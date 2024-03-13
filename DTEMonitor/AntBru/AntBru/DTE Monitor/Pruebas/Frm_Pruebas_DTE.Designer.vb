<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Pruebas_DTE
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
        Me.Btn_RevisarHistorialDTE = New DevComponents.DotNetBar.ButtonX()
        Me.Barra_Progreso = New DevComponents.DotNetBar.Controls.ProgressBarX()
        Me.Lbl_Estado = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Log = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.SuspendLayout()
        '
        'Btn_RevisarHistorialDTE
        '
        Me.Btn_RevisarHistorialDTE.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_RevisarHistorialDTE.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_RevisarHistorialDTE.Location = New System.Drawing.Point(12, 31)
        Me.Btn_RevisarHistorialDTE.Name = "Btn_RevisarHistorialDTE"
        Me.Btn_RevisarHistorialDTE.Size = New System.Drawing.Size(157, 23)
        Me.Btn_RevisarHistorialDTE.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_RevisarHistorialDTE.TabIndex = 0
        Me.Btn_RevisarHistorialDTE.Text = "Revisar historial DTE"
        '
        'Barra_Progreso
        '
        '
        '
        '
        Me.Barra_Progreso.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Barra_Progreso.Location = New System.Drawing.Point(194, 31)
        Me.Barra_Progreso.Name = "Barra_Progreso"
        Me.Barra_Progreso.Size = New System.Drawing.Size(582, 23)
        Me.Barra_Progreso.TabIndex = 1
        Me.Barra_Progreso.Text = "ProgressBarX1"
        '
        'Lbl_Estado
        '
        '
        '
        '
        Me.Lbl_Estado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Estado.Location = New System.Drawing.Point(12, 60)
        Me.Lbl_Estado.Name = "Lbl_Estado"
        Me.Lbl_Estado.Size = New System.Drawing.Size(629, 23)
        Me.Lbl_Estado.TabIndex = 2
        Me.Lbl_Estado.Text = "LabelX1"
        '
        'Txt_Log
        '
        Me.Txt_Log.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt_Log.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Log.Border.Class = "TextBoxBorder"
        Me.Txt_Log.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Log.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Log.ForeColor = System.Drawing.Color.Black
        Me.Txt_Log.Location = New System.Drawing.Point(12, 89)
        Me.Txt_Log.Multiline = True
        Me.Txt_Log.Name = "Txt_Log"
        Me.Txt_Log.PreventEnterBeep = True
        Me.Txt_Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Log.Size = New System.Drawing.Size(764, 321)
        Me.Txt_Log.TabIndex = 74
        '
        'Frm_Pruebas_DTE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(788, 436)
        Me.Controls.Add(Me.Txt_Log)
        Me.Controls.Add(Me.Lbl_Estado)
        Me.Controls.Add(Me.Barra_Progreso)
        Me.Controls.Add(Me.Btn_RevisarHistorialDTE)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Pruebas_DTE"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Btn_RevisarHistorialDTE As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Barra_Progreso As DevComponents.DotNetBar.Controls.ProgressBarX
    Friend WithEvents Lbl_Estado As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Log As DevComponents.DotNetBar.Controls.TextBoxX
End Class
