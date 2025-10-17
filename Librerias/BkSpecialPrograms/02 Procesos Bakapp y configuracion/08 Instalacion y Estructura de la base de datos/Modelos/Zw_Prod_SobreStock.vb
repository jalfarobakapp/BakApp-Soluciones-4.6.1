Public Class Zw_Prod_SobreStock
    Public Property Id As Integer
    Public Property Empresa As String
    Public Property Sucursal As String
    Public Property Bodega As String
    Public Property Codigo As String
    Public Property Descripcion As String
    Public Property Activo As Boolean
    Public Property CodFuncionarioCrea As String
    Public Property FechaVigencia As DateTime?
    Public Property FormatoPqte As String
    Public Property PqteHabilitado As Double
    Public Property PqteComprometido As Double
    Public Property Ud1XPqte As Double
    Public Property CantMinFormato As Double
    Public Property Moneda As String
    Public Property PrecioXUd1 As Double
    Public Property StSobStockUd1 As Double
    Public Property StSobStockUd2 As Double
    Public Property StSbCompStock1 As Double
    Public Property StSbCompStock2 As Double

    ' Nuevo campo adicional
    Public Property IdIndex As Integer
    Public Property Cantidad As Double
    'Public Property Descripcion As String
    Public Property StDispUd1 As Double
    Public Property PqteDisponible As Double
End Class
