<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_DFA_Cierre_Atrasado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_DFA_Cierre_Atrasado))
        Me.WarningBox1 = New DevComponents.DotNetBar.Controls.WarningBox()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Dtp_Hora_Cierre = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Dtp_Fecha_Cierre = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_Fecha_Ingreso = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Dtp_Hora_Ingreso = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Aceptar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Salir = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.Dtp_Hora_Cierre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_Fecha_Cierre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_Fecha_Ingreso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_Hora_Ingreso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'WarningBox1
        '
        Me.WarningBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.WarningBox1.CloseButtonVisible = False
        Me.WarningBox1.ForeColor = System.Drawing.Color.Black
        Me.WarningBox1.Image = CType(resources.GetObject("WarningBox1.Image"), System.Drawing.Image)
        Me.WarningBox1.Location = New System.Drawing.Point(3, 60)
        Me.WarningBox1.Name = "WarningBox1"
        Me.WarningBox1.OptionsButtonVisible = False
        Me.WarningBox1.Size = New System.Drawing.Size(421, 32)
        Me.WarningBox1.TabIndex = 0
        Me.WarningBox1.Text = "<b> Cierre atrasado</b> Las operaciones deben ser abiertas y cerradas el mismo dí" &
    "as."
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupPanel1.CanvasColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupPanel1.Controls.Add(Me.WarningBox1)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(436, 104)
        '
        '
        '
        Me.GroupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel1.Style.BackColorGradientAngle = 90
        Me.GroupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderBottomWidth = 1
        Me.GroupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderLeftWidth = 1
        Me.GroupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderRightWidth = 1
        Me.GroupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderTopWidth = 1
        Me.GroupPanel1.Style.CornerDiameter = 4
        Me.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel1.TabIndex = 1
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Dtp_Hora_Cierre, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Dtp_Fecha_Cierre, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX4, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX3, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX2, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Dtp_Fecha_Ingreso, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Dtp_Hora_Ingreso, 3, 0)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(421, 51)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'Dtp_Hora_Cierre
        '
        '
        '
        '
        Me.Dtp_Hora_Cierre.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Hora_Cierre.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Hora_Cierre.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Hora_Cierre.ButtonDropDown.Visible = True
        Me.Dtp_Hora_Cierre.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Hora_Cierre.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime
        Me.Dtp_Hora_Cierre.IsPopupCalendarOpen = False
        Me.Dtp_Hora_Cierre.Location = New System.Drawing.Point(318, 28)
        '
        '
        '
        Me.Dtp_Hora_Cierre.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Hora_Cierre.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Hora_Cierre.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Hora_Cierre.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Hora_Cierre.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Hora_Cierre.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Hora_Cierre.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Hora_Cierre.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Hora_Cierre.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Hora_Cierre.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Hora_Cierre.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Hora_Cierre.MonthCalendar.DisplayMonth = New Date(2018, 8, 1, 0, 0, 0, 0)
        Me.Dtp_Hora_Cierre.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_Hora_Cierre.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Hora_Cierre.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Hora_Cierre.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Hora_Cierre.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Hora_Cierre.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Hora_Cierre.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Hora_Cierre.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Hora_Cierre.MonthCalendar.Visible = False
        Me.Dtp_Hora_Cierre.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Hora_Cierre.Name = "Dtp_Hora_Cierre"
        Me.Dtp_Hora_Cierre.Size = New System.Drawing.Size(60, 22)
        Me.Dtp_Hora_Cierre.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Hora_Cierre.TabIndex = 5
        Me.Dtp_Hora_Cierre.Value = New Date(2018, 8, 7, 11, 47, 57, 0)
        '
        'Dtp_Fecha_Cierre
        '
        '
        '
        '
        Me.Dtp_Fecha_Cierre.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Cierre.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Cierre.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Cierre.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Cierre.Enabled = False
        Me.Dtp_Fecha_Cierre.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Cierre.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Cierre.Location = New System.Drawing.Point(108, 28)
        '
        '
        '
        Me.Dtp_Fecha_Cierre.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Cierre.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Cierre.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Cierre.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Cierre.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Cierre.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Cierre.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Cierre.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Cierre.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Cierre.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Cierre.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Cierre.MonthCalendar.DisplayMonth = New Date(2018, 8, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Cierre.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_Fecha_Cierre.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Cierre.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Cierre.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Cierre.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Cierre.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Cierre.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Cierre.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Cierre.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Cierre.Name = "Dtp_Fecha_Cierre"
        Me.Dtp_Fecha_Cierre.Size = New System.Drawing.Size(89, 22)
        Me.Dtp_Fecha_Cierre.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Cierre.TabIndex = 4
        Me.Dtp_Fecha_Cierre.Value = New Date(2018, 8, 7, 11, 47, 48, 0)
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(213, 28)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(75, 20)
        Me.LabelX4.TabIndex = 4
        Me.LabelX4.Text = "Hora cierre"
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(3, 28)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(75, 20)
        Me.LabelX3.TabIndex = 3
        Me.LabelX3.Text = "Fecha cierre"
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(213, 3)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 19)
        Me.LabelX2.TabIndex = 3
        Me.LabelX2.Text = "Hora ingreso"
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
        Me.LabelX1.Size = New System.Drawing.Size(75, 19)
        Me.LabelX1.TabIndex = 2
        Me.LabelX1.Text = "Fecha ingreso"
        '
        'Dtp_Fecha_Ingreso
        '
        '
        '
        '
        Me.Dtp_Fecha_Ingreso.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Ingreso.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Ingreso.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Ingreso.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Ingreso.Enabled = False
        Me.Dtp_Fecha_Ingreso.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Ingreso.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Ingreso.Location = New System.Drawing.Point(108, 3)
        '
        '
        '
        Me.Dtp_Fecha_Ingreso.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Ingreso.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Ingreso.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Ingreso.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Ingreso.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Ingreso.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Ingreso.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Ingreso.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Ingreso.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Ingreso.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Ingreso.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Ingreso.MonthCalendar.DisplayMonth = New Date(2018, 8, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Ingreso.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_Fecha_Ingreso.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Ingreso.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Ingreso.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Ingreso.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Ingreso.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Ingreso.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Ingreso.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Ingreso.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Ingreso.Name = "Dtp_Fecha_Ingreso"
        Me.Dtp_Fecha_Ingreso.Size = New System.Drawing.Size(89, 22)
        Me.Dtp_Fecha_Ingreso.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Ingreso.TabIndex = 3
        Me.Dtp_Fecha_Ingreso.Value = New Date(2018, 8, 7, 11, 47, 53, 0)
        '
        'Dtp_Hora_Ingreso
        '
        '
        '
        '
        Me.Dtp_Hora_Ingreso.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Hora_Ingreso.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Hora_Ingreso.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Hora_Ingreso.ButtonDropDown.Visible = True
        Me.Dtp_Hora_Ingreso.Enabled = False
        Me.Dtp_Hora_Ingreso.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Hora_Ingreso.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime
        Me.Dtp_Hora_Ingreso.IsPopupCalendarOpen = False
        Me.Dtp_Hora_Ingreso.Location = New System.Drawing.Point(318, 3)
        '
        '
        '
        Me.Dtp_Hora_Ingreso.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Hora_Ingreso.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Hora_Ingreso.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Hora_Ingreso.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Hora_Ingreso.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Hora_Ingreso.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Hora_Ingreso.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Hora_Ingreso.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Hora_Ingreso.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Hora_Ingreso.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Hora_Ingreso.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Hora_Ingreso.MonthCalendar.DisplayMonth = New Date(2018, 8, 1, 0, 0, 0, 0)
        Me.Dtp_Hora_Ingreso.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_Hora_Ingreso.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Hora_Ingreso.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Hora_Ingreso.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Hora_Ingreso.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Hora_Ingreso.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Hora_Ingreso.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Hora_Ingreso.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Hora_Ingreso.MonthCalendar.Visible = False
        Me.Dtp_Hora_Ingreso.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Hora_Ingreso.Name = "Dtp_Hora_Ingreso"
        Me.Dtp_Hora_Ingreso.Size = New System.Drawing.Size(60, 22)
        Me.Dtp_Hora_Ingreso.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Hora_Ingreso.TabIndex = 4
        Me.Dtp_Hora_Ingreso.Value = New Date(2018, 8, 7, 11, 47, 57, 0)
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Aceptar, Me.Btn_Salir})
        Me.Bar1.Location = New System.Drawing.Point(0, 125)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(460, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 26
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Aceptar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Aceptar.Image = CType(resources.GetObject("Btn_Aceptar.Image"), System.Drawing.Image)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Text = "ACEPTAR"
        Me.Btn_Aceptar.Visible = False
        '
        'Btn_Salir
        '
        Me.Btn_Salir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Salir.FontBold = True
        Me.Btn_Salir.ForeColor = System.Drawing.Color.Red
        Me.Btn_Salir.Image = CType(resources.GetObject("Btn_Salir.Image"), System.Drawing.Image)
        Me.Btn_Salir.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Salir.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.Btn_Salir.Name = "Btn_Salir"
        '
        'Frm_DFA_Cierre_Atrasado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(460, 166)
        Me.ControlBox = False
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.GroupPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_DFA_Cierre_Atrasado"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CIERRE ATRASADO DFA"
        Me.GroupPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.Dtp_Hora_Cierre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_Fecha_Cierre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_Fecha_Ingreso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_Hora_Ingreso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents WarningBox1 As DevComponents.DotNetBar.Controls.WarningBox
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Public WithEvents Btn_Aceptar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Salir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dtp_Fecha_Ingreso As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Dtp_Hora_Ingreso As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Dtp_Hora_Cierre As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Dtp_Fecha_Cierre As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
End Class
