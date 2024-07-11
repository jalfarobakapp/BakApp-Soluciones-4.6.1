<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_IngresarHoja
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_IngresarHoja))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Chk_Reconteo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_FechaCreacion = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Txt_IdContador2 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_IdContador1 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Nro_Hoja = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Eliminar = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel4 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_01 = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Observaciones = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem3 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Copiar = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla_Detalle = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Btn_EliminarFila = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Dtp_FechaCreacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel4.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla_Detalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Chk_Reconteo)
        Me.GroupPanel1.Controls.Add(Me.LabelX4)
        Me.GroupPanel1.Controls.Add(Me.Dtp_FechaCreacion)
        Me.GroupPanel1.Controls.Add(Me.Txt_IdContador2)
        Me.GroupPanel1.Controls.Add(Me.LabelX2)
        Me.GroupPanel1.Controls.Add(Me.Txt_IdContador1)
        Me.GroupPanel1.Controls.Add(Me.Txt_Nro_Hoja)
        Me.GroupPanel1.Controls.Add(Me.LabelX3)
        Me.GroupPanel1.Controls.Add(Me.LabelX1)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 0)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(699, 113)
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
        Me.GroupPanel1.TabIndex = 164
        Me.GroupPanel1.Text = "Encabezado de hoja de conteo"
        '
        'Chk_Reconteo
        '
        Me.Chk_Reconteo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Reconteo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Reconteo.CheckBoxImageChecked = CType(resources.GetObject("Chk_Reconteo.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Reconteo.Checked = True
        Me.Chk_Reconteo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_Reconteo.CheckValue = "Y"
        Me.Chk_Reconteo.Enabled = False
        Me.Chk_Reconteo.FocusCuesEnabled = False
        Me.Chk_Reconteo.ForeColor = System.Drawing.Color.Black
        Me.Chk_Reconteo.Location = New System.Drawing.Point(3, 66)
        Me.Chk_Reconteo.Name = "Chk_Reconteo"
        Me.Chk_Reconteo.Size = New System.Drawing.Size(171, 23)
        Me.Chk_Reconteo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Reconteo.TabIndex = 39
        Me.Chk_Reconteo.Text = "Es reconteo"
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(549, 9)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(39, 23)
        Me.LabelX4.TabIndex = 9
        Me.LabelX4.Text = "Fecha"
        '
        'Dtp_FechaCreacion
        '
        Me.Dtp_FechaCreacion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_FechaCreacion.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_FechaCreacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaCreacion.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_FechaCreacion.ButtonDropDown.Visible = True
        Me.Dtp_FechaCreacion.ForeColor = System.Drawing.Color.Black
        Me.Dtp_FechaCreacion.IsPopupCalendarOpen = False
        Me.Dtp_FechaCreacion.Location = New System.Drawing.Point(594, 10)
        '
        '
        '
        Me.Dtp_FechaCreacion.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FechaCreacion.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaCreacion.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_FechaCreacion.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_FechaCreacion.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_FechaCreacion.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FechaCreacion.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_FechaCreacion.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_FechaCreacion.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_FechaCreacion.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_FechaCreacion.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaCreacion.MonthCalendar.DisplayMonth = New Date(2024, 6, 1, 0, 0, 0, 0)
        Me.Dtp_FechaCreacion.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_FechaCreacion.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_FechaCreacion.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FechaCreacion.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_FechaCreacion.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FechaCreacion.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_FechaCreacion.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaCreacion.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_FechaCreacion.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_FechaCreacion.Name = "Dtp_FechaCreacion"
        Me.Dtp_FechaCreacion.Size = New System.Drawing.Size(91, 22)
        Me.Dtp_FechaCreacion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_FechaCreacion.TabIndex = 8
        Me.Dtp_FechaCreacion.Value = New Date(2024, 6, 23, 12, 19, 44, 0)
        '
        'Txt_IdContador2
        '
        Me.Txt_IdContador2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_IdContador2.Border.Class = "TextBoxBorder"
        Me.Txt_IdContador2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_IdContador2.ButtonCustom.Image = CType(resources.GetObject("Txt_IdContador2.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_IdContador2.ButtonCustom.Visible = True
        Me.Txt_IdContador2.ButtonCustom2.Image = CType(resources.GetObject("Txt_IdContador2.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_IdContador2.ButtonCustom2.Visible = True
        Me.Txt_IdContador2.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_IdContador2.ForeColor = System.Drawing.Color.Black
        Me.Txt_IdContador2.Location = New System.Drawing.Point(418, 37)
        Me.Txt_IdContador2.Name = "Txt_IdContador2"
        Me.Txt_IdContador2.PreventEnterBeep = True
        Me.Txt_IdContador2.ReadOnly = True
        Me.Txt_IdContador2.Size = New System.Drawing.Size(267, 22)
        Me.Txt_IdContador2.TabIndex = 7
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(351, 35)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(61, 23)
        Me.LabelX2.TabIndex = 6
        Me.LabelX2.Text = "Contador 2"
        '
        'Txt_IdContador1
        '
        Me.Txt_IdContador1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_IdContador1.Border.Class = "TextBoxBorder"
        Me.Txt_IdContador1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_IdContador1.ButtonCustom.Image = CType(resources.GetObject("Txt_IdContador1.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_IdContador1.ButtonCustom.Visible = True
        Me.Txt_IdContador1.ButtonCustom2.Image = CType(resources.GetObject("Txt_IdContador1.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_IdContador1.ButtonCustom2.Visible = True
        Me.Txt_IdContador1.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_IdContador1.ForeColor = System.Drawing.Color.Black
        Me.Txt_IdContador1.Location = New System.Drawing.Point(65, 37)
        Me.Txt_IdContador1.Name = "Txt_IdContador1"
        Me.Txt_IdContador1.PreventEnterBeep = True
        Me.Txt_IdContador1.ReadOnly = True
        Me.Txt_IdContador1.Size = New System.Drawing.Size(267, 22)
        Me.Txt_IdContador1.TabIndex = 5
        '
        'Txt_Nro_Hoja
        '
        Me.Txt_Nro_Hoja.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Nro_Hoja.Border.Class = "TextBoxBorder"
        Me.Txt_Nro_Hoja.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Nro_Hoja.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Nro_Hoja.ForeColor = System.Drawing.Color.Black
        Me.Txt_Nro_Hoja.Location = New System.Drawing.Point(106, 12)
        Me.Txt_Nro_Hoja.Name = "Txt_Nro_Hoja"
        Me.Txt_Nro_Hoja.PreventEnterBeep = True
        Me.Txt_Nro_Hoja.Size = New System.Drawing.Size(100, 22)
        Me.Txt_Nro_Hoja.TabIndex = 3
        Me.Txt_Nro_Hoja.WatermarkText = "En construcción..."
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(3, 37)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(97, 23)
        Me.LabelX3.TabIndex = 2
        Me.LabelX3.Text = "Contador 1"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 12)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(97, 23)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "Número de HOJA"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar, Me.Btn_Eliminar})
        Me.Bar1.Location = New System.Drawing.Point(0, 582)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(721, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 163
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
        Me.Btn_Grabar.Tooltip = "Crear Inventario"
        '
        'Btn_Eliminar
        '
        Me.Btn_Eliminar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Eliminar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Eliminar.Image = CType(resources.GetObject("Btn_Eliminar.Image"), System.Drawing.Image)
        Me.Btn_Eliminar.ImageAlt = CType(resources.GetObject("Btn_Eliminar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Eliminar.Name = "Btn_Eliminar"
        Me.Btn_Eliminar.Tooltip = "Eliminar"
        Me.Btn_Eliminar.Visible = False
        '
        'GroupPanel4
        '
        Me.GroupPanel4.BackColor = System.Drawing.Color.White
        Me.GroupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel4.Controls.Add(Me.ContextMenuBar1)
        Me.GroupPanel4.Controls.Add(Me.Grilla_Detalle)
        Me.GroupPanel4.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel4.Location = New System.Drawing.Point(12, 119)
        Me.GroupPanel4.Name = "GroupPanel4"
        Me.GroupPanel4.Size = New System.Drawing.Size(699, 457)
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
        Me.GroupPanel4.TabIndex = 162
        Me.GroupPanel4.Text = "Detalle de los productos inventariados"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_01})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(31, 31)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(250, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 49
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_01
        '
        Me.Menu_Contextual_01.AutoExpandOnClick = True
        Me.Menu_Contextual_01.Name = "Menu_Contextual_01"
        Me.Menu_Contextual_01.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Observaciones, Me.Btn_EliminarFila, Me.LabelItem3, Me.Btn_Copiar})
        Me.Menu_Contextual_01.Text = "Opciones"
        '
        'Btn_Observaciones
        '
        Me.Btn_Observaciones.Image = CType(resources.GetObject("Btn_Observaciones.Image"), System.Drawing.Image)
        Me.Btn_Observaciones.ImageAlt = CType(resources.GetObject("Btn_Observaciones.ImageAlt"), System.Drawing.Image)
        Me.Btn_Observaciones.Name = "Btn_Observaciones"
        Me.Btn_Observaciones.Text = "Observaciones"
        '
        'LabelItem3
        '
        Me.LabelItem3.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem3.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem3.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem3.ImageTextSpacing = 1
        Me.LabelItem3.Name = "LabelItem3"
        Me.LabelItem3.PaddingBottom = 1
        Me.LabelItem3.PaddingLeft = 10
        Me.LabelItem3.PaddingTop = 1
        Me.LabelItem3.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem3.Text = "-------------------------------------------"
        '
        'Btn_Copiar
        '
        Me.Btn_Copiar.Image = CType(resources.GetObject("Btn_Copiar.Image"), System.Drawing.Image)
        Me.Btn_Copiar.ImageAlt = CType(resources.GetObject("Btn_Copiar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Copiar.Name = "Btn_Copiar"
        Me.Btn_Copiar.Text = "Copiar (portapapeles)"
        '
        'Grilla_Detalle
        '
        Me.Grilla_Detalle.AllowUserToDeleteRows = False
        Me.Grilla_Detalle.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Detalle.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grilla_Detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Detalle.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grilla_Detalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Detalle.EnableHeadersVisualStyles = False
        Me.Grilla_Detalle.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Detalle.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Detalle.Name = "Grilla_Detalle"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Detalle.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla_Detalle.Size = New System.Drawing.Size(693, 434)
        Me.Grilla_Detalle.StandardTab = True
        Me.Grilla_Detalle.TabIndex = 27
        '
        'Btn_EliminarFila
        '
        Me.Btn_EliminarFila.Image = CType(resources.GetObject("Btn_EliminarFila.Image"), System.Drawing.Image)
        Me.Btn_EliminarFila.ImageAlt = CType(resources.GetObject("Btn_EliminarFila.ImageAlt"), System.Drawing.Image)
        Me.Btn_EliminarFila.Name = "Btn_EliminarFila"
        Me.Btn_EliminarFila.Text = "Eliminar"
        '
        'Frm_IngresarHoja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(721, 623)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.GroupPanel4)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_IngresarHoja"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "HOJA DE INVENTARIO"
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.Dtp_FechaCreacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel4.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla_Detalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Txt_IdContador1 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Nro_Hoja As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents GroupPanel4 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grilla_Detalle As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Txt_IdContador2 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dtp_FechaCreacion As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Chk_Reconteo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Eliminar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_01 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Observaciones As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Copiar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem3 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_EliminarFila As DevComponents.DotNetBar.ButtonItem
End Class
