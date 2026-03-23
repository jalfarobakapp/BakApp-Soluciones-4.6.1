Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Frm_Sincronizador

    Dim _FechaRevision As DateTime
    Dim _Cl_ConfiguracionLocal As New Cl_ConfiguracionLocal
    Dim _CL_ProcesaDatos As New Cl_ProcesaDatos
    ' Renombrado a Cl_GeneraDespachos para coincidir con la nueva clase
    Dim _Cl_GeneraDespachos As New Cl_GeneraDespachos
    Dim _Version As String
    Public Property _Global_BaseBk As String
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

    End Sub

    Private Sub Frm_Sincronizador_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' el nombre del ejecutable y la extensión:
        _Version = System.IO.Path.GetFileName(Application.ExecutablePath)

        _Version = FileVersionInfo.GetVersionInfo _
                                   (Application.StartupPath & "\" & _Version).FileVersion

        Lbl_Estatus.Text = "Versión: " & _Version

        Txt_Log.ReadOnly = True
        CircularPgrs.IsRunning = False

        Timer_Limpiar.Interval = (1000 * 60) * 5   ' Limpieza del log cada 5 min
        Timer_AjustarFecha.Interval = (1000 * 60) * 30 ' Ajuste de fecha cada 30 min

        Sb_Ejecutar_diablito()

    End Sub

    Sub Sb_Ejecutar_diablito()

        Try

            Dim _Mensaje As New LsValiciones.Mensajes

            Txt_Log.Text = String.Empty

            Sb_AddToLog("Conexión", "Revisando el archivo de conexión a la base de datos...", Txt_Log)

            _Mensaje = _Cl_ConfiguracionLocal.Fx_LeerArchivoConexionJson(True)

            If Not _Mensaje.EsCorrecto Or _Mensaje.Id = 0 Then

                MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Sb_AddToLog("Conexión", "¡Error en la conexión!", Txt_Log)
                Sb_AddToLog("Conexión", _Mensaje.Detalle, Txt_Log)
                Sb_AddToLog("Conexión", _Mensaje.Mensaje, Txt_Log)
                Switch_Sincronizacion.Value = False
                Switch_Sincronizacion.Enabled = False
                CircularPgrs.IsRunning = False

                Return

            End If

            _Cl_GeneraDespachos.ConfiguracionLocal = _Cl_ConfiguracionLocal.Configuracion

            _Global_BaseBk = _Cl_ConfiguracionLocal.Configuracion.Global_BaseBk & ".dbo."

            ' SOLO SE CARGA LA CONEXIÓN 0 (Principal) YA QUE TODO ESTÁ EN EL MISMO SERVIDOR AHORA
            With _Cl_ConfiguracionLocal.Configuracion.Ls_Conexiones.Item(0)
                Cadena_ConexionSQL_Server = _Cl_ConfiguracionLocal.Fx_CadenaConexion(.Host, .Puerto, .Basededatos, .Usuario, .Password)
                Sb_AddToLog("Conexión", "Conexión exitosa a la base de datos " & .Basededatos.ToString.Trim, Txt_Log)
            End With

            Dtp_FechaRevision.Value = FechaDelServidor()

            Switch_Sincronizacion.Value = True
            Switch_Sincronizacion.Enabled = True

            CircularPgrs.IsRunning = True
            Timer_Ejecutar.Interval = 1000 * 10 ' Configurado a 30 segundos (Ajustable)
            Timer_Ejecutar.Start()
            Timer_Limpiar.Start()
            Timer_AjustarFecha.Start()
            Sb_AddToLog("Sincronizador", "Demonio de Despachos B2B en ejecución.", Txt_Log)

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    Private Sub Btn_Configuraciones_Click(sender As Object, e As EventArgs) Handles Btn_Configuraciones.Click
        Timer_Ejecutar.Stop()

        Dim Fm As New Frm_Configuracion
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Sb_Ejecutar_diablito()
    End Sub

    Private Sub Timer_Ejecutar_Tick(sender As Object, e As EventArgs) Handles Timer_Ejecutar.Tick

        ' Detenemos el timer mientras procesa para que no se pisen los procesos si hay muchos registros
        Timer_Ejecutar.Stop()

        Try
            ' Única llamada necesaria al nuevo motor de despachos
            ' Toma un Top de 50 registros por ciclo para no saturar la memoria
            '_Cl_GeneraDespachos.Sb_Procesar_Despachos_ECommerce(Txt_Log, 50)
            'Sb_AddToLog("Tick de Prueba:" & _CL_ProcesaDatos.Fx_Testear_Conexion(), 50)
            _CL_ProcesaDatos.Sb_Procesar_Despachos_ECommerce(Txt_Log)

        Catch ex As Exception
            ' Evita que el programa crashee si se cae el servidor SQL momentáneamente
            Sb_AddToLog("Error Demonio", "Fallo en ejecución: " & ex.Message, Txt_Log)
        End Try

        ' Reanudamos el timer
        Timer_Ejecutar.Start()

    End Sub

    Private Sub Timer_Limpiar_Tick(sender As Object, e As EventArgs) Handles Timer_Limpiar.Tick
        Timer_Limpiar.Stop()

        ' Limpiamos el texto del log cada cierto tiempo para que el programa no consuma toda la RAM
        Txt_Log.Text = String.Empty
        Sb_AddToLog("Sincronizador", "Limpieza de Log automática.", Txt_Log)

        Timer_Limpiar.Start()
    End Sub

    Private Sub Timer_AjustarFecha_Tick(sender As Object, e As EventArgs) Handles Timer_AjustarFecha.Tick
        Dtp_FechaRevision.Value = Now.Date
        Sb_AddToLog("Sincronizador", "Se actualiza la fecha de revisión: " & Dtp_FechaRevision.Value, Txt_Log)
    End Sub

    Private Sub Bar1_ItemClick(sender As Object, e As EventArgs) Handles Bar1.ItemClick

    End Sub

    Private Sub Switch_Sincronizacion_ValueChanged(sender As Object, e As EventArgs) Handles Switch_Sincronizacion.ValueChanged
        If Timer_Ejecutar.Enabled Then
            Timer_Ejecutar.Stop()
            CircularPgrs.IsRunning = False
            Sb_AddToLog("Sincronizador", "Demonio de Despachos detenido por el usuario.", Txt_Log)
        Else
            Timer_Ejecutar.Start()
            CircularPgrs.IsRunning = True
            Sb_AddToLog("Sincronizador", "Demonio de Despachos reanudado por el usuario.", Txt_Log)
        End If
    End Sub

    Private Sub Btn_Limpiar_Click(sender As Object, e As EventArgs) Handles Btn_Limpiar.Click
        Timer_Limpiar.Stop()

        ' Limpiamos el texto del log cada cierto tiempo para que el programa no consuma toda la RAM
        Txt_Log.Text = String.Empty
        Sb_AddToLog("Sincronizador", "Limpieza de Log manual.", Txt_Log)

        Timer_Limpiar.Start()
    End Sub
End Class
