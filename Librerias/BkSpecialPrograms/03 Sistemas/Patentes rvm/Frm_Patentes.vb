Public Class Frm_Patentes

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Tbl_Patentes As DataTable

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_Patentes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_Sql = "Select * From Zw_Patentes_rvm Where Marca = '' And Modelo = ''"
        _Tbl_Patentes = _Sql.Fx_Get_DataTable(Consulta_Sql)

        Dim _DisplayIndex = 0

        With Grilla

            .DataSource = _Tbl_Patentes

            .Columns("Descripcion").Width = 150
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").ReadOnly = False
            .Columns("Descripcion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("PorcComision").Width = 50
            .Columns("PorcComision").HeaderText = "% CM"
            .Columns("PorcComision").ToolTipText = "Porcenta de comisión"
            .Columns("PorcComision").Visible = True
            .Columns("PorcComision").ReadOnly = False
            .Columns("PorcComision").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Resumen").Width = 200
            .Columns("Resumen").HeaderText = "Resumen"
            .Columns("Resumen").Visible = True
            .Columns("Resumen").ReadOnly = False
            .Columns("Resumen").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub


End Class
