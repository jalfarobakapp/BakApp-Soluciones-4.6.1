<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Transbank
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
        Me.Lbl_Status = New System.Windows.Forms.Label
        Me.Txt_Respuesta_Transbank_Decodificada = New System.Windows.Forms.TextBox
        Me.Txt_Respuesta_Transbank_Codificada = New System.Windows.Forms.TextBox
        Me.Txt_Requirimiento = New System.Windows.Forms.TextBox
        Me.cmdClose = New System.Windows.Forms.Button
        Me.groupBox3 = New System.Windows.Forms.GroupBox
        Me.rdoText = New System.Windows.Forms.RadioButton
        Me.rdoHex = New System.Windows.Forms.RadioButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdSend = New System.Windows.Forms.Button
        Me.txtSend = New System.Windows.Forms.TextBox
        Me.rtbDisplay = New System.Windows.Forms.RichTextBox
        Me.groupBox2 = New System.Windows.Forms.GroupBox
        Me.label5 = New System.Windows.Forms.Label
        Me.cboData = New System.Windows.Forms.ComboBox
        Me.label4 = New System.Windows.Forms.Label
        Me.cboStop = New System.Windows.Forms.ComboBox
        Me.label3 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.cboParity = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboBaud = New System.Windows.Forms.ComboBox
        Me.cboPort = New System.Windows.Forms.ComboBox
        Me.cmdOpen = New System.Windows.Forms.Button
        Me.groupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Lbl_Status
        '
        Me.Lbl_Status.AutoSize = True
        Me.Lbl_Status.BackColor = System.Drawing.Color.White
        Me.Lbl_Status.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Status.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Status.Location = New System.Drawing.Point(12, 559)
        Me.Lbl_Status.Name = "Lbl_Status"
        Me.Lbl_Status.Size = New System.Drawing.Size(337, 29)
        Me.Lbl_Status.TabIndex = 73
        Me.Lbl_Status.Text = "TRADUCCION DESDE TRANSBANK"
        '
        'Txt_Respuesta_Transbank_Decodificada
        '
        Me.Txt_Respuesta_Transbank_Decodificada.BackColor = System.Drawing.Color.White
        Me.Txt_Respuesta_Transbank_Decodificada.Font = New System.Drawing.Font("Comic Sans MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Respuesta_Transbank_Decodificada.ForeColor = System.Drawing.Color.Black
        Me.Txt_Respuesta_Transbank_Decodificada.Location = New System.Drawing.Point(12, 459)
        Me.Txt_Respuesta_Transbank_Decodificada.Multiline = True
        Me.Txt_Respuesta_Transbank_Decodificada.Name = "Txt_Respuesta_Transbank_Decodificada"
        Me.Txt_Respuesta_Transbank_Decodificada.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.Txt_Respuesta_Transbank_Decodificada.Size = New System.Drawing.Size(662, 87)
        Me.Txt_Respuesta_Transbank_Decodificada.TabIndex = 72
        '
        'Txt_Respuesta_Transbank_Codificada
        '
        Me.Txt_Respuesta_Transbank_Codificada.BackColor = System.Drawing.Color.White
        Me.Txt_Respuesta_Transbank_Codificada.Font = New System.Drawing.Font("Comic Sans MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Respuesta_Transbank_Codificada.ForeColor = System.Drawing.Color.Black
        Me.Txt_Respuesta_Transbank_Codificada.Location = New System.Drawing.Point(12, 394)
        Me.Txt_Respuesta_Transbank_Codificada.Multiline = True
        Me.Txt_Respuesta_Transbank_Codificada.Name = "Txt_Respuesta_Transbank_Codificada"
        Me.Txt_Respuesta_Transbank_Codificada.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.Txt_Respuesta_Transbank_Codificada.Size = New System.Drawing.Size(662, 44)
        Me.Txt_Respuesta_Transbank_Codificada.TabIndex = 71
        '
        'Txt_Requirimiento
        '
        Me.Txt_Requirimiento.BackColor = System.Drawing.Color.White
        Me.Txt_Requirimiento.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Requirimiento.ForeColor = System.Drawing.Color.Black
        Me.Txt_Requirimiento.Location = New System.Drawing.Point(12, 340)
        Me.Txt_Requirimiento.Multiline = True
        Me.Txt_Requirimiento.Name = "Txt_Requirimiento"
        Me.Txt_Requirimiento.Size = New System.Drawing.Size(662, 33)
        Me.Txt_Requirimiento.TabIndex = 70
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.Color.White
        Me.cmdClose.ForeColor = System.Drawing.Color.Black
        Me.cmdClose.Location = New System.Drawing.Point(468, 296)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(100, 23)
        Me.cmdClose.TabIndex = 66
        Me.cmdClose.Text = "Close Port"
        Me.cmdClose.UseVisualStyleBackColor = False
        '
        'groupBox3
        '
        Me.groupBox3.BackColor = System.Drawing.Color.White
        Me.groupBox3.Controls.Add(Me.rdoText)
        Me.groupBox3.Controls.Add(Me.rdoHex)
        Me.groupBox3.ForeColor = System.Drawing.Color.Black
        Me.groupBox3.Location = New System.Drawing.Point(574, 230)
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.Size = New System.Drawing.Size(100, 60)
        Me.groupBox3.TabIndex = 68
        Me.groupBox3.TabStop = False
        Me.groupBox3.Text = "Mode"
        '
        'rdoText
        '
        Me.rdoText.AutoSize = True
        Me.rdoText.BackColor = System.Drawing.Color.White
        Me.rdoText.ForeColor = System.Drawing.Color.Black
        Me.rdoText.Location = New System.Drawing.Point(6, 38)
        Me.rdoText.Name = "rdoText"
        Me.rdoText.Size = New System.Drawing.Size(44, 17)
        Me.rdoText.TabIndex = 1
        Me.rdoText.TabStop = True
        Me.rdoText.Text = "Text"
        Me.rdoText.UseVisualStyleBackColor = False
        '
        'rdoHex
        '
        Me.rdoHex.AutoSize = True
        Me.rdoHex.BackColor = System.Drawing.Color.White
        Me.rdoHex.ForeColor = System.Drawing.Color.Black
        Me.rdoHex.Location = New System.Drawing.Point(6, 16)
        Me.rdoHex.Name = "rdoHex"
        Me.rdoHex.Size = New System.Drawing.Size(44, 17)
        Me.rdoHex.TabIndex = 0
        Me.rdoHex.TabStop = True
        Me.rdoHex.Text = "Hex"
        Me.rdoHex.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.cmdSend)
        Me.GroupBox1.Controls.Add(Me.txtSend)
        Me.GroupBox1.Controls.Add(Me.rtbDisplay)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(12, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(556, 288)
        Me.GroupBox1.TabIndex = 65
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Serial Port Communication"
        '
        'cmdSend
        '
        Me.cmdSend.BackColor = System.Drawing.Color.White
        Me.cmdSend.ForeColor = System.Drawing.Color.Black
        Me.cmdSend.Location = New System.Drawing.Point(475, 259)
        Me.cmdSend.Name = "cmdSend"
        Me.cmdSend.Size = New System.Drawing.Size(75, 23)
        Me.cmdSend.TabIndex = 5
        Me.cmdSend.Text = "Send"
        Me.cmdSend.UseVisualStyleBackColor = False
        '
        'txtSend
        '
        Me.txtSend.BackColor = System.Drawing.Color.White
        Me.txtSend.ForeColor = System.Drawing.Color.Black
        Me.txtSend.Location = New System.Drawing.Point(7, 259)
        Me.txtSend.Name = "txtSend"
        Me.txtSend.Size = New System.Drawing.Size(454, 22)
        Me.txtSend.TabIndex = 4
        '
        'rtbDisplay
        '
        Me.rtbDisplay.BackColor = System.Drawing.Color.White
        Me.rtbDisplay.ForeColor = System.Drawing.Color.Black
        Me.rtbDisplay.Location = New System.Drawing.Point(7, 19)
        Me.rtbDisplay.Name = "rtbDisplay"
        Me.rtbDisplay.Size = New System.Drawing.Size(543, 234)
        Me.rtbDisplay.TabIndex = 3
        Me.rtbDisplay.Text = ""
        '
        'groupBox2
        '
        Me.groupBox2.BackColor = System.Drawing.Color.White
        Me.groupBox2.Controls.Add(Me.label5)
        Me.groupBox2.Controls.Add(Me.cboData)
        Me.groupBox2.Controls.Add(Me.label4)
        Me.groupBox2.Controls.Add(Me.cboStop)
        Me.groupBox2.Controls.Add(Me.label3)
        Me.groupBox2.Controls.Add(Me.label2)
        Me.groupBox2.Controls.Add(Me.cboParity)
        Me.groupBox2.Controls.Add(Me.Label1)
        Me.groupBox2.Controls.Add(Me.cboBaud)
        Me.groupBox2.Controls.Add(Me.cboPort)
        Me.groupBox2.ForeColor = System.Drawing.Color.Black
        Me.groupBox2.Location = New System.Drawing.Point(578, 3)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(96, 221)
        Me.groupBox2.TabIndex = 67
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Options"
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.BackColor = System.Drawing.Color.White
        Me.label5.ForeColor = System.Drawing.Color.Black
        Me.label5.Location = New System.Drawing.Point(6, 179)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(53, 13)
        Me.label5.TabIndex = 19
        Me.label5.Text = "Data Bits"
        '
        'cboData
        '
        Me.cboData.BackColor = System.Drawing.Color.White
        Me.cboData.ForeColor = System.Drawing.Color.Black
        Me.cboData.FormattingEnabled = True
        Me.cboData.Items.AddRange(New Object() {"7", "8", "9"})
        Me.cboData.Location = New System.Drawing.Point(9, 195)
        Me.cboData.Name = "cboData"
        Me.cboData.Size = New System.Drawing.Size(76, 21)
        Me.cboData.TabIndex = 14
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.BackColor = System.Drawing.Color.White
        Me.label4.ForeColor = System.Drawing.Color.Black
        Me.label4.Location = New System.Drawing.Point(7, 139)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(53, 13)
        Me.label4.TabIndex = 18
        Me.label4.Text = "Stop Bits"
        '
        'cboStop
        '
        Me.cboStop.BackColor = System.Drawing.Color.White
        Me.cboStop.ForeColor = System.Drawing.Color.Black
        Me.cboStop.FormattingEnabled = True
        Me.cboStop.Location = New System.Drawing.Point(9, 155)
        Me.cboStop.Name = "cboStop"
        Me.cboStop.Size = New System.Drawing.Size(76, 21)
        Me.cboStop.TabIndex = 13
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.BackColor = System.Drawing.Color.White
        Me.label3.ForeColor = System.Drawing.Color.Black
        Me.label3.Location = New System.Drawing.Point(6, 98)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(35, 13)
        Me.label3.TabIndex = 17
        Me.label3.Text = "Parity"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.BackColor = System.Drawing.Color.White
        Me.label2.ForeColor = System.Drawing.Color.Black
        Me.label2.Location = New System.Drawing.Point(6, 58)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(60, 13)
        Me.label2.TabIndex = 16
        Me.label2.Text = "Baud Rate"
        '
        'cboParity
        '
        Me.cboParity.BackColor = System.Drawing.Color.White
        Me.cboParity.ForeColor = System.Drawing.Color.Black
        Me.cboParity.FormattingEnabled = True
        Me.cboParity.Location = New System.Drawing.Point(9, 114)
        Me.cboParity.Name = "cboParity"
        Me.cboParity.Size = New System.Drawing.Size(76, 21)
        Me.cboParity.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(6, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Port"
        '
        'cboBaud
        '
        Me.cboBaud.BackColor = System.Drawing.Color.White
        Me.cboBaud.ForeColor = System.Drawing.Color.Black
        Me.cboBaud.FormattingEnabled = True
        Me.cboBaud.Items.AddRange(New Object() {"300", "600", "1200", "2400", "4800", "9600", "14400", "28800", "36000", "115000"})
        Me.cboBaud.Location = New System.Drawing.Point(9, 74)
        Me.cboBaud.Name = "cboBaud"
        Me.cboBaud.Size = New System.Drawing.Size(76, 21)
        Me.cboBaud.TabIndex = 11
        '
        'cboPort
        '
        Me.cboPort.BackColor = System.Drawing.Color.White
        Me.cboPort.ForeColor = System.Drawing.Color.Black
        Me.cboPort.FormattingEnabled = True
        Me.cboPort.Location = New System.Drawing.Point(9, 34)
        Me.cboPort.Name = "cboPort"
        Me.cboPort.Size = New System.Drawing.Size(76, 21)
        Me.cboPort.TabIndex = 10
        '
        'cmdOpen
        '
        Me.cmdOpen.BackColor = System.Drawing.Color.White
        Me.cmdOpen.ForeColor = System.Drawing.Color.Black
        Me.cmdOpen.Location = New System.Drawing.Point(574, 296)
        Me.cmdOpen.Name = "cmdOpen"
        Me.cmdOpen.Size = New System.Drawing.Size(100, 23)
        Me.cmdOpen.TabIndex = 69
        Me.cmdOpen.Text = "Open Port"
        Me.cmdOpen.UseVisualStyleBackColor = False
        '
        'Frm_Transbank
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(693, 606)
        Me.Controls.Add(Me.Lbl_Status)
        Me.Controls.Add(Me.Txt_Respuesta_Transbank_Decodificada)
        Me.Controls.Add(Me.Txt_Respuesta_Transbank_Codificada)
        Me.Controls.Add(Me.Txt_Requirimiento)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.groupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.cmdOpen)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Transbank"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        Me.groupBox3.ResumeLayout(False)
        Me.groupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Lbl_Status As System.Windows.Forms.Label
    Friend WithEvents Txt_Respuesta_Transbank_Decodificada As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Respuesta_Transbank_Codificada As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Requirimiento As System.Windows.Forms.TextBox
    Private WithEvents cmdClose As System.Windows.Forms.Button
    Private WithEvents groupBox3 As System.Windows.Forms.GroupBox
    Private WithEvents rdoText As System.Windows.Forms.RadioButton
    Private WithEvents rdoHex As System.Windows.Forms.RadioButton
    Private WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents cmdSend As System.Windows.Forms.Button
    Private WithEvents txtSend As System.Windows.Forms.TextBox
    Private WithEvents rtbDisplay As System.Windows.Forms.RichTextBox
    Private WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents cboData As System.Windows.Forms.ComboBox
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents cboStop As System.Windows.Forms.ComboBox
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents cboParity As System.Windows.Forms.ComboBox
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents cboBaud As System.Windows.Forms.ComboBox
    Private WithEvents cboPort As System.Windows.Forms.ComboBox
    Private WithEvents cmdOpen As System.Windows.Forms.Button
End Class
