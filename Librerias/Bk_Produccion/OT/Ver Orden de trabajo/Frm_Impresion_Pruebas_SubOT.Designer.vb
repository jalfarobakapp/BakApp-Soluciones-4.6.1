<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Impresion_Pruebas_SubOT
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Impresion_Pruebas_SubOT))
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX
        Me.Txt_OT = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.Txt_SubOt = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX
        Me.Btn_Operarios = New DevComponents.DotNetBar.ButtonX
        Me.SuspendLayout()
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Image = CType(resources.GetObject("ButtonX1.Image"), System.Drawing.Image)
        Me.ButtonX1.Location = New System.Drawing.Point(209, 41)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(99, 22)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 0
        Me.ButtonX1.TabStop = False
        Me.ButtonX1.Text = "Imprimir"
        '
        'Txt_OT
        '
        Me.Txt_OT.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_OT.Border.Class = "TextBoxBorder"
        Me.Txt_OT.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_OT.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_OT.ForeColor = System.Drawing.Color.Black
        Me.Txt_OT.Location = New System.Drawing.Point(12, 41)
        Me.Txt_OT.Name = "Txt_OT"
        Me.Txt_OT.PreventEnterBeep = True
        Me.Txt_OT.Size = New System.Drawing.Size(100, 22)
        Me.Txt_OT.TabIndex = 0
        '
        'Txt_SubOt
        '
        Me.Txt_SubOt.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_SubOt.Border.Class = "TextBoxBorder"
        Me.Txt_SubOt.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_SubOt.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_SubOt.ForeColor = System.Drawing.Color.Black
        Me.Txt_SubOt.Location = New System.Drawing.Point(118, 41)
        Me.Txt_SubOt.Name = "Txt_SubOt"
        Me.Txt_SubOt.PreventEnterBeep = True
        Me.Txt_SubOt.Size = New System.Drawing.Size(75, 22)
        Me.Txt_SubOt.TabIndex = 1
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(12, 12)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 23)
        Me.LabelX1.TabIndex = 3
        Me.LabelX1.Text = "Nro OT"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(118, 12)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 23)
        Me.LabelX2.TabIndex = 4
        Me.LabelX2.Text = "Sub OT"
        '
        'Btn_Operarios
        '
        Me.Btn_Operarios.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Operarios.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Operarios.Location = New System.Drawing.Point(12, 97)
        Me.Btn_Operarios.Name = "Btn_Operarios"
        Me.Btn_Operarios.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Operarios.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Operarios.TabIndex = 5
        Me.Btn_Operarios.Text = "Operarios"
        '
        'Frm_Impresion_Pruebas_SubOT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(320, 70)
        Me.Controls.Add(Me.Btn_Operarios)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Txt_SubOt)
        Me.Controls.Add(Me.Txt_OT)
        Me.Controls.Add(Me.ButtonX1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Impresion_Pruebas_SubOT"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Impresión de Hoja de Ruta"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Txt_OT As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_SubOt As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Operarios As DevComponents.DotNetBar.ButtonX
End Class
