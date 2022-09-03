<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_St_Estado_07_Entrega_Facturacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_St_Estado_07_Entrega_Facturacion))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.Txt_Nota = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.Bar2 = New DevComponents.DotNetBar.Bar
        Me.Btn_Fijar_Estado = New DevComponents.DotNetBar.ButtonItem
        Me.Btn_Agregar_Factura = New DevComponents.DotNetBar.ButtonItem
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem
        Me.Btn_Editar = New DevComponents.DotNetBar.ButtonItem
        Me.Btn_Cancelar = New DevComponents.DotNetBar.ButtonItem
        Me.Btn_Salir = New DevComponents.DotNetBar.ButtonItem
        Me.Grupo_Documentos = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar
        Me.Menu_Contextual_Ver_Quitar = New DevComponents.DotNetBar.ButtonItem
        Me.Btn_Ver_documento = New DevComponents.DotNetBar.ButtonItem
        Me.Btn_Quitar_documento = New DevComponents.DotNetBar.ButtonItem
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX
        Me.Chk_Equipo_Abandonado_Por_El_Cliente = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.Cmb_Estado_Entrega = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX23 = New DevComponents.DotNetBar.LabelX
        Me.Btn_Estado_Entrega = New DevComponents.DotNetBar.ButtonX
        Me.GroupPanel2.SuspendLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_Documentos.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Txt_Nota)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(10, 247)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(508, 120)
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
        Me.GroupPanel2.TabIndex = 90
        Me.GroupPanel2.Text = "Nota (Información sobre la entrega de esta reparación.)"
        '
        'Txt_Nota
        '
        Me.Txt_Nota.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Nota.Border.Class = "TextBoxBorder"
        Me.Txt_Nota.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Nota.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Nota.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Nota.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Nota.FocusHighlightEnabled = True
        Me.Txt_Nota.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Nota.ForeColor = System.Drawing.Color.Black
        Me.Txt_Nota.Location = New System.Drawing.Point(6, 3)
        Me.Txt_Nota.MaxLength = 300
        Me.Txt_Nota.Multiline = True
        Me.Txt_Nota.Name = "Txt_Nota"
        Me.Txt_Nota.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Nota.Size = New System.Drawing.Size(493, 91)
        Me.Txt_Nota.TabIndex = 64
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Fijar_Estado, Me.Btn_Agregar_Factura, Me.Btn_Grabar, Me.Btn_Editar, Me.Btn_Cancelar, Me.Btn_Salir})
        Me.Bar2.Location = New System.Drawing.Point(0, 395)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(525, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 91
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Fijar_Estado
        '
        Me.Btn_Fijar_Estado.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Fijar_Estado.ForeColor = System.Drawing.Color.Black
        Me.Btn_Fijar_Estado.Image = CType(resources.GetObject("Btn_Fijar_Estado.Image"), System.Drawing.Image)
        Me.Btn_Fijar_Estado.Name = "Btn_Fijar_Estado"
        Me.Btn_Fijar_Estado.Text = "Fijar Estado"
        '
        'Btn_Agregar_Factura
        '
        Me.Btn_Agregar_Factura.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Agregar_Factura.ForeColor = System.Drawing.Color.Black
        Me.Btn_Agregar_Factura.Image = CType(resources.GetObject("Btn_Agregar_Factura.Image"), System.Drawing.Image)
        Me.Btn_Agregar_Factura.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Agregar_Factura.Name = "Btn_Agregar_Factura"
        Me.Btn_Agregar_Factura.Tooltip = "Agregar"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Tooltip = "Grabar [F4]"
        Me.Btn_Grabar.Visible = False
        '
        'Btn_Editar
        '
        Me.Btn_Editar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Editar.FontBold = True
        Me.Btn_Editar.ForeColor = System.Drawing.Color.Red
        Me.Btn_Editar.Image = CType(resources.GetObject("Btn_Editar.Image"), System.Drawing.Image)
        Me.Btn_Editar.Name = "Btn_Editar"
        Me.Btn_Editar.Tooltip = "Editar"
        Me.Btn_Editar.Visible = False
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Cancelar.FontBold = True
        Me.Btn_Cancelar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Cancelar.Image = CType(resources.GetObject("Btn_Cancelar.Image"), System.Drawing.Image)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Text = "Cancelar edición"
        Me.Btn_Cancelar.Visible = False
        '
        'Btn_Salir
        '
        Me.Btn_Salir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Salir.ForeColor = System.Drawing.Color.Black
        Me.Btn_Salir.Image = CType(resources.GetObject("Btn_Salir.Image"), System.Drawing.Image)
        Me.Btn_Salir.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Salir.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Tooltip = "Salir"
        '
        'Grupo_Documentos
        '
        Me.Grupo_Documentos.BackColor = System.Drawing.Color.White
        Me.Grupo_Documentos.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Documentos.Controls.Add(Me.ContextMenuBar1)
        Me.Grupo_Documentos.Controls.Add(Me.Grilla)
        Me.Grupo_Documentos.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Documentos.Location = New System.Drawing.Point(10, 54)
        Me.Grupo_Documentos.Name = "Grupo_Documentos"
        Me.Grupo_Documentos.Size = New System.Drawing.Size(506, 157)
        '
        '
        '
        Me.Grupo_Documentos.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Documentos.Style.BackColorGradientAngle = 90
        Me.Grupo_Documentos.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Documentos.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Documentos.Style.BorderBottomWidth = 1
        Me.Grupo_Documentos.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Documentos.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Documentos.Style.BorderLeftWidth = 1
        Me.Grupo_Documentos.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Documentos.Style.BorderRightWidth = 1
        Me.Grupo_Documentos.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Documentos.Style.BorderTopWidth = 1
        Me.Grupo_Documentos.Style.CornerDiameter = 4
        Me.Grupo_Documentos.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Documentos.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Documentos.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Documentos.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Documentos.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Documentos.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Documentos.TabIndex = 98
        Me.Grupo_Documentos.Text = "Factura(s) / Guías Internas"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_Ver_Quitar})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(131, 35)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(319, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 47
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_Ver_Quitar
        '
        Me.Menu_Contextual_Ver_Quitar.AutoExpandOnClick = True
        Me.Menu_Contextual_Ver_Quitar.Name = "Menu_Contextual_Ver_Quitar"
        Me.Menu_Contextual_Ver_Quitar.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Ver_documento, Me.Btn_Quitar_documento})
        Me.Menu_Contextual_Ver_Quitar.Text = "Opciones Ver/Quitar"
        '
        'Btn_Ver_documento
        '
        Me.Btn_Ver_documento.Image = CType(resources.GetObject("Btn_Ver_documento.Image"), System.Drawing.Image)
        Me.Btn_Ver_documento.Name = "Btn_Ver_documento"
        Me.Btn_Ver_documento.Text = "Ver documento"
        '
        'Btn_Quitar_documento
        '
        Me.Btn_Quitar_documento.Image = CType(resources.GetObject("Btn_Quitar_documento.Image"), System.Drawing.Image)
        Me.Btn_Quitar_documento.Name = "Btn_Quitar_documento"
        Me.Btn_Quitar_documento.Text = "Quitar documento de la lista"
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
        Me.Grilla.MultiSelect = False
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
        Me.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grilla.Size = New System.Drawing.Size(500, 134)
        Me.Grilla.TabIndex = 1
        '
        'Chk_Equipo_Abandonado_Por_El_Cliente
        '
        Me.Chk_Equipo_Abandonado_Por_El_Cliente.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Equipo_Abandonado_Por_El_Cliente.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Equipo_Abandonado_Por_El_Cliente.ForeColor = System.Drawing.Color.Black
        Me.Chk_Equipo_Abandonado_Por_El_Cliente.Location = New System.Drawing.Point(12, 21)
        Me.Chk_Equipo_Abandonado_Por_El_Cliente.Name = "Chk_Equipo_Abandonado_Por_El_Cliente"
        Me.Chk_Equipo_Abandonado_Por_El_Cliente.Size = New System.Drawing.Size(232, 18)
        Me.Chk_Equipo_Abandonado_Por_El_Cliente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Equipo_Abandonado_Por_El_Cliente.TabIndex = 103
        Me.Chk_Equipo_Abandonado_Por_El_Cliente.Text = "EQUIPO ABANDONADO POR EL CLIENTE"
        '
        'Cmb_Estado_Entrega
        '
        Me.Cmb_Estado_Entrega.DisplayMember = "Text"
        Me.Cmb_Estado_Entrega.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Estado_Entrega.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Cmb_Estado_Entrega.FocusHighlightEnabled = True
        Me.Cmb_Estado_Entrega.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Estado_Entrega.ItemHeight = 16
        Me.Cmb_Estado_Entrega.Location = New System.Drawing.Point(147, 218)
        Me.Cmb_Estado_Entrega.Name = "Cmb_Estado_Entrega"
        Me.Cmb_Estado_Entrega.Size = New System.Drawing.Size(243, 22)
        Me.Cmb_Estado_Entrega.TabIndex = 104
        '
        'LabelX23
        '
        Me.LabelX23.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX23.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX23.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX23.ForeColor = System.Drawing.Color.Black
        Me.LabelX23.Location = New System.Drawing.Point(12, 217)
        Me.LabelX23.Name = "LabelX23"
        Me.LabelX23.Size = New System.Drawing.Size(118, 23)
        Me.LabelX23.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX23.TabIndex = 105
        Me.LabelX23.Text = "Estado de entrega"
        '
        'Btn_Estado_Entrega
        '
        Me.Btn_Estado_Entrega.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Estado_Entrega.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Estado_Entrega.Image = CType(resources.GetObject("Btn_Estado_Entrega.Image"), System.Drawing.Image)
        Me.Btn_Estado_Entrega.Location = New System.Drawing.Point(396, 217)
        Me.Btn_Estado_Entrega.Name = "Btn_Estado_Entrega"
        Me.Btn_Estado_Entrega.Size = New System.Drawing.Size(28, 24)
        Me.Btn_Estado_Entrega.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Estado_Entrega.TabIndex = 106
        Me.Btn_Estado_Entrega.Tooltip = "Buscar Marca"
        '
        'Frm_St_Estado_07_Entrega_Facturacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(525, 436)
        Me.ControlBox = False
        Me.Controls.Add(Me.Btn_Estado_Entrega)
        Me.Controls.Add(Me.Cmb_Estado_Entrega)
        Me.Controls.Add(Me.LabelX23)
        Me.Controls.Add(Me.Chk_Equipo_Abandonado_Por_El_Cliente)
        Me.Controls.Add(Me.Grupo_Documentos)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.Bar2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "Frm_St_Estado_07_Entrega_Facturacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Entrega y facturación de la reparación."
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo_Documentos.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Txt_Nota As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Fijar_Estado As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Editar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Salir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grupo_Documentos As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_Ver_Quitar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Ver_documento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Quitar_documento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Chk_Equipo_Abandonado_Por_El_Cliente As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Cmb_Estado_Entrega As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX23 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Estado_Entrega As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Agregar_Factura As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Cancelar As DevComponents.DotNetBar.ButtonItem
End Class
