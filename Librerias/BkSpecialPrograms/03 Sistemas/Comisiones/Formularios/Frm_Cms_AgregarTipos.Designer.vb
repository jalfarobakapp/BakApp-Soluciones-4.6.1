<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Cms_AgregarTipos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Cms_AgregarTipos))
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Btn_Filtrar_Funcionarios = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Filtrar_Suc_Bod = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Filtrar_Productos = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Filtrar_Entidades = New DevComponents.DotNetBar.ButtonX()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_Filtros_Entidades = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem3 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Filtro_Ent_Entidades = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Ent_Ciudades = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Ent_Comunas = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Ent_Rubros = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Ent_Zonas = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Ent_Tipo_Entidad = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Ent_Act_Economica = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Ent_Tamano_Empresa = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Ent_Lista_Precio_Asig = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Ent_Lista_Precio_Doc = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem9 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Filtro_Ent_EntidadesExcluidas = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_Filtros_Productos = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Filtro_Pro_Productos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Pro_Super_Familias = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Pro_Familias = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Pro_Sub_Familias = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Pro_Marcas = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Pro_Clas_Libre = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Pro_Rubros = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Pro_Zonas = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem10 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Filtro_Pro_ProductosExcluidos = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_Filtros_Suc_Bod = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem4 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Filtro_SucursalDoc = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Sucursales = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Bodegas = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_Filtros_Funcionarios = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem5 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Filtro_Responzables = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Vendedores = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Vendedor_Asignado_Entidad = New DevComponents.DotNetBar.ButtonItem()
        Me.Txt_PorcComision = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Chk_TieneSC = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Descripcion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Eliminar = New DevComponents.DotNetBar.ButtonItem()
        Me.Imagenes_16x16 = New System.Windows.Forms.ImageList(Me.components)
        Me.Chk_MisVentas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Chk_MisVentas)
        Me.GroupPanel2.Controls.Add(Me.Btn_Filtrar_Funcionarios)
        Me.GroupPanel2.Controls.Add(Me.Btn_Filtrar_Suc_Bod)
        Me.GroupPanel2.Controls.Add(Me.Btn_Filtrar_Productos)
        Me.GroupPanel2.Controls.Add(Me.Btn_Filtrar_Entidades)
        Me.GroupPanel2.Controls.Add(Me.ContextMenuBar1)
        Me.GroupPanel2.Controls.Add(Me.Txt_PorcComision)
        Me.GroupPanel2.Controls.Add(Me.Chk_TieneSC)
        Me.GroupPanel2.Controls.Add(Me.LabelX2)
        Me.GroupPanel2.Controls.Add(Me.Txt_Descripcion)
        Me.GroupPanel2.Controls.Add(Me.LabelX1)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(12, 6)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(560, 184)
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
        Me.GroupPanel2.TabIndex = 163
        Me.GroupPanel2.Text = "Datos del funcionario"
        '
        'Btn_Filtrar_Funcionarios
        '
        Me.Btn_Filtrar_Funcionarios.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Filtrar_Funcionarios.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Filtrar_Funcionarios.Image = CType(resources.GetObject("Btn_Filtrar_Funcionarios.Image"), System.Drawing.Image)
        Me.Btn_Filtrar_Funcionarios.ImageAlt = CType(resources.GetObject("Btn_Filtrar_Funcionarios.ImageAlt"), System.Drawing.Image)
        Me.Btn_Filtrar_Funcionarios.Location = New System.Drawing.Point(375, 72)
        Me.Btn_Filtrar_Funcionarios.Name = "Btn_Filtrar_Funcionarios"
        Me.Btn_Filtrar_Funcionarios.Size = New System.Drawing.Size(126, 25)
        Me.Btn_Filtrar_Funcionarios.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Filtrar_Funcionarios.TabIndex = 123
        Me.Btn_Filtrar_Funcionarios.Text = "Filtrar funcionarios"
        '
        'Btn_Filtrar_Suc_Bod
        '
        Me.Btn_Filtrar_Suc_Bod.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Filtrar_Suc_Bod.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Filtrar_Suc_Bod.Image = CType(resources.GetObject("Btn_Filtrar_Suc_Bod.Image"), System.Drawing.Image)
        Me.Btn_Filtrar_Suc_Bod.ImageAlt = CType(resources.GetObject("Btn_Filtrar_Suc_Bod.ImageAlt"), System.Drawing.Image)
        Me.Btn_Filtrar_Suc_Bod.Location = New System.Drawing.Point(256, 72)
        Me.Btn_Filtrar_Suc_Bod.Name = "Btn_Filtrar_Suc_Bod"
        Me.Btn_Filtrar_Suc_Bod.Size = New System.Drawing.Size(113, 25)
        Me.Btn_Filtrar_Suc_Bod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Filtrar_Suc_Bod.TabIndex = 122
        Me.Btn_Filtrar_Suc_Bod.Text = "Filtrar Suc-Bod"
        '
        'Btn_Filtrar_Productos
        '
        Me.Btn_Filtrar_Productos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Filtrar_Productos.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Filtrar_Productos.Image = CType(resources.GetObject("Btn_Filtrar_Productos.Image"), System.Drawing.Image)
        Me.Btn_Filtrar_Productos.ImageAlt = CType(resources.GetObject("Btn_Filtrar_Productos.ImageAlt"), System.Drawing.Image)
        Me.Btn_Filtrar_Productos.Location = New System.Drawing.Point(131, 72)
        Me.Btn_Filtrar_Productos.Name = "Btn_Filtrar_Productos"
        Me.Btn_Filtrar_Productos.Size = New System.Drawing.Size(119, 25)
        Me.Btn_Filtrar_Productos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Filtrar_Productos.TabIndex = 121
        Me.Btn_Filtrar_Productos.Text = "Filtrar Productos"
        '
        'Btn_Filtrar_Entidades
        '
        Me.Btn_Filtrar_Entidades.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Filtrar_Entidades.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Filtrar_Entidades.Image = CType(resources.GetObject("Btn_Filtrar_Entidades.Image"), System.Drawing.Image)
        Me.Btn_Filtrar_Entidades.ImageAlt = CType(resources.GetObject("Btn_Filtrar_Entidades.ImageAlt"), System.Drawing.Image)
        Me.Btn_Filtrar_Entidades.Location = New System.Drawing.Point(3, 72)
        Me.Btn_Filtrar_Entidades.Name = "Btn_Filtrar_Entidades"
        Me.Btn_Filtrar_Entidades.Size = New System.Drawing.Size(122, 25)
        Me.Btn_Filtrar_Entidades.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Filtrar_Entidades.TabIndex = 120
        Me.Btn_Filtrar_Entidades.Text = "Filtrar Entidades"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_Filtros_Entidades, Me.Menu_Contextual_Filtros_Productos, Me.Menu_Contextual_Filtros_Suc_Bod, Me.Menu_Contextual_Filtros_Funcionarios})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(3, 103)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(582, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 119
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_Filtros_Entidades
        '
        Me.Menu_Contextual_Filtros_Entidades.AutoExpandOnClick = True
        Me.Menu_Contextual_Filtros_Entidades.Name = "Menu_Contextual_Filtros_Entidades"
        Me.Menu_Contextual_Filtros_Entidades.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem3, Me.Btn_Filtro_Ent_Entidades, Me.Btn_Filtro_Ent_Ciudades, Me.Btn_Filtro_Ent_Comunas, Me.Btn_Filtro_Ent_Rubros, Me.Btn_Filtro_Ent_Zonas, Me.Btn_Filtro_Ent_Tipo_Entidad, Me.Btn_Filtro_Ent_Act_Economica, Me.Btn_Filtro_Ent_Tamano_Empresa, Me.Btn_Filtro_Ent_Lista_Precio_Asig, Me.Btn_Filtro_Ent_Lista_Precio_Doc, Me.LabelItem9, Me.Btn_Filtro_Ent_EntidadesExcluidas})
        Me.Menu_Contextual_Filtros_Entidades.Text = "Filtros Entidades"
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
        'Btn_Filtro_Ent_Entidades
        '
        Me.Btn_Filtro_Ent_Entidades.Image = CType(resources.GetObject("Btn_Filtro_Ent_Entidades.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Ent_Entidades.ImageAlt = CType(resources.GetObject("Btn_Filtro_Ent_Entidades.ImageAlt"), System.Drawing.Image)
        Me.Btn_Filtro_Ent_Entidades.Name = "Btn_Filtro_Ent_Entidades"
        Me.Btn_Filtro_Ent_Entidades.Text = "Filtrar por <b><font color=""#0072BC"">CLIENTES</font></b>"
        '
        'Btn_Filtro_Ent_Ciudades
        '
        Me.Btn_Filtro_Ent_Ciudades.Image = CType(resources.GetObject("Btn_Filtro_Ent_Ciudades.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Ent_Ciudades.ImageAlt = CType(resources.GetObject("Btn_Filtro_Ent_Ciudades.ImageAlt"), System.Drawing.Image)
        Me.Btn_Filtro_Ent_Ciudades.Name = "Btn_Filtro_Ent_Ciudades"
        Me.Btn_Filtro_Ent_Ciudades.Text = "Filtrar por <b><font color=""#0072BC"">CIUDADES</font></b>"
        '
        'Btn_Filtro_Ent_Comunas
        '
        Me.Btn_Filtro_Ent_Comunas.Image = CType(resources.GetObject("Btn_Filtro_Ent_Comunas.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Ent_Comunas.ImageAlt = CType(resources.GetObject("Btn_Filtro_Ent_Comunas.ImageAlt"), System.Drawing.Image)
        Me.Btn_Filtro_Ent_Comunas.Name = "Btn_Filtro_Ent_Comunas"
        Me.Btn_Filtro_Ent_Comunas.Text = "Filtrar por <b><font color=""#0072BC"">COMUNAS</font></b>"
        '
        'Btn_Filtro_Ent_Rubros
        '
        Me.Btn_Filtro_Ent_Rubros.Image = CType(resources.GetObject("Btn_Filtro_Ent_Rubros.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Ent_Rubros.ImageAlt = CType(resources.GetObject("Btn_Filtro_Ent_Rubros.ImageAlt"), System.Drawing.Image)
        Me.Btn_Filtro_Ent_Rubros.Name = "Btn_Filtro_Ent_Rubros"
        Me.Btn_Filtro_Ent_Rubros.Text = "Filtrar por <b><font color=""#0072BC""><font color=""#0072BC"">RUBROS</font></font></" &
    "b>"
        '
        'Btn_Filtro_Ent_Zonas
        '
        Me.Btn_Filtro_Ent_Zonas.Image = CType(resources.GetObject("Btn_Filtro_Ent_Zonas.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Ent_Zonas.ImageAlt = CType(resources.GetObject("Btn_Filtro_Ent_Zonas.ImageAlt"), System.Drawing.Image)
        Me.Btn_Filtro_Ent_Zonas.Name = "Btn_Filtro_Ent_Zonas"
        Me.Btn_Filtro_Ent_Zonas.Text = "Filtrar por <b><font color=""#0072BC"">ZONAS</font></b>"
        '
        'Btn_Filtro_Ent_Tipo_Entidad
        '
        Me.Btn_Filtro_Ent_Tipo_Entidad.Image = CType(resources.GetObject("Btn_Filtro_Ent_Tipo_Entidad.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Ent_Tipo_Entidad.ImageAlt = CType(resources.GetObject("Btn_Filtro_Ent_Tipo_Entidad.ImageAlt"), System.Drawing.Image)
        Me.Btn_Filtro_Ent_Tipo_Entidad.Name = "Btn_Filtro_Ent_Tipo_Entidad"
        Me.Btn_Filtro_Ent_Tipo_Entidad.Text = "Filtrar por <b><font color=""#4E5D30""><font color=""#0072BC"">TIPO ENTIDAD</font></f" &
    "ont></b>"
        '
        'Btn_Filtro_Ent_Act_Economica
        '
        Me.Btn_Filtro_Ent_Act_Economica.Image = CType(resources.GetObject("Btn_Filtro_Ent_Act_Economica.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Ent_Act_Economica.ImageAlt = CType(resources.GetObject("Btn_Filtro_Ent_Act_Economica.ImageAlt"), System.Drawing.Image)
        Me.Btn_Filtro_Ent_Act_Economica.Name = "Btn_Filtro_Ent_Act_Economica"
        Me.Btn_Filtro_Ent_Act_Economica.Text = "Filtrar por <b><font color=""#4E5D30""><font color=""#0072BC"">ACT. ECONOMICA</font><" &
    "/font></b>"
        '
        'Btn_Filtro_Ent_Tamano_Empresa
        '
        Me.Btn_Filtro_Ent_Tamano_Empresa.Image = CType(resources.GetObject("Btn_Filtro_Ent_Tamano_Empresa.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Ent_Tamano_Empresa.ImageAlt = CType(resources.GetObject("Btn_Filtro_Ent_Tamano_Empresa.ImageAlt"), System.Drawing.Image)
        Me.Btn_Filtro_Ent_Tamano_Empresa.Name = "Btn_Filtro_Ent_Tamano_Empresa"
        Me.Btn_Filtro_Ent_Tamano_Empresa.Text = "Filtrar por <b><font color=""#4E5D30""><font color=""#0072BC"">TAMAÑO EMPRESA</font><" &
    "/font></b>"
        '
        'Btn_Filtro_Ent_Lista_Precio_Asig
        '
        Me.Btn_Filtro_Ent_Lista_Precio_Asig.Image = CType(resources.GetObject("Btn_Filtro_Ent_Lista_Precio_Asig.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Ent_Lista_Precio_Asig.ImageAlt = CType(resources.GetObject("Btn_Filtro_Ent_Lista_Precio_Asig.ImageAlt"), System.Drawing.Image)
        Me.Btn_Filtro_Ent_Lista_Precio_Asig.Name = "Btn_Filtro_Ent_Lista_Precio_Asig"
        Me.Btn_Filtro_Ent_Lista_Precio_Asig.Text = "Filtrar por <b><font color=""#4E5D30""><font color=""#0072BC"">LISTA PRECIO CLIENTE</" &
    "font></font></b>"
        Me.Btn_Filtro_Ent_Lista_Precio_Asig.Tooltip = "Lista de precios asociada a la entidad"
        '
        'Btn_Filtro_Ent_Lista_Precio_Doc
        '
        Me.Btn_Filtro_Ent_Lista_Precio_Doc.Image = CType(resources.GetObject("Btn_Filtro_Ent_Lista_Precio_Doc.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Ent_Lista_Precio_Doc.ImageAlt = CType(resources.GetObject("Btn_Filtro_Ent_Lista_Precio_Doc.ImageAlt"), System.Drawing.Image)
        Me.Btn_Filtro_Ent_Lista_Precio_Doc.Name = "Btn_Filtro_Ent_Lista_Precio_Doc"
        Me.Btn_Filtro_Ent_Lista_Precio_Doc.Text = "Filtrar por <b><font color=""#4E5D30""><font color=""#0072BC"">LISTA PRECIO ASOC. DET" &
    "ALLE</font></font></b>"
        Me.Btn_Filtro_Ent_Lista_Precio_Doc.Tooltip = "Lista de precios que finalmente se asigno al documento"
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
        Me.LabelItem9.Text = "Datos excluidos"
        '
        'Btn_Filtro_Ent_EntidadesExcluidas
        '
        Me.Btn_Filtro_Ent_EntidadesExcluidas.Image = CType(resources.GetObject("Btn_Filtro_Ent_EntidadesExcluidas.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Ent_EntidadesExcluidas.ImageAlt = CType(resources.GetObject("Btn_Filtro_Ent_EntidadesExcluidas.ImageAlt"), System.Drawing.Image)
        Me.Btn_Filtro_Ent_EntidadesExcluidas.Name = "Btn_Filtro_Ent_EntidadesExcluidas"
        Me.Btn_Filtro_Ent_EntidadesExcluidas.Text = "<font color=""#0072BC""><b><font color=""#ED1C24"">CLIENTES EXCLUIDOS</font></b></fon" &
    "t>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Menu_Contextual_Filtros_Productos
        '
        Me.Menu_Contextual_Filtros_Productos.AutoExpandOnClick = True
        Me.Menu_Contextual_Filtros_Productos.ImageAlt = CType(resources.GetObject("Menu_Contextual_Filtros_Productos.ImageAlt"), System.Drawing.Image)
        Me.Menu_Contextual_Filtros_Productos.Name = "Menu_Contextual_Filtros_Productos"
        Me.Menu_Contextual_Filtros_Productos.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem2, Me.Btn_Filtro_Pro_Productos, Me.Btn_Filtro_Pro_Super_Familias, Me.Btn_Filtro_Pro_Familias, Me.Btn_Filtro_Pro_Sub_Familias, Me.Btn_Filtro_Pro_Marcas, Me.Btn_Filtro_Pro_Clas_Libre, Me.Btn_Filtro_Pro_Rubros, Me.Btn_Filtro_Pro_Zonas, Me.LabelItem10, Me.Btn_Filtro_Pro_ProductosExcluidos})
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
        'Btn_Filtro_Pro_Clas_Libre
        '
        Me.Btn_Filtro_Pro_Clas_Libre.Image = CType(resources.GetObject("Btn_Filtro_Pro_Clas_Libre.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Pro_Clas_Libre.ImageAlt = CType(resources.GetObject("Btn_Filtro_Pro_Clas_Libre.ImageAlt"), System.Drawing.Image)
        Me.Btn_Filtro_Pro_Clas_Libre.Name = "Btn_Filtro_Pro_Clas_Libre"
        Me.Btn_Filtro_Pro_Clas_Libre.Text = "Filtrar por <b><font color=""#4E5D30""><font color=""#0072BC"">CLAS. LIBRE</font></fo" &
    "nt></b>"
        '
        'Btn_Filtro_Pro_Rubros
        '
        Me.Btn_Filtro_Pro_Rubros.Image = CType(resources.GetObject("Btn_Filtro_Pro_Rubros.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Pro_Rubros.ImageAlt = CType(resources.GetObject("Btn_Filtro_Pro_Rubros.ImageAlt"), System.Drawing.Image)
        Me.Btn_Filtro_Pro_Rubros.Name = "Btn_Filtro_Pro_Rubros"
        Me.Btn_Filtro_Pro_Rubros.Text = "Filtrar por <b><font color=""#4E5D30""><font color=""#0072BC"">RUBROS</font></font></" &
    "b>"
        '
        'Btn_Filtro_Pro_Zonas
        '
        Me.Btn_Filtro_Pro_Zonas.Image = CType(resources.GetObject("Btn_Filtro_Pro_Zonas.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Pro_Zonas.ImageAlt = CType(resources.GetObject("Btn_Filtro_Pro_Zonas.ImageAlt"), System.Drawing.Image)
        Me.Btn_Filtro_Pro_Zonas.Name = "Btn_Filtro_Pro_Zonas"
        Me.Btn_Filtro_Pro_Zonas.Text = "Filtrar por <b><font color=""#4E5D30""><font color=""#0072BC"">ZONAS</font></font></b" &
    ">"
        '
        'LabelItem10
        '
        Me.LabelItem10.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem10.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem10.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem10.Name = "LabelItem10"
        Me.LabelItem10.PaddingBottom = 1
        Me.LabelItem10.PaddingLeft = 10
        Me.LabelItem10.PaddingTop = 1
        Me.LabelItem10.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem10.Text = "Datos excluidos"
        '
        'Btn_Filtro_Pro_ProductosExcluidos
        '
        Me.Btn_Filtro_Pro_ProductosExcluidos.Image = CType(resources.GetObject("Btn_Filtro_Pro_ProductosExcluidos.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Pro_ProductosExcluidos.ImageAlt = CType(resources.GetObject("Btn_Filtro_Pro_ProductosExcluidos.ImageAlt"), System.Drawing.Image)
        Me.Btn_Filtro_Pro_ProductosExcluidos.Name = "Btn_Filtro_Pro_ProductosExcluidos"
        Me.Btn_Filtro_Pro_ProductosExcluidos.Text = "<font color=""#0072BC""><b><font color=""#ED1C24"">PRODUCTOS EXCLUIDOS</font></b></fo" &
    "nt>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Menu_Contextual_Filtros_Suc_Bod
        '
        Me.Menu_Contextual_Filtros_Suc_Bod.AutoExpandOnClick = True
        Me.Menu_Contextual_Filtros_Suc_Bod.Name = "Menu_Contextual_Filtros_Suc_Bod"
        Me.Menu_Contextual_Filtros_Suc_Bod.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem4, Me.Btn_Filtro_SucursalDoc, Me.Btn_Filtro_Sucursales, Me.Btn_Filtro_Bodegas})
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
        'Btn_Filtro_SucursalDoc
        '
        Me.Btn_Filtro_SucursalDoc.Image = CType(resources.GetObject("Btn_Filtro_SucursalDoc.Image"), System.Drawing.Image)
        Me.Btn_Filtro_SucursalDoc.ImageAlt = CType(resources.GetObject("Btn_Filtro_SucursalDoc.ImageAlt"), System.Drawing.Image)
        Me.Btn_Filtro_SucursalDoc.Name = "Btn_Filtro_SucursalDoc"
        Me.Btn_Filtro_SucursalDoc.Text = "Filtrar por <b><font color=""#0072BC"">SUCURSAL</font></b> (Emisora Doc. Encabezado" &
    ")"
        '
        'Btn_Filtro_Sucursales
        '
        Me.Btn_Filtro_Sucursales.Image = CType(resources.GetObject("Btn_Filtro_Sucursales.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Sucursales.ImageAlt = CType(resources.GetObject("Btn_Filtro_Sucursales.ImageAlt"), System.Drawing.Image)
        Me.Btn_Filtro_Sucursales.Name = "Btn_Filtro_Sucursales"
        Me.Btn_Filtro_Sucursales.Text = "Filtrar por <b><font color=""#0072BC"">SUCURSAL</font></b> (Línea Doc. Detalle)"
        '
        'Btn_Filtro_Bodegas
        '
        Me.Btn_Filtro_Bodegas.Image = CType(resources.GetObject("Btn_Filtro_Bodegas.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Bodegas.ImageAlt = CType(resources.GetObject("Btn_Filtro_Bodegas.ImageAlt"), System.Drawing.Image)
        Me.Btn_Filtro_Bodegas.Name = "Btn_Filtro_Bodegas"
        Me.Btn_Filtro_Bodegas.Text = "Filtrar por <b><font color=""#0072BC"">BODEGAS</font></b>"
        '
        'Menu_Contextual_Filtros_Funcionarios
        '
        Me.Menu_Contextual_Filtros_Funcionarios.AutoExpandOnClick = True
        Me.Menu_Contextual_Filtros_Funcionarios.Name = "Menu_Contextual_Filtros_Funcionarios"
        Me.Menu_Contextual_Filtros_Funcionarios.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem5, Me.Btn_Filtro_Responzables, Me.Btn_Filtro_Vendedores, Me.Btn_Filtro_Vendedor_Asignado_Entidad})
        Me.Menu_Contextual_Filtros_Funcionarios.Text = "Filtros Funcionarios"
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
        Me.LabelItem5.Text = "Productos"
        '
        'Btn_Filtro_Responzables
        '
        Me.Btn_Filtro_Responzables.Image = CType(resources.GetObject("Btn_Filtro_Responzables.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Responzables.ImageAlt = CType(resources.GetObject("Btn_Filtro_Responzables.ImageAlt"), System.Drawing.Image)
        Me.Btn_Filtro_Responzables.Name = "Btn_Filtro_Responzables"
        Me.Btn_Filtro_Responzables.Text = "Filtrar por <b><font color=""#0072BC"">RESPONSABLE</font></b>"
        '
        'Btn_Filtro_Vendedores
        '
        Me.Btn_Filtro_Vendedores.Image = CType(resources.GetObject("Btn_Filtro_Vendedores.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Vendedores.ImageAlt = CType(resources.GetObject("Btn_Filtro_Vendedores.ImageAlt"), System.Drawing.Image)
        Me.Btn_Filtro_Vendedores.Name = "Btn_Filtro_Vendedores"
        Me.Btn_Filtro_Vendedores.Text = "Filtrar por <b><font color=""#0072BC"">VENDEDOR</font></b>"
        '
        'Btn_Filtro_Vendedor_Asignado_Entidad
        '
        Me.Btn_Filtro_Vendedor_Asignado_Entidad.Image = CType(resources.GetObject("Btn_Filtro_Vendedor_Asignado_Entidad.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Vendedor_Asignado_Entidad.ImageAlt = CType(resources.GetObject("Btn_Filtro_Vendedor_Asignado_Entidad.ImageAlt"), System.Drawing.Image)
        Me.Btn_Filtro_Vendedor_Asignado_Entidad.Name = "Btn_Filtro_Vendedor_Asignado_Entidad"
        Me.Btn_Filtro_Vendedor_Asignado_Entidad.Text = "Filtrar por <b><font color=""#0072BC"">VENDEDOR ASIGNADO</font></b>"
        '
        'Txt_PorcComision
        '
        Me.Txt_PorcComision.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_PorcComision.Border.Class = "TextBoxBorder"
        Me.Txt_PorcComision.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_PorcComision.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_PorcComision.ForeColor = System.Drawing.Color.Black
        Me.Txt_PorcComision.Location = New System.Drawing.Point(151, 35)
        Me.Txt_PorcComision.Name = "Txt_PorcComision"
        Me.Txt_PorcComision.Size = New System.Drawing.Size(54, 22)
        Me.Txt_PorcComision.TabIndex = 42
        Me.Txt_PorcComision.Text = "0"
        Me.Txt_PorcComision.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Chk_TieneSC
        '
        Me.Chk_TieneSC.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_TieneSC.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_TieneSC.CheckBoxImageChecked = CType(resources.GetObject("Chk_TieneSC.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_TieneSC.FocusCuesEnabled = False
        Me.Chk_TieneSC.ForeColor = System.Drawing.Color.Black
        Me.Chk_TieneSC.Location = New System.Drawing.Point(3, 134)
        Me.Chk_TieneSC.Name = "Chk_TieneSC"
        Me.Chk_TieneSC.Size = New System.Drawing.Size(242, 23)
        Me.Chk_TieneSC.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_TieneSC.TabIndex = 41
        Me.Chk_TieneSC.Text = "Tiene comisión bruta sujeta a semana corrida"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 32)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 23)
        Me.LabelX2.TabIndex = 2
        Me.LabelX2.Text = "% Comisión"
        '
        'Txt_Descripcion
        '
        Me.Txt_Descripcion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Descripcion.Border.Class = "TextBoxBorder"
        Me.Txt_Descripcion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Descripcion.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Descripcion.ForeColor = System.Drawing.Color.Black
        Me.Txt_Descripcion.Location = New System.Drawing.Point(151, 4)
        Me.Txt_Descripcion.MaxLength = 30
        Me.Txt_Descripcion.Name = "Txt_Descripcion"
        Me.Txt_Descripcion.PreventEnterBeep = True
        Me.Txt_Descripcion.Size = New System.Drawing.Size(400, 22)
        Me.Txt_Descripcion.TabIndex = 1
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
        Me.LabelX1.Size = New System.Drawing.Size(142, 23)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "Nombre comisión"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar, Me.Btn_Eliminar})
        Me.Bar2.Location = New System.Drawing.Point(0, 205)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(583, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 162
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.ImageAlt = CType(resources.GetObject("Btn_Grabar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Tooltip = "Grabar"
        '
        'Btn_Eliminar
        '
        Me.Btn_Eliminar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Eliminar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Eliminar.Image = CType(resources.GetObject("Btn_Eliminar.Image"), System.Drawing.Image)
        Me.Btn_Eliminar.ImageAlt = CType(resources.GetObject("Btn_Eliminar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Eliminar.Name = "Btn_Eliminar"
        Me.Btn_Eliminar.Tooltip = "Eliminar comisión"
        '
        'Imagenes_16x16
        '
        Me.Imagenes_16x16.ImageStream = CType(resources.GetObject("Imagenes_16x16.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagenes_16x16.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagenes_16x16.Images.SetKeyName(0, "filter.png")
        Me.Imagenes_16x16.Images.SetKeyName(1, "ok.png")
        Me.Imagenes_16x16.Images.SetKeyName(2, "delete.png")
        '
        'Chk_MisVentas
        '
        Me.Chk_MisVentas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_MisVentas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_MisVentas.CheckBoxImageChecked = CType(resources.GetObject("Chk_MisVentas.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_MisVentas.FocusCuesEnabled = False
        Me.Chk_MisVentas.ForeColor = System.Drawing.Color.Black
        Me.Chk_MisVentas.Location = New System.Drawing.Point(259, 134)
        Me.Chk_MisVentas.Name = "Chk_MisVentas"
        Me.Chk_MisVentas.Size = New System.Drawing.Size(81, 23)
        Me.Chk_MisVentas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_MisVentas.TabIndex = 124
        Me.Chk_MisVentas.TabStop = False
        Me.Chk_MisVentas.Text = "Mis ventas"
        '
        'Frm_Cms_AgregarTipos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(583, 246)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.Bar2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Cms_AgregarTipos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Descripcion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Eliminar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Chk_TieneSC As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Txt_PorcComision As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_Filtros_Entidades As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem3 As DevComponents.DotNetBar.LabelItem
    Public WithEvents Btn_Filtro_Ent_Entidades As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Ent_Ciudades As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Ent_Comunas As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Ent_Rubros As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Ent_Zonas As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Ent_Tipo_Entidad As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Ent_Act_Economica As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Ent_Tamano_Empresa As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Ent_Lista_Precio_Asig As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Ent_Lista_Precio_Doc As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem9 As DevComponents.DotNetBar.LabelItem
    Public WithEvents Btn_Filtro_Ent_EntidadesExcluidas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Menu_Contextual_Filtros_Productos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Public WithEvents Btn_Filtro_Pro_Productos As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Pro_Super_Familias As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Pro_Familias As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Pro_Sub_Familias As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Pro_Marcas As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Pro_Clas_Libre As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Pro_Rubros As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Pro_Zonas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem10 As DevComponents.DotNetBar.LabelItem
    Public WithEvents Btn_Filtro_Pro_ProductosExcluidos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Menu_Contextual_Filtros_Suc_Bod As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem4 As DevComponents.DotNetBar.LabelItem
    Public WithEvents Btn_Filtro_SucursalDoc As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Sucursales As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Bodegas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Menu_Contextual_Filtros_Funcionarios As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem5 As DevComponents.DotNetBar.LabelItem
    Public WithEvents Btn_Filtro_Responzables As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Vendedores As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Vendedor_Asignado_Entidad As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Filtrar_Funcionarios As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Filtrar_Suc_Bod As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Filtrar_Productos As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Filtrar_Entidades As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Imagenes_16x16 As ImageList
    Friend WithEvents Chk_MisVentas As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
