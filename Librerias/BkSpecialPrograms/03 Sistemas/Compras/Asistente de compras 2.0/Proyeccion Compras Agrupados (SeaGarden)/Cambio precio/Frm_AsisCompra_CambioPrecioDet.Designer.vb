<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_AsisCompra_CambioPrecioDet
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
        Dim DataGridViewCellStyle64 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle65 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle66 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_AsisCompra_CambioPrecioDet))
        Dim DataGridViewCellStyle67 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle68 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle69 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle70 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle71 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle72 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Grilla_Resultado = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Actualizar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Exportar_Excel = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Grilla_Precios = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Grilla_Detalle = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.GroupPanel4 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Input_CantNoQuiebra = New DevComponents.Editors.IntegerInput()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Lista = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_FechaEstudioVenta = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Grilla_Resultado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.Grilla_Precios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel3.SuspendLayout()
        CType(Me.Grilla_Detalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel4.SuspendLayout()
        CType(Me.Input_CantNoQuiebra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Grilla_Resultado)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 56)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(886, 81)
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
        Me.GroupPanel1.TabIndex = 168
        Me.GroupPanel1.Text = "Calsificación de producto"
        '
        'Grilla_Resultado
        '
        Me.Grilla_Resultado.AllowUserToAddRows = False
        Me.Grilla_Resultado.AllowUserToDeleteRows = False
        Me.Grilla_Resultado.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle64.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle64.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle64.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle64.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle64.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle64.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle64.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Resultado.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle64
        Me.Grilla_Resultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle65.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle65.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle65.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle65.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle65.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle65.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle65.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Resultado.DefaultCellStyle = DataGridViewCellStyle65
        Me.Grilla_Resultado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Resultado.EnableHeadersVisualStyles = False
        Me.Grilla_Resultado.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Resultado.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Resultado.Name = "Grilla_Resultado"
        Me.Grilla_Resultado.ReadOnly = True
        DataGridViewCellStyle66.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle66.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle66.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle66.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle66.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle66.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle66.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Resultado.RowHeadersDefaultCellStyle = DataGridViewCellStyle66
        Me.Grilla_Resultado.Size = New System.Drawing.Size(880, 58)
        Me.Grilla_Resultado.StandardTab = True
        Me.Grilla_Resultado.TabIndex = 27
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Actualizar, Me.Btn_Exportar_Excel})
        Me.Bar1.Location = New System.Drawing.Point(0, 631)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(910, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 167
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Actualizar
        '
        Me.Btn_Actualizar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Actualizar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Actualizar.Image = CType(resources.GetObject("Btn_Actualizar.Image"), System.Drawing.Image)
        Me.Btn_Actualizar.ImageAlt = CType(resources.GetObject("Btn_Actualizar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Actualizar.Name = "Btn_Actualizar"
        Me.Btn_Actualizar.Tooltip = "Actualizar"
        '
        'Btn_Exportar_Excel
        '
        Me.Btn_Exportar_Excel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Exportar_Excel.ForeColor = System.Drawing.Color.Black
        Me.Btn_Exportar_Excel.Image = CType(resources.GetObject("Btn_Exportar_Excel.Image"), System.Drawing.Image)
        Me.Btn_Exportar_Excel.ImageAlt = CType(resources.GetObject("Btn_Exportar_Excel.ImageAlt"), System.Drawing.Image)
        Me.Btn_Exportar_Excel.Name = "Btn_Exportar_Excel"
        Me.Btn_Exportar_Excel.Tooltip = "Exportar a Excel"
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Grilla_Precios)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(12, 143)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(886, 108)
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
        Me.GroupPanel2.TabIndex = 169
        Me.GroupPanel2.Text = "Productos clasificados y vendidos durante el periodo, junto con sus precios de li" &
    "sta."
        '
        'Grilla_Precios
        '
        Me.Grilla_Precios.AllowUserToAddRows = False
        Me.Grilla_Precios.AllowUserToDeleteRows = False
        Me.Grilla_Precios.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle67.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle67.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle67.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle67.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle67.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle67.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle67.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Precios.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle67
        Me.Grilla_Precios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle68.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle68.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle68.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle68.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle68.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle68.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle68.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Precios.DefaultCellStyle = DataGridViewCellStyle68
        Me.Grilla_Precios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Precios.EnableHeadersVisualStyles = False
        Me.Grilla_Precios.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Precios.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Precios.Name = "Grilla_Precios"
        Me.Grilla_Precios.ReadOnly = True
        DataGridViewCellStyle69.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle69.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle69.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle69.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle69.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle69.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle69.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Precios.RowHeadersDefaultCellStyle = DataGridViewCellStyle69
        Me.Grilla_Precios.Size = New System.Drawing.Size(880, 85)
        Me.Grilla_Precios.StandardTab = True
        Me.Grilla_Precios.TabIndex = 27
        '
        'GroupPanel3
        '
        Me.GroupPanel3.BackColor = System.Drawing.Color.White
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.Grilla_Detalle)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Location = New System.Drawing.Point(12, 257)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(886, 368)
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
        Me.GroupPanel3.TabIndex = 170
        Me.GroupPanel3.Text = "Detalle de ventas de cada producto clasificado y sus precios de venta, sin inclui" &
    "r los fletes según la lista de precios."
        '
        'Grilla_Detalle
        '
        Me.Grilla_Detalle.AllowUserToAddRows = False
        Me.Grilla_Detalle.AllowUserToDeleteRows = False
        Me.Grilla_Detalle.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle70.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle70.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle70.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle70.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle70.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle70.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle70.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Detalle.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle70
        Me.Grilla_Detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle71.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle71.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle71.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle71.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle71.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle71.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle71.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Detalle.DefaultCellStyle = DataGridViewCellStyle71
        Me.Grilla_Detalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Detalle.EnableHeadersVisualStyles = False
        Me.Grilla_Detalle.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Detalle.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Detalle.Name = "Grilla_Detalle"
        Me.Grilla_Detalle.ReadOnly = True
        DataGridViewCellStyle72.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle72.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle72.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle72.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle72.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle72.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle72.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Detalle.RowHeadersDefaultCellStyle = DataGridViewCellStyle72
        Me.Grilla_Detalle.Size = New System.Drawing.Size(880, 345)
        Me.Grilla_Detalle.StandardTab = True
        Me.Grilla_Detalle.TabIndex = 27
        '
        'GroupPanel4
        '
        Me.GroupPanel4.BackColor = System.Drawing.Color.White
        Me.GroupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel4.Controls.Add(Me.Input_CantNoQuiebra)
        Me.GroupPanel4.Controls.Add(Me.LabelX1)
        Me.GroupPanel4.Controls.Add(Me.Txt_Lista)
        Me.GroupPanel4.Controls.Add(Me.LabelX3)
        Me.GroupPanel4.Controls.Add(Me.Lbl_FechaEstudioVenta)
        Me.GroupPanel4.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel4.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel4.Name = "GroupPanel4"
        Me.GroupPanel4.Size = New System.Drawing.Size(886, 38)
        '
        '
        '
        Me.GroupPanel4.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel4.Style.BackColorGradientAngle = 90
        Me.GroupPanel4.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel4.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderBottomWidth = 1
        Me.GroupPanel4.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel4.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderLeftWidth = 1
        Me.GroupPanel4.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderRightWidth = 1
        Me.GroupPanel4.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderTopWidth = 1
        Me.GroupPanel4.Style.CornerDiameter = 4
        Me.GroupPanel4.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel4.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel4.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel4.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel4.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel4.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel4.TabIndex = 171
        '
        'Input_CantNoQuiebra
        '
        Me.Input_CantNoQuiebra.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_CantNoQuiebra.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_CantNoQuiebra.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_CantNoQuiebra.ButtonCustom.Image = CType(resources.GetObject("Input_CantNoQuiebra.ButtonCustom.Image"), System.Drawing.Image)
        Me.Input_CantNoQuiebra.ButtonCustom.Visible = True
        Me.Input_CantNoQuiebra.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.Input_CantNoQuiebra.ForeColor = System.Drawing.Color.Black
        Me.Input_CantNoQuiebra.Location = New System.Drawing.Point(409, 4)
        Me.Input_CantNoQuiebra.Name = "Input_CantNoQuiebra"
        Me.Input_CantNoQuiebra.Size = New System.Drawing.Size(93, 22)
        Me.Input_CantNoQuiebra.TabIndex = 5
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(269, 4)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(134, 23)
        Me.LabelX1.TabIndex = 4
        Me.LabelX1.Text = "Cantidad no quiebra stock"
        '
        'Txt_Lista
        '
        Me.Txt_Lista.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Lista.Border.Class = "TextBoxBorder"
        Me.Txt_Lista.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Lista.ButtonCustom.Image = CType(resources.GetObject("Txt_Lista.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Lista.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Lista.ForeColor = System.Drawing.Color.Black
        Me.Txt_Lista.Location = New System.Drawing.Point(83, 4)
        Me.Txt_Lista.Name = "Txt_Lista"
        Me.Txt_Lista.PreventEnterBeep = True
        Me.Txt_Lista.ReadOnly = True
        Me.Txt_Lista.Size = New System.Drawing.Size(180, 22)
        Me.Txt_Lista.TabIndex = 3
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(0, 4)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(86, 23)
        Me.LabelX3.TabIndex = 2
        Me.LabelX3.Text = "Lista de precios"
        '
        'Lbl_FechaEstudioVenta
        '
        Me.Lbl_FechaEstudioVenta.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_FechaEstudioVenta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_FechaEstudioVenta.ForeColor = System.Drawing.Color.Black
        Me.Lbl_FechaEstudioVenta.Location = New System.Drawing.Point(536, 4)
        Me.Lbl_FechaEstudioVenta.Name = "Lbl_FechaEstudioVenta"
        Me.Lbl_FechaEstudioVenta.Size = New System.Drawing.Size(341, 23)
        Me.Lbl_FechaEstudioVenta.TabIndex = 0
        Me.Lbl_FechaEstudioVenta.Text = "Fecha de estudio de venta desde: <b>dd/MM/yyyy</b> hasta <b>dd/MM/yyyy</b>"
        '
        'Frm_AsisCompra_CambioPrecioDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(910, 672)
        Me.Controls.Add(Me.GroupPanel4)
        Me.Controls.Add(Me.GroupPanel3)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_AsisCompra_CambioPrecioDet"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DETALLE DE ESTUDIO DE PRODUCTO PARA INFORMAR SUGERENCIA DE CAMBIO DE PRECIO"
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.Grilla_Resultado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.Grilla_Precios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel3.ResumeLayout(False)
        CType(Me.Grilla_Detalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel4.ResumeLayout(False)
        CType(Me.Input_CantNoQuiebra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grilla_Resultado As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Actualizar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grilla_Precios As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grilla_Detalle As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents GroupPanel4 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Txt_Lista As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_FechaEstudioVenta As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Exportar_Excel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Input_CantNoQuiebra As DevComponents.Editors.IntegerInput
End Class
