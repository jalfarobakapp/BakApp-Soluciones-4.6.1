Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Frm_Sincronizador

    Dim _FechaRevision As DateTime
    Dim _Cl_Conexion As New Cl_Conexion
    Dim _Cl_Sincroniza As New Cl_Sincroniza
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().


        Cadena_ConexionSQL_Server = "data source = VILLAR_PRUEBAS_EXT; initial catalog = RANDOM; user id = RANDOM; password = RANDOM"

    End Sub

    Private Sub Frm_Sincronizador_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Txt_Log.ReadOnly = True
        CircularPgrs.IsRunning = False
        Sb_Ejecutar_diablito()
    End Sub

    Sub Sb_Ejecutar_diablito()

        Dtp_FechaRevision.Value = FechaDelServidor()

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

        CircularPgrs.IsRunning = True
        Timer_Ejecutar.Interval = 1000 * 5
        Timer_Ejecutar.Start()

    End Sub

    Private Sub Timer_Ejecutar_Tick(sender As Object, e As EventArgs) Handles Timer_Ejecutar.Tick

        Timer_Ejecutar.Stop()

        _FechaRevision = Dtp_FechaRevision.Value

        _Cl_Sincroniza.Sb_Ejecutar_Revision(Txt_Log, _FechaRevision)

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
End Class
