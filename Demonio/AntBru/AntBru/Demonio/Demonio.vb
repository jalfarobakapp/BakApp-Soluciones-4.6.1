Imports DevComponents.DotNetBar
Imports BkSpecialPrograms
Imports System.IO

Public Class Demonio

    Dim _Fm_Demonio As Frm_Demonio_01
    'Dim _Fm_Demonio_DTEMonitor As Frm_Demonio_DTEMonitor
    Dim _Class_BaseBk As Class_Conectar_Base_BakApp
    Dim _Contador_Tiempo_Remotas As Integer = 0

    Public Property Pro_Fm_Demonio() As Frm_Demonio_01
        Get
            Return _Fm_Demonio
        End Get
        Set(ByVal value As Frm_Demonio_01)
            _Fm_Demonio = value
        End Set
    End Property

    'Public Property Pro_Frm_Demonio_DTEMonitor() As Frm_Demonio_DTEMonitor
    'Get
    'Return _Fm_Demonio_DTEMonitor
    'End Get
    'Set(ByVal value As Frm_Demonio_DTEMonitor)
    '        _Fm_Demonio_DTEMonitor = value
    'End Set
    'End Property

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Version_BkSpecialPrograms = FileVersionInfo.GetVersionInfo _
                                      (Application.StartupPath & "\BkSpecialPrograms.dll").FileVersion


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

        'Cadena_ConexionSQL_Server = "data source = SIERRALTA; initial catalog = SIERRALTA; user id = SIERRALTA; password = SIERRALTA"
        'Cadena_ConexionSQL_Server = Replace(Cadena_ConexionSQL_Server, " ", "@")
        'Cadena_ConexionSQL_Server = "data source = SIERRALTA; initial catalog = SMARTRADING; user id = SMARTRADING; password = SMARTRADING"

        'Dim _Ejecutar_Demonio As Boolean
        'Dim _Ejecutar_Demonio_DTE As Boolean

        If Environment.GetCommandLineArgs.Length > 1 Then

            Cadena_ConexionSQL_Server = Environment.GetCommandLineArgs(1)
            'MessageBoxEx.Show(Me, Cadena_ConexionSQL_Server, "Cadena", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Cadena_ConexionSQL_Server = Replace(Cadena_ConexionSQL_Server, "@", " ")
            'MessageBoxEx.Show(Me, Cadena_ConexionSQL_Server, "Cadena", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '_Ejecutar_Demonio = True
            '_Ejecutar_Demonio_DTE = True

            'Tiempo_Diablito.Start()

            'Sb_Ejecutar_Demonio()
            Sb_Ejecutar_Demonio2()

            'Dim Fm As New Frm_Demonio_01(Me)
            'Fm.ShowDialog(Me)
            'Fm.Dispose()

            'Application.ExitThread()

        Else

            Tiempo_Alerta.Start()

        End If

        'If _Ejecutar_Demonio Then
        '    Sb_Ejecutar_Demonio()
        '    Sb_Ejecutar_Demonio_DTE()
        'End If

    End Sub

    Sub Sb_Ejecutar_Demonio()

        _Class_BaseBk = New Class_Conectar_Base_BakApp(Me)

        If _Class_BaseBk.Pro_Existe_Base Then

            _Global_BaseBk = _Class_BaseBk.Pro_Row_Tabcarac.Item("Global_BaseBk")
            Sb_Sistema_Demonio(Me)

            Dim _Path = AppPath() & "\Data\" & RutEmpresa & "\Demonio"
            Dim _Datos_Conf As New Ds_Config_Picking

            If Not Directory.Exists(_Path) Then
                System.IO.Directory.CreateDirectory(_Path)
            End If

            _Datos_Conf.Clear()
            Dim exists = System.IO.File.Exists(_Path & "\Config_Local.xml")
            With _Datos_Conf
                If Not exists Then

                    Dim NewFila As DataRow
                    NewFila = _Datos_Conf.Tables("Tbl_Configuracion").NewRow

                    With NewFila

                        .Item("Impresora") = String.Empty
                        .Item("RutaImagen") = String.Empty

                    End With

                    .Tables("Tbl_Configuracion").Rows.Add(NewFila)

                    .WriteXml(_Path & "\Config_Local.xml")

                End If
            End With

            _Datos_Conf.Clear()
            _Datos_Conf.ReadXml(_Path & "\Config_Local.xml")

            Dim _Fila As DataRow = _Datos_Conf.Tables("Tbl_Configuracion").Rows(0)
            Dim _Ejecutar_Automaticamente As Boolean = NuloPorNro(_Fila.Item("Ejecutar_Automaticamente"), False)

            Dim Fm As New Frm_Demonio_01(Me)
            Fm.ShowDialog(Me)
            Fm.Dispose()

            Application.ExitThread()

        Else

            MessageBoxEx.Show(Me, "No es posible conectarse a la base de datos",
                          "Conexión", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Application.ExitThread()

        End If

    End Sub

    Sub Sb_Ejecutar_Demonio2()

        _Class_BaseBk = New Class_Conectar_Base_BakApp(Me)

        If _Class_BaseBk.Pro_Existe_Base Then

            _Global_BaseBk = _Class_BaseBk.Pro_Row_Tabcarac.Item("Global_BaseBk")
            Sb_Sistema_Demonio(Me)

            Dim _Path = AppPath() & "\Data\" & RutEmpresa & "\Demonio"
            Dim _Datos_Conf As New Ds_Config_Picking

            If Not Directory.Exists(_Path) Then
                System.IO.Directory.CreateDirectory(_Path)
            End If

            _Datos_Conf.Clear()
            Dim exists = System.IO.File.Exists(_Path & "\Config_Local.xml")
            With _Datos_Conf
                If Not exists Then

                    Dim NewFila As DataRow
                    NewFila = _Datos_Conf.Tables("Tbl_Configuracion").NewRow

                    With NewFila

                        .Item("Impresora") = String.Empty
                        .Item("RutaImagen") = String.Empty

                    End With

                    .Tables("Tbl_Configuracion").Rows.Add(NewFila)

                    .WriteXml(_Path & "\Config_Local.xml")

                End If
            End With

            _Datos_Conf.Clear()
            _Datos_Conf.ReadXml(_Path & "\Config_Local.xml")

            Dim _Fila As DataRow = _Datos_Conf.Tables("Tbl_Configuracion").Rows(0)
            Dim _Ejecutar_Automaticamente As Boolean = NuloPorNro(_Fila.Item("Ejecutar_Automaticamente"), False)

            Dim _CambioDeConfiguracion As Boolean

            _Global_EsDiablito = True

            Dim Fm As New Frm_Demonio_New
            Fm.ShowDialog(Me)
            _CambioDeConfiguracion = Fm.CambioDeConfiguracion
            Fm.Dispose()
            Fm = Nothing

            If _CambioDeConfiguracion Then

                Dim _Id As Integer = _Global_Row_EstacionBk.Item("Id")
                Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

                Dim Fm2 As New Frm_Demonio_Configuraciones(_Id, FUNCIONARIO)
                Fm2.ShowDialog(Me)
                Fm2.Dispose()

                Sb_Ejecutar_Demonio2()

            Else

                Application.ExitThread()

            End If

        Else

            MessageBoxEx.Show(Me, "No es posible conectarse a la base de datos",
                          "Conexión", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Application.ExitThread()

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

            'Sb_Ejecutar_Demonio()
            Sb_Ejecutar_Demonio2()

        Else

            Application.ExitThread()

        End If

        Application.ExitThread()

    End Sub

    Private Sub Notify_Demonio_DoubleClick(sender As Object, e As EventArgs) Handles Notify_Demonio.DoubleClick
        'ShowContextMenu(Menu_Contextual_Menu_Extra)
        'Sb_Demonio(True)
        Sb_Demonio()
    End Sub

    Private Sub Notify_Demonio_MouseClick(sender As Object, e As MouseEventArgs) Handles Notify_Demonio.MouseClick
        If e.Button = MouseButtons.Right Then
            ' ShowContextMenu(Menu_Contextual_Menu_Extra)
        End If
    End Sub

    Private Sub AbrirDemonioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AbrirDemonioToolStripMenuItem.Click
        Sb_Demonio()
    End Sub

    'Private Sub ConfigurarDemonioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConfigurarDemonioToolStripMenuItem.Click

    '    Dim _Row_Usuario_Autorizado As DataRow

    '    Dim FmP As New Frm_ValidarPermiso(Frm_ValidarPermiso.Tipo_Accion.Validar_Permiso, "Pick0011", True, False)
    '    FmP.Pro_Cerrar_Automaticamente = True
    '    FmP.ShowDialog(Me)
    '    Dim _Validar As Boolean = FmP.Pro_Permiso_Aceptado
    '    _Row_Usuario_Autorizado = FmP.Pro_RowUsuario
    '    FmP.Dispose()

    '    If _Validar Then

    '        Me.Notify_Demonio.Visible = False

    '        Dim Fm As New Frm_Demonio_01_Conf_Local(_Row_Usuario_Autorizado.Item("KOFU"))
    '        Fm.ShowInTaskbar = True
    '        Fm.ShowDialog(Me)
    '        Fm.Dispose()

    '        Sb_Ejecutar_Demonio()

    '    End If

    'End Sub

    Private Sub CerrarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CerrarToolStripMenuItem.Click

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

    'Private Sub Tiempo_Diablito_Tick(sender As Object, e As EventArgs) Handles Tiempo_Diablito.Tick

    '    Tiempo_Diablito.Stop()
    '    Sb_Ejecutar_Demonio()

    'End Sub

End Class
