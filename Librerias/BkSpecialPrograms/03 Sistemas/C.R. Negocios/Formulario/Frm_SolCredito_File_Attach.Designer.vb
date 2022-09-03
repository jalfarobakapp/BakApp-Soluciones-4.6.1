<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_SolCredito_File_Attach
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_SolCredito_File_Attach))
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.Btn_Descargar_Archivos = New DevComponents.DotNetBar.ButtonItem
        Me.Btn_Subir_Archivos = New DevComponents.DotNetBar.ButtonItem
        Me.Btn_Eliminar = New DevComponents.DotNetBar.ButtonItem
        Me.Btn_Refresh = New DevComponents.DotNetBar.ButtonItem
        Me.BtnCancelar = New DevComponents.DotNetBar.ButtonItem
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.List_Carpeta_FTP = New DevComponents.DotNetBar.Controls.ListViewEx
        Me.Archivo = New System.Windows.Forms.ColumnHeader
        Me.Size = New System.Windows.Forms.ColumnHeader
        Me.Fecha = New System.Windows.Forms.ColumnHeader
        Me.Grupo_Estatus = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.TxtLog = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.Barra_Progreso = New DevComponents.DotNetBar.Controls.ProgressBarX
        Me.Btn_Mnu_Descargar_Archivo = New DevComponents.DotNetBar.ButtonItem
        Me.Btn_Mnu_Eliminar_Archivo = New DevComponents.DotNetBar.ButtonItem
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_Estatus.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Descargar_Archivos, Me.Btn_Subir_Archivos, Me.Btn_Eliminar, Me.Btn_Refresh, Me.BtnCancelar})
        Me.Bar1.Location = New System.Drawing.Point(0, 453)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(638, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 114
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Descargar_Archivos
        '
        Me.Btn_Descargar_Archivos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Descargar_Archivos.ForeColor = System.Drawing.Color.Black
        Me.Btn_Descargar_Archivos.Image = CType(resources.GetObject("Btn_Descargar_Archivos.Image"), System.Drawing.Image)
        Me.Btn_Descargar_Archivos.Name = "Btn_Descargar_Archivos"
        Me.Btn_Descargar_Archivos.Tooltip = "Descargar archivos seleccionados"
        '
        'Btn_Subir_Archivos
        '
        Me.Btn_Subir_Archivos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Subir_Archivos.ForeColor = System.Drawing.Color.Black
        Me.Btn_Subir_Archivos.Image = CType(resources.GetObject("Btn_Subir_Archivos.Image"), System.Drawing.Image)
        Me.Btn_Subir_Archivos.Name = "Btn_Subir_Archivos"
        Me.Btn_Subir_Archivos.Tooltip = "Subir archivo"
        '
        'Btn_Eliminar
        '
        Me.Btn_Eliminar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Eliminar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Eliminar.Image = CType(resources.GetObject("Btn_Eliminar.Image"), System.Drawing.Image)
        Me.Btn_Eliminar.Name = "Btn_Eliminar"
        Me.Btn_Eliminar.Tooltip = "Eliminar seleccionados"
        '
        'Btn_Refresh
        '
        Me.Btn_Refresh.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Refresh.ForeColor = System.Drawing.Color.Black
        Me.Btn_Refresh.Image = CType(resources.GetObject("Btn_Refresh.Image"), System.Drawing.Image)
        Me.Btn_Refresh.Name = "Btn_Refresh"
        Me.Btn_Refresh.Text = "Refresh"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnCancelar.ForeColor = System.Drawing.Color.Black
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Tooltip = "Cancelar"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "file_extension_xls.png")
        Me.ImageList1.Images.SetKeyName(1, "file_extension_pdf.png")
        Me.ImageList1.Images.SetKeyName(2, "file_extension_doc.png")
        Me.ImageList1.Images.SetKeyName(3, "file_extension_txt.png")
        Me.ImageList1.Images.SetKeyName(4, "file_extension_jpg.png")
        Me.ImageList1.Images.SetKeyName(5, "document.png")
        Me.ImageList1.Images.SetKeyName(6, "file_extension_bmp.png")
        Me.ImageList1.Images.SetKeyName(7, "mail.png")
        '
        'List_Carpeta_FTP
        '
        Me.List_Carpeta_FTP.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.List_Carpeta_FTP.Border.Class = "ListViewBorder"
        Me.List_Carpeta_FTP.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.List_Carpeta_FTP.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Archivo, Me.Size, Me.Fecha})
        Me.List_Carpeta_FTP.DisabledBackColor = System.Drawing.Color.Empty
        Me.List_Carpeta_FTP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.List_Carpeta_FTP.ForeColor = System.Drawing.Color.Black
        Me.List_Carpeta_FTP.FullRowSelect = True
        Me.List_Carpeta_FTP.Location = New System.Drawing.Point(0, 0)
        Me.List_Carpeta_FTP.Name = "List_Carpeta_FTP"
        Me.List_Carpeta_FTP.Size = New System.Drawing.Size(611, 242)
        Me.List_Carpeta_FTP.SmallImageList = Me.ImageList1
        Me.List_Carpeta_FTP.TabIndex = 120
        Me.List_Carpeta_FTP.UseCompatibleStateImageBehavior = False
        Me.List_Carpeta_FTP.View = System.Windows.Forms.View.Details
        '
        'Archivo
        '
        Me.Archivo.Text = "Archivo"
        Me.Archivo.Width = 339
        '
        'Size
        '
        Me.Size.Text = "Tamaño"
        Me.Size.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Size.Width = 74
        '
        'Fecha
        '
        Me.Fecha.Text = "Fecha creación"
        Me.Fecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Fecha.Width = 156
        '
        'Grupo_Estatus
        '
        Me.Grupo_Estatus.BackColor = System.Drawing.Color.White
        Me.Grupo_Estatus.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Estatus.Controls.Add(Me.TxtLog)
        Me.Grupo_Estatus.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Estatus.Location = New System.Drawing.Point(9, 283)
        Me.Grupo_Estatus.Name = "Grupo_Estatus"
        Me.Grupo_Estatus.Size = New System.Drawing.Size(617, 135)
        '
        '
        '
        Me.Grupo_Estatus.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Estatus.Style.BackColorGradientAngle = 90
        Me.Grupo_Estatus.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Estatus.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Estatus.Style.BorderBottomWidth = 1
        Me.Grupo_Estatus.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Estatus.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Estatus.Style.BorderLeftWidth = 1
        Me.Grupo_Estatus.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Estatus.Style.BorderRightWidth = 1
        Me.Grupo_Estatus.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Estatus.Style.BorderTopWidth = 1
        Me.Grupo_Estatus.Style.CornerDiameter = 4
        Me.Grupo_Estatus.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Estatus.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Estatus.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Estatus.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Estatus.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Estatus.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Estatus.TabIndex = 121
        Me.Grupo_Estatus.Text = "Estatus"
        '
        'TxtLog
        '
        Me.TxtLog.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtLog.Border.Class = "TextBoxBorder"
        Me.TxtLog.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtLog.DisabledBackColor = System.Drawing.Color.White
        Me.TxtLog.ForeColor = System.Drawing.Color.Black
        Me.TxtLog.Location = New System.Drawing.Point(3, 3)
        Me.TxtLog.Multiline = True
        Me.TxtLog.Name = "TxtLog"
        Me.TxtLog.ReadOnly = True
        Me.TxtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtLog.Size = New System.Drawing.Size(608, 106)
        Me.TxtLog.TabIndex = 119
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.List_Carpeta_FTP)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(9, 12)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(617, 265)
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
        Me.GroupPanel1.TabIndex = 122
        Me.GroupPanel1.Text = "Archivos adjuntos del negocio"
        '
        'Barra_Progreso
        '
        Me.Barra_Progreso.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Barra_Progreso.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Barra_Progreso.ForeColor = System.Drawing.Color.Black
        Me.Barra_Progreso.Location = New System.Drawing.Point(9, 424)
        Me.Barra_Progreso.Name = "Barra_Progreso"
        Me.Barra_Progreso.ProgressType = DevComponents.DotNetBar.eProgressItemType.Marquee
        Me.Barra_Progreso.Size = New System.Drawing.Size(617, 12)
        Me.Barra_Progreso.TabIndex = 123
        Me.Barra_Progreso.Visible = False
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
        'Frm_SolCredito_File_Attach
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(638, 494)
        Me.ControlBox = False
        Me.Controls.Add(Me.Barra_Progreso)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Grupo_Estatus)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "Frm_SolCredito_File_Attach"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FORM"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo_Estatus.ResumeLayout(False)
        Me.GroupPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnCancelar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Descargar_Archivos As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Subir_Archivos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Private WithEvents List_Carpeta_FTP As DevComponents.DotNetBar.Controls.ListViewEx
    Private WithEvents Archivo As System.Windows.Forms.ColumnHeader
    Private WithEvents Size As System.Windows.Forms.ColumnHeader
    Private WithEvents Fecha As System.Windows.Forms.ColumnHeader
    Friend WithEvents Grupo_Estatus As DevComponents.DotNetBar.Controls.GroupPanel
    Private WithEvents TxtLog As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Btn_Eliminar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Refresh As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Barra_Progreso As DevComponents.DotNetBar.Controls.ProgressBarX
    Public WithEvents Btn_Mnu_Descargar_Archivo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_Eliminar_Archivo As DevComponents.DotNetBar.ButtonItem
End Class
