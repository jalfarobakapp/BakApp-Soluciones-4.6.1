<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Referencia_DTE_Det
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Referencia_DTE_Det))
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Lbl_CodRef = New DevComponents.DotNetBar.LabelX()
        Me.Cmb_CodRef = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_FchRef = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Cmb_TpoDocRef = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Txt_RazonRef = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_FolioRef = New DevComponents.DotNetBar.Controls.TextBoxX()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.Dtp_FchRef, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar})
        Me.Bar1.Location = New System.Drawing.Point(0, 168)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(653, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 43
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.ImageAlt = CType(resources.GetObject("Btn_Grabar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Tooltip = "Grabar"
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Lbl_CodRef)
        Me.GroupPanel2.Controls.Add(Me.Cmb_CodRef)
        Me.GroupPanel2.Controls.Add(Me.LabelX4)
        Me.GroupPanel2.Controls.Add(Me.Dtp_FchRef)
        Me.GroupPanel2.Controls.Add(Me.LabelX1)
        Me.GroupPanel2.Controls.Add(Me.Cmb_TpoDocRef)
        Me.GroupPanel2.Controls.Add(Me.Txt_RazonRef)
        Me.GroupPanel2.Controls.Add(Me.LabelX2)
        Me.GroupPanel2.Controls.Add(Me.LabelX3)
        Me.GroupPanel2.Controls.Add(Me.Txt_FolioRef)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(629, 151)
        '
        '
        '
        Me.GroupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel2.Style.BackColorGradientAngle = 90
        Me.GroupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderBottomWidth = 1
        Me.GroupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderLeftWidth = 1
        Me.GroupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderRightWidth = 1
        Me.GroupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderTopWidth = 1
        Me.GroupPanel2.Style.CornerDiameter = 4
        Me.GroupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel2.TabIndex = 44
        '
        'Lbl_CodRef
        '
        Me.Lbl_CodRef.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_CodRef.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_CodRef.ForeColor = System.Drawing.Color.Black
        Me.Lbl_CodRef.Location = New System.Drawing.Point(3, 87)
        Me.Lbl_CodRef.Name = "Lbl_CodRef"
        Me.Lbl_CodRef.Size = New System.Drawing.Size(89, 23)
        Me.Lbl_CodRef.TabIndex = 40
        Me.Lbl_CodRef.Text = "Código Ref."
        '
        'Cmb_CodRef
        '
        Me.Cmb_CodRef.DisplayMember = "Text"
        Me.Cmb_CodRef.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_CodRef.ForeColor = System.Drawing.Color.Black
        Me.Cmb_CodRef.FormattingEnabled = True
        Me.Cmb_CodRef.ItemHeight = 16
        Me.Cmb_CodRef.Location = New System.Drawing.Point(98, 88)
        Me.Cmb_CodRef.Name = "Cmb_CodRef"
        Me.Cmb_CodRef.Size = New System.Drawing.Size(229, 22)
        Me.Cmb_CodRef.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_CodRef.TabIndex = 39
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(6, 58)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(89, 23)
        Me.LabelX4.TabIndex = 38
        Me.LabelX4.Text = "Fecha Ref."
        '
        'Dtp_FchRef
        '
        Me.Dtp_FchRef.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_FchRef.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_FchRef.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FchRef.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_FchRef.ButtonDropDown.Visible = True
        Me.Dtp_FchRef.ForeColor = System.Drawing.Color.Black
        Me.Dtp_FchRef.IsPopupCalendarOpen = False
        Me.Dtp_FchRef.Location = New System.Drawing.Point(98, 59)
        '
        '
        '
        Me.Dtp_FchRef.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FchRef.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FchRef.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_FchRef.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_FchRef.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_FchRef.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FchRef.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_FchRef.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_FchRef.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_FchRef.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_FchRef.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FchRef.MonthCalendar.DisplayMonth = New Date(2014, 10, 1, 0, 0, 0, 0)
        Me.Dtp_FchRef.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_FchRef.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_FchRef.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FchRef.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_FchRef.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FchRef.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_FchRef.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FchRef.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_FchRef.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_FchRef.Name = "Dtp_FchRef"
        Me.Dtp_FchRef.Size = New System.Drawing.Size(85, 22)
        Me.Dtp_FchRef.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_FchRef.TabIndex = 37
        Me.Dtp_FchRef.Value = New Date(2014, 10, 1, 18, 45, 8, 0)
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 2)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(89, 23)
        Me.LabelX1.TabIndex = 5
        Me.LabelX1.Text = "Tipo doc. Ref."
        '
        'Cmb_TpoDocRef
        '
        Me.Cmb_TpoDocRef.DisplayMember = "Text"
        Me.Cmb_TpoDocRef.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_TpoDocRef.ForeColor = System.Drawing.Color.Black
        Me.Cmb_TpoDocRef.FormattingEnabled = True
        Me.Cmb_TpoDocRef.ItemHeight = 16
        Me.Cmb_TpoDocRef.Location = New System.Drawing.Point(98, 3)
        Me.Cmb_TpoDocRef.Name = "Cmb_TpoDocRef"
        Me.Cmb_TpoDocRef.Size = New System.Drawing.Size(163, 22)
        Me.Cmb_TpoDocRef.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_TpoDocRef.TabIndex = 4
        '
        'Txt_RazonRef
        '
        Me.Txt_RazonRef.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_RazonRef.Border.Class = "TextBoxBorder"
        Me.Txt_RazonRef.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_RazonRef.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_RazonRef.ForeColor = System.Drawing.Color.Black
        Me.Txt_RazonRef.Location = New System.Drawing.Point(98, 116)
        Me.Txt_RazonRef.MaxLength = 90
        Me.Txt_RazonRef.Name = "Txt_RazonRef"
        Me.Txt_RazonRef.PreventEnterBeep = True
        Me.Txt_RazonRef.Size = New System.Drawing.Size(522, 22)
        Me.Txt_RazonRef.TabIndex = 3
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(6, 31)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(89, 23)
        Me.LabelX2.TabIndex = 0
        Me.LabelX2.Text = "Folio Ref."
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(3, 115)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(89, 23)
        Me.LabelX3.TabIndex = 2
        Me.LabelX3.Text = "Descripción Ref."
        '
        'Txt_FolioRef
        '
        Me.Txt_FolioRef.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_FolioRef.Border.Class = "TextBoxBorder"
        Me.Txt_FolioRef.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_FolioRef.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_FolioRef.ForeColor = System.Drawing.Color.Black
        Me.Txt_FolioRef.Location = New System.Drawing.Point(98, 31)
        Me.Txt_FolioRef.MaxLength = 30
        Me.Txt_FolioRef.Name = "Txt_FolioRef"
        Me.Txt_FolioRef.PreventEnterBeep = True
        Me.Txt_FolioRef.Size = New System.Drawing.Size(85, 22)
        Me.Txt_FolioRef.TabIndex = 1
        '
        'Frm_Referencia_DTE_Det
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(653, 209)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Referencia_DTE_Det"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REFERENCIA PARA ARCHIVO XML DTE SII"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.Dtp_FchRef, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Cmb_TpoDocRef As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Txt_RazonRef As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_FolioRef As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Public WithEvents Dtp_FchRef As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Lbl_CodRef As DevComponents.DotNetBar.LabelX
    Friend WithEvents Cmb_CodRef As DevComponents.DotNetBar.Controls.ComboBoxEx
End Class
