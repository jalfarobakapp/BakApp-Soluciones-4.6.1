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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.BtnImprimirEtiqueta = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_imprimir_Archivo = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnLimpiar = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnBuscarProducto = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnConfiguracion = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Conf_PuertoEtiqueta = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Conf_ConfEstacion = New DevComponents.DotNetBar.ButtonItem()
        Me.Grupo_Ubicaciones = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.CmbBodega = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Seleccionar_Varios = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Grabar_Futuro = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Btn_ConfPuertoXEtiquetaXEquipo = New DevComponents.DotNetBar.ButtonX()
        Me.Cmbetiquetas = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Grupo_Lista_Precios = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.CmbLista = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Chk_Imprimir_Todas_Las_Ubicaciones = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_ImprimiPrecioFuturo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Txt_Codigo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Grupo_Puerto = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.CmbPuerto = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Chk_LimpiarListadoDeCodigosDespuesDeImprimir = New DevComponents.DotNetBar.Controls.CheckBoxX()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_Ubicaciones.SuspendLayout()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel3.SuspendLayout()
        Me.Grupo_Lista_Precios.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.Grupo_Puerto.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnImprimirEtiqueta, Me.Btn_imprimir_Archivo, Me.BtnLimpiar, Me.BtnBuscarProducto, Me.BtnSalir, Me.BtnConfiguracion})
        Me.Bar1.Location = New System.Drawing.Point(0, 560)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(681, 41)
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
        'BtnConfiguracion
        '
        Me.BtnConfiguracion.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnConfiguracion.ForeColor = System.Drawing.Color.Black
        Me.BtnConfiguracion.Image = CType(resources.GetObject("BtnConfiguracion.Image"), System.Drawing.Image)
        Me.BtnConfiguracion.ImageAlt = CType(resources.GetObject("BtnConfiguracion.ImageAlt"), System.Drawing.Image)
        Me.BtnConfiguracion.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnConfiguracion.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnConfiguracion.Name = "BtnConfiguracion"
        Me.BtnConfiguracion.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Conf_PuertoEtiqueta, Me.Btn_Conf_ConfEstacion})
        Me.BtnConfiguracion.Tooltip = "Configuración de sistema"
        '
        'Btn_Conf_PuertoEtiqueta
        '
        Me.Btn_Conf_PuertoEtiqueta.Image = CType(resources.GetObject("Btn_Conf_PuertoEtiqueta.Image"), System.Drawing.Image)
        Me.Btn_Conf_PuertoEtiqueta.ImageAlt = CType(resources.GetObject("Btn_Conf_PuertoEtiqueta.ImageAlt"), System.Drawing.Image)
        Me.Btn_Conf_PuertoEtiqueta.Name = "Btn_Conf_PuertoEtiqueta"
        Me.Btn_Conf_PuertoEtiqueta.Text = "Configuración puerto y etiqueta por defecto"
        '
        'Btn_Conf_ConfEstacion
        '
        Me.Btn_Conf_ConfEstacion.Image = CType(resources.GetObject("Btn_Conf_ConfEstacion.Image"), System.Drawing.Image)
        Me.Btn_Conf_ConfEstacion.ImageAlt = CType(resources.GetObject("Btn_Conf_ConfEstacion.ImageAlt"), System.Drawing.Image)
        Me.Btn_Conf_ConfEstacion.Name = "Btn_Conf_ConfEstacion"
        Me.Btn_Conf_ConfEstacion.Text = "Configuración de estación local"
        '
        'Grupo_Ubicaciones
        '
        Me.Grupo_Ubicaciones.BackColor = System.Drawing.Color.White
        Me.Grupo_Ubicaciones.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Ubicaciones.Controls.Add(Me.CmbBodega)
        Me.Grupo_Ubicaciones.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Ubicaciones.Location = New System.Drawing.Point(9, 411)
        Me.Grupo_Ubicaciones.Name = "Grupo_Ubicaciones"
        Me.Grupo_Ubicaciones.Size = New System.Drawing.Size(346, 58)
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
        Me.CmbBodega.Size = New System.Drawing.Size(334, 22)
        Me.CmbBodega.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CmbBodega.TabIndex = 76
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.ContextMenuBar1)
        Me.GroupPanel2.Controls.Add(Me.Grilla)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(9, 12)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(664, 329)
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
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(129, 104)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(319, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 3
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual
        '
        Me.Menu_Contextual.AutoExpandOnClick = True
        Me.Menu_Contextual.Name = "Menu_Contextual"
        Me.Menu_Contextual.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Seleccionar_Varios, Me.Btn_Grabar_Futuro})
        Me.Menu_Contextual.Text = "Menu Grabar"
        '
        'Btn_Seleccionar_Varios
        '
        Me.Btn_Seleccionar_Varios.Name = "Btn_Seleccionar_Varios"
        Me.Btn_Seleccionar_Varios.Text = "Grabar precios inmediatamente"
        '
        'Btn_Grabar_Futuro
        '
        Me.Btn_Grabar_Futuro.Name = "Btn_Grabar_Futuro"
        Me.Btn_Grabar_Futuro.Text = "Grabar precios a futuro"
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.AllowUserToDeleteRows = False
        Me.Grilla.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla.DefaultCellStyle = DataGridViewCellStyle8
        Me.Grilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla.EnableHeadersVisualStyles = False
        Me.Grilla.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla.Location = New System.Drawing.Point(0, 0)
        Me.Grilla.Name = "Grilla"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.Grilla.RowHeadersVisible = False
        Me.Grilla.Size = New System.Drawing.Size(658, 306)
        Me.Grilla.TabIndex = 2
        '
        'GroupPanel3
        '
        Me.GroupPanel3.BackColor = System.Drawing.Color.White
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.Btn_ConfPuertoXEtiquetaXEquipo)
        Me.GroupPanel3.Controls.Add(Me.Cmbetiquetas)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Location = New System.Drawing.Point(9, 495)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(501, 59)
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
        'Btn_ConfPuertoXEtiquetaXEquipo
        '
        Me.Btn_ConfPuertoXEtiquetaXEquipo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_ConfPuertoXEtiquetaXEquipo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_ConfPuertoXEtiquetaXEquipo.Image = CType(resources.GetObject("Btn_ConfPuertoXEtiquetaXEquipo.Image"), System.Drawing.Image)
        Me.Btn_ConfPuertoXEtiquetaXEquipo.ImageAlt = CType(resources.GetObject("Btn_ConfPuertoXEtiquetaXEquipo.ImageAlt"), System.Drawing.Image)
        Me.Btn_ConfPuertoXEtiquetaXEquipo.Location = New System.Drawing.Point(466, 5)
        Me.Btn_ConfPuertoXEtiquetaXEquipo.Name = "Btn_ConfPuertoXEtiquetaXEquipo"
        Me.Btn_ConfPuertoXEtiquetaXEquipo.Size = New System.Drawing.Size(26, 25)
        Me.Btn_ConfPuertoXEtiquetaXEquipo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_ConfPuertoXEtiquetaXEquipo.TabIndex = 80
        Me.Btn_ConfPuertoXEtiquetaXEquipo.Tooltip = "Seleccionar puerto de salida según etiqueta por equipo"
        '
        'Cmbetiquetas
        '
        Me.Cmbetiquetas.DisplayMember = "Text"
        Me.Cmbetiquetas.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmbetiquetas.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmbetiquetas.ForeColor = System.Drawing.Color.Black
        Me.Cmbetiquetas.FormattingEnabled = True
        Me.Cmbetiquetas.ItemHeight = 19
        Me.Cmbetiquetas.Location = New System.Drawing.Point(3, 5)
        Me.Cmbetiquetas.Name = "Cmbetiquetas"
        Me.Cmbetiquetas.Size = New System.Drawing.Size(457, 25)
        Me.Cmbetiquetas.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Cmbetiquetas.TabIndex = 74
        '
        'Grupo_Lista_Precios
        '
        Me.Grupo_Lista_Precios.BackColor = System.Drawing.Color.White
        Me.Grupo_Lista_Precios.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Lista_Precios.Controls.Add(Me.CmbLista)
        Me.Grupo_Lista_Precios.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Lista_Precios.Location = New System.Drawing.Point(361, 411)
        Me.Grupo_Lista_Precios.Name = "Grupo_Lista_Precios"
        Me.Grupo_Lista_Precios.Size = New System.Drawing.Size(312, 58)
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
        Me.CmbLista.Size = New System.Drawing.Size(302, 22)
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
        Me.Chk_Imprimir_Todas_Las_Ubicaciones.Location = New System.Drawing.Point(9, 475)
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
        Me.Chk_ImprimiPrecioFuturo.Location = New System.Drawing.Point(361, 475)
        Me.Chk_ImprimiPrecioFuturo.Name = "Chk_ImprimiPrecioFuturo"
        Me.Chk_ImprimiPrecioFuturo.Size = New System.Drawing.Size(145, 17)
        Me.Chk_ImprimiPrecioFuturo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_ImprimiPrecioFuturo.TabIndex = 74
        Me.Chk_ImprimiPrecioFuturo.Text = "Imprimir precios FUTURO"
        '
        'Txt_Codigo
        '
        Me.Txt_Codigo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Codigo.Border.Class = "TextBoxBorder"
        Me.Txt_Codigo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Codigo.ButtonCustom.Image = CType(resources.GetObject("Txt_Codigo.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Codigo.ButtonCustom.Visible = True
        Me.Txt_Codigo.ButtonCustom2.Image = CType(resources.GetObject("Txt_Codigo.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Codigo.ButtonCustom2.Visible = True
        Me.Txt_Codigo.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Codigo.ForeColor = System.Drawing.Color.Black
        Me.Txt_Codigo.Location = New System.Drawing.Point(88, 7)
        Me.Txt_Codigo.Name = "Txt_Codigo"
        Me.Txt_Codigo.PreventEnterBeep = True
        Me.Txt_Codigo.ReadOnly = True
        Me.Txt_Codigo.Size = New System.Drawing.Size(187, 22)
        Me.Txt_Codigo.TabIndex = 76
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 6)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(97, 23)
        Me.LabelX1.TabIndex = 75
        Me.LabelX1.Text = "Buscar producto"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Txt_Codigo)
        Me.GroupPanel1.Controls.Add(Me.LabelX1)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(9, 347)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(288, 58)
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
        Me.GroupPanel1.TabIndex = 77
        Me.GroupPanel1.Text = "Traer productos al listado"
        '
        'Grupo_Puerto
        '
        Me.Grupo_Puerto.BackColor = System.Drawing.Color.White
        Me.Grupo_Puerto.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Puerto.Controls.Add(Me.CmbPuerto)
        Me.Grupo_Puerto.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Puerto.Location = New System.Drawing.Point(516, 495)
        Me.Grupo_Puerto.Name = "Grupo_Puerto"
        Me.Grupo_Puerto.Size = New System.Drawing.Size(157, 59)
        '
        '
        '
        Me.Grupo_Puerto.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Puerto.Style.BackColorGradientAngle = 90
        Me.Grupo_Puerto.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Puerto.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Puerto.Style.BorderBottomWidth = 1
        Me.Grupo_Puerto.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Puerto.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Puerto.Style.BorderLeftWidth = 1
        Me.Grupo_Puerto.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Puerto.Style.BorderRightWidth = 1
        Me.Grupo_Puerto.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Puerto.Style.BorderTopWidth = 1
        Me.Grupo_Puerto.Style.CornerDiameter = 4
        Me.Grupo_Puerto.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Puerto.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Puerto.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Puerto.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Puerto.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Puerto.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Puerto.TabIndex = 78
        Me.Grupo_Puerto.Text = "Puerto salida"
        '
        'CmbPuerto
        '
        Me.CmbPuerto.DisplayMember = "Text"
        Me.CmbPuerto.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbPuerto.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbPuerto.ForeColor = System.Drawing.Color.Black
        Me.CmbPuerto.FormattingEnabled = True
        Me.CmbPuerto.ItemHeight = 19
        Me.CmbPuerto.Location = New System.Drawing.Point(1, 5)
        Me.CmbPuerto.Name = "CmbPuerto"
        Me.CmbPuerto.Size = New System.Drawing.Size(147, 25)
        Me.CmbPuerto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CmbPuerto.TabIndex = 0
        '
        'Chk_LimpiarListadoDeCodigosDespuesDeImprimir
        '
        Me.Chk_LimpiarListadoDeCodigosDespuesDeImprimir.AutoSize = True
        Me.Chk_LimpiarListadoDeCodigosDespuesDeImprimir.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_LimpiarListadoDeCodigosDespuesDeImprimir.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_LimpiarListadoDeCodigosDespuesDeImprimir.CheckBoxImageChecked = CType(resources.GetObject("Chk_LimpiarListadoDeCodigosDespuesDeImprimir.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_LimpiarListadoDeCodigosDespuesDeImprimir.FocusCuesEnabled = False
        Me.Chk_LimpiarListadoDeCodigosDespuesDeImprimir.ForeColor = System.Drawing.Color.Black
        Me.Chk_LimpiarListadoDeCodigosDespuesDeImprimir.Location = New System.Drawing.Point(478, 347)
        Me.Chk_LimpiarListadoDeCodigosDespuesDeImprimir.Name = "Chk_LimpiarListadoDeCodigosDespuesDeImprimir"
        Me.Chk_LimpiarListadoDeCodigosDespuesDeImprimir.Size = New System.Drawing.Size(195, 17)
        Me.Chk_LimpiarListadoDeCodigosDespuesDeImprimir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_LimpiarListadoDeCodigosDespuesDeImprimir.TabIndex = 79
        Me.Chk_LimpiarListadoDeCodigosDespuesDeImprimir.Text = "Limpiar listado despues de imprimir"
        '
        'Frm_ImpBarras_PorProducto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(681, 601)
        Me.Controls.Add(Me.Chk_LimpiarListadoDeCodigosDespuesDeImprimir)
        Me.Controls.Add(Me.Grupo_Puerto)
        Me.Controls.Add(Me.GroupPanel1)
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
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel3.ResumeLayout(False)
        Me.Grupo_Lista_Precios.ResumeLayout(False)
        Me.GroupPanel1.ResumeLayout(False)
        Me.Grupo_Puerto.ResumeLayout(False)
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
    Public WithEvents Grupo_Ubicaciones As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Grupo_Lista_Precios As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents CmbBodega As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Cmbetiquetas As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents CmbLista As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Chk_ImprimiPrecioFuturo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Seleccionar_Varios As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Grabar_Futuro As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Txt_Codigo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Public WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents CmbPuerto As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Btn_Conf_PuertoEtiqueta As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Conf_ConfEstacion As DevComponents.DotNetBar.ButtonItem
    Public WithEvents BtnConfiguracion As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_imprimir_Archivo As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Grupo_Puerto As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Chk_LimpiarListadoDeCodigosDespuesDeImprimir As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Chk_Imprimir_Todas_Las_Ubicaciones As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Btn_ConfPuertoXEtiquetaXEquipo As DevComponents.DotNetBar.ButtonX
End Class
