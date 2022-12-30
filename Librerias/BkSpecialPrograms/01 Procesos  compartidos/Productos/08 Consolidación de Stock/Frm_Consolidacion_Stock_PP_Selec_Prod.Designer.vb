<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Consolidacion_Stock_PP_Selec_Prod
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Consolidacion_Stock_PP_Selec_Prod))
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.Rdb_Productos_Todos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Productos_Con_Movimientos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Productos_Seleccionar = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Layout_Producto = New System.Windows.Forms.TableLayoutPanel()
        Me.Lbl_Desde = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_Fecha_Movimientos_Desde = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Lbl_Hasta = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_Fecha_Movimientos_Hasta = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Btn_Seleccionar_Productos = New DevComponents.DotNetBar.ButtonX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Aceptar = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.Layout_Producto.SuspendLayout()
        CType(Me.Dtp_Fecha_Movimientos_Desde, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_Fecha_Movimientos_Hasta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.TableLayoutPanel6)
        Me.GroupPanel1.Controls.Add(Me.Layout_Producto)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(14, 6)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(445, 117)
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
        Me.GroupPanel1.TabIndex = 53
        Me.GroupPanel1.Text = "Selección de productos"
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel6.ColumnCount = 1
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.Rdb_Productos_Todos, 0, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.Rdb_Productos_Con_Movimientos, 0, 1)
        Me.TableLayoutPanel6.Controls.Add(Me.Rdb_Productos_Seleccionar, 0, 2)
        Me.TableLayoutPanel6.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 3
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(134, 85)
        Me.TableLayoutPanel6.TabIndex = 50
        '
        'Rdb_Productos_Todos
        '
        '
        '
        '
        Me.Rdb_Productos_Todos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Productos_Todos.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Productos_Todos.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Productos_Todos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Productos_Todos.Checked = True
        Me.Rdb_Productos_Todos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Productos_Todos.CheckValue = "Y"
        Me.Rdb_Productos_Todos.FocusCuesEnabled = False
        Me.Rdb_Productos_Todos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Productos_Todos.Location = New System.Drawing.Point(3, 3)
        Me.Rdb_Productos_Todos.Name = "Rdb_Productos_Todos"
        Me.Rdb_Productos_Todos.Size = New System.Drawing.Size(92, 21)
        Me.Rdb_Productos_Todos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Productos_Todos.TabIndex = 53
        Me.Rdb_Productos_Todos.Text = "Todos"
        '
        'Rdb_Productos_Con_Movimientos
        '
        '
        '
        '
        Me.Rdb_Productos_Con_Movimientos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Productos_Con_Movimientos.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Productos_Con_Movimientos.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Productos_Con_Movimientos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Productos_Con_Movimientos.FocusCuesEnabled = False
        Me.Rdb_Productos_Con_Movimientos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Productos_Con_Movimientos.Location = New System.Drawing.Point(3, 31)
        Me.Rdb_Productos_Con_Movimientos.Name = "Rdb_Productos_Con_Movimientos"
        Me.Rdb_Productos_Con_Movimientos.Size = New System.Drawing.Size(128, 21)
        Me.Rdb_Productos_Con_Movimientos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Productos_Con_Movimientos.TabIndex = 55
        Me.Rdb_Productos_Con_Movimientos.Text = "Con movimientos"
        '
        'Rdb_Productos_Seleccionar
        '
        '
        '
        '
        Me.Rdb_Productos_Seleccionar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Productos_Seleccionar.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Productos_Seleccionar.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Productos_Seleccionar.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Productos_Seleccionar.FocusCuesEnabled = False
        Me.Rdb_Productos_Seleccionar.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Productos_Seleccionar.Location = New System.Drawing.Point(3, 59)
        Me.Rdb_Productos_Seleccionar.Name = "Rdb_Productos_Seleccionar"
        Me.Rdb_Productos_Seleccionar.Size = New System.Drawing.Size(128, 21)
        Me.Rdb_Productos_Seleccionar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Productos_Seleccionar.TabIndex = 56
        Me.Rdb_Productos_Seleccionar.Text = "Seleccionar productos"
        '
        'Layout_Producto
        '
        Me.Layout_Producto.BackColor = System.Drawing.Color.Transparent
        Me.Layout_Producto.ColumnCount = 4
        Me.Layout_Producto.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.77003!))
        Me.Layout_Producto.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.23693!))
        Me.Layout_Producto.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.24042!))
        Me.Layout_Producto.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.75261!))
        Me.Layout_Producto.Controls.Add(Me.Lbl_Desde, 0, 1)
        Me.Layout_Producto.Controls.Add(Me.Dtp_Fecha_Movimientos_Desde, 1, 1)
        Me.Layout_Producto.Controls.Add(Me.Lbl_Hasta, 2, 1)
        Me.Layout_Producto.Controls.Add(Me.Dtp_Fecha_Movimientos_Hasta, 3, 1)
        Me.Layout_Producto.Controls.Add(Me.Btn_Seleccionar_Productos, 1, 2)
        Me.Layout_Producto.ForeColor = System.Drawing.Color.Black
        Me.Layout_Producto.Location = New System.Drawing.Point(143, 3)
        Me.Layout_Producto.Name = "Layout_Producto"
        Me.Layout_Producto.RowCount = 3
        Me.Layout_Producto.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.Layout_Producto.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.Layout_Producto.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.Layout_Producto.Size = New System.Drawing.Size(289, 85)
        Me.Layout_Producto.TabIndex = 29
        '
        'Lbl_Desde
        '
        '
        '
        '
        Me.Lbl_Desde.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Desde.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Desde.Location = New System.Drawing.Point(3, 31)
        Me.Lbl_Desde.Name = "Lbl_Desde"
        Me.Lbl_Desde.Size = New System.Drawing.Size(45, 18)
        Me.Lbl_Desde.TabIndex = 115
        Me.Lbl_Desde.Text = "Desde"
        Me.Lbl_Desde.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Dtp_Fecha_Movimientos_Desde
        '
        '
        '
        '
        Me.Dtp_Fecha_Movimientos_Desde.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Movimientos_Desde.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Movimientos_Desde.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Movimientos_Desde.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Movimientos_Desde.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Movimientos_Desde.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Movimientos_Desde.Location = New System.Drawing.Point(54, 31)
        '
        '
        '
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.DisplayMonth = New Date(2018, 10, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Movimientos_Desde.Name = "Dtp_Fecha_Movimientos_Desde"
        Me.Dtp_Fecha_Movimientos_Desde.Size = New System.Drawing.Size(98, 22)
        Me.Dtp_Fecha_Movimientos_Desde.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Movimientos_Desde.TabIndex = 65
        Me.Dtp_Fecha_Movimientos_Desde.Value = New Date(2018, 10, 19, 11, 12, 43, 0)
        '
        'Lbl_Hasta
        '
        '
        '
        '
        Me.Lbl_Hasta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Hasta.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Hasta.Location = New System.Drawing.Point(158, 31)
        Me.Lbl_Hasta.Name = "Lbl_Hasta"
        Me.Lbl_Hasta.Size = New System.Drawing.Size(32, 18)
        Me.Lbl_Hasta.TabIndex = 116
        Me.Lbl_Hasta.Text = "Hasta"
        Me.Lbl_Hasta.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Dtp_Fecha_Movimientos_Hasta
        '
        '
        '
        '
        Me.Dtp_Fecha_Movimientos_Hasta.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Movimientos_Hasta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Movimientos_Hasta.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Movimientos_Hasta.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Movimientos_Hasta.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Movimientos_Hasta.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Movimientos_Hasta.Location = New System.Drawing.Point(196, 31)
        '
        '
        '
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.DisplayMonth = New Date(2018, 10, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Movimientos_Hasta.Name = "Dtp_Fecha_Movimientos_Hasta"
        Me.Dtp_Fecha_Movimientos_Hasta.Size = New System.Drawing.Size(90, 22)
        Me.Dtp_Fecha_Movimientos_Hasta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Movimientos_Hasta.TabIndex = 66
        Me.Dtp_Fecha_Movimientos_Hasta.Value = New Date(2018, 10, 19, 11, 12, 43, 0)
        '
        'Btn_Seleccionar_Productos
        '
        Me.Btn_Seleccionar_Productos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Seleccionar_Productos.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Seleccionar_Productos.Image = CType(resources.GetObject("Btn_Seleccionar_Productos.Image"), System.Drawing.Image)
        Me.Btn_Seleccionar_Productos.Location = New System.Drawing.Point(54, 59)
        Me.Btn_Seleccionar_Productos.Name = "Btn_Seleccionar_Productos"
        Me.Btn_Seleccionar_Productos.Size = New System.Drawing.Size(96, 21)
        Me.Btn_Seleccionar_Productos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Seleccionar_Productos.TabIndex = 13
        Me.Btn_Seleccionar_Productos.Text = "Buscar prod."
        Me.Btn_Seleccionar_Productos.Tooltip = "Buscar productos"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Aceptar})
        Me.Bar1.Location = New System.Drawing.Point(0, 129)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(473, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 51
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Aceptar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Aceptar.Image = CType(resources.GetObject("Btn_Aceptar.Image"), System.Drawing.Image)
        Me.Btn_Aceptar.ImageAlt = CType(resources.GetObject("Btn_Aceptar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Text = "Procesar informe"
        '
        'Frm_Consolidacion_Stock_PP_Selec_Prod
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(473, 170)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Consolidacion_Stock_PP_Selec_Prod"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleccion de productos consolidación de stock"
        Me.GroupPanel1.ResumeLayout(False)
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.Layout_Producto.ResumeLayout(False)
        CType(Me.Dtp_Fecha_Movimientos_Desde, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_Fecha_Movimientos_Hasta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Rdb_Productos_Todos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Productos_Seleccionar As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Productos_Con_Movimientos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Layout_Producto As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Lbl_Desde As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Hasta As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dtp_Fecha_Movimientos_Hasta As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Dtp_Fecha_Movimientos_Desde As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Btn_Seleccionar_Productos As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Aceptar As DevComponents.DotNetBar.ButtonItem
End Class
