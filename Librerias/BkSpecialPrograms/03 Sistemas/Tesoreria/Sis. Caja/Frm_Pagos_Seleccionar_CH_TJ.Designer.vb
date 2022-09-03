<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Pagos_Seleccionar_CH_TJ
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Pagos_Seleccionar_CH_TJ))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Aceptar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Limpiar = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Btn_Traer_Saldo = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Buscar_Emisor = New DevComponents.DotNetBar.ButtonX()
        Me.Input_CUOTAS_Nro_Cuotas = New DevComponents.Editors.IntegerInput()
        Me.Txt_VADP_Monto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_EMDP_Documento = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_NUCUDP_Nro_Documento = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_CUDP_Nro_Cuenta = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_SUEMDP_Sucursal = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Grilla_Ctas = New DevComponents.DotNetBar.Controls.DataGridViewX()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Input_CUOTAS_Nro_Cuotas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.Grilla_Ctas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Aceptar, Me.Btn_Limpiar})
        Me.Bar1.Location = New System.Drawing.Point(0, 339)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(446, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 39
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Aceptar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Aceptar.Image = CType(resources.GetObject("Btn_Aceptar.Image"), System.Drawing.Image)
        Me.Btn_Aceptar.ImageAlt = CType(resources.GetObject("Btn_Aceptar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Text = "ACEPTAR"
        '
        'Btn_Limpiar
        '
        Me.Btn_Limpiar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Limpiar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Limpiar.Image = CType(resources.GetObject("Btn_Limpiar.Image"), System.Drawing.Image)
        Me.Btn_Limpiar.ImageAlt = CType(resources.GetObject("Btn_Limpiar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Limpiar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Limpiar.Name = "Btn_Limpiar"
        Me.Btn_Limpiar.Tooltip = "Limpiar"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Btn_Traer_Saldo)
        Me.GroupPanel1.Controls.Add(Me.Btn_Buscar_Emisor)
        Me.GroupPanel1.Controls.Add(Me.Input_CUOTAS_Nro_Cuotas)
        Me.GroupPanel1.Controls.Add(Me.Txt_VADP_Monto)
        Me.GroupPanel1.Controls.Add(Me.LabelX1)
        Me.GroupPanel1.Controls.Add(Me.Txt_EMDP_Documento)
        Me.GroupPanel1.Controls.Add(Me.Txt_NUCUDP_Nro_Documento)
        Me.GroupPanel1.Controls.Add(Me.Txt_CUDP_Nro_Cuenta)
        Me.GroupPanel1.Controls.Add(Me.Txt_SUEMDP_Sucursal)
        Me.GroupPanel1.Controls.Add(Me.LabelX2)
        Me.GroupPanel1.Controls.Add(Me.LabelX3)
        Me.GroupPanel1.Controls.Add(Me.LabelX4)
        Me.GroupPanel1.Controls.Add(Me.LabelX6)
        Me.GroupPanel1.Controls.Add(Me.LabelX5)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(420, 198)
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
        Me.GroupPanel1.TabIndex = 40
        Me.GroupPanel1.Text = "Datos documento de pago"
        '
        'Btn_Traer_Saldo
        '
        Me.Btn_Traer_Saldo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Traer_Saldo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Traer_Saldo.Location = New System.Drawing.Point(281, 146)
        Me.Btn_Traer_Saldo.Name = "Btn_Traer_Saldo"
        Me.Btn_Traer_Saldo.Size = New System.Drawing.Size(97, 22)
        Me.Btn_Traer_Saldo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Traer_Saldo.TabIndex = 49
        Me.Btn_Traer_Saldo.TabStop = False
        Me.Btn_Traer_Saldo.Text = "<- Traer saldo."
        '
        'Btn_Buscar_Emisor
        '
        Me.Btn_Buscar_Emisor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Buscar_Emisor.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Buscar_Emisor.Image = CType(resources.GetObject("Btn_Buscar_Emisor.Image"), System.Drawing.Image)
        Me.Btn_Buscar_Emisor.ImageAlt = CType(resources.GetObject("Btn_Buscar_Emisor.ImageAlt"), System.Drawing.Image)
        Me.Btn_Buscar_Emisor.Location = New System.Drawing.Point(384, 12)
        Me.Btn_Buscar_Emisor.Name = "Btn_Buscar_Emisor"
        Me.Btn_Buscar_Emisor.Size = New System.Drawing.Size(25, 21)
        Me.Btn_Buscar_Emisor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Buscar_Emisor.TabIndex = 2
        Me.Btn_Buscar_Emisor.TabStop = False
        Me.Btn_Buscar_Emisor.Tooltip = "Buscar emisor"
        '
        'Input_CUOTAS_Nro_Cuotas
        '
        Me.Input_CUOTAS_Nro_Cuotas.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_CUOTAS_Nro_Cuotas.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_CUOTAS_Nro_Cuotas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_CUOTAS_Nro_Cuotas.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.Input_CUOTAS_Nro_Cuotas.ForeColor = System.Drawing.Color.Black
        Me.Input_CUOTAS_Nro_Cuotas.Location = New System.Drawing.Point(154, 119)
        Me.Input_CUOTAS_Nro_Cuotas.MaxValue = 48
        Me.Input_CUOTAS_Nro_Cuotas.MinValue = 1
        Me.Input_CUOTAS_Nro_Cuotas.Name = "Input_CUOTAS_Nro_Cuotas"
        Me.Input_CUOTAS_Nro_Cuotas.ShowUpDown = True
        Me.Input_CUOTAS_Nro_Cuotas.Size = New System.Drawing.Size(39, 22)
        Me.Input_CUOTAS_Nro_Cuotas.TabIndex = 48
        Me.Input_CUOTAS_Nro_Cuotas.Value = 1
        '
        'Txt_VADP_Monto
        '
        Me.Txt_VADP_Monto.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_VADP_Monto.Border.Class = "TextBoxBorder"
        Me.Txt_VADP_Monto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_VADP_Monto.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_VADP_Monto.ForeColor = System.Drawing.Color.Black
        Me.Txt_VADP_Monto.Location = New System.Drawing.Point(154, 146)
        Me.Txt_VADP_Monto.Name = "Txt_VADP_Monto"
        Me.Txt_VADP_Monto.PreventEnterBeep = True
        Me.Txt_VADP_Monto.Size = New System.Drawing.Size(121, 22)
        Me.Txt_VADP_Monto.TabIndex = 5
        Me.Txt_VADP_Monto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 10)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(117, 20)
        Me.LabelX1.TabIndex = 2
        Me.LabelX1.Text = "Emisor de documento"
        '
        'Txt_EMDP_Documento
        '
        Me.Txt_EMDP_Documento.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_EMDP_Documento.Border.Class = "TextBoxBorder"
        Me.Txt_EMDP_Documento.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_EMDP_Documento.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_EMDP_Documento.ForeColor = System.Drawing.Color.Black
        Me.Txt_EMDP_Documento.Location = New System.Drawing.Point(154, 11)
        Me.Txt_EMDP_Documento.MaxLength = 16
        Me.Txt_EMDP_Documento.Name = "Txt_EMDP_Documento"
        Me.Txt_EMDP_Documento.PreventEnterBeep = True
        Me.Txt_EMDP_Documento.Size = New System.Drawing.Size(224, 22)
        Me.Txt_EMDP_Documento.TabIndex = 41
        Me.Txt_EMDP_Documento.TabStop = False
        Me.Txt_EMDP_Documento.Text = " "
        '
        'Txt_NUCUDP_Nro_Documento
        '
        Me.Txt_NUCUDP_Nro_Documento.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_NUCUDP_Nro_Documento.Border.Class = "TextBoxBorder"
        Me.Txt_NUCUDP_Nro_Documento.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_NUCUDP_Nro_Documento.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_NUCUDP_Nro_Documento.ForeColor = System.Drawing.Color.Black
        Me.Txt_NUCUDP_Nro_Documento.Location = New System.Drawing.Point(154, 91)
        Me.Txt_NUCUDP_Nro_Documento.MaxLength = 8
        Me.Txt_NUCUDP_Nro_Documento.Name = "Txt_NUCUDP_Nro_Documento"
        Me.Txt_NUCUDP_Nro_Documento.PreventEnterBeep = True
        Me.Txt_NUCUDP_Nro_Documento.Size = New System.Drawing.Size(121, 22)
        Me.Txt_NUCUDP_Nro_Documento.TabIndex = 3
        '
        'Txt_CUDP_Nro_Cuenta
        '
        Me.Txt_CUDP_Nro_Cuenta.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_CUDP_Nro_Cuenta.Border.Class = "TextBoxBorder"
        Me.Txt_CUDP_Nro_Cuenta.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_CUDP_Nro_Cuenta.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_CUDP_Nro_Cuenta.ForeColor = System.Drawing.Color.Black
        Me.Txt_CUDP_Nro_Cuenta.Location = New System.Drawing.Point(154, 64)
        Me.Txt_CUDP_Nro_Cuenta.MaxLength = 16
        Me.Txt_CUDP_Nro_Cuenta.Name = "Txt_CUDP_Nro_Cuenta"
        Me.Txt_CUDP_Nro_Cuenta.PreventEnterBeep = True
        Me.Txt_CUDP_Nro_Cuenta.Size = New System.Drawing.Size(121, 22)
        Me.Txt_CUDP_Nro_Cuenta.TabIndex = 2
        Me.Txt_CUDP_Nro_Cuenta.Text = " "
        '
        'Txt_SUEMDP_Sucursal
        '
        Me.Txt_SUEMDP_Sucursal.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_SUEMDP_Sucursal.Border.Class = "TextBoxBorder"
        Me.Txt_SUEMDP_Sucursal.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_SUEMDP_Sucursal.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_SUEMDP_Sucursal.ForeColor = System.Drawing.Color.Black
        Me.Txt_SUEMDP_Sucursal.Location = New System.Drawing.Point(154, 39)
        Me.Txt_SUEMDP_Sucursal.MaxLength = 3
        Me.Txt_SUEMDP_Sucursal.Name = "Txt_SUEMDP_Sucursal"
        Me.Txt_SUEMDP_Sucursal.PreventEnterBeep = True
        Me.Txt_SUEMDP_Sucursal.Size = New System.Drawing.Size(37, 22)
        Me.Txt_SUEMDP_Sucursal.TabIndex = 1
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 37)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(117, 20)
        Me.LabelX2.TabIndex = 3
        Me.LabelX2.Text = "Sucursal"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(3, 64)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(117, 20)
        Me.LabelX3.TabIndex = 4
        Me.LabelX3.Text = "Número de cuenta"
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(3, 91)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(117, 20)
        Me.LabelX4.TabIndex = 5
        Me.LabelX4.Text = "Número de documento"
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(3, 146)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(117, 18)
        Me.LabelX6.TabIndex = 7
        Me.LabelX6.Text = "Monto $"
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Enabled = False
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(3, 119)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(117, 18)
        Me.LabelX5.TabIndex = 6
        Me.LabelX5.Text = "Número de cuotas"
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Grilla_Ctas)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(12, 219)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(420, 114)
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
        Me.GroupPanel2.TabIndex = 47
        Me.GroupPanel2.Text = "Cuentas de la entidad"
        '
        'Grilla_Ctas
        '
        Me.Grilla_Ctas.AllowUserToAddRows = False
        Me.Grilla_Ctas.AllowUserToDeleteRows = False
        Me.Grilla_Ctas.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Ctas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grilla_Ctas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Ctas.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grilla_Ctas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Ctas.EnableHeadersVisualStyles = False
        Me.Grilla_Ctas.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Ctas.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Ctas.Name = "Grilla_Ctas"
        Me.Grilla_Ctas.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Ctas.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla_Ctas.Size = New System.Drawing.Size(414, 91)
        Me.Grilla_Ctas.StandardTab = True
        Me.Grilla_Ctas.TabIndex = 28
        '
        'Frm_Pagos_Seleccionar_CH_TJ
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(446, 380)
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
        Me.Name = "Frm_Pagos_Seleccionar_CH_TJ"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.Input_CUOTAS_Nro_Cuotas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.Grilla_Ctas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Public WithEvents Btn_Aceptar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_CUDP_Nro_Cuenta As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_SUEMDP_Sucursal As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_NUCUDP_Nro_Documento As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_EMDP_Documento As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grilla_Ctas As DevComponents.DotNetBar.Controls.DataGridViewX
    Public WithEvents Btn_Buscar_Emisor As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Input_CUOTAS_Nro_Cuotas As DevComponents.Editors.IntegerInput
    Public WithEvents Btn_Traer_Saldo As DevComponents.DotNetBar.ButtonX
    Public WithEvents Txt_VADP_Monto As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Public WithEvents Btn_Limpiar As DevComponents.DotNetBar.ButtonItem
End Class
