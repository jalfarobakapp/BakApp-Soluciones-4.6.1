<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_MonedasFicha
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_MonedasFicha))
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Eliminar = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_Femo = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Cmb_Timo = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Vamo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Komo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Nokomo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Dtp_Femo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar, Me.Btn_Eliminar})
        Me.Bar2.Location = New System.Drawing.Point(0, 184)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(458, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 104
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Tooltip = "Grabar"
        '
        'Btn_Eliminar
        '
        Me.Btn_Eliminar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Eliminar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Eliminar.Image = CType(resources.GetObject("Btn_Eliminar.Image"), System.Drawing.Image)
        Me.Btn_Eliminar.ImageAlt = CType(resources.GetObject("Btn_Eliminar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Eliminar.Name = "Btn_Eliminar"
        Me.Btn_Eliminar.Tooltip = "Eliminar"
        Me.Btn_Eliminar.Visible = False
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.LabelX5)
        Me.GroupPanel1.Controls.Add(Me.Dtp_Femo)
        Me.GroupPanel1.Controls.Add(Me.Cmb_Timo)
        Me.GroupPanel1.Controls.Add(Me.LabelX9)
        Me.GroupPanel1.Controls.Add(Me.Txt_Vamo)
        Me.GroupPanel1.Controls.Add(Me.LabelX4)
        Me.GroupPanel1.Controls.Add(Me.Txt_Komo)
        Me.GroupPanel1.Controls.Add(Me.Txt_Nokomo)
        Me.GroupPanel1.Controls.Add(Me.LabelX2)
        Me.GroupPanel1.Controls.Add(Me.LabelX1)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(434, 155)
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
        Me.GroupPanel1.TabIndex = 105
        Me.GroupPanel1.Text = "Detalle de la moneda"
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
        Me.LabelX5.Location = New System.Drawing.Point(3, 94)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(155, 23)
        Me.LabelX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX5.TabIndex = 84
        Me.LabelX5.Text = "Fecha ultima actualización"
        '
        'Dtp_Femo
        '
        Me.Dtp_Femo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_Femo.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Femo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Femo.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Femo.ButtonDropDown.Visible = True
        Me.Dtp_Femo.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Femo.IsPopupCalendarOpen = False
        Me.Dtp_Femo.Location = New System.Drawing.Point(164, 97)
        '
        '
        '
        Me.Dtp_Femo.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Femo.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Femo.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Femo.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Femo.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Femo.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Femo.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Femo.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Femo.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Femo.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Femo.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Femo.MonthCalendar.DisplayMonth = New Date(2016, 7, 1, 0, 0, 0, 0)
        Me.Dtp_Femo.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_Femo.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Femo.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Femo.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Femo.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Femo.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Femo.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Femo.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Femo.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Femo.Name = "Dtp_Femo"
        Me.Dtp_Femo.Size = New System.Drawing.Size(86, 22)
        Me.Dtp_Femo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Femo.TabIndex = 4
        Me.Dtp_Femo.Value = New Date(2016, 7, 8, 16, 32, 31, 0)
        '
        'Cmb_Timo
        '
        Me.Cmb_Timo.DisplayMember = "Text"
        Me.Cmb_Timo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Timo.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Cmb_Timo.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Timo.ItemHeight = 16
        Me.Cmb_Timo.Location = New System.Drawing.Point(286, 8)
        Me.Cmb_Timo.Name = "Cmb_Timo"
        Me.Cmb_Timo.Size = New System.Drawing.Size(124, 22)
        Me.Cmb_Timo.TabIndex = 1
        '
        'LabelX9
        '
        Me.LabelX9.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX9.ForeColor = System.Drawing.Color.Black
        Me.LabelX9.Location = New System.Drawing.Point(252, 4)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(38, 23)
        Me.LabelX9.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX9.TabIndex = 82
        Me.LabelX9.Text = "Tipo"
        '
        'Txt_Vamo
        '
        Me.Txt_Vamo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Vamo.Border.Class = "TextBoxBorder"
        Me.Txt_Vamo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Vamo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Vamo.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Vamo.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Vamo.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Txt_Vamo.ForeColor = System.Drawing.Color.Black
        Me.Txt_Vamo.Location = New System.Drawing.Point(164, 69)
        Me.Txt_Vamo.MaxLength = 20
        Me.Txt_Vamo.Name = "Txt_Vamo"
        Me.Txt_Vamo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Vamo.Size = New System.Drawing.Size(81, 22)
        Me.Txt_Vamo.TabIndex = 3
        Me.Txt_Vamo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(3, 65)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(134, 23)
        Me.LabelX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX4.TabIndex = 74
        Me.LabelX4.Text = "Valor de la moneda"
        '
        'Txt_Komo
        '
        Me.Txt_Komo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Komo.Border.Class = "TextBoxBorder"
        Me.Txt_Komo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Komo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Komo.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Komo.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Komo.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Txt_Komo.ForeColor = System.Drawing.Color.Black
        Me.Txt_Komo.Location = New System.Drawing.Point(164, 8)
        Me.Txt_Komo.MaxLength = 13
        Me.Txt_Komo.Name = "Txt_Komo"
        Me.Txt_Komo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Komo.Size = New System.Drawing.Size(65, 22)
        Me.Txt_Komo.TabIndex = 0
        '
        'Txt_Nokomo
        '
        Me.Txt_Nokomo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Nokomo.Border.Class = "TextBoxBorder"
        Me.Txt_Nokomo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Nokomo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Nokomo.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Nokomo.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Nokomo.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Txt_Nokomo.ForeColor = System.Drawing.Color.Black
        Me.Txt_Nokomo.Location = New System.Drawing.Point(164, 40)
        Me.Txt_Nokomo.MaxLength = 50
        Me.Txt_Nokomo.Name = "Txt_Nokomo"
        Me.Txt_Nokomo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Nokomo.Size = New System.Drawing.Size(246, 22)
        Me.Txt_Nokomo.TabIndex = 2
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
        Me.LabelX2.Location = New System.Drawing.Point(3, 3)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(144, 23)
        Me.LabelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX2.TabIndex = 64
        Me.LabelX2.Text = "Código de la moneda"
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
        Me.LabelX1.Location = New System.Drawing.Point(3, 36)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(150, 23)
        Me.LabelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX1.TabIndex = 69
        Me.LabelX1.Text = "Nombre de la moneda"
        '
        'Frm_MonedasFicha
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(458, 225)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_MonedasFicha"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MANTENCION DE MONEDA"
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.Dtp_Femo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Eliminar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Komo As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Txt_Nokomo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Vamo As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Cmb_Timo As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dtp_Femo As DevComponents.Editors.DateTimeAdv.DateTimeInput
End Class
