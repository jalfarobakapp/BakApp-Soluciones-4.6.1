<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_SobreStock_Grafico
    Inherits DevComponents.DotNetBar.Metro.MetroForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_SobreStock_Grafico))
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title1 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Dim Title2 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Exportar_Excel = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Actualizar = New DevComponents.DotNetBar.ButtonItem()
        Me.Grafico_Mov_Stock = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Rdb_Proyeccion_Semanas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Proyeccion_Meses = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Chk_Serie4 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Serie3 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Serie2 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Serie1 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grafico_Mov_Stock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Exportar_Excel, Me.Btn_Actualizar})
        Me.Bar2.Location = New System.Drawing.Point(0, 538)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(1187, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 197
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Exportar_Excel
        '
        Me.Btn_Exportar_Excel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Exportar_Excel.ForeColor = System.Drawing.Color.Black
        Me.Btn_Exportar_Excel.Image = CType(resources.GetObject("Btn_Exportar_Excel.Image"), System.Drawing.Image)
        Me.Btn_Exportar_Excel.ImageAlt = CType(resources.GetObject("Btn_Exportar_Excel.ImageAlt"), System.Drawing.Image)
        Me.Btn_Exportar_Excel.Name = "Btn_Exportar_Excel"
        Me.Btn_Exportar_Excel.Tooltip = "Exportar a Excel"
        '
        'Btn_Actualizar
        '
        Me.Btn_Actualizar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Actualizar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Actualizar.Image = CType(resources.GetObject("Btn_Actualizar.Image"), System.Drawing.Image)
        Me.Btn_Actualizar.ImageAlt = CType(resources.GetObject("Btn_Actualizar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Actualizar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Actualizar.Name = "Btn_Actualizar"
        Me.Btn_Actualizar.Tooltip = "Refrescar datos"
        '
        'Grafico_Mov_Stock
        '
        Me.Grafico_Mov_Stock.BackSecondaryColor = System.Drawing.Color.White
        Me.Grafico_Mov_Stock.BorderlineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.Grafico_Mov_Stock.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        Me.Grafico_Mov_Stock.BorderlineWidth = 2
        Me.Grafico_Mov_Stock.BorderSkin.PageColor = System.Drawing.Color.Empty
        ChartArea1.Area3DStyle.Inclination = 15
        ChartArea1.Area3DStyle.IsClustered = True
        ChartArea1.Area3DStyle.IsRightAngleAxes = False
        ChartArea1.Area3DStyle.Perspective = 10
        ChartArea1.Area3DStyle.Rotation = 10
        ChartArea1.Area3DStyle.WallWidth = 0
        ChartArea1.AxisX.LabelAutoFitStyle = CType(((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont) _
            Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap), System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)
        ChartArea1.AxisX.LabelStyle.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold)
        ChartArea1.AxisX.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea1.AxisX.ScrollBar.LineColor = System.Drawing.Color.Black
        ChartArea1.AxisX.ScrollBar.Size = 10.0R
        ChartArea1.AxisY.LabelStyle.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold)
        ChartArea1.AxisY.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea1.AxisY.ScrollBar.LineColor = System.Drawing.Color.Black
        ChartArea1.AxisY.ScrollBar.Size = 10.0R
        ChartArea1.BackColor = System.Drawing.Color.White
        ChartArea1.BackSecondaryColor = System.Drawing.Color.White
        ChartArea1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        ChartArea1.CursorX.IsUserEnabled = True
        ChartArea1.CursorX.IsUserSelectionEnabled = True
        ChartArea1.CursorY.IsUserEnabled = True
        ChartArea1.CursorY.IsUserSelectionEnabled = True
        ChartArea1.Name = "Default"
        ChartArea1.ShadowColor = System.Drawing.Color.Transparent
        Me.Grafico_Mov_Stock.ChartAreas.Add(ChartArea1)
        Me.Grafico_Mov_Stock.Location = New System.Drawing.Point(12, 12)
        Me.Grafico_Mov_Stock.Name = "Grafico_Mov_Stock"
        Series1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Series1.ChartArea = "Default"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine
        Series1.Color = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(176, Byte), Integer))
        Series1.IsVisibleInLegend = False
        Series1.Legend = "Default"
        Series1.LegendText = "Stock consolidado..."
        Series1.MarkerBorderColor = System.Drawing.Color.Red
        Series1.MarkerColor = System.Drawing.Color.Red
        Series1.MarkerSize = 8
        Series1.Name = "Series1"
        Series1.ShadowColor = System.Drawing.Color.Black
        Series1.ShadowOffset = 2
        Series1.YValuesPerPoint = 2
        Series2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Series2.ChartArea = "Default"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point
        Series2.Color = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Series2.IsValueShownAsLabel = True
        Series2.IsVisibleInLegend = False
        Series2.Legend = "Default"
        Series2.LegendText = "Venta mueve Stock..."
        Series2.MarkerColor = System.Drawing.Color.Brown
        Series2.MarkerSize = 4
        Series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Star5
        Series2.Name = "Series2"
        Me.Grafico_Mov_Stock.Series.Add(Series1)
        Me.Grafico_Mov_Stock.Series.Add(Series2)
        Me.Grafico_Mov_Stock.Size = New System.Drawing.Size(1147, 448)
        Me.Grafico_Mov_Stock.TabIndex = 198
        Me.Grafico_Mov_Stock.TabStop = False
        Title1.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold)
        Title1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(105, Byte), Integer))
        Title1.Name = "Title1"
        Title1.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Title1.ShadowOffset = 3
        Title1.Text = "Ventas y Movimiento de Stock"
        Title2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Title2.Name = "Title2"
        Title2.Text = "Tiempo de reposición"
        Me.Grafico_Mov_Stock.Titles.Add(Title1)
        Me.Grafico_Mov_Stock.Titles.Add(Title2)
        '
        'Rdb_Proyeccion_Semanas
        '
        Me.Rdb_Proyeccion_Semanas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Proyeccion_Semanas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Proyeccion_Semanas.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Proyeccion_Semanas.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Proyeccion_Semanas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Proyeccion_Semanas.FocusCuesEnabled = False
        Me.Rdb_Proyeccion_Semanas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Proyeccion_Semanas.Location = New System.Drawing.Point(217, 466)
        Me.Rdb_Proyeccion_Semanas.Name = "Rdb_Proyeccion_Semanas"
        Me.Rdb_Proyeccion_Semanas.Size = New System.Drawing.Size(70, 23)
        Me.Rdb_Proyeccion_Semanas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Proyeccion_Semanas.TabIndex = 201
        Me.Rdb_Proyeccion_Semanas.Text = "Semanas"
        '
        'Rdb_Proyeccion_Meses
        '
        Me.Rdb_Proyeccion_Meses.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Proyeccion_Meses.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Proyeccion_Meses.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Proyeccion_Meses.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Proyeccion_Meses.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Proyeccion_Meses.Checked = True
        Me.Rdb_Proyeccion_Meses.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Proyeccion_Meses.CheckValue = "Y"
        Me.Rdb_Proyeccion_Meses.FocusCuesEnabled = False
        Me.Rdb_Proyeccion_Meses.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Proyeccion_Meses.Location = New System.Drawing.Point(149, 466)
        Me.Rdb_Proyeccion_Meses.Name = "Rdb_Proyeccion_Meses"
        Me.Rdb_Proyeccion_Meses.Size = New System.Drawing.Size(62, 23)
        Me.Rdb_Proyeccion_Meses.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Proyeccion_Meses.TabIndex = 200
        Me.Rdb_Proyeccion_Meses.Text = "Meses"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(12, 466)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(142, 23)
        Me.LabelX1.TabIndex = 199
        Me.LabelX1.Text = "Ver gráfico proyectado en:"
        '
        'Chk_Serie4
        '
        Me.Chk_Serie4.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Serie4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Serie4.FocusCuesEnabled = False
        Me.Chk_Serie4.ForeColor = System.Drawing.Color.Black
        Me.Chk_Serie4.Location = New System.Drawing.Point(557, 495)
        Me.Chk_Serie4.Name = "Chk_Serie4"
        Me.Chk_Serie4.Size = New System.Drawing.Size(284, 19)
        Me.Chk_Serie4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Serie4.TabIndex = 205
        Me.Chk_Serie4.Text = "Stock Necesario n MenosXMese"
        '
        'Chk_Serie3
        '
        Me.Chk_Serie3.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Serie3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Serie3.FocusCuesEnabled = False
        Me.Chk_Serie3.ForeColor = System.Drawing.Color.Black
        Me.Chk_Serie3.Location = New System.Drawing.Point(557, 470)
        Me.Chk_Serie3.Name = "Chk_Serie3"
        Me.Chk_Serie3.Size = New System.Drawing.Size(216, 19)
        Me.Chk_Serie3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Serie3.TabIndex = 204
        Me.Chk_Serie3.Text = "Stock Necesario n"
        '
        'Chk_Serie2
        '
        Me.Chk_Serie2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Serie2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Serie2.FocusCuesEnabled = False
        Me.Chk_Serie2.ForeColor = System.Drawing.Color.Black
        Me.Chk_Serie2.Location = New System.Drawing.Point(382, 495)
        Me.Chk_Serie2.Name = "Chk_Serie2"
        Me.Chk_Serie2.Size = New System.Drawing.Size(169, 19)
        Me.Chk_Serie2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Serie2.TabIndex = 203
        Me.Chk_Serie2.Text = "Stock Proyectado"
        '
        'Chk_Serie1
        '
        Me.Chk_Serie1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Serie1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Serie1.FocusCuesEnabled = False
        Me.Chk_Serie1.ForeColor = System.Drawing.Color.Black
        Me.Chk_Serie1.Location = New System.Drawing.Point(382, 470)
        Me.Chk_Serie1.Name = "Chk_Serie1"
        Me.Chk_Serie1.Size = New System.Drawing.Size(169, 19)
        Me.Chk_Serie1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Serie1.TabIndex = 202
        Me.Chk_Serie1.Text = "Stock Mes"
        '
        'Frm_SobreStock_Grafico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1187, 579)
        Me.Controls.Add(Me.Chk_Serie4)
        Me.Controls.Add(Me.Chk_Serie3)
        Me.Controls.Add(Me.Chk_Serie2)
        Me.Controls.Add(Me.Chk_Serie1)
        Me.Controls.Add(Me.Rdb_Proyeccion_Semanas)
        Me.Controls.Add(Me.Rdb_Proyeccion_Meses)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Grafico_Mov_Stock)
        Me.Controls.Add(Me.Bar2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_SobreStock_Grafico"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grafico_Mov_Stock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Exportar_Excel As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Actualizar As DevComponents.DotNetBar.ButtonItem
    Private WithEvents Grafico_Mov_Stock As DataVisualization.Charting.Chart
    Public WithEvents Rdb_Proyeccion_Semanas As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Rdb_Proyeccion_Meses As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Chk_Serie4 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Serie3 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Serie2 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Serie1 As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
