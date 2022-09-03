Imports DevComponents.DotNetBar
Imports BkSpecialPrograms

Public Class Frm_Meson_Operario_Avance

    Dim _Porc_Avance As Double
    Dim _Porc_Avance_MQ As Double
    Dim _Grabar As Boolean

    Public Sub New(Porc_Avance As Double, Codigo As String, Descripcion As String, Numot As String, Subot As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Porc_Avance = Porc_Avance
        Num_Porc_Avance.Minimum = _Porc_Avance * 100
        Num_Porc_Avance.Value = _Porc_Avance * 100
        Num_Porc_Avance.Maximum = 999

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

    Public Property Pro_Porc_Avance As Double
        Get
            Return _Porc_Avance
        End Get
        Set(value As Double)
            _Porc_Avance = value
        End Set
    End Property

    Public Property Pro_Grabar As Boolean
        Get
            Return _Grabar
        End Get
        Set(value As Boolean)
            _Grabar = value
        End Set
    End Property

    Public Property Pro_Porc_Avance_MQ As Double
        Get
            Return _Porc_Avance_MQ
        End Get
        Set(value As Double)
            _Porc_Avance_MQ = value
        End Set
    End Property

    Private Sub Frm_Meson_Operario_Avance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Num_Porc_Avance.Value = _Porc_Avance * 100
        Cp_Progreso.Value = Num_Porc_Avance.Value
        'Cp_Progreso.ProgressBarType = eCircularProgressType.Pie
    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        If Num_Porc_Avance.Value > 100 Then

            MessageBoxEx.Show(Me, "El porcentaje de avance no puede ser mayor al 100%", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return

        End If

        If _Porc_Avance > 0 Then
            _Porc_Avance_MQ = (Num_Porc_Avance.Value / 100) - _Porc_Avance
        Else
            _Porc_Avance_MQ = Num_Porc_Avance.Value / 100
        End If
        _Porc_Avance = Num_Porc_Avance.Value / 100

        If _Porc_Avance_MQ > 0 Then
            _Grabar = True
            Me.Close()
        Else
            MessageBoxEx.Show(Me, "El porcentaje de avance debe ser mayor al avance ya ejecutado", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub Num_Porc_Avance_KeyDown(sender As Object, e As KeyEventArgs) Handles Num_Porc_Avance.KeyDown
        If e.KeyValue = Keys.Enter Then
            Call Btn_Grabar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub Frm_Meson_Operario_Avance_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class
