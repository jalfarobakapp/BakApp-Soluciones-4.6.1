'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_Remotas_Lista_Permisos_Solicitados

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _TblRemotas As DataTable
    Dim _Cadena_ConexionSQL_Server_Original = Cadena_ConexionSQL_Server
    Dim _Funcionario As String
    Dim _Pwfu As String

    Dim _Permiso_BakApp As New Class_Permiso_BakApp

    Dim _Revisar_Automaticamente_X_Notificacion As Boolean
    Dim _NroRemota_Marcar As String
    Dim _Solo_Mis_Notificaciones As Boolean

    Dim _Cambio_De_Empresa As Boolean
    Dim _Modalidad_Origen As String

    Public Property Pro_NroRemota_Marcar() As String
        Get
            Return _NroRemota_Marcar
        End Get
        Set(value As String)
            _NroRemota_Marcar = value
        End Set
    End Property
    Public Property Pro_Solo_Mis_Notificaciones() As Boolean
        Get
            Return _Solo_Mis_Notificaciones
        End Get
        Set(value As Boolean)
            _Solo_Mis_Notificaciones = value
            Chk_Mis_Permisos.Checked = value
        End Set
    End Property

    Public Sub New(Funcionario As String, Revisar_Automaticamente_X_Notificacion As Boolean)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        _Funcionario = Funcionario

        _Revisar_Automaticamente_X_Notificacion = Revisar_Automaticamente_X_Notificacion

        Chk_Mis_Permisos.Visible = True

        _Modalidad_Origen = Modalidad

        If Global_Thema = Enum_Themas.Oscuro Then
            Btn_Refresh.ForeColor = Color.White
        End If

    End Sub

    Private Sub Frm_Remotas_Lista_Permisos_Solicitados_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        csNotificaciones.Notificacion._Revisando_Permiso_Remoto = True

        _Pwfu = Trim(_Sql.Fx_Trae_Dato("TABFU", "PWFU", "KOFU = '" & _Funcionario & "'"))

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Sb_Actualizar_Grilla()

        If _Revisar_Automaticamente_X_Notificacion Then

            Timer_Notificaciones_automaticas.Enabled = True
            Btn_Cambiar_Modalidad.Enabled = False

        Else

            Grilla.Enabled = True
            Timer_Cierre_Automatico.Interval = (1000 * 60) * 3
            Timer_Cierre_Automatico.Enabled = True
            Btn_Cambiar_Modalidad.Enabled = (_Sql.Fx_Cuenta_Registros("CONFIGP") > 1)

        End If

        AddHandler Chk_Mis_Permisos.CheckedChanged, AddressOf Sb_Actualizar_Grilla

        CircularProgressItem1.IsRunning = Timer_Cierre_Automatico.Enabled

    End Sub

    Sub Sb_Actualizar_Grilla()

        Lbl_Empresa.Text = ModEmpresa & " " & RazonEmpresa

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Remotas_Notif
                        Where NroRemota In (Select NroRemota From " & _Global_BaseBk & "Zw_Remotas Where Eliminada = 1) Or 
                              NroRemota In (Select NroRemota From " & _Global_BaseBk & "Zw_Remotas Where CodFuncionario_Autoriza <> '') Or 
	                          NroRemota Not In (Select NroRemota From " & _Global_BaseBk & "Zw_Remotas)"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        If Chk_Mis_Permisos.Checked Then

            Dim _Monto_Aprobacion As Double = _Sql.Fx_Trae_Dato(_Global_BaseBk & "ZW_PermisosVsUsuarios", "Valor_Max_Compra",
                                                                "CodUsuario = '" & FUNCIONARIO & "' And CodPermiso = 'Comp0092'", True)

            Consulta_sql = "SELECT Empresa,NroRemota,CodFuncionario_Solicita," &
                           "Isnull((Select top 1 NOKOFU From TABFU Where KOFU = CodFuncionario_Solicita),'') As Nombre_Funcionario," &
                           "CodFuncionario_Autoriza,CodPermiso," &
                           "(Select top 1 DescripcionPermiso From " & _Global_BaseBk & "ZW_Permisos Zp " &
                           "Where Zp.CodPermiso = Zr.CodPermiso) As 'Nombre_Permiso',Descripcion_Adicional," &
                           "Permiso_Otorgado,Otorga,Id_Casi_DocEnc," &
                           "(Select Top 1 TipoDoc From " & _Global_BaseBk & "Zw_Casi_DocEnc Where Id_DocEnc = Id_Casi_DocEnc) As TipoDoc," &
                           "CONVERT(VARCHAR, Fecha_Solicita, 103) Fecha,CONVERT(VARCHAR, Fecha_Solicita, 108) Hora," &
                           "CodEntidad,CodSucEntidad,NomEntidad,TotalBruto,Espera_En_Linea,Monto_Aprobacion" & vbCrLf &
                           "Into #Paso" & vbCrLf &
                           "From " & _Global_BaseBk & "Zw_Remotas Zr" & vbCrLf &
                           "Where " & vbCrLf &
                           "(Permiso_Otorgado = 0 And CodFuncionario_Autoriza = '' And Eliminada = 0) And " & vbCrLf &
                           "(" & vbCrLf &
                           "NroRemota In (Select NroRemota From " & _Global_BaseBk & "Zw_Notificaciones" & Space(1) &
                           "Where Empresa = '" & ModEmpresa & "' And Usuario_Destino = '" & FUNCIONARIO & "' And Mostrar = 1 And Accion = 'Remota')" & vbCrLf &
                           "Or 
                           NroRemota In (
                           Select NroRemota From " & _Global_BaseBk & "Zw_Remotas Where NroRemota In 
                            (
							Select NroRemota From " & _Global_BaseBk & "Zw_Remotas_En_Cadena_02_Det 
							Where 
							Id_Enc In (Select Id_Enc From " & _Global_BaseBk & "Zw_Remotas_En_Cadena_01_Enc Where Estado In ('','P'))
						    And CodPermiso = 'Comp0092'
							And Id_Det In (Select Id_Det From " & _Global_BaseBk & "Zw_Remotas_En_Cadena_03_Usu Where Usuario_Destino = '" & FUNCIONARIO & "')
							)))
                            Or NroRemota In (Select NroRemota From " & _Global_BaseBk & "Zw_Remotas_Notif Where CodFuncionario_Destino = '" & FUNCIONARIO & "')
                          
                            Select * From #Paso
                            Drop Table #Paso"

            _TblRemotas = _Sql.Fx_Get_Tablas(Consulta_sql)

        Else

            Consulta_sql = "SELECT Empresa,NroRemota,CodFuncionario_Solicita," &
                           "Isnull((Select top 1 NOKOFU From TABFU Where KOFU = CodFuncionario_Solicita),'') As Nombre_Funcionario," &
                           "CodFuncionario_Autoriza,CodPermiso," &
                           "(Select top 1 DescripcionPermiso From " & _Global_BaseBk & "ZW_Permisos Zp " &
                           "Where Zp.CodPermiso = Zr.CodPermiso) As 'Nombre_Permiso',Descripcion_Adicional," &
                           "Permiso_Otorgado,Otorga,Id_Casi_DocEnc," &
                           "(Select Top 1 TipoDoc From " & _Global_BaseBk & "Zw_Casi_DocEnc Where Id_DocEnc = Id_Casi_DocEnc) As TipoDoc," &
                           "CONVERT(VARCHAR, Fecha_Solicita, 103) Fecha,CONVERT(VARCHAR, Fecha_Solicita, 108) Hora," &
                           "CodEntidad,CodSucEntidad,NomEntidad,TotalBruto,Espera_En_Linea" & vbCrLf &
                           "From " & _Global_BaseBk & "Zw_Remotas Zr" & vbCrLf &
                           "Where Empresa = '" & ModEmpresa & "' And CodFuncionario_Autoriza = '' And Eliminada = 0 
                           Order by Fecha,Hora"

            _TblRemotas = _Sql.Fx_Get_Tablas(Consulta_sql)

        End If

        With Grilla

            .DataSource = _TblRemotas

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            .Columns("Empresa").Visible = True
            .Columns("Empresa").HeaderText = "Emp"
            .Columns("Empresa").Width = 40
            .Columns("Empresa").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CodFuncionario_Solicita").Visible = True
            .Columns("CodFuncionario_Solicita").HeaderText = "Func."
            .Columns("CodFuncionario_Solicita").Width = 35
            .Columns("CodFuncionario_Solicita").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NroRemota").Visible = True
            .Columns("NroRemota").HeaderText = "Nro Remota"
            .Columns("NroRemota").Width = 80
            .Columns("NroRemota").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Nombre_Permiso").Visible = True
            .Columns("Nombre_Permiso").HeaderText = "Descripción permisos solicitado"
            .Columns("Nombre_Permiso").Width = 370
            .Columns("Nombre_Permiso").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("TipoDoc").Visible = True
            .Columns("TipoDoc").HeaderText = "TD"
            .Columns("TipoDoc").Width = 30
            .Columns("TipoDoc").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Fecha").Visible = True
            .Columns("Fecha").HeaderText = "Fecha"
            .Columns("Fecha").Width = 100
            .Columns("Fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Hora").Visible = True
            .Columns("Hora").HeaderText = "Hora"
            .Columns("Hora").Width = 60
            .Columns("Hora").DefaultCellStyle.Format = "hh:mm:ss"
            .Columns("Hora").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NomEntidad").Visible = True
            .Columns("NomEntidad").HeaderText = "Nombre entidad"
            .Columns("NomEntidad").Width = 200
            .Columns("NomEntidad").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        For Each _Fila As DataGridViewRow In Grilla.Rows

            Dim _NroRemota = _Fila.Cells("NroRemota").Value
            Dim _CodFuncionario_Solicita = _Fila.Cells("CodFuncionario_Solicita").Value

            If _NroRemota = _NroRemota_Marcar Then
                _Fila.DefaultCellStyle.BackColor = Color.Yellow
                If Global_Thema = Enum_Themas.Oscuro Then
                    _Fila.DefaultCellStyle.BackColor = Color.LightYellow
                    _Fila.DefaultCellStyle.ForeColor = Color.Black
                End If
            End If

            If _CodFuncionario_Solicita = FUNCIONARIO Then
                _Fila.DefaultCellStyle.BackColor = Color.LightGray
            End If

        Next

        Me.Text = "Listado de permisos solicitados por los usuarios remotamente, Empresa: " & RazonEmpresa

    End Sub

    Private Sub Frm_Remotas_Lista_Permisos_Solicitados_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
            'Me.Hide()
            'NotifyIcon1.Visible = True
            'NotifyIcon1.ShowBalloonTip(2, "Info. BakApp", "Permiso remoto quedara en barra de tareas", ToolTipIcon.Info)
        End If
    End Sub

    Private Sub Btn_Refresh_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Refresh.Click
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub Grilla_CellEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellEnter

        Dim _CodPermiso = String.Empty
        Dim _Nombre_Funcionario = String.Empty
        Dim _Descripcion_Adicional = String.Empty
        Dim _Descripcion_del_permiso = String.Empty
        Dim _TotalBruto As Double

        Try
            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

            _CodPermiso = _Fila.Cells("CodPermiso").Value
            _Nombre_Funcionario = _Fila.Cells("Nombre_Funcionario").Value
            _Descripcion_Adicional = _Fila.Cells("Descripcion_Adicional").Value
            _TotalBruto = _Fila.Cells("TotalBruto").Value
            _Descripcion_del_permiso = _Fila.Cells("Nombre_Permiso").Value

        Catch ex As Exception

        Finally

            Lbl_Nombre_Solicitante.Text = _Nombre_Funcionario
            Lbl_Descripcion_Adicional.Text = _Descripcion_Adicional
            Lbl_TotalBruto.Text = FormatCurrency(_TotalBruto, 0)
            Lbl_Descripcion_del_permiso.Text = "( " & _CodPermiso & " ) - " & _Descripcion_del_permiso

        End Try

    End Sub

    Private Sub Timer_Notificaciones_Tick(sender As System.Object, e As System.EventArgs) Handles Timer_Actualizar_Remotas.Tick

        Dim _Reg As Integer

        Dim _Filtro_Remotas = Generar_Filtro_IN(_TblRemotas, "", "NroRemota", False, False, "'")

        If _Filtro_Remotas <> "()" Then

            _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Remotas",
                   "NroRemota Not In " & _Filtro_Remotas & " And CodFuncionario_Autoriza = '' And Id_Casi_DocEnc <> 0 And Eliminada = 0")

        Else

            _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Remotas", "Id_Casi_DocEnc <> 0 And CodFuncionario_Autoriza = '' And Eliminada = 0")

        End If

        If CBool(_Reg) Then

            Sb_Actualizar_Grilla()

        End If

    End Sub

    Private Sub Chk_Notificacion_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Chk_Notificacion_Descuento.CheckedChanged
        Timer_Actualizar_Remotas.Enabled = Chk_Notificacion_Descuento.Checked
        Me.Refresh()
    End Sub

    Private Sub Grilla_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Me.Enabled = False

        Sb_Revisar_Registro_Para_Permiso(_Fila)

        Me.Enabled = True

    End Sub

    Sub Sb_Revisar_Registro_Para_Permiso(_Fila As DataGridViewRow)

        Timer_Cierre_Automatico.Stop()
        CircularProgressItem1.Visible = False

        Dim _Id_Casi_DocEnc = _Fila.Cells("Id_Casi_DocEnc").Value
        Dim _CodFuncionario_Solicita = _Fila.Cells("CodFuncionario_Solicita").Value

        If _CodFuncionario_Solicita = FUNCIONARIO Then
            MessageBoxEx.Show(Me, "No se puede dar permisos a usted mismo", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, Me.TopMost)
        Else
            Sb_Revisar_Permiso(_Fila)
        End If

        Timer_Cierre_Automatico.Start()
        CircularProgressItem1.Visible = True

        Me.Refresh()

    End Sub

    Sub Sb_Revisar_Permiso(_Fila As DataGridViewRow)

        Dim _Id_Casi_DocEnc As Integer = _Fila.Cells("Id_Casi_DocEnc").Value
        Dim _NroRemota As String = _Fila.Cells("NroRemota").Value
        Dim _Nombre_Permiso As String = _Fila.Cells("Nombre_Permiso").Value
        Dim _CodFuncionario_Solicita As String = _Fila.Cells("CodFuncionario_Solicita").Value
        Dim _Espera_En_Linea As Boolean = _Fila.Cells("Espera_En_Linea").Value

        Dim _CodEntidad As String = _Fila.Cells("CodEntidad").Value
        Dim _CodSucEntidad As String = _Fila.Cells("CodSucEntidad").Value


        Dim _DsDocumento As DataSet

        Dim _Tbl_Encabezado As DataTable
        Dim _Tbl_Detalle As DataTable


        Dim _CodPermiso As String = _Fila.Cells("CodPermiso").Value

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Remotas" & vbCrLf &
                       "Where NroRemota = '" & _NroRemota & "'"
        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)
        Dim _Eliminada As Boolean

        If CBool(_Tbl.Rows.Count) Then
            _Eliminada = _Tbl.Rows(0).Item("Eliminada")
        Else
            _Eliminada = True
        End If

        If Not _Eliminada Then

            If _Permiso_BakApp.Fx_Tiene_Permiso(_CodPermiso, _Funcionario, True, False, , , , False, False) Then

                Dim _Rows_Info_Remota As DataRow
                Dim _Rows_Usuario_Autoriza As DataRow

                If _Funcionario = FUNCIONARIO Then
                    _Rows_Info_Remota = _Tbl.Rows(0)
                    _Funcionario = FUNCIONARIO
                Else
                    _Rows_Info_Remota = _Permiso_BakApp.Pro_Rows_Info_Remota
                    _Rows_Usuario_Autoriza = _Permiso_BakApp.Pro_Rows_Usuario_Autoriza
                    _Funcionario = _Rows_Usuario_Autoriza.Item("KOFU")
                End If

                If CBool(_Id_Casi_DocEnc) Then

                    _DsDocumento = Fx_Revisar_Documento_Trae_Ds(_Fila)

                End If

                'Select Case _CodPermiso

                'Case "Bkp00014", "Bkp00015", "Bkp00019", "Bkp00033", "Bkp00057", "Comp0092", "Comp0095"

                If Not (_DsDocumento Is Nothing) Then

                    _Tbl_Encabezado = _DsDocumento.Tables(0)
                    _Tbl_Detalle = _DsDocumento.Tables(1)

                    Dim _Autorizado = False
                    Dim _Rechazado = False

                    ' PERMISOS
                    Sb_Revisar_Documento_Remoto(_NroRemota, _Autorizado, _Rechazado)

                    If _Autorizado Or _Rechazado Then

                        Sb_Actualizar_Notificacion(_Autorizado, _Rechazado, _NroRemota, _CodFuncionario_Solicita, _Espera_En_Linea)

                        If Not _Revisar_Automaticamente_X_Notificacion Then

                            Sb_Actualizar_Grilla()
                            Me.WindowState = FormWindowState.Normal

                        End If

                    End If

                    If _TblRemotas.Rows.Count = 0 Or _Revisar_Automaticamente_X_Notificacion Then Me.Close()

                    Timer_Cierre_Automatico.Start()
                    CircularProgressItem1.Visible = True

                Else

                    LabelItem2.Visible = Not String.IsNullOrWhiteSpace(_CodEntidad)
                    Btn_Ver_deuda_pendiente.Visible = Not String.IsNullOrWhiteSpace(_CodEntidad)

                    ShowContextMenu(Menu_Contextual_01)

                End If

            Else

                MessageBoxEx.Show(Me, "Usted no posee permiso para realizar esta acción", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, Me.TopMost)

                Return

            End If

        Else

            MessageBoxEx.Show(Me, "El permiso ya no está disponible en línea", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Sb_Actualizar_Grilla()

        End If

    End Sub

    Sub Sb_Revisar_Documento_Remoto(_NroRemota As String,
                                    ByRef _Autorizado As Boolean,
                                    ByRef _Rechazado As Boolean)

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Remotas Where NroRemota = '" & _NroRemota & "'"
        Dim _Row_Remota As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _CodPermiso As String = _Row_Remota.Item("CodPermiso")

        Dim _CodFuncionario_Solicita = _Row_Remota.Item("CodFuncionario_Solicita")

        Dim _Eliminada As Boolean = _Row_Remota.Item("Eliminada")

        If Not _Eliminada Then

            Dim _Id_Casi_DocEnc = _Row_Remota.Item("Id_Casi_DocEnc")

            Consulta_sql = "Select *,(Select Top 1 NOKOFU From TABFU Where KOFU = CodFuncionario) As Funcionario" & vbCrLf &
                           "From " & _Global_BaseBk & "Zw_Casi_DocTom Where Id_DocEnc = " & _Id_Casi_DocEnc
            Dim _Row_Zw_Casi_DocTom As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If (_Row_Zw_Casi_DocTom Is Nothing) Then


                Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Casi_DocEnc Where Id_DocEnc = " & _Id_Casi_DocEnc
                Dim _Row_Casi_DocEn As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                Dim _TipoDoc As String = _Row_Casi_DocEn.Item("TipoDoc")
                Dim _Tipo_Documento As csGlobales.Enum_Tipo_Documento
                Dim _Revisar_Documento = False

                Select Case _TipoDoc

                    Case "NVV", "BLV", "FCV", "GDV", "COV"

                        _Tipo_Documento = csGlobales.Enum_Tipo_Documento.Venta
                        _Revisar_Documento = True

                    Case "OCC"

                        _Tipo_Documento = csGlobales.Enum_Tipo_Documento.Compra

                        Dim _Id_DocEnc As Integer = _Row_Remota.Item("Id_Casi_DocEnc")
                        Dim _Monto_Aprobacion As Double = _Row_Remota.Item("Monto_Aprobacion")

                        Dim _Tido = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Casi_DocEnc", "TipoDoc", "Id_DocEnc = " & _Id_DocEnc)

                        If _Tido = "OCC" Then

                            Dim _Puede_Dar_Permiso = False

                            If _CodPermiso = "Comp0092" Then

                                Dim _Jefes As New List(Of String)

                                Fx_Insertar_Jefe_Y_SubJefes(_CodFuncionario_Solicita, _Jefes)

                                For Each _CodJefe As String In _Jefes

                                    If _CodJefe = FUNCIONARIO Then
                                        _Puede_Dar_Permiso = True
                                        Exit For
                                    End If

                                Next

                                If _Puede_Dar_Permiso Then

                                    Dim _Valor_Max_Compra As Double = _Sql.Fx_Trae_Dato(_Global_BaseBk & "ZW_PermisosVsUsuarios", "Valor_Max_Compra",
                                                                                "CodUsuario = '" & FUNCIONARIO & "' And CodPermiso = 'Comp0092'")

                                    If _Valor_Max_Compra < _Monto_Aprobacion Then
                                        MessageBoxEx.Show(Me, "Usted no puede autorizar esta orden de compra, ya que el monto asignado para su aprobación no es suficiente en esta etapa." & Environment.NewLine &
                                                      "Monto necesario: " & FormatCurrency(_Monto_Aprobacion, 0) & Environment.NewLine &
                                                      "Monto máximo que usted puede autorizar: " & FormatCurrency(_Valor_Max_Compra, 0),
                                                      "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, Me.TopMost)
                                        Return
                                    End If

                                Else

                                    MessageBoxEx.Show(Me, "Usted no puede autorizar esta Orden de compra, ya que no tiene relación de jefatura con el usuario que solicita el permiso",
                                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, Me.TopMost)
                                    Return

                                End If

                                _Revisar_Documento = _Puede_Dar_Permiso

                            End If

                            If _CodPermiso = "Comp0095" Then

                                Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Prod_Usuario_Validador 
                                                Where Empresa = '" & ModEmpresa & "' And CodFuncionario = '" & FUNCIONARIO &
                                                "' And Codigo In (Select Codigo From " & _Global_BaseBk & "Zw_Casi_DocDet " &
                                                "Where Id_DocEnc = " & _Id_DocEnc & " And FunValida_Compra = '')"

                                Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                                If CBool(_Tbl.Rows.Count) Then

                                    _Revisar_Documento = True

                                Else

                                    MessageBoxEx.Show(Me, "Usted no puede autorizar esta orden de compra, ya que no hay productos que necesiten de su validación",
                                                      "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, Me.TopMost)
                                    Return

                                End If

                            End If

                        End If

                End Select

                If _Revisar_Documento Then

                    'Me.WindowState = FormWindowState.Minimized

                    Dim Fm As New Frm_Formulario_Documento(_TipoDoc, _Tipo_Documento, False, True, False)
                    Fm.Pro_RowRemota_Notificacion = _Row_Remota
                    Fm.Pro_Correr_a_la_derecha = True
                    Fm.Pro_Revision_Remota = True
                    Fm.ShowDialog(Me)

                    _Autorizado = Fm.Pro_Autorizado_Remota
                    _Rechazado = Fm.Pro_Rechazado_Remota
                    Fm.Dispose()

                End If

            Else

                Dim _Funcionario = _Row_Zw_Casi_DocTom.Item("Funcionario")
                MessageBoxEx.Show(Me, "El documento se encuentra tomado por: " & _Funcionario,
                                  "El permisos esta siendo atentido", MessageBoxButtons.OK, MessageBoxIcon.Information,
                                  MessageBoxDefaultButton.Button1, Me.TopMost)

            End If

        Else

            MessageBoxEx.Show(Me, "El permiso ya no está disponible en línea", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Information,
                              MessageBoxDefaultButton.Button1, Me.TopMost)

        End If

    End Sub

    Function Fx_Revisar_Documento_Trae_Ds(_Fila As DataGridViewRow) As DataSet

        Dim _Id_Casi_DocEnc As Integer = _Fila.Cells("Id_Casi_DocEnc").Value
        Dim _NroRemota As String = _Fila.Cells("NroRemota").Value

        Dim _Id_DocEnc = _Id_Casi_DocEnc

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Casi_DocEnc Where Id_DocEnc = " & _Id_DocEnc & vbCrLf &
                       "Select * From " & _Global_BaseBk & "Zw_Casi_DocDet Where Id_DocEnc = " & _Id_DocEnc & vbCrLf &
                       "Select * From " & _Global_BaseBk & "Zw_Casi_DocDsc Where Id_DocEnc = " & _Id_DocEnc & vbCrLf &
                       "Select * From " & _Global_BaseBk & "Zw_Casi_DocImp Where Id_DocEnc = " & _Id_DocEnc & vbCrLf &
                       "Select * From " & _Global_BaseBk & "Zw_Casi_DocObs Where Id_DocEnc = " & _Id_DocEnc & vbCrLf

        Dim _DsDocumento As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

        Dim _Tbl_Encabezado As DataTable = _DsDocumento.Tables(0)
        Dim _Tbl_Detalle As DataTable = _DsDocumento.Tables(1)

        Dim _TieneEnc As Boolean = CBool(_Tbl_Encabezado.Rows.Count)
        Dim _TieneDet As Boolean = CBool(_Tbl_Detalle.Rows.Count)

        If _TieneEnc And _TieneDet Then

            Return _DsDocumento

        Else

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Remotas Set " & vbCrLf &
                           "CodFuncionario_Autoriza = '',Permiso_Otorgado = 0," & vbCrLf &
                           "Otorga = 'Eliminado',Fecha_Otorga = GetDate(),Eliminada = 1" & vbCrLf &
                           "Where NroRemota = '" & _NroRemota & "'"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            MessageBoxEx.Show(Me, "El permiso ya no está disponible en línea", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop,
                              MessageBoxDefaultButton.Button1, Me.TopMost)

            _DsDocumento = Nothing

            Sb_Actualizar_Grilla()

        End If

    End Function

    Private Sub Frm_Remotas_Lista_Permisos_Solicitados_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        csNotificaciones.Notificacion._Revisando_Permiso_Remoto = False
        Cadena_ConexionSQL_Server = _Cadena_ConexionSQL_Server_Original

        If _Cambio_De_Empresa Then

            Fx_Conectar_Empresa(Me, True)

        Else

            If Not _Revisar_Automaticamente_X_Notificacion And Modalidad <> _Modalidad_Origen Then

                Dim _Mod As New Clas_Modalidades

                _Mod.Sb_Actualiza_Formatos_X_Modalidad()
                _Mod.Sb_Actualizar_Variables_Modalidad(_Modalidad_Origen)

            End If

        End If

    End Sub

    Private Sub Btn_Cambiar_de_empresa_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Cambiar_de_empresa.Click

        Timer_Cierre_Automatico.Stop()
        CircularProgressItem1.Visible = False

        Sb_Cambiar_Empresa(_Cambio_De_Empresa)

        Timer_Cierre_Automatico.Start()
        CircularProgressItem1.Visible = True

        Me.Refresh()

    End Sub

    Sub Sb_Cambiar_Empresa(ByRef _Cambio_De_Empresa As Boolean)

        Dim _Conexion_establecida As Boolean
        Dim _Cadena_ConexionSQL_Seleccionada = String.Empty

        Try

            Dim DatosConex As New ConexionBK

            Dim Directorio As String = Application.StartupPath & "\Data\"
            Dim _Exists = System.IO.File.Exists(Directorio & "Conexiones.xml")

            If Not _Exists Then

                DatosConex.WriteXml(Directorio & "Conexiones.xml")
                MessageBoxEx.Show("Arvhico XML creado correctamente", "Crear XML de Conexión",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return

            End If

            DatosConex.ReadXml(Directorio & "Conexiones.xml")

            Dim Frm_ConexionBD As New Frm_ConexionBD
            Frm_ConexionBD.BtnAgregar.Visible = False
            Frm_ConexionBD.BtnGenerateKey.Visible = False
            Frm_ConexionBD.ShowDialog(Me)

            If Frm_ConexionBD.NombreConexionActiva = String.Empty Then
                Frm_ConexionBD.Dispose()
                Return
            Else
                _Cadena_ConexionSQL_Seleccionada = Fx_CadenaConexionSQL(Frm_ConexionBD.NombreConexionActiva, DatosConex)
            End If

            Frm_ConexionBD.Dispose()

            If _Cadena_ConexionSQL_Seleccionada = Cadena_ConexionSQL_Server Then

                Beep()
                ToastNotification.Show(Me, "YA ESTA CONECTADO A ESTA EMPRESA", Btn_Cambiar_de_empresa.Image,
                                       2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
                Return

            End If

            Cadena_ConexionSQL_Server = _Cadena_ConexionSQL_Seleccionada

            If Fx_Conectar_Empresa(Me, True) Then

                _Cambio_De_Empresa = True

                _Sql = New Class_SQL(Cadena_ConexionSQL_Server)

                Consulta_sql = "Select top 1 * From TABFU Where PWFU = '" & _Pwfu & "'"
                Dim _TblFun As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                If CBool(_TblFun.Rows.Count) Then

                    Dim _Kofu = Trim(_TblFun.Rows(0).Item("KOFU"))
                    Dim _Nokofu = Trim(_TblFun.Rows(0).Item("NOKOFU"))

                    Dim Fm_L As New Frm_Login

                    If Fm_L.Fx_Sesion_Star(Me, _Kofu, _Nokofu) Then

                        If Fx_Tiene_Permiso(Me, "Espr0009", _Kofu) Then
                            _Conexion_establecida = True
                        Else
                            Cadena_ConexionSQL_Server = _Cadena_ConexionSQL_Server_Original
                            Fx_Conectar_Empresa(Me, True)
                            _Sql = New Class_SQL(Cadena_ConexionSQL_Server)
                        End If

                    Else

                        Cadena_ConexionSQL_Server = _Cadena_ConexionSQL_Server_Original
                        Fx_Conectar_Empresa(Me, True)
                        _Sql = New Class_SQL(Cadena_ConexionSQL_Server)

                    End If

                Else

                    MessageBoxEx.Show(Me, "No se reconoce el usuario en la empresa: " & RazonEmpresa & vbCrLf &
                                      "Revise la clave, puede que sea distinta entre ambas bases", "Validación",
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, Me.TopMost)


                    Cadena_ConexionSQL_Server = _Cadena_ConexionSQL_Server_Original
                    Fx_Conectar_Empresa(Me, True)
                    _Sql = New Class_SQL(Cadena_ConexionSQL_Server)

                End If

            End If

        Catch ex As Exception
            MessageBoxEx.Show(ex.Message)
        Finally

            Sb_Actualizar_Grilla()

            If _Conexion_establecida Then
                Beep()
                ToastNotification.Show(Me, "CONEXION ESTABLECIDA: " & RazonEmpresa, Btn_Cambiar_de_empresa.Image,
                                       2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
            End If

        End Try

    End Sub

    Function Fx_Permisos_CtaCte_Entidad(_NroRemota As String,
                                        _CodPermiso As String) As Boolean

        Dim _Row_Encabezado_Venta As DataRow

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Remotas Where NroRemota = '" & _NroRemota & "'"
        Dim _Row_Remota As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Id_Casi_DocEnc = _Row_Remota.Item("Id_Casi_DocEnc")

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Casi_DocEnc Where Id_DocEnc = " & _Id_Casi_DocEnc
        _Row_Encabezado_Venta = _Sql.Fx_Get_DataRow(Consulta_sql)

        With _Row_Encabezado_Venta

            Dim _CodEntidad = .Item("CodEntidad")
            Dim _CodSucEntidad = .Item("CodSucEntidad")

            Dim _TotalBruto = .Item("TotalBruto")
            Dim _Row_Inf_Entidad As DataRow = Fx_Traer_Datos_Entidad(_CodEntidad, _CodSucEntidad)

            Dim _NOTRAEDEUD As Boolean = _Row_Inf_Entidad.Item("NOTRAEDEUD")

            If Not _NOTRAEDEUD Then

                Dim Fm_D As New Frm_InfoEnt_Deudas_Doc_Comerciales(_Row_Inf_Entidad, _TotalBruto, 0, 0, 0, True)

                Fm_D.Pro_FechaEmision = .Item("FechaEmision")
                Fm_D.Pro_Fecha_1er_Vencimiento = .Item("Fecha_1er_Vencimiento")
                Fm_D.Pro_FechaUltVencimiento = .Item("FechaUltVencimiento")
                Fm_D.Pro_Cuotas = .Item("Cuotas")
                Fm_D.Pro_Dias_1er_Vencimiento = .Item("Dias_1er_Vencimiento")
                Fm_D.Pro_Dias_Vencimiento = .Item("Dias_Vencimiento")

                Fm_D.ShowDialog(Me)

                If Fm_D.Pro_Grabar_Vencimientos Then

                    If _CodPermiso = "Bkp00019" Then

                        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Remotas Set " & vbCrLf &
                                       "CodFuncionario_Autoriza = '" & _Funcionario & "',Permiso_Otorgado = 1," & vbCrLf &
                                       "Otorga = 'Autorizado',Fecha_Otorga = GetDate()" & vbCrLf &
                                       "Where NroRemota = '" & _NroRemota & "'" & vbCrLf &
                                       "Update " & _Global_BaseBk & "Zw_Casi_DocEnc Set Funcionario_Autoriza_Deuda_Vencida = '" & _Funcionario & "'" & vbCrLf &
                                       "Where Id_DocEnc = " & _Id_Casi_DocEnc
                        _Sql.Ej_consulta_IDU(Consulta_sql)

                    End If

                End If

                Fm_D.Dispose()

            Else

                Beep()
                ToastNotification.Show(Me, "ESTA ENTIDAD NO AFECTA REVISION CTA. CORRIENTE",
                                     My.Resources.cross,
                                       2 * 1000, eToastGlowColor.Red,
                                       eToastPosition.MiddleCenter)

            End If

        End With

    End Function

    Sub Sb_Rechazar_Permiso(_NroRemota As String)

        Dim _Aceptado As Boolean
        Dim _Observaciones As String

        _Aceptado = InputBox_Bk(Me, "Ingrese motivo del rechazo", "Solicitud rechazada", _Observaciones, True,
                               _Tipo_Mayus_Minus.Mayusculas, 200, True, _Tipo_Imagen.Texto,
                               False, _Tipo_Caracter.Cualquier_caracter)

        If _Aceptado Then

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Remotas Set " & vbCrLf &
                           "CodFuncionario_Autoriza = '" & _Funcionario & "',Otorga = 'Rechazado'," & vbCrLf &
                           "Observaciones = '" & _Observaciones & "',Fecha_Otorga = GetDate()" & vbCrLf &
                           "Where NroRemota = '" & _NroRemota & "'"

            _Sql.Ej_consulta_IDU(Consulta_sql)

        End If

    End Sub

    Private Sub Btn_Admin_Permisos_Usuarios_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Admin_Permisos_Usuarios.Click

        Dim _Autorizado As Boolean

        Dim Fm_Pass As New Frm_Clave_Administrador
        Fm_Pass.ShowDialog(Me)
        _Autorizado = Fm_Pass.Pro_Autorizado
        Fm_Pass.Dispose()

        If _Autorizado Then
            Dim Fm As New Frm_Permisos_Usuario_Lista
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If

    End Sub

    Private Sub Timer_Cierre_Automatico_Tick(sender As System.Object, e As System.EventArgs) Handles Timer_Cierre_Automatico.Tick
        Me.Close()
    End Sub

    Sub Sb_Actualizar_Notificacion(_Autorizado As Boolean,
                                   _Rechazado As Boolean,
                                   _NroRemota As String,
                                   _CodFuncionario_Solicita As String,
                                   _Espera_En_Linea As Boolean)

        Dim _Consulta_sql As String

        _Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Notificaciones" & vbCrLf &
                        "Where Usuario_Solicita = '" & _CodFuncionario_Solicita & "' And NroRemota = '" & _NroRemota & "'"
        Dim _Row_Notificacion As DataRow = _Sql.Fx_Get_DataRow(_Consulta_sql)

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Remotas Where NroRemota = '" & _NroRemota & "'"
        Dim _Row_Remota As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _RCadena = _Row_Remota.Item("RCadena")
        Dim _RCadena_Id_Enc = _Row_Remota.Item("RCadena_Id_Enc")

        If _RCadena Then

            _Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Notificaciones" & vbCrLf &
                            "Where NroRemota = '" & _NroRemota & "'"
            _Sql.Ej_consulta_IDU(_Consulta_sql)

            Dim _Crear_Doc_Def_Al_Grabar As Boolean = _Row_Remota.Item("Crear_Doc_Def_Al_Grabar")
            Dim _Idmaeedo = _Row_Remota.Item("Idmaeedo")

            Dim _Row_Documento As DataRow
            Dim _Tido, _Nudo, _Razon, _Total As String

            Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Remotas_En_Cadena_01_Enc Where Id_Enc = " & _RCadena_Id_Enc
            Dim _RowCRemota As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim _Nro_RCadena = _RowCRemota.Item("Nro_RCadena")

            Dim _Nombre_Correo As String
            Dim _Asunto As String
            Dim _Para As String
            Dim _Enviar_Correo As Boolean

            If _Autorizado Then

                If _Crear_Doc_Def_Al_Grabar Then

                    _Consulta_sql = "Select TIDO,NUDO,ENDO,SUENDO," &
                                     "Isnull((Select Top 1 NOKOEN From MAEEN Where KOEN+SUEN = ENDO+SUENDO),'') As RAZON,VABRDO" & vbCrLf &
                                     "From MAEEDO" & vbCrLf &
                                     "Where IDMAEEDO = " & _Idmaeedo
                    _Row_Documento = _Sql.Fx_Get_DataRow(_Consulta_sql)

                    If Not IsNothing(_Row_Documento) Then

                        _Tido = _Row_Documento.Item("TIDO")
                        _Nudo = _Row_Documento.Item("NUDO")
                        _Razon = Trim(_Row_Documento.Item("RAZON"))
                        _Total = FormatCurrency(_Row_Documento.Item("VABRDO"), 0)

                        If _Tido = "OCC" Then

                            _Razon = "PROVEEDOR: " & _Razon
                            _Nombre_Correo = _Global_Row_Configuracion_General.Item("Nombre_Usuario_Correo_Remotas")
                            _Asunto = "PERMISO ACEPTADO PARA LA SOLICITUD REMOTA Nro:" & _Nro_RCadena & " (" & _NroRemota & ")"
                            _Para = _Sql.Fx_Trae_Dato("TABFU", "EMAIL", "KOFU = '" & _CodFuncionario_Solicita & "'")
                            _Enviar_Correo = True

                        Else

                            _Razon = "CLIENTE: " & _Razon

                        End If

                        csNotificaciones.Notificacion.Fx_Insertar_Notificacion(FUNCIONARIO,
                                                                               _CodFuncionario_Solicita, "PERMISO REMOTO",
                                                                               "PERMISO ACEPTADO PARA LA SOLICITUD REMOTA Nro:" & _Nro_RCadena & " (" & _NroRemota & ")" & vbCrLf & vbCrLf &
                                                                               "DOCUMENTO GENERADO " & _Tido & "-" & _Nudo & vbCrLf &
                                                                               _Razon & vbCrLf & "TOTAL: " & _Total,
                                                                               csNotificaciones.Notificacion.Imagen.Ok, _NroRemota, False, 0, True, _RCadena_Id_Enc,
                                                                               _Enviar_Correo, _Nombre_Correo, _Asunto, _Para)

                    End If

                End If

            ElseIf _Rechazado Then

                _Tido = _RowCRemota.Item("Tido")

                If _Tido = "OCC" Then

                    _Razon = "PROVEEDOR: " & _RowCRemota.Item("Nombre_Entidad")
                    _Nombre_Correo = _Global_Row_Configuracion_General.Item("Nombre_Usuario_Correo_Remotas")
                    _Asunto = "PERMISO DENEGADO PARA LA SOLICITUD REMOTA Nro:" & _Nro_RCadena & " (" & _NroRemota & ")"
                    _Para = _Sql.Fx_Trae_Dato("TABFU", "EMAIL", "KOFU = '" & _CodFuncionario_Solicita & "'")
                    _Enviar_Correo = True

                End If

                csNotificaciones.Notificacion.Fx_Insertar_Notificacion(FUNCIONARIO,
                                _CodFuncionario_Solicita, "PERMISO REMOTO",
                                "PERMISO DENEGADO PARA LA SOLICITUD REMOTA Nro:" & _Nro_RCadena & " (" & _NroRemota & ")" & vbCrLf & _Row_Remota.Item("Observaciones") & vbCrLf & vbCrLf &
                                "DEBE REVISAR LOS DOCUMENTOS CON PERMISOS PENDIENTES",
                                csNotificaciones.Notificacion.Imagen.Rechazado, _NroRemota, False, 0, True, _RCadena_Id_Enc,
                                _Enviar_Correo, _Nombre_Correo, _Asunto, _Para)

            End If

        End If

        If _Espera_En_Linea Then

            _Consulta_sql = "Update " & _Global_BaseBk & "Zw_Notificaciones Set" & Space(1) &
                            "Mostrar = 0,Autorizado = " & CInt(_Autorizado) * -1 & ", Rechazado = " & CInt(_Rechazado) * -1 & vbCrLf &
                            "Where NroRemota = '" & _NroRemota & "'"
            _Sql.Ej_consulta_IDU(_Consulta_sql)

        End If

    End Sub

    Private Sub Timer_Notificaciones_automaticas_Tick(sender As System.Object, e As System.EventArgs) Handles Timer_Notificaciones_automaticas.Tick

        Timer_Notificaciones_automaticas.Enabled = False
        Me.Hide()

        For Each _Fila As DataGridViewRow In Grilla.Rows

            Dim _NroRemota_Linea = _Fila.Cells("NroRemota").Value

            If _NroRemota_Linea = _NroRemota_Marcar Then
                Me.TopMost = False
                Sb_Revisar_Registro_Para_Permiso(_Fila)
                Exit For
            End If

        Next

        Me.Close()

    End Sub

    Private Sub Btn_Otorgar_Permiso_Click(sender As Object, e As EventArgs) Handles Btn_Otorgar_Permiso.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _NroRemota As String = _Fila.Cells("NroRemota").Value
        Dim _Espera_En_Linea As Boolean = _Fila.Cells("Espera_En_Linea").Value

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Remotas Set 
                        CodFuncionario_Autoriza = '" & _Funcionario & "',Permiso_Otorgado = 1,
                        Otorga = 'Autorizado',Fecha_Otorga = GetDate()
                        Where NroRemota = '" & _NroRemota & "'"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        If _Espera_En_Linea Then

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Notificaciones
                            Where NroRemota = '" & _NroRemota & "'"
            _Sql.Ej_consulta_IDU(Consulta_sql)
            Me.Close()

        Else

            Sb_Actualizar_Grilla()

            If Not Convert.ToBoolean(_TblRemotas.Rows.Count) Then
                MessageBoxEx.Show(Me, "No existen mas permisos pendientes", "Permisos Remotos",
                                                          MessageBoxButtons.OK, MessageBoxIcon.Information,
                                                          MessageBoxDefaultButton.Button1, Me.TopMost)
                Me.Close()
            End If

        End If

    End Sub

    Private Sub Btn_Rechazar_Permiso_Click(sender As Object, e As EventArgs) Handles Btn_Rechazar_Permiso.Click

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow

        Dim _NroRemota As String = _Fila.Cells("NroRemota").Value
        Dim _Espera_En_Linea As Boolean = _Fila.Cells("Espera_En_Linea").Value

        Sb_Rechazar_Permiso(_NroRemota)

        If _Espera_En_Linea Then

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Notificaciones" & vbCrLf &
                           "Where NroRemota = '" & _NroRemota & "'"
            _Sql.Ej_consulta_IDU(Consulta_sql)
            Me.Close()

        Else

            Sb_Actualizar_Grilla()

        End If

    End Sub

    Private Sub Btn_Cambiar_Modalidad_Click(sender As Object, e As EventArgs) Handles Btn_Cambiar_Modalidad.Click

        Dim _Modalidad As String = Modalidad

        Dim _ModEmpresa = ModEmpresa
        Dim _ModSucursal = ModSucursal

        Dim Frm_Modalidad As New Frm_Modalidades(False)
        Frm_Modalidad.ControlBox = True
        Frm_Modalidad.ShowDialog(Me)
        Frm_Modalidad.Dispose()

        _Global_Frm_Menu.Refresh()

        If _ModSucursal <> ModSucursal Then

            Sb_Actualizar_Grilla()

        End If

    End Sub

    Private Sub Btn_Ver_deuda_pendiente_Click(sender As Object, e As EventArgs) Handles Btn_Ver_deuda_pendiente.Click

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow

        Dim _Koen As String = _Fila.Cells("CodEntidad").Value
        Dim _Suen As String = _Fila.Cells("CodSucEntidad").Value

        Dim _RowEntidad As DataRow = Fx_Traer_Datos_Entidad(_Koen, _Suen)

        Dim Fm As New Frm_InfoEnt_Deudas_Doc_Comerciales(_RowEntidad, 0, 0, 0, 0, True)
        Fm.Btn_CambCodPago.Visible = False
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

End Class
