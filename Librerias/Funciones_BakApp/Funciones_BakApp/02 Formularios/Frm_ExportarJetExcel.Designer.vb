<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ExportarJetExcel
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ExportarJetExcel))
        Me.SvfDirectorio = New System.Windows.Forms.SaveFileDialog
        Me.circularProgressItem7 = New DevComponents.DotNetBar.CircularProgressItem
        Me.CircularProgressItem1 = New DevComponents.DotNetBar.CircularProgressItem
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton
        Me.BtnCancelar = New System.Windows.Forms.ToolStripButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.BtnDireccionFile = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtNombreArchivo = New System.Windows.Forms.TextBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.CircularProgress2 = New DevComponents.DotNetBar.Controls.CircularProgress
        Me.CircularProgress1 = New DevComponents.DotNetBar.Controls.CircularProgress
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SvfDirectorio
        '
        Me.SvfDirectorio.FileName = "..\..\..\"
        Me.SvfDirectorio.Filter = "Archivos Excel|*.xlsx"
        '
        'circularProgressItem7
        '
        Me.circularProgressItem7.Diameter = 32
        Me.circularProgressItem7.Name = "circularProgressItem7"
        Me.circularProgressItem7.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Dot
        Me.circularProgressItem7.ProgressColor = System.Drawing.Color.SeaGreen
        Me.circularProgressItem7.ProgressTextVisible = True
        '
        'CircularProgressItem1
        '
        Me.CircularProgressItem1.Diameter = 32
        Me.CircularProgressItem1.Name = "CircularProgressItem1"
        Me.CircularProgressItem1.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Dot
        Me.CircularProgressItem1.ProgressColor = System.Drawing.Color.SeaGreen
        Me.CircularProgressItem1.ProgressTextVisible = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton2, Me.ToolStripSeparator1, Me.ToolStripButton1, Me.ToolStripSeparator2, Me.ToolStripButton3, Me.BtnCancelar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 82)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(586, 39)
        Me.ToolStrip1.TabIndex = 4
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = Global.Funciones_BakApp.My.Resources.Resources.door_out
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButton2.Text = "Salir"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.Funciones_BakApp.My.Resources.Resources.export_excel
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButton1.Text = "Exportar a Excel .xlsx"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 39)
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButton3.Text = "ToolStripButton3"
        Me.ToolStripButton3.Visible = False
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Image = Global.Funciones_BakApp.My.Resources.Resources.cancel1
        Me.BtnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(89, 36)
        Me.BtnCancelar.Text = "Cancelar"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CircularProgress1)
        Me.GroupBox1.Controls.Add(Me.CircularProgress2)
        Me.GroupBox1.Controls.Add(Me.BtnDireccionFile)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TxtNombreArchivo)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(562, 67)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Sino selecciona una ubicación quedara en la carpeta por defecto..."
        '
        'BtnDireccionFile
        '
        Me.BtnDireccionFile.Image = Global.Funciones_BakApp.My.Resources.Resources.folder
        Me.BtnDireccionFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnDireccionFile.Location = New System.Drawing.Point(516, 35)
        Me.BtnDireccionFile.Name = "BtnDireccionFile"
        Me.BtnDireccionFile.Size = New System.Drawing.Size(40, 23)
        Me.BtnDireccionFile.TabIndex = 7
        Me.BtnDireccionFile.Text = "..."
        Me.BtnDireccionFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.BtnDireccionFile, "Directorio del archivo")
        Me.BtnDireccionFile.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(115, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(216, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Nombre de archivo de salida (Sin Extención)"
        '
        'TxtNombreArchivo
        '
        Me.TxtNombreArchivo.Location = New System.Drawing.Point(118, 38)
        Me.TxtNombreArchivo.Name = "TxtNombreArchivo"
        Me.TxtNombreArchivo.Size = New System.Drawing.Size(392, 20)
        Me.TxtNombreArchivo.TabIndex = 4
        Me.TxtNombreArchivo.Text = "Datos"
        '
        'CircularProgress2
        '
        '
        '
        '
        Me.CircularProgress2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CircularProgress2.Location = New System.Drawing.Point(56, 15)
        Me.CircularProgress2.Name = "CircularProgress2"
        Me.CircularProgress2.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.CircularProgress2.ProgressColor = System.Drawing.Color.SteelBlue
        Me.CircularProgress2.ProgressTextFormat = "{0}"
        Me.CircularProgress2.ProgressTextVisible = True
        Me.CircularProgress2.Size = New System.Drawing.Size(56, 46)
        Me.CircularProgress2.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.CircularProgress2.TabIndex = 6
        '
        'CircularProgress1
        '
        '
        '
        '
        Me.CircularProgress1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CircularProgress1.Location = New System.Drawing.Point(6, 15)
        Me.CircularProgress1.Name = "CircularProgress1"
        Me.CircularProgress1.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.CircularProgress1.ProgressColor = System.Drawing.Color.SteelBlue
        Me.CircularProgress1.ProgressTextVisible = True
        Me.CircularProgress1.Size = New System.Drawing.Size(56, 46)
        Me.CircularProgress1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.CircularProgress1.TabIndex = 7
        '
        'Frm_ExportarJetExcel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(586, 121)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(602, 159)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(602, 159)
        Me.Name = "Frm_ExportarJetExcel"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Exportar datos a Excel (Archivo de extención .xlsx)"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SvfDirectorio As System.Windows.Forms.SaveFileDialog
    Private WithEvents circularProgressItem7 As DevComponents.DotNetBar.CircularProgressItem
    Private WithEvents CircularProgressItem1 As DevComponents.DotNetBar.CircularProgressItem
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnDireccionFile As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtNombreArchivo As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents CircularProgress1 As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents CircularProgress2 As DevComponents.DotNetBar.Controls.CircularProgress
End Class
