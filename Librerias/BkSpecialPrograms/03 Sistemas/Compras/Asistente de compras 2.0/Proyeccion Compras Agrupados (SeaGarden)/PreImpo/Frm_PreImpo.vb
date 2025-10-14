Public Class Frm_PreImpo

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _TablaDePaso As String

    Public Sub New(_TablaDePaso As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._TablaDePaso = _TablaDePaso

    End Sub

    Private Sub Frm_PreImpo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
