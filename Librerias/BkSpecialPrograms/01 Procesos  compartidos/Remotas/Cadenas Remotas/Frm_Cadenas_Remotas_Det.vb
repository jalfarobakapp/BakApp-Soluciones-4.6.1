Imports DevComponents.DotNetBar

Public Class Frm_Cadenas_Remotas_Det

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _TblCRemotas_Det As DataTable
    Dim _RowRemotas_En_Cadena_01_Enc As DataRow
    Dim _Estado As String

    Dim _Actualizar As Boolean

    Public ReadOnly Property Pro_Actualizar() As Boolean
        Get
            Return _Actualizar
        End Get
    End Property
    Public ReadOnly Property Pro_RowRemotas_En_Cadena_01_Enc() As DataRow
        Get
            Return _RowRemotas_En_Cadena_01_Enc
        End Get
    End Property

    Public Sub New(ByVal RowRemotas_En_Cadena_01_Enc As DataRow)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        _RowRemotas_En_Cadena_01_Enc = RowRemotas_En_Cadena_01_Enc
        _Estado = _RowRemotas_En_Cadena_01_Enc.Item("Estado")

        If _Estado = "A" Then
            Btn_Anular_Solicitud.Enabled = False
        End If

        If Global_Thema = Enum_Themas.Oscuro Then
            Btn_Refresh.ForeColor = Color.White
        End If

    End Sub

    Private Sub Frm_Cadenas_Remotas_Det_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sb_InsertarBotonenGrilla(Grilla, "BtnImagen", "Est.", "Img_Estado", 0, _Tipo_Boton.Imagen)
        Sb_Acualizar_Grilla()

        AddHandler Grilla.CellEnter, AddressOf Sb_Grilla_CellEnter

        Grilla.ScrollBars = ScrollBars.Horizontal

    End Sub

    Sub Sb_Acualizar_Grilla()

        Dim _Id_Enc = _RowRemotas_En_Cadena_01_Enc.Item("Id_Enc")
        Dim _Filtro = "And Z1.Id_Enc = " & _Id_Enc

        Consulta_sql = My.Resources.Recursos_Cadena_Remotas.SQLQuery_Informe_Remotas_Pendientes_Detalle
        Consulta_sql = Replace(Consulta_sql, "#_Global_BaseBk#", _Global_BaseBk)
        Consulta_sql = Replace(Consulta_sql, "#Filtro_Inf_01#", _Filtro)

        _TblCRemotas_Det = _Sql.Fx_Get_DataTable(Consulta_sql)

        With Grilla

            .DataSource = _TblCRemotas_Det

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            .Columns("BtnImagen").Width = 50
            .Columns("BtnImagen").HeaderText = "Est."
            .Columns("BtnImagen").Visible = True
            .Columns("BtnImagen").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NroRemota").Visible = True
            .Columns("NroRemota").HeaderText = "Nro Remota"
            .Columns("NroRemota").Width = 70
            .Columns("NroRemota").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CodPermiso").Visible = True
            .Columns("CodPermiso").HeaderText = "Permiso"
            .Columns("CodPermiso").Width = 70
            .Columns("CodPermiso").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").HeaderText = "Descripción" '"Cód. Permiso"
            .Columns("Descripcion").Width = 440
            .Columns("Descripcion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Estado").Visible = True
            .Columns("Estado").HeaderText = "Estado"
            .Columns("Estado").Width = 290
            .Columns("Estado").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Fecha_Otorga").Visible = True
            .Columns("Fecha_Otorga").HeaderText = "Fecha/Hora"
            .Columns("Fecha_Otorga").DefaultCellStyle.Format = "yyyy/MM/dd, hh:mm"
            .Columns("Fecha_Otorga").Width = 290
            .Columns("Fecha_Otorga").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        For Each _Fila As DataGridViewRow In Grilla.Rows

            Dim _NroRemota = _Fila.Cells("NroRemota").Value
            Dim _CodFuncionario_Autoriza = _Fila.Cells("CodFuncionario_Autoriza").Value
            Dim _CodFuncionario_Revisa = _Fila.Cells("Revisando").Value
            Dim _Otorga = _Fila.Cells("Otorga").Value
            Dim _Revisando = Trim(_Fila.Cells("Revisando").Value)
            Dim _Id_Det = _Fila.Cells("Id_Det").Value
            Dim _Fun_Solicitados As String

            Consulta_sql = "Select *,(Select NOKOFU From TABFU Where KOFU = Usuario_Destino) As Usuario" & vbCrLf &
                           "From " & _Global_BaseBk & "Zw_Remotas_En_Cadena_03_Usu" & vbCrLf &
                           "Where Id_Det = " & _Id_Det
            Dim _TblUsuarios As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)
            _Fun_Solicitados = String.Empty
            Dim _C = 1

            For Each _Fl As DataRow In _TblUsuarios.Rows
                _Fun_Solicitados += Trim(_Fl.Item("Usuario"))
                If _C <> _TblUsuarios.Rows.Count Then
                    _Fun_Solicitados += ", "
                End If
                _C += 1
            Next

            _Fila.Cells("Fun_Solicitados").Value = _Fun_Solicitados


            Dim _Estado = _Fila.Cells("Estado").Value

            Dim _Icono As Image

            Select Case _Otorga

                Case "Autorizado"

                    _Icono = Imagenes_16x16.Images.Item("ok.png")

                Case "Rechazado"

                    _Icono = Imagenes_16x16.Images.Item("delete_button_error.png")
                    Sb_TxtObservacion(_Fila)

                Case "Enviado"

                    If Not String.IsNullOrEmpty(_Revisando) Then

                        _Icono = Imagenes_16x16.Images.Item("clock-user.png")

                    Else

                        If _Estado = "R" Then

                            _Icono = Imagenes_16x16.Images.Item("clock_d.png")

                            If Global_Thema = Enum_Themas.Oscuro Then

                                _Fila.DefaultCellStyle.ForeColor = Color.Gray

                            Else

                                _Fila.DefaultCellStyle.BackColor = Color.Gray

                            End If

                        Else

                            _Icono = Imagenes_16x16.Images.Item("clock.png")

                            If Global_Thema = Enum_Themas.Oscuro Then

                                _Fila.DefaultCellStyle.ForeColor = Color.Yellow

                            Else

                                _Fila.DefaultCellStyle.BackColor = Color.Yellow

                            End If

                        End If

                    End If

                    Sb_TxtObservacion(_Fila)

                Case "Pendiente..."

                    _Icono = Imagenes_16x16.Images.Item("clock_d.png")
                    _Fila.DefaultCellStyle.ForeColor = Color.Gray 'LightYellow

                Case Else

                    _Icono = Imagenes_16x16.Images.Item("warning.png")

            End Select

            _Fila.Cells("BtnImagen").Value = _Icono

        Next

        Me.Refresh()

    End Sub

    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Otorga = _Fila.Cells("Otorga").Value

        Dim _CodFuncionario_Solicita = _Fila.Cells("CodFuncionario_Solicita").Value
        Dim _CodFuncionario_Autoriza = _Fila.Cells("CodFuncionario_Autoriza").Value
        Dim _Id_DocEnc = _Fila.Cells("New_Id_DocEnc").Value
        Dim _Fecha_Otorga As DateTime = NuloPorNro(_Fila.Cells("Fecha_Otorga").Value, Now.Date)

        Dim Fh = _Fecha_Otorga.ToString("F", Globalization.CultureInfo.CreateSpecificCulture("es-CL"))

        Dim _Nombre_CodFuncionario_Autoriza = _Sql.Fx_Trae_Dato("TABFU", "NOKOFU", "KOFU = '" & _CodFuncionario_Autoriza & "'")

        Dim _NroRemota = _Fila.Cells("NroRemota").Value
        Consulta_sql = "SELECT TOP 1 * From " & _Global_BaseBk & "Zw_Remotas" & vbCrLf &
                       "Where NroRemota = '" & _NroRemota & "'"
        Dim _Row_Remota As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _CodPermiso = _Fila.Cells("CodPermiso").Value
        Dim _Descripcion = _Fila.Cells("Descripcion").Value
        Dim _Observaciones = _Fila.Cells("Observaciones").Value
        Dim _Monto_Aprobacion = _Fila.Cells("Monto_Aprobacion").Value

        Dim _Tido = _Fila.Cells("Tido").Value
        Dim _Tipo_Documento As csGlobales.Enum_Tipo_Documento

        If _Tido = "NVV" Then
            _Tipo_Documento = csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Venta
        ElseIf _Tido = "OCC" Then
            _Tipo_Documento = csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Compra
        End If

        If _Otorga = "Autorizado" Then

            MessageBoxEx.Show(Me, "El permiso fue autorizado por: " & _Nombre_CodFuncionario_Autoriza & vbCrLf &
                              "Fecha : " & Fh, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information,
                              MessageBoxDefaultButton.Button1, Me.TopMost)

        ElseIf _Otorga = "Rechazado" Then

            If _CodFuncionario_Solicita = FUNCIONARIO Then

                ShowContextMenu(Menu_Contextual_01)

                Return

            Else
                MessageBoxEx.Show(Me, "Usuario: " & _Nombre_CodFuncionario_Autoriza & vbCrLf & vbCrLf & _Observaciones,
                                      "Rechazado", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, Me.TopMost)
            End If

        ElseIf _Otorga = "Enviado" Then

            If Not String.IsNullOrEmpty(_NroRemota) Then

                If Fx_Tiene_Permiso(Me, _CodPermiso, FUNCIONARIO, , False,,,, False) Then

                    Dim _Id_Casi_DocEnc = _Row_Remota.Item("Id_Casi_DocEnc")

                    Consulta_sql = "Select *,(Select Top 1 NOKOFU From TABFU Where KOFU = CodFuncionario) As Funcionario" & vbCrLf &
                           "From " & _Global_BaseBk & "Zw_Casi_DocTom Where Id_DocEnc = " & _Id_Casi_DocEnc
                    Dim _Row_Zw_Casi_DocTom As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                    If (_Row_Zw_Casi_DocTom Is Nothing) Then

                        'Me.WindowState = FormWindowState.Minimized

                        Dim Fm_Remotas As New Frm_Remotas_Lista_Permisos_Solicitados(FUNCIONARIO, CBool(_Id_Casi_DocEnc))
                        Fm_Remotas.Pro_NroRemota_Marcar = _NroRemota
                        Fm_Remotas.Grilla.Enabled = False
                        Fm_Remotas.ShowDialog(Me)
                        Fm_Remotas.Dispose()

                        'Me.WindowState = FormWindowState.Normal

                        Dim _Reg = Convert.ToBoolean(_Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Casi_DocEnc", "Id_DocEnc = " & _Id_Casi_DocEnc))

                        If Not _Reg Then
                            Me.Close()
                        End If

                    Else

                        Dim _Funcionario = _Row_Zw_Casi_DocTom.Item("Funcionario")
                        MessageBoxEx.Show(Me, "El documento se encuentra tomado por: " & _Funcionario,
                                  "El permisos esta siendo atentido", MessageBoxButtons.OK, MessageBoxIcon.Information,
                                  MessageBoxDefaultButton.Button1, Me.TopMost)

                    End If

                End If

            End If

        Else

            MessageBoxEx.Show(Me, "Permiso en estado pendiente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

        Sb_Acualizar_Grilla()

    End Sub

    Private Sub Btn_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Refresh.Click
        Sb_Acualizar_Grilla()
    End Sub

    Private Sub Sb_Grilla_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Sb_TxtObservacion(_Fila)
    End Sub

    Sub Sb_TxtObservacion(ByVal _Fila As DataGridViewRow)

        Dim _Observaciones = _Fila.Cells("Observaciones").Value
        Dim _Otorga = _Fila.Cells("Otorga").Value
        Dim _Fun_Solicitados = _Fila.Cells("Fun_Solicitados").Value

        Lbl_Observaciones.Text = String.Empty

        If _Otorga = "Rechazado" Then
            If Not String.IsNullOrEmpty(_Observaciones) Then
                Lbl_Observaciones.Text = "MOTIVO: " & _Observaciones
            End If
        Else
            If _Otorga = "Pendiente..." Then
                Lbl_Observaciones.Text = "Esta solicitud se enviara a: " & _Fun_Solicitados
            Else
                Lbl_Observaciones.Text = "Permisos solicitados a: " & _Fun_Solicitados
            End If
        End If

    End Sub

    Private Sub Btn_Anular_Solicitud_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Anular_Solicitud.Click

        Dim _Id_Enc = _RowRemotas_En_Cadena_01_Enc.Item("Id_Enc")
        Dim _Id_DocEnc = _RowRemotas_En_Cadena_01_Enc.Item("Id_DocEnc")

        Dim _Tomado As Boolean

        Dim _CodFuncionario_Tom = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Casi_DocTom", "CodFuncionario", " Id_DocEnc = " & _Id_DocEnc)

        If String.IsNullOrEmpty(_CodFuncionario_Tom) Then

            Dim _Mensaje = MessageBoxEx.Show(Me, "Al anular la solicitud se perderá el documento de referencia" & vbCrLf & vbCrLf &
                                                     "¿Está seguro de anular toda la solicitud?", "Anular solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If _Mensaje = Windows.Forms.DialogResult.Yes Then

                Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Casi_DocTom Z3" & vbCrLf &
                               "Where NroRemota In (Select NroRemota From " & _Global_BaseBk & "Zw_Remotas_En_Cadena_02_Det Where Id_Enc = " & _Id_Enc & ")"
                Dim _Row = _Sql.Fx_Get_DataRow(Consulta_sql)

                If (_Row Is Nothing) Then

                    Dim _Tido As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Casi_DocEnc", "TipoDoc", "Id_DocEnc = " & _Id_DocEnc)

                    Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Casi_DocDet Where Id_DocEnc = " & _Id_DocEnc
                    Dim _TblDetalle As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

                    Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Casi_DocEnc Where Id_DocEnc = " & _Id_DocEnc & vbCrLf &
                                   "Delete " & _Global_BaseBk & "Zw_Casi_DocDet Where Id_DocEnc = " & _Id_DocEnc & vbCrLf &
                                   "Delete " & _Global_BaseBk & "Zw_Casi_DocDsc Where Id_DocEnc = " & _Id_DocEnc & vbCrLf &
                                   "Delete " & _Global_BaseBk & "Zw_Casi_DocImp Where Id_DocEnc = " & _Id_DocEnc & vbCrLf &
                                   "Delete " & _Global_BaseBk & "Zw_Casi_DocTom Where Id_DocEnc = " & _Id_DocEnc & vbCrLf &
                                   "Delete " & _Global_BaseBk & "Zw_Casi_DocPer WHERE Id_DocEnc = " & _Id_DocEnc & vbCrLf &
                                   "Delete " & _Global_BaseBk & "Zw_Referencias_Dte Where Id_Doc = " & _Id_DocEnc & vbCrLf &
                                   vbCrLf &
                                   "Update " & _Global_BaseBk & "Zw_Remotas_En_Cadena_01_Enc Set Estado = 'N' Where Id_Enc = " & _Id_Enc & vbCrLf &
                                   "Delete " & _Global_BaseBk & "Zw_Remotas_En_Cadena_02_Det Where Id_Enc = " & _Id_Enc & vbCrLf & vbCrLf &
                                   "Delete " & _Global_BaseBk & "Zw_Remotas_En_Cadena_03_Usu Where Id_Enc = " & _Id_Enc & vbCrLf &
                                   "Delete " & _Global_BaseBk & "Zw_Notificaciones Where RCadena_Id_Enc = " & _Id_Enc & vbCrLf &
                                   "Update " & _Global_BaseBk & "Zw_Remotas Set Eliminada = 1 Where  RCadena_Id_Enc = " & _Id_Enc

                    If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then

                        If _Estado <> "R" Then
                            Sb_Reestablecer_Stock_En_Zw_Prod_Stock(_Tido, _TblDetalle)
                        End If

                        MessageBoxEx.Show(Me, "Solicitud completamente anulada", "Anular solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        _Actualizar = True
                        Me.Close()
                    End If

                Else

                    _Tomado = True
                    _CodFuncionario_Tom = _Row.Item("CodFuncionario")

                End If

            End If

        Else
            _Tomado = True
        End If

        If _Tomado Then
            Dim _Revisa = _Sql.Fx_Trae_Dato("TABFU", "NOKOFU", "KOFU = '" & _CodFuncionario_Tom & "'")
            MessageBoxEx.Show(Me, "No se puede anular el documento, está siendo revisado por: " & Trim(_Revisa), "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

        Sb_Acualizar_Grilla()

    End Sub

    Private Sub Btn_Eliminar_Y_Reciclar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Eliminar_Y_Reciclar.Click

        Dim _Id_Enc = _RowRemotas_En_Cadena_01_Enc.Item("Id_Enc")
        Dim _Id_DocEnc = _RowRemotas_En_Cadena_01_Enc.Item("Id_DocEnc")


        Dim _CodFuncionario_Tom = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Casi_DocTom", "CodFuncionario", " Id_DocEnc = " & _Id_DocEnc)

        If String.IsNullOrEmpty(_CodFuncionario_Tom) Then

            Dim _Mensaje = MessageBoxEx.Show(Me, "Al eliminar y reciclar la solicitud NO se perderá el documento de referencia." & vbCrLf &
                                             "Este podrá ser rescatado desde los documentos en Stand-By" & vbCrLf & vbCrLf &
                                             "¿Está seguro de eliminar la solicitud?", "Eliminar y reciclar solicitud",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, Me.TopMost)

            If _Mensaje = Windows.Forms.DialogResult.Yes Then

                Dim _Tido As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Casi_DocEnc", "TipoDoc", "Id_DocEnc = " & _Id_DocEnc)

                Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Casi_DocDet Where Id_DocEnc = " & _Id_DocEnc
                Dim _TblDetalle As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Casi_DocEnc Set" & Space(1) &
                               "Stand_by = 1,Fun_Auto_Deuda_Ven = '',Fun_Auto_Stock_Ins = '',Fun_Auto_Cupo_Exe = '',Vizado = 0," & Space(1) &
                               "Fun_Auto_Fecha_Des = '',Fun_Auto_Sol_Compra = ''" & Environment.NewLine &
                               "Where Id_DocEnc =" & _Id_DocEnc & Environment.NewLine &
                               "Update " & _Global_BaseBk & "Zw_Casi_DocDet Set CodFunAutoriza = 'xyz' Where Id_DocEnc =" & _Id_DocEnc & Environment.NewLine &
                               "Delete " & _Global_BaseBk & "Zw_Remotas_En_Cadena_01_Enc Where Id_Enc = " & _Id_Enc & Environment.NewLine &
                               "Delete " & _Global_BaseBk & "Zw_Remotas_En_Cadena_02_Det Where Id_Enc = " & _Id_Enc & Environment.NewLine & Environment.NewLine &
                               "Delete " & _Global_BaseBk & "Zw_Remotas_En_Cadena_03_Usu Where Id_Enc = " & _Id_Enc & Environment.NewLine &
                               "Delete " & _Global_BaseBk & "Zw_Notificaciones Where RCadena_Id_Enc = " & _Id_Enc & Environment.NewLine &
                               "Delete " & _Global_BaseBk & "Zw_Remotas Where RCadena_Id_Enc = " & _Id_Enc

                If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then

                    If _Estado <> "R" Then
                        Sb_Reestablecer_Stock_En_Zw_Prod_Stock(_Tido, _TblDetalle)
                    End If

                    Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Remotas_Notif Where NroRemota Not In (Select NroRemota From " & _Global_BaseBk & "Zw_Remotas)"
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                    MessageBoxEx.Show(Me, "La Solicitud ha sido eliminada, pero el documento podrá ser rescatado nuevamente" & vbCrLf &
                                  "desde el formulario de generación de notas de venta en la opción Stand-By",
                                  "Documento Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, Me.TopMost)
                    _Actualizar = True
                    Me.Close()

                End If

            End If

        Else

            Dim _Revisa = _Sql.Fx_Trae_Dato("TABFU", "NOKOFU", "KOFU = '" & _CodFuncionario_Tom & "'")
            MessageBoxEx.Show(Me, "El documento está siendo revisado por: " & Trim(_Revisa), "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

        Sb_Acualizar_Grilla()

    End Sub

    Private Sub Frm_Cadenas_Remotas_Det_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Sb_Llenar_Funcionarios_Destino(ByVal _Codpermiso As String,
                                               ByRef _Tbl_Usuarios As DataTable)

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "ZW_Permisos" & vbCrLf &
                       "Where CodPermiso = '" & _Codpermiso & "'"
        Dim _RowPermiso As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Descripcion = _RowPermiso.Item("DescripcionPermiso")

        Dim _Condicion_Compras As String

        If _Codpermiso = "Comp0092" Then

            Dim _Jefes As New List(Of String)

            Fx_Insertar_Jefe_Y_SubJefes(FUNCIONARIO, _Jefes)

            _Condicion_Compras = Generar_Filtro_IN_Arreglo(_Jefes, False)

            If CBool(_Jefes.Count) Then
                _Condicion_Compras = "And CodUsuario In " & _Condicion_Compras
            Else
                MessageBoxEx.Show(Me, "No existen usuarios con el permiso necesario." & vbCrLf &
                  "Informe esta situación a la administración por favor.",
                  "No tiene jefes asignados", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

        End If

        Consulta_sql = "Select CodUsuario From " & _Global_BaseBk & "ZW_PermisosVsUsuarios" & vbCrLf &
                       "Where CodPermiso = '" & _Codpermiso & "'" & vbCrLf & _Condicion_Compras

        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim _Filtro_Usuarios_NOT_In As String

        If CBool(_Tbl.Rows.Count) Then
            _Filtro_Usuarios_NOT_In = "And KOFU In " & Generar_Filtro_IN(_Tbl, "", "CodUsuario", False, False, "'")
        Else
            MessageBoxEx.Show(Me, "No existen usuarios con el permiso necesario." & vbCrLf &
                              "Informe esta situación a la administración por favor.",
                              "Faltan usuarios con el permiso [" & _Codpermiso & "]", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim Fm_R As New Frm_Filtro_Especial_Informes(Frm_Filtro_Especial_Informes._Tabla_Fl._Funcionarios_Random)
        Fm_R.Pro_Sql_Filtro_Condicion_Extra = "And INACTIVO = 0" & vbCrLf & _Filtro_Usuarios_NOT_In
        Fm_R.Text = "SOLICITUD DE PERMISO: " & _Codpermiso & " - " & _Descripcion
        Fm_R.Pro_Tbl_Filtro = _Tbl_Usuarios
        Fm_R.ShowDialog(Me)

        If Fm_R.Pro_Filtrar Then
            _Tbl_Usuarios = Fm_R.Pro_Tbl_Filtro
        End If

        Fm_R.Dispose()

    End Sub

    Private Sub Btn_Ver_Documento_Click(sender As Object, e As EventArgs) Handles Btn_Ver_Documento.Click

        Dim _Id_DocEnc = _RowRemotas_En_Cadena_01_Enc.Item("Id_DocEnc")
        Dim _TipoDoc = _RowRemotas_En_Cadena_01_Enc.Item("Tido")
        Dim _Tipo_Documento As csGlobales.Enum_Tipo_Documento

        If _TipoDoc = "NVV" Then
            _Tipo_Documento = csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Venta
        ElseIf _TipoDoc = "OCC" Then
            _Tipo_Documento = csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Compra
        End If

        Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & " Zw_Casi_DocDet", "Id_DocEnc = " & _Id_DocEnc)

        If Convert.ToBoolean(_Reg) Then

            Dim Fm As New Frm_Ver_Documento(_Id_DocEnc, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Bakapp_Kasi)
            Fm.ShowDialog(Me)
            Fm.Dispose()

            Sb_Acualizar_Grilla()

        Else

            MessageBoxEx.Show(Me, "No se encontro el documento de refencia", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop,
                              MessageBoxDefaultButton.Button1, Me.TopMost)

        End If

    End Sub

    Private Sub Btn_Mnu_Reenviar_Evaluacion_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_Reenviar_Evaluacion.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Id_Enc = _Fila.Cells("Id_Enc").Value
        Dim _Id_Det = _Fila.Cells("Id_Det").Value
        Dim _Old_NroRemota = _Fila.Cells("NroRemota").Value
        Dim _CodFuncionario_Solicita = _Fila.Cells("CodFuncionario_Solicita").Value
        Dim _Nombre_Usuario_Solicita = _Fila.Cells("Nombre_Usuario_Solicita").Value
        Dim _Tido = _Fila.Cells("Tido").Value
        Dim _CodPermiso = _Fila.Cells("CodPermiso").Value

        Dim _CodEntidad = _Fila.Cells("CodEntidad").Value
        Dim _Nombre_Entidad = _Fila.Cells("Nombre_Entidad").Value
        Dim _Descripcion_Permiso = _Fila.Cells("Descripcion").Value

        Dim _New_NroRemota As String

        Dim _Tbl_Usuarios As DataTable

        Sb_Llenar_Funcionarios_Destino(_CodPermiso, _Tbl_Usuarios)
        Dim _Sql_Usuario = String.Empty

        If Not IsNothing(_Tbl_Usuarios) Then

            For Each _FUs As DataRow In _Tbl_Usuarios.Rows

                Dim _Usuario_Destino = _FUs.Item("Codigo")

                _Sql_Usuario += "Insert Into " & _Global_BaseBk & "Zw_Remotas_En_Cadena_03_Usu (Id_Enc,Id_Det,Usuario_Destino) Values 
                                (@Id_Enc,@Id_Det,'" & _Usuario_Destino & "')" & Environment.NewLine

            Next

            _New_NroRemota = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Remotas", "MAX(NroRemota)")

            If String.IsNullOrEmpty(Trim(_New_NroRemota)) Then
                _New_NroRemota = 1
            Else
                _New_NroRemota = Math.Round(Val(Mid(_New_NroRemota, 2, 10)) + 1, 0)
            End If

            _New_NroRemota = "R" & numero_(Val(_New_NroRemota), 9)

            Consulta_sql = My.Resources.Recursos_Cadena_Remotas.SQLQuery_Reenviar_Solicitud_De_Permiso
            Consulta_sql = Replace(Consulta_sql, "#New_NroRemota#", _New_NroRemota)
            Consulta_sql = Replace(Consulta_sql, "#Old_NroRemota#", _Old_NroRemota)
            Consulta_sql = Replace(Consulta_sql, "#Id_Enc#", _Id_Enc)
            Consulta_sql = Replace(Consulta_sql, "#Id_Det#", _Id_Det)
            Consulta_sql = Replace(Consulta_sql, "#_Global_BaseBk#", _Global_BaseBk)
            Consulta_sql += Environment.NewLine & _Sql_Usuario

            If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then

                Consulta_sql = "SELECT * FROM " & _Global_BaseBk & "Zw_Remotas_En_Cadena_03_Usu WHERE Id_Det = " & _Id_Det
                Dim _Tbl_Usu As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

                For Each _Fila_Usu As DataRow In _Tbl_Usu.Rows

                    Dim _Usuario_Destino = _Fila_Usu.Item("Usuario_Destino")

                    Dim _Entidad_txt As String

                    If _Tido = "NVV" Then
                        _Entidad_txt = "Cliente: "
                    ElseIf _Tido = "OCC" Then
                        _Entidad_txt = "Proveedor: "
                    End If

                    Dim _Texto = "Solicitado por: " & _CodFuncionario_Solicita & " - " & Mid(Trim(_Nombre_Usuario_Solicita), 1, 13) & Environment.NewLine &
                             "Nro Remota:" & _New_NroRemota & Environment.NewLine &
                             _Descripcion_Permiso & Environment.NewLine &
                             _CodEntidad & " " & Trim(_Nombre_Entidad)

                    Dim _Titulo = "REENVIO DE SOLICITUD..."

                    csNotificaciones.Notificacion.Fx_Insertar_Notificacion(_CodFuncionario_Solicita,
                                                                           _Usuario_Destino,
                                                                           _Titulo,
                                                                           _Texto,
                                                                           csNotificaciones.Notificacion.Imagen.Remota,
                                                                           _New_NroRemota, False, 0, True, _Id_Enc, False, "", "", "")

                Next

                Sb_Acualizar_Grilla()

                MessageBoxEx.Show(Me, "El documento fue reenviado con exito", "Reenviar documento a evaluación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, Me.TopMost)
                Me.Close()

            End If

        End If

    End Sub

    Private Sub Btn_Revisar_Documento_Click(sender As Object, e As EventArgs) Handles Btn_Revisar_Documento.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Id_DocEnc = _Fila.Cells("New_Id_DocEnc").Value
        Dim _Id_Enc = _Fila.Cells("Id_Enc").Value
        Dim _Id_Det = _Fila.Cells("Id_Det").Value

        Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Casi_DocEnc", "Id_DocEnc = " & _Id_DocEnc)

        Dim _NroRemota = _Fila.Cells("NroRemota").Value
        Consulta_sql = "SELECT TOP 1 * From " & _Global_BaseBk & "Zw_Remotas" & vbCrLf &
                       "Where NroRemota = '" & _NroRemota & "'"
        Dim _Row_Remota As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Tido = _Fila.Cells("Tido").Value
        Dim _Tipo_Documento As csGlobales.Enum_Tipo_Documento

        If _Tido = "NVV" Then
            _Tipo_Documento = csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Venta
        ElseIf _Tido = "OCC" Then
            _Tipo_Documento = csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Compra
        End If

        If CBool(_Reg) Then

            Dim Fm_Post As New Frm_Formulario_Documento(_Tido, _Tipo_Documento, False)
            Fm_Post.Pro_RowRemota_Notificacion = _Row_Remota
            Fm_Post.ShowDialog(Me)
            _Actualizar = Fm_Post.Pro_Grabar
            Fm_Post.Dispose()

            If _Actualizar Then
                Me.Close()
            End If

        Else

            MessageBoxEx.Show(Me, "No se encontro el documento de refencia", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop,
                              MessageBoxDefaultButton.Button1, Me.TopMost)

        End If

    End Sub

End Class
