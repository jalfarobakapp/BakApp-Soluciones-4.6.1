Imports DevComponents.DotNetBar

Public Class Frm_Inf_Ventas_X_Periodo_Sub_Informes_02_Mensual

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_Informe As DataTable

    Dim _Fecha_Inicio_01 As Date
    Dim _Fecha_Fin_01 As Date
    Dim _Fecha_Inicio_02 As Date
    Dim _Fecha_Fin_02 As Date

    Dim _SqlFiltro As String
    Dim _SqlFiltro_Detalle As String

    Dim _Fl_Sucursales = String.Empty
    Dim _Fl_Bodegas = String.Empty
    Dim _Fl_Super_Familias = String.Empty
    Dim _Fl_Entidades = String.Empty
    Dim _Fl_Ciudades = String.Empty
    Dim _Fl_Comunas = String.Empty
    Dim _Fl_Productos_Consolidados = String.Empty
    Dim _Fl_Funcionarios = String.Empty

    Dim _Tbl_Filtro_Entidad As DataTable
    Dim _Tbl_Filtro_Ciudad As DataTable
    Dim _Tbl_Filtro_Comunas As DataTable
    Dim _Tbl_Filtro_Rubro_Entidades As DataTable
    Dim _Tbl_Filtro_Zonas_Entidades As DataTable
    Dim _Tbl_Filtro_Responzables As DataTable
    Dim _Tbl_Filtro_Vendedores As DataTable
    Dim _Tbl_Filtro_Productos As DataTable
    Dim _Tbl_Filtro_Super_Familias As DataTable
    Dim _Tbl_Filtro_Marcas As DataTable
    Dim _Tbl_Filtro_Rubro_Productos As DataTable
    Dim _Tbl_Filtro_Clalibpr As DataTable
    Dim _Tbl_Filtro_Zonas_Productos As DataTable

    Dim _Filtro_Entidad_Todas As Boolean
    Dim _Filtro_Ciudad_Todas As Boolean
    Dim _Filtro_Comunas_Todas As Boolean
    Dim _Filtro_Rubro_Entidades_Todas As Boolean
    Dim _Filtro_Zonas_Entidades_Todas As Boolean
    Dim _Filtro_Responzables_Todas As Boolean
    Dim _Filtro_Vendedores_Todas As Boolean
    Dim _Filtro_Productos_Todos As Boolean
    Dim _Filtro_Marcas_Todas As Boolean
    Dim _Filtro_Super_Familias_Todas As Boolean
    Dim _Filtro_Rubro_Productos_Todas As Boolean
    Dim _Filtro_Clalibpr_Todas As Boolean
    Dim _Filtro_Zonas_Productos_Todas As Boolean
    Dim _Filtro_Bodegas_Todas As Boolean

    Dim _Cp_Codigo, _Cp_Descripcion, _Group_By, _Tx_Descripcion As String

    Dim _Nombre_Tabla_Paso As String
    Dim _Nombre_Tabla_Paso2 As String

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
    Dim _Informe As Enum_Informe
    Dim _Unidad As Integer
    Dim _Nombre_Excel As String
    Dim _Correr_a_la_derecha As Boolean
    Dim _Top, _Left As Integer

    Public ReadOnly Property Pro_Fecha_Inicio_01() As Date
        Get
            Return _Fecha_Inicio_01
        End Get
    End Property
    Public ReadOnly Property Pro_Fecha_Fin_01() As Date
        Get
            Return _Fecha_Fin_01
        End Get
    End Property

    Public ReadOnly Property Pro_Fecha_Inicio_02() As Date
        Get
            Return _Fecha_Inicio_02
        End Get
    End Property
    Public ReadOnly Property Pro_Fecha_Fin_02() As Date
        Get
            Return _Fecha_Fin_02
        End Get
    End Property

    Public Property Pro_Fl_Sucursales() As String
        Get
            Return _Fl_Sucursales
        End Get
        Set(value As String)
            _Fl_Sucursales = value
        End Set
    End Property
    Public Property Pro_Fl_Bodegas() As String
        Get
            Return _Fl_Bodegas
        End Get
        Set(value As String)
            _Fl_Bodegas = value
        End Set
    End Property
    Public Property Pro_Fl_Entidades() As String
        Get
            Return _Fl_Entidades
        End Get
        Set(value As String)
            _Fl_Entidades = value
        End Set
    End Property
    Public Property Pro_Fl_Super_Familias() As String
        Get
            Return _Fl_Super_Familias
        End Get
        Set(value As String)
            _Fl_Super_Familias = value
        End Set
    End Property
    Public Property Pro_Fl_Ciudades() As String
        Get
            Return _Fl_Ciudades
        End Get
        Set(value As String)
            _Fl_Ciudades = value
        End Set
    End Property
    Public Property Pro_Fl_Comunas() As String
        Get
            Return _Fl_Comunas
        End Get
        Set(value As String)
            _Fl_Comunas = value
        End Set
    End Property
    Public Property Pro_Fl_Productos_Consolidados() As String
        Get
            Return _Fl_Productos_Consolidados
        End Get
        Set(value As String)
            _Fl_Productos_Consolidados = value
        End Set
    End Property
    Public Property Pro_Fl_Funcionarios() As String
        Get
            Return _Fl_Funcionarios
        End Get
        Set(value As String)
            _Fl_Funcionarios = value
        End Set
    End Property

    Public Property Pro_Tbl_Filtro_Productos() As DataTable
        Get
            Return _Tbl_Filtro_Productos
        End Get
        Set(value As DataTable)
            _Tbl_Filtro_Productos = value
        End Set
    End Property
    Public Property Pro_Tbl_Filtro_Super_Familias() As DataTable
        Get
            Return _Tbl_Filtro_Super_Familias
        End Get
        Set(value As DataTable)
            _Tbl_Filtro_Super_Familias = value
        End Set
    End Property
    Public Property Pro_Tbl_Filtro_Marcas() As DataTable
        Get
            Return _Tbl_Filtro_Marcas
        End Get
        Set(value As DataTable)
            _Tbl_Filtro_Marcas = value
        End Set
    End Property
    Public Property Pro_Tbl_Filtro_Rubro_Productos() As DataTable
        Get
            Return _Tbl_Filtro_Rubro_Productos
        End Get
        Set(value As DataTable)
            _Tbl_Filtro_Rubro_Productos = value
        End Set
    End Property
    Public Property Pro_Tbl_Filtro_Clalibpr() As DataTable
        Get
            Return _Tbl_Filtro_Clalibpr
        End Get
        Set(value As DataTable)
            _Tbl_Filtro_Clalibpr = value
        End Set
    End Property
    Public Property Pro_Tbl_Filtro_Zonas_Productos() As DataTable
        Get
            Return _Tbl_Filtro_Zonas_Productos
        End Get
        Set(value As DataTable)
            _Tbl_Filtro_Zonas_Productos = value
        End Set
    End Property
    Public Property Pro_Tbl_Filtro_Entidad() As DataTable
        Get
            Return _Tbl_Filtro_Entidad
        End Get
        Set(value As DataTable)
            _Tbl_Filtro_Entidad = value
        End Set
    End Property
    Public Property Pro_Tbl_Filtro_Ciudad() As DataTable
        Get
            Return _Tbl_Filtro_Ciudad
        End Get
        Set(value As DataTable)
            _Tbl_Filtro_Ciudad = value
        End Set
    End Property
    Public Property Pro_Tbl_Filtro_Comunas() As DataTable
        Get
            Return _Tbl_Filtro_Comunas
        End Get
        Set(value As DataTable)
            _Tbl_Filtro_Comunas = value
        End Set
    End Property
    Public Property Pro_Tbl_Filtro_Rubro_Entidades() As DataTable
        Get
            Return _Tbl_Filtro_Rubro_Entidades
        End Get
        Set(value As DataTable)
            _Tbl_Filtro_Rubro_Entidades = value
        End Set
    End Property
    Public Property Pro_Tbl_Filtro_Zonas_Entidades() As DataTable
        Get
            Return _Tbl_Filtro_Zonas_Entidades
        End Get
        Set(value As DataTable)
            _Tbl_Filtro_Zonas_Entidades = value
        End Set
    End Property
    Public Property Pro_Tbl_Filtro_Responzables() As DataTable
        Get
            Return _Tbl_Filtro_Responzables
        End Get
        Set(value As DataTable)
            _Tbl_Filtro_Responzables = value
        End Set
    End Property
    Public Property Pro_Tbl_Filtro_Vendedores() As DataTable
        Get
            Return _Tbl_Filtro_Vendedores
        End Get
        Set(value As DataTable)
            _Tbl_Filtro_Vendedores = value
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

    Dim _Sabado As Boolean
    Dim _Domingo As Boolean

    Public Sub New(Nombre_Tabla_Paso As String,
                   Fecha_Inicio_01 As Date,
                   Fecha_Fin_01 As Date,
                   Fecha_Inicio_02 As Date,
                   Fecha_Fin_02 As Date,
                   Informe As Enum_Informe,
                   Unidad As Integer,
                   Sabado As Boolean,
                   Domingo As Boolean,
                   Optional Correr_a_la_derecha As Boolean = False)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Nombre_Tabla_Paso = Nombre_Tabla_Paso
        _Nombre_Tabla_Paso2 = Nombre_Tabla_Paso & "_02"

        _Fecha_Inicio_01 = Fecha_Inicio_01
        _Fecha_Fin_01 = Fecha_Fin_01

        _Fecha_Inicio_02 = Fecha_Inicio_02
        _Fecha_Fin_02 = Fecha_Fin_02

        _Informe = Informe

        _Nombre_Tabla_Paso = Nombre_Tabla_Paso
        _Unidad = Unidad
        _Correr_a_la_derecha = Correr_a_la_derecha

        _Filtro_Entidad_Todas = True
        _Filtro_Ciudad_Todas = True
        _Filtro_Comunas_Todas = True
        _Filtro_Rubro_Entidades_Todas = True
        _Filtro_Zonas_Entidades_Todas = True

        _Filtro_Vendedores_Todas = True
        _Filtro_Responzables_Todas = True

        _Filtro_Productos_Todos = True
        _Filtro_Clalibpr_Todas = True
        _Filtro_Marcas_Todas = True
        _Filtro_Rubro_Productos_Todas = True
        _Filtro_Super_Familias_Todas = True
        _Filtro_Zonas_Productos_Todas = True

        _Sabado = Sabado
        _Domingo = Domingo

        Me.Width = 1000
        Me.Height = 600

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)

        If Global_Thema = Enum_Themas.Oscuro Then

            Btn_Cambiar_Fechas.ForeColor = Color.White
            Btn_Filtrar.ForeColor = Color.White
            Btn_Graficar.ForeColor = Color.White

        End If

    End Sub

    Private Sub Frm_Inf_Ventas_X_Periodo_Sub_Informes_02_Mensual_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        _SqlFiltro = _Fl_Sucursales & vbCrLf &
                     _Fl_Bodegas & vbCrLf &
                     _Fl_Super_Familias & vbCrLf &
                     _Fl_Entidades & vbCrLf &
                     _Fl_Ciudades & vbCrLf &
                     _Fl_Comunas & vbCrLf &
                     _Fl_Productos_Consolidados & vbCrLf &
                     _Fl_Funcionarios

        If _Correr_a_la_derecha Then
            Me.Top = _Top + 5
            Me.Left = _Left + 5
        End If

        Btn_Informe_X_Bodega.Visible = String.IsNullOrEmpty(_Fl_Bodegas)
        Btn_Informe_X_Super_Familia.Visible = String.IsNullOrEmpty(_Fl_Super_Familias)
        Btn_Informe_X_Entidades.Visible = String.IsNullOrEmpty(_Fl_Entidades)
        Btn_Informe_X_Ciudades.Visible = String.IsNullOrEmpty(_Fl_Ciudades)
        Btn_Informe_X_Comunas.Visible = String.IsNullOrEmpty(_Fl_Comunas)
        Btn_Informe_X_Productos_Consolidados.Visible = String.IsNullOrEmpty(_Fl_Productos_Consolidados)
        Btn_Informe_X_Funcionarios.Visible = String.IsNullOrEmpty(_Fl_Funcionarios)



        Select Case _Informe
            Case Enum_Informe.Sucursal
                _Nombre_Excel = "Inf_X_Sucursal"
                _Cp_Codigo = "SULIDO" : _Cp_Descripcion = "SUCURSAL" : _Tx_Descripcion = "Sucursales"
                _Group_By = "SULIDO,SUCURSAL"
                RemoveHandler Me.KeyDown, AddressOf Sb_Frm_KeyDown
            Case Enum_Informe.Bodega
                Btn_Informe_X_Bodega.Visible = False
                _Nombre_Excel = "Inf_X_Bodega"
                _Cp_Codigo = "BOSULIDO" : _Cp_Descripcion = "BODEGA" : _Tx_Descripcion = "Bodegas"
                _Group_By = "BOSULIDO,BODEGA"
            Case Enum_Informe.Super_Familia
                Btn_Informe_X_Super_Familia.Visible = False
                _Nombre_Excel = "Inf_X_Familia"
                _Cp_Codigo = "FMPR" : _Cp_Descripcion = "SUPER_FAMILIA" : _Tx_Descripcion = "Super Familias"
                _Group_By = "FMPR,SUPER_FAMILIA"
            Case Enum_Informe.Entidades
                Btn_Informe_X_Entidades.Visible = False
                _Nombre_Excel = "Inf_X_Entidades"
                _Cp_Codigo = "ENDO+SUENDO" : _Cp_Descripcion = "RAZON" : _Tx_Descripcion = "Razón Social"
                _Group_By = "ENDO,SUENDO,RAZON"
            Case Enum_Informe.Ciudades
                Btn_Informe_X_Ciudades.Visible = False
                _Nombre_Excel = "Inf_X_Ciudades"
                _Cp_Codigo = "CIEN" : _Cp_Descripcion = "CIUDAD" : _Tx_Descripcion = "Ciudades-Regiones"
                _Group_By = "CIEN,CIUDAD"
            Case Enum_Informe.Comunas
                Btn_Informe_X_Comunas.Visible = False
                _Nombre_Excel = "Inf_X_Comunas"
                _Cp_Codigo = "CMEN" : _Cp_Descripcion = "COMUNA" : _Tx_Descripcion = "Comunas"
                _Group_By = "CMEN,COMUNA"
            Case Enum_Informe.Productos_Consolidados
                Btn_Informe_X_Productos_Consolidados.Visible = False
                _Nombre_Excel = "Inf_X_Productos_Cons"
                _Cp_Codigo = "KOPRCT" : _Cp_Descripcion = "NOKOPR" : _Tx_Descripcion = "Productos (Descripción)"
                _Group_By = "KOPRCT,NOKOPR"
            Case Enum_Informe.Funcionarios
                Btn_Informe_X_Funcionarios.Visible = False
                _Nombre_Excel = "Inf_X_Funcionarios"
                _Cp_Codigo = "KOFULIDO" : _Cp_Descripcion = "VENDEDOR"
                _Group_By = "KOFULIDO,VENDEDOR"
        End Select

        Sb_Actualizar_Informe()

        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_Detalle_MouseDown
        AddHandler Grilla.RowPostPaint, AddressOf Sb_RowsPostPaint



    End Sub

    Sub Sb_Actualizar_Rut_Informe(_Tabla_Paso As String)

        Dim _Tbl As DataTable

        Consulta_sql = "Select Distinct RTEN From " & _Tabla_Paso
        _Tbl = _Sql.Fx_Get_Tablas(Consulta_sql)
        Consulta_sql = String.Empty

        If CBool(_Tbl.Rows.Count) Then
            For Each _Row As DataRow In _Tbl.Rows
                Dim _Rten = Trim(_Row.Item("RTEN"))
                Dim _Rut As String
                If Not String.IsNullOrEmpty(_Rten) Then _Rut = FormatNumber(Val(_Rten), 0) & "-" & RutDigito(_Rten)
                Consulta_sql += "Update " & _Tabla_Paso & " Set RUT = '" & _Rut & "' Where RTEN = '" & _Rten & "'" & vbCrLf
            Next
            _Sql.Ej_consulta_IDU(Consulta_sql)
        End If

    End Sub

    Sub Sb_Actualizar_Informe()

        _SqlFiltro_Detalle = Fx_Filtro_Detalle()

        Consulta_sql = "Select distinct FEEMDO From " & _Nombre_Tabla_Paso & vbCrLf &
                       "Where FEEMDO BETWEEN '" & Format(_Fecha_Inicio_01, "yyyyMMdd") & "' AND " &
                       "'" & Format(_Fecha_Fin_01, "yyyyMMdd") & "'"

        Dim _TblDias As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim _Meses = DateDiff(DateInterval.Month, _Fecha_Inicio_01, _Fecha_Fin_01)
        Dim _Meses2 = DateDiff(DateInterval.Month, _Fecha_Inicio_02, _Fecha_Fin_02)

        Dim _Arreglo_Meses(_Meses) As String
        Dim _Fecha_mes As Date = _Fecha_Inicio_01
        Dim _Fecha_mes2 As Date = _Fecha_Inicio_02

        Dim _Dias_Habiles_01 = Fx_Cuenta_Dias(_Fecha_Inicio_01, _Fecha_Fin_01, Opcion_Dias.Habiles) 'Fx_Dias_Habiles(_Fecha_Estudio_Desde, _Fecha_Estudio_Hasta)
        Dim _Dias_Sabado_01 = Fx_Cuenta_Dias(_Fecha_Inicio_01, _Fecha_Fin_01, Opcion_Dias.Sabado)
        Dim _Dias_Domingo_01 = Fx_Cuenta_Dias(_Fecha_Inicio_01, _Fecha_Fin_01, Opcion_Dias.Domingo)

        Consulta_sql = "SELECT " & _Cp_Codigo & " As CODIGO," & _Cp_Descripcion & " As DESCRIPCION," & vbCrLf

        Dim _Arreglo_Campos_Periodo_01() As String = Fx_Construir_Campos(_Meses, _Fecha_mes, "_01")
        Dim _Sql_Campo = _Arreglo_Campos_Periodo_01(0)
        Dim _Sql_Suma = _Arreglo_Campos_Periodo_01(1)

        Dim _Arreglo_Campos_Periodo_02() As String = Fx_Construir_Campos(_Meses2, _Fecha_mes2, "_02")
        Dim _Sql_Campo2 = _Arreglo_Campos_Periodo_02(0)
        Dim _Sql_Suma2 = _Arreglo_Campos_Periodo_02(1)

        '_Sql_Suma = String.Empty

        Dim _Dias_Habiles_02 = Fx_Cuenta_Dias(_Fecha_Inicio_02, _Fecha_Fin_02, Opcion_Dias.Habiles) 'Fx_Dias_Habiles(_Fecha_Estudio_Desde, _Fecha_Estudio_Hasta)
        Dim _Dias_Sabado_02 = Fx_Cuenta_Dias(_Fecha_Inicio_02, _Fecha_Fin_02, Opcion_Dias.Sabado)
        Dim _Dias_Domingo_02 = Fx_Cuenta_Dias(_Fecha_Inicio_02, _Fecha_Fin_02, Opcion_Dias.Domingo)

        Dim _Fin_Mes_02 = ultimodiadelmes(_Fecha_Inicio_02)
        Dim _Dias_Habiles_Proyeccion = Fx_Cuenta_Dias(_Fecha_Fin_02, _Fin_Mes_02, Opcion_Dias.Habiles) 'Fx_Dias_Habiles(_Fecha_Estudio_Desde, _Fecha_Estudio_Hasta)
        Dim _Dias_Sabado_Proyeccion = Fx_Cuenta_Dias(_Fecha_Fin_02, _Fin_Mes_02, Opcion_Dias.Sabado)
        Dim _Dias_Domingo_Proyeccion = Fx_Cuenta_Dias(_Fecha_Fin_02, _Fin_Mes_02, Opcion_Dias.Domingo)

        Dim _Dias_Promedio_01 As Integer = _Dias_Habiles_01
        Dim _Dias_Promedio_02 As Integer = _Dias_Habiles_02
        Dim _Dias_Proyeccion As Integer = _Dias_Habiles_Proyeccion

        If _Sabado Then
            _Dias_Promedio_01 += _Dias_Sabado_01
            _Dias_Promedio_02 += _Dias_Sabado_02
            _Dias_Proyeccion += _Dias_Sabado_Proyeccion
        End If

        If _Domingo Then
            _Dias_Promedio_01 += _Dias_Domingo_01
            _Dias_Promedio_02 += _Dias_Domingo_02
            _Dias_Proyeccion += _Dias_Domingo_Proyeccion
        End If

        Dim _Fecha_Entre_01 As String = "FEEMDO BETWEEN '" & Format(_Fecha_Inicio_01, "yyyyMMdd") & "' AND " &
                                        "'" & Format(_Fecha_Fin_01, "yyyyMMdd") & "'"

        Dim _Fecha_Entre_02 As String = "FEEMDO BETWEEN '" & Format(_Fecha_Inicio_02, "yyyyMMdd") & "' AND " &
                                        "'" & Format(_Fecha_Fin_02, "yyyyMMdd") & "'"

        '"Isnull((Select Sum(VANELI) From " & _Nombre_Tabla_Paso2 & " T2 Where T2." & _Cp_Codigo & " = T1." & _Cp_Codigo & " And " & _Fecha_Entre_02 & " ),0) As Ventas_Periodo_02," & vbCrLf & _
        Consulta_sql += _Sql_Campo & "," & vbCrLf &
                        "Cast(0 as Float) As Ventas_Periodo_01," & vbCrLf &
                        _Meses + 1 & " As Meses," & vbCrLf &
                        _Dias_Promedio_01 & " As Dias_Promedio_01," & vbCrLf &
                        "Cast(0 As Float) As Prom_Vta_01_Diario," & vbCrLf &
                        "Cast(0 As Float) As Prom_Vta_01_Mensual," & vbCrLf &
                        "'' As Separacion," & vbCrLf &
                        _Sql_Campo2 & "," & vbCrLf &
                        "Cast(0 as Float) As Ventas_Periodo_02," & vbCrLf &
                        _Meses2 + 1 & " As Meses_02," & vbCrLf &
                        _Dias_Promedio_02 & " As Dias_Promedio_02," & vbCrLf &
                        "Cast(0 As Float) As Prom_Vta_02_Diario," & vbCrLf &
                        "Cast(0 As Float) As Prom_Vta_02_Mensual," & vbCrLf &
                        "'' As Separacion2," & vbCrLf &
                        "Cast(0 As Float) As Diferencia," & vbCrLf &
                        _Dias_Proyeccion & " As Dias_Proyeccion," & vbCrLf &
                        "Cast(0 As Float) As Referencia," & vbCrLf &
                        "Cast(0 As Float) As Dif_Referencia" &
                        vbCrLf &
                        vbCrLf &
                        "Into #Tbl_Paso" & vbCrLf &
                        "From " & _Nombre_Tabla_Paso & " T1 " & vbCrLf &
                        "Where 1 > 0" & vbCrLf &
                        _SqlFiltro_Detalle &
                        "GROUP BY " & _Group_By &
                        vbCrLf &
                        vbCrLf &
                        "Insert Into #Tbl_Paso" & vbCrLf &
                        "Select 'ZZZ' As CODIGO,'Total' As DESCRIPCION," & vbCrLf &
                        _Sql_Suma & "," & vbCrLf &
                        "Sum(Ventas_Periodo_01)," & vbCrLf &
                        _Meses + 1 & " As Meses_01," & vbCrLf &
                        _Dias_Promedio_01 & " As Dias_Promedio_01," & vbCrLf &
                        "Cast(0 As Float) As Prom_Vta_01_Diario," & vbCrLf &
                        "Cast(0 As Float) As Prom_Vta_01_Mensual," & vbCrLf &
                        "'' As Separacion," & vbCrLf &
                        _Sql_Suma2 & "," & vbCrLf &
                        "Sum(Ventas_Periodo_02)," & vbCrLf &
                        _Meses2 & " As Meses_02," & vbCrLf &
                        _Dias_Promedio_02 & " As Dias_Promedio_02," & vbCrLf &
                        "Cast(0 As Float) As Prom_Vta_02_Diario," & vbCrLf &
                        "Cast(0 As Float) As Prom_Vta_02_Mensual," & vbCrLf &
                        "'' As Separacion2," & vbCrLf &
                        "Cast(0 As Float) As Diferencia, " & vbCrLf &
                        _Dias_Proyeccion & " As Dias_Proyeccion," & vbCrLf &
                        "Cast(0 As Float) As Referencia," & vbCrLf &
                        "Cast(0 As Float) As Dif_Referencia" & vbCrLf &
                        "From #Tbl_Paso" &
                        vbCrLf &
                        vbCrLf &
                        "Update #Tbl_Paso Set Ventas_Periodo_01 = ISNULL((Select SUM(VANELI) From " & _Nombre_Tabla_Paso & " T1" & vbCrLf &
                        "Where " & _Fecha_Entre_01 & " And CODIGO = " & _Cp_Codigo & "),0)" &
                        vbCrLf & vbTab &
                        "Update #Tbl_Paso Set Ventas_Periodo_02 = ISNULL((Select SUM(VANELI) From " & _Nombre_Tabla_Paso & " T1" & vbCrLf &
                        "Where " & _Fecha_Entre_02 & " And CODIGO = " & _Cp_Codigo & "),0)" &
                        vbCrLf & vbTab &
                        "Update #Tbl_Paso Set Ventas_Periodo_01 = (Select SUM(Ventas_Periodo_01) From #Tbl_Paso)," &
                        "Ventas_Periodo_02 = (Select SUM(Ventas_Periodo_02) From #Tbl_Paso)" & vbCrLf & vbTab &
                        "Where CODIGO = 'ZZZ'" & vbCrLf & vbCrLf &
                        "Update #Tbl_Paso Set" & vbCrLf & vbTab &
                        "Prom_Vta_01_Diario = ROUND(Ventas_Periodo_01/" & _Dias_Promedio_01 & ",0)," & vbCrLf & vbTab &
                        "Prom_Vta_02_Diario = ROUND(Ventas_Periodo_02/" & _Dias_Promedio_02 & ",0)," & vbCrLf & vbTab &
                        "Prom_Vta_01_Mensual = ROUND(Ventas_Periodo_01/" & _Meses + 1 & ",0)," & vbCrLf & vbTab &
                        "Prom_Vta_02_Mensual = ROUND(Ventas_Periodo_02/" & _Meses2 + 1 & ",0)" & vbCrLf & vbTab &
                        vbCrLf &
                        "Update #Tbl_Paso Set Diferencia = ROUND(Ventas_Periodo_02-Prom_Vta_01_Mensual,0)" &
                        vbCrLf &
                        "Update #Tbl_Paso Set Referencia = (" & _Dias_Promedio_02 & "+" & _Dias_Proyeccion & ")*Prom_Vta_01_Diario" &
                        vbCrLf &
                        "Update #Tbl_Paso Set Dif_Referencia = (Referencia-Ventas_Periodo_02)*-1" &
                        vbCrLf &
                        "Select * From #Tbl_Paso Order By CODIGO" & vbCrLf &
                        "Drop Table #Tbl_Paso"

        _Tbl_Informe = _Sql.Fx_Get_Tablas(Consulta_sql)

        Grilla.DataSource = Nothing

        With Grilla

            .DataSource = _Tbl_Informe
            'Return
            OcultarEncabezadoGrilla(Grilla) ', True)

            .Columns("CODIGO").Width = 85
            .Columns("CODIGO").HeaderText = "Código"
            .Columns("CODIGO").Visible = True

            .Columns("DESCRIPCION").Width = 200
            .Columns("DESCRIPCION").HeaderText = "Descripción"
            .Columns("DESCRIPCION").Visible = True

            ' ¿Cuantas columnas y cuantas filas?
            Dim NCol As Integer = .ColumnCount
            Dim _Col_Fin = 0
            'Aqui recorremos todas las filas, y por cada fila todas las columnas y vamos escribiendo.
            For i As Integer = 0 To NCol - 1

                Dim NomColumna = .Columns(i).Name.ToString()
                Dim TipoColumna = .Columns(i).CellType.ToString 'DataGrid.Columns(i - 1).ValueType.ToString()
                Dim _Columna = Split(NomColumna, ".")
                '.Columns(i).Visible = False
                If NomColumna.Contains(".") Then
                    .Columns(i).Width = 100
                    .Columns(i).HeaderText = _Columna(0) & " " & _Columna(1)
                    .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns(i).DefaultCellStyle.Format = "$ ###,##"
                    .Columns(i).Visible = True
                End If

                If NomColumna = "Separacion" Then
                    Exit For
                End If
                _Col_Fin = i

            Next

            '.RowHeadersWidth = _Ancho1raColumna

            .Columns("Separacion").Width = 20
            .Columns("Separacion").HeaderText = "-"
            .Columns("Separacion").Visible = True

            For i As Integer = _Col_Fin To NCol - 1

                Dim NomColumna = .Columns(i).Name.ToString()
                Dim TipoColumna = .Columns(i).CellType.ToString 'DataGrid.Columns(i - 1).ValueType.ToString()
                Dim _Columna = Split(NomColumna, ".")
                '.Columns(i).Visible = False
                If NomColumna.Contains(".") Then
                    .Columns(i).Width = 100
                    .Columns(i).HeaderText = _Columna(0) & " " & _Columna(1)
                    .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns(i).DefaultCellStyle.Format = "$ ###,##"
                    .Columns(i).Visible = True
                End If

                If NomColumna = "Separacion2" Then
                    Exit For
                End If

            Next

        End With



    End Sub

    Function Fx_Construir_Campos(_Meses As Integer,
                                 _Fecha_mes As Date,
                                 _Sufijo As String) As String()

        Dim _Arreglo_Meses(_Meses) As String
        Dim _Sql_Campos, _Sql_Suma As String

        For _i = 0 To _Meses

            Dim _Coma = ","

            Dim _Dia = numero_(_Fecha_mes.Day, 2)
            Dim _Mes = numero_(_Fecha_mes.Month, 2)
            Dim _Ano = numero_(_Fecha_mes.Year, 4)

            Dim _Mes_Palabra = UCase(MonthName(_Mes))

            Dim _Campo As String = "[" & _Mes_Palabra & "." & _Ano & "." & _Sufijo & "]"
            _Arreglo_Meses(_i) = _Campo

            Dim _Fecha_Inicio_Mes As Date = Primerdiadelmes(_Fecha_mes)
            Dim _Fecha_Fin_Mes As Date = ultimodiadelmes(_Fecha_mes)

            If _i = _Meses Then
                _Coma = ""
            End If

            _Sql_Campos += _Campo & "=SUM(" & vbCrLf &
                            "CASE " & vbCrLf &
                            "WHEN FEEMDO BETWEEN '" & Format(_Fecha_Inicio_Mes, "yyyyMMdd") &
                            "' AND '" & Format(_Fecha_Fin_Mes, "yyyyMMdd") & "' THEN VANELI" & vbCrLf &
                            "ELSE 0.0" & vbCrLf &
                            "END )" & _Coma & vbCrLf

            _Sql_Suma += "Sum(" & _Campo & ") as '" & _Campo & "'" & _Coma & vbCrLf

            _Fecha_mes = DateAdd(DateInterval.Month, 1, _Fecha_mes)

        Next

        Dim _Arreglo_Sql(1) As String

        _Arreglo_Sql(0) = _Sql_Campos
        _Arreglo_Sql(1) = _Sql_Suma

        Return _Arreglo_Sql

    End Function

    Sub Sb_Revisar_Sub_Informe(_Sub_Informe As Enum_Informe)

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cod = _Fila.Cells(0).Value
        Dim _Des = UCase(_Informe.ToString)
        _Des = UCase(Trim(_Fila.Cells("DESCRIPCION").Value))

        Dim _Texto_Fm As String

        If _Cod = "ZZZ" Then
            _Texto_Fm = "DESDE " & UCase(_Informe.ToString) & ": TODAS"
        Else
            _Texto_Fm = "DESDE " & UCase(_Informe.ToString) & ": " & Trim(_Des)
        End If

        Dim Fl_Sucursales = _Fl_Sucursales
        Dim Fl_Bodegas = _Fl_Bodegas
        Dim Fl_Super_Familias = _Fl_Super_Familias
        Dim Fl_Entidades = _Fl_Entidades
        Dim Fl_Ciudades = _Fl_Ciudades
        Dim Fl_Comunas = _Fl_Comunas
        Dim Fl_Productos_Consolidados = _Fl_Productos_Consolidados
        Dim Fl_Funcionarios = _Fl_Funcionarios

        Select Case _Informe
            Case Enum_Informe.Sucursal
                Fl_Sucursales = Fx_Traer_Filtro("SULIDO") 'Fx_Traer_Filtro_Sucursales()
            Case Enum_Informe.Bodega
                Fl_Bodegas = Fx_Traer_Filtro("BOSULIDO") 'Fx_Traer_Filtro_Bodegas()
            Case Enum_Informe.Super_Familia
                Fl_Super_Familias = Fx_Traer_Filtro("FMPR") 'Fx_Traer_Filtro_Familias()
            Case Enum_Informe.Entidades
                Fl_Entidades = Fx_Traer_Filtro("ENDO+SUENDO")
            Case Enum_Informe.Ciudades
                Fl_Ciudades = Fx_Traer_Filtro("CIEN")
            Case Enum_Informe.Comunas
                Fl_Comunas = Fx_Traer_Filtro("CMEN")
            Case Enum_Informe.Productos_Consolidados
                Fl_Productos_Consolidados = Fx_Traer_Filtro("KOPRCT")
            Case Enum_Informe.Funcionarios
                Fl_Funcionarios = Fx_Traer_Filtro("KOFULIDO")
        End Select


        Dim Fm As New Frm_Inf_Ventas_X_Periodo_Sub_Informes_02_Mensual(_Nombre_Tabla_Paso,
                                                                       _Fecha_Inicio_01,
                                                                       _Fecha_Fin_01,
                                                                       _Fecha_Inicio_02,
                                                                       _Fecha_Fin_02,
                                                                       _Sub_Informe,
                                                                       _Unidad,
                                                                       _Sabado,
                                                                       _Domingo,
                                                                       True)

        Fm.Pro_Top = Me.Top
        Fm.Pro_Left = Me.Left

        Select Case _Sub_Informe
            Case Enum_Informe.Sucursal
                Fl_Sucursales = Fx_Traer_Filtro_Sucursales()
            Case Enum_Informe.Bodega
                Fm.Btn_Informe_X_Bodega.Visible = False
            Case Enum_Informe.Super_Familia
                Fm.Btn_Informe_X_Super_Familia.Visible = False
            Case Enum_Informe.Entidades
                Fm.Btn_Informe_X_Entidades.Visible = False
            Case Enum_Informe.Ciudades
                Fm.Btn_Informe_X_Ciudades.Visible = False
            Case Enum_Informe.Comunas
                Fm.Btn_Informe_X_Comunas.Visible = False
            Case Enum_Informe.Productos_Consolidados
                Fm.Btn_Informe_X_Productos_Consolidados.Visible = False
            Case Enum_Informe.Funcionarios
                Fm.Btn_Informe_X_Funcionarios.Visible = False
        End Select

        Fm.Pro_Fl_Sucursales = Fl_Sucursales
        Fm.Pro_Fl_Bodegas = Fl_Bodegas
        Fm.Pro_Fl_Super_Familias = Fl_Super_Familias
        Fm.Pro_Fl_Entidades = Fl_Entidades
        Fm.Pro_Fl_Ciudades = Fl_Ciudades
        Fm.Pro_Fl_Comunas = Fl_Comunas
        Fm.Pro_Fl_Productos_Consolidados = Fl_Productos_Consolidados
        Fm.Pro_Fl_Funcionarios = Fl_Funcionarios

        Fm.Pro_Tbl_Filtro_Clalibpr = _Tbl_Filtro_Clalibpr
        Fm.Pro_Tbl_Filtro_Marcas = _Tbl_Filtro_Marcas
        Fm.Pro_Tbl_Filtro_Productos = _Tbl_Filtro_Productos
        Fm.Pro_Tbl_Filtro_Rubro_Productos = _Tbl_Filtro_Rubro_Productos
        Fm.Pro_Tbl_Filtro_Super_Familias = _Tbl_Filtro_Super_Familias
        Fm.Pro_Tbl_Filtro_Zonas_Productos = _Tbl_Filtro_Zonas_Productos
        Fm.Pro_Tbl_Filtro_Entidad = _Tbl_Filtro_Entidad
        Fm.Pro_Tbl_Filtro_Ciudad = _Tbl_Filtro_Ciudad
        Fm.Pro_Tbl_Filtro_Comunas = _Tbl_Filtro_Comunas
        Fm.Pro_Tbl_Filtro_Rubro_Entidades = _Tbl_Filtro_Rubro_Entidades
        Fm.Pro_Tbl_Filtro_Zonas_Entidades = _Tbl_Filtro_Zonas_Entidades
        Fm.Pro_Tbl_Filtro_Responzables = _Tbl_Filtro_Responzables
        Fm.Pro_Tbl_Filtro_Vendedores = _Tbl_Filtro_Vendedores

        Fm.Pro_Filtro_Clalibpr_Todas = _Filtro_Clalibpr_Todas
        Fm.Pro_Filtro_Marcas_Todas = _Filtro_Marcas_Todas
        Fm.Pro_Filtro_Productos_Todos = _Filtro_Productos_Todos
        Fm.Pro_Filtro_Rubro_Productos_Todas = _Filtro_Rubro_Productos_Todas
        Fm.Pro_Filtro_Super_Familias_Todas = _Filtro_Super_Familias_Todas
        Fm.Pro_Filtro_Zonas_Productos_Todas = _Filtro_Zonas_Productos_Todas
        Fm.Pro_Filtro_Entidad_Todas = _Filtro_Entidad_Todas
        Fm.Pro_Filtro_Ciudad_Todas = _Filtro_Ciudad_Todas
        Fm.Pro_Filtro_Comunas_Todas = _Filtro_Comunas_Todas
        Fm.Pro_Filtro_Rubro_Entidades_Todas = _Filtro_Rubro_Entidades_Todas
        Fm.Pro_Filtro_Zonas_Entidades_Todas = _Filtro_Zonas_Entidades_Todas
        Fm.Pro_Filtro_Responzables_Todos = _Filtro_Responzables_Todas
        Fm.Pro_Filtro_Vendedores_Todos = _Filtro_Vendedores_Todas

        Fm.ShowDialog(Me)

        Fl_Sucursales = Fm.Pro_Fl_Sucursales
        Fl_Bodegas = Fm.Pro_Fl_Bodegas
        Fl_Super_Familias = Fm.Pro_Fl_Super_Familias
        Fl_Entidades = Fm.Pro_Fl_Entidades
        Fl_Ciudades = Fm.Pro_Fl_Ciudades
        Fl_Comunas = Fm.Pro_Fl_Comunas
        Fl_Productos_Consolidados = Fm.Pro_Fl_Productos_Consolidados
        Fl_Funcionarios = Fm.Pro_Fl_Funcionarios

        _Tbl_Filtro_Clalibpr = Fm.Pro_Tbl_Filtro_Clalibpr
        _Tbl_Filtro_Marcas = Fm.Pro_Tbl_Filtro_Marcas
        _Tbl_Filtro_Productos = Fm.Pro_Tbl_Filtro_Productos
        _Tbl_Filtro_Rubro_Productos = Fm.Pro_Tbl_Filtro_Rubro_Productos
        _Tbl_Filtro_Super_Familias = Fm.Pro_Tbl_Filtro_Super_Familias
        _Tbl_Filtro_Zonas_Productos = Fm.Pro_Tbl_Filtro_Zonas_Productos
        _Tbl_Filtro_Entidad = Fm.Pro_Tbl_Filtro_Entidad
        _Tbl_Filtro_Ciudad = Fm.Pro_Tbl_Filtro_Ciudad
        _Tbl_Filtro_Comunas = Fm.Pro_Tbl_Filtro_Comunas
        _Tbl_Filtro_Rubro_Entidades = Fm.Pro_Tbl_Filtro_Rubro_Entidades
        _Tbl_Filtro_Zonas_Entidades = Fm.Pro_Tbl_Filtro_Zonas_Entidades
        _Tbl_Filtro_Responzables = Fm.Pro_Tbl_Filtro_Responzables
        _Tbl_Filtro_Vendedores = Fm.Pro_Tbl_Filtro_Vendedores

        _Filtro_Clalibpr_Todas = Fm.Pro_Filtro_Clalibpr_Todas
        _Filtro_Marcas_Todas = Fm.Pro_Filtro_Marcas_Todas
        _Filtro_Productos_Todos = Fm.Pro_Filtro_Productos_Todos
        _Filtro_Rubro_Productos_Todas = Fm.Pro_Filtro_Rubro_Productos_Todas
        _Filtro_Super_Familias_Todas = Fm.Pro_Filtro_Super_Familias_Todas
        _Filtro_Zonas_Productos_Todas = Fm.Pro_Filtro_Zonas_Productos_Todas
        _Filtro_Entidad_Todas = Fm.Pro_Filtro_Entidad_Todas
        _Filtro_Ciudad_Todas = Fm.Pro_Filtro_Ciudad_Todas
        _Filtro_Comunas_Todas = Fm.Pro_Filtro_Comunas_Todas
        _Filtro_Rubro_Entidades_Todas = Fm.Pro_Filtro_Rubro_Entidades_Todas
        _Filtro_Zonas_Entidades_Todas = Fm.Pro_Filtro_Zonas_Entidades_Todas
        _Filtro_Responzables_Todas = Fm.Pro_Filtro_Responzables_Todos
        _Filtro_Vendedores_Todas = Fm.Pro_Filtro_Vendedores_Todos

        Fm.Dispose()

        Sb_Actualizar_Informe()

    End Sub

    Sub Sb_Generar_Informe_Mensual_Grupo_Entidades(_Fecha_Inicio_01 As Date,
                                                   _Fecha_Fin_01 As Date,
                                                   _Fecha_Inicio_02 As Date,
                                                   _Fecha_Fin_02 As Date)


        Consulta_sql = "Select distinct FEEMDO From " & _Nombre_Tabla_Paso & vbCrLf &
                       "Where FEEMDO BETWEEN '" & Format(_Fecha_Inicio_01, "yyyyMMdd") & "' AND " &
                       "'" & Format(_Fecha_Fin_01, "yyyyMMdd") & "'"

        Dim _TblDias As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim _Meses = DateDiff(DateInterval.Month, _Fecha_Inicio_01, _Fecha_Fin_01)
        Dim _Meses2 = DateDiff(DateInterval.Month, _Fecha_Inicio_02, _Fecha_Fin_02) + 1

        Dim _Arreglo_Meses(_Meses) As String
        Dim _Fecha_mes As Date = _Fecha_Inicio_01

        Dim _Sql_Suma As String = String.Empty

        Dim _Dias_Habiles_01 = Fx_Cuenta_Dias(_Fecha_Inicio_01, _Fecha_Fin_01, Opcion_Dias.Habiles) 'Fx_Dias_Habiles(_Fecha_Estudio_Desde, _Fecha_Estudio_Hasta)
        Dim _Dias_Sabado_01 = Fx_Cuenta_Dias(_Fecha_Inicio_01, _Fecha_Fin_01, Opcion_Dias.Sabado)
        Dim _Dias_Domingo_01 = Fx_Cuenta_Dias(_Fecha_Inicio_01, _Fecha_Fin_01, Opcion_Dias.Domingo)

        Consulta_sql = "SELECT RTEN,RUT,ENDO,RAZON," & vbCrLf

        For _i = 0 To _Meses

            Dim _Coma = ","

            Dim _Dia = numero_(_Fecha_mes.Day, 2)
            Dim _Mes = numero_(_Fecha_mes.Month, 2)
            Dim _Ano = numero_(_Fecha_mes.Year, 4)

            Dim _Mes_Palabra = UCase(MonthName(_Mes))

            Dim _Campo As String = "[" & _Mes_Palabra & "." & _Ano & "]"
            _Arreglo_Meses(_i) = _Campo

            Dim _Fecha_Inicio_Mes As Date = Primerdiadelmes(_Fecha_mes)
            Dim _Fecha_Fin_Mes As Date = ultimodiadelmes(_Fecha_mes)

            If _i = _Meses Then
                _Coma = ""
            End If

            Consulta_sql += _Campo & "=SUM(" & vbCrLf &
                            "CASE " & vbCrLf &
                            "WHEN FEEMDO BETWEEN '" & Format(_Fecha_Inicio_Mes, "yyyyMMdd") &
                            "' AND '" & Format(_Fecha_Fin_Mes, "yyyyMMdd") & "' THEN VANELI" & vbCrLf &
                            "ELSE 0.0" & vbCrLf &
                            "END )" & _Coma & vbCrLf

            _Sql_Suma += "Sum(" & _Campo & ") as '" & _Campo & "'" & _Coma & vbCrLf

            _Fecha_mes = DateAdd(DateInterval.Month, 1, _Fecha_mes)

        Next

        Dim _Dias_Habiles_02 = Fx_Cuenta_Dias(_Fecha_Inicio_02, _Fecha_Fin_02, Opcion_Dias.Habiles) 'Fx_Dias_Habiles(_Fecha_Estudio_Desde, _Fecha_Estudio_Hasta)
        Dim _Dias_Sabado_02 = Fx_Cuenta_Dias(_Fecha_Inicio_02, _Fecha_Fin_02, Opcion_Dias.Sabado)
        Dim _Dias_Domingo_02 = Fx_Cuenta_Dias(_Fecha_Inicio_02, _Fecha_Fin_02, Opcion_Dias.Domingo)

        Dim _Fin_Mes_02 = ultimodiadelmes(_Fecha_Inicio_02)
        Dim _Dias_Habiles_Proyeccion = Fx_Cuenta_Dias(_Fecha_Fin_02, _Fin_Mes_02, Opcion_Dias.Habiles) 'Fx_Dias_Habiles(_Fecha_Estudio_Desde, _Fecha_Estudio_Hasta)
        Dim _Dias_Sabado_Proyeccion = Fx_Cuenta_Dias(_Fecha_Fin_02, _Fin_Mes_02, Opcion_Dias.Sabado)
        Dim _Dias_Domingo_Proyeccion = Fx_Cuenta_Dias(_Fecha_Fin_02, _Fin_Mes_02, Opcion_Dias.Domingo)

        Dim _Dias_Promedio_01 As Integer = _Dias_Habiles_01
        Dim _Dias_Promedio_02 As Integer = _Dias_Habiles_02
        Dim _Dias_Proyeccion As Integer = _Dias_Habiles_Proyeccion

        If _Sabado Then
            _Dias_Promedio_01 += _Dias_Sabado_01
            _Dias_Promedio_02 += _Dias_Sabado_02
            _Dias_Proyeccion += _Dias_Sabado_Proyeccion
        End If

        If _Domingo Then
            _Dias_Promedio_01 += _Dias_Domingo_01
            _Dias_Promedio_02 += _Dias_Domingo_02
            _Dias_Proyeccion += _Dias_Domingo_Proyeccion
        End If

        Dim _Fecha_Entre_01 As String = "FEEMDO BETWEEN '" & Format(_Fecha_Inicio_01, "yyyyMMdd") & "' AND " &
                                        "'" & Format(_Fecha_Fin_01, "yyyyMMdd") & "'"

        Dim _Fecha_Entre_02 As String = "FEEMDO BETWEEN '" & Format(_Fecha_Inicio_02, "yyyyMMdd") & "' AND " &
                                        "'" & Format(_Fecha_Fin_02, "yyyyMMdd") & "'"


        Consulta_sql += ",Isnull((Select Sum(VANELI) From " & _Nombre_Tabla_Paso & " T2 Where T2.RTEN = T1.RTEN And " & _Fecha_Entre_01 & " ),0) As Ventas_Periodo_01," & vbCrLf &
                        _Meses + 1 & " As Meses," & vbCrLf &
                        _Dias_Promedio_01 & " As Dias_Promedio_01," & vbCrLf &
                        "Cast(0 As Float) As Prom_Vta_01_Diario," & vbCrLf &
                        "Cast(0 As Float) As Prom_Vta_01_Mensual," & vbCrLf &
                        "'' As Separacion," & vbCrLf &
                        "Isnull((Select Sum(VANELI) From " & _Nombre_Tabla_Paso2 & " T2 Where T2.RTEN = T1.RTEN And " & _Fecha_Entre_02 & " ),0) As Ventas_Periodo_02," & vbCrLf &
                        _Meses2 & " As Meses_02," & vbCrLf &
                        _Dias_Promedio_02 & " As Dias_Promedio_02," & vbCrLf &
                        "Cast(0 As Float) As Prom_Vta_02_Diario," & vbCrLf &
                        "Cast(0 As Float) As Prom_Vta_02_Mensual," & vbCrLf &
                        "Cast(0 As Float) As Diferencia," & vbCrLf &
                        _Dias_Proyeccion & " As Dias_Proyeccion," & vbCrLf &
                        "Cast(0 As Float) As Referencia," & vbCrLf &
                        "Cast(0 As Float) As Dif_Referencia" &
                        vbCrLf &
                        vbCrLf &
                        "Into #Tbl_Paso" & vbCrLf &
                        "From " & _Nombre_Tabla_Paso & " T1 " & vbCrLf &
                        "GROUP BY RTEN,RUT,ENDO,RAZON" &
                        vbCrLf &
                        vbCrLf &
                        "Insert Into #Tbl_Paso" & vbCrLf &
                        "Select 'ZZZ' As RTEN,'666666' As RUT,'ZZZ' As ENDO, 'Total' As RAZON," & vbCrLf &
                        _Sql_Suma & "," & vbCrLf &
                        "Sum(Ventas_Periodo_01)," & vbCrLf &
                        _Meses + 1 & " As Meses_01," & vbCrLf &
                        _Dias_Promedio_01 & " As Dias_Promedio_01," & vbCrLf &
                        "Cast(0 As Float) As Prom_Vta_01_Diario," & vbCrLf &
                        "Cast(0 As Float) As Prom_Vta_01_Mensual," & vbCrLf &
                        "'' As Separacion," & vbCrLf &
                        "Sum(Ventas_Periodo_02)," & vbCrLf &
                        _Meses2 & " As Meses_02," & vbCrLf &
                        _Dias_Promedio_02 & " As Dias_Promedio_02," & vbCrLf &
                        "Cast(0 As Float) As Prom_Vta_02_Diario," & vbCrLf &
                        "Cast(0 As Float) As Prom_Vta_02_Mensual," & vbCrLf &
                        "Cast(0 As Float) As Diferencia, " & vbCrLf &
                        _Dias_Proyeccion & " As Dias_Proyeccion," & vbCrLf &
                        "Cast(0 As Float) As Referencia," & vbCrLf &
                        "Cast(0 As Float) As Dif_Referencia" & vbCrLf &
                        "From #Tbl_Paso" &
                        vbCrLf &
                        vbCrLf &
                        "Update #Tbl_Paso Set" & vbCrLf & vbTab &
                        "Prom_Vta_01_Diario = ROUND(Ventas_Periodo_01/" & _Dias_Promedio_01 & ",0)," & vbCrLf & vbTab &
                        "Prom_Vta_02_Diario = ROUND(Ventas_Periodo_02/" & _Dias_Promedio_02 & ",0)," & vbCrLf & vbTab &
                        "Prom_Vta_01_Mensual = ROUND(Ventas_Periodo_01/" & _Meses + 1 & ",0)" & vbCrLf & vbTab &
                        "--Prom_Vta_02_Mensual = ROUND(Ventas_Periodo_02/" & _Dias_Promedio_02 & ",0)" &
                        vbCrLf &
                        "Update #Tbl_Paso Set Diferencia = ROUND(Prom_Vta_01_Mensual-Ventas_Periodo_02,0)" &
                        vbCrLf &
                        "Update #Tbl_Paso Set Referencia = (" & _Dias_Promedio_02 & "+" & _Dias_Proyeccion & ")*Prom_Vta_01_Diario" &
                        vbCrLf &
                        "Update #Tbl_Paso Set Dif_Referencia = (Referencia-Ventas_Periodo_02)*-1" &
                        vbCrLf &
                        "Select * From #Tbl_Paso" & vbCrLf &
                        "Drop Table #Tbl_Paso"



    End Sub


    Function Fx_Filtro_Detalle()

        Dim _Filtro_Entidades,
            _Filtro_Ciudad,
            _Filtro_Comunas,
            _Filtro_Vendedores,
            _Filtro_Responzables,
            _Filtro_Productos,
            _Filtro_Rubros,
            _Filtro_Marcas,
            _Filtro_Zonas,
            _Filtro_SuperFamilias,
            _Filtro_ClasLibre As String


        If _Filtro_Entidad_Todas Then
            _Filtro_Entidades = String.Empty
        Else
            _Filtro_Entidades = Generar_Filtro_IN(_Tbl_Filtro_Entidad, "Chk", "Codigo", False, True, "'")
            _Filtro_Entidades = "And ENDO IN " & _Filtro_Entidades
        End If

        If _Filtro_Ciudad_Todas Then
            _Filtro_Ciudad = String.Empty
        Else
            _Filtro_Ciudad = Generar_Filtro_IN(_Tbl_Filtro_Ciudad, "Chk", "Codigo", False, True, "'")
            _Filtro_Ciudad = "And ENDO IN (Select KOEN From MAEEN Where PAEN+CIEN In " & _Filtro_Ciudad & ")"
        End If

        If _Filtro_Comunas_Todas Then
            _Filtro_Comunas = String.Empty
        Else
            _Filtro_Comunas = Generar_Filtro_IN(_Tbl_Filtro_Comunas, "Chk", "Codigo", False, True, "'")
            _Filtro_Comunas = "And ENDO IN (Select KOEN From MAEEN Where PAEN+CIEN+CMEN In " & _Filtro_Comunas & ")"
        End If


        If _Filtro_Responzables_Todas Then
            _Filtro_Responzables = String.Empty
        Else
            _Filtro_Responzables = Generar_Filtro_IN(_Tbl_Filtro_Responzables, "Chk", "Codigo", False, True, "'")
            _Filtro_Responzables = "And KOFUDO IN " & _Filtro_Responzables
        End If

        If _Filtro_Vendedores_Todas Then
            _Filtro_Vendedores = String.Empty
        Else
            _Filtro_Vendedores = Generar_Filtro_IN(_Tbl_Filtro_Vendedores, "Chk", "Codigo", False, True, "'")
            _Filtro_Vendedores = "And KOFULIDO IN " & _Filtro_Vendedores
        End If

        If _Filtro_Productos_Todos Then
            _Filtro_Productos = String.Empty
        Else
            _Filtro_Productos = Generar_Filtro_IN(_Tbl_Filtro_Productos, "Chk", "Codigo", False, True, "'")
            _Filtro_Productos = "And KOPRCT IN " & _Filtro_Productos
        End If

        If _Filtro_Rubro_Productos_Todas Then
            _Filtro_Rubros = String.Empty
        Else
            _Filtro_Rubros = Generar_Filtro_IN(_Tbl_Filtro_Rubro_Productos, "Chk", "Codigo", False, True, "'")
            _Filtro_Rubros = "And KOPRCT IN (Select KOPR From MAEPR Where RUPR In " & _Filtro_Rubros & ")"
        End If

        If _Filtro_Marcas_Todas Then
            _Filtro_Marcas = String.Empty
        Else
            _Filtro_Marcas = Generar_Filtro_IN(_Tbl_Filtro_Marcas, "Chk", "Codigo", False, True, "'")
            _Filtro_Marcas = "And KOPRCT IN (Select KOPR From MAEPR Where MRPR In " & _Filtro_Marcas & ")"
        End If

        If _Filtro_Super_Familias_Todas Then
            _Filtro_SuperFamilias = String.Empty
        Else
            _Filtro_SuperFamilias = Generar_Filtro_IN(_Tbl_Filtro_Super_Familias, "Chk", "Codigo", False, True, "'")
            _Filtro_SuperFamilias = "And KOPRCT IN (Select KOPR From MAEPR Where FMPR In " & _Filtro_SuperFamilias & ")"
        End If

        If _Filtro_Clalibpr_Todas Then
            _Filtro_ClasLibre = String.Empty
        Else
            _Filtro_ClasLibre = Generar_Filtro_IN(_Tbl_Filtro_Clalibpr, "Chk", "Codigo", False, True, "'")
            _Filtro_ClasLibre = "And KOPRCT IN (Select KOPR From MAEPR Where CLALIBPR In " & _Filtro_ClasLibre & ")"
        End If

        If _Filtro_Zonas_Productos_Todas Then
            _Filtro_Zonas = String.Empty
        Else
            _Filtro_Zonas = Generar_Filtro_IN(_Tbl_Filtro_Zonas_Productos, "Chk", "Codigo", False, True, "'")
            _Filtro_Zonas = "And KOPRCT IN (Select KOPR From MAEPR Where ZONAPR In " & _Filtro_Zonas & ")"
        End If

        '---------------------------

        Dim _Filtro_Externo = _Filtro_Entidades & vbCrLf &
                              _Filtro_Ciudad & vbCrLf &
                              _Filtro_Comunas & vbCrLf &
                              _Filtro_Responzables & vbCrLf &
                              _Filtro_Vendedores & vbCrLf &
                              _Filtro_Productos & vbCrLf &
                              _Filtro_Rubros & vbCrLf &
                              _Filtro_Marcas & vbCrLf &
                              _Filtro_Zonas & vbCrLf &
                              _Filtro_SuperFamilias & vbCrLf &
                              _Filtro_ClasLibre

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

    Function Fx_Filtro_Informes() As String

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cod = _Fila.Cells(0).Value
        Dim _Des = UCase(_Informe.ToString)
        _Des = UCase(Trim(_Fila.Cells("DESCRIPCION").Value))

        Dim _Texto_Fm As String

        If _Cod = "ZZZ" Then
            _Texto_Fm = "DESDE " & UCase(_Informe.ToString) & ": TODAS"
        Else
            _Texto_Fm = "DESDE " & UCase(_Informe.ToString) & ": " & Trim(_Des)
        End If

        Dim Fl_Sucursales = _Fl_Sucursales
        Dim Fl_Bodegas = _Fl_Bodegas
        Dim Fl_Super_Familias = _Fl_Super_Familias
        Dim Fl_Entidades = _Fl_Entidades
        Dim Fl_Ciudades = _Fl_Ciudades
        Dim Fl_Comunas = _Fl_Comunas
        Dim Fl_Productos_Consolidados = _Fl_Productos_Consolidados
        Dim Fl_Funcionarios = _Fl_Funcionarios

        Select Case _Informe
            Case Enum_Informe.Sucursal
                Fl_Sucursales = Fx_Traer_Filtro("SULIDO") 'Fx_Traer_Filtro_Sucursales()
            Case Enum_Informe.Bodega
                Fl_Bodegas = Fx_Traer_Filtro("BOSULIDO") 'Fx_Traer_Filtro_Bodegas()
            Case Enum_Informe.Super_Familia
                Fl_Super_Familias = Fx_Traer_Filtro("FMPR") 'Fx_Traer_Filtro_Familias()
            Case Enum_Informe.Entidades
                Fl_Entidades = Fx_Traer_Filtro("ENDO+SUENDO")
            Case Enum_Informe.Ciudades
                Fl_Ciudades = Fx_Traer_Filtro("CIEN")
            Case Enum_Informe.Comunas
                Fl_Comunas = Fx_Traer_Filtro("CMEN")
            Case Enum_Informe.Productos_Consolidados
                Fl_Productos_Consolidados = Fx_Traer_Filtro("KOPRCT")
            Case Enum_Informe.Funcionarios
                Fl_Funcionarios = Fx_Traer_Filtro("KOFULIDO")
        End Select

        Dim _Filtro As String = Fl_Sucursales & vbCrLf &
                                Fl_Bodegas & vbCrLf &
                                Fl_Super_Familias & vbCrLf &
                                Fl_Entidades & vbCrLf &
                                Fl_Ciudades & vbCrLf &
                                Fl_Comunas & vbCrLf &
                                Fl_Productos_Consolidados & vbCrLf &
                                Fl_Funcionarios

        _Filtro += vbCrLf & Fx_Filtro_Detalle()

        Return _Filtro

    End Function



    Private Sub Sb_RowsPostPaint(sender As System.Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs)
        Try
            'Captura el numero de filas del datagridview
            Dim RowsNumber As String = (e.RowIndex + 1).ToString
            While RowsNumber.Length < sender.RowCount.ToString.Length
                RowsNumber = "0" & RowsNumber
            End While
            Dim size As SizeF = e.Graphics.MeasureString(RowsNumber, Me.Font)
            If sender.RowHeadersWidth < CInt(size.Width + 20) Then
                sender.RowHeadersWidth = CInt(size.Width + 20)
            End If
            Dim ob As Brush = SystemBrushes.ControlText
            e.Graphics.DrawString(RowsNumber, Me.Font, ob, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
        Catch ex As Exception
            MessageBox.Show(ex.Message, "vb.net",
         MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Sb_Grilla_Detalle_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    ShowContextMenu(Menu_Contextual_Informe)
                End If
            End With
        End If
    End Sub

    Private Sub Sb_Frm_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Informe_X_Bodega_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Informe_X_Bodega.Click
        Sb_Revisar_Sub_Informe(Enum_Informe.Bodega)
    End Sub

    Private Sub Btn_Informe_X_Super_Familia_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Informe_X_Super_Familia.Click
        Sb_Revisar_Sub_Informe(Enum_Informe.Super_Familia)
    End Sub

    Private Sub Btn_Informe_X_Entidades_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Informe_X_Entidades.Click
        Sb_Revisar_Sub_Informe(Enum_Informe.Entidades)
    End Sub

    Private Sub Btn_Informe_X_Ciudades_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Informe_X_Ciudades.Click
        Sb_Revisar_Sub_Informe(Enum_Informe.Ciudades)
    End Sub

    Private Sub Btn_Informe_X_Comunas_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Informe_X_Comunas.Click
        Sb_Revisar_Sub_Informe(Enum_Informe.Comunas)
    End Sub

    Private Sub Btn_Informe_X_Productos_Consolidados_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Informe_X_Productos_Consolidados.Click
        Sb_Revisar_Sub_Informe(Enum_Informe.Productos_Consolidados)
    End Sub

    Private Sub Btn_Informe_X_Funcionarios_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Informe_X_Funcionarios.Click
        Sb_Revisar_Sub_Informe(Enum_Informe.Funcionarios)
    End Sub

    Private Sub Btn_Filtrar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Filtrar.Click
        ShowContextMenu(Menu_Contextual_Filtros)
    End Sub

    Private Sub Btn_Cambiar_Fechas_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Cambiar_Fechas.Click

        Dim Fm As New Frm_Inf_Ventas_X_Periodos_Proyeccion_Ventas(_Nombre_Tabla_Paso)
        Fm.Pro_Fecha_01_Desde = _Fecha_Inicio_01
        Fm.Pro_Fecha_01_Hasta = _Fecha_Fin_01
        Fm.Pro_Fecha_02_Desde = _Fecha_Inicio_02
        Fm.Pro_Fecha_02_Hasta = _Fecha_Fin_02
        Fm.ShowDialog(Me)

        Dim _Aceptar As Boolean = Fm.Pro_Aceptar

        If _Aceptar Then
            _Fecha_Inicio_01 = Fm.Pro_Fecha_01_Desde
            _Fecha_Fin_01 = Fm.Pro_Fecha_01_Hasta
            _Fecha_Inicio_02 = Fm.Pro_Fecha_02_Desde
            _Fecha_Fin_02 = Fm.Pro_Fecha_02_Hasta
        End If

        Fm.Dispose()

        If _Aceptar Then
            Sb_Actualizar_Informe()
        End If

    End Sub

    Private Sub Btn_Filtro_Productos_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Filtro_Productos.Click
        Dim _Filtro_Extra_Productos = "And KOPR In (Select KOPRCT From " & _Nombre_Tabla_Paso & ")"
        Dim _Filtro_Extra_Clalibpr = "And KOCARAC In (Select CLALIBPR From " & _Nombre_Tabla_Paso & ")"
        Dim _Filtro_Extra_Marcas = "And KOMR In (Select MRPR From " & _Nombre_Tabla_Paso & ")"
        Dim _Filtro_Extra_Rubros = "And KORU In (Select RUPR From " & _Nombre_Tabla_Paso & ")"
        Dim _Filtro_Extra_Super_Familias_Todas = "And KOFM In (Select FMPR From " & _Nombre_Tabla_Paso & ")"
        Dim _Filtro_Extra_Zonas = "And KOZO In (Select ZOPR From " & _Nombre_Tabla_Paso & ")"

        Dim Fm As New Frm_Filtro_Especial_Productos

        Fm.Pro_Filtro_Productos_Todos = _Filtro_Productos_Todos
        Fm.Pro_Filtro_Clalibpr_Todas = _Filtro_Clalibpr_Todas
        Fm.Pro_Filtro_Marcas_Todas = _Filtro_Marcas_Todas
        Fm.Pro_Filtro_Rubro_Todas = _Filtro_Rubro_Productos_Todas
        Fm.Pro_Filtro_Super_Familias_Todas = _Filtro_Super_Familias_Todas
        Fm.Pro_Filtro_Zonas_Todas = _Filtro_Zonas_Productos_Todas

        Fm.Pro_Tbl_Filtro_Productos = _Tbl_Filtro_Productos
        Fm.Pro_Tbl_Filtro_Clalibpr = _Tbl_Filtro_Clalibpr
        Fm.Pro_Tbl_Filtro_Marcas = _Tbl_Filtro_Marcas
        Fm.Pro_Tbl_Filtro_Rubro = _Tbl_Filtro_Rubro_Productos
        Fm.Pro_Tbl_Filtro_Super_Familias = _Tbl_Filtro_Super_Familias
        Fm.Pro_Tbl_Filtro_Zonas = _Tbl_Filtro_Zonas_Productos

        Fm.Pro_Filtro_Extra_Productos = _Filtro_Extra_Productos
        Fm.Pro_Filtro_Extra_Clalibpr = _Filtro_Extra_Clalibpr
        Fm.Pro_Filtro_Extra_Marcas = _Filtro_Extra_Marcas
        Fm.Pro_Filtro_Extra_Rubro_Productos = _Filtro_Extra_Rubros
        Fm.Pro_Filtro_Extra_Super_Familias = _Filtro_Extra_Super_Familias_Todas
        Fm.Pro_Filtro_Extra_Zonas = _Filtro_Extra_Zonas

        Fm.ShowDialog(Me)

        If Fm.Pro_Aceptar Then

            _Filtro_Productos_Todos = Fm.Pro_Filtro_Productos_Todos
            _Filtro_Clalibpr_Todas = Fm.Pro_Filtro_Clalibpr_Todas
            _Filtro_Marcas_Todas = Fm.Pro_Filtro_Marcas_Todas
            _Filtro_Rubro_Productos_Todas = Fm.Pro_Filtro_Rubro_Todas
            _Filtro_Super_Familias_Todas = Fm.Pro_Filtro_Super_Familias_Todas
            _Filtro_Zonas_Productos_Todas = Fm.Pro_Filtro_Zonas_Todas

            _Tbl_Filtro_Productos = Fm.Pro_Tbl_Filtro_Productos
            _Tbl_Filtro_Clalibpr = Fm.Pro_Tbl_Filtro_Clalibpr
            _Tbl_Filtro_Marcas = Fm.Pro_Tbl_Filtro_Marcas
            _Tbl_Filtro_Rubro_Productos = Fm.Pro_Tbl_Filtro_Rubro
            _Tbl_Filtro_Super_Familias = Fm.Pro_Tbl_Filtro_Super_Familias
            _Tbl_Filtro_Zonas_Productos = Fm.Pro_Tbl_Filtro_Zonas

            Sb_Actualizar_Informe()

        End If

        Fm.Dispose()

    End Sub

    Private Sub Btn_Filtro_Entidades_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Filtro_Entidades.Click

        Dim _Filtro_Extra_Entidad = "And KOEN In (Select ENDO From " & _Nombre_Tabla_Paso & ")"
        Dim _Filtro_Extra_Ciudad = "And KOCI In (Select CIEN From " & _Nombre_Tabla_Paso & ")"
        Dim _Filtro_Extra_Comuna = "And KOCM In (Select CMEN From " & _Nombre_Tabla_Paso & ")"
        Dim _Filtro_Extra_Rubros = "And KORU In (Select RUEN From " & _Nombre_Tabla_Paso & ")"
        Dim _Filtro_Extra_Zonas = "And KOZO In (Select ZOEN From " & _Nombre_Tabla_Paso & ")"

        Dim Fm As New Frm_Filtro_Especial_Entidades

        Fm.Pro_Filtro_Entidad_Todas = _Filtro_Entidad_Todas
        Fm.Pro_Filtro_Ciudades_Todas = _Filtro_Ciudad_Todas
        Fm.Pro_Filtro_Comunas_Todas = _Filtro_Comunas_Todas
        Fm.Pro_Filtro_Rubro_Entidad_Todas = _Filtro_Rubro_Entidades_Todas
        Fm.Pro_Filtro_Zonas_Entidad_Todas = _Filtro_Zonas_Entidades_Todas

        Fm.Pro_Tbl_Filtro_Entidades = _Tbl_Filtro_Entidad
        Fm.Pro_Tbl_Filtro_Ciudad = _Tbl_Filtro_Ciudad
        Fm.Pro_Tbl_Filtro_Comuna = _Tbl_Filtro_Comunas
        Fm.Pro_Tbl_Filtro_Rubro_Entidad = _Tbl_Filtro_Rubro_Entidades
        Fm.Pro_Tbl_Filtro_Zonas_Entidad = _Tbl_Filtro_Zonas_Entidades

        Fm.Pro_Filtro_Extra_Entidad = _Filtro_Extra_Entidad
        Fm.Pro_Filtro_Extra_Ciudad = _Filtro_Extra_Ciudad
        Fm.Pro_Filtro_Extra_Comunas = _Filtro_Extra_Comuna
        Fm.Pro_Filtro_Extra_Rubro_Entidad = _Filtro_Extra_Rubros
        Fm.Pro_Filtro_Extra_Zonas_entidad = _Filtro_Extra_Zonas


        Fm.ShowDialog(Me)

        If Fm.Pro_Aceptar Then

            _Filtro_Entidad_Todas = Fm.Pro_Filtro_Entidad_Todas
            _Filtro_Ciudad_Todas = Fm.Pro_Filtro_Ciudades_Todas
            _Filtro_Comunas_Todas = Fm.Pro_Filtro_Comunas_Todas
            _Filtro_Rubro_Entidades_Todas = Fm.Pro_Filtro_Rubro_Entidad_Todas
            _Filtro_Zonas_Entidades_Todas = Fm.Pro_Filtro_Zonas_Entidad_Todas

            _Tbl_Filtro_Entidad = Fm.Pro_Tbl_Filtro_Entidades
            _Tbl_Filtro_Ciudad = Fm.Pro_Tbl_Filtro_Ciudad
            _Tbl_Filtro_Comunas = Fm.Pro_Tbl_Filtro_Comuna
            _Tbl_Filtro_Rubro_Entidades = Fm.Pro_Tbl_Filtro_Rubro_Entidad
            _Tbl_Filtro_Zonas_Entidades = Fm.Pro_Tbl_Filtro_Zonas_Entidad

            Sb_Actualizar_Informe()

        End If

        Fm.Dispose()

    End Sub

    Private Sub Btn_Filtro_Funcionarios_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Filtro_Funcionarios.Click
        Dim _Filtro_Extra_Responzales = "And KOFU In (Select KOFUDO From " & _Nombre_Tabla_Paso & ")"
        Dim _Filtro_Extra_Vendedores = "And KOFU In (Select KOFULIDO From " & _Nombre_Tabla_Paso & ")"

        Dim Fm As New Frm_Filtro_Especial_Funcionarios

        Fm.Pro_Filtro_Responzables_Todos = _Filtro_Responzables_Todas
        Fm.Pro_Filtro_Vendedores_Todos = _Filtro_Vendedores_Todas

        Fm.Pro_Tbl_Filtro_Responzables = _Tbl_Filtro_Responzables
        Fm.Pro_Tbl_Filtro_Vendedores = _Tbl_Filtro_Vendedores

        Fm.Pro_Filtro_Extra_Responzables = _Filtro_Extra_Responzales
        Fm.Pro_Filtro_Extra_Vendedores = _Filtro_Extra_Vendedores


        Fm.ShowDialog(Me)

        If Fm.Pro_Aceptar Then

            _Filtro_Responzables_Todas = Fm.Pro_Filtro_Responzables_Todos
            _Filtro_Vendedores_Todas = Fm.Pro_Filtro_Vendedores_Todos

            _Tbl_Filtro_Responzables = Fm.Pro_Tbl_Filtro_Responzables
            _Tbl_Filtro_Vendedores = Fm.Pro_Tbl_Filtro_Vendedores

            Sb_Actualizar_Informe()

        End If

        Fm.Dispose()
    End Sub

    Private Sub Btn_Graficar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Graficar.Click
        Dim Fm As New Frm_Inf_Ventas_X_Periodo_Graficos(_Nombre_Tabla_Paso, _Cp_Codigo, _Cp_Descripcion, "")
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub
End Class
