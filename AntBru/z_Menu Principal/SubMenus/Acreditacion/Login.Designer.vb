<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Me.ReflectionImage1 = New DevComponents.DotNetBar.Controls.ReflectionImage()
        Me.Txt_Pass = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Reflex_Contrasena = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.Reflex_Nombre_Usuario = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.Lbl_Usuario = New DevComponents.DotNetBar.LabelX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Ok = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Teclado = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Autenticar_Huella = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Cancelar = New DevComponents.DotNetBar.ButtonItem()
        Me.Lbl_Version = New DevComponents.DotNetBar.LabelX()
        Me.TouchKeyboard1 = New DevComponents.DotNetBar.Keyboard.TouchKeyboard()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReflectionImage1
        '
        '
        '
        '
        Me.ReflectionImage1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionImage1.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.ReflectionImage1.Image = CType(resources.GetObject("ReflectionImage1.Image"), System.Drawing.Image)
        Me.ReflectionImage1.Location = New System.Drawing.Point(12, 43)
        Me.ReflectionImage1.Name = "ReflectionImage1"
        Me.ReflectionImage1.Size = New System.Drawing.Size(101, 119)
        Me.ReflectionImage1.TabIndex = 19
        '
        'Txt_Pass
        '
        Me.Txt_Pass.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Pass.Border.Class = "TextBoxBorder"
        Me.Txt_Pass.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Pass.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Pass.ForeColor = System.Drawing.Color.Black
        Me.Txt_Pass.Location = New System.Drawing.Point(119, 146)
        Me.Txt_Pass.Name = "Txt_Pass"
        Me.Txt_Pass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Txt_Pass.PreventEnterBeep = True
        Me.Txt_Pass.Size = New System.Drawing.Size(217, 20)
        Me.Txt_Pass.TabIndex = 13
        '
        'Reflex_Contrasena
        '
        Me.Reflex_Contrasena.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.Reflex_Contrasena.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Reflex_Contrasena.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Reflex_Contrasena.ForeColor = System.Drawing.Color.Black
        Me.Reflex_Contrasena.Location = New System.Drawing.Point(119, 104)
        Me.Reflex_Contrasena.Name = "Reflex_Contrasena"
        Me.Reflex_Contrasena.Size = New System.Drawing.Size(217, 36)
        Me.Reflex_Contrasena.TabIndex = 18
        Me.Reflex_Contrasena.Text = "<font size=""+6"" color=""#474747"">Contraseña (Random)</font><font color=""#3F3F3F""><" &
    "/font>"
        '
        'Reflex_Nombre_Usuario
        '
        Me.Reflex_Nombre_Usuario.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.Reflex_Nombre_Usuario.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Reflex_Nombre_Usuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Reflex_Nombre_Usuario.ForeColor = System.Drawing.Color.Black
        Me.Reflex_Nombre_Usuario.Location = New System.Drawing.Point(119, 32)
        Me.Reflex_Nombre_Usuario.Name = "Reflex_Nombre_Usuario"
        Me.Reflex_Nombre_Usuario.Size = New System.Drawing.Size(175, 37)
        Me.Reflex_Nombre_Usuario.TabIndex = 17
        Me.Reflex_Nombre_Usuario.Text = "<font size=""+6"" color=""#474747"">Nombre usuario</font><font color=""#3F3F3F""></font" &
    ">"
        '
        'Lbl_Usuario
        '
        Me.Lbl_Usuario.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.Lbl_Usuario.BackgroundStyle.Class = "RibbonGalleryContainer"
        Me.Lbl_Usuario.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Usuario.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Usuario.Location = New System.Drawing.Point(119, 75)
        Me.Lbl_Usuario.Name = "Lbl_Usuario"
        Me.Lbl_Usuario.Size = New System.Drawing.Size(217, 23)
        Me.Lbl_Usuario.TabIndex = 82
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Ok, Me.Btn_Teclado, Me.Btn_Autenticar_Huella, Me.Btn_Cancelar})
        Me.Bar1.Location = New System.Drawing.Point(0, 185)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(343, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 83
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Ok
        '
        Me.Btn_Ok.ForeColor = System.Drawing.Color.Black
        Me.Btn_Ok.Image = CType(resources.GetObject("Btn_Ok.Image"), System.Drawing.Image)
        Me.Btn_Ok.ImageAlt = CType(resources.GetObject("Btn_Ok.ImageAlt"), System.Drawing.Image)
        Me.Btn_Ok.Name = "Btn_Ok"
        Me.Btn_Ok.Text = "Aceptar"
        '
        'Btn_Teclado
        '
        Me.Btn_Teclado.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Teclado.ForeColor = System.Drawing.Color.Black
        Me.Btn_Teclado.Image = CType(resources.GetObject("Btn_Teclado.Image"), System.Drawing.Image)
        Me.Btn_Teclado.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Teclado.Name = "Btn_Teclado"
        '
        'Btn_Autenticar_Huella
        '
        Me.Btn_Autenticar_Huella.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Autenticar_Huella.ForeColor = System.Drawing.Color.Black
        Me.Btn_Autenticar_Huella.Image = CType(resources.GetObject("Btn_Autenticar_Huella.Image"), System.Drawing.Image)
        Me.Btn_Autenticar_Huella.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Autenticar_Huella.Name = "Btn_Autenticar_Huella"
        Me.Btn_Autenticar_Huella.Tooltip = "Autentificar con huella"
        Me.Btn_Autenticar_Huella.Visible = False
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Cancelar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Btn_Cancelar.Image = CType(resources.GetObject("Btn_Cancelar.Image"), System.Drawing.Image)
        Me.Btn_Cancelar.ImageAlt = CType(resources.GetObject("Btn_Cancelar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Cancelar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Cancelar.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Tooltip = "Cancelar"
        '
        'Lbl_Version
        '
        '
        '
        '
        Me.Lbl_Version.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Version.Location = New System.Drawing.Point(12, 3)
        Me.Lbl_Version.Name = "Lbl_Version"
        Me.Lbl_Version.Size = New System.Drawing.Size(268, 23)
        Me.Lbl_Version.TabIndex = 84
        Me.Lbl_Version.Text = "LabelX1"
        '
        'TouchKeyboard1
        '
        Me.TouchKeyboard1.FloatingLocation = New System.Drawing.Point(0, 0)
        Me.TouchKeyboard1.FloatingSize = New System.Drawing.Size(740, 250)
        Me.TouchKeyboard1.Location = New System.Drawing.Point(0, 0)
        Me.TouchKeyboard1.Size = New System.Drawing.Size(740, 250)
        Me.TouchKeyboard1.Text = ""
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Lbl_Version)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.Lbl_Usuario)
        Me.Controls.Add(Me.ReflectionImage1)
        Me.Controls.Add(Me.Txt_Pass)
        Me.Controls.Add(Me.Reflex_Contrasena)
        Me.Controls.Add(Me.Reflex_Nombre_Usuario)
        Me.Name = "Login"
        Me.Size = New System.Drawing.Size(343, 226)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReflectionImage1 As DevComponents.DotNetBar.Controls.ReflectionImage
    Friend WithEvents Txt_Pass As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Reflex_Contrasena As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents Reflex_Nombre_Usuario As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents Lbl_Usuario As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Cancelar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Teclado As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Lbl_Version As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Ok As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents TouchKeyboard1 As DevComponents.DotNetBar.Keyboard.TouchKeyboard
    Friend WithEvents Btn_Autenticar_Huella As DevComponents.DotNetBar.ButtonItem
End Class
