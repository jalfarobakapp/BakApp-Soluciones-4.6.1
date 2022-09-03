<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SplashScreen1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.Lblporcentaje = New System.Windows.Forms.Label
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Lblversion = New System.Windows.Forms.Label
        Me.Copyright = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Lblporcentaje
        '
        Me.Lblporcentaje.AutoSize = True
        Me.Lblporcentaje.BackColor = System.Drawing.Color.Transparent
        Me.Lblporcentaje.Location = New System.Drawing.Point(383, 190)
        Me.Lblporcentaje.Name = "Lblporcentaje"
        Me.Lblporcentaje.Size = New System.Drawing.Size(39, 13)
        Me.Lblporcentaje.TabIndex = 1
        Me.Lblporcentaje.Text = "Label1"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(258, 191)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(118, 12)
        Me.ProgressBar1.TabIndex = 2
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.AntBru.My.Resources.Resources.Inicio
        Me.PictureBox1.Location = New System.Drawing.Point(0, -1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(435, 218)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Lblversion
        '
        Me.Lblversion.AutoSize = True
        Me.Lblversion.Location = New System.Drawing.Point(271, 9)
        Me.Lblversion.Name = "Lblversion"
        Me.Lblversion.Size = New System.Drawing.Size(39, 13)
        Me.Lblversion.TabIndex = 3
        Me.Lblversion.Text = "Label2"
        '
        'Copyright
        '
        Me.Copyright.AutoSize = True
        Me.Copyright.Location = New System.Drawing.Point(271, 32)
        Me.Copyright.Name = "Copyright"
        Me.Copyright.Size = New System.Drawing.Size(39, 13)
        Me.Copyright.TabIndex = 4
        Me.Copyright.Text = "Label2"
        '
        'Timer1
        '
        '
        'SplashScreen1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(434, 215)
        Me.ControlBox = False
        Me.Controls.Add(Me.Copyright)
        Me.Controls.Add(Me.Lblversion)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Lblporcentaje)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SplashScreen1"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Lblporcentaje As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Lblversion As System.Windows.Forms.Label
    Friend WithEvents Copyright As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
