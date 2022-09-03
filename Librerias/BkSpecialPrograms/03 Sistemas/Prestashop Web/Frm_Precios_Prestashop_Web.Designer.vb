<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Precios_Prestashop_Web
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Precios_Prestashop_Web))
        Me.Progress_Porcent = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.Progress_Canti = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Actualizar_Productos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Actualizar_Precios_Stock = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Exportar_ID_Web_Referencia = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Detener = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_01 = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Actualizar_Todo = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Actualizar_Algunos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Actualizar_Solo_Con_Cambios_BD = New DevComponents.DotNetBar.ButtonItem()
        Me.Lbl_Producto = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Estado = New DevComponents.DotNetBar.LabelX()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Progress_Porcent
        '
        Me.Progress_Porcent.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Progress_Porcent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Progress_Porcent.Location = New System.Drawing.Point(3, 4)
        Me.Progress_Porcent.Name = "Progress_Porcent"
        Me.Progress_Porcent.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.Progress_Porcent.ProgressColor = System.Drawing.Color.SteelBlue
        Me.Progress_Porcent.ProgressTextVisible = True
        Me.Progress_Porcent.Size = New System.Drawing.Size(56, 46)
        Me.Progress_Porcent.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.Progress_Porcent.TabIndex = 7
        '
        'Progress_Canti
        '
        Me.Progress_Canti.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Progress_Canti.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Progress_Canti.Location = New System.Drawing.Point(53, 4)
        Me.Progress_Canti.Name = "Progress_Canti"
        Me.Progress_Canti.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.Progress_Canti.ProgressColor = System.Drawing.Color.SteelBlue
        Me.Progress_Canti.ProgressTextFormat = "{0}"
        Me.Progress_Canti.ProgressTextVisible = True
        Me.Progress_Canti.Size = New System.Drawing.Size(56, 46)
        Me.Progress_Canti.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.Progress_Canti.TabIndex = 6
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Actualizar_Productos, Me.Btn_Actualizar_Precios_Stock, Me.Btn_Exportar_ID_Web_Referencia, Me.Btn_Detener})
        Me.Bar2.Location = New System.Drawing.Point(0, 100)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(600, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 41
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Actualizar_Productos
        '
        Me.Btn_Actualizar_Productos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Actualizar_Productos.ForeColor = System.Drawing.Color.Black
        Me.Btn_Actualizar_Productos.Image = CType(resources.GetObject("Btn_Actualizar_Productos.Image"), System.Drawing.Image)
        Me.Btn_Actualizar_Productos.ImageAlt = CType(resources.GetObject("Btn_Actualizar_Productos.ImageAlt"), System.Drawing.Image)
        Me.Btn_Actualizar_Productos.Name = "Btn_Actualizar_Productos"
        Me.Btn_Actualizar_Productos.Tooltip = "Actualizar Productos"
        '
        'Btn_Actualizar_Precios_Stock
        '
        Me.Btn_Actualizar_Precios_Stock.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Actualizar_Precios_Stock.ForeColor = System.Drawing.Color.Black
        Me.Btn_Actualizar_Precios_Stock.Image = CType(resources.GetObject("Btn_Actualizar_Precios_Stock.Image"), System.Drawing.Image)
        Me.Btn_Actualizar_Precios_Stock.ImageAlt = CType(resources.GetObject("Btn_Actualizar_Precios_Stock.ImageAlt"), System.Drawing.Image)
        Me.Btn_Actualizar_Precios_Stock.Name = "Btn_Actualizar_Precios_Stock"
        Me.Btn_Actualizar_Precios_Stock.Tooltip = "Actualizar precios y stock"
        '
        'Btn_Exportar_ID_Web_Referencia
        '
        Me.Btn_Exportar_ID_Web_Referencia.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Exportar_ID_Web_Referencia.ForeColor = System.Drawing.Color.Black
        Me.Btn_Exportar_ID_Web_Referencia.Image = CType(resources.GetObject("Btn_Exportar_ID_Web_Referencia.Image"), System.Drawing.Image)
        Me.Btn_Exportar_ID_Web_Referencia.ImageAlt = CType(resources.GetObject("Btn_Exportar_ID_Web_Referencia.ImageAlt"), System.Drawing.Image)
        Me.Btn_Exportar_ID_Web_Referencia.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Exportar_ID_Web_Referencia.Name = "Btn_Exportar_ID_Web_Referencia"
        Me.Btn_Exportar_ID_Web_Referencia.Tooltip = "Exportar ID web con referencia"
        Me.Btn_Exportar_ID_Web_Referencia.Visible = False
        '
        'Btn_Detener
        '
        Me.Btn_Detener.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Detener.ForeColor = System.Drawing.Color.Black
        Me.Btn_Detener.Image = CType(resources.GetObject("Btn_Detener.Image"), System.Drawing.Image)
        Me.Btn_Detener.ImageAlt = CType(resources.GetObject("Btn_Detener.ImageAlt"), System.Drawing.Image)
        Me.Btn_Detener.Name = "Btn_Detener"
        Me.Btn_Detener.Text = "Detener"
        Me.Btn_Detener.Visible = False
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.ContextMenuBar1)
        Me.GroupPanel1.Controls.Add(Me.Lbl_Producto)
        Me.GroupPanel1.Controls.Add(Me.Lbl_Estado)
        Me.GroupPanel1.Controls.Add(Me.Progress_Porcent)
        Me.GroupPanel1.Controls.Add(Me.Progress_Canti)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(576, 70)
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
        Me.GroupPanel1.TabIndex = 42
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_01})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(397, 31)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(153, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 46
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_01
        '
        Me.Menu_Contextual_01.AutoExpandOnClick = True
        Me.Menu_Contextual_01.Name = "Menu_Contextual_01"
        Me.Menu_Contextual_01.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1, Me.Btn_Actualizar_Todo, Me.Btn_Actualizar_Algunos, Me.Btn_Actualizar_Solo_Con_Cambios_BD})
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
        Me.LabelItem1.Text = "Opciones"
        '
        'Btn_Actualizar_Todo
        '
        Me.Btn_Actualizar_Todo.Image = CType(resources.GetObject("Btn_Actualizar_Todo.Image"), System.Drawing.Image)
        Me.Btn_Actualizar_Todo.ImageAlt = CType(resources.GetObject("Btn_Actualizar_Todo.ImageAlt"), System.Drawing.Image)
        Me.Btn_Actualizar_Todo.Name = "Btn_Actualizar_Todo"
        Me.Btn_Actualizar_Todo.Text = "Actualizar todos los productos"
        '
        'Btn_Actualizar_Algunos
        '
        Me.Btn_Actualizar_Algunos.Image = CType(resources.GetObject("Btn_Actualizar_Algunos.Image"), System.Drawing.Image)
        Me.Btn_Actualizar_Algunos.ImageAlt = CType(resources.GetObject("Btn_Actualizar_Algunos.ImageAlt"), System.Drawing.Image)
        Me.Btn_Actualizar_Algunos.Name = "Btn_Actualizar_Algunos"
        Me.Btn_Actualizar_Algunos.Text = "Actualizar solo algunos (seleccionar)"
        '
        'Btn_Actualizar_Solo_Con_Cambios_BD
        '
        Me.Btn_Actualizar_Solo_Con_Cambios_BD.Image = CType(resources.GetObject("Btn_Actualizar_Solo_Con_Cambios_BD.Image"), System.Drawing.Image)
        Me.Btn_Actualizar_Solo_Con_Cambios_BD.ImageAlt = CType(resources.GetObject("Btn_Actualizar_Solo_Con_Cambios_BD.ImageAlt"), System.Drawing.Image)
        Me.Btn_Actualizar_Solo_Con_Cambios_BD.Name = "Btn_Actualizar_Solo_Con_Cambios_BD"
        Me.Btn_Actualizar_Solo_Con_Cambios_BD.Text = "Actualizar solo con cambios en BD"
        '
        'Lbl_Producto
        '
        Me.Lbl_Producto.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Producto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Producto.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Producto.Location = New System.Drawing.Point(127, 33)
        Me.Lbl_Producto.Name = "Lbl_Producto"
        Me.Lbl_Producto.Size = New System.Drawing.Size(440, 23)
        Me.Lbl_Producto.TabIndex = 9
        Me.Lbl_Producto.Text = "Producto:"
        '
        'Lbl_Estado
        '
        Me.Lbl_Estado.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Estado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Estado.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Estado.Location = New System.Drawing.Point(127, 4)
        Me.Lbl_Estado.Name = "Lbl_Estado"
        Me.Lbl_Estado.Size = New System.Drawing.Size(440, 23)
        Me.Lbl_Estado.TabIndex = 8
        Me.Lbl_Estado.Text = "Estado..."
        '
        'Frm_Precios_Prestashop_Web
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 141)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Precios_Prestashop_Web"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Actualizador  de datos PrestaShop"
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Progress_Porcent As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Progress_Canti As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Actualizar_Productos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Exportar_ID_Web_Referencia As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Lbl_Producto As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Estado As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Detener As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Actualizar_Precios_Stock As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Public WithEvents Menu_Contextual_01 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Actualizar_Todo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Actualizar_Algunos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Actualizar_Solo_Con_Cambios_BD As DevComponents.DotNetBar.ButtonItem
End Class
