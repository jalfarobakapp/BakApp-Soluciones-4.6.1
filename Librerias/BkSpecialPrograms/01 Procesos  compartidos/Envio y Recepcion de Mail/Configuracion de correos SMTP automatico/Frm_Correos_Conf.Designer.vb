<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Correos_Conf
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Correos_Conf))
        Me.Txt_Puerto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Contrasena = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Remitente = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Host_SMTP = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Grupo_Info_Sesion = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Btn_Cuentas = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Btn_Ver_Contrasena = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.Chk_SSL = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Firma = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Chk_Auto_Asunto = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Para = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_CC = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Asunto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Eliminar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Probar_Envio = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Vista_Previa = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Probar_GMAIL = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Carpeta_Imagenes = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel4 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.SuperTabControl2 = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.Btn_Subrayada = New System.Windows.Forms.Button()
        Me.Btn_Cursiva = New System.Windows.Forms.Button()
        Me.Btn_Negrita = New System.Windows.Forms.Button()
        Me.Cmb_Fuente = New System.Windows.Forms.ComboBox()
        Me.Rtf_Cuerpo = New System.Windows.Forms.RichTextBox()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Mnu_Tex_CortarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Mnu_Tex_CopiarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Mnu_Tex_PegarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Pict_Color_Resaltado = New System.Windows.Forms.PictureBox()
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX()
        Me.Pict_Color_Fuente = New System.Windows.Forms.PictureBox()
        Me.Input_Size = New DevComponents.Editors.IntegerInput()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.Color_Resaltado = New DevComponents.DotNetBar.ColorPickerDropDown()
        Me.LabelX14 = New DevComponents.DotNetBar.LabelX()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.Color_Fuente = New DevComponents.DotNetBar.ColorPickerDropDown()
        Me.Chk_Es_Html = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.SuperTabItem2 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel4 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.Txt_Cuerpo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.SuperTabItem4 = New DevComponents.DotNetBar.SuperTabItem()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Nombre_Correo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Rdb_Envio_Automatico = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Rdb_Envio_Manual = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.SuperTabControl1 = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.SuperTabItem1 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel3 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.SuperTabItem3 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SCor = New System.Windows.Forms.ColorDialog()
        Me.Grupo_Info_Sesion.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel4.SuspendLayout()
        CType(Me.SuperTabControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControl2.SuspendLayout()
        Me.SuperTabControlPanel2.SuspendLayout()
        Me.ContextMenuStrip2.SuspendLayout()
        CType(Me.Pict_Color_Resaltado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pict_Color_Fuente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Input_Size, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel4.SuspendLayout()
        Me.GroupPanel2.SuspendLayout()
        Me.GroupPanel3.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControl1.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        Me.SuperTabControlPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Txt_Puerto
        '
        Me.Txt_Puerto.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Puerto.Border.Class = "TextBoxBorder"
        Me.Txt_Puerto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Puerto.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Puerto.ForeColor = System.Drawing.Color.Black
        Me.Txt_Puerto.Location = New System.Drawing.Point(509, 30)
        Me.Txt_Puerto.Name = "Txt_Puerto"
        Me.Txt_Puerto.PreventEnterBeep = True
        Me.Txt_Puerto.ReadOnly = True
        Me.Txt_Puerto.Size = New System.Drawing.Size(50, 22)
        Me.Txt_Puerto.TabIndex = 7
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(310, 30)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(75, 21)
        Me.LabelX4.TabIndex = 6
        Me.LabelX4.Text = "Puerto"
        '
        'Txt_Contrasena
        '
        Me.Txt_Contrasena.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Contrasena.Border.Class = "TextBoxBorder"
        Me.Txt_Contrasena.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Contrasena.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Contrasena.ForeColor = System.Drawing.Color.Black
        Me.Txt_Contrasena.Location = New System.Drawing.Point(72, 30)
        Me.Txt_Contrasena.Name = "Txt_Contrasena"
        Me.Txt_Contrasena.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Txt_Contrasena.PreventEnterBeep = True
        Me.Txt_Contrasena.ReadOnly = True
        Me.Txt_Contrasena.Size = New System.Drawing.Size(232, 22)
        Me.Txt_Contrasena.TabIndex = 5
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(3, 30)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(39, 21)
        Me.LabelX3.TabIndex = 4
        Me.LabelX3.Text = "Contraseña"
        '
        'Txt_Remitente
        '
        Me.Txt_Remitente.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Remitente.Border.Class = "TextBoxBorder"
        Me.Txt_Remitente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Remitente.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Remitente.ForeColor = System.Drawing.Color.Black
        Me.Txt_Remitente.Location = New System.Drawing.Point(72, 3)
        Me.Txt_Remitente.Name = "Txt_Remitente"
        Me.Txt_Remitente.PreventEnterBeep = True
        Me.Txt_Remitente.ReadOnly = True
        Me.Txt_Remitente.Size = New System.Drawing.Size(232, 22)
        Me.Txt_Remitente.TabIndex = 3
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 3)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(39, 21)
        Me.LabelX2.TabIndex = 2
        Me.LabelX2.Text = "Correo"
        '
        'Txt_Host_SMTP
        '
        Me.Txt_Host_SMTP.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Host_SMTP.Border.Class = "TextBoxBorder"
        Me.Txt_Host_SMTP.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Host_SMTP.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Host_SMTP.ForeColor = System.Drawing.Color.Black
        Me.Txt_Host_SMTP.Location = New System.Drawing.Point(509, 3)
        Me.Txt_Host_SMTP.Name = "Txt_Host_SMTP"
        Me.Txt_Host_SMTP.PreventEnterBeep = True
        Me.Txt_Host_SMTP.ReadOnly = True
        Me.Txt_Host_SMTP.Size = New System.Drawing.Size(210, 22)
        Me.Txt_Host_SMTP.TabIndex = 1
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(310, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(173, 21)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "Servidor de correo saliente (SMTP)"
        '
        'Grupo_Info_Sesion
        '
        Me.Grupo_Info_Sesion.BackColor = System.Drawing.Color.White
        Me.Grupo_Info_Sesion.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Info_Sesion.Controls.Add(Me.Btn_Cuentas)
        Me.Grupo_Info_Sesion.Controls.Add(Me.LabelX5)
        Me.Grupo_Info_Sesion.Controls.Add(Me.TableLayoutPanel1)
        Me.Grupo_Info_Sesion.Controls.Add(Me.LabelX6)
        Me.Grupo_Info_Sesion.Controls.Add(Me.Chk_SSL)
        Me.Grupo_Info_Sesion.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Info_Sesion.Location = New System.Drawing.Point(5, 12)
        Me.Grupo_Info_Sesion.Name = "Grupo_Info_Sesion"
        Me.Grupo_Info_Sesion.Size = New System.Drawing.Size(772, 141)
        '
        '
        '
        Me.Grupo_Info_Sesion.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Info_Sesion.Style.BackColorGradientAngle = 90
        Me.Grupo_Info_Sesion.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Info_Sesion.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Info_Sesion.Style.BorderBottomWidth = 1
        Me.Grupo_Info_Sesion.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Info_Sesion.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Info_Sesion.Style.BorderLeftWidth = 1
        Me.Grupo_Info_Sesion.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Info_Sesion.Style.BorderRightWidth = 1
        Me.Grupo_Info_Sesion.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Info_Sesion.Style.BorderTopWidth = 1
        Me.Grupo_Info_Sesion.Style.CornerDiameter = 4
        Me.Grupo_Info_Sesion.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Info_Sesion.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Info_Sesion.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Info_Sesion.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Info_Sesion.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Info_Sesion.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Info_Sesion.TabIndex = 1
        Me.Grupo_Info_Sesion.Text = "Cuenta de salida de mensaje (Correo SMTP)"
        '
        'Btn_Cuentas
        '
        Me.Btn_Cuentas.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText
        Me.Btn_Cuentas.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Cuentas.Image = CType(resources.GetObject("Btn_Cuentas.Image"), System.Drawing.Image)
        Me.Btn_Cuentas.Location = New System.Drawing.Point(3, 92)
        Me.Btn_Cuentas.Name = "Btn_Cuentas"
        Me.Btn_Cuentas.Size = New System.Drawing.Size(175, 21)
        Me.Btn_Cuentas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Cuentas.TabIndex = 25
        Me.Btn_Cuentas.Text = "Seleccionar cuenta (SMTP)"
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(343, 2)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(162, 23)
        Me.LabelX5.TabIndex = 13
        Me.LabelX5.Text = "<b>Credenciales de la cuenta</b>"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.09434!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.90566!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 238.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 199.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 259.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Host_SMTP, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX1, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Remitente, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Btn_Ver_Contrasena, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX3, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Contrasena, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX4, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Puerto, 4, 1)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 31)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(766, 54)
        Me.TableLayoutPanel1.TabIndex = 24
        '
        'Btn_Ver_Contrasena
        '
        Me.Btn_Ver_Contrasena.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText
        Me.Btn_Ver_Contrasena.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Ver_Contrasena.Image = CType(resources.GetObject("Btn_Ver_Contrasena.Image"), System.Drawing.Image)
        Me.Btn_Ver_Contrasena.Location = New System.Drawing.Point(48, 30)
        Me.Btn_Ver_Contrasena.Name = "Btn_Ver_Contrasena"
        Me.Btn_Ver_Contrasena.Size = New System.Drawing.Size(18, 21)
        Me.Btn_Ver_Contrasena.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Ver_Contrasena.TabIndex = 14
        Me.Btn_Ver_Contrasena.Tooltip = "Ver contraseña"
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(3, 3)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(228, 23)
        Me.LabelX6.TabIndex = 11
        Me.LabelX6.Text = "<b>Información de inicio de sesión</b>"
        '
        'Chk_SSL
        '
        Me.Chk_SSL.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_SSL.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_SSL.Enabled = False
        Me.Chk_SSL.ForeColor = System.Drawing.Color.Black
        Me.Chk_SSL.Location = New System.Drawing.Point(518, 2)
        Me.Chk_SSL.Name = "Chk_SSL"
        Me.Chk_SSL.Size = New System.Drawing.Size(127, 23)
        Me.Chk_SSL.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_SSL.TabIndex = 10
        Me.Chk_SSL.Text = "Conexión cifrada (SSL)"
        '
        'Chk_Firma
        '
        Me.Chk_Firma.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Firma.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Firma.ForeColor = System.Drawing.Color.Black
        Me.Chk_Firma.Location = New System.Drawing.Point(518, 3)
        Me.Chk_Firma.Name = "Chk_Firma"
        Me.Chk_Firma.Size = New System.Drawing.Size(239, 20)
        Me.Chk_Firma.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Firma.TabIndex = 25
        Me.Chk_Firma.Text = "Firma"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.Controls.Add(Me.Chk_Auto_Asunto, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelX10, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelX7, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelX8, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Txt_Para, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Txt_CC, 2, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Txt_Asunto, 2, 0)
        Me.TableLayoutPanel2.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 32)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(760, 78)
        Me.TableLayoutPanel2.TabIndex = 9
        '
        'Chk_Auto_Asunto
        '
        Me.Chk_Auto_Asunto.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Auto_Asunto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Auto_Asunto.ForeColor = System.Drawing.Color.Black
        Me.Chk_Auto_Asunto.Location = New System.Drawing.Point(48, 3)
        Me.Chk_Auto_Asunto.Name = "Chk_Auto_Asunto"
        Me.Chk_Auto_Asunto.Size = New System.Drawing.Size(127, 20)
        Me.Chk_Auto_Asunto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Auto_Asunto.TabIndex = 18
        Me.Chk_Auto_Asunto.Text = "Asunto automatico"
        '
        'LabelX10
        '
        Me.LabelX10.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.ForeColor = System.Drawing.Color.Black
        Me.LabelX10.Location = New System.Drawing.Point(3, 55)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(24, 20)
        Me.LabelX10.TabIndex = 22
        Me.LabelX10.Text = "CC"
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.ForeColor = System.Drawing.Color.Black
        Me.LabelX7.Location = New System.Drawing.Point(3, 3)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(39, 20)
        Me.LabelX7.TabIndex = 19
        Me.LabelX7.Text = "Asunto"
        '
        'LabelX8
        '
        Me.LabelX8.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.ForeColor = System.Drawing.Color.Black
        Me.LabelX8.Location = New System.Drawing.Point(3, 29)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(24, 20)
        Me.LabelX8.TabIndex = 17
        Me.LabelX8.Text = "Para"
        '
        'Txt_Para
        '
        Me.Txt_Para.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Para.Border.Class = "TextBoxBorder"
        Me.Txt_Para.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Para.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Para.ForeColor = System.Drawing.Color.Black
        Me.Txt_Para.Location = New System.Drawing.Point(181, 29)
        Me.Txt_Para.Multiline = True
        Me.Txt_Para.Name = "Txt_Para"
        Me.Txt_Para.PreventEnterBeep = True
        Me.Txt_Para.Size = New System.Drawing.Size(574, 20)
        Me.Txt_Para.TabIndex = 18
        '
        'Txt_CC
        '
        Me.Txt_CC.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_CC.Border.Class = "TextBoxBorder"
        Me.Txt_CC.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_CC.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_CC.ForeColor = System.Drawing.Color.Black
        Me.Txt_CC.Location = New System.Drawing.Point(181, 55)
        Me.Txt_CC.Multiline = True
        Me.Txt_CC.Name = "Txt_CC"
        Me.Txt_CC.PreventEnterBeep = True
        Me.Txt_CC.Size = New System.Drawing.Size(574, 20)
        Me.Txt_CC.TabIndex = 23
        '
        'Txt_Asunto
        '
        Me.Txt_Asunto.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Asunto.Border.Class = "TextBoxBorder"
        Me.Txt_Asunto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Asunto.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Asunto.ForeColor = System.Drawing.Color.Black
        Me.Txt_Asunto.Location = New System.Drawing.Point(181, 3)
        Me.Txt_Asunto.Name = "Txt_Asunto"
        Me.Txt_Asunto.PreventEnterBeep = True
        Me.Txt_Asunto.Size = New System.Drawing.Size(574, 22)
        Me.Txt_Asunto.TabIndex = 20
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar, Me.Btn_Eliminar, Me.Btn_Probar_Envio, Me.Btn_Vista_Previa, Me.Btn_Probar_GMAIL, Me.Btn_Carpeta_Imagenes})
        Me.Bar1.Location = New System.Drawing.Point(0, 583)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(796, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 3
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
        Me.Btn_Grabar.Tooltip = "Grabar Servidor de correo de salida SMTP"
        '
        'Btn_Eliminar
        '
        Me.Btn_Eliminar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Eliminar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Eliminar.Image = CType(resources.GetObject("Btn_Eliminar.Image"), System.Drawing.Image)
        Me.Btn_Eliminar.ImageAlt = CType(resources.GetObject("Btn_Eliminar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Eliminar.Name = "Btn_Eliminar"
        Me.Btn_Eliminar.Tooltip = "Eliminar Servidor de correo de salida SMTP"
        '
        'Btn_Probar_Envio
        '
        Me.Btn_Probar_Envio.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Probar_Envio.ForeColor = System.Drawing.Color.Black
        Me.Btn_Probar_Envio.Image = CType(resources.GetObject("Btn_Probar_Envio.Image"), System.Drawing.Image)
        Me.Btn_Probar_Envio.ImageAlt = CType(resources.GetObject("Btn_Probar_Envio.ImageAlt"), System.Drawing.Image)
        Me.Btn_Probar_Envio.Name = "Btn_Probar_Envio"
        Me.Btn_Probar_Envio.Text = "Probar correo"
        '
        'Btn_Vista_Previa
        '
        Me.Btn_Vista_Previa.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Vista_Previa.ForeColor = System.Drawing.Color.Black
        Me.Btn_Vista_Previa.Image = CType(resources.GetObject("Btn_Vista_Previa.Image"), System.Drawing.Image)
        Me.Btn_Vista_Previa.Name = "Btn_Vista_Previa"
        Me.Btn_Vista_Previa.Tooltip = "Vista previa del correo"
        '
        'Btn_Probar_GMAIL
        '
        Me.Btn_Probar_GMAIL.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Probar_GMAIL.ForeColor = System.Drawing.Color.Black
        Me.Btn_Probar_GMAIL.Image = CType(resources.GetObject("Btn_Probar_GMAIL.Image"), System.Drawing.Image)
        Me.Btn_Probar_GMAIL.Name = "Btn_Probar_GMAIL"
        Me.Btn_Probar_GMAIL.Text = "Probar correo  GMAIL"
        Me.Btn_Probar_GMAIL.Visible = False
        '
        'Btn_Carpeta_Imagenes
        '
        Me.Btn_Carpeta_Imagenes.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Carpeta_Imagenes.ForeColor = System.Drawing.Color.Black
        Me.Btn_Carpeta_Imagenes.Image = CType(resources.GetObject("Btn_Carpeta_Imagenes.Image"), System.Drawing.Image)
        Me.Btn_Carpeta_Imagenes.ImageAlt = CType(resources.GetObject("Btn_Carpeta_Imagenes.ImageAlt"), System.Drawing.Image)
        Me.Btn_Carpeta_Imagenes.Name = "Btn_Carpeta_Imagenes"
        Me.Btn_Carpeta_Imagenes.Tooltip = "Carpeta en donde deben de estar las imagenes"
        '
        'GroupPanel4
        '
        Me.GroupPanel4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupPanel4.BackColor = System.Drawing.Color.White
        Me.GroupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel4.Controls.Add(Me.SuperTabControl2)
        Me.GroupPanel4.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel4.Location = New System.Drawing.Point(0, 0)
        Me.GroupPanel4.Name = "GroupPanel4"
        Me.GroupPanel4.Size = New System.Drawing.Size(777, 454)
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
        Me.GroupPanel4.TabIndex = 6
        '
        'SuperTabControl2
        '
        Me.SuperTabControl2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SuperTabControl2.BackColor = System.Drawing.Color.White
        '
        '
        '
        '
        '
        '
        Me.SuperTabControl2.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.SuperTabControl2.ControlBox.MenuBox.Name = ""
        Me.SuperTabControl2.ControlBox.Name = ""
        Me.SuperTabControl2.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabControl2.ControlBox.MenuBox, Me.SuperTabControl2.ControlBox.CloseBox})
        Me.SuperTabControl2.Controls.Add(Me.SuperTabControlPanel2)
        Me.SuperTabControl2.Controls.Add(Me.SuperTabControlPanel4)
        Me.SuperTabControl2.ForeColor = System.Drawing.Color.Black
        Me.SuperTabControl2.Location = New System.Drawing.Point(3, 5)
        Me.SuperTabControl2.Name = "SuperTabControl2"
        Me.SuperTabControl2.ReorderTabsEnabled = True
        Me.SuperTabControl2.SelectedTabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.SuperTabControl2.SelectedTabIndex = 0
        Me.SuperTabControl2.Size = New System.Drawing.Size(765, 440)
        Me.SuperTabControl2.TabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SuperTabControl2.TabIndex = 29
        Me.SuperTabControl2.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabItem2, Me.SuperTabItem4})
        Me.SuperTabControl2.Text = "SuperTabControl2"
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Controls.Add(Me.Btn_Subrayada)
        Me.SuperTabControlPanel2.Controls.Add(Me.Btn_Cursiva)
        Me.SuperTabControlPanel2.Controls.Add(Me.Btn_Negrita)
        Me.SuperTabControlPanel2.Controls.Add(Me.Cmb_Fuente)
        Me.SuperTabControlPanel2.Controls.Add(Me.Rtf_Cuerpo)
        Me.SuperTabControlPanel2.Controls.Add(Me.Pict_Color_Resaltado)
        Me.SuperTabControlPanel2.Controls.Add(Me.LabelX13)
        Me.SuperTabControlPanel2.Controls.Add(Me.Pict_Color_Fuente)
        Me.SuperTabControlPanel2.Controls.Add(Me.Input_Size)
        Me.SuperTabControlPanel2.Controls.Add(Me.ButtonX2)
        Me.SuperTabControlPanel2.Controls.Add(Me.LabelX14)
        Me.SuperTabControlPanel2.Controls.Add(Me.ButtonX1)
        Me.SuperTabControlPanel2.Controls.Add(Me.Chk_Es_Html)
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 27)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(765, 413)
        Me.SuperTabControlPanel2.TabIndex = 1
        Me.SuperTabControlPanel2.TabItem = Me.SuperTabItem2
        '
        'Btn_Subrayada
        '
        Me.Btn_Subrayada.BackColor = System.Drawing.Color.White
        Me.Btn_Subrayada.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Subrayada.ForeColor = System.Drawing.Color.Black
        Me.Btn_Subrayada.Location = New System.Drawing.Point(562, 2)
        Me.Btn_Subrayada.Name = "Btn_Subrayada"
        Me.Btn_Subrayada.Size = New System.Drawing.Size(31, 23)
        Me.Btn_Subrayada.TabIndex = 40
        Me.Btn_Subrayada.Text = "S"
        Me.Btn_Subrayada.UseVisualStyleBackColor = False
        '
        'Btn_Cursiva
        '
        Me.Btn_Cursiva.BackColor = System.Drawing.Color.White
        Me.Btn_Cursiva.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Cursiva.ForeColor = System.Drawing.Color.Black
        Me.Btn_Cursiva.Location = New System.Drawing.Point(525, 2)
        Me.Btn_Cursiva.Name = "Btn_Cursiva"
        Me.Btn_Cursiva.Size = New System.Drawing.Size(31, 23)
        Me.Btn_Cursiva.TabIndex = 39
        Me.Btn_Cursiva.Text = "K"
        Me.Btn_Cursiva.UseVisualStyleBackColor = False
        '
        'Btn_Negrita
        '
        Me.Btn_Negrita.BackColor = System.Drawing.Color.White
        Me.Btn_Negrita.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Negrita.ForeColor = System.Drawing.Color.Black
        Me.Btn_Negrita.Location = New System.Drawing.Point(488, 2)
        Me.Btn_Negrita.Name = "Btn_Negrita"
        Me.Btn_Negrita.Size = New System.Drawing.Size(31, 23)
        Me.Btn_Negrita.TabIndex = 38
        Me.Btn_Negrita.Text = "N"
        Me.Btn_Negrita.UseVisualStyleBackColor = False
        '
        'Cmb_Fuente
        '
        Me.Cmb_Fuente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cmb_Fuente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cmb_Fuente.BackColor = System.Drawing.Color.White
        Me.Cmb_Fuente.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.Cmb_Fuente.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Fuente.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Fuente.FormattingEnabled = True
        Me.Cmb_Fuente.Location = New System.Drawing.Point(44, 2)
        Me.Cmb_Fuente.Name = "Cmb_Fuente"
        Me.Cmb_Fuente.Size = New System.Drawing.Size(209, 24)
        Me.Cmb_Fuente.TabIndex = 37
        '
        'Rtf_Cuerpo
        '
        Me.Rtf_Cuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Rtf_Cuerpo.BackColor = System.Drawing.Color.White
        Me.Rtf_Cuerpo.ContextMenuStrip = Me.ContextMenuStrip2
        Me.Rtf_Cuerpo.ForeColor = System.Drawing.Color.Black
        Me.Rtf_Cuerpo.Location = New System.Drawing.Point(3, 28)
        Me.Rtf_Cuerpo.Name = "Rtf_Cuerpo"
        Me.Rtf_Cuerpo.Size = New System.Drawing.Size(757, 382)
        Me.Rtf_Cuerpo.TabIndex = 27
        Me.Rtf_Cuerpo.Text = ""
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Mnu_Tex_CortarToolStripMenuItem, Me.Mnu_Tex_CopiarToolStripMenuItem, Me.Mnu_Tex_PegarToolStripMenuItem})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(110, 70)
        '
        'Mnu_Tex_CortarToolStripMenuItem
        '
        Me.Mnu_Tex_CortarToolStripMenuItem.Image = CType(resources.GetObject("Mnu_Tex_CortarToolStripMenuItem.Image"), System.Drawing.Image)
        Me.Mnu_Tex_CortarToolStripMenuItem.Name = "Mnu_Tex_CortarToolStripMenuItem"
        Me.Mnu_Tex_CortarToolStripMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.Mnu_Tex_CortarToolStripMenuItem.Text = "Cortar"
        '
        'Mnu_Tex_CopiarToolStripMenuItem
        '
        Me.Mnu_Tex_CopiarToolStripMenuItem.Image = CType(resources.GetObject("Mnu_Tex_CopiarToolStripMenuItem.Image"), System.Drawing.Image)
        Me.Mnu_Tex_CopiarToolStripMenuItem.Name = "Mnu_Tex_CopiarToolStripMenuItem"
        Me.Mnu_Tex_CopiarToolStripMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.Mnu_Tex_CopiarToolStripMenuItem.Text = "Copiar"
        '
        'Mnu_Tex_PegarToolStripMenuItem
        '
        Me.Mnu_Tex_PegarToolStripMenuItem.Image = CType(resources.GetObject("Mnu_Tex_PegarToolStripMenuItem.Image"), System.Drawing.Image)
        Me.Mnu_Tex_PegarToolStripMenuItem.Name = "Mnu_Tex_PegarToolStripMenuItem"
        Me.Mnu_Tex_PegarToolStripMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.Mnu_Tex_PegarToolStripMenuItem.Text = "Pegar"
        '
        'Pict_Color_Resaltado
        '
        Me.Pict_Color_Resaltado.BackColor = System.Drawing.Color.White
        Me.Pict_Color_Resaltado.ForeColor = System.Drawing.Color.Black
        Me.Pict_Color_Resaltado.Location = New System.Drawing.Point(447, 1)
        Me.Pict_Color_Resaltado.Name = "Pict_Color_Resaltado"
        Me.Pict_Color_Resaltado.Size = New System.Drawing.Size(12, 24)
        Me.Pict_Color_Resaltado.TabIndex = 36
        Me.Pict_Color_Resaltado.TabStop = False
        '
        'LabelX13
        '
        Me.LabelX13.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX13.ForeColor = System.Drawing.Color.Black
        Me.LabelX13.Location = New System.Drawing.Point(3, 4)
        Me.LabelX13.Name = "LabelX13"
        Me.LabelX13.Size = New System.Drawing.Size(40, 21)
        Me.LabelX13.TabIndex = 30
        Me.LabelX13.Text = "Fuente"
        '
        'Pict_Color_Fuente
        '
        Me.Pict_Color_Fuente.BackColor = System.Drawing.Color.White
        Me.Pict_Color_Fuente.ForeColor = System.Drawing.Color.Black
        Me.Pict_Color_Fuente.Location = New System.Drawing.Point(392, 2)
        Me.Pict_Color_Fuente.Name = "Pict_Color_Fuente"
        Me.Pict_Color_Fuente.Size = New System.Drawing.Size(10, 23)
        Me.Pict_Color_Fuente.TabIndex = 35
        Me.Pict_Color_Fuente.TabStop = False
        '
        'Input_Size
        '
        Me.Input_Size.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_Size.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_Size.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_Size.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.Input_Size.ForeColor = System.Drawing.Color.Black
        Me.Input_Size.Location = New System.Drawing.Point(305, 2)
        Me.Input_Size.MaxValue = 24
        Me.Input_Size.MinValue = 6
        Me.Input_Size.Name = "Input_Size"
        Me.Input_Size.ShowUpDown = True
        Me.Input_Size.Size = New System.Drawing.Size(47, 22)
        Me.Input_Size.TabIndex = 31
        Me.Input_Size.Value = 8
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX2.Image = CType(resources.GetObject("ButtonX2.Image"), System.Drawing.Image)
        Me.ButtonX2.Location = New System.Drawing.Point(414, 1)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(32, 24)
        Me.ButtonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX2.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Color_Resaltado})
        Me.ButtonX2.TabIndex = 34
        Me.ButtonX2.Tooltip = "Resaltado"
        '
        'Color_Resaltado
        '
        Me.Color_Resaltado.GlobalItem = False
        Me.Color_Resaltado.Name = "Color_Resaltado"
        Me.Color_Resaltado.Text = "Colores"
        '
        'LabelX14
        '
        Me.LabelX14.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX14.ForeColor = System.Drawing.Color.Black
        Me.LabelX14.Location = New System.Drawing.Point(259, 2)
        Me.LabelX14.Name = "LabelX14"
        Me.LabelX14.Size = New System.Drawing.Size(40, 21)
        Me.LabelX14.TabIndex = 32
        Me.LabelX14.Text = "Tamaño"
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Image = CType(resources.GetObject("ButtonX1.Image"), System.Drawing.Image)
        Me.ButtonX1.Location = New System.Drawing.Point(358, 2)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(33, 23)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Color_Fuente})
        Me.ButtonX1.TabIndex = 33
        Me.ButtonX1.Tooltip = "Color de fuente"
        '
        'Color_Fuente
        '
        Me.Color_Fuente.GlobalItem = False
        Me.Color_Fuente.Name = "Color_Fuente"
        Me.Color_Fuente.Text = "Colores"
        '
        'Chk_Es_Html
        '
        Me.Chk_Es_Html.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Es_Html.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Es_Html.Checked = True
        Me.Chk_Es_Html.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_Es_Html.CheckValue = "Y"
        Me.Chk_Es_Html.Enabled = False
        Me.Chk_Es_Html.ForeColor = System.Drawing.Color.Black
        Me.Chk_Es_Html.Location = New System.Drawing.Point(658, 4)
        Me.Chk_Es_Html.Name = "Chk_Es_Html"
        Me.Chk_Es_Html.Size = New System.Drawing.Size(111, 20)
        Me.Chk_Es_Html.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Es_Html.TabIndex = 26
        Me.Chk_Es_Html.Text = "El texto es  HTML"
        '
        'SuperTabItem2
        '
        Me.SuperTabItem2.AttachedControl = Me.SuperTabControlPanel2
        Me.SuperTabItem2.GlobalItem = False
        Me.SuperTabItem2.Name = "SuperTabItem2"
        Me.SuperTabItem2.Text = "Cuerpo del mensaje"
        '
        'SuperTabControlPanel4
        '
        Me.SuperTabControlPanel4.Controls.Add(Me.Txt_Cuerpo)
        Me.SuperTabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel4.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel4.Name = "SuperTabControlPanel4"
        Me.SuperTabControlPanel4.Size = New System.Drawing.Size(765, 440)
        Me.SuperTabControlPanel4.TabIndex = 0
        Me.SuperTabControlPanel4.TabItem = Me.SuperTabItem4
        '
        'Txt_Cuerpo
        '
        Me.Txt_Cuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt_Cuerpo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Cuerpo.Border.Class = "TextBoxBorder"
        Me.Txt_Cuerpo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Cuerpo.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Cuerpo.ForeColor = System.Drawing.Color.Black
        Me.Txt_Cuerpo.Location = New System.Drawing.Point(3, 2)
        Me.Txt_Cuerpo.Multiline = True
        Me.Txt_Cuerpo.Name = "Txt_Cuerpo"
        Me.Txt_Cuerpo.PreventEnterBeep = True
        Me.Txt_Cuerpo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Cuerpo.Size = New System.Drawing.Size(757, 435)
        Me.Txt_Cuerpo.TabIndex = 2
        '
        'SuperTabItem4
        '
        Me.SuperTabItem4.AttachedControl = Me.SuperTabControlPanel4
        Me.SuperTabItem4.GlobalItem = False
        Me.SuperTabItem4.Name = "SuperTabItem4"
        Me.SuperTabItem4.Text = "Texto en Html"
        '
        'LabelX11
        '
        Me.LabelX11.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX11.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX11.ForeColor = System.Drawing.Color.Black
        Me.LabelX11.Location = New System.Drawing.Point(6, -1)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(89, 22)
        Me.LabelX11.TabIndex = 7
        Me.LabelX11.Text = "Nombre correo"
        '
        'Txt_Nombre_Correo
        '
        Me.Txt_Nombre_Correo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt_Nombre_Correo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Nombre_Correo.Border.Class = "TextBoxBorder"
        Me.Txt_Nombre_Correo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Nombre_Correo.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Nombre_Correo.ForeColor = System.Drawing.Color.Black
        Me.Txt_Nombre_Correo.Location = New System.Drawing.Point(94, 1)
        Me.Txt_Nombre_Correo.Name = "Txt_Nombre_Correo"
        Me.Txt_Nombre_Correo.PreventEnterBeep = True
        Me.Txt_Nombre_Correo.Size = New System.Drawing.Size(672, 22)
        Me.Txt_Nombre_Correo.TabIndex = 8
        '
        'GroupPanel2
        '
        Me.GroupPanel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Txt_Nombre_Correo)
        Me.GroupPanel2.Controls.Add(Me.LabelX11)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(772, 30)
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
        Me.GroupPanel2.TabIndex = 9
        '
        'Rdb_Envio_Automatico
        '
        Me.Rdb_Envio_Automatico.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Envio_Automatico.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Envio_Automatico.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Envio_Automatico.Checked = True
        Me.Rdb_Envio_Automatico.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Envio_Automatico.CheckValue = "Y"
        Me.Rdb_Envio_Automatico.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Envio_Automatico.Location = New System.Drawing.Point(144, 3)
        Me.Rdb_Envio_Automatico.Name = "Rdb_Envio_Automatico"
        Me.Rdb_Envio_Automatico.Size = New System.Drawing.Size(119, 19)
        Me.Rdb_Envio_Automatico.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Envio_Automatico.TabIndex = 12
        Me.Rdb_Envio_Automatico.Text = "Envío automático"
        '
        'GroupPanel3
        '
        Me.GroupPanel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupPanel3.BackColor = System.Drawing.Color.White
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.Rdb_Envio_Manual)
        Me.GroupPanel3.Controls.Add(Me.LabelX12)
        Me.GroupPanel3.Controls.Add(Me.Rdb_Envio_Automatico)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Location = New System.Drawing.Point(12, 48)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(772, 30)
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
        Me.GroupPanel3.TabIndex = 14
        '
        'Rdb_Envio_Manual
        '
        Me.Rdb_Envio_Manual.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Envio_Manual.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Envio_Manual.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Envio_Manual.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Envio_Manual.Location = New System.Drawing.Point(269, 3)
        Me.Rdb_Envio_Manual.Name = "Rdb_Envio_Manual"
        Me.Rdb_Envio_Manual.Size = New System.Drawing.Size(119, 19)
        Me.Rdb_Envio_Manual.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Envio_Manual.TabIndex = 13
        Me.Rdb_Envio_Manual.Text = "Envío manual"
        '
        'LabelX12
        '
        Me.LabelX12.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX12.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX12.ForeColor = System.Drawing.Color.Black
        Me.LabelX12.Location = New System.Drawing.Point(6, -1)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(132, 22)
        Me.LabelX12.TabIndex = 7
        Me.LabelX12.Text = "Tipo de envío de correo"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Chk_Firma)
        Me.GroupPanel1.Controls.Add(Me.LabelX9)
        Me.GroupPanel1.Controls.Add(Me.TableLayoutPanel2)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(3, 159)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(772, 136)
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
        Me.GroupPanel1.TabIndex = 15
        Me.GroupPanel1.Text = "Opciones de envío"
        '
        'LabelX9
        '
        Me.LabelX9.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.ForeColor = System.Drawing.Color.Black
        Me.LabelX9.Location = New System.Drawing.Point(3, 3)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(228, 23)
        Me.LabelX9.TabIndex = 21
        Me.LabelX9.Text = "<b>Opciones de envío</b>"
        '
        'SuperTabControl1
        '
        Me.SuperTabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel1)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel3)
        Me.SuperTabControl1.ForeColor = System.Drawing.Color.Black
        Me.SuperTabControl1.Location = New System.Drawing.Point(12, 84)
        Me.SuperTabControl1.Name = "SuperTabControl1"
        Me.SuperTabControl1.ReorderTabsEnabled = True
        Me.SuperTabControl1.SelectedTabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.SuperTabControl1.SelectedTabIndex = 0
        Me.SuperTabControl1.Size = New System.Drawing.Size(780, 481)
        Me.SuperTabControl1.TabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SuperTabControl1.TabIndex = 28
        Me.SuperTabControl1.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabItem3, Me.SuperTabItem1})
        Me.SuperTabControl1.Text = "SuperTabControl1"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.GroupPanel1)
        Me.SuperTabControlPanel1.Controls.Add(Me.Grupo_Info_Sesion)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 27)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(780, 454)
        Me.SuperTabControlPanel1.TabIndex = 1
        Me.SuperTabControlPanel1.TabItem = Me.SuperTabItem1
        '
        'SuperTabItem1
        '
        Me.SuperTabItem1.AttachedControl = Me.SuperTabControlPanel1
        Me.SuperTabItem1.GlobalItem = False
        Me.SuperTabItem1.Name = "SuperTabItem1"
        Me.SuperTabItem1.Text = "Cuenta SMTP - Opciones de envío / Asunto"
        '
        'SuperTabControlPanel3
        '
        Me.SuperTabControlPanel3.Controls.Add(Me.GroupPanel4)
        Me.SuperTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel3.Location = New System.Drawing.Point(0, 27)
        Me.SuperTabControlPanel3.Name = "SuperTabControlPanel3"
        Me.SuperTabControlPanel3.Size = New System.Drawing.Size(780, 454)
        Me.SuperTabControlPanel3.TabIndex = 0
        Me.SuperTabControlPanel3.TabItem = Me.SuperTabItem3
        '
        'SuperTabItem3
        '
        Me.SuperTabItem3.AttachedControl = Me.SuperTabControlPanel3
        Me.SuperTabItem3.GlobalItem = False
        Me.SuperTabItem3.Name = "SuperTabItem3"
        Me.SuperTabItem3.Text = "Cuerpo del mensaje"
        '
        'Frm_Correos_Conf
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(796, 624)
        Me.Controls.Add(Me.SuperTabControl1)
        Me.Controls.Add(Me.GroupPanel3)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButtonText = "HELP"
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(812, 663)
        Me.Name = "Frm_Correos_Conf"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Servidor de correo saliente (SMTP)"
        Me.Grupo_Info_Sesion.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel4.ResumeLayout(False)
        CType(Me.SuperTabControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControl2.ResumeLayout(False)
        Me.SuperTabControlPanel2.ResumeLayout(False)
        Me.ContextMenuStrip2.ResumeLayout(False)
        CType(Me.Pict_Color_Resaltado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pict_Color_Fuente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Input_Size, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel4.ResumeLayout(False)
        Me.GroupPanel2.ResumeLayout(False)
        Me.GroupPanel3.ResumeLayout(False)
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControl1.ResumeLayout(False)
        Me.SuperTabControlPanel1.ResumeLayout(False)
        Me.SuperTabControlPanel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Grupo_Info_Sesion As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Chk_SSL As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Probar_Envio As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Eliminar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Ver_Contrasena As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupPanel4 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Txt_Puerto As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Txt_Contrasena As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Txt_Remitente As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Txt_Host_SMTP As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Txt_Asunto As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Chk_Auto_Asunto As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Txt_Para As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Txt_Cuerpo As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Txt_CC As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Txt_Nombre_Correo As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Chk_Firma As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Public WithEvents Rdb_Envio_Automatico As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Rdb_Envio_Manual As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Chk_Es_Html As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Btn_Probar_GMAIL As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Cuentas As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Vista_Previa As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Rtf_Cuerpo As RichTextBox
    Friend WithEvents LabelX14 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Input_Size As DevComponents.Editors.IntegerInput
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents SuperTabControl1 As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel3 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem3 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem1 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Color_Resaltado As DevComponents.DotNetBar.ColorPickerDropDown
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Color_Fuente As DevComponents.DotNetBar.ColorPickerDropDown
    Friend WithEvents ContextMenuStrip2 As ContextMenuStrip
    Friend WithEvents Mnu_Tex_CortarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Mnu_Tex_CopiarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Mnu_Tex_PegarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Pict_Color_Resaltado As PictureBox
    Friend WithEvents Pict_Color_Fuente As PictureBox
    Friend WithEvents Cmb_Fuente As ComboBox
    Friend WithEvents SCor As ColorDialog
    Friend WithEvents SuperTabControl2 As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel4 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem4 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem2 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents Btn_Subrayada As Button
    Friend WithEvents Btn_Cursiva As Button
    Friend WithEvents Btn_Negrita As Button
    Friend WithEvents Btn_Carpeta_Imagenes As DevComponents.DotNetBar.ButtonItem
End Class
