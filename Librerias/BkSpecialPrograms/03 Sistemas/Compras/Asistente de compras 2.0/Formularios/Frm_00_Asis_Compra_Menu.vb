Imports DevComponents.DotNetBar

Public Class Frm_00_Asis_Compra_Menu

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String


    Dim _Directorio_Informe = (AppPath() & "\Data\" & RutEmpresa & "\Asistente_Compras")

    Dim _DstCompras As New DatosCompra
    Public Tipo_Informe As String

    Dim _TblPasoInforme = "Zw_InfCompras01" & FUNCIONARIO
    Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

    Dim Cancelar As Boolean
    Dim NombreProveedor As String

    Public _Filtro_Productos As String
    Public _DsFiltros As New DsFiltros

    Dim _TblFiltroProductos As DataTable
    Dim _TblFiltroProductosExcluidos As DataTable

    Dim _Tbl_Filtro_Productos As DataTable
    Dim _Tbl_Filtro_Super_Familias As DataTable
    Dim _Tbl_Filtro_Marcas As DataTable
    Dim _Tbl_Filtro_Rubro As DataTable
    Dim _Tbl_Filtro_Clalibpr As DataTable
    Dim _Tbl_Filtro_Zonas As DataTable

    Dim _TblBodCompra As DataTable
    Dim _TblBodVenta As DataTable
    Dim _TblBodReabastecen As DataTable

    Dim _Filtro_Productos_Todos As Boolean
    Dim _Filtro_Marcas_Todas As Boolean
    Dim _Filtro_Super_Familias_Todas As Boolean
    Dim _Filtro_Rubro_Todas As Boolean
    Dim _Filtro_Clalibpr_Todas As Boolean
    Dim _Filtro_Zonas_Todas As Boolean
    Dim _Filtro_Bodegas_Todas As Boolean
    Dim _Filtro_Bodegas_Est_Vta_Todas As Boolean

    Dim _RowProveedor As DataRow
    Dim _RowProveedor_Especial As DataRow
    Dim _RowParametros As DataRow

    Dim _Cmb_Padre_Asociacion_Productos As String
    Dim _Cmb_Proyeccion_Metodo_Abastecer As String
    Dim _Input_Proyeccion_Tiempo_a_Abastecer As Integer
    Dim _Cmb_Proyeccion_Tiempo_Reposicion As String
    Dim _Input_Proyeccion_Tiempo_Reposicion As Integer
    Dim _Rdb_Proyeccion_Rotacion_Diaria As Boolean
    Dim _Rdb_Proyeccion_Rotacion_Efectiva As Boolean
    Dim _Input_Proyeccion_Redondeo As Integer
    Dim _Chk_Quitar_Ventas_Calzadas As Boolean

    Dim _Rdb_Agrupar_x_Asociados As Boolean
    Dim _Rdb_Agrupar_x_Reemplazos As Boolean
    Dim _Cmb_Nodo_Raiz_Asociados As String
    Dim _TblFiltroProductos_Proveedor As DataTable
    Dim _Cancelar As Boolean

    Public Property Accion_Automatica As Boolean
    Public Property Auto_GenerarAutomaticamenteOCCProveedorStar As Boolean
    Public Property Auto_GenerarAutomaticamenteNVI As Boolean
    Public Property Auto_GenerarAutomaticamenteOCCProveedores As Boolean
    Public Property Auto_CorreoCc As String
    Public Property Modalidad_Estudio As String
    Public Property Modo_ConfAuto As Boolean
    Public Property Modo_OCC As Boolean
    Public Property Modo_NVI As Boolean

    'Dim'_LiteSql As Class_SQLite

    Public Sub New(_Modalidad_Estudio As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        'Dim _Directorio_Base_LiteSql As String = Application.StartupPath & "\Data\Configuracion_Local\BK_lite.db"

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Modalidad_Estudio = _Modalidad_Estudio

        Sb_Cargar_Combos()

        'Sb_Parametros_Informe_Conf_Local(True)
        _Modo_OCC = True
        Sb_Parametros_Informe_Sql(False)

        _Filtro_Marcas_Todas = True
        _Filtro_Super_Familias_Todas = True
        _Filtro_Rubro_Todas = True
        _Filtro_Clalibpr_Todas = True
        _Filtro_Zonas_Todas = True
        _Filtro_Bodegas_Todas = True

        STabConfiguracion.SelectedTabIndex = 0

    End Sub

    Private Sub Frm_00_AsisCompra_Menu_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If IsNothing(_TblFiltroProductos) Then _TblFiltroProductos = _DsFiltros.Tables("Filtro")

        AddHandler Rdb_Productos_Con_Movimientos_De_Venta.CheckedChanged, AddressOf Sb_Habilitar_Deshabilitar_RDB
        AddHandler Rdb_Productos_Proveedor.CheckedChanged, AddressOf Sb_Habilitar_Deshabilitar_RDB
        AddHandler Rdb_Productos_Ranking.CheckedChanged, AddressOf Sb_Habilitar_Deshabilitar_RDB
        AddHandler Rdb_Productos_Seleccionar.CheckedChanged, AddressOf Sb_Habilitar_Deshabilitar_RDB
        AddHandler Rdb_Productos_Todos.CheckedChanged, AddressOf Sb_Habilitar_Deshabilitar_RDB
        AddHandler Rdb_Productos_Vendidos_Los_Ultimos_Dias.CheckedChanged, AddressOf Sb_Habilitar_Deshabilitar_RDB

        Sb_Habilitar_Deshabilitar_RDB()
        Input_Productos_Ranking.MaxValue = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Prod_Ranking", "")

        Sb_Color_Botones_Barra(Bar)

        If _Accion_Automatica Then
            Timer_Ejecucion_Automatica.Start()
            Bar.Enabled = False
        End If

        Tab_Costos_OCC.Visible = (_Modo_OCC Or _Modo_ConfAuto)
        Tab_Automatizacion.Visible = False

        If _Modo_OCC Then
            Me.Text += " MODO OCC"
        End If

        If _Modo_NVI Then
            Chk_IncluirUltCXprov.Checked = False
            Chk_IncluirUltCXprov.Visible = False
            Chk_Mostrar_Solo_Stock_Critico.Checked = False
            Chk_Mostrar_Solo_Stock_Critico.Enabled = False
            Cmb_Tipo_de_compra.SelectedValue = "Nacional"
            Cmb_Tipo_de_compra.Enabled = False
            Layaut_UlProdXProv.Visible = False
            Me.Text += " MODO NVI"
            Tab_ConexionExterna.Visible = False
            Tab_Automatizacion.Visible = True
        End If

        If _Modo_ConfAuto Then
            Tab_Automatizacion.Visible = True
            BtnProcesarInf.Visible = False
            Btn_Imprimir_Maestra.Visible = False
        End If

        _Filtro_Productos_Todos = True
        Btn_GrabarConfiguracion.Visible = _Modo_ConfAuto

    End Sub

    Sub Sb_Cargar_Combos()

        Dim _Arr_Filtro(,) As String = {{"1", "Hoy"},
                                        {"7", "7 días:"},
                                        {"14", "14 días"},
                                        {"21", "21 días"},
                                        {"30", "30 días"},
                                        {"90", "3 Meses"},
                                        {"180", "6 Meses"},
                                        {"365", "1 Año"}}
        Sb_Llenar_Combos(_Arr_Filtro, Cmb_Cantidad_Dias_Ultima_Venta)
        Cmb_Cantidad_Dias_Ultima_Venta.SelectedValue = "7"

        Dim _Arr_Dias_Meses(,) As String = {{"1", "días"},
                                           {"30", "meses"}}
        Sb_Llenar_Combos(_Arr_Dias_Meses, Cmb_Metodo_Abastecer_Dias_Meses)
        Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue = "1"

        Sb_Llenar_Combos(_Arr_Dias_Meses, Cmb_Tiempo_Reposicion_Dias_Meses)
        Cmb_Tiempo_Reposicion_Dias_Meses.SelectedValue = "1"

        Dim _Arr_Tipo_Compra(,) As String = {{"Nacional", "Nacional 1"},
                                             {"Nacional2", "Nacional 2"},
                                             {"Exterior", "Comercio exterior"}}
        Sb_Llenar_Combos(_Arr_Tipo_Compra, Cmb_Tipo_de_compra)
        Cmb_Tipo_de_compra.SelectedValue = "Nacional"

        Dim _Arr_Tipo_Documento(,) As String = {{"GRC", "Guía recepción compra (GRC)"},
                                            {"OCC", "Orden de compra (OCC)"},
                                            {"FCC", "Factura de compra (FCC)"}}
        Sb_Llenar_Combos(_Arr_Tipo_Documento, Cmb_Documento_Compra)
        Cmb_Documento_Compra.SelectedValue = "GRC"

        caract_combo(Cmb_Lista_de_costos)
        Consulta_sql = "Select '' As Padre,'' As Hijo Union Select KOLT As Padre,KOLT+'-'+NOKOLT As Hijo From TABPP Where TILT = 'C'"
        Cmb_Lista_de_costos.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        Cmb_Lista_de_costos.SelectedValue = ""

    End Sub

#Region "FUNCIONES"

    Private Sub PressEnter(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If

        ' Si se pulsa la tecla Intro, pasar al siguiente
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            'If e.KeyChar = ChrW(Keys.Return) Then
            e.Handled = True
        ElseIf e.KeyChar = ","c Then
            ' si se pulsa la coma se convertirá en punto
            e.Handled = True
            SendKeys.Send(".")
        ElseIf e.KeyChar = "-"c Then
            e.Handled = True
            SendKeys.Send("")
        End If
    End Sub

    'Sub Sb_Parametros_Revisar_Sqlite(_Eliminar_Todo As Boolean)

    '    'Consulta_sql = "Select * From Tbl_Prm_Informes"
    '    'Dim _Tbl As DataTable ='_LiteSql.Fx_Get_Tablas(Consulta_sql)

    '    If _Eliminar_Todo Then
    '        Consulta_sql = "Delete From Tbl_Prm_Informes Where Informe = 'Compras_Asistente'"
    '        '_LiteSql.Ej_consulta_IDU(Consulta_sql)
    '    End If

    '    Dim _FechaHoy As Date = FormatDateTime(FechaDelServidor, DateFormat.ShortDate)
    '    Dim _Fecha_Hoy = Format(_FechaHoy, "dd-MM-yyyy")
    '    With _RowParametros


    '        'SELECCIONAR PRODUCTOS
    '        '   Todos
    '        '_LiteSql.Sb_Parametro_Informe_Sqlite(Rdb_Productos_Todos, "Compras_Asistente", Rdb_Productos_Todos.Name,
    '        'Class_SQLite.Enum_Type._Boolean, Rdb_Productos_Todos.Checked)

    '        '   Vendidos los ultimos, 7, 30 ,60 dias. etc
    '        '_LiteSql.Sb_Parametro_Informe_Sqlite(Rdb_Productos_Vendidos_Los_Ultimos_Dias, "Compras_Asistente",
    '        ' Rdb_Productos_Vendidos_Los_Ultimos_Dias.Name, Class_SQLite.Enum_Type._Boolean, Rdb_Productos_Vendidos_Los_Ultimos_Dias.Checked)
    '        '_LiteSql.Sb_Parametro_Informe_Sqlite(Cmb_Cantidad_Dias_Ultima_Venta, "Compras_Asistente",
    '        'Cmb_Cantidad_Dias_Ultima_Venta.Name, Class_SQLite.Enum_Type._ComboBox, Cmb_Cantidad_Dias_Ultima_Venta.SelectedValue)

    '        '   Productos con mov. venta entre fechas
    '        '_LiteSql.Sb_Parametro_Informe_Sqlite(Rdb_Productos_Con_Movimientos_De_Venta, "Compras_Asistente",
    '        'Rdb_Productos_Con_Movimientos_De_Venta.Name, Class_SQLite.Enum_Type._Boolean, Rdb_Productos_Con_Movimientos_De_Venta.Checked)
    '        '_LiteSql.Sb_Parametro_Informe_Sqlite(Dtp_Fecha_Movimientos_Desde, "Compras_Asistente",
    '        'Dtp_Fecha_Movimientos_Desde.Name, Class_SQLite.Enum_Type._Date, Dtp_Fecha_Movimientos_Desde.Value)
    '        '_LiteSql.Sb_Parametro_Informe_Sqlite(Dtp_Fecha_Movimientos_Hasta, "Compras_Asistente",
    '        'Dtp_Fecha_Movimientos_Hasta.Name, Class_SQLite.Enum_Type._Date, Dtp_Fecha_Movimientos_Hasta.Value)

    '        '   Seleccionar productos
    '        '_LiteSql.Sb_Parametro_Informe_Sqlite(Rdb_Productos_Seleccionar, "Compras_Asistente",
    '        'Rdb_Productos_Seleccionar.Name, Class_SQLite.Enum_Type._Boolean, Rdb_Productos_Seleccionar.Checked)

    '        '   Seleccionar productos por familias, marcas, etc...
    '        '_LiteSql.Sb_Parametro_Informe_Sqlite(Rdb_Productos_Familias_Marcas_Etc, "Compras_Asistente",
    '        'Rdb_Productos_Familias_Marcas_Etc.Name, Class_SQLite.Enum_Type._Boolean, Rdb_Productos_Familias_Marcas_Etc.Checked)

    '        '   Productos del Ranking
    '        '_LiteSql.Sb_Parametro_Informe_Sqlite(Rdb_Productos_Ranking, "Compras_Asistente",
    '        'Rdb_Productos_Ranking.Name, Class_SQLite.Enum_Type._Boolean, Rdb_Productos_Ranking.Checked)
    '        '_LiteSql.Sb_Parametro_Informe_Sqlite(Input_Productos_Ranking, "Compras_Asistente",
    '        'Input_Productos_Ranking.Name, Class_SQLite.Enum_Type._Double, Input_Productos_Ranking.Value)

    '        '   Productos comprados a un proveedor en especifico
    '        '_LiteSql.Sb_Parametro_Informe_Sqlite(Rdb_Productos_Proveedor, "Compras_Asistente",
    '        'Rdb_Productos_Proveedor.Name, Class_SQLite.Enum_Type._Boolean, Rdb_Productos_Proveedor.Checked)

    '        Dim _Koen As String
    '        Dim _Suen As String

    '        If (_RowProveedor Is Nothing) Then

    '            '_Koen ='_LiteSql.Fx_Trae_Dato("Tbl_Prm_Informes", "Valor", "Informe = 'Compras_Asistente' And Campo = 'Koen'")
    '            '_Suen ='_LiteSql.Fx_Trae_Dato("Tbl_Prm_Informes", "Valor", "Informe = 'Compras_Asistente' And Campo = 'Suen'")

    '            Txt_Proveedor.Text = String.Empty
    '            _RowProveedor = Fx_Traer_Datos_Entidad(_Koen, _Suen)

    '        End If

    '        If Not (_RowProveedor Is Nothing) Then
    '            _Koen = Trim(_RowProveedor.Item("KOEN"))
    '            _Suen = Trim(_RowProveedor.Item("SUEN"))
    '            Txt_Proveedor.Text = Trim(_RowProveedor.Item("KOEN")) & " - " & Trim(_RowProveedor.Item("NOKOEN"))
    '            '_LiteSql.Sb_Parametro_Informe_Sqlite(Nothing, "Compras_Asistente", "Koen", Class_SQLite.Enum_Type._String, _Koen)
    '            '_LiteSql.Sb_Parametro_Informe_Sqlite(Nothing, "Compras_Asistente", "Suen", Class_SQLite.Enum_Type._String, _Suen)
    '        End If

    '        '   Seleccionar si el proveedor es entidad fisica
    '        '_LiteSql.Sb_Parametro_Informe_Sqlite(Chk_Ent_Fisica, "Compras_Asistente",
    '        'Chk_Ent_Fisica.Name, Class_SQLite.Enum_Type._Boolean, Chk_Ent_Fisica.Checked)

    '        '   Seleccionar si el proveedor es entidad fisica
    '        '_LiteSql.Sb_Parametro_Informe_Sqlite(Chk_Traer_Productos_De_Reemplazo, "Compras_Asistente",
    '        'Chk_Traer_Productos_De_Reemplazo.Name, Class_SQLite.Enum_Type._Boolean, Chk_Traer_Productos_De_Reemplazo.Checked)

    '        '   Tipo de compra, Nacional / Comercio Exterior
    '        '_LiteSql.Sb_Parametro_Informe_Sqlite(Cmb_Tipo_de_compra, "Compras_Asistente",
    '        'Cmb_Tipo_de_compra.Name, Class_SQLite.Enum_Type._ComboBox, Cmb_Tipo_de_compra.SelectedValue)

    '        '   Tiempo para aprobicionamiento
    '        '_LiteSql.Sb_Parametro_Informe_Sqlite(Cmb_Metodo_Abastecer_Dias_Meses, "Compras_Asistente", Cmb_Metodo_Abastecer_Dias_Meses.Name,
    '        'Class_SQLite.Enum_Type._ComboBox, Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue)
    '        '_LiteSql.Sb_Parametro_Informe_Sqlite(Input_Dias_a_Abastecer, "Compras_Asistente",
    '        'Input_Dias_a_Abastecer.Name, Class_SQLite.Enum_Type._Double, Input_Dias_a_Abastecer.Value)

    '        '   Tiempo de reposición (Lead Time)
    '        '_LiteSql.Sb_Parametro_Informe_Sqlite(Cmb_Tiempo_Reposicion_Dias_Meses, "Compras_Asistente",
    '        'Cmb_Tiempo_Reposicion_Dias_Meses.Name, Class_SQLite.Enum_Type._ComboBox, Cmb_Tiempo_Reposicion_Dias_Meses.SelectedValue)
    '        '_LiteSql.Sb_Parametro_Informe_Sqlite(Input_Tiempo_Reposicion, "Compras_Asistente",
    '        'Input_Tiempo_Reposicion.Name, Class_SQLite.Enum_Type._Double, Input_Tiempo_Reposicion.Value)

    '        '   Considera Sabado
    '        '_LiteSql.Sb_Parametro_Informe_Sqlite(Chk_Sabado, "Compras_Asistente",
    '        'Chk_Sabado.Name, Class_SQLite.Enum_Type._Boolean, Chk_Sabado.Checked)
    '        '   Considera Domingo
    '        '_LiteSql.Sb_Parametro_Informe_Sqlite(Chk_Domingo, "Compras_Asistente",
    '        'Chk_Domingo.Name, Class_SQLite.Enum_Type._Boolean, Chk_Domingo.Checked)

    '        '   Unidad de compra UD1
    '        '_LiteSql.Sb_Parametro_Informe_Sqlite(Rdb_Ud1_Compra, "Compras_Asistente",
    '        'Rdb_Ud1_Compra.Name, Class_SQLite.Enum_Type._Boolean, Rdb_Ud1_Compra.Checked)
    '        '   Unidad de compra UD1
    '        '_LiteSql.Sb_Parametro_Informe_Sqlite(Rdb_Ud2_Compra, "Compras_Asistente",
    '        'Rdb_Ud2_Compra.Name, Class_SQLite.Enum_Type._Boolean, Rdb_Ud2_Compra.Checked)


    '        '   Costos desde ultimo documento segun seleccion
    '        '_LiteSql.Sb_Parametro_Informe_Sqlite(Rd_Costo_Lista_Proveedor, "Compras_Asistente",
    '        'Rd_Costo_Lista_Proveedor.Name, Class_SQLite.Enum_Type._Boolean, Rd_Costo_Lista_Proveedor.Checked)
    '        '   Costos desde ultimo documento segun seleccion
    '        '_LiteSql.Sb_Parametro_Informe_Sqlite(Rd_Costo_Ultimo_Documento_Seleccionado, "Compras_Asistente",
    '        'Rd_Costo_Ultimo_Documento_Seleccionado.Name, Class_SQLite.Enum_Type._Boolean, Rd_Costo_Ultimo_Documento_Seleccionado.Checked)
    '        '   Costos de la lista del proveedor
    '        '_LiteSql.Sb_Parametro_Informe_Sqlite(Cmb_Documento_Compra, "Compras_Asistente",
    '        'Cmb_Documento_Compra.Name, Class_SQLite.Enum_Type._ComboBox, Cmb_Documento_Compra.SelectedValue)
    '        '   Costos de la lista del proveedor
    '        '_LiteSql.Sb_Parametro_Informe_Sqlite(Dtp_Fecha_Tope_Proveedores_Automaticos, "Compras_Asistente",
    '        'Dtp_Fecha_Tope_Proveedores_Automaticos.Name, Class_SQLite.Enum_Type._Date, Dtp_Fecha_Tope_Proveedores_Automaticos.Value)



    '        '   Ticket Quitar Productos sin rotacion 
    '        '_LiteSql.Sb_Parametro_Informe_Sqlite(Chk_Sacar_Productos_Sin_Rotacion, "Compras_Asistente",
    '        'Chk_Sacar_Productos_Sin_Rotacion.Name, Class_SQLite.Enum_Type._Boolean, Chk_Sacar_Productos_Sin_Rotacion.Checked)
    '        '   Ticket Restar Stock bodega
    '        '_LiteSql.Sb_Parametro_Informe_Sqlite(Chk_Restar_Stok_Bodega, "Compras_Asistente",
    '        'Chk_Restar_Stok_Bodega.Name, Class_SQLite.Enum_Type._Boolean, Chk_Restar_Stok_Bodega.Checked)
    '        '   Ticket Quitar bloqueados compra
    '        '_LiteSql.Sb_Parametro_Informe_Sqlite(Chk_Quitar_Bloqueados_Compra, "Compras_Asistente",
    '        'Chk_Quitar_Bloqueados_Compra.Name, Class_SQLite.Enum_Type._Boolean, Chk_Quitar_Bloqueados_Compra.Checked)
    '        '   Ticket Quitar con OCC o NVI
    '        '_LiteSql.Sb_Parametro_Informe_Sqlite(Chk_No_Considera_Con_Stock_Pedido_OCC_NVI, "Compras_Asistente",
    '        'Chk_No_Considera_Con_Stock_Pedido_OCC_NVI.Name, Class_SQLite.Enum_Type._Boolean, Chk_No_Considera_Con_Stock_Pedido_OCC_NVI.Checked)
    '        '   Ticket Solo Stock critico
    '        '_LiteSql.Sb_Parametro_Informe_Sqlite(Chk_Mostrar_Solo_Stock_Critico, "Compras_Asistente",
    '        'Chk_Mostrar_Solo_Stock_Critico.Name, Class_SQLite.Enum_Type._Boolean, Chk_Mostrar_Solo_Stock_Critico.Checked)


    '        '_Filtro_Bodegas_Est_Vta_Todas = True

    '        '   Venta promedio entre fechas
    '        '_LiteSql.Sb_Parametro_Informe_Sqlite(Rdb_Rango_Fechas_Vta_Promedio, "Compras_Asistente",
    '        'Rdb_Rango_Fechas_Vta_Promedio.Name, Class_SQLite.Enum_Type._Boolean, Rdb_Rango_Fechas_Vta_Promedio.Checked)
    '        '_LiteSql.Sb_Parametro_Informe_Sqlite(Dtp_Fecha_Vta_Desde, "Compras_Asistente",
    '        'Dtp_Fecha_Vta_Desde.Name, Class_SQLite.Enum_Type._Date, Dtp_Fecha_Vta_Desde.Value)
    '        '_LiteSql.Sb_Parametro_Informe_Sqlite(Dtp_Fecha_Vta_Hasta, "Compras_Asistente",
    '        'Dtp_Fecha_Vta_Hasta.Name, Class_SQLite.Enum_Type._Date, Dtp_Fecha_Vta_Hasta.Value)

    '        '   Venta promedio en meses
    '        '_LiteSql.Sb_Parametro_Informe_Sqlite(Rdb_Rango_Meses_Vta_Promedio, "Compras_Asistente",
    '        'Rdb_Rango_Meses_Vta_Promedio.Name, Class_SQLite.Enum_Type._Boolean, Rdb_Rango_Meses_Vta_Promedio.Checked)
    '        '_LiteSql.Sb_Parametro_Informe_Sqlite(Input_Ultimos_Meses_Vta_Promedio, "Compras_Asistente",
    '        'Input_Ultimos_Meses_Vta_Promedio.Name, Class_SQLite.Enum_Type._Double, Input_Ultimos_Meses_Vta_Promedio.Value)

    '        '   Sumar Rotacion Hermanos, agrupar las rotaciones en un solo producto
    '        '_LiteSql.Sb_Parametro_Informe_Sqlite(Chk_Sumar_Rotacion_Hermanos, "Compras_Asistente",
    '        'Chk_Sumar_Rotacion_Hermanos.Name, Class_SQLite.Enum_Type._Boolean, Chk_Sumar_Rotacion_Hermanos.Checked)

    '        '   Rotacion con entidades excluidas
    '        '_LiteSql.Sb_Parametro_Informe_Sqlite(Chk_Rotacion_Con_Ent_Excluidas, "Compras_Asistente",
    '        'Chk_Rotacion_Con_Ent_Excluidas.Name, Class_SQLite.Enum_Type._Boolean, Chk_Rotacion_Con_Ent_Excluidas.Checked)


    '        'If Not _Eliminar_Todo Then
    '        'Consulta_sql = "Select Chk,Codigo,Descripcion From Tbl_Filtros_Busqueda Where Informe = 'Compras_Asistente' And Filtro = 'Bodegas_Stock'"
    '        '_TblBodCompra ='_LiteSql.Fx_Get_Tablas(Consulta_sql)

    '        'Consulta_sql = "Select Chk,Codigo,Descripcion From Tbl_Filtros_Busqueda Where Informe = 'Compras_Asistente' And Filtro = 'Bodegas_Rotacion_Vta'"
    '        '_TblBodVenta ='_LiteSql.Fx_Get_Tablas(Consulta_sql)
    '        'End If

    '    End With

    'End Sub

    Sub Sb_Parametros_Informe_Sql(_Actualizar As Boolean)

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Tmp_Prm_Informes Set Modalidad = '" & Modalidad_Estudio & "'
                        Where Funcionario = '" & FUNCIONARIO & "' And Informe = 'Compras_Asistente'" & Space(1) &
                       "And NombreEquipo = '" & _NombreEquipo & "' And Modalidad = ''"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        If _Actualizar Then

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Tmp_Prm_Informes" & vbCrLf &
                           "Where Funcionario = '" & FUNCIONARIO & "' And Informe = 'Compras_Asistente'" & Space(1) &
                           "And Grupo = 'Seleccion_Productos' And NombreEquipo = '" & _NombreEquipo & "' And Modalidad = '" & Modalidad_Estudio & "'"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Consulta_sql = "Delete From " & _Global_BaseBk & "Zw_Tmp_Filtros_Busqueda" & vbCrLf &
                           "Where Funcionario = '" & FUNCIONARIO & "' And Informe = 'Compras_Asistente'" & Space(1) &
                           "And NombreEquipo = '" & _NombreEquipo & "' And Modalidad = ''"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            _Sql.Sb_Actualizar_Filtro_Tmp(_TblBodCompra, "Compras_Asistente", "Bodegas_Stock", Modalidad_Estudio)
            _Sql.Sb_Actualizar_Filtro_Tmp(_TblBodVenta, "Compras_Asistente", "Bodegas_Rotacion_Vta", Modalidad_Estudio)
            _Sql.Sb_Actualizar_Filtro_Tmp(_TblBodReabastecen, "Compras_Asistente", "Bodegas_Reabastecen", Modalidad_Estudio)
            _Sql.Sb_Actualizar_Filtro_Tmp(_TblFiltroProductosExcluidos, "Compras_Asistente", "Productos_Excluidos", Modalidad_Estudio)

            If Rdb_Productos_Seleccionar.Checked Then
                _Sql.Sb_Actualizar_Filtro_Tmp(_TblFiltroProductos, "Compras_Asistente", "Productos_Seleccionados", Modalidad_Estudio)
            End If

        End If

        If _Actualizar Then

            If Not (Rdb_Productos_Proveedor.Checked) Then

                _RowProveedor = Nothing
                Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Tmp_Prm_Informes" & vbCrLf &
                               "Where NombreEquipo = '" & _NombreEquipo & "' And Funcionario = '" & FUNCIONARIO & "' And Informe = 'Compras_Asistente' And Campo In ('Koen','Suen') And Modalidad = '" & Modalidad_Estudio & "'"
                _Sql.Ej_consulta_IDU(Consulta_sql)

            End If

        End If

        Dim _FechaHoy As Date = FormatDateTime(FechaDelServidor, DateFormat.ShortDate)
        Dim _Fecha_Hoy = Format(_FechaHoy, "dd-MM-yyyy")

        'SELECCIONAR PRODUCTOS
        '   Todos
        _Sql.Sb_Parametro_Informe_Sql(Rdb_Productos_Todos, "Compras_Asistente", Rdb_Productos_Todos.Name,
                                                 Class_SQLite.Enum_Type._Boolean, Rdb_Productos_Todos.Checked, _Actualizar, "Seleccion_Productos")

        'Rdb_Productos_Todos.Checked = CBool(_Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", Rdb_Productos_Todos.Name, "Valor", True))
        '   Vendidos los ultimos, 7, 30 ,60 dias. etc
        _Sql.Sb_Parametro_Informe_Sql(Rdb_Productos_Vendidos_Los_Ultimos_Dias, "Compras_Asistente",
                                             Rdb_Productos_Vendidos_Los_Ultimos_Dias.Name, Class_SQLite.Enum_Type._Boolean, Rdb_Productos_Vendidos_Los_Ultimos_Dias.Checked, _Actualizar, "Seleccion_Productos")
        _Sql.Sb_Parametro_Informe_Sql(Cmb_Cantidad_Dias_Ultima_Venta, "Compras_Asistente",
                                             Cmb_Cantidad_Dias_Ultima_Venta.Name, Class_SQLite.Enum_Type._ComboBox, Cmb_Cantidad_Dias_Ultima_Venta.SelectedValue, _Actualizar, "Seleccion_Productos")

        '   Productos con mov. venta entre fechas
        _Sql.Sb_Parametro_Informe_Sql(Rdb_Productos_Con_Movimientos_De_Venta, "Compras_Asistente",
                                             Rdb_Productos_Con_Movimientos_De_Venta.Name, Class_SQLite.Enum_Type._Boolean, Rdb_Productos_Con_Movimientos_De_Venta.Checked, _Actualizar, "Seleccion_Productos")
        _Sql.Sb_Parametro_Informe_Sql(Dtp_Fecha_Movimientos_Desde, "Compras_Asistente",
                                             Dtp_Fecha_Movimientos_Desde.Name, Class_SQLite.Enum_Type._Date, Dtp_Fecha_Movimientos_Desde.Value, _Actualizar, "Seleccion_Productos")
        _Sql.Sb_Parametro_Informe_Sql(Dtp_Fecha_Movimientos_Hasta, "Compras_Asistente",
                                             Dtp_Fecha_Movimientos_Hasta.Name, Class_SQLite.Enum_Type._Date, Dtp_Fecha_Movimientos_Hasta.Value, _Actualizar, "Seleccion_Productos")

        '   Seleccionar productos
        _Sql.Sb_Parametro_Informe_Sql(Rdb_Productos_Seleccionar, "Compras_Asistente",
                                             Rdb_Productos_Seleccionar.Name, Class_SQLite.Enum_Type._Boolean, Rdb_Productos_Seleccionar.Checked, _Actualizar, "Seleccion_Productos")

        '   Seleccionar productos por familias, marcas, etc...
        _Sql.Sb_Parametro_Informe_Sql(Rdb_Productos_Familias_Marcas_Etc, "Compras_Asistente",
                                             Rdb_Productos_Familias_Marcas_Etc.Name, Class_SQLite.Enum_Type._Boolean, Rdb_Productos_Familias_Marcas_Etc.Checked, _Actualizar, "Seleccion_Productos")

        '   Productos del Ranking
        _Sql.Sb_Parametro_Informe_Sql(Rdb_Productos_Ranking, "Compras_Asistente",
                                             Rdb_Productos_Ranking.Name, Class_SQLite.Enum_Type._Boolean, Rdb_Productos_Ranking.Checked, _Actualizar, "Seleccion_Productos")
        _Sql.Sb_Parametro_Informe_Sql(Input_Productos_Ranking, "Compras_Asistente",
                                             Input_Productos_Ranking.Name, Class_SQLite.Enum_Type._Double, Input_Productos_Ranking.Value, _Actualizar, "Seleccion_Productos")

        '   Productos comprados a un proveedor en especifico
        _Sql.Sb_Parametro_Informe_Sql(Rdb_Productos_Proveedor, "Compras_Asistente",
                                             Rdb_Productos_Proveedor.Name, Class_SQLite.Enum_Type._Boolean, Rdb_Productos_Proveedor.Checked, _Actualizar, "Seleccion_Productos")

        '   Solo provedores con código alternativo
        _Sql.Sb_Parametro_Informe_Sql(Chk_Solo_Proveedores_CodAlternativo, "Compras_Asistente",
                                             Chk_Solo_Proveedores_CodAlternativo.Name, Class_SQLite.Enum_Type._Boolean, Chk_Solo_Proveedores_CodAlternativo.Checked, _Actualizar, "Seleccion_Productos")


        Dim _Koen As String
        Dim _Suen As String

        If (_RowProveedor Is Nothing) Then

            _Koen = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor",
                                      "Informe = 'Compras_Asistente' And Campo = 'Koen' And NombreEquipo = '" & _NombreEquipo & "' And Funcionario = '" & FUNCIONARIO & "' And Modalidad = '" & Modalidad_Estudio & "'")
            _Suen = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor",
                                      "Informe = 'Compras_Asistente' And Campo = 'Suen' And NombreEquipo = '" & _NombreEquipo & "' And Funcionario = '" & FUNCIONARIO & "' And Modalidad = '" & Modalidad_Estudio & "'")

            Txt_Proveedor.Text = String.Empty
            _RowProveedor = Fx_Traer_Datos_Entidad(_Koen, _Suen)

        End If

        If Not (_RowProveedor Is Nothing) Then

            If Rdb_Productos_Proveedor.Checked Then

                _Filtro_Productos_Todos = True

                Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Tmp_Prm_Informes" & vbCrLf &
                               "Where Funcionario = '" & FUNCIONARIO & "' And Informe = 'Compras_Asistente' And Campo In ('Koen','Suen') And Modalidad = '" & Modalidad_Estudio & "'"
                _Sql.Ej_consulta_IDU(Consulta_sql)

                _Koen = Trim(_RowProveedor.Item("KOEN"))
                _Suen = Trim(_RowProveedor.Item("SUEN"))

                Txt_Proveedor.Text = Trim(_RowProveedor.Item("KOEN")) & " - " & Trim(_RowProveedor.Item("NOKOEN"))

                _Sql.Sb_Parametro_Informe_Sql(Nothing, "Compras_Asistente", "Koen", Class_SQLite.Enum_Type._String, _Koen, _Actualizar, "Seleccion_Productos")
                _Sql.Sb_Parametro_Informe_Sql(Nothing, "Compras_Asistente", "Suen", Class_SQLite.Enum_Type._String, _Suen, _Actualizar, "Seleccion_Productos")

                Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Entidades" & vbCrLf &
                                "Where CodEntidad = '" & _Koen & "' And CodSucEntidad = '" & _Suen & "'"
                Dim _Row_Entidades As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)


                If Not IsNothing(_Row_Entidades) Then

                    If Not _Actualizar Then

                        Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue = NuloPorNro(_Row_Entidades.Item("Metodo_Abastecer_Dias_Meses"), 1)
                        Cmb_Tiempo_Reposicion_Dias_Meses.SelectedValue = NuloPorNro(_Row_Entidades.Item("Tiempo_Reposicion_Dias_Meses"), 1)

                        Input_Dias_a_Abastecer.Value = _Row_Entidades.Item("Dias_a_Abastecer")
                        Input_Tiempo_Reposicion.Value = _Row_Entidades.Item("Tiempo_Reposicion")

                    End If

                End If

                If _Actualizar Then

                    If IsNothing(_Row_Entidades) Then

                        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Entidades (CodEntidad,CodSucEntidad,Libera_NVV) Values ('" & _Koen & "','" & _Suen & "',0)" & vbCrLf &
                                       "Select * From " & _Global_BaseBk & "Zw_Entidades where CodEntidad = '" & _Koen & "' And CodSucEntidad = '" & _Suen & "'"
                        _Row_Entidades = _Sql.Fx_Get_DataRow(Consulta_sql)

                    End If

                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_Entidades Set " & vbCrLf &
                               "Metodo_Abastecer_Dias_Meses = " & Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue & "," &
                               "Dias_a_Abastecer = " & Input_Dias_a_Abastecer.Value & "," &
                               "Tiempo_Reposicion_Dias_Meses = " & Cmb_Tiempo_Reposicion_Dias_Meses.SelectedValue & "," &
                               "Tiempo_Reposicion = " & Input_Tiempo_Reposicion.Value & vbCrLf &
                               "Where CodEntidad = '" & _Koen & "' And CodSucEntidad = '" & _Suen & "'"
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                End If

            End If

        End If

        '   Seleccionar si el proveedor es entidad fisica
        _Sql.Sb_Parametro_Informe_Sql(Chk_Ent_Fisica, "Compras_Asistente",
                                             Chk_Ent_Fisica.Name, Class_SQLite.Enum_Type._Boolean, Chk_Ent_Fisica.Checked, _Actualizar)

        '   Seleccionar si el proveedor es entidad fisica
        _Sql.Sb_Parametro_Informe_Sql(Chk_Traer_Productos_De_Reemplazo, "Compras_Asistente",
                                             Chk_Traer_Productos_De_Reemplazo.Name, Class_SQLite.Enum_Type._Boolean, Chk_Traer_Productos_De_Reemplazo.Checked, _Actualizar)

        If _Modo_OCC Then
            '   Tipo de compra, Nacional / Comercio Exterior
            _Sql.Sb_Parametro_Informe_Sql(Cmb_Tipo_de_compra, "Compras_Asistente",
                                             Cmb_Tipo_de_compra.Name, Class_SQLite.Enum_Type._ComboBox, Cmb_Tipo_de_compra.SelectedValue, _Actualizar)
        End If

        If Not Rdb_Productos_Proveedor.Checked Then

            '   Tiempo para aprobicionamiento
            _Sql.Sb_Parametro_Informe_Sql(Cmb_Metodo_Abastecer_Dias_Meses, "Compras_Asistente", Cmb_Metodo_Abastecer_Dias_Meses.Name,
                                                 Class_SQLite.Enum_Type._ComboBox, Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue, _Actualizar)
            _Sql.Sb_Parametro_Informe_Sql(Input_Dias_a_Abastecer, "Compras_Asistente",
                                                 Input_Dias_a_Abastecer.Name, Class_SQLite.Enum_Type._Double, Input_Dias_a_Abastecer.Value, _Actualizar)

            '   Tiempo de reposición (Lead Time, _Actualizar)
            _Sql.Sb_Parametro_Informe_Sql(Cmb_Tiempo_Reposicion_Dias_Meses, "Compras_Asistente",
                                                 Cmb_Tiempo_Reposicion_Dias_Meses.Name, Class_SQLite.Enum_Type._ComboBox, Cmb_Tiempo_Reposicion_Dias_Meses.SelectedValue, _Actualizar)
            _Sql.Sb_Parametro_Informe_Sql(Input_Tiempo_Reposicion, "Compras_Asistente",
                                                 Input_Tiempo_Reposicion.Name, Class_SQLite.Enum_Type._Double, Input_Tiempo_Reposicion.Value, _Actualizar)

        End If

        '   Considera Sabado
        _Sql.Sb_Parametro_Informe_Sql(Chk_Sabado, "Compras_Asistente",
                                             Chk_Sabado.Name, Class_SQLite.Enum_Type._Boolean, Chk_Sabado.Checked, _Actualizar)
        '   Considera Domingo
        _Sql.Sb_Parametro_Informe_Sql(Chk_Domingo, "Compras_Asistente",
                                             Chk_Domingo.Name, Class_SQLite.Enum_Type._Boolean, Chk_Domingo.Checked, _Actualizar)

        '   Unidad de compra UD1
        _Sql.Sb_Parametro_Informe_Sql(Rdb_Ud1_Compra, "Compras_Asistente",
                                             Rdb_Ud1_Compra.Name, Class_SQLite.Enum_Type._Boolean, Rdb_Ud1_Compra.Checked, _Actualizar)
        '   Unidad de compra UD1
        _Sql.Sb_Parametro_Informe_Sql(Rdb_Ud2_Compra, "Compras_Asistente",
                                             Rdb_Ud2_Compra.Name, Class_SQLite.Enum_Type._Boolean, Rdb_Ud2_Compra.Checked, _Actualizar)


        '   Costos desde ultimo documento segun seleccion
        _Sql.Sb_Parametro_Informe_Sql(Rd_Costo_Lista_Proveedor, "Compras_Asistente",
                                             Rd_Costo_Lista_Proveedor.Name, Class_SQLite.Enum_Type._Boolean, Rd_Costo_Lista_Proveedor.Checked, _Actualizar)
        '   Costos desde ultimo documento segun seleccion
        _Sql.Sb_Parametro_Informe_Sql(Rd_Costo_Ultimo_Documento_Seleccionado, "Compras_Asistente",
                                             Rd_Costo_Ultimo_Documento_Seleccionado.Name, Class_SQLite.Enum_Type._Boolean, Rd_Costo_Ultimo_Documento_Seleccionado.Checked, _Actualizar)

        '   Costos de la lista del proveedor
        If Not IsNothing(Cmb_Documento_Compra.SelectedValue) Then
            _Sql.Sb_Parametro_Informe_Sql(Cmb_Documento_Compra, "Compras_Asistente",
                                             Cmb_Documento_Compra.Name, Class_SQLite.Enum_Type._ComboBox, Cmb_Documento_Compra.SelectedValue, _Actualizar)
        End If


        Dtp_Fecha_Tope_Proveedores_Automaticos.Value = DateAdd(DateInterval.Month, -Input_FechaTopeBusquedaProveedores.Value, Now.Date)

        '   Costos de la lista del proveedor
        _Sql.Sb_Parametro_Informe_Sql(Dtp_Fecha_Tope_Proveedores_Automaticos, "Compras_Asistente",
                                             Dtp_Fecha_Tope_Proveedores_Automaticos.Name, Class_SQLite.Enum_Type._Date, Dtp_Fecha_Tope_Proveedores_Automaticos.Value, _Actualizar)

        _Sql.Sb_Parametro_Informe_Sql(Input_FechaTopeBusquedaProveedores, "Compras_Asistente",
                                             Input_FechaTopeBusquedaProveedores.Name, Class_SQLite.Enum_Type._Double, Input_FechaTopeBusquedaProveedores.Value, _Actualizar)


        ''   Ticket Traer Cod. Alternativos desde Bakapp
        '_Sql.Sb_Parametro_Informe_Sql(Chk_CodAlt_desde_LcBakapp, "Compras_Asistente",
        '                                     Chk_CodAlt_desde_LcBakapp.Name, Class_SQLite.Enum_Type._Boolean, Chk_CodAlt_desde_LcBakapp.Checked, _Actualizar)


        '   Ticket Quitar Productos sin rotacion 
        _Sql.Sb_Parametro_Informe_Sql(Chk_Sacar_Productos_Sin_Rotacion, "Compras_Asistente",
                                             Chk_Sacar_Productos_Sin_Rotacion.Name, Class_SQLite.Enum_Type._Boolean, Chk_Sacar_Productos_Sin_Rotacion.Checked, _Actualizar)
        '   Ticket Restar Stock bodega
        _Sql.Sb_Parametro_Informe_Sql(Chk_Restar_Stok_Bodega, "Compras_Asistente",
                                             Chk_Restar_Stok_Bodega.Name, Class_SQLite.Enum_Type._Boolean, Chk_Restar_Stok_Bodega.Checked, _Actualizar)
        '   Ticket Restar Stock pedido NVI
        _Sql.Sb_Parametro_Informe_Sql(Chk_Restar_Stock_PedidoNvi, "Compras_Asistente",
                                             Chk_Restar_Stock_PedidoNvi.Name, Class_SQLite.Enum_Type._Boolean, Chk_Restar_Stock_PedidoNvi.Checked, _Actualizar)

        '   Ticket Restar Stock en transito GTI
        _Sql.Sb_Parametro_Informe_Sql(Chk_Restar_Stock_TransitoGti, "Compras_Asistente",
                                             Chk_Restar_Stock_TransitoGti.Name, Class_SQLite.Enum_Type._Boolean, Chk_Restar_Stock_TransitoGti.Checked, _Actualizar)


        '   Ticket Restar Stock pedido OCC
        _Sql.Sb_Parametro_Informe_Sql(Chk_Restar_Stock_PedidoOcc, "Compras_Asistente",
                                             Chk_Restar_Stock_PedidoOcc.Name, Class_SQLite.Enum_Type._Boolean, Chk_Restar_Stock_PedidoOcc.Checked, _Actualizar)

        '   Ticket Quitar bloqueados compra
        _Sql.Sb_Parametro_Informe_Sql(Chk_Quitar_Bloqueados_Compra, "Compras_Asistente",
                                             Chk_Quitar_Bloqueados_Compra.Name, Class_SQLite.Enum_Type._Boolean, Chk_Quitar_Bloqueados_Compra.Checked, _Actualizar)
        '   Ticket Quitar con OCC o NVI
        _Sql.Sb_Parametro_Informe_Sql(Chk_No_Considera_Con_Stock_Pedido_OCC_NVI, "Compras_Asistente",
                                             Chk_No_Considera_Con_Stock_Pedido_OCC_NVI.Name, Class_SQLite.Enum_Type._Boolean, Chk_No_Considera_Con_Stock_Pedido_OCC_NVI.Checked, _Actualizar)

        If _Modo_OCC Then
            '   Ticket Solo Stock critico
            _Sql.Sb_Parametro_Informe_Sql(Chk_Mostrar_Solo_Stock_Critico, "Compras_Asistente",
                                             Chk_Mostrar_Solo_Stock_Critico.Name, Class_SQLite.Enum_Type._Boolean, Chk_Mostrar_Solo_Stock_Critico.Checked, _Actualizar)
        End If

        '   Ticket Procesar de Uno en Uno
        _Sql.Sb_Parametro_Informe_Sql(Chk_Procesar_Uno_A_Uno, "Compras_Asistente",
                                             Chk_Procesar_Uno_A_Uno.Name, Class_SQLite.Enum_Type._Boolean, Chk_Procesar_Uno_A_Uno.Checked, _Actualizar)


        _Filtro_Bodegas_Est_Vta_Todas = False 'True

        '   Venta promedio entre fechas
        _Sql.Sb_Parametro_Informe_Sql(Rdb_Rango_Fechas_Vta_Promedio, "Compras_Asistente",
                                             Rdb_Rango_Fechas_Vta_Promedio.Name, Class_SQLite.Enum_Type._Boolean, Rdb_Rango_Fechas_Vta_Promedio.Checked, _Actualizar)
        _Sql.Sb_Parametro_Informe_Sql(Dtp_Fecha_Vta_Desde, "Compras_Asistente",
                                             Dtp_Fecha_Vta_Desde.Name, Class_SQLite.Enum_Type._Date, Dtp_Fecha_Vta_Desde.Value, _Actualizar)
        _Sql.Sb_Parametro_Informe_Sql(Dtp_Fecha_Vta_Hasta, "Compras_Asistente",
                                             Dtp_Fecha_Vta_Hasta.Name, Class_SQLite.Enum_Type._Date, Dtp_Fecha_Vta_Hasta.Value, _Actualizar)

        '   Venta promedio en meses
        _Sql.Sb_Parametro_Informe_Sql(Rdb_Rango_Meses_Vta_Promedio, "Compras_Asistente",
                                                 Rdb_Rango_Meses_Vta_Promedio.Name, Class_SQLite.Enum_Type._Boolean, Rdb_Rango_Meses_Vta_Promedio.Checked, _Actualizar)

        _Sql.Sb_Parametro_Informe_Sql(Input_Ultimos_Meses_Vta_Promedio, "Compras_Asistente",
                                                 Input_Ultimos_Meses_Vta_Promedio.Name, Class_SQLite.Enum_Type._Double, Input_Ultimos_Meses_Vta_Promedio.Value, _Actualizar)

        '   Sumar Rotacion Hermanos, agrupar las rotaciones en un solo producto
        _Sql.Sb_Parametro_Informe_Sql(Chk_Sumar_Rotacion_Hermanos, "Compras_Asistente",
                                                 Chk_Sumar_Rotacion_Hermanos.Name, Class_SQLite.Enum_Type._Boolean, Chk_Sumar_Rotacion_Hermanos.Checked, _Actualizar)

        '   Rotacion con entidades excluidas
        _Sql.Sb_Parametro_Informe_Sql(Chk_Rotacion_Con_Ent_Excluidas, "Compras_Asistente",
                                             Chk_Rotacion_Con_Ent_Excluidas.Name, Class_SQLite.Enum_Type._Boolean, Chk_Rotacion_Con_Ent_Excluidas.Checked, _Actualizar)

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Tmp_Filtros_Busqueda Set Modalidad = '" & Modalidad_Estudio & "'" & vbCrLf &
                       "Where Funcionario = '" & FUNCIONARIO & "' And Informe = 'Compras_Asistente'" & Space(1) &
                       "And Filtro = 'Bodegas_Stock' And NombreEquipo = '" & _NombreEquipo & "' And Modalidad = ''"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Tmp_Filtros_Busqueda Set Modalidad = '" & Modalidad_Estudio & "'" & vbCrLf &
                       "Where Funcionario = '" & FUNCIONARIO & "' And Informe = 'Compras_Asistente'" & Space(1) &
                       "And Filtro = 'Bodegas_Rotacion_Vta' And NombreEquipo = '" & _NombreEquipo & "' And Modalidad = ''"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        If Not _Actualizar Then

            Consulta_sql = "Select Chk,Codigo,Descripcion From " & _Global_BaseBk & "Zw_Tmp_Filtros_Busqueda" & vbCrLf &
                           "Where Funcionario = '" & FUNCIONARIO & "' And Informe = 'Compras_Asistente'" & Space(1) &
                           "And Filtro = 'Bodegas_Stock' And NombreEquipo = '" & _NombreEquipo & "' And Modalidad = '" & Modalidad_Estudio & "'"
            _TblBodCompra = _Sql.Fx_Get_Tablas(Consulta_sql)

            Consulta_sql = "Select Chk,Codigo,Descripcion From " & _Global_BaseBk & "Zw_Tmp_Filtros_Busqueda" & vbCrLf &
                           "Where Funcionario = '" & FUNCIONARIO & "' And Informe = 'Compras_Asistente'" & Space(1) &
                           "And Filtro = 'Bodegas_Rotacion_Vta' And NombreEquipo = '" & _NombreEquipo & "' And Modalidad = '" & Modalidad_Estudio & "'"
            _TblBodVenta = _Sql.Fx_Get_Tablas(Consulta_sql)

            Consulta_sql = "Select Chk,Codigo,Descripcion From " & _Global_BaseBk & "Zw_Tmp_Filtros_Busqueda" & vbCrLf &
                           "Where Funcionario = '" & FUNCIONARIO & "' And Informe = 'Compras_Asistente'" & Space(1) &
                           "And Filtro = 'Bodegas_Reabastecen' And NombreEquipo = '" & _NombreEquipo & "' And Modalidad = '" & Modalidad & "'"
            _TblBodReabastecen = _Sql.Fx_Get_Tablas(Consulta_sql)

            Consulta_sql = "Select Chk,Codigo,Descripcion From " & _Global_BaseBk & "Zw_Tmp_Filtros_Busqueda" & vbCrLf &
               "Where Funcionario = '" & FUNCIONARIO & "' And Informe = 'Compras_Asistente'" & Space(1) &
               "And Filtro = 'Productos_Excluidos' And NombreEquipo = '" & _NombreEquipo & "' And Modalidad = '" & Modalidad & "'"
            _TblFiltroProductosExcluidos = _Sql.Fx_Get_Tablas(Consulta_sql)
            Btn_ProductosExcluidos.Text = "Productos excluidos (" & FormatNumber(_TblFiltroProductosExcluidos.Rows.Count, 0) & ")"

            If Rdb_Productos_Seleccionar.Checked Then

                Consulta_sql = "Select Chk,Codigo,Descripcion From " & _Global_BaseBk & "Zw_Tmp_Filtros_Busqueda" & vbCrLf &
                    "Where Funcionario = '" & FUNCIONARIO & "' And Informe = 'Compras_Asistente'" & Space(1) &
                    "And Filtro = 'Productos_Seleccionados' And NombreEquipo = '" & _NombreEquipo & "' And Modalidad = '" & Modalidad & "'"
                _TblFiltroProductos = _Sql.Fx_Get_Tablas(Consulta_sql)

            End If

        End If


        '  Lista de costos
        _Sql.Sb_Parametro_Informe_Sql(Cmb_Lista_de_costos, "Compras_Asistente",
                                      Cmb_Lista_de_costos.Name, Class_SQLite.Enum_Type._ComboBox, "", _Actualizar)


        '   Rotacion en días
        _Sql.Sb_Parametro_Informe_Sql(Rdb_RotDias, "Compras_Asistente",
                                             Rdb_RotDias.Name, Class_SQLite.Enum_Type._Boolean, Rdb_RotDias.Checked, _Actualizar)

        '   Rotacion en meses
        _Sql.Sb_Parametro_Informe_Sql(Rdb_RotMeses, "Compras_Asistente",
                                             Rdb_RotMeses.Name, Class_SQLite.Enum_Type._Boolean, Rdb_RotMeses.Checked, _Actualizar)

        '   Calculo para saber cuanto comprar S.V.R en Mediana
        _Sql.Sb_Parametro_Informe_Sql(Rdb_Rot_Mediana, "Compras_Asistente",
                                             Rdb_Rot_Mediana.Name, Class_SQLite.Enum_Type._Boolean, Rdb_Rot_Mediana.Checked, _Actualizar)

        '   Calculo para saber cuanto comprar S.V.R en Promedio
        _Sql.Sb_Parametro_Informe_Sql(Rdb_Rot_Promedio, "Compras_Asistente",
                                             Rdb_Rot_Promedio.Name, Class_SQLite.Enum_Type._Boolean, Rdb_Rot_Promedio.Checked, _Actualizar)

        If _Modo_OCC Then
            '   Estudiar ultimas compras por proveedor
            _Sql.Sb_Parametro_Informe_Sql(Chk_IncluirUltCXprov, "Compras_Asistente",
                                             Chk_IncluirUltCXprov.Name, Class_SQLite.Enum_Type._Boolean, Chk_IncluirUltCXprov.Checked, _Actualizar)
        End If

        '   Meses estudiar ultimas compras por proveedor
        _Sql.Sb_Parametro_Informe_Sql(Input_MesesCP, "Compras_Asistente",
                                             Input_MesesCP.Name, Class_SQLite.Enum_Type._Double, Input_MesesCP.Value, _Actualizar)

        '   Documentos estudiar ultimas compras por proveedor
        _Sql.Sb_Parametro_Informe_Sql(Input_UltDocumentosCP, "Compras_Asistente",
                                             Input_UltDocumentosCP.Name, Class_SQLite.Enum_Type._Double, Input_UltDocumentosCP.Value, _Actualizar)

        '   Incluir o no incluir movimientos hacia la producción (GDI -> ODT)
        _Sql.Sb_Parametro_Informe_Sql(Chk_Incluir_Salidas_GDI_OT, "Compras_Asistente",
                                             Chk_Incluir_Salidas_GDI_OT.Name, Class_SQLite.Enum_Type._Boolean, Chk_Incluir_Salidas_GDI_OT.Checked, _Actualizar)


        Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_DbExt_Conexion", "Id = " & Txt_DbExt_Nombre_Conexion.Tag))

        If Not _Reg Then
            Txt_DbExt_Nombre_Conexion.Tag = 0
            Txt_DbExt_Nombre_Conexion.Text = String.Empty
            Txt_DbExt_NombreBod_Ori.Text = String.Empty
            Txt_DbExt_NombreBod_Des.Text = String.Empty
        End If

        If _Actualizar Then
            Txt_DbExt_Nombre_Conexion.Text = Txt_DbExt_Nombre_Conexion.Tag
        End If
        '
        _Sql.Sb_Parametro_Informe_Sql(Txt_DbExt_Nombre_Conexion, "Compras_Asistente",
                                                 Txt_DbExt_Nombre_Conexion.Name, Class_SQLite.Enum_Type._String, Txt_DbExt_Nombre_Conexion.Tag, _Actualizar)

        If Not _Actualizar Then
            Txt_DbExt_Nombre_Conexion.Tag = Txt_DbExt_Nombre_Conexion.Text
        End If


        Txt_DbExt_Nombre_Conexion.Text = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_DbExt_Conexion", "Nombre_Conexion", "Id = " & Val(Txt_DbExt_Nombre_Conexion.Tag))

        ' Proveedor especial para compras directas a este proveedor antes que otros

        Dim _Koen_Especial As String
        Dim _Suen_Especial As String

        If (_RowProveedor_Especial Is Nothing) Then

            _Koen_Especial = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor",
                                      "Informe = 'Compras_Asistente' And Campo = 'Koen_Especial' And NombreEquipo = '" & _NombreEquipo & "' And Funcionario = '" & FUNCIONARIO & "' And Modalidad = '" & Modalidad_Estudio & "'")
            _Suen_Especial = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor",
                                      "Informe = 'Compras_Asistente' And Campo = 'Suen_Especial' And NombreEquipo = '" & _NombreEquipo & "' And Funcionario = '" & FUNCIONARIO & "' And Modalidad = '" & Modalidad_Estudio & "'")

            Txt_ProvEspecial.Text = String.Empty
            _RowProveedor_Especial = Fx_Traer_Datos_Entidad(_Koen_Especial, _Suen_Especial)

        End If

        If Not (_RowProveedor_Especial Is Nothing) Then

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Tmp_Prm_Informes" & vbCrLf &
                           "Where Funcionario = '" & FUNCIONARIO & "' And Informe = 'Compras_Asistente' And Campo In ('Koen_Especial','Suen_Especial') And Modalidad = '" & Modalidad_Estudio & "'"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            _Koen_Especial = Trim(_RowProveedor_Especial.Item("KOEN"))
            _Suen_Especial = Trim(_RowProveedor_Especial.Item("SUEN"))

            Txt_ProvEspecial.Text = _RowProveedor_Especial.Item("KOEN").ToString.Trim & " - " & _RowProveedor_Especial.Item("NOKOEN").ToString.Trim

            _Sql.Sb_Parametro_Informe_Sql(Nothing, "Compras_Asistente", "Koen_Especial", Class_SQLite.Enum_Type._String, _Koen_Especial, _Actualizar, "Seleccion_Productos")
            _Sql.Sb_Parametro_Informe_Sql(Nothing, "Compras_Asistente", "Suen_Especial", Class_SQLite.Enum_Type._String, _Suen_Especial, _Actualizar, "Seleccion_Productos")

        End If

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_DbExt_Maest Where Id_Conexion = " & Val(Txt_DbExt_Nombre_Conexion.Tag)
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not IsNothing(_Row) Then
            Txt_DbExt_NombreBod_Ori.Text = _Row.Item("Empresa_Ori") & "-" & _Row.Item("Sucursal_Ori") & "-" & _Row.Item("Bodega_Ori") & " (" & _Row.Item("NombreBod_Ori") & ")"
            Txt_DbExt_NombreBod_Des.Text = _Row.Item("Empresa_Des") & "-" & _Row.Item("Sucursal_Des") & "-" & _Row.Item("Bodega_Des") & " (" & _Row.Item("NombreBod_Des") & ")"
        End If

        '   Ejecutar sincronizacion entre ambas bases
        _Sql.Sb_Parametro_Informe_Sql(Chk_DbExt_SincronizarPRBD, "Compras_Asistente",
                                      Chk_DbExt_SincronizarPRBD.Name, Class_SQLite.Enum_Type._Boolean, Chk_DbExt_SincronizarPRBD.Checked, _Actualizar)


        ' AUTOMATIZACION
        '   Id Correo envio OCC Automaticas
        _Sql.Sb_Parametro_Informe_Sql(Txt_CtaCorreoEnvioAutomatizado_OCC, "Compras_Asistente",
                                      Txt_CtaCorreoEnvioAutomatizado_OCC.Name, Class_SQLite.Enum_Type._String, Txt_CtaCorreoEnvioAutomatizado_OCC.Text, _Actualizar)
        '   Nombre formato PDF adjunto OCC Automaticas
        _Sql.Sb_Parametro_Informe_Sql(Txt_NombreFormato_PDF_OCC, "Compras_Asistente",
                                      Txt_NombreFormato_PDF_OCC.Name, Class_SQLite.Enum_Type._String, Txt_NombreFormato_PDF_OCC.Text, _Actualizar)
        ' Destinatarios CC para envio de OCC automatizada
        _Sql.Sb_Parametro_Informe_Sql(Txt_CorreoCc_OCC, "Compras_Asistente",
                                      Txt_CorreoCc_OCC.Name, Class_SQLite.Enum_Type._String, Txt_CorreoCc_OCC.Text, _Actualizar)


        '   Id Correo envio NVI Automaticas
        _Sql.Sb_Parametro_Informe_Sql(Txt_CtaCorreoEnvioAutomatizado_NVI, "Compras_Asistente",
                                      Txt_CtaCorreoEnvioAutomatizado_NVI.Name, Class_SQLite.Enum_Type._String, Txt_CtaCorreoEnvioAutomatizado_NVI.Text, _Actualizar)
        '   Nombre formato PDF adjunto NVI Automaticas
        _Sql.Sb_Parametro_Informe_Sql(Txt_NombreFormato_PDF_NVI, "Compras_Asistente",
                                      Txt_NombreFormato_PDF_NVI.Name, Class_SQLite.Enum_Type._String, Txt_NombreFormato_PDF_NVI.Text, _Actualizar)
        ' Destinatarios CC para envio de NVI automatizada
        _Sql.Sb_Parametro_Informe_Sql(Txt_CorreoCc_NVI, "Compras_Asistente",
                                      Txt_CorreoCc_NVI.Name, Class_SQLite.Enum_Type._String, Txt_CorreoCc_NVI.Text, _Actualizar)


        ' Sumar Stock Externo al Stock Fisico
        _Sql.Sb_Parametro_Informe_Sql(Chk_SumerStockExternoAlFisico, "Compras_Asistente",
                                      Chk_SumerStockExternoAlFisico.Name, Class_SQLite.Enum_Type._Boolean, Chk_SumerStockExternoAlFisico.Checked, _Actualizar)

        'Quitar productos excluidos
        _Sql.Sb_Parametro_Informe_Sql(Chk_QuitarProdExcluidos, "Compras_Asistente",
                                      Chk_QuitarProdExcluidos.Name, Class_SQLite.Enum_Type._Boolean, Chk_QuitarProdExcluidos.Checked, _Actualizar)


    End Sub

    'Sub Sb_Actualizar_Revisar_Sqlite()

    '    Me.Enabled = False


    '    Dim _SqlQ As String

    '    'SELECCIONAR PRODUCTOS
    '    '   Todos
    '    _SqlQ = Fx_Actualizar_Parametro_Informe_Sqlite("Compras_Asistente", Rdb_Productos_Todos.Name, Rdb_Productos_Todos.Checked)

    '    '   Vendidos los ultimos, 7, 30 ,60 dias. etc
    '    _SqlQ += Fx_Actualizar_Parametro_Informe_Sqlite("Compras_Asistente", Rdb_Productos_Vendidos_Los_Ultimos_Dias.Name, CBool(Rdb_Productos_Vendidos_Los_Ultimos_Dias.Checked) * -1)
    '    _SqlQ += Fx_Actualizar_Parametro_Informe_Sqlite("Compras_Asistente", Cmb_Cantidad_Dias_Ultima_Venta.Name, Cmb_Cantidad_Dias_Ultima_Venta.SelectedValue)

    '    '   Productos con mov. venta entre fechas
    '    _SqlQ += Fx_Actualizar_Parametro_Informe_Sqlite("Compras_Asistente", Rdb_Productos_Con_Movimientos_De_Venta.Name, Rdb_Productos_Con_Movimientos_De_Venta.Checked)
    '    _SqlQ += Fx_Actualizar_Parametro_Informe_Sqlite("Compras_Asistente", Dtp_Fecha_Movimientos_Desde.Name, Dtp_Fecha_Movimientos_Desde.Value)
    '    _SqlQ += Fx_Actualizar_Parametro_Informe_Sqlite("Compras_Asistente", Dtp_Fecha_Movimientos_Hasta.Name, Dtp_Fecha_Movimientos_Hasta.Value)

    '    '   Seleccionar productos
    '    _SqlQ += Fx_Actualizar_Parametro_Informe_Sqlite("Compras_Asistente", Rdb_Productos_Seleccionar.Name, Rdb_Productos_Seleccionar.Checked)

    '    '   Seleccionar productos por familias, marcas, etc...
    '    _SqlQ += Fx_Actualizar_Parametro_Informe_Sqlite("Compras_Asistente", Rdb_Productos_Familias_Marcas_Etc.Name, Rdb_Productos_Familias_Marcas_Etc.Checked)

    '    '   Productos del Ranking
    '    _SqlQ += Fx_Actualizar_Parametro_Informe_Sqlite("Compras_Asistente", Rdb_Productos_Ranking.Name, Rdb_Productos_Ranking.Checked)
    '    _SqlQ += Fx_Actualizar_Parametro_Informe_Sqlite("Compras_Asistente", Input_Productos_Ranking.Name, Input_Productos_Ranking.Value)

    '    '   Productos comprados a un proveedor en especifico
    '    _SqlQ += Fx_Actualizar_Parametro_Informe_Sqlite("Compras_Asistente", Rdb_Productos_Proveedor.Name, Rdb_Productos_Proveedor.Checked)
    '    If Not (_RowProveedor Is Nothing) Then
    '        _SqlQ += Fx_Actualizar_Parametro_Informe_Sqlite("Compras_Asistente", "Koen", _RowProveedor.Item("KOEN"))
    '        _SqlQ += Fx_Actualizar_Parametro_Informe_Sqlite("Compras_Asistente", "Suen", _RowProveedor.Item("SUEN"))
    '    End If

    '    '   Seleccionar si el proveedor es entidad fisica
    '    _SqlQ += Fx_Actualizar_Parametro_Informe_Sqlite("Compras_Asistente", Chk_Ent_Fisica.Name, Chk_Ent_Fisica.Checked)

    '    '   Seleccionar si el proveedor es entidad fisica
    '    _SqlQ += Fx_Actualizar_Parametro_Informe_Sqlite("Compras_Asistente", Chk_Traer_Productos_De_Reemplazo.Name, Chk_Traer_Productos_De_Reemplazo.Checked)

    '    '   Tipo de compra, Nacional / Comercio Exterior
    '    _SqlQ += Fx_Actualizar_Parametro_Informe_Sqlite("Compras_Asistente", Cmb_Tipo_de_compra.Name, Cmb_Tipo_de_compra.SelectedValue)

    '    '   Tiempo para aprobicionamiento
    '    _SqlQ += Fx_Actualizar_Parametro_Informe_Sqlite("Compras_Asistente", Cmb_Metodo_Abastecer_Dias_Meses.Name, Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue)
    '    _SqlQ += Fx_Actualizar_Parametro_Informe_Sqlite("Compras_Asistente", Input_Dias_a_Abastecer.Name, Input_Dias_a_Abastecer.Value)

    '    '   Tiempo de reposición (Lead Time)
    '    _SqlQ += Fx_Actualizar_Parametro_Informe_Sqlite("Compras_Asistente", Cmb_Tiempo_Reposicion_Dias_Meses.Name, Cmb_Tiempo_Reposicion_Dias_Meses.SelectedValue)
    '    _SqlQ += Fx_Actualizar_Parametro_Informe_Sqlite("Compras_Asistente", Input_Tiempo_Reposicion.Name, Input_Tiempo_Reposicion.Value)

    '    '   Considera Sabado
    '    _SqlQ += Fx_Actualizar_Parametro_Informe_Sqlite("Compras_Asistente", Chk_Sabado.Name, Chk_Sabado.Checked)
    '    '   Considera Domingo
    '    _SqlQ += Fx_Actualizar_Parametro_Informe_Sqlite("Compras_Asistente", Chk_Domingo.Name, Chk_Domingo.Checked)

    '    '   Unidad de compra UD1
    '    _SqlQ += Fx_Actualizar_Parametro_Informe_Sqlite("Compras_Asistente", Rdb_Ud1_Compra.Name, Rdb_Ud1_Compra.Checked)
    '    '   Unidad de compra UD1
    '    _SqlQ += Fx_Actualizar_Parametro_Informe_Sqlite("Compras_Asistente", Rdb_Ud2_Compra.Name, Rdb_Ud2_Compra.Checked)


    '    '   Costos desde ultimo documento segun seleccion
    '    _SqlQ += Fx_Actualizar_Parametro_Informe_Sqlite("Compras_Asistente", Rd_Costo_Lista_Proveedor.Name, Rd_Costo_Lista_Proveedor.Checked)
    '    '   Costos desde ultimo documento segun seleccion
    '    _SqlQ += Fx_Actualizar_Parametro_Informe_Sqlite("Compras_Asistente", Rd_Costo_Ultimo_Documento_Seleccionado.Name, Rd_Costo_Ultimo_Documento_Seleccionado.Checked)
    '    '   Costos de la lista del proveedor
    '    _SqlQ += Fx_Actualizar_Parametro_Informe_Sqlite("Compras_Asistente", Cmb_Documento_Compra.Name, Cmb_Documento_Compra.SelectedValue)
    '    '   Costos de la lista del proveedor
    '    _SqlQ += Fx_Actualizar_Parametro_Informe_Sqlite("Compras_Asistente", Dtp_Fecha_Tope_Proveedores_Automaticos.Name, Dtp_Fecha_Tope_Proveedores_Automaticos.Value)



    '    '   Ticket Quitar Productos sin rotacion 
    '    _SqlQ += Fx_Actualizar_Parametro_Informe_Sqlite("Compras_Asistente", Chk_Sacar_Productos_Sin_Rotacion.Name, Chk_Sacar_Productos_Sin_Rotacion.Checked)
    '    '   Ticket Restar Stock bodega
    '    _SqlQ += Fx_Actualizar_Parametro_Informe_Sqlite("Compras_Asistente", Chk_Restar_Stok_Bodega.Name, Chk_Restar_Stok_Bodega.Checked)
    '    '   Ticket Quitar bloqueados compra
    '    _SqlQ += Fx_Actualizar_Parametro_Informe_Sqlite("Compras_Asistente", Chk_Quitar_Bloqueados_Compra.Name, Chk_Quitar_Bloqueados_Compra.Checked)
    '    '   Ticket Quitar con OCC o NVI
    '    _SqlQ += Fx_Actualizar_Parametro_Informe_Sqlite("Compras_Asistente", Chk_No_Considera_Con_Stock_Pedido_OCC_NVI.Name, Chk_No_Considera_Con_Stock_Pedido_OCC_NVI.Checked)
    '    '   Ticket Solo Stock critico
    '    _SqlQ += Fx_Actualizar_Parametro_Informe_Sqlite("Compras_Asistente", Chk_Mostrar_Solo_Stock_Critico.Name, Chk_Mostrar_Solo_Stock_Critico.Checked)


    '    _Filtro_Bodegas_Est_Vta_Todas += True

    '    '   Venta promedio entre fechas
    '    _SqlQ += Fx_Actualizar_Parametro_Informe_Sqlite("Compras_Asistente", Rdb_Rango_Fechas_Vta_Promedio.Name, Rdb_Rango_Fechas_Vta_Promedio.Checked)
    '    _SqlQ += Fx_Actualizar_Parametro_Informe_Sqlite("Compras_Asistente", Dtp_Fecha_Vta_Desde.Name, Dtp_Fecha_Vta_Desde.Value)
    '    _SqlQ += Fx_Actualizar_Parametro_Informe_Sqlite("Compras_Asistente", Dtp_Fecha_Vta_Hasta.Name, Dtp_Fecha_Vta_Hasta.Value)

    '    '   Venta promedio en meses
    '    _SqlQ += Fx_Actualizar_Parametro_Informe_Sqlite("Compras_Asistente", Rdb_Rango_Meses_Vta_Promedio.Name, Rdb_Rango_Meses_Vta_Promedio.Checked)
    '    _SqlQ += Fx_Actualizar_Parametro_Informe_Sqlite("Compras_Asistente", Input_Ultimos_Meses_Vta_Promedio.Name, Input_Ultimos_Meses_Vta_Promedio.Value)

    '    '   Sumar Rotacion Hermanos, agrupar las rotaciones en un solo producto
    '    _SqlQ += Fx_Actualizar_Parametro_Informe_Sqlite("Compras_Asistente", Chk_Sumar_Rotacion_Hermanos.Name, Chk_Sumar_Rotacion_Hermanos.Checked)

    '    '   Rotacion con entidades excluidas
    '    _SqlQ += Fx_Actualizar_Parametro_Informe_Sqlite("Compras_Asistente", Chk_Rotacion_Con_Ent_Excluidas.Name, Chk_Rotacion_Con_Ent_Excluidas.Checked)

    '    '_LiteSql.Ej_consulta_IDU(_SqlQ)

    '    Sb_Actualizar_Filtro_Tbl_Sqlite(_TblBodCompra, "Compras_Asistente", "Bodegas_Stock")
    '    Sb_Actualizar_Filtro_Tbl_Sqlite(_TblBodVenta, "Compras_Asistente", "Bodegas_Rotacion_Vta")

    '    Me.Enabled = True

    'End Sub

    'Sub Sb_Actualizar_Filtro_Tbl_Sqlite(_Tbl As DataTable, _Informe As String, _Filtro As String)

    '    If Not _Tbl Is Nothing Then
    '        If _Tbl.Rows.Count Then

    '            Consulta_sql = "Delete From Tbl_Filtros_Busqueda Where Informe = '" & _Informe & "' And Filtro = '" & _Filtro & "';" & vbCrLf
    '            For Each _Fila As DataRow In _Tbl.Rows
    '                Dim _Chk = CInt(_Fila.Item("Chk")) * -1
    '                Dim _Codigo = _Fila.Item("Codigo")
    '                Dim _Descripcion = _Fila.Item("Descripcion")
    '                Consulta_sql += "INSERT INTO Tbl_Filtros_Busqueda (Informe,Filtro,Chk,Codigo,Descripcion) VALUES" & Space(1) &
    '                                "('" & _Informe & "','" & _Filtro & "'," & _Chk & ",'" & _Codigo & "','" & _Descripcion & "');" & vbCrLf
    '            Next

    '            '_LiteSql.Ej_consulta_IDU(Consulta_sql)

    '        End If
    '    End If

    'End Sub

    'Function Fx_Actualizar_Parametro_Informe_Sqlite(_Informe As String,
    '                                                _Campo As String,
    '                                                _NewValor As String) As String
    '    Dim Consulta_sql As String

    '    Consulta_sql = "Update Tbl_Prm_Informes Set Valor = '" & _NewValor & "' Where Informe = '" & _Informe & "' And Campo = '" & _Campo & "';" & vbCrLf
    '    Return Consulta_sql

    'End Function

    'Sub Sb_Parametros_Actualizar_New(_Row As DataRow)

    '    _DstCompras.Clear()

    '    Dim _Koen, _Suen As String
    '    Dim _RdProveedor As Boolean = Rdb_Productos_Proveedor.Checked

    '    If Not (_RowProveedor Is Nothing) Then
    '        If _RdProveedor Then
    '            _Koen = _RowProveedor.Item("KOEN") : _Suen = _RowProveedor.Item("SUEN")
    '        Else
    '            _Koen = String.Empty : _Suen = String.Empty ': Rdb_Productos_Todos.Checked = True
    '        End If
    '    Else
    '        _Koen = String.Empty : _Suen = String.Empty
    '        If _RdProveedor Then
    '            Rdb_Productos_Todos.Checked = True
    '        End If
    '    End If

    '    Dim NewFila As DataRow
    '    NewFila = _DstCompras.Tables("Parametros_Inf_2").NewRow
    '    With NewFila

    '        .Item("CodFuncionario") = FUNCIONARIO

    '        .Item("Koen") = _Row.Item("Koen")
    '        .Item("Suen") = _Row.Item("Suen")

    '        .Item("Rdb_Productos_Todos") = .Item("Rdb_Productos_Todos")
    '        .Item("Rdb_Productos_Vendidos_Los_Ultimos_Dias") = .Item("Rdb_Productos_Vendidos_Los_Ultimos_Dias")
    '        .Item("Cmb_Cantidad_Dias_Ultima_Venta") = .Item("Cmb_Cantidad_Dias_Ultima_Venta")

    '        .Item("Rdb_Productos_Con_Movimientos_De_Venta") = .Item("Rdb_Productos_Con_Movimientos_De_Venta")
    '        .Item("Dtp_Fecha_Movimientos_Desde") = .Item("Dtp_Fecha_Movimientos_Desde")
    '        .Item("Dtp_Fecha_Movimientos_Hasta") = .Item("Dtp_Fecha_Movimientos_Hasta")

    '        .Item("Rdb_Productos_Seleccionar") = .Item("Rdb_Productos_Seleccionar")

    '        .Item("Rdb_Productos_Ranking") = .Item("Rdb_Productos_Ranking")
    '        .Item("Input_Productos_Ranking") = .Item("Input_Productos_Ranking")

    '        .Item("Rdb_Productos_Proveedor") = .Item("Rdb_Productos_Proveedor")

    '        .Item("Chk_Traer_Productos_De_Reemplazo") = .Item("Chk_Traer_Productos_De_Reemplazo")
    '        .Item("Chk_Ent_Fisica") = .Item("Chk_Ent_Fisica")


    '        .Item("Input_Tiempo_Reposicion") = .Item("Input_Tiempo_Reposicion")
    '        .Item("Input_Dias_a_Abastecer") = .Item("Input_Dias_a_Abastecer")
    '        .Item("Chk_Mostrar_Solo_Stock_Critico") = .Item("Chk_Mostrar_Solo_Stock_Critico")
    '        .Item("Chk_Sabado") = .Item("Chk_Sabado")
    '        .Item("Chk_Domingo") = .Item("Chk_Domingo")


    '        .Item("Rd_Costo_Lista_Proveedor") = .Item("Rd_Costo_Lista_Proveedor")
    '        .Item("Rd_Costo_Ultima_GRC") = .Item("Rd_Costo_Ultima_GRC")
    '        .Item("Rdb_Ud1_Compra") = .Item("Rdb_Ud1_Compra")
    '        .Item("Rdb_Ud2_Compra") = .Item("Rdb_Ud2_Compra")

    '        .Item("Chk_Cargar_Rotacion_Estacional") = .Item("Chk_Cargar_Rotacion_Estacional")
    '        .Item("Dtp_Fecha_Estacional_Desde") = .Item("Dtp_Fecha_Estacional_Desde")
    '        .Item("Dtp_Fecha_Estacional_Hasta") = .Item("Dtp_Fecha_Estacional_Hasta")


    '        .Item("Chk_Restar_Stok_Bodega") = .Item("Chk_Restar_Stok_Bodega")
    '        .Item("Chk_Sacar_Productos_Sin_Rotacion") = .Item("Chk_Sacar_Productos_Sin_Rotacion")
    '        .Item("Chk_No_Considera_Con_Stock_Pedido_OCC_NVI") = .Item("Chk_No_Considera_Con_Stock_Pedido_OCC_NVI")
    '        .Item("Chk_Quitar_Bloqueados_Compra") = .Item("Chk_Quitar_Bloqueados_Compra")

    '        .Item("Dtp_Fecha_Tope_Proveedores_Automaticos") = .Item("Dtp_Fecha_Tope_Proveedores_Automaticos")

    '        .Item("Input_Dias_Advertencia_Rotacion") = .Item("Input_Dias_Advertencia_Rotacion")
    '        .Item("Chk_Advertir_Rotacion") = .Item("Chk_Advertir_Rotacion")

    '        .Item("Cmb_Padre_Asociacion_Productos") = .Item("Cmb_Padre_Asociacion_Productos")
    '        .Item("Cmb_Proyeccion_Metodo_Abastecer") = .Item("Cmb_Proyeccion_Metodo_Abastecer")
    '        .Item("Input_Proyeccion_Tiempo_a_Abastecer") = .Item("Input_Proyeccion_Tiempo_a_Abastecer")

    '        .Item("Cmb_Proyeccion_Tiempo_Reposicion") = .Item("Cmb_Proyeccion_Tiempo_Reposicion")

    '        .Item("Input_Proyeccion_Tiempo_Reposicion") = .Item("Input_Proyeccion_Tiempo_Reposicion")
    '        .Item("Rdb_Proyeccion_Rotacion_Diaria") = _Rdb_Proyeccion_Rotacion_Diaria
    '        .Item("Rdb_Proyeccion_Rotacion_Efectiva") = _Rdb_Proyeccion_Rotacion_Efectiva
    '        .Item("Input_Proyeccion_Redondeo") = _Input_Proyeccion_Redondeo
    '        .Item("Chk_Rotacion_Con_Ent_Excluidas") = Chk_Rotacion_Con_Ent_Excluidas.Checked

    '        .Item("Chk_Quitar_Ventas_Calzadas") = _Chk_Quitar_Ventas_Calzadas

    '        .Item("Rdb_Agrupar_x_Asociados") = _Rdb_Agrupar_x_Asociados
    '        .Item("Rdb_Agrupar_x_Reemplazos") = _Rdb_Agrupar_x_Reemplazos
    '        .Item("Cmb_Nodo_Raiz_Asociados") = _Cmb_Nodo_Raiz_Asociados

    '        _DstCompras.Tables("Parametros_Inf_2").Rows.Add(NewFila)

    '    End With
    '    ' Dim exists = File.Exists(_Directorio_Informe & "\Parametros_Inf.xml")
    '    _DstCompras.WriteXml(_Directorio_Informe & "\Parametros_Inf.xml")

    'End Sub

    'Sub Sb_Parametros_Informe_Conf_Local(_Abrir As Boolean)

    '    If _Abrir Then

    '        With My.Settings

    '            Rdb_Productos_Todos.Checked = .Asis_Compra_Productos_Todos
    '            Rdb_Productos_Vendidos_Los_Ultimos_Dias.Checked = .Asis_Compra_Productos_Vendidos_Los_Ultimos_Dias
    '            Cmb_Cantidad_Dias_Ultima_Venta.SelectedValue = .Asis_Compra_Cantidad_Dias_Ultima_Venta
    '            Rdb_Productos_Con_Movimientos_De_Venta.Checked = .Asis_Compra_Productos_Con_Movimientos_De_Venta
    '            Dtp_Fecha_Movimientos_Desde.Value = .Asis_Compra_Fecha_Movimientos_Desde
    '            Dtp_Fecha_Movimientos_Hasta.Value = .Asis_Compra_Fecha_Movimientos_Hasta
    '            Rdb_Productos_Seleccionar.Checked = .Asis_Compra_Productos_Seleccionar
    '            Rdb_Productos_Familias_Marcas_Etc.Checked = .Asis_Compra_Productos_Familias_Marcas_Etc
    '            Rdb_Productos_Ranking.Checked = .Asis_Compra_Productos_Ranking
    '            Input_Productos_Ranking.Value = .Asis_Compra_Productos_Ranking_Input
    '            Rdb_Productos_Proveedor.Checked = .Asis_Compra_Productos_Proveedor

    '            If Not String.IsNullOrEmpty(.Asis_Compra_Koen_p) Then

    '                _RowProveedor = Fx_Traer_Datos_Entidad(.Asis_Compra_Koen_p, .Asis_Compra_Suen_p)

    '                Txt_Proveedor.Text = _RowProveedor.Item("KOEN").ToString.Trim & " - " & _RowProveedor.Item("NOKOEN").ToString.Trim

    '            End If

    '            Chk_Ent_Fisica.Checked = .Asis_Compra_Ent_Fisica
    '            Chk_Traer_Productos_De_Reemplazo.Checked = .Asis_Compra_Traer_Productos_De_Reemplazo
    '            Cmb_Tipo_de_compra.SelectedValue = .Asis_Compra_Tipo_de_compra
    '            Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue = .Asis_Compra_Metodo_Abastecer_Dias_Meses
    '            Input_Dias_a_Abastecer.Value = .Asis_Compra_Dias_a_Abastecer
    '            Cmb_Tiempo_Reposicion_Dias_Meses.SelectedValue = .Asis_Compra_Tiempo_Reposicion_Dias_Meses
    '            Input_Tiempo_Reposicion.Value = .Asis_Compra_Tiempo_Reposicion
    '            Chk_Sabado.Checked = .Asis_Compra_Sabado
    '            Chk_Domingo.Checked = .Asis_Compra_Domingo
    '            Rdb_Ud1_Compra.Checked = .Asis_Compra_Ud1_Compra
    '            Rdb_Ud2_Compra.Checked = .Asis_Compra_Ud2_Compra
    '            Rd_Costo_Lista_Proveedor.Checked = .Asis_Compra_Costo_Lista_Proveedor
    '            Rd_Costo_Ultimo_Documento_Seleccionado.Checked = .Asis_Compra_Costo_Ultimo_Documento_Seleccionado
    '            Cmb_Documento_Compra.SelectedValue = .Asis_Compra_Documento_Compra
    '            Dtp_Fecha_Tope_Proveedores_Automaticos.Value = .Asis_Compra_Fecha_Tope_Proveedores_Automaticos
    '            Chk_Sacar_Productos_Sin_Rotacion.Checked = .Asis_Compra_Sacar_Productos_Sin_Rotacion
    '            Chk_Restar_Stok_Bodega.Checked = .Asis_Compra_Restar_Stok_Bodega
    '            Chk_Quitar_Bloqueados_Compra.Checked = .Asis_Compra_Quitar_Bloqueados_Compra
    '            Chk_No_Considera_Con_Stock_Pedido_OCC_NVI.Checked = .Asis_Compra_No_Considera_Con_Stock_Pedido_OCC_NVI
    '            Chk_Mostrar_Solo_Stock_Critico.Checked = .Asis_Compra_Mostrar_Solo_Stock_Critico
    '            Chk_Procesar_Uno_A_Uno.Checked = .Asis_Compra_Procesar_Uno_A_Uno
    '            Rdb_Rango_Fechas_Vta_Promedio.Checked = .Asis_Compra_Rango_Fechas_Vta_Promedio
    '            Dtp_Fecha_Vta_Desde.Value = .Asis_Compra_Fecha_Vta_Desde
    '            Dtp_Fecha_Vta_Hasta.Value = .Asis_Compra_Fecha_Vta_Hasta
    '            Rdb_Rango_Meses_Vta_Promedio.Checked = .Asis_Compra_Rango_Meses_Vta_Promedio
    '            Input_Ultimos_Meses_Vta_Promedio.Value = .Asis_Compra_Ultimos_Meses_Vta_Promedio
    '            Chk_Sumar_Rotacion_Hermanos.Checked = .Asis_Compra_Sumar_Rotacion_Hermanos
    '            Chk_Rotacion_Con_Ent_Excluidas.Checked = .Asis_Compra_Rotacion_Con_Ent_Excluidas

    '            If IsNothing(.Asis_Compra_TblBodCompra) Then

    '                Consulta_sql = "Select Chk,Codigo,Descripcion From " & _Global_BaseBk & "Zw_Tmp_Filtros_Busqueda" & vbCrLf &
    '                           "Where Funcionario = '" & FUNCIONARIO & "' And Informe = 'Compras_Asistente'" & Space(1) &
    '                           "And Filtro = 'Bodegas_Stock' And NombreEquipo = '" & _NombreEquipo & "'"
    '                .Asis_Compra_TblBodCompra = _Sql.Fx_Get_Tablas(Consulta_sql)

    '            End If

    '            If IsNothing(.Asis_Compra_TblBodVenta) Then

    '                Consulta_sql = "Select Chk,Codigo,Descripcion From " & _Global_BaseBk & "Zw_Tmp_Filtros_Busqueda" & vbCrLf &
    '                           "Where Funcionario = '" & FUNCIONARIO & "' And Informe = 'Compras_Asistente'" & Space(1) &
    '                           "And Filtro = 'Bodegas_Rotacion_Vta' And NombreEquipo = '" & _NombreEquipo & "'"
    '                .Asis_Compra_TblBodVenta = _Sql.Fx_Get_Tablas(Consulta_sql)

    '            End If

    '            _TblBodCompra = .Asis_Compra_TblBodCompra
    '            _TblBodVenta = .Asis_Compra_TblBodVenta

    '        End With

    '    Else

    '        With My.Settings

    '            .Asis_Compra_Productos_Todos = Rdb_Productos_Todos.Checked
    '            .Asis_Compra_Productos_Vendidos_Los_Ultimos_Dias = Rdb_Productos_Vendidos_Los_Ultimos_Dias.Checked
    '            .Asis_Compra_Cantidad_Dias_Ultima_Venta = Cmb_Cantidad_Dias_Ultima_Venta.SelectedValue
    '            .Asis_Compra_Productos_Con_Movimientos_De_Venta = Rdb_Productos_Con_Movimientos_De_Venta.Checked
    '            .Asis_Compra_Fecha_Movimientos_Desde = Dtp_Fecha_Movimientos_Desde.Value
    '            .Asis_Compra_Fecha_Movimientos_Hasta = Dtp_Fecha_Movimientos_Hasta.Value
    '            .Asis_Compra_Productos_Seleccionar = Rdb_Productos_Seleccionar.Checked
    '            .Asis_Compra_Productos_Familias_Marcas_Etc = Rdb_Productos_Familias_Marcas_Etc.Checked
    '            .Asis_Compra_Productos_Ranking = Rdb_Productos_Ranking.Checked
    '            .Asis_Compra_Productos_Ranking_Input = Input_Productos_Ranking.Value
    '            .Asis_Compra_Productos_Proveedor = Rdb_Productos_Proveedor.Checked

    '            If Not IsNothing(_RowProveedor) And Rdb_Productos_Proveedor.Checked Then

    '                .Asis_Compra_Koen_p = _RowProveedor.Item("KOEN")
    '                .Asis_Compra_Suen_p = _RowProveedor.Item("SUEN")

    '            Else

    '                .Asis_Compra_Koen_p = String.Empty
    '                .Asis_Compra_Suen_p = String.Empty

    '            End If

    '            .Asis_Compra_Ent_Fisica = Chk_Ent_Fisica.Checked
    '            .Asis_Compra_Traer_Productos_De_Reemplazo = Chk_Traer_Productos_De_Reemplazo.Checked
    '            .Asis_Compra_Tipo_de_compra = Cmb_Tipo_de_compra.SelectedValue
    '            .Asis_Compra_Metodo_Abastecer_Dias_Meses = Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue
    '            .Asis_Compra_Dias_a_Abastecer = Input_Dias_a_Abastecer.Value
    '            .Asis_Compra_Tiempo_Reposicion_Dias_Meses = Cmb_Tiempo_Reposicion_Dias_Meses.SelectedValue
    '            .Asis_Compra_Tiempo_Reposicion = Input_Tiempo_Reposicion.Value
    '            .Asis_Compra_Sabado = Chk_Sabado.Checked
    '            .Asis_Compra_Domingo = Chk_Domingo.Checked
    '            .Asis_Compra_Ud1_Compra = Rdb_Ud1_Compra.Checked
    '            .Asis_Compra_Ud2_Compra = Rdb_Ud2_Compra.Checked
    '            .Asis_Compra_Costo_Lista_Proveedor = Rd_Costo_Lista_Proveedor.Checked
    '            .Asis_Compra_Costo_Ultimo_Documento_Seleccionado = Rd_Costo_Ultimo_Documento_Seleccionado.Checked
    '            .Asis_Compra_Documento_Compra = Cmb_Documento_Compra.SelectedValue
    '            .Asis_Compra_Fecha_Tope_Proveedores_Automaticos = Dtp_Fecha_Tope_Proveedores_Automaticos.Value
    '            .Asis_Compra_Sacar_Productos_Sin_Rotacion = Chk_Sacar_Productos_Sin_Rotacion.Checked
    '            .Asis_Compra_Restar_Stok_Bodega = Chk_Restar_Stok_Bodega.Checked
    '            .Asis_Compra_Quitar_Bloqueados_Compra = Chk_Quitar_Bloqueados_Compra.Checked
    '            .Asis_Compra_No_Considera_Con_Stock_Pedido_OCC_NVI = Chk_No_Considera_Con_Stock_Pedido_OCC_NVI.Checked
    '            .Asis_Compra_Mostrar_Solo_Stock_Critico = Chk_Mostrar_Solo_Stock_Critico.Checked
    '            .Asis_Compra_Procesar_Uno_A_Uno = Chk_Procesar_Uno_A_Uno.Checked
    '            .Asis_Compra_Rango_Fechas_Vta_Promedio = Rdb_Rango_Fechas_Vta_Promedio.Checked
    '            .Asis_Compra_Fecha_Vta_Desde = Dtp_Fecha_Vta_Desde.Value
    '            .Asis_Compra_Fecha_Vta_Hasta = Dtp_Fecha_Vta_Hasta.Value
    '            .Asis_Compra_Rango_Meses_Vta_Promedio = Rdb_Rango_Meses_Vta_Promedio.Checked
    '            .Asis_Compra_Ultimos_Meses_Vta_Promedio = Input_Ultimos_Meses_Vta_Promedio.Value
    '            .Asis_Compra_Sumar_Rotacion_Hermanos = Chk_Sumar_Rotacion_Hermanos.Checked
    '            .Asis_Compra_Rotacion_Con_Ent_Excluidas = Chk_Rotacion_Con_Ent_Excluidas.Checked

    '            .Asis_Compra_TblBodCompra = _TblBodCompra
    '            .Asis_Compra_TblBodVenta = _TblBodVenta

    '            .Save()

    '        End With

    '    End If



    'End Sub

#End Region

    Private Sub BtnProveedor_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Buscar_Proveedor.Click

        Dim Fm As New Frm_BuscarEntidad_Mt(False)
        Fm.ShowInTaskbar = False
        Fm.ShowDialog(Me)

        If Fm.Pro_Entidad_Seleccionada Then

            _RowProveedor = Fm.Pro_RowEntidad
            Txt_Proveedor.Text = Trim(_RowProveedor.Item("KOEN")) & " - " & Trim(_RowProveedor.Item("NOKOEN"))

            Dim _Koen = _RowProveedor.Item("KOEN")
            Dim _Suen = _RowProveedor.Item("SUEN")

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Entidades" & vbCrLf &
                           "Where CodEntidad = '" & _Koen & "' And CodSucEntidad = '" & _Suen & "'"
            Dim _Row_Entidades As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            _Tbl_Filtro_Productos = Nothing
            _Tbl_Filtro_Super_Familias = Nothing
            _Tbl_Filtro_Marcas = Nothing
            _Tbl_Filtro_Rubro = Nothing
            _Tbl_Filtro_Clalibpr = Nothing
            _Tbl_Filtro_Zonas = Nothing

            _Filtro_Productos_Todos = True
            _Filtro_Marcas_Todas = True
            _Filtro_Super_Familias_Todas = True
            _Filtro_Rubro_Todas = True
            _Filtro_Clalibpr_Todas = True
            _Filtro_Zonas_Todas = True
            _Filtro_Bodegas_Todas = True

            If Not IsNothing(_Row_Entidades) Then

                Dim _Metodo_Abastecer_Dias_Meses = NuloPorNro(_Row_Entidades.Item("Metodo_Abastecer_Dias_Meses"), 1)
                Dim _Tiempo_Reposicion_Dias_Meses = NuloPorNro(_Row_Entidades.Item("Tiempo_Reposicion_Dias_Meses"), 1)

                If _Metodo_Abastecer_Dias_Meses = 0 Then _Metodo_Abastecer_Dias_Meses = 1
                If _Tiempo_Reposicion_Dias_Meses = 0 Then _Tiempo_Reposicion_Dias_Meses = 1

                Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue = _Metodo_Abastecer_Dias_Meses
                Cmb_Tiempo_Reposicion_Dias_Meses.SelectedValue = _Tiempo_Reposicion_Dias_Meses

                Dim _Dias_a_Abastecer = NuloPorNro(_Row_Entidades.Item("Dias_a_Abastecer"), 30)
                Dim _Tiempo_Reposicion = NuloPorNro(_Row_Entidades.Item("Tiempo_Reposicion"), 3)

                If _Dias_a_Abastecer = 0 Then _Dias_a_Abastecer = 30
                If _Tiempo_Reposicion = 0 Then _Tiempo_Reposicion = 3

                Input_Dias_a_Abastecer.Value = _Dias_a_Abastecer
                Input_Tiempo_Reposicion.Value = _Tiempo_Reposicion

            Else

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Entidades (CodEntidad,CodSucEntidad,Libera_NVV) Values ('" & _Koen & "','" & _Suen & "',0)" & vbCrLf &
                               "Select * From " & _Global_BaseBk & "Zw_Entidades where CodEntidad = '" & _Koen & "' And CodSucEntidad = '" & _Suen & "'"
                _Row_Entidades = _Sql.Fx_Get_DataRow(Consulta_sql)

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Entidades Set " & vbCrLf &
                               "Metodo_Abastecer_Dias_Meses = " & Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue & "," &
                               "Dias_a_Abastecer = " & Input_Dias_a_Abastecer.Value & "," &
                               "Tiempo_Reposicion_Dias_Meses = " & Cmb_Tiempo_Reposicion_Dias_Meses.SelectedValue & "," &
                               "Tiempo_Reposicion = " & Input_Tiempo_Reposicion.Value & vbCrLf &
                               "Where CodEntidad = '" & _Koen & "' And CodSucEntidad = '" & _Suen & "'"
                _Sql.Ej_consulta_IDU(Consulta_sql)

            End If

        End If

        Fm.Dispose()

    End Sub

    Private Sub BtnProcesarInf_Click(sender As System.Object, e As System.EventArgs) Handles BtnProcesarInf.Click

        Dim _Koen As String
        Dim _Suen As String

        If Rdb_Productos_Proveedor.Checked Then

            ' Cargar lista de costos del proveedor en lista de costos del Random
            If _Global_Row_Configuracion_Estacion.Item("Actualizar_Lista_De_Costos_Random_Desde_Bakapp") Then

                _Koen = _RowProveedor.Item("KOEN")
                _Suen = _RowProveedor.Item("SUEN")

                If Not Fx_Actualizar_Lista_De_Costos_Random_Desde_Bakapp(Me, _Koen, _Suen) Then
                    MessageBoxEx.Show(Me, "No es posible realizar el proceso" & vbCrLf & vbCrLf &
                                      "Para poder actualizar la información de la lista de costos del proveedor debe hacer lo siguiente:" & vbCrLf & vbCrLf &
                                      "1.- Ir al menú de inicio" & vbCrLf &
                                      "2.- Opción [PRECIOS Y COSTOS]" & vbCrLf &
                                      "3.- Opción [LISTA DE PROVEEDORES]" & vbCrLf &
                                      "4.- Buscar al proveedor" & vbCrLf &
                                      "5.- Realizar la gestión de mantenimiento de lista de costos de ese proveedor" & vbCrLf &
                                      " * Dejar una lista de costos vigente" & vbCrLf &
                                      " * Fecha de vencimiento mayor a la fecha actual", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return
                End If

            End If

        End If

        If Not _Filtro_Bodegas_Est_Vta_Todas Then
            If IsNothing(_TblBodVenta) Then
                MessageBoxEx.Show(Me, "Debe seleccionar las bodegas para el estudio de la rotación de venta" & vbCrLf & vbCrLf &
                                  "Pestaña: Calc.Vta.Promedio" & vbCrLf &
                                  "Botón: Bodegas estudio", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If
        End If

        If Not _Filtro_Bodegas_Todas Then
            If IsNothing(_TblBodCompra) Then
                MessageBoxEx.Show(Me, "Debe seleccionar las bodegas para abastecer" & vbCrLf & vbCrLf &
                                  "Pestaña: Excluir / Incluir (Opc. dinámicas)" & vbCrLf &
                                  "Botón: Bodegas de estudio de stock", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If
        End If



        If Chk_DbExt_SincronizarPRBD.Checked And Txt_DbExt_Nombre_Conexion.Tag = 0 Then
            MessageBoxEx.Show(Me, "Faltan los datos de conexión hacia la base de datos externa" & vbCrLf & vbCrLf &
                              "Revise la pestaña: Bod.Ext. Prov. Especial", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            STabConfiguracion.SelectedTabIndex = 6
            Return
        End If

        _DstCompras.Clear()
        _Cancelar = False

        Dim _Nodo_Raiz_Asociados As Integer = _Global_Row_Configuracion_General.Item("Nodo_Raiz_Asociados")
        Dim _TblProductos As DataTable = Fx_Traer_Productos()
        Dim _TblProductos_Con_Reemplazo As DataTable

        Dim _Filtro_Pro As String
        Dim _Filtro_Productos As String
        Dim _Filtro_Codigos_Madre As String

        Dim _Mostrar_Informe As Boolean
        Dim _Productos_Encontrados As Boolean

        If Not (_TblProductos Is Nothing) Then
            _Productos_Encontrados = CBool(_TblProductos.Rows.Count)
        End If

        If _Productos_Encontrados Then

            Dim Fm_Espera As New Frm_Form_Esperar
            Fm_Espera.BarraCircular.IsRunning = True
            Fm_Espera.Show()

            _Filtro_Pro = Generar_Filtro_IN(_TblProductos, "", "KOPR", False, False, "'")

            If Chk_Traer_Productos_De_Reemplazo.Checked Then

                Consulta_sql = "Select Arbol.Codigo_Nodo,Arbol.Codigo_Madre From 
                                " & _Global_BaseBk & "Zw_Prod_Asociacion Prod
                                Inner Join " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Arbol On Prod.Codigo_Nodo = Arbol.Codigo_Nodo
                                Where Arbol.Nodo_Raiz = " & _Nodo_Raiz_Asociados & " And Es_Seleccionable = 1 And Codigo In " & _Filtro_Pro

                Dim _Tbl_Codigos_Madre As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                _Filtro_Codigos_Madre = Generar_Filtro_IN(_Tbl_Codigos_Madre, "", "Codigo_Nodo", False, False, "")

                If _Tbl_Codigos_Madre.Rows.Count = 0 Then
                    _Filtro_Codigos_Madre = "('@@@')"
                End If

                Consulta_sql = "
                                Select Codigo 
                                Into #Paso
                                From " & _Global_BaseBk & "Zw_Prod_Asociacion 
                                Where Codigo_Nodo In " & _Filtro_Codigos_Madre & " And Para_filtro = 1

                                Insert Into #Paso (Codigo)
                                Select KOPR From MAEPR
                                Where KOPR In " & _Filtro_Pro & "

                                Select KOPR,'',NOKOPR,UD01PR,UD02PR,RLUD,CLALIBPR,RUPR,MRPR,ZONAPR,FMPR,PFPR,HFPR,BLOQUEAPR,ATPR
                                FROM MAEPR
                                Where KOPR In (Select Distinct Codigo From #Paso)

                                Drop Table #Paso"

                _TblProductos_Con_Reemplazo = _Sql.Fx_Get_Tablas(Consulta_sql)

            Else

                _TblProductos_Con_Reemplazo = _TblProductos

            End If

            _Filtro_Productos = Generar_Filtro_IN(_TblProductos_Con_Reemplazo, "", "KOPR", False, False, "'")

            Fm_Espera.Close()

            If IsNothing(_TblProductos_Con_Reemplazo) Then
                Return
            End If

            _Sql.Sb_Eliminar_Tabla_De_Paso(_TblPasoInforme)

            If Not _Accion_Automatica Then

                If MessageBoxEx.Show(Me, FormatNumber(_TblProductos_Con_Reemplazo.Rows.Count, 0) & " productos encontrados" & vbCrLf &
                         "¿Desea ver el informe?",
                         "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information) <> Windows.Forms.DialogResult.Yes Then
                    Return
                End If

            End If

            _Mostrar_Informe = True

            If _Mostrar_Informe Then

                If Rd_Costo_Ultimo_Documento_Seleccionado.Checked Then
                    If IsNothing(Cmb_Documento_Compra.SelectedValue) Or Cmb_Documento_Compra.SelectedValue = "" Then
                        MessageBoxEx.Show(Me, "Falta seleccionar el tipo de documento para el costo de la OCC", "Validación",
                                          MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.Enabled = True
                        Return
                    End If
                End If

                If Not Auto_GenerarAutomaticamenteOCCProveedores And Not Auto_GenerarAutomaticamenteNVI Then

                    If Chk_DbExt_SincronizarPRBD.Checked Or Auto_GenerarAutomaticamenteOCCProveedorStar Then
                        Sb_Actualizar_Stock_Desde_Una_Empresa_A_Otra(_TblProductos_Con_Reemplazo)
                    End If

                End If

                Fm_Espera = New Frm_Form_Esperar
                Fm_Espera.BarraCircular.IsRunning = True
                Fm_Espera.Show()

                Circular_Progress1.Visible = True
                Circular_Progress1.IsRunning = True
                Me.Refresh()

                Me.Enabled = False

                Sb_Parametros_Informe_Sql(True)

                Dim _Lista_Campos_Dscto As New List(Of String)

                _Lista_Campos_Dscto = Fx_Lista_Campos_Dscto()

                Dim _Campos_Descuentos = String.Empty

                For Each _Campo As String In _Lista_Campos_Dscto
                    _Campos_Descuentos += "[" & _Campo & "]         [Float]        DEFAULT (0)," & vbCrLf
                Next

                Consulta_sql = My.Resources.Recursos_Asis_Compras.SQLQuery_Crear_tabla_de_paso_inf_compra
                Consulta_sql = Replace(Consulta_sql, "#TablaPaso#", _TblPasoInforme)
                Consulta_sql = Replace(Consulta_sql, "#IN#", _Filtro_Productos)
                Consulta_sql = Replace(Consulta_sql, "--#Campos_Descuentos#", _Campos_Descuentos)
                _Sql.Ej_consulta_IDU(Consulta_sql)

                Consulta_sql = "Insert Into " & _TblPasoInforme & " (Codigo,Codigo_Nodo_Madre,Descripcion,UD1,UD2,Rtu,ClasificacionLibre,Rubro,Marca,Zona,SuperFamilia,Familia,SubFamilia,Bloqueapr,Oculto)" & vbCrLf &
                               "SELECT KOPR,'',NOKOPR,UD01PR,UD02PR,RLUD,CLALIBPR,RUPR,MRPR,ZONAPR,FMPR,PFPR,HFPR,BLOQUEAPR,ATPR" & vbCrLf &
                               "FROM MAEPR Mp WHERE KOPR IN " & _Filtro_Productos
                _Sql.Ej_consulta_IDU(Consulta_sql)

                If Chk_Sumar_Rotacion_Hermanos.Checked Then

                    Consulta_sql = "Select Codigo As Kopr, Prod.Codigo_Nodo, DescripcionBusqueda,Arbol.Codigo_Madre,Arbol.Descripcion As Descripcion_Nodo
                                    Into #Paso
                                    From " & _Global_BaseBk & "Zw_Prod_Asociacion Prod
                                    Inner Join " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Arbol On Prod.Codigo_Nodo = Arbol.Codigo_Nodo
                                    Where Arbol.Nodo_Raiz = " & _Nodo_Raiz_Asociados & " And Es_Seleccionable = 1

                                    Update " & _TblPasoInforme & " Set 
                                        Codigo_Nodo = Isnull(#Paso.Codigo_Nodo,0),
                                        Codigo_Nodo_Madre = Isnull(Codigo_Madre,Codigo),
                                        Descripcion_Madre = Isnull(Descripcion_Nodo,Descripcion)

                                    From " & _TblPasoInforme & " Z1
                                    Left Join #Paso On Kopr = Codigo

                                    Drop Table #Paso"
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                Else

                    Consulta_sql = "Update " & _TblPasoInforme & " Set Codigo_Nodo_Madre = Codigo"
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                End If


                Dim _EntExcluidas As String = String.Empty

                If Not Chk_Rotacion_Con_Ent_Excluidas.Checked Then

                    _EntExcluidas = Space(1) & "And Ltrim(RTrim(ENDO))+LTrim(RTrim(SUENDO))" & vbCrLf &
                                "NOT IN (SELECT LTrim(RTrim(Codigo))+LTrim(RTrim(Sucursal))" & vbCrLf &
                                "From " & _Global_BaseBk & "Zw_TblInf_EntExcluidas" & vbCrLf &
                                "Where Funcionario = '" & FUNCIONARIO & "' And Excluida in ('V','A','T'))" & Space(1)

                End If

                Dim _Filtro_Bodega As String

                ' ****** Este filtro hay que aplicarselo a la fecha de ultima venta

                If _Filtro_Bodegas_Est_Vta_Todas Then
                    _Filtro_Bodega = String.Empty
                Else
                    _Filtro_Bodega = Generar_Filtro_IN(_TblBodVenta, "Chk", "Codigo", False, True, "'")
                    _Filtro_Bodega = "And EMPRESA+SULIDO+BOSULIDO In " & _Filtro_Bodega
                End If

                If Not Chk_Procesar_Uno_A_Uno.Checked Then

                    'ACA SE QUEDA PEGADO, PEGA LAS CAJAS
                    'TIDO In ('GDI','GRI') And ARCHIRST = 'POTD'
                    Consulta_sql = "Update " & _TblPasoInforme & Space(1) &
                                   "Set FCV_Ult_Year = (Select Count(KOPRCT) From MAEDDO WITH (NOLOCK)" & Space(1) &
                                   "Where KOPRCT = Codigo And TIDO = 'FCV' And FEEMLI BETWEEN DATEADD(YEAR,-1,Getdate()) And Getdate()" & _Filtro_Bodega & _EntExcluidas & ")" & vbCrLf &
                                   "Update " & _TblPasoInforme & Space(1) &
                                   "Set BLV_Ult_Year = (Select Count(KOPRCT) From MAEDDO WITH (NOLOCK)" & Space(1) &
                                   "Where KOPRCT = Codigo And TIDO = 'BLV' And FEEMLI BETWEEN DATEADD(YEAR,-1,Getdate()) And Getdate()" & _Filtro_Bodega & _EntExcluidas & ")" & vbCrLf &
                                   "Update " & _TblPasoInforme & Space(1) &
                                   "Set NCV_Ult_Year = (Select Count(KOPRCT) From MAEDDO WITH (NOLOCK)" & Space(1) &
                                   "Where KOPRCT = Codigo And TIDO = 'NCV' And FEEMLI BETWEEN DATEADD(YEAR,-1,Getdate()) And Getdate()" & _Filtro_Bodega & _EntExcluidas & ")" & vbCrLf &
                                   "Update " & _TblPasoInforme & Space(1) &
                                   "Set GDIodt_Ult_Year = (Select Count(KOPRCT) From MAEDDO WITH (NOLOCK)" & Space(1) &
                                   "Where KOPRCT = Codigo And TIDO In ('GDI') And ARCHIRST = 'POTD' And FEEMLI BETWEEN DATEADD(YEAR,-1,Getdate()) And Getdate()" & _Filtro_Bodega & ")" & vbCrLf &
                                   "Update " & _TblPasoInforme & Space(1) &
                                   "Set GRIodt_Ult_Year = (Select Count(KOPRCT) From MAEDDO WITH (NOLOCK)" & Space(1) &
                                   "Where KOPRCT = Codigo And TIDO In ('GRI') And ARCHIRST = 'POTD' And FEEMLI BETWEEN DATEADD(YEAR,-1,Getdate()) And Getdate()" & _Filtro_Bodega & ")"
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                    'Aca inserta Las ultima GRC,OCC y GDD
                    ' Se queda pegado, nos saltamos este paso
                    Consulta_sql = My.Resources.Recursos_Asis_Compras.SQLQuery_Insertar_Productos_en_tabla_de_paso_inf_compra
                    Consulta_sql = Replace(Consulta_sql, "#TablaPaso#", _TblPasoInforme)
                    Consulta_sql = Replace(Consulta_sql, "#FiltroBodegas#", _Filtro_Bodega)
                    Consulta_sql = Replace(Consulta_sql, "#EntExcluidas#", _EntExcluidas)
                    Consulta_sql = Replace(Consulta_sql, "#IN#", "")

                    _Sql.Ej_consulta_IDU(Consulta_sql)

                End If

                Dim _Fecha_Desde_Rot_Vta As Date
                Dim _Fecha_Hasta_Rot_vta As Date

                If Rdb_Rango_Fechas_Vta_Promedio.Checked Then
                    _Fecha_Desde_Rot_Vta = Dtp_Fecha_Vta_Desde.Value
                    _Fecha_Hasta_Rot_vta = Dtp_Fecha_Vta_Hasta.Value
                ElseIf Rdb_Rango_Meses_Vta_Promedio.Checked Then
                    _Fecha_Hasta_Rot_vta = FormatDateTime(FechaDelServidor(), DateFormat.ShortDate)
                    _Fecha_Desde_Rot_Vta = DateAdd(DateInterval.Month, -Input_Ultimos_Meses_Vta_Promedio.Value, _Fecha_Hasta_Rot_vta) '#1/1/1900#
                End If

                If Chk_Procesar_Uno_A_Uno.Checked Then

                    If Not _Sql.Fx_Existe_Tabla(_Global_BaseBk & "Zw_Prod_Doc_Ult_Ventas") Then

                        MessageBoxEx.Show(Me, "Falta la tabla Zw_Prod_Doc_Ult_Ventas" & vbCrLf &
                                          "Informe de esta situación al administrador del sistema",
                                          "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                        Me.Enabled = True
                        Fm_Espera.Close()
                        Fm_Espera.Dispose()
                        Fm_Espera = Nothing
                        Circular_Progress1.Visible = False
                        Me.Refresh()
                        Return

                    End If

                    Me.Enabled = True

                    Consulta_sql = "Select Codigo From " & _TblPasoInforme
                    Dim _Tbl_Informe As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)


                    Barra_Progreso.Maximum = 100
                    Barra_Progreso.Visible = True

                    Lbl_Status.Visible = True
                    Lbl_Status.Text = "Revisando ultimas compras del producto..."

                    Dim _Contador = 1

                    Sb_Habilitar_Desabilitar_Controles(False)

                    If Chk_Sumar_Vta_Ult_Year.Checked Then

                        For Each _Row_Producto As DataRow In _Tbl_Informe.Rows

                            System.Windows.Forms.Application.DoEvents()

                            Dim _Codigo As String = _Row_Producto.Item("Codigo")

                            Dim _Fl_Bodegas = Replace(_Filtro_Bodega, "EMPRESA+SULIDO+BOSULIDO", "Ddo.EMPRESA+Ddo.SULIDO+Ddo.BOSULIDO")

                            Dim _Fl_Excluidas = Replace(_EntExcluidas, "(ENDO)", "(Endo)")
                            _Fl_Excluidas = Replace(_Fl_Excluidas, "(SUENDO)", "(Suendo)")


                            Consulta_sql = "Declare @Fecha_Inicio As Datetime = DATEADD(YEAR,-1,Getdate()),
                                                @Fecha_Fin As Datetime = Getdate()
                                        Delete " & _Global_BaseBk & "Zw_Prod_Doc_Ult_Ventas Where Feemli < @Fecha_Inicio

                                        Insert Into " & _Global_BaseBk & "Zw_Prod_Doc_Ult_Ventas (Idmaeedo,Empresa,Codigo,Tido,Nudo,Endo,Suendo,Feemli)
                                        Select Distinct Edo.IDMAEEDO,Ddo.EMPRESA,Ddo.KOPRCT,Edo.TIDO,Edo.NUDO,Edo.ENDO,Edo.SUENDO,Ddo.FEEMLI
                                        From MAEEDO Edo WITH (NOLOCK)
                                         Inner Join MAEDDO Ddo WITH (NOLOCK) On Ddo.IDMAEEDO = Edo.IDMAEEDO
                                          Where Edo.TIDO In ('FCV','BLV','NCV') And FEEMDO BETWEEN @Fecha_Inicio And @Fecha_Fin And Edo.EMPRESA = '" & ModEmpresa & "' 
                                           And KOPRCT = '" & _Codigo & "' 
                                        --And KOPRCT In (Select Codigo From " & _TblPasoInforme & ")
                                        " & _Fl_Bodegas & "
                                        And Edo.IDMAEEDO Not In (Select Idmaeedo From " & _Global_BaseBk & "Zw_Prod_Doc_Ult_Ventas Where Codigo = '" & _Codigo & "')"

                            _Sql.Ej_consulta_IDU(Consulta_sql)

                            Consulta_sql = "Update " & _TblPasoInforme & " Set
                                        BLV_Ult_Year = (Select COUNT(*) From " & _Global_BaseBk & "Zw_Prod_Doc_Ult_Ventas WITH (NOLOCK) Where Tido = 'BLV' And Codigo = '" & _Codigo & "' " & _Fl_Excluidas & "),
                                        FCV_Ult_Year = (Select COUNT(*) From " & _Global_BaseBk & "Zw_Prod_Doc_Ult_Ventas WITH (NOLOCK) Where Tido = 'FCV' And Codigo = '" & _Codigo & "' " & _Fl_Excluidas & "),
                                        NCV_Ult_Year = (Select COUNT(*) From " & _Global_BaseBk & "Zw_Prod_Doc_Ult_Ventas WITH (NOLOCK) Where Tido = 'NCV' And Codigo = '" & _Codigo & "' " & _Fl_Excluidas & ")
                                        Where Codigo = '" & _Codigo & "'"

                            _Sql.Ej_consulta_IDU(Consulta_sql)

                            Consulta_sql = "Select 0 As IdGRC,Getdate() As FGRC,0 As IdOCC,Getdate() As FOCC,0 As IdGDD,Getdate() As FGDD,		                                
                                        Isnull((Select Top 1 FEEMLI From MAEDDO WITH (NOLOCK) Where KOPRCT = '" & _Codigo & "' And TIDO In
                                        ('BLV','BLX','BSV','ESC','FCV','FDB','FDV','FDX','FDZ','FEE','FEV','FVL','FVT','FVX','FVZ','NCE','NCV','NCX','NCZ','NEV','RIN') 
                                        " & _Filtro_Bodega & vbCrLf &
                                        _EntExcluidas & "
                                        Order By FEEMLI Desc),'19000101') As Fecha_Ult_Venta"

                            Dim _Row_Ult_Compras As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                            If Not IsNothing(_Row_Ult_Compras) Then

                                Dim _IdGRC = _Row_Ult_Compras.Item("IdGRC")
                                Dim _IdOCC = _Row_Ult_Compras.Item("IdOCC")
                                Dim _IdGDD = _Row_Ult_Compras.Item("IdGDD")
                                Dim _Fecha_Ult_Venta As String = Format(_Row_Ult_Compras.Item("Fecha_Ult_Venta"), "yyyyMMdd")

                                Consulta_sql = "Update " & _TblPasoInforme & " 
                                            Set IdGRC = " & _IdGRC & ",IdOCC = " & _IdOCC & ",IdGDD = " & _IdGDD & ",Fecha_Ult_Venta = '" & _Fecha_Ult_Venta & "' 
                                            Where Codigo = '" & _Codigo & "'"
                                _Sql.Ej_consulta_IDU(Consulta_sql)

                            End If



                            Consulta_sql = "Declare @Fecha_Inicio As Datetime = DATEADD(YEAR,-1,Getdate()),
                                                @Fecha_Fin As Datetime = Getdate()

                                                Select " &
                                            "(Select Count(*) From " & _Global_BaseBk & "Zw_Prod_Doc_Ult_Ventas Where Codigo = '" & _Codigo & "' And Tido = 'BLV' And Feemli BETWEEN @Fecha_Inicio And @Fecha_Fin) As 'BLV',
	                                             (Select Count(*) From " & _Global_BaseBk & "Zw_Prod_Doc_Ult_Ventas Where Codigo = '" & _Codigo & "' And Tido = 'FCV' And Feemli BETWEEN @Fecha_Inicio And @Fecha_Fin) As 'FCV',
	                                             (Select Count(*) From " & _Global_BaseBk & "Zw_Prod_Doc_Ult_Ventas Where Codigo = '" & _Codigo & "' And Tido = 'NCV' And Feemli BETWEEN @Fecha_Inicio And @Fecha_Fin) As 'NCV',
                                                    Isnull((Select Top 1 FEEMLI From MAEDDO WITH (NOLOCK) Where KOPRCT = '" & _Codigo & "' And TIDO In
                                                      ('BLV','BLX','BSV','ESC','FCV','FDB','FDV','FDX','FDZ','FEE','FEV','FVL','FVT','FVX','FVZ','NCE','NCV','NCX','NCZ','NEV','RIN') 
                                                       " & _Filtro_Bodega & vbCrLf &
                                                   _EntExcluidas & "
                                                        Order By FEEMLI Desc),'19000101') As Fecha_Ult_Venta"

                            Consulta_sql = "Declare @Fecha_Inicio As Datetime = DATEADD(YEAR,-1,Getdate()),
                                                                    @Fecha_Fin As Datetime = Getdate()

                                                Select " &
                                                "(Select Count(*) From " & _Global_BaseBk & "Zw_Prod_Doc_Ult_Ventas Where Codigo = '" & _Codigo & "' And Tido = 'BLV' And Feemli BETWEEN @Fecha_Inicio And @Fecha_Fin) As 'BLV',
	                                             (Select Count(*) From " & _Global_BaseBk & "Zw_Prod_Doc_Ult_Ventas Where Codigo = '" & _Codigo & "' And Tido = 'FCV' And Feemli BETWEEN @Fecha_Inicio And @Fecha_Fin) As 'FCV',
	                                             (Select Count(*) From " & _Global_BaseBk & "Zw_Prod_Doc_Ult_Ventas Where Codigo = '" & _Codigo & "' And Tido = 'NCV' And Feemli BETWEEN @Fecha_Inicio And @Fecha_Fin) As 'NCV',
                                                 Getdate() As Fecha_Ult_Venta"

                            Dim _Row_Ventas As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                            If Not IsNothing(_Row_Ventas) Then

                                Dim _BLV_Ult_Year = _Row_Ventas.Item("BLV")
                                Dim _FCV_Ult_Year = _Row_Ventas.Item("FCV")
                                Dim _NCV_Ult_Year = _Row_Ventas.Item("NCV")
                                Dim _Fecha_Ult_Venta As String = Format(_Row_Ventas.Item("Fecha_Ult_Venta"), "yyyyMMdd")

                                Consulta_sql = "Update " & _TblPasoInforme & " 
                                            Set BLV_Ult_Year = " & _BLV_Ult_Year & ",FCV_Ult_Year = " & _FCV_Ult_Year &
                                                ",NCV_Ult_Year = " & _NCV_Ult_Year & ",Fecha_Ult_Venta = '" & _Fecha_Ult_Venta & "' 
                                            Where Codigo = '" & _Codigo & "'"
                                _Sql.Ej_consulta_IDU(Consulta_sql)

                            End If


                            Dim _Porc = _Contador / _Tbl_Informe.Rows.Count

                            Lbl_Status.Text = "Revisando ultimas compras del producto " &
                                            FormatNumber(_Contador, 0) & " de " & FormatNumber(_Tbl_Informe.Rows.Count, 0) & " (" & FormatPercent(_Porc, 0) & ")"

                            If _Cancelar Then
                                Lbl_Status.Text = "Status..."
                                Barra_Progreso.Visible = Not _Cancelar
                            End If

                            Barra_Progreso.Value = ((_Contador * 100) / _Tbl_Informe.Rows.Count)
                            _Contador += 1

                            If _Cancelar Then
                                Sb_Habilitar_Desabilitar_Controles(True)
                                Lbl_Status.Text = "Status..."
                                Me.Enabled = True
                                Fm_Espera.Close()
                                Fm_Espera.Dispose()
                                Fm_Espera = Nothing
                                Me.Refresh()
                                Return
                            End If

                        Next

                        Btn_Cancelar.Visible = False
                        Me.Refresh()

                    Else

                        Consulta_sql = "Declare @Fecha_Inicio As Datetime = DATEADD(YEAR,-1,Getdate()),
                                            @Fecha_Fin As Datetime = Getdate()

                                    Select Z1.Codigo,(Select Count(*) From " & _Global_BaseBk & "Zw_Prod_Doc_Ult_Ventas Where Codigo = Z1.Codigo And Tido = 'BLV' And Feemli BETWEEN @Fecha_Inicio And @Fecha_Fin) As 'BLV',
                                    (Select Count(*) From " & _Global_BaseBk & "Zw_Prod_Doc_Ult_Ventas Where Codigo = Z1.Codigo And Tido = 'FCV' And Feemli BETWEEN @Fecha_Inicio And @Fecha_Fin) As 'FCV',
                                    (Select Count(*) From " & _Global_BaseBk & "Zw_Prod_Doc_Ult_Ventas Where Codigo = Z1.Codigo And Tido = 'NCV' And Feemli BETWEEN @Fecha_Inicio And @Fecha_Fin) As 'NCV',
                                    Isnull((Select Top 1 FEEMLI From MAEDDO WITH (NOLOCK) Where KOPRCT = Z1.Codigo And TIDO In
                                     ('BLV','BLX','BSV','ESC','FCV','FDB','FDV','FDX','FDZ','FEE','FEV','FVL','FVT','FVX','FVZ','NCE','NCV','NCX','NCZ','NEV','RIN') 
                                                                      " & _Filtro_Bodega & "
                                    " & _EntExcluidas & vbCrLf &
                                        "Order By FEEMLI Desc),'19000101') As Fecha_Ult_Venta
                                    Into #Paso
                                    From " & _TblPasoInforme & " Z1

                                    Update " & _TblPasoInforme & " Set BLV_Ult_Year = Z2.BLV,FCV_Ult_Year = Z2.FCV,NCV_Ult_Year = Z2.NCV, Fecha_Ult_Venta = Z2.Fecha_Ult_Venta
                                    From #Paso Z2
                                    Inner Join " & _TblPasoInforme & " Z1 On Z1.Codigo = Z2.Codigo

                                    Select * From #Paso"
                        _Sql.Ej_consulta_IDU(Consulta_sql)

                        For Each _Row_Producto As DataRow In _Tbl_Informe.Rows

                            System.Windows.Forms.Application.DoEvents()

                            Dim _Porc = _Contador / _Tbl_Informe.Rows.Count

                            Lbl_Status.Text = "Revisando ultimas compras del producto " &
                                            FormatNumber(_Contador, 0) & " de " & FormatNumber(_Tbl_Informe.Rows.Count, 0) & " (" & FormatPercent(_Porc, 0) & ")"

                            If _Cancelar Then
                                Lbl_Status.Text = "Status..."
                                Barra_Progreso.Visible = Not _Cancelar
                            End If

                            Barra_Progreso.Value = ((_Contador * 100) / _Tbl_Informe.Rows.Count)
                            _Contador += 1

                            If _Cancelar Then
                                Sb_Habilitar_Desabilitar_Controles(True)
                                Lbl_Status.Text = "Status..."
                                Me.Enabled = True
                                Fm_Espera.Close()
                                Fm_Espera.Dispose()
                                Fm_Espera = Nothing
                                Me.Refresh()
                                Return
                            End If

                        Next

                    End If

                End If

                Dim _Tiempo_Desde As DateTime = Now

                Me.Enabled = False

                If Chk_Traer_Productos_De_Reemplazo.Checked Then

                    Consulta_sql = "Update " & _TblPasoInforme & " Set Fecha_Ult_Venta = (Select Max(Fecha_Ult_Venta) From " & _TblPasoInforme & " Z2 Where Z1.Codigo_Nodo = Z2.Codigo_Nodo)
                                    From " & _TblPasoInforme & " Z1 Where Codigo_Nodo <> 0"
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                End If

#Region "CALCULO DE ROTACION POR PRODUCTOS"

#Region "ROTACION POR PRODUCTO"


#End Region

                Rdb_RotMeses.Checked = True

                Me.Refresh()
                Lbl_Status.Text = "Calculando rotación por productos, esto puede tardar algunos minutos..."

                Consulta_sql = My.Resources.Recursos_Asis_Compras.SQLQuery_Sacar_la_velocidad_de_venta_mensual_Media2
                Consulta_sql = Replace(Consulta_sql, "#Empresa#", ModEmpresa)
                Consulta_sql = Replace(Consulta_sql, "#Funcionario#", FUNCIONARIO)
                Consulta_sql = Replace(Consulta_sql, "#FechaInicio#", Format(_Fecha_Desde_Rot_Vta, "yyyyMMdd"))
                Consulta_sql = Replace(Consulta_sql, "#FechaTermino#", Format(_Fecha_Hasta_Rot_vta, "yyyyMMdd"))
                Consulta_sql = Replace(Consulta_sql, "#Filtro_Codigo#", "AND KOPRCT In (Select Codigo From #TablaPaso#)")
                Consulta_sql = Replace(Consulta_sql, "#Filtro_Bodega#", _Filtro_Bodega)
                Consulta_sql = Replace(Consulta_sql, "#Entidades_Excluidas#", _EntExcluidas)
                Consulta_sql = Replace(Consulta_sql, "#TablaPaso#", _TblPasoInforme)

                Consulta_sql = Replace(Consulta_sql, "#Codigo_Revision#", "Codigo_Nodo_Madre")
                Consulta_sql = Replace(Consulta_sql, "#Campo_RotUd1Mes#", "RotMensualUd1")
                Consulta_sql = Replace(Consulta_sql, "#Campo_RotUd2Mes#", "RotMensualUd2")
                Consulta_sql = Replace(Consulta_sql, "#Campo_RotUd1Dia#", "RotDiariaUd1")
                Consulta_sql = Replace(Consulta_sql, "#Campo_RotUd2Dia#", "RotDiariaUd2")

                Consulta_sql = Replace(Consulta_sql, "#MediaCal#", "#MediaMes")

                Consulta_sql = Replace(Consulta_sql, "#Campo_Promedio_Ud1Mes#", "Promedio_MensualUd1")
                Consulta_sql = Replace(Consulta_sql, "#Campo_Promedio_Ud2Mes#", "Promedio_MensualUd2")
                Consulta_sql = Replace(Consulta_sql, "#Campo_Promedio_Ud1Dia#", "Promedio_Ud1")
                Consulta_sql = Replace(Consulta_sql, "#Campo_Promedio_Ud2Dia#", "Promedio_Ud2")

                Consulta_sql = Replace(Consulta_sql, "#Incluir_Sabado#", Convert.ToInt32(Chk_Sabado.Checked))
                Consulta_sql = Replace(Consulta_sql, "#Incluir_Domingo#", Convert.ToInt32(Chk_Domingo.Checked))

                Dim _Filtro_Documentos As String

                If Chk_Incluir_Salidas_GDI_OT.Checked Then
                    _Filtro_Documentos = "And (TIDO IN ('FCV', 'FDB', 'FDV', 'FDX', 'FDZ', 'FEV', 'FVL', 'FVT', 'FVX', 'FVZ','FEE', 'BLV','GDV','GDP','NCE', 'NCV', 'NCX', 'NCZ', 'NEV') Or " &
                                          "TIDO In ('GDI','GRI') And ARCHIRST = 'POTD')"
                Else
                    _Filtro_Documentos = "And TIDO IN ('FCV', 'FDB', 'FDV', 'FDX', 'FDZ', 'FEV', 'FVL', 'FVT', 'FVX', 'FVZ','FEE', 'BLV','GDV','GDP','NCE', 'NCV', 'NCX', 'NCZ', 'NEV')"
                End If

                Consulta_sql = Replace(Consulta_sql, "#Filtro_Documentos#", _Filtro_Documentos)

                Me.Refresh()

                _Sql.Ej_consulta_IDU(Consulta_sql)

                Dim _Fecha_Desde_3M As DateTime
                Dim _Fecha_Hasta_3M As DateTime = FechaDelServidor()

                _Fecha_Desde_3M = DateAdd(DateInterval.Month, -3, _Fecha_Hasta_3M)

                ' Ventas los ultimos 3 meses, para tendencia

                Me.Refresh()
                Lbl_Status.Text = "Calculando rotación por productos, esto puede tardar algunos minutos..."


                Consulta_sql = My.Resources.Recursos_Asis_Compras.SQLQuery_Sacar_la_velocidad_de_venta_mensual_Media2
                Consulta_sql = Replace(Consulta_sql, "#Empresa#", ModEmpresa)
                Consulta_sql = Replace(Consulta_sql, "#Funcionario#", FUNCIONARIO)
                Consulta_sql = Replace(Consulta_sql, "#FechaInicio#", Format(_Fecha_Desde_3M, "yyyyMMdd"))
                Consulta_sql = Replace(Consulta_sql, "#FechaTermino#", Format(_Fecha_Hasta_3M, "yyyyMMdd"))
                Consulta_sql = Replace(Consulta_sql, "#Filtro_Codigo#", "AND KOPRCT In (Select Codigo From #TablaPaso#)")
                Consulta_sql = Replace(Consulta_sql, "#Filtro_Bodega#", _Filtro_Bodega)
                Consulta_sql = Replace(Consulta_sql, "#Entidades_Excluidas#", _EntExcluidas)
                Consulta_sql = Replace(Consulta_sql, "#TablaPaso#", _TblPasoInforme)

                Consulta_sql = Replace(Consulta_sql, "#Codigo_Revision#", "Codigo")
                Consulta_sql = Replace(Consulta_sql, "#Campo_RotUd1Mes#", "RotMensualUd1_Prod")
                Consulta_sql = Replace(Consulta_sql, "#Campo_RotUd2Mes#", "RotMensualUd2_Prod")
                Consulta_sql = Replace(Consulta_sql, "#Campo_RotUd1Dia#", "RotDiariaUd1_Prod")
                Consulta_sql = Replace(Consulta_sql, "#Campo_RotUd2Dia#", "RotDiariaUd2_Prod")
                Consulta_sql = Replace(Consulta_sql, "#MediaCal#", "#MediaMes")

                Consulta_sql = Replace(Consulta_sql, "#Campo_Promedio_Ud1Mes#", "Promedio_MensualUd1_Prod")
                Consulta_sql = Replace(Consulta_sql, "#Campo_Promedio_Ud2Mes#", "Promedio_MensualUd2_Prod")
                Consulta_sql = Replace(Consulta_sql, "#Campo_Promedio_Ud1Dia#", "Promedio_Ud1_Prod")
                Consulta_sql = Replace(Consulta_sql, "#Campo_Promedio_Ud2Dia#", "Promedio_Ud2_Prod")

                Consulta_sql = Replace(Consulta_sql, "#Incluir_Sabado#", Convert.ToInt32(Chk_Sabado.Checked))
                Consulta_sql = Replace(Consulta_sql, "#Incluir_Domingo#", Convert.ToInt32(Chk_Domingo.Checked))

                Consulta_sql = Replace(Consulta_sql, "#Filtro_Documentos#", _Filtro_Documentos)

                Me.Refresh()

                _Sql.Ej_consulta_IDU(Consulta_sql)

                '''' ******************************************************

                '' Actualizar stock

                Me.Refresh()
                Lbl_Status.Text = "Calculando rotación por productos, esto puede tardar algunos minutos..."

                Consulta_sql = My.Resources.Recursos_Asis_Compras.SQLQuery_SumTotalQty_Venta_X_Periodo
                Consulta_sql = Replace(Consulta_sql, "#Empresa#", ModEmpresa)
                Consulta_sql = Replace(Consulta_sql, "#Funcionario#", FUNCIONARIO)
                Consulta_sql = Replace(Consulta_sql, "#FechaInicio#", Format(_Fecha_Desde_Rot_Vta, "yyyyMMdd"))
                Consulta_sql = Replace(Consulta_sql, "#FechaTermino#", Format(_Fecha_Hasta_Rot_vta, "yyyyMMdd"))
                Consulta_sql = Replace(Consulta_sql, "#Filtro_Codigo#", "AND KOPRCT In (Select Codigo From #TablaPaso#)")
                Consulta_sql = Replace(Consulta_sql, "#Filtro_Bodega#", _Filtro_Bodega)
                Consulta_sql = Replace(Consulta_sql, "#Entidades_Excluidas#", _EntExcluidas)
                Consulta_sql = Replace(Consulta_sql, "#TablaPaso#", _TblPasoInforme)

                Consulta_sql = Replace(Consulta_sql, "#Codigo_Revision#", "Codigo")

                Consulta_sql = Replace(Consulta_sql, "#Campo_SumTotalQtyUd1#", "SumTotalQtyUd1")
                Consulta_sql = Replace(Consulta_sql, "#Campo_SumTotalQtyUd2#", "SumTotalQtyUd2")

                Me.Refresh()

                _Sql.Ej_consulta_IDU(Consulta_sql)


                Me.Refresh()
                Lbl_Status.Text = "Calculando rotación por productos, esto puede tardar algunos minutos..."

                ' CALCULO PARA TENDENCIA DE VENTA ULTIMOS 3 MESES

                Consulta_sql = My.Resources.Recursos_Asis_Compras.SQLQuery_SumTotalQty_Venta_X_Periodo
                Consulta_sql = Replace(Consulta_sql, "#Empresa#", ModEmpresa)
                Consulta_sql = Replace(Consulta_sql, "#Funcionario#", FUNCIONARIO)
                Consulta_sql = Replace(Consulta_sql, "#FechaInicio#", Format(_Fecha_Desde_3M, "yyyyMMdd"))
                Consulta_sql = Replace(Consulta_sql, "#FechaTermino#", Format(_Fecha_Hasta_3M, "yyyyMMdd"))
                Consulta_sql = Replace(Consulta_sql, "#Filtro_Codigo#", "AND KOPRCT In (Select Codigo From #TablaPaso#)")
                Consulta_sql = Replace(Consulta_sql, "#Filtro_Bodega#", _Filtro_Bodega)
                Consulta_sql = Replace(Consulta_sql, "#Entidades_Excluidas#", _EntExcluidas)
                Consulta_sql = Replace(Consulta_sql, "#TablaPaso#", _TblPasoInforme)

                Consulta_sql = Replace(Consulta_sql, "#Codigo_Revision#", "Codigo")

                Consulta_sql = Replace(Consulta_sql, "#Campo_SumTotalQtyUd1#", "SumTotalQtyUd1_Ult_3Mes")
                Consulta_sql = Replace(Consulta_sql, "#Campo_SumTotalQtyUd2#", "SumTotalQtyUd2_Ult_3Mes")

                Me.Refresh()

                _Sql.Ej_consulta_IDU(Consulta_sql)

                Dim _Fecha_Hasta_3Cio As DateTime = FechaDelServidor()
                Dim _Fecha_Desde_3Cio As Date = DateAdd(DateInterval.Month, -1, _Fecha_Hasta_3Cio)

                Consulta_sql = My.Resources.Recursos_Asis_Compras.SQLQuery_SumTotalQty_Venta_X_Periodo
                Consulta_sql = Replace(Consulta_sql, "#Empresa#", ModEmpresa)
                Consulta_sql = Replace(Consulta_sql, "#Funcionario#", FUNCIONARIO)
                Consulta_sql = Replace(Consulta_sql, "#FechaInicio#", Format(_Fecha_Desde_3Cio, "yyyyMMdd"))
                Consulta_sql = Replace(Consulta_sql, "#FechaTermino#", Format(_Fecha_Hasta_3Cio, "yyyyMMdd"))
                Consulta_sql = Replace(Consulta_sql, "#Filtro_Codigo#", "AND KOPRCT In (Select Codigo From #TablaPaso#)")
                Consulta_sql = Replace(Consulta_sql, "#Filtro_Bodega#", _Filtro_Bodega)
                Consulta_sql = Replace(Consulta_sql, "#Entidades_Excluidas#", _EntExcluidas)
                Consulta_sql = Replace(Consulta_sql, "#TablaPaso#", _TblPasoInforme)

                Consulta_sql = Replace(Consulta_sql, "#Codigo_Revision#", "Codigo")

                Consulta_sql = Replace(Consulta_sql, "#Campo_SumTotalQtyUd1#", "SumTotalQtyUd1_Ult_3Cio")
                Consulta_sql = Replace(Consulta_sql, "#Campo_SumTotalQtyUd2#", "SumTotalQtyUd2_Ult_3Cio")

                Me.Refresh()

                _Sql.Ej_consulta_IDU(Consulta_sql)

#End Region

                Lbl_Status.Text = "Extrayendo informe..."

                Consulta_sql = "Update " & _TblPasoInforme & vbCrLf &
                               "Set Fecha_Inicio = '" & Format(_Fecha_Desde_Rot_Vta, "yyyyMMdd") & "'," &
                               "Fecha_Fin = '" & Format(_Fecha_Hasta_Rot_vta, "yyyyMMdd") & "'"
                _Sql.Ej_consulta_IDU(Consulta_sql)

                If Rdb_Productos_Seleccionar.Checked Then

                    _Filtro_Pro = Generar_Filtro_IN(_TblProductos, "", "KOPR", False, False, "'")

                    Consulta_sql = "Update " & _TblPasoInforme & " Set Es_Reemplazo = 1 Where Codigo Not In " & _Filtro_Pro
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                End If

                If Chk_Sumar_Rotacion_Hermanos.Checked Then

                    Consulta_sql = "Update " & _TblPasoInforme & " Set " & vbCrLf &
                                    "FCV_Ult_Year = (Select Sum(FCV_Ult_Year) From " & _TblPasoInforme & " Z2 Where Z2.Codigo_Nodo_Madre = Z1.Codigo_Nodo_Madre)," & vbCrLf &
                                    "BLV_Ult_Year = (Select Sum(BLV_Ult_Year) From " & _TblPasoInforme & " Z2 Where Z2.Codigo_Nodo_Madre = Z1.Codigo_Nodo_Madre)," & vbCrLf &
                                    "NCV_Ult_Year = (Select Sum(NCV_Ult_Year) From " & _TblPasoInforme & " Z2 Where Z2.Codigo_Nodo_Madre = Z1.Codigo_Nodo_Madre)" & vbCrLf &
                                    "From " & _TblPasoInforme & " Z1"
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                End If

                If Rdb_Productos_Proveedor.Checked Then

                    _Koen = _RowProveedor.Item("KOEN")
                    _Suen = _RowProveedor.Item("SUEN")

                    Consulta_sql = "Update " & _TblPasoInforme & " Set CodProveedor = '" & _Koen & "',CodSucProveedor = '" & _Suen & "'
                                    Update " & _TblPasoInforme & " Set CodAlternativo = (Select Top 1 KOPRAL From TABCODAL Where KOEN = '" & _Koen & "' And Codigo = KOPR)"
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                    Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Entidades" & vbCrLf &
                                   "Where CodEntidad = '" & _Koen & "' And CodSucEntidad = '" & _Suen & "'"
                    Dim _Row_Entidades As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                    If IsNothing(_Row_Entidades) Then

                        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Entidades (CodEntidad,CodSucEntidad,Libera_NVV) Values ('" & _Koen & "','" & _Suen & "',0)"
                        _Sql.Ej_consulta_IDU(Consulta_sql)

                    End If

                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_Entidades Set " & vbCrLf &
                                   "Metodo_Abastecer_Dias_Meses = " & Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue & "," &
                                   "Dias_a_Abastecer = " & Input_Dias_a_Abastecer.Value & "," &
                                   "Tiempo_Reposicion_Dias_Meses = " & Cmb_Tiempo_Reposicion_Dias_Meses.SelectedValue & "," &
                                   "Tiempo_Reposicion = " & Input_Tiempo_Reposicion.Value & vbCrLf &
                                   "Where CodEntidad = '" & _Koen & "' And CodSucEntidad = '" & _Suen & "'"
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                End If

                Me.Enabled = True
                Fm_Espera.Close()
                Fm_Espera.Dispose()
                Fm_Espera = Nothing
                Circular_Progress1.Visible = False
                Me.Refresh()

                If Rdb_Productos_Proveedor.Checked And Chk_IncluirUltCXprov.Checked Then

                    Dim Fm As New Frm_10_Asis_Compra_Ult3OCCxProv()
                    Fm.Accion_Automatica = True
                    Fm.ShowDialog(Me)
                    Fm.Dispose()

                End If

                If CBool(_TblFiltroProductosExcluidos.Rows.Count) Then

                    Dim _CodigosExcluidos As String = Generar_Filtro_IN(_TblFiltroProductosExcluidos, "Chk", "Codigo", False, True, "'")

                    Consulta_sql = "Update " & _TblPasoInforme & " Set ProductoExcluido = 1" & vbCrLf &
                                   "Where Codigo In " & _CodigosExcluidos
                    _Sql.Ej_consulta_IDU(Consulta_sql)


                End If

                Sb_Procesar_Informe(_Filtro_Productos)
                Sb_Habilitar_Desabilitar_Controles(True)

            End If

        Else
            MessageBoxEx.Show(Me, "No existe información", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Sub Sb_Procesar_Informe(_Filtro_Productos As String)

        Dim _Dias_Advertencia_Rotacion = Input_Dias_Advertencia_Rotacion.Value
        Dim _Fecha As Date = FormatDateTime(DateAdd(DateInterval.Day, -_Dias_Advertencia_Rotacion, FechaDelServidor), DateFormat.ShortDate)

        Dim _Con_Ent_Excluidas As Integer = CInt(Chk_Rotacion_Con_Ent_Excluidas.Checked) * -1

        If Chk_Advertir_Rotacion.Checked Then

            Consulta_sql = "Select Codigo From " & _TblPasoInforme & vbCrLf &
                           "Where" & vbCrLf &
                           "Codigo In (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Rotacion" & vbCrLf &
                           "Where" & vbCrLf &
                           "(Fecha_Ultima_Ejecucion < '" & Format(_Fecha, "yyyyMMdd") & "' or Fecha_Ultima_Ejecucion is null)" & vbCrLf &
                           "And Con_Ent_Excluidas = " & _Con_Ent_Excluidas & vbCrLf &
                           "And Codigo In " & _Filtro_Productos & ")" & vbCrLf &
                           "And Codigo Not in (Select KOPR From MAEPR Where TIPR = 'SSN')"

            Consulta_sql = "Select Codigo From " & _TblPasoInforme & vbCrLf &
                           "Where" & vbCrLf &
                           "Codigo In (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Stock_Enc_History" & Space(1) &
                           "Where Fecha_Ult_Revision <= '" & Format(_Fecha, "yyyyMMdd") & "')" & Space(1) &
                           "Or Codigo In (Select Codigo From " & _TblPasoInforme & " Where Codigo Not In (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Stock_Enc_History))"

            Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            If CBool(_Tbl.Rows.Count) Then

                Dim _Reprocesa_Rotacion As Boolean
                Dim _Consulta = MessageBoxEx.Show(Me, "Existen " & FormatNumber(_Tbl.Rows.Count, 0) & " productos con rotación desactualizada" & vbCrLf &
                                     "¿Desea actualizar los datos de rotación (Recomendado)? ", "ALERTA!!!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Stop)

                If _Consulta = Windows.Forms.DialogResult.Yes Then

                    Dim Fm_R As New Frm_Rotacion_Selec_Prod_Parametros

                    Fm_R.Chk_Incluir_Ventas_Entidades_Excluidas.Checked = Chk_Rotacion_Con_Ent_Excluidas.Checked
                    If Chk_Rotacion_Con_Ent_Excluidas.Checked Then Fm_R.Chk_Incluir_Ventas_Entidades_Excluidas.Enabled = False

                    Fm_R.Pro_Tbl_Productos_Seleccionados = _Tbl
                    Fm_R.ShowDialog(Me)
                    _Reprocesa_Rotacion = Fm_R.Pro_Informe_Procesado
                    Fm_R.Dispose()

                ElseIf _Consulta = Windows.Forms.DialogResult.Cancel Then
                    Return
                End If

                If _Reprocesa_Rotacion Then
                    MessageBoxEx.Show(Me, "Ahora es seguro continuar con la gestión", "Actualizar rotación",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    If MessageBoxEx.Show(Me, "No se genero actualización de rotación, no es confiable la información del reporte" & vbCrLf &
                                       "¿Desea ver el informe?",
                                       "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> Windows.Forms.DialogResult.Yes Then
                        Return
                    End If

                End If

            End If

        End If

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Prod_Log_Compras (NombreEquipo, CodFuncionario, Codigo)" & vbCrLf &
                       "Select '" & _NombreEquipo & "','" & FUNCIONARIO & "',KOPR" & vbCrLf &
                       "From MAEPR Where KOPR Not In (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Log_Compras" & Space(1) &
                       "Where NombreEquipo = '" & _NombreEquipo & "' And CodFuncionario = '" & FUNCIONARIO & "')" & vbCrLf &
                       "And KOPR In (Select Codigo From " & _TblPasoInforme & ")"
        _Sql.Ej_consulta_IDU(Consulta_sql)


        Dim Fm As New Frm_01_Asis_Compra_Resultados(Modalidad_Estudio)

        Fm.Pro_Nombre_Tbl_Paso_Informe = _TblPasoInforme

        Fm.Pro_Filtro_Clalibpr_Todas = _Filtro_Clalibpr_Todas
        Fm.Pro_Filtro_Marcas_Todas = _Filtro_Marcas_Todas
        Fm.Pro_Filtro_Rubro_Todas = _Filtro_Rubro_Todas
        Fm.Pro_Filtro_Super_Familias_Todas = _Filtro_Super_Familias_Todas
        Fm.Pro_Filtro_Zonas_Todas = _Filtro_Zonas_Todas

        Fm.Pro_Tbl_Filtro_Clalibpr = _Tbl_Filtro_Clalibpr
        Fm.Pro_Tbl_Filtro_Marcas = _Tbl_Filtro_Marcas
        Fm.Pro_Tbl_Filtro_Rubro = _Tbl_Filtro_Rubro
        Fm.Pro_Tbl_Filtro_Super_Familias = _Tbl_Filtro_Super_Familias
        Fm.Pro_Tbl_Filtro_Zonas = _Tbl_Filtro_Zonas

        Fm.Accion_Automatica = _Accion_Automatica
        Fm.Auto_GenerarAutomaticamenteOCCProveedores = Auto_GenerarAutomaticamenteOCCProveedores
        Fm.Auto_GenerarAutomaticamenteOCCProveedorStar = Auto_GenerarAutomaticamenteOCCProveedorStar
        Fm.Auto_GenerarAutomaticamenteNVI = Auto_GenerarAutomaticamenteNVI

        If Auto_GenerarAutomaticamenteNVI Then
            Fm.Auto_CorreoCc = Txt_CorreoCc_NVI.Text
            Fm.Auto_Id_Correo = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Correos", "Id", "Nombre_Correo = '" & Txt_CtaCorreoEnvioAutomatizado_NVI.Text & "'")
            Fm.Auto_NombreFormato_PDF = Txt_NombreFormato_PDF_NVI.Text
        Else
            Fm.Auto_CorreoCc = Txt_CorreoCc_OCC.Text
            Fm.Auto_Id_Correo = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Correos", "Id", "Nombre_Correo = '" & Txt_CtaCorreoEnvioAutomatizado_OCC.Text & "'")
            Fm.Auto_NombreFormato_PDF = Txt_NombreFormato_PDF_OCC.Text
        End If

        Fm.Modo_OCC = Modo_OCC
        Fm.Modo_NVI = _Modo_NVI

        Fm.Chk_QuitarProdExcluidos.Checked = Chk_QuitarProdExcluidos.Checked

        Fm.ShowDialog(Me)
        Fm.Dispose()

        Sb_Parametros_Informe_Sql(False)

    End Sub

    Private Sub Frm_00_AsisCompra_Menu_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        Me.Enabled = False
        _Sql.Sb_Eliminar_Tabla_De_Paso(_TblPasoInforme)

        If Not Modo_ConfAuto Then
            Sb_Parametros_Informe_Sql(True)
        End If

    End Sub

    Private Sub Frm_00_AsisCompra_Menu_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub BtnSeleccionarProductos_Click(sender As System.Object, e As System.EventArgs) Handles BtnSeleccionarProductos.Click

        Dim _Sql_Filtro_Condicion_Extra = "And TIPR In ('FPN','FIN')"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_TblFiltroProductos,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Productos, _Sql_Filtro_Condicion_Extra,
                               False, False) Then

            Dim _Nodo_Raiz_Asociados As Integer = _Global_Row_Configuracion_General.Item("Nodo_Raiz_Asociados")

            _TblFiltroProductos = _Filtrar.Pro_Tbl_Filtro

            If Not _Filtrar.Pro_Filtro_Todas Then

                If Chk_Traer_Productos_De_Reemplazo.Checked Then

                    If MessageBoxEx.Show(Me, "Desea excluir a los productos hermanos de los productos seleccionados?",
                                         "Productos de reemplazo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then


                        Dim _Filtro_Pro = Generar_Filtro_IN(_TblFiltroProductos, "", "Codigo", False, False, "'")

                        If Chk_Traer_Productos_De_Reemplazo.Checked Then

                            Consulta_sql = "Select Arbol.Codigo_Nodo,Arbol.Codigo_Madre From 
                                " & _Global_BaseBk & "Zw_Prod_Asociacion Prod
                                Inner Join " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Arbol On Prod.Codigo_Nodo = Arbol.Codigo_Nodo
                                Where Arbol.Nodo_Raiz = " & _Nodo_Raiz_Asociados & " And Es_Seleccionable = 1 And Codigo In " & _Filtro_Pro

                            Dim _Tbl_Codigos_Madre As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                            Dim _Filtro_Codigos_Madre = Generar_Filtro_IN(_Tbl_Codigos_Madre, "", "Codigo_Nodo", False, False, "")

                            If _Tbl_Codigos_Madre.Rows.Count = 0 Then
                                _Filtro_Codigos_Madre = "('@@@')"
                            End If

                            Consulta_sql = "
                                Select Codigo 
                                Into #Paso
                                From " & _Global_BaseBk & "Zw_Prod_Asociacion 
                                Where Codigo_Nodo In " & _Filtro_Codigos_Madre & " And Para_filtro = 1

                                Insert Into #Paso (Codigo)
                                Select KOPR From MAEPR
                                Where KOPR In " & _Filtro_Pro & "

                                Select Cast(1 As Bit) As Chk,KOPR As Codigo,NOKOPR As Descripcion
                                FROM MAEPR
                                Where KOPR In (Select Distinct Codigo From #Paso)

                                Drop Table #Paso"

                            _TblFiltroProductos = _Sql.Fx_Get_Tablas(Consulta_sql)

                        End If


                    End If

                End If

            Else
                Rdb_Productos_Todos.Checked = True
                _TblFiltroProductos = Nothing
            End If

        End If

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Sub Sb_Habilitar_Deshabilitar_RDB()

        Sb_Habilitar_Layout(False)

        If Rdb_Productos_Todos.Checked Then

        ElseIf Rdb_Productos_Vendidos_Los_Ultimos_Dias.Checked Then

            Cmb_Cantidad_Dias_Ultima_Venta.Enabled = True

        ElseIf Rdb_Productos_Seleccionar.Checked Then

            BtnSeleccionarProductos.Enabled = True

        ElseIf Rdb_Productos_Familias_Marcas_Etc.Checked Then

            Btn_Seleccionar_Productos_X_Clasificacion_RD.Enabled = True

        ElseIf Rdb_Productos_Con_Movimientos_De_Venta.Checked Then

            Lbl_Desde.Enabled = True
            Lbl_Hasta.Enabled = True

            Dtp_Fecha_Movimientos_Desde.Enabled = True
            Dtp_Fecha_Movimientos_Hasta.Enabled = True

        ElseIf Rdb_Productos_Ranking.Checked Then

            Input_Productos_Ranking.Enabled = True
            Input_Productos_Ranking.Focus()

        ElseIf Rdb_Productos_Proveedor.Checked Then

            Btn_Buscar_Proveedor.Enabled = True
            Txt_Proveedor.Enabled = True
            Btn_Filtrar_ProdProveedor.Enabled = True

        End If

        If Rdb_Productos_Proveedor.Checked Then

            Try
                Dim _Koen = _RowProveedor.Item("KOEN")
                Dim _Suen = _RowProveedor.Item("SUEN")

                Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Entidades" & vbCrLf &
                               "Where CodEntidad = '" & _Koen & "' And CodSucEntidad = '" & _Suen & "'"
                Dim _Row_Entidades As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                If Not IsNothing(_Row_Entidades) Then

                    Dim _Metodo_Abastecer_Dias_Meses = NuloPorNro(_Row_Entidades.Item("Metodo_Abastecer_Dias_Meses"), 1)
                    Dim _Tiempo_Reposicion_Dias_Meses = NuloPorNro(_Row_Entidades.Item("Tiempo_Reposicion_Dias_Meses"), 1)

                    If _Metodo_Abastecer_Dias_Meses = 0 Then _Metodo_Abastecer_Dias_Meses = 1
                    If _Tiempo_Reposicion_Dias_Meses = 0 Then _Tiempo_Reposicion_Dias_Meses = 1

                    Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue = _Metodo_Abastecer_Dias_Meses
                    Cmb_Tiempo_Reposicion_Dias_Meses.SelectedValue = _Tiempo_Reposicion_Dias_Meses

                    Dim _Dias_a_Abastecer = NuloPorNro(_Row_Entidades.Item("Dias_a_Abastecer"), 30)
                    Dim _Tiempo_Reposicion = NuloPorNro(_Row_Entidades.Item("Tiempo_Reposicion"), 3)

                    If _Dias_a_Abastecer = 0 Then _Dias_a_Abastecer = 30
                    If _Tiempo_Reposicion = 0 Then _Tiempo_Reposicion = 3

                    Input_Dias_a_Abastecer.Value = _Dias_a_Abastecer
                    Input_Tiempo_Reposicion.Value = _Tiempo_Reposicion

                End If
            Catch ex As Exception

            End Try

        Else

            '   Tiempo para aprobicionamiento
            _Sql.Sb_Parametro_Informe_Sql(Cmb_Metodo_Abastecer_Dias_Meses, "Compras_Asistente", Cmb_Metodo_Abastecer_Dias_Meses.Name,
                                                 Class_SQLite.Enum_Type._ComboBox, Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue, False)
            _Sql.Sb_Parametro_Informe_Sql(Input_Dias_a_Abastecer, "Compras_Asistente",
                                                 Input_Dias_a_Abastecer.Name, Class_SQLite.Enum_Type._Double, Input_Dias_a_Abastecer.Value, False)

            '   Tiempo de reposición (Lead Time, _Actualizar)
            _Sql.Sb_Parametro_Informe_Sql(Cmb_Tiempo_Reposicion_Dias_Meses, "Compras_Asistente",
                                                 Cmb_Tiempo_Reposicion_Dias_Meses.Name, Class_SQLite.Enum_Type._ComboBox, Cmb_Tiempo_Reposicion_Dias_Meses.SelectedValue, False)
            _Sql.Sb_Parametro_Informe_Sql(Input_Tiempo_Reposicion, "Compras_Asistente",
                                                 Input_Tiempo_Reposicion.Name, Class_SQLite.Enum_Type._Double, Input_Tiempo_Reposicion.Value, False)

        End If

        Chk_Solo_Proveedores_CodAlternativo.Enabled = Not Rdb_Productos_Proveedor.Checked

        Btn_Imprimir_Maestra.Visible = Rdb_Productos_Proveedor.Checked
        Me.Refresh()

    End Sub

    Sub Sb_Habilitar_Layout(_Habilitar As Boolean)

        Lbl_Desde.Enabled = _Habilitar
        Lbl_Hasta.Enabled = _Habilitar

        Dtp_Fecha_Movimientos_Desde.Enabled = _Habilitar
        Dtp_Fecha_Movimientos_Hasta.Enabled = _Habilitar

        Input_Productos_Ranking.Enabled = _Habilitar

        BtnSeleccionarProductos.Enabled = _Habilitar
        Btn_Seleccionar_Productos_X_Clasificacion_RD.Enabled = _Habilitar
        Btn_Filtrar_ProdProveedor.Enabled = _Habilitar

        Cmb_Cantidad_Dias_Ultima_Venta.Enabled = _Habilitar

        Btn_Buscar_Proveedor.Enabled = _Habilitar
        Txt_Proveedor.Enabled = _Habilitar

        'Chk_IncluirUltCXprov.Enabled = _Habilitar
        'Layaut_UlProdXProv.Enabled = _Habilitar

    End Sub

    Private Function Fx_Cargar_Bodegas() As DataTable

        Dim _Tbl As DataTable

        Consulta_sql = "Select CAST( 1 AS bit) AS Chk,EMPRESA+KOSU+KOBO as Codigo,NOKOBO as Descripcion" & vbCrLf &
                       "From TABBO" & vbCrLf &
                       "Order by Codigo"

        _Tbl = _Sql.Fx_Get_Tablas(Consulta_sql)

        Return _Tbl

    End Function

    Function Fx_Traer_Productos() As DataTable

        Try

            If Rdb_Productos_Todos.Checked Then

                Consulta_sql = "Select KOPR From MAEPR Where 1 > 0" & vbCrLf

            ElseIf Rdb_Productos_Vendidos_Los_Ultimos_Dias.Checked Then

                Dim _FechaVenta_Ini, _FechaVenta_Fin As Date
                Dim _Dias As Integer

                If Rdb_Productos_Vendidos_Los_Ultimos_Dias.Checked Then
                    _Dias = Cmb_Cantidad_Dias_Ultima_Venta.SelectedValue
                End If

                _FechaVenta_Ini = DateAdd("d", -_Dias, Date.Now)
                _FechaVenta_Fin = Date.Now

                If _Dias = 1 Then
                    _FechaVenta_Ini = Date.Now
                    _FechaVenta_Fin = Date.Now
                End If

                Dim F1_ = Format(_FechaVenta_Ini, "yyyyMMdd")
                Dim F2_ = Format(_FechaVenta_Fin, "yyyyMMdd")

                Consulta_sql = "Select KOPR From MAEPR Where KOPR IN " &
                              "(Select Distinct KOPRCT FROM MAEDDO Ddo Inner Join MAEEDO Edo On Edo.IDMAEEDO = Ddo.IDMAEEDO" & Space(1) &
                               "Where Ddo.TIDO IN ('FCV','GDV','BLV','GDI','GDD','NCC')" & vbCrLf &
                               "And FEEMLI BETWEEN '" & F1_ & "' And '" & F2_ & "' And Edo.NUDONODEFI = 0)" & vbCrLf

                'Select DISTINCT KOPRCT FROM MAEDDO Ddo
                'Inner Join MAEEDO Edo On Edo.IDMAEEDO = Ddo.IDMAEEDO
                'WHERE Ddo.TIDO IN ('FCV','GDV','BLV','GDI','GDD','NCC') AND FEEMLI BETWEEN '20211123' AND '20211123' And Edo.NUDONODEFI = 1

            ElseIf Rdb_Productos_Con_Movimientos_De_Venta.Checked Then

                Dim F1_ = Format(Dtp_Fecha_Movimientos_Desde.Value, "yyyyMMdd")
                Dim F2_ = Format(Dtp_Fecha_Movimientos_Hasta.Value, "yyyyMMdd")

                Consulta_sql = "Select KOPR From MAEPR Where KOPR IN (SELECT DISTINCT KOPRCT FROM MAEDDO " &
                               "WHERE TIDO IN ('FCV','GDV','BLV','GDI','GDD','NCC')" & vbCrLf &
                               "AND FEEMLI BETWEEN '" & F1_ & "' AND '" & F2_ & "')" & vbCrLf

            ElseIf Rdb_Productos_Seleccionar.Checked Then

                If (_TblFiltroProductos Is Nothing) Or _TblFiltroProductos.Rows.Count = 0 Then
                    MessageBoxEx.Show(Me, "Esta marcada la opción [Seleccionar productos]." & vbCrLf &
                                      "No se selecciono ningún producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return Nothing
                End If

                _Filtro_Productos = Generar_Filtro_IN(_TblFiltroProductos, "", "Codigo", False, False, "'")

                Consulta_sql = "Select KOPR From MAEPR Where KOPR In " & _Filtro_Productos & vbCrLf


            ElseIf Rdb_Productos_Ranking.Checked Then

                Consulta_sql = "Select KOPR From MAEPR" & Space(1) &
                               "Where KOPR In (Select Top " & Input_Productos_Ranking.Value & " Codigo" & Space(1) &
                               "From Zw_Prod_Ranking Order By Ranking_Top)" & vbCrLf


            ElseIf Rdb_Productos_Proveedor.Checked Then

                If (_RowProveedor Is Nothing) Then
                    MessageBoxEx.Show(Me, "Falta seleccionar al proveedor", "Validación",
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return Nothing
                End If

                Dim _Endo As String = _RowProveedor.Item("KOEN")
                Dim _Suendo As String = _RowProveedor.Item("SUEN")

                Dim _Algunos_Productos As String = String.Empty

                If Not IsNothing(_TblFiltroProductos_Proveedor) Then

                    _Algunos_Productos = Generar_Filtro_IN(_TblFiltroProductos_Proveedor, "Chk", "Codigo", False, True, "'")
                    _Algunos_Productos = "And KOPR In " & _Algunos_Productos

                End If

                If Chk_Ent_Fisica.Checked Then
                    Consulta_sql = "Select Distinct KOPR From MAEPR" & Space(1) &
                                    "Where KOPR In (Select Distinct KOPRCT From MAEDDO Where ENDOFI = '" & _Endo & "') Or " & Space(1) &
                                    "KOPR In (Select distinct KOPR From TABCODAL Where KOEN = '" & _Endo & "')" & vbCrLf & _Algunos_Productos & vbCrLf
                Else
                    Consulta_sql = "Select Distinct KOPR From MAEPR" & Space(1) &
                                    "Where KOPR In (Select distinct KOPR From TABCODAL Where KOEN = '" & _Endo & "')" & vbCrLf & _Algunos_Productos & vbCrLf

                End If

            ElseIf Rdb_Productos_Familias_Marcas_Etc.Checked Then

                Consulta_sql = "Select KOPR From MAEPR Where 1 > 0" & vbCrLf

            End If


            '---- FILTROS -------------------------------

            Dim _Filtro_Rubros,
                _Filtro_Marcas,
                _Filtro_Zonas,
                _Filtro_SuperFamilias,
                _Filtro_ClasLibre,
                _Filtro_Bodega As String



            If _Filtro_Rubro_Todas Then
                _Filtro_Rubros = String.Empty
            Else
                _Filtro_Rubros = Generar_Filtro_IN(_Tbl_Filtro_Rubro, "Chk", "Codigo", False, True, "'")
                _Filtro_Rubros = "And RUPR In " & _Filtro_Rubros
                '_Filtro_Rubros = "And KOPR IN (Select KOPR From MAEPR Where RUPR In " & _Filtro_Rubros & ")"
            End If

            If _Filtro_Marcas_Todas Then
                _Filtro_Marcas = String.Empty
            Else
                _Filtro_Marcas = Generar_Filtro_IN(_Tbl_Filtro_Marcas, "Chk", "Codigo", False, True, "'")
                _Filtro_Marcas = "And MRPR In " & _Filtro_Marcas
                '_Filtro_Marcas = "And KOPR IN (Select KOPR From MAEPR Where MRPR In " & _Filtro_Marcas & ")"
            End If

            If _Filtro_Super_Familias_Todas Then
                _Filtro_SuperFamilias = String.Empty
            Else
                _Filtro_SuperFamilias = Generar_Filtro_IN(_Tbl_Filtro_Super_Familias, "Chk", "Codigo", False, True, "'")
                _Filtro_SuperFamilias = "And FMPR In " & _Filtro_SuperFamilias
                '_Filtro_SuperFamilias = "And KOPR IN (Select KOPR From MAEPR Where FMPR In " & _Filtro_SuperFamilias & ")"
            End If

            If _Filtro_Clalibpr_Todas Then
                _Filtro_ClasLibre = String.Empty
            Else
                _Filtro_ClasLibre = Generar_Filtro_IN(_Tbl_Filtro_Clalibpr, "Chk", "Codigo", False, True, "'")
                _Filtro_ClasLibre = "And CLALIBPR In " & _Filtro_ClasLibre
                '_Filtro_ClasLibre = "And KOPR IN (Select KOPR From MAEPR Where CLALIBPR In " & _Filtro_ClasLibre & ")"
            End If

            If _Filtro_Zonas_Todas Then
                _Filtro_Zonas = String.Empty
            Else
                _Filtro_Zonas = Generar_Filtro_IN(_Tbl_Filtro_Zonas, "Chk", "Codigo", False, True, "'")
                _Filtro_Zonas = "And ZONAPR In " & _Filtro_Zonas
                '_Filtro_Zonas = "And KOPR IN (Select KOPR From MAEPR Where ZONAPR In " & _Filtro_Zonas & ")"
            End If

            '---------------------------

            Dim Fl As String = _Filtro_Productos

            Consulta_sql += _Filtro_Bodega & vbCrLf &
                            _Filtro_ClasLibre & vbCrLf &
                            _Filtro_Marcas & vbCrLf &
                            _Filtro_Rubros & vbCrLf &
                            _Filtro_SuperFamilias & vbCrLf &
                            _Filtro_Zonas

            Consulta_sql += vbCrLf & "And TIPR In ('FPN','FIN')"

            Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            Dim _Count = _Tbl.Rows.Count

            If Not CBool(_Count) Then
                _Tbl = Nothing
            End If

            Return _Tbl


        Catch ex As Exception
            'MsgBox(ex.Message)
            'myTrans.Rollback()
            MessageBoxEx.Show(Me, ex.Message, "Transaccion desecha", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Function

    Private Sub RdbProductos_Ranking_CheckedChanged(sender As System.Object, e As System.EventArgs)
        If Rdb_Productos_Ranking.Checked Then
            Input_Productos_Ranking.Focus()
        End If
    End Sub

    Private Sub Rdb_Productos_Proveedor_CheckedChanged(sender As System.Object, e As System.EventArgs)
        If Rdb_Productos_Proveedor.Checked Then
            Chk_Traer_Productos_De_Reemplazo.Checked = False
            Chk_Traer_Productos_De_Reemplazo.Enabled = False
            Btn_Imprimir_Maestra.Visible = True
        Else
            Chk_Traer_Productos_De_Reemplazo.Enabled = True
            Btn_Imprimir_Maestra.Visible = False
        End If
        Me.Refresh()
    End Sub


    Private Sub Cmb_Dias_Abastecer_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

        Dim _Valor As Integer = Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue

        Cmb_Tiempo_Reposicion_Dias_Meses.SelectedValue = _Valor

        Select Case _Valor

            Case 1
                Input_Dias_a_Abastecer.MaxValue = 60
                Input_Dias_a_Abastecer.Value = 7
                Input_Tiempo_Reposicion.MaxValue = 60
                Input_Tiempo_Reposicion.Value = 1
            Case 7
                Input_Dias_a_Abastecer.MaxValue = 4
                Input_Dias_a_Abastecer.Value = 1
                Input_Tiempo_Reposicion.MaxValue = 4
                Input_Tiempo_Reposicion.Value = 1
            Case 30
                Input_Dias_a_Abastecer.MaxValue = 6
                Input_Dias_a_Abastecer.Value = 1
                Input_Tiempo_Reposicion.MaxValue = 6
                Input_Tiempo_Reposicion.Value = 1
            Case Else

        End Select

    End Sub
    Private Sub Cmb_Tiempo_Reposicion_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

        Dim _Valor As Integer = Cmb_Tiempo_Reposicion_Dias_Meses.SelectedValue

        Select Case _Valor

            Case 1
                Input_Tiempo_Reposicion.MaxValue = 60
                Input_Tiempo_Reposicion.Value = 7
            Case 7
                Input_Tiempo_Reposicion.MaxValue = 4
                Input_Tiempo_Reposicion.Value = 1
            Case 30
                Input_Tiempo_Reposicion.MaxValue = 6
                Input_Tiempo_Reposicion.Value = 1
            Case Else

        End Select

    End Sub

    Private Sub Btn_Bodega_Vta_Estudio_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Bodega_Vta_Estudio.Click

        Dim Fm As New Frm_Filtro_Especial_Informes(Frm_Filtro_Especial_Informes._Tabla_Fl._Bodegas, False)
        Fm.Pro_Tbl_Filtro = _TblBodVenta

        Fm.ShowDialog(Me)

        If Fm.Pro_Filtrar Then

            _TblBodVenta = Fm.Pro_Tbl_Filtro

            If Fm.Pro_Filtrar_Todo Then
                _Filtro_Bodegas_Est_Vta_Todas = True
            Else
                If (_TblBodCompra Is Nothing) Then
                    _Filtro_Bodegas_Est_Vta_Todas = True
                Else
                    _Filtro_Bodegas_Est_Vta_Todas = False
                End If
            End If

        End If
        Fm.Dispose()

    End Sub

    Private Sub Btn_Ent_Excluidas_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Ent_Excluidas.Click
        If Fx_Tiene_Permiso(Me, "CfEnt016") Then
            Dim Fm As New Frm_EntExcluidas
            Fm.ShowInTaskbar = False
            Fm.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If
    End Sub

    Private Sub Btn_Seleccionar_Productos_X_Clasificacion_RD_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Seleccionar_Productos_X_Clasificacion_RD.Click

        Dim Fm As New Frm_Filtro_Especial_Productos

        Fm.Pro_Filtro_Clalibpr_Todas = _Filtro_Clalibpr_Todas
        Fm.Pro_Filtro_Marcas_Todas = _Filtro_Marcas_Todas
        Fm.Pro_Filtro_Rubro_Todas = _Filtro_Rubro_Todas
        Fm.Pro_Filtro_Super_Familias_Todas = _Filtro_Super_Familias_Todas
        Fm.Pro_Filtro_Zonas_Todas = _Filtro_Zonas_Todas

        Fm.Pro_Tbl_Filtro_Clalibpr = _Tbl_Filtro_Clalibpr
        Fm.Pro_Tbl_Filtro_Marcas = _Tbl_Filtro_Marcas
        Fm.Pro_Tbl_Filtro_Rubro = _Tbl_Filtro_Rubro
        Fm.Pro_Tbl_Filtro_Super_Familias = _Tbl_Filtro_Super_Familias
        Fm.Pro_Tbl_Filtro_Zonas = _Tbl_Filtro_Zonas

        Fm.ShowDialog(Me)

        _Tbl_Filtro_Clalibpr = Fm.Pro_Tbl_Filtro_Clalibpr
        _Tbl_Filtro_Marcas = Fm.Pro_Tbl_Filtro_Marcas
        _Tbl_Filtro_Rubro = Fm.Pro_Tbl_Filtro_Rubro
        _Tbl_Filtro_Super_Familias = Fm.Pro_Tbl_Filtro_Super_Familias
        _Tbl_Filtro_Zonas = Fm.Pro_Tbl_Filtro_Zonas

        _Filtro_Clalibpr_Todas = Fm.Pro_Filtro_Clalibpr_Todas
        _Filtro_Marcas_Todas = Fm.Pro_Filtro_Marcas_Todas
        _Filtro_Rubro_Todas = Fm.Pro_Filtro_Rubro_Todas
        _Filtro_Super_Familias_Todas = Fm.Pro_Filtro_Super_Familias_Todas
        _Filtro_Zonas_Todas = Fm.Pro_Filtro_Zonas_Todas

        Fm.Dispose()

    End Sub

    Private Sub Btn_Bodegas_Stock_Click_1(sender As System.Object, e As System.EventArgs) Handles Btn_Bodegas_Stock.Click
        Dim Fm As New Frm_Filtro_Especial_Informes(Frm_Filtro_Especial_Informes._Tabla_Fl._Bodegas, False)
        Fm.Pro_Tbl_Filtro = _TblBodCompra

        Fm.ShowDialog(Me)

        If Fm.Pro_Filtrar Then

            _TblBodCompra = Fm.Pro_Tbl_Filtro

            If Fm.Pro_Filtrar_Todo Then
                _Filtro_Bodegas_Todas = True
            Else
                If (_TblBodCompra Is Nothing) Then
                    _Filtro_Bodegas_Todas = True
                Else
                    _Filtro_Bodegas_Todas = False
                End If
            End If

        End If
        Fm.Dispose()
    End Sub

    Private Sub Chk_Rotacion_Con_Ent_Excluidas_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Chk_Rotacion_Con_Ent_Excluidas.CheckedChanged
        If Chk_Rotacion_Con_Ent_Excluidas.Checked Then
            If Not Fx_Tiene_Permiso(Me, "Comp0080",, Me.Visible) Then
                Chk_Rotacion_Con_Ent_Excluidas.Checked = False
            End If
        End If
    End Sub

    Private Sub Chk_Procesar_Uno_A_Uno_CheckedChanged(sender As Object, e As CheckBoxChangeEventArgs) Handles Chk_Procesar_Uno_A_Uno.CheckedChanged
        If Not Chk_Procesar_Uno_A_Uno.Checked Then
            If Not Fx_Tiene_Permiso(Me, "Comp0093",, Me.Visible) Then
                Chk_Procesar_Uno_A_Uno.Checked = True
            End If
        End If
    End Sub

    Private Sub Btn_Imprimir_Maestra_Click(sender As Object, e As EventArgs) Handles Btn_Imprimir_Maestra.Click

        If Not IsNothing(_RowProveedor) Then

            Dim _CodProveedor = _RowProveedor.Item("KOEN")
            Dim _SucProveedor = _RowProveedor.Item("SUEN")

            Consulta_sql = "Select Count(*) As Items
                            From TABCODAL Td 
                            Inner Join MAEPR Mp On Td.KOPR = Mp.KOPR
                            Where KOEN = '" & _CodProveedor & "' And BLOQUEAPR In ('','V')"

            Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim _Reg As Boolean = CBool(_Row.Item("Items"))

            If _Reg Then

                Dim _Ud = 1

                If Rdb_Ud2_Compra.Checked Then
                    _Ud = 2
                End If

                Dim _Clas_Imprimir_AsisCompra As New Clas_Imprimir_AsisCompra()
                If _Clas_Imprimir_AsisCompra.Fx_Ejecutar_Impresion(_CodProveedor, _SucProveedor, _Ud) Then

                    Dim _Imprimir_Negrita As Boolean

                    If MessageBoxEx.Show(Me, "¿Imprimir el detalle en Negrita?", "Opciones de impresión", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                        _Imprimir_Negrita = True

                    End If
                    _Clas_Imprimir_AsisCompra.Imprimir_Negrita = _Imprimir_Negrita
                    _Clas_Imprimir_AsisCompra.Fx_Imprimir_Archivo(Me, "")
                End If

            Else
                MessageBoxEx.Show(Me, "No se encontraron códigos en maestra de códigos alternativos para la entidad", "Información",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        Else
            MessageBoxEx.Show(Me, "Falta seleccionar al proveedor", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Sub Sb_Actualizar_Stock_Desde_Una_Empresa_A_Otra(_Tbl_Productos As DataTable)

        If Not _Sql.Fx_Existe_Tabla(_Global_BaseBk & "Zw_DbExt_Conexion") Then
            Return
        End If

        If Not _Sql.Fx_Existe_Tabla(_Global_BaseBk & "Zw_DbExt_Maest") Then
            Return
        End If

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_DbExt_Maest Where Activo = 1"
        Dim _Row_DbExtMaest As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row_DbExtMaest) Then
            Return
        End If

        Dim _Id_Conexion = _Row_DbExtMaest.Item("Id_Conexion")

        Dim _Empresa_Ori = _Row_DbExtMaest.Item("Empresa_Ori")
        Dim _Sucursal_Ori = _Row_DbExtMaest.Item("Sucursal_Ori")
        Dim _Bodega_Ori = _Row_DbExtMaest.Item("Bodega_Ori")

        Dim _Empresa_Des = _Row_DbExtMaest.Item("Empresa_Des")
        Dim _Sucursal_Des = _Row_DbExtMaest.Item("Sucursal_Des")
        Dim _Bodega_Des = _Row_DbExtMaest.Item("Bodega_Des")

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_DbExt_Conexion Where Id = " & _Id_Conexion
        Dim _Row_DnExt As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Servidor = _Row_DnExt.Item("Servidor")
        Dim _Puerto = _Row_DnExt.Item("Puerto")
        Dim _Usuario = _Row_DnExt.Item("Usuario")
        Dim _Clave = _Row_DnExt.Item("Clave")
        Dim _BaseDeDatos = _Row_DnExt.Item("BaseDeDatos")

        Dim _ServidorPuerto As String = _Servidor

        If Not String.IsNullOrEmpty(_Puerto) Then
            _ServidorPuerto = _Servidor & "," & _Puerto
        End If

        Dim _Cadena_ConexionSQL_Server_Origen = "data " &
                                        "source = " & _ServidorPuerto & "; " &
                                        "initial catalog = " & _BaseDeDatos & "; " &
                                        "user id = " & _Usuario & "; " &
                                        "password = " & _Clave

        Dim Fm As New Frm_Importar_Stock_OEBD(_Tbl_Productos, _Cadena_ConexionSQL_Server_Origen, "KOPR")
        Fm.Text = "Actualización de Stock desde una empresa a otra"
        Fm.Empresa_Ori = _Empresa_Ori
        Fm.Sucursal_Ori = _Sucursal_Ori
        Fm.Bodega_Ori = _Bodega_Ori
        Fm.Empresa_Des = _Empresa_Des
        Fm.Sucursal_Des = _Sucursal_Des
        Fm.Bodega_Des = _Bodega_Des
        Fm.Ejecutar_Automaticamente = True
        Fm.SoloProductosConStock = _Modo_NVI
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Filtrar_ProdProveedor_Click(sender As Object, e As EventArgs) Handles Btn_Filtrar_ProdProveedor.Click

        If (_RowProveedor Is Nothing) Then
            MessageBoxEx.Show(Me, "Falta seleccionar al proveedor", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Koen = _RowProveedor.Item("KOEN")

        Dim _Sql_Filtro_Condicion_Extra = "And TIPR = 'FPN' And KOPR In (Select KOPR From TABCODAL Where KOEN = '" & _Koen & "')"


        Dim Fm As New Frm_Filtro_Especial_Productos

        Fm.Pro_Filtro_Extra_Productos = _Sql_Filtro_Condicion_Extra
        Fm.Pro_Filtro_Extra_Marcas = "And KOMR In (Select MRPR From MAEPR Where KOPR In (Select KOPR From MAEPR Where 1>0 " & _Sql_Filtro_Condicion_Extra & "))"
        Fm.Pro_Filtro_Extra_Super_Familias = "And KOFM In (Select FMPR From MAEPR Where KOPR In (Select KOPR From MAEPR Where 1>0 " & _Sql_Filtro_Condicion_Extra & "))"
        Fm.Pro_Filtro_Extra_Rubro_Productos = "And KORU In (Select RUPR From MAEPR Where KOPR In (Select KOPR From MAEPR Where 1>0 " & _Sql_Filtro_Condicion_Extra & "))"
        Fm.Pro_Filtro_Extra_Clalibpr = "And KOCARAC In (Select CLALIBPR From MAEPR Where KOPR In (Select KOPR From MAEPR Where 1>0 " & _Sql_Filtro_Condicion_Extra & "))"
        Fm.Pro_Filtro_Extra_Zonas = "And KOZO In (Select ZONAPR From MAEPR Where KOPR In (Select KOPR From MAEPR Where 1>0 " & _Sql_Filtro_Condicion_Extra & "))"


        Fm.Pro_Filtro_Productos_Todos = _Filtro_Productos_Todos
        Fm.Pro_Filtro_Clalibpr_Todas = _Filtro_Clalibpr_Todas
        Fm.Pro_Filtro_Marcas_Todas = _Filtro_Marcas_Todas
        Fm.Pro_Filtro_Rubro_Todas = _Filtro_Rubro_Todas
        Fm.Pro_Filtro_Super_Familias_Todas = _Filtro_Super_Familias_Todas
        Fm.Pro_Filtro_Zonas_Todas = _Filtro_Zonas_Todas

        Fm.Pro_Tbl_Filtro_Productos = _Tbl_Filtro_Productos
        Fm.Pro_Tbl_Filtro_Clalibpr = _Tbl_Filtro_Clalibpr
        Fm.Pro_Tbl_Filtro_Marcas = _Tbl_Filtro_Marcas
        Fm.Pro_Tbl_Filtro_Rubro = _Tbl_Filtro_Rubro
        Fm.Pro_Tbl_Filtro_Super_Familias = _Tbl_Filtro_Super_Familias
        Fm.Pro_Tbl_Filtro_Zonas = _Tbl_Filtro_Zonas

        Fm.ShowDialog(Me)

        _Tbl_Filtro_Productos = Fm.Pro_Tbl_Filtro_Productos
        _Tbl_Filtro_Clalibpr = Fm.Pro_Tbl_Filtro_Clalibpr
        _Tbl_Filtro_Marcas = Fm.Pro_Tbl_Filtro_Marcas
        _Tbl_Filtro_Rubro = Fm.Pro_Tbl_Filtro_Rubro
        _Tbl_Filtro_Super_Familias = Fm.Pro_Tbl_Filtro_Super_Familias
        _Tbl_Filtro_Zonas = Fm.Pro_Tbl_Filtro_Zonas

        _Filtro_Productos_Todos = Fm.Pro_Filtro_Productos_Todos
        _Filtro_Clalibpr_Todas = Fm.Pro_Filtro_Clalibpr_Todas
        _Filtro_Marcas_Todas = Fm.Pro_Filtro_Marcas_Todas
        _Filtro_Rubro_Todas = Fm.Pro_Filtro_Rubro_Todas
        _Filtro_Super_Familias_Todas = Fm.Pro_Filtro_Super_Familias_Todas
        _Filtro_Zonas_Todas = Fm.Pro_Filtro_Zonas_Todas

        Fm.Dispose()

        '---- FILTROS -------------------------------

        Dim _Filtro_Productos = String.Empty
        Dim _Filtro_Rubros = String.Empty
        Dim _Filtro_Marcas = String.Empty
        Dim _Filtro_Zonas = String.Empty
        Dim _Filtro_SuperFamilias = String.Empty
        Dim _Filtro_ClasLibre = String.Empty
        Dim _Filtro_Bodega = String.Empty


        If _Filtro_Productos_Todos Then

            If Not _Filtro_Rubro_Todas Then
                _Filtro_Rubros = Generar_Filtro_IN(_Tbl_Filtro_Rubro, "Chk", "Codigo", False, True, "'")
                _Filtro_Rubros = "And KOPR IN (Select KOPR From MAEPR Where RUPR In " & _Filtro_Rubros & ")"
            End If

            If Not _Filtro_Marcas_Todas Then
                _Filtro_Marcas = Generar_Filtro_IN(_Tbl_Filtro_Marcas, "Chk", "Codigo", False, True, "'")
                _Filtro_Marcas = "And KOPR IN (Select KOPR From MAEPR Where MRPR In " & _Filtro_Marcas & ")"
            End If

            If Not _Filtro_Super_Familias_Todas Then
                _Filtro_SuperFamilias = Generar_Filtro_IN(_Tbl_Filtro_Super_Familias, "Chk", "Codigo", False, True, "'")
                _Filtro_SuperFamilias = "And KOPR IN (Select KOPR From MAEPR Where FMPR In " & _Filtro_SuperFamilias & ")"
            End If

            If Not _Filtro_Clalibpr_Todas Then
                _Filtro_ClasLibre = Generar_Filtro_IN(_Tbl_Filtro_Clalibpr, "Chk", "Codigo", False, True, "'")
                _Filtro_ClasLibre = "And KOPR IN (Select KOPR From MAEPR Where CLALIBPR In " & _Filtro_ClasLibre & ")"
            End If

            If Not _Filtro_Zonas_Todas Then
                _Filtro_Zonas = Generar_Filtro_IN(_Tbl_Filtro_Zonas, "Chk", "Codigo", False, True, "'")
                _Filtro_Zonas = "And KOPR IN (Select KOPR From MAEPR Where ZONAPR In " & _Filtro_Zonas & ")"
            End If

        Else

            If IsNothing(_Tbl_Filtro_Productos) Then
                Return
            End If

            _Filtro_Productos = Generar_Filtro_IN(_Tbl_Filtro_Productos, "Chk", "Codigo", False, True, "'")
            _Filtro_Productos = "And KOPR IN " & _Filtro_Productos

        End If

        '---------------------------

        Consulta_sql = "Select Cast(1 As Bit) As Chk,KOPR as Codigo From MAEPR Where 1 > 0" & vbCrLf &
                        _Filtro_Productos & vbCrLf &
                        _Filtro_Bodega & vbCrLf &
                        _Filtro_ClasLibre & vbCrLf &
                        _Filtro_Marcas & vbCrLf &
                        _Filtro_Rubros & vbCrLf &
                        _Filtro_SuperFamilias & vbCrLf &
                        _Filtro_Zonas

        _TblFiltroProductos_Proveedor = _Sql.Fx_Get_Tablas(Consulta_sql)

        'If Rdb_Traer_No_Bloqueados.Checked Then
        '    Consulta_sql += Rdb_Traer_No_Bloqueados.Tag.ToString
        'End If

        'If Rdb_Traer_Bloqueados_Compras.Checked Then
        '    Consulta_sql += Rdb_Traer_Bloqueados_Compras.Tag.ToString
        'End If

        'If Rdb_Traer_Bloqueados_Venta.Checked Then
        '    Consulta_sql += Rdb_Traer_Bloqueados_Venta.Tag.ToString
        'End If

        'If Rdb_Traer_Bloqueados_Compra_y_Venta.Checked Then
        '    Consulta_sql += Rdb_Traer_Bloqueados_Compra_y_Venta.Tag.ToString
        'End If

        'If Rdb_Traer_Bloqueados_Compra_Venta_y_Produccion.Checked Then
        '    Consulta_sql += Rdb_Traer_Bloqueados_Compra_Venta_y_Produccion.Tag.ToString
        'End If








        'Dim _Filtrar As New Clas_Filtros_Random(Me)

        'If _Filtrar.Fx_Filtrar(_TblFiltroProductos_Proveedor,
        '                       Clas_Filtros_Random.Enum_Tabla_Fl._Productos, _Sql_Filtro_Condicion_Extra,
        '                       False, False) Then

        '    _TblFiltroProductos_Proveedor = _Filtrar.Pro_Tbl_Filtro
        '    If _Filtrar.Pro_Filtro_Todas Then
        '        _TblFiltroProductos_Proveedor = Nothing
        '    End If

        'End If

    End Sub

    Sub Sb_Habilitar_Desabilitar_Controles(_Habilitar As Boolean)

        Grupo_Productos.Enabled = _Habilitar
        STabConfiguracion.Enabled = _Habilitar
        BtnProcesarInf.Enabled = _Habilitar
        Chk_Procesar_Uno_A_Uno.Enabled = _Habilitar
        Btn_Imprimir_Maestra.Enabled = _Habilitar
        Btn_Cancelar.Visible = (Chk_Procesar_Uno_A_Uno.Checked And Not _Habilitar)
        Btn_Cancelar.Enabled = Not _Habilitar
        Circular_Progress1.Visible = Not _Habilitar

        Me.Refresh()

    End Sub

    Private Sub Btn_Cancelar_Click(sender As Object, e As EventArgs) Handles Btn_Cancelar.Click
        Btn_Cancelar.Enabled = False
        If MessageBoxEx.Show(Me, "¿Esta seguro de querer cancelar esta acción?", "Cancelar proceso",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Lbl_Status.Text = "Cancelando el proceso, por favor espere..."
            Barra_Progreso.Value = 0
            System.Windows.Forms.Application.DoEvents()
            Me.Refresh()
            _Cancelar = True
        Else
            Btn_Cancelar.Enabled = True
        End If
    End Sub

    Private Sub Timer_Ejecucion_Automatica_Tick(sender As Object, e As EventArgs) Handles Timer_Ejecucion_Automatica.Tick
        Timer_Ejecucion_Automatica.Stop()
        Call BtnProcesarInf_Click(Nothing, Nothing)
        Me.Close()
    End Sub

    Private Sub Txt_DbExt_Nombre_Conexion_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_DbExt_Nombre_Conexion.ButtonCustomClick

        Dim _RowConexion As DataRow

        Consulta_sql = "Select *,'****' As [Password] From " & _Global_BaseBk & "Zw_DbExt_Conexion"
        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        If Not CBool(_Tbl.Rows.Count) Then
            MessageBoxEx.Show(Me, "No hay conexiones disponibles" & vbCrLf & vbCrLf &
                              "Dene ir a la Configuración -> Conexiones -> Conexiones a otras bases de datos externas (para fines migratorios de información)" & vbCrLf &
                              "Informe de esta situación al administrador del sistema", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim Fm As New Frm_ConexOtrasBases
        Fm.Seleccionar = True
        Fm.ShowDialog(Me)
        _RowConexion = Fm.RowConexion
        Fm.Dispose()

        If Not IsNothing(_RowConexion) Then

            Dim _ErrorBodegas As Boolean

            If IsDBNull(_RowConexion.Item("Empresa_Ori")) Or IsDBNull(_RowConexion.Item("Empresa_Des")) Then
                _ErrorBodegas = True
            End If

            If Not _ErrorBodegas Then
                If String.IsNullOrEmpty(_RowConexion.Item("Empresa_Ori").ToString.Trim) Or
                    String.IsNullOrEmpty(_RowConexion.Item("Empresa_Des").ToString.Trim) Then
                    _ErrorBodegas = True
                End If
            End If

            If _ErrorBodegas Then
                MessageBoxEx.Show(Me, "Faltan las bodegas de origen o destino para hacer la gestión" & vbCrLf & vbCrLf &
                                  "Dene ir a la Configuración -> Conexiones -> Conexiones a otras bases de datos externas (para fines migratorios de información)" & vbCrLf &
                                  "Informe de esta situación al administrador del sistema", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            Txt_DbExt_Nombre_Conexion.Tag = _RowConexion.Item("Id")
            Txt_DbExt_Nombre_Conexion.Text = _RowConexion.Item("Nombre_Conexion")
            Txt_DbExt_NombreBod_Ori.Text = _RowConexion.Item("Empresa_Ori") & "-" & _RowConexion.Item("Sucursal_Ori") & "-" & _RowConexion.Item("Bodega_Ori") & " (" & _RowConexion.Item("NombreBod_Ori") & ")"
            Txt_DbExt_NombreBod_Des.Text = _RowConexion.Item("Empresa_Des") & "-" & _RowConexion.Item("Sucursal_Des") & "-" & _RowConexion.Item("Bodega_Des") & " (" & _RowConexion.Item("NombreBod_Des") & ")"

        End If

    End Sub

    Private Sub Btn_Buscar_ProvEspecial_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_ProvEspecial.Click

        If Not CBool(Txt_DbExt_Nombre_Conexion.Tag) Then
            MessageBoxEx.Show(Me, "Falta la conexión externa", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim Fm As New Frm_BuscarEntidad_Mt(False)
        Fm.ShowInTaskbar = False
        Fm.ShowDialog(Me)

        If Fm.Pro_Entidad_Seleccionada Then

            _RowProveedor_Especial = Fm.Pro_RowEntidad
            Txt_ProvEspecial.Text = _RowProveedor_Especial.Item("KOEN").ToString.Trim & " - " & _RowProveedor_Especial.Item("NOKOEN").ToString.Trim

        End If
        Fm.Dispose()

    End Sub

    Private Sub Txt_DbExt_Nombre_Conexion_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_DbExt_Nombre_Conexion.ButtonCustom2Click

        If String.IsNullOrEmpty(Txt_DbExt_Nombre_Conexion.Text) Then
            Txt_DbExt_Nombre_Conexion.Tag = 0
            Txt_DbExt_Nombre_Conexion.Text = String.Empty
            Txt_DbExt_NombreBod_Ori.Text = String.Empty
            Txt_DbExt_NombreBod_Des.Text = String.Empty
            _RowProveedor_Especial = Nothing
            Txt_ProvEspecial.Text = String.Empty
            Beep()
            Return
        End If
        If MessageBoxEx.Show(Me, "¿Confirma quitar esta conexión?", "Quitar conexión externa",
                             MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) = DialogResult.Yes Then
            Txt_DbExt_Nombre_Conexion.Tag = 0
            Txt_DbExt_Nombre_Conexion.Text = String.Empty
            Txt_DbExt_NombreBod_Ori.Text = String.Empty
            Txt_DbExt_NombreBod_Des.Text = String.Empty
            _RowProveedor_Especial = Nothing
            Txt_ProvEspecial.Text = String.Empty
        End If

    End Sub

    Private Sub Chk_DbExt_SincronizarPRBD_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_DbExt_SincronizarPRBD.CheckedChanged
        Grupo_DbExt.Enabled = Chk_DbExt_SincronizarPRBD.Checked
    End Sub

    Private Sub Txt_CtaCorreoEnvioAutomatizado_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_CtaCorreoEnvioAutomatizado_OCC.ButtonCustomClick

        Dim _Row_Email As DataRow

        Dim Fm As New Frm_Correos_SMTP
        Fm.Pro_Seleccionar = True
        Fm.ShowDialog(Me)
        _Row_Email = Fm.Pro_Row_Fila_Seleccionada
        Fm.Dispose()

        If Not IsNothing(_Row_Email) Then
            Txt_CtaCorreoEnvioAutomatizado_OCC.Tag = _Row_Email.Item("Id")
            Txt_CtaCorreoEnvioAutomatizado_OCC.Text = _Row_Email.Item("Nombre_Correo").ToString.Trim
        End If

    End Sub

    Private Sub Txt_NombreFormato_PDF_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_NombreFormato_PDF_OCC.ButtonCustomClick

        Dim Fm As New Frm_Seleccionar_Formato("OCC")

        If CBool(Fm.Tbl_Formatos.Rows.Count) Then

            Fm.ShowDialog(Me)
            If Fm.Formato_Seleccionado Then
                Txt_NombreFormato_PDF_OCC.Tag = Fm.Row_Formato_Seleccionado.Item("NombreFormato").ToString.Trim
                Txt_NombreFormato_PDF_OCC.Text = Fm.Row_Formato_Seleccionado.Item("NombreFormato").ToString.Trim
            End If

        Else
            MessageBoxEx.Show(Me, "No existen formatos adicionales para este documento", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

        Fm.Dispose()

    End Sub

    Private Sub Txt_NombreFormato_PDF_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_NombreFormato_PDF_OCC.ButtonCustom2Click
        If MessageBoxEx.Show(Me, "Confirma quitar el formato", "Quitar formato", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Txt_NombreFormato_PDF_OCC.Tag = String.Empty
            Txt_NombreFormato_PDF_OCC.Text = String.Empty
        End If
    End Sub

    Private Sub Txt_CtaCorreoEnvioAutomatizado_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_CtaCorreoEnvioAutomatizado_OCC.ButtonCustom2Click
        If MessageBoxEx.Show(Me, "Confirma quitar el correo", "Quitar correo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Txt_CtaCorreoEnvioAutomatizado_OCC.Tag = 0
            Txt_CtaCorreoEnvioAutomatizado_OCC.Text = String.Empty
        End If
    End Sub

    Private Sub Btn_Bodega_NVI_Estudio_Click(sender As Object, e As EventArgs) Handles Btn_Bodega_NVI_Estudio.Click

        Dim Fm As New Frm_Filtro_Especial_Informes(Frm_Filtro_Especial_Informes._Tabla_Fl._Bodegas, False)
        Fm.Pro_Tbl_Filtro = _TblBodReabastecen

        Fm.ShowDialog(Me)

        If Fm.Pro_Filtrar Then

            _TblBodReabastecen = Fm.Pro_Tbl_Filtro

            'If Fm.Pro_Filtrar_Todo Then
            '    _Filtro_Bodegas_Est_Vta_Todas = True
            'Else
            '    If (_TblBodCompra Is Nothing) Then
            '        _Filtro_Bodegas_Est_Vta_Todas = True
            '    Else
            '        _Filtro_Bodegas_Est_Vta_Todas = False
            '    End If
            'End If

        End If

        Fm.Dispose()

    End Sub

    Private Sub Btn_GrabarConfiguracion_Click(sender As Object, e As EventArgs) Handles Btn_GrabarConfiguracion.Click

        Me.Enabled = False
        Sb_Parametros_Informe_Sql(True)
        Me.Enabled = True
        MessageBoxEx.Show(Me, "Configuración guardada correctamente", "Guardar configuración", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()

    End Sub

    Private Sub Txt_CtaCorreoEnvioAutomatizado_NVI_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_CtaCorreoEnvioAutomatizado_NVI.ButtonCustomClick

        Dim _Row_Email As DataRow

        Dim Fm As New Frm_Correos_SMTP
        Fm.Pro_Seleccionar = True
        Fm.ShowDialog(Me)
        _Row_Email = Fm.Pro_Row_Fila_Seleccionada
        Fm.Dispose()

        If Not IsNothing(_Row_Email) Then
            Txt_CtaCorreoEnvioAutomatizado_NVI.Tag = _Row_Email.Item("Id")
            Txt_CtaCorreoEnvioAutomatizado_NVI.Text = _Row_Email.Item("Nombre_Correo").ToString.Trim
        End If

    End Sub

    Private Sub Txt_CtaCorreoEnvioAutomatizado_NVI_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_CtaCorreoEnvioAutomatizado_NVI.ButtonCustom2Click
        If MessageBoxEx.Show(Me, "Confirma quitar el correo", "Quitar correo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Txt_CtaCorreoEnvioAutomatizado_NVI.Tag = 0
            Txt_CtaCorreoEnvioAutomatizado_NVI.Text = String.Empty
        End If
    End Sub

    Private Sub Txt_NombreFormato_PDF_NVI_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_NombreFormato_PDF_NVI.ButtonCustomClick

        Dim Fm As New Frm_Seleccionar_Formato("NVI")

        If CBool(Fm.Tbl_Formatos.Rows.Count) Then

            Fm.ShowDialog(Me)
            If Fm.Formato_Seleccionado Then
                Txt_NombreFormato_PDF_NVI.Tag = Fm.Row_Formato_Seleccionado.Item("NombreFormato").ToString.Trim
                Txt_NombreFormato_PDF_NVI.Text = Fm.Row_Formato_Seleccionado.Item("NombreFormato").ToString.Trim
            End If

        Else
            MessageBoxEx.Show(Me, "No existen formatos adicionales para este documento", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

        Fm.Dispose()

    End Sub

    Private Sub Txt_NombreFormato_PDF_NVI_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_NombreFormato_PDF_NVI.ButtonCustom2Click
        If MessageBoxEx.Show(Me, "Confirma quitar el formato", "Quitar formato", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Txt_NombreFormato_PDF_NVI.Tag = String.Empty
            Txt_NombreFormato_PDF_NVI.Text = String.Empty
        End If
    End Sub

    Private Sub Btn_ProductosExcluidos_Click(sender As Object, e As EventArgs) Handles Btn_ProductosExcluidos.Click

        Dim _Sql_Filtro_Condicion_Extra = "And TIPR In ('FPN','FIN')"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_TblFiltroProductosExcluidos,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Productos, _Sql_Filtro_Condicion_Extra,
                               False, False) Then

            Dim _Nodo_Raiz_Asociados As Integer = _Global_Row_Configuracion_General.Item("Nodo_Raiz_Asociados")

            _TblFiltroProductosExcluidos = _Filtrar.Pro_Tbl_Filtro

            If Not _Filtrar.Pro_Filtro_Todas Then

                If Chk_Traer_Productos_De_Reemplazo.Checked Then

                    If MessageBoxEx.Show(Me, "Desea excluir a los productos hermanos de los productos seleccionados?",
                                         "Productos de reemplazo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then


                        Dim _Filtro_Pro = Generar_Filtro_IN(_TblFiltroProductosExcluidos, "", "Codigo", False, False, "'")

                        If Chk_Traer_Productos_De_Reemplazo.Checked Then

                            Consulta_sql = "Select Arbol.Codigo_Nodo,Arbol.Codigo_Madre From 
                                " & _Global_BaseBk & "Zw_Prod_Asociacion Prod
                                Inner Join " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Arbol On Prod.Codigo_Nodo = Arbol.Codigo_Nodo
                                Where Arbol.Nodo_Raiz = " & _Nodo_Raiz_Asociados & " And Es_Seleccionable = 1 And Codigo In " & _Filtro_Pro

                            Dim _Tbl_Codigos_Madre As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                            Dim _Filtro_Codigos_Madre = Generar_Filtro_IN(_Tbl_Codigos_Madre, "", "Codigo_Nodo", False, False, "")

                            If _Tbl_Codigos_Madre.Rows.Count = 0 Then
                                _Filtro_Codigos_Madre = "('@@@')"
                            End If

                            Consulta_sql = "
                                Select Codigo 
                                Into #Paso
                                From " & _Global_BaseBk & "Zw_Prod_Asociacion 
                                Where Codigo_Nodo In " & _Filtro_Codigos_Madre & " And Para_filtro = 1

                                Insert Into #Paso (Codigo)
                                Select KOPR From MAEPR
                                Where KOPR In " & _Filtro_Pro & "

                                Select Cast(1 As Bit) As Chk,KOPR As Codigo,NOKOPR As Descripcion
                                FROM MAEPR
                                Where KOPR In (Select Distinct Codigo From #Paso)

                                Drop Table #Paso"

                            _TblFiltroProductosExcluidos = _Sql.Fx_Get_Tablas(Consulta_sql)

                        End If


                    End If

                End If
            Else
                Rdb_Productos_Todos.Checked = True
                _TblFiltroProductosExcluidos = Nothing
            End If

        End If

        Btn_ProductosExcluidos.Text = "Productos excluidos (" & FormatNumber(_TblFiltroProductosExcluidos.Rows.Count, 0) & ")"

    End Sub

End Class
