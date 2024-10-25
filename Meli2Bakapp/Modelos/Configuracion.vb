Public Class Configuracion
    Public Property Ls_Conexiones As List(Of Conexion)
    Public Property Global_BaseBk As String
    Public Property BodegaFacturacion As BodegaFacturacion
End Class

Public Class BodegaFacturacion
    Public Property Empresa As String
    Public Property Razon As String
    Public Property Kosu As String
    Public Property Nokosu As String
    Public Property Kobo As String
    Public Property Nokobo As String

End Class
