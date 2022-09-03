Imports DevComponents.DotNetBar
Imports BkSpecialPrograms
Imports System.Threading

Public Class Frm_Notificaciones

    Dim _Fm_Demonio As Frm_Demonio_01

    Public Property Pro_Fm_Demonio() As Frm_Demonio_01
        Get
            Return _Fm_Demonio
        End Get
        Set(ByVal value As Frm_Demonio_01)
            _Fm_Demonio = value
        End Set
    End Property

    Dim _Face_Pruebas As Boolean

    Dim _Cl_Notificaciones As Cl_Notificaciones

    Private _Contador_Tiempo_Remotas As Integer
    Private _Contador_Tiempo_SolComProd As Integer

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Version_BkSpecialPrograms = FileVersionInfo.GetVersionInfo _
                                      (Application.StartupPath & "\BkSpecialPrograms.dll").FileVersion


        '_Cl_Notificaciones.Pro_Tiempo_Notificacion = 1000 * 60
        '_Cl_Notificaciones.Pro_Contador_Tiempo_Remotas = 0

    End Sub

    Private Sub Demonio_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        _Global_Version_BakApp = _Version_BakApp
        _Configuracion_Regional_()
        'Me.WindowState = FormWindowState.Minimized
        Me.Hide()

        Fm_Padre_Notificaciones = Me

        _Cl_Notificaciones = New Cl_Notificaciones(Fm_Padre_Notificaciones)

        ' Leer los parámetros de la línea de comandos
        ' y mostrarlos en la caja de textos
        '
        ' Para probar, indicar esto en CommandLine arguments en propiedades
        'Prueba1 prueba2 /file:Nombre del fichero
        '
        ' Comprobar si hay más de un parámetro,
        ' el parámetro CERO es el nombre del ejecutable

        'Cadena_ConexionSQL_Server = "data source = SIERRALTA; initial catalog = SIERRALTA; user id = SIERRALTA; password = SIERRALTA"
        'Cadena_ConexionSQL_Server = Replace(Cadena_ConexionSQL_Server, " ", "@")

        Dim _Ejecutar_Notificaciones As Boolean

        If Environment.GetCommandLineArgs.Length > 1 Then
            Cadena_ConexionSQL_Server = Environment.GetCommandLineArgs(1)
            'MessageBoxEx.Show(Me, Cadena_ConexionSQL_Server, "Cadena", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Cadena_ConexionSQL_Server = Replace(Cadena_ConexionSQL_Server, "@", " ")
            'MessageBoxEx.Show(Me, Cadena_ConexionSQL_Server, "Cadena", MessageBoxButtons.OK, MessageBoxIcon.Information)

            _Ejecutar_Notificaciones = True
        Else
            Tiempo_Alerta.Enabled = True
            _Face_Pruebas = True
        End If

        If _Ejecutar_Notificaciones Then
            Sb_Ejecutar_Notificaciones()
        End If

        Sb_Revisar_Estilo("")

    End Sub

    Sub Sb_Ejecutar_Notificaciones()

        Dim _Class_BaseBk As New Class_Conectar_Base_BakApp(Me)

        If _Class_BaseBk.Pro_Existe_Base Then

            _Global_BaseBk = _Class_BaseBk.Pro_Row_Tabcarac.Item("Global_BaseBk")

            If _Cl_Notificaciones.Fx_Conectar_Sistema Then

                Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
                Dim Consulta_sql As String

                Dim _Mod As New Clas_Modalidades
                _Mod.Sb_Actualiza_Formatos_X_Modalidad()
                _Global_Row_Configuracion_General = _Mod.Fx_Sql_Trae_Modalidad(Clas_Modalidades.Enum_Modalidad.General, "")
                _Global_Row_Configuracion_Estacion = _Mod.Fx_Sql_Trae_Modalidad(Clas_Modalidades.Enum_Modalidad.Estacion, Modalidad)
                _Mod.Sb_Actualizar_Variables_Modalidad(Modalidad)

                Dim _NombreEquipo = _Global_Row_EstacionBk.Item("NombreEquipo")
                Dim _Mos_Notif_X_CdPermiso As Boolean = _Global_Row_EstacionBk.Item("Mos_Notif_X_CdPermiso")

                Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_EstacionesBkp Where NombreEquipo = '" & _NombreEquipo & "'"
                _Global_Row_EstacionBk = _Sql.Fx_Get_DataRow(Consulta_sql)
                FUNCIONARIO = _Global_Row_EstacionBk.Item("Usuario_Actual")

                Notify_Notificaciones.Text = "BakApp (" & FUNCIONARIO & " - " & RutEmpresaActiva & ")"

                Me.Notify_Notificaciones.ShowBalloonTip(5, "Info. BakApp", "Monitoreo de notificaciones activado",
                                                      ToolTipIcon.Info)

                Tiempo_Notificaciones.Interval = 30 * 1000 ' Cada 1 minuto
                Tiempo_Notificaciones.Enabled = True

            Else

                Me.Close()

            End If

        Else

            MessageBoxEx.Show(Me, "No es posible conectarse a la base de datos",
                          "Conexión", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Application.ExitThread()

        End If

    End Sub

    Private Sub Tiempo_Alerta_Tick(sender As Object, e As EventArgs) Handles Tiempo_Alerta.Tick

        Tiempo_Alerta.Stop()

        MessageBoxEx.Show(Me, "No se han indicado parámetros en la línea de comandos" & vbCrLf &
                            "El nombre (y path) del ejecutable es:" & vbCrLf &
                            Environment.GetCommandLineArgs(0), "Falta String de conexión", MessageBoxButtons.OK, MessageBoxIcon.Stop)
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
            Sb_Ejecutar_Notificaciones()

        Else

            Application.ExitThread()

        End If

    End Sub

    Private Sub Notify_Demonio_MouseClick(sender As Object, e As MouseEventArgs) Handles Notify_Notificaciones.MouseClick
        'If e.Button = MouseButtons.Right Then
        '    ' ShowContextMenu(Menu_Contextual_Menu_Extra)
        'End If
    End Sub

    Private Sub ConfigurarDemonioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConfigurarDemonioToolStripMenuItem.Click

        Dim _Row_Usuario_Autorizado As DataRow

        Dim FmP As New Frm_ValidarPermiso(Frm_ValidarPermiso.Tipo_Accion.Validar_Permiso, "Pick0011", True, False)
        FmP.Pro_Cerrar_Automaticamente = True
        FmP.ShowDialog(Me)
        Dim _Validar As Boolean = FmP.Pro_Permiso_Aceptado
        _Row_Usuario_Autorizado = FmP.Pro_RowUsuario
        FmP.Dispose()

        If _Validar Then

            Me.Notify_Notificaciones.Visible = False

            Dim Fm As New Frm_Demonio_01_Conf_Local(_Row_Usuario_Autorizado.Item("KOFU"))
            Fm.ShowInTaskbar = True
            Fm.ShowDialog(Me)
            Fm.Dispose()

            Sb_Ejecutar_Notificaciones()

        End If
    End Sub

    Private Sub CerrarToolStripMenuItem_Click(sender As Object, e As EventArgs)

        Dim _Validar As Boolean

        Dim Fm As New Frm_ValidarPermiso(Frm_ValidarPermiso.Tipo_Accion.Validar_Permiso, "Pick0011", True, False)
        Fm.Pro_Cerrar_Automaticamente = True
        Fm.ShowDialog(Me)
        _Validar = Fm.Pro_Permiso_Aceptado
        Fm.Dispose()

        If _Validar Then
            Me.Close()
        End If

    End Sub

    Private Sub Tiempo_Notificaciones_Tick(sender As Object, e As EventArgs) Handles Tiempo_Notificaciones.Tick

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        'Dim Consulta_sql As String

        Tiempo_Notificaciones.Stop()

        If Not _Face_Pruebas Then

            Dim ejecutando As Process() = Process.GetProcessesByName("BakApp_Soluciones")

            If Not (CBool(ejecutando.Length)) Then

                Me.Notify_Notificaciones.ShowBalloonTip(5, "Info. BakApp", "Monitoreo de notificaciones desactivado" & vbCrLf &
                                                        "No se encuentra en ejecución Bakapp",
                                                          ToolTipIcon.Error)
                ' 5 Segundos de demora
                Thread.Sleep(5000)
                Me.Close()
            End If

        End If

        Dim _NombreEquipo = _Global_Row_EstacionBk.Item("NombreEquipo")

        Dim _Silenciar_Mis_Notificaciones As Boolean

        If _Sql.Fx_Exite_Campo(_Global_BaseBk & "Zw_EstacionesBkp", "Silenciar_Notificaciones") Then
            _Silenciar_Mis_Notificaciones = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_EstacionesBkp",
                                                          "Silenciar_Notificaciones", "NombreEquipo = '" & _NombreEquipo & "'")
        End If


        Dim _Sonido_Beep = Not _Silenciar_Mis_Notificaciones

        Dim _Mos_Notif_X_CdPermiso As Boolean = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_EstacionesBkp",
                                                                  "Mos_Notif_X_CdPermiso", "NombreEquipo = '" & _NombreEquipo & "'")

        If Not (FUNCIONARIO Is Nothing) Then

            Try

                Tiempo_Notificaciones.Stop()
                Dim _Mostrar_todas As Boolean

                If _Mos_Notif_X_CdPermiso Then

                    If Not csNotificaciones.Notificacion._Revisando_Permiso_Remoto Then

                        _Cl_Notificaciones.Sb_Revisar_Notificaciones_Remotas(False, _Sonido_Beep)
                        '_Cl_Notificaciones.Sb_Revisar_Notificaciones_Remotas(True, _Sonido_Beep)

                        If _Contador_Tiempo_SolComProd >= 10 Then
                            _Mostrar_todas = True
                            _Contador_Tiempo_SolComProd = 0
                        End If

                        If IsNothing(sender) Then
                            _Mostrar_todas = True
                        End If

                        _Cl_Notificaciones.Sb_Revisar_Notificaciones_SolComProd(_Mostrar_todas, _Sonido_Beep)

                    End If

                Else

                    _Cl_Notificaciones.Sb_Revisar_Notificaciones_Remotas(True, _Sonido_Beep)
                    _Cl_Notificaciones.Sb_Revisar_Notificaciones_SolComProd(True, _Sonido_Beep)

                End If

                'Notify_Notificaciones.Text = "BakApp (Notificaciones activas)"

                'Dim _Notificacion = "Hola mundo..."

                'Me.Notify_Notificaciones.ShowBalloonTip(8, "Info. BakApp", _Notificacion, ToolTipIcon.Info)

            Catch ex As Exception

            Finally

                _Contador_Tiempo_Remotas += 1
                _Contador_Tiempo_SolComProd += 1

                Tiempo_Notificaciones.Interval = 30 * 1000
                Tiempo_Notificaciones.Start()

            End Try

        End If


    End Sub

    Private Sub Notify_Notificaciones_DoubleClick(sender As Object, e As EventArgs) Handles Notify_Notificaciones.DoubleClick

        If Tiempo_Notificaciones.Enabled Then
            Call Tiempo_Notificaciones_Tick(Nothing, Nothing)
        End If

    End Sub

End Class
