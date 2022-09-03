Imports DevComponents.DotNetBar
Imports System.Windows.Forms.DataVisualization.Charting

Public Class Frm_Inf_Ventas_X_Periodo_Graficos


    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Nombre_Tabla_Paso As String
    Dim _SqlFiltro As String

    Dim _SqlFiltro_Rango_01 As String
    Dim _SqlFiltro_Rango_02 As String

    Dim _Dias_Proyeccion As Integer

    Dim _Ds_Informes As DataSet
    Dim _Row_Totales As DataRow
    Dim _Tbl_Informe As DataTable
    Dim _Tbl_Informe_Actual As DataTable
    Dim _Tbl_DifClientes_R1_R2 As DataTable
    Dim _Tbl_DifProductos_R1_R2 As DataTable

    Dim _Cp_Codigo, _Cp_Descripcion As String
    Dim _Filtro_Sql As String

    Dim _Fl_Sucursales = String.Empty
    Dim _Fl_Bodegas = String.Empty
    Dim _Fl_Super_Familias = String.Empty
    Dim _Fl_Entidades = String.Empty
    Dim _Fl_Ciudades = String.Empty
    Dim _Fl_Comunas = String.Empty
    Dim _Fl_Productos_Consolidados = String.Empty
    Dim _Fl_Funcionarios = String.Empty

    Dim _Tbl_Filtro_Entidad As DataTable
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
    Dim _Tbl_Filtro_Clas_BakApp As DataTable ' Clasificaciones BakApp

    Dim _Filtro_Entidad_Todas As Boolean
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
    Dim _Filtro_Tipo_Entidad_Todas As Boolean
    Dim _Filtro_Act_Economica_Todas As Boolean
    Dim _Filtro_Tama_Empresa_Todas As Boolean
    Dim _Filtro_Clas_BakApp_Todas As Boolean ' Clasificaciones BakApp

    Dim _Total_Dias As Integer = 20
    Dim _Dias_Transcurridos As Integer = 1

    Dim _Tbl_Vista_Informe As DataTable
    Dim _Row_Vista As DataRow

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
    Public Property Pro_Tbl_Filtro_Vendedores_Asignados() As DataTable
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

    Dim _Fecha_Desde_Origen_R1 As Date
    Dim _Fecha_Desde_Origen_R2 As Date

    Public Sub New(Nombre_Tabla_Paso As String,
                   Cp_Codigo As String,
                   Cp_Descripcion As String,
                   Filtro_Sql As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Nombre_Tabla_Paso = Nombre_Tabla_Paso
        _Cp_Codigo = Cp_Codigo
        _Cp_Descripcion = Cp_Descripcion
        _Filtro_Sql = Filtro_Sql

        Dtp_Fecha_Desde_01.Value = Primerdiadelmes(FechaDelServidor)
        Dtp_Fecha_Hasta_01.Value = FechaDelServidor()

        Dtp_Fecha_Desde_02.Value = Dtp_Fecha_Desde_01.Value
        Dtp_Fecha_Hasta_02.Value = Dtp_Fecha_Hasta_01.Value

        _Fecha_Desde_Origen_R1 = Dtp_Fecha_Desde_01.Value
        _Fecha_Desde_Origen_R2 = Dtp_Fecha_Desde_02.Value

        '_Informe = Informe
        _Nombre_Tabla_Paso = Nombre_Tabla_Paso
        '_Unidad = Unidad
        '_Correr_a_la_derecha = Correr_a_la_derecha

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

        _Filtro_Vendedores_Todas = True


        If Fx_Tiene_Permiso(Me, "Inf00025", , True) Then
            _Filtro_Vendedores_Asignados_Todas = True
        Else
            Consulta_sql = "Select Cast(1 As Bit) As Chk,KOFU As Codigo, NOKOFU as Descripcion" & vbCrLf &
                           "From TABFU Where KOFU = '" & FUNCIONARIO & "'"
            '_Tbl_Filtro_Vendedores = _Sql.Fx_Get_Tablas(Consulta_sql)
            _Tbl_Filtro_Vendedores_Asignados = _Sql.Fx_Get_Tablas(Consulta_sql)
        End If

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

        Sb_Formato_Generico_Grilla(Grilla, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)

        Input_Dias_Feriado_R1.Value = 0
        Input_Dias_Feriado_R2.Value = 0

        Btn_Detalle_Rango_1.Visible = True
        Btn_Detalle_Rango_2.Visible = True

        Sb_Feriados_Rango_1()
        Sb_Feriados_Rango_2()
        Sb_Cargar_Combo_Vista_Informe()

        Sb_Formato_Graficos(Grafico_Comparativo, 0, 0)
        Sb_Formato_Graficos(Grafico_Media_R1, 0, 0)
        Sb_Formato_Graficos(Grafico_Media_R2, 0, 0)

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Inf_Ventas_X_Periodo_Graficos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        AddHandler Grilla.CellEnter, AddressOf Sb_Grilla_CellEnter
        AddHandler Grilla.ColumnHeaderMouseClick, AddressOf Sb_Grilla_ColumnHeaderMouseClick

        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_Detalle_MouseDown
        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla.CellDoubleClick, AddressOf Sb_Grilla_CellDoubleClick

        AddHandler Cmb_Vista_Informe.SelectedIndexChanged, AddressOf Sb_Cmb_Vista_Informe_SelectedIndexChanged

        Btn_Atras.Enabled = False
        Btn_Vista_Informe.Enabled = False

        Sb_Actualizar_Grilla()

    End Sub

    Function Fx_Filtro_Fecha(Fecha_Desde As Date, Fecha_Hasta As Date) As String

        Dim _Fecha_Entre As String

        Dim _F_Desde = Format(Fecha_Desde, "yyyMMdd")
        Dim _F_Hasta = Format(Fecha_Hasta, "yyyMMdd")

        _Fecha_Entre = "And FEEMLI BETWEEN '" & _F_Desde & "' And '" & _F_Hasta & "'" & vbCrLf

        Return _Fecha_Entre

    End Function

    'Sub Sb_Actualizar_Graficos()

    'Grafica_Mes_X_Ano.Series.Clear()
    'Grafico_Acumulado_X_Grupo.Series.Clear()
    'Grafico_Anual.Series.Clear()
    'Grafico_Lineal.Series.Clear()
    'Grafico_Pie.Series.Clear()

    'Sb_Generar_Grafica_Vista_Mensual()
    'Sb_Generar_Grafica_Acumulativo_Grupal_X_Fechas()
    'Sb_Generar_Grafica_Vista_Anual()
    'Sb_Generar_Grafica_Vista_Mens_X_Año()
    'Sb_Grafico_Pie_Acumulativo()
    'End Sub

    Sub Sb_Generar_Grafica_Vista_Mensual()


        Consulta_sql = "Select Distinct Ano From " & _Nombre_Tabla_Paso & vbCrLf &
                       "Select Distinct " & _Cp_Codigo & " AS CODIGO," & _Cp_Descripcion & " AS DESCRIPCION" & vbCrLf &
                       "From " & _Nombre_Tabla_Paso & vbCrLf &
                       "Where 1 > 0" & _Filtro_Sql

        Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

        Dim _Tbl_Anos = _Ds.Tables(0)
        Dim _Tbl_Datos = _Ds.Tables(1)

        Dim _Sql_Puntos_Cero = String.Empty


        For Each _Row_Datos As DataRow In _Tbl_Datos.Rows
            Dim _Codigo = _Row_Datos.Item("CODIGO")
            Dim _Descripcion = _Row_Datos.Item("DESCRIPCION")

            For Each _Row_Ano As DataRow In _Tbl_Anos.Rows
                Dim _Ano = _Row_Ano.Item("Ano")

                _Sql_Puntos_Cero += "Insert Into #Paso1 (CODIGO,DESCRIPCION,Mes_Ano,Mes,Ano,Orden,VANELI) Values" & Space(1) &
               "('" & _Codigo & "','" & _Descripcion & "','Enero." & _Ano & "','Enero','" & _Ano & "',1,0)" & vbCrLf &
                "Insert Into #Paso1 (CODIGO,DESCRIPCION,Mes_Ano,Mes,Ano,Orden,VANELI) Values" & Space(1) &
              "('" & _Codigo & "','" & _Descripcion & "','Febrero." & _Ano & "','Febrero','" & _Ano & "',2,0)" & vbCrLf &
                "Insert Into #Paso1 (CODIGO,DESCRIPCION,Mes_Ano,Mes,Ano,Orden,VANELI) Values" & Space(1) &
              "('" & _Codigo & "','" & _Descripcion & "','Marzo." & _Ano & "','Marzo','" & _Ano & "',3,0)" & vbCrLf &
                "Insert Into #Paso1 (CODIGO,DESCRIPCION,Mes_Ano,Mes,Ano,Orden,VANELI) Values" & Space(1) &
              "('" & _Codigo & "','" & _Descripcion & "','Abril." & _Ano & "','Abril','" & _Ano & "',4,0)" & vbCrLf &
                "Insert Into #Paso1 (CODIGO,DESCRIPCION,Mes_Ano,Mes,Ano,Orden,VANELI) Values" & Space(1) &
              "('" & _Codigo & "','" & _Descripcion & "','Mayo." & _Ano & "','Mayo','" & _Ano & "',5,0)" & vbCrLf &
                "Insert Into #Paso1 (CODIGO,DESCRIPCION,Mes_Ano,Mes,Ano,Orden,VANELI) Values" & Space(1) &
              "('" & _Codigo & "','" & _Descripcion & "','Junio." & _Ano & "','Junio','" & _Ano & "',6,0)" & vbCrLf &
                "Insert Into #Paso1 (CODIGO,DESCRIPCION,Mes_Ano,Mes,Ano,Orden,VANELI) Values" & Space(1) &
              "('" & _Codigo & "','" & _Descripcion & "','Julio." & _Ano & "','Julio','" & _Ano & "',7,0)" & vbCrLf &
                "Insert Into #Paso1 (CODIGO,DESCRIPCION,Mes_Ano,Mes,Ano,Orden,VANELI) Values" & Space(1) &
              "('" & _Codigo & "','" & _Descripcion & "','Agosto." & _Ano & "','Agosto','" & _Ano & "',8,0)" & vbCrLf &
                "Insert Into #Paso1 (CODIGO,DESCRIPCION,Mes_Ano,Mes,Ano,Orden,VANELI) Values" & Space(1) &
              "('" & _Codigo & "','" & _Descripcion & "','Septiembre." & _Ano & "','Septiembre','" & _Ano & "',9,0)" & vbCrLf &
                "Insert Into #Paso1 (CODIGO,DESCRIPCION,Mes_Ano,Mes,Ano,Orden,VANELI) Values" & Space(1) &
              "('" & _Codigo & "','" & _Descripcion & "','Octubre." & _Ano & "','Octubre','" & _Ano & "',10,0)" & vbCrLf &
                "Insert Into #Paso1 (CODIGO,DESCRIPCION,Mes_Ano,Mes,Ano,Orden,VANELI) Values" & Space(1) &
              "('" & _Codigo & "','" & _Descripcion & "','Noviembre." & _Ano & "','Noviembre','" & _Ano & "',11,0)" & vbCrLf &
                "Insert Into #Paso1 (CODIGO,DESCRIPCION,Mes_Ano,Mes,Ano,Orden,VANELI) Values" & Space(1) &
              "('" & _Codigo & "','" & _Descripcion & "','Diciembre." & _Ano & "','Diciembre','" & _Ano & "',12,0)" & vbCrLf

            Next

        Next

        '_Sql_Puntos_Cero = String.Empty

        Consulta_sql = My.Resources.Recursos_Inf_Ventas.Inf_Grafico_Dinamica_Ventas_Mensuales

        Consulta_sql = Replace(Consulta_sql, "#CODIGO#", _Cp_Codigo)
        Consulta_sql = Replace(Consulta_sql, "#DESCRIPCION#", _Cp_Descripcion)
        Consulta_sql = Replace(Consulta_sql, "#Tabla_Paso#", _Nombre_Tabla_Paso)
        Consulta_sql = Replace(Consulta_sql, "#Filtro_Sql#", _Filtro_Sql)
        Consulta_sql = Replace(Consulta_sql, "#Filtro_Fechas#", "")
        Consulta_sql = Replace(Consulta_sql, "#Sql_Puntos_Cero#", _Sql_Puntos_Cero)


        Dim _Sql_DReader As System.Data.SqlClient.SqlDataReader
        _Sql_DReader = _Sql.Fx_SqlDataReader(Consulta_sql)

        ' Data bind chart to a table where all rows are grouped in series by the "Name" column

        Dim Grafico_Lineal As Chart

        Grafico_Lineal.DataBindCrossTable(_Sql_DReader, "CODIGO", "Mes_Ano", "Total", "Label=Total{C0}")
        Grafico_Lineal.ChartAreas(0).AxisX.IsMarginVisible = True
        Grafico_Lineal.ChartAreas(0).AxisY.LabelStyle.Format = "C0"

        Grafico_Lineal.Legends("Default").BackColor = Color.White
        'Chart1.Legends("Default").BackSecondaryColor = Color.Green
        'Chart1.Legends("Default").BackGradientStyle = GradientStyle.DiagonalLeft

        Grafico_Lineal.Legends("Default").BorderColor = Color.Black
        Grafico_Lineal.Legends("Default").BorderWidth = 2
        Grafico_Lineal.Legends("Default").BorderDashStyle = ChartDashStyle.Solid
        'Sombra leyenda
        Grafico_Lineal.Legends("Default").ShadowOffset = 5

        ' Set series chart type
        'Chart1.Series("Series1").ChartType = DirectCast([Enum].Parse(GetType(SeriesChartType), _
        '                                                             comboBoxChartType.Text, True), SeriesChartType)

        ' Set series appearance
        Dim marker As MarkerStyle = MarkerStyle.Circle
        For Each ser As Series In Grafico_Lineal.Series

            ser.ShadowOffset = 1
            ser.BorderWidth = 3
            ser.ChartType = SeriesChartType.Line

            ser.MarkerSize = 5
            ser.MarkerStyle = marker
            ser.MarkerBorderColor = Color.FromArgb(64, 64, 64)
            ser.Font = New Font("Trebuchet MS", 8, FontStyle.Bold)
            ser.IsValueShownAsLabel = False

            For Each Punto In ser.Points
                Punto.Label = String.Empty
            Next

            ser.EmptyPointStyle.Color = Color.Red
            ser.EmptyPointStyle.BorderWidth = 0
            ser.EmptyPointStyle.BorderDashStyle = ChartDashStyle.Dash
            ser.EmptyPointStyle.MarkerSize = 14
            ser.EmptyPointStyle.MarkerStyle = MarkerStyle.None
            ser.EmptyPointStyle.MarkerBorderColor = Color.Black
            ser.EmptyPointStyle.MarkerColor = Color.Red

            'marker += 1
            'If marker > 9 Then
            'marker = MarkerStyle.Square
            'End If

        Next


        For i = 0 To Grafico_Lineal.Series.Count - 1
            Try
                Grafico_Lineal.Series(i)("EmptyPointValue") = "Zero" '"Average"
            Catch ex As Exception

            End Try
        Next

    End Sub

    Sub Sb_Actualizar_Grafico_Media(_F1_R1 As Date,
                                    _F2_R1 As Date,
                                    _Grafico As Chart,
                                    _R As Integer)

        Try


            Dim _Fila As DataGridViewRow

            Try
                _Fila = Grilla.Rows(Grilla.CurrentRow.Index)
            Catch ex As Exception
                _Fila = Grilla.Rows(0)
            End Try

            'Dim _F1_R1 As Date = Dtp_Fecha_Desde_01.Value
            'Dim _F2_R1 As Date = Dtp_Fecha_Hasta_01.Value
            'Dim _F1_R2 As Date = Dtp_Fecha_Desde_02.Value
            'Dim _F2_R2 As Date = Dtp_Fecha_Hasta_02.Value


            Dim _Codigo = _Fila.Cells("CODIGO").Value
            Dim _Descripcion = _Fila.Cells("DESCRIPCION").Value

            Dim _ARBOL_BAKAPP As Boolean = _Row_Vista.Item("ARBOL_BAKAPP")

            Dim _SqlFiltro_Rango = Fx_Filtro_Detalle(_F1_R1, _F2_R1)


            _Sql.Sb_Eliminar_Tabla_De_Paso("#Paso")

            'Dim F1 As Date = DateAdd("d", -365, Date.Now)
            _F1_R1 = Primerdiadelmes(_F1_R1)
            'Dim F2 As Date = Date.Now 'DateAdd("m", -1, Date.Now)

            Dim _FechaInicio As String = _F1_R1 'Format(ultimodiadelmes(DateAdd("d", -365, Date.Now)), "yyyyMMdd")
            Dim _FechaFin As String = _F2_R1 ' Format(Date.Now, "yyyyMMdd")

            Dim _Filtro_Nodos As String

            If _Filtro_Clas_BakApp_Todas Then
                _Filtro_Nodos = String.Empty
            Else
                _Filtro_Nodos = Generar_Filtro_IN(_Tbl_Filtro_Clas_BakApp, "Chk", "Codigo_Nodo", False, True, "")
                _Filtro_Nodos = "And KOPRCT In (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf &
                                "Where Codigo_Nodo In " & _Filtro_Nodos & ")"
            End If

            If _ARBOL_BAKAPP Then

                Consulta_sql = "Select '" & _Codigo & "' As CODIGO,'" & _Descripcion & "' As DESCRIPCION," &
                               "DATENAME(month,FEEMLI) as 'Mes_Palabra'," &
                               "DATEPART(week, FEEMLI) as 'Semana'," &
                               "MONTH(FEEMLI) as 'Mes'," &
                               "YEAR(FEEMLI) as 'Ano', SUM(CAPRCO1) As Cantidad,SUM(VANELI) as Total" & vbCrLf &
                               "Into #Paso" & vbCrLf &
                               "From " & _Nombre_Tabla_Paso & vbCrLf &
                               "Where 1 > 0" & vbCrLf &
                               "And KOPRCT In (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion" & Space(1) &
                               "Where Codigo_Nodo = " & _Codigo & ")" & vbCrLf &
                               _SqlFiltro_Rango & vbCrLf &
                               _Filtro_Nodos & vbCrLf &
                               "Group by FEEMLI" & vbCrLf & vbCrLf
            Else
                Consulta_sql = "Select " & _Cp_Codigo & " As CODIGO," & _Cp_Descripcion & " As DESCRIPCION," &
                               "DATENAME(month,FEEMLI) as 'Mes_Palabra'," &
                               "DATEPART(week, FEEMLI) as 'Semana'," &
                               "MONTH(FEEMLI) as 'Mes'," &
                               "YEAR(FEEMLI) as 'Ano', SUM(CAPRCO1) As Cantidad,SUM(VANELI) as Total" & vbCrLf &
                               "Into #Paso" & vbCrLf &
                               "From " & _Nombre_Tabla_Paso & vbCrLf &
                               "Where 1 > 0" & vbCrLf &
                               "And " & _Cp_Codigo & " = '" & _Codigo & "'" & vbCrLf &
                               _SqlFiltro_Rango & vbCrLf &
                               _Filtro_Nodos & vbCrLf &
                               "Group by " & _Cp_Codigo & "," & _Cp_Descripcion & ",FEEMLI" & vbCrLf & vbCrLf
            End If




            Dim Meses As Long = DateDiff(DateInterval.Month, _F1_R1, _F2_R1)

            Dim Meses_(Meses) As String
            Dim Fecha As Date = _F1_R1

            For Mes = 0 To Meses

                'Fecha = DateAdd(DateInterval.Month, 1, Fecha)

                Dim FechaNw As String = MonthName(Month(Fecha), True) & "-" & Fecha.Year
                Meses_(Mes) = FechaNw

                Dim FStr As String = Format(Primerdiadelmes(Fecha), "yyyyMMdd")

                Consulta_sql += "Insert Into #Paso (CODIGO,DESCRIPCION,Mes_Palabra,Semana,Mes,Ano,Cantidad,Total)" & vbCrLf &
                                "Values ('" & _Codigo & "','" & _Descripcion & "'," & vbCrLf &
                                "DATENAME(month,'" & FStr & "')," & vbCrLf &
                                "DATEPART(week, '" & FStr & "')," & vbCrLf &
                                "MONTH('" & FStr & "')," & vbCrLf &
                                "YEAR('" & FStr & "'),0,0)" & vbCrLf

                Fecha = DateAdd(DateInterval.Month, 1, Fecha)

            Next


            Consulta_sql += "Select Ltrim(Rtrim(substring(Mes_Palabra,1,3)))+'-'+Ltrim(Rtrim(STR(Ano))) as Periodo," & vbCrLf &
                            "Case When ROUND(SUM(Cantidad),2) = 0 then Null" & vbCrLf &
                            "Else ROUND(SUM(Cantidad),2) End as Cantidad," & vbCrLf &
                            "Case When ROUND(SUM(Total),2) = 0 then Null" & vbCrLf &
                            "Else ROUND(SUM(Total),2) End as Total" & vbCrLf &
                            "From #Paso" & vbCrLf &
                            "WHERE 1 > 0" & vbCrLf &
                            "GROUP BY Mes_Palabra,Ano,Mes" & vbCrLf &
                            "Order by Ano,Mes" &
                            vbCrLf &
                            vbCrLf &
                            "Select Ltrim(Rtrim(substring(Mes_Palabra,1,3)))+'-'+Ltrim(Rtrim(STR(Ano)))+'-'+Ltrim(Rtrim(STR(Semana))) as Periodo," & vbCrLf &
                            "Case When ROUND(SUM(Cantidad),2) = 0 then Null" & vbCrLf &
                            "Else ROUND(SUM(Cantidad),2) End as Cantidad," & vbCrLf &
                            "Case When ROUND(SUM(Total),2) = 0 then Null" & vbCrLf &
                            "Else ROUND(SUM(Total),2) End as Total" & vbCrLf &
                            "From #Paso" & vbCrLf &
                            "WHERE 1 > 0" & vbCrLf &
                            "GROUP BY Semana,Mes_Palabra,Ano" & vbCrLf &
                            "Order by Semana" & vbCrLf &
                            "Drop Table #Paso"
            Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

            Dim _Dias_Habiles_R1 = Fx_Cuenta_Dias(_F1_R1, _F2_R1, Opcion_Dias.Habiles) 'Fx_Dias_Habiles(_Fecha_Estudio_Desde, _Fecha_Estudio_Hasta)
            Dim _Dias_Sabado_R1 = Fx_Cuenta_Dias(_F1_R1, _F2_R1, Opcion_Dias.Sabado)
            Dim _Dias_Domingo_R1 = Fx_Cuenta_Dias(_F1_R1, _F2_R1, Opcion_Dias.Domingo)

            Dim _Dias_Promedio_R1 As Integer = _Dias_Habiles_R1

            If Chk_Sabado.Checked Then _Dias_Promedio_R1 += _Dias_Sabado_R1
            If Chk_Domingo.Checked Then _Dias_Promedio_R1 += _Dias_Domingo_R1


            Dim _Dias_Habiles_R2 '= Fx_Cuenta_Dias(_F1_R2, _F2_R2, Opcion_Dias.Habiles) 'Fx_Dias_Habiles(_Fecha_Estudio_Desde, _Fecha_Estudio_Hasta)
            Dim _Dias_Sabado_R2 '= Fx_Cuenta_Dias(_F1_R2, _F2_R2, Opcion_Dias.Sabado)
            Dim _Dias_Domingo_R2 '= Fx_Cuenta_Dias(_F1_R2, _F2_R2, Opcion_Dias.Domingo)

            Dim _Dias_Promedio_R2 As Integer = _Dias_Habiles_R2

            If Chk_Sabado.Checked Then _Dias_Promedio_R2 += _Dias_Sabado_R2
            If Chk_Domingo.Checked Then _Dias_Promedio_R2 += _Dias_Domingo_R2

            Dim _Serie = 0

            With _Grafico 'Grafico_Media_R1

                ' Set Grid lines and tick marks interval
                .Series(_Serie).XValueType = ChartValueType.Double

                ' Set X axis automatic fitting style
                .ChartAreas(_Serie).AxisX.LabelAutoFitStyle =
                 LabelAutoFitStyles.DecreaseFont 'ON LabelAutoFitStyle.DecreaseFont Or LabelAutoFitStyle.IncreaseFont Or LabelAutoFitStyle.WordWrap

                '
                .ChartAreas(_Serie).AxisX.Interval = 1
                .ChartAreas(_Serie).AxisY.Interval = 0
                .ChartAreas(_Serie).AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount

                .ChartAreas(_Serie).AxisX.MajorGrid.Interval = 0
                .ChartAreas(_Serie).AxisX.MajorTickMark.Interval = 1
                .ChartAreas(_Serie).AxisX.MinorGrid.Interval = 0.5
                .ChartAreas(_Serie).AxisX.MinorTickMark.Interval = 0.5
                .ChartAreas(_Serie).AxisX.IsMarginVisible = True
                ' Calculate Mean
                'Dim mean As Double = .DataManipulator.Statistics.Mean(_Serie)

                Dim _FirstView As New DataView(_Ds.Tables(0))

                .Series(_Serie).Points.DataBindXY(_FirstView, "Periodo", _FirstView, "Total")

                '.Series(_Serie).Points.DataBindXY(myReader, "Periodo", myReader, "Ud")


                '' Calculate Median
                ''Dim median As Double = .DataManipulator.Statistics.Median("Series1")
                '' Calculate Standard Deviation from the Variance
                ''Dim variance As Double = .DataManipulator.Statistics.Variance("Series1", True)
                ''Dim standardDeviation As Double = Math.Sqrt(variance)

                ' Calculate Median
                Dim _Median As Double '= .DataManipulator.Statistics.Median("Series1")
                ' Calculate Standard Deviation from the Variance
                Dim _Variance As Double '= .DataManipulator.Statistics.Variance("Series1", True)
                Dim _StandardDeviation As Double '= Math.Sqrt(variance)

                Try
                    _Median = .DataManipulator.Statistics.Median("Series1")
                    ' Calculate Standard Deviation from the Variance
                    _Variance = .DataManipulator.Statistics.Variance("Series1", True)
                    _StandardDeviation = Math.Sqrt(_Variance)
                Catch ex As Exception
                    _Median = _Fila.Cells("Total_R" & _R).Value
                    _StandardDeviation = 0
                End Try


                '// Set Strip line item
                .ChartAreas(0).AxisY.StripLines(0).IntervalOffset = _Median - Math.Sqrt(_Variance)
                .ChartAreas(0).AxisY.StripLines(0).StripWidth = 2.0 * Math.Sqrt(_Variance)


                .ChartAreas(0).AxisY.StripLines.Item(0).Text = String.Empty '"Desviación Estandar" ' & FormatNumber(_StandardDeviation, 3)
                .ChartAreas(0).AxisY.StripLines.Item(1).Text = String.Empty '"Mediana: " & FormatNumber(_Median, 0)
                .ChartAreas(0).AxisY.StripLines.Item(2).Text = "Mediana"

                '// Set Strip line item
                .ChartAreas(0).AxisY.StripLines(1).IntervalOffset = _Median

                '// Set Strip line item
                .ChartAreas(0).AxisY.StripLines(2).IntervalOffset = _Median
                .ChartAreas(0).AxisY.LabelStyle.Format = "C0"

                '.ChartAreas(0).
                .Titles("Titulo_Serie").Text = "Ventas Rango " & _R
                .Titles("Desviacion_Standar").Text = "Desviación Standar: " & FormatCurrency(_StandardDeviation, 0)
                .Titles("Media").Text = "Venta mediana: " & FormatCurrency(_Median, 0)


            End With

            Return




            Lbl_Dias_Habiles_R1.Text = FormatNumber(_Dias_Promedio_R1, 0)
            Lbl_Dias_Habiles_R2.Text = FormatNumber(_Dias_Promedio_R2, 0)

            Dim _Total_R1 As Double = NuloPorNro(_Fila.Cells("Total_R1").Value, 0)
            Dim _Total_R2 As Double = NuloPorNro(_Fila.Cells("Total_R2").Value, 0)

            Dim _Prom_Venta_diario_R1 As Double = _Total_R1 / _Dias_Promedio_R1
            Dim _Prom_Venta_diario_R2 As Double = _Total_R2 / _Dias_Promedio_R2

            Lbl_Prom_Vta_Diario_R1.Text = FormatCurrency(_Prom_Venta_diario_R1, 0)
            Lbl_Prom_Vta_Diario_R2.Text = FormatCurrency(_Prom_Venta_diario_R2, 0)

            Dim _Dias_R2_X_Prom_Vta_R1 As Double = _Dias_Habiles_R2 * _Prom_Venta_diario_R1
            Dim _Diferencia As Double = _Dias_R2_X_Prom_Vta_R1 - _Total_R2

            Lbl_Expectativa.Text = FormatCurrency(_Dias_R2_X_Prom_Vta_R1, 0)

            _Diferencia = _Diferencia * -1 'IIf(_Diferencia < 0, _Diferencia * -1, _Diferencia)

            Lbl_Diferencia.Text = FormatCurrency(_Diferencia, 0)


            Dim _Dif_Porc As Double

            Try
                _Dif_Porc = _Diferencia / _Dias_R2_X_Prom_Vta_R1
            Catch ex As Exception
                _Dif_Porc = 0
            End Try

            '_Dif_Porc = _Dif_Porc * -1 'IIf(_Dif_Porc < 0, _Dif_Porc * -1, _Dif_Porc)
            Lbl_Diferencia_Porc.Text = FormatPercent(_Dif_Porc, 2)


            If _Diferencia < 0 Then
                Lbl_Diferencia.ForeColor = Color.Red
                Lbl_Diferencia_Porc.ForeColor = Color.Red
            Else
                Lbl_Diferencia.ForeColor = Color.Green
                Lbl_Diferencia_Porc.ForeColor = Color.Green
            End If

            Lbl_Total_R1.Text = FormatNumber(_Total_R1, 0)
            Lbl_Total_R2.Text = FormatCurrency(_Total_R2, 0)
            Lbl_Realidad.Text = FormatCurrency(_Total_R2, 0)

            ' Initialize an array of doubles

            Dim _R1 As String = Math.Round(_Dias_R2_X_Prom_Vta_R1, 0)
            Dim _R2 As String = Math.Round(_Total_R2, 0)

            'If _R1 = 0 Then _R1 = Nothing
            'If _R2 = 0 Then _R2 = Nothing

            'Dim yval(1) As Double ' = {_R1, _R2}
            'Dim xval(1) As String ' = {"V.E.S.P.", "V. Real"}

            'yval(0) = _R1 '{_R1, _R2}
            'xval(0) = "V.E.S.P." '{"V.E.S.P.", "V. Real"}

            '' Bind the double array to the Y axis points of the Default data series
            'Grafico_Comparativo.Series(0).Points.DataBindXY(xval, yval)

            'yval(0) = _R2 '{_R1, _R2}
            'xval(0) = "V. Real"

            'Grafico_Comparativo.Series(1).Points.DataBindXY(xval, yval)

            'Grafico_Comparativo.ChartAreas(0).AxisY.LabelStyle.Format = "C0"


            'Grafico_Comparativo.Series(0)("EmptyPointValue") = "Zero" '"Average" 
            'Grafico_Comparativo.Series(1)("EmptyPointValue") = "Zero" '"Average" 

            'Dim Grafico_Lineal As Chart

            If _R1 = 0 Then _R1 = "Null"
            If _R2 = 0 Then _R2 = "Null"

            Consulta_sql = "Select 'Expectativa' As Codigo,'Diferencia' As Diferencia," & _R1 & " As Valor" & vbCrLf &
                           "Union" & vbCrLf &
                           "Select 'Realidad' As Codigo,'Diferencia' As Diferencia," & _R2 & " As Valor"


            Dim _Sql_DReader As System.Data.SqlClient.SqlDataReader
            _Sql_DReader = _Sql.Fx_SqlDataReader(Consulta_sql)

            Dim _R1v As Double = Math.Round(_Dias_R2_X_Prom_Vta_R1, 0)
            Dim _R2V As Double = Math.Round(_Total_R2, 0)

            Dim _Min, _Max As Double

            If _R1v < _R2V Then
                _Min = _R1v : _Max = _R2V
            Else
                _Min = _R2V : _Max = _R1v
            End If

            If _Min > 0 Then _Min = 0

            'Grafico_Comparativo.ChartAreas.

            Dim Grafico = Grafico_Comparativo 'Grafico_Acumulado_X_Grupo

            Grafico.ChartAreas(0).AxisY.Minimum = _Min '[Double].NaN
            Grafico.ChartAreas(0).AxisY.Maximum = _Max ' '[Double].NaN

            Grafico.ChartAreas(0).AxisY2.Minimum = _Min '[Double].NaN
            Grafico.ChartAreas(0).AxisY2.Maximum = _Max ' [Double].NaN

            Grafico.Series.Clear()

            Grafico.DataBindCrossTable(_Sql_DReader, "Codigo", "Diferencia", "Valor", "Label=Valor{C0}")

            Grafico.ChartAreas(0).Area3DStyle.Enable3D = False

            'Grafico.ChartAreas(0).AxisX.IsMarginVisible = True
            Grafico.ChartAreas(0).AxisY.LabelStyle.Format = "C0"


            'Grafico.Legends("Default").BackColor = Color.White
            'Grafico.Legends("Default").BorderColor = Color.Black
            'Grafico.Legends("Default").BorderWidth = 2
            'Grafico.Legends("Default").BorderDashStyle = ChartDashStyle.Solid

            'Sombra leyenda
            Grafico.Legends("Default").ShadowOffset = 0

            ' Set series appearance

            Dim marker As MarkerStyle = MarkerStyle.None

            For Each ser As Series In Grafico.Series

                ser.ShadowOffset = 1
                ser.BorderWidth = 3
                ser.ChartType = SeriesChartType.Column

                ser.MarkerSize = 5
                ser.MarkerStyle = marker
                ser.MarkerBorderColor = Color.FromArgb(64, 64, 64)
                ser.Font = New Font("Trebuchet MS", 8, FontStyle.Bold)
                ser.IsValueShownAsLabel = True

                For Each Punto In ser.Points
                    Punto.Label = String.Empty
                Next

                ser.EmptyPointStyle.Color = Color.Red
                ser.EmptyPointStyle.BorderWidth = 0
                ser.EmptyPointStyle.BorderDashStyle = ChartDashStyle.Dash
                ser.EmptyPointStyle.MarkerSize = 14
                ser.EmptyPointStyle.MarkerStyle = MarkerStyle.Cross
                ser.EmptyPointStyle.MarkerBorderColor = Color.Black
                ser.EmptyPointStyle.MarkerColor = Color.Red

                'marker += 1
                'If marker > 9 Then
                'marker = MarkerStyle.Square
                'End If

            Next


            For i = 0 To Grafico_Comparativo.Series.Count - 1
                Try
                    Grafico_Comparativo.Series(i)("EmptyPointValue") = "Zero" '"Average"
                Catch ex As Exception

                End Try
            Next

        Catch ex As Exception
            MessageBoxEx.Show(ex.Message)
        End Try

    End Sub

    Sub Sb_Actualizar_Grafico_Comparativo()

        Try

            'Dim _ARBOL_BAKAPP As Boolean = _Row_Vista.Item("ARBOL_BAKAPP")

            'If _ARBOL_BAKAPP Then Return


            Dim _Fila As DataGridViewRow

            Try
                _Fila = Grilla.Rows(Grilla.CurrentRow.Index)
            Catch ex As Exception
                _Fila = Grilla.Rows(0)
            End Try

            Dim _F1_R1 As Date = FormatDateTime(Dtp_Fecha_Desde_01.Value, DateFormat.ShortDate)
            Dim _F2_R1 As Date = FormatDateTime(Dtp_Fecha_Hasta_01.Value, DateFormat.ShortDate)
            Dim _F1_R2 As Date = FormatDateTime(Dtp_Fecha_Desde_02.Value, DateFormat.ShortDate)
            Dim _F2_R2 As Date = FormatDateTime(Dtp_Fecha_Hasta_02.Value, DateFormat.ShortDate)

            Dim _Dias_Habiles_R1 = Fx_Cuenta_Dias(_F1_R1, _F2_R1, Opcion_Dias.Habiles) 'Fx_Dias_Habiles(_Fecha_Estudio_Desde, _Fecha_Estudio_Hasta)
            Dim _Dias_Sabado_R1 = Fx_Cuenta_Dias(_F1_R1, _F2_R1, Opcion_Dias.Sabado)
            Dim _Dias_Domingo_R1 = Fx_Cuenta_Dias(_F1_R1, _F2_R1, Opcion_Dias.Domingo)

            Dim _Dias_Promedio_R1 As Integer = _Dias_Habiles_R1 - Input_Dias_Feriado_R1.Value

            If Chk_Sabado.Checked Then _Dias_Promedio_R1 += _Dias_Sabado_R1
            If Chk_Domingo.Checked Then _Dias_Promedio_R1 += _Dias_Domingo_R1


            Dim _Dias_Habiles_R2 = Fx_Cuenta_Dias(_F1_R2, _F2_R2, Opcion_Dias.Habiles) 'Fx_Dias_Habiles(_Fecha_Estudio_Desde, _Fecha_Estudio_Hasta)
            Dim _Dias_Sabado_R2 = Fx_Cuenta_Dias(_F1_R2, _F2_R2, Opcion_Dias.Sabado)
            Dim _Dias_Domingo_R2 = Fx_Cuenta_Dias(_F1_R2, _F2_R2, Opcion_Dias.Domingo)

            Dim _Dias_Promedio_R2 As Integer = _Dias_Habiles_R2 - Input_Dias_Feriado_R2.Value



            If Chk_Sabado.Checked Then _Dias_Promedio_R2 += _Dias_Sabado_R2
            If Chk_Domingo.Checked Then _Dias_Promedio_R2 += _Dias_Domingo_R2


            Lbl_Dias_Habiles_R1.Text = FormatNumber(_Dias_Promedio_R1, 0)
            Lbl_Dias_Habiles_R2.Text = FormatNumber(_Dias_Promedio_R2, 0)

            Dim _Total_R1 As Double = NuloPorNro(_Fila.Cells("Total_R1").Value, 0)
            Dim _Total_R2 As Double = NuloPorNro(_Fila.Cells("Total_R2").Value, 0)

            Dim _Prom_Venta_diario_R1 As Double = NuloPorNro(_Fila.Cells("Prom_Diario_R1").Value, 0) '_Total_R1 / _Dias_Promedio_R1
            Dim _Prom_Venta_diario_R2 As Double = NuloPorNro(_Fila.Cells("Prom_Diario_R2").Value, 0) '_Total_R2 / _Dias_Promedio_R2

            Lbl_Prom_Vta_Diario_R1.Text = FormatCurrency(_Prom_Venta_diario_R1, 0)
            Lbl_Prom_Vta_Diario_R2.Text = FormatCurrency(_Prom_Venta_diario_R2, 0)

            Dim _Expectativa As Double = NuloPorNro(_Fila.Cells("Expectativa").Value, 0) '_Dias_Habiles_R2 * _Prom_Venta_diario_R1
            Dim _Realidad As Double = NuloPorNro(_Fila.Cells("Realidad").Value, 0)
            Dim _Diferencia As Double = _Expectativa - _Total_R2

            Lbl_Expectativa.Text = FormatCurrency(_Expectativa, 0)

            _Diferencia = _Diferencia * -1 'IIf(_Diferencia < 0, _Diferencia * -1, _Diferencia)

            Lbl_Diferencia.Text = FormatCurrency(_Diferencia, 0)


            Lbl_Dias_Proyeccion.Text = _Dias_Proyeccion
            Dim _Proyeccion As Double = (_Dias_Proyeccion * _Prom_Venta_diario_R2) ' + _Total_R2
            Lbl_Proyeccion.Text = FormatCurrency(_Proyeccion, 0)

            Dim _Dif_Porc As Double

            Try
                _Dif_Porc = _Diferencia / _Expectativa
            Catch ex As Exception
                _Dif_Porc = 0
            End Try

            '_Dif_Porc = _Dif_Porc * -1 'IIf(_Dif_Porc < 0, _Dif_Porc * -1, _Dif_Porc)
            Lbl_Diferencia_Porc.Text = FormatPercent(_Dif_Porc, 2)


            If _Diferencia < 0 Then
                If Global_Thema = Enum_Themas.Oscuro Then
                    Lbl_Diferencia.ForeColor = Color.FromArgb(221, 79, 67)
                    Lbl_Diferencia_Porc.ForeColor = Color.FromArgb(221, 79, 67)
                Else
                    Lbl_Diferencia.ForeColor = Color.Red
                    Lbl_Diferencia_Porc.ForeColor = Color.Red
                End If
            Else
                Lbl_Diferencia.ForeColor = Color.Green
                Lbl_Diferencia_Porc.ForeColor = Color.Green
            End If

            Lbl_Total_R1.Text = FormatNumber(_Total_R1, 0)
            Lbl_Total_R2.Text = FormatCurrency(_Total_R2, 0)
            Lbl_Realidad.Text = FormatCurrency(_Total_R2, 0)

            ' Initialize an array of doubles

            Dim _R1 As String = Math.Round(_Expectativa, 0)
            Dim _R2 As String = Math.Round(_Realidad, 0)

            If _R1 = 0 Then _R1 = "Null"
            If _R2 = 0 Then _R2 = "Null"

            Consulta_sql = "Select 'Expectativa' As Codigo,'Comparación' As Comparacion," & _R1 & " As Valor" & vbCrLf &
                           "Union" & vbCrLf &
                           "Select 'Realidad' As Codigo,'Comparación' As Comparacion," & _R2 & " As Valor"


            Dim _Sql_DReader As System.Data.SqlClient.SqlDataReader
            _Sql_DReader = _Sql.Fx_SqlDataReader(Consulta_sql)

            Dim _R1v As Double = Math.Round(_Expectativa, 0)
            Dim _R2V As Double = Math.Round(_Realidad, 0)

            Dim _Min, _Max As Double

            If _R1v < _R2V Then
                _Min = _R1v : _Max = _R2V
            Else
                _Min = _R2V : _Max = _R1v
            End If

            If _Min > 0 Then _Min = 0

            If _Max = 0 Then
                _Max = 1
            End If

            'Grafico_Comparativo.ChartAreas.

            Dim Grafico = Grafico_Comparativo 'Grafico_Acumulado_X_Grupo

            Grafico.ChartAreas(0).AxisY.Minimum = _Min '[Double].NaN
            Grafico.ChartAreas(0).AxisY.Maximum = _Max ' '[Double].NaN

            Grafico.ChartAreas(0).AxisY2.Minimum = _Min '[Double].NaN
            Grafico.ChartAreas(0).AxisY2.Maximum = _Max ' [Double].NaN

            Grafico.Series.Clear()

            Grafico.DataBindCrossTable(_Sql_DReader, "Codigo", "Comparacion", "Valor", "Label=Valor{C0}")

            Grafico.ChartAreas(0).Area3DStyle.Enable3D = True

            'Grafico.ChartAreas(0).AxisX.IsMarginVisible = True
            Grafico.ChartAreas(0).AxisY.LabelStyle.Format = "C0"

            'Chart1.ChartAreas("Default").AxisY.LabelStyle.Format = "C0"

            'Grafico.Legends("Default").BackColor = Color.White
            'Grafico.Legends("Default").BorderColor = Color.Black
            'Grafico.Legends("Default").BorderWidth = 2
            'Grafico.Legends("Default").BorderDashStyle = ChartDashStyle.Solid
            ''Sombra leyenda
            'Grafico.Legends("Default").ShadowOffset = 5

            ' Set series chart type
            'Chart1.Series("Series1").ChartType = DirectCast([Enum].Parse(GetType(SeriesChartType), _
            '                                                             comboBoxChartType.Text, True), SeriesChartType)

            ' Set series appearance
            Dim marker As MarkerStyle = MarkerStyle.None

            For Each ser As Series In Grafico.Series

                ser.ShadowOffset = 1
                ser.BorderWidth = 3
                ser.ChartType = SeriesChartType.Column
                'ser("DrawingStyle") = "Cylinder"


                ser.MarkerSize = 5
                ser.MarkerStyle = marker
                ser.MarkerBorderColor = Color.FromArgb(64, 64, 64)
                ser.Font = New Font("Trebuchet MS", 8, FontStyle.Bold)
                ser.IsValueShownAsLabel = True

                For Each Punto In ser.Points
                    Punto.Label = String.Empty
                Next

                ser.EmptyPointStyle.Color = Color.Red
                ser.EmptyPointStyle.BorderWidth = 0
                ser.EmptyPointStyle.BorderDashStyle = ChartDashStyle.Dash
                ser.EmptyPointStyle.MarkerSize = 14
                ser.EmptyPointStyle.MarkerStyle = MarkerStyle.Cross
                ser.EmptyPointStyle.MarkerBorderColor = Color.Black
                ser.EmptyPointStyle.MarkerColor = Color.Red

                ser.LabelFormat = "C0"

                'marker += 1
                'If marker > 9 Then
                'marker = MarkerStyle.Square
                'End If

            Next

            For i = 0 To Grafico_Comparativo.Series.Count - 1
                Try
                    Grafico_Comparativo.Series(i)("EmptyPointValue") = "Zero" '"Average"
                Catch ex As Exception

                End Try
            Next

        Catch ex As Exception
            MessageBoxEx.Show(ex.Message)
        End Try

    End Sub


    Function Fx_Filtro_Detalle(_Fecha_Desde As Date,
                               _Fecha_Hasta As Date,
                               Optional _Incorporar_Filtro_Fecha As Boolean = True,
                               Optional _Incorporar_Filtro_Sucursales As Boolean = True,
                               Optional _Incorporar_Filtro_Bodega As Boolean = True,
                               Optional _Incorporar_Filtro_Entidades As Boolean = True,
                               Optional _Incorporar_Filtro_Ciudad As Boolean = True,
                               Optional _Incorporar_Filtro_Comuna As Boolean = True,
                               Optional _Incorporar_Filtro_Rubros_Ent As Boolean = True,
                               Optional _Incorporar_Filtro_Zonas_Ent As Boolean = True,
                               Optional _Incorporar_Filtro_Acti_Economica As Boolean = True,
                               Optional _Incorporar_Filtro_Tama_Empresa As Boolean = True,
                               Optional _Incorporar_Filtro_Tipo_Entidad As Boolean = True,
                               Optional _Incorporar_Filtro_Vendedores As Boolean = True,
                               Optional _Incorporar_Filtro_Vendedores_Asignados As Boolean = True,
                               Optional _Incorporar_Filtro_Responzables As Boolean = True,
                               Optional _Incorporar_Filtro_Productos As Boolean = True,
                               Optional _Incorporar_Filtro_Marcas As Boolean = True,
                               Optional _Incorporar_Filtro_Rubros_Pr As Boolean = True,
                               Optional _Incorporar_Filtro_Zonas_Pr As Boolean = True,
                               Optional _Incorporar_Filtro_SuperFamilias As Boolean = True,
                               Optional _Incorporar_Filtro_Familias As Boolean = True,
                               Optional _Incorporar_Filtro_Sub_Familias As Boolean = True,
                               Optional _Incorporar_Filtro_ClasLibre As Boolean = True)

        Dim _Filtro_Sucursales,
            _Filtro_Bodegas,
            _Filtro_Entidades,
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
            _Filtro_Marcas,
            _Filtro_Rubros_Pr,
            _Filtro_Zonas_Pr,
            _Filtro_SuperFamilias,
            _Filtro_Familias,
            _Filtro_Sub_Familias,
            _Filtro_ClasLibre As String

        If _Incorporar_Filtro_Sucursales Then
            If _Filtro_Sucursales_Todas Then
                _Filtro_Sucursales = String.Empty
            Else
                _Filtro_Sucursales = Generar_Filtro_IN(_Tbl_Filtro_Sucursales, "Chk", "Codigo", False, True, "'")
                _Filtro_Sucursales = "And SULIDO IN " & _Filtro_Sucursales & vbCrLf
            End If
        End If

        If _Incorporar_Filtro_Bodega Then
            If _Filtro_Bodegas_Todas Then
                _Filtro_Bodegas = String.Empty
            Else
                _Filtro_Bodegas = Generar_Filtro_IN(_Tbl_Filtro_Bodegas, "Chk", "Codigo", False, True, "'")
                _Filtro_Bodegas = "And EMPRESA+SULIDO+BOSULIDO IN " & _Filtro_Bodegas & vbCrLf
            End If
        End If


        If _Incorporar_Filtro_Entidades Then
            If _Filtro_Entidad_Todas Then
                _Filtro_Entidades = String.Empty
            Else
                _Filtro_Entidades = Generar_Filtro_IN(_Tbl_Filtro_Entidad, "Chk", "Codigo", False, True, "'")
                _Filtro_Entidades = "And ENDO IN " & _Filtro_Entidades & vbCrLf
            End If
        End If

        If _Incorporar_Filtro_Ciudad Then
            If _Filtro_Ciudad_Todas Then
                _Filtro_Ciudad = String.Empty
            Else
                _Filtro_Ciudad = Generar_Filtro_IN(_Tbl_Filtro_Ciudad, "Chk", "Codigo", False, True, "'")
                _Filtro_Ciudad = "And ENDO+SUENDO IN (Select KOEN+SUEN From MAEEN Where PAEN+CIEN In " & _Filtro_Ciudad & ")" & vbCrLf
                '_Filtro_Ciudad = "And PAEN+CIEN IN " & _Filtro_Ciudad & vbCrLf
            End If
        End If

        If _Incorporar_Filtro_Comuna Then
            If _Filtro_Comunas_Todas Then
                _Filtro_Comunas = String.Empty
            Else
                _Filtro_Comunas = Generar_Filtro_IN(_Tbl_Filtro_Comunas, "Chk", "Codigo", False, True, "'")
                _Filtro_Comunas = "And ENDO+SUENDO IN (Select KOEN+SUEN From MAEEN Where PAEN+CIEN+CMEN In " & _Filtro_Comunas & ")" & vbCrLf
                '_Filtro_Comunas = "And PAEN+CIEN+CMEN IN " & _Filtro_Comunas & vbCrLf
            End If
        End If

        If _Incorporar_Filtro_Rubros_Ent Then
            If _Filtro_Rubro_Entidades_Todas Then
                _Filtro_Rubros_En = String.Empty
            Else
                _Filtro_Rubros_En = Generar_Filtro_IN(_Tbl_Filtro_Rubro_Entidades, "Chk", "Codigo", False, True, "'")
                '_Filtro_Rubros_En = "And ENDO+SUENDO IN (Select KOEN+SUEN From MAEEN Where RUEN In " & _Filtro_Rubros_En & ")" & vbCrLf
                _Filtro_Rubros_En = "And RUEN IN " & _Filtro_Rubros_En & vbCrLf
            End If
        End If

        If _Incorporar_Filtro_Zonas_Ent Then
            If _Filtro_Zonas_Entidades_Todas Then
                _Filtro_Zonas_En = String.Empty
            Else
                _Filtro_Zonas_En = Generar_Filtro_IN(_Tbl_Filtro_Zonas_Entidades, "Chk", "Codigo", False, True, "'")
                '_Filtro_Zonas_En = "And ENDO+SUENDO IN (Select KOEN+SUEN From MAEEN Where ZOEN In " & _Filtro_Zonas_En & ")" & vbCrLf
                _Filtro_Zonas_En = "And ZOEN IN " & _Filtro_Zonas_En & vbCrLf
            End If
        End If

        If _Incorporar_Filtro_Acti_Economica Then
            If _Filtro_Act_Economica_Todas Then
                _Filtro_Acti_Economica = String.Empty
            Else
                _Filtro_Acti_Economica = Generar_Filtro_IN(_Tbl_Filtro_Act_Economica, "Chk", "Codigo", False, True, "'")
                '_Filtro_Acti_Economica = "And ACTIEN IN (Select ACTIEN From MAEEN Where ACTIEN In " & _Filtro_Acti_Economica & ")" & vbCrLf
                _Filtro_Acti_Economica = "And ACTIEN IN " & _Filtro_Acti_Economica & vbCrLf
            End If
        End If

        If _Incorporar_Filtro_Tama_Empresa Then
            If _Filtro_Tama_Empresa_Todas Then
                _Filtro_Tama_Empresa = String.Empty
            Else
                _Filtro_Tama_Empresa = Generar_Filtro_IN(_Tbl_Filtro_Tama_Empresa, "Chk", "Codigo", False, True, "'")
                '_Filtro_Tama_Empresa = "And TAMAEN IN (Select TAMAEN From MAEEN Where TAMAEN In " & _Filtro_Tama_Empresa & ")" & vbCrLf
                _Filtro_Tama_Empresa = "And TAMAEN IN " & _Filtro_Tama_Empresa & vbCrLf
            End If
        End If

        If _Incorporar_Filtro_Tipo_Entidad Then
            If _Filtro_Tipo_Entidad_Todas Then
                _Filtro_Tipo_Entidad = String.Empty
            Else
                _Filtro_Tipo_Entidad = Generar_Filtro_IN(_Tbl_Filtro_Tipo_Entidad, "Chk", "Codigo", False, True, "'")
                '_Filtro_Tipo_Entidad = "And TIPOEN IN (Select TIPOEN From MAEEN Where TIPOEN In " & _Filtro_Tipo_Entidad & ")" & vbCrLf
                _Filtro_Tipo_Entidad = "And TIPOEN IN " & _Filtro_Tipo_Entidad & vbCrLf
            End If
        End If

        If _Incorporar_Filtro_Responzables Then
            If _Filtro_Responzables_Todas Then
                _Filtro_Responzables = String.Empty
            Else
                _Filtro_Responzables = Generar_Filtro_IN(_Tbl_Filtro_Responzables, "Chk", "Codigo", False, True, "'")
                _Filtro_Responzables = "And KOFUDO IN " & _Filtro_Responzables & vbCrLf
            End If
        End If

        If _Incorporar_Filtro_Vendedores Then
            If _Filtro_Vendedores_Todas Then
                _Filtro_Vendedores = String.Empty
            Else
                _Filtro_Vendedores = Generar_Filtro_IN(_Tbl_Filtro_Vendedores, "Chk", "Codigo", False, True, "'")
                _Filtro_Vendedores = "And KOFULIDO IN " & _Filtro_Vendedores & vbCrLf
            End If
        End If

        If _Filtro_Vendedores_Asignados_Todas Then
            _Filtro_Vendedores_Asignados = String.Empty
        Else
            _Filtro_Vendedores_Asignados = Generar_Filtro_IN(_Tbl_Filtro_Vendedores_Asignados, "Chk", "Codigo", False, True, "'")
            _Filtro_Vendedores_Asignados = "And KOFUEN IN " & _Filtro_Vendedores_Asignados & vbCrLf
        End If

        If _Incorporar_Filtro_Productos Then
            If _Filtro_Productos_Todos Then
                _Filtro_Productos = String.Empty
            Else
                _Filtro_Productos = Generar_Filtro_IN(_Tbl_Filtro_Productos, "Chk", "Codigo", False, True, "'")
                _Filtro_Productos = "And KOPRCT IN " & _Filtro_Productos & vbCrLf
            End If
        End If

        If _Incorporar_Filtro_Rubros_Pr Then
            If _Filtro_Rubro_Productos_Todas Then
                _Filtro_Rubros_Pr = String.Empty
            Else
                _Filtro_Rubros_Pr = Generar_Filtro_IN(_Tbl_Filtro_Rubro_Productos, "Chk", "Codigo", False, True, "'")
                '_Filtro_Rubros_Pr = "And KOPRCT IN (Select KOPR From MAEPR Where RUPR In " & _Filtro_Rubros_Pr & ")" & vbCrLf
                _Filtro_Ciudad = "And RUEN IN " & _Filtro_Comunas & vbCrLf
            End If
        End If

        If _Incorporar_Filtro_Marcas Then
            If _Filtro_Marcas_Todas Then
                _Filtro_Marcas = String.Empty
            Else
                _Filtro_Marcas = Generar_Filtro_IN(_Tbl_Filtro_Marcas, "Chk", "Codigo", False, True, "'")
                _Filtro_Marcas = "And KOPRCT IN (Select KOPR From MAEPR Where MRPR In " & _Filtro_Marcas & ")" & vbCrLf
            End If
        End If

        If _Incorporar_Filtro_SuperFamilias Then
            If _Filtro_Super_Familias_Todas Then
                _Filtro_SuperFamilias = String.Empty
            Else
                _Filtro_SuperFamilias = Generar_Filtro_IN(_Tbl_Filtro_Super_Familias, "Chk", "Codigo", False, True, "'")
                _Filtro_SuperFamilias = "And KOPRCT IN (Select KOPR From MAEPR Where FMPR In " & _Filtro_SuperFamilias & ")" & vbCrLf
            End If
        End If

        If _Incorporar_Filtro_Familias Then
            If _Filtro_Familias_Todas Then
                _Filtro_Familias = String.Empty
            Else
                _Filtro_Familias = Generar_Filtro_IN(_Tbl_Filtro_Familias, "Chk", "Codigo", False, True, "'")
                _Filtro_Familias = "And KOPRCT IN (Select KOPR From MAEPR Where FMPR+PFPR In " & _Filtro_Familias & ")" & vbCrLf
            End If
        End If

        If _Incorporar_Filtro_Sub_Familias Then
            If _Filtro_Sub_Familias_Todas Then
                _Filtro_Sub_Familias = String.Empty
            Else
                _Filtro_Sub_Familias = Generar_Filtro_IN(_Tbl_Filtro_Sub_Familias, "Chk", "Codigo", False, True, "'")
                _Filtro_Sub_Familias = "And KOPRCT IN (Select KOPR From MAEPR Where FMPR+PFPR+HFPR In " & _Filtro_Sub_Familias & ")" & vbCrLf
            End If
        End If

        If _Incorporar_Filtro_ClasLibre Then
            If _Filtro_Clalibpr_Todas Then
                _Filtro_ClasLibre = String.Empty
            Else
                _Filtro_ClasLibre = Generar_Filtro_IN(_Tbl_Filtro_Clalibpr, "Chk", "Codigo", False, True, "'")
                _Filtro_ClasLibre = "And KOPRCT IN (Select KOPR From MAEPR Where CLALIBPR In " & _Filtro_ClasLibre & ")" & vbCrLf
            End If
        End If

        If _Incorporar_Filtro_Zonas_Pr Then
            If _Filtro_Zonas_Productos_Todas Then
                _Filtro_Zonas_Pr = String.Empty
            Else
                _Filtro_Zonas_Pr = Generar_Filtro_IN(_Tbl_Filtro_Zonas_Productos, "Chk", "Codigo", False, True, "'")
                _Filtro_Zonas_Pr = "And KOPRCT IN (Select KOPR From MAEPR Where ZONAPR In " & _Filtro_Zonas_Pr & ")" & vbCrLf
            End If
        End If
        '---------------------------


        Dim _SqlFiltro_Fechas As String

        If _Incorporar_Filtro_Fecha Then
            _SqlFiltro_Fechas = "And FEEMDO BETWEEN '" & Format(_Fecha_Desde, "yyyyMMdd") & "' AND '" &
                                 Format(_Fecha_Hasta, "yyyyMMdd") & "'" & vbCrLf
        End If

        Dim _Filtro_Externo = _Filtro_Sucursales &
                              _Filtro_Bodegas &
                              _Filtro_Entidades &
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
                              _Filtro_Rubros_Pr &
                              _Filtro_Marcas &
                              _Filtro_Zonas_Pr &
                              _Filtro_SuperFamilias &
                              _Filtro_Familias &
                              _Filtro_Sub_Familias &
                              _Filtro_ClasLibre &
                              _SqlFiltro_Fechas

        Return _Filtro_Externo

    End Function

    Sub Sb_Actualizar_Matriz_Cubo()
        Consulta_sql = My.Resources.Recursos_Inf_Ventas.Informe_Ventas_x_Perido_Nivel_Detalle_Cubo_Actualizacion
        Consulta_sql = Replace(Consulta_sql, "#Empresa#", ModEmpresa)
        Consulta_sql = Replace(Consulta_sql, "#Tabla_Paso#", _Nombre_Tabla_Paso)
        Consulta_sql = Replace(Consulta_sql, "#Fecha_Inicio#", Format(Dtp_Fecha_Desde_01.Value, "yyyyMMdd"))
        Consulta_sql = Replace(Consulta_sql, "#Fecha_Fin#", Format(Dtp_Fecha_Hasta_01.Value, "yyyyMMdd"))
        Consulta_sql = Replace(Consulta_sql, "#Filtro_Externo#", "")

        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            'MessageBox.Show(Me, "Actualización realizada correctamente", _
            '                "Actualizar Matriz de datos del cubo", _
            '                MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Sub Sb_Cargar_Combo_Vista_Informe()

        Consulta_sql = My.Resources.Recursos_Inf_Ventas.Cargar_Tabla_Vista_del_Cubo
        Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

        _Tbl_Vista_Informe = _Ds.Tables(0)

        Dim _Tbl = _Ds.Tables(3)

        caract_combo(Cmb_Vista_Informe)
        Cmb_Vista_Informe.DataSource = _Tbl
        Cmb_Vista_Informe.SelectedValue = "SULIDO"

        _Row_Vista = Fx_Crea_Tabla_Con_Filtro(_Tbl_Vista_Informe,
                                         "CODIGO = '" & Cmb_Vista_Informe.SelectedValue & "'", "Id").Rows(0)
        Sb_Actualizar_Grilla()

    End Sub

    Sub Sb_Actualizar_Grilla()


        Try

            If Dtp_Fecha_Desde_01.Value > Dtp_Fecha_Hasta_01.Value Or
                Dtp_Fecha_Desde_02.Value > Dtp_Fecha_Hasta_02.Value Then
                Throw New Exception("Error en Rango de fecha, La fecha desde no puede ser mayor a la fecha hasta")
            End If

            Me.Cursor = Cursors.WaitCursor
            Me.Enabled = False
            Me.Refresh()


            Dim _Unidad = 1

            _SqlFiltro_Rango_01 = Fx_Filtro_Detalle(Dtp_Fecha_Desde_01.Value, Dtp_Fecha_Hasta_01.Value)
            _SqlFiltro_Rango_02 = Fx_Filtro_Detalle(Dtp_Fecha_Desde_02.Value, Dtp_Fecha_Hasta_02.Value)


            _Cp_Codigo = _Row_Vista.Item("CODIGO")
            _Cp_Descripcion = _Row_Vista.Item("DESCRIPCION")


            Dim _ARBOL_BAKAPP As Boolean = _Row_Vista.Item("ARBOL_BAKAPP")

            Txt_Vista_Informe.Text = _Row_Vista.Item("DESCRIPCION_VISTA")

            Dim _Campo_Mostrar, _Cabecera_Mostrar, _Formato_Campo As String


            '_Cp_Codigo = _Row_Vista.Item("CODIGO")
            '_Cp_Descripcion = _Row_Vista.Item("DESCRIPCION")


            Dim _F1_R1 As Date = FormatDateTime(Dtp_Fecha_Desde_01.Value, DateFormat.ShortDate)
            Dim _F2_R1 As Date = FormatDateTime(Dtp_Fecha_Hasta_01.Value, DateFormat.ShortDate)

            Dim _F1_R2 As Date = FormatDateTime(Dtp_Fecha_Desde_02.Value, DateFormat.ShortDate)
            Dim _F2_R2 As Date = FormatDateTime(Dtp_Fecha_Hasta_02.Value, DateFormat.ShortDate)

            Dim _Meses_R1, _Meses_R2 As Integer

            Dim _Dias_Habiles_R1 = Fx_Cuenta_Dias(_F1_R1, _F2_R1, Opcion_Dias.Habiles) 'Fx_Dias_Habiles(_Fecha_Estudio_Desde, _Fecha_Estudio_Hasta)
            Dim _Dias_Sabado_R1 = Fx_Cuenta_Dias(_F1_R1, _F2_R1, Opcion_Dias.Sabado)
            Dim _Dias_Domingo_R1 = Fx_Cuenta_Dias(_F1_R1, _F2_R1, Opcion_Dias.Domingo)

            Dim _Dias_Promedio_R1 As Integer = _Dias_Habiles_R1 - Input_Dias_Feriado_R1.Value

            If Chk_Sabado.Checked Then _Dias_Promedio_R1 += _Dias_Sabado_R1
            If Chk_Domingo.Checked Then _Dias_Promedio_R1 += _Dias_Domingo_R1

            Dim _Dias_Habiles_R2 = Fx_Cuenta_Dias(_F1_R2, _F2_R2, Opcion_Dias.Habiles) 'Fx_Dias_Habiles(_Fecha_Estudio_Desde, _Fecha_Estudio_Hasta)
            Dim _Dias_Sabado_R2 = Fx_Cuenta_Dias(_F1_R2, _F2_R2, Opcion_Dias.Sabado)
            Dim _Dias_Domingo_R2 = Fx_Cuenta_Dias(_F1_R2, _F2_R2, Opcion_Dias.Domingo)

            Dim _Dias_Promedio_R2 As Integer = _Dias_Habiles_R2 - Input_Dias_Feriado_R2.Value

            If _Dias_Promedio_R1 = 0 Or _Dias_Promedio_R2 = 0 Then
                Throw New Exception("Los días a calcular no pueden ser cero" & vbCrLf &
                                    "Puede ser que este escogiendo un fin de semana y no haya marcado la el ticket considerar día sábado o domingo." & vbCrLf &
                                    "Puede ser que escogió la misma fecha entre desde y hasta, pero puso días feriados.")
            End If

            Dim _Fecha_Mayor As Date

            If Dtp_Fecha_Hasta_01.Value > Dtp_Fecha_Hasta_02.Value Then
                _Fecha_Mayor = FormatDateTime(Dtp_Fecha_Hasta_01.Value, DateFormat.ShortDate)
            Else
                _Fecha_Mayor = FormatDateTime(Dtp_Fecha_Hasta_02.Value, DateFormat.ShortDate)
            End If


            If Chk_Sabado.Checked Then _Dias_Promedio_R2 += _Dias_Sabado_R2
            If Chk_Domingo.Checked Then _Dias_Promedio_R2 += _Dias_Domingo_R2

            _Meses_R1 = DateDiff(DateInterval.Month, _F1_R1, _F2_R1) + 1
            _Meses_R2 = DateDiff(DateInterval.Month, _F1_R2, _F2_R2) + 1


            _Dias_Proyeccion = Fx_Cuenta_Dias(Primerdiadelmes(_F1_R2), ultimodiadelmes(_F2_R2), Opcion_Dias.Habiles) - Input_Dias_Feriado_R2.Value

            Dim _Filtro_Nodos As String

            If _Filtro_Clas_BakApp_Todas Then
                _Filtro_Nodos = String.Empty
            Else
                _Filtro_Nodos = Generar_Filtro_IN(_Tbl_Filtro_Clas_BakApp, "Chk", "Codigo_Nodo", False, True, "")
                _Filtro_Nodos = "And KOPRCT In (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf &
                                "Where Codigo_Nodo In " & _Filtro_Nodos & ")"
            End If

            If _ARBOL_BAKAPP Then

                Consulta_sql = My.Resources.Recursos_Inf_Ventas.Comparativo_de_Ventas_Arbol_Asociaciones

                Consulta_sql = Replace(Consulta_sql, "#Codigo_Nodo#", _Cp_Codigo)
                Consulta_sql = Replace(Consulta_sql, "#Zw_TblArbol_Asociaciones#", _Global_BaseBk & "Zw_TblArbol_Asociaciones")
                Consulta_sql = Replace(Consulta_sql, "#Zw_Prod_Asociacion#", _Global_BaseBk & "Zw_Prod_Asociacion")

                If _Cp_Codigo = "0" Then
                    Consulta_sql = Replace(Consulta_sql, "/*--Filtro_Sin_Clasificacion#", "")
                    Consulta_sql = Replace(Consulta_sql, "*/--Filtro_Sin_Clasificacion#", "")
                End If


            Else
                Consulta_sql = My.Resources.Recursos_Inf_Ventas.Comparativo_de_Ventas
            End If

            Dim _Ins_Sin_Asociacion_01 As String
            Dim _Ins_Sin_Asociacion_02 As String


            Dim _Chk_Mayor_Cero = String.Empty

            If Chk_Quitar_Valor_Cero.Checked Then
                _Chk_Mayor_Cero = "And (Total_R1 > 0 Or Total_R2 > 0)"
            End If

            Consulta_sql = Replace(Consulta_sql, "#Cp_Codigo#", _Cp_Codigo)
            Consulta_sql = Replace(Consulta_sql, "#Cp_Descripcion#", _Cp_Descripcion)
            Consulta_sql = Replace(Consulta_sql, "#Dias_R1#", _Dias_Promedio_R1)
            Consulta_sql = Replace(Consulta_sql, "#Dias_R2#", _Dias_Promedio_R2)
            Consulta_sql = Replace(Consulta_sql, "#Meses_R1#", _Meses_R1)
            Consulta_sql = Replace(Consulta_sql, "#Meses_R2#", _Meses_R2)
            Consulta_sql = Replace(Consulta_sql, "#Porc_R1#", "Porc_R1")
            Consulta_sql = Replace(Consulta_sql, "#Dias_Actuales#", 0)
            Consulta_sql = Replace(Consulta_sql, "#Dias_Total_Mes#", _Dias_Promedio_R2)
            Consulta_sql = Replace(Consulta_sql, "#Total_Meta#", 0)
            Consulta_sql = Replace(Consulta_sql, "#_SqlFiltro_Rango_01#", _SqlFiltro_Rango_01)
            Consulta_sql = Replace(Consulta_sql, "#_SqlFiltro_Rango_02#", _SqlFiltro_Rango_02)
            Consulta_sql = Replace(Consulta_sql, "#Total_Venta_RE#", "Total_R1")
            Consulta_sql = Replace(Consulta_sql, "#Prom_Diario_Escogido#", "Prom_Diario_R2")
            Consulta_sql = Replace(Consulta_sql, "#Tabla_Paso#", _Nombre_Tabla_Paso)
            Consulta_sql = Replace(Consulta_sql, "#_Filtro_Nodos#", _Filtro_Nodos)
            Consulta_sql = Replace(Consulta_sql, "#Chk_Mayor_Cero#", _Chk_Mayor_Cero)

            Dim _SqlFiltro_Fechas As String = "And FEEMDO BETWEEN '" & Format(Dtp_Fecha_Desde_01.Value, "yyyyMMdd") & "' AND '" &
                                            Format(Dtp_Fecha_Hasta_01.Value, "yyyyMMdd") & "'" & vbCrLf

            Consulta_sql = Replace(Consulta_sql, "#_SqlFiltro_Fecha_Rango_01#", _SqlFiltro_Fechas)


            Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

            _Tbl_Informe = _Ds.Tables(0) '_Sql.Fx_Get_Tablas(Consulta_sql)
            _Tbl_Informe_Actual = _Ds.Tables(4)
            _Tbl_DifClientes_R1_R2 = _Ds.Tables(5)
            _Tbl_DifProductos_R1_R2 = _Ds.Tables(6)

            Dim _Row_Totales As DataRow = _Ds.Tables(1).Rows(0)

            With Grilla

                .DataSource = _Tbl_Informe

                OcultarEncabezadoGrilla(Grilla)

                .Columns("CODIGO").Width = 100
                .Columns("CODIGO").HeaderText = "Cód."
                .Columns("CODIGO").Visible = True

                .Columns("DESCRIPCION").Width = 365 '340
                .Columns("DESCRIPCION").HeaderText = "Descripción"
                .Columns("DESCRIPCION").Visible = True

                If Cmb_Vista_Informe.SelectedValue = "ENDO+SUENDO" Then
                    .Columns("DESCRIPCION").Width = 365 - 35 '340
                    .Columns("VND").Width = 35
                    .Columns("VND").HeaderText = "Ven"
                    .Columns("VND").Visible = True
                Else
                    .Columns("VND").Visible = False
                End If

                '.Columns("Prom_Diario_R1").Width = 100 '110
                '.Columns("Prom_Diario_R1").HeaderText = "Prom. D. R1"
                '.Columns("Prom_Diario_R1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                '.Columns("Prom_Diario_R1").DefaultCellStyle.Format = "$ ###,##"
                '.Columns("Prom_Diario_R1").Visible = True

                '.Columns("Prom_Diario_R2").Width = 100 '110
                '.Columns("Prom_Diario_R2").HeaderText = "Prom. D. R2"
                '.Columns("Prom_Diario_R2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                '.Columns("Prom_Diario_R2").DefaultCellStyle.Format = "$ ###,##"
                '.Columns("Prom_Diario_R2").Visible = True


                '.Columns("Total_R1").Width = 100 '110
                '.Columns("Total_R1").HeaderText = "Total R1"
                '.Columns("Total_R1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                '.Columns("Total_R1").DefaultCellStyle.Format = "$ ###,##"
                '.Columns("Total_R1").Visible = True

                '.Columns("Total_R2").Width = 100
                '.Columns("Total_R2").HeaderText = "Total R2"
                '.Columns("Total_R2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                '.Columns("Total_R2").DefaultCellStyle.Format = "$ ###,##"
                '.Columns("Total_R2").Visible = True

                If Rdb_Ver_Valores.Checked Then

                    .Columns("Expectativa").Width = 100 '110
                    .Columns("Expectativa").HeaderText = "Prom. Vta R1"
                    .Columns("Expectativa").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns("Expectativa").DefaultCellStyle.Format = "$ ###,##"
                    .Columns("Expectativa").Visible = True

                    .Columns("Realidad").Width = 100 '110
                    .Columns("Realidad").HeaderText = "Prom. Vta R2"
                    .Columns("Realidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns("Realidad").DefaultCellStyle.Format = "$ ###,##"
                    .Columns("Realidad").Visible = True

                End If

                If Rdb_Ver_Cantidades.Checked Then

                    .Columns("ExpectativaCant").Width = 100 '110
                    .Columns("ExpectativaCant").HeaderText = "Prom. Cant R1"
                    .Columns("ExpectativaCant").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns("ExpectativaCant").DefaultCellStyle.Format = "###,##"
                    .Columns("ExpectativaCant").Visible = True

                    .Columns("RealidadCant").Width = 100 '110
                    .Columns("RealidadCant").HeaderText = "Prom. cant R2"
                    .Columns("RealidadCant").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns("RealidadCant").DefaultCellStyle.Format = "###,##"
                    .Columns("RealidadCant").Visible = True

                End If

            End With

            Sb_Marcar_Grilla()

            Sb_Imagenes_Filtros()

            Btn_Atras.Enabled = _ARBOL_BAKAPP

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Error al generar informe", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally

            Me.Cursor = Cursors.Default
            Me.Enabled = True
        End Try

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

        Sb_Actualizar_Grilla()

    End Sub

    Private Sub Sb_Grilla_CellEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

        Sb_Actualizar_Grafico_Media(FormatDateTime(Dtp_Fecha_Desde_01.Value, DateFormat.ShortDate),
                                    FormatDateTime(Dtp_Fecha_Hasta_01.Value, DateFormat.ShortDate), Grafico_Media_R1, 1)
        Sb_Actualizar_Grafico_Media(FormatDateTime(Dtp_Fecha_Desde_02.Value, DateFormat.ShortDate),
                                    FormatDateTime(Dtp_Fecha_Hasta_02.Value, DateFormat.ShortDate), Grafico_Media_R2, 2)
        Sb_Actualizar_Grafico_Comparativo()

        Sb_Formato_Graficos(Grafico_Comparativo, 0, 0)
        Sb_Formato_Graficos(Grafico_Comparativo, 0, 1)
        Sb_Formato_Graficos(Grafico_Media_R1, 0, 0)
        Sb_Formato_Graficos(Grafico_Media_R2, 0, 0)

    End Sub

    Private Sub Sb_Grilla_ColumnHeaderMouseClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        Sb_Marcar_Grilla()
    End Sub

    Sub Sb_Marcar_Grilla()

        For Each _Fila As DataGridViewRow In Grilla.Rows

            Dim _Expectativa = _Fila.Cells("Expectativa").Value
            Dim _Realidad = _Fila.Cells("Realidad").Value

            Dim _CampoRealidad = "Realidad"

            If Rdb_Ver_Cantidades.Checked Then
                _CampoRealidad = "RealidadCant"
            End If

            If _Expectativa > _Realidad Then
                If Global_Thema = Enum_Themas.Oscuro Then
                    _Fila.Cells(_CampoRealidad).Style.ForeColor = Color.FromArgb(221, 79, 67)
                Else
                    _Fila.Cells(_CampoRealidad).Style.ForeColor = Color.Red
                End If
            Else
                _Fila.Cells(_CampoRealidad).Style.ForeColor = Color.Green
            End If
        Next

    End Sub

    Private Sub Btn_Filtro_Pro_Productos_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Filtro_Pro_Productos.Click

        Dim _SqlFiltro_Fechas As String

        _SqlFiltro_Fechas = "Where FEEMLI BETWEEN '" & Format(Dtp_Fecha_Desde_01.Value, "yyyyMMdd") & "' AND '" &
                             Format(Dtp_Fecha_Hasta_02.Value, "yyyyMMdd") & "'" & vbCrLf

        Dim _Sql_Filtro_Condicion_Extra = "And KOPR In (Select Distinct KOPRCT From " &
                                          _Nombre_Tabla_Paso & vbCrLf & _SqlFiltro_Fechas & ")"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Productos,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Productos, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Productos_Todos, False) Then

            _Tbl_Filtro_Productos = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Productos_Todos = _Filtrar.Pro_Filtro_Todas

            Sb_Actualizar_Grilla()
        End If

    End Sub

    Private Sub Btn_Filtro_Pro_Super_Familias_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Filtro_Pro_Super_Familias.Click

        Dim _SqlFiltro_Fechas As String

        _SqlFiltro_Fechas = "Where FEEMLI BETWEEN '" & Format(Dtp_Fecha_Desde_01.Value, "yyyyMMdd") & "' AND '" &
                             Format(Dtp_Fecha_Hasta_02.Value, "yyyyMMdd") & "'" & vbCrLf

        Dim _Sql_Filtro_Condicion_Extra = "And KOFM In (Select Distinct FMPR From " &
                                          _Nombre_Tabla_Paso & vbCrLf & _SqlFiltro_Fechas & ")"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Super_Familias,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Tabla_Super_Familia, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Super_Familias_Todas) Then

            _Tbl_Filtro_Super_Familias = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Super_Familias_Todas = _Filtrar.Pro_Filtro_Todas

            If Cmb_Vista_Informe.SelectedValue = "FMPR" Then
                Sb_Actualizar_Grilla()
            Else
                Cmb_Vista_Informe.SelectedValue = "FMPR"
            End If

        End If

    End Sub

    Private Sub Btn_Filtro_Pro_Familias_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Filtro_Pro_Familias.Click

        Dim _SqlFiltro_Fechas As String

        _SqlFiltro_Fechas = "Where FEEMLI BETWEEN '" & Format(Dtp_Fecha_Desde_01.Value, "yyyyMMdd") & "' AND '" &
                             Format(Dtp_Fecha_Hasta_02.Value, "yyyyMMdd") & "'" & vbCrLf

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
                Sb_Actualizar_Grilla()
            Else
                Cmb_Vista_Informe.SelectedValue = "PFPR"
            End If
        End If

    End Sub

    Private Sub Btn_Filtro_Pro_Sub_Familias_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Filtro_Pro_Sub_Familias.Click

        Dim _SqlFiltro_Fechas As String

        _SqlFiltro_Fechas = "Where FEEMLI BETWEEN '" & Format(Dtp_Fecha_Desde_01.Value, "yyyyMMdd") & "' AND '" &
                              Format(Dtp_Fecha_Hasta_02.Value, "yyyyMMdd") & "'" & vbCrLf


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
                Sb_Actualizar_Grilla()
            Else
                Cmb_Vista_Informe.SelectedValue = "HFPR"
            End If

        End If

    End Sub

    Private Sub Btn_Filtro_Pro_Marcas_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Filtro_Pro_Marcas.Click
        Dim _SqlFiltro_Fechas As String

        _SqlFiltro_Fechas = "Where FEEMLI BETWEEN '" & Format(Dtp_Fecha_Desde_01.Value, "yyyyMMdd") & "' AND '" &
                             Format(Dtp_Fecha_Hasta_02.Value, "yyyyMMdd") & "'" & vbCrLf

        Dim _Sql_Filtro_Condicion_Extra = "And KOMR In (Select Distinct MRPR From " &
                                          _Nombre_Tabla_Paso & vbCrLf & _SqlFiltro_Fechas & ")"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Marcas,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Tabla_Marcas, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Marcas_Todas) Then

            _Tbl_Filtro_Marcas = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Marcas_Todas = _Filtrar.Pro_Filtro_Todas

            If Cmb_Vista_Informe.SelectedValue = "MRPR" Then
                Sb_Actualizar_Grilla()
            Else
                Cmb_Vista_Informe.SelectedValue = "MRPR"
            End If

        End If
    End Sub

    Private Sub Btn_Filtro_Pro_Clas_Libre_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Filtro_Pro_Clas_Libre.Click
        Dim _SqlFiltro_Fechas As String

        _SqlFiltro_Fechas = "Where FEEMLI BETWEEN '" & Format(Dtp_Fecha_Desde_01.Value, "yyyyMMdd") & "' AND '" &
                            Format(Dtp_Fecha_Hasta_02.Value, "yyyyMMdd") & "'" & vbCrLf

        Dim _Sql_Filtro_Condicion_Extra = "And KOTABLA = 'CLALIBPR' And KOCARAC In (Select Distinct CLALIBPR From " &
                                          _Nombre_Tabla_Paso & vbCrLf & _SqlFiltro_Fechas & ")"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Clalibpr,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Tabla_Tabcarac, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Clalibpr_Todas) Then

            _Tbl_Filtro_Clalibpr = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Clalibpr_Todas = _Filtrar.Pro_Filtro_Todas

            If Cmb_Vista_Informe.SelectedValue = "CLALIBPR" Then
                Sb_Actualizar_Grilla()
            Else
                Cmb_Vista_Informe.SelectedValue = "CLALIBPR"
            End If

        End If
    End Sub

    Private Sub Btn_Filtro_Pro_Rubros_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Filtro_Pro_Rubros.Click
        Dim _SqlFiltro_Fechas As String

        _SqlFiltro_Fechas = "Where FEEMLI BETWEEN '" & Format(Dtp_Fecha_Desde_01.Value, "yyyyMMdd") & "' AND '" &
                            Format(Dtp_Fecha_Hasta_02.Value, "yyyyMMdd") & "'" & vbCrLf

        Dim _Sql_Filtro_Condicion_Extra = "And KORU In (Select Distinct RUPR From " &
                                          _Nombre_Tabla_Paso & vbCrLf & _SqlFiltro_Fechas & ")"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Rubro_Productos,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Tabla_Rubros, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Rubro_Productos_Todas, True) Then

            _Tbl_Filtro_Rubro_Productos = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Rubro_Productos_Todas = _Filtrar.Pro_Filtro_Todas

            If Cmb_Vista_Informe.SelectedValue = "RUPR" Then
                Sb_Actualizar_Grilla()
            Else
                Cmb_Vista_Informe.SelectedValue = "RUPR"
            End If

        End If
    End Sub

    Private Sub Btn_Filtro_Pro_Zonas_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Filtro_Pro_Zonas.Click
        Dim _SqlFiltro_Fechas As String

        _SqlFiltro_Fechas = "Where FEEMLI BETWEEN '" & Format(Dtp_Fecha_Desde_01.Value, "yyyyMMdd") & "' AND '" &
                            Format(Dtp_Fecha_Hasta_02.Value, "yyyyMMdd") & "'" & vbCrLf

        Dim _Sql_Filtro_Condicion_Extra = "And KOZO In (Select Distinct ZOPR From " &
                                          _Nombre_Tabla_Paso & vbCrLf & _SqlFiltro_Fechas & ")"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Zonas_Productos,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Tabla_Zonas, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Zonas_Productos_Todas, True) Then

            _Tbl_Filtro_Zonas_Productos = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Zonas_Productos_Todas = _Filtrar.Pro_Filtro_Todas

            If Cmb_Vista_Informe.SelectedValue = "ZOPR" Then
                Sb_Actualizar_Grilla()
            Else
                Cmb_Vista_Informe.SelectedValue = "ZOPR"
            End If

        End If
    End Sub

    Private Sub Btn_Filtro_Ent_Entidades_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Filtro_Ent_Entidades.Click

        Dim _SqlFiltro_Fechas As String

        _SqlFiltro_Fechas = "Where FEEMLI BETWEEN '" & Format(Dtp_Fecha_Desde_01.Value, "yyyyMMdd") & "' AND '" &
                            Format(Dtp_Fecha_Hasta_02.Value, "yyyyMMdd") & "'" & Space(1)

        Dim _SqlFiltro_Extra = Fx_Filtro_Detalle(Nothing, Nothing, False, , , False)

        Dim _Sql_Filtro_Condicion_Extra = "And KOEN+SUEN In (Select Distinct ENDO+SUENDO From " &
                                         _Nombre_Tabla_Paso & vbCrLf & _SqlFiltro_Fechas & _SqlFiltro_Extra & ")"


        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Entidad,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Entidades, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Entidad_Todas, False) Then

            _Tbl_Filtro_Entidad = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Entidad_Todas = _Filtrar.Pro_Filtro_Todas

            If Cmb_Vista_Informe.SelectedValue = "ENDO+SUENDO" Then
                Sb_Actualizar_Grilla()
            Else
                Cmb_Vista_Informe.SelectedValue = "ENDO+SUENDO"
            End If

        End If

    End Sub

    Private Sub Btn_Filtro_Ent_Ciudades_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Filtro_Ent_Ciudades.Click
        Dim _SqlFiltro_Fechas As String

        _SqlFiltro_Fechas = "Where FEEMLI BETWEEN '" & Format(Dtp_Fecha_Desde_01.Value, "yyyyMMdd") & "' AND '" &
                            Format(Dtp_Fecha_Hasta_02.Value, "yyyyMMdd") & "'" & vbCrLf

        Dim _SqlFiltro_Extra = Fx_Filtro_Detalle(Nothing, Nothing, False, , , , False)

        Dim _Sql_Filtro_Condicion_Extra = "And KOCI In (Select Distinct CIEN From" & Space(1) &
                                         _Nombre_Tabla_Paso & vbCrLf & _SqlFiltro_Fechas & _SqlFiltro_Extra & ")"


        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Ciudad,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Ciudades, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Ciudad_Todas, False) Then

            _Tbl_Filtro_Ciudad = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Ciudad_Todas = _Filtrar.Pro_Filtro_Todas

            If Cmb_Vista_Informe.SelectedValue = "CIEN" Then
                Sb_Actualizar_Grilla()
            Else
                Cmb_Vista_Informe.SelectedValue = "CIEN"
            End If

        End If
    End Sub

    Private Sub Btn_Filtro_Ent_Comunas_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Filtro_Ent_Comunas.Click
        Dim _SqlFiltro_Fechas As String

        _SqlFiltro_Fechas = "Where FEEMLI BETWEEN '" & Format(Dtp_Fecha_Desde_01.Value, "yyyyMMdd") & "' AND '" &
                            Format(Dtp_Fecha_Hasta_02.Value, "yyyyMMdd") & "'" & vbCrLf

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

            If Cmb_Vista_Informe.SelectedValue = "CIEN+CMEN" Then
                Sb_Actualizar_Grilla()
            Else
                Cmb_Vista_Informe.SelectedValue = "CIEN+CMEN"
            End If

        End If
    End Sub

    Private Sub Btn_Filtro_Ent_Rubros_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Filtro_Ent_Rubros.Click
        Dim _SqlFiltro_Fechas As String

        _SqlFiltro_Fechas = "Where FEEMLI BETWEEN '" & Format(Dtp_Fecha_Desde_01.Value, "yyyyMMdd") & "' AND '" &
                            Format(Dtp_Fecha_Hasta_02.Value, "yyyyMMdd") & "'" & vbCrLf

        Dim _Sql_Filtro_Condicion_Extra = "And KORU In (Select Distinct RUEN From " &
                                          _Nombre_Tabla_Paso & vbCrLf & _SqlFiltro_Fechas & ")"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Rubro_Entidades,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Tabla_Rubros, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Rubro_Entidades_Todas, True) Then

            _Tbl_Filtro_Rubro_Entidades = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Rubro_Entidades_Todas = _Filtrar.Pro_Filtro_Todas

            If Cmb_Vista_Informe.SelectedValue = "RUEN" Then
                Sb_Actualizar_Grilla()
            Else
                Cmb_Vista_Informe.SelectedValue = "RUEN"
            End If

        End If
    End Sub

    Private Sub Btn_Filtro_Ent_Zonas_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Filtro_Ent_Zonas.Click
        Dim _SqlFiltro_Fechas As String

        _SqlFiltro_Fechas = "Where FEEMLI BETWEEN '" & Format(Dtp_Fecha_Desde_01.Value, "yyyyMMdd") & "' AND '" &
                            Format(Dtp_Fecha_Hasta_02.Value, "yyyyMMdd") & "'" & vbCrLf

        Dim _Sql_Filtro_Condicion_Extra = "And KOZO In (Select Distinct ZOEN From " &
                                          _Nombre_Tabla_Paso & vbCrLf & _SqlFiltro_Fechas & ")"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Zonas_Entidades,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Tabla_Zonas, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Zonas_Entidades_Todas, True) Then

            _Tbl_Filtro_Zonas_Entidades = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Zonas_Entidades_Todas = _Filtrar.Pro_Filtro_Todas

            If Cmb_Vista_Informe.SelectedValue = "ZOEN" Then
                Sb_Actualizar_Grilla()
            Else
                Cmb_Vista_Informe.SelectedValue = "ZOEN"
            End If

        End If
    End Sub

    Private Sub Btn_Filtro_Ent_Tipo_Entidad_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Filtro_Ent_Tipo_Entidad.Click
        Dim _SqlFiltro_Fechas As String

        _SqlFiltro_Fechas = "Where FEEMLI BETWEEN '" & Format(Dtp_Fecha_Desde_01.Value, "yyyyMMdd") & "' AND '" &
                            Format(Dtp_Fecha_Hasta_02.Value, "yyyyMMdd") & "'" & vbCrLf

        Dim _Sql_Filtro_Condicion_Extra = "And KOTABLA = 'TIPOENTIDA' And KOCARAC In (Select Distinct TIPOEN From " &
                                          _Nombre_Tabla_Paso & vbCrLf & _SqlFiltro_Fechas & ")"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Tipo_Entidad,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Tabla_Tabcarac, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Tipo_Entidad_Todas) Then

            _Tbl_Filtro_Tipo_Entidad = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Tipo_Entidad_Todas = _Filtrar.Pro_Filtro_Todas

            If Cmb_Vista_Informe.SelectedValue = "TIPOEN" Then
                Sb_Actualizar_Grilla()
            Else
                Cmb_Vista_Informe.SelectedValue = "TIPOEN"
            End If

        End If
    End Sub

    Private Sub Btn_Filtro_Ent_Act_Economica_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Filtro_Ent_Act_Economica.Click
        Dim _SqlFiltro_Fechas As String

        _SqlFiltro_Fechas = "Where FEEMLI BETWEEN '" & Format(Dtp_Fecha_Desde_01.Value, "yyyyMMdd") & "' AND '" &
                            Format(Dtp_Fecha_Hasta_02.Value, "yyyyMMdd") & "'" & vbCrLf

        Dim _Sql_Filtro_Condicion_Extra = "And KOTABLA = 'ACTIVIDADE' And KOCARAC In (Select Distinct ACTIEN From " &
                                          _Nombre_Tabla_Paso & vbCrLf & _SqlFiltro_Fechas & ")"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Act_Economica,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Tabla_Tabcarac, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Act_Economica_Todas) Then

            _Tbl_Filtro_Act_Economica = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Act_Economica_Todas = _Filtrar.Pro_Filtro_Todas

            If Cmb_Vista_Informe.SelectedValue = "ACTIEN" Then
                Sb_Actualizar_Grilla()
            Else
                Cmb_Vista_Informe.SelectedValue = "ACTIEN"
            End If

        End If
    End Sub

    Private Sub Btn_Filtro_Ent_Tamano_Empresa_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Filtro_Ent_Tamano_Empresa.Click
        Dim _SqlFiltro_Fechas As String

        _SqlFiltro_Fechas = "Where FEEMLI BETWEEN '" & Format(Dtp_Fecha_Desde_01.Value, "yyyyMMdd") & "' AND '" &
                            Format(Dtp_Fecha_Hasta_02.Value, "yyyyMMdd") & "'" & vbCrLf

        Dim _Sql_Filtro_Condicion_Extra = "And KOTABLA = 'TAMA¥OEMPR' And KOCARAC In (Select Distinct TAMAEN From " &
                                          _Nombre_Tabla_Paso & vbCrLf & _SqlFiltro_Fechas & ")"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Tama_Empresa,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Tabla_Tabcarac, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Tama_Empresa_Todas) Then

            _Tbl_Filtro_Tama_Empresa = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Tama_Empresa_Todas = _Filtrar.Pro_Filtro_Todas

            If Cmb_Vista_Informe.SelectedValue = "TAMAEN" Then
                Sb_Actualizar_Grilla()
            Else
                Cmb_Vista_Informe.SelectedValue = "TAMAEN"
            End If

        End If
    End Sub

    Private Sub Btn_Filtro_Responzables_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Filtro_Responzables.Click
        Dim _SqlFiltro_Fechas As String

        _SqlFiltro_Fechas = "Where FEEMLI BETWEEN '" & Format(Dtp_Fecha_Desde_01.Value, "yyyyMMdd") & "' AND '" &
                            Format(Dtp_Fecha_Hasta_02.Value, "yyyyMMdd") & "'" & vbCrLf

        Dim _Sql_Filtro_Condicion_Extra = "And KOFU In (Select Distinct KOFUDO From " &
                                          _Nombre_Tabla_Paso & vbCrLf & _SqlFiltro_Fechas & ")"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Responzables,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Funcionarios_Random, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Responzables_Todas, False) Then

            _Tbl_Filtro_Responzables = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Responzables_Todas = _Filtrar.Pro_Filtro_Todas

            If Cmb_Vista_Informe.SelectedValue = "KOFUEN" Then
                Sb_Actualizar_Grilla()
            Else
                Cmb_Vista_Informe.SelectedValue = "KOFUEN"
            End If

        End If
    End Sub

    Private Sub Btn_Filtro_Vendedores_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Filtro_Vendedores.Click
        If Fx_Tiene_Permiso(Me, "Inf00025") Then
            Dim _SqlFiltro_Fechas As String

            _SqlFiltro_Fechas = "Where FEEMLI BETWEEN '" & Format(Dtp_Fecha_Desde_01.Value, "yyyyMMdd") & "' AND '" &
                                Format(Dtp_Fecha_Hasta_02.Value, "yyyyMMdd") & "'" & vbCrLf

            Dim _Sql_Filtro_Condicion_Extra = "And KOFU In (Select Distinct KOFULIDO From " &
                                              _Nombre_Tabla_Paso & vbCrLf & _SqlFiltro_Fechas & ")"

            Dim _Filtrar As New Clas_Filtros_Random(Me)

            If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Vendedores,
                                   Clas_Filtros_Random.Enum_Tabla_Fl._Funcionarios_Random, _Sql_Filtro_Condicion_Extra,
                                   _Filtro_Vendedores_Todas, False) Then

                _Tbl_Filtro_Vendedores = _Filtrar.Pro_Tbl_Filtro
                _Filtro_Vendedores_Todas = _Filtrar.Pro_Filtro_Todas

                If Cmb_Vista_Informe.SelectedValue = "KOFULIDO" Then
                    Sb_Actualizar_Grilla()
                Else
                    Cmb_Vista_Informe.SelectedValue = "KOFULIDO"
                End If
            End If
        End If
    End Sub

    Private Sub Btn_Filtro_Sucursales_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Filtro_Sucursales.Click
        Dim _SqlFiltro_Fechas As String

        _SqlFiltro_Fechas = "Where FEEMLI BETWEEN '" & Format(Dtp_Fecha_Desde_01.Value, "yyyyMMdd") & "' AND '" &
                            Format(Dtp_Fecha_Hasta_02.Value, "yyyyMMdd") & "'" & vbCrLf

        Dim _Sql_Filtro_Condicion_Extra = "And EMPRESA+KOSU In (Select Distinct EMPRESA+SULIDO From " &
                                          _Nombre_Tabla_Paso & vbCrLf & _SqlFiltro_Fechas & ")"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Sucursales,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Sucursales, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Sucursales_Todas, False) Then

            _Tbl_Filtro_Sucursales = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Sucursales_Todas = _Filtrar.Pro_Filtro_Todas

            If Cmb_Vista_Informe.SelectedValue = "SULIDO" Then
                Sb_Actualizar_Grilla()
            Else
                Cmb_Vista_Informe.SelectedValue = "SULIDO"
            End If

        End If
    End Sub

    Private Sub Btn_Filtro_Bodegas_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Filtro_Bodegas.Click
        Dim _SqlFiltro_Fechas As String

        _SqlFiltro_Fechas = "Where FEEMLI BETWEEN '" & Format(Dtp_Fecha_Desde_01.Value, "yyyyMMdd") & "' AND '" &
                            Format(Dtp_Fecha_Hasta_02.Value, "yyyyMMdd") & "'" & vbCrLf

        Dim _Sql_Filtro_Condicion_Extra = "And EMPRESA+KOSU+KOBO In (Select Distinct EMPRESA+SULIDO+BOSULIDO From " &
                                          _Nombre_Tabla_Paso & vbCrLf & _SqlFiltro_Fechas & ")"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Bodegas,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Bodegas, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Bodegas_Todas, False) Then

            _Tbl_Filtro_Bodegas = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Bodegas_Todas = _Filtrar.Pro_Filtro_Todas

            If Cmb_Vista_Informe.SelectedValue = "BOSULIDO" Then
                Sb_Actualizar_Grilla()
            Else
                Cmb_Vista_Informe.SelectedValue = "BOSULIDO"
            End If

        End If
    End Sub

    Sub Sb_Imagenes_Filtros()

        Btn_Filtro_Responzables.Image = Fx_Imagen_Filtro(_Filtro_Responzables_Todas)
        Btn_Filtro_Vendedores.Image = Fx_Imagen_Filtro(_Filtro_Vendedores_Todas)
        Btn_Filtro_Vendedor_Asignado_Entidad.Image = Fx_Imagen_Filtro(_Filtro_Vendedores_Asignados_Todas)

        If Not _Filtro_Vendedores_Todas Or Not _Filtro_Responzables_Todas Then
            Btn_Filtrar_Funcionarios.Image = Imagenes_16x16.Images.Item("filter.png")
        Else
            Btn_Filtrar_Funcionarios.Image = Nothing
        End If

        Btn_Filtro_Ent_Entidades.Image = Fx_Imagen_Filtro(_Filtro_Entidad_Todas)
        Btn_Filtro_Ent_Ciudades.Image = Fx_Imagen_Filtro(_Filtro_Ciudad_Todas)
        Btn_Filtro_Ent_Comunas.Image = Fx_Imagen_Filtro(_Filtro_Comunas_Todas)
        Btn_Filtro_Ent_Rubros.Image = Fx_Imagen_Filtro(_Filtro_Rubro_Entidades_Todas)
        Btn_Filtro_Ent_Zonas.Image = Fx_Imagen_Filtro(_Filtro_Zonas_Entidades_Todas)
        Btn_Filtro_Ent_Act_Economica.Image = Fx_Imagen_Filtro(_Filtro_Act_Economica_Todas)
        Btn_Filtro_Ent_Tipo_Entidad.Image = Fx_Imagen_Filtro(_Filtro_Tipo_Entidad_Todas)
        Btn_Filtro_Ent_Tamano_Empresa.Image = Fx_Imagen_Filtro(_Filtro_Tama_Empresa_Todas)
        Btn_Filtrar_Clas_BakApp.Image = Fx_Imagen_Filtro(_Filtro_Clas_BakApp_Todas)

        If Not _Filtro_Entidad_Todas Or
           Not _Filtro_Ciudad_Todas Or
           Not _Filtro_Comunas_Todas Or
           Not _Filtro_Rubro_Entidades_Todas Or
           Not _Filtro_Zonas_Entidades_Todas Or
           Not _Filtro_Act_Economica_Todas Or
           Not _Filtro_Tipo_Entidad_Todas Or
           Not _Filtro_Tama_Empresa_Todas Then
            Btn_Filtrar_Entidades.Image = Imagenes_16x16.Images.Item("filter.png")
        Else
            Btn_Filtrar_Entidades.Image = Nothing
        End If

        Btn_Filtro_Pro_Productos.Image = Fx_Imagen_Filtro(_Filtro_Productos_Todos)
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
           Not _Filtro_Zonas_Productos_Todas Then
            Btn_Filtrar_Productos.Image = Imagenes_16x16.Images.Item("filter.png")
        Else
            Btn_Filtrar_Productos.Image = Nothing
        End If

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
            Return Nothing ' Imagenes_20x20.Images.Item("filter.png")
        Else
            Return Imagenes_16x16.Images.Item("filter.png")
        End If
    End Function

    Private Sub Sb_Grilla_Detalle_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    'ShowContextMenu(Menu_Contextual_Informe)

                    If Cmb_Vista_Informe.SelectedValue = "ENDO+SUENDO" Then
                        Btn_Mnu_Informeacion_Credito_Cliente.Visible = True
                    Else
                        Btn_Mnu_Informeacion_Credito_Cliente.Visible = False
                    End If

                    ShowContextMenu(Menu_Contextual_Vista_Detalle)
                End If
            End With
        End If
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


    Private Sub Btn_Informe_X_Documentos_Entidades_Click(sender As System.Object, e As System.EventArgs)

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cod = _Fila.Cells("CODIGO").Value

        Dim _Filtro '= _SqlFiltro_Detalle & vbCrLf & _
        '   "And " & _Cp_Codigo & " = '" & _Cod & "'"

        Dim Fm As New Frm_Inf_Ventas_X_Periodo_Sub_Informes_01(_Nombre_Tabla_Paso,
                                                               _Filtro,
                                                               Frm_Inf_Ventas_X_Periodo_Sub_Informes_01.Enum_Tipo_Informe.Inf_Documentos)

        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Informe_X_Productos_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Informe_X_Productos.Click

        Dim _F1_R1 As Date = Dtp_Fecha_Desde_01.Value
        Dim _F2_R1 As Date = Dtp_Fecha_Hasta_01.Value
        Dim _F1_R2 As Date = Dtp_Fecha_Desde_02.Value
        Dim _F2_R2 As Date = Dtp_Fecha_Hasta_02.Value

        Dim _Dias_Habiles_R1 = Fx_Cuenta_Dias(_F1_R1, _F2_R1, Opcion_Dias.Habiles) 'Fx_Dias_Habiles(_Fecha_Estudio_Desde, _Fecha_Estudio_Hasta)
        Dim _Dias_Sabado_R1 = Fx_Cuenta_Dias(_F1_R1, _F2_R1, Opcion_Dias.Sabado)
        Dim _Dias_Domingo_R1 = Fx_Cuenta_Dias(_F1_R1, _F2_R1, Opcion_Dias.Domingo)

        Dim _Dias_Promedio_R1 As Integer = _Dias_Habiles_R1

        If Chk_Sabado.Checked Then _Dias_Promedio_R1 += _Dias_Sabado_R1
        If Chk_Domingo.Checked Then _Dias_Promedio_R1 += _Dias_Domingo_R1


        Dim _Dias_Habiles_R2 = Fx_Cuenta_Dias(_F1_R2, _F2_R2, Opcion_Dias.Habiles) 'Fx_Dias_Habiles(_Fecha_Estudio_Desde, _Fecha_Estudio_Hasta)
        Dim _Dias_Sabado_R2 = Fx_Cuenta_Dias(_F1_R2, _F2_R2, Opcion_Dias.Sabado)
        Dim _Dias_Domingo_R2 = Fx_Cuenta_Dias(_F1_R2, _F2_R2, Opcion_Dias.Domingo)

        Dim _Dias_Promedio_R2 As Integer = _Dias_Habiles_R2

        If Chk_Sabado.Checked Then _Dias_Promedio_R2 += _Dias_Sabado_R2
        If Chk_Domingo.Checked Then _Dias_Promedio_R2 += _Dias_Domingo_R2



        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cod = Trim(_Fila.Cells("CODIGO").Value)
        Dim _SqlFiltro_Detalle = Fx_Filtro_Detalle(Nothing, Nothing, False)

        Dim _Filtro As String
        Dim _Filtro_Nodos As String

        If _Filtro_Clas_BakApp_Todas Then
            _Filtro_Nodos = String.Empty
        Else
            _Filtro_Nodos = Generar_Filtro_IN(_Tbl_Filtro_Clas_BakApp, "Chk", "CODIGO", False, True, "")
            _Filtro_Nodos = "And KOPRCT In (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf &
                            "Where Codigo_Nodo In " & _Filtro_Nodos & ")"
        End If

        Dim _Filto_Nd

        If Cmb_Vista_Informe.SelectedValue = "0" Then
            Select Case _Cod
                Case "-2"
                    _Filto_Nd = "And KOPRCT Not In (Select KOPR From MAEPR)"
                Case "-1"
                    _Filto_Nd = "And KOPRCT In (Select KOPR From MAEPR Where KOPR Not In (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion Where Producto = 0))"
                Case Else
                    _Filto_Nd = "And KOPRCT In (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf &
                                            "Where Codigo_Nodo = " & _Cod & ")"
            End Select
            _Filtro = _SqlFiltro_Detalle & vbCrLf & _Filto_Nd & Space(1) & _Filtro_Nodos
        Else
            _Filtro = _SqlFiltro_Detalle & vbCrLf & "And " & _Cp_Codigo & " = '" & _Cod & "'"
        End If

        'If Cmb_Vista_Informe.SelectedValue <> "0" Then
        '_Filtro = _SqlFiltro_Detalle & vbCrLf & "And " & _Cp_Codigo & " = '" & _Cod & "'" & vbCrLf & _Filtro_Nodos
        'Else

        'If _Cod = "-1" Then
        '_Filto_Nd = "And KOPRCT In (Select KOPR From MAEPR Where KOPR Not In (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion Where Producto = 0))"
        '_Filtro = _SqlFiltro_Detalle & vbCrLf & _Filto_Nd & Space(1) & _Filtro_Nodos
        'Else
        '_Filto_Nd = "And KOPRCT In (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf & _
        '                            "Where Codigo_Nodo = " & _Cod & ")"
        '_Filtro = _SqlFiltro_Detalle & vbCrLf & _Filto_Nd & Space(1) & _Filtro_Nodos
        'End If

        'End If

        Consulta_sql = My.Resources.Recursos_Inf_Ventas.Cargar_Detalle_De_Productos_X_Rango_Venta
        Consulta_sql = Replace(Consulta_sql, "#Fecha_R1_Desde#", Format(Dtp_Fecha_Desde_01.Value, "yyyyMMdd"))
        Consulta_sql = Replace(Consulta_sql, "#Fecha_R1_Hasta#", Format(Dtp_Fecha_Hasta_01.Value, "yyyyMMdd"))
        Consulta_sql = Replace(Consulta_sql, "#Fecha_R2_Desde#", Format(Dtp_Fecha_Desde_02.Value, "yyyyMMdd"))
        Consulta_sql = Replace(Consulta_sql, "#Fecha_R2_Hasta#", Format(Dtp_Fecha_Hasta_02.Value, "yyyyMMdd"))
        Consulta_sql = Replace(Consulta_sql, "#dias_Habiles_R1#", _Dias_Habiles_R1)
        Consulta_sql = Replace(Consulta_sql, "#dias_Habiles_R2#", _Dias_Habiles_R2)
        Consulta_sql = Replace(Consulta_sql, "#Empresa#", ModEmpresa)
        Consulta_sql = Replace(Consulta_sql, "#Sucursal#", ModSucursal)
        Consulta_sql = Replace(Consulta_sql, "#Bodega#", ModBodega)
        Consulta_sql = Replace(Consulta_sql, "#Bodega#", ModBodega)
        Consulta_sql = Replace(Consulta_sql, "#Nombre_Tabla_Paso#", _Nombre_Tabla_Paso)

        Consulta_sql = Replace(Consulta_sql, "#Filtro#", _Filtro)

        Dim _Tbl_Informe As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        If CBool(_Tbl_Informe.Rows.Count) Then

            Dim _Row_Entidad As DataRow
            If Cmb_Vista_Informe.SelectedValue = "ENDO+SUENDO" Then
                Consulta_sql = "Select top 1 * From MAEEN Where KOEN+SUEN = '" & _Cod & "'"
                _Row_Entidad = _Sql.Fx_Get_DataRow(Consulta_sql)
            End If

            Dim Fm As New Frm_Inf_Ventas_X_Periodo_Productos_Vs_Rangos_Venta(_Tbl_Informe)
            Fm.Pro_RowEntidad = _Row_Entidad
            Fm.ShowDialog(Me)
            Fm.Dispose()
        Else
            MessageBoxEx.Show(Me, "No existe información", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

        'Dim Fm As New Frm_Inf_Ventas_X_Periodo_Sub_Informes_01(_Nombre_Tabla_Paso, _
        '                                                       _Filtro, _
        '                                                       Frm_Inf_Ventas_X_Periodo_Sub_Informes_01.Enum_Tipo_Informe.Inf_Clientes)

        'Fm.ShowDialog(Me)
        'Fm.Dispose()
    End Sub

    Private Sub Btn_Informe_X_Clientes_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Informe_X_Clientes.Click

        Dim _F1_R1 As Date = Dtp_Fecha_Desde_01.Value
        Dim _F2_R1 As Date = Dtp_Fecha_Hasta_01.Value
        Dim _F1_R2 As Date = Dtp_Fecha_Desde_02.Value
        Dim _F2_R2 As Date = Dtp_Fecha_Hasta_02.Value

        Dim _Dias_Habiles_R1 = Fx_Cuenta_Dias(_F1_R1, _F2_R1, Opcion_Dias.Habiles) 'Fx_Dias_Habiles(_Fecha_Estudio_Desde, _Fecha_Estudio_Hasta)
        Dim _Dias_Sabado_R1 = Fx_Cuenta_Dias(_F1_R1, _F2_R1, Opcion_Dias.Sabado)
        Dim _Dias_Domingo_R1 = Fx_Cuenta_Dias(_F1_R1, _F2_R1, Opcion_Dias.Domingo)

        Dim _Dias_Promedio_R1 As Integer = _Dias_Habiles_R1

        If Chk_Sabado.Checked Then _Dias_Promedio_R1 += _Dias_Sabado_R1
        If Chk_Domingo.Checked Then _Dias_Promedio_R1 += _Dias_Domingo_R1


        Dim _Dias_Habiles_R2 = Fx_Cuenta_Dias(_F1_R2, _F2_R2, Opcion_Dias.Habiles) 'Fx_Dias_Habiles(_Fecha_Estudio_Desde, _Fecha_Estudio_Hasta)
        Dim _Dias_Sabado_R2 = Fx_Cuenta_Dias(_F1_R2, _F2_R2, Opcion_Dias.Sabado)
        Dim _Dias_Domingo_R2 = Fx_Cuenta_Dias(_F1_R2, _F2_R2, Opcion_Dias.Domingo)

        Dim _Dias_Promedio_R2 As Integer = _Dias_Habiles_R2

        If Chk_Sabado.Checked Then _Dias_Promedio_R2 += _Dias_Sabado_R2
        If Chk_Domingo.Checked Then _Dias_Promedio_R2 += _Dias_Domingo_R2


        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cod = _Fila.Cells("CODIGO").Value
        Dim _SqlFiltro_Detalle = Fx_Filtro_Detalle(Nothing, Nothing, False)

        Dim _Filtro = _SqlFiltro_Detalle & vbCrLf &
                       "And " & _Cp_Codigo & " = '" & _Cod & "'"

        Consulta_sql = My.Resources.Recursos_Inf_Ventas.Cargar_Clientes_X_Rango_Venta
        Consulta_sql = Replace(Consulta_sql, "#Fecha_R1_Desde#", Format(Dtp_Fecha_Desde_01.Value, "yyyyMMdd"))
        Consulta_sql = Replace(Consulta_sql, "#Fecha_R1_Hasta#", Format(Dtp_Fecha_Hasta_01.Value, "yyyyMMdd"))
        Consulta_sql = Replace(Consulta_sql, "#Fecha_R2_Desde#", Format(Dtp_Fecha_Desde_02.Value, "yyyyMMdd"))
        Consulta_sql = Replace(Consulta_sql, "#Fecha_R2_Hasta#", Format(Dtp_Fecha_Hasta_02.Value, "yyyyMMdd"))
        Consulta_sql = Replace(Consulta_sql, "#dias_Habiles_R1#", _Dias_Habiles_R1)
        Consulta_sql = Replace(Consulta_sql, "#dias_Habiles_R2#", _Dias_Habiles_R2)
        Consulta_sql = Replace(Consulta_sql, "#Filtro#", _Filtro)


        Dim _Tbl_Informe As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        If CBool(_Tbl_Informe.Rows.Count) Then
            Dim Fm As New Frm_Inf_Ventas_X_Periodo_Productos_Vs_Rangos_Venta(_Tbl_Informe)
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If

        'Dim Fm As New Frm_Inf_Ventas_X_Periodo_Sub_Informes_01(_Nombre_Tabla_Paso, _
        '                                                       _Filtro, _
        '                                                       Frm_Inf_Ventas_X_Periodo_Sub_Informes_01.Enum_Tipo_Informe.Inf_Clientes)

        'Fm.ShowDialog(Me)
        'Fm.Dispose()

    End Sub

    Private Sub Btn_Mnu_Informeacion_Credito_Cliente_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Mnu_Informeacion_Credito_Cliente.Click
        If Fx_Tiene_Permiso(Me, "Inf00018") Then

            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

            'Dim _Koen As String = _Fila.Cells("ENDO").Value
            'Dim _Suen As String = _Fila.Cells("SUENDO").Value
            Dim _Razon As String = _Fila.Cells("DESCRIPCION").Value

            Dim Fm As New Frm_Infor_Ent_Estado_Creditos_Vigentes
            Fm.Pro_TxtDescripcion = _Razon
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If
    End Sub

    Private Sub Btn_Detalle_Rango_1_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Detalle_Rango_1.Click
        Sb_Ver_Detalle_De_Ventas_Por_Rango(1)
    End Sub

    Private Sub Btn_Detalle_Rango_2_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Detalle_Rango_2.Click
        Sb_Ver_Detalle_De_Ventas_Por_Rango(2)
    End Sub

    Sub Sb_Ver_Detalle_De_Ventas_Por_Rango(_Rango As Integer)

        Try
            Me.Enabled = False


            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
            Dim _Cod = Trim(_Fila.Cells("CODIGO").Value)

            Dim _Texto As String
            Dim _SqlFiltro_Detalle As String
            Dim _Filtro As String

            If _Rango = 1 Then
                _SqlFiltro_Detalle = Fx_Filtro_Detalle(Dtp_Fecha_Desde_01.Value, Dtp_Fecha_Hasta_01.Value)
                _Texto = "Informe de ventas Rango 1 desde: " & FormatDateTime(Dtp_Fecha_Desde_01.Value,
                         DateFormat.ShortDate) & Space(1) &
                         "Hasta: " & FormatDateTime(Dtp_Fecha_Hasta_01.Value, DateFormat.ShortDate)
            ElseIf _Rango = 2 Then
                _SqlFiltro_Detalle = Fx_Filtro_Detalle(Dtp_Fecha_Desde_02.Value, Dtp_Fecha_Hasta_02.Value)
                _Texto = "Informe de ventas Rango 1 desde: " & FormatDateTime(Dtp_Fecha_Desde_02.Value,
                         DateFormat.ShortDate) & Space(1) &
                         "Hasta: " & FormatDateTime(Dtp_Fecha_Hasta_02.Value, DateFormat.ShortDate)
            Else
                Return
            End If


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

            Dim Fm As New Frm_Inf_Ventas_X_Periodo_Sub_Informe_SuperGrid(_Nombre_Tabla_Paso, _Filtro, False, "")
            If CBool(Fm.Pro_Ds_Informe.Tables(0).Rows.Count) Then
                Fm.Text = _Texto
                Fm.ShowDialog(Me)
            Else
                MessageBoxEx.Show(Me, "No existe información", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            Fm.Dispose()

        Catch ex As Exception
        Finally
            Me.Enabled = True
        End Try

    End Sub



    Private Sub Btn_Proyeccion_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Proyeccion.Click

        If Fx_Tiene_Permiso(Me, "Inf00030") Then

            Dim _F1_R1 As Date = FormatDateTime(Dtp_Fecha_Desde_01.Value, DateFormat.ShortDate)
            Dim _F2_R1 As Date = FormatDateTime(Dtp_Fecha_Hasta_01.Value, DateFormat.ShortDate)

            Dim _F1_R2 As Date = FormatDateTime(Dtp_Fecha_Desde_02.Value, DateFormat.ShortDate)
            Dim _F2_R2 As Date = FormatDateTime(Dtp_Fecha_Hasta_02.Value, DateFormat.ShortDate)

            Dim _Meses_R1, _Meses_R2 As Integer

            Dim _Dias_Habiles_R1 = Fx_Cuenta_Dias(_F1_R1, _F2_R1, Opcion_Dias.Habiles) 'Fx_Dias_Habiles(_Fecha_Estudio_Desde, _Fecha_Estudio_Hasta)
            Dim _Dias_Sabado_R1 = Fx_Cuenta_Dias(_F1_R1, _F2_R1, Opcion_Dias.Sabado)
            Dim _Dias_Domingo_R1 = Fx_Cuenta_Dias(_F1_R1, _F2_R1, Opcion_Dias.Domingo)

            Dim _Dias_Promedio_R1 As Integer = _Dias_Habiles_R1 - Input_Dias_Feriado_R1.Value

            If Chk_Sabado.Checked Then _Dias_Promedio_R1 += _Dias_Sabado_R1
            If Chk_Domingo.Checked Then _Dias_Promedio_R1 += _Dias_Domingo_R1

            Dim _Dias_Habiles_R2 = Fx_Cuenta_Dias(_F1_R2, _F2_R2, Opcion_Dias.Habiles) 'Fx_Dias_Habiles(_Fecha_Estudio_Desde, _Fecha_Estudio_Hasta)
            Dim _Dias_Sabado_R2 = Fx_Cuenta_Dias(_F1_R2, _F2_R2, Opcion_Dias.Sabado)
            Dim _Dias_Domingo_R2 = Fx_Cuenta_Dias(_F1_R2, _F2_R2, Opcion_Dias.Domingo)

            Dim _Dias_Promedio_R2 As Integer = _Dias_Habiles_R2 - Input_Dias_Feriado_R2.Value


            If Chk_Sabado.Checked Then _Dias_Promedio_R2 += _Dias_Sabado_R2
            If Chk_Domingo.Checked Then _Dias_Promedio_R2 += _Dias_Domingo_R2

            _Meses_R1 = DateDiff(DateInterval.Month, _F1_R1, _F2_R1) + 1
            _Meses_R2 = DateDiff(DateInterval.Month, _F1_R2, _F2_R2) + 1


            Dim _Filtro_Nodos As String

            If _Filtro_Clas_BakApp_Todas Then
                _Filtro_Nodos = String.Empty
            Else
                _Filtro_Nodos = Generar_Filtro_IN(_Tbl_Filtro_Clas_BakApp, "Chk", "CODIGO", False, True, "")
                _Filtro_Nodos = "And KOPRCT In (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf &
                                "Where Codigo_Nodo In " & _Filtro_Nodos & ")"
            End If



            Dim Fm As New Frm_Inf_Ventas_X_Periodo_Proyeccion(_Nombre_Tabla_Paso,
                                                              _Cp_Codigo,
                                                              _Cp_Descripcion,
                                                              _Dias_Promedio_R1,
                                                              _Dias_Promedio_R2,
                                                              _Meses_R1,
                                                              _Meses_R2,
                                                              _SqlFiltro_Rango_01,
                                                              _SqlFiltro_Rango_02,
                                                              _Filtro_Nodos)
            Fm.Pro_Dias_Transcurridos = _Dias_Transcurridos
            Fm.Pro_Total_Dias = _Total_Dias
            Fm.ShowDialog(Me)
            _Total_Dias = Fm.Pro_Total_Dias
            _Dias_Transcurridos = Fm.Pro_Dias_Transcurridos
            Fm.Dispose()

        End If

    End Sub

    Private Sub Sb_Grilla_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs)
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
                Sb_Actualizar_Grilla()
            Else
                MessageBoxEx.Show(Me, "No existen más carpetas en esta selección", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        End If
    End Sub

    Private Sub Btn_Vista_Informe_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Vista_Informe.Click

        Dim Fm As New Frm_Arbol_Asociacion_05_Busqueda(Frm_Arbol_Asociacion_05_Busqueda.Enum_Tipo_De_Carpeta.Clas_Unica_Ambas, True)
        Fm.Pro_Seleccionar_Todo = _Filtro_Clas_BakApp_Todas
        Fm.Pro_Tbl_Nodos_Seleccionados = _Tbl_Filtro_Clas_BakApp
        Fm.ShowDialog(Me)
        If Not (Fm.Pro_Row_Nodo_Seleccionado Is Nothing) Then

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

            Sb_Actualizar_Grilla()

        End If
        Fm.Dispose()

    End Sub

    Private Sub Btn_Atras_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Atras.Click

        Dim _Nodo_Padre = _Row_Vista.Item("Identificacdor_NodoPadre")

        If CBool(_Nodo_Padre) Then

            Consulta_sql = "Select Codigo_Nodo as CODIGO,Descripcion As DESCRIPCION,Descripcion As DESCRIPCION_VISTA," &
                           "Cast(1 As Bit) As ARBOL_BAKAPP,*,Identificacdor_NodoPadre As Nodo_Padre" & vbCrLf &
                           "From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Codigo_Nodo = " & _Nodo_Padre
            _Row_Vista = _Sql.Fx_Get_DataRow(Consulta_sql)

            Sb_Actualizar_Grilla()
        Else
            Cmb_Vista_Informe.SelectedValue = "0"
            _Row_Vista = Fx_Crea_Tabla_Con_Filtro(_Tbl_Vista_Informe,
                                              "CODIGO = '" & Cmb_Vista_Informe.SelectedValue & "'", "Id").Rows(0)
            _Row_Vista.Item("ARBOL_BAKAPP") = True
            Sb_Actualizar_Grilla()
            Btn_Atras.Enabled = False

        End If

    End Sub

    Private Sub Btn_Filtrar_Clas_BakApp_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Filtrar_Clas_BakApp.Click

        Try
            Me.Enabled = False
            Me.Cursor = Cursors.WaitCursor
            Me.Refresh()

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

                    Sb_Actualizar_Grilla()

                End If
            End If
            Fm.Dispose()

        Catch ex As Exception

        Finally
            Me.Enabled = True
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub Dtp_Fecha_Hasta_01_TextChanged(sender As System.Object, e As System.EventArgs) Handles Dtp_Fecha_Hasta_01.TextChanged
        Sb_Feriados_Rango_1()
    End Sub

    Private Sub Dtp_Fecha_Desde_01_TextChanged(sender As System.Object, e As System.EventArgs) Handles Dtp_Fecha_Desde_01.TextChanged
        Sb_Feriados_Rango_1()
    End Sub

    Private Sub Dtp_Fecha_Hasta_02_TextChanged(sender As System.Object, e As System.EventArgs) Handles Dtp_Fecha_Hasta_02.TextChanged
        Sb_Feriados_Rango_2()
    End Sub

    Private Sub Dtp_Fecha_Desde_02_TextChanged(sender As System.Object, e As System.EventArgs) Handles Dtp_Fecha_Desde_02.TextChanged
        Sb_Feriados_Rango_2()
    End Sub

    Sub Sb_Feriados_Rango_1()

        Dim _Fecha_Desde As String = Format(Dtp_Fecha_Desde_01.Value, "yyyyMMdd")
        Dim _Fecha_Hasta As String = Format(Dtp_Fecha_Hasta_01.Value, "yyyyMMdd")

        Dim _Seis As String
        Dim _Siete As String

        If Chk_Sabado.Checked Then _Seis = ",6"
        If Chk_Domingo.Checked Then _Siete = ",7"

        Consulta_sql = "SELECT Tabla,CodigoTabla,NombreTabla,Fecha," &
                       "DATEPART(Dw,Fecha) As Nro_Dia,DATENAME(DW,Fecha) As Nombre_Dia " & vbCrLf &
                       "FROM " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf &
                       "WHERE (Tabla = 'FERIADOS')" & vbCrLf &
                       "And Fecha Between '" & _Fecha_Desde & "' And '" & _Fecha_Hasta & "'" & vbCrLf &
                       " And DATEPART(Dw,Fecha) In (1,2,3,4,5" & _Seis & _Siete & ")" & vbCrLf &
                       "ORDER BY Fecha"
        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        If CBool(_Tbl.Rows.Count) Then
            Input_Dias_Feriado_R1.Value = _Tbl.Rows.Count
        Else
            Input_Dias_Feriado_R1.Value = 0
        End If

    End Sub

    Sub Sb_Feriados_Rango_2()

        Dim _Fecha_Desde As String = Format(Dtp_Fecha_Desde_02.Value, "yyyyMMdd")
        Dim _Fecha_Hasta As String = Format(Dtp_Fecha_Hasta_02.Value, "yyyyMMdd")

        Dim _Seis As String
        Dim _Siete As String

        If Chk_Sabado.Checked Then _Seis = ",6"
        If Chk_Domingo.Checked Then _Siete = ",7"

        Consulta_sql = "SELECT Tabla,CodigoTabla,NombreTabla,Fecha," &
                       "DATEPART(Dw,Fecha) As Nro_Dia,DATENAME(DW,Fecha) As Nombre_Dia " & vbCrLf &
                       "FROM " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf &
                       "WHERE (Tabla = 'FERIADOS')" & vbCrLf &
                       "And Fecha Between '" & _Fecha_Desde & "' And '" & _Fecha_Hasta & "'" & vbCrLf &
                       " And DATEPART(Dw,Fecha) In (1,2,3,4,5" & _Seis & _Siete & ")" & vbCrLf &
                       "ORDER BY Fecha"
        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        If CBool(_Tbl.Rows.Count) Then
            Input_Dias_Feriado_R2.Value = _Tbl.Rows.Count
        End If

    End Sub

    Private Sub Btn_Dias_Feriados_Rango_1_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Dias_Feriados_Rango_1.Click
        Dim Fm As New Frm_Feriados_Anuales
        Fm.Pro_Fecha_Desde = FormatDateTime(Dtp_Fecha_Desde_01.Value)
        Fm.Pro_Fecha_Hasta = FormatDateTime(Dtp_Fecha_Hasta_01.Value)
        Fm.ShowDialog(Me)
        Fm.Dispose()
        Sb_Feriados_Rango_1()
    End Sub

    Private Sub Btn_Dias_Feriados_Rango_2_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Dias_Feriados_Rango_2.Click
        Dim Fm As New Frm_Feriados_Anuales
        Fm.Pro_Fecha_Desde = FormatDateTime(Dtp_Fecha_Desde_02.Value)
        Fm.Pro_Fecha_Hasta = FormatDateTime(Dtp_Fecha_Hasta_02.Value)
        Fm.ShowDialog(Me)
        Fm.Dispose()
        Sb_Feriados_Rango_2()
    End Sub

    Private Sub Chk_Sabado_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Chk_Sabado.CheckedChanged
        Sb_Feriados_Rango_1()
        Sb_Feriados_Rango_2()
    End Sub

    Private Sub Chk_Domingo_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Chk_Domingo.CheckedChanged
        Sb_Feriados_Rango_1()
        Sb_Feriados_Rango_2()
    End Sub

    Private Sub Btn_Excel_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Excel.Click
        ShowContextMenu(Menu_contextual_Exportar_Excel)
    End Sub

    Private Sub Btn_Exportar_Vista_Actual_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Exportar_Vista_Actual.Click
        If Fx_Tiene_Permiso(Me, "Inf00038") Then
            ExportarTabla_JetExcel_Tabla(_Tbl_Informe_Actual, Me, "Informe")
        End If
    End Sub

    Private Sub Btn_Exportar_Detalle_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Exportar_Detalle.Click
        If Fx_Tiene_Permiso(Me, "Inf00038") Then
            ExportarTabla_JetExcel_Tabla(_Tbl_Informe, Me, "Informe")
        End If
    End Sub

    Private Sub Btn_Nota_de_venta_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Nota_de_venta.Click

        If Fx_Tiene_Permiso(Me, "Bkp00040") Then

            Dim Fm_Post As New Frm_Formulario_Documento("NVV", csGlobales.Enum_Tipo_Documento.Venta, False)
            Fm_Post.MinimizeBox = True
            Fm_Post.ShowDialog(Me)
            Fm_Post.Dispose()

        End If

    End Sub

    Private Sub Btn_Crear_Venta_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Crear_Venta.Click
        ShowContextMenu(Menu_Contextual_Ventas)
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

        If Not Fx_Tiene_Permiso(Me, "Inf00025") Then
            Return
        End If

        Dim _SqlFiltro_Fechas As String

        _SqlFiltro_Fechas = "Where FEEMLI BETWEEN '" & Format(Dtp_Fecha_Desde_01.Value, "yyyyMMdd") & "' AND '" &
                             Format(Dtp_Fecha_Hasta_02.Value, "yyyyMMdd") & "'"

        Dim _Sql_Filtro_Condicion_Extra = "And KOFU In (Select Distinct KOFUEN From " &
                                          _Nombre_Tabla_Paso & vbCrLf & _SqlFiltro_Fechas & ")"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Vendedores_Asignados,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Funcionarios_Random, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Vendedores_Asignados_Todas, False) Then

            _Tbl_Filtro_Vendedores_Asignados = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Vendedores_Asignados_Todas = _Filtrar.Pro_Filtro_Todas

            If Cmb_Vista_Informe.SelectedValue = "KOFUEN" Then
                Sb_Actualizar_Grilla()
            Else
                Cmb_Vista_Informe.SelectedValue = "KOFUEN"
            End If
        End If

    End Sub

    Private Sub Btn_Actualizar_Informe_Click(sender As Object, e As EventArgs) Handles Btn_Actualizar_Informe.Click
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub Btn_Exportar_Diferencia_Clientes_Click(sender As Object, e As EventArgs) Handles Btn_Exportar_Diferencia_Clientes.Click
        ExportarTabla_JetExcel_Tabla(_Tbl_DifClientes_R1_R2, Me, "Dif. Clientes R1 y R2", "Inf00044")
    End Sub

    Private Sub Btn_Exportar_Diferencia_Productos_Click(sender As Object, e As EventArgs) Handles Btn_Exportar_Diferencia_Productos.Click
        ExportarTabla_JetExcel_Tabla(_Tbl_DifProductos_R1_R2, Me, "Dif. Productos R1 y R2", "Inf00045")
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
                    .Palette = ChartColorPalette.SeaGreen
                    _Color_Fondo = Color.FromArgb(Global_camvasColor)

            End Select

            Try
                .Titles.Item(0).ForeColor = _Color_Letras
                .Titles.Item(1).ForeColor = _Color_Letras
                .Titles.Item(2).ForeColor = _Color_Letras
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
                .Legends(1).ForeColor = _Color_Letras
                .Legends(2).ForeColor = _Color_Letras
            Catch ex As Exception

            End Try

            Try
                .ChartAreas(_ChartArea).BackColor = _Color_Fondo
                .ChartAreas(_ChartArea).BackSecondaryColor = _Color_Fondo

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

End Class
