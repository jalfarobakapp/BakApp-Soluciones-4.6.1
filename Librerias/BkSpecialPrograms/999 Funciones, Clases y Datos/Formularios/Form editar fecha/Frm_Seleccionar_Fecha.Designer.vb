<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Seleccionar_Fecha
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Seleccionar_Fecha))
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Aceptar = New DevComponents.DotNetBar.ButtonX()
        Me.Dtp_Hora = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Cancelar = New DevComponents.DotNetBar.ButtonX()
        Me.Dtp_Fecha = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        CType(Me.Dtp_Hora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_Fecha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(12, 13)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(103, 23)
        Me.LabelX1.TabIndex = 68
        Me.LabelX1.Text = "Fecha"
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Aceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Aceptar.Image = CType(resources.GetObject("Btn_Aceptar.Image"), System.Drawing.Image)
        Me.Btn_Aceptar.ImageAlt = CType(resources.GetObject("Btn_Aceptar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Aceptar.Location = New System.Drawing.Point(81, 93)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(87, 29)
        Me.Btn_Aceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Aceptar.TabIndex = 69
        Me.Btn_Aceptar.Text = "Aceptar"
        '
        'Dtp_Hora
        '
        Me.Dtp_Hora.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_Hora.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Hora.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Hora.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Hora.ButtonDropDown.Visible = True
        Me.Dtp_Hora.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Dtp_Hora.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Hora.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime
        Me.Dtp_Hora.IsPopupCalendarOpen = False
        Me.Dtp_Hora.Location = New System.Drawing.Point(198, 35)
        '
        '
        '
        Me.Dtp_Hora.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Hora.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Hora.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Hora.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Hora.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Hora.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Hora.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Hora.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Hora.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Hora.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Hora.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Hora.MonthCalendar.DisplayMonth = New Date(2025, 1, 1, 0, 0, 0, 0)
        Me.Dtp_Hora.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_Hora.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Hora.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Hora.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Hora.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Hora.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Hora.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Hora.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Hora.MonthCalendar.Visible = False
        Me.Dtp_Hora.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Hora.Name = "Dtp_Hora"
        Me.Dtp_Hora.Size = New System.Drawing.Size(58, 22)
        Me.Dtp_Hora.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Hora.TabIndex = 70
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(198, 13)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(63, 23)
        Me.LabelX2.TabIndex = 71
        Me.LabelX2.Text = "Hora"
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Cancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Cancelar.Image = CType(resources.GetObject("Btn_Cancelar.Image"), System.Drawing.Image)
        Me.Btn_Cancelar.ImageAlt = CType(resources.GetObject("Btn_Cancelar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Cancelar.Location = New System.Drawing.Point(174, 93)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Size = New System.Drawing.Size(87, 29)
        Me.Btn_Cancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Cancelar.TabIndex = 72
        Me.Btn_Cancelar.Text = "Cancelar"
        '
        'Dtp_Fecha
        '
        Me.Dtp_Fecha.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_Fecha.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha.ButtonDropDown.Visible = True
        Me.Dtp_Fecha.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha.Format = DevComponents.Editors.eDateTimePickerFormat.[Long]
        Me.Dtp_Fecha.IsPopupCalendarOpen = False
        Me.Dtp_Fecha.Location = New System.Drawing.Point(12, 35)
        '
        '
        '
        Me.Dtp_Fecha.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha.MonthCalendar.DisplayMonth = New Date(2025, 1, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_Fecha.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha.Name = "Dtp_Fecha"
        Me.Dtp_Fecha.Size = New System.Drawing.Size(180, 22)
        Me.Dtp_Fecha.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha.TabIndex = 73
        Me.Dtp_Fecha.Value = New Date(2025, 1, 10, 0, 8, 16, 0)
        '
        'Frm_Seleccionar_Fecha
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(264, 126)
        Me.Controls.Add(Me.Dtp_Fecha)
        Me.Controls.Add(Me.Btn_Cancelar)
        Me.Controls.Add(Me.Dtp_Hora)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.Btn_Aceptar)
        Me.Controls.Add(Me.LabelX1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Seleccionar_Fecha"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SELECCIONE LA FECHA"
        CType(Me.Dtp_Hora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_Fecha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Aceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Dtp_Hora As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Cancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Dtp_Fecha As DevComponents.Editors.DateTimeAdv.DateTimeInput
End Class
