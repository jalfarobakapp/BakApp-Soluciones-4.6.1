<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_MenuBarras
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_MenuBarras))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.Btnbuscardocumento = New System.Windows.Forms.ToolStripButton
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.PegarToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.BtnImprimirBarra = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.Cmbpuerto = New System.Windows.Forms.ToolStripComboBox
        Me.ToolStripButtonGrabarPuerto = New System.Windows.Forms.ToolStripButton
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Btnbuscardocumento, Me.toolStripSeparator, Me.PegarToolStripButton, Me.toolStripSeparator1, Me.BtnImprimirBarra, Me.ToolStripSeparator2, Me.ToolStripLabel1, Me.Cmbpuerto, Me.ToolStripButtonGrabarPuerto})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(755, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'Btnbuscardocumento
        '
        Me.Btnbuscardocumento.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Btnbuscardocumento.Image = Global.AntBru.My.Resources.Resources.folder_find
        Me.Btnbuscardocumento.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btnbuscardocumento.Name = "Btnbuscardocumento"
        Me.Btnbuscardocumento.Size = New System.Drawing.Size(23, 22)
        Me.Btnbuscardocumento.Text = "&Buscar documento del sistema"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'PegarToolStripButton
        '
        Me.PegarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PegarToolStripButton.Image = Global.AntBru.My.Resources.Resources.setting_tools2
        Me.PegarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PegarToolStripButton.Name = "PegarToolStripButton"
        Me.PegarToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PegarToolStripButton.Text = "&Configuración de códigos de barra"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BtnImprimirBarra
        '
        Me.BtnImprimirBarra.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnImprimirBarra.Image = Global.AntBru.My.Resources.Resources.barcode
        Me.BtnImprimirBarra.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnImprimirBarra.Name = "BtnImprimirBarra"
        Me.BtnImprimirBarra.Size = New System.Drawing.Size(23, 22)
        Me.BtnImprimirBarra.Text = "Imprimir código de barras por producto"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(199, 22)
        Me.ToolStripLabel1.Text = "Puerto de Salida Impresora de Barras"
        '
        'Cmbpuerto
        '
        Me.Cmbpuerto.Items.AddRange(New Object() {"LPT1", "LPT2", "LPT3", "LPT4"})
        Me.Cmbpuerto.Name = "Cmbpuerto"
        Me.Cmbpuerto.Size = New System.Drawing.Size(121, 25)
        Me.Cmbpuerto.Text = "LPT1"
        '
        'ToolStripButtonGrabarPuerto
        '
        Me.ToolStripButtonGrabarPuerto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonGrabarPuerto.Image = Global.AntBru.My.Resources.Resources.disk1
        Me.ToolStripButtonGrabarPuerto.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonGrabarPuerto.Name = "ToolStripButtonGrabarPuerto"
        Me.ToolStripButtonGrabarPuerto.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButtonGrabarPuerto.Text = "Grabar puerto de salida"
        '
        'Frm_MenuBarras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(755, 514)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "Frm_MenuBarras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Program especial de impresión de códigos de barra"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents Btnbuscardocumento As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PegarToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnImprimirBarra As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Cmbpuerto As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripButtonGrabarPuerto As System.Windows.Forms.ToolStripButton
End Class
