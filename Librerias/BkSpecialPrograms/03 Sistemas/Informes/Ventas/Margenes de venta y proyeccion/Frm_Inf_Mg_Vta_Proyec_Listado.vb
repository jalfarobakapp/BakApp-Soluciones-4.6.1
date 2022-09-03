Imports DevComponents.DotNetBar
Imports System.Windows.Forms.DataVisualization.Charting

Public Class Frm_Inf_Mg_Vta_Proyec_Listado

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Ds As DataSet

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Dtp_Fecha_Desde.Value = Primerdiadelmes(FechaDelServidor())
        Dtp_Fecha_Hasta.Value = FechaDelServidor()

        Sb_Formato_Generico_Grilla(Grilla_Informe_Documentos, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)

        If Global_Thema = Enum_Themas.Oscuro Then
            Tabs.TabStyle = eSuperTabStyle.Office2007
        End If

    End Sub

    Private Sub Frm_Inf_Mg_Vta_Proyec_Listado_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        Sb_Formato_Graficos(Grafico_Desviacion_Estandar, 0, 0)
        Sb_Formato_Graficos(Grafico_Tendencias, 0, 0)
        Sb_Formato_Graficos(Grafico_Ventas_Periodo, 0, 0)

        Sb_Actualizar_Grilla()

    End Sub

    Function Sb_Actualizar_Grilla()

        Dim _Fecha_Desde As String = Format(Dtp_Fecha_Desde.Value, "yyyyMMdd")
        Dim _Fecha_Hasta As String = Format(Dtp_Fecha_Hasta.Value, "yyyyMMdd")

        Dim _EntExcluidas = String.Empty

        If Chk_Quitar_Entidades_Excluidas.Checked Then

            _EntExcluidas = "And ENDO+SUENDO" & vbCrLf &
                            "NOT IN (SELECT Codigo+Sucursal" & vbCrLf &
                            "From " & _Global_BaseBk & "Zw_TblInf_EntExcluidas" & vbCrLf &
                            "Where Funcionario = '" & FUNCIONARIO & "' And Excluida in ('V','A','T'))" & Space(1)

        End If

        Consulta_Sql = My.Resources.Recursos_Inf_MgProyecion.SQLQuery_Revision_Margenes_SeaGarden_Con_Mediana
        Consulta_Sql = Replace(Consulta_Sql, "#Fecha_Desde#", _Fecha_Desde)
        Consulta_Sql = Replace(Consulta_Sql, "#Fecha_Hasta#", _Fecha_Hasta)
        Consulta_Sql = Replace(Consulta_Sql, "#EntExcluidas#", _EntExcluidas)

        _Ds = _Sql.Fx_Get_DataSet(Consulta_Sql)

        Dim _Tbl_Documentos As DataTable = _Ds.Tables(0)
        Dim _Tbl_Detalle As DataTable = _Ds.Tables(1)
        Dim _Tbl_Fechas As DataTable = _Ds.Tables(2)
        Dim _Tbl_Mediana As DataTable = _Ds.Tables(3)
        Dim _Tbl_Totales As DataTable = _Ds.Tables(4)

        Lbl_Total_Margenv.Tag = _Tbl_Totales.Rows(0).Item("Total_Margen")
        Lbl_Total_Margenv.Text = FormatCurrency(Lbl_Total_Margenv.Tag, 0)

        Tabs.SelectedTabIndex = 0
        Tab_04_Grafica_Ventas_Inventario.Visible = False


        With Grilla_Informe_Documentos

            .DataSource = _Tbl_Documentos

            OcultarEncabezadoGrilla(Grilla_Informe_Documentos)

            .Columns("ENDO").Width = 75
            .Columns("ENDO").HeaderText = "Entidad"
            .Columns("ENDO").DisplayIndex = 0
            .Columns("ENDO").Visible = True

            .Columns("NOKOEN").Width = 230
            .Columns("NOKOEN").HeaderText = "Nombre"
            .Columns("NOKOEN").DisplayIndex = 1
            .Columns("NOKOEN").Visible = True

            .Columns("TIDO").Width = 30
            .Columns("TIDO").HeaderText = "TD"
            .Columns("TIDO").DisplayIndex = 2
            .Columns("TIDO").Visible = True

            .Columns("NUDO").Width = 70
            .Columns("NUDO").HeaderText = "Número"
            .Columns("NUDO").DisplayIndex = 3
            .Columns("NUDO").Visible = True

            .Columns("FEEMDO").Width = 75
            .Columns("FEEMDO").HeaderText = "Fecha"
            .Columns("FEEMDO").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FEEMDO").DisplayIndex = 4
            .Columns("FEEMDO").Visible = True

            .Columns("NETO").Width = 80
            .Columns("NETO").HeaderText = "Neto"
            .Columns("NETO").DefaultCellStyle.Format = "$ ##,###"
            .Columns("NETO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("NETO").DisplayIndex = 5
            .Columns("NETO").Visible = True

            .Columns("COSTO").Width = 90
            .Columns("COSTO").HeaderText = "Costo"
            .Columns("COSTO").DefaultCellStyle.Format = "$ ##,###"
            .Columns("COSTO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("COSTO").DisplayIndex = 6
            .Columns("COSTO").Visible = True

            .Columns("MG").Width = 90
            .Columns("MG").HeaderText = "Mrg %"
            .Columns("MG").DefaultCellStyle.Format = "% ##,##0.00"
            .Columns("MG").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("MG").DisplayIndex = 7
            .Columns("MG").Visible = True

            .Columns("MARGEN").Width = 90
            .Columns("MARGEN").HeaderText = "Margen"
            .Columns("MARGEN").DefaultCellStyle.Format = "$ ##,###"
            .Columns("MARGEN").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("MARGEN").DisplayIndex = 8
            .Columns("MARGEN").Visible = True

        End With

        If CBool(_Tbl_Detalle.Rows.Count) Then

            Dim _Tbl_Grafico As DataTable = _Tbl_Fechas

            Sb_Llenar_Grafico(Grafico_Ventas_Periodo, _Tbl_Grafico, 0) 'SqlGrf, 0)
            Sb_Llenar_Grafico(Grafico_Desviacion_Estandar, _Tbl_Grafico, 0, True) 'SqlGrf, 0, True)

            Sb_Llenar_Grafico_Tendencias(_Tbl_Fechas)
            Tab_04_Grafica_Ventas_Inventario.Visible = True

        Else

            MessageBoxEx.Show(Me, "No existen datos que mostrar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Tab_04_Grafica_Ventas_Inventario.Visible = False

        End If

        Me.Refresh()

    End Function

    Sub Sb_Llenar_Grafico(ByVal _Grafico As Chart,
                          ByVal _TblGrafico As DataTable,
                          ByVal _Serie As Integer,
                          Optional ByVal _Tiene_Varianza As Boolean = False)

        With _Grafico

            ' Set Grid lines and tick marks interval
            .Series(_Serie).XValueType = ChartValueType.Date

            ' Set X axis automatic fitting style
            .ChartAreas(_Serie).AxisX.LabelAutoFitStyle = LabelAutoFitStyles.DecreaseFont 'ON LabelAutoFitStyle.DecreaseFont Or LabelAutoFitStyle.IncreaseFont Or LabelAutoFitStyle.WordWrap

            '
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
            .Series(_Serie).Points.DataBindXY(_FirstView, "FEEMDO", _FirstView, "NETO")

            '.Series(_Serie).Points.DataBindXY(myReader, "Periodo", myReader, "Ud")

            If _Tiene_Varianza Then
                '' Calculate Median
                ''Dim median As Double = .DataManipulator.Statistics.Median("Series1")
                '' Calculate Standard Deviation from the Variance
                ''Dim variance As Double = .DataManipulator.Statistics.Variance("Series1", True)
                ''Dim standardDeviation As Double = Math.Sqrt(variance)

                ' Calculate Median
                Dim median As Double '= .DataManipulator.Statistics.Median("Series1")
                ' Calculate Standard Deviation from the Variance
                Dim variance As Double '= .DataManipulator.Statistics.Variance("Series1", True)
                Dim standardDeviation As Double '= Math.Sqrt(variance)

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

                LblDesviacionStandar.Text = FormatNumber(standardDeviation, 3)
                LblMedia.Text = FormatNumber(median, 0)

            Else

                Dim _Rango_Fecha As String

                _Rango_Fecha = "Ventas Desde: " &
                               FormatDateTime(Dtp_Fecha_Desde.Value, DateFormat.ShortDate) &
                               " Hasta: " &
                FormatDateTime(Dtp_Fecha_Hasta.Value, DateFormat.ShortDate)

                .Titles(0).Text = _Rango_Fecha
                .Titles(1).Text = "Ventas..." '_Descripcion

                ' Loop through all series
                Dim series As Series
                For Each series In _Grafico.Series
                    ' Set empty points visual appearance attributes
                    series.EmptyPointStyle.Color = Color.Red
                    series.EmptyPointStyle.BorderWidth = 1
                    series.EmptyPointStyle.BorderDashStyle = ChartDashStyle.Dash
                    series.EmptyPointStyle.MarkerSize = 14
                    series.EmptyPointStyle.MarkerStyle = MarkerStyle.Cross
                    series.EmptyPointStyle.MarkerBorderColor = Color.Black
                    series.EmptyPointStyle.MarkerColor = Color.Red
                    series.LabelFormat = "N0"

                Next series

                ' Set empty points values of Series1 to average.
                '.Series(_Serie)("EmptyPointValue") = "Average"
                .Series(_Serie)("EmptyPointValue") = "Zero"

            End If

        End With

    End Sub

    Private Sub Sb_Llenar_Grafico_Tendencias(ByVal _Tbl_Grafico_Tendencia As DataTable)

        Dim rand As Random = New Random()
        Dim randSeed As Integer = rand.[Next]()

        rand = New Random(randSeed)
        Dim period As Integer = 100 '365 * 2 ' Integer.Parse(comboBoxPeriod.Text)

        Grafico_Tendencias.Series("Ventas").Points.Clear()
        Dim high As Double = rand.NextDouble() * 40

        If high <= 0 Then
            high = -1 * high + 1
        End If

        Dim _Tbl As DataTable = _Tbl_Grafico_Tendencia

        Dim dv As DataView = _Tbl_Grafico_Tendencia.DefaultView
        'dv.RowFilter = "Fecha = '01-09-2017'"

        'Dim _Row As DataTable = dv.Table
        'Dim busca_renglon() As DataRow

        'busca_renglon = _Tbl_Grafico_Tendencia.Select("Fecha = '01-09-2017'")

        'Dim _o = _Row.Rows(0).Item("SumTotalQtyUd1") ' busca_renglon(0).Item("SumTotalQtyUd1")

        Dim close As Double = high - rand.NextDouble()
        Dim low As Double = close - rand.NextDouble()
        Dim volume As Double = 100 + 15 * rand.NextDouble()

        'Dim _D = DateTime.Parse("1/2/2002")

        Dim _Fecha As DateTime = _Tbl_Grafico_Tendencia.Rows(0).Item("FEEMDO")

        Dim _Neto = _Tbl_Grafico_Tendencia.Rows(0).Item("NETO")

        Dim _dias = DateDiff(DateInterval.Day, Dtp_Fecha_Desde.Value, Dtp_Fecha_Hasta.Value)
        period = _dias
        'high = _Tbl_Grafico_Tendencia.Rows(0).Item("SumTotalQtyUd1")

        'Grafico_Tendencias.Series("Input").Points.AddXY(DateTime.Parse("1/2/2002"), 2)

        Grafico_Tendencias.Series("Ventas").Points.AddXY(DateTime.Parse(_Fecha), _Neto)

        Grafico_Tendencias.ChartAreas(0).AxisY.LabelStyle.Format = "N0"

        'Grafico_Tendencias.Series("Input").Points(0).YValues(1) = high 'low
        'Grafico_Tendencias.Series("Input").Points(0).YValues(2) = high 'close
        'Grafico_Tendencias.Series("Input").Points(0).YValues(3) = high 'close

        For day As Integer = 1 To period

            dv.RowFilter = "FEEMDO = '" & Format(_Fecha, "dd-MM-yyyy") & "'"
            Dim _Row As DataTable = dv.Table

            If CBool(dv.Count) Then
                _Neto = dv.Item(0).Item("NETO") ' _Row.Rows(0).Item("SumTotalQtyUd1")
            Else
                _Neto -= 0.1
            End If

            If _Neto < 0 Then
                _Neto = 0
            End If


            'high = Grafico_Tendencias.Series("Input").Points(day - 1).YValues(2) + rand.NextDouble()


            close = _Neto - 0.1 'high - rand.NextDouble()
            low = _Neto - 0.1 'close - rand.NextDouble()
            If low > Grafico_Tendencias.Series("Ventas").Points(day - 1).YValues(2) Then low = Grafico_Tendencias.Series("Ventas").Points(day - 1).YValues(2)

            If high <= 0 Then
                high = -1 * high + 1
            End If

            Grafico_Tendencias.Series("Ventas").Points.AddXY(day, _Neto)

            Dim _Fee = Grafico_Tendencias.Series("Ventas").Points(day - 1).XValue + 1

            Grafico_Tendencias.Series("Ventas").Points(day).XValue = _Fee 'Grafico_Tendencias.Series("Input").Points(day - 1).XValue + 1
            'Grafico_Tendencias.Series("Input").Points(day).YValues(1) = low
            'Grafico_Tendencias.Series("Input").Points(day).YValues(2) = close
            'Grafico_Tendencias.Series("Input").Points(day).YValues(3) = close

            _Fecha = DateAdd(DateInterval.Day, 1, _Fecha)

        Next

        Grafico_Tendencias.Invalidate()

        Calculations()

    End Sub

    Private Sub Calculations()
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

            Dim _Dias = DateDiff(DateInterval.Day, Dtp_Fecha_Desde.Value, Dtp_Fecha_Hasta.Value) + 50

            Dim forecasting As Integer = 30 '75 '_Dias '365 * 2 ' Integer.Parse(comboBoxForecasting.Text)
            Dim [error] As String = "True" 'checkBoxError.Checked.ToString()
            Dim forecastingError As String = "False" 'checkBoxForecastingError.Checked.ToString()
            Dim parameters As String = typeRegression & ","c & forecasting & ","c & [error] & ","c & forecastingError
            'Grafico_Tendencias.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, parameters, "Input:Y", "Forecasting:Y,Range:Y,Range:Y2")
            Grafico_Tendencias.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, parameters, "Ventas:Y", "Proyeccion:Y,Rango:Y,Rango:Y2")
            Grafico_Tendencias.Series("Rango").Enabled = True ' checkBoxError.Checked OrElse checkBoxForecastingError.Checked
            Grafico_Tendencias.Invalidate()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Btn_Actualizar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Btn_Actualizar.Click
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub Btn_Exportar_Excel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Btn_Exportar_Excel.Click
        Dim _Tbl_Documentos As DataTable = _Ds.Tables(0)
        ExportarTabla_JetExcel_Tabla(_Tbl_Documentos, Me, "Documentos margenes")
    End Sub

    Private Sub Grilla_Informe_Documentos_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Grilla_Informe_Documentos.MouseDown
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

    Private Sub Grilla_Informe_Documentos_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles Grilla_Informe_Documentos.CellDoubleClick
        ShowContextMenu(Menu_Contextual_01_Opciones_Documento)
    End Sub

    Private Sub Btn_Ver_documento_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Btn_Ver_documento.Click

        Dim _Idmaeedo As Integer
        _Idmaeedo = Grilla_Informe_Documentos.Rows(Grilla_Informe_Documentos.CurrentRow.Index).Cells("IDMAEEDO").Value

        Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Ver_Documento_Margenes_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Ver_Documento_Margenes.Click
        Dim _Idmaeedo As Integer
        _Idmaeedo = Grilla_Informe_Documentos.Rows(Grilla_Informe_Documentos.CurrentRow.Index).Cells("IDMAEEDO").Value
        Dim Fm As New Frm_Remotas_Analisi_Dscto_X_Documento_Rd(Cadena_ConexionSQL_Server, Nothing, Nothing,
                                                               Frm_Remotas_Analisi_Dscto_X_Documento_Rd.Enum_Tabla.Maeedo, _Idmaeedo)
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub


    Private Sub Btn_Utilidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Utilidad.Click

        Dim _Tbl_Totales As DataTable = _Ds.Tables(4)

        Dim _PP_Mrg As Double = _Tbl_Totales.Rows(0).Item("PP_Mrg")
        Dim _Total_Neto As Double = _Tbl_Totales.Rows(0).Item("Total_Neto")

        Dim Fm As New Frm_Inf_Mg_Vta_Proyec_Utilidad
        Fm.Pro_Fecha_Desde = Dtp_Fecha_Desde.Value
        Fm.Pro_Fecha_Hasta = Dtp_Fecha_Hasta.Value
        Fm.Lbl_PPMg.Tag = Math.Round(_PP_Mrg, 5)
        Fm.Lbl_Total_Neto.Tag = _Total_Neto
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Entidades_Excluidas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Entidades_Excluidas.Click

        If Fx_Tiene_Permiso(Me, "CfEnt016") Then
            Dim Fm As New Frm_EntExcluidas
            Fm.ShowInTaskbar = False
            Fm.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
            Fm.ShowDialog(Me)
            Fm.Dispose()
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
