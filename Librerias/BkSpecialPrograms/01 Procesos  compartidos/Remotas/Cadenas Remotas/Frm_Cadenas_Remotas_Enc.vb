'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_Cadenas_Remotas_Lista

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _TblCRemotas_Enc As DataTable
    Dim _Filtro_Extra As String

    Dim _Revisar_Notificacion As Boolean
    Dim _Id_Enc_Revisar As Integer

    Dim _Modalidad_Origen As String

    Dim _Fecha_Desde As Date

    Enum Enum_Accion
        Mis_CRemotas
        Revision_CRemotas
    End Enum

    Dim _Accion As Enum_Accion
    Dim _Tido As String

    Public Property Pro_Filtro_Extra As String
        Get
            Return _Filtro_Extra
        End Get
        Set(value As String)
            _Filtro_Extra = value
        End Set
    End Property

    Public Property Pro_Revisar_Notificacion As Boolean
        Get
            Return _Revisar_Notificacion
        End Get
        Set(value As Boolean)
            _Revisar_Notificacion = value
        End Set
    End Property

    Public Property Pro_Id_Enc_Revisar As Integer
        Get
            Return _Id_Enc_Revisar
        End Get
        Set(value As Integer)
            _Id_Enc_Revisar = value
        End Set
    End Property

    Public Sub New(Accion As Enum_Accion, Tido As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)

        '_Accion = Accion

        CircularProgressItem1.IsRunning = True
        _Accion = Accion
        _Tido = Tido

        If _Accion = Enum_Accion.Mis_CRemotas Then
            Me.Text += Space(1) & "del usuario activo"
        End If

        _Fecha_Desde = FechaDelServidor()

        Dtp_Fecha_Emision_Hasta.Value = _Fecha_Desde
        Dtp_Fecha_Emision_Desde.Value = _Fecha_Desde

        _Modalidad_Origen = Modalidad

        Chk_Mostrar_Todas.Visible = (_Tido = "OCC" And Not _Accion = Enum_Accion.Mis_CRemotas)

        If Global_Thema = Enum_Themas.Oscuro Then
            Btn_Refresh.ForeColor = Color.White
        End If

    End Sub

    Private Sub Frm_Cadenas_Remotas_Lista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim _Fecha = Format(FechaDelServidor, "yyyyMMdd")

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Remotas 
                        Set Nro_RCadena = Isnull((Select Nro_RCadena From " & _Global_BaseBk & "Zw_Remotas_En_Cadena_01_Enc Where RCadena_Id_Enc = Id_Enc),'')
                        
                        /*
                        Delete " & _Global_BaseBk & "Zw_Remotas_En_Cadena_01_Enc Where Id_Enc In
                        (Select Id_Enc From " & _Global_BaseBk & "Zw_Remotas_En_Cadena_01_Enc 
                                    Where Estado Not in ('') And Fecha_Hora_Grab < '" & _Fecha & "' And Tido = 'NVV')

                        Delete " & _Global_BaseBk & "Zw_Remotas_En_Cadena_02_Det 
                            Where Id_Enc Not In (Select Id_Enc From " & _Global_BaseBk & "Zw_Remotas_En_Cadena_01_Enc)
                        Delete " & _Global_BaseBk & "Zw_Remotas_En_Cadena_03_Usu 
                            Where Id_Enc Not In (Select Id_Enc From " & _Global_BaseBk & "Zw_Remotas_En_Cadena_01_Enc) 
                                               
                        Delete " & _Global_BaseBk & "Zw_Remotas_En_Cadena_02_Det 
                            Where Id_Enc In (Select Id_Enc From " & _Global_BaseBk & "Zw_Remotas_En_Cadena_01_Enc And Estado <> ''And Tido = 'OCC')
                        Delete " & _Global_BaseBk & "Zw_Remotas_En_Cadena_03_Usu 
                            Where Id_Enc In (Select Id_Enc From " & _Global_BaseBk & "Zw_Remotas_En_Cadena_01_Enc And Estado <> ''And Tido = 'OCC')
                        */"

        _Sql.Ej_consulta_IDU(Consulta_sql)

        Sb_InsertarBotonenGrilla(Grilla, "BtnImagen_Estado", "Est.", "Img_Estado", 0, _Tipo_Boton.Imagen)
        Sb_InsertarBotonenGrilla(Grilla, "BtnImagen_Tag", "Tag", "Img_Tag", 1, _Tipo_Boton.Imagen)

        Sb_Cargar_Sucursales()

        Cmb_Sucursal.SelectedValue = "01Todas"
        Sb_Acualizar_Grilla()

        AddHandler Chk_Mostrar_Nulas.CheckedChanged, AddressOf Sb_Acualizar_Grilla
        AddHandler Cmb_Sucursal.SelectedIndexChanged, AddressOf Cmb_Sucursal_SelectedIndexChanged
        AddHandler Chk_Mostrar_Todas.CheckedChanged, AddressOf Chk_Mostrar_Todas_CheckedChanged

        If _Accion = Enum_Accion.Mis_CRemotas Then

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Notificaciones 
                            Where RCadena_Id_Enc In (Select Id_Enc From " & _Global_BaseBk & "Zw_Remotas_En_Cadena_01_Enc Where Tido = '" & _Tido & "') 
                            And Usuario_Destino = '" & FUNCIONARIO & "'"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            If _Revisar_Notificacion Then
                Timer_Revisar_Notificacion.Start()
            End If
        End If

    End Sub

    Sub Sb_Acualizar_Grilla()

        Try

            Me.Enabled = False

            Me.Text = "Documentos en espera para permisos remotos, Empresa: " & ModEmpresa & " - " & _Global_Row_Modalidad.Item("RAZON").Trim

            Dim _Filtro = String.Empty
            Dim _Filtro_Estado = String.Empty

            Dim _Fecha_Desde = Format(Dtp_Fecha_Emision_Desde.Value, "yyyy-MM-dd")
            Dim _Fecha_Hasta = Format(Dtp_Fecha_Emision_Hasta.Value, "yyyy-MM-dd")

            If Not Chk_Mostrar_Nulas.Checked Then
                _Filtro_Estado = "('','P','r')"
            Else
                _Filtro_Estado = "('','P','N','r')"
            End If

            Dim _Ancho = 0

            If _Accion = Enum_Accion.Mis_CRemotas Then

                Chk_Mostrar_Todas.Checked = True

                _Filtro += "And Usuario_Solicita = '" & FUNCIONARIO & "' And Tido = '" & _Tido & "' And ((Z1.Estado In " & _Filtro_Estado & " Or
                        (Id_Enc In (Select RCadena_Id_Enc From " & _Global_BaseBk & "Zw_Remotas" & Space(1) &
                            "Where Z1.Estado In ('A','R') And 
                          Fecha_Otorga Between Convert(Datetime, '" & _Fecha_Desde & " 00:00:00',102) And Convert(Datetime, '" & _Fecha_Hasta & " 23:59:59',102) ))))"
                _Ancho = 110 + 20

            ElseIf _Accion = Enum_Accion.Revision_CRemotas Then

                _Filtro += "And Tido = '" & _Tido & "' And ((Z1.Estado In " & _Filtro_Estado & " Or 
                        (Id_Enc In (Select RCadena_Id_Enc From " & _Global_BaseBk & "Zw_Remotas" & Space(1) &
                            "Where Z1.Estado In ('A','R') And 
                          Fecha_Otorga Between Convert(Datetime, '" & _Fecha_Desde & " 00:00:00',102) And Convert(Datetime, '" & _Fecha_Hasta & " 23:59:59',102) ))))"

            End If

            Dim _Filtro_Empresa_Sucursal As String

            If Cmb_Sucursal.SelectedValue = "01Todas" Then
                _Filtro_Empresa_Sucursal = "And Empresa = '" & ModEmpresa & "'"
            Else
                _Filtro_Empresa_Sucursal = "And Empresa = '" & ModEmpresa & "' And Sucursal = '" & Cmb_Sucursal.SelectedValue & "'"
            End If

            _Filtro += vbCrLf & _Filtro_Extra


            Consulta_sql = My.Resources.Recursos_Cadena_Remotas.SQLQuery_Informe_Remotas_Pendientes

            Consulta_sql = Replace(Consulta_sql, "#Tido#", _Tido)
            Consulta_sql = Replace(Consulta_sql, "#Ver_Todas#", Convert.ToInt32(Chk_Mostrar_Todas.Checked))
            Consulta_sql = Replace(Consulta_sql, "#CodFuncionario#", FUNCIONARIO)

            Consulta_sql = Replace(Consulta_sql, "#Filtro_Inf_01#", _Filtro)
            Consulta_sql = Replace(Consulta_sql, "#_Global_BaseBk#", _Global_BaseBk)
            Consulta_sql = Replace(Consulta_sql, "#Filtro_Empresa_Sucursal#", _Filtro_Empresa_Sucursal)

            _TblCRemotas_Enc = _Sql.Fx_Get_DataTable(Consulta_sql)

            With Grilla

                .DataSource = _TblCRemotas_Enc

                OcultarEncabezadoGrilla(Grilla, True)

                Dim _DisplayIndex = 0

                .Columns("BtnImagen_Estado").Width = 50
                .Columns("BtnImagen_Estado").HeaderText = "Est."
                .Columns("BtnImagen_Estado").Visible = True
                .Columns("BtnImagen_Estado").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("BtnImagen_Tag").Width = 50
                .Columns("BtnImagen_Tag").HeaderText = "Tag"
                .Columns("BtnImagen_Tag").Visible = True
                .Columns("BtnImagen_Tag").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("Sucursal").Visible = True
                .Columns("Sucursal").HeaderText = "Suc."
                .Columns("Sucursal").Width = 35
                .Columns("Sucursal").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("Nro_RCadena").Visible = True
                .Columns("Nro_RCadena").HeaderText = "Nro CRemota"
                .Columns("Nro_RCadena").Width = 70
                .Columns("Nro_RCadena").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("Usuario_Solicita").Visible = True
                .Columns("Usuario_Solicita").HeaderText = "Sol." '"Cód. Permiso"
                .Columns("Usuario_Solicita").Width = 35 '+ 15 + 10 + 10 + 20 + 10 + 15 + 20 + 10 + 10 + 10
                .Columns("Usuario_Solicita").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("Nombre_Usuario_Solicita").Visible = (_Accion = Enum_Accion.Revision_CRemotas)
                .Columns("Nombre_Usuario_Solicita").HeaderText = "Solicitado por" '"Cód. Permiso"
                .Columns("Nombre_Usuario_Solicita").Width = 130
                .Columns("Nombre_Usuario_Solicita").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("Fecha").Visible = True
                .Columns("Fecha").HeaderText = "Fecha"
                .Columns("Fecha").Width = 65
                .Columns("Fecha").DefaultCellStyle.Format = "dd/MM/yyyy"
                .Columns("Fecha").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("Hora").Visible = True
                .Columns("Hora").HeaderText = "Hora"
                .Columns("Hora").Width = 40
                .Columns("Hora").DefaultCellStyle.Format = "HH:mm"
                .Columns("Hora").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("Estado_Str").Visible = True
                .Columns("Estado_Str").HeaderText = "Estado"
                .Columns("Estado_Str").Width = 65
                .Columns("Estado_Str").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("CodEntidad").Visible = True
                .Columns("CodEntidad").HeaderText = "Entidad"
                .Columns("CodEntidad").Width = 70
                .Columns("CodEntidad").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("CodSucEntidad").Visible = True
                .Columns("CodSucEntidad").HeaderText = "Suc."
                .Columns("CodSucEntidad").Width = 35
                .Columns("CodSucEntidad").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("Nombre_Entidad").Visible = True
                .Columns("Nombre_Entidad").HeaderText = "Razón Social"
                .Columns("Nombre_Entidad").Width = 195 + _Ancho
                .Columns("Nombre_Entidad").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("Tido").Visible = True
                .Columns("Tido").HeaderText = "TD"
                .Columns("Tido").Width = 30
                .Columns("Tido").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Tido").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("Nudo").Visible = True
                .Columns("Nudo").HeaderText = "Número"
                .Columns("Nudo").Width = 70
                .Columns("Nudo").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("Moneda_Doc").Visible = True
                .Columns("Moneda_Doc").HeaderText = "M"
                .Columns("Moneda_Doc").Width = 30
                .Columns("Moneda_Doc").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("Total_Documento").Visible = True
                .Columns("Total_Documento").HeaderText = "Total"
                .Columns("Total_Documento").Width = 80
                .Columns("Total_Documento").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Total_Documento").DefaultCellStyle.Format = "###,##.##"
                .Columns("Total_Documento").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

            End With

            For Each _Fila As DataGridViewRow In Grilla.Rows

                Dim _Estado = _Fila.Cells("Estado").Value
                Dim _Anotaciones = Convert.ToBoolean(_Fila.Cells("Anotaciones").Value)
                Dim _NroDocumento = Trim(_Fila.Cells("NroDocumento").Value)
                Dim _Reserva_NroOCC = _Fila.Cells("Reserva_NroOCC").Value

                Dim _Icono As Image

                Select Case _Estado
                    Case "", "r"
                        _Icono = Imagenes_16x16.Images.Item("clock-import.png")
                        _Fila.DefaultCellStyle.BackColor = Color.LightYellow
                    Case "P"
                        _Icono = Imagenes_16x16.Images.Item("clock-info.png")
                    Case "A"
                        _Icono = Imagenes_16x16.Images.Item("ok.png")
                    Case "N"
                        _Icono = Imagenes_16x16.Images.Item("cancel.png")
                        _Fila.DefaultCellStyle.ForeColor = Color.Gray
                    Case "R"
                        _Icono = Imagenes_16x16.Images.Item("delete_button_error.png")
                    Case Else
                        _Icono = Imagenes_16x16.Images.Item("clock.png")
                End Select


                If _NroDocumento = "X" Then
                    _Icono = Imagenes_16x16.Images.Item("warning.png")
                End If

                _Fila.Cells("BtnImagen_Estado").Value = _Icono

                If _Anotaciones Then
                    _Icono = Imagenes_16x16.Images.Item("note_text.png")
                Else
                    _Icono = Imagenes_16x16.Images.Item("note.png")
                End If

                _Fila.Cells("BtnImagen_Tag").Value = _Icono

                If Global_Thema = Enum_Themas.Oscuro Then

                    _Fila.Cells("Nudo").Style.ForeColor = Color.LightGreen

                    If _Reserva_NroOCC Then
                        _Fila.Cells("Nudo").Style.ForeColor = Color.Gold
                    End If

                Else

                    If _Reserva_NroOCC Then
                        _Fila.Cells("Nudo").Style.BackColor = Color.Yellow
                    End If

                End If

            Next

            If _Sql.Fx_Exite_Campo(_Global_BaseBk & "Zw_Notificaciones", "No_Volver_A_Notificar") Then
                Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Notificaciones 
                            Where Empresa = '" & ModEmpresa & "' And Usuario_Destino = '" & FUNCIONARIO & "' And RCadena_Id_Enc <> 0 And No_Volver_A_Notificar = 0"
            Else
                Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Notificaciones 
                            Where Empresa = '" & ModEmpresa & "' And Usuario_Destino = '" & FUNCIONARIO & "' And RCadena_Id_Enc <> 0"
            End If

            _Sql.Ej_consulta_IDU(Consulta_sql)

            'Esta sentencia repara la tabla [Zw_Remotas_Notif] con notificaciones a usuarios que no esten registrados

            'Insert Into Zw_Remotas_Notif (CodFuncionario_Destino,NroRemota)

            'Select Usuario_Destino,NroRemota
            'From Zw_Remotas_En_Cadena_03_Usu Usua
            'Left Join Zw_Remotas_En_Cadena_02_Det Deta On Deta.Id_Det = Usua.Id_Det
            'Where Usua.Id_Det In (
            'SELECT Id_Det
            'FROM            Zw_Remotas_En_Cadena_02_Det Det
            'Inner Join Zw_Remotas Rem On Det.NroRemota = Rem.NroRemota
            'WHERE Rem.Permiso_Otorgado = 0)
            'And Usua.Usuario_Destino+NroRemota Not In (Select CodFuncionario_Destino+NroRemota From Zw_Remotas_Notif)


        Catch ex As Exception
        Finally
            Me.Enabled = True
        End Try

    End Sub

    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Tiempo_Refresco.Stop()
        Me.Enabled = False

        Try

            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

            Dim _Id_Enc = _Fila.Cells("Id_Enc").Value
            Dim _Id_Enc_Padre = _Fila.Cells("Id_Enc_Padre").Value
            Dim _Estado = Trim(_Fila.Cells("Estado").Value)
            Dim _Idmaeedo = _Fila.Cells("Idmaeedo").Value
            Dim _Usuario_Solicita = _Fila.Cells("Usuario_Solicita").Value

            Dim _Refrescar As Boolean

            Select Case _Estado

                Case "A"

                    Dim _Reg = _Sql.Fx_Cuenta_Registros("MAEDDO", "IDMAEEDO = " & _Idmaeedo)

                    If CBool(_Reg) Then

                        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Notificaciones Where RCadena_Id_Enc = " & _Id_Enc & " And Usuario_Destino = '" & FUNCIONARIO & "'"
                        _Sql.Ej_consulta_IDU(Consulta_sql)

                        Dim Fm_D As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
                        Fm_D.ShowDialog(Me)
                        Fm_D.Dispose()

                    Else
                        MessageBoxEx.Show(Me, "No se encontro el documento")
                    End If

                Case "", "P", "R", "r"

                    Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Remotas_En_Cadena_01_Enc Where Id_Enc = " & _Id_Enc
                    Dim _Row = _Sql.Fx_Get_DataRow(Consulta_sql)

                    Dim _Nro_RCadena = Trim(_Row.Item("Nro_RCadena"))
                    Dim _CodEntidad = Trim(_Row.Item("CodEntidad"))
                    Dim _Nombre_Entidad = Trim(_Row.Item("Nombre_Entidad"))
                    Dim _Tido = Trim(_Row.Item("Tido"))

                    Dim Fm As New Frm_Cadenas_Remotas_Det(_Row)
                    Fm.Text = "Solicitud Nro: " & _Nro_RCadena & ", " & _CodEntidad & " - " & _Nombre_Entidad
                    Fm.Btn_Anular_Solicitud.Visible = (_Accion = Enum_Accion.Mis_CRemotas)
                    Fm.Btn_Eliminar_Y_Reciclar.Visible = (_Accion = Enum_Accion.Mis_CRemotas)
                    Fm.ShowDialog(Me)
                    _Refrescar = Fm.Pro_Actualizar
                    Fm.Dispose()

                Case "E"

                    Dim _Mensaje = String.Empty

                    Dim _Nro_RCadena_Padre = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Remotas_En_Cadena_01_Enc", "Nro_RCadena", "Id_Enc = " & _Id_Enc_Padre)
                    If Not String.IsNullOrEmpty(_Nro_RCadena_Padre) Then _Mensaje = vbCrLf & "Revise la solicitud de envio Nro: " & _Nro_RCadena_Padre

                    MessageBoxEx.Show(Me, "Esta solicitud fue reemplazada" & vbCrLf & _Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                Case "N"

                    MessageBoxEx.Show(Me, "Solicitud anulada", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            End Select

            Sb_Acualizar_Grilla()

        Catch ex As Exception

        Finally
            Me.Enabled = True
            Tiempo_Refresco.Start()
        End Try

    End Sub

    Private Sub Btn_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Refresh.Click
        Sb_Acualizar_Grilla()
    End Sub

    Private Sub Btn_Admin_Permisos_Usuarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Admin_Permisos_Usuarios.Click
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

    Private Sub Frm_Cadenas_Remotas_Lista_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Timer_Revisar_Notificacion_Tick(sender As Object, e As EventArgs) Handles Timer_Revisar_Notificacion.Tick

        Tiempo_Refresco.Stop()
        Timer_Revisar_Notificacion.Stop()

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Remotas_En_Cadena_01_Enc Where Id_Enc = " & _Id_Enc_Revisar
        Dim _Row = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Nro_RCadena = Trim(_Row.Item("Nro_RCadena"))
        Dim _CodEntidad = Trim(_Row.Item("CodEntidad"))
        Dim _Nombre_Entidad = Trim(_Row.Item("Nombre_Entidad"))

        Dim Fm As New Frm_Cadenas_Remotas_Det(_Row)
        Fm.Text = "Solicitud Nro: " & _Nro_RCadena & ", " & _CodEntidad & " - " & _Nombre_Entidad
        Fm.Btn_Anular_Solicitud.Visible = (_Accion = Enum_Accion.Mis_CRemotas)
        Fm.Btn_Eliminar_Y_Reciclar.Visible = (_Accion = Enum_Accion.Mis_CRemotas)
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Sb_Acualizar_Grilla()
        Tiempo_Refresco.Start()

    End Sub

    Private Sub Dtp_Fecha_Emision_Desde_ValueChanged(sender As Object, e As EventArgs) Handles Dtp_Fecha_Emision_Desde.ValueChanged

        Dim _Fecha_Desde As Date = FormatDateTime(Dtp_Fecha_Emision_Desde.Value, DateFormat.ShortDate)
        Dim _Fecha_Hasta As Date = FormatDateTime(Dtp_Fecha_Emision_Hasta.Value, DateFormat.ShortDate)

        If _Fecha_Desde > _Fecha_Hasta Then
            MessageBoxEx.Show(Me, "La fecha desde no puede ser mayor a la fecha hasta", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Dtp_Fecha_Emision_Desde.Value = _Fecha_Desde
        Else
            _Fecha_Desde = Dtp_Fecha_Emision_Desde.Value
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

            RemoveHandler Cmb_Sucursal.SelectedIndexChanged, AddressOf Cmb_Sucursal_SelectedIndexChanged
            Sb_Cargar_Sucursales()
            Cmb_Sucursal.SelectedValue = "01Todas" 'ModSucursal
            Sb_Acualizar_Grilla()
            AddHandler Cmb_Sucursal.SelectedIndexChanged, AddressOf Cmb_Sucursal_SelectedIndexChanged

        End If

    End Sub

    Private Sub Frm_Cadenas_Remotas_Lista_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

        If Modalidad <> _Modalidad_Origen Then

            Dim _Mod As New Clas_Modalidades

            _Mod.Sb_Actualiza_Formatos_X_Modalidad()
            _Mod.Sb_Actualizar_Variables_Modalidad(_Modalidad_Origen)

        End If

    End Sub

    Sub Sb_Cargar_Sucursales()

        caract_combo(Cmb_Sucursal)
        Consulta_sql = "SELECT '01Todas' AS Padre,'Todas las sucursales' AS Hijo " & vbCrLf & "Union" & vbCrLf &
                       "SELECT KOSU AS Padre,KOSU+'-'+NOKOSU AS Hijo FROM TABSU WHERE EMPRESA = '" & ModEmpresa & "'"
        Cmb_Sucursal.DataSource = _Sql.Fx_Get_DataTable(Consulta_sql)
        Cmb_Sucursal.SelectedValue = ModSucursal

    End Sub

    Private Sub Cmb_Sucursal_SelectedIndexChanged(sender As Object, e As EventArgs)

        Sb_Acualizar_Grilla()

    End Sub

    Private Sub Chk_Mostrar_Todas_CheckedChanged(sender As Object, e As EventArgs)

        If Chk_Mostrar_Todas.Checked Then
            If Fx_Tiene_Permiso(Me, "Comp0094") Then
                Cmb_Sucursal.SelectedValue = "01Todas"
            Else
                Chk_Mostrar_Todas.Checked = False
                Return
            End If
        End If

        Sb_Acualizar_Grilla()

    End Sub

End Class
