<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_DFA_Ingreso
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_DFA_Ingreso))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Crear_Nueva_DFA = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Salir = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Chk_Acepta_estar_en_mas_de_una_maquina = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.ReflectionImage1 = New DevComponents.DotNetBar.Controls.ReflectionImage()
        Me.Lbl_Referencia = New System.Windows.Forms.Label()
        Me.Dtp_Fecha_Ingreso = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Txt_Numero_OT = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Numero_DFA = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel4 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Grilla_Pobrefad = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.LayoutSpacerItem1 = New DevComponents.DotNetBar.Layout.LayoutSpacerItem()
        Me.LayoutGroup1 = New DevComponents.DotNetBar.Layout.LayoutGroup()
        Me.LayoutSpacerItem2 = New DevComponents.DotNetBar.Layout.LayoutSpacerItem()
        Me.GroupPanel5 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Grilla_Pdatfad = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Tiempo = New System.Windows.Forms.Timer(Me.components)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Dtp_Fecha_Ingreso, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel4.SuspendLayout()
        CType(Me.Grilla_Pobrefad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel5.SuspendLayout()
        CType(Me.Grilla_Pdatfad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Crear_Nueva_DFA, Me.Btn_Salir})
        Me.Bar1.Location = New System.Drawing.Point(0, 381)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(785, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 25
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Crear_Nueva_DFA
        '
        Me.Btn_Crear_Nueva_DFA.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Crear_Nueva_DFA.ForeColor = System.Drawing.Color.Black
        Me.Btn_Crear_Nueva_DFA.Image = CType(resources.GetObject("Btn_Crear_Nueva_DFA.Image"), System.Drawing.Image)
        Me.Btn_Crear_Nueva_DFA.Name = "Btn_Crear_Nueva_DFA"
        Me.Btn_Crear_Nueva_DFA.Text = "CREAR DFA"
        Me.Btn_Crear_Nueva_DFA.Visible = False
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
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Chk_Acepta_estar_en_mas_de_una_maquina)
        Me.GroupPanel1.Controls.Add(Me.ReflectionImage1)
        Me.GroupPanel1.Controls.Add(Me.Lbl_Referencia)
        Me.GroupPanel1.Controls.Add(Me.Dtp_Fecha_Ingreso)
        Me.GroupPanel1.Controls.Add(Me.Txt_Numero_OT)
        Me.GroupPanel1.Controls.Add(Me.Txt_Numero_DFA)
        Me.GroupPanel1.Controls.Add(Me.LabelX9)
        Me.GroupPanel1.Controls.Add(Me.LabelX6)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(760, 113)
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
        Me.GroupPanel1.TabIndex = 88
        '
        'Chk_Acepta_estar_en_mas_de_una_maquina
        '
        Me.Chk_Acepta_estar_en_mas_de_una_maquina.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Acepta_estar_en_mas_de_una_maquina.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Acepta_estar_en_mas_de_una_maquina.Checked = True
        Me.Chk_Acepta_estar_en_mas_de_una_maquina.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_Acepta_estar_en_mas_de_una_maquina.CheckValue = "Y"
        Me.Chk_Acepta_estar_en_mas_de_una_maquina.ForeColor = System.Drawing.Color.Black
        Me.Chk_Acepta_estar_en_mas_de_una_maquina.Location = New System.Drawing.Point(412, 40)
        Me.Chk_Acepta_estar_en_mas_de_una_maquina.Name = "Chk_Acepta_estar_en_mas_de_una_maquina"
        Me.Chk_Acepta_estar_en_mas_de_una_maquina.Size = New System.Drawing.Size(238, 23)
        Me.Chk_Acepta_estar_en_mas_de_una_maquina.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Acepta_estar_en_mas_de_una_maquina.TabIndex = 94
        Me.Chk_Acepta_estar_en_mas_de_una_maquina.Text = "Acepta estar en más de una maquina"
        '
        'ReflectionImage1
        '
        Me.ReflectionImage1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.ReflectionImage1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionImage1.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.ReflectionImage1.ForeColor = System.Drawing.Color.Black
        Me.ReflectionImage1.Image = CType(resources.GetObject("ReflectionImage1.Image"), System.Drawing.Image)
        Me.ReflectionImage1.Location = New System.Drawing.Point(656, 7)
        Me.ReflectionImage1.Name = "ReflectionImage1"
        Me.ReflectionImage1.Size = New System.Drawing.Size(95, 95)
        Me.ReflectionImage1.TabIndex = 93
        '
        'Lbl_Referencia
        '
        Me.Lbl_Referencia.BackColor = System.Drawing.Color.White
        Me.Lbl_Referencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl_Referencia.Enabled = False
        Me.Lbl_Referencia.Font = New System.Drawing.Font("Courier New", 12.0!)
        Me.Lbl_Referencia.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Referencia.Location = New System.Drawing.Point(2, 76)
        Me.Lbl_Referencia.Name = "Lbl_Referencia"
        Me.Lbl_Referencia.Size = New System.Drawing.Size(648, 26)
        Me.Lbl_Referencia.TabIndex = 92
        Me.Lbl_Referencia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Dtp_Fecha_Ingreso
        '
        Me.Dtp_Fecha_Ingreso.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_Fecha_Ingreso.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Ingreso.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Ingreso.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Ingreso.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Ingreso.Enabled = False
        Me.Dtp_Fecha_Ingreso.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dtp_Fecha_Ingreso.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Ingreso.Format = DevComponents.Editors.eDateTimePickerFormat.[Long]
        Me.Dtp_Fecha_Ingreso.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Ingreso.Location = New System.Drawing.Point(412, 7)
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
        Me.Dtp_Fecha_Ingreso.MonthCalendar.DisplayMonth = New Date(2018, 1, 1, 0, 0, 0, 0)
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
        Me.Dtp_Fecha_Ingreso.Size = New System.Drawing.Size(238, 25)
        Me.Dtp_Fecha_Ingreso.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Ingreso.TabIndex = 90
        Me.Dtp_Fecha_Ingreso.Value = New Date(2018, 1, 30, 12, 16, 22, 0)
        '
        'Txt_Numero_OT
        '
        Me.Txt_Numero_OT.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Numero_OT.Border.Class = "TextBoxBorder"
        Me.Txt_Numero_OT.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Numero_OT.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Numero_OT.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Numero_OT.FocusHighlightEnabled = True
        Me.Txt_Numero_OT.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Numero_OT.ForeColor = System.Drawing.Color.Black
        Me.Txt_Numero_OT.Location = New System.Drawing.Point(185, 37)
        Me.Txt_Numero_OT.MaxLength = 50
        Me.Txt_Numero_OT.Name = "Txt_Numero_OT"
        Me.Txt_Numero_OT.Size = New System.Drawing.Size(115, 26)
        Me.Txt_Numero_OT.TabIndex = 89
        Me.Txt_Numero_OT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Txt_Numero_DFA
        '
        Me.Txt_Numero_DFA.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Numero_DFA.Border.Class = "TextBoxBorder"
        Me.Txt_Numero_DFA.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Numero_DFA.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Numero_DFA.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Numero_DFA.FocusHighlightEnabled = True
        Me.Txt_Numero_DFA.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Numero_DFA.ForeColor = System.Drawing.Color.Black
        Me.Txt_Numero_DFA.Location = New System.Drawing.Point(185, 6)
        Me.Txt_Numero_DFA.MaxLength = 50
        Me.Txt_Numero_DFA.Name = "Txt_Numero_DFA"
        Me.Txt_Numero_DFA.Size = New System.Drawing.Size(115, 26)
        Me.Txt_Numero_DFA.TabIndex = 73
        Me.Txt_Numero_DFA.Text = "9999999999"
        Me.Txt_Numero_DFA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelX9
        '
        Me.LabelX9.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX9.ForeColor = System.Drawing.Color.Black
        Me.LabelX9.Location = New System.Drawing.Point(6, 5)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(133, 23)
        Me.LabelX9.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX9.TabIndex = 72
        Me.LabelX9.Text = "NUMERO DFA"
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Font = New System.Drawing.Font("Courier New", 9.75!)
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(3, 37)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(176, 23)
        Me.LabelX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX6.TabIndex = 65
        Me.LabelX6.Text = "INICIO / FIN Trabajo"
        '
        'GroupPanel4
        '
        Me.GroupPanel4.BackColor = System.Drawing.Color.White
        Me.GroupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel4.Controls.Add(Me.Grilla_Pobrefad)
        Me.GroupPanel4.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel4.Location = New System.Drawing.Point(6, 275)
        Me.GroupPanel4.Name = "GroupPanel4"
        Me.GroupPanel4.Size = New System.Drawing.Size(763, 79)
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
        Me.GroupPanel4.TabIndex = 91
        Me.GroupPanel4.Text = "OPERARIOS"
        '
        'Grilla_Pobrefad
        '
        Me.Grilla_Pobrefad.AllowUserToAddRows = False
        Me.Grilla_Pobrefad.AllowUserToDeleteRows = False
        Me.Grilla_Pobrefad.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Pobrefad.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grilla_Pobrefad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Pobrefad.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grilla_Pobrefad.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Pobrefad.EnableHeadersVisualStyles = False
        Me.Grilla_Pobrefad.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Pobrefad.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Pobrefad.MultiSelect = False
        Me.Grilla_Pobrefad.Name = "Grilla_Pobrefad"
        Me.Grilla_Pobrefad.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Pobrefad.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla_Pobrefad.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grilla_Pobrefad.Size = New System.Drawing.Size(757, 56)
        Me.Grilla_Pobrefad.TabIndex = 1
        '
        'LayoutSpacerItem1
        '
        Me.LayoutSpacerItem1.Height = 32
        Me.LayoutSpacerItem1.Name = "LayoutSpacerItem1"
        Me.LayoutSpacerItem1.Width = 32
        '
        'LayoutGroup1
        '
        Me.LayoutGroup1.Height = 100
        Me.LayoutGroup1.MinSize = New System.Drawing.Size(120, 32)
        Me.LayoutGroup1.Name = "LayoutGroup1"
        Me.LayoutGroup1.TextPosition = DevComponents.DotNetBar.Layout.eLayoutPosition.Top
        Me.LayoutGroup1.Width = 200
        '
        'LayoutSpacerItem2
        '
        Me.LayoutSpacerItem2.Height = 32
        Me.LayoutSpacerItem2.Name = "LayoutSpacerItem2"
        Me.LayoutSpacerItem2.Width = 32
        '
        'GroupPanel5
        '
        Me.GroupPanel5.BackColor = System.Drawing.Color.White
        Me.GroupPanel5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel5.Controls.Add(Me.Grilla_Pdatfad)
        Me.GroupPanel5.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel5.Location = New System.Drawing.Point(12, 131)
        Me.GroupPanel5.Name = "GroupPanel5"
        Me.GroupPanel5.Size = New System.Drawing.Size(760, 126)
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
        Me.GroupPanel5.TabIndex = 92
        Me.GroupPanel5.Text = "DETALLE DE DATOS DE FABRICACION"
        '
        'Grilla_Pdatfad
        '
        Me.Grilla_Pdatfad.AllowUserToAddRows = False
        Me.Grilla_Pdatfad.AllowUserToDeleteRows = False
        Me.Grilla_Pdatfad.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Pdatfad.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Grilla_Pdatfad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Pdatfad.DefaultCellStyle = DataGridViewCellStyle5
        Me.Grilla_Pdatfad.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Pdatfad.EnableHeadersVisualStyles = False
        Me.Grilla_Pdatfad.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Pdatfad.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Pdatfad.MultiSelect = False
        Me.Grilla_Pdatfad.Name = "Grilla_Pdatfad"
        Me.Grilla_Pdatfad.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Pdatfad.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Grilla_Pdatfad.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grilla_Pdatfad.Size = New System.Drawing.Size(754, 103)
        Me.Grilla_Pdatfad.TabIndex = 1
        '
        'Frm_DFA_Ingreso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(785, 422)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupPanel5)
        Me.Controls.Add(Me.GroupPanel4)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_DFA_Ingreso"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ingreso de actividades de fabricación (DFA) según Hoja de Ruta"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.Dtp_Fecha_Ingreso, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel4.ResumeLayout(False)
        CType(Me.Grilla_Pobrefad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel5.ResumeLayout(False)
        CType(Me.Grilla_Pdatfad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Public WithEvents Btn_Crear_Nueva_DFA As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Salir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Txt_Numero_DFA As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Numero_OT As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Dtp_Fecha_Ingreso As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents GroupPanel4 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grilla_Pobrefad As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents LayoutSpacerItem1 As DevComponents.DotNetBar.Layout.LayoutSpacerItem
    Friend WithEvents LayoutGroup1 As DevComponents.DotNetBar.Layout.LayoutGroup
    Friend WithEvents LayoutSpacerItem2 As DevComponents.DotNetBar.Layout.LayoutSpacerItem
    Friend WithEvents Lbl_Referencia As System.Windows.Forms.Label
    Friend WithEvents GroupPanel5 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grilla_Pdatfad As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Tiempo As System.Windows.Forms.Timer
    Friend WithEvents ReflectionImage1 As DevComponents.DotNetBar.Controls.ReflectionImage
    Friend WithEvents Chk_Acepta_estar_en_mas_de_una_maquina As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
