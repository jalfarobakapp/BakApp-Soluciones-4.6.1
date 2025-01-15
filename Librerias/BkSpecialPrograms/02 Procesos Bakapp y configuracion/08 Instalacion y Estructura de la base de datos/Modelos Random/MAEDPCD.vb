Public Class MAEDPCD
    Public Property IDMAEDPCD As Integer
    Public Property IDMAEDPCE As Integer
    Public Property VAASDP As Double
    Public Property FEASDP As DateTime?
    Public Property TIDOPA As String
    Public Property ARCHIRST As String
    Public Property IDRST As Integer
    Public Property TCASIG As Double
    Public Property REFERENCIA As Double
    Public Property KOFUASDP As String
    Public Property SUASDP As String
    Public Property CJASDP As String
    Public Property HORAGRAB As Integer
    Public Property LAHORA As DateTime?

    Public Sub New()
        IDMAEDPCD = 0
        IDMAEDPCE = 0
        VAASDP = 0
        FEASDP = Nothing
        TIDOPA = String.Empty
        ARCHIRST = String.Empty
        IDRST = 0
        TCASIG = 0
        REFERENCIA = 0
        KOFUASDP = String.Empty
        SUASDP = String.Empty
        CJASDP = String.Empty
        HORAGRAB = 0
        LAHORA = Nothing
    End Sub
End Class
