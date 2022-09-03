<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Archivos_Adjuntos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Archivos_Adjuntos))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Descargar_Archivo = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Eliminar_Archivo = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla_Archivos = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Subir_Archivos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Descargar_Archivos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Refresh = New DevComponents.DotNetBar.ButtonItem()
        Me.Barra_Progreso = New DevComponents.DotNetBar.Controls.ProgressBarX()
        Me.Imagenes = New System.Windows.Forms.ImageList(Me.components)
        Me.Imagenes_32x32 = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupPanel1.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla_Archivos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.ContextMenuBar1)
        Me.GroupPanel1.Controls.Add(Me.Grilla_Archivos)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(9, 3)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(617, 397)
        '
        '
        '
        Me.GroupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel1.Style.BackColorGradientAngle = 90
        Me.GroupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderBottomWidth = 1
        Me.GroupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderLeftWidth = 1
        Me.GroupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderRightWidth = 1
        Me.GroupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderTopWidth = 1
        Me.GroupPanel1.Style.CornerDiameter = 4
        Me.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel1.TabIndex = 129
        Me.GroupPanel1.Text = "Archivos adjuntos"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(154, 87)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(266, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 97
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual
        '
        Me.Menu_Contextual.AutoExpandOnClick = True
        Me.Menu_Contextual.Name = "Menu_Contextual"
        Me.Menu_Contextual.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Mnu_Descargar_Archivo, Me.Btn_Mnu_Eliminar_Archivo})
        Me.Menu_Contextual.Text = "Opciones"
        '
        'Btn_Mnu_Descargar_Archivo
        '
        Me.Btn_Mnu_Descargar_Archivo.Image = CType(resources.GetObject("Btn_Mnu_Descargar_Archivo.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Descargar_Archivo.Name = "Btn_Mnu_Descargar_Archivo"
        Me.Btn_Mnu_Descargar_Archivo.Text = "Ver archivo (descarga temporal)"
        '
        'Btn_Mnu_Eliminar_Archivo
        '
        Me.Btn_Mnu_Eliminar_Archivo.Image = CType(resources.GetObject("Btn_Mnu_Eliminar_Archivo.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Eliminar_Archivo.Name = "Btn_Mnu_Eliminar_Archivo"
        Me.Btn_Mnu_Eliminar_Archivo.Text = "Eliminar archivo" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Grilla_Archivos
        '
        Me.Grilla_Archivos.AllowUserToAddRows = False
        Me.Grilla_Archivos.AllowUserToDeleteRows = False
        Me.Grilla_Archivos.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Archivos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grilla_Archivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Archivos.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grilla_Archivos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Archivos.EnableHeadersVisualStyles = False
        Me.Grilla_Archivos.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Archivos.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Archivos.Name = "Grilla_Archivos"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Archivos.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla_Archivos.RowHeadersVisible = False
        Me.Grilla_Archivos.RowTemplate.Height = 25
        Me.Grilla_Archivos.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Grilla_Archivos.Size = New System.Drawing.Size(611, 374)
        Me.Grilla_Archivos.TabIndex = 1
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Subir_Archivos, Me.Btn_Descargar_Archivos, Me.Btn_Refresh})
        Me.Bar1.Location = New System.Drawing.Point(0, 449)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(636, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 128
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Subir_Archivos
        '
        Me.Btn_Subir_Archivos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Subir_Archivos.ForeColor = System.Drawing.Color.Black
        Me.Btn_Subir_Archivos.Image = CType(resources.GetObject("Btn_Subir_Archivos.Image"), System.Drawing.Image)
        Me.Btn_Subir_Archivos.Name = "Btn_Subir_Archivos"
        Me.Btn_Subir_Archivos.Tooltip = "Subir archivo"
        '
        'Btn_Descargar_Archivos
        '
        Me.Btn_Descargar_Archivos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Descargar_Archivos.ForeColor = System.Drawing.Color.Black
        Me.Btn_Descargar_Archivos.Image = CType(resources.GetObject("Btn_Descargar_Archivos.Image"), System.Drawing.Image)
        Me.Btn_Descargar_Archivos.Name = "Btn_Descargar_Archivos"
        Me.Btn_Descargar_Archivos.Tooltip = "Descargar archivos seleccionados"
        '
        'Btn_Refresh
        '
        Me.Btn_Refresh.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Refresh.ForeColor = System.Drawing.Color.Black
        Me.Btn_Refresh.Image = CType(resources.GetObject("Btn_Refresh.Image"), System.Drawing.Image)
        Me.Btn_Refresh.Name = "Btn_Refresh"
        '
        'Barra_Progreso
        '
        Me.Barra_Progreso.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Barra_Progreso.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Barra_Progreso.ForeColor = System.Drawing.Color.Black
        Me.Barra_Progreso.Location = New System.Drawing.Point(9, 415)
        Me.Barra_Progreso.Name = "Barra_Progreso"
        Me.Barra_Progreso.ProgressType = DevComponents.DotNetBar.eProgressItemType.Marquee
        Me.Barra_Progreso.Size = New System.Drawing.Size(617, 12)
        Me.Barra_Progreso.TabIndex = 130
        Me.Barra_Progreso.Visible = False
        '
        'Imagenes
        '
        Me.Imagenes.ImageStream = CType(resources.GetObject("Imagenes.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagenes.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagenes.Images.SetKeyName(0, "file_extension_xls.png")
        Me.Imagenes.Images.SetKeyName(1, "file_extension_pdf.png")
        Me.Imagenes.Images.SetKeyName(2, "file_extension_doc.png")
        Me.Imagenes.Images.SetKeyName(3, "file_extension_txt.png")
        Me.Imagenes.Images.SetKeyName(4, "file_extension_jpg.png")
        Me.Imagenes.Images.SetKeyName(5, "document.png")
        Me.Imagenes.Images.SetKeyName(6, "file_extension_bmp.png")
        Me.Imagenes.Images.SetKeyName(7, "mail.png")
        '
        'Imagenes_32x32
        '
        Me.Imagenes_32x32.ImageStream = CType(resources.GetObject("Imagenes_32x32.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagenes_32x32.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagenes_32x32.Images.SetKeyName(0, "cross.png")
        '
        'Frm_Archivos_Adjuntos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(636, 490)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.Barra_Progreso)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Archivos_Adjuntos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla_Archivos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Mnu_Descargar_Archivo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_Eliminar_Archivo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grilla_Archivos As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Public WithEvents Btn_Subir_Archivos As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Descargar_Archivos As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Refresh As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Barra_Progreso As DevComponents.DotNetBar.Controls.ProgressBarX
    Friend WithEvents Imagenes As ImageList
    Friend WithEvents Imagenes_32x32 As ImageList
End Class
