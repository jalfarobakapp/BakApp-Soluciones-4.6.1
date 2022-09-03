<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Cambio_Fecha_Vencimientos
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Cambio_Fecha_Vencimientos))
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar_Vencimientos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Reestablecer_Vencimientos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Editar_Vencimientos = New DevComponents.DotNetBar.ButtonItem()
        Me.Grupo_CondPago = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Dtp_Fecha_Emision = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Btn_AceptarVencimientos = New DevComponents.DotNetBar.ButtonX()
        Me.Dtp_FechaUltVencimiento = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_Fecha_1er_Vencimiento = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Dias_Entre_Vencimientos = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Cuotas = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Warning_Nomina = New DevComponents.DotNetBar.Controls.WarningBox()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_CondPago.SuspendLayout()
        CType(Me.Dtp_Fecha_Emision, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_FechaUltVencimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_Fecha_1er_Vencimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Grilla)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(11, 103)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(626, 209)
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
        Me.GroupPanel1.TabIndex = 38
        Me.GroupPanel1.Text = "Detalle"
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla.EnableHeadersVisualStyles = False
        Me.Grilla.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla.Location = New System.Drawing.Point(0, 0)
        Me.Grilla.Name = "Grilla"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla.Size = New System.Drawing.Size(620, 186)
        Me.Grilla.StandardTab = True
        Me.Grilla.TabIndex = 43
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar_Vencimientos, Me.Btn_Reestablecer_Vencimientos, Me.Btn_Editar_Vencimientos})
        Me.Bar1.Location = New System.Drawing.Point(0, 355)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(648, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 39
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Grabar_Vencimientos
        '
        Me.Btn_Grabar_Vencimientos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar_Vencimientos.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar_Vencimientos.Image = CType(resources.GetObject("Btn_Grabar_Vencimientos.Image"), System.Drawing.Image)
        Me.Btn_Grabar_Vencimientos.ImageAlt = CType(resources.GetObject("Btn_Grabar_Vencimientos.ImageAlt"), System.Drawing.Image)
        Me.Btn_Grabar_Vencimientos.Name = "Btn_Grabar_Vencimientos"
        Me.Btn_Grabar_Vencimientos.Tooltip = "Grabar vencimientos"
        Me.Btn_Grabar_Vencimientos.Visible = False
        '
        'Btn_Reestablecer_Vencimientos
        '
        Me.Btn_Reestablecer_Vencimientos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Reestablecer_Vencimientos.ForeColor = System.Drawing.Color.Black
        Me.Btn_Reestablecer_Vencimientos.Image = CType(resources.GetObject("Btn_Reestablecer_Vencimientos.Image"), System.Drawing.Image)
        Me.Btn_Reestablecer_Vencimientos.ImageAlt = CType(resources.GetObject("Btn_Reestablecer_Vencimientos.ImageAlt"), System.Drawing.Image)
        Me.Btn_Reestablecer_Vencimientos.Name = "Btn_Reestablecer_Vencimientos"
        Me.Btn_Reestablecer_Vencimientos.Tooltip = "Reestablecer vencimientos"
        Me.Btn_Reestablecer_Vencimientos.Visible = False
        '
        'Btn_Editar_Vencimientos
        '
        Me.Btn_Editar_Vencimientos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Editar_Vencimientos.ForeColor = System.Drawing.Color.Black
        Me.Btn_Editar_Vencimientos.Image = CType(resources.GetObject("Btn_Editar_Vencimientos.Image"), System.Drawing.Image)
        Me.Btn_Editar_Vencimientos.ImageAlt = CType(resources.GetObject("Btn_Editar_Vencimientos.ImageAlt"), System.Drawing.Image)
        Me.Btn_Editar_Vencimientos.Name = "Btn_Editar_Vencimientos"
        Me.Btn_Editar_Vencimientos.Text = "Editar vencimientos"
        '
        'Grupo_CondPago
        '
        Me.Grupo_CondPago.BackColor = System.Drawing.Color.White
        Me.Grupo_CondPago.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_CondPago.Controls.Add(Me.Dtp_Fecha_Emision)
        Me.Grupo_CondPago.Controls.Add(Me.LabelX1)
        Me.Grupo_CondPago.Controls.Add(Me.Btn_AceptarVencimientos)
        Me.Grupo_CondPago.Controls.Add(Me.Dtp_FechaUltVencimiento)
        Me.Grupo_CondPago.Controls.Add(Me.LabelX3)
        Me.Grupo_CondPago.Controls.Add(Me.Dtp_Fecha_1er_Vencimiento)
        Me.Grupo_CondPago.Controls.Add(Me.LabelX5)
        Me.Grupo_CondPago.Controls.Add(Me.Txt_Dias_Entre_Vencimientos)
        Me.Grupo_CondPago.Controls.Add(Me.LabelX8)
        Me.Grupo_CondPago.Controls.Add(Me.Txt_Cuotas)
        Me.Grupo_CondPago.Controls.Add(Me.LabelX2)
        Me.Grupo_CondPago.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_CondPago.Enabled = False
        Me.Grupo_CondPago.Location = New System.Drawing.Point(11, 12)
        Me.Grupo_CondPago.Name = "Grupo_CondPago"
        Me.Grupo_CondPago.Size = New System.Drawing.Size(626, 85)
        '
        '
        '
        Me.Grupo_CondPago.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_CondPago.Style.BackColorGradientAngle = 90
        Me.Grupo_CondPago.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_CondPago.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_CondPago.Style.BorderBottomWidth = 1
        Me.Grupo_CondPago.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_CondPago.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_CondPago.Style.BorderLeftWidth = 1
        Me.Grupo_CondPago.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_CondPago.Style.BorderRightWidth = 1
        Me.Grupo_CondPago.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_CondPago.Style.BorderTopWidth = 1
        Me.Grupo_CondPago.Style.CornerDiameter = 4
        Me.Grupo_CondPago.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_CondPago.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_CondPago.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_CondPago.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_CondPago.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_CondPago.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_CondPago.TabIndex = 42
        Me.Grupo_CondPago.Text = "Vencimientos del documento"
        '
        'Dtp_Fecha_Emision
        '
        Me.Dtp_Fecha_Emision.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_Fecha_Emision.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Emision.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Emision.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Emision.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Emision.Enabled = False
        Me.Dtp_Fecha_Emision.FocusHighlightEnabled = True
        Me.Dtp_Fecha_Emision.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Emision.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Emision.Location = New System.Drawing.Point(111, 36)
        '
        '
        '
        Me.Dtp_Fecha_Emision.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Emision.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Emision.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Emision.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Emision.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Emision.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Emision.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Emision.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Emision.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Emision.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Emision.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Emision.MonthCalendar.DisplayMonth = New Date(2014, 11, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Emision.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Emision.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Emision.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Emision.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Emision.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Emision.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Emision.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Emision.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Emision.Name = "Dtp_Fecha_Emision"
        Me.Dtp_Fecha_Emision.Size = New System.Drawing.Size(102, 22)
        Me.Dtp_Fecha_Emision.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Emision.TabIndex = 83
        Me.Dtp_Fecha_Emision.Value = New Date(2014, 9, 30, 0, 0, 0, 0)
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(111, 12)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(102, 23)
        Me.LabelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX1.TabIndex = 84
        Me.LabelX1.Text = "Fecha emisión"
        '
        'Btn_AceptarVencimientos
        '
        Me.Btn_AceptarVencimientos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_AceptarVencimientos.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_AceptarVencimientos.Image = CType(resources.GetObject("Btn_AceptarVencimientos.Image"), System.Drawing.Image)
        Me.Btn_AceptarVencimientos.ImageAlt = CType(resources.GetObject("Btn_AceptarVencimientos.ImageAlt"), System.Drawing.Image)
        Me.Btn_AceptarVencimientos.Location = New System.Drawing.Point(464, 35)
        Me.Btn_AceptarVencimientos.Name = "Btn_AceptarVencimientos"
        Me.Btn_AceptarVencimientos.Size = New System.Drawing.Size(145, 23)
        Me.Btn_AceptarVencimientos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_AceptarVencimientos.TabIndex = 82
        Me.Btn_AceptarVencimientos.Text = "Aceptar vencimientos"
        '
        'Dtp_FechaUltVencimiento
        '
        Me.Dtp_FechaUltVencimiento.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_FechaUltVencimiento.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_FechaUltVencimiento.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaUltVencimiento.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_FechaUltVencimiento.ButtonDropDown.Visible = True
        Me.Dtp_FechaUltVencimiento.Enabled = False
        Me.Dtp_FechaUltVencimiento.FocusHighlightEnabled = True
        Me.Dtp_FechaUltVencimiento.ForeColor = System.Drawing.Color.Black
        Me.Dtp_FechaUltVencimiento.IsPopupCalendarOpen = False
        Me.Dtp_FechaUltVencimiento.Location = New System.Drawing.Point(350, 36)
        '
        '
        '
        Me.Dtp_FechaUltVencimiento.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FechaUltVencimiento.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaUltVencimiento.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_FechaUltVencimiento.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_FechaUltVencimiento.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_FechaUltVencimiento.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FechaUltVencimiento.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_FechaUltVencimiento.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_FechaUltVencimiento.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_FechaUltVencimiento.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_FechaUltVencimiento.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaUltVencimiento.MonthCalendar.DisplayMonth = New Date(2014, 11, 1, 0, 0, 0, 0)
        Me.Dtp_FechaUltVencimiento.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_FechaUltVencimiento.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FechaUltVencimiento.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_FechaUltVencimiento.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FechaUltVencimiento.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_FechaUltVencimiento.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaUltVencimiento.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_FechaUltVencimiento.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_FechaUltVencimiento.Name = "Dtp_FechaUltVencimiento"
        Me.Dtp_FechaUltVencimiento.Size = New System.Drawing.Size(97, 22)
        Me.Dtp_FechaUltVencimiento.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_FechaUltVencimiento.TabIndex = 80
        Me.Dtp_FechaUltVencimiento.Value = New Date(2014, 9, 30, 0, 0, 0, 0)
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(350, 12)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(97, 23)
        Me.LabelX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX3.TabIndex = 81
        Me.LabelX3.Text = "Fecha Ult. Venc."
        '
        'Dtp_Fecha_1er_Vencimiento
        '
        Me.Dtp_Fecha_1er_Vencimiento.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_Fecha_1er_Vencimiento.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_1er_Vencimiento.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_1er_Vencimiento.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_1er_Vencimiento.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_1er_Vencimiento.FocusHighlightEnabled = True
        Me.Dtp_Fecha_1er_Vencimiento.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_1er_Vencimiento.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_1er_Vencimiento.Location = New System.Drawing.Point(233, 36)
        '
        '
        '
        Me.Dtp_Fecha_1er_Vencimiento.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_1er_Vencimiento.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_1er_Vencimiento.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_1er_Vencimiento.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_1er_Vencimiento.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_1er_Vencimiento.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_1er_Vencimiento.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_1er_Vencimiento.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_1er_Vencimiento.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_1er_Vencimiento.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_1er_Vencimiento.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_1er_Vencimiento.MonthCalendar.DisplayMonth = New Date(2014, 11, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_1er_Vencimiento.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_1er_Vencimiento.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_1er_Vencimiento.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_1er_Vencimiento.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_1er_Vencimiento.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_1er_Vencimiento.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_1er_Vencimiento.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_1er_Vencimiento.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_1er_Vencimiento.Name = "Dtp_Fecha_1er_Vencimiento"
        Me.Dtp_Fecha_1er_Vencimiento.Size = New System.Drawing.Size(102, 22)
        Me.Dtp_Fecha_1er_Vencimiento.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_1er_Vencimiento.TabIndex = 10
        Me.Dtp_Fecha_1er_Vencimiento.Value = New Date(2014, 9, 30, 0, 0, 0, 0)
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(233, 12)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(102, 23)
        Me.LabelX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX5.TabIndex = 70
        Me.LabelX5.Text = "Fecha 1er Venc."
        '
        'Txt_Dias_Entre_Vencimientos
        '
        Me.Txt_Dias_Entre_Vencimientos.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Dias_Entre_Vencimientos.Border.Class = "TextBoxBorder"
        Me.Txt_Dias_Entre_Vencimientos.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Dias_Entre_Vencimientos.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Dias_Entre_Vencimientos.FocusHighlightEnabled = True
        Me.Txt_Dias_Entre_Vencimientos.ForeColor = System.Drawing.Color.Black
        Me.Txt_Dias_Entre_Vencimientos.Location = New System.Drawing.Point(58, 37)
        Me.Txt_Dias_Entre_Vencimientos.MaxLength = 20
        Me.Txt_Dias_Entre_Vencimientos.Name = "Txt_Dias_Entre_Vencimientos"
        Me.Txt_Dias_Entre_Vencimientos.PreventEnterBeep = True
        Me.Txt_Dias_Entre_Vencimientos.Size = New System.Drawing.Size(34, 22)
        Me.Txt_Dias_Entre_Vencimientos.TabIndex = 78
        Me.Txt_Dias_Entre_Vencimientos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelX8
        '
        Me.LabelX8.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX8.ForeColor = System.Drawing.Color.Black
        Me.LabelX8.Location = New System.Drawing.Point(58, 12)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(34, 23)
        Me.LabelX8.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX8.TabIndex = 79
        Me.LabelX8.Text = "Dias"
        '
        'Txt_Cuotas
        '
        Me.Txt_Cuotas.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Cuotas.Border.Class = "TextBoxBorder"
        Me.Txt_Cuotas.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Cuotas.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Cuotas.FocusHighlightEnabled = True
        Me.Txt_Cuotas.ForeColor = System.Drawing.Color.Black
        Me.Txt_Cuotas.Location = New System.Drawing.Point(3, 36)
        Me.Txt_Cuotas.MaxLength = 20
        Me.Txt_Cuotas.Name = "Txt_Cuotas"
        Me.Txt_Cuotas.PreventEnterBeep = True
        Me.Txt_Cuotas.Size = New System.Drawing.Size(38, 22)
        Me.Txt_Cuotas.TabIndex = 9
        Me.Txt_Cuotas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 12)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(49, 23)
        Me.LabelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX2.TabIndex = 61
        Me.LabelX2.Text = "Cuotas"
        '
        'Warning_Nomina
        '
        Me.Warning_Nomina.BackColor = System.Drawing.Color.White
        Me.Warning_Nomina.ForeColor = System.Drawing.Color.Black
        Me.Warning_Nomina.Image = CType(resources.GetObject("Warning_Nomina.Image"), System.Drawing.Image)
        Me.Warning_Nomina.Location = New System.Drawing.Point(11, 318)
        Me.Warning_Nomina.Name = "Warning_Nomina"
        Me.Warning_Nomina.OptionsText = "Información..."
        Me.Warning_Nomina.Size = New System.Drawing.Size(352, 33)
        Me.Warning_Nomina.TabIndex = 43
        Me.Warning_Nomina.Text = "<b>Atención</b> documento en nomina de pago"
        Me.Warning_Nomina.Visible = False
        '
        'Frm_Cambio_Fecha_Vencimientos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(648, 396)
        Me.Controls.Add(Me.Warning_Nomina)
        Me.Controls.Add(Me.Grupo_CondPago)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.GroupPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Cambio_Fecha_Vencimientos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo_CondPago.ResumeLayout(False)
        CType(Me.Dtp_Fecha_Emision, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_FechaUltVencimiento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_Fecha_1er_Vencimiento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar_Vencimientos As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Grupo_CondPago As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Btn_AceptarVencimientos As DevComponents.DotNetBar.ButtonX
    Public WithEvents Dtp_FechaUltVencimiento As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Public WithEvents Dtp_Fecha_1er_Vencimiento As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Dias_Entre_Vencimientos As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Cuotas As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Reestablecer_Vencimientos As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Dtp_Fecha_Emision As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Editar_Vencimientos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Warning_Nomina As DevComponents.DotNetBar.Controls.WarningBox
End Class
