Public Class Zw_PreVenta_StockProd
    Public Property Id As Integer
    Public Property Empresa As String
    Public Property Sucursal As String
    Public Property Bodega As String
    Public Property IdCont As Integer
    Public Property Contenedor As String
    Public Property Codigo As String
    Public Property StcfiUd1 As Double
    Public Property StcfiUd2 As Double
    Public Property StcCompUd1 As Double
    Public Property StcCompUd2 As Double
    Public Property StcfiDisponibleUd1 As Double
    Public Property StcfiDisponibleUd2 As Double
    Public Property FormatoPqte As String
    Public Property PqteHabilitado As Double
    Public Property PqteComprometido As Double
    Public Property Ud1XPqte As Double
    Public Property CantMinFormato As Integer
    Public Property Moneda As String
    Public Property PrecioXUd1 As Double

    ' Nuevo campo adicional
    Public Property IdIndex As Integer
    Public Property Cantidad As Double
    Public Property Descripcion As String
    Public Property StDispUd1 As Double
    Public Property PqteDisponible As Double
End Class

