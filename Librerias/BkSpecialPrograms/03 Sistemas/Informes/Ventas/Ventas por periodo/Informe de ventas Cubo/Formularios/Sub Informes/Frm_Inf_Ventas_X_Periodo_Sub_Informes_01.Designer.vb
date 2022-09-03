<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Inf_Ventas_X_Periodo_Sub_Informes_01
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Inf_Ventas_X_Periodo_Sub_Informes_01))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Informe_X_Documentos = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual = New DevComponents.DotNetBar.ButtonItem()
        Me.Lbl_Mnu_1 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Mnu_Estadisticas_Producto = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Ver_Documento = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Informeacion_Credito_Cliente = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Copiar = New DevComponents.DotNetBar.ButtonItem()
        Me.Lbl_Informes = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Informe_Clientes = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Informe_Documentos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Informe_Productos = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_Ventas = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem6 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Cotizacion = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Nota_de_venta = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_contextual_Exportar_Excel = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem8 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Exportar_Vista_Actual = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Exportar_Detalle = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Filtro_Productos = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem4 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Filtro_Entidades = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Ciudades = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Comunas = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem5 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Filtro_Responzables = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Vendedores = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem3 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Excel = New DevComponents.DotNetBar.ButtonItem()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Crear_Venta = New DevComponents.DotNetBar.ButtonItem()
        Me.Grupo_Total = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Lbl_Total_Bruto = New DevComponents.DotNetBar.LabelX()
        Me.Grupo_Impuestos = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Lbl_Total_Cantidad = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Lbl_Total_Neto = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Filtro_Abanzado = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_Total.SuspendLayout()
        Me.Grupo_Impuestos.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
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
        Me.LabelItem1.Text = "Informe detallado"
        '
        'Btn_Informe_X_Documentos
        '
        Me.Btn_Informe_X_Documentos.Image = CType(resources.GetObject("Btn_Informe_X_Documentos.Image"), System.Drawing.Image)
        Me.Btn_Informe_X_Documentos.Name = "Btn_Informe_X_Documentos"
        Me.Btn_Informe_X_Documentos.Text = "Ver detalle de los <b><font color=""#22B14C"">Documentos->Detalle</font></b>"
        '
        'GroupPanel2
        '
        Me.GroupPanel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.ContextMenuBar1)
        Me.GroupPanel2.Controls.Add(Me.Grilla)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(12, 41)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(775, 289)
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
        Me.GroupPanel2.TabIndex = 116
        Me.GroupPanel2.Text = "Documentos"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual, Me.Menu_Contextual_Ventas, Me.Menu_contextual_Exportar_Excel})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(198, 47)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(449, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 51
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual
        '
        Me.Menu_Contextual.AutoExpandOnClick = True
        Me.Menu_Contextual.Name = "Menu_Contextual"
        Me.Menu_Contextual.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Lbl_Mnu_1, Me.Btn_Mnu_Estadisticas_Producto, Me.Btn_Mnu_Ver_Documento, Me.Btn_Mnu_Informeacion_Credito_Cliente, Me.Btn_Copiar, Me.Lbl_Informes, Me.Btn_Informe_Clientes, Me.Btn_Informe_Documentos, Me.Btn_Informe_Productos})
        Me.Menu_Contextual.Text = "Opciones"
        '
        'Lbl_Mnu_1
        '
        Me.Lbl_Mnu_1.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Lbl_Mnu_1.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.Lbl_Mnu_1.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.Lbl_Mnu_1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.Lbl_Mnu_1.Name = "Lbl_Mnu_1"
        Me.Lbl_Mnu_1.PaddingBottom = 1
        Me.Lbl_Mnu_1.PaddingLeft = 10
        Me.Lbl_Mnu_1.PaddingTop = 1
        Me.Lbl_Mnu_1.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.Lbl_Mnu_1.Text = "Opciones"
        '
        'Btn_Mnu_Estadisticas_Producto
        '
        Me.Btn_Mnu_Estadisticas_Producto.Image = CType(resources.GetObject("Btn_Mnu_Estadisticas_Producto.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Estadisticas_Producto.ImageAlt = CType(resources.GetObject("Btn_Mnu_Estadisticas_Producto.ImageAlt"), System.Drawing.Image)
        Me.Btn_Mnu_Estadisticas_Producto.Name = "Btn_Mnu_Estadisticas_Producto"
        Me.Btn_Mnu_Estadisticas_Producto.Text = "Ver estadísticas del producto/información adicional"
        '
        'Btn_Mnu_Ver_Documento
        '
        Me.Btn_Mnu_Ver_Documento.Image = CType(resources.GetObject("Btn_Mnu_Ver_Documento.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Ver_Documento.ImageAlt = CType(resources.GetObject("Btn_Mnu_Ver_Documento.ImageAlt"), System.Drawing.Image)
        Me.Btn_Mnu_Ver_Documento.Name = "Btn_Mnu_Ver_Documento"
        Me.Btn_Mnu_Ver_Documento.Text = "Ver documento"
        '
        'Btn_Mnu_Informeacion_Credito_Cliente
        '
        Me.Btn_Mnu_Informeacion_Credito_Cliente.Image = CType(resources.GetObject("Btn_Mnu_Informeacion_Credito_Cliente.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Informeacion_Credito_Cliente.ImageAlt = CType(resources.GetObject("Btn_Mnu_Informeacion_Credito_Cliente.ImageAlt"), System.Drawing.Image)
        Me.Btn_Mnu_Informeacion_Credito_Cliente.Name = "Btn_Mnu_Informeacion_Credito_Cliente"
        Me.Btn_Mnu_Informeacion_Credito_Cliente.Text = "Ver información de créditos vigentes del cliente"
        '
        'Btn_Copiar
        '
        Me.Btn_Copiar.Image = CType(resources.GetObject("Btn_Copiar.Image"), System.Drawing.Image)
        Me.Btn_Copiar.ImageAlt = CType(resources.GetObject("Btn_Copiar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Copiar.Name = "Btn_Copiar"
        Me.Btn_Copiar.Text = "Copiar (portapapeles)"
        '
        'Lbl_Informes
        '
        Me.Lbl_Informes.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Lbl_Informes.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.Lbl_Informes.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.Lbl_Informes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.Lbl_Informes.Name = "Lbl_Informes"
        Me.Lbl_Informes.PaddingBottom = 1
        Me.Lbl_Informes.PaddingLeft = 10
        Me.Lbl_Informes.PaddingTop = 1
        Me.Lbl_Informes.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.Lbl_Informes.Text = "Informe detallado"
        '
        'Btn_Informe_Clientes
        '
        Me.Btn_Informe_Clientes.Image = CType(resources.GetObject("Btn_Informe_Clientes.Image"), System.Drawing.Image)
        Me.Btn_Informe_Clientes.ImageAlt = CType(resources.GetObject("Btn_Informe_Clientes.ImageAlt"), System.Drawing.Image)
        Me.Btn_Informe_Clientes.Name = "Btn_Informe_Clientes"
        Me.Btn_Informe_Clientes.Text = "Ver detalle de los <b><font color=""#22B14C"">Clientes</font></b>"
        '
        'Btn_Informe_Documentos
        '
        Me.Btn_Informe_Documentos.Image = CType(resources.GetObject("Btn_Informe_Documentos.Image"), System.Drawing.Image)
        Me.Btn_Informe_Documentos.ImageAlt = CType(resources.GetObject("Btn_Informe_Documentos.ImageAlt"), System.Drawing.Image)
        Me.Btn_Informe_Documentos.Name = "Btn_Informe_Documentos"
        Me.Btn_Informe_Documentos.Text = "Ver detalle de las <b><font color=""#22B14C"">Documentos</font></b>"
        '
        'Btn_Informe_Productos
        '
        Me.Btn_Informe_Productos.Image = CType(resources.GetObject("Btn_Informe_Productos.Image"), System.Drawing.Image)
        Me.Btn_Informe_Productos.ImageAlt = CType(resources.GetObject("Btn_Informe_Productos.ImageAlt"), System.Drawing.Image)
        Me.Btn_Informe_Productos.Name = "Btn_Informe_Productos"
        Me.Btn_Informe_Productos.Text = "Ver detalle de los <b><font color=""#22B14C"">Productos</font></b>"
        '
        'Menu_Contextual_Ventas
        '
        Me.Menu_Contextual_Ventas.AutoExpandOnClick = True
        Me.Menu_Contextual_Ventas.Name = "Menu_Contextual_Ventas"
        Me.Menu_Contextual_Ventas.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem6, Me.Btn_Cotizacion, Me.Btn_Nota_de_venta})
        Me.Menu_Contextual_Ventas.Text = "Ventas..."
        '
        'LabelItem6
        '
        Me.LabelItem6.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem6.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem6.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem6.Name = "LabelItem6"
        Me.LabelItem6.PaddingBottom = 1
        Me.LabelItem6.PaddingLeft = 10
        Me.LabelItem6.PaddingTop = 1
        Me.LabelItem6.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem6.Text = "Documentos de venta"
        '
        'Btn_Cotizacion
        '
        Me.Btn_Cotizacion.Enabled = False
        Me.Btn_Cotizacion.Image = CType(resources.GetObject("Btn_Cotizacion.Image"), System.Drawing.Image)
        Me.Btn_Cotizacion.ImageAlt = CType(resources.GetObject("Btn_Cotizacion.ImageAlt"), System.Drawing.Image)
        Me.Btn_Cotizacion.Name = "Btn_Cotizacion"
        Me.Btn_Cotizacion.Text = "COTIZACION"
        '
        'Btn_Nota_de_venta
        '
        Me.Btn_Nota_de_venta.Image = CType(resources.GetObject("Btn_Nota_de_venta.Image"), System.Drawing.Image)
        Me.Btn_Nota_de_venta.ImageAlt = CType(resources.GetObject("Btn_Nota_de_venta.ImageAlt"), System.Drawing.Image)
        Me.Btn_Nota_de_venta.Name = "Btn_Nota_de_venta"
        Me.Btn_Nota_de_venta.Text = "NOTA DE VENTA"
        '
        'Menu_contextual_Exportar_Excel
        '
        Me.Menu_contextual_Exportar_Excel.AutoExpandOnClick = True
        Me.Menu_contextual_Exportar_Excel.Name = "Menu_contextual_Exportar_Excel"
        Me.Menu_contextual_Exportar_Excel.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem8, Me.Btn_Exportar_Vista_Actual, Me.Btn_Exportar_Detalle})
        Me.Menu_contextual_Exportar_Excel.Text = "Exportar Excel"
        '
        'LabelItem8
        '
        Me.LabelItem8.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem8.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem8.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem8.Name = "LabelItem8"
        Me.LabelItem8.PaddingBottom = 1
        Me.LabelItem8.PaddingLeft = 10
        Me.LabelItem8.PaddingTop = 1
        Me.LabelItem8.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem8.Text = "Exportar datos a Excel"
        '
        'Btn_Exportar_Vista_Actual
        '
        Me.Btn_Exportar_Vista_Actual.Image = CType(resources.GetObject("Btn_Exportar_Vista_Actual.Image"), System.Drawing.Image)
        Me.Btn_Exportar_Vista_Actual.ImageAlt = CType(resources.GetObject("Btn_Exportar_Vista_Actual.ImageAlt"), System.Drawing.Image)
        Me.Btn_Exportar_Vista_Actual.Name = "Btn_Exportar_Vista_Actual"
        Me.Btn_Exportar_Vista_Actual.Text = "Exportar vista actual"
        '
        'Btn_Exportar_Detalle
        '
        Me.Btn_Exportar_Detalle.Image = CType(resources.GetObject("Btn_Exportar_Detalle.Image"), System.Drawing.Image)
        Me.Btn_Exportar_Detalle.ImageAlt = CType(resources.GetObject("Btn_Exportar_Detalle.ImageAlt"), System.Drawing.Image)
        Me.Btn_Exportar_Detalle.Name = "Btn_Exportar_Detalle"
        Me.Btn_Exportar_Detalle.Text = "Exportar detalle"
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.AllowUserToDeleteRows = False
        Me.Grilla.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
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
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
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
        Me.Grilla.RowHeadersVisible = False
        Me.Grilla.Size = New System.Drawing.Size(769, 266)
        Me.Grilla.TabIndex = 122
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
        Me.LabelItem2.Text = "Informes Agrupados"
        '
        'Btn_Filtro_Productos
        '
        Me.Btn_Filtro_Productos.Image = CType(resources.GetObject("Btn_Filtro_Productos.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Productos.Name = "Btn_Filtro_Productos"
        Me.Btn_Filtro_Productos.Text = "Filtrar por <b><font color=""#0072BC"">PRODUCTOS</font></b>"
        '
        'LabelItem4
        '
        Me.LabelItem4.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem4.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem4.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem4.Name = "LabelItem4"
        Me.LabelItem4.PaddingBottom = 1
        Me.LabelItem4.PaddingLeft = 10
        Me.LabelItem4.PaddingTop = 1
        Me.LabelItem4.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem4.Text = "Entidades"
        '
        'Btn_Filtro_Entidades
        '
        Me.Btn_Filtro_Entidades.Image = CType(resources.GetObject("Btn_Filtro_Entidades.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Entidades.Name = "Btn_Filtro_Entidades"
        Me.Btn_Filtro_Entidades.Text = "Filtrar por <b><font color=""#4E5D30""><font color=""#ED1C24"">ENTIDADES</font></font" &
    "></b>"
        '
        'Btn_Filtro_Ciudades
        '
        Me.Btn_Filtro_Ciudades.Image = CType(resources.GetObject("Btn_Filtro_Ciudades.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Ciudades.Name = "Btn_Filtro_Ciudades"
        Me.Btn_Filtro_Ciudades.Text = "Filtrar por <b><font color=""#4E5D30""><font color=""#ED1C24"">CIUDADES</font></font>" &
    "</b>"
        '
        'Btn_Filtro_Comunas
        '
        Me.Btn_Filtro_Comunas.Image = CType(resources.GetObject("Btn_Filtro_Comunas.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Comunas.Name = "Btn_Filtro_Comunas"
        Me.Btn_Filtro_Comunas.Text = "Filtrar por <b><font color=""#4E5D30""><font color=""#ED1C24"">COMUNAS</font></font><" &
    "/b>"
        '
        'LabelItem5
        '
        Me.LabelItem5.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem5.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem5.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem5.Name = "LabelItem5"
        Me.LabelItem5.PaddingBottom = 1
        Me.LabelItem5.PaddingLeft = 10
        Me.LabelItem5.PaddingTop = 1
        Me.LabelItem5.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem5.Text = "Funcionarios"
        '
        'Btn_Filtro_Responzables
        '
        Me.Btn_Filtro_Responzables.Image = CType(resources.GetObject("Btn_Filtro_Responzables.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Responzables.Name = "Btn_Filtro_Responzables"
        Me.Btn_Filtro_Responzables.Text = "Filtrar por <b><font color=""#903C39"">RESPONZABLES</font></b>"
        '
        'Btn_Filtro_Vendedores
        '
        Me.Btn_Filtro_Vendedores.Image = CType(resources.GetObject("Btn_Filtro_Vendedores.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Vendedores.Name = "Btn_Filtro_Vendedores"
        Me.Btn_Filtro_Vendedores.Text = "Filtrar por <b><font color=""#903C39"">VENDEDORES</font></b>"
        '
        'LabelItem3
        '
        Me.LabelItem3.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem3.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem3.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem3.Name = "LabelItem3"
        Me.LabelItem3.PaddingBottom = 1
        Me.LabelItem3.PaddingLeft = 10
        Me.LabelItem3.PaddingTop = 1
        Me.LabelItem3.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem3.Text = "Productos"
        '
        'Btn_Excel
        '
        Me.Btn_Excel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Excel.ForeColor = System.Drawing.Color.Black
        Me.Btn_Excel.Image = CType(resources.GetObject("Btn_Excel.Image"), System.Drawing.Image)
        Me.Btn_Excel.ImageAlt = CType(resources.GetObject("Btn_Excel.ImageAlt"), System.Drawing.Image)
        Me.Btn_Excel.Name = "Btn_Excel"
        Me.Btn_Excel.Tooltip = "Exportar a Excel"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Excel, Me.Btn_Crear_Venta})
        Me.Bar1.Location = New System.Drawing.Point(0, 400)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(798, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 115
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Crear_Venta
        '
        Me.Btn_Crear_Venta.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Crear_Venta.ForeColor = System.Drawing.Color.Black
        Me.Btn_Crear_Venta.Image = CType(resources.GetObject("Btn_Crear_Venta.Image"), System.Drawing.Image)
        Me.Btn_Crear_Venta.Name = "Btn_Crear_Venta"
        Me.Btn_Crear_Venta.Text = "CREAR VENTA"
        '
        'Grupo_Total
        '
        Me.Grupo_Total.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grupo_Total.BackColor = System.Drawing.Color.White
        Me.Grupo_Total.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Total.Controls.Add(Me.Lbl_Total_Bruto)
        Me.Grupo_Total.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Total.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Grupo_Total.Location = New System.Drawing.Point(610, 336)
        Me.Grupo_Total.Name = "Grupo_Total"
        Me.Grupo_Total.Size = New System.Drawing.Size(178, 58)
        '
        '
        '
        Me.Grupo_Total.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Total.Style.BackColorGradientAngle = 90
        Me.Grupo_Total.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Total.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Total.Style.BorderBottomWidth = 1
        Me.Grupo_Total.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Total.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Total.Style.BorderLeftWidth = 1
        Me.Grupo_Total.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Total.Style.BorderRightWidth = 1
        Me.Grupo_Total.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Total.Style.BorderTopWidth = 1
        Me.Grupo_Total.Style.CornerDiameter = 4
        Me.Grupo_Total.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Total.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Total.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Total.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Total.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Total.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Total.TabIndex = 117
        Me.Grupo_Total.Text = "Total Bruto"
        '
        'Lbl_Total_Bruto
        '
        Me.Lbl_Total_Bruto.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Total_Bruto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Total_Bruto.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Total_Bruto.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Total_Bruto.Location = New System.Drawing.Point(3, 3)
        Me.Lbl_Total_Bruto.Name = "Lbl_Total_Bruto"
        Me.Lbl_Total_Bruto.Size = New System.Drawing.Size(166, 23)
        Me.Lbl_Total_Bruto.TabIndex = 34
        Me.Lbl_Total_Bruto.Text = "0"
        Me.Lbl_Total_Bruto.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Grupo_Impuestos
        '
        Me.Grupo_Impuestos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grupo_Impuestos.BackColor = System.Drawing.Color.White
        Me.Grupo_Impuestos.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Impuestos.Controls.Add(Me.Lbl_Total_Cantidad)
        Me.Grupo_Impuestos.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Impuestos.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Grupo_Impuestos.Location = New System.Drawing.Point(263, 336)
        Me.Grupo_Impuestos.Name = "Grupo_Impuestos"
        Me.Grupo_Impuestos.Size = New System.Drawing.Size(157, 58)
        '
        '
        '
        Me.Grupo_Impuestos.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Impuestos.Style.BackColorGradientAngle = 90
        Me.Grupo_Impuestos.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Impuestos.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Impuestos.Style.BorderBottomWidth = 1
        Me.Grupo_Impuestos.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Impuestos.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Impuestos.Style.BorderLeftWidth = 1
        Me.Grupo_Impuestos.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Impuestos.Style.BorderRightWidth = 1
        Me.Grupo_Impuestos.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Impuestos.Style.BorderTopWidth = 1
        Me.Grupo_Impuestos.Style.CornerDiameter = 4
        Me.Grupo_Impuestos.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Impuestos.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Impuestos.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Impuestos.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Impuestos.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Impuestos.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Impuestos.TabIndex = 118
        Me.Grupo_Impuestos.Text = "Total Cantidad"
        '
        'Lbl_Total_Cantidad
        '
        Me.Lbl_Total_Cantidad.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Total_Cantidad.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Total_Cantidad.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Total_Cantidad.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Total_Cantidad.Location = New System.Drawing.Point(2, 4)
        Me.Lbl_Total_Cantidad.Name = "Lbl_Total_Cantidad"
        Me.Lbl_Total_Cantidad.Size = New System.Drawing.Size(146, 23)
        Me.Lbl_Total_Cantidad.TabIndex = 34
        Me.Lbl_Total_Cantidad.Text = "0"
        Me.Lbl_Total_Cantidad.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'GroupPanel1
        '
        Me.GroupPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Lbl_Total_Neto)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.GroupPanel1.Location = New System.Drawing.Point(426, 336)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(178, 58)
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
        Me.GroupPanel1.TabIndex = 119
        Me.GroupPanel1.Text = "Total Neto"
        '
        'Lbl_Total_Neto
        '
        Me.Lbl_Total_Neto.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Total_Neto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Total_Neto.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Total_Neto.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Total_Neto.Location = New System.Drawing.Point(3, 3)
        Me.Lbl_Total_Neto.Name = "Lbl_Total_Neto"
        Me.Lbl_Total_Neto.Size = New System.Drawing.Size(166, 23)
        Me.Lbl_Total_Neto.TabIndex = 34
        Me.Lbl_Total_Neto.Text = "0"
        Me.Lbl_Total_Neto.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(15, 12)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(90, 23)
        Me.LabelX1.TabIndex = 121
        Me.LabelX1.Text = "Filtro avanzado"
        '
        'Txt_Filtro_Abanzado
        '
        Me.Txt_Filtro_Abanzado.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Filtro_Abanzado.Border.Class = "TextBoxBorder"
        Me.Txt_Filtro_Abanzado.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Filtro_Abanzado.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Filtro_Abanzado.ForeColor = System.Drawing.Color.Black
        Me.Txt_Filtro_Abanzado.Location = New System.Drawing.Point(111, 12)
        Me.Txt_Filtro_Abanzado.Name = "Txt_Filtro_Abanzado"
        Me.Txt_Filtro_Abanzado.PreventEnterBeep = True
        Me.Txt_Filtro_Abanzado.Size = New System.Drawing.Size(677, 22)
        Me.Txt_Filtro_Abanzado.TabIndex = 120
        '
        'Frm_Inf_Ventas_X_Periodo_Sub_Informes_01
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(798, 441)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Txt_Filtro_Abanzado)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Grupo_Total)
        Me.Controls.Add(Me.Grupo_Impuestos)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Inf_Ventas_X_Periodo_Sub_Informes_01"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo_Total.ResumeLayout(False)
        Me.Grupo_Impuestos.ResumeLayout(False)
        Me.GroupPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Informe_X_Documentos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Lbl_Mnu_1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Mnu_Estadisticas_Producto As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_Ver_Documento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Public WithEvents Btn_Filtro_Productos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem4 As DevComponents.DotNetBar.LabelItem
    Public WithEvents Btn_Filtro_Entidades As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Ciudades As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Comunas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem5 As DevComponents.DotNetBar.LabelItem
    Public WithEvents Btn_Filtro_Responzables As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Vendedores As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem3 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Excel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Grupo_Total As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Lbl_Total_Bruto As DevComponents.DotNetBar.LabelX
    Friend WithEvents Grupo_Impuestos As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Lbl_Total_Cantidad As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Lbl_Total_Neto As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Mnu_Informeacion_Credito_Cliente As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Filtro_Abanzado As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Lbl_Informes As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Informe_Documentos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Informe_Productos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Informe_Clientes As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Crear_Venta As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Menu_Contextual_Ventas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem6 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Cotizacion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Nota_de_venta As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Copiar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Menu_contextual_Exportar_Excel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem8 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Exportar_Vista_Actual As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Exportar_Detalle As DevComponents.DotNetBar.ButtonItem
End Class
