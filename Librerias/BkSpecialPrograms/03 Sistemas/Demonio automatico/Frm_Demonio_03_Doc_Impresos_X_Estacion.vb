Imports DevComponents.DotNetBar
'Imports Lib_Bakapp_VarClassFunc

Public Class Frm_Demonio_03_Doc_Impresos_X_Estacion

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tido As String
    Dim _Nombre_Equipo As String
    Dim _Impresora As String
    Dim _Tbl_Documentos_Informe As DataTable
    Dim _Tbl_Doc_A_Imprimir As DataTable

    Public Property Pro_Impresora() As String
        Get
            Return _Impresora
        End Get
        Set(ByVal value As String)
            _Impresora = value
        End Set
    End Property
    Public Property Pro_Nombre_Equipo()
        Get
            Return _Nombre_Equipo
        End Get
        Set(ByVal value)
            _Nombre_Equipo = value
        End Set
    End Property
    Public ReadOnly Property Pro_Tbl_Doc_A_Imprimir() As DataTable
        Get

            Consulta_sql = "Select TipoDoc as Padre,NombreDoc as Hijo From " & _Global_BaseBk & "Zw_Demonio_Cof_Estacion" & vbCrLf &
                       "WHERE Traer_Doc_Auto_Imprimir = 1 And NombreEquipo = '" & _Nombre_Equipo & "'" & vbCrLf & "ORDER BY Padre"
            _Tbl_Doc_A_Imprimir = _Sql.Fx_Get_DataTable(Consulta_sql)

            Return _Tbl_Doc_A_Imprimir
        End Get
    End Property

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 25, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        If Global_Thema = Enum_Themas.Oscuro Then

            Btn_Imprimir.ForeColor = Color.White
            BtnBuscarDocumentos.ForeColor = Color.White

        End If

    End Sub

    Private Sub Frm_Imp_Picking_01_Documentos_Impresos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Consulta_sql = "Select TipoDoc as Padre,NombreDoc as Hijo From " & _Global_BaseBk & "Zw_Demonio_Cof_Estacion" & vbCrLf &
                       "Where Traer_Doc_Auto_Imprimir = 1 And NombreEquipo = '" & _Nombre_Equipo & "'" & vbCrLf &
                       "Order BY Padre"
        _Tbl_Doc_A_Imprimir = _Sql.Fx_Get_DataTable(Consulta_sql)

        caract_combo(Cmb_Tido)
        Cmb_Tido.DataSource = _Tbl_Doc_A_Imprimir

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown

        AddHandler DtpFecharevision.ValueChanged, AddressOf Sb_Actualizar_Grilla
        AddHandler Cmb_Tido.SelectedIndexChanged, AddressOf Sb_Actualizar_Grilla

        Sb_InsertarBotonenGrilla(Grilla, "BtnImagen", "Est.", "Estado", 0, _Tipo_Boton.Imagen)

        Sb_Actualizar_Grilla()

    End Sub

    Sub Sb_Actualizar_Grilla()

        _Tido = Cmb_Tido.SelectedValue

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Demonio_Cof_Estacion" & vbCrLf &
                       "Where TipoDoc = '" & _Tido & "' And NombreEquipo = '" & _Nombre_Equipo & "'"
        Dim _Row_ConfEstacion As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _IdPadre = _Row_ConfEstacion.Item("Id")

        Dim _Fecha = Format(DtpFecharevision.Value, "yyyMMdd")
        Dim Dia_1 As String = numero_(DtpFecharevision.Value.Day, 2)
        Dim Mes_1 As String = numero_(DtpFecharevision.Value.Month, 2)
        Dim Ano_1 As String = DtpFecharevision.Value.Year

        Dim _Filtro_Fechas =
                      "And FEEMDO BETWEEN CONVERT(DATETIME, '" & Ano_1 & "-" & Mes_1 & "-" & Dia_1 & " 00:00:00', 102)" & vbCrLf &
                      "AND CONVERT(DATETIME, '" & Ano_1 & "-" & Mes_1 & "-" & Dia_1 & " 23:59:59', 102)"

        Consulta_sql = "Select Codigo From " & _Global_BaseBk & "Zw_Demonio_Filtros_X_Estacion" & vbCrLf &
                       "Where IdPadre = " & _IdPadre
        Dim _TblFiltroFunc As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim _Filtro_Funcionarios As String

        If CBool(_TblFiltroFunc.Rows.Count) Then
            _Filtro_Funcionarios = Generar_Filtro_IN(_TblFiltroFunc, "", "Codigo", False, False, "'") ' 
            _Filtro_Funcionarios = "And KOFUDO In " & _Filtro_Funcionarios
        End If

        _Sql.Sb_Eliminar_Tabla_De_Paso("#Paso001")

        Consulta_sql = My.Resources.Recursos_Demonio.SqlQuery_Buscar_Doc_Impresos_y_Log_Errores
        Consulta_sql = Replace(Consulta_sql, "#Filtro_Fechas#", _Filtro_Fechas)
        Consulta_sql = Replace(Consulta_sql, "#NombreEquipo#", _Nombre_Equipo)
        Consulta_sql = Replace(Consulta_sql, "#Tido#", _Tido)
        Consulta_sql = Replace(Consulta_sql, "#Filtro_Funcionarios#", _Filtro_Funcionarios)
        Consulta_sql = Replace(Consulta_sql, "#Zw_Demonio_Doc_Emitidos_Cola_Impresion#",
                               _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Cola_Impresion")

        Consulta_sql = Replace(Consulta_sql, "#Fecha#", _Fecha)

        _Tbl_Documentos_Informe = _Sql.Fx_Get_DataTable(Consulta_sql)

        With Grilla

            .DataSource = _Tbl_Documentos_Informe

            OcultarEncabezadoGrilla(Grilla)

            .Columns("BtnImagen").Width = 50
            .Columns("BtnImagen").HeaderText = "Est."
            .Columns("BtnImagen").Visible = True

            .Columns("Chk").Width = 40
            .Columns("Chk").HeaderText = "Print"
            .Columns("Chk").Visible = True
            .Columns("Chk").ReadOnly = False

            .Columns("TIDO").Width = 40
            .Columns("TIDO").HeaderText = "TD"
            .Columns("TIDO").Visible = True

            .Columns("NUDO").Width = 80
            .Columns("NUDO").HeaderText = "Número"
            .Columns("NUDO").Visible = True

            .Columns("RAZON").Width = 280
            .Columns("RAZON").HeaderText = "Entidad"
            .Columns("RAZON").Visible = True

            .Columns("VABRDO").Width = 80
            .Columns("VABRDO").HeaderText = "Total"
            .Columns("VABRDO").DefaultCellStyle.Format = "$ ##,###"
            .Columns("VABRDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VABRDO").Visible = True

            .Columns("Items").Width = 60
            .Columns("Items").HeaderText = "Items"
            .Columns("Items").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Items").Visible = True

            .Columns("KOFUDO").Width = 30
            .Columns("KOFUDO").HeaderText = "Func."
            .Columns("KOFUDO").Visible = True

        End With

        Chk_Seleccionar_Todo.Checked = False

        If CBool(Grilla.Rows.Count) Then
            Sb_ChequearTodo(Grilla, False)
        End If

        For Each _Row As DataGridViewRow In Grilla.Rows

            Dim _Impreso = _Row.Cells("Impreso").Value
            Dim _Error_Al_Imprimir = _Row.Cells("Error_Al_Imprimir").Value

            If _Error_Al_Imprimir Then
                _Row.Cells("BtnImagen").Value = Imagenes_20x20.Images.Item("print-error.png")
            Else
                If _Impreso Then
                    _Row.Cells("BtnImagen").Value = Imagenes_20x20.Images.Item("print-ok.png")
                Else
                    _Row.Cells("BtnImagen").Value = Imagenes_20x20.Images.Item("print-warn.png")
                End If
            End If

        Next

        Me.Text = "Re-imprimir documentos Nombre Equipo:" & _Nombre_Equipo

    End Sub

    Private Sub BtnBuscarDocumentos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarDocumentos.Click
        ' Dim Fm As New Frm_Demonio_01(Me)
        'Fm._Impresora = _Impresora
        'Fm.Sb_Reimprimir_documento()
        'Fm.Dispose()
    End Sub

    Private Sub BtnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActualizar.Click
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub Frm_Imp_Picking_01_Documentos_Impresos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Imprimir.Click

        Dim _Filtrpo_SQl = Generar_Filtro_IN(_Tbl_Documentos_Informe, "Chk", "TIDO", False, True, "'")

        If _Filtrpo_SQl = "()" Then
            MessageBoxEx.Show(Me, "No se seleccionó ningún registro",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Imp As String = _Impresora

        Dim Fm As New Frm_Seleccionar_Impresoras(_Impresora)
        Fm.ShowDialog(Me)

        If Not String.IsNullOrEmpty(Trim(Fm.Pro_Impresora_Seleccionada)) Then
            _Imp = Fm.Pro_Impresora_Seleccionada
        Else
            Return
        End If

        Dim _NombreFormato = Fx_NombreFormato()

        Try
            Me.Enabled = False

            If Not String.IsNullOrEmpty(_NombreFormato) Then

                Dim _Imprimir = MessageBoxEx.Show(Me, "¿Confirma la impresión masiva?",
                                         "Re-Imprimir Documentos",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If _Imprimir = Windows.Forms.DialogResult.Yes Then

                    For Each _Fila As DataGridViewRow In Grilla.Rows

                        Dim _Chk As Boolean = _Fila.Cells("Chk").Value

                        If _Chk Then
                            If Not Fx_ReImprimir_Documento(_Fila, _Imp, _NombreFormato) Then
                                Exit For
                            End If
                        End If

                    Next

                    Chk_Seleccionar_Todo.Checked = False
                    Sb_ChequearTodo(Grilla, False)

                End If

            End If

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            Me.Enabled = True
        End Try


    End Sub

    Function Fx_NombreFormato() As String

        Dim _TipoDoc = Cmb_Tido.SelectedValue
        Dim _NombreFormato = String.Empty

        Dim Fm As New Frm_Seleccionar_Formato(_TipoDoc)
        If CBool(Fm.Tbl_Formatos.Rows.Count) Then
            Fm.ShowDialog(Me)
            If Fm.Formato_Seleccionado Then _NombreFormato = Fm.Row_Formato_Seleccionado.Item("NombreFormato")
        Else
            MessageBoxEx.Show(Me, "No existen formatos adicionales para este documento",
                              "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
        Fm.Dispose()

        Return _NombreFormato

    End Function

    Function Fx_ReImprimir_Documento(ByVal _Fila As DataGridViewRow,
                                     ByVal _Impresora As String,
                                     ByVal _NombreFormato As String) As Boolean

        Dim _Idmaeedo = _Fila.Cells("IDMAEEDO").Value
        Dim _Tido = _Fila.Cells("TIDO").Value

        Consulta_sql = "Select Top 1 * From MAEEDO Where IDMAEEDO = " & _Idmaeedo
        Dim _RowEncabezado As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)


        'Dim _Log_Error = Fx_Enviar_A_Imprimir_Documento(Me,
        '                                                _NombreFormato,
        '                                                _Idmaeedo,
        '                                                False, False, _Impresora, False, 0, False, "")

        Dim _Mensaje As LsValiciones.Mensajes

        _Mensaje = Fx_Enviar_A_Imprimir_Documento(Me,
                                                        _NombreFormato,
                                                        _Idmaeedo,
                                                        False, False, _Impresora, False, 0, False, "")

        If Not _Mensaje.EsCorrecto Then
            MessageBoxEx.Show(_Mensaje.Mensaje, "Error al imprimir", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

        'If Not String.IsNullOrEmpty(_Log_Error) Then
        '    MessageBoxEx.Show(_Log_Error, "Error al imprimir", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        'End If

        Return _Mensaje.EsCorrecto

    End Function

    Private Sub Chk_Seleccionar_Todo_CheckedChanged(ByVal sender As System.Object, ByVal e As DevComponents.DotNetBar.CheckBoxChangeEventArgs) Handles Chk_Seleccionar_Todo.CheckedChanged
        Dim chk As Boolean = Chk_Seleccionar_Todo.Checked
        Sb_ChequearTodo(Grilla, chk)
    End Sub

    Private Sub Sb_ChequearTodo(ByVal Grilla As DataGridView,
                                ByVal Chk As Boolean)

        For Each _Fila As DataGridViewRow In Grilla.Rows
            _Fila.Cells("Chk").Value = Chk
        Next

        Grilla.CurrentCell = Grilla.Rows(0).Cells("TIDO")

    End Sub


    Private Sub Grilla_CellMouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Grilla.CellMouseUp
        Grilla.EndEdit()
    End Sub

    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Error_Al_Imprimir As Boolean = _Fila.Cells("Error_Al_Imprimir").Value

        Btn_Revisar_Problema.Visible = _Error_Al_Imprimir

        ShowContextMenu(Menu_Contextual_01)

    End Sub

    Private Sub Sb_Grilla_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
                    Dim _Error_Al_Imprimir As Boolean = _Fila.Cells("Error_Al_Imprimir").Value

                    Btn_Revisar_Problema.Visible = _Error_Al_Imprimir

                    ShowContextMenu(Menu_Contextual_01)

                End If
            End With
        End If
    End Sub

    Private Sub Btn_Ver_Documento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ver_Documento.Click
        Dim _Idmaeedo = Grilla.Rows(Grilla.CurrentRow.Index).Cells("IDMAEEDO").Value

        Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub

    Private Sub Btn_Imprimir_Documento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Imprimir_Documento.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Tido = _Fila.Cells("TIDO").Value
        Dim _Nudo = _Fila.Cells("NUDO").Value
        Dim _Log_Error = _Fila.Cells("Log_Error").Value
        Dim _Kofudo = _Fila.Cells("KOFUDO").Value
        Dim _Funcionario = _Fila.Cells("FUNCIONARIO").Value
        Dim _Impreso = _Fila.Cells("Impreso").Value
        Dim _Error_Al_Imprimir = _Fila.Cells("Error_Al_Imprimir").Value

        Dim _Imp As String = _Impresora

        Dim Fm As New Frm_Seleccionar_Impresoras(_Imp)
        Fm.ShowDialog(Me)

        If Not String.IsNullOrEmpty(Trim(Fm.Pro_Impresora_Seleccionada)) Then
            _Imp = Fm.Pro_Impresora_Seleccionada
        Else
            Return
        End If

        Dim _NombreFormato = Fx_NombreFormato()

        If Not String.IsNullOrEmpty(_NombreFormato) Then
            Fx_ReImprimir_Documento(_Fila, _Imp, _NombreFormato)
        End If

    End Sub

    Private Sub Btn_Revisar_Problema_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Revisar_Problema.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Tido = _Fila.Cells("TIDO").Value
        Dim _Nudo = _Fila.Cells("NUDO").Value
        Dim _Log_Error = _Fila.Cells("Log_Error").Value
        Dim _Kofudo = _Fila.Cells("KOFUDO").Value
        Dim _Funcionario = _Fila.Cells("FUNCIONARIO").Value
        Dim _Impreso = _Fila.Cells("Impreso").Value
        Dim _Error_Al_Imprimir = _Fila.Cells("Error_Al_Imprimir").Value

        MessageBoxEx.Show(Me, _Log_Error & vbCrLf &
                          "Funcionario Documento: (" & _Kofudo & ") " & _Funcionario,
                          "Definición del error", MessageBoxButtons.OK,
                           MessageBoxIcon.Warning)

    End Sub

End Class
