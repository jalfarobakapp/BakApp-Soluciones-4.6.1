Imports BkSpecialPrograms

Public Class Frm_Sincronizador

    Dim _Conexiones As List(Of Conexion)
    Dim _FechaRevision As DateTime

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().


        Cadena_ConexionSQL_Server = "data source = VILLAR_PRUEBAS_EXT; initial catalog = RANDOM; user id = RANDOM; password = RANDOM"

    End Sub

    Private Sub Frm_Sincronizador_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dtp_FechaRevision.Value = FechaDelServidor()

        _Global_BaseBk = "BAKAPP_VH.dbo."
        _Conexiones = New List(Of Conexion)

        CircularPgrs.IsRunning = True

        Timer_Ejecutar.Interval = 1000 * 5

        Timer_Ejecutar.Start()

    End Sub

    Private Sub Timer_Ejecutar_Tick(sender As Object, e As EventArgs) Handles Timer_Ejecutar.Tick
        Timer_Ejecutar.Stop()
        _FechaRevision = Dtp_FechaRevision.Value
        Dim _Cl_Sincriniza As New Cl_Sincroniza
        _Cl_Sincriniza.Sb_Ejecutar_Revision(Txt_Log, _FechaRevision)

        Timer_Ejecutar.Start()
    End Sub

    Sub Sb_Ejecutar_diablito()



    End Sub

End Class
