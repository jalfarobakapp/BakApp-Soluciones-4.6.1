Imports DevComponents.DotNetBar
Imports BkSpecialPrograms
Public Class Frm_Meson_Operario_Cantidad_Fabricada

    Dim _Grabar As Boolean
    Dim _Fabricados As Integer

    Public Property Pro_Grabar As Boolean
        Get
            Return _Grabar
        End Get
        Set(value As Boolean)
            _Grabar = value
        End Set
    End Property

    Public Property Pro_Fabricados As Integer
        Get
            Return _Fabricados
        End Get
        Set(value As Integer)
            _Fabricados = value
        End Set
    End Property

    Public Sub New(Fabricar As Integer, Codigo As String, Descripcion As String, Numot As String, Subot As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Lbl_Cantidad_Fabricar.Text = "Cantidad a fabricar: " & FormatNumber(Fabricar, 0)
        Num_Cant_Fabricada.Minimum = 1
        Num_Cant_Fabricada.Maximum = Fabricar
        Num_Cant_Fabricada.Value = Fabricar

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

    Private Sub Frm_Meson_Operario_Cantidad_Fabricada_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.ActiveControl = Num_Cant_Fabricada
        Num_Cant_Fabricada.Select()
    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        If Not String.IsNullOrEmpty(Trim(Num_Cant_Fabricada.Text)) Then

            If CDbl(Num_Cant_Fabricada.Text) <= Num_Cant_Fabricada.Maximum Then
                _Fabricados = Num_Cant_Fabricada.Value
                'If MessageBoxEx.Show(Me, "¿Confirma la fabricación por " & Num_Cant_Fabricada.Value & " producto(s)?",
                '                     "Confirmación", vbYesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                _Grabar = True
                Me.Close()
                'End If
            Else
                MessageBoxEx.Show(Me, "La cantidad a fabricar no debe ser mayor a " & Num_Cant_Fabricada.Value, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Num_Cant_Fabricada.Text = Num_Cant_Fabricada.Value
            End If

        Else
            MessageBoxEx.Show(Me, "Debe ingresar una cantidad a fabricar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Num_Cant_Fabricada.Text = Num_Cant_Fabricada.Value
        End If

    End Sub

    Private Sub Frm_Meson_Operario_Cantidad_Fabricada_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Num_Cant_Fabricada_KeyDown(sender As Object, e As KeyEventArgs) Handles Num_Cant_Fabricada.KeyDown
        If e.KeyValue = Keys.Enter Then
            Call Btn_Grabar_Click(Nothing, Nothing)
        End If
    End Sub
End Class
