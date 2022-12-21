Imports DevComponents.DotNetBar

Public Class Frm_Seleccionar_Fecha

    Public Property FechaSeleccionada As DateTime
    Public Property Grabar As Boolean
    Public Property ExigeFechaMinima As Boolean
    Public Property FechaMinima As DateTime
    Public Property SolicitarConfirmacionDeFecha As Boolean

    Public Property FechaDisplay As Date
        Get
            Return _FechaDisplay
        End Get
        Set(value As Date)
            _FechaDisplay = value
            Mnt_Fecha.DisplayMonth = _FechaDisplay
            Txt_Fecha.Text = _FechaDisplay.ToShortDateString
        End Set
    End Property

    Dim _FechaDisplay As DateTime


    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New Point(Me.Width + Cursor.Position.X - 200, Cursor.Position.Y - 200)

    End Sub

    Private Sub Frm_Seleccionar_Fecha_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ActiveControl = Mnt_Fecha
    End Sub

    Private Sub Btn_Cancelar_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub Btn_Aceptar_Click(sender As Object, e As EventArgs) Handles Btn_Aceptar.Click

        FechaSeleccionada = Mnt_Fecha.SelectedDate

        If ExigeFechaMinima Then
            If _FechaSeleccionada <= _FechaMinima Then
                MessageBoxEx.Show(Me, "La fecha no puede ser menor o igual a la fecha: " & FechaMinima.ToShortDateString,
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If
        End If

        If SolicitarConfirmacionDeFecha Then
            If MessageBoxEx.Show(Me, "¿Confirma la fecha " & FechaSeleccionada.ToShortDateString & "?", "Confirmar selección",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
                Return
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

    Private Sub Mnt_Fecha_DateSelected(sender As Object, e As DateRangeEventArgs) Handles Mnt_Fecha.DateSelected
        Txt_Fecha.Text = Mnt_Fecha.SelectedDate.ToShortDateString
    End Sub
End Class
