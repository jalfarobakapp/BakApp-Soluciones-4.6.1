Imports System.Windows.Forms.DataVisualization.Charting
Imports DevComponents.DotNetBar

Public Class Frm_Inf_Ventas_X_Periodo_Cubo

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Nombre_Tabla_Paso As String
    Dim _SqlFiltro As String
    Dim _SqlFiltro_Detalle As String
    Dim _SqlFiltro_Arbol_BakApp As String
    Dim _Nodo_Padre_Back As Integer

    Dim _Sql_Consulta_Grafica_Acumulativa As String

    Dim _Ds_Informes As DataSet
    Dim _Row_Totales As DataRow
    Dim _Tbl_Informe As DataTable
    Dim _Tbl_Informe_Vista_Actual As DataTable

    Dim _Fecha_Desde_Origen As Date

    Dim _Tbl_Filtro_Entidad As DataTable
    Dim _Tbl_Filtro_SucursalDoc As DataTable
    Dim _Tbl_Filtro_Sucursales As DataTable
    Dim _Tbl_Filtro_Bodegas As DataTable

    Dim _Tbl_Filtro_Ciudad As DataTable
    Dim _Tbl_Filtro_Comunas As DataTable
    Dim _Tbl_Filtro_Rubro_Entidades As DataTable
    Dim _Tbl_Filtro_Zonas_Entidades As DataTable
    Dim _Tbl_Filtro_Responzables As DataTable
    Dim _Tbl_Filtro_Vendedores As DataTable
    Dim _Tbl_Filtro_Vendedores_Asignados As DataTable
    Dim _Tbl_Filtro_Productos As DataTable
    Dim _Tbl_Filtro_Super_Familias As DataTable
    Dim _Tbl_Filtro_Familias As DataTable
    Dim _Tbl_Filtro_Sub_Familias As DataTable
    Dim _Tbl_Filtro_Marcas As DataTable
    Dim _Tbl_Filtro_Rubro_Productos As DataTable
    Dim _Tbl_Filtro_Clalibpr As DataTable
    Dim _Tbl_Filtro_Zonas_Productos As DataTable
    Dim _Tbl_Filtro_Tipo_Entidad As DataTable
    Dim _Tbl_Filtro_Act_Economica As DataTable
    Dim _Tbl_Filtro_Tama_Empresa As DataTable
    Dim _Tbl_Filtro_Clas_BakApp As DataTable
    Dim _Tbl_Filtro_Lista_Precio_Asig As DataTable
    Dim _Tbl_Filtro_Lista_Precio_Docu As DataTable

    Dim _Tbl_Filtro_EntidadExcluidas As DataTable
    Dim _Tbl_Filtro_ProductosExcluidos As DataTable

    Dim _Filtro_Entidad_Todas As Boolean
    Dim _Filtro_SucursalDoc_Todas As Boolean
    Dim _Filtro_Sucursales_Todas As Boolean
    Dim _Filtro_Bodegas_Todas As Boolean

    Dim _Filtro_Ciudad_Todas As Boolean
    Dim _Filtro_Comunas_Todas As Boolean
    Dim _Filtro_Rubro_Entidades_Todas As Boolean
    Dim _Filtro_Zonas_Entidades_Todas As Boolean
    Dim _Filtro_Responzables_Todas As Boolean
    Dim _Filtro_Vendedores_Todas As Boolean
    Dim _Filtro_Vendedores_Asignados_Todas As Boolean
    Dim _Filtro_Productos_Todos As Boolean
    Dim _Filtro_Marcas_Todas As Boolean
    Dim _Filtro_Super_Familias_Todas As Boolean
    Dim _Filtro_Familias_Todas As Boolean
    Dim _Filtro_Sub_Familias_Todas As Boolean
    Dim _Filtro_Rubro_Productos_Todas As Boolean
    Dim _Filtro_Clalibpr_Todas As Boolean
    Dim _Filtro_Zonas_Productos_Todas As Boolean
    Dim _Filtro_Lista_Precio_Asig_Todas As Boolean
    Dim _Filtro_Lista_Precio_Docu_Todas As Boolean

    Dim _Filtro_Tipo_Entidad_Todas As Boolean
    Dim _Filtro_Act_Economica_Todas As Boolean
    Dim _Filtro_Tama_Empresa_Todas As Boolean

    Dim _Filtro_Clas_BakApp_Todas As Boolean

    Dim _Cp_Codigo, _Cp_Descripcion, _Tx_Descripcion As String

    Dim _Fecha_Inicio_Proyeccion_01 As Date
    Dim _Fecha_Inicio_Proyeccion_02 As Date

    Dim _Fecha_Fin_Proyeccion_01 As Date
    Dim _Fecha_Fin_Proyeccion_02 As Date

    Dim _Kosu As String

    Private _dv As New DataView

    Dim _Tbl_Vista_Informe As DataTable
    Dim _Row_Vista As DataRow

    Dim _Rotacion = 0

    Dim _Fecha_Carga_Desde As Date
    Dim _Fecha_Carga_Hasta As Date

    Enum Enum_Informe
        Sucursal
        Bodega
        Super_Familia
        Entidades
        Ciudades
        Comunas
        Productos_Consolidados
        Funcionarios
    End Enum

    Enum Enum_New_Informe
        Sucursal
        Bodega
        Ent_Ciudades
        Ent_Comunas
        Ent_Tamano_Empresa
        Ent_Tipo_Entidad
        Ent_Act_Economica
        Ent_Rubros
        Ent_Zonas
        Prod_Super_Familia
        Prod_Familias
        Prod_Sub_Familias
        Prod_Marcas
        Prod_Rubros
        Prod_Clas_Libre
        Prod_Clas_BakApp
        Prod_Zonas
        Vendedores
        Responzables
        Vendedores_Asignados
        Ent_Lista_Precios_Asig
    End Enum

    Dim _Informe As Enum_New_Informe

    Dim _Unidad As Integer
    Dim _Nombre_Excel As String
    Dim _Correr_a_la_derecha As Boolean
    Dim _Top, _Left As Integer

    Public Property Pro_Fl_Sucursales() As String
        Get
            'Return _Fl_Sucursales
        End Get
        Set(value As String)
            '_Fl_Sucursales = value
        End Set
    End Property
    Public Property Pro_Fl_Bodegas() As String
        Get
            'Return _Fl_Bodegas
        End Get
        Set(value As String)
            '_Fl_Bodegas = value
        End Set
    End Property
    Public Property Pro_Fl_Entidades() As String
        Get
            'Return _Fl_Entidades
        End Get
        Set(value As String)
            '_Fl_Entidades = value
        End Set
    End Property
    Public Property Pro_Fl_Super_Familias() As String
        Get
            'Return _Fl_Super_Familias
        End Get
        Set(value As String)
            '_Fl_Super_Familias = value
        End Set
    End Property
    Public Property Pro_Fl_Ciudades() As String
        Get
            'Return _Fl_Ciudades
        End Get
        Set(value As String)
            '_Fl_Ciudades = value
        End Set
    End Property
    Public Property Pro_Fl_Comunas() As String
        Get
            'Return _Fl_Comunas
        End Get
        Set(value As String)
            '_Fl_Comunas = value
        End Set
    End Property
    Public Property Pro_Fl_Productos_Consolidados() As String
        Get
            'Return _Fl_Productos_Consolidados
        End Get
        Set(value As String)
            '_Fl_Productos_Consolidados = value
        End Set
    End Property
    Public Property Pro_Fl_Funcionarios() As String
        Get
            'Return _Fl_Funcionarios
        End Get
        Set(value As String)
            '_Fl_Funcionarios = value
        End Set
    End Property
    Public Property Tbl_Filtro_Productos() As DataTable
        Get
            Return _Tbl_Filtro_Productos
        End Get
        Set(value As DataTable)
            _Tbl_Filtro_Productos = value
        End Set
    End Property
    Public Property Tbl_Filtro_Super_Familias() As DataTable
        Get
            Return _Tbl_Filtro_Super_Familias
        End Get
        Set(value As DataTable)
            _Tbl_Filtro_Super_Familias = value
        End Set
    End Property
    Public Property Tbl_Filtro_Marcas() As DataTable
        Get
            Return _Tbl_Filtro_Marcas
        End Get
        Set(value As DataTable)
            _Tbl_Filtro_Marcas = value
        End Set
    End Property
    Public Property Tbl_Filtro_Rubro_Productos() As DataTable
        Get
            Return _Tbl_Filtro_Rubro_Productos
        End Get
        Set(value As DataTable)
            _Tbl_Filtro_Rubro_Productos = value
        End Set
    End Property
    Public Property Tbl_Filtro_Clalibpr() As DataTable
        Get
            Return _Tbl_Filtro_Clalibpr
        End Get
        Set(value As DataTable)
            _Tbl_Filtro_Clalibpr = value
        End Set
    End Property
    Public Property Tbl_Filtro_Zonas_Productos() As DataTable
        Get
            Return _Tbl_Filtro_Zonas_Productos
        End Get
        Set(value As DataTable)
            _Tbl_Filtro_Zonas_Productos = value
        End Set
    End Property
    Public Property Tbl_Filtro_Entidad() As DataTable
        Get
            Return _Tbl_Filtro_Entidad
        End Get
        Set(value As DataTable)
            _Tbl_Filtro_Entidad = value
        End Set
    End Property
    Public Property Tbl_Filtro_Ciudad() As DataTable
        Get
            Return _Tbl_Filtro_Ciudad
        End Get
        Set(value As DataTable)
            _Tbl_Filtro_Ciudad = value
        End Set
    End Property
    Public Property Tbl_Filtro_Comunas() As DataTable
        Get
            Return _Tbl_Filtro_Comunas
        End Get
        Set(value As DataTable)
            _Tbl_Filtro_Comunas = value
        End Set
    End Property
    Public Property Tbl_Filtro_Rubro_Entidades() As DataTable
        Get
            Return _Tbl_Filtro_Rubro_Entidades
        End Get
        Set(value As DataTable)
            _Tbl_Filtro_Rubro_Entidades = value
        End Set
    End Property
    Public Property Tbl_Filtro_Zonas_Entidades() As DataTable
        Get
            Return _Tbl_Filtro_Zonas_Entidades
        End Get
        Set(value As DataTable)
            _Tbl_Filtro_Zonas_Entidades = value
        End Set
    End Property
    Public Property Tbl_Filtro_Responzables() As DataTable
        Get
            Return _Tbl_Filtro_Responzables
        End Get
        Set(value As DataTable)
            _Tbl_Filtro_Responzables = value
        End Set
    End Property
    Public Property Tbl_Filtro_Vendedores() As DataTable
        Get
            Return _Tbl_Filtro_Vendedores
        End Get
        Set(value As DataTable)
            _Tbl_Filtro_Vendedores = value
        End Set
    End Property
    Public Property Tbl_Filtro_Vendedores_Asignados() As DataTable
        Get
            Return _Tbl_Filtro_Vendedores_Asignados
        End Get
        Set(value As DataTable)
            _Tbl_Filtro_Vendedores_Asignados = value
        End Set
    End Property
    Public Property Pro_Filtro_Productos_Todos() As Boolean
        Get
            Return _Filtro_Productos_Todos
        End Get
        Set(value As Boolean)
            _Filtro_Productos_Todos = value
        End Set
    End Property
    Public Property Pro_Filtro_Marcas_Todas() As Boolean
        Get
            Return _Filtro_Marcas_Todas
        End Get
        Set(value As Boolean)
            _Filtro_Marcas_Todas = value
        End Set
    End Property
    Public Property Pro_Filtro_Super_Familias_Todas() As Boolean
        Get
            Return _Filtro_Super_Familias_Todas
        End Get
        Set(value As Boolean)
            _Filtro_Super_Familias_Todas = value
        End Set
    End Property
    Public Property Pro_Filtro_Rubro_Productos_Todas() As Boolean
        Get
            Return _Filtro_Rubro_Productos_Todas
        End Get
        Set(value As Boolean)
            _Filtro_Rubro_Productos_Todas = value
        End Set
    End Property
    Public Property Pro_Filtro_Clalibpr_Todas() As Boolean
        Get
            Return _Filtro_Clalibpr_Todas
        End Get
        Set(value As Boolean)
            _Filtro_Clalibpr_Todas = value
        End Set
    End Property
    Public Property Pro_Filtro_Zonas_Productos_Todas() As Boolean
        Get
            Return _Filtro_Zonas_Productos_Todas
        End Get
        Set(value As Boolean)
            _Filtro_Zonas_Productos_Todas = value
        End Set
    End Property
    Public Property Pro_Filtro_Responzables_Todos() As Boolean
        Get
            Return _Filtro_Responzables_Todas
        End Get
        Set(value As Boolean)
            _Filtro_Responzables_Todas = value
        End Set
    End Property
    Public Property Pro_Filtro_Vendedores_Todos() As Boolean
        Get
            Return _Filtro_Vendedores_Todas
        End Get
        Set(value As Boolean)
            _Filtro_Vendedores_Todas = value
        End Set
    End Property
    Public Property Pro_Filtro_Vendedores_Asignados_Todos() As Boolean
        Get
            Return _Filtro_Vendedores_Asignados_Todas
        End Get
        Set(value As Boolean)
            _Filtro_Vendedores_Asignados_Todas = value
        End Set
    End Property
    Public Property Pro_Filtro_Entidad_Todas() As Boolean
        Get
            Return _Filtro_Entidad_Todas
        End Get
        Set(value As Boolean)
            _Filtro_Entidad_Todas = value
        End Set
    End Property
    Public Property Pro_Filtro_Ciudad_Todas() As Boolean
        Get
            Return _Filtro_Ciudad_Todas
        End Get
        Set(value As Boolean)
            _Filtro_Ciudad_Todas = value
        End Set
    End Property
    Public Property Pro_Filtro_Comunas_Todas() As Boolean
        Get
            Return _Filtro_Comunas_Todas
        End Get
        Set(value As Boolean)
            _Filtro_Comunas_Todas = value
        End Set
    End Property
    Public Property Pro_Filtro_Rubro_Entidades_Todas() As Boolean
        Get
            Return _Filtro_Rubro_Entidades_Todas
        End Get
        Set(value As Boolean)
            _Filtro_Rubro_Entidades_Todas = value
        End Set
    End Property
    Public Property Pro_Filtro_Zonas_Entidades_Todas() As Boolean
        Get
            Return _Filtro_Zonas_Entidades_Todas
        End Get
        Set(value As Boolean)
            _Filtro_Zonas_Entidades_Todas = value
        End Set
    End Property
    Public Property Pro_Top() As Integer
        Get
            Return Me.Top
        End Get
        Set(value As Integer)
            _Top = value
        End Set
    End Property
    Public Property Pro_Left() As Integer
        Get
            Return Me.Left
        End Get
        Set(value As Integer)
            _Left = value
        End Set
    End Property
    Public Property Pro_Fecha_Desde() As Date
        Get
            Return Dtp_Fecha_Desde.Value
        End Get
        Set(value As Date)
            Dtp_Fecha_Desde.Value = value
        End Set
    End Property
    Public Property Pro_Fecha_Hasta() As Date
        Get
            Return Dtp_Fecha_Hasta.Value
        End Get
        Set(value As Date)
            Dtp_Fecha_Hasta.Value = value
        End Set
    End Property

    Public Property Tbl_Filtro_SucursalDoc As DataTable
        Get
            Return _Tbl_Filtro_SucursalDoc
        End Get
        Set(value As DataTable)
            _Tbl_Filtro_SucursalDoc = value
        End Set
    End Property

    Public Property Tbl_Filtro_Sucursales As DataTable
        Get
            Return _Tbl_Filtro_Sucursales
        End Get
        Set(value As DataTable)
            _Tbl_Filtro_Sucursales = value
        End Set
    End Property

    Public Property Tbl_Filtro_Bodegas As DataTable
        Get
            Return _Tbl_Filtro_Bodegas
        End Get
        Set(value As DataTable)
            _Tbl_Filtro_Bodegas = value
        End Set
    End Property

    Public Property Tbl_Filtro_Familias As DataTable
        Get
            Return _Tbl_Filtro_Familias
        End Get
        Set(value As DataTable)
            _Tbl_Filtro_Familias = value
        End Set
    End Property

    Public Property Tbl_Filtro_Sub_Familias As DataTable
        Get
            Return _Tbl_Filtro_Sub_Familias
        End Get
        Set(value As DataTable)
            _Tbl_Filtro_Sub_Familias = value
        End Set
    End Property

    Public Property Tbl_Filtro_Tipo_Entidad As DataTable
        Get
            Return _Tbl_Filtro_Tipo_Entidad
        End Get
        Set(value As DataTable)
            _Tbl_Filtro_Tipo_Entidad = value
        End Set
    End Property

    Public Property Tbl_Filtro_Act_Economica As DataTable
        Get
            Return _Tbl_Filtro_Act_Economica
        End Get
        Set(value As DataTable)
            _Tbl_Filtro_Act_Economica = value
        End Set
    End Property

    Public Property Tbl_Filtro_Tama_Empresa As DataTable
        Get
            Return _Tbl_Filtro_Tama_Empresa
        End Get
        Set(value As DataTable)
            _Tbl_Filtro_Tama_Empresa = value
        End Set
    End Property

    Public Property FechaDesdeFd As Date
    Public Property FechaHastaFh As Date
    Public Property Comisiones As Boolean
    Public Property TotalNetoComisiones As Double
    Public Property ImportarComisiones As Boolean

    Public Property Tbl_Filtro_EntidadExcluidas As DataTable
        Get
            Return _Tbl_Filtro_EntidadExcluidas
        End Get
        Set(value As DataTable)
            _Tbl_Filtro_EntidadExcluidas = value
        End Set
    End Property

    Public Property Tbl_Filtro_ProductosExcluidos As DataTable
        Get
            Return _Tbl_Filtro_ProductosExcluidos
        End Get
        Set(value As DataTable)
            _Tbl_Filtro_ProductosExcluidos = value
        End Set
    End Property

    Public Sub New(Informe As Enum_Informe,
                   Nombre_Tabla_Paso As String,
                   Unidad As Integer,
                   Fecha_Desde As Date,
                   Fecha_Hasta As Date,
                   Optional Correr_a_la_derecha As Boolean = False)

        ' Llamada necesaria para el Diseñador de Windows Forms.

        _Filtro_Vendedores_Asignados_Todas = True

        If Fx_Tiene_Permiso(Me, "Inf00025", , False) Then
            _Filtro_Vendedores_Asignados_Todas = True
        Else

            _Filtro_Vendedores_Asignados_Todas = False

            Consulta_sql = "Select Cast(1 As Bit) As Chk,KOFU As Codigo, NOKOFU as Descripcion" & vbCrLf &
                               "From TABFU Where KOFU = '" & FUNCIONARIO & "'"
            _Tbl_Filtro_Vendedores_Asignados = _Sql.Fx_Get_Tablas(Consulta_sql)
        End If

        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Informe = Informe
        _Nombre_Tabla_Paso = Nombre_Tabla_Paso
        _Unidad = Unidad
        _Correr_a_la_derecha = Correr_a_la_derecha

        _Filtro_SucursalDoc_Todas = True
        _Filtro_Sucursales_Todas = True
        _Filtro_Bodegas_Todas = True
        _Filtro_Entidad_Todas = True
        _Filtro_Ciudad_Todas = True
        _Filtro_Comunas_Todas = True
        _Filtro_Rubro_Entidades_Todas = True
        _Filtro_Zonas_Entidades_Todas = True
        _Filtro_Act_Economica_Todas = True
        _Filtro_Tipo_Entidad_Todas = True
        _Filtro_Tama_Empresa_Todas = True
        _Filtro_Lista_Precio_Asig_Todas = True
        _Filtro_Lista_Precio_Docu_Todas = True
        _Filtro_Vendedores_Todas = True
        _Filtro_Responzables_Todas = True
        _Filtro_Productos_Todos = True
        _Filtro_Clalibpr_Todas = True
        _Filtro_Marcas_Todas = True
        _Filtro_Rubro_Productos_Todas = True
        _Filtro_Super_Familias_Todas = True
        _Filtro_Familias_Todas = True
        _Filtro_Sub_Familias_Todas = True
        _Filtro_Zonas_Productos_Todas = True
        _Filtro_Clas_BakApp_Todas = True

        Dtp_Fecha_Desde.Value = Fecha_Desde
        Dtp_Fecha_Hasta.Value = Fecha_Hasta

        _Fecha_Desde_Origen = Fecha_Desde

        Sb_Formato_Generico_Grilla(Grilla, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)

        Tiempo.Enabled = False
        Tiempo.Interval = 1000

        Chk_Ver_Pie_3D.Checked = True
        Chk_Ver_Leyenda.Checked = False

        Sb_Color_Botones_Barra(Bar1)

        Grafico_Pie.ChartAreas(0).BackColor = Color.FromArgb(Global_camvasColor)

    End Sub

    Private Sub Frm_Inf_Ventas_X_Periodo_Sucursal_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        _Nodo_Padre_Back = 0

        _SqlFiltro = String.Empty

        If _Correr_a_la_derecha Then
            Me.Top = _Top + 5
            Me.Left = _Left + 5
        End If


        AddHandler Me.KeyDown, AddressOf Sb_Frm_KeyDown

        Dtp_Fecha_Desde.Value = Primerdiadelmes(Now.Date)
        Dtp_Fecha_Hasta.Value = ultimodiadelmes(Now.Date)

        Sb_Cargar_Combo_Vista_Informe()

        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_Detalle_MouseDown
        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla.CellEnter, AddressOf Sb_Grilla_CellEnter

        AddHandler Chk_Ver_Pie_3D.CheckedChanged, AddressOf Rdb_CheckedChanged
        AddHandler Chk_Ver_Leyenda.CheckedChanged, AddressOf Rdb_CheckedChanged

        AddHandler Rdb_Pie_Codigo.CheckedChanged, AddressOf Rdb_Pie_CheckedChanged
        AddHandler Rdb_Pie_Descripcion.CheckedChanged, AddressOf Rdb_Pie_CheckedChanged

        AddHandler Cmb_Vista_Informe.SelectedIndexChanged, AddressOf Sb_Cmb_Vista_Informe_SelectedIndexChanged

        AddHandler Num_Agrupador_Pie.ValueChanged, AddressOf Sb_Grafico_Pie_Acumulativo

        Super_Tab.SelectedTabIndex = 2

        Btn_Atras.Enabled = False
        Btn_Vista_Informe.Enabled = Btn_Atras.Enabled

        Dim _Row_Fechas As DataRow

        Consulta_sql = "Select Isnull(MIN(FEEMLI),'19000101') As Fecha_Desde,Isnull(MAX(FEEMLI),'19000101') AS Fecha_Hasta From " & _Nombre_Tabla_Paso
        _Row_Fechas = _Sql.Fx_Get_DataRow(Consulta_sql, False)

        Dim _Existe_Base As Boolean

        If Not (_Row_Fechas Is Nothing) Then
            Dim _Fd = Format(_Row_Fechas.Item("Fecha_Desde"), "yyyyMMdd")
            Dim _Fh = _Row_Fechas.Item("Fecha_Hasta")
            If _Fd <> "19000101" Then
                _Existe_Base = True
            End If
        End If

        If _Existe_Base Then
            Me.Text = "Informe de ventas del periodo nivel Sucursal." & Space(2) &
            "Fechas de estudio" & Space(1) &
            "desde: " & FormatDateTime(_Row_Fechas.Item("Fecha_Desde"), DateFormat.ShortDate) & Space(1) &
            "hasta: " & FormatDateTime(_Row_Fechas.Item("Fecha_Hasta"), DateFormat.ShortDate) & Space(2) & "(Inf: " & _Nombre_Tabla_Paso & ")"
        Else
            Me.Text = "(Inf: " & _Nombre_Tabla_Paso & ")"
        End If


        If Comisiones Then

            If IsNothing(Tbl_Filtro_Entidad) Then
                _Filtro_Entidad_Todas = True
            Else
                _Filtro_Entidad_Todas = Not CBool(Tbl_Filtro_Entidad.Rows.Count)
            End If

            _Filtro_SucursalDoc_Todas = Not CBool(_Tbl_Filtro_SucursalDoc.Rows.Count)
            _Filtro_Sucursales_Todas = Not CBool(_Tbl_Filtro_Sucursales.Rows.Count)
            _Filtro_Bodegas_Todas = Not CBool(_Tbl_Filtro_Bodegas.Rows.Count)
            _Filtro_Ciudad_Todas = Not CBool(_Tbl_Filtro_Ciudad.Rows.Count)
            _Filtro_Comunas_Todas = Not CBool(_Tbl_Filtro_Comunas.Rows.Count)
            _Filtro_Rubro_Entidades_Todas = Not CBool(_Tbl_Filtro_Rubro_Entidades.Rows.Count)
            _Filtro_Zonas_Entidades_Todas = Not CBool(_Tbl_Filtro_Zonas_Entidades.Rows.Count)
            _Filtro_Responzables_Todas = Not CBool(_Tbl_Filtro_Responzables.Rows.Count)
            _Filtro_Vendedores_Todas = Not CBool(_Tbl_Filtro_Vendedores.Rows.Count)
            _Filtro_Vendedores_Asignados_Todas = Not CBool(_Tbl_Filtro_Vendedores_Asignados.Rows.Count)

            If IsNothing(_Tbl_Filtro_Productos) Then
                _Filtro_Productos_Todos = True
            Else
                _Filtro_Productos_Todos = Not CBool(_Tbl_Filtro_Productos.Rows.Count)
            End If

            _Filtro_Super_Familias_Todas = Not CBool(_Tbl_Filtro_Super_Familias.Rows.Count)
            _Filtro_Familias_Todas = Not CBool(_Tbl_Filtro_Familias.Rows.Count)
            _Filtro_Sub_Familias_Todas = Not CBool(_Tbl_Filtro_Sub_Familias.Rows.Count)
            _Filtro_Marcas_Todas = Not CBool(_Tbl_Filtro_Marcas.Rows.Count)
            _Filtro_Rubro_Productos_Todas = Not CBool(_Tbl_Filtro_Rubro_Productos.Rows.Count)
            _Filtro_Clalibpr_Todas = Not CBool(_Tbl_Filtro_Clalibpr.Rows.Count)
            _Filtro_Zonas_Productos_Todas = Not CBool(_Tbl_Filtro_Zonas_Productos.Rows.Count)
            _Filtro_Tipo_Entidad_Todas = Not CBool(_Tbl_Filtro_Tipo_Entidad.Rows.Count)
            _Filtro_Act_Economica_Todas = Not CBool(_Tbl_Filtro_Act_Economica.Rows.Count)
            _Filtro_Tama_Empresa_Todas = Not CBool(_Tbl_Filtro_Tama_Empresa.Rows.Count)

            Tiempo.Start()

        Else

            Tiempo.Enabled = False
            Tiempo_revisa_actualizacion.Enabled = True

        End If




        Sb_Formato_Graficos(Grafico_Tendencias, 0, 0)

    End Sub

    Sub Sb_Actualizar_Matriz_Cubo()

        Me.Cursor = Cursors.WaitCursor
        Me.Refresh()

        Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros("sysobjects", "type = 'U' And name = '" & _Nombre_Tabla_Paso & "'"))

        If Not _Reg Then

            Consulta_sql = My.Resources.Recursos_Inf_Ventas.Informe_Ventas_x_Perido_Nivel_Detalle_Cubo
            Consulta_sql = Replace(Consulta_sql, "#Empresa#", ModEmpresa)
            Consulta_sql = Replace(Consulta_sql, "#Tabla_Paso#", _Nombre_Tabla_Paso)
            Consulta_sql = Replace(Consulta_sql, "#Filtro_Externo#", "")
            Consulta_sql = Replace(Consulta_sql, "#Fecha_Inicio#", Format(Dtp_Fecha_Desde.Value, "yyyyMMdd"))
            Consulta_sql = Replace(Consulta_sql, "#Fecha_Fin#", Format(Dtp_Fecha_Hasta.Value, "yyyyMMdd"))

            _Sql.Ej_consulta_IDU(Consulta_sql)

        End If

        ' CON ESTO ACTUALIZAMOS EL INFORME 

        Consulta_sql = "Delete " & _Nombre_Tabla_Paso & vbCrLf &
                       "Where IDMAEDDO NOT IN (SELECT IDMAEDDO FROM MAEDDO" & Space(1) &
                       "Where FEEMLI = '" & Format(Dtp_Fecha_Desde.Value, "yyyyMMdd") & "')" & vbCrLf &
                       "And FEEMLI = '" & Format(Dtp_Fecha_Hasta.Value, "yyyyMMdd") & "'" & vbCrLf &
                       "And TIDO IN ('BLV','BLX','BSV','ESC','FCV','FDB','FDV','FDX','FDZ','FEE','FEV','FVL','FVT','FVX',
	  			       'FVZ','FXV','FYV','NCE','NCV','NCX','NCZ','NEV','RIN')"
        _Sql.Ej_consulta_IDU(Consulta_sql)


        Consulta_sql = My.Resources.Recursos_Inf_Ventas.Informe_Ventas_x_Perido_Nivel_Detalle_Cubo_Actualizacion
        Consulta_sql = Replace(Consulta_sql, "#Empresa#", ModEmpresa)
        Consulta_sql = Replace(Consulta_sql, "#Tabla_Paso#", _Nombre_Tabla_Paso)
        Consulta_sql = Replace(Consulta_sql, "#Fecha_Inicio#", Format(Dtp_Fecha_Desde.Value, "yyyyMMdd"))
        Consulta_sql = Replace(Consulta_sql, "#Fecha_Fin#", Format(Dtp_Fecha_Hasta.Value, "yyyyMMdd"))
        Consulta_sql = Replace(Consulta_sql, "#Filtro_Externo#", "")

        _Sql.Ej_consulta_IDU(Consulta_sql)

        Consulta_sql = "CREATE UNIQUE INDEX Ix_" & _Nombre_Tabla_Paso & "_01 ON " & _Nombre_Tabla_Paso & " (IDMAEDDO)"
        _Sql.Ej_consulta_IDU(Consulta_sql, False)
        Consulta_sql = "CREATE INDEX Ix_" & _Nombre_Tabla_Paso & "_02 ON " & _Nombre_Tabla_Paso & " (ENDO,SUENDO)"
        _Sql.Ej_consulta_IDU(Consulta_sql, False)
        Consulta_sql = "CREATE INDEX Ix_" & _Nombre_Tabla_Paso & "_03 ON " & _Nombre_Tabla_Paso & " (KOPRCT)"
        _Sql.Ej_consulta_IDU(Consulta_sql, False)
        Consulta_sql = "CREATE INDEX Ix_" & _Nombre_Tabla_Paso & "_04 ON " & _Nombre_Tabla_Paso & " (SULIDO,BOSULIDO)"
        _Sql.Ej_consulta_IDU(Consulta_sql, False)
        Consulta_sql = "CREATE INDEX Ix_" & _Nombre_Tabla_Paso & "_05 ON " & _Nombre_Tabla_Paso & " (KOFUDO)"
        _Sql.Ej_consulta_IDU(Consulta_sql, False)
        Consulta_sql = "CREATE INDEX Ix_" & _Nombre_Tabla_Paso & "_06 ON " & _Nombre_Tabla_Paso & " (KOFULIDO)"
        _Sql.Ej_consulta_IDU(Consulta_sql, False)
        Consulta_sql = "CREATE INDEX Ix_" & _Nombre_Tabla_Paso & "_07 ON " & _Nombre_Tabla_Paso & " (IDMAEEDO)"
        _Sql.Ej_consulta_IDU(Consulta_sql, False)
        Consulta_sql = "CREATE INDEX Ix_" & _Nombre_Tabla_Paso & "_08 ON " & _Nombre_Tabla_Paso & " (FEEMLI)"
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        Me.Cursor = Cursors.Default

    End Sub

    Sub Sb_Cargar_Combo_Vista_Informe()

        Consulta_sql = My.Resources.Recursos_Inf_Ventas.Cargar_Tabla_Vista_del_Cubo
        Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

        _Tbl_Vista_Informe = _Ds.Tables(0)

        Dim _Tbl = _Ds.Tables(3)

        caract_combo(Cmb_Vista_Informe)
        Cmb_Vista_Informe.DataSource = _Tbl
        Cmb_Vista_Informe.SelectedValue = "SUDO" '"SULIDO"

        _Row_Vista = Fx_Crea_Tabla_Con_Filtro(_Tbl_Vista_Informe,
                                         "CODIGO = '" & Cmb_Vista_Informe.SelectedValue & "'", "Id").Rows(0)

    End Sub

    Sub Sb_Actualizar_Grilla(_Actualizar_Datos_Informe As Boolean)

        Try

            If Comisiones Then
                Dtp_Fecha_Desde.Value = FechaDesdeFd
                Dtp_Fecha_Hasta.Value = FechaHastaFh
                _Actualizar_Datos_Informe = False
            End If

            Consulta_sql = "Select Min(FEEMLI) As Fecha_Desde, Max(FEEMLI) As Fecha_Hasta From " & _Nombre_Tabla_Paso
            Dim _Row_Fechas_Carga As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Try
                If Not (_Row_Fechas_Carga Is Nothing) Then
                    _Fecha_Carga_Desde = FormatDateTime(_Row_Fechas_Carga.Item("Fecha_Desde"), DateFormat.ShortDate)
                    _Fecha_Carga_Hasta = FormatDateTime(_Row_Fechas_Carga.Item("Fecha_Hasta"), DateFormat.ShortDate)
                End If

            Catch ex As Exception

            End Try

            If Dtp_Fecha_Desde.Value > Dtp_Fecha_Hasta.Value Then
                Throw New Exception("Error en Rango de fecha, La fecha Desde no puede ser mayor a la fecha Hasta")
            End If

            Dim _F1 As Date = FormatDateTime(Dtp_Fecha_Desde.Value, DateFormat.ShortDate)
            Dim _F2 As Date = FormatDateTime(_Fecha_Carga_Desde, DateFormat.ShortDate)

            If _F1 < _F2 Then
                Dtp_Fecha_Desde.Value = _Fecha_Carga_Desde
                Throw New Exception("Error en Rango de fecha, La fecha Desde no puede ser menor que " & _F2 & vbCrLf &
                                    "El historial de información para el usuario activo son movimientos de ventas desde: " & _Fecha_Carga_Desde & " hasta: " & _Fecha_Carga_Hasta & vbCrLf & vbCrLf &
                                    "Si desea mas información debe actualizar la matriz de datos para sus informes." & vbCrLf & vbCrLf &
                                    "   Botón [Mantención de informe] - >[Actualizar datos del informe]")
            End If


            Me.Cursor = Cursors.WaitCursor
            Me.Enabled = False
            Me.Refresh()

            If _Actualizar_Datos_Informe Then

                Consulta_sql = "SELECT Count(IDMAEEDO) AS Doc_en_DDO FROM MAEDDO WHERE FEEMLI BETWEEN '" & Format(Dtp_Fecha_Desde.Value, "yyyyMMdd") & "' AND '" &
                            Format(Dtp_Fecha_Hasta.Value, "yyyyMMdd") & "'" & Space(1) &
                            "AND TIDO IN ('BLV','BLX','BSV','ESC','FCV','FDB','FDV','FDX','FDZ','FEE'," &
                            "'FEV','FVL','FVT','FVX','FVZ','FXV','FYV','NCE','NCV','NCX','NCZ','NEV','RIN')" & Space(1) &
                            "And IDMAEEDO Not IN (Select IDMAEEDO From MAEEDO Where NUDONODEFI = 1)" &
                            vbCrLf &
                            "SELECT Count(IDMAEEDO) As Doc_en_Paso FROM " & _Nombre_Tabla_Paso & Space(1) &
                            "WHERE " &
                            "FEEMLI BETWEEN '" & Format(Dtp_Fecha_Desde.Value, "yyyyMMdd") &
                            "' AND " &
                            "'" & Format(Dtp_Fecha_Hasta.Value, "yyyyMMdd") & "'" & Space(1) &
                            "AND TIDO IN ('BLV','BLX','BSV','ESC','FCV','FDB','FDV','FDX','FDZ','FEE'," &
                            "'FEV','FVL','FVT','FVX','FVZ','FXV','FYV','NCE','NCV','NCX','NCZ','NEV','RIN')"

                Dim _Ds_Documento As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

                Dim _Doc_en_DDO As Double = _Ds_Documento.Tables(0).Rows(0).Item(0)
                Dim _Doc_en_Paso As Double = _Ds_Documento.Tables(1).Rows(0).Item(0)

                If _Doc_en_DDO <> _Doc_en_Paso Then

                    ToastNotification.Show(Me, "ACTUALIZANDO DATOS DEL INFORME, POR FAVOR ESPERE...",
                                           Imagenes_32x32.Images.Item("cloud-download.png"),
                                               5 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

                    'System.Threading.Thread.Sleep(5000)
                    Dim Fm As New Frm_Inf_Ventas_X_Periodo_Fechas(Frm_Inf_Ventas_X_Periodo_Fechas.Enum_Acciones.Actualizar_Informe_Automatico)
                    Fm.Nombre_Tabla_Paso = _Nombre_Tabla_Paso
                    Fm.Pro_Fecha_Desde = Dtp_Fecha_Desde.Value
                    Fm.Pro_Fecha_Hasta = Dtp_Fecha_Hasta.Value
                    Fm.ShowDialog(Me)

                    If Fm.Pro_Informe_Actualizado Then
                        Sb_Actualizar_Grilla(False)
                    End If
                    Fm.Dispose()

                End If

            End If


            _SqlFiltro_Detalle = Fx_Filtro_Detalle()

            Dim _Codigo

            _Codigo = _Row_Vista.Item("CODIGO")
            _Cp_Codigo = _Row_Vista.Item("CODIGO")
            _Cp_Descripcion = _Row_Vista.Item("DESCRIPCION")


            Dim _ARBOL_BAKAPP As Boolean = _Row_Vista.Item("ARBOL_BAKAPP")

            Txt_Vista_Informe.Text = _Row_Vista.Item("DESCRIPCION_VISTA")

            Dim _Campo_Mostrar, _Cabecera_Mostrar, _Formato_Campo As String

            If Rdb_Ver_Cantidades.Checked Then
                _Cabecera_Mostrar = "Cantidades"
                _Campo_Mostrar = "CAPRCO" & _Unidad
                _Formato_Campo = "###,##"
                Grupo_Total.Text = "Total cantidades"
                _Campo_Mostrar = "Sum(" & _Campo_Mostrar & ")"
            End If

            If Rdb_Ver_Valores.Checked Then
                _Campo_Mostrar = "CASE WHEN MODO = '$' THEN VANELI ELSE ROUND(VANELI*TAMODO,0) END"
                _Cabecera_Mostrar = "Total Neto"
                _Formato_Campo = "$ ###,##"
                Grupo_Total.Text = "Total neto"
                _Campo_Mostrar = "Sum(" & _Campo_Mostrar & ")"
            End If

            Dim _GroupBy = "Group By " & _Cp_Codigo & "," & _Cp_Descripcion
            Dim _Distinct = String.Empty

            If Rdb_Ver_Clientes.Checked Or Rdb_Ver_documentos.Checked Then

                Dim _Campos As String

                If Rdb_Ver_documentos.Checked Then
                    _Campos = "TIDO+NUDO"
                    _Cabecera_Mostrar = "Documentos"
                    Grupo_Total.Text = "Total documentos"
                End If

                If Rdb_Ver_Clientes.Checked Then
                    _Campos = "ENDO+SUENDO"
                    _Cabecera_Mostrar = "Clientes"
                    Grupo_Total.Text = "Total clientes"
                End If

                Dim _Filtro_Tipr = String.Empty

                If Not Chk_Incluir_Conceptos.Checked Then
                    _Filtro_Tipr = "And PRCT = 0"
                End If

                _Campo_Mostrar = "(Select Count(Distinct " & _Campos & ") From " & _Nombre_Tabla_Paso & " Z2 Where " &
                                  "FEEMDO BETWEEN " &
                                  "'" & Format(Dtp_Fecha_Desde.Value, "yyyyMMdd") & "' And " &
                                  "'" & Format(Dtp_Fecha_Hasta.Value, "yyyyMMdd") & "' " &
                                  _Filtro_Tipr & " And " & _Nombre_Tabla_Paso & "." & _Cp_Codigo & " = Z2." & _Cp_Codigo & ")"

                _Campo_Mostrar = "(Select Count(Distinct " & _Campos & ") From " & _Nombre_Tabla_Paso & " Z2 Where 1 > 0 " &
                                  _SqlFiltro_Detalle & " And " & _Nombre_Tabla_Paso & "." & _Cp_Codigo & " = Z2." & _Cp_Codigo & ")"

                _Distinct = "Distinct "
                _GroupBy = String.Empty

                _Formato_Campo = "###,##"

            End If


            If _ARBOL_BAKAPP Then

                Dim _Condicion_Nodo As String

                If _Row_Vista.Item("Es_Seleccionable") Then
                    _Codigo = _Row_Vista.Item("Nodo_Padre")
                End If

                Dim _Chk_Mayor_Cero As String

                If Chk_Quitar_Valor_Cero.Checked Then
                    _Chk_Mayor_Cero = "Where TOTAL > 0"
                End If

                Dim _Ins_Sin_Asociacion_01 As String
                Dim _Ins_Sin_Asociacion_02 As String

                If _Codigo = "0" Then

                    _Ins_Sin_Asociacion_01 = "Insert Into #Paso1 (CODIGO,DESCRIPCION) Values (-1,'Sin Clasificación')" & vbCrLf &
                                             "Insert Into #Paso1 (CODIGO,DESCRIPCION) Values (-2,'Prod. Desconocidos')"

                    _Ins_Sin_Asociacion_02 = "Update #Paso1 Set TOTAL = Isnull((Select Sum(VANELI) From " & _Nombre_Tabla_Paso & vbCrLf &
                                             "Where KOPRCT  In (Select KOPR From MAEPR Where KOPR Not In (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion Where Producto = 0))" & vbCrLf &
                                             _SqlFiltro_Detalle & "),0)" & vbCrLf &
                                             "Where CODIGO = -1" & vbCrLf &
                                             "Update #Paso1 Set TOTAL = Isnull((Select Sum(VANELI) From " & _Nombre_Tabla_Paso & vbCrLf &
                                             "Where KOPRCT Not In (Select KOPR From MAEPR)" & vbCrLf &
                                             _SqlFiltro_Detalle & "),0)" & vbCrLf &
                                             "Where CODIGO = -2"
                End If

                Dim _Filtro_Nodos As String

                If _Filtro_Clas_BakApp_Todas Then
                    _Filtro_Nodos = String.Empty
                Else
                    _Filtro_Nodos = Generar_Filtro_IN(_Tbl_Filtro_Clas_BakApp, "Chk", "Codigo_Nodo", False, True, "")
                    _Filtro_Nodos = "And Codigo In (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf &
                                    "Where Codigo_Nodo In " & _Filtro_Nodos & ")"
                End If

                Consulta_sql = "Select Distinct Codigo_Nodo As CODIGO,Descripcion As DESCRIPCION," & vbCrLf &
                               "CAST(0 as Float) As Porc,CAST(0 as Float) As TOTAL" & vbCrLf &
                               "Into #Paso1" & vbCrLf &
                               "FROM " & _Global_BaseBk & "Zw_TblArbol_Asociaciones" & vbCrLf &
                               "Where 1 > 0" & vbCrLf &
                               "And Clas_Unica_X_Producto = 1 And Identificacdor_NodoPadre = " & _Codigo & vbCrLf &
                               "Order By DESCRIPCION" &
                               vbCrLf &
                               vbCrLf &
                               _Ins_Sin_Asociacion_01 &
                               vbCrLf &
                               vbCrLf &
                               "Update #Paso1 Set TOTAL = Isnull((Select Sum(VANELI) From " & _Nombre_Tabla_Paso & " Where KOPRCT In" & vbCrLf &
                               "(Select Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf &
                               "Where Codigo_Nodo = CODIGO" & vbCrLf &
                               _Filtro_Nodos & vbCrLf &
                               ")" & vbCrLf &
                               _SqlFiltro_Detalle & vbCrLf &
                               "),0)" &
                               vbCrLf &
                               vbCrLf &
                               _Ins_Sin_Asociacion_02 &
                               vbCrLf &
                               vbCrLf &
                               "Select Isnull(Sum(TOTAL),0) As TOTAL" & vbCrLf &
                               "Into #Paso2" & vbCrLf &
                               "From #Paso1" & vbCrLf &
                               "Where 1 > 0" & vbCrLf &
                               "Update #Paso1 Set Porc = CASE WHEN TOTAL > 0 THEN ROUND(CASE WHEN (Select TOTAL From #Paso2) > 0 THEN Isnull((Round(TOTAL/(Select TOTAL From #Paso2),4)),0) ELSE 0 END,5) ELSE 0 END" & vbCrLf &
                               "Select * From #Paso1" & vbCrLf & _Chk_Mayor_Cero & vbCrLf &
                               "Select * From #Paso2" & vbCrLf &
                               "Drop Table #Paso1" & vbCrLf &
                               "Drop table #Paso2"

            Else

                _Nombre_Excel = _Row_Vista.Item("EXCEL")

                Dim _Filtro_Nodos As String

                If _Filtro_Clas_BakApp_Todas Then
                    _Filtro_Nodos = String.Empty
                Else
                    _Filtro_Nodos = Generar_Filtro_IN(_Tbl_Filtro_Clas_BakApp, "Chk", "Codigo_Nodo", False, True, "")
                    _Filtro_Nodos = "And KOPRCT In (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf &
                                    "Where Codigo_Nodo In " & _Filtro_Nodos & ")"
                End If

                ' CAST(0 as Float) As Porc,Sum(CASE WHEN MODO = '$' THEN VANELI ELSE ROUND(VANELI*TAMODO,0) END)

                Consulta_sql = "Declare @Total Float" &
                                vbCrLf &
                                vbCrLf &
                               "Select " & _Distinct & _Cp_Codigo & " As CODIGO," & _Cp_Descripcion & " As DESCRIPCION," &
                               "CAST('' As Varchar(3)) As VND,CAST(0 as Float) As Porc," & _Campo_Mostrar & " As TOTAL" & vbCrLf &
                               "Into #Paso1" & vbCrLf &
                               "From " & _Nombre_Tabla_Paso & vbCrLf &
                               "Where 1 > 0" & vbCrLf &
                               _SqlFiltro &
                               vbCrLf &
                               _SqlFiltro_Detalle &
                               _Filtro_Nodos & vbCrLf &
                               vbCrLf &
                               _SqlFiltro_Arbol_BakApp &
                               _GroupBy &
                               vbCrLf &
                               vbCrLf &
                               "Select Isnull(Sum(TOTAL),0) As TOTAL Into #Paso2 From #Paso1" & vbCrLf &
                               "Set @Total = (Select Sum(TOTAL) From #Paso1)" &
                               vbCrLf &
                               vbCrLf &
                               "Update #Paso1 Set Porc = CASE WHEN TOTAL > 0 THEN ROUND(CASE WHEN (Select TOTAL From #Paso2) > 0 THEN TOTAL/(Select TOTAL From #Paso2) ELSE 0 END,5) ELSE 0 END" & vbCrLf &
                               "Update #Paso1 Set Porc = CASE WHEN TOTAL > 0 THEN ROUND(CASE WHEN (Select TOTAL From #Paso2) > 0 THEN TOTAL/@Total ELSE 0 END,5) ELSE 0 END" & vbCrLf &
                               "Update #Paso1 Set VND = Isnull((Select KOFUEN From MAEEN Where CODIGO = KOEN+SUEN),'???')" & vbCrLf &
                               "Select * From #Paso1" & vbCrLf &
                               "Select * From #Paso2" & vbCrLf &
                               "Drop Table #Paso1" & vbCrLf &
                               "Drop Table #Paso2"
            End If

            _Sql_Consulta_Grafica_Acumulativa = Consulta_sql

            Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

            _Tbl_Informe = _Ds.Tables(0) '_Sql.Fx_Get_Tablas(Consulta_sql)
            Dim _Row_Totales As DataRow = _Ds.Tables(1).Rows(0)

            If _Tbl_Informe.Rows.Count = 0 Then
                Throw New Exception("No existe información de ventas entre estas fechas")
            End If

            'RemoveHandler Grilla.CellEnter, AddressOf Sb_Grilla_CellEnter

            With Grilla

                .DataSource = _Tbl_Informe

                OcultarEncabezadoGrilla(Grilla)

                Dim _Display = 0

                .Columns("CODIGO").Width = 50
                .Columns("CODIGO").HeaderText = "Cód."
                .Columns("CODIGO").Visible = True
                .Columns("CODIGO").DisplayIndex = _Display
                _Display += 1

                .Columns("DESCRIPCION").Width = 210 '340
                .Columns("DESCRIPCION").HeaderText = "Descripción"
                .Columns("DESCRIPCION").Visible = True
                .Columns("DESCRIPCION").DisplayIndex = _Display
                _Display += 1

                If Not _ARBOL_BAKAPP Then
                    If Cmb_Vista_Informe.SelectedValue = "ENDO+SUENDO" Then
                        .Columns("DESCRIPCION").Width = 210 - 35 '340
                        .Columns("VND").Width = 35
                        .Columns("VND").HeaderText = "Ven"
                        .Columns("VND").Visible = True
                        .Columns("VND").DisplayIndex = _Display
                        _Display += 1
                    Else
                        .Columns("VND").Visible = False
                    End If
                End If

                .Columns("Porc").Width = 60 '110
                .Columns("Porc").HeaderText = "Porc"
                .Columns("Porc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Porc").DefaultCellStyle.Format = "% ##.##"
                .Columns("Porc").Visible = True
                .Columns("Porc").DisplayIndex = _Display
                _Display += 1

                .Columns("TOTAL").Width = 100
                .Columns("TOTAL").HeaderText = _Cabecera_Mostrar
                .Columns("TOTAL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("TOTAL").DefaultCellStyle.Format = _Formato_Campo
                .Columns("TOTAL").Visible = True
                .Columns("TOTAL").DisplayIndex = _Display

            End With

            If Rdb_Ver_Valores.Checked Then
                Txt_Total_Neto.Text = FormatCurrency(_Row_Totales.Item("TOTAL"), 0)
            Else
                Txt_Total_Neto.Text = FormatNumber(_Row_Totales.Item("TOTAL"), 0)
            End If

            TotalNetoComisiones = _Row_Totales.Item("TOTAL")

            Sb_Actualizar_Graficos()

            Sb_Marcar_Grafico_Barras(_Tbl_Informe.Rows(0).Item("CODIGO"))

            Sb_Imagenes_Filtros()

            Btn_Atras.Enabled = _ARBOL_BAKAPP

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Error al generar informe", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally

            Me.Cursor = Cursors.Default
            Me.Enabled = True
        End Try

    End Sub

    Function Fx_Filtro_Detalle(Optional _Incluye_Fechas As Boolean = True)

        Dim _Filtro_SucursalDoc,
            _Filtro_Sucursales,
            _Filtro_Bodegas,
            _Filtro_Entidades,
            _Filtro_EntidadesExcluidas,
            _Filtro_Ciudad,
            _Filtro_Comunas,
            _Filtro_Rubros_En,
            _Filtro_Zonas_En,
            _Filtro_Acti_Economica,
            _Filtro_Tama_Empresa,
            _Filtro_Tipo_Entidad,
            _Filtro_Vendedores,
            _Filtro_Vendedores_Asignados,
            _Filtro_Responzables,
            _Filtro_Productos,
            _Filtro_ProductosExcluidos,
            _Filtro_Marcas,
            _Filtro_Rubros_Pr,
            _Filtro_Zonas_Pr,
            _Filtro_SuperFamilias,
            _Filtro_Familias,
            _Filtro_Sub_Familias,
            _Filtro_ClasLibre,
            _Filtro_Lista_Precio_Asig,
            _Filtro_Lista_Precio_Docu As String

        If _Filtro_SucursalDoc_Todas Then
            _Filtro_SucursalDoc = String.Empty
        Else
            _Filtro_SucursalDoc = Generar_Filtro_IN(_Tbl_Filtro_SucursalDoc, "Chk", "Codigo", False, True, "'")
            _Filtro_SucursalDoc = "And SUDO IN " & _Filtro_SucursalDoc & vbCrLf
        End If

        If _Filtro_Sucursales_Todas Then
            _Filtro_Sucursales = String.Empty
        Else
            _Filtro_Sucursales = Generar_Filtro_IN(_Tbl_Filtro_Sucursales, "Chk", "Codigo", False, True, "'")
            _Filtro_Sucursales = "And SULIDO IN " & _Filtro_Sucursales & vbCrLf
        End If

        If _Filtro_Bodegas_Todas Then
            _Filtro_Bodegas = String.Empty
        Else
            _Filtro_Bodegas = Generar_Filtro_IN(_Tbl_Filtro_Bodegas, "Chk", "Codigo", False, True, "'")
            _Filtro_Bodegas = "And EMPRESA+SULIDO+BOSULIDO IN " & _Filtro_Bodegas & vbCrLf
        End If

        If _Filtro_Entidad_Todas Then
            _Filtro_Entidades = String.Empty
        Else
            _Filtro_Entidades = Generar_Filtro_IN(_Tbl_Filtro_Entidad, "Chk", "Codigo", False, True, "'")
            _Filtro_Entidades = "And ENDO IN " & _Filtro_Entidades & vbCrLf
        End If

        If Not IsNothing(_Tbl_Filtro_EntidadExcluidas) AndAlso CBool(_Tbl_Filtro_EntidadExcluidas.Rows.Count) Then
            _Filtro_EntidadesExcluidas = Generar_Filtro_IN(_Tbl_Filtro_EntidadExcluidas, "Chk", "Codigo", False, True, "'")
            _Filtro_EntidadesExcluidas = "And ENDO Not In " & _Filtro_EntidadesExcluidas & vbCrLf
        Else
            _Filtro_EntidadesExcluidas = String.Empty
        End If

        If _Filtro_Lista_Precio_Asig_Todas Then
            _Filtro_Lista_Precio_Asig = String.Empty
        Else
            _Filtro_Lista_Precio_Asig = Generar_Filtro_IN(_Tbl_Filtro_Lista_Precio_Asig, "Chk", "Codigo", False, True, "'")
            _Filtro_Lista_Precio_Asig = "And LVEN IN " & _Filtro_Lista_Precio_Asig & vbCrLf
        End If

        If _Filtro_Lista_Precio_Docu_Todas Then
            _Filtro_Lista_Precio_Docu = String.Empty
        Else
            _Filtro_Lista_Precio_Docu = Generar_Filtro_IN(_Tbl_Filtro_Lista_Precio_Docu, "Chk", "Codigo", False, True, "'")
            _Filtro_Lista_Precio_Docu = "And KOLTPR IN " & _Filtro_Lista_Precio_Docu & vbCrLf
        End If

        If _Filtro_Ciudad_Todas Then
            _Filtro_Ciudad = String.Empty
        Else
            _Filtro_Ciudad = Generar_Filtro_IN(_Tbl_Filtro_Ciudad, "Chk", "Codigo", False, True, "'")
            _Filtro_Ciudad = "And ENDO+SUENDO IN (Select KOEN+SUEN From MAEEN Where PAEN+CIEN In " & _Filtro_Ciudad & ")" & vbCrLf
        End If

        If _Filtro_Comunas_Todas Then
            _Filtro_Comunas = String.Empty
        Else
            _Filtro_Comunas = Generar_Filtro_IN(_Tbl_Filtro_Comunas, "Chk", "Codigo", False, True, "'")
            _Filtro_Comunas = "And ENDO+SUENDO IN (Select KOEN+SUEN From MAEEN Where PAEN+CIEN+CMEN In " & _Filtro_Comunas & ")" & vbCrLf
        End If

        If _Filtro_Rubro_Entidades_Todas Then
            _Filtro_Rubros_En = String.Empty
        Else
            _Filtro_Rubros_En = Generar_Filtro_IN(_Tbl_Filtro_Rubro_Entidades, "Chk", "Codigo", False, True, "'")
            _Filtro_Rubros_En = "And RUEN IN " & _Filtro_Rubros_En & vbCrLf
        End If

        If _Filtro_Zonas_Entidades_Todas Then
            _Filtro_Zonas_En = String.Empty
        Else
            _Filtro_Zonas_En = Generar_Filtro_IN(_Tbl_Filtro_Zonas_Entidades, "Chk", "Codigo", False, True, "'")
            _Filtro_Zonas_En = "And ZOEN IN " & _Filtro_Zonas_En & vbCrLf
        End If


        If _Filtro_Act_Economica_Todas Then
            _Filtro_Acti_Economica = String.Empty
        Else
            _Filtro_Acti_Economica = Generar_Filtro_IN(_Tbl_Filtro_Act_Economica, "Chk", "Codigo", False, True, "'")
            _Filtro_Acti_Economica = "And ACTIEN IN " & _Filtro_Acti_Economica & vbCrLf
        End If

        If _Filtro_Tama_Empresa_Todas Then
            _Filtro_Tama_Empresa = String.Empty
        Else
            _Filtro_Tama_Empresa = Generar_Filtro_IN(_Tbl_Filtro_Tama_Empresa, "Chk", "Codigo", False, True, "'")
            _Filtro_Tama_Empresa = "And TAMAEN IN " & _Filtro_Tama_Empresa & vbCrLf
        End If

        If _Filtro_Tipo_Entidad_Todas Then
            _Filtro_Tipo_Entidad = String.Empty
        Else
            _Filtro_Tipo_Entidad = Generar_Filtro_IN(_Tbl_Filtro_Tipo_Entidad, "Chk", "Codigo", False, True, "'")
            _Filtro_Tipo_Entidad = "And TIPOEN IN " & _Filtro_Tipo_Entidad & vbCrLf
        End If

        If _Filtro_Responzables_Todas Then
            _Filtro_Responzables = String.Empty
        Else
            _Filtro_Responzables = Generar_Filtro_IN(_Tbl_Filtro_Responzables, "Chk", "Codigo", False, True, "'")
            _Filtro_Responzables = "And KOFUDO IN " & _Filtro_Responzables & vbCrLf
        End If

        If _Filtro_Vendedores_Todas Then
            _Filtro_Vendedores = String.Empty
        Else
            _Filtro_Vendedores = Generar_Filtro_IN(_Tbl_Filtro_Vendedores, "Chk", "Codigo", False, True, "'")
            _Filtro_Vendedores = "And KOFULIDO IN " & _Filtro_Vendedores & vbCrLf
        End If

        If _Filtro_Vendedores_Asignados_Todas Then
            _Filtro_Vendedores_Asignados = String.Empty
        Else
            _Filtro_Vendedores_Asignados = Generar_Filtro_IN(_Tbl_Filtro_Vendedores_Asignados, "Chk", "Codigo", False, True, "'")
            _Filtro_Vendedores_Asignados = "And KOFUEN IN " & _Filtro_Vendedores_Asignados & vbCrLf
        End If

        If _Filtro_Productos_Todos Then
            _Filtro_Productos = String.Empty
        Else
            _Filtro_Productos = Generar_Filtro_IN(_Tbl_Filtro_Productos, "Chk", "Codigo", False, True, "'")
            _Filtro_Productos = "And KOPRCT IN " & _Filtro_Productos & vbCrLf
        End If

        If Not IsNothing(_Tbl_Filtro_ProductosExcluidos) AndAlso CBool(_Tbl_Filtro_ProductosExcluidos.Rows.Count) Then
            _Filtro_ProductosExcluidos = Generar_Filtro_IN(_Tbl_Filtro_ProductosExcluidos, "Chk", "Codigo", False, True, "'")
            _Filtro_ProductosExcluidos = "And KOPRCT Not In " & _Filtro_ProductosExcluidos & vbCrLf
        Else
            _Filtro_ProductosExcluidos = String.Empty
        End If

        If _Filtro_Rubro_Productos_Todas Then
            _Filtro_Rubros_Pr = String.Empty
        Else
            _Filtro_Rubros_Pr = Generar_Filtro_IN(_Tbl_Filtro_Rubro_Productos, "Chk", "Codigo", False, True, "'")
            _Filtro_Ciudad = "And RUEN IN " & _Filtro_Comunas & vbCrLf
        End If

        If _Filtro_Marcas_Todas Then
            _Filtro_Marcas = String.Empty
        Else
            _Filtro_Marcas = Generar_Filtro_IN(_Tbl_Filtro_Marcas, "Chk", "Codigo", False, True, "'")
            _Filtro_Marcas = "And KOPRCT IN (Select KOPR From MAEPR Where MRPR In " & _Filtro_Marcas & ")" & vbCrLf
        End If

        If _Filtro_Super_Familias_Todas Then
            _Filtro_SuperFamilias = String.Empty
        Else
            _Filtro_SuperFamilias = Generar_Filtro_IN(_Tbl_Filtro_Super_Familias, "Chk", "Codigo", False, True, "'")
            _Filtro_SuperFamilias = "And FMPR In " & _Filtro_SuperFamilias & vbCrLf
        End If

        If _Filtro_Familias_Todas Then
            _Filtro_Familias = String.Empty
        Else
            _Filtro_Familias = Generar_Filtro_IN(_Tbl_Filtro_Familias, "Chk", "Codigo", False, True, "'")
            _Filtro_Familias = "And FMPR+PFPR In " & _Filtro_Familias & vbCrLf
        End If

        If _Filtro_Sub_Familias_Todas Then
            _Filtro_Sub_Familias = String.Empty
        Else
            _Filtro_Sub_Familias = Generar_Filtro_IN(_Tbl_Filtro_Sub_Familias, "Chk", "Codigo", False, True, "'")
            _Filtro_Sub_Familias = "And FMPR+PFPR+HFPR In " & _Filtro_Sub_Familias & vbCrLf
        End If

        If _Filtro_Clalibpr_Todas Then
            _Filtro_ClasLibre = String.Empty
        Else
            _Filtro_ClasLibre = Generar_Filtro_IN(_Tbl_Filtro_Clalibpr, "Chk", "Codigo", False, True, "'")
            _Filtro_ClasLibre = "And KOPRCT IN (Select KOPR From MAEPR Where CLALIBPR In " & _Filtro_ClasLibre & ")" & vbCrLf
        End If

        If _Filtro_Zonas_Productos_Todas Then
            _Filtro_Zonas_Pr = String.Empty
        Else
            _Filtro_Zonas_Pr = Generar_Filtro_IN(_Tbl_Filtro_Zonas_Productos, "Chk", "Codigo", False, True, "'")
            _Filtro_Zonas_Pr = "And KOPRCT IN (Select KOPR From MAEPR Where ZONAPR In " & _Filtro_Zonas_Pr & ")" & vbCrLf
        End If

        '---------------------------

        Dim _SqlFiltro_Fechas As String

        If _Incluye_Fechas Then

            _SqlFiltro_Fechas = "And FEEMDO BETWEEN '" & Format(Dtp_Fecha_Desde.Value, "yyyyMMdd") & "' AND '" &
                                 Format(Dtp_Fecha_Hasta.Value, "yyyyMMdd") & "'" & vbCrLf

        End If

        Dim _Filtro_Tipr As String

        If Not Chk_Incluir_Conceptos.Checked Then
            _Filtro_Tipr = "And PRCT = 0" & vbCrLf
        End If

        Dim _Filtro_Externo = _Filtro_SucursalDoc &
                              _Filtro_Sucursales &
                              _Filtro_Bodegas &
                              _Filtro_Entidades &
                              _Filtro_EntidadesExcluidas &
                              _Filtro_Ciudad &
                              _Filtro_Comunas &
                              _Filtro_Rubros_En &
                              _Filtro_Zonas_En &
                              _Filtro_Acti_Economica &
                              _Filtro_Tama_Empresa &
                              _Filtro_Tipo_Entidad &
                              _Filtro_Responzables &
                              _Filtro_Vendedores &
                              _Filtro_Vendedores_Asignados &
                              _Filtro_Productos &
                              _Filtro_ProductosExcluidos &
                              _Filtro_Rubros_Pr &
                              _Filtro_Marcas &
                              _Filtro_Zonas_Pr &
                              _Filtro_SuperFamilias &
                              _Filtro_Familias &
                              _Filtro_Sub_Familias &
                              _Filtro_ClasLibre &
                              _Filtro_Lista_Precio_Asig &
                              _Filtro_Lista_Precio_Docu &
                              _SqlFiltro_Fechas &
                              _Filtro_Tipr


        Return _Filtro_Externo

    End Function

    Function Fx_Traer_Filtro(_Campo As String) As String

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Filtro As String

        Dim _Codigo = _Fila.Cells("CODIGO").Value

        If _Codigo = "ZZZ" Then
            _Filtro = Generar_Filtro_IN(_Tbl_Informe, "", "CODIGO", False, False, "'")
        Else
            _Filtro = "('" & _Codigo & "')"
        End If

        _Filtro = "And " & _Campo & "  IN " & _Filtro

        Return _Filtro

    End Function

    Function Fx_Traer_Filtro_Sucursales() As String

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Kosu As String
        Dim _Filtro_Sucursales As String

        Try
            _Kosu = _Fila.Cells("KOSU").Value

            If _Kosu = "ZZZ" Then
                _Kosu = String.Empty 'Generar_Filtro_IN(_Tbl_Informe, "", "KOSU", False, False, "'")
                _Filtro_Sucursales = _Kosu
            Else
                _Kosu = "('" & _Kosu & "')"
                _Filtro_Sucursales = "And KOSU IN " & _Kosu
            End If

        Catch ex As Exception
            _Filtro_Sucursales = String.Empty
        End Try

        Return _Filtro_Sucursales

    End Function

    Private Sub Sb_Grilla_Detalle_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    ShowContextMenu(Menu_Contextual_Vista_Detalle)
                End If
            End With
        End If
    End Sub

    Private Sub Sb_Frm_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Rdb_Orden_CheckedChanged(sender As System.Object, e As System.EventArgs)
        If CType(sender, DevComponents.DotNetBar.Controls.CheckBoxX).Checked Then
            Sb_Actualizar_Grilla(False)
        End If
    End Sub

    Private Sub Btn_Graficar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Graficar.Click
        If Fx_Tiene_Permiso(Me, "Inf00020") Then
            Dim Fm As New Frm_Inf_Ventas_X_Periodo_Graficos(_Nombre_Tabla_Paso,
                                                            _Cp_Codigo,
                                                            _Cp_Descripcion,
                                                            _SqlFiltro_Detalle)
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If
    End Sub

    Private Sub Btn_Actualizar_Informe_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Actualizar_Informe.Click
        Sb_Actualizar_Grilla(False)
    End Sub


#Region "GRAFICOS"

    Function Fx_Filtro_Fecha(Fecha_Desde As Date, Fecha_Hasta As Date) As String

        Dim _Fecha_Entre As String

        Dim _F_Desde = Format(Fecha_Desde, "yyyMMdd")
        Dim _F_Hasta = Format(Fecha_Hasta, "yyyMMdd")

        _Fecha_Entre = "And FEEMLI BETWEEN '" & _F_Desde & "' And '" & _F_Hasta & "'" & vbCrLf

        Return _Fecha_Entre

    End Function

    Sub Sb_Actualizar_Graficos()

        If _Row_Vista.Item("ARBOL_BAKAPP") Then
            If False Then Sb_Generar_Grafica_Linea_De_Tiempo_Arbol(Grafico_Linea_De_Tiempo)
        Else
            'Sb_Generar_Grafica_Linea_De_Tiempo(Grafico_Linea_De_Tiempo)
        End If
        Sb_Grafico_Pie_Acumulativo()

    End Sub

    Sub Sb_Generar_Grafica_Linea_De_Tiempo(_Grafico As Chart)

        _Grafico.Series.Clear()

        Dim _Filtro_Nodos As String

        If _Filtro_Clas_BakApp_Todas Then
            _Filtro_Nodos = String.Empty
        Else
            _Filtro_Nodos = Generar_Filtro_IN(_Tbl_Filtro_Clas_BakApp, "Chk", "Codigo_Nodo", False, True, "")
            _Filtro_Nodos = "And KOPRCT In (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf &
                            "Where Codigo_Nodo In " & _Filtro_Nodos & ")"
        End If

        Consulta_sql = "Select Distinct Ano From " & _Nombre_Tabla_Paso & vbCrLf &
                       "Where 1 > 0" & _SqlFiltro_Detalle & vbCrLf &
                       "Select Distinct " & _Cp_Codigo & " AS CODIGO," & _Cp_Descripcion & " AS DESCRIPCION" & vbCrLf &
                       "From " & _Nombre_Tabla_Paso & vbCrLf &
                       "Where 1 > 0" & _SqlFiltro_Detalle & vbCrLf & _Filtro_Nodos

        Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

        Dim _Tbl_Datos = _Ds.Tables(1)

        Dim _Sql_Puntos_Cero = String.Empty

        Dim _F1 As Date = Dtp_Fecha_Desde.Value
        Dim _F2 As Date = Dtp_Fecha_Hasta.Value

        Dim _Meses = DateDiff(DateInterval.Month, _F1, _F2) '+ 1
        Dim _Mes = _F1.Month

        For Each _Row_Datos As DataRow In _Tbl_Datos.Rows

            Dim _Codigo = _Row_Datos.Item("CODIGO")
            Dim _Descripcion = _Row_Datos.Item("DESCRIPCION")

            Dim Fecha As Date = Dtp_Fecha_Desde.Value

            For Mes = 0 To _Meses

                Dim _Mes_Ano As String = UCase(MonthName(Month(Fecha), False) & "." & Fecha.Year)

                Dim FStr As String = Format(Primerdiadelmes(Fecha), "yyyyMMdd")
                _Mes_Ano = "UPPER(DATENAME(MONTH,'" & FStr & "'))+'.'+DATENAME(YEAR,'" & FStr & "')"
                Dim _Mes_Palabra = "UPPER(DATENAME(MONTH,'" & FStr & "'))"

                _Sql_Puntos_Cero += "Insert Into #Paso1 (CODIGO,DESCRIPCION,Mes_Ano,Mes,Ano,Orden,VANELI) Values" & Space(1) &
                 "('" & _Codigo & "','" & _Descripcion & "'," & _Mes_Ano & "," & _Mes_Palabra & ",'" & Year(Fecha) & "'," & Month(Fecha) & ",0)" & vbCrLf

                Fecha = DateAdd(DateInterval.Month, 1, Fecha)

            Next

        Next

        ' Dejo en cero para no ensuciar el informe
        _Sql_Puntos_Cero = String.Empty

        Consulta_sql = My.Resources.Recursos_Inf_Ventas.Inf_Grafico_Dinamica_Ventas_Mensuales

        Consulta_sql = Replace(Consulta_sql, "#CODIGO#", _Cp_Codigo)
        Consulta_sql = Replace(Consulta_sql, "#DESCRIPCION#", _Cp_Descripcion)
        Consulta_sql = Replace(Consulta_sql, "#Tabla_Paso#", _Nombre_Tabla_Paso)
        Consulta_sql = Replace(Consulta_sql, "#Filtro_Sql#", _SqlFiltro_Detalle & vbCrLf & _Filtro_Nodos)
        Consulta_sql = Replace(Consulta_sql, "#Filtro_Fechas#", "")
        Consulta_sql = Replace(Consulta_sql, "#Sql_Puntos_Cero#", _Sql_Puntos_Cero)

        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim rows() As DataRow = _Tbl.Select("Total=MAX(Total)")
        Dim _Max

        If (rows.Length = 0) Then
            ' No hay ningún registro en la tabla TblFacturas.
            ' Devolvemos el número 1.
            _Max = 0

        Else
            ' Le sumamos una unidad al valor máximo
            ' existente en el campo NFactura.
            Dim numero As Object = rows(0).Item("Total")

            _Max = numero

        End If


        Dim _Sql_DReader As System.Data.SqlClient.SqlDataReader
        _Sql_DReader = _Sql.Fx_SqlDataReader(Consulta_sql)

        ' Data bind chart to a table where all rows are grouped in series by the "Name" column

        _Grafico.DataBindCrossTable(_Sql_DReader, "DESCRIPCION", "Mes_Ano", "Total", "Label=Total{C0}") ' Original
        '_Grafico.DataBindCrossTable(_Sql_DReader, "Ano", "Mes", "Total", "Label=Total{C0}")

        _Sql.Sb_Cerrar_Conexion2()

        _Grafico.ChartAreas(0).AxisX.IsMarginVisible = True
        _Grafico.ChartAreas(0).AxisY.LabelStyle.Format = "C0"

        '_Grafico.Legends("Default").BackColor = Color.White
        'Chart1.Legends("Default").BackSecondaryColor = Color.Green
        'Chart1.Legends("Default").BackGradientStyle = GradientStyle.DiagonalLeft

        '_Grafico.Legends("Default").BorderColor = Color.Black
        '_Grafico.Legends("Default").BorderWidth = 2
        '_Grafico.Legends("Default").BorderDashStyle = ChartDashStyle.Solid

        'Sombra leyenda
        _Grafico.Legends("Default").ShadowOffset = 0

        _Grafico.Legends("Default").DockedToChartArea = "Default"
        _Grafico.Legends("Default").InsideChartArea = "" '"Default"
        _Grafico.Legends("Default").Alignment = StringAlignment.Near

        _Grafico.Legends("Default").Docking = Docking.Right
        _Grafico.Legends("Default").LegendStyle = LegendStyle.Column
        _Grafico.Legends("Default").TableStyle = LegendTableStyle.Auto

        ' Set series chart type
        'Chart1.Series("Series1").ChartType = DirectCast([Enum].Parse(GetType(SeriesChartType), _
        '                                                             comboBoxChartType.Text, True), SeriesChartType)

        ' Set series appearance
        Dim marker As MarkerStyle = MarkerStyle.Circle
        Dim _Contador = 0

        For Each ser As Series In _Grafico.Series

            ser.ShadowOffset = 1
            ser.BorderWidth = 1

            If CBool(_Meses) Then
                ser.ChartType = SeriesChartType.Line
            Else
                ser.ChartType = SeriesChartType.Column
            End If

            'ser.Color = Color.FromArgb(255, 128, 128)

            ser.MarkerSize = 1
            ser.MarkerStyle = marker
            'ser.MarkerBorderColor = Color.FromArgb(64, 64, 64)
            ser.Font = New Font("Trebuchet MS", 8, FontStyle.Bold)
            ser.IsValueShownAsLabel = False

            For Each Punto In ser.Points
                Punto.Label = String.Empty
                Dim _Cod As String = Punto.XValue

            Next

            ser.EmptyPointStyle.Color = Color.Red
            ser.EmptyPointStyle.BorderWidth = 2
            ser.EmptyPointStyle.BorderDashStyle = ChartDashStyle.Dash
            ser.EmptyPointStyle.MarkerSize = 10
            ser.EmptyPointStyle.MarkerStyle = MarkerStyle.Cross
            ser.EmptyPointStyle.MarkerBorderColor = Color.Black
            ser.EmptyPointStyle.MarkerColor = Color.Red

            ser.ToolTip = ser.Name
            'Dim _Name As String = Trim(ser.Name.ToString)
            '
            'For Each _Row As DataGridViewRow In Grilla.Rows
            'Dim _Codigo = _Row.Cells("CODIGO").Value
            'If Trim(_Codigo) = Trim(ser.Name) Then
            '_Row.Cells("CODIGO").Style.BackColor = ser.Color
            'End If
            'Next

            'marker += 1
            'If marker > 9 Then
            'marker = MarkerStyle.Square
            'End If

            Sb_Formato_Graficos(Grafico_Linea_De_Tiempo, 0, _Contador)
            _Contador += 1

        Next


        ' Find point with maximum Y value and change color
        'Dim maxValuePoint As DataPoint = Grafico_Lineal.Series("Series1").Points.FindMaxValue()
        'maxValuePoint.Color = Color.FromArgb(255, 128, 128)

        ' Find point with minimum Y value and change color
        'Dim minValuePoint As DataPoint = Grafico_Lineal.Series("Series1").Points.FindMinValue()
        'minValuePoint.Color = Color.FromArgb(128, 128, 255)


        For i = 0 To _Grafico.Series.Count - 1
            Try
                _Grafico.Series(i)("EmptyPointValue") = "Zero" '"Average"
            Catch ex As Exception

            End Try
        Next

    End Sub

    Sub Sb_Generar_Grafica_Linea_De_Tiempo_Arbol(_Grafico As Chart)

        _Grafico.Series.Clear()

        Dim _Sql_Filtro = Fx_Filtro_Detalle(False)

        Dim _Nodo_Padre = _Row_Vista.Item("Nodo_Padre")

        Dim _Sql_Mes_Query = String.Empty
        Dim _Sql_Puntos_Cero = String.Empty

        Dim _F1 As Date = Dtp_Fecha_Desde.Value
        Dim _F2 As Date = Dtp_Fecha_Hasta.Value

        Dim _Meses = DateDiff(DateInterval.Month, _F1, _F2) '+ 1
        Dim _Mes = _F1.Month

        Dim _Sql_Grafico = "CREATE TABLE #Paso1(" & vbCrLf &
                           "[Id]                 [int] IDENTITY(1,1) NOT NULL," & vbCrLf &
                           "[CODIGO]             [varchar](20) Default  ('')," & vbCrLf &
                           "[DESCRIPCION]        [varchar](50) Default  ('')," & vbCrLf &
                           "[Mes_Ano]            [varchar](100) Default  ('')," & vbCrLf &
                           "[Mes]                [varchar](20) Default ('')," & vbCrLf &
                           "[Ano]                [varchar](4) Default  ('')," & vbCrLf &
                           "[Orden]              [Int] Default(0)," & vbCrLf &
                           "[Total]              [Float] Default(0)" & vbCrLf &
                           ") ON [PRIMARY]"

        Dim _Fecha_Desde As Date = Dtp_Fecha_Desde.Value
        Dim _Fecha_Hasta As Date = ultimodiadelmes(_Fecha_Desde)

        Dim _Fecha As Date = Dtp_Fecha_Desde.Value

        For Mes = 0 To _Meses

            For Each _Row_Datos As DataRow In _Tbl_Informe.Rows

                Dim _Codigo = _Row_Datos.Item("CODIGO")
                Dim _Descripcion = _Row_Datos.Item("DESCRIPCION")

                Dim _Mes_Ano As String = UCase(MonthName(Month(_Fecha), False) & "." & _Fecha.Year)


                Dim FStr As String = Format(Primerdiadelmes(_Fecha), "yyyyMMdd")
                _Mes_Ano = "UPPER(DATENAME(MONTH,'" & FStr & "'))+'.'+DATENAME(YEAR,'" & FStr & "')"
                Dim _Mes_Palabra = "UPPER(DATENAME(MONTH,'" & FStr & "'))"

                _Sql_Puntos_Cero += "Insert Into #Paso1 (CODIGO,DESCRIPCION,Mes_Ano,Mes,Ano,Orden,VANELI) Values" & Space(1) &
                 "('" & _Codigo & "','" & _Descripcion & "'," & _Mes_Ano & "," & _Mes_Palabra & ",'" & Year(_Fecha) & "'," & Month(_Fecha) & ",0)" & vbCrLf

                Dim _SqlFiltro_Fechas = "And FEEMLI BETWEEN '" & Format(_Fecha_Desde, "yyyyMMdd") & "' AND '" &
                                         Format(_Fecha_Hasta, "yyyyMMdd") & "'" & vbCrLf

                Consulta_sql = "Select SUM(VANELI) As Total From " & _Nombre_Tabla_Paso & vbCrLf &
                               "Where 1 > 0 " & vbCrLf & _Sql_Filtro & vbCrLf & _SqlFiltro_Fechas & vbCrLf &
                               "And KOPRCT In" & vbCrLf &
                               "(Select Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf &
                               "Where Codigo_Nodo = " & _Codigo & ")"

                Dim _Row_Valor As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                Dim _Valor As Double

                If (_Row_Valor Is Nothing) Then
                    _Valor = 0
                Else
                    _Valor = NuloPorNro(_Row_Valor.Item("Total"), 0)
                End If

                _Sql_Mes_Query += "Insert Into #Paso1 (CODIGO,DESCRIPCION,Mes_Ano,Mes,Ano,Orden,Total) Values" & Space(1) &
                 "('" & _Codigo & "','" & _Descripcion & "'," & _Mes_Ano & "," & _Mes_Palabra & ",'" & Year(_Fecha) & "'," & Month(_Fecha) & "," & De_Num_a_Tx_01(_Valor, False, 5) & ")" & vbCrLf

            Next

            _Fecha = DateAdd(DateInterval.Month, 1, _Fecha)
            _Fecha_Desde = Primerdiadelmes(_Fecha)
            _Fecha_Hasta = ultimodiadelmes(_Fecha)

        Next

        _Sql_Grafico += vbCrLf & vbCrLf & _Sql_Mes_Query & vbCrLf &
                        "Select * From #Paso1" & vbCrLf &
                        "Drop Table #Paso1"

        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(_Sql_Grafico)

        Dim rows() As DataRow = _Tbl.Select("Total=MAX(Total)")
        Dim _Max

        If (rows.Length = 0) Then
            ' No hay ningún registro en la tabla TblFacturas.
            ' Devolvemos el número 1.
            _Max = 0

        Else
            ' Le sumamos una unidad al valor máximo
            ' existente en el campo NFactura.
            Dim numero As Object = rows(0).Item("Total")

            _Max = numero

        End If


        Dim _Sql_DReader As System.Data.SqlClient.SqlDataReader
        _Sql_DReader = _Sql.Fx_SqlDataReader(_Sql_Grafico)

        ' Data bind chart to a table where all rows are grouped in series by the "Name" column

        _Grafico.DataBindCrossTable(_Sql_DReader, "DESCRIPCION", "Mes_Ano", "Total", "Label=Total{C0}")
        _Grafico.ChartAreas(0).AxisX.IsMarginVisible = True
        _Grafico.ChartAreas(0).AxisY.LabelStyle.Format = "C0"

        'Sombra leyenda
        _Grafico.Legends("Default").ShadowOffset = 5

        _Grafico.Legends("Default").DockedToChartArea = "Default"
        _Grafico.Legends("Default").InsideChartArea = "" '"Default"
        _Grafico.Legends("Default").Alignment = StringAlignment.Near

        _Grafico.Legends("Default").Docking = Docking.Right
        _Grafico.Legends("Default").LegendStyle = LegendStyle.Column
        _Grafico.Legends("Default").TableStyle = LegendTableStyle.Auto

        ' Set series appearance
        Dim marker As MarkerStyle = MarkerStyle.Circle
        For Each ser As Series In _Grafico.Series

            ser.ShadowOffset = 1
            ser.BorderWidth = 3
            ser.ChartType = SeriesChartType.Line
            'ser.Color = Color.FromArgb(255, 128, 128)

            ser.MarkerSize = 5
            ser.MarkerStyle = marker
            'ser.MarkerBorderColor = Color.FromArgb(64, 64, 64)
            ser.Font = New Font("Trebuchet MS", 8, FontStyle.Bold)
            ser.IsValueShownAsLabel = False

            For Each Punto In ser.Points
                Punto.Label = String.Empty
                Dim _Cod As String = Punto.XValue

            Next

            ser.EmptyPointStyle.Color = Color.Red
            ser.EmptyPointStyle.BorderWidth = 2
            ser.EmptyPointStyle.BorderDashStyle = ChartDashStyle.Dash
            ser.EmptyPointStyle.MarkerSize = 10
            ser.EmptyPointStyle.MarkerStyle = MarkerStyle.Cross
            ser.EmptyPointStyle.MarkerBorderColor = Color.Black
            ser.EmptyPointStyle.MarkerColor = Color.Red

            'Dim _Name As String = Trim(ser.Name.ToString)
            '
            'For Each _Row As DataGridViewRow In Grilla.Rows
            'Dim _Codigo = _Row.Cells("CODIGO").Value
            'If Trim(_Codigo) = Trim(ser.Name) Then
            '_Row.Cells("CODIGO").Style.BackColor = ser.Color
            'End If
            'Next

            'marker += 1
            'If marker > 9 Then
            'marker = MarkerStyle.Square
            'End If

        Next

        ' Find point with maximum Y value and change color
        'Dim maxValuePoint As DataPoint = Grafico_Lineal.Series("Series1").Points.FindMaxValue()
        'maxValuePoint.Color = Color.FromArgb(255, 128, 128)

        ' Find point with minimum Y value and change color
        'Dim minValuePoint As DataPoint = Grafico_Lineal.Series("Series1").Points.FindMinValue()
        'minValuePoint.Color = Color.FromArgb(128, 128, 255)


        For i = 0 To _Grafico.Series.Count - 1
            Try
                _Grafico.Series(i)("EmptyPointValue") = "Zero" '"Average"
            Catch ex As Exception

            End Try
        Next

    End Sub

    Function Fx_Generar_Grafico_Pie() As String

        'If Not _Row_Vista.Item("ARBOL_BAKAPP") Then

        'Dim _Nodo_Padre = _Row_Vista.Item("Nodo_Padre")

        'Consulta_sql = "Select Distinct Ano From " & _Nombre_Tabla_Paso & vbCrLf & _
        '               "Where 1 > 0" & _SqlFiltro_Detalle & _
        '               vbCrLf & _
        '               "Select Codigo_Nodo AS CODIGO,Descripcion AS DESCRIPCION" & vbCrLf & _
        '               "From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones" & vbCrLf & _
        '               "Where 1 > 0 And Identificacdor_NodoPadre = " & _Nodo_Padre
        'Else
        Consulta_sql = "Select Distinct Ano From " & _Nombre_Tabla_Paso & vbCrLf &
                       "Where 1 > 0" & _SqlFiltro_Detalle & vbCrLf &
                       "Select Distinct " & _Cp_Codigo & " AS CODIGO," & _Cp_Descripcion & " AS DESCRIPCION" & vbCrLf &
                       "From " & _Nombre_Tabla_Paso & vbCrLf &
                       "Where 1 > 0" & _SqlFiltro_Detalle
        'End If

        Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

        Dim _Tbl_Anos = _Ds.Tables(0)
        Dim _Tbl_Datos = _Ds.Tables(1)

        Dim _Sql_Puntos_Cero = String.Empty

        Dim _F1 As Date = Dtp_Fecha_Desde.Value
        Dim _F2 As Date = Dtp_Fecha_Hasta.Value

        Dim _Meses = DateDiff(DateInterval.Month, _F1, _F2) '+ 1
        Dim _Mes = _F1.Month



        For Each _Row_Datos As DataRow In _Tbl_Datos.Rows

            Dim _Codigo = _Row_Datos.Item("CODIGO")
            Dim _Descripcion = _Row_Datos.Item("DESCRIPCION")

            Dim Fecha As Date = Dtp_Fecha_Desde.Value

            For Mes = 0 To _Meses

                'Fecha = DateAdd(DateInterval.Month, 1, Fecha)

                Dim _Mes_Ano As String = UCase(MonthName(Month(Fecha), False) & "." & Fecha.Year)

                'Meses_(Mes) = FechaNw

                Dim FStr As String = Format(Primerdiadelmes(Fecha), "yyyyMMdd")
                _Mes_Ano = "UPPER(DATENAME(MONTH,'" & FStr & "'))+'.'+DATENAME(YEAR,'" & FStr & "')"
                Dim _Mes_Palabra = "UPPER(DATENAME(MONTH,'" & FStr & "'))"

                _Sql_Puntos_Cero += "Insert Into #Paso1 (CODIGO,DESCRIPCION,Mes_Ano,Mes,Ano,Orden,VANELI) Values" & Space(1) &
                 "('" & _Codigo & "','" & _Descripcion & "'," & _Mes_Ano & "," & _Mes_Palabra & ",'" & Year(Fecha) & "'," & Month(Fecha) & ",0)" & vbCrLf


                Fecha = DateAdd(DateInterval.Month, 1, Fecha)

            Next

        Next

        '_Sql_Puntos_Cero = String.Empty

        Dim _Sql_Grafico As String = My.Resources.Recursos_Inf_Ventas.Inf_Grafico_Dinamica_Ventas_Mensuales

        _Sql_Grafico = Replace(_Sql_Grafico, "#CODIGO#", _Cp_Codigo)
        _Sql_Grafico = Replace(_Sql_Grafico, "#DESCRIPCION#", _Cp_Descripcion)
        _Sql_Grafico = Replace(_Sql_Grafico, "#Tabla_Paso#", _Nombre_Tabla_Paso)
        _Sql_Grafico = Replace(_Sql_Grafico, "#Filtro_Sql#", _SqlFiltro_Detalle)
        _Sql_Grafico = Replace(_Sql_Grafico, "#Filtro_Fechas#", "")
        _Sql_Grafico = Replace(_Sql_Grafico, "#Sql_Puntos_Cero#", _Sql_Puntos_Cero)

        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(_Sql_Grafico)

        Dim rows() As DataRow = _Tbl.Select("Total=MAX(Total)")
        Dim _Max

        If (rows.Length = 0) Then
            ' No hay ningún registro en la tabla TblFacturas.
            ' Devolvemos el número 1.
            _Max = 0

        Else
            ' Le sumamos una unidad al valor máximo
            ' existente en el campo NFactura.
            Dim numero As Object = rows(0).Item("Ano")

            _Max = numero

        End If

        Return _Sql_Grafico

    End Function

    Function Fx_Generar_Grafico_Pie_Arbol_Asociaciones() As String

        Dim _Sql_Filtro = Fx_Filtro_Detalle(False)

        Dim _Nodo_Padre = _Row_Vista.Item("Nodo_Padre")

        Dim _Sql_Mes_Query = String.Empty
        Dim _Sql_Puntos_Cero = String.Empty


        Dim _F1 As Date = Dtp_Fecha_Desde.Value
        Dim _F2 As Date = Dtp_Fecha_Hasta.Value

        Dim _Meses = DateDiff(DateInterval.Month, _F1, _F2) '+ 1
        Dim _Mes = _F1.Month

        Dim _Sql_Grafico = "CREATE TABLE #Paso1(" & vbCrLf &
                           "[Id]                 [int] IDENTITY(1,1) NOT NULL," & vbCrLf &
                           "[CODIGO]             [varchar](20) Default  ('')," & vbCrLf &
                           "[DESCRIPCION]        [varchar](50) Default  ('')," & vbCrLf &
                           "[Mes_Ano]            [varchar](100) Default  ('')," & vbCrLf &
                           "[Mes]                [varchar](20) Default ('')," & vbCrLf &
                           "[Ano]                [varchar](4) Default  ('')," & vbCrLf &
                           "[Orden]              [Int] Default(0)," & vbCrLf &
                           "[Total]              [Float] Default(0)" & vbCrLf &
                           ") ON [PRIMARY]"

        Dim _Fecha_Desde As Date = Dtp_Fecha_Desde.Value
        Dim _Fecha_Hasta As Date = ultimodiadelmes(_Fecha_Desde)

        Dim _Fecha As Date = Dtp_Fecha_Desde.Value

        For Mes = 0 To _Meses

            For Each _Row_Datos As DataRow In _Tbl_Informe.Rows

                Dim _Codigo = _Row_Datos.Item("CODIGO")
                Dim _Descripcion = _Row_Datos.Item("DESCRIPCION")

                'Fecha = DateAdd(DateInterval.Month, 1, Fecha)

                Dim _Mes_Ano As String = UCase(MonthName(Month(_Fecha), False) & "." & _Fecha.Year)

                'Meses_(Mes) = FechaNw

                Dim FStr As String = Format(Primerdiadelmes(_Fecha), "yyyyMMdd")
                _Mes_Ano = "UPPER(DATENAME(MONTH,'" & FStr & "'))+'.'+DATENAME(YEAR,'" & FStr & "')"
                Dim _Mes_Palabra = "UPPER(DATENAME(MONTH,'" & FStr & "'))"

                _Sql_Puntos_Cero += "Insert Into #Paso1 (CODIGO,DESCRIPCION,Mes_Ano,Mes,Ano,Orden,VANELI) Values" & Space(1) &
                 "('" & _Codigo & "','" & _Descripcion & "'," & _Mes_Ano & "," & _Mes_Palabra & ",'" & Year(_Fecha) & "'," & Month(_Fecha) & ",0)" & vbCrLf

                Dim _SqlFiltro_Fechas = "And FEEMLI BETWEEN '" & Format(_Fecha_Desde, "yyyyMMdd") & "' AND '" &
                                         Format(_Fecha_Hasta, "yyyyMMdd") & "'" & vbCrLf

                Consulta_sql = "Select SUM(VANELI) As Total From " & _Nombre_Tabla_Paso & vbCrLf &
                               "Where 1 > 0 " & vbCrLf & _Sql_Filtro & vbCrLf & _SqlFiltro_Fechas & vbCrLf &
                               "And KOPRCT In" & vbCrLf &
                               "(Select Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf &
                               "Where Codigo_Nodo = " & _Codigo & ")"

                Dim _Row_Valor As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                Dim _Valor As Double

                If (_Row_Valor Is Nothing) Then
                    _Valor = 0
                Else
                    _Valor = NuloPorNro(_Row_Valor.Item("Total"), 0)
                End If

                _Sql_Mes_Query += "Insert Into #Paso1 (CODIGO,DESCRIPCION,Mes_Ano,Mes,Ano,Orden,Total) Values" & Space(1) &
                 "('" & _Codigo & "','" & _Descripcion & "'," & _Mes_Ano & "," & _Mes_Palabra & ",'" & Year(_Fecha) & "'," & Month(_Fecha) & "," & De_Num_a_Tx_01(_Valor, False, 5) & ")" & vbCrLf

            Next

            _Fecha = DateAdd(DateInterval.Month, 1, _Fecha)
            _Fecha_Desde = Primerdiadelmes(_Fecha)
            _Fecha_Hasta = ultimodiadelmes(_Fecha)

        Next

        _Sql_Grafico += vbCrLf & vbCrLf & _Sql_Mes_Query & vbCrLf &
                        "Select * From #Paso1" & vbCrLf &
                        "Drop Table #Paso1"

        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(_Sql_Grafico)

        Dim rows() As DataRow = _Tbl.Select("Total=MAX(Total)")
        Dim _Max

        If (rows.Length = 0) Then
            ' No hay ningún registro en la tabla TblFacturas.
            ' Devolvemos el número 1.
            _Max = 0

        Else
            ' Le sumamos una unidad al valor máximo
            ' existente en el campo NFactura.
            Dim numero As Object = rows(0).Item("Total")

            _Max = numero

        End If

        Return _Sql_Grafico

    End Function

    Sub Sb_Generar_Grafica_Linea_De_Tiempo_X_Year(_Grafico As Chart,
                                                  _Agrupar As String,
                                                  _Eje_X As String,
                                                  _Eje_Y As String)

        Dim _Index_Fila As Integer

        Try
            _Index_Fila = Grilla.CurrentRow.Index
        Catch ex As Exception
            _Index_Fila = 0
        End Try

        Dim _Fila As DataGridViewRow = Grilla.Rows(_Index_Fila)

        Dim _Codigo = _Fila.Cells(0).Value
        Dim _Descripcion = _Fila.Cells(1).Value
        Dim _Campo = Cmb_Vista_Informe.SelectedValue

        _Grafico.Series.Clear()

        Dim _Filtro_Nodos As String

        If _Filtro_Clas_BakApp_Todas Then
            _Filtro_Nodos = String.Empty
        Else
            _Filtro_Nodos = Generar_Filtro_IN(_Tbl_Filtro_Clas_BakApp, "Chk", "Codigo_Nodo", False, True, "")
            _Filtro_Nodos = "And KOPRCT In (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf &
                            "Where Codigo_Nodo In " & _Filtro_Nodos & ")"
        End If

        'Consulta_sql = "Select Distinct Ano From " & _Nombre_Tabla_Paso & vbCrLf &
        '               "Where 1 > 0" & _SqlFiltro_Detalle & vbCrLf &
        '               "Select Distinct " & _Cp_Codigo & " AS CODIGO," & _Cp_Descripcion & " AS DESCRIPCION" & vbCrLf &
        '               "From " & _Nombre_Tabla_Paso & vbCrLf &
        '               "Where 1 > 0" & _SqlFiltro_Detalle & vbCrLf & _Filtro_Nodos

        'Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

        'Dim _Tbl_Datos = _Ds.Tables(1)

        Dim _Sql_Puntos_Cero = String.Empty

        Dim _F1 As Date = Dtp_Fecha_Desde.Value
        Dim _F2 As Date = Dtp_Fecha_Hasta.Value

        Dim _Meses = DateDiff(DateInterval.Month, _F1, _F2) '+ 1
        Dim _Mes = _F1.Month

        Dim _New_SqlFiltro_Detalle = _SqlFiltro_Detalle

        _New_SqlFiltro_Detalle += "And " & _Campo & " = '" & _Codigo & "'"

        If _F1.Month = _F2.Month Then
            Consulta_sql = My.Resources.Recursos_Inf_Ventas.Inf_Grafico_Dinamica_Ventas_Mensuales_Fecha
        Else
            Consulta_sql = My.Resources.Recursos_Inf_Ventas.Inf_Grafico_Dinamica_Ventas_Mensuales
        End If

        Consulta_sql = Replace(Consulta_sql, "#CODIGO#", _Cp_Codigo)
        Consulta_sql = Replace(Consulta_sql, "#DESCRIPCION#", _Cp_Descripcion)
        Consulta_sql = Replace(Consulta_sql, "#Tabla_Paso#", _Nombre_Tabla_Paso)
        Consulta_sql = Replace(Consulta_sql, "#Filtro_Sql#", _New_SqlFiltro_Detalle & vbCrLf & _Filtro_Nodos)
        Consulta_sql = Replace(Consulta_sql, "#Filtro_Fechas#", "")
        Consulta_sql = Replace(Consulta_sql, "#Sql_Puntos_Cero#", _Sql_Puntos_Cero)

        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim rows() As DataRow = _Tbl.Select("Total=MAX(Total)")
        Dim _Max

        If (rows.Length = 0) Then
            ' No hay ningún registro en la tabla TblFacturas.
            ' Devolvemos el número 1.
            _Max = 0

        Else
            ' Le sumamos una unidad al valor máximo
            ' existente en el campo NFactura.
            Dim numero As Object = rows(0).Item("Total")

            _Max = numero

        End If


        Dim _Sql_DReader As System.Data.SqlClient.SqlDataReader
        _Sql_DReader = _Sql.Fx_SqlDataReader(Consulta_sql)

        ' Data bind chart to a table where all rows are grouped in series by the "Name" column
        If _F1.Month = _F2.Month Then
            _Grafico.DataBindCrossTable(_Sql_DReader, "Mes_Ano", "Dia", _Eje_Y, "Label=Total{C0}")
        Else
            _Grafico.DataBindCrossTable(_Sql_DReader, _Agrupar, _Eje_X, _Eje_Y, "Label=Total{C0}")
        End If

        _Sql.Sb_Cerrar_Conexion2()

        _Grafico.ChartAreas(0).AxisX.IsMarginVisible = True
        _Grafico.ChartAreas(0).AxisY.LabelStyle.Format = "C0"

        '_Grafico.ChartAreas(0).Axes(0).IntervalAutoMode = IntervalAutoMode.VariableCount
        '_Grafico.ChartAreas(0).Axes(1).IntervalAutoMode = IntervalAutoMode.VariableCount

        _Grafico.ChartAreas(0).AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount
        _Grafico.ChartAreas(0).AxisY.IntervalAutoMode = IntervalAutoMode.FixedCount

        '_Grafico.ChartAreas(0).Axes(0).IntervalType = DateTimeIntervalType.Auto

        '_Grafico.Legends("Default").BackColor = Color.White
        'Chart1.Legends("Default").BackSecondaryColor = Color.Green
        'Chart1.Legends("Default").BackGradientStyle = GradientStyle.DiagonalLeft

        '_Grafico.Legends("Default").BorderColor = Color.Black
        '_Grafico.Legends("Default").BorderWidth = 2
        '_Grafico.Legends("Default").BorderDashStyle = ChartDashStyle.Solid

        'Sombra leyenda
        _Grafico.Legends("Default").ShadowOffset = 0

        _Grafico.Legends("Default").DockedToChartArea = "Default"
        _Grafico.Legends("Default").InsideChartArea = "" '"Default"
        _Grafico.Legends("Default").Alignment = StringAlignment.Near

        _Grafico.Legends("Default").Docking = Docking.Right
        _Grafico.Legends("Default").LegendStyle = LegendStyle.Column
        _Grafico.Legends("Default").TableStyle = LegendTableStyle.Auto

        ' Set series chart type
        'Chart1.Series("Series1").ChartType = DirectCast([Enum].Parse(GetType(SeriesChartType), _
        '                                                             comboBoxChartType.Text, True), SeriesChartType)

        ' Set series appearance
        Dim marker As MarkerStyle = MarkerStyle.Circle
        Dim _Contador = 0

        For Each ser As Series In _Grafico.Series

            ser.ShadowOffset = 1
            ser.BorderWidth = 1

            'If CBool(_Meses) Then
            ser.ChartType = SeriesChartType.Line
            'Else
            'ser.ChartType = SeriesChartType.Column
            'End If

            'ser.Color = Color.FromArgb(255, 128, 128)

            ser.MarkerSize = 1
            ser.MarkerStyle = marker
            'ser.MarkerBorderColor = Color.FromArgb(64, 64, 64)
            ser.Font = New Font("Trebuchet MS", 8, FontStyle.Bold)
            ser.IsValueShownAsLabel = False

            For Each Punto In ser.Points
                Punto.Label = String.Empty
                Dim _Cod As String = Punto.XValue

            Next

            'ser.EmptyPointStyle.Color = Color.Red
            'ser.EmptyPointStyle.BorderWidth = 2
            'ser.EmptyPointStyle.BorderDashStyle = ChartDashStyle.Dash
            'ser.EmptyPointStyle.MarkerSize = 10
            'ser.EmptyPointStyle.MarkerStyle = MarkerStyle.Cross
            'ser.EmptyPointStyle.MarkerBorderColor = Color.Black
            'ser.EmptyPointStyle.MarkerColor = Color.Red

            ser.ToolTip = ser.Name

            Sb_Formato_Graficos(_Grafico, 0, _Contador)
            _Contador += 1

        Next


        ' Find point with maximum Y value and change color
        'Dim maxValuePoint As DataPoint = Grafico_Lineal.Series("Series1").Points.FindMaxValue()
        'maxValuePoint.Color = Color.FromArgb(255, 128, 128)

        ' Find point with minimum Y value and change color
        'Dim minValuePoint As DataPoint = Grafico_Lineal.Series("Series1").Points.FindMinValue()
        'minValuePoint.Color = Color.FromArgb(128, 128, 255)


        'For i = 0 To _Grafico.Series.Count - 1
        '    Try
        '        _Grafico.Series(i)("EmptyPointValue") = "Zero" '"Average"
        '    Catch ex As Exception

        '    End Try
        'Next

    End Sub

    Function Fx_Mes(Mes As Integer) As String

        Dim _Mes As String

        _Mes = MonthName(Mes, False)

        Return _Mes

    End Function


    Sub Sb_Generar_Grafica_Acumulativo_Grupal_X_Fechas()

        Grafico_Acumulado_X_Grupo.Series.Clear()

        Dim _Rango As String = FormatDateTime(Dtp_Fecha_Desde.Value, DateFormat.ShortDate) & " -> " & FormatDateTime(Dtp_Fecha_Hasta.Value, DateFormat.ShortDate)
        Dim _Filtro_Nodos As String

        If _Filtro_Clas_BakApp_Todas Then
            _Filtro_Nodos = String.Empty
        Else
            _Filtro_Nodos = Generar_Filtro_IN(_Tbl_Filtro_Clas_BakApp, "Chk", "Codigo_Nodo", False, True, "")
            _Filtro_Nodos = "And KOPRCT In (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf &
                            "Where Codigo_Nodo In " & _Filtro_Nodos & ")"
        End If

        Consulta_sql = "Select " & _Cp_Codigo & " As CODIGO," & _Cp_Descripcion & " As DESCRIPCION," &
                       "SUM(VANELI) As VANELI,CAST(0 as Float) as Porc,CAST(0 as Float) as Total" & vbCrLf &
                       "Into #Paso1" & vbCrLf &
                       "From " & _Nombre_Tabla_Paso & vbCrLf &
                       "Where 1 > 0" & vbCrLf &
                       _SqlFiltro_Detalle &
                       _Filtro_Nodos &
                       "Group By " & _Cp_Codigo & "," & _Cp_Descripcion & ",FEEMLI" & vbCrLf &
                       "Select Case When CODIGO = '' Then 'S/C' Else CODIGO End As CODIGO,DESCRIPCION," &
                       "Sum(VANELI) As Total,'" & _Rango & "' As Rango" & vbCrLf &
                       "From #Paso1" & vbCrLf &
                       "Group By CODIGO,DESCRIPCION,Total" & vbCrLf &
                       "Drop Table #Paso1"

        'Consulta_sql = _Sql_Consulta_Grafica_Acumulativa

        Dim _Sql_DReader As System.Data.SqlClient.SqlDataReader
        _Sql_DReader = _Sql.Fx_SqlDataReader(Consulta_sql)

        ' Data bind chart to a table where all rows are grouped in series by the "Name" column

        Grafico_Acumulado_X_Grupo.ChartAreas(0).AxisY.Minimum = 0 ' _Min '[Double].NaN
        Grafico_Acumulado_X_Grupo.ChartAreas(0).AxisY.Maximum = [Double].NaN

        Grafico_Acumulado_X_Grupo.ChartAreas(0).AxisY2.Minimum = 0 '_Min '[Double].NaN
        Grafico_Acumulado_X_Grupo.ChartAreas(0).AxisY2.Maximum = [Double].NaN

        Grafico_Acumulado_X_Grupo.DataBindCrossTable(_Sql_DReader, "Rango", "DESCRIPCION", "Total", "Label=Total{C0}")
        Grafico_Acumulado_X_Grupo.ChartAreas(0).AxisX.IsMarginVisible = True
        Grafico_Acumulado_X_Grupo.ChartAreas(0).AxisY.LabelStyle.Format = "C0"

        Grafico_Acumulado_X_Grupo.Legends("Default").BackColor = Color.White
        'Chart1.Legends("Default").BackSecondaryColor = Color.Green
        'Chart1.Legends("Default").BackGradientStyle = GradientStyle.DiagonalLeft

        Grafico_Acumulado_X_Grupo.Legends("Default").BorderColor = Color.Black
        Grafico_Acumulado_X_Grupo.Legends("Default").BorderWidth = 2
        Grafico_Acumulado_X_Grupo.Legends("Default").BorderDashStyle = ChartDashStyle.Solid
        'Sombra leyenda
        Grafico_Acumulado_X_Grupo.Legends("Default").ShadowOffset = 5

        Grafico_Acumulado_X_Grupo.ChartAreas(0).Area3DStyle.Enable3D = True


        ' Find point with maximum Y value and change color
        'Dim maxValuePoint As DataPoint = Grafico_Acumulado_X_Grupo.Series("Series1").Points.FindMaxValue()
        'maxValuePoint.Color = Color.FromArgb(255, 128, 128)

        ' Find point with minimum Y value and change color
        'Dim minValuePoint As DataPoint = Grafico_Acumulado_X_Grupo.Series("Series1").Points.FindMinValue()
        'minValuePoint.Color = Color.FromArgb(128, 128, 255)

        'Return
        ' Set series chart type
        'Chart1.Series("Series1").ChartType = DirectCast([Enum].Parse(GetType(SeriesChartType), _
        '                                                             comboBoxChartType.Text, True), SeriesChartType)

        ' Set series appearance
        Dim marker As MarkerStyle = MarkerStyle.None
        For Each ser As Series In Grafico_Acumulado_X_Grupo.Series

            ser.ShadowOffset = 1
            ser.BorderWidth = 3
            ser.ChartType = SeriesChartType.Column

            ser.MarkerSize = 5
            ser.MarkerStyle = marker
            ser.MarkerBorderColor = Color.FromArgb(64, 64, 64)
            ser.Font = New Font("Trebuchet MS", 8, FontStyle.Bold)
            ser.IsValueShownAsLabel = False

            For Each Punto In ser.Points
                Punto.Label = String.Empty
                Dim _Cod As String = Punto.AxisLabel
                Punto.ToolTip = _Cod '_Sql.Fx_Trae_Dato(_Nombre_Tabla_Paso, _Cp_Descripcion, _
                '                  _Cp_Codigo & " = '" & _Cod & "'")


                'Punto.Color = Color.FromArgb(MyAlpha, MyRed, MyGreen, MyBlue)

                'ser.Color = Color.FromArgb(255, 128, 128)
            Next

            'marker += 1
            'If marker > 9 Then
            'marker = MarkerStyle.Square
            'End If

        Next


    End Sub

    Sub Sb_Marcar_Grafico_Barras(_Codigo As String)

        ' Set series appearance
        Dim marker As MarkerStyle = MarkerStyle.None
        For Each ser As Series In Grafico_Acumulado_X_Grupo.Series

            ser.ShadowOffset = 1
            ser.BorderWidth = 3
            ser.ChartType = SeriesChartType.Column

            ser.MarkerSize = 5
            ser.MarkerStyle = marker
            ser.MarkerBorderColor = Color.FromArgb(64, 64, 64)
            ser.Font = New Font("Trebuchet MS", 8, FontStyle.Bold)
            ser.IsValueShownAsLabel = False

            For Each Punto In ser.Points
                Punto.Label = String.Empty
                Dim _Cod As String = Punto.AxisLabel

                If _Row_Vista.Item("ARBOL_BAKAPP") Then
                    'Punto.ToolTip = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TblArbol_Asociaciones", "Descripcion", _
                    '                                   "Codigo_Nodo = '" & _Codigo & "'")
                Else
                    Try
                        '    Punto.ToolTip = _Sql.Fx_Trae_Dato(_Nombre_Tabla_Paso, _Cp_Descripcion, _
                        '                                                 _Cp_Codigo & " = '" & _Cod & "'")
                    Catch ex As Exception
                        Punto.ToolTip = String.Empty
                    End Try
                End If

                Punto.ToolTip = String.Empty
                If String.IsNullOrEmpty(Trim(_Codigo)) Then _Codigo = "S/C"

                If _Codigo = _Cod Then
                    Punto.Color = Color.Red
                    Punto.BorderColor = Color.Coral
                Else
                    Punto.Color = Color.AliceBlue 'Color.FromArgb(64, 64, 64)
                    Punto.BorderColor = Color.Blue
                End If
                'Punto.Color = Color.FromArgb(MyAlpha, MyRed, MyGreen, MyBlue)

                'ser.Color = Color.FromArgb(255, 128, 128)
            Next

            'marker += 1
            'If marker > 9 Then
            'marker = MarkerStyle.Square
            'End If

        Next

    End Sub

    Sub Sb_Grafico_Pie_Acumulativo()

        Dim _TblPie As DataTable = Fx_Crea_Tabla_Con_Filtro(_Tbl_Informe, "1 > 0", "Porc")
        Dim _Coun As Integer = _TblPie.Rows.Count
        ' Populate series data
        Dim _yValues(_Coun - 1) As Double '= {65.62, 75.54, 60.45, 55.73, 70.42}
        Dim _xValues(_Coun - 1) As String '= {"France", "Canada", "UK", "USA", "Italy"}

        Dim series1 As Series = Grafico_Pie.Series(0)

        Dim _i = 0

        For Each _Fila As DataRow In _TblPie.Rows

            _yValues(_i) = _Fila.Item("Porc")

            Dim _Porc = FormatNumber(_Fila.Item("Porc") * 100, 1) ' FormatPercent(_Fila.Item("Porc"), 1)
            Dim _Codigo = _Fila.Item("CODIGO").ToString.Trim
            Dim _Descripcion = Mid(_Fila.Item("DESCRIPCION").ToString.Trim, 1, 17)

            If _Row_Vista.Item("ARBOL_BAKAPP") Then
                _xValues(_i) = _Descripcion
            Else
                If Rdb_Pie_Codigo.Checked Then
                    _xValues(_i) = _Porc & " - " & _Codigo
                ElseIf Rdb_Pie_Descripcion.Checked Then
                    _xValues(_i) = _Descripcion
                End If
            End If

            _i += 1

        Next

        series1.Points.DataBindXY(_xValues, _yValues)

        _i = 0

        For Each _Fila As DataRow In _TblPie.Rows

            _yValues(_i) = _Fila.Item("Porc")

            Dim _Porc = FormatPercent(_Fila.Item("Porc"), 1) ' FormatPercent(_Fila.Item("Porc"), 1)
            Dim _Codigo = _Fila.Item("CODIGO").ToString.Trim
            Dim _Descripcion = _Fila.Item("DESCRIPCION").ToString.Trim

            series1.Points.Item(_i).ToolTip = _Codigo & " - " & _Descripcion & " (" & _Porc & ")"
            _i += 1

        Next





        Grafico_Pie.ChartAreas(0).BackColor = Color.FromArgb(Global_camvasColor)

        Dim _Num_Agrupador As Double = Num_Agrupador_Pie.Value / 100


        'If Not Chk_Agrupar_Pie.Checked Then _Num_Agrupador = 0

        '' Establezca el umbral bajo el cual se recogerán todos los puntos
        series1("CollectedThreshold") = Num_Agrupador_Pie.Value '- 0.01 ' _Num_Agrupador * 10 '0.1
        '' Establecer el tipo de umbral para ser un porcentaje del PIE Grafico
        '' Cuando se establece en falso, esta propiedad usa el valor real para determinar el umbral recolectado
        series1("CollectedThresholdUsePercent") = True 'Chk_Agrupar_Pie.Checked ' "true"

        '' Establecer la etiqueta de la porción de PIE Grafico recogido
        series1("CollectedLabel") = "Grupo de ventas <= " & FormatPercent(_Num_Agrupador, 0)

        '' Establecer el texto de la leyenda del sector de PIE Grafico recogido
        series1("CollectedLegendText") = "Grupo de ventas <= " & FormatPercent(_Num_Agrupador, 0) '"Otros 02"

        '' Establecer el sector de PIE Grafico recogido a explotar
        series1("CollectedSliceExploded") = "true"

        '' Establecer el color de la porción de PIE Grafico recogido
        series1("CollectedColor") = "Green"

        '' Establezca la información sobre herramientas de la porción de gráfico recopilada
        series1("CollectedToolTip") = "Grupo de ventas <= " & FormatPercent(_Num_Agrupador, 0) '"Otros 03"


        Select Case Global_Thema
            Case Enum_Themas.Claro
                series1.Palette = ChartColorPalette.BrightPastel
                series1.LabelForeColor = Color.FromArgb(32, 32, 32)
            Case Enum_Themas.Gris
                series1.Palette = ChartColorPalette.BrightPastel
                series1.LabelForeColor = Color.FromArgb(32, 32, 32)
            Case Enum_Themas.Oscuro
                series1.Palette = ChartColorPalette.Chocolate
                series1.LabelForeColor = Color.FromArgb(226, 226, 226)
                Grafico_Pie.Legends(0).ForeColor = Color.FromArgb(226, 226, 226)
            Case Enum_Themas.Azul
                series1.Palette = ChartColorPalette.SeaGreen
                series1.LabelForeColor = Color.FromArgb(60, 64, 67)
                Grafico_Pie.Legends(0).ForeColor = Color.FromArgb(60, 64, 67)
        End Select


        Grafico_Pie.ChartAreas(0).Area3DStyle.Enable3D = Chk_Ver_Pie_3D.Checked


        Grafico_Pie.Legends(0).Enabled = Chk_Ver_Leyenda.Checked
        Grafico_Pie.Legends(0).BackColor = Color.FromArgb(Global_camvasColor)


        'SEIRES1.LabelStyle.Font = New Font("Arial", 10)


        ' MUESTRA EL PORCENTAJE EN LAS ETIQUETAS DEL GRAFICO

        If Rdb_Pie_Codigo.Checked Then
            series1.Label = "#PERCENT{P2}"
        Else
            series1.Label = String.Empty
        End If

        'Chart1.ChartAreas("Default")
        series1.Font = New Font("Arial", 7)


        ' Set chart type and title
        series1.ChartType = SeriesChartType.Pie ' DirectCast([Enum].Parse(GetType(SeriesChartType), comboBoxChartType.Text, True), SeriesChartType)
        'Grafico_Pie.Titles(0).Text = "Porcentaje de ventas según selección" 'comboBoxChartType.Text + " Chart"

        ' Set labels style

        If Chk_Ver_Pie_3D.Checked Then
            series1("PieLabelStyle") = "Outside" ' comboBoxLabelStyle.Text
        Else
            series1("PieLabelStyle") = Nothing
        End If


        ' Set Doughnut hole size
        'series1("Default")("DoughnutRadius") = "Radio Tex" 'comboBoxRadius.Text

        ' Disable Doughnut hole size control for Pie chart
        'comboBoxRadius.Enabled = (comboBoxChartType.Text <> "Pie")

        ' Explode selected country
        For Each point As DataPoint In Grafico_Pie.Series(0).Points
            'point("")
            point("Exploded") = "false"
            If point.AxisLabel = "SALMON" Then
                point("Exploded") = "true"
            End If
        Next

    End Sub

#End Region

    Private Sub Sb_Grilla_CellEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

        Try

            'Return
            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

            Dim _Codigo As String = _Fila.Cells("CODIGO").Value
            'Dim _Descripcion As String = _Fila.Cells("DESCRIPCION").Value

            If _Row_Vista.Item("ARBOL_BAKAPP") Then
                _Codigo = _Fila.Cells("DESCRIPCION").Value
            Else
                If Rdb_Pie_Codigo.Checked Then
                    _Codigo = _Fila.Cells("CODIGO").Value
                ElseIf Rdb_Pie_Descripcion.Checked Then
                    _Codigo = _Fila.Cells("DESCRIPCION").Value
                End If
            End If

            For Each point As DataPoint In Grafico_Pie.Series("Default").Points
                'point("")
                point("Exploded") = "false"
                If Trim(point.AxisLabel) = Trim(_Codigo) Then
                    point("Exploded") = "true"
                End If
            Next

            '_Codigo = _Fila.Cells("CODIGO").Value

            Sb_Marcar_Grafico_Barras(_Codigo)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Chk_Ver_Pie_3D_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Chk_Ver_Pie_3D.CheckedChanged
        'Grafico_Pie.ChartAreas(0).Area3DStyle.Enable3D = Chk_Ver_Pie_3D.Checked
    End Sub

    Private Sub Rdb_CheckedChanged(sender As System.Object, e As System.EventArgs)
        Sb_Grafico_Pie_Acumulativo()
    End Sub

    Private Sub Btn_Filtrar_Entidades_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Filtrar_Entidades.Click
        ShowContextMenu(Menu_Contextual_Filtros_Entidades)
    End Sub

    Private Sub Btn_Filtrar_Productos_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Filtrar_Productos.Click
        ShowContextMenu(Menu_Contextual_Filtros_Productos)
    End Sub

    Private Sub Btn_Filtrar_Suc_Bod_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Filtrar_Suc_Bod.Click
        ShowContextMenu(Menu_Contextual_Filtros_Suc_Bod)
    End Sub

    Private Sub Btn_Filtrar_Funcionarios_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Filtrar_Funcionarios.Click
        ShowContextMenu(Menu_Contextual_Filtros_Funcionarios)
    End Sub

    Private Sub Btn_Filtro_Pro_Productos_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Filtro_Pro_Productos.Click
        Dim _SqlFiltro_Fechas As String

        _SqlFiltro_Fechas = "Where FEEMLI BETWEEN '" & Format(Dtp_Fecha_Desde.Value, "yyyyMMdd") & "' AND '" &
                             Format(Dtp_Fecha_Hasta.Value, "yyyyMMdd") & "'" & vbCrLf

        Dim _Sql_Filtro_Condicion_Extra = "And KOPR In (Select Distinct KOPRCT From " &
                                          _Nombre_Tabla_Paso & vbCrLf & _SqlFiltro_Fechas & ")"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Productos,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Productos, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Productos_Todos, False) Then

            _Tbl_Filtro_Productos = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Productos_Todos = _Filtrar.Pro_Filtro_Todas

            Sb_Actualizar_Grilla(False)
        End If
    End Sub

    Private Sub Btn_Filtro_Pro_Super_Familias_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Filtro_Pro_Super_Familias.Click

        Dim _SqlFiltro_Fechas As String

        _SqlFiltro_Fechas = "Where FEEMLI BETWEEN '" & Format(Dtp_Fecha_Desde.Value, "yyyyMMdd") & "' AND '" &
                             Format(Dtp_Fecha_Hasta.Value, "yyyyMMdd") & "'" & vbCrLf

        Dim _Sql_Filtro_Condicion_Extra = "And KOFM In (Select Distinct FMPR From " &
                                          _Nombre_Tabla_Paso & vbCrLf & _SqlFiltro_Fechas & ")"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Super_Familias,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Tabla_Super_Familia, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Super_Familias_Todas) Then

            _Tbl_Filtro_Super_Familias = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Super_Familias_Todas = _Filtrar.Pro_Filtro_Todas

            If Cmb_Vista_Informe.SelectedValue = "FMPR" Then
                Sb_Actualizar_Grilla(False)
            Else
                Cmb_Vista_Informe.SelectedValue = "FMPR"
            End If

        End If
    End Sub

    Private Sub Btn_Filtro_Pro_Familias_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Filtro_Pro_Familias.Click

        Dim _SqlFiltro_Fechas As String

        _SqlFiltro_Fechas = "Where FEEMLI BETWEEN '" & Format(Dtp_Fecha_Desde.Value, "yyyyMMdd") & "' AND '" &
                             Format(Dtp_Fecha_Hasta.Value, "yyyyMMdd") & "'" & vbCrLf

        Dim _Sql_Filtro_Condicion_Extra = String.Empty
        Dim _Filtro_Extra_Familias = String.Empty

        If Not _Filtro_Super_Familias_Todas Then
            If Not (_Tbl_Filtro_Super_Familias Is Nothing) Then
                If _Tbl_Filtro_Super_Familias.Rows.Count Then

                    Dim _Fl_Super_Familias = Generar_Filtro_IN(_Tbl_Filtro_Super_Familias, "Chk", "Codigo", False, True, "'")
                    _Filtro_Extra_Familias = vbCrLf & "And KOFM In " & _Fl_Super_Familias

                End If
            End If
        End If

        _Sql_Filtro_Condicion_Extra = "And KOPF In (Select Distinct PFPR From " &
                                       _Nombre_Tabla_Paso & vbCrLf & _SqlFiltro_Fechas & ")" & _Filtro_Extra_Familias

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Familias,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Tabla_Familia, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Familias_Todas) Then

            _Tbl_Filtro_Familias = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Familias_Todas = _Filtrar.Pro_Filtro_Todas

            If Cmb_Vista_Informe.SelectedValue = "PFPR" Then
                Sb_Actualizar_Grilla(False)
            Else
                Cmb_Vista_Informe.SelectedValue = "PFPR"
            End If
        End If

    End Sub

    Private Sub Btn_Filtro_Pro_Sub_Familias_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Filtro_Pro_Sub_Familias.Click

        Dim _SqlFiltro_Fechas As String

        _SqlFiltro_Fechas = "Where FEEMLI BETWEEN '" & Format(Dtp_Fecha_Desde.Value, "yyyyMMdd") & "' AND '" &
                             Format(Dtp_Fecha_Hasta.Value, "yyyyMMdd") & "'" & vbCrLf

        Dim _Sql_Filtro_Condicion_Extra = String.Empty
        Dim _Filtro_Extra_Familias = String.Empty

        If Not _Filtro_Super_Familias_Todas Then
            If Not (_Tbl_Filtro_Super_Familias Is Nothing) Then
                If _Tbl_Filtro_Super_Familias.Rows.Count Then

                    Dim _Fl_Super_Familias = Generar_Filtro_IN(_Tbl_Filtro_Super_Familias, "Chk", "Codigo", False, True, "'")
                    _Filtro_Extra_Familias = vbCrLf & "And KOFM In " & _Fl_Super_Familias

                End If
            End If
        End If

        If Not _Filtro_Familias_Todas Then
            If Not (_Tbl_Filtro_Familias Is Nothing) Then
                If _Tbl_Filtro_Familias.Rows.Count Then

                    Dim _Fl_Familias = Generar_Filtro_IN(_Tbl_Filtro_Familias, "Chk", "Codigo", False, True, "'")
                    _Filtro_Extra_Familias += vbCrLf & "And KOFM+KOPF In " & _Fl_Familias

                End If
            End If
        End If

        _Sql_Filtro_Condicion_Extra = "And KOPF In (Select Distinct PFPR From " &
                                       _Nombre_Tabla_Paso & vbCrLf & _SqlFiltro_Fechas & ")" & vbCrLf &
                                       _Filtro_Extra_Familias

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Sub_Familias,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Tabla_Sub_Familia, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Sub_Familias_Todas) Then

            _Tbl_Filtro_Sub_Familias = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Sub_Familias_Todas = _Filtrar.Pro_Filtro_Todas

            If Cmb_Vista_Informe.SelectedValue = "HFPR" Then
                Sb_Actualizar_Grilla(False)
            Else
                Cmb_Vista_Informe.SelectedValue = "HFPR"
            End If

        End If

    End Sub

    Private Sub Btn_Filtro_Pro_Marcas_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Filtro_Pro_Marcas.Click

        Dim _SqlFiltro_Fechas As String

        _SqlFiltro_Fechas = "Where FEEMLI BETWEEN '" & Format(Dtp_Fecha_Desde.Value, "yyyyMMdd") & "' AND '" &
                             Format(Dtp_Fecha_Hasta.Value, "yyyyMMdd") & "'" & vbCrLf

        Dim _Sql_Filtro_Condicion_Extra = "And KOMR In (Select Distinct MRPR From " &
                                          _Nombre_Tabla_Paso & vbCrLf & _SqlFiltro_Fechas & ")"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Marcas,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Tabla_Marcas, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Marcas_Todas) Then

            _Tbl_Filtro_Marcas = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Marcas_Todas = _Filtrar.Pro_Filtro_Todas

            If Cmb_Vista_Informe.SelectedValue = "MRPR" Then
                Sb_Actualizar_Grilla(False)
            Else
                Cmb_Vista_Informe.SelectedValue = "MRPR"
            End If

        End If

    End Sub

    Private Sub Btn_Filtro_Pro_Clas_Libre_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Filtro_Pro_Clas_Libre.Click

        Dim _SqlFiltro_Fechas As String

        _SqlFiltro_Fechas = "Where FEEMLI BETWEEN '" & Format(Dtp_Fecha_Desde.Value, "yyyyMMdd") & "' AND '" &
                             Format(Dtp_Fecha_Hasta.Value, "yyyyMMdd") & "'" & vbCrLf

        Dim _Sql_Filtro_Condicion_Extra = "And KOTABLA = 'CLALIBPR' And KOCARAC In (Select Distinct CLALIBPR From " &
                                          _Nombre_Tabla_Paso & vbCrLf & _SqlFiltro_Fechas & ")"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Clalibpr,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Tabla_Tabcarac, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Clalibpr_Todas) Then

            _Tbl_Filtro_Clalibpr = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Clalibpr_Todas = _Filtrar.Pro_Filtro_Todas

            If Cmb_Vista_Informe.SelectedValue = "CLALIBPR" Then
                Sb_Actualizar_Grilla(False)
            Else
                Cmb_Vista_Informe.SelectedValue = "CLALIBPR"
            End If

        End If

    End Sub

    Private Sub Btn_Filtro_Pro_Rubros_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Filtro_Pro_Rubros.Click

        Dim _SqlFiltro_Fechas As String

        _SqlFiltro_Fechas = "Where FEEMLI BETWEEN '" & Format(Dtp_Fecha_Desde.Value, "yyyyMMdd") & "' AND '" &
                             Format(Dtp_Fecha_Hasta.Value, "yyyyMMdd") & "'" & vbCrLf

        Dim _Sql_Filtro_Condicion_Extra = "And KORU In (Select Distinct RUPR From " &
                                          _Nombre_Tabla_Paso & vbCrLf & _SqlFiltro_Fechas & ")"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Rubro_Productos,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Tabla_Rubros, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Rubro_Productos_Todas, True) Then

            _Tbl_Filtro_Rubro_Productos = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Rubro_Productos_Todas = _Filtrar.Pro_Filtro_Todas

            If Cmb_Vista_Informe.SelectedValue = "RUPR" Then
                Sb_Actualizar_Grilla(False)
            Else
                Cmb_Vista_Informe.SelectedValue = "RUPR"
            End If

        End If

    End Sub

    Private Sub Btn_Filtro_Pro_Zonas_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Filtro_Pro_Zonas.Click

        Dim _SqlFiltro_Fechas As String

        _SqlFiltro_Fechas = "Where FEEMLI BETWEEN '" & Format(Dtp_Fecha_Desde.Value, "yyyyMMdd") & "' AND '" &
                             Format(Dtp_Fecha_Hasta.Value, "yyyyMMdd") & "'" & vbCrLf

        Dim _Sql_Filtro_Condicion_Extra = "And KOZO In (Select Distinct ZOPR From " &
                                          _Nombre_Tabla_Paso & vbCrLf & _SqlFiltro_Fechas & ")"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Zonas_Productos,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Tabla_Zonas, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Zonas_Productos_Todas, True) Then

            _Tbl_Filtro_Zonas_Productos = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Zonas_Productos_Todas = _Filtrar.Pro_Filtro_Todas

            If Cmb_Vista_Informe.SelectedValue = "ZOPR" Then
                Sb_Actualizar_Grilla(False)
            Else
                Cmb_Vista_Informe.SelectedValue = "ZOPR"
            End If

        End If

    End Sub

    Private Sub Btn_Filtro_Ent_Ciudades_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Filtro_Ent_Ciudades.Click
        Dim _SqlFiltro_Fechas As String

        _SqlFiltro_Fechas = "Where FEEMLI BETWEEN '" & Format(Dtp_Fecha_Desde.Value, "yyyyMMdd") & "' AND '" &
                             Format(Dtp_Fecha_Hasta.Value, "yyyyMMdd") & "'" & vbCrLf

        Dim _Sql_Filtro_Condicion_Extra = "And KOCI In (Select Distinct CIEN From " &
                                          _Nombre_Tabla_Paso & vbCrLf & _SqlFiltro_Fechas & ")"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Ciudad,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Ciudades, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Ciudad_Todas, False) Then

            _Tbl_Filtro_Ciudad = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Ciudad_Todas = _Filtrar.Pro_Filtro_Todas

            If Cmb_Vista_Informe.SelectedValue = "CIEN" Then
                Sb_Actualizar_Grilla(False)
            Else
                Cmb_Vista_Informe.SelectedValue = "CIEN"
            End If

        End If
    End Sub

    Private Sub Btn_Filtro_Ent_Comunas_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Filtro_Ent_Comunas.Click
        Dim _SqlFiltro_Fechas As String

        _SqlFiltro_Fechas = "Where FEEMLI BETWEEN '" & Format(Dtp_Fecha_Desde.Value, "yyyyMMdd") & "' AND '" &
                             Format(Dtp_Fecha_Hasta.Value, "yyyyMMdd") & "'"

        Dim _Sql_Filtro_Condicion_Extra = String.Empty
        Dim _Filtro_Extra_Comunas = String.Empty

        If Not _Filtro_Ciudad_Todas Then
            If Not (_Tbl_Filtro_Ciudad Is Nothing) Then
                If _Tbl_Filtro_Ciudad.Rows.Count Then
                    Dim _Fl_Ciudad = Generar_Filtro_IN(_Tbl_Filtro_Ciudad, "Chk", "Codigo", False, True, "'")
                    _Filtro_Extra_Comunas = vbCrLf & "And KOPA+KOCI In " & _Fl_Ciudad
                End If
            End If
        End If

        _Sql_Filtro_Condicion_Extra = "And KOCI In (Select Distinct CIEN From " &
                                       _Nombre_Tabla_Paso & vbCrLf & _SqlFiltro_Fechas & ")" & vbCrLf & _Filtro_Extra_Comunas

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Comunas,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Comunas, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Comunas_Todas, False) Then

            _Tbl_Filtro_Comunas = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Comunas_Todas = _Filtrar.Pro_Filtro_Todas

            If Cmb_Vista_Informe.SelectedValue = "CMEN" Then
                Sb_Actualizar_Grilla(False)
            Else
                Cmb_Vista_Informe.SelectedValue = "CIEN+CMEN"
            End If

        End If
    End Sub

    Private Sub Btn_Filtro_Ent_Rubros_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Filtro_Ent_Rubros.Click
        Dim _SqlFiltro_Fechas As String

        _SqlFiltro_Fechas = "Where FEEMLI BETWEEN '" & Format(Dtp_Fecha_Desde.Value, "yyyyMMdd") & "' AND '" &
                             Format(Dtp_Fecha_Hasta.Value, "yyyyMMdd") & "'" & vbCrLf

        Dim _Sql_Filtro_Condicion_Extra = "And KORU In (Select Distinct RUEN From " &
                                          _Nombre_Tabla_Paso & vbCrLf & _SqlFiltro_Fechas & ")"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Rubro_Entidades,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Tabla_Rubros, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Rubro_Entidades_Todas, True) Then

            _Tbl_Filtro_Rubro_Entidades = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Rubro_Entidades_Todas = _Filtrar.Pro_Filtro_Todas

            If Cmb_Vista_Informe.SelectedValue = "RUEN" Then
                Sb_Actualizar_Grilla(False)
            Else
                Cmb_Vista_Informe.SelectedValue = "RUEN"
            End If

        End If
    End Sub

    Private Sub Btn_Filtro_Ent_Zonas_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Filtro_Ent_Zonas.Click
        Dim _SqlFiltro_Fechas As String

        _SqlFiltro_Fechas = "Where FEEMLI BETWEEN '" & Format(Dtp_Fecha_Desde.Value, "yyyyMMdd") & "' AND '" &
                             Format(Dtp_Fecha_Hasta.Value, "yyyyMMdd") & "'" & vbCrLf

        Dim _Sql_Filtro_Condicion_Extra = "And KOZO In (Select Distinct ZOEN From " &
                                          _Nombre_Tabla_Paso & vbCrLf & _SqlFiltro_Fechas & ")"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Zonas_Entidades,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Tabla_Zonas, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Zonas_Entidades_Todas, True) Then

            _Tbl_Filtro_Zonas_Entidades = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Zonas_Entidades_Todas = _Filtrar.Pro_Filtro_Todas

            If Cmb_Vista_Informe.SelectedValue = "ZOEN" Then
                Sb_Actualizar_Grilla(False)
            Else
                Cmb_Vista_Informe.SelectedValue = "ZOEN"
            End If

        End If
    End Sub

    Private Sub Btn_Filtro_Ent_Tipo_Entidad_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Filtro_Ent_Tipo_Entidad.Click
        Dim _SqlFiltro_Fechas As String

        _SqlFiltro_Fechas = "Where FEEMLI BETWEEN '" & Format(Dtp_Fecha_Desde.Value, "yyyyMMdd") & "' AND '" &
                             Format(Dtp_Fecha_Hasta.Value, "yyyyMMdd") & "'"

        Dim _Sql_Filtro_Condicion_Extra = "And KOTABLA = 'TIPOENTIDA' And KOCARAC In (Select Distinct TIPOEN From " &
                                          _Nombre_Tabla_Paso & vbCrLf & _SqlFiltro_Fechas & ")"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Tipo_Entidad,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Tabla_Tabcarac, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Tipo_Entidad_Todas) Then

            _Tbl_Filtro_Tipo_Entidad = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Tipo_Entidad_Todas = _Filtrar.Pro_Filtro_Todas

            If Cmb_Vista_Informe.SelectedValue = "TIPOEN" Then
                Sb_Actualizar_Grilla(False)
            Else
                Cmb_Vista_Informe.SelectedValue = "TIPOEN"
            End If

        End If
    End Sub

    Private Sub Btn_Filtro_Ent_Act_Economica_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Filtro_Ent_Act_Economica.Click
        Dim _SqlFiltro_Fechas As String

        _SqlFiltro_Fechas = "Where FEEMLI BETWEEN '" & Format(Dtp_Fecha_Desde.Value, "yyyyMMdd") & "' AND '" &
                             Format(Dtp_Fecha_Hasta.Value, "yyyyMMdd") & "'" & vbCrLf

        Dim _Sql_Filtro_Condicion_Extra = "And KOTABLA = 'ACTIVIDADE' And KOCARAC In (Select Distinct ACTIEN From " &
                                          _Nombre_Tabla_Paso & vbCrLf & _SqlFiltro_Fechas & ")"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Act_Economica,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Tabla_Tabcarac, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Act_Economica_Todas) Then

            _Tbl_Filtro_Act_Economica = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Act_Economica_Todas = _Filtrar.Pro_Filtro_Todas

            If Cmb_Vista_Informe.SelectedValue = "ACTIEN" Then
                Sb_Actualizar_Grilla(False)
            Else
                Cmb_Vista_Informe.SelectedValue = "ACTIEN"
            End If

        End If
    End Sub

    Private Sub Btn_Filtro_Ent_Tamano_Empresa_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Filtro_Ent_Tamano_Empresa.Click
        Dim _SqlFiltro_Fechas As String

        _SqlFiltro_Fechas = "Where FEEMLI BETWEEN '" & Format(Dtp_Fecha_Desde.Value, "yyyyMMdd") & "' AND '" &
                             Format(Dtp_Fecha_Hasta.Value, "yyyyMMdd") & "'" & vbCrLf

        Dim _Sql_Filtro_Condicion_Extra = "And KOTABLA = 'TAMA¥OEMPR' And KOCARAC In (Select Distinct TAMAEN From " &
                                          _Nombre_Tabla_Paso & vbCrLf & _SqlFiltro_Fechas & ")"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Tama_Empresa,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Tabla_Tabcarac, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Tama_Empresa_Todas) Then

            _Tbl_Filtro_Tama_Empresa = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Tama_Empresa_Todas = _Filtrar.Pro_Filtro_Todas

            If Cmb_Vista_Informe.SelectedValue = "TAMAEN" Then
                Sb_Actualizar_Grilla(False)
            Else
                Cmb_Vista_Informe.SelectedValue = "TAMAEN"
            End If

        End If
    End Sub

    Private Sub Btn_Filtro_Responzables_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Filtro_Responzables.Click
        Dim _SqlFiltro_Fechas As String

        _SqlFiltro_Fechas = "Where FEEMLI BETWEEN '" & Format(Dtp_Fecha_Desde.Value, "yyyyMMdd") & "' AND '" &
                             Format(Dtp_Fecha_Hasta.Value, "yyyyMMdd") & "'"

        Dim _Sql_Filtro_Condicion_Extra = "And KOFU In (Select Distinct KOFUDO From " &
                                          _Nombre_Tabla_Paso & vbCrLf & _SqlFiltro_Fechas & ")"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Responzables,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Funcionarios_Random, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Responzables_Todas, False) Then

            _Tbl_Filtro_Responzables = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Responzables_Todas = _Filtrar.Pro_Filtro_Todas

            If Cmb_Vista_Informe.SelectedValue = "KOFUDO" Then
                Sb_Actualizar_Grilla(False)
            Else
                Cmb_Vista_Informe.SelectedValue = "KOFUDO"
            End If
        End If
    End Sub

    Private Sub Btn_Filtro_Vendedores_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Filtro_Vendedores.Click
        If Fx_Tiene_Permiso(Me, "Inf00025") Then
            Dim _SqlFiltro_Fechas As String

            _SqlFiltro_Fechas = "Where FEEMLI BETWEEN '" & Format(Dtp_Fecha_Desde.Value, "yyyyMMdd") & "' AND '" &
                                 Format(Dtp_Fecha_Hasta.Value, "yyyyMMdd") & "'"

            Dim _Sql_Filtro_Condicion_Extra = "And KOFU In (Select Distinct KOFULIDO From " &
                                              _Nombre_Tabla_Paso & vbCrLf & _SqlFiltro_Fechas & ")"

            Dim _Filtrar As New Clas_Filtros_Random(Me)

            If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Vendedores,
                                   Clas_Filtros_Random.Enum_Tabla_Fl._Funcionarios_Random, _Sql_Filtro_Condicion_Extra,
                                   _Filtro_Vendedores_Todas, False) Then

                _Tbl_Filtro_Vendedores = _Filtrar.Pro_Tbl_Filtro
                _Filtro_Vendedores_Todas = _Filtrar.Pro_Filtro_Todas

                If Cmb_Vista_Informe.SelectedValue = "KOFULIDO" Then
                    Sb_Actualizar_Grilla(False)
                Else
                    Cmb_Vista_Informe.SelectedValue = "KOFULIDO"
                End If
            End If
        End If
    End Sub

    Private Sub Btn_Filtro_Sucursales_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Filtro_Sucursales.Click

        Dim _SqlFiltro_Fechas As String

        _SqlFiltro_Fechas = "Where FEEMLI BETWEEN '" & Format(Dtp_Fecha_Desde.Value, "yyyyMMdd") & "' AND '" &
                             Format(Dtp_Fecha_Hasta.Value, "yyyyMMdd") & "'" & vbCrLf

        Dim _Sql_Filtro_Condicion_Extra = "And EMPRESA+KOSU In (Select Distinct EMPRESA+SULIDO From " &
                                          _Nombre_Tabla_Paso & vbCrLf & _SqlFiltro_Fechas & ")"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Sucursales,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Sucursales, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Sucursales_Todas, False) Then

            _Tbl_Filtro_Sucursales = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Sucursales_Todas = _Filtrar.Pro_Filtro_Todas

            If Cmb_Vista_Informe.SelectedValue = "SULIDO" Then
                Sb_Actualizar_Grilla(False)
            Else
                Cmb_Vista_Informe.SelectedValue = "SULIDO"
            End If

        End If

    End Sub

    Private Sub Btn_Filtro_Bodegas_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Filtro_Bodegas.Click

        Dim _SqlFiltro_Fechas As String

        _SqlFiltro_Fechas = "Where FEEMLI BETWEEN '" & Format(Dtp_Fecha_Desde.Value, "yyyyMMdd") & "' AND '" &
                             Format(Dtp_Fecha_Hasta.Value, "yyyyMMdd") & "'" & vbCrLf

        Dim _Sql_Filtro_Condicion_Extra = "And EMPRESA+KOSU+KOBO In (Select Distinct EMPRESA+SULIDO+BOSULIDO From " &
                                          _Nombre_Tabla_Paso & vbCrLf & _SqlFiltro_Fechas & ")"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Bodegas,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Bodegas, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Bodegas_Todas, False) Then

            _Tbl_Filtro_Bodegas = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Bodegas_Todas = _Filtrar.Pro_Filtro_Todas

            If Cmb_Vista_Informe.SelectedValue = "BOSULIDO" Then
                Sb_Actualizar_Grilla(False)
            Else
                Cmb_Vista_Informe.SelectedValue = "BOSULIDO"
            End If

        End If

    End Sub

    Sub Sb_Imagenes_Filtros()

        Btn_Filtro_Responzables.Image = Fx_Imagen_Filtro(_Filtro_Responzables_Todas)
        Btn_Filtro_Vendedores.Image = Fx_Imagen_Filtro(_Filtro_Vendedores_Todas)
        Btn_Filtro_Vendedor_Asignado_Entidad.Image = Fx_Imagen_Filtro(_Filtro_Vendedores_Asignados_Todas)

        If Not _Filtro_Vendedores_Todas Or Not _Filtro_Responzables_Todas Or Not _Filtro_Vendedores_Asignados_Todas Then
            Btn_Filtrar_Funcionarios.Image = Imagenes_16x16.Images.Item("filter.png")
        Else
            Btn_Filtrar_Funcionarios.Image = Nothing
        End If

        Btn_Filtro_Ent_Entidades.Image = Fx_Imagen_Filtro(_Filtro_Entidad_Todas)
        Btn_Filtro_Ent_EntidadesExcluidas.Image = Fx_Imagen_Filtro(Not (Not IsNothing(_Tbl_Filtro_EntidadExcluidas) AndAlso CBool(_Tbl_Filtro_EntidadExcluidas.Rows.Count)))
        Btn_Filtro_Ent_Ciudades.Image = Fx_Imagen_Filtro(_Filtro_Ciudad_Todas)
        Btn_Filtro_Ent_Comunas.Image = Fx_Imagen_Filtro(_Filtro_Comunas_Todas)
        Btn_Filtro_Ent_Rubros.Image = Fx_Imagen_Filtro(_Filtro_Rubro_Entidades_Todas)
        Btn_Filtro_Ent_Zonas.Image = Fx_Imagen_Filtro(_Filtro_Zonas_Entidades_Todas)
        Btn_Filtro_Ent_Act_Economica.Image = Fx_Imagen_Filtro(_Filtro_Act_Economica_Todas)
        Btn_Filtro_Ent_Tipo_Entidad.Image = Fx_Imagen_Filtro(_Filtro_Tipo_Entidad_Todas)
        Btn_Filtro_Ent_Tamano_Empresa.Image = Fx_Imagen_Filtro(_Filtro_Tama_Empresa_Todas)
        Btn_Filtro_Ent_Lista_Precio_Asig.Image = Fx_Imagen_Filtro(_Filtro_Lista_Precio_Asig_Todas)
        Btn_Filtro_Ent_Lista_Precio_Doc.Image = Fx_Imagen_Filtro(_Filtro_Lista_Precio_Docu_Todas)

        Btn_Filtrar_Clas_BakApp.Image = Fx_Imagen_Filtro(_Filtro_Clas_BakApp_Todas)

        If Not _Filtro_Entidad_Todas Or
           Not _Filtro_Ciudad_Todas Or
           Not _Filtro_Comunas_Todas Or
           Not _Filtro_Rubro_Entidades_Todas Or
           Not _Filtro_Zonas_Entidades_Todas Or
           Not _Filtro_Act_Economica_Todas Or
           Not _Filtro_Tipo_Entidad_Todas Or
           Not _Filtro_Tama_Empresa_Todas Or
           Not _Filtro_Lista_Precio_Asig_Todas Or
           Not _Filtro_Lista_Precio_Docu_Todas Or
           (Not IsNothing(_Tbl_Filtro_EntidadExcluidas) AndAlso CBool(_Tbl_Filtro_EntidadExcluidas.Rows.Count)) Then

            Btn_Filtrar_Entidades.Image = Imagenes_16x16.Images.Item("filter.png")
        Else
            Btn_Filtrar_Entidades.Image = Nothing
        End If

        Btn_Filtro_Pro_Productos.Image = Fx_Imagen_Filtro(_Filtro_Productos_Todos)
        Btn_Filtro_Pro_ProductosExcluidos.Image = Fx_Imagen_Filtro(Not (Not IsNothing(_Tbl_Filtro_ProductosExcluidos) AndAlso CBool(_Tbl_Filtro_ProductosExcluidos.Rows.Count)))
        Btn_Filtro_Pro_Super_Familias.Image = Fx_Imagen_Filtro(_Filtro_Super_Familias_Todas)
        Btn_Filtro_Pro_Familias.Image = Fx_Imagen_Filtro(_Filtro_Familias_Todas)
        Btn_Filtro_Pro_Sub_Familias.Image = Fx_Imagen_Filtro(_Filtro_Sub_Familias_Todas)
        Btn_Filtro_Pro_Marcas.Image = Fx_Imagen_Filtro(_Filtro_Marcas_Todas)
        Btn_Filtro_Pro_Clas_Libre.Image = Fx_Imagen_Filtro(_Filtro_Clalibpr_Todas)
        Btn_Filtro_Pro_Rubros.Image = Fx_Imagen_Filtro(_Filtro_Rubro_Productos_Todas)
        Btn_Filtro_Pro_Zonas.Image = Fx_Imagen_Filtro(_Filtro_Zonas_Productos_Todas)

        If Not _Filtro_Productos_Todos Or
           Not _Filtro_Super_Familias_Todas Or
           Not _Filtro_Familias_Todas Or
           Not _Filtro_Sub_Familias_Todas Or
           Not _Filtro_Marcas_Todas Or
           Not _Filtro_Clalibpr_Todas Or
           Not _Filtro_Rubro_Productos_Todas Or
           Not _Filtro_Zonas_Productos_Todas Or
           (Not IsNothing(_Tbl_Filtro_ProductosExcluidos) AndAlso CBool(_Tbl_Filtro_ProductosExcluidos.Rows.Count)) Then
            Btn_Filtrar_Productos.Image = Imagenes_16x16.Images.Item("filter.png")
        Else
            Btn_Filtrar_Productos.Image = Nothing
        End If

        Btn_Filtro_SucursalDoc.Image = Fx_Imagen_Filtro(_Filtro_SucursalDoc_Todas)
        Btn_Filtro_Sucursales.Image = Fx_Imagen_Filtro(_Filtro_Sucursales_Todas)
        Btn_Filtro_Bodegas.Image = Fx_Imagen_Filtro(_Filtro_Bodegas_Todas)

        If Not _Filtro_Sucursales_Todas Or Not _Filtro_Bodegas_Todas Then
            Btn_Filtrar_Suc_Bod.Image = Imagenes_16x16.Images.Item("filter.png")
        Else
            Btn_Filtrar_Suc_Bod.Image = Nothing
        End If

    End Sub

    Function Fx_Imagen_Filtro(_Todas As Boolean) As Image

        If _Todas Then
            Return Nothing
        Else
            Return Imagenes_16x16.Images.Item("filter.png")
        End If

    End Function

    Private Sub Btn_Informe_X_Clientes_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Informe_X_Clientes.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cod = _Fila.Cells("CODIGO").Value

        Dim _Filtro As String

        If Cmb_Vista_Informe.SelectedValue = "0" Then
            Select Case _Cod
                Case "-2"
                    _Filtro = _SqlFiltro_Detalle & vbCrLf &
                     "And KOPRCT Not In (Select KOPR From MAEPR)"
                Case "-1"
                    _Filtro = _SqlFiltro_Detalle & vbCrLf &
                     "And KOPRCT In (Select KOPR From MAEPR Where KOPR Not In " &
                     "(Select Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion Where Producto = 0))"
                Case Else
                    _Filtro = _SqlFiltro_Detalle & vbCrLf &
                                     "And KOPRCT In (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion Where Codigo_Nodo = " & _Cod & ")"

            End Select
        Else
            _Filtro = _SqlFiltro_Detalle & vbCrLf & "And " & _Cp_Codigo & " = '" & _Cod & "'"
        End If

        Dim _Filtro_Nodos As String

        If _Filtro_Clas_BakApp_Todas Then
            _Filtro_Nodos = String.Empty
        Else

            _Filtro_Nodos = Generar_Filtro_IN(_Tbl_Filtro_Clas_BakApp, "", "CODIGO", False, False, "")
            _Filtro_Nodos = vbCrLf & "And KOPRCT In (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf &
                            "Where Codigo_Nodo In " & _Filtro_Nodos & ")" & vbCrLf

        End If

        _Filtro += _Filtro_Nodos

        Dim _Texto = "Informe de ventas desde: " & FormatDateTime(Dtp_Fecha_Desde.Value, DateFormat.ShortDate) & Space(1) &
                     "Hasta: " & FormatDateTime(Dtp_Fecha_Hasta.Value, DateFormat.ShortDate)

        Dim Fm As New Frm_Inf_Ventas_X_Periodo_Sub_Informe_SuperGrid(_Nombre_Tabla_Paso, _Filtro, True, "")
        If CBool(Fm.Pro_Ds_Informe.Tables(0).Rows.Count) Then
            Fm.Text = _Texto
            Fm.ShowDialog(Me)
        Else
            MessageBoxEx.Show(Me, "No existe información", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
        Fm.Dispose()

    End Sub

    Private Sub Btn_Informe_X_Documentos_Entidades_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Informe_X_Documentos_Entidades.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cod = _Fila.Cells("CODIGO").Value

        Dim _Filtro As String

        If Cmb_Vista_Informe.SelectedValue = "0" Then
            Select Case _Cod
                Case "-2"
                    _Filtro = _SqlFiltro_Detalle & vbCrLf &
                     "And KOPRCT Not In (Select KOPR From MAEPR)"
                Case "-1"
                    _Filtro = _SqlFiltro_Detalle & vbCrLf &
                     "And KOPRCT In (Select KOPR From MAEPR Where KOPR Not In " &
                     "(Select Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion Where Producto = 0))"
                Case Else
                    _Filtro = _SqlFiltro_Detalle & vbCrLf &
                                     "And KOPRCT In (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion Where Codigo_Nodo = " & _Cod & ")"

            End Select
        Else
            _Filtro = _SqlFiltro_Detalle & vbCrLf & "And " & _Cp_Codigo & " = '" & _Cod & "'"
        End If

        Dim _Filtro_Nodos As String

        If _Filtro_Clas_BakApp_Todas Then
            _Filtro_Nodos = String.Empty
        Else

            _Filtro_Nodos = Generar_Filtro_IN(_Tbl_Filtro_Clas_BakApp, "Chk", "Codigo_Nodo", False, True, "")
            _Filtro_Nodos = vbCrLf & "And KOPRCT In (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf &
                            "Where Codigo_Nodo In " & _Filtro_Nodos & ")" & vbCrLf

        End If

        _Filtro += _Filtro_Nodos

        Dim Fm As New Frm_Inf_Ventas_X_Periodo_Sub_Informes_01(_Nombre_Tabla_Paso,
                                                               _Filtro,
                                                               Frm_Inf_Ventas_X_Periodo_Sub_Informes_01.Enum_Tipo_Informe.Inf_Documentos)

        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Informe_X_Productos_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Informe_X_Productos.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cod = _Fila.Cells("CODIGO").Value

        Dim _Filtro As String

        If Cmb_Vista_Informe.SelectedValue = "0" Then
            Select Case _Cod
                Case "-2"
                    _Filtro = _SqlFiltro_Detalle & vbCrLf &
                     "And KOPRCT Not In (Select KOPR From MAEPR)"
                Case "-1"
                    _Filtro = _SqlFiltro_Detalle & vbCrLf &
                     "And KOPRCT In (Select KOPR From MAEPR Where KOPR Not In " &
                     "(Select Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion Where Producto = 0))"
                Case Else
                    _Filtro = _SqlFiltro_Detalle & vbCrLf &
                                     "And KOPRCT In (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion Where Codigo_Nodo = " & _Cod & ")"

            End Select
        Else
            _Filtro = _SqlFiltro_Detalle & vbCrLf & "And " & _Cp_Codigo & " = '" & _Cod & "'"
        End If

        Dim _Filtro_Nodos As String

        If _Filtro_Clas_BakApp_Todas Then
            _Filtro_Nodos = String.Empty
        Else

            _Filtro_Nodos = Generar_Filtro_IN(_Tbl_Filtro_Clas_BakApp, "Chk", "Codigo_Nodo", False, True, "")
            _Filtro_Nodos = vbCrLf & "And KOPRCT In (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf &
                            "Where Codigo_Nodo In " & _Filtro_Nodos & ")" & vbCrLf

        End If

        _Filtro += _Filtro_Nodos

        Dim Fm As New Frm_Inf_Ventas_X_Periodo_Sub_Informes_01(_Nombre_Tabla_Paso,
                                                               _Filtro,
                                                               Frm_Inf_Ventas_X_Periodo_Sub_Informes_01.Enum_Tipo_Informe.Inf_Detalle)

        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub


    Private Sub Btn_Vista_Informe_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Vista_Informe.Click

        Dim Fm As New Frm_Arbol_Asociacion_05_Busqueda(Frm_Arbol_Asociacion_05_Busqueda.Enum_Tipo_De_Carpeta.Clas_Unica_Ambas, False)
        Fm.Pro_Seleccionar_Todo = _Filtro_Clas_BakApp_Todas
        Fm.Pro_Tbl_Nodos_Seleccionados = _Tbl_Filtro_Clas_BakApp
        Fm.ShowDialog(Me)
        If Fm.Pro_Aceptar Then

            Dim _Es_Seleccionable As Boolean = Fm.Pro_Row_Nodo_Seleccionado.Item("Es_Seleccionable")
            Dim _Codigo_Nodo As Integer

            If _Es_Seleccionable Then
                _Codigo_Nodo = Fm.Pro_Row_Nodo_Seleccionado.Item("Identificacdor_NodoPadre")
            Else
                _Codigo_Nodo = Fm.Pro_Row_Nodo_Seleccionado.Item("Codigo_Nodo")
            End If

            Consulta_sql = "Select Codigo_Nodo as CODIGO,Descripcion As DESCRIPCION,Descripcion As DESCRIPCION_VISTA," &
                          "Cast(1 As Bit) As ARBOL_BAKAPP,Identificacdor_NodoPadre As Nodo_Padre,Es_Seleccionable,*" & vbCrLf &
                           "From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Codigo_Nodo = " & _Codigo_Nodo
            _Row_Vista = _Sql.Fx_Get_DataRow(Consulta_sql)

            Sb_Actualizar_Grilla(False)

        End If
        Fm.Dispose()

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _ARBOL_BAKAPP As Boolean = _Row_Vista.Item("ARBOL_BAKAPP")

        If _ARBOL_BAKAPP Then

            Dim _Codigo = _Fila.Cells("CODIGO").Value
            Dim _Row_Nodo As DataRow
            Dim _Es_Seleccionable As Boolean


            If _Codigo = "-1" Or _Codigo = "-2" Then
                _Es_Seleccionable = False
            Else
                Consulta_sql = "Select Codigo_Nodo as CODIGO,Descripcion As DESCRIPCION,Descripcion As DESCRIPCION_VISTA," &
                               "Cast(1 As Bit) As ARBOL_BAKAPP,Identificacdor_NodoPadre As Nodo_Padre,Es_Seleccionable,*" & vbCrLf &
                               "From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Codigo_Nodo = " & _Codigo
                _Row_Nodo = _Sql.Fx_Get_DataRow(Consulta_sql)
                _Es_Seleccionable = _Row_Nodo.Item("Es_Seleccionable")
            End If


            If Not _Es_Seleccionable Then
                _Row_Vista = _Row_Nodo
                Sb_Actualizar_Grilla(False)
            Else
                MessageBoxEx.Show(Me, "No existen más carpetas en esta selección", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        End If

    End Sub

    Private Sub Sb_Cmb_Vista_Informe_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

        _Row_Vista = Fx_Crea_Tabla_Con_Filtro(_Tbl_Vista_Informe,
                                              "CODIGO = '" & Cmb_Vista_Informe.SelectedValue & "'", "Id").Rows(0)

        If Cmb_Vista_Informe.SelectedValue = "0" Then
            _Row_Vista.Item("ARBOL_BAKAPP") = True
            Btn_Vista_Informe.Enabled = True
        Else
            Btn_Vista_Informe.Enabled = False
        End If

        Sb_Actualizar_Grilla(False)

    End Sub

    Private Sub Btn_Atras_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Atras.Click

        Dim _Nodo_Padre = _Row_Vista.Item("Nodo_Padre")

        If CBool(_Nodo_Padre) Then

            Consulta_sql = "Select Codigo_Nodo as CODIGO,Descripcion As DESCRIPCION,Descripcion As DESCRIPCION_VISTA," &
                           "Cast(1 As Bit) As ARBOL_BAKAPP,*,Identificacdor_NodoPadre As Nodo_Padre" & vbCrLf &
                           "From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Codigo_Nodo = " & _Nodo_Padre
            _Row_Vista = _Sql.Fx_Get_DataRow(Consulta_sql)

            Sb_Actualizar_Grilla(False)
        Else
            Cmb_Vista_Informe.SelectedValue = "0"
            _Row_Vista = Fx_Crea_Tabla_Con_Filtro(_Tbl_Vista_Informe,
                                              "CODIGO = '" & Cmb_Vista_Informe.SelectedValue & "'", "Id").Rows(0)
            _Row_Vista.Item("ARBOL_BAKAPP") = True
            Sb_Actualizar_Grilla(False)
            Btn_Atras.Enabled = False

        End If

    End Sub

    Private Sub Btn_Arbol_Asociaciones_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Arbol_Asociaciones.Click
        If Fx_Tiene_Permiso(Me, "Tbl00002") Then
            Dim Fm As New Frm_Arbol_Asociacion_02(False, 0, False, Frm_Arbol_Asociacion_02.Enum_Clasificacion.Unica, 0)
            Fm.Pro_Identificador_NodoPadre = 0
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If
    End Sub

    Private Sub Btn_Filtrar_Clas_BakApp_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Filtrar_Clas_BakApp.Click

        Me.Cursor = Cursors.WaitCursor

        Try
            Me.Enabled = False
            Me.Refresh()

            Application.DoEvents()

            Dim Fm As New Frm_Arbol_Asociacion_05_Busqueda(Frm_Arbol_Asociacion_05_Busqueda.Enum_Tipo_De_Carpeta.Clas_Unica_Ambas, True)
            Fm.Pro_Seleccionar_Todo = _Filtro_Clas_BakApp_Todas
            Fm.Pro_Tbl_Nodos_Seleccionados = _Tbl_Filtro_Clas_BakApp
            Fm.ShowDialog(Me)
            If Fm.Pro_Aceptar Then
                If Not (Fm.Pro_Tbl_Nodos_Seleccionados Is Nothing) Then

                    _Filtro_Clas_BakApp_Todas = Fm.Pro_Seleccionar_Todo
                    _Tbl_Filtro_Clas_BakApp = Fm.Pro_Tbl_Nodos_Seleccionados

                    If Cmb_Vista_Informe.SelectedValue = "0" Then
                        _Row_Vista = Fx_Crea_Tabla_Con_Filtro(_Tbl_Vista_Informe,
                                                  "CODIGO = '" & Cmb_Vista_Informe.SelectedValue & "'", "Id").Rows(0)

                        _Row_Vista.Item("ARBOL_BAKAPP") = True
                    End If

                    Sb_Actualizar_Grilla(False)

                End If
            End If
            Fm.Dispose()
        Catch ex As Exception

        Finally
            Me.Cursor = Cursors.Default
            Me.Enabled = True
        End Try

    End Sub

    Private Sub Btn_Totar_Pie_Derecha_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Totar_Pie_Derecha.Click
        _Rotacion -= 5
        If _Rotacion <= 0 Then
            _Rotacion = 360
        End If
        Grafico_Pie.Series(0)("PieStartAngle") = _Rotacion.ToString()
    End Sub

    Private Sub Btn_Totar_Pie_Izquierda_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Totar_Pie_Izquierda.Click
        _Rotacion += 5
        If _Rotacion >= 360 Then
            _Rotacion = 0
        End If
        Grafico_Pie.Series(0)("PieStartAngle") = _Rotacion.ToString()
    End Sub

    Private Sub Rdb_Pie_CheckedChanged(sender As System.Object, e As System.EventArgs)
        If CType(sender, DevComponents.DotNetBar.Controls.CheckBoxX).Checked Then
            Sb_Grafico_Pie_Acumulativo()
        End If
    End Sub

    Private Sub Btn_Grafico_Linea_Tiempo_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Grafico_Linea_Tiempo.Click
        Dim Fm As New Frm_Inf_Ventas_Grafico_Linea_Tiempo(Grafico_Linea_De_Tiempo)
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub

    Private Sub Grafico_Linea_De_Tiempo_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles Grafico_Linea_De_Tiempo.MouseDown
        Dim result As HitTestResult = Grafico_Linea_De_Tiempo.HitTest(e.X, e.Y)
        If result IsNot Nothing AndAlso result.[Object] IsNot Nothing Then
            ' When user hits the LegendItem
            If TypeOf result.[Object] Is LegendItem Then
                ' Legend item result
                Dim legendItem As LegendItem = DirectCast(result.[Object], LegendItem)

                ' series item selected
                Dim selectedSeries As Series = DirectCast(legendItem.Tag, Series)

                If selectedSeries IsNot Nothing Then

                    ' Dim mainForm As System.Windows.Forms.DataVisualization.Charting.Utilities.SampleMain.MainForm = DirectCast(Me.ParentForm, System.Windows.Forms.DataVisualization.Charting.Utilities.SampleMain.MainForm)

                    If selectedSeries.Enabled Then
                        selectedSeries.Enabled = False
                        'legendItem.Cells(0).Image = 'Imagenes_16x16.Images.Item("ok.png") 'String.Format(mainForm.CurrentSamplePath + "\chk_unchecked.png")
                        legendItem.Cells(0).ImageTransparentColor = Color.Red
                    Else

                        selectedSeries.Enabled = True
                        'legendItem.Cells(0).Image = Imagenes_16x16.Images.Item("ok.delete") 'String.Format(mainForm.CurrentSamplePath + "\chk_checked.png")
                        legendItem.Cells(0).ImageTransparentColor = Color.Red
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub Btn_Filtro_Ent_Entidades_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Filtro_Ent_Entidades.Click

        Dim _SqlFiltro_Fechas As String

        _SqlFiltro_Fechas = "Where FEEMLI BETWEEN '" & Format(Dtp_Fecha_Desde.Value, "yyyyMMdd") & "' AND '" &
                            Format(Dtp_Fecha_Hasta.Value, "yyyyMMdd") & "'" & vbCrLf

        Dim _Sql_Filtro_Condicion_Extra = "And KOEN+SUEN In (Select Distinct ENDO+SUENDO From " &
                                         _Nombre_Tabla_Paso & vbCrLf & _SqlFiltro_Fechas & ")"


        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Entidad,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Entidades, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Entidad_Todas, False) Then

            _Tbl_Filtro_Entidad = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Entidad_Todas = _Filtrar.Pro_Filtro_Todas

            Sb_Actualizar_Grilla(False)

        End If

    End Sub

    Private Sub Btn_Consulta_Ventas_X_Cliente_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Consulta_Ventas_X_Cliente.Click
        ShowContextMenu(Menu_Contextual_Consulta_Entidades)
    End Sub

    Sub Sb_Consultar_Ventas_X_Cliente(_Solo_Vendedor_Activo As Boolean)

        Dim _RowEntidad As DataRow

        Dim Fm_Ent As New Frm_BuscarEntidad_Mt(False)

        If _Solo_Vendedor_Activo Then
            'If Not Fx_Tiene_Permiso(Me, "Inf00025", , False) Then
            Fm_Ent.Pro_Filtro_Extra = "AND KOEN IN (SELECT KOEN FROM MAEEN WHERE KOFUEN = '" & FUNCIONARIO & "')"
            Fm_Ent.Text = "Búsqueda entidades asignadas al vendedor: " & Nombre_funcionario_activo
            Fm_Ent.Chk_Solo_Clientes_Del_Vendedor.Checked = True
            Fm_Ent.Chk_Solo_Clientes_Del_Vendedor.Enabled = False
            'End If
        End If

        Fm_Ent.Pro_Crear_Entidad = False
        Fm_Ent.ShowDialog(Me)

        _RowEntidad = Fm_Ent.Pro_RowEntidad
        Fm_Ent.Dispose()

        If Not (_RowEntidad Is Nothing) Then

            Dim _Endo = _RowEntidad.Item("KOEN")
            Dim _Suendo = _RowEntidad.Item("SUEN")
            Dim _Kofuen = _RowEntidad.Item("KOFUEN")

            Dim _Filtro = "And ENDO = '" & _Endo & "' And SUENDO = '" & _Suendo & "'"

            Dim _Texto = "Informe de ventas desde: " & FormatDateTime(Dtp_Fecha_Desde.Value, DateFormat.ShortDate) & Space(1) &
                         "Hasta: " & FormatDateTime(Dtp_Fecha_Hasta.Value, DateFormat.ShortDate)

            Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros("MAEEN", "KOFUEN = '" & FUNCIONARIO & "'" & vbCrLf &
                                                                 "And KOEN = '" & _Endo & "' And SUEN = '" & _Suendo & "'"))

            If Not _Reg Then

                If Not Fx_Tiene_Permiso(Me, "Inf00025") Then
                    Return
                End If

            End If

            Dim Fm As New Frm_Inf_Ventas_X_Periodo_Sub_Informe_SuperGrid(_Nombre_Tabla_Paso, _Filtro, True, "")
            If CBool(Fm.Pro_Ds_Informe.Tables(0).Rows.Count) Then
                Fm.Text = _Texto
                Fm.ShowDialog(Me)
            Else
                MessageBoxEx.Show(Me, "No existe información" & vbCrLf &
                                          "La carga de venta es Desde: " & _Fecha_Carga_Desde & " Hasta: " & _Fecha_Carga_Hasta,
                                          "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            Fm.Dispose()

        End If

    End Sub

    Private Sub Btn_Consulta_Ventas_X_Cliente_X_Asignados_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Consulta_Ventas_X_Cliente_X_Asignados.Click

        Sb_Informe_Clientes_X_Vendedor(FUNCIONARIO, Nombre_funcionario_activo)

        'Consulta_sql = "Select KOEN+SUEN AS CODIGO From MAEEN Where KOFUEN = '" & FUNCIONARIO & "'"

        'Dim _TblEntidades As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        'If CBool(_TblEntidades.Rows.Count) Then

        '    Dim _Entidades As String = Generar_Filtro_IN(_TblEntidades, "", "CODIGO", False, False, "'")

        '    Dim _Filtro = "And ENDO+SUENDO IN " & _Entidades

        '    Dim _Texto = "Informe de ventas desde: " & FormatDateTime(Dtp_Fecha_Desde.Value, DateFormat.ShortDate) & Space(1) &
        '                 "Hasta: " & FormatDateTime(Dtp_Fecha_Hasta.Value, DateFormat.ShortDate)

        '    _Texto = "Clientes asociados al vendedor: " & FUNCIONARIO & "-" & Nombre_funcionario_activo

        '    Dim Fm As New Frm_Inf_Ventas_X_Periodo_Sub_Informe_SuperGrid(_Nombre_Tabla_Paso, _Filtro, False, FUNCIONARIO)
        '    If CBool(Fm.Pro_Ds_Informe.Tables(0).Rows.Count) Then
        '        Fm.Text = _Texto
        '        Fm.ShowDialog(Me)
        '    Else
        '        MessageBoxEx.Show(Me, "No existe información" & vbCrLf &
        '                          "La carga de venta es Desde: " & _Fecha_Carga_Desde & " Hasta: " & _Fecha_Carga_Hasta,
        '                          "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    End If
        '    Fm.Dispose()

        'Else
        '    MessageBoxEx.Show(Me, "Usted no tiene ventas en el sistema", "Validación",
        '                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
        'End If

    End Sub

    Private Sub Btn_Actualizar_Datos_Informe_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Actualizar_Datos_Informe.Click

        Dim Fm As New Frm_Inf_Ventas_X_Periodo_Fechas(Frm_Inf_Ventas_X_Periodo_Fechas.Enum_Acciones.Actializar_Informe_Manual)
        Fm.Nombre_Tabla_Paso = _Nombre_Tabla_Paso
        Fm.ShowDialog(Me)

        If Fm.Pro_Informe_Actualizado Then
            Sb_Actualizar_Grilla(False)
        End If

        Fm.Dispose()
    End Sub

    Private Sub Btn_Reperar_Datos_Informe_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Reperar_Datos_Informe.Click

        Dim Fm As New Frm_Inf_Ventas_X_Periodo_Fechas(Frm_Inf_Ventas_X_Periodo_Fechas.Enum_Acciones.Actualizar_Filtro)
        Fm.Nombre_Tabla_Paso = _Nombre_Tabla_Paso
        Fm.ShowDialog(Me)

        If Fm.Pro_Informe_Actualizado Then
            Sb_Actualizar_Grilla(False)
        End If

        Fm.Dispose()

    End Sub

    Private Sub Btn_Mantencion_Datos_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Mantencion_Datos.Click
        ShowContextMenu(Menu_Contextual_Mantencion_Informe)
    End Sub

    Private Sub Btn_Excel_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Excel.Click
        If Fx_Tiene_Permiso(Me, "Inf00042") Then ExportarTabla_JetExcel_Tabla(_Tbl_Informe, Me, "Informe")
    End Sub

    Private Sub Btn_Crear_NVV_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Crear_Venta.Click
        ShowContextMenu(Menu_Contextual_Ventas)
    End Sub

    Private Function Fx_CheckForm(_form As Form) As Form

        If Not (_form Is Nothing) Then
            For Each f As Form In Application.OpenForms
                If f.Name = _form.Name Then
                    Return f
                End If
            Next
        End If

        Return Nothing

    End Function

    Private Sub Btn_Cotizacion_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Cotizacion.Click

        If Fx_Tiene_Permiso(Me, "Bkp00045") Then

            Dim Fm_Post As New Frm_Formulario_Documento("COV", csGlobales.Enum_Tipo_Documento.Venta, False)
            'Fm_Post.Btn_Minimizar.Visible = True
            Fm_Post.MinimizeBox = True
            Fm_Post.ShowDialog(Me)
            Fm_Post.Dispose()

        End If

    End Sub

    Private Sub Btn_Nota_de_venta_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Nota_de_venta.Click

        If Fx_Tiene_Permiso(Me, "Bkp00041") Then

            Dim Fm_Post As New Frm_Formulario_Documento("NVV", csGlobales.Enum_Tipo_Documento.Venta, False)
            'Fm_Post.Btn_Minimizar.Visible = True
            Fm_Post.MinimizeBox = False
            Fm_Post.ShowDialog(Me)
            Fm_Post.Dispose()

        End If

    End Sub

    Private Sub Btn_Actualizar_Mes_Actual_Click(sender As Object, e As EventArgs) Handles Btn_Actualizar_Mes_Actual.Click
        Sb_Actualizar_Matriz_Cubo()
        Sb_Cargar_Combo_Vista_Informe()
    End Sub

    Private Sub Btn_Copiar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Copiar.Click
        With Grilla

            Dim _Cabeza = .Columns(.CurrentCell.ColumnIndex).Name
            Dim _Texto_Cabeza = .Columns(.CurrentCell.ColumnIndex).HeaderText

            Dim Copiar = .Rows(.CurrentRow.Index).Cells(_Cabeza).Value
            Clipboard.SetText(Copiar)

            ToastNotification.Show(Me, _Texto_Cabeza & " esta en el portapapeles", Btn_Copiar.Image,
                                   2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

        End With
    End Sub

    Private Sub Btn_Filtro_Vendedor_Asignado_Entidad_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Filtro_Vendedor_Asignado_Entidad.Click
        If Fx_Tiene_Permiso(Me, "Inf00025") Then
            Dim _SqlFiltro_Fechas As String

            _SqlFiltro_Fechas = "Where FEEMLI BETWEEN '" & Format(Dtp_Fecha_Desde.Value, "yyyyMMdd") & "' AND '" &
                                 Format(Dtp_Fecha_Hasta.Value, "yyyyMMdd") & "'"

            Dim _Sql_Filtro_Condicion_Extra = "And KOFU In (Select Distinct KOFUEN From " &
                                              _Nombre_Tabla_Paso & vbCrLf & _SqlFiltro_Fechas & ")"

            Dim _Filtrar As New Clas_Filtros_Random(Me)

            If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Vendedores_Asignados,
                                   Clas_Filtros_Random.Enum_Tabla_Fl._Funcionarios_Random, _Sql_Filtro_Condicion_Extra,
                                   _Filtro_Vendedores_Asignados_Todas, False) Then

                _Tbl_Filtro_Vendedores_Asignados = _Filtrar.Pro_Tbl_Filtro
                _Filtro_Vendedores_Asignados_Todas = _Filtrar.Pro_Filtro_Todas

                If Cmb_Vista_Informe.SelectedValue = "KOFUEN" Then
                    Sb_Actualizar_Grilla(False)
                Else
                    Cmb_Vista_Informe.SelectedValue = "KOFUEN"
                End If
            End If
        End If
    End Sub

    Private Sub Grilla_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellEnter

        Try

            If Super_Tab.SelectedTabIndex = 1 Then
                Sb_Generar_Grafica_Linea_De_Tiempo(Grafico_Linea_De_Tiempo)
            End If

            If Super_Tab.SelectedTabIndex = 3 Then
                '_Agrupar = "Ano"
                'Dim _Eje_X = "Orden"
                'Dim _Eje_Y = "Total"
                Sb_Generar_Grafica_Linea_De_Tiempo_X_Year(Grafico_Year1, "Ano", "Orden", "Total")
                Sb_Generar_Grafica_Linea_De_Tiempo_X_Year(Grafico_Year2, "DESCRIPCION", "Mes_Ano", "Total")
                Sb_Grafico_Tendencias()
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Tiempo_revisa_actualizacion_Tick(sender As System.Object, e As System.EventArgs) Handles Tiempo_revisa_actualizacion.Tick

        Try

            Me.Enabled = True


            ToastNotification.Show(Me, "BUSCANDO ACTUALIZACIONES...", Imagenes_32x32.Images.Item("cloud.png"),
                               1 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

            Tiempo_revisa_actualizacion.Enabled = False

            Dim _Reg_Tabla As Boolean = _Sql.Fx_Existe_Tabla(_Nombre_Tabla_Paso)

            Dim _Actualizar As Boolean

            If Not _Reg_Tabla Then

                MessageBoxEx.Show(Me, "No existe tabla con información" & vbCrLf &
                                  "Se debe cargar el informe completamente", "Validación",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information)

                Dim Fm As New Frm_Inf_Ventas_X_Periodo_Fechas(Frm_Inf_Ventas_X_Periodo_Fechas.Enum_Acciones.Crear_Informe)
                Fm.Nombre_Tabla_Paso = _Nombre_Tabla_Paso
                Fm.ShowDialog(Me)

                If Fm.Pro_Informe_Actualizado Then
                    Sb_Actualizar_Grilla(False)
                End If
                Fm.Dispose()

            Else

                Dim _Reg_Campos As Boolean = _Sql.Fx_Exite_Campo(_Nombre_Tabla_Paso, "KOFUEN")

                Dim _Sql_Campos_Nuevos As String

                If Not _Reg_Campos Then
                    _Actualizar = True
                    _Sql_Campos_Nuevos = "ALTER TABLE " & _Nombre_Tabla_Paso & " ADD 
                                      KOFUEN Char(3) Not Null Default('')" & vbCrLf & vbCrLf
                End If

                If Not _Reg_Campos Then
                    _Actualizar = True
                    _Sql_Campos_Nuevos += "ALTER TABLE " & _Nombre_Tabla_Paso & " ADD 
                                       VENDEDOR_ASIGNADO Varchar(50) Not Null Default('')" & vbCrLf & vbCrLf
                End If

                _Reg_Campos = _Sql.Fx_Exite_Campo(_Nombre_Tabla_Paso, "SUCURSALLIDO")

                If Not _Reg_Campos Then
                    _Actualizar = True
                    _Sql_Campos_Nuevos += "ALTER TABLE " & _Nombre_Tabla_Paso & " ADD 
                                       SUCURSALLIDO Varchar(50) Not Null Default('')" & vbCrLf & vbCrLf
                End If

                If _Actualizar Then

                    Me.Cursor = Cursors.WaitCursor

                    ToastNotification.Show(Me, "SE INSERTARAN LOS NUEVOS CAMPOS...", Imagenes_32x32.Images.Item("cloud.png"),
                                           2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

                    'MessageBoxEx.Show(Me, "Se debe actualizar la tabla del informe, se incorporan nuevos campos",
                    '                  "Actualización de sistema de informes...",
                    ' MessageBoxButtons.OK, MessageBoxIcon.Information)
                    _Sql.Ej_consulta_IDU(_Sql_Campos_Nuevos)

                    _Fecha_Carga_Desde = _Sql.Fx_Trae_Dato(_Nombre_Tabla_Paso, "Min(FEEMLI)")

                    Dim Fm As New Frm_Inf_Ventas_X_Periodo_Fechas(Frm_Inf_Ventas_X_Periodo_Fechas.Enum_Acciones.Actualizar_Informe_Automatico)
                    Fm.Nombre_Tabla_Paso = _Nombre_Tabla_Paso
                    Fm.Pro_Fecha_Desde = _Fecha_Carga_Desde
                    Fm.Pro_Fecha_Hasta = Pro_Fecha_Hasta
                    Fm.ShowDialog(Me)
                    Fm.Dispose()

                    Fm = New Frm_Inf_Ventas_X_Periodo_Fechas(Frm_Inf_Ventas_X_Periodo_Fechas.Enum_Acciones.Actualizar_Filtro)
                    Fm.Nombre_Tabla_Paso = _Nombre_Tabla_Paso
                    Fm.ShowDialog(Me)
                    If Fm.Pro_Informe_Actualizado Then
                        Sb_Actualizar_Grilla(False)
                    End If

                    If Fm.Pro_Informe_Actualizado Then
                        Sb_Actualizar_Grilla(False)
                    End If
                    Fm.Dispose()

                Else
                    Tiempo.Enabled = True
                End If
            End If

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Problema en actualización automatica", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            Me.Enabled = True
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub Tiempo_Tick(sender As Object, e As EventArgs) Handles Tiempo.Tick
        Tiempo.Enabled = False
        Sb_Actualizar_Grilla(True)
    End Sub

    Private Sub Btn_Consulta_Ventas_X_Cliente_X_Vendedor_Click(sender As Object, e As EventArgs) Handles Btn_Consulta_Ventas_X_Cliente_X_Vendedor.Click
        Sb_Informe_Clientes_X_Vendedor("", "")
    End Sub

    Sub Sb_Informe_Clientes_X_Vendedor(_Kofu As String, _Nokofu As String)

        Dim _Filtrar As New Clas_Filtros_Random(Me)
        Dim _Codigo As String
        Dim _Descripcion As String

        If String.IsNullOrEmpty(_Kofu) Then

            If Not Fx_Tiene_Permiso(Me, "Inf00043") Then
                Return
            End If

            If _Filtrar.Fx_Filtrar(Nothing,
                           Clas_Filtros_Random.Enum_Tabla_Fl._Funcionarios_Random, "",
                           False, False, True) Then

                _Codigo = _Filtrar.Pro_Tbl_Filtro.Rows(0).Item("Codigo")
                _Descripcion = _Filtrar.Pro_Tbl_Filtro.Rows(0).Item("Descripcion")

            Else
                Return
            End If
        Else
            _Codigo = _Kofu
            _Descripcion = _Nokofu
        End If

        Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros("MAEEN", "KOFUEN = '" & _Codigo & "'"))

        If _Reg Then

            Dim _Texto = "Clientes asociados al vendedor: " & _Codigo & "-" & _Descripcion

            Dim Fm As New Frm_Inf_Ventas_X_Periodo_Sub_Informe_SuperGrid(_Nombre_Tabla_Paso, "", False, _Codigo)
            If CBool(Fm.Pro_Ds_Informe.Tables(0).Rows.Count) Then
                Fm.Text = _Texto
                Fm.ShowDialog(Me)
            Else
                MessageBoxEx.Show(Me, "No existe información" & vbCrLf &
                                  "La carga de venta es Desde: " & _Fecha_Carga_Desde & " Hasta: " & _Fecha_Carga_Hasta,
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            Fm.Dispose()

        Else
            MessageBoxEx.Show(Me, "Este usuario no tiene clientes asignados", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub Btn_Consulta_Ventas_X_Cliente_X_Todos_Click(sender As Object, e As EventArgs) Handles Btn_Consulta_Ventas_X_Cliente_X_Todos.Click
        If Fx_Tiene_Permiso(Me, "Inf00025") Then
            Sb_Consultar_Ventas_X_Cliente(False)
        End If
    End Sub

    Private Sub Btn_Consulta_Ventas_X_Cliente_X_VendEspecifico_Click(sender As Object, e As EventArgs) Handles Btn_Consulta_Ventas_X_Cliente_X_VendEspecifico.Click
        Sb_Consultar_Ventas_X_Cliente(True)
    End Sub

    Private Sub Btn_Filtro_Ent_Lista_Precio_Asig_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Ent_Lista_Precio_Asig.Click

        Dim _SqlFiltro_Fechas As String

        _SqlFiltro_Fechas = "Where FEEMLI BETWEEN '" & Format(Dtp_Fecha_Desde.Value, "yyyyMMdd") & "' AND '" &
                            Format(Dtp_Fecha_Hasta.Value, "yyyyMMdd") & "'" & vbCrLf

        Dim _Sql_Filtro_Condicion_Extra = "And TILT = 'P' And KOLT In (Select Distinct SUBSTRING(LVEN,6,3) From " &
                                          _Nombre_Tabla_Paso & vbCrLf & _SqlFiltro_Fechas & ")"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = "TABPP"
        _Filtrar.Campo = "'TABPP'+KOLT"
        _Filtrar.Descripcion = "NOKOLT"

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Lista_Precio_Asig,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Lista_Precio_Asig_Todas, True) Then

            _Tbl_Filtro_Lista_Precio_Asig = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Lista_Precio_Asig_Todas = _Filtrar.Pro_Filtro_Todas

            If Cmb_Vista_Informe.SelectedValue = "LVEN" Then
                Sb_Actualizar_Grilla(False)
            Else
                Cmb_Vista_Informe.SelectedValue = "LVEN"
            End If

        End If

    End Sub

    Private Sub Btn_Filtro_Ent_Lista_Precio_Doc_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Ent_Lista_Precio_Doc.Click

        Dim _SqlFiltro_Fechas As String

        _SqlFiltro_Fechas = "Where FEEMLI BETWEEN '" & Format(Dtp_Fecha_Desde.Value, "yyyyMMdd") & "' AND '" &
                            Format(Dtp_Fecha_Hasta.Value, "yyyyMMdd") & "'" & vbCrLf

        Dim _Sql_Filtro_Condicion_Extra = "And TILT = 'P' And KOLT In (Select Distinct SUBSTRING(KOLTPR,6,3) From " &
                                          _Nombre_Tabla_Paso & vbCrLf & _SqlFiltro_Fechas & ")"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = "TABPP"
        _Filtrar.Campo = "'TABPP'+KOLT"
        _Filtrar.Descripcion = "NOKOLT"

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Lista_Precio_Docu,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Lista_Precio_Asig_Todas, False) Then

            _Tbl_Filtro_Lista_Precio_Docu = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Lista_Precio_Docu_Todas = _Filtrar.Pro_Filtro_Todas

            If Cmb_Vista_Informe.SelectedValue = "KOLTPR" Then
                Sb_Actualizar_Grilla(False)
            Else
                Cmb_Vista_Informe.SelectedValue = "KOLTPR"
            End If

        End If

    End Sub

    Private Sub Btn_Filtro_SucursalDoc_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_SucursalDoc.Click

        Dim _SqlFiltro_Fechas As String

        _SqlFiltro_Fechas = "Where FEEMLI BETWEEN '" & Format(Dtp_Fecha_Desde.Value, "yyyyMMdd") & "' AND '" &
                             Format(Dtp_Fecha_Hasta.Value, "yyyyMMdd") & "'" & vbCrLf

        Dim _Sql_Filtro_Condicion_Extra = "And EMPRESA+KOSU In (Select Distinct EMPRESA+SUDO From " &
                                          _Nombre_Tabla_Paso & vbCrLf & _SqlFiltro_Fechas & ")"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_SucursalDoc,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Sucursales, _Sql_Filtro_Condicion_Extra,
                               _Filtro_SucursalDoc_Todas, False) Then

            _Tbl_Filtro_SucursalDoc = _Filtrar.Pro_Tbl_Filtro
            _Filtro_SucursalDoc_Todas = _Filtrar.Pro_Filtro_Todas

            If Cmb_Vista_Informe.SelectedValue = "SUDO" Then
                Sb_Actualizar_Grilla(False)
            Else
                Cmb_Vista_Informe.SelectedValue = "SUDO"
            End If

        End If

    End Sub

    Private Sub Btn_Importar_Informe_Click(sender As Object, e As EventArgs) Handles Btn_Importar_Informe.Click

        ImportarComisiones = True
        Me.Close()

    End Sub

    Private Sub Btn_Filtro_Ent_EntidadesExcluidas_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Ent_EntidadesExcluidas.Click

        Dim _SqlFiltro_Fechas As String

        _SqlFiltro_Fechas = "Where FEEMLI BETWEEN '" & Format(Dtp_Fecha_Desde.Value, "yyyyMMdd") & "' AND '" &
                            Format(Dtp_Fecha_Hasta.Value, "yyyyMMdd") & "'" & vbCrLf

        Dim _Sql_Filtro_Condicion_Extra = "And KOEN+SUEN In (Select Distinct ENDO+SUENDO From " & _Nombre_Tabla_Paso & ")"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_EntidadExcluidas,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Entidades, _Sql_Filtro_Condicion_Extra,
                               False, False,, False,, False) Then

            _Tbl_Filtro_EntidadExcluidas = _Filtrar.Pro_Tbl_Filtro

            Sb_Actualizar_Grilla(False)

        End If

    End Sub

    Private Sub Btn_Filtro_Pro_ProductosExcluidos_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Pro_ProductosExcluidos.Click

        Dim _SqlFiltro_Fechas As String

        _SqlFiltro_Fechas = "Where FEEMLI BETWEEN '" & Format(Dtp_Fecha_Desde.Value, "yyyyMMdd") & "' AND '" &
                             Format(Dtp_Fecha_Hasta.Value, "yyyyMMdd") & "'" & vbCrLf

        Dim _Sql_Filtro_Condicion_Extra = "And KOPR In (Select Distinct KOPRCT From " & _Nombre_Tabla_Paso & ")"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_ProductosExcluidos,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Productos, _Sql_Filtro_Condicion_Extra,
                               False, False) Then

            _Tbl_Filtro_ProductosExcluidos = _Filtrar.Pro_Tbl_Filtro

            Sb_Actualizar_Grilla(False)

        End If

    End Sub

    Sub Sb_Formato_Graficos(_Grafico As Chart,
                            _ChartArea As Integer,
                            _Serie As Integer)

        Dim _Color_Grilla As Color
        Dim _Color_Fondo As Color
        Dim _Color_Letras As Color
        Dim _Color_Media As Color

        Dim _Color_Rango As Color

        With _Grafico

            Select Case Global_Thema

                Case Enum_Themas.Claro

                    _Color_Grilla = Color.LightGray
                    _Color_Letras = Color.Black
                    _Color_Media = Color.FromArgb(251, 237, 233)
                    _Color_Rango = Color.FromArgb(160, 197, 247)
                    .Palette = ChartColorPalette.BrightPastel
                    _Color_Fondo = Color.FromArgb(Global_camvasColor)

                Case Enum_Themas.Gris

                    _Color_Grilla = Color.FromArgb(231, 231, 231)
                    _Color_Letras = Color.Black
                    _Color_Media = Color.FromArgb(231, 231, 231)
                    _Color_Rango = Color.FromArgb(160, 197, 247)
                    .Palette = ChartColorPalette.BrightPastel
                    _Color_Fondo = Color.FromArgb(203, 203, 203)

                Case Enum_Themas.Azul

                    _Color_Grilla = Color.FromArgb(130, 130, 130)
                    _Color_Letras = Color.Black
                    _Color_Media = Color.FromArgb(251, 237, 233)
                    _Color_Rango = Color.FromArgb(160, 197, 247)
                    .Palette = ChartColorPalette.SeaGreen
                    _Color_Fondo = Color.FromArgb(Global_camvasColor)

                Case Enum_Themas.Oscuro

                    _Color_Grilla = Color.FromArgb(56, 62, 78)
                    _Color_Letras = Color.FromArgb(226, 226, 226)
                    _Color_Media = Color.FromArgb(35, 39, 42)
                    _Color_Rango = Color.FromArgb(35, 39, 42)
                    .Palette = ChartColorPalette.Chocolate
                    .Palette = ChartColorPalette.BrightPastel
                    _Color_Fondo = Color.FromArgb(Global_camvasColor)

            End Select

            Try
                .Titles.Item(0).ForeColor = _Color_Letras
                .Titles.Item(1).ForeColor = _Color_Letras
            Catch ex As Exception

            End Try

            .BorderSkin.PageColor = Color.FromArgb(32, 32, 32)

            Try
                .Series(_Serie).LabelForeColor = _Color_Letras
            Catch ex As Exception

            End Try

            Try
                .ChartAreas(_ChartArea).AxisY.StripLines.Item(0).ForeColor = _Color_Letras
                .ChartAreas(_ChartArea).AxisY.StripLines.Item(0).BackColor = _Color_Media
                .ChartAreas(_ChartArea).AxisY.StripLines.Item(1).ForeColor = _Color_Letras
                .ChartAreas(_ChartArea).AxisY.StripLines.Item(2).ForeColor = _Color_Letras

                '.ChartAreas(_ChartArea).AxisY.StripLines.Item(0).Text = "Desviación Estandar"
                '.ChartAreas(_ChartArea).AxisY.StripLines.Item(1).Text = "Mediana"
                '.ChartAreas(_ChartArea).AxisY.StripLines.Item(2).Text = "3"

            Catch ex As Exception

            End Try

            Try
                .Legends(0).ForeColor = _Color_Letras
            Catch ex As Exception

            End Try

            Try
                .ChartAreas(_ChartArea).AxisX.TitleForeColor = _Color_Letras
                .ChartAreas(_ChartArea).AxisX2.TitleForeColor = _Color_Letras
                .ChartAreas(_ChartArea).AxisY.TitleForeColor = _Color_Letras
                .ChartAreas(_ChartArea).AxisY2.TitleForeColor = _Color_Letras

                .ChartAreas(_ChartArea).AxisX.LabelStyle.ForeColor = _Color_Letras
                .ChartAreas(_ChartArea).AxisX2.LabelStyle.ForeColor = _Color_Letras
                .ChartAreas(_ChartArea).AxisY.LabelStyle.ForeColor = _Color_Letras
                .ChartAreas(_ChartArea).AxisY2.LabelStyle.ForeColor = _Color_Letras

                .ChartAreas(_ChartArea).AxisX.MajorGrid.LineColor = _Color_Grilla
                .ChartAreas(_ChartArea).AxisX2.MajorGrid.LineColor = _Color_Grilla
                .ChartAreas(_ChartArea).AxisY.MajorGrid.LineColor = _Color_Grilla
                .ChartAreas(_ChartArea).AxisY2.MajorGrid.LineColor = _Color_Grilla

                .ChartAreas(_ChartArea).AxisX.MinorGrid.LineColor = _Color_Grilla
                .ChartAreas(_ChartArea).AxisX2.MinorGrid.LineColor = _Color_Grilla
                .ChartAreas(_ChartArea).AxisY.MinorGrid.LineColor = _Color_Grilla
                .ChartAreas(_ChartArea).AxisY2.MinorGrid.LineColor = _Color_Grilla

                .ChartAreas(_ChartArea).AxisX.MajorTickMark.LineColor = _Color_Grilla
                .ChartAreas(_ChartArea).AxisX2.MajorTickMark.LineColor = _Color_Grilla
                .ChartAreas(_ChartArea).AxisY.MajorTickMark.LineColor = _Color_Grilla
                .ChartAreas(_ChartArea).AxisY2.MajorTickMark.LineColor = _Color_Grilla

                .ChartAreas(_ChartArea).AxisX.LineColor = _Color_Grilla
                .ChartAreas(_ChartArea).AxisX2.LineColor = _Color_Grilla
                .ChartAreas(_ChartArea).AxisY.LineColor = _Color_Grilla
                .ChartAreas(_ChartArea).AxisY2.LineColor = _Color_Grilla


                .ChartAreas(_ChartArea).BorderColor = _Color_Grilla

                .ChartAreas(_ChartArea).BackColor = _Color_Fondo
            Catch ex As Exception

            End Try

        End With

    End Sub

    Private Sub Sb_Grafico_Tendencias()

        Dim rand As Random = New Random()
        Dim randSeed As Integer = rand.[Next]()

        rand = New Random(randSeed)
        Dim period As Integer = 100

        Grafico_Tendencias.Series("Ventas").Points.Clear()
        Dim high As Double = rand.NextDouble() * 40

        If high <= 0 Then
            high = -1 * high + 1
        End If


        Dim _Sql_Puntos_Cero = String.Empty

        Dim _F1 As Date = Dtp_Fecha_Desde.Value
        Dim _F2 As Date = Dtp_Fecha_Hasta.Value

        Dim _Meses = DateDiff(DateInterval.Month, _F1, _F2) '+ 1
        Dim _Mes = _F1.Month

        Dim _Index_Fila As Integer

        Try
            _Index_Fila = Grilla.CurrentRow.Index
        Catch ex As Exception
            _Index_Fila = 0
        End Try

        Dim _Filtro_Nodos As String

        If _Filtro_Clas_BakApp_Todas Then
            _Filtro_Nodos = String.Empty
        Else
            _Filtro_Nodos = Generar_Filtro_IN(_Tbl_Filtro_Clas_BakApp, "Chk", "Codigo_Nodo", False, True, "")
            _Filtro_Nodos = "And KOPRCT In (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf &
                            "Where Codigo_Nodo In " & _Filtro_Nodos & ")"
        End If

        'Grafico_Tendencias.Series.Clear()

        Dim _Fila As DataGridViewRow = Grilla.Rows(_Index_Fila)

        Dim _Codigo = _Fila.Cells(0).Value
        Dim _Descripcion = _Fila.Cells(1).Value
        Dim _Campo = Cmb_Vista_Informe.SelectedValue

        Dim _New_SqlFiltro_Detalle = _SqlFiltro_Detalle

        _New_SqlFiltro_Detalle += "And " & _Campo & " = '" & _Codigo & "'"

        Consulta_sql = My.Resources.Recursos_Inf_Ventas.Inf_Grafico_Dinamica_Ventas_Mensuales_Fecha

        Consulta_sql = Replace(Consulta_sql, "#CODIGO#", _Cp_Codigo)
        Consulta_sql = Replace(Consulta_sql, "#DESCRIPCION#", _Cp_Descripcion)
        Consulta_sql = Replace(Consulta_sql, "#Tabla_Paso#", _Nombre_Tabla_Paso)
        Consulta_sql = Replace(Consulta_sql, "#Filtro_Sql#", _New_SqlFiltro_Detalle & vbCrLf & _Filtro_Nodos)
        Consulta_sql = Replace(Consulta_sql, "#Filtro_Fechas#", "")
        Consulta_sql = Replace(Consulta_sql, "#Sql_Puntos_Cero#", _Sql_Puntos_Cero)

        Dim _Tbl_Grafico_Tendencia As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        'Dim _Tbl As DataTable = _Tbl_Grafico_Tendencia

        Dim dv As DataView = _Tbl_Grafico_Tendencia.DefaultView

        Dim close As Double = high - rand.NextDouble()
        Dim low As Double = close - rand.NextDouble()
        Dim volume As Double = 100 + 15 * rand.NextDouble()

        Dim _Fecha As DateTime = _Tbl_Grafico_Tendencia.Rows(0).Item("Fecha")

        Dim _Ud = _Tbl_Grafico_Tendencia.Rows(0).Item("Total")

        Dim _dias = DateDiff(DateInterval.Day, Dtp_Fecha_Desde.Value, Dtp_Fecha_Hasta.Value)
        period = _dias

        Grafico_Tendencias.Series("Ventas").Points.AddXY(DateTime.Parse(_Fecha), _Ud)

        For day As Integer = 1 To period

            dv.RowFilter = "Fecha = '" & Format(_Fecha, "dd-MM-yyyy") & "'"
            Dim _Row As DataTable = dv.Table

            If CBool(dv.Count) Then
                _Ud = dv.Item(0).Item("Total")
            Else
                _Ud -= 0.1
            End If

            If _Ud < 0 Then
                _Ud = 0
            End If

            close = _Ud - 0.1 'high - rand.NextDouble()
            low = _Ud - 0.1 'close - rand.NextDouble()
            If low > Grafico_Tendencias.Series("Ventas").Points(day - 1).YValues(2) Then low = Grafico_Tendencias.Series("Ventas").Points(day - 1).YValues(2)

            If high <= 0 Then
                high = -1 * high + 1
            End If

            Grafico_Tendencias.Series("Ventas").Points.AddXY(day, _Ud)

            Dim _Fee = Grafico_Tendencias.Series("Ventas").Points(day - 1).XValue + 1

            Grafico_Tendencias.Series("Ventas").Points(day).XValue = _Fee
            _Fecha = DateAdd(DateInterval.Day, 1, _Fecha)

        Next

        Grafico_Tendencias.Invalidate()

        Sb_Linea_Tendencia()

    End Sub

    Private Sub Sb_Linea_Tendencia()
        Try

            Dim typeRegression As String = "Polynomial"

            typeRegression = "Linear"

            'typeRegression = "Exponential"
            'typeRegression = "Power"

            'If comboBoxRegressionType.Text <> "Polynomial" Then
            'typeRegression = comboBoxRegressionType.Text
            'Else
            'typeRegression = comboBoxOrder.Text
            'End If

            Dim _Dias = DateDiff(DateInterval.Day, Dtp_Fecha_Desde.Value, Dtp_Fecha_Hasta.Value) + 50

            Dim forecasting As Integer = 75 '_Dias '365 * 2 ' Integer.Parse(comboBoxForecasting.Text)
            Dim [error] As String = "True" 'checkBoxError.Checked.ToString()
            Dim forecastingError As String = "False" 'checkBoxForecastingError.Checked.ToString()
            Dim parameters As String = typeRegression & ","c & forecasting & ","c & [error] & ","c & forecastingError

            Grafico_Tendencias.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, parameters, "Ventas:Y", "Proyeccion:Y,Rango:Y,Rango:Y2")
            Grafico_Tendencias.Series("Rango").Enabled = True
            Grafico_Tendencias.Invalidate()

        Catch ex As Exception

        End Try

    End Sub


End Class
