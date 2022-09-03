Imports DevComponents.DotNetBar
Imports BkSpecialPrograms

Public Class Frm_Meson_Operario_Cantidad_A_Fabricar

    Dim _Grabar As Boolean
    Dim _Fabricar As Integer

    Public Property Pro_Grabar As Boolean
        Get
            Return _Grabar
        End Get
        Set(value As Boolean)
            _Grabar = value
        End Set
    End Property

    Public Property Pro_Fabricar As Integer
        Get
            Return _Fabricar
        End Get
        Set(value As Integer)
            _Fabricar = value
        End Set
    End Property

    Public Sub New(Fabricar As Double, Codigo As String, Descripcion As String, Numot As String, Subot As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Num_Cant_Fabricar.Maximum = Fabricar
        Num_Cant_Fabricar.Minimum = 1
        Num_Cant_Fabricar.Value = Fabricar

        Dim _Color = "#17365D"

        If Global_Thema = Enum_Themas.Oscuro Then
            _Color = "#51BCFF"
        End If

        LabelX1.Text = "<b>OT: " & Numot & " SubOt: </b><font color=""" & _Color & """>" & Subot & "</font><br/>" &
                       "<b>Código: " & Codigo & "</b><br/><font color=""" & _Color & """>" & Descripcion & "</font>"

        If Global_Thema = Enum_Themas.Oscuro Then
            Btn_Grabar.ForeColor = Color.White
        End If

    End Sub

    Private Sub Frm_Meson_Operario_Cantidad_A_Fabricar_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.ActiveControl = Num_Cant_Fabricar
    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        If Not String.IsNullOrEmpty(Trim(Num_Cant_Fabricar.Text)) Then

            If CDbl(Num_Cant_Fabricar.Text) <= Num_Cant_Fabricar.Maximum Then
                _Fabricar = Num_Cant_Fabricar.Value
                _Grabar = True
                Me.Close()
            Else
                MessageBoxEx.Show(Me, "La cantidad a fabricar no debe ser mayor a " & Num_Cant_Fabricar.Value, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Num_Cant_Fabricar.Text = Num_Cant_Fabricar.Value
            End If

        Else
            MessageBoxEx.Show(Me, "Debe ingresar una cantidad a fabricar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Num_Cant_Fabricar.Text = Num_Cant_Fabricar.Value
        End If

    End Sub

    Private Sub Num_Cant_Fabricar_KeyDown(sender As Object, e As KeyEventArgs) Handles Num_Cant_Fabricar.KeyDown
        If e.KeyValue = Keys.Enter Then
            Call Btn_Grabar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub Frm_Meson_Operario_Cantidad_A_Fabricar_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class
