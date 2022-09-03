<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Form_Esperar
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
        Me.components = New System.ComponentModel.Container
        Me.BarraCircular = New DevComponents.DotNetBar.Controls.CircularProgress
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'BarraCircular
        '
        Me.BarraCircular.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.BarraCircular.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BarraCircular.Location = New System.Drawing.Point(10, 12)
        Me.BarraCircular.Name = "BarraCircular"
        Me.BarraCircular.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Dot
        Me.BarraCircular.ProgressColor = System.Drawing.Color.DarkGreen
        Me.BarraCircular.ProgressTextFormat = "{0}"
        Me.BarraCircular.Size = New System.Drawing.Size(82, 45)
        Me.BarraCircular.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.BarraCircular.TabIndex = 0
        Me.BarraCircular.TabStop = False
        '
        'ReflectionLabel1
        '
        Me.ReflectionLabel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.ForeColor = System.Drawing.Color.Black
        Me.ReflectionLabel1.Location = New System.Drawing.Point(98, -3)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(383, 60)
        Me.ReflectionLabel1.TabIndex = 1
        Me.ReflectionLabel1.TabStop = False
        Me.ReflectionLabel1.Text = "<b><font size=""+6""><i>C</i><font color=""#B02B2C"">argando información, por favor e" & _
            "spere...</font></font></b>"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'Frm_Form_Esperar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(502, 65)
        Me.ControlBox = False
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.BarraCircular)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Frm_Form_Esperar"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Public WithEvents BarraCircular As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
