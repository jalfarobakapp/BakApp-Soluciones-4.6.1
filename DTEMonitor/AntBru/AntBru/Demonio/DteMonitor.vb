Imports DevComponents.DotNetBar
'Imports BkSpecialPrograms
Imports HEFESTO.FIRMA.DOCUMENTO

Public Class DteMonitor

    'Dim _Fm_Demonio As Frm_Demonio_01
    Dim _Fm_Demonio_DTEMonitor As Frm_Demonio_DTEMonitor
    Dim _Class_BaseBk As Class_Conectar_Base_BakApp

    'Public Property Pro_Fm_Demonio() As Frm_Demonio_01
    '    Get
    '        Return _Fm_Demonio
    '    End Get
    '    Set(ByVal value As Frm_Demonio_01)
    '        _Fm_Demonio = value
    '    End Set
    'End Property

    Public Property Pro_Frm_Demonio_DTEMonitor() As Frm_Demonio_DTEMonitor
        Get
            Return _Fm_Demonio_DTEMonitor
        End Get
        Set(ByVal value As Frm_Demonio_DTEMonitor)
            _Fm_Demonio_DTEMonitor = value
        End Set
    End Property

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Version_BkSpecialPrograms = "" 'FileVersionInfo.GetVersionInfo(Application.StartupPath & "\BkSpecialPrograms.dll").FileVersion


    End Sub

    Private Sub Demonio_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        _Global_Version_BakApp = _Version_BakApp
        _Configuracion_Regional_()
        Me.Hide()

        ' Leer los parámetros de la línea de comandos
        ' y mostrarlos en la caja de textos
        '
        ' Para probar, indicar esto en CommandLine arguments en propiedades
        'Prueba1 prueba2 /file:Nombre del fichero
        '
        ' Comprobar si hay más de un parámetro,
        ' el parámetro CERO es el nombre del ejecutable

        'Cadena_ConexionSQL_Server = "data source = SIERRALTA; initial catalog = SMARTRADING; user id = SMARTRADING; password = SMARTRADING"

        If Environment.GetCommandLineArgs.Length > 1 Then

            Cadena_ConexionSQL_Server = Environment.GetCommandLineArgs(1)
            Cadena_ConexionSQL_Server = Replace(Cadena_ConexionSQL_Server, "@", " ")

            Sb_Sistema_Demonio_DTE(Me)

            Dim Fm As New Frm_Demonio_DTEMonitor(Me)
            Fm.ShowDialog(Me)
            Fm.Dispose()

            Application.ExitThread()

        Else

            Tiempo_Alerta.Start()

        End If

    End Sub

    Private Sub Tiempo_Alerta_Tick(sender As Object, e As EventArgs) Handles Tiempo_Alerta.Tick

        Tiempo_Alerta.Enabled = False

        Dim _Info As New TaskDialogInfo("Falta String de conexión",
                          eTaskDialogIcon.Stop2,
                          "No se han indicado parámetros en la línea de comandos",
                          "El nombre (y path) del ejecutable es:" & vbCrLf &
                                            Environment.GetCommandLineArgs(0),
                          eTaskDialogButton.Ok, eTaskDialogBackgroundColor.Red, Nothing, Nothing, Nothing, Nothing, Nothing)

        Dim _Resultado As eTaskDialogResult = TaskDialog.Show(_Info)


        Dim _Fmdb As New Frm_ConexionBD()
        _Fmdb.BtnAgregar.Visible = False
        _Fmdb.ShowDialog(Me)
        Dim _RowConexion As DataRow = _Fmdb.Pro_RowConexion
        _Fmdb.Dispose()

        If Not (_RowConexion Is Nothing) Then

            Dim _Cadena = "data source = #SV#; initial catalog = #BD#; user id = #US#; password = #PW#"

            Dim SV, PT, BD, US, PW As String

            SV = _RowConexion.Item("Servidor")
            PT = _RowConexion.Item("Puerto")
            US = _RowConexion.Item("Usuario")
            PW = _RowConexion.Item("Clave")
            BD = _RowConexion.Item("BaseDeDatos")

            If Trim(PT) <> "" Then
                SV = Trim(SV & "," & PT)
            End If

            _Cadena = Replace(_Cadena, "#SV#", SV)
            _Cadena = Replace(_Cadena, "#BD#", BD)
            _Cadena = Replace(_Cadena, "#US#", US)
            _Cadena = Replace(_Cadena, "#PW#", PW)

            Cadena_ConexionSQL_Server = _Cadena

            _Class_BaseBk = New Class_Conectar_Base_BakApp(Me)

            If _Class_BaseBk.Pro_Existe_Base Then

                _Global_BaseBk = _Class_BaseBk.Pro_Row_Tabcarac.Item("Global_BaseBk")
                Sb_Sistema_Demonio_DTE(Me)

                'If _Global_Row_EstacionBk.Item("EsDTEMonitor") Then
                Dim Fm As New Frm_Demonio_DTEMonitor(Me)
                Fm.ShowDialog(Me)
                Fm.Dispose()
                'End If

            Else

                MessageBoxEx.Show(Me, "No es posible conectarse a la base de datos", "Conexión", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            End If

        End If

        Application.ExitThread()

    End Sub

    Private Sub Notify_Bk2Dte_DoubleClick(sender As Object, e As EventArgs) Handles Notify_Bk2Dte.DoubleClick

        If Not _Global_Row_EstacionBk.Item("EsDTEMonitor") Then

            Notify_Bk2Dte.Visible = False
            Dim _Info As New TaskDialogInfo("Este equipo no es el DTE Monitor",
                              eTaskDialogIcon.NoEntry,
                              "Solamente el equipo que es el DTE Monitor puede activar esta opción.",
                              "Consulte al administradord del sistema",
                              eTaskDialogButton.Ok, eTaskDialogBackgroundColor.Red, Nothing, Nothing, Nothing, Nothing, Nothing)

            Dim _Resultado As eTaskDialogResult = TaskDialog.Show(_Info)
            Notify_Bk2Dte.Visible = True
            Return

        End If

        'Sb_Demonio_DTE()

    End Sub
End Class
