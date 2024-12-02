<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Sincronizador
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Sincronizador))
        Me.Switch_Sincronizacion = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Chk_AmbienteDePruebas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_FechaRevision = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Limpiar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Configuraciones = New DevComponents.DotNetBar.ButtonItem()
        Me.Metro_Bar_Color = New DevComponents.DotNetBar.Metro.MetroStatusBar()
        Me.Lbl_Estatus = New DevComponents.DotNetBar.LabelItem()
        Me.CircularPgrs = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.Txt_Log = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Timer_Ejecutar = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_Limpiar = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_AjustarFecha = New System.Windows.Forms.Timer(Me.components)
        CType(Me.Dtp_FechaRevision, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Switch_Sincronizacion
        '
        Me.Switch_Sincronizacion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Switch_Sincronizacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Switch_Sincronizacion.ForeColor = System.Drawing.Color.Black
        Me.Switch_Sincronizacion.Location = New System.Drawing.Point(296, 365)
        Me.Switch_Sincronizacion.Name = "Switch_Sincronizacion"
        Me.Switch_Sincronizacion.OffText = "Pausada"
        Me.Switch_Sincronizacion.OnText = "Activa"
        Me.Switch_Sincronizacion.Size = New System.Drawing.Size(89, 22)
        Me.Switch_Sincronizacion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Switch_Sincronizacion.TabIndex = 182
        Me.Switch_Sincronizacion.Value = True
        Me.Switch_Sincronizacion.ValueObject = "Y"
        '
        'Chk_AmbienteDePruebas
        '
        Me.Chk_AmbienteDePruebas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_AmbienteDePruebas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_AmbienteDePruebas.CheckBoxImageChecked = CType(resources.GetObject("Chk_AmbienteDePruebas.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_AmbienteDePruebas.FocusCuesEnabled = False
        Me.Chk_AmbienteDePruebas.ForeColor = System.Drawing.Color.Black
        Me.Chk_AmbienteDePruebas.Location = New System.Drawing.Point(566, 365)
        Me.Chk_AmbienteDePruebas.Name = "Chk_AmbienteDePruebas"
        Me.Chk_AmbienteDePruebas.Size = New System.Drawing.Size(127, 23)
        Me.Chk_AmbienteDePruebas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_AmbienteDePruebas.TabIndex = 181
        Me.Chk_AmbienteDePruebas.Text = "Ambiente de pruebas"
        Me.Chk_AmbienteDePruebas.Visible = False
        '
        'LabelX1
        '
        Me.LabelX1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(12, 362)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(95, 23)
        Me.LabelX1.TabIndex = 180
        Me.LabelX1.Text = "Fecha de revisión"
        '
        'Dtp_FechaRevision
        '
        Me.Dtp_FechaRevision.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Dtp_FechaRevision.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_FechaRevision.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_FechaRevision.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaRevision.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_FechaRevision.ButtonDropDown.Visible = True
        Me.Dtp_FechaRevision.ForeColor = System.Drawing.Color.Black
        Me.Dtp_FechaRevision.IsPopupCalendarOpen = False
        Me.Dtp_FechaRevision.Location = New System.Drawing.Point(113, 363)
        '
        '
        '
        Me.Dtp_FechaRevision.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FechaRevision.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaRevision.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_FechaRevision.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_FechaRevision.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_FechaRevision.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FechaRevision.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_FechaRevision.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_FechaRevision.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_FechaRevision.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_FechaRevision.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaRevision.MonthCalendar.DisplayMonth = New Date(2024, 4, 1, 0, 0, 0, 0)
        Me.Dtp_FechaRevision.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_FechaRevision.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_FechaRevision.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FechaRevision.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_FechaRevision.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FechaRevision.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_FechaRevision.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaRevision.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_FechaRevision.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_FechaRevision.Name = "Dtp_FechaRevision"
        Me.Dtp_FechaRevision.Size = New System.Drawing.Size(87, 22)
        Me.Dtp_FechaRevision.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_FechaRevision.TabIndex = 179
        Me.Dtp_FechaRevision.Value = New Date(2024, 4, 26, 16, 52, 36, 0)
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Limpiar, Me.Btn_Configuraciones})
        Me.Bar1.Location = New System.Drawing.Point(0, 391)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(704, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 177
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Limpiar
        '
        Me.Btn_Limpiar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Limpiar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Limpiar.Image = CType(resources.GetObject("Btn_Limpiar.Image"), System.Drawing.Image)
        Me.Btn_Limpiar.ImageAlt = CType(resources.GetObject("Btn_Limpiar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Limpiar.Name = "Btn_Limpiar"
        Me.Btn_Limpiar.Tooltip = "Limpiar log..."
        '
        'Btn_Configuraciones
        '
        Me.Btn_Configuraciones.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Configuraciones.ForeColor = System.Drawing.Color.Black
        Me.Btn_Configuraciones.Image = CType(resources.GetObject("Btn_Configuraciones.Image"), System.Drawing.Image)
        Me.Btn_Configuraciones.ImageAlt = CType(resources.GetObject("Btn_Configuraciones.ImageAlt"), System.Drawing.Image)
        Me.Btn_Configuraciones.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.Btn_Configuraciones.Name = "Btn_Configuraciones"
        Me.Btn_Configuraciones.Tooltip = "Configurar conexión"
        '
        'Metro_Bar_Color
        '
        Me.Metro_Bar_Color.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Metro_Bar_Color.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Metro_Bar_Color.ContainerControlProcessDialogKey = True
        Me.Metro_Bar_Color.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Metro_Bar_Color.DragDropSupport = True
        Me.Metro_Bar_Color.Font = New System.Drawing.Font("Segoe UI", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Metro_Bar_Color.ForeColor = System.Drawing.Color.Black
        Me.Metro_Bar_Color.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Lbl_Estatus})
        Me.Metro_Bar_Color.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.Metro_Bar_Color.Location = New System.Drawing.Point(0, 432)
        Me.Metro_Bar_Color.Name = "Metro_Bar_Color"
        Me.Metro_Bar_Color.Size = New System.Drawing.Size(704, 22)
        Me.Metro_Bar_Color.TabIndex = 178
        Me.Metro_Bar_Color.Text = "MetroStatusBar1"
        '
        'Lbl_Estatus
        '
        Me.Lbl_Estatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Estatus.Name = "Lbl_Estatus"
        Me.Lbl_Estatus.Text = "LabelItem2"
        '
        'CircularPgrs
        '
        Me.CircularPgrs.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.CircularPgrs.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CircularPgrs.Enabled = False
        Me.CircularPgrs.FocusCuesEnabled = False
        Me.CircularPgrs.Location = New System.Drawing.Point(393, 365)
        Me.CircularPgrs.Name = "CircularPgrs"
        Me.CircularPgrs.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Dot
        Me.CircularPgrs.ProgressColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CircularPgrs.Size = New System.Drawing.Size(32, 23)
        Me.CircularPgrs.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.CircularPgrs.TabIndex = 176
        '
        'Txt_Log
        '
        Me.Txt_Log.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt_Log.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Log.Border.Class = "TextBoxBorder"
        Me.Txt_Log.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Log.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Log.ForeColor = System.Drawing.Color.Black
        Me.Txt_Log.Location = New System.Drawing.Point(12, 6)
        Me.Txt_Log.Multiline = True
        Me.Txt_Log.Name = "Txt_Log"
        Me.Txt_Log.PreventEnterBeep = True
        Me.Txt_Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Log.Size = New System.Drawing.Size(680, 350)
        Me.Txt_Log.TabIndex = 175
        '
        'LabelX2
        '
        Me.LabelX2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelX2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(220, 363)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(83, 23)
        Me.LabelX2.TabIndex = 183
        Me.LabelX2.Text = "Sincronización"
        '
        'Timer_Ejecutar
        '
        Me.Timer_Ejecutar.Interval = 2000
        '
        'Timer_Limpiar
        '
        Me.Timer_Limpiar.Interval = 2000
        '
        'Timer_AjustarFecha
        '
        Me.Timer_AjustarFecha.Interval = 2000
        '
        'Frm_Sincronizador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(704, 454)
        Me.Controls.Add(Me.Switch_Sincronizacion)
        Me.Controls.Add(Me.Chk_AmbienteDePruebas)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Dtp_FechaRevision)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.Metro_Bar_Color)
        Me.Controls.Add(Me.CircularPgrs)
        Me.Controls.Add(Me.Txt_Log)
        Me.Controls.Add(Me.LabelX2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Frm_Sincronizador"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SINCRONIZA MLIBRE2BAKAPP"
        CType(Me.Dtp_FechaRevision, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Switch_Sincronizacion As DevComponents.DotNetBar.Controls.SwitchButton
    Public WithEvents Chk_AmbienteDePruebas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dtp_FechaRevision As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Limpiar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Configuraciones As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Metro_Bar_Color As DevComponents.DotNetBar.Metro.MetroStatusBar
    Friend WithEvents Lbl_Estatus As DevComponents.DotNetBar.LabelItem
    Friend WithEvents CircularPgrs As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Txt_Log As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Timer_Ejecutar As Timer
    Friend WithEvents Timer_Limpiar As Timer
    Friend WithEvents Timer_AjustarFecha As Timer
End Class
