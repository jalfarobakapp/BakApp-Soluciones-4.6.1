Public Class Frm_GRI_Ingreso
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_GRI_Ingreso_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Btn_Ingresar_GRI_Click(sender As Object, e As EventArgs) Handles Btn_Ingresar_GRI.Click

        Dim Fm As New Frm_GRI_FabXProducto
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

End Class
