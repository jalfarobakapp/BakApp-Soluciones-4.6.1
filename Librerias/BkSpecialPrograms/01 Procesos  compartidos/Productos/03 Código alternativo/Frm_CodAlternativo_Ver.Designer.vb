<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_CodAlternativo_Ver
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_CodAlternativo_Ver))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtRTU = New System.Windows.Forms.TextBox()
        Me.TxtCodigo = New System.Windows.Forms.TextBox()
        Me.Txtdescripcion = New System.Windows.Forms.TextBox()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.BtnAgregarCodAlternativos = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnAgregarCodBarra = New DevComponents.DotNetBar.ButtonItem()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Mnu_BtnEditarDescripProducto = New System.Windows.Forms.ToolStripMenuItem()
        Me.Mnu_BtnEliminarLinea = New System.Windows.Forms.ToolStripMenuItem()
        Me.TxtDescripcion_Proveedor = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GrillAlternativos = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_Permisos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Editar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Ver_Usuario_Con_Este_Permiso = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Chk_Lect_Barras_IngrxCantidad = New DevComponents.DotNetBar.Controls.CheckBoxX()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.GrillAlternativos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(580, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "R.T.U."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(130, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Descripción"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(3, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Código"
        '
        'TxtRTU
        '
        Me.TxtRTU.BackColor = System.Drawing.Color.White
        Me.TxtRTU.ForeColor = System.Drawing.Color.Black
        Me.TxtRTU.Location = New System.Drawing.Point(583, 28)
        Me.TxtRTU.Name = "TxtRTU"
        Me.TxtRTU.ReadOnly = True
        Me.TxtRTU.Size = New System.Drawing.Size(60, 22)
        Me.TxtRTU.TabIndex = 2
        '
        'TxtCodigo
        '
        Me.TxtCodigo.BackColor = System.Drawing.Color.White
        Me.TxtCodigo.ForeColor = System.Drawing.Color.Black
        Me.TxtCodigo.Location = New System.Drawing.Point(6, 28)
        Me.TxtCodigo.Name = "TxtCodigo"
        Me.TxtCodigo.ReadOnly = True
        Me.TxtCodigo.Size = New System.Drawing.Size(120, 22)
        Me.TxtCodigo.TabIndex = 0
        '
        'Txtdescripcion
        '
        Me.Txtdescripcion.BackColor = System.Drawing.Color.White
        Me.Txtdescripcion.ForeColor = System.Drawing.Color.Black
        Me.Txtdescripcion.Location = New System.Drawing.Point(133, 28)
        Me.Txtdescripcion.Name = "Txtdescripcion"
        Me.Txtdescripcion.ReadOnly = True
        Me.Txtdescripcion.Size = New System.Drawing.Size(444, 22)
        Me.Txtdescripcion.TabIndex = 0
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnAgregarCodAlternativos, Me.BtnAgregarCodBarra})
        Me.Bar1.Location = New System.Drawing.Point(0, 397)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(662, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 31
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnAgregarCodAlternativos
        '
        Me.BtnAgregarCodAlternativos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnAgregarCodAlternativos.ForeColor = System.Drawing.Color.Black
        Me.BtnAgregarCodAlternativos.Image = CType(resources.GetObject("BtnAgregarCodAlternativos.Image"), System.Drawing.Image)
        Me.BtnAgregarCodAlternativos.ImageAlt = CType(resources.GetObject("BtnAgregarCodAlternativos.ImageAlt"), System.Drawing.Image)
        Me.BtnAgregarCodAlternativos.Name = "BtnAgregarCodAlternativos"
        Me.BtnAgregarCodAlternativos.Text = "Agregar código altenativo"
        Me.BtnAgregarCodAlternativos.Tooltip = "Agregar código altenativo de un proveedor"
        '
        'BtnAgregarCodBarra
        '
        Me.BtnAgregarCodBarra.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnAgregarCodBarra.ForeColor = System.Drawing.Color.Black
        Me.BtnAgregarCodBarra.Image = CType(resources.GetObject("BtnAgregarCodBarra.Image"), System.Drawing.Image)
        Me.BtnAgregarCodBarra.ImageAlt = CType(resources.GetObject("BtnAgregarCodBarra.ImageAlt"), System.Drawing.Image)
        Me.BtnAgregarCodBarra.Name = "BtnAgregarCodBarra"
        Me.BtnAgregarCodBarra.Text = "Agregar código de barras (F2)"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Mnu_BtnEditarDescripProducto, Me.Mnu_BtnEliminarLinea})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(240, 48)
        Me.ContextMenuStrip1.Text = "Sub Menu productos"
        '
        'Mnu_BtnEditarDescripProducto
        '
        Me.Mnu_BtnEditarDescripProducto.Image = CType(resources.GetObject("Mnu_BtnEditarDescripProducto.Image"), System.Drawing.Image)
        Me.Mnu_BtnEditarDescripProducto.Name = "Mnu_BtnEditarDescripProducto"
        Me.Mnu_BtnEditarDescripProducto.Size = New System.Drawing.Size(239, 22)
        Me.Mnu_BtnEditarDescripProducto.Text = "Editar descripción del producto"
        '
        'Mnu_BtnEliminarLinea
        '
        Me.Mnu_BtnEliminarLinea.Image = Global.BkSpecialPrograms.My.Resources.Resources.delete2
        Me.Mnu_BtnEliminarLinea.Name = "Mnu_BtnEliminarLinea"
        Me.Mnu_BtnEliminarLinea.Size = New System.Drawing.Size(239, 22)
        Me.Mnu_BtnEliminarLinea.Text = "Eliminar línea"
        '
        'TxtDescripcion_Proveedor
        '
        Me.TxtDescripcion_Proveedor.BackColor = System.Drawing.Color.White
        Me.TxtDescripcion_Proveedor.ForeColor = System.Drawing.Color.Black
        Me.TxtDescripcion_Proveedor.Location = New System.Drawing.Point(154, 337)
        Me.TxtDescripcion_Proveedor.Name = "TxtDescripcion_Proveedor"
        Me.TxtDescripcion_Proveedor.ReadOnly = True
        Me.TxtDescripcion_Proveedor.Size = New System.Drawing.Size(498, 22)
        Me.TxtDescripcion_Proveedor.TabIndex = 34
        Me.TxtDescripcion_Proveedor.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(3, 340)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(145, 13)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "Descripción del proveedor:"
        '
        'GrillAlternativos
        '
        Me.GrillAlternativos.AllowUserToAddRows = False
        Me.GrillAlternativos.AllowUserToOrderColumns = True
        Me.GrillAlternativos.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GrillAlternativos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.GrillAlternativos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GrillAlternativos.DefaultCellStyle = DataGridViewCellStyle5
        Me.GrillAlternativos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrillAlternativos.EnableHeadersVisualStyles = False
        Me.GrillAlternativos.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.GrillAlternativos.Location = New System.Drawing.Point(0, 0)
        Me.GrillAlternativos.Name = "GrillAlternativos"
        Me.GrillAlternativos.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GrillAlternativos.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.GrillAlternativos.RowHeadersVisible = False
        Me.GrillAlternativos.RowTemplate.Height = 25
        Me.GrillAlternativos.Size = New System.Drawing.Size(643, 213)
        Me.GrillAlternativos.TabIndex = 55
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.ContextMenuBar1)
        Me.GroupPanel1.Controls.Add(Me.GrillAlternativos)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(6, 95)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(649, 236)
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
        Me.GroupPanel1.TabIndex = 56
        Me.GroupPanel1.Text = "Código de barras asociados al producto"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_Permisos})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(168, 94)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(306, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 56
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_Permisos
        '
        Me.Menu_Contextual_Permisos.AutoExpandOnClick = True
        Me.Menu_Contextual_Permisos.Name = "Menu_Contextual_Permisos"
        Me.Menu_Contextual_Permisos.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Editar, Me.Btn_Ver_Usuario_Con_Este_Permiso})
        Me.Menu_Contextual_Permisos.Text = "Opciones productos"
        '
        'Btn_Editar
        '
        Me.Btn_Editar.Image = CType(resources.GetObject("Btn_Editar.Image"), System.Drawing.Image)
        Me.Btn_Editar.ImageAlt = CType(resources.GetObject("Btn_Editar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Editar.Name = "Btn_Editar"
        Me.Btn_Editar.Text = "Editar"
        '
        'Btn_Ver_Usuario_Con_Este_Permiso
        '
        Me.Btn_Ver_Usuario_Con_Este_Permiso.Image = CType(resources.GetObject("Btn_Ver_Usuario_Con_Este_Permiso.Image"), System.Drawing.Image)
        Me.Btn_Ver_Usuario_Con_Este_Permiso.ImageAlt = CType(resources.GetObject("Btn_Ver_Usuario_Con_Este_Permiso.ImageAlt"), System.Drawing.Image)
        Me.Btn_Ver_Usuario_Con_Este_Permiso.Name = "Btn_Ver_Usuario_Con_Este_Permiso"
        Me.Btn_Ver_Usuario_Con_Este_Permiso.Text = "Eliminar"
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Label3)
        Me.GroupPanel2.Controls.Add(Me.Label1)
        Me.GroupPanel2.Controls.Add(Me.Label2)
        Me.GroupPanel2.Controls.Add(Me.Txtdescripcion)
        Me.GroupPanel2.Controls.Add(Me.TxtCodigo)
        Me.GroupPanel2.Controls.Add(Me.TxtRTU)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(6, 12)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(649, 83)
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
        Me.GroupPanel2.TabIndex = 57
        Me.GroupPanel2.Text = "Producto"
        '
        'Chk_Lect_Barras_IngrxCantidad
        '
        Me.Chk_Lect_Barras_IngrxCantidad.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Lect_Barras_IngrxCantidad.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Lect_Barras_IngrxCantidad.ForeColor = System.Drawing.Color.Black
        Me.Chk_Lect_Barras_IngrxCantidad.Location = New System.Drawing.Point(6, 368)
        Me.Chk_Lect_Barras_IngrxCantidad.Name = "Chk_Lect_Barras_IngrxCantidad"
        Me.Chk_Lect_Barras_IngrxCantidad.Size = New System.Drawing.Size(416, 23)
        Me.Chk_Lect_Barras_IngrxCantidad.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Lect_Barras_IngrxCantidad.TabIndex = 58
        Me.Chk_Lect_Barras_IngrxCantidad.Text = "Ingresar cantidades al leer código de barras en despacho/recepción"
        '
        'Frm_CodAlternativo_Ver
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(662, 438)
        Me.Controls.Add(Me.Chk_Lect_Barras_IngrxCantidad)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.TxtDescripcion_Proveedor)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_CodAlternativo_Ver"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asociar código alternativo"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.GrillAlternativos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        Me.GroupPanel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents TxtRTU As System.Windows.Forms.TextBox
    Public WithEvents TxtCodigo As System.Windows.Forms.TextBox
    Public WithEvents Txtdescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnAgregarCodAlternativos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents TxtDescripcion_Proveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Mnu_BtnEditarDescripProducto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Mnu_BtnEliminarLinea As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnAgregarCodBarra As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GrillAlternativos As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Chk_Lect_Barras_IngrxCantidad As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_Permisos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Editar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Ver_Usuario_Con_Este_Permiso As DevComponents.DotNetBar.ButtonItem
End Class
