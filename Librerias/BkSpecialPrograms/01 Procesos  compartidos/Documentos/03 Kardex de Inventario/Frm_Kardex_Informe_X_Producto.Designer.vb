<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Kardex_Informe_X_Producto
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Kardex_Informe_X_Producto))
        Me.GrillaKardex = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.TextBoxX11 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.TextBoxX10 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.TextBoxX9 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.TxtPrPromPonderado = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.TxtPrecioNetoReal = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.TxtValorNetoLinea = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.TxtDsctoLinea = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.label = New DevComponents.DotNetBar.LabelX()
        Me.TxtPrecioUnitario = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.TxtTidopa = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.TxtEntidad = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.TxtFechaEmisionHora = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.BtnIrAptincipio = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnIrAlFin = New DevComponents.DotNetBar.ButtonItem()
        Me.Lbl_NroDecimales = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_DecimalRestar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_DecimalAgregar = New DevComponents.DotNetBar.ButtonItem()
        Me.TxtNroLote = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX()
        Me.TxtDescripcionProducto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        CType(Me.GrillaKardex, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.GroupPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrillaKardex
        '
        Me.GrillaKardex.AllowUserToAddRows = False
        Me.GrillaKardex.AllowUserToDeleteRows = False
        Me.GrillaKardex.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GrillaKardex.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.GrillaKardex.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GrillaKardex.DefaultCellStyle = DataGridViewCellStyle2
        Me.GrillaKardex.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrillaKardex.EnableHeadersVisualStyles = False
        Me.GrillaKardex.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.GrillaKardex.Location = New System.Drawing.Point(0, 0)
        Me.GrillaKardex.Name = "GrillaKardex"
        Me.GrillaKardex.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GrillaKardex.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.GrillaKardex.Size = New System.Drawing.Size(1010, 348)
        Me.GrillaKardex.StandardTab = True
        Me.GrillaKardex.TabIndex = 27
        '
        'TextBoxX11
        '
        Me.TextBoxX11.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX11.Border.Class = "TextBoxBorder"
        Me.TextBoxX11.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX11.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX11.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX11.Location = New System.Drawing.Point(747, 75)
        Me.TextBoxX11.Name = "TextBoxX11"
        Me.TextBoxX11.PreventEnterBeep = True
        Me.TextBoxX11.ReadOnly = True
        Me.TextBoxX11.Size = New System.Drawing.Size(99, 22)
        Me.TextBoxX11.TabIndex = 21
        Me.TextBoxX11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TextBoxX11.Visible = False
        '
        'LabelX11
        '
        Me.LabelX11.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX11.ForeColor = System.Drawing.Color.Black
        Me.LabelX11.Location = New System.Drawing.Point(747, 57)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(99, 23)
        Me.LabelX11.TabIndex = 20
        Me.LabelX11.Text = "Precio unitario"
        Me.LabelX11.Visible = False
        '
        'TextBoxX10
        '
        Me.TextBoxX10.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX10.Border.Class = "TextBoxBorder"
        Me.TextBoxX10.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX10.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX10.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX10.Location = New System.Drawing.Point(642, 75)
        Me.TextBoxX10.Name = "TextBoxX10"
        Me.TextBoxX10.PreventEnterBeep = True
        Me.TextBoxX10.ReadOnly = True
        Me.TextBoxX10.Size = New System.Drawing.Size(99, 22)
        Me.TextBoxX10.TabIndex = 19
        Me.TextBoxX10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TextBoxX10.Visible = False
        '
        'LabelX10
        '
        Me.LabelX10.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.ForeColor = System.Drawing.Color.Black
        Me.LabelX10.Location = New System.Drawing.Point(642, 57)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(99, 23)
        Me.LabelX10.TabIndex = 18
        Me.LabelX10.Text = "Precio unitario"
        Me.LabelX10.Visible = False
        '
        'TextBoxX9
        '
        Me.TextBoxX9.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX9.Border.Class = "TextBoxBorder"
        Me.TextBoxX9.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX9.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX9.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX9.Location = New System.Drawing.Point(537, 75)
        Me.TextBoxX9.Name = "TextBoxX9"
        Me.TextBoxX9.PreventEnterBeep = True
        Me.TextBoxX9.ReadOnly = True
        Me.TextBoxX9.Size = New System.Drawing.Size(99, 22)
        Me.TextBoxX9.TabIndex = 17
        Me.TextBoxX9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TextBoxX9.Visible = False
        '
        'LabelX9
        '
        Me.LabelX9.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.ForeColor = System.Drawing.Color.Black
        Me.LabelX9.Location = New System.Drawing.Point(537, 57)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(99, 23)
        Me.LabelX9.TabIndex = 16
        Me.LabelX9.Text = "Precio unitario"
        Me.LabelX9.Visible = False
        '
        'TxtPrPromPonderado
        '
        Me.TxtPrPromPonderado.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtPrPromPonderado.Border.Class = "TextBoxBorder"
        Me.TxtPrPromPonderado.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtPrPromPonderado.DisabledBackColor = System.Drawing.Color.White
        Me.TxtPrPromPonderado.ForeColor = System.Drawing.Color.Black
        Me.TxtPrPromPonderado.Location = New System.Drawing.Point(432, 75)
        Me.TxtPrPromPonderado.Name = "TxtPrPromPonderado"
        Me.TxtPrPromPonderado.PreventEnterBeep = True
        Me.TxtPrPromPonderado.ReadOnly = True
        Me.TxtPrPromPonderado.Size = New System.Drawing.Size(99, 22)
        Me.TxtPrPromPonderado.TabIndex = 15
        Me.TxtPrPromPonderado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelX8
        '
        Me.LabelX8.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.ForeColor = System.Drawing.Color.Black
        Me.LabelX8.Location = New System.Drawing.Point(432, 57)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(99, 23)
        Me.LabelX8.TabIndex = 14
        Me.LabelX8.Text = "Pr. Prom. Ponder."
        '
        'TxtPrecioNetoReal
        '
        Me.TxtPrecioNetoReal.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtPrecioNetoReal.Border.Class = "TextBoxBorder"
        Me.TxtPrecioNetoReal.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtPrecioNetoReal.DisabledBackColor = System.Drawing.Color.White
        Me.TxtPrecioNetoReal.ForeColor = System.Drawing.Color.Black
        Me.TxtPrecioNetoReal.Location = New System.Drawing.Point(327, 75)
        Me.TxtPrecioNetoReal.Name = "TxtPrecioNetoReal"
        Me.TxtPrecioNetoReal.PreventEnterBeep = True
        Me.TxtPrecioNetoReal.ReadOnly = True
        Me.TxtPrecioNetoReal.Size = New System.Drawing.Size(99, 22)
        Me.TxtPrecioNetoReal.TabIndex = 13
        Me.TxtPrecioNetoReal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.ForeColor = System.Drawing.Color.Black
        Me.LabelX7.Location = New System.Drawing.Point(327, 57)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(99, 23)
        Me.LabelX7.TabIndex = 12
        Me.LabelX7.Text = "Precio Neto Real"
        '
        'TxtValorNetoLinea
        '
        Me.TxtValorNetoLinea.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtValorNetoLinea.Border.Class = "TextBoxBorder"
        Me.TxtValorNetoLinea.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtValorNetoLinea.DisabledBackColor = System.Drawing.Color.White
        Me.TxtValorNetoLinea.ForeColor = System.Drawing.Color.Black
        Me.TxtValorNetoLinea.Location = New System.Drawing.Point(222, 75)
        Me.TxtValorNetoLinea.Name = "TxtValorNetoLinea"
        Me.TxtValorNetoLinea.PreventEnterBeep = True
        Me.TxtValorNetoLinea.ReadOnly = True
        Me.TxtValorNetoLinea.Size = New System.Drawing.Size(99, 22)
        Me.TxtValorNetoLinea.TabIndex = 11
        Me.TxtValorNetoLinea.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(222, 57)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(112, 23)
        Me.LabelX6.TabIndex = 10
        Me.LabelX6.Text = "Valor Neto Línea"
        '
        'TxtDsctoLinea
        '
        Me.TxtDsctoLinea.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtDsctoLinea.Border.Class = "TextBoxBorder"
        Me.TxtDsctoLinea.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtDsctoLinea.DisabledBackColor = System.Drawing.Color.White
        Me.TxtDsctoLinea.ForeColor = System.Drawing.Color.Black
        Me.TxtDsctoLinea.Location = New System.Drawing.Point(117, 75)
        Me.TxtDsctoLinea.Name = "TxtDsctoLinea"
        Me.TxtDsctoLinea.PreventEnterBeep = True
        Me.TxtDsctoLinea.ReadOnly = True
        Me.TxtDsctoLinea.Size = New System.Drawing.Size(99, 22)
        Me.TxtDsctoLinea.TabIndex = 9
        Me.TxtDsctoLinea.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'label
        '
        Me.label.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.label.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.label.ForeColor = System.Drawing.Color.Black
        Me.label.Location = New System.Drawing.Point(117, 57)
        Me.label.Name = "label"
        Me.label.Size = New System.Drawing.Size(99, 23)
        Me.label.TabIndex = 8
        Me.label.Text = "Descuento Línea"
        '
        'TxtPrecioUnitario
        '
        Me.TxtPrecioUnitario.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtPrecioUnitario.Border.Class = "TextBoxBorder"
        Me.TxtPrecioUnitario.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtPrecioUnitario.DisabledBackColor = System.Drawing.Color.White
        Me.TxtPrecioUnitario.ForeColor = System.Drawing.Color.Black
        Me.TxtPrecioUnitario.Location = New System.Drawing.Point(12, 75)
        Me.TxtPrecioUnitario.Name = "TxtPrecioUnitario"
        Me.TxtPrecioUnitario.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPrecioUnitario.PreventEnterBeep = True
        Me.TxtPrecioUnitario.ReadOnly = True
        Me.TxtPrecioUnitario.Size = New System.Drawing.Size(99, 22)
        Me.TxtPrecioUnitario.TabIndex = 7
        Me.TxtPrecioUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(12, 57)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(99, 23)
        Me.LabelX4.TabIndex = 6
        Me.LabelX4.Text = "Precio unitario"
        '
        'TxtTidopa
        '
        Me.TxtTidopa.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtTidopa.Border.Class = "TextBoxBorder"
        Me.TxtTidopa.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtTidopa.DisabledBackColor = System.Drawing.Color.White
        Me.TxtTidopa.ForeColor = System.Drawing.Color.Black
        Me.TxtTidopa.Location = New System.Drawing.Point(619, 29)
        Me.TxtTidopa.Name = "TxtTidopa"
        Me.TxtTidopa.PreventEnterBeep = True
        Me.TxtTidopa.ReadOnly = True
        Me.TxtTidopa.Size = New System.Drawing.Size(227, 22)
        Me.TxtTidopa.TabIndex = 5
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(619, 11)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(227, 23)
        Me.LabelX3.TabIndex = 4
        Me.LabelX3.Text = "Documento base de la transacción"
        '
        'TxtEntidad
        '
        Me.TxtEntidad.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtEntidad.Border.Class = "TextBoxBorder"
        Me.TxtEntidad.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtEntidad.DisabledBackColor = System.Drawing.Color.White
        Me.TxtEntidad.ForeColor = System.Drawing.Color.Black
        Me.TxtEntidad.Location = New System.Drawing.Point(166, 29)
        Me.TxtEntidad.Name = "TxtEntidad"
        Me.TxtEntidad.PreventEnterBeep = True
        Me.TxtEntidad.ReadOnly = True
        Me.TxtEntidad.Size = New System.Drawing.Size(447, 22)
        Me.TxtEntidad.TabIndex = 3
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(166, 11)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(112, 23)
        Me.LabelX2.TabIndex = 2
        Me.LabelX2.Text = "Entidad"
        '
        'TxtFechaEmisionHora
        '
        Me.TxtFechaEmisionHora.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtFechaEmisionHora.Border.Class = "TextBoxBorder"
        Me.TxtFechaEmisionHora.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtFechaEmisionHora.DisabledBackColor = System.Drawing.Color.White
        Me.TxtFechaEmisionHora.ForeColor = System.Drawing.Color.Black
        Me.TxtFechaEmisionHora.Location = New System.Drawing.Point(12, 29)
        Me.TxtFechaEmisionHora.Name = "TxtFechaEmisionHora"
        Me.TxtFechaEmisionHora.PreventEnterBeep = True
        Me.TxtFechaEmisionHora.ReadOnly = True
        Me.TxtFechaEmisionHora.Size = New System.Drawing.Size(148, 22)
        Me.TxtFechaEmisionHora.TabIndex = 1
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(12, 11)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(112, 23)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "Fecha Emisión/Hora"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnIrAptincipio, Me.BtnIrAlFin, Me.Btn_DecimalAgregar, Me.Btn_DecimalRestar, Me.Lbl_NroDecimales})
        Me.Bar2.Location = New System.Drawing.Point(0, 560)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(1033, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 40
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'BtnIrAptincipio
        '
        Me.BtnIrAptincipio.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnIrAptincipio.ForeColor = System.Drawing.Color.Black
        Me.BtnIrAptincipio.Image = CType(resources.GetObject("BtnIrAptincipio.Image"), System.Drawing.Image)
        Me.BtnIrAptincipio.ImageAlt = CType(resources.GetObject("BtnIrAptincipio.ImageAlt"), System.Drawing.Image)
        Me.BtnIrAptincipio.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnIrAptincipio.Name = "BtnIrAptincipio"
        Me.BtnIrAptincipio.Tooltip = "Ir al primer registro"
        '
        'BtnIrAlFin
        '
        Me.BtnIrAlFin.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnIrAlFin.ForeColor = System.Drawing.Color.Black
        Me.BtnIrAlFin.Image = CType(resources.GetObject("BtnIrAlFin.Image"), System.Drawing.Image)
        Me.BtnIrAlFin.ImageAlt = CType(resources.GetObject("BtnIrAlFin.ImageAlt"), System.Drawing.Image)
        Me.BtnIrAlFin.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnIrAlFin.Name = "BtnIrAlFin"
        Me.BtnIrAlFin.Tooltip = "Ir al último registro"
        '
        'Lbl_NroDecimales
        '
        Me.Lbl_NroDecimales.BorderType = DevComponents.DotNetBar.eBorderType.Sunken
        Me.Lbl_NroDecimales.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_NroDecimales.ForeColor = System.Drawing.Color.Black
        Me.Lbl_NroDecimales.Name = "Lbl_NroDecimales"
        Me.Lbl_NroDecimales.Text = "0,00000"
        Me.Lbl_NroDecimales.TextAlignment = System.Drawing.StringAlignment.Far
        Me.Lbl_NroDecimales.Tooltip = "2 decimales"
        '
        'Btn_DecimalRestar
        '
        Me.Btn_DecimalRestar.Image = CType(resources.GetObject("Btn_DecimalRestar.Image"), System.Drawing.Image)
        Me.Btn_DecimalRestar.ImageAlt = CType(resources.GetObject("Btn_DecimalRestar.ImageAlt"), System.Drawing.Image)
        Me.Btn_DecimalRestar.Name = "Btn_DecimalRestar"
        Me.Btn_DecimalRestar.Tooltip = "Disminuir decimales"
        '
        'Btn_DecimalAgregar
        '
        Me.Btn_DecimalAgregar.Image = CType(resources.GetObject("Btn_DecimalAgregar.Image"), System.Drawing.Image)
        Me.Btn_DecimalAgregar.ImageAlt = CType(resources.GetObject("Btn_DecimalAgregar.ImageAlt"), System.Drawing.Image)
        Me.Btn_DecimalAgregar.Name = "Btn_DecimalAgregar"
        Me.Btn_DecimalAgregar.Tooltip = "Aumentar decimales"
        '
        'TxtNroLote
        '
        Me.TxtNroLote.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtNroLote.Border.Class = "TextBoxBorder"
        Me.TxtNroLote.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtNroLote.DisabledBackColor = System.Drawing.Color.White
        Me.TxtNroLote.ForeColor = System.Drawing.Color.Black
        Me.TxtNroLote.Location = New System.Drawing.Point(632, 13)
        Me.TxtNroLote.Name = "TxtNroLote"
        Me.TxtNroLote.PreventEnterBeep = True
        Me.TxtNroLote.ReadOnly = True
        Me.TxtNroLote.Size = New System.Drawing.Size(241, 22)
        Me.TxtNroLote.TabIndex = 44
        '
        'LabelX12
        '
        Me.LabelX12.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX12.ForeColor = System.Drawing.Color.Black
        Me.LabelX12.Location = New System.Drawing.Point(632, -5)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(112, 23)
        Me.LabelX12.TabIndex = 43
        Me.LabelX12.Text = "Nro. de Lote"
        '
        'TxtDescripcionProducto
        '
        Me.TxtDescripcionProducto.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtDescripcionProducto.Border.Class = "TextBoxBorder"
        Me.TxtDescripcionProducto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtDescripcionProducto.DisabledBackColor = System.Drawing.Color.White
        Me.TxtDescripcionProducto.ForeColor = System.Drawing.Color.Black
        Me.TxtDescripcionProducto.Location = New System.Drawing.Point(9, 13)
        Me.TxtDescripcionProducto.Name = "TxtDescripcionProducto"
        Me.TxtDescripcionProducto.PreventEnterBeep = True
        Me.TxtDescripcionProducto.ReadOnly = True
        Me.TxtDescripcionProducto.Size = New System.Drawing.Size(617, 22)
        Me.TxtDescripcionProducto.TabIndex = 42
        '
        'LabelX13
        '
        Me.LabelX13.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX13.ForeColor = System.Drawing.Color.Black
        Me.LabelX13.Location = New System.Drawing.Point(9, -5)
        Me.LabelX13.Name = "LabelX13"
        Me.LabelX13.Size = New System.Drawing.Size(112, 23)
        Me.LabelX13.TabIndex = 41
        Me.LabelX13.Text = "Producto"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.GrillaKardex)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(9, 41)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(1016, 371)
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
        Me.GroupPanel1.TabIndex = 45
        Me.GroupPanel1.Text = "Detalle del kardex..."
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.TxtTidopa)
        Me.GroupPanel2.Controls.Add(Me.TxtDsctoLinea)
        Me.GroupPanel2.Controls.Add(Me.TxtPrecioUnitario)
        Me.GroupPanel2.Controls.Add(Me.TxtFechaEmisionHora)
        Me.GroupPanel2.Controls.Add(Me.TxtEntidad)
        Me.GroupPanel2.Controls.Add(Me.TextBoxX11)
        Me.GroupPanel2.Controls.Add(Me.LabelX1)
        Me.GroupPanel2.Controls.Add(Me.LabelX11)
        Me.GroupPanel2.Controls.Add(Me.TextBoxX10)
        Me.GroupPanel2.Controls.Add(Me.LabelX2)
        Me.GroupPanel2.Controls.Add(Me.LabelX10)
        Me.GroupPanel2.Controls.Add(Me.TextBoxX9)
        Me.GroupPanel2.Controls.Add(Me.LabelX3)
        Me.GroupPanel2.Controls.Add(Me.LabelX9)
        Me.GroupPanel2.Controls.Add(Me.TxtPrPromPonderado)
        Me.GroupPanel2.Controls.Add(Me.LabelX4)
        Me.GroupPanel2.Controls.Add(Me.LabelX8)
        Me.GroupPanel2.Controls.Add(Me.TxtPrecioNetoReal)
        Me.GroupPanel2.Controls.Add(Me.label)
        Me.GroupPanel2.Controls.Add(Me.LabelX7)
        Me.GroupPanel2.Controls.Add(Me.TxtValorNetoLinea)
        Me.GroupPanel2.Controls.Add(Me.LabelX6)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(9, 418)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(1016, 129)
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
        Me.GroupPanel2.TabIndex = 46
        Me.GroupPanel2.Text = "Información de la fila activa"
        '
        'Frm_Kardex_Informe_X_Producto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1033, 601)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.TxtNroLote)
        Me.Controls.Add(Me.LabelX12)
        Me.Controls.Add(Me.TxtDescripcionProducto)
        Me.Controls.Add(Me.LabelX13)
        Me.Controls.Add(Me.Bar2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Kardex_Informe_X_Producto"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Movimientos y situación de Stock"
        CType(Me.GrillaKardex, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents TextBoxX11 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TextBoxX10 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TextBoxX9 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtPrPromPonderado As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtPrecioNetoReal As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtValorNetoLinea As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtDsctoLinea As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents label As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtPrecioUnitario As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtTidopa As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtEntidad As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtFechaEmisionHora As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtNroLote As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtDescripcionProducto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
    Friend WithEvents BtnIrAptincipio As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnIrAlFin As DevComponents.DotNetBar.ButtonItem
    Public WithEvents GrillaKardex As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Lbl_NroDecimales As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_DecimalRestar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_DecimalAgregar As DevComponents.DotNetBar.ButtonItem
End Class
