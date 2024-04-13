Partial Public Class Zw_Stk_Tipos
    Public Property Id As Integer
    Public Property Id_Area As Integer
    Public Property Tipo As String
    Public Property ExigeProducto As Boolean
    Public Property Asignado As Boolean
    Public Property AsignadoGrupo As Boolean
    Public Property AsignadoAgente As Boolean
    Public Property Id_Grupo As Integer
    Public Property CodAgente As String
    Public Property CieTk_Id_Area As Integer
    Public Property CieTk_Id_Tipo As Integer
    Public Property Inc_Cantidades As Boolean
    Public Property Inc_Fecha As Boolean
    Public Property Inc_Hora As Boolean
    Public Property RevInventario As Boolean
    Public Property AjusInventario As Boolean
    Public Property SobreStock As Boolean
    Public Property BodModalXDefecto As Boolean
    Public Property PreguntaCreaNewTicket As Boolean
    Public Property CerrarAgenteSinPerm As Boolean
    Public Property RespuestaXDefecto As String
End Class

Partial Public Class Zw_Stk_Tipos
    Public Property Grupo As String
    Public Property Agente As String
End Class
