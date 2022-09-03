Imports DevComponents.DotNetBar
'Imports Lib_Bakapp_VarClassFunc

Public Class Frm_Formatos_Numericos

    Dim _Formato As String
    Dim _Aceptar As Boolean

    Public ReadOnly Property Pro_Aceptar() As Boolean
        Get
            Return _Aceptar
        End Get
    End Property

    Public Property Pro_Formato() As String
        Get
            Return _Formato
        End Get
        Set(ByVal value As String)
            _Formato = value
        End Set
    End Property

    Public Sub New(ByVal Formato As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Formato = Replace(Formato, ".", "")

        If Global_Thema = Enum_Themas.Oscuro Then
            Input_Decimales.FocusHighlightEnabled = False
            Input_Numeros.FocusHighlightEnabled = False
            Btn_Aceptar.ForeColor = Color.White
        End If

    End Sub

    Private Sub Frm_Formatos_Numericos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If _Formato.Contains("$") Then
            Rdb_Moneda.Checked = True
        ElseIf _Formato.Contains("%") Then
            Rdb_Porcentaje.Checked = True
        End If

        _Formato = Replace(_Formato, "$", "")
        _Formato = Replace(_Formato, "%", "")

        If _Formato.Contains("9") Then
            Rdb_Alineacion_Der.Checked = True
        End If

        If _Formato.Contains(",") Then
            Dim _Dec = Split(_Formato, ",", 2)
            Input_Decimales.Value = Len(_Dec(1))
            Input_Numeros.Value = Len(_Dec(0))
        Else
            Input_Numeros.Value = Len(_Formato)
        End If

        Sb_Refrescar_Formato()

        AddHandler Input_Numeros.ValueChanged, AddressOf Sb_Refrescar_Formato
        AddHandler Input_Decimales.ValueChanged, AddressOf Sb_Refrescar_Formato

        AddHandler Rdb_Sin_Simbolo.CheckedChanged, AddressOf Sb_Refrescar_Formato
        AddHandler Rdb_Porcentaje.CheckedChanged, AddressOf Sb_Refrescar_Formato
        AddHandler Rdb_Moneda.CheckedChanged, AddressOf Sb_Refrescar_Formato

        AddHandler Rdb_Alineacion_Izq.CheckedChanged, AddressOf Rdb_Alineacion_Izq_CheckedChanged
        AddHandler Rdb_Alineacion_Der.CheckedChanged, AddressOf Rdb_Alineacion_Der_CheckedChanged

    End Sub

    Sub Sb_Refrescar_Formato()

        Dim _Valor = StrDup(Input_Numeros.Value, "9")
        Dim _Decimales = Input_Decimales.Value

        If CBool(Input_Decimales.Value) Then
            Dim _Deci = StrDup(Input_Decimales.Value, "9")
            _Valor += "," & _Deci
        End If

        If Rdb_Alineacion_Izq.Checked Then
            _Valor = Replace(_Valor, "9", "8")
        End If

        Dim _Cant_Caracteres As Integer = Len(_Formato)

        Dim _Precio_Val As Double = De_Txt_a_Num_01(_Valor, _Decimales) 'Val(_Valor)

        Dim _Precio = FormatNumber(Math.Round(_Precio_Val, _Decimales), _Decimales)

        _Formato = Trim(_Valor)

        If Rdb_Moneda.Checked Then
            Lbl_Ejemplo.Text = FormatCurrency(_Precio, _Decimales)
        ElseIf Rdb_Porcentaje.Checked Then
            Lbl_Ejemplo.Text = _Precio & "%"
        Else
            Lbl_Ejemplo.Text = _Precio
        End If

        If Rdb_Alineacion_Der.Checked Then
            Lbl_Ejemplo.TextAlign = ContentAlignment.MiddleRight
        Else
            Lbl_Ejemplo.TextAlign = ContentAlignment.MiddleLeft
        End If

    End Sub

    Private Sub Rdb_Alineacion_Izq_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Rdb_Alineacion_Izq.Checked Then
            Sb_Refrescar_Formato()
        End If
    End Sub

    Private Sub Rdb_Alineacion_Der_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Rdb_Alineacion_Der.Checked Then
            Sb_Refrescar_Formato()
        End If
    End Sub

    Private Sub Frm_Formatos_Numericos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        _Formato = Lbl_Ejemplo.Text
        _Aceptar = True
        Me.Close()
    End Sub

End Class
