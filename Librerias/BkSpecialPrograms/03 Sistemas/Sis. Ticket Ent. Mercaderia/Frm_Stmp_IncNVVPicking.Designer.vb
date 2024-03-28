<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Stmp_IncNVVPicking
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Stmp_IncNVVPicking))
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Dtp_FechaParaFacturacion = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.GroupPanel4 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Txt_Ocdo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_BuscaXObservaciones = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.Cmb_TipoVenta = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_BuscaXFechaDespacho = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_BuscaXFechaEmision = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_BuscaXEntidad = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_BuscaXNudoNVV = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Observaciones = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Chk_Imprimir = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Input_Monto_Max_CRV_FacMasiva = New DevComponents.Editors.IntegerInput()
        Me.Chk_Pagar_Documentos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Pagar_Saldos_CRV = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_PickearTodo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_EnviarPickear = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_ActualizarLista = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Cancelar = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_01_Opciones_Documento = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Ver_documento = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Ver_Anotaciones_Documento = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_Opciones_Especiales = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Config_Tipo_Estacion = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Config_Impresora = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Config_Impresora_Local = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Config_Impresora_Diablito = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Impresion_PDF = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.MetroStatusBar1 = New DevComponents.DotNetBar.Metro.MetroStatusBar()
        Me.Lbl_Status = New DevComponents.DotNetBar.LabelItem()
        Me.Chk_FacturarTodo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        CType(Me.Dtp_FechaParaFacturacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel4.SuspendLayout()
        CType(Me.Dtp_BuscaXFechaDespacho, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_BuscaXFechaEmision, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Input_Monto_Max_CRV_FacMasiva, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Dtp_FechaParaFacturacion
        '
        Me.Dtp_FechaParaFacturacion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_FechaParaFacturacion.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_FechaParaFacturacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaParaFacturacion.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_FechaParaFacturacion.ButtonDropDown.Visible = True
        Me.Dtp_FechaParaFacturacion.ForeColor = System.Drawing.Color.Black
        Me.Dtp_FechaParaFacturacion.IsPopupCalendarOpen = False
        Me.Dtp_FechaParaFacturacion.Location = New System.Drawing.Point(132, 3)
        '
        '
        '
        Me.Dtp_FechaParaFacturacion.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FechaParaFacturacion.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaParaFacturacion.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_FechaParaFacturacion.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_FechaParaFacturacion.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_FechaParaFacturacion.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FechaParaFacturacion.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_FechaParaFacturacion.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_FechaParaFacturacion.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_FechaParaFacturacion.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_FechaParaFacturacion.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaParaFacturacion.MonthCalendar.DisplayMonth = New Date(2021, 1, 1, 0, 0, 0, 0)
        Me.Dtp_FechaParaFacturacion.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_FechaParaFacturacion.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_FechaParaFacturacion.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FechaParaFacturacion.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_FechaParaFacturacion.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FechaParaFacturacion.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_FechaParaFacturacion.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaParaFacturacion.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_FechaParaFacturacion.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_FechaParaFacturacion.Name = "Dtp_FechaParaFacturacion"
        Me.Dtp_FechaParaFacturacion.Size = New System.Drawing.Size(83, 22)
        Me.Dtp_FechaParaFacturacion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_FechaParaFacturacion.TabIndex = 132
        Me.Dtp_FechaParaFacturacion.Value = New Date(2024, 3, 21, 0, 0, 0, 0)
        '
        'GroupPanel4
        '
        Me.GroupPanel4.BackColor = System.Drawing.Color.White
        Me.GroupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel4.Controls.Add(Me.Txt_Ocdo)
        Me.GroupPanel4.Controls.Add(Me.LabelX8)
        Me.GroupPanel4.Controls.Add(Me.Txt_BuscaXObservaciones)
        Me.GroupPanel4.Controls.Add(Me.LabelX7)
        Me.GroupPanel4.Controls.Add(Me.Cmb_TipoVenta)
        Me.GroupPanel4.Controls.Add(Me.LabelX6)
        Me.GroupPanel4.Controls.Add(Me.Dtp_BuscaXFechaDespacho)
        Me.GroupPanel4.Controls.Add(Me.LabelX4)
        Me.GroupPanel4.Controls.Add(Me.Dtp_BuscaXFechaEmision)
        Me.GroupPanel4.Controls.Add(Me.LabelX3)
        Me.GroupPanel4.Controls.Add(Me.Txt_BuscaXEntidad)
        Me.GroupPanel4.Controls.Add(Me.LabelX2)
        Me.GroupPanel4.Controls.Add(Me.Txt_BuscaXNudoNVV)
        Me.GroupPanel4.Controls.Add(Me.LabelX5)
        Me.GroupPanel4.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel4.Location = New System.Drawing.Point(9, 22)
        Me.GroupPanel4.Name = "GroupPanel4"
        Me.GroupPanel4.Size = New System.Drawing.Size(1272, 78)
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
        Me.GroupPanel4.TabIndex = 135
        Me.GroupPanel4.Text = "Filtrar notas de venta"
        '
        'Txt_Ocdo
        '
        Me.Txt_Ocdo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Ocdo.Border.Class = "TextBoxBorder"
        Me.Txt_Ocdo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Ocdo.ButtonCustom.Image = CType(resources.GetObject("Txt_Ocdo.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Ocdo.ButtonCustom.Visible = True
        Me.Txt_Ocdo.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Ocdo.ForeColor = System.Drawing.Color.Black
        Me.Txt_Ocdo.Location = New System.Drawing.Point(816, 30)
        Me.Txt_Ocdo.MaxLength = 20
        Me.Txt_Ocdo.Name = "Txt_Ocdo"
        Me.Txt_Ocdo.PreventEnterBeep = True
        Me.Txt_Ocdo.Size = New System.Drawing.Size(120, 22)
        Me.Txt_Ocdo.TabIndex = 22
        '
        'LabelX8
        '
        Me.LabelX8.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.ForeColor = System.Drawing.Color.Black
        Me.LabelX8.Location = New System.Drawing.Point(816, 10)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(89, 23)
        Me.LabelX8.TabIndex = 21
        Me.LabelX8.Text = "Orden de compra"
        '
        'Txt_BuscaXObservaciones
        '
        Me.Txt_BuscaXObservaciones.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_BuscaXObservaciones.Border.Class = "TextBoxBorder"
        Me.Txt_BuscaXObservaciones.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_BuscaXObservaciones.ButtonCustom.Image = CType(resources.GetObject("Txt_BuscaXObservaciones.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_BuscaXObservaciones.ButtonCustom.Visible = True
        Me.Txt_BuscaXObservaciones.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_BuscaXObservaciones.ForeColor = System.Drawing.Color.Black
        Me.Txt_BuscaXObservaciones.Location = New System.Drawing.Point(497, 30)
        Me.Txt_BuscaXObservaciones.Name = "Txt_BuscaXObservaciones"
        Me.Txt_BuscaXObservaciones.PreventEnterBeep = True
        Me.Txt_BuscaXObservaciones.Size = New System.Drawing.Size(313, 22)
        Me.Txt_BuscaXObservaciones.TabIndex = 19
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.ForeColor = System.Drawing.Color.Black
        Me.LabelX7.Location = New System.Drawing.Point(497, 10)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(141, 23)
        Me.LabelX7.TabIndex = 20
        Me.LabelX7.Text = "Observaciones"
        '
        'Cmb_TipoVenta
        '
        Me.Cmb_TipoVenta.DisplayMember = "Text"
        Me.Cmb_TipoVenta.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_TipoVenta.ForeColor = System.Drawing.Color.Black
        Me.Cmb_TipoVenta.FormattingEnabled = True
        Me.Cmb_TipoVenta.ItemHeight = 16
        Me.Cmb_TipoVenta.Location = New System.Drawing.Point(1156, 29)
        Me.Cmb_TipoVenta.Name = "Cmb_TipoVenta"
        Me.Cmb_TipoVenta.Size = New System.Drawing.Size(68, 22)
        Me.Cmb_TipoVenta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_TipoVenta.TabIndex = 17
        Me.Cmb_TipoVenta.Text = "Todas..."
        Me.Cmb_TipoVenta.Visible = False
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(1156, 10)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(68, 23)
        Me.LabelX6.TabIndex = 18
        Me.LabelX6.Text = "Tipo de venta"
        Me.LabelX6.Visible = False
        '
        'Dtp_BuscaXFechaDespacho
        '
        Me.Dtp_BuscaXFechaDespacho.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_BuscaXFechaDespacho.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_BuscaXFechaDespacho.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_BuscaXFechaDespacho.ButtonClear.Visible = True
        Me.Dtp_BuscaXFechaDespacho.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_BuscaXFechaDespacho.ButtonDropDown.Visible = True
        Me.Dtp_BuscaXFechaDespacho.ForeColor = System.Drawing.Color.Black
        Me.Dtp_BuscaXFechaDespacho.IsPopupCalendarOpen = False
        Me.Dtp_BuscaXFechaDespacho.Location = New System.Drawing.Point(1049, 30)
        '
        '
        '
        Me.Dtp_BuscaXFechaDespacho.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_BuscaXFechaDespacho.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_BuscaXFechaDespacho.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_BuscaXFechaDespacho.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_BuscaXFechaDespacho.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_BuscaXFechaDespacho.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_BuscaXFechaDespacho.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_BuscaXFechaDespacho.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_BuscaXFechaDespacho.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_BuscaXFechaDespacho.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_BuscaXFechaDespacho.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_BuscaXFechaDespacho.MonthCalendar.DisplayMonth = New Date(2023, 3, 1, 0, 0, 0, 0)
        Me.Dtp_BuscaXFechaDespacho.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_BuscaXFechaDespacho.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_BuscaXFechaDespacho.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_BuscaXFechaDespacho.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_BuscaXFechaDespacho.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_BuscaXFechaDespacho.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_BuscaXFechaDespacho.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_BuscaXFechaDespacho.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_BuscaXFechaDespacho.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_BuscaXFechaDespacho.Name = "Dtp_BuscaXFechaDespacho"
        Me.Dtp_BuscaXFechaDespacho.Size = New System.Drawing.Size(101, 22)
        Me.Dtp_BuscaXFechaDespacho.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_BuscaXFechaDespacho.TabIndex = 16
        Me.Dtp_BuscaXFechaDespacho.Value = New Date(2023, 3, 6, 13, 17, 7, 0)
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(1049, 10)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(93, 23)
        Me.LabelX4.TabIndex = 15
        Me.LabelX4.Text = "Fecha Despacho"
        '
        'Dtp_BuscaXFechaEmision
        '
        Me.Dtp_BuscaXFechaEmision.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_BuscaXFechaEmision.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_BuscaXFechaEmision.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_BuscaXFechaEmision.ButtonClear.Visible = True
        Me.Dtp_BuscaXFechaEmision.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_BuscaXFechaEmision.ButtonDropDown.Visible = True
        Me.Dtp_BuscaXFechaEmision.ForeColor = System.Drawing.Color.Black
        Me.Dtp_BuscaXFechaEmision.IsPopupCalendarOpen = False
        Me.Dtp_BuscaXFechaEmision.Location = New System.Drawing.Point(942, 30)
        '
        '
        '
        Me.Dtp_BuscaXFechaEmision.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_BuscaXFechaEmision.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_BuscaXFechaEmision.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_BuscaXFechaEmision.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_BuscaXFechaEmision.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_BuscaXFechaEmision.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_BuscaXFechaEmision.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_BuscaXFechaEmision.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_BuscaXFechaEmision.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_BuscaXFechaEmision.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_BuscaXFechaEmision.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_BuscaXFechaEmision.MonthCalendar.DisplayMonth = New Date(2023, 3, 1, 0, 0, 0, 0)
        Me.Dtp_BuscaXFechaEmision.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_BuscaXFechaEmision.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_BuscaXFechaEmision.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_BuscaXFechaEmision.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_BuscaXFechaEmision.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_BuscaXFechaEmision.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_BuscaXFechaEmision.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_BuscaXFechaEmision.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_BuscaXFechaEmision.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_BuscaXFechaEmision.Name = "Dtp_BuscaXFechaEmision"
        Me.Dtp_BuscaXFechaEmision.Size = New System.Drawing.Size(101, 22)
        Me.Dtp_BuscaXFechaEmision.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_BuscaXFechaEmision.TabIndex = 14
        Me.Dtp_BuscaXFechaEmision.Value = New Date(2023, 3, 6, 13, 17, 7, 0)
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(942, 10)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(93, 23)
        Me.LabelX3.TabIndex = 13
        Me.LabelX3.Text = "Fecha Emisión"
        '
        'Txt_BuscaXEntidad
        '
        Me.Txt_BuscaXEntidad.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_BuscaXEntidad.Border.Class = "TextBoxBorder"
        Me.Txt_BuscaXEntidad.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_BuscaXEntidad.ButtonCustom.Image = CType(resources.GetObject("Txt_BuscaXEntidad.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_BuscaXEntidad.ButtonCustom.Visible = True
        Me.Txt_BuscaXEntidad.ButtonCustom2.Image = CType(resources.GetObject("Txt_BuscaXEntidad.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_BuscaXEntidad.ButtonCustom2.Visible = True
        Me.Txt_BuscaXEntidad.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_BuscaXEntidad.ForeColor = System.Drawing.Color.Black
        Me.Txt_BuscaXEntidad.Location = New System.Drawing.Point(150, 30)
        Me.Txt_BuscaXEntidad.Name = "Txt_BuscaXEntidad"
        Me.Txt_BuscaXEntidad.PreventEnterBeep = True
        Me.Txt_BuscaXEntidad.ReadOnly = True
        Me.Txt_BuscaXEntidad.Size = New System.Drawing.Size(341, 22)
        Me.Txt_BuscaXEntidad.TabIndex = 6
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(150, 10)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 23)
        Me.LabelX2.TabIndex = 7
        Me.LabelX2.Text = "Entidad"
        '
        'Txt_BuscaXNudoNVV
        '
        Me.Txt_BuscaXNudoNVV.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_BuscaXNudoNVV.Border.Class = "TextBoxBorder"
        Me.Txt_BuscaXNudoNVV.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_BuscaXNudoNVV.ButtonCustom.Image = CType(resources.GetObject("Txt_BuscaXNudoNVV.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_BuscaXNudoNVV.ButtonCustom.Visible = True
        Me.Txt_BuscaXNudoNVV.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_BuscaXNudoNVV.ForeColor = System.Drawing.Color.Black
        Me.Txt_BuscaXNudoNVV.Location = New System.Drawing.Point(3, 30)
        Me.Txt_BuscaXNudoNVV.Name = "Txt_BuscaXNudoNVV"
        Me.Txt_BuscaXNudoNVV.PreventEnterBeep = True
        Me.Txt_BuscaXNudoNVV.Size = New System.Drawing.Size(141, 22)
        Me.Txt_BuscaXNudoNVV.TabIndex = 3
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(3, 10)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(141, 23)
        Me.LabelX5.TabIndex = 5
        Me.LabelX5.Text = "Número de NVV"
        '
        'Txt_Observaciones
        '
        Me.Txt_Observaciones.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Observaciones.Border.Class = "TextBoxBorder"
        Me.Txt_Observaciones.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Observaciones.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Observaciones.ForeColor = System.Drawing.Color.Black
        Me.Txt_Observaciones.Location = New System.Drawing.Point(9, 494)
        Me.Txt_Observaciones.Name = "Txt_Observaciones"
        Me.Txt_Observaciones.PreventEnterBeep = True
        Me.Txt_Observaciones.ReadOnly = True
        Me.Txt_Observaciones.Size = New System.Drawing.Size(1272, 22)
        Me.Txt_Observaciones.TabIndex = 134
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(12, 2)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(114, 23)
        Me.LabelX1.TabIndex = 133
        Me.LabelX1.Text = "Fecha de facturación:"
        '
        'Chk_Imprimir
        '
        Me.Chk_Imprimir.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Imprimir.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Imprimir.CheckBoxImageChecked = CType(resources.GetObject("Chk_Imprimir.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Imprimir.FocusCuesEnabled = False
        Me.Chk_Imprimir.ForeColor = System.Drawing.Color.Black
        Me.Chk_Imprimir.Location = New System.Drawing.Point(9, 567)
        Me.Chk_Imprimir.Name = "Chk_Imprimir"
        Me.Chk_Imprimir.Size = New System.Drawing.Size(254, 17)
        Me.Chk_Imprimir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Imprimir.TabIndex = 131
        Me.Chk_Imprimir.Text = "Imprimir facturas"
        '
        'Input_Monto_Max_CRV_FacMasiva
        '
        Me.Input_Monto_Max_CRV_FacMasiva.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_Monto_Max_CRV_FacMasiva.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_Monto_Max_CRV_FacMasiva.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_Monto_Max_CRV_FacMasiva.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.Input_Monto_Max_CRV_FacMasiva.ForeColor = System.Drawing.Color.Black
        Me.Input_Monto_Max_CRV_FacMasiva.Location = New System.Drawing.Point(1216, 522)
        Me.Input_Monto_Max_CRV_FacMasiva.MaxValue = 10000
        Me.Input_Monto_Max_CRV_FacMasiva.MinValue = 1
        Me.Input_Monto_Max_CRV_FacMasiva.Name = "Input_Monto_Max_CRV_FacMasiva"
        Me.Input_Monto_Max_CRV_FacMasiva.ShowUpDown = True
        Me.Input_Monto_Max_CRV_FacMasiva.Size = New System.Drawing.Size(64, 22)
        Me.Input_Monto_Max_CRV_FacMasiva.TabIndex = 129
        Me.Input_Monto_Max_CRV_FacMasiva.Value = 1
        '
        'Chk_Pagar_Documentos
        '
        Me.Chk_Pagar_Documentos.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Pagar_Documentos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Pagar_Documentos.CheckBoxImageChecked = CType(resources.GetObject("Chk_Pagar_Documentos.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Pagar_Documentos.FocusCuesEnabled = False
        Me.Chk_Pagar_Documentos.ForeColor = System.Drawing.Color.Black
        Me.Chk_Pagar_Documentos.Location = New System.Drawing.Point(9, 547)
        Me.Chk_Pagar_Documentos.Name = "Chk_Pagar_Documentos"
        Me.Chk_Pagar_Documentos.Size = New System.Drawing.Size(415, 17)
        Me.Chk_Pagar_Documentos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Pagar_Documentos.TabIndex = 130
        Me.Chk_Pagar_Documentos.Text = "Pagar documentos con pago asociado a la nota de venta en Cta. Cte. del cliente"
        '
        'Chk_Pagar_Saldos_CRV
        '
        Me.Chk_Pagar_Saldos_CRV.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Pagar_Saldos_CRV.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Pagar_Saldos_CRV.CheckBoxImageChecked = CType(resources.GetObject("Chk_Pagar_Saldos_CRV.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Pagar_Saldos_CRV.FocusCuesEnabled = False
        Me.Chk_Pagar_Saldos_CRV.ForeColor = System.Drawing.Color.Black
        Me.Chk_Pagar_Saldos_CRV.Location = New System.Drawing.Point(956, 522)
        Me.Chk_Pagar_Saldos_CRV.Name = "Chk_Pagar_Saldos_CRV"
        Me.Chk_Pagar_Saldos_CRV.Size = New System.Drawing.Size(254, 22)
        Me.Chk_Pagar_Saldos_CRV.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Pagar_Saldos_CRV.TabIndex = 128
        Me.Chk_Pagar_Saldos_CRV.Text = "Pagar saldos con CRV. monto máximo CRV $ ->"
        '
        'Chk_PickearTodo
        '
        Me.Chk_PickearTodo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_PickearTodo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_PickearTodo.CheckBoxImageChecked = CType(resources.GetObject("Chk_PickearTodo.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_PickearTodo.FocusCuesEnabled = False
        Me.Chk_PickearTodo.ForeColor = System.Drawing.Color.Black
        Me.Chk_PickearTodo.Location = New System.Drawing.Point(9, 529)
        Me.Chk_PickearTodo.Name = "Chk_PickearTodo"
        Me.Chk_PickearTodo.Size = New System.Drawing.Size(85, 17)
        Me.Chk_PickearTodo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_PickearTodo.TabIndex = 123
        Me.Chk_PickearTodo.Text = "Pickear todo"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_EnviarPickear, Me.Btn_ActualizarLista, Me.Btn_Cancelar})
        Me.Bar1.Location = New System.Drawing.Point(0, 594)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(1293, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 122
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_EnviarPickear
        '
        Me.Btn_EnviarPickear.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_EnviarPickear.ForeColor = System.Drawing.Color.Black
        Me.Btn_EnviarPickear.Image = CType(resources.GetObject("Btn_EnviarPickear.Image"), System.Drawing.Image)
        Me.Btn_EnviarPickear.ImageAlt = CType(resources.GetObject("Btn_EnviarPickear.ImageAlt"), System.Drawing.Image)
        Me.Btn_EnviarPickear.Name = "Btn_EnviarPickear"
        Me.Btn_EnviarPickear.Tooltip = "Enviar a pickear documentos marcados"
        '
        'Btn_ActualizarLista
        '
        Me.Btn_ActualizarLista.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_ActualizarLista.ForeColor = System.Drawing.Color.Black
        Me.Btn_ActualizarLista.Image = CType(resources.GetObject("Btn_ActualizarLista.Image"), System.Drawing.Image)
        Me.Btn_ActualizarLista.ImageAlt = CType(resources.GetObject("Btn_ActualizarLista.ImageAlt"), System.Drawing.Image)
        Me.Btn_ActualizarLista.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_ActualizarLista.Name = "Btn_ActualizarLista"
        Me.Btn_ActualizarLista.Tooltip = "Actualizar (F5)"
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Cancelar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Cancelar.Image = CType(resources.GetObject("Btn_Cancelar.Image"), System.Drawing.Image)
        Me.Btn_Cancelar.ImageAlt = CType(resources.GetObject("Btn_Cancelar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Text = "Cancelar"
        Me.Btn_Cancelar.Tooltip = "Eliminar Servidor de correo de salida SMTP"
        Me.Btn_Cancelar.Visible = False
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.ContextMenuBar1)
        Me.GroupPanel1.Controls.Add(Me.Grilla)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(9, 106)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(1272, 382)
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
        Me.GroupPanel1.TabIndex = 121
        Me.GroupPanel1.Text = "Detalle"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_01_Opciones_Documento, Me.Menu_Contextual_Opciones_Especiales})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(211, 120)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(325, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 46
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_01_Opciones_Documento
        '
        Me.Menu_Contextual_01_Opciones_Documento.AutoExpandOnClick = True
        Me.Menu_Contextual_01_Opciones_Documento.Name = "Menu_Contextual_01_Opciones_Documento"
        Me.Menu_Contextual_01_Opciones_Documento.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1, Me.Btn_Ver_documento, Me.Btn_Ver_Anotaciones_Documento})
        Me.Menu_Contextual_01_Opciones_Documento.Text = "Opciones documento"
        '
        'LabelItem1
        '
        Me.LabelItem1.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem1.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem1.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem1.Name = "LabelItem1"
        Me.LabelItem1.PaddingBottom = 1
        Me.LabelItem1.PaddingLeft = 10
        Me.LabelItem1.PaddingTop = 1
        Me.LabelItem1.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem1.Text = "Opciones"
        '
        'Btn_Ver_documento
        '
        Me.Btn_Ver_documento.Image = CType(resources.GetObject("Btn_Ver_documento.Image"), System.Drawing.Image)
        Me.Btn_Ver_documento.ImageAlt = CType(resources.GetObject("Btn_Ver_documento.ImageAlt"), System.Drawing.Image)
        Me.Btn_Ver_documento.Name = "Btn_Ver_documento"
        Me.Btn_Ver_documento.Text = "Ver documento"
        '
        'Btn_Ver_Anotaciones_Documento
        '
        Me.Btn_Ver_Anotaciones_Documento.Image = CType(resources.GetObject("Btn_Ver_Anotaciones_Documento.Image"), System.Drawing.Image)
        Me.Btn_Ver_Anotaciones_Documento.Name = "Btn_Ver_Anotaciones_Documento"
        Me.Btn_Ver_Anotaciones_Documento.Text = "Ver anotaciones del documento"
        '
        'Menu_Contextual_Opciones_Especiales
        '
        Me.Menu_Contextual_Opciones_Especiales.AutoExpandOnClick = True
        Me.Menu_Contextual_Opciones_Especiales.Name = "Menu_Contextual_Opciones_Especiales"
        Me.Menu_Contextual_Opciones_Especiales.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Config_Tipo_Estacion, Me.Btn_Config_Impresora})
        Me.Menu_Contextual_Opciones_Especiales.Text = "Opciones especiales"
        '
        'Btn_Config_Tipo_Estacion
        '
        Me.Btn_Config_Tipo_Estacion.Image = CType(resources.GetObject("Btn_Config_Tipo_Estacion.Image"), System.Drawing.Image)
        Me.Btn_Config_Tipo_Estacion.ImageAlt = CType(resources.GetObject("Btn_Config_Tipo_Estacion.ImageAlt"), System.Drawing.Image)
        Me.Btn_Config_Tipo_Estacion.Name = "Btn_Config_Tipo_Estacion"
        Me.Btn_Config_Tipo_Estacion.Text = "Configuración tipo de estación"
        '
        'Btn_Config_Impresora
        '
        Me.Btn_Config_Impresora.Image = CType(resources.GetObject("Btn_Config_Impresora.Image"), System.Drawing.Image)
        Me.Btn_Config_Impresora.ImageAlt = CType(resources.GetObject("Btn_Config_Impresora.ImageAlt"), System.Drawing.Image)
        Me.Btn_Config_Impresora.Name = "Btn_Config_Impresora"
        Me.Btn_Config_Impresora.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Config_Impresora_Local, Me.Btn_Config_Impresora_Diablito, Me.Btn_Impresion_PDF})
        Me.Btn_Config_Impresora.Text = "Configuración impresora de salida"
        '
        'Btn_Config_Impresora_Local
        '
        Me.Btn_Config_Impresora_Local.Image = CType(resources.GetObject("Btn_Config_Impresora_Local.Image"), System.Drawing.Image)
        Me.Btn_Config_Impresora_Local.ImageAlt = CType(resources.GetObject("Btn_Config_Impresora_Local.ImageAlt"), System.Drawing.Image)
        Me.Btn_Config_Impresora_Local.Name = "Btn_Config_Impresora_Local"
        Me.Btn_Config_Impresora_Local.Text = "Impresora local o conectada a la red"
        '
        'Btn_Config_Impresora_Diablito
        '
        Me.Btn_Config_Impresora_Diablito.Image = CType(resources.GetObject("Btn_Config_Impresora_Diablito.Image"), System.Drawing.Image)
        Me.Btn_Config_Impresora_Diablito.ImageAlt = CType(resources.GetObject("Btn_Config_Impresora_Diablito.ImageAlt"), System.Drawing.Image)
        Me.Btn_Config_Impresora_Diablito.Name = "Btn_Config_Impresora_Diablito"
        Me.Btn_Config_Impresora_Diablito.Text = "Impresión hacia diablito (servidor de impresiones)"
        Me.Btn_Config_Impresora_Diablito.Tooltip = "Configurar mis salidas de impresión al diablito"
        '
        'Btn_Impresion_PDF
        '
        Me.Btn_Impresion_PDF.Image = CType(resources.GetObject("Btn_Impresion_PDF.Image"), System.Drawing.Image)
        Me.Btn_Impresion_PDF.ImageAlt = CType(resources.GetObject("Btn_Impresion_PDF.ImageAlt"), System.Drawing.Image)
        Me.Btn_Impresion_PDF.Name = "Btn_Impresion_PDF"
        Me.Btn_Impresion_PDF.Text = "Directorio de salida para PDF automático"
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.AllowUserToDeleteRows = False
        Me.Grilla.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla.DefaultCellStyle = DataGridViewCellStyle8
        Me.Grilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla.EnableHeadersVisualStyles = False
        Me.Grilla.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla.Location = New System.Drawing.Point(0, 0)
        Me.Grilla.Name = "Grilla"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.Grilla.RowHeadersVisible = False
        Me.Grilla.Size = New System.Drawing.Size(1266, 359)
        Me.Grilla.TabIndex = 3
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
        Me.MetroStatusBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Lbl_Status})
        Me.MetroStatusBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MetroStatusBar1.Location = New System.Drawing.Point(0, 635)
        Me.MetroStatusBar1.Name = "MetroStatusBar1"
        Me.MetroStatusBar1.Size = New System.Drawing.Size(1293, 22)
        Me.MetroStatusBar1.TabIndex = 127
        Me.MetroStatusBar1.Text = "MetroStatusBar1"
        '
        'Lbl_Status
        '
        Me.Lbl_Status.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Status.Name = "Lbl_Status"
        Me.Lbl_Status.Text = "Status"
        '
        'Chk_FacturarTodo
        '
        Me.Chk_FacturarTodo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_FacturarTodo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_FacturarTodo.CheckBoxImageChecked = CType(resources.GetObject("Chk_FacturarTodo.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_FacturarTodo.FocusCuesEnabled = False
        Me.Chk_FacturarTodo.ForeColor = System.Drawing.Color.Black
        Me.Chk_FacturarTodo.Location = New System.Drawing.Point(100, 529)
        Me.Chk_FacturarTodo.Name = "Chk_FacturarTodo"
        Me.Chk_FacturarTodo.Size = New System.Drawing.Size(85, 17)
        Me.Chk_FacturarTodo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_FacturarTodo.TabIndex = 136
        Me.Chk_FacturarTodo.Text = "Facturar todo"
        '
        'Frm_Stmp_IncNVVPicking
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1293, 657)
        Me.Controls.Add(Me.Chk_FacturarTodo)
        Me.Controls.Add(Me.Dtp_FechaParaFacturacion)
        Me.Controls.Add(Me.GroupPanel4)
        Me.Controls.Add(Me.Txt_Observaciones)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Chk_Imprimir)
        Me.Controls.Add(Me.Input_Monto_Max_CRV_FacMasiva)
        Me.Controls.Add(Me.Chk_Pagar_Documentos)
        Me.Controls.Add(Me.Chk_Pagar_Saldos_CRV)
        Me.Controls.Add(Me.Chk_PickearTodo)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.MetroStatusBar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Stmp_IncNVVPicking"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ENVIAR NOTAS DE VENTA A PICKING"
        CType(Me.Dtp_FechaParaFacturacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel4.ResumeLayout(False)
        CType(Me.Dtp_BuscaXFechaDespacho, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_BuscaXFechaEmision, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Input_Monto_Max_CRV_FacMasiva, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Dtp_FechaParaFacturacion As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents GroupPanel4 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Cmb_TipoVenta As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dtp_BuscaXFechaDespacho As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dtp_BuscaXFechaEmision As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_BuscaXEntidad As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_BuscaXNudoNVV As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Observaciones As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Chk_Imprimir As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Input_Monto_Max_CRV_FacMasiva As DevComponents.Editors.IntegerInput
    Friend WithEvents Chk_Pagar_Documentos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Pagar_Saldos_CRV As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_PickearTodo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_EnviarPickear As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Cancelar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_01_Opciones_Documento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Ver_documento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Ver_Anotaciones_Documento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Menu_Contextual_Opciones_Especiales As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Config_Tipo_Estacion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Config_Impresora As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Config_Impresora_Local As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Config_Impresora_Diablito As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Impresion_PDF As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents MetroStatusBar1 As DevComponents.DotNetBar.Metro.MetroStatusBar
    Friend WithEvents Lbl_Status As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Chk_FacturarTodo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Btn_ActualizarLista As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Txt_Ocdo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_BuscaXObservaciones As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
End Class
