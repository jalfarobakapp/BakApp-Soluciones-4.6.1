Public Class Frm_Cms_Periodos_Crear

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Public Property Id As Integer
    Public Property Row_Periodo As DataRow

    Public Sub New(_Id As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        If CBool(_Id) Then

            Consulta_Sql = "Select * From Zw_Comisiones_Enc Where Id = " & _Id
            _Row_Periodo = _Sql.Fx_Get_DataRow(Consulta_Sql)

        End If

    End Sub

    Private Sub Frm_Cms_Periodos_Crear_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not IsNothing(_Row_Periodo) Then

            Txt_Nombre.Text = _Row_Periodo.Item("Nombre")
            Cmb_Ano.SelectedValue = _Row_Periodo.Item("Ano")
            Cmb_Mes.SelectedValue = _Row_Periodo.Item("Mes")

        End If

    End Sub

End Class
