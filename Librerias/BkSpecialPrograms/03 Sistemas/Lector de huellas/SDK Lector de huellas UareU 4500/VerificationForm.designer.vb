<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VerificationForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VerificationForm))
        Me.VerificationControl = New DPFP.Gui.Verification.VerificationControl()
        Me.CircularProgress1 = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.Tiempo = New System.Windows.Forms.Timer(Me.components)
        Me.Btn_Cerrar = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Grabar_Sin_Lector = New DevComponents.DotNetBar.ButtonX()
        Me.Lbl_Estatus = New System.Windows.Forms.Label()
        Me.Tiempo2 = New System.Windows.Forms.Timer(Me.components)
        Me.Tiempo3 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'VerificationControl
        '
        Me.VerificationControl.Active = True
        Me.VerificationControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.VerificationControl.Location = New System.Drawing.Point(13, 17)
        Me.VerificationControl.Name = "VerificationControl"
        Me.VerificationControl.ReaderSerialNumber = "00000000-0000-0000-0000-000000000000"
        Me.VerificationControl.Size = New System.Drawing.Size(48, 47)
        Me.VerificationControl.TabIndex = 6
        '
        'CircularProgress1
        '
        '
        '
        '
        Me.CircularProgress1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CircularProgress1.Location = New System.Drawing.Point(328, 17)
        Me.CircularProgress1.Name = "CircularProgress1"
        Me.CircularProgress1.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Dot
        Me.CircularProgress1.ProgressColor = System.Drawing.Color.CornflowerBlue
        Me.CircularProgress1.Size = New System.Drawing.Size(49, 36)
        Me.CircularProgress1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.CircularProgress1.TabIndex = 7
        '
        'Tiempo
        '
        Me.Tiempo.Interval = 5000
        '
        'Btn_Cerrar
        '
        Me.Btn_Cerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Cerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Cerrar.Location = New System.Drawing.Point(302, 71)
        Me.Btn_Cerrar.Name = "Btn_Cerrar"
        Me.Btn_Cerrar.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Cerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Cerrar.TabIndex = 9
        Me.Btn_Cerrar.Text = "Cerrar"
        '
        'Btn_Grabar_Sin_Lector
        '
        Me.Btn_Grabar_Sin_Lector.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Grabar_Sin_Lector.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Grabar_Sin_Lector.Location = New System.Drawing.Point(194, 71)
        Me.Btn_Grabar_Sin_Lector.Name = "Btn_Grabar_Sin_Lector"
        Me.Btn_Grabar_Sin_Lector.Size = New System.Drawing.Size(102, 23)
        Me.Btn_Grabar_Sin_Lector.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Grabar_Sin_Lector.TabIndex = 10
        Me.Btn_Grabar_Sin_Lector.Text = "Grabar sin huella"
        '
        'Lbl_Estatus
        '
        Me.Lbl_Estatus.Location = New System.Drawing.Point(67, 17)
        Me.Lbl_Estatus.Name = "Lbl_Estatus"
        Me.Lbl_Estatus.Size = New System.Drawing.Size(255, 37)
        Me.Lbl_Estatus.TabIndex = 11
        Me.Lbl_Estatus.Text = "Para verificar su identidad, toque el lector de huellas digitales con cualquier d" &
    "edo registrado." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Tiempo2
        '
        Me.Tiempo2.Interval = 5000
        '
        'Tiempo3
        '
        Me.Tiempo3.Interval = 1000
        '
        'VerificationForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(389, 105)
        Me.Controls.Add(Me.Lbl_Estatus)
        Me.Controls.Add(Me.Btn_Grabar_Sin_Lector)
        Me.Controls.Add(Me.Btn_Cerrar)
        Me.Controls.Add(Me.CircularProgress1)
        Me.Controls.Add(Me.VerificationControl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "VerificationForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Verify Your Identity"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CircularProgress1 As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Tiempo As Timer
    Friend WithEvents Btn_Cerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Grabar_Sin_Lector As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Lbl_Estatus As Label
    Friend WithEvents Tiempo2 As Timer
    Friend WithEvents Tiempo3 As Timer
    Public WithEvents VerificationControl As DPFP.Gui.Verification.VerificationControl
End Class
