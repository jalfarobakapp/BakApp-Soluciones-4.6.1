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
        Me.Btn_ProbarConexionWms = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_Wms_Basededatos = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Txt_Wms_Password = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Txt_Wms_Usuario = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Txt_Wms_Puerto = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Txt_Wms_Host = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Chk_ImprimirRetiros = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_ImprimirDespachos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Impresora_Retiros = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Impresora_Despachos = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_NombreFormato_Despachos = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_NombreFormato_Retiros = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Grupo_Imprimir = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Txt_NombreEquipoImprime = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Input_DiasRevNVV = New DevComponents.Editors.IntegerInput()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_Imprimir.SuspendLayout()
        CType(Me.Input_DiasRevNVV, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(351, 212)
        Me.GroupBox1.TabIndex = 35
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
        Me.GroupBox2.Controls.Add(Me.Btn_ProbarConexionWms)
        Me.GroupBox2.Controls.Add(Me.Txt_Wms_Basededatos)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Txt_Wms_Password)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Txt_Wms_Usuario)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Txt_Wms_Puerto)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Txt_Wms_Host)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(369, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(351, 212)
        Me.GroupBox2.TabIndex = 36
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos de conexión SQL WMS"
        '
        'Btn_ProbarConexionWms
        '
        Me.Btn_ProbarConexionWms.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_ProbarConexionWms.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_ProbarConexionWms.Location = New System.Drawing.Point(25, 175)
        Me.Btn_ProbarConexionWms.Name = "Btn_ProbarConexionWms"
        Me.Btn_ProbarConexionWms.Size = New System.Drawing.Size(102, 23)
        Me.Btn_ProbarConexionWms.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_ProbarConexionWms.TabIndex = 12
        Me.Btn_ProbarConexionWms.Text = "Probar conexión"
        '
        'Txt_Wms_Basededatos
        '
        Me.Txt_Wms_Basededatos.BackColor = System.Drawing.Color.White
        Me.Txt_Wms_Basededatos.ForeColor = System.Drawing.Color.Black
        Me.Txt_Wms_Basededatos.Location = New System.Drawing.Point(133, 141)
        Me.Txt_Wms_Basededatos.Name = "Txt_Wms_Basededatos"
        Me.Txt_Wms_Basededatos.Size = New System.Drawing.Size(207, 22)
        Me.Txt_Wms_Basededatos.TabIndex = 4
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
        'Txt_Wms_Password
        '
        Me.Txt_Wms_Password.BackColor = System.Drawing.Color.White
        Me.Txt_Wms_Password.ForeColor = System.Drawing.Color.Black
        Me.Txt_Wms_Password.Location = New System.Drawing.Point(133, 113)
        Me.Txt_Wms_Password.Name = "Txt_Wms_Password"
        Me.Txt_Wms_Password.Size = New System.Drawing.Size(207, 22)
        Me.Txt_Wms_Password.TabIndex = 3
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
        'Txt_Wms_Usuario
        '
        Me.Txt_Wms_Usuario.BackColor = System.Drawing.Color.White
        Me.Txt_Wms_Usuario.ForeColor = System.Drawing.Color.Black
        Me.Txt_Wms_Usuario.Location = New System.Drawing.Point(133, 86)
        Me.Txt_Wms_Usuario.Name = "Txt_Wms_Usuario"
        Me.Txt_Wms_Usuario.Size = New System.Drawing.Size(207, 22)
        Me.Txt_Wms_Usuario.TabIndex = 2
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
        'Txt_Wms_Puerto
        '
        Me.Txt_Wms_Puerto.BackColor = System.Drawing.Color.White
        Me.Txt_Wms_Puerto.ForeColor = System.Drawing.Color.Black
        Me.Txt_Wms_Puerto.Location = New System.Drawing.Point(133, 58)
        Me.Txt_Wms_Puerto.Name = "Txt_Wms_Puerto"
        Me.Txt_Wms_Puerto.Size = New System.Drawing.Size(207, 22)
        Me.Txt_Wms_Puerto.TabIndex = 1
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
        'Txt_Wms_Host
        '
        Me.Txt_Wms_Host.BackColor = System.Drawing.Color.White
        Me.Txt_Wms_Host.ForeColor = System.Drawing.Color.Black
        Me.Txt_Wms_Host.Location = New System.Drawing.Point(133, 29)
        Me.Txt_Wms_Host.Name = "Txt_Wms_Host"
        Me.Txt_Wms_Host.Size = New System.Drawing.Size(207, 22)
        Me.Txt_Wms_Host.TabIndex = 0
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
        Me.Bar1.Location = New System.Drawing.Point(0, 445)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(733, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 86
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
        'Chk_ImprimirRetiros
        '
        Me.Chk_ImprimirRetiros.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_ImprimirRetiros.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_ImprimirRetiros.CheckBoxImageChecked = CType(resources.GetObject("Chk_ImprimirRetiros.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_ImprimirRetiros.FocusCuesEnabled = False
        Me.Chk_ImprimirRetiros.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Chk_ImprimirRetiros.ForeColor = System.Drawing.Color.Black
        Me.Chk_ImprimirRetiros.Location = New System.Drawing.Point(11, 96)
        Me.Chk_ImprimirRetiros.Name = "Chk_ImprimirRetiros"
        Me.Chk_ImprimirRetiros.Size = New System.Drawing.Size(86, 19)
        Me.Chk_ImprimirRetiros.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_ImprimirRetiros.TabIndex = 88
        Me.Chk_ImprimirRetiros.Text = "Retiros"
        '
        'Chk_ImprimirDespachos
        '
        Me.Chk_ImprimirDespachos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_ImprimirDespachos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_ImprimirDespachos.CheckBoxImageChecked = CType(resources.GetObject("Chk_ImprimirDespachos.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_ImprimirDespachos.FocusCuesEnabled = False
        Me.Chk_ImprimirDespachos.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Chk_ImprimirDespachos.ForeColor = System.Drawing.Color.Black
        Me.Chk_ImprimirDespachos.Location = New System.Drawing.Point(11, 127)
        Me.Chk_ImprimirDespachos.Name = "Chk_ImprimirDespachos"
        Me.Chk_ImprimirDespachos.Size = New System.Drawing.Size(86, 19)
        Me.Chk_ImprimirDespachos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_ImprimirDespachos.TabIndex = 89
        Me.Chk_ImprimirDespachos.Text = "Despachos"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(103, 71)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(150, 19)
        Me.LabelX1.TabIndex = 92
        Me.LabelX1.Text = "Nombre impresora"
        '
        'Txt_Impresora_Retiros
        '
        Me.Txt_Impresora_Retiros.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Impresora_Retiros.Border.Class = "TextBoxBorder"
        Me.Txt_Impresora_Retiros.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Impresora_Retiros.ButtonCustom.Image = CType(resources.GetObject("Txt_Impresora_Retiros.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Impresora_Retiros.ButtonCustom.Visible = True
        Me.Txt_Impresora_Retiros.ButtonCustom2.Image = CType(resources.GetObject("Txt_Impresora_Retiros.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Impresora_Retiros.ButtonCustom2.Visible = True
        Me.Txt_Impresora_Retiros.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Impresora_Retiros.ForeColor = System.Drawing.Color.Black
        Me.Txt_Impresora_Retiros.Location = New System.Drawing.Point(103, 93)
        Me.Txt_Impresora_Retiros.Name = "Txt_Impresora_Retiros"
        Me.Txt_Impresora_Retiros.PreventEnterBeep = True
        Me.Txt_Impresora_Retiros.Size = New System.Drawing.Size(281, 22)
        Me.Txt_Impresora_Retiros.TabIndex = 93
        '
        'Txt_Impresora_Despachos
        '
        Me.Txt_Impresora_Despachos.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Impresora_Despachos.Border.Class = "TextBoxBorder"
        Me.Txt_Impresora_Despachos.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Impresora_Despachos.ButtonCustom.Image = CType(resources.GetObject("Txt_Impresora_Despachos.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Impresora_Despachos.ButtonCustom.Visible = True
        Me.Txt_Impresora_Despachos.ButtonCustom2.Image = CType(resources.GetObject("Txt_Impresora_Despachos.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Impresora_Despachos.ButtonCustom2.Visible = True
        Me.Txt_Impresora_Despachos.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Impresora_Despachos.ForeColor = System.Drawing.Color.Black
        Me.Txt_Impresora_Despachos.Location = New System.Drawing.Point(103, 124)
        Me.Txt_Impresora_Despachos.Name = "Txt_Impresora_Despachos"
        Me.Txt_Impresora_Despachos.PreventEnterBeep = True
        Me.Txt_Impresora_Despachos.Size = New System.Drawing.Size(281, 22)
        Me.Txt_Impresora_Despachos.TabIndex = 94
        '
        'Txt_NombreFormato_Despachos
        '
        Me.Txt_NombreFormato_Despachos.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_NombreFormato_Despachos.Border.Class = "TextBoxBorder"
        Me.Txt_NombreFormato_Despachos.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_NombreFormato_Despachos.ButtonCustom.Image = CType(resources.GetObject("Txt_NombreFormato_Despachos.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_NombreFormato_Despachos.ButtonCustom.Visible = True
        Me.Txt_NombreFormato_Despachos.ButtonCustom2.Image = CType(resources.GetObject("Txt_NombreFormato_Despachos.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_NombreFormato_Despachos.ButtonCustom2.Visible = True
        Me.Txt_NombreFormato_Despachos.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_NombreFormato_Despachos.ForeColor = System.Drawing.Color.Black
        Me.Txt_NombreFormato_Despachos.Location = New System.Drawing.Point(398, 124)
        Me.Txt_NombreFormato_Despachos.Name = "Txt_NombreFormato_Despachos"
        Me.Txt_NombreFormato_Despachos.PreventEnterBeep = True
        Me.Txt_NombreFormato_Despachos.Size = New System.Drawing.Size(298, 22)
        Me.Txt_NombreFormato_Despachos.TabIndex = 97
        '
        'Txt_NombreFormato_Retiros
        '
        Me.Txt_NombreFormato_Retiros.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_NombreFormato_Retiros.Border.Class = "TextBoxBorder"
        Me.Txt_NombreFormato_Retiros.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_NombreFormato_Retiros.ButtonCustom.Image = CType(resources.GetObject("Txt_NombreFormato_Retiros.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_NombreFormato_Retiros.ButtonCustom.Visible = True
        Me.Txt_NombreFormato_Retiros.ButtonCustom2.Image = CType(resources.GetObject("Txt_NombreFormato_Retiros.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_NombreFormato_Retiros.ButtonCustom2.Visible = True
        Me.Txt_NombreFormato_Retiros.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_NombreFormato_Retiros.ForeColor = System.Drawing.Color.Black
        Me.Txt_NombreFormato_Retiros.Location = New System.Drawing.Point(398, 93)
        Me.Txt_NombreFormato_Retiros.Name = "Txt_NombreFormato_Retiros"
        Me.Txt_NombreFormato_Retiros.PreventEnterBeep = True
        Me.Txt_NombreFormato_Retiros.Size = New System.Drawing.Size(298, 22)
        Me.Txt_NombreFormato_Retiros.TabIndex = 96
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(398, 71)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(150, 19)
        Me.LabelX2.TabIndex = 95
        Me.LabelX2.Text = "Nombre formato"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(11, 71)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(86, 19)
        Me.LabelX3.TabIndex = 98
        Me.LabelX3.Text = "Imprimir:"
        '
        'Grupo_Imprimir
        '
        Me.Grupo_Imprimir.BackColor = System.Drawing.Color.White
        Me.Grupo_Imprimir.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Imprimir.Controls.Add(Me.Txt_NombreEquipoImprime)
        Me.Grupo_Imprimir.Controls.Add(Me.LabelX5)
        Me.Grupo_Imprimir.Controls.Add(Me.LabelX1)
        Me.Grupo_Imprimir.Controls.Add(Me.LabelX3)
        Me.Grupo_Imprimir.Controls.Add(Me.Chk_ImprimirRetiros)
        Me.Grupo_Imprimir.Controls.Add(Me.Txt_NombreFormato_Despachos)
        Me.Grupo_Imprimir.Controls.Add(Me.Chk_ImprimirDespachos)
        Me.Grupo_Imprimir.Controls.Add(Me.Txt_NombreFormato_Retiros)
        Me.Grupo_Imprimir.Controls.Add(Me.Txt_Impresora_Retiros)
        Me.Grupo_Imprimir.Controls.Add(Me.LabelX2)
        Me.Grupo_Imprimir.Controls.Add(Me.Txt_Impresora_Despachos)
        Me.Grupo_Imprimir.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Imprimir.Location = New System.Drawing.Point(12, 230)
        Me.Grupo_Imprimir.Name = "Grupo_Imprimir"
        Me.Grupo_Imprimir.Size = New System.Drawing.Size(708, 173)
        '
        '
        '
        Me.Grupo_Imprimir.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Imprimir.Style.BackColorGradientAngle = 90
        Me.Grupo_Imprimir.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Imprimir.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Imprimir.Style.BorderBottomWidth = 1
        Me.Grupo_Imprimir.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Imprimir.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Imprimir.Style.BorderLeftWidth = 1
        Me.Grupo_Imprimir.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Imprimir.Style.BorderRightWidth = 1
        Me.Grupo_Imprimir.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Imprimir.Style.BorderTopWidth = 1
        Me.Grupo_Imprimir.Style.CornerDiameter = 4
        Me.Grupo_Imprimir.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Imprimir.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Imprimir.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Imprimir.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Imprimir.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Imprimir.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Imprimir.TabIndex = 99
        Me.Grupo_Imprimir.Text = "Imprimir lista de verificación"
        '
        'Txt_NombreEquipoImprime
        '
        Me.Txt_NombreEquipoImprime.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_NombreEquipoImprime.Border.Class = "TextBoxBorder"
        Me.Txt_NombreEquipoImprime.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_NombreEquipoImprime.ButtonCustom.Image = CType(resources.GetObject("Txt_NombreEquipoImprime.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_NombreEquipoImprime.ButtonCustom.Visible = True
        Me.Txt_NombreEquipoImprime.ButtonCustom2.Image = CType(resources.GetObject("Txt_NombreEquipoImprime.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_NombreEquipoImprime.ButtonCustom2.Visible = True
        Me.Txt_NombreEquipoImprime.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_NombreEquipoImprime.ForeColor = System.Drawing.Color.Black
        Me.Txt_NombreEquipoImprime.Location = New System.Drawing.Point(119, 29)
        Me.Txt_NombreEquipoImprime.Name = "Txt_NombreEquipoImprime"
        Me.Txt_NombreEquipoImprime.PreventEnterBeep = True
        Me.Txt_NombreEquipoImprime.Size = New System.Drawing.Size(265, 22)
        Me.Txt_NombreEquipoImprime.TabIndex = 100
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(11, 18)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(113, 33)
        Me.LabelX5.TabIndex = 99
        Me.LabelX5.Text = "Nombre de " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "equipo que imprime"
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(12, 420)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(168, 19)
        Me.LabelX4.TabIndex = 100
        Me.LabelX4.Text = "Días para revisar NVV hacia atras"
        '
        'Input_DiasRevNVV
        '
        Me.Input_DiasRevNVV.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_DiasRevNVV.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_DiasRevNVV.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_DiasRevNVV.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.Input_DiasRevNVV.ForeColor = System.Drawing.Color.Black
        Me.Input_DiasRevNVV.Location = New System.Drawing.Point(186, 420)
        Me.Input_DiasRevNVV.MaxValue = 30
        Me.Input_DiasRevNVV.Name = "Input_DiasRevNVV"
        Me.Input_DiasRevNVV.ShowUpDown = True
        Me.Input_DiasRevNVV.Size = New System.Drawing.Size(50, 22)
        Me.Input_DiasRevNVV.TabIndex = 101
        Me.Input_DiasRevNVV.Value = 1
        '
        'Frm_Conexiones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(733, 486)
        Me.Controls.Add(Me.Input_DiasRevNVV)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.Grupo_Imprimir)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Conexiones"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CONFIGURACION DE CONEXION"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo_Imprimir.ResumeLayout(False)
        CType(Me.Input_DiasRevNVV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Txt_Rd_Basededatos As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Txt_Rd_Password As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Txt_Rd_Usuario As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Txt_Rd_Puerto As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Txt_Wms_Basededatos As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Txt_Wms_Password As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Txt_Wms_Usuario As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Txt_Wms_Puerto As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Txt_Wms_Host As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Btn_ProbarConexionRd As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_ProbarConexionWms As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Chk_ImprimirRetiros As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_ImprimirDespachos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Impresora_Retiros As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Impresora_Despachos As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_NombreFormato_Despachos As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_NombreFormato_Retiros As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Grupo_Imprimir As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Txt_Rd_Host As TextBox
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Input_DiasRevNVV As DevComponents.Editors.IntegerInput
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_NombreEquipoImprime As DevComponents.DotNetBar.Controls.TextBoxX
End Class
