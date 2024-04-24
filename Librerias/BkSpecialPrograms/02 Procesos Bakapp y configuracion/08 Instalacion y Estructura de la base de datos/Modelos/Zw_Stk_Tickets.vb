Partial Public Class Zw_Stk_Tickets

    Public Property Id As Integer
    Public Property Id_Raiz As Integer
    Public Property Empresa As String
    Public Property Sucursal As String
    Public Property Numero As String
    Public Property SubNro As String
    Public Property Id_Area As Integer
    Public Property Id_Tipo As Integer
    Public Property Prioridad As String
    Public Property FechaCreacion As DateTime?
    Public Property CodFuncionario_Crea As String
    Public Property Asunto As String
    Public Property Descripcion As String
    Public Property Asignado As Boolean
    Public Property AsignadoGrupo As Boolean
    Public Property Id_Grupo As Integer
    Public Property AsignadoAgente As Boolean
    Public Property CodAgente As String
    Public Property Estado As String
    Public Property UltAccion As String
    Public Property CodFuncionario_Cierra As String
    Public Property FechaCierre As DateTime?
    Public Property Id_Padre As Integer
    Public Property Rechazado As Boolean
    Public Property Aceptado As Boolean

End Class

Partial Class Zw_Stk_Tickets
    Public Property New_Id_TicketAc As Integer
End Class
