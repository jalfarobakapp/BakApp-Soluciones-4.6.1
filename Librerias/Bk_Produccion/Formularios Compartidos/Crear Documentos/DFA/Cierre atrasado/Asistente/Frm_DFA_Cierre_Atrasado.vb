Imports Funciones_BakApp
Imports DevComponents.DotNetBar
Imports BkSpecialPrograms

Public Class Frm_DFA_Cierre_Atrasado

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Aceptar As Boolean

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
            Return Dtp_Fecha_Cierre.Value
        End Get
        Set(ByVal value As Date)
            Dtp_Fecha_Cierre.Value = value
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
            Return Dtp_Hora_Cierre.Value
        End Get
        Set(ByVal value As Date)
            Dtp_Hora_Cierre.Value = value
        End Set
    End Property

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Btn_Aceptar.Visible = True

        WarningBox1.Text = "<b> Validación</b> La hora de cierre no puede ser igual o menor a la hora de ingreso"
    End Sub

    Private Sub Frm_DFA_Cierre_Atrazado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click

        Dim _Hora_Ingreso As DateTime = FormatDateTime(Dtp_Hora_Ingreso.Value, DateFormat.ShortTime)
        Dim _Hora_Cierre As DateTime = FormatDateTime(Dtp_Hora_Cierre.Value, DateFormat.ShortTime)

        If _Hora_Cierre <= _Hora_Ingreso Then

            Beep()

            ToastNotification.Show(Me, "HORA INVALIDA", Btn_Salir.Image, _
                             1 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
            'MessageBoxEx.Show(Me, "La hora de cierre no puede ser igual o menor a la hora de ingreso", _
            '                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            _Aceptar = True
            Me.Close()
        End If

    End Sub

    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Me.Close()
    End Sub


End Class