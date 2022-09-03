<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Pagos_Masivos_Cheque
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Pagos_Masivos_Cheque))
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_Fecha_Vencimiento = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Cmb_Emdp = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Proveedor = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Total_a_pagar = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Nro_Cheque = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_Fecha_Emision = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Pagar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Trae_Ultimo_Nro_Cheque = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.Dtp_Fecha_Vencimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_Fecha_Emision, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(11, 6)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(488, 187)
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
        Me.GroupPanel1.TabIndex = 39
        Me.GroupPanel1.Text = "Identificación de documento de pago"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.31646!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.68355!))
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX6, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Dtp_Fecha_Vencimiento, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Cmb_Emdp, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX4, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Proveedor, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX5, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Total_a_pagar, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX3, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Nro_Cheque, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX2, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Dtp_Fecha_Emision, 1, 2)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(474, 156)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(3, 53)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(114, 19)
        Me.LabelX6.TabIndex = 4
        Me.LabelX6.Text = "Fecha emisión"
        Me.LabelX6.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Dtp_Fecha_Vencimiento
        '
        '
        '
        '
        Me.Dtp_Fecha_Vencimiento.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Vencimiento.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Vencimiento.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Vencimiento.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Vencimiento.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Vencimiento.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Vencimiento.Location = New System.Drawing.Point(123, 78)
        '
        '
        '
        Me.Dtp_Fecha_Vencimiento.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Vencimiento.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Vencimiento.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Vencimiento.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Vencimiento.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Vencimiento.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Vencimiento.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Vencimiento.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Vencimiento.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Vencimiento.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Vencimiento.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Vencimiento.MonthCalendar.DisplayMonth = New Date(2016, 3, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Vencimiento.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_Fecha_Vencimiento.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Vencimiento.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Vencimiento.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Vencimiento.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Vencimiento.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Vencimiento.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Vencimiento.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Vencimiento.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Vencimiento.Name = "Dtp_Fecha_Vencimiento"
        Me.Dtp_Fecha_Vencimiento.Size = New System.Drawing.Size(90, 22)
        Me.Dtp_Fecha_Vencimiento.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Vencimiento.TabIndex = 10
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 28)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(114, 19)
        Me.LabelX1.TabIndex = 2
        Me.LabelX1.Text = "Emisor de documento"
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Cmb_Emdp
        '
        Me.Cmb_Emdp.DisplayMember = "Text"
        Me.Cmb_Emdp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Emdp.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Emdp.FormattingEnabled = True
        Me.Cmb_Emdp.ItemHeight = 16
        Me.Cmb_Emdp.Location = New System.Drawing.Point(123, 28)
        Me.Cmb_Emdp.Name = "Cmb_Emdp"
        Me.Cmb_Emdp.Size = New System.Drawing.Size(268, 22)
        Me.Cmb_Emdp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Emdp.TabIndex = 0
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(3, 3)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(114, 19)
        Me.LabelX4.TabIndex = 8
        Me.LabelX4.Text = "Proveedor"
        Me.LabelX4.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Txt_Proveedor
        '
        Me.Txt_Proveedor.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Proveedor.Border.Class = "TextBoxBorder"
        Me.Txt_Proveedor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Proveedor.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Proveedor.ForeColor = System.Drawing.Color.Black
        Me.Txt_Proveedor.Location = New System.Drawing.Point(123, 3)
        Me.Txt_Proveedor.Name = "Txt_Proveedor"
        Me.Txt_Proveedor.PreventEnterBeep = True
        Me.Txt_Proveedor.ReadOnly = True
        Me.Txt_Proveedor.Size = New System.Drawing.Size(348, 22)
        Me.Txt_Proveedor.TabIndex = 9
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(3, 128)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(114, 19)
        Me.LabelX5.TabIndex = 6
        Me.LabelX5.Text = "Monto total a pagar "
        Me.LabelX5.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Txt_Total_a_pagar
        '
        Me.Txt_Total_a_pagar.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Total_a_pagar.Border.Class = "TextBoxBorder"
        Me.Txt_Total_a_pagar.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Total_a_pagar.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Total_a_pagar.ForeColor = System.Drawing.Color.Black
        Me.Txt_Total_a_pagar.Location = New System.Drawing.Point(123, 128)
        Me.Txt_Total_a_pagar.Name = "Txt_Total_a_pagar"
        Me.Txt_Total_a_pagar.PreventEnterBeep = True
        Me.Txt_Total_a_pagar.ReadOnly = True
        Me.Txt_Total_a_pagar.Size = New System.Drawing.Size(121, 22)
        Me.Txt_Total_a_pagar.TabIndex = 7
        Me.Txt_Total_a_pagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(3, 103)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(114, 19)
        Me.LabelX3.TabIndex = 4
        Me.LabelX3.Text = "Número de cheque"
        Me.LabelX3.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Txt_Nro_Cheque
        '
        Me.Txt_Nro_Cheque.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Nro_Cheque.Border.Class = "TextBoxBorder"
        Me.Txt_Nro_Cheque.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Nro_Cheque.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Nro_Cheque.ForeColor = System.Drawing.Color.Black
        Me.Txt_Nro_Cheque.Location = New System.Drawing.Point(123, 103)
        Me.Txt_Nro_Cheque.MaxLength = 8
        Me.Txt_Nro_Cheque.Name = "Txt_Nro_Cheque"
        Me.Txt_Nro_Cheque.PreventEnterBeep = True
        Me.Txt_Nro_Cheque.Size = New System.Drawing.Size(90, 22)
        Me.Txt_Nro_Cheque.TabIndex = 1
        Me.Txt_Nro_Cheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 78)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(114, 19)
        Me.LabelX2.TabIndex = 3
        Me.LabelX2.Text = "Fecha vencimiento"
        Me.LabelX2.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Dtp_Fecha_Emision
        '
        '
        '
        '
        Me.Dtp_Fecha_Emision.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Emision.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Emision.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Emision.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Emision.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Emision.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Emision.Location = New System.Drawing.Point(123, 53)
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
        Me.Dtp_Fecha_Emision.MonthCalendar.DisplayMonth = New Date(2016, 3, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Emision.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
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
        Me.Dtp_Fecha_Emision.Size = New System.Drawing.Size(90, 22)
        Me.Dtp_Fecha_Emision.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Emision.TabIndex = 2
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Pagar, Me.Btn_Trae_Ultimo_Nro_Cheque})
        Me.Bar1.Location = New System.Drawing.Point(0, 199)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(501, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 38
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Pagar
        '
        Me.Btn_Pagar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Pagar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Pagar.Image = CType(resources.GetObject("Btn_Pagar.Image"), System.Drawing.Image)
        Me.Btn_Pagar.Name = "Btn_Pagar"
        Me.Btn_Pagar.Text = "Realizar pago"
        '
        'Btn_Trae_Ultimo_Nro_Cheque
        '
        Me.Btn_Trae_Ultimo_Nro_Cheque.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Trae_Ultimo_Nro_Cheque.ForeColor = System.Drawing.Color.Black
        Me.Btn_Trae_Ultimo_Nro_Cheque.Image = CType(resources.GetObject("Btn_Trae_Ultimo_Nro_Cheque.Image"), System.Drawing.Image)
        Me.Btn_Trae_Ultimo_Nro_Cheque.Name = "Btn_Trae_Ultimo_Nro_Cheque"
        Me.Btn_Trae_Ultimo_Nro_Cheque.Tooltip = "Traer ultimo número de cheque"
        '
        'Frm_Pagos_Masivos_Cheque
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(501, 240)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Pagos_Masivos_Cheque"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pago con cheque bancario"
        Me.GroupPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.Dtp_Fecha_Vencimiento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_Fecha_Emision, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Dtp_Fecha_Emision As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Cmb_Emdp As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Txt_Nro_Cheque As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Public WithEvents Btn_Pagar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Total_a_pagar As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Proveedor As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dtp_Fecha_Vencimiento As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Public WithEvents Btn_Trae_Ultimo_Nro_Cheque As DevComponents.DotNetBar.ButtonItem
End Class
