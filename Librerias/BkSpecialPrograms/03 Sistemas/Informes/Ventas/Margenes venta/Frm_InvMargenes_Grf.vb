Imports DevComponents.DotNetBar
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Windows.Forms
Imports System.Drawing
'Imports Lib_Bakapp_VarClassFunc


Public Class Frm_InvMargenes_Grf

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _TablaGrf_Mg As DataTable
    Dim _TablaGrf_Mk As DataTable

    Dim _TblMrg_Informe As DataTable
    Dim _Tbl_Detalle As DataTable

    Public Property TablaGrf_Mg As DataTable
        Get
            Return _TablaGrf_Mg
        End Get
        Set(value As DataTable)
            _TablaGrf_Mg = value
        End Set
    End Property

    Public Property TablaGrf_Mk As DataTable
        Get
            Return _TablaGrf_Mk
        End Get
        Set(value As DataTable)
            _TablaGrf_Mk = value
        End Set
    End Property

    Public Property TblMrg_Informe As DataTable
        Get
            Return _TblMrg_Informe
        End Get
        Set(value As DataTable)
            _TblMrg_Informe = value
        End Set
    End Property

    Public Property Tbl_Detalle As DataTable
        Get
            Return _Tbl_Detalle
        End Get
        Set(value As DataTable)
            _Tbl_Detalle = value
        End Set
    End Property

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Mg, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, True, False)
        Sb_Formato_Generico_Grilla(Grilla_Mk, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, True, False)

        If Global_Thema = Enum_Themas.Oscuro Then
            BtnExportarExcel.ForeColor = Color.White
        End If

    End Sub

    Private Sub Frm_InvMargenes_Grf_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Grilla_Mg.DataSource = TablaGrf_Mg
        LlenarGrafico(Grafico1, TablaGrf_Mg, 0)
        FormatoGrilla(Grilla_Mg)

        Grilla_Mk.DataSource = TablaGrf_Mk
        LlenarGrafico(Grafico1, TablaGrf_Mk, 1)
        FormatoGrilla(Grilla_Mg)
        FormatoGrilla(Grilla_Mk)

        Grafico1.Series(0).IsValueShownAsLabel = True
        Grafico1.Series(0).MarkerStyle = MarkerStyle.Circle
        Grafico1.Series(0).BorderWidth = 3

        Grafico1.Series(1).IsValueShownAsLabel = False
        Grafico1.Series(1).MarkerStyle = MarkerStyle.None
        Grafico1.Series(1).BorderWidth = 1

        'Grafico1.ChartAreas(0).AxisX.LabelStyle.Format = "N"
        'Grafico1.ChartAreas(0).AxisY.LabelStyle.Format = "C0"

        Sb_Formato_Graficos(Grafico1, 0, 0)
        Sb_Formato_Graficos(Grafico1, 0, 1)

        SuperTabControl1.SelectedTabIndex = 0
        Call SuperTabControl1_SelectedTabChanged(Nothing, Nothing)

    End Sub
    Sub LlenarGrafico(ByVal Grafico As Chart,
                      ByVal Tabla As DataTable,
                      ByVal Serie As Integer)

        Try

            Dim firstView As New DataView(Tabla)

            ' Since the DataView implements IEnumerable, pass the reader directly into
            '   the DataBind method with the name of the Columns selected in the query    

            With Grafico

                ' Create cursor object
                Dim cursor As System.Windows.Forms.DataVisualization.Charting.Cursor

                ' Set cursor object
                cursor = .ChartAreas(0).CursorY

                ' Set cursor properties
                cursor.LineWidth = 2
                cursor.LineDashStyle = ChartDashStyle.DashDot
                cursor.LineColor = Color.Red
                cursor.SelectionColor = Color.Yellow

                ' Set cursor selection color of X axis cursor
                .ChartAreas(0).CursorX.SelectionColor = Color.Yellow

                ' Set Grid lines and tick marks interval
                .Series(Serie).XValueType = ChartValueType.Double

                ' Set X axis automatic fitting style
                .ChartAreas(0).AxisX.LabelAutoFitStyle =
                 LabelAutoFitStyles.DecreaseFont 'ON LabelAutoFitStyle.DecreaseFont Or LabelAutoFitStyle.IncreaseFont Or LabelAutoFitStyle.WordWrap

                '
                '.ChartAreas(0).AxisX.Interval = 1

                '.ChartAreas(0).AxisY.Interval = 0
                '.ChartAreas(0).AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount

                '.ChartAreas(0).AxisX.MajorGrid.Interval = 0
                '.ChartAreas(0).AxisX.MajorTickMark.Interval = 1
                '.ChartAreas(0).AxisX.MinorGrid.Interval = 0.5
                '.ChartAreas(0).AxisX.MinorTickMark.Interval = 0.5
                '.ChartAreas(0).AxisX.IsMarginVisible = True

                .Series(Serie).Points.DataBindXY(firstView, "Rango", firstView, "Cantidad")

                .Titles(0).Text = "Margenes..."

                ' Loop through all series
                ''Dim series As Series
                ''For Each series In Grafico.Series
                ' Set empty points visual appearance attributes
                ''Series.EmptyPointStyle.Color = Color.Red
                ''Series.EmptyPointStyle.BorderWidth = 1
                ''Series.EmptyPointStyle.BorderDashStyle = ChartDashStyle.Dash
                ''Series.EmptyPointStyle.MarkerSize = 14
                ''Series.EmptyPointStyle.MarkerStyle = MarkerStyle.Cross
                ''Series.EmptyPointStyle.MarkerBorderColor = Color.Black
                ''Series.EmptyPointStyle.MarkerColor = Color.Red
                ''Next series

            End With

        Catch ex As Exception
            MessageBoxEx.Show(ex.Message)
        End Try

    End Sub
    Sub FormatoGrilla(ByVal Grilla As DataGridView)

        With Grilla
            ' Rango, Desde, Hasta, Cantidad

            .Columns("Rango").Width = 100
            .Columns("Rango").HeaderText = "Rango margen"
            .Columns("Rango").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("Desde").Width = 60
            .Columns("Desde").HeaderText = "% Desde"
            .Columns("Desde").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("Hasta").Width = 60
            .Columns("Hasta").HeaderText = "% Hasta"
            .Columns("Hasta").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("Cantidad").Width = 130
            .Columns("Cantidad").HeaderText = "Total de productos"
            .Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Cantidad").DefaultCellStyle.Format = "###,#0.##"

        End With

    End Sub
    Private Sub Grilla_Mg_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla_Mg.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla_Mg.Rows(Grilla_Mg.CurrentRow.Index)

        Dim _Rango As String = _Fila.Cells("Rango").Value
        Dim _Desde As String = _Fila.Cells("Desde").Value
        Dim _Hasta As String = _Fila.Cells("Hasta").Value

        Dim _Tbl As DataTable = Fx_Crea_Tabla_Con_Filtro(_TblMrg_Informe, "Grupo_Mg >= " & _Desde & " And Grupo_Mg <= " & _Hasta, "")

        If CBool(_Tbl.Rows.Count) Then

            Dim Fm As New Frm_InvMargenes_Grf_Res

            Fm.Text = "Informe Rango de porcentage:  " & _Rango
            Fm.Tbl_Detalle = Tbl_Detalle
            Fm.Tbl_Informe = _Tbl
            Fm.ShowDialog(Me)

        Else

            MessageBoxEx.Show(Me, "No existe información", "Ver productos", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

    End Sub
    Private Sub Grilla_Mk_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla_Mk.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla_Mg.Rows(Grilla_Mk.CurrentRow.Index)

        Dim _Rango As String = _Fila.Cells("Rango").Value
        Dim _Desde As String = _Fila.Cells("Desde").Value
        Dim _Hasta As String = _Fila.Cells("Hasta").Value

        Dim _Tbl As DataTable = Fx_Crea_Tabla_Con_Filtro(_TblMrg_Informe, "Grupo_Mk >= " & _Desde & " And Grupo_Mk <= " & _Hasta, "")

        If CBool(_Tbl.Rows.Count) Then

            Dim Fm As New Frm_InvMargenes_Grf_Res

            Fm.Text = "Informe Rango de porcentage:  " & _Rango
            Fm.Tbl_Detalle = Tbl_Detalle
            Fm.Tbl_Informe = _Tbl
            Fm.ShowDialog(Me)

        Else

            MessageBoxEx.Show(Me, "No existe información", "Ver productos", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

    End Sub

    Private Sub BtnExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExportarExcel.Click

        ExportarTabla_JetExcel_Tabla(TablaGrf_Mk, Me, "Margenes")
        ExportarTabla_JetExcel_Tabla(TablaGrf_Mk, Me, "Mg_Costos")
        ExportarTabla_JetExcel_Tabla(_TblMrg_Informe, Me, "Detalle")

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

    Private Sub SuperTabControl1_SelectedTabChanged(sender As Object, e As SuperTabStripSelectedTabChangedEventArgs) Handles SuperTabControl1.SelectedTabChanged

        Dim Tab_ As Integer = SuperTabControl1.SelectedTabIndex

        With Grafico1

            If Tab_ = 1 Then

                .Series(0).IsValueShownAsLabel = True
                .Series(0).MarkerStyle = MarkerStyle.Circle
                .Series(0).BorderWidth = 3

                .Series(1).IsValueShownAsLabel = False
                .Series(1).MarkerStyle = MarkerStyle.None
                .Series(1).BorderWidth = 1

            Else

                .Series(1).IsValueShownAsLabel = True
                .Series(1).MarkerStyle = MarkerStyle.Circle
                .Series(1).BorderWidth = 3

                .Series(0).IsValueShownAsLabel = False
                .Series(0).MarkerStyle = MarkerStyle.None
                .Series(0).BorderWidth = 1

            End If

        End With

    End Sub

End Class