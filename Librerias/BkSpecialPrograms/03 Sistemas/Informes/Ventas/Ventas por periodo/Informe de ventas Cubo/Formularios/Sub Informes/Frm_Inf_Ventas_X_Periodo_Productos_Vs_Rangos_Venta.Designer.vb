<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Inf_Ventas_X_Periodo_Productos_Vs_Rangos_Venta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Inf_Ventas_X_Periodo_Productos_Vs_Rangos_Venta))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual = New DevComponents.DotNetBar.ButtonItem()
        Me.Lbl_Mnu_1 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Mnu_Estadisticas_Producto = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Ver_Documento = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Informeacion_Credito_Cliente = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Informe_Clientes = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Informe_Documentos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Informe_Productos = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Excel = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Actualizar_Informe = New DevComponents.DotNetBar.ButtonItem()
        Me.Chk_Mostrar_Solo_Vendidos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel2
        '
        Me.GroupPanel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.ContextMenuBar1)
        Me.GroupPanel2.Controls.Add(Me.Grilla)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(1145, 469)
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
        Me.GroupPanel2.TabIndex = 117
        Me.GroupPanel2.Text = "Detalle"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(198, 47)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(356, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 51
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual
        '
        Me.Menu_Contextual.AutoExpandOnClick = True
        Me.Menu_Contextual.Name = "Menu_Contextual"
        Me.Menu_Contextual.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Lbl_Mnu_1, Me.Btn_Mnu_Estadisticas_Producto, Me.Btn_Mnu_Ver_Documento, Me.Btn_Mnu_Informeacion_Credito_Cliente, Me.Btn_Informe_Clientes, Me.Btn_Informe_Documentos, Me.Btn_Informe_Productos})
        Me.Menu_Contextual.Text = "Opciones"
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
        Me.Lbl_Mnu_1.Text = "Opciones"
        '
        'Btn_Mnu_Estadisticas_Producto
        '
        Me.Btn_Mnu_Estadisticas_Producto.Image = CType(resources.GetObject("Btn_Mnu_Estadisticas_Producto.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Estadisticas_Producto.ImageAlt = CType(resources.GetObject("Btn_Mnu_Estadisticas_Producto.ImageAlt"), System.Drawing.Image)
        Me.Btn_Mnu_Estadisticas_Producto.Name = "Btn_Mnu_Estadisticas_Producto"
        Me.Btn_Mnu_Estadisticas_Producto.Text = "Ver estadísticas del producto/información adicional"
        '
        'Btn_Mnu_Ver_Documento
        '
        Me.Btn_Mnu_Ver_Documento.Image = CType(resources.GetObject("Btn_Mnu_Ver_Documento.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Ver_Documento.ImageAlt = CType(resources.GetObject("Btn_Mnu_Ver_Documento.ImageAlt"), System.Drawing.Image)
        Me.Btn_Mnu_Ver_Documento.Name = "Btn_Mnu_Ver_Documento"
        Me.Btn_Mnu_Ver_Documento.Text = "Ver documento"
        Me.Btn_Mnu_Ver_Documento.Visible = False
        '
        'Btn_Mnu_Informeacion_Credito_Cliente
        '
        Me.Btn_Mnu_Informeacion_Credito_Cliente.Image = CType(resources.GetObject("Btn_Mnu_Informeacion_Credito_Cliente.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Informeacion_Credito_Cliente.ImageAlt = CType(resources.GetObject("Btn_Mnu_Informeacion_Credito_Cliente.ImageAlt"), System.Drawing.Image)
        Me.Btn_Mnu_Informeacion_Credito_Cliente.Name = "Btn_Mnu_Informeacion_Credito_Cliente"
        Me.Btn_Mnu_Informeacion_Credito_Cliente.Text = "Ver información de créditos vigentes del cliente"
        Me.Btn_Mnu_Informeacion_Credito_Cliente.Visible = False
        '
        'Btn_Informe_Clientes
        '
        Me.Btn_Informe_Clientes.Image = CType(resources.GetObject("Btn_Informe_Clientes.Image"), System.Drawing.Image)
        Me.Btn_Informe_Clientes.ImageAlt = CType(resources.GetObject("Btn_Informe_Clientes.ImageAlt"), System.Drawing.Image)
        Me.Btn_Informe_Clientes.Name = "Btn_Informe_Clientes"
        Me.Btn_Informe_Clientes.Text = "Ver detalle de los <b><font color=""#22B14C"">Clientes</font></b>"
        Me.Btn_Informe_Clientes.Visible = False
        '
        'Btn_Informe_Documentos
        '
        Me.Btn_Informe_Documentos.Image = CType(resources.GetObject("Btn_Informe_Documentos.Image"), System.Drawing.Image)
        Me.Btn_Informe_Documentos.ImageAlt = CType(resources.GetObject("Btn_Informe_Documentos.ImageAlt"), System.Drawing.Image)
        Me.Btn_Informe_Documentos.Name = "Btn_Informe_Documentos"
        Me.Btn_Informe_Documentos.Text = "Ver detalle de las <b><font color=""#22B14C"">Documentos</font></b>"
        Me.Btn_Informe_Documentos.Visible = False
        '
        'Btn_Informe_Productos
        '
        Me.Btn_Informe_Productos.Image = CType(resources.GetObject("Btn_Informe_Productos.Image"), System.Drawing.Image)
        Me.Btn_Informe_Productos.ImageAlt = CType(resources.GetObject("Btn_Informe_Productos.ImageAlt"), System.Drawing.Image)
        Me.Btn_Informe_Productos.Name = "Btn_Informe_Productos"
        Me.Btn_Informe_Productos.Text = "Ver detalle de los <b><font color=""#22B14C"">Productos</font></b>"
        Me.Btn_Informe_Productos.Visible = False
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
        Me.Grilla.Size = New System.Drawing.Size(1139, 446)
        Me.Grilla.TabIndex = 120
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Excel, Me.Btn_Actualizar_Informe})
        Me.Bar1.Location = New System.Drawing.Point(0, 528)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(1169, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 118
        Me.Bar1.TabStop = False
        '
        'Btn_Excel
        '
        Me.Btn_Excel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Excel.ForeColor = System.Drawing.Color.Black
        Me.Btn_Excel.Image = CType(resources.GetObject("Btn_Excel.Image"), System.Drawing.Image)
        Me.Btn_Excel.ImageAlt = CType(resources.GetObject("Btn_Excel.ImageAlt"), System.Drawing.Image)
        Me.Btn_Excel.Name = "Btn_Excel"
        Me.Btn_Excel.Tooltip = "Exportar a Excel"
        '
        'Btn_Actualizar_Informe
        '
        Me.Btn_Actualizar_Informe.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Actualizar_Informe.ForeColor = System.Drawing.Color.Black
        Me.Btn_Actualizar_Informe.Image = CType(resources.GetObject("Btn_Actualizar_Informe.Image"), System.Drawing.Image)
        Me.Btn_Actualizar_Informe.ImageAlt = CType(resources.GetObject("Btn_Actualizar_Informe.ImageAlt"), System.Drawing.Image)
        Me.Btn_Actualizar_Informe.Name = "Btn_Actualizar_Informe"
        Me.Btn_Actualizar_Informe.Text = "Actualizar"
        Me.Btn_Actualizar_Informe.Visible = False
        '
        'Chk_Mostrar_Solo_Vendidos
        '
        Me.Chk_Mostrar_Solo_Vendidos.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Mostrar_Solo_Vendidos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Mostrar_Solo_Vendidos.ForeColor = System.Drawing.Color.Black
        Me.Chk_Mostrar_Solo_Vendidos.Location = New System.Drawing.Point(12, 487)
        Me.Chk_Mostrar_Solo_Vendidos.Name = "Chk_Mostrar_Solo_Vendidos"
        Me.Chk_Mostrar_Solo_Vendidos.Size = New System.Drawing.Size(352, 23)
        Me.Chk_Mostrar_Solo_Vendidos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Mostrar_Solo_Vendidos.TabIndex = 119
        Me.Chk_Mostrar_Solo_Vendidos.Text = "Mostrar solo productos vendidos entre los periodos"
        Me.Chk_Mostrar_Solo_Vendidos.Visible = False
        '
        'Frm_Inf_Ventas_X_Periodo_Productos_Vs_Rangos_Venta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1169, 569)
        Me.Controls.Add(Me.Chk_Mostrar_Solo_Vendidos)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.GroupPanel2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Inf_Ventas_X_Periodo_Productos_Vs_Rangos_Venta"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DETALLE DE PRODUCTOS VENDIDOS"
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Lbl_Mnu_1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Mnu_Estadisticas_Producto As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_Ver_Documento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_Informeacion_Credito_Cliente As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Informe_Clientes As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Informe_Documentos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Informe_Productos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Excel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Actualizar_Informe As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Chk_Mostrar_Solo_Vendidos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
End Class
