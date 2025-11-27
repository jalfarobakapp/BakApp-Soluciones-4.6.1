Imports System.Windows.Forms.DataVisualization.Charting

Public Class Frm_SobreStock_Grafico

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Cl_SobreStockXClas As New Cl_SobreStockXClas

    Dim _Codigo As String
    Dim _Codigo_Nodo_Madre As String

    Dim _Tbl As DataTable

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
        Else
            Sb_Actualizar_Productos_Mensual()
        End If


    End Sub

    Sub Sb_Actualizar_Productos_Mensual()

        Consulta_sql = $"-- Estudio de proyección de ventas por MES

SELECT 
    Codigo,
	Codigo_Nodo_Madre,
    Periodo,
    Mes,
    NombreMes,
    MAX(StockMes) AS StockMes,          -- stock al cierre del mes
    MAX(VentaMes) AS VentaMes,          -- rotación mensual
    LlegadasMes AS LlegadasMes,     -- total llegadas del mes
	MAX(StockNecesarioNMeses) As StockNecesarioNMeses,
	MAX(StockProyectadoMensual) As StockProyectadoMensual,
	MAX(StockNecesarioNMenosXMeses) As StockNecesarioNMenosXMeses

FROM {_Cl_SobreStockXClas.TablaCalendarioMesesSemanasProductos}
Where Codigo = '{_Codigo}'
GROUP BY Codigo, Codigo_Nodo_Madre, Periodo, Mes, NombreMes,LlegadasMes
ORDER BY Codigo, Periodo, Mes;"

        _Tbl = _Sql.Fx_Get_DataTable(Consulta_sql)

        ' Luego de obtener la tabla, poblar el gráfico
        Sb_Poblar_Grafico()

    End Sub

    Sub Sb_Actualizar_Clasificaciones_Mensual()

        Consulta_sql = $"-- Estudio de proyección de ventas por MES

SELECT 
    Codigo_Nodo_Madre,
    Periodo,
    Mes,
    NombreMes,
    MAX(StockMes) AS StockMes,          -- stock al cierre del mes
    MAX(VentaMes) AS VentaMes,          -- rotación mensual
    LlegadasMes AS LlegadasMes,         -- total llegadas del mes
	MAX(StockNecesarioNMeses) As StockNecesarioNMeses,
	MAX(StockProyectadoMensual) As StockProyectadoMensual,
	MAX(StockNecesarioNMenosXMeses) As StockNecesarioNMenosXMeses

FROM {_Cl_SobreStockXClas.TablaCalendarioMesesSemanasClasificacion}
Where Codigo_Nodo_Madre = '{_Codigo_Nodo_Madre}'
GROUP BY Codigo_Nodo_Madre, Periodo, Mes, NombreMes,LlegadasMes
ORDER BY Codigo_Nodo_Madre, Periodo, Mes;"

        _Tbl = _Sql.Fx_Get_DataTable(Consulta_sql)

        ' Luego de obtener la tabla, poblar el gráfico
        Sb_Poblar_Grafico()

    End Sub

    Sub Sb_Poblar_Grafico()

        ' Verificar datos
        If _Tbl Is Nothing OrElse _Tbl.Rows.Count = 0 Then
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
            {"StockMes", "StockMes"},
            {"StockNecesarioNMeses", "StockNecesarioNMeses"},
            {"StockProyectadoMensual", "StockProyectadoMensual"},
            {"StockNecesarioNMenosXMeses", "StockNecesarioNMenosXMeses"}
        }

        ' Crear series con formato base
        For Each kvp In seriesConfig
            Dim s As Series = Grafico_Mov_Stock.Series.Add(kvp.Key)
            s.ChartType = SeriesChartType.Line
            s.XValueType = ChartValueType.String
            s.BorderWidth = 2
            s.MarkerStyle = MarkerStyle.Circle
            s.MarkerSize = 5
            s.IsValueShownAsLabel = False
            s.Legend = "Legend1"
            s.LegendText = kvp.Value
        Next

        ' Recorrer filas y agregar puntos
        For Each row As DataRow In _Tbl.Rows

            Dim nombreMes As String = If(IsDBNull(row("NombreMes")), String.Empty, row("NombreMes").ToString().Trim())
            Dim periodo As String = If(IsDBNull(row("Periodo")), String.Empty, row("Periodo").ToString().Trim())
            Dim labelX As String = $"{nombreMes} {periodo}"

            Dim stockMes As Double = 0
            Dim stockNecesario As Double = 0
            Dim stockProyectado As Double = 0
            Dim stockNecesarioMenos As Double = 0

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

            ' Agregar puntos (si existe la serie)
            If Grafico_Mov_Stock.Series.IndexOf("StockMes") >= 0 Then
                Grafico_Mov_Stock.Series("StockMes").Points.AddXY(labelX, stockMes)
            End If

            If Grafico_Mov_Stock.Series.IndexOf("StockNecesarioNMeses") >= 0 Then
                Grafico_Mov_Stock.Series("StockNecesarioNMeses").Points.AddXY(labelX, stockNecesario)
            End If

            If Grafico_Mov_Stock.Series.IndexOf("StockProyectadoMensual") >= 0 Then
                Grafico_Mov_Stock.Series("StockProyectadoMensual").Points.AddXY(labelX, stockProyectado)
            End If

            If Grafico_Mov_Stock.Series.IndexOf("StockNecesarioNMenosXMeses") >= 0 Then
                Grafico_Mov_Stock.Series("StockNecesarioNMenosXMeses").Points.AddXY(labelX, stockNecesarioMenos)
            End If

        Next

        ' Formato ejes
        ca.AxisX.Interval = 1
        ca.AxisX.LabelStyle.Angle = -45
        ca.AxisX.MajorGrid.Enabled = False
        ca.AxisX.Title = "Mes - Año"
        ca.AxisY.Title = "Cantidad"
        ca.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot

        ' Ajustar escala Y para mostrar desde cero
        ca.RecalculateAxesScale()
        If ca.AxisY.Minimum > 0 Then
            ca.AxisY.Minimum = 0
        End If

        ' Forzar refresh del control
        Grafico_Mov_Stock.Invalidate()

    End Sub

End Class
