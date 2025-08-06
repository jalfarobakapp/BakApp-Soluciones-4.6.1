<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_BkpPostBusquedaEspecial_Mt
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_BkpPostBusquedaEspecial_Mt))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.BtnCrearProductos = New DevComponents.DotNetBar.ButtonItem()
        Me.LblOculto = New DevComponents.DotNetBar.LabelItem()
        Me.CirProg_Actualizando = New DevComponents.DotNetBar.CircularProgressItem()
        Me.Lbl_Cargando_Productos = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Seleccion_Multiple = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Marcar_Seleccionados = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Desmarcar_Seleccionados = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Orden_Bodegas = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Teclado = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnExportaExcel = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnBuscarListaCostosProveedor = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnBuscarAlternativos = New DevComponents.DotNetBar.ButtonItem()
        Me.ChkMostrarOcultos = New DevComponents.DotNetBar.CheckBoxItem()
        Me.TxtCodigo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Ficha = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Patente = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.CmbCantFilas = New System.Windows.Forms.ComboBox()
        Me.Grupo_BusquedaProducto = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_CodAlternativo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txtdescripcion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Patente = New DevComponents.DotNetBar.LabelX()
        Me.Context_Menu_Solicitud_Compra = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_01 = New DevComponents.DotNetBar.ButtonItem()
        Me.Lbl_Mnu_1 = New DevComponents.DotNetBar.LabelItem()
        Me.Mnu_Btn_Ver_Informacion_de_producto = New DevComponents.DotNetBar.ButtonItem()
        Me.Mnu_Btn_Codigos_Reemplazo = New DevComponents.DotNetBar.ButtonItem()
        Me.Mnu_Btn_Productos_Asociados = New DevComponents.DotNetBar.ButtonItem()
        Me.Mnu_Btn_Cambiar_Codigo_Producto = New DevComponents.DotNetBar.ButtonItem()
        Me.Mnu_Btn_Pr_Ver_Clasificacion_Producto = New DevComponents.DotNetBar.ButtonItem()
        Me.Mnu_Btn_Ver_Clasificaciones_producto = New DevComponents.DotNetBar.ButtonItem()
        Me.Mnu_Btn_Mantencion_clasificaciones_producto = New DevComponents.DotNetBar.ButtonItem()
        Me.Mnu_Btn_Imagenes_producto = New DevComponents.DotNetBar.ButtonItem()
        Me.Mnu_Btn_Mant_codigos_alternativos = New DevComponents.DotNetBar.ButtonItem()
        Me.Mnu_Btn_Kardex_Inventario = New DevComponents.DotNetBar.ButtonItem()
        Me.Mnu_Btn_Ubicacion_Producto = New DevComponents.DotNetBar.ButtonItem()
        Me.Mnu_Btn_Ocultar_Desocultar = New DevComponents.DotNetBar.ButtonItem()
        Me.Mnu_Btn_Ocultar = New DevComponents.DotNetBar.ButtonItem()
        Me.Mnu_Btn_Desocultar = New DevComponents.DotNetBar.ButtonItem()
        Me.Mnu_Btn_Archivos_Asociados_Producto = New DevComponents.DotNetBar.ButtonItem()
        Me.Mnu_Btn_Dimensiones = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Migrar_Producto = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.Mnu_Btn_Editar_Producto = New DevComponents.DotNetBar.ButtonItem()
        Me.Mnu_Btn_Eliminar_Producto = New DevComponents.DotNetBar.ButtonItem()
        Me.Mnu_Btn_Copiar = New DevComponents.DotNetBar.ButtonItem()
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
        Me.TouchKeyboard1 = New DevComponents.DotNetBar.Keyboard.TouchKeyboard()
        Me.Bar_Menu_Producto = New DevComponents.DotNetBar.Bar()
        Me.Btn_Mnu_Pr_Editar_Producto = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Pr_Eliminar_Producto = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Pr_Estadistica_Producto = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Pr_Codigo_De_Reemplazo = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Productos_Asociados = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Pr_Cambiar_Codigo_Producto = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Pr_Ver_Clasificacion_Producto = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Pr_Mantencion_Clasificacion_Producto = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Pr_Imagen_Producto = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Pr_Codigo_Alternativo = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Pr_Kardex_Inventario = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Pr_Ubicacion_Producto = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Ocultar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Ver_Archivos_Adjuntos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Dimensiones = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtrar = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem8 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem9 = New DevComponents.DotNetBar.ButtonItem()
        Me.Chk_Top20 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Btn_Maestra_Productos = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Top20 = New DevComponents.DotNetBar.ButtonX()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Chk_MostrarVendidosUlt3Meses = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_StockFisicoMayorCero = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Imagenes_20x20 = New System.Windows.Forms.ImageList(Me.components)
        Me.Imagenes_16x16 = New System.Windows.Forms.ImageList(Me.components)
        Me.Imagenes_32x32 = New System.Windows.Forms.ImageList(Me.components)
        Me.Imagenes_32x32_Dark = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_BusquedaProducto.SuspendLayout()
        CType(Me.Context_Menu_Solicitud_Compra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar_Menu_Producto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnCrearProductos, Me.LblOculto, Me.CirProg_Actualizando, Me.Lbl_Cargando_Productos, Me.Btn_Seleccion_Multiple, Me.Btn_Marcar_Seleccionados, Me.Btn_Desmarcar_Seleccionados, Me.Btn_Orden_Bodegas, Me.Btn_Teclado, Me.BtnExportaExcel, Me.BtnBuscarListaCostosProveedor, Me.BtnBuscarAlternativos, Me.ChkMostrarOcultos})
        Me.Bar1.Location = New System.Drawing.Point(0, 590)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(860, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 24
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnCrearProductos
        '
        Me.BtnCrearProductos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnCrearProductos.ForeColor = System.Drawing.Color.Black
        Me.BtnCrearProductos.Image = CType(resources.GetObject("BtnCrearProductos.Image"), System.Drawing.Image)
        Me.BtnCrearProductos.ImageAlt = CType(resources.GetObject("BtnCrearProductos.ImageAlt"), System.Drawing.Image)
        Me.BtnCrearProductos.Name = "BtnCrearProductos"
        Me.BtnCrearProductos.Tooltip = "Crear nuevo producto"
        Me.BtnCrearProductos.Visible = False
        '
        'LblOculto
        '
        Me.LblOculto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOculto.ForeColor = System.Drawing.Color.Red
        Me.LblOculto.Name = "LblOculto"
        Me.LblOculto.Text = "."
        '
        'CirProg_Actualizando
        '
        Me.CirProg_Actualizando.Name = "CirProg_Actualizando"
        Me.CirProg_Actualizando.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Dot
        '
        'Lbl_Cargando_Productos
        '
        Me.Lbl_Cargando_Productos.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Cargando_Productos.Name = "Lbl_Cargando_Productos"
        Me.Lbl_Cargando_Productos.Text = "    Cargando productos..."
        '
        'Btn_Seleccion_Multiple
        '
        Me.Btn_Seleccion_Multiple.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Seleccion_Multiple.ForeColor = System.Drawing.Color.Black
        Me.Btn_Seleccion_Multiple.Image = CType(resources.GetObject("Btn_Seleccion_Multiple.Image"), System.Drawing.Image)
        Me.Btn_Seleccion_Multiple.ImageAlt = CType(resources.GetObject("Btn_Seleccion_Multiple.ImageAlt"), System.Drawing.Image)
        Me.Btn_Seleccion_Multiple.Name = "Btn_Seleccion_Multiple"
        Me.Btn_Seleccion_Multiple.Text = "Aceptar"
        Me.Btn_Seleccion_Multiple.Tooltip = "Trasladar productos seleccionados (Tikceados)"
        Me.Btn_Seleccion_Multiple.Visible = False
        '
        'Btn_Marcar_Seleccionados
        '
        Me.Btn_Marcar_Seleccionados.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Marcar_Seleccionados.ForeColor = System.Drawing.Color.Black
        Me.Btn_Marcar_Seleccionados.Image = CType(resources.GetObject("Btn_Marcar_Seleccionados.Image"), System.Drawing.Image)
        Me.Btn_Marcar_Seleccionados.Name = "Btn_Marcar_Seleccionados"
        Me.Btn_Marcar_Seleccionados.Tooltip = "Tickear seleccionados"
        Me.Btn_Marcar_Seleccionados.Visible = False
        '
        'Btn_Desmarcar_Seleccionados
        '
        Me.Btn_Desmarcar_Seleccionados.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Desmarcar_Seleccionados.ForeColor = System.Drawing.Color.Black
        Me.Btn_Desmarcar_Seleccionados.Image = CType(resources.GetObject("Btn_Desmarcar_Seleccionados.Image"), System.Drawing.Image)
        Me.Btn_Desmarcar_Seleccionados.Name = "Btn_Desmarcar_Seleccionados"
        Me.Btn_Desmarcar_Seleccionados.Tooltip = "Destickear seleccionados"
        Me.Btn_Desmarcar_Seleccionados.Visible = False
        '
        'Btn_Orden_Bodegas
        '
        Me.Btn_Orden_Bodegas.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Orden_Bodegas.ForeColor = System.Drawing.Color.Black
        Me.Btn_Orden_Bodegas.Image = CType(resources.GetObject("Btn_Orden_Bodegas.Image"), System.Drawing.Image)
        Me.Btn_Orden_Bodegas.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.Btn_Orden_Bodegas.Name = "Btn_Orden_Bodegas"
        Me.Btn_Orden_Bodegas.Tooltip = "Cambiar el orden de las bodegas en el mostrador"
        '
        'Btn_Teclado
        '
        Me.Btn_Teclado.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Teclado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Btn_Teclado.Image = CType(resources.GetObject("Btn_Teclado.Image"), System.Drawing.Image)
        Me.Btn_Teclado.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.Btn_Teclado.Name = "Btn_Teclado"
        Me.Btn_Teclado.Text = "VER"
        '
        'BtnExportaExcel
        '
        Me.BtnExportaExcel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnExportaExcel.ForeColor = System.Drawing.Color.Black
        Me.BtnExportaExcel.Image = CType(resources.GetObject("BtnExportaExcel.Image"), System.Drawing.Image)
        Me.BtnExportaExcel.ImageAlt = CType(resources.GetObject("BtnExportaExcel.ImageAlt"), System.Drawing.Image)
        Me.BtnExportaExcel.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnExportaExcel.Name = "BtnExportaExcel"
        Me.BtnExportaExcel.Tooltip = "Exportar a Excel"
        '
        'BtnBuscarListaCostosProveedor
        '
        Me.BtnBuscarListaCostosProveedor.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnBuscarListaCostosProveedor.ForeColor = System.Drawing.Color.Black
        Me.BtnBuscarListaCostosProveedor.Image = CType(resources.GetObject("BtnBuscarListaCostosProveedor.Image"), System.Drawing.Image)
        Me.BtnBuscarListaCostosProveedor.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnBuscarListaCostosProveedor.Name = "BtnBuscarListaCostosProveedor"
        Me.BtnBuscarListaCostosProveedor.Tooltip = "Buscar en lista costos del proveedor"
        Me.BtnBuscarListaCostosProveedor.Visible = False
        '
        'BtnBuscarAlternativos
        '
        Me.BtnBuscarAlternativos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnBuscarAlternativos.ForeColor = System.Drawing.Color.Black
        Me.BtnBuscarAlternativos.Image = CType(resources.GetObject("BtnBuscarAlternativos.Image"), System.Drawing.Image)
        Me.BtnBuscarAlternativos.ImageAlt = CType(resources.GetObject("BtnBuscarAlternativos.ImageAlt"), System.Drawing.Image)
        Me.BtnBuscarAlternativos.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnBuscarAlternativos.Name = "BtnBuscarAlternativos"
        Me.BtnBuscarAlternativos.Tooltip = "Buscar código alternativo"
        Me.BtnBuscarAlternativos.Visible = False
        '
        'ChkMostrarOcultos
        '
        Me.ChkMostrarOcultos.CheckBoxImageChecked = CType(resources.GetObject("ChkMostrarOcultos.CheckBoxImageChecked"), System.Drawing.Image)
        Me.ChkMostrarOcultos.Name = "ChkMostrarOcultos"
        Me.ChkMostrarOcultos.Text = "Mostrar ocultos"
        '
        'TxtCodigo
        '
        Me.TxtCodigo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtCodigo.Border.Class = "TextBoxBorder"
        Me.TxtCodigo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtCodigo.DisabledBackColor = System.Drawing.Color.White
        Me.TxtCodigo.FocusHighlightColor = System.Drawing.Color.PaleTurquoise
        Me.TxtCodigo.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodigo.ForeColor = System.Drawing.Color.Black
        Me.TxtCodigo.Location = New System.Drawing.Point(556, 3)
        Me.TxtCodigo.Name = "TxtCodigo"
        Me.TxtCodigo.PreventEnterBeep = True
        Me.TxtCodigo.Size = New System.Drawing.Size(96, 22)
        Me.TxtCodigo.TabIndex = 23
        '
        'Txt_Ficha
        '
        Me.Txt_Ficha.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Ficha.Border.Class = "TextBoxBorder"
        Me.Txt_Ficha.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Ficha.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Ficha.FocusHighlightColor = System.Drawing.Color.PaleTurquoise
        Me.Txt_Ficha.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Ficha.ForeColor = System.Drawing.Color.Black
        Me.Txt_Ficha.Location = New System.Drawing.Point(82, 520)
        Me.Txt_Ficha.Multiline = True
        Me.Txt_Ficha.Name = "Txt_Ficha"
        Me.Txt_Ficha.PreventEnterBeep = True
        Me.Txt_Ficha.ReadOnly = True
        Me.Txt_Ficha.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Ficha.Size = New System.Drawing.Size(774, 33)
        Me.Txt_Ficha.TabIndex = 55
        Me.Txt_Ficha.Text = "Ficha tecnica" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Ficha tecnica"
        '
        'Txt_Patente
        '
        Me.Txt_Patente.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Patente.Border.Class = "TextBoxBorder"
        Me.Txt_Patente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Patente.ButtonCustom.Image = CType(resources.GetObject("Txt_Patente.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Patente.ButtonCustom2.Image = CType(resources.GetObject("Txt_Patente.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Patente.ButtonCustom2.Visible = True
        Me.Txt_Patente.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Patente.FocusHighlightColor = System.Drawing.Color.PaleTurquoise
        Me.Txt_Patente.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Txt_Patente.ForeColor = System.Drawing.Color.Black
        Me.Txt_Patente.Location = New System.Drawing.Point(768, 68)
        Me.Txt_Patente.MaxLength = 6
        Me.Txt_Patente.Name = "Txt_Patente"
        Me.Txt_Patente.PreventEnterBeep = True
        Me.Txt_Patente.Size = New System.Drawing.Size(88, 22)
        Me.Txt_Patente.TabIndex = 58
        Me.Txt_Patente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(1007, 86)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(89, 23)
        Me.LabelX1.TabIndex = 30
        Me.LabelX1.Text = "Ver los primeros"
        '
        'CmbCantFilas
        '
        Me.CmbCantFilas.BackColor = System.Drawing.Color.White
        Me.CmbCantFilas.ForeColor = System.Drawing.Color.Black
        Me.CmbCantFilas.FormattingEnabled = True
        Me.CmbCantFilas.Items.AddRange(New Object() {"10", "20", "30", "40", "50", "100", "200", "1000", "10000", "100000"})
        Me.CmbCantFilas.Location = New System.Drawing.Point(1102, 88)
        Me.CmbCantFilas.Name = "CmbCantFilas"
        Me.CmbCantFilas.Size = New System.Drawing.Size(82, 21)
        Me.CmbCantFilas.TabIndex = 29
        Me.CmbCantFilas.Text = "100"
        '
        'Grupo_BusquedaProducto
        '
        Me.Grupo_BusquedaProducto.BackColor = System.Drawing.Color.White
        Me.Grupo_BusquedaProducto.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_BusquedaProducto.Controls.Add(Me.LabelX4)
        Me.Grupo_BusquedaProducto.Controls.Add(Me.Txt_CodAlternativo)
        Me.Grupo_BusquedaProducto.Controls.Add(Me.Txtdescripcion)
        Me.Grupo_BusquedaProducto.Controls.Add(Me.LabelX2)
        Me.Grupo_BusquedaProducto.Controls.Add(Me.TxtCodigo)
        Me.Grupo_BusquedaProducto.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_BusquedaProducto.Location = New System.Drawing.Point(5, 9)
        Me.Grupo_BusquedaProducto.Margin = New System.Windows.Forms.Padding(0)
        Me.Grupo_BusquedaProducto.Name = "Grupo_BusquedaProducto"
        Me.Grupo_BusquedaProducto.Size = New System.Drawing.Size(851, 56)
        '
        '
        '
        Me.Grupo_BusquedaProducto.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_BusquedaProducto.Style.BackColorGradientAngle = 90
        Me.Grupo_BusquedaProducto.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_BusquedaProducto.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_BusquedaProducto.Style.BorderBottomWidth = 1
        Me.Grupo_BusquedaProducto.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_BusquedaProducto.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_BusquedaProducto.Style.BorderLeftWidth = 1
        Me.Grupo_BusquedaProducto.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_BusquedaProducto.Style.BorderRightWidth = 1
        Me.Grupo_BusquedaProducto.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_BusquedaProducto.Style.BorderTopWidth = 1
        Me.Grupo_BusquedaProducto.Style.CornerDiameter = 4
        Me.Grupo_BusquedaProducto.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_BusquedaProducto.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_BusquedaProducto.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_BusquedaProducto.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_BusquedaProducto.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_BusquedaProducto.TabIndex = 0
        Me.Grupo_BusquedaProducto.Text = "Cadena de busqueda del producto"
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(658, 3)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(39, 23)
        Me.LabelX4.TabIndex = 61
        Me.LabelX4.Text = "Cód.Alt."
        Me.LabelX4.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Txt_CodAlternativo
        '
        Me.Txt_CodAlternativo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_CodAlternativo.Border.Class = "TextBoxBorder"
        Me.Txt_CodAlternativo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_CodAlternativo.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_CodAlternativo.FocusHighlightColor = System.Drawing.Color.PaleTurquoise
        Me.Txt_CodAlternativo.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_CodAlternativo.ForeColor = System.Drawing.Color.Black
        Me.Txt_CodAlternativo.Location = New System.Drawing.Point(703, 3)
        Me.Txt_CodAlternativo.Name = "Txt_CodAlternativo"
        Me.Txt_CodAlternativo.PreventEnterBeep = True
        Me.Txt_CodAlternativo.Size = New System.Drawing.Size(137, 22)
        Me.Txt_CodAlternativo.TabIndex = 60
        '
        'Txtdescripcion
        '
        Me.Txtdescripcion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txtdescripcion.Border.Class = "TextBoxBorder"
        Me.Txtdescripcion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txtdescripcion.DisabledBackColor = System.Drawing.Color.White
        Me.Txtdescripcion.ForeColor = System.Drawing.Color.Black
        Me.Txtdescripcion.Location = New System.Drawing.Point(4, 3)
        Me.Txtdescripcion.Name = "Txtdescripcion"
        Me.Txtdescripcion.PreventEnterBeep = True
        Me.Txtdescripcion.Size = New System.Drawing.Size(501, 22)
        Me.Txtdescripcion.TabIndex = 59
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(511, 3)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(39, 23)
        Me.LabelX2.TabIndex = 24
        Me.LabelX2.Text = "Código"
        Me.LabelX2.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Lbl_Patente
        '
        Me.Lbl_Patente.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Patente.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Patente.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Patente.Location = New System.Drawing.Point(711, 68)
        Me.Lbl_Patente.Name = "Lbl_Patente"
        Me.Lbl_Patente.Size = New System.Drawing.Size(51, 23)
        Me.Lbl_Patente.TabIndex = 57
        Me.Lbl_Patente.Text = "PATENTE"
        Me.Lbl_Patente.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Context_Menu_Solicitud_Compra
        '
        Me.Context_Menu_Solicitud_Compra.AntiAlias = True
        Me.Context_Menu_Solicitud_Compra.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Context_Menu_Solicitud_Compra.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_01, Me.Menu_Contextual_Filtros_Productos})
        Me.Context_Menu_Solicitud_Compra.Location = New System.Drawing.Point(194, 158)
        Me.Context_Menu_Solicitud_Compra.Name = "Context_Menu_Solicitud_Compra"
        Me.Context_Menu_Solicitud_Compra.Size = New System.Drawing.Size(404, 25)
        Me.Context_Menu_Solicitud_Compra.Stretch = True
        Me.Context_Menu_Solicitud_Compra.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Context_Menu_Solicitud_Compra.TabIndex = 50
        Me.Context_Menu_Solicitud_Compra.TabStop = False
        Me.Context_Menu_Solicitud_Compra.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_01
        '
        Me.Menu_Contextual_01.AutoExpandOnClick = True
        Me.Menu_Contextual_01.Name = "Menu_Contextual_01"
        Me.Menu_Contextual_01.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Lbl_Mnu_1, Me.Mnu_Btn_Ver_Informacion_de_producto, Me.Mnu_Btn_Codigos_Reemplazo, Me.Mnu_Btn_Productos_Asociados, Me.Mnu_Btn_Cambiar_Codigo_Producto, Me.Mnu_Btn_Pr_Ver_Clasificacion_Producto, Me.Mnu_Btn_Imagenes_producto, Me.Mnu_Btn_Mant_codigos_alternativos, Me.Mnu_Btn_Kardex_Inventario, Me.Mnu_Btn_Ubicacion_Producto, Me.Mnu_Btn_Ocultar_Desocultar, Me.Mnu_Btn_Archivos_Asociados_Producto, Me.Mnu_Btn_Dimensiones, Me.Btn_Migrar_Producto, Me.LabelItem1, Me.Mnu_Btn_Editar_Producto, Me.Mnu_Btn_Eliminar_Producto, Me.Mnu_Btn_Copiar})
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
        Me.Lbl_Mnu_1.Text = "Menu general"
        '
        'Mnu_Btn_Ver_Informacion_de_producto
        '
        Me.Mnu_Btn_Ver_Informacion_de_producto.Image = CType(resources.GetObject("Mnu_Btn_Ver_Informacion_de_producto.Image"), System.Drawing.Image)
        Me.Mnu_Btn_Ver_Informacion_de_producto.ImageAlt = CType(resources.GetObject("Mnu_Btn_Ver_Informacion_de_producto.ImageAlt"), System.Drawing.Image)
        Me.Mnu_Btn_Ver_Informacion_de_producto.Name = "Mnu_Btn_Ver_Informacion_de_producto"
        Me.Mnu_Btn_Ver_Informacion_de_producto.Text = "Ver información adicional del producto"
        '
        'Mnu_Btn_Codigos_Reemplazo
        '
        Me.Mnu_Btn_Codigos_Reemplazo.Image = CType(resources.GetObject("Mnu_Btn_Codigos_Reemplazo.Image"), System.Drawing.Image)
        Me.Mnu_Btn_Codigos_Reemplazo.ImageAlt = CType(resources.GetObject("Mnu_Btn_Codigos_Reemplazo.ImageAlt"), System.Drawing.Image)
        Me.Mnu_Btn_Codigos_Reemplazo.Name = "Mnu_Btn_Codigos_Reemplazo"
        Me.Mnu_Btn_Codigos_Reemplazo.Text = "Ver códigos de reemplazo"
        '
        'Mnu_Btn_Productos_Asociados
        '
        Me.Mnu_Btn_Productos_Asociados.Image = CType(resources.GetObject("Mnu_Btn_Productos_Asociados.Image"), System.Drawing.Image)
        Me.Mnu_Btn_Productos_Asociados.ImageAlt = CType(resources.GetObject("Mnu_Btn_Productos_Asociados.ImageAlt"), System.Drawing.Image)
        Me.Mnu_Btn_Productos_Asociados.Name = "Mnu_Btn_Productos_Asociados"
        Me.Mnu_Btn_Productos_Asociados.Text = "Productos asociados"
        '
        'Mnu_Btn_Cambiar_Codigo_Producto
        '
        Me.Mnu_Btn_Cambiar_Codigo_Producto.Image = CType(resources.GetObject("Mnu_Btn_Cambiar_Codigo_Producto.Image"), System.Drawing.Image)
        Me.Mnu_Btn_Cambiar_Codigo_Producto.ImageAlt = CType(resources.GetObject("Mnu_Btn_Cambiar_Codigo_Producto.ImageAlt"), System.Drawing.Image)
        Me.Mnu_Btn_Cambiar_Codigo_Producto.Name = "Mnu_Btn_Cambiar_Codigo_Producto"
        Me.Mnu_Btn_Cambiar_Codigo_Producto.Text = "Cambiar código del producto"
        '
        'Mnu_Btn_Pr_Ver_Clasificacion_Producto
        '
        Me.Mnu_Btn_Pr_Ver_Clasificacion_Producto.Image = CType(resources.GetObject("Mnu_Btn_Pr_Ver_Clasificacion_Producto.Image"), System.Drawing.Image)
        Me.Mnu_Btn_Pr_Ver_Clasificacion_Producto.ImageAlt = CType(resources.GetObject("Mnu_Btn_Pr_Ver_Clasificacion_Producto.ImageAlt"), System.Drawing.Image)
        Me.Mnu_Btn_Pr_Ver_Clasificacion_Producto.Name = "Mnu_Btn_Pr_Ver_Clasificacion_Producto"
        Me.Mnu_Btn_Pr_Ver_Clasificacion_Producto.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Mnu_Btn_Ver_Clasificaciones_producto, Me.Mnu_Btn_Mantencion_clasificaciones_producto})
        Me.Mnu_Btn_Pr_Ver_Clasificacion_Producto.Text = "Ver clasificaciones del producto"
        '
        'Mnu_Btn_Ver_Clasificaciones_producto
        '
        Me.Mnu_Btn_Ver_Clasificaciones_producto.Image = CType(resources.GetObject("Mnu_Btn_Ver_Clasificaciones_producto.Image"), System.Drawing.Image)
        Me.Mnu_Btn_Ver_Clasificaciones_producto.ImageAlt = CType(resources.GetObject("Mnu_Btn_Ver_Clasificaciones_producto.ImageAlt"), System.Drawing.Image)
        Me.Mnu_Btn_Ver_Clasificaciones_producto.Name = "Mnu_Btn_Ver_Clasificaciones_producto"
        Me.Mnu_Btn_Ver_Clasificaciones_producto.Text = "Ver clasificaciones del producto"
        '
        'Mnu_Btn_Mantencion_clasificaciones_producto
        '
        Me.Mnu_Btn_Mantencion_clasificaciones_producto.Image = CType(resources.GetObject("Mnu_Btn_Mantencion_clasificaciones_producto.Image"), System.Drawing.Image)
        Me.Mnu_Btn_Mantencion_clasificaciones_producto.ImageAlt = CType(resources.GetObject("Mnu_Btn_Mantencion_clasificaciones_producto.ImageAlt"), System.Drawing.Image)
        Me.Mnu_Btn_Mantencion_clasificaciones_producto.Name = "Mnu_Btn_Mantencion_clasificaciones_producto"
        Me.Mnu_Btn_Mantencion_clasificaciones_producto.Text = "Mantencion_clasificaciones_producto"
        '
        'Mnu_Btn_Imagenes_producto
        '
        Me.Mnu_Btn_Imagenes_producto.Image = CType(resources.GetObject("Mnu_Btn_Imagenes_producto.Image"), System.Drawing.Image)
        Me.Mnu_Btn_Imagenes_producto.ImageAlt = CType(resources.GetObject("Mnu_Btn_Imagenes_producto.ImageAlt"), System.Drawing.Image)
        Me.Mnu_Btn_Imagenes_producto.Name = "Mnu_Btn_Imagenes_producto"
        Me.Mnu_Btn_Imagenes_producto.Text = "Imagenes del producto"
        '
        'Mnu_Btn_Mant_codigos_alternativos
        '
        Me.Mnu_Btn_Mant_codigos_alternativos.Image = CType(resources.GetObject("Mnu_Btn_Mant_codigos_alternativos.Image"), System.Drawing.Image)
        Me.Mnu_Btn_Mant_codigos_alternativos.ImageAlt = CType(resources.GetObject("Mnu_Btn_Mant_codigos_alternativos.ImageAlt"), System.Drawing.Image)
        Me.Mnu_Btn_Mant_codigos_alternativos.Name = "Mnu_Btn_Mant_codigos_alternativos"
        Me.Mnu_Btn_Mant_codigos_alternativos.Text = "Mantención de códigos alternativos de este producto"
        '
        'Mnu_Btn_Kardex_Inventario
        '
        Me.Mnu_Btn_Kardex_Inventario.Image = CType(resources.GetObject("Mnu_Btn_Kardex_Inventario.Image"), System.Drawing.Image)
        Me.Mnu_Btn_Kardex_Inventario.ImageAlt = CType(resources.GetObject("Mnu_Btn_Kardex_Inventario.ImageAlt"), System.Drawing.Image)
        Me.Mnu_Btn_Kardex_Inventario.Name = "Mnu_Btn_Kardex_Inventario"
        Me.Mnu_Btn_Kardex_Inventario.Text = "Kardex Inventario"
        '
        'Mnu_Btn_Ubicacion_Producto
        '
        Me.Mnu_Btn_Ubicacion_Producto.Image = CType(resources.GetObject("Mnu_Btn_Ubicacion_Producto.Image"), System.Drawing.Image)
        Me.Mnu_Btn_Ubicacion_Producto.ImageAlt = CType(resources.GetObject("Mnu_Btn_Ubicacion_Producto.ImageAlt"), System.Drawing.Image)
        Me.Mnu_Btn_Ubicacion_Producto.Name = "Mnu_Btn_Ubicacion_Producto"
        Me.Mnu_Btn_Ubicacion_Producto.Text = "Ubicación de producto en bodegas"
        '
        'Mnu_Btn_Ocultar_Desocultar
        '
        Me.Mnu_Btn_Ocultar_Desocultar.Image = CType(resources.GetObject("Mnu_Btn_Ocultar_Desocultar.Image"), System.Drawing.Image)
        Me.Mnu_Btn_Ocultar_Desocultar.ImageAlt = CType(resources.GetObject("Mnu_Btn_Ocultar_Desocultar.ImageAlt"), System.Drawing.Image)
        Me.Mnu_Btn_Ocultar_Desocultar.Name = "Mnu_Btn_Ocultar_Desocultar"
        Me.Mnu_Btn_Ocultar_Desocultar.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Mnu_Btn_Ocultar, Me.Mnu_Btn_Desocultar})
        Me.Mnu_Btn_Ocultar_Desocultar.Text = "Ocultar/Desocultar"
        '
        'Mnu_Btn_Ocultar
        '
        Me.Mnu_Btn_Ocultar.Image = CType(resources.GetObject("Mnu_Btn_Ocultar.Image"), System.Drawing.Image)
        Me.Mnu_Btn_Ocultar.ImageAlt = CType(resources.GetObject("Mnu_Btn_Ocultar.ImageAlt"), System.Drawing.Image)
        Me.Mnu_Btn_Ocultar.Name = "Mnu_Btn_Ocultar"
        Me.Mnu_Btn_Ocultar.Text = "Ocultar"
        '
        'Mnu_Btn_Desocultar
        '
        Me.Mnu_Btn_Desocultar.Image = CType(resources.GetObject("Mnu_Btn_Desocultar.Image"), System.Drawing.Image)
        Me.Mnu_Btn_Desocultar.ImageAlt = CType(resources.GetObject("Mnu_Btn_Desocultar.ImageAlt"), System.Drawing.Image)
        Me.Mnu_Btn_Desocultar.Name = "Mnu_Btn_Desocultar"
        Me.Mnu_Btn_Desocultar.Text = "Desocultar"
        '
        'Mnu_Btn_Archivos_Asociados_Producto
        '
        Me.Mnu_Btn_Archivos_Asociados_Producto.Image = CType(resources.GetObject("Mnu_Btn_Archivos_Asociados_Producto.Image"), System.Drawing.Image)
        Me.Mnu_Btn_Archivos_Asociados_Producto.ImageAlt = CType(resources.GetObject("Mnu_Btn_Archivos_Asociados_Producto.ImageAlt"), System.Drawing.Image)
        Me.Mnu_Btn_Archivos_Asociados_Producto.Name = "Mnu_Btn_Archivos_Asociados_Producto"
        Me.Mnu_Btn_Archivos_Asociados_Producto.Text = "Archivos adjuntos asociados al producto"
        '
        'Mnu_Btn_Dimensiones
        '
        Me.Mnu_Btn_Dimensiones.Image = CType(resources.GetObject("Mnu_Btn_Dimensiones.Image"), System.Drawing.Image)
        Me.Mnu_Btn_Dimensiones.ImageAlt = CType(resources.GetObject("Mnu_Btn_Dimensiones.ImageAlt"), System.Drawing.Image)
        Me.Mnu_Btn_Dimensiones.Name = "Mnu_Btn_Dimensiones"
        Me.Mnu_Btn_Dimensiones.Text = "Dimensiones (peso, largo, alto, ancho)"
        '
        'Btn_Migrar_Producto
        '
        Me.Btn_Migrar_Producto.Image = CType(resources.GetObject("Btn_Migrar_Producto.Image"), System.Drawing.Image)
        Me.Btn_Migrar_Producto.ImageAlt = CType(resources.GetObject("Btn_Migrar_Producto.ImageAlt"), System.Drawing.Image)
        Me.Btn_Migrar_Producto.Name = "Btn_Migrar_Producto"
        Me.Btn_Migrar_Producto.Text = "Migrar producto a base externa"
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
        Me.LabelItem1.Text = "Edición"
        '
        'Mnu_Btn_Editar_Producto
        '
        Me.Mnu_Btn_Editar_Producto.Image = CType(resources.GetObject("Mnu_Btn_Editar_Producto.Image"), System.Drawing.Image)
        Me.Mnu_Btn_Editar_Producto.ImageAlt = CType(resources.GetObject("Mnu_Btn_Editar_Producto.ImageAlt"), System.Drawing.Image)
        Me.Mnu_Btn_Editar_Producto.Name = "Mnu_Btn_Editar_Producto"
        Me.Mnu_Btn_Editar_Producto.Text = "Editar producto"
        '
        'Mnu_Btn_Eliminar_Producto
        '
        Me.Mnu_Btn_Eliminar_Producto.Image = CType(resources.GetObject("Mnu_Btn_Eliminar_Producto.Image"), System.Drawing.Image)
        Me.Mnu_Btn_Eliminar_Producto.ImageAlt = CType(resources.GetObject("Mnu_Btn_Eliminar_Producto.ImageAlt"), System.Drawing.Image)
        Me.Mnu_Btn_Eliminar_Producto.Name = "Mnu_Btn_Eliminar_Producto"
        Me.Mnu_Btn_Eliminar_Producto.Text = "Eliminar producto"
        '
        'Mnu_Btn_Copiar
        '
        Me.Mnu_Btn_Copiar.Image = CType(resources.GetObject("Mnu_Btn_Copiar.Image"), System.Drawing.Image)
        Me.Mnu_Btn_Copiar.ImageAlt = CType(resources.GetObject("Mnu_Btn_Copiar.ImageAlt"), System.Drawing.Image)
        Me.Mnu_Btn_Copiar.Name = "Mnu_Btn_Copiar"
        Me.Mnu_Btn_Copiar.Text = "Copiar (portapapeles)"
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
        Me.Btn_Filtro_Pro_Productos.Visible = False
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
        'TouchKeyboard1
        '
        Me.TouchKeyboard1.FloatingLocation = New System.Drawing.Point(0, 0)
        Me.TouchKeyboard1.FloatingSize = New System.Drawing.Size(370, 125)
        Me.TouchKeyboard1.Location = New System.Drawing.Point(0, 0)
        Me.TouchKeyboard1.Size = New System.Drawing.Size(740, 250)
        Me.TouchKeyboard1.Text = ""
        '
        'Bar_Menu_Producto
        '
        Me.Bar_Menu_Producto.AntiAlias = True
        Me.Bar_Menu_Producto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar_Menu_Producto.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Mnu_Pr_Editar_Producto, Me.Btn_Mnu_Pr_Eliminar_Producto, Me.Btn_Mnu_Pr_Estadistica_Producto, Me.Btn_Mnu_Pr_Codigo_De_Reemplazo, Me.Btn_Productos_Asociados, Me.Btn_Mnu_Pr_Cambiar_Codigo_Producto, Me.Btn_Mnu_Pr_Ver_Clasificacion_Producto, Me.Btn_Mnu_Pr_Mantencion_Clasificacion_Producto, Me.Btn_Mnu_Pr_Imagen_Producto, Me.Btn_Mnu_Pr_Codigo_Alternativo, Me.Btn_Mnu_Pr_Kardex_Inventario, Me.Btn_Mnu_Pr_Ubicacion_Producto, Me.Btn_Ocultar, Me.Btn_Ver_Archivos_Adjuntos, Me.Btn_Dimensiones, Me.Btn_Filtrar})
        Me.Bar_Menu_Producto.Location = New System.Drawing.Point(11, 68)
        Me.Bar_Menu_Producto.Name = "Bar_Menu_Producto"
        Me.Bar_Menu_Producto.Size = New System.Drawing.Size(704, 41)
        Me.Bar_Menu_Producto.Stretch = True
        Me.Bar_Menu_Producto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar_Menu_Producto.TabIndex = 34
        Me.Bar_Menu_Producto.TabStop = False
        Me.Bar_Menu_Producto.Text = "Bar2"
        '
        'Btn_Mnu_Pr_Editar_Producto
        '
        Me.Btn_Mnu_Pr_Editar_Producto.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Mnu_Pr_Editar_Producto.Image = CType(resources.GetObject("Btn_Mnu_Pr_Editar_Producto.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Pr_Editar_Producto.ImageAlt = CType(resources.GetObject("Btn_Mnu_Pr_Editar_Producto.ImageAlt"), System.Drawing.Image)
        Me.Btn_Mnu_Pr_Editar_Producto.Name = "Btn_Mnu_Pr_Editar_Producto"
        Me.Btn_Mnu_Pr_Editar_Producto.Tooltip = "Editar producto"
        '
        'Btn_Mnu_Pr_Eliminar_Producto
        '
        Me.Btn_Mnu_Pr_Eliminar_Producto.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Mnu_Pr_Eliminar_Producto.Image = CType(resources.GetObject("Btn_Mnu_Pr_Eliminar_Producto.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Pr_Eliminar_Producto.ImageAlt = CType(resources.GetObject("Btn_Mnu_Pr_Eliminar_Producto.ImageAlt"), System.Drawing.Image)
        Me.Btn_Mnu_Pr_Eliminar_Producto.Name = "Btn_Mnu_Pr_Eliminar_Producto"
        Me.Btn_Mnu_Pr_Eliminar_Producto.Tooltip = "Eliminar producto"
        '
        'Btn_Mnu_Pr_Estadistica_Producto
        '
        Me.Btn_Mnu_Pr_Estadistica_Producto.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Mnu_Pr_Estadistica_Producto.Image = CType(resources.GetObject("Btn_Mnu_Pr_Estadistica_Producto.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Pr_Estadistica_Producto.ImageAlt = CType(resources.GetObject("Btn_Mnu_Pr_Estadistica_Producto.ImageAlt"), System.Drawing.Image)
        Me.Btn_Mnu_Pr_Estadistica_Producto.Name = "Btn_Mnu_Pr_Estadistica_Producto"
        Me.Btn_Mnu_Pr_Estadistica_Producto.Tooltip = "Ver estadísticas del producto/información adicional"
        '
        'Btn_Mnu_Pr_Codigo_De_Reemplazo
        '
        Me.Btn_Mnu_Pr_Codigo_De_Reemplazo.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Mnu_Pr_Codigo_De_Reemplazo.Image = CType(resources.GetObject("Btn_Mnu_Pr_Codigo_De_Reemplazo.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Pr_Codigo_De_Reemplazo.ImageAlt = CType(resources.GetObject("Btn_Mnu_Pr_Codigo_De_Reemplazo.ImageAlt"), System.Drawing.Image)
        Me.Btn_Mnu_Pr_Codigo_De_Reemplazo.Name = "Btn_Mnu_Pr_Codigo_De_Reemplazo"
        Me.Btn_Mnu_Pr_Codigo_De_Reemplazo.Tooltip = "Códigos de reemplazo"
        '
        'Btn_Productos_Asociados
        '
        Me.Btn_Productos_Asociados.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Productos_Asociados.Image = CType(resources.GetObject("Btn_Productos_Asociados.Image"), System.Drawing.Image)
        Me.Btn_Productos_Asociados.ImageAlt = CType(resources.GetObject("Btn_Productos_Asociados.ImageAlt"), System.Drawing.Image)
        Me.Btn_Productos_Asociados.Name = "Btn_Productos_Asociados"
        Me.Btn_Productos_Asociados.Tooltip = "Productos asociados"
        '
        'Btn_Mnu_Pr_Cambiar_Codigo_Producto
        '
        Me.Btn_Mnu_Pr_Cambiar_Codigo_Producto.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Mnu_Pr_Cambiar_Codigo_Producto.Image = CType(resources.GetObject("Btn_Mnu_Pr_Cambiar_Codigo_Producto.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Pr_Cambiar_Codigo_Producto.ImageAlt = CType(resources.GetObject("Btn_Mnu_Pr_Cambiar_Codigo_Producto.ImageAlt"), System.Drawing.Image)
        Me.Btn_Mnu_Pr_Cambiar_Codigo_Producto.Name = "Btn_Mnu_Pr_Cambiar_Codigo_Producto"
        Me.Btn_Mnu_Pr_Cambiar_Codigo_Producto.Tooltip = "Cambiar código del producto"
        '
        'Btn_Mnu_Pr_Ver_Clasificacion_Producto
        '
        Me.Btn_Mnu_Pr_Ver_Clasificacion_Producto.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Mnu_Pr_Ver_Clasificacion_Producto.Image = CType(resources.GetObject("Btn_Mnu_Pr_Ver_Clasificacion_Producto.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Pr_Ver_Clasificacion_Producto.ImageAlt = CType(resources.GetObject("Btn_Mnu_Pr_Ver_Clasificacion_Producto.ImageAlt"), System.Drawing.Image)
        Me.Btn_Mnu_Pr_Ver_Clasificacion_Producto.Name = "Btn_Mnu_Pr_Ver_Clasificacion_Producto"
        Me.Btn_Mnu_Pr_Ver_Clasificacion_Producto.Tooltip = "Ver clasificaciones"
        '
        'Btn_Mnu_Pr_Mantencion_Clasificacion_Producto
        '
        Me.Btn_Mnu_Pr_Mantencion_Clasificacion_Producto.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Mnu_Pr_Mantencion_Clasificacion_Producto.Image = CType(resources.GetObject("Btn_Mnu_Pr_Mantencion_Clasificacion_Producto.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Pr_Mantencion_Clasificacion_Producto.ImageAlt = CType(resources.GetObject("Btn_Mnu_Pr_Mantencion_Clasificacion_Producto.ImageAlt"), System.Drawing.Image)
        Me.Btn_Mnu_Pr_Mantencion_Clasificacion_Producto.Name = "Btn_Mnu_Pr_Mantencion_Clasificacion_Producto"
        Me.Btn_Mnu_Pr_Mantencion_Clasificacion_Producto.Tooltip = "Mantención de clasificaciones"
        '
        'Btn_Mnu_Pr_Imagen_Producto
        '
        Me.Btn_Mnu_Pr_Imagen_Producto.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Mnu_Pr_Imagen_Producto.Image = CType(resources.GetObject("Btn_Mnu_Pr_Imagen_Producto.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Pr_Imagen_Producto.ImageAlt = CType(resources.GetObject("Btn_Mnu_Pr_Imagen_Producto.ImageAlt"), System.Drawing.Image)
        Me.Btn_Mnu_Pr_Imagen_Producto.Name = "Btn_Mnu_Pr_Imagen_Producto"
        Me.Btn_Mnu_Pr_Imagen_Producto.Tooltip = "Imagenes del producto"
        '
        'Btn_Mnu_Pr_Codigo_Alternativo
        '
        Me.Btn_Mnu_Pr_Codigo_Alternativo.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Mnu_Pr_Codigo_Alternativo.Image = CType(resources.GetObject("Btn_Mnu_Pr_Codigo_Alternativo.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Pr_Codigo_Alternativo.ImageAlt = CType(resources.GetObject("Btn_Mnu_Pr_Codigo_Alternativo.ImageAlt"), System.Drawing.Image)
        Me.Btn_Mnu_Pr_Codigo_Alternativo.Name = "Btn_Mnu_Pr_Codigo_Alternativo"
        Me.Btn_Mnu_Pr_Codigo_Alternativo.Tooltip = "Códigos alternativos del producto"
        '
        'Btn_Mnu_Pr_Kardex_Inventario
        '
        Me.Btn_Mnu_Pr_Kardex_Inventario.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Mnu_Pr_Kardex_Inventario.Image = CType(resources.GetObject("Btn_Mnu_Pr_Kardex_Inventario.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Pr_Kardex_Inventario.ImageAlt = CType(resources.GetObject("Btn_Mnu_Pr_Kardex_Inventario.ImageAlt"), System.Drawing.Image)
        Me.Btn_Mnu_Pr_Kardex_Inventario.Name = "Btn_Mnu_Pr_Kardex_Inventario"
        Me.Btn_Mnu_Pr_Kardex_Inventario.Tooltip = "Kardex de inventario"
        '
        'Btn_Mnu_Pr_Ubicacion_Producto
        '
        Me.Btn_Mnu_Pr_Ubicacion_Producto.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Mnu_Pr_Ubicacion_Producto.Image = CType(resources.GetObject("Btn_Mnu_Pr_Ubicacion_Producto.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Pr_Ubicacion_Producto.ImageAlt = CType(resources.GetObject("Btn_Mnu_Pr_Ubicacion_Producto.ImageAlt"), System.Drawing.Image)
        Me.Btn_Mnu_Pr_Ubicacion_Producto.Name = "Btn_Mnu_Pr_Ubicacion_Producto"
        Me.Btn_Mnu_Pr_Ubicacion_Producto.Tooltip = "Ubicación del producto"
        '
        'Btn_Ocultar
        '
        Me.Btn_Ocultar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Ocultar.Image = CType(resources.GetObject("Btn_Ocultar.Image"), System.Drawing.Image)
        Me.Btn_Ocultar.ImageAlt = CType(resources.GetObject("Btn_Ocultar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Ocultar.Name = "Btn_Ocultar"
        Me.Btn_Ocultar.Text = "Ocultar"
        Me.Btn_Ocultar.Tooltip = "Ocultar/Desocultar"
        '
        'Btn_Ver_Archivos_Adjuntos
        '
        Me.Btn_Ver_Archivos_Adjuntos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Ver_Archivos_Adjuntos.Image = CType(resources.GetObject("Btn_Ver_Archivos_Adjuntos.Image"), System.Drawing.Image)
        Me.Btn_Ver_Archivos_Adjuntos.ImageAlt = CType(resources.GetObject("Btn_Ver_Archivos_Adjuntos.ImageAlt"), System.Drawing.Image)
        Me.Btn_Ver_Archivos_Adjuntos.Name = "Btn_Ver_Archivos_Adjuntos"
        Me.Btn_Ver_Archivos_Adjuntos.Tooltip = "Archivos adjuntos asociados al producto"
        '
        'Btn_Dimensiones
        '
        Me.Btn_Dimensiones.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Dimensiones.Image = CType(resources.GetObject("Btn_Dimensiones.Image"), System.Drawing.Image)
        Me.Btn_Dimensiones.ImageAlt = CType(resources.GetObject("Btn_Dimensiones.ImageAlt"), System.Drawing.Image)
        Me.Btn_Dimensiones.Name = "Btn_Dimensiones"
        Me.Btn_Dimensiones.Tooltip = "Dimensiones"
        '
        'Btn_Filtrar
        '
        Me.Btn_Filtrar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Filtrar.Image = CType(resources.GetObject("Btn_Filtrar.Image"), System.Drawing.Image)
        Me.Btn_Filtrar.ImageAlt = CType(resources.GetObject("Btn_Filtrar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Filtrar.Name = "Btn_Filtrar"
        Me.Btn_Filtrar.Tooltip = "Dimensiones"
        '
        'ButtonItem8
        '
        Me.ButtonItem8.Image = CType(resources.GetObject("ButtonItem8.Image"), System.Drawing.Image)
        Me.ButtonItem8.Name = "ButtonItem8"
        Me.ButtonItem8.Text = "OCULTAR"
        '
        'ButtonItem9
        '
        Me.ButtonItem9.Image = CType(resources.GetObject("ButtonItem9.Image"), System.Drawing.Image)
        Me.ButtonItem9.Name = "ButtonItem9"
        Me.ButtonItem9.Text = "DESOCULTAR"
        '
        'Chk_Top20
        '
        Me.Chk_Top20.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Top20.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Top20.CheckBoxImageChecked = CType(resources.GetObject("Chk_Top20.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Top20.CheckBoxImageUnChecked = CType(resources.GetObject("Chk_Top20.CheckBoxImageUnChecked"), System.Drawing.Image)
        Me.Chk_Top20.FocusCuesEnabled = False
        Me.Chk_Top20.ForeColor = System.Drawing.Color.Black
        Me.Chk_Top20.Location = New System.Drawing.Point(383, 115)
        Me.Chk_Top20.Name = "Chk_Top20"
        Me.Chk_Top20.Size = New System.Drawing.Size(359, 25)
        Me.Chk_Top20.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Top20.TabIndex = 51
        Me.Chk_Top20.Text = "Al buscar productos presentar esta vista de datos como predefinida."
        Me.Chk_Top20.Visible = False
        '
        'Btn_Maestra_Productos
        '
        Me.Btn_Maestra_Productos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Maestra_Productos.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Maestra_Productos.Location = New System.Drawing.Point(5, 115)
        Me.Btn_Maestra_Productos.Name = "Btn_Maestra_Productos"
        Me.Btn_Maestra_Productos.Size = New System.Drawing.Size(183, 25)
        Me.Btn_Maestra_Productos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Maestra_Productos.TabIndex = 53
        Me.Btn_Maestra_Productos.Text = "Maestra de productos"
        '
        'Btn_Top20
        '
        Me.Btn_Top20.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Top20.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Top20.Location = New System.Drawing.Point(194, 115)
        Me.Btn_Top20.Name = "Btn_Top20"
        Me.Btn_Top20.Size = New System.Drawing.Size(183, 25)
        Me.Btn_Top20.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Top20.TabIndex = 54
        Me.Btn_Top20.Text = "Top 20 por entidad"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "ok.png")
        Me.ImageList1.Images.SetKeyName(1, "checkmark_24px.png")
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(5, 520)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(71, 23)
        Me.LabelX3.TabIndex = 56
        Me.LabelX3.Text = "Ficha técnica"
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.AllowUserToDeleteRows = False
        Me.Grilla.BackgroundColor = System.Drawing.Color.White
        Me.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla.DefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla.Location = New System.Drawing.Point(5, 146)
        Me.Grilla.Name = "Grilla"
        Me.Grilla.Size = New System.Drawing.Size(851, 368)
        Me.Grilla.TabIndex = 57
        '
        'Chk_MostrarVendidosUlt3Meses
        '
        Me.Chk_MostrarVendidosUlt3Meses.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_MostrarVendidosUlt3Meses.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_MostrarVendidosUlt3Meses.CheckBoxImageChecked = CType(resources.GetObject("Chk_MostrarVendidosUlt3Meses.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_MostrarVendidosUlt3Meses.FocusCuesEnabled = False
        Me.Chk_MostrarVendidosUlt3Meses.ForeColor = System.Drawing.Color.Black
        Me.Chk_MostrarVendidosUlt3Meses.Location = New System.Drawing.Point(5, 559)
        Me.Chk_MostrarVendidosUlt3Meses.Name = "Chk_MostrarVendidosUlt3Meses"
        Me.Chk_MostrarVendidosUlt3Meses.Size = New System.Drawing.Size(281, 25)
        Me.Chk_MostrarVendidosUlt3Meses.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_MostrarVendidosUlt3Meses.TabIndex = 59
        Me.Chk_MostrarVendidosUlt3Meses.Text = "Mostrar solo productos vendidos los últimos 3 meses"
        Me.Chk_MostrarVendidosUlt3Meses.Visible = False
        '
        'Chk_StockFisicoMayorCero
        '
        Me.Chk_StockFisicoMayorCero.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_StockFisicoMayorCero.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_StockFisicoMayorCero.CheckBoxImageChecked = CType(resources.GetObject("Chk_StockFisicoMayorCero.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_StockFisicoMayorCero.FocusCuesEnabled = False
        Me.Chk_StockFisicoMayorCero.ForeColor = System.Drawing.Color.Black
        Me.Chk_StockFisicoMayorCero.Location = New System.Drawing.Point(292, 559)
        Me.Chk_StockFisicoMayorCero.Name = "Chk_StockFisicoMayorCero"
        Me.Chk_StockFisicoMayorCero.Size = New System.Drawing.Size(114, 25)
        Me.Chk_StockFisicoMayorCero.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_StockFisicoMayorCero.TabIndex = 60
        Me.Chk_StockFisicoMayorCero.Text = "Stock físico > 0"
        '
        'Imagenes_20x20
        '
        Me.Imagenes_20x20.ImageStream = CType(resources.GetObject("Imagenes_20x20.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagenes_20x20.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagenes_20x20.Images.SetKeyName(0, "filter-ok.png")
        Me.Imagenes_20x20.Images.SetKeyName(1, "filter.png")
        '
        'Imagenes_16x16
        '
        Me.Imagenes_16x16.ImageStream = CType(resources.GetObject("Imagenes_16x16.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagenes_16x16.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagenes_16x16.Images.SetKeyName(0, "filter.png")
        Me.Imagenes_16x16.Images.SetKeyName(1, "ok.png")
        Me.Imagenes_16x16.Images.SetKeyName(2, "delete.png")
        '
        'Imagenes_32x32
        '
        Me.Imagenes_32x32.ImageStream = CType(resources.GetObject("Imagenes_32x32.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagenes_32x32.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagenes_32x32.Images.SetKeyName(0, "filter.png")
        Me.Imagenes_32x32.Images.SetKeyName(1, "filter-ok.png")
        '
        'Imagenes_32x32_Dark
        '
        Me.Imagenes_32x32_Dark.ImageStream = CType(resources.GetObject("Imagenes_32x32_Dark.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagenes_32x32_Dark.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagenes_32x32_Dark.Images.SetKeyName(0, "filter.png")
        Me.Imagenes_32x32_Dark.Images.SetKeyName(1, "filter-ok.png")
        '
        'Frm_BkpPostBusquedaEspecial_Mt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(860, 631)
        Me.Controls.Add(Me.Chk_StockFisicoMayorCero)
        Me.Controls.Add(Me.Chk_MostrarVendidosUlt3Meses)
        Me.Controls.Add(Me.Context_Menu_Solicitud_Compra)
        Me.Controls.Add(Me.Lbl_Patente)
        Me.Controls.Add(Me.Txt_Patente)
        Me.Controls.Add(Me.Grilla)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.Txt_Ficha)
        Me.Controls.Add(Me.Btn_Top20)
        Me.Controls.Add(Me.Btn_Maestra_Productos)
        Me.Controls.Add(Me.Chk_Top20)
        Me.Controls.Add(Me.Bar_Menu_Producto)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Grupo_BusquedaProducto)
        Me.Controls.Add(Me.CmbCantFilas)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_BkpPostBusquedaEspecial_Mt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Productos del sistema."
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo_BusquedaProducto.ResumeLayout(False)
        CType(Me.Context_Menu_Solicitud_Compra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar_Menu_Producto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Public WithEvents BtnCrearProductos As DevComponents.DotNetBar.ButtonItem
    Public WithEvents BtnBuscarAlternativos As DevComponents.DotNetBar.ButtonItem
    Public WithEvents BtnExportaExcel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ChkMostrarOcultos As DevComponents.DotNetBar.CheckBoxItem
    Friend WithEvents LblOculto As DevComponents.DotNetBar.LabelItem
    Public WithEvents BtnBuscarListaCostosProveedor As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Public WithEvents CmbCantFilas As System.Windows.Forms.ComboBox
    Friend WithEvents Grupo_BusquedaProducto As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents TxtCodigo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TouchKeyboard1 As DevComponents.DotNetBar.Keyboard.TouchKeyboard
    Public WithEvents Btn_Teclado As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Bar_Menu_Producto As DevComponents.DotNetBar.Bar
    Public WithEvents Btn_Mnu_Pr_Estadistica_Producto As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Mnu_Pr_Imagen_Producto As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Mnu_Pr_Codigo_De_Reemplazo As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Mnu_Pr_Ubicacion_Producto As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Mnu_Pr_Mantencion_Clasificacion_Producto As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Mnu_Pr_Codigo_Alternativo As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Mnu_Pr_Kardex_Inventario As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Ocultar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Mnu_Pr_Ver_Clasificacion_Producto As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Mnu_Pr_Editar_Producto As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Mnu_Pr_Eliminar_Producto As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Mnu_Pr_Cambiar_Codigo_Producto As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem8 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem9 As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Ver_Archivos_Adjuntos As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Context_Menu_Solicitud_Compra As DevComponents.DotNetBar.ContextMenuBar
    Public WithEvents Menu_Contextual_01 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Lbl_Mnu_1 As DevComponents.DotNetBar.LabelItem
    Public WithEvents Mnu_Btn_Ver_Informacion_de_producto As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Mnu_Btn_Codigos_Reemplazo As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Mnu_Btn_Ocultar_Desocultar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Mnu_Btn_Cambiar_Codigo_Producto As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Mnu_Btn_Editar_Producto As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Mnu_Btn_Eliminar_Producto As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Mnu_Btn_Pr_Ver_Clasificacion_Producto As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Mnu_Btn_Imagenes_producto As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Mnu_Btn_Ocultar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Mnu_Btn_Desocultar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Mnu_Btn_Ver_Clasificaciones_producto As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Mnu_Btn_Mantencion_clasificaciones_producto As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Mnu_Btn_Mant_codigos_alternativos As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Mnu_Btn_Kardex_Inventario As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Mnu_Btn_Ubicacion_Producto As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Mnu_Btn_Archivos_Asociados_Producto As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Mnu_Btn_Copiar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Productos_Asociados As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Mnu_Btn_Productos_Asociados As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents CirProg_Actualizando As DevComponents.DotNetBar.CircularProgressItem
    Friend WithEvents Lbl_Cargando_Productos As DevComponents.DotNetBar.LabelItem
    Public WithEvents Btn_Orden_Bodegas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Chk_Top20 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Btn_Top20 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Maestra_Productos As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ImageList1 As ImageList
    Public WithEvents Btn_Seleccion_Multiple As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Marcar_Seleccionados As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Desmarcar_Seleccionados As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Public WithEvents Btn_Dimensiones As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Mnu_Btn_Dimensiones As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Txt_Ficha As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Migrar_Producto As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Lbl_Patente As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Patente As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txtdescripcion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_CodAlternativo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Chk_MostrarVendidosUlt3Meses As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_StockFisicoMayorCero As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Btn_Filtrar As DevComponents.DotNetBar.ButtonItem
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
    Friend WithEvents Imagenes_20x20 As ImageList
    Friend WithEvents Imagenes_16x16 As ImageList
    Friend WithEvents Imagenes_32x32 As ImageList
    Friend WithEvents Imagenes_32x32_Dark As ImageList
End Class
