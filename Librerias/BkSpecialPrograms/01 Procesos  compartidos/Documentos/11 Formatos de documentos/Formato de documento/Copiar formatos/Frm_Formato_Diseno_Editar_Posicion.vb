Public Class Frm_Formato_Diseno_Editar_Posicion

    Dim _FormPadre As Object

    Dim _X As Integer
    Dim _Y As Integer

    Dim _Alto As Double
    Dim _Ancho As Double

    Dim _Sumar_Boton As Boolean
    Dim _Aceptar As Boolean

    Public ReadOnly Property Pro_Aceptar() As Boolean
        Get
            Return _Aceptar
        End Get
    End Property

    Public Property Pro_Tamano_Hoja() As Boolean
        Get

        End Get
        Set(ByVal value As Boolean)
            If value Then

                Grupo.Text = "Tamaño de hoja"
                Lbl_X.Text = "Ancho (Cm)"
                Lbl_X_Sumar_MM.Text = "MM"
                Lbl_Y.Text = "Alto (Cm)"
                Lbl_Y_Sumar_MM.Text = "MM"
                Me.StartPosition = FormStartPosition.CenterScreen
                _Sumar_Boton = False

                Sumar_X.MaxValue = 99
                Sumar_Y.MaxValue = 99

                Input_Alto_Y.MinValue = 3
                Input_Ancho_X.MinValue = 3

            End If

        End Set
    End Property

    Public Property Pro_Alto_Y() As Double
        Get

            Dim ValorDecimal As Double
            Dim ParteEntera As Long = Input_Alto_Y.Value
            Dim ParteDecimal As Double = Sumar_Y.Value / 100

            ValorDecimal = ParteEntera + ParteDecimal
            _Alto = ValorDecimal

            Return _Alto
        End Get
        Set(ByVal value As Double)

            Dim ValorDecimal As Double
            Dim ParteEntera As Long
            Dim ParteDecimal As Double

            ValorDecimal = value '10.56789
            ParteEntera = Int(ValorDecimal)
            ParteDecimal = ValorDecimal - ParteEntera

            Input_Alto_Y.Value = ParteEntera
            Sumar_Y.Value = ParteDecimal * 100

        End Set
    End Property

    Public Property Pro_Ancho_X() As Double
        Get

            Dim ValorDecimal As Double
            Dim ParteEntera As Long = Input_Ancho_X.Value
            Dim ParteDecimal As Double = Sumar_X.Value / 100

            ValorDecimal = ParteEntera + ParteDecimal
            _Ancho = ValorDecimal

            Return _Ancho
        End Get
        Set(ByVal value As Double)

            Dim ValorDecimal As Double
            Dim ParteEntera As Long
            Dim ParteDecimal As Double

            ValorDecimal = value '10.56789
            ParteEntera = Int(ValorDecimal)
            ParteDecimal = ValorDecimal - ParteEntera

            Input_Ancho_X.Value = ParteEntera
            Sumar_X.Value = ParteDecimal * 100

        End Set
    End Property

    Public Sub New(ByVal Maximo_X As Integer, ByVal Maximo_Y As Integer, _
                   ByVal Form_Padre As Object)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Input_Ancho_X.MaxValue = Maximo_X
        Input_Alto_Y.MaxValue = Maximo_Y

        _Sumar_Boton = True

        If Global_Thema = Enum_Themas.Oscuro Then
            Btn_Aceptar.ForeColor = Color.White
            Input_Alto_Y.FocusHighlightEnabled = False
            Input_Ancho_X.FocusHighlightEnabled = False
            Sumar_X.FocusHighlightEnabled = False
            Sumar_Y.FocusHighlightEnabled = False
        End If

    End Sub

    Private Sub Frm_Formato_Diseno_Editar_Posicion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If _Sumar_Boton Then

            AddHandler Sumar_Y.ValueChanged, AddressOf Sumar_Y_ValueChanged
            AddHandler Sumar_X.ValueChanged, AddressOf Sumar_X_ValueChanged

        End If

    End Sub

    Private Sub Frm_Formato_Diseno_Editar_Posicion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyValue = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyValue = Keys.Enter Then
            _Aceptar = True
            Me.Close()
        End If

    End Sub

    Private Sub Sumar_Y_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Input_Alto_Y.Value += Sumar_Y.Value
    End Sub

    Private Sub Sumar_X_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Input_Ancho_X.Value += Sumar_X.Value
    End Sub

    Public Property Pro_X() As Integer
        Get
            Return Input_Ancho_X.Value
        End Get
        Set(ByVal value As Integer)
            Input_Ancho_X.Value = value
        End Set
    End Property

    Public Property Pro_Y() As Integer
        Get
            Return Input_Alto_Y.Value
        End Get
        Set(ByVal value As Integer)
            Input_Alto_Y.Value = value
        End Set
    End Property

    Private Sub Input_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '_FormPadre.Sld_Ubicacion_X.Value = Input_Ancho_X.Value
        '_FormPadre.Sld_Ubicacion_Y.Value = Input_Alto_Y.Value
    End Sub


    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        _Aceptar = True
        Me.Close()
    End Sub

End Class