<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_MtCreaProd_01_IngBusqEspecial
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_MtCreaProd_01_IngBusqEspecial))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.BtnAsociaciones = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Asociaciones_Unicas = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Copiar_Arbol_Hijos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Agregar_Clas_Especial = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_VerArbol = New DevComponents.DotNetBar.ButtonItem()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtCodigo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtDescripcion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtCodigoGenericoMadre = New System.Windows.Forms.TextBox()
        Me.Highlighter1 = New DevComponents.DotNetBar.Validator.Highlighter()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_01 = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.Mnu_Btn_Editar_Clas_Especial = New DevComponents.DotNetBar.ButtonItem()
        Me.Mnu_Btn_Eliminar_Clas_Especial = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla_Clasificaciones = New DevComponents.DotNetBar.Controls.DataGridViewX()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla_Clasificaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnAsociaciones, Me.Btn_Asociaciones_Unicas, Me.Btn_Copiar_Arbol_Hijos, Me.Btn_Agregar_Clas_Especial, Me.Btn_VerArbol})
        Me.Bar1.Location = New System.Drawing.Point(0, 369)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(676, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 7
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnAsociaciones
        '
        Me.BtnAsociaciones.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnAsociaciones.FontBold = True
        Me.BtnAsociaciones.ForeColor = System.Drawing.Color.Black
        Me.BtnAsociaciones.Image = CType(resources.GetObject("BtnAsociaciones.Image"), System.Drawing.Image)
        Me.BtnAsociaciones.ImageAlt = CType(resources.GetObject("BtnAsociaciones.ImageAlt"), System.Drawing.Image)
        Me.BtnAsociaciones.Name = "BtnAsociaciones"
        Me.BtnAsociaciones.Tooltip = "Asociar clasificaciones dinámicas"
        '
        'Btn_Asociaciones_Unicas
        '
        Me.Btn_Asociaciones_Unicas.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Asociaciones_Unicas.FontBold = True
        Me.Btn_Asociaciones_Unicas.ForeColor = System.Drawing.Color.Navy
        Me.Btn_Asociaciones_Unicas.Image = CType(resources.GetObject("Btn_Asociaciones_Unicas.Image"), System.Drawing.Image)
        Me.Btn_Asociaciones_Unicas.ImageAlt = CType(resources.GetObject("Btn_Asociaciones_Unicas.ImageAlt"), System.Drawing.Image)
        Me.Btn_Asociaciones_Unicas.Name = "Btn_Asociaciones_Unicas"
        Me.Btn_Asociaciones_Unicas.Tooltip = "Asociar clasificaciones únicas"
        '
        'Btn_Copiar_Arbol_Hijos
        '
        Me.Btn_Copiar_Arbol_Hijos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Copiar_Arbol_Hijos.ForeColor = System.Drawing.Color.Black
        Me.Btn_Copiar_Arbol_Hijos.Image = CType(resources.GetObject("Btn_Copiar_Arbol_Hijos.Image"), System.Drawing.Image)
        Me.Btn_Copiar_Arbol_Hijos.ImageAlt = CType(resources.GetObject("Btn_Copiar_Arbol_Hijos.ImageAlt"), System.Drawing.Image)
        Me.Btn_Copiar_Arbol_Hijos.Name = "Btn_Copiar_Arbol_Hijos"
        Me.Btn_Copiar_Arbol_Hijos.Tooltip = "Clasificar otros productos igual que este (solo clasificaciones dinámicas)"
        '
        'Btn_Agregar_Clas_Especial
        '
        Me.Btn_Agregar_Clas_Especial.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Agregar_Clas_Especial.FontBold = True
        Me.Btn_Agregar_Clas_Especial.ForeColor = System.Drawing.Color.Navy
        Me.Btn_Agregar_Clas_Especial.Image = CType(resources.GetObject("Btn_Agregar_Clas_Especial.Image"), System.Drawing.Image)
        Me.Btn_Agregar_Clas_Especial.ImageAlt = CType(resources.GetObject("Btn_Agregar_Clas_Especial.ImageAlt"), System.Drawing.Image)
        Me.Btn_Agregar_Clas_Especial.Name = "Btn_Agregar_Clas_Especial"
        Me.Btn_Agregar_Clas_Especial.Tooltip = "Agregar nueva clasificación especial"
        '
        'Btn_VerArbol
        '
        Me.Btn_VerArbol.FontBold = True
        Me.Btn_VerArbol.ForeColor = System.Drawing.Color.Black
        Me.Btn_VerArbol.Image = CType(resources.GetObject("Btn_VerArbol.Image"), System.Drawing.Image)
        Me.Btn_VerArbol.ImageAlt = CType(resources.GetObject("Btn_VerArbol.ImageAlt"), System.Drawing.Image)
        Me.Btn_VerArbol.Name = "Btn_VerArbol"
        Me.Btn_VerArbol.Tooltip = "Ver solo arbol del producto"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(3, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Descripción"
        '
        'TxtCodigo
        '
        Me.TxtCodigo.BackColor = System.Drawing.Color.White
        Me.TxtCodigo.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightOnFocus(Me.TxtCodigo, True)
        Me.TxtCodigo.Location = New System.Drawing.Point(76, 15)
        Me.TxtCodigo.Name = "TxtCodigo"
        Me.TxtCodigo.ReadOnly = True
        Me.TxtCodigo.Size = New System.Drawing.Size(125, 22)
        Me.TxtCodigo.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(3, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Código"
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
        Me.TxtDescripcion.Location = New System.Drawing.Point(76, 43)
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.PreventEnterBeep = True
        Me.TxtDescripcion.ReadOnly = True
        Me.TxtDescripcion.Size = New System.Drawing.Size(551, 22)
        Me.TxtDescripcion.TabIndex = 14
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(365, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(131, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Código Madre/Generico"
        Me.Label3.Visible = False
        '
        'TxtCodigoGenericoMadre
        '
        Me.TxtCodigoGenericoMadre.BackColor = System.Drawing.Color.White
        Me.TxtCodigoGenericoMadre.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightOnFocus(Me.TxtCodigoGenericoMadre, True)
        Me.TxtCodigoGenericoMadre.Location = New System.Drawing.Point(502, 15)
        Me.TxtCodigoGenericoMadre.Name = "TxtCodigoGenericoMadre"
        Me.TxtCodigoGenericoMadre.ReadOnly = True
        Me.TxtCodigoGenericoMadre.Size = New System.Drawing.Size(125, 22)
        Me.TxtCodigoGenericoMadre.TabIndex = 13
        Me.TxtCodigoGenericoMadre.Visible = False
        '
        'Highlighter1
        '
        Me.Highlighter1.ContainerControl = Me
        Me.Highlighter1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.TxtDescripcion)
        Me.GroupPanel1.Controls.Add(Me.Label1)
        Me.GroupPanel1.Controls.Add(Me.Label3)
        Me.GroupPanel1.Controls.Add(Me.Label2)
        Me.GroupPanel1.Controls.Add(Me.TxtCodigoGenericoMadre)
        Me.GroupPanel1.Controls.Add(Me.TxtCodigo)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 0)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(650, 100)
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
        Me.GroupPanel1.TabIndex = 14
        Me.GroupPanel1.Text = "Producto original del sistema"
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.ContextMenuBar1)
        Me.GroupPanel2.Controls.Add(Me.Grilla_Clasificaciones)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(12, 106)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(650, 257)
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
        Me.GroupPanel2.TabIndex = 15
        Me.GroupPanel2.Text = "Descripciones alternativas por origen"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_01})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(109, 69)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(210, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 47
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_01
        '
        Me.Menu_Contextual_01.AutoExpandOnClick = True
        Me.Menu_Contextual_01.Name = "Menu_Contextual_01"
        Me.Menu_Contextual_01.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1, Me.Mnu_Btn_Editar_Clas_Especial, Me.Mnu_Btn_Eliminar_Clas_Especial})
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
        Me.LabelItem1.Text = "Opciones dela línea"
        '
        'Mnu_Btn_Editar_Clas_Especial
        '
        Me.Mnu_Btn_Editar_Clas_Especial.Image = CType(resources.GetObject("Mnu_Btn_Editar_Clas_Especial.Image"), System.Drawing.Image)
        Me.Mnu_Btn_Editar_Clas_Especial.ImageAlt = CType(resources.GetObject("Mnu_Btn_Editar_Clas_Especial.ImageAlt"), System.Drawing.Image)
        Me.Mnu_Btn_Editar_Clas_Especial.Name = "Mnu_Btn_Editar_Clas_Especial"
        Me.Mnu_Btn_Editar_Clas_Especial.Text = "Editar clasificación especial"
        '
        'Mnu_Btn_Eliminar_Clas_Especial
        '
        Me.Mnu_Btn_Eliminar_Clas_Especial.Image = CType(resources.GetObject("Mnu_Btn_Eliminar_Clas_Especial.Image"), System.Drawing.Image)
        Me.Mnu_Btn_Eliminar_Clas_Especial.ImageAlt = CType(resources.GetObject("Mnu_Btn_Eliminar_Clas_Especial.ImageAlt"), System.Drawing.Image)
        Me.Mnu_Btn_Eliminar_Clas_Especial.Name = "Mnu_Btn_Eliminar_Clas_Especial"
        Me.Mnu_Btn_Eliminar_Clas_Especial.Text = "Eliminar clasificación especial"
        '
        'Grilla_Clasificaciones
        '
        Me.Grilla_Clasificaciones.AllowUserToAddRows = False
        Me.Grilla_Clasificaciones.AllowUserToDeleteRows = False
        Me.Grilla_Clasificaciones.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Clasificaciones.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Grilla_Clasificaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Clasificaciones.DefaultCellStyle = DataGridViewCellStyle5
        Me.Grilla_Clasificaciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Clasificaciones.EnableHeadersVisualStyles = False
        Me.Grilla_Clasificaciones.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Clasificaciones.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Clasificaciones.Name = "Grilla_Clasificaciones"
        Me.Grilla_Clasificaciones.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Clasificaciones.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Grilla_Clasificaciones.RowHeadersVisible = False
        Me.Grilla_Clasificaciones.RowTemplate.Height = 25
        Me.Grilla_Clasificaciones.Size = New System.Drawing.Size(644, 234)
        Me.Grilla_Clasificaciones.TabIndex = 55
        '
        'Frm_MtCreaProd_01_IngBusqEspecial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(676, 410)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_MtCreaProd_01_IngBusqEspecial"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ficha producto y sus descripciones alternativas de busqueda"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla_Clasificaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnAsociaciones As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents TxtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Highlighter1 As DevComponents.DotNetBar.Validator.Highlighter
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents TxtCodigoGenericoMadre As System.Windows.Forms.TextBox
    Friend WithEvents TxtDescripcion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Btn_VerArbol As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Copiar_Arbol_Hijos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Btn_Agregar_Clas_Especial As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_01 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Mnu_Btn_Editar_Clas_Especial As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Mnu_Btn_Eliminar_Clas_Especial As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Asociaciones_Unicas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grilla_Clasificaciones As DevComponents.DotNetBar.Controls.DataGridViewX
End Class
