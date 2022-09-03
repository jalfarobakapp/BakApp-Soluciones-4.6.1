<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Trazabilidad_documento
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Trazabilidad_documento))
        Me.labelZoom = New System.Windows.Forms.Label()
        Me.treeGX1 = New DevComponents.Tree.TreeGX()
        Me.nodeConnector2 = New DevComponents.Tree.NodeConnector()
        Me.nodeStyle = New DevComponents.Tree.ElementStyle()
        Me.nodeConnector1 = New DevComponents.Tree.NodeConnector()
        Me.styleClass = New DevComponents.Tree.ElementStyle()
        Me.label1 = New System.Windows.Forms.Label()
        Me.trackBar1 = New System.Windows.Forms.TrackBar()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_Encabezado = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Ver_documento = New DevComponents.DotNetBar.ButtonItem()
        Me.button1 = New System.Windows.Forms.Button()
        Me.buttonPrint = New System.Windows.Forms.Button()
        Me.comboLayoutType = New System.Windows.Forms.ComboBox()
        Me.comboLayout = New System.Windows.Forms.ComboBox()
        Me.Lista_Imagenes_32 = New System.Windows.Forms.ImageList()
        Me.Lista_Imagenes_16 = New System.Windows.Forms.ImageList()
        Me.printDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.saveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.printPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.node1 = New DevComponents.Tree.Node()
        Me.ElementStyle13 = New DevComponents.Tree.ElementStyle()
        Me.Lista_Imagnes_Pago_16 = New System.Windows.Forms.ImageList()
        Me.ElementStyle1 = New DevComponents.Tree.ElementStyle()
        Me.ElementStyle2 = New DevComponents.Tree.ElementStyle()
        Me.ElementStyle3 = New DevComponents.Tree.ElementStyle()
        Me.ElementStyle4 = New DevComponents.Tree.ElementStyle()
        Me.ElementStyle5 = New DevComponents.Tree.ElementStyle()
        Me.ElementStyle6 = New DevComponents.Tree.ElementStyle()
        Me.ElementStyle7 = New DevComponents.Tree.ElementStyle()
        Me.ElementStyle8 = New DevComponents.Tree.ElementStyle()
        Me.ElementStyle9 = New DevComponents.Tree.ElementStyle()
        Me.ElementStyle10 = New DevComponents.Tree.ElementStyle()
        Me.ElementStyle11 = New DevComponents.Tree.ElementStyle()
        Me.ElementStyle12 = New DevComponents.Tree.ElementStyle()
        CType(Me.treeGX1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel1.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'labelZoom
        '
        Me.labelZoom.BackColor = System.Drawing.Color.Transparent
        Me.labelZoom.ForeColor = System.Drawing.Color.Black
        Me.labelZoom.Location = New System.Drawing.Point(472, 9)
        Me.labelZoom.Name = "labelZoom"
        Me.labelZoom.Size = New System.Drawing.Size(37, 15)
        Me.labelZoom.TabIndex = 2
        Me.labelZoom.Text = "100%"
        '
        'treeGX1
        '
        Me.treeGX1.AllowDrop = True
        Me.treeGX1.AutoScrollMinSize = New System.Drawing.Size(44, 22)
        Me.treeGX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.treeGX1.BackgroundStyle.BackColor2 = System.Drawing.Color.White
        Me.treeGX1.BackgroundStyle.BackColorGradientAngle = 90
        Me.treeGX1.BackgroundStyle.BackColorSchemePart = DevComponents.Tree.eColorSchemePart.MenuBackground
        Me.treeGX1.CommandBackColorGradientAngle = 90
        Me.treeGX1.CommandMouseOverBackColor2SchemePart = DevComponents.Tree.eColorSchemePart.ItemHotBackground2
        Me.treeGX1.CommandMouseOverBackColorGradientAngle = 90
        Me.treeGX1.DiagramLayoutFlow = DevComponents.Tree.eDiagramFlow.TopToBottom
        Me.treeGX1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.treeGX1.ExpandLineColorSchemePart = DevComponents.Tree.eColorSchemePart.BarDockedBorder
        Me.treeGX1.ForeColor = System.Drawing.Color.Black
        Me.treeGX1.LicenseKey = "EB364C34-3CE3-4cd6-BB1B-13513ABE0D62"
        Me.treeGX1.Location = New System.Drawing.Point(0, 63)
        Me.treeGX1.MapLayoutFlow = DevComponents.Tree.eMapFlow.BottomToTop
        Me.treeGX1.Name = "treeGX1"
        Me.treeGX1.NodesConnector = Me.nodeConnector2
        Me.treeGX1.NodeStyle = Me.nodeStyle
        Me.treeGX1.NodeVerticalSpacing = 8
        Me.treeGX1.PathSeparator = ";"
        Me.treeGX1.RootConnector = Me.nodeConnector1
        Me.treeGX1.Size = New System.Drawing.Size(653, 373)
        Me.treeGX1.Styles.Add(Me.nodeStyle)
        Me.treeGX1.Styles.Add(Me.styleClass)
        Me.treeGX1.SuspendPaint = False
        Me.treeGX1.TabIndex = 3
        Me.treeGX1.Text = "treeGX1"
        '
        'nodeConnector2
        '
        Me.nodeConnector2.LineWidth = 5
        '
        'nodeStyle
        '
        Me.nodeStyle.BackColor2SchemePart = DevComponents.Tree.eColorSchemePart.BarBackground2
        Me.nodeStyle.BackColorGradientAngle = 90
        Me.nodeStyle.BackColorSchemePart = DevComponents.Tree.eColorSchemePart.BarBackground
        Me.nodeStyle.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid
        Me.nodeStyle.BorderBottomWidth = 1
        Me.nodeStyle.BorderColorSchemePart = DevComponents.Tree.eColorSchemePart.BarDockedBorder
        Me.nodeStyle.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid
        Me.nodeStyle.BorderLeftWidth = 1
        Me.nodeStyle.BorderRight = DevComponents.Tree.eStyleBorderType.Solid
        Me.nodeStyle.BorderRightWidth = 1
        Me.nodeStyle.BorderTop = DevComponents.Tree.eStyleBorderType.Solid
        Me.nodeStyle.BorderTopWidth = 1
        Me.nodeStyle.CornerDiameter = 4
        Me.nodeStyle.CornerType = DevComponents.Tree.eCornerType.Rounded
        Me.nodeStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nodeStyle.Name = "nodeStyle"
        Me.nodeStyle.PaddingBottom = 4
        Me.nodeStyle.PaddingLeft = 4
        Me.nodeStyle.PaddingRight = 4
        Me.nodeStyle.PaddingTop = 4
        Me.nodeStyle.TextColor = System.Drawing.SystemColors.ControlText
        '
        'nodeConnector1
        '
        Me.nodeConnector1.LineWidth = 5
        '
        'styleClass
        '
        Me.styleClass.BackColor2SchemePart = DevComponents.Tree.eColorSchemePart.ItemHotBackground2
        Me.styleClass.BackColorGradientAngle = 90
        Me.styleClass.BackColorSchemePart = DevComponents.Tree.eColorSchemePart.ItemHotBackground
        Me.styleClass.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid
        Me.styleClass.BorderBottomWidth = 1
        Me.styleClass.BorderColorSchemePart = DevComponents.Tree.eColorSchemePart.ItemHotBorder
        Me.styleClass.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid
        Me.styleClass.BorderLeftWidth = 1
        Me.styleClass.BorderRight = DevComponents.Tree.eStyleBorderType.Solid
        Me.styleClass.BorderRightWidth = 1
        Me.styleClass.BorderTop = DevComponents.Tree.eStyleBorderType.Solid
        Me.styleClass.BorderTopWidth = 1
        Me.styleClass.CornerDiameter = 4
        Me.styleClass.CornerType = DevComponents.Tree.eCornerType.Rounded
        Me.styleClass.Name = "styleClass"
        Me.styleClass.PaddingBottom = 4
        Me.styleClass.PaddingLeft = 4
        Me.styleClass.PaddingRight = 4
        Me.styleClass.PaddingTop = 4
        Me.styleClass.TextColorSchemePart = DevComponents.Tree.eColorSchemePart.ItemHotText
        '
        'label1
        '
        Me.label1.BackColor = System.Drawing.Color.Transparent
        Me.label1.ForeColor = System.Drawing.Color.Black
        Me.label1.Location = New System.Drawing.Point(437, 8)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(37, 15)
        Me.label1.TabIndex = 1
        Me.label1.Text = "Zoom: "
        '
        'trackBar1
        '
        Me.trackBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.trackBar1.AutoSize = False
        Me.trackBar1.BackColor = System.Drawing.Color.White
        Me.trackBar1.LargeChange = 50
        Me.trackBar1.Location = New System.Drawing.Point(515, 4)
        Me.trackBar1.Maximum = 400
        Me.trackBar1.Minimum = 30
        Me.trackBar1.Name = "trackBar1"
        Me.trackBar1.Size = New System.Drawing.Size(134, 24)
        Me.trackBar1.SmallChange = 10
        Me.trackBar1.TabIndex = 0
        Me.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None
        Me.trackBar1.Value = 100
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.panel1.Controls.Add(Me.ContextMenuBar1)
        Me.panel1.Controls.Add(Me.button1)
        Me.panel1.Controls.Add(Me.buttonPrint)
        Me.panel1.Controls.Add(Me.comboLayoutType)
        Me.panel1.Controls.Add(Me.comboLayout)
        Me.panel1.Controls.Add(Me.labelZoom)
        Me.panel1.Controls.Add(Me.label1)
        Me.panel1.Controls.Add(Me.trackBar1)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel1.ForeColor = System.Drawing.Color.Black
        Me.panel1.Location = New System.Drawing.Point(0, 0)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(653, 63)
        Me.panel1.TabIndex = 4
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.DockSide = DevComponents.DotNetBar.eDockSide.Top
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_Encabezado})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(12, 34)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(512, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 47
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_Encabezado
        '
        Me.Menu_Contextual_Encabezado.AutoExpandOnClick = True
        Me.Menu_Contextual_Encabezado.Name = "Menu_Contextual_Encabezado"
        Me.Menu_Contextual_Encabezado.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Ver_documento})
        Me.Menu_Contextual_Encabezado.Text = "Opciones encabezado"
        '
        'Btn_Ver_documento
        '
        Me.Btn_Ver_documento.Image = CType(resources.GetObject("Btn_Ver_documento.Image"), System.Drawing.Image)
        Me.Btn_Ver_documento.Name = "Btn_Ver_documento"
        Me.Btn_Ver_documento.Text = "Ver documento"
        '
        'button1
        '
        Me.button1.BackColor = System.Drawing.Color.White
        Me.button1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.button1.ForeColor = System.Drawing.Color.Black
        Me.button1.Location = New System.Drawing.Point(65, 4)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(69, 22)
        Me.button1.TabIndex = 6
        Me.button1.Text = "Save Image"
        Me.button1.UseVisualStyleBackColor = False
        '
        'buttonPrint
        '
        Me.buttonPrint.BackColor = System.Drawing.Color.White
        Me.buttonPrint.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.buttonPrint.ForeColor = System.Drawing.Color.Black
        Me.buttonPrint.Location = New System.Drawing.Point(3, 4)
        Me.buttonPrint.Name = "buttonPrint"
        Me.buttonPrint.Size = New System.Drawing.Size(56, 22)
        Me.buttonPrint.TabIndex = 5
        Me.buttonPrint.Text = "Print"
        Me.buttonPrint.UseVisualStyleBackColor = False
        '
        'comboLayoutType
        '
        Me.comboLayoutType.BackColor = System.Drawing.Color.White
        Me.comboLayoutType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboLayoutType.ForeColor = System.Drawing.Color.Black
        Me.comboLayoutType.Location = New System.Drawing.Point(326, 4)
        Me.comboLayoutType.Name = "comboLayoutType"
        Me.comboLayoutType.Size = New System.Drawing.Size(93, 21)
        Me.comboLayoutType.TabIndex = 4
        '
        'comboLayout
        '
        Me.comboLayout.BackColor = System.Drawing.Color.White
        Me.comboLayout.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboLayout.ForeColor = System.Drawing.Color.Black
        Me.comboLayout.Location = New System.Drawing.Point(220, 4)
        Me.comboLayout.Name = "comboLayout"
        Me.comboLayout.Size = New System.Drawing.Size(100, 21)
        Me.comboLayout.TabIndex = 3
        '
        'Lista_Imagenes_32
        '
        Me.Lista_Imagenes_32.ImageStream = CType(resources.GetObject("Lista_Imagenes_32.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Lista_Imagenes_32.TransparentColor = System.Drawing.Color.Transparent
        Me.Lista_Imagenes_32.Images.SetKeyName(0, "document_text.png")
        Me.Lista_Imagenes_32.Images.SetKeyName(1, "tag_price.png")
        Me.Lista_Imagenes_32.Images.SetKeyName(2, "Boleta")
        Me.Lista_Imagenes_32.Images.SetKeyName(3, "Notadecredito")
        Me.Lista_Imagenes_32.Images.SetKeyName(4, "Guia")
        Me.Lista_Imagenes_32.Images.SetKeyName(5, "Factura")
        Me.Lista_Imagenes_32.Images.SetKeyName(6, "Ordendetrabajo")
        '
        'Lista_Imagenes_16
        '
        Me.Lista_Imagenes_16.ImageStream = CType(resources.GetObject("Lista_Imagenes_16.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Lista_Imagenes_16.TransparentColor = System.Drawing.Color.Transparent
        Me.Lista_Imagenes_16.Images.SetKeyName(0, "shipment.png")
        Me.Lista_Imagenes_16.Images.SetKeyName(1, "list.png")
        Me.Lista_Imagenes_16.Images.SetKeyName(2, "package-arrow_left.png")
        Me.Lista_Imagenes_16.Images.SetKeyName(3, "package-arrow_right.png")
        Me.Lista_Imagenes_16.Images.SetKeyName(4, "security_lock.png")
        Me.Lista_Imagenes_16.Images.SetKeyName(5, "security_unlock.png")
        '
        'printDocument1
        '
        Me.printDocument1.OriginAtMargins = True
        '
        'saveFileDialog1
        '
        Me.saveFileDialog1.DefaultExt = "png"
        Me.saveFileDialog1.Filter = "PNG Files | *.png"
        Me.saveFileDialog1.Title = "Save TreeGX control content to image"
        '
        'printPreviewDialog1
        '
        Me.printPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.printPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.printPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.printPreviewDialog1.Document = Me.printDocument1
        Me.printPreviewDialog1.Enabled = True
        Me.printPreviewDialog1.Icon = CType(resources.GetObject("printPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.printPreviewDialog1.Name = "printPreviewDialog1"
        Me.printPreviewDialog1.UseAntiAlias = True
        Me.printPreviewDialog1.Visible = False
        '
        'node1
        '
        Me.node1.Expanded = True
        Me.node1.Name = "node1"
        Me.node1.Style = Me.ElementStyle13
        Me.node1.Text = "node1"
        '
        'ElementStyle13
        '
        Me.ElementStyle13.BackColor = System.Drawing.Color.White
        Me.ElementStyle13.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.ElementStyle13.BackColorGradientAngle = 90
        Me.ElementStyle13.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid
        Me.ElementStyle13.BorderBottomWidth = 1
        Me.ElementStyle13.BorderColor = System.Drawing.Color.DarkGray
        Me.ElementStyle13.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid
        Me.ElementStyle13.BorderLeftWidth = 1
        Me.ElementStyle13.BorderRight = DevComponents.Tree.eStyleBorderType.Solid
        Me.ElementStyle13.BorderRightWidth = 1
        Me.ElementStyle13.BorderTop = DevComponents.Tree.eStyleBorderType.Solid
        Me.ElementStyle13.BorderTopWidth = 1
        Me.ElementStyle13.CornerDiameter = 4
        Me.ElementStyle13.CornerType = DevComponents.Tree.eCornerType.Rounded
        Me.ElementStyle13.Description = "Gray"
        Me.ElementStyle13.Name = "ElementStyle13"
        Me.ElementStyle13.PaddingBottom = 3
        Me.ElementStyle13.PaddingLeft = 3
        Me.ElementStyle13.PaddingRight = 3
        Me.ElementStyle13.PaddingTop = 3
        Me.ElementStyle13.TextColor = System.Drawing.Color.Black
        '
        'Lista_Imagnes_Pago_16
        '
        Me.Lista_Imagnes_Pago_16.ImageStream = CType(resources.GetObject("Lista_Imagnes_Pago_16.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Lista_Imagnes_Pago_16.TransparentColor = System.Drawing.Color.Transparent
        Me.Lista_Imagnes_Pago_16.Images.SetKeyName(0, "money.png")
        Me.Lista_Imagnes_Pago_16.Images.SetKeyName(1, "check.png")
        Me.Lista_Imagnes_Pago_16.Images.SetKeyName(2, "credit_card.png")
        Me.Lista_Imagnes_Pago_16.Images.SetKeyName(3, "stock_exchange.png")
        Me.Lista_Imagnes_Pago_16.Images.SetKeyName(4, "quote.png")
        Me.Lista_Imagnes_Pago_16.Images.SetKeyName(5, "document_text.png")
        Me.Lista_Imagnes_Pago_16.Images.SetKeyName(6, "invoice-to_check.png")
        Me.Lista_Imagnes_Pago_16.Images.SetKeyName(7, "money_banknote-info.png")
        Me.Lista_Imagnes_Pago_16.Images.SetKeyName(8, "tag_price.png")
        '
        'ElementStyle1
        '
        Me.ElementStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ElementStyle1.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.ElementStyle1.BackColorGradientAngle = 90
        Me.ElementStyle1.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid
        Me.ElementStyle1.BorderBottomWidth = 1
        Me.ElementStyle1.BorderColor = System.Drawing.Color.DarkGray
        Me.ElementStyle1.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid
        Me.ElementStyle1.BorderLeftWidth = 1
        Me.ElementStyle1.BorderRight = DevComponents.Tree.eStyleBorderType.Solid
        Me.ElementStyle1.BorderRightWidth = 1
        Me.ElementStyle1.BorderTop = DevComponents.Tree.eStyleBorderType.Solid
        Me.ElementStyle1.BorderTopWidth = 1
        Me.ElementStyle1.CornerDiameter = 4
        Me.ElementStyle1.CornerType = DevComponents.Tree.eCornerType.Rounded
        Me.ElementStyle1.Description = "Blue"
        Me.ElementStyle1.Name = "ElementStyle1"
        Me.ElementStyle1.PaddingBottom = 3
        Me.ElementStyle1.PaddingLeft = 3
        Me.ElementStyle1.PaddingRight = 3
        Me.ElementStyle1.PaddingTop = 3
        Me.ElementStyle1.TextColor = System.Drawing.Color.Black
        '
        'ElementStyle2
        '
        Me.ElementStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.ElementStyle2.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.ElementStyle2.BackColorGradientAngle = 90
        Me.ElementStyle2.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid
        Me.ElementStyle2.BorderBottomWidth = 1
        Me.ElementStyle2.BorderColor = System.Drawing.Color.DarkGray
        Me.ElementStyle2.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid
        Me.ElementStyle2.BorderLeftWidth = 1
        Me.ElementStyle2.BorderRight = DevComponents.Tree.eStyleBorderType.Solid
        Me.ElementStyle2.BorderRightWidth = 1
        Me.ElementStyle2.BorderTop = DevComponents.Tree.eStyleBorderType.Solid
        Me.ElementStyle2.BorderTopWidth = 1
        Me.ElementStyle2.CornerDiameter = 4
        Me.ElementStyle2.CornerType = DevComponents.Tree.eCornerType.Rounded
        Me.ElementStyle2.Description = "Yellow"
        Me.ElementStyle2.Name = "ElementStyle2"
        Me.ElementStyle2.PaddingBottom = 3
        Me.ElementStyle2.PaddingLeft = 3
        Me.ElementStyle2.PaddingRight = 3
        Me.ElementStyle2.PaddingTop = 3
        Me.ElementStyle2.TextColor = System.Drawing.Color.Black
        '
        'ElementStyle3
        '
        Me.ElementStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.ElementStyle3.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(183, Byte), Integer), CType(CType(201, Byte), Integer), CType(CType(151, Byte), Integer))
        Me.ElementStyle3.BackColorGradientAngle = 90
        Me.ElementStyle3.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid
        Me.ElementStyle3.BorderBottomWidth = 1
        Me.ElementStyle3.BorderColor = System.Drawing.Color.DarkGray
        Me.ElementStyle3.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid
        Me.ElementStyle3.BorderLeftWidth = 1
        Me.ElementStyle3.BorderRight = DevComponents.Tree.eStyleBorderType.Solid
        Me.ElementStyle3.BorderRightWidth = 1
        Me.ElementStyle3.BorderTop = DevComponents.Tree.eStyleBorderType.Solid
        Me.ElementStyle3.BorderTopWidth = 1
        Me.ElementStyle3.CornerDiameter = 4
        Me.ElementStyle3.CornerType = DevComponents.Tree.eCornerType.Rounded
        Me.ElementStyle3.Description = "Green"
        Me.ElementStyle3.Name = "ElementStyle3"
        Me.ElementStyle3.PaddingBottom = 3
        Me.ElementStyle3.PaddingLeft = 3
        Me.ElementStyle3.PaddingRight = 3
        Me.ElementStyle3.PaddingTop = 3
        Me.ElementStyle3.TextColor = System.Drawing.Color.Black
        '
        'ElementStyle4
        '
        Me.ElementStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.ElementStyle4.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(151, Byte), Integer))
        Me.ElementStyle4.BackColorGradientAngle = 90
        Me.ElementStyle4.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid
        Me.ElementStyle4.BorderBottomWidth = 1
        Me.ElementStyle4.BorderColor = System.Drawing.Color.DarkGray
        Me.ElementStyle4.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid
        Me.ElementStyle4.BorderLeftWidth = 1
        Me.ElementStyle4.BorderRight = DevComponents.Tree.eStyleBorderType.Solid
        Me.ElementStyle4.BorderRightWidth = 1
        Me.ElementStyle4.BorderTop = DevComponents.Tree.eStyleBorderType.Solid
        Me.ElementStyle4.BorderTopWidth = 1
        Me.ElementStyle4.CornerDiameter = 4
        Me.ElementStyle4.CornerType = DevComponents.Tree.eCornerType.Rounded
        Me.ElementStyle4.Description = "Red"
        Me.ElementStyle4.Name = "ElementStyle4"
        Me.ElementStyle4.PaddingBottom = 3
        Me.ElementStyle4.PaddingLeft = 3
        Me.ElementStyle4.PaddingRight = 3
        Me.ElementStyle4.PaddingTop = 3
        Me.ElementStyle4.TextColor = System.Drawing.Color.Black
        '
        'ElementStyle5
        '
        Me.ElementStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.ElementStyle5.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.ElementStyle5.BackColorGradientAngle = 90
        Me.ElementStyle5.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid
        Me.ElementStyle5.BorderBottomWidth = 1
        Me.ElementStyle5.BorderColor = System.Drawing.Color.DarkGray
        Me.ElementStyle5.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid
        Me.ElementStyle5.BorderLeftWidth = 1
        Me.ElementStyle5.BorderRight = DevComponents.Tree.eStyleBorderType.Solid
        Me.ElementStyle5.BorderRightWidth = 1
        Me.ElementStyle5.BorderTop = DevComponents.Tree.eStyleBorderType.Solid
        Me.ElementStyle5.BorderTopWidth = 1
        Me.ElementStyle5.CornerDiameter = 4
        Me.ElementStyle5.CornerType = DevComponents.Tree.eCornerType.Rounded
        Me.ElementStyle5.Description = "Purple"
        Me.ElementStyle5.Name = "ElementStyle5"
        Me.ElementStyle5.PaddingBottom = 3
        Me.ElementStyle5.PaddingLeft = 3
        Me.ElementStyle5.PaddingRight = 3
        Me.ElementStyle5.PaddingTop = 3
        Me.ElementStyle5.TextColor = System.Drawing.Color.Black
        '
        'ElementStyle6
        '
        Me.ElementStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.ElementStyle6.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.ElementStyle6.BackColorGradientAngle = 90
        Me.ElementStyle6.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid
        Me.ElementStyle6.BorderBottomWidth = 1
        Me.ElementStyle6.BorderColor = System.Drawing.Color.DarkGray
        Me.ElementStyle6.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid
        Me.ElementStyle6.BorderLeftWidth = 1
        Me.ElementStyle6.BorderRight = DevComponents.Tree.eStyleBorderType.Solid
        Me.ElementStyle6.BorderRightWidth = 1
        Me.ElementStyle6.BorderTop = DevComponents.Tree.eStyleBorderType.Solid
        Me.ElementStyle6.BorderTopWidth = 1
        Me.ElementStyle6.CornerDiameter = 4
        Me.ElementStyle6.CornerType = DevComponents.Tree.eCornerType.Rounded
        Me.ElementStyle6.Description = "Cyan"
        Me.ElementStyle6.Name = "ElementStyle6"
        Me.ElementStyle6.PaddingBottom = 3
        Me.ElementStyle6.PaddingLeft = 3
        Me.ElementStyle6.PaddingRight = 3
        Me.ElementStyle6.PaddingTop = 3
        Me.ElementStyle6.TextColor = System.Drawing.Color.Black
        '
        'ElementStyle7
        '
        Me.ElementStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.ElementStyle7.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.ElementStyle7.BackColorGradientAngle = 90
        Me.ElementStyle7.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid
        Me.ElementStyle7.BorderBottomWidth = 1
        Me.ElementStyle7.BorderColor = System.Drawing.Color.DarkGray
        Me.ElementStyle7.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid
        Me.ElementStyle7.BorderLeftWidth = 1
        Me.ElementStyle7.BorderRight = DevComponents.Tree.eStyleBorderType.Solid
        Me.ElementStyle7.BorderRightWidth = 1
        Me.ElementStyle7.BorderTop = DevComponents.Tree.eStyleBorderType.Solid
        Me.ElementStyle7.BorderTopWidth = 1
        Me.ElementStyle7.CornerDiameter = 4
        Me.ElementStyle7.CornerType = DevComponents.Tree.eCornerType.Rounded
        Me.ElementStyle7.Description = "Orange"
        Me.ElementStyle7.Name = "ElementStyle7"
        Me.ElementStyle7.PaddingBottom = 3
        Me.ElementStyle7.PaddingLeft = 3
        Me.ElementStyle7.PaddingRight = 3
        Me.ElementStyle7.PaddingTop = 3
        Me.ElementStyle7.TextColor = System.Drawing.Color.Black
        '
        'ElementStyle8
        '
        Me.ElementStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.ElementStyle8.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(187, Byte), Integer))
        Me.ElementStyle8.BackColorGradientAngle = 90
        Me.ElementStyle8.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid
        Me.ElementStyle8.BorderBottomWidth = 1
        Me.ElementStyle8.BorderColor = System.Drawing.Color.DarkGray
        Me.ElementStyle8.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid
        Me.ElementStyle8.BorderLeftWidth = 1
        Me.ElementStyle8.BorderRight = DevComponents.Tree.eStyleBorderType.Solid
        Me.ElementStyle8.BorderRightWidth = 1
        Me.ElementStyle8.BorderTop = DevComponents.Tree.eStyleBorderType.Solid
        Me.ElementStyle8.BorderTopWidth = 1
        Me.ElementStyle8.CornerDiameter = 4
        Me.ElementStyle8.CornerType = DevComponents.Tree.eCornerType.Rounded
        Me.ElementStyle8.Description = "Magenta"
        Me.ElementStyle8.Name = "ElementStyle8"
        Me.ElementStyle8.PaddingBottom = 3
        Me.ElementStyle8.PaddingLeft = 3
        Me.ElementStyle8.PaddingRight = 3
        Me.ElementStyle8.PaddingTop = 3
        Me.ElementStyle8.TextColor = System.Drawing.Color.Black
        '
        'ElementStyle9
        '
        Me.ElementStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.ElementStyle9.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.ElementStyle9.BackColorGradientAngle = 90
        Me.ElementStyle9.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid
        Me.ElementStyle9.BorderBottomWidth = 1
        Me.ElementStyle9.BorderColor = System.Drawing.Color.DarkGray
        Me.ElementStyle9.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid
        Me.ElementStyle9.BorderLeftWidth = 1
        Me.ElementStyle9.BorderRight = DevComponents.Tree.eStyleBorderType.Solid
        Me.ElementStyle9.BorderRightWidth = 1
        Me.ElementStyle9.BorderTop = DevComponents.Tree.eStyleBorderType.Solid
        Me.ElementStyle9.BorderTopWidth = 1
        Me.ElementStyle9.CornerDiameter = 4
        Me.ElementStyle9.CornerType = DevComponents.Tree.eCornerType.Rounded
        Me.ElementStyle9.Description = "Tan"
        Me.ElementStyle9.Name = "ElementStyle9"
        Me.ElementStyle9.PaddingBottom = 3
        Me.ElementStyle9.PaddingLeft = 3
        Me.ElementStyle9.PaddingRight = 3
        Me.ElementStyle9.PaddingTop = 3
        Me.ElementStyle9.TextColor = System.Drawing.Color.Black
        '
        'ElementStyle10
        '
        Me.ElementStyle10.BackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.ElementStyle10.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(111, Byte), Integer))
        Me.ElementStyle10.BackColorGradientAngle = 90
        Me.ElementStyle10.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid
        Me.ElementStyle10.BorderBottomWidth = 1
        Me.ElementStyle10.BorderColor = System.Drawing.Color.DarkGray
        Me.ElementStyle10.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid
        Me.ElementStyle10.BorderLeftWidth = 1
        Me.ElementStyle10.BorderRight = DevComponents.Tree.eStyleBorderType.Solid
        Me.ElementStyle10.BorderRightWidth = 1
        Me.ElementStyle10.BorderTop = DevComponents.Tree.eStyleBorderType.Solid
        Me.ElementStyle10.BorderTopWidth = 1
        Me.ElementStyle10.CornerDiameter = 4
        Me.ElementStyle10.CornerType = DevComponents.Tree.eCornerType.Rounded
        Me.ElementStyle10.Description = "Lemon"
        Me.ElementStyle10.Name = "ElementStyle10"
        Me.ElementStyle10.PaddingBottom = 3
        Me.ElementStyle10.PaddingLeft = 3
        Me.ElementStyle10.PaddingRight = 3
        Me.ElementStyle10.PaddingTop = 3
        Me.ElementStyle10.TextColor = System.Drawing.Color.Black
        '
        'ElementStyle11
        '
        Me.ElementStyle11.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ElementStyle11.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(173, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(146, Byte), Integer))
        Me.ElementStyle11.BackColorGradientAngle = 90
        Me.ElementStyle11.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid
        Me.ElementStyle11.BorderBottomWidth = 1
        Me.ElementStyle11.BorderColor = System.Drawing.Color.DarkGray
        Me.ElementStyle11.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid
        Me.ElementStyle11.BorderLeftWidth = 1
        Me.ElementStyle11.BorderRight = DevComponents.Tree.eStyleBorderType.Solid
        Me.ElementStyle11.BorderRightWidth = 1
        Me.ElementStyle11.BorderTop = DevComponents.Tree.eStyleBorderType.Solid
        Me.ElementStyle11.BorderTopWidth = 1
        Me.ElementStyle11.CornerDiameter = 4
        Me.ElementStyle11.CornerType = DevComponents.Tree.eCornerType.Rounded
        Me.ElementStyle11.Description = "Apple"
        Me.ElementStyle11.Name = "ElementStyle11"
        Me.ElementStyle11.PaddingBottom = 3
        Me.ElementStyle11.PaddingLeft = 3
        Me.ElementStyle11.PaddingRight = 3
        Me.ElementStyle11.PaddingTop = 3
        Me.ElementStyle11.TextColor = System.Drawing.Color.Black
        '
        'ElementStyle12
        '
        Me.ElementStyle12.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.ElementStyle12.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.ElementStyle12.BackColorGradientAngle = 90
        Me.ElementStyle12.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid
        Me.ElementStyle12.BorderBottomWidth = 1
        Me.ElementStyle12.BorderColor = System.Drawing.Color.DarkGray
        Me.ElementStyle12.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid
        Me.ElementStyle12.BorderLeftWidth = 1
        Me.ElementStyle12.BorderRight = DevComponents.Tree.eStyleBorderType.Solid
        Me.ElementStyle12.BorderRightWidth = 1
        Me.ElementStyle12.BorderTop = DevComponents.Tree.eStyleBorderType.Solid
        Me.ElementStyle12.BorderTopWidth = 1
        Me.ElementStyle12.CornerDiameter = 4
        Me.ElementStyle12.CornerType = DevComponents.Tree.eCornerType.Rounded
        Me.ElementStyle12.Description = "Silver"
        Me.ElementStyle12.Name = "ElementStyle12"
        Me.ElementStyle12.PaddingBottom = 3
        Me.ElementStyle12.PaddingLeft = 3
        Me.ElementStyle12.PaddingRight = 3
        Me.ElementStyle12.PaddingTop = 3
        Me.ElementStyle12.TextColor = System.Drawing.Color.Black
        '
        'Frm_Trazabilidad_documento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(653, 436)
        Me.Controls.Add(Me.treeGX1)
        Me.Controls.Add(Me.panel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_Trazabilidad_documento"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.treeGX1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel1.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents labelZoom As System.Windows.Forms.Label
    Friend WithEvents treeGX1 As DevComponents.Tree.TreeGX
    Friend WithEvents nodeConnector2 As DevComponents.Tree.NodeConnector
    Friend WithEvents nodeStyle As DevComponents.Tree.ElementStyle
    Friend WithEvents nodeConnector1 As DevComponents.Tree.NodeConnector
    Friend WithEvents styleClass As DevComponents.Tree.ElementStyle
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents trackBar1 As System.Windows.Forms.TrackBar
    Friend WithEvents panel1 As System.Windows.Forms.Panel
    Friend WithEvents Lista_Imagenes_32 As System.Windows.Forms.ImageList
    Friend WithEvents Lista_Imagenes_16 As System.Windows.Forms.ImageList
    Friend WithEvents comboLayoutType As System.Windows.Forms.ComboBox
    Friend WithEvents comboLayout As System.Windows.Forms.ComboBox
    Friend WithEvents button1 As System.Windows.Forms.Button
    Friend WithEvents buttonPrint As System.Windows.Forms.Button
    Friend WithEvents printDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents saveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents printPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents node1 As DevComponents.Tree.Node
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_Encabezado As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Ver_documento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Lista_Imagnes_Pago_16 As System.Windows.Forms.ImageList
    Friend WithEvents ElementStyle13 As DevComponents.Tree.ElementStyle
    Friend WithEvents ElementStyle1 As DevComponents.Tree.ElementStyle
    Friend WithEvents ElementStyle2 As DevComponents.Tree.ElementStyle
    Friend WithEvents ElementStyle3 As DevComponents.Tree.ElementStyle
    Friend WithEvents ElementStyle4 As DevComponents.Tree.ElementStyle
    Friend WithEvents ElementStyle5 As DevComponents.Tree.ElementStyle
    Friend WithEvents ElementStyle6 As DevComponents.Tree.ElementStyle
    Friend WithEvents ElementStyle7 As DevComponents.Tree.ElementStyle
    Friend WithEvents ElementStyle8 As DevComponents.Tree.ElementStyle
    Friend WithEvents ElementStyle9 As DevComponents.Tree.ElementStyle
    Friend WithEvents ElementStyle10 As DevComponents.Tree.ElementStyle
    Friend WithEvents ElementStyle11 As DevComponents.Tree.ElementStyle
    Friend WithEvents ElementStyle12 As DevComponents.Tree.ElementStyle
End Class
