<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Huella_Identificar
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Huella_Identificar))
        Me.axZKFPEngX1 = New AxZKFPEngXControl.AxZKFPEngX()
        Me.rdb10 = New System.Windows.Forms.RadioButton()
        Me.rdb9 = New System.Windows.Forms.RadioButton()
        Me.txtb5 = New System.Windows.Forms.TextBox()
        Me.txtb1 = New System.Windows.Forms.TextBox()
        Me.label6 = New System.Windows.Forms.Label()
        Me.label5 = New System.Windows.Forms.Label()
        Me.label4 = New System.Windows.Forms.Label()
        Me.txtb2 = New System.Windows.Forms.TextBox()
        Me.pictureBox1 = New System.Windows.Forms.PictureBox()
        Me.statusBar1 = New System.Windows.Forms.StatusBar()
        Me.statusbar0 = New System.Windows.Forms.StatusBarPanel()
        Me.Tiempo_Encender = New System.Windows.Forms.Timer(Me.components)
        Me.Btn_Grabar_Sin_Lector = New DevComponents.DotNetBar.ButtonX()
        CType(Me.axZKFPEngX1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.statusbar0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'axZKFPEngX1
        '
        Me.axZKFPEngX1.BackColor = System.Drawing.Color.White
        Me.axZKFPEngX1.Enabled = True
        Me.axZKFPEngX1.ForeColor = System.Drawing.Color.Black
        Me.axZKFPEngX1.Location = New System.Drawing.Point(96, 80)
        Me.axZKFPEngX1.Name = "axZKFPEngX1"
        Me.axZKFPEngX1.OcxState = CType(resources.GetObject("axZKFPEngX1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.axZKFPEngX1.Size = New System.Drawing.Size(24, 24)
        Me.axZKFPEngX1.TabIndex = 64
        '
        'rdb10
        '
        Me.rdb10.AutoSize = True
        Me.rdb10.BackColor = System.Drawing.Color.White
        Me.rdb10.Checked = True
        Me.rdb10.Enabled = False
        Me.rdb10.ForeColor = System.Drawing.Color.Black
        Me.rdb10.Location = New System.Drawing.Point(106, 381)
        Me.rdb10.Name = "rdb10"
        Me.rdb10.Size = New System.Drawing.Size(94, 17)
        Me.rdb10.TabIndex = 46
        Me.rdb10.TabStop = True
        Me.rdb10.Text = "ZKFinger 10.0"
        Me.rdb10.UseVisualStyleBackColor = False
        '
        'rdb9
        '
        Me.rdb9.AutoSize = True
        Me.rdb9.BackColor = System.Drawing.Color.White
        Me.rdb9.Enabled = False
        Me.rdb9.ForeColor = System.Drawing.Color.Black
        Me.rdb9.Location = New System.Drawing.Point(12, 381)
        Me.rdb9.Name = "rdb9"
        Me.rdb9.Size = New System.Drawing.Size(88, 17)
        Me.rdb9.TabIndex = 44
        Me.rdb9.Text = "ZKFinger 9.0"
        Me.rdb9.UseVisualStyleBackColor = False
        '
        'txtb5
        '
        Me.txtb5.BackColor = System.Drawing.Color.White
        Me.txtb5.ForeColor = System.Drawing.Color.Black
        Me.txtb5.Location = New System.Drawing.Point(312, 45)
        Me.txtb5.Name = "txtb5"
        Me.txtb5.ReadOnly = True
        Me.txtb5.Size = New System.Drawing.Size(241, 22)
        Me.txtb5.TabIndex = 53
        '
        'txtb1
        '
        Me.txtb1.BackColor = System.Drawing.Color.White
        Me.txtb1.ForeColor = System.Drawing.Color.Black
        Me.txtb1.Location = New System.Drawing.Point(400, 2)
        Me.txtb1.Name = "txtb1"
        Me.txtb1.ReadOnly = True
        Me.txtb1.Size = New System.Drawing.Size(52, 22)
        Me.txtb1.TabIndex = 52
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.BackColor = System.Drawing.Color.White
        Me.label6.ForeColor = System.Drawing.Color.Black
        Me.label6.Location = New System.Drawing.Point(309, 29)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(79, 13)
        Me.label6.TabIndex = 50
        Me.label6.Text = "Serial Number"
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.BackColor = System.Drawing.Color.White
        Me.label5.ForeColor = System.Drawing.Color.Black
        Me.label5.Location = New System.Drawing.Point(514, 6)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(46, 13)
        Me.label5.TabIndex = 48
        Me.label5.Text = "Current"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.BackColor = System.Drawing.Color.White
        Me.label4.ForeColor = System.Drawing.Color.Black
        Me.label4.Location = New System.Drawing.Point(312, 6)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(77, 13)
        Me.label4.TabIndex = 47
        Me.label4.Text = "Sensor Count"
        '
        'txtb2
        '
        Me.txtb2.BackColor = System.Drawing.Color.White
        Me.txtb2.ForeColor = System.Drawing.Color.Black
        Me.txtb2.Location = New System.Drawing.Point(573, 2)
        Me.txtb2.Name = "txtb2"
        Me.txtb2.ReadOnly = True
        Me.txtb2.Size = New System.Drawing.Size(68, 22)
        Me.txtb2.TabIndex = 49
        '
        'pictureBox1
        '
        Me.pictureBox1.BackColor = System.Drawing.Color.White
        Me.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pictureBox1.ForeColor = System.Drawing.Color.Black
        Me.pictureBox1.Location = New System.Drawing.Point(12, 3)
        Me.pictureBox1.Name = "pictureBox1"
        Me.pictureBox1.Size = New System.Drawing.Size(271, 372)
        Me.pictureBox1.TabIndex = 41
        Me.pictureBox1.TabStop = False
        '
        'statusBar1
        '
        Me.statusBar1.ForeColor = System.Drawing.Color.Black
        Me.statusBar1.Location = New System.Drawing.Point(0, 438)
        Me.statusBar1.Name = "statusBar1"
        Me.statusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.statusbar0})
        Me.statusBar1.ShowPanels = True
        Me.statusBar1.Size = New System.Drawing.Size(295, 26)
        Me.statusBar1.TabIndex = 42
        '
        'statusbar0
        '
        Me.statusbar0.Name = "statusbar0"
        Me.statusbar0.Text = "Estado:"
        Me.statusbar0.Width = 770
        '
        'Tiempo_Encender
        '
        Me.Tiempo_Encender.Interval = 1000
        '
        'Btn_Grabar_Sin_Lector
        '
        Me.Btn_Grabar_Sin_Lector.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Grabar_Sin_Lector.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Grabar_Sin_Lector.Location = New System.Drawing.Point(181, 404)
        Me.Btn_Grabar_Sin_Lector.Name = "Btn_Grabar_Sin_Lector"
        Me.Btn_Grabar_Sin_Lector.Size = New System.Drawing.Size(102, 23)
        Me.Btn_Grabar_Sin_Lector.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Grabar_Sin_Lector.TabIndex = 65
        Me.Btn_Grabar_Sin_Lector.Text = "Grabar sin huella"
        '
        'Frm_Huella_Identificar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(295, 464)
        Me.Controls.Add(Me.Btn_Grabar_Sin_Lector)
        Me.Controls.Add(Me.axZKFPEngX1)
        Me.Controls.Add(Me.rdb10)
        Me.Controls.Add(Me.rdb9)
        Me.Controls.Add(Me.txtb5)
        Me.Controls.Add(Me.txtb1)
        Me.Controls.Add(Me.label6)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.txtb2)
        Me.Controls.Add(Me.pictureBox1)
        Me.Controls.Add(Me.statusBar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Huella_Identificar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "IDENTIFICAR HUELLA"
        CType(Me.axZKFPEngX1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.statusbar0, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents axZKFPEngX1 As AxZKFPEngX
    Private WithEvents rdb10 As RadioButton
    Private WithEvents rdb9 As RadioButton
    Private WithEvents txtb5 As TextBox
    Private WithEvents txtb1 As TextBox
    Private WithEvents label6 As Label
    Private WithEvents label5 As Label
    Private WithEvents label4 As Label
    Private WithEvents txtb2 As TextBox
    Private WithEvents pictureBox1 As PictureBox
    Private WithEvents statusBar1 As StatusBar
    Private WithEvents statusbar0 As StatusBarPanel
    Friend WithEvents Tiempo_Encender As Timer
    Public WithEvents Btn_Grabar_Sin_Lector As DevComponents.DotNetBar.ButtonX
End Class
