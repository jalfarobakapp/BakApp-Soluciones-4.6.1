Imports System.Windows.Forms.DataVisualization.Charting

Public Class Frm_SobreStock_Grafico

    ' Plan (pseudocódigo detallado):
    ' 1. Añadir una serie adicional para "Llegadas" en los métodos mensuales y semanales.
    '    - La serie de llegadas debe ser de tipo Point (SeriesChartType.Point) para mostrar solo marcadores sin línea.
    '    - Configurar MarkerStyle y MarkerSize para que sean visibles.
    '    - No conectar puntos entre periodos (Point no conecta).
    ' 2. Al recorrer las filas:
    '    - Extraer el valor de llegadas (LlegadasMes / LlegadasSemanal) con comprobación de DBNull.
    '    - Redondear el valor de llegadas.
    '    - Añadir un punto en la serie de llegadas SOLO si el valor de llegadas > 0.
    '    - Mantener el comportamiento actual para las otras series.
    ' 3. No cambiar la lógica de las checkboxes existentes; la serie de llegadas será visible por defecto y tendrá entrada en la leyenda.
    ' 4. Formatear las etiquetas del eje Y a 2 decimales y forzar recomputo de ejes.
    ' 5. Asegurar que no se produzcan excepciones si la serie no existe antes de usarla.
    ' Resultado: se mostrarán puntos (marcadores) indicando los meses/semanas donde hubo llegadas, sin trazar líneas innecesarias.

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Cl_SobreStockXClas As New Cl_SobreStockXClas

    Dim _Codigo As String
    Dim _Codigo_Nodo_Madre As String

    Dim _Tbl_Mensual As DataTable
    Dim _Tbl_Semanal As DataTable

    Public Property StockInicial As Double

    Public Sub New(_Codigo As String, _Codigo_Nodo_Madre As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me._Codigo = _Codigo
        Me._Codigo_Nodo_Madre = _Codigo_Nodo_Madre

    End Sub

    Private Sub Frm_SobreStock_Grafico_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not String.IsNullOrEmpty(_Codigo_Nodo_Madre) Then
            Sb_Actualizar_Clasificaciones_Mensual()
            Sb_Actualizar_Clasificaciones_Semanal()
        Else
            Sb_Actualizar_Productos_Mensual()
            Sb_Actualizar_Productos_Semanal()
        End If

        'If Rdb_Proyeccion_Meses.Checked Then
        'Sb_Poblar_Grafico_Mensual()
        'ElseIf Rdb_Proyeccion_Semanas.Checked Then
        Sb_Poblar_Grafico_Semanal()
        'End If

        AddHandler Chk_StockSemanal.CheckedChanged, AddressOf Sb_Ver_Etiquetas_Grafico_Tiempo_Reposicion
        AddHandler Chk_StockProyectadoMensual.CheckedChanged, AddressOf Sb_Ver_Etiquetas_Grafico_Tiempo_Reposicion
        AddHandler Chk_StockNecesarioNMeses.CheckedChanged, AddressOf Sb_Ver_Etiquetas_Grafico_Tiempo_Reposicion
        AddHandler Chk_StockNecesarioNMenosXMeses.CheckedChanged, AddressOf Sb_Ver_Etiquetas_Grafico_Tiempo_Reposicion
        AddHandler Chk_LlegadasMes.CheckedChanged, AddressOf Sb_Ver_Etiquetas_Grafico_Tiempo_Reposicion
        AddHandler Chk_StockInicial.CheckedChanged, AddressOf Sb_Ver_Etiquetas_Grafico_Tiempo_Reposicion
        AddHandler Chk_StockMes.CheckedChanged, AddressOf Sb_Ver_Etiquetas_Grafico_Tiempo_Reposicion

        Chk_StockMes.Checked = True

    End Sub

    Sub Sb_Actualizar_Productos_Mensual()

        Consulta_sql = $"-- Estudio de proyección de ventas por MES

SELECT 
    Codigo,
	Codigo_Nodo_Madre,
    Periodo,
    Mes,
    NombreMes,
    MIN(StockMes) AS StockMes,          -- stock al cierre del mes
    MAX(VentaMes) AS VentaMes,          -- rotación mensual
    LlegadasMes AS LlegadasMes,         -- total llegadas del mes
	MAX(StockNecesarioNMeses) As StockNecesarioNMeses,
	MAX(StockProyectadoMensual) As StockProyectadoMensual,
	MAX(StockNecesarioNMenosXMeses) As StockNecesarioNMenosXMeses

FROM {_Cl_SobreStockXClas.TablaCalendarioMesesSemanasProductos}
Where Codigo = '{_Codigo}'
GROUP BY Codigo, Codigo_Nodo_Madre, Periodo, Mes, NombreMes,LlegadasMes
ORDER BY Codigo, Periodo, Mes;"

        _Tbl_Mensual = _Sql.Fx_Get_DataTable(Consulta_sql)

    End Sub

    Sub Sb_Actualizar_Productos_Semanal()

        Consulta_sql = $"-- Estudio de proyección de ventas por MES

SELECT 
    Codigo,
	Codigo_Nodo_Madre,
    Periodo,
    Mes,
    NombreMes,
    Semana,
    'Sem' + CAST(Semana AS VARCHAR(2)) + '-' + LEFT(NombreMes,3) + '-' + CAST(Periodo AS VARCHAR(4)) AS NombreSemana,
    MAX(StockSemanal) AS StockSemanal,              -- stock al cierre de la semana
    MAX(VentaSemanal) AS VentaSemanal,              -- rotación semanal
    SUM(LlegadaSemanal) AS LlegadasSemanal,         -- total llegadas de la semana
    MIN(StockMes) AS StockMes,                      -- stock al cierre del mes    
    MAX(StockNecesarioNMeses) AS StockNecesarioNMeses,
	MAX(StockProyectadoMensual) AS StockProyectadoMensual,
	MAX(StockNecesarioNMenosXMeses) AS StockNecesarioNMenosXSemanas,
    MAX(StockNecesarioNMeses) AS StockNecesarioNSemanas,
    MAX(StockProyectadoSemanal) AS StockProyectadoSemanal

FROM {_Cl_SobreStockXClas.TablaCalendarioMesesSemanasProductos}
Where Codigo = '{_Codigo}'
GROUP BY Codigo, Codigo_Nodo_Madre, Periodo, Mes, NombreMes, Semana
ORDER BY Periodo, Mes, Semana;"

        _Tbl_Semanal = _Sql.Fx_Get_DataTable(Consulta_sql)

    End Sub


    Sub Sb_Actualizar_Clasificaciones_Mensual()

        Consulta_sql = $"-- Estudio de proyección de ventas por MES

SELECT 
    Codigo_Nodo_Madre,
    Periodo,
    Mes,
    NombreMes,
    MIN(StockMes) AS StockMes,          -- stock al cierre del mes
    MAX(VentaMes) AS VentaMes,          -- rotación mensual
    LlegadasMes AS LlegadasMes,         -- total llegadas del mes
	MAX(StockNecesarioNMeses) As StockNecesarioNMeses,
	MAX(StockProyectadoMensual) As StockProyectadoMensual,
	MAX(StockNecesarioNMenosXMeses) As StockNecesarioNMenosXMeses

FROM {_Cl_SobreStockXClas.TablaCalendarioMesesSemanasClasificacion}
Where Codigo_Nodo_Madre = '{_Codigo_Nodo_Madre}'
GROUP BY Codigo_Nodo_Madre, Periodo, Mes, NombreMes,LlegadasMes
ORDER BY Codigo_Nodo_Madre, Periodo, Mes;"

        _Tbl_Mensual = _Sql.Fx_Get_DataTable(Consulta_sql)

    End Sub

    Sub Sb_Actualizar_Clasificaciones_Semanal()

        Consulta_sql = $"
SELECT 
    Codigo_Nodo_Madre,
    Periodo,
    Mes,
    NombreMes,
    Semana,
    'Sem' + CAST(Semana AS VARCHAR(2)) + '-' + LEFT(NombreMes,3) + '-' + CAST(Periodo AS VARCHAR(4)) AS NombreSemana,
    MAX(StockSemanal) AS StockSemanal,              -- stock al cierre de la semana
    MAX(VentaSemanal) AS VentaSemanal,              -- rotación semanal
    SUM(LlegadaSemanal) AS LlegadasSemanal,         -- total llegadas de la semana
    MIN(StockMes) AS StockMes,          -- stock al cierre del mes
    MAX(StockNecesarioNMeses) AS StockNecesarioNSemanas,
    MAX(StockProyectadoSemanal) AS StockProyectadoSemanal,
    MAX(StockNecesarioNMenosXMeses) As StockNecesarioNMenosXSemanas
FROM {_Cl_SobreStockXClas.TablaCalendarioMesesSemanasClasificacion}
WHERE Codigo_Nodo_Madre = '{_Codigo_Nodo_Madre}'
GROUP BY Codigo_Nodo_Madre, Periodo, Mes, NombreMes, Semana
ORDER BY Codigo_Nodo_Madre, Periodo, Mes, Semana;
"

        _Tbl_Semanal = _Sql.Fx_Get_DataTable(Consulta_sql)

    End Sub

    ' Plan (pseudocódigo detallado):
    ' 1. Comprobar si hay datos y limpiar gráfico si no hay.
    ' 2. Asegurar que exista ChartArea y limpiar series/leyendas.
    ' 3. Crear las series necesarias.
    '    - Para cada serie configurar: ChartType, XValueType, BorderWidth, MarkerStyle, MarkerSize, Legend, LegendText.
    '    - Establecer formato de etiqueta numérica a dos decimales: LabelFormat = "N2".
    ' 4. Al recorrer filas:
    '    - Extraer valores numéricos con comprobaciones de DBNull.
    '    - Convertir/Redondear los valores a 2 decimales (Math.Round).
    '    - Agregar puntos usando AddXY pasando el valor ya redondeado.
    ' 5. Configurar formato de ejes:
    '    - Establecer Interval, Angle, Titles, MajorGrid.
    '    - Forzar formato de etiqueta del eje Y a 2 decimales: AxisY.LabelStyle.Format = "N2".
    ' 6. Recalcular escalas y forzar refresco.
    '
    ' Resultado: cuando se muestren etiquetas de punto (IsValueShownAsLabel = True)
    ' y las etiquetas del eje Y, se visualizarán con 2 decimales.

    Sub Sb_Poblar_Grafico_Mensual()

        ' Verificar datos
        If _Tbl_Mensual Is Nothing OrElse _Tbl_Mensual.Rows.Count = 0 Then
            If Grafico_Mov_Stock IsNot Nothing Then
                Grafico_Mov_Stock.Series.Clear()
                Grafico_Mov_Stock.Titles.Clear()
                Grafico_Mov_Stock.Legends.Clear()
            End If
            Return
        End If

        ' Asegurar chartarea y limpieza
        If Grafico_Mov_Stock.ChartAreas.Count = 0 Then
            Grafico_Mov_Stock.ChartAreas.Add("ChartArea1")
        End If

        Dim ca As ChartArea = Grafico_Mov_Stock.ChartAreas(0)
        Grafico_Mov_Stock.Series.Clear()
        Grafico_Mov_Stock.Legends.Clear()
        Grafico_Mov_Stock.Legends.Add(New Legend("Legend1"))

        ' Definir series a crear (nombre interno -> texto de leyenda)
        Dim seriesConfig As New Dictionary(Of String, String) From {
            {"StockMes", "Stock Mes"},
            {"StockNecesarioNMeses", "Stock Necesario n Meses"},
            {"StockProyectadoMensual", "Stock Proyectado Mensual"},
            {"StockNecesarioNMenosXMeses", "Stock Necesario 2 MenosXMeses"},
            {"LlegadasMes", "Llegadas Mes"}, ' Nueva serie para llegadas (solo puntos)
            {"StockInicial", "Stock Inicial"} ' Nueva serie para stock inicial (punto verde en primer registro)
        }

        ' Crear series con formato base
        For Each kvp In seriesConfig
            Dim s As Series = Grafico_Mov_Stock.Series.Add(kvp.Key)

            If kvp.Key = "LlegadasMes" Then
                ' Serie de puntos para marcaciones de llegadas
                s.ChartType = SeriesChartType.Point
                s.XValueType = ChartValueType.String
                s.BorderWidth = 0
                s.MarkerStyle = MarkerStyle.Circle
                s.MarkerSize = 8
                s.Color = Color.FromArgb(255, 0, 120, 215)
                s.IsValueShownAsLabel = False
                ' Formato de las etiquetas de punto: 2 decimales
                s.LabelFormat = "N2"
            ElseIf kvp.Key = "StockInicial" Then
                ' Serie de punto para stock inicial (solo un marcador en el primer registro)
                s.ChartType = SeriesChartType.Point
                s.XValueType = ChartValueType.String
                s.BorderWidth = 0
                s.MarkerStyle = MarkerStyle.Circle
                s.MarkerSize = 9
                s.Color = Color.Green
                s.IsValueShownAsLabel = False
                s.LabelFormat = "N2"
            Else
                s.ChartType = SeriesChartType.Line
                s.XValueType = ChartValueType.String
                s.BorderWidth = 2

                If s.Name = "StockMes" Or s.Name = "StockProyectadoMensual" Then
                    s.MarkerStyle = MarkerStyle.Circle
                    s.MarkerSize = 5
                Else
                    s.MarkerStyle = MarkerStyle.None
                    s.MarkerSize = 0
                End If

                s.IsValueShownAsLabel = False
                ' Formato de las etiquetas de punto: 2 decimales
                s.LabelFormat = "N2"
            End If

            s.Legend = "Legend1"
            s.LegendText = kvp.Value
        Next

        ' Recorrer filas y agregar puntos
        Dim isFirstMes As Boolean = True
        Dim UltProyectado As Boolean = False

        For Each row As DataRow In _Tbl_Mensual.Rows

            Dim nombreMes As String = If(IsDBNull(row("NombreMes")), String.Empty, row("NombreMes").ToString().Trim())
            Dim periodo As String = If(IsDBNull(row("Periodo")), String.Empty, row("Periodo").ToString().Trim())
            Dim labelX As String = $"{nombreMes} {periodo}"

            Dim stockMes As Double = 0
            Dim stockNecesario As Double = 0
            Dim stockProyectado As Double = 0
            Dim stockNecesarioMenos As Double = 0
            Dim llegadasMes As Double = 0

            If Not IsDBNull(row("StockMes")) Then
                Double.TryParse(row("StockMes").ToString(), stockMes)
            End If

            If Not IsDBNull(row("StockNecesarioNMeses")) Then
                Double.TryParse(row("StockNecesarioNMeses").ToString(), stockNecesario)
            End If

            If Not IsDBNull(row("StockProyectadoMensual")) Then
                Double.TryParse(row("StockProyectadoMensual").ToString(), stockProyectado)
            End If

            If Not IsDBNull(row("StockNecesarioNMenosXMeses")) Then
                Double.TryParse(row("StockNecesarioNMenosXMeses").ToString(), stockNecesarioMenos)
            End If

            If row.Table.Columns.Contains("LlegadasMes") AndAlso Not IsDBNull(row("LlegadasMes")) Then
                Double.TryParse(row("LlegadasMes").ToString(), llegadasMes)
            End If

            ' Redondear a 2 decimales antes de agregar (seguridad y consistencia)
            stockMes = Math.Round(stockMes, 2)
            stockNecesario = Math.Round(stockNecesario, 2)
            stockProyectado = Math.Round(stockProyectado, 2)
            stockNecesarioMenos = Math.Round(stockNecesarioMenos, 2)
            llegadasMes = Math.Round(llegadasMes, 2)

            ' Agregar punto stock inicial en el primer registro
            If isFirstMes AndAlso Grafico_Mov_Stock.Series.IndexOf("StockInicial") >= 0 Then
                Grafico_Mov_Stock.Series("StockInicial").Points.AddXY(labelX, Math.Round(Me.StockInicial, 2))
                isFirstMes = False
            End If

            ' Agregar puntos (si existe la serie)
            If Grafico_Mov_Stock.Series.IndexOf("StockMes") >= 0 Then
                Grafico_Mov_Stock.Series("StockMes").Points.AddXY(labelX, stockMes)
            End If

            If Grafico_Mov_Stock.Series.IndexOf("StockNecesarioNMeses") >= 0 Then
                Grafico_Mov_Stock.Series("StockNecesarioNMeses").Points.AddXY(labelX, stockNecesario)
            End If

            If Grafico_Mov_Stock.Series.IndexOf("StockProyectadoMensual") >= 0 Then
                ' Siempre usar labelX para alinear en el eje X.
                ' Si hay valor positivo y no se ha marcado UltProyectado, añadir el valor.
                ' Si no, añadir Double.NaN con el mismo labelX para mantener la secuencia sin dibujar marcador.
                If stockProyectado > 0 AndAlso Not UltProyectado Then
                    Grafico_Mov_Stock.Series("StockProyectadoMensual").Points.AddXY(labelX, stockProyectado)
                Else
                    Grafico_Mov_Stock.Series("StockProyectadoMensual").Points.AddXY(labelX, Double.NaN)
                End If

                If stockProyectado <= 0 Then
                    UltProyectado = True
                End If
            End If

            If Grafico_Mov_Stock.Series.IndexOf("StockNecesarioNMenosXMeses") >= 0 Then
                Grafico_Mov_Stock.Series("StockNecesarioNMenosXMeses").Points.AddXY(labelX, stockNecesarioMenos)
            End If

            ' Añadir punto de llegadas solo si hubo llegadas (> 0)
            If llegadasMes > 0 AndAlso Grafico_Mov_Stock.Series.IndexOf("LlegadasMes") >= 0 Then
                Grafico_Mov_Stock.Series("LlegadasMes").Points.AddXY(labelX, llegadasMes)
            End If

        Next

        ' Formato ejes
        ca.AxisX.Interval = 1
        ca.AxisX.LabelStyle.Angle = -45
        ca.AxisX.MajorGrid.Enabled = False
        ca.AxisX.Title = "Mes - Año"
        ca.AxisY.Title = "Cantidad"
        ca.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot

        ' Formato de etiquetas del eje Y: 2 decimales
        ca.AxisY.LabelStyle.Format = "N2"

        ' Ajustar escala Y para mostrar desde cero
        ca.RecalculateAxesScale()
        If ca.AxisY.Minimum > 0 Then
            ca.AxisY.Minimum = 0
        End If

        Chk_StockSemanal.Text = seriesConfig("StockMes")
        Chk_StockProyectadoMensual.Text = seriesConfig("StockProyectadoMensual")
        Chk_StockNecesarioNMeses.Text = seriesConfig("StockNecesarioNMeses")
        Chk_StockNecesarioNMenosXMeses.Text = seriesConfig("StockNecesarioNMenosXMeses")

        ' Forzar refresh del control
        Grafico_Mov_Stock.Invalidate()

    End Sub

    ' Pseudocódigo detallado:
    ' 1. Recorrer cada fila de _Tbl_Semanal.
    ' 2. Calcular labelX igual que antes para mantener la posición en el eje X.
    ' 3. Obtener y redondear los valores numéricos (stockSemanal, stockNecesario, stockProyectado, stockNecesarioMenos, llegadasSemanal, stockMes).
    ' 4. Para mantener la secuencia de puntos en el tiempo sin mostrar ceros:
    '    - Siempre añadir un punto en la serie "LlegadasSemanal" por cada iteración.
    '    - Si llegadasSemanal > 0 -> añadir el valor real.
    '    - Si llegadasSemanal = 0 -> añadir Double.NaN (punto vacío) usando el mismo labelX.
    '    - De este modo la serie avanza en el tiempo (misma cantidad de puntos/x) pero no dibuja marcadores para ceros.
    ' 5. Comprobar que la serie exista antes de usarla para evitar excepciones.
    ' 6. Añadir una nueva serie de tipo Point llamada "StockMes" que representará el stock mensual,
    '    - Solo agregar el punto a "StockMes" cuando labelX <> String.Empty (según requisito).
    ' 7. Conservar el resto del comportamiento (StockInicial, StockSemanal, etc.).
    '
    ' Resultado: la serie "StockMes" aparecerá como puntos en el gráfico semanal alineados con semanas,
    ' pero solo en las entradas donde labelX no está vacío.

    Sub Sb_Poblar_Grafico_Semanal()

        ' Pseudocódigo detallado:
        ' 1. Verificar existencia de datos.
        ' 2. Asegurar ChartArea y limpiar series/leyendas.
        ' 3. Crear series (ya implementado).
        ' 4. Antes de iterar, construir un primer punto "inicio" para StockSemanal:
        '    - Leer la primera fila de _Tbl_Semanal y extraer LlegadasSemanal (comprobando DBNull).
        '    - Calcular initialStock = StockInicial + llegadasPrimeraFila (si llegadas > 0), redondeado a 2 decimales.
        '    - Agregar un punto inicial en la serie "StockSemanal" con label "" y valor initialStock (si la serie existe).
        '    - Agregar Double.NaN en las demás series (cuando existan) para mantener la alineación temporal.
        ' 5. Continuar con el bucle existente: cada fila añade sus puntos normales.
        ' 6. Mantener la lógica de agregar StockInicial dentro del primer registro del bucle (con su propia serie).
        ' 7. Formatear ejes y forzar refresh.
        '
        ' Resultado: el gráfico semanal comienza con un punto inicial que representa StockInicial + primera llegada,
        ' y luego sigue el consumo a lo largo de las semanas.

        ' Verificar datos
        If _Tbl_Semanal Is Nothing OrElse _Tbl_Semanal.Rows.Count = 0 Then
            If Grafico_Mov_Stock IsNot Nothing Then
                Grafico_Mov_Stock.Series.Clear()
                Grafico_Mov_Stock.Titles.Clear()
                Grafico_Mov_Stock.Legends.Clear()
            End If
            Return
        End If

        ' Asegurar chartarea y limpieza
        If Grafico_Mov_Stock.ChartAreas.Count = 0 Then
            Grafico_Mov_Stock.ChartAreas.Add("ChartArea1")
        End If

        Dim ca As ChartArea = Grafico_Mov_Stock.ChartAreas(0)
        Grafico_Mov_Stock.Series.Clear()
        Grafico_Mov_Stock.Legends.Clear()
        Grafico_Mov_Stock.Legends.Add(New Legend("Legend1"))

        ' Definir series a crear (nombre interno -> texto de leyenda)
        Dim seriesConfig As New Dictionary(Of String, String) From {
            {"StockSemanal", "Stock Semanal"},
            {"StockNecesarioNSemanas", "Stock Necesario n Semanas"},
            {"StockProyectadoSemanal", "Stock Proyectado Semanal"},
            {"StockNecesarioNMenosXSemanas", "Stock Necesario 8 MenosXSemanas"},
            {"LlegadasSemanal", "Llegadas Semanal"},
            {"StockMes", "Stock Mes"}, ' Nueva serie de puntos con valor mensual (mostrar solo cuando labelX <> "")
            {"StockInicial", "Stock Inicial"}
        }

        ' Crear series con formato base
        For Each kvp In seriesConfig
            Dim s As Series = Grafico_Mov_Stock.Series.Add(kvp.Key)

            If kvp.Key = "LlegadasSemanal" Then
                s.ChartType = SeriesChartType.Point
                s.XValueType = ChartValueType.String
                s.BorderWidth = 0
                s.MarkerStyle = MarkerStyle.Circle
                s.MarkerSize = 7
                s.Color = Color.FromArgb(255, 220, 80, 0)
                s.IsValueShownAsLabel = False
                s.LabelFormat = "N2"
            ElseIf kvp.Key = "StockMes" Then
                ' Serie nueva: stock mensual mostrada como puntos en el gráfico semanal
                s.ChartType = SeriesChartType.Point
                s.XValueType = ChartValueType.String
                s.BorderWidth = 0
                s.MarkerStyle = MarkerStyle.Diamond
                s.MarkerSize = 7
                s.Color = Color.FromArgb(255, 0, 120, 215)
                s.IsValueShownAsLabel = False
                s.LabelFormat = "N2"
            ElseIf kvp.Key = "StockInicial" Then
                s.ChartType = SeriesChartType.Point
                s.XValueType = ChartValueType.String
                s.BorderWidth = 0
                s.MarkerStyle = MarkerStyle.Circle
                s.MarkerSize = 9
                s.Color = Color.Green
                s.IsValueShownAsLabel = False
                s.LabelFormat = "N2"
            Else
                s.ChartType = SeriesChartType.Line
                s.XValueType = ChartValueType.String
                s.BorderWidth = 2

                If s.Name = "StockSemanal" Or s.Name = "StockProyectadoSemanal" Then
                    s.MarkerStyle = MarkerStyle.Circle
                    s.MarkerSize = 5
                Else
                    s.MarkerStyle = MarkerStyle.None
                    s.MarkerSize = 0
                End If

                s.IsValueShownAsLabel = False
                s.LabelFormat = "N2"
            End If

            s.Legend = "Legend1"
            s.LegendText = kvp.Value
        Next

        ''' --- Nuevo: agregar primer registro que representa el stock inicial + primera llegada ---
        ''Try
        ''    Dim primeraLlegada As Double = 0
        ''    If _Tbl_Semanal.Columns.Contains("LlegadasSemanal") AndAlso Not IsDBNull(_Tbl_Semanal.Rows(0)("LlegadasSemanal")) Then
        ''        Double.TryParse(_Tbl_Semanal.Rows(0)("LlegadasSemanal").ToString(), primeraLlegada)
        ''    End If

        ''    Dim stockInicialMasLlegada As Double = Math.Round(Me.StockInicial + If(primeraLlegada > 0, primeraLlegada, 0), 2)

        ''    ' Agregar punto inicial en StockSemanal con label vacío para que quede como primer punto
        ''    If Grafico_Mov_Stock.Series.IndexOf("StockSemanal") >= 0 Then
        ''        Grafico_Mov_Stock.Series("StockSemanal").Points.AddXY("", stockInicialMasLlegada)
        ''    End If

        ''    ' Mantener la alineación temporal: agregar Double.NaN en las otras series (si existen)
        ''    Dim keysParaNaN As String() = {"StockNecesarioNSemanas", "StockProyectadoSemanal", "StockNecesarioNMenosXSemanas", "LlegadasSemanal", "StockMes"}
        ''    For Each k In keysParaNaN
        ''        If Grafico_Mov_Stock.Series.IndexOf(k) >= 0 Then
        ''            Grafico_Mov_Stock.Series(k).Points.AddXY("", Double.NaN)
        ''        End If
        ''    Next
        ''    ' No agregar aquí StockInicial (se añade en el primer ciclo para mantener consistencia actual)
        ''Catch ex As Exception
        ''    ' No interrumpir si ocurre algo al construir el punto inicial
        ''End Try
        ''' --- Fin nuevo bloque ---


        Dim labelX As String

        Dim stockSemanal As Double = 0
        Dim stockNecesario As Double = 0
        Dim stockProyectado As Double = 0
        Dim stockNecesarioMenos As Double = 0
        Dim llegadasSemanal As Double = 0
        Dim stockMes As Double = 0

        ' Recorrer filas y agregar puntos
        Dim isFirstSemana As Boolean = True
        Dim UltlabelX As String = String.Empty
        Dim UltProyectado As Boolean = False

        '' Agregar punto stock inicial en el primer registro
        'If isFirstSemana AndAlso Grafico_Mov_Stock.Series.IndexOf("StockInicial") >= 0 Then
        '    Grafico_Mov_Stock.Series("StockSemanal").Points.AddXY("Stock Inicial", Math.Round(Me.StockInicial, 2))
        '    'isFirstSemana = False
        'End If

        'Grafico_Mov_Stock.Series("StockSemanal").Points.AddXY("", Double.NaN)
        'Grafico_Mov_Stock.Series("StockNecesarioNSemanas").Points.AddXY("", Double.NaN)
        'Grafico_Mov_Stock.Series("StockProyectadoSemanal").Points.AddXY("", Double.NaN)
        'Grafico_Mov_Stock.Series("StockNecesarioNMenosXSemanas").Points.AddXY("", Double.NaN)
        'Grafico_Mov_Stock.Series("llegadasSemanal").Points.AddXY("", Double.NaN)
        'Grafico_Mov_Stock.Series("StockMes").Points.AddXY("", Double.NaN)

        For Each row As DataRow In _Tbl_Semanal.Rows

            Dim nombreMes As String = If(IsDBNull(row("NombreMes")), String.Empty, row("NombreMes").ToString().Trim())
            Dim periodo As String = If(IsDBNull(row("Periodo")), String.Empty, row("Periodo").ToString().Trim())
            labelX = $"{nombreMes} {periodo}"

            If row.Table.Columns.Contains("NombreSemana") AndAlso Not IsDBNull(row("NombreSemana")) Then
                If UltlabelX <> labelX Then
                    UltlabelX = labelX
                Else
                    labelX = String.Empty
                End If
            Else
                Dim semana As String = If(IsDBNull(row("Semana")), String.Empty, row("Semana").ToString().Trim())
                labelX = $"{semana} - {nombreMes} {periodo}".Trim()
            End If

            If row.Table.Columns.Contains("StockSemanal") AndAlso Not IsDBNull(row("StockSemanal")) Then
                Double.TryParse(row("StockSemanal").ToString(), stockSemanal)
            Else
                stockSemanal = 0
            End If

            If row.Table.Columns.Contains("StockNecesarioNSemanas") AndAlso Not IsDBNull(row("StockNecesarioNSemanas")) Then
                Double.TryParse(row("StockNecesarioNSemanas").ToString(), stockNecesario)
            Else
                stockNecesario = 0
            End If

            If row.Table.Columns.Contains("StockProyectadoSemanal") AndAlso Not IsDBNull(row("StockProyectadoSemanal")) Then
                Double.TryParse(row("StockProyectadoSemanal").ToString(), stockProyectado)
            Else
                stockProyectado = 0
            End If

            If row.Table.Columns.Contains("StockNecesarioNMenosXSemanas") AndAlso Not IsDBNull(row("StockNecesarioNMenosXSemanas")) Then
                Double.TryParse(row("StockNecesarioNMenosXSemanas").ToString(), stockNecesarioMenos)
            Else
                stockNecesarioMenos = 0
            End If

            If row.Table.Columns.Contains("LlegadasSemanal") AndAlso Not IsDBNull(row("LlegadasSemanal")) Then
                Double.TryParse(row("LlegadasSemanal").ToString(), llegadasSemanal)
            Else
                llegadasSemanal = 0
            End If

            ' Leer StockMes si está presente (valor mensual asociado a la fila semanal)
            If row.Table.Columns.Contains("StockMes") AndAlso Not IsDBNull(row("StockMes")) Then
                Double.TryParse(row("StockMes").ToString(), stockMes)
                stockMes = stockSemanal
            Else
                stockMes = 0
            End If

            ' Redondear valores
            stockSemanal = Math.Round(stockSemanal, 2)
            stockNecesario = Math.Round(stockNecesario, 2)
            stockProyectado = Math.Round(stockProyectado, 2)
            stockNecesarioMenos = Math.Round(stockNecesarioMenos, 2)
            llegadasSemanal = Math.Round(llegadasSemanal, 2)
            'stockMes = Math.Round(stockMes, 2)

            ' Agregar punto stock inicial en el primer registro (serie StockInicial)
            If isFirstSemana AndAlso Grafico_Mov_Stock.Series.IndexOf("StockInicial") >= 0 Then
                Grafico_Mov_Stock.Series("StockInicial").Points.AddXY("", Math.Round(Me.StockInicial, 2))
                isFirstSemana = False
            End If

            ' Agregar puntos (si existe la serie)
            If Grafico_Mov_Stock.Series.IndexOf("StockSemanal") >= 0 Then
                Grafico_Mov_Stock.Series("StockSemanal").Points.AddXY(labelX, stockSemanal)
            End If

            If Grafico_Mov_Stock.Series.IndexOf("StockNecesarioNSemanas") >= 0 Then
                Grafico_Mov_Stock.Series("StockNecesarioNSemanas").Points.AddXY("", stockNecesario)
            End If

            If stockProyectado >= 0 Then ' Grafico_Mov_Stock.Series.IndexOf("StockProyectadoSemanal") > 0 Then
                If Not UltProyectado Then
                    Grafico_Mov_Stock.Series("StockProyectadoSemanal").Points.AddXY("", stockProyectado)
                End If

                If stockProyectado <= 0 Then
                    UltProyectado = True
                End If
            End If

            If Grafico_Mov_Stock.Series.IndexOf("StockNecesarioNMenosXSemanas") >= 0 Then
                Grafico_Mov_Stock.Series("StockNecesarioNMenosXSemanas").Points.AddXY("", stockNecesarioMenos)
            End If

            ' Añadir punto de llegadas: usar Double.NaN para ceros para mantener la secuencia temporal sin dibujar marcador
            If Grafico_Mov_Stock.Series.IndexOf("LlegadasSemanal") >= 0 Then
                Dim valorLlegada As Double = If(llegadasSemanal > 0, llegadasSemanal, Double.NaN)
                ' Usar el mismo labelX para alinear con StockSemanal en el eje X
                Grafico_Mov_Stock.Series("LlegadasSemanal").Points.AddXY(labelX, valorLlegada)
            End If

            '' Añadir punto de stock mensual como punto (solo cuando labelX no es vacío)
            If UltlabelX = labelX Then ' labelX <> String.Empty AndAlso Grafico_Mov_Stock.Series.IndexOf("StockMes") >= 0 Then
                Grafico_Mov_Stock.Series("StockMes").Points.AddXY(labelX, stockMes)
            Else
                Grafico_Mov_Stock.Series("StockMes").Points.AddXY(labelX, Double.NaN)
            End If

        Next

        ' Formato ejes
        ca.AxisX.Interval = 1
        ca.AxisX.LabelStyle.Angle = -45
        ca.AxisX.MajorGrid.Enabled = False
        ca.AxisX.Title = "Semana - Mes - Año"
        ca.AxisY.Title = "Cantidad"
        ca.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot

        ' Formato de etiquetas del eje Y: 2 decimales
        ca.AxisY.LabelStyle.Format = "N2"

        ' Ajustar escala Y para mostrar desde cero
        ca.RecalculateAxesScale()
        If ca.AxisY.Minimum > 0 Then
            ca.AxisY.Minimum = 0
        End If

        Chk_StockSemanal.Text = seriesConfig("StockSemanal")
        Chk_StockProyectadoMensual.Text = seriesConfig("StockProyectadoSemanal")
        Chk_StockNecesarioNMeses.Text = seriesConfig("StockNecesarioNSemanas")
        Chk_StockNecesarioNMenosXMeses.Text = seriesConfig("StockNecesarioNMenosXSemanas")

        ' Forzar refresh del control
        Grafico_Mov_Stock.Invalidate()

    End Sub

    Sub Sb_Ver_Etiquetas_Grafico_Tiempo_Reposicion()

        Try
            If Rdb_Proyeccion_Meses.Checked Then
                Grafico_Mov_Stock.Series("StockMes").IsValueShownAsLabel = Chk_StockMes.Checked
                Grafico_Mov_Stock.Series("StockSemanal").IsValueShownAsLabel = Chk_StockSemanal.Checked
                Grafico_Mov_Stock.Series("StockNecesarioNMeses").IsValueShownAsLabel = Chk_StockNecesarioNMeses.Checked
                Grafico_Mov_Stock.Series("StockProyectadoMensual").IsValueShownAsLabel = Chk_StockProyectadoMensual.Checked
                Grafico_Mov_Stock.Series("StockNecesarioNMenosXMeses").IsValueShownAsLabel = Chk_StockNecesarioNMenosXMeses.Checked
                Grafico_Mov_Stock.Series("LlegadasMes").IsValueShownAsLabel = Chk_LlegadasMes.Checked
                Grafico_Mov_Stock.Series("StockInicial").IsValueShownAsLabel = Chk_StockInicial.Checked
            ElseIf Rdb_Proyeccion_Semanas.Checked Then
                Grafico_Mov_Stock.Series("StockMes").IsValueShownAsLabel = Chk_StockMes.Checked
                Grafico_Mov_Stock.Series("StockSemanal").IsValueShownAsLabel = Chk_StockSemanal.Checked
                Grafico_Mov_Stock.Series("StockNecesarioNSemanas").IsValueShownAsLabel = Chk_StockNecesarioNMeses.Checked
                Grafico_Mov_Stock.Series("StockProyectadoSemanal").IsValueShownAsLabel = Chk_StockProyectadoMensual.Checked
                Grafico_Mov_Stock.Series("StockNecesarioNMenosXSemanas").IsValueShownAsLabel = Chk_StockNecesarioNMenosXMeses.Checked
                Grafico_Mov_Stock.Series("LlegadasSemanal").IsValueShownAsLabel = Chk_LlegadasMes.Checked
                Grafico_Mov_Stock.Series("StockInicial").IsValueShownAsLabel = Chk_StockInicial.Checked
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Rdb_Proyeccion_Meses_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_Proyeccion_Meses.CheckedChanged
        Sb_Poblar_Grafico_Mensual()
        If Rdb_Proyeccion_Meses.Checked Then
            Sb_Ver_Etiquetas_Grafico_Tiempo_Reposicion()
        End If
    End Sub

    Private Sub Rdb_Proyeccion_Semanas_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_Proyeccion_Semanas.CheckedChanged
        Sb_Poblar_Grafico_Semanal()
        If Rdb_Proyeccion_Semanas.Checked Then
            Sb_Ver_Etiquetas_Grafico_Tiempo_Reposicion()
        End If
    End Sub

    Private Sub Btn_Exportar_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Exportar_Excel.Click
        Try
            If Rdb_Proyeccion_Meses.Checked Then
                ExportarTabla_JetExcel_Tabla(_Tbl_Mensual, Me, "Proyeccion_Mensual")
            ElseIf Rdb_Proyeccion_Semanas.Checked Then
                ExportarTabla_JetExcel_Tabla(_Tbl_Semanal, Me, "Proyeccion_Semanal")
            End If
        Catch ex As Exception

        End Try
    End Sub

End Class
