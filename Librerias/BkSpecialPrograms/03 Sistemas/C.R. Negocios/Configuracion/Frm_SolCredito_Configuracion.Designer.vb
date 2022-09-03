<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_SolCredito_Configuracion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_SolCredito_Configuracion))
        Me.Btn_Conectar_FTP = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_Directorio_Seleccionado = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Correo_SMTP = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnCancelar = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Ftp_Host = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Ftp_Usuario = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Btn_Ver_Contrasena = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Ftp_Contrasena = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Ftp_Puerto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Cmb_Correo_Al_Grabar = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.GroupPanel4 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Cmb_Correo_Al_Cerrar = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupPanel3.SuspendLayout()
        Me.GroupPanel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Btn_Conectar_FTP
        '
        Me.Btn_Conectar_FTP.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Conectar_FTP.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Conectar_FTP.Image = CType(resources.GetObject("Btn_Conectar_FTP.Image"), System.Drawing.Image)
        Me.Btn_Conectar_FTP.Location = New System.Drawing.Point(3, 79)
        Me.Btn_Conectar_FTP.Name = "Btn_Conectar_FTP"
        Me.Btn_Conectar_FTP.Size = New System.Drawing.Size(117, 23)
        Me.Btn_Conectar_FTP.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Conectar_FTP.TabIndex = 51
        Me.Btn_Conectar_FTP.Text = "Conectar con FTP"
        '
        'Txt_Directorio_Seleccionado
        '
        Me.Txt_Directorio_Seleccionado.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Directorio_Seleccionado.Border.Class = "TextBoxBorder"
        Me.Txt_Directorio_Seleccionado.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Directorio_Seleccionado.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Directorio_Seleccionado.ForeColor = System.Drawing.Color.Black
        Me.Txt_Directorio_Seleccionado.Location = New System.Drawing.Point(3, 108)
        Me.Txt_Directorio_Seleccionado.Name = "Txt_Directorio_Seleccionado"
        Me.Txt_Directorio_Seleccionado.PreventEnterBeep = True
        Me.Txt_Directorio_Seleccionado.ReadOnly = True
        Me.Txt_Directorio_Seleccionado.Size = New System.Drawing.Size(603, 22)
        Me.Txt_Directorio_Seleccionado.TabIndex = 1
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar, Me.Btn_Correo_SMTP, Me.BtnCancelar})
        Me.Bar1.Location = New System.Drawing.Point(0, 318)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(621, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 112
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Tooltip = "Grabar"
        '
        'Btn_Correo_SMTP
        '
        Me.Btn_Correo_SMTP.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Correo_SMTP.ForeColor = System.Drawing.Color.Black
        Me.Btn_Correo_SMTP.Image = CType(resources.GetObject("Btn_Correo_SMTP.Image"), System.Drawing.Image)
        Me.Btn_Correo_SMTP.Name = "Btn_Correo_SMTP"
        Me.Btn_Correo_SMTP.Tooltip = "Grabar"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnCancelar.ForeColor = System.Drawing.Color.Black
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Tooltip = "Cancelar"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupPanel1.Controls.Add(Me.Btn_Conectar_FTP)
        Me.GroupPanel1.Controls.Add(Me.Txt_Directorio_Seleccionado)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(0, 12)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(617, 154)
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
        Me.GroupPanel1.TabIndex = 114
        Me.GroupPanel1.Text = "<b>Ruta archivos adjunto para el negocio FTP</b>"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Ftp_Host, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX1, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Ftp_Usuario, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Btn_Ver_Contrasena, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX3, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Ftp_Contrasena, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX4, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Ftp_Puerto, 4, 1)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 17)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(611, 54)
        Me.TableLayoutPanel1.TabIndex = 52
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
        Me.LabelX2.Size = New System.Drawing.Size(55, 21)
        Me.LabelX2.TabIndex = 2
        Me.LabelX2.Text = "Usuario"
        '
        'Txt_Ftp_Host
        '
        Me.Txt_Ftp_Host.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Ftp_Host.Border.Class = "TextBoxBorder"
        Me.Txt_Ftp_Host.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Ftp_Host.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Ftp_Host.ForeColor = System.Drawing.Color.Black
        Me.Txt_Ftp_Host.Location = New System.Drawing.Point(360, 3)
        Me.Txt_Ftp_Host.Name = "Txt_Ftp_Host"
        Me.Txt_Ftp_Host.PreventEnterBeep = True
        Me.Txt_Ftp_Host.Size = New System.Drawing.Size(243, 22)
        Me.Txt_Ftp_Host.TabIndex = 1
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(315, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(39, 21)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "Host"
        '
        'Txt_Ftp_Usuario
        '
        Me.Txt_Ftp_Usuario.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Ftp_Usuario.Border.Class = "TextBoxBorder"
        Me.Txt_Ftp_Usuario.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Ftp_Usuario.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Ftp_Usuario.ForeColor = System.Drawing.Color.Black
        Me.Txt_Ftp_Usuario.Location = New System.Drawing.Point(87, 3)
        Me.Txt_Ftp_Usuario.Name = "Txt_Ftp_Usuario"
        Me.Txt_Ftp_Usuario.PreventEnterBeep = True
        Me.Txt_Ftp_Usuario.Size = New System.Drawing.Size(222, 22)
        Me.Txt_Ftp_Usuario.TabIndex = 3
        '
        'Btn_Ver_Contrasena
        '
        Me.Btn_Ver_Contrasena.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText
        Me.Btn_Ver_Contrasena.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Ver_Contrasena.Image = CType(resources.GetObject("Btn_Ver_Contrasena.Image"), System.Drawing.Image)
        Me.Btn_Ver_Contrasena.Location = New System.Drawing.Point(64, 30)
        Me.Btn_Ver_Contrasena.Name = "Btn_Ver_Contrasena"
        Me.Btn_Ver_Contrasena.Size = New System.Drawing.Size(17, 21)
        Me.Btn_Ver_Contrasena.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Ver_Contrasena.TabIndex = 14
        Me.Btn_Ver_Contrasena.Tooltip = "Ver contraseña"
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
        Me.LabelX3.Size = New System.Drawing.Size(55, 21)
        Me.LabelX3.TabIndex = 4
        Me.LabelX3.Text = "Contraseña"
        '
        'Txt_Ftp_Contrasena
        '
        Me.Txt_Ftp_Contrasena.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Ftp_Contrasena.Border.Class = "TextBoxBorder"
        Me.Txt_Ftp_Contrasena.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Ftp_Contrasena.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Ftp_Contrasena.ForeColor = System.Drawing.Color.Black
        Me.Txt_Ftp_Contrasena.Location = New System.Drawing.Point(87, 30)
        Me.Txt_Ftp_Contrasena.Name = "Txt_Ftp_Contrasena"
        Me.Txt_Ftp_Contrasena.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Txt_Ftp_Contrasena.PreventEnterBeep = True
        Me.Txt_Ftp_Contrasena.Size = New System.Drawing.Size(222, 22)
        Me.Txt_Ftp_Contrasena.TabIndex = 5
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(315, 30)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(39, 21)
        Me.LabelX4.TabIndex = 6
        Me.LabelX4.Text = "Puerto"
        '
        'Txt_Ftp_Puerto
        '
        Me.Txt_Ftp_Puerto.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Ftp_Puerto.Border.Class = "TextBoxBorder"
        Me.Txt_Ftp_Puerto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Ftp_Puerto.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Ftp_Puerto.ForeColor = System.Drawing.Color.Black
        Me.Txt_Ftp_Puerto.Location = New System.Drawing.Point(360, 30)
        Me.Txt_Ftp_Puerto.Name = "Txt_Ftp_Puerto"
        Me.Txt_Ftp_Puerto.PreventEnterBeep = True
        Me.Txt_Ftp_Puerto.Size = New System.Drawing.Size(50, 22)
        Me.Txt_Ftp_Puerto.TabIndex = 7
        '
        'GroupPanel3
        '
        Me.GroupPanel3.BackColor = System.Drawing.Color.White
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.Cmb_Correo_Al_Grabar)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Location = New System.Drawing.Point(0, 172)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(617, 62)
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
        Me.GroupPanel3.TabIndex = 116
        Me.GroupPanel3.Text = "<b>Correo automatico al grabar</b>"
        '
        'Cmb_Correo_Al_Grabar
        '
        Me.Cmb_Correo_Al_Grabar.DisplayMember = "Text"
        Me.Cmb_Correo_Al_Grabar.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Correo_Al_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Correo_Al_Grabar.FormattingEnabled = True
        Me.Cmb_Correo_Al_Grabar.ItemHeight = 16
        Me.Cmb_Correo_Al_Grabar.Location = New System.Drawing.Point(3, 14)
        Me.Cmb_Correo_Al_Grabar.Name = "Cmb_Correo_Al_Grabar"
        Me.Cmb_Correo_Al_Grabar.Size = New System.Drawing.Size(603, 22)
        Me.Cmb_Correo_Al_Grabar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Correo_Al_Grabar.TabIndex = 53
        '
        'GroupPanel4
        '
        Me.GroupPanel4.BackColor = System.Drawing.Color.White
        Me.GroupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel4.Controls.Add(Me.Cmb_Correo_Al_Cerrar)
        Me.GroupPanel4.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel4.Location = New System.Drawing.Point(0, 240)
        Me.GroupPanel4.Name = "GroupPanel4"
        Me.GroupPanel4.Size = New System.Drawing.Size(617, 62)
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
        Me.GroupPanel4.TabIndex = 117
        Me.GroupPanel4.Text = "<b>Correo automatico al cerrar </b>"
        '
        'Cmb_Correo_Al_Cerrar
        '
        Me.Cmb_Correo_Al_Cerrar.DisplayMember = "Text"
        Me.Cmb_Correo_Al_Cerrar.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Correo_Al_Cerrar.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Correo_Al_Cerrar.FormattingEnabled = True
        Me.Cmb_Correo_Al_Cerrar.ItemHeight = 16
        Me.Cmb_Correo_Al_Cerrar.Location = New System.Drawing.Point(3, 14)
        Me.Cmb_Correo_Al_Cerrar.Name = "Cmb_Correo_Al_Cerrar"
        Me.Cmb_Correo_Al_Cerrar.Size = New System.Drawing.Size(603, 22)
        Me.Cmb_Correo_Al_Cerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Correo_Al_Cerrar.TabIndex = 53
        '
        'Frm_SolCredito_Configuracion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(621, 359)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupPanel4)
        Me.Controls.Add(Me.GroupPanel3)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "Frm_SolCredito_Configuracion"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuración local"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupPanel3.ResumeLayout(False)
        Me.GroupPanel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Btn_Conectar_FTP As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Txt_Directorio_Seleccionado As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnCancelar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Btn_Correo_SMTP As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Cmb_Correo_Al_Grabar As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents GroupPanel4 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Cmb_Correo_Al_Cerrar As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Ftp_Host As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Ftp_Usuario As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Btn_Ver_Contrasena As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Ftp_Contrasena As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Ftp_Puerto As DevComponents.DotNetBar.Controls.TextBoxX
End Class
