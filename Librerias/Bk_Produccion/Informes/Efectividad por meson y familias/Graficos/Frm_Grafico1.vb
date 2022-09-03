Imports System.Windows.Forms.DataVisualization.Charting
Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Frm_Grafico1

    Dim _TblGrafico1 As DataTable
    Dim _TblGrafico2 As DataTable
    Dim _Titulo As String
    Dim _Descripcion1 As String
    Dim _Descripcion2 As String
    Dim _Fecha_Desde As DateTime
    Dim _Fecha_Hasta As DateTime

    Public Property TblGrafico1 As DataTable
        Get
            Return _TblGrafico1
        End Get
        Set(value As DataTable)
            _TblGrafico1 = value
        End Set
    End Property

    Public Property Descripcion1 As String
        Get
            Return _Descripcion1
        End Get
        Set(value As String)
            _Descripcion1 = value
        End Set
    End Property

    Public Property Fecha_Desde As Date
        Get
            Return _Fecha_Desde
        End Get
        Set(value As Date)
            _Fecha_Desde = value
        End Set
    End Property

    Public Property Fecha_Hasta As Date
        Get
            Return _Fecha_Hasta
        End Get
        Set(value As Date)
            _Fecha_Hasta = value
        End Set
    End Property

    Public Property TblGrafico2 As DataTable
        Get
            Return _TblGrafico2
        End Get
        Set(value As DataTable)
            _TblGrafico2 = value
        End Set
    End Property

    Public Property Descripcion2 As String
        Get
            Return _Descripcion2
        End Get
        Set(value As String)
            _Descripcion2 = value
        End Set
    End Property

    Public Property Titulo As String
        Get
            Return _Titulo
        End Get
        Set(value As String)
            _Titulo = value
        End Set
    End Property

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_Grafico1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SuperTabControl1.SelectedTabIndex = 0

        Sb_Formato_Graficos(Grafico_1, 0, 0)
        Sb_Formato_Graficos(Grafico_1, 0, 1)

        Sb_Llenar_Grafico(_Descripcion1, _Fecha_Desde, _Fecha_Hasta, Grafico_1, _TblGrafico1, 1, False)
        Sb_Llenar_Grafico(_Descripcion2, _Fecha_Desde, _Fecha_Hasta, Grafico_1, _TblGrafico2, 0, False)

        Dim _Rango_Fecha As String

        _Rango_Fecha = "Ventas Desde: " &
                       FormatDateTime(_Fecha_Desde, DateFormat.ShortDate) &
                       " Hasta: " &
                       FormatDateTime(_Fecha_Hasta, DateFormat.ShortDate)

        Grafico_1.Titles(0).Text = _Rango_Fecha
        Grafico_1.Titles(1).Text = _Titulo

    End Sub

    Sub Sb_Llenar_Grafico(_Descripcion1 As String,
                          _Fecha_Desde As DateTime,
                          _Fecha_Hasta As DateTime,
                          _Grafico As Chart,
                          _TblGrafico1 As DataTable,
                          _Serie As Integer,
                          _Tiene_Varianza As Boolean)

        With _Grafico


            ' Set Grid lines and tick marks interval
            .Series(_Serie).XValueType = ChartValueType.Double

            ' Set X axis automatic fitting style
            .ChartAreas(0).AxisX.LabelAutoFitStyle =
             LabelAutoFitStyles.DecreaseFont 'ON LabelAutoFitStyle.DecreaseFont Or LabelAutoFitStyle.IncreaseFont Or LabelAutoFitStyle.WordWrap

            .ChartAreas(0).AxisX.Interval = 1
            .ChartAreas(0).AxisY.Interval = 0
            .ChartAreas(0).AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount

            .ChartAreas(0).AxisX.MajorGrid.Interval = 0
            .ChartAreas(0).AxisX.MajorTickMark.Interval = 1
            .ChartAreas(0).AxisX.MinorGrid.Interval = 0.5
            .ChartAreas(0).AxisX.MinorTickMark.Interval = 0.5
            .ChartAreas(0).AxisX.IsMarginVisible = True

            .ChartAreas(0).AxisY.LabelStyle.Format = "N0"


            .Series(_Serie).LegendText = _Descripcion1

            Dim _FirstView As New DataView(_TblGrafico1)

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

                    series.LabelFormat = "N0"
                    'If Rdb_Ud2.Checked Then series.LabelFormat = "N2"

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


End Class
