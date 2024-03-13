<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ValidarPermiso
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ValidarPermiso))
        Me.Txtclave = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.Highlighter1 = New DevComponents.DotNetBar.Validator.Highlighter()
        Me.TouchKeyboard1 = New DevComponents.DotNetBar.Keyboard.TouchKeyboard()
        Me.Btn_Teclado = New DevComponents.DotNetBar.ButtonX()
        Me.Tiempo_Label = New System.Windows.Forms.Timer(Me.components)
        Me.Btn_Validar_Con_Huella = New DevComponents.DotNetBar.ButtonX()
        Me.Tiempo_Huella = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'Txtclave
        '
        Me.Txtclave.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txtclave.Border.Class = "TextBoxBorder"
        Me.Txtclave.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txtclave.DisabledBackColor = System.Drawing.Color.White
        Me.Txtclave.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtclave.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightColor(Me.Txtclave, DevComponents.DotNetBar.Validator.eHighlightColor.Red)
        Me.Highlighter1.SetHighlightOnFocus(Me.Txtclave, True)
        Me.Txtclave.Location = New System.Drawing.Point(6, 27)
        Me.Txtclave.Name = "Txtclave"
        Me.Txtclave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Txtclave.PreventEnterBeep = True
        Me.Txtclave.Size = New System.Drawing.Size(129, 35)
        Me.Txtclave.TabIndex = 0
        Me.Txtclave.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Txtclave.WatermarkColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Txtclave.WatermarkText = "Ing. Clave..."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(3, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(131, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Ingrese clave de usuario"
        '
        'BtnAceptar
        '
        Me.BtnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnAceptar.Image = CType(resources.GetObject("BtnAceptar.Image"), System.Drawing.Image)
        Me.BtnAceptar.ImageAlt = CType(resources.GetObject("BtnAceptar.ImageAlt"), System.Drawing.Image)
        Me.BtnAceptar.Location = New System.Drawing.Point(141, 27)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(85, 35)
        Me.BtnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnAceptar.TabIndex = 2
        Me.BtnAceptar.Text = "Aceptar"
        '
        'Highlighter1
        '
        Me.Highlighter1.ContainerControl = Me
        Me.Highlighter1.FocusHighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
        Me.Highlighter1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
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
        Me.Btn_Teclado.Location = New System.Drawing.Point(232, 27)
        Me.Btn_Teclado.Name = "Btn_Teclado"
        Me.Btn_Teclado.Size = New System.Drawing.Size(46, 35)
        Me.Btn_Teclado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Teclado.TabIndex = 3
        Me.Btn_Teclado.Tooltip = "Ver teclado"
        '
        'Tiempo_Label
        '
        Me.Tiempo_Label.Interval = 20000
        '
        'Btn_Validar_Con_Huella
        '
        Me.Btn_Validar_Con_Huella.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Validar_Con_Huella.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Validar_Con_Huella.Image = CType(resources.GetObject("Btn_Validar_Con_Huella.Image"), System.Drawing.Image)
        Me.Btn_Validar_Con_Huella.ImageAlt = CType(resources.GetObject("Btn_Validar_Con_Huella.ImageAlt"), System.Drawing.Image)
        Me.Btn_Validar_Con_Huella.Location = New System.Drawing.Point(284, 27)
        Me.Btn_Validar_Con_Huella.Name = "Btn_Validar_Con_Huella"
        Me.Btn_Validar_Con_Huella.Size = New System.Drawing.Size(46, 35)
        Me.Btn_Validar_Con_Huella.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Validar_Con_Huella.TabIndex = 4
        Me.Btn_Validar_Con_Huella.Tooltip = "Ver teclado"
        '
        'Tiempo_Huella
        '
        Me.Tiempo_Huella.Interval = 1000
        '
        'Frm_ValidarPermiso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(332, 70)
        Me.Controls.Add(Me.Btn_Validar_Con_Huella)
        Me.Controls.Add(Me.Btn_Teclado)
        Me.Controls.Add(Me.BtnAceptar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Txtclave)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_ValidarPermiso"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Verificar permiso..."
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Txtclave As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Highlighter1 As DevComponents.DotNetBar.Validator.Highlighter
    Friend WithEvents Btn_Teclado As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TouchKeyboard1 As DevComponents.DotNetBar.Keyboard.TouchKeyboard
    Friend WithEvents Tiempo_Label As Timer
    Friend WithEvents Btn_Validar_Con_Huella As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Tiempo_Huella As Timer
End Class
