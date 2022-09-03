<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Adjuntar_Archivos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Adjuntar_Archivos))
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_Fila = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Descargar_Archivo = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Eliminar_Archivo = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_Filas = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Descargar_Archivos2 = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Eliminar_Archivos = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_Subir = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Subir_Archivos2 = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Agregar_Observacion2 = New DevComponents.DotNetBar.ButtonItem()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Subir_Archivos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Descargar_Archivos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Agregar_Observacion = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Refresh = New DevComponents.DotNetBar.ButtonItem()
        Me.Barra_Progreso = New DevComponents.DotNetBar.Controls.ProgressBarX()
        Me.Imagenes = New System.Windows.Forms.ImageList(Me.components)
        Me.Listv_Archivos = New DevComponents.DotNetBar.Controls.ListViewEx()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_Fila, Me.Menu_Contextual_Filas, Me.Menu_Contextual_Subir})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(130, 242)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(266, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 97
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_Fila
        '
        Me.Menu_Contextual_Fila.AutoExpandOnClick = True
        Me.Menu_Contextual_Fila.Name = "Menu_Contextual_Fila"
        Me.Menu_Contextual_Fila.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Mnu_Descargar_Archivo, Me.Btn_Mnu_Eliminar_Archivo})
        Me.Menu_Contextual_Fila.Text = "Opciones"
        '
        'Btn_Mnu_Descargar_Archivo
        '
        Me.Btn_Mnu_Descargar_Archivo.Image = CType(resources.GetObject("Btn_Mnu_Descargar_Archivo.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Descargar_Archivo.ImageAlt = CType(resources.GetObject("Btn_Mnu_Descargar_Archivo.ImageAlt"), System.Drawing.Image)
        Me.Btn_Mnu_Descargar_Archivo.Name = "Btn_Mnu_Descargar_Archivo"
        Me.Btn_Mnu_Descargar_Archivo.Text = "Ver archivo (descarga temporal)"
        '
        'Btn_Mnu_Eliminar_Archivo
        '
        Me.Btn_Mnu_Eliminar_Archivo.Image = CType(resources.GetObject("Btn_Mnu_Eliminar_Archivo.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Eliminar_Archivo.ImageAlt = CType(resources.GetObject("Btn_Mnu_Eliminar_Archivo.ImageAlt"), System.Drawing.Image)
        Me.Btn_Mnu_Eliminar_Archivo.Name = "Btn_Mnu_Eliminar_Archivo"
        Me.Btn_Mnu_Eliminar_Archivo.Text = "Eliminar archivo" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Menu_Contextual_Filas
        '
        Me.Menu_Contextual_Filas.AutoExpandOnClick = True
        Me.Menu_Contextual_Filas.Name = "Menu_Contextual_Filas"
        Me.Menu_Contextual_Filas.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Descargar_Archivos2, Me.Btn_Eliminar_Archivos})
        Me.Menu_Contextual_Filas.Text = "Opciones"
        '
        'Btn_Descargar_Archivos2
        '
        Me.Btn_Descargar_Archivos2.Image = CType(resources.GetObject("Btn_Descargar_Archivos2.Image"), System.Drawing.Image)
        Me.Btn_Descargar_Archivos2.ImageAlt = CType(resources.GetObject("Btn_Descargar_Archivos2.ImageAlt"), System.Drawing.Image)
        Me.Btn_Descargar_Archivos2.Name = "Btn_Descargar_Archivos2"
        Me.Btn_Descargar_Archivos2.Text = "Descargar archivos seleccionados"
        '
        'Btn_Eliminar_Archivos
        '
        Me.Btn_Eliminar_Archivos.Image = CType(resources.GetObject("Btn_Eliminar_Archivos.Image"), System.Drawing.Image)
        Me.Btn_Eliminar_Archivos.ImageAlt = CType(resources.GetObject("Btn_Eliminar_Archivos.ImageAlt"), System.Drawing.Image)
        Me.Btn_Eliminar_Archivos.Name = "Btn_Eliminar_Archivos"
        Me.Btn_Eliminar_Archivos.Text = "Eliminar archivos seleccionados"
        '
        'Menu_Contextual_Subir
        '
        Me.Menu_Contextual_Subir.AutoExpandOnClick = True
        Me.Menu_Contextual_Subir.Name = "Menu_Contextual_Subir"
        Me.Menu_Contextual_Subir.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Subir_Archivos2, Me.Btn_Agregar_Observacion2})
        Me.Menu_Contextual_Subir.Text = "Opciones"
        '
        'Btn_Subir_Archivos2
        '
        Me.Btn_Subir_Archivos2.Image = CType(resources.GetObject("Btn_Subir_Archivos2.Image"), System.Drawing.Image)
        Me.Btn_Subir_Archivos2.ImageAlt = CType(resources.GetObject("Btn_Subir_Archivos2.ImageAlt"), System.Drawing.Image)
        Me.Btn_Subir_Archivos2.Name = "Btn_Subir_Archivos2"
        Me.Btn_Subir_Archivos2.Text = "Subir archivos"
        '
        'Btn_Agregar_Observacion2
        '
        Me.Btn_Agregar_Observacion2.Image = CType(resources.GetObject("Btn_Agregar_Observacion2.Image"), System.Drawing.Image)
        Me.Btn_Agregar_Observacion2.ImageAlt = CType(resources.GetObject("Btn_Agregar_Observacion2.ImageAlt"), System.Drawing.Image)
        Me.Btn_Agregar_Observacion2.Name = "Btn_Agregar_Observacion2"
        Me.Btn_Agregar_Observacion2.Text = "Agregar imagen"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Subir_Archivos, Me.Btn_Descargar_Archivos, Me.Btn_Agregar_Observacion, Me.Btn_Refresh})
        Me.Bar1.Location = New System.Drawing.Point(0, 496)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(628, 41)
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
        Me.Btn_Subir_Archivos.ImageAlt = CType(resources.GetObject("Btn_Subir_Archivos.ImageAlt"), System.Drawing.Image)
        Me.Btn_Subir_Archivos.Name = "Btn_Subir_Archivos"
        Me.Btn_Subir_Archivos.Tooltip = "Subir archivos"
        '
        'Btn_Descargar_Archivos
        '
        Me.Btn_Descargar_Archivos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Descargar_Archivos.ForeColor = System.Drawing.Color.Black
        Me.Btn_Descargar_Archivos.Image = CType(resources.GetObject("Btn_Descargar_Archivos.Image"), System.Drawing.Image)
        Me.Btn_Descargar_Archivos.ImageAlt = CType(resources.GetObject("Btn_Descargar_Archivos.ImageAlt"), System.Drawing.Image)
        Me.Btn_Descargar_Archivos.Name = "Btn_Descargar_Archivos"
        Me.Btn_Descargar_Archivos.Tooltip = "Descargar archivos seleccionados"
        '
        'Btn_Agregar_Observacion
        '
        Me.Btn_Agregar_Observacion.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Agregar_Observacion.ForeColor = System.Drawing.Color.Black
        Me.Btn_Agregar_Observacion.Image = CType(resources.GetObject("Btn_Agregar_Observacion.Image"), System.Drawing.Image)
        Me.Btn_Agregar_Observacion.ImageAlt = CType(resources.GetObject("Btn_Agregar_Observacion.ImageAlt"), System.Drawing.Image)
        Me.Btn_Agregar_Observacion.Name = "Btn_Agregar_Observacion"
        Me.Btn_Agregar_Observacion.Tooltip = "Agregar imagen desde el portapapeles."
        '
        'Btn_Refresh
        '
        Me.Btn_Refresh.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Refresh.ForeColor = System.Drawing.Color.Black
        Me.Btn_Refresh.Image = CType(resources.GetObject("Btn_Refresh.Image"), System.Drawing.Image)
        Me.Btn_Refresh.ImageAlt = CType(resources.GetObject("Btn_Refresh.ImageAlt"), System.Drawing.Image)
        Me.Btn_Refresh.Name = "Btn_Refresh"
        Me.Btn_Refresh.Tooltip = "Actualizar(F5)"
        '
        'Barra_Progreso
        '
        Me.Barra_Progreso.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Barra_Progreso.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Barra_Progreso.ForeColor = System.Drawing.Color.Black
        Me.Barra_Progreso.Location = New System.Drawing.Point(6, 470)
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
        'Listv_Archivos
        '
        Me.Listv_Archivos.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.Listv_Archivos.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Listv_Archivos.Border.Class = "ListViewBorder"
        Me.Listv_Archivos.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Listv_Archivos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader1})
        Me.Listv_Archivos.DisabledBackColor = System.Drawing.Color.Empty
        Me.Listv_Archivos.ForeColor = System.Drawing.Color.Black
        Me.Listv_Archivos.GridLines = True
        Me.Listv_Archivos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.Listv_Archivos.HideSelection = False
        Me.Listv_Archivos.HotTracking = True
        Me.Listv_Archivos.HoverSelection = True
        Me.Listv_Archivos.Location = New System.Drawing.Point(6, 12)
        Me.Listv_Archivos.Name = "Listv_Archivos"
        Me.Listv_Archivos.Size = New System.Drawing.Size(617, 452)
        Me.Listv_Archivos.SmallImageList = Me.Imagenes
        Me.Listv_Archivos.TabIndex = 137
        Me.Listv_Archivos.UseCompatibleStateImageBehavior = False
        Me.Listv_Archivos.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Archivo"
        Me.ColumnHeader4.Width = 339
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Tamaño"
        Me.ColumnHeader5.Width = 74
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Fecha creación"
        Me.ColumnHeader6.Width = 156
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Fun."
        '
        'Frm_Adjuntar_Archivos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(628, 537)
        Me.Controls.Add(Me.ContextMenuBar1)
        Me.Controls.Add(Me.Listv_Archivos)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.Barra_Progreso)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Adjuntar_Archivos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Archivos adjuntos al documento"
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_Fila As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Mnu_Descargar_Archivo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_Eliminar_Archivo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Public WithEvents Btn_Descargar_Archivos As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Subir_Archivos As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Refresh As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Barra_Progreso As DevComponents.DotNetBar.Controls.ProgressBarX
    Friend WithEvents Imagenes As ImageList
    Public WithEvents Btn_Agregar_Observacion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Menu_Contextual_Filas As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Descargar_Archivos2 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Eliminar_Archivos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Listv_Archivos As DevComponents.DotNetBar.Controls.ListViewEx
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents Menu_Contextual_Subir As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Subir_Archivos2 As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Agregar_Observacion2 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ColumnHeader1 As ColumnHeader
End Class
