<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Zw_Inv_Sector
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Zw_Inv_Sector))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_Zonas = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Ver_Despacho = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Accion_Confirmar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Accion_Preparar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Accion_Despachar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Accion_Cerrar = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Crear_Zona = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Editar_Zona = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Eliminar_Zona = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Cmb_Bodegas = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.ContextMenuBar1)
        Me.GroupPanel1.Controls.Add(Me.Grilla)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 41)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(708, 405)
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
        Me.GroupPanel1.Text = "Zonas"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_Zonas})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(31, 37)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(480, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 48
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_Zonas
        '
        Me.Menu_Contextual_Zonas.AutoExpandOnClick = True
        Me.Menu_Contextual_Zonas.Name = "Menu_Contextual_Zonas"
        Me.Menu_Contextual_Zonas.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Ver_Despacho, Me.Btn_Accion_Confirmar, Me.Btn_Accion_Preparar, Me.Btn_Accion_Despachar, Me.Btn_Accion_Cerrar})
        Me.Menu_Contextual_Zonas.Text = "Opciones Despacho"
        '
        'Btn_Ver_Despacho
        '
        Me.Btn_Ver_Despacho.Image = CType(resources.GetObject("Btn_Ver_Despacho.Image"), System.Drawing.Image)
        Me.Btn_Ver_Despacho.Name = "Btn_Ver_Despacho"
        Me.Btn_Ver_Despacho.Text = "Asociar ubcaciones"
        Me.Btn_Ver_Despacho.Tooltip = "Dar "
        '
        'Btn_Accion_Confirmar
        '
        Me.Btn_Accion_Confirmar.Image = CType(resources.GetObject("Btn_Accion_Confirmar.Image"), System.Drawing.Image)
        Me.Btn_Accion_Confirmar.Name = "Btn_Accion_Confirmar"
        Me.Btn_Accion_Confirmar.Text = "CONFIRMAR "
        Me.Btn_Accion_Confirmar.Tooltip = "Dar "
        '
        'Btn_Accion_Preparar
        '
        Me.Btn_Accion_Preparar.Image = CType(resources.GetObject("Btn_Accion_Preparar.Image"), System.Drawing.Image)
        Me.Btn_Accion_Preparar.Name = "Btn_Accion_Preparar"
        Me.Btn_Accion_Preparar.Text = "PREPARAR"
        Me.Btn_Accion_Preparar.Tooltip = "Preparar pedido, armar bulto"
        '
        'Btn_Accion_Despachar
        '
        Me.Btn_Accion_Despachar.Image = CType(resources.GetObject("Btn_Accion_Despachar.Image"), System.Drawing.Image)
        Me.Btn_Accion_Despachar.Name = "Btn_Accion_Despachar"
        Me.Btn_Accion_Despachar.Text = "DESPACHAR"
        Me.Btn_Accion_Despachar.Tooltip = "Despachar bultos, entregar al cliente o transportista"
        '
        'Btn_Accion_Cerrar
        '
        Me.Btn_Accion_Cerrar.Image = CType(resources.GetObject("Btn_Accion_Cerrar.Image"), System.Drawing.Image)
        Me.Btn_Accion_Cerrar.Name = "Btn_Accion_Cerrar"
        Me.Btn_Accion_Cerrar.Text = "CERRAR"
        Me.Btn_Accion_Cerrar.Tooltip = "Cerrar orden, insertar Nro. de encomienda"
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
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
        Me.Grilla.Size = New System.Drawing.Size(702, 382)
        Me.Grilla.StandardTab = True
        Me.Grilla.TabIndex = 30
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Crear_Zona, Me.Btn_Editar_Zona, Me.Btn_Eliminar_Zona})
        Me.Bar1.Location = New System.Drawing.Point(0, 459)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(732, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 32
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Crear_Zona
        '
        Me.Btn_Crear_Zona.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Crear_Zona.ForeColor = System.Drawing.Color.Black
        Me.Btn_Crear_Zona.Image = CType(resources.GetObject("Btn_Crear_Zona.Image"), System.Drawing.Image)
        Me.Btn_Crear_Zona.Name = "Btn_Crear_Zona"
        Me.Btn_Crear_Zona.Tooltip = "Crear Inventario"
        '
        'Btn_Editar_Zona
        '
        Me.Btn_Editar_Zona.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Editar_Zona.ForeColor = System.Drawing.Color.Black
        Me.Btn_Editar_Zona.Image = CType(resources.GetObject("Btn_Editar_Zona.Image"), System.Drawing.Image)
        Me.Btn_Editar_Zona.Name = "Btn_Editar_Zona"
        Me.Btn_Editar_Zona.Tooltip = "Crear Zona"
        '
        'Btn_Eliminar_Zona
        '
        Me.Btn_Eliminar_Zona.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Eliminar_Zona.ForeColor = System.Drawing.Color.Black
        Me.Btn_Eliminar_Zona.Image = CType(resources.GetObject("Btn_Eliminar_Zona.Image"), System.Drawing.Image)
        Me.Btn_Eliminar_Zona.Name = "Btn_Eliminar_Zona"
        Me.Btn_Eliminar_Zona.Tooltip = "Crear Zona"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(15, 12)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(45, 23)
        Me.LabelX1.TabIndex = 34
        Me.LabelX1.Text = "Bodega"
        '
        'Cmb_Bodegas
        '
        Me.Cmb_Bodegas.DisplayMember = "Text"
        Me.Cmb_Bodegas.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Bodegas.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Bodegas.FormattingEnabled = True
        Me.Cmb_Bodegas.ItemHeight = 16
        Me.Cmb_Bodegas.Location = New System.Drawing.Point(66, 13)
        Me.Cmb_Bodegas.Name = "Cmb_Bodegas"
        Me.Cmb_Bodegas.Size = New System.Drawing.Size(654, 22)
        Me.Cmb_Bodegas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Bodegas.TabIndex = 35
        '
        'Zw_Inv_Sector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(732, 500)
        Me.Controls.Add(Me.Cmb_Bodegas)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Zw_Inv_Sector"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Crear_Zona As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Editar_Zona As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Eliminar_Zona As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Cmb_Bodegas As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_Zonas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Ver_Despacho As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Accion_Confirmar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Accion_Preparar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Accion_Despachar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Accion_Cerrar As DevComponents.DotNetBar.ButtonItem
End Class
