<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_MantCostosPrecios_CreaLista
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_MantCostosPrecios_CreaLista))
        Me.GroupPanel11 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Lbl_Estado = New DevComponents.DotNetBar.LabelX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Proveedor = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_NombreLista = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_FechaVigenciaHasta = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_FechaVigenciaDesde = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Barrar_Menu = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Eliminar = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.Cmb_Lista = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.GroupPanel11.SuspendLayout()
        CType(Me.Dtp_FechaVigenciaHasta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_FechaVigenciaDesde, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Barrar_Menu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel11
        '
        Me.GroupPanel11.BackColor = System.Drawing.Color.White
        Me.GroupPanel11.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel11.Controls.Add(Me.Cmb_Lista)
        Me.GroupPanel11.Controls.Add(Me.LabelX6)
        Me.GroupPanel11.Controls.Add(Me.Lbl_Estado)
        Me.GroupPanel11.Controls.Add(Me.LabelX7)
        Me.GroupPanel11.Controls.Add(Me.Lbl_Proveedor)
        Me.GroupPanel11.Controls.Add(Me.LabelX5)
        Me.GroupPanel11.Controls.Add(Me.LabelX4)
        Me.GroupPanel11.Controls.Add(Me.Txt_NombreLista)
        Me.GroupPanel11.Controls.Add(Me.LabelX2)
        Me.GroupPanel11.Controls.Add(Me.Dtp_FechaVigenciaHasta)
        Me.GroupPanel11.Controls.Add(Me.LabelX3)
        Me.GroupPanel11.Controls.Add(Me.Dtp_FechaVigenciaDesde)
        Me.GroupPanel11.Controls.Add(Me.LabelX1)
        Me.GroupPanel11.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel11.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel11.Name = "GroupPanel11"
        Me.GroupPanel11.Size = New System.Drawing.Size(545, 180)
        '
        '
        '
        Me.GroupPanel11.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel11.Style.BackColorGradientAngle = 90
        Me.GroupPanel11.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel11.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel11.Style.BorderBottomWidth = 1
        Me.GroupPanel11.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel11.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel11.Style.BorderLeftWidth = 1
        Me.GroupPanel11.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel11.Style.BorderRightWidth = 1
        Me.GroupPanel11.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel11.Style.BorderTopWidth = 1
        Me.GroupPanel11.Style.CornerDiameter = 4
        Me.GroupPanel11.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel11.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel11.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel11.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel11.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel11.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel11.TabIndex = 82
        Me.GroupPanel11.Text = "Lista de costos"
        '
        'Lbl_Estado
        '
        Me.Lbl_Estado.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Estado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Estado.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Estado.Location = New System.Drawing.Point(84, 9)
        Me.Lbl_Estado.Name = "Lbl_Estado"
        Me.Lbl_Estado.Size = New System.Drawing.Size(442, 23)
        Me.Lbl_Estado.TabIndex = 23
        Me.Lbl_Estado.Text = "En construcción..."
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX7.ForeColor = System.Drawing.Color.Black
        Me.LabelX7.Location = New System.Drawing.Point(3, 9)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(75, 23)
        Me.LabelX7.TabIndex = 22
        Me.LabelX7.Text = "Estado"
        '
        'Lbl_Proveedor
        '
        Me.Lbl_Proveedor.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Proveedor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Proveedor.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Proveedor.Location = New System.Drawing.Point(84, 38)
        Me.Lbl_Proveedor.Name = "Lbl_Proveedor"
        Me.Lbl_Proveedor.Size = New System.Drawing.Size(452, 23)
        Me.Lbl_Proveedor.TabIndex = 21
        Me.Lbl_Proveedor.Text = "Nombre lista"
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(3, 38)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(75, 23)
        Me.LabelX5.TabIndex = 20
        Me.LabelX5.Text = "Proveedor"
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(2, 96)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(95, 23)
        Me.LabelX4.TabIndex = 19
        Me.LabelX4.Text = "Fecha de vigencia"
        '
        'Txt_NombreLista
        '
        Me.Txt_NombreLista.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_NombreLista.Border.Class = "TextBoxBorder"
        Me.Txt_NombreLista.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_NombreLista.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_NombreLista.ForeColor = System.Drawing.Color.Black
        Me.Txt_NombreLista.Location = New System.Drawing.Point(84, 67)
        Me.Txt_NombreLista.Name = "Txt_NombreLista"
        Me.Txt_NombreLista.PreventEnterBeep = True
        Me.Txt_NombreLista.Size = New System.Drawing.Size(452, 22)
        Me.Txt_NombreLista.TabIndex = 18
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 67)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(104, 23)
        Me.LabelX2.TabIndex = 17
        Me.LabelX2.Text = "Nombre lista"
        '
        'Dtp_FechaVigenciaHasta
        '
        Me.Dtp_FechaVigenciaHasta.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_FechaVigenciaHasta.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_FechaVigenciaHasta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaVigenciaHasta.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_FechaVigenciaHasta.ButtonDropDown.Visible = True
        Me.Dtp_FechaVigenciaHasta.ForeColor = System.Drawing.Color.Black
        Me.Dtp_FechaVigenciaHasta.IsPopupCalendarOpen = False
        Me.Dtp_FechaVigenciaHasta.Location = New System.Drawing.Point(357, 98)
        '
        '
        '
        Me.Dtp_FechaVigenciaHasta.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FechaVigenciaHasta.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaVigenciaHasta.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_FechaVigenciaHasta.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_FechaVigenciaHasta.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_FechaVigenciaHasta.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FechaVigenciaHasta.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_FechaVigenciaHasta.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_FechaVigenciaHasta.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_FechaVigenciaHasta.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_FechaVigenciaHasta.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaVigenciaHasta.MonthCalendar.DisplayMonth = New Date(2022, 6, 1, 0, 0, 0, 0)
        Me.Dtp_FechaVigenciaHasta.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_FechaVigenciaHasta.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_FechaVigenciaHasta.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FechaVigenciaHasta.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_FechaVigenciaHasta.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FechaVigenciaHasta.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_FechaVigenciaHasta.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaVigenciaHasta.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_FechaVigenciaHasta.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_FechaVigenciaHasta.Name = "Dtp_FechaVigenciaHasta"
        Me.Dtp_FechaVigenciaHasta.Size = New System.Drawing.Size(82, 22)
        Me.Dtp_FechaVigenciaHasta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_FechaVigenciaHasta.TabIndex = 15
        Me.Dtp_FechaVigenciaHasta.Value = New Date(2022, 6, 10, 16, 36, 30, 0)
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(305, 98)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(46, 23)
        Me.LabelX3.TabIndex = 16
        Me.LabelX3.Text = "Hasta"
        Me.LabelX3.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Dtp_FechaVigenciaDesde
        '
        Me.Dtp_FechaVigenciaDesde.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_FechaVigenciaDesde.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_FechaVigenciaDesde.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaVigenciaDesde.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_FechaVigenciaDesde.ButtonDropDown.Visible = True
        Me.Dtp_FechaVigenciaDesde.ForeColor = System.Drawing.Color.Black
        Me.Dtp_FechaVigenciaDesde.IsPopupCalendarOpen = False
        Me.Dtp_FechaVigenciaDesde.Location = New System.Drawing.Point(206, 98)
        '
        '
        '
        Me.Dtp_FechaVigenciaDesde.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FechaVigenciaDesde.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaVigenciaDesde.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_FechaVigenciaDesde.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_FechaVigenciaDesde.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_FechaVigenciaDesde.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FechaVigenciaDesde.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_FechaVigenciaDesde.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_FechaVigenciaDesde.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_FechaVigenciaDesde.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_FechaVigenciaDesde.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaVigenciaDesde.MonthCalendar.DisplayMonth = New Date(2022, 6, 1, 0, 0, 0, 0)
        Me.Dtp_FechaVigenciaDesde.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_FechaVigenciaDesde.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_FechaVigenciaDesde.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FechaVigenciaDesde.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_FechaVigenciaDesde.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FechaVigenciaDesde.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_FechaVigenciaDesde.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaVigenciaDesde.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_FechaVigenciaDesde.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_FechaVigenciaDesde.Name = "Dtp_FechaVigenciaDesde"
        Me.Dtp_FechaVigenciaDesde.Size = New System.Drawing.Size(82, 22)
        Me.Dtp_FechaVigenciaDesde.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_FechaVigenciaDesde.TabIndex = 0
        Me.Dtp_FechaVigenciaDesde.Value = New Date(2022, 6, 10, 16, 36, 30, 0)
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(153, 97)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(46, 23)
        Me.LabelX1.TabIndex = 14
        Me.LabelX1.Text = "Desde"
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Barrar_Menu
        '
        Me.Barrar_Menu.AntiAlias = True
        Me.Barrar_Menu.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Barrar_Menu.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Barrar_Menu.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar, Me.Btn_Eliminar})
        Me.Barrar_Menu.Location = New System.Drawing.Point(0, 202)
        Me.Barrar_Menu.Name = "Barrar_Menu"
        Me.Barrar_Menu.Size = New System.Drawing.Size(566, 41)
        Me.Barrar_Menu.Stretch = True
        Me.Barrar_Menu.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Barrar_Menu.TabIndex = 83
        Me.Barrar_Menu.TabStop = False
        Me.Barrar_Menu.Text = "Bar2"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.ImageAlt = CType(resources.GetObject("Btn_Grabar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Grabar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Tooltip = "Grabar"
        '
        'Btn_Eliminar
        '
        Me.Btn_Eliminar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Eliminar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Eliminar.Image = CType(resources.GetObject("Btn_Eliminar.Image"), System.Drawing.Image)
        Me.Btn_Eliminar.ImageAlt = CType(resources.GetObject("Btn_Eliminar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Eliminar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Eliminar.Name = "Btn_Eliminar"
        Me.Btn_Eliminar.Tooltip = "Grabar"
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(2, 125)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(198, 23)
        Me.LabelX6.TabIndex = 24
        Me.LabelX6.Text = "Lista de costos a utilizar en Random"
        '
        'Cmb_Lista
        '
        Me.Cmb_Lista.DisplayMember = "Text"
        Me.Cmb_Lista.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Lista.FormattingEnabled = True
        Me.Cmb_Lista.ItemHeight = 16
        Me.Cmb_Lista.Location = New System.Drawing.Point(206, 126)
        Me.Cmb_Lista.Name = "Cmb_Lista"
        Me.Cmb_Lista.Size = New System.Drawing.Size(235, 22)
        Me.Cmb_Lista.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Lista.TabIndex = 25
        '
        'Frm_MantCostosPrecios_CreaLista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(566, 243)
        Me.Controls.Add(Me.Barrar_Menu)
        Me.Controls.Add(Me.GroupPanel11)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_MantCostosPrecios_CreaLista"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MANTENCION DE LISTA DE PRECIOS POR PROVEEDOR"
        Me.GroupPanel11.ResumeLayout(False)
        CType(Me.Dtp_FechaVigenciaHasta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_FechaVigenciaDesde, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Barrar_Menu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupPanel11 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Dtp_FechaVigenciaHasta As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dtp_FechaVigenciaDesde As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_NombreLista As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Proveedor As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Estado As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Barrar_Menu As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Eliminar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Cmb_Lista As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
End Class
