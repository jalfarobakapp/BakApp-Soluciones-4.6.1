Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Frm_Sincronizador

    Dim _FechaRevision As DateTime
    Dim _Cl_Conexion As New Cl_Conexion
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

        Dim _Arr_Filtro(,) As String = {{"1", "Hoy"},
                                        {"3", "3 días:"},
                                        {"7", "7 días"},
                                        {"31", "1 Mes"}}
        Sb_Llenar_Combos(_Arr_Filtro, Cmb_Cantidad_Dias_Ultima_Venta)
        Cmb_Cantidad_Dias_Ultima_Venta.SelectedValue = "7"

        Sb_Ejecutar_diablito()

    End Sub

    Sub Sb_Ejecutar_diablito()

        Try

            _Global_BaseBk = "BAKAPP_VH.dbo."

            Dim _Mensaje As New LsValiciones.Mensajes

            Txt_Log.Text = String.Empty

            Sb_AddToLog("Conexión", "Revisando el archivo de conexión a las bases de datos...", Txt_Log)

            _Mensaje = _Cl_Conexion.Fx_LeerArchivoConexionJson(True)

            If Not _Mensaje.EsCorrecto Or _Mensaje.Id = 0 Then

                MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Sb_AddToLog("Conexión", "¡Error en la conexión", Txt_Log)
                Sb_AddToLog("Conexión", _Mensaje.Detalle, Txt_Log)
                Sb_AddToLog("Conexión", _Mensaje.Mensaje, Txt_Log)

                Return

            End If

            Cadena_ConexionSQL_Server = _Cl_Conexion.Fx_CadenaConexion(_Cl_Conexion.Ls_Conexiones(0).Host,
                                       _Cl_Conexion.Ls_Conexiones(0).Puerto,
                                       _Cl_Conexion.Ls_Conexiones(0).Basededatos,
                                       _Cl_Conexion.Ls_Conexiones(0).Usuario,
                                       _Cl_Conexion.Ls_Conexiones(0).Password)

            Sb_AddToLog("Conexión", "¡Conexión exitosa a la base de datos " & _Cl_Conexion.Ls_Conexiones(0).Basededatos.ToString.Trim & "!", Txt_Log)

            _Cl_Sincroniza.Cadena_ConexionSQL_Server_Wms = _Cl_Conexion.Fx_CadenaConexion(_Cl_Conexion.Ls_Conexiones(1).Host,
                                                                                          _Cl_Conexion.Ls_Conexiones(1).Puerto,
                                                                                          _Cl_Conexion.Ls_Conexiones(1).Basededatos,
                                                                                          _Cl_Conexion.Ls_Conexiones(1).Usuario,
                                                                                          _Cl_Conexion.Ls_Conexiones(1).Password)

            Sb_AddToLog("Conexión", "¡Conexión exitosa a la base de datos " & _Cl_Conexion.Ls_Conexiones(1).Basededatos.ToString.Trim & "!", Txt_Log)

            Dtp_FechaRevision.Value = FechaDelServidor()

            CircularPgrs.IsRunning = True
            Timer_Ejecutar.Interval = 1000 * 5
            Timer_Ejecutar.Start()
            Timer_Limpiar.Start()

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    Private Sub Timer_Ejecutar_Tick(sender As Object, e As EventArgs) Handles Timer_Ejecutar.Tick

        Timer_Ejecutar.Stop()

        _FechaRevision = Dtp_FechaRevision.Value

        Dim _Dias As Integer = Cmb_Cantidad_Dias_Ultima_Venta.SelectedValue * -1
        Dim _FechaHasta As Date = _FechaRevision
        Dim _FechaDesde As Date = DateAdd(DateInterval.Day, _Dias, _FechaRevision)

        _Cl_Sincroniza.Sb_Ejecutar_Revision_IncorporarNVVAutomaticamenteAStem(Txt_Log, _FechaDesde, _FechaHasta)
        _Cl_Sincroniza.Sb_Ejecutar_Revision(Txt_Log, _FechaRevision)
        _Cl_Sincroniza.Sb_MarcarFacturadasPorFuera(Txt_Log, _FechaRevision)
        _Cl_Sincroniza.Sb_RevisarCanceladasLiberadas(Txt_Log, _FechaRevision)

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

    Private Sub Switch_Sincronizacion_ValueChanged(sender As Object, e As EventArgs) Handles Switch_Sincronizacion.ValueChanged
        If Switch_Sincronizacion.Value Then
            CircularPgrs.IsRunning = False
            Timer_Ejecutar.Stop()
        Else
            CircularPgrs.IsRunning = True
            Timer_Ejecutar.Start()
        End If
    End Sub

    Private Sub Timer_Limpiar_Tick(sender As Object, e As EventArgs) Handles Timer_Limpiar.Tick
        Timer_Limpiar.Stop()
        Sb_AddToLog("Conexión", "Revisando completadas para ver si hay alguna cancelada en WMS...", Txt_Log)
        _Cl_Sincroniza.Sb_RevisarCompletadasCanceladas(Txt_Log)
        Timer_Limpiar.Start()
    End Sub

End Class
