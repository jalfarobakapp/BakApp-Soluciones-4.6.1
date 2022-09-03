Imports DevComponents.DotNetBar

Public Class Frm_Formulario_Iva_Ila

    Dim _Valor_Ila As Double
    Dim _Valor_Iva As Double
    Dim _Valor_Neto As Double
    Dim _Valor_Bruto As Double
    Dim _Aceptar As Boolean

    Dim _Porc_Iva As Double
    Dim _Porc_Ila As Double

    Enum Enum_Tipo_Impuesto
        Iva
        Impuesto
    End Enum

    Dim _Tipo_Impuesto As Enum_Tipo_Impuesto

    Public Property Porc_Iva As Double
        Get
            Return _Porc_Iva
        End Get
        Set(value As Double)
            _Porc_Iva = value
        End Set
    End Property

    Public Property Aceptar As Boolean
        Get
            Return _Aceptar
        End Get
        Set(value As Boolean)
            _Aceptar = value
        End Set
    End Property

    Public Property Valor_Iva As Double
        Get
            Return _Valor_Iva
        End Get
        Set(value As Double)
            _Valor_Iva = value
        End Set
    End Property

    Public Property Valor_Ila As Double
        Get
            Return _Valor_Ila
        End Get
        Set(value As Double)
            _Valor_Ila = value
        End Set
    End Property

    Public Sub New(Tipo_Impuesto As Enum_Tipo_Impuesto,
                   Valor_Iva As Double,
                   Valor_Ila As Double,
                   Valor_Neto As Double,
                   Valor_Bruto As Double)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Valor_Neto = Valor_Neto
        _Valor_Ila = Valor_Ila
        _Valor_Iva = Valor_Iva
        _Valor_Bruto = Valor_Bruto

        Me.Text = "Cambiar valor " & Tipo_Impuesto.ToString
        Lbl_Etiqueta.Text = "Nuevo valor " & Tipo_Impuesto.ToString

        Select Case _Tipo_Impuesto

            Case Enum_Tipo_Impuesto.Iva
                Txt_Valor.Tag = _Valor_Iva
            Case Enum_Tipo_Impuesto.Impuesto
                Txt_Valor.Tag = _Valor_Ila
        End Select

        Txt_Valor.Text = FormatCurrency(Txt_Valor.Tag)

    End Sub

    Private Sub Frm_Formulario_Iva_Ila_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.ActiveControl = Txt_Valor

    End Sub

    Private Sub Btn_Aceptar_Click(sender As Object, e As EventArgs) Handles Btn_Aceptar.Click

        Select Case _Tipo_Impuesto

            Case Enum_Tipo_Impuesto.Iva
                _Valor_Iva = Txt_Valor.Tag
                _Valor_Bruto = _Valor_Neto + _Valor_Iva + _Valor_Ila
                _Porc_Iva = Math.Round(((_Valor_Bruto / (_Valor_Neto + _Valor_Ila)) - 1) * 100, 5)
            Case Enum_Tipo_Impuesto.Impuesto
                _Valor_Ila = Txt_Valor.Tag
                _Valor_Bruto = _Valor_Neto + _Valor_Iva + _Valor_Ila
                _Porc_Ila = Math.Round(((_Valor_Bruto / (_Valor_Neto + _Valor_Iva)) - 1) * 100, 5)
        End Select

        _Aceptar = True
        Me.Close()

    End Sub

    Private Sub Txt_Valor_Validated(sender As Object, e As EventArgs) Handles Txt_Valor.Validated
        Txt_Valor.Tag = De_Txt_a_Num_01(Txt_Valor.Text, 3)
        Txt_Valor.Text = FormatCurrency(Txt_Valor.Tag)
    End Sub

    Private Sub Txt_Valor_Enter(sender As Object, e As EventArgs) Handles Txt_Valor.Enter
        Txt_Valor.Text = Txt_Valor.Tag
    End Sub

    Private Sub Txt_Valor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Valor.KeyPress

        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii, False))
        If KeyAscii = 0 Then
            e.Handled = True
        End If

        ' Si se pulsa la tecla Intro, pasar al siguiente
        If e.KeyChar = Convert.ToChar(Keys.Return) Then

            e.Handled = True
            Btn_Aceptar.Focus()

        ElseIf e.KeyChar = ","c Then
            ' si se pulsa la coma se convertirá en punto
            e.Handled = True
            SendKeys.Send(".")
        End If

    End Sub

    Private Sub Frm_Formulario_Iva_Ila_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

End Class