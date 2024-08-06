<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ConfFtpProduc
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ConfFtpProduc))
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_ProbConexion = New DevComponents.DotNetBar.ButtonItem()
        Me.Grupo_Configuracion_Ftp = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
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
        Me.Txt_Directorio_Seleccionado = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_Configuracion_Ftp.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar, Me.Btn_ProbConexion})
        Me.Bar1.Location = New System.Drawing.Point(0, 142)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(638, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 118
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_ProbConexion
        '
        Me.Btn_ProbConexion.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_ProbConexion.ForeColor = System.Drawing.Color.Black
        Me.Btn_ProbConexion.Image = CType(resources.GetObject("Btn_ProbConexion.Image"), System.Drawing.Image)
        Me.Btn_ProbConexion.ImageAlt = CType(resources.GetObject("Btn_ProbConexion.ImageAlt"), System.Drawing.Image)
        Me.Btn_ProbConexion.Name = "Btn_ProbConexion"
        Me.Btn_ProbConexion.Text = "Probar conexión"
        '
        'Grupo_Configuracion_Ftp
        '
        Me.Grupo_Configuracion_Ftp.BackColor = System.Drawing.Color.White
        Me.Grupo_Configuracion_Ftp.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Configuracion_Ftp.Controls.Add(Me.LabelX5)
        Me.Grupo_Configuracion_Ftp.Controls.Add(Me.TableLayoutPanel1)
        Me.Grupo_Configuracion_Ftp.Controls.Add(Me.Txt_Directorio_Seleccionado)
        Me.Grupo_Configuracion_Ftp.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Configuracion_Ftp.Location = New System.Drawing.Point(12, 3)
        Me.Grupo_Configuracion_Ftp.Name = "Grupo_Configuracion_Ftp"
        Me.Grupo_Configuracion_Ftp.Size = New System.Drawing.Size(617, 125)
        '
        '
        '
        Me.Grupo_Configuracion_Ftp.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Configuracion_Ftp.Style.BackColorGradientAngle = 90
        Me.Grupo_Configuracion_Ftp.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Configuracion_Ftp.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Configuracion_Ftp.Style.BorderBottomWidth = 1
        Me.Grupo_Configuracion_Ftp.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Configuracion_Ftp.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Configuracion_Ftp.Style.BorderLeftWidth = 1
        Me.Grupo_Configuracion_Ftp.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Configuracion_Ftp.Style.BorderRightWidth = 1
        Me.Grupo_Configuracion_Ftp.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Configuracion_Ftp.Style.BorderTopWidth = 1
        Me.Grupo_Configuracion_Ftp.Style.CornerDiameter = 4
        Me.Grupo_Configuracion_Ftp.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Configuracion_Ftp.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Configuracion_Ftp.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Configuracion_Ftp.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Configuracion_Ftp.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Configuracion_Ftp.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Configuracion_Ftp.TabIndex = 119
        Me.Grupo_Configuracion_Ftp.Text = "<b>Ruta archivos adjunto para el negocio FTP</b>"
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(3, 77)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(39, 21)
        Me.LabelX5.TabIndex = 53
        Me.LabelX5.Text = "Fichero"
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
        Me.Txt_Directorio_Seleccionado.Location = New System.Drawing.Point(48, 77)
        Me.Txt_Directorio_Seleccionado.Name = "Txt_Directorio_Seleccionado"
        Me.Txt_Directorio_Seleccionado.PreventEnterBeep = True
        Me.Txt_Directorio_Seleccionado.ReadOnly = True
        Me.Txt_Directorio_Seleccionado.Size = New System.Drawing.Size(558, 22)
        Me.Txt_Directorio_Seleccionado.TabIndex = 1
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.FontBold = True
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Navy
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.ImageAlt = CType(resources.GetObject("Btn_Grabar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Grabar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Grabar.Name = "Btn_Grabar"
        '
        'Frm_ConfFtpProduc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(638, 183)
        Me.Controls.Add(Me.Grupo_Configuracion_Ftp)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_ConfFtpProduc"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configurqación de conexión FTP para imagenes de productos"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo_Configuracion_Ftp.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Public WithEvents Btn_ProbConexion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grupo_Configuracion_Ftp As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Ftp_Host As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Ftp_Usuario As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Btn_Ver_Contrasena As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Ftp_Contrasena As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Ftp_Puerto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Directorio_Seleccionado As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
End Class
