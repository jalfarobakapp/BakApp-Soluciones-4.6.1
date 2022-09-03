<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Huellas_U4500
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim QuitButton As System.Windows.Forms.Button
        Dim gbEnrollment As System.Windows.Forms.GroupBox
        Dim gbEventHandlerStatus As System.Windows.Forms.GroupBox
        Dim lblMaxFingers As System.Windows.Forms.Label
        Dim lblMask As System.Windows.Forms.Label
        Dim gbVerification As System.Windows.Forms.GroupBox
        Dim gbReturnValues As System.Windows.Forms.GroupBox
        Dim lblFalseAcceptRate As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Huellas_U4500))
        Me.Button2 = New System.Windows.Forms.Button()
        Me.MaxFingers = New System.Windows.Forms.NumericUpDown()
        Me.Mask = New System.Windows.Forms.NumericUpDown()
        Me.EnrollButton = New System.Windows.Forms.Button()
        Me.IsFailure = New System.Windows.Forms.RadioButton()
        Me.IsSuccess = New System.Windows.Forms.RadioButton()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.VerifyButton = New System.Windows.Forms.Button()
        Me.FalseAcceptRate = New System.Windows.Forms.TextBox()
        Me.IsFeatureSetMatched = New System.Windows.Forms.CheckBox()
        Me.ToolTips = New System.Windows.Forms.ToolTip(Me.components)
        Me.ReflectionImage1 = New DevComponents.DotNetBar.Controls.ReflectionImage()
        QuitButton = New System.Windows.Forms.Button()
        gbEnrollment = New System.Windows.Forms.GroupBox()
        gbEventHandlerStatus = New System.Windows.Forms.GroupBox()
        lblMaxFingers = New System.Windows.Forms.Label()
        lblMask = New System.Windows.Forms.Label()
        gbVerification = New System.Windows.Forms.GroupBox()
        gbReturnValues = New System.Windows.Forms.GroupBox()
        lblFalseAcceptRate = New System.Windows.Forms.Label()
        gbEnrollment.SuspendLayout()
        CType(Me.MaxFingers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Mask, System.ComponentModel.ISupportInitialize).BeginInit()
        gbEventHandlerStatus.SuspendLayout()
        gbVerification.SuspendLayout()
        gbReturnValues.SuspendLayout()
        Me.SuspendLayout()
        '
        'QuitButton
        '
        QuitButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        QuitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        QuitButton.Location = New System.Drawing.Point(163, 136)
        QuitButton.Name = "QuitButton"
        QuitButton.Size = New System.Drawing.Size(75, 23)
        QuitButton.TabIndex = 2
        QuitButton.Text = "Salir"
        Me.ToolTips.SetToolTip(QuitButton, "Close the sample application")
        QuitButton.UseVisualStyleBackColor = True
        AddHandler QuitButton.Click, AddressOf Me.QuitButton_Click
        '
        'gbEnrollment
        '
        gbEnrollment.Controls.Add(Me.MaxFingers)
        gbEnrollment.Controls.Add(Me.Mask)
        gbEnrollment.Controls.Add(Me.EnrollButton)
        gbEnrollment.Controls.Add(gbEventHandlerStatus)
        gbEnrollment.Controls.Add(lblMaxFingers)
        gbEnrollment.Controls.Add(lblMask)
        gbEnrollment.Location = New System.Drawing.Point(261, 12)
        gbEnrollment.Name = "gbEnrollment"
        gbEnrollment.Size = New System.Drawing.Size(266, 201)
        gbEnrollment.TabIndex = 0
        gbEnrollment.TabStop = False
        gbEnrollment.Text = "Inscripción"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(12, 21)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(145, 23)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Inscribir huellas digitales"
        Me.ToolTips.SetToolTip(Me.Button2, "Start fingerprint enrollment")
        Me.Button2.UseVisualStyleBackColor = True
        '
        'MaxFingers
        '
        Me.MaxFingers.Enabled = False
        Me.MaxFingers.Location = New System.Drawing.Point(160, 52)
        Me.MaxFingers.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.MaxFingers.Name = "MaxFingers"
        Me.MaxFingers.Size = New System.Drawing.Size(94, 20)
        Me.MaxFingers.TabIndex = 3
        Me.ToolTips.SetToolTip(Me.MaxFingers, "Enter a number from 1 to 10")
        Me.MaxFingers.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Mask
        '
        Me.Mask.Enabled = False
        Me.Mask.Location = New System.Drawing.Point(160, 26)
        Me.Mask.Maximum = New Decimal(New Integer() {1023, 0, 0, 0})
        Me.Mask.Name = "Mask"
        Me.Mask.Size = New System.Drawing.Size(94, 20)
        Me.Mask.TabIndex = 1
        Me.ToolTips.SetToolTip(Me.Mask, "Enter a number from 0 to 1023")
        '
        'EnrollButton
        '
        Me.EnrollButton.Location = New System.Drawing.Point(35, 174)
        Me.EnrollButton.Name = "EnrollButton"
        Me.EnrollButton.Size = New System.Drawing.Size(181, 23)
        Me.EnrollButton.TabIndex = 5
        Me.EnrollButton.Text = "Inscribir huellas digitales Old"
        Me.ToolTips.SetToolTip(Me.EnrollButton, "Start fingerprint enrollment")
        Me.EnrollButton.UseVisualStyleBackColor = True
        Me.EnrollButton.Visible = False
        '
        'gbEventHandlerStatus
        '
        gbEventHandlerStatus.Controls.Add(Me.IsFailure)
        gbEventHandlerStatus.Controls.Add(Me.IsSuccess)
        gbEventHandlerStatus.Enabled = False
        gbEventHandlerStatus.Location = New System.Drawing.Point(9, 79)
        gbEventHandlerStatus.Name = "gbEventHandlerStatus"
        gbEventHandlerStatus.Size = New System.Drawing.Size(251, 60)
        gbEventHandlerStatus.TabIndex = 4
        gbEventHandlerStatus.TabStop = False
        gbEventHandlerStatus.Text = "Estado del controlador de eventos"
        '
        'IsFailure
        '
        Me.IsFailure.AutoSize = True
        Me.IsFailure.Location = New System.Drawing.Point(151, 29)
        Me.IsFailure.Name = "IsFailure"
        Me.IsFailure.Size = New System.Drawing.Size(63, 17)
        Me.IsFailure.TabIndex = 1
        Me.IsFailure.Text = "Fracaso"
        Me.ToolTips.SetToolTip(Me.IsFailure, "Force an enrollment failure")
        Me.IsFailure.UseVisualStyleBackColor = True
        '
        'IsSuccess
        '
        Me.IsSuccess.AutoSize = True
        Me.IsSuccess.Checked = True
        Me.IsSuccess.Location = New System.Drawing.Point(26, 29)
        Me.IsSuccess.Name = "IsSuccess"
        Me.IsSuccess.Size = New System.Drawing.Size(48, 17)
        Me.IsSuccess.TabIndex = 0
        Me.IsSuccess.TabStop = True
        Me.IsSuccess.Text = "Éxito"
        Me.ToolTips.SetToolTip(Me.IsSuccess, "Allow a successful enrollment")
        Me.IsSuccess.UseVisualStyleBackColor = True
        '
        'lblMaxFingers
        '
        lblMaxFingers.Location = New System.Drawing.Point(6, 53)
        lblMaxFingers.Name = "lblMaxFingers"
        lblMaxFingers.Size = New System.Drawing.Size(148, 20)
        lblMaxFingers.TabIndex = 2
        lblMaxFingers.Text = "Max. conteo de dedos inscritos"
        lblMaxFingers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMask
        '
        lblMask.Location = New System.Drawing.Point(6, 27)
        lblMask.Name = "lblMask"
        lblMask.Size = New System.Drawing.Size(148, 20)
        lblMask.TabIndex = 0
        lblMask.Text = "Máscara de huellas dactilares"
        lblMask.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gbVerification
        '
        gbVerification.Controls.Add(Me.VerifyButton)
        gbVerification.Controls.Add(gbReturnValues)
        gbVerification.Location = New System.Drawing.Point(261, 231)
        gbVerification.Name = "gbVerification"
        gbVerification.Size = New System.Drawing.Size(266, 205)
        gbVerification.TabIndex = 1
        gbVerification.TabStop = False
        gbVerification.Text = "Verificación"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 64)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(145, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Verificar huellas digitales"
        Me.ToolTips.SetToolTip(Me.Button1, "Start fingerprint verification")
        Me.Button1.UseVisualStyleBackColor = True
        '
        'VerifyButton
        '
        Me.VerifyButton.Location = New System.Drawing.Point(35, 176)
        Me.VerifyButton.Name = "VerifyButton"
        Me.VerifyButton.Size = New System.Drawing.Size(181, 23)
        Me.VerifyButton.TabIndex = 1
        Me.VerifyButton.Text = "Verificar huellas digitales Old"
        Me.ToolTips.SetToolTip(Me.VerifyButton, "Start fingerprint verification")
        Me.VerifyButton.UseVisualStyleBackColor = True
        Me.VerifyButton.Visible = False
        '
        'gbReturnValues
        '
        gbReturnValues.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        gbReturnValues.Controls.Add(Me.FalseAcceptRate)
        gbReturnValues.Controls.Add(lblFalseAcceptRate)
        gbReturnValues.Controls.Add(Me.IsFeatureSetMatched)
        gbReturnValues.Location = New System.Drawing.Point(9, 40)
        gbReturnValues.Name = "gbReturnValues"
        gbReturnValues.Size = New System.Drawing.Size(251, 100)
        gbReturnValues.TabIndex = 0
        gbReturnValues.TabStop = False
        gbReturnValues.Text = "Return values"
        '
        'FalseAcceptRate
        '
        Me.FalseAcceptRate.Location = New System.Drawing.Point(132, 62)
        Me.FalseAcceptRate.Name = "FalseAcceptRate"
        Me.FalseAcceptRate.ReadOnly = True
        Me.FalseAcceptRate.Size = New System.Drawing.Size(113, 20)
        Me.FalseAcceptRate.TabIndex = 2
        Me.ToolTips.SetToolTip(Me.FalseAcceptRate, "Displays the false accept rate (FAR)")
        '
        'lblFalseAcceptRate
        '
        lblFalseAcceptRate.Location = New System.Drawing.Point(6, 62)
        lblFalseAcceptRate.Name = "lblFalseAcceptRate"
        lblFalseAcceptRate.Size = New System.Drawing.Size(120, 20)
        lblFalseAcceptRate.TabIndex = 1
        lblFalseAcceptRate.Text = "Tasa de aceptación falsa"
        lblFalseAcceptRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'IsFeatureSetMatched
        '
        Me.IsFeatureSetMatched.AutoCheck = False
        Me.IsFeatureSetMatched.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.IsFeatureSetMatched.Location = New System.Drawing.Point(6, 32)
        Me.IsFeatureSetMatched.Name = "IsFeatureSetMatched"
        Me.IsFeatureSetMatched.Size = New System.Drawing.Size(201, 24)
        Me.IsFeatureSetMatched.TabIndex = 0
        Me.IsFeatureSetMatched.Text = "¿El conjunto de funciones coincide?"
        Me.ToolTips.SetToolTip(Me.IsFeatureSetMatched, "Displays a match result")
        Me.IsFeatureSetMatched.UseVisualStyleBackColor = True
        '
        'ReflectionImage1
        '
        Me.ReflectionImage1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.ReflectionImage1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionImage1.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.ReflectionImage1.ForeColor = System.Drawing.Color.Black
        Me.ReflectionImage1.Image = CType(resources.GetObject("ReflectionImage1.Image"), System.Drawing.Image)
        Me.ReflectionImage1.Location = New System.Drawing.Point(163, 21)
        Me.ReflectionImage1.Name = "ReflectionImage1"
        Me.ReflectionImage1.Size = New System.Drawing.Size(77, 116)
        Me.ReflectionImage1.TabIndex = 134
        '
        'Frm_Huellas_U4500
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = QuitButton
        Me.ClientSize = New System.Drawing.Size(249, 171)
        Me.Controls.Add(Me.ReflectionImage1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(QuitButton)
        Me.Controls.Add(gbEnrollment)
        Me.Controls.Add(gbVerification)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Huellas_U4500"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "INSCRIPCION DE HUELLA"
        gbEnrollment.ResumeLayout(False)
        CType(Me.MaxFingers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Mask, System.ComponentModel.ISupportInitialize).EndInit()
        gbEventHandlerStatus.ResumeLayout(False)
        gbEventHandlerStatus.PerformLayout()
        gbVerification.ResumeLayout(False)
        gbReturnValues.ResumeLayout(False)
        gbReturnValues.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents EnrollButton As System.Windows.Forms.Button
    Private WithEvents IsFailure As System.Windows.Forms.RadioButton
    Private WithEvents IsSuccess As System.Windows.Forms.RadioButton
	Private WithEvents VerifyButton As System.Windows.Forms.Button
    Private WithEvents FalseAcceptRate As System.Windows.Forms.TextBox
	Private WithEvents IsFeatureSetMatched As System.Windows.Forms.CheckBox
	Friend WithEvents MaxFingers As System.Windows.Forms.NumericUpDown
	Friend WithEvents Mask As System.Windows.Forms.NumericUpDown
	Friend WithEvents ToolTips As System.Windows.Forms.ToolTip
    Private WithEvents Button1 As Button
    Private WithEvents Button2 As Button
    Friend WithEvents ReflectionImage1 As DevComponents.DotNetBar.Controls.ReflectionImage
End Class
