<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Clave_Administrador
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Clave_Administrador))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Lbl_Usuario = New DevComponents.DotNetBar.LabelX()
        Me.Grupocambiapass = New System.Windows.Forms.GroupBox()
        Me.Btn_Ver_Clave_02 = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Ver_Clave_01 = New DevComponents.DotNetBar.ButtonX()
        Me.Txtpass2 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Txtpass1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.UsernameLabel = New System.Windows.Forms.Label()
        Me.Txt_Password = New System.Windows.Forms.TextBox()
        Me.PasswordLabel = New System.Windows.Forms.Label()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Aceptar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Cancelar = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupBox1.SuspendLayout()
        Me.Grupocambiapass.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Lbl_Usuario)
        Me.GroupBox1.Controls.Add(Me.Grupocambiapass)
        Me.GroupBox1.Controls.Add(Me.UsernameLabel)
        Me.GroupBox1.Controls.Add(Me.Txt_Password)
        Me.GroupBox1.Controls.Add(Me.PasswordLabel)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(250, 255)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'Lbl_Usuario
        '
        Me.Lbl_Usuario.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.Lbl_Usuario.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Lbl_Usuario.BackgroundStyle.Class = "RibbonGalleryContainer"
        Me.Lbl_Usuario.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Usuario.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Usuario.Location = New System.Drawing.Point(8, 42)
        Me.Lbl_Usuario.Name = "Lbl_Usuario"
        Me.Lbl_Usuario.Size = New System.Drawing.Size(226, 21)
        Me.Lbl_Usuario.TabIndex = 83
        '
        'Grupocambiapass
        '
        Me.Grupocambiapass.Controls.Add(Me.Btn_Ver_Clave_02)
        Me.Grupocambiapass.Controls.Add(Me.Btn_Ver_Clave_01)
        Me.Grupocambiapass.Controls.Add(Me.Txtpass2)
        Me.Grupocambiapass.Controls.Add(Me.Label2)
        Me.Grupocambiapass.Controls.Add(Me.Txtpass1)
        Me.Grupocambiapass.Controls.Add(Me.Label1)
        Me.Grupocambiapass.Enabled = False
        Me.Grupocambiapass.Location = New System.Drawing.Point(8, 118)
        Me.Grupocambiapass.Name = "Grupocambiapass"
        Me.Grupocambiapass.Size = New System.Drawing.Size(236, 130)
        Me.Grupocambiapass.TabIndex = 9
        Me.Grupocambiapass.TabStop = False
        Me.Grupocambiapass.Text = "Datos nueva clave"
        '
        'Btn_Ver_Clave_02
        '
        Me.Btn_Ver_Clave_02.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Ver_Clave_02.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Ver_Clave_02.Image = CType(resources.GetObject("Btn_Ver_Clave_02.Image"), System.Drawing.Image)
        Me.Btn_Ver_Clave_02.Location = New System.Drawing.Point(193, 101)
        Me.Btn_Ver_Clave_02.Name = "Btn_Ver_Clave_02"
        Me.Btn_Ver_Clave_02.Size = New System.Drawing.Size(33, 20)
        Me.Btn_Ver_Clave_02.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Ver_Clave_02.TabIndex = 11
        '
        'Btn_Ver_Clave_01
        '
        Me.Btn_Ver_Clave_01.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Ver_Clave_01.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Ver_Clave_01.Image = CType(resources.GetObject("Btn_Ver_Clave_01.Image"), System.Drawing.Image)
        Me.Btn_Ver_Clave_01.Location = New System.Drawing.Point(193, 52)
        Me.Btn_Ver_Clave_01.Name = "Btn_Ver_Clave_01"
        Me.Btn_Ver_Clave_01.Size = New System.Drawing.Size(33, 20)
        Me.Btn_Ver_Clave_01.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Ver_Clave_01.TabIndex = 10
        '
        'Txtpass2
        '
        Me.Txtpass2.Location = New System.Drawing.Point(8, 101)
        Me.Txtpass2.Name = "Txtpass2"
        Me.Txtpass2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Txtpass2.Size = New System.Drawing.Size(181, 20)
        Me.Txtpass2.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(6, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(220, 23)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Confirmar contraseña"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Txtpass1
        '
        Me.Txtpass1.Location = New System.Drawing.Point(8, 52)
        Me.Txtpass1.Name = "Txtpass1"
        Me.Txtpass1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Txtpass1.Size = New System.Drawing.Size(181, 20)
        Me.Txtpass1.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(6, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(220, 23)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Nueva contraseña"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UsernameLabel
        '
        Me.UsernameLabel.Location = New System.Drawing.Point(6, 16)
        Me.UsernameLabel.Name = "UsernameLabel"
        Me.UsernameLabel.Size = New System.Drawing.Size(220, 23)
        Me.UsernameLabel.TabIndex = 7
        Me.UsernameLabel.Text = "&Nombre de usuario"
        Me.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Txt_Password
        '
        Me.Txt_Password.Location = New System.Drawing.Point(8, 92)
        Me.Txt_Password.Name = "Txt_Password"
        Me.Txt_Password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Txt_Password.Size = New System.Drawing.Size(226, 20)
        Me.Txt_Password.TabIndex = 5
        '
        'PasswordLabel
        '
        Me.PasswordLabel.Location = New System.Drawing.Point(6, 66)
        Me.PasswordLabel.Name = "PasswordLabel"
        Me.PasswordLabel.Size = New System.Drawing.Size(220, 23)
        Me.PasswordLabel.TabIndex = 4
        Me.PasswordLabel.Text = "&Contraseña actual"
        Me.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Aceptar, Me.Btn_Cancelar})
        Me.Bar1.Location = New System.Drawing.Point(0, 270)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(259, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 84
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Aceptar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Aceptar.Image = CType(resources.GetObject("Btn_Aceptar.Image"), System.Drawing.Image)
        Me.Btn_Aceptar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Tooltip = "Aceptar"
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Cancelar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Cancelar.Image = CType(resources.GetObject("Btn_Cancelar.Image"), System.Drawing.Image)
        Me.Btn_Cancelar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Cancelar.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Tooltip = "Cancelar"
        '
        'Clave_Administrador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Clave_Administrador"
        Me.Size = New System.Drawing.Size(259, 311)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Grupocambiapass.ResumeLayout(False)
        Me.Grupocambiapass.PerformLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Grupocambiapass As System.Windows.Forms.GroupBox
    Friend WithEvents Txtpass2 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Txtpass1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents UsernameLabel As System.Windows.Forms.Label
    Friend WithEvents Txt_Password As System.Windows.Forms.TextBox
    Friend WithEvents PasswordLabel As System.Windows.Forms.Label
    Friend WithEvents Btn_Ver_Clave_01 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Aceptar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Cancelar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Ver_Clave_02 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Lbl_Usuario As DevComponents.DotNetBar.LabelX

End Class
