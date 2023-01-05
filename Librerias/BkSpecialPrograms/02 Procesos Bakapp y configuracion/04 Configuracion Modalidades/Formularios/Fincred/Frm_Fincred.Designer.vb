<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Fincred
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Fincred))
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Txt_Token2 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Chk_AmbientePruebas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_NombreSucursal = New DevComponents.DotNetBar.Controls.TextBoxX()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar})
        Me.Bar1.Location = New System.Drawing.Point(0, 93)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(356, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 66
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Tooltip = "Grabar"
        '
        'Txt_Token2
        '
        Me.Txt_Token2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Token2.Border.Class = "TextBoxBorder"
        Me.Txt_Token2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Token2.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Token2.ForeColor = System.Drawing.Color.Black
        Me.Txt_Token2.Location = New System.Drawing.Point(107, 13)
        Me.Txt_Token2.MaxLength = 50
        Me.Txt_Token2.Name = "Txt_Token2"
        Me.Txt_Token2.PreventEnterBeep = True
        Me.Txt_Token2.Size = New System.Drawing.Size(240, 22)
        Me.Txt_Token2.TabIndex = 70
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(12, 12)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 23)
        Me.LabelX2.TabIndex = 69
        Me.LabelX2.Text = "Token"
        '
        'Chk_AmbientePruebas
        '
        Me.Chk_AmbientePruebas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_AmbientePruebas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_AmbientePruebas.CheckBoxImageChecked = CType(resources.GetObject("Chk_AmbientePruebas.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_AmbientePruebas.ForeColor = System.Drawing.Color.Black
        Me.Chk_AmbientePruebas.Location = New System.Drawing.Point(12, 69)
        Me.Chk_AmbientePruebas.Name = "Chk_AmbientePruebas"
        Me.Chk_AmbientePruebas.Size = New System.Drawing.Size(191, 16)
        Me.Chk_AmbientePruebas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_AmbientePruebas.TabIndex = 71
        Me.Chk_AmbientePruebas.TabStop = False
        Me.Chk_AmbientePruebas.Text = "Es ambiente de pruebas"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(12, 40)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(89, 23)
        Me.LabelX3.TabIndex = 72
        Me.LabelX3.Text = "Nombre Sucursal"
        '
        'Txt_NombreSucursal
        '
        Me.Txt_NombreSucursal.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_NombreSucursal.Border.Class = "TextBoxBorder"
        Me.Txt_NombreSucursal.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_NombreSucursal.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_NombreSucursal.ForeColor = System.Drawing.Color.Black
        Me.Txt_NombreSucursal.Location = New System.Drawing.Point(107, 41)
        Me.Txt_NombreSucursal.MaxLength = 50
        Me.Txt_NombreSucursal.Name = "Txt_NombreSucursal"
        Me.Txt_NombreSucursal.PreventEnterBeep = True
        Me.Txt_NombreSucursal.Size = New System.Drawing.Size(240, 22)
        Me.Txt_NombreSucursal.TabIndex = 73
        '
        'Frm_Fincred
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(356, 134)
        Me.Controls.Add(Me.Txt_NombreSucursal)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.Chk_AmbientePruebas)
        Me.Controls.Add(Me.Txt_Token2)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Fincred"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TOKEN FINCRED"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Txt_Token2 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Chk_AmbientePruebas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_NombreSucursal As DevComponents.DotNetBar.Controls.TextBoxX
End Class
