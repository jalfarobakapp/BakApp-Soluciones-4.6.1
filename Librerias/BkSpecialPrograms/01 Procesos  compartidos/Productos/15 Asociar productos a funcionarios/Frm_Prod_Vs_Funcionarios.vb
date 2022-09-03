Imports DevComponents.DotNetBar
Public Class Frm_Prod_Vs_Funcionarios

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Row_Funcionario As DataRow
    Dim _Tbl_Productos As DataTable
    Dim _Dv As New DataView

    Dim _CodFuncionario As String

    Public Property Tbl_Productos As DataTable
        Get
            Return _Tbl_Productos
        End Get
        Set(value As DataTable)
            _Tbl_Productos = value
        End Set
    End Property

    Public Sub New(_CodFuncionario As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.White, ScrollBars.Vertical, True, False, False)

        Me._CodFuncionario = _CodFuncionario

        Consulta_Sql = "Select * From TABFU Where KOFU = '" & _CodFuncionario & "'"
        Dim _Row_Funcionario = _Sql.Fx_Get_DataRow(Consulta_Sql)

        Me.Text = "FUNCIONARIO: " & _CodFuncionario & " - " & _Row_Funcionario.Item("NOKOFU").ToString.Trim

    End Sub

    Private Sub Frm_Prod_Vs_Funcionarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        Sb_Actualizar_Grilla()

    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_Sql = "Select Cast(0 As Bit) As Chk,Empresa,CodFuncionario,Codigo,
                        Case 
                            When NOKOPR Is Null Then 
                                Case 
                                    When NOKOCT Is Null Then '???' 
                                    Else NOKOCT 
                                End 
                            Else NOKOPR 
                        End As Descripcion" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Prod_Usuario_Validador" & vbCrLf &
                       "Left Join MAEPR On KOPR = Codigo" & vbCrLf &
                       "Left Join TABCT On KOCT = Codigo" & vbCrLf &
                       "Where Empresa = '" & ModEmpresa & "' And CodFuncionario = '" & _CodFuncionario & "'"
        Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_Sql)

        _Tbl_Productos = _Ds.Tables("Table")
        _Dv.Table = _Tbl_Productos

        Dim _DisplayIndex = 0

        With Grilla

            .DataSource = _Dv

            OcultarEncabezadoGrilla(Grilla)

            .Columns("Chk").HeaderText = "Sel"
            .Columns("Chk").Width = 25
            .Columns("Chk").Visible = True
            .Columns("Chk").ReadOnly = False
            .Columns("Chk").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Codigo").Width = 110
            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").Visible = True
            .Columns("Codigo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Descripcion").Width = 400
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        Grupo.Text = "Detalle de productos asignados al funcionario. (" & FormatNumber(Grilla.Rows.Count, 0) & ")"

        Chk_Seleccionar_Todos.Checked = False
        Chk_Seleccionar_Todos.Enabled = _Tbl_Productos.Rows.Count
        Btn_Quitar_Productos.Enabled = _Tbl_Productos.Rows.Count
        Btn_Exportar_Excel.Enabled = _Tbl_Productos.Rows.Count

    End Sub

    Private Sub Btn_Quitar_Productos_Click(sender As Object, e As EventArgs) Handles Btn_Quitar_Productos.Click

        Dim Consulta_sql As String

        Try

            Bar2.Enabled = False

            Dim _Contador = 0

            For Each _Fila As DataRow In _Tbl_Productos.Rows

                Dim _Chk As Boolean = _Fila.Item("Chk")

                If _Chk Then _Contador += 1

            Next

            If _Contador = 0 Then

                MessageBoxEx.Show(Me, "No existen productos seleccionados", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return

            End If

            If MessageBoxEx.Show(Me, "¿Está seguro de quitar los registros marcados?", "Quitar registros. (Marcados " & _Contador & ")",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Consulta_sql = String.Empty

                For Each _Fila As DataRow In _Tbl_Productos.Rows

                    Dim _Codigo As String = _Fila.Item("Codigo")
                    Dim _Chk As Boolean = _Fila.Item("Chk")

                    If _Chk Then

                        Consulta_sql += "Delete " & _Global_BaseBk & "Zw_Prod_Usuario_Validador" & vbCrLf &
                                       "Where Empresa = '" & ModEmpresa & "' And CodFuncionario = '" & _CodFuncionario & "' And Codigo = '" & _Codigo & "'" & vbCrLf

                    End If

                Next

                If Not String.IsNullOrEmpty(Consulta_sql) Then
                    If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                        MessageBoxEx.Show(Me, "Productos quitados", "Quitar productos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If

            End If

            Sb_Actualizar_Grilla()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Bar2.Enabled = True
        End Try

    End Sub

    Private Sub Grilla_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grilla.CellMouseUp
        Grilla.EndEdit()
    End Sub

    Private Sub Btn_Exportar_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Exportar_Excel.Click
        ExportarTabla_JetExcel_Tabla(_Tbl_Productos, Me, "Productos_" & FUNCIONARIO)
    End Sub

    Private Sub Txt_Descripcion_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Descripcion.KeyDown
        If e.KeyValue = Keys.Enter Then
            _Dv.RowFilter = "Codigo+Descripcion Like '%" & Txt_Descripcion.Text.Trim & "%'"
        End If
    End Sub

    Private Sub Chk_Seleccionar_Todos_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Seleccionar_Todos.CheckedChanged

        Try

            Dim chk As Boolean = Chk_Seleccionar_Todos.Checked

            For Each _Fila As DataGridViewRow In Grilla.Rows
                _Fila.Cells("Chk").Value = chk
            Next

            If _Tbl_Productos.Rows.Count Then
                Grilla.CurrentCell = Grilla.Rows(0).Cells("Codigo")
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Btn_Agregar_Productos_Click(sender As Object, e As EventArgs) Handles Btn_Agregar_Productos.Click

        Dim _Filtro_Productos As String = Generar_Filtro_IN(_Tbl_Productos, "", "Codigo", False, False, "'")

        Dim _Sql_Filtro_Condicion_Extra = "And KOPR Not In (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Usuario_Validador " &
                                          "Where Empresa = '" & ModEmpresa & "')"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        Dim _Tbl_Filtro_Productos As DataTable

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Productos,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Productos, _Sql_Filtro_Condicion_Extra,
                               False, False) Then

            _Tbl_Filtro_Productos = _Filtrar.Pro_Tbl_Filtro

            If CBool(_Tbl_Filtro_Productos.Rows.Count) Then

                Bar2.Enabled = False
                Dim Consulta_sql As String

                _Filtro_Productos = Generar_Filtro_IN(_Tbl_Filtro_Productos, "Chk", "Codigo", False, True, "'")

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Prod_Usuario_Validador (Empresa, CodFuncionario, Codigo)" & vbCrLf &
                               "Select '" & ModEmpresa & "','" & _CodFuncionario & "',KOPR" & vbCrLf &
                               "From MAEPR" & vbCrLf &
                               "Where KOPR In " & _Filtro_Productos & vbCrLf
                _Sql.Ej_consulta_IDU(Consulta_sql)

                Sb_Actualizar_Grilla()
                Bar2.Enabled = True

            End If

        End If


    End Sub

    Private Sub Btn_Agregar_Conceptos_Click(sender As Object, e As EventArgs) Handles Btn_Agregar_Conceptos.Click

        Dim _Filtro_Productos As String = Generar_Filtro_IN(_Tbl_Productos, "", "Codigo", False, False, "'")

        Dim _Sql_Filtro_Condicion_Extra = "And KOCT Not In (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Usuario_Validador " &
                                          "Where Empresa = '" & ModEmpresa & "')"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        Dim _Tbl_Filtro_Productos As DataTable

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Productos,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Conceptos, _Sql_Filtro_Condicion_Extra,
                               False, False) Then

            _Tbl_Filtro_Productos = _Filtrar.Pro_Tbl_Filtro

            If CBool(_Tbl_Filtro_Productos.Rows.Count) Then

                Bar2.Enabled = False
                Dim Consulta_sql As String

                _Filtro_Productos = Generar_Filtro_IN(_Tbl_Filtro_Productos, "Chk", "Codigo", False, True, "'")

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Prod_Usuario_Validador (Empresa, CodFuncionario, Codigo)" & vbCrLf &
                               "Select '" & ModEmpresa & "','" & _CodFuncionario & "',KOCT" & vbCrLf &
                               "From TABCT" & vbCrLf &
                               "Where KOCT In " & _Filtro_Productos & vbCrLf
                _Sql.Ej_consulta_IDU(Consulta_sql)

                Sb_Actualizar_Grilla()
                Bar2.Enabled = True

            End If

        End If


    End Sub

    Private Sub Btn_AgregarProductos_Click(sender As Object, e As EventArgs) Handles Btn_AgregarProductos.Click
        ShowContextMenu(Menu_Contextual_03)
    End Sub

    Private Sub Grilla_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Grilla.DataError

    End Sub
End Class
