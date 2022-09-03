<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ValidarPermisoUsuario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ValidarPermisoUsuario))
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.BtnIngresarClave = New DevComponents.DotNetBar.ButtonItem
        Me.BtnPermisoRemoto = New DevComponents.DotNetBar.ButtonItem
        Me.BtnOtorgarPermisoPermanente = New DevComponents.DotNetBar.ButtonItem
        Me.BtnxSalir = New DevComponents.DotNetBar.ButtonItem
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.LblDescripcionPermiso = New DevComponents.DotNetBar.LabelX
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX
        Me.LblCodPermiso = New DevComponents.DotNetBar.LabelX
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
        Me.ReflectionImage1 = New DevComponents.DotNetBar.Controls.ReflectionImage
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnIngresarClave, Me.BtnPermisoRemoto, Me.BtnOtorgarPermisoPermanente, Me.BtnxSalir})
        Me.Bar1.Location = New System.Drawing.Point(0, 196)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(501, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 25
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnIngresarClave
        '
        Me.BtnIngresarClave.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnIngresarClave.ForeColor = System.Drawing.Color.Black
        Me.BtnIngresarClave.Image = Global.Funciones_BakApp.My.Resources.Resources.key
        Me.BtnIngresarClave.Name = "BtnIngresarClave"
        Me.BtnIngresarClave.Text = "Ingresar clave de autorización"
        '
        'BtnPermisoRemoto
        '
        Me.BtnPermisoRemoto.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnPermisoRemoto.ForeColor = System.Drawing.Color.Black
        Me.BtnPermisoRemoto.Image = CType(resources.GetObject("BtnPermisoRemoto.Image"), System.Drawing.Image)
        Me.BtnPermisoRemoto.Name = "BtnPermisoRemoto"
        Me.BtnPermisoRemoto.Text = "Solicitar permiso remoto"
        Me.BtnPermisoRemoto.Tooltip = "Remota"
        '
        'BtnOtorgarPermisoPermanente
        '
        Me.BtnOtorgarPermisoPermanente.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnOtorgarPermisoPermanente.ForeColor = System.Drawing.Color.Black
        Me.BtnOtorgarPermisoPermanente.Image = Global.Funciones_BakApp.My.Resources.Resources.user_ok
        Me.BtnOtorgarPermisoPermanente.Name = "BtnOtorgarPermisoPermanente"
        Me.BtnOtorgarPermisoPermanente.Tooltip = "Otorgar el permiso permanentemente"
        '
        'BtnxSalir
        '
        Me.BtnxSalir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnxSalir.ForeColor = System.Drawing.Color.Black
        Me.BtnxSalir.Image = Global.Funciones_BakApp.My.Resources.Resources.button_rounded_red_delete
        Me.BtnxSalir.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnxSalir.Name = "BtnxSalir"
        '
        'ReflectionLabel1
        '
        Me.ReflectionLabel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.ForeColor = System.Drawing.Color.Black
        Me.ReflectionLabel1.Location = New System.Drawing.Point(68, -5)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(403, 49)
        Me.ReflectionLabel1.TabIndex = 26
        Me.ReflectionLabel1.Text = "<b><font size=""+4" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & """><i>U</i><font color=""#B02B2C"">sted no posee permiso para rea" & _
            "lizar esta acción</font></font></b>"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.LblDescripcionPermiso)
        Me.GroupBox1.Controls.Add(Me.LabelX3)
        Me.GroupBox1.Controls.Add(Me.LblCodPermiso)
        Me.GroupBox1.Controls.Add(Me.LabelX1)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(12, 50)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(481, 138)
        Me.GroupBox1.TabIndex = 27
        Me.GroupBox1.TabStop = False
        '
        'LblDescripcionPermiso
        '
        Me.LblDescripcionPermiso.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.LblDescripcionPermiso.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblDescripcionPermiso.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDescripcionPermiso.ForeColor = System.Drawing.Color.Black
        Me.LblDescripcionPermiso.Location = New System.Drawing.Point(17, 87)
        Me.LblDescripcionPermiso.Name = "LblDescripcionPermiso"
        Me.LblDescripcionPermiso.Size = New System.Drawing.Size(442, 45)
        Me.LblDescripcionPermiso.TabIndex = 3
        Me.LblDescripcionPermiso.Text = "LabelX2"
        Me.LblDescripcionPermiso.TextLineAlignment = System.Drawing.StringAlignment.Near
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(17, 53)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(102, 28)
        Me.LabelX3.TabIndex = 2
        Me.LabelX3.Text = "Descripción :"
        '
        'LblCodPermiso
        '
        Me.LblCodPermiso.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.LblCodPermiso.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblCodPermiso.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCodPermiso.ForeColor = System.Drawing.Color.Black
        Me.LblCodPermiso.Location = New System.Drawing.Point(84, 24)
        Me.LblCodPermiso.Name = "LblCodPermiso"
        Me.LblCodPermiso.Size = New System.Drawing.Size(146, 23)
        Me.LblCodPermiso.TabIndex = 1
        Me.LblCodPermiso.Text = "LabelX2"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(17, 21)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(76, 28)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "Código :"
        '
        'ReflectionImage1
        '
        '
        '
        '
        Me.ReflectionImage1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionImage1.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.ReflectionImage1.Location = New System.Drawing.Point(18, -5)
        Me.ReflectionImage1.Name = "ReflectionImage1"
        Me.ReflectionImage1.Size = New System.Drawing.Size(44, 63)
        Me.ReflectionImage1.TabIndex = 28
        '
        'Frm_ValidarPermisoUsuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(501, 237)
        Me.ControlBox = False
        Me.Controls.Add(Me.ReflectionImage1)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "Frm_ValidarPermisoUsuario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Permiso de usuario"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnIngresarClave As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnxSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LblDescripcionPermiso As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LblCodPermiso As DevComponents.DotNetBar.LabelX
    Friend WithEvents BtnPermisoRemoto As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ReflectionImage1 As DevComponents.DotNetBar.Controls.ReflectionImage
    Friend WithEvents BtnOtorgarPermisoPermanente As DevComponents.DotNetBar.ButtonItem
End Class
