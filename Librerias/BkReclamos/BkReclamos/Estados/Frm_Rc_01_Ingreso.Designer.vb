<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Rc_01_Ingreso
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Rc_01_Ingreso))
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Editar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Cancelar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Archivos_Adjuntos = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Grilla_Preguntas = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Txt_Descripcion_Reclamo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.GroupPanel6 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Cmb_Sub_Tipo_Reclamos = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX14 = New DevComponents.DotNetBar.LabelX()
        Me.Cmb_Tipo_Reclamo = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Buscar_Vendedor = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_Vendedor = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel5 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Txt_Email_Contacto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Nombre_Contacto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Btn_Buscar_Cliente = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Cliente = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Telefono_Contacto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Direccion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Cmb_Suc_Elaboracion = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Btn_Buscar_Producto = New DevComponents.DotNetBar.ButtonX()
        Me.Dtp_Fecha_Elab = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Txt_Producto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Cantidad = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.Imagenes_32x32 = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.Grilla_Preguntas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.GroupPanel6.SuspendLayout()
        Me.GroupPanel5.SuspendLayout()
        Me.GroupPanel3.SuspendLayout()
        CType(Me.Dtp_Fecha_Elab, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar, Me.Btn_Editar, Me.Btn_Cancelar, Me.Btn_Archivos_Adjuntos})
        Me.Bar2.Location = New System.Drawing.Point(0, 537)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(784, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 86
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
        'Btn_Archivos_Adjuntos
        '
        Me.Btn_Archivos_Adjuntos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Archivos_Adjuntos.ForeColor = System.Drawing.Color.Black
        Me.Btn_Archivos_Adjuntos.Image = CType(resources.GetObject("Btn_Archivos_Adjuntos.Image"), System.Drawing.Image)
        Me.Btn_Archivos_Adjuntos.Name = "Btn_Archivos_Adjuntos"
        Me.Btn_Archivos_Adjuntos.Text = "..."
        Me.Btn_Archivos_Adjuntos.Tooltip = "Ver archivos adjuntos"
        Me.Btn_Archivos_Adjuntos.Visible = False
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Grilla_Preguntas)
        Me.GroupPanel2.Controls.Add(Me.Txt_Descripcion_Reclamo)
        Me.GroupPanel2.Controls.Add(Me.LabelX10)
        Me.GroupPanel2.Controls.Add(Me.LabelX12)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(11, 271)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(741, 232)
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
        Me.GroupPanel2.TabIndex = 104
        '
        'Grilla_Preguntas
        '
        Me.Grilla_Preguntas.AllowUserToAddRows = False
        Me.Grilla_Preguntas.AllowUserToDeleteRows = False
        Me.Grilla_Preguntas.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Preguntas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.Grilla_Preguntas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Preguntas.DefaultCellStyle = DataGridViewCellStyle8
        Me.Grilla_Preguntas.EnableHeadersVisualStyles = False
        Me.Grilla_Preguntas.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Preguntas.Location = New System.Drawing.Point(6, 114)
        Me.Grilla_Preguntas.Name = "Grilla_Preguntas"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Preguntas.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.Grilla_Preguntas.RowHeadersVisible = False
        Me.Grilla_Preguntas.RowTemplate.Height = 25
        Me.Grilla_Preguntas.Size = New System.Drawing.Size(726, 109)
        Me.Grilla_Preguntas.TabIndex = 73
        '
        'Txt_Descripcion_Reclamo
        '
        Me.Txt_Descripcion_Reclamo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Descripcion_Reclamo.Border.Class = "TextBoxBorder"
        Me.Txt_Descripcion_Reclamo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Descripcion_Reclamo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Descripcion_Reclamo.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Descripcion_Reclamo.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Descripcion_Reclamo.FocusHighlightEnabled = True
        Me.Txt_Descripcion_Reclamo.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Descripcion_Reclamo.ForeColor = System.Drawing.Color.Black
        Me.Txt_Descripcion_Reclamo.Location = New System.Drawing.Point(6, 24)
        Me.Txt_Descripcion_Reclamo.MaxLength = 1000
        Me.Txt_Descripcion_Reclamo.Multiline = True
        Me.Txt_Descripcion_Reclamo.Name = "Txt_Descripcion_Reclamo"
        Me.Txt_Descripcion_Reclamo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Descripcion_Reclamo.Size = New System.Drawing.Size(726, 63)
        Me.Txt_Descripcion_Reclamo.TabIndex = 11
        '
        'LabelX10
        '
        Me.LabelX10.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX10.ForeColor = System.Drawing.Color.Black
        Me.LabelX10.Location = New System.Drawing.Point(6, 0)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(178, 22)
        Me.LabelX10.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX10.TabIndex = 72
        Me.LabelX10.Text = "Descripción Reclamo"
        '
        'LabelX12
        '
        Me.LabelX12.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX12.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX12.ForeColor = System.Drawing.Color.Black
        Me.LabelX12.Location = New System.Drawing.Point(6, 91)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(70, 23)
        Me.LabelX12.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX12.TabIndex = 111
        Me.LabelX12.Text = "Preguntas"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.GroupPanel6)
        Me.GroupPanel1.Controls.Add(Me.GroupPanel5)
        Me.GroupPanel1.Controls.Add(Me.GroupPanel3)
        Me.GroupPanel1.Controls.Add(Me.GroupPanel2)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(11, 5)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(761, 516)
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
        Me.GroupPanel1.TabIndex = 88
        '
        'GroupPanel6
        '
        Me.GroupPanel6.BackColor = System.Drawing.Color.White
        Me.GroupPanel6.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel6.Controls.Add(Me.Cmb_Sub_Tipo_Reclamos)
        Me.GroupPanel6.Controls.Add(Me.LabelX14)
        Me.GroupPanel6.Controls.Add(Me.Cmb_Tipo_Reclamo)
        Me.GroupPanel6.Controls.Add(Me.LabelX11)
        Me.GroupPanel6.Controls.Add(Me.Btn_Buscar_Vendedor)
        Me.GroupPanel6.Controls.Add(Me.Txt_Vendedor)
        Me.GroupPanel6.Controls.Add(Me.LabelX1)
        Me.GroupPanel6.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel6.Location = New System.Drawing.Point(11, 198)
        Me.GroupPanel6.Name = "GroupPanel6"
        Me.GroupPanel6.Size = New System.Drawing.Size(741, 67)
        '
        '
        '
        Me.GroupPanel6.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel6.Style.BackColorGradientAngle = 90
        Me.GroupPanel6.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel6.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel6.Style.BorderBottomWidth = 1
        Me.GroupPanel6.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel6.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel6.Style.BorderLeftWidth = 1
        Me.GroupPanel6.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel6.Style.BorderRightWidth = 1
        Me.GroupPanel6.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel6.Style.BorderTopWidth = 1
        Me.GroupPanel6.Style.CornerDiameter = 4
        Me.GroupPanel6.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel6.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel6.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel6.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel6.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel6.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel6.TabIndex = 121
        '
        'Cmb_Sub_Tipo_Reclamos
        '
        Me.Cmb_Sub_Tipo_Reclamos.DisplayMember = "Text"
        Me.Cmb_Sub_Tipo_Reclamos.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Sub_Tipo_Reclamos.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Cmb_Sub_Tipo_Reclamos.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Sub_Tipo_Reclamos.ItemHeight = 16
        Me.Cmb_Sub_Tipo_Reclamos.Location = New System.Drawing.Point(484, 3)
        Me.Cmb_Sub_Tipo_Reclamos.Name = "Cmb_Sub_Tipo_Reclamos"
        Me.Cmb_Sub_Tipo_Reclamos.Size = New System.Drawing.Size(248, 22)
        Me.Cmb_Sub_Tipo_Reclamos.TabIndex = 116
        '
        'LabelX14
        '
        Me.LabelX14.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX14.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX14.ForeColor = System.Drawing.Color.Black
        Me.LabelX14.Location = New System.Drawing.Point(401, 2)
        Me.LabelX14.Name = "LabelX14"
        Me.LabelX14.Size = New System.Drawing.Size(59, 23)
        Me.LabelX14.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX14.TabIndex = 117
        Me.LabelX14.Text = "Sub-tipo"
        '
        'Cmb_Tipo_Reclamo
        '
        Me.Cmb_Tipo_Reclamo.DisplayMember = "Text"
        Me.Cmb_Tipo_Reclamo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Tipo_Reclamo.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Cmb_Tipo_Reclamo.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Tipo_Reclamo.ItemHeight = 16
        Me.Cmb_Tipo_Reclamo.Location = New System.Drawing.Point(115, 3)
        Me.Cmb_Tipo_Reclamo.Name = "Cmb_Tipo_Reclamo"
        Me.Cmb_Tipo_Reclamo.Size = New System.Drawing.Size(280, 22)
        Me.Cmb_Tipo_Reclamo.TabIndex = 8
        '
        'LabelX11
        '
        Me.LabelX11.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX11.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX11.ForeColor = System.Drawing.Color.Black
        Me.LabelX11.Location = New System.Drawing.Point(6, 3)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(136, 23)
        Me.LabelX11.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX11.TabIndex = 110
        Me.LabelX11.Text = "Tipo de reclamo"
        '
        'Btn_Buscar_Vendedor
        '
        Me.Btn_Buscar_Vendedor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Buscar_Vendedor.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Buscar_Vendedor.Image = CType(resources.GetObject("Btn_Buscar_Vendedor.Image"), System.Drawing.Image)
        Me.Btn_Buscar_Vendedor.Location = New System.Drawing.Point(401, 32)
        Me.Btn_Buscar_Vendedor.Name = "Btn_Buscar_Vendedor"
        Me.Btn_Buscar_Vendedor.Size = New System.Drawing.Size(53, 22)
        Me.Btn_Buscar_Vendedor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Buscar_Vendedor.TabIndex = 114
        Me.Btn_Buscar_Vendedor.TabStop = False
        Me.Btn_Buscar_Vendedor.Tooltip = "Buscar Vendedor"
        '
        'Txt_Vendedor
        '
        '
        '
        '
        Me.Txt_Vendedor.Border.Class = "TextBoxBorder"
        Me.Txt_Vendedor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Vendedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Vendedor.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Vendedor.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Vendedor.ForeColor = System.Drawing.Color.Black
        Me.Txt_Vendedor.Location = New System.Drawing.Point(115, 33)
        Me.Txt_Vendedor.MaxLength = 20
        Me.Txt_Vendedor.Name = "Txt_Vendedor"
        Me.Txt_Vendedor.ReadOnly = True
        Me.Txt_Vendedor.Size = New System.Drawing.Size(280, 22)
        Me.Txt_Vendedor.TabIndex = 10
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
        Me.LabelX1.Location = New System.Drawing.Point(6, 32)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(64, 23)
        Me.LabelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX1.TabIndex = 112
        Me.LabelX1.Text = "Vendedor"
        '
        'GroupPanel5
        '
        Me.GroupPanel5.BackColor = System.Drawing.Color.White
        Me.GroupPanel5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel5.Controls.Add(Me.Txt_Email_Contacto)
        Me.GroupPanel5.Controls.Add(Me.LabelX7)
        Me.GroupPanel5.Controls.Add(Me.Txt_Nombre_Contacto)
        Me.GroupPanel5.Controls.Add(Me.Btn_Buscar_Cliente)
        Me.GroupPanel5.Controls.Add(Me.LabelX9)
        Me.GroupPanel5.Controls.Add(Me.Txt_Cliente)
        Me.GroupPanel5.Controls.Add(Me.LabelX4)
        Me.GroupPanel5.Controls.Add(Me.Txt_Telefono_Contacto)
        Me.GroupPanel5.Controls.Add(Me.Txt_Direccion)
        Me.GroupPanel5.Controls.Add(Me.LabelX6)
        Me.GroupPanel5.Controls.Add(Me.LabelX13)
        Me.GroupPanel5.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel5.Location = New System.Drawing.Point(11, 3)
        Me.GroupPanel5.Name = "GroupPanel5"
        Me.GroupPanel5.Size = New System.Drawing.Size(741, 116)
        '
        '
        '
        Me.GroupPanel5.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel5.Style.BackColorGradientAngle = 90
        Me.GroupPanel5.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel5.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel5.Style.BorderBottomWidth = 1
        Me.GroupPanel5.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel5.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel5.Style.BorderLeftWidth = 1
        Me.GroupPanel5.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel5.Style.BorderRightWidth = 1
        Me.GroupPanel5.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel5.Style.BorderTopWidth = 1
        Me.GroupPanel5.Style.CornerDiameter = 4
        Me.GroupPanel5.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel5.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel5.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel5.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel5.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel5.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel5.TabIndex = 120
        '
        'Txt_Email_Contacto
        '
        Me.Txt_Email_Contacto.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Email_Contacto.Border.Class = "TextBoxBorder"
        Me.Txt_Email_Contacto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Email_Contacto.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Email_Contacto.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Email_Contacto.FocusHighlightEnabled = True
        Me.Txt_Email_Contacto.ForeColor = System.Drawing.Color.Black
        Me.Txt_Email_Contacto.Location = New System.Drawing.Point(287, 86)
        Me.Txt_Email_Contacto.MaxLength = 100
        Me.Txt_Email_Contacto.Name = "Txt_Email_Contacto"
        Me.Txt_Email_Contacto.Size = New System.Drawing.Size(386, 22)
        Me.Txt_Email_Contacto.TabIndex = 122
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
        Me.LabelX7.Location = New System.Drawing.Point(244, 86)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(37, 23)
        Me.LabelX7.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX7.TabIndex = 123
        Me.LabelX7.Text = "Email"
        '
        'Txt_Nombre_Contacto
        '
        Me.Txt_Nombre_Contacto.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Nombre_Contacto.Border.Class = "TextBoxBorder"
        Me.Txt_Nombre_Contacto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Nombre_Contacto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Nombre_Contacto.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Nombre_Contacto.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Nombre_Contacto.FocusHighlightEnabled = True
        Me.Txt_Nombre_Contacto.ForeColor = System.Drawing.Color.Black
        Me.Txt_Nombre_Contacto.Location = New System.Drawing.Point(66, 59)
        Me.Txt_Nombre_Contacto.MaxLength = 50
        Me.Txt_Nombre_Contacto.Name = "Txt_Nombre_Contacto"
        Me.Txt_Nombre_Contacto.Size = New System.Drawing.Size(607, 22)
        Me.Txt_Nombre_Contacto.TabIndex = 2
        '
        'Btn_Buscar_Cliente
        '
        Me.Btn_Buscar_Cliente.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Buscar_Cliente.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Buscar_Cliente.Image = CType(resources.GetObject("Btn_Buscar_Cliente.Image"), System.Drawing.Image)
        Me.Btn_Buscar_Cliente.Location = New System.Drawing.Point(679, 8)
        Me.Btn_Buscar_Cliente.Name = "Btn_Buscar_Cliente"
        Me.Btn_Buscar_Cliente.Size = New System.Drawing.Size(53, 21)
        Me.Btn_Buscar_Cliente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Buscar_Cliente.TabIndex = 121
        Me.Btn_Buscar_Cliente.TabStop = False
        Me.Btn_Buscar_Cliente.Tooltip = "Buscar Cliente"
        Me.Btn_Buscar_Cliente.Visible = False
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
        Me.LabelX9.Location = New System.Drawing.Point(6, 60)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(54, 23)
        Me.LabelX9.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX9.TabIndex = 72
        Me.LabelX9.Text = "Contacto"
        '
        'Txt_Cliente
        '
        Me.Txt_Cliente.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Cliente.Border.Class = "TextBoxBorder"
        Me.Txt_Cliente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Cliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Cliente.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Cliente.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Cliente.FocusHighlightEnabled = True
        Me.Txt_Cliente.ForeColor = System.Drawing.Color.Black
        Me.Txt_Cliente.Location = New System.Drawing.Point(66, 7)
        Me.Txt_Cliente.MaxLength = 50
        Me.Txt_Cliente.Name = "Txt_Cliente"
        Me.Txt_Cliente.ReadOnly = True
        Me.Txt_Cliente.Size = New System.Drawing.Size(607, 22)
        Me.Txt_Cliente.TabIndex = 0
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(6, 5)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(133, 23)
        Me.LabelX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX4.TabIndex = 72
        Me.LabelX4.Text = "Cliente"
        '
        'Txt_Telefono_Contacto
        '
        Me.Txt_Telefono_Contacto.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Telefono_Contacto.Border.Class = "TextBoxBorder"
        Me.Txt_Telefono_Contacto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Telefono_Contacto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Telefono_Contacto.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Telefono_Contacto.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Telefono_Contacto.FocusHighlightEnabled = True
        Me.Txt_Telefono_Contacto.ForeColor = System.Drawing.Color.Black
        Me.Txt_Telefono_Contacto.Location = New System.Drawing.Point(66, 86)
        Me.Txt_Telefono_Contacto.MaxLength = 20
        Me.Txt_Telefono_Contacto.Name = "Txt_Telefono_Contacto"
        Me.Txt_Telefono_Contacto.Size = New System.Drawing.Size(135, 22)
        Me.Txt_Telefono_Contacto.TabIndex = 3
        '
        'Txt_Direccion
        '
        Me.Txt_Direccion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Direccion.Border.Class = "TextBoxBorder"
        Me.Txt_Direccion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Direccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Direccion.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Direccion.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Direccion.FocusHighlightEnabled = True
        Me.Txt_Direccion.ForeColor = System.Drawing.Color.Black
        Me.Txt_Direccion.Location = New System.Drawing.Point(66, 32)
        Me.Txt_Direccion.MaxLength = 20
        Me.Txt_Direccion.Name = "Txt_Direccion"
        Me.Txt_Direccion.ReadOnly = True
        Me.Txt_Direccion.Size = New System.Drawing.Size(607, 22)
        Me.Txt_Direccion.TabIndex = 1
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
        Me.LabelX6.Location = New System.Drawing.Point(6, 86)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(54, 23)
        Me.LabelX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX6.TabIndex = 65
        Me.LabelX6.Text = "Teléfono"
        '
        'LabelX13
        '
        Me.LabelX13.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX13.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX13.ForeColor = System.Drawing.Color.Black
        Me.LabelX13.Location = New System.Drawing.Point(6, 31)
        Me.LabelX13.Name = "LabelX13"
        Me.LabelX13.Size = New System.Drawing.Size(133, 23)
        Me.LabelX13.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX13.TabIndex = 65
        Me.LabelX13.Text = "Dirección"
        '
        'GroupPanel3
        '
        Me.GroupPanel3.BackColor = System.Drawing.Color.White
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.Cmb_Suc_Elaboracion)
        Me.GroupPanel3.Controls.Add(Me.Btn_Buscar_Producto)
        Me.GroupPanel3.Controls.Add(Me.Dtp_Fecha_Elab)
        Me.GroupPanel3.Controls.Add(Me.Txt_Producto)
        Me.GroupPanel3.Controls.Add(Me.LabelX3)
        Me.GroupPanel3.Controls.Add(Me.LabelX5)
        Me.GroupPanel3.Controls.Add(Me.LabelX2)
        Me.GroupPanel3.Controls.Add(Me.Txt_Cantidad)
        Me.GroupPanel3.Controls.Add(Me.LabelX8)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Location = New System.Drawing.Point(11, 125)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(741, 67)
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
        Me.GroupPanel3.TabIndex = 119
        '
        'Cmb_Suc_Elaboracion
        '
        Me.Cmb_Suc_Elaboracion.DisplayMember = "Text"
        Me.Cmb_Suc_Elaboracion.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Suc_Elaboracion.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Cmb_Suc_Elaboracion.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Suc_Elaboracion.ItemHeight = 16
        Me.Cmb_Suc_Elaboracion.Location = New System.Drawing.Point(198, 32)
        Me.Cmb_Suc_Elaboracion.Name = "Cmb_Suc_Elaboracion"
        Me.Cmb_Suc_Elaboracion.Size = New System.Drawing.Size(197, 22)
        Me.Cmb_Suc_Elaboracion.TabIndex = 9
        '
        'Btn_Buscar_Producto
        '
        Me.Btn_Buscar_Producto.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Buscar_Producto.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Buscar_Producto.Image = CType(resources.GetObject("Btn_Buscar_Producto.Image"), System.Drawing.Image)
        Me.Btn_Buscar_Producto.Location = New System.Drawing.Point(679, 4)
        Me.Btn_Buscar_Producto.Name = "Btn_Buscar_Producto"
        Me.Btn_Buscar_Producto.Size = New System.Drawing.Size(53, 21)
        Me.Btn_Buscar_Producto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Buscar_Producto.TabIndex = 118
        Me.Btn_Buscar_Producto.TabStop = False
        Me.Btn_Buscar_Producto.Tooltip = "Buscar Producto"
        '
        'Dtp_Fecha_Elab
        '
        Me.Dtp_Fecha_Elab.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_Fecha_Elab.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Elab.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Elab.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Elab.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Elab.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Elab.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Elab.Location = New System.Drawing.Point(484, 32)
        '
        '
        '
        Me.Dtp_Fecha_Elab.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Elab.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Elab.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Elab.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Elab.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Elab.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Elab.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Elab.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Elab.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Elab.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Elab.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Elab.MonthCalendar.DisplayMonth = New Date(2019, 4, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Elab.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_Fecha_Elab.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Elab.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Elab.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Elab.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Elab.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Elab.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Elab.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Elab.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Elab.Name = "Dtp_Fecha_Elab"
        Me.Dtp_Fecha_Elab.Size = New System.Drawing.Size(84, 22)
        Me.Dtp_Fecha_Elab.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Elab.TabIndex = 7
        Me.Dtp_Fecha_Elab.TabStop = False
        '
        'Txt_Producto
        '
        Me.Txt_Producto.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Producto.Border.Class = "TextBoxBorder"
        Me.Txt_Producto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Producto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Producto.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Producto.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Producto.FocusHighlightEnabled = True
        Me.Txt_Producto.ForeColor = System.Drawing.Color.Black
        Me.Txt_Producto.Location = New System.Drawing.Point(66, 3)
        Me.Txt_Producto.MaxLength = 50
        Me.Txt_Producto.Name = "Txt_Producto"
        Me.Txt_Producto.ReadOnly = True
        Me.Txt_Producto.Size = New System.Drawing.Size(607, 22)
        Me.Txt_Producto.TabIndex = 5
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(6, 6)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(133, 23)
        Me.LabelX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX3.TabIndex = 72
        Me.LabelX3.Text = "Producto"
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(138, 31)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(63, 23)
        Me.LabelX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX5.TabIndex = 115
        Me.LabelX5.Text = "Suc. Elab."
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
        Me.LabelX2.Location = New System.Drawing.Point(401, 32)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(77, 22)
        Me.LabelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX2.TabIndex = 116
        Me.LabelX2.Text = "Fecha Elab."
        '
        'Txt_Cantidad
        '
        Me.Txt_Cantidad.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Cantidad.Border.Class = "TextBoxBorder"
        Me.Txt_Cantidad.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Cantidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Cantidad.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Cantidad.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Cantidad.FocusHighlightEnabled = True
        Me.Txt_Cantidad.ForeColor = System.Drawing.Color.Black
        Me.Txt_Cantidad.Location = New System.Drawing.Point(66, 31)
        Me.Txt_Cantidad.MaxLength = 20
        Me.Txt_Cantidad.Name = "Txt_Cantidad"
        Me.Txt_Cantidad.Size = New System.Drawing.Size(66, 22)
        Me.Txt_Cantidad.TabIndex = 6
        Me.Txt_Cantidad.Text = "30.000 KG."
        Me.Txt_Cantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.LabelX8.Location = New System.Drawing.Point(6, 31)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(133, 23)
        Me.LabelX8.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX8.TabIndex = 65
        Me.LabelX8.Text = "Cantidad"
        '
        'Imagenes_32x32
        '
        Me.Imagenes_32x32.ImageStream = CType(resources.GetObject("Imagenes_32x32.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagenes_32x32.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagenes_32x32.Images.SetKeyName(0, "warning.png")
        Me.Imagenes_32x32.Images.SetKeyName(1, "Warning 32.png")
        '
        'Frm_Rc_01_Ingreso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 578)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Rc_01_Ingreso"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "INGRESO"
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.Grilla_Preguntas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel6.ResumeLayout(False)
        Me.GroupPanel5.ResumeLayout(False)
        Me.GroupPanel3.ResumeLayout(False)
        CType(Me.Dtp_Fecha_Elab, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Editar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Cancelar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Txt_Descripcion_Reclamo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Cmb_Tipo_Reclamo As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Buscar_Vendedor As DevComponents.DotNetBar.ButtonX
    Public WithEvents Txt_Vendedor As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Cmb_Suc_Elaboracion As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupPanel6 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupPanel5 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Btn_Buscar_Cliente As DevComponents.DotNetBar.ButtonX
    Public WithEvents Txt_Cliente As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Direccion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Btn_Buscar_Producto As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Dtp_Fecha_Elab As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Producto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Cantidad As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Nombre_Contacto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Telefono_Contacto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Imagenes_32x32 As ImageList
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Grilla_Preguntas As DevComponents.DotNetBar.Controls.DataGridViewX
    Public WithEvents Txt_Email_Contacto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Cmb_Sub_Tipo_Reclamos As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX14 As DevComponents.DotNetBar.LabelX
    Public WithEvents Btn_Archivos_Adjuntos As DevComponents.DotNetBar.ButtonItem
End Class
