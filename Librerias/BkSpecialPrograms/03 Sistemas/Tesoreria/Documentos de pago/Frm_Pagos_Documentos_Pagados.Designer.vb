<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Pagos_Documentos_Pagados
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Pagos_Documentos_Pagados))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_01 = New DevComponents.DotNetBar.ButtonItem()
        Me.Lbl_Mnu_1 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Mnu_Ficha_Entidad = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Ver_documento = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_02 = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Cambiar_Nro_Doc = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Cambiar_Nro_Cta_Cte = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_03 = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Mnu_Imprimir_Documento = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Vista_Previa = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla_Detalle = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Enviar_Correos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Imprimir_Comprobante = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Editar_Encabezado = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Imprimir_Vista_Previa = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel13 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Grilla_Encabezado = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Lista_Imagenes_16 = New System.Windows.Forms.ImageList(Me.components)
        Me.Lista_Imagenes_32 = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupPanel1.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla_Detalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel13.SuspendLayout()
        CType(Me.Grilla_Encabezado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.ContextMenuBar1)
        Me.GroupPanel1.Controls.Add(Me.Grilla_Detalle)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 86)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(746, 401)
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
        Me.GroupPanel1.TabIndex = 40
        Me.GroupPanel1.Text = "Detalle"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_01, Me.Menu_Contextual_02, Me.Menu_Contextual_03})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(231, 59)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(263, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 47
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_01
        '
        Me.Menu_Contextual_01.AutoExpandOnClick = True
        Me.Menu_Contextual_01.Name = "Menu_Contextual_01"
        Me.Menu_Contextual_01.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Lbl_Mnu_1, Me.Btn_Mnu_Ficha_Entidad, Me.Btn_Ver_documento})
        Me.Menu_Contextual_01.Text = "Opciones"
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
        Me.Lbl_Mnu_1.Text = "Información del cliente"
        '
        'Btn_Mnu_Ficha_Entidad
        '
        Me.Btn_Mnu_Ficha_Entidad.Image = CType(resources.GetObject("Btn_Mnu_Ficha_Entidad.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Ficha_Entidad.Name = "Btn_Mnu_Ficha_Entidad"
        Me.Btn_Mnu_Ficha_Entidad.Text = "Ver ficha de entidad"
        '
        'Btn_Ver_documento
        '
        Me.Btn_Ver_documento.Image = CType(resources.GetObject("Btn_Ver_documento.Image"), System.Drawing.Image)
        Me.Btn_Ver_documento.Name = "Btn_Ver_documento"
        Me.Btn_Ver_documento.Text = "Ver documento"
        '
        'Menu_Contextual_02
        '
        Me.Menu_Contextual_02.AutoExpandOnClick = True
        Me.Menu_Contextual_02.Name = "Menu_Contextual_02"
        Me.Menu_Contextual_02.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1, Me.Btn_Cambiar_Nro_Doc, Me.Btn_Cambiar_Nro_Cta_Cte})
        Me.Menu_Contextual_02.Text = "Opciones"
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
        Me.LabelItem1.Text = "Modificar datos del encabezado"
        '
        'Btn_Cambiar_Nro_Doc
        '
        Me.Btn_Cambiar_Nro_Doc.Image = CType(resources.GetObject("Btn_Cambiar_Nro_Doc.Image"), System.Drawing.Image)
        Me.Btn_Cambiar_Nro_Doc.Name = "Btn_Cambiar_Nro_Doc"
        Me.Btn_Cambiar_Nro_Doc.Text = "Cambiar número de cheque/tarjeta/transferencia"
        '
        'Btn_Cambiar_Nro_Cta_Cte
        '
        Me.Btn_Cambiar_Nro_Cta_Cte.Image = CType(resources.GetObject("Btn_Cambiar_Nro_Cta_Cte.Image"), System.Drawing.Image)
        Me.Btn_Cambiar_Nro_Cta_Cte.Name = "Btn_Cambiar_Nro_Cta_Cte"
        Me.Btn_Cambiar_Nro_Cta_Cte.Text = "Cambiar número de Cta. Cte."
        '
        'Menu_Contextual_03
        '
        Me.Menu_Contextual_03.AutoExpandOnClick = True
        Me.Menu_Contextual_03.Name = "Menu_Contextual_03"
        Me.Menu_Contextual_03.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem2, Me.Btn_Mnu_Imprimir_Documento, Me.Btn_Mnu_Vista_Previa})
        Me.Menu_Contextual_03.Text = "Opciones"
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
        Me.LabelItem2.Text = "Imprimir/Vista previa"
        '
        'Btn_Mnu_Imprimir_Documento
        '
        Me.Btn_Mnu_Imprimir_Documento.Image = CType(resources.GetObject("Btn_Mnu_Imprimir_Documento.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Imprimir_Documento.Name = "Btn_Mnu_Imprimir_Documento"
        Me.Btn_Mnu_Imprimir_Documento.Text = "Imprimir documento"
        '
        'Btn_Mnu_Vista_Previa
        '
        Me.Btn_Mnu_Vista_Previa.Image = CType(resources.GetObject("Btn_Mnu_Vista_Previa.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Vista_Previa.Name = "Btn_Mnu_Vista_Previa"
        Me.Btn_Mnu_Vista_Previa.Text = "Vista previa"
        '
        'Grilla_Detalle
        '
        Me.Grilla_Detalle.AllowUserToAddRows = False
        Me.Grilla_Detalle.AllowUserToDeleteRows = False
        Me.Grilla_Detalle.BackgroundColor = System.Drawing.Color.White
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
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
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
        Me.Grilla_Detalle.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Detalle.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla_Detalle.Size = New System.Drawing.Size(740, 378)
        Me.Grilla_Detalle.StandardTab = True
        Me.Grilla_Detalle.TabIndex = 82
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Enviar_Correos, Me.Btn_Imprimir_Comprobante, Me.Btn_Editar_Encabezado, Me.Btn_Imprimir_Vista_Previa})
        Me.Bar1.Location = New System.Drawing.Point(0, 503)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(765, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 39
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Enviar_Correos
        '
        Me.Btn_Enviar_Correos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Enviar_Correos.ForeColor = System.Drawing.Color.Black
        Me.Btn_Enviar_Correos.Image = CType(resources.GetObject("Btn_Enviar_Correos.Image"), System.Drawing.Image)
        Me.Btn_Enviar_Correos.Name = "Btn_Enviar_Correos"
        Me.Btn_Enviar_Correos.Tooltip = "Enviar correos"
        '
        'Btn_Imprimir_Comprobante
        '
        Me.Btn_Imprimir_Comprobante.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Imprimir_Comprobante.ForeColor = System.Drawing.Color.Black
        Me.Btn_Imprimir_Comprobante.Image = CType(resources.GetObject("Btn_Imprimir_Comprobante.Image"), System.Drawing.Image)
        Me.Btn_Imprimir_Comprobante.Name = "Btn_Imprimir_Comprobante"
        Me.Btn_Imprimir_Comprobante.Tooltip = "Imprimir comprobante"
        Me.Btn_Imprimir_Comprobante.Visible = False
        '
        'Btn_Editar_Encabezado
        '
        Me.Btn_Editar_Encabezado.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Editar_Encabezado.ForeColor = System.Drawing.Color.Black
        Me.Btn_Editar_Encabezado.Image = CType(resources.GetObject("Btn_Editar_Encabezado.Image"), System.Drawing.Image)
        Me.Btn_Editar_Encabezado.Name = "Btn_Editar_Encabezado"
        Me.Btn_Editar_Encabezado.Tooltip = "Modificar datos (Nro. Cheque/Tarjeta/Cta. Cte/ Etc.)"
        '
        'Btn_Imprimir_Vista_Previa
        '
        Me.Btn_Imprimir_Vista_Previa.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Imprimir_Vista_Previa.ForeColor = System.Drawing.Color.Black
        Me.Btn_Imprimir_Vista_Previa.Image = CType(resources.GetObject("Btn_Imprimir_Vista_Previa.Image"), System.Drawing.Image)
        Me.Btn_Imprimir_Vista_Previa.Name = "Btn_Imprimir_Vista_Previa"
        Me.Btn_Imprimir_Vista_Previa.Tooltip = "Imprimir"
        Me.Btn_Imprimir_Vista_Previa.Visible = False
        '
        'GroupPanel13
        '
        Me.GroupPanel13.BackColor = System.Drawing.Color.White
        Me.GroupPanel13.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel13.Controls.Add(Me.Grilla_Encabezado)
        Me.GroupPanel13.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel13.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.GroupPanel13.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel13.Name = "GroupPanel13"
        Me.GroupPanel13.Size = New System.Drawing.Size(746, 68)
        '
        '
        '
        Me.GroupPanel13.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel13.Style.BackColorGradientAngle = 90
        Me.GroupPanel13.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel13.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel13.Style.BorderBottomWidth = 1
        Me.GroupPanel13.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel13.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel13.Style.BorderLeftWidth = 1
        Me.GroupPanel13.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel13.Style.BorderRightWidth = 1
        Me.GroupPanel13.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel13.Style.BorderTopWidth = 1
        Me.GroupPanel13.Style.CornerDiameter = 4
        Me.GroupPanel13.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel13.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel13.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel13.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel13.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel13.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel13.TabIndex = 81
        Me.GroupPanel13.Text = "Encabezado"
        '
        'Grilla_Encabezado
        '
        Me.Grilla_Encabezado.AllowUserToAddRows = False
        Me.Grilla_Encabezado.AllowUserToDeleteRows = False
        Me.Grilla_Encabezado.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Encabezado.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Grilla_Encabezado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Encabezado.DefaultCellStyle = DataGridViewCellStyle5
        Me.Grilla_Encabezado.EnableHeadersVisualStyles = False
        Me.Grilla_Encabezado.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Encabezado.Location = New System.Drawing.Point(3, 3)
        Me.Grilla_Encabezado.Name = "Grilla_Encabezado"
        Me.Grilla_Encabezado.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Encabezado.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Grilla_Encabezado.RowHeadersVisible = False
        Me.Grilla_Encabezado.RowTemplate.Height = 25
        Me.Grilla_Encabezado.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Grilla_Encabezado.Size = New System.Drawing.Size(734, 39)
        Me.Grilla_Encabezado.TabIndex = 0
        '
        'Lista_Imagenes_16
        '
        Me.Lista_Imagenes_16.ImageStream = CType(resources.GetObject("Lista_Imagenes_16.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Lista_Imagenes_16.TransparentColor = System.Drawing.Color.Transparent
        Me.Lista_Imagenes_16.Images.SetKeyName(0, "money.png")
        Me.Lista_Imagenes_16.Images.SetKeyName(1, "check.png")
        Me.Lista_Imagenes_16.Images.SetKeyName(2, "credit_card.png")
        Me.Lista_Imagenes_16.Images.SetKeyName(3, "stock_exchange.png")
        Me.Lista_Imagenes_16.Images.SetKeyName(4, "quote.png")
        Me.Lista_Imagenes_16.Images.SetKeyName(5, "document_text.png")
        Me.Lista_Imagenes_16.Images.SetKeyName(6, "invoice-to_check.png")
        Me.Lista_Imagenes_16.Images.SetKeyName(7, "money_banknote-info.png")
        Me.Lista_Imagenes_16.Images.SetKeyName(8, "tag_price.png")
        '
        'Lista_Imagenes_32
        '
        Me.Lista_Imagenes_32.ImageStream = CType(resources.GetObject("Lista_Imagenes_32.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Lista_Imagenes_32.TransparentColor = System.Drawing.Color.Transparent
        Me.Lista_Imagenes_32.Images.SetKeyName(0, "check-print.png")
        Me.Lista_Imagenes_32.Images.SetKeyName(1, "credit_card_front-print.png")
        '
        'Frm_Pagos_Documentos_Pagados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(765, 544)
        Me.Controls.Add(Me.GroupPanel13)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Pagos_Documentos_Pagados"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla_Detalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel13.ResumeLayout(False)
        CType(Me.Grilla_Encabezado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_01 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Lbl_Mnu_1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Mnu_Ficha_Entidad As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Enviar_Correos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel13 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grilla_Encabezado As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Lista_Imagenes_16 As System.Windows.Forms.ImageList
    Friend WithEvents Btn_Ver_documento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Imprimir_Vista_Previa As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Imprimir_Comprobante As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Menu_Contextual_02 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Cambiar_Nro_Doc As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Cambiar_Nro_Cta_Cte As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Editar_Encabezado As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Menu_Contextual_03 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Mnu_Imprimir_Documento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_Vista_Previa As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Lista_Imagenes_32 As System.Windows.Forms.ImageList
    Friend WithEvents Grilla_Detalle As DevComponents.DotNetBar.Controls.DataGridViewX
End Class
