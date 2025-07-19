Public Class Zw_Contenedor
    Public Property IdCont As Integer
    Public Property Empresa As String
    Public Property Contenedor As String
    Public Property NombreContenedor As String
    Public Property Tido_Rela As String
    Public Property Nudo_Rela As String
    Public Property Idmaeedo_Rela As Integer
    Public Property Estado As String

    Public Sub New()
        IdCont = 0
        Empresa = Mod_Empresa
        Contenedor = String.Empty
        NombreContenedor = String.Empty
        Tido_Rela = String.Empty
        Nudo_Rela = String.Empty
        Idmaeedo_Rela = 0
        Estado = String.Empty
    End Sub

End Class
