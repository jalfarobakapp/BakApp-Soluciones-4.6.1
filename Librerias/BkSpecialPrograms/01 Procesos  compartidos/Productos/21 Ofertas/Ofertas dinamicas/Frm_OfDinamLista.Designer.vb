<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_OfDinamLista
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_OfDinamLista))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Cmb_TipoOferta = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_FechaTope = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_FechaInicio = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_BuscaXProducto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Buscador = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Grilla_Productos = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Eliminar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Crear_Receta = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_ExportarExcel = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_01 = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_EditarOferta = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_AsociarProductos = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_02 = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_QuitarProducto = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_InfoKardex = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla_Recetas = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_NroMaxProdXOfertaDinamica = New DevComponents.DotNetBar.LabelX()
        Me.Btn_EditarNroMaxProductos = New DevComponents.DotNetBar.ButtonX()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Chk_Marcar_Todas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.GroupPanel3.SuspendLayout()
        CType(Me.Dtp_FechaTope, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_FechaInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.Grilla_Productos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla_Recetas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupPanel3
        '
        Me.GroupPanel3.BackColor = System.Drawing.Color.White
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.Cmb_TipoOferta)
        Me.GroupPanel3.Controls.Add(Me.LabelX9)
        Me.GroupPanel3.Controls.Add(Me.Dtp_FechaTope)
        Me.GroupPanel3.Controls.Add(Me.LabelX4)
        Me.GroupPanel3.Controls.Add(Me.Dtp_FechaInicio)
        Me.GroupPanel3.Controls.Add(Me.LabelX3)
        Me.GroupPanel3.Controls.Add(Me.Txt_BuscaXProducto)
        Me.GroupPanel3.Controls.Add(Me.LabelX2)
        Me.GroupPanel3.Controls.Add(Me.Txt_Buscador)
        Me.GroupPanel3.Controls.Add(Me.LabelX7)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Location = New System.Drawing.Point(9, 0)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(1038, 100)
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
        Me.GroupPanel3.TabIndex = 104
        Me.GroupPanel3.Text = "Buscador"
        '
        'Cmb_TipoOferta
        '
        Me.Cmb_TipoOferta.DisplayMember = "Text"
        Me.Cmb_TipoOferta.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_TipoOferta.ForeColor = System.Drawing.Color.Black
        Me.Cmb_TipoOferta.FormattingEnabled = True
        Me.Cmb_TipoOferta.ItemHeight = 16
        Me.Cmb_TipoOferta.Location = New System.Drawing.Point(508, 48)
        Me.Cmb_TipoOferta.Name = "Cmb_TipoOferta"
        Me.Cmb_TipoOferta.Size = New System.Drawing.Size(278, 22)
        Me.Cmb_TipoOferta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_TipoOferta.TabIndex = 108
        Me.Cmb_TipoOferta.Text = "Todas..."
        '
        'LabelX9
        '
        Me.LabelX9.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.ForeColor = System.Drawing.Color.Black
        Me.LabelX9.Location = New System.Drawing.Point(424, 47)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(78, 23)
        Me.LabelX9.TabIndex = 109
        Me.LabelX9.Text = "Tipo de oferta"
        '
        'Dtp_FechaTope
        '
        Me.Dtp_FechaTope.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_FechaTope.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_FechaTope.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaTope.ButtonClear.Visible = True
        Me.Dtp_FechaTope.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_FechaTope.ButtonDropDown.Visible = True
        Me.Dtp_FechaTope.ForeColor = System.Drawing.Color.Black
        Me.Dtp_FechaTope.IsPopupCalendarOpen = False
        Me.Dtp_FechaTope.Location = New System.Drawing.Point(294, 48)
        '
        '
        '
        Me.Dtp_FechaTope.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FechaTope.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaTope.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_FechaTope.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_FechaTope.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_FechaTope.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FechaTope.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_FechaTope.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_FechaTope.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_FechaTope.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_FechaTope.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaTope.MonthCalendar.DisplayMonth = New Date(2023, 3, 1, 0, 0, 0, 0)
        Me.Dtp_FechaTope.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_FechaTope.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_FechaTope.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FechaTope.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_FechaTope.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FechaTope.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_FechaTope.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaTope.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_FechaTope.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_FechaTope.Name = "Dtp_FechaTope"
        Me.Dtp_FechaTope.Size = New System.Drawing.Size(101, 22)
        Me.Dtp_FechaTope.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_FechaTope.TabIndex = 105
        Me.Dtp_FechaTope.Value = New Date(2023, 3, 6, 13, 17, 7, 0)
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(210, 47)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(93, 23)
        Me.LabelX4.TabIndex = 104
        Me.LabelX4.Text = "Fecha de Tope"
        '
        'Dtp_FechaInicio
        '
        Me.Dtp_FechaInicio.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_FechaInicio.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_FechaInicio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaInicio.ButtonClear.Visible = True
        Me.Dtp_FechaInicio.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_FechaInicio.ButtonDropDown.Visible = True
        Me.Dtp_FechaInicio.ForeColor = System.Drawing.Color.Black
        Me.Dtp_FechaInicio.IsPopupCalendarOpen = False
        Me.Dtp_FechaInicio.Location = New System.Drawing.Point(92, 48)
        '
        '
        '
        Me.Dtp_FechaInicio.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FechaInicio.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaInicio.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_FechaInicio.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_FechaInicio.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_FechaInicio.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FechaInicio.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_FechaInicio.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_FechaInicio.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_FechaInicio.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_FechaInicio.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaInicio.MonthCalendar.DisplayMonth = New Date(2023, 3, 1, 0, 0, 0, 0)
        Me.Dtp_FechaInicio.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_FechaInicio.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_FechaInicio.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FechaInicio.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_FechaInicio.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FechaInicio.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_FechaInicio.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaInicio.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_FechaInicio.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_FechaInicio.Name = "Dtp_FechaInicio"
        Me.Dtp_FechaInicio.Size = New System.Drawing.Size(101, 22)
        Me.Dtp_FechaInicio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_FechaInicio.TabIndex = 103
        Me.Dtp_FechaInicio.Value = New Date(2023, 3, 6, 13, 17, 7, 0)
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(3, 47)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(93, 23)
        Me.LabelX3.TabIndex = 102
        Me.LabelX3.Text = "Fecha de Inicio"
        '
        'Txt_BuscaXProducto
        '
        Me.Txt_BuscaXProducto.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_BuscaXProducto.Border.Class = "TextBoxBorder"
        Me.Txt_BuscaXProducto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_BuscaXProducto.ButtonCustom.Image = CType(resources.GetObject("Txt_BuscaXProducto.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_BuscaXProducto.ButtonCustom.Visible = True
        Me.Txt_BuscaXProducto.ButtonCustom2.Image = CType(resources.GetObject("Txt_BuscaXProducto.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_BuscaXProducto.ButtonCustom2.Visible = True
        Me.Txt_BuscaXProducto.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_BuscaXProducto.ForeColor = System.Drawing.Color.Black
        Me.Txt_BuscaXProducto.Location = New System.Drawing.Point(792, 20)
        Me.Txt_BuscaXProducto.Name = "Txt_BuscaXProducto"
        Me.Txt_BuscaXProducto.PreventEnterBeep = True
        Me.Txt_BuscaXProducto.ReadOnly = True
        Me.Txt_BuscaXProducto.Size = New System.Drawing.Size(237, 22)
        Me.Txt_BuscaXProducto.TabIndex = 1
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(792, 0)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(121, 23)
        Me.LabelX2.TabIndex = 101
        Me.LabelX2.Text = "Producto asociado..."
        '
        'Txt_Buscador
        '
        Me.Txt_Buscador.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Buscador.Border.Class = "TextBoxBorder"
        Me.Txt_Buscador.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Buscador.ButtonCustom.Image = CType(resources.GetObject("Txt_Buscador.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Buscador.ButtonCustom2.Image = CType(resources.GetObject("Txt_Buscador.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Buscador.ButtonCustom2.Visible = True
        Me.Txt_Buscador.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Buscador.ForeColor = System.Drawing.Color.Black
        Me.Txt_Buscador.Location = New System.Drawing.Point(3, 20)
        Me.Txt_Buscador.Name = "Txt_Buscador"
        Me.Txt_Buscador.PreventEnterBeep = True
        Me.Txt_Buscador.Size = New System.Drawing.Size(783, 22)
        Me.Txt_Buscador.TabIndex = 0
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.ForeColor = System.Drawing.Color.Black
        Me.LabelX7.Location = New System.Drawing.Point(3, 0)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(404, 23)
        Me.LabelX7.TabIndex = 99
        Me.LabelX7.Text = "Ingrese algún código o algo de la descripción del descuento especial"
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Grilla_Productos)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(9, 436)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(1038, 153)
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
        Me.GroupPanel2.TabIndex = 103
        Me.GroupPanel2.Text = "Productos que se asocian al tipo de descuento"
        '
        'Grilla_Productos
        '
        Me.Grilla_Productos.AllowUserToAddRows = False
        Me.Grilla_Productos.AllowUserToDeleteRows = False
        Me.Grilla_Productos.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Productos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grilla_Productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Productos.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grilla_Productos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Productos.EnableHeadersVisualStyles = False
        Me.Grilla_Productos.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Productos.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Productos.MultiSelect = False
        Me.Grilla_Productos.Name = "Grilla_Productos"
        Me.Grilla_Productos.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Productos.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla_Productos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grilla_Productos.Size = New System.Drawing.Size(1032, 130)
        Me.Grilla_Productos.TabIndex = 1
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar, Me.Btn_Eliminar, Me.Btn_Crear_Receta, Me.Btn_ExportarExcel})
        Me.Bar2.Location = New System.Drawing.Point(0, 631)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(1056, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 102
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.ImageAlt = CType(resources.GetObject("Btn_Grabar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Grabar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Tooltip = "Grabar [F4]"
        '
        'Btn_Eliminar
        '
        Me.Btn_Eliminar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Eliminar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Eliminar.Image = CType(resources.GetObject("Btn_Eliminar.Image"), System.Drawing.Image)
        Me.Btn_Eliminar.ImageAlt = CType(resources.GetObject("Btn_Eliminar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Eliminar.Name = "Btn_Eliminar"
        Me.Btn_Eliminar.Tooltip = "Eliminar"
        '
        'Btn_Crear_Receta
        '
        Me.Btn_Crear_Receta.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Crear_Receta.ForeColor = System.Drawing.Color.Black
        Me.Btn_Crear_Receta.Image = CType(resources.GetObject("Btn_Crear_Receta.Image"), System.Drawing.Image)
        Me.Btn_Crear_Receta.ImageAlt = CType(resources.GetObject("Btn_Crear_Receta.ImageAlt"), System.Drawing.Image)
        Me.Btn_Crear_Receta.Name = "Btn_Crear_Receta"
        Me.Btn_Crear_Receta.Tooltip = "Crear nuevo tipo de descuento especial"
        '
        'Btn_ExportarExcel
        '
        Me.Btn_ExportarExcel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_ExportarExcel.ForeColor = System.Drawing.Color.Black
        Me.Btn_ExportarExcel.Image = CType(resources.GetObject("Btn_ExportarExcel.Image"), System.Drawing.Image)
        Me.Btn_ExportarExcel.ImageAlt = CType(resources.GetObject("Btn_ExportarExcel.ImageAlt"), System.Drawing.Image)
        Me.Btn_ExportarExcel.Name = "Btn_ExportarExcel"
        Me.Btn_ExportarExcel.Tooltip = "Exportar a Excel"
        Me.Btn_ExportarExcel.Visible = False
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.ContextMenuBar1)
        Me.GroupPanel1.Controls.Add(Me.Grilla_Recetas)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(9, 106)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(1038, 298)
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
        Me.GroupPanel1.TabIndex = 101
        Me.GroupPanel1.Text = "Nómina de tipos de descuentos especiales"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_01, Me.Menu_Contextual_02})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(77, 33)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(330, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 55
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_01
        '
        Me.Menu_Contextual_01.AutoExpandOnClick = True
        Me.Menu_Contextual_01.Name = "Menu_Contextual_01"
        Me.Menu_Contextual_01.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Mnu_EditarOferta, Me.Btn_Mnu_AsociarProductos})
        Me.Menu_Contextual_01.Text = "Opciones"
        '
        'Btn_Mnu_EditarOferta
        '
        Me.Btn_Mnu_EditarOferta.Image = CType(resources.GetObject("Btn_Mnu_EditarOferta.Image"), System.Drawing.Image)
        Me.Btn_Mnu_EditarOferta.ImageAlt = CType(resources.GetObject("Btn_Mnu_EditarOferta.ImageAlt"), System.Drawing.Image)
        Me.Btn_Mnu_EditarOferta.Name = "Btn_Mnu_EditarOferta"
        Me.Btn_Mnu_EditarOferta.Text = "Editar oferta"
        '
        'Btn_Mnu_AsociarProductos
        '
        Me.Btn_Mnu_AsociarProductos.Image = CType(resources.GetObject("Btn_Mnu_AsociarProductos.Image"), System.Drawing.Image)
        Me.Btn_Mnu_AsociarProductos.ImageAlt = CType(resources.GetObject("Btn_Mnu_AsociarProductos.ImageAlt"), System.Drawing.Image)
        Me.Btn_Mnu_AsociarProductos.Name = "Btn_Mnu_AsociarProductos"
        Me.Btn_Mnu_AsociarProductos.Text = "Asociar productos a la oferta"
        '
        'Menu_Contextual_02
        '
        Me.Menu_Contextual_02.AutoExpandOnClick = True
        Me.Menu_Contextual_02.Name = "Menu_Contextual_02"
        Me.Menu_Contextual_02.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Mnu_QuitarProducto, Me.Btn_InfoKardex})
        Me.Menu_Contextual_02.Text = "Opciones"
        '
        'Btn_Mnu_QuitarProducto
        '
        Me.Btn_Mnu_QuitarProducto.Image = CType(resources.GetObject("Btn_Mnu_QuitarProducto.Image"), System.Drawing.Image)
        Me.Btn_Mnu_QuitarProducto.ImageAlt = CType(resources.GetObject("Btn_Mnu_QuitarProducto.ImageAlt"), System.Drawing.Image)
        Me.Btn_Mnu_QuitarProducto.Name = "Btn_Mnu_QuitarProducto"
        Me.Btn_Mnu_QuitarProducto.Text = "Quitar producto de la oferta"
        '
        'Btn_InfoKardex
        '
        Me.Btn_InfoKardex.Image = CType(resources.GetObject("Btn_InfoKardex.Image"), System.Drawing.Image)
        Me.Btn_InfoKardex.ImageAlt = CType(resources.GetObject("Btn_InfoKardex.ImageAlt"), System.Drawing.Image)
        Me.Btn_InfoKardex.Name = "Btn_InfoKardex"
        Me.Btn_InfoKardex.Text = "Ver información del stock del producto"
        '
        'Grilla_Recetas
        '
        Me.Grilla_Recetas.AllowUserToAddRows = False
        Me.Grilla_Recetas.AllowUserToDeleteRows = False
        Me.Grilla_Recetas.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Recetas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Grilla_Recetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Recetas.DefaultCellStyle = DataGridViewCellStyle5
        Me.Grilla_Recetas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Recetas.EnableHeadersVisualStyles = False
        Me.Grilla_Recetas.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Recetas.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Recetas.MultiSelect = False
        Me.Grilla_Recetas.Name = "Grilla_Recetas"
        Me.Grilla_Recetas.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Recetas.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Grilla_Recetas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grilla_Recetas.Size = New System.Drawing.Size(1032, 275)
        Me.Grilla_Recetas.TabIndex = 1
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(4, 4)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(518, 20)
        Me.LabelX1.TabIndex = 105
        Me.LabelX1.Text = "Numero máximo de productos que se podrán seleccionar para ser asociados a una ofe" &
    "rta de una sola vez"
        '
        'Lbl_NroMaxProdXOfertaDinamica
        '
        Me.Lbl_NroMaxProdXOfertaDinamica.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_NroMaxProdXOfertaDinamica.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_NroMaxProdXOfertaDinamica.ForeColor = System.Drawing.Color.Black
        Me.Lbl_NroMaxProdXOfertaDinamica.Location = New System.Drawing.Point(530, 4)
        Me.Lbl_NroMaxProdXOfertaDinamica.Name = "Lbl_NroMaxProdXOfertaDinamica"
        Me.Lbl_NroMaxProdXOfertaDinamica.Size = New System.Drawing.Size(48, 20)
        Me.Lbl_NroMaxProdXOfertaDinamica.TabIndex = 106
        Me.Lbl_NroMaxProdXOfertaDinamica.Tag = "1"
        Me.Lbl_NroMaxProdXOfertaDinamica.Text = "1"
        '
        'Btn_EditarNroMaxProductos
        '
        Me.Btn_EditarNroMaxProductos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_EditarNroMaxProductos.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_EditarNroMaxProductos.Location = New System.Drawing.Point(601, 565)
        Me.Btn_EditarNroMaxProductos.Name = "Btn_EditarNroMaxProductos"
        Me.Btn_EditarNroMaxProductos.Size = New System.Drawing.Size(62, 27)
        Me.Btn_EditarNroMaxProductos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_EditarNroMaxProductos.TabIndex = 107
        Me.Btn_EditarNroMaxProductos.Text = "<-- Editar"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90.09901!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.90099!))
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_NroMaxProdXOfertaDinamica, 1, 0)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(9, 595)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(586, 28)
        Me.TableLayoutPanel1.TabIndex = 108
        '
        'Chk_Marcar_Todas
        '
        Me.Chk_Marcar_Todas.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Marcar_Todas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Marcar_Todas.CheckBoxImageChecked = CType(resources.GetObject("Chk_Marcar_Todas.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Marcar_Todas.FocusCuesEnabled = False
        Me.Chk_Marcar_Todas.ForeColor = System.Drawing.Color.Black
        Me.Chk_Marcar_Todas.Location = New System.Drawing.Point(9, 410)
        Me.Chk_Marcar_Todas.Name = "Chk_Marcar_Todas"
        Me.Chk_Marcar_Todas.Size = New System.Drawing.Size(145, 20)
        Me.Chk_Marcar_Todas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Marcar_Todas.TabIndex = 109
        Me.Chk_Marcar_Todas.Text = "Marcar todas"
        '
        'Frm_OfDinamLista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1056, 672)
        Me.Controls.Add(Me.Chk_Marcar_Todas)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Btn_EditarNroMaxProductos)
        Me.Controls.Add(Me.GroupPanel3)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.GroupPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_OfDinamLista"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "OFERTAS DINAMICAS"
        Me.GroupPanel3.ResumeLayout(False)
        CType(Me.Dtp_FechaTope, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_FechaInicio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.Grilla_Productos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla_Recetas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Txt_BuscaXProducto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Buscador As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grilla_Productos As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Crear_Receta As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_01 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_EditarOferta As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_AsociarProductos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grilla_Recetas As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Btn_ExportarExcel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Menu_Contextual_02 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_QuitarProducto As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_NroMaxProdXOfertaDinamica As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_EditarNroMaxProductos As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Cmb_TipoOferta As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dtp_FechaTope As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dtp_FechaInicio As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_InfoKardex As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Chk_Marcar_Todas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Btn_Eliminar As DevComponents.DotNetBar.ButtonItem
End Class
