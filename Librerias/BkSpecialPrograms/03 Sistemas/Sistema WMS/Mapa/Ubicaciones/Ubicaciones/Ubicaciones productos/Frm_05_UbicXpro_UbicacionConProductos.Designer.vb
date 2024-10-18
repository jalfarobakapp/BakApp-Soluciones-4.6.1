<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_05_UbicXpro_UbicacionConProductos
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_05_UbicXpro_UbicacionConProductos))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.LblBodega = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.LblSucursal = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LblEmpresa = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Buscar_Producto = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Seleccion_Multiple = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Imprimir_Etiquetas = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnExportarExcel = New DevComponents.DotNetBar.ButtonItem()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_Ubicacion = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.Mnu_Btn_Ver_Informacion_de_producto = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Ver_Ubicaciones_Del_Producto = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Eliminar_Ubicacion = New DevComponents.DotNetBar.ButtonItem()
        Me.Rdb_Ud1 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Ud2 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TxtUbicacion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Lbl_InfoFechaIngUbic = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Seleccion_MultipleQuitar = New DevComponents.DotNetBar.ButtonItem()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.LblBodega, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX6, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.LblSucursal, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX4, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LblEmpresa, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX2, 0, 0)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(742, 65)
        Me.TableLayoutPanel1.TabIndex = 25
        '
        'LblBodega
        '
        Me.LblBodega.AutoSize = True
        '
        '
        '
        Me.LblBodega.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblBodega.ForeColor = System.Drawing.Color.Black
        Me.LblBodega.Location = New System.Drawing.Point(88, 46)
        Me.LblBodega.Name = "LblBodega"
        Me.LblBodega.Size = New System.Drawing.Size(41, 17)
        Me.LblBodega.TabIndex = 5
        Me.LblBodega.Text = "LabelX7"
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(5, 46)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(75, 14)
        Me.LabelX6.TabIndex = 4
        Me.LabelX6.Text = "Bodega"
        '
        'LblSucursal
        '
        Me.LblSucursal.AutoSize = True
        '
        '
        '
        Me.LblSucursal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblSucursal.ForeColor = System.Drawing.Color.Black
        Me.LblSucursal.Location = New System.Drawing.Point(88, 24)
        Me.LblSucursal.Name = "LblSucursal"
        Me.LblSucursal.Size = New System.Drawing.Size(41, 17)
        Me.LblSucursal.TabIndex = 3
        Me.LblSucursal.Text = "LabelX5"
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(5, 24)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(75, 14)
        Me.LabelX4.TabIndex = 2
        Me.LabelX4.Text = "Sucursal"
        '
        'LblEmpresa
        '
        Me.LblEmpresa.AutoSize = True
        '
        '
        '
        Me.LblEmpresa.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblEmpresa.ForeColor = System.Drawing.Color.Black
        Me.LblEmpresa.Location = New System.Drawing.Point(88, 5)
        Me.LblEmpresa.Name = "LblEmpresa"
        Me.LblEmpresa.Size = New System.Drawing.Size(41, 17)
        Me.LblEmpresa.TabIndex = 1
        Me.LblEmpresa.Text = "LabelX3"
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(5, 5)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 11)
        Me.LabelX2.TabIndex = 0
        Me.LabelX2.Text = "Empresa"
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.AllowUserToDeleteRows = False
        Me.Grilla.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
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
        Me.Grilla.Size = New System.Drawing.Size(736, 239)
        Me.Grilla.TabIndex = 10
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Buscar_Producto, Me.Btn_Seleccion_Multiple, Me.Btn_Seleccion_MultipleQuitar, Me.Btn_Imprimir_Etiquetas, Me.BtnExportarExcel})
        Me.Bar1.Location = New System.Drawing.Point(0, 427)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(760, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 41
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Buscar_Producto
        '
        Me.Btn_Buscar_Producto.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Buscar_Producto.ForeColor = System.Drawing.Color.Black
        Me.Btn_Buscar_Producto.Image = CType(resources.GetObject("Btn_Buscar_Producto.Image"), System.Drawing.Image)
        Me.Btn_Buscar_Producto.ImageAlt = CType(resources.GetObject("Btn_Buscar_Producto.ImageAlt"), System.Drawing.Image)
        Me.Btn_Buscar_Producto.Name = "Btn_Buscar_Producto"
        Me.Btn_Buscar_Producto.Tooltip = "Agregar un productos (F2)"
        '
        'Btn_Seleccion_Multiple
        '
        Me.Btn_Seleccion_Multiple.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Seleccion_Multiple.ForeColor = System.Drawing.Color.Black
        Me.Btn_Seleccion_Multiple.Image = CType(resources.GetObject("Btn_Seleccion_Multiple.Image"), System.Drawing.Image)
        Me.Btn_Seleccion_Multiple.ImageAlt = CType(resources.GetObject("Btn_Seleccion_Multiple.ImageAlt"), System.Drawing.Image)
        Me.Btn_Seleccion_Multiple.Name = "Btn_Seleccion_Multiple"
        Me.Btn_Seleccion_Multiple.Tooltip = "Agregar productos con selección múltiple (F3)"
        '
        'Btn_Imprimir_Etiquetas
        '
        Me.Btn_Imprimir_Etiquetas.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Imprimir_Etiquetas.ForeColor = System.Drawing.Color.Black
        Me.Btn_Imprimir_Etiquetas.Image = CType(resources.GetObject("Btn_Imprimir_Etiquetas.Image"), System.Drawing.Image)
        Me.Btn_Imprimir_Etiquetas.ImageAlt = CType(resources.GetObject("Btn_Imprimir_Etiquetas.ImageAlt"), System.Drawing.Image)
        Me.Btn_Imprimir_Etiquetas.Name = "Btn_Imprimir_Etiquetas"
        '
        'BtnExportarExcel
        '
        Me.BtnExportarExcel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnExportarExcel.ForeColor = System.Drawing.Color.Black
        Me.BtnExportarExcel.Image = CType(resources.GetObject("BtnExportarExcel.Image"), System.Drawing.Image)
        Me.BtnExportarExcel.ImageAlt = CType(resources.GetObject("BtnExportarExcel.ImageAlt"), System.Drawing.Image)
        Me.BtnExportarExcel.Name = "BtnExportarExcel"
        Me.BtnExportarExcel.Tooltip = "Exportar a Excel"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(12, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 43
        Me.Label3.Text = "Ubicación"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.ContextMenuBar1)
        Me.GroupPanel1.Controls.Add(Me.Grilla)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 127)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(742, 262)
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
        Me.GroupPanel1.TabIndex = 44
        Me.GroupPanel1.Text = "Detalle"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_Ubicacion})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(131, 39)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(222, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 50
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_Ubicacion
        '
        Me.Menu_Contextual_Ubicacion.AutoExpandOnClick = True
        Me.Menu_Contextual_Ubicacion.Name = "Menu_Contextual_Ubicacion"
        Me.Menu_Contextual_Ubicacion.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1, Me.Mnu_Btn_Ver_Informacion_de_producto, Me.Btn_Mnu_Ver_Ubicaciones_Del_Producto, Me.Btn_Mnu_Eliminar_Ubicacion})
        Me.Menu_Contextual_Ubicacion.Text = "Opciones Ubicacion"
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
        Me.LabelItem1.Text = "Opciones de la ubicación"
        '
        'Mnu_Btn_Ver_Informacion_de_producto
        '
        Me.Mnu_Btn_Ver_Informacion_de_producto.Image = CType(resources.GetObject("Mnu_Btn_Ver_Informacion_de_producto.Image"), System.Drawing.Image)
        Me.Mnu_Btn_Ver_Informacion_de_producto.ImageAlt = CType(resources.GetObject("Mnu_Btn_Ver_Informacion_de_producto.ImageAlt"), System.Drawing.Image)
        Me.Mnu_Btn_Ver_Informacion_de_producto.Name = "Mnu_Btn_Ver_Informacion_de_producto"
        Me.Mnu_Btn_Ver_Informacion_de_producto.Text = "Ver información adicional del producto"
        '
        'Btn_Mnu_Ver_Ubicaciones_Del_Producto
        '
        Me.Btn_Mnu_Ver_Ubicaciones_Del_Producto.Image = CType(resources.GetObject("Btn_Mnu_Ver_Ubicaciones_Del_Producto.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Ver_Ubicaciones_Del_Producto.Name = "Btn_Mnu_Ver_Ubicaciones_Del_Producto"
        Me.Btn_Mnu_Ver_Ubicaciones_Del_Producto.Text = "Ver ubicaciones del producto"
        '
        'Btn_Mnu_Eliminar_Ubicacion
        '
        Me.Btn_Mnu_Eliminar_Ubicacion.ForeColor = System.Drawing.Color.Red
        Me.Btn_Mnu_Eliminar_Ubicacion.Image = CType(resources.GetObject("Btn_Mnu_Eliminar_Ubicacion.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Eliminar_Ubicacion.Name = "Btn_Mnu_Eliminar_Ubicacion"
        Me.Btn_Mnu_Eliminar_Ubicacion.Text = "Quitar producto de esta ubicación"
        '
        'Rdb_Ud1
        '
        Me.Rdb_Ud1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Rdb_Ud1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Ud1.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Ud1.Checked = True
        Me.Rdb_Ud1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Ud1.CheckValue = "Y"
        Me.Rdb_Ud1.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Ud1.Location = New System.Drawing.Point(12, 395)
        Me.Rdb_Ud1.Name = "Rdb_Ud1"
        Me.Rdb_Ud1.Size = New System.Drawing.Size(69, 23)
        Me.Rdb_Ud1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Ud1.TabIndex = 45
        Me.Rdb_Ud1.Text = "Unidad 1"
        '
        'Rdb_Ud2
        '
        Me.Rdb_Ud2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Rdb_Ud2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Ud2.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Ud2.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Ud2.Location = New System.Drawing.Point(87, 395)
        Me.Rdb_Ud2.Name = "Rdb_Ud2"
        Me.Rdb_Ud2.Size = New System.Drawing.Size(72, 23)
        Me.Rdb_Ud2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Ud2.TabIndex = 46
        Me.Rdb_Ud2.Text = "Unidad 2"
        '
        'TxtUbicacion
        '
        Me.TxtUbicacion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtUbicacion.Border.Class = "TextBoxBorder"
        Me.TxtUbicacion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtUbicacion.DisabledBackColor = System.Drawing.Color.White
        Me.TxtUbicacion.ForeColor = System.Drawing.Color.Black
        Me.TxtUbicacion.Location = New System.Drawing.Point(12, 99)
        Me.TxtUbicacion.Name = "TxtUbicacion"
        Me.TxtUbicacion.PreventEnterBeep = True
        Me.TxtUbicacion.Size = New System.Drawing.Size(742, 22)
        Me.TxtUbicacion.TabIndex = 47
        '
        'Lbl_InfoFechaIngUbic
        '
        Me.Lbl_InfoFechaIngUbic.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_InfoFechaIngUbic.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_InfoFechaIngUbic.ForeColor = System.Drawing.Color.Black
        Me.Lbl_InfoFechaIngUbic.Image = CType(resources.GetObject("Lbl_InfoFechaIngUbic.Image"), System.Drawing.Image)
        Me.Lbl_InfoFechaIngUbic.ImageTextSpacing = 5
        Me.Lbl_InfoFechaIngUbic.Location = New System.Drawing.Point(165, 395)
        Me.Lbl_InfoFechaIngUbic.Name = "Lbl_InfoFechaIngUbic"
        Me.Lbl_InfoFechaIngUbic.Size = New System.Drawing.Size(589, 23)
        Me.Lbl_InfoFechaIngUbic.TabIndex = 48
        Me.Lbl_InfoFechaIngUbic.Text = "Fecha de ingreso en la ubicación: 05-10-2024"
        '
        'Btn_Seleccion_MultipleQuitar
        '
        Me.Btn_Seleccion_MultipleQuitar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Seleccion_MultipleQuitar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Seleccion_MultipleQuitar.Image = CType(resources.GetObject("Btn_Seleccion_MultipleQuitar.Image"), System.Drawing.Image)
        Me.Btn_Seleccion_MultipleQuitar.ImageAlt = CType(resources.GetObject("Btn_Seleccion_MultipleQuitar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Seleccion_MultipleQuitar.Name = "Btn_Seleccion_MultipleQuitar"
        Me.Btn_Seleccion_MultipleQuitar.Tooltip = "Quitar productos con selección múltiple (F4)"
        '
        'Frm_05_UbicXpro_UbicacionConProductos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(760, 468)
        Me.Controls.Add(Me.Lbl_InfoFechaIngUbic)
        Me.Controls.Add(Me.TxtUbicacion)
        Me.Controls.Add(Me.Rdb_Ud2)
        Me.Controls.Add(Me.Rdb_Ud1)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_05_UbicXpro_UbicacionConProductos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Productos en la ubicación"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Public WithEvents LblBodega As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Public WithEvents LblSucursal As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Public WithEvents LblEmpresa As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Buscar_Producto As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnExportarExcel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Btn_Seleccion_Multiple As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Rdb_Ud1 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Ud2 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_Ubicacion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Mnu_Ver_Ubicaciones_Del_Producto As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Imprimir_Etiquetas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents TxtUbicacion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Btn_Mnu_Eliminar_Ubicacion As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Mnu_Btn_Ver_Informacion_de_producto As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Lbl_InfoFechaIngUbic As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Seleccion_MultipleQuitar As DevComponents.DotNetBar.ButtonItem
End Class
