Public Class Frm_Editor_Fecha

    Dim _Fecha As Date
    Dim _Aceptada As Boolean

    Public Property Fecha As Date
        Get
            Return _Fecha
        End Get
        Set(value As Date)
            _Fecha = value
        End Set
    End Property

    Public Property Aceptada As Boolean
        Get
            Return _Aceptada
        End Get
        Set(value As Boolean)
            _Aceptada = value
        End Set
    End Property

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_Editor_Fecha_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dtp_Fecha.Value = Fecha
    End Sub

    Private Sub Frm_Editor_Fecha_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Dtp_Fecha_ValueChanged(sender As Object, e As EventArgs) Handles Dtp_Fecha.ValueChanged
        Btn_Aceptar.Focus()
    End Sub

    Private Sub Btn_Aceptar_Click(sender As Object, e As EventArgs) Handles Btn_Aceptar.Click
        _Fecha = Dtp_Fecha.Value
        _Aceptada = True
        Me.Close()
    End Sub

End Class
