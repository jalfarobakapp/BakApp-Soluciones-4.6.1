<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Configuracion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Configuracion))
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
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.SuperTabControl1 = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.SuperTabItem2 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabItem1 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_ModalidadFac = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX15 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Concepto_D = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Bodega = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Concepto_R = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Global_BaseBk = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX16 = New DevComponents.DotNetBar.LabelX()
        Me.Cmb_DocEmitir = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Txt_Empresa = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX17 = New DevComponents.DotNetBar.LabelX()
        Me.Chk_Facturar = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Txt_Vendedor = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Responsable = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX18 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_RutaEtiquetas = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtBakApp = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControl1.SuspendLayout()
        Me.SuperTabControlPanel2.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.TxtBakApp)
        Me.GroupBox1.Controls.Add(Me.Label6)
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
        Me.GroupBox1.Location = New System.Drawing.Point(12, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(708, 254)
        Me.GroupBox1.TabIndex = 105
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de conexión SQL RANDOM + BAKAPP"
        '
        'Btn_ProbarConexionRd
        '
        Me.Btn_ProbarConexionRd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_ProbarConexionRd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_ProbarConexionRd.Location = New System.Drawing.Point(213, 225)
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
        Me.Txt_Rd_Basededatos.Location = New System.Drawing.Point(320, 135)
        Me.Txt_Rd_Basededatos.Name = "Txt_Rd_Basededatos"
        Me.Txt_Rd_Basededatos.Size = New System.Drawing.Size(207, 26)
        Me.Txt_Rd_Basededatos.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.White
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(209, 138)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 19)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Base de datos"
        '
        'Txt_Rd_Password
        '
        Me.Txt_Rd_Password.BackColor = System.Drawing.Color.White
        Me.Txt_Rd_Password.ForeColor = System.Drawing.Color.Black
        Me.Txt_Rd_Password.Location = New System.Drawing.Point(320, 107)
        Me.Txt_Rd_Password.Name = "Txt_Rd_Password"
        Me.Txt_Rd_Password.Size = New System.Drawing.Size(207, 26)
        Me.Txt_Rd_Password.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(209, 110)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 19)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Clave"
        '
        'Txt_Rd_Usuario
        '
        Me.Txt_Rd_Usuario.BackColor = System.Drawing.Color.White
        Me.Txt_Rd_Usuario.ForeColor = System.Drawing.Color.Black
        Me.Txt_Rd_Usuario.Location = New System.Drawing.Point(320, 80)
        Me.Txt_Rd_Usuario.Name = "Txt_Rd_Usuario"
        Me.Txt_Rd_Usuario.Size = New System.Drawing.Size(207, 26)
        Me.Txt_Rd_Usuario.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(209, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 19)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Usuario"
        '
        'Txt_Rd_Puerto
        '
        Me.Txt_Rd_Puerto.BackColor = System.Drawing.Color.White
        Me.Txt_Rd_Puerto.ForeColor = System.Drawing.Color.Black
        Me.Txt_Rd_Puerto.Location = New System.Drawing.Point(320, 52)
        Me.Txt_Rd_Puerto.Name = "Txt_Rd_Puerto"
        Me.Txt_Rd_Puerto.Size = New System.Drawing.Size(207, 26)
        Me.Txt_Rd_Puerto.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(209, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 19)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Puerto"
        '
        'Txt_Rd_Host
        '
        Me.Txt_Rd_Host.BackColor = System.Drawing.Color.White
        Me.Txt_Rd_Host.ForeColor = System.Drawing.Color.Black
        Me.Txt_Rd_Host.Location = New System.Drawing.Point(320, 23)
        Me.Txt_Rd_Host.Name = "Txt_Rd_Host"
        Me.Txt_Rd_Host.Size = New System.Drawing.Size(207, 26)
        Me.Txt_Rd_Host.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(209, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 19)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Servidor"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar})
        Me.Bar1.Location = New System.Drawing.Point(0, 319)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(759, 41)
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
        'SuperTabControl1
        '
        Me.SuperTabControl1.BackColor = System.Drawing.Color.White
        '
        '
        '
        '
        '
        '
        Me.SuperTabControl1.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.SuperTabControl1.ControlBox.MenuBox.Name = ""
        Me.SuperTabControl1.ControlBox.Name = ""
        Me.SuperTabControl1.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabControl1.ControlBox.MenuBox, Me.SuperTabControl1.ControlBox.CloseBox})
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel2)
        Me.SuperTabControl1.ForeColor = System.Drawing.Color.Black
        Me.SuperTabControl1.Location = New System.Drawing.Point(12, 12)
        Me.SuperTabControl1.Name = "SuperTabControl1"
        Me.SuperTabControl1.ReorderTabsEnabled = True
        Me.SuperTabControl1.SelectedTabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.SuperTabControl1.SelectedTabIndex = 2
        Me.SuperTabControl1.Size = New System.Drawing.Size(737, 292)
        Me.SuperTabControl1.TabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SuperTabControl1.TabIndex = 133
        Me.SuperTabControl1.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabItem2})
        Me.SuperTabControl1.Text = "SuperTabControl1"
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Controls.Add(Me.GroupBox1)
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 31)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(737, 261)
        Me.SuperTabControlPanel2.TabIndex = 0
        Me.SuperTabControlPanel2.TabItem = Me.SuperTabItem2
        '
        'SuperTabItem2
        '
        Me.SuperTabItem2.AttachedControl = Me.SuperTabControlPanel2
        Me.SuperTabItem2.GlobalItem = False
        Me.SuperTabItem2.Name = "SuperTabItem2"
        Me.SuperTabItem2.Text = "Datos de conexión"
        '
        'SuperTabItem1
        '
        Me.SuperTabItem1.AttachedControl = Me.SuperTabControlPanel1
        Me.SuperTabItem1.GlobalItem = False
        Me.SuperTabItem1.Name = "SuperTabItem1"
        Me.SuperTabItem1.Text = "Facturación/Boletas"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.LabelX13)
        Me.SuperTabControlPanel1.Controls.Add(Me.Txt_ModalidadFac)
        Me.SuperTabControlPanel1.Controls.Add(Me.LabelX15)
        Me.SuperTabControlPanel1.Controls.Add(Me.Txt_Concepto_D)
        Me.SuperTabControlPanel1.Controls.Add(Me.LabelX12)
        Me.SuperTabControlPanel1.Controls.Add(Me.LabelX4)
        Me.SuperTabControlPanel1.Controls.Add(Me.Txt_Bodega)
        Me.SuperTabControlPanel1.Controls.Add(Me.Txt_Concepto_R)
        Me.SuperTabControlPanel1.Controls.Add(Me.Txt_Global_BaseBk)
        Me.SuperTabControlPanel1.Controls.Add(Me.LabelX3)
        Me.SuperTabControlPanel1.Controls.Add(Me.LabelX16)
        Me.SuperTabControlPanel1.Controls.Add(Me.Cmb_DocEmitir)
        Me.SuperTabControlPanel1.Controls.Add(Me.Txt_Empresa)
        Me.SuperTabControlPanel1.Controls.Add(Me.LabelX2)
        Me.SuperTabControlPanel1.Controls.Add(Me.LabelX17)
        Me.SuperTabControlPanel1.Controls.Add(Me.Chk_Facturar)
        Me.SuperTabControlPanel1.Controls.Add(Me.Txt_Vendedor)
        Me.SuperTabControlPanel1.Controls.Add(Me.Txt_Responsable)
        Me.SuperTabControlPanel1.Controls.Add(Me.LabelX18)
        Me.SuperTabControlPanel1.Controls.Add(Me.LabelX1)
        Me.SuperTabControlPanel1.Controls.Add(Me.Txt_RutaEtiquetas)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 31)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(737, 261)
        Me.SuperTabControlPanel1.TabIndex = 1
        Me.SuperTabControlPanel1.TabItem = Me.SuperTabItem1
        '
        'LabelX13
        '
        Me.LabelX13.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX13.ForeColor = System.Drawing.Color.Black
        Me.LabelX13.Location = New System.Drawing.Point(13, 68)
        Me.LabelX13.Name = "LabelX13"
        Me.LabelX13.Size = New System.Drawing.Size(112, 20)
        Me.LabelX13.TabIndex = 133
        Me.LabelX13.Text = "Modalidad"
        '
        'Txt_ModalidadFac
        '
        Me.Txt_ModalidadFac.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_ModalidadFac.Border.Class = "TextBoxBorder"
        Me.Txt_ModalidadFac.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_ModalidadFac.ButtonCustom.Image = CType(resources.GetObject("Txt_ModalidadFac.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_ModalidadFac.ButtonCustom.Visible = True
        Me.Txt_ModalidadFac.ButtonCustom2.Image = CType(resources.GetObject("Txt_ModalidadFac.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_ModalidadFac.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_ModalidadFac.ForeColor = System.Drawing.Color.Black
        Me.Txt_ModalidadFac.Location = New System.Drawing.Point(146, 69)
        Me.Txt_ModalidadFac.Name = "Txt_ModalidadFac"
        Me.Txt_ModalidadFac.PreventEnterBeep = True
        Me.Txt_ModalidadFac.ReadOnly = True
        Me.Txt_ModalidadFac.Size = New System.Drawing.Size(253, 22)
        Me.Txt_ModalidadFac.TabIndex = 134
        Me.Txt_ModalidadFac.WatermarkText = "Modalidad que factura"
        '
        'LabelX15
        '
        Me.LabelX15.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX15.ForeColor = System.Drawing.Color.Black
        Me.LabelX15.Location = New System.Drawing.Point(13, 12)
        Me.LabelX15.Name = "LabelX15"
        Me.LabelX15.Size = New System.Drawing.Size(112, 20)
        Me.LabelX15.TabIndex = 116
        Me.LabelX15.Text = "Nombre Base Bakapp"
        '
        'Txt_Concepto_D
        '
        Me.Txt_Concepto_D.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Concepto_D.Border.Class = "TextBoxBorder"
        Me.Txt_Concepto_D.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Concepto_D.ButtonCustom.Image = CType(resources.GetObject("Txt_Concepto_D.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Concepto_D.ButtonCustom.Visible = True
        Me.Txt_Concepto_D.ButtonCustom2.Image = CType(resources.GetObject("Txt_Concepto_D.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Concepto_D.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Concepto_D.ForeColor = System.Drawing.Color.Black
        Me.Txt_Concepto_D.Location = New System.Drawing.Point(146, 233)
        Me.Txt_Concepto_D.Name = "Txt_Concepto_D"
        Me.Txt_Concepto_D.PreventEnterBeep = True
        Me.Txt_Concepto_D.ReadOnly = True
        Me.Txt_Concepto_D.Size = New System.Drawing.Size(253, 22)
        Me.Txt_Concepto_D.TabIndex = 132
        Me.Txt_Concepto_D.WatermarkText = "Concepto de ajuste de pesos (DESCUENTO)"
        '
        'LabelX12
        '
        Me.LabelX12.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX12.ForeColor = System.Drawing.Color.Black
        Me.LabelX12.Location = New System.Drawing.Point(13, 99)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(112, 20)
        Me.LabelX12.TabIndex = 113
        Me.LabelX12.Text = "Bodega de facturación"
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(13, 235)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(112, 20)
        Me.LabelX4.TabIndex = 131
        Me.LabelX4.Text = "Concepto descuento"
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
        Me.Txt_Bodega.Location = New System.Drawing.Point(146, 97)
        Me.Txt_Bodega.Name = "Txt_Bodega"
        Me.Txt_Bodega.PreventEnterBeep = True
        Me.Txt_Bodega.ReadOnly = True
        Me.Txt_Bodega.Size = New System.Drawing.Size(253, 22)
        Me.Txt_Bodega.TabIndex = 114
        Me.Txt_Bodega.WatermarkText = "Bodega desde donde se sacan los productos"
        '
        'Txt_Concepto_R
        '
        Me.Txt_Concepto_R.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Concepto_R.Border.Class = "TextBoxBorder"
        Me.Txt_Concepto_R.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Concepto_R.ButtonCustom.Image = CType(resources.GetObject("Txt_Concepto_R.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Concepto_R.ButtonCustom.Visible = True
        Me.Txt_Concepto_R.ButtonCustom2.Image = CType(resources.GetObject("Txt_Concepto_R.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Concepto_R.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Concepto_R.ForeColor = System.Drawing.Color.Black
        Me.Txt_Concepto_R.Location = New System.Drawing.Point(146, 207)
        Me.Txt_Concepto_R.Name = "Txt_Concepto_R"
        Me.Txt_Concepto_R.PreventEnterBeep = True
        Me.Txt_Concepto_R.ReadOnly = True
        Me.Txt_Concepto_R.Size = New System.Drawing.Size(253, 22)
        Me.Txt_Concepto_R.TabIndex = 130
        Me.Txt_Concepto_R.WatermarkText = "Concepto de ajuste de pesos (RECARGO)"
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
        Me.Txt_Global_BaseBk.Location = New System.Drawing.Point(146, 12)
        Me.Txt_Global_BaseBk.Name = "Txt_Global_BaseBk"
        Me.Txt_Global_BaseBk.PreventEnterBeep = True
        Me.Txt_Global_BaseBk.Size = New System.Drawing.Size(253, 22)
        Me.Txt_Global_BaseBk.TabIndex = 115
        Me.Txt_Global_BaseBk.WatermarkText = "Nombre de base de datos de Bakapp"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(13, 209)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(112, 20)
        Me.LabelX3.TabIndex = 129
        Me.LabelX3.Text = "Concepto recargo"
        '
        'LabelX16
        '
        Me.LabelX16.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX16.ForeColor = System.Drawing.Color.Black
        Me.LabelX16.Location = New System.Drawing.Point(13, 40)
        Me.LabelX16.Name = "LabelX16"
        Me.LabelX16.Size = New System.Drawing.Size(112, 20)
        Me.LabelX16.TabIndex = 117
        Me.LabelX16.Text = "Empresa"
        '
        'Cmb_DocEmitir
        '
        Me.Cmb_DocEmitir.DisplayMember = "Text"
        Me.Cmb_DocEmitir.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_DocEmitir.ForeColor = System.Drawing.Color.Black
        Me.Cmb_DocEmitir.FormattingEnabled = True
        Me.Cmb_DocEmitir.ItemHeight = 20
        Me.Cmb_DocEmitir.Location = New System.Drawing.Point(641, 155)
        Me.Cmb_DocEmitir.Name = "Cmb_DocEmitir"
        Me.Cmb_DocEmitir.Size = New System.Drawing.Size(79, 26)
        Me.Cmb_DocEmitir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_DocEmitir.TabIndex = 128
        Me.Cmb_DocEmitir.Text = "FACTURA"
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
        Me.Txt_Empresa.Location = New System.Drawing.Point(146, 41)
        Me.Txt_Empresa.Name = "Txt_Empresa"
        Me.Txt_Empresa.PreventEnterBeep = True
        Me.Txt_Empresa.ReadOnly = True
        Me.Txt_Empresa.Size = New System.Drawing.Size(253, 22)
        Me.Txt_Empresa.TabIndex = 118
        Me.Txt_Empresa.WatermarkText = "Empresa a conectar"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(529, 153)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(106, 24)
        Me.LabelX2.TabIndex = 127
        Me.LabelX2.Text = "Documento a emitir"
        '
        'LabelX17
        '
        Me.LabelX17.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX17.ForeColor = System.Drawing.Color.Black
        Me.LabelX17.Location = New System.Drawing.Point(13, 127)
        Me.LabelX17.Name = "LabelX17"
        Me.LabelX17.Size = New System.Drawing.Size(112, 20)
        Me.LabelX17.TabIndex = 119
        Me.LabelX17.Text = "Vendedor"
        '
        'Chk_Facturar
        '
        Me.Chk_Facturar.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Facturar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Facturar.CheckBoxImageChecked = CType(resources.GetObject("Chk_Facturar.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Facturar.ForeColor = System.Drawing.Color.Black
        Me.Chk_Facturar.Location = New System.Drawing.Point(405, 155)
        Me.Chk_Facturar.Name = "Chk_Facturar"
        Me.Chk_Facturar.Size = New System.Drawing.Size(100, 21)
        Me.Chk_Facturar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Facturar.TabIndex = 125
        Me.Chk_Facturar.Text = "Facturar/Boletear"
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
        Me.Txt_Vendedor.Location = New System.Drawing.Point(146, 125)
        Me.Txt_Vendedor.Name = "Txt_Vendedor"
        Me.Txt_Vendedor.PreventEnterBeep = True
        Me.Txt_Vendedor.ReadOnly = True
        Me.Txt_Vendedor.Size = New System.Drawing.Size(253, 22)
        Me.Txt_Vendedor.TabIndex = 120
        Me.Txt_Vendedor.WatermarkText = "Vendedor asociados a las notas de venta"
        '
        'Txt_Responsable
        '
        Me.Txt_Responsable.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Responsable.Border.Class = "TextBoxBorder"
        Me.Txt_Responsable.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Responsable.ButtonCustom.Image = CType(resources.GetObject("Txt_Responsable.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Responsable.ButtonCustom.Visible = True
        Me.Txt_Responsable.ButtonCustom2.Image = CType(resources.GetObject("Txt_Responsable.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Responsable.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Responsable.ForeColor = System.Drawing.Color.Black
        Me.Txt_Responsable.Location = New System.Drawing.Point(146, 153)
        Me.Txt_Responsable.Name = "Txt_Responsable"
        Me.Txt_Responsable.PreventEnterBeep = True
        Me.Txt_Responsable.ReadOnly = True
        Me.Txt_Responsable.Size = New System.Drawing.Size(253, 22)
        Me.Txt_Responsable.TabIndex = 124
        Me.Txt_Responsable.WatermarkText = "Responsable del documento"
        '
        'LabelX18
        '
        Me.LabelX18.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX18.ForeColor = System.Drawing.Color.Black
        Me.LabelX18.Location = New System.Drawing.Point(13, 183)
        Me.LabelX18.Name = "LabelX18"
        Me.LabelX18.Size = New System.Drawing.Size(112, 20)
        Me.LabelX18.TabIndex = 121
        Me.LabelX18.Text = "Ruta PDF"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(13, 155)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(127, 20)
        Me.LabelX1.TabIndex = 123
        Me.LabelX1.Text = "Facturador/Responsable"
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
        Me.Txt_RutaEtiquetas.Location = New System.Drawing.Point(146, 181)
        Me.Txt_RutaEtiquetas.Name = "Txt_RutaEtiquetas"
        Me.Txt_RutaEtiquetas.PreventEnterBeep = True
        Me.Txt_RutaEtiquetas.ReadOnly = True
        Me.Txt_RutaEtiquetas.Size = New System.Drawing.Size(575, 22)
        Me.Txt_RutaEtiquetas.TabIndex = 122
        Me.Txt_RutaEtiquetas.WatermarkText = "Ruta de PDF"
        '
        'TxtBakApp
        '
        Me.TxtBakApp.BackColor = System.Drawing.Color.White
        Me.TxtBakApp.ForeColor = System.Drawing.Color.Black
        Me.TxtBakApp.Location = New System.Drawing.Point(320, 166)
        Me.TxtBakApp.Name = "TxtBakApp"
        Me.TxtBakApp.Size = New System.Drawing.Size(207, 26)
        Me.TxtBakApp.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.White
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(209, 169)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 19)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "BakApp BD"
        '
        'Frm_Configuracion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(759, 360)
        Me.Controls.Add(Me.SuperTabControl1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Configuracion"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CONFIGURACION DE SISTEMA DE SINCRONIZACION SHOPIFY VS BAKAPP"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControl1.ResumeLayout(False)
        Me.SuperTabControlPanel2.ResumeLayout(False)
        Me.SuperTabControlPanel1.ResumeLayout(False)
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
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents SuperTabControl1 As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem2 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabItem1 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_ModalidadFac As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX15 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Concepto_D As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Bodega As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Concepto_R As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Global_BaseBk As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX16 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Cmb_DocEmitir As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Txt_Empresa As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX17 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Chk_Facturar As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Txt_Vendedor As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Responsable As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX18 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_RutaEtiquetas As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtBakApp As TextBox
    Friend WithEvents Label6 As Label
End Class
