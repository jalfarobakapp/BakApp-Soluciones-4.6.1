<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_St_EncIngreso
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
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle29 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle30 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_St_EncIngreso))
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Grilla_Productos = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Btn_Contacto = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_Nombre_Contacto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Email_Contacto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Telefono_Contacto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Agregar_Producto = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel13 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_Documentos_Grarantia = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Documento_Sistema = New DevComponents.DotNetBar.ButtonItem()
        Me.Documento_Externo = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Doc_Externo_Boleta = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Doc_Externo_Factura = New DevComponents.DotNetBar.ButtonItem()
        Me.Txt_Defecto_segun_cliente = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Nota_Etapa_01 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.GroupPanel3.SuspendLayout()
        CType(Me.Grilla_Productos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel13.SuspendLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel3
        '
        Me.GroupPanel3.BackColor = System.Drawing.Color.White
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.ContextMenuBar1)
        Me.GroupPanel3.Controls.Add(Me.Grilla_Productos)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.GroupPanel3.Location = New System.Drawing.Point(12, 129)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(774, 173)
        '
        '
        '
        Me.GroupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel3.Style.BackColorGradientAngle = 90
        Me.GroupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderBottomWidth = 1
        Me.GroupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderLeftWidth = 1
        Me.GroupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderRightWidth = 1
        Me.GroupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderTopWidth = 1
        Me.GroupPanel3.Style.CornerDiameter = 4
        Me.GroupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel3.TabIndex = 109
        Me.GroupPanel3.Text = "Sub-Ordenes de servicio (productos)"
        '
        'Grilla_Productos
        '
        Me.Grilla_Productos.AllowUserToAddRows = False
        Me.Grilla_Productos.AllowUserToDeleteRows = False
        Me.Grilla_Productos.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle25.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        DataGridViewCellStyle25.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle25.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Productos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle25
        Me.Grilla_Productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle26.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle26.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        DataGridViewCellStyle26.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle26.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Productos.DefaultCellStyle = DataGridViewCellStyle26
        Me.Grilla_Productos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Productos.EnableHeadersVisualStyles = False
        Me.Grilla_Productos.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Productos.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Productos.Name = "Grilla_Productos"
        Me.Grilla_Productos.ReadOnly = True
        DataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle27.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        DataGridViewCellStyle27.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle27.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Productos.RowHeadersDefaultCellStyle = DataGridViewCellStyle27
        Me.Grilla_Productos.RowHeadersVisible = False
        Me.Grilla_Productos.RowTemplate.Height = 25
        Me.Grilla_Productos.Size = New System.Drawing.Size(768, 150)
        Me.Grilla_Productos.TabIndex = 91
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Btn_Contacto)
        Me.GroupPanel1.Controls.Add(Me.Txt_Nombre_Contacto)
        Me.GroupPanel1.Controls.Add(Me.LabelX9)
        Me.GroupPanel1.Controls.Add(Me.Txt_Email_Contacto)
        Me.GroupPanel1.Controls.Add(Me.LabelX7)
        Me.GroupPanel1.Controls.Add(Me.Txt_Telefono_Contacto)
        Me.GroupPanel1.Controls.Add(Me.LabelX6)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 59)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(774, 64)
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
        Me.GroupPanel1.TabIndex = 108
        '
        'Btn_Contacto
        '
        Me.Btn_Contacto.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Contacto.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Contacto.Image = CType(resources.GetObject("Btn_Contacto.Image"), System.Drawing.Image)
        Me.Btn_Contacto.Location = New System.Drawing.Point(715, 6)
        Me.Btn_Contacto.Name = "Btn_Contacto"
        Me.Btn_Contacto.Size = New System.Drawing.Size(50, 48)
        Me.Btn_Contacto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Contacto.TabIndex = 74
        Me.Btn_Contacto.Tooltip = "buscar contactos del cliente"
        '
        'Txt_Nombre_Contacto
        '
        '
        '
        '
        Me.Txt_Nombre_Contacto.Border.Class = "TextBoxBorder"
        Me.Txt_Nombre_Contacto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Nombre_Contacto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Nombre_Contacto.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Nombre_Contacto.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Nombre_Contacto.ForeColor = System.Drawing.Color.Black
        Me.Txt_Nombre_Contacto.Location = New System.Drawing.Point(152, 6)
        Me.Txt_Nombre_Contacto.MaxLength = 50
        Me.Txt_Nombre_Contacto.Name = "Txt_Nombre_Contacto"
        Me.Txt_Nombre_Contacto.ReadOnly = True
        Me.Txt_Nombre_Contacto.Size = New System.Drawing.Size(557, 22)
        Me.Txt_Nombre_Contacto.TabIndex = 73
        '
        'LabelX9
        '
        Me.LabelX9.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX9.ForeColor = System.Drawing.Color.Black
        Me.LabelX9.Location = New System.Drawing.Point(6, 2)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(133, 23)
        Me.LabelX9.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX9.TabIndex = 72
        Me.LabelX9.Text = "Nombre del contacto"
        '
        'Txt_Email_Contacto
        '
        '
        '
        '
        Me.Txt_Email_Contacto.Border.Class = "TextBoxBorder"
        Me.Txt_Email_Contacto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Email_Contacto.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.Txt_Email_Contacto.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Email_Contacto.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Email_Contacto.ForeColor = System.Drawing.Color.Black
        Me.Txt_Email_Contacto.Location = New System.Drawing.Point(451, 33)
        Me.Txt_Email_Contacto.MaxLength = 50
        Me.Txt_Email_Contacto.Name = "Txt_Email_Contacto"
        Me.Txt_Email_Contacto.ReadOnly = True
        Me.Txt_Email_Contacto.Size = New System.Drawing.Size(258, 22)
        Me.Txt_Email_Contacto.TabIndex = 71
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX7.ForeColor = System.Drawing.Color.Black
        Me.LabelX7.Location = New System.Drawing.Point(335, 32)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(110, 23)
        Me.LabelX7.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX7.TabIndex = 70
        Me.LabelX7.Text = "Email de contacto"
        '
        'Txt_Telefono_Contacto
        '
        '
        '
        '
        Me.Txt_Telefono_Contacto.Border.Class = "TextBoxBorder"
        Me.Txt_Telefono_Contacto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Telefono_Contacto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Telefono_Contacto.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Telefono_Contacto.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Telefono_Contacto.ForeColor = System.Drawing.Color.Black
        Me.Txt_Telefono_Contacto.Location = New System.Drawing.Point(152, 32)
        Me.Txt_Telefono_Contacto.MaxLength = 20
        Me.Txt_Telefono_Contacto.Name = "Txt_Telefono_Contacto"
        Me.Txt_Telefono_Contacto.ReadOnly = True
        Me.Txt_Telefono_Contacto.Size = New System.Drawing.Size(150, 22)
        Me.Txt_Telefono_Contacto.TabIndex = 69
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(6, 31)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(133, 23)
        Me.LabelX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX6.TabIndex = 65
        Me.LabelX6.Text = "Teléfono de contacto"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar, Me.Btn_Agregar_Producto})
        Me.Bar2.Location = New System.Drawing.Point(0, 410)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(796, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 107
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Tooltip = "Grabar [F4]"
        '
        'Btn_Agregar_Producto
        '
        Me.Btn_Agregar_Producto.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Agregar_Producto.ForeColor = System.Drawing.Color.Black
        Me.Btn_Agregar_Producto.Image = CType(resources.GetObject("Btn_Agregar_Producto.Image"), System.Drawing.Image)
        Me.Btn_Agregar_Producto.Name = "Btn_Agregar_Producto"
        Me.Btn_Agregar_Producto.Text = "Agregar producto"
        '
        'GroupPanel13
        '
        Me.GroupPanel13.BackColor = System.Drawing.Color.White
        Me.GroupPanel13.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel13.Controls.Add(Me.Grilla)
        Me.GroupPanel13.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel13.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.GroupPanel13.Location = New System.Drawing.Point(12, 0)
        Me.GroupPanel13.Name = "GroupPanel13"
        Me.GroupPanel13.Size = New System.Drawing.Size(774, 53)
        '
        '
        '
        Me.GroupPanel13.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel13.Style.BackColorGradientAngle = 90
        Me.GroupPanel13.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel13.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel13.Style.BorderBottomWidth = 1
        Me.GroupPanel13.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel13.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel13.Style.BorderLeftWidth = 1
        Me.GroupPanel13.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel13.Style.BorderRightWidth = 1
        Me.GroupPanel13.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel13.Style.BorderTopWidth = 1
        Me.GroupPanel13.Style.CornerDiameter = 4
        Me.GroupPanel13.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel13.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel13.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel13.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel13.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel13.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel13.TabIndex = 104
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.AllowUserToDeleteRows = False
        Me.Grilla.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle28.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle28.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        DataGridViewCellStyle28.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle28.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle28.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle28
        Me.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle29.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle29.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        DataGridViewCellStyle29.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle29.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle29.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla.DefaultCellStyle = DataGridViewCellStyle29
        Me.Grilla.EnableHeadersVisualStyles = False
        Me.Grilla.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla.Location = New System.Drawing.Point(3, 3)
        Me.Grilla.Name = "Grilla"
        Me.Grilla.ReadOnly = True
        DataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle30.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle30.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        DataGridViewCellStyle30.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle30.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle30.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle30
        Me.Grilla.RowHeadersVisible = False
        Me.Grilla.RowTemplate.Height = 25
        Me.Grilla.Size = New System.Drawing.Size(762, 39)
        Me.Grilla.TabIndex = 0
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Txt_Defecto_segun_cliente)
        Me.GroupPanel2.Controls.Add(Me.LabelX10)
        Me.GroupPanel2.Controls.Add(Me.LabelX8)
        Me.GroupPanel2.Controls.Add(Me.Txt_Nota_Etapa_01)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(12, 308)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(774, 93)
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
        Me.GroupPanel2.TabIndex = 110
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_Documentos_Grarantia})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(318, 42)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(261, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 73
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_Documentos_Grarantia
        '
        Me.Menu_Contextual_Documentos_Grarantia.AutoExpandOnClick = True
        Me.Menu_Contextual_Documentos_Grarantia.Name = "Menu_Contextual_Documentos_Grarantia"
        Me.Menu_Contextual_Documentos_Grarantia.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Documento_Sistema, Me.Documento_Externo})
        Me.Menu_Contextual_Documentos_Grarantia.Text = "Opciones Documentos"
        '
        'Btn_Documento_Sistema
        '
        Me.Btn_Documento_Sistema.Image = CType(resources.GetObject("Btn_Documento_Sistema.Image"), System.Drawing.Image)
        Me.Btn_Documento_Sistema.Name = "Btn_Documento_Sistema"
        Me.Btn_Documento_Sistema.Text = "Documento del sistema"
        Me.Btn_Documento_Sistema.Tooltip = "Buscar documento en base de datos del sistema y linkear"
        '
        'Documento_Externo
        '
        Me.Documento_Externo.Image = CType(resources.GetObject("Documento_Externo.Image"), System.Drawing.Image)
        Me.Documento_Externo.Name = "Documento_Externo"
        Me.Documento_Externo.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Doc_Externo_Boleta, Me.Btn_Doc_Externo_Factura})
        Me.Documento_Externo.Text = "Documento Externo"
        Me.Documento_Externo.Tooltip = "Poner numero de la boleta o factura del cliente"
        '
        'Btn_Doc_Externo_Boleta
        '
        Me.Btn_Doc_Externo_Boleta.Image = CType(resources.GetObject("Btn_Doc_Externo_Boleta.Image"), System.Drawing.Image)
        Me.Btn_Doc_Externo_Boleta.Name = "Btn_Doc_Externo_Boleta"
        Me.Btn_Doc_Externo_Boleta.Text = "BOLETA"
        '
        'Btn_Doc_Externo_Factura
        '
        Me.Btn_Doc_Externo_Factura.Image = CType(resources.GetObject("Btn_Doc_Externo_Factura.Image"), System.Drawing.Image)
        Me.Btn_Doc_Externo_Factura.Name = "Btn_Doc_Externo_Factura"
        Me.Btn_Doc_Externo_Factura.Text = "FACTURA"
        '
        'Txt_Defecto_segun_cliente
        '
        '
        '
        '
        Me.Txt_Defecto_segun_cliente.Border.Class = "TextBoxBorder"
        Me.Txt_Defecto_segun_cliente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Defecto_segun_cliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Defecto_segun_cliente.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Defecto_segun_cliente.FocusHighlightEnabled = True
        Me.Txt_Defecto_segun_cliente.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Defecto_segun_cliente.ForeColor = System.Drawing.Color.Black
        Me.Txt_Defecto_segun_cliente.Location = New System.Drawing.Point(152, 3)
        Me.Txt_Defecto_segun_cliente.MaxLength = 1000
        Me.Txt_Defecto_segun_cliente.Multiline = True
        Me.Txt_Defecto_segun_cliente.Name = "Txt_Defecto_segun_cliente"
        Me.Txt_Defecto_segun_cliente.ReadOnly = True
        Me.Txt_Defecto_segun_cliente.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Defecto_segun_cliente.Size = New System.Drawing.Size(613, 53)
        Me.Txt_Defecto_segun_cliente.TabIndex = 1
        '
        'LabelX10
        '
        Me.LabelX10.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Dock = System.Windows.Forms.DockStyle.Top
        Me.LabelX10.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX10.ForeColor = System.Drawing.Color.Black
        Me.LabelX10.Location = New System.Drawing.Point(0, 0)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(768, 23)
        Me.LabelX10.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX10.TabIndex = 72
        Me.LabelX10.Text = "Defecto según el cliente"
        '
        'LabelX8
        '
        Me.LabelX8.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX8.ForeColor = System.Drawing.Color.Black
        Me.LabelX8.Location = New System.Drawing.Point(3, 61)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(42, 23)
        Me.LabelX8.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX8.TabIndex = 71
        Me.LabelX8.Text = "Nota :"
        '
        'Txt_Nota_Etapa_01
        '
        '
        '
        '
        Me.Txt_Nota_Etapa_01.Border.Class = "TextBoxBorder"
        Me.Txt_Nota_Etapa_01.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Nota_Etapa_01.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Nota_Etapa_01.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Nota_Etapa_01.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Nota_Etapa_01.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Nota_Etapa_01.ForeColor = System.Drawing.Color.Black
        Me.Txt_Nota_Etapa_01.Location = New System.Drawing.Point(152, 62)
        Me.Txt_Nota_Etapa_01.MaxLength = 1000
        Me.Txt_Nota_Etapa_01.Name = "Txt_Nota_Etapa_01"
        Me.Txt_Nota_Etapa_01.ReadOnly = True
        Me.Txt_Nota_Etapa_01.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Nota_Etapa_01.Size = New System.Drawing.Size(613, 22)
        Me.Txt_Nota_Etapa_01.TabIndex = 2
        '
        'Frm_St_EncIngreso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(796, 451)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.GroupPanel3)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.GroupPanel13)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_St_EncIngreso"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        Me.GroupPanel3.ResumeLayout(False)
        CType(Me.Grilla_Productos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel13.ResumeLayout(False)
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grilla_Productos As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Btn_Contacto As DevComponents.DotNetBar.ButtonX
    Public WithEvents Txt_Nombre_Contacto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Email_Contacto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Telefono_Contacto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel13 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Btn_Agregar_Producto As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_Documentos_Grarantia As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Documento_Sistema As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Documento_Externo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Doc_Externo_Boleta As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Doc_Externo_Factura As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Txt_Defecto_segun_cliente As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Nota_Etapa_01 As DevComponents.DotNetBar.Controls.TextBoxX
End Class
