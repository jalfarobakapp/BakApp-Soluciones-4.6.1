<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Rc_02_Revision
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Rc_02_Revision))
        Me.Btn_Aceptar = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Rechazar = New DevComponents.DotNetBar.ButtonX()
        Me.SuspendLayout()
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Aceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Aceptar.Image = CType(resources.GetObject("Btn_Aceptar.Image"), System.Drawing.Image)
        Me.Btn_Aceptar.Location = New System.Drawing.Point(12, 12)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(233, 45)
        Me.Btn_Aceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Aceptar.TabIndex = 88
        Me.Btn_Aceptar.Text = "<b>Aceptar</b>, <i>enviar a revisión</i>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<i>* Recopilar información</i>"
        '
        'Btn_Rechazar
        '
        Me.Btn_Rechazar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Rechazar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Rechazar.Image = CType(resources.GetObject("Btn_Rechazar.Image"), System.Drawing.Image)
        Me.Btn_Rechazar.Location = New System.Drawing.Point(12, 63)
        Me.Btn_Rechazar.Name = "Btn_Rechazar"
        Me.Btn_Rechazar.Size = New System.Drawing.Size(233, 45)
        Me.Btn_Rechazar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Rechazar.TabIndex = 89
        Me.Btn_Rechazar.Text = "<b>Rechazar</b>, <i>cambiar tidpo de reclamo. (enviar a otra area)</i>"
        '
        'Frm_Rc_02_Revision
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(257, 119)
        Me.Controls.Add(Me.Btn_Rechazar)
        Me.Controls.Add(Me.Btn_Aceptar)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Rc_02_Revision"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REVISION, APERTURA DE RECLAMO"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Btn_Aceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Rechazar As DevComponents.DotNetBar.ButtonX
End Class
