<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Crear_Entidad_Mt_Puntos
    Inherits DevComponents.DotNetBar.Metro.MetroForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Crear_Entidad_Mt_Puntos))
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Aceptar = New DevComponents.DotNetBar.ButtonItem()
        Me.Txt_EmailPuntos = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX20 = New DevComponents.DotNetBar.LabelX()
        Me.Chk_JuntaPuntos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Dtp_FechaInscripPuntos = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_FechaInscripPuntos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Aceptar})
        Me.Bar1.Location = New System.Drawing.Point(0, 78)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(486, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 49
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Aceptar.ForeColor = System.Drawing.Color.Navy
        Me.Btn_Aceptar.Image = CType(resources.GetObject("Btn_Aceptar.Image"), System.Drawing.Image)
        Me.Btn_Aceptar.ImageAlt = CType(resources.GetObject("Btn_Aceptar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Text = "Aceptar"
        Me.Btn_Aceptar.Tooltip = "Aceptar"
        '
        'Txt_EmailPuntos
        '
        Me.Txt_EmailPuntos.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_EmailPuntos.Border.Class = "TextBoxBorder"
        Me.Txt_EmailPuntos.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_EmailPuntos.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.Txt_EmailPuntos.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_EmailPuntos.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_EmailPuntos.ForeColor = System.Drawing.Color.Black
        Me.Txt_EmailPuntos.Location = New System.Drawing.Point(52, 16)
        Me.Txt_EmailPuntos.Name = "Txt_EmailPuntos"
        Me.Txt_EmailPuntos.Size = New System.Drawing.Size(422, 22)
        Me.Txt_EmailPuntos.TabIndex = 52
        Me.Txt_EmailPuntos.WatermarkText = "Correo de contactos para los puntos..."
        '
        'LabelX20
        '
        Me.LabelX20.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX20.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX20.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX20.ForeColor = System.Drawing.Color.Black
        Me.LabelX20.Location = New System.Drawing.Point(12, 15)
        Me.LabelX20.Name = "LabelX20"
        Me.LabelX20.Size = New System.Drawing.Size(34, 23)
        Me.LabelX20.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX20.TabIndex = 53
        Me.LabelX20.Text = "Email"
        '
        'Chk_JuntaPuntos
        '
        Me.Chk_JuntaPuntos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_JuntaPuntos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_JuntaPuntos.CheckBoxImageChecked = CType(resources.GetObject("Chk_JuntaPuntos.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_JuntaPuntos.FocusCuesEnabled = False
        Me.Chk_JuntaPuntos.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Chk_JuntaPuntos.ForeColor = System.Drawing.Color.Black
        Me.Chk_JuntaPuntos.Location = New System.Drawing.Point(12, 44)
        Me.Chk_JuntaPuntos.Name = "Chk_JuntaPuntos"
        Me.Chk_JuntaPuntos.Size = New System.Drawing.Size(86, 22)
        Me.Chk_JuntaPuntos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_JuntaPuntos.TabIndex = 54
        Me.Chk_JuntaPuntos.TabStop = False
        Me.Chk_JuntaPuntos.Text = "Junta puntos"
        '
        'Dtp_FechaInscripPuntos
        '
        Me.Dtp_FechaInscripPuntos.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_FechaInscripPuntos.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_FechaInscripPuntos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaInscripPuntos.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_FechaInscripPuntos.ButtonDropDown.Visible = True
        Me.Dtp_FechaInscripPuntos.ForeColor = System.Drawing.Color.Black
        Me.Dtp_FechaInscripPuntos.IsPopupCalendarOpen = False
        Me.Dtp_FechaInscripPuntos.Location = New System.Drawing.Point(393, 45)
        '
        '
        '
        Me.Dtp_FechaInscripPuntos.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FechaInscripPuntos.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaInscripPuntos.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_FechaInscripPuntos.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_FechaInscripPuntos.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_FechaInscripPuntos.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FechaInscripPuntos.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_FechaInscripPuntos.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_FechaInscripPuntos.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_FechaInscripPuntos.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_FechaInscripPuntos.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaInscripPuntos.MonthCalendar.DisplayMonth = New Date(2020, 11, 1, 0, 0, 0, 0)
        Me.Dtp_FechaInscripPuntos.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_FechaInscripPuntos.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_FechaInscripPuntos.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FechaInscripPuntos.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_FechaInscripPuntos.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FechaInscripPuntos.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_FechaInscripPuntos.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaInscripPuntos.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_FechaInscripPuntos.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_FechaInscripPuntos.Name = "Dtp_FechaInscripPuntos"
        Me.Dtp_FechaInscripPuntos.Size = New System.Drawing.Size(81, 22)
        Me.Dtp_FechaInscripPuntos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_FechaInscripPuntos.TabIndex = 76
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
        Me.LabelX1.Location = New System.Drawing.Point(285, 44)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(102, 23)
        Me.LabelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX1.TabIndex = 77
        Me.LabelX1.Text = "Fecha inscripción"
        '
        'Frm_Crear_Entidad_Mt_Puntos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(486, 119)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Dtp_FechaInscripPuntos)
        Me.Controls.Add(Me.Chk_JuntaPuntos)
        Me.Controls.Add(Me.Txt_EmailPuntos)
        Me.Controls.Add(Me.LabelX20)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Crear_Entidad_Mt_Puntos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_FechaInscripPuntos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Aceptar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX20 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_EmailPuntos As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Chk_JuntaPuntos As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Dtp_FechaInscripPuntos As DevComponents.Editors.DateTimeAdv.DateTimeInput
End Class
