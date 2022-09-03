<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Cantidades_Ud_Disintas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Cantidades_Ud_Disintas))
        Me.LblUnidad2 = New System.Windows.Forms.Label
        Me.LblUnidad1 = New System.Windows.Forms.Label
        Me.TxtCantUD2 = New System.Windows.Forms.TextBox
        Me.TxtRTU = New System.Windows.Forms.TextBox
        Me.TxtCantUD1 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.BtnAceptar = New DevComponents.DotNetBar.ButtonX
        Me.SuspendLayout()
        '
        'LblUnidad2
        '
        Me.LblUnidad2.AutoSize = True
        Me.LblUnidad2.Location = New System.Drawing.Point(230, 59)
        Me.LblUnidad2.Name = "LblUnidad2"
        Me.LblUnidad2.Size = New System.Drawing.Size(29, 13)
        Me.LblUnidad2.TabIndex = 16
        Me.LblUnidad2.Text = "UD2"
        '
        'LblUnidad1
        '
        Me.LblUnidad1.AutoSize = True
        Me.LblUnidad1.Location = New System.Drawing.Point(230, 9)
        Me.LblUnidad1.Name = "LblUnidad1"
        Me.LblUnidad1.Size = New System.Drawing.Size(29, 13)
        Me.LblUnidad1.TabIndex = 15
        Me.LblUnidad1.Text = "UD1"
        '
        'TxtCantUD2
        '
        Me.TxtCantUD2.Location = New System.Drawing.Point(122, 56)
        Me.TxtCantUD2.Name = "TxtCantUD2"
        Me.TxtCantUD2.Size = New System.Drawing.Size(100, 22)
        Me.TxtCantUD2.TabIndex = 12
        Me.TxtCantUD2.Text = "0"
        Me.TxtCantUD2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtRTU
        '
        Me.TxtRTU.Enabled = False
        Me.TxtRTU.Location = New System.Drawing.Point(122, 32)
        Me.TxtRTU.Name = "TxtRTU"
        Me.TxtRTU.ReadOnly = True
        Me.TxtRTU.Size = New System.Drawing.Size(100, 22)
        Me.TxtRTU.TabIndex = 14
        Me.TxtRTU.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtCantUD1
        '
        Me.TxtCantUD1.Location = New System.Drawing.Point(122, 6)
        Me.TxtCantUD1.Name = "TxtCantUD1"
        Me.TxtCantUD1.Size = New System.Drawing.Size(100, 22)
        Me.TxtCantUD1.TabIndex = 8
        Me.TxtCantUD1.Text = "0"
        Me.TxtCantUD1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "R.T.U. "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Unidad Secundaria"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Unidad Primaria"
        '
        'BtnAceptar
        '
        Me.BtnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnAceptar.Location = New System.Drawing.Point(15, 84)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(210, 23)
        Me.BtnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnAceptar.TabIndex = 17
        Me.BtnAceptar.Text = "ACEPTAR"
        '
        'Frm_Cantidades_Ud_Disintas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(259, 117)
        Me.ControlBox = False
        Me.Controls.Add(Me.BtnAceptar)
        Me.Controls.Add(Me.LblUnidad2)
        Me.Controls.Add(Me.LblUnidad1)
        Me.Controls.Add(Me.TxtCantUD2)
        Me.Controls.Add(Me.TxtRTU)
        Me.Controls.Add(Me.TxtCantUD1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_Cantidades_Ud_Disintas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ingreso cantidades"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtCantUD2 As System.Windows.Forms.TextBox
    Friend WithEvents TxtCantUD1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnAceptar As DevComponents.DotNetBar.ButtonX
    Public WithEvents LblUnidad2 As System.Windows.Forms.Label
    Public WithEvents LblUnidad1 As System.Windows.Forms.Label
    Public WithEvents TxtRTU As System.Windows.Forms.TextBox
End Class
