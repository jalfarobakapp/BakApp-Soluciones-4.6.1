'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_Sol_Pro_Bodega_ListaPendientes

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String


    Dim _Condicion As String
    Dim _SoloCierra As Boolean

    Dim _TblProductosSol As DataTable

    Public Property Pro_Condicion As String
        Get
            Return _Condicion
        End Get
        Set(value As String)
            _Condicion = value
        End Set
    End Property

    Public Property Pro_SoloCierra As Boolean
        Get
            Return _SoloCierra
        End Get
        Set(value As Boolean)
            _SoloCierra = value
        End Set
    End Property

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(Grilla, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    'Private Sub BtnxSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnxSalir.Click
    '    _SoloCierra = True
    '    Me.Close()
    'End Sub

    Private Sub Frm_Sol_Pro_Bodega_ListaPendientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        DtpFecharevision.Value = FechaDelServidor()
        Sb_Actualizar_Grilla(_Condicion)

        AddHandler Chk_Validar_Usuario_Con_Huella.CheckedChanged, AddressOf Sb_Chk_Validar_Usuario_Con_Huella_CheckedChanged
        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Me.ActiveControl = TxtCodigoSol

    End Sub

    Private Sub TxtCodigoSol_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigoSol.KeyDown

        Radio1.Checked = True
        Radio2.Checked = False

        If e.KeyValue = Keys.Enter Then

            Dim _CodSolicitud = Fx_Rellena_ceros(TxtCodigoSol.Text, 10)

            Sb_Revisar_Vale(_CodSolicitud)
            TxtCodigoSol.Text = String.Empty
            TxtCodigoSol.Focus()

        End If

    End Sub

    Private Function GetRadioButtons() As Command()
        Return New Command() {Radio1, Radio2}
    End Function

    Sub Sb_Actualizar_Grilla(Optional ByVal _Condicion As String = "")

        Dim _Fecha = Format(DtpFecharevision.Value, "yyyyMMdd")

        Dim Dia_1 As String = numero_(DtpFecharevision.Value.Day, 2)
        Dim Mes_1 As String = numero_(DtpFecharevision.Value.Month, 2)
        Dim Ano_1 As String = DtpFecharevision.Value.Year

        Dim _Filtro_Fecha =
                      "Or (FechaHora_Solicita BETWEEN CONVERT(DATETIME, '" & Ano_1 & "-" & Mes_1 & "-" & Dia_1 & " 00:00:00', 102)" & vbCrLf &
                      "AND CONVERT(DATETIME, '" & Ano_1 & "-" & Mes_1 & "-" & Dia_1 & " 23:59:59', 102))"


        Consulta_sql = "SELECT Id,CodSolicitud,Estado,Case " & vbCrLf &
                       "When Estado = 'SOL' Then 'SOLICITADO'" & vbCrLf &
                       "When Estado = 'ENT' Then 'ENTREGADO VEN.'" & vbCrLf &
                       "When Estado = 'REC' Then 'RECIBIDO BOD.'" & vbCrLf &
                       "When Estado = 'OUT' Then 'CANCELADO'" & vbCrLf &
                       "End As 'Nom_Estado'" & vbCrLf &
                       ",Funcionario,(Select Top 1 NOKOFU From TABFU Where KOFU = Funcionario) As 'Nom_Funcionario_Sol'" & vbCrLf &
                       ",Codigo,Descripcion,Empresa,Sucursal,Bodega," & vbCrLf &
                       "(Select NOKOBO From TABBO Where EMPRESA = Empresa And KOSU = Sucursal And KOBO = Bodega) As 'NomBodega'," & vbCrLf &
                       "Ubicacion," & vbCrLf &
                       "FechaHora_Solicita," & vbCrLf &
                       "Isnull(CONVERT(VARCHAR, FechaHora_Solicita, 103),'') Fecha_Sol," & vbCrLf &
                       "Isnull(CONVERT(VARCHAR, FechaHora_Solicita, 108),'') Hora_Sol," & vbCrLf &
                       "FechaHora_Entrega," & vbCrLf &
                       "Isnull(CONVERT(VARCHAR, FechaHora_Entrega, 103),'') Fecha_Ent," & vbCrLf &
                       "Isnull(CONVERT(VARCHAR, FechaHora_Entrega, 108),'') Hora_Ent," & vbCrLf &
                       "FechaHora_Recibe," & vbCrLf &
                       "Isnull(CONVERT(VARCHAR, FechaHora_Recibe, 103),'') Fecha_Rec," & vbCrLf &
                       "Isnull(CONVERT(VARCHAR, FechaHora_Recibe, 108),'') Hora_Rec," & vbCrLf &
                       "FechaHora_Cierre," & vbCrLf &
                       "Isnull(CONVERT(VARCHAR, FechaHora_Cierre, 103),'') Fecha_Cie," & vbCrLf &
                       "Isnull(CONVERT(VARCHAR, FechaHora_Cierre, 108),'') Hora_Cie," & vbCrLf &
                       "FechaHora_Autoriza_pasar," & vbCrLf &
                       "Isnull(CONVERT(VARCHAR, FechaHora_Autoriza_pasar, 103),'') Fecha_Aut," & vbCrLf &
                       "Isnull(CONVERT(VARCHAR, FechaHora_Autoriza_pasar, 108),'') Hora_Aut," & vbCrLf &
                       "Funcionario_Entrega," & vbCrLf &
                       "Isnull((Select Top 1 NOKOFU From TABFU Where KOFU = Funcionario_Entrega),'') As 'Nom_Funcionario_Ent'," & vbCrLf &
                       "Funcionario_Recibe," & vbCrLf &
                       "Isnull((Select Top 1 NOKOFU From TABFU Where KOFU = Funcionario_Recibe),'') As 'Nom_Funcionario_Rec'," & vbCrLf &
                       "Funcionario_Autoriza_cierre," & vbCrLf &
                       "Isnull((Select Top 1 NOKOFU From TABFU Where KOFU = Funcionario_Autoriza_cierre),'') As 'Nom_Funcionario_Cie'," & vbCrLf &
                       "Funcionario_Autoriza_pasar," & vbCrLf &
                       "Isnull((Select Top 1 NOKOFU From TABFU Where KOFU = Funcionario_Autoriza_pasar),'') As 'Nom_Funcionario_Aut'," & vbCrLf &
                       "Motivo_cierre" & vbCrLf &
                       "FROM " & _Global_BaseBk & "Zw_Prod_SolBodega" & vbCrLf &
                       "Where 1 > 0" & vbCrLf &
                       "And Estado In ('SOL','ENT')" & vbCrLf &
                       _Filtro_Fecha & vbCrLf &
                       _Condicion & vbCrLf &
                       "Order by FechaHora_Solicita"

        With Grilla
            _TblProductosSol = _SQL.Fx_Get_DataTable(Consulta_sql)

            .DataSource = _TblProductosSol
            '.DataSource = _TblProductosSol
            Dim W As Integer
            OcultarEncabezadoGrilla(Grilla, True)
            'Return
            .Columns("Id").HeaderText = "Id"
            .Columns("Id").Width = 0
            .Columns("Id").Visible = True

            .Columns("Nom_Estado").HeaderText = "Estado"
            .Columns("Nom_Estado").Width = 110
            '.Columns("Nom_Estado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Nom_Estado").Visible = True
            .Columns("Nom_Estado").ReadOnly = True

            .Columns("Nom_Funcionario_Sol").HeaderText = "Solicitado por"
            .Columns("Nom_Funcionario_Sol").Width = 175
            .Columns("Nom_Funcionario_Sol").Visible = True
            .Columns("Nom_Funcionario_Sol").ReadOnly = True

            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").Width = 100
            .Columns("Codigo").Visible = True
            .Columns("Codigo").ReadOnly = True

            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").Width = 300
            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").ReadOnly = True

            .Columns("Fecha_Sol").HeaderText = "Fecha Sol."
            .Columns("Fecha_Sol").Width = 80
            .Columns("Fecha_Sol").Visible = True
            .Columns("Fecha_Sol").ReadOnly = True

            .Columns("Hora_Sol").HeaderText = "Hora Sol."
            .Columns("Hora_Sol").Width = 80
            .Columns("Hora_Sol").Visible = True
            .Columns("Hora_Sol").ReadOnly = True

            For Each _Fila As DataGridViewRow In .Rows

                Dim _NroFila = _Fila.Index

                Dim _Estado As String = _Fila.Cells("Estado").Value

                If _Estado = "SOL" Then
                    If Global_Thema = Enum_Themas.Oscuro Then
                        _Fila.DefaultCellStyle.ForeColor = Color.Black
                    End If
                    _Fila.DefaultCellStyle.BackColor = Color.Yellow
                ElseIf _Estado = "ENT" Then
                    _Fila.DefaultCellStyle.BackColor = Color.Red
                    _Fila.DefaultCellStyle.ForeColor = Color.White
                ElseIf _Estado = "REC" Then
                    If Global_Thema = Enum_Themas.Oscuro Then
                        _Fila.DefaultCellStyle.ForeColor = Color.Black
                    End If
                    _Fila.DefaultCellStyle.BackColor = Color.LightGreen
                ElseIf _Estado = "OUT" Then
                    _Fila.DefaultCellStyle.BackColor = Color.Gray
                    _Fila.DefaultCellStyle.ForeColor = Color.White
                End If

            Next

        End With

    End Sub

    Sub Sb_Revisar_Vale(ByVal _CodSolicitud As String)

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Prod_SolBodega" & vbCrLf &
                       "Where CodSolicitud = '" & _CodSolicitud & "'"

        Dim _TblProdSol As DataTable = _SQL.Fx_Get_DataTable(Consulta_sql)

        If CBool(_TblProdSol.Rows.Count) Then

            Dim _Fila As DataRow = _TblProdSol.Rows(0)

            Dim _Id = _Fila.Item("Id")
            Dim _Estado = _Fila.Item("Estado")
            Dim _Codigo = _Fila.Item("Codigo").ToString.Trim
            Dim _Descripcion = _Fila.Item("Descripcion").ToString.Trim

            Dim _Bodega = _Fila.Item("Bodega").ToString.Trim
            Dim _Ubicacion = _Fila.Item("Ubicacion").ToString.Trim

            Dim _FechaHora_Solicita As DateTime = _Fila.Item("FechaHora_Solicita")
            Dim _FechaHora_Entrega As DateTime = NuloPorNro(_Fila.Item("FechaHora_Entrega"), Now.Date)
            Dim _FechaHora_Recibe As DateTime = NuloPorNro(_Fila.Item("FechaHora_Recibe"), Now.Date)

            Dim _Funcionario_Recibe As String = _Fila.Item("Funcionario_Recibe")
            Dim _Funcionario_Autoriza_pasar As String = _Fila.Item("Funcionario_Autoriza_pasar")
            Dim _Motivo_cierre As String = _Fila.Item("Motivo_cierre")

            If _Estado = "SOL" Then

                    If Fx_Entregar_Producto(_Codigo, _Id) Then
                        Sb_Actualizar_Grilla(_Condicion)
                        BuscarDatoEnGrilla(Trim(_Id), "Id", Grilla)
                    End If

                ElseIf _Estado = "ENT" Then

                    If Fx_Recibir_Producto(_Codigo, _Id) Then
                        Sb_Actualizar_Grilla(_Condicion)
                        BuscarDatoEnGrilla(Trim(_Id), "Id", Grilla)
                    End If

                ElseIf _Estado = "REC" Then

                    Dim _Fun = _Sql.Fx_Trae_Dato("TABFU", "NOKOFU", "KOFU = '" & _Funcionario_Recibe & "'")

                    MessageBoxEx.Show(Me, "Este producto ya fue entregado a la bodega" & vbCrLf & vbCrLf &
                                      "Recepcionado en bodega por: " & _Fun & vbCrLf &
                                      "Fecha de recepción:" & FormatDateTime(_FechaHora_Recibe, DateFormat.LongDate),
                                     "Solitar productos a bodega", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return

                ElseIf _Estado = "OUT" Then

                    Dim _Fun = _Sql.Fx_Trae_Dato("TABFU", "NOKOFU", "KOFU = '" & _Funcionario_Recibe & "'")

                    MessageBoxEx.Show(Me, "Esta solicitud ya esta cerrada" & vbCrLf & vbCrLf &
                                      "Motivo del cierre: " & _Motivo_cierre,
                                      "Solitar productos a bodega", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return


                End If

        Else

            Beep()
            ToastNotification.Show(Me, "DOCUMENTO NO EXISTE",
                                   My.Resources.cross,
                                   1 * 1000, eToastGlowColor.Red,
                                   eToastPosition.MiddleCenter)
        End If

    End Sub

    Function Fx_Entregar_Producto(ByVal _Codigo As String,
                                  ByVal _Id As String) As Boolean

        Dim Fm As New Frm_ValidarPermiso(Frm_ValidarPermiso.Tipo_Accion.Validar_Permiso, "Bkp00023", True, Chk_Validar_Usuario_Con_Huella.Checked)
        Fm.No_Necesita_Permiso_Supervisor = True
        Fm.Text = "PRESTAR PRODUCTO A VENTA"
        Fm.ShowDialog(Me)

        If (Fm.Pro_RowUsuario Is Nothing) Then Return False

        Dim _Kofu As String = Fm.Pro_RowUsuario.Item("KOFU")

        If Not Fm.Pro_Permiso_Aceptado Then
            If Fx_Tiene_Permiso(Me, "Bkp00023", _Kofu, , False) Then
                Fx_Entregar_Producto(_Codigo, _Id)
            Else
                Return False
            End If
        ElseIf Fm.Pro_Permiso_Aceptado Then

            Radio1.Text = "Producto encontrado"
            Radio1.Checked = True
            Radio2.Text = "Cancelar la solicitud (desistir)"
            Radio2.Checked = False
            Dim info As New TaskDialogInfo("Solitar productos a bodega",
                         eTaskDialogIcon.CheckMark2,
                          "¡DECIDIR QUE HACER CON EL PRODUCTO!",
                          "Debe seleccionar si sigue con la entrega o cancela la operación",
                          eTaskDialogButton.Cancel + eTaskDialogButton.Ok _
                          , eTaskDialogBackgroundColor.Red, GetRadioButtons, Nothing, Nothing, Nothing, Nothing)

            Dim result As eTaskDialogResult = TaskDialog.Show(info)

            If result = eTaskDialogResult.Ok Then

                Dim _Aceptado As Boolean

                If Radio1.Checked Then

                    Dim _Codigo_Pistoleado As String

                    _Aceptado = Trim(UCase(InputBox_Bk(Me, "INGRESE CODIGO DEL PRODUCTO",
                                              "PRESTAR PRODUCTO AL VENDEDOR", _Codigo_Pistoleado, False, _Tipo_Mayus_Minus.Normal,, True)))

                    If _Aceptado Then

                        If _Codigo = _Codigo_Pistoleado Then

                            BuscarDatoEnGrilla(Trim(_Id), "Id", Grilla)

                            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Prod_SolBodega Set " & vbCrLf &
                                       "Estado = 'ENT'," & vbCrLf &
                                       "FechaHora_Entrega = Getdate()," & vbCrLf &
                                       "Funcionario_Entrega = '" & _Kofu & "'" & vbCrLf &
                                       "Where Id = " & _Id
                            If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                                Beep()
                                ToastNotification.Show(Me, "ENTREGE EL PRODUCTO",
                                                   My.Resources.ok_button,
                                                   2 * 1000, eToastGlowColor.Green,
                                                   eToastPosition.MiddleCenter)

                            End If
                            Return True

                        Else
                            MessageBoxEx.Show(Me, "Producto no corresponde al solicitado según vale",
                                          "Solitar productos a bodega",
                                          MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Return False
                        End If

                    End If

                ElseIf Radio2.Checked Then

                    If Fx_Cancelar_solicitud(_Id, _Kofu) Then
                        Return True
                    End If

                End If
            Else
                Return False
            End If

        End If

    End Function

    Function Fx_Recibir_Producto(ByVal _Codigo As String,
                                 ByVal _Id As String) As Boolean

        Dim Fm As New Frm_ValidarPermiso(Frm_ValidarPermiso.Tipo_Accion.Validar_Permiso, "Bkp00024", True, Chk_Validar_Usuario_Con_Huella.Checked)
        Fm.No_Necesita_Permiso_Supervisor = True
        Fm.Text = "RECIBIR PRODUCTO EN BODEGA"
        Fm.ShowDialog(Me)

        If (Fm.Pro_RowUsuario Is Nothing) Then Return False

        Dim _Kofu As String = Fm.Pro_RowUsuario.Item("KOFU")

        If Not Fm.Pro_Permiso_Aceptado Then

            If Fx_Tiene_Permiso(Me, "Bkp00024", _Kofu, , False) Then
                Fx_Recibir_Producto(_Codigo, _Id)
            Else
                Return False
            End If

        ElseIf Fm.Pro_Permiso_Aceptado Then

            Dim _Aceptar As Boolean

            Dim _Codigo_Pistoleado As String

            _Aceptar = Trim(UCase(InputBox_Bk(Me, "INGRESE CODIGO DEL PRODUCTO",
                                               "DEVOLVER EL PRODUCTO A BODEGA", _Codigo_Pistoleado,
                                               False, _Tipo_Mayus_Minus.Normal,, True)))

            If _Aceptar Then

                If _Codigo = _Codigo_Pistoleado Then

                    BuscarDatoEnGrilla(Trim(_Id), "Id", Grilla)

                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_Prod_SolBodega Set " & vbCrLf &
                                   "Estado = 'REC'," & vbCrLf &
                                   "FechaHora_Recibe = Getdate()," & vbCrLf &
                                   "Funcionario_Recibe = '" & _Kofu & "'" & vbCrLf &
                                   "Where Id = " & _Id
                    If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                        Beep()
                        ToastNotification.Show(Me, "RECEPCION ACEPTADA",
                                               My.Resources.ok_button,
                                               2 * 1000, eToastGlowColor.Green,
                                               eToastPosition.MiddleCenter)

                        Return True

                    End If
                Else
                    Beep()
                    ToastNotification.Show(Me, "PRODUCTO NO CORRESPONDE AL SOLICITADO",
                                           My.Resources.cross,
                                           2 * 1000, eToastGlowColor.Red,
                                           eToastPosition.MiddleCenter)

                    Return False
                End If
            End If

        Else
            Return False
        End If

    End Function

    Function Fx_Cancelar_solicitud(ByVal _Id As String,
                                   ByVal _Usuario As String) As Boolean

        Dim _Funcionario_Autoriza_cierre As String
        Dim _Motivo_cierre As String

        Radio1.Checked = True
        Radio2.Checked = False
        Radio3.Checked = False

        Radio1.Text = "Producto no encontrado"
        Radio2.Text = "Ya no se necesita"
        Radio3.Text = "Otro motivo"

        Dim _Radios As Command() = {Radio1, Radio2, Radio3}

        Dim info As New TaskDialogInfo("Solitar productos a bodega",
               eTaskDialogIcon.Shield,
               "¡CANCELAR SOLICITUD!",
               "PARA CANCELAR LAS SOLICITUDES SE NECESITA UN PERMISO ESPECIAL" & vbCrLf & vbCrLf & "Seleccione una opción",
               eTaskDialogButton.Ok + eTaskDialogButton.Cancel _
               , eTaskDialogBackgroundColor.Red, _Radios, Nothing, Nothing, Nothing, Nothing)

        Dim result As eTaskDialogResult = TaskDialog.Show(info)

        If result = eTaskDialogResult.Ok Then

            Dim Fm As New Frm_ValidarPermiso(Frm_ValidarPermiso.Tipo_Accion.Validar_Permiso, "Bkp00028", True, Chk_Validar_Usuario_Con_Huella.Checked)
            Fm.No_Necesita_Permiso_Supervisor = True
            Fm.Text = "CLAVE PARA AUTORIZAR ACCION"
            Fm.ShowDialog(Me)

            If (Fm.Pro_RowUsuario Is Nothing) Then Return False

            Dim _Kofu As String = Fm.Pro_RowUsuario.Item("KOFU")

            If Not Fm.Pro_Permiso_Aceptado Then

                If Fx_Tiene_Permiso(Me, "Bkp00028", _Kofu) Then
                    Fx_Cancelar_solicitud(_Id, _Usuario)
                Else
                    Return False
                End If

            End If

            _Funcionario_Autoriza_cierre = _Kofu

            If Radio1.Checked Then
                _Motivo_cierre = "Producto no encontrado"
            ElseIf Radio2.Checked Then
                _Motivo_cierre = "El vendedor ya no lo necesita"
            ElseIf Radio3.Checked Then

                Dim _Aceptado As Boolean

                _Aceptado = InputBox_Bk(Me, "Escriba el motivo para cancelar la solicitud",
                                               "Cancelar solicitud", _Motivo_cierre, , _Tipo_Mayus_Minus.Mayusculas,, True)

                If _Aceptado Then
                    _Motivo_cierre = QuitaEspacios_ParaCodigos(_Motivo_cierre, 1)
                Else
                    Return False
                End If

            End If

        Else
            Return False
        End If

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Prod_SolBodega Set " & vbCrLf &
                       "Estado = 'OUT'," & vbCrLf &
                       "FechaHora_Cierre = Getdate()," & vbCrLf &
                       "Funcionario_Entrega = '" & _Usuario & "'," & vbCrLf &
                       "Funcionario_Autoriza_cierre = '" & _Funcionario_Autoriza_cierre & "'," & vbCrLf &
                       "Motivo_cierre = '" & UCase(_Motivo_cierre) & "'" & vbCrLf &
                       "Where Id = " & _Id

        If _Sql.Ej_consulta_IDU(Consulta_Sql) Then

            MessageBoxEx.Show(Me, "PRODUCTO LIBERADO", "Solitar productos a bodega",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)

            Return True

        End If

    End Function

    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        If Not _Fila.IsNewRow Then

            Dim _Estado As String = _Fila.Cells("Estado").Value

            If Fx_Tiene_Permiso(Me, "Bkp00030") Then

                Dim _CodSolicitud As String = _Fila.Cells("CodSolicitud").Value
                Sb_Revisar_Vale(_CodSolicitud)

            End If
        End If
    End Sub

    Private Sub BtnExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExportarExcel.Click

        If Fx_Tiene_Permiso(Me, "Bkp00029") Then
            Sb_Actualizar_Grilla()
            ExportarTabla_JetExcel_Tabla(_TblProductosSol, Me, "Lista productos solicitados a bodega")
        End If

    End Sub


    Private Sub BtnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActualizar.Click
        Sb_Actualizar_Grilla(_Condicion)
    End Sub



    Private Sub Grilla_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Grilla.MouseDown

        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    If Not Grilla.Rows(Grilla.CurrentRow.Index).IsNewRow Then
                        ShowContextMenu(Menu_Contextual_01)
                    End If
                End If
            End With
        End If

    End Sub

    Private Sub Frm_Sol_Pro_Bodega_ListaPendientes_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then Me.Close()
    End Sub


    Private Sub Sb_Chk_Validar_Usuario_Con_Huella_CheckedChanged(sender As Object, e As EventArgs)
        If Not Chk_Validar_Usuario_Con_Huella.Checked Then
            If Not Fx_Tiene_Permiso(Me, "Bkp00052") Then
                Chk_Validar_Usuario_Con_Huella.Checked = True
            End If
        End If
    End Sub

    Private Sub Mnu_Btn_VerTraza_Click(sender As Object, e As EventArgs) Handles Mnu_Btn_VerTraza.Click
        If Fx_Tiene_Permiso(Me, "Bkp00032") Then

            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

            Dim Fm As New Frm_Sol_Pro_Bodega_InforXproducto
            Fm._Fila = _Fila
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If
    End Sub

    Private Sub Mnu_Btn_Ver_Informacion_de_producto_Click(sender As Object, e As EventArgs) Handles Mnu_Btn_Ver_Informacion_de_producto.Click
        If Fx_Tiene_Permiso(Me, "Prod009") Then

            Dim _Codigo = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Codigo").Value
            Dim Fm As New Frm_EstadisticaProducto(_Codigo)
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If
    End Sub
End Class
