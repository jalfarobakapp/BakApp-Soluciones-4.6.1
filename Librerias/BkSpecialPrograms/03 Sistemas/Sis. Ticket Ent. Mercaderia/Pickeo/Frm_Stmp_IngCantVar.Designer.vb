<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Stmp_IngCantVar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Stmp_IngCantVar))
        Me.TxtCantUD2 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtCantUD1 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.BtnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.LblUnidad2 = New System.Windows.Forms.Label()
        Me.LblUnidad1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Lbl_CantVenUd1 = New System.Windows.Forms.Label()
        Me.Lbl_CantVenUd2 = New System.Windows.Forms.Label()
        Me.Highlighter1 = New DevComponents.DotNetBar.Validator.Highlighter()
        Me.SuspendLayout()
        '
        'TxtCantUD2
        '
        '
        '
        '
        Me.TxtCantUD2.Border.Class = "TextBoxBorder"
        Me.TxtCantUD2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtCantUD2.DisabledBackColor = System.Drawing.Color.White
        Me.TxtCantUD2.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightOnFocus(Me.TxtCantUD2, True)
        Me.TxtCantUD2.Location = New System.Drawing.Point(122, 35)
        Me.TxtCantUD2.Name = "TxtCantUD2"
        Me.TxtCantUD2.PreventEnterBeep = True
        Me.TxtCantUD2.Size = New System.Drawing.Size(100, 22)
        Me.TxtCantUD2.TabIndex = 1
        Me.TxtCantUD2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TxtCantUD2.WatermarkText = "0"
        '
        'TxtCantUD1
        '
        '
        '
        '
        Me.TxtCantUD1.Border.Class = "TextBoxBorder"
        Me.TxtCantUD1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtCantUD1.DisabledBackColor = System.Drawing.Color.White
        Me.TxtCantUD1.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightOnFocus(Me.TxtCantUD1, True)
        Me.TxtCantUD1.Location = New System.Drawing.Point(122, 7)
        Me.TxtCantUD1.Name = "TxtCantUD1"
        Me.TxtCantUD1.PreventEnterBeep = True
        Me.TxtCantUD1.Size = New System.Drawing.Size(100, 22)
        Me.TxtCantUD1.TabIndex = 0
        Me.TxtCantUD1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TxtCantUD1.WatermarkText = "0"
        '
        'BtnAceptar
        '
        Me.BtnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnAceptar.Location = New System.Drawing.Point(15, 72)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(207, 24)
        Me.BtnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnAceptar.TabIndex = 126
        Me.BtnAceptar.Text = "ACEPTAR"
        '
        'LblUnidad2
        '
        Me.LblUnidad2.AutoSize = True
        Me.LblUnidad2.BackColor = System.Drawing.Color.White
        Me.LblUnidad2.ForeColor = System.Drawing.Color.Black
        Me.LblUnidad2.Location = New System.Drawing.Point(230, 37)
        Me.LblUnidad2.Name = "LblUnidad2"
        Me.LblUnidad2.Size = New System.Drawing.Size(29, 13)
        Me.LblUnidad2.TabIndex = 125
        Me.LblUnidad2.Text = "UD2"
        '
        'LblUnidad1
        '
        Me.LblUnidad1.AutoSize = True
        Me.LblUnidad1.BackColor = System.Drawing.Color.White
        Me.LblUnidad1.ForeColor = System.Drawing.Color.Black
        Me.LblUnidad1.Location = New System.Drawing.Point(230, 9)
        Me.LblUnidad1.Name = "LblUnidad1"
        Me.LblUnidad1.Size = New System.Drawing.Size(29, 13)
        Me.LblUnidad1.TabIndex = 124
        Me.LblUnidad1.Text = "UD1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(12, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 13)
        Me.Label2.TabIndex = 121
        Me.Label2.Text = "Unidad Secundaria"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 120
        Me.Label1.Text = "Unidad Primaria"
        '
        'Lbl_CantVenUd1
        '
        Me.Lbl_CantVenUd1.AutoSize = True
        Me.Lbl_CantVenUd1.BackColor = System.Drawing.Color.White
        Me.Lbl_CantVenUd1.ForeColor = System.Drawing.Color.Black
        Me.Lbl_CantVenUd1.Location = New System.Drawing.Point(265, 9)
        Me.Lbl_CantVenUd1.Name = "Lbl_CantVenUd1"
        Me.Lbl_CantVenUd1.Size = New System.Drawing.Size(128, 13)
        Me.Lbl_CantVenUd1.TabIndex = 130
        Me.Lbl_CantVenUd1.Text = "Cantidad vendida: 1500"
        '
        'Lbl_CantVenUd2
        '
        Me.Lbl_CantVenUd2.AutoSize = True
        Me.Lbl_CantVenUd2.BackColor = System.Drawing.Color.White
        Me.Lbl_CantVenUd2.ForeColor = System.Drawing.Color.Black
        Me.Lbl_CantVenUd2.Location = New System.Drawing.Point(265, 37)
        Me.Lbl_CantVenUd2.Name = "Lbl_CantVenUd2"
        Me.Lbl_CantVenUd2.Size = New System.Drawing.Size(110, 13)
        Me.Lbl_CantVenUd2.TabIndex = 131
        Me.Lbl_CantVenUd2.Text = "Cantidad vendida: 6"
        '
        'Highlighter1
        '
        Me.Highlighter1.ContainerControl = Me
        Me.Highlighter1.FocusHighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
        Me.Highlighter1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        '
        'Frm_Stmp_IngCantVar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(426, 107)
        Me.Controls.Add(Me.Lbl_CantVenUd2)
        Me.Controls.Add(Me.Lbl_CantVenUd1)
        Me.Controls.Add(Me.TxtCantUD2)
        Me.Controls.Add(Me.TxtCantUD1)
        Me.Controls.Add(Me.BtnAceptar)
        Me.Controls.Add(Me.LblUnidad2)
        Me.Controls.Add(Me.LblUnidad1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Stmp_IngCantVar"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RTU Variable"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtCantUD2 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtCantUD1 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents BtnAceptar As DevComponents.DotNetBar.ButtonX
    Public WithEvents LblUnidad2 As Label
    Public WithEvents LblUnidad1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Lbl_CantVenUd1 As Label
    Friend WithEvents Lbl_CantVenUd2 As Label
    Friend WithEvents Highlighter1 As DevComponents.DotNetBar.Validator.Highlighter
End Class
