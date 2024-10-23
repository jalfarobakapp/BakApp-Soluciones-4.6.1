<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_RevMayMin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_RevMayMin))
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Procesar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Cancelar = New DevComponents.DotNetBar.ButtonItem()
        Me.Circular_Progres_Val = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.Circular_Progres_Porc = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.Rdb_RevTodosClientes = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_RevVentasRangoFecha = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Grupo_01 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Lbl_Holding = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Cliente = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Rdb_Cliente = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Panel_Fechas = New System.Windows.Forms.Panel()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_Fecha_Vta_Desde = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Dtp_Fecha_Vta_Hasta = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Estado = New DevComponents.DotNetBar.LabelX()
        Me.TxtLog = New DevComponents.DotNetBar.Controls.TextBoxX()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_01.SuspendLayout()
        Me.Panel_Fechas.SuspendLayout()
        CType(Me.Dtp_Fecha_Vta_Desde, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_Fecha_Vta_Hasta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Procesar, Me.Btn_Cancelar})
        Me.Bar1.Location = New System.Drawing.Point(0, 298)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(781, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 81
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
        Me.Btn_Procesar.Text = "Procesar"
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Cancelar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Cancelar.Image = CType(resources.GetObject("Btn_Cancelar.Image"), System.Drawing.Image)
        Me.Btn_Cancelar.ImageAlt = CType(resources.GetObject("Btn_Cancelar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Text = "Cancelar"
        Me.Btn_Cancelar.Tooltip = "Eliminar Servidor de correo de salida SMTP"
        '
        'Circular_Progres_Val
        '
        Me.Circular_Progres_Val.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Circular_Progres_Val.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Circular_Progres_Val.FocusCuesEnabled = False
        Me.Circular_Progres_Val.Location = New System.Drawing.Point(3, 14)
        Me.Circular_Progres_Val.Name = "Circular_Progres_Val"
        Me.Circular_Progres_Val.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.Circular_Progres_Val.ProgressColor = System.Drawing.Color.SteelBlue
        Me.Circular_Progres_Val.ProgressTextFormat = "{0}"
        Me.Circular_Progres_Val.ProgressTextVisible = True
        Me.Circular_Progres_Val.Size = New System.Drawing.Size(54, 44)
        Me.Circular_Progres_Val.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.Circular_Progres_Val.TabIndex = 76
        '
        'Circular_Progres_Porc
        '
        Me.Circular_Progres_Porc.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Circular_Progres_Porc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Circular_Progres_Porc.FocusCuesEnabled = False
        Me.Circular_Progres_Porc.Location = New System.Drawing.Point(63, 14)
        Me.Circular_Progres_Porc.Name = "Circular_Progres_Porc"
        Me.Circular_Progres_Porc.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.Circular_Progres_Porc.ProgressColor = System.Drawing.Color.SteelBlue
        Me.Circular_Progres_Porc.ProgressTextVisible = True
        Me.Circular_Progres_Porc.Size = New System.Drawing.Size(49, 44)
        Me.Circular_Progres_Porc.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.Circular_Progres_Porc.TabIndex = 77
        '
        'Rdb_RevTodosClientes
        '
        Me.Rdb_RevTodosClientes.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_RevTodosClientes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_RevTodosClientes.CheckBoxImageChecked = CType(resources.GetObject("Rdb_RevTodosClientes.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_RevTodosClientes.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_RevTodosClientes.Checked = True
        Me.Rdb_RevTodosClientes.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_RevTodosClientes.CheckValue = "Y"
        Me.Rdb_RevTodosClientes.FocusCuesEnabled = False
        Me.Rdb_RevTodosClientes.ForeColor = System.Drawing.Color.Black
        Me.Rdb_RevTodosClientes.Location = New System.Drawing.Point(5, 147)
        Me.Rdb_RevTodosClientes.Name = "Rdb_RevTodosClientes"
        Me.Rdb_RevTodosClientes.Size = New System.Drawing.Size(147, 18)
        Me.Rdb_RevTodosClientes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_RevTodosClientes.TabIndex = 81
        Me.Rdb_RevTodosClientes.Text = "Revisar todos los clientes"
        '
        'Rdb_RevVentasRangoFecha
        '
        Me.Rdb_RevVentasRangoFecha.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_RevVentasRangoFecha.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_RevVentasRangoFecha.CheckBoxImageChecked = CType(resources.GetObject("Rdb_RevVentasRangoFecha.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_RevVentasRangoFecha.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_RevVentasRangoFecha.FocusCuesEnabled = False
        Me.Rdb_RevVentasRangoFecha.ForeColor = System.Drawing.Color.Black
        Me.Rdb_RevVentasRangoFecha.Location = New System.Drawing.Point(5, 171)
        Me.Rdb_RevVentasRangoFecha.Name = "Rdb_RevVentasRangoFecha"
        Me.Rdb_RevVentasRangoFecha.Size = New System.Drawing.Size(265, 18)
        Me.Rdb_RevVentasRangoFecha.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_RevVentasRangoFecha.TabIndex = 82
        Me.Rdb_RevVentasRangoFecha.Text = "Revisar clientes con ventas en un rango de fechas"
        '
        'Grupo_01
        '
        Me.Grupo_01.BackColor = System.Drawing.Color.White
        Me.Grupo_01.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_01.Controls.Add(Me.Lbl_Holding)
        Me.Grupo_01.Controls.Add(Me.Txt_Cliente)
        Me.Grupo_01.Controls.Add(Me.Rdb_Cliente)
        Me.Grupo_01.Controls.Add(Me.Panel_Fechas)
        Me.Grupo_01.Controls.Add(Me.Lbl_Estado)
        Me.Grupo_01.Controls.Add(Me.TxtLog)
        Me.Grupo_01.Controls.Add(Me.Rdb_RevVentasRangoFecha)
        Me.Grupo_01.Controls.Add(Me.Rdb_RevTodosClientes)
        Me.Grupo_01.Controls.Add(Me.Circular_Progres_Porc)
        Me.Grupo_01.Controls.Add(Me.Circular_Progres_Val)
        Me.Grupo_01.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_01.Location = New System.Drawing.Point(12, 12)
        Me.Grupo_01.Name = "Grupo_01"
        Me.Grupo_01.Size = New System.Drawing.Size(763, 269)
        '
        '
        '
        Me.Grupo_01.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_01.Style.BackColorGradientAngle = 90
        Me.Grupo_01.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_01.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_01.Style.BorderBottomWidth = 1
        Me.Grupo_01.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_01.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_01.Style.BorderLeftWidth = 1
        Me.Grupo_01.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_01.Style.BorderRightWidth = 1
        Me.Grupo_01.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_01.Style.BorderTopWidth = 1
        Me.Grupo_01.Style.CornerDiameter = 4
        Me.Grupo_01.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_01.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_01.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_01.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_01.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_01.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_01.TabIndex = 82
        Me.Grupo_01.Text = "Proceso"
        '
        'Lbl_Holding
        '
        Me.Lbl_Holding.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Holding.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Holding.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Holding.Location = New System.Drawing.Point(142, 220)
        Me.Lbl_Holding.Name = "Lbl_Holding"
        Me.Lbl_Holding.Size = New System.Drawing.Size(600, 23)
        Me.Lbl_Holding.TabIndex = 122
        Me.Lbl_Holding.Text = "Holding: No pertenece a ningún Holding."
        '
        'Txt_Cliente
        '
        Me.Txt_Cliente.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Cliente.Border.Class = "TextBoxBorder"
        Me.Txt_Cliente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Cliente.ButtonCustom.Image = CType(resources.GetObject("Txt_Cliente.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Cliente.ButtonCustom.Visible = True
        Me.Txt_Cliente.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Cliente.ForeColor = System.Drawing.Color.Black
        Me.Txt_Cliente.Location = New System.Drawing.Point(142, 195)
        Me.Txt_Cliente.Name = "Txt_Cliente"
        Me.Txt_Cliente.PreventEnterBeep = True
        Me.Txt_Cliente.ReadOnly = True
        Me.Txt_Cliente.Size = New System.Drawing.Size(600, 22)
        Me.Txt_Cliente.TabIndex = 121
        '
        'Rdb_Cliente
        '
        Me.Rdb_Cliente.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Cliente.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Cliente.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Cliente.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Cliente.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Cliente.FocusCuesEnabled = False
        Me.Rdb_Cliente.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Cliente.Location = New System.Drawing.Point(5, 195)
        Me.Rdb_Cliente.Name = "Rdb_Cliente"
        Me.Rdb_Cliente.Size = New System.Drawing.Size(131, 18)
        Me.Rdb_Cliente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Cliente.TabIndex = 120
        Me.Rdb_Cliente.Text = "Un cliente en particular"
        '
        'Panel_Fechas
        '
        Me.Panel_Fechas.BackColor = System.Drawing.Color.Transparent
        Me.Panel_Fechas.Controls.Add(Me.LabelX2)
        Me.Panel_Fechas.Controls.Add(Me.Dtp_Fecha_Vta_Desde)
        Me.Panel_Fechas.Controls.Add(Me.Dtp_Fecha_Vta_Hasta)
        Me.Panel_Fechas.Controls.Add(Me.LabelX1)
        Me.Panel_Fechas.Location = New System.Drawing.Point(276, 156)
        Me.Panel_Fechas.Name = "Panel_Fechas"
        Me.Panel_Fechas.Size = New System.Drawing.Size(280, 33)
        Me.Panel_Fechas.TabIndex = 119
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 12)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(47, 19)
        Me.LabelX2.TabIndex = 118
        Me.LabelX2.Text = "Desde"
        Me.LabelX2.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'Dtp_Fecha_Vta_Desde
        '
        Me.Dtp_Fecha_Vta_Desde.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_Fecha_Vta_Desde.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Vta_Desde.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Vta_Desde.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Vta_Desde.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Vta_Desde.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Vta_Desde.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Vta_Desde.Location = New System.Drawing.Point(57, 9)
        '
        '
        '
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.DisplayMonth = New Date(2018, 10, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Vta_Desde.Name = "Dtp_Fecha_Vta_Desde"
        Me.Dtp_Fecha_Vta_Desde.Size = New System.Drawing.Size(81, 22)
        Me.Dtp_Fecha_Vta_Desde.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Vta_Desde.TabIndex = 115
        Me.Dtp_Fecha_Vta_Desde.Value = New Date(2024, 10, 12, 0, 0, 0, 0)
        '
        'Dtp_Fecha_Vta_Hasta
        '
        Me.Dtp_Fecha_Vta_Hasta.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_Fecha_Vta_Hasta.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Vta_Hasta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Vta_Hasta.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Vta_Hasta.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Vta_Hasta.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Vta_Hasta.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Vta_Hasta.Location = New System.Drawing.Point(189, 9)
        '
        '
        '
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.DisplayMonth = New Date(2018, 10, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Vta_Hasta.Name = "Dtp_Fecha_Vta_Hasta"
        Me.Dtp_Fecha_Vta_Hasta.Size = New System.Drawing.Size(80, 22)
        Me.Dtp_Fecha_Vta_Hasta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Vta_Hasta.TabIndex = 116
        Me.Dtp_Fecha_Vta_Hasta.Value = New Date(2024, 10, 12, 0, 0, 0, 0)
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(144, 12)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(39, 19)
        Me.LabelX1.TabIndex = 117
        Me.LabelX1.Text = "Hasta"
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'Lbl_Estado
        '
        Me.Lbl_Estado.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Estado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Estado.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Estado.Location = New System.Drawing.Point(5, 118)
        Me.Lbl_Estado.Name = "Lbl_Estado"
        Me.Lbl_Estado.Size = New System.Drawing.Size(737, 23)
        Me.Lbl_Estado.TabIndex = 85
        Me.Lbl_Estado.Text = "Presione Porocesar...."
        '
        'TxtLog
        '
        Me.TxtLog.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtLog.Border.Class = "TextBoxBorder"
        Me.TxtLog.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtLog.DisabledBackColor = System.Drawing.Color.White
        Me.TxtLog.ForeColor = System.Drawing.Color.Black
        Me.TxtLog.Location = New System.Drawing.Point(127, 3)
        Me.TxtLog.Multiline = True
        Me.TxtLog.Name = "TxtLog"
        Me.TxtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtLog.Size = New System.Drawing.Size(615, 109)
        Me.TxtLog.TabIndex = 84
        '
        'Frm_RevMayMin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(781, 339)
        Me.Controls.Add(Me.Grupo_01)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_RevMayMin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REVISION DE ENTIDADES PARA MANTENER LISTAS MAYORISTAS Y MINORISTAS"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo_01.ResumeLayout(False)
        Me.Panel_Fechas.ResumeLayout(False)
        CType(Me.Dtp_Fecha_Vta_Desde, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_Fecha_Vta_Hasta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Public WithEvents Btn_Procesar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Cancelar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Circular_Progres_Val As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Circular_Progres_Porc As DevComponents.DotNetBar.Controls.CircularProgress
    Public WithEvents Rdb_RevTodosClientes As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Rdb_RevVentasRangoFecha As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Grupo_01 As DevComponents.DotNetBar.Controls.GroupPanel
    Private WithEvents TxtLog As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Lbl_Estado As DevComponents.DotNetBar.LabelX
    Friend WithEvents Panel_Fechas As Panel
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dtp_Fecha_Vta_Desde As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Dtp_Fecha_Vta_Hasta As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Public WithEvents Rdb_Cliente As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Txt_Cliente As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Lbl_Holding As DevComponents.DotNetBar.LabelX
End Class
