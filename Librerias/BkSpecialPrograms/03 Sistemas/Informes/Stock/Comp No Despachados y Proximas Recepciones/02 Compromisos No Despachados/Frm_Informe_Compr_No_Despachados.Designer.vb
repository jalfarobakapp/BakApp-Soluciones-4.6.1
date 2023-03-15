<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Informe_Compr_No_Despachados
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Informe_Compr_No_Despachados))
        Me.Rdb_Todos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.GroupPanel5 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Chk_Fecha_Recepcion = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.Dtp_Fecha_Recepcion_Hasta = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_Fecha_Recepcion_Desde = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Rdb_COV = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_NCV = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_BLV = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_FCV = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_NVV = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_NVI = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Dtp_Fecha_Emision_Desde = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Dtp_Fecha_Emision_Hasta = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Rdb_Lineas_Pendientes = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Lineas_Todas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Chk_Incluir_COV = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Stock_Fisico = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.Chk_Excluye_FLN = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Ejecutar_Informe = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel4 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.Rdb_Ud2 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Ud1 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtros_Bodega = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Clasificacion_Productos = New DevComponents.DotNetBar.ButtonItem()
        Me.Chk_NVVHabilitadasFacturar = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.GroupPanel5.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        CType(Me.Dtp_Fecha_Recepcion_Hasta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_Fecha_Recepcion_Desde, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.Dtp_Fecha_Emision_Desde, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_Fecha_Emision_Hasta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupPanel3.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.GroupPanel2.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel4.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Rdb_Todos
        '
        Me.Rdb_Todos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Todos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Todos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Todos.FocusCuesEnabled = False
        Me.Rdb_Todos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Todos.Location = New System.Drawing.Point(3, 141)
        Me.Rdb_Todos.Name = "Rdb_Todos"
        Me.Rdb_Todos.Size = New System.Drawing.Size(203, 15)
        Me.Rdb_Todos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Todos.TabIndex = 115
        Me.Rdb_Todos.Text = "Todos los documentos"
        '
        'GroupPanel5
        '
        Me.GroupPanel5.BackColor = System.Drawing.Color.White
        Me.GroupPanel5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel5.Controls.Add(Me.Chk_Fecha_Recepcion)
        Me.GroupPanel5.Controls.Add(Me.TableLayoutPanel6)
        Me.GroupPanel5.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel5.Location = New System.Drawing.Point(12, 336)
        Me.GroupPanel5.Name = "GroupPanel5"
        Me.GroupPanel5.Size = New System.Drawing.Size(398, 59)
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
        Me.GroupPanel5.TabIndex = 122
        Me.GroupPanel5.Text = "Documentos por recibir, fecha de recepción en documentos..."
        '
        'Chk_Fecha_Recepcion
        '
        Me.Chk_Fecha_Recepcion.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Fecha_Recepcion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Fecha_Recepcion.FocusCuesEnabled = False
        Me.Chk_Fecha_Recepcion.ForeColor = System.Drawing.Color.Black
        Me.Chk_Fecha_Recepcion.Location = New System.Drawing.Point(3, 6)
        Me.Chk_Fecha_Recepcion.Name = "Chk_Fecha_Recepcion"
        Me.Chk_Fecha_Recepcion.Size = New System.Drawing.Size(143, 23)
        Me.Chk_Fecha_Recepcion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Fecha_Recepcion.TabIndex = 115
        Me.Chk_Fecha_Recepcion.Text = "Incluir esta condición"
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel6.ColumnCount = 4
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.Controls.Add(Me.Dtp_Fecha_Recepcion_Hasta, 3, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.LabelX2, 2, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.Dtp_Fecha_Recepcion_Desde, 1, 0)
        Me.TableLayoutPanel6.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(163, 3)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 1
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(206, 31)
        Me.TableLayoutPanel6.TabIndex = 115
        '
        'Dtp_Fecha_Recepcion_Hasta
        '
        Me.Dtp_Fecha_Recepcion_Hasta.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_Fecha_Recepcion_Hasta.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Recepcion_Hasta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Recepcion_Hasta.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Recepcion_Hasta.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Recepcion_Hasta.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Recepcion_Hasta.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Recepcion_Hasta.Location = New System.Drawing.Point(112, 3)
        '
        '
        '
        Me.Dtp_Fecha_Recepcion_Hasta.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Recepcion_Hasta.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Recepcion_Hasta.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Recepcion_Hasta.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Recepcion_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Recepcion_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Recepcion_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Recepcion_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Recepcion_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Recepcion_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Recepcion_Hasta.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Recepcion_Hasta.MonthCalendar.DisplayMonth = New Date(2017, 5, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Recepcion_Hasta.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Recepcion_Hasta.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Recepcion_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Recepcion_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Recepcion_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Recepcion_Hasta.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Recepcion_Hasta.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Recepcion_Hasta.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Recepcion_Hasta.Name = "Dtp_Fecha_Recepcion_Hasta"
        Me.Dtp_Fecha_Recepcion_Hasta.Size = New System.Drawing.Size(82, 22)
        Me.Dtp_Fecha_Recepcion_Hasta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Recepcion_Hasta.TabIndex = 112
        Me.Dtp_Fecha_Recepcion_Hasta.Value = New Date(2017, 5, 9, 17, 44, 34, 0)
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(96, 3)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(10, 23)
        Me.LabelX2.TabIndex = 114
        Me.LabelX2.Text = "-"
        Me.LabelX2.TextAlignment = System.Drawing.StringAlignment.Center
        Me.LabelX2.TextLineAlignment = System.Drawing.StringAlignment.Near
        '
        'Dtp_Fecha_Recepcion_Desde
        '
        Me.Dtp_Fecha_Recepcion_Desde.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_Fecha_Recepcion_Desde.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Recepcion_Desde.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Recepcion_Desde.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Recepcion_Desde.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Recepcion_Desde.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Recepcion_Desde.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Recepcion_Desde.Location = New System.Drawing.Point(3, 3)
        '
        '
        '
        Me.Dtp_Fecha_Recepcion_Desde.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Recepcion_Desde.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Recepcion_Desde.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Recepcion_Desde.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Recepcion_Desde.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Recepcion_Desde.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Recepcion_Desde.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Recepcion_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Recepcion_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Recepcion_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Recepcion_Desde.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Recepcion_Desde.MonthCalendar.DisplayMonth = New Date(2017, 5, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Recepcion_Desde.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Recepcion_Desde.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Recepcion_Desde.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Recepcion_Desde.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Recepcion_Desde.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Recepcion_Desde.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Recepcion_Desde.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Recepcion_Desde.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Recepcion_Desde.Name = "Dtp_Fecha_Recepcion_Desde"
        Me.Dtp_Fecha_Recepcion_Desde.Size = New System.Drawing.Size(87, 22)
        Me.Dtp_Fecha_Recepcion_Desde.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Recepcion_Desde.TabIndex = 105
        Me.Dtp_Fecha_Recepcion_Desde.Value = New Date(2017, 5, 9, 17, 44, 34, 0)
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.Rdb_COV, 0, 5)
        Me.TableLayoutPanel3.Controls.Add(Me.Rdb_NCV, 0, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.Rdb_BLV, 0, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.Rdb_FCV, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.Rdb_NVV, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Rdb_NVI, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Rdb_Todos, 0, 6)
        Me.TableLayoutPanel3.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 7
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(209, 159)
        Me.TableLayoutPanel3.TabIndex = 5
        '
        'Rdb_COV
        '
        Me.Rdb_COV.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_COV.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_COV.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_COV.FocusCuesEnabled = False
        Me.Rdb_COV.ForeColor = System.Drawing.Color.Black
        Me.Rdb_COV.Location = New System.Drawing.Point(3, 118)
        Me.Rdb_COV.Name = "Rdb_COV"
        Me.Rdb_COV.Size = New System.Drawing.Size(203, 15)
        Me.Rdb_COV.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_COV.TabIndex = 123
        Me.Rdb_COV.Text = "Cotizaciones (COV)"
        '
        'Rdb_NCV
        '
        Me.Rdb_NCV.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_NCV.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_NCV.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_NCV.FocusCuesEnabled = False
        Me.Rdb_NCV.ForeColor = System.Drawing.Color.Black
        Me.Rdb_NCV.Location = New System.Drawing.Point(3, 95)
        Me.Rdb_NCV.Name = "Rdb_NCV"
        Me.Rdb_NCV.Size = New System.Drawing.Size(203, 16)
        Me.Rdb_NCV.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_NCV.TabIndex = 6
        Me.Rdb_NCV.Text = "Notas de crédito (NCV)"
        '
        'Rdb_BLV
        '
        Me.Rdb_BLV.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_BLV.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_BLV.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_BLV.FocusCuesEnabled = False
        Me.Rdb_BLV.ForeColor = System.Drawing.Color.Black
        Me.Rdb_BLV.Location = New System.Drawing.Point(3, 72)
        Me.Rdb_BLV.Name = "Rdb_BLV"
        Me.Rdb_BLV.Size = New System.Drawing.Size(203, 16)
        Me.Rdb_BLV.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_BLV.TabIndex = 6
        Me.Rdb_BLV.Text = "Boletas (BLV)"
        '
        'Rdb_FCV
        '
        Me.Rdb_FCV.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_FCV.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_FCV.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_FCV.FocusCuesEnabled = False
        Me.Rdb_FCV.ForeColor = System.Drawing.Color.Black
        Me.Rdb_FCV.Location = New System.Drawing.Point(3, 49)
        Me.Rdb_FCV.Name = "Rdb_FCV"
        Me.Rdb_FCV.Size = New System.Drawing.Size(203, 16)
        Me.Rdb_FCV.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_FCV.TabIndex = 6
        Me.Rdb_FCV.Text = "Facturas (FCV)"
        '
        'Rdb_NVV
        '
        Me.Rdb_NVV.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_NVV.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_NVV.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_NVV.FocusCuesEnabled = False
        Me.Rdb_NVV.ForeColor = System.Drawing.Color.Black
        Me.Rdb_NVV.Location = New System.Drawing.Point(3, 26)
        Me.Rdb_NVV.Name = "Rdb_NVV"
        Me.Rdb_NVV.Size = New System.Drawing.Size(203, 16)
        Me.Rdb_NVV.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_NVV.TabIndex = 6
        Me.Rdb_NVV.Text = "Notas de venta (NVV)"
        '
        'Rdb_NVI
        '
        Me.Rdb_NVI.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_NVI.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_NVI.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_NVI.Checked = True
        Me.Rdb_NVI.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_NVI.CheckValue = "Y"
        Me.Rdb_NVI.FocusCuesEnabled = False
        Me.Rdb_NVI.ForeColor = System.Drawing.Color.Black
        Me.Rdb_NVI.Location = New System.Drawing.Point(3, 3)
        Me.Rdb_NVI.Name = "Rdb_NVI"
        Me.Rdb_NVI.Size = New System.Drawing.Size(203, 16)
        Me.Rdb_NVI.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_NVI.TabIndex = 3
        Me.Rdb_NVI.Text = "Notas de venta interna (NVI)"
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
        Me.Dtp_Fecha_Emision_Desde.Size = New System.Drawing.Size(92, 22)
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
        Me.Dtp_Fecha_Emision_Hasta.Location = New System.Drawing.Point(117, 3)
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
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_Lineas_Pendientes, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_Lineas_Todas, 0, 0)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 6)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(153, 43)
        Me.TableLayoutPanel1.TabIndex = 5
        '
        'Rdb_Lineas_Pendientes
        '
        Me.Rdb_Lineas_Pendientes.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Lineas_Pendientes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Lineas_Pendientes.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Lineas_Pendientes.Checked = True
        Me.Rdb_Lineas_Pendientes.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Lineas_Pendientes.CheckValue = "Y"
        Me.Rdb_Lineas_Pendientes.FocusCuesEnabled = False
        Me.Rdb_Lineas_Pendientes.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Lineas_Pendientes.Location = New System.Drawing.Point(3, 24)
        Me.Rdb_Lineas_Pendientes.Name = "Rdb_Lineas_Pendientes"
        Me.Rdb_Lineas_Pendientes.Size = New System.Drawing.Size(147, 16)
        Me.Rdb_Lineas_Pendientes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Lineas_Pendientes.TabIndex = 6
        Me.Rdb_Lineas_Pendientes.Text = "Solo líneas pendientes"
        '
        'Rdb_Lineas_Todas
        '
        Me.Rdb_Lineas_Todas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Lineas_Todas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Lineas_Todas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Lineas_Todas.FocusCuesEnabled = False
        Me.Rdb_Lineas_Todas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Lineas_Todas.Location = New System.Drawing.Point(3, 3)
        Me.Rdb_Lineas_Todas.Name = "Rdb_Lineas_Todas"
        Me.Rdb_Lineas_Todas.Size = New System.Drawing.Size(94, 14)
        Me.Rdb_Lineas_Todas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Lineas_Todas.TabIndex = 3
        Me.Rdb_Lineas_Todas.Text = "Todas las líneas"
        '
        'GroupPanel3
        '
        Me.GroupPanel3.BackColor = System.Drawing.Color.White
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.TableLayoutPanel2)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Location = New System.Drawing.Point(12, 47)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(225, 59)
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
        Me.GroupPanel3.TabIndex = 121
        Me.GroupPanel3.Text = "Emitidas entre"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.Controls.Add(Me.LabelX1, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Dtp_Fecha_Emision_Desde, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Dtp_Fecha_Emision_Hasta, 2, 0)
        Me.TableLayoutPanel2.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(214, 31)
        Me.TableLayoutPanel2.TabIndex = 5
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(101, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(10, 23)
        Me.LabelX1.TabIndex = 114
        Me.LabelX1.Text = "-"
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Center
        Me.LabelX1.TextLineAlignment = System.Drawing.StringAlignment.Near
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(243, 112)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(167, 89)
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
        Me.GroupPanel2.TabIndex = 117
        Me.GroupPanel2.Text = "Detalle"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.TableLayoutPanel3)
        Me.GroupPanel1.Controls.Add(Me.Chk_Incluir_COV)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 112)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(225, 207)
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
        Me.GroupPanel1.TabIndex = 116
        Me.GroupPanel1.Text = "Tipo de documentos"
        '
        'Chk_Incluir_COV
        '
        Me.Chk_Incluir_COV.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Incluir_COV.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Incluir_COV.FocusCuesEnabled = False
        Me.Chk_Incluir_COV.ForeColor = System.Drawing.Color.Black
        Me.Chk_Incluir_COV.Location = New System.Drawing.Point(19, 163)
        Me.Chk_Incluir_COV.Name = "Chk_Incluir_COV"
        Me.Chk_Incluir_COV.Size = New System.Drawing.Size(203, 23)
        Me.Chk_Incluir_COV.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Incluir_COV.TabIndex = 6
        Me.Chk_Incluir_COV.Text = "Incluir cotizaciones (COV)"
        Me.Chk_Incluir_COV.Visible = False
        '
        'Chk_Stock_Fisico
        '
        Me.Chk_Stock_Fisico.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Stock_Fisico.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Stock_Fisico.Checked = True
        Me.Chk_Stock_Fisico.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_Stock_Fisico.CheckValue = "Y"
        Me.Chk_Stock_Fisico.FocusCuesEnabled = False
        Me.Chk_Stock_Fisico.ForeColor = System.Drawing.Color.Black
        Me.Chk_Stock_Fisico.Location = New System.Drawing.Point(3, 3)
        Me.Chk_Stock_Fisico.Name = "Chk_Stock_Fisico"
        Me.Chk_Stock_Fisico.Size = New System.Drawing.Size(155, 16)
        Me.Chk_Stock_Fisico.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Stock_Fisico.TabIndex = 94
        Me.Chk_Stock_Fisico.Text = "Traer Stock físico bodega"
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel5.ColumnCount = 1
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.Chk_Stock_Fisico, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Chk_Excluye_FLN, 0, 1)
        Me.TableLayoutPanel5.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(249, 58)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 2
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(161, 48)
        Me.TableLayoutPanel5.TabIndex = 119
        '
        'Chk_Excluye_FLN
        '
        Me.Chk_Excluye_FLN.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Excluye_FLN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Excluye_FLN.Checked = True
        Me.Chk_Excluye_FLN.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_Excluye_FLN.CheckValue = "Y"
        Me.Chk_Excluye_FLN.FocusCuesEnabled = False
        Me.Chk_Excluye_FLN.ForeColor = System.Drawing.Color.Black
        Me.Chk_Excluye_FLN.Location = New System.Drawing.Point(3, 27)
        Me.Chk_Excluye_FLN.Name = "Chk_Excluye_FLN"
        Me.Chk_Excluye_FLN.Size = New System.Drawing.Size(155, 16)
        Me.Chk_Excluye_FLN.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Excluye_FLN.TabIndex = 95
        Me.Chk_Excluye_FLN.Text = "Traer "
        Me.Chk_Excluye_FLN.Visible = False
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Ejecutar_Informe})
        Me.Bar1.Location = New System.Drawing.Point(0, 422)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(422, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 115
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Ejecutar_Informe
        '
        Me.Btn_Ejecutar_Informe.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Ejecutar_Informe.ForeColor = System.Drawing.Color.Black
        Me.Btn_Ejecutar_Informe.Image = CType(resources.GetObject("Btn_Ejecutar_Informe.Image"), System.Drawing.Image)
        Me.Btn_Ejecutar_Informe.ImageAlt = CType(resources.GetObject("Btn_Ejecutar_Informe.ImageAlt"), System.Drawing.Image)
        Me.Btn_Ejecutar_Informe.Name = "Btn_Ejecutar_Informe"
        Me.Btn_Ejecutar_Informe.Text = "Procesar informe"
        '
        'GroupPanel4
        '
        Me.GroupPanel4.BackColor = System.Drawing.Color.White
        Me.GroupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel4.Controls.Add(Me.TableLayoutPanel4)
        Me.GroupPanel4.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel4.Location = New System.Drawing.Point(243, 207)
        Me.GroupPanel4.Name = "GroupPanel4"
        Me.GroupPanel4.Size = New System.Drawing.Size(167, 112)
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
        Me.GroupPanel4.TabIndex = 118
        Me.GroupPanel4.Text = "Unidad"
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel4.ColumnCount = 1
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.Rdb_Ud2, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.Rdb_Ud1, 0, 0)
        Me.TableLayoutPanel4.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 2
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(135, 45)
        Me.TableLayoutPanel4.TabIndex = 5
        '
        'Rdb_Ud2
        '
        Me.Rdb_Ud2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Ud2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Ud2.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Ud2.FocusCuesEnabled = False
        Me.Rdb_Ud2.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Ud2.Location = New System.Drawing.Point(3, 25)
        Me.Rdb_Ud2.Name = "Rdb_Ud2"
        Me.Rdb_Ud2.Size = New System.Drawing.Size(126, 14)
        Me.Rdb_Ud2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Ud2.TabIndex = 6
        Me.Rdb_Ud2.Text = "Secundaria"
        '
        'Rdb_Ud1
        '
        Me.Rdb_Ud1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Ud1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Ud1.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Ud1.Checked = True
        Me.Rdb_Ud1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Ud1.CheckValue = "Y"
        Me.Rdb_Ud1.FocusCuesEnabled = False
        Me.Rdb_Ud1.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Ud1.Location = New System.Drawing.Point(3, 3)
        Me.Rdb_Ud1.Name = "Rdb_Ud1"
        Me.Rdb_Ud1.Size = New System.Drawing.Size(94, 14)
        Me.Rdb_Ud1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Ud1.TabIndex = 3
        Me.Rdb_Ud1.Text = "Principal"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem1})
        Me.Bar2.Location = New System.Drawing.Point(0, 0)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(422, 33)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar2.TabIndex = 120
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'ButtonItem1
        '
        Me.ButtonItem1.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem1.Image = CType(resources.GetObject("ButtonItem1.Image"), System.Drawing.Image)
        Me.ButtonItem1.Name = "ButtonItem1"
        Me.ButtonItem1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Filtros_Bodega, Me.Btn_Clasificacion_Productos})
        Me.ButtonItem1.Text = "Filtros"
        '
        'Btn_Filtros_Bodega
        '
        Me.Btn_Filtros_Bodega.Image = CType(resources.GetObject("Btn_Filtros_Bodega.Image"), System.Drawing.Image)
        Me.Btn_Filtros_Bodega.ImageAlt = CType(resources.GetObject("Btn_Filtros_Bodega.ImageAlt"), System.Drawing.Image)
        Me.Btn_Filtros_Bodega.Name = "Btn_Filtros_Bodega"
        Me.Btn_Filtros_Bodega.Text = "Bodegas"
        '
        'Btn_Clasificacion_Productos
        '
        Me.Btn_Clasificacion_Productos.Image = CType(resources.GetObject("Btn_Clasificacion_Productos.Image"), System.Drawing.Image)
        Me.Btn_Clasificacion_Productos.ImageAlt = CType(resources.GetObject("Btn_Clasificacion_Productos.ImageAlt"), System.Drawing.Image)
        Me.Btn_Clasificacion_Productos.Name = "Btn_Clasificacion_Productos"
        Me.Btn_Clasificacion_Productos.Text = "Filtros (Super familia, Marcas, Clasificación, Rubro, Zonas)"
        '
        'Chk_NVVHabilitadasFacturar
        '
        Me.Chk_NVVHabilitadasFacturar.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_NVVHabilitadasFacturar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_NVVHabilitadasFacturar.Checked = True
        Me.Chk_NVVHabilitadasFacturar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_NVVHabilitadasFacturar.CheckValue = "Y"
        Me.Chk_NVVHabilitadasFacturar.FocusCuesEnabled = False
        Me.Chk_NVVHabilitadasFacturar.ForeColor = System.Drawing.Color.Black
        Me.Chk_NVVHabilitadasFacturar.Location = New System.Drawing.Point(12, 401)
        Me.Chk_NVVHabilitadasFacturar.Name = "Chk_NVVHabilitadasFacturar"
        Me.Chk_NVVHabilitadasFacturar.Size = New System.Drawing.Size(272, 15)
        Me.Chk_NVVHabilitadasFacturar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_NVVHabilitadasFacturar.TabIndex = 123
        Me.Chk_NVVHabilitadasFacturar.Text = "Solo Notas de Venta Habilitadas para facturar"
        '
        'Frm_Informe_Compr_No_Despachados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(422, 463)
        Me.Controls.Add(Me.Chk_NVVHabilitadasFacturar)
        Me.Controls.Add(Me.GroupPanel5)
        Me.Controls.Add(Me.GroupPanel3)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.TableLayoutPanel5)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.GroupPanel4)
        Me.Controls.Add(Me.Bar2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Informe_Compr_No_Despachados"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "COMPROMISOS NO DESPACHADOS (Venta - Stock)"
        Me.GroupPanel5.ResumeLayout(False)
        Me.TableLayoutPanel6.ResumeLayout(False)
        CType(Me.Dtp_Fecha_Recepcion_Hasta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_Fecha_Recepcion_Desde, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel3.ResumeLayout(False)
        CType(Me.Dtp_Fecha_Emision_Desde, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_Fecha_Emision_Hasta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupPanel3.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.GroupPanel2.ResumeLayout(False)
        Me.GroupPanel1.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Rdb_Todos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents GroupPanel5 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Chk_Fecha_Recepcion As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents TableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Dtp_Fecha_Recepcion_Hasta As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dtp_Fecha_Recepcion_Desde As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Rdb_NCV As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_BLV As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_FCV As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_NVV As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_NVI As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Dtp_Fecha_Emision_Desde As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Dtp_Fecha_Emision_Hasta As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Rdb_Lineas_Pendientes As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Lineas_Todas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Chk_Stock_Fisico As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Chk_Excluye_FLN As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Ejecutar_Informe As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel4 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Rdb_Ud2 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Ud1 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Filtros_Bodega As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Clasificacion_Productos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Rdb_COV As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Incluir_COV As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_NVVHabilitadasFacturar As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
