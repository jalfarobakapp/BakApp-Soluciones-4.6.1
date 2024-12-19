<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Informe_Prox_Recep_Y_Comp_No_Desp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Informe_Prox_Recep_Y_Comp_No_Desp))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Grupo_Venta_Diaria = New DevComponents.DotNetBar.Controls.GroupPanel()
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
        Me.Btn_Informe_X_Entidad_Documentos_Productos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Informe_X_Documentos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Informe_X_Productos = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Excel = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Imprimir = New DevComponents.DotNetBar.ButtonItem()
        Me.Grupo_Venta_Diaria.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Grupo_Venta_Diaria
        '
        Me.Grupo_Venta_Diaria.BackColor = System.Drawing.Color.White
        Me.Grupo_Venta_Diaria.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Venta_Diaria.Controls.Add(Me.ContextMenuBar1)
        Me.Grupo_Venta_Diaria.Controls.Add(Me.Grilla)
        Me.Grupo_Venta_Diaria.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Venta_Diaria.Location = New System.Drawing.Point(12, 3)
        Me.Grupo_Venta_Diaria.Name = "Grupo_Venta_Diaria"
        Me.Grupo_Venta_Diaria.Size = New System.Drawing.Size(750, 462)
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
        Me.Grupo_Venta_Diaria.TabIndex = 103
        Me.Grupo_Venta_Diaria.Text = "Detalle del informe"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_Informe})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(252, 104)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(280, 25)
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
        Me.Menu_Contextual_Informe.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem2, Me.Btn_Informe_X_Bodega, Me.Btn_Informe_X_Super_Familia, Me.Btn_Informe_X_Entidades, Me.Btn_Informe_X_Ciudades, Me.Btn_Informe_X_Comunas, Me.Btn_Informe_X_Productos_Consolidados, Me.Btn_Informe_X_Funcionarios, Me.LabelItem1, Me.Btn_Informe_X_Entidad_Documentos_Productos, Me.Btn_Informe_X_Documentos, Me.Btn_Informe_X_Productos})
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
        Me.Btn_Informe_X_Bodega.ImageAlt = CType(resources.GetObject("Btn_Informe_X_Bodega.ImageAlt"), System.Drawing.Image)
        Me.Btn_Informe_X_Bodega.Name = "Btn_Informe_X_Bodega"
        Me.Btn_Informe_X_Bodega.Text = "Ver informe por <b><font color=""#0072BC"">BODEGAS</font></b>"
        '
        'Btn_Informe_X_Super_Familia
        '
        Me.Btn_Informe_X_Super_Familia.Image = CType(resources.GetObject("Btn_Informe_X_Super_Familia.Image"), System.Drawing.Image)
        Me.Btn_Informe_X_Super_Familia.ImageAlt = CType(resources.GetObject("Btn_Informe_X_Super_Familia.ImageAlt"), System.Drawing.Image)
        Me.Btn_Informe_X_Super_Familia.Name = "Btn_Informe_X_Super_Familia"
        Me.Btn_Informe_X_Super_Familia.Text = "Ver informe por <b><font color=""#4E5D30""><font color=""#ED1C24"">SUPER FAMILIAS</fo" &
    "nt></font></b>"
        '
        'Btn_Informe_X_Entidades
        '
        Me.Btn_Informe_X_Entidades.Image = CType(resources.GetObject("Btn_Informe_X_Entidades.Image"), System.Drawing.Image)
        Me.Btn_Informe_X_Entidades.ImageAlt = CType(resources.GetObject("Btn_Informe_X_Entidades.ImageAlt"), System.Drawing.Image)
        Me.Btn_Informe_X_Entidades.Name = "Btn_Informe_X_Entidades"
        Me.Btn_Informe_X_Entidades.Text = "Ver informe por <b><font color=""#903C39"">ENTIDADES</font></b>"
        '
        'Btn_Informe_X_Ciudades
        '
        Me.Btn_Informe_X_Ciudades.Image = CType(resources.GetObject("Btn_Informe_X_Ciudades.Image"), System.Drawing.Image)
        Me.Btn_Informe_X_Ciudades.ImageAlt = CType(resources.GetObject("Btn_Informe_X_Ciudades.ImageAlt"), System.Drawing.Image)
        Me.Btn_Informe_X_Ciudades.Name = "Btn_Informe_X_Ciudades"
        Me.Btn_Informe_X_Ciudades.Text = "Ver informe por <b><font color=""#0072BC"">CIUDADES (Entidad)</font></b>"
        '
        'Btn_Informe_X_Comunas
        '
        Me.Btn_Informe_X_Comunas.Image = CType(resources.GetObject("Btn_Informe_X_Comunas.Image"), System.Drawing.Image)
        Me.Btn_Informe_X_Comunas.ImageAlt = CType(resources.GetObject("Btn_Informe_X_Comunas.ImageAlt"), System.Drawing.Image)
        Me.Btn_Informe_X_Comunas.Name = "Btn_Informe_X_Comunas"
        Me.Btn_Informe_X_Comunas.Text = "Ver informe por <b><font color=""#0072BC"">COMUNAS (Entidad)</font></b>"
        '
        'Btn_Informe_X_Productos_Consolidados
        '
        Me.Btn_Informe_X_Productos_Consolidados.Image = CType(resources.GetObject("Btn_Informe_X_Productos_Consolidados.Image"), System.Drawing.Image)
        Me.Btn_Informe_X_Productos_Consolidados.ImageAlt = CType(resources.GetObject("Btn_Informe_X_Productos_Consolidados.ImageAlt"), System.Drawing.Image)
        Me.Btn_Informe_X_Productos_Consolidados.Name = "Btn_Informe_X_Productos_Consolidados"
        Me.Btn_Informe_X_Productos_Consolidados.Text = "Ver informe por <b><font color=""#0072BC"">PRODUCTOS (Consolidado)</font></b>"
        '
        'Btn_Informe_X_Funcionarios
        '
        Me.Btn_Informe_X_Funcionarios.Image = CType(resources.GetObject("Btn_Informe_X_Funcionarios.Image"), System.Drawing.Image)
        Me.Btn_Informe_X_Funcionarios.ImageAlt = CType(resources.GetObject("Btn_Informe_X_Funcionarios.ImageAlt"), System.Drawing.Image)
        Me.Btn_Informe_X_Funcionarios.Name = "Btn_Informe_X_Funcionarios"
        Me.Btn_Informe_X_Funcionarios.Text = "Ver informe por <b><font color=""#903C39"">FUNCIONARIOS</font></b>"
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
        'Btn_Informe_X_Entidad_Documentos_Productos
        '
        Me.Btn_Informe_X_Entidad_Documentos_Productos.Image = CType(resources.GetObject("Btn_Informe_X_Entidad_Documentos_Productos.Image"), System.Drawing.Image)
        Me.Btn_Informe_X_Entidad_Documentos_Productos.ImageAlt = CType(resources.GetObject("Btn_Informe_X_Entidad_Documentos_Productos.ImageAlt"), System.Drawing.Image)
        Me.Btn_Informe_X_Entidad_Documentos_Productos.Name = "Btn_Informe_X_Entidad_Documentos_Productos"
        Me.Btn_Informe_X_Entidad_Documentos_Productos.Text = "Ver detalle de los <b><font color=""#22B14C"">Entidades->Documentos->Productos</fon" &
    "t></b>"
        '
        'Btn_Informe_X_Documentos
        '
        Me.Btn_Informe_X_Documentos.Image = CType(resources.GetObject("Btn_Informe_X_Documentos.Image"), System.Drawing.Image)
        Me.Btn_Informe_X_Documentos.ImageAlt = CType(resources.GetObject("Btn_Informe_X_Documentos.ImageAlt"), System.Drawing.Image)
        Me.Btn_Informe_X_Documentos.Name = "Btn_Informe_X_Documentos"
        Me.Btn_Informe_X_Documentos.Text = "Ver detalle de los <b><font color=""#22B14C"">Documentos->Detalle</font></b>"
        '
        'Btn_Informe_X_Productos
        '
        Me.Btn_Informe_X_Productos.Image = CType(resources.GetObject("Btn_Informe_X_Productos.Image"), System.Drawing.Image)
        Me.Btn_Informe_X_Productos.ImageAlt = CType(resources.GetObject("Btn_Informe_X_Productos.ImageAlt"), System.Drawing.Image)
        Me.Btn_Informe_X_Productos.Name = "Btn_Informe_X_Productos"
        Me.Btn_Informe_X_Productos.Text = "Ver detalle de los <b><font color=""#22B14C"">Productos->Detalle</font></b>"
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
        Me.Grilla.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Grilla.RowHeadersVisible = False
        Me.Grilla.Size = New System.Drawing.Size(744, 439)
        Me.Grilla.TabIndex = 3
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Excel, Me.Btn_Imprimir})
        Me.Bar1.Location = New System.Drawing.Point(0, 471)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(771, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 102
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
        'Btn_Imprimir
        '
        Me.Btn_Imprimir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Imprimir.ForeColor = System.Drawing.Color.Black
        Me.Btn_Imprimir.Image = CType(resources.GetObject("Btn_Imprimir.Image"), System.Drawing.Image)
        Me.Btn_Imprimir.ImageAlt = CType(resources.GetObject("Btn_Imprimir.ImageAlt"), System.Drawing.Image)
        Me.Btn_Imprimir.Name = "Btn_Imprimir"
        Me.Btn_Imprimir.Tooltip = "Exportar a Excel"
        '
        'Frm_Informe_Prox_Recep_Y_Comp_No_Desp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(771, 512)
        Me.Controls.Add(Me.Grupo_Venta_Diaria)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Informe_Prox_Recep_Y_Comp_No_Desp"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Compromisos no despachados por Sucursal"
        Me.Grupo_Venta_Diaria.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Grupo_Venta_Diaria As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_Informe As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Public WithEvents Btn_Informe_X_Bodega As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Informe_X_Super_Familia As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Informe_X_Entidades As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Informe_X_Entidad_Documentos_Productos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Excel As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Informe_X_Productos_Consolidados As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Informe_X_Ciudades As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Informe_X_Comunas As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Informe_X_Funcionarios As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Informe_X_Productos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Informe_X_Documentos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Btn_Imprimir As DevComponents.DotNetBar.ButtonItem
End Class
