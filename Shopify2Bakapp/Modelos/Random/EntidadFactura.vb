Public Class EntidadFactura
    ' Propiedades que mapean las columnas del SQL
    Public Property KOEN As String
    Public Property SUEN As String
    Public Property NOKOEN As String
    Public Property KOFUEN As String
    Public Property ListaEntidad As String ' Mapea a LVEN
    Public Property NumeroFactura As String ' Mapea a Numero_Factura (NUDO)
    Public Property FechaUltimaFactura As DateTime? ' Nullable por si no hay factura (aunque usas WHERE P.KOLTPR)
    Public Property ListaKOLTPR As String ' Mapea a Lista_KOLTPR
    Public Property Clasificacion As String

    ' Constructor vacío
    Public Sub New()
    End Sub

    ' Constructor opcional para facilitar la carga manual
    Public Sub New(koen As String, suen As String, nokoen As String, kofuen As String,
                   listaEntidad As String, numeroFactura As String, fecha As DateTime?,
                   listaKoltpr As String, clasificacion As String)
        Me.KOEN = koen
        Me.SUEN = suen
        Me.NOKOEN = nokoen
        Me.KOFUEN = kofuen
        Me.ListaEntidad = listaEntidad
        Me.NumeroFactura = numeroFactura
        Me.FechaUltimaFactura = fecha
        Me.ListaKOLTPR = listaKoltpr
        Me.Clasificacion = clasificacion
    End Sub
End Class
