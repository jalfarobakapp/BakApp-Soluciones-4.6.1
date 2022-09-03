<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_LcProv_Mantencion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_LcProv_Mantencion))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Btn_Cancelar = New DevComponents.DotNetBar.ButtonX()
        Me.Circular_Progres_Porc = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.Lbl_Procesando = New DevComponents.DotNetBar.LabelX()
        Me.Circular_Progres_Val = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.Grupo_Rut = New System.Windows.Forms.GroupBox()
        Me.Lbl_Rtu = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_Productos = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Estadisticas_Producto_01 = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_Copiar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Estadisticas_Producto_02 = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Copiar_datos = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_Formula = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Estadisticas_Producto_03 = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem4 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Ejecutar_Formula = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Configurar_Formula_Linea = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem5 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Copiar_Formula = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Copiar_Datos_Precios = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_Costo = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem6 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_PM_Linea = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_UC_Linea = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_Tratamiento = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem3 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Buscar_Un_Producto = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Busqueda_Selectiva = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Busqueda_Class = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Traer_Todos_Los_Productos = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnCambiarLista = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Importar_Desde_Excel = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla = New System.Windows.Forms.DataGridView()
        Me.Barra_Abajo = New DevComponents.DotNetBar.Bar()
        Me.BtnGrabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Limpiar = New DevComponents.DotNetBar.ButtonItem()
        Me.Chk_Marcar_Todo = New DevComponents.DotNetBar.CheckBoxItem()
        Me.Btn_Exportar_Excel = New DevComponents.DotNetBar.ButtonItem()
        Me.Txt_Funcion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Grupo_Costo_Ud1 = New System.Windows.Forms.GroupBox()
        Me.Lbl_Costo_Ultima_Compra_Ud1 = New DevComponents.DotNetBar.LabelX()
        Me.Grupo_Costo_Ud2 = New System.Windows.Forms.GroupBox()
        Me.Lbl_Costo_Ultima_Compra_Ud2 = New DevComponents.DotNetBar.LabelX()
        Me.Grupo_PM = New System.Windows.Forms.GroupBox()
        Me.Lbl_Costo_PM = New DevComponents.DotNetBar.LabelX()
        Me.Chk_Ud1_X_Ud2 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Txt_Descripcion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Btn_Conf_Funcion = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_Proveedor = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Grupo_Rut.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Barra_Abajo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_Costo_Ud1.SuspendLayout()
        Me.Grupo_Costo_Ud2.SuspendLayout()
        Me.Grupo_PM.SuspendLayout()
        Me.SuspendLayout()
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Cancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Cancelar.Image = CType(resources.GetObject("Btn_Cancelar.Image"), System.Drawing.Image)
        Me.Btn_Cancelar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Cancelar.Location = New System.Drawing.Point(557, 445)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Size = New System.Drawing.Size(51, 44)
        Me.Btn_Cancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Cancelar.TabIndex = 91
        Me.Btn_Cancelar.Text = "Cancelar"
        Me.Btn_Cancelar.Visible = False
        '
        'Circular_Progres_Porc
        '
        Me.Circular_Progres_Porc.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Circular_Progres_Porc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Circular_Progres_Porc.Location = New System.Drawing.Point(476, 445)
        Me.Circular_Progres_Porc.Name = "Circular_Progres_Porc"
        Me.Circular_Progres_Porc.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.Circular_Progres_Porc.ProgressColor = System.Drawing.Color.SteelBlue
        Me.Circular_Progres_Porc.ProgressTextVisible = True
        Me.Circular_Progres_Porc.Size = New System.Drawing.Size(75, 44)
        Me.Circular_Progres_Porc.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.Circular_Progres_Porc.TabIndex = 90
        Me.Circular_Progres_Porc.Visible = False
        '
        'Lbl_Procesando
        '
        Me.Lbl_Procesando.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Procesando.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Procesando.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Procesando.Location = New System.Drawing.Point(420, 492)
        Me.Lbl_Procesando.Name = "Lbl_Procesando"
        Me.Lbl_Procesando.Size = New System.Drawing.Size(360, 23)
        Me.Lbl_Procesando.TabIndex = 89
        Me.Lbl_Procesando.Text = "Proseando... por favor espere"
        Me.Lbl_Procesando.Visible = False
        '
        'Circular_Progres_Val
        '
        Me.Circular_Progres_Val.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Circular_Progres_Val.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Circular_Progres_Val.Location = New System.Drawing.Point(410, 445)
        Me.Circular_Progres_Val.Name = "Circular_Progres_Val"
        Me.Circular_Progres_Val.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.Circular_Progres_Val.ProgressColor = System.Drawing.Color.SteelBlue
        Me.Circular_Progres_Val.ProgressTextFormat = "{0}"
        Me.Circular_Progres_Val.ProgressTextVisible = True
        Me.Circular_Progres_Val.Size = New System.Drawing.Size(75, 44)
        Me.Circular_Progres_Val.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.Circular_Progres_Val.TabIndex = 88
        Me.Circular_Progres_Val.Visible = False
        '
        'Grupo_Rut
        '
        Me.Grupo_Rut.BackColor = System.Drawing.Color.White
        Me.Grupo_Rut.Controls.Add(Me.Lbl_Rtu)
        Me.Grupo_Rut.ForeColor = System.Drawing.Color.Black
        Me.Grupo_Rut.Location = New System.Drawing.Point(7, 471)
        Me.Grupo_Rut.Name = "Grupo_Rut"
        Me.Grupo_Rut.Size = New System.Drawing.Size(90, 44)
        Me.Grupo_Rut.TabIndex = 78
        Me.Grupo_Rut.TabStop = False
        Me.Grupo_Rut.Text = "R.T.U."
        '
        'Lbl_Rtu
        '
        Me.Lbl_Rtu.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Rtu.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Rtu.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Rtu.Location = New System.Drawing.Point(6, 18)
        Me.Lbl_Rtu.Name = "Lbl_Rtu"
        Me.Lbl_Rtu.Size = New System.Drawing.Size(78, 23)
        Me.Lbl_Rtu.TabIndex = 34
        Me.Lbl_Rtu.Text = "R.T.U."
        Me.Lbl_Rtu.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.ContextMenuBar1)
        Me.GroupPanel1.Controls.Add(Me.Grilla)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(3, 47)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(777, 334)
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
        Me.GroupPanel1.TabIndex = 85
        Me.GroupPanel1.Text = "Detalle"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_Productos, Me.Menu_Contextual_Copiar, Me.Menu_Contextual_Formula, Me.Menu_Contextual_Costo, Me.Menu_Contextual_Tratamiento})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(65, 32)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(645, 25)
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
        Me.Menu_Contextual_Productos.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1, Me.Btn_Estadisticas_Producto_01})
        Me.Menu_Contextual_Productos.Text = "Opciones Productos"
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
        Me.LabelItem1.Text = "Opciones del producto"
        '
        'Btn_Estadisticas_Producto_01
        '
        Me.Btn_Estadisticas_Producto_01.Image = CType(resources.GetObject("Btn_Estadisticas_Producto_01.Image"), System.Drawing.Image)
        Me.Btn_Estadisticas_Producto_01.Name = "Btn_Estadisticas_Producto_01"
        Me.Btn_Estadisticas_Producto_01.Text = "Ver estadísticas del producto/información adicional"
        '
        'Menu_Contextual_Copiar
        '
        Me.Menu_Contextual_Copiar.AutoExpandOnClick = True
        Me.Menu_Contextual_Copiar.Name = "Menu_Contextual_Copiar"
        Me.Menu_Contextual_Copiar.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Estadisticas_Producto_02, Me.Btn_Copiar_datos})
        Me.Menu_Contextual_Copiar.Text = "Opciones Copia"
        '
        'Btn_Estadisticas_Producto_02
        '
        Me.Btn_Estadisticas_Producto_02.Image = CType(resources.GetObject("Btn_Estadisticas_Producto_02.Image"), System.Drawing.Image)
        Me.Btn_Estadisticas_Producto_02.Name = "Btn_Estadisticas_Producto_02"
        Me.Btn_Estadisticas_Producto_02.Text = "Ver estadísticas del producto/información adicional"
        '
        'Btn_Copiar_datos
        '
        Me.Btn_Copiar_datos.Image = CType(resources.GetObject("Btn_Copiar_datos.Image"), System.Drawing.Image)
        Me.Btn_Copiar_datos.Name = "Btn_Copiar_datos"
        Me.Btn_Copiar_datos.Text = "Copiar este datos en todos los productos marcados"
        '
        'Menu_Contextual_Formula
        '
        Me.Menu_Contextual_Formula.AutoExpandOnClick = True
        Me.Menu_Contextual_Formula.Name = "Menu_Contextual_Formula"
        Me.Menu_Contextual_Formula.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Estadisticas_Producto_03, Me.LabelItem4, Me.Btn_Ejecutar_Formula, Me.Btn_Configurar_Formula_Linea, Me.LabelItem5, Me.Btn_Copiar_Formula, Me.Btn_Copiar_Datos_Precios})
        Me.Menu_Contextual_Formula.Text = "Opciones Formula"
        '
        'Btn_Estadisticas_Producto_03
        '
        Me.Btn_Estadisticas_Producto_03.Image = CType(resources.GetObject("Btn_Estadisticas_Producto_03.Image"), System.Drawing.Image)
        Me.Btn_Estadisticas_Producto_03.Name = "Btn_Estadisticas_Producto_03"
        Me.Btn_Estadisticas_Producto_03.Text = "Ver estadísticas del producto/información adicional"
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
        Me.LabelItem4.Text = "Formulas del producto seleccionado (línea activa)"
        '
        'Btn_Ejecutar_Formula
        '
        Me.Btn_Ejecutar_Formula.Image = CType(resources.GetObject("Btn_Ejecutar_Formula.Image"), System.Drawing.Image)
        Me.Btn_Ejecutar_Formula.Name = "Btn_Ejecutar_Formula"
        Me.Btn_Ejecutar_Formula.Text = "Ejecutar formula"
        '
        'Btn_Configurar_Formula_Linea
        '
        Me.Btn_Configurar_Formula_Linea.Image = CType(resources.GetObject("Btn_Configurar_Formula_Linea.Image"), System.Drawing.Image)
        Me.Btn_Configurar_Formula_Linea.Name = "Btn_Configurar_Formula_Linea"
        Me.Btn_Configurar_Formula_Linea.Text = "Configuración de formula"
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
        Me.LabelItem5.Text = "Copiar datos (línea activa)"
        '
        'Btn_Copiar_Formula
        '
        Me.Btn_Copiar_Formula.Image = CType(resources.GetObject("Btn_Copiar_Formula.Image"), System.Drawing.Image)
        Me.Btn_Copiar_Formula.Name = "Btn_Copiar_Formula"
        Me.Btn_Copiar_Formula.Text = "Copiar la <b>fórmula</b> de este producto en todos los productos marcados"
        '
        'Btn_Copiar_Datos_Precios
        '
        Me.Btn_Copiar_Datos_Precios.Image = CType(resources.GetObject("Btn_Copiar_Datos_Precios.Image"), System.Drawing.Image)
        Me.Btn_Copiar_Datos_Precios.Name = "Btn_Copiar_Datos_Precios"
        Me.Btn_Copiar_Datos_Precios.Text = "Copiar este <b>Valor</b> en todos los productos marcados"
        '
        'Menu_Contextual_Costo
        '
        Me.Menu_Contextual_Costo.AutoExpandOnClick = True
        Me.Menu_Contextual_Costo.Name = "Menu_Contextual_Costo"
        Me.Menu_Contextual_Costo.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem6, Me.Btn_PM_Linea, Me.Btn_UC_Linea})
        Me.Menu_Contextual_Costo.Text = "Opciones Costo"
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
        Me.LabelItem6.Text = "Costos de la línea activa"
        '
        'Btn_PM_Linea
        '
        Me.Btn_PM_Linea.Image = CType(resources.GetObject("Btn_PM_Linea.Image"), System.Drawing.Image)
        Me.Btn_PM_Linea.Name = "Btn_PM_Linea"
        Me.Btn_PM_Linea.Text = "Traer el PM de este producto"
        '
        'Btn_UC_Linea
        '
        Me.Btn_UC_Linea.Image = CType(resources.GetObject("Btn_UC_Linea.Image"), System.Drawing.Image)
        Me.Btn_UC_Linea.Name = "Btn_UC_Linea"
        Me.Btn_UC_Linea.Text = "Traer el Costo última compra de este producto"
        '
        'Menu_Contextual_Tratamiento
        '
        Me.Menu_Contextual_Tratamiento.AutoExpandOnClick = True
        Me.Menu_Contextual_Tratamiento.Name = "Menu_Contextual_Tratamiento"
        Me.Menu_Contextual_Tratamiento.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem3, Me.Btn_Buscar_Un_Producto, Me.Btn_Busqueda_Selectiva, Me.Btn_Busqueda_Class, Me.Btn_Traer_Todos_Los_Productos, Me.BtnCambiarLista, Me.LabelItem2, Me.Btn_Importar_Desde_Excel})
        Me.Menu_Contextual_Tratamiento.Text = "Opciones Productos"
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
        Me.LabelItem3.Text = "Opciones del producto"
        '
        'Btn_Buscar_Un_Producto
        '
        Me.Btn_Buscar_Un_Producto.Image = CType(resources.GetObject("Btn_Buscar_Un_Producto.Image"), System.Drawing.Image)
        Me.Btn_Buscar_Un_Producto.Name = "Btn_Buscar_Un_Producto"
        Me.Btn_Buscar_Un_Producto.Text = "Traer un solo producto (F2)"
        '
        'Btn_Busqueda_Selectiva
        '
        Me.Btn_Busqueda_Selectiva.Image = CType(resources.GetObject("Btn_Busqueda_Selectiva.Image"), System.Drawing.Image)
        Me.Btn_Busqueda_Selectiva.Name = "Btn_Busqueda_Selectiva"
        Me.Btn_Busqueda_Selectiva.Text = "Buscar productos selectivamente (F3)"
        '
        'Btn_Busqueda_Class
        '
        Me.Btn_Busqueda_Class.Image = CType(resources.GetObject("Btn_Busqueda_Class.Image"), System.Drawing.Image)
        Me.Btn_Busqueda_Class.Name = "Btn_Busqueda_Class"
        Me.Btn_Busqueda_Class.Text = "Buscar productos según clasificación (Marca, Rubros, Familia, Etc.)"
        '
        'Btn_Traer_Todos_Los_Productos
        '
        Me.Btn_Traer_Todos_Los_Productos.Image = CType(resources.GetObject("Btn_Traer_Todos_Los_Productos.Image"), System.Drawing.Image)
        Me.Btn_Traer_Todos_Los_Productos.Name = "Btn_Traer_Todos_Los_Productos"
        Me.Btn_Traer_Todos_Los_Productos.Text = "Traer todos los productos"
        '
        'BtnCambiarLista
        '
        Me.BtnCambiarLista.Image = CType(resources.GetObject("BtnCambiarLista.Image"), System.Drawing.Image)
        Me.BtnCambiarLista.Name = "BtnCambiarLista"
        Me.BtnCambiarLista.Text = "Cambiar lista de precios"
        Me.BtnCambiarLista.Visible = False
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
        Me.LabelItem2.Text = "Importar datos desde Excel"
        '
        'Btn_Importar_Desde_Excel
        '
        Me.Btn_Importar_Desde_Excel.Image = CType(resources.GetObject("Btn_Importar_Desde_Excel.Image"), System.Drawing.Image)
        Me.Btn_Importar_Desde_Excel.Name = "Btn_Importar_Desde_Excel"
        Me.Btn_Importar_Desde_Excel.Text = "Importar datos desde <b>Excel </b>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.AllowUserToDeleteRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        Me.Grilla.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.Grilla.BackgroundColor = System.Drawing.Color.White
        Me.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla.Location = New System.Drawing.Point(0, 0)
        Me.Grilla.Name = "Grilla"
        Me.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grilla.Size = New System.Drawing.Size(771, 311)
        Me.Grilla.TabIndex = 3
        '
        'Barra_Abajo
        '
        Me.Barra_Abajo.AntiAlias = True
        Me.Barra_Abajo.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Barra_Abajo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Barra_Abajo.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnGrabar, Me.Btn_Limpiar, Me.Chk_Marcar_Todo, Me.Btn_Exportar_Excel})
        Me.Barra_Abajo.Location = New System.Drawing.Point(0, 533)
        Me.Barra_Abajo.Name = "Barra_Abajo"
        Me.Barra_Abajo.Size = New System.Drawing.Size(793, 41)
        Me.Barra_Abajo.Stretch = True
        Me.Barra_Abajo.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Barra_Abajo.TabIndex = 77
        Me.Barra_Abajo.TabStop = False
        Me.Barra_Abajo.Text = "Bar2"
        '
        'BtnGrabar
        '
        Me.BtnGrabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnGrabar.ForeColor = System.Drawing.Color.Black
        Me.BtnGrabar.Image = CType(resources.GetObject("BtnGrabar.Image"), System.Drawing.Image)
        Me.BtnGrabar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnGrabar.Name = "BtnGrabar"
        Me.BtnGrabar.Tooltip = "Grabar"
        '
        'Btn_Limpiar
        '
        Me.Btn_Limpiar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Limpiar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Limpiar.Image = CType(resources.GetObject("Btn_Limpiar.Image"), System.Drawing.Image)
        Me.Btn_Limpiar.Name = "Btn_Limpiar"
        Me.Btn_Limpiar.Tooltip = "Limpiar tratamiento"
        '
        'Chk_Marcar_Todo
        '
        Me.Chk_Marcar_Todo.Name = "Chk_Marcar_Todo"
        Me.Chk_Marcar_Todo.Text = "Marcar todo"
        '
        'Btn_Exportar_Excel
        '
        Me.Btn_Exportar_Excel.ForeColor = System.Drawing.Color.Black
        Me.Btn_Exportar_Excel.Image = Global.BkSpecialPrograms.My.Resources.Resources.export_to_excel
        Me.Btn_Exportar_Excel.Name = "Btn_Exportar_Excel"
        Me.Btn_Exportar_Excel.Tooltip = "Exportar a excel (Vista actual)"
        '
        'Txt_Funcion
        '
        Me.Txt_Funcion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Funcion.Border.Class = "TextBoxBorder"
        Me.Txt_Funcion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Funcion.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Funcion.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Funcion.ForeColor = System.Drawing.Color.Black
        Me.Txt_Funcion.Location = New System.Drawing.Point(31, 416)
        Me.Txt_Funcion.Name = "Txt_Funcion"
        Me.Txt_Funcion.PreventEnterBeep = True
        Me.Txt_Funcion.ReadOnly = True
        Me.Txt_Funcion.Size = New System.Drawing.Size(749, 20)
        Me.Txt_Funcion.TabIndex = 86
        '
        'Grupo_Costo_Ud1
        '
        Me.Grupo_Costo_Ud1.BackColor = System.Drawing.Color.White
        Me.Grupo_Costo_Ud1.Controls.Add(Me.Lbl_Costo_Ultima_Compra_Ud1)
        Me.Grupo_Costo_Ud1.ForeColor = System.Drawing.Color.Black
        Me.Grupo_Costo_Ud1.Location = New System.Drawing.Point(103, 471)
        Me.Grupo_Costo_Ud1.Name = "Grupo_Costo_Ud1"
        Me.Grupo_Costo_Ud1.Size = New System.Drawing.Size(100, 44)
        Me.Grupo_Costo_Ud1.TabIndex = 79
        Me.Grupo_Costo_Ud1.TabStop = False
        Me.Grupo_Costo_Ud1.Text = "Costo U.C. Ud1"
        '
        'Lbl_Costo_Ultima_Compra_Ud1
        '
        Me.Lbl_Costo_Ultima_Compra_Ud1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Costo_Ultima_Compra_Ud1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Costo_Ultima_Compra_Ud1.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Costo_Ultima_Compra_Ud1.Location = New System.Drawing.Point(6, 18)
        Me.Lbl_Costo_Ultima_Compra_Ud1.Name = "Lbl_Costo_Ultima_Compra_Ud1"
        Me.Lbl_Costo_Ultima_Compra_Ud1.Size = New System.Drawing.Size(90, 23)
        Me.Lbl_Costo_Ultima_Compra_Ud1.TabIndex = 34
        Me.Lbl_Costo_Ultima_Compra_Ud1.Text = "UC1"
        Me.Lbl_Costo_Ultima_Compra_Ud1.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'Grupo_Costo_Ud2
        '
        Me.Grupo_Costo_Ud2.BackColor = System.Drawing.Color.White
        Me.Grupo_Costo_Ud2.Controls.Add(Me.Lbl_Costo_Ultima_Compra_Ud2)
        Me.Grupo_Costo_Ud2.ForeColor = System.Drawing.Color.Black
        Me.Grupo_Costo_Ud2.Location = New System.Drawing.Point(209, 471)
        Me.Grupo_Costo_Ud2.Name = "Grupo_Costo_Ud2"
        Me.Grupo_Costo_Ud2.Size = New System.Drawing.Size(99, 44)
        Me.Grupo_Costo_Ud2.TabIndex = 80
        Me.Grupo_Costo_Ud2.TabStop = False
        Me.Grupo_Costo_Ud2.Text = "Costo U.C. Ud2"
        '
        'Lbl_Costo_Ultima_Compra_Ud2
        '
        Me.Lbl_Costo_Ultima_Compra_Ud2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Costo_Ultima_Compra_Ud2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Costo_Ultima_Compra_Ud2.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Costo_Ultima_Compra_Ud2.Location = New System.Drawing.Point(6, 18)
        Me.Lbl_Costo_Ultima_Compra_Ud2.Name = "Lbl_Costo_Ultima_Compra_Ud2"
        Me.Lbl_Costo_Ultima_Compra_Ud2.Size = New System.Drawing.Size(78, 23)
        Me.Lbl_Costo_Ultima_Compra_Ud2.TabIndex = 34
        Me.Lbl_Costo_Ultima_Compra_Ud2.Text = "UC2"
        Me.Lbl_Costo_Ultima_Compra_Ud2.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'Grupo_PM
        '
        Me.Grupo_PM.BackColor = System.Drawing.Color.White
        Me.Grupo_PM.Controls.Add(Me.Lbl_Costo_PM)
        Me.Grupo_PM.ForeColor = System.Drawing.Color.Black
        Me.Grupo_PM.Location = New System.Drawing.Point(314, 471)
        Me.Grupo_PM.Name = "Grupo_PM"
        Me.Grupo_PM.Size = New System.Drawing.Size(90, 44)
        Me.Grupo_PM.TabIndex = 81
        Me.Grupo_PM.TabStop = False
        Me.Grupo_PM.Text = "Costo PM"
        '
        'Lbl_Costo_PM
        '
        Me.Lbl_Costo_PM.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Costo_PM.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Costo_PM.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Costo_PM.Location = New System.Drawing.Point(6, 18)
        Me.Lbl_Costo_PM.Name = "Lbl_Costo_PM"
        Me.Lbl_Costo_PM.Size = New System.Drawing.Size(78, 23)
        Me.Lbl_Costo_PM.TabIndex = 34
        Me.Lbl_Costo_PM.Text = "PM"
        Me.Lbl_Costo_PM.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'Chk_Ud1_X_Ud2
        '
        Me.Chk_Ud1_X_Ud2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Ud1_X_Ud2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Ud1_X_Ud2.Checked = True
        Me.Chk_Ud1_X_Ud2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_Ud1_X_Ud2.CheckValue = "Y"
        Me.Chk_Ud1_X_Ud2.ForeColor = System.Drawing.Color.Black
        Me.Chk_Ud1_X_Ud2.Location = New System.Drawing.Point(7, 442)
        Me.Chk_Ud1_X_Ud2.Name = "Chk_Ud1_X_Ud2"
        Me.Chk_Ud1_X_Ud2.Size = New System.Drawing.Size(213, 23)
        Me.Chk_Ud1_X_Ud2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Ud1_X_Ud2.TabIndex = 82
        Me.Chk_Ud1_X_Ud2.Text = "Calculo automático Ud1 vs Ud2 * Rtu"
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
        Me.Txt_Descripcion.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Descripcion.ForeColor = System.Drawing.Color.Black
        Me.Txt_Descripcion.Location = New System.Drawing.Point(3, 384)
        Me.Txt_Descripcion.Name = "Txt_Descripcion"
        Me.Txt_Descripcion.PreventEnterBeep = True
        Me.Txt_Descripcion.ReadOnly = True
        Me.Txt_Descripcion.Size = New System.Drawing.Size(777, 22)
        Me.Txt_Descripcion.TabIndex = 83
        '
        'Btn_Conf_Funcion
        '
        Me.Btn_Conf_Funcion.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Conf_Funcion.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Conf_Funcion.Image = CType(resources.GetObject("Btn_Conf_Funcion.Image"), System.Drawing.Image)
        Me.Btn_Conf_Funcion.Location = New System.Drawing.Point(3, 414)
        Me.Btn_Conf_Funcion.Name = "Btn_Conf_Funcion"
        Me.Btn_Conf_Funcion.Size = New System.Drawing.Size(22, 22)
        Me.Btn_Conf_Funcion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Conf_Funcion.TabIndex = 87
        Me.Btn_Conf_Funcion.Tooltip = "Funcion"
        '
        'Txt_Proveedor
        '
        Me.Txt_Proveedor.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Proveedor.Border.Class = "TextBoxBorder"
        Me.Txt_Proveedor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Proveedor.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Proveedor.FocusHighlightEnabled = True
        Me.Txt_Proveedor.ForeColor = System.Drawing.Color.Black
        Me.Txt_Proveedor.Location = New System.Drawing.Point(103, 15)
        Me.Txt_Proveedor.Name = "Txt_Proveedor"
        Me.Txt_Proveedor.PreventEnterBeep = True
        Me.Txt_Proveedor.ReadOnly = True
        Me.Txt_Proveedor.Size = New System.Drawing.Size(677, 22)
        Me.Txt_Proveedor.TabIndex = 92
        Me.Txt_Proveedor.WatermarkText = "No hay filtro para ningún proveedor..."
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(3, 12)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(88, 23)
        Me.LabelX4.TabIndex = 93
        Me.LabelX4.Text = "Proveedor"
        '
        'Frm_LcProv_Mantencion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(793, 574)
        Me.Controls.Add(Me.Txt_Proveedor)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.Btn_Cancelar)
        Me.Controls.Add(Me.Circular_Progres_Porc)
        Me.Controls.Add(Me.Lbl_Procesando)
        Me.Controls.Add(Me.Circular_Progres_Val)
        Me.Controls.Add(Me.Grupo_Rut)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Barra_Abajo)
        Me.Controls.Add(Me.Txt_Funcion)
        Me.Controls.Add(Me.Grupo_Costo_Ud1)
        Me.Controls.Add(Me.Grupo_Costo_Ud2)
        Me.Controls.Add(Me.Grupo_PM)
        Me.Controls.Add(Me.Chk_Ud1_X_Ud2)
        Me.Controls.Add(Me.Txt_Descripcion)
        Me.Controls.Add(Me.Btn_Conf_Funcion)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_LcProv_Mantencion"
        Me.ShowInTaskbar = False
        Me.Text = "MetroForm"
        Me.Grupo_Rut.ResumeLayout(False)
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Barra_Abajo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo_Costo_Ud1.ResumeLayout(False)
        Me.Grupo_Costo_Ud2.ResumeLayout(False)
        Me.Grupo_PM.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Btn_Cancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Circular_Progres_Porc As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Lbl_Procesando As DevComponents.DotNetBar.LabelX
    Friend WithEvents Circular_Progres_Val As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Grupo_Rut As GroupBox
    Friend WithEvents Lbl_Rtu As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_Productos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Estadisticas_Producto_01 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Menu_Contextual_Copiar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Estadisticas_Producto_02 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Copiar_datos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Menu_Contextual_Formula As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Estadisticas_Producto_03 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem4 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Ejecutar_Formula As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Configurar_Formula_Linea As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem5 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Copiar_Formula As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Copiar_Datos_Precios As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Menu_Contextual_Costo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem6 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_PM_Linea As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_UC_Linea As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Menu_Contextual_Tratamiento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem3 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Buscar_Un_Producto As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Busqueda_Selectiva As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Busqueda_Class As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Traer_Todos_Los_Productos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnCambiarLista As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Importar_Desde_Excel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grilla As DataGridView
    Friend WithEvents Barra_Abajo As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnGrabar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Limpiar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Chk_Marcar_Todo As DevComponents.DotNetBar.CheckBoxItem
    Friend WithEvents Btn_Exportar_Excel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Txt_Funcion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Grupo_Costo_Ud1 As GroupBox
    Friend WithEvents Lbl_Costo_Ultima_Compra_Ud1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Grupo_Costo_Ud2 As GroupBox
    Friend WithEvents Lbl_Costo_Ultima_Compra_Ud2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Grupo_PM As GroupBox
    Friend WithEvents Lbl_Costo_PM As DevComponents.DotNetBar.LabelX
    Public WithEvents Chk_Ud1_X_Ud2 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Txt_Descripcion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Btn_Conf_Funcion As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Txt_Proveedor As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
End Class
