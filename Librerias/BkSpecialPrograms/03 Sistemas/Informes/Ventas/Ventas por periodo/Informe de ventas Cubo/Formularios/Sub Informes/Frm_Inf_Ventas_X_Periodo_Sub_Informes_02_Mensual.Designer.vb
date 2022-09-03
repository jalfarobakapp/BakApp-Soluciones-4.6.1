<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Inf_Ventas_X_Periodo_Sub_Informes_02_Mensual
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Inf_Ventas_X_Periodo_Sub_Informes_02_Mensual))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_Informe = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Informe_X_Bodega = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Informe_X_Super_Familia = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Informe_X_Entidades = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Informe_X_Ciudades = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Informe_X_Comunas = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Informe_X_Productos_Consolidados = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Informe_X_Funcionarios = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Informe_X_Documentos_Entidades = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Informe_X_Productos = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_Filtros = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem3 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Filtro_Productos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Entidades = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Funcionarios = New DevComponents.DotNetBar.ButtonItem()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Excel = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtrar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Cambiar_Fechas = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Graficar = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.GroupPanel2.Location = New System.Drawing.Point(12, 6)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(735, 406)
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
        Me.GroupPanel2.TabIndex = 121
        Me.GroupPanel2.Text = "Documentos"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_Informe, Me.Menu_Contextual_Filtros})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(80, 152)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(512, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 97
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_Informe
        '
        Me.Menu_Contextual_Informe.AutoExpandOnClick = True
        Me.Menu_Contextual_Informe.Name = "Menu_Contextual_Informe"
        Me.Menu_Contextual_Informe.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem2, Me.Btn_Informe_X_Bodega, Me.Btn_Informe_X_Super_Familia, Me.Btn_Informe_X_Entidades, Me.Btn_Informe_X_Ciudades, Me.Btn_Informe_X_Comunas, Me.Btn_Informe_X_Productos_Consolidados, Me.Btn_Informe_X_Funcionarios, Me.LabelItem1, Me.Btn_Informe_X_Documentos_Entidades, Me.Btn_Informe_X_Productos})
        Me.Menu_Contextual_Informe.Text = "Sub Informes Recepcion - Despacho"
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
        Me.LabelItem2.Text = "Informes Agrupados"
        '
        'Btn_Informe_X_Bodega
        '
        Me.Btn_Informe_X_Bodega.Image = CType(resources.GetObject("Btn_Informe_X_Bodega.Image"), System.Drawing.Image)
        Me.Btn_Informe_X_Bodega.Name = "Btn_Informe_X_Bodega"
        Me.Btn_Informe_X_Bodega.Text = "Ver informe por <b><font color=""#0072BC"">BODEGAS</font></b>"
        '
        'Btn_Informe_X_Super_Familia
        '
        Me.Btn_Informe_X_Super_Familia.Image = CType(resources.GetObject("Btn_Informe_X_Super_Familia.Image"), System.Drawing.Image)
        Me.Btn_Informe_X_Super_Familia.Name = "Btn_Informe_X_Super_Familia"
        Me.Btn_Informe_X_Super_Familia.Text = "Ver informe por <b><font color=""#4E5D30""><font color=""#ED1C24"">SUPER FAMILIAS</fo" &
    "nt></font></b>"
        '
        'Btn_Informe_X_Entidades
        '
        Me.Btn_Informe_X_Entidades.Image = CType(resources.GetObject("Btn_Informe_X_Entidades.Image"), System.Drawing.Image)
        Me.Btn_Informe_X_Entidades.Name = "Btn_Informe_X_Entidades"
        Me.Btn_Informe_X_Entidades.Text = "Ver informe por <b><font color=""#903C39"">ENTIDADES</font></b>"
        '
        'Btn_Informe_X_Ciudades
        '
        Me.Btn_Informe_X_Ciudades.Image = CType(resources.GetObject("Btn_Informe_X_Ciudades.Image"), System.Drawing.Image)
        Me.Btn_Informe_X_Ciudades.Name = "Btn_Informe_X_Ciudades"
        Me.Btn_Informe_X_Ciudades.Text = "Ver informe por <b><font color=""#0072BC"">CIUDADES (Entidad)</font></b>"
        '
        'Btn_Informe_X_Comunas
        '
        Me.Btn_Informe_X_Comunas.Image = CType(resources.GetObject("Btn_Informe_X_Comunas.Image"), System.Drawing.Image)
        Me.Btn_Informe_X_Comunas.Name = "Btn_Informe_X_Comunas"
        Me.Btn_Informe_X_Comunas.Text = "Ver informe por <b><font color=""#0072BC"">COMUNAS (Entidad)</font></b>"
        '
        'Btn_Informe_X_Productos_Consolidados
        '
        Me.Btn_Informe_X_Productos_Consolidados.Image = CType(resources.GetObject("Btn_Informe_X_Productos_Consolidados.Image"), System.Drawing.Image)
        Me.Btn_Informe_X_Productos_Consolidados.Name = "Btn_Informe_X_Productos_Consolidados"
        Me.Btn_Informe_X_Productos_Consolidados.Text = "Ver informe por <b><font color=""#0072BC"">PRODUCTOS (Consolidado)</font></b>"
        '
        'Btn_Informe_X_Funcionarios
        '
        Me.Btn_Informe_X_Funcionarios.Image = CType(resources.GetObject("Btn_Informe_X_Funcionarios.Image"), System.Drawing.Image)
        Me.Btn_Informe_X_Funcionarios.Name = "Btn_Informe_X_Funcionarios"
        Me.Btn_Informe_X_Funcionarios.Text = "Ver informe por <b><font color=""#903C39"">VENDEDORES</font></b>"
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
        Me.LabelItem1.Text = "Informe detallado"
        '
        'Btn_Informe_X_Documentos_Entidades
        '
        Me.Btn_Informe_X_Documentos_Entidades.Image = CType(resources.GetObject("Btn_Informe_X_Documentos_Entidades.Image"), System.Drawing.Image)
        Me.Btn_Informe_X_Documentos_Entidades.Name = "Btn_Informe_X_Documentos_Entidades"
        Me.Btn_Informe_X_Documentos_Entidades.Text = "Ver detalle de las <b><font color=""#22B14C"">Documentos -> Entidades</font></b>"
        '
        'Btn_Informe_X_Productos
        '
        Me.Btn_Informe_X_Productos.Image = CType(resources.GetObject("Btn_Informe_X_Productos.Image"), System.Drawing.Image)
        Me.Btn_Informe_X_Productos.Name = "Btn_Informe_X_Productos"
        Me.Btn_Informe_X_Productos.Text = "Ver detalle de los <b><font color=""#22B14C"">Productos->Detalle</font></b>"
        '
        'Menu_Contextual_Filtros
        '
        Me.Menu_Contextual_Filtros.AutoExpandOnClick = True
        Me.Menu_Contextual_Filtros.Name = "Menu_Contextual_Filtros"
        Me.Menu_Contextual_Filtros.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem3, Me.Btn_Filtro_Productos, Me.Btn_Filtro_Entidades, Me.Btn_Filtro_Funcionarios})
        Me.Menu_Contextual_Filtros.Text = "Filtros"
        '
        'LabelItem3
        '
        Me.LabelItem3.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem3.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem3.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem3.Name = "LabelItem3"
        Me.LabelItem3.PaddingBottom = 1
        Me.LabelItem3.PaddingLeft = 10
        Me.LabelItem3.PaddingTop = 1
        Me.LabelItem3.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem3.Text = "Productos"
        '
        'Btn_Filtro_Productos
        '
        Me.Btn_Filtro_Productos.Image = CType(resources.GetObject("Btn_Filtro_Productos.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Productos.Name = "Btn_Filtro_Productos"
        Me.Btn_Filtro_Productos.Text = "Filtrar por <b><font color=""#0072BC"">PRODUCTOS</font></b>"
        '
        'Btn_Filtro_Entidades
        '
        Me.Btn_Filtro_Entidades.Image = CType(resources.GetObject("Btn_Filtro_Entidades.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Entidades.Name = "Btn_Filtro_Entidades"
        Me.Btn_Filtro_Entidades.Text = "Filtrar por <b><font color=""#4E5D30""><font color=""#ED1C24"">ENTIDADES</font></font" &
    "></b>"
        '
        'Btn_Filtro_Funcionarios
        '
        Me.Btn_Filtro_Funcionarios.Image = CType(resources.GetObject("Btn_Filtro_Funcionarios.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Funcionarios.Name = "Btn_Filtro_Funcionarios"
        Me.Btn_Filtro_Funcionarios.Text = "Filtrar por <b><font color=""#903C39"">FUNCIONARIOS</font></b>"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Excel, Me.Btn_Filtrar, Me.Btn_Cambiar_Fechas, Me.Btn_Graficar})
        Me.Bar1.Location = New System.Drawing.Point(0, 427)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(754, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 120
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Excel
        '
        Me.Btn_Excel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Excel.ForeColor = System.Drawing.Color.Black
        Me.Btn_Excel.Image = CType(resources.GetObject("Btn_Excel.Image"), System.Drawing.Image)
        Me.Btn_Excel.Name = "Btn_Excel"
        Me.Btn_Excel.Tooltip = "Exportar a Excel"
        '
        'Btn_Filtrar
        '
        Me.Btn_Filtrar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Filtrar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Filtrar.Image = CType(resources.GetObject("Btn_Filtrar.Image"), System.Drawing.Image)
        Me.Btn_Filtrar.Name = "Btn_Filtrar"
        Me.Btn_Filtrar.Text = "Filtrar datos"
        '
        'Btn_Cambiar_Fechas
        '
        Me.Btn_Cambiar_Fechas.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Cambiar_Fechas.ForeColor = System.Drawing.Color.Black
        Me.Btn_Cambiar_Fechas.Image = CType(resources.GetObject("Btn_Cambiar_Fechas.Image"), System.Drawing.Image)
        Me.Btn_Cambiar_Fechas.Name = "Btn_Cambiar_Fechas"
        Me.Btn_Cambiar_Fechas.Text = "Cambiar fechas"
        '
        'Btn_Graficar
        '
        Me.Btn_Graficar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Graficar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Graficar.Image = CType(resources.GetObject("Btn_Graficar.Image"), System.Drawing.Image)
        Me.Btn_Graficar.Name = "Btn_Graficar"
        Me.Btn_Graficar.Text = "Graficar"
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
        Me.Grilla.Size = New System.Drawing.Size(729, 383)
        Me.Grilla.TabIndex = 123
        '
        'Frm_Inf_Ventas_X_Periodo_Sub_Informes_02_Mensual
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(754, 468)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "Frm_Inf_Ventas_X_Periodo_Sub_Informes_02_Mensual"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Excel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_Informe As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Public WithEvents Btn_Informe_X_Bodega As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Informe_X_Super_Familia As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Informe_X_Entidades As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Informe_X_Ciudades As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Informe_X_Comunas As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Informe_X_Productos_Consolidados As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Informe_X_Funcionarios As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Informe_X_Documentos_Entidades As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Informe_X_Productos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Menu_Contextual_Filtros As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem3 As DevComponents.DotNetBar.LabelItem
    Public WithEvents Btn_Filtro_Productos As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Entidades As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Funcionarios As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Filtrar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Cambiar_Fechas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Graficar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
End Class
