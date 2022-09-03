<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Archivador_Buscador
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Archivador_Buscador))
        Me.chkIgnorarError = New System.Windows.Forms.CheckBox()
        Me.lvFics = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chkConSubDir = New System.Windows.Forms.CheckBox()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDir = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Btn_Buscar = New System.Windows.Forms.Button()
        Me.Btn_Examinar = New System.Windows.Forms.Button()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Btn_Abrir_Documento = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Abrir_Directorio = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Abrir_Archivo = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Integrar_Archivos = New DevComponents.DotNetBar.ButtonItem()
        Me.MetroStatusBar1 = New DevComponents.DotNetBar.Metro.MetroStatusBar()
        Me.LabelInfo = New DevComponents.DotNetBar.LabelItem()
        Me.Txt_Consulta = New System.Windows.Forms.TextBox()
        Me.Lbl_Progress = New System.Windows.Forms.Label()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Bar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkIgnorarError
        '
        Me.chkIgnorarError.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkIgnorarError.AutoSize = True
        Me.chkIgnorarError.BackColor = System.Drawing.Color.White
        Me.chkIgnorarError.Checked = True
        Me.chkIgnorarError.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIgnorarError.Enabled = False
        Me.chkIgnorarError.ForeColor = System.Drawing.Color.Black
        Me.chkIgnorarError.Location = New System.Drawing.Point(335, 63)
        Me.chkIgnorarError.Name = "chkIgnorarError"
        Me.chkIgnorarError.Size = New System.Drawing.Size(160, 17)
        Me.chkIgnorarError.TabIndex = 17
        Me.chkIgnorarError.Text = "Ignorar los avisos de error"
        Me.chkIgnorarError.UseVisualStyleBackColor = False
        '
        'lvFics
        '
        Me.lvFics.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lvFics.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvFics.BackColor = System.Drawing.Color.White
        Me.lvFics.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lvFics.ForeColor = System.Drawing.Color.Black
        Me.lvFics.FullRowSelect = True
        Me.lvFics.GridLines = True
        Me.lvFics.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvFics.HideSelection = False
        Me.lvFics.Location = New System.Drawing.Point(12, 88)
        Me.lvFics.MultiSelect = False
        Me.lvFics.Name = "lvFics"
        Me.lvFics.Size = New System.Drawing.Size(803, 459)
        Me.lvFics.TabIndex = 18
        Me.lvFics.UseCompatibleStateImageBehavior = False
        Me.lvFics.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Nombre"
        Me.ColumnHeader1.Width = 159
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Directorio"
        Me.ColumnHeader2.Width = 1000
        '
        'chkConSubDir
        '
        Me.chkConSubDir.AutoSize = True
        Me.chkConSubDir.BackColor = System.Drawing.Color.White
        Me.chkConSubDir.Checked = True
        Me.chkConSubDir.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkConSubDir.ForeColor = System.Drawing.Color.Black
        Me.chkConSubDir.Location = New System.Drawing.Point(118, 63)
        Me.chkConSubDir.Name = "chkConSubDir"
        Me.chkConSubDir.Size = New System.Drawing.Size(135, 17)
        Me.chkConSubDir.TabIndex = 16
        Me.chkConSubDir.Text = "Incluir subdirectorios"
        Me.chkConSubDir.UseVisualStyleBackColor = False
        '
        'txtFiltro
        '
        Me.txtFiltro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFiltro.BackColor = System.Drawing.Color.White
        Me.txtFiltro.Enabled = False
        Me.txtFiltro.ForeColor = System.Drawing.Color.Black
        Me.txtFiltro.Location = New System.Drawing.Point(118, 6)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(616, 22)
        Me.txtFiltro.TabIndex = 13
        Me.txtFiltro.Text = "*.*"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 16)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Filtro búsqueda:"
        '
        'txtDir
        '
        Me.txtDir.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDir.BackColor = System.Drawing.Color.White
        Me.txtDir.ForeColor = System.Drawing.Color.Black
        Me.txtDir.Location = New System.Drawing.Point(118, 32)
        Me.txtDir.Name = "txtDir"
        Me.txtDir.Size = New System.Drawing.Size(616, 22)
        Me.txtDir.TabIndex = 15
        Me.txtDir.Text = "C:\"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(12, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 16)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Directorio:"
        '
        'Btn_Buscar
        '
        Me.Btn_Buscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Buscar.BackColor = System.Drawing.Color.White
        Me.Btn_Buscar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Buscar.Location = New System.Drawing.Point(740, 59)
        Me.Btn_Buscar.Name = "Btn_Buscar"
        Me.Btn_Buscar.Size = New System.Drawing.Size(75, 21)
        Me.Btn_Buscar.TabIndex = 23
        Me.Btn_Buscar.Text = "Buscar"
        Me.Btn_Buscar.UseVisualStyleBackColor = False
        '
        'Btn_Examinar
        '
        Me.Btn_Examinar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Examinar.BackColor = System.Drawing.Color.White
        Me.Btn_Examinar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Examinar.Location = New System.Drawing.Point(740, 32)
        Me.Btn_Examinar.Name = "Btn_Examinar"
        Me.Btn_Examinar.Size = New System.Drawing.Size(75, 22)
        Me.Btn_Examinar.TabIndex = 22
        Me.Btn_Examinar.Text = "Examinar..."
        Me.Btn_Examinar.UseVisualStyleBackColor = False
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Controls.Add(Me.ProgressBar1)
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Abrir_Documento, Me.Btn_Abrir_Directorio, Me.Btn_Abrir_Archivo, Me.Btn_Integrar_Archivos})
        Me.Bar1.Location = New System.Drawing.Point(0, 553)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(827, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 53
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.BackColor = System.Drawing.Color.White
        Me.ProgressBar1.ForeColor = System.Drawing.Color.Black
        Me.ProgressBar1.Location = New System.Drawing.Point(496, 16)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(319, 22)
        Me.ProgressBar1.TabIndex = 0
        '
        'Btn_Abrir_Documento
        '
        Me.Btn_Abrir_Documento.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Abrir_Documento.ForeColor = System.Drawing.Color.Black
        Me.Btn_Abrir_Documento.Image = CType(resources.GetObject("Btn_Abrir_Documento.Image"), System.Drawing.Image)
        Me.Btn_Abrir_Documento.ImageAlt = CType(resources.GetObject("Btn_Abrir_Documento.ImageAlt"), System.Drawing.Image)
        Me.Btn_Abrir_Documento.Name = "Btn_Abrir_Documento"
        Me.Btn_Abrir_Documento.Tooltip = "Abrir documento"
        '
        'Btn_Abrir_Directorio
        '
        Me.Btn_Abrir_Directorio.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Abrir_Directorio.ForeColor = System.Drawing.Color.Black
        Me.Btn_Abrir_Directorio.Image = CType(resources.GetObject("Btn_Abrir_Directorio.Image"), System.Drawing.Image)
        Me.Btn_Abrir_Directorio.ImageAlt = CType(resources.GetObject("Btn_Abrir_Directorio.ImageAlt"), System.Drawing.Image)
        Me.Btn_Abrir_Directorio.Name = "Btn_Abrir_Directorio"
        Me.Btn_Abrir_Directorio.Tooltip = "Abrir directorio"
        '
        'Btn_Abrir_Archivo
        '
        Me.Btn_Abrir_Archivo.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Abrir_Archivo.ForeColor = System.Drawing.Color.Black
        Me.Btn_Abrir_Archivo.Image = CType(resources.GetObject("Btn_Abrir_Archivo.Image"), System.Drawing.Image)
        Me.Btn_Abrir_Archivo.ImageAlt = CType(resources.GetObject("Btn_Abrir_Archivo.ImageAlt"), System.Drawing.Image)
        Me.Btn_Abrir_Archivo.Name = "Btn_Abrir_Archivo"
        Me.Btn_Abrir_Archivo.Tooltip = "Abrir archivo .xml"
        '
        'Btn_Integrar_Archivos
        '
        Me.Btn_Integrar_Archivos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Integrar_Archivos.ForeColor = System.Drawing.Color.Black
        Me.Btn_Integrar_Archivos.Image = CType(resources.GetObject("Btn_Integrar_Archivos.Image"), System.Drawing.Image)
        Me.Btn_Integrar_Archivos.ImageAlt = CType(resources.GetObject("Btn_Integrar_Archivos.ImageAlt"), System.Drawing.Image)
        Me.Btn_Integrar_Archivos.Name = "Btn_Integrar_Archivos"
        Me.Btn_Integrar_Archivos.Tooltip = "Abrir archivo .xml"
        '
        'MetroStatusBar1
        '
        Me.MetroStatusBar1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.MetroStatusBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MetroStatusBar1.ContainerControlProcessDialogKey = True
        Me.MetroStatusBar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.MetroStatusBar1.DragDropSupport = True
        Me.MetroStatusBar1.Font = New System.Drawing.Font("Segoe UI", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MetroStatusBar1.ForeColor = System.Drawing.Color.Black
        Me.MetroStatusBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelInfo})
        Me.MetroStatusBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MetroStatusBar1.Location = New System.Drawing.Point(0, 594)
        Me.MetroStatusBar1.Name = "MetroStatusBar1"
        Me.MetroStatusBar1.Size = New System.Drawing.Size(827, 22)
        Me.MetroStatusBar1.TabIndex = 54
        Me.MetroStatusBar1.Text = "MetroStatusBar1"
        '
        'LabelInfo
        '
        Me.LabelInfo.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelInfo.Name = "LabelInfo"
        Me.LabelInfo.Text = "Status..."
        '
        'Txt_Consulta
        '
        Me.Txt_Consulta.BackColor = System.Drawing.Color.White
        Me.Txt_Consulta.ForeColor = System.Drawing.Color.Black
        Me.Txt_Consulta.Location = New System.Drawing.Point(310, 245)
        Me.Txt_Consulta.Multiline = True
        Me.Txt_Consulta.Name = "Txt_Consulta"
        Me.Txt_Consulta.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Consulta.Size = New System.Drawing.Size(488, 191)
        Me.Txt_Consulta.TabIndex = 55
        Me.Txt_Consulta.Visible = False
        '
        'Lbl_Progress
        '
        Me.Lbl_Progress.BackColor = System.Drawing.Color.White
        Me.Lbl_Progress.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Progress.Location = New System.Drawing.Point(496, 550)
        Me.Lbl_Progress.Name = "Lbl_Progress"
        Me.Lbl_Progress.Size = New System.Drawing.Size(319, 16)
        Me.Lbl_Progress.TabIndex = 56
        Me.Lbl_Progress.Text = "-"
        Me.Lbl_Progress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Frm_Archivador_Buscador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(827, 616)
        Me.Controls.Add(Me.Lbl_Progress)
        Me.Controls.Add(Me.Txt_Consulta)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.MetroStatusBar1)
        Me.Controls.Add(Me.Btn_Buscar)
        Me.Controls.Add(Me.Btn_Examinar)
        Me.Controls.Add(Me.chkIgnorarError)
        Me.Controls.Add(Me.lvFics)
        Me.Controls.Add(Me.chkConSubDir)
        Me.Controls.Add(Me.txtFiltro)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtDir)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "Frm_Archivador_Buscador"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "visualizador de archivador de documentos"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Bar1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents chkIgnorarError As CheckBox
    Private WithEvents lvFics As ListView
    Private WithEvents ColumnHeader1 As ColumnHeader
    Private WithEvents ColumnHeader2 As ColumnHeader
    Private WithEvents chkConSubDir As CheckBox
    Private WithEvents txtFiltro As TextBox
    Private WithEvents Label2 As Label
    Private WithEvents txtDir As TextBox
    Private WithEvents Label1 As Label
    Private WithEvents Btn_Buscar As Button
    Private WithEvents Btn_Examinar As Button
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Abrir_Documento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Abrir_Archivo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Abrir_Directorio As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroStatusBar1 As DevComponents.DotNetBar.Metro.MetroStatusBar
    Friend WithEvents LabelInfo As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Integrar_Archivos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Txt_Consulta As TextBox
    Friend WithEvents ProgressBar1 As ProgressBar
    Private WithEvents Lbl_Progress As Label
End Class
