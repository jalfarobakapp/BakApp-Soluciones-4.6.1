<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Crear_Entidad_Mt_Noficicaiones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Crear_Entidad_Mt_Noficicaiones))
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Cmb_Suen = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Cmb_Komail = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Dtp_Mailini = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Mailto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Nameto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Mailcc = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Namecc = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Mailcc2 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Namecc2 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Agregar_cta = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.Dtp_Mailini, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(11, 3)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(516, 262)
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
        Me.GroupPanel1.TabIndex = 42
        Me.GroupPanel1.Text = "Configuración para el envío de correos automáticos"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.57936!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.42063!))
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Cmb_Suen, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cmb_Komail, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Dtp_Mailini, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX6, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Mailto, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX9, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX8, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Nameto, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Mailcc, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Namecc, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Mailcc2, 1, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Namecc2, 1, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX7, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX5, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX10, 0, 8)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 9
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(504, 230)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(3, 53)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(117, 19)
        Me.LabelX3.TabIndex = 4
        Me.LabelX3.Text = "Fecha inicio"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(117, 19)
        Me.LabelX1.TabIndex = 2
        Me.LabelX1.Text = "Sucursal"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 28)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(117, 19)
        Me.LabelX2.TabIndex = 3
        Me.LabelX2.Text = "Tipo"
        '
        'Cmb_Suen
        '
        Me.Cmb_Suen.DisplayMember = "Text"
        Me.Cmb_Suen.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Suen.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Suen.FormattingEnabled = True
        Me.Cmb_Suen.ItemHeight = 16
        Me.Cmb_Suen.Location = New System.Drawing.Point(141, 3)
        Me.Cmb_Suen.Name = "Cmb_Suen"
        Me.Cmb_Suen.Size = New System.Drawing.Size(133, 22)
        Me.Cmb_Suen.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Suen.TabIndex = 3
        '
        'Cmb_Komail
        '
        Me.Cmb_Komail.DisplayMember = "Text"
        Me.Cmb_Komail.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Komail.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Komail.FormattingEnabled = True
        Me.Cmb_Komail.ItemHeight = 16
        Me.Cmb_Komail.Location = New System.Drawing.Point(141, 28)
        Me.Cmb_Komail.Name = "Cmb_Komail"
        Me.Cmb_Komail.Size = New System.Drawing.Size(360, 22)
        Me.Cmb_Komail.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Komail.TabIndex = 8
        '
        'Dtp_Mailini
        '
        '
        '
        '
        Me.Dtp_Mailini.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Mailini.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Mailini.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Mailini.ButtonDropDown.Visible = True
        Me.Dtp_Mailini.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Mailini.IsPopupCalendarOpen = False
        Me.Dtp_Mailini.Location = New System.Drawing.Point(141, 53)
        '
        '
        '
        Me.Dtp_Mailini.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Mailini.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Mailini.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Mailini.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Mailini.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Mailini.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Mailini.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Mailini.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Mailini.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Mailini.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Mailini.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Mailini.MonthCalendar.DisplayMonth = New Date(2020, 11, 1, 0, 0, 0, 0)
        Me.Dtp_Mailini.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_Mailini.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Mailini.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Mailini.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Mailini.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Mailini.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Mailini.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Mailini.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Mailini.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Mailini.Name = "Dtp_Mailini"
        Me.Dtp_Mailini.Size = New System.Drawing.Size(78, 22)
        Me.Dtp_Mailini.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Mailini.TabIndex = 46
        Me.Dtp_Mailini.Value = New Date(2020, 11, 13, 11, 47, 43, 0)
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(3, 78)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(117, 19)
        Me.LabelX6.TabIndex = 10
        Me.LabelX6.Text = "Email"
        '
        'Txt_Mailto
        '
        Me.Txt_Mailto.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Mailto.Border.Class = "TextBoxBorder"
        Me.Txt_Mailto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Mailto.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Mailto.ForeColor = System.Drawing.Color.Black
        Me.Txt_Mailto.Location = New System.Drawing.Point(141, 78)
        Me.Txt_Mailto.MaxLength = 50
        Me.Txt_Mailto.Name = "Txt_Mailto"
        Me.Txt_Mailto.PreventEnterBeep = True
        Me.Txt_Mailto.Size = New System.Drawing.Size(360, 22)
        Me.Txt_Mailto.TabIndex = 1
        '
        'LabelX9
        '
        Me.LabelX9.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.ForeColor = System.Drawing.Color.Black
        Me.LabelX9.Location = New System.Drawing.Point(3, 103)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(117, 19)
        Me.LabelX9.TabIndex = 11
        Me.LabelX9.Text = "Nombre destinatario"
        '
        'LabelX8
        '
        Me.LabelX8.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.ForeColor = System.Drawing.Color.Black
        Me.LabelX8.Location = New System.Drawing.Point(3, 128)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(117, 19)
        Me.LabelX8.TabIndex = 12
        Me.LabelX8.Text = "Copia de emial"
        '
        'Txt_Nameto
        '
        Me.Txt_Nameto.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Nameto.Border.Class = "TextBoxBorder"
        Me.Txt_Nameto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Nameto.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Nameto.ForeColor = System.Drawing.Color.Black
        Me.Txt_Nameto.Location = New System.Drawing.Point(141, 103)
        Me.Txt_Nameto.MaxLength = 50
        Me.Txt_Nameto.Name = "Txt_Nameto"
        Me.Txt_Nameto.PreventEnterBeep = True
        Me.Txt_Nameto.Size = New System.Drawing.Size(360, 22)
        Me.Txt_Nameto.TabIndex = 2
        '
        'Txt_Mailcc
        '
        Me.Txt_Mailcc.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Mailcc.Border.Class = "TextBoxBorder"
        Me.Txt_Mailcc.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Mailcc.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Mailcc.ForeColor = System.Drawing.Color.Black
        Me.Txt_Mailcc.Location = New System.Drawing.Point(141, 128)
        Me.Txt_Mailcc.MaxLength = 50
        Me.Txt_Mailcc.Name = "Txt_Mailcc"
        Me.Txt_Mailcc.PreventEnterBeep = True
        Me.Txt_Mailcc.Size = New System.Drawing.Size(360, 22)
        Me.Txt_Mailcc.TabIndex = 3
        '
        'Txt_Namecc
        '
        Me.Txt_Namecc.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Namecc.Border.Class = "TextBoxBorder"
        Me.Txt_Namecc.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Namecc.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Namecc.ForeColor = System.Drawing.Color.Black
        Me.Txt_Namecc.Location = New System.Drawing.Point(141, 153)
        Me.Txt_Namecc.MaxLength = 50
        Me.Txt_Namecc.Name = "Txt_Namecc"
        Me.Txt_Namecc.PreventEnterBeep = True
        Me.Txt_Namecc.Size = New System.Drawing.Size(360, 22)
        Me.Txt_Namecc.TabIndex = 4
        '
        'Txt_Mailcc2
        '
        Me.Txt_Mailcc2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Mailcc2.Border.Class = "TextBoxBorder"
        Me.Txt_Mailcc2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Mailcc2.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Mailcc2.ForeColor = System.Drawing.Color.Black
        Me.Txt_Mailcc2.Location = New System.Drawing.Point(141, 178)
        Me.Txt_Mailcc2.MaxLength = 50
        Me.Txt_Mailcc2.Name = "Txt_Mailcc2"
        Me.Txt_Mailcc2.PreventEnterBeep = True
        Me.Txt_Mailcc2.Size = New System.Drawing.Size(360, 22)
        Me.Txt_Mailcc2.TabIndex = 5
        '
        'Txt_Namecc2
        '
        Me.Txt_Namecc2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Namecc2.Border.Class = "TextBoxBorder"
        Me.Txt_Namecc2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Namecc2.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Namecc2.ForeColor = System.Drawing.Color.Black
        Me.Txt_Namecc2.Location = New System.Drawing.Point(141, 203)
        Me.Txt_Namecc2.MaxLength = 50
        Me.Txt_Namecc2.Name = "Txt_Namecc2"
        Me.Txt_Namecc2.PreventEnterBeep = True
        Me.Txt_Namecc2.Size = New System.Drawing.Size(360, 22)
        Me.Txt_Namecc2.TabIndex = 6
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.ForeColor = System.Drawing.Color.Black
        Me.LabelX7.Location = New System.Drawing.Point(3, 153)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(117, 19)
        Me.LabelX7.TabIndex = 11
        Me.LabelX7.Text = "Nombre destinatario CC"
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(3, 178)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(117, 19)
        Me.LabelX5.TabIndex = 11
        Me.LabelX5.Text = "Copia de emial-2 "
        '
        'LabelX10
        '
        Me.LabelX10.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.ForeColor = System.Drawing.Color.Black
        Me.LabelX10.Location = New System.Drawing.Point(3, 203)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(132, 20)
        Me.LabelX10.TabIndex = 45
        Me.LabelX10.Text = "Nombre destinatario CC-2"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Agregar_cta})
        Me.Bar1.Location = New System.Drawing.Point(0, 272)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(539, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 41
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Agregar_cta
        '
        Me.Btn_Agregar_cta.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Agregar_cta.ForeColor = System.Drawing.Color.Black
        Me.Btn_Agregar_cta.Image = CType(resources.GetObject("Btn_Agregar_cta.Image"), System.Drawing.Image)
        Me.Btn_Agregar_cta.ImageAlt = CType(resources.GetObject("Btn_Agregar_cta.ImageAlt"), System.Drawing.Image)
        Me.Btn_Agregar_cta.Name = "Btn_Agregar_cta"
        Me.Btn_Agregar_cta.Text = "Aceptar"
        '
        'Frm_Crear_Entidad_Mt_Noficicaiones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(539, 313)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Crear_Entidad_Mt_Noficicaiones"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NOTIFICACIONES"
        Me.GroupPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.Dtp_Mailini, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Cmb_Komail As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Public WithEvents Btn_Agregar_cta As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Cmb_Suen As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Dtp_Mailini As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Public WithEvents Txt_Mailto As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Txt_Mailcc As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Txt_Namecc2 As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Txt_Mailcc2 As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Txt_Namecc As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Txt_Nameto As DevComponents.DotNetBar.Controls.TextBoxX
End Class
