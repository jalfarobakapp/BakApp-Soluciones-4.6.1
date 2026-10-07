Public Class Zw_InterStock_Det

    Public Property Id_Enc As Integer
    Public Property Id_Det As Integer
    Public Property Idmaeedo As Integer
    Public Property Idmaeddo As Integer
    Public Property Tido As String
    Public Property Nudo As String
    Public Property Endo As String
    Public Property Suendo As String
    Public Property Empresa As String
    Public Property Sucursal As String
    Public Property Bodega As String
    Public Property Codigo As String
    Public Property Caprco1 As Double
    Public Property Caprco2 As Double
    Public Property Stockinicialud1 As Double
    Public Property Stockinicialud2 As Double
    Public Property Stockantesud1 As Double
    Public Property Stockantesud2 As Double
    Public Property Stockdespuesud1 As Double
    Public Property Stockdespuesud2 As Double
    Public Property Ud1_negativo As Boolean
    Public Property Ud2_negativo As Boolean
    Public Property Comprarud1 As Double
    Public Property Comprarud2 As Double
    Public Property CodLista As String
    Public Property Costo As Double
    Public Property Empresa_OCC As String
    Public Property Sucursal_OCC As String
    Public Property Bodega_OCC As String
    Public Property Idmaeedo_OCC As Integer
    Public Property Idmaeddo_OCC As Integer
    Public Property Tido_OCC As String
    Public Property Nudo_OCC As String
    Public Property Empresa_NVV As String
    Public Property Sucursal_NVV As String
    Public Property Bodega_NVV As String
    Public Property Idmaeedo_NVV As Integer
    Public Property Idmaeddo_NVV As Integer
    Public Property Tido_NVV As String
    Public Property Nudo_NVV As String
    Public Property Empresa_FCV As String
    Public Property Idmaeedo_FCV As Integer
    Public Property Idmaeddo_FCV As Integer
    Public Property Tido_FCV As String
    Public Property Nudo_FCV As String
    Public Property Empresa_FCC As String
    Public Property Idmaeedo_FCC As Integer
    Public Property Idmaeddo_FCC As Integer
    Public Property Tido_FCC As String
    Public Property Nudo_FCC As String

    ' Constructor vacío estándar
    Public Sub New()
    End Sub

    ' Constructor a partir de un DataRow
    Public Sub New(row As DataRow)
        If row IsNot Nothing Then
            If Not IsDBNull(row("Id_Enc")) Then Me.Id_Enc = Convert.ToInt32(row("Id_Enc"))
            If Not IsDBNull(row("Id_Det")) Then Me.Id_Det = Convert.ToInt32(row("Id_Det"))
            If Not IsDBNull(row("Idmaeedo")) Then Me.Idmaeedo = Convert.ToInt32(row("Idmaeedo"))
            If Not IsDBNull(row("Idmaeddo")) Then Me.Idmaeddo = Convert.ToInt32(row("Idmaeddo"))
            If Not IsDBNull(row("Tido")) Then Me.Tido = row("Tido").ToString()
            If Not IsDBNull(row("Nudo")) Then Me.Nudo = row("Nudo").ToString()
            If Not IsDBNull(row("Endo")) Then Me.Endo = row("Endo").ToString()
            If Not IsDBNull(row("Suendo")) Then Me.Suendo = row("Suendo").ToString()
            If Not IsDBNull(row("Empresa")) Then Me.Empresa = row("Empresa").ToString()
            If Not IsDBNull(row("Sucursal")) Then Me.Sucursal = row("Sucursal").ToString()
            If Not IsDBNull(row("Bodega")) Then Me.Bodega = row("Bodega").ToString()
            If Not IsDBNull(row("Codigo")) Then Me.Codigo = row("Codigo").ToString()
            If Not IsDBNull(row("Caprco1")) Then Me.Caprco1 = Convert.ToDouble(row("Caprco1"))
            If Not IsDBNull(row("Caprco2")) Then Me.Caprco2 = Convert.ToDouble(row("Caprco2"))
            If Not IsDBNull(row("Stockinicialud1")) Then Me.Stockinicialud1 = Convert.ToDouble(row("Stockinicialud1"))
            If Not IsDBNull(row("Stockinicialud2")) Then Me.Stockinicialud2 = Convert.ToDouble(row("Stockinicialud2"))
            If Not IsDBNull(row("Stockantesud1")) Then Me.Stockantesud1 = Convert.ToDouble(row("Stockantesud1"))
            If Not IsDBNull(row("Stockantesud2")) Then Me.Stockantesud2 = Convert.ToDouble(row("Stockantesud2"))
            If Not IsDBNull(row("Stockdespuesud1")) Then Me.Stockdespuesud1 = Convert.ToDouble(row("Stockdespuesud1"))
            If Not IsDBNull(row("Stockdespuesud2")) Then Me.Stockdespuesud2 = Convert.ToDouble(row("Stockdespuesud2"))
            If Not IsDBNull(row("Ud1_negativo")) Then Me.Ud1_negativo = Convert.ToBoolean(row("Ud1_negativo"))
            If Not IsDBNull(row("Ud2_negativo")) Then Me.Ud2_negativo = Convert.ToBoolean(row("Ud2_negativo"))
            If Not IsDBNull(row("Comprarud1")) Then Me.Comprarud1 = Convert.ToDouble(row("Comprarud1"))
            If Not IsDBNull(row("Comprarud2")) Then Me.Comprarud2 = Convert.ToDouble(row("Comprarud2"))
            If Not IsDBNull(row("CodLista")) Then Me.CodLista = row("CodLista").ToString()
            If Not IsDBNull(row("Costo")) Then Me.Costo = Convert.ToDouble(row("Costo"))
            If Not IsDBNull(row("Empresa_OCC")) Then Me.Empresa_OCC = row("Empresa_OCC").ToString()
            If Not IsDBNull(row("Sucursal_OCC")) Then Me.Sucursal_OCC = row("Sucursal_OCC").ToString()
            If Not IsDBNull(row("Bodega_OCC")) Then Me.Bodega_OCC = row("Bodega_OCC").ToString()
            If Not IsDBNull(row("Idmaeedo_OCC")) Then Me.Idmaeedo_OCC = Convert.ToInt32(row("Idmaeedo_OCC"))
            If Not IsDBNull(row("Idmaeddo_OCC")) Then Me.Idmaeddo_OCC = Convert.ToInt32(row("Idmaeddo_OCC"))
            If Not IsDBNull(row("Tido_OCC")) Then Me.Tido_OCC = row("Tido_OCC").ToString()
            If Not IsDBNull(row("Nudo_OCC")) Then Me.Nudo_OCC = row("Nudo_OCC").ToString()
            If Not IsDBNull(row("Empresa_NVV")) Then Me.Empresa_NVV = row("Empresa_NVV").ToString()
            If Not IsDBNull(row("Sucursal_NVV")) Then Me.Sucursal_NVV = row("Sucursal_NVV").ToString()
            If Not IsDBNull(row("Bodega_NVV")) Then Me.Bodega_NVV = row("Bodega_NVV").ToString()
            If Not IsDBNull(row("Idmaeedo_NVV")) Then Me.Idmaeedo_NVV = Convert.ToInt32(row("Idmaeedo_NVV"))
            If Not IsDBNull(row("Idmaeddo_NVV")) Then Me.Idmaeddo_NVV = Convert.ToInt32(row("Idmaeddo_NVV"))
            If Not IsDBNull(row("Tido_NVV")) Then Me.Tido_NVV = row("Tido_NVV").ToString()
            If Not IsDBNull(row("Nudo_NVV")) Then Me.Nudo_NVV = row("Nudo_NVV").ToString()
            If Not IsDBNull(row("Empresa_FCV")) Then Me.Empresa_FCV = row("Empresa_FCV").ToString()
            If Not IsDBNull(row("Idmaeedo_FCV")) Then Me.Idmaeedo_FCV = Convert.ToInt32(row("Idmaeedo_FCV"))
            If Not IsDBNull(row("Idmaeddo_FCV")) Then Me.Idmaeddo_FCV = Convert.ToInt32(row("Idmaeddo_FCV"))
            If Not IsDBNull(row("Tido_FCV")) Then Me.Tido_FCV = row("Tido_FCV").ToString()
            If Not IsDBNull(row("Nudo_FCV")) Then Me.Nudo_FCV = row("Nudo_FCV").ToString()
            If Not IsDBNull(row("Empresa_FCC")) Then Me.Empresa_FCC = row("Empresa_FCC").ToString()
            If Not IsDBNull(row("Idmaeedo_FCC")) Then Me.Idmaeedo_FCC = Convert.ToInt32(row("Idmaeedo_FCC"))
            If Not IsDBNull(row("Idmaeddo_FCC")) Then Me.Idmaeddo_FCC = Convert.ToInt32(row("Idmaeddo_FCC"))
            If Not IsDBNull(row("Tido_FCC")) Then Me.Tido_FCC = row("Tido_FCC").ToString()
            If Not IsDBNull(row("Nudo_FCC")) Then Me.Nudo_FCC = row("Nudo_FCC").ToString()
        End If
    End Sub

End Class
