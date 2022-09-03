<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Pago_Masivo_Autoriza_Enc
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Pago_Masivo_Autoriza_Enc))
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar_Autorizacion = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Txt_Total = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Referencia = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Cmb_Tipo_Pago = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Dtp_Fecha_Asignacion_Pago = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Dtp_Fecha_Asignacion_Pago, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar_Autorizacion})
        Me.Bar1.Location = New System.Drawing.Point(0, 192)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(433, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 46
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Grabar_Autorizacion
        '
        Me.Btn_Grabar_Autorizacion.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar_Autorizacion.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar_Autorizacion.Image = CType(resources.GetObject("Btn_Grabar_Autorizacion.Image"), System.Drawing.Image)
        Me.Btn_Grabar_Autorizacion.Name = "Btn_Grabar_Autorizacion"
        Me.Btn_Grabar_Autorizacion.Tooltip = "Autorizar documentos a pagar (crear código de autorización)"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Txt_Total)
        Me.GroupPanel1.Controls.Add(Me.LabelX4)
        Me.GroupPanel1.Controls.Add(Me.Txt_Referencia)
        Me.GroupPanel1.Controls.Add(Me.LabelX3)
        Me.GroupPanel1.Controls.Add(Me.LabelX2)
        Me.GroupPanel1.Controls.Add(Me.LabelX1)
        Me.GroupPanel1.Controls.Add(Me.Cmb_Tipo_Pago)
        Me.GroupPanel1.Controls.Add(Me.Dtp_Fecha_Asignacion_Pago)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 2)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(409, 181)
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
        Me.GroupPanel1.TabIndex = 47
        Me.GroupPanel1.Text = "Condiciones"
        '
        'Txt_Total
        '
        Me.Txt_Total.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Total.Border.Class = "TextBoxBorder"
        Me.Txt_Total.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Total.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Total.ForeColor = System.Drawing.Color.Black
        Me.Txt_Total.Location = New System.Drawing.Point(93, 127)
        Me.Txt_Total.Name = "Txt_Total"
        Me.Txt_Total.PreventEnterBeep = True
        Me.Txt_Total.ReadOnly = True
        Me.Txt_Total.Size = New System.Drawing.Size(100, 22)
        Me.Txt_Total.TabIndex = 52
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(12, 126)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(75, 23)
        Me.LabelX4.TabIndex = 51
        Me.LabelX4.Text = "Total"
        Me.LabelX4.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Txt_Referencia
        '
        Me.Txt_Referencia.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Referencia.Border.Class = "TextBoxBorder"
        Me.Txt_Referencia.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Referencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Referencia.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Referencia.FocusHighlightEnabled = True
        Me.Txt_Referencia.ForeColor = System.Drawing.Color.Black
        Me.Txt_Referencia.Location = New System.Drawing.Point(93, 18)
        Me.Txt_Referencia.MaxLength = 100
        Me.Txt_Referencia.Multiline = True
        Me.Txt_Referencia.Name = "Txt_Referencia"
        Me.Txt_Referencia.PreventEnterBeep = True
        Me.Txt_Referencia.Size = New System.Drawing.Size(307, 45)
        Me.Txt_Referencia.TabIndex = 50
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(12, 15)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(75, 23)
        Me.LabelX3.TabIndex = 49
        Me.LabelX3.Text = "Referencia"
        Me.LabelX3.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(12, 98)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 23)
        Me.LabelX2.TabIndex = 48
        Me.LabelX2.Text = "Tipo de pago"
        Me.LabelX2.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(12, 69)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 23)
        Me.LabelX1.TabIndex = 2
        Me.LabelX1.Text = "Fecha de pago"
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Cmb_Tipo_Pago
        '
        Me.Cmb_Tipo_Pago.DisplayMember = "Text"
        Me.Cmb_Tipo_Pago.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Tipo_Pago.FocusHighlightEnabled = True
        Me.Cmb_Tipo_Pago.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Tipo_Pago.FormattingEnabled = True
        Me.Cmb_Tipo_Pago.ItemHeight = 16
        Me.Cmb_Tipo_Pago.Location = New System.Drawing.Point(93, 97)
        Me.Cmb_Tipo_Pago.Name = "Cmb_Tipo_Pago"
        Me.Cmb_Tipo_Pago.Size = New System.Drawing.Size(129, 22)
        Me.Cmb_Tipo_Pago.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Tipo_Pago.TabIndex = 1
        '
        'Dtp_Fecha_Asignacion_Pago
        '
        Me.Dtp_Fecha_Asignacion_Pago.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_Fecha_Asignacion_Pago.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Asignacion_Pago.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Asignacion_Pago.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Asignacion_Pago.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Asignacion_Pago.FocusHighlightEnabled = True
        Me.Dtp_Fecha_Asignacion_Pago.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Asignacion_Pago.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Asignacion_Pago.Location = New System.Drawing.Point(93, 69)
        '
        '
        '
        Me.Dtp_Fecha_Asignacion_Pago.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Asignacion_Pago.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Asignacion_Pago.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Asignacion_Pago.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Asignacion_Pago.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Asignacion_Pago.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Asignacion_Pago.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Asignacion_Pago.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Asignacion_Pago.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Asignacion_Pago.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Asignacion_Pago.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Asignacion_Pago.MonthCalendar.DisplayMonth = New Date(2018, 1, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Asignacion_Pago.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Asignacion_Pago.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Asignacion_Pago.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Asignacion_Pago.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Asignacion_Pago.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Asignacion_Pago.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Asignacion_Pago.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Asignacion_Pago.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Asignacion_Pago.Name = "Dtp_Fecha_Asignacion_Pago"
        Me.Dtp_Fecha_Asignacion_Pago.Size = New System.Drawing.Size(87, 22)
        Me.Dtp_Fecha_Asignacion_Pago.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Asignacion_Pago.TabIndex = 0
        Me.Dtp_Fecha_Asignacion_Pago.Value = New Date(2018, 1, 15, 16, 49, 16, 0)
        '
        'Frm_Pago_Masivo_Autoriza_Enc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(433, 233)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Pago_Masivo_Autoriza_Enc"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Autorización de pago a proveedores"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.Dtp_Fecha_Asignacion_Pago, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar_Autorizacion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Dtp_Fecha_Asignacion_Pago As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Cmb_Tipo_Pago As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Referencia As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Total As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
End Class
