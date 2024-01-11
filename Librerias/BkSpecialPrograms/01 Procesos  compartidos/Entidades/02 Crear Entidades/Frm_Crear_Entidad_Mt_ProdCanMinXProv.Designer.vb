<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Crear_Entidad_Mt_ProdCanMinXProv
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Crear_Entidad_Mt_ProdCanMinXProv))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_AgregarProductos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_ExportarExcel = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_QuitarConValorCero = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Menu_Contextual = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_01 = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_EditarMotivo = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_QuitarProducto = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_02 = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_SeleccionarProductos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_TraerProductosFCCGRCOCC = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_TraerProductosTabcodal = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Txt_Buscador = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Rdb_VerProd_Todos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_VerProd_ConMultiplos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_VerProd_SinMultiplos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Menu_Contextual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel3.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar, Me.Btn_AgregarProductos, Me.Btn_ExportarExcel, Me.Btn_QuitarConValorCero})
        Me.Bar1.Location = New System.Drawing.Point(0, 510)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(654, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 56
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
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
        'Btn_AgregarProductos
        '
        Me.Btn_AgregarProductos.ForeColor = System.Drawing.Color.Black
        Me.Btn_AgregarProductos.Image = CType(resources.GetObject("Btn_AgregarProductos.Image"), System.Drawing.Image)
        Me.Btn_AgregarProductos.ImageAlt = CType(resources.GetObject("Btn_AgregarProductos.ImageAlt"), System.Drawing.Image)
        Me.Btn_AgregarProductos.Name = "Btn_AgregarProductos"
        Me.Btn_AgregarProductos.Text = "Agregar producto"
        '
        'Btn_ExportarExcel
        '
        Me.Btn_ExportarExcel.ForeColor = System.Drawing.Color.Black
        Me.Btn_ExportarExcel.Image = CType(resources.GetObject("Btn_ExportarExcel.Image"), System.Drawing.Image)
        Me.Btn_ExportarExcel.ImageAlt = CType(resources.GetObject("Btn_ExportarExcel.ImageAlt"), System.Drawing.Image)
        Me.Btn_ExportarExcel.Name = "Btn_ExportarExcel"
        Me.Btn_ExportarExcel.Text = "Exportar a Excel"
        '
        'Btn_QuitarConValorCero
        '
        Me.Btn_QuitarConValorCero.ForeColor = System.Drawing.Color.Black
        Me.Btn_QuitarConValorCero.Image = CType(resources.GetObject("Btn_QuitarConValorCero.Image"), System.Drawing.Image)
        Me.Btn_QuitarConValorCero.ImageAlt = CType(resources.GetObject("Btn_QuitarConValorCero.ImageAlt"), System.Drawing.Image)
        Me.Btn_QuitarConValorCero.Name = "Btn_QuitarConValorCero"
        Me.Btn_QuitarConValorCero.Text = "Quitar productos con valor cero"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Menu_Contextual)
        Me.GroupPanel1.Controls.Add(Me.Grilla)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(7, 82)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(640, 377)
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
        Me.GroupPanel1.TabIndex = 55
        Me.GroupPanel1.Text = "Detalle de productos"
        '
        'Menu_Contextual
        '
        Me.Menu_Contextual.AntiAlias = True
        Me.Menu_Contextual.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Menu_Contextual.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_01, Me.Menu_Contextual_02})
        Me.Menu_Contextual.Location = New System.Drawing.Point(26, 31)
        Me.Menu_Contextual.Name = "Menu_Contextual"
        Me.Menu_Contextual.Size = New System.Drawing.Size(329, 25)
        Me.Menu_Contextual.Stretch = True
        Me.Menu_Contextual.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Menu_Contextual.TabIndex = 55
        Me.Menu_Contextual.TabStop = False
        Me.Menu_Contextual.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_01
        '
        Me.Menu_Contextual_01.AutoExpandOnClick = True
        Me.Menu_Contextual_01.Name = "Menu_Contextual_01"
        Me.Menu_Contextual_01.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_EditarMotivo, Me.Btn_QuitarProducto})
        Me.Menu_Contextual_01.Text = "Opciones"
        '
        'Btn_EditarMotivo
        '
        Me.Btn_EditarMotivo.Image = CType(resources.GetObject("Btn_EditarMotivo.Image"), System.Drawing.Image)
        Me.Btn_EditarMotivo.ImageAlt = CType(resources.GetObject("Btn_EditarMotivo.ImageAlt"), System.Drawing.Image)
        Me.Btn_EditarMotivo.Name = "Btn_EditarMotivo"
        Me.Btn_EditarMotivo.Text = "Editar motivo de bloqueo"
        '
        'Btn_QuitarProducto
        '
        Me.Btn_QuitarProducto.Image = CType(resources.GetObject("Btn_QuitarProducto.Image"), System.Drawing.Image)
        Me.Btn_QuitarProducto.ImageAlt = CType(resources.GetObject("Btn_QuitarProducto.ImageAlt"), System.Drawing.Image)
        Me.Btn_QuitarProducto.Name = "Btn_QuitarProducto"
        Me.Btn_QuitarProducto.Text = "Quitar producto de la lista"
        '
        'Menu_Contextual_02
        '
        Me.Menu_Contextual_02.AutoExpandOnClick = True
        Me.Menu_Contextual_02.Name = "Menu_Contextual_02"
        Me.Menu_Contextual_02.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Mnu_SeleccionarProductos, Me.Btn_TraerProductosFCCGRCOCC, Me.Btn_TraerProductosTabcodal})
        Me.Menu_Contextual_02.Text = "Opciones"
        '
        'Btn_Mnu_SeleccionarProductos
        '
        Me.Btn_Mnu_SeleccionarProductos.Image = CType(resources.GetObject("Btn_Mnu_SeleccionarProductos.Image"), System.Drawing.Image)
        Me.Btn_Mnu_SeleccionarProductos.ImageAlt = CType(resources.GetObject("Btn_Mnu_SeleccionarProductos.ImageAlt"), System.Drawing.Image)
        Me.Btn_Mnu_SeleccionarProductos.Name = "Btn_Mnu_SeleccionarProductos"
        Me.Btn_Mnu_SeleccionarProductos.Text = "Seleccionar productos"
        '
        'Btn_TraerProductosFCCGRCOCC
        '
        Me.Btn_TraerProductosFCCGRCOCC.Image = CType(resources.GetObject("Btn_TraerProductosFCCGRCOCC.Image"), System.Drawing.Image)
        Me.Btn_TraerProductosFCCGRCOCC.ImageAlt = CType(resources.GetObject("Btn_TraerProductosFCCGRCOCC.ImageAlt"), System.Drawing.Image)
        Me.Btn_TraerProductosFCCGRCOCC.Name = "Btn_TraerProductosFCCGRCOCC"
        Me.Btn_TraerProductosFCCGRCOCC.Text = "Traer productos comprados al proveedor (desde GRC/FCC/OCC)"
        '
        'Btn_TraerProductosTabcodal
        '
        Me.Btn_TraerProductosTabcodal.Image = CType(resources.GetObject("Btn_TraerProductosTabcodal.Image"), System.Drawing.Image)
        Me.Btn_TraerProductosTabcodal.ImageAlt = CType(resources.GetObject("Btn_TraerProductosTabcodal.ImageAlt"), System.Drawing.Image)
        Me.Btn_TraerProductosTabcodal.Name = "Btn_TraerProductosTabcodal"
        Me.Btn_TraerProductosTabcodal.Text = "Traer productos desde el maestro de códigos alternativos del proveedor"
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
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla.Size = New System.Drawing.Size(634, 354)
        Me.Grilla.StandardTab = True
        Me.Grilla.TabIndex = 54
        '
        'GroupPanel3
        '
        Me.GroupPanel3.BackColor = System.Drawing.Color.White
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.Txt_Buscador)
        Me.GroupPanel3.Controls.Add(Me.LabelX7)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Location = New System.Drawing.Point(7, 6)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(640, 70)
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
        Me.GroupPanel3.TabIndex = 117
        Me.GroupPanel3.Text = "Buscador"
        '
        'Txt_Buscador
        '
        Me.Txt_Buscador.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Buscador.Border.Class = "TextBoxBorder"
        Me.Txt_Buscador.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Buscador.ButtonCustom.Image = CType(resources.GetObject("Txt_Buscador.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Buscador.ButtonCustom2.Image = CType(resources.GetObject("Txt_Buscador.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Buscador.ButtonCustom2.Visible = True
        Me.Txt_Buscador.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Buscador.ForeColor = System.Drawing.Color.Black
        Me.Txt_Buscador.Location = New System.Drawing.Point(3, 22)
        Me.Txt_Buscador.Name = "Txt_Buscador"
        Me.Txt_Buscador.PreventEnterBeep = True
        Me.Txt_Buscador.Size = New System.Drawing.Size(631, 22)
        Me.Txt_Buscador.TabIndex = 0
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.ForeColor = System.Drawing.Color.Black
        Me.LabelX7.Location = New System.Drawing.Point(3, 0)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(404, 23)
        Me.LabelX7.TabIndex = 99
        Me.LabelX7.Text = "Ingrese algo de la descripción o código"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.24723!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.63838!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.11439!))
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_VerProd_Todos, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_VerProd_ConMultiplos, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_VerProd_SinMultiplos, 2, 0)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(84, 465)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(272, 28)
        Me.TableLayoutPanel1.TabIndex = 140
        '
        'Rdb_VerProd_Todos
        '
        Me.Rdb_VerProd_Todos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_VerProd_Todos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_VerProd_Todos.CheckBoxImageChecked = CType(resources.GetObject("Rdb_VerProd_Todos.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_VerProd_Todos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_VerProd_Todos.Checked = True
        Me.Rdb_VerProd_Todos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_VerProd_Todos.CheckValue = "Y"
        Me.Rdb_VerProd_Todos.FocusCuesEnabled = False
        Me.Rdb_VerProd_Todos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_VerProd_Todos.Location = New System.Drawing.Point(3, 3)
        Me.Rdb_VerProd_Todos.Name = "Rdb_VerProd_Todos"
        Me.Rdb_VerProd_Todos.Size = New System.Drawing.Size(57, 19)
        Me.Rdb_VerProd_Todos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_VerProd_Todos.TabIndex = 134
        Me.Rdb_VerProd_Todos.TabStop = False
        Me.Rdb_VerProd_Todos.Text = "Todos"
        '
        'Rdb_VerProd_ConMultiplos
        '
        Me.Rdb_VerProd_ConMultiplos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_VerProd_ConMultiplos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_VerProd_ConMultiplos.CheckBoxImageChecked = CType(resources.GetObject("Rdb_VerProd_ConMultiplos.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_VerProd_ConMultiplos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_VerProd_ConMultiplos.FocusCuesEnabled = False
        Me.Rdb_VerProd_ConMultiplos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_VerProd_ConMultiplos.Location = New System.Drawing.Point(66, 3)
        Me.Rdb_VerProd_ConMultiplos.Name = "Rdb_VerProd_ConMultiplos"
        Me.Rdb_VerProd_ConMultiplos.Size = New System.Drawing.Size(94, 19)
        Me.Rdb_VerProd_ConMultiplos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_VerProd_ConMultiplos.TabIndex = 135
        Me.Rdb_VerProd_ConMultiplos.TabStop = False
        Me.Rdb_VerProd_ConMultiplos.Text = "Con multiplos"
        '
        'Rdb_VerProd_SinMultiplos
        '
        Me.Rdb_VerProd_SinMultiplos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_VerProd_SinMultiplos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_VerProd_SinMultiplos.CheckBoxImageChecked = CType(resources.GetObject("Rdb_VerProd_SinMultiplos.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_VerProd_SinMultiplos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_VerProd_SinMultiplos.FocusCuesEnabled = False
        Me.Rdb_VerProd_SinMultiplos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_VerProd_SinMultiplos.Location = New System.Drawing.Point(168, 3)
        Me.Rdb_VerProd_SinMultiplos.Name = "Rdb_VerProd_SinMultiplos"
        Me.Rdb_VerProd_SinMultiplos.Size = New System.Drawing.Size(101, 19)
        Me.Rdb_VerProd_SinMultiplos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_VerProd_SinMultiplos.TabIndex = 136
        Me.Rdb_VerProd_SinMultiplos.TabStop = False
        Me.Rdb_VerProd_SinMultiplos.Text = "Sin multiplos"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(7, 465)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(102, 23)
        Me.LabelX2.TabIndex = 139
        Me.LabelX2.Text = "Ver productos:"
        '
        'Frm_Crear_Entidad_Mt_ProdCanMinXProv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(654, 551)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.GroupPanel3)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.GroupPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Crear_Entidad_Mt_ProdCanMinXProv"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MANTENCION DE PRODUCTOS CON MULTIPLOS A COMPRAR POR PROVEEDORES"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.Menu_Contextual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel3.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_AgregarProductos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_ExportarExcel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Menu_Contextual As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_01 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_EditarMotivo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_QuitarProducto As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Txt_Buscador As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Menu_Contextual_02 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_TraerProductosFCCGRCOCC As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_TraerProductosTabcodal As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_SeleccionarProductos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_QuitarConValorCero As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Rdb_VerProd_Todos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_VerProd_ConMultiplos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_VerProd_SinMultiplos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
End Class
