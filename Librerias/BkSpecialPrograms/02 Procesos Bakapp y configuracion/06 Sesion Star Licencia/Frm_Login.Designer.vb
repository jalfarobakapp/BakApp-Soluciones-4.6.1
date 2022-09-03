<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Login
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Login))
        Me.Txtxusuario = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtxPassword = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.ReflectionLabel2 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.Highlighter1 = New DevComponents.DotNetBar.Validator.Highlighter()
        Me.BtnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.BtnxAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.ReflectionImage1 = New DevComponents.DotNetBar.Controls.ReflectionImage()
        Me.TouchKeyboard1 = New DevComponents.DotNetBar.Keyboard.TouchKeyboard()
        Me.Btn_Teclado = New DevComponents.DotNetBar.ButtonX()
        Me.SuspendLayout()
        '
        'Txtxusuario
        '
        Me.Txtxusuario.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txtxusuario.Border.Class = "TextBoxBorder"
        Me.Txtxusuario.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txtxusuario.DisabledBackColor = System.Drawing.Color.White
        Me.Txtxusuario.ForeColor = System.Drawing.Color.Black
        Me.Txtxusuario.Location = New System.Drawing.Point(154, 44)
        Me.Txtxusuario.Name = "Txtxusuario"
        Me.Txtxusuario.PreventEnterBeep = True
        Me.Txtxusuario.ReadOnly = True
        Me.Txtxusuario.Size = New System.Drawing.Size(194, 22)
        Me.Txtxusuario.TabIndex = 1
        Me.Txtxusuario.TabStop = False
        '
        'TxtxPassword
        '
        Me.TxtxPassword.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtxPassword.Border.Class = "TextBoxBorder"
        Me.TxtxPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtxPassword.DisabledBackColor = System.Drawing.Color.White
        Me.TxtxPassword.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightOnFocus(Me.TxtxPassword, True)
        Me.TxtxPassword.Location = New System.Drawing.Point(154, 114)
        Me.TxtxPassword.Name = "TxtxPassword"
        Me.TxtxPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtxPassword.PreventEnterBeep = True
        Me.TxtxPassword.Size = New System.Drawing.Size(194, 22)
        Me.TxtxPassword.TabIndex = 0
        '
        'ReflectionLabel2
        '
        Me.ReflectionLabel2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.ReflectionLabel2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel2.ForeColor = System.Drawing.Color.Black
        Me.ReflectionLabel2.Location = New System.Drawing.Point(154, 72)
        Me.ReflectionLabel2.Name = "ReflectionLabel2"
        Me.ReflectionLabel2.Size = New System.Drawing.Size(175, 36)
        Me.ReflectionLabel2.TabIndex = 10
        Me.ReflectionLabel2.Text = "<b><font size=""+3"">C<font color=""#0F243E"">ontraseña (Random)</font></font></b>"
        '
        'ReflectionLabel1
        '
        Me.ReflectionLabel1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.ForeColor = System.Drawing.Color.Black
        Me.ReflectionLabel1.Location = New System.Drawing.Point(154, 2)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(175, 36)
        Me.ReflectionLabel1.TabIndex = 9
        Me.ReflectionLabel1.Text = "<b><font size=""+3"">N<font color=""#0F243E"">ombre de usuario</font></font></b>"
        '
        'Highlighter1
        '
        Me.Highlighter1.ContainerControl = Me
        Me.Highlighter1.FocusHighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
        Me.Highlighter1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Highlighter1.SetHighlightOnFocus(Me.BtnCancelar, True)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(259, 151)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(89, 33)
        Me.BtnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnCancelar.TabIndex = 2
        Me.BtnCancelar.TabStop = False
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left
        '
        'BtnxAceptar
        '
        Me.BtnxAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnxAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Highlighter1.SetHighlightOnFocus(Me.BtnxAceptar, True)
        Me.BtnxAceptar.Image = CType(resources.GetObject("BtnxAceptar.Image"), System.Drawing.Image)
        Me.BtnxAceptar.Location = New System.Drawing.Point(154, 151)
        Me.BtnxAceptar.Name = "BtnxAceptar"
        Me.BtnxAceptar.Size = New System.Drawing.Size(80, 33)
        Me.BtnxAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnxAceptar.TabIndex = 1
        Me.BtnxAceptar.Text = "Aceptar"
        Me.BtnxAceptar.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left
        '
        'ReflectionImage1
        '
        Me.ReflectionImage1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.ReflectionImage1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionImage1.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.ReflectionImage1.ForeColor = System.Drawing.Color.Black
        Me.ReflectionImage1.Image = CType(resources.GetObject("ReflectionImage1.Image"), System.Drawing.Image)
        Me.ReflectionImage1.Location = New System.Drawing.Point(12, 2)
        Me.ReflectionImage1.Name = "ReflectionImage1"
        Me.ReflectionImage1.Size = New System.Drawing.Size(128, 181)
        Me.ReflectionImage1.TabIndex = 11
        '
        'TouchKeyboard1
        '
        Me.TouchKeyboard1.FloatingLocation = New System.Drawing.Point(0, 0)
        Me.TouchKeyboard1.FloatingSize = New System.Drawing.Size(740, 250)
        Me.TouchKeyboard1.Location = New System.Drawing.Point(0, 0)
        Me.TouchKeyboard1.Size = New System.Drawing.Size(740, 250)
        Me.TouchKeyboard1.Text = ""
        '
        'Btn_Teclado
        '
        Me.Btn_Teclado.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Teclado.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Teclado.Image = CType(resources.GetObject("Btn_Teclado.Image"), System.Drawing.Image)
        Me.Btn_Teclado.Location = New System.Drawing.Point(12, 148)
        Me.Btn_Teclado.Name = "Btn_Teclado"
        Me.Btn_Teclado.Size = New System.Drawing.Size(46, 35)
        Me.Btn_Teclado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Teclado.TabIndex = 12
        Me.Btn_Teclado.Tooltip = "Ver teclado"
        '
        'Frm_Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(365, 204)
        Me.Controls.Add(Me.Btn_Teclado)
        Me.Controls.Add(Me.ReflectionImage1)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnxAceptar)
        Me.Controls.Add(Me.Txtxusuario)
        Me.Controls.Add(Me.TxtxPassword)
        Me.Controls.Add(Me.ReflectionLabel2)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Txtxusuario As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtxPassword As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ReflectionLabel2 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents BtnxAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Highlighter1 As DevComponents.DotNetBar.Validator.Highlighter
    Friend WithEvents ReflectionImage1 As DevComponents.DotNetBar.Controls.ReflectionImage
    Friend WithEvents TouchKeyboard1 As DevComponents.DotNetBar.Keyboard.TouchKeyboard
    Friend WithEvents Btn_Teclado As DevComponents.DotNetBar.ButtonX
End Class
