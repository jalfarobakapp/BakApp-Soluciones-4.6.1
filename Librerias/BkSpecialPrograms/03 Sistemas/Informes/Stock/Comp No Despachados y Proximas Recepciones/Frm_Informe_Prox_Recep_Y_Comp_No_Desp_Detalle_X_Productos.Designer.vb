<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Informe_Prox_Recep_Y_Comp_No_Desp_Detalle_X_Productos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Informe_Prox_Recep_Y_Comp_No_Desp_Detalle_X_Productos))
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual = New DevComponents.DotNetBar.ButtonItem()
        Me.Lbl_Mnu_1 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Estadisticas_Producto = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Ver_Documento = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_Excel = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Excel_Detalle = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Excel_Resumen = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla_Productos = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Excel = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Grilla_Documentos = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Btn_Filtrar_Productos = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Quitar_Filtro = New DevComponents.DotNetBar.ButtonX()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla_Productos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Grilla_Documentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.ContextMenuBar1)
        Me.GroupPanel2.Controls.Add(Me.Grilla_Productos)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(12, 41)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(770, 322)
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
        Me.GroupPanel2.TabIndex = 108
        Me.GroupPanel2.Text = "Productos"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual, Me.Menu_Contextual_Excel})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(91, 62)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(356, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 50
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual
        '
        Me.Menu_Contextual.AutoExpandOnClick = True
        Me.Menu_Contextual.Name = "Menu_Contextual"
        Me.Menu_Contextual.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Lbl_Mnu_1, Me.Btn_Estadisticas_Producto, Me.Btn_Ver_Documento})
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
        'Btn_Estadisticas_Producto
        '
        Me.Btn_Estadisticas_Producto.Image = CType(resources.GetObject("Btn_Estadisticas_Producto.Image"), System.Drawing.Image)
        Me.Btn_Estadisticas_Producto.ImageAlt = CType(resources.GetObject("Btn_Estadisticas_Producto.ImageAlt"), System.Drawing.Image)
        Me.Btn_Estadisticas_Producto.Name = "Btn_Estadisticas_Producto"
        Me.Btn_Estadisticas_Producto.Text = "Ver estadísticas del producto/información adicional"
        '
        'Btn_Ver_Documento
        '
        Me.Btn_Ver_Documento.Image = CType(resources.GetObject("Btn_Ver_Documento.Image"), System.Drawing.Image)
        Me.Btn_Ver_Documento.ImageAlt = CType(resources.GetObject("Btn_Ver_Documento.ImageAlt"), System.Drawing.Image)
        Me.Btn_Ver_Documento.Name = "Btn_Ver_Documento"
        Me.Btn_Ver_Documento.Text = "Ver documento"
        '
        'Menu_Contextual_Excel
        '
        Me.Menu_Contextual_Excel.AutoExpandOnClick = True
        Me.Menu_Contextual_Excel.Name = "Menu_Contextual_Excel"
        Me.Menu_Contextual_Excel.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1, Me.Btn_Excel_Detalle, Me.Btn_Excel_Resumen})
        Me.Menu_Contextual_Excel.Text = "Exportar Excel"
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
        Me.LabelItem1.Text = "Opciones"
        '
        'Btn_Excel_Detalle
        '
        Me.Btn_Excel_Detalle.Image = CType(resources.GetObject("Btn_Excel_Detalle.Image"), System.Drawing.Image)
        Me.Btn_Excel_Detalle.ImageAlt = CType(resources.GetObject("Btn_Excel_Detalle.ImageAlt"), System.Drawing.Image)
        Me.Btn_Excel_Detalle.Name = "Btn_Excel_Detalle"
        Me.Btn_Excel_Detalle.Text = "Exportar todo el detalle"
        '
        'Btn_Excel_Resumen
        '
        Me.Btn_Excel_Resumen.Image = CType(resources.GetObject("Btn_Excel_Resumen.Image"), System.Drawing.Image)
        Me.Btn_Excel_Resumen.ImageAlt = CType(resources.GetObject("Btn_Excel_Resumen.ImageAlt"), System.Drawing.Image)
        Me.Btn_Excel_Resumen.Name = "Btn_Excel_Resumen"
        Me.Btn_Excel_Resumen.Text = "Exportar resumen"
        '
        'Grilla_Productos
        '
        Me.Grilla_Productos.AllowUserToAddRows = False
        Me.Grilla_Productos.AllowUserToDeleteRows = False
        Me.Grilla_Productos.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Productos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.Grilla_Productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Productos.DefaultCellStyle = DataGridViewCellStyle14
        Me.Grilla_Productos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Productos.EnableHeadersVisualStyles = False
        Me.Grilla_Productos.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Productos.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Productos.Name = "Grilla_Productos"
        Me.Grilla_Productos.ReadOnly = True
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Productos.RowHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.Grilla_Productos.RowHeadersVisible = False
        Me.Grilla_Productos.Size = New System.Drawing.Size(764, 299)
        Me.Grilla_Productos.TabIndex = 4
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Excel})
        Me.Bar1.Location = New System.Drawing.Point(0, 530)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(794, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 109
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
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
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Grilla_Documentos)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 369)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(770, 142)
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
        Me.GroupPanel1.TabIndex = 110
        Me.GroupPanel1.Text = "Detalle del producto"
        '
        'Grilla_Documentos
        '
        Me.Grilla_Documentos.AllowUserToAddRows = False
        Me.Grilla_Documentos.AllowUserToDeleteRows = False
        Me.Grilla_Documentos.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Documentos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle16
        Me.Grilla_Documentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Documentos.DefaultCellStyle = DataGridViewCellStyle17
        Me.Grilla_Documentos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Documentos.EnableHeadersVisualStyles = False
        Me.Grilla_Documentos.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Documentos.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Documentos.Name = "Grilla_Documentos"
        Me.Grilla_Documentos.ReadOnly = True
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Documentos.RowHeadersDefaultCellStyle = DataGridViewCellStyle18
        Me.Grilla_Documentos.RowHeadersVisible = False
        Me.Grilla_Documentos.Size = New System.Drawing.Size(764, 119)
        Me.Grilla_Documentos.TabIndex = 3
        '
        'Btn_Filtrar_Productos
        '
        Me.Btn_Filtrar_Productos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Filtrar_Productos.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Filtrar_Productos.Location = New System.Drawing.Point(12, 12)
        Me.Btn_Filtrar_Productos.Name = "Btn_Filtrar_Productos"
        Me.Btn_Filtrar_Productos.Size = New System.Drawing.Size(118, 23)
        Me.Btn_Filtrar_Productos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Filtrar_Productos.TabIndex = 111
        Me.Btn_Filtrar_Productos.Text = "Filtrar productos"
        '
        'Btn_Quitar_Filtro
        '
        Me.Btn_Quitar_Filtro.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Quitar_Filtro.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Quitar_Filtro.Image = CType(resources.GetObject("Btn_Quitar_Filtro.Image"), System.Drawing.Image)
        Me.Btn_Quitar_Filtro.ImageAlt = CType(resources.GetObject("Btn_Quitar_Filtro.ImageAlt"), System.Drawing.Image)
        Me.Btn_Quitar_Filtro.Location = New System.Drawing.Point(131, 12)
        Me.Btn_Quitar_Filtro.Name = "Btn_Quitar_Filtro"
        Me.Btn_Quitar_Filtro.Size = New System.Drawing.Size(28, 23)
        Me.Btn_Quitar_Filtro.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Quitar_Filtro.TabIndex = 112
        Me.Btn_Quitar_Filtro.Tooltip = "Quitar filtro"
        '
        'Frm_Informe_Prox_Recep_Y_Comp_No_Desp_Detalle_X_Productos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(794, 571)
        Me.Controls.Add(Me.Btn_Quitar_Filtro)
        Me.Controls.Add(Me.Btn_Filtrar_Productos)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.GroupPanel2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Informe_Prox_Recep_Y_Comp_No_Desp_Detalle_X_Productos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla_Productos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.Grilla_Documentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Excel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Lbl_Mnu_1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Estadisticas_Producto As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Ver_Documento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grilla_Productos As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Grilla_Documentos As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Btn_Filtrar_Productos As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Menu_Contextual_Excel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Excel_Detalle As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Excel_Resumen As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Quitar_Filtro As DevComponents.DotNetBar.ButtonX
End Class
