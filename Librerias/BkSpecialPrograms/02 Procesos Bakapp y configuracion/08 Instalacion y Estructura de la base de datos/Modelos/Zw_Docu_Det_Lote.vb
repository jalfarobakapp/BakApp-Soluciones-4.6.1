Public Class Zw_Docu_Det_Lote

    Public Property Id As Integer
    Public Property Id_Det As Integer
    Public Property Idmaeddo As Integer
    Public Property Idmaeedo As Integer
    Public Property Tido As String
    Public Property Nudo As String
    Public Property Codigo As String
    Public Property Descripcion As String
    Public Property NroLote As String
    Public Property SubLote As String
    Public Property FElaboracion As DateTime?
    Public Property FVencimiento As DateTime?
    Public Property CantUd1 As Double
    Public Property CantUd2 As Double

    Public Sub New()

        Id = 0
        Id_Det = 0
        Idmaeddo = 0
        Idmaeedo = 0
        Tido = String.Empty
        Nudo = String.Empty
        Codigo = String.Empty
        Descripcion = String.Empty
        NroLote = String.Empty
        SubLote = String.Empty
        FElaboracion = Nothing
        FVencimiento = Nothing
        CantUd1 = 0
        CantUd2 = 0

    End Sub

End Class
