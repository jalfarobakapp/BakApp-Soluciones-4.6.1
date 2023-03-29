<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ImpBarras_PorProducto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ImpBarras_PorProducto))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.BtnImprimirEtiqueta = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_imprimir_Archivo = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnLimpiar = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnBuscarProducto = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem()
        Me.Grupo_Ubicaciones = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.CmbBodega = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Cmbetiquetas = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Grupo_Lista_Precios = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.CmbLista = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Chk_Imprimir_Todas_Las_Ubicaciones = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_ImprimiPrecioFuturo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_Ubicaciones.SuspendLayout()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel3.SuspendLayout()
        Me.Grupo_Lista_Precios.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnImprimirEtiqueta, Me.Btn_imprimir_Archivo, Me.BtnLimpiar, Me.BtnBuscarProducto, Me.BtnSalir})
        Me.Bar1.Location = New System.Drawing.Point(0, 491)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(600, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010
        Me.Bar1.TabIndex = 66
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnImprimirEtiqueta
        '
        Me.BtnImprimirEtiqueta.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnImprimirEtiqueta.ForeColor = System.Drawing.Color.Black
        Me.BtnImprimirEtiqueta.Image = CType(resources.GetObject("BtnImprimirEtiqueta.Image"), System.Drawing.Image)
        Me.BtnImprimirEtiqueta.ImageAlt = CType(resources.GetObject("BtnImprimirEtiqueta.ImageAlt"), System.Drawing.Image)
        Me.BtnImprimirEtiqueta.Name = "BtnImprimirEtiqueta"
        Me.BtnImprimirEtiqueta.Text = "Imprimir etiquetas"
        '
        'Btn_imprimir_Archivo
        '
        Me.Btn_imprimir_Archivo.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_imprimir_Archivo.ForeColor = System.Drawing.Color.Black
        Me.Btn_imprimir_Archivo.Image = CType(resources.GetObject("Btn_imprimir_Archivo.Image"), System.Drawing.Image)
        Me.Btn_imprimir_Archivo.ImageAlt = CType(resources.GetObject("Btn_imprimir_Archivo.ImageAlt"), System.Drawing.Image)
        Me.Btn_imprimir_Archivo.Name = "Btn_imprimir_Archivo"
        Me.Btn_imprimir_Archivo.Tooltip = "Imprimir a un archivo"
        '
        'BtnLimpiar
        '
        Me.BtnLimpiar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnLimpiar.ForeColor = System.Drawing.Color.Black
        Me.BtnLimpiar.Image = CType(resources.GetObject("BtnLimpiar.Image"), System.Drawing.Image)
        Me.BtnLimpiar.ImageAlt = CType(resources.GetObject("BtnLimpiar.ImageAlt"), System.Drawing.Image)
        Me.BtnLimpiar.Name = "BtnLimpiar"
        Me.BtnLimpiar.Tooltip = "Limpiar listado"
        '
        'BtnBuscarProducto
        '
        Me.BtnBuscarProducto.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnBuscarProducto.ForeColor = System.Drawing.Color.Black
        Me.BtnBuscarProducto.Image = CType(resources.GetObject("BtnBuscarProducto.Image"), System.Drawing.Image)
        Me.BtnBuscarProducto.ImageAlt = CType(resources.GetObject("BtnBuscarProducto.ImageAlt"), System.Drawing.Image)
        Me.BtnBuscarProducto.Name = "BtnBuscarProducto"
        Me.BtnBuscarProducto.Tooltip = "Buscar productos "
        '
        'BtnSalir
        '
        Me.BtnSalir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnSalir.ForeColor = System.Drawing.Color.Black
        Me.BtnSalir.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Tooltip = "Salir"
        '
        'Grupo_Ubicaciones
        '
        Me.Grupo_Ubicaciones.BackColor = System.Drawing.Color.White
        Me.Grupo_Ubicaciones.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Ubicaciones.Controls.Add(Me.CmbBodega)
        Me.Grupo_Ubicaciones.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Ubicaciones.Location = New System.Drawing.Point(9, 343)
        Me.Grupo_Ubicaciones.Name = "Grupo_Ubicaciones"
        Me.Grupo_Ubicaciones.Size = New System.Drawing.Size(258, 58)
        '
        '
        '
        Me.Grupo_Ubicaciones.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Ubicaciones.Style.BackColorGradientAngle = 90
        Me.Grupo_Ubicaciones.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Ubicaciones.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Ubicaciones.Style.BorderBottomWidth = 1
        Me.Grupo_Ubicaciones.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Ubicaciones.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Ubicaciones.Style.BorderLeftWidth = 1
        Me.Grupo_Ubicaciones.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Ubicaciones.Style.BorderRightWidth = 1
        Me.Grupo_Ubicaciones.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Ubicaciones.Style.BorderTopWidth = 1
        Me.Grupo_Ubicaciones.Style.CornerDiameter = 4
        Me.Grupo_Ubicaciones.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Ubicaciones.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Ubicaciones.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Ubicaciones.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Ubicaciones.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Ubicaciones.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Ubicaciones.TabIndex = 67
        Me.Grupo_Ubicaciones.Text = "Bodega para ubicación"
        '
        'CmbBodega
        '
        Me.CmbBodega.DisplayMember = "Text"
        Me.CmbBodega.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbBodega.ForeColor = System.Drawing.Color.Black
        Me.CmbBodega.FormattingEnabled = True
        Me.CmbBodega.ItemHeight = 16
        Me.CmbBodega.Location = New System.Drawing.Point(3, 9)
        Me.CmbBodega.Name = "CmbBodega"
        Me.CmbBodega.Size = New System.Drawing.Size(246, 22)
        Me.CmbBodega.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CmbBodega.TabIndex = 76
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Grilla)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(9, 17)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(582, 320)
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
        Me.GroupPanel2.TabIndex = 68
        Me.GroupPanel2.Text = "Productos"
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
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla.RowHeadersVisible = False
        Me.Grilla.Size = New System.Drawing.Size(576, 297)
        Me.Grilla.TabIndex = 2
        '
        'GroupPanel3
        '
        Me.GroupPanel3.BackColor = System.Drawing.Color.White
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.Cmbetiquetas)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Location = New System.Drawing.Point(9, 430)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(582, 50)
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
        Me.GroupPanel3.TabIndex = 69
        Me.GroupPanel3.Text = "Etiqueta"
        '
        'Cmbetiquetas
        '
        Me.Cmbetiquetas.DisplayMember = "Text"
        Me.Cmbetiquetas.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmbetiquetas.ForeColor = System.Drawing.Color.Black
        Me.Cmbetiquetas.FormattingEnabled = True
        Me.Cmbetiquetas.ItemHeight = 16
        Me.Cmbetiquetas.Location = New System.Drawing.Point(3, 2)
        Me.Cmbetiquetas.Name = "Cmbetiquetas"
        Me.Cmbetiquetas.Size = New System.Drawing.Size(570, 22)
        Me.Cmbetiquetas.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Cmbetiquetas.TabIndex = 74
        '
        'Grupo_Lista_Precios
        '
        Me.Grupo_Lista_Precios.BackColor = System.Drawing.Color.White
        Me.Grupo_Lista_Precios.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Lista_Precios.Controls.Add(Me.CmbLista)
        Me.Grupo_Lista_Precios.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Lista_Precios.Location = New System.Drawing.Point(273, 343)
        Me.Grupo_Lista_Precios.Name = "Grupo_Lista_Precios"
        Me.Grupo_Lista_Precios.Size = New System.Drawing.Size(318, 58)
        '
        '
        '
        Me.Grupo_Lista_Precios.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Lista_Precios.Style.BackColorGradientAngle = 90
        Me.Grupo_Lista_Precios.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Lista_Precios.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Lista_Precios.Style.BorderBottomWidth = 1
        Me.Grupo_Lista_Precios.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Lista_Precios.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Lista_Precios.Style.BorderLeftWidth = 1
        Me.Grupo_Lista_Precios.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Lista_Precios.Style.BorderRightWidth = 1
        Me.Grupo_Lista_Precios.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Lista_Precios.Style.BorderTopWidth = 1
        Me.Grupo_Lista_Precios.Style.CornerDiameter = 4
        Me.Grupo_Lista_Precios.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Lista_Precios.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Lista_Precios.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Lista_Precios.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Lista_Precios.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Lista_Precios.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Lista_Precios.TabIndex = 70
        Me.Grupo_Lista_Precios.Text = "Lista de precios"
        '
        'CmbLista
        '
        Me.CmbLista.DisplayMember = "Text"
        Me.CmbLista.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbLista.ForeColor = System.Drawing.Color.Black
        Me.CmbLista.FormattingEnabled = True
        Me.CmbLista.ItemHeight = 16
        Me.CmbLista.Location = New System.Drawing.Point(3, 9)
        Me.CmbLista.Name = "CmbLista"
        Me.CmbLista.Size = New System.Drawing.Size(306, 22)
        Me.CmbLista.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CmbLista.TabIndex = 75
        '
        'Chk_Imprimir_Todas_Las_Ubicaciones
        '
        Me.Chk_Imprimir_Todas_Las_Ubicaciones.AutoSize = True
        Me.Chk_Imprimir_Todas_Las_Ubicaciones.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Imprimir_Todas_Las_Ubicaciones.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Imprimir_Todas_Las_Ubicaciones.CheckBoxImageChecked = CType(resources.GetObject("Chk_Imprimir_Todas_Las_Ubicaciones.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Imprimir_Todas_Las_Ubicaciones.FocusCuesEnabled = False
        Me.Chk_Imprimir_Todas_Las_Ubicaciones.ForeColor = System.Drawing.Color.Black
        Me.Chk_Imprimir_Todas_Las_Ubicaciones.Location = New System.Drawing.Point(9, 407)
        Me.Chk_Imprimir_Todas_Las_Ubicaciones.Name = "Chk_Imprimir_Todas_Las_Ubicaciones"
        Me.Chk_Imprimir_Todas_Las_Ubicaciones.Size = New System.Drawing.Size(169, 17)
        Me.Chk_Imprimir_Todas_Las_Ubicaciones.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Imprimir_Todas_Las_Ubicaciones.TabIndex = 73
        Me.Chk_Imprimir_Todas_Las_Ubicaciones.Text = "Imprimir todas las ubicaciones"
        '
        'Chk_ImprimiPrecioFuturo
        '
        Me.Chk_ImprimiPrecioFuturo.AutoSize = True
        Me.Chk_ImprimiPrecioFuturo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_ImprimiPrecioFuturo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_ImprimiPrecioFuturo.CheckBoxImageChecked = CType(resources.GetObject("Chk_ImprimiPrecioFuturo.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_ImprimiPrecioFuturo.FocusCuesEnabled = False
        Me.Chk_ImprimiPrecioFuturo.ForeColor = System.Drawing.Color.Black
        Me.Chk_ImprimiPrecioFuturo.Location = New System.Drawing.Point(273, 407)
        Me.Chk_ImprimiPrecioFuturo.Name = "Chk_ImprimiPrecioFuturo"
        Me.Chk_ImprimiPrecioFuturo.Size = New System.Drawing.Size(145, 17)
        Me.Chk_ImprimiPrecioFuturo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_ImprimiPrecioFuturo.TabIndex = 74
        Me.Chk_ImprimiPrecioFuturo.Text = "Imprimir precios FUTURO"
        '
        'Frm_ImpBarras_PorProducto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 532)
        Me.Controls.Add(Me.Chk_ImprimiPrecioFuturo)
        Me.Controls.Add(Me.Chk_Imprimir_Todas_Las_Ubicaciones)
        Me.Controls.Add(Me.Grupo_Lista_Precios)
        Me.Controls.Add(Me.GroupPanel3)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.Grupo_Ubicaciones)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_ImpBarras_PorProducto"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Impresión de etiquetas por productos"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo_Ubicaciones.ResumeLayout(False)
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel3.ResumeLayout(False)
        Me.Grupo_Lista_Precios.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnImprimirEtiqueta As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnBuscarProducto As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnLimpiar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Btn_imprimir_Archivo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Chk_Imprimir_Todas_Las_Ubicaciones As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Grupo_Ubicaciones As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Grupo_Lista_Precios As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents CmbBodega As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Cmbetiquetas As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents CmbLista As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Chk_ImprimiPrecioFuturo As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
