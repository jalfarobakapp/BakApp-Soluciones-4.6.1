Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Menu

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim NotifyIcon1 As NotifyIcon '= _Fm_Menu_Padre.Notify_Remota
    Dim _Fm_Menu_Padre As Metro.MetroAppForm
    Dim _Menu_Extra As Boolean


    Public Sub New(Fm_Menu_Padre As Metro.MetroAppForm, Menu_Extra As Boolean)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Fm_Menu_Padre = Fm_Menu_Padre
        _Menu_Extra = Menu_Extra

        AddHandler Lbl_Thema_Claro.Click, AddressOf Thema_Click
        AddHandler Lbl_Thema_Gris.Click, AddressOf Thema_Click
        AddHandler Lbl_Thema_Oscuro.Click, AddressOf Thema_Click
        AddHandler Lbl_Thema_Azul.Click, AddressOf Thema_Click

        If Global_Thema = Enum_Themas.Oscuro Then
            BtnTeamviewer.ForeColor = Color.White
            Btn_Actualizar_BakApp.ForeColor = Color.White
        End If

    End Sub

    Private Sub Menu_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        AddHandler Btn_Cambio_Empresa.Click, AddressOf Sb_Cambiar_De_Base_De_Datos

        Sb_Revisar_Estilo("")

        Try
            Lbl_Estatus.Text = "Fun: " & FUNCIONARIO & "-" & Nombre_funcionario_activo.Trim &
                          ", Mod: " & Modalidad & ", BakApp Versión: " & _Global_Version_BakApp & "..." & Space(4) &
                          "(Base BakApp: " & _Global_BaseBk & "). Estación: " & _Global_Row_EstacionBk.Item("NombreEquipo")
        Catch ex As Exception
            Lbl_Estatus.Text = String.Empty
        End Try

        If _Menu_Extra Then

            Btn_Actualizar_BakApp.Visible = False
            Btn_Cambio_Empresa.Visible = False
            Btn_Desconectar_Bases.Visible = False
            Btn_Permisos_Remotos.Visible = False
            BtnConfiguracion.Visible = False
            Btn_Cerrar_Sistema.Visible = False
            BtnGestionCompras.Enabled = False
            Btn_Themas.Visible = False

        Else

            Btn_Actualizar_BakApp.Tooltip = Frm_Menu.Notify_Actualizacion.Text
            Btn_Actualizar_BakApp.Visible = Frm_Menu.Notify_Actualizacion.Visible

            Tiempo_Actualizar_BakApp.Enabled = Frm_Menu.Notify_Actualizacion.Visible

        End If

        If Global_Thema = Enum_Themas.Oscuro Then
            Sb_Color_Botones_Barra(Barra)
        End If

        Btn_Facturacion_Electronica.Visible = True

        'ButtonX1.Visible = True

        If _Global_Row_Configuracion_Estacion.Item("FacElect_Usar_AmbienteCertificacion") Then
            Dim _BackColor_Tido As Color = Color.FromArgb(235, 81, 13)
            Metro_Bar_Color.BackgroundStyle.BackColor = _BackColor_Tido
        End If

        Dim DatosConex As New ConexionBK

        Dim Directorio As String = Application.StartupPath & "\Data\"

        Dim _Tbl = New DataTable
        DatosConex.Clear()
        DatosConex.ReadXml(Directorio & "Conexiones.xml")
        _Tbl = DatosConex.Tables("CnBakApp")

        'If _Tbl.Rows.Count = 1 Then
        '    MessageBoxEx.Show(_Fm_Menu_Padre, "No hay mas empresas conectadas", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Return
        'End If

        Btn_CambioDeEmpresa.Visible = (_Tbl.Rows.Count > 1)

        Sb_Color_Botones_Barra(Barra)

    End Sub

    Private Sub BtnGestionCompras_Click(sender As System.Object, e As System.EventArgs) Handles BtnGestionCompras.Click

        Dim NewPanel As Modulo_Compras = Nothing
        NewPanel = New Modulo_Compras(_Fm_Menu_Padre)
        _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)

    End Sub

    Private Sub BtnProductos_Click(sender As System.Object, e As System.EventArgs)
        Dim NewPanel As Productos = Nothing
        NewPanel = New Productos(_Fm_Menu_Padre)
        _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

    Private Sub BtnInventarios_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Inventarios.Click
        Dim NewPanel As Sistema_Inventarios = Nothing
        NewPanel = New Sistema_Inventarios(_Fm_Menu_Padre)
        _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

    Private Sub BtnInformes_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Informes.Click
        Dim NewPanel As Modulo_Informes = Nothing
        NewPanel = New Modulo_Informes(_Fm_Menu_Padre)
        _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

    Private Sub Btn_CambiarCodProducto_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Ventas.Click
        'MessageBoxEx.Show(Me, "No esta disponible en esta versión", "Inventario", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        'Return
        'If Licencia_Modulo("VTA01") Then
        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Bkp00001") Then
            Dim NewPanel As Modulo_Ventas = Nothing
            NewPanel = New Modulo_Ventas(_Fm_Menu_Padre)
            'If _Menu_Extra Then
            '    NewPanel.BtnCambiarDeUsuario.Visible = False
            'End If
            _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)
        End If
        'End If
    End Sub

    Private Sub BtnConfiguracion_Click(sender As System.Object, e As System.EventArgs) Handles BtnConfiguracion.Click

        Dim _Autorizado As Boolean

        Dim Fm_Pass As New Frm_Clave_Administrador
        Fm_Pass.ShowDialog(Me)
        _Autorizado = Fm_Pass.Pro_Autorizado
        Fm_Pass.Dispose()

        If _Autorizado Then _Fm_Menu_Padre.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Bottom)

    End Sub

    Private Sub BtnCambiarDeUsuario_Click(sender As System.Object, e As System.EventArgs) Handles BtnCambiarDeUsuario.Click
        Dim NewPanel As Login = Nothing
        NewPanel = New Login(_Fm_Menu_Padre)
        NewPanel.FormMenu = Me
        _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Right)
    End Sub

    Private Sub BtnTeamviewer_Click(sender As System.Object, e As System.EventArgs) Handles BtnTeamviewer.Click
        Shell(AppPath() & "\TeamViewerQS.exe", AppWinStyle.NormalFocus)
    End Sub

    Private Sub BtnProgramasEspeciales_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Programas_Especiales.Click
        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Espr0021") Then
            Dim NewPanel As Modulo_Programas_Especiales = Nothing
            NewPanel = New Modulo_Programas_Especiales(_Fm_Menu_Padre)
            _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)
        End If
    End Sub

    Private Sub Btn_Cerrar_Sistema_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Cerrar_Sistema.Click
        _Fm_Menu_Padre.Close()
    End Sub

    Sub Sb_Cambiar_De_Base_De_Datos()

        Dim _Texto = _Fm_Menu_Padre.Text
        Dim Cls_CB As New Clase_Cambiar_Empresa(_Fm_Menu_Padre)

        If Cls_CB.Fx_Cambiar_Empresa_Solo_Para_Formulario_Actual(Clase_Cambiar_Empresa.Tipo_de_cambio.Cambiar_totalmente,
                                                                 "Espr0010", Btn_Cambio_Empresa.Image) Then

            '_Fm_Menu_Padre.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)
            'sesion = False
            '_Fm_Menu_Padre.Sb_Iniciar_Sistema(True)

            'Dim NewPanel As Login = Nothing
            'NewPanel = New Login()
            '_Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Right)

        Else
            _Fm_Menu_Padre.Text = _Texto
        End If


    End Sub

    Function Fx_Act_Usuario(_Kofu As String, _Nokofu As String) As Boolean

        Dim Fm_L As New Frm_Login

        If Fm_L.Fx_Sesion_Star(_Fm_Menu_Padre, _Kofu, _Nokofu) Then

            FUNCIONARIO = _Kofu
            Nombre_funcionario_activo = _Nokofu
            _Global_Sesion = True

            Dim Frm_Modalidad As New Frm_Modalidad_Mt
            Frm_Modalidad.ShowDialog(Me)
            Return True

        Else

            Return False

        End If

    End Function

    Private Sub Btn_Desconectar_Bases_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Desconectar_Bases.Click

        If MessageBoxEx.Show(_Fm_Menu_Padre, "Esto lo desconectara de las otras bases a las cuales se ha conectado durante el transcurso de su sesión" & vbCrLf &
                              "¿Está seguro de cerrar estas conexiones?", "Cerrar conexiones", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Dim Ip = getIp()
            Dim _NombreEquipo = UCase(System.Net.Dns.GetHostName)
            Dim Directorio As String = Application.StartupPath & "\Data\"
            Dim _Cadena_ConexionSQL_Server_Original = Cadena_ConexionSQL_Server

            Dim DatosConex As New ConexionBK
            DatosConex.ReadXml(Directorio & "Conexiones.xml")

            Try

                Dim _Tbl As DataTable = New DataTable
                _Tbl = DatosConex.Tables("CnBakApp")

                If _Tbl.Rows.Count Then

                    For Each _Fila As DataRow In _Tbl.Rows

                        Dim _Servidor = Trim(_Fila.Item("Servidor"))
                        Dim _Puerto = Trim(_Fila.Item("Puerto"))
                        Dim _BaseDeDatos = Trim(_Fila.Item("BaseDeDatos"))
                        Dim _Usuario = Trim(_Fila.Item("Usuario"))
                        Dim _Clave = Trim(_Fila.Item("Clave"))

                        If Not String.IsNullOrEmpty(_Puerto) Then
                            _Servidor += "," & _Puerto
                        End If

                        'data source = SQL7.VITGLOBAL.NET,1777; initial catalog = AGRORAMA; user id = AGRORAMA; password = AGRORAMA

                        Cadena_ConexionSQL_Server = "data source = " & _Servidor & "; initial catalog = " & _BaseDeDatos &
                                        "; user id = " & _Usuario & "; password = " & _Clave

                        If Cadena_ConexionSQL_Server <> _Cadena_ConexionSQL_Server_Original Then

                            Dim _RutEmpresa = Trim(_Sql.Fx_Trae_Dato("CONFIGP", "RUT", "EMPRESA = '" & ModEmpresa & "'"))

                            Dim _Class_BaseBk As New Class_Conectar_Base_BakApp(_Fm_Menu_Padre)

                            If _Class_BaseBk.Pro_Existe_Base Then

                                _Global_BaseBk = _Class_BaseBk.Pro_Row_Tabcarac("Global_BaseBk")
                                Consulta_sql = "Update " & _Global_BaseBk & "Zw_EstacionesBkp Set Conectado = 0," & vbCrLf &
                                       "Fecha_Hora_Conec = Null" & vbCrLf &
                                       "Where NombreEquipo = '" & _NombreEquipo & "'"
                                _Sql.Ej_consulta_IDU(Consulta_sql, False)

                            End If

                        End If

                    Next

                    MessageBoxEx.Show(_Fm_Menu_Padre, "Bases liberadas correctamente", "Desconectar bases",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information)


                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                Cadena_ConexionSQL_Server = _Cadena_ConexionSQL_Server_Original

                Dim _Class_BaseBk As New Class_Conectar_Base_BakApp(_Fm_Menu_Padre)

                If _Class_BaseBk.Pro_Existe_Base Then

                    _Global_BaseBk = _Class_BaseBk.Pro_Row_Tabcarac.Item("Global_BaseBk")

                Else

                    MessageBoxEx.Show(_Fm_Menu_Padre, "No esta configurada la base de datos de BakApp",
                                      "Falta identificación de base BakApp", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                    If _Class_BaseBk.Fx_Grabar_Base_Bakapp_En_Tabcarac() Then
                        _Global_BaseBk = Trim(_Class_BaseBk.Pro_Row_Tabcarac.Item("Global_BaseBk"))
                    End If

                End If

            End Try

        End If

    End Sub

    Private Sub Btn_Servicio_Tecnico_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Servicio_Tecnico.Click

        Dim NewPanel As Modulo_Servicio_Tecnico = Nothing
        NewPanel = New Modulo_Servicio_Tecnico(_Fm_Menu_Padre)
        _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)

    End Sub

    Private Sub Btn_Actualizar_BakApp_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Actualizar_BakApp.Click
        Tiempo_Actualizar_BakApp.Stop()
        Frm_Menu.Sb_Descargar_Actualizacion()
        Tiempo_Actualizar_BakApp.Start()
    End Sub

    Private Sub Btn_Tesoreria_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Tesoreria.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Ppro0007") Then

            If Fx_Revisar_Taza_Cambio(_Fm_Menu_Padre) Then

                Dim NewPanel As Modulo_Tesoreria = Nothing
                NewPanel = New Modulo_Tesoreria(_Fm_Menu_Padre)
                _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)

            End If

        End If

    End Sub

    Private Sub Btn_Precios_Costos_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Precios_Costos.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Pre0008") Then

            Dim NewPanel As Modulo_Lista_Precios_Costos = Nothing
            NewPanel = New Modulo_Lista_Precios_Costos(_Fm_Menu_Padre)
            _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)

        End If

    End Sub

    Private Sub Btn_Parametros_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Parametros.Click

        Dim NewPanel As Modulo_Parametros = Nothing
        NewPanel = New Modulo_Parametros(_Fm_Menu_Padre)
        _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)

    End Sub

    Private Sub Btn_Prueba_Monto_Palabra_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Prueba_Monto_Palabra.Click

        Try

            Dim _Numero As Double

            If InputBox_Bk(_Fm_Menu_Padre, "Revisar monto escrito", "BakApp", _Numero, False,
                                                _Tipo_Mayus_Minus.Normal, , True, _Tipo_Imagen.Cheque_Numero, True, _Tipo_Caracter.Moneda, False) Then

                Dim _Palabra = Letras(_Numero)
                MessageBoxEx.Show(_Fm_Menu_Padre, _Palabra, FormatNumber(_Numero, 0), MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub BtnCreacionEntidad_Click(sender As System.Object, e As System.EventArgs) Handles BtnCreacionEntidad.Click

        Dim NewPanel As Entidades_menu = Nothing
        NewPanel = New Entidades_menu(_Fm_Menu_Padre)
        _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)

    End Sub

    Private Sub BtnProductos_Click_1(sender As System.Object, e As System.EventArgs) Handles BtnProductos.Click

        Dim NewPanel As Productos = Nothing
        NewPanel = New Productos(_Fm_Menu_Padre)
        _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)

    End Sub

    Private Sub BtnBuscarDocumento_Click(sender As System.Object, e As System.EventArgs) Handles BtnBuscarDocumento.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Doc00015") Then

            Dim _Fm As New Frm_BusquedaDocumento_Filtro(True)
            _Fm.Sb_LlenarCombo_FlDoc(Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Todos, "")
            _Fm.Pro_TipoDoc_Seleccionado = Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Todos
            _Fm.ShowDialog(Me)
            _Fm.Dispose()

        End If

    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click


        'Dim _IdmaeedoFCV = 1121028
        'Dim _Cl As New Cl_CambiarFechaVencimiento(_IdmaeedoFCV)
        '_Cl.Fx_CambioFechaConFincred()

        'Dim Auto_CorreoCc = "jalfaro@bakapp.cl"
        'Dim Auto_Id_CorreoOCCMinCompra = 38

        'Dim _OrdenesBajoMinimo As New List(Of Integer)

        '_OrdenesBajoMinimo.Add(1120834)
        '_OrdenesBajoMinimo.Add(1120835)

        'Dim _Generar_OCC As New GeneraOccAuto.Generar_Doc_Auto
        '_Generar_OCC.Fx_Enviar_Notificacion_Correo_OCC_BajoMinCompra(Auto_CorreoCc, "", Auto_Id_CorreoOCCMinCompra, _OrdenesBajoMinimo)



        'Dim _Cl_Wordpress As New Cl_Wordpress

        'Dim Productos As JArray = _Cl_Wordpress.ObtenerProductos()
        '_Cl_Wordpress.ActualizarStock("14687", 0, 42088)

        'Return
        'Dim Fm As New Frm_Migrar_Productos
        'Fm.ShowDialog(Me)
        'Fm.Dispose()

    End Sub

    Sub Sb_Prueba_Chilexpress()

        Dim _Id_Despacho = 10880

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Chilexpress_Env Where IdDespacho = " & _Id_Despacho
        Dim _Row_Chilexpress As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Idenvio = _Row_Chilexpress.Item("Idenvio")
        Dim _Json = _Row_Chilexpress.Item("Json")

        Dim _Referencia = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Despachos_Doc", "Ltrim(Rtrim(Substring(Tido,1,1)))+'-'+Ltrim(Str(Nudo))", "Id_Despacho = " & _Id_Despacho)

        _Json = Replace(_Json, "En construccion...", _Referencia)

        Dim _Clas_CliexpressAPI As New Clas_CliexpressAPI()

        If _Clas_CliexpressAPI.Fx_Realizar_Envio(_Idenvio, _Json) Then

            Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Chilexpress_Env Where Idenvio = " & _Idenvio
            _Row_Chilexpress = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim _Etiqueta = _Row_Chilexpress.Item("Etiqueta")
            Dim _Etiqueta_Img As Image = _Clas_CliexpressAPI.Fx_Generar_Etiqueta(_Etiqueta)
            Dim _Ruta_Etiqueta As String
            Dim _Nombre_Etiqueta As String

            If _Clas_CliexpressAPI.Fx_CrearPDF(_Etiqueta_Img) Then

                _Ruta_Etiqueta = _Clas_CliexpressAPI.Ruta_Etiqueta
                _Nombre_Etiqueta = _Clas_CliexpressAPI.Nombre_Etiqueta

                Consulta_sql = "Select Idrst From " & _Global_BaseBk & "Zw_Despachos_Doc Where Id_Despacho = " & _Id_Despacho
                Dim _Tbl_Docs As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                For Each _Fila As DataRow In _Tbl_Docs.Rows

                    Dim _Idmaeedo = _Fila.Item("Idrst")

                    Dim Fm As New Frm_Adjuntar_Archivos("Zw_Docu_Archivos", "Idmaeedo", _Idmaeedo)
                    Fm.Fx_Grabar_Observacion_Adjunta(_Ruta_Etiqueta & "\" & _Nombre_Etiqueta, _Nombre_Etiqueta, False)
                    'MessageBoxEx.Show(Me, "Etiqueta adjunta al documento correctamente", "Chilexpress", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Next

            End If

        End If

    End Sub

    Private Sub Btn_Produccion_Click(sender As Object, e As EventArgs) Handles Btn_Produccion.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Pdc00001") Then

            Dim NewPanel As Produccion = Nothing
            NewPanel = New Produccion
            Frm_Menu.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)

        End If

    End Sub

    Private Sub Btn_SisReclamos_Click(sender As Object, e As EventArgs) Handles Btn_SisReclamos.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Rcl00001") Then

            Dim NewPanel As Sistema_Reclamos = Nothing
            NewPanel = New Sistema_Reclamos(_Fm_Menu_Padre)
            _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)

        End If

    End Sub

    Private Sub Tiempo_Actualizar_BakApp_Tick(sender As Object, e As EventArgs) Handles Tiempo_Actualizar_BakApp.Tick
        Tiempo_Actualizar_BakApp.Enabled = False
        Frm_Menu.Sb_Descargar_Actualizacion()
        Tiempo_Actualizar_BakApp.Interval = (1000 * 60) * 3
        Tiempo_Actualizar_BakApp.Enabled = True
    End Sub

    Private Sub Btn_Despachos_Click(sender As Object, e As EventArgs) Handles Btn_Despachos.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "ODp00001") Then

            Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Despachos_Tom Where NombreEquipo = '" & _NombreEquipo & "'"
            _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

            Dim NewPanel As Sistema_Despachos = Nothing
            NewPanel = New Sistema_Despachos(_Fm_Menu_Padre)
            _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)

        End If

    End Sub

    Private Sub Thema_Click(sender As Object, e As EventArgs)

        'Fx_Cambiar_Thema(CType(sender, Object).Tag, Color.FromArgb(-16748352))
        'Sb_Revisar_Estilo("")

    End Sub

    Private Sub Btn_Themas_Click(sender As Object, e As EventArgs) Handles Btn_Themas.Click

        Dim _Lbl As Object

        If (Global_Thema = Lbl_Thema_Claro.Tag) Then _Lbl = Lbl_Thema_Claro
        If (Global_Thema = Lbl_Thema_Gris.Tag) Then _Lbl = Lbl_Thema_Gris
        If (Global_Thema = Lbl_Thema_Oscuro.Tag) Then _Lbl = Lbl_Thema_Oscuro
        If (Global_Thema = Lbl_Thema_Oscuro_Ligth.Tag) Then _Lbl = Lbl_Thema_Oscuro_Ligth
        If (Global_Thema = Lbl_Thema_Azul.Tag) Then _Lbl = Lbl_Thema_Azul

        Lbl_Thema_Claro.Image = Nothing
        Lbl_Thema_Gris.Image = Nothing
        Lbl_Thema_Oscuro.Image = Nothing
        Lbl_Thema_Azul.Image = Nothing

        CType(_Lbl, LabelItem).Image = ImageList1.Images.Item(0)

        ShowContextMenu(Menu_Contextual_Menu_Extra)

    End Sub

    Private Sub buttonStyleCustom_ColorPreview(sender As Object, e As ColorPreviewEventArgs) Handles buttonStyleCustom.ColorPreview

        If StyleManager.IsMetro(StyleManager.Style) Then

            'Metro_Bar_Color.Visible = True

            Dim _baseColor As Color = e.Color
            Dim _camvasColor As Color

            Select Case Global_Thema

                Case Enum_Themas.Claro

                    _camvasColor = Color.White

                Case Enum_Themas.Gris

                    _camvasColor = Color.FromArgb(216, 216, 216)

                Case Enum_Themas.Oscuro

                    _camvasColor = Color.FromArgb(32, 32, 32) '  Color.Black

                Case Enum_Themas.Azul

                    _camvasColor = Color.FromArgb(217, 224, 248)

            End Select


            StyleManager.MetroColorGeneratorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(_camvasColor, _baseColor)

        Else

            StyleManager.ColorTint = e.Color

        End If

    End Sub

    Private Sub buttonStyleCustom_SelectedColorChanged(sender As Object, e As EventArgs) Handles buttonStyleCustom.SelectedColorChanged

        ' Metro_Bar_Color.Visible = False

        buttonStyleCustom.CommandParameter = buttonStyleCustom.SelectedColor

        Dim _baseColor As Color = buttonStyleCustom.CommandParameter 'e.Color

        Fx_Cambiar_Thema(Global_Thema, _baseColor)
        Sb_Revisar_Estilo("")

    End Sub

    Private Sub Lbl_Thema_Claro_Click(sender As Object, e As EventArgs) Handles Lbl_Thema_Claro.Click
        Fx_Cambiar_Thema(Enum_Themas.Claro, Color.FromArgb(0, 112, 192))
        Sb_Revisar_Estilo("")
        Sb_Color_Botones_Barra(Barra)
    End Sub

    Private Sub Lbl_Thema_Gris_Click(sender As Object, e As EventArgs) Handles Lbl_Thema_Gris.Click
        Fx_Cambiar_Thema(Enum_Themas.Gris, Color.FromArgb(0, 112, 192))
        Sb_Revisar_Estilo("")
        Sb_Color_Botones_Barra(Barra)
    End Sub

    Private Sub Lbl_Thema_Oscuro_Click(sender As Object, e As EventArgs) Handles Lbl_Thema_Oscuro.Click
        Fx_Cambiar_Thema(Enum_Themas.Oscuro, Color.FromArgb(0, 112, 192))
        Sb_Revisar_Estilo("")
        Sb_Color_Botones_Barra(Barra)
    End Sub

    Private Sub Lbl_Thema_Azul_Click(sender As Object, e As EventArgs) Handles Lbl_Thema_Azul.Click
        Fx_Cambiar_Thema(Enum_Themas.Azul, Color.FromArgb(64, 80, 141))
        Sb_Revisar_Estilo("")
        Sb_Color_Botones_Barra(Barra)
    End Sub

    Private Sub buttonStyleCustom_MouseLeave(sender As Object, e As EventArgs) Handles buttonStyleCustom.MouseLeave
        Sb_Revisar_Estilo("")
    End Sub

    Private Sub Lbl_Thema_Oscuro_Ligth_Click(sender As Object, e As EventArgs) Handles Lbl_Thema_Oscuro_Ligth.Click
        Fx_Cambiar_Thema(Enum_Themas.Oscuro_Ligth, Color.FromArgb(0, 112, 192))
        Sb_Revisar_Estilo("")
        BtnTeamviewer.ForeColor = Color.White
        Btn_Actualizar_BakApp.ForeColor = Color.White
    End Sub

    Private Sub Btn_Conf_ConfGeneral_Click(sender As Object, e As EventArgs) Handles Btn_Conf_ConfGeneral.Click
        Call BtnConfiguracion_Click(Nothing, Nothing)
    End Sub

    Private Sub Btn_Conf_ConfEstacion_Click(sender As Object, e As EventArgs) Handles Btn_Conf_ConfEstacion.Click

        Dim _Autorizado As Boolean

        Dim Fm_Pass As New Frm_Clave_Administrador
        Fm_Pass.ShowDialog(Me)
        _Autorizado = Fm_Pass.Pro_Autorizado
        Fm_Pass.Dispose()

        If _Autorizado Then

            Dim _Id = _Global_Row_EstacionBk.Item("Id")
            Dim Fm As New Frm_RegistrarEquipo(Frm_RegistrarEquipo.Enum_Accion.Editar, _Id, False)
            Fm.ShowDialog(Me)
            Fm.Dispose()

            Dim _Mod As New Clas_Modalidades

            _Mod.Sb_Actualiza_Formatos_X_Modalidad()
            _Mod.Sb_Actualizar_Variables_Modalidad(Modalidad)

            Dim _NombreEquipo = _Global_Row_EstacionBk.Item("NombreEquipo")

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_EstacionesBkp Where NombreEquipo = '" & _NombreEquipo & "'"
            _Global_Row_EstacionBk = _Sql.Fx_Get_DataRow(Consulta_sql)

        End If

    End Sub

    Private Sub Btn_Conf_ConfImpDiablito_Click(sender As Object, e As EventArgs) Handles Btn_Conf_ConfImpDiablito.Click

        Dim Fm As New Frm_Imp_Diablito_X_Est(FUNCIONARIO, False)
        Fm.Tido = "000"
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Facturacion_Electronica_Click(sender As Object, e As EventArgs) Handles Btn_Facturacion_Electronica.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Dte00002") Then
            Dim NewPanel As Factura_Electronica = Nothing
            NewPanel = New Factura_Electronica(_Fm_Menu_Padre)
            _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)
        End If

    End Sub

    Private Sub Btn_CambioDeEmpresa_Click(sender As Object, e As EventArgs) Handles Btn_CambioDeEmpresa.Click

        Dim _Ejecutando_Notificaciones As Process() = Process.GetProcessesByName(_Global_Nombre_BakApp_Notificaciones)
        Dim _Ejecutando_Demonio As Process() = Process.GetProcessesByName(_Global_Nombre_BakApp_Demonio)
        Dim _Ejecutando_DTEMonitor As Process() = Process.GetProcessesByName(_Global_Nombre_BakApp_DTEMonitor)

        For Each prog As Process In Process.GetProcesses

            If UCase(prog.ProcessName) = UCase(_Global_Nombre_BakApp_Demonio) Then
                MessageBoxEx.Show(Frm_Menu, "El diablito de monitoreo de acciones automáticas se encuentra en ejecución." & vbCrLf &
                                            "No se puede hacer cambio de empresa cuando el diablito esta corriendo.", "Validación",
                                            MessageBoxButtons.OK, MessageBoxIcon.Stop)
                'prog.Kill()
                Return
            End If

            If UCase(prog.ProcessName) = UCase(_Global_Nombre_BakApp_DTEMonitor) Then
                MessageBoxEx.Show(Frm_Menu, "El diablito de monitoreo de documentos DTE SII se encuentra en ejecución." & vbCrLf &
                                             "No se puede hacer cambio de empresa cuando el diablito esta corriendo.", "Validación",
                                            MessageBoxButtons.OK, MessageBoxIcon.Stop)
                'prog.Kill()
                Return
            End If

            If UCase(prog.ProcessName) = UCase(_Global_Nombre_BakApp_Notificaciones) Then
                prog.Kill()
            End If

        Next

        _Fm_Menu_Padre.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Right)

        BaseDeConexion = ArchivoConexion.BasePrincipal
        Dim NewPanel As Empresas_conectadas = Nothing
        NewPanel = New Empresas_conectadas(_Fm_Menu_Padre, True)
        _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)

    End Sub

    Private Sub Menu_Enter(sender As Object, e As EventArgs) Handles MyBase.Enter
        Try
            Lbl_Estatus.Text = "Fun: " & FUNCIONARIO & "-" & Nombre_funcionario_activo.Trim &
                          ", Mod: " & Modalidad & ", BakApp Versión: " & _Global_Version_BakApp & "..." & Space(4) &
                          "(Base BakApp: " & _Global_BaseBk & "). Estación: " & _Global_Row_EstacionBk.Item("NombreEquipo")
        Catch ex As Exception
            Lbl_Estatus.Text = String.Empty
        End Try
    End Sub

    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs) Handles ButtonItem1.Click

        Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")
        Dim _Id_Prog As Integer = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Demonio_ConfXEstacion", "Id", "NombreEquipo = '" & _NombreEquipo & "'", True)

        If Not CBool(_Id_Prog) Then
            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Demonio_ConfXEstacion (NombreEquipo) Values ('" & _NombreEquipo & "')"
            _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Id_Prog)
        End If

        Dim Fm As New Frm_Demonio_Configuraciones(_Id_Prog, FUNCIONARIO)
        Fm.ShowDialog(_Fm_Menu_Padre)
        Fm.Dispose()

    End Sub

    Private Sub ButtonItem2_Click(sender As Object, e As EventArgs) Handles ButtonItem2.Click

        Dim Fm As New Frm_Demonio_New
        Fm.ShowDialog(_Fm_Menu_Padre)
        Fm.Dispose()

    End Sub

    Private Sub ButtonItem3_Click(sender As Object, e As EventArgs) Handles ButtonItem3.Click

        Dim Fm As New Frm_Cms_Fun
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub ButtonItem4_Click(sender As Object, e As EventArgs) Handles ButtonItem4.Click

        Dim Fm As New Frm_Cms(1)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub
End Class
