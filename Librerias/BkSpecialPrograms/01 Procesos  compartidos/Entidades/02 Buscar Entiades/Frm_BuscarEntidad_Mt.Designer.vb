<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_BuscarEntidad_Mt
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_BuscarEntidad_Mt))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.BtnCrearUser = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnEditarUser = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnEliminarUser = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Exportar_Excel = New DevComponents.DotNetBar.ButtonItem()
        Me.Rdb_Ambos = New DevComponents.DotNetBar.CheckBoxItem()
        Me.Rdb_Clientes = New DevComponents.DotNetBar.CheckBoxItem()
        Me.Rdb_Proveedores = New DevComponents.DotNetBar.CheckBoxItem()
        Me.Btn_Subir = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Bajar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Seleccionar = New DevComponents.DotNetBar.ButtonItem()
        Me.Highlighter1 = New DevComponents.DotNetBar.Validator.Highlighter()
        Me.Txtdescripcion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Mnu_Contextual = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditarEntidadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminarEntidadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.AsociarMarcaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_01 = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Editar_Entidad = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Eliminar_Entidad = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Contactos_Entidad = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Direcciones_Despacho = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla_Entidades = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TouchKeyboard1 = New DevComponents.DotNetBar.Keyboard.TouchKeyboard()
        Me.Chk_Solo_Clientes_Del_Vendedor = New DevComponents.DotNetBar.Controls.CheckBoxX()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Mnu_Contextual.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla_Entidades, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnCrearUser, Me.BtnEditarUser, Me.BtnEliminarUser, Me.Btn_Exportar_Excel, Me.Rdb_Ambos, Me.Rdb_Clientes, Me.Rdb_Proveedores, Me.Btn_Subir, Me.Btn_Bajar, Me.Btn_Seleccionar})
        Me.Bar2.Location = New System.Drawing.Point(0, 520)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(902, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 9
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'BtnCrearUser
        '
        Me.BtnCrearUser.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnCrearUser.ForeColor = System.Drawing.Color.Black
        Me.BtnCrearUser.Image = CType(resources.GetObject("BtnCrearUser.Image"), System.Drawing.Image)
        Me.BtnCrearUser.ImageAlt = CType(resources.GetObject("BtnCrearUser.ImageAlt"), System.Drawing.Image)
        Me.BtnCrearUser.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnCrearUser.Name = "BtnCrearUser"
        Me.BtnCrearUser.Tooltip = "Crear  nueva entidad"
        '
        'BtnEditarUser
        '
        Me.BtnEditarUser.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnEditarUser.ForeColor = System.Drawing.Color.Black
        Me.BtnEditarUser.Image = CType(resources.GetObject("BtnEditarUser.Image"), System.Drawing.Image)
        Me.BtnEditarUser.ImageAlt = CType(resources.GetObject("BtnEditarUser.ImageAlt"), System.Drawing.Image)
        Me.BtnEditarUser.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnEditarUser.Name = "BtnEditarUser"
        Me.BtnEditarUser.Tooltip = "Editar entidad"
        '
        'BtnEliminarUser
        '
        Me.BtnEliminarUser.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnEliminarUser.ForeColor = System.Drawing.Color.Black
        Me.BtnEliminarUser.Image = CType(resources.GetObject("BtnEliminarUser.Image"), System.Drawing.Image)
        Me.BtnEliminarUser.ImageAlt = CType(resources.GetObject("BtnEliminarUser.ImageAlt"), System.Drawing.Image)
        Me.BtnEliminarUser.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnEliminarUser.Name = "BtnEliminarUser"
        Me.BtnEliminarUser.Tooltip = "Eliminar entidad"
        '
        'Btn_Exportar_Excel
        '
        Me.Btn_Exportar_Excel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Exportar_Excel.ForeColor = System.Drawing.Color.Black
        Me.Btn_Exportar_Excel.Image = CType(resources.GetObject("Btn_Exportar_Excel.Image"), System.Drawing.Image)
        Me.Btn_Exportar_Excel.ImageAlt = CType(resources.GetObject("Btn_Exportar_Excel.ImageAlt"), System.Drawing.Image)
        Me.Btn_Exportar_Excel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Exportar_Excel.Name = "Btn_Exportar_Excel"
        Me.Btn_Exportar_Excel.Tooltip = "Crear  nueva entidad"
        Me.Btn_Exportar_Excel.Visible = False
        '
        'Rdb_Ambos
        '
        Me.Rdb_Ambos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Ambos.Checked = True
        Me.Rdb_Ambos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Ambos.Name = "Rdb_Ambos"
        Me.Rdb_Ambos.Text = "Buscar ambos"
        '
        'Rdb_Clientes
        '
        Me.Rdb_Clientes.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Clientes.Name = "Rdb_Clientes"
        Me.Rdb_Clientes.Text = "Solo clientes"
        '
        'Rdb_Proveedores
        '
        Me.Rdb_Proveedores.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Proveedores.Name = "Rdb_Proveedores"
        Me.Rdb_Proveedores.Text = "Solo proveedores"
        '
        'Btn_Subir
        '
        Me.Btn_Subir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Subir.ForeColor = System.Drawing.Color.Black
        Me.Btn_Subir.Image = CType(resources.GetObject("Btn_Subir.Image"), System.Drawing.Image)
        Me.Btn_Subir.ImageAlt = CType(resources.GetObject("Btn_Subir.ImageAlt"), System.Drawing.Image)
        Me.Btn_Subir.Name = "Btn_Subir"
        Me.Btn_Subir.Visible = False
        '
        'Btn_Bajar
        '
        Me.Btn_Bajar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Bajar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Bajar.Image = CType(resources.GetObject("Btn_Bajar.Image"), System.Drawing.Image)
        Me.Btn_Bajar.ImageAlt = CType(resources.GetObject("Btn_Bajar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Bajar.Name = "Btn_Bajar"
        Me.Btn_Bajar.Visible = False
        '
        'Btn_Seleccionar
        '
        Me.Btn_Seleccionar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Seleccionar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Seleccionar.Image = CType(resources.GetObject("Btn_Seleccionar.Image"), System.Drawing.Image)
        Me.Btn_Seleccionar.ImageAlt = CType(resources.GetObject("Btn_Seleccionar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Seleccionar.Name = "Btn_Seleccionar"
        Me.Btn_Seleccionar.Visible = False
        '
        'Highlighter1
        '
        Me.Highlighter1.ContainerControl = Me
        Me.Highlighter1.FocusHighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Green
        Me.Highlighter1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        '
        'Txtdescripcion
        '
        Me.Txtdescripcion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txtdescripcion.Border.Class = "TextBoxBorder"
        Me.Txtdescripcion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txtdescripcion.DisabledBackColor = System.Drawing.Color.White
        Me.Txtdescripcion.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightOnFocus(Me.Txtdescripcion, True)
        Me.Txtdescripcion.Location = New System.Drawing.Point(3, 13)
        Me.Txtdescripcion.Name = "Txtdescripcion"
        Me.Txtdescripcion.PreventEnterBeep = True
        Me.Txtdescripcion.Size = New System.Drawing.Size(869, 22)
        Me.Txtdescripcion.TabIndex = 0
        '
        'Mnu_Contextual
        '
        Me.Mnu_Contextual.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditarEntidadToolStripMenuItem, Me.EliminarEntidadToolStripMenuItem, Me.ToolStripSeparator1, Me.AsociarMarcaToolStripMenuItem})
        Me.Mnu_Contextual.Name = "Mnu_Contextual"
        Me.Mnu_Contextual.Size = New System.Drawing.Size(219, 76)
        '
        'EditarEntidadToolStripMenuItem
        '
        Me.EditarEntidadToolStripMenuItem.Image = CType(resources.GetObject("EditarEntidadToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EditarEntidadToolStripMenuItem.Name = "EditarEntidadToolStripMenuItem"
        Me.EditarEntidadToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.EditarEntidadToolStripMenuItem.Text = "Editar entidad"
        '
        'EliminarEntidadToolStripMenuItem
        '
        Me.EliminarEntidadToolStripMenuItem.Image = CType(resources.GetObject("EliminarEntidadToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EliminarEntidadToolStripMenuItem.Name = "EliminarEntidadToolStripMenuItem"
        Me.EliminarEntidadToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.EliminarEntidadToolStripMenuItem.Text = "Eliminar entidad"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(215, 6)
        '
        'AsociarMarcaToolStripMenuItem
        '
        Me.AsociarMarcaToolStripMenuItem.Image = CType(resources.GetObject("AsociarMarcaToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AsociarMarcaToolStripMenuItem.Name = "AsociarMarcaToolStripMenuItem"
        Me.AsociarMarcaToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.AsociarMarcaToolStripMenuItem.Text = "Asociar marcas a la entidad"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.ContextMenuBar1)
        Me.GroupPanel1.Controls.Add(Me.Grilla_Entidades)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(9, 79)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(881, 402)
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
        Me.GroupPanel1.TabIndex = 10
        Me.GroupPanel1.Text = "Seleccione la entidad con doble clic o enter sobre la línea"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_01})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(288, 37)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(153, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 54
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_01
        '
        Me.Menu_Contextual_01.AutoExpandOnClick = True
        Me.Menu_Contextual_01.Name = "Menu_Contextual_01"
        Me.Menu_Contextual_01.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Mnu_Editar_Entidad, Me.Btn_Mnu_Eliminar_Entidad, Me.LabelItem1, Me.Btn_Contactos_Entidad, Me.Btn_Direcciones_Despacho})
        Me.Menu_Contextual_01.Text = "Opciones"
        '
        'Btn_Mnu_Editar_Entidad
        '
        Me.Btn_Mnu_Editar_Entidad.Image = CType(resources.GetObject("Btn_Mnu_Editar_Entidad.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Editar_Entidad.ImageAlt = CType(resources.GetObject("Btn_Mnu_Editar_Entidad.ImageAlt"), System.Drawing.Image)
        Me.Btn_Mnu_Editar_Entidad.Name = "Btn_Mnu_Editar_Entidad"
        Me.Btn_Mnu_Editar_Entidad.Text = "Editar fila"
        '
        'Btn_Mnu_Eliminar_Entidad
        '
        Me.Btn_Mnu_Eliminar_Entidad.Image = CType(resources.GetObject("Btn_Mnu_Eliminar_Entidad.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Eliminar_Entidad.ImageAlt = CType(resources.GetObject("Btn_Mnu_Eliminar_Entidad.ImageAlt"), System.Drawing.Image)
        Me.Btn_Mnu_Eliminar_Entidad.Name = "Btn_Mnu_Eliminar_Entidad"
        Me.Btn_Mnu_Eliminar_Entidad.Text = "Eliminar fila"
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
        Me.LabelItem1.Text = "Otras opciones"
        '
        'Btn_Contactos_Entidad
        '
        Me.Btn_Contactos_Entidad.Image = CType(resources.GetObject("Btn_Contactos_Entidad.Image"), System.Drawing.Image)
        Me.Btn_Contactos_Entidad.ImageAlt = CType(resources.GetObject("Btn_Contactos_Entidad.ImageAlt"), System.Drawing.Image)
        Me.Btn_Contactos_Entidad.Name = "Btn_Contactos_Entidad"
        Me.Btn_Contactos_Entidad.Text = "Contactos de la entidad"
        '
        'Btn_Direcciones_Despacho
        '
        Me.Btn_Direcciones_Despacho.Image = CType(resources.GetObject("Btn_Direcciones_Despacho.Image"), System.Drawing.Image)
        Me.Btn_Direcciones_Despacho.ImageAlt = CType(resources.GetObject("Btn_Direcciones_Despacho.ImageAlt"), System.Drawing.Image)
        Me.Btn_Direcciones_Despacho.Name = "Btn_Direcciones_Despacho"
        Me.Btn_Direcciones_Despacho.Text = "Direcciones de despacho"
        '
        'Grilla_Entidades
        '
        Me.Grilla_Entidades.AllowUserToAddRows = False
        Me.Grilla_Entidades.AllowUserToDeleteRows = False
        Me.Grilla_Entidades.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Entidades.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grilla_Entidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Entidades.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grilla_Entidades.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Entidades.EnableHeadersVisualStyles = False
        Me.Grilla_Entidades.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Entidades.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Entidades.Name = "Grilla_Entidades"
        Me.Grilla_Entidades.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Entidades.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla_Entidades.Size = New System.Drawing.Size(875, 379)
        Me.Grilla_Entidades.StandardTab = True
        Me.Grilla_Entidades.TabIndex = 53
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Txtdescripcion)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(9, 12)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(881, 61)
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
        Me.GroupPanel2.TabIndex = 11
        Me.GroupPanel2.Text = "Filtro. Ingrese algo del rut, código o descripción de la entidad"
        '
        'TouchKeyboard1
        '
        Me.TouchKeyboard1.FloatingLocation = New System.Drawing.Point(0, 0)
        Me.TouchKeyboard1.FloatingSize = New System.Drawing.Size(740, 250)
        Me.TouchKeyboard1.Location = New System.Drawing.Point(0, 0)
        Me.TouchKeyboard1.Size = New System.Drawing.Size(740, 250)
        Me.TouchKeyboard1.Text = ""
        '
        'Chk_Solo_Clientes_Del_Vendedor
        '
        Me.Chk_Solo_Clientes_Del_Vendedor.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Solo_Clientes_Del_Vendedor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Solo_Clientes_Del_Vendedor.FocusCuesEnabled = False
        Me.Chk_Solo_Clientes_Del_Vendedor.ForeColor = System.Drawing.Color.Black
        Me.Chk_Solo_Clientes_Del_Vendedor.Location = New System.Drawing.Point(9, 487)
        Me.Chk_Solo_Clientes_Del_Vendedor.Name = "Chk_Solo_Clientes_Del_Vendedor"
        Me.Chk_Solo_Clientes_Del_Vendedor.Size = New System.Drawing.Size(195, 23)
        Me.Chk_Solo_Clientes_Del_Vendedor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Solo_Clientes_Del_Vendedor.TabIndex = 12
        Me.Chk_Solo_Clientes_Del_Vendedor.Text = "Ver solo clientes del usuario activo"
        '
        'Frm_BuscarEntidad_Mt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(902, 561)
        Me.Controls.Add(Me.Chk_Solo_Clientes_Del_Vendedor)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.GroupPanel2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_BuscarEntidad_Mt"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Busqueda de Entidades"
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Mnu_Contextual.ResumeLayout(False)
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla_Entidades, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnCrearUser As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnEditarUser As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnEliminarUser As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Highlighter1 As DevComponents.DotNetBar.Validator.Highlighter
    Friend WithEvents Mnu_Contextual As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditarEntidadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EliminarEntidadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AsociarMarcaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Rdb_Ambos As DevComponents.DotNetBar.CheckBoxItem
    Public WithEvents Rdb_Clientes As DevComponents.DotNetBar.CheckBoxItem
    Public WithEvents Rdb_Proveedores As DevComponents.DotNetBar.CheckBoxItem
    Public WithEvents Btn_Bajar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Subir As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Seleccionar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents TouchKeyboard1 As DevComponents.DotNetBar.Keyboard.TouchKeyboard
    Public WithEvents Txtdescripcion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Chk_Solo_Clientes_Del_Vendedor As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Grilla_Entidades As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_01 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_Editar_Entidad As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_Eliminar_Entidad As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Exportar_Excel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Contactos_Entidad As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Direcciones_Despacho As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
End Class
