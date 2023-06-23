Imports System.Drawing.Printing
Imports System.IO
Imports System.Threading
Imports DevComponents.DotNetBar
Imports HEFSIIREGCOMPRAVENTAS.LIB
Imports Newtonsoft.Json.Linq

Public Class Frm_Demonio_01

    Enum _Pausa
        Play
        Pausa
    End Enum

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tm_Correos As Boolean
    Dim _Tm_Monitoreo_doc_emitidos As Boolean
    Dim _Tm_Cola_Impresion As Boolean
    Dim _Tm_Solicitud_Productos_Bodega As Boolean

    Dim _Impresora_Prod_Sol_Bodega As String
    Dim _Formulario As Form

    Dim _Tbl_Filtro_Doc_Imprimir As DataTable
    Dim _Tbl_Filtro_Doc_Correos As DataTable

    Dim IndiceFilaGrilla, IndiceFilaGrillaImpresos As Integer
    Dim _Imprimir_Barras As Boolean
    Dim _IdMaeedoDoc As String

    Dim _TblEncabezado,
        _TblDetalle,
        _TblDocOrigen,
        _TblObservaciones As DataTable

    Dim _DsDatos As DataSet

    Public _Datos_Conf As New Ds_Config_Picking
    Dim _Path = AppPath() & "\Data\" & RutEmpresa & "\Demonio"

    Private prtSettings As PrinterSettings
    Dim _PickingActivo As String

    Dim _Sw_Activar_Monitoreos,
        _Sw_Activar_Picking,
        _Sw_Activar_SolProdbod,
        _Sw_Activar_Correos,
        _Sw_Activar_Poswii,
        _Sw_Activar_Prestashop,
        _Sw_Activar_LibroDTESII,
        _Sw_Activar_Wordpress_Stock,
        _Sw_Activar_Wordpress_Productos,
        _Sw_Activar_Listas_Programacion As Boolean

    Dim _Prestashop_Ejecucion_Total As Boolean

    Dim _Cons_Ejecutar As Boolean
    Dim _Cons_Ejecudato As Boolean
    Dim _CierreDoc_Ejecudato As Boolean

    Dim _Prestashop_Total_Ejecutar As Boolean
    Dim _Prestashop_Total_Ejecudato As Boolean

    Dim _Correos_Enviados, _Correos_Rechazados As Integer
    Dim _Row_Nom_Equipo As DataRow

    Dim _Input_Tiempo_Correo As Integer
    Dim _Input_Tiempo_Impresion As Integer
    Dim _Input_Tiempo_Sol_Bodega As Integer
    Dim _Input_Tiempo_Poswii As Integer
    Dim _Input_Tiempo_Prestashop As Integer
    Dim _Input_Tiempo_Picking As Integer
    Dim _Input_Tiempo_LibroDTESII As Integer
    Dim _Input_Tiempo_Prestashop_orders As Integer
    Dim _Input_Tiempo_Archivador As Integer

    Dim _Input_Tiempo_Wordpress_Stock As Integer
    Dim _Input_Tiempo_Wordpress_Productos As Integer

    Dim _Input_Tiempo_Listas_Programacion As Integer

    Dim _Segundos_Correo As Integer
    Dim _Minutos_Correo As Integer

    Dim _Minutos_Wordpress_Prod As Integer
    Dim _Segundos_Wordpress_Prod As Integer
    Dim _Minutos_Wordpress_Stock As Integer
    Dim _Segundos_Wordpress_Stock As Integer

    Dim _Segundos_Impresion As Integer
    Dim _Segundos_Sol_Bodega As Integer
    Dim _Segundos_Poswii As Integer
    Dim _Segundos_Prestashop_orders As Integer
    Dim _Segundos_Prestashop As Integer
    Dim _Minutos_Prestashop As Integer
    Dim _Hora_Prestashop As String

    Dim _Segundos_Minimiza_Automatico As Integer
    Dim _Segundos_Picking As Integer

    Dim _Segundos_LibroDTESII As Integer
    Dim _Minutos_LibroDTESII As Integer

    Dim _Segundos_RunMonitor As Integer

    Dim _Segundos_Archivador As Integer

    Dim _Segundos_Listas_Programacion As Integer
    Dim _Segundos_FacAuto As Integer

    Dim _Minimiza_Automatico As Boolean
    Dim _Cadena_Conexion_Poswii As String

    Dim _Procesando_Cola_Impresion As Boolean
    Dim _Procesando_Correos As Boolean
    Dim _Procesando_Prestashop As Boolean
    Dim _Procesando_Picking As Boolean
    Dim _Procesando_LibroDTESII As Boolean

    Dim _Nombre_Equipo As String

    Dim _Rdb_Cons_Stock_Todos As Boolean
    Dim _Rdb_Cons_Stock_Mov_Hoy As Boolean

    Dim _Cons_Lunes As Boolean
    Dim _Cons_Martes As Boolean
    Dim _Cons_Miercoles As Boolean
    Dim _Cons_Jueves As Boolean
    Dim _Cons_Viernes As Boolean
    Dim _Cons_Sabado As Boolean
    Dim _Cons_Domingo As Boolean

    Dim _Prest_Lunes As Boolean
    Dim _Prest_Martes As Boolean
    Dim _Prest_Miercoles As Boolean
    Dim _Prest_Jueves As Boolean
    Dim _Prest_Viernes As Boolean
    Dim _Prest_Sabado As Boolean
    Dim _Prest_Domingo As Boolean

    Dim _CierreDoc_Lunes As Boolean
    Dim _CierreDoc_Martes As Boolean
    Dim _CierreDoc_Miercoles As Boolean
    Dim _CierreDoc_Jueves As Boolean
    Dim _CierreDoc_Viernes As Boolean
    Dim _CierreDoc_Sabado As Boolean
    Dim _CierreDoc_Domingo As Boolean

    Dim _Chk_COVCerrar As Boolean
    Dim _Chk_NVICerrar As Boolean
    Dim _Chk_NVVCerrar As Boolean
    Dim _Chk_OCICerrar As Boolean
    Dim _Chk_OCCCerrar As Boolean

    Dim _Input_DiasCOV As Integer
    Dim _Input_DiasNVI As Integer
    Dim _Input_DiasNVV As Integer
    Dim _Input_DiasOCI As Integer
    Dim _Input_DiasOCC As Integer

    Dim _Minimizar As Boolean

    Dim _Contador_Reenvio_Firmas_DTE As Integer

    Dim _Cl_Correos As New Cl_Correos
    Dim _Cl_Prestashop_Web As New Cl_Prestashop_Web
    Dim _Cl_Imprimir_Documentos As New Cl_Imprimir_Documentos
    Dim _Cl_Imprimir_Picking As New Cl_Imprimir_Picking
    Dim _Cl_Archivador As New Cl_Archivador
    Dim _Cl_Prestashop_Orders As New Cl_Prestashop_Orders
    Dim _Cl_LibroDTESII As New Cl_LibroDTESII
    Dim _Cl_Wordpress As New Cl_Wordpress
    Dim _Cl_Solicitud_Productos_Bodega As New Cl_Solicitud_Productos_Bodega
    Dim _Cl_Listas_Programadas As New Cl_Listas_Programadas
    Dim _Cl_FacAuto_NVV As New Cl_FacAuto_NVV
    Dim _Cl_Asistente_Compras As New Cl_Asistente_Compras
    Dim _Cl_Enviar_Doc_SinRecepcion As New Cl_Enviar_Doc_SinRecepcion

    Dim _Ejecutar_PrestaShop_Ordenes As Boolean
    Dim _Nro_Impresiones_Cerrar As Integer = 20

    Dim _Directorio = AppPath() & "\Data\" & RutEmpresa & "\Tmp"
    Dim _Dir_Correo_Imagenes = _Directorio & "\Correo\Imagenes"

    Private _Timer_HH1 As Timer

    Public ReadOnly Property Pro_Minimizar As Boolean
        Get
            Return _Minimizar
        End Get
    End Property
    Public ReadOnly Property Pro_Procesando_Cola_Impresion() As Boolean
        Get
            Return _Procesando_Cola_Impresion
        End Get
    End Property
    Public ReadOnly Property Pro_Procesando_Correos() As Boolean
        Get
            Return _Procesando_Cola_Impresion
        End Get
    End Property
    Public ReadOnly Property Pro_Procesando_Prestashop() As Boolean
        Get
            Return _Procesando_Cola_Impresion
        End Get
    End Property
    Public ReadOnly Property Pro_Demonio_Activado() As Boolean
        Get
            If Switch_Monitoreo_doc_emitidos.Value Or
               Switch_Correos.Value Or
               Switch_Cola_Impresion.Value Or
               Switch_Solicitud_Productos_Bodega.Value Or
               Switch_Poswii.Value Or
               Switch_Prestashop.Value Or
               Switch_Cons_Stock.Value Or
               Switch_LibroDTESII.Value Or
               Switch_Archivador.Value Or
               Switch_Wordpress_Prod.Value Or
               Switch_Wordpress_Stock.Value Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property
    Public ReadOnly Property Pro_NombreEquipo() As String
        Get
            _Nombre_Equipo = _Row_Nom_Equipo.Item("Nombre_Equipo")
            Return _Nombre_Equipo
        End Get
    End Property

    Public Sub New(Formulario_Padre As Form)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        DtpFecharevision.Enabled = False
        DtpFecharevision.Value = Now

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

        Timer_Hora_Actual.Enabled = True

        Me.TopMost = False
        _Formulario = Formulario_Padre

        Sb_Actualizar_Fecha()

        'Me.WindowState = FormWindowState.Minimized

        _Segundos_Minimiza_Automatico = 60 * 5

    End Sub

    Private Sub Frm_Imp_Picking_01_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Sb_Load()

        AddHandler Switch_Archivador.ValueChanged, AddressOf Switch_Archivador_ValueChanged

        PicBox_Documentos.Enabled = False
        LblDocumentos.Enabled = False
        CircularPgrs.Enabled = False
        Switch_Monitoreo_doc_emitidos.Enabled = False

        Sb_Actv_Botones_Configuracion()

        Timer_Segundos.Enabled = True

        Me.Text = "Demonio para acciones automatizadas, V: [" & _Version_BkSpecialPrograms & "]"
        Lbl_Nombre_Equipo.Text = "Nombre equipo: " & _Nombre_Equipo
        Lbl_Modalidad.Text = "Modalidad: " & Modalidad & ", Sucursal: " & ModSucursal & ", Bodega: " & ModBodega

        _Minimiza_Automatico = True

        Lbl_Estatus.Text = "Empresa: " & ModEmpresa & ", Modalidad: " & Modalidad & ", Usuario: " & FUNCIONARIO & ", Equipo: " & _Nombre_Equipo

        Sb_Color_Botones_Barra(Bar1)

        Sb_Programar_Timer()

    End Sub

    Public Sub Sb_Load()

        Sb_Revisar_Estilo("")

        _Datos_Conf.Clear()
        _Datos_Conf.ReadXml(_Path & "\Config_Local.xml")

        Dim _Fila As DataRow = _Datos_Conf.Tables("Tbl_Configuracion").Rows(0)

        _Impresora_Prod_Sol_Bodega = _Fila.Item("Impresora")

        Switch_Monitoreo_doc_emitidos.Value = False
        Switch_Correos.Value = NuloPorNro(_Fila.Item("Timer_Monitoreo_Mail"), False)
        Switch_Cola_Impresion.Value = NuloPorNro(_Fila.Item("Timer_Monitoreo_Impresion"), False)
        Switch_Solicitud_Productos_Bodega.Value = NuloPorNro(_Fila.Item("Timer_Monitoreo_SolProdBod"), False)
        Switch_Prestashop.Value = NuloPorNro(_Fila.Item("Timer_Prestashop"), False)
        Switch_Prestashop_Ordenes.Value = NuloPorNro(_Fila.Item("Timer_Prestashop_Ordenes"), False)
        Switch_Cons_Stock.Value = NuloPorNro(_Fila.Item("Timer_Consolidacion_Stock"), False)
        Switch_Picking.Value = NuloPorNro(_Fila.Item("Timer_Picking"), False)
        Switch_LibroDTESII.Value = NuloPorNro(_Fila.Item("Timer_LibroDTESII"), False)
        Switch_Archivador.Value = NuloPorNro(_Fila.Item("Timer_Archivador"), False)
        Switch_Wordpress_Stock.Value = NuloPorNro(_Fila.Item("Timer_Wordpress_Stock"), False)
        Switch_Wordpress_Prod.Value = NuloPorNro(_Fila.Item("Timer_Wordpress_Productos"), False)
        Switch_Cierre_Documentos.Value = NuloPorNro(_Fila.Item("Chk_Timer_CierreDoc"), False)
        Switch_Listas_Programadas.Value = NuloPorNro(_Fila.Item("Timer_Listas_Programadas"), False)
        Switch_FacAuto.Value = NuloPorNro(_Fila.Item("Timer_FacAuto"), False)
        Switch_AsisCompras.Value = NuloPorNro(_Fila.Item("Chk_AsistenteDeCompras"), False)
        Switch_EnvDocSinRecep.Value = NuloPorNro(_Fila.Item("Chk_EnvDocSinRecep"), False)

        _Cl_Archivador.Ruta_Archivador = NuloPorNro(_Fila.Item("Ruta_Archivador"), "")

        If Not String.IsNullOrEmpty(_Cl_Archivador.Ruta_Archivador) Then

            If Not Directory.Exists(_Cl_Archivador.Ruta_Archivador) Then
                _Cl_Archivador.Ruta_Archivador = AppPath() & "\Data\" & RutEmpresa
            End If

            _Cl_Archivador.Ruta_Archivador += "\Archivador"

        Else
            Switch_Archivador.Value = False
        End If

        _Rdb_Cons_Stock_Todos = NuloPorNro(_Fila.Item("Rdb_Cons_Stock_Todos"), True)
        _Rdb_Cons_Stock_Mov_Hoy = NuloPorNro(_Fila.Item("Rdb_Cons_Stock_Mov_Hoy"), False)

        _Input_Tiempo_Correo = NuloPorNro(_Fila.Item("Input_Tiempo_Correo"), 2) * 60 * 1000
        _Input_Tiempo_Impresion = NuloPorNro(_Fila.Item("Input_Tiempo_Impresion"), 1) * 1000
        _Input_Tiempo_Sol_Bodega = NuloPorNro(_Fila.Item("Input_Tiempo_Sol_Bodega"), 1) * 1000
        _Input_Tiempo_Prestashop = NuloPorNro(_Fila.Item("Input_Tiempo_Prestashop"), 1) * 60 * 1000

        _Input_Tiempo_Prestashop_orders = 3 * 60 * 1000

        _Input_Tiempo_Picking = NuloPorNro(_Fila.Item("Input_Tiempo_Picking"), 1) * 1000
        _Input_Tiempo_Archivador = NuloPorNro(_Fila.Item("Input_Tiempo_Archivador"), 1) * 1000
        _Input_Tiempo_LibroDTESII = NuloPorNro(_Fila.Item("Input_Tiempo_LibroDTESII"), 5) * 60 * 1000

        _Input_Tiempo_Wordpress_Stock = NuloPorNro(_Fila.Item("Input_Tiempo_Wordpress_Stock"), 5) * 60 * 1000
        _Input_Tiempo_Wordpress_Productos = NuloPorNro(_Fila.Item("Input_Tiempo_Wordpress_Productos"), 5) * 60 * 1000

        _Segundos_Correo = 60
        _Minutos_Correo = (_Input_Tiempo_Correo / 1000 / 60) - 1

        _Segundos_Impresion = _Input_Tiempo_Impresion / 1000
        _Segundos_Sol_Bodega = _Input_Tiempo_Sol_Bodega / 1000
        _Segundos_Poswii = _Input_Tiempo_Poswii / 1000

        _Segundos_Prestashop_orders = 10

        _Segundos_Prestashop = 60
        _Minutos_Prestashop = (_Input_Tiempo_Prestashop / 1000 / 60) - 1

        _Segundos_Picking = _Input_Tiempo_Picking / 1000

        _Segundos_LibroDTESII = 60
        _Minutos_LibroDTESII = (_Input_Tiempo_LibroDTESII / 1000 / 60) - 1

        _Segundos_RunMonitor = 60

        _Segundos_Archivador = _Input_Tiempo_Archivador / 1000

        'Wordpress
        _Segundos_Wordpress_Prod = 60
        _Minutos_Wordpress_Stock = (_Input_Tiempo_Wordpress_Stock / 1000 / 60) - 1
        _Segundos_Wordpress_Stock = 60
        _Minutos_Wordpress_Prod = (_Input_Tiempo_Wordpress_Productos / 1000 / 60) - 1

        _Segundos_Listas_Programacion = 60
        _Segundos_FacAuto = 60

        Dim _Hora_Cstock As DateTime

        _Hora_Cstock = NuloPorNro(_Fila.Item("Dtp_Cons_Stock_Hora_Ejecuion"), Now.ToString("HH:mm:ss"))
        Lbl_Hora_Consolid_Stock.Text = Format(_Hora_Cstock, "HH:mm")

        _Cons_Lunes = NuloPorNro(_Fila.Item("Chk_Cons_Stock_Lunes"), False)
        _Cons_Martes = NuloPorNro(_Fila.Item("Chk_Cons_Stock_Martes"), False)
        _Cons_Miercoles = NuloPorNro(_Fila.Item("Chk_Cons_Stock_Miercoles"), False)
        _Cons_Jueves = NuloPorNro(_Fila.Item("Chk_Cons_Stock_Jueves"), False)
        _Cons_Viernes = NuloPorNro(_Fila.Item("Chk_Cons_Stock_Viernes"), False)
        _Cons_Sabado = NuloPorNro(_Fila.Item("Chk_Cons_Stock_Sabado"), False)
        _Cons_Domingo = NuloPorNro(_Fila.Item("Chk_Cons_Stock_Domingo"), False)

        _Prest_Lunes = NuloPorNro(_Fila.Item("Chk_Prestashop_Lunes"), False)
        _Prest_Martes = NuloPorNro(_Fila.Item("Chk_Prestashop_Martes"), False)
        _Prest_Miercoles = NuloPorNro(_Fila.Item("Chk_Prestashop_Miercoles"), False)
        _Prest_Jueves = NuloPorNro(_Fila.Item("Chk_Prestashop_Jueves"), False)
        _Prest_Viernes = NuloPorNro(_Fila.Item("Chk_Prestashop_Viernes"), False)
        _Prest_Sabado = NuloPorNro(_Fila.Item("Chk_Prestashop_Sabado"), False)
        _Prest_Domingo = NuloPorNro(_Fila.Item("Chk_Prestashop_Domingo"), False)

        _Hora_Cstock = NuloPorNro(_Fila.Item("Dtp_CierreDoc_Hora_Ejecucion"), Now.ToString("HH:mm:ss"))
        '_Hora_Cstock = DateAdd(DateInterval.Minute, 1, _Hora_Cstock)
        Lbl_Hora_Cierre_Documentos.Text = Format(_Hora_Cstock, "HH:mm")

        _CierreDoc_Lunes = NuloPorNro(_Fila.Item("Chk_CierreDoc_Lunes"), False)
        _CierreDoc_Martes = NuloPorNro(_Fila.Item("Chk_CierreDoc_Martes"), False)
        _CierreDoc_Miercoles = NuloPorNro(_Fila.Item("Chk_CierreDoc_Miercoles"), False)
        _CierreDoc_Jueves = NuloPorNro(_Fila.Item("Chk_CierreDoc_Jueves"), False)
        _CierreDoc_Viernes = NuloPorNro(_Fila.Item("Chk_CierreDoc_Viernes"), False)
        _CierreDoc_Sabado = NuloPorNro(_Fila.Item("Chk_CierreDoc_Sabado"), False)
        _CierreDoc_Domingo = NuloPorNro(_Fila.Item("Chk_CierreDoc_Domingo"), False)

        _Chk_COVCerrar = NuloPorNro(_Fila.Item("Chk_COVCerrar"), False)
        _Chk_NVICerrar = NuloPorNro(_Fila.Item("Chk_NVICerrar"), False)
        _Chk_NVVCerrar = NuloPorNro(_Fila.Item("Chk_NVVCerrar"), False)
        _Chk_OCICerrar = NuloPorNro(_Fila.Item("Chk_OCICerrar"), False)
        _Chk_OCCCerrar = NuloPorNro(_Fila.Item("Chk_OCCCerrar"), False)

        _Input_DiasCOV = NuloPorNro(_Fila.Item("Input_DiasCOV"), 1)
        _Input_DiasNVI = NuloPorNro(_Fila.Item("Input_DiasNVI"), 1)
        _Input_DiasNVV = NuloPorNro(_Fila.Item("Input_DiasNVV"), 1)
        _Input_DiasOCI = NuloPorNro(_Fila.Item("Input_DiasOCI"), 1)
        _Input_DiasOCI = NuloPorNro(_Fila.Item("Input_DiasOCI"), 1)
        _Input_DiasOCC = NuloPorNro(_Fila.Item("Input_DiasOCC"), 1)

        _Cl_Correos.CantMmail = NuloPorNro(_Fila.Item("CantMail"), 30)

        _Prestashop_Ejecucion_Total = NuloPorNro(_Fila.Item("Chk_Prestashop_Ejecucion_Total"), False)

        If _Prestashop_Ejecucion_Total Then

            _Hora_Cstock = NuloPorNro(_Fila.Item("Dtp_Prestashop_Total_Hora_Ejecucion"), Now.ToString("HH:mm:ss"))
            _Hora_Prestashop = Format(_Hora_Cstock, "HH:mm")
            Lbl_Prestashop.Text = "PrestaShop" & " Hora. Rev. Total: " & _Hora_Prestashop

        End If

        _Ejecutar_PrestaShop_Ordenes = Switch_Prestashop_Ordenes.Value

        _Cl_FacAuto_NVV.Modalidad_Fac = NuloPorNro(_Fila.Item("Txt_Modalidad_FacAuto"), "")
        _Cl_FacAuto_NVV.Nombre_Equipo = _Nombre_Equipo
        _Cl_FacAuto_NVV.Fac_Lunes = NuloPorNro(_Fila.Item("Chk_Fac_Lunes"), 0)
        _Cl_FacAuto_NVV.Fac_Martes = NuloPorNro(_Fila.Item("Chk_Fac_Martes"), 0)
        _Cl_FacAuto_NVV.Fac_Miercoles = NuloPorNro(_Fila.Item("Chk_Fac_Miercoles"), 0)
        _Cl_FacAuto_NVV.Fac_Jueves = NuloPorNro(_Fila.Item("Chk_Fac_Jueves"), 0)
        _Cl_FacAuto_NVV.Fac_Viernes = NuloPorNro(_Fila.Item("Chk_Fac_Viernes"), 0)
        _Cl_FacAuto_NVV.Fac_Sabado = NuloPorNro(_Fila.Item("Chk_Fac_Sabado"), 0)
        _Cl_FacAuto_NVV.Fac_Domingo = NuloPorNro(_Fila.Item("Chk_Fac_Domingo"), 0)

        _Cl_FacAuto_NVV.FA_1Dia = NuloPorNro(_Fila.Item("Rdb_FA_1Dia"), 0)
        _Cl_FacAuto_NVV.FA_1Semana = NuloPorNro(_Fila.Item("Rdb_FA_1Semana"), 0)
        _Cl_FacAuto_NVV.FA_1Mes = NuloPorNro(_Fila.Item("Rdb_FA_1Mes"), 0)
        _Cl_FacAuto_NVV.FA_1Todas = NuloPorNro(_Fila.Item("Rdb_FA_1Todas"), 0)

        AddHandler Switch_Monitoreo_doc_emitidos.ValueChanged, AddressOf Sb_Switch_DocEmitidos
        AddHandler Switch_Correos.ValueChanged, AddressOf Sb_Switch_Correo
        AddHandler Switch_Solicitud_Productos_Bodega.ValueChanged, AddressOf Sb_Switch_Solicitud_Productos_Bodega
        AddHandler Switch_Cola_Impresion.ValueChanged, AddressOf Sb_Switch_Cola_Impresion
        AddHandler Switch_Poswii.ValueChanged, AddressOf Sb_Switch_Poswii
        AddHandler Switch_Prestashop.ValueChanged, AddressOf Sb_Switch_Prestashop
        AddHandler Switch_Cons_Stock.ValueChanged, AddressOf Sb_Switch_Cons_Stock
        AddHandler Switch_Picking.ValueChanged, AddressOf Sb_Switch_Picking

        AddHandler Switch_Wordpress_Prod.ValueChanged, AddressOf Sb_Switch_Wordpress_Prod
        AddHandler Switch_Wordpress_Stock.ValueChanged, AddressOf Sb_Switch_Wordpress_Prod

        _Cl_Asistente_Compras.Chk_AsistenteDeCompras = NuloPorNro(_Fila.Item("Chk_AsistenteDeCompras"), False)
        _Cl_Asistente_Compras.Dtp_AsisCompra_Hora_Ejecucion = NuloPorNro(_Fila.Item("Dtp_AsisCompra_Hora_Ejecucion"), Now.ToString("HH:mm:ss"))

        _Cl_Asistente_Compras.Chk_AsisComEjecLunes = NuloPorNro(_Fila.Item("Chk_AsisComEjecLunes"), False)
        _Cl_Asistente_Compras.Chk_AsisComEjecMartes = NuloPorNro(_Fila.Item("Chk_AsisComEjecMartes"), False)
        _Cl_Asistente_Compras.Chk_AsisComEjecMiercoles = NuloPorNro(_Fila.Item("Chk_AsisComEjecMiercoles"), False)
        _Cl_Asistente_Compras.Chk_AsisComEjecJueves = NuloPorNro(_Fila.Item("Chk_AsisComEjecJueves"), False)
        _Cl_Asistente_Compras.Chk_AsisComEjecViernes = NuloPorNro(_Fila.Item("Chk_AsisComEjecViernes"), False)
        _Cl_Asistente_Compras.Chk_AsisComEjecSabado = NuloPorNro(_Fila.Item("Chk_AsisComEjecSabado"), False)
        _Cl_Asistente_Compras.Chk_AsisComEjecDomingo = NuloPorNro(_Fila.Item("Chk_AsisComEjecDomingo"), False)

        _Cl_Asistente_Compras.Txt_AsComModLunes = NuloPorNro(_Fila.Item("Txt_AsComModLunes"), "")
        _Cl_Asistente_Compras.Txt_AsComModMartes = NuloPorNro(_Fila.Item("Txt_AsComModMartes"), "")
        _Cl_Asistente_Compras.Txt_AsComModMiercoles = NuloPorNro(_Fila.Item("Txt_AsComModMiercoles"), "")
        _Cl_Asistente_Compras.Txt_AsComModJueves = NuloPorNro(_Fila.Item("Txt_AsComModJueves"), "")
        _Cl_Asistente_Compras.Txt_AsComModViernes = NuloPorNro(_Fila.Item("Txt_AsComModViernes"), "")
        _Cl_Asistente_Compras.Txt_AsComModSabado = NuloPorNro(_Fila.Item("Txt_AsComModSabado"), "")
        _Cl_Asistente_Compras.Txt_AsComModDomingo = NuloPorNro(_Fila.Item("Txt_AsComModDomingo"), "")

        _Hora_Cstock = _Cl_Asistente_Compras.Dtp_AsisCompra_Hora_Ejecucion
        Lbl_Hora_AsisCompra.Text = Format(_Hora_Cstock, "HH:mm")

        _Cl_Enviar_Doc_SinRecepcion.Id_Correo = NuloPorNro(_Fila.Item("Id_CtaCorreoEnvDocSinRecep"), 0)
        _Cl_Enviar_Doc_SinRecepcion.Para = NuloPorNro(_Fila.Item("Txt_ParaEnvDocSinRecep"), "")

        _Cl_Enviar_Doc_SinRecepcion.Chk_EnvDocSinRecep_EjecLunes = NuloPorNro(_Fila.Item("Chk_EnvDocSinRecep_EjecLunes"), False)
        _Cl_Enviar_Doc_SinRecepcion.Chk_EnvDocSinRecep_EjecMartes = NuloPorNro(_Fila.Item("Chk_EnvDocSinRecep_EjecMartes"), False)
        _Cl_Enviar_Doc_SinRecepcion.Chk_EnvDocSinRecep_EjecMiercoles = NuloPorNro(_Fila.Item("Chk_EnvDocSinRecep_EjecMiercoles"), False)
        _Cl_Enviar_Doc_SinRecepcion.Chk_EnvDocSinRecep_EjecJueves = NuloPorNro(_Fila.Item("Chk_EnvDocSinRecep_EjecJueves"), False)
        _Cl_Enviar_Doc_SinRecepcion.Chk_EnvDocSinRecep_EjecViernes = NuloPorNro(_Fila.Item("Chk_EnvDocSinRecep_EjecViernes"), False)
        _Cl_Enviar_Doc_SinRecepcion.Chk_EnvDocSinRecep_EjecSabado = NuloPorNro(_Fila.Item("Chk_EnvDocSinRecep_EjecSabado"), False)
        _Cl_Enviar_Doc_SinRecepcion.Chk_EnvDocSinRecep_EjecDomingo = NuloPorNro(_Fila.Item("Chk_EnvDocSinRecep_EjecDomingo"), False)

        _Cl_Enviar_Doc_SinRecepcion.Chk_EnvDocSinRecep = NuloPorNro(_Fila.Item("Chk_EnvDocSinRecep"), False)
        _Cl_Enviar_Doc_SinRecepcion.Dtp_EnvDocSinRecep_Hora_Ejecucion = NuloPorNro(_Fila.Item("Dtp_EnvDocSinRecep_Hora_Ejecucion"), Now.ToString("HH:mm:ss"))

        _Cl_Enviar_Doc_SinRecepcion.COV = NuloPorNro(_Fila.Item("EnvDocSinRecep_COV"), False)
        _Cl_Enviar_Doc_SinRecepcion.NVI = NuloPorNro(_Fila.Item("EnvDocSinRecep_NVI"), False)
        _Cl_Enviar_Doc_SinRecepcion.NVV = NuloPorNro(_Fila.Item("EnvDocSinRecep_NVV"), False)
        _Cl_Enviar_Doc_SinRecepcion.OCI = NuloPorNro(_Fila.Item("EnvDocSinRecep_OCI"), False)
        _Cl_Enviar_Doc_SinRecepcion.OCC = NuloPorNro(_Fila.Item("EnvDocSinRecep_OCC"), False)
        _Cl_Enviar_Doc_SinRecepcion.GTI = NuloPorNro(_Fila.Item("EnvDocSinRecep_GTI"), False)
        _Cl_Enviar_Doc_SinRecepcion.GDI = NuloPorNro(_Fila.Item("EnvDocSinRecep_GDI"), False)

        _Cl_Enviar_Doc_SinRecepcion.DiasCOV = NuloPorNro(_Fila.Item("EnvDocSinRecep_DiasCOV"), 0)
        _Cl_Enviar_Doc_SinRecepcion.DiasNVI = NuloPorNro(_Fila.Item("EnvDocSinRecep_DiasNVI"), 0)
        _Cl_Enviar_Doc_SinRecepcion.DiasNVV = NuloPorNro(_Fila.Item("EnvDocSinRecep_DiasNVV"), 0)
        _Cl_Enviar_Doc_SinRecepcion.DiasOCI = NuloPorNro(_Fila.Item("EnvDocSinRecep_DiasOCI"), 0)
        _Cl_Enviar_Doc_SinRecepcion.DiasOCC = NuloPorNro(_Fila.Item("EnvDocSinRecep_DiasOCC"), 0)
        _Cl_Enviar_Doc_SinRecepcion.DiasGTI = NuloPorNro(_Fila.Item("EnvDocSinRecep_DiasGTI"), 0)
        _Cl_Enviar_Doc_SinRecepcion.DiasGDI = NuloPorNro(_Fila.Item("EnvDocSinRecep_DiasGDI"), 0)

        _Hora_Cstock = _Cl_Enviar_Doc_SinRecepcion.Dtp_EnvDocSinRecep_Hora_Ejecucion
        Lbl_Hora_EnvDocSinRecep.Text = Format(_Hora_Cstock, "HH:mm")

        Sb_Pausar(_Pausa.Play)

        Dim _Dir_Local As String = AppPath() & "\Data\"

        _Nombre_Equipo = My.Computer.Name

        'Dim _Ds As New DatosBakApp
        '_Ds.Clear()
        '_Ds.ReadXml(_Dir_Local & RutEmpresa & "\Configuracion_Local\Nombre_Equipo.xml")

        '_Row_Nom_Equipo = _Ds.Tables("Tbl_Nombre_Equipo").Rows(0)

        _Nombre_Equipo = _Global_Row_EstacionBk.Item("NombreEquipo") '_Row_Nom_Equipo.Item("Nombre_Equipo")

    End Sub


    Sub Sb_Enable_Objetos()

        CircularPgrs.IsRunning = True
        CircularMail.IsRunning = Switch_Correos.Value
        Circular_Cola_Impresion.IsRunning = Switch_Cola_Impresion.Value
        Circular_SolicitudProductosBodega.IsRunning = Switch_Solicitud_Productos_Bodega.Value
        Circular_Poswii.IsRunning = Switch_Poswii.Value
        Circular_Prestashop.IsRunning = Switch_Prestashop.Value
        Circular_Prestashop_Ordenes.IsRunning = Switch_Prestashop.Value
        Circular_Cons_Stock.IsRunning = Switch_Cons_Stock.Value
        CircularPicking.IsRunning = Switch_Picking.Value
        CircularLibroDTESII.IsRunning = Switch_LibroDTESII.Value
        CircularListasProgramadas.IsRunning = Switch_Listas_Programadas.Value
        CircularFacAuto.IsRunning = Switch_FacAuto.Value
        CircularAsisCompra.IsRunning = Switch_AsisCompras.Value

        PicBox_Archivador.Enabled = Switch_Archivador.Value
        PicBox_Cola_Impresion.Enabled = Switch_Cola_Impresion.Value
        PicBox_Consolidacion_Stock.Enabled = Switch_Cons_Stock.Value
        PicBox_Correo.Enabled = Switch_Correos.Value
        PicBox_Documentos.Enabled = Switch_Monitoreo_doc_emitidos.Value
        PicBox_LibroDTESII.Enabled = Switch_LibroDTESII.Value
        PicBox_Imprimir_Picking.Enabled = Switch_Picking.Value
        PicBox_Prestashop.Enabled = Switch_Prestashop.Value
        PicBox_Sol_Prod_Bodega.Enabled = Switch_Solicitud_Productos_Bodega.Value
        PictureBox7.Enabled = Switch_FacAuto.Value

        Lbl_Archivador.Enabled = Switch_Archivador.Value
        Lbl_Cola_Impresion.Enabled = Switch_Cola_Impresion.Value
        Lbl_Consolidacion_Stock.Enabled = Switch_Cons_Stock.Value
        Lbl_Correo.Enabled = Switch_Correos.Value
        LblDocumentos.Enabled = Switch_Monitoreo_doc_emitidos.Value
        Lbl_LibroDTESII.Enabled = Switch_LibroDTESII.Value
        Lbl_Imprimir_Picking.Enabled = Switch_Picking.Value
        Lbl_Prestashop.Enabled = Switch_Prestashop.Value
        Lbl_Prestashop_Ordenes.Enabled = Switch_Prestashop_Ordenes.Value

        Lbl_Sol_Prod_Bodega.Enabled = Switch_Solicitud_Productos_Bodega.Value
        Lbl_FacAuto.Enabled = Switch_FacAuto.Value

        Lbl_Wordpress_productos.Enabled = Switch_Wordpress_Prod.Value
        Lbl_Wordpress_Stock_Precios.Enabled = Switch_Wordpress_Stock.Value
        Lbl_Cierre_Documentos.Enabled = Switch_Cierre_Documentos.Value
        Lbl_AsisCompras.Enabled = Switch_AsisCompras.Value

    End Sub


    Sub Sb_Actv_Botones_Configuracion()

        Dim _Enable_Conf = False

        If Not Switch_Cola_Impresion.Value Then _Enable_Conf = True

        'Btn_Filtro_Doc_Impresion.Enabled = _Enable_Conf
        Btn_Lista_Doc_Impresos.Enabled = _Enable_Conf
        Btn_LogError_Poswii.Enabled = _Enable_Conf

        _Enable_Conf = False

        If Not Switch_Correos.Value Then _Enable_Conf = True

        ' Btn_Filtro_Doc_Correo.Enabled = _Enable_Conf

        _Enable_Conf = False

        If Not Switch_Prestashop.Value Then _Enable_Conf = True
        ' Btn_Filtro_Doc_Prestashop.Enabled = _Enable_Conf

    End Sub

    Sub LlenaComboTipoDoc()

        'caract_combo(CmbTido)

        Dim dt As New DataTable("Tabla1")
        Dim dr As DataRow
        Dim rs As New DataSet("Ds")

        'creamos las mismas columnas que hay en el dataset
        dt.Columns.Add("Padre", System.Type.[GetType]("System.String"))
        dt.Columns.Add("Hijo", System.Type.[GetType]("System.String"))
        ',,,,,,

        dr = dt.NewRow() : dr("Padre") = "BLV" : dr("Hijo") = "Boleta" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Padre") = "FCV" : dr("Hijo") = "Factura" : dt.Rows.Add(dr)
        'cerramos el datareader y la conexión
        'añadimos la tabla al dataset
        rs.Tables.Add(dt)

        'With CmbTido
        ' .DataSource = Nothing
        ' .DataSource = dt
        'End With

    End Sub

    Public Function Fx_Imprimir_Vale(_Id As String,
                                    Optional _Solicita_Producto_Bodega As Boolean = False)

        Try
            Sb_Pausar(_Pausa.Pausa)
            ' ejemplo simple para imprimir en .NET
            ' Usamos una clase del tipo PrintDocument

            Dim _Tipo As String
            Dim _Numero As String
            Dim _EsVale As Boolean
            Dim _Nombre_documento As String


            If Not _Solicita_Producto_Bodega Then

                _EsVale = _Sql.Fx_Trae_Dato("MAEEDO", "NUDONODEFI", "IDMAEEDO = " & _Id)

                Dim _OrdenDetalle As String

                If _EsVale Then
                    _OrdenDetalle = "ORDER BY UBICACION"
                Else
                    _OrdenDetalle = "ORDER BY IDMAEDDO"
                End If

                Consulta_sql = My.Resources.Recursos_Demonio.Picking
                Consulta_sql = Replace(Consulta_sql, "#Idmaeedo#", _Id)
                Consulta_sql = Replace(Consulta_sql, "#Orden_Detalle#", _OrdenDetalle)

                _DsDatos = _Sql.Fx_Get_DataSet(Consulta_sql)


                _TblEncabezado = _DsDatos.Tables(0)
                _TblDetalle = _DsDatos.Tables(1)
                _TblObservaciones = _DsDatos.Tables(2)
                _TblDocOrigen = _DsDatos.Tables(3)
                _Tipo = _TblEncabezado.Rows(0).Item("TIDO")
                _Numero = _TblEncabezado.Rows(0).Item("NUDO")
                _Nombre_documento = _Tipo & "-" & _Numero
                _Imprimir_Barras = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Picking_Doc", "Imprimir_Barras", "TipoDoc = '" & _Tipo & "'")

            Else

                Consulta_sql = "SELECT Id,CodSolicitud,Estado,Funcionario," & vbCrLf &
                               "(Select top 1 NOKOFU From TABFU Where KOFU = Funcionario) As 'Vendedor'," & vbCrLf &
                               "Codigo,Descripcion,Empresa,Sucursal,Bodega," & vbCrLf &
                               "(Select top 1 NOKOBO From TABBO" & vbCrLf &
                               "Where EMPRESA = Empresa And KOSU = Sucursal And KOBO = Bodega) As 'Bod_'," & vbCrLf &
                               "Ubicacion,FechaHora_Solicita," & vbCrLf &
                               "FechaHora_Entrega,FechaHora_Recibe,FechaHora_Cierre," & vbCrLf &
                               "Funcionario_Entrega,Funcionario_Recibe,Funcionario_Autoriza_pasar," & vbCrLf &
                               "Funcionario_Autoriza_cierre,Motivo_cierre,Impreso," & vbCrLf &
                               "(Select Top 1 STFI1 From MAEST" & vbCrLf &
                               "Where EMPRESA = Empresa And KOSU = Sucursal And KOBO = Bodega And KOPR = Codigo) As Stock" & vbCrLf &
                               "FROM " & _Global_BaseBk & "Zw_Prod_SolBodega" & vbCrLf &
                               "Where Id = " & _Id
                _DsDatos = _Sql.Fx_Get_DataSet(Consulta_sql)
                _Tipo = "SOLPRBOD"
                _Nombre_documento = "Sol_ProductoBodega"
            End If

            Dim printDoc As New PrintDocument

            'Dim pd As Printing.PrintDocument
            'pd = New Printing.PrintDocument

            Dim pkCustomSize1 As New Printing.PaperSize("Custom Paper Size", 100, 5000)
            printDoc.PrinterSettings.DefaultPageSettings.PaperSize = pkCustomSize1

            ' asignamos el método de evento para cada página a imprimir

            Select Case _Tipo
                'Case "FCV"
                'If _EsVale Then
                'AddHandler printDoc.PrintPage, AddressOf Sb_Print_PrintPage_Vale_Trans
                'Else
                'AddHandler printDoc.PrintPage, AddressOf Sb_Print_PrintPage_Picking
                'End If
                'Case "BLV"
                'If _EsVale Then
                'AddHandler printDoc.PrintPage, AddressOf Sb_Print_PrintPage_Vale_Trans
                'Else
                'AddHandler printDoc.PrintPage, AddressOf Sb_Print_PrintPage_Picking
                'End If
                'Case "COV"
                'AddHandler printDoc.PrintPage, AddressOf Sb_Print_PrintPage_Cotizacion
                'Case "NVV"
                'AddHandler printDoc.PrintPage, AddressOf Sb_Print_PrintPage_NotaDeVenta
                Case "SOLPRBOD"
                    AddHandler printDoc.PrintPage, AddressOf Sb_Print_PrintPage_Solicita_Producto
                    'Case "OCC"
                    'AddHandler printDoc.PrintPage, AddressOf Sb_Print_PrintPage_OrdenDeCompra
                    'Case "GRC"
                    'AddHandler printDoc.PrintPage, AddressOf Sb_Print_PrintPage_GuiaRecepcionCompra
                Case Else
                    MessageBoxEx.Show("No existe formato para el documento", "Imprimir", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return False
                    Exit Function
            End Select

            ' indicamos que queremos imprimir

            printDoc.DocumentName = _Nombre_documento

            Dim _Impresora As String

            If String.IsNullOrEmpty(_Impresora_Prod_Sol_Bodega) Then
                Dim prtDialog As New PrintDialog
                If prtSettings Is Nothing Then
                    prtSettings = New PrinterSettings
                End If

                With prtDialog
                    .AllowPrintToFile = False
                    .AllowSelection = False
                    .AllowSomePages = False
                    .PrintToFile = False
                    .ShowHelp = False
                    .ShowNetwork = True

                    .PrinterSettings = prtSettings

                    If .ShowDialog(Me) = DialogResult.OK Then
                        _Impresora = .PrinterSettings.PrinterName
                    Else
                        Return False
                    End If

                End With
            End If


            printDoc.PrinterSettings.PrinterName = _Impresora
            printDoc.Print()


            Return True
        Catch ex As Exception
            Return False
            MsgBox(ex.Message)
        Finally
            Sb_Pausar(_Pausa.Play)
        End Try
    End Function

    Sub Sb_Switch_DocEmitidos(sender As System.Object, e As System.EventArgs)

        'Dim Permiso = Fx_Tiene_Permiso(Me, "Pick0009")

        'If Not Permiso Then
        'RemoveHandler Switch_Monitoreo_doc_emitidos.ValueChanged, AddressOf Sb_Switch_DocEmitidos
        'Switch_Monitoreo_doc_emitidos.Value = False
        'AddHandler Switch_Monitoreo_doc_emitidos.ValueChanged, AddressOf Sb_Switch_DocEmitidos
        'End If

        CircularPgrs.IsRunning = Switch_Monitoreo_doc_emitidos.Value

    End Sub

    Sub Sb_Switch_Correo(sender As System.Object, e As System.EventArgs)

        CircularMail.IsRunning = Switch_Correos.Value
        If Switch_Correos.Value Then _Segundos_Correo = _Input_Tiempo_Correo / 1000
        Sb_Actv_Botones_Configuracion()

    End Sub

    Sub Sb_Switch_Cola_Impresion(sender As System.Object, e As System.EventArgs)

        Circular_Cola_Impresion.IsRunning = Switch_Cola_Impresion.Value

        If Switch_Cola_Impresion.Value Then
            Btn_LogError_Impresion.Visible = False
            _Segundos_Impresion = _Input_Tiempo_Impresion / 1000
            Btn_Lista_Doc_Impresos.Enabled = False
        Else
            Btn_Lista_Doc_Impresos.Enabled = True
        End If

    End Sub

    Private Sub Sb_Switch_Solicitud_Productos_Bodega(sender As System.Object, e As System.EventArgs)

        Circular_SolicitudProductosBodega.IsRunning = Switch_Solicitud_Productos_Bodega.Value
        If Switch_Solicitud_Productos_Bodega.Value Then _Segundos_Sol_Bodega = _Input_Tiempo_Sol_Bodega / 1000

    End Sub

    Sub Sb_Switch_Poswii(sender As System.Object, e As System.EventArgs)

        Circular_Poswii.IsRunning = Switch_Poswii.Value

        If Switch_Poswii.Value Then
            Btn_LogError_Poswii.Visible = False
            _Segundos_Poswii = _Input_Tiempo_Poswii / 1000
        End If

        Sb_Actv_Botones_Configuracion()

    End Sub

    Sub Sb_Switch_Prestashop(sender As System.Object, e As System.EventArgs)

        Circular_Prestashop.IsRunning = Switch_Prestashop.Value

        If Switch_Prestashop.Value Then

            If _Procesando_Prestashop Then
                Beep()
                ToastNotification.Show(Me, "¡SE ESTAN PROCESANDO DATOS!", My.Resources.cross,
                                            2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
                Switch_Prestashop.Value = False
            Else
                Btn_LogError_Prestashop.Visible = False
                Btn_Reenviar_Con_Errores_Prestashop.Visible = False
                _Minutos_Prestashop = (_Input_Tiempo_Prestashop / 1000 / 60) - 1
                _Segundos_Prestashop = 59
            End If

        End If

        Sb_Actv_Botones_Configuracion()

    End Sub

    Sub Sb_Switch_Cons_Stock(sender As System.Object, e As System.EventArgs)
        Circular_Cons_Stock.IsRunning = Switch_Prestashop.Value
    End Sub

    Sub Sb_Switch_Picking(sender As System.Object, e As System.EventArgs)

        CircularPicking.IsRunning = Switch_Picking.Value
        If Switch_Picking.Value Then _Segundos_Picking = _Input_Tiempo_Picking / 1000

    End Sub

    Sub Sb_Switch_LibroDTESII(sender As System.Object, e As System.EventArgs)

        CircularLibroDTESII.IsRunning = Switch_LibroDTESII.Value
        If Switch_LibroDTESII.Value Then _Segundos_LibroDTESII = _Input_Tiempo_LibroDTESII / 1000
        Lbl_LibroDTESII.Text = "Monitoreo Libro DTE desde SII"

    End Sub

    Sub Sb_Switch_Wordpress_Stock(sender As System.Object, e As System.EventArgs)

        CircularWordpressStock.IsRunning = Switch_Picking.Value
        If Switch_Wordpress_Stock.Value Then
            _Minutos_Wordpress_Stock = (_Input_Tiempo_Wordpress_Stock / 1000 / 60) - 1
            _Segundos_Wordpress_Stock = 59
        End If

    End Sub

    Sub Sb_Switch_Wordpress_Prod(sender As System.Object, e As System.EventArgs)

        CircularWordpressStock.IsRunning = Switch_Picking.Value
        If Switch_Wordpress_Prod.Value Then
            _Minutos_Wordpress_Prod = (_Input_Tiempo_Wordpress_Productos / 1000 / 60) - 1
            _Segundos_Wordpress_Prod = 59
        End If

    End Sub

    Sub Sb_Pausar(_Pausar As _Pausa)

        If _Pausar = _Pausa.Pausa Then
            Timer_Segundos.Enabled = False
        ElseIf _Pausar = _Pausa.Play Then
            Timer_Segundos.Enabled = True
        End If

        Sb_Enable_Objetos()

    End Sub

    Sub Sb_Revisar_Guia_De_Recepcion_GRC(Idmaeedo)

        Sb_Pausar(_Pausa.Pausa)

        Dim _Mail_Envio, _Mail_Fallo As Integer


        Consulta_sql = "SELECT Id_SOC, Vendedor, (Select NOKOFU from TABFU Where KOFU = Ed.Vendedor) AS NombreUsuario," &
                       "(Select EMAIL from TABFU Where KOFU = Ed.Vendedor) AS Email, IdMaeedo_OCC" & vbCrLf &
                       "FROM " & _Global_BaseBk & "ZW_SOC_Encabezado AS Ed" & vbCrLf &
                       "WHERE IdMaeedo_OCC IN (SELECT IDMAEEDO FROM MAEEDO WHERE TIDO+NUDO IN " & vbCrLf &
                       "(select distinct TIDOPA+NUDOPA FROM MAEDDO " & vbCrLf &
                       "WHERE IDMAEEDO = " & Idmaeedo & "))"

        Dim TblUsuarios = _Sql.Fx_Get_Tablas(Consulta_sql)

        ' Dim Cont As Integer
        If TblUsuarios.Rows.Count > 0 Then
            For Each Fila As DataRow In TblUsuarios.Rows 'Cont = 0 To 32
                'Dim Observacion = _Sql.Fx_Trae_Dato(, "TEXTO" & Cont + 1, "MAEEDOOB", "IDMAEEDO = " & Idmaeedo)

                Dim _Id_SOC = Fila.Item("Id_SOC").ToString 'IdSolicitud
                Dim _CodUsuario = Fila.Item("Vendedor").ToString
                Dim _NombreVendedor = Trim(Fila.Item("NombreUsuario").ToString)
                Dim _Para = Trim(Fila.Item("Email").ToString)
                Dim Fecha As Date = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Picking", "Fecha", "Idmaeedo =" & Idmaeedo)
                Dim Hora As Date = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Picking", "Hora", "Idmaeedo =" & Idmaeedo)

                'Dim Observacion = FilasObs.Item("TEXTO" & Cont + 1)
                If Not String.IsNullOrEmpty(_Para) Then

                    Dim FechaRecep = FormatDateTime(Fecha, DateFormat.ShortDate)
                    Dim HoraRecep = FormatDateTime(Hora, DateFormat.ShortTime)

                    ' Dim RecibeMail = Fx_Tiene_Permiso(Me, "Not0007", CodUsuario, True)

                    Dim _Crea_Htm As New Clase_Crear_Documento_Htm
                    Dim _Ruta As String = AppPath() & "\Data\" & RutEmpresa & "\Tmp"

                    Dim _Cuerpo_Html

                    If _Crea_Htm.Fx_Crear_Documento_Htm(Idmaeedo, _Ruta, False) Then
                        Dim _Dir As String = _Ruta & "\Documento.Htm"
                        _Cuerpo_Html = LeeArchivo(_Dir)
                    End If

                    Dim _Id As Integer = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Picking_Doc", "Id_Correo", "TipoDoc = 'GRC'")

                    Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Correos Where Id = " & NuloPorNro(_Id, 0)
                    Dim _TblCorreo As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                    If CBool(_TblCorreo.Rows.Count) Then

                        Dim _Remitente = Trim(_TblCorreo.Rows(0).Item("Remitente"))
                        Dim _CC = _TblCorreo.Rows(0).Item("CC")
                        Dim _Host = _TblCorreo.Rows(0).Item("Host")
                        Dim _Puerto = _TblCorreo.Rows(0).Item("Puerto")
                        Dim _Contrasena = Trim(_TblCorreo.Rows(0).Item("Contrasena"))
                        Dim _Asunto = _TblCorreo.Rows(0).Item("Asunto")
                        Dim _CuerpoMensaje = _TblCorreo.Rows(0).Item("CuerpoMensaje")
                        Dim _SSL = _TblCorreo.Rows(0).Item("SSL")


                        _CuerpoMensaje = Replace(_CuerpoMensaje, "<HTML>", _Cuerpo_Html & vbCrLf)

                        Dim _Filas As Integer

                        If String.IsNullOrEmpty(_Asunto) Then
                            _Asunto = "Recepción de mercadería en bodega solicitada por usted."
                        End If

                        Dim EnviarCorreo As New Frm_Correos_Conf


                        If EnviarCorreo.Fx_Enviar_Mail(_Host,
                                                       _Remitente,
                                                       _Contrasena,
                                                       _Para,
                                                       _CC,
                                                       _Asunto,
                                                       _CuerpoMensaje,
                                                       Nothing,
                                                       _Puerto,
                                                       _SSL,
                                                       False) Then
                            _Correos_Enviados += 1
                            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Picking set Correo = 1 Where Idmaeedo = " & Idmaeedo
                            _Sql.Ej_consulta_IDU(Consulta_sql)

                            Consulta_sql = "Insert into " & _Global_BaseBk & "Zw_CorreosEnvioRecepcion (Remitente,Para,CC,Fecha, " &
                                           "Hora,Idmaeedo,Estado,Asunto,Mensaje) values " & vbCrLf &
                                           "('" & _Remitente & "','" & _Para & "','" & _CC & "',Getdate(),Getdate(),'" & Idmaeedo &
                                           "','E','" & _Asunto & "','Aviso: Llega mercadería a la bodega, mercadería solicitada por el usuraio (" & _NombreVendedor & ")')"
                            _Sql.Ej_consulta_IDU(Consulta_sql)

                            _Mail_Envio += 1
                        Else
                            _Correos_Rechazados += 1
                            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Picking set Correo = 1 Where Idmaeedo = " & Idmaeedo
                            _Sql.Ej_consulta_IDU(Consulta_sql)

                            Consulta_sql = "Insert into " & _Global_BaseBk & "Zw_CorreosEnvioRecepcion (Remitente,Para,CC,Fecha," &
                                           "Hora,Idmaeedo,Estado,Asunto,Mensaje) values " & vbCrLf &
                                           "('" & _Remitente & "','" & _Para & "','" & _CC & "',Getdate(),Getdate(),'" & Idmaeedo &
                                           "','R','" & _Asunto & "','" & Replace(EnviarCorreo.Pro_Error, "'", "´") & "')"
                            _Sql.Ej_consulta_IDU(Consulta_sql)
                            _Mail_Fallo += 1
                        End If


                    End If



                    'If RecibeMail Then
                    'EnviarCorreoporGRC(Email, NombreVendedor, Idmaeedo, Solicitud, FechaRecep, HoraRecep)
                    'End If

                End If
            Next
            'Consulta_sql = "Update Zw_Picking set Correo = 1 Where Idmaeedo = " & Idmaeedo
            ' _Sql.Ej_consulta_IDU(Consulta_Sql)
        Else
            Consulta_sql = "Update Zw_Picking set Correo = 1 Where Idmaeedo = " & Idmaeedo
            _Sql.Ej_consulta_IDU(Consulta_sql)
        End If

        If CBool(_Mail_Envio) Then

            csNotificaciones.Notificacion.mostrarVentana("Información BakApp",
                                                            _Mail_Envio & " correos de información" & vbCrLf &
                                                            "enviados correctamente",
                                                            csNotificaciones.Notificacion.Imagen.Internet, 3, True)
        End If

        If CBool(_Mail_Fallo) Then
            'Me.Hide()
            'Notificacion_Correos.Visible = True
            'Notificacion_Correos.ShowBalloonTip(10, "Info. BakApp", "Problemas con el envio de correos de información", _
            '                                    ToolTipIcon.Error)

            csNotificaciones.Notificacion.mostrarVentana("Información BakApp",
                                                            _Mail_Envio & " correos de información" & vbCrLf &
                                                            "Problemas con el envío de los correos de aviso",
                                                            csNotificaciones.Notificacion.Imagen.Error, 3, True)

        End If

        Sb_Pausar(_Pausa.Play)

        'Lbl_Correos.Text = "Enviados: " & _Correos_Enviados & ", Rechazados: " & _Correos_Rechazados
        Me.Refresh()

    End Sub

    Private Sub BtnCambFecha_Click(sender As System.Object, e As System.EventArgs) Handles BtnCambFecha.Click

        If Fx_Tiene_Permiso(Me, "Pick0007") Then
            DtpFecharevision.Enabled = True
        End If

    End Sub

    Private Sub DtpFecharevision_ValueChanged(sender As System.Object, e As System.EventArgs) Handles DtpFecharevision.ValueChanged
        DtpFecharevision.Enabled = False
    End Sub

#Region "Imprimir Solitud producto"

    Private Sub Sb_Print_PrintPage_Solicita_Producto(sender As Object,
                                       e As PrintPageEventArgs)


        ' Este evento se producirá cada vez que se imprima una nueva página
        ' imprimir HOLA MUNDO en Arial tamaño 24 y negrita

        Dim _Fila_Producto As DataRow = _DsDatos.Tables(0).Rows(0) 'Encabezado del vale
        Dim _CodSolicitud As String = _Fila_Producto.Item("CodSolicitud")

        Try
            'Vale-BkPost
            Dim bm As Bitmap = Nothing
            Dim CodBarras As New PictureBox
            Dim Imagen As New PictureBox


            Dim iType As BarCode.Code128SubTypes =
             DirectCast([Enum].Parse(GetType(BarCode.Code128SubTypes), "CODE128"), BarCode.Code128SubTypes)
            bm = BarCode.Code128(UCase(_CodSolicitud), iType, False)
            If Not IsNothing(bm) Then
                CodBarras.Image = bm
            End If

            ' imprimimos la cadena en el margen izquierdo
            Dim xPos As Single = 3 'e.MarginBounds.Left
            ' La fuente a usar

            Dim DtFont As New Font("Arial", 7, FontStyle.Regular) ' Fuente del detalle
            Dim Dt2Font As New Font("Arial", 8, FontStyle.Bold)   ' Fuente del detalle
            Dim prFont As New Font("Arial", 9, FontStyle.Bold)    ' Fuente Encabezado
            Dim Fte_Arial_12 As New Font("Arial", 12, FontStyle.Bold)    ' Fuente Encabezado


            Dim FontNro As New Font("Times New Roman", 14, FontStyle.Bold)
            Dim FontCon As New Font("Times New Roman", 11, FontStyle.Bold)
            ' la posición superior
            Dim yPos As Single = prFont.GetHeight(e.Graphics) - 10

            'tb = TablaOigenr 'DirectCast(Grilla.DataSource, DataTable)
            'Encabezado

            'Try
            'Imagen.Image = New System.Drawing.Bitmap(_RutaImagen)
            'e.Graphics.DrawImage(Imagen.Image, xPos + 10, yPos, 250, 200)
            'Catch ex As Exception
            'End Try

            Dim _Hora_actual = FormatDateTime(Date.Now, DateFormat.ShortTime).ToString
            Dim _Fecha_actual = FormatDateTime(Date.Now, DateFormat.ShortDate).ToString

            Dim _Fecha_servidor = FormatDateTime(FechaDelServidor(), DateFormat.ShortTime).ToString

            Dim NroLineasPagina As Integer = e.PageBounds.Height / Dt2Font.GetHeight(e.Graphics)

            'yPos += 180
            'e.Graphics.DrawString("VALE DE MERCADERIA PENDIENTE", prFont, Brushes.Black, xPos, yPos)
            e.Graphics.DrawString("SOLICITUD DE PRODUCTOS", Fte_Arial_12, Brushes.Black, xPos, yPos)
            yPos += 10
            e.Graphics.DrawString("_____________________________________________", Dt2Font, Brushes.Black, xPos, yPos)
            yPos += 15

            Dim _Vendedor = Trim(_Fila_Producto.Item("Vendedor"))
            'e.Graphics.DrawString("Solicitado por: " & _Vendedor, prFont, Brushes.Black, xPos, yPos)
            'yPos += 12

            e.Graphics.DrawString("_____________________________________________", Dt2Font, Brushes.Black, xPos, yPos)
            yPos += 15

            Dim _Id As String = _Fila_Producto.Item("Id")
            e.Graphics.DrawString("VALE: " & _Id, Fte_Arial_12, Brushes.Black, xPos, yPos)
            yPos += 20
            'e.Graphics.DrawString("_____________________________________________", Dt2Font, Brushes.Black, xPos, yPos)
            'yPos = yPos + 15

            e.Graphics.DrawString("SOLICITA. : " & _Vendedor, prFont, Brushes.Black, xPos, yPos)
            yPos += 15
            e.Graphics.DrawString("FECHA: " & _Fecha_actual, prFont, Brushes.Black, xPos, yPos)
            yPos += 15
            e.Graphics.DrawString("HORA: " & _Hora_actual, prFont, Brushes.Black, xPos, yPos)
            yPos += 5
            e.Graphics.DrawString("_____________________________________________", Dt2Font, Brushes.Black, xPos, yPos)
            yPos += 25


            Dim _CodProducto = _Fila_Producto.Item("Codigo")
            e.Graphics.DrawString("Código: ", Dt2Font, Brushes.Black, xPos, yPos)
            yPos += 12
            e.Graphics.DrawString(_CodProducto, Dt2Font, Brushes.Black, xPos, yPos)
            yPos += 18

            Dim _Descripcion = _Fila_Producto.Item("Descripcion")
            e.Graphics.DrawString("Descripción: ", Dt2Font, Brushes.Black, xPos, yPos)
            yPos += 12
            e.Graphics.DrawString(Mid(_Descripcion, 1, 40), Dt2Font, Brushes.Black, xPos, yPos)
            yPos += 18

            Dim _Bodega = _Fila_Producto.Item("Bod_")
            e.Graphics.DrawString("Bodega: ", Dt2Font, Brushes.Black, xPos, yPos)
            yPos += 12
            e.Graphics.DrawString(_Bodega, Dt2Font, Brushes.Black, xPos, yPos)
            yPos += 18

            Dim Stock = _Fila_Producto.Item("Stock")
            e.Graphics.DrawString("Stock: ", Dt2Font, Brushes.Black, xPos, yPos)
            yPos += 12
            e.Graphics.DrawString(Stock, Dt2Font, Brushes.Black, xPos, yPos)
            yPos += 18

            Dim _Ubicacion = _Fila_Producto.Item("Ubicacion")
            e.Graphics.DrawString("Ubicación: ", Dt2Font, Brushes.Black, xPos, yPos)
            yPos += 12
            e.Graphics.DrawString(_Ubicacion, Dt2Font, Brushes.Black, xPos, yPos)
            yPos += 18

            e.Graphics.DrawString("_____________________________________________", Dt2Font, Brushes.Black, xPos, yPos)
            yPos = yPos + 15
            '------------------------


            yPos = yPos + 30
            e.Graphics.DrawImage(CodBarras.Image, xPos + 10, yPos, 220, 70)
            e.HasMorePages = False

        Catch ex As Exception
            My.Computer.FileSystem.WriteAllText("Log_Errores.log", ex.Message & vbCrLf & ex.StackTrace, False)
            MsgBox(ex.Message)
            MsgBox("Error lo puesde ver en archivo Log de errores")
        End Try

    End Sub


#End Region

    Private Sub Btn_On_Off_Click(sender As System.Object, e As System.EventArgs) Handles Btn_On_Off.Click

        Dim _Validar As Boolean

        If Switch_Correos.Enabled Then
            _Validar = False
        Else
            Dim Fm As New Frm_ValidarPermiso(Frm_ValidarPermiso.Tipo_Accion.Validar_Permiso, "Pick0011", True, False)
            Fm.Pro_Cerrar_Automaticamente = True
            Fm.ShowDialog(Me)
            _Validar = Fm.Pro_Permiso_Aceptado
            Fm.Dispose()
        End If

        If _Validar Then

            Switch_Correos.Enabled = _Validar
            Switch_Monitoreo_doc_emitidos.Enabled = _Validar
            Switch_Cola_Impresion.Enabled = _Validar
            Switch_Solicitud_Productos_Bodega.Enabled = _Validar
            Switch_Poswii.Enabled = _Validar
            Switch_Prestashop.Enabled = _Validar
            Switch_Cons_Stock.Enabled = _Validar
            Chk_Solo_Marcar_No_Imprimir.Enabled = _Validar

        End If

    End Sub

    Private Sub Tiempo_Hora_Actual_Tick(sender As System.Object, e As System.EventArgs) Handles Timer_Hora_Actual.Tick

        Lbl_Correo.Text = _Cl_Correos.Lbl_Estado
        Lbl_Prestashop.Text = _Cl_Prestashop_Web.Etiqueta2.Text
        Lbl_Archivador.Text = _Cl_Archivador.Lbl_Estado

        Me.Text = "Acciones automaticas, Hora actual: " & Date.Now.ToLongTimeString & ", versión: [" & _Version_BkSpecialPrograms & "]"

    End Sub

    Private Sub Frm_Imp_Picking_01_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            _Minimizar = True
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Filtro_Doc_Correo_Click(sender As System.Object, e As System.EventArgs)
        Sb_Pausar(_Pausa.Pausa)
        Dim Fm As New Frm_Demonio_02_Conf_X_Estacion(Frm_Demonio_04_Conf_Impr_X_Funcionarios.Tipo_Configuracion.Correo)
        Fm.Pro_NombreEquipo = Pro_NombreEquipo
        Fm.ShowDialog(Me)
        If Fm.Pro_Grabar Then
            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Fm.Dispose()
        Sb_Pausar(_Pausa.Play)
    End Sub

    Private Sub Btn_Filtro_Doc_Impresion_Click(sender As System.Object, e As System.EventArgs)
        Sb_Pausar(_Pausa.Pausa)
        Dim Fm As New Frm_Demonio_02_Conf_X_Estacion(Frm_Demonio_04_Conf_Impr_X_Funcionarios.Tipo_Configuracion.Impresion)
        Fm.Pro_NombreEquipo = Pro_NombreEquipo
        'Fm.Pro_Impresora = _Impresora
        Fm.ShowDialog(Me)
        If Fm.Pro_Grabar Then
            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Fm.Dispose()
        Sb_Pausar(_Pausa.Play)
    End Sub

    Sub Sb_Ver_Documentos_Impresos()
        Sb_Pausar(_Pausa.Pausa)
        Dim _Tbl As DataTable

        Dim Fm As New Frm_Demonio_03_Doc_Impresos_X_Estacion
        'Fm.Pro_Impresora = _Impresora
        Fm.Pro_Nombre_Equipo = Pro_NombreEquipo
        _Tbl = Fm.Pro_Tbl_Doc_A_Imprimir

        If CBool(_Tbl.Rows.Count) Then
            Fm.ShowDialog(Me)
        Else
            MessageBoxEx.Show(Me, "No existen documentos configurados para imprimir en esta estación de trabajo",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
        Fm.Dispose()
        Sb_Pausar(_Pausa.Play)
    End Sub

    Private Sub Btn_Lista_Doc_Impresos_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Lista_Doc_Impresos.Click
        Sb_Ver_Documentos_Impresos()
    End Sub

    Private Sub Btn_LogError_Impresion_Click(sender As System.Object, e As System.EventArgs) Handles Btn_LogError_Impresion.Click
        Sb_Ver_Documentos_Impresos()
    End Sub

    Private Sub Timer_Segundos_Tick(sender As System.Object, e As System.EventArgs) Handles Timer_Segundos.Tick

        Dim _Hora = numero_(Date.Now.ToShortTimeString, 5)
        Dim _Hoy As Date = DtpFecharevision.Value 'Date.Now
        Dim _Dia = _Hoy.DayOfWeek

        If Me.Visible Then
            If _Hora.Contains("00:00") Then
                DtpFecharevision.Value = FechaDelServidor()
            End If
        End If

        Dim horaProgramada As DateTime = DateTime.Today.Add(New TimeSpan(17, 60, 0))
        ' Calcular el tiempo restante hasta la hora programada
        Dim tiempoRestante As TimeSpan = horaProgramada - DateTime.Now

        Dim _TiempoRestante As String = tiempoRestante.Hours & ":" & tiempoRestante.Minutes & ":" & tiempoRestante.Seconds

        Lbl_Hora_AsisCompra.Text = _TiempoRestante

        Lbl_Segundos_FacAuto.Visible = Switch_FacAuto.Value

        ' EMPIEZAN LOS PROCEDIMIENTOS

#Region "CONSOLIDACION DE STOCK"

        If Switch_Cons_Stock.Value Then

            If (_Dia = DayOfWeek.Monday And _Cons_Lunes) Or
               (_Dia = DayOfWeek.Tuesday And _Cons_Martes) Or
               (_Dia = DayOfWeek.Wednesday And _Cons_Miercoles) Or
               (_Dia = DayOfWeek.Thursday And _Cons_Jueves) Or
               (_Dia = DayOfWeek.Friday And _Cons_Viernes) Or
               (_Dia = DayOfWeek.Saturday And _Cons_Sabado) Or
               (_Dia = DayOfWeek.Sunday And _Cons_Domingo) Then

                If _Hora = Lbl_Hora_Consolid_Stock.Text Then

                    If Not _Cons_Ejecudato Then
                        Sb_Procedimiento_Consolidar_Stock(_Rdb_Cons_Stock_Todos, _Rdb_Cons_Stock_Mov_Hoy)
                        _Cons_Ejecudato = True
                    End If

                Else

                    _Cons_Ejecudato = False

                End If

            End If

        End If

#End Region

#Region "CERRAR DOCUMENTOS DE COMPROMISO"

        If Switch_Cierre_Documentos.Value Then

            If (_Dia = DayOfWeek.Monday And _CierreDoc_Lunes) Or
               (_Dia = DayOfWeek.Tuesday And _CierreDoc_Martes) Or
               (_Dia = DayOfWeek.Wednesday And _CierreDoc_Miercoles) Or
               (_Dia = DayOfWeek.Thursday And _CierreDoc_Jueves) Or
               (_Dia = DayOfWeek.Friday And _CierreDoc_Viernes) Or
               (_Dia = DayOfWeek.Saturday And _CierreDoc_Sabado) Or
               (_Dia = DayOfWeek.Sunday And _CierreDoc_Domingo) Then

                If _Hora = Lbl_Hora_Cierre_Documentos.Text Then

                    If Not _CierreDoc_Ejecudato Then

                        Sb_Pausar(_Pausa.Pausa)

                        Sb_Procedimientos_Cierre_Masivo_Documentos("COV", _Input_DiasCOV, _Chk_COVCerrar)
                        Sb_Procedimientos_Cierre_Masivo_Documentos("NVI", _Input_DiasNVI, _Chk_NVICerrar)
                        Sb_Procedimientos_Cierre_Masivo_Documentos("NVV", _Input_DiasNVV, _Chk_NVVCerrar)
                        Sb_Procedimientos_Cierre_Masivo_Documentos("OCI", _Input_DiasOCI, _Chk_OCICerrar)
                        Sb_Procedimientos_Cierre_Masivo_Documentos("OCC", _Input_DiasOCC, _Chk_OCCCerrar)

                        Sb_Pausar(_Pausa.Play)

                        _CierreDoc_Ejecudato = True

                    End If

                Else

                    _CierreDoc_Ejecudato = False

                End If

            End If

        End If

#End Region

#Region "ARCHIVADOR DE DOCUMENTOS"

        Lbl_Segundos_Archivador.Visible = Switch_Archivador.Value

        If Not _Cl_Archivador.Procesando Then

            If Switch_Archivador.Value Then
                _Segundos_Archivador -= 1
            End If

            If _Segundos_Archivador < 0 Then

                Sb_Actualizar_Fecha()

                _Cl_Archivador.Fecha_Revision = DtpFecharevision.Value
                _Cl_Archivador.Nombre_Equipo = _Nombre_Equipo
                _Cl_Archivador.Sb_Iniciar()

                _Segundos_Archivador = _Input_Tiempo_Archivador / 1000

            End If

        End If

        Lbl_Segundos_Archivador.Text = _Segundos_Archivador

#End Region

#Region "ENVIO DE CORREOS"

        Lbl_Segundos_Correo.Visible = Switch_Correos.Value

        If _Cl_Correos.Procesando Then

            Lbl_Segundos_Correo.Text = "En proceso..."

        Else

            If _Minutos_Correo = 0 Then
                If (Switch_Cola_Impresion.Value And _Segundos_Correo = _Segundos_Impresion) Or
                   (Switch_Picking.Value And _Segundos_Correo = _Segundos_Picking) Then
                    _Segundos_Correo += 3
                End If
            End If

            If Switch_Correos.Value Then
                _Segundos_Correo -= 1
                If _Segundos_Correo < 0 Then
                    _Minutos_Correo -= 1
                    _Segundos_Correo = 59
                End If
            End If

            If _Minutos_Correo = 0 And _Segundos_Correo = 0 Then

                If Not _Cl_Imprimir_Documentos.Procesando And Not _Cl_Imprimir_Picking.Procesando Then

                    Sb_Actualizar_Fecha()

                    'Sb_Pausar(True)

                    _Cl_Correos.Fecha_Revision = DtpFecharevision.Value
                    _Cl_Correos.Nombre_Equipo = _Nombre_Equipo
                    _Cl_Correos.Sb_Procedimiento_Correos()

                    'Sb_Pausar(False)

                    _Minutos_Correo = (_Input_Tiempo_Correo / 1000 / 60) - 1
                    _Segundos_Correo = 59

                Else

                    _Segundos_Correo = 10

                End If

            End If

            Lbl_Segundos_Correo.Text = numero_(_Minutos_Correo, 2) & ":" & numero_(_Segundos_Correo, 2)

        End If

#End Region

#Region "IMPRESION DE DOCUMENTOS"

        Lbl_Segundos_Impresion.Visible = Switch_Cola_Impresion.Value

        If _Cl_Imprimir_Documentos.Procesando Then

            Lbl_Segundos_Impresion.Text = "Imp..."

        Else

            If Switch_Cola_Impresion.Value Then _Segundos_Impresion -= 1

            If _Segundos_Impresion < 0 Then

                Sb_Pausar(True)

                Sb_Actualizar_Fecha()

                _Cl_Imprimir_Documentos.Fecha_Revision = DtpFecharevision.Value
                _Cl_Imprimir_Documentos.Nombre_Equipo = _Nombre_Equipo
                _Cl_Imprimir_Documentos.Sb_Procedimiento_Cola_Impresion()

                _Segundos_Impresion = _Input_Tiempo_Impresion / 1000

                Sb_Pausar(False)

            End If

            Lbl_Segundos_Impresion.Text = _Segundos_Impresion

        End If

#End Region

#Region "IMPRESION DE PICKING"

        Lbl_Segundos_Picking.Visible = Switch_Picking.Value

        If _Cl_Imprimir_Picking.Procesando Then

            Lbl_Segundos_Picking.Text = "Imp..."

        Else

            If Switch_Picking.Value Then _Segundos_Picking -= 1

            If _Segundos_Picking < 0 Then

                Sb_Pausar(True)

                Sb_Actualizar_Fecha()

                _Cl_Imprimir_Picking.Fecha_Revision = DtpFecharevision.Value
                _Cl_Imprimir_Picking.Nombre_Equipo = _Nombre_Equipo
                _Cl_Imprimir_Picking.Sb_Procedimiento_Picking()

                _Segundos_Picking = _Input_Tiempo_Picking / 1000

                Sb_Pausar(False)

            End If

            Lbl_Segundos_Picking.Text = _Segundos_Picking

        End If

#End Region

#Region "PRESTASHOP ORDERS"

        _Segundos_Prestashop_orders -= 1

        If _Ejecutar_PrestaShop_Ordenes Then

            If Not _Cl_Prestashop_Orders.Procesando Then

                If _Segundos_Prestashop_orders < 0 Then

                    Sb_Actualizar_Fecha()

                    _Cl_Prestashop_Orders.Nombre_Equipo = _Nombre_Equipo
                    _Cl_Prestashop_Orders.Fecha_Revision = DtpFecharevision.Value
                    _Cl_Prestashop_Orders.Sb_Iniciar()
                    'Sb_Procedimiento_Prestashop_orders()
                    _Segundos_Prestashop_orders = 2

                End If

            End If

        End If

#End Region

#Region "PRESTASHOP WEB, ACTUALIZACION DE STOCK Y PRECIOS DE PRODUCTOS EN LA WEB"

        Lbl_Segundos_Prestashop.Visible = Switch_Prestashop.Value

        If _Cl_Prestashop_Web.Procesando Then

            Lbl_Segundos_Prestashop.Text = "En proceso..."

        Else

            If Switch_Prestashop.Value Then

                _Segundos_Prestashop -= 1

                If _Segundos_Prestashop < 0 Then
                    _Minutos_Prestashop -= 1
                    _Segundos_Prestashop = 59
                End If

            End If

            If _Minutos_Prestashop = 0 And _Segundos_Prestashop = 0 Then

                ' Consolidar el stock de los productos antes de actualizar
                Sb_Procedimiento_Consolidar_Stock(False, True)

                Sb_Actualizar_Fecha()

                _Cl_Prestashop_Web.Fecha_Revision = DtpFecharevision.Value

                Sb_Pausar(_Pausa.Pausa)

                _Cl_Prestashop_Web.Sb_Procedimiento_Prestashop()
                _Cl_Prestashop_Web.Sb_Procedimiento_Prestashop3()

                Sb_Pausar(_Pausa.Play)

                _Minutos_Prestashop = (_Input_Tiempo_Prestashop / 1000 / 60) - 1
                _Segundos_Prestashop = 59

                Lbl_Prestashop.Text = "Sincronización de Prestashop con los sitios Web."

            End If

            If _Prestashop_Ejecucion_Total Then

                If (_Dia = DayOfWeek.Monday And _Prest_Lunes) Or
                   (_Dia = DayOfWeek.Tuesday And _Prest_Martes) Or
                   (_Dia = DayOfWeek.Wednesday And _Prest_Miercoles) Or
                   (_Dia = DayOfWeek.Thursday And _Prest_Jueves) Or
                   (_Dia = DayOfWeek.Friday And _Prest_Viernes) Or
                   (_Dia = DayOfWeek.Saturday And _Prest_Sabado) Or
                   (_Dia = DayOfWeek.Sunday And _Prest_Domingo) Then

                    If _Hora = _Hora_Prestashop Then

                        If Not _Prestashop_Total_Ejecudato Then

                            Sb_Pausar(True)
                            Sb_Actualizar_Fecha()

                            _Prestashop_Total_Ejecudato = True

                            _Cl_Prestashop_Web.Fecha_Revision = DtpFecharevision.Value
                            _Cl_Prestashop_Web.Sb_Procedimiento_Prestashop2(True)

                            Sb_Pausar(False)

                        End If

                    Else

                        _Prestashop_Total_Ejecudato = False

                    End If

                End If

            End If

            Lbl_Segundos_Prestashop.Text = numero_(_Minutos_Prestashop, 2) & ":" & numero_(_Segundos_Prestashop, 2)

        End If

#End Region

#Region "RUN MONITOR"

        'If _Segundos_RunMonitor < 0 Then

        '    Sb_Actualizar_Fecha()
        '    Sb_Procediminento_Revision_RunMonitor()
        '    _Segundos_RunMonitor = 59

        'End If

#End Region

#Region "LIBRO DTE SII"

        Lbl_Segundos_DTESII.Visible = Switch_LibroDTESII.Value

        If _Cl_LibroDTESII.Procesando Then
            Lbl_Segundos_DTESII.Text = "Procesando..."
        Else

            If Switch_LibroDTESII.Value Then

                _Segundos_LibroDTESII -= 1
                _Segundos_RunMonitor -= 1

                If _Segundos_LibroDTESII < 0 Then
                    _Minutos_LibroDTESII -= 1
                    _Segundos_LibroDTESII = 59
                End If

            End If

            If _Minutos_LibroDTESII = 0 And _Segundos_LibroDTESII = 0 Then

                Sb_Pausar(_Pausa.Pausa)

                Dim Fm As New Frm_Recibir_Correos_DTE
                Fm.ActivacionAutomatica = True
                Fm.ShowDialog(Me)
                Fm.Dispose()

                Sb_Actualizar_Fecha()

                Dim _Fecha As Date = DtpFecharevision.Value
                Dim _Fecha_Anterior As Date = DateAdd(DateInterval.Month, -1, _Fecha)

                Dim _Periodo = _Fecha.Year
                Dim _Mes = _Fecha.Month
                Dim _Libro_Bajado As Boolean
                Dim _Reenviar_Documentos_al_SII = False

                _Contador_Reenvio_Firmas_DTE += 1

                If _Contador_Reenvio_Firmas_DTE = 8 Then
                    _Reenviar_Documentos_al_SII = True
                    _Contador_Reenvio_Firmas_DTE = 0
                End If

                Dim _Clas_Hefesto_Dte_Libro As New Clas_Hefesto_Dte_Libro

                'Dim _RecuperarResumenVentasRegistro As HefRespuesta
                'Dim _RecuperarVentasRegistro As HefRespuesta
                'Dim _RecuperarResumenCompras As HefRespuesta
                Dim _RecuperarComprasRegistro As HefRespuesta
                Dim _RecuperarComprasPendientes As HefRespuesta
                'Dim _RecuperarComprasNoIncluir As HefRespuesta
                'Dim _RecuperarComprasReclamadas As HefRespuesta

                Lbl_LibroDTESII.Text = "Recuperando los registros de compras desde el SII..."
                Application.DoEvents()

                _RecuperarComprasRegistro = _Clas_Hefesto_Dte_Libro.Fx_RecuperarComprasRegistro(_Periodo, _Mes)
                Thread.Sleep(2000)
                Lbl_LibroDTESII.Text = "Es correcto: " & _RecuperarComprasRegistro.EsCorrecto
                Application.DoEvents()
                Thread.Sleep(2000)
                Lbl_LibroDTESII.Text = "Mensaje    : " & _RecuperarComprasRegistro.Mensaje
                Application.DoEvents()

                _RecuperarComprasPendientes = _Clas_Hefesto_Dte_Libro.Fx_RecuperarComprasPendientes(_Periodo, _Mes)
                Thread.Sleep(2000)
                Lbl_LibroDTESII.Text = "Es correcto: " & _RecuperarComprasPendientes.EsCorrecto
                Application.DoEvents()
                Thread.Sleep(2000)
                Lbl_LibroDTESII.Text = "Mensaje    : " & _RecuperarComprasPendientes.Mensaje
                Application.DoEvents()

                If _RecuperarComprasRegistro.EsCorrecto And _RecuperarComprasPendientes.EsCorrecto Then

                    Dim _Fichero1 As String = File.ReadAllText(_RecuperarComprasRegistro.Directorio)
                    Dim _Fichero2 As String = File.ReadAllText(_RecuperarComprasPendientes.Directorio)

                    Dim _Tbl_Registro_Compras As DataTable = Fx_TblFromJson(_Fichero1, "RegistroCompras")
                    Dim _Tbl_Registro_Compras_Pendientes As DataTable = Fx_TblFromJson(_Fichero2, "RegistroComprasPendientes")

                    _Clas_Hefesto_Dte_Libro.Estatus = Lbl_LibroDTESII

                    Thread.Sleep(2000)

                    _Clas_Hefesto_Dte_Libro.Fx_Importar_Archivo_SII_Compras_Desde_Json(_Tbl_Registro_Compras,
                                                                                  _Tbl_Registro_Compras_Pendientes,
                                                                                  _Periodo, _Mes)

                    Lbl_LibroDTESII.Text = "Monitoreo Libro DTE desde SII"
                Else
                    Lbl_LibroDTESII.Text = "Problema al descargar los archivos desde el SII"
                End If

                Sb_Pausar(_Pausa.Play)

                _Minutos_LibroDTESII = (_Input_Tiempo_LibroDTESII / 1000 / 60) - 1
                _Segundos_LibroDTESII = 59

            End If

            Lbl_Segundos_DTESII.Text = numero_(_Minutos_LibroDTESII, 2) & ":" & numero_(_Segundos_LibroDTESII, 2) & " [" & _Contador_Reenvio_Firmas_DTE & "]"

        End If

#End Region

#Region "SOLICITUD DE PRODUCTOS A BODEGA"

        Lbl_Segundos_Sol_Bodega.Visible = Switch_Solicitud_Productos_Bodega.Value

        If _Cl_Solicitud_Productos_Bodega.Procesando Then
            Lbl_Segundos_Sol_Bodega.Text = "..."
        Else

            If Switch_Solicitud_Productos_Bodega.Value Then
                _Segundos_Sol_Bodega -= 1
            End If

            If _Segundos_Sol_Bodega < 0 Then

                Sb_Actualizar_Fecha()
                _Cl_Solicitud_Productos_Bodega.Impresora_Prod_Sol_Bodega = _Impresora_Prod_Sol_Bodega
                _Cl_Solicitud_Productos_Bodega.Sb_Iniciar()
                _Segundos_Sol_Bodega = _Input_Tiempo_Sol_Bodega / 1000

            End If

            Lbl_Segundos_Sol_Bodega.Text = _Segundos_Sol_Bodega

        End If

#End Region

#Region "WORDPRESS PROD"

        Dim _Empresa = ModEmpresa

        If Switch_Wordpress_Prod.Value Then

            _Segundos_Wordpress_Prod -= 1

            If _Segundos_Wordpress_Prod < 0 Then
                _Minutos_Wordpress_Prod -= 1
                _Segundos_Wordpress_Prod = 59
            End If

            If _Minutos_Wordpress_Prod = 0 And _Segundos_Wordpress_Prod = 0 Then

                _Cl_Wordpress = New Cl_Wordpress

                If Not IsNothing(_Cl_Wordpress.Row_Wordpress_Keys) Then

                    Sb_Pausar(_Pausa.Pausa)

                    Dim Productos As JArray = _Cl_Wordpress.ObtenerProductos()

                    If Not IsNothing(Productos) Then

                        Consulta_sql = "Truncate Table " & _Global_BaseBk & "Zw_Wordpress_Productos" & vbCrLf & vbCrLf
                        Dim _Contador = 1

                        For Each item As JObject In Productos

                            Dim id As String = item.GetValue("id").ToString()
                            Dim sku As String = item.GetValue("sku").ToString()
                            Dim description As String = item.GetValue("name").ToString()
                            Dim stock_quantity As String = item.GetValue("stock_quantity").ToString()
                            Dim price As String = item.GetValue("price").ToString()

                            description = Mid(description, 1, 50)

                            Consulta_sql += "Insert Into " & _Global_BaseBk & "Zw_Wordpress_Productos (Id_Producto,Sku,Descripcion,Stock,Precio,Actualizacion,Log_Producto,Empresa) Values "

                            If _Cl_Wordpress.ConsultarProducto(sku) Then
                                Consulta_sql += "('" & id & "','" & sku & "','" & description & "','" & stock_quantity & "','" & price & "',getdate(),'','" & _Empresa & "')" & vbCrLf
                            Else
                                Consulta_sql += "('" & id & "','" & sku & "','" & description & "','" & stock_quantity & "','" & price & "',getdate()," &
                                            "'EL PRODUCTO NO EXISTE DENTRO DEL CATALOGO DE RANDOM','" & _Empresa & "')" & vbCrLf
                            End If

                            If sku = "AGT-19-0005" Or sku.Contains("AGT") Then
                                Dim _Aca = 0
                            End If

                            Application.DoEvents()

                            Lbl_Wordpress_productos.Text = "Revisando " & FormatNumber(_Contador, 0) & " de " & FormatNumber(Productos.Count, 0) & " productos..."
                            _Contador += 1

                        Next

                        _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

                    End If

                End If

                Sb_Pausar(_Pausa.Play)

                _Minutos_Wordpress_Prod = (_Input_Tiempo_Wordpress_Productos / 1000 / 60) - 1
                _Segundos_Wordpress_Prod = 59

            End If
            Lbl_Wordpress_productos.Text = "Wordpress productos"
            Lbl_Segundos_Wordpress_Prod.Text = numero_(_Minutos_Wordpress_Prod, 2) & ":" & numero_(_Segundos_Wordpress_Prod, 2)

        End If

#End Region

#Region "WORDPRESS STOCK/PRECIOS"

        If Switch_Wordpress_Stock.Value Then

            _Segundos_Wordpress_Stock -= 1

            If _Segundos_Wordpress_Stock < 0 Then
                _Minutos_Wordpress_Stock -= 1
                _Segundos_Wordpress_Stock = 59
            End If

            If _Minutos_Wordpress_Stock = 0 And _Segundos_Wordpress_Stock = 0 Then

                If Not IsNothing(_Cl_Wordpress.Row_Wordpress_Keys) Then

                    Sb_Pausar(_Pausa.Pausa)

                    Dim _PrecioNeto As Boolean = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Wordpress", "PrecioNeto", "1>0")

                    Dim _Campo_Precio As String

                    If _PrecioNeto Then
                        _Campo_Precio = "PrecioNeto"
                    Else
                        _Campo_Precio = "PrecioBruto"
                    End If

                    'en la tabla Zw_TablaDeCaracterizaciones Se deben grabar las bodegas para los filtros en el campo CodigoTabla
                    'Ejemplo: Tabla = 'WORDPRESS_BOD', Campo = '01SUCBOD',NombreTabla = 'NOMBRE BODEGA'

                    Consulta_sql = "Select CodigoTabla From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Where Tabla = 'WORDPRESS_BOD'"
                    Dim _Tbl_Bodegas As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                    Dim _Filtros_Bod As String = "And EMPRESA = '" & _Empresa & "'" & vbCrLf

                    If CBool(_Tbl_Bodegas.Rows.Count) Then
                        _Filtros_Bod = Generar_Filtro_IN(_Tbl_Bodegas, "", "CodigoTabla", False, False, "'")
                        _Filtros_Bod = "And Ms.EMPRESA+Ms.KOSU+Ms.KOBO In " & _Filtros_Bod & vbCrLf
                    End If

                    Consulta_sql = "Select Ms.KOPR,Case When Round(Sum(STFI1),0) >=0 Then Round(Sum(STFI1),0) Else 0 End As STFI1,
                    Isnull(Round(Tp.PP01UD/1.19,0),0) As PrecioNeto,
                    Round(Tp.PP01UD,0) As PrecioBruto
                    Into #Paso From MAEST Ms
                    Left Join TABPRE Tp On KOLT = '" & _Cl_Wordpress.Cod_Lista & "' And Ms.KOPR = Tp.KOPR
                    Where Ms.KOPR In (Select Sku From " & _Global_BaseBk & "Zw_Wordpress_Productos)" & vbCrLf &
                    _Filtros_Bod & vbCrLf &
                    "Group By Ms.KOPR,Tp.PP01UD" &
                    vbCrLf &
                    "Insert " & _Global_BaseBk & "Zw_Demonio_Wordpress (Id_Producto,Sku,Stock,Precio,Descripcion,Fecha,Revisado,Error,Log_Error,Fecha_Hora,Empresa)
                    
                    Select Id_Producto,Sku,STFI1,Round(T1." & _Campo_Precio & ",0),Descripcion,Getdate(),0,0,'',Getdate(),Empresa 
                    From #Paso T1 
                    Inner Join " & _Global_BaseBk & "[Zw_Wordpress_Productos] T2 ON T1.KOPR=T2.Sku 
                    Where (T1.STFI1<>T2.Stock Or Round(T1." & _Campo_Precio & ",0) <> Round(T2.Precio,0))
                    Drop Table #Paso"

                    _Sql.Ej_consulta_IDU(Consulta_sql)

                    Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Demonio_Wordpress Where Revisado = 0"
                    Dim _TblStockActualizado As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                    Dim _Contador = 1

                    For Each _Fila As DataRow In _TblStockActualizado.Rows

                        Dim _Id As Integer = _Fila.Item("Id")
                        Dim _Id_Producto As Integer = _Fila.Item("Id_Producto")
                        Dim _Sku As String = _Fila.Item("Sku")
                        Dim _Stock As String = De_Num_a_Tx_01(_Fila.Item("Stock"), False, 5)
                        Dim _Precio As String = De_Num_a_Tx_01(_Fila.Item("Precio"), False, 5)
                        Dim _Stock_Producto As String
                        Dim _Precio_Producto As String
                        Dim _Log_Error = String.Empty

                        _Stock_Producto = _Stock
                        _Precio_Producto = _Precio

                        If _Fila.Item("Stock") < 0 Then
                            _Stock_Producto = "0"
                            _Log_Error = "Stock negativo " & _Stock
                            _Stock = "0"
                        End If

                        Dim _Respuesta As String = _Cl_Wordpress.ActualizarStock(_Id_Producto, _Stock_Producto, _Precio_Producto)

                        If _Respuesta = "True" Then
                            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Demonio_Wordpress" & vbCrLf &
                                           "Set Revisado = 1,Error = 0,Log_Error = '" & _Log_Error & "',Fecha_Hora=Getdate()" & vbCrLf &
                                           "Where Id='" & _Id & "'" & vbCrLf &
                                           "Update " & _Global_BaseBk & "Zw_Wordpress_Productos" & vbCrLf &
                                           "Set Stock='" & _Stock & "',Precio='" & _Precio & "',Actualizacion=Getdate()" & vbCrLf &
                                           "Where Id_Producto=" & _Id_Producto

                        Else
                            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Demonio_Wordpress " &
                                           "SET Revisado=1,Error=1,Log_Error = '" & _Respuesta & "',Fecha_Hora=Getdate()" & vbCrLf &
                                           "Where Id=" & _Id
                        End If

                        _Sql.Fx_Ejecutar_Consulta(Consulta_sql)

                        Application.DoEvents()

                        Lbl_Wordpress_Stock_Precios.Text = "Revisando " & FormatNumber(_Contador, 0) & " de " & FormatNumber(_TblStockActualizado.Rows.Count, 0) & " productos..."
                        _Contador += 1

                    Next

                End If

                Sb_Pausar(_Pausa.Play)

                _Minutos_Wordpress_Stock = (_Input_Tiempo_Wordpress_Stock / 1000 / 60) - 1
                _Segundos_Wordpress_Stock = 59

            End If

            Lbl_Wordpress_Stock_Precios.Text = "Wordpress Stock"
            Lbl_Segundos_Wordpress_Stock.Text = numero_(_Minutos_Wordpress_Stock, 2) & ":" & numero_(_Segundos_Wordpress_Stock, 2)
        End If

#End Region

#Region "POSWII Solo Ferreteria Ohiggins"

        Lbl_Segundos_Poswii.Visible = Switch_Poswii.Value

        If Switch_Poswii.Value Then _Segundos_Poswii -= 1

        If _Segundos_Poswii < 0 Then
            Sb_Actualizar_Fecha()
            Sb_Procedimiento_Poswii()
            _Segundos_Poswii = _Input_Tiempo_Poswii / 1000
        End If

        Lbl_Segundos_Poswii.Text = _Segundos_Poswii

#End Region

#Region "LISTAS DE PRECIO PROGRAMADAS"

        If Switch_Listas_Programadas.Value Then

            _Segundos_Listas_Programacion -= 1

            If _Segundos_Listas_Programacion < 0 Then '_Hora.Contains(":00") Then

                Sb_Pausar(_Pausa.Pausa)

                _Cl_Listas_Programadas.FechaProgramacion = DtpFecharevision.Value
                _Cl_Listas_Programadas.Sb_Grabar_Listas_Programadas()

                Sb_Pausar(_Pausa.Play)

                _Segundos_Listas_Programacion = 60

            End If

            Lbl_Segundos_Listas_Programadas.Text = _Segundos_Listas_Programacion

        End If

#End Region

#Region "FACTURAR AUTOMATICAMENTE"

        If Switch_FacAuto.Value Then

            _Segundos_FacAuto -= 1

            If _Segundos_FacAuto < 0 Then

                If (_Dia = DayOfWeek.Monday And _Cl_FacAuto_NVV.Fac_Lunes) Or
                   (_Dia = DayOfWeek.Tuesday And _Cl_FacAuto_NVV.Fac_Martes) Or
                   (_Dia = DayOfWeek.Wednesday And _Cl_FacAuto_NVV.Fac_Miercoles) Or
                   (_Dia = DayOfWeek.Thursday And _Cl_FacAuto_NVV.Fac_Jueves) Or
                   (_Dia = DayOfWeek.Friday And _Cl_FacAuto_NVV.Fac_Viernes) Or
                   (_Dia = DayOfWeek.Saturday And _Cl_FacAuto_NVV.Fac_Sabado) Or
                   (_Dia = DayOfWeek.Sunday And _Cl_FacAuto_NVV.Fac_Domingo) Then

                    Sb_Pausar(_Pausa.Pausa)

                    _Cl_FacAuto_NVV.Fecha_Revision = DtpFecharevision.Value
                    _Cl_FacAuto_NVV.Nombre_Equipo = _Nombre_Equipo
                    _Cl_FacAuto_NVV.Sb_Traer_NVV_A_Facturar()
                    _Cl_FacAuto_NVV.Sb_Facturar_Automaticamente_NVV(Me, Lbl_FacAuto)

                    Lbl_FacAuto.Text = "Generar facturas automáticamente"

                    Sb_Pausar(_Pausa.Play)

                End If

                _Segundos_FacAuto = 60

            End If

            Lbl_Segundos_FacAuto.Text = _Segundos_FacAuto

        Else

            _Segundos_FacAuto = 60

        End If

#End Region

#Region "ASISTENTE DE COMPRAS"

        If Switch_AsisCompras.Value Then

            If (_Dia = DayOfWeek.Monday And _Cl_Asistente_Compras.Chk_AsisComEjecLunes) Or
               (_Dia = DayOfWeek.Tuesday And _Cl_Asistente_Compras.Chk_AsisComEjecMartes) Or
               (_Dia = DayOfWeek.Wednesday And _Cl_Asistente_Compras.Chk_AsisComEjecMiercoles) Or
               (_Dia = DayOfWeek.Thursday And _Cl_Asistente_Compras.Chk_AsisComEjecJueves) Or
               (_Dia = DayOfWeek.Friday And _Cl_Asistente_Compras.Chk_AsisComEjecViernes) Or
               (_Dia = DayOfWeek.Saturday And _Cl_Asistente_Compras.Chk_AsisComEjecSabado) Or
               (_Dia = DayOfWeek.Sunday And _Cl_Asistente_Compras.Chk_AsisComEjecDomingo) Then

                If _Hora = Lbl_Hora_AsisCompra.Text Then

                    Sb_Pausar(_Pausa.Pausa)

                    Dim _TblModalidades As DataTable
                    Dim _FiltroModalidades As String

                    If _Dia = DayOfWeek.Monday Then
                        _FiltroModalidades = _Cl_Asistente_Compras.Txt_AsComModLunes
                        If _Cl_Asistente_Compras.Ejecutado_Lunes Then _FiltroModalidades = "('XXX')"
                    End If
                    If _Dia = DayOfWeek.Tuesday Then
                        _FiltroModalidades = _Cl_Asistente_Compras.Txt_AsComModMartes
                        If _Cl_Asistente_Compras.Ejecutado_Martes Then _FiltroModalidades = "('XXX')"
                    End If
                    If _Dia = DayOfWeek.Wednesday Then
                        _FiltroModalidades = _Cl_Asistente_Compras.Txt_AsComModMiercoles
                        If _Cl_Asistente_Compras.Ejecutado_Miercoles Then _FiltroModalidades = "('XXX')"
                    End If
                    If _Dia = DayOfWeek.Thursday Then
                        _FiltroModalidades = _Cl_Asistente_Compras.Txt_AsComModJueves
                        If _Cl_Asistente_Compras.Ejecutado_Jueves Then _FiltroModalidades = "('XXX')"
                    End If
                    If _Dia = DayOfWeek.Friday Then
                        _FiltroModalidades = _Cl_Asistente_Compras.Txt_AsComModViernes
                        If _Cl_Asistente_Compras.Ejecutado_Viernes Then _FiltroModalidades = "('XXX')"
                    End If
                    If _Dia = DayOfWeek.Saturday Then
                        _FiltroModalidades = _Cl_Asistente_Compras.Txt_AsComModSabado
                        If _Cl_Asistente_Compras.Ejecutado_Sabado Then _FiltroModalidades = "('XXX')"
                    End If
                    If _Dia = DayOfWeek.Sunday Then
                        _FiltroModalidades = _Cl_Asistente_Compras.Txt_AsComModDomingo
                        If _Cl_Asistente_Compras.Ejecutado_Domingo Then _FiltroModalidades = "('XXX')"
                    End If

                    Consulta_sql = "Select MODALIDAD From CONFIEST Where MODALIDAD In " & _FiltroModalidades
                    _TblModalidades = _Sql.Fx_Get_Tablas(Consulta_sql)

                    Dim _ModalidadOld As String = Modalidad
                    Dim _Mod As New Clas_Modalidades

                    Me.WindowState = FormWindowState.Normal

                    For Each _Fl As DataRow In _TblModalidades.Rows

                        Modalidad = _Fl.Item("MODALIDAD")

                        _Global_Row_Configuracion_General = _Mod.Fx_Sql_Trae_Modalidad(Clas_Modalidades.Enum_Modalidad.General, "")
                        _Global_Row_Configuracion_Estacion = _Mod.Fx_Sql_Trae_Modalidad(Clas_Modalidades.Enum_Modalidad.Estacion, Modalidad)
                        _Mod.Sb_Actualizar_Variables_Modalidad(Modalidad)
                        _Mod.Sb_Actualiza_Formatos_X_Modalidad()

                        _Cl_Asistente_Compras.Sb_Ejecutar(Me, Modalidad, False, True, False, False, True)
                        _Cl_Asistente_Compras.Sb_Ejecutar(Me, Modalidad, True, False, False, True, False)
                        _Cl_Asistente_Compras.Sb_Ejecutar(Me, Modalidad, True, False, True, False, False)

                    Next

                    Me.WindowState = FormWindowState.Minimized

                    Modalidad = _ModalidadOld

                    _Mod = New Clas_Modalidades
                    _Global_Row_Configuracion_General = _Mod.Fx_Sql_Trae_Modalidad(Clas_Modalidades.Enum_Modalidad.General, "")
                    _Global_Row_Configuracion_Estacion = _Mod.Fx_Sql_Trae_Modalidad(Clas_Modalidades.Enum_Modalidad.Estacion, Modalidad)
                    _Mod.Sb_Actualizar_Variables_Modalidad(Modalidad)
                    _Mod.Sb_Actualiza_Formatos_X_Modalidad()

                    _Cl_Asistente_Compras.Ejecutado_Lunes = (_Dia = DayOfWeek.Monday)
                    _Cl_Asistente_Compras.Ejecutado_Martes = (_Dia = DayOfWeek.Tuesday)
                    _Cl_Asistente_Compras.Ejecutado_Miercoles = (_Dia = DayOfWeek.Wednesday)
                    _Cl_Asistente_Compras.Ejecutado_Jueves = (_Dia = DayOfWeek.Thursday)
                    _Cl_Asistente_Compras.Ejecutado_Viernes = (_Dia = DayOfWeek.Friday)
                    _Cl_Asistente_Compras.Ejecutado_Sabado = (_Dia = DayOfWeek.Saturday)
                    _Cl_Asistente_Compras.Ejecutado_Domingo = (_Dia = DayOfWeek.Sunday)

                    Sb_Pausar(_Pausa.Play)

                End If

            End If

        End If

#End Region

#Region "INFORME DE DOCUMENTOS PENDIENTES"

        If Switch_EnvDocSinRecep.Value Then

            If (_Dia = DayOfWeek.Monday And _Cl_Enviar_Doc_SinRecepcion.Chk_EnvDocSinRecep_EjecLunes) Or
               (_Dia = DayOfWeek.Tuesday And _Cl_Enviar_Doc_SinRecepcion.Chk_EnvDocSinRecep_EjecMartes) Or
               (_Dia = DayOfWeek.Wednesday And _Cl_Enviar_Doc_SinRecepcion.Chk_EnvDocSinRecep_EjecMiercoles) Or
               (_Dia = DayOfWeek.Thursday And _Cl_Enviar_Doc_SinRecepcion.Chk_EnvDocSinRecep_EjecJueves) Or
               (_Dia = DayOfWeek.Friday And _Cl_Enviar_Doc_SinRecepcion.Chk_EnvDocSinRecep_EjecViernes) Or
               (_Dia = DayOfWeek.Saturday And _Cl_Enviar_Doc_SinRecepcion.Chk_EnvDocSinRecep_EjecSabado) Or
               (_Dia = DayOfWeek.Sunday And _Cl_Enviar_Doc_SinRecepcion.Chk_EnvDocSinRecep_EjecDomingo) Then

                If _Hora = Lbl_Hora_EnvDocSinRecep.Text Then

                    Sb_Pausar(_Pausa.Pausa)

                    Dim _Ejecutar = True

                    If _Dia = DayOfWeek.Monday Then If _Cl_Asistente_Compras.Ejecutado_Lunes Then _Ejecutar = False
                    If _Dia = DayOfWeek.Tuesday Then If _Cl_Asistente_Compras.Ejecutado_Martes Then _Ejecutar = False
                    If _Dia = DayOfWeek.Wednesday Then If _Cl_Asistente_Compras.Ejecutado_Miercoles Then _Ejecutar = False
                    If _Dia = DayOfWeek.Thursday Then If _Cl_Asistente_Compras.Ejecutado_Jueves Then _Ejecutar = False
                    If _Dia = DayOfWeek.Friday Then If _Cl_Asistente_Compras.Ejecutado_Viernes Then _Ejecutar = False
                    If _Dia = DayOfWeek.Saturday Then If _Cl_Asistente_Compras.Ejecutado_Sabado Then _Ejecutar = False
                    If _Dia = DayOfWeek.Sunday Then If _Cl_Asistente_Compras.Ejecutado_Domingo Then _Ejecutar = False

                    If _Ejecutar Then

                        _Cl_Enviar_Doc_SinRecepcion.Sb_Procesar_Informe(DtpFecharevision.Value)

                        If _Cl_Enviar_Doc_SinRecepcion.Crear_Html.EsCorrecto Then

                            Dim _Para = _Cl_Enviar_Doc_SinRecepcion.Para
                            Dim _Id_Correo = _Cl_Enviar_Doc_SinRecepcion.Id_Correo
                            Dim _RutaArchivo = _Cl_Enviar_Doc_SinRecepcion.Crear_Html.RutaArchivo
                            _Cl_Enviar_Doc_SinRecepcion.Fx_EnviarNotificacionCorreoAlDiablito(_Para, "", _Id_Correo, _RutaArchivo)

                            _Cl_Asistente_Compras.Ejecutado_Lunes = (_Dia = DayOfWeek.Monday)
                            _Cl_Asistente_Compras.Ejecutado_Martes = (_Dia = DayOfWeek.Tuesday)
                            _Cl_Asistente_Compras.Ejecutado_Miercoles = (_Dia = DayOfWeek.Wednesday)
                            _Cl_Asistente_Compras.Ejecutado_Jueves = (_Dia = DayOfWeek.Thursday)
                            _Cl_Asistente_Compras.Ejecutado_Viernes = (_Dia = DayOfWeek.Friday)
                            _Cl_Asistente_Compras.Ejecutado_Sabado = (_Dia = DayOfWeek.Saturday)
                            _Cl_Asistente_Compras.Ejecutado_Domingo = (_Dia = DayOfWeek.Sunday)

                        End If

                    End If

                    Sb_Pausar(_Pausa.Play)

                End If

            End If

        End If

#End Region

#Region "MINIMIZAR"

        Application.DoEvents()

        _Segundos_Minimiza_Automatico -= 1

        If _Segundos_Minimiza_Automatico < 0 Then
            _Segundos_Minimiza_Automatico = 60 * 5
            Me.WindowState = FormWindowState.Minimized
        End If

#End Region

    End Sub

    Sub Sb_Actualizar_Fecha()

        Dim _Fecha_Computador As Date = FormatDateTime(Now.Date, DateFormat.ShortDate)
        Dim _Fecha_Dtp As Date = FormatDateTime(DtpFecharevision.Value, DateFormat.ShortDate)

        If Not Me.Visible Then

            If _Fecha_Computador <> _Fecha_Dtp Then

                DtpFecharevision.Value = FormatDateTime(FechaDelServidor(), DateFormat.ShortDate)

            End If

        End If

    End Sub

    Sub Sb_Procediminento_Revision_RunMonitor()

        Dim _RunMonitor_Corriendo As Boolean

        For Each prog As Process In Process.GetProcesses
            If prog.ProcessName = "cmd" Then
                _RunMonitor_Corriendo = True
            End If
        Next

        If Not _RunMonitor_Corriendo Then

            Dim _Clas_Hefesto_Dte_Libro As New Clas_Hefesto_Dte_Libro
            _Clas_Hefesto_Dte_Libro.Fx_Ejecutar_runMonitor_BAT(_Formulario)

            'Limpiamos basura DTE
            Consulta_sql = "Delete FMAEPETD Where IDDTE Not In (Select IDDTE From FMAEDTE)
                            Delete FMAEPETE Where IDPET NOT IN (SELECT IDPET FROM FMAEPETD)
                            Delete FMAESOBE WHERE IDPET NOT IN (SELECT IDPET FROM FMAEPETE)
                            Delete FMAERESE WHERE IDSOBE NOT IN (SELECT IDSOBE FROM FMAESOBE)"
            _Sql.Ej_consulta_IDU(Consulta_sql)

        End If

    End Sub

    Sub Sb_Procedimiento_Correos()

        Sb_Pausar(_Pausa.Pausa)

        Dim _Consulta_sql = String.Empty
        _Procesando_Correos = True

        Dim _Fecha = Format(DtpFecharevision.Value, "yyyyMMdd")
        Dim _Tbl_Correos As DataTable

        Dim Dia_1 As String = numero_(DtpFecharevision.Value.Day, 2)
        Dim Mes_1 As String = numero_(DtpFecharevision.Value.Month, 2)
        Dim Ano_1 As String = DtpFecharevision.Value.Year

        Dim _Filtro_Fecha =
                      "FEEMDO BETWEEN CONVERT(DATETIME, '" & Ano_1 & "-" & Mes_1 & "-" & Dia_1 & " 00:00:00', 102)" & vbCrLf &
                      "AND CONVERT(DATETIME, '" & Ano_1 & "-" & Mes_1 & "-" & Dia_1 & " 23:59:59', 102)"

        _Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Aviso_Correo" & vbCrLf &
                        "Where Fecha < '" & _Fecha &
                        "' And NombreEquipo In ('" & _Nombre_Equipo & "','') And Enviado = 1" &
                        vbCrLf &
                        vbCrLf &
                        "Select * From " & _Global_BaseBk & "Zw_Demonio_Cof_Estacion" & vbCrLf &
                        "Where NombreEquipo = '" & _Nombre_Equipo & "' And Traer_Doc_Auto_Correo = 1"

        Dim _Tbl_Zw_Demonio_Cof_Estacion As DataTable = _Sql.Fx_Get_Tablas(_Consulta_sql)

        Dim _SqlQuery_Correo = String.Empty

        Dim _Contador = 0

        For Each _Fila As DataRow In _Tbl_Zw_Demonio_Cof_Estacion.Rows

            Dim _Tido As String = _Fila.Item("TipoDoc")
            Dim _NombreFormato As String = _Fila.Item("NombreFormato")
            Dim _IdPadre As String = _Fila.Item("Id")
            Dim _Condicion_Func = String.Empty

            Dim _Imprimir_Picking = _Fila.Item("Imprimir_Picking")

            _Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Demonio_Filtros_X_Estacion" & vbCrLf &
                            "Where NombreEquipo = '" & _Nombre_Equipo & "' And Nombre_Correo <> '' And (Correo_Para <> '' Or Para_Maeenmail = 1)"
            Dim _TblFiltroFunc As DataTable = _Sql.Fx_Get_Tablas(_Consulta_sql)

            If CBool(_TblFiltroFunc.Rows.Count) Then

                For Each _Fila_Correo As DataRow In _TblFiltroFunc.Rows

                    Dim _TipoDoc = _Fila_Correo.Item("TipoDoc")
                    Dim _Nombre_Correo = _Fila_Correo.Item("Nombre_Correo")
                    Dim _NombreFormato_Correo = _Fila_Correo.Item("NombreFormato_Correo")
                    Dim _Correo_Para = _Fila_Correo.Item("Correo_Para")
                    Dim _Kofudo = _Fila_Correo.Item("Codigo")
                    Dim _Para_Maeenmail = _Fila_Correo.Item("Para_Maeenmail")

                    Dim _Nudonodefi As String = "0"

                    Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Correos Where Nombre_Correo = '" & _Nombre_Correo & "'"
                    Dim _Row_Correo As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                    _Contador += 1
                    Lbl_Correo.Text = "Revisando Conf. para envio " & _Contador & " (" & _TblFiltroFunc.Rows.Count & ")..."
                    System.Windows.Forms.Application.DoEvents()

                    If Not IsNothing(_Row_Correo) Then

                        Dim _Asunto = _Row_Correo.Item("Asunto")
                        Dim _CuerpoMensaje = _Row_Correo.Item("CuerpoMensaje")

                        If Not String.IsNullOrEmpty(_Correo_Para) Or _Para_Maeenmail Then

                            Dim _Tbl_Destinatarios As DataTable
                            Dim _Para As String

                            If Not String.IsNullOrEmpty(_Correo_Para) Then

                                Consulta_sql = "Select KOFU,NOKOFU,Rtrim(Ltrim(EMAIL)) As EMAIL From TABFU Where KOFU In " & _Correo_Para
                                _Tbl_Destinatarios = _Sql.Fx_Get_Tablas(Consulta_sql)
                                _Para = Generar_Filtro_IN_Email(_Tbl_Destinatarios, "EMAIL")

                            End If

                            _SqlQuery_Correo += "Insert Into " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Aviso_Correo" & Space(1) &
                                         "(NombreEquipo,Nombre_Correo,CodFuncionario,Asunto,Para,Cc,Idmaeedo," &
                                         "Tido,Nudo,NombreFormato,Enviar,Intentos,Enviado,Adjuntar_Documento,Mensaje,Fecha,Para_Maeenmail) " & vbCrLf &
                                         "Select '" & _Nombre_Equipo & "','" & _Nombre_Correo & "','" & _Kofudo & "','" & _Asunto & "','" & _Para &
                                         "','',IDMAEEDO,TIDO,NUDO,'" & _NombreFormato_Correo & "',1,0,0,1,'" & _CuerpoMensaje & "',Getdate()," & Convert.ToInt32(_Para_Maeenmail) & vbCrLf &
                                         "From MAEEDO Where TIDO = '" & _Tido & "' And " & _Filtro_Fecha & " And NUDONODEFI = 0" & vbCrLf &
                                         "And IDMAEEDO Not In (Select Idmaeedo From " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Aviso_Correo" & Space(1) &
                                         "Where NombreEquipo In ('" & _Nombre_Equipo & "'))" & Space(1) &
                                         "And KOFUDO = '" & _Kofudo & "'" & vbCrLf &
                                         vbCrLf & "-------------------------------------------------" & vbCrLf

                        End If

                    End If

                Next

            End If

        Next


        If Not String.IsNullOrEmpty(_SqlQuery_Correo) Then
            Lbl_Correo.Text = "Insertando datos..."
            System.Windows.Forms.Application.DoEvents()
            _Sql.Ej_consulta_IDU(_SqlQuery_Correo, False)
        End If

        ' **********************************************************************
        ' ACA SE CREAN LAS FILAS PARA LOS ENVIOS DE CORREOS DE FORMA AUTOMATICA SEGUN LA TABLA DE MAEENMAIL

        ' MAEENEMAIL Códigos de funcionamento

        '001 Envío de correo con PDF/XML de documentos tributarios electrónicos
        '004 Informe de facturas impagas con mas de N días a fecha de emisión
        'CAM Campañas promocionales
        'ODS Envío de notificaciones por ordenes de servicio

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Aviso_Correo" & vbCrLf &
                       "Where Fecha < '" & _Fecha & "' And NombreEquipo = '" & _Nombre_Equipo & "' And Enviado = 1" &
                        vbCrLf &
                        vbCrLf &
                       "Select * From " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Aviso_Correo" & vbCrLf &
                       "Where Enviar = 1 And Enviado = 0 And NombreEquipo In ('','" & _Nombre_Equipo & "') And Para = '' And Para_Maeenmail = 1"
        _Tbl_Correos = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim _SqlQuery = String.Empty

        For Each _Fila As DataRow In _Tbl_Correos.Rows

            Dim _Id = _Fila.Item("Id")
            Dim _IdMaeedo = _Fila.Item("Idmaeedo")
            Dim _Para_Maeenmail = _Fila.Item("Para_Maeenmail")

            Consulta_sql = "Select TIDO,NUDO,ENDO,SUENDO From MAEEDO Where IDMAEEDO = " & _IdMaeedo
            Dim _Row_Maeedo As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim _Koen = _Row_Maeedo.Item("ENDO")
            Dim _Suen = _Row_Maeedo.Item("SUENDO")

            Consulta_sql = "Select Distinct Rtrim(Ltrim(MAILTO)) As MAILTO,Rtrim(Ltrim(MAILCC)) As MAILCC From MAEENMAIL Where KOEN = '" & _Koen & "' And KOMAIL = '001'"

            Dim _Tbl_Maeenmail As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            System.Windows.Forms.Application.DoEvents()

            If Convert.ToBoolean(_Tbl_Maeenmail.Rows.Count) Then

                For Each _Fila_Mail As DataRow In _Tbl_Maeenmail.Rows

                    Dim _Para As String = Trim(_Fila_Mail.Item("MAILTO"))
                    Dim _Cc As String = Trim(_Fila_Mail.Item("MAILCC"))

                    _Para = _Para.Trim()
                    _Cc = _Cc.Trim()

                    _SqlQuery += "Insert Into " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Aviso_Correo (NombreEquipo,Nombre_Correo,CodFuncionario,Asunto," &
                                 "Para,Cc,Idmaeedo,Tido,Nudo,NombreFormato,Enviar,Intentos,Enviado,Adjuntar_Documento,Mensaje,Fecha,Informacion,Para_Maeenmail)" &
                                 vbCrLf &
                                 "Select '" & _Nombre_Equipo & "',Nombre_Correo,CodFuncionario,Asunto,'" & _Para & "','" & _Cc & "',Idmaeedo,Tido,Nudo,NombreFormato,Enviar," &
                                 "Intentos,Enviado,Adjuntar_Documento,Mensaje,Fecha,Informacion,Para_Maeenmail" & vbCrLf &
                                 "From " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Aviso_Correo" & vbCrLf &
                                 "Where Id = " & _Id & vbCrLf & vbCrLf

                Next

            Else

                Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Log_Gestiones",
                                                    "Archirst = 'MAEEDO' And Idrst = " & _IdMaeedo & " And" & Space(1) &
                                                    "Accion = 'Correo no enviado. Motivo: La entidad no tiene correos asociados en tabla MAEENMAIL' And" & Space(1) &
                                                    "Fecha_Hora >= '" & Format(DtpFecharevision.Value, "yyyyMMdd") & "'")
                If _Reg = 0 Then
                    Fx_Add_Log_Gestion(FUNCIONARIO, Modalidad, "MAEEDO", _IdMaeedo, "Diablito",
                                   "Correo no enviado. Motivo: La entidad no tiene correos asociados en tabla MAEENMAIL", "", "", _Koen, _Suen, False, "")
                End If

            End If

        Next

        If Not String.IsNullOrEmpty(_SqlQuery) Then
            _Sql.Ej_consulta_IDU(_SqlQuery)
        End If

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Aviso_Correo Where Para = '' And NombreEquipo In ('','" & _Nombre_Equipo & "') And Para_Maeenmail = 1"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Aviso_Correo" & vbCrLf &
                       "Where Enviar = 1 And Enviado = 0 And NombreEquipo In ('','" & _Nombre_Equipo & "')"
        _Tbl_Correos = _Sql.Fx_Get_Tablas(Consulta_sql)


        Lbl_Correo.Text = "Creando correos para envio..."
        System.Windows.Forms.Application.DoEvents()

        Dim _Conteo_envio = 0
        Dim _Conteo_Error = 0

        If (_Tbl_Correos.Rows.Count) Then

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Aviso_Correo Set Enviar = 0 
                            Where Id In " & Generar_Filtro_IN(_Tbl_Correos, "", "Id", False, False, "")
            _Sql.Ej_consulta_IDU(Consulta_sql)

            For Each _Fila As DataRow In _Tbl_Correos.Rows

                Dim _Id = _Fila.Item("Id")
                Dim _NombreEquipo = _Fila.Item("NombreEquipo")
                Dim _Nombre_Correo = _Fila.Item("Nombre_Correo")
                Dim _Asunto = _Fila.Item("Asunto")
                Dim _Para = Trim(_Fila.Item("Para"))
                Dim _Cc = Trim(_Fila.Item("Cc"))
                Dim _IdMaeedo = _Fila.Item("Idmaeedo")
                Dim _Tido = _Fila.Item("Tido")
                Dim _Nudo = _Fila.Item("Nudo")
                Dim _NombreFormato = _Fila.Item("NombreFormato")
                Dim _Enviar = _Fila.Item("Enviar")
                Dim _Intentos = _Fila.Item("Intentos")
                Dim _Enviado = _Fila.Item("Enviado")
                Dim _Adjuntar_Documento = _Fila.Item("Adjuntar_Documento")
                Dim _Archivos_Adjuntos(0) As String
                Dim _Para_Maeenmail = _Fila.Item("Para_Maeenmail")

                'Dim _Subtido As String = _Sql.Fx_Trae_Dato("MAEEDO", "SUBTIDO", "IDMAEEDO = " & _IdMaeedo)

                Dim _Existe_File

                Consulta_sql = "Select TIDO,NUDO,KOEN,SUEN,NOKOEN 
                                From MAEEDO Inner Join MAEEN On KOEN = ENDO And SUEN = SUENDO 
                                Where IDMAEEDO = " & _IdMaeedo
                Dim _Row_Documento As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                Dim _Koen, _Suen As String

                If Not IsNothing(_Row_Documento) Then

                    _Koen = _Row_Documento.Item("KOEN")
                    _Suen = _Row_Documento.Item("SUEN")

                End If

                If _Adjuntar_Documento Then

                    Dim _Pdf_Adjunto As New Clas_PDF_Crear_Documento(_IdMaeedo,
                                                                     _Tido,
                                                                     _NombreFormato,
                                                                     _Tido & "-" & _Nudo,
                                                                     _Path, _Tido & "-" & _Nudo, False)
                    _Pdf_Adjunto.Sb_Crear_PDF("", False, _Pdf_Adjunto.Pro_Nombre_Archivo)
                    Dim _Error_Pdf = _Pdf_Adjunto.Pro_Error

                    _Existe_File = System.IO.File.Exists(_Pdf_Adjunto.Pro_Full_Path_Archivo_PDF & "\" & _Pdf_Adjunto.Pro_Nombre_Archivo & ".pdf")

                    If _Existe_File Then
                        _Archivos_Adjuntos(0) = _Pdf_Adjunto.Pro_Full_Path_Archivo_PDF & "\" & _Pdf_Adjunto.Pro_Nombre_Archivo & ".pdf"
                    Else
                        _Archivos_Adjuntos = Nothing
                    End If

                End If

                Dim _Crea_Html As New Clase_Crear_Documento_Htm
                Dim _Ruta_Html As String = AppPath() & "\Data\" & RutEmpresa & "\Tmp"

                Dim _Cuerpo_Html

                If _Crea_Html.Fx_Crear_Documento_Htm(_IdMaeedo, _Ruta_Html, True) Then
                    Dim _Dir As String = _Ruta_Html & "\Documento.Htm"
                    _Cuerpo_Html = LeeArchivo(_Dir)
                End If

                Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Correos" & vbCrLf &
                               "Where Nombre_Correo = '" & _Nombre_Correo & "'"
                Dim _Row_Correo As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                If _Row_Correo IsNot Nothing Then

                    Dim _Remitente = Trim(_Row_Correo.Item("Remitente"))
                    Dim _Host = _Row_Correo.Item("Host")
                    Dim _Puerto = _Row_Correo.Item("Puerto")
                    Dim _Contrasena = Trim(_Row_Correo.Item("Contrasena"))

                    Dim _CuerpoMensaje = _Fila.Item("Mensaje")
                    Dim _SSL = _Row_Correo.Item("SSL")

                    _CuerpoMensaje = Replace(_CuerpoMensaje, "<HTML>", _Cuerpo_Html & vbCrLf)

                    If String.IsNullOrEmpty(_Asunto) Then
                        _Asunto = "Envío de correo automático por BakApp…"
                    End If

                    Sb_Llenar_Variables_Etiquetas_Documento(_Asunto, _IdMaeedo)
                    Sb_Llenar_Variables_Etiquetas_Documento(_CuerpoMensaje, _IdMaeedo)

                    Dim EnviarCorreo As New Frm_Correos_Conf

                    _Para = _Para.Trim()
                    _Cc = _Cc.Trim()

                    Dim _Correo_Enviado As Boolean = EnviarCorreo.Fx_Enviar_Mail(_Host,
                                                                                 _Remitente,
                                                                                 _Contrasena,
                                                                                 _Para,
                                                                                 _Cc,
                                                                                 _Asunto,
                                                                                 _CuerpoMensaje,
                                                                                 _Archivos_Adjuntos,
                                                                                 _Puerto,
                                                                                 _SSL,
                                                                                 False)

                    Dim _Error As String = EnviarCorreo.Pro_Error
                    EnviarCorreo.Dispose()
                    EnviarCorreo = Nothing

                    Dim _Destinatarios = ", Para: " & _Para
                    If Not String.IsNullOrEmpty(_Cc) Then _Destinatarios = _Destinatarios & ", CC: " & _Cc

                    If _Correo_Enviado Then

                        _Conteo_envio += 1

                        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Aviso_Correo Set" & Space(1) &
                                       "Enviado = 1," &
                                       "Intentos = " & _Intentos + 1 & "," &
                                       "Fecha_Envio = Getdate()," &
                                       "Informacion = 'Envio: Ok'" & vbCrLf &
                                       "Where Id = " & _Id
                        _Sql.Ej_consulta_IDU(Consulta_sql)

                        If _Existe_File Then
                            Try
                                My.Computer.FileSystem.DeleteFile(_Archivos_Adjuntos(0),
                                                                  FileIO.UIOption.OnlyErrorDialogs,
                                                                  FileIO.RecycleOption.DeletePermanently)
                            Catch ex As Exception
                            End Try
                        End If

                        Fx_Add_Log_Gestion(FUNCIONARIO, Modalidad, "MAEEDO", _IdMaeedo, "Diablito",
                                           "Envio: Ok: " & _Destinatarios, "", "", _Koen, _Suen, False, "")

                    Else

                        _Conteo_Error += 1

                        Dim _Problema As String

                        If _Intentos = 3 Then

                            _Problema = "Problemas al enviar correo: " & _Error

                            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Aviso_Correo Set" & Space(1) &
                                           "Enviar = 0," &
                                           "Fecha_Envio = Getdate()," &
                                           "Informacion = '" & _Problema & "'" & vbCrLf &
                                           "Where Id = " & _Id
                        Else

                            _Problema = Replace(_Error, "'", "''")

                            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Aviso_Correo Set" & Space(1) &
                                           "Enviar = 1," & vbCrLf &
                                           "Intentos = " & _Intentos + 1 & "," &
                                           "Fecha_Envio = Getdate()," &
                                           "Informacion = '" & _Problema & "'" & vbCrLf &
                                           "Where Id = " & _Id
                        End If

                        If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                            Fx_Add_Log_Gestion(FUNCIONARIO, Modalidad, "MAEEDO", _IdMaeedo, "Diablito",
                                           _Problema & _Destinatarios, "", "", _Koen, _Suen, False, "")

                        End If


                    End If

                    System.Windows.Forms.Application.DoEvents()

                    Lbl_Correo.Text = "Enviados " & _Conteo_envio & " de " & FormatNumber(_Tbl_Correos.Rows.Count, 0) & " (Probelmas(" & _Conteo_Error & "))"

                End If

            Next

        End If

        Lbl_Correo.Text = "Monitoreo Correos"
        _Segundos_Correo = _Input_Tiempo_Correo / 1000

        _Procesando_Correos = False
        Sb_Pausar(_Pausa.Play)

    End Sub

    Sub Sb_Procedimiento_Cola_Impresion() 'IMPRIMIR DOCUMENTOS AUTOMATICAMENTE CUANDO LLEGAN

        Dim _Consulta_sql = String.Empty
        Sb_Pausar(_Pausa.Pausa)
        _Procesando_Cola_Impresion = True

        Dim _Fecha = Format(DtpFecharevision.Value, "yyyyMMdd")

        Dim Dia_1 As String = numero_(DtpFecharevision.Value.Day, 2)
        Dim Mes_1 As String = numero_(DtpFecharevision.Value.Month, 2)
        Dim Ano_1 As String = DtpFecharevision.Value.Year

        Dim _Filtro_Fecha =
                      "FEEMDO BETWEEN CONVERT(DATETIME, '" & Ano_1 & "-" & Mes_1 & "-" & Dia_1 & " 00:00:00', 102)" & vbCrLf &
                      "AND CONVERT(DATETIME, '" & Ano_1 & "-" & Mes_1 & "-" & Dia_1 & " 23:59:59', 102)"

        Dim _Filtro_Feemdo
        Dim _Filtro_Lahora

        _Filtro_Feemdo =
                      "FEEMDO BETWEEN CONVERT(DATETIME, '" & Ano_1 & "-" & Mes_1 & "-" & Dia_1 & " 00:00:00', 102)" & vbCrLf &
                      "AND CONVERT(DATETIME, '" & Ano_1 & "-" & Mes_1 & "-" & Dia_1 & " 23:59:59', 102)"

        _Filtro_Lahora =
                      "LAHORA BETWEEN CONVERT(DATETIME, '" & Ano_1 & "-" & Mes_1 & "-" & Dia_1 & " 00:00:00', 102)" & vbCrLf &
                      "AND CONVERT(DATETIME, '" & Ano_1 & "-" & Mes_1 & "-" & Dia_1 & " 23:59:59', 102)"

        _Filtro_Fecha = "((" & _Filtro_Feemdo & ") Or (" & _Filtro_Lahora & "))"

        _Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Cola_Impresion" & vbCrLf &
                        "Where Fecha < '" & _Fecha &
                        "' And NombreEquipo = '" & _Nombre_Equipo & "'-- And Impreso = 1" &
                        vbCrLf &
                        vbCrLf &
                        "Select * From " & _Global_BaseBk & "Zw_Demonio_Cof_Estacion" & vbCrLf &
                        "Where NombreEquipo = '" & _Nombre_Equipo &
                        "' And Traer_Doc_Auto_Imprimir = 1"

        Dim _Tbl_Zw_Demonio_Cof_Estacion As DataTable = _Sql.Fx_Get_Tablas(_Consulta_sql)

        Dim _SqlQuery_Cola = String.Empty

        For Each _Fila As DataRow In _Tbl_Zw_Demonio_Cof_Estacion.Rows

            Dim _Tido As String = _Fila.Item("TipoDoc")
            Dim _NombreFormato As String = _Fila.Item("NombreFormato")
            Dim _IdPadre As String = _Fila.Item("Id")
            Dim _Condicion_Func = String.Empty

            Dim _Imprimir_Picking = _Fila.Item("Imprimir_Picking")

            _Consulta_sql = "Select Codigo From " & _Global_BaseBk & "Zw_Demonio_Filtros_X_Estacion" & vbCrLf &
                            "Where IdPadre = " & _IdPadre & " And Impresora <> '' And Picking = 0"
            Dim _TblFiltroFunc As DataTable = _Sql.Fx_Get_Tablas(_Consulta_sql)

            If CBool(_TblFiltroFunc.Rows.Count) Then

                Dim _Imp_Suc_Modal = True '_Fila.Item("Imp_Suc_Modal")

                _Condicion_Func = Generar_Filtro_IN(_TblFiltroFunc, "", "Codigo", False, False, "'") ' 
                _Condicion_Func = "And KOFUDO In " & _Condicion_Func

                Dim _Nudonodefi As String = "0"

                If _Tido = "BLV" Or _Tido = "FCV" Then
                    Dim _Tipo_Definitivo_Vale As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Demonio_Cof_Estacion", "Tipo_Definitivo_Vale",
                                                          "NombreEquipo = '" & _Nombre_Equipo & "' And TipoDoc = '" & _Tido & "'")

                    Select Case _Tipo_Definitivo_Vale
                        Case "D"
                            _Nudonodefi = "0"
                            _SqlQuery_Cola += Fx_Insertar_Documento_Para_Imprimir(_Tido, _NombreFormato, _Filtro_Fecha, _Condicion_Func, 0, 0, _Imp_Suc_Modal)
                        Case "V", "A"
                            If _Tipo_Definitivo_Vale = "V" Then
                                _SqlQuery_Cola += Fx_Insertar_Documento_Para_Imprimir(_Tido, _NombreFormato, _Filtro_Fecha, _Condicion_Func, 1, 0, _Imp_Suc_Modal)
                            ElseIf _Tipo_Definitivo_Vale = "A" Then
                                _SqlQuery_Cola += Fx_Insertar_Documento_Para_Imprimir(_Tido, _NombreFormato, _Filtro_Fecha, _Condicion_Func, 0, 0, _Imp_Suc_Modal)
                                _SqlQuery_Cola += Fx_Insertar_Documento_Para_Imprimir(_Tido, _NombreFormato, _Filtro_Fecha, _Condicion_Func, 1, 0, _Imp_Suc_Modal)
                            End If
                    End Select

                Else
                    _SqlQuery_Cola += Fx_Insertar_Documento_Para_Imprimir(_Tido, _NombreFormato, _Filtro_Fecha, _Condicion_Func, 0, 0, _Imp_Suc_Modal)
                End If

            End If

        Next

        If Not String.IsNullOrEmpty(_SqlQuery_Cola) Then
            _Sql.Ej_consulta_IDU(_SqlQuery_Cola, False)
        End If
        ' **********************************************************************

        _Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Cola_Impresion" & vbCrLf &
                        "Where Revizado_Demonio = 0 And NombreEquipo = '" & _Nombre_Equipo & "' And" & Space(1) &
                        "Fecha = '" & Format(DtpFecharevision.Value, "yyyyMMdd") & "' And Picking = 0"

        Dim _Tbl_Doc_Sin_Imprimir As DataTable = _Sql.Fx_Get_Tablas(_Consulta_sql)

        Dim _Solo_Marcar_No_Imprimir As Boolean = Chk_Solo_Marcar_No_Imprimir.Checked

        If CBool(_Tbl_Doc_Sin_Imprimir.Rows.Count) Then 'CBool(rReg) Then

            If _Tbl_Doc_Sin_Imprimir.Rows.Count > 5 Then

                If MessageBoxEx.Show(_Formulario, "Hay " & _Tbl_Doc_Sin_Imprimir.Rows.Count & " documentos en Cola" & vbCrLf &
                                     "¿Desea imprimirlos de todas formas?",
                                   "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> Windows.Forms.DialogResult.Yes Then

                    _Solo_Marcar_No_Imprimir = True

                End If

            End If

            For Each _Fila_Imp As DataRow In _Tbl_Doc_Sin_Imprimir.Rows

                Dim _Id As Integer = _Fila_Imp.Item("Id")
                Dim _IdMaeedo = _Fila_Imp.Item("Idmaeedo")
                Dim _Tido = _Fila_Imp.Item("Tido")
                Dim _Funcionario = _Fila_Imp.Item("Funcionario")
                Dim _Picking = _Fila_Imp.Item("Picking")

                If Not _Solo_Marcar_No_Imprimir Then

                    Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Demonio_Cof_Estacion" & vbCrLf &
                                   "Where NombreEquipo = '" & _Nombre_Equipo & "' And TipoDoc = '" & _Tido & "'"

                    Dim _Row_Demonio_Cof_Estacion As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)
                    Dim _IdPadre = _Row_Demonio_Cof_Estacion.Item("Id")
                    Dim _Imprimir_Voucher_TJV As Boolean = _Row_Demonio_Cof_Estacion.Item("Imprimir_Voucher_TJV")
                    Dim _Imprimir_Voucher_TJV_Original_Transbak As Boolean = _Row_Demonio_Cof_Estacion.Item("Imprimir_Voucher_TJV_Original_Transbak")

                    Consulta_sql = "Select Top 1 * " &
                                   "From " & _Global_BaseBk & "Zw_Demonio_Filtros_X_Estacion " &
                                   "Where IdPadre = " & _IdPadre & " And TipoDoc = '" & _Tido & "' And Codigo = '" & _Funcionario & "' And Picking = 0"
                    Dim _Row_Demonio_Filtros_X_Estacion As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                    Dim _Imp As String = _Row_Demonio_Filtros_X_Estacion.Item("Impresora")
                    Dim _NombreFormato = _Row_Demonio_Filtros_X_Estacion.Item("NombreFormato")

                    Dim _Nro_Copias_Impresion = _Row_Demonio_Filtros_X_Estacion.Item("Nro_Copias_Impresion")
                    Dim _Log_Error As String


                    If Fx_Validar_Impresora(_Imp) Then

                        _Log_Error = Fx_Enviar_A_Imprimir_Documento(Me, _NombreFormato,
                                                                    _IdMaeedo, False, False, _Imp, False, _Nro_Copias_Impresion, False, "")


                        If String.IsNullOrEmpty(_Log_Error) Then

                            If _Imprimir_Voucher_TJV Or _Imprimir_Voucher_TJV_Original_Transbak Then
                                Sb_Imprimir_Voucher_Tarjeta(_IdMaeedo, _Log_Error, _Imp, _Imprimir_Voucher_TJV_Original_Transbak)
                            End If

                            _Consulta_sql = "Update " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Cola_Impresion" & Space(1) &
                                            "Set Revizado_Demonio = 1,Impreso = 1,Error_Al_Imprimir = 0," & vbCrLf &
                                            "Log_Error = '" & _Log_Error & "'" & vbCrLf &
                                            "Where Id = " & _Id
                            _Sql.Ej_consulta_IDU(_Consulta_sql)

                        Else

                            _Consulta_sql = "Update " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Cola_Impresion" & Space(1) &
                                            "Set Revizado_Demonio = 1,Impreso = 0,Error_Al_Imprimir = 1," &
                                            "Log_Error = '" & _Log_Error & "'" & vbCrLf &
                                            "Where Id = " & _Id
                            _Sql.Ej_consulta_IDU(_Consulta_sql)


                        End If

                    Else

                        _Log_Error = "No existe impresora seleccionada (" & _Imp & "). Revise la configuración de los funcionarios en cola de impresión"

                        _Consulta_sql = "Update " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Cola_Impresion" & Space(1) &
                                        "Set Revizado_Demonio = 1,Impreso = 0,Error_Al_Imprimir = 1,Log_Error = '" & _Log_Error & "'" & vbCrLf &
                                        "Where Id = " & _Id
                        _Sql.Ej_consulta_IDU(_Consulta_sql)

                    End If


                Else

                    _Consulta_sql = "Update " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Cola_Impresion " &
                                    "Set Revizado_Demonio = 1,Impreso = 0,Error_Al_Imprimir = 0,Log_Error = 'No se imprime, se marca como impreso por el usuario'" & vbCrLf &
                                    "Where Id = " & _Id
                    _Sql.Ej_consulta_IDU(_Consulta_sql)

                End If

            Next

        End If

        Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Cola_Impresion",
                                            "Fecha = '" & _Fecha &
                                            "' And NombreEquipo = '" & _Nombre_Equipo & "' And Error_Al_Imprimir = 1")

        If CBool(_Reg) Then
            Btn_LogError_Impresion.Visible = CBool(_Reg)
            Switch_Cola_Impresion.Value = False
        End If

        _Procesando_Correos = False
        Sb_Pausar(_Pausa.Play)

    End Sub

    Sub Sb_Procedimiento_Picking() 'IMPRIMIR DOCUMENTOS AUTOMATICAMENTE CUANDO LLEGAN

        Dim _Consulta_sql = String.Empty

        Sb_Pausar(_Pausa.Pausa)
        _Procesando_Cola_Impresion = True

        Dim _Fecha = Format(DtpFecharevision.Value, "yyyyMMdd")

        Dim Dia_1 As String = numero_(DtpFecharevision.Value.Day, 2)
        Dim Mes_1 As String = numero_(DtpFecharevision.Value.Month, 2)
        Dim Ano_1 As String = DtpFecharevision.Value.Year

        Dim _Filtro_Fecha =
                      "FEEMLI BETWEEN CONVERT(DATETIME, '" & Ano_1 & "-" & Mes_1 & "-" & Dia_1 & " 00:00:00', 102)" & vbCrLf &
                      "AND CONVERT(DATETIME, '" & Ano_1 & "-" & Mes_1 & "-" & Dia_1 & " 23:59:59', 102)"

        _Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Cola_Impresion" & vbCrLf &
                        "Where Fecha < '" & _Fecha &
                        "' And NombreEquipo = '" & _Nombre_Equipo & "'-- And Impreso = 1" &
                        vbCrLf &
                        vbCrLf &
                        "Select * From " & _Global_BaseBk & "Zw_Demonio_Cof_Estacion" & vbCrLf &
                        "Where NombreEquipo = '" & _Nombre_Equipo &
                        "' And Imprimir_Picking = 1"

        Dim _Tbl_Zw_Demonio_Cof_Estacion As DataTable = _Sql.Fx_Get_Tablas(_Consulta_sql)

        Dim _SqlQuery_Cola = String.Empty

        For Each _Fila As DataRow In _Tbl_Zw_Demonio_Cof_Estacion.Rows

            Dim _Tido As String = _Fila.Item("TipoDoc")
            Dim _NombreFormato As String = _Fila.Item("NombreFormato")
            Dim _IdPadre As String = _Fila.Item("Id")
            'Dim _Condicion_Func = String.Empty

            Dim _Imprimir_Picking = _Fila.Item("Imprimir_Picking")
            Dim _Imp_Suc_Modal = _Fila.Item("Imp_Suc_Modal")

            'PICKING
            If _Imprimir_Picking Then

                _Consulta_sql = "Select Codigo From " & _Global_BaseBk & "Zw_Demonio_Filtros_X_Estacion" & vbCrLf &
                                "Where IdPadre = " & _IdPadre & " And Impresora <> '' And Picking = 1"
                Dim _TblFiltroFunc As DataTable = _Sql.Fx_Get_Tablas(_Consulta_sql)

                If CBool(_TblFiltroFunc.Rows.Count) Then

                    _SqlQuery_Cola += Fx_Insertar_Documento_Para_Imprimir_Picking(_Tido, _NombreFormato, _Filtro_Fecha, 0, 1, _Imp_Suc_Modal)

                End If

            End If

        Next

        If Not String.IsNullOrEmpty(_SqlQuery_Cola) Then

            _Sql.Ej_consulta_IDU(_SqlQuery_Cola, False)

        End If

        ' **********************************************************************

        _Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Cola_Impresion" & vbCrLf &
                        "Where Revizado_Demonio = 0 And NombreEquipo = '" & _Nombre_Equipo & "' And" & Space(1) &
                        "Fecha = '" & Format(DtpFecharevision.Value, "yyyyMMdd") & "' And Picking = 1"

        Dim _Tbl_Doc_Sin_Imprimir As DataTable = _Sql.Fx_Get_Tablas(_Consulta_sql)

        Dim _Solo_Marcar_No_Imprimir As Boolean = Chk_Solo_Marcar_No_Imprimir.Checked

        If CBool(_Tbl_Doc_Sin_Imprimir.Rows.Count) Then

            If _Tbl_Doc_Sin_Imprimir.Rows.Count > 5 Then

                If MessageBoxEx.Show(_Formulario, "Hay " & _Tbl_Doc_Sin_Imprimir.Rows.Count & " documentos en Cola" & vbCrLf &
                                     "¿Desea imprimirlos de todas formas?",
                                     "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> Windows.Forms.DialogResult.Yes Then

                    _Solo_Marcar_No_Imprimir = True

                End If

            End If

            For Each _Fila_Imp As DataRow In _Tbl_Doc_Sin_Imprimir.Rows

                Dim _Id As Integer = _Fila_Imp.Item("Id")
                Dim _IdMaeedo = _Fila_Imp.Item("Idmaeedo")
                Dim _Tido = _Fila_Imp.Item("Tido")
                Dim _Funcionario = _Fila_Imp.Item("Funcionario")
                Dim _Picking = _Fila_Imp.Item("Picking")

                If Not _Solo_Marcar_No_Imprimir Then

                    Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Demonio_Cof_Estacion" & vbCrLf &
                                   "Where NombreEquipo = '" & _Nombre_Equipo & "' And TipoDoc = '" & _Tido & "'"

                    Dim _Row_Demonio_Cof_Estacion As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)
                    Dim _IdPadre = _Row_Demonio_Cof_Estacion.Item("Id")
                    Dim _Imprimir_Voucher_TJV As Boolean = _Row_Demonio_Cof_Estacion.Item("Imprimir_Voucher_TJV")
                    Dim _Imprimir_Voucher_TJV_Original_Transbak As Boolean = _Row_Demonio_Cof_Estacion.Item("Imprimir_Voucher_TJV_Original_Transbak")

                    Consulta_sql = "Select Top 1 * " &
                                   "From " & _Global_BaseBk & "Zw_Demonio_Filtros_X_Estacion " &
                                   "Where IdPadre = " & _IdPadre & " And TipoDoc = '" & _Tido & "' And Codigo = '" & _Funcionario & "' And Picking = 1"
                    Dim _Row_Demonio_Filtros_X_Estacion As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                    Dim _Imp As String = _Row_Demonio_Filtros_X_Estacion.Item("Impresora")
                    Dim _NombreFormato = _Row_Demonio_Filtros_X_Estacion.Item("NombreFormato")

                    Dim _Nro_Copias_Impresion = _Row_Demonio_Filtros_X_Estacion.Item("Nro_Copias_Impresion")
                    Dim _Log_Error As String


                    If Fx_Validar_Impresora(_Imp) Then

                        _Log_Error = Fx_Enviar_A_Imprimir_Documento(Me, _NombreFormato,
                                                                    _IdMaeedo, False, False, _Imp, False, _Nro_Copias_Impresion, False, "")


                        If String.IsNullOrEmpty(_Log_Error) Then

                            _Consulta_sql = "Update " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Cola_Impresion" & Space(1) &
                                            "Set Revizado_Demonio = 1,Impreso = 1,Error_Al_Imprimir = 0," & vbCrLf &
                                            "Log_Error = '" & _Log_Error & "'" & vbCrLf &
                                            "Where Id = " & _Id
                            _Sql.Ej_consulta_IDU(_Consulta_sql)

                        Else

                            _Consulta_sql = "Update " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Cola_Impresion" & Space(1) &
                                            "Set Revizado_Demonio = 1,Impreso = 0,Error_Al_Imprimir = 1," &
                                            "Log_Error = '" & _Log_Error & "'" & vbCrLf &
                                            "Where Id = " & _Id
                            _Sql.Ej_consulta_IDU(_Consulta_sql)


                        End If

                    Else

                        _Log_Error = "No existe impresora seleccionada (" & _Imp & "). Revise la configuración de los funcionarios en cola de impresión"

                        _Consulta_sql = "Update " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Cola_Impresion" & Space(1) &
                                        "Set Revizado_Demonio = 1,Impreso = 0,Error_Al_Imprimir = 1,Log_Error = '" & _Log_Error & "'" & vbCrLf &
                                        "Where Id = " & _Id
                        _Sql.Ej_consulta_IDU(_Consulta_sql)

                    End If


                Else

                    _Consulta_sql = "Update " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Cola_Impresion " &
                                    "Set Revizado_Demonio = 1,Impreso = 0,Error_Al_Imprimir = 0,Log_Error = 'No se imprime, se marca como impreso por el usuario'" & vbCrLf &
                                    "Where Id = " & _Id
                    _Sql.Ej_consulta_IDU(_Consulta_sql)

                End If

            Next

        End If

        Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Cola_Impresion",
                                            "Fecha = '" & _Fecha &
                                            "' And NombreEquipo = '" & _Nombre_Equipo & "' And Error_Al_Imprimir = 1")

        If CBool(_Reg) Then
            Btn_LogError_Impresion.Visible = CBool(_Reg)
            Switch_Cola_Impresion.Value = False
        End If

        _Procesando_Correos = False
        Sb_Pausar(_Pausa.Play)

    End Sub

    Private Function Fx_Insertar_Documento_Para_Imprimir_Picking(_Tido As String,
                                                                 _NombreFormato As String,
                                                                 _Filtro_Fecha As String,
                                                                 _Nudonodefi As Integer,
                                                                 _Picking As Integer,
                                                                 _Imp_Suc_Modal As Boolean)

        Dim _Filtro_Sucursal = String.Empty

        If _Imp_Suc_Modal Then
            _Filtro_Sucursal = "And SULIDO = '" & ModSucursal & "' And BOSULIDO = '" & ModBodega & "'"
        End If

        Fx_Insertar_Documento_Para_Imprimir_Picking =
                         "-- INSERTANDO " & _Tido &
                         vbCrLf &
                         vbCrLf &
                         "Insert Into " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Cola_Impresion" & Space(1) &
                         "(NombreEquipo,Idmaeedo,Tido,Nudo,Funcionario,Fecha,NombreFormato,Nudonodefi,Picking)" & vbCrLf &
                         "Select '" & _Nombre_Equipo & "',IDMAEEDO,TIDO,NUDO,KOFUDO,GetDate()," &
                         "'" & _NombreFormato & "'," & _Nudonodefi & "," & _Picking & vbCrLf &
                         "From MAEEDO" & vbCrLf &
                         "Where" & vbCrLf &
                         "IDMAEEDO IN (Select Distinct IDMAEEDO From MAEDDO" & vbCrLf &
                         "Where" & vbCrLf &
                         "TIDO = '" & _Tido & "' " & vbCrLf &
                         _Filtro_Sucursal & vbCrLf &
                         "And " & _Filtro_Fecha & vbCrLf & "And NUDONODEFI = " & _Nudonodefi & vbCrLf &
                         "And IDMAEEDO not In (Select Idmaeedo From " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Cola_Impresion" & vbCrLf &
                         "Where NombreEquipo = '" & _Nombre_Equipo & "'  And Nudonodefi = " & _Nudonodefi & " And Picking = " & _Picking & "))" & vbCrLf &
                         vbCrLf & "-------------------------------------------------" & vbCrLf


    End Function

    Private Function Fx_Insertar_Documento_Para_Imprimir(_Tido As String,
                                                         _NombreFormato As String,
                                                         _Filtro_Fecha As String,
                                                         _Condicion_Func As String,
                                                         _Nudonodefi As Integer,
                                                         _Picking As Integer,
                                                         _Imp_Suc_Modal As Boolean)

        Dim _Filtro_Sucursal = String.Empty

        If _Imp_Suc_Modal Then
            _Filtro_Sucursal = "And SUDO = '" & ModSucursal & "'"
        End If

        Fx_Insertar_Documento_Para_Imprimir =
                                 "-- INSERTANDO " & _Tido &
                                 vbCrLf &
                                 vbCrLf &
                                 "Insert Into " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Cola_Impresion" & Space(1) &
                                 "(NombreEquipo,Idmaeedo,Tido,Nudo,Funcionario,Fecha,NombreFormato,Nudonodefi,Picking)" & vbCrLf &
                                 "Select '" & _Nombre_Equipo & "',IDMAEEDO,TIDO,NUDO,KOFUDO,GetDate()," &
                                 "'" & _NombreFormato & "'," & _Nudonodefi & "," & _Picking & vbCrLf &
                                 "From MAEEDO Where TIDO = '" & _Tido & "'" & vbCrLf &
                                 "And " & _Filtro_Fecha & vbCrLf & "And NUDONODEFI = " & _Nudonodefi & vbCrLf &
                                 "And IDMAEEDO not In (Select Idmaeedo From " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Cola_Impresion" & vbCrLf &
                                 "Where NombreEquipo = '" & _Nombre_Equipo & "'  And Nudonodefi = " & _Nudonodefi & " And Picking = " & _Picking & ")" & vbCrLf &
                                 _Condicion_Func & vbCrLf &
                                _Filtro_Sucursal & vbCrLf &
                                 vbCrLf & "-------------------------------------------------" & vbCrLf

    End Function

    Sub Sb_Procedimiento_Solicitud_De_Productos_A_Bodega()

        Sb_Pausar(_Pausa.Pausa)

        Dim _Id As Integer

        Consulta_sql = "Select Id From " & _Global_BaseBk & "Zw_Prod_SolBodega " &
                       "Where Empresa = '" & ModEmpresa & "' And Sucursal = '" & ModSucursal & "'  And Bodega = '" & ModBodega & "' And Impreso = 0"

        Dim _TblProd_SolBodega = _Sql.Fx_Get_Tablas(Consulta_sql)

        If CBool(_TblProd_SolBodega.Rows.Count) Then
            For Each FILA As DataRow In _TblProd_SolBodega.Rows

                _Id = FILA.Item("Id")

                If Chk_Solo_Marcar_No_Imprimir.Checked = False Then

                    Dim _NombreFormato = "Solicitud_PrBd"

                    Dim _Log_Error As String = Fx_Imprimir_Documento(_Id, "SPB", "", _NombreFormato, False, False,
                                                                     False, _Impresora_Prod_Sol_Bodega, "")

                    If String.IsNullOrEmpty(_Log_Error) Then
                        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Prod_SolBodega set Impreso = 1 where Id = " & _Id
                        _Sql.Ej_consulta_IDU(Consulta_sql)
                    End If

                End If

            Next

        End If

        Sb_Pausar(_Pausa.Play)

    End Sub

    Sub Sb_Procedimiento_Poswii() 'IMPRIMIR EN POSWII SOLO FERRETERIA OHIGGINS

        Dim _Consulta_sql = String.Empty
        Sb_Pausar(_Pausa.Pausa)

        Dim _SqlPoswi As New Class_SQL(_Cadena_Conexion_Poswii)

        Consulta_sql = "SELECT id_impresion,id_tipo_doc,folio,fecha_creacion,codigo_usuario,texto_autorizacion,rut_cliente,nombre_cliente," &
                       "id_tabla_cab_ERP,codigo_cliente,impreso,copias,atencion,validez_oferta" & vbCrLf &
                       "FROM " & _Global_BaseBk & "hist_impresion" & vbCrLf &
                       "Where impreso = 0"

        Dim _Tbl_hist_impresion As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        If CBool(_Tbl_hist_impresion.Rows.Count) Then

            For Each _Fila As DataRow In _Tbl_hist_impresion.Rows

                Dim _id_impresion = _Fila.Item("id_impresion")
                Dim _id_tipo_doc = _Fila.Item("id_tipo_doc")
                Dim _folio = _Fila.Item("folio")
                Dim _fecha_creacion = _Fila.Item("fecha_creacion")
                Dim _codigo_usuario = _Fila.Item("codigo_usuario")
                Dim _texto_autorizacion = CInt(_Fila.Item("texto_autorizacion") * -1)
                Dim _rut_cliente = _Fila.Item("rut_cliente")
                Dim _nombre_cliente = _Fila.Item("nombre_cliente")
                Dim _id_tabla_cab_ERP = _Fila.Item("id_tabla_cab_ERP")
                Dim _codigo_cliente = _Fila.Item("codigo_cliente")
                Dim _impreso = _Fila.Item("impreso")
                Dim _copias = 1 '_Fila.Item("copias")
                Dim _atencion = _Fila.Item("atencion")
                Dim _validez_oferta = _Fila.Item("validez_oferta")
                Dim _Log_Error = String.Empty

                Consulta_sql = "Select Top 1 * From usuarios Where codigo = '" & _codigo_usuario & "'"
                Dim _Row_usuario_poswi As DataRow = _SqlPoswi.Fx_Get_DataRow(Consulta_sql)

                If _Row_usuario_poswi Is Nothing Then

                    _Log_Error = "Usuario no esta registrado en la tabla usuarios de la base poswi_central"
                    Consulta_sql = "Update " & _Global_BaseBk & "hist_impresion Set Log_Error = '" & _Log_Error & "'" & vbCrLf &
                                                       "Where id_impresion = " & _id_impresion
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                Else

                    Dim _impresora As String = _Row_usuario_poswi.Item("impresora")
                    _copias = _Row_usuario_poswi.Item("copias_imp_default")

                    If String.IsNullOrEmpty(_Log_Error) Then

                        Consulta_sql = "Insert Into hist_impresion" & Space(1) &
                                       "(id_tipo_doc,folio,fecha_creacion,codigo_usuario,texto_autorizacion," &
                                       "rut_cliente,nombre_cliente, id_tabla_cab_ERP,codigo_cliente,impreso,copias," &
                                       "atencion,validez_oferta) Values " &
                                       "(" & _id_tipo_doc & ",'" & _folio & "',CONVERT (date, getdate()),'" & _codigo_usuario &
                                       "','','" & _rut_cliente & "','" & _nombre_cliente & "'," & _id_tabla_cab_ERP &
                                       ",'" & _codigo_cliente & "',0," & _copias &
                                       ",'" & _atencion & "','" & _validez_oferta & "')" & vbCrLf & vbCrLf

                        If _SqlPoswi.Ej_consulta_IDU(Consulta_sql) Then

                            Consulta_sql = "Delete " & _Global_BaseBk & "hist_impresion" & vbCrLf &
                                           "Where id_impresion = " & _id_impresion
                            _Sql.Ej_consulta_IDU(Consulta_sql)

                        End If

                    End If

                End If

            Next

        End If

        Consulta_sql = "SELECT id_envio_email,cuenta_email,fecha_creacion,hora_creacion,enviado,id_tabla_cab_ERP,id_tipo_doc," &
                       "folio,enviar" & vbCrLf &
                       "From " & _Global_BaseBk & "hist_envios_email" & vbCrLf &
                       "Where enviado = 0"
        Dim _Tbl_hist_envios_email As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        If CBool(_Tbl_hist_envios_email.Rows.Count) Then

            For Each _Fila As DataRow In _Tbl_hist_envios_email.Rows

                Dim _id_envio_email = _Fila.Item("id_envio_email")
                Dim _cuenta_email = _Fila.Item("cuenta_email")
                Dim _id_tabla_cab_ERP = _Fila.Item("id_tabla_cab_ERP")
                Dim _id_tipo_doc = _Fila.Item("id_tipo_doc")
                Dim _folio = _Fila.Item("folio")

                Consulta_sql = "Insert Into hist_envios_email" & Space(1) &
                       "(cuenta_email,fecha_creacion,hora_creacion,enviado,id_tabla_cab_ERP," &
                       "id_tipo_doc,folio,enviar) Values " &
                       "('" & _cuenta_email & "',CONVERT(date, getdate())," &
                       "SUBSTRING(CONVERT(varchar(10),CONVERT(time, CURRENT_TIMESTAMP)),1,8)" &
                       ",0," & _id_tabla_cab_ERP & "," & _id_tipo_doc & ",'" & _folio & "',1)"

                If _SqlPoswi.Ej_consulta_IDU(Consulta_sql) Then

                    Consulta_sql = "Delete " & _Global_BaseBk & "hist_envios_email" & vbCrLf &
                                   "Where id_envio_email = " & _id_envio_email
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                End If

            Next

        End If

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "hist_impresion", "impreso = 0 And Log_Error <> ''")
        Btn_LogError_Poswii.Visible = CBool(_Reg)

        Sb_Pausar(_Pausa.Play)

    End Sub

    Sub Sb_Procedimiento_Prestashop()

        Dim _Consulta_sql = String.Empty
        Sb_Pausar(_Pausa.Pausa)

        _Procesando_Prestashop = True

        Dim _Fecha = Format(DtpFecharevision.Value, "yyyyMMdd")

        Dim Dia_1 As String = numero_(DtpFecharevision.Value.Day, 2)
        Dim Mes_1 As String = numero_(DtpFecharevision.Value.Month, 2)
        Dim Ano_1 As String = DtpFecharevision.Value.Year

        _Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Demonio_Prestashop" & vbCrLf &
                        "Where 1 > 0 " & vbCrLf &
                        "And ((Revisado = 0 And NombreEquipo = '" & _Nombre_Equipo & "' And Fecha = '" & _Fecha & "')" & vbCrLf &
                        "Or (Revisado = 0 And Peticion_Manual = 1 And Fecha = '" & _Fecha & "'))"
        Dim _Tbl_Productos_Prestashop As DataTable = _Sql.Fx_Get_Tablas(_Consulta_sql)

        If CBool(_Tbl_Productos_Prestashop.Rows.Count) Then

            Dim _Filtro_Codigos As String = Generar_Filtro_IN(_Tbl_Productos_Prestashop, "", "Id", True, False, "")

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Demonio_Prestashop" & Space(1) &
                           "Where NombreEquipo = '" & _Nombre_Equipo & "' And Codigo = 'Error!!'" & vbCrLf & vbCrLf &
                           "Update " & _Global_BaseBk & "Zw_Demonio_Prestashop Set Log_Error = '' Where Id In " & _Filtro_Codigos
            _Sql.Ej_consulta_IDU(Consulta_sql, False)

            Dim _Cadena_Conexion_MySql As String
            Dim _Clas_Ps As Class_MySQL

            'For Each _Row_Doc As DataRow In _Tbl_Productos_Prestashop.Rows
            System.Windows.Forms.Application.DoEvents()

            Consulta_sql = "Select Codigo_Pagina,Nombre_Pagina,Host,Usuario,Clave,Puerto_X_Defecto,Puerto,Base_Datos,Cod_Lista" & vbCrLf &
                           "From " & _Global_BaseBk & "Zw_PrestaShop" & vbCrLf &
                           "Where Conexion_Activa = 1"
            Dim _Tbl_Prestashop As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            Dim _Cont_Conexion = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Demonio_Prestashop", "1>0") + 1

            For Each _Fila As DataRow In _Tbl_Prestashop.Rows

                Dim _Codigo_Pagina = _Fila.Item("Codigo_Pagina")
                Dim _Nombre_Pagina = _Fila.Item("NOmbre_Pagina")

                Dim _Host = _Fila.Item("Host")
                Dim _Usuario = _Fila.Item("Usuario")
                Dim _Clave = _Fila.Item("Clave")
                Dim _Puerto_X_Defecto = _Fila.Item("Puerto_X_Defecto")
                Dim _Puerto = _Fila.Item("Puerto")
                Dim _Base_Datos = _Fila.Item("Base_Datos")
                Dim _Cod_Lista = _Fila.Item("Cod_Lista")

                _Cadena_Conexion_MySql = "Host=" & _Host & ";Database=" & _Base_Datos & ";Uid=" & _Usuario & ";Password=" & _Clave & ";"
                _Clas_Ps = New Class_MySQL(_Cadena_Conexion_MySql)

                _Clas_Ps.Sb_Abrir_Conexion()

                Dim _Log_Error As String = _Clas_Ps.Pro_Error


                If String.IsNullOrEmpty(_Clas_Ps.Pro_Error) Then

                    Dim _Contador = 1

                    For Each _Row_Doc As DataRow In _Tbl_Productos_Prestashop.Rows

                        Dim _Codigo = _Row_Doc.Item("Codigo")
                        Dim _Id As Integer = _Row_Doc.Item("Id")

                        Lbl_Prestashop.Text = _Nombre_Pagina & ", Prod.: " & _Contador & " de " & _Tbl_Productos_Prestashop.Rows.Count
                        _Contador += 1

                        _Log_Error = String.Empty

                        Consulta_sql = "Select Top 1 * From TABCODAL" & vbCrLf &
                                       "Where KOEN = '" & _Codigo_Pagina & "' AND KOPR = '" & _Codigo & "'"
                        Dim _Row_Tabcodal As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                        Dim _Error_Stock = String.Empty
                        Dim _Error_Precios = String.Empty
                        Dim _Error_active = String.Empty

                        _Error_Stock = Fx_Prestashop_Actualizar_Stock(_Cadena_Conexion_MySql, _Nombre_Pagina, _Codigo, _Row_Tabcodal, 50) & " - "
                        _Error_Precios = Fx_Prestashop_Actualizar_Precios(_Cadena_Conexion_MySql, _Nombre_Pagina, _Codigo, _Cod_Lista, _Row_Tabcodal)
                        _Error_active = Fx_Prestashop_Activar_Desactivar_Producto(_Cadena_Conexion_MySql, _Codigo, _Codigo_Pagina)

                        Dim _Error As Boolean
                        _Log_Error = _Nombre_Pagina & ", " & _Error_Stock & ", " & _Error_Precios

                        If _Error_Stock = "Error!! al insertar Stock" Or _Error_Precios = "Error!! al insertar Precio" Then

                            _Error = True
                            Btn_Reenviar_Con_Errores_Prestashop.Visible = True
                            Btn_LogError_Prestashop.Enabled = True
                            Btn_LogError_Prestashop.Visible = True

                        Else

                            _Error = False

                        End If

                        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Demonio_Prestashop Set Revisado = 1," & vbCrLf &
                                       "Log_Error = '(" & _Log_Error & ") '+Log_Error," & Space(1) &
                                       "Error = " & CInt(_Error) * -1 & vbCrLf &
                                       "Where Id = " & _Id
                        _Sql.Ej_consulta_IDU(Consulta_sql, False)

                    Next

                Else

                    Btn_LogError_Prestashop.Enabled = True

                    Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Demonio_Prestashop (NombreEquipo,Idmaeddo,Codigo,Descripcion,Fecha,Revisado,Log_Error,Error) Values " & vbCrLf &
                                   "('" & _Nombre_Equipo & "'," & _Cont_Conexion & ",'Error!!','" & _Nombre_Pagina &
                                   "','" & _Fecha & "',1,'Error: " & _Nombre_Pagina & ", Descripción Error: " & _Log_Error & "',1)"
                    _Sql.Ej_consulta_IDU(Consulta_sql, False)

                End If

                _Cont_Conexion += 1

            Next

            If Switch_Prestashop.Value = False Then GoTo Fin

            ' Next

        End If

Fin:
        Lbl_Prestashop.Text = "Prestashop"
        _Procesando_Prestashop = False
        Sb_Pausar(_Pausa.Play)

    End Sub

    'Sub Sb_Procedimiento_Prestashop2(_Procesar_Todo As Boolean)

    '    Dim _Consulta_sql = String.Empty
    '    Sb_Pausar(_Pausa.Pausa)

    '    Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_PrestaShop"
    '    Dim _Tbl_Sitios_Prestashops As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql, False)

    '    Dim _Sitio As String
    '    Dim _Stock_Maximo As Double

    '    Dim _Tbl_Productos As DataTable

    '    For Each _Row_Prestashop As DataRow In _Tbl_Sitios_Prestashops.Rows

    '        _Sitio = _Row_Prestashop.Item("Nombre_Pagina")
    '        _Stock_Maximo = _Row_Prestashop.Item("Stock_Maximo")

    '        If _Procesar_Todo Then

    '            Consulta_sql = "Select *,Cast(0 As Float) As Stock_Actual,Cast(0 As Bit) As Mostrar
    '                            From " & _Global_BaseBk & "Zw_Prod_PrestaShop
    '                            Where Sitio = '" & _Sitio & "'"

    '        Else

    '            Consulta_sql = "Select *,Cast(0 As Float) As Stock_Actual,Cast(0 As Bit) As Mostrar
    '                            Into #Paso
    '                            From " & _Global_BaseBk & "Zw_Prod_PrestaShop
    '                            Where Sitio = '" & _Sitio & "' 

    '                            Update #Paso Set Stock_Actual = (Select Isnull(Sum(STFI1),0) From MAEST Where KOPR = Codigo)

    '                            Update #Paso Set Mostrar = 1 Where Codigo In (Select Codigo From #Paso Where Stock_Actual <> Stock_Rd And Stock_Actual < " & De_Txt_a_Num_01(_Stock_Maximo, 5) & ")
    '		        Update #Paso Set Mostrar = 1 Where Codigo In (Select Codigo_Padre From " & _Global_BaseBk & "Zw_Prod_Padres Where Carpeta = '" & _Sitio & "' And Codigo_Hijo In (Select Codigo From #Paso Where Mostrar = 1))
    '		        Update #Paso Set Mostrar = 1 Where Codigo In (Select Codigo_Hijo From " & _Global_BaseBk & "Zw_Prod_Padres Z2 Where Carpeta = '" & _Sitio & "' And Codigo_Padre In (Select Codigo From #Paso Where Mostrar = 1))

    '                            Select * From #Paso Where Mostrar = 1
    '                            Drop Table #Paso"

    '        End If


    '        _Tbl_Productos = _Sql.Fx_Get_Tablas(Consulta_sql)

    '        If CBool(_Tbl_Productos.Rows.Count) Then

    '            Dim _Class_Prestashop = New Class_Prestashop(_Sitio)

    '            If Not IsNothing(_Tbl_Productos) Then
    '                _Tbl_Productos = _Class_Prestashop.Fx_Tbl_Productos_Prestashop(_Class_Prestashop.Sitio, _Tbl_Productos, "Codigo")
    '            End If

    '            _Class_Prestashop.Progress_Canti = Circular_Prestashop

    '            _Class_Prestashop.Etiqueta2 = Lbl_Prestashop
    '            _Class_Prestashop.Sb_Insertar_Nuevos_Productos_Desde_Prestashop_Hacia_Tabla_Prod_PrestaShop(False)

    '            _Class_Prestashop.Sb_Actualizar_Tabla_Prod_PrestaShop(_Tbl_Productos)
    '            _Class_Prestashop.Sb_Actualizar_Datos_En_Prestashop(_Tbl_Productos, True)
    '            _Class_Prestashop.Sb_Activar_Desactivar_Datos_En_Prestashop()

    '        End If

    '    Next

    '    Lbl_Prestashop.Text = "Prestashop"
    '    _Procesando_Prestashop = False
    '    Sb_Pausar(_Pausa.Play)

    'End Sub

    'Sub Sb_Procedimiento_Prestashop_orders()

    '    Dim _Consulta_sql = String.Empty
    '    Sb_Pausar(_Pausa.Pausa)

    '    _Procesando_Prestashop = True

    '    _Consulta_sql = "Select Od.Id_order,Od.Reference,Od.Date_add,Od.Total_paid,Ps.*
    '                     From " & _Global_BaseBk & "Zw_PrestaShop_orders Od
    '                     Inner Join " & _Global_BaseBk & "Zw_PrestaShop Ps On Ps.Codigo_Pagina = Od.Codigo_Pagina
    '                     Where Reference = ''"

    '    Dim _Tbl_PrestaShop_orders As DataTable = _Sql.Fx_Get_Tablas(_Consulta_sql)

    '    If CBool(_Tbl_PrestaShop_orders.Rows.Count) Then

    '        For Each _Fila As DataRow In _Tbl_PrestaShop_orders.Rows

    '            Dim _Codigo_Pagina = _Fila.Item("Codigo_Pagina")
    '            Dim _Nombre_Pagina = _Fila.Item("Nombre_Pagina")

    '            Dim _Host = _Fila.Item("Host")
    '            Dim _Usuario = _Fila.Item("Usuario")
    '            Dim _Clave = _Fila.Item("Clave")
    '            Dim _Puerto_X_Defecto = _Fila.Item("Puerto_X_Defecto")
    '            Dim _Puerto = _Fila.Item("Puerto")
    '            Dim _Base_Datos = _Fila.Item("Base_Datos")
    '            Dim _Cod_Lista = _Fila.Item("Cod_Lista")

    '            Dim _Id_order As Integer = _Fila.Item("Id_order")

    '            Dim _Cadena_Conexion_MySql As String
    '            Dim _Clas_Ps As Class_MySQL

    '            _Cadena_Conexion_MySql = "Host=" & _Host & ";Database=" & _Base_Datos & ";Uid=" & _Usuario & ";Password=" & _Clave & ";"
    '            _Clas_Ps = New Class_MySQL(_Cadena_Conexion_MySql)

    '            _Clas_Ps.Sb_Abrir_Conexion()

    '            Dim _Log_Error As String = _Clas_Ps.Pro_Error

    '            If String.IsNullOrEmpty(_Clas_Ps.Pro_Error) Then

    '                _Log_Error = Fx_Prestashop_Traer_Orden(_Cadena_Conexion_MySql, _Codigo_Pagina, _Id_order)

    '            End If

    '            If Not String.IsNullOrEmpty(_Log_Error) Then

    '                'Fx_Add_Log_Gestion(FUNCIONARIO, Modalidad, "Zw_PrestaShop_orders", _Id_order, "Diablito",
    '                '                   "Prestashop " & _Nombre_Pagina & ": " & _Log_Error, "", "", "", "", False, "")

    '                Consulta_sql = "Update " & _Global_BaseBk & "Zw_PrestaShop_orders Set 
    '                                Reference = 'Error! - " & Mid(_Log_Error.Trim, 1, 80) & "' 
    '                                Where Codigo_Pagina = '" & _Codigo_Pagina & "' And Id_order = " & _Id_order
    '                _Sql.Ej_consulta_IDU(Consulta_sql)

    '            End If

    '            _Log_Error = String.Empty

    '        Next

    '    End If

    '    Lbl_Prestashop.Text = "Prestashop"
    '    _Procesando_Prestashop = False
    '    Sb_Pausar(_Pausa.Play)

    'End Sub

    Sub Sb_Procedimiento_Consolidar_Stock(_Rdb_Cons_Stock_Todos As Boolean,
                                          _Rdb_Cons_Stock_Mov_Hoy As Boolean)

        Timer_Hora_Actual.Stop()

        _Cl_Archivador.Sb_Detener()
        _Cl_Correos.Sb_Detener()
        _Cl_Imprimir_Documentos.Sb_Detener()
        _Cl_Imprimir_Picking.Sb_Detener()
        _Cl_LibroDTESII.Sb_Detener()
        _Cl_Prestashop_Orders.Sb_Detener()
        _Cl_Prestashop_Web.Sb_Detener()
        _Cl_Solicitud_Productos_Bodega.Sb_Detener()

        Sb_Pausar(_Pausa.Pausa)

        Dim _Tbl_Productos As DataTable

        Dim _Fecha = Format(DtpFecharevision.Value, "yyyyMMdd")
        Dim _Hora_Inicio = Date.Now.ToShortTimeString

        If _Rdb_Cons_Stock_Todos Then
            Consulta_sql = "Select KOPR AS 'Codigo', NOKOPR AS 'Descripcion' From MAEPR" & vbCrLf &
                           "Where ATPR = '' And TIPR = 'FPN'"
        ElseIf _Rdb_Cons_Stock_Mov_Hoy Then

            Consulta_sql = "Select KOPR AS 'Codigo', NOKOPR AS 'Descripcion' From MAEPR" & vbCrLf &
                           "Where" & vbCrLf &
                           "ATPR = '' And TIPR = 'FPN'" & vbCrLf &
                           "And (KOPR IN (SELECT Distinct KOPRCT From MAEDDO Where FEEMLI = '" & _Fecha & "')" & vbCrLf &
                           "Or KOPR In (Select KOPRCT From MAEDDO Ddo Inner Join MAEEDO Edo On Edo.IDMAEEDO = Ddo.IDMAEEDO " &
                           "Where CONVERT(varchar,LAHORA,112) = '" & _Fecha & "'))"

        End If

        _Tbl_Productos = _Sql.Fx_Get_Tablas(Consulta_sql)

        If CBool(_Tbl_Productos.Rows.Count) Then

            Dim _Filtro_Productos As String = Generar_Filtro_IN(_Tbl_Productos, "", "Codigo", False, False, "'")

            Dim Fm As New Frm_Consolidacion_Stock_PP(_Filtro_Productos)
            Fm.Pro_Ejecutar_Automaticamente = True
            Fm.ShowDialog(_Formulario)
            Fm.Dispose()

            Dim _Hora_Termino = Date.Now.ToShortTimeString

            Fx_Add_Log_Gestion(FUNCIONARIO, Modalidad, "", 0, "Consolidacion",
                               "Consolidación de stock automaticamente desde el diablito según programación..." & Space(1) &
                               "Productos: " & FormatNumber(_Tbl_Productos.Rows.Count, 0) & Space(1) &
                               "Hora inicio: " & _Hora_Inicio & ", Hora termino: " & _Hora_Termino,
                               "", "", "", "", 0, "")

        End If

        Sb_Pausar(_Pausa.Play)

        Timer_Hora_Actual.Start()

    End Sub

    Sub Sb_Procedimiento_LibroDTESII(_Periodo As Integer,
                                     _Mes As Integer,
                                     _Bajar_Libros As Boolean,
                                     _Revisar_Libro_Ventas As Boolean,
                                     _Revisar_Libro_Compras As Boolean,
                               ByRef _Libro_Bajado As Boolean,
                                     _Reenviar_Documentos_al_SII As Boolean)

        Sb_Pausar(_Pausa.Pausa)

        Dim _Error = String.Empty

        Dim _Estatus As String = Lbl_LibroDTESII.Text

        Dim _Clas_Hefesto_Dte_Libro As New Clas_Hefesto_Dte_Libro

        CircularLibroDTESII.ProgressBarType = eCircularProgressType.Donut

        _Clas_Hefesto_Dte_Libro.Circular_Progres_Porc = CircularLibroDTESII

        '_Ubic_Archivo = "D:\OneDrive\Documentos\Empresas\Sierralta\Hefesto_DTE\CONFIGURACION\Salida\" & RutEmpresa & "\" & _Periodo

        If _Bajar_Libros Then

            If System.IO.File.Exists(_Clas_Hefesto_Dte_Libro.Directorio_Hefesto & "\SISTEMA\HEFESTO_LIBROS.exe") Then

                Dim _Cadena_ConexionSQL_Server_Actual As String = Replace(Cadena_ConexionSQL_Server, " ", "@")
                Dim _Ejecutar As String = _Clas_Hefesto_Dte_Libro.Directorio_Hefesto & "\SISTEMA\HEFESTO_LIBROS.exe" & Space(1) & RutEmpresa & Space(1) & _Periodo & "-" & numero_(_Mes, 2)

                Try

                    Shell(_Ejecutar, AppWinStyle.MinimizedNoFocus, True)
                    _Libro_Bajado = True

                Catch ex As Exception

                    _Error = ex.Message

                End Try

            Else

                _Error = "No se encontro el archivo HEFESTO_LIBROS.exe en el directorio (" & _Clas_Hefesto_Dte_Libro.Directorio_Hefesto & "\SISTEMA)"

            End If

        Else

            _Libro_Bajado = True

        End If

        If _Libro_Bajado Then

            _Clas_Hefesto_Dte_Libro.Formulario = Me

            If _Revisar_Libro_Ventas Then
                'Revisión de libro de ventas
                _Clas_Hefesto_Dte_Libro.Estatus = Lbl_LibroDTESII
                _Clas_Hefesto_Dte_Libro.Fx_Importar_Archivo_SII_Ventas_Desde_XML(_Periodo, _Mes, _Reenviar_Documentos_al_SII)
            End If

            If _Revisar_Libro_Compras Then
                'Revisión de libro de compras
                _Clas_Hefesto_Dte_Libro.Estatus = Lbl_LibroDTESII
                _Clas_Hefesto_Dte_Libro.Fx_Importar_Archivo_SII_Compras_Desde_XML(_Periodo, _Mes)

            End If

        End If

        Lbl_LibroDTESII.Text = _Estatus

        If Not String.IsNullOrEmpty(_Error) Then

            Switch_LibroDTESII.Value = False
            CircularLibroDTESII.Visible = False
            Lbl_LibroDTESII.Text = "Monitoreo Libro DTE desde SII, ERROR!!!"
            Fx_Add_Log_Gestion(FUNCIONARIO, Modalidad, "", 0, "Demonio_Error", _Error, "", "", "", "", False, "")

        End If

        CircularLibroDTESII.ProgressBarType = eCircularProgressType.Line

        Sb_Pausar(_Pausa.Play)

    End Sub

    Sub Sb_Procedimiento_Archivar_Documentos(_Incluir_Levantados As Boolean)

        Sb_Pausar(_Pausa.Pausa)

        Dim _Year As String = DtpFecharevision.Value.Year.ToString
        Dim _Month As String = numero_(DtpFecharevision.Value.Month, 2)
        Dim _Month_Palabra As String = Fx_Mes_Palabra(_Month)
        Dim _Day As String = numero_(DtpFecharevision.Value.Day, 2)

        Dim _Ruta_Archivador As String = AppPath() & "\Data\" & RutEmpresa & "\Archivador" '"\BkPost\Ult_" & _Tido & "_Bkp.xml"

        Dim _Ruta_Year As String = _Ruta_Archivador & "\" & _Year
        Dim _Ruta_Month As String = _Ruta_Year & "\" & _Month & " " & _Month_Palabra
        Dim _Ruta_Dia As String = _Ruta_Year & "\" & _Month & " " & _Month_Palabra & "\" & _Day
        Dim _Ruta_Archivo As String

        If Not Directory.Exists(_Ruta_Archivador) Then
            System.IO.Directory.CreateDirectory(_Ruta_Archivador)
        End If

        If Not Directory.Exists(_Ruta_Year) Then
            System.IO.Directory.CreateDirectory(_Ruta_Year)
        End If

        If Not Directory.Exists(_Ruta_Month) Then
            System.IO.Directory.CreateDirectory(_Ruta_Month)
        End If

        If Not Directory.Exists(_Ruta_Dia) Then
            System.IO.Directory.CreateDirectory(_Ruta_Dia)
        End If

        Dim _Fecha = Format(DtpFecharevision.Value, "yyyyMMdd")

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Demonio_Archivador Where Fecha < '" & _Fecha & "'"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Demonio_Archivador (Idmaeedo,Tido,Nudo,Fecha)
                        Select IDMAEEDO,TIDO,NUDO,FEEMDO From MAEEDO
                        Where FEEMDO = '" & _Fecha & "'
                        And IDMAEEDO Not In (Select Idmaeedo From " & _Global_BaseBk & "Zw_Demonio_Archivador Where Fecha = '" & _Fecha & "') And NUDONODEFI = 0"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Dim _Archivado As String = "And Archivado = 0"

        If _Incluir_Levantados Then
            _Archivado = String.Empty
        End If

        Dim _Ruta_Documentos As String = _Ruta_Dia & "\Documentos"

        If Not Directory.Exists(_Ruta_Documentos) Then
            System.IO.Directory.CreateDirectory(_Ruta_Documentos)
        End If

        Dim _Ruta_Pagos As String = _Ruta_Dia & "\Pagos"

        If Not Directory.Exists(_Ruta_Pagos) Then
            System.IO.Directory.CreateDirectory(_Ruta_Pagos)
        End If

        _Ruta_Pagos = _Ruta_Pagos & "\Pagos_" & _Fecha & ".xml"

        Consulta_sql = "Select * From MAEDPCE Where FEEMDP = '" & _Fecha & "'
                        Select Mdp.*,Isnull(Edo.TIDO,Mdp.TIDOPA),Isnull(Edo.NUDO,'') As NUDO From MAEDPCD Mdp 
                        Left Join MAEEDO Edo On Edo.IDMAEEDO = Mdp.IDRST
                        Where Mdp.LAHORA = '" & _Fecha & "'"

        Dim _Dsp As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql, True)
        _Dsp.Tables(0).TableName = "Maedpce"
        _Dsp.Tables(1).TableName = "Maedpcd"
        _Dsp.WriteXml(_Ruta_Pagos)


        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Demonio_Archivador 
                        Where Fecha = '" & _Fecha & "' " & _Archivado
        Dim _Tbl_Archivos As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim _Leyenda As String = _Tbl_Archivos.Rows.Count
        Dim _Contador = 0

        For Each _Fila As DataRow In _Tbl_Archivos.Rows

            Dim _Idmaeedo As Integer = _Fila.Item("Idmaeedo")
            Dim _Tido As String = _Fila.Item("Tido")
            Dim _Nudo As String = _Fila.Item("Nudo")

            Dim _Ruta_Tido As String = _Ruta_Documentos & "\" & _Tido

            If Not Directory.Exists(_Ruta_Tido) Then
                System.IO.Directory.CreateDirectory(_Ruta_Tido)
            End If

            _Ruta_Archivo = _Ruta_Tido & "\" & _Tido & "-" & _Nudo & ".xml"

            Consulta_sql = "Select * From MAEEDO Where IDMAEEDO = " & _Idmaeedo & "
                            Select * From MAEDDO Where IDMAEEDO = " & _Idmaeedo & "
                            Select * From MAEIMLI Where IDMAEEDO = " & _Idmaeedo & "
                            Select * From MAEDTLI Where IDMAEEDO = " & _Idmaeedo & "
                            Select * From MAEEDOOB Where IDMAEEDO = " & _Idmaeedo & "
                            Select * From MAEVEN Where IDMAEEDO = " & _Idmaeedo & "
                            Select * From MAEEN 
                                Inner Join MAEEDO On ENDO = KOEN And SUENDO = SUEN 
                                Where IDMAEEDO = " & _Idmaeedo

            Try

                Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql, True)

                _Ds.Tables(0).TableName = "Maeedo"
                _Ds.Tables(1).TableName = "Maeddo"
                _Ds.Tables(2).TableName = "Maeimli"
                _Ds.Tables(3).TableName = "Maedtli"
                _Ds.Tables(4).TableName = "Maeedoob"
                _Ds.Tables(5).TableName = "Maeven"
                _Ds.Tables(6).TableName = "Maeen"

                _Ds.WriteXml(_Ruta_Archivo)

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Demonio_Archivador Set Archivado = 1 Where Idmaeedo = " & _Idmaeedo
                _Sql.Ej_consulta_IDU(Consulta_sql)

            Catch ex As Exception

            End Try

            _Contador += 1
            _Leyenda = "Insertandos " & _Contador & " de " & _Tbl_Archivos.Rows.Count & ")..."
            Lbl_Archivador.Text = _Leyenda
            System.Windows.Forms.Application.DoEvents()

        Next

        Lbl_Archivador.Text = "Monitoreo archivador de documentos"

        Sb_Pausar(_Pausa.Play)

    End Sub

    Sub Sb_Procedimientos_Cierre_Masivo_Documentos(_Tido As String, _Dias As Integer, _Ejecutar As Boolean)

        If Not _Ejecutar Then
            Return
        End If

        Dim _Fecha As Date = DtpFecharevision.Value

        _Fecha = DateAdd(DateInterval.Day, -_Dias, _Fecha)

        Consulta_sql = My.Resources.Recursos_Demonio.SQLQuery_Cierrer_Docmuento
        Consulta_sql = Replace(Consulta_sql, "#Filtro#",
                       "Edo.EMPRESA = '" & ModEmpresa & "' And Edo.TIDO = '" & _Tido & "' And Edo.ESDO = '' And Edo.FEEMDO <= '" & Format(_Fecha, "yyyyMMdd") & "'")
        Consulta_sql = Replace(Consulta_sql, "#Campo_SUENDOFI#", "")
        Consulta_sql = Replace(Consulta_sql, "#Left_Join_MAEEN_ENDOFI_SUENDOFI#", "")
        Consulta_sql = Replace(Consulta_sql, "Isnull(Mae2.NOKOEN,'') As RAZON_FISICA,", "")
        Consulta_sql = Replace(Consulta_sql, "#Orden#", "")
        Consulta_sql = Replace(Consulta_sql, "#CantidadDoc#", "100")
        Consulta_sql = Replace(Consulta_sql, "Cast(0 As Bit) As Chk,", "Cast(1 As Bit) As Chk,")

        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        If _Tbl.Rows.Count Then

            Dim Fm As New Frm_BuscarDocumento_Mt
            Fm.Ocultar_Envio_Correos_Masivamente = True
            Fm.Lbl_Ver.Text = False
            Fm.BtnAceptar.Visible = True
            Fm.Pro_Sql_Query = Consulta_sql
            Fm.CmbCantFilas.Text = 100
            Fm.Pro_Pago_a_Documento = False
            Fm.Pro_Abrir_Seleccionado = False
            Fm.Seleccion_Multiple = True
            Fm.Abrir_Cerrar_Documentos_Compromiso = True
            Fm.Abrir_Documentos = False
            Fm.Cerrar_Documentos = True
            Fm.Cerrar_Documentos_Automaticamente = True
            Fm.Bar1.Enabled = False
            'Fm.ControlBox = False
            Fm.ShowDialog(Me)

        End If

    End Sub

    Private Sub Btn_ConfImpresora_Click(sender As Object, e As EventArgs) Handles Btn_Configurar.Click

        Sb_Pausar(_Pausa.Pausa)

        Dim _Row_Usuario_Autorizado As DataRow

        Dim FmP As New Frm_ValidarPermiso(Frm_ValidarPermiso.Tipo_Accion.Validar_Permiso, "Pick0011", True, False)
        FmP.Pro_Cerrar_Automaticamente = True
        FmP.ShowDialog(Me)
        Dim _Validar As Boolean = FmP.Pro_Permiso_Aceptado
        _Row_Usuario_Autorizado = FmP.Pro_RowUsuario
        FmP.Dispose()

        If _Validar Then

            Dim Fm As New Frm_Demonio_01_Conf_Local(_Row_Usuario_Autorizado.Item("KOFU"))
            Fm.ShowDialog(Me)
            Dim _Cambiar_Usuario_X_Defecto As Boolean = Fm.Cambiar_Usuario_X_Defecto
            Fm.Dispose()

            Sb_Load()

            If _Cambiar_Usuario_X_Defecto Then

                Me.Text = "Demonio para acciones automatizadas, V: [" & _Version_BkSpecialPrograms & "]"
                Lbl_Nombre_Equipo.Text = "Nombre equipo: " & _Nombre_Equipo
                Lbl_Modalidad.Text = "Modalidad: " & Modalidad & ", Sucursal: " & ModSucursal & ", Bodega: " & ModBodega

                _Segundos_Minimiza_Automatico = 60 * 2
                _Minimiza_Automatico = True

                Lbl_Estatus.Text = "Empresa: " & ModEmpresa & ", Modalidad: " & Modalidad & ", Usuario: " & FUNCIONARIO & ", Equipo: " & _Nombre_Equipo

                MessageBoxEx.Show(Me, "Usuario y modalidad cambiados para revisión", "Cambio de usuario", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        End If

        Sb_Pausar(_Pausa.Play)

    End Sub

    Private Sub Btn_Filtro_Doc_Prestashop_Click(sender As System.Object, e As System.EventArgs)
        Sb_Pausar(_Pausa.Pausa)
        Dim Fm As New Frm_Demonio_02_Conf_X_Estacion(Frm_Demonio_04_Conf_Impr_X_Funcionarios.Tipo_Configuracion.Prestashop)
        Fm.Pro_NombreEquipo = Pro_NombreEquipo
        Fm.ShowDialog(Me)
        If Fm.Pro_Grabar Then
            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Fm.Dispose()
        Sb_Pausar(_Pausa.Play)
    End Sub

    Function Fx_Prestashop_Actualizar_Precios(_Cadena_Conexion_MySql As String,
                                              _Nombre_Pagina As String,
                                              _Codigo As String,
                                              _Cod_Lista As String,
                                              _Row_Tabcodal As DataRow) As String

        Try

            Dim _Clas_Ps As New Class_MySQL(_Cadena_Conexion_MySql)
            Dim _Cant_Encontrados As Long = 0
            Dim Contador As Long = 0

            Dim _Mensaje As String

            'Consulta_sql = "Select Top 1 * From TABCODAL" & vbCrLf & _
            '               "Where KOEN = '" & _Codigo_Pagina & "' AND KOPR = '" & _Codigo & "'"
            'Dim _Row_Tabcodal As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If Not (_Row_Tabcodal Is Nothing) Then

                Dim _ID_Producto As String = Trim(_Row_Tabcodal.Item("KOPRAL"))

                Dim _Row_Precios As DataRow
                Dim _Row_Lista As DataRow

                Consulta_sql = "Select Top 1 * From TABPRE Where KOLT = '" & _Cod_Lista & "' And KOPR = '" & _Codigo & "'"
                _Row_Precios = _Sql.Fx_Get_DataRow(Consulta_sql)

                Consulta_sql = "Select Top 1 * From TABPP Where KOLT = '" & _Cod_Lista & "'"
                _Row_Lista = _Sql.Fx_Get_DataRow(Consulta_sql)

                Dim _Valor As Double = _Row_Precios.Item("PP01UD")
                Dim _Ecuacion As String = _Row_Precios.Item("ECUACION")
                Dim _Melt As String = _Row_Lista.Item("MELT")

                If Trim(_Ecuacion) = Trim(LCase(_Ecuacion)) Then

                    Dim _Tiene_C As Boolean = InStr(1, _Ecuacion, "<")
                    Dim _Tiene_Cor As Boolean = InStr(1, _Ecuacion, "[")

                    If Not _Tiene_C Then
                        If Not _Tiene_Cor Then

                            Dim _Campo_Precio
                            Dim _Campo_Ecuacion

                            'If _UnTrans = 1 Then
                            _Campo_Precio = "PP01UD"
                            _Campo_Ecuacion = "ECUACION"
                            'Else
                            '_Campo_Precio = "PP02UD"
                            '_Campo_Ecuacion = "ECUACIONU2"
                            'End If

                            _Valor = Fx_Precio_Formula_Random(_Row_Precios, _Campo_Precio, _Campo_Ecuacion, Nothing, True, "", 1, 1)

                            If _Melt = "B" Then
                                _Valor = Math.Round(_Valor / 1.19, 6)
                            End If

                        End If
                    End If
                End If

                '_Valor = 3000

                Consulta_sql = "Update ps_product_shop set price = " & De_Num_a_Tx_01(_Valor, False, 8) & vbCrLf &
                               "Where id_product = " & _ID_Producto.Trim
                If _Clas_Ps.Fx_Ej_consulta_IDU(Consulta_sql, False) Then

                    _Mensaje = "Tabla [ps_product] OK,"

                    Consulta_sql = "Update ps_product set price = " & De_Num_a_Tx_01(_Valor, False, 8) & vbCrLf &
                                   "Where id_product = " & _ID_Producto.Trim & vbCrLf
                    If _Clas_Ps.Fx_Ej_consulta_IDU(Consulta_sql, False) Then
                        _Mensaje += "Tabla [ps_product_shop] OK."
                    Else
                        _Mensaje = "Error!! al insertar Precio"
                    End If
                Else
                    _Mensaje = "Error!! al insertar Precio"
                End If

                _Mensaje = "Lista: " & _Cod_Lista & ", Precio: $ " & De_Num_a_Tx_01(_Valor, False, 6) & ", " & _Mensaje
            Else
                Return "No Aplica"
            End If

            Return _Mensaje
        Catch ex As Exception
            Return "Error!! al insertar Precio"
        End Try

    End Function

    Function Fx_Prestashop_Actualizar_Stock(_Cadena_Conexion_MySql As String,
                                            _Nombre_Pagina As String,
                                            _Codigo As String,
                                            _Row_Tabcodal As DataRow,
                                            _Max_Stock As Double) As String

        Try
            Dim _Clas_Ps As New Class_MySQL(_Cadena_Conexion_MySql)

            If Not (_Row_Tabcodal Is Nothing) Then

                Dim _ID_Producto As String = _Row_Tabcodal.Item("KOPRAL")
                Dim _Stock As Double = _Sql.Fx_Trae_Dato("MAEST", "SUM(STFI1-STDV1)", "KOPR = '" & _Codigo & "'")
                Dim _Stock_Total = _Stock

                If _Stock > _Max_Stock Then _Stock = _Max_Stock

                Consulta_sql = "Update ps_stock_available set quantity= " & De_Num_a_Tx_01(_Stock) & vbCrLf &
                               "Where id_product = " & _ID_Producto.Trim & vbCrLf

                If _Clas_Ps.Fx_Ej_consulta_IDU(Consulta_sql, False) Then
                    Return "Stock en Bodega: " & De_Num_a_Tx_01(_Stock_Total, False, 0) &
                           ", Stock grabado: " & De_Num_a_Tx_01(_Stock, 0) & "."
                Else
                    Return "Error!! al insertar Stock" '_Clas_Ps.Pro_Error & ". "
                End If
            Else
                Return "No Aplica."
            End If
        Catch ex As Exception
            Return "Error!! al insertar Stock"
        End Try

    End Function



    Private Sub Btn_Archivar_Documentos_Click(sender As Object, e As EventArgs) Handles Btn_Archivar_Documentos.Click
        Sb_Procedimiento_Archivar_Documentos(False)
    End Sub

    Private Sub Switch_Archivador_ValueChanged(sender As Object, e As EventArgs)

        If Switch_Archivador.Value Then
            If String.IsNullOrEmpty(_Cl_Archivador.Ruta_Archivador) Then
                MessageBoxEx.Show(Me, "Debe configurar el directorio de destino", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Switch_Archivador.Value = False
            End If
        End If

    End Sub

    Function Fx_Prestashop_Activar_Desactivar_Producto(_Cadena_Conexion_MySql As String,
                                                       _Codigo As String,
                                                       _Koen As String) As String

        'Dim _Error As String

        Try

            Dim _Clas_Ps As New Class_MySQL(_Cadena_Conexion_MySql)

            Dim _Tbl_Productos_Hermanos As DataTable = Fx_Tbl_Productos_Hermanos(_Codigo)

            For Each _Fila As DataRow In _Tbl_Productos_Hermanos.Rows

                Dim _Codigo2 As String = _Fila.Item("Codigo")
                'Dim _Stock As Double = _Fila.Item("Stock")
                'Dim _Importados As Boolean = _Fila.Item("Importados")
                Dim _active As Boolean = _Fila.Item("active")

                Consulta_sql = "Select Top 1 * From TABCODAL Where KOEN = '" & _Koen & "' And KOPR = '" & _Codigo2 & "'"
                Dim _Row_Tabcodal As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                If Not (_Row_Tabcodal Is Nothing) Then

                    Dim _id_product As String = _Row_Tabcodal.Item("KOPRAL")

                    Consulta_sql = "Update ps_product set active = b'" & Convert.ToInt32(_active) & "'" & vbCrLf &
                                   "Where id_product = " & _id_product.Trim

                    If _Clas_Ps.Fx_Ej_consulta_IDU(Consulta_sql, False) Then

                        Consulta_sql = "Update ps_product_shop set active = b'" & Convert.ToInt32(_active) & "'" & vbCrLf &
                                                           "Where id_product = " & _id_product.Trim

                        If _Clas_Ps.Fx_Ej_consulta_IDU(Consulta_sql, False) Then
                            'Return ""
                        Else
                            Return "Error!! al insertar Stock" '_Clas_Ps.Pro_Error & ". "
                        End If

                    Else
                        Return "Error!! al insertar Stock" '_Clas_Ps.Pro_Error & ". "
                    End If

                Else
                    Return "No Aplica."
                End If

            Next

        Catch ex As Exception
            Return "Error!! al insertar Stock"
        End Try

    End Function


    Function Fx_Tbl_Productos_Hermanos(_Codigo As String) As DataTable

        Dim _Nodo_Raiz_Asociados As Integer = _Global_Row_Configuracion_General.Item("Nodo_Raiz_Asociados")

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf &
                       "Where (Codigo = '" & _Codigo & "') AND (Para_filtro = 1)" & vbCrLf &
                       "And Codigo_Nodo In (Select Codigo_Nodo From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Nodo_Raiz = " & _Nodo_Raiz_Asociados & ")"

        Dim _Row_Nodo_Clasificaciones As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Codigo_Nodo As Integer

        If _Row_Nodo_Clasificaciones Is Nothing Then
            _Codigo_Nodo = 0
        Else
            _Codigo_Nodo = _Row_Nodo_Clasificaciones.Item("Codigo_Nodo")
        End If

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Codigo_Nodo = " & _Codigo_Nodo
        _Row_Nodo_Clasificaciones = _Sql.Fx_Get_DataRow(Consulta_sql)

        'Consulta_sql = "Select KOPR As Codigo,Cast(0 As Bit) As Importado,Cast(0 As Float) As Stock,Cast(0 As Bit) As active 
        '                From MAEPR Where KOPR In (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion" & Space(1) &
        '               "Where Codigo_Nodo = " & _Codigo_Nodo & " And Codigo_Nodo <> 0)"

        Consulta_sql = "Select Codigo,Cast(0 As Bit) As Importado,Cast(0 As Float) As Stock,Cast(0 As Bit) As active,Hermano 
                        From " & _Global_BaseBk & "Zw_Prod_Asociacion 
                        Where Codigo_Nodo = " & _Codigo_Nodo & " And Codigo_Nodo <> 0"

        Dim _Tbl_Productos_Hermanos As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim _Codigo_Nodo_Importados = 30106 ' Codigo_Nodo 04 IMPORTADOS

        For Each _Fila As DataRow In _Tbl_Productos_Hermanos.Rows

            Dim _Codigo2 As String = _Fila.Item("Codigo")
            Dim _Stock As Double = _Sql.Fx_Trae_Dato("MAEST", "SUM(STFI1)", "EMPRESA = '" & ModEmpresa & "' And KOPR = '" & _Codigo2 & "'")
            Dim _Importado = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Prod_Asociacion",
                                                      "Codigo_Nodo = " & _Codigo_Nodo_Importados & " And Codigo = '" & _Codigo2 & "'")

            _Fila.Item("Stock") = _Stock
            _Fila.Item("Importado") = Convert.ToBoolean(_Importado)

        Next

        For Each _Fila3 As DataRow In _Tbl_Productos_Hermanos.Rows

            Dim _Codigo3 As String = _Fila3.Item("Codigo")
            Dim _Importado3 As Boolean = _Fila3.Item("Importado")
            Dim _Stock3 As Boolean = (_Fila3.Item("Stock") > 0)
            Dim _Hermano3 As String = _Fila3.Item("Hermano")

            If _Importado3 And _Stock3 Then

                _Fila3.Item("active") = True

            Else

                _Fila3.Item("active") = True

                If Not String.IsNullOrEmpty(_Hermano3.Trim) Then

                    For Each _Fila4 As DataRow In _Tbl_Productos_Hermanos.Rows

                        Dim _Codigo4 As String = _Fila4.Item("Codigo")
                        Dim _Hermano4 As String = _Fila3.Item("Hermano")

                        If _Codigo3 <> _Codigo4 And _Hermano3 = _Codigo4 Then

                            Dim _Importado4 As Boolean = _Fila4.Item("Importado")
                            Dim _Stock4 As Boolean = (_Fila4.Item("Stock") > 0)

                            If _Importado4 And _Stock4 Then
                                _Fila3.Item("active") = False
                            End If

                        End If

                    Next

                End If

            End If

        Next

        Return _Tbl_Productos_Hermanos

    End Function

    Function Fx_Prestashop_Traer_Orden(_Cadena_Conexion_MySql As String,
                                       _Codigo_Pagina As String,
                                       _Id_orders As Integer) As String

        Try

            Dim _Clas_Ps As New Class_MySQL(_Cadena_Conexion_MySql)

            Consulta_sql = "Select id_order,reference,total_paid,date_add From ps_orders Where id_order = " & _Id_orders
            Dim _Tbl_ps_orders As DataTable = _Clas_Ps.Fx_Get_Datatable(Consulta_sql)

            If Not String.IsNullOrEmpty(_Clas_Ps.Pro_Error) Then Return _Clas_Ps.Pro_Error

            Consulta_sql = "Select id_order_detail,id_order,product_id,product_reference,product_name,product_quantity,product_price,reduction_percent," &
                           "unit_price_tax_excl,unit_price_tax_incl,total_price_tax_excl,total_price_tax_incl,original_product_price 
                            From ps_order_detail Where id_order = " & _Id_orders
            Dim _Tbl_ps_orders_detail As DataTable = _Clas_Ps.Fx_Get_Datatable(Consulta_sql)

            If Not String.IsNullOrEmpty(_Clas_Ps.Pro_Error) Then Return _Clas_Ps.Pro_Error

            Consulta_sql = "Select Imp.* From ps_order_detail_tax Imp 
                            Inner join ps_order_detail Det On Det.id_order_detail = Imp.id_order_detail
                            Where id_order = " & _Id_orders
            Dim _Tbl_ps_orders_detail_tax As DataTable = _Clas_Ps.Fx_Get_Datatable(Consulta_sql)

            If Not String.IsNullOrEmpty(_Clas_Ps.Pro_Error) Then Return _Clas_Ps.Pro_Error

            If _Tbl_ps_orders.Rows.Count Then

                Dim _Reference As String = _Tbl_ps_orders.Rows(0).Item("reference")
                Dim _Date_add As String = Format(_Tbl_ps_orders.Rows(0).Item("date_add"), "yyyyMMdd hh:mm")
                Dim _Total_paid As String = De_Num_a_Tx_01(_Tbl_ps_orders.Rows(0).Item("total_paid"), False, 5)

                Dim _Sql_Query = String.Empty


                _Sql_Query = "Delete " & _Global_BaseBk & "Zw_PrestaShop_orders Where Codigo_Pagina = '" & _Codigo_Pagina & "' And Id_order = " & _Id_orders & " --And Reference = 'Error!'
                              Insert Into " & _Global_BaseBk & "Zw_PrestaShop_orders (Codigo_Pagina,Id_order,Reference,Date_add,Total_paid) " &
                              "Values ('" & _Codigo_Pagina & "'," & _Id_orders & ",'" & _Reference & "','" & _Date_add & "'," & _Total_paid & ")" & vbCrLf & vbCrLf

                '_Sql_Query = "Update " & _Global_BaseBk & "Zw_PrestaShop_orders Set 
                '              Reference = '" & _Reference & "', Date_add = '" & _Date_add & "', Total_paid = " & _Total_paid & "
                '              Where Codigo_Pagina = '" & _Codigo_Pagina & "' And Id_order = " & _Id_orders & vbCrLf & vbCrLf


                For Each _Fila As DataRow In _Tbl_ps_orders_detail.Rows

                    Dim _Id_order_detail = _Fila.Item("id_order_detail")
                    Dim _Id_order = _Fila.Item("id_order")
                    Dim _Product_id = _Fila.Item("product_id")
                    Dim _Product_reference = _Fila.Item("product_reference")
                    Dim _Product_name = _Fila.Item("product_name")
                    Dim _Product_quantity = De_Num_a_Tx_01(_Fila.Item("product_quantity"), False, 5)
                    Dim _Product_price = De_Num_a_Tx_01(_Fila.Item("product_price"), False, 5)
                    Dim _Reduction_percent = De_Num_a_Tx_01(_Fila.Item("reduction_percent"), False, 5)
                    Dim _Unit_price_tax_excl = De_Num_a_Tx_01(_Fila.Item("unit_price_tax_excl"), False, 5)
                    Dim _Unit_price_tax_incl = De_Num_a_Tx_01(_Fila.Item("unit_price_tax_incl"), False, 5)
                    Dim _Total_price_tax_excl = De_Num_a_Tx_01(_Fila.Item("total_price_tax_excl"), False, 5)
                    Dim _Total_price_tax_incl = De_Num_a_Tx_01(_Fila.Item("total_price_tax_incl"), False, 5)
                    Dim _Original_product_price = De_Num_a_Tx_01(_Fila.Item("original_product_price"), False, 5)

                    _Sql_Query += "Insert Into " & _Global_BaseBk & "Zw_PrestaShop_orders_detail (Codigo_Pagina,Id_order_detail,Id_order,Product_id," &
                                  "Product_reference,Product_name,Product_quantity,Product_price,Reduction_percent,Unit_price_tax_excl," &
                                  "Unit_price_tax_incl,Total_price_tax_excl,Total_price_tax_incl,Original_product_price) 
                                   Values ('" & _Codigo_Pagina & "'," & _Id_order_detail & "," & _Id_order & "," & _Product_id & "," &
                                  "'" & _Product_reference & "','" & _Product_name & "'," & _Product_quantity & "," & _Product_price & "," & _Reduction_percent &
                                  "," & _Unit_price_tax_excl & "," &
                                  _Unit_price_tax_incl & "," & _Total_price_tax_excl & "," & _Total_price_tax_incl & "," & _Original_product_price & ")" & vbCrLf

                Next

                _Sql_Query += vbCrLf

                For Each _Fila_tax As DataRow In _Tbl_ps_orders_detail_tax.Rows

                    Dim _Id_order_detail = _Fila_tax.Item("id_order_detail")
                    Dim _Id_tax = _Fila_tax.Item("id_tax")
                    Dim _Unit_amount = De_Num_a_Tx_01(_Fila_tax.Item("unit_amount"), False, 5)
                    Dim _Total_amount = De_Num_a_Tx_01(_Fila_tax.Item("total_amount"), False, 5)

                    _Sql_Query += "Insert Into " & _Global_BaseBk & "Zw_PrestaShop_orders_detail_tax (Codigo_Pagina,Id_order_detail,Id_tax,Unit_amount,Total_amount) 
                                   Values ('" & _Codigo_Pagina & "'," & _Id_order_detail & "," & _Id_tax & "," & _Unit_amount & "," & _Total_amount & ")"

                Next

                If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(_Sql_Query) Then
                    Return ""
                Else
                    Return _Sql.Pro_Error
                End If

            Else

                Return "No se encontro el documento"

            End If


        Catch ex As Exception
            Return "Error!! al insertar documento " & ex.Message
        End Try

    End Function

    Private Sub Btn_Reenviar_Con_Errores_Prestashop_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Reenviar_Con_Errores_Prestashop.Click
        Sb_Reenviar_Productos_Con_Error_Prestashop()
    End Sub

    Sub Sb_Reenviar_Productos_Con_Error_Prestashop()

        Dim _Fecha As Date

        Try
            Dim _Consulta = MessageBoxEx.Show(Me, "¿Reenviar productos solo del día (Yes), de otras fechas (No)?",
                                              "Reenviar productos", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            If _Consulta = Windows.Forms.DialogResult.Yes Then
                _Fecha = DtpFecharevision.Value
            ElseIf _Consulta = Windows.Forms.DialogResult.No Then

                Dim _Fecha_S As String = FormatDateTime(DtpFecharevision.Value, DateFormat.ShortDate)
                Dim _Aceptar As Boolean

                _Aceptar = InputBox_Bk(Me, "Digite la fecha", "Reenviar productos",
                                 _Fecha_S,
                                 False, _Tipo_Mayus_Minus.Normal, 0,
                                 True, _Tipo_Imagen.Texto, False, _Tipo_Caracter.Cualquier_caracter, False)

                If _Aceptar Then
                    _Fecha = _Fecha_S
                End If
            Else
                Return
            End If

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Demonio_Prestashop Set" & Space(1) &
                           "Revisado = 1, Error = 0, Log_Error = '',Fecha = '" & Format(_Fecha, "yyyyMMdd") & "'" & vbCrLf &
                           "Where NombreEquipo = '" & _Nombre_Equipo & "' And Error = 1 And Fecha = '" & Format(_Fecha, "yyyyMMdd") & "'"
            If _Sql.Ej_consulta_IDU(Consulta_sql, False) Then
                MessageBoxEx.Show(Me, "Los productos seran reprocesados en la proxima revisión", "Reenviar productos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBoxEx.Show(Me, "Validación", "Fecha invalida", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Sb_Reenviar_Productos_Con_Error_Prestashop()
        End Try

    End Sub

    Private Sub Btn_LogError_Prestashop_Click(sender As System.Object, e As System.EventArgs) Handles Btn_LogError_Prestashop.Click

        Consulta_sql = "SELECT  Id,NombreEquipo,Idmaeedo,Idmaeddo,Codigo,Descripcion,Fecha,Revisado,Log_Error,Error" & vbCrLf &
                       "FROM " & _Global_BaseBk & "Zw_Demonio_Prestashop" & vbCrLf &
                       "Where Error = 1 And NombreEquipo = '" & _Nombre_Equipo & "'"

        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)
        ExportarTabla_JetExcel_Tabla(_Tbl, Me, "Errores Prestashop")

        Btn_LogError_Prestashop.Visible = False
        Btn_LogError_Prestashop.Enabled = False

    End Sub

    Sub Sb_Imprimir_Voucher_Tarjeta(_Idmaeedo As Integer,
                                    ByRef _LogError As String,
                                    _Impresora As String,
                                    _Imprimir_Voucher_Original_Transbank As Boolean)

        If _Imprimir_Voucher_Original_Transbank Then
            Dim _Cl_Voucher As New Clas_Imprimir_Voucher
            _Cl_Voucher.Fx_Imprimir_Voucher(Me, _Idmaeedo, _Impresora)
        Else

            Consulta_sql = "SELECT TOP 1 Id,OperationId,FechaHora_Inicio,FechaHora_Fin,posid,posuser,Venta_Generada,Cancelado_Por_Usuario," &
                      "Cancelado_Por_Tiempo,Tido,Nudo,Pagado_CashDro,Pagado_Transbank,Pagado_Random,Idmaeedo,Tipo_De_Pago,Monto," &
                      "Impreso,Log_Error,Status_Tarjeta, Respuesta_Tarjeta" & vbCrLf &
                      "FROM " & _Global_BaseBk & "Zw_CashDro_Operaciones" & vbCrLf &
                      "Where Idmaeedo = " & _Idmaeedo & " And Tipo_De_Pago = 'TJV'"

            Dim _Row_Tarjeta_Cashdro As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If Not (_Row_Tarjeta_Cashdro Is Nothing) Then

                Consulta_sql = "SELECT TOP 1  * FROM MAEDPCE" & vbCrLf &
                               "WHERE TIDP = 'TJV' AND IDMAEDPCE In" & Space(1) &
                               "(SELECT TOP 1 IDMAEDPCE FROM MAEDPCD WHERE ARCHIRST = 'MAEEDO' AND IDRST = " & _Idmaeedo & ")" & vbCrLf &
                               "ORDER BY IDMAEDPCE DESC"
                Dim _Row_Maedpce As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                If (_Row_Tarjeta_Cashdro Is Nothing) Or (_Row_Maedpce Is Nothing) Then
                    _LogError += "Documento de pago no existe en MAEDPCE"
                    Return
                End If

                Dim _NombreFormato As String
                Dim _Row_Formato As DataRow

                Dim _Idmaedpce = _Row_Maedpce.Item("IDMAEDPCE")
                Dim _Tidp = _Row_Maedpce.Item("TIDP")
                Dim _Tip = _Tidp
                Dim _Nudp = _Row_Maedpce.Item("NUDP")
                Dim _Emdp = Trim(_Row_Maedpce.Item("EMDP"))

                Consulta_sql = "Select Top 1 * From TABENDP WHERE TIDPEN = '" & Mid(_Tidp, 1, 2) & "' AND KOENDP = '" & _Emdp & "'"
                Dim _Row_Tabendp As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                If Not (_Row_Tabendp Is Nothing) Then
                    Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Format_01" & vbCrLf &
                                              "Where TipoDoc = 'TJV' And Emdp = '" & _Emdp & "'"
                    _NombreFormato = Trim(_Row_Tabendp.Item("KOENDP")) & "-" & Trim(_Row_Tabendp.Item("NOKOENDP")) '000069764215

                    _Row_Formato = _Sql.Fx_Get_DataRow(Consulta_sql)

                    Dim _Imprimir As New Clas_Imprimir_Documento(_Idmaedpce,
                                                                 _Tidp,
                                                                 _NombreFormato,
                                                                 _Tip & "-" & _Nudp,
                                                                 False, _Emdp, "")

                    _Imprimir.Pro_Impresora = _Impresora
                    _Imprimir.Fx_Imprimir_Documento(Nothing, False, False)
                    _LogError += _Imprimir.Pro_Ultimo_Error

                Else
                    _LogError += "No fue posible imprimir el Voucher de TRANSBANK, no existe tipo de pago (" & _Emdp & ") " & _Row_Tarjeta_Cashdro.Item("Respuesta_Tarjeta")
                End If

            End If

        End If

    End Sub

    Private Sub Frm_Demonio_01_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        If Not _Minimizar Then

            Sb_Load()

            If Switch_Monitoreo_doc_emitidos.Value Or
               Switch_Correos.Value Or
               Switch_Cola_Impresion.Value Or
               Switch_Solicitud_Productos_Bodega.Value Or
               Switch_Poswii.Value Or
               Switch_Prestashop.Value Or
               Switch_Cons_Stock.Value Then

                Dim _Validar As Boolean

                Dim Fm As New Frm_ValidarPermiso(Frm_ValidarPermiso.Tipo_Accion.Validar_Permiso, "Pick0011", True, False)
                Fm.Pro_Cerrar_Automaticamente = True
                Fm.ShowDialog(Me)
                _Validar = Fm.Pro_Permiso_Aceptado
                Fm.Dispose()

                If Not _Validar Then
                    e.Cancel = True
                End If

            End If

        End If

    End Sub

    Private Sub Frm_Demonio_01_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        'If Me.WindowState = FormWindowState.Minimized Then
        '    _Minimizar = True
        '    Me.Close()
        'End If
    End Sub

    Sub Sb_Llenar_Variables_Etiquetas_Documento(ByRef _Texto As String, _Idmaeedo As Integer)

        If Convert.ToBoolean(_Idmaeedo) Then

            Consulta_sql = Replace(My.Resources.Recursos_Ver_Documento.Traer_Documento_Random, "#Idmaeedo#", _Idmaeedo)
            Dim _Datos_Documento = _Sql.Fx_Get_DataSet(Consulta_sql)

            Dim _Row_Encabezado = _Datos_Documento.Tables(0).Rows(0)
            'Dim _TblDetalle = _Datos_Documento.Tables(1)
            'Dim _Row_Observaciones = _Datos_Documento.Tables(2).Rows(0)

            _Texto = Replace(_Texto, "<Doc_Tido>", Fx_Parametro_Vs_Variable("<Doc_Tido>", _Row_Encabezado))
            _Texto = Replace(_Texto, "<Doc_Nudo>", Fx_Parametro_Vs_Variable("<Doc_Nudo>", _Row_Encabezado))
            _Texto = Replace(_Texto, "<Doc_Razon>", Fx_Parametro_Vs_Variable("<Doc_Razon>", _Row_Encabezado))
            _Texto = Replace(_Texto, "<Doc_Feemdo>", Fx_Parametro_Vs_Variable("<Doc_Feemdo>", _Row_Encabezado))
            _Texto = Replace(_Texto, "<Doc_Vabrdo>", Fx_Parametro_Vs_Variable("<Doc_Vabrdo>", _Row_Encabezado))

        End If

    End Sub

    Private Function Fx_Parametro_Vs_Variable(_Parametro As String, _Row As DataRow) As String

        Dim _Valor = "???"

        Try

            Dim _Vl = Split(Replace(Replace(_Parametro, "<", ""), ">", ""), ",")

            Dim _Campo = UCase(Replace(_Vl(0), "Doc_", ""))

            Select Case _Parametro

                Case "<Doc_Tido>",
                     "<Doc_Nudo>",
                     "<Doc_Razon>"

                    _Valor = NuloPorNro(_Row.Item(_Campo), "")

                Case "<Doc_Vanedo,0>"

                    _Valor = FormatCurrency(_Row.Item(_Campo), 0)

                Case "<Doc_Vanedo,1>"

                    _Valor = FormatCurrency(_Row.Item(_Campo), 1)

                Case "<Doc_Vanedo,2>"

                    _Valor = FormatCurrency(_Row.Item(_Campo), 2)

                Case "<Doc_Vabrdo>"

                    _Valor = FormatCurrency(_Row.Item(_Campo), 0)

                Case "<Doc_Feemdo>", "<Doc_Feemdo,1>"

                    _Valor = FormatDateTime(_Row.Item(_Campo), DateFormat.ShortDate)

                Case "<Doc_Feemdo,2>"

                    _Valor = FormatDateTime(_Row.Item(_Campo), DateFormat.LongDate)

            End Select

            Return _Valor

        Catch ex As Exception
            _Valor = ex.Message & "... Error"
            'MsgBox("Error", vbOK, ex.Message)
        End Try

    End Function

    Private Sub Frm_Demonio_01_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        Sb_Pausar(_Pausa.Pausa)

    End Sub

    Sub Sb_Programar_Timer()
        ' Establecer la hora programada para la tarea (ejemplo: 14:30)
        Dim horaProgramada As DateTime = DateTime.Today.Add(New TimeSpan(17, 60, 0))

        ' Calcular el tiempo restante hasta la hora programada
        Dim tiempoRestante As TimeSpan = horaProgramada - DateTime.Now

        If tiempoRestante.TotalMilliseconds < 0 Then
            ' La hora programada ya ha pasado
            Console.WriteLine("La hora programada ya ha pasado.")
            Return
        End If

        ' Crear un temporizador con el tiempo restante como intervalo
        _Timer_HH1 = New Timer(AddressOf EjecutarTarea, Nothing, tiempoRestante, Timeout.InfiniteTimeSpan)

        ' Mantener el programa en ejecución
        Console.ReadLine()
    End Sub

    Sub EjecutarTarea(state As Object)
        ' Aquí puedes colocar el código de la tarea que deseas ejecutar
        Console.WriteLine("¡Tarea ejecutada!")

        ' Reiniciar el temporizador para la próxima ejecución
        Dim diaSemanaProgramado As DayOfWeek = DayOfWeek.Thursday ' Establecer el día de la semana programado
        Dim horaProgramada As TimeSpan = New TimeSpan(17, 60, 0) ' Establecer la hora programada
        Dim tiempoRestante As TimeSpan = SiguienteDiaProgramado(diaSemanaProgramado, horaProgramada) - DateTime.Now
        _Timer_HH1.Change(tiempoRestante, Timeout.InfiniteTimeSpan)
    End Sub

    Function SiguienteDiaProgramado(diaSemanaProgramado As DayOfWeek, horaProgramada As TimeSpan) As DateTime
        Dim fechaActual As DateTime = DateTime.Now.Date
        Dim siguienteDia As Integer = (diaSemanaProgramado - fechaActual.DayOfWeek + 7) Mod 7
        Dim fechaProgramada As DateTime = fechaActual.AddDays(siguienteDia).Date.Add(horaProgramada)
        Return fechaProgramada
    End Function


End Class
