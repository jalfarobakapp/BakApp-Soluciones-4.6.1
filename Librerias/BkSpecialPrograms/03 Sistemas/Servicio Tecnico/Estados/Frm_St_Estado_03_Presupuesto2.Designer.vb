<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_St_Estado_03_Presupuesto2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_St_Estado_03_Presupuesto2))
        Me.Grupo_Grilla = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Fijar_Estado = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Agregar_Producto = New DevComponents.DotNetBar.ButtonItem()
        Me.Grupo_Presupuesto = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Txt_Tecnico_Taller = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_NroSerie = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Txt_Nota = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Defecto_segun_cliente = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.Highlighter1 = New DevComponents.DotNetBar.Validator.Highlighter()
        Me.Chk_ProductoNoReparable = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Grupo_Grilla.SuspendLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_Presupuesto.SuspendLayout()
        Me.GroupPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Grupo_Grilla
        '
        Me.Grupo_Grilla.BackColor = System.Drawing.Color.White
        Me.Grupo_Grilla.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Grilla.Controls.Add(Me.Grilla)
        Me.Grupo_Grilla.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Grilla.Location = New System.Drawing.Point(9, 80)
        Me.Grupo_Grilla.Name = "Grupo_Grilla"
        Me.Grupo_Grilla.Size = New System.Drawing.Size(608, 261)
        '
        '
        '
        Me.Grupo_Grilla.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Grilla.Style.BackColorGradientAngle = 90
        Me.Grupo_Grilla.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Grilla.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Grilla.Style.BorderBottomWidth = 1
        Me.Grupo_Grilla.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Grilla.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Grilla.Style.BorderLeftWidth = 1
        Me.Grupo_Grilla.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Grilla.Style.BorderRightWidth = 1
        Me.Grupo_Grilla.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Grilla.Style.BorderTopWidth = 1
        Me.Grupo_Grilla.Style.CornerDiameter = 4
        Me.Grupo_Grilla.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Grilla.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Grilla.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Grilla.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Grilla.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Grilla.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Grilla.TabIndex = 97
        Me.Grupo_Grilla.Text = "Servicios a realizar"
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
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
        Me.Grilla.MultiSelect = False
        Me.Grilla.Name = "Grilla"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grilla.Size = New System.Drawing.Size(602, 238)
        Me.Grilla.TabIndex = 2
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Fijar_Estado, Me.Btn_Agregar_Producto})
        Me.Bar2.Location = New System.Drawing.Point(0, 520)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(627, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 96
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
        'Btn_Agregar_Producto
        '
        Me.Btn_Agregar_Producto.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Agregar_Producto.ForeColor = System.Drawing.Color.Black
        Me.Btn_Agregar_Producto.Image = CType(resources.GetObject("Btn_Agregar_Producto.Image"), System.Drawing.Image)
        Me.Btn_Agregar_Producto.Name = "Btn_Agregar_Producto"
        Me.Btn_Agregar_Producto.Text = "Agregar servicio"
        '
        'Grupo_Presupuesto
        '
        Me.Grupo_Presupuesto.BackColor = System.Drawing.Color.White
        Me.Grupo_Presupuesto.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Presupuesto.Controls.Add(Me.Txt_Tecnico_Taller)
        Me.Grupo_Presupuesto.Controls.Add(Me.Txt_NroSerie)
        Me.Grupo_Presupuesto.Controls.Add(Me.LabelX1)
        Me.Grupo_Presupuesto.Controls.Add(Me.LabelX2)
        Me.Grupo_Presupuesto.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Presupuesto.Location = New System.Drawing.Point(9, 3)
        Me.Grupo_Presupuesto.Name = "Grupo_Presupuesto"
        Me.Grupo_Presupuesto.Size = New System.Drawing.Size(608, 71)
        '
        '
        '
        Me.Grupo_Presupuesto.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Presupuesto.Style.BackColorGradientAngle = 90
        Me.Grupo_Presupuesto.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Presupuesto.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Presupuesto.Style.BorderBottomWidth = 1
        Me.Grupo_Presupuesto.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Presupuesto.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Presupuesto.Style.BorderLeftWidth = 1
        Me.Grupo_Presupuesto.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Presupuesto.Style.BorderRightWidth = 1
        Me.Grupo_Presupuesto.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Presupuesto.Style.BorderTopWidth = 1
        Me.Grupo_Presupuesto.Style.CornerDiameter = 4
        Me.Grupo_Presupuesto.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Presupuesto.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Presupuesto.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Presupuesto.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Presupuesto.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Presupuesto.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Presupuesto.TabIndex = 98
        Me.Grupo_Presupuesto.Text = "Datos del técnico y el producto a reparar"
        '
        'Txt_Tecnico_Taller
        '
        Me.Txt_Tecnico_Taller.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Tecnico_Taller.Border.Class = "TextBoxBorder"
        Me.Txt_Tecnico_Taller.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Tecnico_Taller.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Tecnico_Taller.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Tecnico_Taller.Enabled = False
        Me.Txt_Tecnico_Taller.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Tecnico_Taller.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Tecnico_Taller.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightOnFocus(Me.Txt_Tecnico_Taller, True)
        Me.Txt_Tecnico_Taller.Location = New System.Drawing.Point(51, 17)
        Me.Txt_Tecnico_Taller.MaxLength = 300
        Me.Txt_Tecnico_Taller.Name = "Txt_Tecnico_Taller"
        Me.Txt_Tecnico_Taller.ReadOnly = True
        Me.Txt_Tecnico_Taller.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Tecnico_Taller.Size = New System.Drawing.Size(250, 22)
        Me.Txt_Tecnico_Taller.TabIndex = 0
        '
        'Txt_NroSerie
        '
        Me.Txt_NroSerie.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_NroSerie.Border.Class = "TextBoxBorder"
        Me.Txt_NroSerie.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_NroSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_NroSerie.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_NroSerie.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_NroSerie.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_NroSerie.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightOnFocus(Me.Txt_NroSerie, True)
        Me.Txt_NroSerie.Location = New System.Drawing.Point(454, 17)
        Me.Txt_NroSerie.MaxLength = 300
        Me.Txt_NroSerie.Name = "Txt_NroSerie"
        Me.Txt_NroSerie.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_NroSerie.Size = New System.Drawing.Size(145, 22)
        Me.Txt_NroSerie.TabIndex = 1
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(346, 16)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(102, 23)
        Me.LabelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX1.TabIndex = 69
        Me.LabelX1.Text = "Número de serie"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(0, 17)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(51, 23)
        Me.LabelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX2.TabIndex = 64
        Me.LabelX2.Text = "Técnico"
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Txt_Nota)
        Me.GroupPanel2.Controls.Add(Me.Txt_Defecto_segun_cliente)
        Me.GroupPanel2.Controls.Add(Me.LabelX10)
        Me.GroupPanel2.Controls.Add(Me.LabelX8)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(9, 369)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(608, 127)
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
        Me.GroupPanel2.TabIndex = 99
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
        Me.Txt_Nota.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Nota.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightOnFocus(Me.Txt_Nota, True)
        Me.Txt_Nota.Location = New System.Drawing.Point(39, 98)
        Me.Txt_Nota.MaxLength = 1000
        Me.Txt_Nota.Name = "Txt_Nota"
        Me.Txt_Nota.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Nota.Size = New System.Drawing.Size(560, 22)
        Me.Txt_Nota.TabIndex = 64
        Me.Txt_Nota.TabStop = False
        '
        'Txt_Defecto_segun_cliente
        '
        Me.Txt_Defecto_segun_cliente.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Defecto_segun_cliente.Border.Class = "TextBoxBorder"
        Me.Txt_Defecto_segun_cliente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Defecto_segun_cliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Defecto_segun_cliente.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Defecto_segun_cliente.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Defecto_segun_cliente.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Defecto_segun_cliente.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightOnFocus(Me.Txt_Defecto_segun_cliente, True)
        Me.Txt_Defecto_segun_cliente.Location = New System.Drawing.Point(0, 29)
        Me.Txt_Defecto_segun_cliente.MaxLength = 1000
        Me.Txt_Defecto_segun_cliente.Multiline = True
        Me.Txt_Defecto_segun_cliente.Name = "Txt_Defecto_segun_cliente"
        Me.Txt_Defecto_segun_cliente.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Defecto_segun_cliente.Size = New System.Drawing.Size(599, 61)
        Me.Txt_Defecto_segun_cliente.TabIndex = 64
        Me.Txt_Defecto_segun_cliente.TabStop = False
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
        Me.LabelX10.Size = New System.Drawing.Size(602, 23)
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
        Me.LabelX8.Location = New System.Drawing.Point(0, 95)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(42, 23)
        Me.LabelX8.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX8.TabIndex = 71
        Me.LabelX8.Text = "Nota :"
        '
        'Highlighter1
        '
        Me.Highlighter1.ContainerControl = Me
        Me.Highlighter1.FocusHighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
        Me.Highlighter1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        '
        'Chk_ProductoNoReparable
        '
        Me.Chk_ProductoNoReparable.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_ProductoNoReparable.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_ProductoNoReparable.CheckBoxImageChecked = CType(resources.GetObject("Chk_ProductoNoReparable.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_ProductoNoReparable.FocusCuesEnabled = False
        Me.Chk_ProductoNoReparable.ForeColor = System.Drawing.Color.Black
        Me.Chk_ProductoNoReparable.Location = New System.Drawing.Point(9, 347)
        Me.Chk_ProductoNoReparable.Name = "Chk_ProductoNoReparable"
        Me.Chk_ProductoNoReparable.Size = New System.Drawing.Size(158, 16)
        Me.Chk_ProductoNoReparable.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_ProductoNoReparable.TabIndex = 104
        Me.Chk_ProductoNoReparable.Text = "PRODUCTO NO REPARABLE"
        '
        'Frm_St_Estado_03_Presupuesto2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(627, 561)
        Me.Controls.Add(Me.Chk_ProductoNoReparable)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.Grupo_Presupuesto)
        Me.Controls.Add(Me.Grupo_Grilla)
        Me.Controls.Add(Me.Bar2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_St_Estado_03_Presupuesto2"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PRESUPUESTO"
        Me.Grupo_Grilla.ResumeLayout(False)
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo_Presupuesto.ResumeLayout(False)
        Me.GroupPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Grupo_Grilla As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Fijar_Estado As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grupo_Presupuesto As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Txt_Tecnico_Taller As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Txt_NroSerie As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Txt_Nota As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Txt_Defecto_segun_cliente As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Agregar_Producto As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Highlighter1 As DevComponents.DotNetBar.Validator.Highlighter
    Friend WithEvents Chk_ProductoNoReparable As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
