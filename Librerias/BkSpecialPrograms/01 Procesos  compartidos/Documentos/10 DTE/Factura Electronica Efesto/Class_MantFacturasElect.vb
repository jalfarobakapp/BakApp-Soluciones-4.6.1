Public Class Class_MantFacturasElect

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Fecha_Desde As Date
    Public Property Fecha_Hasta As Date
    Public Property Tbl_Documentos As DataTable
    Public Property Tbl_Sucursales As DataTable
    Public Property Tbl_Responsables As DataTable
    Public Property Tbl_Entidades As DataTable
    Public Property Documentos_Todos As Boolean
    Public Property Sucursales_Todas As Boolean
    Public Property Responsables_Todos As Boolean
    Public Property Entidades_Todas As Boolean
    Public Property Aceptar As Boolean
    Public Property Idmaeedo As Integer
    Public Property Estado_Aceptado As Boolean
    Public Property Estado_AceptadoReparos As Boolean
    Public Property Estado_Rechazado As Boolean
    Public Property Estado_SinFirmar As Boolean
    Public Property Estado_ErrorEnvioCorreo As Boolean
    Public Sub New()

        _Documentos_Todos = True
        _Sucursales_Todas = True
        _Responsables_Todos = True
        _Entidades_Todas = True

    End Sub

End Class
