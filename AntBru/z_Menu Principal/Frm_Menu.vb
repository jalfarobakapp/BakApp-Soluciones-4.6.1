Imports DevComponents.DotNetBar
Imports BkSpecialPrograms
Imports System.IO
Imports DevComponents.DotNetBar.Metro

Public Class Frm_Menu
    Inherits MetroAppForm

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Ds_Estilo As New DatosBakApp
    Dim DatosConex As New ConexionBK
    Dim Directorio As String = Application.StartupPath & "\Data\"

    Dim _Dir_Local As String = Application.StartupPath & "\Data\Configuracion_Local"
    Dim _Mi_IP = getIp()
    Dim _NombreEquipo = UCase(System.Net.Dns.GetHostName)

    Dim _Fm_Demonio As Frm_Demonio_01

    Dim _Tiempo_Notificacion As Integer = 1000 * 60

    Dim _Contador_Tiempo_Remotas As Integer = 0
    Dim _Contador_Tiempo_SolComProd As Integer = 0


    Public Property Pro_Fm_Demonio() As Frm_Demonio_01
        Get
            Return _Fm_Demonio
        End Get
        Set(ByVal value As Frm_Demonio_01)
            _Fm_Demonio = value
        End Set
    End Property

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' el nombre del ejecutable y la extensión:
        _Global_Nombre_BakApp_Soluciones = System.IO.Path.GetFileName(Application.ExecutablePath)

        _Version_BakApp = FileVersionInfo.GetVersionInfo _
                                   (Application.StartupPath & "\" & _Global_Nombre_BakApp_Soluciones).FileVersion

        _Version_BkSpecialPrograms = FileVersionInfo.GetVersionInfo _
                                       (Application.StartupPath & "\BkSpecialPrograms.dll").FileVersion

        _Global_Nombre_BakApp_Soluciones = Replace(_Global_Nombre_BakApp_Soluciones, ".exe", "")

        'Sb_Revisar_Estilo("")

        Select Case _Global_Nombre_BakApp_Soluciones
            Case "BakApp_Soluciones2"
                _Global_Nombre_BakApp_Notificaciones = "BakApp_Notificaciones2"
                _Global_Nombre_BakApp_Demonio = "BakApp_Demonio2"
                _Global_Nombre_BakApp_DTEMonitor = "BakApp_DTEMonitor2"
                _Global_Nombre_BakApp_Demonio_Impresion = "BakApp_Demonio_Impresion2"
            Case "BakApp_Soluciones3"
                _Global_Nombre_BakApp_Notificaciones = "BakApp_Notificaciones3"
                _Global_Nombre_BakApp_Demonio = "BakApp_Demonio3"
                _Global_Nombre_BakApp_DTEMonitor = "BakApp_DTEMonitor3"
                _Global_Nombre_BakApp_Demonio_Impresion = "BakApp_Demonio_Impresion3"
            Case "BakApp_Soluciones4"
                _Global_Nombre_BakApp_Notificaciones = "BakApp_Notificaciones4"
                _Global_Nombre_BakApp_Demonio = "BakApp_Demonio4"
                _Global_Nombre_BakApp_DTEMonitor = "BakApp_DTEMonitor4"
                _Global_Nombre_BakApp_Demonio_Impresion = "BakApp_Demonio_Impresion4"
            Case "BakApp_Soluciones5"
                _Global_Nombre_BakApp_Notificaciones = "BakApp_Notificaciones5"
                _Global_Nombre_BakApp_Demonio = "BakApp_Demonio5"
                _Global_Nombre_BakApp_DTEMonitor = "BakApp_DTEMonitor5"
                _Global_Nombre_BakApp_Demonio_Impresion = "BakApp_Demonio_Impresion5"
            Case Else
                _Global_Nombre_BakApp_Notificaciones = "BakApp_Notificaciones"
                _Global_Nombre_BakApp_Demonio = "BakApp_Demonio"
                _Global_Nombre_BakApp_DTEMonitor = "BakApp_DTEMonitor"
                _Global_Nombre_BakApp_Demonio_Impresion = "BakApp_Demonio_Impresion"
        End Select


        Dim ejecutando As Process() = Process.GetProcessesByName(_Global_Nombre_BakApp_Notificaciones)

        If ejecutando.Length > 0 Then

            For Each prog As Process In Process.GetProcesses
                If UCase(prog.ProcessName) = UCase(_Global_Nombre_BakApp_Notificaciones) Then
                    prog.Kill()
                    Exit For
                End If
            Next

        End If

    End Sub

    Private Sub Frm_Menu_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim ejecutando As Process() = Process.GetProcessesByName(_Global_Nombre_BakApp_Soluciones)

        If ejecutando.Length > 1 Then

            MessageBoxEx.Show(Me, "El sistema ya esta en ejecución", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End

        Else

            _Global_Frm_Menu = Me

            _Global_Version_BakApp = _Version_BakApp
            _Configuracion_Regional_()
            Sb_Iniciar_Sistema(False)
            LvlVersion.Text = "Versión:" & _Version_BakApp & ", Empresa: " & Trim(RazonEmpresa)

        End If

    End Sub

    Private Sub BtnCompras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim Nro = 22

        If Fx_Tiene_Permiso(Me, Nro) Then

            Dim UserControl1 As Modulo_Compras = Nothing
            UserControl1 = New Modulo_Compras(Me)
            Me.ShowModalPanel(UserControl1, DevComponents.DotNetBar.Controls.eSlideSide.Left)
        Else
            MensajeSinPermiso(Nro)
        End If

    End Sub

    Function VisualizarFormulario(ByVal Formulario As Object,
                                  ByVal FormularioPadre As Form,
                                  Optional ByVal VerEnShowDialong As Boolean = True,
                                  Optional ByVal EsMDI As Boolean = False
                                  )

        If EsMDI = True Then
            Formulario.MdiParent = FormularioPadre
            If Formulario Is Nothing Then
                Formulario.Show()
            ElseIf Not Formulario.Visible Then
                Formulario.Show()
            Else
                Formulario.Focus()
            End If
        Else

            If VerEnShowDialong = True Then
                If Formulario Is Nothing Then
                    Formulario.ShowDialog(FormularioPadre)
                ElseIf Not Formulario.Visible Then
                    Formulario.ShowDialog(FormularioPadre)
                Else
                    Formulario.Focus()
                End If
            Else
                If Formulario Is Nothing Then
                    Formulario.Show()
                ElseIf Not Formulario.Visible Then
                    Formulario.Show()
                Else
                    Formulario.Focus()
                End If
            End If
        End If

        Return True

    End Function

    Private Sub BtnCambioPassAdmin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCambioPassAdmin.Click
        Dim NewPanel As Clave_Administrador = Nothing
        NewPanel = New Clave_Administrador(Me)
        Me.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

    Private Sub Btn_OcultarPr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Tiempo_Espera_Notificacion.Enabled = False
        Dim Nro As String = "Prod004"
        If Fx_Tiene_Permiso(Me, Nro) Then
            Dim Frm_OcultarPr As New Frm_OcultarPr
            Frm_OcultarPr.ShowDialog(Me)
        Else
            MensajeSinPermiso(Nro)
        End If
        'Tiempo_Espera_Notificacion.Enabled = True
    End Sub

    Private Sub BtnCerrarSistema_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrarSistema.Click
        Me.Close()
    End Sub

    Private Sub AppCommandTheme_Executed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AppCommandTheme.Executed

        Dim source As ICommandSource = TryCast(sender, ICommandSource)

        If TypeOf source.CommandParameter Is String Then

            Dim style As eStyle = CType(System.Enum.Parse(GetType(eStyle), source.CommandParameter.ToString()), eStyle)

            style = eStyle.VisualStudio2010Blue
            'style = eStyle.VisualStudio2012Dark

            ' Using StyleManager change the style and color tinting

            If StyleManager.IsMetro(style) Then

                ' More customization is needed for Metro
                ' Capitalize App Button and tab
                ''buttonFile.Text = buttonFile.Text.ToUpper()
                ''For Each item As BaseItem In RibbonControl.Items
                ' Ribbon Control may contain items other than tabs so that needs to be taken in account
                ''Dim tab As RibbonTabItem = TryCast(item, RibbonTabItem)
                ''If tab IsNot Nothing Then
                ''TAB.Text = TAB.Text.ToUpper()
                ''End If
                ''Next item

                ''buttonFile.BackstageTabEnabled = True ' Use Backstage for Metro

                ''ribbonControl1.RibbonStripFont = New System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))

                If style = eStyle.Metro Then
                    StyleManager.MetroColorGeneratorParameters = DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters.DarkBlue
                End If

                ' Adjust size of switch button to match Metro styling
                ''switchButtonItem1.SwitchWidth = 12
                ''switchButtonItem1.ButtonWidth = 42
                ''switchButtonItem1.ButtonHeight = 19

                StyleManager.Style = style ' BOOM

                StyleManager.ChangeStyle(style, Color.Blue)

                Dim StrColor As Color = Color.Blue

                Dim Clr = StrColor.ToArgb()
                Dim Estilo As eStyle = style
                Dim NombreBoton = sender.Name


                'Consulta_sql = "Update Tmp_Conf_Local Set Thema = '" & Estilo & "', Color = '" & Clr &
                '               "', NombreBotonEstilo = '" & NombreBoton & "'" & vbCrLf &
                '               "Where Modulo = 'Thema'"
                'Ej_consulta_IDUaccess(Consulta_sql)


            Else
                ' If previous style was Metro we need to update other properties as well
                If StyleManager.IsMetro(StyleManager.Style) Then
                    ''ribbonControl1.RibbonStripFont = Nothing
                    ' Fix capitalization App Button and tab
                    ''buttonFile.Text = ToTitleCase(buttonFile.Text)
                    ''For Each item As BaseItem In RibbonControl.Items
                    ' Ribbon Control may contain items other than tabs so that needs to be taken in account
                    ''Dim tab As RibbonTabItem = TryCast(item, RibbonTabItem)
                    ''If tab IsNot Nothing Then
                    ''TAB.Text = ToTitleCase(TAB.Text)
                    ''End If
                    ''Next item
                    ' Adjust size of switch button to match Office styling
                    ''switchButtonItem1.SwitchWidth = 28
                    ''switchButtonItem1.ButtonWidth = 62
                    ''switchButtonItem1.ButtonHeight = 20
                End If

                StyleManager.ChangeStyle(style, Color.Empty)

                Dim StrColor As Color = Color.Empty

                Dim Clr = StrColor.ToArgb()
                Dim Estilo As eStyle = style
                Dim NombreBoton = sender.Name


                'Consulta_sql = "Update Tmp_Conf_Local Set Thema = '" & Estilo & "', Color = '" & Clr &
                '               "', NombreBotonEstilo = '" & NombreBoton & "'" & vbCrLf &
                '               "Where Modulo = 'Thema'"
                'Ej_consulta_IDUaccess(Consulta_sql)

                If style = eStyle.Office2007Black OrElse style = eStyle.Office2007Blue OrElse style = eStyle.Office2007Silver OrElse style = eStyle.Office2007VistaGlass Then
                    ''buttonFile.BackstageTabEnabled = False
                Else
                    ''buttonFile.BackstageTabEnabled = True
                End If

            End If

        ElseIf TypeOf source.CommandParameter Is Color Then

            If StyleManager.IsMetro(StyleManager.Style) Then
                StyleManager.MetroColorGeneratorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(Color.White, CType(source.CommandParameter, Color))
            Else
                StyleManager.ColorTint = CType(source.CommandParameter, Color)
            End If

        End If

        'StyleManager.MetroColorGeneratorParameters = _
        'New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(Color.White, _
        '                                                                            buttonStyleCustom.CommandParameter)
        'StyleManager1.Style = Estilo
        'StyleManager.MetroColorGeneratorParameters = _
        '      New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(Color.White, _
        '                                Color.FromArgb(Clr))

    End Sub

#Region "Automatic Color Scheme creation based on the selected color table"
    Private m_ColorSelected As Boolean = False
    Private m_BaseStyle As eStyle = eStyle.Metro

    Private Sub buttonStyleCustom_SelectedColorChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonStyleCustom.SelectedColorChanged

        m_ColorSelected = True ' Indicate that color was selected for buttonStyleCustom_ExpandChange method
        buttonStyleCustom.CommandParameter = buttonStyleCustom.SelectedColor

        Dim StrColor As Color = buttonStyleCustom.CommandParameter

        Dim _Color = StrColor.ToArgb()
        Dim _Estilo As eStyle = m_BaseStyle

        _Ds_Estilo.Clear()

        'Sb_Actualizar_Estilo(_Dir_Local, _Ds_Estilo, _Estilo, _Estilo.ToString, _Color)

        'Color.FromArgb(Str)

    End Sub

    Private Sub buttonStyleCustom_ColorPreview(ByVal sender As System.Object, ByVal e As DevComponents.DotNetBar.ColorPreviewEventArgs) Handles buttonStyleCustom.ColorPreview
        If StyleManager.IsMetro(StyleManager.Style) Then
            Dim baseColor As Color = e.Color
            StyleManager.MetroColorGeneratorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(Color.White, baseColor)
        Else
            StyleManager.ColorTint = e.Color
        End If
    End Sub

    Private Sub buttonStyleCustom_ExpandChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonStyleCustom.ExpandChange
        If buttonStyleCustom.Expanded Then
            ' Remember the starting color scheme to apply if no color is selected during live-preview
            m_ColorSelected = False
            m_BaseStyle = StyleManager.Style
        Else
            If Not m_ColorSelected Then
                If StyleManager.IsMetro(StyleManager.Style) Then
                    StyleManager.MetroColorGeneratorParameters = DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters.Default
                Else
                    StyleManager.ChangeStyle(m_BaseStyle, Color.Empty)
                End If
            End If
        End If
    End Sub
#End Region

    Private Sub Frm_Menu_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        If MessageBoxEx.Show(Me, "¿Desea salir del sistema?", "Cerrar Sistema",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Stop) = System.Windows.Forms.DialogResult.Yes Then

            Sb_Cerrar_Sistema(True)

        Else
            e.Cancel = True
        End If

    End Sub

    Private Sub BtnActProdSierralta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Consulta_sql = "Insert into W_PRODUSCTOS_RD (KOPR,NOKOPR,NOKOPR_RD)" & vbCrLf &
                       "SELECT KOPR,NOKOPR,NOKOPR FROM MAEPR WHERE KOPR NOT IN (SELECT KOPR FROM W_PRODUSCTOS_RD)" & vbCrLf &
                       "AND TIPR = 'FPN'"

        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Actualizar productos Post-Venta BakApp", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub BtnUnificarProductos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim Nro As String = "Prod006"
        If Fx_Tiene_Permiso(Me, Nro) Then
            Dim Frm_UnificacionProducto As New Frm_UnificacionProducto
            Frm_UnificacionProducto.ShowInTaskbar = False
            Frm_UnificacionProducto.ShowDialog(Me)
        End If

    End Sub

    Private Sub BtnCodBusquedAvanzada_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim Nro As String = "Prod009"
        If Fx_Tiene_Permiso(Me, Nro) Then

            Dim FrmBa As New Frm_MtCreaProd_01_IngBusqEspecial

            FrmBa.ShowInTaskbar = False
            FrmBa.ShowDialog(Me)

        Else
            MensajeSinPermiso(Nro)
        End If

    End Sub

    Private Sub BtnCompras_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If Fx_Tiene_Permiso(Me, 22) Then

            Dim UserControl1 As Modulo_Compras = Nothing
            UserControl1 = New Modulo_Compras(Me)
            Me.ShowModalPanel(UserControl1, DevComponents.DotNetBar.Controls.eSlideSide.Left)

        End If
    End Sub


    Sub Sb_Iniciar_Sistema(ByVal _Cambio_de_base As Boolean)

        Dim exists As Boolean

        LblModalidad.Text = String.Empty

        If Not Directory.Exists(Directorio) Then
            System.IO.Directory.CreateDirectory(Directorio)
        End If

        exists = System.IO.File.Exists(Directorio & "Conexiones.xml")

        If Not exists Then
            DatosConex.WriteXml(Directorio & "Conexiones.xml")
            MessageBoxEx.Show(Me, "Arvhico XML creado correctamente", "Crear XML de Conexión",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)
            End
        End If


        Dim _Tbl = New DataTable
        DatosConex.Clear()
        DatosConex.ReadXml(Directorio & "Conexiones.xml")
        _Tbl = DatosConex.Tables("CnBakApp")

        If _Tbl.Rows.Count = 0 Then

            Dim NewPanel As Crear_Conexion = Nothing
            NewPanel = New Crear_Conexion(Me)
            NewPanel._Primera_Conexion = True
            Me.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)

        ElseIf _Tbl.Rows.Count = 1 Then

            RutEmpresaActiva = _Tbl.Rows(0).Item("Rut")

            _Global_NombreConexion = _Tbl.Rows(0).Item("NombreConexion")
            Cadena_ConexionSQL_Server = Fx_CadenaConexionSQL(_Global_NombreConexion, DatosConex)

            _Tbl.Rows(0).Item("Conectado") = True

            DatosConex.WriteXml(Directorio & "Conexiones.xml")

            If Fx_Conectar_Empresa(Me, True) Then

                Dim _Row_Estacion = Fx_Row_Sesion_Star(Me)

                If Fx_Buscar_Actualizacion(Me) Then
                    Sb_Cerrar_Sistema(False)
                End If

                If Not IsNothing(_Row_Estacion) Then

                    Dim _TipoEstacion As String = Trim(_Row_Estacion.Item("TipoEstacion"))

                    Select Case _TipoEstacion
                        Case "Cd"
                            Sb_CashDro(Me)
                            Sb_Cerrar_Sistema(False)
                            End
                        Case "Dfa"
                            Sb_Produccion_Mesones_DFA()
                            End
                        Case "OT1"
                            Sb_IngresoGRIProduccion()
                            End
                        Case Else
                            Dim NewPanel As Login = Nothing
                            NewPanel = New Login(Me)
                            NewPanel._Inicio_Sesion = True
                            Me.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)
                    End Select

                End If
            Else
                End
            End If

        Else

            Dim NewPanel As Empresas_conectadas = Nothing
            NewPanel = New Empresas_conectadas(Me, _Cambio_de_base)
            Me.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)

        End If

    End Sub

    Private Sub BtnMenuPrincipal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMenuPrincipal.Click
        Dim NewPanel As Menu = Nothing
        NewPanel = New Menu(Me, False)
        Me.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

    Private Sub Btn_Licencia_Sistema_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Licencia_Sistema.Click
        Dim Fm As New Frm_Licencia_Empresa
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub

    Sub Sb_Revisar_Estilo_Old(Optional ByVal _Estilo As eStyle = eStyle.Metro,
                              Optional ByVal _Color As Integer = -16748352)

        If Not Directory.Exists(_Dir_Local) Then
            System.IO.Directory.CreateDirectory(_Dir_Local)
        End If

        Dim _Existe = System.IO.File.Exists(_Dir_Local & "Estilo.xml")

        If Not _Existe Then
            Sb_Actualizar_Estilo(_Dir_Local, _Ds_Estilo, _Estilo, _Estilo.ToString, _Color)
        End If

        _Ds_Estilo.Clear()
        _Ds_Estilo.ReadXml(_Dir_Local & "\Estilo.xml")

        Dim _Cod_Estilo = _Ds_Estilo.Tables("Themas").Rows(0).Item("Cod_Estilo")
        Dim _Nombre_Estilo = _Ds_Estilo.Tables("Themas").Rows(0).Item("Nombre_Estilo")
        _Color = _Ds_Estilo.Tables("Themas").Rows(0).Item("Color")


        'StyleManager1.Style = _Estilo
        'StyleManager1.MetroColorGeneratorParameters =
        '      New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(Color.White,
        '                                Color.FromArgb(_Color))

    End Sub

    Sub Sb_Actualizar_Estilo(ByVal _Directorio As String,
                             ByVal _Ds As DataSet,
                             ByVal _Thema As String,
                             ByVal _Estilo As String,
                             ByVal _Color As Integer)

        Dim NewFila As DataRow
        NewFila = _Ds.Tables("Themas").NewRow
        With NewFila
            .Item("Cod_Estilo") = _Thema
            .Item("Color") = _Color
            .Item("Nombre_Estilo") = _Estilo
        End With

        _Ds.Tables("Themas").Rows.Add(NewFila)
        _Ds.WriteXml(_Directorio & "\Estilo.xml")

    End Sub

    Private Sub Btn_Permisos_de_usuarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Permisos_de_usuarios.Click
        Dim Fm As New Frm_Permisos_Usuario_Lista
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub

    Private Sub Btn_Configuracion_General_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Configuracion_General.Click

        Dim _Clas_Mod As New Clas_Modalidades

        _Global_Row_Configuracion_General = _Clas_Mod.Fx_Sql_Trae_Modalidad(Clas_Modalidades.Enum_Modalidad.General, "")
        _Global_Row_Configuracion_Estacion = _Clas_Mod.Fx_Sql_Trae_Modalidad(Clas_Modalidades.Enum_Modalidad.Estacion, Modalidad)

        Dim _RowModalidad As DataRow = _Clas_Mod.Fx_Sql_Trae_Modalidad(Clas_Modalidades.Enum_Modalidad.General, "  ")

        Dim Fm As New Frm_Configuracion_Gral(_RowModalidad, True)
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Return

        'Dim NewPanel As Cntrl_Configuracion_General = Nothing
        'NewPanel = New Cntrl_Configuracion_General(Me, _Global_Row_Configuracion_General, True)
        'Me.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)

    End Sub

    Private Sub Btn_Configuracion_Estacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Configuracion_Estacion.Click

        Dim _Modalidad As String = Modalidad

        Dim _ModEmpresa = ModEmpresa
        Dim _ModSucursal = ModSucursal

        Dim Fm As New Frm_Modalidades(False)
        Fm.Configuracion_Modalidad = True
        Fm.ControlBox = True
        Fm.ShowDialog(Me)
        Fm.Dispose()

        'Dim NewPanel As Cntrl_Modalidad_Conf = Nothing
        'NewPanel = New Cntrl_Modalidad_Conf()
        'NewPanel.FmPrincipal = Me
        'Me.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)

    End Sub

    Private Sub Notify_BakApp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Notify_BakApp.Click
        ShowContextMenu(Menu_Contextual_01)
    End Sub

    Private Sub Frm_Menu_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyValue = Keys.Escape Then
            For Each f In Me.Controls
                Dim SS = f
            Next
        End If
    End Sub

    Sub Sb_Remotas(_Solo_Mis_Notificaciones As Boolean)

        If _Global_Sesion Then

            Dim _CodAutoriza As String

            If Fx_Tiene_Permiso(Me, "Espr0009") Then

                _CodAutoriza = FUNCIONARIO
                Me.WindowState = FormWindowState.Maximized
                Notify_Remota.Visible = False
                Btn_Mnu_Permisos_Remotos.Enabled = False

                For Each prog As Process In Process.GetProcesses
                    If UCase(prog.ProcessName) = UCase(_Global_Nombre_BakApp_Notificaciones) Then
                        prog.Kill()
                        Exit For
                    End If
                Next

                Dim Fm_Remotas As New Frm_Remotas_Lista_Permisos_Solicitados(_CodAutoriza, False)
                Fm_Remotas.Pro_Solo_Mis_Notificaciones = _Solo_Mis_Notificaciones
                Fm_Remotas.ShowDialog(Me)
                Fm_Remotas.Dispose()
                Btn_Mnu_Permisos_Remotos.Enabled = True

                Sb_Ejecutar_Notificaciones(Me, False)

            End If

        Else

            Beep()

        End If

    End Sub

    Private Sub Notify_Actualizacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Notify_Actualizacion.Click
        Fx_Buscar_Actualizacion(Me)
    End Sub

    Sub Sb_Descargar_Actualizacion()
        If Fx_Buscar_Actualizacion(Me) Then
            Sb_Cerrar_Sistema(False)
        End If
    End Sub

    Private Sub Mnu_Compras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mnu_Compras.Click

        If Fx_Tiene_Permiso(Me, "Espr0015") Then

            Dim _Funcionario_Activo As String = FUNCIONARIO
            Dim _Modalidad_Activa As String = Modalidad
            Dim _Nombre_Funcionario_Activo_ As String = Nombre_funcionario_activo

            Mnu_Compras.Enabled = False

            Dim Fm_Mnu_Extra As New Frm_Menu_Extra(Frm_Menu_Extra.Enum_Menu.Compras)
            Fm_Mnu_Extra.ShowDialog(Me)
            Fm_Mnu_Extra.Dispose()

            Sb_Actualizar_Modalidad(_Funcionario_Activo, _Nombre_Funcionario_Activo_, _Modalidad_Activa)
            Mnu_Compras.Enabled = True

        End If

    End Sub

    Private Sub Mnu_Ventas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mnu_Ventas.Click

        If Fx_Tiene_Permiso(Me, "Espr0016") Then

            Dim _Funcionario_Activo As String = FUNCIONARIO
            Dim _Modalidad_Activa As String = Modalidad
            Dim _Nombre_Funcionario_Activo_ As String = Nombre_funcionario_activo

            Mnu_Ventas.Enabled = False

            Dim Fm_Mnu_Extra As New Frm_Menu_Extra(Frm_Menu_Extra.Enum_Menu.Ventas)
            Fm_Mnu_Extra.ShowDialog(Me)
            Fm_Mnu_Extra.Dispose()

            Sb_Actualizar_Modalidad(_Funcionario_Activo, _Nombre_Funcionario_Activo_, _Modalidad_Activa)
            Mnu_Ventas.Enabled = True

        End If

    End Sub

    Private Sub Mnu_Precios_Costos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mnu_Precios_Costos.Click

        If Fx_Tiene_Permiso(Me, "Espr0017") Then

            Dim _Funcionario_Activo As String = FUNCIONARIO
            Dim _Modalidad_Activa As String = Modalidad
            Dim _Nombre_Funcionario_Activo_ As String = Nombre_funcionario_activo

            Dim NewPanel As Modulo_Lista_Precios_Costos = Nothing
            Mnu_Precios_Costos.Enabled = False

            Dim Fm_Mnu_Extra As New Frm_Menu_Extra(Frm_Menu_Extra.Enum_Menu.Listas_Precios_Costo)
            Fm_Mnu_Extra.ShowDialog(Me)
            Fm_Mnu_Extra.Dispose()

            Sb_Actualizar_Modalidad(_Funcionario_Activo, _Nombre_Funcionario_Activo_, _Modalidad_Activa)
            Mnu_Precios_Costos.Enabled = True

        End If

    End Sub

    Private Sub Mnu_Parametros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mnu_Parametros.Click

        If Fx_Tiene_Permiso(Me, "Espr0018") Then

            Dim _Funcionario_Activo As String = FUNCIONARIO
            Dim _Modalidad_Activa As String = Modalidad
            Dim _Nombre_Funcionario_Activo_ As String = Nombre_funcionario_activo

            Dim NewPanel As Modulo_Parametros = Nothing
            Mnu_Parametros.Enabled = False

            Dim Fm_Mnu_Extra As New Frm_Menu_Extra(Frm_Menu_Extra.Enum_Menu.Parametros)
            Fm_Mnu_Extra.ShowDialog(Me)
            Fm_Mnu_Extra.Dispose()

            Sb_Actualizar_Modalidad(_Funcionario_Activo, _Nombre_Funcionario_Activo_, _Modalidad_Activa)
            Mnu_Parametros.Enabled = True

        End If

    End Sub

    Private Sub Mnu_Inventario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mnu_Inventario.Click

        If Fx_Tiene_Permiso(Me, "Espr0019") Then

            Dim _Funcionario_Activo As String = FUNCIONARIO
            Dim _Modalidad_Activa As String = Modalidad
            Dim _Nombre_Funcionario_Activo_ As String = Nombre_funcionario_activo

            Dim NewPanel As Sistema_Inventarios = Nothing
            Mnu_Inventario.Enabled = False

            Dim Fm_Mnu_Extra As New Frm_Menu_Extra(Frm_Menu_Extra.Enum_Menu.Inventarios)
            Fm_Mnu_Extra.ShowDialog(Me)
            Fm_Mnu_Extra.Dispose()

            Sb_Actualizar_Modalidad(_Funcionario_Activo, _Nombre_Funcionario_Activo_, _Modalidad_Activa)
            Mnu_Inventario.Enabled = True

        End If

    End Sub

    Private Sub Mnu_Informes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mnu_Informes.Click

        If Fx_Tiene_Permiso(Me, "Espr0020") Then

            Dim _Funcionario_Activo As String = FUNCIONARIO
            Dim _Modalidad_Activa As String = Modalidad
            Dim _Nombre_Funcionario_Activo_ As String = Nombre_funcionario_activo

            Dim NewPanel As Modulo_Informes = Nothing
            Mnu_Informes.Enabled = False

            Dim Fm_Mnu_Extra As New Frm_Menu_Extra(Frm_Menu_Extra.Enum_Menu.Informes)
            Fm_Mnu_Extra.ShowDialog(Me)
            Fm_Mnu_Extra.Dispose()

            Sb_Actualizar_Modalidad(_Funcionario_Activo, _Nombre_Funcionario_Activo_, _Modalidad_Activa)
            Mnu_Informes.Enabled = True

        End If

    End Sub

    Private Sub Mnu_Programas_Especiales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mnu_Programas_Especiales.Click

        If Fx_Tiene_Permiso(Me, "Espr0021") Then

            Dim _Funcionario_Activo As String = FUNCIONARIO
            Dim _Modalidad_Activa As String = Modalidad
            Dim _Nombre_Funcionario_Activo_ As String = Nombre_funcionario_activo

            Dim NewPanel As Modulo_Programas_Especiales = Nothing
            Mnu_Programas_Especiales.Enabled = False

            Dim Fm_Mnu_Extra As New Frm_Menu_Extra(Frm_Menu_Extra.Enum_Menu.Programas_Especiales)
            Fm_Mnu_Extra.ShowDialog(Me)
            Fm_Mnu_Extra.Dispose()

            Sb_Actualizar_Modalidad(_Funcionario_Activo, _Nombre_Funcionario_Activo_, _Modalidad_Activa)
            Mnu_Programas_Especiales.Enabled = True

        End If

    End Sub

    Private Sub Mnu_Buscar_Documento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mnu_Buscar_Documento.Click

        If Fx_Tiene_Permiso(Me, "Doc00015") Then

            Mnu_Buscar_Documento.Enabled = False

            Dim _Fm As New Frm_BusquedaDocumento_Filtro(True)
            _Fm.Sb_LlenarCombo_FlDoc(Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Todos, "")
            _Fm.Pro_TipoDoc_Seleccionado = Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Todos
            _Fm.ShowDialog(Me)
            _Fm.Dispose()

            Mnu_Buscar_Documento.Enabled = True

        End If

    End Sub

    Private Sub Mnu_Serv_Tecnico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mnu_Serv_Tecnico.Click

        If Fx_Tiene_Permiso(Me, "Espr0022") Then

            Dim _Funcionario_Activo As String = FUNCIONARIO
            Dim _Modalidad_Activa As String = Modalidad
            Dim _Nombre_Funcionario_Activo_ As String = Nombre_funcionario_activo

            Dim NewPanel As Modulo_Servicio_Tecnico = Nothing
            Mnu_Serv_Tecnico.Enabled = False

            Dim Fm_Mnu_Extra As New Frm_Menu_Extra(Frm_Menu_Extra.Enum_Menu.Serv_Tecnico)
            Fm_Mnu_Extra.ShowDialog(Me)
            Fm_Mnu_Extra.Dispose()

            Sb_Actualizar_Modalidad(_Funcionario_Activo, _Nombre_Funcionario_Activo_, _Modalidad_Activa)
            Mnu_Serv_Tecnico.Enabled = True

        End If

    End Sub

    Private Sub Mnu_Tesoreria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mnu_Tesoreria.Click

        If Fx_Tiene_Permiso(Me, "Espr0023") Then

            Dim _Funcionario_Activo As String = FUNCIONARIO
            Dim _Modalidad_Activa As String = Modalidad
            Dim _Nombre_Funcionario_Activo_ As String = Nombre_funcionario_activo

            Dim NewPanel As Modulo_Tesoreria = Nothing
            Mnu_Tesoreria.Enabled = False

            Dim Fm_Mnu_Extra As New Frm_Menu_Extra(Frm_Menu_Extra.Enum_Menu.Tesoreria)
            Fm_Mnu_Extra.ShowDialog(Me)
            Fm_Mnu_Extra.Dispose()

            Sb_Actualizar_Modalidad(_Funcionario_Activo, _Nombre_Funcionario_Activo_, _Modalidad_Activa)
            Mnu_Tesoreria.Enabled = True

        End If

    End Sub

    Sub Sb_Actualizar_Modalidad(ByVal _Funcionario_Activo As String,
                                ByVal _Nombre_Funcionario_Activo_ As String,
                                ByVal _Modalidad_Activa As String)

        FUNCIONARIO = _Funcionario_Activo
        Nombre_funcionario_activo = _Nombre_Funcionario_Activo_
        Modalidad = _Modalidad_Activa

        Dim _Mod As New Clas_Modalidades

        _Mod.Sb_Actualiza_Formatos_X_Modalidad()
        '_Global_Row_Configuracion_General = _Mod.Fx_Sql_Trae_Modalidad(Clas_Modalidades.Modalidad.General, "")
        '_Global_Row_Configuracion_Estacion = _Mod.Fx_Sql_Trae_Modalidad(Clas_Modalidades.Modalidad.Estacion, Modalidad)
        _Mod.Sb_Actualizar_Variables_Modalidad(Modalidad)

        'Me.Text = "Sistema BakApp. Empresa :" & RazonEmpresa &
        '          ", Funcionario Activo: " & Trim(Nombre_funcionario_activo) &
        '          ", Modalidad: " & Modalidad & ", BakApp Versión: " & _Global_Version_BakApp & "..." & Space(4) &
        '          "(Base BakApp: " & _Global_BaseBk & "). Estación: " & _Global_Row_EstacionBk.Item("NombreEquipo")

    End Sub

    Private Sub Notify_Menu_Extra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Notify_Menu_BakApp.Click

        'Dim _Path = AppPath() & "\Data\" & RutEmpresa & "\Demonio"
        'Dim _Datos_Conf As New Ds_Config_Picking
        '_Datos_Conf.ReadXml(_Path & "\Config_Local.xml")

        'Dim _Fila As DataRow = _Datos_Conf.Tables("Tbl_Configuracion").Rows(0)
        'Dim _Ejecutar_Automaticamente As Boolean = NuloPorNro(_Fila.Item("Ejecutar_Automaticamente"), False)

        Dim ejecutando As Process() = Process.GetProcessesByName(_Global_Nombre_BakApp_Demonio)

        Btn_Demonio.Visible = Not (ejecutando.Length > 0)

        Lbl_MenuBarraTareas.Text = "BakApp, Empresa: " & RazonEmpresa

        ShowContextMenu(Menu_Contextual_Menu_Extra)

    End Sub

    Private Sub Btn_Teamviewer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Teamviewer.Click
        Shell(AppPath() & "\TeamViewerQS.exe", AppWinStyle.NormalFocus)
    End Sub

    Enum Enum_Tipo_Notificacion
        Permiso_Remoto
        Sol_Compra
        Informacion
    End Enum

    Private Sub Btn_Revisar_Estructura_Db_Click(sender As Object, e As EventArgs) Handles Btn_Revisar_Estructura_Db.Click
        Dim Fm As New Frm_Estructura_Base_De_Datos
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub

    Private Sub Btn_Activar_Notificaciones_Click(sender As Object, e As EventArgs) Handles Btn_Activar_Notificaciones.Click

        'Tiempo_Espera_Notificacion.Start()
        Tiempo_Espera_Notifiacion_Temporal.Stop()

        Btn_DesacNotif_15.Checked = False
        Btn_DesacNotif_30.Checked = False

        'Btn_Notificaciones.Text = "NOTIFICACIONES (Activadas)"

        Btn_Activar_Notificaciones.Enabled = Not Tiempo_Espera_Notifiacion_Temporal.Enabled
        Btn_Desactivar_Notificaciones.Enabled = Tiempo_Espera_Notifiacion_Temporal.Enabled

        Btn_DesacNotif_15.Enabled = Tiempo_Espera_Notifiacion_Temporal.Enabled
        Btn_DesacNotif_30.Enabled = Tiempo_Espera_Notifiacion_Temporal.Enabled
        Btn_DesacNotif_Siempre.Enabled = Tiempo_Espera_Notifiacion_Temporal.Enabled

        '_Sql = New Class_SQL(Cadena_ConexionSQL_Server)

        'Consulta_sql = "Update " & _Global_BaseBk & "Zw_EstacionesBkp Set Mos_Notif_X_CdPermiso = 1 Where NombreEquipo = '" & _NombreEquipo & "'"
        '_Sql.Ej_consulta_IDU(Consulta_sql)

        'Me.Notify_Menu_BakApp.ShowBalloonTip(5, "Info. BakApp", "Notificaciones automaticas activadas...", ToolTipIcon.Info)

        Sb_Ejecutar_Notificaciones(Me, False)

    End Sub

    Private Sub Btn_Desactivar_Notificaciones_Click(sender As Object, e As EventArgs)

        'Tiempo_Espera_Notificacion.Stop()
        'csNotificaciones.Notificacion.Sb_Pop_Up_Remota(0, "NOTIFICACIONES", "NOTIFICACIONES DESACTIVADAS...",
        'csNotificaciones.Notificacion.Imagen.Informacion, 2, True, Me)

        Btn_Activar_Notificaciones.Enabled = True
        Btn_Desactivar_Notificaciones.Enabled = False

        _Sql = New Class_SQL(Cadena_ConexionSQL_Server)

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_EstacionesBkp Set Mos_Notif_X_CdPermiso = 0 Where NombreEquipo = '" & _NombreEquipo & "'"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Me.Notify_Menu_BakApp.ShowBalloonTip(5, "Info. BakApp", "Notificaciones desactivadas...", ToolTipIcon.Warning)

    End Sub

    Sub Sb_Dasactivar_Temporal(ByVal _Minutos As Integer)

        Tiempo_Espera_Notifiacion_Temporal.Interval = (1000 * 60) * _Minutos
        Tiempo_Espera_Notifiacion_Temporal.Start()

        Btn_Activar_Notificaciones.Enabled = True
        Btn_DesacNotif_15.Enabled = False
        Btn_DesacNotif_30.Enabled = False
        Btn_DesacNotif_Siempre.Enabled = False

        For Each prog As Process In Process.GetProcesses
            If UCase(prog.ProcessName) = UCase(_Global_Nombre_BakApp_Notificaciones) Then
                prog.Kill()
                Exit For
            End If
        Next

        Me.Notify_Menu_BakApp.ShowBalloonTip(3, "Info. BakApp", "Notificaciones desactivadas temporalmente por " & _Minutos & " minutos...", ToolTipIcon.Warning)

    End Sub

    Private Sub Tiempo_Espera_Notifiacion_Temporal_Tick(sender As Object, e As EventArgs) Handles Tiempo_Espera_Notifiacion_Temporal.Tick

        Tiempo_Espera_Notifiacion_Temporal.Stop()

        Btn_DesacNotif_15.Checked = False
        Btn_DesacNotif_30.Checked = False

        'Tiempo_Espera_Notificacion.Start()

        Btn_Activar_Notificaciones.Enabled = False
        Btn_DesacNotif_15.Enabled = True
        Btn_DesacNotif_30.Enabled = True
        Btn_DesacNotif_Siempre.Enabled = True

        'Btn_Notificaciones.Text = "NOTIFICACIONES (Activadas)"

        'Me.Notify_Menu_BakApp.ShowBalloonTip(5, "Info. BakApp", "Notificaciones automaticas activadas...", ToolTipIcon.Info)
        Sb_Ejecutar_Notificaciones(Me, False)

    End Sub

    Private Sub Btn_DesacNotif_15_Click(sender As Object, e As EventArgs) Handles Btn_DesacNotif_15.Click

        Sb_Dasactivar_Temporal(Btn_DesacNotif_15.Tag)
        Btn_DesacNotif_15.Checked = True

    End Sub

    Private Sub Btn_DesacNotif_30_Click(sender As Object, e As EventArgs) Handles Btn_DesacNotif_30.Click

        Sb_Dasactivar_Temporal(Btn_DesacNotif_30.Tag)
        Btn_DesacNotif_30.Checked = True

    End Sub

    Private Sub Btn_DesacNotif_Siempre_Click(sender As Object, e As EventArgs) Handles Btn_DesacNotif_Siempre.Click

        Tiempo_Espera_Notifiacion_Temporal.Stop()

        Btn_DesacNotif_15.Checked = False
        Btn_DesacNotif_30.Checked = False

        Btn_Activar_Notificaciones.Enabled = True
        Btn_Desactivar_Notificaciones.Enabled = False

        _Sql = New Class_SQL(Cadena_ConexionSQL_Server)

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_EstacionesBkp Set Mos_Notif_X_CdPermiso = 0 Where NombreEquipo = '" & _NombreEquipo & "'"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Me.Notify_Menu_BakApp.ShowBalloonTip(5, "Info. BakApp", "Notificaciones desactivadas...", ToolTipIcon.Warning)

        For Each prog As Process In Process.GetProcesses
            If UCase(prog.ProcessName) = UCase("BakApp_Notificaciones") Then
                prog.Kill()
                Exit For
            End If
        Next

    End Sub

    Private Sub Btn_Mnu_Permisos_Remotos_Todos_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_Permisos_Remotos_Todos.Click
        Notify_Menu_BakApp.Visible = False
        Sb_Remotas(False)
        Notify_Menu_BakApp.Visible = True
    End Sub

    Private Sub Btn_Mnu_Permisos_Remotos_OCC_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_Permisos_Remotos_OCC.Click

        If Fx_Tiene_Permiso(Me, "Espr0029") Then

            Notify_Menu_BakApp.Visible = False
            csNotificaciones.Notificacion._Revisando_Permiso_Remoto = True

            Dim Fm As New Frm_Cadenas_Remotas_Lista(Frm_Cadenas_Remotas_Lista.Enum_Accion.Revision_CRemotas, "OCC")
            Fm.ShowDialog(Me)
            Fm.Dispose()

            Notify_Menu_BakApp.Visible = True
            csNotificaciones.Notificacion._Revisando_Permiso_Remoto = False
            Me.Refresh()

        End If

    End Sub

    Private Sub Btn_Mnu_Permisos_Remotos_NVV_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_Permisos_Remotos_NVV.Click

        If Fx_Tiene_Permiso(Me, "Espr0030",,, False,,,, False) Then

            Notify_Menu_BakApp.Visible = False
            csNotificaciones.Notificacion._Revisando_Permiso_Remoto = True

            Dim Fm As New Frm_Cadenas_Remotas_Lista(Frm_Cadenas_Remotas_Lista.Enum_Accion.Revision_CRemotas, "NVV")
            Fm.ShowDialog(Me)
            Fm.Dispose()

            Notify_Menu_BakApp.Visible = True
            csNotificaciones.Notificacion._Revisando_Permiso_Remoto = False

        End If

    End Sub

    Private Sub Btn_Mnu_Permisos_Remotos_Mios_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_Permisos_Remotos_Mios.Click

        Notify_Menu_BakApp.Visible = False
        Sb_Remotas(True)
        Notify_Menu_BakApp.Visible = True

    End Sub

    Private Sub Mos_Notif_X_CdPermiso_Click(sender As Object, e As EventArgs)

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Dim _NombreEquipo = _Global_Row_EstacionBk.Item("NombreEquipo")

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_EstacionesBkp Set Mos_Notif_X_CdPermiso = " & Convert.ToInt32(Not Mos_Notif_X_CdPermiso.Checked) & vbCrLf &
                       "Where NombreEquipo = '" & _NombreEquipo & "'"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        'RemoveHandler Mos_Notif_X_CdPermiso.Click, AddressOf Mos_Notif_X_CdPermiso_Click

    End Sub

    Private Sub Mos_Notif_X_CdPermiso_MouseEnter(sender As Object, e As EventArgs) Handles Mos_Notif_X_CdPermiso.MouseEnter

        RemoveHandler Mos_Notif_X_CdPermiso.Click, AddressOf Mos_Notif_X_CdPermiso_Click
        AddHandler Mos_Notif_X_CdPermiso.Click, AddressOf Mos_Notif_X_CdPermiso_Click

    End Sub

    Private Sub Silenciar_Notificaciones_Click(sender As Object, e As EventArgs)

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Dim _NombreEquipo = _Global_Row_EstacionBk.Item("NombreEquipo")

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_EstacionesBkp Set Silenciar_Notificaciones = " & Convert.ToInt32(Not Silenciar_Notificaciones.Checked) & vbCrLf &
                       "Where NombreEquipo = '" & _NombreEquipo & "'"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        'RemoveHandler Silenciar_Notificaciones.Click, AddressOf Silenciar_Notificaciones_Click

    End Sub

    Private Sub Silenciar_Notificaciones_MouseEnter(sender As Object, e As EventArgs) Handles Silenciar_Notificaciones.MouseEnter

        RemoveHandler Silenciar_Notificaciones.Click, AddressOf Silenciar_Notificaciones_Click
        AddHandler Silenciar_Notificaciones.Click, AddressOf Silenciar_Notificaciones_Click

    End Sub

    Private Sub Btn_Usuarios_Click(sender As Object, e As EventArgs) Handles Btn_Usuarios.Click

        Dim Fm As New Frm_Usuarios_Random
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Descargar_Version_Click(sender As Object, e As EventArgs) Handles Btn_Descargar_Version.Click

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _Clas_Actualizar_Bakapp As New Clas_Actualiza_BakApp_Sql

        With _Clas_Actualizar_Bakapp

            Dim _Rut = RutEmpresa
            Dim _Ruta_Y_Archivo_Actualizacion As String
            Dim _Descarga_Completa As Boolean
            Dim _Directorio_Destino As String

            With _Clas_Actualizar_Bakapp

                If .Fx_Existe_Version_Para_Descargar Then

                    Dim Fm As New Frm_Actualizar_BakApp(.URL_Descarga, .Nombre_Archivo, .Nro_Version_Nueva, Frm_Actualizar_BakApp.Enum_Accion.Descargar)
                    Fm.ShowDialog(Me)
                    Fm.Dispose()
                    _Ruta_Y_Archivo_Actualizacion = Fm.Ruta_Y_Archivo_Actualizacion
                    _Descarga_Completa = Fm.Descarga_Completa
                    _Directorio_Destino = Fm.Directorio_Destino
                    Fm.Dispose()

                    If _Descarga_Completa Then

                        Process.Start("explorer.exe", _Directorio_Destino)

                    End If

                Else

                    If Not String.IsNullOrEmpty(.Mensaje) Then
                        MessageBoxEx.Show(Me, .Mensaje, "Problemas al descargar la versión", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If

                End If

            End With

        End With

    End Sub

    Private Sub Btn_Nueva_Conexion_Click(sender As Object, e As EventArgs) Handles Btn_Nueva_Conexion.Click

        BaseDeConexion = ArchivoConexion.BasePrincipal
        Dim NewPanel As Empresas_conectadas = Nothing
        NewPanel = New Empresas_conectadas(Me, True)
        NewPanel._Crear_Conexion = True
        Me.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)

    End Sub

    Private Sub Btn_Conexion_Base_Datos_Externa_Click(sender As Object, e As EventArgs) Handles Btn_Conexion_Base_Datos_Externa.Click

        Dim Fm As New Frm_ConexOtrasBases
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub BtnConfTipoEstacionNormal_Click(sender As Object, e As EventArgs) Handles BtnConfTipoEstacionNormal.Click
        Dim Fm As New Frm_RegistrarEquipo_Listado(False, Frm_RegistrarEquipo_Listado.Enum_Tipo_Estacion.Normal)
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub

    Private Sub BtnConfTipoEstacionB4A_Click(sender As Object, e As EventArgs) Handles BtnConfTipoEstacionB4A.Click
        Dim Fm As New Frm_RegistrarEquipo_Listado(False, Frm_RegistrarEquipo_Listado.Enum_Tipo_Estacion.B4A)
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub

    Private Sub Btn_Demonio_Click(sender As Object, e As EventArgs) Handles Btn_Demonio.Click
        Fx_Ejecutar_Demonio2(Me, True)
    End Sub

    Private Sub Frm_Menu_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dim _Path = AppPath() & "\Data\" & RutEmpresa & "\Tmp\Print_Borrar"
        Sb_BorrarArchivosEnDirectorio(_Path)
    End Sub

    Sub Sb_BorrarArchivosEnDirectorio(_Path As String)
        Try
            If Directory.Exists(_Path) Then
                Dim archivos As String() = Directory.GetFiles(_Path)
                For Each archivo As String In archivos
                    Try
                        File.Delete(archivo)
                    Catch ex As Exception
                        ' Manejar errores al intentar eliminar un archivo
                        Console.WriteLine($"Error al eliminar el archivo: {archivo} - {ex.Message}")
                    End Try
                Next
            Else
                Console.WriteLine($"El directorio especificado no existe: {_Path}")
            End If
        Catch ex As Exception
            ' Manejar errores generales
            Console.WriteLine($"Error al procesar el directorio: {_Path} - {ex.Message}")
        End Try
    End Sub

End Class
