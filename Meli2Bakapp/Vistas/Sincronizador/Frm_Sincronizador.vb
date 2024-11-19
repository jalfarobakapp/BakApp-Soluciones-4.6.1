Imports BkSpecialPrograms
Imports DevComponents.DotNetBar
Public Class Frm_Sincronizador

    Dim _FechaRevision As DateTime
    Dim _Cl_ConfiguracionLocal As New Cl_ConfiguracionLocal
    Dim _Cl_Sincroniza As New Cl_Sincroniza
    Dim _Version As String
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_Sincronizador_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' el nombre del ejecutable y la extensión:
        _Version = System.IO.Path.GetFileName(Application.ExecutablePath)

        _Version = FileVersionInfo.GetVersionInfo _
                                   (Application.StartupPath & "\" & _Version).FileVersion

        Lbl_Estatus.Text = "Versión: " & _Version

        Txt_Log.ReadOnly = True
        CircularPgrs.IsRunning = False

        Timer_Limpiar.Interval = (1000 * 60) * 5
        Timer_AjustarFecha.Interval = (1000 * 60) * 30
        'Timer_CerrarConfirmadas.Interval = (1000 * 60) * 15

        Sb_Ejecutar_diablito()

    End Sub

    Sub Sb_Ejecutar_diablito()

        Try

            Dim _Mensaje As New LsValiciones.Mensajes

            Txt_Log.Text = String.Empty

            Sb_AddToLog("Conexión", "Revisando el archivo de conexión a las bases de datos...", Txt_Log)

            _Mensaje = _Cl_ConfiguracionLocal.Fx_LeerArchivoConexionJson(True)

            If Not _Mensaje.EsCorrecto Or _Mensaje.Id = 0 Then

                MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Sb_AddToLog("Conexión", "¡Error en la conexión", Txt_Log)
                Sb_AddToLog("Conexión", _Mensaje.Detalle, Txt_Log)
                Sb_AddToLog("Conexión", _Mensaje.Mensaje, Txt_Log)
                Switch_Sincronizacion.Value = False
                Switch_Sincronizacion.Enabled = False
                CircularPgrs.IsRunning = False

                Return

            End If

            _Cl_Sincroniza.ConfiguracionLocal = _Cl_ConfiguracionLocal.Configuracion

            _Global_BaseBk = _Cl_ConfiguracionLocal.Configuracion.Global_BaseBk & ".dbo."

            With _Cl_ConfiguracionLocal.Configuracion.Ls_Conexiones.Item(0)
                Cadena_ConexionSQL_Server = _Cl_ConfiguracionLocal.Fx_CadenaConexion(.Host, .Puerto, .Basededatos, .Usuario, .Password)
                Sb_AddToLog("Conexión", "Conexión exitosa a la base de datos " & .Basededatos.ToString.Trim, Txt_Log)
            End With

            With _Cl_ConfiguracionLocal.Configuracion.Ls_Conexiones.Item(1)
                _Cl_Sincroniza.Cadena_ConexionSQL_Server_Meli = _Cl_ConfiguracionLocal.Fx_CadenaConexion(.Host, .Puerto, .Basededatos, .Usuario, .Password)
                Sb_AddToLog("Conexión", "Conexión exitosa a la base de datos " & .Basededatos.ToString.Trim, Txt_Log)
            End With

            Dtp_FechaRevision.Value = FechaDelServidor()

            Switch_Sincronizacion.Value = True
            Switch_Sincronizacion.Enabled = True

            CircularPgrs.IsRunning = True
            Timer_Ejecutar.Interval = 1000 * 20
            Timer_Ejecutar.Start()
            Timer_Limpiar.Start()
            Timer_AjustarFecha.Start()
            Sb_AddToLog("Sincronizar", "Sincronización en ejecución.", Txt_Log)

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    Private Sub Btn_Configuraciones_Click(sender As Object, e As EventArgs) Handles Btn_Configuraciones.Click
        Timer_Ejecutar.Stop()

        Dim Fm As New Frm_Conexiones
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Sb_Ejecutar_diablito()
    End Sub

    Private Sub Timer_Ejecutar_Tick(sender As Object, e As EventArgs) Handles Timer_Ejecutar.Tick
        Timer_Ejecutar.Stop()
        _Cl_Sincroniza.Sb_Revisar_Pedidos(Txt_Log, Dtp_FechaRevision.Value, 10)
        Timer_Ejecutar.Start()
    End Sub

    Private Sub Timer_Limpiar_Tick(sender As Object, e As EventArgs) Handles Timer_Limpiar.Tick
        Timer_Limpiar.Stop()
        'Sb_AddToLog("Conexión", "Revisando completadas para ver si hay alguna cancelada en WMS...", Txt_Log)
        Timer_Limpiar.Start()
    End Sub

    Private Sub Timer_AjustarFecha_Tick(sender As Object, e As EventArgs) Handles Timer_AjustarFecha.Tick
        Txt_Log.Text = String.Empty
        Dtp_FechaRevision.Value = Now.Date
        Sb_AddToLog("Sincronizar", "Se actualiza la fecha: " & Dtp_FechaRevision.Value, Txt_Log)
    End Sub
End Class
