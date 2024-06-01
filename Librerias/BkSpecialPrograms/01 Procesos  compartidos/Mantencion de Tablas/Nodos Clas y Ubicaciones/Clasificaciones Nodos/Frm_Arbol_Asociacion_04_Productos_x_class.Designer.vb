<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Arbol_Asociacion_04_Productos_x_class
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Arbol_Asociacion_04_Productos_x_class))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Exportar_Excel = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_AgregarProductos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Quitar_Productos = New DevComponents.DotNetBar.ButtonItem()
        Me.Barra_Progreso_ = New DevComponents.DotNetBar.Controls.ProgressBarX()
        Me.Txt_Filtrar = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_01 = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.Mnu_Btn_Ver_Asociaciones_Del_Producto = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Estadisticas_Producto = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Reparara_Arbol_Del_Producto = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Ver_documento_origen = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_02 = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Quitar_Marcados = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Quitar_Todo = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Quitar_Huachos = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.LabelItem3 = New DevComponents.DotNetBar.LabelItem()
        Me.ButtonItem3 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem5 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem6 = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Reparar_Arbol = New DevComponents.DotNetBar.ButtonItem()
        Me.Metro_Bar_Color = New DevComponents.DotNetBar.Metro.MetroStatusBar()
        Me.Lbl_Estatus = New DevComponents.DotNetBar.LabelItem()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Codigo_Madre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Codigo_Nodo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Lbl_Codigo_Nodo = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Descripcion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Codigo_Madre = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Btn_QuitarProducto = New DevComponents.DotNetBar.ButtonItem()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Exportar_Excel, Me.Btn_AgregarProductos, Me.Btn_Quitar_Productos})
        Me.Bar2.Location = New System.Drawing.Point(0, 569)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(632, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 44
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Exportar_Excel
        '
        Me.Btn_Exportar_Excel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Exportar_Excel.ForeColor = System.Drawing.Color.Black
        Me.Btn_Exportar_Excel.Image = CType(resources.GetObject("Btn_Exportar_Excel.Image"), System.Drawing.Image)
        Me.Btn_Exportar_Excel.ImageAlt = CType(resources.GetObject("Btn_Exportar_Excel.ImageAlt"), System.Drawing.Image)
        Me.Btn_Exportar_Excel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Exportar_Excel.Name = "Btn_Exportar_Excel"
        Me.Btn_Exportar_Excel.Tooltip = "Exportar a Excel"
        '
        'Btn_AgregarProductos
        '
        Me.Btn_AgregarProductos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_AgregarProductos.ForeColor = System.Drawing.Color.Black
        Me.Btn_AgregarProductos.Image = CType(resources.GetObject("Btn_AgregarProductos.Image"), System.Drawing.Image)
        Me.Btn_AgregarProductos.ImageAlt = CType(resources.GetObject("Btn_AgregarProductos.ImageAlt"), System.Drawing.Image)
        Me.Btn_AgregarProductos.Name = "Btn_AgregarProductos"
        Me.Btn_AgregarProductos.Text = "Agregar productos"
        '
        'Btn_Quitar_Productos
        '
        Me.Btn_Quitar_Productos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Quitar_Productos.ForeColor = System.Drawing.Color.Black
        Me.Btn_Quitar_Productos.Image = CType(resources.GetObject("Btn_Quitar_Productos.Image"), System.Drawing.Image)
        Me.Btn_Quitar_Productos.ImageAlt = CType(resources.GetObject("Btn_Quitar_Productos.ImageAlt"), System.Drawing.Image)
        Me.Btn_Quitar_Productos.Name = "Btn_Quitar_Productos"
        Me.Btn_Quitar_Productos.Text = "Quitar productos (marcados)"
        '
        'Barra_Progreso_
        '
        Me.Barra_Progreso_.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Barra_Progreso_.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Barra_Progreso_.ForeColor = System.Drawing.Color.Black
        Me.Barra_Progreso_.Location = New System.Drawing.Point(652, 194)
        Me.Barra_Progreso_.Name = "Barra_Progreso_"
        Me.Barra_Progreso_.Size = New System.Drawing.Size(606, 26)
        Me.Barra_Progreso_.TabIndex = 49
        Me.Barra_Progreso_.Text = "Barra estado..."
        Me.Barra_Progreso_.TextVisible = True
        '
        'Txt_Filtrar
        '
        Me.Txt_Filtrar.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Descripcion.Border.Class = "TextBoxBorder"
        Me.Txt_Descripcion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Filtrar.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Filtrar.ForeColor = System.Drawing.Color.Black
        Me.Txt_Filtrar.Location = New System.Drawing.Point(72, 118)
        Me.Txt_Filtrar.Name = "Txt_Filtrar"
        Me.Txt_Filtrar.PreventEnterBeep = True
        Me.Txt_Filtrar.Size = New System.Drawing.Size(548, 22)
        Me.Txt_Filtrar.TabIndex = 2
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.ContextMenuBar1)
        Me.GroupPanel2.Controls.Add(Me.Grilla)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(9, 147)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(611, 416)
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
        Me.GroupPanel2.TabIndex = 51
        Me.GroupPanel2.Text = "Detalle de productos en carpeta"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_01, Me.Menu_Contextual_02})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(112, 124)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(334, 25)
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
        Me.Menu_Contextual_01.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1, Me.Mnu_Btn_Ver_Asociaciones_Del_Producto, Me.Btn_Estadisticas_Producto, Me.Btn_Reparara_Arbol_Del_Producto, Me.Btn_QuitarProducto, Me.Btn_Ver_documento_origen})
        Me.Menu_Contextual_01.Text = "Opciones"
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
        Me.LabelItem1.Text = "Opciones dela línea"
        '
        'Mnu_Btn_Ver_Asociaciones_Del_Producto
        '
        Me.Mnu_Btn_Ver_Asociaciones_Del_Producto.Image = CType(resources.GetObject("Mnu_Btn_Ver_Asociaciones_Del_Producto.Image"), System.Drawing.Image)
        Me.Mnu_Btn_Ver_Asociaciones_Del_Producto.ImageAlt = CType(resources.GetObject("Mnu_Btn_Ver_Asociaciones_Del_Producto.ImageAlt"), System.Drawing.Image)
        Me.Mnu_Btn_Ver_Asociaciones_Del_Producto.Name = "Mnu_Btn_Ver_Asociaciones_Del_Producto"
        Me.Mnu_Btn_Ver_Asociaciones_Del_Producto.Text = "Ver arbol de asocioaciones del producto"
        '
        'Btn_Estadisticas_Producto
        '
        Me.Btn_Estadisticas_Producto.Image = CType(resources.GetObject("Btn_Estadisticas_Producto.Image"), System.Drawing.Image)
        Me.Btn_Estadisticas_Producto.ImageAlt = CType(resources.GetObject("Btn_Estadisticas_Producto.ImageAlt"), System.Drawing.Image)
        Me.Btn_Estadisticas_Producto.Name = "Btn_Estadisticas_Producto"
        Me.Btn_Estadisticas_Producto.Text = "Ver estadísticas del producto/información adicional"
        '
        'Btn_Reparara_Arbol_Del_Producto
        '
        Me.Btn_Reparara_Arbol_Del_Producto.Image = CType(resources.GetObject("Btn_Reparara_Arbol_Del_Producto.Image"), System.Drawing.Image)
        Me.Btn_Reparara_Arbol_Del_Producto.ImageAlt = CType(resources.GetObject("Btn_Reparara_Arbol_Del_Producto.ImageAlt"), System.Drawing.Image)
        Me.Btn_Reparara_Arbol_Del_Producto.Name = "Btn_Reparara_Arbol_Del_Producto"
        Me.Btn_Reparara_Arbol_Del_Producto.Text = "Reparar Arbol Del Producto"
        '
        'Btn_Ver_documento_origen
        '
        Me.Btn_Ver_documento_origen.Image = CType(resources.GetObject("Btn_Ver_documento_origen.Image"), System.Drawing.Image)
        Me.Btn_Ver_documento_origen.ImageAlt = CType(resources.GetObject("Btn_Ver_documento_origen.ImageAlt"), System.Drawing.Image)
        Me.Btn_Ver_documento_origen.Name = "Btn_Ver_documento_origen"
        Me.Btn_Ver_documento_origen.Text = "Copiar"
        '
        'Menu_Contextual_02
        '
        Me.Menu_Contextual_02.AutoExpandOnClick = True
        Me.Menu_Contextual_02.Name = "Menu_Contextual_02"
        Me.Menu_Contextual_02.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem2, Me.Btn_Quitar_Marcados, Me.Btn_Quitar_Todo, Me.Btn_Quitar_Huachos})
        Me.Menu_Contextual_02.Text = "Opciones quitar productos"
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
        Me.LabelItem2.Text = "Quitar productos"
        '
        'Btn_Quitar_Marcados
        '
        Me.Btn_Quitar_Marcados.Image = CType(resources.GetObject("Btn_Quitar_Marcados.Image"), System.Drawing.Image)
        Me.Btn_Quitar_Marcados.ImageAlt = CType(resources.GetObject("Btn_Quitar_Marcados.ImageAlt"), System.Drawing.Image)
        Me.Btn_Quitar_Marcados.Name = "Btn_Quitar_Marcados"
        Me.Btn_Quitar_Marcados.Text = "Quitar solo productos seleccionados"
        '
        'Btn_Quitar_Todo
        '
        Me.Btn_Quitar_Todo.Image = CType(resources.GetObject("Btn_Quitar_Todo.Image"), System.Drawing.Image)
        Me.Btn_Quitar_Todo.ImageAlt = CType(resources.GetObject("Btn_Quitar_Todo.ImageAlt"), System.Drawing.Image)
        Me.Btn_Quitar_Todo.Name = "Btn_Quitar_Todo"
        Me.Btn_Quitar_Todo.Text = "Quitar todos los productos"
        '
        'Btn_Quitar_Huachos
        '
        Me.Btn_Quitar_Huachos.Image = CType(resources.GetObject("Btn_Quitar_Huachos.Image"), System.Drawing.Image)
        Me.Btn_Quitar_Huachos.ImageAlt = CType(resources.GetObject("Btn_Quitar_Huachos.ImageAlt"), System.Drawing.Image)
        Me.Btn_Quitar_Huachos.Name = "Btn_Quitar_Huachos"
        Me.Btn_Quitar_Huachos.Text = "Quita los productos que no tienen asignación hacia algún hijo de esta carpeta pad" &
    "re"
        Me.Btn_Quitar_Huachos.Visible = False
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
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
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Grilla.RowHeadersVisible = False
        Me.Grilla.RowTemplate.Height = 25
        Me.Grilla.Size = New System.Drawing.Size(605, 393)
        Me.Grilla.TabIndex = 54
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
        Me.LabelItem3.Text = "Opciones dela línea"
        '
        'ButtonItem3
        '
        Me.ButtonItem3.Image = CType(resources.GetObject("ButtonItem3.Image"), System.Drawing.Image)
        Me.ButtonItem3.Name = "ButtonItem3"
        Me.ButtonItem3.Text = "Ver arbol de asocioaciones del producto"
        '
        'ButtonItem5
        '
        Me.ButtonItem5.Image = CType(resources.GetObject("ButtonItem5.Image"), System.Drawing.Image)
        Me.ButtonItem5.Name = "ButtonItem5"
        Me.ButtonItem5.Text = "Ver estadísticas del producto/información adicional"
        '
        'ButtonItem6
        '
        Me.ButtonItem6.Image = CType(resources.GetObject("ButtonItem6.Image"), System.Drawing.Image)
        Me.ButtonItem6.Name = "ButtonItem6"
        Me.ButtonItem6.Text = "Reparar Arbol Del Producto"
        '
        'Btn_Reparar_Arbol
        '
        Me.Btn_Reparar_Arbol.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Reparar_Arbol.ForeColor = System.Drawing.Color.Black
        Me.Btn_Reparar_Arbol.Image = CType(resources.GetObject("Btn_Reparar_Arbol.Image"), System.Drawing.Image)
        Me.Btn_Reparar_Arbol.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Reparar_Arbol.Name = "Btn_Reparar_Arbol"
        Me.Btn_Reparar_Arbol.Tooltip = "Reparar árbol"
        Me.Btn_Reparar_Arbol.Visible = False
        '
        'Metro_Bar_Color
        '
        Me.Metro_Bar_Color.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Metro_Bar_Color.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Metro_Bar_Color.ContainerControlProcessDialogKey = True
        Me.Metro_Bar_Color.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Metro_Bar_Color.DragDropSupport = True
        Me.Metro_Bar_Color.Font = New System.Drawing.Font("Segoe UI", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Metro_Bar_Color.ForeColor = System.Drawing.Color.Black
        Me.Metro_Bar_Color.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Lbl_Estatus})
        Me.Metro_Bar_Color.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.Metro_Bar_Color.Location = New System.Drawing.Point(0, 610)
        Me.Metro_Bar_Color.Name = "Metro_Bar_Color"
        Me.Metro_Bar_Color.Size = New System.Drawing.Size(632, 22)
        Me.Metro_Bar_Color.TabIndex = 173
        Me.Metro_Bar_Color.Text = "MetroStatusBar1"
        '
        'Lbl_Estatus
        '
        Me.Lbl_Estatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Estatus.Name = "Lbl_Estatus"
        Me.Lbl_Estatus.Text = "LabelItem2"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Image = CType(resources.GetObject("LabelX1.Image"), System.Drawing.Image)
        Me.LabelX1.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right
        Me.LabelX1.ImageTextSpacing = 3
        Me.LabelX1.Location = New System.Drawing.Point(9, 118)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(57, 23)
        Me.LabelX1.TabIndex = 174
        Me.LabelX1.Text = "Buscar"
        '
        'Txt_Codigo_Madre
        '
        Me.Txt_Codigo_Madre.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Codigo_Madre.Border.Class = "TextBoxBorder"
        Me.Txt_Codigo_Madre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Codigo_Madre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Codigo_Madre.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Codigo_Madre.ForeColor = System.Drawing.Color.Black
        Me.Txt_Codigo_Madre.Location = New System.Drawing.Point(90, 4)
        Me.Txt_Codigo_Madre.Name = "Txt_Codigo_Madre"
        Me.Txt_Codigo_Madre.PreventEnterBeep = True
        Me.Txt_Codigo_Madre.ReadOnly = True
        Me.Txt_Codigo_Madre.Size = New System.Drawing.Size(109, 22)
        Me.Txt_Codigo_Madre.TabIndex = 175
        '
        'Txt_Codigo_Nodo
        '
        Me.Txt_Codigo_Nodo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Codigo_Nodo.Border.Class = "TextBoxBorder"
        Me.Txt_Codigo_Nodo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Codigo_Nodo.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Codigo_Nodo.ForeColor = System.Drawing.Color.Black
        Me.Txt_Codigo_Nodo.Location = New System.Drawing.Point(291, 3)
        Me.Txt_Codigo_Nodo.Name = "Txt_Codigo_Nodo"
        Me.Txt_Codigo_Nodo.PreventEnterBeep = True
        Me.Txt_Codigo_Nodo.ReadOnly = True
        Me.Txt_Codigo_Nodo.Size = New System.Drawing.Size(109, 22)
        Me.Txt_Codigo_Nodo.TabIndex = 176
        '
        'Lbl_Codigo_Nodo
        '
        Me.Lbl_Codigo_Nodo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Codigo_Nodo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Codigo_Nodo.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Codigo_Nodo.Location = New System.Drawing.Point(217, 4)
        Me.Lbl_Codigo_Nodo.Name = "Lbl_Codigo_Nodo"
        Me.Lbl_Codigo_Nodo.Size = New System.Drawing.Size(85, 23)
        Me.Lbl_Codigo_Nodo.TabIndex = 180
        Me.Lbl_Codigo_Nodo.Text = "Código Nodo"
        '
        'Txt_Descripcion
        '
        Me.Txt_Descripcion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Descripcion.Border.Class = "TextBoxBorder"
        Me.Txt_Descripcion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Descripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Descripcion.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Descripcion.ForeColor = System.Drawing.Color.Black
        Me.Txt_Descripcion.Location = New System.Drawing.Point(90, 32)
        Me.Txt_Descripcion.Multiline = True
        Me.Txt_Descripcion.Name = "Txt_Descripcion"
        Me.Txt_Descripcion.PreventEnterBeep = True
        Me.Txt_Descripcion.ReadOnly = True
        Me.Txt_Descripcion.Size = New System.Drawing.Size(512, 42)
        Me.Txt_Descripcion.TabIndex = 177
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
        Me.LabelX2.Size = New System.Drawing.Size(68, 23)
        Me.LabelX2.TabIndex = 179
        Me.LabelX2.Text = "Descripción"
        '
        'Lbl_Codigo_Madre
        '
        Me.Lbl_Codigo_Madre.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Codigo_Madre.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Codigo_Madre.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Codigo_Madre.Location = New System.Drawing.Point(3, 3)
        Me.Lbl_Codigo_Madre.Name = "Lbl_Codigo_Madre"
        Me.Lbl_Codigo_Madre.Size = New System.Drawing.Size(86, 23)
        Me.Lbl_Codigo_Madre.TabIndex = 178
        Me.Lbl_Codigo_Madre.Text = "Código Madre"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Lbl_Codigo_Madre)
        Me.GroupPanel1.Controls.Add(Me.Txt_Codigo_Madre)
        Me.GroupPanel1.Controls.Add(Me.LabelX2)
        Me.GroupPanel1.Controls.Add(Me.Txt_Codigo_Nodo)
        Me.GroupPanel1.Controls.Add(Me.Txt_Descripcion)
        Me.GroupPanel1.Controls.Add(Me.Lbl_Codigo_Nodo)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(9, 12)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(611, 100)
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
        Me.GroupPanel1.TabIndex = 181
        Me.GroupPanel1.Text = "Clasificación"
        '
        'Btn_QuitarProducto
        '
        Me.Btn_QuitarProducto.Image = CType(resources.GetObject("Btn_QuitarProducto.Image"), System.Drawing.Image)
        Me.Btn_QuitarProducto.ImageAlt = CType(resources.GetObject("Btn_QuitarProducto.ImageAlt"), System.Drawing.Image)
        Me.Btn_QuitarProducto.Name = "Btn_QuitarProducto"
        Me.Btn_QuitarProducto.Text = "Quitar este producto"
        '
        'Frm_Arbol_Asociacion_04_Productos_x_class
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(632, 632)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Txt_Filtrar)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.Barra_Progreso_)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.Metro_Bar_Color)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Arbol_Asociacion_04_Productos_x_class"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Public WithEvents Btn_AgregarProductos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Barra_Progreso_ As DevComponents.DotNetBar.Controls.ProgressBarX
    Public WithEvents Btn_Exportar_Excel As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Txt_Filtrar As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_01 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Mnu_Btn_Ver_Asociaciones_Del_Producto As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Estadisticas_Producto As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Reparara_Arbol_Del_Producto As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Quitar_Productos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Menu_Contextual_02 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Quitar_Marcados As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Quitar_Todo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem3 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents ButtonItem3 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem5 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem6 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Quitar_Huachos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Ver_documento_origen As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Btn_Reparar_Arbol As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Metro_Bar_Color As DevComponents.DotNetBar.Metro.MetroStatusBar
    Friend WithEvents Lbl_Estatus As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Codigo_Madre As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Txt_Codigo_Nodo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Lbl_Codigo_Nodo As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Descripcion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Codigo_Madre As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Btn_QuitarProducto As DevComponents.DotNetBar.ButtonItem
End Class
