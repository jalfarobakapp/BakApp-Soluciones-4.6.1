<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Despacho_Ordenes
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
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Despacho_Ordenes))
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Cmb_Sucursal = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Grilla_Doc_Productos = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Grilla_Documentos = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Nuevo_Despacho = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Buscar_Despacho = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Actualizar = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnExportarExcel = New DevComponents.DotNetBar.ButtonItem()
        Me.MetroStatusBar1 = New DevComponents.DotNetBar.Metro.MetroStatusBar()
        Me.Barra_Progreso = New DevComponents.DotNetBar.ProgressBarItem()
        Me.Lbl_Status = New DevComponents.DotNetBar.LabelItem()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_Productos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Ver_Despacho = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Accion_Confirmar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Accion_Preparar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Accion_Despachar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Accion_Cerrar = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla_Sub_Ordenes = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.GroupPanel4 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Grilla_Ordenes_Despacho = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.GroupPanel3.SuspendLayout()
        CType(Me.Grilla_Doc_Productos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla_Documentos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla_Sub_Ordenes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel4.SuspendLayout()
        CType(Me.Grilla_Ordenes_Despacho, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Cmb_Sucursal
        '
        Me.Cmb_Sucursal.DisplayMember = "Text"
        Me.Cmb_Sucursal.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Sucursal.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Sucursal.FormattingEnabled = True
        Me.Cmb_Sucursal.ItemHeight = 16
        Me.Cmb_Sucursal.Location = New System.Drawing.Point(579, 3)
        Me.Cmb_Sucursal.Name = "Cmb_Sucursal"
        Me.Cmb_Sucursal.Size = New System.Drawing.Size(220, 22)
        Me.Cmb_Sucursal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Sucursal.TabIndex = 148
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(523, 6)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(49, 19)
        Me.LabelX2.TabIndex = 147
        Me.LabelX2.Text = "Sucursal"
        '
        'GroupPanel3
        '
        Me.GroupPanel3.BackColor = System.Drawing.Color.White
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.Grilla_Doc_Productos)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Location = New System.Drawing.Point(7, 463)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(795, 164)
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
        Me.GroupPanel3.TabIndex = 145
        Me.GroupPanel3.Text = "Detalle de orden de despacho"
        '
        'Grilla_Doc_Productos
        '
        Me.Grilla_Doc_Productos.AllowUserToAddRows = False
        Me.Grilla_Doc_Productos.AllowUserToDeleteRows = False
        Me.Grilla_Doc_Productos.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Doc_Productos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.Grilla_Doc_Productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Doc_Productos.DefaultCellStyle = DataGridViewCellStyle14
        Me.Grilla_Doc_Productos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Doc_Productos.EnableHeadersVisualStyles = False
        Me.Grilla_Doc_Productos.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Doc_Productos.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Doc_Productos.Name = "Grilla_Doc_Productos"
        Me.Grilla_Doc_Productos.ReadOnly = True
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Doc_Productos.RowHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.Grilla_Doc_Productos.Size = New System.Drawing.Size(789, 141)
        Me.Grilla_Doc_Productos.StandardTab = True
        Me.Grilla_Doc_Productos.TabIndex = 28
        '
        'Grilla_Documentos
        '
        Me.Grilla_Documentos.AllowUserToAddRows = False
        Me.Grilla_Documentos.AllowUserToDeleteRows = False
        Me.Grilla_Documentos.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Documentos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle16
        Me.Grilla_Documentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Documentos.DefaultCellStyle = DataGridViewCellStyle17
        Me.Grilla_Documentos.EnableHeadersVisualStyles = False
        Me.Grilla_Documentos.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Documentos.Location = New System.Drawing.Point(861, 335)
        Me.Grilla_Documentos.Name = "Grilla_Documentos"
        Me.Grilla_Documentos.ReadOnly = True
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Documentos.RowHeadersDefaultCellStyle = DataGridViewCellStyle18
        Me.Grilla_Documentos.Size = New System.Drawing.Size(786, 57)
        Me.Grilla_Documentos.StandardTab = True
        Me.Grilla_Documentos.TabIndex = 27
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Nuevo_Despacho, Me.Btn_Buscar_Despacho, Me.Btn_Actualizar, Me.BtnExportarExcel})
        Me.Bar2.Location = New System.Drawing.Point(0, 633)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(812, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 142
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Nuevo_Despacho
        '
        Me.Btn_Nuevo_Despacho.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Nuevo_Despacho.ForeColor = System.Drawing.Color.Black
        Me.Btn_Nuevo_Despacho.Image = CType(resources.GetObject("Btn_Nuevo_Despacho.Image"), System.Drawing.Image)
        Me.Btn_Nuevo_Despacho.ImageAlt = CType(resources.GetObject("Btn_Nuevo_Despacho.ImageAlt"), System.Drawing.Image)
        Me.Btn_Nuevo_Despacho.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Nuevo_Despacho.Name = "Btn_Nuevo_Despacho"
        Me.Btn_Nuevo_Despacho.Tooltip = "Crear Orden de despacho"
        '
        'Btn_Buscar_Despacho
        '
        Me.Btn_Buscar_Despacho.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Buscar_Despacho.ForeColor = System.Drawing.Color.Black
        Me.Btn_Buscar_Despacho.Image = CType(resources.GetObject("Btn_Buscar_Despacho.Image"), System.Drawing.Image)
        Me.Btn_Buscar_Despacho.ImageAlt = CType(resources.GetObject("Btn_Buscar_Despacho.ImageAlt"), System.Drawing.Image)
        Me.Btn_Buscar_Despacho.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Buscar_Despacho.Name = "Btn_Buscar_Despacho"
        Me.Btn_Buscar_Despacho.Tooltip = "Buscar Orden de despacho"
        '
        'Btn_Actualizar
        '
        Me.Btn_Actualizar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Actualizar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Actualizar.Image = CType(resources.GetObject("Btn_Actualizar.Image"), System.Drawing.Image)
        Me.Btn_Actualizar.ImageAlt = CType(resources.GetObject("Btn_Actualizar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Actualizar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Actualizar.Name = "Btn_Actualizar"
        Me.Btn_Actualizar.Tooltip = "Refrescar datos"
        '
        'BtnExportarExcel
        '
        Me.BtnExportarExcel.ForeColor = System.Drawing.Color.Black
        Me.BtnExportarExcel.Image = CType(resources.GetObject("BtnExportarExcel.Image"), System.Drawing.Image)
        Me.BtnExportarExcel.ImageAlt = CType(resources.GetObject("BtnExportarExcel.ImageAlt"), System.Drawing.Image)
        Me.BtnExportarExcel.Name = "BtnExportarExcel"
        Me.BtnExportarExcel.Tooltip = "Exportar a excel (Vista actual)"
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
        Me.MetroStatusBar1.Location = New System.Drawing.Point(0, 674)
        Me.MetroStatusBar1.Name = "MetroStatusBar1"
        Me.MetroStatusBar1.Size = New System.Drawing.Size(812, 22)
        Me.MetroStatusBar1.TabIndex = 144
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
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.ContextMenuBar1)
        Me.GroupPanel1.Controls.Add(Me.Grilla_Sub_Ordenes)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(7, 294)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(795, 163)
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
        Me.GroupPanel1.TabIndex = 143
        Me.GroupPanel1.Text = "Sub-Ordenes"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_Productos})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(114, 38)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(480, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 47
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_Productos
        '
        Me.Menu_Contextual_Productos.AutoExpandOnClick = True
        Me.Menu_Contextual_Productos.Name = "Menu_Contextual_Productos"
        Me.Menu_Contextual_Productos.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Ver_Despacho, Me.Btn_Accion_Confirmar, Me.Btn_Accion_Preparar, Me.Btn_Accion_Despachar, Me.Btn_Accion_Cerrar})
        Me.Menu_Contextual_Productos.Text = "Opciones Despacho"
        '
        'Btn_Ver_Despacho
        '
        Me.Btn_Ver_Despacho.Image = CType(resources.GetObject("Btn_Ver_Despacho.Image"), System.Drawing.Image)
        Me.Btn_Ver_Despacho.ImageAlt = CType(resources.GetObject("Btn_Ver_Despacho.ImageAlt"), System.Drawing.Image)
        Me.Btn_Ver_Despacho.Name = "Btn_Ver_Despacho"
        Me.Btn_Ver_Despacho.Text = "Ver despacho"
        Me.Btn_Ver_Despacho.Tooltip = "Dar "
        '
        'Btn_Accion_Confirmar
        '
        Me.Btn_Accion_Confirmar.Image = CType(resources.GetObject("Btn_Accion_Confirmar.Image"), System.Drawing.Image)
        Me.Btn_Accion_Confirmar.ImageAlt = CType(resources.GetObject("Btn_Accion_Confirmar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Accion_Confirmar.Name = "Btn_Accion_Confirmar"
        Me.Btn_Accion_Confirmar.Text = "CONFIRMAR "
        Me.Btn_Accion_Confirmar.Tooltip = "Dar "
        '
        'Btn_Accion_Preparar
        '
        Me.Btn_Accion_Preparar.Image = CType(resources.GetObject("Btn_Accion_Preparar.Image"), System.Drawing.Image)
        Me.Btn_Accion_Preparar.ImageAlt = CType(resources.GetObject("Btn_Accion_Preparar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Accion_Preparar.Name = "Btn_Accion_Preparar"
        Me.Btn_Accion_Preparar.Text = "PREPARAR"
        Me.Btn_Accion_Preparar.Tooltip = "Preparar pedido, armar bulto"
        '
        'Btn_Accion_Despachar
        '
        Me.Btn_Accion_Despachar.Image = CType(resources.GetObject("Btn_Accion_Despachar.Image"), System.Drawing.Image)
        Me.Btn_Accion_Despachar.ImageAlt = CType(resources.GetObject("Btn_Accion_Despachar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Accion_Despachar.Name = "Btn_Accion_Despachar"
        Me.Btn_Accion_Despachar.Text = "DESPACHAR"
        Me.Btn_Accion_Despachar.Tooltip = "Despachar bultos, entregar al cliente o transportista"
        '
        'Btn_Accion_Cerrar
        '
        Me.Btn_Accion_Cerrar.Image = CType(resources.GetObject("Btn_Accion_Cerrar.Image"), System.Drawing.Image)
        Me.Btn_Accion_Cerrar.ImageAlt = CType(resources.GetObject("Btn_Accion_Cerrar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Accion_Cerrar.Name = "Btn_Accion_Cerrar"
        Me.Btn_Accion_Cerrar.Text = "CERRAR"
        Me.Btn_Accion_Cerrar.Tooltip = "Cerrar orden, insertar Nro. de encomienda"
        '
        'Grilla_Sub_Ordenes
        '
        Me.Grilla_Sub_Ordenes.AllowUserToAddRows = False
        Me.Grilla_Sub_Ordenes.AllowUserToDeleteRows = False
        Me.Grilla_Sub_Ordenes.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle19.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Sub_Ordenes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle19
        Me.Grilla_Sub_Ordenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle20.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle20.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle20.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Sub_Ordenes.DefaultCellStyle = DataGridViewCellStyle20
        Me.Grilla_Sub_Ordenes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Sub_Ordenes.EnableHeadersVisualStyles = False
        Me.Grilla_Sub_Ordenes.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Sub_Ordenes.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Sub_Ordenes.Name = "Grilla_Sub_Ordenes"
        Me.Grilla_Sub_Ordenes.ReadOnly = True
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle21.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle21.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Sub_Ordenes.RowHeadersDefaultCellStyle = DataGridViewCellStyle21
        Me.Grilla_Sub_Ordenes.Size = New System.Drawing.Size(789, 140)
        Me.Grilla_Sub_Ordenes.StandardTab = True
        Me.Grilla_Sub_Ordenes.TabIndex = 27
        '
        'GroupPanel4
        '
        Me.GroupPanel4.BackColor = System.Drawing.Color.White
        Me.GroupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel4.Controls.Add(Me.Grilla_Ordenes_Despacho)
        Me.GroupPanel4.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel4.Location = New System.Drawing.Point(7, 31)
        Me.GroupPanel4.Name = "GroupPanel4"
        Me.GroupPanel4.Size = New System.Drawing.Size(795, 257)
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
        Me.GroupPanel4.TabIndex = 154
        Me.GroupPanel4.Text = "Ordenes de despacho"
        '
        'Grilla_Ordenes_Despacho
        '
        Me.Grilla_Ordenes_Despacho.AllowUserToAddRows = False
        Me.Grilla_Ordenes_Despacho.AllowUserToDeleteRows = False
        Me.Grilla_Ordenes_Despacho.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle22.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle22.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle22.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Ordenes_Despacho.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle22
        Me.Grilla_Ordenes_Despacho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle23.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle23.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle23.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle23.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Ordenes_Despacho.DefaultCellStyle = DataGridViewCellStyle23
        Me.Grilla_Ordenes_Despacho.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Ordenes_Despacho.EnableHeadersVisualStyles = False
        Me.Grilla_Ordenes_Despacho.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Ordenes_Despacho.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Ordenes_Despacho.Name = "Grilla_Ordenes_Despacho"
        Me.Grilla_Ordenes_Despacho.ReadOnly = True
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle24.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle24.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Ordenes_Despacho.RowHeadersDefaultCellStyle = DataGridViewCellStyle24
        Me.Grilla_Ordenes_Despacho.Size = New System.Drawing.Size(789, 234)
        Me.Grilla_Ordenes_Despacho.StandardTab = True
        Me.Grilla_Ordenes_Despacho.TabIndex = 27
        '
        'Frm_Despacho_Ordenes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(812, 696)
        Me.Controls.Add(Me.GroupPanel4)
        Me.Controls.Add(Me.Grilla_Documentos)
        Me.Controls.Add(Me.Cmb_Sucursal)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.GroupPanel3)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroStatusBar1)
        Me.Controls.Add(Me.GroupPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Despacho_Ordenes"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ORDENES DE DESPACHOS"
        Me.GroupPanel3.ResumeLayout(False)
        CType(Me.Grilla_Doc_Productos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla_Documentos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla_Sub_Ordenes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel4.ResumeLayout(False)
        CType(Me.Grilla_Ordenes_Despacho, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents Cmb_Sucursal As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grilla_Doc_Productos As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Grilla_Documentos As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnExportarExcel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroStatusBar1 As DevComponents.DotNetBar.Metro.MetroStatusBar
    Friend WithEvents Barra_Progreso As DevComponents.DotNetBar.ProgressBarItem
    Friend WithEvents Lbl_Status As DevComponents.DotNetBar.LabelItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_Productos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Ver_Despacho As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Accion_Confirmar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Accion_Preparar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Accion_Despachar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Accion_Cerrar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grilla_Sub_Ordenes As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents GroupPanel4 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grilla_Ordenes_Despacho As DevComponents.DotNetBar.Controls.DataGridViewX
    Public WithEvents Btn_Nuevo_Despacho As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Buscar_Despacho As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Actualizar As DevComponents.DotNetBar.ButtonItem
End Class
