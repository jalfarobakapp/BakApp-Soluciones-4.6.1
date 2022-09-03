<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Vales_Listado_Espera_Filtro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Vales_Listado_Espera_Filtro))
        Me.Grupo_Productos = New System.Windows.Forms.GroupBox
        Me.Btn_Producto = New DevComponents.DotNetBar.ButtonX
        Me.Rdb_Producto_Uno = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.Rdb_Producto_Todos = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.TxtProductoFiltro = New System.Windows.Forms.TextBox
        Me.Grupo_TipoEntrega = New System.Windows.Forms.GroupBox
        Me.ItemPanel1 = New DevComponents.DotNetBar.ItemPanel
        Me.Rdb_Retira_Cliente = New DevComponents.DotNetBar.CheckBoxItem
        Me.Rdb_Despacho_Domicilio = New DevComponents.DotNetBar.CheckBoxItem
        Me.Rdb_Ambos = New DevComponents.DotNetBar.CheckBoxItem
        Me.Txt_Documento = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.Txt_NroVale = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.BtnFiltrar = New DevComponents.DotNetBar.ButtonItem
        Me.BtnLimpiar = New DevComponents.DotNetBar.ButtonItem
        Me.Btn_Salir = New DevComponents.DotNetBar.ButtonItem
        Me.Cmb_Func_Marca = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.Grupo_Fecha = New System.Windows.Forms.GroupBox
        Me.Rdb_Fecha_Emision_Todas = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.Rdb_Fecha_Emision_Desde_Hasta = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.DtpFecha_desde = New System.Windows.Forms.DateTimePicker
        Me.DtpFecha_hasta = New System.Windows.Forms.DateTimePicker
        Me.LblFecha1 = New DevComponents.DotNetBar.LabelX
        Me.LblFecha2 = New DevComponents.DotNetBar.LabelX
        Me.Grupo_Cliente = New System.Windows.Forms.GroupBox
        Me.Btn_Entidad_Una = New DevComponents.DotNetBar.ButtonX
        Me.Rdb_Cliente_Uno = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.Txt_Entidad = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.Rdb_Cliente_Todas = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.Chk_Nulas = New DevComponents.DotNetBar.CheckBoxItem
        Me.Chk_EnprocesoOc = New DevComponents.DotNetBar.CheckBoxItem
        Me.Btn_Tipo_doc_Buscasr = New DevComponents.DotNetBar.ButtonX
        Me.Grupo_Func_Marca = New System.Windows.Forms.GroupBox
        Me.Rdb_Func_Marca_Todos = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.Rdb_Func_Marca_Uno = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.Grupo_Func_Activa = New System.Windows.Forms.GroupBox
        Me.Rdb_Func_Activa_Todos = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.Rdb_Func_Activa_Uno = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.Cmb_Func_Activa = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.Grupo_NroVale = New System.Windows.Forms.GroupBox
        Me.Rdb_Vale_todos = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.Rdb_Vale_Uno = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.LblNroVale = New DevComponents.DotNetBar.LabelX
        Me.Grupo_Documentos = New System.Windows.Forms.GroupBox
        Me.CmbTipoDoc = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.Rdb_Tipo_doc_todos = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.Rdb_Tipo_doc_Uno = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.Grupo_Estado = New System.Windows.Forms.GroupBox
        Me.ItemPanel2 = New DevComponents.DotNetBar.ItemPanel
        Me.Chk_VerMarcadas = New DevComponents.DotNetBar.CheckBoxItem
        Me.Chk_VerActivas = New DevComponents.DotNetBar.CheckBoxItem
        Me.Chk_VerCerradas = New DevComponents.DotNetBar.CheckBoxItem
        Me.Chk_VerNulas = New DevComponents.DotNetBar.CheckBoxItem
        Me.Grupo_Productos.SuspendLayout()
        Me.Grupo_TipoEntrega.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_Fecha.SuspendLayout()
        Me.Grupo_Cliente.SuspendLayout()
        Me.Grupo_Func_Marca.SuspendLayout()
        Me.Grupo_Func_Activa.SuspendLayout()
        Me.Grupo_NroVale.SuspendLayout()
        Me.Grupo_Documentos.SuspendLayout()
        Me.Grupo_Estado.SuspendLayout()
        Me.SuspendLayout()
        '
        'Grupo_Productos
        '
        Me.Grupo_Productos.BackColor = System.Drawing.Color.Transparent
        Me.Grupo_Productos.Controls.Add(Me.Btn_Producto)
        Me.Grupo_Productos.Controls.Add(Me.Rdb_Producto_Uno)
        Me.Grupo_Productos.Controls.Add(Me.Rdb_Producto_Todos)
        Me.Grupo_Productos.Controls.Add(Me.TxtProductoFiltro)
        Me.Grupo_Productos.ForeColor = System.Drawing.Color.Black
        Me.Grupo_Productos.Location = New System.Drawing.Point(8, 286)
        Me.Grupo_Productos.Name = "Grupo_Productos"
        Me.Grupo_Productos.Size = New System.Drawing.Size(588, 51)
        Me.Grupo_Productos.TabIndex = 41
        Me.Grupo_Productos.TabStop = False
        Me.Grupo_Productos.Text = "Productos que contiene"
        '
        'Btn_Producto
        '
        Me.Btn_Producto.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Producto.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Producto.Image = CType(resources.GetObject("Btn_Producto.Image"), System.Drawing.Image)
        Me.Btn_Producto.Location = New System.Drawing.Point(171, 21)
        Me.Btn_Producto.Name = "Btn_Producto"
        Me.Btn_Producto.Size = New System.Drawing.Size(31, 23)
        Me.Btn_Producto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Producto.TabIndex = 30
        Me.Btn_Producto.Tooltip = "Ver selección"
        '
        'Rdb_Producto_Uno
        '
        Me.Rdb_Producto_Uno.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Rdb_Producto_Uno.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Producto_Uno.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Producto_Uno.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Producto_Uno.Location = New System.Drawing.Point(59, 21)
        Me.Rdb_Producto_Uno.Name = "Rdb_Producto_Uno"
        Me.Rdb_Producto_Uno.Size = New System.Drawing.Size(106, 23)
        Me.Rdb_Producto_Uno.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Producto_Uno.TabIndex = 29
        Me.Rdb_Producto_Uno.Text = "Uno en especifico"
        '
        'Rdb_Producto_Todos
        '
        Me.Rdb_Producto_Todos.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Rdb_Producto_Todos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Producto_Todos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Producto_Todos.Checked = True
        Me.Rdb_Producto_Todos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Producto_Todos.CheckValue = "Y"
        Me.Rdb_Producto_Todos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Producto_Todos.Location = New System.Drawing.Point(6, 21)
        Me.Rdb_Producto_Todos.Name = "Rdb_Producto_Todos"
        Me.Rdb_Producto_Todos.Size = New System.Drawing.Size(53, 23)
        Me.Rdb_Producto_Todos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Producto_Todos.TabIndex = 28
        Me.Rdb_Producto_Todos.Text = "Todos"
        '
        'TxtProductoFiltro
        '
        Me.TxtProductoFiltro.BackColor = System.Drawing.Color.White
        Me.TxtProductoFiltro.ForeColor = System.Drawing.Color.Black
        Me.TxtProductoFiltro.Location = New System.Drawing.Point(208, 21)
        Me.TxtProductoFiltro.Name = "TxtProductoFiltro"
        Me.TxtProductoFiltro.ReadOnly = True
        Me.TxtProductoFiltro.Size = New System.Drawing.Size(373, 22)
        Me.TxtProductoFiltro.TabIndex = 8
        Me.TxtProductoFiltro.TabStop = False
        '
        'Grupo_TipoEntrega
        '
        Me.Grupo_TipoEntrega.BackColor = System.Drawing.Color.Transparent
        Me.Grupo_TipoEntrega.Controls.Add(Me.ItemPanel1)
        Me.Grupo_TipoEntrega.ForeColor = System.Drawing.Color.Black
        Me.Grupo_TipoEntrega.Location = New System.Drawing.Point(173, 343)
        Me.Grupo_TipoEntrega.Name = "Grupo_TipoEntrega"
        Me.Grupo_TipoEntrega.Size = New System.Drawing.Size(176, 129)
        Me.Grupo_TipoEntrega.TabIndex = 40
        Me.Grupo_TipoEntrega.TabStop = False
        Me.Grupo_TipoEntrega.Text = "Tipo entrega"
        '
        'ItemPanel1
        '
        '
        '
        '
        Me.ItemPanel1.BackgroundStyle.BackColor = System.Drawing.Color.White
        Me.ItemPanel1.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ItemPanel1.BackgroundStyle.BorderBottomWidth = 1
        Me.ItemPanel1.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ItemPanel1.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ItemPanel1.BackgroundStyle.BorderLeftWidth = 1
        Me.ItemPanel1.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ItemPanel1.BackgroundStyle.BorderRightWidth = 1
        Me.ItemPanel1.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ItemPanel1.BackgroundStyle.BorderTopWidth = 1
        Me.ItemPanel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemPanel1.ContainerControlProcessDialogKey = True
        Me.ItemPanel1.DragDropSupport = True
        Me.ItemPanel1.ForeColor = System.Drawing.Color.Black
        Me.ItemPanel1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Rdb_Retira_Cliente, Me.Rdb_Despacho_Domicilio, Me.Rdb_Ambos})
        Me.ItemPanel1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemPanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.ItemPanel1.Location = New System.Drawing.Point(6, 17)
        Me.ItemPanel1.Name = "ItemPanel1"
        Me.ItemPanel1.Size = New System.Drawing.Size(161, 90)
        Me.ItemPanel1.TabIndex = 1
        Me.ItemPanel1.Text = "ItemPanel1"
        '
        'Rdb_Retira_Cliente
        '
        Me.Rdb_Retira_Cliente.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Retira_Cliente.Name = "Rdb_Retira_Cliente"
        Me.Rdb_Retira_Cliente.Text = "RETIRA CLIENTE"
        '
        'Rdb_Despacho_Domicilio
        '
        Me.Rdb_Despacho_Domicilio.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Despacho_Domicilio.Name = "Rdb_Despacho_Domicilio"
        Me.Rdb_Despacho_Domicilio.Text = "DESPACHO A DOMICILIO"
        '
        'Rdb_Ambos
        '
        Me.Rdb_Ambos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Ambos.Checked = True
        Me.Rdb_Ambos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Ambos.Name = "Rdb_Ambos"
        Me.Rdb_Ambos.Text = "AMBOS"
        '
        'Txt_Documento
        '
        Me.Txt_Documento.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Documento.Border.Class = "TextBoxBorder"
        Me.Txt_Documento.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Documento.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Documento.FocusHighlightEnabled = True
        Me.Txt_Documento.ForeColor = System.Drawing.Color.Black
        Me.Txt_Documento.Location = New System.Drawing.Point(178, 50)
        Me.Txt_Documento.Name = "Txt_Documento"
        Me.Txt_Documento.PreventEnterBeep = True
        Me.Txt_Documento.Size = New System.Drawing.Size(107, 22)
        Me.Txt_Documento.TabIndex = 37
        Me.Txt_Documento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Txt_NroVale
        '
        Me.Txt_NroVale.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_NroVale.Border.Class = "TextBoxBorder"
        Me.Txt_NroVale.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_NroVale.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_NroVale.FocusHighlightEnabled = True
        Me.Txt_NroVale.ForeColor = System.Drawing.Color.Black
        Me.Txt_NroVale.Location = New System.Drawing.Point(181, 50)
        Me.Txt_NroVale.MaxLength = 10
        Me.Txt_NroVale.Name = "Txt_NroVale"
        Me.Txt_NroVale.PreventEnterBeep = True
        Me.Txt_NroVale.Size = New System.Drawing.Size(100, 22)
        Me.Txt_NroVale.TabIndex = 35
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnFiltrar, Me.BtnLimpiar, Me.Btn_Salir})
        Me.Bar1.Location = New System.Drawing.Point(0, 483)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(608, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 33
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnFiltrar
        '
        Me.BtnFiltrar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnFiltrar.ForeColor = System.Drawing.Color.Black
        Me.BtnFiltrar.Image = CType(resources.GetObject("BtnFiltrar.Image"), System.Drawing.Image)
        Me.BtnFiltrar.Name = "BtnFiltrar"
        Me.BtnFiltrar.Text = "Aplicar filtro"
        '
        'BtnLimpiar
        '
        Me.BtnLimpiar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnLimpiar.ForeColor = System.Drawing.Color.Black
        Me.BtnLimpiar.Name = "BtnLimpiar"
        '
        'Btn_Salir
        '
        Me.Btn_Salir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Salir.ForeColor = System.Drawing.Color.Black
        Me.Btn_Salir.Image = CType(resources.GetObject("Btn_Salir.Image"), System.Drawing.Image)
        Me.Btn_Salir.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Tooltip = "Salir"
        '
        'Cmb_Func_Marca
        '
        Me.Cmb_Func_Marca.DisplayMember = "Text"
        Me.Cmb_Func_Marca.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Func_Marca.FocusHighlightEnabled = True
        Me.Cmb_Func_Marca.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Func_Marca.FormattingEnabled = True
        Me.Cmb_Func_Marca.ItemHeight = 16
        Me.Cmb_Func_Marca.Location = New System.Drawing.Point(6, 50)
        Me.Cmb_Func_Marca.Name = "Cmb_Func_Marca"
        Me.Cmb_Func_Marca.Size = New System.Drawing.Size(275, 22)
        Me.Cmb_Func_Marca.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Func_Marca.TabIndex = 31
        '
        'Grupo_Fecha
        '
        Me.Grupo_Fecha.BackColor = System.Drawing.Color.White
        Me.Grupo_Fecha.Controls.Add(Me.Rdb_Fecha_Emision_Todas)
        Me.Grupo_Fecha.Controls.Add(Me.Rdb_Fecha_Emision_Desde_Hasta)
        Me.Grupo_Fecha.Controls.Add(Me.DtpFecha_desde)
        Me.Grupo_Fecha.Controls.Add(Me.DtpFecha_hasta)
        Me.Grupo_Fecha.Controls.Add(Me.LblFecha1)
        Me.Grupo_Fecha.Controls.Add(Me.LblFecha2)
        Me.Grupo_Fecha.ForeColor = System.Drawing.Color.Black
        Me.Grupo_Fecha.Location = New System.Drawing.Point(12, 174)
        Me.Grupo_Fecha.Name = "Grupo_Fecha"
        Me.Grupo_Fecha.Size = New System.Drawing.Size(584, 47)
        Me.Grupo_Fecha.TabIndex = 42
        Me.Grupo_Fecha.TabStop = False
        Me.Grupo_Fecha.Text = "Fecha de emisión"
        '
        'Rdb_Fecha_Emision_Todas
        '
        Me.Rdb_Fecha_Emision_Todas.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Rdb_Fecha_Emision_Todas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Fecha_Emision_Todas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Fecha_Emision_Todas.Checked = True
        Me.Rdb_Fecha_Emision_Todas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Fecha_Emision_Todas.CheckValue = "Y"
        Me.Rdb_Fecha_Emision_Todas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Fecha_Emision_Todas.Location = New System.Drawing.Point(6, 20)
        Me.Rdb_Fecha_Emision_Todas.Name = "Rdb_Fecha_Emision_Todas"
        Me.Rdb_Fecha_Emision_Todas.Size = New System.Drawing.Size(47, 23)
        Me.Rdb_Fecha_Emision_Todas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Fecha_Emision_Todas.TabIndex = 25
        Me.Rdb_Fecha_Emision_Todas.Text = "Todas"
        '
        'Rdb_Fecha_Emision_Desde_Hasta
        '
        Me.Rdb_Fecha_Emision_Desde_Hasta.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Rdb_Fecha_Emision_Desde_Hasta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Fecha_Emision_Desde_Hasta.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Fecha_Emision_Desde_Hasta.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Fecha_Emision_Desde_Hasta.Location = New System.Drawing.Point(59, 20)
        Me.Rdb_Fecha_Emision_Desde_Hasta.Name = "Rdb_Fecha_Emision_Desde_Hasta"
        Me.Rdb_Fecha_Emision_Desde_Hasta.Size = New System.Drawing.Size(97, 23)
        Me.Rdb_Fecha_Emision_Desde_Hasta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Fecha_Emision_Desde_Hasta.TabIndex = 24
        Me.Rdb_Fecha_Emision_Desde_Hasta.Text = "Emitidos entre"
        '
        'DtpFecha_desde
        '
        Me.DtpFecha_desde.BackColor = System.Drawing.Color.White
        Me.DtpFecha_desde.ForeColor = System.Drawing.Color.Black
        Me.DtpFecha_desde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFecha_desde.Location = New System.Drawing.Point(225, 20)
        Me.DtpFecha_desde.Name = "DtpFecha_desde"
        Me.DtpFecha_desde.Size = New System.Drawing.Size(93, 22)
        Me.DtpFecha_desde.TabIndex = 13
        '
        'DtpFecha_hasta
        '
        Me.DtpFecha_hasta.BackColor = System.Drawing.Color.White
        Me.DtpFecha_hasta.ForeColor = System.Drawing.Color.Black
        Me.DtpFecha_hasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFecha_hasta.Location = New System.Drawing.Point(375, 20)
        Me.DtpFecha_hasta.Name = "DtpFecha_hasta"
        Me.DtpFecha_hasta.Size = New System.Drawing.Size(93, 22)
        Me.DtpFecha_hasta.TabIndex = 14
        '
        'LblFecha1
        '
        Me.LblFecha1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LblFecha1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblFecha1.ForeColor = System.Drawing.Color.Black
        Me.LblFecha1.Location = New System.Drawing.Point(182, 19)
        Me.LblFecha1.Name = "LblFecha1"
        Me.LblFecha1.Size = New System.Drawing.Size(46, 23)
        Me.LblFecha1.TabIndex = 22
        Me.LblFecha1.Text = "Desde"
        '
        'LblFecha2
        '
        Me.LblFecha2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LblFecha2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblFecha2.ForeColor = System.Drawing.Color.Black
        Me.LblFecha2.Location = New System.Drawing.Point(333, 19)
        Me.LblFecha2.Name = "LblFecha2"
        Me.LblFecha2.Size = New System.Drawing.Size(36, 23)
        Me.LblFecha2.TabIndex = 23
        Me.LblFecha2.Text = "Hasta"
        '
        'Grupo_Cliente
        '
        Me.Grupo_Cliente.BackColor = System.Drawing.Color.White
        Me.Grupo_Cliente.Controls.Add(Me.Btn_Entidad_Una)
        Me.Grupo_Cliente.Controls.Add(Me.Rdb_Cliente_Uno)
        Me.Grupo_Cliente.Controls.Add(Me.Txt_Entidad)
        Me.Grupo_Cliente.Controls.Add(Me.Rdb_Cliente_Todas)
        Me.Grupo_Cliente.ForeColor = System.Drawing.Color.Black
        Me.Grupo_Cliente.Location = New System.Drawing.Point(8, 227)
        Me.Grupo_Cliente.Name = "Grupo_Cliente"
        Me.Grupo_Cliente.Size = New System.Drawing.Size(588, 53)
        Me.Grupo_Cliente.TabIndex = 43
        Me.Grupo_Cliente.TabStop = False
        Me.Grupo_Cliente.Text = "Entidad del documento (cliente)"
        '
        'Btn_Entidad_Una
        '
        Me.Btn_Entidad_Una.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Entidad_Una.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Entidad_Una.Image = CType(resources.GetObject("Btn_Entidad_Una.Image"), System.Drawing.Image)
        Me.Btn_Entidad_Una.Location = New System.Drawing.Point(171, 21)
        Me.Btn_Entidad_Una.Name = "Btn_Entidad_Una"
        Me.Btn_Entidad_Una.Size = New System.Drawing.Size(31, 23)
        Me.Btn_Entidad_Una.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Entidad_Una.TabIndex = 28
        Me.Btn_Entidad_Una.Tooltip = "Ver selección"
        '
        'Rdb_Cliente_Uno
        '
        Me.Rdb_Cliente_Uno.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Rdb_Cliente_Uno.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Cliente_Uno.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Cliente_Uno.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Cliente_Uno.Location = New System.Drawing.Point(59, 22)
        Me.Rdb_Cliente_Uno.Name = "Rdb_Cliente_Uno"
        Me.Rdb_Cliente_Uno.Size = New System.Drawing.Size(106, 23)
        Me.Rdb_Cliente_Uno.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Cliente_Uno.TabIndex = 27
        Me.Rdb_Cliente_Uno.Text = "Uno en especifico"
        '
        'Txt_Entidad
        '
        Me.Txt_Entidad.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Entidad.Border.Class = "TextBoxBorder"
        Me.Txt_Entidad.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Entidad.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Entidad.Enabled = False
        Me.Txt_Entidad.ForeColor = System.Drawing.Color.Black
        Me.Txt_Entidad.Location = New System.Drawing.Point(208, 22)
        Me.Txt_Entidad.Name = "Txt_Entidad"
        Me.Txt_Entidad.PreventEnterBeep = True
        Me.Txt_Entidad.Size = New System.Drawing.Size(373, 22)
        Me.Txt_Entidad.TabIndex = 9
        '
        'Rdb_Cliente_Todas
        '
        Me.Rdb_Cliente_Todas.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Rdb_Cliente_Todas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Cliente_Todas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Cliente_Todas.Checked = True
        Me.Rdb_Cliente_Todas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Cliente_Todas.CheckValue = "Y"
        Me.Rdb_Cliente_Todas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Cliente_Todas.Location = New System.Drawing.Point(6, 21)
        Me.Rdb_Cliente_Todas.Name = "Rdb_Cliente_Todas"
        Me.Rdb_Cliente_Todas.Size = New System.Drawing.Size(47, 23)
        Me.Rdb_Cliente_Todas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Cliente_Todas.TabIndex = 22
        Me.Rdb_Cliente_Todas.Text = "Todas"
        '
        'Chk_Nulas
        '
        Me.Chk_Nulas.Name = "Chk_Nulas"
        Me.Chk_Nulas.Text = "NULAS"
        '
        'Chk_EnprocesoOc
        '
        Me.Chk_EnprocesoOc.Name = "Chk_EnprocesoOc"
        Me.Chk_EnprocesoOc.Text = "EN PROCESO DE OC"
        '
        'Btn_Tipo_doc_Buscasr
        '
        Me.Btn_Tipo_doc_Buscasr.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Tipo_doc_Buscasr.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Tipo_doc_Buscasr.Image = CType(resources.GetObject("Btn_Tipo_doc_Buscasr.Image"), System.Drawing.Image)
        Me.Btn_Tipo_doc_Buscasr.Location = New System.Drawing.Point(141, 51)
        Me.Btn_Tipo_doc_Buscasr.Name = "Btn_Tipo_doc_Buscasr"
        Me.Btn_Tipo_doc_Buscasr.Size = New System.Drawing.Size(31, 21)
        Me.Btn_Tipo_doc_Buscasr.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Tipo_doc_Buscasr.TabIndex = 46
        Me.Btn_Tipo_doc_Buscasr.Tooltip = "Ver selección"
        '
        'Grupo_Func_Marca
        '
        Me.Grupo_Func_Marca.BackColor = System.Drawing.Color.White
        Me.Grupo_Func_Marca.Controls.Add(Me.Rdb_Func_Marca_Todos)
        Me.Grupo_Func_Marca.Controls.Add(Me.Rdb_Func_Marca_Uno)
        Me.Grupo_Func_Marca.Controls.Add(Me.Cmb_Func_Marca)
        Me.Grupo_Func_Marca.ForeColor = System.Drawing.Color.Black
        Me.Grupo_Func_Marca.Location = New System.Drawing.Point(8, 92)
        Me.Grupo_Func_Marca.Name = "Grupo_Func_Marca"
        Me.Grupo_Func_Marca.Size = New System.Drawing.Size(290, 80)
        Me.Grupo_Func_Marca.TabIndex = 47
        Me.Grupo_Func_Marca.TabStop = False
        Me.Grupo_Func_Marca.Text = "Funcionario que marco el documento"
        '
        'Rdb_Func_Marca_Todos
        '
        Me.Rdb_Func_Marca_Todos.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Rdb_Func_Marca_Todos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Func_Marca_Todos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Func_Marca_Todos.Checked = True
        Me.Rdb_Func_Marca_Todos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Func_Marca_Todos.CheckValue = "Y"
        Me.Rdb_Func_Marca_Todos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Func_Marca_Todos.Location = New System.Drawing.Point(6, 20)
        Me.Rdb_Func_Marca_Todos.Name = "Rdb_Func_Marca_Todos"
        Me.Rdb_Func_Marca_Todos.Size = New System.Drawing.Size(59, 23)
        Me.Rdb_Func_Marca_Todos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Func_Marca_Todos.TabIndex = 25
        Me.Rdb_Func_Marca_Todos.Text = "Todas"
        '
        'Rdb_Func_Marca_Uno
        '
        Me.Rdb_Func_Marca_Uno.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Rdb_Func_Marca_Uno.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Func_Marca_Uno.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Func_Marca_Uno.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Func_Marca_Uno.Location = New System.Drawing.Point(101, 21)
        Me.Rdb_Func_Marca_Uno.Name = "Rdb_Func_Marca_Uno"
        Me.Rdb_Func_Marca_Uno.Size = New System.Drawing.Size(112, 23)
        Me.Rdb_Func_Marca_Uno.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Func_Marca_Uno.TabIndex = 24
        Me.Rdb_Func_Marca_Uno.Text = "Uno en particular"
        '
        'Grupo_Func_Activa
        '
        Me.Grupo_Func_Activa.BackColor = System.Drawing.Color.White
        Me.Grupo_Func_Activa.Controls.Add(Me.Rdb_Func_Activa_Todos)
        Me.Grupo_Func_Activa.Controls.Add(Me.Rdb_Func_Activa_Uno)
        Me.Grupo_Func_Activa.Controls.Add(Me.Cmb_Func_Activa)
        Me.Grupo_Func_Activa.ForeColor = System.Drawing.Color.Black
        Me.Grupo_Func_Activa.Location = New System.Drawing.Point(304, 92)
        Me.Grupo_Func_Activa.Name = "Grupo_Func_Activa"
        Me.Grupo_Func_Activa.Size = New System.Drawing.Size(292, 80)
        Me.Grupo_Func_Activa.TabIndex = 48
        Me.Grupo_Func_Activa.TabStop = False
        Me.Grupo_Func_Activa.Text = "Funcionario que activo el vale"
        '
        'Rdb_Func_Activa_Todos
        '
        Me.Rdb_Func_Activa_Todos.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Rdb_Func_Activa_Todos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Func_Activa_Todos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Func_Activa_Todos.Checked = True
        Me.Rdb_Func_Activa_Todos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Func_Activa_Todos.CheckValue = "Y"
        Me.Rdb_Func_Activa_Todos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Func_Activa_Todos.Location = New System.Drawing.Point(6, 20)
        Me.Rdb_Func_Activa_Todos.Name = "Rdb_Func_Activa_Todos"
        Me.Rdb_Func_Activa_Todos.Size = New System.Drawing.Size(59, 23)
        Me.Rdb_Func_Activa_Todos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Func_Activa_Todos.TabIndex = 25
        Me.Rdb_Func_Activa_Todos.Text = "Todas"
        '
        'Rdb_Func_Activa_Uno
        '
        Me.Rdb_Func_Activa_Uno.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Rdb_Func_Activa_Uno.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Func_Activa_Uno.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Func_Activa_Uno.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Func_Activa_Uno.Location = New System.Drawing.Point(101, 21)
        Me.Rdb_Func_Activa_Uno.Name = "Rdb_Func_Activa_Uno"
        Me.Rdb_Func_Activa_Uno.Size = New System.Drawing.Size(112, 23)
        Me.Rdb_Func_Activa_Uno.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Func_Activa_Uno.TabIndex = 24
        Me.Rdb_Func_Activa_Uno.Text = "Uno en particular"
        '
        'Cmb_Func_Activa
        '
        Me.Cmb_Func_Activa.DisplayMember = "Text"
        Me.Cmb_Func_Activa.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Func_Activa.FocusHighlightEnabled = True
        Me.Cmb_Func_Activa.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Func_Activa.FormattingEnabled = True
        Me.Cmb_Func_Activa.ItemHeight = 16
        Me.Cmb_Func_Activa.Location = New System.Drawing.Point(6, 50)
        Me.Cmb_Func_Activa.Name = "Cmb_Func_Activa"
        Me.Cmb_Func_Activa.Size = New System.Drawing.Size(279, 22)
        Me.Cmb_Func_Activa.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Func_Activa.TabIndex = 31
        '
        'Grupo_NroVale
        '
        Me.Grupo_NroVale.BackColor = System.Drawing.Color.White
        Me.Grupo_NroVale.Controls.Add(Me.Rdb_Vale_todos)
        Me.Grupo_NroVale.Controls.Add(Me.Rdb_Vale_Uno)
        Me.Grupo_NroVale.Controls.Add(Me.LblNroVale)
        Me.Grupo_NroVale.Controls.Add(Me.Txt_NroVale)
        Me.Grupo_NroVale.ForeColor = System.Drawing.Color.Black
        Me.Grupo_NroVale.Location = New System.Drawing.Point(8, 6)
        Me.Grupo_NroVale.Name = "Grupo_NroVale"
        Me.Grupo_NroVale.Size = New System.Drawing.Size(290, 80)
        Me.Grupo_NroVale.TabIndex = 49
        Me.Grupo_NroVale.TabStop = False
        Me.Grupo_NroVale.Text = "Número de vale"
        '
        'Rdb_Vale_todos
        '
        Me.Rdb_Vale_todos.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Rdb_Vale_todos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Vale_todos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Vale_todos.Checked = True
        Me.Rdb_Vale_todos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Vale_todos.CheckValue = "Y"
        Me.Rdb_Vale_todos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Vale_todos.Location = New System.Drawing.Point(6, 20)
        Me.Rdb_Vale_todos.Name = "Rdb_Vale_todos"
        Me.Rdb_Vale_todos.Size = New System.Drawing.Size(59, 23)
        Me.Rdb_Vale_todos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Vale_todos.TabIndex = 25
        Me.Rdb_Vale_todos.Text = "Todas"
        '
        'Rdb_Vale_Uno
        '
        Me.Rdb_Vale_Uno.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Rdb_Vale_Uno.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Vale_Uno.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Vale_Uno.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Vale_Uno.Location = New System.Drawing.Point(6, 47)
        Me.Rdb_Vale_Uno.Name = "Rdb_Vale_Uno"
        Me.Rdb_Vale_Uno.Size = New System.Drawing.Size(118, 23)
        Me.Rdb_Vale_Uno.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Vale_Uno.TabIndex = 24
        Me.Rdb_Vale_Uno.Text = "Uno en particular"
        '
        'LblNroVale
        '
        Me.LblNroVale.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LblNroVale.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblNroVale.ForeColor = System.Drawing.Color.Black
        Me.LblNroVale.Location = New System.Drawing.Point(130, 49)
        Me.LblNroVale.Name = "LblNroVale"
        Me.LblNroVale.Size = New System.Drawing.Size(45, 23)
        Me.LblNroVale.TabIndex = 34
        Me.LblNroVale.Text = "N° Vale"
        '
        'Grupo_Documentos
        '
        Me.Grupo_Documentos.BackColor = System.Drawing.Color.White
        Me.Grupo_Documentos.Controls.Add(Me.CmbTipoDoc)
        Me.Grupo_Documentos.Controls.Add(Me.Rdb_Tipo_doc_todos)
        Me.Grupo_Documentos.Controls.Add(Me.Rdb_Tipo_doc_Uno)
        Me.Grupo_Documentos.Controls.Add(Me.Txt_Documento)
        Me.Grupo_Documentos.Controls.Add(Me.Btn_Tipo_doc_Buscasr)
        Me.Grupo_Documentos.ForeColor = System.Drawing.Color.Black
        Me.Grupo_Documentos.Location = New System.Drawing.Point(304, 6)
        Me.Grupo_Documentos.Name = "Grupo_Documentos"
        Me.Grupo_Documentos.Size = New System.Drawing.Size(290, 80)
        Me.Grupo_Documentos.TabIndex = 50
        Me.Grupo_Documentos.TabStop = False
        Me.Grupo_Documentos.Text = "Tipo de documento (boletas/facturas)"
        '
        'CmbTipoDoc
        '
        Me.CmbTipoDoc.DisplayMember = "Text"
        Me.CmbTipoDoc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbTipoDoc.ForeColor = System.Drawing.Color.Black
        Me.CmbTipoDoc.FormattingEnabled = True
        Me.CmbTipoDoc.ItemHeight = 16
        Me.CmbTipoDoc.Location = New System.Drawing.Point(11, 50)
        Me.CmbTipoDoc.Name = "CmbTipoDoc"
        Me.CmbTipoDoc.Size = New System.Drawing.Size(119, 22)
        Me.CmbTipoDoc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CmbTipoDoc.TabIndex = 48
        Me.CmbTipoDoc.Text = "BOLETA"
        '
        'Rdb_Tipo_doc_todos
        '
        Me.Rdb_Tipo_doc_todos.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Rdb_Tipo_doc_todos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Tipo_doc_todos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Tipo_doc_todos.Checked = True
        Me.Rdb_Tipo_doc_todos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Tipo_doc_todos.CheckValue = "Y"
        Me.Rdb_Tipo_doc_todos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Tipo_doc_todos.Location = New System.Drawing.Point(6, 20)
        Me.Rdb_Tipo_doc_todos.Name = "Rdb_Tipo_doc_todos"
        Me.Rdb_Tipo_doc_todos.Size = New System.Drawing.Size(105, 23)
        Me.Rdb_Tipo_doc_todos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Tipo_doc_todos.TabIndex = 25
        Me.Rdb_Tipo_doc_todos.Text = "Boletas y Facturas"
        '
        'Rdb_Tipo_doc_Uno
        '
        Me.Rdb_Tipo_doc_Uno.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Rdb_Tipo_doc_Uno.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Tipo_doc_Uno.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Tipo_doc_Uno.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Tipo_doc_Uno.Location = New System.Drawing.Point(141, 20)
        Me.Rdb_Tipo_doc_Uno.Name = "Rdb_Tipo_doc_Uno"
        Me.Rdb_Tipo_doc_Uno.Size = New System.Drawing.Size(109, 23)
        Me.Rdb_Tipo_doc_Uno.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Tipo_doc_Uno.TabIndex = 24
        Me.Rdb_Tipo_doc_Uno.Text = "Uno en particular"
        '
        'Grupo_Estado
        '
        Me.Grupo_Estado.BackColor = System.Drawing.Color.Transparent
        Me.Grupo_Estado.Controls.Add(Me.ItemPanel2)
        Me.Grupo_Estado.ForeColor = System.Drawing.Color.Black
        Me.Grupo_Estado.Location = New System.Drawing.Point(8, 343)
        Me.Grupo_Estado.Name = "Grupo_Estado"
        Me.Grupo_Estado.Size = New System.Drawing.Size(159, 129)
        Me.Grupo_Estado.TabIndex = 51
        Me.Grupo_Estado.TabStop = False
        Me.Grupo_Estado.Text = "Estados"
        '
        'ItemPanel2
        '
        '
        '
        '
        Me.ItemPanel2.BackgroundStyle.BackColor = System.Drawing.Color.White
        Me.ItemPanel2.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ItemPanel2.BackgroundStyle.BorderBottomWidth = 1
        Me.ItemPanel2.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ItemPanel2.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ItemPanel2.BackgroundStyle.BorderLeftWidth = 1
        Me.ItemPanel2.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ItemPanel2.BackgroundStyle.BorderRightWidth = 1
        Me.ItemPanel2.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ItemPanel2.BackgroundStyle.BorderTopWidth = 1
        Me.ItemPanel2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemPanel2.ContainerControlProcessDialogKey = True
        Me.ItemPanel2.DragDropSupport = True
        Me.ItemPanel2.ForeColor = System.Drawing.Color.Black
        Me.ItemPanel2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Chk_VerMarcadas, Me.Chk_VerActivas, Me.Chk_VerCerradas, Me.Chk_VerNulas})
        Me.ItemPanel2.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemPanel2.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.ItemPanel2.Location = New System.Drawing.Point(6, 21)
        Me.ItemPanel2.Name = "ItemPanel2"
        Me.ItemPanel2.Size = New System.Drawing.Size(148, 90)
        Me.ItemPanel2.TabIndex = 1
        Me.ItemPanel2.Text = "ItemPanel2"
        '
        'Chk_VerMarcadas
        '
        Me.Chk_VerMarcadas.Name = "Chk_VerMarcadas"
        Me.Chk_VerMarcadas.Text = "MARCARDAS"
        '
        'Chk_VerActivas
        '
        Me.Chk_VerActivas.Name = "Chk_VerActivas"
        Me.Chk_VerActivas.Text = "ACTIVAS"
        '
        'Chk_VerCerradas
        '
        Me.Chk_VerCerradas.Name = "Chk_VerCerradas"
        Me.Chk_VerCerradas.Text = "CERRADAS"
        '
        'Chk_VerNulas
        '
        Me.Chk_VerNulas.Name = "Chk_VerNulas"
        Me.Chk_VerNulas.Text = "NULAS"
        '
        'Frm_Vales_Listado_Espera_Filtro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(608, 524)
        Me.ControlBox = False
        Me.Controls.Add(Me.Grupo_Estado)
        Me.Controls.Add(Me.Grupo_Documentos)
        Me.Controls.Add(Me.Grupo_NroVale)
        Me.Controls.Add(Me.Grupo_Func_Activa)
        Me.Controls.Add(Me.Grupo_Func_Marca)
        Me.Controls.Add(Me.Grupo_Cliente)
        Me.Controls.Add(Me.Grupo_Fecha)
        Me.Controls.Add(Me.Grupo_Productos)
        Me.Controls.Add(Me.Grupo_TipoEntrega)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_Vales_Listado_Espera_Filtro"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Filtrar, buscar vales de entrega - despacho"
        Me.Grupo_Productos.ResumeLayout(False)
        Me.Grupo_Productos.PerformLayout()
        Me.Grupo_TipoEntrega.ResumeLayout(False)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo_Fecha.ResumeLayout(False)
        Me.Grupo_Cliente.ResumeLayout(False)
        Me.Grupo_Func_Marca.ResumeLayout(False)
        Me.Grupo_Func_Activa.ResumeLayout(False)
        Me.Grupo_NroVale.ResumeLayout(False)
        Me.Grupo_Documentos.ResumeLayout(False)
        Me.Grupo_Estado.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Grupo_Productos As System.Windows.Forms.GroupBox
    Friend WithEvents TxtProductoFiltro As System.Windows.Forms.TextBox
    Friend WithEvents ItemPanel1 As DevComponents.DotNetBar.ItemPanel
    Public WithEvents Rdb_Retira_Cliente As DevComponents.DotNetBar.CheckBoxItem
    Public WithEvents Rdb_Despacho_Domicilio As DevComponents.DotNetBar.CheckBoxItem
    Public WithEvents Rdb_Ambos As DevComponents.DotNetBar.CheckBoxItem
    Friend WithEvents Txt_Documento As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_NroVale As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnFiltrar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnLimpiar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Salir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Cmb_Func_Marca As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Grupo_Fecha As System.Windows.Forms.GroupBox
    Public WithEvents Rdb_Fecha_Emision_Todas As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Rdb_Fecha_Emision_Desde_Hasta As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents DtpFecha_desde As System.Windows.Forms.DateTimePicker
    Public WithEvents DtpFecha_hasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblFecha1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LblFecha2 As DevComponents.DotNetBar.LabelX
    Public WithEvents Grupo_Cliente As System.Windows.Forms.GroupBox
    Public WithEvents Btn_Entidad_Una As DevComponents.DotNetBar.ButtonX
    Public WithEvents Rdb_Cliente_Uno As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Txt_Entidad As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Rdb_Cliente_Todas As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Chk_Nulas As DevComponents.DotNetBar.CheckBoxItem
    Public WithEvents Rdb_Producto_Uno As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Rdb_Producto_Todos As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Btn_Producto As DevComponents.DotNetBar.ButtonX
    Public WithEvents Btn_Tipo_doc_Buscasr As DevComponents.DotNetBar.ButtonX
    Public WithEvents Rdb_Func_Marca_Todos As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Rdb_Func_Marca_Uno As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Grupo_Func_Marca As System.Windows.Forms.GroupBox
    Friend WithEvents Grupo_Func_Activa As System.Windows.Forms.GroupBox
    Public WithEvents Rdb_Func_Activa_Todos As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Rdb_Func_Activa_Uno As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Cmb_Func_Activa As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Grupo_NroVale As System.Windows.Forms.GroupBox
    Public WithEvents Rdb_Vale_todos As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Rdb_Vale_Uno As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Grupo_Documentos As System.Windows.Forms.GroupBox
    Public WithEvents Rdb_Tipo_doc_todos As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Rdb_Tipo_doc_Uno As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents CmbTipoDoc As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LblNroVale As DevComponents.DotNetBar.LabelX
    Friend WithEvents ItemPanel2 As DevComponents.DotNetBar.ItemPanel
    Public WithEvents Chk_VerMarcadas As DevComponents.DotNetBar.CheckBoxItem
    Public WithEvents Chk_VerActivas As DevComponents.DotNetBar.CheckBoxItem
    Public WithEvents Chk_VerCerradas As DevComponents.DotNetBar.CheckBoxItem
    Public WithEvents Grupo_TipoEntrega As System.Windows.Forms.GroupBox
    Public WithEvents Grupo_Estado As System.Windows.Forms.GroupBox
    Public WithEvents Chk_VerNulas As DevComponents.DotNetBar.CheckBoxItem
    Private WithEvents Chk_EnprocesoOc As DevComponents.DotNetBar.CheckBoxItem
End Class
