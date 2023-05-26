Public Class Frm_Demonio_ConfAsisCompra

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Id As Integer
    Dim _Row_Configuracion As DataRow
    Dim _Row_Programacion As DataRow

    Public Property Id As Integer
        Get
            Return _Id
        End Get
        Set(value As Integer)
            _Id = value
        End Set
    End Property

    Public Sub New(_Id As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Id = _Id

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Demonio_ConfAsisCompra Where Id = " & _Id
        _Row_Configuracion = _Sql.Fx_Get_DataRow(Consulta_sql)

    End Sub

    Private Sub Frm_Demonio_ConfAsisCompra_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not IsNothing(_Row_Configuracion) Then
            Txt_Modalidad.Text = _Row_Configuracion.Item("Modalidad")
            Cmb_Tido.SelectedValue = _Row_Configuracion.Item("Tido")
        End If

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

    End Sub

    Private Sub Btn_ConfProgramacion_Click(sender As Object, e As EventArgs) Handles Btn_ConfProgramacion.Click

    End Sub


End Class
