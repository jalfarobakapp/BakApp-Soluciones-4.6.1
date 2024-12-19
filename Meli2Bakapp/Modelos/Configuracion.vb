Public Class Configuracion
    Public Property Ls_Conexiones As List(Of Conexion)
    Public Property Global_BaseBk As String
    Public Property BodegaFacturacion As BodegaFacturacion
    Public Property Vendedor As String
    Public Property NoVendedor As String
    Public Property Responsable As String
    Public Property NoResponsable As String
    Public Property RutaEtiquetas As String
    Public Property Facturar As Boolean
    Public Property DocEmitir As String
End Class

Public Class BodegaFacturacion
    Public Property Empresa As String
    Public Property Razon As String
    Public Property Kosu As String
    Public Property Nokosu As String
    Public Property Kobo As String
    Public Property Nokobo As String

End Class
