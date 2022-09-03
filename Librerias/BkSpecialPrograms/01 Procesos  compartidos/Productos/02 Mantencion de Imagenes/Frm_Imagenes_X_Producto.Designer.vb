<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Imagenes_X_Producto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Imagenes_X_Producto))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Pbx_Imagen = New System.Windows.Forms.PictureBox()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Subir_Imagen = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Eliminar = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnSolicitarProductoBodega = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla_Imagenes = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_Imagenes = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_DejarXDefecto = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Eliminar = New DevComponents.DotNetBar.ButtonItem()
        Me.Lbl_Url = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        CType(Me.Pbx_Imagen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla_Imagenes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.GroupPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pbx_Imagen
        '
        Me.Pbx_Imagen.BackColor = System.Drawing.Color.White
        Me.Pbx_Imagen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pbx_Imagen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pbx_Imagen.ForeColor = System.Drawing.Color.Black
        Me.Pbx_Imagen.Location = New System.Drawing.Point(0, 0)
        Me.Pbx_Imagen.Margin = New System.Windows.Forms.Padding(0)
        Me.Pbx_Imagen.Name = "Pbx_Imagen"
        Me.Pbx_Imagen.Size = New System.Drawing.Size(519, 447)
        Me.Pbx_Imagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Pbx_Imagen.TabIndex = 0
        Me.Pbx_Imagen.TabStop = False
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Subir_Imagen, Me.Btn_Eliminar, Me.BtnSolicitarProductoBodega})
        Me.Bar1.Location = New System.Drawing.Point(0, 523)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(716, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 25
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Subir_Imagen
        '
        Me.Btn_Subir_Imagen.ForeColor = System.Drawing.Color.Black
        Me.Btn_Subir_Imagen.Image = CType(resources.GetObject("Btn_Subir_Imagen.Image"), System.Drawing.Image)
        Me.Btn_Subir_Imagen.ImageAlt = CType(resources.GetObject("Btn_Subir_Imagen.ImageAlt"), System.Drawing.Image)
        Me.Btn_Subir_Imagen.Name = "Btn_Subir_Imagen"
        '
        'Btn_Eliminar
        '
        Me.Btn_Eliminar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Eliminar.Image = CType(resources.GetObject("Btn_Eliminar.Image"), System.Drawing.Image)
        Me.Btn_Eliminar.ImageAlt = CType(resources.GetObject("Btn_Eliminar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Eliminar.Name = "Btn_Eliminar"
        '
        'BtnSolicitarProductoBodega
        '
        Me.BtnSolicitarProductoBodega.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnSolicitarProductoBodega.ForeColor = System.Drawing.Color.Black
        Me.BtnSolicitarProductoBodega.Image = CType(resources.GetObject("BtnSolicitarProductoBodega.Image"), System.Drawing.Image)
        Me.BtnSolicitarProductoBodega.ImageAlt = CType(resources.GetObject("BtnSolicitarProductoBodega.ImageAlt"), System.Drawing.Image)
        Me.BtnSolicitarProductoBodega.Name = "BtnSolicitarProductoBodega"
        Me.BtnSolicitarProductoBodega.Text = "Solicitar producto a bodega"
        Me.BtnSolicitarProductoBodega.Visible = False
        '
        'Grilla_Imagenes
        '
        Me.Grilla_Imagenes.AllowUserToAddRows = False
        Me.Grilla_Imagenes.AllowUserToDeleteRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.PeachPuff
        Me.Grilla_Imagenes.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla_Imagenes.BackgroundColor = System.Drawing.Color.White
        Me.Grilla_Imagenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Imagenes.DefaultCellStyle = DataGridViewCellStyle4
        Me.Grilla_Imagenes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Imagenes.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Imagenes.Name = "Grilla_Imagenes"
        Me.Grilla_Imagenes.ReadOnly = True
        Me.Grilla_Imagenes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grilla_Imagenes.Size = New System.Drawing.Size(147, 453)
        Me.Grilla_Imagenes.TabIndex = 27
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.Panel1.Controls.Add(Me.ContextMenuBar1)
        Me.Panel1.Controls.Add(Me.Pbx_Imagen)
        Me.Panel1.ForeColor = System.Drawing.Color.Black
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(519, 447)
        Me.Panel1.TabIndex = 30
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_Imagenes})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(172, 216)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(252, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 49
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_Imagenes
        '
        Me.Menu_Contextual_Imagenes.AutoExpandOnClick = True
        Me.Menu_Contextual_Imagenes.Name = "Menu_Contextual_Imagenes"
        Me.Menu_Contextual_Imagenes.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_DejarXDefecto, Me.Btn_Mnu_Eliminar})
        Me.Menu_Contextual_Imagenes.Text = "Opciones Lista"
        '
        'Btn_DejarXDefecto
        '
        Me.Btn_DejarXDefecto.Image = CType(resources.GetObject("Btn_DejarXDefecto.Image"), System.Drawing.Image)
        Me.Btn_DejarXDefecto.ImageAlt = CType(resources.GetObject("Btn_DejarXDefecto.ImageAlt"), System.Drawing.Image)
        Me.Btn_DejarXDefecto.Name = "Btn_DejarXDefecto"
        Me.Btn_DejarXDefecto.Text = "Dejar imagen por defecto"
        '
        'Btn_Mnu_Eliminar
        '
        Me.Btn_Mnu_Eliminar.Image = CType(resources.GetObject("Btn_Mnu_Eliminar.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Eliminar.ImageAlt = CType(resources.GetObject("Btn_Mnu_Eliminar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Mnu_Eliminar.Name = "Btn_Mnu_Eliminar"
        Me.Btn_Mnu_Eliminar.Text = "Eliminar"
        '
        'Lbl_Url
        '
        Me.Lbl_Url.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Lbl_Url.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Url.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Url.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Url.Location = New System.Drawing.Point(12, 494)
        Me.Lbl_Url.Name = "Lbl_Url"
        Me.Lbl_Url.Size = New System.Drawing.Size(689, 23)
        Me.Lbl_Url.TabIndex = 32
        Me.Lbl_Url.Text = "Url: "
        '
        'GroupPanel1
        '
        Me.GroupPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Grilla_Imagenes)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(153, 476)
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
        Me.GroupPanel1.TabIndex = 33
        Me.GroupPanel1.Text = "Imagenes"
        '
        'GroupPanel2
        '
        Me.GroupPanel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Panel1)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(171, 12)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(533, 476)
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
        Me.GroupPanel2.TabIndex = 34
        Me.GroupPanel2.Text = "Imagen"
        '
        'Frm_Imagenes_X_Producto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(716, 564)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Lbl_Url)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(732, 603)
        Me.Name = "Frm_Imagenes_X_Producto"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Imagenes del producto"
        CType(Me.Pbx_Imagen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla_Imagenes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pbx_Imagen As System.Windows.Forms.PictureBox
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Grilla_Imagenes As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Public WithEvents BtnSolicitarProductoBodega As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Subir_Imagen As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Eliminar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Lbl_Url As DevComponents.DotNetBar.LabelX
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_Imagenes As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_DejarXDefecto As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_Eliminar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
End Class
