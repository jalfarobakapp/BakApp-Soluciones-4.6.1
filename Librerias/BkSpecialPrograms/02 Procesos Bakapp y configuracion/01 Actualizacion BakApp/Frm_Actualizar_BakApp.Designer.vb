<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Actualizar_BakApp
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Actualizar_BakApp))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Barra_Progreso = New System.Windows.Forms.ProgressBar()
        Me.Bnt_Copiar_Link_Descarga_Portapapeles = New DevComponents.DotNetBar.ButtonX()
        Me.Tiempo_Cierre = New System.Windows.Forms.Timer(Me.components)
        Me.Link_Descarga = New System.Windows.Forms.LinkLabel()
        Me.Btn_Descargar_Actualizacion = New DevComponents.DotNetBar.ButtonX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.Barra_Progreso)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(549, 46)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Progreso de la descarga..."
        '
        'Barra_Progreso
        '
        Me.Barra_Progreso.BackColor = System.Drawing.Color.White
        Me.Barra_Progreso.ForeColor = System.Drawing.Color.Black
        Me.Barra_Progreso.Location = New System.Drawing.Point(6, 21)
        Me.Barra_Progreso.Name = "Barra_Progreso"
        Me.Barra_Progreso.Size = New System.Drawing.Size(537, 17)
        Me.Barra_Progreso.TabIndex = 0
        '
        'Bnt_Copiar_Link_Descarga_Portapapeles
        '
        Me.Bnt_Copiar_Link_Descarga_Portapapeles.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Bnt_Copiar_Link_Descarga_Portapapeles.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Bnt_Copiar_Link_Descarga_Portapapeles.Image = CType(resources.GetObject("Bnt_Copiar_Link_Descarga_Portapapeles.Image"), System.Drawing.Image)
        Me.Bnt_Copiar_Link_Descarga_Portapapeles.Location = New System.Drawing.Point(625, 78)
        Me.Bnt_Copiar_Link_Descarga_Portapapeles.Name = "Bnt_Copiar_Link_Descarga_Portapapeles"
        Me.Bnt_Copiar_Link_Descarga_Portapapeles.Size = New System.Drawing.Size(214, 23)
        Me.Bnt_Copiar_Link_Descarga_Portapapeles.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bnt_Copiar_Link_Descarga_Portapapeles.TabIndex = 57
        Me.Bnt_Copiar_Link_Descarga_Portapapeles.Text = "Ir directamente al sitio de descarga..."
        '
        'Tiempo_Cierre
        '
        Me.Tiempo_Cierre.Interval = 5000
        '
        'Link_Descarga
        '
        Me.Link_Descarga.AutoSize = True
        Me.Link_Descarga.BackColor = System.Drawing.Color.White
        Me.Link_Descarga.ForeColor = System.Drawing.Color.Black
        Me.Link_Descarga.Location = New System.Drawing.Point(12, 152)
        Me.Link_Descarga.Name = "Link_Descarga"
        Me.Link_Descarga.Size = New System.Drawing.Size(61, 13)
        Me.Link_Descarga.TabIndex = 58
        Me.Link_Descarga.TabStop = True
        Me.Link_Descarga.Text = "LinkLabel1"
        '
        'Btn_Descargar_Actualizacion
        '
        Me.Btn_Descargar_Actualizacion.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Descargar_Actualizacion.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Descargar_Actualizacion.Image = CType(resources.GetObject("Btn_Descargar_Actualizacion.Image"), System.Drawing.Image)
        Me.Btn_Descargar_Actualizacion.Location = New System.Drawing.Point(12, 64)
        Me.Btn_Descargar_Actualizacion.Name = "Btn_Descargar_Actualizacion"
        Me.Btn_Descargar_Actualizacion.Size = New System.Drawing.Size(180, 38)
        Me.Btn_Descargar_Actualizacion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Descargar_Actualizacion.TabIndex = 59
        Me.Btn_Descargar_Actualizacion.Text = "DESCARGAR"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(12, 117)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(368, 26)
        Me.Label1.TabIndex = 60
        Me.Label1.Text = "Si al hacer clic en el botón de descarga no se descarga la actualización" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " puede " &
    "ir directamente al link presionando el siguiente enlace." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Frm_Actualizar_BakApp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(569, 185)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Btn_Descargar_Actualizacion)
        Me.Controls.Add(Me.Link_Descarga)
        Me.Controls.Add(Me.Bnt_Copiar_Link_Descarga_Portapapeles)
        Me.Controls.Add(Me.GroupBox1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Actualizar_BakApp"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NUEVA ACTUALIZACION"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Barra_Progreso As System.Windows.Forms.ProgressBar
    Friend WithEvents Bnt_Copiar_Link_Descarga_Portapapeles As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Tiempo_Cierre As System.Windows.Forms.Timer
    Friend WithEvents Link_Descarga As LinkLabel
    Friend WithEvents Btn_Descargar_Actualizacion As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label1 As Label
End Class
