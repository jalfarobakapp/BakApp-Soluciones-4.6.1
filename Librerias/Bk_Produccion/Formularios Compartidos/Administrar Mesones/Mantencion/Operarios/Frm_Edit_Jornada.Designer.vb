<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Edit_Jornada
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Edit_Jornada))
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Cmb_Dia = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Input_Max_HhExtra = New DevComponents.Editors.IntegerInput()
        Me.Dtp_Hora_Salida = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Lbl_Hora_Termino = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_Hora_Entrada = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Input_Max_HhExtra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_Hora_Salida, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_Hora_Entrada, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar})
        Me.Bar1.Location = New System.Drawing.Point(0, 87)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(506, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 28
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Tooltip = "Grabar"
        Me.Btn_Grabar.Visible = False
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Cmb_Dia)
        Me.GroupPanel1.Controls.Add(Me.LabelX3)
        Me.GroupPanel1.Controls.Add(Me.Input_Max_HhExtra)
        Me.GroupPanel1.Controls.Add(Me.Dtp_Hora_Salida)
        Me.GroupPanel1.Controls.Add(Me.Lbl_Hora_Termino)
        Me.GroupPanel1.Controls.Add(Me.LabelX1)
        Me.GroupPanel1.Controls.Add(Me.LabelX2)
        Me.GroupPanel1.Controls.Add(Me.Dtp_Hora_Entrada)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 6)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(481, 65)
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
        Me.GroupPanel1.TabIndex = 27
        '
        'Cmb_Dia
        '
        Me.Cmb_Dia.DisplayMember = "Text"
        Me.Cmb_Dia.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Dia.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Dia.FormattingEnabled = True
        Me.Cmb_Dia.ItemHeight = 16
        Me.Cmb_Dia.Location = New System.Drawing.Point(3, 28)
        Me.Cmb_Dia.Name = "Cmb_Dia"
        Me.Cmb_Dia.Size = New System.Drawing.Size(150, 22)
        Me.Cmb_Dia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Dia.TabIndex = 137
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(327, 1)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(138, 23)
        Me.LabelX3.TabIndex = 99
        Me.LabelX3.Text = "Máximo Horas Extra por día"
        '
        'Input_Max_HhExtra
        '
        Me.Input_Max_HhExtra.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_Max_HhExtra.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_Max_HhExtra.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_Max_HhExtra.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.Input_Max_HhExtra.ForeColor = System.Drawing.Color.Black
        Me.Input_Max_HhExtra.Location = New System.Drawing.Point(361, 28)
        Me.Input_Max_HhExtra.MaxValue = 8
        Me.Input_Max_HhExtra.MinValue = 0
        Me.Input_Max_HhExtra.Name = "Input_Max_HhExtra"
        Me.Input_Max_HhExtra.ShowUpDown = True
        Me.Input_Max_HhExtra.Size = New System.Drawing.Size(61, 22)
        Me.Input_Max_HhExtra.TabIndex = 100
        '
        'Dtp_Hora_Salida
        '
        Me.Dtp_Hora_Salida.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_Hora_Salida.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Hora_Salida.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Hora_Salida.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Hora_Salida.ButtonDropDown.Visible = True
        Me.Dtp_Hora_Salida.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Hora_Salida.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime
        Me.Dtp_Hora_Salida.IsPopupCalendarOpen = False
        Me.Dtp_Hora_Salida.Location = New System.Drawing.Point(248, 28)
        '
        '
        '
        Me.Dtp_Hora_Salida.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Hora_Salida.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Hora_Salida.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Hora_Salida.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Hora_Salida.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Hora_Salida.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Hora_Salida.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Hora_Salida.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Hora_Salida.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Hora_Salida.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Hora_Salida.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Hora_Salida.MonthCalendar.DisplayMonth = New Date(2018, 8, 1, 0, 0, 0, 0)
        Me.Dtp_Hora_Salida.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_Hora_Salida.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Hora_Salida.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Hora_Salida.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Hora_Salida.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Hora_Salida.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Hora_Salida.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Hora_Salida.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Hora_Salida.MonthCalendar.Visible = False
        Me.Dtp_Hora_Salida.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Hora_Salida.Name = "Dtp_Hora_Salida"
        Me.Dtp_Hora_Salida.Size = New System.Drawing.Size(60, 22)
        Me.Dtp_Hora_Salida.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Hora_Salida.TabIndex = 5
        Me.Dtp_Hora_Salida.Value = New Date(2018, 8, 7, 11, 47, 57, 0)
        '
        'Lbl_Hora_Termino
        '
        Me.Lbl_Hora_Termino.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Hora_Termino.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Hora_Termino.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Hora_Termino.Location = New System.Drawing.Point(248, 2)
        Me.Lbl_Hora_Termino.Name = "Lbl_Hora_Termino"
        Me.Lbl_Hora_Termino.Size = New System.Drawing.Size(75, 20)
        Me.Lbl_Hora_Termino.TabIndex = 4
        Me.Lbl_Hora_Termino.Text = "Hora salida"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(4, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 19)
        Me.LabelX1.TabIndex = 2
        Me.LabelX1.Text = "Día"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(162, 3)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 19)
        Me.LabelX2.TabIndex = 3
        Me.LabelX2.Text = "Hora entrada"
        '
        'Dtp_Hora_Entrada
        '
        Me.Dtp_Hora_Entrada.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_Hora_Entrada.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Hora_Entrada.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Hora_Entrada.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Hora_Entrada.ButtonDropDown.Visible = True
        Me.Dtp_Hora_Entrada.Enabled = False
        Me.Dtp_Hora_Entrada.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Hora_Entrada.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime
        Me.Dtp_Hora_Entrada.IsPopupCalendarOpen = False
        Me.Dtp_Hora_Entrada.Location = New System.Drawing.Point(162, 28)
        '
        '
        '
        Me.Dtp_Hora_Entrada.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Hora_Entrada.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Hora_Entrada.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Hora_Entrada.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Hora_Entrada.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Hora_Entrada.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Hora_Entrada.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Hora_Entrada.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Hora_Entrada.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Hora_Entrada.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Hora_Entrada.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Hora_Entrada.MonthCalendar.DisplayMonth = New Date(2018, 8, 1, 0, 0, 0, 0)
        Me.Dtp_Hora_Entrada.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_Hora_Entrada.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Hora_Entrada.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Hora_Entrada.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Hora_Entrada.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Hora_Entrada.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Hora_Entrada.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Hora_Entrada.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Hora_Entrada.MonthCalendar.Visible = False
        Me.Dtp_Hora_Entrada.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Hora_Entrada.Name = "Dtp_Hora_Entrada"
        Me.Dtp_Hora_Entrada.Size = New System.Drawing.Size(60, 22)
        Me.Dtp_Hora_Entrada.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Hora_Entrada.TabIndex = 4
        Me.Dtp_Hora_Entrada.Value = New Date(2018, 8, 7, 11, 47, 57, 0)
        '
        'Frm_Edit_Jornada
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(506, 128)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.GroupPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Edit_Jornada"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.Input_Max_HhExtra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_Hora_Salida, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_Hora_Entrada, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Public WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Dtp_Hora_Salida As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Public WithEvents Lbl_Hora_Termino As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Public WithEvents Dtp_Hora_Entrada As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Input_Max_HhExtra As DevComponents.Editors.IntegerInput
    Public WithEvents Cmb_Dia As DevComponents.DotNetBar.Controls.ComboBoxEx
End Class
