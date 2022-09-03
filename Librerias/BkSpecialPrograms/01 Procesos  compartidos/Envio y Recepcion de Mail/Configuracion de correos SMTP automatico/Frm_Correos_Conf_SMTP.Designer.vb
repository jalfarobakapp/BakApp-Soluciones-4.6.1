<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Correos_Conf_SMTP
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Correos_Conf_SMTP))
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Eliminar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Probar_Envio = New DevComponents.DotNetBar.ButtonItem()
        Me.Grupo_Info_Sesion = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Host_SMTP = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Remitente = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Contrasena = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Puerto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.Chk_SSL = New DevComponents.DotNetBar.Controls.CheckBoxX()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_Info_Sesion.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar, Me.Btn_Eliminar, Me.Btn_Probar_Envio})
        Me.Bar1.Location = New System.Drawing.Point(0, 124)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(788, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 5
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
        'Grupo_Info_Sesion
        '
        Me.Grupo_Info_Sesion.BackColor = System.Drawing.Color.White
        Me.Grupo_Info_Sesion.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Info_Sesion.Controls.Add(Me.LabelX5)
        Me.Grupo_Info_Sesion.Controls.Add(Me.TableLayoutPanel1)
        Me.Grupo_Info_Sesion.Controls.Add(Me.LabelX6)
        Me.Grupo_Info_Sesion.Controls.Add(Me.Chk_SSL)
        Me.Grupo_Info_Sesion.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Info_Sesion.Location = New System.Drawing.Point(9, 12)
        Me.Grupo_Info_Sesion.Name = "Grupo_Info_Sesion"
        Me.Grupo_Info_Sesion.Size = New System.Drawing.Size(772, 97)
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
        Me.Grupo_Info_Sesion.TabIndex = 4
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
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 236.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Host_SMTP, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX1, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Remitente, 2, 0)
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
        Me.LabelX2.Size = New System.Drawing.Size(45, 21)
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
        Me.Txt_Host_SMTP.Location = New System.Drawing.Point(532, 3)
        Me.Txt_Host_SMTP.Name = "Txt_Host_SMTP"
        Me.Txt_Host_SMTP.PreventEnterBeep = True
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
        Me.LabelX1.Location = New System.Drawing.Point(333, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(173, 21)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "Servidor de correo saliente (SMTP)"
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
        Me.Txt_Remitente.Location = New System.Drawing.Point(95, 3)
        Me.Txt_Remitente.Name = "Txt_Remitente"
        Me.Txt_Remitente.PreventEnterBeep = True
        Me.Txt_Remitente.Size = New System.Drawing.Size(232, 22)
        Me.Txt_Remitente.TabIndex = 3
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
        Me.LabelX3.Size = New System.Drawing.Size(54, 21)
        Me.LabelX3.TabIndex = 4
        Me.LabelX3.Text = "Contraseña"
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
        Me.Txt_Contrasena.Location = New System.Drawing.Point(95, 30)
        Me.Txt_Contrasena.Name = "Txt_Contrasena"
        Me.Txt_Contrasena.PreventEnterBeep = True
        Me.Txt_Contrasena.Size = New System.Drawing.Size(232, 22)
        Me.Txt_Contrasena.TabIndex = 5
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(333, 30)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(75, 21)
        Me.LabelX4.TabIndex = 6
        Me.LabelX4.Text = "Puerto"
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
        Me.Txt_Puerto.Location = New System.Drawing.Point(532, 30)
        Me.Txt_Puerto.Name = "Txt_Puerto"
        Me.Txt_Puerto.PreventEnterBeep = True
        Me.Txt_Puerto.Size = New System.Drawing.Size(50, 22)
        Me.Txt_Puerto.TabIndex = 7
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
        Me.Chk_SSL.ForeColor = System.Drawing.Color.Black
        Me.Chk_SSL.Location = New System.Drawing.Point(518, 2)
        Me.Chk_SSL.Name = "Chk_SSL"
        Me.Chk_SSL.Size = New System.Drawing.Size(127, 23)
        Me.Chk_SSL.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_SSL.TabIndex = 10
        Me.Chk_SSL.Text = "Conexión cifrada (SSL)"
        '
        'Frm_Correos_Conf_SMTP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(788, 165)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.Grupo_Info_Sesion)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Correos_Conf_SMTP"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CORREO SMTP"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo_Info_Sesion.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Eliminar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Probar_Envio As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grupo_Info_Sesion As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Host_SMTP As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Remitente As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Contrasena As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Puerto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Chk_SSL As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
