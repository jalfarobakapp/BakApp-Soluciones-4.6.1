<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Meson_Operario_Ingreso
    Inherits DevComponents.DotNetBar.Metro.MetroForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Meson_Operario_Ingreso))
        Me.Btn_Ingresar_DFA = New DevComponents.DotNetBar.ButtonX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Ingresar_Manualmente = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Buscar_OT = New DevComponents.DotNetBar.ButtonItem()
        Me.ReflectionImage1 = New DevComponents.DotNetBar.Controls.ReflectionImage()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Btn_Ingresar_DFA
        '
        Me.Btn_Ingresar_DFA.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Ingresar_DFA.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Ingresar_DFA.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Ingresar_DFA.Image = CType(resources.GetObject("Btn_Ingresar_DFA.Image"), System.Drawing.Image)
        Me.Btn_Ingresar_DFA.ImageAlt = CType(resources.GetObject("Btn_Ingresar_DFA.ImageAlt"), System.Drawing.Image)
        Me.Btn_Ingresar_DFA.Location = New System.Drawing.Point(112, 32)
        Me.Btn_Ingresar_DFA.Name = "Btn_Ingresar_DFA"
        Me.Btn_Ingresar_DFA.Size = New System.Drawing.Size(365, 139)
        Me.Btn_Ingresar_DFA.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Ingresar_DFA.TabIndex = 0
        Me.Btn_Ingresar_DFA.Text = "<b>INGRESAR HORAS</b><br/> " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<b>DE PRODUCCION</b>"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Ingresar_Manualmente, Me.Btn_Buscar_OT})
        Me.Bar1.Location = New System.Drawing.Point(0, 300)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(592, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 30
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Ingresar_Manualmente
        '
        Me.Btn_Ingresar_Manualmente.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Ingresar_Manualmente.ForeColor = System.Drawing.Color.Black
        Me.Btn_Ingresar_Manualmente.Image = CType(resources.GetObject("Btn_Ingresar_Manualmente.Image"), System.Drawing.Image)
        Me.Btn_Ingresar_Manualmente.ImageAlt = CType(resources.GetObject("Btn_Ingresar_Manualmente.ImageAlt"), System.Drawing.Image)
        Me.Btn_Ingresar_Manualmente.Name = "Btn_Ingresar_Manualmente"
        Me.Btn_Ingresar_Manualmente.Text = "Buscar operario"
        Me.Btn_Ingresar_Manualmente.Tooltip = "Ingresar horas manualmente, buscar operario en la lista"
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
        '
        'ReflectionImage1
        '
        Me.ReflectionImage1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.ReflectionImage1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionImage1.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.ReflectionImage1.Image = CType(resources.GetObject("ReflectionImage1.Image"), System.Drawing.Image)
        Me.ReflectionImage1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ReflectionImage1.Location = New System.Drawing.Point(112, 189)
        Me.ReflectionImage1.Name = "ReflectionImage1"
        Me.ReflectionImage1.Size = New System.Drawing.Size(365, 101)
        Me.ReflectionImage1.TabIndex = 31
        '
        'Frm_Meson_Operario_Ingreso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(592, 341)
        Me.Controls.Add(Me.ReflectionImage1)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.Btn_Ingresar_DFA)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Meson_Operario_Ingreso"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "INGRESO DE HORAS DE PRODUCCION POR OPERARIO"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Btn_Ingresar_DFA As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents ReflectionImage1 As DevComponents.DotNetBar.Controls.ReflectionImage
    Public WithEvents Btn_Ingresar_Manualmente As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Buscar_OT As DevComponents.DotNetBar.ButtonItem
End Class
