Imports DevComponents.DotNetBar
Imports BkSpecialPrograms

Public Class Frm_DFA_Cierre_Atrasado

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Aceptar As Boolean

    Dim _No_Validar_Hora_Ingreso As Boolean
    Dim _No_Validar_Hora_Termino As Boolean

    Dim _Fecha_Ingreso_Minima As Date
    Dim _Fecha_Ingreso_Maxima As Date

    Dim _Fecha_Termino_Minima As Date
    Dim _Fecha_Termino_Maxima As Date

    Dim _Validar_Fecha_Ingreso_Minima As Boolean
    Dim _Validar_Fecha_Ingreso_Maxima As Boolean

    Dim _Validar_Fecha_Termino_Minima As Boolean
    Dim _Validar_Fecha_Termino_Maxima As Boolean

    Public ReadOnly Property Pro_Aceptar() As Boolean
        Get
            Return _Aceptar
        End Get
    End Property
    Public Property Pro_Fecha_Ingreso() As Date
        Get
            Return Dtp_Fecha_Ingreso.Value
        End Get
        Set(ByVal value As Date)
            Dtp_Fecha_Ingreso.Value = value
        End Set
    End Property
    Public Property Pro_Fecha_Cierre() As Date
        Get
            Return Dtp_Fecha_Termino.Value
        End Get
        Set(ByVal value As Date)
            Dtp_Fecha_Termino.Value = value
        End Set
    End Property
    Public Property Pro_Hora_Ingreso() As DateTime
        Get
            Return Dtp_Hora_Ingreso.Value
        End Get
        Set(ByVal value As Date)
            Dtp_Hora_Ingreso.Value = value
        End Set
    End Property
    Public Property Pro_Hora_Cierre() As DateTime
        Get
            Return Dtp_Hora_Termino.Value
        End Get
        Set(ByVal value As Date)
            Dtp_Hora_Termino.Value = value
        End Set
    End Property

    Public Property Fecha_Ingreso_Minima As Date
        Get
            Return _Fecha_Ingreso_Minima
        End Get
        Set(value As Date)
            _Fecha_Ingreso_Minima = value
        End Set
    End Property

    Public Property No_Validar_Hora_Ingreso As Boolean
        Get
            Return _No_Validar_Hora_Ingreso
        End Get
        Set(value As Boolean)
            _No_Validar_Hora_Ingreso = value
        End Set
    End Property

    Public Property No_Validar_Hora_Termino As Boolean
        Get
            Return _No_Validar_Hora_Termino
        End Get
        Set(value As Boolean)
            _No_Validar_Hora_Termino = value
        End Set
    End Property

    Public Property Fecha_Ingreso_Minima1 As Date
        Get
            Return _Fecha_Ingreso_Minima
        End Get
        Set(value As Date)
            _Fecha_Ingreso_Minima = value
        End Set
    End Property

    Public Property Fecha_Ingreso_Maxima As Date
        Get
            Return _Fecha_Ingreso_Maxima
        End Get
        Set(value As Date)
            _Fecha_Ingreso_Maxima = value
        End Set
    End Property

    Public Property Fecha_Termino_Minima As Date
        Get
            Return _Fecha_Termino_Minima
        End Get
        Set(value As Date)
            _Fecha_Termino_Minima = value
        End Set
    End Property

    Public Property Fecha_Termino_Maxima As Date
        Get
            Return _Fecha_Termino_Maxima
        End Get
        Set(value As Date)
            _Fecha_Termino_Maxima = value
        End Set
    End Property

    Public Property Validar_Fecha_Ingreso_Minima As Boolean
        Get
            Return _Validar_Fecha_Ingreso_Minima
        End Get
        Set(value As Boolean)
            _Validar_Fecha_Ingreso_Minima = value
        End Set
    End Property

    Public Property Validar_Fecha_Ingreso_Maxima As Boolean
        Get
            Return _Validar_Fecha_Ingreso_Maxima
        End Get
        Set(value As Boolean)
            _Validar_Fecha_Ingreso_Maxima = value
        End Set
    End Property

    Public Property Validar_Fecha_Termino_Minima As Boolean
        Get
            Return _Validar_Fecha_Termino_Minima
        End Get
        Set(value As Boolean)
            _Validar_Fecha_Termino_Minima = value
        End Set
    End Property

    Public Property Validar_Fecha_Termino_Maxima As Boolean
        Get
            Return _Validar_Fecha_Termino_Maxima
        End Get
        Set(value As Boolean)
            _Validar_Fecha_Termino_Maxima = value
        End Set
    End Property

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Btn_Aceptar.Visible = True

        WarningBox1.Text = "<b> Validación</b> La hora de cierre no puede ser igual o menor a la hora de ingreso"

        Dtp_Fecha_Ingreso.Enabled = True
        'Dtp_Fecha_Termino.Enabled = True
        Dtp_Hora_Ingreso.Enabled = True
        Dtp_Hora_Termino.Enabled = True

        If Global_Thema = Enum_Themas.Oscuro Then
            Btn_Aceptar.ForeColor = Color.White
        End If

    End Sub

    Private Sub Frm_DFA_Cierre_Atrazado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dtp_Fecha_Termino.Value = Dtp_Fecha_Ingreso.Value
    End Sub

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click

        Dim _Hora_Ingreso As DateTime = FormatDateTime(Dtp_Hora_Ingreso.Value, DateFormat.ShortTime)
        Dim _Hora_Cierre As DateTime = FormatDateTime(Dtp_Hora_Termino.Value, DateFormat.ShortTime)

        Dim _Fecha_Ingreso As Date = FormatDateTime(Dtp_Fecha_Ingreso.Value, DateFormat.ShortDate)
        Dim _Fecha_Termino As Date = FormatDateTime(Dtp_Fecha_Termino.Value, DateFormat.ShortDate)
        Dim _FechaDelServidor As Date = FormatDateTime(FechaDelServidor, DateFormat.ShortDate)

        If No_Validar_Hora_Ingreso Then
            If _Hora_Ingreso = #1/1/0001 12:00:00 AM# Then
                Sb_Hora_Invalida()
                Return
            End If
        End If

        If No_Validar_Hora_Termino Then
            If _Hora_Cierre = #1/1/0001 12:00:00 AM# Then
                Sb_Hora_Invalida()
                Return
            End If
        End If

        If Not No_Validar_Hora_Ingreso And Not No_Validar_Hora_Termino Then
            If _Hora_Cierre <= _Hora_Ingreso Or (_Hora_Ingreso = #1/1/0001 12:00:00 AM# Or _Hora_Cierre = #1/1/0001 12:00:00 AM#) Then
                Sb_Hora_Invalida()
                Return
            End If
        End If

        If _Validar_Fecha_Ingreso_Minima Then
            If FormatDateTime(_Fecha_Ingreso_Minima, DateFormat.ShortDate) >= _Fecha_Ingreso Then
                MessageBoxEx.Show(Me, "La fecha de ingreso no puede ser igual o menos que " &
                                  FormatDateTime(_Fecha_Ingreso_Minima, DateFormat.ShortDate),
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If
        End If

        If _Validar_Fecha_Ingreso_Maxima Then
            If _FechaDelServidor < _Fecha_Ingreso Then
                MessageBoxEx.Show(Me, "La fecha de ingreso no puede ser mayor que " & _FechaDelServidor,
                                      "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If
        End If


        If _Validar_Fecha_Termino_Minima Then
            If FormatDateTime(_Fecha_Termino_Minima, DateFormat.ShortDate) >= _Fecha_Ingreso Then
                MessageBoxEx.Show(Me, "La fecha de termino no puede ser igual o menos que " &
                                  FormatDateTime(_Fecha_Ingreso_Minima, DateFormat.ShortDate),
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If
        End If

        If _Validar_Fecha_Termino_Maxima Then
            If _FechaDelServidor < _Fecha_Termino Then
                MessageBoxEx.Show(Me, "La fecha de termino no puede ser mayor que " & _FechaDelServidor,
                                      "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If
        End If

        _Aceptar = True
        Me.Close()

    End Sub

    Sub Sb_Hora_Invalida()
        Beep()
        ToastNotification.Show(Me, "HORA INVALIDA", Imagenes_32x32.Images.Item("button_rounded_red_delete.png"),
                         1 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
    End Sub

    Private Sub Dtp_Fecha_Ingreso_ValueChanged(sender As Object, e As EventArgs) Handles Dtp_Fecha_Ingreso.ValueChanged
        Dtp_Fecha_Termino.Value = Dtp_Fecha_Ingreso.Value
    End Sub

    Private Sub Frm_DFA_Cierre_Atrasado_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

End Class
