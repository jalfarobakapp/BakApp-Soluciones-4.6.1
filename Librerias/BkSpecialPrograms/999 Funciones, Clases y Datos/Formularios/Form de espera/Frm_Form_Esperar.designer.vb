<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Form_Esperar
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
        Me.BarraCircular = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.MetroStatusBar1 = New DevComponents.DotNetBar.Metro.MetroStatusBar()
        Me.ProgressBarItem1 = New DevComponents.DotNetBar.ProgressBarItem()
        Me.Lbl_Texto = New DevComponents.DotNetBar.LabelX()
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
        Me.BarraCircular.Size = New System.Drawing.Size(61, 36)
        Me.BarraCircular.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.BarraCircular.TabIndex = 0
        Me.BarraCircular.TabStop = False
        '
        'Timer1
        '
        '
        'BackgroundWorker1
        '
        '
        'MetroStatusBar1
        '
        '
        '
        '
        Me.MetroStatusBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MetroStatusBar1.ContainerControlProcessDialogKey = True
        Me.MetroStatusBar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.MetroStatusBar1.DragDropSupport = True
        Me.MetroStatusBar1.Font = New System.Drawing.Font("Segoe UI", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MetroStatusBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ProgressBarItem1})
        Me.MetroStatusBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MetroStatusBar1.Location = New System.Drawing.Point(0, 55)
        Me.MetroStatusBar1.Name = "MetroStatusBar1"
        Me.MetroStatusBar1.Size = New System.Drawing.Size(591, 22)
        Me.MetroStatusBar1.TabIndex = 2
        Me.MetroStatusBar1.Text = "MetroStatusBar1"
        '
        'ProgressBarItem1
        '
        '
        '
        '
        Me.ProgressBarItem1.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ProgressBarItem1.ChunkGradientAngle = 0!
        Me.ProgressBarItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ProgressBarItem1.Name = "ProgressBarItem1"
        Me.ProgressBarItem1.RecentlyUsed = False
        '
        'Lbl_Texto
        '
        '
        '
        '
        Me.Lbl_Texto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Texto.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Texto.Location = New System.Drawing.Point(86, 12)
        Me.Lbl_Texto.Name = "Lbl_Texto"
        Me.Lbl_Texto.Size = New System.Drawing.Size(484, 36)
        Me.Lbl_Texto.TabIndex = 5
        Me.Lbl_Texto.Text = "CARGANDO INFORMACION, POR FAVOR ESPERE..."
        '
        'Frm_Form_Esperar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(591, 77)
        Me.ControlBox = False
        Me.Controls.Add(Me.Lbl_Texto)
        Me.Controls.Add(Me.MetroStatusBar1)
        Me.Controls.Add(Me.BarraCircular)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Form_Esperar"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents BarraCircular As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents MetroStatusBar1 As DevComponents.DotNetBar.Metro.MetroStatusBar
    Friend WithEvents ProgressBarItem1 As DevComponents.DotNetBar.ProgressBarItem
    Friend WithEvents Lbl_Texto As DevComponents.DotNetBar.LabelX
End Class
