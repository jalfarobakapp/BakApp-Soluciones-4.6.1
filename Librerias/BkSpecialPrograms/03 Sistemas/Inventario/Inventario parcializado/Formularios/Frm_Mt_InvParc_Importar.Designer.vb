<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Mt_InvParc_Importar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Mt_InvParc_Importar))
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Archivo_Ayuda = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnImportarDatos = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BtnAbrir_Archivo = New DevComponents.DotNetBar.ButtonX()
        Me.Progreso_Porc = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.Progreso_Cont = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtNombreArchivo = New System.Windows.Forms.TextBox()
        Me.OFile_BuscarArchivo = New System.Windows.Forms.OpenFileDialog()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Archivo_Ayuda, Me.BtnImportarDatos})
        Me.Bar1.Location = New System.Drawing.Point(0, 93)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(580, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 9
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Archivo_Ayuda
        '
        Me.Btn_Archivo_Ayuda.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Archivo_Ayuda.ForeColor = System.Drawing.Color.Black
        Me.Btn_Archivo_Ayuda.Image = CType(resources.GetObject("Btn_Archivo_Ayuda.Image"), System.Drawing.Image)
        Me.Btn_Archivo_Ayuda.Name = "Btn_Archivo_Ayuda"
        Me.Btn_Archivo_Ayuda.Text = "Ayuda"
        Me.Btn_Archivo_Ayuda.Tooltip = "Descargar ejemplo de archivo de levantamiento"
        '
        'BtnImportarDatos
        '
        Me.BtnImportarDatos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnImportarDatos.ForeColor = System.Drawing.Color.Black
        Me.BtnImportarDatos.Image = CType(resources.GetObject("BtnImportarDatos.Image"), System.Drawing.Image)
        Me.BtnImportarDatos.Name = "BtnImportarDatos"
        Me.BtnImportarDatos.Text = "Importar datos..."
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.BtnAbrir_Archivo)
        Me.GroupBox1.Controls.Add(Me.Progreso_Porc)
        Me.GroupBox1.Controls.Add(Me.Progreso_Cont)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TxtNombreArchivo)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(3, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(572, 67)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Dirección de archivo excel con información..."
        '
        'BtnAbrir_Archivo
        '
        Me.BtnAbrir_Archivo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnAbrir_Archivo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnAbrir_Archivo.Image = CType(resources.GetObject("BtnAbrir_Archivo.Image"), System.Drawing.Image)
        Me.BtnAbrir_Archivo.Location = New System.Drawing.Point(526, 38)
        Me.BtnAbrir_Archivo.Name = "BtnAbrir_Archivo"
        Me.BtnAbrir_Archivo.Size = New System.Drawing.Size(37, 23)
        Me.BtnAbrir_Archivo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnAbrir_Archivo.TabIndex = 10
        '
        'Progreso_Porc
        '
        '
        '
        '
        Me.Progreso_Porc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Progreso_Porc.Location = New System.Drawing.Point(6, 15)
        Me.Progreso_Porc.Name = "Progreso_Porc"
        Me.Progreso_Porc.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.Progreso_Porc.ProgressColor = System.Drawing.Color.SteelBlue
        Me.Progreso_Porc.ProgressTextVisible = True
        Me.Progreso_Porc.Size = New System.Drawing.Size(56, 46)
        Me.Progreso_Porc.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.Progreso_Porc.TabIndex = 7
        '
        'Progreso_Cont
        '
        '
        '
        '
        Me.Progreso_Cont.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Progreso_Cont.Location = New System.Drawing.Point(56, 15)
        Me.Progreso_Cont.Name = "Progreso_Cont"
        Me.Progreso_Cont.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.Progreso_Cont.ProgressColor = System.Drawing.Color.SteelBlue
        Me.Progreso_Cont.ProgressTextFormat = "{0}"
        Me.Progreso_Cont.ProgressTextVisible = True
        Me.Progreso_Cont.Size = New System.Drawing.Size(56, 46)
        Me.Progreso_Cont.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.Progreso_Cont.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(115, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(160, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Nombre de archivo a importar"
        '
        'TxtNombreArchivo
        '
        Me.TxtNombreArchivo.BackColor = System.Drawing.Color.White
        Me.TxtNombreArchivo.ForeColor = System.Drawing.Color.Black
        Me.TxtNombreArchivo.Location = New System.Drawing.Point(118, 38)
        Me.TxtNombreArchivo.Name = "TxtNombreArchivo"
        Me.TxtNombreArchivo.Size = New System.Drawing.Size(402, 22)
        Me.TxtNombreArchivo.TabIndex = 4
        '
        'OFile_BuscarArchivo
        '
        Me.OFile_BuscarArchivo.FileName = "OpenFileDialog1"
        '
        'Frm_Mt_InvParc_Importar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(580, 134)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.GroupBox1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Mt_InvParc_Importar"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Importar productos..."
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnAbrir_Archivo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Progreso_Porc As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Progreso_Cont As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtNombreArchivo As System.Windows.Forms.TextBox
    Friend WithEvents OFile_BuscarArchivo As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Btn_Archivo_Ayuda As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnImportarDatos As DevComponents.DotNetBar.ButtonItem
End Class
