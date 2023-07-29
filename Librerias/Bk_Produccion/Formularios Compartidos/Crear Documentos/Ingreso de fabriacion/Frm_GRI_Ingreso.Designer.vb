<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_GRI_Ingreso
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_GRI_Ingreso))
        Me.ReflectionImage1 = New DevComponents.DotNetBar.Controls.ReflectionImage()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Buscar_OT = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Ingresar_GRI = New DevComponents.DotNetBar.ButtonX()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReflectionImage1
        '
        Me.ReflectionImage1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.ReflectionImage1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionImage1.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.ReflectionImage1.ForeColor = System.Drawing.Color.Black
        Me.ReflectionImage1.Image = CType(resources.GetObject("ReflectionImage1.Image"), System.Drawing.Image)
        Me.ReflectionImage1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ReflectionImage1.Location = New System.Drawing.Point(28, 227)
        Me.ReflectionImage1.Name = "ReflectionImage1"
        Me.ReflectionImage1.Size = New System.Drawing.Size(519, 101)
        Me.ReflectionImage1.TabIndex = 34
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Buscar_OT})
        Me.Bar1.Location = New System.Drawing.Point(0, 345)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(547, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 33
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Buscar_OT
        '
        Me.Btn_Buscar_OT.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Buscar_OT.ForeColor = System.Drawing.Color.Black
        Me.Btn_Buscar_OT.Image = CType(resources.GetObject("Btn_Buscar_OT.Image"), System.Drawing.Image)
        Me.Btn_Buscar_OT.ImageAlt = CType(resources.GetObject("Btn_Buscar_OT.ImageAlt"), System.Drawing.Image)
        Me.Btn_Buscar_OT.Name = "Btn_Buscar_OT"
        Me.Btn_Buscar_OT.Text = "Buscar OT"
        Me.Btn_Buscar_OT.Tooltip = "Ver OT"
        Me.Btn_Buscar_OT.Visible = False
        '
        'Btn_Ingresar_GRI
        '
        Me.Btn_Ingresar_GRI.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Ingresar_GRI.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Ingresar_GRI.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Ingresar_GRI.Image = CType(resources.GetObject("Btn_Ingresar_GRI.Image"), System.Drawing.Image)
        Me.Btn_Ingresar_GRI.ImageAlt = CType(resources.GetObject("Btn_Ingresar_GRI.ImageAlt"), System.Drawing.Image)
        Me.Btn_Ingresar_GRI.Location = New System.Drawing.Point(64, 40)
        Me.Btn_Ingresar_GRI.Name = "Btn_Ingresar_GRI"
        Me.Btn_Ingresar_GRI.Size = New System.Drawing.Size(411, 139)
        Me.Btn_Ingresar_GRI.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Ingresar_GRI.TabIndex = 32
        Me.Btn_Ingresar_GRI.Text = "<b>INGRESAR PRODUCTOS</b><br/> " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<b>FABRICADOS A BODEGA</b>"
        '
        'Frm_GRI_Ingreso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(547, 386)
        Me.Controls.Add(Me.ReflectionImage1)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.Btn_Ingresar_GRI)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_GRI_Ingreso"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "INGRESO DE DATOS DE FABRICACION"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReflectionImage1 As DevComponents.DotNetBar.Controls.ReflectionImage
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Public WithEvents Btn_Buscar_OT As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Ingresar_GRI As DevComponents.DotNetBar.ButtonX
End Class
