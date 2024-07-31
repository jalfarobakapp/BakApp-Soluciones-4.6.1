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

        'Cadena_ConexionSQL_Server = "data source = VILLAR_PRUEBAS_EXT; initial catalog = RANDOM; user id = RANDOM; password = RANDOM"

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

        Sb_Ejecutar_diablito()

        AddHandler Switch_Sincronizacion.ValueChanged, AddressOf Switch_Sincronizacion_ValueChanged

    End Sub

    Sub Sb_Ejecutar_diablito()

        Try

            _Global_BaseBk = "BAKAPP_VH.dbo."

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

            With _Cl_ConfiguracionLocal.Configuracion.Ls_Conexiones.Item(0)
                Cadena_ConexionSQL_Server = _Cl_ConfiguracionLocal.Fx_CadenaConexion(.Host, .Puerto, .Basededatos, .Usuario, .Password)
                Sb_AddToLog("Conexión", "¡Conexión exitosa a la base de datos " & .Basededatos.ToString.Trim & "!", Txt_Log)
            End With

            With _Cl_ConfiguracionLocal.Configuracion.Ls_Conexiones.Item(1)
                _Cl_Sincroniza.Cadena_ConexionSQL_Server_Wms = _Cl_ConfiguracionLocal.Fx_CadenaConexion(.Host, .Puerto, .Basededatos, .Usuario, .Password)
                Sb_AddToLog("Conexión", "¡Conexión exitosa a la base de datos " & .Basededatos.ToString.Trim & "!", Txt_Log)
            End With

            Dtp_FechaRevision.Value = FechaDelServidor()
            Lbl_DiasRevNVV.Text = "Días para revisar NVV hacia atras " & _Cl_Sincroniza.ConfiguracionLocal.DiasRevNVV

            Switch_Sincronizacion.Value = True
            Switch_Sincronizacion.Enabled = True

            CircularPgrs.IsRunning = True
            Timer_Ejecutar.Interval = 1000 * 5
            Timer_Ejecutar.Start()
            Timer_Limpiar.Start()
            Timer_AjustarFecha.Start()
            Sb_AddToLog("Sincronizar", "Sincronización en ejecución.", Txt_Log)

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    Private Sub Timer_Ejecutar_Tick(sender As Object, e As EventArgs) Handles Timer_Ejecutar.Tick

        Timer_Ejecutar.Stop()

        If IsNothing(Cadena_ConexionSQL_Server) Then
            Return
        End If

        If Not Switch_Sincronizacion.Value Then
            CircularPgrs.IsRunning = False
            Me.Refresh()
            Return
        End If

        If String.IsNullOrWhiteSpace(Txt_Log.Text) Then

            With _Cl_ConfiguracionLocal.Configuracion.Ls_Conexiones.Item(0)
                Sb_AddToLog("Conexión", "¡Conexión exitosa a la base de datos " & .Basededatos.ToString.Trim & "!", Txt_Log)
            End With

            With _Cl_ConfiguracionLocal.Configuracion.Ls_Conexiones.Item(1)
                Sb_AddToLog("Conexión", "¡Conexión exitosa a la base de datos " & .Basededatos.ToString.Trim & "!", Txt_Log)
            End With

            Sb_AddToLog("Sincronizar", "Sincronización en ejecución.", Txt_Log)

        End If

        _FechaRevision = Dtp_FechaRevision.Value

        Dim _Dias As Integer = _Cl_ConfiguracionLocal.Configuracion.DiasRevNVV * -1
        Dim _FechaHasta As Date = _FechaRevision
        Dim _FechaDesde As Date = DateAdd(DateInterval.Day, _Dias, _FechaRevision)

        _Cl_Sincroniza.Sb_Ejecutar_Revision_IncorporarNVVAutomaticamenteAStem(Txt_Log, _FechaDesde, _FechaHasta)
        _Cl_Sincroniza.Sb_Ejecutar_Revision(Txt_Log, _FechaRevision)
        _Cl_Sincroniza.Sb_MarcarFacturadasPorFuera(Txt_Log)
        _Cl_Sincroniza.Sb_RevisarCanceladasLiberadas(Txt_Log, _FechaRevision)
        _Cl_Sincroniza.Sb_RevisarRezagadasSinFuncionarioQueFactura(Txt_Log)
        _Cl_Sincroniza.Sb_RevisarFacturadasConfirmadasSinCerrar(Txt_Log)
        '_Cl_Sincroniza.Sb_RevisarIngresadasRezagadas(Txt_Log)

        Switch_Sincronizacion.Value = True
        CircularPgrs.IsRunning = True

        Timer_Ejecutar.Start()

    End Sub

    Private Sub Btn_Conexion_Click(sender As Object, e As EventArgs) Handles Btn_Conexion.Click

        Timer_Ejecutar.Stop()

        Dim Fm As New Frm_Conexiones
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Sb_Ejecutar_diablito()

    End Sub

    Private Sub Btn_Limpiar_Click(sender As Object, e As EventArgs) Handles Btn_Limpiar.Click
        Txt_Log.Text = String.Empty
    End Sub

    Private Sub Switch_Sincronizacion_ValueChanged(sender As Object, e As EventArgs)

        CircularPgrs.IsRunning = Switch_Sincronizacion.Value

        If Switch_Sincronizacion.Value Then
            Sb_AddToLog("Sincronizar", "Sincronización en ejecución.", Txt_Log)
            Timer_Ejecutar.Start()
        Else
            Sb_AddToLog("Sincronizar", "Sincronización pausada por el usuario.", Txt_Log)
        End If

    End Sub

    Private Sub Timer_Limpiar_Tick(sender As Object, e As EventArgs) Handles Timer_Limpiar.Tick
        Timer_Limpiar.Stop()
        Sb_AddToLog("Conexión", "Revisando completadas para ver si hay alguna cancelada en WMS...", Txt_Log)
        _Cl_Sincroniza.Sb_RevisarCompletadasCanceladas(Txt_Log)
        Timer_Limpiar.Start()
    End Sub

    Private Sub Timer_AjustarFecha_Tick(sender As Object, e As EventArgs) Handles Timer_AjustarFecha.Tick
        Txt_Log.Text = String.Empty
        Dtp_FechaRevision.Value = Now.Date
        Sb_AddToLog("Sincronizar", "Se actualiza la fecha: " & Dtp_FechaRevision.Value, Txt_Log)
    End Sub
End Class
