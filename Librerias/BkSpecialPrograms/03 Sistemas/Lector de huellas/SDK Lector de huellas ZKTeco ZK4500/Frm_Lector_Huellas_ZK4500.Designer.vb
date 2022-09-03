<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Lector_Huellas_ZK4500
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Lector_Huellas_ZK4500))
        Me.pictureBox1 = New System.Windows.Forms.PictureBox()
        Me.statusBar1 = New System.Windows.Forms.StatusBar()
        Me.statusbar0 = New System.Windows.Forms.StatusBarPanel()
        Me.btnBeep = New System.Windows.Forms.Button()
        Me.btnIdentify = New System.Windows.Forms.Button()
        Me.btnGreen = New System.Windows.Forms.Button()
        Me.btnVerify = New System.Windows.Forms.Button()
        Me.btnRed = New System.Windows.Forms.Button()
        Me.chkFakeFunOn = New System.Windows.Forms.CheckBox()
        Me.btnIdentifyByImage = New System.Windows.Forms.Button()
        Me.groupBox4 = New System.Windows.Forms.GroupBox()
        Me.radioButton2 = New System.Windows.Forms.RadioButton()
        Me.radioButton1 = New System.Windows.Forms.RadioButton()
        Me.btnRegByImage = New System.Windows.Forms.Button()
        Me.btnbrowse = New System.Windows.Forms.Button()
        Me.btnCloseSensor = New System.Windows.Forms.Button()
        Me.rdb10 = New System.Windows.Forms.RadioButton()
        Me.btnInitialSensor = New System.Windows.Forms.Button()
        Me.rdb9 = New System.Windows.Forms.RadioButton()
        Me.btnReg = New System.Windows.Forms.Button()
        Me.txtb5 = New System.Windows.Forms.TextBox()
        Me.txtb1 = New System.Windows.Forms.TextBox()
        Me.label6 = New System.Windows.Forms.Label()
        Me.label5 = New System.Windows.Forms.Label()
        Me.label4 = New System.Windows.Forms.Label()
        Me.txtb2 = New System.Windows.Forms.TextBox()
        Me.axZKFPEngX1 = New AxZKFPEngXControl.AxZKFPEngX()
        Me.saveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Btn_Verificar_Huella = New System.Windows.Forms.Button()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.statusbar0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox4.SuspendLayout()
        CType(Me.axZKFPEngX1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pictureBox1
        '
        Me.pictureBox1.BackColor = System.Drawing.Color.White
        Me.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pictureBox1.ForeColor = System.Drawing.Color.Black
        Me.pictureBox1.Location = New System.Drawing.Point(12, 6)
        Me.pictureBox1.Name = "pictureBox1"
        Me.pictureBox1.Size = New System.Drawing.Size(274, 372)
        Me.pictureBox1.TabIndex = 15
        Me.pictureBox1.TabStop = False
        '
        'statusBar1
        '
        Me.statusBar1.ForeColor = System.Drawing.Color.Black
        Me.statusBar1.Location = New System.Drawing.Point(0, 511)
        Me.statusBar1.Name = "statusBar1"
        Me.statusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.statusbar0})
        Me.statusBar1.ShowPanels = True
        Me.statusBar1.Size = New System.Drawing.Size(655, 26)
        Me.statusBar1.TabIndex = 16
        '
        'statusbar0
        '
        Me.statusbar0.Name = "statusbar0"
        Me.statusbar0.Text = "Estado:"
        Me.statusbar0.Width = 770
        '
        'btnBeep
        '
        Me.btnBeep.BackColor = System.Drawing.Color.White
        Me.btnBeep.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBeep.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBeep.ForeColor = System.Drawing.Color.Black
        Me.btnBeep.Location = New System.Drawing.Point(562, 356)
        Me.btnBeep.Name = "btnBeep"
        Me.btnBeep.Size = New System.Drawing.Size(72, 25)
        Me.btnBeep.TabIndex = 38
        Me.btnBeep.Text = "Beep"
        Me.btnBeep.UseVisualStyleBackColor = False
        '
        'btnIdentify
        '
        Me.btnIdentify.BackColor = System.Drawing.Color.White
        Me.btnIdentify.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIdentify.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnIdentify.ForeColor = System.Drawing.Color.Black
        Me.btnIdentify.Location = New System.Drawing.Point(514, 269)
        Me.btnIdentify.Name = "btnIdentify"
        Me.btnIdentify.Size = New System.Drawing.Size(118, 25)
        Me.btnIdentify.TabIndex = 39
        Me.btnIdentify.Text = "Identify 1 : N"
        Me.btnIdentify.UseVisualStyleBackColor = False
        '
        'btnGreen
        '
        Me.btnGreen.BackColor = System.Drawing.Color.White
        Me.btnGreen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGreen.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnGreen.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGreen.ForeColor = System.Drawing.Color.Black
        Me.btnGreen.Location = New System.Drawing.Point(435, 356)
        Me.btnGreen.Name = "btnGreen"
        Me.btnGreen.Size = New System.Drawing.Size(72, 25)
        Me.btnGreen.TabIndex = 36
        Me.btnGreen.Text = "VERDE"
        Me.btnGreen.UseVisualStyleBackColor = False
        '
        'btnVerify
        '
        Me.btnVerify.BackColor = System.Drawing.Color.White
        Me.btnVerify.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnVerify.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnVerify.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVerify.ForeColor = System.Drawing.Color.Black
        Me.btnVerify.Location = New System.Drawing.Point(312, 269)
        Me.btnVerify.Name = "btnVerify"
        Me.btnVerify.Size = New System.Drawing.Size(118, 25)
        Me.btnVerify.TabIndex = 27
        Me.btnVerify.Text = "Verificar 1 : 1"
        Me.btnVerify.UseVisualStyleBackColor = False
        '
        'btnRed
        '
        Me.btnRed.BackColor = System.Drawing.Color.White
        Me.btnRed.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRed.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnRed.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRed.ForeColor = System.Drawing.Color.Black
        Me.btnRed.Location = New System.Drawing.Point(312, 356)
        Me.btnRed.Name = "btnRed"
        Me.btnRed.Size = New System.Drawing.Size(72, 25)
        Me.btnRed.TabIndex = 35
        Me.btnRed.Text = "ROJO"
        Me.btnRed.UseVisualStyleBackColor = False
        '
        'chkFakeFunOn
        '
        Me.chkFakeFunOn.AutoSize = True
        Me.chkFakeFunOn.BackColor = System.Drawing.Color.White
        Me.chkFakeFunOn.ForeColor = System.Drawing.Color.Black
        Me.chkFakeFunOn.Location = New System.Drawing.Point(514, 232)
        Me.chkFakeFunOn.Name = "chkFakeFunOn"
        Me.chkFakeFunOn.Size = New System.Drawing.Size(86, 17)
        Me.chkFakeFunOn.TabIndex = 32
        Me.chkFakeFunOn.Text = "FakeFunOn"
        Me.chkFakeFunOn.UseVisualStyleBackColor = False
        '
        'btnIdentifyByImage
        '
        Me.btnIdentifyByImage.BackColor = System.Drawing.Color.White
        Me.btnIdentifyByImage.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIdentifyByImage.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnIdentifyByImage.ForeColor = System.Drawing.Color.Black
        Me.btnIdentifyByImage.Location = New System.Drawing.Point(516, 312)
        Me.btnIdentifyByImage.Name = "btnIdentifyByImage"
        Me.btnIdentifyByImage.Size = New System.Drawing.Size(118, 25)
        Me.btnIdentifyByImage.TabIndex = 33
        Me.btnIdentifyByImage.Text = "Identify by image"
        Me.btnIdentifyByImage.UseVisualStyleBackColor = False
        '
        'groupBox4
        '
        Me.groupBox4.BackColor = System.Drawing.Color.White
        Me.groupBox4.Controls.Add(Me.radioButton2)
        Me.groupBox4.Controls.Add(Me.radioButton1)
        Me.groupBox4.ForeColor = System.Drawing.Color.Black
        Me.groupBox4.Location = New System.Drawing.Point(514, 176)
        Me.groupBox4.Name = "groupBox4"
        Me.groupBox4.Size = New System.Drawing.Size(118, 39)
        Me.groupBox4.TabIndex = 34
        Me.groupBox4.TabStop = False
        Me.groupBox4.Text = "Format"
        '
        'radioButton2
        '
        Me.radioButton2.AutoSize = True
        Me.radioButton2.BackColor = System.Drawing.Color.White
        Me.radioButton2.Checked = True
        Me.radioButton2.ForeColor = System.Drawing.Color.Black
        Me.radioButton2.Location = New System.Drawing.Point(60, 15)
        Me.radioButton2.Name = "radioButton2"
        Me.radioButton2.Size = New System.Drawing.Size(43, 17)
        Me.radioButton2.TabIndex = 1
        Me.radioButton2.TabStop = True
        Me.radioButton2.Text = "JPG"
        Me.radioButton2.UseVisualStyleBackColor = False
        '
        'radioButton1
        '
        Me.radioButton1.AutoSize = True
        Me.radioButton1.BackColor = System.Drawing.Color.White
        Me.radioButton1.ForeColor = System.Drawing.Color.Black
        Me.radioButton1.Location = New System.Drawing.Point(6, 15)
        Me.radioButton1.Name = "radioButton1"
        Me.radioButton1.Size = New System.Drawing.Size(48, 17)
        Me.radioButton1.TabIndex = 1
        Me.radioButton1.Text = "BMP"
        Me.radioButton1.UseVisualStyleBackColor = False
        '
        'btnRegByImage
        '
        Me.btnRegByImage.BackColor = System.Drawing.Color.White
        Me.btnRegByImage.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRegByImage.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnRegByImage.ForeColor = System.Drawing.Color.Black
        Me.btnRegByImage.Location = New System.Drawing.Point(312, 312)
        Me.btnRegByImage.Name = "btnRegByImage"
        Me.btnRegByImage.Size = New System.Drawing.Size(118, 25)
        Me.btnRegByImage.TabIndex = 31
        Me.btnRegByImage.Text = "Register by image"
        Me.btnRegByImage.UseVisualStyleBackColor = False
        '
        'btnbrowse
        '
        Me.btnbrowse.BackColor = System.Drawing.Color.White
        Me.btnbrowse.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnbrowse.ForeColor = System.Drawing.Color.Black
        Me.btnbrowse.Location = New System.Drawing.Point(312, 182)
        Me.btnbrowse.Name = "btnbrowse"
        Me.btnbrowse.Size = New System.Drawing.Size(118, 23)
        Me.btnbrowse.TabIndex = 37
        Me.btnbrowse.Text = "SaveImage"
        Me.btnbrowse.UseVisualStyleBackColor = False
        '
        'btnCloseSensor
        '
        Me.btnCloseSensor.BackColor = System.Drawing.Color.White
        Me.btnCloseSensor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCloseSensor.Enabled = False
        Me.btnCloseSensor.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCloseSensor.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCloseSensor.ForeColor = System.Drawing.Color.Black
        Me.btnCloseSensor.Location = New System.Drawing.Point(514, 139)
        Me.btnCloseSensor.Name = "btnCloseSensor"
        Me.btnCloseSensor.Size = New System.Drawing.Size(118, 25)
        Me.btnCloseSensor.TabIndex = 30
        Me.btnCloseSensor.Text = "Desconectar Sensor"
        Me.btnCloseSensor.UseVisualStyleBackColor = False
        '
        'rdb10
        '
        Me.rdb10.AutoSize = True
        Me.rdb10.BackColor = System.Drawing.Color.White
        Me.rdb10.Checked = True
        Me.rdb10.ForeColor = System.Drawing.Color.Black
        Me.rdb10.Location = New System.Drawing.Point(514, 96)
        Me.rdb10.Name = "rdb10"
        Me.rdb10.Size = New System.Drawing.Size(94, 17)
        Me.rdb10.TabIndex = 22
        Me.rdb10.TabStop = True
        Me.rdb10.Text = "ZKFinger 10.0"
        Me.rdb10.UseVisualStyleBackColor = False
        '
        'btnInitialSensor
        '
        Me.btnInitialSensor.BackColor = System.Drawing.Color.White
        Me.btnInitialSensor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnInitialSensor.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnInitialSensor.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInitialSensor.ForeColor = System.Drawing.Color.Black
        Me.btnInitialSensor.Location = New System.Drawing.Point(312, 139)
        Me.btnInitialSensor.Name = "btnInitialSensor"
        Me.btnInitialSensor.Size = New System.Drawing.Size(118, 22)
        Me.btnInitialSensor.TabIndex = 21
        Me.btnInitialSensor.Text = "Conectar Sensor"
        Me.btnInitialSensor.UseVisualStyleBackColor = False
        '
        'rdb9
        '
        Me.rdb9.AutoSize = True
        Me.rdb9.BackColor = System.Drawing.Color.White
        Me.rdb9.ForeColor = System.Drawing.Color.Black
        Me.rdb9.Location = New System.Drawing.Point(312, 96)
        Me.rdb9.Name = "rdb9"
        Me.rdb9.Size = New System.Drawing.Size(88, 17)
        Me.rdb9.TabIndex = 20
        Me.rdb9.Text = "ZKFinger 9.0"
        Me.rdb9.UseVisualStyleBackColor = False
        '
        'btnReg
        '
        Me.btnReg.BackColor = System.Drawing.Color.White
        Me.btnReg.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnReg.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReg.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReg.ForeColor = System.Drawing.Color.Black
        Me.btnReg.Location = New System.Drawing.Point(312, 226)
        Me.btnReg.Name = "btnReg"
        Me.btnReg.Size = New System.Drawing.Size(118, 25)
        Me.btnReg.TabIndex = 19
        Me.btnReg.Text = "Registrar huella"
        Me.btnReg.UseVisualStyleBackColor = False
        '
        'txtb5
        '
        Me.txtb5.BackColor = System.Drawing.Color.White
        Me.txtb5.ForeColor = System.Drawing.Color.Black
        Me.txtb5.Location = New System.Drawing.Point(400, 49)
        Me.txtb5.Name = "txtb5"
        Me.txtb5.ReadOnly = True
        Me.txtb5.Size = New System.Drawing.Size(241, 22)
        Me.txtb5.TabIndex = 29
        '
        'txtb1
        '
        Me.txtb1.BackColor = System.Drawing.Color.White
        Me.txtb1.ForeColor = System.Drawing.Color.Black
        Me.txtb1.Location = New System.Drawing.Point(400, 5)
        Me.txtb1.Name = "txtb1"
        Me.txtb1.ReadOnly = True
        Me.txtb1.Size = New System.Drawing.Size(52, 22)
        Me.txtb1.TabIndex = 28
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.BackColor = System.Drawing.Color.White
        Me.label6.ForeColor = System.Drawing.Color.Black
        Me.label6.Location = New System.Drawing.Point(312, 52)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(79, 13)
        Me.label6.TabIndex = 26
        Me.label6.Text = "Serial Number"
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.BackColor = System.Drawing.Color.White
        Me.label5.ForeColor = System.Drawing.Color.Black
        Me.label5.Location = New System.Drawing.Point(514, 9)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(46, 13)
        Me.label5.TabIndex = 24
        Me.label5.Text = "Current"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.BackColor = System.Drawing.Color.White
        Me.label4.ForeColor = System.Drawing.Color.Black
        Me.label4.Location = New System.Drawing.Point(312, 9)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(77, 13)
        Me.label4.TabIndex = 23
        Me.label4.Text = "Sensor Count"
        '
        'txtb2
        '
        Me.txtb2.BackColor = System.Drawing.Color.White
        Me.txtb2.ForeColor = System.Drawing.Color.Black
        Me.txtb2.Location = New System.Drawing.Point(573, 5)
        Me.txtb2.Name = "txtb2"
        Me.txtb2.ReadOnly = True
        Me.txtb2.Size = New System.Drawing.Size(68, 22)
        Me.txtb2.TabIndex = 25
        '
        'axZKFPEngX1
        '
        Me.axZKFPEngX1.BackColor = System.Drawing.Color.White
        Me.axZKFPEngX1.Enabled = True
        Me.axZKFPEngX1.ForeColor = System.Drawing.Color.Black
        Me.axZKFPEngX1.Location = New System.Drawing.Point(462, 225)
        Me.axZKFPEngX1.Name = "axZKFPEngX1"
        Me.axZKFPEngX1.OcxState = CType(resources.GetObject("axZKFPEngX1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.axZKFPEngX1.Size = New System.Drawing.Size(24, 24)
        Me.axZKFPEngX1.TabIndex = 40
        '
        'openFileDialog1
        '
        Me.openFileDialog1.FileName = "openFileDialog1"
        '
        'Btn_Verificar_Huella
        '
        Me.Btn_Verificar_Huella.BackColor = System.Drawing.Color.White
        Me.Btn_Verificar_Huella.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_Verificar_Huella.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Btn_Verificar_Huella.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Verificar_Huella.ForeColor = System.Drawing.Color.Black
        Me.Btn_Verificar_Huella.Location = New System.Drawing.Point(12, 437)
        Me.Btn_Verificar_Huella.Name = "Btn_Verificar_Huella"
        Me.Btn_Verificar_Huella.Size = New System.Drawing.Size(118, 25)
        Me.Btn_Verificar_Huella.TabIndex = 41
        Me.Btn_Verificar_Huella.Text = "Verificar Huella"
        Me.Btn_Verificar_Huella.UseVisualStyleBackColor = False
        '
        'Frm_Lector_Huellas_ZK4500
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(655, 537)
        Me.Controls.Add(Me.Btn_Verificar_Huella)
        Me.Controls.Add(Me.axZKFPEngX1)
        Me.Controls.Add(Me.btnBeep)
        Me.Controls.Add(Me.btnIdentify)
        Me.Controls.Add(Me.btnGreen)
        Me.Controls.Add(Me.btnVerify)
        Me.Controls.Add(Me.btnRed)
        Me.Controls.Add(Me.chkFakeFunOn)
        Me.Controls.Add(Me.btnIdentifyByImage)
        Me.Controls.Add(Me.groupBox4)
        Me.Controls.Add(Me.btnRegByImage)
        Me.Controls.Add(Me.btnbrowse)
        Me.Controls.Add(Me.btnCloseSensor)
        Me.Controls.Add(Me.rdb10)
        Me.Controls.Add(Me.btnInitialSensor)
        Me.Controls.Add(Me.rdb9)
        Me.Controls.Add(Me.btnReg)
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
        Me.Name = "Frm_Lector_Huellas_ZK4500"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SENSOR DE HUELLAS DACTILARES"
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.statusbar0, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupBox4.ResumeLayout(False)
        Me.groupBox4.PerformLayout()
        CType(Me.axZKFPEngX1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents pictureBox1 As PictureBox
    Private WithEvents statusBar1 As StatusBar
    Private WithEvents statusbar0 As StatusBarPanel
    Private WithEvents btnBeep As Button
    Private WithEvents btnIdentify As Button
    Private WithEvents btnGreen As Button
    Private WithEvents btnVerify As Button
    Private WithEvents btnRed As Button
    Private WithEvents chkFakeFunOn As CheckBox
    Private WithEvents btnIdentifyByImage As Button
    Private WithEvents groupBox4 As GroupBox
    Private WithEvents radioButton2 As RadioButton
    Private WithEvents radioButton1 As RadioButton
    Private WithEvents btnRegByImage As Button
    Private WithEvents btnbrowse As Button
    Private WithEvents btnCloseSensor As Button
    Private WithEvents rdb10 As RadioButton
    Private WithEvents btnInitialSensor As Button
    Private WithEvents rdb9 As RadioButton
    Private WithEvents btnReg As Button
    Private WithEvents txtb5 As TextBox
    Private WithEvents txtb1 As TextBox
    Private WithEvents label6 As Label
    Private WithEvents label5 As Label
    Private WithEvents label4 As Label
    Private WithEvents txtb2 As TextBox
    Private WithEvents axZKFPEngX1 As AxZKFPEngXControl.AxZKFPEngX
    Private WithEvents saveFileDialog1 As SaveFileDialog
    Private WithEvents openFileDialog1 As OpenFileDialog
    Private WithEvents Btn_Verificar_Huella As Button
End Class
