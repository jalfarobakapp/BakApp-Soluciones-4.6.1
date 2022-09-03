Imports DevComponents.DotNetBar
Imports System.Windows.Forms.DataVisualization.Charting

Public Class Frm_EstadisticaProducto

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

    Dim _Tbl_Filtro_Bodegas As DataTable
    Dim _Filtro_Bodegas_Todas As Boolean

    Dim _Codigo As String
    Dim _Ud As Integer

    Dim _Row_Producto As DataRow
    Dim _Row_Concepto As DataRow
    Dim _Tbl_Productos_Reemplazo As DataTable

    Dim _AcConSwit As Boolean

    Dim _Tbl_Movimientos_Acumulados As DataTable
    Dim _Tbl_Grafico As DataTable
    Dim _Tbl_Grafico_X_Dias As DataTable
    Dim _Tbl_Grafico_Tendencia As DataTable

    Dim Tipo As String
    Dim Fr_Alerta_Stock As DevComponents.DotNetBar.Balloon

    Public _Correr_a_la_derecha As Boolean
    Dim _Graficos_Actualizados As Boolean

    Dim _Tbl_Productos_Hermanos As DataTable

    Dim _Endo As String
    Dim _RowEntidad As DataRow

    Dim _Descripcion As String
    Dim _Row_Nodo_Clasificaciones As DataRow
    Dim _Es_Concepto As Boolean

    Public Enum Tipo_Doc
        Ninguno
        Compra
        Venta
    End Enum

    Dim _Tipo_Doc As Tipo_Doc

    Public ReadOnly Property Pro_Tbl_Moviminetos_Acumulados() As DataTable
        Get
            Return _Tbl_Movimientos_Acumulados
        End Get
    End Property
    Public ReadOnly Property Pro_Tbl_Grafico() As DataTable
        Get
            Return _Tbl_Grafico
        End Get
    End Property
    Public Property Pro_Agrupar_Reemplazos() As Boolean
        Get
            Return Chk_Agrupar_Asociados.Checked
        End Get
        Set(value As Boolean)
            Chk_Agrupar_Asociados.Checked = value
        End Set
    End Property
    Public Property Pro_Stock_Critico() As Double
        Get
            Return Input_Stock_Minimo.Value
        End Get
        Set(value As Double)
            Input_Stock_Minimo.Value = value
        End Set
    End Property
    Public Property Pro_Incluir_Analisi_Con_Ent_Excluidas() As Double
        Get
            Return Chk_Rotacion_Con_Ent_Excluidas.Checked
        End Get
        Set(value As Double)
            Chk_Rotacion_Con_Ent_Excluidas.Checked = value
        End Set
    End Property
    Public Property Pro_Tbl_Filtro_Bodegas() As DataTable
        Get
            Return _Tbl_Filtro_Bodegas
        End Get
        Set(value As DataTable)
            _Tbl_Filtro_Bodegas = value
        End Set
    End Property
    Public Property Pro_Filtro_Bodegas_Todas() As Boolean
        Get
            Return _Filtro_Bodegas_Todas
        End Get
        Set(value As Boolean)
            _Filtro_Bodegas_Todas = value
        End Set
    End Property
    Public Property Pro_Row_Producto() As DataRow
        Get
            Return _Row_Producto
        End Get
        Set(value As DataRow)
            _Row_Producto = value
        End Set
    End Property
    Public ReadOnly Property Pro_Tbl_Productos_Reemplazo() As DataTable
        Get
            Return _Tbl_Productos_Reemplazo
        End Get
    End Property
    Public Property Pro_Tbl_Productos_Hermanos() As DataTable
        Get
            Return _Tbl_Productos_Hermanos
        End Get
        Set(value As DataTable)
            _Tbl_Productos_Hermanos = value
        End Set
    End Property

    Public Property Pro_Fecha_Moviminetos_Stock_Desde() As Date
        Get
            Return Dtp_Fecha_Moviminetos_Stock_Desde.Value
        End Get
        Set(value As Date)
            Dtp_Fecha_Moviminetos_Stock_Desde.Value = value
        End Set
    End Property
    Public Property Pro_Fecha_Moviminetos_Stock_Hasta() As Date
        Get
            Return Dtp_Fecha_Moviminetos_Stock_Hasta.Value
        End Get
        Set(value As Date)
            Dtp_Fecha_Moviminetos_Stock_Hasta.Value = value
        End Set
    End Property

    Public Sub New(Codigo As String,
                   Optional Endo As String = "",
                   Optional Tipo_D As Tipo_Doc = Tipo_Doc.Ninguno)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Dim _Ano As Integer = FechaDelServidor.Year

        Dim _Fecha = DateAdd(DateInterval.Year, -1, FechaDelServidor)
        Dtp_Fecha_Moviminetos_Stock_Desde.Value = Primerdiadelmes(_Fecha) 'Convert.ToDateTime("01/01/" & _Ano)
        Dtp_Fecha_Moviminetos_Stock_Hasta.Value = FechaDelServidor()

        Sb_Formato_Generico_Grilla(Grilla_Mensual, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Semanal, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

        If Rdb_Ud1.Checked Then
            _Ud = 1
        Else
            _Ud = 2
        End If

        Consulta_sql = "Select EMPRESA+KOSU+KOBO As Codigo,1 As Chk,NOKOBO as Descripcion From TABBO" & vbCrLf &
                       "Where EMPRESA+KOSU+KOBO = '" & ModEmpresa & ModSucursal & ModBodega & "'"
        _Tbl_Filtro_Bodegas = _Sql.Fx_Get_Tablas(Consulta_sql)

        _Codigo = Trim(Codigo)

        _Endo = Trim(Endo)
        _Tipo_Doc = Tipo_D


        Consulta_sql = My.Resources.Recursos_Info_Producto.SQLQuery_DatosDelProducto
        Consulta_sql = Replace(Consulta_sql, "#Codigo#", _Codigo)

        _Row_Producto = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row_Producto) Then

            Consulta_sql = "SELECT * FROM TABCT WHERE KOCT = '" & _Codigo & "'"
            _Row_Concepto = _Sql.Fx_Get_DataRow(Consulta_sql)

            If Not IsNothing(_Row_Concepto) Then
                _Es_Concepto = True
                _Descripcion = _Row_Concepto.Item("NOKOCT")

                Tab_04_Grafica_Ventas_Inventario.Enabled = False
                Tab_05_Movimientos_Acumulados.Enabled = False
                Tab_06_Codigos_Alternativos.Enabled = False
                Tab_07_Informacion_Del_Producto.Enabled = False

                BtnKardex.Enabled = False
                BtnStockPorBodegas.Enabled = False
                BtnCodigoAlternativos.Enabled = False
                Btn_Asociaciones_Arbol.Enabled = False
                Btn_Info_Prod_Otra_Empresa.Enabled = False
                Btn_Mnu_Pr_Codigo_De_Reemplazo.Enabled = False
                Btn_Productos_Asociados.Enabled = False
                Btn_Ver_Archivos_Adjuntos.Enabled = False
                Chk_Agrupar_Asociados.Enabled = False

            End If

        Else

            _Descripcion = Trim(_Row_Producto.Item("NOKOPR"))

        End If



        Dim series As Series = Grafico_Mov_Stock.Series.Add("Series3") 'Ingreso Stock: Compras , Ajustes, mov. internos
        series.ChartArea = "Default"
        series.ChartType = SeriesChartType.Point
        series.BorderWidth = 5
        series.MarkerColor = Color.Green
        series.MarkerStyle = MarkerStyle.Star5
        series.MarkerSize = 10
        series.IsValueShownAsLabel = False 'True

        series = Grafico_Mov_Stock.Series.Add("Series4") ' Salida Stock: Ventas, Ajustes, mov. internos
        series.ChartArea = "Default"
        series.ChartType = SeriesChartType.Point
        series.BorderWidth = 3
        series.MarkerColor = Color.Yellow
        series.MarkerStyle = MarkerStyle.Triangle
        series.MarkerSize = 5
        series.IsValueShownAsLabel = True

        series = Grafico_Mov_Stock.Series.Add("Series5") ' LINEA STOCK MINIMO
        series.ChartArea = "Default"
        series.ChartType = SeriesChartType.Line
        series.BorderWidth = 1
        series.MarkerColor = Color.Red
        series.MarkerStyle = MarkerStyle.None
        series.MarkerSize = 1
        series.IsValueShownAsLabel = False

        series = Grafico_Mov_Stock.Series.Add("Series6") ' NUMERO STOCK MINIMO
        series.ChartArea = "Default"
        series.ChartType = SeriesChartType.Point
        series.BorderWidth = 5
        series.MarkerColor = Color.Red
        series.MarkerStyle = MarkerStyle.Square
        series.MarkerSize = 3
        series.IsValueShownAsLabel = True

        series = Grafico_Mov_Stock.Series.Add("Series7") 'SOLICITUDES OCC
        series.ChartArea = "Default"
        series.ChartType = SeriesChartType.Point
        series.BorderWidth = 5
        series.MarkerColor = Color.Blue
        series.MarkerStyle = MarkerStyle.Star4
        series.MarkerSize = 8
        series.IsValueShownAsLabel = False 'True

        Dtp_Fecha_Moviminetos_Stock_Hasta.Value = FechaDelServidor()
        Chk_Stock_Minimo.Checked = False



        If Not String.IsNullOrEmpty(_Endo) Then
            Chk_Grafica_Ventas_Solo_Entidad.Visible = True
            Consulta_sql = "Select Top 1 * From MAEEN Where KOEN = '" & _Endo & "'"
            _RowEntidad = _Sql.Fx_Get_DataRow(Consulta_sql)
        End If

        AddHandler Rdb_Ud1.CheckedChanged, AddressOf Sb_Rdb_Ud_CheckedChanged
        AddHandler Rdb_Ud2.CheckedChanged, AddressOf Sb_Rdb_Ud_CheckedChanged

        Sb_Parametros_Informe_Sql(False)
        Me.ControlBox = True
        Me.ShowInTaskbar = False

        If Global_Thema = Enum_Themas.Oscuro Then

            MchMensuales.LineChartStyle.LineColor = Color.White
            McsSemanales.LineChartStyle.LineColor = Color.White

        End If

        SuperTabControl1.SelectedTabIndex = 0

    End Sub

    Private Sub Frm_EstadisticaProducto_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Sb_Actualizar_Tbl_Productos_Hermanos()

        Btn_Productos_Asociados.Tooltip = "Productos asociados (" & _Tbl_Productos_Hermanos.Rows.Count & ")"
        Chk_Agrupar_Asociados.Enabled = CBool(_Tbl_Productos_Hermanos.Rows.Count)

        Me.Text = "Código: " & _Codigo & ", " & _Descripcion & "       (Empresa: " & RazonEmpresa & ")"

        If _Correr_a_la_derecha Then
            Me.Top += 30
            Me.Left += 30
        End If

        Fr_Alerta_Stock = New AlertCustom(_Codigo, 1)
        LblEntFisicaVentas.Text = String.Empty
        LblEntFisicaCompras.Text = String.Empty

        Sb_Formato_Generico_Grilla(GrillaVentas, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        Sb_Formato_Generico_Grilla(GrillaCompras, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Entidad, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        Sb_Formato_Generico_Grilla(GrillaMovAcumulados, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

        Sb_Formato_Generico_Grilla(Grilla_Alternativos, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)
        Sb_Formato_Generico_Grilla(Grilla_DetalleDocAlternativos, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

        Sb_Llenar_Grillas(Chk_Mostrar_Solo_BLV_FCV_NCV.Checked, True)

        Sb_ActualizarGrilla_Alternativos()

        If Not IsNothing(_Row_Producto) Then

            TxtCodigoPrincipal.Text = Trim(_Row_Producto.Item("KOPR"))
            TxtCodigoRapido.Text = Trim(_Row_Producto.Item("KOPRRA"))
            TxtCodigoTecnico.Text = Trim(_Row_Producto.Item("KOPRTE"))
            TxtDescripcion.Text = Trim(_Row_Producto.Item("NOKOPR"))
            TxtRtu.Text = _Row_Producto.Item("RLUD")
            TxtUnidad1.Text = _Row_Producto.Item("UD01PR")
            TxtUnidad2.Text = _Row_Producto.Item("UD02PR")

            Dim _Marca As String = _Row_Producto.Item("Marca")
            Dim _SuperFamilia As String = _Row_Producto.Item("SuperFamilia")
            Dim _Familia As String = _Row_Producto.Item("Familia")
            Dim _SubFamilia As String = _Row_Producto.Item("SubFamilia")
            Dim _Rubro As String = _Row_Producto.Item("Rubro")
            Dim _ClasLibre As String = _Row_Producto.Item("CLALIBPR")
            Dim _Zona As String = _Row_Producto.Item("Zona")

            LblMarca.Text = _Marca
            LblSuperFamilia.Text = _SuperFamilia
            LblSubFamilia.Text = _SubFamilia
            LblFamilia.Text = _Familia
            LblRubro.Text = _Rubro
            LblClasLibre.Text = _Sql.Fx_Trae_Dato("TABCARAC", "NOKOCARAC",
                                                  "KOTABLA = 'CLALIBPR' and KOCARAC = '" & _ClasLibre & "'")
            LblZona.Text = _Zona

        End If

        _AcConSwit = True


        AddHandler Grilla_Entidad.CellDoubleClick, AddressOf Sb_Grilla_CellDoubleClick
        AddHandler GrillaCompras.CellDoubleClick, AddressOf Sb_Grilla_CellDoubleClick
        AddHandler GrillaVentas.CellDoubleClick, AddressOf Sb_Grilla_CellDoubleClick

        AddHandler Grilla_Entidad.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler GrillaCompras.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler GrillaVentas.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        AddHandler Grilla_Entidad.MouseDown, AddressOf Sb_Grilla_MouseDown
        AddHandler GrillaCompras.MouseDown, AddressOf Sb_Grilla_MouseDown
        AddHandler GrillaVentas.MouseDown, AddressOf Sb_Grilla_MouseDown

        AddHandler Chk_Stock_Movimiento.CheckedChanged, AddressOf Sb_Ver_Etiquetas_Grafico_Tiempo_Reposicion
        AddHandler Chk_Stock_Minimo.CheckedChanged, AddressOf Sb_Ver_Etiquetas_Grafico_Tiempo_Reposicion
        AddHandler Chk_Stock_Ingresos.CheckedChanged, AddressOf Sb_Ver_Etiquetas_Grafico_Tiempo_Reposicion
        AddHandler Chk_Stock_Salidas.CheckedChanged, AddressOf Sb_Ver_Etiquetas_Grafico_Tiempo_Reposicion

        Sb_Ver_Etiquetas_Grafico_Tiempo_Reposicion()

        AddHandler Tabs.SelectedTabChanged, AddressOf Sb_Tabs_SelectedTabChanged

        GrillaCompras.Visible = Fx_Tiene_Permiso(Me, "Prod051",, False)

        AddHandler Chk_Agrupar_Asociados.CheckedChanged, AddressOf Chk_Agrupar_Asociados_CheckedChanged
        Chk_Agrupar_Asociados_CheckedChanged(Nothing, Nothing)

        Grafico_Ventas_Periodo.Titles(1).Text = _Descripcion

        If Global_Thema = Enum_Themas.Oscuro Then
            Tabs.TabStyle = eSuperTabStyle.Office2007
        End If

        Sb_Formato_Graficos(Grafico_Desviacion_Estandar, 0, 0)

        For i = 0 To 7
            Sb_Formato_Graficos(Grafico_Mov_Stock, i, i)
        Next

        Sb_Formato_Graficos(Grafico_Tendencias, 0, 0)
        Sb_Formato_Graficos(Grafico_Ventas_Periodo, 0, 0)

        Sb_Color_Botones_Barra(Bar1)
        Sb_Dias_Entre_Fechas()

    End Sub

    Sub Sb_Actualizar_Tbl_Productos_Hermanos()

        Dim _Nodo_Raiz_Asociados As Integer = _Global_Row_Configuracion_General.Item("Nodo_Raiz_Asociados")

        Consulta_sql = "SELECT Top 1 * From " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf &
                       "Where (Codigo = '" & _Codigo & "') AND (Para_filtro = 1)" & vbCrLf &
                       "And Codigo_Nodo In (Select Codigo_Nodo From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Nodo_Raiz = " & _Nodo_Raiz_Asociados & ")"

        _Row_Nodo_Clasificaciones = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Codigo_Nodo As Integer

        If _Row_Nodo_Clasificaciones Is Nothing Then
            _Codigo_Nodo = 0
        Else
            _Codigo_Nodo = _Row_Nodo_Clasificaciones.Item("Codigo_Nodo")
        End If

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Codigo_Nodo = " & _Codigo_Nodo
        _Row_Nodo_Clasificaciones = _Sql.Fx_Get_DataRow(Consulta_sql)

        Consulta_sql = "SELECT KOPR FROM MAEPR WHERE KOPR IN (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion" & Space(1) &
                       "Where Codigo_Nodo = " & _Codigo_Nodo & " And Codigo_Nodo <> 0)" & Space(1) &
                       "AND KOPR <> '" & _Codigo & "'"
        _Tbl_Productos_Hermanos = _Sql.Fx_Get_Tablas(Consulta_sql)

    End Sub

    Private Sub Frm_EstadisticaProducto_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        If Fr_Alerta_Stock.Visible Then Fr_Alerta_Stock.Close()
        Sb_Parametros_Informe_Sql(True)

    End Sub

    Private Sub BtnxSalir_Click(sender As System.Object, e As System.EventArgs)
        Me.Close()
    End Sub

    Sub Sb_Actualizar_Grilla(_Grilla As DataGridView,
                             _TipoDoc As String,
                             _Codigo As String,
                             _Tipo_Doc As Tipo_Doc,
                             _Endo As String,
                             _Rotacion_Con_Ent_Excluidas As Boolean)

        Consulta_sql = My.Resources.Recursos_Info_Producto.Ultimos_Movimientos_Del_Producto

        Consulta_sql = Replace(Consulta_sql, "#Empresa#", ModEmpresa)
        Consulta_sql = Replace(Consulta_sql, "#Funcionario#", FUNCIONARIO)
        Consulta_sql = Replace(Consulta_sql, "#TipoDocumento#", _TipoDoc)
        Consulta_sql = Replace(Consulta_sql, "#NroDocumentos#", CmbCantFilas.Text)
        Consulta_sql = Replace(Consulta_sql, "#Codigo#", _Codigo)

        '#Filtro_Entidad# And MAEDDO.ENDO = ''
        Dim _Filtro_Entidad As String
        Dim _Filtro_Entidades_Excluidas As String
        Dim _Filtro_Codigos_Asociados As String

        If String.IsNullOrEmpty(_Endo) Then
            _Filtro_Entidad = String.Empty
        Else
            _Filtro_Entidad = "And MAEDDO.ENDO = '" & _Endo & "'"
        End If

        If Not _Rotacion_Con_Ent_Excluidas Then
            _Filtro_Entidades_Excluidas = "And LTRIM(RTRIM(MAEDDO.ENDO))+RTRIM(LTRIM(MAEDDO.SUENDO))" & vbCrLf &
            "NOT IN (SELECT  LTRIM(RTRIM(Codigo))+LTRIM(RTRIM(Sucursal)) From " & _Global_BaseBk & "Zw_TblInf_EntExcluidas" & vbCrLf &
            "Where Funcionario = '" & FUNCIONARIO & "' And Excluida in ('V','A','T'))" & vbCrLf
        End If


        If Chk_Agrupar_Asociados.Checked And CBool(_Tbl_Productos_Hermanos.Rows.Count) Then
            Dim _Filtro_Prod_Hermanos = Generar_Filtro_IN(_Tbl_Productos_Hermanos, "", "KOPR", False, False, "'")
            _Filtro_Codigos_Asociados = "Select KOPR From MAEPR Where KOPR IN " & _Filtro_Prod_Hermanos & Space(1) &
                                        "Union" & Space(1) &
                                        "Select KOPR From MAEPR Where KOPR = '" & _Codigo & "'"

            Consulta_sql = Replace(Consulta_sql, "MAEDDO.KOPRCT = @Codigo  AND", "MAEDDO.KOPRCT In (" & _Filtro_Codigos_Asociados & ") AND")
        End If


        Consulta_sql = Replace(Consulta_sql, "#Filtro_Entidad#", _Filtro_Entidad & Space(1) & _Filtro_Entidades_Excluidas)


        With _Grilla

            .DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)

            OcultarEncabezadoGrilla(_Grilla)

            Dim _DisplayIndex = 0

            .Columns("ENDO").Width = 75
            .Columns("ENDO").HeaderText = "Entidad"
            .Columns("ENDO").Visible = True
            .Columns("ENDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            If Chk_Agrupar_Asociados.Checked Then
                .Columns("NOKOEN").Width = 240 - 90
            Else
                .Columns("NOKOEN").Width = 240
            End If

            .Columns("NOKOEN").HeaderText = "Nombre"
            .Columns("NOKOEN").Visible = True
            .Columns("NOKOEN").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("TIDO").Width = 30
            .Columns("TIDO").HeaderText = "TD"
            .Columns("TIDO").Visible = True
            .Columns("TIDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NUDO").Width = 70
            .Columns("NUDO").HeaderText = "Número"
            .Columns("NUDO").Visible = True
            .Columns("NUDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FEEMLI").Width = 65
            .Columns("FEEMLI").HeaderText = "Fecha"
            .Columns("FEEMLI").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FEEMLI").Visible = True
            .Columns("FEEMLI").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("SULIDO").Width = 35
            .Columns("SULIDO").HeaderText = "Suc"
            .Columns("SULIDO").Visible = True
            .Columns("SULIDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("BOSULIDO").Width = 35
            .Columns("BOSULIDO").HeaderText = "Bod"
            .Columns("BOSULIDO").Visible = True
            .Columns("BOSULIDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("KOPRCT").Width = 90
            .Columns("KOPRCT").HeaderText = "Código"
            .Columns("KOPRCT").Visible = Chk_Agrupar_Asociados.Checked
            .Columns("KOPRCT").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("UN").Width = 25
            .Columns("UN").HeaderText = "Un"
            .Columns("UN").Visible = True
            .Columns("UN").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CANTIDAD").Width = 60
            .Columns("CANTIDAD").HeaderText = "Cantidad"
            .Columns("CANTIDAD").DefaultCellStyle.Format = "##,###0.00"
            .Columns("CANTIDAD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CANTIDAD").Visible = True
            .Columns("CANTIDAD").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("MODO").Width = 30
            .Columns("MODO").HeaderText = "M."
            .Columns("MODO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("MODO").Visible = True
            .Columns("MODO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("PRECIOUD").Width = 70
            .Columns("PRECIOUD").HeaderText = "Pr.Unidad"
            .Columns("PRECIOUD").DefaultCellStyle.Format = "$ ##,###0.00"
            .Columns("PRECIOUD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PRECIOUD").Visible = True
            .Columns("PRECIOUD").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("VANELI").Width = 80
            .Columns("VANELI").HeaderText = "Valor"
            .Columns("VANELI").DefaultCellStyle.Format = "$ ##,###0.00"
            .Columns("VANELI").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VANELI").Visible = True
            .Columns("VANELI").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            If _Tipo_Doc = Frm_EstadisticaProducto.Tipo_Doc.Compra Then
                If Fx_Tiene_Permiso(Me, "NO00001", , False) Then
                    .Columns("PRECIOUD").Visible = False
                    .Columns("VANELI").Visible = False
                End If
            End If

        End With

        For Each _Fila As DataGridViewRow In _Grilla.Rows

            Dim _Tido = _Fila.Cells("TIDO").Value

            If _Tido = "NCV" Then
                If Global_Thema = Enum_Themas.Oscuro Then
                    _Fila.DefaultCellStyle.ForeColor = Color.Gold
                Else
                    _Fila.DefaultCellStyle.BackColor = Color.Yellow
                End If
            End If

        Next

        Btn_Dimensiones.Visible = Not Chk_Agrupar_Asociados.Checked

        Me.Refresh()

    End Sub

    Function Fx_Ds_Graficos(_Row_Producto As DataRow,
                            _Tbl_Productos As DataTable) As DataSet

        Dim _Filtro_Codigos As String

        If Not (_Row_Producto Is Nothing) Then
            _Filtro_Codigos = "('" & _Row_Producto.Item("KOPR") & "')"
        Else
            _Filtro_Codigos = Generar_Filtro_IN(_Tbl_Productos, "", "KOPR", False, False, "'")
        End If

        Dim _TblPaso As String = "#TblPaso" & FUNCIONARIO

        _Sql.Sb_Eliminar_Tabla_De_Paso(_TblPaso)

        Dim _dias = -365

        Dim F1 As Date = Dtp_Fecha_Moviminetos_Stock_Desde.Value
        Dim F2 As Date = Dtp_Fecha_Moviminetos_Stock_Hasta.Value

        Dim FechaInicio As String = Format(F1, "yyyyMMdd")
        Dim FechaFin As String = Format(F2, "yyyyMMdd")

        Consulta_sql = My.Resources.Recursos_Info_Producto.SQLQuery_Estadisticas_por_producto
        Consulta_sql = Replace(Consulta_sql, "#Empresa#", ModEmpresa)
        Consulta_sql = Replace(Consulta_sql, "#Codigo#", _Filtro_Codigos)
        Consulta_sql = Replace(Consulta_sql, "#Fecha#", FechaFin)

        Consulta_sql = Replace(Consulta_sql, "#Fecha1#", Format(F1, "yyyyMMdd"))
        Consulta_sql = Replace(Consulta_sql, "#Fecha2#", FechaFin)

        Dim _Filtro_Extra As String

        If Chk_Grafica_Ventas_Solo_Entidad.Checked Then
            _Filtro_Extra = "And EDO.ENDO = '" & _Endo & "'"
        End If

        Consulta_sql = Replace(Consulta_sql, "#Filtro_Extra#", _Filtro_Extra)

        Dim _Filtro_Bodegas As String

        If _Filtro_Bodegas_Todas Then
            _Filtro_Bodegas = String.Empty
        Else
            _Filtro_Bodegas = Generar_Filtro_IN(_Tbl_Filtro_Bodegas, "Chk", "Codigo", False, True, "'")
            _Filtro_Bodegas = "And DDO.EMPRESA+DDO.SULIDO+DDO.BOSULIDO IN " & _Filtro_Bodegas
        End If

        Consulta_sql = Replace(Consulta_sql, "#FiltroBodegas#", _Filtro_Bodegas)
        Consulta_sql = Replace(Consulta_sql, "#Funcionario#", FUNCIONARIO)

        Dim _Filtro_Entidades_Excluidas As String = String.Empty

        If Not Chk_Rotacion_Con_Ent_Excluidas.Checked Then

            _Filtro_Entidades_Excluidas = "And LTRIM(RTRIM(DDO.ENDO))+RTRIM(LTRIM(DDO.SUENDO))" & vbCrLf &
            "NOT IN (SELECT LTRIM(RTRIM(Codigo))+LTRIM(RTRIM(Sucursal)) From " & _Global_BaseBk & "Zw_TblInf_EntExcluidas" & vbCrLf &
            "Where Funcionario = @CodFuncionario And Excluida In ('V','A','T'))" & vbCrLf

        End If

        Consulta_sql = Replace(Consulta_sql, "#Filtro_Entidades_Excluidas#", _Filtro_Entidades_Excluidas)
        Consulta_sql = Replace(Consulta_sql, "#Tabla_de_Paso#", _TblPaso)
        Consulta_sql += vbCrLf

        Dim Meses As Integer = DateDiff(DateInterval.Month, F1, F2)

        Dim Meses_(Meses) As String
        Dim Fecha As Date = F1

        For Mes = 0 To Meses

            Dim FechaNw As String = MonthName(Month(Fecha), True) & "-" & Fecha.Year
            Meses_(Mes) = FechaNw

            Dim FStr As String = Format(Primerdiadelmes(Fecha), "yyyyMMdd")

            Consulta_sql += "Insert Into " & _TblPaso & "( Tipo,Sucursal,Bodega,Fecha, Mes_Palabra, Semana, Mes, Ano, SumTotalQtyUd1, SumTotalQtyUd2)" & vbCrLf &
                            "Values ('V','" & ModSucursal & "','" & ModBodega & "','" & FStr & "'," & vbCrLf &
                            "DATENAME(month,'" & FStr & "')," & vbCrLf &
                            "DATEPART(week, '" & FStr & "')," & vbCrLf &
                            "MONTH('" & FStr & "')," & vbCrLf &
                            "YEAR('" & FStr & "'),0,0)" & vbCrLf

            Fecha = DateAdd(DateInterval.Month, 1, Fecha)

        Next

        Dim _Unidad As String = "SumTotalQtyUd" & _Ud


        Consulta_sql += vbCrLf & My.Resources.Recursos_Info_Producto.MovAcumulados & vbCrLf & vbCrLf
        Consulta_sql = Replace(Consulta_sql, "#SumTotalQtyUd#", _Unidad)
        Consulta_sql = Replace(Consulta_sql, "#Tabla_de_Paso#", _TblPaso)

        Consulta_sql += "Select Ltrim(Rtrim(substring(Mes_Palabra,1,3)))+'-'+Ltrim(Rtrim(STR(Ano))) as Periodo," & vbCrLf &
                        "Case When ROUND(SUM(" & _Unidad & "),2) = 0 then Null" & vbCrLf &
                        "Else ROUND(SUM(" & _Unidad & "),2) End as Ud" & vbCrLf &
                        "From " & _TblPaso & vbCrLf &
                        "Where (Tipo = 'V')" & vbCrLf &
                        "GROUP BY Mes_Palabra,Ano,Mes" & vbCrLf &
                        "Order by Ano,Mes" & vbCrLf &
                        "Select * From " & _TblPaso & " Where (Tipo = 'V') Order by Fecha" & vbCrLf &
                        "Drop Table " & _TblPaso

        Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

        Return _Ds

    End Function

    Function Fx_Ds_Graficos2(_Row_Producto As DataRow,
                            _Tbl_Productos As DataTable) As DataSet

        Dim _Filtro_Codigos As String

        If Not (_Row_Producto Is Nothing) Then
            _Filtro_Codigos = "('" & _Row_Producto.Item("KOPR") & "')"
        Else
            _Filtro_Codigos = Generar_Filtro_IN(_Tbl_Productos, "", "KOPR", False, False, "'")
        End If

        Dim _TblPaso As String = "#TblPaso" & FUNCIONARIO

        _Sql.Sb_Eliminar_Tabla_De_Paso(_TblPaso)

        Dim _dias = -365

        Dim F1 As Date = Dtp_Fecha_Moviminetos_Stock_Desde.Value
        Dim F2 As Date = Dtp_Fecha_Moviminetos_Stock_Hasta.Value

        Dim FechaInicio As String = Format(F1, "yyyyMMdd")
        Dim FechaFin As String = Format(F2, "yyyyMMdd")

        Consulta_sql = My.Resources.Recursos_Info_Producto.SQLQuery_Estadisticas_por_producto
        Consulta_sql = Replace(Consulta_sql, "#Empresa#", ModEmpresa)
        Consulta_sql = Replace(Consulta_sql, "#Codigo#", _Filtro_Codigos)
        Consulta_sql = Replace(Consulta_sql, "#Fecha#", FechaFin)

        Consulta_sql = Replace(Consulta_sql, "#Fecha1#", Format(F1, "yyyyMMdd"))
        Consulta_sql = Replace(Consulta_sql, "#Fecha2#", FechaFin)

        Dim _Filtro_Extra As String

        If Chk_Grafica_Ventas_Solo_Entidad.Checked Then
            _Filtro_Extra = "And EDO.ENDO = '" & _Endo & "'"
        End If

        Consulta_sql = Replace(Consulta_sql, "#Filtro_Extra#", _Filtro_Extra)

        Dim _Filtro_Bodegas As String

        If _Filtro_Bodegas_Todas Then
            _Filtro_Bodegas = String.Empty
        Else
            _Filtro_Bodegas = Generar_Filtro_IN(_Tbl_Filtro_Bodegas, "Chk", "Codigo", False, True, "'")
            _Filtro_Bodegas = "And DDO.EMPRESA+DDO.SULIDO+DDO.BOSULIDO IN " & _Filtro_Bodegas
        End If

        Consulta_sql = Replace(Consulta_sql, "#FiltroBodegas#", _Filtro_Bodegas)
        Consulta_sql = Replace(Consulta_sql, "#Funcionario#", FUNCIONARIO)

        Dim _Filtro_Entidades_Excluidas As String = String.Empty

        If Not Chk_Rotacion_Con_Ent_Excluidas.Checked Then

            _Filtro_Entidades_Excluidas = "And LTRIM(RTRIM(DDO.ENDO))+RTRIM(LTRIM(DDO.SUENDO))" & vbCrLf &
            "NOT IN (SELECT LTRIM(RTRIM(Codigo))+LTRIM(RTRIM(Sucursal)) From " & _Global_BaseBk & "Zw_TblInf_EntExcluidas" & vbCrLf &
            "Where Funcionario = @CodFuncionario And Excluida In ('V','A','T'))" & vbCrLf

        End If

        Consulta_sql = Replace(Consulta_sql, "#Filtro_Entidades_Excluidas#", _Filtro_Entidades_Excluidas)
        Consulta_sql = Replace(Consulta_sql, "#Tabla_de_Paso#", _TblPaso)
        Consulta_sql += vbCrLf

        Dim Meses As Integer = DateDiff(DateInterval.Month, F1, F2)

        Dim Meses_(Meses) As String
        Dim Fecha As Date = F1

        'For Mes = 0 To Meses

        '    Dim FechaNw As String = MonthName(Month(Fecha), True) & "-" & Fecha.Year
        '    Meses_(Mes) = FechaNw

        '    Dim FStr As String = Format(Primerdiadelmes(Fecha), "yyyyMMdd")

        '    Consulta_sql += "Insert Into " & _TblPaso & "( Tipo,Sucursal,Bodega,Fecha, Mes_Palabra, Semana, Mes, Ano, SumTotalQtyUd1, SumTotalQtyUd2)" & vbCrLf &
        '                    "Values ('V','" & ModSucursal & "','" & ModBodega & "','" & FStr & "'," & vbCrLf &
        '                    "DATENAME(month,'" & FStr & "')," & vbCrLf &
        '                    "DATEPART(week, '" & FStr & "')," & vbCrLf &
        '                    "MONTH('" & FStr & "')," & vbCrLf &
        '                    "YEAR('" & FStr & "'),0,0)" & vbCrLf

        '    Fecha = DateAdd(DateInterval.Month, 1, Fecha)

        'Next

        Dim _Dias_Entre_Fechas As Integer = DateDiff(DateInterval.Day, F1, F2)
        Dim _Dias_Array(_Dias_Entre_Fechas) As String

        Fecha = F1
        Dim FStr = String.Empty

        For Mes = 0 To Meses

            Dim _yyyy = Fecha.Year
            Dim _MM = Fecha.Month

            Dim _Dias_del_Mes = System.DateTime.DaysInMonth(_yyyy, _MM)

            For _dd = 1 To _Dias_del_Mes

                Dim FechaNw As String = MonthName(Month(Fecha), True) & "-" & numero_(_dd, 2) '& "-" & numero_(_MM, 2) & "-" & Mid(_yyyy, 3, 2)
                Meses_(Mes) = FechaNw

                FStr = _yyyy & numero_(_MM, 2) & numero_(_dd, 2)

                Consulta_sql += "Insert Into " & _TblPaso & "( Tipo,Sucursal,Bodega,Fecha,Mes_Palabra,Semana,Dia,Mes,Ano,SumTotalQtyUd1,SumTotalQtyUd2)" & vbCrLf &
                                "Values ('V','" & ModSucursal & "','" & ModBodega & "','" & FStr & "'," & vbCrLf &
                                "DATENAME(month,'" & FStr & "')," & vbCrLf &
                                "DATEPART(week, '" & FStr & "')," & vbCrLf &
                                "DAY('" & FStr & "')," & vbCrLf &
                                "MONTH('" & FStr & "')," & vbCrLf &
                                "YEAR('" & FStr & "'),0,0)" & vbCrLf & vbCrLf

                If FStr = Format(F2, "yyyyMMdd") Then Exit For

            Next

            If FStr = Format(F2, "yyyyMMdd") Then Exit For

            Fecha = DateAdd(DateInterval.Month, 1, Fecha)

        Next

        Dim _Unidad As String = "SumTotalQtyUd" & _Ud

        Consulta_sql += vbCrLf & My.Resources.Recursos_Info_Producto.MovAcumulados & vbCrLf & vbCrLf
        Consulta_sql = Replace(Consulta_sql, "#SumTotalQtyUd#", _Unidad)
        Consulta_sql = Replace(Consulta_sql, "#Tabla_de_Paso#", _TblPaso)

        Consulta_sql += "Select Ltrim(Rtrim(substring(Mes_Palabra,1,3)))+'-'+Ltrim(Rtrim(STR(Ano))) as Periodo," & vbCrLf &
                        "Case When ROUND(SUM(" & _Unidad & "),2) = 0 then Null" & vbCrLf &
                        "Else ROUND(SUM(" & _Unidad & "),2) End as Ud" & vbCrLf &
                        "From " & _TblPaso & vbCrLf &
                        "Where (Tipo = 'V')" & vbCrLf &
                        "Group by Mes_Palabra,Ano,Mes" & vbCrLf &
                        "Order by Ano,Mes" &
                        vbCrLf &
                        vbCrLf &
                        "Select * From " & _TblPaso & " Where (Tipo = 'V') Order by Fecha" &
                        vbCrLf &
                        vbCrLf &
                        "--Select Rtrim(Ltrim(STR(Dia)))+'-'+ Rtrim(Ltrim(Str(Mes)))+'-'+Substring(Rtrim(Ltrim(Str(Ano))),3,2) as Periodo," & vbCrLf &
                        "Select Ltrim(Rtrim(STR(Dia)))+'-'+Ltrim(Rtrim(STR(Mes))) as Periodo," & vbCrLf &
                        "Case When ROUND(SUM(" & _Unidad & "),2) = 0 then Null" & vbCrLf &
                        "Else ROUND(SUM(" & _Unidad & "),2) End as Ud" & vbCrLf &
                        "From " & _TblPaso & vbCrLf &
                        "Where (Tipo = 'V')" & vbCrLf &
                        "GROUP BY Mes_Palabra,Ano,Mes,Dia" & vbCrLf &
                        "Order by Ano,Mes,Dia" &
                        vbCrLf &
                        vbCrLf &
                        "Drop Table " & _TblPaso

        Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

        Return _Ds

    End Function

    Sub Sb_Actualizar_Estadisticas_Varios_Productos(_Tbl_Productos As DataTable)

        Dim _Ds As DataSet

        Dim _F1 As Date = Dtp_Fecha_Moviminetos_Stock_Desde.Value
        Dim _F2 As Date = Dtp_Fecha_Moviminetos_Stock_Hasta.Value

        Dim _Meses As Integer = DateDiff(DateInterval.Month, _F1, _F2)
        Dim _Dias As Integer = DateDiff(DateInterval.Day, _F1, _F2)

        If Chk_Mostrar_Venta_Por_Dia.Checked And _Dias <= 120 Then
            _Ds = Fx_Ds_Graficos2(Nothing, _Tbl_Productos)
        Else
            _Ds = Fx_Ds_Graficos(Nothing, _Tbl_Productos)
        End If

        _Tbl_Movimientos_Acumulados = _Ds.Tables(0)
        _Tbl_Grafico = _Ds.Tables(1)
        _Tbl_Grafico_Tendencia = _Ds.Tables(2)

        GrillaMovAcumulados.DataSource = _Tbl_Movimientos_Acumulados
        '
        With GrillaMovAcumulados
            For I = 1 To 6
                .Columns(I).DefaultCellStyle.Format = "##,###0.00"
                .Columns(I).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Next
        End With

        If Chk_Mostrar_Venta_Por_Dia.Checked And _Dias <= 120 Then
            _Tbl_Grafico_X_Dias = _Ds.Tables(3)
            Sb_Llenar_Grafico(Grafico_Ventas_Periodo, _Tbl_Grafico_X_Dias, 0)
            Sb_Llenar_Grafico(Grafico_Desviacion_Estandar, _Tbl_Grafico_X_Dias, 0, True)
        Else
            Sb_Llenar_Grafico(Grafico_Ventas_Periodo, _Tbl_Grafico, 0)
            Sb_Llenar_Grafico(Grafico_Desviacion_Estandar, _Tbl_Grafico, 0, True)
        End If

    End Sub

    Sub Sb_Actualizar_Estadisticas_Un_Solo_Producto(_Row_Producto As DataRow)

        Dim _Ds As DataSet

        Dim _F1 As Date = Dtp_Fecha_Moviminetos_Stock_Desde.Value
        Dim _F2 As Date = Dtp_Fecha_Moviminetos_Stock_Hasta.Value

        Dim _Meses As Integer = DateDiff(DateInterval.Month, _F1, _F2)
        Dim _Dias As Integer = DateDiff(DateInterval.Day, _F1, _F2)

        If Chk_Mostrar_Venta_Por_Dia.Checked And _Dias <= 120 Then
            _Ds = Fx_Ds_Graficos2(_Row_Producto, Nothing)
        Else
            _Ds = Fx_Ds_Graficos(_Row_Producto, Nothing)
        End If

        _Tbl_Movimientos_Acumulados = _Ds.Tables(0)
        _Tbl_Grafico = _Ds.Tables(1)
        _Tbl_Grafico_Tendencia = _Ds.Tables(2)

        GrillaMovAcumulados.DataSource = _Tbl_Movimientos_Acumulados
        '
        With GrillaMovAcumulados
            For I = 1 To 6
                .Columns(I).DefaultCellStyle.Format = "##,###0.00"
                .Columns(I).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Next
        End With

        If Chk_Mostrar_Venta_Por_Dia.Checked And _Dias <= 120 Then
            _Tbl_Grafico_X_Dias = _Ds.Tables(3)
            Sb_Llenar_Grafico(Grafico_Ventas_Periodo, _Tbl_Grafico_X_Dias, 0)
            Sb_Llenar_Grafico(Grafico_Desviacion_Estandar, _Tbl_Grafico_X_Dias, 0, True)
        Else
            Sb_Llenar_Grafico(Grafico_Ventas_Periodo, _Tbl_Grafico, 0)
            Sb_Llenar_Grafico(Grafico_Desviacion_Estandar, _Tbl_Grafico, 0, True)
        End If

    End Sub

    Sub Sb_Llenar_Grafico(_Grafico As Chart,
                          _TblGrafico As DataTable,
                          _Serie As Integer,
                          Optional _Tiene_Varianza As Boolean = False)

        With _Grafico

            ' Set Grid lines and tick marks interval
            .Series(_Serie).XValueType = ChartValueType.Double

            ' Set X axis automatic fitting style
            .ChartAreas(_Serie).AxisX.LabelAutoFitStyle =
             LabelAutoFitStyles.DecreaseFont 'ON LabelAutoFitStyle.DecreaseFont Or LabelAutoFitStyle.IncreaseFont Or LabelAutoFitStyle.WordWrap

            .ChartAreas(_Serie).AxisX.Interval = 1
            .ChartAreas(_Serie).AxisY.Interval = 0
            .ChartAreas(_Serie).AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount

            .ChartAreas(_Serie).AxisX.MajorGrid.Interval = 0
            .ChartAreas(_Serie).AxisX.MajorTickMark.Interval = 1
            .ChartAreas(_Serie).AxisX.MinorGrid.Interval = 0.5
            .ChartAreas(_Serie).AxisX.MinorTickMark.Interval = 0.5
            .ChartAreas(_Serie).AxisX.IsMarginVisible = True

            .ChartAreas(_Serie).AxisY.LabelStyle.Format = "N0"
            ' Calculate Mean
            'Dim mean As Double = .DataManipulator.Statistics.Mean(_Serie)

            Dim _FirstView As New DataView(_TblGrafico)

            '_Serie = 2
            .Series(_Serie).Points.DataBindXY(_FirstView, "Periodo", _FirstView, "Ud")

            '.Series(_Serie).Points.DataBindXY(myReader, "Periodo", myReader, "Ud")


            If _Tiene_Varianza Then

                ' Calculate Median
                Dim median As Double '= .DataManipulator.Statistics.Median("Series1")

                ' Calculate Standard Deviation from the Variance
                Dim variance As Double
                Dim standardDeviation As Double

                Try
                    median = .DataManipulator.Statistics.Median("Series1")
                    ' Calculate Standard Deviation from the Variance
                    variance = .DataManipulator.Statistics.Variance("Series1", True)
                    standardDeviation = Math.Sqrt(variance)
                Catch ex As Exception
                    median = 0
                    variance = 0
                    standardDeviation = 0
                End Try


                '// Set Strip line item
                .ChartAreas(0).AxisY.StripLines(0).IntervalOffset = median - Math.Sqrt(variance)
                .ChartAreas(0).AxisY.StripLines(0).StripWidth = 2.0 * Math.Sqrt(variance)

                '// Set Strip line item
                .ChartAreas(0).AxisY.StripLines(1).IntervalOffset = median

                '// Set Strip line item
                .ChartAreas(0).AxisY.StripLines(2).IntervalOffset = median

                .ChartAreas(0).AxisY.StripLines.Item(0).Text = "Desviación Estandar: " & FormatNumber(standardDeviation, 3)
                .ChartAreas(0).AxisY.StripLines.Item(1).Text = "Mediana: " & FormatNumber(median, 2)

                .ChartAreas(0).AxisY.StripLines.Item(2).Text = median

                LblDesviacionStandar.Text = FormatNumber(standardDeviation, 3)
                LblMedia.Text = FormatNumber(median, 2)

            Else

                Dim _Rango_Fecha As String

                _Rango_Fecha = "Ventas Desde: " &
                               FormatDateTime(Dtp_Fecha_Moviminetos_Stock_Desde.Value, DateFormat.ShortDate) &
                               " Hasta: " &
                               FormatDateTime(Dtp_Fecha_Moviminetos_Stock_Hasta.Value, DateFormat.ShortDate)

                .Titles(0).Text = _Rango_Fecha
                .Titles(1).Text = _Descripcion

                ' Loop through all series
                Dim series As Series

                For Each series In _Grafico.Series

                    ' Set empty points visual appearance attributes
                    series.EmptyPointStyle.Color = Color.Red
                    series.EmptyPointStyle.BorderWidth = 1
                    series.EmptyPointStyle.BorderDashStyle = ChartDashStyle.Dash
                    series.EmptyPointStyle.MarkerSize = 8
                    series.EmptyPointStyle.MarkerStyle = MarkerStyle.Cross
                    series.EmptyPointStyle.MarkerBorderColor = Color.Black
                    series.EmptyPointStyle.MarkerColor = Color.Red

                    If Rdb_Ud1.Checked Then series.LabelFormat = "N0"
                    If Rdb_Ud2.Checked Then series.LabelFormat = "N2"

                    series.LabelFormat = "#0.#,#"

                Next series

                ' Set empty points values of Series1 to average.
                '.Series(_Serie)("EmptyPointValue") = "Average"
                .Series(_Serie)("EmptyPointValue") = "Zero"

            End If

        End With

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
                    .Palette = ChartColorPalette.BrightPastel
                    _Color_Fondo = Color.FromArgb(Global_camvasColor)
                Case Enum_Themas.Oscuro
                    _Color_Grilla = Color.FromArgb(56, 62, 78)
                    _Color_Letras = Color.White
                    _Color_Media = Color.FromArgb(35, 39, 42)
                    _Color_Rango = Color.FromArgb(35, 39, 42)
                    .Palette = ChartColorPalette.BrightPastel
                    _Color_Fondo = Color.FromArgb(Global_camvasColor)
                    Grafico_Tendencias.Series(0).Color = _Color_Rango

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

    Private Sub BtnActualizarInformacion_Click(sender As System.Object, e As System.EventArgs) Handles BtnActualizarInformacion.Click

        Dim _Tabs = Tabs.SelectedTabIndex

        Sb_Llenar_Grillas(Chk_Mostrar_Solo_BLV_FCV_NCV.Checked, True)

        Tabs.SelectedTabIndex = _Tabs

    End Sub

    Sub Sb_Llenar_Grillas(_Mostrar As Boolean,
                          _Cambiar_Tabs_Seleccion As Boolean)

        Dim DocVentas, DocCompras As String

        Me.Cursor = Cursors.WaitCursor

        If _Mostrar Then
            DocVentas = "('BLV','BSV','BLX','FCV','FDB','FDV','FDX','FDZ','FEV','FVL','FVT','FVX','FVZ'," &
                         "'RIN','ESC','FEE','NCV','NCX','NCZ','NEV','NCE')"
            DocCompras = "('BLC','FCC','FCT','FDC','RGA','NCC','NCB')"
        Else
            DocVentas = "('BLV','BSV','BLX','FCV','FDB','FDV','FDX','FDZ','FEV','FVL','FVT','FVX','FVZ'," &
                         "'RIN','ESC','FEE','NCV','NCX','NCZ','NEV','NCE','NVV','GDV')"
            DocCompras = "('BLC','FCC','FCT','FDC','RGA','NCC','NCB','OCC','GRC')"
        End If

        Dim _Nokoen As String = _Sql.Fx_Trae_Dato("MAEEN", "NOKOEN", "KOEN = '" & _Endo & "'")

        Lbl_Nombre_Entidad_Documento.Text = _Endo & ", " & _Nokoen

        If _Cambiar_Tabs_Seleccion Then Tabs.SelectedTabIndex = 1

        If _Tipo_Doc = Tipo_Doc.Ninguno Then
            Tab_03_VtaCom_Entidad.Close()
        ElseIf _Tipo_Doc = Tipo_Doc.Compra Then
            Tab_03_VtaCom_Entidad.Text = "Compras Entidad"
            Sb_Actualizar_Grilla(Grilla_Entidad, DocCompras, _Codigo, Tipo_Doc.Compra, _Endo, False)
            If _Mostrar Then Tabs.SelectedTabIndex = 0
        ElseIf _Tipo_Doc = Tipo_Doc.Venta Then
            Tab_03_VtaCom_Entidad.Text = "Ventas Entidad"
            Sb_Actualizar_Grilla(Grilla_Entidad, DocVentas, _Codigo, Tipo_Doc.Venta, _Endo, Chk_Rotacion_Con_Ent_Excluidas.Checked)
        End If

        Sb_Actualizar_Grilla(GrillaVentas, DocVentas, _Codigo, Tipo_Doc.Venta, "", Chk_Rotacion_Con_Ent_Excluidas.Checked)
        Sb_Actualizar_Grilla(GrillaCompras, DocCompras, _Codigo, Tipo_Doc.Compra, "", True)

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub Sb_Grilla_CellDoubleClick(sender As System.Object,
                                          e As System.Windows.Forms.DataGridViewCellEventArgs)

        Me.Enabled = False

        Dim _Idmaeedo As Integer = sender.Rows(sender.CurrentRow.Index).Cells("IDMAEEDO").Value

        Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Me.Enabled = True

    End Sub

    Private Sub BtnKardex_Click(sender As System.Object, e As System.EventArgs) Handles BtnKardex.Click

        If Fx_Tiene_Permiso(Me, "Prod002") Then
            Dim _Mostrar_Alerta_Stock As Boolean = Fr_Alerta_Stock.Visible

            If _Mostrar_Alerta_Stock Then Fr_Alerta_Stock.Close()

            Dim Fm As New Frm_Kardex_X_Producto_Lista
            Dim Oculto As String = _Sql.Fx_Trae_Dato("MAEPR", "ATPR", "KOPR = '" & _Codigo & "'")
            If Oculto = "OCU" Then
                Fm.ChkMostrarOcultos.Checked = True
            End If
            Fm.Pro_Mostrar_Kardex_Asociados = Chk_Agrupar_Asociados.Checked
            Fm.Pro_Codigo = _Codigo
            Fm.ShowDialog(Me)
            Fm.Dispose()

            If _Mostrar_Alerta_Stock Then
                Fr_Alerta_Stock = New AlertCustom(_Codigo, _Ud)
                ShowLoadAlert(Fr_Alerta_Stock, Me, True, 10, Chk_Agrupar_Asociados.Checked)
            End If
        End If

    End Sub

    Private Sub GrillaVentas_CellEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrillaVentas.CellEnter
        Try
            LblEntFisicaVentas.Text = "Entidad física: " &
            Trim(GrillaVentas.Rows(GrillaVentas.CurrentRow.Index).Cells("ENDOFI").Value) & " - " &
            Trim(GrillaVentas.Rows(GrillaVentas.CurrentRow.Index).Cells("NOMENDOFI").Value)
        Catch ex As Exception
            LblEntFisicaVentas.Text = String.Empty
        End Try
    End Sub

    Private Sub GrillaCompras_CellEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrillaCompras.CellEnter
        Try
            LblEntFisicaCompras.Text = "Entidad física: " &
            Trim(GrillaCompras.Rows(GrillaCompras.CurrentRow.Index).Cells("ENDOFI").Value) & " - " &
           Trim(GrillaCompras.Rows(GrillaCompras.CurrentRow.Index).Cells("NOMENDOFI").Value)
        Catch ex As Exception
            LblEntFisicaCompras.Text = String.Empty
        End Try
    End Sub

    Sub Sb_ActualizarGrilla_Alternativos()

        Consulta_sql = "Select KOPRAL,NOKOPRAL,KOEN," & vbCrLf &
                       "(SELECT TOP 1 NOKOEN FROM MAEEN WHERE KOEN = TABCODAL.KOEN) AS PROVEEDOR FROM TABCODAL" & vbCrLf &
                       "WHERE KOPR = '" & _Codigo & "' Order by KOEN"

        With Grilla_Alternativos

            .DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
            OcultarEncabezadoGrilla(Grilla_Alternativos, True)

            .Columns("KOPRAL").Width = 120
            .Columns("KOPRAL").HeaderText = "Código alternativo"
            .Columns("KOPRAL").Visible = True

            .Columns("KOEN").Width = 100
            .Columns("KOEN").HeaderText = "Proveedor"
            .Columns("KOEN").Visible = True

            .Columns("PROVEEDOR").Width = 550
            .Columns("PROVEEDOR").HeaderText = "Razón social"
            .Columns("PROVEEDOR").Visible = True

        End With

    End Sub

    Private Sub Grilla_Alternativos_CellEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

        Dim _Endo As String = Grilla_Alternativos.Rows(Grilla_Alternativos.CurrentRow.Index).Cells("KOEN").Value

        Dim IdGRC, IdFCC As String
        IdGRC = _Sql.Fx_Trae_Dato("MAEDDO", "IDMAEDDO",
                                "(KOPRCT = '" & _Codigo &
                                "') AND (TIDO = 'GRC') And (ENDO = '" & _Endo & "') ORDER BY FEEMLI DESC")

        IdFCC = _Sql.Fx_Trae_Dato("MAEDDO", "IDMAEDDO",
                                "(KOPRCT = '" & _Codigo &
                                "') AND (TIDO = 'FCC') And (ENDO = '" & _Endo & "') ORDER BY FEEMLI DESC")

        'IdOCC = Grilla.Rows(Grilla.CurrentRow.Index).Cells("IdOCC").Value
        'IdGRC = Grilla.Rows(Grilla.CurrentRow.Index).Cells("IdGRC").Value

        Consulta_sql = My.Resources.Recursos_Info_Producto.UltimasOccGrcFcc_Pendientes
        Consulta_sql = Replace(Consulta_sql, "#IdFcc#", Val(IdFCC))
        Consulta_sql = Replace(Consulta_sql, "#IdGrc#", Val(IdGRC))

        With Grilla_DetalleDocAlternativos


            .DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
            OcultarEncabezadoGrilla(Grilla_DetalleDocAlternativos, True)

            .Columns("Obs").HeaderText = "Periodo"
            .Columns("Obs").Width = 80
            .Columns("Obs").Visible = True

            .Columns("Tipo").HeaderText = "Tipo"
            .Columns("Tipo").Width = 30
            .Columns("Tipo").Visible = True

            .Columns("Numero").HeaderText = "Número"
            .Columns("Numero").Width = 75
            .Columns("Numero").Visible = True

            .Columns("EntFisica").HeaderText = "Ent. física"
            .Columns("EntFisica").Width = 120
            .Columns("EntFisica").Visible = True

            .Columns("Razon").HeaderText = "Proveedor"
            .Columns("Razon").Width = 120
            .Columns("Razon").Visible = True

            .Columns("Fecha").HeaderText = "Fecha"
            .Columns("Fecha").Width = 90
            .Columns("Fecha").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("Fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha").Visible = True
            'Obs,Tipo,Numero,Razon,EntFisica,Fecha,CantUd1,Un1,CantUd2,Un2

            .Columns("UD").Width = 50
            .Columns("UD").Visible = True

            .Columns("Cant").Width = 50
            .Columns("Cant").DefaultCellStyle.Format = "##,###0.00"
            .Columns("Cant").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Cant").Visible = True

            If Not Fx_Tiene_Permiso(Me, "NO00001", , False) Then

                .Columns("PPPRNE").HeaderText = "Precio Neto"
                .Columns("PPPRNE").Visible = True
                .Columns("PPPRNE").Width = 70
                .Columns("PPPRNE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("PPPRNE").DefaultCellStyle.Format = "$ ###,##"
                .Columns("PPPRNE").ReadOnly = True

                .Columns("PC_DESC").HeaderText = "% Dc"
                .Columns("PC_DESC").Visible = True
                .Columns("PC_DESC").Width = 40
                .Columns("PC_DESC").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("PC_DESC").DefaultCellStyle.Format = "##,##.## %"
                .Columns("PC_DESC").ReadOnly = True

                .Columns("VANELI").HeaderText = "Valor Neto"
                .Columns("VANELI").Visible = True
                .Columns("VANELI").Width = 70
                .Columns("VANELI").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("VANELI").DefaultCellStyle.Format = "$ ###,##"
                .Columns("VANELI").ReadOnly = True
            End If
        End With

    End Sub

    Private Sub BtnCodigoAlternativos_Click(sender As System.Object, e As System.EventArgs) Handles BtnCodigoAlternativos.Click
        If Fx_Tiene_Permiso(Me, "Prod020") Then
            Dim _Descripcion As String = _Row_Producto.Item("NOKOPR")
            Dim _Rtu As Double = _Row_Producto.Item("RLUD")

            Dim Fm As New Frm_CodAlternativo_Ver
            Fm.TxtCodigo.Text = _Codigo

            Fm.Txtdescripcion.Text = _Descripcion
            Fm.TxtRTU.Text = _Rtu
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If
    End Sub

    Private Sub BtnFiltroBodegas_Click(sender As System.Object, e As System.EventArgs) Handles BtnFiltroBodegas.Click

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Bodegas,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Bodegas, "",
                               _Filtro_Bodegas_Todas, False) Then

            _Tbl_Filtro_Bodegas = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Bodegas_Todas = _Filtrar.Pro_Filtro_Todas

            Call Btn_Actualizar_Grafico_Click(Nothing, Nothing)
            'Sb_Actualizar_Estadisticas_Un_Solo_Producto(_Row_Producto)

        End If

    End Sub

    Private Sub BtnStockPorBodegas_Click(sender As System.Object, e As System.EventArgs) Handles BtnStockPorBodegas.Click
        If Not Fr_Alerta_Stock.Visible Then
            Fr_Alerta_Stock = New AlertCustom(_Codigo, _Ud)
            ShowLoadAlert(Fr_Alerta_Stock, Me, True, 10, Chk_Agrupar_Asociados.Checked)
        Else
            Fr_Alerta_Stock.Close()
        End If
    End Sub

    Private Sub Frm_EstadisticaProducto_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Info_Prod_Otra_Empresa_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Info_Prod_Otra_Empresa.Click

        If Fx_Tiene_Permiso(Me, "Prod057") Then

            Dim _Cadena_ConexionSQL_Server_Original = Cadena_ConexionSQL_Server
            Dim _Cadena_ConexionSQL_Seleccionada = String.Empty

            Try

                Dim DatosConex As New ConexionBK

                Dim Directorio As String = Application.StartupPath & "\Data\"
                Dim _Exists = System.IO.File.Exists(Directorio & "Conexiones.xml")

                If Not _Exists Then
                    DatosConex.WriteXml(Directorio & "Conexiones.xml")
                    MessageBoxEx.Show("Arvhico XML creado correctamente", "Crear XML de Conexión",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                DatosConex.ReadXml(Directorio & "Conexiones.xml")

                Dim Frm_ConexionBD As New Frm_ConexionBD
                Frm_ConexionBD.BtnAgregar.Visible = False
                Frm_ConexionBD.BtnGenerateKey.Visible = False
                Frm_ConexionBD.ShowDialog(Me)

                If Frm_ConexionBD.NombreConexionActiva = String.Empty Then
                    Frm_ConexionBD.Dispose()
                    Return
                Else
                    _Cadena_ConexionSQL_Seleccionada = Fx_CadenaConexionSQL(Frm_ConexionBD.NombreConexionActiva, DatosConex)
                End If
                Frm_ConexionBD.Dispose()

                Cadena_ConexionSQL_Server = _Cadena_ConexionSQL_Seleccionada

                Dim _Codigo = TxtCodigoPrincipal.Text

                Fx_Conectar_Empresa(Me, True)

                If Fx_Tiene_Permiso(Me, "Prod009") Then

                    Dim _RowProducto As DataRow = Fx_Producto_en_otra_base(_Codigo)

                    If Not (_RowProducto Is Nothing) Then

                        _Codigo = _RowProducto.Item("KOPR")

                        Dim Fm As New Frm_EstadisticaProducto(_Codigo)
                        Fm.Btn_Info_Prod_Otra_Empresa.Visible = False
                        Fm._Correr_a_la_derecha = True
                        Fm.ShowDialog(Me)
                        Fm.Dispose()

                    End If

                End If

            Catch ex As Exception
                MessageBoxEx.Show(ex.Message)
            Finally
                Cadena_ConexionSQL_Server = _Cadena_ConexionSQL_Server_Original
                Fx_Conectar_Empresa(Me, True)
                ' SQL_ServerClass.Sb_Cerrar_Conexion(cn1)
            End Try

        End If

    End Sub

    Function Fx_Producto_en_otra_base(_Codigo As String) As DataRow

        Consulta_sql = "Select * From MAEPR Where KOPR = '" & _Codigo & "'"
        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        If CBool(_Tbl.Rows.Count) Then

            Dim _Kopr = Trim(_Tbl.Rows(0).Item("KOPR"))
            Dim _Nokopr = Trim(_Tbl.Rows(0).Item("NOKOPR"))

            'If 
            'MessageBoxEx.Show(Me, "Código: " & _Kopr & ", " & _Nokopr, "Producto encontrado", _
            '                                 MessageBoxButtons.OK, MessageBoxIcon.Information)

            Return _Tbl.Rows(0)
            'End If
        Else

            If MessageBoxEx.Show(Me, "No se encontro coincidencia en " & RazonEmpresa & vbCrLf &
             "¿Desea buscar otro producto?", "Producto no encontrado", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) = Windows.Forms.DialogResult.Yes Then

                Return Fx_Buscar_Producto()

            End If


        End If

        Return Nothing

    End Function

    Function Fx_Buscar_Producto() As DataRow

        If Fx_Tiene_Permiso(Me, "Prod012") Then

            Dim Fm As New Frm_BkpPostBusquedaEspecial_Mt
            Fm.Pro_Tipo_Lista = "C"
            Fm.Pro_Lista_Busqueda = ModListaPrecioVenta
            Fm.Pro_Sucursal_Busqueda = ModSucursal
            Fm.Pro_Bodega_Busqueda = ModBodega
            Fm.Txtdescripcion.Text = ""
            Fm.Pro_Mostrar_Info = False
            Fm.Pro_Actualizar_Precios = False

            Codigo_abuscar = String.Empty

            Fm.ShowDialog(Me)

            If Fm.Pro_Seleccionado Then
                Return Fm.Pro_Tbl_Producto_Seleccionado.Rows(0)
            Else
                Return Nothing
            End If

        End If

    End Function

    Private Sub Sb_Rdb_Ud_CheckedChanged(sender As System.Object, e As System.EventArgs)
        If CType(sender, DevComponents.DotNetBar.Controls.CheckBoxX).Checked Then
            If Rdb_Ud1.Checked Then
                _Ud = 1
            Else
                _Ud = 2
            End If
            If _AcConSwit Then Call Btn_Actualizar_Grafico_Click(Nothing, Nothing) 'Sb_Actualizar_Estadisticas_Un_Solo_Producto(_Row_Producto)
        End If
    End Sub

    Sub Sb_Actualizar_Grafico_Movimiento_Stock(_Empresa As String)

        Dim _Codigo = _Row_Producto.Item("KOPR")
        Dim _Agrupar_Reemplazos As Boolean = Chk_Agrupar_Asociados.Checked

        If _Agrupar_Reemplazos And CBool(_Tbl_Productos_Hermanos.Rows.Count) Then

            Dim _Filtro_Prod_Hermanos = Generar_Filtro_IN(_Tbl_Productos_Hermanos, "", "KOPR", False, False, "'")

            Consulta_sql = "Select KOPR From MAEPR Where KOPR IN " & _Filtro_Prod_Hermanos & vbCrLf &
                           "Union" & vbCrLf &
                           "Select KOPR From MAEPR Where KOPR = '" & _Codigo & "'"
        Else
            Consulta_sql = "Select Top 1 KOPR From MAEPR Where KOPR = '" & _Codigo & "'"
        End If


        Dim _TblProductos As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim _Filtro_Productos As String
        Dim _Filtro_Bodegas As String

        _Filtro_Productos = Generar_Filtro_IN(_TblProductos, "", "KOPR", False, False, "'")
        _Filtro_Bodegas = Generar_Filtro_IN(_Tbl_Filtro_Bodegas, "Chk", "Codigo", False, True, "'")


        If _Filtro_Bodegas_Todas Then
            _Filtro_Bodegas = String.Empty
        Else
            _Filtro_Bodegas = "And D.EMPRESA+D.SULIDO+D.BOSULIDO IN " & _Filtro_Bodegas
        End If

        _Sql.Sb_Eliminar_Tabla_De_Paso("Zw_TblStockConsolid")

        Dim _Fecha_Desde = Dtp_Fecha_Moviminetos_Stock_Desde.Value
        Dim _Fecha_Hasta = ultimodiadelmes(Dtp_Fecha_Moviminetos_Stock_Hasta.Value)

        Dim Fecha_ As Date = _Fecha_Desde 'DateAdd(DateInterval.Day,-1 'Primerdiadelmes(_Fecha_Desde)


        Consulta_sql = My.Resources._24_Recursos.Consolidación_de_Stock_por_producto
        Consulta_sql = Replace(Consulta_sql, "#Empresa#", _Empresa)
        Consulta_sql = Replace(Consulta_sql, "#Codigo#", _Filtro_Productos)
        Consulta_sql = Replace(Consulta_sql, "#Fecha#", Format(_Fecha_Desde, "yyyyMMdd"))
        Consulta_sql = Replace(Consulta_sql, "#FiltroBodegas#", _Filtro_Bodegas)
        Consulta_sql = Replace(Consulta_sql, "#Int#", 1)
        Consulta_sql = Replace(Consulta_sql, "AND D.EMPRESA  =@Empresa", String.Empty)
        Consulta_sql = Replace(Consulta_sql, "AND D.SULIDO   =@Sucursal", String.Empty)

        _Sql.Ej_consulta_IDU(Consulta_sql)

        Consulta_sql = "SELECT ROUND(ISNULL(SUM(CantidadUd1),0),2) AS StockUd1," &
                       "ROUND(ISNULL(SUM(CantidadUd2),0),2) AS StockUd2" & vbCrLf &
                       "FROM Zw_TblStockConsolid" & vbCrLf &
                       "WHERE KOPRCT In " & _Filtro_Productos

        Dim Tbl_StMes As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        _Sql.Sb_Eliminar_Tabla_De_Paso("Zw_TblStockConsolid")



        '-----------------------------------------------------------------------------------------------------------------

        Dim _StockUd As Double = Tbl_StMes.Rows(0).Item("StockUd" & _Ud)
        'Dim _StockUd2 As Double = Tbl_StMes.Rows(0).Item("StockUd2")

        Dim F1 As Integer = 1 'Primerdiadelmes(_Fecha_Inicio).Day
        Dim F2 As Integer = DateDiff(DateInterval.Day, _Fecha_Desde, _Fecha_Hasta) '+ 30 '(365 / 4) + 10 'ultimodiadelmes(_Fecha_Inicio).Day


        Dim Fecha As Date = _Fecha_Desde
        Dim Contador = 0
        Dim Stock_Diaro(30, 30) As String

        'Dim _StockUd1_Contador As Double = _StockUd1
        'Dim _StockUd2_Contador As Double = _StockUd2
        Dim FechaNw As Date = Primerdiadelmes(_Fecha_Desde)

        Grafico_Mov_Stock.Series("Series1").Points.Clear()
        Grafico_Mov_Stock.Series("Series2").Points.Clear()
        Grafico_Mov_Stock.Series("Series3").Points.Clear()
        Grafico_Mov_Stock.Series("Series4").Points.Clear()
        Grafico_Mov_Stock.Series("Series5").Points.Clear()
        Grafico_Mov_Stock.Series("Series6").Points.Clear()
        Grafico_Mov_Stock.Series("Series7").Points.Clear()


        Grafico_Mov_Stock.Series("Series1").EmptyPointStyle.Color = Color.Red
        Grafico_Mov_Stock.Series("Series1").EmptyPointStyle.BorderWidth = 1
        Grafico_Mov_Stock.Series("Series1").EmptyPointStyle.BorderDashStyle = ChartDashStyle.Dash
        Grafico_Mov_Stock.Series("Series1").EmptyPointStyle.MarkerSize = 10
        Grafico_Mov_Stock.Series("Series1").EmptyPointStyle.MarkerStyle = MarkerStyle.Cross
        Grafico_Mov_Stock.Series("Series1").EmptyPointStyle.MarkerBorderColor = Color.Black
        Grafico_Mov_Stock.Series("Series1").EmptyPointStyle.MarkerColor = Color.Red

        Grafico_Mov_Stock.Series("Series1")("EmptyPointValue") = "Zero"

        Grafico_Mov_Stock.Series("Series1").XValueType = ChartValueType.Date
        Grafico_Mov_Stock.ChartAreas(0).AxisY.LabelStyle.Format = "N0"


        For Each series In Grafico_Mov_Stock.Series
            series.LabelFormat = "N0"
        Next
        Grafico_Mov_Stock.Series("Series1").YValueType = ChartValueType.Double

        ' Grafico_Mov_Stock.Series.LabelFormat = "N0"

        'Grafico_Mov_Stock.Series.RemoveAt(2)

        Dim _Ultimo_Nro As String = Math.Round(_StockUd, 0)

        Consulta_sql = My.Resources.Recursos_Info_Producto.SQLQuery_Mov_Stock_Diario_Tabla

        Consulta_sql = Replace(Consulta_sql, "#Empresa#", _Empresa)
        Consulta_sql = Replace(Consulta_sql, "#Ud#", _Ud)
        Consulta_sql = Replace(Consulta_sql, "#Codigo#", _Filtro_Productos)
        Consulta_sql = Replace(Consulta_sql, "#Fecha_Desde#", Format(_Fecha_Desde, "yyyyMMdd"))
        Consulta_sql = Replace(Consulta_sql, "#Fecha_Hasta#", Format(FechaDelServidor, "yyyyMMdd"))
        Consulta_sql = Replace(Consulta_sql, "#FiltroBodegas#", Replace(_Filtro_Bodegas, "D.", "MAEDDO."))

        Dim Tbl_ As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim _Stock_Solicitado As Double
        Dim _Stock_Ingreso As Double
        Dim _Stock_Salida As Double

        Grafico_Mov_Stock.Series("Series6").Points.AddXY(FechaNw, Input_Stock_Minimo.Value)

        Dim _Quibre As Boolean = True

        Consulta_sql = "Select Top 1 * From MAEDDO D" & vbCrLf &
                       "Where KOPRCT In " & _Filtro_Productos & " And D.TIDO In ('GRC','GRI','FCC')" & Space(1) & _Filtro_Bodegas & " Order by IDMAEEDO Desc"
        Dim _RowUltCompra As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        For F1 = F1 To F2

            System.Windows.Forms.Application.DoEvents()

            Dim _Fecha_Actual As String = Format(FechaNw, "yyyyMMdd")

            Dim _Row_renglon() As DataRow
            _Row_renglon = Tbl_.Select("FECHA='" & _Fecha_Actual & "'")

            If _Row_renglon.Length > 0 Then
                Dim _Row As DataRow = _Row_renglon(0)

                _Stock_Solicitado = _Row.Item("Solicitud_Compra_Ud")
                _Stock_Ingreso = _Row.Item("Ingreso_Compra_Ud") + _Row.Item("Ingreso_Interno_Ud")
                _Stock_Salida = _Row.Item("Salida_Venta_Ud") + _Row.Item("Salida_Interno_Ud")

                _StockUd += _Stock_Ingreso + _Stock_Salida '_Row_renglon(0).Item("Mov_Ud" & _Ud) 'Tbl_.Rows(0).Item("Mov_Ud" & _Ud)
            End If

            Dim _Stock As String = Math.Round(_StockUd, 0)

            If F1 = 1 Then
                Grafico_Mov_Stock.Series("Series2").Points.AddXY(FechaNw, _Ultimo_Nro)
            Else

                If CBool(_Stock_Solicitado) Then
                    Grafico_Mov_Stock.Series("Series7").Points.AddXY(FechaNw, 1)
                End If

                If CBool(_Stock_Salida) Then
                    Grafico_Mov_Stock.Series("Series3").Points.AddXY(FechaNw, _Stock_Salida * -1)
                End If

                If CBool(_Stock_Ingreso) Then
                    Grafico_Mov_Stock.Series("Series4").Points.AddXY(FechaNw, _Stock_Ingreso)
                End If

                If _Ultimo_Nro <> _Stock Then
                    Grafico_Mov_Stock.Series("Series2").Points.AddXY(FechaNw, _Stock)
                End If

            End If


            _Ultimo_Nro = _Stock

            If _Stock = 0 Then
                If _Quibre Then
                    _Stock = Nothing
                    _Quibre = False
                    Grafico_Mov_Stock.Series("Series1").Points.AddXY(FechaNw, _Stock)
                End If
            Else
                _Quibre = True
                Grafico_Mov_Stock.Series("Series1").Points.AddXY(FechaNw, _Stock)
            End If

            _Stock_Solicitado = 0
            _Stock_Salida = 0
            _Stock_Ingreso = 0

            Grafico_Mov_Stock.Series("Series5").Points.AddXY(FechaNw, Input_Stock_Minimo.Value)

            FechaNw = DateAdd(DateInterval.Day, 1, FechaNw)

        Next

        Grafico_Mov_Stock.Series("Series6").Points.AddXY(FechaNw, Input_Stock_Minimo.Value) ' NRO STOCK CRITICO

        Grafico_Mov_Stock.ChartAreas("Default").AxisX.IntervalType = DateTimeIntervalType.Days

        Sb_Actualizar_Grilla_Mensual()

    End Sub

    Private Sub Btn_Actualizar_Grafico_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Actualizar_Grafico.Click

        If Dtp_Fecha_Moviminetos_Stock_Hasta.Value > FechaDelServidor() Then
            MessageBoxEx.Show(Me, "Fecha ""Hasta""  no puede ser mayor al día de hoy " &
                              FormatDateTime(FechaDelServidor, DateFormat.LongDate),
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Dtp_Fecha_Moviminetos_Stock_Hasta.Value = FechaDelServidor()
        End If

        If Dtp_Fecha_Moviminetos_Stock_Hasta.Value >= Dtp_Fecha_Moviminetos_Stock_Desde.Value Then

            Sb_Llenar_Grillas(Chk_Mostrar_Solo_BLV_FCV_NCV.Checked, False)

            Dim _Meses = DateDiff(DateInterval.Month, Dtp_Fecha_Moviminetos_Stock_Desde.Value,
                                  Dtp_Fecha_Moviminetos_Stock_Hasta.Value)


            If _Meses <= 25 Then

                Me.Enabled = False

                Try
                    'Dim Fm_Espera As New Frm_Form_Esperar
                    'Fm_Espera.BarraCircular.IsRunning = True
                    'Fm_Espera.Show()

                    If Chk_Agrupar_Asociados.Checked And CBool(_Tbl_Productos_Hermanos.Rows.Count) Then

                        Dim _Filtro_Prod_Hermanos = Generar_Filtro_IN(_Tbl_Productos_Hermanos, "", "KOPR", False, False, "'")
                        Consulta_sql = "Select KOPR From MAEPR Where KOPR IN " & _Filtro_Prod_Hermanos & vbCrLf &
                                       "Union" & vbCrLf &
                                       "Select KOPR From MAEPR Where KOPR = '" & _Codigo & "'"
                        Dim _TblProductos As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                        Sb_Actualizar_Estadisticas_Varios_Productos(_TblProductos)
                    Else
                        Sb_Actualizar_Estadisticas_Un_Solo_Producto(_Row_Producto)
                    End If

                    Sb_Actualizar_Grafico_Movimiento_Stock(ModEmpresa)

                    'Fm_Espera.Close()
                    'Fm_Espera.Dispose()
                Catch ex As Exception
                Finally
                    Me.Enabled = True
                End Try

            Else
                MessageBoxEx.Show(Me, "El intervalo de tiempo no puede ser mayor a 25 meses", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If


        Else
            MessageBoxEx.Show(Me, "La fecha ""Hasta"" no puede ser menor que la fecha ""Desde""", "Validación, Fecha tiempo reposición", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Dtp_Fecha_Moviminetos_Stock_Hasta.Value = FechaDelServidor()
        End If

        Sb_Grafico_Tendencias()
        Sb_Linea_Tendencia()

        Sb_Formato_Graficos(Grafico_Desviacion_Estandar, 0, 0)

        For i = 0 To 7
            Sb_Formato_Graficos(Grafico_Mov_Stock, i, i)
        Next

        Sb_Formato_Graficos(Grafico_Tendencias, 0, 0)
        Sb_Formato_Graficos(Grafico_Ventas_Periodo, 0, 0)

    End Sub

    Private Sub Chk_Grafica_Ventas_Solo_Entidad_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Chk_Grafica_Ventas_Solo_Entidad.CheckedChanged
        Sb_Actualizar_Grafico_Movimiento_Stock(ModEmpresa)
    End Sub

    Sub Sb_Ver_Etiquetas_Grafico_Tiempo_Reposicion()

        'Grafico_Mov_Stock.Series("Series1").IsValueShownAsLabel = False
        Grafico_Mov_Stock.Series("Series2").IsValueShownAsLabel = Chk_Stock_Movimiento.Checked
        Grafico_Mov_Stock.Series("Series3").IsValueShownAsLabel = Chk_Stock_Salidas.Checked
        Grafico_Mov_Stock.Series("Series4").IsValueShownAsLabel = Chk_Stock_Ingresos.Checked
        'Grafico_Mov_Stock.Series("Series5").IsValueShownAsLabel = False
        Grafico_Mov_Stock.Series("Series6").IsValueShownAsLabel = Chk_Stock_Minimo.Checked

    End Sub

    Private Sub Btn_Mnu_Pr_Codigo_De_Reemplazo_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Mnu_Pr_Codigo_De_Reemplazo.Click

        Dim Fm As New Frm_ProductosReemplazo(_Codigo)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Ver_Archivos_Adjuntos_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Ver_Archivos_Adjuntos.Click
        If Fx_Tiene_Permiso(Me, "Prod045") Then
            Dim Fm As New Frm_Adjuntar_Archivos_X_Productos(_Codigo)
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If
    End Sub

    Sub Sb_Actualizar_Grilla_Mensual_Old()


        Try

            Dim points As New List(Of Double)()

            Dim Punto As Double = 0
            points.Add(Punto)

            McsSemanales.DataPoints = points
            MchMensuales.DataPoints = points

            'LabelX2.Text = "..."


            If Chk_Agrupar_Asociados.Checked Then

                Consulta_sql = "SELECT KOPR FROM MAEPR WHERE KOPR = '" & _Codigo & "'" & vbCrLf & vbCrLf &
                               "UNION" & vbCrLf &
                               "SELECT KOPR FROM TABREMP WHERE KOPRREM = '" & _Codigo & "' AND KOPR <> '" & _Codigo & "' "
            Else
                Consulta_sql = "Select Top 1 * From MAEPR Where KOPR = '" & _Codigo & "'"
            End If

            Dim _TblProductos As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            Dim _Filtro_Productos As String

            _Filtro_Productos = Generar_Filtro_IN(_TblProductos, "", "KOPR", False, False, "'")


            Dim F1 As Date = Dtp_Fecha_Moviminetos_Stock_Desde.Value
            F1 = Primerdiadelmes(F1)

            Dim _Fecha_Inicio As Date = F1
            Dim _Fecha_Fin As Date = ultimodiadelmes(Dtp_Fecha_Moviminetos_Stock_Hasta.Value)

            Dim _Filtro_Entidades_Excluidas As String = String.Empty

            If Not Chk_Rotacion_Con_Ent_Excluidas.Checked Then

                _Filtro_Entidades_Excluidas = "And LTRIM(RTRIM(ENDO))+RTRIM(LTRIM(SUENDO))" & vbCrLf &
                "NOT IN (SELECT  LTRIM(RTRIM(Codigo))+LTRIM(RTRIM(Sucursal)) From " & _Global_BaseBk & "Zw_TblInf_EntExcluidas" & vbCrLf &
                "Where Funcionario = @CodFuncionario And Excluida in ('V','A','T'))" & vbCrLf

            End If

            Consulta_sql = My.Resources.Recursos_Asis_Compras.SQLQuery_Info_Estadistica_X_Producto
            Consulta_sql = Replace(Consulta_sql, "#Codigo#", _Filtro_Productos)
            Consulta_sql = Replace(Consulta_sql, "#Empresa#", ModEmpresa)
            Consulta_sql = Replace(Consulta_sql, "#Funcionario#", FUNCIONARIO)
            Consulta_sql = Replace(Consulta_sql, "#FechaInicio#", Format(_Fecha_Inicio, "yyyyMMdd"))
            Consulta_sql = Replace(Consulta_sql, "#FechaTermino#", Format(_Fecha_Fin, "yyyyMMdd"))
            Consulta_sql = Replace(Consulta_sql, "#Mes#", 1)
            Consulta_sql = Replace(Consulta_sql, "#Filtro_Entidades_Excluidas#", _Filtro_Entidades_Excluidas)

            Dim _Filtro_Bodega As String

            If _Filtro_Bodegas_Todas Then
                _Filtro_Bodega = String.Empty
            Else
                _Filtro_Bodega = Generar_Filtro_IN(_Tbl_Filtro_Bodegas, "Chk", "Codigo", False, True, "'")
                _Filtro_Bodega = "And EMPRESA+SULIDO+BOSULIDO In " & _Filtro_Bodega
            End If

            Consulta_sql = Replace(Consulta_sql, "#Filtro_Bodega#", _Filtro_Bodega)


            Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

            MchMensuales.ChartType = eMicroChartType.Line

            LlenarPointMchar(MchMensuales, _Ds.Tables(0), 1)

            'RemoveHandler Grilla_Mensual.CellEnter, AddressOf Sb_Actualizar_Grilla_Semanas

            With Grilla_Mensual
                .DataSource = Nothing
                .DataSource = _Ds.Tables(0)
                .Columns("Periodo").HeaderText = "Periodo"
                .Columns("periodo").Width = 130
                .Columns("Ud1").Width = 60
                .Columns("Ud1").DefaultCellStyle.Format = "##,###0.00"
                .Columns("Ud1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Ud2").Width = 60
                .Columns("Ud2").DefaultCellStyle.Format = "##,###0.00"
                .Columns("Ud2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Mes").Visible = False
            End With

            'Sb_Actualizar_Grilla_Semanas()

            'AddHandler Grilla_Mensual.CellEnter, AddressOf Sb_Actualizar_Grilla_Semanas
        Catch ex As Exception

        End Try
    End Sub

    Sub Sb_Actualizar_Grilla_Mensual()

        Try

            'LabelX2.Text = "..."

            If Chk_Agrupar_Asociados.Checked Then

                Consulta_sql = "SELECT KOPR FROM MAEPR WHERE KOPR = '" & _Codigo & "'" & vbCrLf & vbCrLf &
                               "UNION" & vbCrLf &
                               "SELECT KOPR FROM TABREMP WHERE KOPRREM = '" & _Codigo & "' AND KOPR <> '" & _Codigo & "' "
            Else
                Consulta_sql = "Select Top 1 * From MAEPR Where KOPR = '" & _Codigo & "'"
            End If

            Dim _TblProductos As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            Dim _Filtro_Productos As String

            _Filtro_Productos = Generar_Filtro_IN(_TblProductos, "", "KOPR", False, False, "'")


            Dim F1 As Date = Dtp_Fecha_Moviminetos_Stock_Desde.Value
            F1 = Primerdiadelmes(F1)

            Dim _Fecha_Inicio As Date = F1
            Dim _Fecha_Fin As Date = ultimodiadelmes(Dtp_Fecha_Moviminetos_Stock_Hasta.Value)

            Dim _Filtro_Entidades_Excluidas As String = String.Empty

            If Not Chk_Rotacion_Con_Ent_Excluidas.Checked Then

                _Filtro_Entidades_Excluidas = "And LTRIM(RTRIM(ENDO))+RTRIM(LTRIM(SUENDO))" & vbCrLf &
                "NOT IN (SELECT  LTRIM(RTRIM(Codigo))+LTRIM(RTRIM(Sucursal)) From " & _Global_BaseBk & "Zw_TblInf_EntExcluidas" & vbCrLf &
                "Where Funcionario = @CodFuncionario And Excluida in ('V','A','T'))" & vbCrLf

            End If

            Consulta_sql = My.Resources.Recursos_Asis_Compras.SQLQuery_Info_Estadistica_X_Producto
            Consulta_sql = Replace(Consulta_sql, "#Codigo#", _Filtro_Productos)
            Consulta_sql = Replace(Consulta_sql, "#Empresa#", ModEmpresa)
            Consulta_sql = Replace(Consulta_sql, "#Funcionario#", FUNCIONARIO)
            Consulta_sql = Replace(Consulta_sql, "#FechaInicio#", Format(_Fecha_Inicio, "yyyyMMdd"))
            Consulta_sql = Replace(Consulta_sql, "#FechaTermino#", Format(_Fecha_Fin, "yyyyMMdd"))
            Consulta_sql = Replace(Consulta_sql, "#Mes#", 1)
            Consulta_sql = Replace(Consulta_sql, "#Filtro_Entidades_Excluidas#", _Filtro_Entidades_Excluidas)
            Consulta_sql = Replace(Consulta_sql, "#_Global_BaseBk#", _Global_BaseBk)


            Dim _Filtro_Bodega As String

            If _Filtro_Bodegas_Todas Then
                _Filtro_Bodega = String.Empty
            Else
                _Filtro_Bodega = Generar_Filtro_IN(_Tbl_Filtro_Bodegas, "Chk", "Codigo", False, True, "'")
                _Filtro_Bodega = "And EMPRESA+SULIDO+BOSULIDO In " & _Filtro_Bodega
            End If

            Dim _Filtro_Documentos As String

            'If Chk_Incluir_Salidas_GDI_OT.Checked Then
            _Filtro_Documentos = "And (TIDO IN ('FCV', 'FDB', 'FDV', 'FDX', 'FDZ', 'FEV', 'FVL', 'FVT', 'FVX', 'FVZ','FEE', 'BLV','GDV','GDP','NCE', 'NCV', 'NCX', 'NCZ', 'NEV') Or " &
                                          "TIDO In ('GDI','GRI') And ARCHIRST = 'POTD')"
            'Else
            '_Filtro_Documentos = "And TIDO IN ('FCV', 'FDB', 'FDV', 'FDX', 'FDZ', 'FEV', 'FVL', 'FVT', 'FVX', 'FVZ','FEE', 'BLV','GDV','GDP','NCE', 'NCV', 'NCX', 'NCZ', 'NEV')"
            'End If

            Consulta_sql = Replace(Consulta_sql, "#Filtro_Documentos#", _Filtro_Documentos)


            Consulta_sql = Replace(Consulta_sql, "#Filtro_Bodega#", _Filtro_Bodega)


            Dim _Ds = _Sql.Fx_Get_DataSet(Consulta_sql)


            _Ds.Relations.Add("Rel_Mes_x_Semana",
                         _Ds.Tables("Table").Columns("Periodo"),
                         _Ds.Tables("Table1").Columns("Periodo"), False)


            MchMensuales.ChartType = eMicroChartType.Line

            'Dim points As New List(Of Double)()

            Grilla_Mensual.DataSource = _Ds
            Grilla_Mensual.DataMember = "Table"

            Grilla_Semanal.DataSource = _Ds
            Grilla_Semanal.DataMember = "Table.Rel_Mes_x_Semana"

            OcultarEncabezadoGrilla(Grilla_Mensual, True)
            OcultarEncabezadoGrilla(Grilla_Semanal, True)

            With Grilla_Mensual

                .Columns("Periodo").HeaderText = "Periodo"
                .Columns("periodo").Width = 130
                .Columns("periodo").Visible = True

                .Columns("Ud1").Width = 60
                .Columns("Ud1").DefaultCellStyle.Format = "##,###0.00"
                .Columns("Ud1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Ud1").Visible = True

                .Columns("Ud2").Width = 60
                .Columns("Ud2").DefaultCellStyle.Format = "##,###0.00"
                .Columns("Ud2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Ud2").Visible = True

            End With

            Dim Campo As String = "Ud" & _Ud
            Dim points As New List(Of Double)()

            Dim _Punto As Double = 0
            points.Add(_Punto)

            McsSemanales.DataPoints = points
            MchMensuales.DataPoints = points
            For Each _Fila As DataGridViewRow In Grilla_Mensual.Rows
                _Punto = _Fila.Cells(Campo).Value
                points.Add(_Punto)
            Next

            MchMensuales.DataPoints = points

            With Grilla_Semanal

                .Columns("Semana").Width = 90
                .Columns("Semana").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Semana").Visible = True

                .Columns("Ud1").Width = 60
                .Columns("Ud1").DefaultCellStyle.Format = "##,###0.00"
                .Columns("Ud1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Ud1").Visible = True

                .Columns("Ud2").Width = 60
                .Columns("Ud2").DefaultCellStyle.Format = "##,###0.00"
                .Columns("Ud2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Ud2").Visible = True

            End With

        Catch ex As Exception

        End Try

    End Sub

    Sub LlenarPointMchar(Mchar As DevComponents.DotNetBar.MicroChart,
                         Tabla As DataTable,
                         Optional Unidad As Integer = 1)
        Dim points As New List(Of Double)()

        Dim Campo As String = "Ud" & Unidad

        For Each Fila As DataRow In Tabla.Rows
            Dim Punto As Double = Fila.Item(Campo)
            points.Add(Punto)
        Next

        Mchar.DataPoints = points

    End Sub

    Sub Sb_Actualizar_Grilla_Semanas_Old()

        'Dim Fm_Espera As New Frm_Form_Esperar
        'Fm_Espera.BarraCircular.IsRunning = True
        'Fm_Espera.Show()

        Try


            Dim _Fila As DataGridViewRow = Grilla_Mensual.Rows(Grilla_Mensual.CurrentRow.Index)

            Dim Mes = _Fila.Cells("Mes").Value
            Dim Periodo = _Fila.Cells("Periodo").Value

            If Chk_Agrupar_Asociados.Checked Then

                Consulta_sql = "SELECT KOPR FROM MAEPR WHERE KOPR = '" & _Codigo & "'" & vbCrLf & vbCrLf &
                               "UNION" & vbCrLf &
                               "SELECT KOPR FROM TABREMP WHERE KOPRREM = '" & _Codigo & "' AND KOPR <> '" & _Codigo & "' "
            Else
                Consulta_sql = "Select Top 1 * From MAEPR Where KOPR = '" & _Codigo & "'"
            End If

            Dim _TblProductos As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            Dim _Filtro_Productos As String

            _Filtro_Productos = Generar_Filtro_IN(_TblProductos, "", "KOPR", False, False, "'")


            Consulta_sql = My.Resources.Recursos_Asis_Compras.SQLQuery_Info_Estadistica_X_Producto

            Consulta_sql = Replace(Consulta_sql, "#Codigo#", _Filtro_Productos)
            Consulta_sql = Replace(Consulta_sql, "#Empresa#", ModEmpresa)
            Consulta_sql = Replace(Consulta_sql, "#Funcionario#", FUNCIONARIO)

            Dim F1 As Date = DateAdd(DateInterval.Year, -2, FechaDelServidor)
            F1 = Primerdiadelmes(F1)

            Dim _Fecha_Inicio As Date = F1 '_Fila.Cells("Fecha_Inicio").Value
            Dim _Fecha_Fin As Date = ultimodiadelmes(FechaDelServidor()) '_Fila.Cells("Fecha_Fin").Value

            'Dim _Fecha_Inicio As Date = _Fila.Cells("Fecha_Inicio").Value
            'Dim _Fecha_Fin As Date = _Fila.Cells("Fecha_Fin").Value

            Consulta_sql = Replace(Consulta_sql, "#FechaInicio#", Format(_Fecha_Inicio, "yyyyMMdd"))
            Consulta_sql = Replace(Consulta_sql, "#FechaTermino#", Format(_Fecha_Fin, "yyyyMMdd"))

            Consulta_sql = Replace(Consulta_sql, "#Mes#", Mes)

            Dim _Filtro_Entidades_Excluidas As String = String.Empty

            If Not Chk_Rotacion_Con_Ent_Excluidas.Checked Then

                _Filtro_Entidades_Excluidas = "And LTRIM(RTRIM(ENDO))+RTRIM(LTRIM(SUENDO))" & vbCrLf &
                "NOT IN (SELECT  LTRIM(RTRIM(Codigo))+LTRIM(RTRIM(Sucursal)) From " & _Global_BaseBk & "Zw_TblInf_EntExcluidas" & vbCrLf &
                "Where Funcionario = @CodFuncionario And Excluida in ('V','A','T'))" & vbCrLf

            End If

            Consulta_sql = Replace(Consulta_sql, "#Filtro_Entidades_Excluidas#", _Filtro_Entidades_Excluidas)
            'Consulta_sql = Replace(Consulta_sql, "Zw_TblInf_EntExcluidas", _Global_BaseBk & "Zw_TblInf_EntExcluidas")

            Dim _Filtro_Bodega As String

            If _Filtro_Bodegas_Todas Then
                _Filtro_Bodega = String.Empty
            Else
                _Filtro_Bodega = Generar_Filtro_IN(_Tbl_Filtro_Bodegas, "Chk", "Codigo", False, True, "'")
                _Filtro_Bodega = "And EMPRESA+SULIDO+BOSULIDO In " & _Filtro_Bodega
            End If

            Consulta_sql = Replace(Consulta_sql, "#Filtro_Bodega#", _Filtro_Bodega)

            Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

            Dim _Tbl As DataTable = _Ds.Tables(1)

            'Ejecutar_consulta_SQL(Consulta_sql, cn1)

            'tb = New DataTable
            'da.Fill(tb) ' ---  aca se carga la tabla de la base access completa

            McsSemanales.ChartType = eMicroChartType.Line
            LlenarPointMchar(McsSemanales, _Tbl, 1)


            With Grilla_Semanal
                .DataSource = _Tbl

                .Columns("Semana").Width = 90
                .Columns("Semana").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Ud1").Width = 60
                .Columns("Ud1").DefaultCellStyle.Format = "##,###0.00"
                .Columns("Ud1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Ud2").Width = 60
                .Columns("Ud2").DefaultCellStyle.Format = "##,###0.00"
                .Columns("Ud2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With

            'LabelX2.Text = "Ventas en " & Periodo

        Catch ex As Exception
            Grilla_Semanal.DataSource = Nothing
        Finally
            'Fm_Espera.Dispose()
        End Try

    End Sub

    Private Sub Tab_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

        If Tabs.SelectedTabIndex = 2 Then

            If Not Fr_Alerta_Stock.Visible Then
                Fr_Alerta_Stock = New AlertCustom(_Codigo, _Ud)
                ShowLoadAlert(Fr_Alerta_Stock, Me, False, , Chk_Agrupar_Asociados.Checked)
            Else
                Fr_Alerta_Stock.Close()
            End If

        End If

    End Sub

    Sub Sb_Color_Super_Tab()

        Tabs.TabStrip.BeginUpdate()

        Dim values As Integer() = DirectCast([Enum].GetValues(GetType(eTabItemColor)), Integer())

        ' Loop through each tab, setting its PredefinedColor
        ' scheme in a Round Robin fashion

        For i As Integer = 0 To Tabs.Tabs.Count - 1
            Dim tab As SuperTabItem = TryCast(Tabs.Tabs(i), SuperTabItem)

            If tab IsNot Nothing Then
                tab.ResetTabColor()
                tab.PredefinedColor = DirectCast((i Mod (values.Length - 1)), eTabItemColor) + 1
            End If
        Next

        ' Reset our TabStrip color back to default

        Tabs.ResetTabStripColor()
        Tabs.TabStrip.EndUpdate()

    End Sub

    Private Sub Sb_Tabs_SelectedTabChanged(sender As System.Object, e As DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs)

        Dim _Id_Graficos As Integer

        If Chk_Grafica_Ventas_Solo_Entidad.Visible Then
            _Id_Graficos = 3
        Else
            _Id_Graficos = 2
        End If

        Select Case Tabs.SelectedTabIndex

            Case _Id_Graficos

                Dim _NewValue = e.NewValue.ToString

                If _NewValue = "Grafica de ventas/Inventario" Then

                    If Not Fr_Alerta_Stock.Visible Then

                        Fr_Alerta_Stock = New AlertCustom(_Codigo, _Ud)
                        ShowLoadAlert(Fr_Alerta_Stock, Me, False, , Chk_Agrupar_Asociados.Checked)

                        If Not _Graficos_Actualizados Then

                            Call Btn_Actualizar_Grafico_Click(Nothing, Nothing)
                            _Graficos_Actualizados = True

                        End If

                    Else

                        Fr_Alerta_Stock.Close()

                    End If

                    Chk_Agrupar_Asociados.Enabled = True

                End If

            Case 5, 6

                Chk_Agrupar_Asociados.Enabled = False

            Case Else

                Chk_Agrupar_Asociados.Enabled = True

        End Select

    End Sub

    Private Sub Btn_Ver_Info_Ult_Compras_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Ver_Info_Ult_Compras.Click
        GrillaCompras.Visible = Fx_Tiene_Permiso(Me, "Prod051")
    End Sub

    Private Sub Sb_Data()

        Dim rand As Random = New Random()
        Dim randSeed As Integer = rand.[Next]()

        rand = New Random(randSeed)
        Dim period As Integer = 100 '365 * 2 ' Integer.Parse(comboBoxPeriod.Text)

        Grafico_Tendencias.Series("Input").Points.Clear()
        Dim high As Double = rand.NextDouble() * 40

        If high <= 0 Then
            high = -1 * high + 1
        End If

        Dim _Tbl As DataTable = _Tbl_Grafico_Tendencia
        Dim dv As DataView = _Tbl_Grafico_Tendencia.DefaultView

        Dim close As Double = high - rand.NextDouble()
        Dim low As Double = close - rand.NextDouble()
        Dim volume As Double = 100 + 15 * rand.NextDouble()

        Dim _Fecha As DateTime = _Tbl_Grafico_Tendencia.Rows(0).Item("Fecha")

        Dim _Ud = _Tbl_Grafico_Tendencia.Rows(0).Item("SumTotalQtyUd1")

        Dim _dias = DateDiff(DateInterval.Day, _Fecha, FechaDelServidor)
        period = _dias

        Grafico_Tendencias.Series("Input").Points.AddXY(DateTime.Parse("1/2/2002"), high)
        Grafico_Tendencias.Series("Input").Points(0).YValues(1) = low
        Grafico_Tendencias.Series("Input").Points(0).YValues(2) = close
        Grafico_Tendencias.Series("Input").Points(0).YValues(3) = close

        For day As Integer = 1 To period

            high = Grafico_Tendencias.Series("Input").Points(day - 1).YValues(2) + rand.NextDouble()
            close = high - rand.NextDouble()
            low = close - rand.NextDouble()
            If low > Grafico_Tendencias.Series("Input").Points(day - 1).YValues(2) Then low = Grafico_Tendencias.Series("Input").Points(day - 1).YValues(2)

            If high <= 0 Then
                high = -1 * high + 1
            End If

            dv.RowFilter = "Fecha = '" & Format(_Fecha, "dd-MM-yyyy") & "'"
            Dim _Row As DataTable = dv.Table
            _Ud = _Row.Rows(0).Item("SumTotalQtyUd1")

            If CBool(_Ud) Then
                Dim a = 1
            End If
            _Ud += 1

            Grafico_Tendencias.Series("Input").Points.AddXY(day, high)
            Grafico_Tendencias.Series("Input").Points(day).XValue = Grafico_Tendencias.Series("Input").Points(day - 1).XValue + 1
            Grafico_Tendencias.Series("Input").Points(day).YValues(1) = low
            Grafico_Tendencias.Series("Input").Points(day).YValues(2) = close
            Grafico_Tendencias.Series("Input").Points(day).YValues(3) = close

            _Fecha = DateAdd(DateInterval.Day, 1, _Fecha)

        Next

        Grafico_Tendencias.Invalidate()

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

        Dim _Tbl As DataTable = _Tbl_Grafico_Tendencia

        Dim dv As DataView = _Tbl_Grafico_Tendencia.DefaultView

        Dim close As Double = high - rand.NextDouble()
        Dim low As Double = close - rand.NextDouble()
        Dim volume As Double = 100 + 15 * rand.NextDouble()

        Dim _Fecha As DateTime = _Tbl_Grafico_Tendencia.Rows(0).Item("Fecha")

        Dim _Ud = _Tbl_Grafico_Tendencia.Rows(0).Item("SumTotalQtyUd1")

        Dim _dias = DateDiff(DateInterval.Day, Dtp_Fecha_Moviminetos_Stock_Desde.Value, Dtp_Fecha_Moviminetos_Stock_Hasta.Value)
        period = _dias

        Grafico_Tendencias.Series("Ventas").Points.AddXY(DateTime.Parse(_Fecha), _Ud)

        For day As Integer = 1 To period

            dv.RowFilter = "Fecha = '" & Format(_Fecha, "dd-MM-yyyy") & "'"
            Dim _Row As DataTable = dv.Table

            If CBool(dv.Count) Then
                _Ud = dv.Item(0).Item("SumTotalQtyUd1")
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

    End Sub

    Private Sub Sb_Linea_Tendencia()
        Try


            'If comboBoxRegressionType.Text <> "Polynomial" Then
            'comboBoxOrder.Enabled = False
            'Else
            'comboBoxOrder.Enabled = True
            'End If

            Dim typeRegression As String = "Polynomial"

            typeRegression = "Linear"
            'typeRegression = "Exponential"
            'typeRegression = "Power"
            'If comboBoxRegressionType.Text <> "Polynomial" Then
            'typeRegression = comboBoxRegressionType.Text
            'Else
            'typeRegression = comboBoxOrder.Text
            'End If

            Dim _Dias = DateDiff(DateInterval.Day, Dtp_Fecha_Moviminetos_Stock_Desde.Value, Dtp_Fecha_Moviminetos_Stock_Hasta.Value) + 50

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

    Private Sub Chk_Agrupar_Asociados_CheckedChanged(sender As Object, e As EventArgs)

        Tabs.SelectedTabIndex = 1

        If Not _Es_Concepto Then
            If Chk_Agrupar_Asociados.Checked Then
                Tab_06_Codigos_Alternativos.Enabled = False
                Tab_07_Informacion_Del_Producto.Enabled = False
            Else
                Tab_06_Codigos_Alternativos.Enabled = True
                Tab_07_Informacion_Del_Producto.Enabled = True
            End If
        End If

        If Fr_Alerta_Stock.Visible Then Fr_Alerta_Stock.Close()
        _Graficos_Actualizados = False
        Call BtnActualizarInformacion_Click(Nothing, Nothing)

    End Sub

    Private Sub Mnu_Btn_Ver_Clasificaciones_Arbol_Click(sender As Object, e As EventArgs) Handles Mnu_Btn_Ver_Clasificaciones_Arbol.Click
        Dim Fm As New Frm_Arbol_Asociacion_01
        Fm.Pro_Codigo_Producto = _Codigo
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub

    Private Sub Mnu_Btn_Mantencion_Clasificaciones_Arbol_Click(sender As Object, e As EventArgs) Handles Mnu_Btn_Mantencion_Clasificaciones_Arbol.Click
        If Fx_Tiene_Permiso(Me, "Prod021") Then
            Dim Fm As New Frm_MtCreaProd_01_IngBusqEspecial
            Fm.TxtCodigo.Text = _Codigo
            Fm.TxtDescripcion.Text = _Descripcion
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If
    End Sub

    Private Sub Btn_Ver_documento_Click(sender As Object, e As EventArgs) Handles Btn_Ver_documento.Click

        Dim _Grilla As DataGridView

        If Tabs.SelectedTabIndex = 0 Then _Grilla = GrillaCompras
        If Tabs.SelectedTabIndex = 1 Then _Grilla = GrillaVentas
        If Tabs.SelectedTabIndex = 2 Then _Grilla = Grilla_Entidad

        Call Sb_Grilla_CellDoubleClick(_Grilla, Nothing)

    End Sub

    Private Sub Btn_Asociaciones_Arbol_Click(sender As Object, e As EventArgs) Handles Btn_Asociaciones_Arbol.Click
        ShowContextMenu(Menu_Contextual_02_Opciones_Arbol)
    End Sub

    'Private Sub GrillaCompras_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles GrillaCompras.CellMouseDown
    '    If e.Button = Windows.Forms.MouseButtons.Right Then
    '        With sender
    '            Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
    '            If Hitest.Type = DataGridViewHitTestType.Cell Then
    '                .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
    '                ShowContextMenu(Menu_Contextual_01_Opciones_Documento)
    '            End If
    '        End With
    '    End If
    'End Sub

    Private Sub GrillaVentas_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles GrillaVentas.CellMouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    ShowContextMenu(Menu_Contextual_01_Opciones_Documento)
                End If
            End With
        End If
    End Sub

    Private Sub Grilla_Entidad_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grilla_Entidad.CellMouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    ShowContextMenu(Menu_Contextual_01_Opciones_Documento)
                End If
            End With
        End If
    End Sub

    Private Sub Grilla_Mensual_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Mensual.CellEnter
        Try

            Dim points As New List(Of Double)()

            Dim _Punto As Double = 0
            points.Add(_Punto)

            McsSemanales.DataPoints = points
            McsSemanales.ChartType = eMicroChartType.Line

            Dim Campo As String = "Ud" & _Ud
            Dim _Semana = 0

            For Each _Fila As DataGridViewRow In Grilla_Semanal.Rows
                _Punto = _Fila.Cells(Campo).Value
                _Semana += 1
                _Fila.Cells("Semana").Value = _Semana
                points.Add(_Punto)
            Next

            McsSemanales.DataPoints = points

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Tabs_SelectedTabChanged(sender As Object, e As SuperTabStripSelectedTabChangedEventArgs) Handles Tabs.SelectedTabChanged

        If Tabs.TabIndex = 4 Then

        End If

    End Sub

    Private Sub Btn_Productos_Asociados_Click_1(sender As System.Object, e As System.EventArgs) Handles Btn_Productos_Asociados.Click

        If Fx_Tiene_Permiso(Me, "Prod056") Then

            If Chk_Agrupar_Asociados.Enabled And Not IsNothing(_Row_Nodo_Clasificaciones) Then

                Dim _Codigo_Nodo = _Row_Nodo_Clasificaciones.Item("Codigo_Nodo")
                Dim _Identificador_NodoPadre = _Row_Nodo_Clasificaciones.Item("Codigo_Nodo")
                Dim _FullPath = String.Empty
                Dim _Es_Seleccionable = _Row_Nodo_Clasificaciones.Item("Es_Seleccionable")
                Dim _Clas_Unica_X_Producto = _Row_Nodo_Clasificaciones.Item("Clas_Unica_X_Producto")
                Dim _Descripcion = _Row_Nodo_Clasificaciones.Item("Descripcion")

                Dim Fm As New Frm_Arbol_Asociacion_04_Productos_x_class(_Identificador_NodoPadre,
                                                                        _Codigo_Nodo,
                                                                        _Descripcion,
                                                                        _FullPath,
                                                                        _Es_Seleccionable,
                                                                        _Clas_Unica_X_Producto,
                                                                        False)
                Fm.Pro_Codigo_Heredado = _Codigo
                Fm.Text = "Clasificación: (Cod. " & _Codigo_Nodo & ") " & _Descripcion
                Fm.ShowDialog(Me)
                Fm.Dispose()

            Else
                MessageBoxEx.Show(Me, "No existen productos asociados a este articulo", "Productos asociados", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        End If

    End Sub

    Private Sub Sb_Grilla_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    ShowContextMenu(Menu_Contextual_01_Opciones_Documento)
                End If
            End With
        End If
    End Sub

    Private Sub Btn_Guardar_Vista_Click(sender As Object, e As EventArgs) Handles Btn_Guardar_Vista.Click
        Sb_Parametros_Informe_Sql(True)
        MessageBoxEx.Show(Me, "Los datos de configuración se guardaran para las nuevas consultas de productos", "Guardar vista",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Sub Sb_Parametros_Informe_Sql(_Actualizar As Boolean)

        Dim _Informe = "Informacion_Producto"

        If _Actualizar Then

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Tmp_Prm_Informes" & vbCrLf &
                           "Where Funcionario = '" & FUNCIONARIO & "' And Informe = '" & _Informe & "'" & Space(1) &
                           "And Grupo = 'Bodegas_Vta' And NombreEquipo = '" & _NombreEquipo & "' And Modalidad = '" & Modalidad & "'"
            _Sql.Ej_consulta_IDU(Consulta_sql)
            _Sql.Sb_Actualizar_Filtro_Tmp(_Tbl_Filtro_Bodegas, _Informe, "Bodegas_Vta")

        End If

        Dim _FechaHoy As Date = FormatDateTime(FechaDelServidor, DateFormat.ShortDate)
        Dim _Fecha_Hoy = Format(_FechaHoy, "dd-MM-yyyy")


        'SELECCIONAR PRODUCTOS
        _Sql.Sb_Parametro_Informe_Sql(Rdb_Ud1, _Informe, Rdb_Ud1.Name,
                                                 Class_SQLite.Enum_Type._Boolean, Rdb_Ud1.Checked, _Actualizar, "Grafico")
        _Sql.Sb_Parametro_Informe_Sql(Rdb_Ud2, _Informe, Rdb_Ud2.Name,
                                                 Class_SQLite.Enum_Type._Boolean, Rdb_Ud2.Checked, _Actualizar, "Grafico")

        _Sql.Sb_Parametro_Informe_Sql(Chk_Rotacion_Con_Ent_Excluidas, _Informe, Chk_Rotacion_Con_Ent_Excluidas.Name,
                                                 Class_SQLite.Enum_Type._Boolean, Chk_Rotacion_Con_Ent_Excluidas.Checked, _Actualizar, "Grafico")

        _Sql.Sb_Parametro_Informe_Sql(Chk_Mostrar_Solo_BLV_FCV_NCV, _Informe, Chk_Mostrar_Solo_BLV_FCV_NCV.Name,
                                                 Class_SQLite.Enum_Type._Boolean, Chk_Mostrar_Solo_BLV_FCV_NCV.Checked, _Actualizar, "Grafico")

        _Sql.Sb_Parametro_Informe_Sql(Chk_Agrupar_Asociados, _Informe, Chk_Agrupar_Asociados.Name,
                                                 Class_SQLite.Enum_Type._Boolean, Chk_Agrupar_Asociados.Checked, _Actualizar, "Grafico")

        _Sql.Sb_Parametro_Informe_Sql(Dtp_Fecha_Moviminetos_Stock_Desde, _Informe, Dtp_Fecha_Moviminetos_Stock_Desde.Name,
                                                 Class_SQLite.Enum_Type._Date, Dtp_Fecha_Moviminetos_Stock_Desde.Value, _Actualizar, "Grafico")

        _Sql.Sb_Parametro_Informe_Sql(Dtp_Fecha_Moviminetos_Stock_Hasta, _Informe, Dtp_Fecha_Moviminetos_Stock_Hasta.Name,
                                                 Class_SQLite.Enum_Type._Date, Dtp_Fecha_Moviminetos_Stock_Hasta.Value, _Actualizar, "Grafico")


        If Not _Actualizar Then
            Consulta_sql = "Select Chk,Codigo,Descripcion From " & _Global_BaseBk & "Zw_Tmp_Filtros_Busqueda" & vbCrLf &
                           "Where Funcionario = '" & FUNCIONARIO & "' And Informe = '" & _Informe & "'" & Space(1) &
                           "And Filtro = 'Bodegas_Vta' And NombreEquipo = '" & _NombreEquipo & "' And Modalidad = '" & Modalidad & "'"
            _Tbl_Filtro_Bodegas = _Sql.Fx_Get_Tablas(Consulta_sql)
        End If

        If Not CBool(_Tbl_Filtro_Bodegas.Rows.Count) Then
            Consulta_sql = "Select EMPRESA+KOSU+KOBO As Codigo,1 As Chk,NOKOBO as Descripcion From TABBO" & vbCrLf &
                           "Where EMPRESA+KOSU+KOBO = '" & ModEmpresa & ModSucursal & ModBodega & "'"
            _Tbl_Filtro_Bodegas = _Sql.Fx_Get_Tablas(Consulta_sql)
        End If

    End Sub

    Private Sub Chk_Mostrar_Venta_Por_Dia_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Mostrar_Venta_Por_Dia.CheckedChanged
        Call Btn_Actualizar_Grafico_Click(Nothing, Nothing)
    End Sub

    Private Sub Dtp_Fecha_Moviminetos_Stock_Hasta_Click(sender As Object, e As EventArgs) Handles Dtp_Fecha_Moviminetos_Stock_Hasta.Click
        Sb_Dias_Entre_Fechas()
    End Sub

    Private Sub Dtp_Fecha_Moviminetos_Stock_Desde_Click(sender As Object, e As EventArgs) Handles Dtp_Fecha_Moviminetos_Stock_Desde.Click
        Sb_Dias_Entre_Fechas()
    End Sub

    Sub Sb_Dias_Entre_Fechas()

        Dim F1 As Date = Dtp_Fecha_Moviminetos_Stock_Desde.Value
        Dim F2 As Date = Dtp_Fecha_Moviminetos_Stock_Hasta.Value
        Dim _Dias_Entre_Fechas As Integer = DateDiff(DateInterval.Day, F1, F2)
        Lbl_Dias_Estudio.Text = "Días: " & FormatNumber(_Dias_Entre_Fechas, 0)

    End Sub

    Private Sub Chk_Mostrar_Venta_Por_Dia_CheckedChanging(sender As Object, e As Controls.CheckBoxXChangeEventArgs) Handles Chk_Mostrar_Venta_Por_Dia.CheckedChanging

        Dim F1 As Date = Dtp_Fecha_Moviminetos_Stock_Desde.Value
        Dim F2 As Date = Dtp_Fecha_Moviminetos_Stock_Hasta.Value
        Dim _Dias_Entre_Fechas As Integer = DateDiff(DateInterval.Day, F1, F2)

        If _Dias_Entre_Fechas > 120 Then
            MessageBoxEx.Show(Me, "Para mostrar este grafico solo deben haber 120 o  menos días de estudio" & vbCrLf &
                              "Días de estudio: " & FormatNumber(_Dias_Entre_Fechas, 0), "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
        End If

    End Sub

    Private Sub Btn_Dimensiones_Click(sender As Object, e As EventArgs) Handles Btn_Dimensiones.Click

        Dim Fm As New Frm_Dimensiones_Pr(TxtCodigoPrincipal.Text, False)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Rev_Cumpl_Proveedor_Click(sender As Object, e As EventArgs) Handles Btn_Rev_Cumpl_Proveedor.Click

        Dim _Fila As DataGridViewRow = GrillaCompras.Rows(GrillaCompras.CurrentRow.Index)

        Dim _Endo As String = _Fila.Cells("ENDO").Value
        Dim _Suendo As String = _Fila.Cells("SUENDO").Value

        Dim Fm As New Frm_CumplXProveedor(_Endo, _Suendo, _Codigo)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

End Class
