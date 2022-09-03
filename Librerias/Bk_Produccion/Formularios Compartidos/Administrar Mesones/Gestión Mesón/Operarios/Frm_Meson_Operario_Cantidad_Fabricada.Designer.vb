<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Meson_Operario_Cantidad_Fabricada
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Meson_Operario_Cantidad_Fabricada))
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Num_Cant_Fabricada = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Lbl_Cantidad_Fabricar = New System.Windows.Forms.Label()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Num_Cant_Fabricada, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar})
        Me.Bar1.Location = New System.Drawing.Point(0, 173)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(399, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 33
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.ImageAlt = CType(resources.GetObject("Btn_Grabar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Text = "Aceptar"
        '
        'Num_Cant_Fabricada
        '
        Me.Num_Cant_Fabricada.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Num_Cant_Fabricada.Location = New System.Drawing.Point(272, 49)
        Me.Num_Cant_Fabricada.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.Num_Cant_Fabricada.Name = "Num_Cant_Fabricada"
        Me.Num_Cant_Fabricada.Size = New System.Drawing.Size(73, 50)
        Me.Num_Cant_Fabricada.TabIndex = 32
        Me.Num_Cant_Fabricada.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Num_Cant_Fabricada.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(24, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(242, 37)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Cantidad fabricada"
        '
        'Lbl_Cantidad_Fabricar
        '
        Me.Lbl_Cantidad_Fabricar.AutoSize = True
        Me.Lbl_Cantidad_Fabricar.BackColor = System.Drawing.Color.White
        Me.Lbl_Cantidad_Fabricar.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Cantidad_Fabricar.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Cantidad_Fabricar.Location = New System.Drawing.Point(24, 9)
        Me.Lbl_Cantidad_Fabricar.Name = "Lbl_Cantidad_Fabricar"
        Me.Lbl_Cantidad_Fabricar.Size = New System.Drawing.Size(240, 37)
        Me.Lbl_Cantidad_Fabricar.TabIndex = 34
        Me.Lbl_Cantidad_Fabricar.Text = "Cantidad esperada"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(4, 105)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(395, 66)
        Me.LabelX1.TabIndex = 39
        Me.LabelX1.Text = "<b>Codigo: XXXXXXXXXXXXX</b><br/>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<font color=""#17365D"">Descripcion: ZXZXZXZXZXZ" &
    "XZXZXZXZXZXZXZXZXZXZXZXZXZXZXZXZXZXZXZD</font>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Frm_Meson_Operario_Cantidad_Fabricada
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(399, 214)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Lbl_Cantidad_Fabricar)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.Num_Cant_Fabricada)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Meson_Operario_Cantidad_Fabricada"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Productos fabricados correctamente"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Num_Cant_Fabricada, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Public WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Num_Cant_Fabricada As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents Lbl_Cantidad_Fabricar As Label
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
End Class
