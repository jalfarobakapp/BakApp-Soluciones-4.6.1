<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Inf_Vencimientos_Procesar_Informe
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Inf_Vencimientos_Procesar_Informe))
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Procesar_Informe = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Entidades_Excluidas = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Configuracion_Local = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Dtp_Fecha_Hasta = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_Fecha_Desde = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Progreso_Porc = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.Progreso_Cont = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.Lbl_Nombre_Empresa = New DevComponents.DotNetBar.LabelX()
        Me.Chk_Deuda_Efectiva = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.GroupPanel4 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Chk_Excluir_Documentos_Autorizados_Pago = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_Anotaciones_Algunas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Anotaciones_Todas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_Vendedores_Algunos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Vendedores_Todos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_Sucursales_Algunas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Sucursales_Todas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_Entidades_Algunas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Entidades_Todas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.Dtp_Fecha_Hasta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_Fecha_Desde, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel4.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Procesar_Informe, Me.Btn_Entidades_Excluidas, Me.Btn_Configuracion_Local})
        Me.Bar1.Location = New System.Drawing.Point(0, 387)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(385, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 22
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Procesar_Informe
        '
        Me.Btn_Procesar_Informe.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Procesar_Informe.ForeColor = System.Drawing.Color.Black
        Me.Btn_Procesar_Informe.Image = CType(resources.GetObject("Btn_Procesar_Informe.Image"), System.Drawing.Image)
        Me.Btn_Procesar_Informe.Name = "Btn_Procesar_Informe"
        Me.Btn_Procesar_Informe.Text = "Procesar informe"
        '
        'Btn_Entidades_Excluidas
        '
        Me.Btn_Entidades_Excluidas.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Entidades_Excluidas.ForeColor = System.Drawing.Color.Black
        Me.Btn_Entidades_Excluidas.Image = CType(resources.GetObject("Btn_Entidades_Excluidas.Image"), System.Drawing.Image)
        Me.Btn_Entidades_Excluidas.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.Btn_Entidades_Excluidas.Name = "Btn_Entidades_Excluidas"
        Me.Btn_Entidades_Excluidas.Tooltip = "Entidades excluidas"
        '
        'Btn_Configuracion_Local
        '
        Me.Btn_Configuracion_Local.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Configuracion_Local.ForeColor = System.Drawing.Color.Black
        Me.Btn_Configuracion_Local.Image = CType(resources.GetObject("Btn_Configuracion_Local.Image"), System.Drawing.Image)
        Me.Btn_Configuracion_Local.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.Btn_Configuracion_Local.Name = "Btn_Configuracion_Local"
        Me.Btn_Configuracion_Local.Tooltip = "Configuración local"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 29)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(361, 62)
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
        Me.GroupPanel1.TabIndex = 23
        Me.GroupPanel1.Text = "Rango de fechas"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.45238!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.25!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.15476!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.14286!))
        Me.TableLayoutPanel1.Controls.Add(Me.Dtp_Fecha_Hasta, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX5, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX4, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Dtp_Fecha_Desde, 1, 0)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(8, 8)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(336, 44)
        Me.TableLayoutPanel1.TabIndex = 37
        '
        'Dtp_Fecha_Hasta
        '
        '
        '
        '
        Me.Dtp_Fecha_Hasta.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Hasta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Hasta.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Hasta.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Hasta.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Hasta.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Hasta.Location = New System.Drawing.Point(229, 3)
        '
        '
        '
        Me.Dtp_Fecha_Hasta.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Hasta.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Hasta.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Hasta.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Hasta.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Hasta.MonthCalendar.DisplayMonth = New Date(2016, 6, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Hasta.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_Fecha_Hasta.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Hasta.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Hasta.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Hasta.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Hasta.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Hasta.Name = "Dtp_Fecha_Hasta"
        Me.Dtp_Fecha_Hasta.Size = New System.Drawing.Size(94, 22)
        Me.Dtp_Fecha_Hasta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Hasta.TabIndex = 39
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(169, 3)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(54, 18)
        Me.LabelX5.TabIndex = 38
        Me.LabelX5.Text = "Hasta"
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(3, 3)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(55, 18)
        Me.LabelX4.TabIndex = 38
        Me.LabelX4.Text = "Desde"
        '
        'Dtp_Fecha_Desde
        '
        '
        '
        '
        Me.Dtp_Fecha_Desde.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Desde.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Desde.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Desde.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Desde.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Desde.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Desde.Location = New System.Drawing.Point(64, 3)
        '
        '
        '
        Me.Dtp_Fecha_Desde.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Desde.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Desde.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Desde.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Desde.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Desde.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Desde.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Desde.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Desde.MonthCalendar.DisplayMonth = New Date(2016, 6, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Desde.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_Fecha_Desde.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Desde.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Desde.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Desde.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Desde.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Desde.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Desde.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Desde.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Desde.Name = "Dtp_Fecha_Desde"
        Me.Dtp_Fecha_Desde.Size = New System.Drawing.Size(99, 22)
        Me.Dtp_Fecha_Desde.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Desde.TabIndex = 38
        '
        'Progreso_Porc
        '
        Me.Progreso_Porc.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Progreso_Porc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Progreso_Porc.Location = New System.Drawing.Point(74, 335)
        Me.Progreso_Porc.Name = "Progreso_Porc"
        Me.Progreso_Porc.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.Progreso_Porc.ProgressColor = System.Drawing.Color.SteelBlue
        Me.Progreso_Porc.ProgressTextVisible = True
        Me.Progreso_Porc.Size = New System.Drawing.Size(56, 46)
        Me.Progreso_Porc.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.Progreso_Porc.TabIndex = 32
        '
        'Progreso_Cont
        '
        Me.Progreso_Cont.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Progreso_Cont.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Progreso_Cont.Location = New System.Drawing.Point(12, 335)
        Me.Progreso_Cont.Name = "Progreso_Cont"
        Me.Progreso_Cont.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.Progreso_Cont.ProgressColor = System.Drawing.Color.SteelBlue
        Me.Progreso_Cont.ProgressTextFormat = "{0}"
        Me.Progreso_Cont.ProgressTextVisible = True
        Me.Progreso_Cont.Size = New System.Drawing.Size(56, 46)
        Me.Progreso_Cont.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.Progreso_Cont.TabIndex = 31
        '
        'Lbl_Nombre_Empresa
        '
        Me.Lbl_Nombre_Empresa.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Nombre_Empresa.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Nombre_Empresa.Dock = System.Windows.Forms.DockStyle.Top
        Me.Lbl_Nombre_Empresa.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Nombre_Empresa.Location = New System.Drawing.Point(0, 0)
        Me.Lbl_Nombre_Empresa.Name = "Lbl_Nombre_Empresa"
        Me.Lbl_Nombre_Empresa.Size = New System.Drawing.Size(385, 23)
        Me.Lbl_Nombre_Empresa.TabIndex = 33
        Me.Lbl_Nombre_Empresa.Text = "Empresa: "
        '
        'Chk_Deuda_Efectiva
        '
        Me.Chk_Deuda_Efectiva.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Deuda_Efectiva.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Deuda_Efectiva.ForeColor = System.Drawing.Color.Black
        Me.Chk_Deuda_Efectiva.Location = New System.Drawing.Point(8, 144)
        Me.Chk_Deuda_Efectiva.Name = "Chk_Deuda_Efectiva"
        Me.Chk_Deuda_Efectiva.Size = New System.Drawing.Size(206, 23)
        Me.Chk_Deuda_Efectiva.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Deuda_Efectiva.TabIndex = 0
        Me.Chk_Deuda_Efectiva.Text = "Mostrar deuda efectiva (Doc. Pago)"
        '
        'GroupPanel4
        '
        Me.GroupPanel4.BackColor = System.Drawing.Color.White
        Me.GroupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel4.Controls.Add(Me.Chk_Excluir_Documentos_Autorizados_Pago)
        Me.GroupPanel4.Controls.Add(Me.TableLayoutPanel5)
        Me.GroupPanel4.Controls.Add(Me.Chk_Deuda_Efectiva)
        Me.GroupPanel4.Controls.Add(Me.TableLayoutPanel4)
        Me.GroupPanel4.Controls.Add(Me.TableLayoutPanel3)
        Me.GroupPanel4.Controls.Add(Me.TableLayoutPanel2)
        Me.GroupPanel4.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel4.Location = New System.Drawing.Point(12, 107)
        Me.GroupPanel4.Name = "GroupPanel4"
        Me.GroupPanel4.Size = New System.Drawing.Size(361, 222)
        '
        '
        '
        Me.GroupPanel4.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel4.Style.BackColorGradientAngle = 90
        Me.GroupPanel4.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel4.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderBottomWidth = 1
        Me.GroupPanel4.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel4.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderLeftWidth = 1
        Me.GroupPanel4.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderRightWidth = 1
        Me.GroupPanel4.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderTopWidth = 1
        Me.GroupPanel4.Style.CornerDiameter = 4
        Me.GroupPanel4.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel4.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel4.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel4.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel4.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel4.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel4.TabIndex = 36
        Me.GroupPanel4.Text = "Filtros"
        '
        'Chk_Excluir_Documentos_Autorizados_Pago
        '
        Me.Chk_Excluir_Documentos_Autorizados_Pago.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Excluir_Documentos_Autorizados_Pago.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Excluir_Documentos_Autorizados_Pago.ForeColor = System.Drawing.Color.Black
        Me.Chk_Excluir_Documentos_Autorizados_Pago.Location = New System.Drawing.Point(8, 167)
        Me.Chk_Excluir_Documentos_Autorizados_Pago.Name = "Chk_Excluir_Documentos_Autorizados_Pago"
        Me.Chk_Excluir_Documentos_Autorizados_Pago.Size = New System.Drawing.Size(269, 23)
        Me.Chk_Excluir_Documentos_Autorizados_Pago.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Excluir_Documentos_Autorizados_Pago.TabIndex = 6
        Me.Chk_Excluir_Documentos_Autorizados_Pago.Text = "Excluir documentos autorizados para pago"
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel5.ColumnCount = 3
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.LabelX6, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Rdb_Anotaciones_Algunas, 2, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Rdb_Anotaciones_Todas, 1, 0)
        Me.TableLayoutPanel5.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(8, 101)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 1
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(339, 25)
        Me.TableLayoutPanel5.TabIndex = 5
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(3, 3)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(131, 19)
        Me.LabelX6.TabIndex = 4
        Me.LabelX6.Text = "Anotaciones Tabuladas"
        '
        'Rdb_Anotaciones_Algunas
        '
        Me.Rdb_Anotaciones_Algunas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Anotaciones_Algunas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Anotaciones_Algunas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Anotaciones_Algunas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Anotaciones_Algunas.Location = New System.Drawing.Point(231, 3)
        Me.Rdb_Anotaciones_Algunas.Name = "Rdb_Anotaciones_Algunas"
        Me.Rdb_Anotaciones_Algunas.Size = New System.Drawing.Size(94, 19)
        Me.Rdb_Anotaciones_Algunas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Anotaciones_Algunas.TabIndex = 3
        Me.Rdb_Anotaciones_Algunas.Text = "Algunos"
        '
        'Rdb_Anotaciones_Todas
        '
        Me.Rdb_Anotaciones_Todas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Anotaciones_Todas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Anotaciones_Todas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Anotaciones_Todas.Checked = True
        Me.Rdb_Anotaciones_Todas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Anotaciones_Todas.CheckValue = "Y"
        Me.Rdb_Anotaciones_Todas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Anotaciones_Todas.Location = New System.Drawing.Point(140, 3)
        Me.Rdb_Anotaciones_Todas.Name = "Rdb_Anotaciones_Todas"
        Me.Rdb_Anotaciones_Todas.Size = New System.Drawing.Size(85, 19)
        Me.Rdb_Anotaciones_Todas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Anotaciones_Todas.TabIndex = 1
        Me.Rdb_Anotaciones_Todas.Text = "Todos"
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel4.ColumnCount = 3
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.LabelX3, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Rdb_Vendedores_Algunos, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Rdb_Vendedores_Todos, 1, 0)
        Me.TableLayoutPanel4.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(8, 70)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(339, 25)
        Me.TableLayoutPanel4.TabIndex = 4
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(3, 3)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(131, 19)
        Me.LabelX3.TabIndex = 4
        Me.LabelX3.Text = "Vendedores"
        '
        'Rdb_Vendedores_Algunos
        '
        Me.Rdb_Vendedores_Algunos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Vendedores_Algunos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Vendedores_Algunos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Vendedores_Algunos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Vendedores_Algunos.Location = New System.Drawing.Point(231, 3)
        Me.Rdb_Vendedores_Algunos.Name = "Rdb_Vendedores_Algunos"
        Me.Rdb_Vendedores_Algunos.Size = New System.Drawing.Size(94, 19)
        Me.Rdb_Vendedores_Algunos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Vendedores_Algunos.TabIndex = 3
        Me.Rdb_Vendedores_Algunos.Text = "Algunos"
        '
        'Rdb_Vendedores_Todos
        '
        Me.Rdb_Vendedores_Todos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Vendedores_Todos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Vendedores_Todos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Vendedores_Todos.Checked = True
        Me.Rdb_Vendedores_Todos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Vendedores_Todos.CheckValue = "Y"
        Me.Rdb_Vendedores_Todos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Vendedores_Todos.Location = New System.Drawing.Point(140, 3)
        Me.Rdb_Vendedores_Todos.Name = "Rdb_Vendedores_Todos"
        Me.Rdb_Vendedores_Todos.Size = New System.Drawing.Size(85, 19)
        Me.Rdb_Vendedores_Todos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Vendedores_Todos.TabIndex = 1
        Me.Rdb_Vendedores_Todos.Text = "Todos"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel3.ColumnCount = 3
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.LabelX2, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Rdb_Sucursales_Algunas, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Rdb_Sucursales_Todas, 1, 0)
        Me.TableLayoutPanel3.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(8, 42)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(339, 25)
        Me.TableLayoutPanel3.TabIndex = 3
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
        Me.LabelX2.Size = New System.Drawing.Size(131, 19)
        Me.LabelX2.TabIndex = 4
        Me.LabelX2.Text = "Sucursales"
        '
        'Rdb_Sucursales_Algunas
        '
        Me.Rdb_Sucursales_Algunas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Sucursales_Algunas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Sucursales_Algunas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Sucursales_Algunas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Sucursales_Algunas.Location = New System.Drawing.Point(231, 3)
        Me.Rdb_Sucursales_Algunas.Name = "Rdb_Sucursales_Algunas"
        Me.Rdb_Sucursales_Algunas.Size = New System.Drawing.Size(94, 19)
        Me.Rdb_Sucursales_Algunas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Sucursales_Algunas.TabIndex = 3
        Me.Rdb_Sucursales_Algunas.Text = "Algunas"
        '
        'Rdb_Sucursales_Todas
        '
        Me.Rdb_Sucursales_Todas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Sucursales_Todas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Sucursales_Todas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Sucursales_Todas.Checked = True
        Me.Rdb_Sucursales_Todas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Sucursales_Todas.CheckValue = "Y"
        Me.Rdb_Sucursales_Todas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Sucursales_Todas.Location = New System.Drawing.Point(140, 3)
        Me.Rdb_Sucursales_Todas.Name = "Rdb_Sucursales_Todas"
        Me.Rdb_Sucursales_Todas.Size = New System.Drawing.Size(85, 19)
        Me.Rdb_Sucursales_Todas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Sucursales_Todas.TabIndex = 1
        Me.Rdb_Sucursales_Todas.Text = "Todas "
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.LabelX1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Rdb_Entidades_Algunas, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Rdb_Entidades_Todas, 1, 0)
        Me.TableLayoutPanel2.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(8, 14)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(339, 25)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(131, 19)
        Me.LabelX1.TabIndex = 4
        Me.LabelX1.Text = "Entidades"
        '
        'Rdb_Entidades_Algunas
        '
        Me.Rdb_Entidades_Algunas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Entidades_Algunas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Entidades_Algunas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Entidades_Algunas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Entidades_Algunas.Location = New System.Drawing.Point(231, 3)
        Me.Rdb_Entidades_Algunas.Name = "Rdb_Entidades_Algunas"
        Me.Rdb_Entidades_Algunas.Size = New System.Drawing.Size(94, 19)
        Me.Rdb_Entidades_Algunas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Entidades_Algunas.TabIndex = 3
        Me.Rdb_Entidades_Algunas.Text = "Algunas"
        '
        'Rdb_Entidades_Todas
        '
        Me.Rdb_Entidades_Todas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Entidades_Todas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Entidades_Todas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Entidades_Todas.Checked = True
        Me.Rdb_Entidades_Todas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Entidades_Todas.CheckValue = "Y"
        Me.Rdb_Entidades_Todas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Entidades_Todas.Location = New System.Drawing.Point(140, 3)
        Me.Rdb_Entidades_Todas.Name = "Rdb_Entidades_Todas"
        Me.Rdb_Entidades_Todas.Size = New System.Drawing.Size(85, 19)
        Me.Rdb_Entidades_Todas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Entidades_Todas.TabIndex = 1
        Me.Rdb_Entidades_Todas.Text = "Todas "
        '
        'Frm_Inf_Vencimientos_Procesar_Informe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(385, 428)
        Me.Controls.Add(Me.GroupPanel4)
        Me.Controls.Add(Me.Lbl_Nombre_Empresa)
        Me.Controls.Add(Me.Progreso_Porc)
        Me.Controls.Add(Me.Progreso_Cont)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Inf_Vencimientos_Procesar_Informe"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.Dtp_Fecha_Hasta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_Fecha_Desde, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel4.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Procesar_Informe As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Progreso_Porc As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Progreso_Cont As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Btn_Configuracion_Local As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Lbl_Nombre_Empresa As DevComponents.DotNetBar.LabelX
    Friend WithEvents Chk_Deuda_Efectiva As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Entidades_Todas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Entidades_Algunas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents GroupPanel4 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_Vendedores_Algunos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Vendedores_Todos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_Sucursales_Algunas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Sucursales_Todas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dtp_Fecha_Hasta As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Dtp_Fecha_Desde As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_Anotaciones_Algunas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Anotaciones_Todas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Btn_Entidades_Excluidas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Chk_Excluir_Documentos_Autorizados_Pago As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
