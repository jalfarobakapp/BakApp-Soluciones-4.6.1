<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_CRV_Filtrar
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_CRV_Filtrar))
        Me.Rdb_CRV_Todas = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.Dtp_Fecha_Salida_Hasta = New DevComponents.Editors.DateTimeAdv.DateTimeInput
        Me.Dtp_Fecha_Salida_Desde = New DevComponents.Editors.DateTimeAdv.DateTimeInput
        Me.Layout_Vehiculo = New System.Windows.Forms.TableLayoutPanel
        Me.Cmb_Nuevo_Vehiculo = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX
        Me.Imagenes_32x32 = New System.Windows.Forms.ImageList(Me.components)
        Me.Grupo_Fechas = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Lbl_FS_hasta = New DevComponents.DotNetBar.LabelX
        Me.Rdb_Fecha_Salida_Rango = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.Rdb_Fecha_Salida_Todas = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.Lbl_FS_desde = New DevComponents.DotNetBar.LabelX
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel
        Me.Dtp_Fecha_Llegada_Hasta = New DevComponents.Editors.DateTimeAdv.DateTimeInput
        Me.Lbl_FL_hasta = New DevComponents.DotNetBar.LabelX
        Me.Dtp_Fecha_Llegada_Desde = New DevComponents.Editors.DateTimeAdv.DateTimeInput
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX
        Me.Rdb_Fecha_Llegada_Rango = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.Rdb_Fecha_Llegada_Todas = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.Lbl_FL_desde = New DevComponents.DotNetBar.LabelX
        Me.Grupo_OT = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX
        Me.Txt_Nro_CRV = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.Rdb_CRV_Una = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX
        Me.Rdb_Estados_Algunos = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.Rdb_Estados_Todas = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.BtnxSalir = New DevComponents.DotNetBar.ButtonItem
        Me.BtnFiltrar = New DevComponents.DotNetBar.ButtonItem
        Me.Grupo_Entidad = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.Layout_Chofer = New System.Windows.Forms.TableLayoutPanel
        Me.Cmb_Chofer = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
        Me.Rdb_Entidades_Algunas = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.Rdb_Entidades_Todas = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        CType(Me.Dtp_Fecha_Salida_Hasta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_Fecha_Salida_Desde, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Layout_Vehiculo.SuspendLayout()
        Me.Grupo_Fechas.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        CType(Me.Dtp_Fecha_Llegada_Hasta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_Fecha_Llegada_Desde, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_OT.SuspendLayout()
        Me.TableLayoutPanel7.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.Grupo_Entidad.SuspendLayout()
        Me.Layout_Chofer.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Rdb_CRV_Todas
        '
        Me.Rdb_CRV_Todas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_CRV_Todas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_CRV_Todas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_CRV_Todas.Checked = True
        Me.Rdb_CRV_Todas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_CRV_Todas.CheckValue = "Y"
        Me.Rdb_CRV_Todas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_CRV_Todas.Location = New System.Drawing.Point(178, 3)
        Me.Rdb_CRV_Todas.Name = "Rdb_CRV_Todas"
        Me.Rdb_CRV_Todas.Size = New System.Drawing.Size(85, 19)
        Me.Rdb_CRV_Todas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_CRV_Todas.TabIndex = 1
        Me.Rdb_CRV_Todas.Text = "Todos"
        '
        'Dtp_Fecha_Salida_Hasta
        '
        '
        '
        '
        Me.Dtp_Fecha_Salida_Hasta.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Salida_Hasta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Salida_Hasta.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Salida_Hasta.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Salida_Hasta.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Salida_Hasta.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Salida_Hasta.Location = New System.Drawing.Point(404, 3)
        '
        '
        '
        Me.Dtp_Fecha_Salida_Hasta.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Salida_Hasta.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Salida_Hasta.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Salida_Hasta.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Salida_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Salida_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Salida_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Salida_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Salida_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Salida_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Salida_Hasta.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Salida_Hasta.MonthCalendar.DisplayMonth = New Date(2016, 7, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Salida_Hasta.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Salida_Hasta.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Salida_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Salida_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Salida_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Salida_Hasta.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Salida_Hasta.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Salida_Hasta.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Salida_Hasta.Name = "Dtp_Fecha_Salida_Hasta"
        Me.Dtp_Fecha_Salida_Hasta.Size = New System.Drawing.Size(81, 22)
        Me.Dtp_Fecha_Salida_Hasta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Salida_Hasta.TabIndex = 8
        Me.Dtp_Fecha_Salida_Hasta.Value = New Date(2016, 7, 8, 16, 33, 0, 0)
        '
        'Dtp_Fecha_Salida_Desde
        '
        '
        '
        '
        Me.Dtp_Fecha_Salida_Desde.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Salida_Desde.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Salida_Desde.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Salida_Desde.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Salida_Desde.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Salida_Desde.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Salida_Desde.Location = New System.Drawing.Point(278, 3)
        '
        '
        '
        Me.Dtp_Fecha_Salida_Desde.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Salida_Desde.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Salida_Desde.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Salida_Desde.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Salida_Desde.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Salida_Desde.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Salida_Desde.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Salida_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Salida_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Salida_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Salida_Desde.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Salida_Desde.MonthCalendar.DisplayMonth = New Date(2016, 7, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Salida_Desde.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Salida_Desde.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Salida_Desde.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Salida_Desde.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Salida_Desde.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Salida_Desde.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Salida_Desde.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Salida_Desde.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Salida_Desde.Name = "Dtp_Fecha_Salida_Desde"
        Me.Dtp_Fecha_Salida_Desde.Size = New System.Drawing.Size(79, 22)
        Me.Dtp_Fecha_Salida_Desde.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Salida_Desde.TabIndex = 7
        Me.Dtp_Fecha_Salida_Desde.Value = New Date(2016, 7, 8, 16, 32, 31, 0)
        '
        'Layout_Vehiculo
        '
        Me.Layout_Vehiculo.BackColor = System.Drawing.Color.Transparent
        Me.Layout_Vehiculo.ColumnCount = 2
        Me.Layout_Vehiculo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Layout_Vehiculo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 263.0!))
        Me.Layout_Vehiculo.Controls.Add(Me.Cmb_Nuevo_Vehiculo, 1, 0)
        Me.Layout_Vehiculo.Controls.Add(Me.LabelX10, 0, 0)
        Me.Layout_Vehiculo.ForeColor = System.Drawing.Color.Black
        Me.Layout_Vehiculo.Location = New System.Drawing.Point(3, 68)
        Me.Layout_Vehiculo.Name = "Layout_Vehiculo"
        Me.Layout_Vehiculo.RowCount = 1
        Me.Layout_Vehiculo.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Layout_Vehiculo.Size = New System.Drawing.Size(485, 25)
        Me.Layout_Vehiculo.TabIndex = 27
        '
        'Cmb_Nuevo_Vehiculo
        '
        Me.Cmb_Nuevo_Vehiculo.DisplayMember = "Text"
        Me.Cmb_Nuevo_Vehiculo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Nuevo_Vehiculo.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Nuevo_Vehiculo.FormattingEnabled = True
        Me.Cmb_Nuevo_Vehiculo.ItemHeight = 16
        Me.Cmb_Nuevo_Vehiculo.Location = New System.Drawing.Point(225, 3)
        Me.Cmb_Nuevo_Vehiculo.Name = "Cmb_Nuevo_Vehiculo"
        Me.Cmb_Nuevo_Vehiculo.Size = New System.Drawing.Size(257, 22)
        Me.Cmb_Nuevo_Vehiculo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Nuevo_Vehiculo.TabIndex = 103
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
        Me.LabelX10.Size = New System.Drawing.Size(87, 19)
        Me.LabelX10.TabIndex = 4
        Me.LabelX10.Text = "Vehículo"
        '
        'Imagenes_32x32
        '
        Me.Imagenes_32x32.ImageStream = CType(resources.GetObject("Imagenes_32x32.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagenes_32x32.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagenes_32x32.Images.SetKeyName(0, "Delete")
        Me.Imagenes_32x32.Images.SetKeyName(1, "Warning")
        '
        'Grupo_Fechas
        '
        Me.Grupo_Fechas.BackColor = System.Drawing.Color.White
        Me.Grupo_Fechas.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Fechas.Controls.Add(Me.TableLayoutPanel1)
        Me.Grupo_Fechas.Controls.Add(Me.TableLayoutPanel6)
        Me.Grupo_Fechas.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Fechas.Location = New System.Drawing.Point(12, 242)
        Me.Grupo_Fechas.Name = "Grupo_Fechas"
        Me.Grupo_Fechas.Size = New System.Drawing.Size(503, 100)
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
        Me.Grupo_Fechas.TabIndex = 87
        Me.Grupo_Fechas.Text = "Fechas"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 7
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 165.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Dtp_Fecha_Salida_Hasta, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_FS_hasta, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Dtp_Fecha_Salida_Desde, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_Fecha_Salida_Rango, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_Fecha_Salida_Todas, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_FS_desde, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX4, 0, 0)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 13)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(566, 25)
        Me.TableLayoutPanel1.TabIndex = 6
        '
        'Lbl_FS_hasta
        '
        '
        '
        '
        Me.Lbl_FS_hasta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_FS_hasta.ForeColor = System.Drawing.Color.Black
        Me.Lbl_FS_hasta.Location = New System.Drawing.Point(364, 3)
        Me.Lbl_FS_hasta.Name = "Lbl_FS_hasta"
        Me.Lbl_FS_hasta.Size = New System.Drawing.Size(34, 19)
        Me.Lbl_FS_hasta.TabIndex = 9
        Me.Lbl_FS_hasta.Text = "Hasta"
        '
        'Rdb_Fecha_Salida_Rango
        '
        Me.Rdb_Fecha_Salida_Rango.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Fecha_Salida_Rango.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Fecha_Salida_Rango.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Fecha_Salida_Rango.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Fecha_Salida_Rango.Location = New System.Drawing.Point(166, 3)
        Me.Rdb_Fecha_Salida_Rango.Name = "Rdb_Fecha_Salida_Rango"
        Me.Rdb_Fecha_Salida_Rango.Size = New System.Drawing.Size(58, 19)
        Me.Rdb_Fecha_Salida_Rango.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Fecha_Salida_Rango.TabIndex = 3
        Me.Rdb_Fecha_Salida_Rango.Text = "Rango"
        '
        'Rdb_Fecha_Salida_Todas
        '
        Me.Rdb_Fecha_Salida_Todas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Fecha_Salida_Todas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Fecha_Salida_Todas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Fecha_Salida_Todas.Checked = True
        Me.Rdb_Fecha_Salida_Todas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Fecha_Salida_Todas.CheckValue = "Y"
        Me.Rdb_Fecha_Salida_Todas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Fecha_Salida_Todas.Location = New System.Drawing.Point(104, 3)
        Me.Rdb_Fecha_Salida_Todas.Name = "Rdb_Fecha_Salida_Todas"
        Me.Rdb_Fecha_Salida_Todas.Size = New System.Drawing.Size(56, 19)
        Me.Rdb_Fecha_Salida_Todas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Fecha_Salida_Todas.TabIndex = 1
        Me.Rdb_Fecha_Salida_Todas.Text = "Todas"
        '
        'Lbl_FS_desde
        '
        '
        '
        '
        Me.Lbl_FS_desde.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_FS_desde.ForeColor = System.Drawing.Color.Black
        Me.Lbl_FS_desde.Location = New System.Drawing.Point(230, 3)
        Me.Lbl_FS_desde.Name = "Lbl_FS_desde"
        Me.Lbl_FS_desde.Size = New System.Drawing.Size(38, 19)
        Me.Lbl_FS_desde.TabIndex = 7
        Me.Lbl_FS_desde.Text = "Desde"
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
        Me.LabelX4.Text = "Fecha de Salida"
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel6.ColumnCount = 7
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 164.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.Dtp_Fecha_Llegada_Hasta, 6, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.Lbl_FL_hasta, 5, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.Dtp_Fecha_Llegada_Desde, 4, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.LabelX9, 0, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.Rdb_Fecha_Llegada_Rango, 2, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.Rdb_Fecha_Llegada_Todas, 1, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.Lbl_FL_desde, 3, 0)
        Me.TableLayoutPanel6.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(3, 44)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 1
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(566, 25)
        Me.TableLayoutPanel6.TabIndex = 7
        '
        'Dtp_Fecha_Llegada_Hasta
        '
        '
        '
        '
        Me.Dtp_Fecha_Llegada_Hasta.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Llegada_Hasta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Llegada_Hasta.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Llegada_Hasta.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Llegada_Hasta.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Llegada_Hasta.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Llegada_Hasta.Location = New System.Drawing.Point(405, 3)
        '
        '
        '
        Me.Dtp_Fecha_Llegada_Hasta.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Llegada_Hasta.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Llegada_Hasta.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Llegada_Hasta.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Llegada_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Llegada_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Llegada_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Llegada_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Llegada_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Llegada_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Llegada_Hasta.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Llegada_Hasta.MonthCalendar.DisplayMonth = New Date(2016, 7, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Llegada_Hasta.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Llegada_Hasta.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Llegada_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Llegada_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Llegada_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Llegada_Hasta.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Llegada_Hasta.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Llegada_Hasta.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Llegada_Hasta.Name = "Dtp_Fecha_Llegada_Hasta"
        Me.Dtp_Fecha_Llegada_Hasta.Size = New System.Drawing.Size(80, 22)
        Me.Dtp_Fecha_Llegada_Hasta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Llegada_Hasta.TabIndex = 8
        Me.Dtp_Fecha_Llegada_Hasta.Value = New Date(2016, 7, 8, 16, 42, 49, 0)
        '
        'Lbl_FL_hasta
        '
        '
        '
        '
        Me.Lbl_FL_hasta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_FL_hasta.ForeColor = System.Drawing.Color.Black
        Me.Lbl_FL_hasta.Location = New System.Drawing.Point(365, 3)
        Me.Lbl_FL_hasta.Name = "Lbl_FL_hasta"
        Me.Lbl_FL_hasta.Size = New System.Drawing.Size(34, 19)
        Me.Lbl_FL_hasta.TabIndex = 9
        Me.Lbl_FL_hasta.Text = "Desde"
        '
        'Dtp_Fecha_Llegada_Desde
        '
        '
        '
        '
        Me.Dtp_Fecha_Llegada_Desde.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Llegada_Desde.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Llegada_Desde.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Llegada_Desde.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Llegada_Desde.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Llegada_Desde.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Llegada_Desde.Location = New System.Drawing.Point(278, 3)
        '
        '
        '
        Me.Dtp_Fecha_Llegada_Desde.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Llegada_Desde.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Llegada_Desde.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Llegada_Desde.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Llegada_Desde.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Llegada_Desde.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Llegada_Desde.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Llegada_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Llegada_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Llegada_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Llegada_Desde.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Llegada_Desde.MonthCalendar.DisplayMonth = New Date(2016, 7, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Llegada_Desde.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Llegada_Desde.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Llegada_Desde.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Llegada_Desde.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Llegada_Desde.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Llegada_Desde.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Llegada_Desde.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Llegada_Desde.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Llegada_Desde.Name = "Dtp_Fecha_Llegada_Desde"
        Me.Dtp_Fecha_Llegada_Desde.Size = New System.Drawing.Size(80, 22)
        Me.Dtp_Fecha_Llegada_Desde.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Llegada_Desde.TabIndex = 7
        Me.Dtp_Fecha_Llegada_Desde.Value = New Date(2016, 7, 8, 16, 42, 41, 0)
        '
        'LabelX9
        '
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.ForeColor = System.Drawing.Color.Black
        Me.LabelX9.Location = New System.Drawing.Point(3, 3)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(95, 19)
        Me.LabelX9.TabIndex = 4
        Me.LabelX9.Text = "Fecha de Llegada"
        '
        'Rdb_Fecha_Llegada_Rango
        '
        Me.Rdb_Fecha_Llegada_Rango.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Fecha_Llegada_Rango.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Fecha_Llegada_Rango.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Fecha_Llegada_Rango.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Fecha_Llegada_Rango.Location = New System.Drawing.Point(166, 3)
        Me.Rdb_Fecha_Llegada_Rango.Name = "Rdb_Fecha_Llegada_Rango"
        Me.Rdb_Fecha_Llegada_Rango.Size = New System.Drawing.Size(56, 19)
        Me.Rdb_Fecha_Llegada_Rango.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Fecha_Llegada_Rango.TabIndex = 3
        Me.Rdb_Fecha_Llegada_Rango.Text = "Rango"
        '
        'Rdb_Fecha_Llegada_Todas
        '
        Me.Rdb_Fecha_Llegada_Todas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Fecha_Llegada_Todas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Fecha_Llegada_Todas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Fecha_Llegada_Todas.Checked = True
        Me.Rdb_Fecha_Llegada_Todas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Fecha_Llegada_Todas.CheckValue = "Y"
        Me.Rdb_Fecha_Llegada_Todas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Fecha_Llegada_Todas.Location = New System.Drawing.Point(104, 3)
        Me.Rdb_Fecha_Llegada_Todas.Name = "Rdb_Fecha_Llegada_Todas"
        Me.Rdb_Fecha_Llegada_Todas.Size = New System.Drawing.Size(56, 19)
        Me.Rdb_Fecha_Llegada_Todas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Fecha_Llegada_Todas.TabIndex = 1
        Me.Rdb_Fecha_Llegada_Todas.Text = "Todas"
        '
        'Lbl_FL_desde
        '
        '
        '
        '
        Me.Lbl_FL_desde.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_FL_desde.ForeColor = System.Drawing.Color.Black
        Me.Lbl_FL_desde.Location = New System.Drawing.Point(228, 3)
        Me.Lbl_FL_desde.Name = "Lbl_FL_desde"
        Me.Lbl_FL_desde.Size = New System.Drawing.Size(37, 19)
        Me.Lbl_FL_desde.TabIndex = 7
        Me.Lbl_FL_desde.Text = "Desde"
        '
        'Grupo_OT
        '
        Me.Grupo_OT.BackColor = System.Drawing.Color.White
        Me.Grupo_OT.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_OT.Controls.Add(Me.TableLayoutPanel7)
        Me.Grupo_OT.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_OT.Location = New System.Drawing.Point(12, 6)
        Me.Grupo_OT.Name = "Grupo_OT"
        Me.Grupo_OT.Size = New System.Drawing.Size(503, 68)
        '
        '
        '
        Me.Grupo_OT.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_OT.Style.BackColorGradientAngle = 90
        Me.Grupo_OT.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_OT.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_OT.Style.BorderBottomWidth = 1
        Me.Grupo_OT.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_OT.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_OT.Style.BorderLeftWidth = 1
        Me.Grupo_OT.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_OT.Style.BorderRightWidth = 1
        Me.Grupo_OT.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_OT.Style.BorderTopWidth = 1
        Me.Grupo_OT.Style.CornerDiameter = 4
        Me.Grupo_OT.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_OT.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_OT.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_OT.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_OT.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_OT.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_OT.TabIndex = 86
        Me.Grupo_OT.Text = "Filtro por número de C.R.V."
        '
        'TableLayoutPanel7
        '
        Me.TableLayoutPanel7.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel7.ColumnCount = 4
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 162.0!))
        Me.TableLayoutPanel7.Controls.Add(Me.LabelX11, 0, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.Txt_Nro_CRV, 3, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.Rdb_CRV_Todas, 1, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.Rdb_CRV_Una, 2, 0)
        Me.TableLayoutPanel7.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel7.Location = New System.Drawing.Point(6, 12)
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        Me.TableLayoutPanel7.RowCount = 1
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel7.Size = New System.Drawing.Size(482, 28)
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
        Me.LabelX11.Size = New System.Drawing.Size(131, 19)
        Me.LabelX11.TabIndex = 4
        Me.LabelX11.Text = "Control Ruta Vehículo"
        '
        'Txt_Nro_CRV
        '
        Me.Txt_Nro_CRV.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Nro_CRV.Border.Class = "TextBoxBorder"
        Me.Txt_Nro_CRV.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Nro_CRV.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Nro_CRV.FocusHighlightEnabled = True
        Me.Txt_Nro_CRV.ForeColor = System.Drawing.Color.Black
        Me.Txt_Nro_CRV.Location = New System.Drawing.Point(323, 3)
        Me.Txt_Nro_CRV.MaxLength = 10
        Me.Txt_Nro_CRV.Name = "Txt_Nro_CRV"
        Me.Txt_Nro_CRV.PreventEnterBeep = True
        Me.Txt_Nro_CRV.Size = New System.Drawing.Size(156, 22)
        Me.Txt_Nro_CRV.TabIndex = 22
        Me.Txt_Nro_CRV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Rdb_CRV_Una
        '
        Me.Rdb_CRV_Una.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_CRV_Una.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_CRV_Una.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_CRV_Una.ForeColor = System.Drawing.Color.Black
        Me.Rdb_CRV_Una.Location = New System.Drawing.Point(270, 3)
        Me.Rdb_CRV_Una.Name = "Rdb_CRV_Una"
        Me.Rdb_CRV_Una.Size = New System.Drawing.Size(47, 19)
        Me.Rdb_CRV_Una.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_CRV_Una.TabIndex = 3
        Me.Rdb_CRV_Una.Text = "Una"
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel5.ColumnCount = 3
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 151.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.LabelX6, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Rdb_Estados_Algunos, 2, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Rdb_Estados_Todas, 1, 0)
        Me.TableLayoutPanel5.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(3, 99)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 1
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(485, 25)
        Me.TableLayoutPanel5.TabIndex = 5
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
        Me.LabelX6.TabIndex = 4
        Me.LabelX6.Text = "Estados"
        '
        'Rdb_Estados_Algunos
        '
        Me.Rdb_Estados_Algunos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Estados_Algunos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Estados_Algunos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Estados_Algunos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Estados_Algunos.Location = New System.Drawing.Point(377, 3)
        Me.Rdb_Estados_Algunos.Name = "Rdb_Estados_Algunos"
        Me.Rdb_Estados_Algunos.Size = New System.Drawing.Size(94, 19)
        Me.Rdb_Estados_Algunos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Estados_Algunos.TabIndex = 3
        Me.Rdb_Estados_Algunos.Text = "Algunos"
        '
        'Rdb_Estados_Todas
        '
        Me.Rdb_Estados_Todas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Estados_Todas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Estados_Todas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Estados_Todas.Checked = True
        Me.Rdb_Estados_Todas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Estados_Todas.CheckValue = "Y"
        Me.Rdb_Estados_Todas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Estados_Todas.Location = New System.Drawing.Point(226, 3)
        Me.Rdb_Estados_Todas.Name = "Rdb_Estados_Todas"
        Me.Rdb_Estados_Todas.Size = New System.Drawing.Size(85, 19)
        Me.Rdb_Estados_Todas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Estados_Todas.TabIndex = 1
        Me.Rdb_Estados_Todas.Text = "Todos"
        '
        'BtnxSalir
        '
        Me.BtnxSalir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnxSalir.ForeColor = System.Drawing.Color.Black
        Me.BtnxSalir.Image = CType(resources.GetObject("BtnxSalir.Image"), System.Drawing.Image)
        Me.BtnxSalir.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnxSalir.Name = "BtnxSalir"
        Me.BtnxSalir.Tooltip = "Salir"
        '
        'BtnFiltrar
        '
        Me.BtnFiltrar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnFiltrar.ForeColor = System.Drawing.Color.Black
        Me.BtnFiltrar.Image = CType(resources.GetObject("BtnFiltrar.Image"), System.Drawing.Image)
        Me.BtnFiltrar.Name = "BtnFiltrar"
        Me.BtnFiltrar.Text = "Aplicar filtro"
        '
        'Grupo_Entidad
        '
        Me.Grupo_Entidad.BackColor = System.Drawing.Color.White
        Me.Grupo_Entidad.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Entidad.Controls.Add(Me.Layout_Chofer)
        Me.Grupo_Entidad.Controls.Add(Me.Layout_Vehiculo)
        Me.Grupo_Entidad.Controls.Add(Me.TableLayoutPanel5)
        Me.Grupo_Entidad.Controls.Add(Me.TableLayoutPanel2)
        Me.Grupo_Entidad.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Entidad.Location = New System.Drawing.Point(12, 80)
        Me.Grupo_Entidad.Name = "Grupo_Entidad"
        Me.Grupo_Entidad.Size = New System.Drawing.Size(503, 156)
        '
        '
        '
        Me.Grupo_Entidad.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Entidad.Style.BackColorGradientAngle = 90
        Me.Grupo_Entidad.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Entidad.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Entidad.Style.BorderBottomWidth = 1
        Me.Grupo_Entidad.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Entidad.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Entidad.Style.BorderLeftWidth = 1
        Me.Grupo_Entidad.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Entidad.Style.BorderRightWidth = 1
        Me.Grupo_Entidad.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Entidad.Style.BorderTopWidth = 1
        Me.Grupo_Entidad.Style.CornerDiameter = 4
        Me.Grupo_Entidad.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Entidad.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Entidad.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Entidad.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Entidad.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Entidad.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Entidad.TabIndex = 85
        Me.Grupo_Entidad.Text = "Filtros Entidades, Técnicos y Estados"
        '
        'Layout_Chofer
        '
        Me.Layout_Chofer.BackColor = System.Drawing.Color.Transparent
        Me.Layout_Chofer.ColumnCount = 2
        Me.Layout_Chofer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Layout_Chofer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 262.0!))
        Me.Layout_Chofer.Controls.Add(Me.Cmb_Chofer, 0, 0)
        Me.Layout_Chofer.Controls.Add(Me.LabelX3, 0, 0)
        Me.Layout_Chofer.ForeColor = System.Drawing.Color.Black
        Me.Layout_Chofer.Location = New System.Drawing.Point(3, 40)
        Me.Layout_Chofer.Name = "Layout_Chofer"
        Me.Layout_Chofer.RowCount = 1
        Me.Layout_Chofer.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Layout_Chofer.Size = New System.Drawing.Size(485, 25)
        Me.Layout_Chofer.TabIndex = 28
        '
        'Cmb_Chofer
        '
        Me.Cmb_Chofer.DisplayMember = "Text"
        Me.Cmb_Chofer.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Chofer.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Chofer.FormattingEnabled = True
        Me.Cmb_Chofer.ItemHeight = 16
        Me.Cmb_Chofer.Location = New System.Drawing.Point(226, 3)
        Me.Cmb_Chofer.Name = "Cmb_Chofer"
        Me.Cmb_Chofer.Size = New System.Drawing.Size(256, 22)
        Me.Cmb_Chofer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Chofer.TabIndex = 104
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(3, 3)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(87, 19)
        Me.LabelX3.TabIndex = 4
        Me.LabelX3.Text = "Chofer"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 151.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.LabelX1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Rdb_Entidades_Algunas, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Rdb_Entidades_Todas, 1, 0)
        Me.TableLayoutPanel2.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 9)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(485, 25)
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
        Me.Rdb_Entidades_Algunas.Location = New System.Drawing.Point(377, 3)
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
        Me.Rdb_Entidades_Todas.Location = New System.Drawing.Point(226, 3)
        Me.Rdb_Entidades_Todas.Name = "Rdb_Entidades_Todas"
        Me.Rdb_Entidades_Todas.Size = New System.Drawing.Size(85, 19)
        Me.Rdb_Entidades_Todas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Entidades_Todas.TabIndex = 1
        Me.Rdb_Entidades_Todas.Text = "Todos"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnFiltrar, Me.BtnxSalir})
        Me.Bar1.Location = New System.Drawing.Point(0, 362)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(519, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 84
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Frm_CRV_Filtrar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(519, 403)
        Me.ControlBox = False
        Me.Controls.Add(Me.Grupo_Fechas)
        Me.Controls.Add(Me.Grupo_OT)
        Me.Controls.Add(Me.Grupo_Entidad)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_CRV_Filtrar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Filtrar Control Ruta Vehículo"
        CType(Me.Dtp_Fecha_Salida_Hasta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_Fecha_Salida_Desde, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Layout_Vehiculo.ResumeLayout(False)
        Me.Grupo_Fechas.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel6.ResumeLayout(False)
        CType(Me.Dtp_Fecha_Llegada_Hasta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_Fecha_Llegada_Desde, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo_OT.ResumeLayout(False)
        Me.TableLayoutPanel7.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.Grupo_Entidad.ResumeLayout(False)
        Me.Layout_Chofer.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Rdb_CRV_Todas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Dtp_Fecha_Salida_Hasta As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Dtp_Fecha_Salida_Desde As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Layout_Vehiculo As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Imagenes_32x32 As System.Windows.Forms.ImageList
    Friend WithEvents Grupo_Fechas As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Lbl_FS_hasta As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_Fecha_Salida_Rango As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Fecha_Salida_Todas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Lbl_FS_desde As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Dtp_Fecha_Llegada_Hasta As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Lbl_FL_hasta As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dtp_Fecha_Llegada_Desde As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_Fecha_Llegada_Rango As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Fecha_Llegada_Todas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Lbl_FL_desde As DevComponents.DotNetBar.LabelX
    Friend WithEvents Grupo_OT As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel7 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Nro_CRV As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Rdb_CRV_Una As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_Estados_Algunos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Estados_Todas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents BtnxSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnFiltrar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grupo_Entidad As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_Entidades_Algunas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Entidades_Todas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Layout_Chofer As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Cmb_Chofer As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Cmb_Nuevo_Vehiculo As DevComponents.DotNetBar.Controls.ComboBoxEx
End Class
