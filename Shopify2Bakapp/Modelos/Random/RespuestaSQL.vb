Public Class RespuestaSQL

    ''' <summary>
    ''' IDMAEEDO: 893467
    ''' </summary>
    Public Property IDMAEEDO As Integer

    ''' <summary>
    ''' TIDO: NVV
    ''' </summary>
    Public Property TIDO As String

    ''' <summary>
    ''' NUDO: B2B8000090
    ''' </summary>
    Public Property NUDO As String

    ''' <summary>
    ''' ENDO: 14175774
    ''' </summary>
    Public Property ENDO As String

    ''' <summary>
    ''' SUENDO: (blank/spaces)
    ''' </summary>
    Public Property SUENDO As String

    ''' <summary>
    ''' NOKOEN: PABLO VALLADARES
    ''' </summary>
    Public Property NOKOEN As String

    ''' <summary>
    ''' EMPRESA: 01
    ''' </summary>
    Public Property EMPRESA As String

    ''' <summary>
    ''' SUDO: CM
    ''' </summary>
    Public Property SUDO As String

    ''' <summary>
    ''' OBDO: Dirección de envío: Los Maitenes Poniente...
    ''' </summary>
    Public Property OBDO As String

    ''' <summary>
    ''' CAPRCO: 3 (Cantidad/Precio)
    ''' </summary>
    Public Property CAPRCO As Decimal

    ''' <summary>
    ''' OCDO: 1107
    ''' </summary>
    Public Property OCDO As String

    ''' <summary>
    ''' PAEN = CODIGO PAIS
    ''' </summary>
    Public Property PAEN As String

    ''' <summary>
    ''' CIEN = CODIGO CIUDAD
    ''' </summary>
    Public Property CIEN As String

    ''' <summary>
    ''' CMEN = CODIGO COMUNA
    ''' </summary>
    Public Property CMEN As String

    ''' <summary>
    ''' TEXTO1: Pablo Valladares
    ''' </summary>
    Public Property TEXTO1 As String

    ''' <summary>
    ''' TEXTO2: 944960185
    ''' </summary>
    Public Property TEXTO2 As String

    ''' <summary>
    ''' TEXTO3: pvalladares@seagarden.cl
    ''' </summary>
    Public Property TEXTO3 As String

    Public Property Bodega As String

    Public Property CodFuncionario As String

    Public Property Valor As Integer

    ' --- Nuevos campos de validación de pagos ---

    ''' <summary>
    ''' IDMAEDPCE: ID del pago asociado en Random
    ''' </summary>
    Public Property IDMAEDPCE As Integer

    ''' <summary>
    ''' REFANTI: Referencia del pago anticipado (ej. código de Transbank o MercadoPago)
    ''' </summary>
    Public Property REFANTI As String

    ''' <summary>
    ''' VADP: Valor del abono o pago recibido
    ''' </summary>
    Public Property VADP As Decimal

    ''' <summary>
    ''' PagoSuficiente: 1 si el pago es mayor o igual al valor del documento, 0 si es menor
    ''' </summary>
    Public Property PagoSuficiente As Integer

End Class
