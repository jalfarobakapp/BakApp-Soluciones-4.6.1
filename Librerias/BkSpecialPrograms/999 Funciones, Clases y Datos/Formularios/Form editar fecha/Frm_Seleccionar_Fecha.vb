Imports DevComponents.DotNetBar

Public Class Frm_Seleccionar_Fecha

    Public Property FechaSeleccionada As DateTime
    Public Property Grabar As Boolean
    Public Property ExigeFechaMinima As Boolean
    Public Property ExigeFechaMaxima As Boolean
    Public Property FechaMinima As DateTime
    Public Property FechaMaxima As DateTime
    Public Property SolicitarConfirmacionDeFecha As Boolean
    Public Property HoraSeleccionada As DateTime

    Public Property MostraFormularioAlCentro As Boolean
        Get
            Return Me.StartPosition = FormStartPosition.CenterScreen
        End Get
        Set(value As Boolean)
            If value Then
                Me.StartPosition = FormStartPosition.CenterScreen
            Else
                Me.StartPosition = FormStartPosition.Manual
            End If
        End Set
    End Property

    Dim _HoraDisplay As DateTime
    Dim _FechaDisplay As DateTime

    Public Property SeleccionarHora As Boolean
        Get
            Return Dtp_Hora.Visible
        End Get
        Set(value As Boolean)
            LabelX2.Visible = value
            Dtp_Hora.Visible = value
        End Set
    End Property

    Public Property FechaDisplay As Date
        Get
            Return _FechaDisplay
        End Get
        Set(value As Date)
            _FechaDisplay = value
        End Set
    End Property

    Public Property HoraDisplay As Date
        Get
            Return _HoraDisplay
        End Get
        Set(value As Date)
            _HoraDisplay = value
            Dtp_Hora.Value = _HoraDisplay
        End Set
    End Property

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New Point(Me.Width + Cursor.Position.X - 200, Cursor.Position.Y - 200)

    End Sub

    Private Sub Frm_Seleccionar_Fecha_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ActiveControl = Dtp_Fecha
    End Sub

    Private Sub Btn_Cancelar_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub Btn_Aceptar_Click(sender As Object, e As EventArgs) Handles Btn_Aceptar.Click

        FechaSeleccionada = Dtp_Fecha.Value.Date
        HoraSeleccionada = Dtp_Hora.Value

        If SeleccionarHora Then
            If HoraSeleccionada.Hour = 0 And HoraSeleccionada.Minute = 0 Then
                MessageBoxEx.Show(Me, "Debe seleccionar una hora válida", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Dtp_Hora.Focus()
                Return
            End If
        End If

        If ExigeFechaMinima Then
            If _FechaSeleccionada.Date <= _FechaMinima.Date Then
                MessageBoxEx.Show(Me, "La fecha no puede ser menor o igual a la fecha: " & FechaMinima.ToShortDateString,
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Dtp_Fecha.Focus()
                Return
            End If
        End If

        If ExigeFechaMaxima Then
            If _FechaSeleccionada.Date >= _FechaMaxima.Date Then
                MessageBoxEx.Show(Me, "La fecha no puede ser mayor o igual a la fecha: " & FechaMaxima.ToShortDateString,
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Dtp_Fecha.Focus()
                Return
            End If
        End If

        If SolicitarConfirmacionDeFecha Then

            If SeleccionarHora Then

                FechaSeleccionada = FechaSeleccionada.AddHours(HoraSeleccionada.Hour).AddMinutes(HoraSeleccionada.Minute)

                If MessageBoxEx.Show(Me, "¿Confirma la fecha " & FechaSeleccionada.ToLongDateString & " y hora " & FechaSeleccionada.ToShortTimeString & "?", "Confirmar selección",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
                    Return
                End If

            Else

                If MessageBoxEx.Show(Me, "¿Confirma la fecha " & FechaSeleccionada.ToShortDateString & "?", "Confirmar selección",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
                    Return
                End If

            End If

        End If

        Grabar = True
        Me.Close()

    End Sub

    Private Sub Frm_Seleccionar_Fecha_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Cancelar_Click_1(sender As Object, e As EventArgs) Handles Btn_Cancelar.Click
        Me.Close()
    End Sub
End Class
