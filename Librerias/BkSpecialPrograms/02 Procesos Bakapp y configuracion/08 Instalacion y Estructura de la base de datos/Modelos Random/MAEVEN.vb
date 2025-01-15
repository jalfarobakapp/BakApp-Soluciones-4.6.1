Public Class MAEVEN
    Public Property IDMAEVEN As Integer
    Public Property IDMAEEDO As Integer
    Public Property FEVE As DateTime?
    Public Property ESPGVE As String
    Public Property VAVE As Double
    Public Property VAABVE As Double
    Public Property ARCHIRST As String
    Public Property PORESTPAG As Double
    Public Property OBSERVA As String

    Public Sub New()
        IDMAEVEN = 0
        IDMAEEDO = 0
        FEVE = Nothing
        ESPGVE = String.Empty
        VAVE = 0
        VAABVE = 0
        ARCHIRST = String.Empty
        PORESTPAG = 0
        OBSERVA = String.Empty
    End Sub
End Class
