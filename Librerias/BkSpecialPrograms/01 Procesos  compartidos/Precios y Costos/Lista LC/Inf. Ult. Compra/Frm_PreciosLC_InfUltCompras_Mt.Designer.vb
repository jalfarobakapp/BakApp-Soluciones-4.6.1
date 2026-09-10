<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_PreciosLC_InfUltCompras_Mt
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_PreciosLC_InfUltCompras_Mt))
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Grilla_GRC_Ant = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Actualizar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Procesar = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Cmb_Margen = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Input_Margen = New DevComponents.Editors.IntegerInput()
        Me.Chk_QuitarSeleccionados = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_GRCconFCC = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Txt_BuscaXProducto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Filtro_Productos = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.Cmb_GRCvsUltGRC = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Cmb_ListaPrecio = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.DFechaTermino = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.DFechaInicio = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.TabControl1 = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.GrillaProdActualizados = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.SuperTabItem2 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Ver_Documento = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_ListaLC = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_OfertasDinamicas = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Copiar = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.SuperTabItem1 = New DevComponents.DotNetBar.SuperTabItem()
        Me.Btn_VerInformeXProductos = New DevComponents.DotNetBar.ButtonItem()
        CType(Me.Grilla_GRC_Ant, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel3.SuspendLayout()
        CType(Me.Input_Margen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DFechaTermino, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DFechaInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.SuperTabControlPanel2.SuspendLayout()
        CType(Me.GrillaProdActualizados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel1.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Grilla_GRC_Ant
        '
        Me.Grilla_GRC_Ant.AllowUserToAddRows = False
        Me.Grilla_GRC_Ant.AllowUserToDeleteRows = False
        Me.Grilla_GRC_Ant.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_GRC_Ant.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grilla_GRC_Ant.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_GRC_Ant.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grilla_GRC_Ant.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_GRC_Ant.EnableHeadersVisualStyles = False
        Me.Grilla_GRC_Ant.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_GRC_Ant.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_GRC_Ant.Name = "Grilla_GRC_Ant"
        Me.Grilla_GRC_Ant.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_GRC_Ant.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla_GRC_Ant.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grilla_GRC_Ant.Size = New System.Drawing.Size(1032, 77)
        Me.Grilla_GRC_Ant.StandardTab = True
        Me.Grilla_GRC_Ant.TabIndex = 30
        '
        'GroupPanel1
        '
        Me.GroupPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Grilla_GRC_Ant)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(1, 480)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(1038, 100)
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
        Me.GroupPanel1.TabIndex = 19
        Me.GroupPanel1.Text = "Datos de la última GRC anterior a la seleccionada"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Actualizar, Me.Btn_Procesar, Me.Btn_VerInformeXProductos})
        Me.Bar2.Location = New System.Drawing.Point(0, 586)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(1040, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar2.TabIndex = 53
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Actualizar
        '
        Me.Btn_Actualizar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Actualizar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Actualizar.Image = CType(resources.GetObject("Btn_Actualizar.Image"), System.Drawing.Image)
        Me.Btn_Actualizar.ImageAlt = CType(resources.GetObject("Btn_Actualizar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Actualizar.Name = "Btn_Actualizar"
        '
        'Btn_Procesar
        '
        Me.Btn_Procesar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Procesar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Procesar.Image = CType(resources.GetObject("Btn_Procesar.Image"), System.Drawing.Image)
        Me.Btn_Procesar.ImageAlt = CType(resources.GetObject("Btn_Procesar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Procesar.Name = "Btn_Procesar"
        Me.Btn_Procesar.Text = "Procesar marcados"
        '
        'GroupPanel3
        '
        Me.GroupPanel3.BackColor = System.Drawing.Color.White
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.Cmb_Margen)
        Me.GroupPanel3.Controls.Add(Me.Input_Margen)
        Me.GroupPanel3.Controls.Add(Me.Chk_QuitarSeleccionados)
        Me.GroupPanel3.Controls.Add(Me.Chk_GRCconFCC)
        Me.GroupPanel3.Controls.Add(Me.Txt_BuscaXProducto)
        Me.GroupPanel3.Controls.Add(Me.LabelX2)
        Me.GroupPanel3.Controls.Add(Me.Btn_Filtro_Productos)
        Me.GroupPanel3.Controls.Add(Me.LabelX5)
        Me.GroupPanel3.Controls.Add(Me.Cmb_GRCvsUltGRC)
        Me.GroupPanel3.Controls.Add(Me.LabelX1)
        Me.GroupPanel3.Controls.Add(Me.Cmb_ListaPrecio)
        Me.GroupPanel3.Controls.Add(Me.LabelX9)
        Me.GroupPanel3.Controls.Add(Me.DFechaTermino)
        Me.GroupPanel3.Controls.Add(Me.LabelX4)
        Me.GroupPanel3.Controls.Add(Me.DFechaInicio)
        Me.GroupPanel3.Controls.Add(Me.LabelX3)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Location = New System.Drawing.Point(1, 0)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(1038, 108)
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
        Me.GroupPanel3.TabIndex = 105
        Me.GroupPanel3.Text = "Buscador"
        '
        'Cmb_Margen
        '
        Me.Cmb_Margen.DisplayMember = "Text"
        Me.Cmb_Margen.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Margen.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Margen.FormattingEnabled = True
        Me.Cmb_Margen.ItemHeight = 16
        Me.Cmb_Margen.Location = New System.Drawing.Point(451, 34)
        Me.Cmb_Margen.Name = "Cmb_Margen"
        Me.Cmb_Margen.Size = New System.Drawing.Size(145, 22)
        Me.Cmb_Margen.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Margen.TabIndex = 128
        '
        'Input_Margen
        '
        Me.Input_Margen.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_Margen.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_Margen.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_Margen.ButtonCustom.Visible = True
        Me.Input_Margen.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.Input_Margen.ForeColor = System.Drawing.Color.Black
        Me.Input_Margen.Location = New System.Drawing.Point(602, 34)
        Me.Input_Margen.MaxValue = 999
        Me.Input_Margen.MinValue = -999
        Me.Input_Margen.Name = "Input_Margen"
        Me.Input_Margen.ShowUpDown = True
        Me.Input_Margen.Size = New System.Drawing.Size(80, 22)
        Me.Input_Margen.TabIndex = 127
        '
        'Chk_QuitarSeleccionados
        '
        Me.Chk_QuitarSeleccionados.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_QuitarSeleccionados.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_QuitarSeleccionados.FocusCuesEnabled = False
        Me.Chk_QuitarSeleccionados.ForeColor = System.Drawing.Color.Black
        Me.Chk_QuitarSeleccionados.Location = New System.Drawing.Point(132, 59)
        Me.Chk_QuitarSeleccionados.Name = "Chk_QuitarSeleccionados"
        Me.Chk_QuitarSeleccionados.Size = New System.Drawing.Size(133, 23)
        Me.Chk_QuitarSeleccionados.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_QuitarSeleccionados.TabIndex = 126
        Me.Chk_QuitarSeleccionados.Text = "Quitar seleccionados"
        '
        'Chk_GRCconFCC
        '
        Me.Chk_GRCconFCC.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_GRCconFCC.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_GRCconFCC.FocusCuesEnabled = False
        Me.Chk_GRCconFCC.ForeColor = System.Drawing.Color.Black
        Me.Chk_GRCconFCC.Location = New System.Drawing.Point(3, 59)
        Me.Chk_GRCconFCC.Name = "Chk_GRCconFCC"
        Me.Chk_GRCconFCC.Size = New System.Drawing.Size(123, 23)
        Me.Chk_GRCconFCC.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_GRCconFCC.TabIndex = 125
        Me.Chk_GRCconFCC.Text = "Mostrar solo con FCC"
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
        Me.Txt_BuscaXProducto.Location = New System.Drawing.Point(842, 32)
        Me.Txt_BuscaXProducto.Name = "Txt_BuscaXProducto"
        Me.Txt_BuscaXProducto.PreventEnterBeep = True
        Me.Txt_BuscaXProducto.ReadOnly = True
        Me.Txt_BuscaXProducto.Size = New System.Drawing.Size(187, 22)
        Me.Txt_BuscaXProducto.TabIndex = 123
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(753, 33)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(95, 23)
        Me.LabelX2.TabIndex = 124
        Me.LabelX2.Text = "Buscar producto"
        '
        'Btn_Filtro_Productos
        '
        Me.Btn_Filtro_Productos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Filtro_Productos.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Filtro_Productos.Image = CType(resources.GetObject("Btn_Filtro_Productos.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Productos.ImageAlt = CType(resources.GetObject("Btn_Filtro_Productos.ImageAlt"), System.Drawing.Image)
        Me.Btn_Filtro_Productos.Location = New System.Drawing.Point(753, 3)
        Me.Btn_Filtro_Productos.Name = "Btn_Filtro_Productos"
        Me.Btn_Filtro_Productos.Size = New System.Drawing.Size(276, 23)
        Me.Btn_Filtro_Productos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Filtro_Productos.TabIndex = 122
        Me.Btn_Filtro_Productos.Text = "Filtrar productos..."
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(367, 33)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(78, 23)
        Me.LabelX5.TabIndex = 121
        Me.LabelX5.Text = "Margen"
        '
        'Cmb_GRCvsUltGRC
        '
        Me.Cmb_GRCvsUltGRC.DisplayMember = "Text"
        Me.Cmb_GRCvsUltGRC.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_GRCvsUltGRC.ForeColor = System.Drawing.Color.Black
        Me.Cmb_GRCvsUltGRC.FormattingEnabled = True
        Me.Cmb_GRCvsUltGRC.ItemHeight = 16
        Me.Cmb_GRCvsUltGRC.Location = New System.Drawing.Point(207, 32)
        Me.Cmb_GRCvsUltGRC.Name = "Cmb_GRCvsUltGRC"
        Me.Cmb_GRCvsUltGRC.Size = New System.Drawing.Size(144, 22)
        Me.Cmb_GRCvsUltGRC.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_GRCvsUltGRC.TabIndex = 116
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(5, 32)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(196, 23)
        Me.LabelX1.TabIndex = 117
        Me.LabelX1.Text = "Porcentaje Dif. costos GRC vs Ult. GRC"
        '
        'Cmb_ListaPrecio
        '
        Me.Cmb_ListaPrecio.DisplayMember = "Text"
        Me.Cmb_ListaPrecio.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_ListaPrecio.ForeColor = System.Drawing.Color.Black
        Me.Cmb_ListaPrecio.FormattingEnabled = True
        Me.Cmb_ListaPrecio.ItemHeight = 16
        Me.Cmb_ListaPrecio.Location = New System.Drawing.Point(451, 4)
        Me.Cmb_ListaPrecio.Name = "Cmb_ListaPrecio"
        Me.Cmb_ListaPrecio.Size = New System.Drawing.Size(231, 22)
        Me.Cmb_ListaPrecio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_ListaPrecio.TabIndex = 108
        '
        'LabelX9
        '
        Me.LabelX9.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.ForeColor = System.Drawing.Color.Black
        Me.LabelX9.Location = New System.Drawing.Point(367, 3)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(78, 23)
        Me.LabelX9.TabIndex = 109
        Me.LabelX9.Text = "Lista de precios"
        '
        'DFechaTermino
        '
        Me.DFechaTermino.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.DFechaTermino.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.DFechaTermino.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DFechaTermino.ButtonClear.Visible = True
        Me.DFechaTermino.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.DFechaTermino.ButtonDropDown.Visible = True
        Me.DFechaTermino.ForeColor = System.Drawing.Color.Black
        Me.DFechaTermino.IsPopupCalendarOpen = False
        Me.DFechaTermino.Location = New System.Drawing.Point(250, 4)
        '
        '
        '
        Me.DFechaTermino.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.DFechaTermino.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DFechaTermino.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.DFechaTermino.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.DFechaTermino.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.DFechaTermino.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.DFechaTermino.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.DFechaTermino.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.DFechaTermino.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.DFechaTermino.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.DFechaTermino.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DFechaTermino.MonthCalendar.DisplayMonth = New Date(2023, 3, 1, 0, 0, 0, 0)
        Me.DFechaTermino.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.DFechaTermino.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.DFechaTermino.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.DFechaTermino.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.DFechaTermino.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.DFechaTermino.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.DFechaTermino.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DFechaTermino.MonthCalendar.TodayButtonVisible = True
        Me.DFechaTermino.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.DFechaTermino.Name = "DFechaTermino"
        Me.DFechaTermino.Size = New System.Drawing.Size(101, 22)
        Me.DFechaTermino.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.DFechaTermino.TabIndex = 105
        Me.DFechaTermino.Value = New Date(2023, 3, 6, 13, 17, 7, 0)
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(186, 3)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(69, 23)
        Me.LabelX4.TabIndex = 104
        Me.LabelX4.Text = "Fecha hasta"
        '
        'DFechaInicio
        '
        Me.DFechaInicio.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.DFechaInicio.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.DFechaInicio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DFechaInicio.ButtonClear.Visible = True
        Me.DFechaInicio.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.DFechaInicio.ButtonDropDown.Visible = True
        Me.DFechaInicio.ForeColor = System.Drawing.Color.Black
        Me.DFechaInicio.IsPopupCalendarOpen = False
        Me.DFechaInicio.Location = New System.Drawing.Point(79, 4)
        '
        '
        '
        Me.DFechaInicio.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.DFechaInicio.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DFechaInicio.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.DFechaInicio.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.DFechaInicio.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.DFechaInicio.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.DFechaInicio.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.DFechaInicio.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.DFechaInicio.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.DFechaInicio.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.DFechaInicio.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DFechaInicio.MonthCalendar.DisplayMonth = New Date(2023, 3, 1, 0, 0, 0, 0)
        Me.DFechaInicio.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.DFechaInicio.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.DFechaInicio.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.DFechaInicio.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.DFechaInicio.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.DFechaInicio.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.DFechaInicio.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DFechaInicio.MonthCalendar.TodayButtonVisible = True
        Me.DFechaInicio.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.DFechaInicio.Name = "DFechaInicio"
        Me.DFechaInicio.Size = New System.Drawing.Size(101, 22)
        Me.DFechaInicio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.DFechaInicio.TabIndex = 103
        Me.DFechaInicio.Value = New Date(2023, 3, 6, 13, 17, 7, 0)
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(5, 3)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(68, 23)
        Me.LabelX3.TabIndex = 102
        Me.LabelX3.Text = "Fecha desde"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.BackColor = System.Drawing.Color.White
        '
        '
        '
        '
        '
        '
        Me.TabControl1.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.TabControl1.ControlBox.MenuBox.Name = ""
        Me.TabControl1.ControlBox.Name = ""
        Me.TabControl1.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.TabControl1.ControlBox.MenuBox, Me.TabControl1.ControlBox.CloseBox})
        Me.TabControl1.Controls.Add(Me.SuperTabControlPanel1)
        Me.TabControl1.Controls.Add(Me.SuperTabControlPanel2)
        Me.TabControl1.ForeColor = System.Drawing.Color.Black
        Me.TabControl1.Location = New System.Drawing.Point(1, 114)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.ReorderTabsEnabled = True
        Me.TabControl1.SelectedTabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TabControl1.SelectedTabIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1038, 360)
        Me.TabControl1.TabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.TabIndex = 106
        Me.TabControl1.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabItem1, Me.SuperTabItem2})
        Me.TabControl1.Text = "SuperTabControl1"
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Controls.Add(Me.GrillaProdActualizados)
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(1038, 360)
        Me.SuperTabControlPanel2.TabIndex = 0
        Me.SuperTabControlPanel2.TabItem = Me.SuperTabItem2
        '
        'GrillaProdActualizados
        '
        Me.GrillaProdActualizados.AllowUserToAddRows = False
        Me.GrillaProdActualizados.AllowUserToDeleteRows = False
        Me.GrillaProdActualizados.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GrillaProdActualizados.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.GrillaProdActualizados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GrillaProdActualizados.DefaultCellStyle = DataGridViewCellStyle8
        Me.GrillaProdActualizados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrillaProdActualizados.EnableHeadersVisualStyles = False
        Me.GrillaProdActualizados.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.GrillaProdActualizados.Location = New System.Drawing.Point(0, 0)
        Me.GrillaProdActualizados.Name = "GrillaProdActualizados"
        Me.GrillaProdActualizados.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GrillaProdActualizados.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.GrillaProdActualizados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrillaProdActualizados.Size = New System.Drawing.Size(1038, 360)
        Me.GrillaProdActualizados.StandardTab = True
        Me.GrillaProdActualizados.TabIndex = 31
        '
        'SuperTabItem2
        '
        Me.SuperTabItem2.AttachedControl = Me.SuperTabControlPanel2
        Me.SuperTabItem2.GlobalItem = False
        Me.SuperTabItem2.Name = "SuperTabItem2"
        Me.SuperTabItem2.Text = "Productos procesados entre fechas"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.ContextMenuBar1)
        Me.SuperTabControlPanel1.Controls.Add(Me.Grilla)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 27)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(1038, 333)
        Me.SuperTabControlPanel1.TabIndex = 1
        Me.SuperTabControlPanel1.TabItem = Me.SuperTabItem1
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(92, 52)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(319, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 31
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual
        '
        Me.Menu_Contextual.AutoExpandOnClick = True
        Me.Menu_Contextual.Name = "Menu_Contextual"
        Me.Menu_Contextual.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Ver_Documento, Me.Btn_ListaLC, Me.Btn_OfertasDinamicas, Me.Btn_Copiar})
        Me.Menu_Contextual.Text = "Opciones"
        '
        'Btn_Ver_Documento
        '
        Me.Btn_Ver_Documento.Image = CType(resources.GetObject("Btn_Ver_Documento.Image"), System.Drawing.Image)
        Me.Btn_Ver_Documento.ImageAlt = CType(resources.GetObject("Btn_Ver_Documento.ImageAlt"), System.Drawing.Image)
        Me.Btn_Ver_Documento.Name = "Btn_Ver_Documento"
        Me.Btn_Ver_Documento.Text = "Ver documento"
        '
        'Btn_ListaLC
        '
        Me.Btn_ListaLC.Image = CType(resources.GetObject("Btn_ListaLC.Image"), System.Drawing.Image)
        Me.Btn_ListaLC.ImageAlt = CType(resources.GetObject("Btn_ListaLC.ImageAlt"), System.Drawing.Image)
        Me.Btn_ListaLC.Name = "Btn_ListaLC"
        Me.Btn_ListaLC.Text = "Lista LC (Mantención de precios LC)"
        Me.Btn_ListaLC.Visible = False
        '
        'Btn_OfertasDinamicas
        '
        Me.Btn_OfertasDinamicas.Image = CType(resources.GetObject("Btn_OfertasDinamicas.Image"), System.Drawing.Image)
        Me.Btn_OfertasDinamicas.ImageAlt = CType(resources.GetObject("Btn_OfertasDinamicas.ImageAlt"), System.Drawing.Image)
        Me.Btn_OfertasDinamicas.Name = "Btn_OfertasDinamicas"
        Me.Btn_OfertasDinamicas.Text = "Control de ofertas dinámicas"
        Me.Btn_OfertasDinamicas.Visible = False
        '
        'Btn_Copiar
        '
        Me.Btn_Copiar.Image = CType(resources.GetObject("Btn_Copiar.Image"), System.Drawing.Image)
        Me.Btn_Copiar.ImageAlt = CType(resources.GetObject("Btn_Copiar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Copiar.Name = "Btn_Copiar"
        Me.Btn_Copiar.Text = "Copiar (portapapeles)"
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.AllowUserToDeleteRows = False
        Me.Grilla.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla.DefaultCellStyle = DataGridViewCellStyle5
        Me.Grilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla.EnableHeadersVisualStyles = False
        Me.Grilla.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla.Location = New System.Drawing.Point(0, 0)
        Me.Grilla.Name = "Grilla"
        Me.Grilla.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grilla.Size = New System.Drawing.Size(1038, 333)
        Me.Grilla.StandardTab = True
        Me.Grilla.TabIndex = 30
        '
        'SuperTabItem1
        '
        Me.SuperTabItem1.AttachedControl = Me.SuperTabControlPanel1
        Me.SuperTabItem1.GlobalItem = False
        Me.SuperTabItem1.Name = "SuperTabItem1"
        Me.SuperTabItem1.Text = "Productos recepcionados sin cambio de precios entre fechas"
        '
        'Btn_VerInformeXProductos
        '
        Me.Btn_VerInformeXProductos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_VerInformeXProductos.ForeColor = System.Drawing.Color.Black
        Me.Btn_VerInformeXProductos.Image = CType(resources.GetObject("Btn_VerInformeXProductos.Image"), System.Drawing.Image)
        Me.Btn_VerInformeXProductos.ImageAlt = CType(resources.GetObject("Btn_VerInformeXProductos.ImageAlt"), System.Drawing.Image)
        Me.Btn_VerInformeXProductos.Name = "Btn_VerInformeXProductos"
        Me.Btn_VerInformeXProductos.Text = "Ver informe por productos"
        '
        'Frm_PreciosLC_InfUltCompras_Mt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1040, 627)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GroupPanel3)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.GroupPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_PreciosLC_InfUltCompras_Mt"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Productos recepcionados"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Grilla_GRC_Ant, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel3.ResumeLayout(False)
        CType(Me.Input_Margen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DFechaTermino, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DFechaInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.SuperTabControlPanel2.ResumeLayout(False)
        CType(Me.GrillaProdActualizados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel1.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Grilla_GRC_Ant As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Actualizar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Cmb_ListaPrecio As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents DFechaTermino As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents DFechaInicio As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TabControl1 As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents SuperTabItem1 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents GrillaProdActualizados As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents SuperTabItem2 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Cmb_GRCvsUltGRC As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Filtro_Productos As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Txt_BuscaXProducto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_ListaLC As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_OfertasDinamicas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Ver_Documento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Chk_GRCconFCC As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_QuitarSeleccionados As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Input_Margen As DevComponents.Editors.IntegerInput
    Friend WithEvents Cmb_Margen As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Btn_Copiar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Procesar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_VerInformeXProductos As DevComponents.DotNetBar.ButtonItem
End Class
