<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_InfoEnt_Deudas_Doc_Comerciales
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_InfoEnt_Deudas_Doc_Comerciales))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_CambCodPago = New DevComponents.DotNetBar.ButtonItem()
        Me.SuperTabControl1 = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.Grilla_Credito = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Tab_SituacionCliente = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.Grilla_Deuda = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Tab_DeudasVencidas = New DevComponents.DotNetBar.SuperTabItem()
        Me.Grupo_CondPago = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Btn_AceptarVencimientos = New DevComponents.DotNetBar.ButtonX()
        Me.Dtp_FechaUltVencimiento = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_Fecha_1er_Vencimiento = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Dias_1er_Vencimiento = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Cuotas = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Warning_Box_Deuda = New DevComponents.DotNetBar.Controls.WarningBox()
        Me.Warning_Box_Cupo_Exedido = New DevComponents.DotNetBar.Controls.WarningBox()
        Me.Imagenes_16x16 = New System.Windows.Forms.ImageList(Me.components)
        Me.Chk_Utilizar_NVV_En_Credito_X_Cliente = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControl1.SuspendLayout()
        Me.SuperTabControlPanel2.SuspendLayout()
        CType(Me.Grilla_Credito, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel1.SuspendLayout()
        CType(Me.Grilla_Deuda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_CondPago.SuspendLayout()
        CType(Me.Dtp_FechaUltVencimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_Fecha_1er_Vencimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_CambCodPago})
        Me.Bar2.Location = New System.Drawing.Point(0, 450)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(603, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 11
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_CambCodPago
        '
        Me.Btn_CambCodPago.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_CambCodPago.ForeColor = System.Drawing.Color.Black
        Me.Btn_CambCodPago.Image = CType(resources.GetObject("Btn_CambCodPago.Image"), System.Drawing.Image)
        Me.Btn_CambCodPago.ImageAlt = CType(resources.GetObject("Btn_CambCodPago.ImageAlt"), System.Drawing.Image)
        Me.Btn_CambCodPago.Name = "Btn_CambCodPago"
        Me.Btn_CambCodPago.Text = "Cambiar condición de pago"
        '
        'SuperTabControl1
        '
        Me.SuperTabControl1.BackColor = System.Drawing.Color.White
        '
        '
        '
        '
        '
        '
        Me.SuperTabControl1.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.SuperTabControl1.ControlBox.MenuBox.Name = ""
        Me.SuperTabControl1.ControlBox.Name = ""
        Me.SuperTabControl1.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabControl1.ControlBox.MenuBox, Me.SuperTabControl1.ControlBox.CloseBox})
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel2)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel1)
        Me.SuperTabControl1.ForeColor = System.Drawing.Color.Black
        Me.SuperTabControl1.Location = New System.Drawing.Point(12, 12)
        Me.SuperTabControl1.Name = "SuperTabControl1"
        Me.SuperTabControl1.ReorderTabsEnabled = True
        Me.SuperTabControl1.SelectedTabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.SuperTabControl1.SelectedTabIndex = 0
        Me.SuperTabControl1.Size = New System.Drawing.Size(580, 242)
        Me.SuperTabControl1.TabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SuperTabControl1.TabIndex = 13
        Me.SuperTabControl1.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Tab_SituacionCliente, Me.Tab_DeudasVencidas})
        Me.SuperTabControl1.Text = "SuperTabControl1"
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Controls.Add(Me.Grilla_Credito)
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 27)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(580, 215)
        Me.SuperTabControlPanel2.TabIndex = 0
        Me.SuperTabControlPanel2.TabItem = Me.Tab_SituacionCliente
        '
        'Grilla_Credito
        '
        Me.Grilla_Credito.AllowUserToAddRows = False
        Me.Grilla_Credito.AllowUserToDeleteRows = False
        Me.Grilla_Credito.AllowUserToOrderColumns = True
        Me.Grilla_Credito.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Credito.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grilla_Credito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Credito.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grilla_Credito.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Credito.EnableHeadersVisualStyles = False
        Me.Grilla_Credito.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Credito.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Credito.Name = "Grilla_Credito"
        Me.Grilla_Credito.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Credito.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla_Credito.Size = New System.Drawing.Size(580, 215)
        Me.Grilla_Credito.StandardTab = True
        Me.Grilla_Credito.TabIndex = 55
        '
        'Tab_SituacionCliente
        '
        Me.Tab_SituacionCliente.AttachedControl = Me.SuperTabControlPanel2
        Me.Tab_SituacionCliente.GlobalItem = False
        Me.Tab_SituacionCliente.Name = "Tab_SituacionCliente"
        Me.Tab_SituacionCliente.Text = "Situación de crédito del cliente"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.Grilla_Deuda)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(580, 242)
        Me.SuperTabControlPanel1.TabIndex = 1
        Me.SuperTabControlPanel1.TabItem = Me.Tab_DeudasVencidas
        '
        'Grilla_Deuda
        '
        Me.Grilla_Deuda.AllowUserToAddRows = False
        Me.Grilla_Deuda.AllowUserToDeleteRows = False
        Me.Grilla_Deuda.AllowUserToOrderColumns = True
        Me.Grilla_Deuda.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Deuda.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Grilla_Deuda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Deuda.DefaultCellStyle = DataGridViewCellStyle5
        Me.Grilla_Deuda.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Deuda.EnableHeadersVisualStyles = False
        Me.Grilla_Deuda.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Deuda.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Deuda.Name = "Grilla_Deuda"
        Me.Grilla_Deuda.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Deuda.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Grilla_Deuda.Size = New System.Drawing.Size(580, 242)
        Me.Grilla_Deuda.StandardTab = True
        Me.Grilla_Deuda.TabIndex = 54
        '
        'Tab_DeudasVencidas
        '
        Me.Tab_DeudasVencidas.AttachedControl = Me.SuperTabControlPanel1
        Me.Tab_DeudasVencidas.GlobalItem = False
        Me.Tab_DeudasVencidas.Name = "Tab_DeudasVencidas"
        Me.Tab_DeudasVencidas.Text = "Deudas vencidas"
        '
        'Grupo_CondPago
        '
        Me.Grupo_CondPago.BackColor = System.Drawing.Color.White
        Me.Grupo_CondPago.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_CondPago.Controls.Add(Me.Btn_AceptarVencimientos)
        Me.Grupo_CondPago.Controls.Add(Me.Dtp_FechaUltVencimiento)
        Me.Grupo_CondPago.Controls.Add(Me.LabelX3)
        Me.Grupo_CondPago.Controls.Add(Me.Dtp_Fecha_1er_Vencimiento)
        Me.Grupo_CondPago.Controls.Add(Me.LabelX5)
        Me.Grupo_CondPago.Controls.Add(Me.Txt_Dias_1er_Vencimiento)
        Me.Grupo_CondPago.Controls.Add(Me.LabelX8)
        Me.Grupo_CondPago.Controls.Add(Me.Txt_Cuotas)
        Me.Grupo_CondPago.Controls.Add(Me.LabelX2)
        Me.Grupo_CondPago.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_CondPago.Enabled = False
        Me.Grupo_CondPago.Location = New System.Drawing.Point(12, 281)
        Me.Grupo_CondPago.Name = "Grupo_CondPago"
        Me.Grupo_CondPago.Size = New System.Drawing.Size(580, 85)
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
        Me.Grupo_CondPago.TabIndex = 41
        Me.Grupo_CondPago.Text = "Condiciones de pago"
        '
        'Btn_AceptarVencimientos
        '
        Me.Btn_AceptarVencimientos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_AceptarVencimientos.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_AceptarVencimientos.Image = CType(resources.GetObject("Btn_AceptarVencimientos.Image"), System.Drawing.Image)
        Me.Btn_AceptarVencimientos.ImageAlt = CType(resources.GetObject("Btn_AceptarVencimientos.ImageAlt"), System.Drawing.Image)
        Me.Btn_AceptarVencimientos.Location = New System.Drawing.Point(420, 12)
        Me.Btn_AceptarVencimientos.Name = "Btn_AceptarVencimientos"
        Me.Btn_AceptarVencimientos.Size = New System.Drawing.Size(151, 46)
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
        Me.Dtp_FechaUltVencimiento.Location = New System.Drawing.Point(303, 36)
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
        Me.Dtp_FechaUltVencimiento.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
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
        Me.LabelX3.Location = New System.Drawing.Point(303, 12)
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
        Me.Dtp_Fecha_1er_Vencimiento.Location = New System.Drawing.Point(180, 36)
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
        Me.Dtp_Fecha_1er_Vencimiento.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
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
        Me.LabelX5.Location = New System.Drawing.Point(180, 12)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(136, 23)
        Me.LabelX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX5.TabIndex = 70
        Me.LabelX5.Text = "Fecha 1er Venc."
        '
        'Txt_Dias_1er_Vencimiento
        '
        Me.Txt_Dias_1er_Vencimiento.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Dias_1er_Vencimiento.Border.Class = "TextBoxBorder"
        Me.Txt_Dias_1er_Vencimiento.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Dias_1er_Vencimiento.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Dias_1er_Vencimiento.FocusHighlightEnabled = True
        Me.Txt_Dias_1er_Vencimiento.ForeColor = System.Drawing.Color.Black
        Me.Txt_Dias_1er_Vencimiento.Location = New System.Drawing.Point(72, 36)
        Me.Txt_Dias_1er_Vencimiento.MaxLength = 3
        Me.Txt_Dias_1er_Vencimiento.Name = "Txt_Dias_1er_Vencimiento"
        Me.Txt_Dias_1er_Vencimiento.PreventEnterBeep = True
        Me.Txt_Dias_1er_Vencimiento.Size = New System.Drawing.Size(88, 22)
        Me.Txt_Dias_1er_Vencimiento.TabIndex = 78
        Me.Txt_Dias_1er_Vencimiento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        Me.LabelX8.Location = New System.Drawing.Point(72, 12)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(144, 23)
        Me.LabelX8.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX8.TabIndex = 79
        Me.LabelX8.Text = "Dias 1er Venc."
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
        Me.Txt_Cuotas.MaxLength = 2
        Me.Txt_Cuotas.Name = "Txt_Cuotas"
        Me.Txt_Cuotas.PreventEnterBeep = True
        Me.Txt_Cuotas.Size = New System.Drawing.Size(49, 22)
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
        'Warning_Box_Deuda
        '
        Me.Warning_Box_Deuda.BackColor = System.Drawing.Color.White
        Me.Warning_Box_Deuda.CloseButtonVisible = False
        Me.Warning_Box_Deuda.ForeColor = System.Drawing.Color.Black
        Me.Warning_Box_Deuda.Image = CType(resources.GetObject("Warning_Box_Deuda.Image"), System.Drawing.Image)
        Me.Warning_Box_Deuda.Location = New System.Drawing.Point(12, 372)
        Me.Warning_Box_Deuda.Name = "Warning_Box_Deuda"
        Me.Warning_Box_Deuda.OptionsButtonVisible = False
        Me.Warning_Box_Deuda.OptionsText = "Ver..."
        Me.Warning_Box_Deuda.Size = New System.Drawing.Size(580, 33)
        Me.Warning_Box_Deuda.TabIndex = 44
        Me.Warning_Box_Deuda.Text = "<b>TIENE DEUDAS VENCIDAS</b> <i></i>"
        Me.Warning_Box_Deuda.Visible = False
        '
        'Warning_Box_Cupo_Exedido
        '
        Me.Warning_Box_Cupo_Exedido.BackColor = System.Drawing.Color.White
        Me.Warning_Box_Cupo_Exedido.CloseButtonVisible = False
        Me.Warning_Box_Cupo_Exedido.ForeColor = System.Drawing.Color.Black
        Me.Warning_Box_Cupo_Exedido.Image = CType(resources.GetObject("Warning_Box_Cupo_Exedido.Image"), System.Drawing.Image)
        Me.Warning_Box_Cupo_Exedido.Location = New System.Drawing.Point(12, 411)
        Me.Warning_Box_Cupo_Exedido.Name = "Warning_Box_Cupo_Exedido"
        Me.Warning_Box_Cupo_Exedido.OptionsButtonVisible = False
        Me.Warning_Box_Cupo_Exedido.OptionsText = "Ver..."
        Me.Warning_Box_Cupo_Exedido.Size = New System.Drawing.Size(580, 33)
        Me.Warning_Box_Cupo_Exedido.TabIndex = 45
        Me.Warning_Box_Cupo_Exedido.Text = "<b>CLIENTE EXEDE EL LIMITE DE CUPO EN CTA. CTE.</b> <i></i>"
        Me.Warning_Box_Cupo_Exedido.Visible = False
        '
        'Imagenes_16x16
        '
        Me.Imagenes_16x16.ImageStream = CType(resources.GetObject("Imagenes_16x16.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagenes_16x16.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagenes_16x16.Images.SetKeyName(0, "warning.png")
        Me.Imagenes_16x16.Images.SetKeyName(1, "ok.png")
        Me.Imagenes_16x16.Images.SetKeyName(2, "cancel.png")
        Me.Imagenes_16x16.Images.SetKeyName(3, "delete_button_error.png")
        '
        'Chk_Utilizar_NVV_En_Credito_X_Cliente
        '
        Me.Chk_Utilizar_NVV_En_Credito_X_Cliente.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Utilizar_NVV_En_Credito_X_Cliente.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Utilizar_NVV_En_Credito_X_Cliente.Enabled = False
        Me.Chk_Utilizar_NVV_En_Credito_X_Cliente.ForeColor = System.Drawing.Color.Black
        Me.Chk_Utilizar_NVV_En_Credito_X_Cliente.Location = New System.Drawing.Point(12, 252)
        Me.Chk_Utilizar_NVV_En_Credito_X_Cliente.Name = "Chk_Utilizar_NVV_En_Credito_X_Cliente"
        Me.Chk_Utilizar_NVV_En_Credito_X_Cliente.Size = New System.Drawing.Size(319, 23)
        Me.Chk_Utilizar_NVV_En_Credito_X_Cliente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Utilizar_NVV_En_Credito_X_Cliente.TabIndex = 46
        Me.Chk_Utilizar_NVV_En_Credito_X_Cliente.Text = "Considera NVV abiertas como cupo utilizado"
        Me.ToolTip1.SetToolTip(Me.Chk_Utilizar_NVV_En_Credito_X_Cliente, "Se debe cambia desde CONFIGURACION GENERAL")
        '
        'Frm_InfoEnt_Deudas_Doc_Comerciales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(603, 491)
        Me.Controls.Add(Me.Grupo_CondPago)
        Me.Controls.Add(Me.Warning_Box_Cupo_Exedido)
        Me.Controls.Add(Me.Warning_Box_Deuda)
        Me.Controls.Add(Me.SuperTabControl1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.Chk_Utilizar_NVV_En_Credito_X_Cliente)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_InfoEnt_Deudas_Doc_Comerciales"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cuotas vencidas"
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControl1.ResumeLayout(False)
        Me.SuperTabControlPanel2.ResumeLayout(False)
        CType(Me.Grilla_Credito, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel1.ResumeLayout(False)
        CType(Me.Grilla_Deuda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo_CondPago.ResumeLayout(False)
        CType(Me.Dtp_FechaUltVencimiento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_Fecha_1er_Vencimiento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Public WithEvents Tab_SituacionCliente As DevComponents.DotNetBar.SuperTabItem
    Public WithEvents Tab_DeudasVencidas As DevComponents.DotNetBar.SuperTabItem
    Public WithEvents Grupo_CondPago As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Dtp_FechaUltVencimiento As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Public WithEvents Dtp_Fecha_1er_Vencimiento As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Dias_1er_Vencimiento As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Cuotas As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Public WithEvents Btn_AceptarVencimientos As DevComponents.DotNetBar.ButtonX
    Public WithEvents Btn_CambCodPago As DevComponents.DotNetBar.ButtonItem
    Private WithEvents SuperTabControl1 As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents Warning_Box_Deuda As DevComponents.DotNetBar.Controls.WarningBox
    Friend WithEvents Warning_Box_Cupo_Exedido As DevComponents.DotNetBar.Controls.WarningBox
    Friend WithEvents Imagenes_16x16 As System.Windows.Forms.ImageList
    Friend WithEvents Chk_Utilizar_NVV_En_Credito_X_Cliente As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Grilla_Credito As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Grilla_Deuda As DevComponents.DotNetBar.Controls.DataGridViewX
End Class
