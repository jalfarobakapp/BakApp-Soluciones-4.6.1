Imports DevComponents.DotNetBar

Public Class Frm_Recalculo_PPP_Selec_Prod

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Tbl_Productos As DataTable
    Public Property ProcesarTodos As Boolean
    Public Property ProcesarConMovEntreFechas As Boolean


    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Btn_Aceptar_Click(sender As Object, e As EventArgs) Handles Btn_Aceptar.Click

        If Rdb_Productos_Seleccionar.Checked Then
            If (_Tbl_Productos Is Nothing) OrElse Not CBool(_Tbl_Productos.Rows.Count) Then
                MessageBoxEx.Show(Me, "No exiten datos seleccionados", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If
        End If

        If Rdb_Productos_Todos.Checked Then

            Consulta_sql = $"Select KOPR AS 'Codigo', NOKOPR AS 'Descripcion' From MAEPR TIPR In ('FPN'{IIf(Chk_IncluirInsumos.Checked, ",'FIN'", "")})"
            Tbl_Productos = _Sql.Fx_Get_DataTable(Consulta_sql)

        ElseIf Rdb_Productos_Con_Movimientos.Checked Then

            Consulta_sql = "Select KOPR AS 'Codigo', NOKOPR AS 'Descripcion'" &
                           "From MAEPR" & vbCrLf &
                           $"Where TIPR In ('FPN'{IIf(Chk_IncluirInsumos.Checked, ",'FIN'", "")}) And" & Space(1) &
                           "KOPR IN (Select Distinct KOPRCT From MAEDDO" & Space(1) &
                           "Where FEEMLI BETWEEN '" & Format(Dtp_Fecha_Movimientos_Desde.Value, "yyyyMMdd") & "'" & Space(1) &
                           "And '" & Format(Dtp_Fecha_Movimientos_Hasta.Value, "yyyyMMdd") & "')"
            Tbl_Productos = _Sql.Fx_Get_DataTable(Consulta_sql)

            If Not CBool(Tbl_Productos.Rows.Count) Then
                MessageBoxEx.Show(Me, "No se encontraron productos", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

        End If

        Me.DialogResult = DialogResult.OK
        Me.Close()

    End Sub

    Private Sub Btn_Seleccionar_Productos_Click(sender As Object, e As EventArgs) Handles Btn_Seleccionar_Productos.Click

        Dim _Sql_Filtro_Condicion_Extra = $"And TIPR In ('FPN'{IIf(Chk_IncluirInsumos.Checked, ",'FIN'", "")})"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Productos,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Productos, _Sql_Filtro_Condicion_Extra,
                               False, False) Then

            _Tbl_Productos = _Filtrar.Pro_Tbl_Filtro
            If _Filtrar.Pro_Filtro_Todas Then
                Rdb_Productos_Todos.Checked = True
                _Tbl_Productos = Nothing
            End If

        End If

    End Sub

    Private Sub Frm_Recalculo_PPP_Selec_Prod_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
