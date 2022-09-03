<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_MantFacturasElecFiltrar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_MantFacturasElecFiltrar))
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_Fecha_Emision_Desde = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Dtp_Fecha_Emision_Hasta = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_Entidades_Algunas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Entidades_Todas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TableLayoutPanel9 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_Sucursales_Algunas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Sucursales_Todas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_Documentos_Algunos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Documentos_Todos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_Responsables_Algunos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Responsables_Todos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Procesar = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel3.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.Dtp_Fecha_Emision_Desde, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_Fecha_Emision_Hasta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel9.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.TableLayoutPanel7.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel3
        '
        Me.GroupPanel3.BackColor = System.Drawing.Color.White
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.TableLayoutPanel2)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(311, 59)
        '
        '
        '
        Me.GroupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel3.Style.BackColorGradientAngle = 90
        Me.GroupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderBottomWidth = 1
        Me.GroupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderLeftWidth = 1
        Me.GroupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderRightWidth = 1
        Me.GroupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderTopWidth = 1
        Me.GroupPanel3.Style.CornerDiameter = 4
        Me.GroupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel3.TabIndex = 122
        Me.GroupPanel3.Text = "Emitidas entre"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.56522!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.913043!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.95652!))
        Me.TableLayoutPanel2.Controls.Add(Me.LabelX1, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Dtp_Fecha_Emision_Desde, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Dtp_Fecha_Emision_Hasta, 2, 0)
        Me.TableLayoutPanel2.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(51, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(230, 31)
        Me.TableLayoutPanel2.TabIndex = 5
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(93, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(2, 23)
        Me.LabelX1.TabIndex = 114
        Me.LabelX1.Text = "-"
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Center
        Me.LabelX1.TextLineAlignment = System.Drawing.StringAlignment.Near
        '
        'Dtp_Fecha_Emision_Desde
        '
        Me.Dtp_Fecha_Emision_Desde.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_Fecha_Emision_Desde.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Emision_Desde.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Emision_Desde.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Emision_Desde.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Emision_Desde.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Emision_Desde.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Emision_Desde.Location = New System.Drawing.Point(3, 3)
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
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.DisplayMonth = New Date(2017, 5, 1, 0, 0, 0, 0)
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
        Me.Dtp_Fecha_Emision_Desde.Size = New System.Drawing.Size(84, 22)
        Me.Dtp_Fecha_Emision_Desde.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Emision_Desde.TabIndex = 105
        Me.Dtp_Fecha_Emision_Desde.Value = New Date(2017, 5, 9, 17, 44, 34, 0)
        '
        'Dtp_Fecha_Emision_Hasta
        '
        Me.Dtp_Fecha_Emision_Hasta.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_Fecha_Emision_Hasta.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Emision_Hasta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Emision_Hasta.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Emision_Hasta.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Emision_Hasta.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Emision_Hasta.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Emision_Hasta.Location = New System.Drawing.Point(101, 3)
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
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.DisplayMonth = New Date(2017, 5, 1, 0, 0, 0, 0)
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
        Me.Dtp_Fecha_Emision_Hasta.Size = New System.Drawing.Size(92, 22)
        Me.Dtp_Fecha_Emision_Hasta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Emision_Hasta.TabIndex = 112
        Me.Dtp_Fecha_Emision_Hasta.Value = New Date(2017, 5, 9, 17, 44, 34, 0)
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupPanel2.Controls.Add(Me.TableLayoutPanel9)
        Me.GroupPanel2.Controls.Add(Me.TableLayoutPanel6)
        Me.GroupPanel2.Controls.Add(Me.TableLayoutPanel7)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(12, 77)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(311, 167)
        '
        '
        '
        Me.GroupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel2.Style.BackColorGradientAngle = 90
        Me.GroupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderBottomWidth = 1
        Me.GroupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderLeftWidth = 1
        Me.GroupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderRightWidth = 1
        Me.GroupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderTopWidth = 1
        Me.GroupPanel2.Style.CornerDiameter = 4
        Me.GroupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel2.TabIndex = 123
        Me.GroupPanel2.Text = "Filtros Entidades"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_Entidades_Algunas, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_Entidades_Todas, 1, 0)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 108)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(296, 25)
        Me.TableLayoutPanel1.TabIndex = 50
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
        Me.LabelX2.Size = New System.Drawing.Size(100, 19)
        Me.LabelX2.TabIndex = 4
        Me.LabelX2.Text = "Entidades"
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
        Me.Rdb_Entidades_Algunas.Location = New System.Drawing.Point(193, 3)
        Me.Rdb_Entidades_Algunas.Name = "Rdb_Entidades_Algunas"
        Me.Rdb_Entidades_Algunas.Size = New System.Drawing.Size(94, 19)
        Me.Rdb_Entidades_Algunas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Entidades_Algunas.TabIndex = 3
        Me.Rdb_Entidades_Algunas.Text = "Algunas"
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
        Me.Rdb_Entidades_Todas.Location = New System.Drawing.Point(109, 3)
        Me.Rdb_Entidades_Todas.Name = "Rdb_Entidades_Todas"
        Me.Rdb_Entidades_Todas.Size = New System.Drawing.Size(78, 19)
        Me.Rdb_Entidades_Todas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Entidades_Todas.TabIndex = 1
        Me.Rdb_Entidades_Todas.Text = "Todas "
        '
        'TableLayoutPanel9
        '
        Me.TableLayoutPanel9.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel9.ColumnCount = 3
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84.0!))
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
        Me.TableLayoutPanel9.Controls.Add(Me.LabelX10, 0, 0)
        Me.TableLayoutPanel9.Controls.Add(Me.Rdb_Sucursales_Algunas, 2, 0)
        Me.TableLayoutPanel9.Controls.Add(Me.Rdb_Sucursales_Todas, 1, 0)
        Me.TableLayoutPanel9.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel9.Location = New System.Drawing.Point(3, 46)
        Me.TableLayoutPanel9.Name = "TableLayoutPanel9"
        Me.TableLayoutPanel9.RowCount = 1
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel9.Size = New System.Drawing.Size(296, 25)
        Me.TableLayoutPanel9.TabIndex = 49
        '
        'LabelX10
        '
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.ForeColor = System.Drawing.Color.Black
        Me.LabelX10.Location = New System.Drawing.Point(3, 3)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(100, 19)
        Me.LabelX10.TabIndex = 4
        Me.LabelX10.Text = "Sucursales"
        '
        'Rdb_Sucursales_Algunas
        '
        Me.Rdb_Sucursales_Algunas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Sucursales_Algunas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Sucursales_Algunas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Sucursales_Algunas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Sucursales_Algunas.Location = New System.Drawing.Point(193, 3)
        Me.Rdb_Sucursales_Algunas.Name = "Rdb_Sucursales_Algunas"
        Me.Rdb_Sucursales_Algunas.Size = New System.Drawing.Size(94, 19)
        Me.Rdb_Sucursales_Algunas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Sucursales_Algunas.TabIndex = 3
        Me.Rdb_Sucursales_Algunas.Text = "Algunas"
        '
        'Rdb_Sucursales_Todas
        '
        Me.Rdb_Sucursales_Todas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Sucursales_Todas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Sucursales_Todas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Sucursales_Todas.Checked = True
        Me.Rdb_Sucursales_Todas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Sucursales_Todas.CheckValue = "Y"
        Me.Rdb_Sucursales_Todas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Sucursales_Todas.Location = New System.Drawing.Point(109, 3)
        Me.Rdb_Sucursales_Todas.Name = "Rdb_Sucursales_Todas"
        Me.Rdb_Sucursales_Todas.Size = New System.Drawing.Size(78, 19)
        Me.Rdb_Sucursales_Todas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Sucursales_Todas.TabIndex = 1
        Me.Rdb_Sucursales_Todas.Text = "Todas "
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel6.ColumnCount = 3
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.LabelX7, 0, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.Rdb_Documentos_Algunos, 2, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.Rdb_Documentos_Todos, 1, 0)
        Me.TableLayoutPanel6.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(3, 15)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 1
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(296, 25)
        Me.TableLayoutPanel6.TabIndex = 47
        '
        'LabelX7
        '
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.ForeColor = System.Drawing.Color.Black
        Me.LabelX7.Location = New System.Drawing.Point(3, 3)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(100, 19)
        Me.LabelX7.TabIndex = 4
        Me.LabelX7.Text = "Documentos"
        '
        'Rdb_Documentos_Algunos
        '
        Me.Rdb_Documentos_Algunos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Documentos_Algunos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Documentos_Algunos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Documentos_Algunos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Documentos_Algunos.Location = New System.Drawing.Point(193, 3)
        Me.Rdb_Documentos_Algunos.Name = "Rdb_Documentos_Algunos"
        Me.Rdb_Documentos_Algunos.Size = New System.Drawing.Size(94, 19)
        Me.Rdb_Documentos_Algunos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Documentos_Algunos.TabIndex = 3
        Me.Rdb_Documentos_Algunos.Text = "Algunas"
        '
        'Rdb_Documentos_Todos
        '
        Me.Rdb_Documentos_Todos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Documentos_Todos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Documentos_Todos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Documentos_Todos.Checked = True
        Me.Rdb_Documentos_Todos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Documentos_Todos.CheckValue = "Y"
        Me.Rdb_Documentos_Todos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Documentos_Todos.Location = New System.Drawing.Point(109, 3)
        Me.Rdb_Documentos_Todos.Name = "Rdb_Documentos_Todos"
        Me.Rdb_Documentos_Todos.Size = New System.Drawing.Size(78, 19)
        Me.Rdb_Documentos_Todos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Documentos_Todos.TabIndex = 1
        Me.Rdb_Documentos_Todos.Text = "Todas "
        '
        'TableLayoutPanel7
        '
        Me.TableLayoutPanel7.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel7.ColumnCount = 3
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
        Me.TableLayoutPanel7.Controls.Add(Me.LabelX8, 0, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.Rdb_Responsables_Algunos, 2, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.Rdb_Responsables_Todos, 1, 0)
        Me.TableLayoutPanel7.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel7.Location = New System.Drawing.Point(3, 77)
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        Me.TableLayoutPanel7.RowCount = 1
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel7.Size = New System.Drawing.Size(296, 25)
        Me.TableLayoutPanel7.TabIndex = 48
        '
        'LabelX8
        '
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.ForeColor = System.Drawing.Color.Black
        Me.LabelX8.Location = New System.Drawing.Point(3, 3)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(100, 19)
        Me.LabelX8.TabIndex = 4
        Me.LabelX8.Text = "Responsables"
        '
        'Rdb_Responsables_Algunos
        '
        Me.Rdb_Responsables_Algunos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Responsables_Algunos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Responsables_Algunos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Responsables_Algunos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Responsables_Algunos.Location = New System.Drawing.Point(193, 3)
        Me.Rdb_Responsables_Algunos.Name = "Rdb_Responsables_Algunos"
        Me.Rdb_Responsables_Algunos.Size = New System.Drawing.Size(94, 19)
        Me.Rdb_Responsables_Algunos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Responsables_Algunos.TabIndex = 3
        Me.Rdb_Responsables_Algunos.Text = "Algunas"
        '
        'Rdb_Responsables_Todos
        '
        Me.Rdb_Responsables_Todos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Responsables_Todos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Responsables_Todos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Responsables_Todos.Checked = True
        Me.Rdb_Responsables_Todos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Responsables_Todos.CheckValue = "Y"
        Me.Rdb_Responsables_Todos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Responsables_Todos.Location = New System.Drawing.Point(109, 3)
        Me.Rdb_Responsables_Todos.Name = "Rdb_Responsables_Todos"
        Me.Rdb_Responsables_Todos.Size = New System.Drawing.Size(78, 19)
        Me.Rdb_Responsables_Todos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Responsables_Todos.TabIndex = 1
        Me.Rdb_Responsables_Todos.Text = "Todas "
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Procesar})
        Me.Bar1.Location = New System.Drawing.Point(0, 256)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(335, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 124
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Procesar
        '
        Me.Btn_Procesar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Procesar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Procesar.Image = CType(resources.GetObject("Btn_Procesar.Image"), System.Drawing.Image)
        Me.Btn_Procesar.ImageAlt = CType(resources.GetObject("Btn_Procesar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Procesar.Name = "Btn_Procesar"
        Me.Btn_Procesar.Tooltip = "Procesar"
        '
        'Frm_MantFacturasElecFiltrar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(335, 297)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.GroupPanel3)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_MantFacturasElecFiltrar"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "INFORME DEL ESTADO DE ENVIOS DTE AL SII"
        Me.GroupPanel3.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.Dtp_Fecha_Emision_Desde, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_Fecha_Emision_Hasta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel9.ResumeLayout(False)
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel7.ResumeLayout(False)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dtp_Fecha_Emision_Desde As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Dtp_Fecha_Emision_Hasta As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel9 As TableLayoutPanel
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_Sucursales_Algunas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Sucursales_Todas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents TableLayoutPanel6 As TableLayoutPanel
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_Documentos_Algunos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Documentos_Todos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents TableLayoutPanel7 As TableLayoutPanel
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_Responsables_Algunos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Responsables_Todos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_Entidades_Algunas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Entidades_Todas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Procesar As DevComponents.DotNetBar.ButtonItem
End Class
