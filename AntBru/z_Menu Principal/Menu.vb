Imports Bk_Produccion
Imports BkSpecialPrograms
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Keyboard

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

        Lbl_Thema_Claro.Tag = Enum_Themas.Claro
        Lbl_Thema_Gris.Tag = Enum_Themas.Gris
        Lbl_Thema_Oscuro.Tag = Enum_Themas.Oscuro
        Lbl_Thema_Azul.Tag = Enum_Themas.Azul
        Lbl_Thema_Rojo.Tag = Enum_Themas.Rojo
        Lbl_Thema_Verde.Tag = Enum_Themas.Verde

        AddHandler Lbl_Thema_Claro.Click, AddressOf Thema_Click
        AddHandler Lbl_Thema_Gris.Click, AddressOf Thema_Click
        AddHandler Lbl_Thema_Oscuro.Click, AddressOf Thema_Click
        AddHandler Lbl_Thema_Azul.Click, AddressOf Thema_Click
        AddHandler Lbl_Thema_Rojo.Click, AddressOf Thema_Click
        AddHandler Lbl_Thema_Verde.Click, AddressOf Thema_Click

        ' 3. En el constructor o en InitializeComponent, agregar los handlers:
        ' (Esto puede ir después de InitializeComponent en el constructor)
        AddHandler Lbl_Thema_Claro.MouseEnter, AddressOf Lbl_Thema_MouseEnter
        AddHandler Lbl_Thema_Gris.MouseEnter, AddressOf Lbl_Thema_MouseEnter
        AddHandler Lbl_Thema_Oscuro.MouseEnter, AddressOf Lbl_Thema_MouseEnter
        AddHandler Lbl_Thema_Azul.MouseEnter, AddressOf Lbl_Thema_MouseEnter
        AddHandler Lbl_Thema_Rojo.MouseEnter, AddressOf Lbl_Thema_MouseEnter
        AddHandler Lbl_Thema_Verde.MouseEnter, AddressOf Lbl_Thema_MouseEnter

        AddHandler Lbl_Thema_Claro.MouseLeave, AddressOf Lbl_Thema_MouseLeave
        AddHandler Lbl_Thema_Gris.MouseLeave, AddressOf Lbl_Thema_MouseLeave
        AddHandler Lbl_Thema_Oscuro.MouseLeave, AddressOf Lbl_Thema_MouseLeave
        AddHandler Lbl_Thema_Azul.MouseLeave, AddressOf Lbl_Thema_MouseLeave
        AddHandler Lbl_Thema_Rojo.MouseLeave, AddressOf Lbl_Thema_MouseLeave
        AddHandler Lbl_Thema_Verde.MouseLeave, AddressOf Lbl_Thema_MouseLeave

        If Global_Thema = Enum_Themas.Oscuro Then
            BtnTeamviewer.ForeColor = Color.White
            Btn_Actualizar_BakApp.ForeColor = Color.White
        End If

    End Sub

    Private Sub Menu_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        AddHandler Btn_Cambio_Empresa.Click, AddressOf Sb_Cambiar_De_Base_De_Datos
        Sb_Load()
    End Sub

    Sub Sb_Load()

        Sb_Revisar_Estilo("")

        Try
            Lbl_Estatus.Text = "Fun: " & FUNCIONARIO & "-" & Nombre_funcionario_activo.Trim &
                          ",Emp: " & Mod_Empresa & ", Mod: " & Mod_Modalidad & ", BakApp Versión: " & _Global_Version_BakApp & "..." & Space(4) &
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

        Try
            If _Global_Row_Configuracion_Estacion.Item("FacElect_Usar_AmbienteCertificacion") Then
                Dim _BackColor_Tido As Color = Color.FromArgb(235, 81, 13)
                Metro_Bar_Color.BackgroundStyle.BackColor = _BackColor_Tido
            End If
        Catch ex As Exception

        End Try

        Dim DatosConex As New ConexionBK

        Dim Directorio As String = Application.StartupPath & "\Data\"

        Dim _Tbl = New DataTable
        DatosConex.Clear()
        DatosConex.ReadXml(Directorio & "Conexiones.xml")
        _Tbl = DatosConex.Tables("CnBakApp")

        Btn_CambioDeEmpresa.Visible = (_Tbl.Rows.Count > 1)

        Sb_Color_Botones_Barra(Barra)

    End Sub

    Private Sub BtnGestionCompras_Click(sender As System.Object, e As System.EventArgs) Handles BtnGestionCompras.Click

        If Not Fx_Tiene_Permiso(_Fm_Menu_Padre, "Comp0102") Then
            Return
        End If

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

        If Not Fx_Tiene_Permiso(_Fm_Menu_Padre, "Invg0009") Then
            Return
        End If

        Dim NewPanel As Sistema_Inventarios = Nothing
        NewPanel = New Sistema_Inventarios(_Fm_Menu_Padre)
        _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)

    End Sub

    Private Sub BtnInformes_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Informes.Click

        If Not Fx_Tiene_Permiso(_Fm_Menu_Padre, "Inf00050") Then
            Return
        End If

        Dim NewPanel As Modulo_Informes = Nothing
        NewPanel = New Modulo_Informes(_Fm_Menu_Padre)
        _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

    Private Sub Btn_CambiarCodProducto_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Ventas.Click

        If Not Fx_Tiene_Permiso(_Fm_Menu_Padre, "Bkp00001") Then
            Return
        End If

        Dim NewPanel As Modulo_Ventas = Nothing
        NewPanel = New Modulo_Ventas(_Fm_Menu_Padre)
        _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)

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

                            Dim _RutEmpresa = Trim(_Sql.Fx_Trae_Dato("CONFIGP", "RUT", "EMPRESA = '" & Mod_Empresa & "'"))

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
        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Stec0001") Then
            Dim NewPanel As Modulo_Servicio_Tecnico = Nothing
            NewPanel = New Modulo_Servicio_Tecnico(_Fm_Menu_Padre)
            _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)
        End If
    End Sub

    Private Sub Btn_Actualizar_BakApp_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Actualizar_BakApp.Click
        Tiempo_Actualizar_BakApp.Stop()
        Frm_Menu.Sb_Descargar_Actualizacion()
        Tiempo_Actualizar_BakApp.Start()
    End Sub

    Private Sub Btn_Tesoreria_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Tesoreria.Click

        If Not Fx_Tiene_Permiso(_Fm_Menu_Padre, "Ppro0007") Then
            Return
        End If

        Dim _Msj_Tsc As LsValiciones.Mensajes = Fx_Revisar_Tasa_Cambio(_Fm_Menu_Padre)

        If Not _Msj_Tsc.EsCorrecto Then
            Return
        End If

        Dim NewPanel As Modulo_Tesoreria = Nothing
        NewPanel = New Modulo_Tesoreria(_Fm_Menu_Padre)
        _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)

    End Sub

    Private Sub Btn_Precios_Costos_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Precios_Costos.Click

        If Not Fx_Tiene_Permiso(_Fm_Menu_Padre, "Pre0008") Then
            Return
        End If

        Dim NewPanel As Modulo_Lista_Precios_Costos = Nothing
        NewPanel = New Modulo_Lista_Precios_Costos(_Fm_Menu_Padre)
        _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)

    End Sub

    Private Sub Btn_Parametros_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Parametros.Click

        If Not Fx_Tiene_Permiso(_Fm_Menu_Padre, "Espr0018") Then
            Return
        End If

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

        If Not Fx_Tiene_Permiso(_Fm_Menu_Padre, "CfEnt037") Then
            Return
        End If

        Dim NewPanel As Entidades_menu = Nothing
        NewPanel = New Entidades_menu(_Fm_Menu_Padre)
        _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)

    End Sub

    Private Sub BtnProductos_Click_1(sender As System.Object, e As System.EventArgs) Handles BtnProductos.Click

        If Not Fx_Tiene_Permiso(_Fm_Menu_Padre, "Prod078") Then
            Return
        End If

        Dim NewPanel As Productos = Nothing
        NewPanel = New Productos(_Fm_Menu_Padre)
        _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)

    End Sub

    Private Sub BtnBuscarDocumento_Click(sender As System.Object, e As System.EventArgs) Handles BtnBuscarDocumento.Click

        If Not Fx_Tiene_Permiso(_Fm_Menu_Padre, "Doc00015") Then
            Return
        End If

        Dim _Fm As New Frm_BusquedaDocumento_Filtro(True)
        _Fm.Sb_LlenarCombo_FlDoc(Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Todos, "")
        _Fm.Pro_TipoDoc_Seleccionado = Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Todos
        _Fm.ShowDialog(Me)
        _Fm.Dispose()

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
                Dim _Tbl_Docs As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

                For Each _Fila As DataRow In _Tbl_Docs.Rows

                    Dim _Idmaeedo = _Fila.Item("Idrst")

                    Dim Fm As New Frm_Adjuntar_Archivos("Zw_Docu_Archivos", "Idmaeedo", _Idmaeedo)
                    Fm.Fx_Grabar_Observacion_Adjunta(_Ruta_Etiqueta & "\" & _Nombre_Etiqueta, _Nombre_Etiqueta, False, FUNCIONARIO)
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
        If (Global_Thema = Lbl_Thema_Azul.Tag) Then _Lbl = Lbl_Thema_Azul
        If (Global_Thema = Lbl_Thema_Rojo.Tag) Then _Lbl = Lbl_Thema_Rojo
        If (Global_Thema = Lbl_Thema_Verde.Tag) Then _Lbl = Lbl_Thema_Verde

        Lbl_Thema_Claro.Image = Nothing
        Lbl_Thema_Gris.Image = Nothing
        Lbl_Thema_Oscuro.Image = Nothing
        Lbl_Thema_Azul.Image = Nothing
        Lbl_Thema_Rojo.Image = Nothing
        Lbl_Thema_Verde.Image = Nothing

        CType(_Lbl, LabelItem).Image = ImageList1.Images.Item(0)

        ShowContextMenu(Menu_Contextual_Menu_Extra)

    End Sub

    Private Sub buttonStyleCustom_ColorPreview(sender As Object, e As ColorPreviewEventArgs) Handles buttonStyleCustom.ColorPreview

        If StyleManager.IsMetro(StyleManager.Style) Then

            ' Obtener el canvas color actual
            Dim currentParams As DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters = StyleManager.MetroColorGeneratorParameters
            Dim _camvasColor As Color

            If Not currentParams.Equals(Nothing) Then
                _camvasColor = currentParams.CanvasColor
            Else
                ' Valor por defecto si no hay parámetros previos
                _camvasColor = Color.White
            End If

            Dim _baseColor As Color = e.Color

            StyleManager.MetroColorGeneratorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(_camvasColor, _baseColor)

        Else

            StyleManager.ColorTint = e.Color

        End If

        'If StyleManager.IsMetro(StyleManager.Style) Then

        '    'Metro_Bar_Color.Visible = True

        '    Dim _baseColor As Color = e.Color
        '    Dim _camvasColor As Color

        '    Select Case Global_Thema

        '        Case Enum_Themas.Claro

        '            _camvasColor = Color.White

        '        Case Enum_Themas.Gris

        '            _camvasColor = Color.FromArgb(216, 216, 216)

        '        Case Enum_Themas.Oscuro

        '            _camvasColor = Color.FromArgb(32, 32, 32) '  Color.Black

        '        Case Enum_Themas.Azul

        '            _camvasColor = Color.FromArgb(217, 224, 248)

        '    End Select


        '    StyleManager.MetroColorGeneratorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(_camvasColor, _baseColor)

        'Else

        '    StyleManager.ColorTint = e.Color

        'End If

    End Sub

    Private Sub buttonStyleCustom_SelectedColorChanged(sender As Object, e As EventArgs) Handles buttonStyleCustom.SelectedColorChanged

        ' Metro_Bar_Color.Visible = False

        buttonStyleCustom.CommandParameter = buttonStyleCustom.SelectedColor

        Dim _baseColor As Color = buttonStyleCustom.CommandParameter 'e.Color

        Fx_Cambiar_Thema(Global_Thema, _baseColor)
        Sb_Revisar_Estilo("")

    End Sub

    'Private Sub Lbl_Thema_Claro_Click(sender As Object, e As EventArgs) Handles Lbl_Thema_Claro.Click
    '    Fx_Cambiar_Thema(Enum_Themas.Claro, Color.FromArgb(0, 112, 192))
    '    Sb_Revisar_Estilo("")
    '    Sb_Color_Botones_Barra(Barra)
    'End Sub

    'Private Sub Lbl_Thema_Gris_Click(sender As Object, e As EventArgs) Handles Lbl_Thema_Gris.Click
    '    Fx_Cambiar_Thema(Enum_Themas.Gris, Color.FromArgb(0, 112, 192))
    '    Sb_Revisar_Estilo("")
    '    Sb_Color_Botones_Barra(Barra)
    'End Sub

    'Private Sub Lbl_Thema_Oscuro_Click(sender As Object, e As EventArgs) Handles Lbl_Thema_Oscuro.Click
    '    Fx_Cambiar_Thema(Enum_Themas.Oscuro, Color.FromArgb(0, 112, 192))
    '    Sb_Revisar_Estilo("")
    '    Sb_Color_Botones_Barra(Barra)
    'End Sub

    'Private Sub Lbl_Thema_Azul_Click(sender As Object, e As EventArgs) Handles Lbl_Thema_Azul.Click
    '    Fx_Cambiar_Thema(Enum_Themas.Azul, Color.FromArgb(64, 80, 141))
    '    Sb_Revisar_Estilo("")
    '    Sb_Color_Botones_Barra(Barra)
    'End Sub

    'Private Sub Lbl_Thema_Rojo_Click(sender As Object, e As EventArgs) Handles Lbl_Thema_Rojo.Click
    '    Fx_Cambiar_Thema(Enum_Themas.Rojo, Color.FromArgb(175, 0, 0))
    '    Sb_Revisar_Estilo("")
    '    Sb_Color_Botones_Barra(Barra)
    'End Sub

    'Private Sub Lbl_Thema_Verde_Click(sender As Object, e As EventArgs) Handles Lbl_Thema_Verde.Click
    '    Fx_Cambiar_Thema(Enum_Themas.Verde, Color.FromArgb(16, 124, 65))
    '    Sb_Revisar_Estilo("")
    '    Sb_Color_Botones_Barra(Barra)
    'End Sub
    'Private Sub Lbl_Thema_Oscuro_Ligth_Click(sender As Object, e As EventArgs) Handles Lbl_Thema_Oscuro_Ligth.Click
    '    Fx_Cambiar_Thema(Enum_Themas.Oscuro_Ligth, Color.FromArgb(0, 112, 192))
    '    Sb_Revisar_Estilo("")
    '    BtnTeamviewer.ForeColor = Color.White
    '    Btn_Actualizar_BakApp.ForeColor = Color.White
    'End Sub

    ' Ejemplo de uso: obtener los colores asociados al tag de un label
    ' Dim colores As List(Of Color) = DiccionarioColoresThemas(Lbl_Thema_Verde.Tag)
    ' Dim colorOscuro As Color = colores(0)
    ' Dim colorClaro As Color = colores(1)
    Private Sub buttonStyleCustom_MouseLeave(sender As Object, e As EventArgs) Handles buttonStyleCustom.MouseLeave
        Sb_Revisar_Estilo("")
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
            _Mod.Sb_Actualizar_Variables_Modalidad(Mod_Modalidad)

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
                          ", Mod: " & Mod_Modalidad & ", BakApp Versión: " & _Global_Version_BakApp & "..." & Space(4) &
                          "(Base BakApp: " & _Global_BaseBk & "). Estación: " & _Global_Row_EstacionBk.Item("NombreEquipo")
        Catch ex As Exception
            Lbl_Estatus.Text = String.Empty
        End Try
    End Sub

    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs) Handles ButtonItem1.Click

        Dim _Id As Integer = _Global_Row_EstacionBk.Item("Id")
        Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

        Dim Fm As New Frm_Demonio_Configuraciones(_Id, FUNCIONARIO)
        Fm.ShowDialog(_Fm_Menu_Padre)
        Fm.Dispose()

    End Sub

    Private Sub ButtonItem2_Click(sender As Object, e As EventArgs) Handles ButtonItem2.Click

        Dim _CambioDeConfiguracion As Boolean

        Dim Fm As New Frm_Demonio_New
        Fm.ShowDialog(_Fm_Menu_Padre)
        _CambioDeConfiguracion = Fm.CambioDeConfiguracion
        Fm.Dispose()
        Fm = Nothing

        If _CambioDeConfiguracion Then

            Dim _Id As Integer = _Global_Row_EstacionBk.Item("Id")
            Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

            Dim Fm2 As New Frm_Demonio_Configuraciones(_Id, FUNCIONARIO)
            Fm2.ShowDialog(_Fm_Menu_Padre)
            Fm2.Dispose()

            Call ButtonItem2_Click(Nothing, Nothing)

        End If

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

    Private Sub Btn_IngresarGRIProduccion_Click(sender As Object, e As EventArgs) Handles Btn_IngresarGRIProduccion.Click

        Dim Fm As New Frm_GRI_Ingreso
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub LabelX1_DoubleClick(sender As Object, e As EventArgs) Handles LabelX1.DoubleClick
        Dim _Autorizado As Boolean

        If ButtonX1.Visible Then
            ButtonX1.Visible = False
            Return
        End If

        Dim Fm_Pass As New Frm_Clave_Administrador
        Fm_Pass.ShowDialog(Me)
        _Autorizado = Fm_Pass.Pro_Autorizado
        Fm_Pass.Dispose()

        If Not _Autorizado Then
            Return
        End If

        ButtonX1.Visible = True
        Me.Refresh()
    End Sub

    Private Sub Btn_CrearNVVDesdeOCC_Click(sender As Object, e As EventArgs) Handles Btn_CrearNVVDesdeOCC.Click
        Return
        Dim _Id_Enc As Integer = 5

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Demonio_NVVAuto Where Id_Enc = " & _Id_Enc
        Dim _Row_Encabezado As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Endo As String = _Row_Encabezado.Item("Endo_Ori")
        Dim _Suendo As String = _Row_Encabezado.Item("Suendo_Ori")

        Consulta_sql = "Select Top 1 * From MAEEN Where KOEN = '" & _Endo & "' And SUEN = '" & _Suendo & "'"
        Dim _Row_Entidad As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Tido As String = "NVV"
        Dim _Fecha_Emision As DateTime = FechaDelServidor()

        Consulta_sql = "Select *,1 As Precio From " & _Global_BaseBk & "Zw_Demonio_NVVAutoDet Where Id_Enc = " & _Id_Enc
        Dim _Tbl_Productos As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim Fm As New Frm_Formulario_Documento(_Tido,
                                               csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Venta,
                                               False, False, False, False, False)

        Fm.Pro_RowEntidad = _Row_Entidad
        Fm.Sb_Crear_Documento_Interno_Con_Tabla(_Fm_Menu_Padre, _Tbl_Productos, _Fecha_Emision,
                                                "Codigo", "Cantidad", "Precio", "Observacion", False, True)
        Dim _Mensaje As LsValiciones.Mensajes = Fm.Fx_Grabar_Documento(False)
        Fm.Dispose()

        If _Mensaje.EsCorrecto Then

            Consulta_sql = "Select Top 1 * From MAEEDO Where IDMAEEDO = " & _Mensaje.Id
            Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Demonio_NVVAuto Set " &
                           "NVVGenerada = 1" &
                           ",Idmaeedo_NVV = " & _Row.Item("IDMAEEDO") &
                           ",Nudo_NVV = '" & _Row.Item("NUDO") & "'" &
                           ",Feemdo_NVV = '" & Format(_Row.Item("FEEMDO"), "yyyyMMdd") & "'" & vbCrLf &
                            "Where Id_Enc = " & _Id_Enc
            _Sql.Ej_consulta_IDU(Consulta_sql)

        End If

    End Sub

    Private Sub Btn_Stem_Click(sender As Object, e As EventArgs) Handles Btn_Stem.Click

        Dim Fm As New Frm_Stmp_Listado
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_RevPesoVariable_Click(sender As Object, e As EventArgs) Handles Btn_RevPesoVariable.Click

        Dim _Mensaje As New LsValiciones.Mensajes
        Dim Cl As New Cl_PesoVariable

        _Mensaje = Cl.Fx_Cacular(100, 6, 3)

        MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono)


    End Sub

    Private Sub ButtonItem6_Click(sender As Object, e As EventArgs) Handles ButtonItem6.Click

        Dim _Cl_ListaMayoristaMinorista As New Cl_ListaMayoristaMinorista

        _Cl_ListaMayoristaMinorista.Sb_LlenarCorreosNuevosMayoristas(2, FechaDelServidor().AddDays(-1))

        Return

        Dim _Fecha As Date = FechaDelServidor()
        Dim _PrimerDiaMes As Date = DateSerial(Year(_Fecha), Month(_Fecha), 1)
        Dim _UltimoDiaMes As Date = DateSerial(Year(_Fecha), Month(_Fecha) + 1, 0)

        _PrimerDiaMes = Primerdiadelmes(_Fecha)
        _UltimoDiaMes = ultimodiadelmes(_Fecha)

        Consulta_sql = "Select Distinct ENDO,SUENDO,NOKOEN,LCEN,SUBSTRING(LVEN,6,3) As LVEN,Lista As ListaSuperior" & vbCrLf &
                       "From MAEEDO" & vbCrLf &
                       "Inner Join MAEEN On KOEN = ENDO And SUEN = SUENDO" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_ListaPreGlobal On ListaInferior = SUBSTRING(LVEN,6,3)" & vbCrLf &
                       "Where TIDO = 'FCV' And FEEMDO Between '" & Format(_PrimerDiaMes, "yyyyMMdd") &
                       "' And '" & Format(_UltimoDiaMes, "yyyyMMdd") &
                       "' And LVEN In (SELECT 'TABPP'+ListaInferior FROM " & _Global_BaseBk & "Zw_ListaPreGlobal Where ListaInferior <> '')"

        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim _Lista As New List(Of LsValiciones.Mensajes)

        For Each _Fila As DataRow In _Tbl.Rows

            Dim _CodEntidad = _Fila.Item("ENDO")
            Dim _ListaSuperior = _Fila.Item("ListaSuperior")

            Dim _Msj As LsValiciones.Mensajes

            Dim _Cl_DocListaSuperior As New Cl_DocListaSuperior
            _Msj = _Cl_DocListaSuperior.Fx_RevisarSiCumpleConTenerListaSuperior(_CodEntidad, _ListaSuperior)

            If _Msj.EsCorrecto Then

                Dim _CodHolding As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Entidades", "CodHolding", "CodEntidad = '" & _CodEntidad & "'")
                Dim _FiltroEntidades As String

                If String.IsNullOrWhiteSpace(_CodHolding) Then
                    _FiltroEntidades = "('" & _CodEntidad & "')"
                Else
                    Consulta_sql = "Select CodEntidad From " & _Global_BaseBk & "Zw_Entidades Where CodHolding = '" & _CodHolding & "'"
                    Dim _TblHolding As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)
                    _FiltroEntidades = Generar_Filtro_IN(_TblHolding, "", "CodEntidad", False, False, "'")
                End If

                _Lista.Add(_CodEntidad)

            End If

        Next

        Dim _ListaCorreos As New List(Of LsValiciones.Mensajes)

        For Each _Msj As LsValiciones.Mensajes In _Lista

            Dim _CorreoMsj As LsValiciones.Mensajes = Fx_EnviarCorreosMayoristaMinorista(2, "jalfaro@bakapp.cl", "")

            _ListaCorreos.Add(_CorreoMsj)

            If _CorreoMsj.EsCorrecto Then

            End If

        Next

    End Sub

    Function Fx_EnviarCorreosMayoristaMinorista(_Id_Correo As Integer, _Para As String, _Cc As String) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes


        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Correos Where Id = " & _Id_Correo
        Dim _Row_Correo As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row_Correo) Then
            Throw New System.Exception("No existe configuración para el envio de correos")
        End If

        Dim _Nombre_Correo As String = _Row_Correo.Item("Nombre_Correo")
        Dim _Asunto As String = _Row_Correo.Item("Asunto")
        Dim _CuerpoMensaje As String = _Row_Correo.Item("CuerpoMensaje")

        If String.IsNullOrEmpty(_Asunto) Then
            _Asunto = "Correo de notificación de pedido " & RazonEmpresa
        End If

        _CuerpoMensaje = Replace(_CuerpoMensaje, "&lt;", "<")
        _CuerpoMensaje = Replace(_CuerpoMensaje, "&gt;", ">")
        _CuerpoMensaje = Replace(_CuerpoMensaje, "&quot;", """")

        _CuerpoMensaje = Replace(_CuerpoMensaje, "'", "''")

        If Not String.IsNullOrEmpty(_Nombre_Correo) Then

            Dim _Fecha = "Getdate()"
            Dim _Adjuntar_Documento As Boolean = False

            'If _Enviar_al_otro_dia Then
            '    _Fecha = "DATEADD(D,1,Getdate())"
            'End If

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Aviso_Correo (Id_Correo,Nombre_Correo,CodFuncionario,Asunto," &
                            "Para,Cc,Idmaeedo,Tido,Nudo,NombreFormato,Enviar,Mensaje,Fecha,Adjuntar_Documento,Doc_Adjuntos,Adjuntar_DTE,Id_Dte,Id_Trackid)" &
                            vbCrLf &
                            "Values (" & _Id_Correo & ",'" & _Nombre_Correo & "','','" & _Asunto & "','" & _Para & "','" & _Cc &
                            "',0,'','','',1,'" & _CuerpoMensaje & "'," & _Fecha &
                            "," & Convert.ToInt32(_Adjuntar_Documento) & ",'',1,0,0)"

            _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

            If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
                Throw New System.Exception(_Sql.Pro_Error)
            End If

        End If

        Return _Mensaje

    End Function

    Private Sub Btn_OccPreventa_Click(sender As Object, e As EventArgs) Handles Btn_OccPreventa.Click

        Dim _RowFormato As DataRow = Fx_Formato_Modalidad(_Fm_Menu_Padre, Mod_Empresa, Mod_Modalidad, "OCC", True)

        If (_RowFormato Is Nothing) Then

            MessageBoxEx.Show(_Fm_Menu_Padre, "Debe configurar el formato de salida en la configuración por modalidad de trabajo",
                              "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Exit Sub

        End If

        Dim _Msj_Tsc As LsValiciones.Mensajes = Fx_Revisar_Tasa_Cambio(_Fm_Menu_Padre)

        If Not _Msj_Tsc.EsCorrecto Then
            Return
        End If

        Dim Fm As New Frm_Formulario_Documento("OCC", csGlobales.Enum_Tipo_Documento.Compra, False, False, True)
        Fm.PreVenta = True
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_PagarDocumento_Click(sender As Object, e As EventArgs) Handles Btn_PagarDocumento.Click

        Dim _Idmaeedo As Integer = 1181838

        Dim _Cl_Pagar As New Clas_Pagar
        Dim _Maedpce As MAEDPCE
        Dim _Mensaje As LsValiciones.Mensajes

        Dim _Row_Maeedo As DataRow = _Sql.Fx_Get_DataRow("Select * From MAEEDO Where IDMAEEDO = " & _Idmaeedo)

        Consulta_sql = "Select TOP 1 * From MAEMO Where KOMO = 'US$' AND FEMO = '" & Format(FechaDelServidor, "yyyyMMdd") & "' Order by IDMAEMO DESC"
        Dim _Row_MaemoUSD = _Sql.Fx_Get_DataRow(Consulta_sql)

        _Maedpce = New MAEDPCE With {
        .TIDP = "TJV",
        .EMPRESA = Mod_Empresa,
        .ENDP = _Row_Maeedo.Item("ENDO"),
        .EMDP = "904",
        .SUEMDP = "",
        .CUDP = "2020",
        .NUCUDP = "123",
        .FEEMDP = FechaDelServidor(),
        .FEVEDP = FechaDelServidor(),
        .MODP = "$",
        .TIMODP = "N",
        .TAMODP = _Row_MaemoUSD.Item("VAMO"),
        .VADP = _Row_Maeedo.Item("VABRDO"),
        .VAASDP = _Row_Maeedo.Item("VABRDO"),
        .VAVUDP = 0,
        .ESASDP = "A",
        .ESPGDP = "P",
        .SUREDP = "CM",
        .CJREDP = "CM",
        .KOFUDP = "016",
        .REFANTI = "2000006746848587",
        .KOTU = 1,
        .VAABDP = 0,
        .CUOTAS = 1,
        .ARCHIRSD = "",
        .IDRSD = 0,
        .KOTNDP = RutEmpresa,
        .SUTNDP = "CM"
        }

        Dim _Fecha_Asignacion_Pago As Date = FechaDelServidor()
        Dim _Ls_Maedpce As New List(Of MAEDPCE)

        _Ls_Maedpce.Add(_Maedpce)

        _Mensaje = _Cl_Pagar.Fx_Pagar_Documento(_Idmaeedo, _Ls_Maedpce, _Fecha_Asignacion_Pago)

        MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono)

        If Not _Mensaje.EsCorrecto Then
            Return
        End If

    End Sub

    Private Sub Btn_GDI2GRI_Click(sender As Object, e As EventArgs) Handles Btn_GDI2GRI.Click

        Dim Fm As New Frm_GDI2GRI
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Return

        Dim _Tido As String = "GDI"
        Dim _Modalidad As String = Mod_Modalidad
        Dim _Fecha_Emision As Date = FechaDelServidor()
        Dim _Codigo As String = "01VAC16PMX000"
        Dim _Cantidad As Double = 200
        Dim _Sucursal As String = "LIN"
        Dim _Bodega_GDI As String = "Z08"
        Dim _Bodega_GRI As String = "Z01"

        Dim _Mensaje As New LsValiciones.Mensajes

        _Mensaje = Fx_Crear_GRIDesdeGDI(_Fm_Menu_Padre, 1946812, _Sucursal, _Bodega_GRI)

        MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono)

        'Consulta_sql = "Select Top 1 * From CONFIGP Where EMPRESA = '" & Mod_Empresa & "'"
        'Dim _Row_Configp As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        'Dim _Koen = _Row_Configp.Item("RUT")

        'Consulta_sql = "Select Top 1 * From MAEEN Where KOEN = '" & _Koen & "'"
        'Dim _Row_Entidad As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)


        'Consulta_sql = "Select KOPR As Codigo," & _Cantidad & " As Cantidad,PM As Precio,'' As Observacion," &
        '               "'" & _Sucursal & "' As Sucursal,'" & _Bodega_GDI & "' As Bodega" & vbCrLf &
        '               "From MAEPREM" & vbCrLf &
        '               "Where KOPR = '" & _Codigo & "'"
        'Dim _Tbl_Productos As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        'Dim Fm As New Frm_Formulario_Documento(_Tido,
        '                               csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Guia_Despacho_Interna,
        '                               False, False, False, False, False)
        'Fm.Sb_Limpiar(_Modalidad)
        'Fm.Pro_RowEntidad = _Row_Entidad
        'Fm.Sb_Crear_Documento_Interno_Con_Tabla(_Fm_Menu_Padre, _Tbl_Productos, _Fecha_Emision,
        '                                        "Codigo", "Cantidad", "Precio", "Observacion", False, True,, True)
        'Fm.Pro_SubTido = "GTI"
        '_Mensaje = Fm.Fx_Grabar_Documento(False)
        'Fm.Dispose()

        _Mensaje = Fx_Crear_GDI2GRI(_Modalidad, _Sucursal, _Bodega_GDI, _Fecha_Emision, _Codigo, _Cantidad)

        MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono)

        If _Mensaje.EsCorrecto Then

            _Mensaje = Fx_Crear_GRIDesdeGDI(_Fm_Menu_Padre, _Mensaje.Id, _Sucursal, _Bodega_GRI)

            MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono)

        End If

    End Sub

    Function Fx_Crear_GDI2GRI(_Modalidad As String,
                              _Sucursal As String,
                              _Bodega_GDI As String,
                              _Fecha_Emision As Date,
                              _Codigo As String,
                              _Cantidad As Double) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            Consulta_sql = "Select Top 1 * From CONFIGP Where EMPRESA = '" & Mod_Empresa & "'"
            Dim _Row_Configp As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim _Koen = _Row_Configp.Item("RUT")

            Consulta_sql = "Select Top 1 * From MAEEN Where KOEN = '" & _Koen & "'"
            Dim _Row_Entidad As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)


            Consulta_sql = "Select KOPR As Codigo," & _Cantidad & " As Cantidad,PM As Precio,'' As Observacion," &
                           "'" & _Sucursal & "' As Sucursal,'" & _Bodega_GDI & "' As Bodega" & vbCrLf &
                           "From MAEPREM" & vbCrLf &
                           "Where KOPR = '" & _Codigo & "'"
            Dim _Tbl_Productos As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            Dim Fm As New Frm_Formulario_Documento("GDI",
                                           csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Guia_Despacho_Interna,
                                           False, False, False, False, False)
            Fm.Sb_Limpiar(_Modalidad)
            Fm.Pro_RowEntidad = _Row_Entidad
            Fm.Sb_Crear_Documento_Interno_Con_Tabla(_Fm_Menu_Padre, _Tbl_Productos, _Fecha_Emision,
                                                    "Codigo", "Cantidad", "Precio", "Observacion", False, True,, True)
            Fm.Pro_SubTido = "GTI"
            _Mensaje = Fm.Fx_Grabar_Documento(False)
            Fm.Dispose()

            If Not _Mensaje.EsCorrecto Then
                Throw New System.Exception(_Mensaje.Mensaje)
            End If

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = "Error al crear la guía de despacho interna"
            _Mensaje.Detalle = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Error
        End Try

        Return _Mensaje

    End Function

    Function Fx_Crear_GRIDesdeGDI(_Formulario As Form,
                                  _Idmaeedo_Ori As Integer,
                                  _Sucursal_Recepcion As String,
                                  _Bodega_Recepcion As String) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Dim _New_Idmaeedo As Integer
        Dim _Fecha_Emision As Date = FechaDelServidor()

        Try

            Consulta_sql = "Select * From MAEEDO Where IDMAEEDO = " & _Idmaeedo_Ori & vbCrLf &
                           "Select MAEDDO.*,CASE WHEN UDTRPR = 1 THEN CAPRCO1-CAPREX1 ELSE CAPRCO2-CAPREX2 END AS 'Cantidad'," & vbCrLf &
                           "CAPRCO1-CAPREX1 AS 'CantUd1_Dori',CAPRCO2-CAPREX2 AS 'CantUd2_Dori'," & vbCrLf &
                           "CASE WHEN UDTRPR = 1 THEN PPPRNE ELSE PPPRNE*RLUDPR END AS 'Precio'," & vbCrLf &
                           "Isnull(Ofer.Id_Oferta,'') As Id_Oferta," & vbCrLf &
                           "Isnull(Ofer.Oferta,'') As Oferta," & vbCrLf &
                           "Isnull(Ofer.Es_Padre_Oferta,0) As Es_Padre_Oferta," & vbCrLf &
                           "Isnull(Ofer.Padre_Oferta,0) As Padre_Oferta," & vbCrLf &
                           "Isnull(Ofer.Hijo_Oferta,0) As Hijo_Oferta," & vbCrLf &
                           "Isnull(Cantidad_Oferta,0) As Cantidad_Oferta," & vbCrLf &
                           "Isnull(Porcdesc_Oferta,0) As Porcdesc_Oferta" & vbCrLf &
                           "From MAEDDO WITH ( NOLOCK )" & vbCrLf &
                           "Left Join " & _Global_BaseBk & "Zw_Linea_Oferta Ofer On Ofer.Idmaeddo = IDMAEDDO" & vbCrLf &
                           "Where IDMAEEDO In (" & _Idmaeedo_Ori & ")  And (ESLIDO <> 'C' OR ESFALI = 'I')" & vbCrLf &
                           "Order by IDMAEEDO,IDMAEDDO" & vbCrLf &
                           "Select * From MAEIMLI" & vbCrLf &
                           "Where IDMAEEDO In (" & _Idmaeedo_Ori & ")" & vbCrLf &
                           "Select * From MAEDTLI" & vbCrLf &
                           "Where IDMAEEDO In (" & _Idmaeedo_Ori & ")" & vbCrLf &
                           "Select TOP 1 * From MAEEDOOB Where IDMAEEDO = " & _Idmaeedo_Ori

            Dim _Ds_Maeedo_Origen As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

            Dim Fm_Post As New Frm_Formulario_Documento("GRI", csGlobales.Enum_Tipo_Documento.Guia_Recepcion_Interna, False)
            Fm_Post.Sb_Limpiar(Mod_Modalidad)
            Fm_Post.Sb_Crear_Documento_Desde_Otros_Documentos(_Formulario, _Ds_Maeedo_Origen, False, False, _Fecha_Emision, False, True,, _Bodega_Recepcion, _Sucursal_Recepcion, True)

            _Mensaje = Fm_Post.Fx_Grabar_Documento(False, csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_de_Grabacion.Nuevo_documento, True, False)
            Fm_Post.Dispose()

            If Not _Mensaje.EsCorrecto Then
                Throw New System.Exception(_Mensaje.Mensaje)
            End If

            _Mensaje.EsCorrecto = True
            _Mensaje.Mensaje = "Se ha creado la guía de recepción interna correctamente"
            _Mensaje.Icono = MessageBoxIcon.Information
            _Mensaje.Id = _New_Idmaeedo

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = "Error al crear la guía de recepción interna"
            _Mensaje.Detalle = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Error

        End Try

        Return _Mensaje

    End Function

    Private Sub Btn_Rutas_Click(sender As Object, e As EventArgs) Handles Btn_Rutas.Click

        Dim Fm As New Frm_Stmp_ListadoXRutas
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_CovPreVenta_Click(sender As Object, e As EventArgs) Handles Btn_CovPreVenta.Click

        Modulo_Documentos.Sb_Generar_Documento(_Fm_Menu_Padre,
                                               "COV",
                                               True,
                                               csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Venta, "PRE")

    End Sub

    Private Sub Btn_PPP_Click(sender As Object, e As EventArgs) Handles Btn_PPP.Click

        Dim _EjecutarProcesoTodosLosProductos As Boolean = False

        If MessageBoxEx.Show(Me, "¿Desea recalcular todo automáticamente el PPP?", "Recalcular PPP por producto",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            _EjecutarProcesoTodosLosProductos = True
        End If

        Dim Fm As New Frm_Recalculo_PPPxProd
        Fm.EjecutarProcesoTodosLosProductos = _EjecutarProcesoTodosLosProductos
        Fm.ModoPruebas = True
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub


    ' Pseudocódigo detallado:
    ' 1. Crear un método para manejar el evento MouseEnter de todos los LabelX de themas.
    '    - Al entrar, obtener el Tag del label y buscar en DiccionarioColoresThemas.
    '    - Cambiar los colores de la aplicación usando el color correspondiente (oscuro o claro según preferencia).
    ' 2. Crear un método para manejar el evento MouseLeave de todos los LabelX de themas.
    '    - No hacer nada, para que el color no vuelva al original (el color solo cambia si se hace clic).
    ' 3. Modificar los handlers para que todos los LabelX de themas usen estos eventos.
    ' 4. Al hacer clic, guardar el thema seleccionado y aplicar el color de forma definitiva.

    ' Implementación:
    ' 1. Agregar los handlers MouseEnter y MouseLeave a los LabelX de themas en el constructor o en el diseñador.
    ' 2. Implementar los métodos de eventos.
    ' 3. Modificar los métodos Click para que solo apliquen el color y guarden el thema.

    ' Código a agregar/modificar:



    ' Métodos para MouseEnter y MouseLeave:

    'Private Sub Lbl_Thema_MouseEnter(sender As Object, e As EventArgs)
    '    Dim lbl As LabelItem = CType(sender, LabelItem)
    '    Dim tag = lbl.Tag
    '    If DiccionarioColoresThemas.ContainsKey(tag) Then
    '        Dim colores = DiccionarioColoresThemas(tag)
    '        Dim colorOscuro As Color = colores(0)
    '        Dim colorClaro As Color = colores(1)
    '        ' Usar colorOscuro como base para el thema
    '        If StyleManager.IsMetro(StyleManager.Style) Then
    '            Dim _camvasColor As Color
    '            Select Case tag
    '                Case Enum_Themas.Claro : _camvasColor = Color.White
    '                Case Enum_Themas.Gris : _camvasColor = Color.FromArgb(216, 216, 216)
    '                Case Enum_Themas.Oscuro : _camvasColor = Color.FromArgb(32, 32, 32)
    '                Case Enum_Themas.Azul : _camvasColor = Color.FromArgb(217, 224, 248)
    '                Case Enum_Themas.Verde : _camvasColor = Color.FromArgb(230, 255, 230)
    '                Case Enum_Themas.Rojo : _camvasColor = Color.FromArgb(255, 230, 230)
    '                Case Enum_Themas.Oscuro_Ligth : _camvasColor = Color.FromArgb(80, 80, 80)
    '                Case Else : _camvasColor = Color.White
    '            End Select
    '            StyleManager.MetroColorGeneratorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(_camvasColor, colorOscuro)
    '        Else
    '            StyleManager.ColorTint = colorOscuro
    '        End If
    '    End If
    'End Sub

    'Private Sub Lbl_Thema_MouseLeave(sender As Object, e As EventArgs)
    '    ' No hacer nada para que el color no vuelva al original.
    '    ' El color solo cambiará si se hace clic en el thema.
    'End Sub

    ' Modificar los métodos Click de los LabelX de themas para que apliquen el thema de forma definitiva:

    Private Sub Lbl_Thema_Claro_Click(sender As Object, e As EventArgs) Handles Lbl_Thema_Claro.Click
        Fx_Cambiar_Thema(Enum_Themas.Claro, DiccionarioColoresThemas(Enum_Themas.Claro)(1))
        Sb_Revisar_Estilo("")
        Sb_Color_Botones_Barra(Barra)
    End Sub

    Private Sub Lbl_Thema_Gris_Click(sender As Object, e As EventArgs) Handles Lbl_Thema_Gris.Click
        Fx_Cambiar_Thema(Enum_Themas.Gris, DiccionarioColoresThemas(Enum_Themas.Gris)(1))
        Sb_Revisar_Estilo("")
        Sb_Color_Botones_Barra(Barra)
    End Sub

    Private Sub Lbl_Thema_Oscuro_Click(sender As Object, e As EventArgs) Handles Lbl_Thema_Oscuro.Click
        Fx_Cambiar_Thema(Enum_Themas.Oscuro, DiccionarioColoresThemas(Enum_Themas.Oscuro)(1))
        Sb_Revisar_Estilo("")
        Sb_Color_Botones_Barra(Barra)
    End Sub

    Private Sub Lbl_Thema_Azul_Click(sender As Object, e As EventArgs) Handles Lbl_Thema_Azul.Click
        Fx_Cambiar_Thema(Enum_Themas.Azul, DiccionarioColoresThemas(Enum_Themas.Azul)(1))
        Sb_Revisar_Estilo("")
        Sb_Color_Botones_Barra(Barra)
    End Sub

    Private Sub Lbl_Thema_Rojo_Click(sender As Object, e As EventArgs) Handles Lbl_Thema_Rojo.Click
        Fx_Cambiar_Thema(Enum_Themas.Rojo, DiccionarioColoresThemas(Enum_Themas.Rojo)(1))
        Sb_Revisar_Estilo("")
        Sb_Color_Botones_Barra(Barra)
    End Sub

    Private Sub Lbl_Thema_Verde_Click(sender As Object, e As EventArgs) Handles Lbl_Thema_Verde.Click
        Fx_Cambiar_Thema(Enum_Themas.Verde, DiccionarioColoresThemas(Enum_Themas.Verde)(1))
        Sb_Revisar_Estilo("")
        Sb_Color_Botones_Barra(Barra)
    End Sub

    ' Pseudocódigo detallado:
    ' 1. Crear un solo método Lbl_Thema_MouseEnter que funcione para todos los LabelItem de themas.
    ' 2. En el constructor o en el método InitializeComponent, agregar el handler MouseEnter a todos los LabelItem de themas.
    ' 3. Eliminar los handlers MouseEnter individuales (como Lbl_Thema_Verde_MouseEnter).
    ' 4. El método Lbl_Thema_MouseEnter debe detectar el thema por el Tag y aplicar el color correspondiente.

    ' Implementación:

    ' 1. Método único para MouseEnter:
    Private Sub Lbl_Thema_MouseEnter(sender As Object, e As EventArgs)
        Dim lbl As LabelItem = TryCast(sender, LabelItem)
        If lbl Is Nothing Then Return
        Dim tag = lbl.Tag
        If DiccionarioColoresThemas.ContainsKey(tag) Then
            Dim colores = DiccionarioColoresThemas(tag)
            Dim _canvasColor As Color = colores(0)
            Dim baseColor As Color = colores(1)
            If StyleManager.IsMetro(StyleManager.Style) Then
                StyleManager.MetroColorGeneratorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(_canvasColor, baseColor)
            Else
                StyleManager.ColorTint = baseColor
            End If
        End If
    End Sub

    ' 2. Método único para MouseLeave:
    Private Sub Lbl_Thema_MouseLeave(sender As Object, e As EventArgs)
        Sb_Revisar_Estilo("")
    End Sub

    Private Sub Btn_Grupos_Click(sender As Object, e As EventArgs) Handles Btn_Grupos.Click

        Dim Fm As New Frm_Grupos_Lista
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

End Class
