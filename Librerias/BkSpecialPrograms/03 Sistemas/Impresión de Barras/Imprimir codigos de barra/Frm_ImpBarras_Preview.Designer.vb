<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_ImpBarras_Preview
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ImpBarras_Preview))
        Me.Btn_imprimir_Archivo = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem2 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem3 = New DevComponents.DotNetBar.ButtonItem()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Recargar = New DevComponents.DotNetBar.ButtonItem()
        Me.Lbl_Nombre_Etiqueta = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Producto = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Img_Etiqueta = New System.Windows.Forms.PictureBox()
        Me.Pnl_Alto = New System.Windows.Forms.Panel()
        Me.Pnl_Ancho = New System.Windows.Forms.Panel()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.Img_Etiqueta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Btn_imprimir_Archivo
        '
        Me.Btn_imprimir_Archivo.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_imprimir_Archivo.ForeColor = System.Drawing.Color.Black
        Me.Btn_imprimir_Archivo.Image = CType(resources.GetObject("Btn_imprimir_Archivo.Image"), System.Drawing.Image)
        Me.Btn_imprimir_Archivo.ImageAlt = CType(resources.GetObject("Btn_imprimir_Archivo.ImageAlt"), System.Drawing.Image)
        Me.Btn_imprimir_Archivo.Name = "Btn_imprimir_Archivo"
        Me.Btn_imprimir_Archivo.Text = "Imprimir a un archivo"
        Me.Btn_imprimir_Archivo.Visible = False
        '
        'ButtonItem1
        '
        Me.ButtonItem1.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem1.ForeColor = System.Drawing.Color.Black
        Me.ButtonItem1.Image = CType(resources.GetObject("ButtonItem1.Image"), System.Drawing.Image)
        Me.ButtonItem1.ImageAlt = CType(resources.GetObject("ButtonItem1.ImageAlt"), System.Drawing.Image)
        Me.ButtonItem1.Name = "ButtonItem1"
        Me.ButtonItem1.Text = "Imprimir a un archivo"
        Me.ButtonItem1.Visible = False
        '
        'ButtonItem2
        '
        Me.ButtonItem2.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem2.ForeColor = System.Drawing.Color.Black
        Me.ButtonItem2.Image = CType(resources.GetObject("ButtonItem2.Image"), System.Drawing.Image)
        Me.ButtonItem2.ImageAlt = CType(resources.GetObject("ButtonItem2.ImageAlt"), System.Drawing.Image)
        Me.ButtonItem2.Name = "ButtonItem2"
        Me.ButtonItem2.Text = "Imprimir a un archivo"
        Me.ButtonItem2.Visible = False
        '
        'ButtonItem3
        '
        Me.ButtonItem3.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem3.ForeColor = System.Drawing.Color.Black
        Me.ButtonItem3.Image = CType(resources.GetObject("ButtonItem3.Image"), System.Drawing.Image)
        Me.ButtonItem3.ImageAlt = CType(resources.GetObject("ButtonItem3.ImageAlt"), System.Drawing.Image)
        Me.ButtonItem3.Name = "ButtonItem3"
        Me.ButtonItem3.Text = "Imprimir a un archivo"
        Me.ButtonItem3.Visible = False
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Recargar})
        Me.Bar1.Location = New System.Drawing.Point(0, 449)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(844, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010
        Me.Bar1.TabIndex = 66
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Recargar
        '
        Me.Btn_Recargar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Recargar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Recargar.Image = CType(resources.GetObject("Btn_Recargar.Image"), System.Drawing.Image)
        Me.Btn_Recargar.ImageAlt = CType(resources.GetObject("Btn_Recargar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Recargar.Name = "Btn_Recargar"
        Me.Btn_Recargar.Stretch = True
        '
        'Lbl_Nombre_Etiqueta
        '
        Me.Lbl_Nombre_Etiqueta.AutoSize = True
        Me.Lbl_Nombre_Etiqueta.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Nombre_Etiqueta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Nombre_Etiqueta.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Nombre_Etiqueta.Location = New System.Drawing.Point(76, 12)
        Me.Lbl_Nombre_Etiqueta.Name = "Lbl_Nombre_Etiqueta"
        Me.Lbl_Nombre_Etiqueta.Size = New System.Drawing.Size(112, 17)
        Me.Lbl_Nombre_Etiqueta.TabIndex = 67
        Me.Lbl_Nombre_Etiqueta.Text = "Nombre de la etiqueta"
        '
        'Lbl_Producto
        '
        Me.Lbl_Producto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_Producto.AutoSize = True
        Me.Lbl_Producto.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Producto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Producto.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Producto.Location = New System.Drawing.Point(683, 12)
        Me.Lbl_Producto.Name = "Lbl_Producto"
        Me.Lbl_Producto.Size = New System.Drawing.Size(108, 17)
        Me.Lbl_Producto.TabIndex = 68
        Me.Lbl_Producto.Text = "Nombre del Producto"
        '
        'LabelX1
        '
        Me.LabelX1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelX1.AutoSize = True
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(616, 12)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(49, 17)
        Me.LabelX1.TabIndex = 69
        Me.LabelX1.Text = "Producto:"
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.CanvasColor = System.Drawing.Color.Empty
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Img_Etiqueta)
        Me.GroupPanel2.Controls.Add(Me.Pnl_Alto)
        Me.GroupPanel2.Controls.Add(Me.Pnl_Ancho)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(12, 39)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(820, 404)
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
        Me.GroupPanel2.TabIndex = 84
        Me.GroupPanel2.Text = "Vista de la etiqueta"
        '
        'Img_Etiqueta
        '
        Me.Img_Etiqueta.BackColor = System.Drawing.Color.Transparent
        Me.Img_Etiqueta.Dock = System.Windows.Forms.DockStyle.Left
        Me.Img_Etiqueta.ErrorImage = CType(resources.GetObject("Img_Etiqueta.ErrorImage"), System.Drawing.Image)
        Me.Img_Etiqueta.ForeColor = System.Drawing.Color.Black
        Me.Img_Etiqueta.Location = New System.Drawing.Point(116, 85)
        Me.Img_Etiqueta.Name = "Img_Etiqueta"
        Me.Img_Etiqueta.Size = New System.Drawing.Size(153, 296)
        Me.Img_Etiqueta.TabIndex = 0
        Me.Img_Etiqueta.TabStop = False
        '
        'Pnl_Alto
        '
        Me.Pnl_Alto.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.Pnl_Alto.Dock = System.Windows.Forms.DockStyle.Left
        Me.Pnl_Alto.ForeColor = System.Drawing.Color.Black
        Me.Pnl_Alto.Location = New System.Drawing.Point(0, 85)
        Me.Pnl_Alto.Name = "Pnl_Alto"
        Me.Pnl_Alto.Size = New System.Drawing.Size(116, 296)
        Me.Pnl_Alto.TabIndex = 2
        '
        'Pnl_Ancho
        '
        Me.Pnl_Ancho.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.Pnl_Ancho.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pnl_Ancho.ForeColor = System.Drawing.Color.Black
        Me.Pnl_Ancho.Location = New System.Drawing.Point(0, 0)
        Me.Pnl_Ancho.Name = "Pnl_Ancho"
        Me.Pnl_Ancho.Size = New System.Drawing.Size(814, 85)
        Me.Pnl_Ancho.TabIndex = 1
        '
        'LabelX2
        '
        Me.LabelX2.AutoSize = True
        Me.LabelX2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(12, 12)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(45, 17)
        Me.LabelX2.TabIndex = 85
        Me.LabelX2.Text = "Etiqueta:"
        '
        'Frm_ImpBarras_Preview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(844, 490)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Lbl_Producto)
        Me.Controls.Add(Me.Lbl_Nombre_Etiqueta)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_ImpBarras_Preview"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Preview"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.Img_Etiqueta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Btn_imprimir_Archivo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem2 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem3 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Recargar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Lbl_Nombre_Etiqueta As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Producto As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Img_Etiqueta As PictureBox
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Pnl_Ancho As Panel
    Friend WithEvents Pnl_Alto As Panel
End Class
