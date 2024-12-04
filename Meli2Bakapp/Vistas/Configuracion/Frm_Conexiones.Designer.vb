<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Conexiones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Conexiones))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Btn_ProbarConexionRd = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_Rd_Basededatos = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Txt_Rd_Password = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Txt_Rd_Usuario = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Txt_Rd_Puerto = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Txt_Rd_Host = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Btn_ProbarConexionMeli = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_Meli_Basededatos = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Txt_Meli_Password = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Txt_Meli_Usuario = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Txt_Meli_Puerto = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Txt_Meli_Host = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Txt_Bodega = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Global_BaseBk = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX15 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Empresa = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX16 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Vendedor = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX17 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_RutaEtiquetas = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX18 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Responsable = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.Btn_ProbarConexionRd)
        Me.GroupBox1.Controls.Add(Me.Txt_Rd_Basededatos)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Txt_Rd_Password)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Txt_Rd_Usuario)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Txt_Rd_Puerto)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Txt_Rd_Host)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(12, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(351, 212)
        Me.GroupBox1.TabIndex = 105
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de conexión SQL RANDOM"
        '
        'Btn_ProbarConexionRd
        '
        Me.Btn_ProbarConexionRd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_ProbarConexionRd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_ProbarConexionRd.Location = New System.Drawing.Point(25, 175)
        Me.Btn_ProbarConexionRd.Name = "Btn_ProbarConexionRd"
        Me.Btn_ProbarConexionRd.Size = New System.Drawing.Size(102, 23)
        Me.Btn_ProbarConexionRd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_ProbarConexionRd.TabIndex = 11
        Me.Btn_ProbarConexionRd.Text = "Probar conexión"
        '
        'Txt_Rd_Basededatos
        '
        Me.Txt_Rd_Basededatos.BackColor = System.Drawing.Color.White
        Me.Txt_Rd_Basededatos.ForeColor = System.Drawing.Color.Black
        Me.Txt_Rd_Basededatos.Location = New System.Drawing.Point(133, 141)
        Me.Txt_Rd_Basededatos.Name = "Txt_Rd_Basededatos"
        Me.Txt_Rd_Basededatos.Size = New System.Drawing.Size(207, 22)
        Me.Txt_Rd_Basededatos.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.White
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(22, 144)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Base de datos"
        '
        'Txt_Rd_Password
        '
        Me.Txt_Rd_Password.BackColor = System.Drawing.Color.White
        Me.Txt_Rd_Password.ForeColor = System.Drawing.Color.Black
        Me.Txt_Rd_Password.Location = New System.Drawing.Point(133, 113)
        Me.Txt_Rd_Password.Name = "Txt_Rd_Password"
        Me.Txt_Rd_Password.Size = New System.Drawing.Size(207, 22)
        Me.Txt_Rd_Password.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(22, 116)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Clave"
        '
        'Txt_Rd_Usuario
        '
        Me.Txt_Rd_Usuario.BackColor = System.Drawing.Color.White
        Me.Txt_Rd_Usuario.ForeColor = System.Drawing.Color.Black
        Me.Txt_Rd_Usuario.Location = New System.Drawing.Point(133, 86)
        Me.Txt_Rd_Usuario.Name = "Txt_Rd_Usuario"
        Me.Txt_Rd_Usuario.Size = New System.Drawing.Size(207, 22)
        Me.Txt_Rd_Usuario.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(22, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Usuario"
        '
        'Txt_Rd_Puerto
        '
        Me.Txt_Rd_Puerto.BackColor = System.Drawing.Color.White
        Me.Txt_Rd_Puerto.ForeColor = System.Drawing.Color.Black
        Me.Txt_Rd_Puerto.Location = New System.Drawing.Point(133, 58)
        Me.Txt_Rd_Puerto.Name = "Txt_Rd_Puerto"
        Me.Txt_Rd_Puerto.Size = New System.Drawing.Size(207, 22)
        Me.Txt_Rd_Puerto.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(22, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Puerto"
        '
        'Txt_Rd_Host
        '
        Me.Txt_Rd_Host.BackColor = System.Drawing.Color.White
        Me.Txt_Rd_Host.ForeColor = System.Drawing.Color.Black
        Me.Txt_Rd_Host.Location = New System.Drawing.Point(133, 29)
        Me.Txt_Rd_Host.Name = "Txt_Rd_Host"
        Me.Txt_Rd_Host.Size = New System.Drawing.Size(207, 22)
        Me.Txt_Rd_Host.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(22, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Servidor"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.Controls.Add(Me.Btn_ProbarConexionMeli)
        Me.GroupBox2.Controls.Add(Me.Txt_Meli_Basededatos)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Txt_Meli_Password)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Txt_Meli_Usuario)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Txt_Meli_Puerto)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Txt_Meli_Host)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(369, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(351, 212)
        Me.GroupBox2.TabIndex = 106
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos de conexión SQL MELI"
        '
        'Btn_ProbarConexionMeli
        '
        Me.Btn_ProbarConexionMeli.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_ProbarConexionMeli.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_ProbarConexionMeli.Location = New System.Drawing.Point(25, 175)
        Me.Btn_ProbarConexionMeli.Name = "Btn_ProbarConexionMeli"
        Me.Btn_ProbarConexionMeli.Size = New System.Drawing.Size(102, 23)
        Me.Btn_ProbarConexionMeli.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_ProbarConexionMeli.TabIndex = 12
        Me.Btn_ProbarConexionMeli.Text = "Probar conexión"
        '
        'Txt_Meli_Basededatos
        '
        Me.Txt_Meli_Basededatos.BackColor = System.Drawing.Color.White
        Me.Txt_Meli_Basededatos.ForeColor = System.Drawing.Color.Black
        Me.Txt_Meli_Basededatos.Location = New System.Drawing.Point(133, 141)
        Me.Txt_Meli_Basededatos.Name = "Txt_Meli_Basededatos"
        Me.Txt_Meli_Basededatos.Size = New System.Drawing.Size(207, 22)
        Me.Txt_Meli_Basededatos.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.White
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(22, 144)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Base de datos"
        '
        'Txt_Meli_Password
        '
        Me.Txt_Meli_Password.BackColor = System.Drawing.Color.White
        Me.Txt_Meli_Password.ForeColor = System.Drawing.Color.Black
        Me.Txt_Meli_Password.Location = New System.Drawing.Point(133, 113)
        Me.Txt_Meli_Password.Name = "Txt_Meli_Password"
        Me.Txt_Meli_Password.Size = New System.Drawing.Size(207, 22)
        Me.Txt_Meli_Password.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.White
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(22, 116)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Clave"
        '
        'Txt_Meli_Usuario
        '
        Me.Txt_Meli_Usuario.BackColor = System.Drawing.Color.White
        Me.Txt_Meli_Usuario.ForeColor = System.Drawing.Color.Black
        Me.Txt_Meli_Usuario.Location = New System.Drawing.Point(133, 86)
        Me.Txt_Meli_Usuario.Name = "Txt_Meli_Usuario"
        Me.Txt_Meli_Usuario.Size = New System.Drawing.Size(207, 22)
        Me.Txt_Meli_Usuario.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.White
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(22, 89)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 13)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Usuario"
        '
        'Txt_Meli_Puerto
        '
        Me.Txt_Meli_Puerto.BackColor = System.Drawing.Color.White
        Me.Txt_Meli_Puerto.ForeColor = System.Drawing.Color.Black
        Me.Txt_Meli_Puerto.Location = New System.Drawing.Point(133, 58)
        Me.Txt_Meli_Puerto.Name = "Txt_Meli_Puerto"
        Me.Txt_Meli_Puerto.Size = New System.Drawing.Size(207, 22)
        Me.Txt_Meli_Puerto.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.White
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(22, 61)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 13)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Puerto"
        '
        'Txt_Meli_Host
        '
        Me.Txt_Meli_Host.BackColor = System.Drawing.Color.White
        Me.Txt_Meli_Host.ForeColor = System.Drawing.Color.Black
        Me.Txt_Meli_Host.Location = New System.Drawing.Point(133, 29)
        Me.Txt_Meli_Host.Name = "Txt_Meli_Host"
        Me.Txt_Meli_Host.Size = New System.Drawing.Size(207, 22)
        Me.Txt_Meli_Host.TabIndex = 0
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.White
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(22, 32)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 13)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Servidor"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar})
        Me.Bar1.Location = New System.Drawing.Point(0, 407)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(731, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 107
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.ImageAlt = CType(resources.GetObject("Btn_Grabar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Tooltip = "Grabar conexiones"
        '
        'Txt_Bodega
        '
        Me.Txt_Bodega.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Bodega.Border.Class = "TextBoxBorder"
        Me.Txt_Bodega.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Bodega.ButtonCustom.Image = CType(resources.GetObject("Txt_Bodega.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Bodega.ButtonCustom.Visible = True
        Me.Txt_Bodega.ButtonCustom2.Image = CType(resources.GetObject("Txt_Bodega.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Bodega.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Bodega.ForeColor = System.Drawing.Color.Black
        Me.Txt_Bodega.Location = New System.Drawing.Point(145, 280)
        Me.Txt_Bodega.Name = "Txt_Bodega"
        Me.Txt_Bodega.PreventEnterBeep = True
        Me.Txt_Bodega.ReadOnly = True
        Me.Txt_Bodega.Size = New System.Drawing.Size(253, 22)
        Me.Txt_Bodega.TabIndex = 114
        Me.Txt_Bodega.WatermarkText = "Bodega desde donde se sacan los productos"
        '
        'LabelX12
        '
        Me.LabelX12.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX12.ForeColor = System.Drawing.Color.Black
        Me.LabelX12.Location = New System.Drawing.Point(12, 282)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(112, 20)
        Me.LabelX12.TabIndex = 113
        Me.LabelX12.Text = "Bodega de facturación"
        '
        'Txt_Global_BaseBk
        '
        Me.Txt_Global_BaseBk.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Global_BaseBk.Border.Class = "TextBoxBorder"
        Me.Txt_Global_BaseBk.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Global_BaseBk.ButtonCustom.Image = CType(resources.GetObject("Txt_Global_BaseBk.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Global_BaseBk.ButtonCustom2.Image = CType(resources.GetObject("Txt_Global_BaseBk.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Global_BaseBk.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Global_BaseBk.ForeColor = System.Drawing.Color.Black
        Me.Txt_Global_BaseBk.Location = New System.Drawing.Point(145, 224)
        Me.Txt_Global_BaseBk.Name = "Txt_Global_BaseBk"
        Me.Txt_Global_BaseBk.PreventEnterBeep = True
        Me.Txt_Global_BaseBk.Size = New System.Drawing.Size(253, 22)
        Me.Txt_Global_BaseBk.TabIndex = 115
        Me.Txt_Global_BaseBk.WatermarkText = "Nombre de base de datos de Bakapp"
        '
        'LabelX15
        '
        Me.LabelX15.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX15.ForeColor = System.Drawing.Color.Black
        Me.LabelX15.Location = New System.Drawing.Point(12, 224)
        Me.LabelX15.Name = "LabelX15"
        Me.LabelX15.Size = New System.Drawing.Size(112, 20)
        Me.LabelX15.TabIndex = 116
        Me.LabelX15.Text = "Nombre Base Bakapp"
        '
        'Txt_Empresa
        '
        Me.Txt_Empresa.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Empresa.Border.Class = "TextBoxBorder"
        Me.Txt_Empresa.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Empresa.ButtonCustom.Image = CType(resources.GetObject("Txt_Empresa.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Empresa.ButtonCustom.Visible = True
        Me.Txt_Empresa.ButtonCustom2.Image = CType(resources.GetObject("Txt_Empresa.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Empresa.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Empresa.ForeColor = System.Drawing.Color.Black
        Me.Txt_Empresa.Location = New System.Drawing.Point(145, 253)
        Me.Txt_Empresa.Name = "Txt_Empresa"
        Me.Txt_Empresa.PreventEnterBeep = True
        Me.Txt_Empresa.ReadOnly = True
        Me.Txt_Empresa.Size = New System.Drawing.Size(253, 22)
        Me.Txt_Empresa.TabIndex = 118
        Me.Txt_Empresa.WatermarkText = "Empresa a conectar"
        '
        'LabelX16
        '
        Me.LabelX16.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX16.ForeColor = System.Drawing.Color.Black
        Me.LabelX16.Location = New System.Drawing.Point(12, 252)
        Me.LabelX16.Name = "LabelX16"
        Me.LabelX16.Size = New System.Drawing.Size(112, 20)
        Me.LabelX16.TabIndex = 117
        Me.LabelX16.Text = "Empresa"
        '
        'Txt_Vendedor
        '
        Me.Txt_Vendedor.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Vendedor.Border.Class = "TextBoxBorder"
        Me.Txt_Vendedor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Vendedor.ButtonCustom.Image = CType(resources.GetObject("Txt_Vendedor.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Vendedor.ButtonCustom.Visible = True
        Me.Txt_Vendedor.ButtonCustom2.Image = CType(resources.GetObject("Txt_Vendedor.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Vendedor.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Vendedor.ForeColor = System.Drawing.Color.Black
        Me.Txt_Vendedor.Location = New System.Drawing.Point(145, 308)
        Me.Txt_Vendedor.Name = "Txt_Vendedor"
        Me.Txt_Vendedor.PreventEnterBeep = True
        Me.Txt_Vendedor.ReadOnly = True
        Me.Txt_Vendedor.Size = New System.Drawing.Size(253, 22)
        Me.Txt_Vendedor.TabIndex = 120
        Me.Txt_Vendedor.WatermarkText = "Vendedor asociados a las notas de venta"
        '
        'LabelX17
        '
        Me.LabelX17.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX17.ForeColor = System.Drawing.Color.Black
        Me.LabelX17.Location = New System.Drawing.Point(12, 310)
        Me.LabelX17.Name = "LabelX17"
        Me.LabelX17.Size = New System.Drawing.Size(112, 20)
        Me.LabelX17.TabIndex = 119
        Me.LabelX17.Text = "Vendedor"
        '
        'Txt_RutaEtiquetas
        '
        Me.Txt_RutaEtiquetas.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_RutaEtiquetas.Border.Class = "TextBoxBorder"
        Me.Txt_RutaEtiquetas.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_RutaEtiquetas.ButtonCustom.Image = CType(resources.GetObject("Txt_RutaEtiquetas.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_RutaEtiquetas.ButtonCustom.Visible = True
        Me.Txt_RutaEtiquetas.ButtonCustom2.Image = CType(resources.GetObject("Txt_RutaEtiquetas.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_RutaEtiquetas.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_RutaEtiquetas.ForeColor = System.Drawing.Color.Black
        Me.Txt_RutaEtiquetas.Location = New System.Drawing.Point(145, 364)
        Me.Txt_RutaEtiquetas.Name = "Txt_RutaEtiquetas"
        Me.Txt_RutaEtiquetas.PreventEnterBeep = True
        Me.Txt_RutaEtiquetas.ReadOnly = True
        Me.Txt_RutaEtiquetas.Size = New System.Drawing.Size(575, 22)
        Me.Txt_RutaEtiquetas.TabIndex = 122
        Me.Txt_RutaEtiquetas.WatermarkText = "Ruta de PDF"
        '
        'LabelX18
        '
        Me.LabelX18.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX18.ForeColor = System.Drawing.Color.Black
        Me.LabelX18.Location = New System.Drawing.Point(12, 366)
        Me.LabelX18.Name = "LabelX18"
        Me.LabelX18.Size = New System.Drawing.Size(112, 20)
        Me.LabelX18.TabIndex = 121
        Me.LabelX18.Text = "Ruta PDF"
        '
        'Txt_Responsable
        '
        Me.Txt_Responsable.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Responsable.Border.Class = "TextBoxBorder"
        Me.Txt_Responsable.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Responsable.ButtonCustom.Image = CType(resources.GetObject("TextBoxX1.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Responsable.ButtonCustom.Visible = True
        Me.Txt_Responsable.ButtonCustom2.Image = CType(resources.GetObject("TextBoxX1.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Responsable.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Responsable.ForeColor = System.Drawing.Color.Black
        Me.Txt_Responsable.Location = New System.Drawing.Point(145, 336)
        Me.Txt_Responsable.Name = "Txt_Responsable"
        Me.Txt_Responsable.PreventEnterBeep = True
        Me.Txt_Responsable.ReadOnly = True
        Me.Txt_Responsable.Size = New System.Drawing.Size(253, 22)
        Me.Txt_Responsable.TabIndex = 124
        Me.Txt_Responsable.WatermarkText = "Responsable del documento"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(12, 338)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(127, 20)
        Me.LabelX1.TabIndex = 123
        Me.LabelX1.Text = "Facturador/Responsable"
        '
        'Frm_Conexiones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(731, 448)
        Me.Controls.Add(Me.Txt_Responsable)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Txt_RutaEtiquetas)
        Me.Controls.Add(Me.LabelX18)
        Me.Controls.Add(Me.Txt_Vendedor)
        Me.Controls.Add(Me.LabelX17)
        Me.Controls.Add(Me.Txt_Empresa)
        Me.Controls.Add(Me.LabelX16)
        Me.Controls.Add(Me.LabelX15)
        Me.Controls.Add(Me.Txt_Global_BaseBk)
        Me.Controls.Add(Me.Txt_Bodega)
        Me.Controls.Add(Me.LabelX12)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Conexiones"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CONFIGURACION DE SISTEMA DE SINCRONIZACION MELI VS BAKAPP"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Btn_ProbarConexionRd As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Txt_Rd_Basededatos As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Txt_Rd_Password As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Txt_Rd_Usuario As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Txt_Rd_Puerto As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Txt_Rd_Host As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Btn_ProbarConexionMeli As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Txt_Meli_Basededatos As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Txt_Meli_Password As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Txt_Meli_Usuario As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Txt_Meli_Puerto As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Txt_Meli_Host As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Txt_Bodega As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Global_BaseBk As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX15 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Empresa As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX16 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Vendedor As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX17 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_RutaEtiquetas As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX18 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Responsable As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
End Class
