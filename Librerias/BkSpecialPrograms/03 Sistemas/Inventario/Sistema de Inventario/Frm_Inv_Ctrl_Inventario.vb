Public Class Frm_Inv_Ctrl_Inventario

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Id_Inventario As Integer
    Dim _Row_Inventario As DataRow

    Public Property Row_Inventario As DataRow
        Get
            Return _Row_Inventario
        End Get
        Set(value As DataRow)
            _Row_Inventario = value
        End Set
    End Property

    Public Sub New(_Id_Inventario As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Id_Inventario = _Id_Inventario

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Inv_Inventario Inv" & vbCrLf &
                       "Where Id_Inventario = " & _Id_Inventario
        _Row_Inventario = _Sql.Fx_Get_DataRow(Consulta_sql)

    End Sub

    Private Sub Frm_Control_Inventario_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Lbl_Nombre_Inventario.Text = _Row_Inventario.Item("Nombre_Inventario")

    End Sub


    Private Sub Btn_Operadores_Click(sender As Object, e As EventArgs) Handles Btn_Operadores.Click

        Dim Fm As New Frm_Operadores(_Id_Inventario)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Parejas_Click(sender As Object, e As EventArgs) Handles Btn_Parejas.Click

        Dim Fm As New Frm_Parejas(_Id_Inventario)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Sectores_Click(sender As Object, e As EventArgs) Handles Btn_Sectores.Click

        Dim Fm As New Zw_Inv_Sector(_Id_Inventario)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Plan_Click(sender As Object, e As EventArgs) Handles Btn_Plan.Click

        Dim Fm As New Frm_Plan(_Id_Inventario)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub
End Class
