<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Cadenas_Remotas_Buscador
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Cadenas_Remotas_Buscador))
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Buscar = New DevComponents.DotNetBar.ButtonItem()
        Me.Grupo_Fechas = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Dtp_Fecha_Emision_Hasta = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Lbl_FE_hasta = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_Fecha_Emision_Desde = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Rdb_Fecha_Emision_Rango = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Fecha_Emision_Todas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Lbl_FE_desde = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.TableLayoutPanel13 = New System.Windows.Forms.TableLayoutPanel()
        Me.Dtp_Fecha_Cierre_Hasta = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Lbl_FC_hasta = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_Fecha_Cierre_Desde = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX15 = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_Fecha_Cierre_Rango = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Fecha_Cierre_Todas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Lbl_FC_desde = New DevComponents.DotNetBar.LabelX()
        Me.Grupo_Numero = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Numero = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Rdb_Numero_Todos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Numero_Uno = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Grupo_Otros_Filtros = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_Vendedor_Algunos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Vendedor_Todos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_Producto_Algunos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Producto_Todos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_Entidades_Algunas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Entidades_Todas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Imagenes_32x32 = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_Fechas.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.Dtp_Fecha_Emision_Hasta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_Fecha_Emision_Desde, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel13.SuspendLayout()
        CType(Me.Dtp_Fecha_Cierre_Hasta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_Fecha_Cierre_Desde, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_Numero.SuspendLayout()
        Me.TableLayoutPanel7.SuspendLayout()
        Me.Grupo_Otros_Filtros.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Buscar})
        Me.Bar1.Location = New System.Drawing.Point(0, 329)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(530, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 120
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Buscar
        '
        Me.Btn_Buscar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Buscar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Buscar.Image = CType(resources.GetObject("Btn_Buscar.Image"), System.Drawing.Image)
        Me.Btn_Buscar.Name = "Btn_Buscar"
        Me.Btn_Buscar.Text = "Buscar"
        '
        'Grupo_Fechas
        '
        Me.Grupo_Fechas.BackColor = System.Drawing.Color.White
        Me.Grupo_Fechas.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Fechas.Controls.Add(Me.TableLayoutPanel1)
        Me.Grupo_Fechas.Controls.Add(Me.TableLayoutPanel13)
        Me.Grupo_Fechas.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Fechas.Location = New System.Drawing.Point(12, 91)
        Me.Grupo_Fechas.Name = "Grupo_Fechas"
        Me.Grupo_Fechas.Size = New System.Drawing.Size(503, 94)
        '
        '
        '
        Me.Grupo_Fechas.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Fechas.Style.BackColorGradientAngle = 90
        Me.Grupo_Fechas.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Fechas.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Fechas.Style.BorderBottomWidth = 1
        Me.Grupo_Fechas.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Fechas.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Fechas.Style.BorderLeftWidth = 1
        Me.Grupo_Fechas.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Fechas.Style.BorderRightWidth = 1
        Me.Grupo_Fechas.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Fechas.Style.BorderTopWidth = 1
        Me.Grupo_Fechas.Style.CornerDiameter = 4
        Me.Grupo_Fechas.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Fechas.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Fechas.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Fechas.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Fechas.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Fechas.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Fechas.TabIndex = 123
        Me.Grupo_Fechas.Text = "Fechas"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 7
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 165.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Dtp_Fecha_Emision_Hasta, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_FE_hasta, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Dtp_Fecha_Emision_Desde, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_Fecha_Emision_Rango, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_Fecha_Emision_Todas, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_FE_desde, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX4, 0, 0)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 12)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(566, 25)
        Me.TableLayoutPanel1.TabIndex = 6
        '
        'Dtp_Fecha_Emision_Hasta
        '
        '
        '
        '
        Me.Dtp_Fecha_Emision_Hasta.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Emision_Hasta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Emision_Hasta.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Emision_Hasta.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Emision_Hasta.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Emision_Hasta.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Emision_Hasta.Location = New System.Drawing.Point(404, 3)
        '
        '
        '
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.DisplayMonth = New Date(2016, 7, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Emision_Hasta.Name = "Dtp_Fecha_Emision_Hasta"
        Me.Dtp_Fecha_Emision_Hasta.Size = New System.Drawing.Size(81, 22)
        Me.Dtp_Fecha_Emision_Hasta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Emision_Hasta.TabIndex = 8
        Me.Dtp_Fecha_Emision_Hasta.Value = New Date(2016, 7, 8, 16, 33, 0, 0)
        '
        'Lbl_FE_hasta
        '
        '
        '
        '
        Me.Lbl_FE_hasta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_FE_hasta.ForeColor = System.Drawing.Color.Black
        Me.Lbl_FE_hasta.Location = New System.Drawing.Point(364, 3)
        Me.Lbl_FE_hasta.Name = "Lbl_FE_hasta"
        Me.Lbl_FE_hasta.Size = New System.Drawing.Size(34, 19)
        Me.Lbl_FE_hasta.TabIndex = 9
        Me.Lbl_FE_hasta.Text = "Hasta"
        '
        'Dtp_Fecha_Emision_Desde
        '
        '
        '
        '
        Me.Dtp_Fecha_Emision_Desde.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Emision_Desde.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Emision_Desde.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Emision_Desde.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Emision_Desde.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Emision_Desde.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Emision_Desde.Location = New System.Drawing.Point(278, 3)
        '
        '
        '
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.DisplayMonth = New Date(2016, 7, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Emision_Desde.Name = "Dtp_Fecha_Emision_Desde"
        Me.Dtp_Fecha_Emision_Desde.Size = New System.Drawing.Size(79, 22)
        Me.Dtp_Fecha_Emision_Desde.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Emision_Desde.TabIndex = 7
        Me.Dtp_Fecha_Emision_Desde.Value = New Date(2016, 7, 8, 16, 32, 31, 0)
        '
        'Rdb_Fecha_Emision_Rango
        '
        Me.Rdb_Fecha_Emision_Rango.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Fecha_Emision_Rango.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Fecha_Emision_Rango.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Fecha_Emision_Rango.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Fecha_Emision_Rango.Location = New System.Drawing.Point(166, 3)
        Me.Rdb_Fecha_Emision_Rango.Name = "Rdb_Fecha_Emision_Rango"
        Me.Rdb_Fecha_Emision_Rango.Size = New System.Drawing.Size(56, 19)
        Me.Rdb_Fecha_Emision_Rango.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Fecha_Emision_Rango.TabIndex = 3
        Me.Rdb_Fecha_Emision_Rango.Text = "Rango"
        '
        'Rdb_Fecha_Emision_Todas
        '
        Me.Rdb_Fecha_Emision_Todas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Fecha_Emision_Todas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Fecha_Emision_Todas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Fecha_Emision_Todas.Checked = True
        Me.Rdb_Fecha_Emision_Todas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Fecha_Emision_Todas.CheckValue = "Y"
        Me.Rdb_Fecha_Emision_Todas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Fecha_Emision_Todas.Location = New System.Drawing.Point(104, 3)
        Me.Rdb_Fecha_Emision_Todas.Name = "Rdb_Fecha_Emision_Todas"
        Me.Rdb_Fecha_Emision_Todas.Size = New System.Drawing.Size(56, 19)
        Me.Rdb_Fecha_Emision_Todas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Fecha_Emision_Todas.TabIndex = 1
        Me.Rdb_Fecha_Emision_Todas.Text = "Todas"
        '
        'Lbl_FE_desde
        '
        '
        '
        '
        Me.Lbl_FE_desde.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_FE_desde.ForeColor = System.Drawing.Color.Black
        Me.Lbl_FE_desde.Location = New System.Drawing.Point(228, 3)
        Me.Lbl_FE_desde.Name = "Lbl_FE_desde"
        Me.Lbl_FE_desde.Size = New System.Drawing.Size(38, 19)
        Me.Lbl_FE_desde.TabIndex = 7
        Me.Lbl_FE_desde.Text = "Desde"
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(3, 3)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(95, 19)
        Me.LabelX4.TabIndex = 4
        Me.LabelX4.Text = "Fecha de emisi�n"
        '
        'TableLayoutPanel13
        '
        Me.TableLayoutPanel13.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel13.ColumnCount = 7
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62.0!))
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62.0!))
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87.0!))
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 164.0!))
        Me.TableLayoutPanel13.Controls.Add(Me.Dtp_Fecha_Cierre_Hasta, 6, 0)
        Me.TableLayoutPanel13.Controls.Add(Me.Lbl_FC_hasta, 5, 0)
        Me.TableLayoutPanel13.Controls.Add(Me.Dtp_Fecha_Cierre_Desde, 4, 0)
        Me.TableLayoutPanel13.Controls.Add(Me.LabelX15, 0, 0)
        Me.TableLayoutPanel13.Controls.Add(Me.Rdb_Fecha_Cierre_Rango, 2, 0)
        Me.TableLayoutPanel13.Controls.Add(Me.Rdb_Fecha_Cierre_Todas, 1, 0)
        Me.TableLayoutPanel13.Controls.Add(Me.Lbl_FC_desde, 3, 0)
        Me.TableLayoutPanel13.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel13.Location = New System.Drawing.Point(3, 43)
        Me.TableLayoutPanel13.Name = "TableLayoutPanel13"
        Me.TableLayoutPanel13.RowCount = 1
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel13.Size = New System.Drawing.Size(566, 25)
        Me.TableLayoutPanel13.TabIndex = 7
        '
        'Dtp_Fecha_Cierre_Hasta
        '
        '
        '
        '
        Me.Dtp_Fecha_Cierre_Hasta.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Cierre_Hasta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Cierre_Hasta.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Cierre_Hasta.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Cierre_Hasta.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Cierre_Hasta.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Cierre_Hasta.Location = New System.Drawing.Point(405, 3)
        '
        '
        '
        Me.Dtp_Fecha_Cierre_Hasta.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Cierre_Hasta.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Cierre_Hasta.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Cierre_Hasta.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Cierre_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Cierre_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Cierre_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Cierre_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Cierre_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Cierre_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Cierre_Hasta.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Cierre_Hasta.MonthCalendar.DisplayMonth = New Date(2016, 7, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Cierre_Hasta.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Cierre_Hasta.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Cierre_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Cierre_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Cierre_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Cierre_Hasta.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Cierre_Hasta.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Cierre_Hasta.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Cierre_Hasta.Name = "Dtp_Fecha_Cierre_Hasta"
        Me.Dtp_Fecha_Cierre_Hasta.Size = New System.Drawing.Size(80, 22)
        Me.Dtp_Fecha_Cierre_Hasta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Cierre_Hasta.TabIndex = 8
        Me.Dtp_Fecha_Cierre_Hasta.Value = New Date(2016, 7, 8, 16, 42, 49, 0)
        '
        'Lbl_FC_hasta
        '
        '
        '
        '
        Me.Lbl_FC_hasta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_FC_hasta.ForeColor = System.Drawing.Color.Black
        Me.Lbl_FC_hasta.Location = New System.Drawing.Point(365, 3)
        Me.Lbl_FC_hasta.Name = "Lbl_FC_hasta"
        Me.Lbl_FC_hasta.Size = New System.Drawing.Size(34, 19)
        Me.Lbl_FC_hasta.TabIndex = 9
        Me.Lbl_FC_hasta.Text = "Desde"
        '
        'Dtp_Fecha_Cierre_Desde
        '
        '
        '
        '
        Me.Dtp_Fecha_Cierre_Desde.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Cierre_Desde.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Cierre_Desde.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Cierre_Desde.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Cierre_Desde.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Cierre_Desde.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Cierre_Desde.Location = New System.Drawing.Point(278, 3)
        '
        '
        '
        Me.Dtp_Fecha_Cierre_Desde.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Cierre_Desde.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Cierre_Desde.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Cierre_Desde.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Cierre_Desde.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Cierre_Desde.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Cierre_Desde.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Cierre_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Cierre_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Cierre_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Cierre_Desde.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Cierre_Desde.MonthCalendar.DisplayMonth = New Date(2016, 7, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Cierre_Desde.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Cierre_Desde.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Cierre_Desde.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Cierre_Desde.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Cierre_Desde.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Cierre_Desde.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Cierre_Desde.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Cierre_Desde.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Cierre_Desde.Name = "Dtp_Fecha_Cierre_Desde"
        Me.Dtp_Fecha_Cierre_Desde.Size = New System.Drawing.Size(80, 22)
        Me.Dtp_Fecha_Cierre_Desde.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Cierre_Desde.TabIndex = 7
        Me.Dtp_Fecha_Cierre_Desde.Value = New Date(2016, 7, 8, 16, 42, 41, 0)
        '
        'LabelX15
        '
        '
        '
        '
        Me.LabelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX15.ForeColor = System.Drawing.Color.Black
        Me.LabelX15.Location = New System.Drawing.Point(3, 3)
        Me.LabelX15.Name = "LabelX15"
        Me.LabelX15.Size = New System.Drawing.Size(95, 19)
        Me.LabelX15.TabIndex = 4
        Me.LabelX15.Text = "Fecha de cierre"
        '
        'Rdb_Fecha_Cierre_Rango
        '
        Me.Rdb_Fecha_Cierre_Rango.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Fecha_Cierre_Rango.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Fecha_Cierre_Rango.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Fecha_Cierre_Rango.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Fecha_Cierre_Rango.Location = New System.Drawing.Point(166, 3)
        Me.Rdb_Fecha_Cierre_Rango.Name = "Rdb_Fecha_Cierre_Rango"
        Me.Rdb_Fecha_Cierre_Rango.Size = New System.Drawing.Size(56, 19)
        Me.Rdb_Fecha_Cierre_Rango.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Fecha_Cierre_Rango.TabIndex = 3
        Me.Rdb_Fecha_Cierre_Rango.Text = "Rango"
        '
        'Rdb_Fecha_Cierre_Todas
        '
        Me.Rdb_Fecha_Cierre_Todas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Fecha_Cierre_Todas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Fecha_Cierre_Todas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Fecha_Cierre_Todas.Checked = True
        Me.Rdb_Fecha_Cierre_Todas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Fecha_Cierre_Todas.CheckValue = "Y"
        Me.Rdb_Fecha_Cierre_Todas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Fecha_Cierre_Todas.Location = New System.Drawing.Point(104, 3)
        Me.Rdb_Fecha_Cierre_Todas.Name = "Rdb_Fecha_Cierre_Todas"
        Me.Rdb_Fecha_Cierre_Todas.Size = New System.Drawing.Size(56, 19)
        Me.Rdb_Fecha_Cierre_Todas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Fecha_Cierre_Todas.TabIndex = 1
        Me.Rdb_Fecha_Cierre_Todas.Text = "Todas"
        '
        'Lbl_FC_desde
        '
        '
        '
        '
        Me.Lbl_FC_desde.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_FC_desde.ForeColor = System.Drawing.Color.Black
        Me.Lbl_FC_desde.Location = New System.Drawing.Point(228, 3)
        Me.Lbl_FC_desde.Name = "Lbl_FC_desde"
        Me.Lbl_FC_desde.Size = New System.Drawing.Size(37, 19)
        Me.Lbl_FC_desde.TabIndex = 7
        Me.Lbl_FC_desde.Text = "Desde"
        '
        'Grupo_Numero
        '
        Me.Grupo_Numero.BackColor = System.Drawing.Color.White
        Me.Grupo_Numero.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Numero.Controls.Add(Me.TableLayoutPanel7)
        Me.Grupo_Numero.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Numero.Location = New System.Drawing.Point(12, 12)
        Me.Grupo_Numero.Name = "Grupo_Numero"
        Me.Grupo_Numero.Size = New System.Drawing.Size(503, 73)
        '
        '
        '
        Me.Grupo_Numero.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Numero.Style.BackColorGradientAngle = 90
        Me.Grupo_Numero.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Numero.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Numero.Style.BorderBottomWidth = 1
        Me.Grupo_Numero.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Numero.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Numero.Style.BorderLeftWidth = 1
        Me.Grupo_Numero.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Numero.Style.BorderRightWidth = 1
        Me.Grupo_Numero.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Numero.Style.BorderTopWidth = 1
        Me.Grupo_Numero.Style.CornerDiameter = 4
        Me.Grupo_Numero.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Numero.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Numero.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Numero.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Numero.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Numero.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Numero.TabIndex = 122
        Me.Grupo_Numero.Text = "Filtro por n�mero de solicitud remota"
        '
        'TableLayoutPanel7
        '
        Me.TableLayoutPanel7.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel7.ColumnCount = 4
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 58.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel7.Controls.Add(Me.LabelX11, 0, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.Txt_Numero, 3, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.Rdb_Numero_Todos, 1, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.Rdb_Numero_Uno, 2, 0)
        Me.TableLayoutPanel7.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel7.Location = New System.Drawing.Point(6, 12)
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        Me.TableLayoutPanel7.RowCount = 1
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel7.Size = New System.Drawing.Size(336, 28)
        Me.TableLayoutPanel7.TabIndex = 23
        '
        'LabelX11
        '
        '
        '
        '
        Me.LabelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX11.ForeColor = System.Drawing.Color.Black
        Me.LabelX11.Location = New System.Drawing.Point(3, 3)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(103, 19)
        Me.LabelX11.TabIndex = 4
        Me.LabelX11.Text = "N�mero de solicitud"
        '
        'Txt_Numero
        '
        Me.Txt_Numero.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Numero.Border.Class = "TextBoxBorder"
        Me.Txt_Numero.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Numero.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Numero.FocusHighlightEnabled = True
        Me.Txt_Numero.ForeColor = System.Drawing.Color.Black
        Me.Txt_Numero.Location = New System.Drawing.Point(229, 3)
        Me.Txt_Numero.MaxLength = 10
        Me.Txt_Numero.Name = "Txt_Numero"
        Me.Txt_Numero.PreventEnterBeep = True
        Me.Txt_Numero.Size = New System.Drawing.Size(100, 22)
        Me.Txt_Numero.TabIndex = 22
        Me.Txt_Numero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Rdb_Numero_Todos
        '
        Me.Rdb_Numero_Todos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Numero_Todos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Numero_Todos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Numero_Todos.Checked = True
        Me.Rdb_Numero_Todos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Numero_Todos.CheckValue = "Y"
        Me.Rdb_Numero_Todos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Numero_Todos.Location = New System.Drawing.Point(112, 3)
        Me.Rdb_Numero_Todos.Name = "Rdb_Numero_Todos"
        Me.Rdb_Numero_Todos.Size = New System.Drawing.Size(53, 19)
        Me.Rdb_Numero_Todos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Numero_Todos.TabIndex = 1
        Me.Rdb_Numero_Todos.Text = "Todos"
        '
        'Rdb_Numero_Uno
        '
        Me.Rdb_Numero_Uno.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Numero_Uno.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Numero_Uno.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Numero_Uno.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Numero_Uno.Location = New System.Drawing.Point(171, 3)
        Me.Rdb_Numero_Uno.Name = "Rdb_Numero_Uno"
        Me.Rdb_Numero_Uno.Size = New System.Drawing.Size(47, 19)
        Me.Rdb_Numero_Uno.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Numero_Uno.TabIndex = 3
        Me.Rdb_Numero_Uno.Text = "Uno"
        '
        'Grupo_Otros_Filtros
        '
        Me.Grupo_Otros_Filtros.BackColor = System.Drawing.Color.White
        Me.Grupo_Otros_Filtros.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Otros_Filtros.Controls.Add(Me.TableLayoutPanel4)
        Me.Grupo_Otros_Filtros.Controls.Add(Me.TableLayoutPanel3)
        Me.Grupo_Otros_Filtros.Controls.Add(Me.TableLayoutPanel2)
        Me.Grupo_Otros_Filtros.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Otros_Filtros.Location = New System.Drawing.Point(12, 193)
        Me.Grupo_Otros_Filtros.Name = "Grupo_Otros_Filtros"
        Me.Grupo_Otros_Filtros.Size = New System.Drawing.Size(503, 123)
        '
        '
        '
        Me.Grupo_Otros_Filtros.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Otros_Filtros.Style.BackColorGradientAngle = 90
        Me.Grupo_Otros_Filtros.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Otros_Filtros.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Otros_Filtros.Style.BorderBottomWidth = 1
        Me.Grupo_Otros_Filtros.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Otros_Filtros.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Otros_Filtros.Style.BorderLeftWidth = 1
        Me.Grupo_Otros_Filtros.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Otros_Filtros.Style.BorderRightWidth = 1
        Me.Grupo_Otros_Filtros.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Otros_Filtros.Style.BorderTopWidth = 1
        Me.Grupo_Otros_Filtros.Style.CornerDiameter = 4
        Me.Grupo_Otros_Filtros.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Otros_Filtros.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Otros_Filtros.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Otros_Filtros.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Otros_Filtros.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Otros_Filtros.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Otros_Filtros.TabIndex = 121
        Me.Grupo_Otros_Filtros.Text = "Filtros Entidades, T�cnicos y Estados"
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel4.ColumnCount = 3
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.LabelX6, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Rdb_Vendedor_Algunos, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Rdb_Vendedor_Todos, 1, 0)
        Me.TableLayoutPanel4.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(3, 65)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(488, 25)
        Me.TableLayoutPanel4.TabIndex = 4
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(3, 3)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(131, 19)
        Me.LabelX6.TabIndex = 89
        Me.LabelX6.Text = "Vendedor"
        '
        'Rdb_Vendedor_Algunos
        '
        Me.Rdb_Vendedor_Algunos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Vendedor_Algunos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Vendedor_Algunos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Vendedor_Algunos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Vendedor_Algunos.Location = New System.Drawing.Point(380, 3)
        Me.Rdb_Vendedor_Algunos.Name = "Rdb_Vendedor_Algunos"
        Me.Rdb_Vendedor_Algunos.Size = New System.Drawing.Size(94, 19)
        Me.Rdb_Vendedor_Algunos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Vendedor_Algunos.TabIndex = 3
        Me.Rdb_Vendedor_Algunos.Text = "Algunos"
        '
        'Rdb_Vendedor_Todos
        '
        Me.Rdb_Vendedor_Todos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Vendedor_Todos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Vendedor_Todos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Vendedor_Todos.Checked = True
        Me.Rdb_Vendedor_Todos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Vendedor_Todos.CheckValue = "Y"
        Me.Rdb_Vendedor_Todos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Vendedor_Todos.Location = New System.Drawing.Point(289, 3)
        Me.Rdb_Vendedor_Todos.Name = "Rdb_Vendedor_Todos"
        Me.Rdb_Vendedor_Todos.Size = New System.Drawing.Size(85, 19)
        Me.Rdb_Vendedor_Todos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Vendedor_Todos.TabIndex = 1
        Me.Rdb_Vendedor_Todos.Text = "Todos"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel3.ColumnCount = 3
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.LabelX2, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Rdb_Producto_Algunos, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Rdb_Producto_Todos, 1, 0)
        Me.TableLayoutPanel3.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 37)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(488, 25)
        Me.TableLayoutPanel3.TabIndex = 3
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 3)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(131, 19)
        Me.LabelX2.TabIndex = 4
        Me.LabelX2.Text = "Producto"
        '
        'Rdb_Producto_Algunos
        '
        Me.Rdb_Producto_Algunos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Producto_Algunos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Producto_Algunos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Producto_Algunos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Producto_Algunos.Location = New System.Drawing.Point(380, 3)
        Me.Rdb_Producto_Algunos.Name = "Rdb_Producto_Algunos"
        Me.Rdb_Producto_Algunos.Size = New System.Drawing.Size(94, 19)
        Me.Rdb_Producto_Algunos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Producto_Algunos.TabIndex = 3
        Me.Rdb_Producto_Algunos.Text = "Algunos"
        '
        'Rdb_Producto_Todos
        '
        Me.Rdb_Producto_Todos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Producto_Todos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Producto_Todos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Producto_Todos.Checked = True
        Me.Rdb_Producto_Todos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Producto_Todos.CheckValue = "Y"
        Me.Rdb_Producto_Todos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Producto_Todos.Location = New System.Drawing.Point(289, 3)
        Me.Rdb_Producto_Todos.Name = "Rdb_Producto_Todos"
        Me.Rdb_Producto_Todos.Size = New System.Drawing.Size(85, 19)
        Me.Rdb_Producto_Todos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Producto_Todos.TabIndex = 1
        Me.Rdb_Producto_Todos.Text = "Todas "
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.LabelX1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Rdb_Entidades_Algunas, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Rdb_Entidades_Todas, 1, 0)
        Me.TableLayoutPanel2.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 9)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(488, 25)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(131, 19)
        Me.LabelX1.TabIndex = 4
        Me.LabelX1.Text = "Clientes / Entidades "
        '
        'Rdb_Entidades_Algunas
        '
        Me.Rdb_Entidades_Algunas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Entidades_Algunas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Entidades_Algunas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Entidades_Algunas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Entidades_Algunas.Location = New System.Drawing.Point(380, 3)
        Me.Rdb_Entidades_Algunas.Name = "Rdb_Entidades_Algunas"
        Me.Rdb_Entidades_Algunas.Size = New System.Drawing.Size(94, 19)
        Me.Rdb_Entidades_Algunas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Entidades_Algunas.TabIndex = 3
        Me.Rdb_Entidades_Algunas.Text = "Algunos"
        '
        'Rdb_Entidades_Todas
        '
        Me.Rdb_Entidades_Todas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Entidades_Todas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Entidades_Todas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Entidades_Todas.Checked = True
        Me.Rdb_Entidades_Todas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Entidades_Todas.CheckValue = "Y"
        Me.Rdb_Entidades_Todas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Entidades_Todas.Location = New System.Drawing.Point(289, 3)
        Me.Rdb_Entidades_Todas.Name = "Rdb_Entidades_Todas"
        Me.Rdb_Entidades_Todas.Size = New System.Drawing.Size(85, 19)
        Me.Rdb_Entidades_Todas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Entidades_Todas.TabIndex = 1
        Me.Rdb_Entidades_Todas.Text = "Todos"
        '
        'Imagenes_32x32
        '
        Me.Imagenes_32x32.ImageStream = CType(resources.GetObject("Imagenes_32x32.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagenes_32x32.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagenes_32x32.Images.SetKeyName(0, "Delete")
        Me.Imagenes_32x32.Images.SetKeyName(1, "Warning")
        Me.Imagenes_32x32.Images.SetKeyName(2, "multiply_filled_32px_Red.png")
        Me.Imagenes_32x32.Images.SetKeyName(3, "Warning 32 Yellow.png")
        '
        'Frm_Cadenas_Remotas_Buscador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(530, 370)
        Me.Controls.Add(Me.Grupo_Fechas)
        Me.Controls.Add(Me.Grupo_Numero)
        Me.Controls.Add(Me.Grupo_Otros_Filtros)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Cadenas_Remotas_Buscador"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BUSCADOR DE SOLICITUDES"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo_Fechas.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.Dtp_Fecha_Emision_Hasta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_Fecha_Emision_Desde, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel13.ResumeLayout(False)
        CType(Me.Dtp_Fecha_Cierre_Hasta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_Fecha_Cierre_Desde, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo_Numero.ResumeLayout(False)
        Me.TableLayoutPanel7.ResumeLayout(False)
        Me.Grupo_Otros_Filtros.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Public WithEvents Btn_Buscar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grupo_Fechas As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Dtp_Fecha_Emision_Hasta As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Lbl_FE_hasta As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dtp_Fecha_Emision_Desde As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Rdb_Fecha_Emision_Rango As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Fecha_Emision_Todas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Lbl_FE_desde As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TableLayoutPanel13 As TableLayoutPanel
    Friend WithEvents Dtp_Fecha_Cierre_Hasta As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Lbl_FC_hasta As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dtp_Fecha_Cierre_Desde As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX15 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_Fecha_Cierre_Rango As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Fecha_Cierre_Todas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Lbl_FC_desde As DevComponents.DotNetBar.LabelX
    Friend WithEvents Grupo_Numero As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel7 As TableLayoutPanel
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Numero As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Rdb_Numero_Todos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Numero_Uno As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Grupo_Otros_Filtros As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_Vendedor_Algunos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Vendedor_Todos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_Producto_Algunos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Producto_Todos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_Entidades_Algunas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Entidades_Todas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Imagenes_32x32 As ImageList
End Class
