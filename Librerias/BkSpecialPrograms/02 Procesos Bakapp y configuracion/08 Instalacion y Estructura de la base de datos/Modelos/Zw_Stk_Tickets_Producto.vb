Public Class Zw_Stk_Tickets_Producto
    Public Property Id As Integer
    Public Property Id_Ticket As Integer
    Public Property Id_Raiz As Integer
    Public Property Numero As String
    Public Property Empresa As String
    Public Property Sucursal As String
    Public Property Bodega As String
    Public Property Codigo As String
    Public Property Descripcion As String
    Public Property Rtu As Double
    Public Property UdMedida As Integer
    Public Property Ud1 As String
    Public Property Ud2 As String
    Public Property Um As String
    Public Property StfiEnBodega As Double
    Public Property Cantidad As Double
    Public Property Diferencia As Double
    Public Property FechaRev As DateTime?
    Public Property Stfi1 As Double
    Public Property Stfi2 As Double
    Public Property RevInventario As Boolean
    Public Property AjusInventario As Boolean
    Public Property SobreStock As Boolean
    Public Property Ubicacion As String
    Public Property Id_TicketAc As Integer
    Public Property Id_Padre As Integer
    Public Property ConfCantCero As Boolean


    Public Sub New()
        Me.Id = 0
        Me.Id_Ticket = 0
        Me.Id_Raiz = 0
        Me.Numero = String.Empty
        Me.Empresa = String.Empty
        Me.Sucursal = String.Empty
        Me.Bodega = String.Empty
        Me.Descripcion_Bodega = String.Empty
        Me.Codigo = String.Empty
        Me.Descripcion = String.Empty
        Me.Rtu = 0
        Me.UdMedida = 1
        Me.Ud1 = String.Empty
        Me.Ud2 = String.Empty
        Me.Um = String.Empty
        Me.StfiEnBodega = 0
        Me.Cantidad = 0
        Me.Diferencia = 0
        'Me.FechaRev = FechaRev
        Me.Stfi1 = 0
        Me.Stfi2 = 0
        Me.RevInventario = False
        Me.AjusInventario = False
        Me.SobreStock = False
        Me.Ubicacion = String.Empty
        Me.Id_TicketAc = 0
        Me.Id_Padre = 0
        Me.ConfCantCero = False
    End Sub

End Class

Partial Public Class Zw_Stk_Tickets_Producto
    Public Property Descripcion_Bodega As String

End Class
