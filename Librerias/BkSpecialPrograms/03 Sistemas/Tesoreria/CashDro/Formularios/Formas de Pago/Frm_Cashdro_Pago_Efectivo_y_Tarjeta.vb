Public Class Frm_Cashdro_Pago_Efectivo_y_Tarjeta

    Dim _Monto As Double
    Dim _Aceptar As Boolean

    Dim _Valor_a_pagar As Double

    Public Property Pro_Monto As Double
        Get
            Return _Monto
        End Get
        Set(value As Double)
            _Monto = value
        End Set
    End Property

    Public Property Pro_Aceptar As Boolean
        Get
            Return _Aceptar
        End Get
        Set(value As Boolean)
            _Aceptar = value
        End Set
    End Property

    Public Sub New(Valor_a_pagar As Double)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Valor_a_pagar = Valor_a_pagar
        '_Valor_Maximo = _Valor_a_pagar
        Tiempo_Pago_Efectivo.Interval = 1000 * (60 * 2)
    End Sub

    Private Sub Frm_Cashdro_Pago_Efectivo_y_Tarjeta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _Monto = 1000
        Txt_Monto.Text = FormatNumber(_Monto, 0)
        Txt_Monto.Tag = _Monto

        Lbl_Valor_Venta.Text = "<b><font size = ""34"" color=""#349FCE"">VALOR VENTA: " & FormatCurrency(_Valor_a_pagar, 0) & "</font></b>  "
        Sb_Saldo_Tarjeta()
        Me.ActiveControl = Btn_Aceptar
    End Sub

    Private Sub Btn_Aceptar_Click(sender As Object, e As EventArgs) Handles Btn_Aceptar.Click
        _Aceptar = True
        Me.Close()
    End Sub

    Private Sub Btn_Sumar_Click(sender As Object, e As EventArgs) Handles Btn_Sumar.Click
        Dim _Suma As Double = Txt_Monto.Tag + 1000
        If _Suma < _Valor_a_pagar Then
            _Monto = _Suma
            Txt_Monto.Text = FormatNumber(_Monto, 0)
            Txt_Monto.Tag = _Monto
            Sb_Saldo_Tarjeta()
        End If
    End Sub

    Private Sub Btn_Restar_Click(sender As Object, e As EventArgs) Handles Btn_Restar.Click
        Dim _Resta As Double = Txt_Monto.Tag - 1000
        If _Resta >= 1000 Then
            _Monto = _Resta
            Txt_Monto.Text = FormatNumber(_Monto, 0)
            Txt_Monto.Tag = _Monto
            Sb_Saldo_Tarjeta()
        End If
    End Sub

    Sub Sb_Saldo_Tarjeta()

        Dim _Saldo As Double = _Valor_a_pagar - Txt_Monto.Tag

        Dim _Saldo_Tjv As String = "<b><font size = ""16"" color=""#349FCE"">Total saldo a pagar con tarjeta " & FormatCurrency(_Saldo, 0) & "</font></b>"
        Lbl_Saldo_Tarjeta.Text = _Saldo_Tjv

    End Sub

    Private Sub Tiempo_Pago_Efectivo_Tick(sender As Object, e As EventArgs) Handles Tiempo_Pago_Efectivo.Tick
        Me.Close()
    End Sub

    Private Sub Btn_Cancelar_Click(sender As Object, e As EventArgs) Handles Btn_Cancelar.Click
        Me.Close()
    End Sub
End Class