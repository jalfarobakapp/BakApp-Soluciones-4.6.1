<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Informe_Composicion_Stock_X_Productos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Informe_Composicion_Stock_X_Productos))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Grupo_Venta_Diaria = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_Producto = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Ver_Informacion_Producto = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Copiar = New DevComponents.DotNetBar.ButtonItem()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Actualizar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Excel = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Rdb_Saldo_Con_y_sin_saldo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Saldo_Con_saldo_Positivo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Saldo_Distinto_de_cero = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Grupo_Total = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Lbl_Total_Valirzado = New DevComponents.DotNetBar.LabelX()
        Me.Grupo_Impuestos = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Lbl_Total_Stock = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Filtro_Productos = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Grupo_Venta_Diaria.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Grupo_Total.SuspendLayout()
        Me.Grupo_Impuestos.SuspendLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Grupo_Venta_Diaria
        '
        Me.Grupo_Venta_Diaria.BackColor = System.Drawing.Color.White
        Me.Grupo_Venta_Diaria.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Venta_Diaria.Controls.Add(Me.ContextMenuBar1)
        Me.Grupo_Venta_Diaria.Controls.Add(Me.Grilla)
        Me.Grupo_Venta_Diaria.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Venta_Diaria.Location = New System.Drawing.Point(12, 41)
        Me.Grupo_Venta_Diaria.Name = "Grupo_Venta_Diaria"
        Me.Grupo_Venta_Diaria.Size = New System.Drawing.Size(760, 415)
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
        Me.Grupo_Venta_Diaria.TabIndex = 98
        Me.Grupo_Venta_Diaria.Text = "Detalle de productos"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_Producto})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(89, 97)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(529, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 97
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_Producto
        '
        Me.Menu_Contextual_Producto.AutoExpandOnClick = True
        Me.Menu_Contextual_Producto.Name = "Menu_Contextual_Producto"
        Me.Menu_Contextual_Producto.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Ver_Informacion_Producto, Me.Btn_Copiar})
        Me.Menu_Contextual_Producto.Text = "Opciones producto"
        '
        'Btn_Ver_Informacion_Producto
        '
        Me.Btn_Ver_Informacion_Producto.Image = CType(resources.GetObject("Btn_Ver_Informacion_Producto.Image"), System.Drawing.Image)
        Me.Btn_Ver_Informacion_Producto.Name = "Btn_Ver_Informacion_Producto"
        Me.Btn_Ver_Informacion_Producto.Text = "Ver estadísticas del producto (Información adicional)"
        '
        'Btn_Copiar
        '
        Me.Btn_Copiar.Image = CType(resources.GetObject("Btn_Copiar.Image"), System.Drawing.Image)
        Me.Btn_Copiar.Name = "Btn_Copiar"
        Me.Btn_Copiar.Text = "Copiar (portapapeles)"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Actualizar, Me.Btn_Excel})
        Me.Bar1.Location = New System.Drawing.Point(0, 526)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(784, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 97
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Actualizar
        '
        Me.Btn_Actualizar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Actualizar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Actualizar.Image = CType(resources.GetObject("Btn_Actualizar.Image"), System.Drawing.Image)
        Me.Btn_Actualizar.Name = "Btn_Actualizar"
        Me.Btn_Actualizar.Text = "Actualizar"
        Me.Btn_Actualizar.Visible = False
        '
        'Btn_Excel
        '
        Me.Btn_Excel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Excel.ForeColor = System.Drawing.Color.Black
        Me.Btn_Excel.Image = CType(resources.GetObject("Btn_Excel.Image"), System.Drawing.Image)
        Me.Btn_Excel.Name = "Btn_Excel"
        Me.Btn_Excel.Tooltip = "Exportar a Excel"
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(12, 462)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(387, 58)
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
        Me.GroupPanel2.TabIndex = 100
        Me.GroupPanel2.Text = "Saldo de productos"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_Saldo_Con_y_sin_saldo, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_Saldo_Con_saldo_Positivo, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_Saldo_Distinto_de_cero, 2, 0)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 10)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(382, 22)
        Me.TableLayoutPanel1.TabIndex = 5
        '
        'Rdb_Saldo_Con_y_sin_saldo
        '
        Me.Rdb_Saldo_Con_y_sin_saldo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Saldo_Con_y_sin_saldo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Saldo_Con_y_sin_saldo.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Saldo_Con_y_sin_saldo.Checked = True
        Me.Rdb_Saldo_Con_y_sin_saldo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Saldo_Con_y_sin_saldo.CheckValue = "Y"
        Me.Rdb_Saldo_Con_y_sin_saldo.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Saldo_Con_y_sin_saldo.Location = New System.Drawing.Point(3, 3)
        Me.Rdb_Saldo_Con_y_sin_saldo.Name = "Rdb_Saldo_Con_y_sin_saldo"
        Me.Rdb_Saldo_Con_y_sin_saldo.Size = New System.Drawing.Size(94, 14)
        Me.Rdb_Saldo_Con_y_sin_saldo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Saldo_Con_y_sin_saldo.TabIndex = 3
        Me.Rdb_Saldo_Con_y_sin_saldo.Text = "Con y sin saldo"
        '
        'Rdb_Saldo_Con_saldo_Positivo
        '
        Me.Rdb_Saldo_Con_saldo_Positivo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Saldo_Con_saldo_Positivo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Saldo_Con_saldo_Positivo.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Saldo_Con_saldo_Positivo.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Saldo_Con_saldo_Positivo.Location = New System.Drawing.Point(103, 3)
        Me.Rdb_Saldo_Con_saldo_Positivo.Name = "Rdb_Saldo_Con_saldo_Positivo"
        Me.Rdb_Saldo_Con_saldo_Positivo.Size = New System.Drawing.Size(113, 14)
        Me.Rdb_Saldo_Con_saldo_Positivo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Saldo_Con_saldo_Positivo.TabIndex = 6
        Me.Rdb_Saldo_Con_saldo_Positivo.Text = "Con saldo positivo"
        '
        'Rdb_Saldo_Distinto_de_cero
        '
        Me.Rdb_Saldo_Distinto_de_cero.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Saldo_Distinto_de_cero.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Saldo_Distinto_de_cero.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Saldo_Distinto_de_cero.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Saldo_Distinto_de_cero.Location = New System.Drawing.Point(222, 3)
        Me.Rdb_Saldo_Distinto_de_cero.Name = "Rdb_Saldo_Distinto_de_cero"
        Me.Rdb_Saldo_Distinto_de_cero.Size = New System.Drawing.Size(154, 14)
        Me.Rdb_Saldo_Distinto_de_cero.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Saldo_Distinto_de_cero.TabIndex = 6
        Me.Rdb_Saldo_Distinto_de_cero.Text = "Con saldo distinto de cero"
        '
        'Grupo_Total
        '
        Me.Grupo_Total.BackColor = System.Drawing.Color.White
        Me.Grupo_Total.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Total.Controls.Add(Me.Lbl_Total_Valirzado)
        Me.Grupo_Total.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Total.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Grupo_Total.Location = New System.Drawing.Point(640, 462)
        Me.Grupo_Total.Name = "Grupo_Total"
        Me.Grupo_Total.Size = New System.Drawing.Size(132, 58)
        '
        '
        '
        Me.Grupo_Total.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Total.Style.BackColorGradientAngle = 90
        Me.Grupo_Total.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Total.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Total.Style.BorderBottomWidth = 1
        Me.Grupo_Total.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Total.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Total.Style.BorderLeftWidth = 1
        Me.Grupo_Total.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Total.Style.BorderRightWidth = 1
        Me.Grupo_Total.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Total.Style.BorderTopWidth = 1
        Me.Grupo_Total.Style.CornerDiameter = 4
        Me.Grupo_Total.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Total.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Total.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Total.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Total.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Total.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Total.TabIndex = 101
        Me.Grupo_Total.Text = "Total Valorizado"
        '
        'Lbl_Total_Valirzado
        '
        Me.Lbl_Total_Valirzado.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Total_Valirzado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Total_Valirzado.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Total_Valirzado.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Total_Valirzado.Location = New System.Drawing.Point(3, 3)
        Me.Lbl_Total_Valirzado.Name = "Lbl_Total_Valirzado"
        Me.Lbl_Total_Valirzado.Size = New System.Drawing.Size(120, 23)
        Me.Lbl_Total_Valirzado.TabIndex = 34
        Me.Lbl_Total_Valirzado.Text = "0"
        Me.Lbl_Total_Valirzado.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Grupo_Impuestos
        '
        Me.Grupo_Impuestos.BackColor = System.Drawing.Color.White
        Me.Grupo_Impuestos.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Impuestos.Controls.Add(Me.Lbl_Total_Stock)
        Me.Grupo_Impuestos.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Impuestos.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Grupo_Impuestos.Location = New System.Drawing.Point(518, 462)
        Me.Grupo_Impuestos.Name = "Grupo_Impuestos"
        Me.Grupo_Impuestos.Size = New System.Drawing.Size(115, 58)
        '
        '
        '
        Me.Grupo_Impuestos.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Impuestos.Style.BackColorGradientAngle = 90
        Me.Grupo_Impuestos.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Impuestos.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Impuestos.Style.BorderBottomWidth = 1
        Me.Grupo_Impuestos.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Impuestos.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Impuestos.Style.BorderLeftWidth = 1
        Me.Grupo_Impuestos.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Impuestos.Style.BorderRightWidth = 1
        Me.Grupo_Impuestos.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Impuestos.Style.BorderTopWidth = 1
        Me.Grupo_Impuestos.Style.CornerDiameter = 4
        Me.Grupo_Impuestos.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Impuestos.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Impuestos.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Impuestos.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Impuestos.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Impuestos.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Impuestos.TabIndex = 102
        Me.Grupo_Impuestos.Text = "Total Stock"
        '
        'Lbl_Total_Stock
        '
        Me.Lbl_Total_Stock.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Total_Stock.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Total_Stock.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Total_Stock.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Total_Stock.Location = New System.Drawing.Point(2, 4)
        Me.Lbl_Total_Stock.Name = "Lbl_Total_Stock"
        Me.Lbl_Total_Stock.Size = New System.Drawing.Size(104, 23)
        Me.Lbl_Total_Stock.TabIndex = 34
        Me.Lbl_Total_Stock.Text = "0"
        Me.Lbl_Total_Stock.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(12, 12)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(90, 23)
        Me.LabelX1.TabIndex = 119
        Me.LabelX1.Text = "Filtrar productos"
        '
        'Txt_Filtro_Productos
        '
        Me.Txt_Filtro_Productos.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Filtro_Productos.Border.Class = "TextBoxBorder"
        Me.Txt_Filtro_Productos.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Filtro_Productos.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Filtro_Productos.ForeColor = System.Drawing.Color.Black
        Me.Txt_Filtro_Productos.Location = New System.Drawing.Point(108, 12)
        Me.Txt_Filtro_Productos.Name = "Txt_Filtro_Productos"
        Me.Txt_Filtro_Productos.PreventEnterBeep = True
        Me.Txt_Filtro_Productos.Size = New System.Drawing.Size(661, 22)
        Me.Txt_Filtro_Productos.TabIndex = 118
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
        Me.Grilla.Size = New System.Drawing.Size(754, 392)
        Me.Grilla.TabIndex = 98
        '
        'Frm_Informe_Composicion_Stock_X_Productos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 567)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Txt_Filtro_Productos)
        Me.Controls.Add(Me.Grupo_Total)
        Me.Controls.Add(Me.Grupo_Impuestos)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.Grupo_Venta_Diaria)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Informe_Composicion_Stock_X_Productos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informe de Stock valorizado por productos"
        Me.Grupo_Venta_Diaria.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Grupo_Total.ResumeLayout(False)
        Me.Grupo_Impuestos.ResumeLayout(False)
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Grupo_Venta_Diaria As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Actualizar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Excel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_Producto As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Ver_Informacion_Producto As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Copiar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Rdb_Saldo_Con_y_sin_saldo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Saldo_Con_saldo_Positivo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Saldo_Distinto_de_cero As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Grupo_Total As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Lbl_Total_Valirzado As DevComponents.DotNetBar.LabelX
    Friend WithEvents Grupo_Impuestos As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Lbl_Total_Stock As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Filtro_Productos As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
End Class
