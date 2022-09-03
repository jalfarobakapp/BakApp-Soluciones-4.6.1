Imports DevComponents.DotNetBar


Public Class Frm_Sobregiro_Exposicion

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

    Dim _Fecha As Date
    Dim _Dolar As Double

    Dim _Var_Monto_Venta_Civa As Double
    Dim _Var_Linea_Credito_Int_Ac_Peso As Double
    Dim _Var_Deuda_Actual As Double
    Dim _Var_Valor_UF As Double

    Dim _Deuda_Actual As Double
    Dim _Monto_Venta_Civa As Double
    Dim _Porc_Exposicion As Double


    Public Sub New(ByVal Fecha As Date, _
                   ByVal Var_Monto_Venta_Civa As Double, _
                   ByVal Var_Linea_Credito_Int_Ac_Peso As Double, _
                   ByVal Var_Deuda_Actual As Double, _
                   ByVal Var_Valor_UF As Double, _
                   ByVal Deuda_Actual As Double, _
                   ByVal Monto_Venta_Civa As Double, _
                   ByVal Porc_Exposicion As Double, _
                   ByVal Dolar As Double, _
                   ByVal Clasificacion As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Fecha = Fecha
        _Var_Deuda_Actual = Var_Deuda_Actual
        _Var_Linea_Credito_Int_Ac_Peso = Var_Linea_Credito_Int_Ac_Peso
        _Var_Monto_Venta_Civa = Var_Monto_Venta_Civa
        _Var_Valor_UF = Var_Valor_UF

        _Deuda_Actual = Deuda_Actual
        _Monto_Venta_Civa = Monto_Venta_Civa
        _Porc_Exposicion = Porc_Exposicion

        _Dolar = Dolar

        Me.Text = "INFORMACIÓN ADICIONAL (" & Clasificacion & ")"

    End Sub

    Private Sub Frm_Sobregiro_Exposicion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim _Sobregiro As Boolean

        '_Dolar = _Sql.Fx_Trae_Dato("MAEMO", "VAMO", "KOMO = 'US$' AND FEMO = '" & Format(_Fecha, "yyyyMMdd") & "'", True)

        Dim _Solicitado_Peso As Double = _Var_Monto_Venta_Civa ' Fx_Convert_UF2Peso(Var_Linea_Credito_SC_Ac_UF, Var_Valor_UF, False)
        Dim _Saldo_Linea_Peso As Double = _Var_Linea_Credito_Int_Ac_Peso - _Var_Deuda_Actual
        _Saldo_Linea_Peso = _Solicitado_Peso - _Saldo_Linea_Peso 'Var_Linea_Credito_Int_Ac_Peso - (Var_Deuda_Actual + _Solicitado_Peso)
        Dim _Saldo_Linea_Uf As Double = _Saldo_Linea_Peso / _Var_Valor_UF
        Dim _Saldo_Linea_Dolar As Double = _Saldo_Linea_Peso / _Dolar

        Lbl_Valor_Dolar.Text = "Valor dolar " & FormatCurrency(_Dolar)

        If _Saldo_Linea_Peso > 0 Then
            Lbl_Sobregiro.Text = "VENTA CON SOBREGIRO"
            Reflex_Img_Sobregiro.Image = Imagenes.Images.Item("secure_err.png")
            _Sobregiro = True

            Lbl_Saldo_Linea_Peso.ForeColor = Color.Red
            Lbl_Saldo_Linea_Uf.ForeColor = Color.Red
            Lbl_Saldo_Linea_Dolar.ForeColor = Color.Red
            'Var_Linea_Credito_Int_Ac_Peso

        ElseIf _Saldo_Linea_Peso < 0 Then
            Reflex_Img_Sobregiro.Image = Imagenes.Images.Item("secure_ok.png")
            Lbl_Sobregiro.Text = "NO HAY SOBREGIRO"
        End If

        If _Saldo_Linea_Peso = 0 Then
            Lbl_Sobregiro.Text = String.Empty
            Reflex_Img_Sobregiro.Image = Imagenes.Images.Item("secure-info.png")
        End If

        Lbl_Saldo_Linea_Peso.Text = FormatNumber(_Saldo_Linea_Peso, 0)
        Lbl_Saldo_Linea_Uf.Text = FormatNumber(_Saldo_Linea_Uf, 0)
        Lbl_Saldo_Linea_Dolar.Text = FormatNumber(_Saldo_Linea_Dolar, 0)

        Dim _Decimal = 0

        If Str(_Porc_Exposicion).Contains(".") Then
            Dim _Arr = Split(Str(_Porc_Exposicion), ".")
            If _Arr.Length = 2 Then
                If _Arr(1) > 0 Then
                    _Decimal = 2
                End If
            End If
        End If

        _Porc_Exposicion = _Porc_Exposicion / 100

        Lbl_Porc_Exposicion.Text = FormatPercent(_Porc_Exposicion, _Decimal)

        Dim _Exposicion, _Exposicion_Dolar As Double


        If _Sobregiro Then

            _Exposicion = _Var_Linea_Credito_Int_Ac_Peso * _Porc_Exposicion

            Lbl_Valor_Exposicion_01.Text = FormatCurrency(_Saldo_Linea_Peso, 0)
            Lbl_Valor_Exposicion_02.Text = FormatCurrency(_Exposicion, 0)
            Lbl_Exposicion_01.Text = "Sobregiro"
            Lbl_Exposicion_02.Text = "Sin seguro " & Lbl_Porc_Exposicion.Text
            Lbl_Porc_Exposicion.Visible = False
            LabelX7.Visible = False
            _Exposicion += _Saldo_Linea_Peso

        Else

            Lbl_Valor_Exposicion_01.Text = FormatCurrency(_Deuda_Actual, 0)
            Lbl_Valor_Exposicion_02.Text = FormatCurrency(_Monto_Venta_Civa, 0)

            _Exposicion = (_Deuda_Actual + _Monto_Venta_Civa) * _Porc_Exposicion
        End If

        _Exposicion_Dolar = _Exposicion / _Dolar

        Lbl_Exposicion.Text = FormatCurrency(_Exposicion, 0)
        Lbl_Exposicion_Dolar.Text = "US$ " & FormatNumber(_Exposicion_Dolar, 0)


    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub Frm_Sobregiro_Exposicion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    
End Class