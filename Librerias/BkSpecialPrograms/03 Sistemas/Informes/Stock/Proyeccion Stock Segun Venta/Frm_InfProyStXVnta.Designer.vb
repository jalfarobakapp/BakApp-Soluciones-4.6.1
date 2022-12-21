<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_InfProyStXVnta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_InfProyStXVnta))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Grupo_Venta_Diaria = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_Filtros_Productos = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Filtro_Pro_Productos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Pro_Super_Familias = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Pro_Familias = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Pro_Sub_Familias = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Pro_Marcas = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Pro_Categorias = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Pro_Codigos_Madre = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Pro_Clas_Libre = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Pro_Rubros = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Pro_Zonas = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_Filtros_Suc_Bod = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem4 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Filtro_Sucursales = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Bodegas = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_Edicion_Datos = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem9 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Cambiar_PromVntaPorc = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Cambiar_PromVntaValor = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Actualizar_Informe = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Excel = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtrar_Suc_Bod = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Filtrar_Productos = New DevComponents.DotNetBar.ButtonX()
        Me.Cmb_Vista_Informe = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ComboItem1 = New DevComponents.Editors.ComboItem()
        Me.ComboItem2 = New DevComponents.Editors.ComboItem()
        Me.ComboItem3 = New DevComponents.Editors.ComboItem()
        Me.ComboItem4 = New DevComponents.Editors.ComboItem()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Input_MesesEstudio = New DevComponents.Editors.IntegerInput()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Input_MesesProyeccion = New DevComponents.Editors.IntegerInput()
        Me.Btn_Bodega_Vta_Estudio = New DevComponents.DotNetBar.ButtonX()
        Me.Grupo_Venta_Diaria.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Input_MesesEstudio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Input_MesesProyeccion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Grupo_Venta_Diaria
        '
        Me.Grupo_Venta_Diaria.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grupo_Venta_Diaria.BackColor = System.Drawing.Color.White
        Me.Grupo_Venta_Diaria.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Venta_Diaria.Controls.Add(Me.ContextMenuBar1)
        Me.Grupo_Venta_Diaria.Controls.Add(Me.Grilla)
        Me.Grupo_Venta_Diaria.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Venta_Diaria.Location = New System.Drawing.Point(4, 72)
        Me.Grupo_Venta_Diaria.Name = "Grupo_Venta_Diaria"
        Me.Grupo_Venta_Diaria.Size = New System.Drawing.Size(1063, 532)
        '
        '
        '
        Me.Grupo_Venta_Diaria.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Venta_Diaria.Style.BackColorGradientAngle = 90
        Me.Grupo_Venta_Diaria.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Venta_Diaria.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Venta_Diaria.Style.BorderBottomWidth = 1
        Me.Grupo_Venta_Diaria.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Venta_Diaria.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Venta_Diaria.Style.BorderLeftWidth = 1
        Me.Grupo_Venta_Diaria.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Venta_Diaria.Style.BorderRightWidth = 1
        Me.Grupo_Venta_Diaria.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Venta_Diaria.Style.BorderTopWidth = 1
        Me.Grupo_Venta_Diaria.Style.CornerDiameter = 4
        Me.Grupo_Venta_Diaria.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Venta_Diaria.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Venta_Diaria.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Venta_Diaria.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Venta_Diaria.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Venta_Diaria.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Venta_Diaria.TabIndex = 105
        Me.Grupo_Venta_Diaria.Text = "Detalle del informe"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_Filtros_Productos, Me.Menu_Contextual_Filtros_Suc_Bod, Me.Menu_Contextual_Edicion_Datos})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(31, 28)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(784, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 97
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_Filtros_Productos
        '
        Me.Menu_Contextual_Filtros_Productos.AutoExpandOnClick = True
        Me.Menu_Contextual_Filtros_Productos.ImageAlt = CType(resources.GetObject("Menu_Contextual_Filtros_Productos.ImageAlt"), System.Drawing.Image)
        Me.Menu_Contextual_Filtros_Productos.Name = "Menu_Contextual_Filtros_Productos"
        Me.Menu_Contextual_Filtros_Productos.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem2, Me.Btn_Filtro_Pro_Productos, Me.Btn_Filtro_Pro_Super_Familias, Me.Btn_Filtro_Pro_Familias, Me.Btn_Filtro_Pro_Sub_Familias, Me.Btn_Filtro_Pro_Marcas, Me.Btn_Filtro_Pro_Categorias, Me.Btn_Filtro_Pro_Codigos_Madre, Me.Btn_Filtro_Pro_Clas_Libre, Me.Btn_Filtro_Pro_Rubros, Me.Btn_Filtro_Pro_Zonas})
        Me.Menu_Contextual_Filtros_Productos.Text = "Filtros Productos"
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
        Me.LabelItem2.Text = "Productos"
        '
        'Btn_Filtro_Pro_Productos
        '
        Me.Btn_Filtro_Pro_Productos.Image = CType(resources.GetObject("Btn_Filtro_Pro_Productos.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Pro_Productos.ImageAlt = CType(resources.GetObject("Btn_Filtro_Pro_Productos.ImageAlt"), System.Drawing.Image)
        Me.Btn_Filtro_Pro_Productos.Name = "Btn_Filtro_Pro_Productos"
        Me.Btn_Filtro_Pro_Productos.Text = "Filtrar por <b><font color=""#0072BC"">PRODUCTOS" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "</font></b>"
        '
        'Btn_Filtro_Pro_Super_Familias
        '
        Me.Btn_Filtro_Pro_Super_Familias.Image = CType(resources.GetObject("Btn_Filtro_Pro_Super_Familias.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Pro_Super_Familias.ImageAlt = CType(resources.GetObject("Btn_Filtro_Pro_Super_Familias.ImageAlt"), System.Drawing.Image)
        Me.Btn_Filtro_Pro_Super_Familias.Name = "Btn_Filtro_Pro_Super_Familias"
        Me.Btn_Filtro_Pro_Super_Familias.Text = "Filtrar por <b><font color=""#0072BC"">SUPER FAMILIAS</font></b>"
        '
        'Btn_Filtro_Pro_Familias
        '
        Me.Btn_Filtro_Pro_Familias.Image = CType(resources.GetObject("Btn_Filtro_Pro_Familias.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Pro_Familias.ImageAlt = CType(resources.GetObject("Btn_Filtro_Pro_Familias.ImageAlt"), System.Drawing.Image)
        Me.Btn_Filtro_Pro_Familias.Name = "Btn_Filtro_Pro_Familias"
        Me.Btn_Filtro_Pro_Familias.Text = "Filtrar por <b><font color=""#0072BC"">FAMILIAS</font></b>"
        '
        'Btn_Filtro_Pro_Sub_Familias
        '
        Me.Btn_Filtro_Pro_Sub_Familias.Image = CType(resources.GetObject("Btn_Filtro_Pro_Sub_Familias.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Pro_Sub_Familias.ImageAlt = CType(resources.GetObject("Btn_Filtro_Pro_Sub_Familias.ImageAlt"), System.Drawing.Image)
        Me.Btn_Filtro_Pro_Sub_Familias.Name = "Btn_Filtro_Pro_Sub_Familias"
        Me.Btn_Filtro_Pro_Sub_Familias.Text = "Filtrar por <b><font color=""#4E5D30""><font color=""#0072BC"">SUB FAMILIAS</font></f" &
    "ont></b>"
        '
        'Btn_Filtro_Pro_Marcas
        '
        Me.Btn_Filtro_Pro_Marcas.Image = CType(resources.GetObject("Btn_Filtro_Pro_Marcas.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Pro_Marcas.ImageAlt = CType(resources.GetObject("Btn_Filtro_Pro_Marcas.ImageAlt"), System.Drawing.Image)
        Me.Btn_Filtro_Pro_Marcas.Name = "Btn_Filtro_Pro_Marcas"
        Me.Btn_Filtro_Pro_Marcas.Text = "Filtrar por <b><font color=""#0072BC"">MARCAS</font></b>"
        '
        'Btn_Filtro_Pro_Categorias
        '
        Me.Btn_Filtro_Pro_Categorias.Image = CType(resources.GetObject("Btn_Filtro_Pro_Categorias.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Pro_Categorias.ImageAlt = CType(resources.GetObject("Btn_Filtro_Pro_Categorias.ImageAlt"), System.Drawing.Image)
        Me.Btn_Filtro_Pro_Categorias.Name = "Btn_Filtro_Pro_Categorias"
        Me.Btn_Filtro_Pro_Categorias.Text = "Filtrar por <b><font color=""#0072BC"">CATEGORIAS</font></b>"
        '
        'Btn_Filtro_Pro_Codigos_Madre
        '
        Me.Btn_Filtro_Pro_Codigos_Madre.Image = CType(resources.GetObject("Btn_Filtro_Pro_Codigos_Madre.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Pro_Codigos_Madre.ImageAlt = CType(resources.GetObject("Btn_Filtro_Pro_Codigos_Madre.ImageAlt"), System.Drawing.Image)
        Me.Btn_Filtro_Pro_Codigos_Madre.Name = "Btn_Filtro_Pro_Codigos_Madre"
        Me.Btn_Filtro_Pro_Codigos_Madre.Text = "Filtrar por <b><font color=""#0072BC"">CODIGOS MADRE</font></b>"
        '
        'Btn_Filtro_Pro_Clas_Libre
        '
        Me.Btn_Filtro_Pro_Clas_Libre.Image = CType(resources.GetObject("Btn_Filtro_Pro_Clas_Libre.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Pro_Clas_Libre.ImageAlt = CType(resources.GetObject("Btn_Filtro_Pro_Clas_Libre.ImageAlt"), System.Drawing.Image)
        Me.Btn_Filtro_Pro_Clas_Libre.Name = "Btn_Filtro_Pro_Clas_Libre"
        Me.Btn_Filtro_Pro_Clas_Libre.Text = "Filtrar por <b><font color=""#4E5D30""><font color=""#0072BC"">CLAS. LIBRE</font></fo" &
    "nt></b>"
        Me.Btn_Filtro_Pro_Clas_Libre.Visible = False
        '
        'Btn_Filtro_Pro_Rubros
        '
        Me.Btn_Filtro_Pro_Rubros.Image = CType(resources.GetObject("Btn_Filtro_Pro_Rubros.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Pro_Rubros.ImageAlt = CType(resources.GetObject("Btn_Filtro_Pro_Rubros.ImageAlt"), System.Drawing.Image)
        Me.Btn_Filtro_Pro_Rubros.Name = "Btn_Filtro_Pro_Rubros"
        Me.Btn_Filtro_Pro_Rubros.Text = "Filtrar por <b><font color=""#4E5D30""><font color=""#0072BC"">RUBROS</font></font></" &
    "b>"
        Me.Btn_Filtro_Pro_Rubros.Visible = False
        '
        'Btn_Filtro_Pro_Zonas
        '
        Me.Btn_Filtro_Pro_Zonas.Image = CType(resources.GetObject("Btn_Filtro_Pro_Zonas.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Pro_Zonas.ImageAlt = CType(resources.GetObject("Btn_Filtro_Pro_Zonas.ImageAlt"), System.Drawing.Image)
        Me.Btn_Filtro_Pro_Zonas.Name = "Btn_Filtro_Pro_Zonas"
        Me.Btn_Filtro_Pro_Zonas.Text = "Filtrar por <b><font color=""#4E5D30""><font color=""#0072BC"">ZONAS</font></font></b" &
    ">"
        Me.Btn_Filtro_Pro_Zonas.Visible = False
        '
        'Menu_Contextual_Filtros_Suc_Bod
        '
        Me.Menu_Contextual_Filtros_Suc_Bod.AutoExpandOnClick = True
        Me.Menu_Contextual_Filtros_Suc_Bod.Name = "Menu_Contextual_Filtros_Suc_Bod"
        Me.Menu_Contextual_Filtros_Suc_Bod.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem4, Me.Btn_Filtro_Sucursales, Me.Btn_Filtro_Bodegas})
        Me.Menu_Contextual_Filtros_Suc_Bod.Text = "Filtros Sucursales-Bodegas"
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
        Me.LabelItem4.Text = "Productos"
        '
        'Btn_Filtro_Sucursales
        '
        Me.Btn_Filtro_Sucursales.Image = CType(resources.GetObject("Btn_Filtro_Sucursales.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Sucursales.ImageAlt = CType(resources.GetObject("Btn_Filtro_Sucursales.ImageAlt"), System.Drawing.Image)
        Me.Btn_Filtro_Sucursales.Name = "Btn_Filtro_Sucursales"
        Me.Btn_Filtro_Sucursales.Text = "Filtrar por <b><font color=""#0072BC"">SUCURSALES</font></b>"
        '
        'Btn_Filtro_Bodegas
        '
        Me.Btn_Filtro_Bodegas.Image = CType(resources.GetObject("Btn_Filtro_Bodegas.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Bodegas.ImageAlt = CType(resources.GetObject("Btn_Filtro_Bodegas.ImageAlt"), System.Drawing.Image)
        Me.Btn_Filtro_Bodegas.Name = "Btn_Filtro_Bodegas"
        Me.Btn_Filtro_Bodegas.Text = "Filtrar por <b><font color=""#0072BC"">BODEGAS</font></b>"
        '
        'Menu_Contextual_Edicion_Datos
        '
        Me.Menu_Contextual_Edicion_Datos.AutoExpandOnClick = True
        Me.Menu_Contextual_Edicion_Datos.Name = "Menu_Contextual_Edicion_Datos"
        Me.Menu_Contextual_Edicion_Datos.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem9, Me.Btn_Cambiar_PromVntaPorc, Me.Btn_Cambiar_PromVntaValor})
        Me.Menu_Contextual_Edicion_Datos.Text = "Reparar datos..."
        '
        'LabelItem9
        '
        Me.LabelItem9.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem9.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem9.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem9.Name = "LabelItem9"
        Me.LabelItem9.PaddingBottom = 1
        Me.LabelItem9.PaddingLeft = 10
        Me.LabelItem9.PaddingTop = 1
        Me.LabelItem9.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem9.Text = "Simular"
        '
        'Btn_Cambiar_PromVntaPorc
        '
        Me.Btn_Cambiar_PromVntaPorc.Image = CType(resources.GetObject("Btn_Cambiar_PromVntaPorc.Image"), System.Drawing.Image)
        Me.Btn_Cambiar_PromVntaPorc.ImageAlt = CType(resources.GetObject("Btn_Cambiar_PromVntaPorc.ImageAlt"), System.Drawing.Image)
        Me.Btn_Cambiar_PromVntaPorc.Name = "Btn_Cambiar_PromVntaPorc"
        Me.Btn_Cambiar_PromVntaPorc.Text = "Cambiar la venta promedio (Porcentaje)"
        Me.Btn_Cambiar_PromVntaPorc.Visible = False
        '
        'Btn_Cambiar_PromVntaValor
        '
        Me.Btn_Cambiar_PromVntaValor.Image = CType(resources.GetObject("Btn_Cambiar_PromVntaValor.Image"), System.Drawing.Image)
        Me.Btn_Cambiar_PromVntaValor.ImageAlt = CType(resources.GetObject("Btn_Cambiar_PromVntaValor.ImageAlt"), System.Drawing.Image)
        Me.Btn_Cambiar_PromVntaValor.Name = "Btn_Cambiar_PromVntaValor"
        Me.Btn_Cambiar_PromVntaValor.Text = "Cambiar la venta promedio (Valor)"
        Me.Btn_Cambiar_PromVntaValor.Visible = False
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
        Me.Grilla.Size = New System.Drawing.Size(1057, 509)
        Me.Grilla.TabIndex = 3
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Actualizar_Informe, Me.Btn_Excel})
        Me.Bar1.Location = New System.Drawing.Point(0, 617)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(1067, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 104
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Actualizar_Informe
        '
        Me.Btn_Actualizar_Informe.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Actualizar_Informe.ForeColor = System.Drawing.Color.Black
        Me.Btn_Actualizar_Informe.Image = CType(resources.GetObject("Btn_Actualizar_Informe.Image"), System.Drawing.Image)
        Me.Btn_Actualizar_Informe.ImageAlt = CType(resources.GetObject("Btn_Actualizar_Informe.ImageAlt"), System.Drawing.Image)
        Me.Btn_Actualizar_Informe.Name = "Btn_Actualizar_Informe"
        Me.Btn_Actualizar_Informe.Text = "Actualizar"
        '
        'Btn_Excel
        '
        Me.Btn_Excel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Excel.ForeColor = System.Drawing.Color.Black
        Me.Btn_Excel.Image = CType(resources.GetObject("Btn_Excel.Image"), System.Drawing.Image)
        Me.Btn_Excel.Name = "Btn_Excel"
        Me.Btn_Excel.Tooltip = "Exportar a Excel"
        '
        'Btn_Filtrar_Suc_Bod
        '
        Me.Btn_Filtrar_Suc_Bod.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Filtrar_Suc_Bod.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Filtrar_Suc_Bod.Image = CType(resources.GetObject("Btn_Filtrar_Suc_Bod.Image"), System.Drawing.Image)
        Me.Btn_Filtrar_Suc_Bod.ImageAlt = CType(resources.GetObject("Btn_Filtrar_Suc_Bod.ImageAlt"), System.Drawing.Image)
        Me.Btn_Filtrar_Suc_Bod.Location = New System.Drawing.Point(611, 12)
        Me.Btn_Filtrar_Suc_Bod.Name = "Btn_Filtrar_Suc_Bod"
        Me.Btn_Filtrar_Suc_Bod.Size = New System.Drawing.Size(113, 25)
        Me.Btn_Filtrar_Suc_Bod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Filtrar_Suc_Bod.TabIndex = 115
        Me.Btn_Filtrar_Suc_Bod.Text = "Filtrar Suc-Bod"
        '
        'Btn_Filtrar_Productos
        '
        Me.Btn_Filtrar_Productos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Filtrar_Productos.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Filtrar_Productos.Image = CType(resources.GetObject("Btn_Filtrar_Productos.Image"), System.Drawing.Image)
        Me.Btn_Filtrar_Productos.ImageAlt = CType(resources.GetObject("Btn_Filtrar_Productos.ImageAlt"), System.Drawing.Image)
        Me.Btn_Filtrar_Productos.Location = New System.Drawing.Point(730, 12)
        Me.Btn_Filtrar_Productos.Name = "Btn_Filtrar_Productos"
        Me.Btn_Filtrar_Productos.Size = New System.Drawing.Size(119, 25)
        Me.Btn_Filtrar_Productos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Filtrar_Productos.TabIndex = 114
        Me.Btn_Filtrar_Productos.Text = "Filtrar Productos"
        '
        'Cmb_Vista_Informe
        '
        Me.Cmb_Vista_Informe.DisplayMember = "Text"
        Me.Cmb_Vista_Informe.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Vista_Informe.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Vista_Informe.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Vista_Informe.FormattingEnabled = True
        Me.Cmb_Vista_Informe.ItemHeight = 23
        Me.Cmb_Vista_Informe.Items.AddRange(New Object() {Me.ComboItem1, Me.ComboItem2, Me.ComboItem3, Me.ComboItem4})
        Me.Cmb_Vista_Informe.Location = New System.Drawing.Point(172, 43)
        Me.Cmb_Vista_Informe.MaximumSize = New System.Drawing.Size(322, 0)
        Me.Cmb_Vista_Informe.Name = "Cmb_Vista_Informe"
        Me.Cmb_Vista_Informe.Size = New System.Drawing.Size(315, 29)
        Me.Cmb_Vista_Informe.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Vista_Informe.TabIndex = 118
        '
        'ComboItem1
        '
        Me.ComboItem1.Text = "ComboItem1"
        '
        'ComboItem2
        '
        Me.ComboItem2.Text = "ComboItem2"
        '
        'ComboItem3
        '
        Me.ComboItem3.Text = "ComboItem3"
        '
        'ComboItem4
        '
        Me.ComboItem4.Text = "ComboItem4"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(15, 43)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(151, 23)
        Me.LabelX1.TabIndex = 119
        Me.LabelX1.Text = "VISTA DEL INFORME"
        '
        'Input_MesesEstudio
        '
        Me.Input_MesesEstudio.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_MesesEstudio.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_MesesEstudio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_MesesEstudio.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.Input_MesesEstudio.Enabled = False
        Me.Input_MesesEstudio.ForeColor = System.Drawing.Color.Black
        Me.Input_MesesEstudio.Location = New System.Drawing.Point(152, 11)
        Me.Input_MesesEstudio.MaxValue = 24
        Me.Input_MesesEstudio.MinValue = 1
        Me.Input_MesesEstudio.Name = "Input_MesesEstudio"
        Me.Input_MesesEstudio.ShowUpDown = True
        Me.Input_MesesEstudio.Size = New System.Drawing.Size(44, 22)
        Me.Input_MesesEstudio.TabIndex = 120
        Me.Input_MesesEstudio.Value = 3
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(15, 11)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(151, 23)
        Me.LabelX2.TabIndex = 121
        Me.LabelX2.Text = "Meses estudio prom. venta"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(202, 11)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(98, 23)
        Me.LabelX3.TabIndex = 123
        Me.LabelX3.Text = "Meses proyección"
        '
        'Input_MesesProyeccion
        '
        Me.Input_MesesProyeccion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_MesesProyeccion.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_MesesProyeccion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_MesesProyeccion.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.Input_MesesProyeccion.Enabled = False
        Me.Input_MesesProyeccion.ForeColor = System.Drawing.Color.Black
        Me.Input_MesesProyeccion.Location = New System.Drawing.Point(295, 11)
        Me.Input_MesesProyeccion.MaxValue = 12
        Me.Input_MesesProyeccion.MinValue = 3
        Me.Input_MesesProyeccion.Name = "Input_MesesProyeccion"
        Me.Input_MesesProyeccion.ShowUpDown = True
        Me.Input_MesesProyeccion.Size = New System.Drawing.Size(42, 22)
        Me.Input_MesesProyeccion.TabIndex = 122
        Me.Input_MesesProyeccion.Value = 6
        '
        'Btn_Bodega_Vta_Estudio
        '
        Me.Btn_Bodega_Vta_Estudio.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Bodega_Vta_Estudio.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Bodega_Vta_Estudio.Image = CType(resources.GetObject("Btn_Bodega_Vta_Estudio.Image"), System.Drawing.Image)
        Me.Btn_Bodega_Vta_Estudio.ImageAlt = CType(resources.GetObject("Btn_Bodega_Vta_Estudio.ImageAlt"), System.Drawing.Image)
        Me.Btn_Bodega_Vta_Estudio.Location = New System.Drawing.Point(355, 11)
        Me.Btn_Bodega_Vta_Estudio.Name = "Btn_Bodega_Vta_Estudio"
        Me.Btn_Bodega_Vta_Estudio.Size = New System.Drawing.Size(132, 22)
        Me.Btn_Bodega_Vta_Estudio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Bodega_Vta_Estudio.TabIndex = 124
        Me.Btn_Bodega_Vta_Estudio.Text = "Bodegas de estudio"
        Me.Btn_Bodega_Vta_Estudio.Visible = False
        '
        'Frm_InfProyStXVnta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1067, 658)
        Me.Controls.Add(Me.Btn_Bodega_Vta_Estudio)
        Me.Controls.Add(Me.Input_MesesProyeccion)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.Input_MesesEstudio)
        Me.Controls.Add(Me.Cmb_Vista_Informe)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Btn_Filtrar_Suc_Bod)
        Me.Controls.Add(Me.Btn_Filtrar_Productos)
        Me.Controls.Add(Me.Grupo_Venta_Diaria)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.LabelX2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "Frm_InfProyStXVnta"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        Me.Grupo_Venta_Diaria.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Input_MesesEstudio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Input_MesesProyeccion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Grupo_Venta_Diaria As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Excel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Filtrar_Suc_Bod As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Filtrar_Productos As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Cmb_Vista_Informe As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Actualizar_Informe As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ComboItem1 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem2 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem3 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem4 As DevComponents.Editors.ComboItem
    Friend WithEvents Input_MesesEstudio As DevComponents.Editors.IntegerInput
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Input_MesesProyeccion As DevComponents.Editors.IntegerInput
    Friend WithEvents Btn_Bodega_Vta_Estudio As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Menu_Contextual_Filtros_Productos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Public WithEvents Btn_Filtro_Pro_Productos As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Pro_Super_Familias As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Pro_Familias As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Pro_Sub_Familias As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Pro_Marcas As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Pro_Categorias As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Pro_Codigos_Madre As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Pro_Clas_Libre As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Pro_Rubros As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Pro_Zonas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Menu_Contextual_Filtros_Suc_Bod As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem4 As DevComponents.DotNetBar.LabelItem
    Public WithEvents Btn_Filtro_Sucursales As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Bodegas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_Edicion_Datos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem9 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Cambiar_PromVntaPorc As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Cambiar_PromVntaValor As DevComponents.DotNetBar.ButtonItem
End Class
