<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Desp_01_Ingreso
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Desp_01_Ingreso))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Grilla_Documentos = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Btn_Direccion_Agencia = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Chilexpress = New DevComponents.DotNetBar.ButtonX()
        Me.Lbl_Suc_Retiro = New DevComponents.DotNetBar.LabelX()
        Me.Cmb_Sucursal_Retiro = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Btn_Buscar_Transportista = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_Transportista = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Btn_Buscar_Tipo_Venta = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_Nombre_Cliente = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Referencia = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Dtp_Fecha_Despacho = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Txt_Tipo_Venta = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Cmb_Tipo_Envio = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Warning_Valor = New DevComponents.DotNetBar.Controls.WarningBox()
        Me.Btn_Modificar_Direccion = New DevComponents.DotNetBar.ButtonX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Editar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Cancelar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Archivos_Adjuntos = New DevComponents.DotNetBar.ButtonItem()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_01 = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Ver_Documento = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Quitar_Documento = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Buscar_Documentos = New DevComponents.DotNetBar.ButtonX()
        Me.Grilla_Productos = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Chk_Entregar_Con_Doc_Pagados = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Transpor_Por_Pagar = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.ReflectionImage1 = New DevComponents.DotNetBar.Controls.ReflectionImage()
        Me.Highlighter1 = New DevComponents.DotNetBar.Validator.Highlighter()
        Me.Txt_Datos_Entidad_Direccion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.SuperTabControl1 = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.Txt_Observaciones = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.SuperTabItem1 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.SuperTabItem2 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel3 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.SuperTabItem3 = New DevComponents.DotNetBar.SuperTabItem()
        Me.Warning_Cantidad = New DevComponents.DotNetBar.Controls.WarningBox()
        Me.Chk_EntregaPaletizada = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Btn_EditarEntregaPaletizada = New DevComponents.DotNetBar.ButtonX()
        CType(Me.Grilla_Documentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Dtp_Fecha_Despacho, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla_Productos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControl1.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        Me.SuperTabControlPanel2.SuspendLayout()
        Me.SuperTabControlPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Grilla_Documentos
        '
        Me.Grilla_Documentos.AllowUserToAddRows = False
        Me.Grilla_Documentos.AllowUserToDeleteRows = False
        Me.Grilla_Documentos.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Documentos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grilla_Documentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Documentos.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grilla_Documentos.EnableHeadersVisualStyles = False
        Me.Grilla_Documentos.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Documentos.Location = New System.Drawing.Point(3, 3)
        Me.Grilla_Documentos.Name = "Grilla_Documentos"
        Me.Grilla_Documentos.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Documentos.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla_Documentos.Size = New System.Drawing.Size(623, 189)
        Me.Grilla_Documentos.StandardTab = True
        Me.Grilla_Documentos.TabIndex = 27
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Btn_Direccion_Agencia)
        Me.GroupPanel1.Controls.Add(Me.Btn_Chilexpress)
        Me.GroupPanel1.Controls.Add(Me.Lbl_Suc_Retiro)
        Me.GroupPanel1.Controls.Add(Me.Cmb_Sucursal_Retiro)
        Me.GroupPanel1.Controls.Add(Me.Btn_Buscar_Transportista)
        Me.GroupPanel1.Controls.Add(Me.Txt_Transportista)
        Me.GroupPanel1.Controls.Add(Me.Btn_Buscar_Tipo_Venta)
        Me.GroupPanel1.Controls.Add(Me.Txt_Nombre_Cliente)
        Me.GroupPanel1.Controls.Add(Me.Txt_Referencia)
        Me.GroupPanel1.Controls.Add(Me.Dtp_Fecha_Despacho)
        Me.GroupPanel1.Controls.Add(Me.Txt_Tipo_Venta)
        Me.GroupPanel1.Controls.Add(Me.LabelX4)
        Me.GroupPanel1.Controls.Add(Me.LabelX1)
        Me.GroupPanel1.Controls.Add(Me.LabelX3)
        Me.GroupPanel1.Controls.Add(Me.Cmb_Tipo_Envio)
        Me.GroupPanel1.Controls.Add(Me.LabelX6)
        Me.GroupPanel1.Controls.Add(Me.LabelX5)
        Me.GroupPanel1.Controls.Add(Me.LabelX2)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 0)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(554, 205)
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
        Me.GroupPanel1.TabIndex = 87
        Me.GroupPanel1.Text = "Información de despacho"
        '
        'Btn_Direccion_Agencia
        '
        Me.Btn_Direccion_Agencia.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Direccion_Agencia.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Direccion_Agencia.Image = CType(resources.GetObject("Btn_Direccion_Agencia.Image"), System.Drawing.Image)
        Me.Btn_Direccion_Agencia.ImageAlt = CType(resources.GetObject("Btn_Direccion_Agencia.ImageAlt"), System.Drawing.Image)
        Me.Btn_Direccion_Agencia.Location = New System.Drawing.Point(220, 32)
        Me.Btn_Direccion_Agencia.Name = "Btn_Direccion_Agencia"
        Me.Btn_Direccion_Agencia.Size = New System.Drawing.Size(81, 22)
        Me.Btn_Direccion_Agencia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Direccion_Agencia.TabIndex = 133
        Me.Btn_Direccion_Agencia.Text = "AG x def."
        Me.Btn_Direccion_Agencia.Tooltip = "Transporte por defecto para el despacho por agencia de esta entidad"
        Me.Btn_Direccion_Agencia.Visible = False
        '
        'Btn_Chilexpress
        '
        Me.Btn_Chilexpress.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Chilexpress.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Chilexpress.Image = CType(resources.GetObject("Btn_Chilexpress.Image"), System.Drawing.Image)
        Me.Btn_Chilexpress.ImageAlt = CType(resources.GetObject("Btn_Chilexpress.ImageAlt"), System.Drawing.Image)
        Me.Btn_Chilexpress.Location = New System.Drawing.Point(369, 144)
        Me.Btn_Chilexpress.Name = "Btn_Chilexpress"
        Me.Btn_Chilexpress.Size = New System.Drawing.Size(112, 29)
        Me.Btn_Chilexpress.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Chilexpress.TabIndex = 132
        Me.Btn_Chilexpress.Text = "<i><b>CHILEXPRESS</b></i>"
        Me.Btn_Chilexpress.Visible = False
        '
        'Lbl_Suc_Retiro
        '
        Me.Lbl_Suc_Retiro.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Suc_Retiro.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Suc_Retiro.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Suc_Retiro.Location = New System.Drawing.Point(307, 32)
        Me.Lbl_Suc_Retiro.Name = "Lbl_Suc_Retiro"
        Me.Lbl_Suc_Retiro.Size = New System.Drawing.Size(59, 20)
        Me.Lbl_Suc_Retiro.TabIndex = 131
        Me.Lbl_Suc_Retiro.Text = "Suc. Retiro"
        '
        'Cmb_Sucursal_Retiro
        '
        Me.Cmb_Sucursal_Retiro.DisplayMember = "Text"
        Me.Cmb_Sucursal_Retiro.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Sucursal_Retiro.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Sucursal_Retiro.FormattingEnabled = True
        Me.Highlighter1.SetHighlightOnFocus(Me.Cmb_Sucursal_Retiro, True)
        Me.Cmb_Sucursal_Retiro.ItemHeight = 16
        Me.Cmb_Sucursal_Retiro.Location = New System.Drawing.Point(371, 32)
        Me.Cmb_Sucursal_Retiro.Name = "Cmb_Sucursal_Retiro"
        Me.Cmb_Sucursal_Retiro.Size = New System.Drawing.Size(167, 22)
        Me.Cmb_Sucursal_Retiro.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Sucursal_Retiro.TabIndex = 2
        '
        'Btn_Buscar_Transportista
        '
        Me.Btn_Buscar_Transportista.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Buscar_Transportista.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Buscar_Transportista.Image = CType(resources.GetObject("Btn_Buscar_Transportista.Image"), System.Drawing.Image)
        Me.Btn_Buscar_Transportista.ImageAlt = CType(resources.GetObject("Btn_Buscar_Transportista.ImageAlt"), System.Drawing.Image)
        Me.Btn_Buscar_Transportista.Location = New System.Drawing.Point(487, 116)
        Me.Btn_Buscar_Transportista.Name = "Btn_Buscar_Transportista"
        Me.Btn_Buscar_Transportista.Size = New System.Drawing.Size(51, 22)
        Me.Btn_Buscar_Transportista.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Buscar_Transportista.TabIndex = 5
        Me.Btn_Buscar_Transportista.Tooltip = "Ver selección"
        '
        'Txt_Transportista
        '
        Me.Txt_Transportista.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Transportista.Border.Class = "TextBoxBorder"
        Me.Txt_Transportista.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Transportista.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Transportista.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Transportista.ForeColor = System.Drawing.Color.Black
        Me.Txt_Transportista.Location = New System.Drawing.Point(86, 116)
        Me.Txt_Transportista.MaxLength = 20
        Me.Txt_Transportista.Name = "Txt_Transportista"
        Me.Txt_Transportista.PreventEnterBeep = True
        Me.Txt_Transportista.ReadOnly = True
        Me.Txt_Transportista.Size = New System.Drawing.Size(395, 22)
        Me.Txt_Transportista.TabIndex = 129
        Me.Txt_Transportista.TabStop = False
        '
        'Btn_Buscar_Tipo_Venta
        '
        Me.Btn_Buscar_Tipo_Venta.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Buscar_Tipo_Venta.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Buscar_Tipo_Venta.Image = CType(resources.GetObject("Btn_Buscar_Tipo_Venta.Image"), System.Drawing.Image)
        Me.Btn_Buscar_Tipo_Venta.ImageAlt = CType(resources.GetObject("Btn_Buscar_Tipo_Venta.ImageAlt"), System.Drawing.Image)
        Me.Btn_Buscar_Tipo_Venta.Location = New System.Drawing.Point(487, 60)
        Me.Btn_Buscar_Tipo_Venta.Name = "Btn_Buscar_Tipo_Venta"
        Me.Btn_Buscar_Tipo_Venta.Size = New System.Drawing.Size(51, 22)
        Me.Btn_Buscar_Tipo_Venta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Buscar_Tipo_Venta.TabIndex = 3
        Me.Btn_Buscar_Tipo_Venta.Tooltip = "Buscar Cliente"
        '
        'Txt_Nombre_Cliente
        '
        Me.Txt_Nombre_Cliente.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Nombre_Cliente.Border.Class = "TextBoxBorder"
        Me.Txt_Nombre_Cliente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Nombre_Cliente.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Nombre_Cliente.ForeColor = System.Drawing.Color.Black
        Me.Txt_Nombre_Cliente.Location = New System.Drawing.Point(86, 4)
        Me.Txt_Nombre_Cliente.MaxLength = 50
        Me.Txt_Nombre_Cliente.Name = "Txt_Nombre_Cliente"
        Me.Txt_Nombre_Cliente.PreventEnterBeep = True
        Me.Txt_Nombre_Cliente.ReadOnly = True
        Me.Txt_Nombre_Cliente.Size = New System.Drawing.Size(452, 22)
        Me.Txt_Nombre_Cliente.TabIndex = 0
        '
        'Txt_Referencia
        '
        Me.Txt_Referencia.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Referencia.Border.Class = "TextBoxBorder"
        Me.Txt_Referencia.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Referencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Referencia.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Referencia.ForeColor = System.Drawing.Color.Black
        Me.Txt_Referencia.Location = New System.Drawing.Point(86, 88)
        Me.Txt_Referencia.MaxLength = 100
        Me.Txt_Referencia.Name = "Txt_Referencia"
        Me.Txt_Referencia.PreventEnterBeep = True
        Me.Txt_Referencia.Size = New System.Drawing.Size(395, 22)
        Me.Txt_Referencia.TabIndex = 4
        '
        'Dtp_Fecha_Despacho
        '
        Me.Dtp_Fecha_Despacho.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_Fecha_Despacho.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Despacho.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Despacho.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Despacho.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Despacho.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Despacho.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Despacho.Location = New System.Drawing.Point(168, 151)
        '
        '
        '
        Me.Dtp_Fecha_Despacho.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Despacho.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Despacho.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Despacho.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Despacho.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Despacho.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Despacho.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Despacho.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Despacho.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Despacho.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Despacho.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Despacho.MonthCalendar.DisplayMonth = New Date(2020, 3, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Despacho.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_Fecha_Despacho.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Despacho.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Despacho.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Despacho.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Despacho.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Despacho.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Despacho.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Despacho.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Despacho.Name = "Dtp_Fecha_Despacho"
        Me.Dtp_Fecha_Despacho.Size = New System.Drawing.Size(80, 22)
        Me.Dtp_Fecha_Despacho.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Despacho.TabIndex = 6
        Me.Dtp_Fecha_Despacho.Value = New Date(2020, 3, 2, 18, 40, 6, 0)
        '
        'Txt_Tipo_Venta
        '
        Me.Txt_Tipo_Venta.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Tipo_Venta.Border.Class = "TextBoxBorder"
        Me.Txt_Tipo_Venta.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Tipo_Venta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Tipo_Venta.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Tipo_Venta.ForeColor = System.Drawing.Color.Black
        Me.Txt_Tipo_Venta.Location = New System.Drawing.Point(86, 60)
        Me.Txt_Tipo_Venta.MaxLength = 20
        Me.Txt_Tipo_Venta.Name = "Txt_Tipo_Venta"
        Me.Txt_Tipo_Venta.PreventEnterBeep = True
        Me.Txt_Tipo_Venta.ReadOnly = True
        Me.Txt_Tipo_Venta.Size = New System.Drawing.Size(395, 22)
        Me.Txt_Tipo_Venta.TabIndex = 127
        Me.Txt_Tipo_Venta.TabStop = False
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(3, 151)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(169, 20)
        Me.LabelX4.TabIndex = 95
        Me.LabelX4.Text = "Fecha compromiso de despacho"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(77, 19)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "Cliente"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(3, 32)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(77, 20)
        Me.LabelX3.TabIndex = 92
        Me.LabelX3.Text = "Tipo de envio"
        '
        'Cmb_Tipo_Envio
        '
        Me.Cmb_Tipo_Envio.DisplayMember = "Text"
        Me.Cmb_Tipo_Envio.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Tipo_Envio.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Tipo_Envio.FormattingEnabled = True
        Me.Highlighter1.SetHighlightOnFocus(Me.Cmb_Tipo_Envio, True)
        Me.Cmb_Tipo_Envio.ItemHeight = 16
        Me.Cmb_Tipo_Envio.Location = New System.Drawing.Point(86, 32)
        Me.Cmb_Tipo_Envio.Name = "Cmb_Tipo_Envio"
        Me.Cmb_Tipo_Envio.Size = New System.Drawing.Size(128, 22)
        Me.Cmb_Tipo_Envio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Tipo_Envio.TabIndex = 1
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(3, 115)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(77, 20)
        Me.LabelX6.TabIndex = 94
        Me.LabelX6.Text = "Transportista"
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(3, 59)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(77, 20)
        Me.LabelX5.TabIndex = 96
        Me.LabelX5.Text = "Tipo venta"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 86)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(77, 21)
        Me.LabelX2.TabIndex = 30
        Me.LabelX2.Text = "Referencia"
        '
        'Warning_Valor
        '
        Me.Warning_Valor.BackColor = System.Drawing.Color.White
        Me.Warning_Valor.ForeColor = System.Drawing.Color.Black
        Me.Warning_Valor.Image = CType(resources.GetObject("Warning_Valor.Image"), System.Drawing.Image)
        Me.Warning_Valor.Location = New System.Drawing.Point(239, 478)
        Me.Warning_Valor.Name = "Warning_Valor"
        Me.Warning_Valor.OptionsText = "Información..."
        Me.Warning_Valor.Size = New System.Drawing.Size(405, 34)
        Me.Warning_Valor.TabIndex = 130
        Me.Warning_Valor.Text = "<b>Validación</b> Bajo el mínimo de venta para despacho"
        Me.Warning_Valor.Visible = False
        '
        'Btn_Modificar_Direccion
        '
        Me.Btn_Modificar_Direccion.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Modificar_Direccion.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Modificar_Direccion.Image = CType(resources.GetObject("Btn_Modificar_Direccion.Image"), System.Drawing.Image)
        Me.Btn_Modificar_Direccion.ImageAlt = CType(resources.GetObject("Btn_Modificar_Direccion.ImageAlt"), System.Drawing.Image)
        Me.Btn_Modificar_Direccion.Location = New System.Drawing.Point(461, 13)
        Me.Btn_Modificar_Direccion.Name = "Btn_Modificar_Direccion"
        Me.Btn_Modificar_Direccion.Size = New System.Drawing.Size(139, 23)
        Me.Btn_Modificar_Direccion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Modificar_Direccion.TabIndex = 122
        Me.Btn_Modificar_Direccion.TabStop = False
        Me.Btn_Modificar_Direccion.Text = "Modificar dirección" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar, Me.Btn_Editar, Me.Btn_Cancelar, Me.Btn_Archivos_Adjuntos})
        Me.Bar2.Location = New System.Drawing.Point(0, 553)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(656, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 89
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
        'Btn_Editar
        '
        Me.Btn_Editar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Editar.FontBold = True
        Me.Btn_Editar.ForeColor = System.Drawing.Color.Red
        Me.Btn_Editar.Image = CType(resources.GetObject("Btn_Editar.Image"), System.Drawing.Image)
        Me.Btn_Editar.ImageAlt = CType(resources.GetObject("Btn_Editar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Editar.Name = "Btn_Editar"
        Me.Btn_Editar.Tooltip = "Editar"
        Me.Btn_Editar.Visible = False
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Cancelar.FontBold = True
        Me.Btn_Cancelar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Btn_Cancelar.Image = CType(resources.GetObject("Btn_Cancelar.Image"), System.Drawing.Image)
        Me.Btn_Cancelar.ImageAlt = CType(resources.GetObject("Btn_Cancelar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Text = "Cancelar edición"
        Me.Btn_Cancelar.Visible = False
        '
        'Btn_Archivos_Adjuntos
        '
        Me.Btn_Archivos_Adjuntos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Archivos_Adjuntos.ForeColor = System.Drawing.Color.Black
        Me.Btn_Archivos_Adjuntos.Image = CType(resources.GetObject("Btn_Archivos_Adjuntos.Image"), System.Drawing.Image)
        Me.Btn_Archivos_Adjuntos.ImageAlt = CType(resources.GetObject("Btn_Archivos_Adjuntos.ImageAlt"), System.Drawing.Image)
        Me.Btn_Archivos_Adjuntos.Name = "Btn_Archivos_Adjuntos"
        Me.Btn_Archivos_Adjuntos.Text = "..."
        Me.Btn_Archivos_Adjuntos.Tooltip = "Ver archivos adjuntos"
        Me.Btn_Archivos_Adjuntos.Visible = False
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_01})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(50, 23)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(153, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 46
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_01
        '
        Me.Menu_Contextual_01.AutoExpandOnClick = True
        Me.Menu_Contextual_01.Name = "Menu_Contextual_01"
        Me.Menu_Contextual_01.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1, Me.Btn_Ver_Documento, Me.Btn_Quitar_Documento})
        Me.Menu_Contextual_01.Text = "Opciones"
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
        'Btn_Ver_Documento
        '
        Me.Btn_Ver_Documento.Image = CType(resources.GetObject("Btn_Ver_Documento.Image"), System.Drawing.Image)
        Me.Btn_Ver_Documento.ImageAlt = CType(resources.GetObject("Btn_Ver_Documento.ImageAlt"), System.Drawing.Image)
        Me.Btn_Ver_Documento.Name = "Btn_Ver_Documento"
        Me.Btn_Ver_Documento.Text = "Ver documento"
        '
        'Btn_Quitar_Documento
        '
        Me.Btn_Quitar_Documento.Image = CType(resources.GetObject("Btn_Quitar_Documento.Image"), System.Drawing.Image)
        Me.Btn_Quitar_Documento.ImageAlt = CType(resources.GetObject("Btn_Quitar_Documento.ImageAlt"), System.Drawing.Image)
        Me.Btn_Quitar_Documento.Name = "Btn_Quitar_Documento"
        Me.Btn_Quitar_Documento.Text = "Quitar documento de la orden"
        '
        'Btn_Buscar_Documentos
        '
        Me.Btn_Buscar_Documentos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Buscar_Documentos.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Buscar_Documentos.Location = New System.Drawing.Point(3, 198)
        Me.Btn_Buscar_Documentos.Name = "Btn_Buscar_Documentos"
        Me.Btn_Buscar_Documentos.Size = New System.Drawing.Size(148, 23)
        Me.Btn_Buscar_Documentos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Buscar_Documentos.TabIndex = 28
        Me.Btn_Buscar_Documentos.Text = "Buscar documentos"
        '
        'Grilla_Productos
        '
        Me.Grilla_Productos.AllowUserToAddRows = False
        Me.Grilla_Productos.AllowUserToDeleteRows = False
        Me.Grilla_Productos.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Productos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Grilla_Productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Productos.DefaultCellStyle = DataGridViewCellStyle5
        Me.Grilla_Productos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Productos.EnableHeadersVisualStyles = False
        Me.Grilla_Productos.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Productos.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Productos.Name = "Grilla_Productos"
        Me.Grilla_Productos.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Productos.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Grilla_Productos.Size = New System.Drawing.Size(632, 261)
        Me.Grilla_Productos.StandardTab = True
        Me.Grilla_Productos.TabIndex = 28
        '
        'Chk_Entregar_Con_Doc_Pagados
        '
        Me.Chk_Entregar_Con_Doc_Pagados.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Entregar_Con_Doc_Pagados.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Entregar_Con_Doc_Pagados.ForeColor = System.Drawing.Color.Black
        Me.Chk_Entregar_Con_Doc_Pagados.Location = New System.Drawing.Point(12, 524)
        Me.Chk_Entregar_Con_Doc_Pagados.Name = "Chk_Entregar_Con_Doc_Pagados"
        Me.Chk_Entregar_Con_Doc_Pagados.Size = New System.Drawing.Size(211, 23)
        Me.Chk_Entregar_Con_Doc_Pagados.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Entregar_Con_Doc_Pagados.TabIndex = 124
        Me.Chk_Entregar_Con_Doc_Pagados.TabStop = False
        Me.Chk_Entregar_Con_Doc_Pagados.Text = "Cliente debe pagar antes de retirar"
        '
        'Chk_Transpor_Por_Pagar
        '
        Me.Chk_Transpor_Por_Pagar.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Transpor_Por_Pagar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Transpor_Por_Pagar.ForeColor = System.Drawing.Color.Black
        Me.Chk_Transpor_Por_Pagar.Location = New System.Drawing.Point(12, 502)
        Me.Chk_Transpor_Por_Pagar.Name = "Chk_Transpor_Por_Pagar"
        Me.Chk_Transpor_Por_Pagar.Size = New System.Drawing.Size(211, 23)
        Me.Chk_Transpor_Por_Pagar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Transpor_Por_Pagar.TabIndex = 125
        Me.Chk_Transpor_Por_Pagar.TabStop = False
        Me.Chk_Transpor_Por_Pagar.Text = "Transporte por pagar"
        '
        'ReflectionImage1
        '
        Me.ReflectionImage1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.ReflectionImage1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionImage1.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.ReflectionImage1.ForeColor = System.Drawing.Color.Black
        Me.ReflectionImage1.Image = CType(resources.GetObject("ReflectionImage1.Image"), System.Drawing.Image)
        Me.ReflectionImage1.Location = New System.Drawing.Point(572, 12)
        Me.ReflectionImage1.Name = "ReflectionImage1"
        Me.ReflectionImage1.Size = New System.Drawing.Size(72, 193)
        Me.ReflectionImage1.TabIndex = 126
        '
        'Highlighter1
        '
        Me.Highlighter1.ContainerControl = Me
        Me.Highlighter1.FocusHighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Green
        Me.Highlighter1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        '
        'Txt_Datos_Entidad_Direccion
        '
        Me.Txt_Datos_Entidad_Direccion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Datos_Entidad_Direccion.Border.Class = "TextBoxBorder"
        Me.Txt_Datos_Entidad_Direccion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Datos_Entidad_Direccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Datos_Entidad_Direccion.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Datos_Entidad_Direccion.ForeColor = System.Drawing.Color.Black
        Me.Txt_Datos_Entidad_Direccion.Location = New System.Drawing.Point(6, 3)
        Me.Txt_Datos_Entidad_Direccion.MaxLength = 500
        Me.Txt_Datos_Entidad_Direccion.Multiline = True
        Me.Txt_Datos_Entidad_Direccion.Name = "Txt_Datos_Entidad_Direccion"
        Me.Txt_Datos_Entidad_Direccion.PreventEnterBeep = True
        Me.Txt_Datos_Entidad_Direccion.ReadOnly = True
        Me.Txt_Datos_Entidad_Direccion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Datos_Entidad_Direccion.Size = New System.Drawing.Size(623, 162)
        Me.Txt_Datos_Entidad_Direccion.TabIndex = 127
        Me.Txt_Datos_Entidad_Direccion.Text = "CARLOS ROJAS SILVA" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "7473816-8" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "AV. SANCHEZ FONTECILLA 11528" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "CHILE" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "METROPOLITANA" &
    " DE SANTIAGO" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "PEÑALOLÉN" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "+56962190937" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'SuperTabControl1
        '
        Me.SuperTabControl1.BackColor = System.Drawing.Color.White
        '
        '
        '
        '
        '
        '
        Me.SuperTabControl1.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.SuperTabControl1.ControlBox.MenuBox.Name = ""
        Me.SuperTabControl1.ControlBox.Name = ""
        Me.SuperTabControl1.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabControl1.ControlBox.MenuBox, Me.SuperTabControl1.ControlBox.CloseBox})
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel1)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel2)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel3)
        Me.SuperTabControl1.ForeColor = System.Drawing.Color.Black
        Me.SuperTabControl1.Location = New System.Drawing.Point(12, 211)
        Me.SuperTabControl1.Name = "SuperTabControl1"
        Me.SuperTabControl1.ReorderTabsEnabled = True
        Me.SuperTabControl1.SelectedTabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.SuperTabControl1.SelectedTabIndex = 0
        Me.SuperTabControl1.Size = New System.Drawing.Size(632, 261)
        Me.SuperTabControl1.TabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SuperTabControl1.TabIndex = 129
        Me.SuperTabControl1.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabItem1, Me.SuperTabItem2, Me.SuperTabItem3})
        Me.SuperTabControl1.Text = "SuperTabControl1"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.Btn_Modificar_Direccion)
        Me.SuperTabControlPanel1.Controls.Add(Me.Txt_Observaciones)
        Me.SuperTabControlPanel1.Controls.Add(Me.Txt_Datos_Entidad_Direccion)
        Me.SuperTabControlPanel1.Controls.Add(Me.LabelX7)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 27)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(632, 234)
        Me.SuperTabControlPanel1.TabIndex = 1
        Me.SuperTabControlPanel1.TabItem = Me.SuperTabItem1
        '
        'Txt_Observaciones
        '
        Me.Txt_Observaciones.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Observaciones.Border.Class = "TextBoxBorder"
        Me.Txt_Observaciones.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Observaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Observaciones.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Observaciones.ForeColor = System.Drawing.Color.Black
        Me.Txt_Observaciones.Location = New System.Drawing.Point(6, 182)
        Me.Txt_Observaciones.MaxLength = 500
        Me.Txt_Observaciones.Multiline = True
        Me.Txt_Observaciones.Name = "Txt_Observaciones"
        Me.Txt_Observaciones.PreventEnterBeep = True
        Me.Txt_Observaciones.Size = New System.Drawing.Size(623, 49)
        Me.Txt_Observaciones.TabIndex = 7
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.ForeColor = System.Drawing.Color.Black
        Me.LabelX7.Location = New System.Drawing.Point(6, 163)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(77, 20)
        Me.LabelX7.TabIndex = 129
        Me.LabelX7.Text = "Observaciones"
        '
        'SuperTabItem1
        '
        Me.SuperTabItem1.AttachedControl = Me.SuperTabControlPanel1
        Me.SuperTabItem1.GlobalItem = False
        Me.SuperTabItem1.Name = "SuperTabItem1"
        Me.SuperTabItem1.Text = "Datos del envío"
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Controls.Add(Me.Btn_Buscar_Documentos)
        Me.SuperTabControlPanel2.Controls.Add(Me.ContextMenuBar1)
        Me.SuperTabControlPanel2.Controls.Add(Me.Grilla_Documentos)
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(632, 261)
        Me.SuperTabControlPanel2.TabIndex = 0
        Me.SuperTabControlPanel2.TabItem = Me.SuperTabItem2
        '
        'SuperTabItem2
        '
        Me.SuperTabItem2.AttachedControl = Me.SuperTabControlPanel2
        Me.SuperTabItem2.GlobalItem = False
        Me.SuperTabItem2.Name = "SuperTabItem2"
        Me.SuperTabItem2.Text = "Documentos"
        '
        'SuperTabControlPanel3
        '
        Me.SuperTabControlPanel3.Controls.Add(Me.Grilla_Productos)
        Me.SuperTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel3.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel3.Name = "SuperTabControlPanel3"
        Me.SuperTabControlPanel3.Size = New System.Drawing.Size(632, 261)
        Me.SuperTabControlPanel3.TabIndex = 0
        Me.SuperTabControlPanel3.TabItem = Me.SuperTabItem3
        '
        'SuperTabItem3
        '
        Me.SuperTabItem3.AttachedControl = Me.SuperTabControlPanel3
        Me.SuperTabItem3.GlobalItem = False
        Me.SuperTabItem3.Name = "SuperTabItem3"
        Me.SuperTabItem3.Text = "Productos consolidados"
        '
        'Warning_Cantidad
        '
        Me.Warning_Cantidad.BackColor = System.Drawing.Color.White
        Me.Warning_Cantidad.ForeColor = System.Drawing.Color.Black
        Me.Warning_Cantidad.Image = CType(resources.GetObject("Warning_Cantidad.Image"), System.Drawing.Image)
        Me.Warning_Cantidad.Location = New System.Drawing.Point(239, 515)
        Me.Warning_Cantidad.Name = "Warning_Cantidad"
        Me.Warning_Cantidad.OptionsText = "Información..."
        Me.Warning_Cantidad.Size = New System.Drawing.Size(405, 34)
        Me.Warning_Cantidad.TabIndex = 131
        Me.Warning_Cantidad.Text = "<b>Validación</b> Bajo el mínimo de KG por transportista"
        Me.Warning_Cantidad.Visible = False
        '
        'Chk_EntregaPaletizada
        '
        Me.Chk_EntregaPaletizada.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_EntregaPaletizada.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_EntregaPaletizada.Enabled = False
        Me.Chk_EntregaPaletizada.ForeColor = System.Drawing.Color.Black
        Me.Chk_EntregaPaletizada.Location = New System.Drawing.Point(12, 478)
        Me.Chk_EntregaPaletizada.Name = "Chk_EntregaPaletizada"
        Me.Chk_EntregaPaletizada.Size = New System.Drawing.Size(110, 23)
        Me.Chk_EntregaPaletizada.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_EntregaPaletizada.TabIndex = 132
        Me.Chk_EntregaPaletizada.Text = "Entrega paletizada"
        '
        'Btn_EditarEntregaPaletizada
        '
        Me.Btn_EditarEntregaPaletizada.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_EditarEntregaPaletizada.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_EditarEntregaPaletizada.Location = New System.Drawing.Point(128, 478)
        Me.Btn_EditarEntregaPaletizada.Name = "Btn_EditarEntregaPaletizada"
        Me.Btn_EditarEntregaPaletizada.Size = New System.Drawing.Size(75, 23)
        Me.Btn_EditarEntregaPaletizada.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_EditarEntregaPaletizada.TabIndex = 133
        Me.Btn_EditarEntregaPaletizada.Text = "<- Modificar"
        '
        'Frm_Desp_01_Ingreso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(656, 594)
        Me.Controls.Add(Me.Btn_EditarEntregaPaletizada)
        Me.Controls.Add(Me.Chk_EntregaPaletizada)
        Me.Controls.Add(Me.Warning_Valor)
        Me.Controls.Add(Me.Warning_Cantidad)
        Me.Controls.Add(Me.SuperTabControl1)
        Me.Controls.Add(Me.ReflectionImage1)
        Me.Controls.Add(Me.Chk_Transpor_Por_Pagar)
        Me.Controls.Add(Me.Chk_Entregar_Con_Doc_Pagados)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.GroupPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Desp_01_Ingreso"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ORDEN DE DESPACHO"
        CType(Me.Grilla_Documentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.Dtp_Fecha_Despacho, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla_Productos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControl1.ResumeLayout(False)
        Me.SuperTabControlPanel1.ResumeLayout(False)
        Me.SuperTabControlPanel2.ResumeLayout(False)
        Me.SuperTabControlPanel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Grilla_Documentos As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Editar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Cancelar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Archivos_Adjuntos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Chk_Entregar_Con_Doc_Pagados As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Grilla_Productos As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Public WithEvents Cmb_Tipo_Envio As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Btn_Modificar_Direccion As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Chk_Transpor_Por_Pagar As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Public WithEvents Btn_Buscar_Transportista As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Buscar_Documentos As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_01 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Ver_Documento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Quitar_Documento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Buscar_Tipo_Venta As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ReflectionImage1 As DevComponents.DotNetBar.Controls.ReflectionImage
    Friend WithEvents Highlighter1 As DevComponents.DotNetBar.Validator.Highlighter
    Friend WithEvents Txt_Nombre_Cliente As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Transportista As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Referencia As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Tipo_Venta As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Datos_Entidad_Direccion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents SuperTabControl1 As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem1 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem2 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel3 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem3 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents Lbl_Suc_Retiro As DevComponents.DotNetBar.LabelX
    Public WithEvents Cmb_Sucursal_Retiro As DevComponents.DotNetBar.Controls.ComboBoxEx
    Public WithEvents Dtp_Fecha_Despacho As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Txt_Observaciones As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Warning_Cantidad As DevComponents.DotNetBar.Controls.WarningBox
    Friend WithEvents Warning_Valor As DevComponents.DotNetBar.Controls.WarningBox
    Friend WithEvents Btn_Chilexpress As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Direccion_Agencia As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Chk_EntregaPaletizada As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Btn_EditarEntregaPaletizada As DevComponents.DotNetBar.ButtonX
End Class
