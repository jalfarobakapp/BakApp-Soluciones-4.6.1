<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_MantFacturasElecFiltrar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_MantFacturasElecFiltrar))
        Me.Grupo_Fechas = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_Fecha_Emision_Desde = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Dtp_Fecha_Emision_Hasta = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Grupo_Filtros = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Rdb_Entidades_Algunas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Entidades_Todas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.TableLayoutPanel9 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_Sucursales_Todas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Sucursales_Algunas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.Rdb_Documentos_Algunos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_Documentos_Todos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_Responsables_Todos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Responsables_Algunos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Procesar = New DevComponents.DotNetBar.ButtonItem()
        Me.Grupo_Estado = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Grupo_Excepciones = New System.Windows.Forms.TableLayoutPanel()
        Me.Rdb_EstadoSinFirmar = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_EstadoRechazados = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_EstadoAceptadosReparos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_EstadoAceptados = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_EstadoExcepciones = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_EstadoTodos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Grupo_Uno = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Txt_Documento = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_Buscar_Todos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Buscar_Uno = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_ErrorEnvioCorreo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Grupo_Fechas.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.Dtp_Fecha_Emision_Desde, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_Fecha_Emision_Hasta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_Filtros.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel9.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.TableLayoutPanel7.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_Estado.SuspendLayout()
        Me.Grupo_Excepciones.SuspendLayout()
        Me.Grupo_Uno.SuspendLayout()
        Me.SuspendLayout()
        '
        'Grupo_Fechas
        '
        Me.Grupo_Fechas.BackColor = System.Drawing.Color.White
        Me.Grupo_Fechas.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Fechas.Controls.Add(Me.TableLayoutPanel2)
        Me.Grupo_Fechas.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Fechas.Location = New System.Drawing.Point(12, 43)
        Me.Grupo_Fechas.Name = "Grupo_Fechas"
        Me.Grupo_Fechas.Size = New System.Drawing.Size(217, 59)
        '
        '
        '
        Me.Grupo_Fechas.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Fechas.Style.BackColorGradientAngle = 90
        Me.Grupo_Fechas.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Fechas.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Fechas.Style.BorderBottomWidth = 1
        Me.Grupo_Fechas.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Fechas.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Fechas.Style.BorderLeftWidth = 1
        Me.Grupo_Fechas.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Fechas.Style.BorderRightWidth = 1
        Me.Grupo_Fechas.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Fechas.Style.BorderTopWidth = 1
        Me.Grupo_Fechas.Style.CornerDiameter = 4
        Me.Grupo_Fechas.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Fechas.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Fechas.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Fechas.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Fechas.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Fechas.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Fechas.TabIndex = 122
        Me.Grupo_Fechas.Text = "Emitidas entre"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.93877!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.081633!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.46939!))
        Me.TableLayoutPanel2.Controls.Add(Me.LabelX1, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Dtp_Fecha_Emision_Desde, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Dtp_Fecha_Emision_Hasta, 2, 0)
        Me.TableLayoutPanel2.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(6, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(196, 31)
        Me.TableLayoutPanel2.TabIndex = 5
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(95, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(2, 23)
        Me.LabelX1.TabIndex = 114
        Me.LabelX1.Text = "-"
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Center
        Me.LabelX1.TextLineAlignment = System.Drawing.StringAlignment.Near
        '
        'Dtp_Fecha_Emision_Desde
        '
        Me.Dtp_Fecha_Emision_Desde.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_Fecha_Emision_Desde.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Emision_Desde.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Emision_Desde.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Emision_Desde.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Emision_Desde.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Emision_Desde.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Emision_Desde.Location = New System.Drawing.Point(3, 3)
        '
        '
        '
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.DisplayMonth = New Date(2017, 5, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Emision_Desde.Name = "Dtp_Fecha_Emision_Desde"
        Me.Dtp_Fecha_Emision_Desde.Size = New System.Drawing.Size(84, 22)
        Me.Dtp_Fecha_Emision_Desde.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Emision_Desde.TabIndex = 105
        Me.Dtp_Fecha_Emision_Desde.Value = New Date(2017, 5, 9, 17, 44, 34, 0)
        '
        'Dtp_Fecha_Emision_Hasta
        '
        Me.Dtp_Fecha_Emision_Hasta.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_Fecha_Emision_Hasta.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Emision_Hasta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Emision_Hasta.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Emision_Hasta.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Emision_Hasta.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Emision_Hasta.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Emision_Hasta.Location = New System.Drawing.Point(103, 3)
        '
        '
        '
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.DisplayMonth = New Date(2017, 5, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Emision_Hasta.Name = "Dtp_Fecha_Emision_Hasta"
        Me.Dtp_Fecha_Emision_Hasta.Size = New System.Drawing.Size(85, 22)
        Me.Dtp_Fecha_Emision_Hasta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Emision_Hasta.TabIndex = 112
        Me.Dtp_Fecha_Emision_Hasta.Value = New Date(2017, 5, 9, 17, 44, 34, 0)
        '
        'Grupo_Filtros
        '
        Me.Grupo_Filtros.BackColor = System.Drawing.Color.White
        Me.Grupo_Filtros.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Grupo_Filtros.Controls.Add(Me.TableLayoutPanel1)
        Me.Grupo_Filtros.Controls.Add(Me.TableLayoutPanel9)
        Me.Grupo_Filtros.Controls.Add(Me.TableLayoutPanel6)
        Me.Grupo_Filtros.Controls.Add(Me.TableLayoutPanel7)
        Me.Grupo_Filtros.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Filtros.Location = New System.Drawing.Point(12, 108)
        Me.Grupo_Filtros.Name = "Grupo_Filtros"
        Me.Grupo_Filtros.Size = New System.Drawing.Size(311, 181)
        '
        '
        '
        Me.Grupo_Filtros.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Filtros.Style.BackColorGradientAngle = 90
        Me.Grupo_Filtros.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Filtros.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Filtros.Style.BorderBottomWidth = 1
        Me.Grupo_Filtros.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Filtros.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Filtros.Style.BorderLeftWidth = 1
        Me.Grupo_Filtros.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Filtros.Style.BorderRightWidth = 1
        Me.Grupo_Filtros.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Filtros.Style.BorderTopWidth = 1
        Me.Grupo_Filtros.Style.CornerDiameter = 4
        Me.Grupo_Filtros.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Filtros.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Filtros.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Filtros.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Filtros.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Filtros.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Filtros.TabIndex = 123
        Me.Grupo_Filtros.Text = "Filtros "
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_Entidades_Algunas, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_Entidades_Todas, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX2, 0, 0)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 108)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(296, 25)
        Me.TableLayoutPanel1.TabIndex = 50
        '
        'Rdb_Entidades_Algunas
        '
        Me.Rdb_Entidades_Algunas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Entidades_Algunas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Entidades_Algunas.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Entidades_Algunas.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Entidades_Algunas.CheckBoxImageUnChecked = CType(resources.GetObject("Rdb_Entidades_Algunas.CheckBoxImageUnChecked"), System.Drawing.Image)
        Me.Rdb_Entidades_Algunas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Entidades_Algunas.FocusCuesEnabled = False
        Me.Rdb_Entidades_Algunas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Entidades_Algunas.Location = New System.Drawing.Point(193, 3)
        Me.Rdb_Entidades_Algunas.Name = "Rdb_Entidades_Algunas"
        Me.Rdb_Entidades_Algunas.Size = New System.Drawing.Size(70, 19)
        Me.Rdb_Entidades_Algunas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Entidades_Algunas.TabIndex = 138
        Me.Rdb_Entidades_Algunas.Text = "Algunas"
        '
        'Rdb_Entidades_Todas
        '
        Me.Rdb_Entidades_Todas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Entidades_Todas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Entidades_Todas.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Entidades_Todas.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Entidades_Todas.CheckBoxImageUnChecked = CType(resources.GetObject("Rdb_Entidades_Todas.CheckBoxImageUnChecked"), System.Drawing.Image)
        Me.Rdb_Entidades_Todas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Entidades_Todas.Checked = True
        Me.Rdb_Entidades_Todas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Entidades_Todas.CheckValue = "Y"
        Me.Rdb_Entidades_Todas.FocusCuesEnabled = False
        Me.Rdb_Entidades_Todas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Entidades_Todas.Location = New System.Drawing.Point(109, 3)
        Me.Rdb_Entidades_Todas.Name = "Rdb_Entidades_Todas"
        Me.Rdb_Entidades_Todas.Size = New System.Drawing.Size(70, 19)
        Me.Rdb_Entidades_Todas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Entidades_Todas.TabIndex = 137
        Me.Rdb_Entidades_Todas.Text = "Todas"
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 3)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(100, 19)
        Me.LabelX2.TabIndex = 4
        Me.LabelX2.Text = "Entidades"
        '
        'TableLayoutPanel9
        '
        Me.TableLayoutPanel9.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel9.ColumnCount = 3
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84.0!))
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
        Me.TableLayoutPanel9.Controls.Add(Me.LabelX10, 0, 0)
        Me.TableLayoutPanel9.Controls.Add(Me.Rdb_Sucursales_Todas, 1, 0)
        Me.TableLayoutPanel9.Controls.Add(Me.Rdb_Sucursales_Algunas, 2, 0)
        Me.TableLayoutPanel9.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel9.Location = New System.Drawing.Point(3, 46)
        Me.TableLayoutPanel9.Name = "TableLayoutPanel9"
        Me.TableLayoutPanel9.RowCount = 1
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel9.Size = New System.Drawing.Size(296, 25)
        Me.TableLayoutPanel9.TabIndex = 49
        '
        'LabelX10
        '
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.ForeColor = System.Drawing.Color.Black
        Me.LabelX10.Location = New System.Drawing.Point(3, 3)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(100, 19)
        Me.LabelX10.TabIndex = 4
        Me.LabelX10.Text = "Sucursales"
        '
        'Rdb_Sucursales_Todas
        '
        Me.Rdb_Sucursales_Todas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Sucursales_Todas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Sucursales_Todas.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Sucursales_Todas.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Sucursales_Todas.CheckBoxImageUnChecked = CType(resources.GetObject("Rdb_Sucursales_Todas.CheckBoxImageUnChecked"), System.Drawing.Image)
        Me.Rdb_Sucursales_Todas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Sucursales_Todas.Checked = True
        Me.Rdb_Sucursales_Todas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Sucursales_Todas.CheckValue = "Y"
        Me.Rdb_Sucursales_Todas.FocusCuesEnabled = False
        Me.Rdb_Sucursales_Todas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Sucursales_Todas.Location = New System.Drawing.Point(109, 3)
        Me.Rdb_Sucursales_Todas.Name = "Rdb_Sucursales_Todas"
        Me.Rdb_Sucursales_Todas.Size = New System.Drawing.Size(70, 19)
        Me.Rdb_Sucursales_Todas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Sucursales_Todas.TabIndex = 133
        Me.Rdb_Sucursales_Todas.Text = "Todas"
        '
        'Rdb_Sucursales_Algunas
        '
        Me.Rdb_Sucursales_Algunas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Sucursales_Algunas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Sucursales_Algunas.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Sucursales_Algunas.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Sucursales_Algunas.CheckBoxImageUnChecked = CType(resources.GetObject("Rdb_Sucursales_Algunas.CheckBoxImageUnChecked"), System.Drawing.Image)
        Me.Rdb_Sucursales_Algunas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Sucursales_Algunas.FocusCuesEnabled = False
        Me.Rdb_Sucursales_Algunas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Sucursales_Algunas.Location = New System.Drawing.Point(193, 3)
        Me.Rdb_Sucursales_Algunas.Name = "Rdb_Sucursales_Algunas"
        Me.Rdb_Sucursales_Algunas.Size = New System.Drawing.Size(70, 19)
        Me.Rdb_Sucursales_Algunas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Sucursales_Algunas.TabIndex = 134
        Me.Rdb_Sucursales_Algunas.Text = "Algunas"
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel6.ColumnCount = 3
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.Rdb_Documentos_Algunos, 2, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.LabelX7, 0, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.Rdb_Documentos_Todos, 1, 0)
        Me.TableLayoutPanel6.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(3, 15)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 1
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(296, 25)
        Me.TableLayoutPanel6.TabIndex = 47
        '
        'Rdb_Documentos_Algunos
        '
        Me.Rdb_Documentos_Algunos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Documentos_Algunos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Documentos_Algunos.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Documentos_Algunos.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Documentos_Algunos.CheckBoxImageUnChecked = CType(resources.GetObject("Rdb_Documentos_Algunos.CheckBoxImageUnChecked"), System.Drawing.Image)
        Me.Rdb_Documentos_Algunos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Documentos_Algunos.FocusCuesEnabled = False
        Me.Rdb_Documentos_Algunos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Documentos_Algunos.Location = New System.Drawing.Point(193, 3)
        Me.Rdb_Documentos_Algunos.Name = "Rdb_Documentos_Algunos"
        Me.Rdb_Documentos_Algunos.Size = New System.Drawing.Size(70, 19)
        Me.Rdb_Documentos_Algunos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Documentos_Algunos.TabIndex = 132
        Me.Rdb_Documentos_Algunos.Text = "Algunos"
        '
        'LabelX7
        '
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.ForeColor = System.Drawing.Color.Black
        Me.LabelX7.Location = New System.Drawing.Point(3, 3)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(100, 19)
        Me.LabelX7.TabIndex = 4
        Me.LabelX7.Text = "Tipo documento"
        '
        'Rdb_Documentos_Todos
        '
        Me.Rdb_Documentos_Todos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Documentos_Todos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Documentos_Todos.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Documentos_Todos.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Documentos_Todos.CheckBoxImageUnChecked = CType(resources.GetObject("Rdb_Documentos_Todos.CheckBoxImageUnChecked"), System.Drawing.Image)
        Me.Rdb_Documentos_Todos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Documentos_Todos.Checked = True
        Me.Rdb_Documentos_Todos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Documentos_Todos.CheckValue = "Y"
        Me.Rdb_Documentos_Todos.FocusCuesEnabled = False
        Me.Rdb_Documentos_Todos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Documentos_Todos.Location = New System.Drawing.Point(109, 3)
        Me.Rdb_Documentos_Todos.Name = "Rdb_Documentos_Todos"
        Me.Rdb_Documentos_Todos.Size = New System.Drawing.Size(70, 19)
        Me.Rdb_Documentos_Todos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Documentos_Todos.TabIndex = 131
        Me.Rdb_Documentos_Todos.Text = "Todos"
        '
        'TableLayoutPanel7
        '
        Me.TableLayoutPanel7.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel7.ColumnCount = 3
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
        Me.TableLayoutPanel7.Controls.Add(Me.LabelX8, 0, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.Rdb_Responsables_Todos, 1, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.Rdb_Responsables_Algunos, 2, 0)
        Me.TableLayoutPanel7.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel7.Location = New System.Drawing.Point(3, 77)
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        Me.TableLayoutPanel7.RowCount = 1
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel7.Size = New System.Drawing.Size(296, 25)
        Me.TableLayoutPanel7.TabIndex = 48
        '
        'LabelX8
        '
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.ForeColor = System.Drawing.Color.Black
        Me.LabelX8.Location = New System.Drawing.Point(3, 3)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(100, 19)
        Me.LabelX8.TabIndex = 4
        Me.LabelX8.Text = "Responsables"
        '
        'Rdb_Responsables_Todos
        '
        Me.Rdb_Responsables_Todos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Responsables_Todos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Responsables_Todos.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Responsables_Todos.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Responsables_Todos.CheckBoxImageUnChecked = CType(resources.GetObject("Rdb_Responsables_Todos.CheckBoxImageUnChecked"), System.Drawing.Image)
        Me.Rdb_Responsables_Todos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Responsables_Todos.Checked = True
        Me.Rdb_Responsables_Todos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Responsables_Todos.CheckValue = "Y"
        Me.Rdb_Responsables_Todos.FocusCuesEnabled = False
        Me.Rdb_Responsables_Todos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Responsables_Todos.Location = New System.Drawing.Point(109, 3)
        Me.Rdb_Responsables_Todos.Name = "Rdb_Responsables_Todos"
        Me.Rdb_Responsables_Todos.Size = New System.Drawing.Size(70, 19)
        Me.Rdb_Responsables_Todos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Responsables_Todos.TabIndex = 135
        Me.Rdb_Responsables_Todos.Text = "Todas"
        '
        'Rdb_Responsables_Algunos
        '
        Me.Rdb_Responsables_Algunos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Responsables_Algunos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Responsables_Algunos.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Responsables_Algunos.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Responsables_Algunos.CheckBoxImageUnChecked = CType(resources.GetObject("Rdb_Responsables_Algunos.CheckBoxImageUnChecked"), System.Drawing.Image)
        Me.Rdb_Responsables_Algunos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Responsables_Algunos.FocusCuesEnabled = False
        Me.Rdb_Responsables_Algunos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Responsables_Algunos.Location = New System.Drawing.Point(193, 3)
        Me.Rdb_Responsables_Algunos.Name = "Rdb_Responsables_Algunos"
        Me.Rdb_Responsables_Algunos.Size = New System.Drawing.Size(70, 19)
        Me.Rdb_Responsables_Algunos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Responsables_Algunos.TabIndex = 136
        Me.Rdb_Responsables_Algunos.Text = "Algunas"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Procesar})
        Me.Bar1.Location = New System.Drawing.Point(0, 292)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(479, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 124
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Procesar
        '
        Me.Btn_Procesar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Procesar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Procesar.Image = CType(resources.GetObject("Btn_Procesar.Image"), System.Drawing.Image)
        Me.Btn_Procesar.ImageAlt = CType(resources.GetObject("Btn_Procesar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Procesar.Name = "Btn_Procesar"
        Me.Btn_Procesar.Tooltip = "Procesar"
        '
        'Grupo_Estado
        '
        Me.Grupo_Estado.BackColor = System.Drawing.Color.White
        Me.Grupo_Estado.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Estado.Controls.Add(Me.Grupo_Excepciones)
        Me.Grupo_Estado.Controls.Add(Me.Rdb_EstadoExcepciones)
        Me.Grupo_Estado.Controls.Add(Me.Rdb_EstadoTodos)
        Me.Grupo_Estado.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Estado.Location = New System.Drawing.Point(329, 108)
        Me.Grupo_Estado.Name = "Grupo_Estado"
        Me.Grupo_Estado.Size = New System.Drawing.Size(139, 181)
        '
        '
        '
        Me.Grupo_Estado.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Estado.Style.BackColorGradientAngle = 90
        Me.Grupo_Estado.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Estado.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Estado.Style.BorderBottomWidth = 1
        Me.Grupo_Estado.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Estado.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Estado.Style.BorderLeftWidth = 1
        Me.Grupo_Estado.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Estado.Style.BorderRightWidth = 1
        Me.Grupo_Estado.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Estado.Style.BorderTopWidth = 1
        Me.Grupo_Estado.Style.CornerDiameter = 4
        Me.Grupo_Estado.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Estado.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Estado.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Estado.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Estado.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Estado.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Estado.TabIndex = 125
        Me.Grupo_Estado.Text = "Estado del documento"
        '
        'Grupo_Excepciones
        '
        Me.Grupo_Excepciones.BackColor = System.Drawing.Color.Transparent
        Me.Grupo_Excepciones.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.Grupo_Excepciones.ColumnCount = 1
        Me.Grupo_Excepciones.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Grupo_Excepciones.Controls.Add(Me.Rdb_ErrorEnvioCorreo, 0, 4)
        Me.Grupo_Excepciones.Controls.Add(Me.Rdb_EstadoSinFirmar, 0, 3)
        Me.Grupo_Excepciones.Controls.Add(Me.Rdb_EstadoRechazados, 0, 2)
        Me.Grupo_Excepciones.Controls.Add(Me.Rdb_EstadoAceptadosReparos, 0, 1)
        Me.Grupo_Excepciones.Controls.Add(Me.Rdb_EstadoAceptados, 0, 0)
        Me.Grupo_Excepciones.Enabled = False
        Me.Grupo_Excepciones.ForeColor = System.Drawing.Color.Black
        Me.Grupo_Excepciones.Location = New System.Drawing.Point(3, 55)
        Me.Grupo_Excepciones.Name = "Grupo_Excepciones"
        Me.Grupo_Excepciones.RowCount = 5
        Me.Grupo_Excepciones.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.Grupo_Excepciones.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.Grupo_Excepciones.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.Grupo_Excepciones.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.Grupo_Excepciones.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.Grupo_Excepciones.Size = New System.Drawing.Size(127, 99)
        Me.Grupo_Excepciones.TabIndex = 138
        '
        'Rdb_EstadoSinFirmar
        '
        Me.Rdb_EstadoSinFirmar.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_EstadoSinFirmar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_EstadoSinFirmar.CheckBoxImageChecked = CType(resources.GetObject("Rdb_EstadoSinFirmar.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_EstadoSinFirmar.CheckBoxImageUnChecked = CType(resources.GetObject("Rdb_EstadoSinFirmar.CheckBoxImageUnChecked"), System.Drawing.Image)
        Me.Rdb_EstadoSinFirmar.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_EstadoSinFirmar.FocusCuesEnabled = False
        Me.Rdb_EstadoSinFirmar.ForeColor = System.Drawing.Color.Black
        Me.Rdb_EstadoSinFirmar.Location = New System.Drawing.Point(4, 61)
        Me.Rdb_EstadoSinFirmar.Name = "Rdb_EstadoSinFirmar"
        Me.Rdb_EstadoSinFirmar.Size = New System.Drawing.Size(70, 12)
        Me.Rdb_EstadoSinFirmar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_EstadoSinFirmar.TabIndex = 139
        Me.Rdb_EstadoSinFirmar.Text = "Sin Firmar"
        '
        'Rdb_EstadoRechazados
        '
        Me.Rdb_EstadoRechazados.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_EstadoRechazados.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_EstadoRechazados.CheckBoxImageChecked = CType(resources.GetObject("Rdb_EstadoRechazados.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_EstadoRechazados.CheckBoxImageUnChecked = CType(resources.GetObject("Rdb_EstadoRechazados.CheckBoxImageUnChecked"), System.Drawing.Image)
        Me.Rdb_EstadoRechazados.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_EstadoRechazados.FocusCuesEnabled = False
        Me.Rdb_EstadoRechazados.ForeColor = System.Drawing.Color.Black
        Me.Rdb_EstadoRechazados.Location = New System.Drawing.Point(4, 42)
        Me.Rdb_EstadoRechazados.Name = "Rdb_EstadoRechazados"
        Me.Rdb_EstadoRechazados.Size = New System.Drawing.Size(119, 12)
        Me.Rdb_EstadoRechazados.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_EstadoRechazados.TabIndex = 139
        Me.Rdb_EstadoRechazados.Text = "Rachazados"
        '
        'Rdb_EstadoAceptadosReparos
        '
        Me.Rdb_EstadoAceptadosReparos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_EstadoAceptadosReparos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_EstadoAceptadosReparos.CheckBoxImageChecked = CType(resources.GetObject("Rdb_EstadoAceptadosReparos.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_EstadoAceptadosReparos.CheckBoxImageUnChecked = CType(resources.GetObject("Rdb_EstadoAceptadosReparos.CheckBoxImageUnChecked"), System.Drawing.Image)
        Me.Rdb_EstadoAceptadosReparos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_EstadoAceptadosReparos.FocusCuesEnabled = False
        Me.Rdb_EstadoAceptadosReparos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_EstadoAceptadosReparos.Location = New System.Drawing.Point(4, 23)
        Me.Rdb_EstadoAceptadosReparos.Name = "Rdb_EstadoAceptadosReparos"
        Me.Rdb_EstadoAceptadosReparos.Size = New System.Drawing.Size(119, 12)
        Me.Rdb_EstadoAceptadosReparos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_EstadoAceptadosReparos.TabIndex = 139
        Me.Rdb_EstadoAceptadosReparos.Text = "Aceptado/Reparos"
        '
        'Rdb_EstadoAceptados
        '
        Me.Rdb_EstadoAceptados.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_EstadoAceptados.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_EstadoAceptados.CheckBoxImageChecked = CType(resources.GetObject("Rdb_EstadoAceptados.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_EstadoAceptados.CheckBoxImageUnChecked = CType(resources.GetObject("Rdb_EstadoAceptados.CheckBoxImageUnChecked"), System.Drawing.Image)
        Me.Rdb_EstadoAceptados.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_EstadoAceptados.Checked = True
        Me.Rdb_EstadoAceptados.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_EstadoAceptados.CheckValue = "Y"
        Me.Rdb_EstadoAceptados.FocusCuesEnabled = False
        Me.Rdb_EstadoAceptados.ForeColor = System.Drawing.Color.Black
        Me.Rdb_EstadoAceptados.Location = New System.Drawing.Point(4, 4)
        Me.Rdb_EstadoAceptados.Name = "Rdb_EstadoAceptados"
        Me.Rdb_EstadoAceptados.Size = New System.Drawing.Size(70, 12)
        Me.Rdb_EstadoAceptados.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_EstadoAceptados.TabIndex = 139
        Me.Rdb_EstadoAceptados.Text = "Aceptados"
        '
        'Rdb_EstadoExcepciones
        '
        Me.Rdb_EstadoExcepciones.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_EstadoExcepciones.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_EstadoExcepciones.CheckBoxImageChecked = CType(resources.GetObject("Rdb_EstadoExcepciones.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_EstadoExcepciones.CheckBoxImageUnChecked = CType(resources.GetObject("Rdb_EstadoExcepciones.CheckBoxImageUnChecked"), System.Drawing.Image)
        Me.Rdb_EstadoExcepciones.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_EstadoExcepciones.FocusCuesEnabled = False
        Me.Rdb_EstadoExcepciones.ForeColor = System.Drawing.Color.Black
        Me.Rdb_EstadoExcepciones.Location = New System.Drawing.Point(3, 33)
        Me.Rdb_EstadoExcepciones.Name = "Rdb_EstadoExcepciones"
        Me.Rdb_EstadoExcepciones.Size = New System.Drawing.Size(70, 19)
        Me.Rdb_EstadoExcepciones.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_EstadoExcepciones.TabIndex = 135
        Me.Rdb_EstadoExcepciones.Text = "Excepciones"
        '
        'Rdb_EstadoTodos
        '
        Me.Rdb_EstadoTodos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_EstadoTodos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_EstadoTodos.CheckBoxImageChecked = CType(resources.GetObject("Rdb_EstadoTodos.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_EstadoTodos.CheckBoxImageUnChecked = CType(resources.GetObject("Rdb_EstadoTodos.CheckBoxImageUnChecked"), System.Drawing.Image)
        Me.Rdb_EstadoTodos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_EstadoTodos.Checked = True
        Me.Rdb_EstadoTodos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_EstadoTodos.CheckValue = "Y"
        Me.Rdb_EstadoTodos.FocusCuesEnabled = False
        Me.Rdb_EstadoTodos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_EstadoTodos.Location = New System.Drawing.Point(3, 15)
        Me.Rdb_EstadoTodos.Name = "Rdb_EstadoTodos"
        Me.Rdb_EstadoTodos.Size = New System.Drawing.Size(70, 19)
        Me.Rdb_EstadoTodos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_EstadoTodos.TabIndex = 132
        Me.Rdb_EstadoTodos.Text = "Todos"
        '
        'Grupo_Uno
        '
        Me.Grupo_Uno.BackColor = System.Drawing.Color.White
        Me.Grupo_Uno.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Uno.Controls.Add(Me.Txt_Documento)
        Me.Grupo_Uno.Controls.Add(Me.LabelX3)
        Me.Grupo_Uno.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Uno.Location = New System.Drawing.Point(235, 43)
        Me.Grupo_Uno.Name = "Grupo_Uno"
        Me.Grupo_Uno.Size = New System.Drawing.Size(233, 59)
        '
        '
        '
        Me.Grupo_Uno.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Uno.Style.BackColorGradientAngle = 90
        Me.Grupo_Uno.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Uno.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Uno.Style.BorderBottomWidth = 1
        Me.Grupo_Uno.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Uno.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Uno.Style.BorderLeftWidth = 1
        Me.Grupo_Uno.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Uno.Style.BorderRightWidth = 1
        Me.Grupo_Uno.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Uno.Style.BorderTopWidth = 1
        Me.Grupo_Uno.Style.CornerDiameter = 4
        Me.Grupo_Uno.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Uno.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Uno.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Uno.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Uno.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Uno.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Uno.TabIndex = 126
        Me.Grupo_Uno.Text = "Estado del documento"
        '
        'Txt_Documento
        '
        Me.Txt_Documento.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Documento.Border.Class = "TextBoxBorder"
        Me.Txt_Documento.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Documento.ButtonCustom.Image = CType(resources.GetObject("Txt_Documento.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Documento.ButtonCustom.Visible = True
        Me.Txt_Documento.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Documento.ForeColor = System.Drawing.Color.Black
        Me.Txt_Documento.Location = New System.Drawing.Point(107, 6)
        Me.Txt_Documento.Name = "Txt_Documento"
        Me.Txt_Documento.PreventEnterBeep = True
        Me.Txt_Documento.ReadOnly = True
        Me.Txt_Documento.Size = New System.Drawing.Size(117, 22)
        Me.Txt_Documento.TabIndex = 1
        Me.Txt_Documento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(3, 6)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(104, 23)
        Me.LabelX3.TabIndex = 0
        Me.LabelX3.Text = "Documento a buscar"
        '
        'Rdb_Buscar_Todos
        '
        Me.Rdb_Buscar_Todos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Buscar_Todos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Buscar_Todos.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Buscar_Todos.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Buscar_Todos.CheckBoxImageUnChecked = CType(resources.GetObject("Rdb_Buscar_Todos.CheckBoxImageUnChecked"), System.Drawing.Image)
        Me.Rdb_Buscar_Todos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Buscar_Todos.Checked = True
        Me.Rdb_Buscar_Todos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Buscar_Todos.CheckValue = "Y"
        Me.Rdb_Buscar_Todos.FocusCuesEnabled = False
        Me.Rdb_Buscar_Todos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Buscar_Todos.Location = New System.Drawing.Point(12, 12)
        Me.Rdb_Buscar_Todos.Name = "Rdb_Buscar_Todos"
        Me.Rdb_Buscar_Todos.Size = New System.Drawing.Size(134, 19)
        Me.Rdb_Buscar_Todos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Buscar_Todos.TabIndex = 134
        Me.Rdb_Buscar_Todos.Text = "Todo los documentos"
        '
        'Rdb_Buscar_Uno
        '
        Me.Rdb_Buscar_Uno.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Buscar_Uno.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Buscar_Uno.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Buscar_Uno.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Buscar_Uno.CheckBoxImageUnChecked = CType(resources.GetObject("Rdb_Buscar_Uno.CheckBoxImageUnChecked"), System.Drawing.Image)
        Me.Rdb_Buscar_Uno.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Buscar_Uno.FocusCuesEnabled = False
        Me.Rdb_Buscar_Uno.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Buscar_Uno.Location = New System.Drawing.Point(235, 12)
        Me.Rdb_Buscar_Uno.Name = "Rdb_Buscar_Uno"
        Me.Rdb_Buscar_Uno.Size = New System.Drawing.Size(124, 19)
        Me.Rdb_Buscar_Uno.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Buscar_Uno.TabIndex = 137
        Me.Rdb_Buscar_Uno.Text = "Uno en particular"
        '
        'Rdb_ErrorEnvioCorreo
        '
        Me.Rdb_ErrorEnvioCorreo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_ErrorEnvioCorreo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_ErrorEnvioCorreo.CheckBoxImageChecked = CType(resources.GetObject("Rdb_ErrorEnvioCorreo.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_ErrorEnvioCorreo.CheckBoxImageUnChecked = CType(resources.GetObject("Rdb_ErrorEnvioCorreo.CheckBoxImageUnChecked"), System.Drawing.Image)
        Me.Rdb_ErrorEnvioCorreo.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_ErrorEnvioCorreo.FocusCuesEnabled = False
        Me.Rdb_ErrorEnvioCorreo.ForeColor = System.Drawing.Color.Black
        Me.Rdb_ErrorEnvioCorreo.Location = New System.Drawing.Point(4, 80)
        Me.Rdb_ErrorEnvioCorreo.Name = "Rdb_ErrorEnvioCorreo"
        Me.Rdb_ErrorEnvioCorreo.Size = New System.Drawing.Size(119, 15)
        Me.Rdb_ErrorEnvioCorreo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_ErrorEnvioCorreo.TabIndex = 140
        Me.Rdb_ErrorEnvioCorreo.Text = "Sin envió de correo"
        '
        'Frm_MantFacturasElecFiltrar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(479, 333)
        Me.Controls.Add(Me.Rdb_Buscar_Uno)
        Me.Controls.Add(Me.Rdb_Buscar_Todos)
        Me.Controls.Add(Me.Grupo_Uno)
        Me.Controls.Add(Me.Grupo_Estado)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.Grupo_Filtros)
        Me.Controls.Add(Me.Grupo_Fechas)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_MantFacturasElecFiltrar"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "INFORME DEL ESTADO DE ENVIOS DTE AL SII"
        Me.Grupo_Fechas.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.Dtp_Fecha_Emision_Desde, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_Fecha_Emision_Hasta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo_Filtros.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel9.ResumeLayout(False)
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel7.ResumeLayout(False)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo_Estado.ResumeLayout(False)
        Me.Grupo_Excepciones.ResumeLayout(False)
        Me.Grupo_Uno.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Grupo_Fechas As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dtp_Fecha_Emision_Desde As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Dtp_Fecha_Emision_Hasta As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Grupo_Filtros As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel9 As TableLayoutPanel
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TableLayoutPanel6 As TableLayoutPanel
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TableLayoutPanel7 As TableLayoutPanel
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Procesar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Rdb_Documentos_Todos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Documentos_Algunos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Entidades_Algunas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Entidades_Todas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Sucursales_Todas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Sucursales_Algunas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Responsables_Todos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Responsables_Algunos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Grupo_Estado As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grupo_Uno As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Txt_Documento As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_Buscar_Todos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Buscar_Uno As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_EstadoExcepciones As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_EstadoTodos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Grupo_Excepciones As TableLayoutPanel
    Friend WithEvents Rdb_EstadoSinFirmar As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_EstadoRechazados As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_EstadoAceptadosReparos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_EstadoAceptados As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_ErrorEnvioCorreo As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
