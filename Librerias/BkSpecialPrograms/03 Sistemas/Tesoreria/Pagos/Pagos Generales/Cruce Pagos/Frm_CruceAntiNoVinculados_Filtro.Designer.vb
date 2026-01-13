<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_CruceAntiNoVinculados_Filtro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_CruceAntiNoVinculados_Filtro))
        Me.Dtp_FechaHasta = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_FechaDesde = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Procesar = New DevComponents.DotNetBar.ButtonItem()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_Entidades_Algunas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Entidades_Todas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Chk_SoloClienteConDocPendientesPago = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_SinCruceAutomatico = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_SoloPagosPesos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.MetroStatusBar1 = New DevComponents.DotNetBar.Metro.MetroStatusBar()
        Me.Barra_Progreso = New DevComponents.DotNetBar.ProgressBarItem()
        Me.Lbl_Status = New DevComponents.DotNetBar.LabelItem()
        Me.Chk_MayorMenorQue = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Cmb_MayorMenorQue = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Input_MayorMenorQue = New DevComponents.Editors.IntegerInput()
        CType(Me.Dtp_FechaHasta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_FechaDesde, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.Input_MayorMenorQue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Dtp_FechaHasta
        '
        Me.Dtp_FechaHasta.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_FechaHasta.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_FechaHasta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaHasta.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_FechaHasta.ButtonDropDown.Visible = True
        Me.Dtp_FechaHasta.ForeColor = System.Drawing.Color.Black
        Me.Dtp_FechaHasta.IsPopupCalendarOpen = False
        Me.Dtp_FechaHasta.Location = New System.Drawing.Point(165, 20)
        '
        '
        '
        Me.Dtp_FechaHasta.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FechaHasta.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaHasta.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_FechaHasta.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_FechaHasta.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_FechaHasta.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FechaHasta.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_FechaHasta.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_FechaHasta.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_FechaHasta.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_FechaHasta.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaHasta.MonthCalendar.DisplayMonth = New Date(2025, 1, 1, 0, 0, 0, 0)
        Me.Dtp_FechaHasta.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_FechaHasta.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_FechaHasta.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FechaHasta.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_FechaHasta.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FechaHasta.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_FechaHasta.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaHasta.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_FechaHasta.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_FechaHasta.Name = "Dtp_FechaHasta"
        Me.Dtp_FechaHasta.Size = New System.Drawing.Size(80, 22)
        Me.Dtp_FechaHasta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_FechaHasta.TabIndex = 196
        Me.Dtp_FechaHasta.Value = New Date(2025, 1, 30, 12, 12, 50, 0)
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(133, 19)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(34, 23)
        Me.LabelX4.TabIndex = 198
        Me.LabelX4.Text = "hasta"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(11, 17)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(34, 23)
        Me.LabelX3.TabIndex = 197
        Me.LabelX3.Text = "desde"
        '
        'Dtp_FechaDesde
        '
        Me.Dtp_FechaDesde.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_FechaDesde.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_FechaDesde.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaDesde.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_FechaDesde.ButtonDropDown.Visible = True
        Me.Dtp_FechaDesde.ForeColor = System.Drawing.Color.Black
        Me.Dtp_FechaDesde.IsPopupCalendarOpen = False
        Me.Dtp_FechaDesde.Location = New System.Drawing.Point(48, 19)
        '
        '
        '
        Me.Dtp_FechaDesde.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FechaDesde.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaDesde.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_FechaDesde.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_FechaDesde.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_FechaDesde.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FechaDesde.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_FechaDesde.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_FechaDesde.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_FechaDesde.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_FechaDesde.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaDesde.MonthCalendar.DisplayMonth = New Date(2025, 1, 1, 0, 0, 0, 0)
        Me.Dtp_FechaDesde.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_FechaDesde.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_FechaDesde.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FechaDesde.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_FechaDesde.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FechaDesde.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_FechaDesde.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaDesde.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_FechaDesde.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_FechaDesde.Name = "Dtp_FechaDesde"
        Me.Dtp_FechaDesde.Size = New System.Drawing.Size(79, 22)
        Me.Dtp_FechaDesde.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_FechaDesde.TabIndex = 195
        Me.Dtp_FechaDesde.Value = New Date(2025, 1, 30, 12, 12, 50, 0)
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Dtp_FechaHasta)
        Me.GroupPanel1.Controls.Add(Me.Dtp_FechaDesde)
        Me.GroupPanel1.Controls.Add(Me.LabelX4)
        Me.GroupPanel1.Controls.Add(Me.LabelX3)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(282, 78)
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
        Me.GroupPanel1.TabIndex = 199
        Me.GroupPanel1.Text = "Periodo emisión de los pagos"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Procesar})
        Me.Bar1.Location = New System.Drawing.Point(0, 198)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(629, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 200
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
        Me.Btn_Procesar.Text = "Procesar"
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel6.ColumnCount = 3
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.LabelX7, 0, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.Rdb_Entidades_Algunas, 2, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.Rdb_Entidades_Todas, 1, 0)
        Me.TableLayoutPanel6.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(3, 17)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 1
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(296, 25)
        Me.TableLayoutPanel6.TabIndex = 201
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
        Me.LabelX7.Text = "Entidades"
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
        Me.Rdb_Entidades_Algunas.Location = New System.Drawing.Point(193, 3)
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
        Me.Rdb_Entidades_Todas.Location = New System.Drawing.Point(109, 3)
        Me.Rdb_Entidades_Todas.Name = "Rdb_Entidades_Todas"
        Me.Rdb_Entidades_Todas.Size = New System.Drawing.Size(78, 19)
        Me.Rdb_Entidades_Todas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Entidades_Todas.TabIndex = 1
        Me.Rdb_Entidades_Todas.Text = "Todas "
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.TableLayoutPanel6)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(300, 12)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(317, 78)
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
        Me.GroupPanel2.TabIndex = 202
        Me.GroupPanel2.Text = "Criterio de selección"
        '
        'Chk_SoloClienteConDocPendientesPago
        '
        Me.Chk_SoloClienteConDocPendientesPago.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_SoloClienteConDocPendientesPago.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_SoloClienteConDocPendientesPago.CheckBoxImageChecked = CType(resources.GetObject("Chk_SoloClienteConDocPendientesPago.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_SoloClienteConDocPendientesPago.FocusCuesEnabled = False
        Me.Chk_SoloClienteConDocPendientesPago.ForeColor = System.Drawing.Color.Black
        Me.Chk_SoloClienteConDocPendientesPago.Location = New System.Drawing.Point(12, 96)
        Me.Chk_SoloClienteConDocPendientesPago.Name = "Chk_SoloClienteConDocPendientesPago"
        Me.Chk_SoloClienteConDocPendientesPago.Size = New System.Drawing.Size(424, 23)
        Me.Chk_SoloClienteConDocPendientesPago.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_SoloClienteConDocPendientesPago.TabIndex = 203
        Me.Chk_SoloClienteConDocPendientesPago.Text = "Mostrar solo registros de clientes con documentos pendientes (facturas/boletas)"
        '
        'Chk_SinCruceAutomatico
        '
        Me.Chk_SinCruceAutomatico.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_SinCruceAutomatico.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_SinCruceAutomatico.CheckBoxImageChecked = CType(resources.GetObject("Chk_SinCruceAutomatico.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_SinCruceAutomatico.FocusCuesEnabled = False
        Me.Chk_SinCruceAutomatico.ForeColor = System.Drawing.Color.Black
        Me.Chk_SinCruceAutomatico.Location = New System.Drawing.Point(12, 119)
        Me.Chk_SinCruceAutomatico.Name = "Chk_SinCruceAutomatico"
        Me.Chk_SinCruceAutomatico.Size = New System.Drawing.Size(464, 23)
        Me.Chk_SinCruceAutomatico.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_SinCruceAutomatico.TabIndex = 204
        Me.Chk_SinCruceAutomatico.Text = "Excluir pagos vinculados a documentos en cruce automático"
        '
        'Chk_SoloPagosPesos
        '
        Me.Chk_SoloPagosPesos.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_SoloPagosPesos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_SoloPagosPesos.CheckBoxImageChecked = CType(resources.GetObject("Chk_SoloPagosPesos.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_SoloPagosPesos.FocusCuesEnabled = False
        Me.Chk_SoloPagosPesos.ForeColor = System.Drawing.Color.Black
        Me.Chk_SoloPagosPesos.Location = New System.Drawing.Point(12, 144)
        Me.Chk_SoloPagosPesos.Name = "Chk_SoloPagosPesos"
        Me.Chk_SoloPagosPesos.Size = New System.Drawing.Size(464, 18)
        Me.Chk_SoloPagosPesos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_SoloPagosPesos.TabIndex = 205
        Me.Chk_SoloPagosPesos.Text = "Solo pagos en $ pesos"
        '
        'MetroStatusBar1
        '
        Me.MetroStatusBar1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.MetroStatusBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MetroStatusBar1.ContainerControlProcessDialogKey = True
        Me.MetroStatusBar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.MetroStatusBar1.DragDropSupport = True
        Me.MetroStatusBar1.Font = New System.Drawing.Font("Segoe UI", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MetroStatusBar1.ForeColor = System.Drawing.Color.Black
        Me.MetroStatusBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Barra_Progreso, Me.Lbl_Status})
        Me.MetroStatusBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MetroStatusBar1.Location = New System.Drawing.Point(0, 239)
        Me.MetroStatusBar1.Name = "MetroStatusBar1"
        Me.MetroStatusBar1.Size = New System.Drawing.Size(629, 22)
        Me.MetroStatusBar1.TabIndex = 206
        Me.MetroStatusBar1.Text = "MetroStatusBar1"
        '
        'Barra_Progreso
        '
        '
        '
        '
        Me.Barra_Progreso.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Barra_Progreso.ChunkGradientAngle = 0!
        Me.Barra_Progreso.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.Barra_Progreso.Name = "Barra_Progreso"
        Me.Barra_Progreso.RecentlyUsed = False
        Me.Barra_Progreso.Visible = False
        '
        'Lbl_Status
        '
        Me.Lbl_Status.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Lbl_Status.Name = "Lbl_Status"
        Me.Lbl_Status.Text = "Status..."
        '
        'Chk_MayorMenorQue
        '
        Me.Chk_MayorMenorQue.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_MayorMenorQue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_MayorMenorQue.CheckBoxImageChecked = CType(resources.GetObject("Chk_MayorMenorQue.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_MayorMenorQue.FocusCuesEnabled = False
        Me.Chk_MayorMenorQue.ForeColor = System.Drawing.Color.Black
        Me.Chk_MayorMenorQue.Location = New System.Drawing.Point(12, 168)
        Me.Chk_MayorMenorQue.Name = "Chk_MayorMenorQue"
        Me.Chk_MayorMenorQue.Size = New System.Drawing.Size(72, 22)
        Me.Chk_MayorMenorQue.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_MayorMenorQue.TabIndex = 208
        Me.Chk_MayorMenorQue.Text = "Solo pagos"
        '
        'Cmb_MayorMenorQue
        '
        Me.Cmb_MayorMenorQue.DisplayMember = "Text"
        Me.Cmb_MayorMenorQue.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_MayorMenorQue.ForeColor = System.Drawing.Color.Black
        Me.Cmb_MayorMenorQue.FormattingEnabled = True
        Me.Cmb_MayorMenorQue.ItemHeight = 16
        Me.Cmb_MayorMenorQue.Location = New System.Drawing.Point(90, 168)
        Me.Cmb_MayorMenorQue.Name = "Cmb_MayorMenorQue"
        Me.Cmb_MayorMenorQue.Size = New System.Drawing.Size(204, 22)
        Me.Cmb_MayorMenorQue.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_MayorMenorQue.TabIndex = 210
        '
        'Input_MayorMenorQue
        '
        Me.Input_MayorMenorQue.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_MayorMenorQue.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_MayorMenorQue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_MayorMenorQue.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.Input_MayorMenorQue.ForeColor = System.Drawing.Color.Black
        Me.Input_MayorMenorQue.Location = New System.Drawing.Point(306, 168)
        Me.Input_MayorMenorQue.MinValue = 1
        Me.Input_MayorMenorQue.Name = "Input_MayorMenorQue"
        Me.Input_MayorMenorQue.ShowUpDown = True
        Me.Input_MayorMenorQue.Size = New System.Drawing.Size(71, 22)
        Me.Input_MayorMenorQue.TabIndex = 211
        Me.Input_MayorMenorQue.Value = 1000
        '
        'Frm_CruceAntiNoVinculados_Filtro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(629, 261)
        Me.Controls.Add(Me.Input_MayorMenorQue)
        Me.Controls.Add(Me.Cmb_MayorMenorQue)
        Me.Controls.Add(Me.Chk_MayorMenorQue)
        Me.Controls.Add(Me.Chk_SoloPagosPesos)
        Me.Controls.Add(Me.Chk_SinCruceAutomatico)
        Me.Controls.Add(Me.Chk_SoloClienteConDocPendientesPago)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.MetroStatusBar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_CruceAntiNoVinculados_Filtro"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informe de situación de anticipos de clientes "
        CType(Me.Dtp_FechaHasta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_FechaDesde, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.Input_MayorMenorQue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Dtp_FechaHasta As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dtp_FechaDesde As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Procesar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents TableLayoutPanel6 As TableLayoutPanel
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_Entidades_Algunas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Entidades_Todas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Chk_SoloClienteConDocPendientesPago As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_SinCruceAutomatico As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_SoloPagosPesos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents MetroStatusBar1 As DevComponents.DotNetBar.Metro.MetroStatusBar
    Friend WithEvents Barra_Progreso As DevComponents.DotNetBar.ProgressBarItem
    Friend WithEvents Lbl_Status As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Chk_MayorMenorQue As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Cmb_MayorMenorQue As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Input_MayorMenorQue As DevComponents.Editors.IntegerInput
End Class
