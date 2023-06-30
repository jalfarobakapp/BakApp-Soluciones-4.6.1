<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Demonio_ConfProgramacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Demonio_ConfProgramacion))
        Me.Grupo_Semanal = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Chk_Domingo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Lunes = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Martes = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Miercoles = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Sabado = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Jueves = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Viernes = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Grupo_Frecuencia = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Dtp_FinalizaCada = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Dtp_ApartirDeCada = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Cmb_TipoIntervaloCada = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Input_IntervaloCada = New DevComponents.Editors.IntegerInput()
        Me.Dtp_HoraUnaVez = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Rdb_SucedeCada = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_SucedeUnaVez = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_FrecuDiaria = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_FrecuSemanal = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.BtnGrabar = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Txt_Nombre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Grupo_Resumen = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Txt_Resumen = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Grupo_Semanal.SuspendLayout()
        Me.Grupo_Frecuencia.SuspendLayout()
        CType(Me.Dtp_FinalizaCada, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_ApartirDeCada, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Input_IntervaloCada, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_HoraUnaVez, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel3.SuspendLayout()
        Me.Grupo_Resumen.SuspendLayout()
        Me.SuspendLayout()
        '
        'Grupo_Semanal
        '
        Me.Grupo_Semanal.BackColor = System.Drawing.Color.White
        Me.Grupo_Semanal.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Semanal.Controls.Add(Me.Chk_Domingo)
        Me.Grupo_Semanal.Controls.Add(Me.Chk_Lunes)
        Me.Grupo_Semanal.Controls.Add(Me.Chk_Martes)
        Me.Grupo_Semanal.Controls.Add(Me.Chk_Miercoles)
        Me.Grupo_Semanal.Controls.Add(Me.Chk_Sabado)
        Me.Grupo_Semanal.Controls.Add(Me.Chk_Jueves)
        Me.Grupo_Semanal.Controls.Add(Me.Chk_Viernes)
        Me.Grupo_Semanal.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Semanal.Location = New System.Drawing.Point(12, 91)
        Me.Grupo_Semanal.Name = "Grupo_Semanal"
        Me.Grupo_Semanal.Size = New System.Drawing.Size(494, 67)
        '
        '
        '
        Me.Grupo_Semanal.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Semanal.Style.BackColorGradientAngle = 90
        Me.Grupo_Semanal.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Semanal.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Semanal.Style.BorderBottomWidth = 1
        Me.Grupo_Semanal.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Semanal.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Semanal.Style.BorderLeftWidth = 1
        Me.Grupo_Semanal.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Semanal.Style.BorderRightWidth = 1
        Me.Grupo_Semanal.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Semanal.Style.BorderTopWidth = 1
        Me.Grupo_Semanal.Style.CornerDiameter = 4
        Me.Grupo_Semanal.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Semanal.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Semanal.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Semanal.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Semanal.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Semanal.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Semanal.TabIndex = 0
        '
        'Chk_Domingo
        '
        Me.Chk_Domingo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Domingo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Domingo.CheckBoxImageChecked = CType(resources.GetObject("Chk_Domingo.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Domingo.FocusCuesEnabled = False
        Me.Chk_Domingo.ForeColor = System.Drawing.Color.Black
        Me.Chk_Domingo.Location = New System.Drawing.Point(402, 35)
        Me.Chk_Domingo.Name = "Chk_Domingo"
        Me.Chk_Domingo.Size = New System.Drawing.Size(74, 21)
        Me.Chk_Domingo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Domingo.TabIndex = 39
        Me.Chk_Domingo.Text = "Domingo"
        '
        'Chk_Lunes
        '
        Me.Chk_Lunes.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Lunes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Lunes.CheckBoxImageChecked = CType(resources.GetObject("Chk_Lunes.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Lunes.FocusCuesEnabled = False
        Me.Chk_Lunes.ForeColor = System.Drawing.Color.Black
        Me.Chk_Lunes.Location = New System.Drawing.Point(16, 3)
        Me.Chk_Lunes.Name = "Chk_Lunes"
        Me.Chk_Lunes.Size = New System.Drawing.Size(72, 21)
        Me.Chk_Lunes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Lunes.TabIndex = 33
        Me.Chk_Lunes.Text = "Lunes"
        '
        'Chk_Martes
        '
        Me.Chk_Martes.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Martes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Martes.CheckBoxImageChecked = CType(resources.GetObject("Chk_Martes.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Martes.FocusCuesEnabled = False
        Me.Chk_Martes.ForeColor = System.Drawing.Color.Black
        Me.Chk_Martes.Location = New System.Drawing.Point(16, 32)
        Me.Chk_Martes.Name = "Chk_Martes"
        Me.Chk_Martes.Size = New System.Drawing.Size(63, 21)
        Me.Chk_Martes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Martes.TabIndex = 34
        Me.Chk_Martes.Text = "Martes"
        '
        'Chk_Miercoles
        '
        Me.Chk_Miercoles.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Miercoles.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Miercoles.CheckBoxImageChecked = CType(resources.GetObject("Chk_Miercoles.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Miercoles.FocusCuesEnabled = False
        Me.Chk_Miercoles.ForeColor = System.Drawing.Color.Black
        Me.Chk_Miercoles.Location = New System.Drawing.Point(129, 3)
        Me.Chk_Miercoles.Name = "Chk_Miercoles"
        Me.Chk_Miercoles.Size = New System.Drawing.Size(100, 21)
        Me.Chk_Miercoles.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Miercoles.TabIndex = 35
        Me.Chk_Miercoles.Text = "Miercoles"
        '
        'Chk_Sabado
        '
        Me.Chk_Sabado.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Sabado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Sabado.CheckBoxImageChecked = CType(resources.GetObject("Chk_Sabado.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Sabado.FocusCuesEnabled = False
        Me.Chk_Sabado.ForeColor = System.Drawing.Color.Black
        Me.Chk_Sabado.Location = New System.Drawing.Point(402, 3)
        Me.Chk_Sabado.Name = "Chk_Sabado"
        Me.Chk_Sabado.Size = New System.Drawing.Size(74, 21)
        Me.Chk_Sabado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Sabado.TabIndex = 38
        Me.Chk_Sabado.Text = "Sabádo"
        '
        'Chk_Jueves
        '
        Me.Chk_Jueves.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Jueves.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Jueves.CheckBoxImageChecked = CType(resources.GetObject("Chk_Jueves.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Jueves.FocusCuesEnabled = False
        Me.Chk_Jueves.ForeColor = System.Drawing.Color.Black
        Me.Chk_Jueves.Location = New System.Drawing.Point(129, 35)
        Me.Chk_Jueves.Name = "Chk_Jueves"
        Me.Chk_Jueves.Size = New System.Drawing.Size(90, 21)
        Me.Chk_Jueves.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Jueves.TabIndex = 36
        Me.Chk_Jueves.Text = "Jueves"
        '
        'Chk_Viernes
        '
        Me.Chk_Viernes.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Viernes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Viernes.CheckBoxImageChecked = CType(resources.GetObject("Chk_Viernes.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Viernes.FocusCuesEnabled = False
        Me.Chk_Viernes.ForeColor = System.Drawing.Color.Black
        Me.Chk_Viernes.Location = New System.Drawing.Point(257, 3)
        Me.Chk_Viernes.Name = "Chk_Viernes"
        Me.Chk_Viernes.Size = New System.Drawing.Size(118, 21)
        Me.Chk_Viernes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Viernes.TabIndex = 37
        Me.Chk_Viernes.Text = "Viernes"
        '
        'Grupo_Frecuencia
        '
        Me.Grupo_Frecuencia.BackColor = System.Drawing.Color.White
        Me.Grupo_Frecuencia.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Frecuencia.Controls.Add(Me.Dtp_FinalizaCada)
        Me.Grupo_Frecuencia.Controls.Add(Me.Dtp_ApartirDeCada)
        Me.Grupo_Frecuencia.Controls.Add(Me.LabelX2)
        Me.Grupo_Frecuencia.Controls.Add(Me.LabelX1)
        Me.Grupo_Frecuencia.Controls.Add(Me.Cmb_TipoIntervaloCada)
        Me.Grupo_Frecuencia.Controls.Add(Me.Input_IntervaloCada)
        Me.Grupo_Frecuencia.Controls.Add(Me.Dtp_HoraUnaVez)
        Me.Grupo_Frecuencia.Controls.Add(Me.Rdb_SucedeCada)
        Me.Grupo_Frecuencia.Controls.Add(Me.Rdb_SucedeUnaVez)
        Me.Grupo_Frecuencia.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Frecuencia.Location = New System.Drawing.Point(12, 164)
        Me.Grupo_Frecuencia.Name = "Grupo_Frecuencia"
        Me.Grupo_Frecuencia.Size = New System.Drawing.Size(493, 115)
        '
        '
        '
        Me.Grupo_Frecuencia.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Frecuencia.Style.BackColorGradientAngle = 90
        Me.Grupo_Frecuencia.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Frecuencia.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Frecuencia.Style.BorderBottomWidth = 1
        Me.Grupo_Frecuencia.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Frecuencia.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Frecuencia.Style.BorderLeftWidth = 1
        Me.Grupo_Frecuencia.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Frecuencia.Style.BorderRightWidth = 1
        Me.Grupo_Frecuencia.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Frecuencia.Style.BorderTopWidth = 1
        Me.Grupo_Frecuencia.Style.CornerDiameter = 4
        Me.Grupo_Frecuencia.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Frecuencia.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Frecuencia.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Frecuencia.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Frecuencia.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Frecuencia.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Frecuencia.TabIndex = 1
        Me.Grupo_Frecuencia.Text = "Frecuencia diaria"
        '
        'Dtp_FinalizaCada
        '
        Me.Dtp_FinalizaCada.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_FinalizaCada.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_FinalizaCada.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FinalizaCada.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_FinalizaCada.ButtonDropDown.Visible = True
        Me.Dtp_FinalizaCada.Enabled = False
        Me.Dtp_FinalizaCada.ForeColor = System.Drawing.Color.Black
        Me.Dtp_FinalizaCada.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime
        Me.Dtp_FinalizaCada.IsPopupCalendarOpen = False
        Me.Dtp_FinalizaCada.Location = New System.Drawing.Point(401, 63)
        '
        '
        '
        Me.Dtp_FinalizaCada.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FinalizaCada.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FinalizaCada.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_FinalizaCada.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_FinalizaCada.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_FinalizaCada.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FinalizaCada.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_FinalizaCada.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_FinalizaCada.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_FinalizaCada.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_FinalizaCada.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FinalizaCada.MonthCalendar.DisplayMonth = New Date(2018, 11, 1, 0, 0, 0, 0)
        Me.Dtp_FinalizaCada.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_FinalizaCada.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_FinalizaCada.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FinalizaCada.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_FinalizaCada.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FinalizaCada.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_FinalizaCada.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FinalizaCada.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_FinalizaCada.MonthCalendar.Visible = False
        Me.Dtp_FinalizaCada.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_FinalizaCada.Name = "Dtp_FinalizaCada"
        Me.Dtp_FinalizaCada.Size = New System.Drawing.Size(54, 22)
        Me.Dtp_FinalizaCada.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_FinalizaCada.TabIndex = 135
        Me.Dtp_FinalizaCada.TabStop = False
        Me.Dtp_FinalizaCada.Value = New Date(2018, 11, 5, 23, 59, 0, 0)
        Me.Dtp_FinalizaCada.Visible = False
        Me.Dtp_FinalizaCada.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center
        '
        'Dtp_ApartirDeCada
        '
        Me.Dtp_ApartirDeCada.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_ApartirDeCada.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_ApartirDeCada.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_ApartirDeCada.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_ApartirDeCada.ButtonDropDown.Visible = True
        Me.Dtp_ApartirDeCada.Enabled = False
        Me.Dtp_ApartirDeCada.ForeColor = System.Drawing.Color.Black
        Me.Dtp_ApartirDeCada.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime
        Me.Dtp_ApartirDeCada.IsPopupCalendarOpen = False
        Me.Dtp_ApartirDeCada.Location = New System.Drawing.Point(401, 38)
        '
        '
        '
        Me.Dtp_ApartirDeCada.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_ApartirDeCada.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_ApartirDeCada.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_ApartirDeCada.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_ApartirDeCada.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_ApartirDeCada.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_ApartirDeCada.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_ApartirDeCada.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_ApartirDeCada.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_ApartirDeCada.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_ApartirDeCada.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_ApartirDeCada.MonthCalendar.DisplayMonth = New Date(2018, 11, 1, 0, 0, 0, 0)
        Me.Dtp_ApartirDeCada.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_ApartirDeCada.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_ApartirDeCada.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_ApartirDeCada.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_ApartirDeCada.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_ApartirDeCada.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_ApartirDeCada.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_ApartirDeCada.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_ApartirDeCada.MonthCalendar.Visible = False
        Me.Dtp_ApartirDeCada.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_ApartirDeCada.Name = "Dtp_ApartirDeCada"
        Me.Dtp_ApartirDeCada.Size = New System.Drawing.Size(54, 22)
        Me.Dtp_ApartirDeCada.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_ApartirDeCada.TabIndex = 134
        Me.Dtp_ApartirDeCada.TabStop = False
        Me.Dtp_ApartirDeCada.Value = New Date(2018, 11, 5, 0, 0, 0, 0)
        Me.Dtp_ApartirDeCada.Visible = False
        Me.Dtp_ApartirDeCada.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Enabled = False
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(322, 66)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(83, 19)
        Me.LabelX2.TabIndex = 133
        Me.LabelX2.Text = "Finaliza:"
        Me.LabelX2.Visible = False
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Enabled = False
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(322, 37)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(83, 19)
        Me.LabelX1.TabIndex = 132
        Me.LabelX1.Text = "A partir de:"
        Me.LabelX1.Visible = False
        '
        'Cmb_TipoIntervaloCada
        '
        Me.Cmb_TipoIntervaloCada.DisplayMember = "Text"
        Me.Cmb_TipoIntervaloCada.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_TipoIntervaloCada.ForeColor = System.Drawing.Color.Black
        Me.Cmb_TipoIntervaloCada.FormattingEnabled = True
        Me.Cmb_TipoIntervaloCada.ItemHeight = 16
        Me.Cmb_TipoIntervaloCada.Location = New System.Drawing.Point(208, 38)
        Me.Cmb_TipoIntervaloCada.Name = "Cmb_TipoIntervaloCada"
        Me.Cmb_TipoIntervaloCada.Size = New System.Drawing.Size(99, 22)
        Me.Cmb_TipoIntervaloCada.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_TipoIntervaloCada.TabIndex = 131
        '
        'Input_IntervaloCada
        '
        Me.Input_IntervaloCada.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_IntervaloCada.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_IntervaloCada.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_IntervaloCada.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.Input_IntervaloCada.ForeColor = System.Drawing.Color.Black
        Me.Input_IntervaloCada.Location = New System.Drawing.Point(148, 38)
        Me.Input_IntervaloCada.Name = "Input_IntervaloCada"
        Me.Input_IntervaloCada.ShowUpDown = True
        Me.Input_IntervaloCada.Size = New System.Drawing.Size(54, 22)
        Me.Input_IntervaloCada.TabIndex = 130
        '
        'Dtp_HoraUnaVez
        '
        Me.Dtp_HoraUnaVez.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_HoraUnaVez.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_HoraUnaVez.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_HoraUnaVez.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_HoraUnaVez.ButtonDropDown.Visible = True
        Me.Dtp_HoraUnaVez.ForeColor = System.Drawing.Color.Black
        Me.Dtp_HoraUnaVez.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime
        Me.Dtp_HoraUnaVez.IsPopupCalendarOpen = False
        Me.Dtp_HoraUnaVez.Location = New System.Drawing.Point(148, 9)
        '
        '
        '
        Me.Dtp_HoraUnaVez.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_HoraUnaVez.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_HoraUnaVez.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_HoraUnaVez.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_HoraUnaVez.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_HoraUnaVez.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_HoraUnaVez.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_HoraUnaVez.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_HoraUnaVez.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_HoraUnaVez.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_HoraUnaVez.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_HoraUnaVez.MonthCalendar.DisplayMonth = New Date(2018, 11, 1, 0, 0, 0, 0)
        Me.Dtp_HoraUnaVez.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_HoraUnaVez.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_HoraUnaVez.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_HoraUnaVez.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_HoraUnaVez.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_HoraUnaVez.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_HoraUnaVez.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_HoraUnaVez.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_HoraUnaVez.MonthCalendar.Visible = False
        Me.Dtp_HoraUnaVez.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_HoraUnaVez.Name = "Dtp_HoraUnaVez"
        Me.Dtp_HoraUnaVez.Size = New System.Drawing.Size(54, 22)
        Me.Dtp_HoraUnaVez.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_HoraUnaVez.TabIndex = 129
        Me.Dtp_HoraUnaVez.TabStop = False
        Me.Dtp_HoraUnaVez.Value = New Date(2018, 11, 5, 16, 26, 11, 0)
        '
        'Rdb_SucedeCada
        '
        Me.Rdb_SucedeCada.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_SucedeCada.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_SucedeCada.CheckBoxImageChecked = CType(resources.GetObject("Rdb_SucedeCada.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_SucedeCada.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_SucedeCada.FocusCuesEnabled = False
        Me.Rdb_SucedeCada.ForeColor = System.Drawing.Color.Black
        Me.Rdb_SucedeCada.Location = New System.Drawing.Point(15, 37)
        Me.Rdb_SucedeCada.Name = "Rdb_SucedeCada"
        Me.Rdb_SucedeCada.Size = New System.Drawing.Size(100, 23)
        Me.Rdb_SucedeCada.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_SucedeCada.TabIndex = 4
        Me.Rdb_SucedeCada.Text = "Sucede cada"
        '
        'Rdb_SucedeUnaVez
        '
        Me.Rdb_SucedeUnaVez.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_SucedeUnaVez.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_SucedeUnaVez.CheckBoxImageChecked = CType(resources.GetObject("Rdb_SucedeUnaVez.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_SucedeUnaVez.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_SucedeUnaVez.Checked = True
        Me.Rdb_SucedeUnaVez.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_SucedeUnaVez.CheckValue = "Y"
        Me.Rdb_SucedeUnaVez.FocusCuesEnabled = False
        Me.Rdb_SucedeUnaVez.ForeColor = System.Drawing.Color.Black
        Me.Rdb_SucedeUnaVez.Location = New System.Drawing.Point(15, 8)
        Me.Rdb_SucedeUnaVez.Name = "Rdb_SucedeUnaVez"
        Me.Rdb_SucedeUnaVez.Size = New System.Drawing.Size(129, 23)
        Me.Rdb_SucedeUnaVez.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_SucedeUnaVez.TabIndex = 3
        Me.Rdb_SucedeUnaVez.Text = "Sucede una vez a la(s):"
        '
        'Rdb_FrecuDiaria
        '
        Me.Rdb_FrecuDiaria.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Rdb_FrecuDiaria.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_FrecuDiaria.CheckBoxImageChecked = CType(resources.GetObject("Rdb_FrecuDiaria.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_FrecuDiaria.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_FrecuDiaria.Checked = True
        Me.Rdb_FrecuDiaria.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_FrecuDiaria.CheckValue = "Y"
        Me.Rdb_FrecuDiaria.FocusCuesEnabled = False
        Me.Rdb_FrecuDiaria.ForeColor = System.Drawing.Color.Black
        Me.Rdb_FrecuDiaria.Location = New System.Drawing.Point(12, 62)
        Me.Rdb_FrecuDiaria.Name = "Rdb_FrecuDiaria"
        Me.Rdb_FrecuDiaria.Size = New System.Drawing.Size(100, 23)
        Me.Rdb_FrecuDiaria.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_FrecuDiaria.TabIndex = 2
        Me.Rdb_FrecuDiaria.Text = "Sucede diariamente"
        '
        'Rdb_FrecuSemanal
        '
        Me.Rdb_FrecuSemanal.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Rdb_FrecuSemanal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_FrecuSemanal.CheckBoxImageChecked = CType(resources.GetObject("Rdb_FrecuSemanal.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_FrecuSemanal.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_FrecuSemanal.FocusCuesEnabled = False
        Me.Rdb_FrecuSemanal.ForeColor = System.Drawing.Color.Black
        Me.Rdb_FrecuSemanal.Location = New System.Drawing.Point(118, 62)
        Me.Rdb_FrecuSemanal.Name = "Rdb_FrecuSemanal"
        Me.Rdb_FrecuSemanal.Size = New System.Drawing.Size(100, 23)
        Me.Rdb_FrecuSemanal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_FrecuSemanal.TabIndex = 3
        Me.Rdb_FrecuSemanal.Text = "Sucede semanalmente"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnGrabar})
        Me.Bar1.Location = New System.Drawing.Point(0, 375)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(518, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 117
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnGrabar
        '
        Me.BtnGrabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnGrabar.ForeColor = System.Drawing.Color.Black
        Me.BtnGrabar.Image = CType(resources.GetObject("BtnGrabar.Image"), System.Drawing.Image)
        Me.BtnGrabar.ImageAlt = CType(resources.GetObject("BtnGrabar.ImageAlt"), System.Drawing.Image)
        Me.BtnGrabar.Name = "BtnGrabar"
        Me.BtnGrabar.Tooltip = "Grabar"
        '
        'GroupPanel3
        '
        Me.GroupPanel3.BackColor = System.Drawing.Color.White
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.Txt_Nombre)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Location = New System.Drawing.Point(12, 0)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(494, 56)
        '
        '
        '
        Me.GroupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel3.Style.BackColorGradientAngle = 90
        Me.GroupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderBottomWidth = 1
        Me.GroupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderLeftWidth = 1
        Me.GroupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderRightWidth = 1
        Me.GroupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderTopWidth = 1
        Me.GroupPanel3.Style.CornerDiameter = 4
        Me.GroupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel3.TabIndex = 118
        Me.GroupPanel3.Text = "Nombre"
        '
        'Txt_Nombre
        '
        Me.Txt_Nombre.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Nombre.Border.Class = "TextBoxBorder"
        Me.Txt_Nombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Nombre.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Nombre.ForeColor = System.Drawing.Color.Black
        Me.Txt_Nombre.Location = New System.Drawing.Point(3, 8)
        Me.Txt_Nombre.Name = "Txt_Nombre"
        Me.Txt_Nombre.PreventEnterBeep = True
        Me.Txt_Nombre.Size = New System.Drawing.Size(482, 22)
        Me.Txt_Nombre.TabIndex = 0
        '
        'Grupo_Resumen
        '
        Me.Grupo_Resumen.BackColor = System.Drawing.Color.White
        Me.Grupo_Resumen.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Resumen.Controls.Add(Me.Txt_Resumen)
        Me.Grupo_Resumen.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Resumen.Location = New System.Drawing.Point(12, 285)
        Me.Grupo_Resumen.Name = "Grupo_Resumen"
        Me.Grupo_Resumen.Size = New System.Drawing.Size(493, 84)
        '
        '
        '
        Me.Grupo_Resumen.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Resumen.Style.BackColorGradientAngle = 90
        Me.Grupo_Resumen.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Resumen.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Resumen.Style.BorderBottomWidth = 1
        Me.Grupo_Resumen.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Resumen.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Resumen.Style.BorderLeftWidth = 1
        Me.Grupo_Resumen.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Resumen.Style.BorderRightWidth = 1
        Me.Grupo_Resumen.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Resumen.Style.BorderTopWidth = 1
        Me.Grupo_Resumen.Style.CornerDiameter = 4
        Me.Grupo_Resumen.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Resumen.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Resumen.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Resumen.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Resumen.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Resumen.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Resumen.TabIndex = 119
        Me.Grupo_Resumen.Text = "Resumen, descripción"
        '
        'Txt_Resumen
        '
        Me.Txt_Resumen.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Resumen.Border.Class = "TextBoxBorder"
        Me.Txt_Resumen.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Resumen.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Resumen.ForeColor = System.Drawing.Color.Black
        Me.Txt_Resumen.Location = New System.Drawing.Point(2, 3)
        Me.Txt_Resumen.Multiline = True
        Me.Txt_Resumen.Name = "Txt_Resumen"
        Me.Txt_Resumen.PreventEnterBeep = True
        Me.Txt_Resumen.Size = New System.Drawing.Size(482, 55)
        Me.Txt_Resumen.TabIndex = 1
        '
        'Frm_Demonio_ConfProgramacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(518, 416)
        Me.Controls.Add(Me.Grupo_Resumen)
        Me.Controls.Add(Me.Grupo_Frecuencia)
        Me.Controls.Add(Me.GroupPanel3)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.Rdb_FrecuSemanal)
        Me.Controls.Add(Me.Rdb_FrecuDiaria)
        Me.Controls.Add(Me.Grupo_Semanal)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Demonio_ConfProgramacion"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CONFIGURACION DE PROGRAMACION"
        Me.Grupo_Semanal.ResumeLayout(False)
        Me.Grupo_Frecuencia.ResumeLayout(False)
        CType(Me.Dtp_FinalizaCada, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_ApartirDeCada, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Input_IntervaloCada, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_HoraUnaVez, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel3.ResumeLayout(False)
        Me.Grupo_Resumen.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Grupo_Semanal As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grupo_Frecuencia As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Rdb_FrecuDiaria As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_FrecuSemanal As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Domingo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Lunes As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Martes As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Miercoles As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Sabado As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Jueves As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Viernes As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_SucedeCada As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_SucedeUnaVez As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Cmb_TipoIntervaloCada As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Input_IntervaloCada As DevComponents.Editors.IntegerInput
    Friend WithEvents Dtp_HoraUnaVez As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnGrabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Txt_Nombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Dtp_FinalizaCada As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Dtp_ApartirDeCada As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Grupo_Resumen As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Txt_Resumen As DevComponents.DotNetBar.Controls.TextBoxX
End Class
