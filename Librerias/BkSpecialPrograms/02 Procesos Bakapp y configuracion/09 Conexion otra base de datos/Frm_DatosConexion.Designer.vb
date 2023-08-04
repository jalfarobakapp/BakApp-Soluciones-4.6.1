<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_DatosConexion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_DatosConexion))
        Me.TouchKeyboard1 = New DevComponents.DotNetBar.Keyboard.TouchKeyboard()
        Me.Txt_BaseDeDatos = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Txt_Clave = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Txt_Usuario = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Conectar = New DevComponents.DotNetBar.ButtonItem()
        Me.Txt_Puerto = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Txt_Servidor = New System.Windows.Forms.TextBox()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Txt_Nombre_Conexion = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Txt_Empresa = New System.Windows.Forms.TextBox()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TouchKeyboard1
        '
        Me.TouchKeyboard1.FloatingLocation = New System.Drawing.Point(0, 0)
        Me.TouchKeyboard1.FloatingSize = New System.Drawing.Size(740, 250)
        Me.TouchKeyboard1.Location = New System.Drawing.Point(0, 0)
        Me.TouchKeyboard1.Size = New System.Drawing.Size(740, 250)
        Me.TouchKeyboard1.Text = ""
        '
        'Txt_BaseDeDatos
        '
        Me.Txt_BaseDeDatos.BackColor = System.Drawing.Color.White
        Me.Txt_BaseDeDatos.ForeColor = System.Drawing.Color.Black
        Me.Txt_BaseDeDatos.Location = New System.Drawing.Point(126, 124)
        Me.Txt_BaseDeDatos.Name = "Txt_BaseDeDatos"
        Me.Txt_BaseDeDatos.Size = New System.Drawing.Size(207, 22)
        Me.Txt_BaseDeDatos.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(15, 127)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Base de datos"
        '
        'Txt_Clave
        '
        Me.Txt_Clave.BackColor = System.Drawing.Color.White
        Me.Txt_Clave.ForeColor = System.Drawing.Color.Black
        Me.Txt_Clave.Location = New System.Drawing.Point(126, 96)
        Me.Txt_Clave.Name = "Txt_Clave"
        Me.Txt_Clave.Size = New System.Drawing.Size(207, 22)
        Me.Txt_Clave.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(15, 99)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Clave"
        '
        'Txt_Usuario
        '
        Me.Txt_Usuario.BackColor = System.Drawing.Color.White
        Me.Txt_Usuario.ForeColor = System.Drawing.Color.Black
        Me.Txt_Usuario.Location = New System.Drawing.Point(126, 69)
        Me.Txt_Usuario.Name = "Txt_Usuario"
        Me.Txt_Usuario.Size = New System.Drawing.Size(207, 22)
        Me.Txt_Usuario.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(15, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Usuario"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Text = "Grabar"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Conectar, Me.Btn_Grabar})
        Me.Bar1.Location = New System.Drawing.Point(0, 306)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(368, 57)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 87
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Conectar
        '
        Me.Btn_Conectar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Conectar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Conectar.Image = CType(resources.GetObject("Btn_Conectar.Image"), System.Drawing.Image)
        Me.Btn_Conectar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Conectar.Name = "Btn_Conectar"
        Me.Btn_Conectar.Text = "Probar conexión"
        '
        'Txt_Puerto
        '
        Me.Txt_Puerto.BackColor = System.Drawing.Color.White
        Me.Txt_Puerto.ForeColor = System.Drawing.Color.Black
        Me.Txt_Puerto.Location = New System.Drawing.Point(126, 41)
        Me.Txt_Puerto.Name = "Txt_Puerto"
        Me.Txt_Puerto.Size = New System.Drawing.Size(207, 22)
        Me.Txt_Puerto.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(15, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Puerto"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(15, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Servidor"
        '
        'Txt_Servidor
        '
        Me.Txt_Servidor.BackColor = System.Drawing.Color.White
        Me.Txt_Servidor.ForeColor = System.Drawing.Color.Black
        Me.Txt_Servidor.Location = New System.Drawing.Point(126, 12)
        Me.Txt_Servidor.Name = "Txt_Servidor"
        Me.Txt_Servidor.Size = New System.Drawing.Size(207, 22)
        Me.Txt_Servidor.TabIndex = 1
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Txt_BaseDeDatos)
        Me.GroupPanel1.Controls.Add(Me.Label1)
        Me.GroupPanel1.Controls.Add(Me.Label5)
        Me.GroupPanel1.Controls.Add(Me.Txt_Servidor)
        Me.GroupPanel1.Controls.Add(Me.Txt_Clave)
        Me.GroupPanel1.Controls.Add(Me.Label2)
        Me.GroupPanel1.Controls.Add(Me.Label4)
        Me.GroupPanel1.Controls.Add(Me.Txt_Puerto)
        Me.GroupPanel1.Controls.Add(Me.Txt_Usuario)
        Me.GroupPanel1.Controls.Add(Me.Label3)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 53)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(348, 177)
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
        Me.GroupPanel1.TabIndex = 88
        Me.GroupPanel1.Text = "Datos de conexión SQL"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(12, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 13)
        Me.Label6.TabIndex = 90
        Me.Label6.Text = "Nombre"
        '
        'Txt_Nombre_Conexion
        '
        Me.Txt_Nombre_Conexion.BackColor = System.Drawing.Color.White
        Me.Txt_Nombre_Conexion.ForeColor = System.Drawing.Color.Black
        Me.Txt_Nombre_Conexion.Location = New System.Drawing.Point(67, 15)
        Me.Txt_Nombre_Conexion.Name = "Txt_Nombre_Conexion"
        Me.Txt_Nombre_Conexion.Size = New System.Drawing.Size(293, 22)
        Me.Txt_Nombre_Conexion.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(21, 248)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 13)
        Me.Label7.TabIndex = 91
        Me.Label7.Text = "Empresa"
        '
        'Txt_Empresa
        '
        Me.Txt_Empresa.BackColor = System.Drawing.Color.White
        Me.Txt_Empresa.ForeColor = System.Drawing.Color.Black
        Me.Txt_Empresa.Location = New System.Drawing.Point(141, 245)
        Me.Txt_Empresa.Name = "Txt_Empresa"
        Me.Txt_Empresa.ReadOnly = True
        Me.Txt_Empresa.Size = New System.Drawing.Size(60, 22)
        Me.Txt_Empresa.TabIndex = 92
        '
        'Frm_DatosConexion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(368, 363)
        Me.Controls.Add(Me.Txt_Empresa)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Txt_Nombre_Conexion)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_DatosConexion"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Conexión base de datos"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TouchKeyboard1 As DevComponents.DotNetBar.Keyboard.TouchKeyboard
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Conectar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Txt_BaseDeDatos As TextBox
    Public WithEvents Txt_Clave As TextBox
    Public WithEvents Txt_Usuario As TextBox
    Public WithEvents Txt_Puerto As TextBox
    Public WithEvents Txt_Servidor As TextBox
    Friend WithEvents Label6 As Label
    Public WithEvents Txt_Nombre_Conexion As TextBox
    Friend WithEvents Label7 As Label
    Public WithEvents Txt_Empresa As TextBox
End Class
