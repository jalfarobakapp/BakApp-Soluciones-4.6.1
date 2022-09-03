<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Buscar_Orden_Despacho
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Buscar_Orden_Despacho))
        Me.TableLayoutPanel14 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_Productos_Algunos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Productos_Todos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TableLayoutPanel11 = New System.Windows.Forms.TableLayoutPanel()
        Me.Txt_Nro_Encomienda = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.Grupo_Fechas = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Dtp_Fecha_Emision_Hasta = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Lbl_FE_hasta = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_Fecha_Emision_Desde = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Rdb_Fecha_Emision_Rango = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Fecha_Emision_Todas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Lbl_FE_desde = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.Dtp_Fecha_Cierre_Hasta = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Lbl_FC_hasta = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_Fecha_Cierre_Desde = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_Fecha_Cierre_Rango = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Fecha_Cierre_Todas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Lbl_FC_desde = New DevComponents.DotNetBar.LabelX()
        Me.Grupo_OT = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Nro_OD = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Rdb_Orden_de_despacho_Todas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Orden_de_despacho_Una = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Grupo_Filtros = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Btn_Quitar_Filtro_Documento = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Buscar_documento = New DevComponents.DotNetBar.ButtonX()
        Me.TableLayoutPanel10 = New System.Windows.Forms.TableLayoutPanel()
        Me.Txt_Documento = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.TableLayoutPanel9 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_Sucursal_Algunas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Sucursal_Todas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TableLayoutPanel8 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_Transporte_Algunos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Transporte_Todos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_Estados_Algunos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Estados_Todas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_Tipo_de_venta_Algunos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Tipo_de_venta_Todos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_Tipo_de_envio_Algunos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Tipo_de_envio_Todos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_Entidades_Algunas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Entidades_Todas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.BtnFiltrar = New DevComponents.DotNetBar.ButtonItem()
        Me.TableLayoutPanel14.SuspendLayout()
        Me.TableLayoutPanel11.SuspendLayout()
        Me.Grupo_Fechas.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.Dtp_Fecha_Emision_Hasta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_Fecha_Emision_Desde, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel6.SuspendLayout()
        CType(Me.Dtp_Fecha_Cierre_Hasta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_Fecha_Cierre_Desde, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_OT.SuspendLayout()
        Me.TableLayoutPanel7.SuspendLayout()
        Me.Grupo_Filtros.SuspendLayout()
        Me.TableLayoutPanel10.SuspendLayout()
        Me.TableLayoutPanel9.SuspendLayout()
        Me.TableLayoutPanel8.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel14
        '
        Me.TableLayoutPanel14.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel14.ColumnCount = 3
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91.0!))
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111.0!))
        Me.TableLayoutPanel14.Controls.Add(Me.LabelX13, 0, 0)
        Me.TableLayoutPanel14.Controls.Add(Me.Rdb_Productos_Algunos, 2, 0)
        Me.TableLayoutPanel14.Controls.Add(Me.Rdb_Productos_Todos, 1, 0)
        Me.TableLayoutPanel14.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel14.Location = New System.Drawing.Point(6, 157)
        Me.TableLayoutPanel14.Name = "TableLayoutPanel14"
        Me.TableLayoutPanel14.RowCount = 1
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel14.Size = New System.Drawing.Size(339, 25)
        Me.TableLayoutPanel14.TabIndex = 79
        '
        'LabelX13
        '
        '
        '
        '
        Me.LabelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX13.ForeColor = System.Drawing.Color.Black
        Me.LabelX13.Location = New System.Drawing.Point(3, 3)
        Me.LabelX13.Name = "LabelX13"
        Me.LabelX13.Size = New System.Drawing.Size(131, 19)
        Me.LabelX13.TabIndex = 4
        Me.LabelX13.Text = "Productos"
        '
        'Rdb_Productos_Algunos
        '
        Me.Rdb_Productos_Algunos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Productos_Algunos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Productos_Algunos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Productos_Algunos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Productos_Algunos.Location = New System.Drawing.Point(231, 3)
        Me.Rdb_Productos_Algunos.Name = "Rdb_Productos_Algunos"
        Me.Rdb_Productos_Algunos.Size = New System.Drawing.Size(94, 19)
        Me.Rdb_Productos_Algunos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Productos_Algunos.TabIndex = 3
        Me.Rdb_Productos_Algunos.Text = "Algunos"
        '
        'Rdb_Productos_Todos
        '
        Me.Rdb_Productos_Todos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Productos_Todos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Productos_Todos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Productos_Todos.Checked = True
        Me.Rdb_Productos_Todos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Productos_Todos.CheckValue = "Y"
        Me.Rdb_Productos_Todos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Productos_Todos.Location = New System.Drawing.Point(140, 3)
        Me.Rdb_Productos_Todos.Name = "Rdb_Productos_Todos"
        Me.Rdb_Productos_Todos.Size = New System.Drawing.Size(85, 19)
        Me.Rdb_Productos_Todos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Productos_Todos.TabIndex = 1
        Me.Rdb_Productos_Todos.Text = "Todos"
        '
        'TableLayoutPanel11
        '
        Me.TableLayoutPanel11.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel11.ColumnCount = 2
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 238.0!))
        Me.TableLayoutPanel11.Controls.Add(Me.Txt_Nro_Encomienda, 1, 0)
        Me.TableLayoutPanel11.Controls.Add(Me.LabelX10, 0, 0)
        Me.TableLayoutPanel11.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel11.Location = New System.Drawing.Point(6, 259)
        Me.TableLayoutPanel11.Name = "TableLayoutPanel11"
        Me.TableLayoutPanel11.RowCount = 1
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel11.Size = New System.Drawing.Size(339, 30)
        Me.TableLayoutPanel11.TabIndex = 27
        '
        'Txt_Nro_Encomienda
        '
        Me.Txt_Nro_Encomienda.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Nro_Encomienda.Border.Class = "TextBoxBorder"
        Me.Txt_Nro_Encomienda.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Nro_Encomienda.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Nro_Encomienda.FocusHighlightEnabled = True
        Me.Txt_Nro_Encomienda.ForeColor = System.Drawing.Color.Black
        Me.Txt_Nro_Encomienda.Location = New System.Drawing.Point(104, 3)
        Me.Txt_Nro_Encomienda.MaxLength = 25
        Me.Txt_Nro_Encomienda.Name = "Txt_Nro_Encomienda"
        Me.Txt_Nro_Encomienda.PreventEnterBeep = True
        Me.Txt_Nro_Encomienda.Size = New System.Drawing.Size(232, 22)
        Me.Txt_Nro_Encomienda.TabIndex = 28
        Me.Txt_Nro_Encomienda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Txt_Nro_Encomienda.WatermarkText = "Ninguna, no aplica filtro"
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
        Me.LabelX10.Size = New System.Drawing.Size(95, 19)
        Me.LabelX10.TabIndex = 4
        Me.LabelX10.Text = "N° de encomienda"
        '
        'Grupo_Fechas
        '
        Me.Grupo_Fechas.BackColor = System.Drawing.Color.White
        Me.Grupo_Fechas.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Fechas.Controls.Add(Me.TableLayoutPanel1)
        Me.Grupo_Fechas.Controls.Add(Me.TableLayoutPanel6)
        Me.Grupo_Fechas.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Fechas.Location = New System.Drawing.Point(12, 415)
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
        Me.TableLayoutPanel1.Controls.Add(Me.Dtp_Fecha_Emision_Hasta, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_FE_hasta, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Dtp_Fecha_Emision_Desde, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_Fecha_Emision_Rango, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_Fecha_Emision_Todas, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_FE_desde, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX4, 0, 0)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 13)
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
        Me.Dtp_Fecha_Emision_Hasta.Enabled = False
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
        Me.Lbl_FE_hasta.Enabled = False
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
        Me.Dtp_Fecha_Emision_Desde.Enabled = False
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
        Me.Rdb_Fecha_Emision_Rango.Size = New System.Drawing.Size(58, 19)
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
        Me.Lbl_FE_desde.Enabled = False
        Me.Lbl_FE_desde.ForeColor = System.Drawing.Color.Black
        Me.Lbl_FE_desde.Location = New System.Drawing.Point(230, 3)
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
        Me.LabelX4.Text = "Fecha de emisión"
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel6.ColumnCount = 7
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 164.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.Dtp_Fecha_Cierre_Hasta, 6, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.Lbl_FC_hasta, 5, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.Dtp_Fecha_Cierre_Desde, 4, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.LabelX9, 0, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.Rdb_Fecha_Cierre_Rango, 2, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.Rdb_Fecha_Cierre_Todas, 1, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.Lbl_FC_desde, 3, 0)
        Me.TableLayoutPanel6.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(3, 44)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 1
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(566, 25)
        Me.TableLayoutPanel6.TabIndex = 7
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
        Me.Dtp_Fecha_Cierre_Hasta.Enabled = False
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
        Me.Lbl_FC_hasta.Enabled = False
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
        Me.Dtp_Fecha_Cierre_Desde.Enabled = False
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
        Me.LabelX9.Text = "Fecha de cierre"
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
        Me.Lbl_FC_desde.Enabled = False
        Me.Lbl_FC_desde.ForeColor = System.Drawing.Color.Black
        Me.Lbl_FC_desde.Location = New System.Drawing.Point(230, 3)
        Me.Lbl_FC_desde.Name = "Lbl_FC_desde"
        Me.Lbl_FC_desde.Size = New System.Drawing.Size(37, 19)
        Me.Lbl_FC_desde.TabIndex = 7
        Me.Lbl_FC_desde.Text = "Desde"
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
        Me.Grupo_OT.Text = "Filtro por número de OT"
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
        Me.TableLayoutPanel7.Controls.Add(Me.Txt_Nro_OD, 3, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.Rdb_Orden_de_despacho_Todas, 1, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.Rdb_Orden_de_despacho_Una, 2, 0)
        Me.TableLayoutPanel7.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel7.Location = New System.Drawing.Point(6, 12)
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        Me.TableLayoutPanel7.RowCount = 1
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel7.Size = New System.Drawing.Size(444, 28)
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
        Me.LabelX11.Text = "Ordenes de despacho"
        '
        'Txt_Nro_OD
        '
        Me.Txt_Nro_OD.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Nro_OD.Border.Class = "TextBoxBorder"
        Me.Txt_Nro_OD.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Nro_OD.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Nro_OD.FocusHighlightEnabled = True
        Me.Txt_Nro_OD.ForeColor = System.Drawing.Color.Black
        Me.Txt_Nro_OD.Location = New System.Drawing.Point(285, 3)
        Me.Txt_Nro_OD.MaxLength = 10
        Me.Txt_Nro_OD.Name = "Txt_Nro_OD"
        Me.Txt_Nro_OD.PreventEnterBeep = True
        Me.Txt_Nro_OD.Size = New System.Drawing.Size(100, 22)
        Me.Txt_Nro_OD.TabIndex = 22
        Me.Txt_Nro_OD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Rdb_Orden_de_despacho_Todas
        '
        Me.Rdb_Orden_de_despacho_Todas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Orden_de_despacho_Todas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Orden_de_despacho_Todas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Orden_de_despacho_Todas.Checked = True
        Me.Rdb_Orden_de_despacho_Todas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Orden_de_despacho_Todas.CheckValue = "Y"
        Me.Rdb_Orden_de_despacho_Todas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Orden_de_despacho_Todas.Location = New System.Drawing.Point(140, 3)
        Me.Rdb_Orden_de_despacho_Todas.Name = "Rdb_Orden_de_despacho_Todas"
        Me.Rdb_Orden_de_despacho_Todas.Size = New System.Drawing.Size(85, 19)
        Me.Rdb_Orden_de_despacho_Todas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Orden_de_despacho_Todas.TabIndex = 1
        Me.Rdb_Orden_de_despacho_Todas.Text = "Todos"
        '
        'Rdb_Orden_de_despacho_Una
        '
        Me.Rdb_Orden_de_despacho_Una.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Orden_de_despacho_Una.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Orden_de_despacho_Una.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Orden_de_despacho_Una.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Orden_de_despacho_Una.Location = New System.Drawing.Point(232, 3)
        Me.Rdb_Orden_de_despacho_Una.Name = "Rdb_Orden_de_despacho_Una"
        Me.Rdb_Orden_de_despacho_Una.Size = New System.Drawing.Size(47, 19)
        Me.Rdb_Orden_de_despacho_Una.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Orden_de_despacho_Una.TabIndex = 3
        Me.Rdb_Orden_de_despacho_Una.Text = "Una"
        '
        'Grupo_Filtros
        '
        Me.Grupo_Filtros.BackColor = System.Drawing.Color.White
        Me.Grupo_Filtros.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Filtros.Controls.Add(Me.Btn_Quitar_Filtro_Documento)
        Me.Grupo_Filtros.Controls.Add(Me.Btn_Buscar_documento)
        Me.Grupo_Filtros.Controls.Add(Me.TableLayoutPanel10)
        Me.Grupo_Filtros.Controls.Add(Me.TableLayoutPanel9)
        Me.Grupo_Filtros.Controls.Add(Me.TableLayoutPanel8)
        Me.Grupo_Filtros.Controls.Add(Me.TableLayoutPanel14)
        Me.Grupo_Filtros.Controls.Add(Me.TableLayoutPanel5)
        Me.Grupo_Filtros.Controls.Add(Me.TableLayoutPanel4)
        Me.Grupo_Filtros.Controls.Add(Me.TableLayoutPanel3)
        Me.Grupo_Filtros.Controls.Add(Me.TableLayoutPanel2)
        Me.Grupo_Filtros.Controls.Add(Me.TableLayoutPanel11)
        Me.Grupo_Filtros.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Filtros.Location = New System.Drawing.Point(12, 80)
        Me.Grupo_Filtros.Name = "Grupo_Filtros"
        Me.Grupo_Filtros.Size = New System.Drawing.Size(503, 329)
        '
        '
        '
        Me.Grupo_Filtros.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Filtros.Style.BackColorGradientAngle = 90
        Me.Grupo_Filtros.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Filtros.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Filtros.Style.BorderBottomWidth = 1
        Me.Grupo_Filtros.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Filtros.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Filtros.Style.BorderLeftWidth = 1
        Me.Grupo_Filtros.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Filtros.Style.BorderRightWidth = 1
        Me.Grupo_Filtros.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Filtros.Style.BorderTopWidth = 1
        Me.Grupo_Filtros.Style.CornerDiameter = 4
        Me.Grupo_Filtros.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Filtros.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Filtros.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Filtros.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Filtros.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Filtros.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Filtros.TabIndex = 85
        Me.Grupo_Filtros.Text = "Filtros Entidades, Técnicos y Estados"
        '
        'Btn_Quitar_Filtro_Documento
        '
        Me.Btn_Quitar_Filtro_Documento.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Quitar_Filtro_Documento.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Quitar_Filtro_Documento.Enabled = False
        Me.Btn_Quitar_Filtro_Documento.Image = CType(resources.GetObject("Btn_Quitar_Filtro_Documento.Image"), System.Drawing.Image)
        Me.Btn_Quitar_Filtro_Documento.Location = New System.Drawing.Point(387, 222)
        Me.Btn_Quitar_Filtro_Documento.Name = "Btn_Quitar_Filtro_Documento"
        Me.Btn_Quitar_Filtro_Documento.Size = New System.Drawing.Size(27, 23)
        Me.Btn_Quitar_Filtro_Documento.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Quitar_Filtro_Documento.TabIndex = 84
        Me.Btn_Quitar_Filtro_Documento.Tooltip = "Quitar filtro por documento"
        '
        'Btn_Buscar_documento
        '
        Me.Btn_Buscar_documento.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Buscar_documento.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Buscar_documento.Image = CType(resources.GetObject("Btn_Buscar_documento.Image"), System.Drawing.Image)
        Me.Btn_Buscar_documento.Location = New System.Drawing.Point(348, 222)
        Me.Btn_Buscar_documento.Name = "Btn_Buscar_documento"
        Me.Btn_Buscar_documento.Size = New System.Drawing.Size(33, 23)
        Me.Btn_Buscar_documento.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Buscar_documento.TabIndex = 83
        '
        'TableLayoutPanel10
        '
        Me.TableLayoutPanel10.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel10.ColumnCount = 2
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 238.0!))
        Me.TableLayoutPanel10.Controls.Add(Me.Txt_Documento, 1, 0)
        Me.TableLayoutPanel10.Controls.Add(Me.LabelX8, 0, 0)
        Me.TableLayoutPanel10.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel10.Location = New System.Drawing.Point(6, 219)
        Me.TableLayoutPanel10.Name = "TableLayoutPanel10"
        Me.TableLayoutPanel10.RowCount = 1
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel10.Size = New System.Drawing.Size(339, 30)
        Me.TableLayoutPanel10.TabIndex = 82
        '
        'Txt_Documento
        '
        Me.Txt_Documento.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Documento.Border.Class = "TextBoxBorder"
        Me.Txt_Documento.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Documento.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Documento.FocusHighlightEnabled = True
        Me.Txt_Documento.ForeColor = System.Drawing.Color.Black
        Me.Txt_Documento.Location = New System.Drawing.Point(104, 3)
        Me.Txt_Documento.MaxLength = 10
        Me.Txt_Documento.Name = "Txt_Documento"
        Me.Txt_Documento.PreventEnterBeep = True
        Me.Txt_Documento.ReadOnly = True
        Me.Txt_Documento.Size = New System.Drawing.Size(232, 22)
        Me.Txt_Documento.TabIndex = 28
        Me.Txt_Documento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Txt_Documento.WatermarkText = "Ninguna, no aplica filtro"
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
        Me.LabelX8.Size = New System.Drawing.Size(87, 19)
        Me.LabelX8.TabIndex = 4
        Me.LabelX8.Text = "Documento"
        '
        'TableLayoutPanel9
        '
        Me.TableLayoutPanel9.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel9.ColumnCount = 3
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91.0!))
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111.0!))
        Me.TableLayoutPanel9.Controls.Add(Me.LabelX7, 0, 0)
        Me.TableLayoutPanel9.Controls.Add(Me.Rdb_Sucursal_Algunas, 2, 0)
        Me.TableLayoutPanel9.Controls.Add(Me.Rdb_Sucursal_Todas, 1, 0)
        Me.TableLayoutPanel9.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel9.Location = New System.Drawing.Point(6, 8)
        Me.TableLayoutPanel9.Name = "TableLayoutPanel9"
        Me.TableLayoutPanel9.RowCount = 1
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel9.Size = New System.Drawing.Size(339, 25)
        Me.TableLayoutPanel9.TabIndex = 81
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
        Me.LabelX7.Size = New System.Drawing.Size(131, 19)
        Me.LabelX7.TabIndex = 4
        Me.LabelX7.Text = "Sucursal"
        '
        'Rdb_Sucursal_Algunas
        '
        Me.Rdb_Sucursal_Algunas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Sucursal_Algunas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Sucursal_Algunas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Sucursal_Algunas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Sucursal_Algunas.Location = New System.Drawing.Point(231, 3)
        Me.Rdb_Sucursal_Algunas.Name = "Rdb_Sucursal_Algunas"
        Me.Rdb_Sucursal_Algunas.Size = New System.Drawing.Size(94, 19)
        Me.Rdb_Sucursal_Algunas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Sucursal_Algunas.TabIndex = 3
        Me.Rdb_Sucursal_Algunas.Text = "Algunos"
        '
        'Rdb_Sucursal_Todas
        '
        Me.Rdb_Sucursal_Todas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Sucursal_Todas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Sucursal_Todas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Sucursal_Todas.Checked = True
        Me.Rdb_Sucursal_Todas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Sucursal_Todas.CheckValue = "Y"
        Me.Rdb_Sucursal_Todas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Sucursal_Todas.Location = New System.Drawing.Point(140, 3)
        Me.Rdb_Sucursal_Todas.Name = "Rdb_Sucursal_Todas"
        Me.Rdb_Sucursal_Todas.Size = New System.Drawing.Size(85, 19)
        Me.Rdb_Sucursal_Todas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Sucursal_Todas.TabIndex = 1
        Me.Rdb_Sucursal_Todas.Text = "Todos"
        '
        'TableLayoutPanel8
        '
        Me.TableLayoutPanel8.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel8.ColumnCount = 3
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91.0!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111.0!))
        Me.TableLayoutPanel8.Controls.Add(Me.LabelX5, 0, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.Rdb_Transporte_Algunos, 2, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.Rdb_Transporte_Todos, 1, 0)
        Me.TableLayoutPanel8.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel8.Location = New System.Drawing.Point(6, 188)
        Me.TableLayoutPanel8.Name = "TableLayoutPanel8"
        Me.TableLayoutPanel8.RowCount = 1
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel8.Size = New System.Drawing.Size(339, 25)
        Me.TableLayoutPanel8.TabIndex = 80
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(3, 3)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(131, 19)
        Me.LabelX5.TabIndex = 4
        Me.LabelX5.Text = "Transporte"
        '
        'Rdb_Transporte_Algunos
        '
        Me.Rdb_Transporte_Algunos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Transporte_Algunos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Transporte_Algunos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Transporte_Algunos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Transporte_Algunos.Location = New System.Drawing.Point(231, 3)
        Me.Rdb_Transporte_Algunos.Name = "Rdb_Transporte_Algunos"
        Me.Rdb_Transporte_Algunos.Size = New System.Drawing.Size(94, 19)
        Me.Rdb_Transporte_Algunos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Transporte_Algunos.TabIndex = 3
        Me.Rdb_Transporte_Algunos.Text = "Algunos"
        '
        'Rdb_Transporte_Todos
        '
        Me.Rdb_Transporte_Todos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Transporte_Todos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Transporte_Todos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Transporte_Todos.Checked = True
        Me.Rdb_Transporte_Todos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Transporte_Todos.CheckValue = "Y"
        Me.Rdb_Transporte_Todos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Transporte_Todos.Location = New System.Drawing.Point(140, 3)
        Me.Rdb_Transporte_Todos.Name = "Rdb_Transporte_Todos"
        Me.Rdb_Transporte_Todos.Size = New System.Drawing.Size(85, 19)
        Me.Rdb_Transporte_Todos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Transporte_Todos.TabIndex = 1
        Me.Rdb_Transporte_Todos.Text = "Todos"
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel5.ColumnCount = 3
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.LabelX6, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Rdb_Estados_Algunos, 2, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Rdb_Estados_Todas, 1, 0)
        Me.TableLayoutPanel5.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(6, 126)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 1
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(339, 25)
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
        Me.Rdb_Estados_Algunos.Location = New System.Drawing.Point(231, 3)
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
        Me.Rdb_Estados_Todas.Location = New System.Drawing.Point(140, 3)
        Me.Rdb_Estados_Todas.Name = "Rdb_Estados_Todas"
        Me.Rdb_Estados_Todas.Size = New System.Drawing.Size(85, 19)
        Me.Rdb_Estados_Todas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Estados_Todas.TabIndex = 1
        Me.Rdb_Estados_Todas.Text = "Todos"
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel4.ColumnCount = 3
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.LabelX3, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Rdb_Tipo_de_venta_Algunos, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Rdb_Tipo_de_venta_Todos, 1, 0)
        Me.TableLayoutPanel4.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(6, 95)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(339, 25)
        Me.TableLayoutPanel4.TabIndex = 4
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
        Me.LabelX3.Size = New System.Drawing.Size(131, 19)
        Me.LabelX3.TabIndex = 4
        Me.LabelX3.Text = "Tipo de venta"
        '
        'Rdb_Tipo_de_venta_Algunos
        '
        Me.Rdb_Tipo_de_venta_Algunos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Tipo_de_venta_Algunos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Tipo_de_venta_Algunos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Tipo_de_venta_Algunos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Tipo_de_venta_Algunos.Location = New System.Drawing.Point(231, 3)
        Me.Rdb_Tipo_de_venta_Algunos.Name = "Rdb_Tipo_de_venta_Algunos"
        Me.Rdb_Tipo_de_venta_Algunos.Size = New System.Drawing.Size(94, 19)
        Me.Rdb_Tipo_de_venta_Algunos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Tipo_de_venta_Algunos.TabIndex = 3
        Me.Rdb_Tipo_de_venta_Algunos.Text = "Algunos"
        '
        'Rdb_Tipo_de_venta_Todos
        '
        Me.Rdb_Tipo_de_venta_Todos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Tipo_de_venta_Todos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Tipo_de_venta_Todos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Tipo_de_venta_Todos.Checked = True
        Me.Rdb_Tipo_de_venta_Todos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Tipo_de_venta_Todos.CheckValue = "Y"
        Me.Rdb_Tipo_de_venta_Todos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Tipo_de_venta_Todos.Location = New System.Drawing.Point(140, 3)
        Me.Rdb_Tipo_de_venta_Todos.Name = "Rdb_Tipo_de_venta_Todos"
        Me.Rdb_Tipo_de_venta_Todos.Size = New System.Drawing.Size(85, 19)
        Me.Rdb_Tipo_de_venta_Todos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Tipo_de_venta_Todos.TabIndex = 1
        Me.Rdb_Tipo_de_venta_Todos.Text = "Todos"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel3.ColumnCount = 3
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.LabelX2, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Rdb_Tipo_de_envio_Algunos, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Rdb_Tipo_de_envio_Todos, 1, 0)
        Me.TableLayoutPanel3.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(6, 67)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(339, 25)
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
        Me.LabelX2.Text = "Tipo de envio"
        '
        'Rdb_Tipo_de_envio_Algunos
        '
        Me.Rdb_Tipo_de_envio_Algunos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Tipo_de_envio_Algunos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Tipo_de_envio_Algunos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Tipo_de_envio_Algunos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Tipo_de_envio_Algunos.Location = New System.Drawing.Point(231, 3)
        Me.Rdb_Tipo_de_envio_Algunos.Name = "Rdb_Tipo_de_envio_Algunos"
        Me.Rdb_Tipo_de_envio_Algunos.Size = New System.Drawing.Size(94, 19)
        Me.Rdb_Tipo_de_envio_Algunos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Tipo_de_envio_Algunos.TabIndex = 3
        Me.Rdb_Tipo_de_envio_Algunos.Text = "Algunos"
        '
        'Rdb_Tipo_de_envio_Todos
        '
        Me.Rdb_Tipo_de_envio_Todos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Tipo_de_envio_Todos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Tipo_de_envio_Todos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Tipo_de_envio_Todos.Checked = True
        Me.Rdb_Tipo_de_envio_Todos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Tipo_de_envio_Todos.CheckValue = "Y"
        Me.Rdb_Tipo_de_envio_Todos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Tipo_de_envio_Todos.Location = New System.Drawing.Point(140, 3)
        Me.Rdb_Tipo_de_envio_Todos.Name = "Rdb_Tipo_de_envio_Todos"
        Me.Rdb_Tipo_de_envio_Todos.Size = New System.Drawing.Size(85, 19)
        Me.Rdb_Tipo_de_envio_Todos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Tipo_de_envio_Todos.TabIndex = 1
        Me.Rdb_Tipo_de_envio_Todos.Text = "Todas "
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
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(6, 39)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(339, 25)
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
        Me.Rdb_Entidades_Algunas.Location = New System.Drawing.Point(231, 3)
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
        Me.Rdb_Entidades_Todas.Location = New System.Drawing.Point(140, 3)
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
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnFiltrar})
        Me.Bar1.Location = New System.Drawing.Point(0, 521)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(528, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 84
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnFiltrar
        '
        Me.BtnFiltrar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnFiltrar.ForeColor = System.Drawing.Color.Black
        Me.BtnFiltrar.Image = CType(resources.GetObject("BtnFiltrar.Image"), System.Drawing.Image)
        Me.BtnFiltrar.Name = "BtnFiltrar"
        Me.BtnFiltrar.Text = "Aplicar filtro"
        '
        'Frm_Buscar_Orden_Despacho
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(528, 562)
        Me.Controls.Add(Me.Grupo_Fechas)
        Me.Controls.Add(Me.Grupo_OT)
        Me.Controls.Add(Me.Grupo_Filtros)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Buscar_Orden_Despacho"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BUSCADOR DE ORDENES DE DESPACHO"
        Me.TableLayoutPanel14.ResumeLayout(False)
        Me.TableLayoutPanel11.ResumeLayout(False)
        Me.Grupo_Fechas.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.Dtp_Fecha_Emision_Hasta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_Fecha_Emision_Desde, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel6.ResumeLayout(False)
        CType(Me.Dtp_Fecha_Cierre_Hasta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_Fecha_Cierre_Desde, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo_OT.ResumeLayout(False)
        Me.TableLayoutPanel7.ResumeLayout(False)
        Me.Grupo_Filtros.ResumeLayout(False)
        Me.TableLayoutPanel10.ResumeLayout(False)
        Me.TableLayoutPanel9.ResumeLayout(False)
        Me.TableLayoutPanel8.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel14 As TableLayoutPanel
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_Productos_Algunos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Productos_Todos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents TableLayoutPanel11 As TableLayoutPanel
    Friend WithEvents Txt_Nro_Encomienda As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Grupo_Fechas As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Dtp_Fecha_Emision_Hasta As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Lbl_FE_hasta As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dtp_Fecha_Emision_Desde As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Rdb_Fecha_Emision_Rango As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Fecha_Emision_Todas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Lbl_FE_desde As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TableLayoutPanel6 As TableLayoutPanel
    Friend WithEvents Dtp_Fecha_Cierre_Hasta As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Lbl_FC_hasta As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dtp_Fecha_Cierre_Desde As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_Fecha_Cierre_Rango As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Fecha_Cierre_Todas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Lbl_FC_desde As DevComponents.DotNetBar.LabelX
    Friend WithEvents Grupo_OT As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel7 As TableLayoutPanel
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Nro_OD As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Rdb_Orden_de_despacho_Todas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Orden_de_despacho_Una As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Grupo_Filtros As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel5 As TableLayoutPanel
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_Estados_Algunos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Estados_Todas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_Tipo_de_venta_Algunos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Tipo_de_venta_Todos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_Entidades_Algunas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Entidades_Todas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnFiltrar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_Tipo_de_envio_Algunos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Tipo_de_envio_Todos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents TableLayoutPanel8 As TableLayoutPanel
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_Transporte_Algunos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Transporte_Todos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents TableLayoutPanel9 As TableLayoutPanel
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_Sucursal_Algunas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Sucursal_Todas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Btn_Buscar_documento As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TableLayoutPanel10 As TableLayoutPanel
    Friend WithEvents Txt_Documento As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Quitar_Filtro_Documento As DevComponents.DotNetBar.ButtonX
End Class
