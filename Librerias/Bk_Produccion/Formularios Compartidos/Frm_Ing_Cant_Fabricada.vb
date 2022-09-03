
Imports DevComponents.DotNetBar

Public Class Frm_Ing_Cant_Fabricada

    Dim _Realjor As Double
    Dim _Permitir_Valor_Cero As Boolean
    Dim _Estimado_Fabricar As Double
    Dim _Fabricado As Boolean

    Public Property Pro_Realjor() As Double
        Get
            Return _Realjor
        End Get
        Set(ByVal value As Double)
            _Realjor = value
        End Set
    End Property
    Public Property Pro_Permitir_Valor_Cero() As Boolean
        Get
            Return _Permitir_Valor_Cero
        End Get
        Set(ByVal value As Boolean)
            _Permitir_Valor_Cero = value
        End Set
    End Property
    Public Property Pro_Estimado_Fabricar() As Double
        Get
            Return _Estimado_Fabricar
        End Get
        Set(ByVal value As Double)
            _Estimado_Fabricar = value
        End Set
    End Property
    Public ReadOnly Property Pro_Fabricado() As Boolean
        Get
            Return _Fabricado
        End Get
    End Property

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_Ing_Cant_Fabricada_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Num_Realjor = Me.ActiveControl
        'Num_Realjor.Focus()

        'Me.ActiveControl = NumericUpDown1
        'NumericUpDown1.Select(0, NumericUpDown1.Text.Length)
        'NumericUpDown1.Focus()


        Me.ActiveControl = Num_Realjor
        Num_Realjor.Select(0, Num_Realjor.Text.Length)
        Num_Realjor.Focus()

        Me.Text = "FRABRICACION (Estimado " & _Estimado_Fabricar & ")"

    End Sub

    Sub Sb_Aceptar()

        _Fabricado = True

        If Not CBool(Num_Realjor.Value) Then
            If Not _Permitir_Valor_Cero Then
                MessageBoxEx.Show(Me, "Debe ingresar la cantidad a fabricar, no puede ser cero", "Validación", _
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Num_Realjor.Focus()
                _Fabricado = False
            End If
        End If

        If CBool(_Estimado_Fabricar) Then
            If Num_Realjor.Value > _Estimado_Fabricar Then
                If MessageBoxEx.Show(Me, "Esta fabricando mayor cantidad de lo estipulado." & vbCrLf & _
                                     "Cantidad estipulada: " & FormatNumber(_Estimado_Fabricar, 0) & vbCrLf & _
                                     "¿Confirma esta cantidad?", "Confirmar cantidad", _
                                     MessageBoxButtons.YesNoCancel, _
                                     MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
                    _Fabricado = False
                    Num_Realjor.Select(0, Num_Realjor.Text.Length)
                    Num_Realjor.Focus()
                End If
            End If
        End If

        If _Fabricado Then
            _Realjor = Num_Realjor.Value
            Me.Close()
        End If
    End Sub

    Private Sub Num_Realjor_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Num_Realjor.KeyDown
        If e.KeyValue = Keys.Enter Then
            Sb_Aceptar()
        End If
    End Sub

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        Sb_Aceptar()
    End Sub

    Private Sub Frm_Ing_Cant_Fabricada_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            _Fabricado = False
            Me.Close()
        End If
    End Sub

End Class