<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Cadenas_Remotas_Lista
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Cadenas_Remotas_Lista))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar2 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.ButtonItem2 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem3 = New DevComponents.DotNetBar.ButtonItem()
        Me.DataGridViewX1 = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Refresh = New DevComponents.DotNetBar.ButtonItem()
        Me.CircularProgressItem1 = New DevComponents.DotNetBar.CircularProgressItem()
        Me.Btn_Admin_Permisos_Usuarios = New DevComponents.DotNetBar.ButtonItem()
        Me.Tiempo_Refresco = New System.Windows.Forms.Timer(Me.components)
        Me.Imagenes_16x16 = New System.Windows.Forms.ImageList(Me.components)
        Me.Chk_Mostrar_Nulas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Timer_Revisar_Notificacion = New System.Windows.Forms.Timer(Me.components)
        Me.Dtp_Fecha_Emision_Hasta = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Lbl_FE_hasta = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_Fecha_Emision_Desde = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Lbl_FE_desde = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Cambiar_Modalidad = New DevComponents.DotNetBar.ButtonX()
        Me.Cmb_Sucursal = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Chk_Mostrar_Todas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.ContextMenuBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridViewX1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_Fecha_Emision_Hasta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_Fecha_Emision_Desde, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Grilla)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 37)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(1078, 460)
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
        Me.GroupPanel1.TabIndex = 1
        Me.GroupPanel1.Text = "Para hacer gestión haga doble clic sobre la fila seleccionada"
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.AllowUserToDeleteRows = False
        Me.Grilla.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla.EnableHeadersVisualStyles = False
        Me.Grilla.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla.Location = New System.Drawing.Point(0, 0)
        Me.Grilla.MultiSelect = False
        Me.Grilla.Name = "Grilla"
        Me.Grilla.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grilla.Size = New System.Drawing.Size(1072, 437)
        Me.Grilla.TabIndex = 1
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.ContextMenuBar2)
        Me.GroupPanel2.Controls.Add(Me.DataGridViewX1)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(1149, 293)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(770, 122)
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
        Me.GroupPanel2.TabIndex = 2
        Me.GroupPanel2.Text = "Para hacer gestión haga doble clic sobre la fila seleccionada"
        '
        'ContextMenuBar2
        '
        Me.ContextMenuBar2.AntiAlias = True
        Me.ContextMenuBar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem1})
        Me.ContextMenuBar2.Location = New System.Drawing.Point(306, 168)
        Me.ContextMenuBar2.Name = "ContextMenuBar2"
        Me.ContextMenuBar2.Size = New System.Drawing.Size(153, 25)
        Me.ContextMenuBar2.Stretch = True
        Me.ContextMenuBar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar2.TabIndex = 81
        Me.ContextMenuBar2.TabStop = False
        Me.ContextMenuBar2.Text = "ContextMenuBar2"
        '
        'ButtonItem1
        '
        Me.ButtonItem1.AutoExpandOnClick = True
        Me.ButtonItem1.Name = "ButtonItem1"
        Me.ButtonItem1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem2, Me.ButtonItem2, Me.ButtonItem3})
        Me.ButtonItem1.Text = "Opciones"
        '
        'LabelItem2
        '
        Me.LabelItem2.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem2.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem2.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem2.Name = "LabelItem2"
        Me.LabelItem2.PaddingBottom = 1
        Me.LabelItem2.PaddingLeft = 10
        Me.LabelItem2.PaddingTop = 1
        Me.LabelItem2.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem2.Text = "Acción"
        '
        'ButtonItem2
        '
        Me.ButtonItem2.Image = CType(resources.GetObject("ButtonItem2.Image"), System.Drawing.Image)
        Me.ButtonItem2.Name = "ButtonItem2"
        Me.ButtonItem2.Text = "Ver deuda pendiente"
        '
        'ButtonItem3
        '
        Me.ButtonItem3.Image = CType(resources.GetObject("ButtonItem3.Image"), System.Drawing.Image)
        Me.ButtonItem3.Name = "ButtonItem3"
        Me.ButtonItem3.Text = "Otorgar permiso al usuario"
        '
        'DataGridViewX1
        '
        Me.DataGridViewX1.AllowUserToAddRows = False
        Me.DataGridViewX1.AllowUserToDeleteRows = False
        Me.DataGridViewX1.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewX1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewX1.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewX1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridViewX1.EnableHeadersVisualStyles = False
        Me.DataGridViewX1.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.DataGridViewX1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridViewX1.MultiSelect = False
        Me.DataGridViewX1.Name = "DataGridViewX1"
        Me.DataGridViewX1.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewX1.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DataGridViewX1.Size = New System.Drawing.Size(764, 99)
        Me.DataGridViewX1.TabIndex = 1
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Refresh, Me.CircularProgressItem1, Me.Btn_Admin_Permisos_Usuarios})
        Me.Bar1.Location = New System.Drawing.Point(0, 530)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(1102, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 117
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Refresh
        '
        Me.Btn_Refresh.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Refresh.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Btn_Refresh.Image = CType(resources.GetObject("Btn_Refresh.Image"), System.Drawing.Image)
        Me.Btn_Refresh.Name = "Btn_Refresh"
        Me.Btn_Refresh.Text = "Refresh"
        '
        'CircularProgressItem1
        '
        Me.CircularProgressItem1.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.CircularProgressItem1.Name = "CircularProgressItem1"
        Me.CircularProgressItem1.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Dot
        '
        'Btn_Admin_Permisos_Usuarios
        '
        Me.Btn_Admin_Permisos_Usuarios.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Admin_Permisos_Usuarios.ForeColor = System.Drawing.Color.Black
        Me.Btn_Admin_Permisos_Usuarios.Image = CType(resources.GetObject("Btn_Admin_Permisos_Usuarios.Image"), System.Drawing.Image)
        Me.Btn_Admin_Permisos_Usuarios.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.Btn_Admin_Permisos_Usuarios.Name = "Btn_Admin_Permisos_Usuarios"
        Me.Btn_Admin_Permisos_Usuarios.Tooltip = "Administrar permisos de usuarios"
        '
        'Tiempo_Refresco
        '
        Me.Tiempo_Refresco.Enabled = True
        Me.Tiempo_Refresco.Interval = 30000
        '
        'Imagenes_16x16
        '
        Me.Imagenes_16x16.ImageStream = CType(resources.GetObject("Imagenes_16x16.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagenes_16x16.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagenes_16x16.Images.SetKeyName(0, "warning.png")
        Me.Imagenes_16x16.Images.SetKeyName(1, "ok.png")
        Me.Imagenes_16x16.Images.SetKeyName(2, "cancel.png")
        Me.Imagenes_16x16.Images.SetKeyName(3, "delete_button_error.png")
        Me.Imagenes_16x16.Images.SetKeyName(4, "clock.png")
        Me.Imagenes_16x16.Images.SetKeyName(5, "clock-import.png")
        Me.Imagenes_16x16.Images.SetKeyName(6, "clock-info.png")
        Me.Imagenes_16x16.Images.SetKeyName(7, "tag_green.png")
        Me.Imagenes_16x16.Images.SetKeyName(8, "note_text.png")
        Me.Imagenes_16x16.Images.SetKeyName(9, "note.png")
        '
        'Chk_Mostrar_Nulas
        '
        Me.Chk_Mostrar_Nulas.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Mostrar_Nulas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Mostrar_Nulas.ForeColor = System.Drawing.Color.Black
        Me.Chk_Mostrar_Nulas.Location = New System.Drawing.Point(12, 506)
        Me.Chk_Mostrar_Nulas.Name = "Chk_Mostrar_Nulas"
        Me.Chk_Mostrar_Nulas.Size = New System.Drawing.Size(183, 18)
        Me.Chk_Mostrar_Nulas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Mostrar_Nulas.TabIndex = 118
        Me.Chk_Mostrar_Nulas.Text = "Mostrar solicitudes nulas"
        '
        'Timer_Revisar_Notificacion
        '
        Me.Timer_Revisar_Notificacion.Interval = 1000
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
        Me.Dtp_Fecha_Emision_Hasta.Location = New System.Drawing.Point(256, 9)
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
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.DisplayMonth = New Date(2016, 7, 1, 0, 0, 0, 0)
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
        Me.Dtp_Fecha_Emision_Hasta.Size = New System.Drawing.Size(81, 22)
        Me.Dtp_Fecha_Emision_Hasta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Emision_Hasta.TabIndex = 8
        Me.Dtp_Fecha_Emision_Hasta.Value = New Date(2016, 7, 8, 16, 33, 0, 0)
        '
        'Lbl_FE_hasta
        '
        Me.Lbl_FE_hasta.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_FE_hasta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_FE_hasta.ForeColor = System.Drawing.Color.Black
        Me.Lbl_FE_hasta.Location = New System.Drawing.Point(222, 12)
        Me.Lbl_FE_hasta.Name = "Lbl_FE_hasta"
        Me.Lbl_FE_hasta.Size = New System.Drawing.Size(34, 19)
        Me.Lbl_FE_hasta.TabIndex = 9
        Me.Lbl_FE_hasta.Text = "Hasta"
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
        Me.Dtp_Fecha_Emision_Desde.Location = New System.Drawing.Point(138, 9)
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
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.DisplayMonth = New Date(2016, 7, 1, 0, 0, 0, 0)
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
        Me.Dtp_Fecha_Emision_Desde.Size = New System.Drawing.Size(79, 22)
        Me.Dtp_Fecha_Emision_Desde.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Emision_Desde.TabIndex = 7
        Me.Dtp_Fecha_Emision_Desde.Value = New Date(2016, 7, 8, 16, 32, 31, 0)
        '
        'Lbl_FE_desde
        '
        Me.Lbl_FE_desde.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_FE_desde.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_FE_desde.ForeColor = System.Drawing.Color.Black
        Me.Lbl_FE_desde.Location = New System.Drawing.Point(103, 12)
        Me.Lbl_FE_desde.Name = "Lbl_FE_desde"
        Me.Lbl_FE_desde.Size = New System.Drawing.Size(38, 19)
        Me.Lbl_FE_desde.TabIndex = 7
        Me.Lbl_FE_desde.Text = "Desde"
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(12, 12)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(95, 19)
        Me.LabelX4.TabIndex = 4
        Me.LabelX4.Text = "Fecha de emisión"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(765, 9)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(53, 22)
        Me.LabelX1.TabIndex = 120
        Me.LabelX1.Text = "Sucursal"
        '
        'Btn_Cambiar_Modalidad
        '
        Me.Btn_Cambiar_Modalidad.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Cambiar_Modalidad.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Cambiar_Modalidad.Image = CType(resources.GetObject("Btn_Cambiar_Modalidad.Image"), System.Drawing.Image)
        Me.Btn_Cambiar_Modalidad.Location = New System.Drawing.Point(622, 9)
        Me.Btn_Cambiar_Modalidad.Name = "Btn_Cambiar_Modalidad"
        Me.Btn_Cambiar_Modalidad.Size = New System.Drawing.Size(137, 22)
        Me.Btn_Cambiar_Modalidad.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Cambiar_Modalidad.TabIndex = 125
        Me.Btn_Cambiar_Modalidad.TabStop = False
        Me.Btn_Cambiar_Modalidad.Text = "Empresa/Modalidad"
        Me.Btn_Cambiar_Modalidad.Tooltip = "Cambiar Sucursal/Modalidad"
        Me.Btn_Cambiar_Modalidad.Visible = False
        '
        'Cmb_Sucursal
        '
        Me.Cmb_Sucursal.DisplayMember = "Text"
        Me.Cmb_Sucursal.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Sucursal.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Sucursal.FormattingEnabled = True
        Me.Cmb_Sucursal.ItemHeight = 16
        Me.Cmb_Sucursal.Location = New System.Drawing.Point(824, 9)
        Me.Cmb_Sucursal.Name = "Cmb_Sucursal"
        Me.Cmb_Sucursal.Size = New System.Drawing.Size(266, 22)
        Me.Cmb_Sucursal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Sucursal.TabIndex = 126
        '
        'Chk_Mostrar_Todas
        '
        Me.Chk_Mostrar_Todas.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Mostrar_Todas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Mostrar_Todas.ForeColor = System.Drawing.Color.Black
        Me.Chk_Mostrar_Todas.Location = New System.Drawing.Point(170, 506)
        Me.Chk_Mostrar_Todas.Name = "Chk_Mostrar_Todas"
        Me.Chk_Mostrar_Todas.Size = New System.Drawing.Size(228, 18)
        Me.Chk_Mostrar_Todas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Mostrar_Todas.TabIndex = 127
        Me.Chk_Mostrar_Todas.Text = "Mostrar todas las solicitudes"
        '
        'Frm_Cadenas_Remotas_Lista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1102, 571)
        Me.Controls.Add(Me.Chk_Mostrar_Todas)
        Me.Controls.Add(Me.Cmb_Sucursal)
        Me.Controls.Add(Me.Btn_Cambiar_Modalidad)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Dtp_Fecha_Emision_Hasta)
        Me.Controls.Add(Me.Lbl_FE_hasta)
        Me.Controls.Add(Me.Chk_Mostrar_Nulas)
        Me.Controls.Add(Me.Dtp_Fecha_Emision_Desde)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.Lbl_FE_desde)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.GroupPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Cadenas_Remotas_Lista"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Documentos en espera para permisos remotos"
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.ContextMenuBar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridViewX1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_Fecha_Emision_Hasta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_Fecha_Emision_Desde, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents ContextMenuBar2 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents ButtonItem2 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem3 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents DataGridViewX1 As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Public WithEvents Btn_Refresh As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Admin_Permisos_Usuarios As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Tiempo_Refresco As System.Windows.Forms.Timer
    Friend WithEvents CircularProgressItem1 As DevComponents.DotNetBar.CircularProgressItem
    Friend WithEvents Imagenes_16x16 As System.Windows.Forms.ImageList
    Friend WithEvents Chk_Mostrar_Nulas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Timer_Revisar_Notificacion As Timer
    Friend WithEvents Dtp_Fecha_Emision_Hasta As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Lbl_FE_hasta As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dtp_Fecha_Emision_Desde As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Lbl_FE_desde As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Cambiar_Modalidad As DevComponents.DotNetBar.ButtonX
    Public WithEvents Cmb_Sucursal As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Chk_Mostrar_Todas As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
