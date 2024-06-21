Public Class Frm_Inv_Ctrl_Inventario

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Id As Integer
    Public Property Cl_Inventario As New Cl_Inventario

    Public Sub New(_Id As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Id = _Id
        Cl_Inventario.Fx_Llenar_Zw_Inv_Inventario(_Id)

    End Sub

    Private Sub Frm_Control_Inventario_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Lbl_Nombre_Inventario.Text = Cl_Inventario.Zw_Inv_Inventario.NombreInventario

    End Sub


    Private Sub Btn_Operadores_Click(sender As Object, e As EventArgs) Handles Btn_Operadores.Click

        Dim Fm As New Frm_Operadores(_Id)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Parejas_Click(sender As Object, e As EventArgs) Handles Btn_Parejas.Click

        Dim Fm As New Frm_Parejas(_Id)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Sectores_Click(sender As Object, e As EventArgs) Handles Btn_Sectores.Click

        Dim Fm As New Frm_Inv_Ubicaciones(_Id)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Plan_Click(sender As Object, e As EventArgs) Handles Btn_Plan.Click

        Dim Fm As New Frm_Plan(_Id)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub


End Class
