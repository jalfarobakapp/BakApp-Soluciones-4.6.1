Public Class Zw_Stk_Tickets_Acciones
    Public Property Id As Integer
    Public Property Id_Ticket As Integer
    Public Property Accion As String
    Public Property Descripcion As String
    Public Property Fecha As DateTime?
    Public Property CodFuncionario As String
    Public Property CodAgente As String
    Public Property En_Construccion As Boolean
    Public Property Visto As Boolean
    Public Property Cierra_Ticket As Boolean
    Public Property Solicita_Cierre As Boolean
    Public Property CreaNewTicket As Boolean
    Public Property AnulaTicket As Boolean
    Public Property CodFunGestiona As String
    Public Property Rechazado As Boolean
    Public Property Aceptado As Boolean
    Public Property Id_Raiz As Integer
    Public Property Id_Ticket_Cierra As Integer
    Public Property Id_Ticket_Crea As Integer
    Public Property Asunto As String
End Class
