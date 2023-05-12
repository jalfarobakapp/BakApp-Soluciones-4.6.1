<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_St_Mant_ProdServTecnico
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_St_Mant_ProdServTecnico))
        Me.Lbl_SelProdIngreso = New DevComponents.DotNetBar.LabelX()
        Me.Btn_SelProdIngreso = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_SelProdServicio = New DevComponents.DotNetBar.ButtonX()
        Me.Lbl_SelProdServicio = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Line1 = New DevComponents.DotNetBar.Controls.Line()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Lbl_SelProdIngreso
        '
        Me.Lbl_SelProdIngreso.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_SelProdIngreso.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_SelProdIngreso.ForeColor = System.Drawing.Color.Black
        Me.Lbl_SelProdIngreso.Location = New System.Drawing.Point(15, 26)
        Me.Lbl_SelProdIngreso.Name = "Lbl_SelProdIngreso"
        Me.Lbl_SelProdIngreso.Size = New System.Drawing.Size(401, 23)
        Me.Lbl_SelProdIngreso.TabIndex = 2
        Me.Lbl_SelProdIngreso.Text = "PRODUCTOS ASOCIADOS A INGRESO A TALLER... (Asignados: 999)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Btn_SelProdIngreso
        '
        Me.Btn_SelProdIngreso.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_SelProdIngreso.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_SelProdIngreso.Image = CType(resources.GetObject("Btn_SelProdIngreso.Image"), System.Drawing.Image)
        Me.Btn_SelProdIngreso.Location = New System.Drawing.Point(422, 28)
        Me.Btn_SelProdIngreso.Name = "Btn_SelProdIngreso"
        Me.Btn_SelProdIngreso.Size = New System.Drawing.Size(96, 21)
        Me.Btn_SelProdIngreso.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_SelProdIngreso.TabIndex = 14
        Me.Btn_SelProdIngreso.Text = "Buscar prod."
        Me.Btn_SelProdIngreso.Tooltip = "Buscar productos"
        '
        'Btn_SelProdServicio
        '
        Me.Btn_SelProdServicio.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_SelProdServicio.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_SelProdServicio.Image = CType(resources.GetObject("Btn_SelProdServicio.Image"), System.Drawing.Image)
        Me.Btn_SelProdServicio.Location = New System.Drawing.Point(422, 55)
        Me.Btn_SelProdServicio.Name = "Btn_SelProdServicio"
        Me.Btn_SelProdServicio.Size = New System.Drawing.Size(96, 21)
        Me.Btn_SelProdServicio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_SelProdServicio.TabIndex = 16
        Me.Btn_SelProdServicio.Text = "Buscar prod."
        Me.Btn_SelProdServicio.Tooltip = "Buscar productos"
        '
        'Lbl_SelProdServicio
        '
        Me.Lbl_SelProdServicio.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_SelProdServicio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_SelProdServicio.ForeColor = System.Drawing.Color.Black
        Me.Lbl_SelProdServicio.Location = New System.Drawing.Point(15, 55)
        Me.Lbl_SelProdServicio.Name = "Lbl_SelProdServicio"
        Me.Lbl_SelProdServicio.Size = New System.Drawing.Size(401, 23)
        Me.Lbl_SelProdServicio.TabIndex = 15
        Me.Lbl_SelProdServicio.Text = "PRODUCTOS ASOCIADOS A SERVICIOS DE REPARACION... (Asignados: 999)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(12, 113)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(518, 94)
        Me.LabelX3.TabIndex = 17
        Me.LabelX3.Text = resources.GetString("LabelX3.Text")
        Me.LabelX3.TextLineAlignment = System.Drawing.StringAlignment.Near
        '
        'Line1
        '
        Me.Line1.Location = New System.Drawing.Point(12, 93)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(521, 23)
        Me.Line1.TabIndex = 18
        Me.Line1.Text = "Line1"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar})
        Me.Bar2.Location = New System.Drawing.Point(0, 226)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(545, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 91
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.ImageAlt = CType(resources.GetObject("Btn_Grabar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Grabar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Tooltip = "Grabar "
        '
        'Frm_St_Mant_ProdServTecnico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(545, 267)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.Btn_SelProdServicio)
        Me.Controls.Add(Me.Lbl_SelProdServicio)
        Me.Controls.Add(Me.Btn_SelProdIngreso)
        Me.Controls.Add(Me.Lbl_SelProdIngreso)
        Me.Controls.Add(Me.Line1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_St_Mant_ProdServTecnico"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FILTRO PARA MOSTRAR PRODUCTOS EN SERVICIO TECNICO"
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Lbl_SelProdIngreso As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_SelProdIngreso As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_SelProdServicio As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Lbl_SelProdServicio As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Line1 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
End Class
