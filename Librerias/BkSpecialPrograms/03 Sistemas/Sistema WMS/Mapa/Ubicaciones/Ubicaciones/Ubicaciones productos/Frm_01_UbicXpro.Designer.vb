<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_01_UbicXpro
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_01_UbicXpro))
        Me.Highlighter1 = New DevComponents.DotNetBar.Validator.Highlighter()
        Me.TxtDescripcion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.BtnAgregarUbicXProdDirecto = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnAgregarUbicXProdBuscar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Pr_Estadistica_Producto = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_Ubicacion = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Mnu_Ubicacion_X_Defecto = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Ver_Sector = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Ver_Sector_En_Mapa = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Eliminar_Ubicacion = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Imprimir_Ubicacion = New DevComponents.DotNetBar.ButtonItem()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Highlighter1
        '
        Me.Highlighter1.ContainerControl = Me
        Me.Highlighter1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtDescripcion.Border.Class = "TextBoxBorder"
        Me.TxtDescripcion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtDescripcion.DisabledBackColor = System.Drawing.Color.White
        Me.TxtDescripcion.FocusHighlightEnabled = True
        Me.TxtDescripcion.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightColor(Me.TxtDescripcion, DevComponents.DotNetBar.Validator.eHighlightColor.Red)
        Me.TxtDescripcion.Location = New System.Drawing.Point(15, 25)
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.PreventEnterBeep = True
        Me.TxtDescripcion.ReadOnly = True
        Me.TxtDescripcion.Size = New System.Drawing.Size(767, 22)
        Me.TxtDescripcion.TabIndex = 36
        Me.TxtDescripcion.WatermarkText = "Máximo 48 caracteres "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Descripción"
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
        Me.Grilla.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Grilla.RowHeadersVisible = False
        Me.Grilla.Size = New System.Drawing.Size(761, 234)
        Me.Grilla.TabIndex = 13
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnAgregarUbicXProdDirecto, Me.BtnAgregarUbicXProdBuscar, Me.Btn_Mnu_Pr_Estadistica_Producto})
        Me.Bar1.Location = New System.Drawing.Point(0, 316)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(794, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 38
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnAgregarUbicXProdDirecto
        '
        Me.BtnAgregarUbicXProdDirecto.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnAgregarUbicXProdDirecto.ForeColor = System.Drawing.Color.Black
        Me.BtnAgregarUbicXProdDirecto.Image = CType(resources.GetObject("BtnAgregarUbicXProdDirecto.Image"), System.Drawing.Image)
        Me.BtnAgregarUbicXProdDirecto.Name = "BtnAgregarUbicXProdDirecto"
        Me.BtnAgregarUbicXProdDirecto.Text = "Agregar ubicación (F2)"
        Me.BtnAgregarUbicXProdDirecto.Tooltip = "Limpiar grilla"
        '
        'BtnAgregarUbicXProdBuscar
        '
        Me.BtnAgregarUbicXProdBuscar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnAgregarUbicXProdBuscar.ForeColor = System.Drawing.Color.Black
        Me.BtnAgregarUbicXProdBuscar.Image = CType(resources.GetObject("BtnAgregarUbicXProdBuscar.Image"), System.Drawing.Image)
        Me.BtnAgregarUbicXProdBuscar.Name = "BtnAgregarUbicXProdBuscar"
        Me.BtnAgregarUbicXProdBuscar.Text = "Agregar ubicación (Buscar F3)"
        Me.BtnAgregarUbicXProdBuscar.Tooltip = "Limpiar grilla"
        '
        'Btn_Mnu_Pr_Estadistica_Producto
        '
        Me.Btn_Mnu_Pr_Estadistica_Producto.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Mnu_Pr_Estadistica_Producto.ForeColor = System.Drawing.Color.Black
        Me.Btn_Mnu_Pr_Estadistica_Producto.Image = CType(resources.GetObject("Btn_Mnu_Pr_Estadistica_Producto.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Pr_Estadistica_Producto.ImageAlt = CType(resources.GetObject("Btn_Mnu_Pr_Estadistica_Producto.ImageAlt"), System.Drawing.Image)
        Me.Btn_Mnu_Pr_Estadistica_Producto.Name = "Btn_Mnu_Pr_Estadistica_Producto"
        Me.Btn_Mnu_Pr_Estadistica_Producto.Tooltip = "Ver estadísticas del producto/información adicional"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.ContextMenuBar1)
        Me.GroupPanel1.Controls.Add(Me.Grilla)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(15, 53)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(767, 257)
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
        Me.GroupPanel1.TabIndex = 39
        Me.GroupPanel1.Text = "Ubicaciones del producto"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_Ubicacion})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(135, 54)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(222, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 49
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_Ubicacion
        '
        Me.Menu_Contextual_Ubicacion.AutoExpandOnClick = True
        Me.Menu_Contextual_Ubicacion.Name = "Menu_Contextual_Ubicacion"
        Me.Menu_Contextual_Ubicacion.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1, Me.Btn_Mnu_Ubicacion_X_Defecto, Me.Btn_Mnu_Ver_Sector, Me.Btn_Mnu_Ver_Sector_En_Mapa, Me.Btn_Mnu_Eliminar_Ubicacion, Me.Btn_Imprimir_Ubicacion})
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
        'Btn_Mnu_Ubicacion_X_Defecto
        '
        Me.Btn_Mnu_Ubicacion_X_Defecto.Image = CType(resources.GetObject("Btn_Mnu_Ubicacion_X_Defecto.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Ubicacion_X_Defecto.Name = "Btn_Mnu_Ubicacion_X_Defecto"
        Me.Btn_Mnu_Ubicacion_X_Defecto.Text = "Asignar ubicación por defector"
        '
        'Btn_Mnu_Ver_Sector
        '
        Me.Btn_Mnu_Ver_Sector.Image = CType(resources.GetObject("Btn_Mnu_Ver_Sector.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Ver_Sector.Name = "Btn_Mnu_Ver_Sector"
        Me.Btn_Mnu_Ver_Sector.Text = "Ver Sector (Estantería)"
        '
        'Btn_Mnu_Ver_Sector_En_Mapa
        '
        Me.Btn_Mnu_Ver_Sector_En_Mapa.Image = CType(resources.GetObject("Btn_Mnu_Ver_Sector_En_Mapa.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Ver_Sector_En_Mapa.Name = "Btn_Mnu_Ver_Sector_En_Mapa"
        Me.Btn_Mnu_Ver_Sector_En_Mapa.Text = "Ver el sector en el mapa"
        '
        'Btn_Mnu_Eliminar_Ubicacion
        '
        Me.Btn_Mnu_Eliminar_Ubicacion.ForeColor = System.Drawing.Color.Red
        Me.Btn_Mnu_Eliminar_Ubicacion.Image = CType(resources.GetObject("Btn_Mnu_Eliminar_Ubicacion.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Eliminar_Ubicacion.Name = "Btn_Mnu_Eliminar_Ubicacion"
        Me.Btn_Mnu_Eliminar_Ubicacion.Text = "Quitar producto de esta ubicacion"
        '
        'Btn_Imprimir_Ubicacion
        '
        Me.Btn_Imprimir_Ubicacion.Image = CType(resources.GetObject("Btn_Imprimir_Ubicacion.Image"), System.Drawing.Image)
        Me.Btn_Imprimir_Ubicacion.Name = "Btn_Imprimir_Ubicacion"
        Me.Btn_Imprimir_Ubicacion.Text = "Imprimir etiqueta"
        '
        'Frm_01_UbicXpro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(794, 357)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.TxtDescripcion)
        Me.Controls.Add(Me.Label2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_01_UbicXpro"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ubicación de producto"
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Highlighter1 As DevComponents.DotNetBar.Validator.Highlighter
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents TxtDescripcion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Public WithEvents BtnAgregarUbicXProdBuscar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents BtnAgregarUbicXProdDirecto As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_Ubicacion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Mnu_Ubicacion_X_Defecto As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_Ver_Sector As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_Ver_Sector_En_Mapa As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_Eliminar_Ubicacion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Imprimir_Ubicacion As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Mnu_Pr_Estadistica_Producto As DevComponents.DotNetBar.ButtonItem
End Class
