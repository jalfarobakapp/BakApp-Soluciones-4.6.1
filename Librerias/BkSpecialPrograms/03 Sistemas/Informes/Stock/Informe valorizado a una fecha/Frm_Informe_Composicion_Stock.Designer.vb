<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Informe_Composicion_Stock
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Informe_Composicion_Stock))
        Me.Grupo_Venta_Diaria = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_Informe = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Informe_X_Bodega = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Informe_X_Familia = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Informe_X_Obsolencia = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Informe_X_Productos = New DevComponents.DotNetBar.ButtonItem()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Actualizar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Excel = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Rdb_Saldo_Con_y_sin_saldo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Saldo_Con_saldo_Positivo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Saldo_Distinto_de_cero = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Grupo_Venta_Diaria.SuspendLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
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
        Me.Grupo_Venta_Diaria.Location = New System.Drawing.Point(12, 6)
        Me.Grupo_Venta_Diaria.Name = "Grupo_Venta_Diaria"
        Me.Grupo_Venta_Diaria.Size = New System.Drawing.Size(760, 411)
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
        Me.Grupo_Venta_Diaria.TabIndex = 96
        Me.Grupo_Venta_Diaria.Text = "Detalle del informe"
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
        Me.Grilla.Size = New System.Drawing.Size(754, 388)
        Me.Grilla.TabIndex = 3
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_Informe})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(210, 144)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(266, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 96
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_Informe
        '
        Me.Menu_Contextual_Informe.AutoExpandOnClick = True
        Me.Menu_Contextual_Informe.Name = "Menu_Contextual_Informe"
        Me.Menu_Contextual_Informe.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem2, Me.Btn_Informe_X_Bodega, Me.Btn_Informe_X_Familia, Me.Btn_Informe_X_Obsolencia, Me.LabelItem1, Me.Btn_Informe_X_Productos})
        Me.Menu_Contextual_Informe.Text = "Sub Informes STOCK"
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
        Me.LabelItem2.Text = "Opciones para descuentos del documento"
        '
        'Btn_Informe_X_Bodega
        '
        Me.Btn_Informe_X_Bodega.Image = CType(resources.GetObject("Btn_Informe_X_Bodega.Image"), System.Drawing.Image)
        Me.Btn_Informe_X_Bodega.Name = "Btn_Informe_X_Bodega"
        Me.Btn_Informe_X_Bodega.Text = "Ver informe por <b><font color=""#0072BC"">BODEGAS</font></b>"
        '
        'Btn_Informe_X_Familia
        '
        Me.Btn_Informe_X_Familia.Image = CType(resources.GetObject("Btn_Informe_X_Familia.Image"), System.Drawing.Image)
        Me.Btn_Informe_X_Familia.Name = "Btn_Informe_X_Familia"
        Me.Btn_Informe_X_Familia.Text = "Ver informe por <b><font color=""#4E5D30""><font color=""#ED1C24"">FAMILIAS</font></f" &
    "ont></b>"
        '
        'Btn_Informe_X_Obsolencia
        '
        Me.Btn_Informe_X_Obsolencia.Image = CType(resources.GetObject("Btn_Informe_X_Obsolencia.Image"), System.Drawing.Image)
        Me.Btn_Informe_X_Obsolencia.Name = "Btn_Informe_X_Obsolencia"
        Me.Btn_Informe_X_Obsolencia.Text = "Ver informe por <b><font color=""#903C39"">OBSOLESENCIA</font></b>"
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
        Me.LabelItem1.Text = "Detalle de productos"
        '
        'Btn_Informe_X_Productos
        '
        Me.Btn_Informe_X_Productos.Image = CType(resources.GetObject("Btn_Informe_X_Productos.Image"), System.Drawing.Image)
        Me.Btn_Informe_X_Productos.Name = "Btn_Informe_X_Productos"
        Me.Btn_Informe_X_Productos.Text = "Ver detalle de los <b><font color=""#22B14C"">PRODUCTOS</font></b>"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Actualizar, Me.Btn_Excel})
        Me.Bar1.Location = New System.Drawing.Point(0, 481)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(784, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 95
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
        Me.GroupPanel2.Location = New System.Drawing.Point(12, 423)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(387, 52)
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
        Me.GroupPanel2.TabIndex = 101
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
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
        'Frm_Informe_Composicion_Stock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 522)
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
        Me.Name = "Frm_Informe_Composicion_Stock"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "INFORME STOCK A UNA FECHA"
        Me.Grupo_Venta_Diaria.ResumeLayout(False)
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Grupo_Venta_Diaria As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Actualizar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_Informe As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Informe_X_Productos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Excel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Rdb_Saldo_Con_y_sin_saldo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Saldo_Con_saldo_Positivo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Saldo_Distinto_de_cero As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Public WithEvents Btn_Informe_X_Bodega As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Informe_X_Familia As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Informe_X_Obsolencia As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
End Class
