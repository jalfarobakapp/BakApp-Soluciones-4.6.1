<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Grafico1
    Inherits DevComponents.DotNetBar.Metro.MetroForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title1 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Dim Title2 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim StripLine1 As System.Windows.Forms.DataVisualization.Charting.StripLine = New System.Windows.Forms.DataVisualization.Charting.StripLine()
        Dim StripLine2 As System.Windows.Forms.DataVisualization.Charting.StripLine = New System.Windows.Forms.DataVisualization.Charting.StripLine()
        Dim StripLine3 As System.Windows.Forms.DataVisualization.Charting.StripLine = New System.Windows.Forms.DataVisualization.Charting.StripLine()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend3 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series4 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series5 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series6 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea4 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series7 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series8 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title3 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Dim Title4 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Grafico1))
        Me.SuperTabControl1 = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel8 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.Grafico_1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.SuperTabItem1 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel9 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.Grafico_Desviacion_Estandar = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.LblMedia = New System.Windows.Forms.Label()
        Me.label6 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.LblDesviacionStandar = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.SuperTabItem2 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel10 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.Grafico_Tendencias = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.SuperTabItem3 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel11 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX16 = New DevComponents.DotNetBar.LabelX()
        Me.Chk_Stock_Minimo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Stock_Salidas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Input_Stock_Minimo = New DevComponents.Editors.IntegerInput()
        Me.Chk_Stock_Ingresos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Stock_Movimiento = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Grafico_Mov_Stock = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.SuperTabItem4 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel12 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.GroupPanel5 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.MchMensuales = New DevComponents.DotNetBar.MicroChart()
        Me.Grilla_Mensual = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.GroupPanel4 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.McsSemanales = New DevComponents.DotNetBar.MicroChart()
        Me.Grilla_Semanal = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.SuperTabItem5 = New DevComponents.DotNetBar.SuperTabItem()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Actualizar_Informe = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Excel = New DevComponents.DotNetBar.ButtonItem()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControl1.SuspendLayout()
        Me.SuperTabControlPanel8.SuspendLayout()
        CType(Me.Grafico_1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel9.SuspendLayout()
        CType(Me.Grafico_Desviacion_Estandar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuperTabControlPanel10.SuspendLayout()
        CType(Me.Grafico_Tendencias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel11.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        CType(Me.Input_Stock_Minimo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grafico_Mov_Stock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel12.SuspendLayout()
        Me.GroupPanel5.SuspendLayout()
        CType(Me.Grilla_Mensual, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel4.SuspendLayout()
        CType(Me.Grilla_Semanal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SuperTabControl1
        '
        Me.SuperTabControl1.BackColor = System.Drawing.Color.White
        '
        '
        '
        '
        '
        '
        Me.SuperTabControl1.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.SuperTabControl1.ControlBox.MenuBox.Name = ""
        Me.SuperTabControl1.ControlBox.Name = ""
        Me.SuperTabControl1.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabControl1.ControlBox.MenuBox, Me.SuperTabControl1.ControlBox.CloseBox})
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel8)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel9)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel10)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel11)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel12)
        Me.SuperTabControl1.ForeColor = System.Drawing.Color.Black
        Me.SuperTabControl1.Location = New System.Drawing.Point(25, 22)
        Me.SuperTabControl1.Name = "SuperTabControl1"
        Me.SuperTabControl1.ReorderTabsEnabled = True
        Me.SuperTabControl1.SelectedTabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.SuperTabControl1.SelectedTabIndex = 3
        Me.SuperTabControl1.Size = New System.Drawing.Size(877, 458)
        Me.SuperTabControl1.TabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SuperTabControl1.TabIndex = 8
        Me.SuperTabControl1.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabItem1, Me.SuperTabItem2, Me.SuperTabItem3, Me.SuperTabItem4, Me.SuperTabItem5})
        Me.SuperTabControl1.Text = "Tendencias (proyección)"
        '
        'SuperTabControlPanel8
        '
        Me.SuperTabControlPanel8.Controls.Add(Me.Grafico_1)
        Me.SuperTabControlPanel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel8.Location = New System.Drawing.Point(0, 27)
        Me.SuperTabControlPanel8.Name = "SuperTabControlPanel8"
        Me.SuperTabControlPanel8.Size = New System.Drawing.Size(877, 431)
        Me.SuperTabControlPanel8.TabIndex = 1
        Me.SuperTabControlPanel8.TabItem = Me.SuperTabItem1
        '
        'Grafico_1
        '
        Me.Grafico_1.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Top
        Me.Grafico_1.BackImageTransparentColor = System.Drawing.Color.White
        Me.Grafico_1.BackSecondaryColor = System.Drawing.Color.White
        Me.Grafico_1.BorderlineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.Grafico_1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        Me.Grafico_1.BorderlineWidth = 2
        Me.Grafico_1.BorderSkin.BackColor = System.Drawing.Color.White
        Me.Grafico_1.BorderSkin.BorderColor = System.Drawing.Color.White
        ChartArea1.Area3DStyle.Inclination = 15
        ChartArea1.Area3DStyle.IsClustered = True
        ChartArea1.Area3DStyle.IsRightAngleAxes = False
        ChartArea1.Area3DStyle.Perspective = 10
        ChartArea1.Area3DStyle.Rotation = 10
        ChartArea1.Area3DStyle.WallWidth = 0
        ChartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount
        ChartArea1.AxisX.LabelAutoFitStyle = CType(((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont) _
            Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap), System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)
        ChartArea1.AxisX.LabelStyle.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold)
        ChartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea1.AxisX.LineColor = System.Drawing.Color.LightGray
        ChartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray
        ChartArea1.AxisX.ScrollBar.LineColor = System.Drawing.Color.Black
        ChartArea1.AxisX.ScrollBar.Size = 10.0R
        ChartArea1.AxisX.TitleForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        ChartArea1.AxisX2.TitleForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        ChartArea1.AxisY.LabelStyle.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold)
        ChartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea1.AxisY.LineColor = System.Drawing.Color.LightGray
        ChartArea1.AxisY.MajorGrid.LineColor = System.Drawing.SystemColors.ControlLight
        ChartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.Red
        ChartArea1.AxisY.MinorTickMark.LineColor = System.Drawing.Color.Red
        ChartArea1.AxisY.ScrollBar.LineColor = System.Drawing.Color.Black
        ChartArea1.AxisY.ScrollBar.Size = 10.0R
        ChartArea1.AxisY.TitleForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        ChartArea1.AxisY2.LineColor = System.Drawing.Color.LightGray
        ChartArea1.AxisY2.TitleForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
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
        Me.Grafico_1.ChartAreas.Add(ChartArea1)
        Legend1.BackColor = System.Drawing.Color.Transparent
        Legend1.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold)
        Legend1.ForeColor = System.Drawing.Color.Maroon
        Legend1.IsTextAutoFit = False
        Legend1.Name = "Default"
        Me.Grafico_1.Legends.Add(Legend1)
        Me.Grafico_1.Location = New System.Drawing.Point(3, 3)
        Me.Grafico_1.Name = "Grafico_1"
        Series1.ChartArea = "Default"
        Series1.IsValueShownAsLabel = True
        Series1.Legend = "Default"
        Series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle
        Series1.Name = "Series1"
        Series1.ShadowColor = System.Drawing.Color.Black
        Series1.SmartLabelStyle.CalloutLineColor = System.Drawing.Color.Maroon
        Series2.ChartArea = "Default"
        Series2.IsValueShownAsLabel = True
        Series2.Legend = "Default"
        Series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle
        Series2.Name = "Series2"
        Me.Grafico_1.Series.Add(Series1)
        Me.Grafico_1.Series.Add(Series2)
        Me.Grafico_1.Size = New System.Drawing.Size(871, 425)
        Me.Grafico_1.TabIndex = 3
        Me.Grafico_1.TabStop = False
        Title1.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold)
        Title1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(105, Byte), Integer))
        Title1.Name = "Titulo_Grafico_01_Arriba"
        Title1.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Title1.ShadowOffset = 3
        Title1.Text = "Grafico de ventas periodo"
        Title2.Name = "Titulo_Grafico_01_Abajo"
        Title2.Text = "SSSS"
        Me.Grafico_1.Titles.Add(Title1)
        Me.Grafico_1.Titles.Add(Title2)
        '
        'SuperTabItem1
        '
        Me.SuperTabItem1.AttachedControl = Me.SuperTabControlPanel8
        Me.SuperTabItem1.GlobalItem = False
        Me.SuperTabItem1.Name = "SuperTabItem1"
        Me.SuperTabItem1.Text = "Grafica con valores"
        '
        'SuperTabControlPanel9
        '
        Me.SuperTabControlPanel9.Controls.Add(Me.Grafico_Desviacion_Estandar)
        Me.SuperTabControlPanel9.Controls.Add(Me.TableLayoutPanel3)
        Me.SuperTabControlPanel9.Controls.Add(Me.TableLayoutPanel2)
        Me.SuperTabControlPanel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel9.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel9.Name = "SuperTabControlPanel9"
        Me.SuperTabControlPanel9.Size = New System.Drawing.Size(877, 458)
        Me.SuperTabControlPanel9.TabIndex = 0
        Me.SuperTabControlPanel9.TabItem = Me.SuperTabItem2
        '
        'Grafico_Desviacion_Estandar
        '
        Me.Grafico_Desviacion_Estandar.BorderlineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.Grafico_Desviacion_Estandar.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        Me.Grafico_Desviacion_Estandar.BorderlineWidth = 2
        ChartArea2.Area3DStyle.Inclination = 15
        ChartArea2.Area3DStyle.IsClustered = True
        ChartArea2.Area3DStyle.IsRightAngleAxes = False
        ChartArea2.Area3DStyle.Perspective = 10
        ChartArea2.Area3DStyle.Rotation = 10
        ChartArea2.Area3DStyle.WallWidth = 0
        ChartArea2.AxisX.LabelAutoFitStyle = CType((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) _
            Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) _
            Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap), System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)
        ChartArea2.AxisX.LabelStyle.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold)
        ChartArea2.AxisX.LabelStyle.Interval = 0R
        ChartArea2.AxisX.LabelStyle.IntervalOffset = 0R
        ChartArea2.AxisX.LabelStyle.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.[Auto]
        ChartArea2.AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.[Auto]
        ChartArea2.AxisX.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea2.AxisX.MajorGrid.Interval = 0R
        ChartArea2.AxisX.MajorGrid.IntervalOffset = 0R
        ChartArea2.AxisX.MajorGrid.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.[Auto]
        ChartArea2.AxisX.MajorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.[Auto]
        ChartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea2.AxisX.MajorTickMark.Interval = 0R
        ChartArea2.AxisX.MajorTickMark.IntervalOffset = 0R
        ChartArea2.AxisX.MajorTickMark.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.[Auto]
        ChartArea2.AxisX.MajorTickMark.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.[Auto]
        ChartArea2.AxisX2.LabelAutoFitStyle = CType((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) _
            Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) _
            Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap), System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)
        ChartArea2.AxisX2.LabelStyle.Interval = 0R
        ChartArea2.AxisX2.LabelStyle.IntervalOffset = 0R
        ChartArea2.AxisX2.LabelStyle.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.[Auto]
        ChartArea2.AxisX2.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.[Auto]
        ChartArea2.AxisX2.MajorGrid.Interval = 0R
        ChartArea2.AxisX2.MajorGrid.IntervalOffset = 0R
        ChartArea2.AxisX2.MajorGrid.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.[Auto]
        ChartArea2.AxisX2.MajorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.[Auto]
        ChartArea2.AxisX2.MajorTickMark.Interval = 0R
        ChartArea2.AxisX2.MajorTickMark.IntervalOffset = 0R
        ChartArea2.AxisX2.MajorTickMark.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.[Auto]
        ChartArea2.AxisX2.MajorTickMark.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.[Auto]
        ChartArea2.AxisY.LabelAutoFitStyle = CType((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) _
            Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) _
            Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap), System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)
        ChartArea2.AxisY.LabelStyle.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold)
        ChartArea2.AxisY.LabelStyle.Interval = 0R
        ChartArea2.AxisY.LabelStyle.IntervalOffset = 0R
        ChartArea2.AxisY.LabelStyle.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.[Auto]
        ChartArea2.AxisY.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.[Auto]
        ChartArea2.AxisY.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea2.AxisY.MajorGrid.Enabled = False
        ChartArea2.AxisY.MajorGrid.Interval = 0R
        ChartArea2.AxisY.MajorGrid.IntervalOffset = 0R
        ChartArea2.AxisY.MajorGrid.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.[Auto]
        ChartArea2.AxisY.MajorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.[Auto]
        ChartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea2.AxisY.MajorTickMark.Interval = 0R
        ChartArea2.AxisY.MajorTickMark.IntervalOffset = 0R
        ChartArea2.AxisY.MajorTickMark.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.[Auto]
        ChartArea2.AxisY.MajorTickMark.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.[Auto]
        StripLine1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(168, Byte), Integer))
        StripLine1.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        StripLine1.IntervalOffset = 20.0R
        StripLine1.StripWidth = 50.0R
        StripLine1.Text = "Standard Deviation"
        StripLine1.TextLineAlignment = System.Drawing.StringAlignment.Far
        StripLine2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(65, Byte), Integer))
        StripLine2.BorderWidth = 2
        StripLine2.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        StripLine2.IntervalOffset = 40.0R
        StripLine2.Text = "Mean"
        StripLine2.TextLineAlignment = System.Drawing.StringAlignment.Far
        StripLine3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(10, Byte), Integer))
        StripLine3.BorderWidth = 2
        StripLine3.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        StripLine3.IntervalOffset = 50.0R
        StripLine3.Text = "Median"
        StripLine3.TextAlignment = System.Drawing.StringAlignment.Near
        StripLine3.TextLineAlignment = System.Drawing.StringAlignment.Far
        ChartArea2.AxisY.StripLines.Add(StripLine1)
        ChartArea2.AxisY.StripLines.Add(StripLine2)
        ChartArea2.AxisY.StripLines.Add(StripLine3)
        ChartArea2.AxisY2.LabelAutoFitStyle = CType((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) _
            Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) _
            Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap), System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)
        ChartArea2.AxisY2.LabelStyle.Interval = 0R
        ChartArea2.AxisY2.LabelStyle.IntervalOffset = 0R
        ChartArea2.AxisY2.LabelStyle.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.[Auto]
        ChartArea2.AxisY2.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.[Auto]
        ChartArea2.AxisY2.MajorGrid.Interval = 0R
        ChartArea2.AxisY2.MajorGrid.IntervalOffset = 0R
        ChartArea2.AxisY2.MajorGrid.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.[Auto]
        ChartArea2.AxisY2.MajorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.[Auto]
        ChartArea2.AxisY2.MajorTickMark.Interval = 0R
        ChartArea2.AxisY2.MajorTickMark.IntervalOffset = 0R
        ChartArea2.AxisY2.MajorTickMark.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.[Auto]
        ChartArea2.AxisY2.MajorTickMark.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.[Auto]
        ChartArea2.BackColor = System.Drawing.Color.White
        ChartArea2.BackSecondaryColor = System.Drawing.Color.White
        ChartArea2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea2.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        ChartArea2.Name = "Default"
        ChartArea2.ShadowColor = System.Drawing.Color.Transparent
        Me.Grafico_Desviacion_Estandar.ChartAreas.Add(ChartArea2)
        Legend2.Alignment = System.Drawing.StringAlignment.Far
        Legend2.BackColor = System.Drawing.Color.Transparent
        Legend2.Enabled = False
        Legend2.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold)
        Legend2.IsTextAutoFit = False
        Legend2.Name = "Default"
        Legend2.Position.Auto = False
        Legend2.Position.Height = 15.0!
        Legend2.Position.Width = 30.0!
        Legend2.Position.X = 63.0!
        Legend2.Position.Y = 5.0!
        Me.Grafico_Desviacion_Estandar.Legends.Add(Legend2)
        Me.Grafico_Desviacion_Estandar.Location = New System.Drawing.Point(3, 3)
        Me.Grafico_Desviacion_Estandar.Name = "Grafico_Desviacion_Estandar"
        Series3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(105, Byte), Integer))
        Series3.BorderWidth = 2
        Series3.ChartArea = "Default"
        Series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series3.LabelToolTip = "O"
        Series3.Legend = "Default"
        Series3.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle
        Series3.Name = "Series1"
        Series3.ShadowOffset = 1
        Me.Grafico_Desviacion_Estandar.Series.Add(Series3)
        Me.Grafico_Desviacion_Estandar.Size = New System.Drawing.Size(866, 269)
        Me.Grafico_Desviacion_Estandar.TabIndex = 18
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 145.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.LblMedia, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.label6, 0, 0)
        Me.TableLayoutPanel3.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(656, 271)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(200, 27)
        Me.TableLayoutPanel3.TabIndex = 21
        '
        'LblMedia
        '
        Me.LblMedia.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.LblMedia.ForeColor = System.Drawing.Color.Black
        Me.LblMedia.Location = New System.Drawing.Point(58, 0)
        Me.LblMedia.Name = "LblMedia"
        Me.LblMedia.Size = New System.Drawing.Size(112, 23)
        Me.LblMedia.TabIndex = 17
        Me.LblMedia.Text = "label5"
        Me.LblMedia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'label6
        '
        Me.label6.ForeColor = System.Drawing.Color.Black
        Me.label6.Location = New System.Drawing.Point(3, 0)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(46, 23)
        Me.label6.TabIndex = 16
        Me.label6.Text = "Media:"
        Me.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 142.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.LblDesviacionStandar, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label7, 0, 0)
        Me.TableLayoutPanel2.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 271)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(264, 23)
        Me.TableLayoutPanel2.TabIndex = 20
        '
        'LblDesviacionStandar
        '
        Me.LblDesviacionStandar.ForeColor = System.Drawing.Color.Black
        Me.LblDesviacionStandar.Location = New System.Drawing.Point(125, 0)
        Me.LblDesviacionStandar.Name = "LblDesviacionStandar"
        Me.LblDesviacionStandar.Size = New System.Drawing.Size(76, 23)
        Me.LblDesviacionStandar.TabIndex = 15
        Me.LblDesviacionStandar.Text = "Label4"
        Me.LblDesviacionStandar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(3, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(115, 23)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Desviación Estandar:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SuperTabItem2
        '
        Me.SuperTabItem2.AttachedControl = Me.SuperTabControlPanel9
        Me.SuperTabItem2.GlobalItem = False
        Me.SuperTabItem2.Name = "SuperTabItem2"
        Me.SuperTabItem2.Text = "Grafica muestra desviación estandar"
        '
        'SuperTabControlPanel10
        '
        Me.SuperTabControlPanel10.Controls.Add(Me.Grafico_Tendencias)
        Me.SuperTabControlPanel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel10.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel10.Name = "SuperTabControlPanel10"
        Me.SuperTabControlPanel10.Size = New System.Drawing.Size(877, 458)
        Me.SuperTabControlPanel10.TabIndex = 0
        Me.SuperTabControlPanel10.TabItem = Me.SuperTabItem3
        '
        'Grafico_Tendencias
        '
        Me.Grafico_Tendencias.BorderlineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.Grafico_Tendencias.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        Me.Grafico_Tendencias.BorderlineWidth = 2
        Me.Grafico_Tendencias.BorderSkin.BorderColor = System.Drawing.Color.White
        ChartArea3.Area3DStyle.Inclination = 15
        ChartArea3.Area3DStyle.IsClustered = True
        ChartArea3.Area3DStyle.IsRightAngleAxes = False
        ChartArea3.Area3DStyle.Perspective = 10
        ChartArea3.Area3DStyle.Rotation = 10
        ChartArea3.Area3DStyle.WallWidth = 0
        ChartArea3.AxisX.LabelAutoFitStyle = CType((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) _
            Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) _
            Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap), System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)
        ChartArea3.AxisX.LabelStyle.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold)
        ChartArea3.AxisX.LabelStyle.Format = "dd MMM"
        ChartArea3.AxisX.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea3.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea3.AxisX2.LabelAutoFitStyle = CType((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) _
            Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) _
            Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap), System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)
        ChartArea3.AxisY.IsStartedFromZero = False
        ChartArea3.AxisY.LabelAutoFitStyle = CType((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) _
            Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) _
            Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap), System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)
        ChartArea3.AxisY.LabelStyle.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold)
        ChartArea3.AxisY.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea3.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea3.AxisY2.LabelAutoFitStyle = CType((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) _
            Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) _
            Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap), System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)
        ChartArea3.BackColor = System.Drawing.Color.White
        ChartArea3.BackSecondaryColor = System.Drawing.Color.Transparent
        ChartArea3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea3.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        ChartArea3.Name = "Default"
        ChartArea3.ShadowColor = System.Drawing.Color.Transparent
        Me.Grafico_Tendencias.ChartAreas.Add(ChartArea3)
        Legend3.Alignment = System.Drawing.StringAlignment.Far
        Legend3.BackColor = System.Drawing.Color.Transparent
        Legend3.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom
        Legend3.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold)
        Legend3.IsDockedInsideChartArea = False
        Legend3.IsTextAutoFit = False
        Legend3.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row
        Legend3.Name = "Default"
        Me.Grafico_Tendencias.Legends.Add(Legend3)
        Me.Grafico_Tendencias.Location = New System.Drawing.Point(3, 3)
        Me.Grafico_Tendencias.Name = "Grafico_Tendencias"
        Series4.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(105, Byte), Integer))
        Series4.ChartArea = "Default"
        Series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Range
        Series4.Color = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(240, Byte), Integer))
        Series4.Legend = "Default"
        Series4.Name = "Rango"
        Series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime
        Series4.YValuesPerPoint = 2
        Series5.BorderWidth = 2
        Series5.ChartArea = "Default"
        Series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series5.Color = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(65, Byte), Integer))
        Series5.LabelForeColor = System.Drawing.Color.OrangeRed
        Series5.Legend = "Default"
        Series5.Name = "Proyeccion"
        Series5.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Series5.ShadowOffset = 1
        Series5.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime
        Series6.BorderWidth = 2
        Series6.ChartArea = "Default"
        Series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series6.Color = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(10, Byte), Integer))
        Series6.Legend = "Default"
        Series6.Name = "Ventas"
        Series6.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Series6.ShadowOffset = 1
        Series6.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime
        Series6.YValuesPerPoint = 4
        Me.Grafico_Tendencias.Series.Add(Series4)
        Me.Grafico_Tendencias.Series.Add(Series5)
        Me.Grafico_Tendencias.Series.Add(Series6)
        Me.Grafico_Tendencias.Size = New System.Drawing.Size(866, 296)
        Me.Grafico_Tendencias.TabIndex = 2
        '
        'SuperTabItem3
        '
        Me.SuperTabItem3.AttachedControl = Me.SuperTabControlPanel10
        Me.SuperTabItem3.GlobalItem = False
        Me.SuperTabItem3.Name = "SuperTabItem3"
        Me.SuperTabItem3.Text = "Tendencias (proyección)"
        '
        'SuperTabControlPanel11
        '
        Me.SuperTabControlPanel11.Controls.Add(Me.TableLayoutPanel4)
        Me.SuperTabControlPanel11.Controls.Add(Me.Grafico_Mov_Stock)
        Me.SuperTabControlPanel11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel11.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel11.Name = "SuperTabControlPanel11"
        Me.SuperTabControlPanel11.Size = New System.Drawing.Size(877, 458)
        Me.SuperTabControlPanel11.TabIndex = 0
        Me.SuperTabControlPanel11.TabItem = Me.SuperTabItem4
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel4.ColumnCount = 3
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.28571!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.71429!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 196.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.LabelX16, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Chk_Stock_Minimo, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Chk_Stock_Salidas, 2, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.Input_Stock_Minimo, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Chk_Stock_Ingresos, 1, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.Chk_Stock_Movimiento, 0, 1)
        Me.TableLayoutPanel4.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(3, 241)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 2
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(324, 50)
        Me.TableLayoutPanel4.TabIndex = 37
        '
        'LabelX16
        '
        '
        '
        '
        Me.LabelX16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX16.ForeColor = System.Drawing.Color.Black
        Me.LabelX16.Location = New System.Drawing.Point(3, 3)
        Me.LabelX16.Name = "LabelX16"
        Me.LabelX16.Size = New System.Drawing.Size(63, 19)
        Me.LabelX16.TabIndex = 31
        Me.LabelX16.Text = "Stock mínimo"
        '
        'Chk_Stock_Minimo
        '
        '
        '
        '
        Me.Chk_Stock_Minimo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Stock_Minimo.Checked = True
        Me.Chk_Stock_Minimo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_Stock_Minimo.CheckValue = "Y"
        Me.Chk_Stock_Minimo.ForeColor = System.Drawing.Color.Black
        Me.Chk_Stock_Minimo.Location = New System.Drawing.Point(130, 3)
        Me.Chk_Stock_Minimo.Name = "Chk_Stock_Minimo"
        Me.Chk_Stock_Minimo.Size = New System.Drawing.Size(143, 19)
        Me.Chk_Stock_Minimo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Stock_Minimo.TabIndex = 36
        Me.Chk_Stock_Minimo.Text = "Ver Nro. Stock mínimo"
        '
        'Chk_Stock_Salidas
        '
        '
        '
        '
        Me.Chk_Stock_Salidas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Stock_Salidas.ForeColor = System.Drawing.Color.Black
        Me.Chk_Stock_Salidas.Location = New System.Drawing.Point(130, 28)
        Me.Chk_Stock_Salidas.Name = "Chk_Stock_Salidas"
        Me.Chk_Stock_Salidas.Size = New System.Drawing.Size(103, 19)
        Me.Chk_Stock_Salidas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Stock_Salidas.TabIndex = 35
        Me.Chk_Stock_Salidas.Text = "Salidas"
        '
        'Input_Stock_Minimo
        '
        '
        '
        '
        Me.Input_Stock_Minimo.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_Stock_Minimo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_Stock_Minimo.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.Input_Stock_Minimo.ForeColor = System.Drawing.Color.Black
        Me.Input_Stock_Minimo.Location = New System.Drawing.Point(72, 3)
        Me.Input_Stock_Minimo.MinValue = 1
        Me.Input_Stock_Minimo.Name = "Input_Stock_Minimo"
        Me.Input_Stock_Minimo.ShowUpDown = True
        Me.Input_Stock_Minimo.Size = New System.Drawing.Size(51, 22)
        Me.Input_Stock_Minimo.TabIndex = 27
        Me.Input_Stock_Minimo.Value = 1
        '
        'Chk_Stock_Ingresos
        '
        '
        '
        '
        Me.Chk_Stock_Ingresos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Stock_Ingresos.ForeColor = System.Drawing.Color.Black
        Me.Chk_Stock_Ingresos.Location = New System.Drawing.Point(72, 28)
        Me.Chk_Stock_Ingresos.Name = "Chk_Stock_Ingresos"
        Me.Chk_Stock_Ingresos.Size = New System.Drawing.Size(52, 19)
        Me.Chk_Stock_Ingresos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Stock_Ingresos.TabIndex = 34
        Me.Chk_Stock_Ingresos.Text = "Ingresos"
        '
        'Chk_Stock_Movimiento
        '
        '
        '
        '
        Me.Chk_Stock_Movimiento.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Stock_Movimiento.ForeColor = System.Drawing.Color.Black
        Me.Chk_Stock_Movimiento.Location = New System.Drawing.Point(3, 28)
        Me.Chk_Stock_Movimiento.Name = "Chk_Stock_Movimiento"
        Me.Chk_Stock_Movimiento.Size = New System.Drawing.Size(63, 19)
        Me.Chk_Stock_Movimiento.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Stock_Movimiento.TabIndex = 33
        Me.Chk_Stock_Movimiento.Text = "Tiempo stock"
        '
        'Grafico_Mov_Stock
        '
        Me.Grafico_Mov_Stock.BackSecondaryColor = System.Drawing.Color.White
        Me.Grafico_Mov_Stock.BorderlineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.Grafico_Mov_Stock.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        Me.Grafico_Mov_Stock.BorderlineWidth = 2
        Me.Grafico_Mov_Stock.BorderSkin.PageColor = System.Drawing.Color.Empty
        ChartArea4.Area3DStyle.Inclination = 15
        ChartArea4.Area3DStyle.IsClustered = True
        ChartArea4.Area3DStyle.IsRightAngleAxes = False
        ChartArea4.Area3DStyle.Perspective = 10
        ChartArea4.Area3DStyle.Rotation = 10
        ChartArea4.Area3DStyle.WallWidth = 0
        ChartArea4.AxisX.LabelAutoFitStyle = CType(((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont) _
            Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap), System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)
        ChartArea4.AxisX.LabelStyle.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold)
        ChartArea4.AxisX.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea4.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea4.AxisX.ScrollBar.LineColor = System.Drawing.Color.Black
        ChartArea4.AxisX.ScrollBar.Size = 10.0R
        ChartArea4.AxisY.LabelStyle.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold)
        ChartArea4.AxisY.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea4.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea4.AxisY.ScrollBar.LineColor = System.Drawing.Color.Black
        ChartArea4.AxisY.ScrollBar.Size = 10.0R
        ChartArea4.BackColor = System.Drawing.Color.White
        ChartArea4.BackSecondaryColor = System.Drawing.Color.White
        ChartArea4.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea4.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        ChartArea4.CursorX.IsUserEnabled = True
        ChartArea4.CursorX.IsUserSelectionEnabled = True
        ChartArea4.CursorY.IsUserEnabled = True
        ChartArea4.CursorY.IsUserSelectionEnabled = True
        ChartArea4.Name = "Default"
        ChartArea4.ShadowColor = System.Drawing.Color.Transparent
        Me.Grafico_Mov_Stock.ChartAreas.Add(ChartArea4)
        Me.Grafico_Mov_Stock.Location = New System.Drawing.Point(3, 3)
        Me.Grafico_Mov_Stock.Name = "Grafico_Mov_Stock"
        Series7.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Series7.ChartArea = "Default"
        Series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine
        Series7.Color = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(176, Byte), Integer))
        Series7.IsVisibleInLegend = False
        Series7.Legend = "Default"
        Series7.LegendText = "Stock consolidado..."
        Series7.MarkerBorderColor = System.Drawing.Color.Red
        Series7.MarkerColor = System.Drawing.Color.Red
        Series7.MarkerSize = 8
        Series7.Name = "Series1"
        Series7.ShadowColor = System.Drawing.Color.Black
        Series7.ShadowOffset = 2
        Series7.YValuesPerPoint = 2
        Series8.BorderColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Series8.ChartArea = "Default"
        Series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point
        Series8.Color = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Series8.IsValueShownAsLabel = True
        Series8.IsVisibleInLegend = False
        Series8.Legend = "Default"
        Series8.LegendText = "Venta mueve Stock..."
        Series8.MarkerColor = System.Drawing.Color.Brown
        Series8.MarkerSize = 4
        Series8.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Star5
        Series8.Name = "Series2"
        Me.Grafico_Mov_Stock.Series.Add(Series7)
        Me.Grafico_Mov_Stock.Series.Add(Series8)
        Me.Grafico_Mov_Stock.Size = New System.Drawing.Size(863, 232)
        Me.Grafico_Mov_Stock.TabIndex = 5
        Me.Grafico_Mov_Stock.TabStop = False
        Title3.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold)
        Title3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(105, Byte), Integer))
        Title3.Name = "Title1"
        Title3.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Title3.ShadowOffset = 3
        Title3.Text = "Ventas y Movimiento de Stock"
        Title4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Title4.Name = "Title2"
        Title4.Text = "Tiempo de reposición"
        Me.Grafico_Mov_Stock.Titles.Add(Title3)
        Me.Grafico_Mov_Stock.Titles.Add(Title4)
        '
        'SuperTabItem4
        '
        Me.SuperTabItem4.AttachedControl = Me.SuperTabControlPanel11
        Me.SuperTabItem4.GlobalItem = False
        Me.SuperTabItem4.Name = "SuperTabItem4"
        Me.SuperTabItem4.Text = "Grafico tiempo de reposición"
        '
        'SuperTabControlPanel12
        '
        Me.SuperTabControlPanel12.Controls.Add(Me.GroupPanel5)
        Me.SuperTabControlPanel12.Controls.Add(Me.GroupPanel4)
        Me.SuperTabControlPanel12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel12.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel12.Name = "SuperTabControlPanel12"
        Me.SuperTabControlPanel12.Size = New System.Drawing.Size(877, 458)
        Me.SuperTabControlPanel12.TabIndex = 0
        Me.SuperTabControlPanel12.TabItem = Me.SuperTabItem5
        '
        'GroupPanel5
        '
        Me.GroupPanel5.BackColor = System.Drawing.Color.White
        Me.GroupPanel5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel5.Controls.Add(Me.MchMensuales)
        Me.GroupPanel5.Controls.Add(Me.Grilla_Mensual)
        Me.GroupPanel5.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel5.Location = New System.Drawing.Point(3, 3)
        Me.GroupPanel5.Name = "GroupPanel5"
        Me.GroupPanel5.Size = New System.Drawing.Size(306, 289)
        '
        '
        '
        Me.GroupPanel5.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel5.Style.BackColorGradientAngle = 90
        Me.GroupPanel5.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel5.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel5.Style.BorderBottomWidth = 1
        Me.GroupPanel5.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel5.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel5.Style.BorderLeftWidth = 1
        Me.GroupPanel5.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel5.Style.BorderRightWidth = 1
        Me.GroupPanel5.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel5.Style.BorderTopWidth = 1
        Me.GroupPanel5.Style.CornerDiameter = 4
        Me.GroupPanel5.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel5.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel5.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel5.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel5.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel5.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel5.TabIndex = 17
        Me.GroupPanel5.Text = "Ventas mensuales"
        '
        'MchMensuales
        '
        Me.MchMensuales.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.MchMensuales.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MchMensuales.BarChartStyle.PositiveBarColor = System.Drawing.Color.YellowGreen
        Me.MchMensuales.ForeColor = System.Drawing.Color.Black
        Me.MchMensuales.LineChartStyle.HighPointColor = System.Drawing.Color.Blue
        Me.MchMensuales.LineChartStyle.LastPointColor = System.Drawing.Color.Red
        Me.MchMensuales.Location = New System.Drawing.Point(3, 3)
        Me.MchMensuales.Name = "MchMensuales"
        Me.MchMensuales.Size = New System.Drawing.Size(288, 51)
        Me.MchMensuales.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.MchMensuales.TabIndex = 8
        Me.MchMensuales.Text = "Ventas Mensuales"
        '
        'Grilla_Mensual
        '
        Me.Grilla_Mensual.AllowUserToAddRows = False
        Me.Grilla_Mensual.AllowUserToDeleteRows = False
        Me.Grilla_Mensual.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Mensual.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grilla_Mensual.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Mensual.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grilla_Mensual.EnableHeadersVisualStyles = False
        Me.Grilla_Mensual.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Mensual.Location = New System.Drawing.Point(3, 60)
        Me.Grilla_Mensual.Name = "Grilla_Mensual"
        Me.Grilla_Mensual.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Mensual.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla_Mensual.RowHeadersVisible = False
        Me.Grilla_Mensual.RowTemplate.Height = 25
        Me.Grilla_Mensual.Size = New System.Drawing.Size(288, 204)
        Me.Grilla_Mensual.TabIndex = 15
        '
        'GroupPanel4
        '
        Me.GroupPanel4.BackColor = System.Drawing.Color.White
        Me.GroupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel4.Controls.Add(Me.McsSemanales)
        Me.GroupPanel4.Controls.Add(Me.Grilla_Semanal)
        Me.GroupPanel4.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel4.Location = New System.Drawing.Point(315, 0)
        Me.GroupPanel4.Name = "GroupPanel4"
        Me.GroupPanel4.Size = New System.Drawing.Size(248, 292)
        '
        '
        '
        Me.GroupPanel4.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel4.Style.BackColorGradientAngle = 90
        Me.GroupPanel4.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel4.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderBottomWidth = 1
        Me.GroupPanel4.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel4.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderLeftWidth = 1
        Me.GroupPanel4.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderRightWidth = 1
        Me.GroupPanel4.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderTopWidth = 1
        Me.GroupPanel4.Style.CornerDiameter = 4
        Me.GroupPanel4.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel4.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel4.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel4.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel4.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel4.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel4.TabIndex = 16
        Me.GroupPanel4.Text = "Ventas Semanales"
        '
        'McsSemanales
        '
        Me.McsSemanales.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.McsSemanales.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.McsSemanales.ChartType = DevComponents.DotNetBar.eMicroChartType.Plot
        Me.McsSemanales.ColumnChartStyle.HighPointBarColor = System.Drawing.Color.Green
        Me.McsSemanales.ColumnChartStyle.LowPointBarColor = System.Drawing.Color.Red
        Me.McsSemanales.ForeColor = System.Drawing.Color.Black
        Me.McsSemanales.LineChartStyle.HighPointColor = System.Drawing.Color.Lime
        Me.McsSemanales.LineChartStyle.LowPointColor = System.Drawing.Color.Red
        Me.McsSemanales.Location = New System.Drawing.Point(3, 3)
        Me.McsSemanales.Name = "McsSemanales"
        Me.McsSemanales.Size = New System.Drawing.Size(236, 54)
        Me.McsSemanales.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.McsSemanales.TabIndex = 9
        Me.McsSemanales.Text = "Ventas Mensules"
        '
        'Grilla_Semanal
        '
        Me.Grilla_Semanal.AllowUserToAddRows = False
        Me.Grilla_Semanal.AllowUserToDeleteRows = False
        Me.Grilla_Semanal.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Semanal.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Grilla_Semanal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Semanal.DefaultCellStyle = DataGridViewCellStyle5
        Me.Grilla_Semanal.EnableHeadersVisualStyles = False
        Me.Grilla_Semanal.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Semanal.Location = New System.Drawing.Point(3, 63)
        Me.Grilla_Semanal.Name = "Grilla_Semanal"
        Me.Grilla_Semanal.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Semanal.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Grilla_Semanal.RowHeadersVisible = False
        Me.Grilla_Semanal.RowTemplate.Height = 25
        Me.Grilla_Semanal.Size = New System.Drawing.Size(236, 203)
        Me.Grilla_Semanal.TabIndex = 14
        '
        'SuperTabItem5
        '
        Me.SuperTabItem5.AttachedControl = Me.SuperTabControlPanel12
        Me.SuperTabItem5.GlobalItem = False
        Me.SuperTabItem5.Name = "SuperTabItem5"
        Me.SuperTabItem5.Text = "Ventas Semanales"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Actualizar_Informe, Me.Btn_Excel})
        Me.Bar1.Location = New System.Drawing.Point(0, 503)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(978, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 105
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Actualizar_Informe
        '
        Me.Btn_Actualizar_Informe.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Actualizar_Informe.ForeColor = System.Drawing.Color.Black
        Me.Btn_Actualizar_Informe.Image = CType(resources.GetObject("Btn_Actualizar_Informe.Image"), System.Drawing.Image)
        Me.Btn_Actualizar_Informe.ImageAlt = CType(resources.GetObject("Btn_Actualizar_Informe.ImageAlt"), System.Drawing.Image)
        Me.Btn_Actualizar_Informe.Name = "Btn_Actualizar_Informe"
        Me.Btn_Actualizar_Informe.Tooltip = "Actualizar informe"
        '
        'Btn_Excel
        '
        Me.Btn_Excel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Excel.ForeColor = System.Drawing.Color.Black
        Me.Btn_Excel.Image = CType(resources.GetObject("Btn_Excel.Image"), System.Drawing.Image)
        Me.Btn_Excel.ImageAlt = CType(resources.GetObject("Btn_Excel.ImageAlt"), System.Drawing.Image)
        Me.Btn_Excel.Name = "Btn_Excel"
        Me.Btn_Excel.Tooltip = "Exportar a Excel"
        '
        'Frm_Grafico1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(978, 544)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.SuperTabControl1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Grafico1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControl1.ResumeLayout(False)
        Me.SuperTabControlPanel8.ResumeLayout(False)
        CType(Me.Grafico_1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel9.ResumeLayout(False)
        CType(Me.Grafico_Desviacion_Estandar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.SuperTabControlPanel10.ResumeLayout(False)
        CType(Me.Grafico_Tendencias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel11.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        CType(Me.Input_Stock_Minimo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grafico_Mov_Stock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel12.ResumeLayout(False)
        Me.GroupPanel5.ResumeLayout(False)
        CType(Me.Grilla_Mensual, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel4.ResumeLayout(False)
        CType(Me.Grilla_Semanal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SuperTabControl1 As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel8 As DevComponents.DotNetBar.SuperTabControlPanel
    Private WithEvents Grafico_1 As DataVisualization.Charting.Chart
    Friend WithEvents SuperTabItem1 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel9 As DevComponents.DotNetBar.SuperTabControlPanel
    Private WithEvents Grafico_Desviacion_Estandar As DataVisualization.Charting.Chart
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Private WithEvents LblMedia As Label
    Private WithEvents label6 As Label
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Private WithEvents LblDesviacionStandar As Label
    Private WithEvents Label7 As Label
    Friend WithEvents SuperTabItem2 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel10 As DevComponents.DotNetBar.SuperTabControlPanel
    Private WithEvents Grafico_Tendencias As DataVisualization.Charting.Chart
    Friend WithEvents SuperTabItem3 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel11 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents LabelX16 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Chk_Stock_Minimo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Stock_Salidas As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Input_Stock_Minimo As DevComponents.Editors.IntegerInput
    Friend WithEvents Chk_Stock_Ingresos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Stock_Movimiento As DevComponents.DotNetBar.Controls.CheckBoxX
    Private WithEvents Grafico_Mov_Stock As DataVisualization.Charting.Chart
    Friend WithEvents SuperTabItem4 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel12 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents GroupPanel5 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents MchMensuales As DevComponents.DotNetBar.MicroChart
    Friend WithEvents Grilla_Mensual As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents GroupPanel4 As DevComponents.DotNetBar.Controls.GroupPanel
    Private WithEvents McsSemanales As DevComponents.DotNetBar.MicroChart
    Friend WithEvents Grilla_Semanal As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents SuperTabItem5 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Actualizar_Informe As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Excel As DevComponents.DotNetBar.ButtonItem
End Class
