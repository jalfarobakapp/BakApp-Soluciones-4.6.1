Imports DevComponents.DotNetBar

Public Class Frm_WMS_Documento

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Cl_Documento_Wms As New Cl_Documento_Wms
    Public Property Cl_Documento_Wms As Cl_Documento_Wms
        Get
            Return _Cl_Documento_Wms
        End Get
        Set(value As Cl_Documento_Wms)
            _Cl_Documento_Wms = value
        End Set
    End Property

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_WMS_Documento_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

End Class
