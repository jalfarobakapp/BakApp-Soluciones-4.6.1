<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Rc_02_Revision_Cam_Tipo_Reclamo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Rc_02_Revision_Cam_Tipo_Reclamo))
        Me.Cmb_Sub_Tipo_Reclamos = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX14 = New DevComponents.DotNetBar.LabelX()
        Me.Cmb_Tipo_Reclamo = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Rechazar = New DevComponents.DotNetBar.ButtonX()
        Me.SuspendLayout()
        '
        'Cmb_Sub_Tipo_Reclamos
        '
        Me.Cmb_Sub_Tipo_Reclamos.DisplayMember = "Text"
        Me.Cmb_Sub_Tipo_Reclamos.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Sub_Tipo_Reclamos.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Cmb_Sub_Tipo_Reclamos.FocusHighlightEnabled = True
        Me.Cmb_Sub_Tipo_Reclamos.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Sub_Tipo_Reclamos.ItemHeight = 16
        Me.Cmb_Sub_Tipo_Reclamos.Location = New System.Drawing.Point(120, 103)
        Me.Cmb_Sub_Tipo_Reclamos.Name = "Cmb_Sub_Tipo_Reclamos"
        Me.Cmb_Sub_Tipo_Reclamos.Size = New System.Drawing.Size(192, 22)
        Me.Cmb_Sub_Tipo_Reclamos.TabIndex = 124
        '
        'LabelX14
        '
        Me.LabelX14.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX14.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX14.ForeColor = System.Drawing.Color.Black
        Me.LabelX14.Location = New System.Drawing.Point(12, 102)
        Me.LabelX14.Name = "LabelX14"
        Me.LabelX14.Size = New System.Drawing.Size(59, 23)
        Me.LabelX14.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX14.TabIndex = 125
        Me.LabelX14.Text = "Sub-tipo"
        '
        'Cmb_Tipo_Reclamo
        '
        Me.Cmb_Tipo_Reclamo.DisplayMember = "Text"
        Me.Cmb_Tipo_Reclamo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Tipo_Reclamo.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Cmb_Tipo_Reclamo.FocusHighlightEnabled = True
        Me.Cmb_Tipo_Reclamo.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Tipo_Reclamo.ItemHeight = 16
        Me.Cmb_Tipo_Reclamo.Location = New System.Drawing.Point(120, 73)
        Me.Cmb_Tipo_Reclamo.Name = "Cmb_Tipo_Reclamo"
        Me.Cmb_Tipo_Reclamo.Size = New System.Drawing.Size(192, 22)
        Me.Cmb_Tipo_Reclamo.TabIndex = 122
        '
        'LabelX11
        '
        Me.LabelX11.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX11.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX11.ForeColor = System.Drawing.Color.Black
        Me.LabelX11.Location = New System.Drawing.Point(12, 73)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(136, 23)
        Me.LabelX11.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX11.TabIndex = 123
        Me.LabelX11.Text = "Tipo de reclamo"
        '
        'Btn_Rechazar
        '
        Me.Btn_Rechazar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Rechazar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Rechazar.Image = CType(resources.GetObject("Btn_Rechazar.Image"), System.Drawing.Image)
        Me.Btn_Rechazar.Location = New System.Drawing.Point(12, 12)
        Me.Btn_Rechazar.Name = "Btn_Rechazar"
        Me.Btn_Rechazar.Size = New System.Drawing.Size(300, 45)
        Me.Btn_Rechazar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Rechazar.TabIndex = 126
        Me.Btn_Rechazar.Text = "<b>Rechazar</b>, <i>Confirmar el cambio</i>"
        '
        'Frm_Rc_02_Revision_Cam_Tipo_Reclamo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(324, 136)
        Me.Controls.Add(Me.Btn_Rechazar)
        Me.Controls.Add(Me.Cmb_Sub_Tipo_Reclamos)
        Me.Controls.Add(Me.LabelX14)
        Me.Controls.Add(Me.Cmb_Tipo_Reclamo)
        Me.Controls.Add(Me.LabelX11)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Rc_02_Revision_Cam_Tipo_Reclamo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RECHAZAR REVISION, ENVIAR A OTRA AREA"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Cmb_Sub_Tipo_Reclamos As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX14 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Cmb_Tipo_Reclamo As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Rechazar As DevComponents.DotNetBar.ButtonX
End Class
