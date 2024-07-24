<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_FTP_Fichero
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_FTP_Fichero))
        Me.Grupo_Configuracion_Ftp = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Ftp_Host = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Ftp_Usuario = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Btn_Ver_Contrasena = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Ftp_Contrasena = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Ftp_Puerto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Directorio_Seleccionado = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Refresh = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Descargar_Archivos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Subir_Archivos = New DevComponents.DotNetBar.ButtonItem()
        Me.Grupo_Fichero = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.List_Carpeta_FTP = New DevComponents.DotNetBar.Controls.ListViewEx()
        Me.Archivo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Size = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Fecha = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.TxtLog = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Grupo_Estatus = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Eliminar_documento = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Renombrar = New DevComponents.DotNetBar.ButtonItem()
        Me.CirProgres_FTP = New DevComponents.DotNetBar.CircularProgressItem()
        Me.Grupo_Configuracion_Ftp.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_Fichero.SuspendLayout()
        Me.Grupo_Estatus.SuspendLayout()
        Me.GroupPanel3.SuspendLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Grupo_Configuracion_Ftp
        '
        Me.Grupo_Configuracion_Ftp.BackColor = System.Drawing.Color.White
        Me.Grupo_Configuracion_Ftp.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Configuracion_Ftp.Controls.Add(Me.LabelX5)
        Me.Grupo_Configuracion_Ftp.Controls.Add(Me.TableLayoutPanel1)
        Me.Grupo_Configuracion_Ftp.Controls.Add(Me.Txt_Directorio_Seleccionado)
        Me.Grupo_Configuracion_Ftp.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Configuracion_Ftp.Location = New System.Drawing.Point(12, 12)
        Me.Grupo_Configuracion_Ftp.Name = "Grupo_Configuracion_Ftp"
        Me.Grupo_Configuracion_Ftp.Size = New System.Drawing.Size(617, 125)
        '
        '
        '
        Me.Grupo_Configuracion_Ftp.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Configuracion_Ftp.Style.BackColorGradientAngle = 90
        Me.Grupo_Configuracion_Ftp.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Configuracion_Ftp.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Configuracion_Ftp.Style.BorderBottomWidth = 1
        Me.Grupo_Configuracion_Ftp.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Configuracion_Ftp.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Configuracion_Ftp.Style.BorderLeftWidth = 1
        Me.Grupo_Configuracion_Ftp.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Configuracion_Ftp.Style.BorderRightWidth = 1
        Me.Grupo_Configuracion_Ftp.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Configuracion_Ftp.Style.BorderTopWidth = 1
        Me.Grupo_Configuracion_Ftp.Style.CornerDiameter = 4
        Me.Grupo_Configuracion_Ftp.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Configuracion_Ftp.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Configuracion_Ftp.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Configuracion_Ftp.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Configuracion_Ftp.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Configuracion_Ftp.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Configuracion_Ftp.TabIndex = 115
        Me.Grupo_Configuracion_Ftp.Text = "<b>Ruta archivos adjunto para el negocio FTP</b>"
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(3, 77)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(39, 21)
        Me.LabelX5.TabIndex = 53
        Me.LabelX5.Text = "Fichero"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Ftp_Host, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX1, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Ftp_Usuario, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Btn_Ver_Contrasena, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX3, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Ftp_Contrasena, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX4, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Ftp_Puerto, 4, 1)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 17)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(611, 54)
        Me.TableLayoutPanel1.TabIndex = 52
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 3)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(55, 21)
        Me.LabelX2.TabIndex = 2
        Me.LabelX2.Text = "Usuario"
        '
        'Txt_Ftp_Host
        '
        Me.Txt_Ftp_Host.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Ftp_Host.Border.Class = "TextBoxBorder"
        Me.Txt_Ftp_Host.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Ftp_Host.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Ftp_Host.ForeColor = System.Drawing.Color.Black
        Me.Txt_Ftp_Host.Location = New System.Drawing.Point(360, 3)
        Me.Txt_Ftp_Host.Name = "Txt_Ftp_Host"
        Me.Txt_Ftp_Host.PreventEnterBeep = True
        Me.Txt_Ftp_Host.Size = New System.Drawing.Size(243, 22)
        Me.Txt_Ftp_Host.TabIndex = 1
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(315, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(39, 21)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "Host"
        '
        'Txt_Ftp_Usuario
        '
        Me.Txt_Ftp_Usuario.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Ftp_Usuario.Border.Class = "TextBoxBorder"
        Me.Txt_Ftp_Usuario.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Ftp_Usuario.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Ftp_Usuario.ForeColor = System.Drawing.Color.Black
        Me.Txt_Ftp_Usuario.Location = New System.Drawing.Point(87, 3)
        Me.Txt_Ftp_Usuario.Name = "Txt_Ftp_Usuario"
        Me.Txt_Ftp_Usuario.PreventEnterBeep = True
        Me.Txt_Ftp_Usuario.Size = New System.Drawing.Size(222, 22)
        Me.Txt_Ftp_Usuario.TabIndex = 3
        '
        'Btn_Ver_Contrasena
        '
        Me.Btn_Ver_Contrasena.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText
        Me.Btn_Ver_Contrasena.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Ver_Contrasena.Image = CType(resources.GetObject("Btn_Ver_Contrasena.Image"), System.Drawing.Image)
        Me.Btn_Ver_Contrasena.Location = New System.Drawing.Point(64, 30)
        Me.Btn_Ver_Contrasena.Name = "Btn_Ver_Contrasena"
        Me.Btn_Ver_Contrasena.Size = New System.Drawing.Size(17, 21)
        Me.Btn_Ver_Contrasena.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Ver_Contrasena.TabIndex = 14
        Me.Btn_Ver_Contrasena.Tooltip = "Ver contraseña"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(3, 30)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(55, 21)
        Me.LabelX3.TabIndex = 4
        Me.LabelX3.Text = "Contraseña"
        '
        'Txt_Ftp_Contrasena
        '
        Me.Txt_Ftp_Contrasena.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Ftp_Contrasena.Border.Class = "TextBoxBorder"
        Me.Txt_Ftp_Contrasena.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Ftp_Contrasena.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Ftp_Contrasena.ForeColor = System.Drawing.Color.Black
        Me.Txt_Ftp_Contrasena.Location = New System.Drawing.Point(87, 30)
        Me.Txt_Ftp_Contrasena.Name = "Txt_Ftp_Contrasena"
        Me.Txt_Ftp_Contrasena.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Txt_Ftp_Contrasena.PreventEnterBeep = True
        Me.Txt_Ftp_Contrasena.Size = New System.Drawing.Size(222, 22)
        Me.Txt_Ftp_Contrasena.TabIndex = 5
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(315, 30)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(39, 21)
        Me.LabelX4.TabIndex = 6
        Me.LabelX4.Text = "Puerto"
        '
        'Txt_Ftp_Puerto
        '
        Me.Txt_Ftp_Puerto.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Ftp_Puerto.Border.Class = "TextBoxBorder"
        Me.Txt_Ftp_Puerto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Ftp_Puerto.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Ftp_Puerto.ForeColor = System.Drawing.Color.Black
        Me.Txt_Ftp_Puerto.Location = New System.Drawing.Point(360, 30)
        Me.Txt_Ftp_Puerto.Name = "Txt_Ftp_Puerto"
        Me.Txt_Ftp_Puerto.PreventEnterBeep = True
        Me.Txt_Ftp_Puerto.Size = New System.Drawing.Size(50, 22)
        Me.Txt_Ftp_Puerto.TabIndex = 7
        '
        'Txt_Directorio_Seleccionado
        '
        Me.Txt_Directorio_Seleccionado.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Directorio_Seleccionado.Border.Class = "TextBoxBorder"
        Me.Txt_Directorio_Seleccionado.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Directorio_Seleccionado.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Directorio_Seleccionado.ForeColor = System.Drawing.Color.Black
        Me.Txt_Directorio_Seleccionado.Location = New System.Drawing.Point(48, 77)
        Me.Txt_Directorio_Seleccionado.Name = "Txt_Directorio_Seleccionado"
        Me.Txt_Directorio_Seleccionado.PreventEnterBeep = True
        Me.Txt_Directorio_Seleccionado.ReadOnly = True
        Me.Txt_Directorio_Seleccionado.Size = New System.Drawing.Size(558, 22)
        Me.Txt_Directorio_Seleccionado.TabIndex = 1
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Refresh, Me.Btn_Descargar_Archivos, Me.Btn_Subir_Archivos})
        Me.Bar1.Location = New System.Drawing.Point(0, 615)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(642, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 117
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Refresh
        '
        Me.Btn_Refresh.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Refresh.ForeColor = System.Drawing.Color.Black
        Me.Btn_Refresh.Image = CType(resources.GetObject("Btn_Refresh.Image"), System.Drawing.Image)
        Me.Btn_Refresh.Name = "Btn_Refresh"
        Me.Btn_Refresh.Text = "Refresh"
        '
        'Btn_Descargar_Archivos
        '
        Me.Btn_Descargar_Archivos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Descargar_Archivos.ForeColor = System.Drawing.Color.Black
        Me.Btn_Descargar_Archivos.Image = CType(resources.GetObject("Btn_Descargar_Archivos.Image"), System.Drawing.Image)
        Me.Btn_Descargar_Archivos.Name = "Btn_Descargar_Archivos"
        Me.Btn_Descargar_Archivos.Text = "Descargar archivos seleccionados"
        '
        'Btn_Subir_Archivos
        '
        Me.Btn_Subir_Archivos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Subir_Archivos.ForeColor = System.Drawing.Color.Black
        Me.Btn_Subir_Archivos.Image = CType(resources.GetObject("Btn_Subir_Archivos.Image"), System.Drawing.Image)
        Me.Btn_Subir_Archivos.Name = "Btn_Subir_Archivos"
        Me.Btn_Subir_Archivos.Text = "Subir archivo"
        '
        'Grupo_Fichero
        '
        Me.Grupo_Fichero.BackColor = System.Drawing.Color.White
        Me.Grupo_Fichero.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Fichero.Controls.Add(Me.List_Carpeta_FTP)
        Me.Grupo_Fichero.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Fichero.Location = New System.Drawing.Point(12, 185)
        Me.Grupo_Fichero.Name = "Grupo_Fichero"
        Me.Grupo_Fichero.Size = New System.Drawing.Size(617, 251)
        '
        '
        '
        Me.Grupo_Fichero.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Fichero.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Fichero.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Fichero.TabIndex = 118
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
        Me.List_Carpeta_FTP.HideSelection = False
        Me.List_Carpeta_FTP.Location = New System.Drawing.Point(0, 0)
        Me.List_Carpeta_FTP.Name = "List_Carpeta_FTP"
        Me.List_Carpeta_FTP.Size = New System.Drawing.Size(617, 251)
        Me.List_Carpeta_FTP.SmallImageList = Me.ImageList1
        Me.List_Carpeta_FTP.TabIndex = 119
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
        Me.TxtLog.Size = New System.Drawing.Size(608, 138)
        Me.TxtLog.TabIndex = 119
        '
        'Grupo_Estatus
        '
        Me.Grupo_Estatus.BackColor = System.Drawing.Color.White
        Me.Grupo_Estatus.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Estatus.Controls.Add(Me.TxtLog)
        Me.Grupo_Estatus.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Estatus.Location = New System.Drawing.Point(12, 442)
        Me.Grupo_Estatus.Name = "Grupo_Estatus"
        Me.Grupo_Estatus.Size = New System.Drawing.Size(617, 167)
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
        Me.Grupo_Estatus.TabIndex = 120
        Me.Grupo_Estatus.Text = "Estatus"
        '
        'GroupPanel3
        '
        Me.GroupPanel3.BackColor = System.Drawing.Color.White
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.Bar2)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Location = New System.Drawing.Point(12, 143)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(617, 36)
        '
        '
        '
        Me.GroupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel3.Style.BackColorGradientAngle = 90
        Me.GroupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderBottomWidth = 1
        Me.GroupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderLeftWidth = 1
        Me.GroupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderRightWidth = 1
        Me.GroupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderTopWidth = 1
        Me.GroupPanel3.Style.CornerDiameter = 4
        Me.GroupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel3.TabIndex = 121
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.BackColor = System.Drawing.Color.Transparent
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Eliminar_documento, Me.Btn_Renombrar, Me.CirProgres_FTP})
        Me.Bar2.Location = New System.Drawing.Point(3, 2)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(603, 27)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar2.TabIndex = 123
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Eliminar_documento
        '
        Me.Btn_Eliminar_documento.Image = CType(resources.GetObject("Btn_Eliminar_documento.Image"), System.Drawing.Image)
        Me.Btn_Eliminar_documento.Name = "Btn_Eliminar_documento"
        Me.Btn_Eliminar_documento.Visible = False
        '
        'Btn_Renombrar
        '
        Me.Btn_Renombrar.Image = CType(resources.GetObject("Btn_Renombrar.Image"), System.Drawing.Image)
        Me.Btn_Renombrar.Name = "Btn_Renombrar"
        '
        'CirProgres_FTP
        '
        Me.CirProgres_FTP.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.CirProgres_FTP.Name = "CirProgres_FTP"
        Me.CirProgres_FTP.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Dot
        Me.CirProgres_FTP.Visible = False
        '
        'Frm_FTP_Fichero
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(642, 656)
        Me.Controls.Add(Me.GroupPanel3)
        Me.Controls.Add(Me.Grupo_Estatus)
        Me.Controls.Add(Me.Grupo_Fichero)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.Grupo_Configuracion_Ftp)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_FTP_Fichero"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FTP:"
        Me.Grupo_Configuracion_Ftp.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo_Fichero.ResumeLayout(False)
        Me.Grupo_Estatus.ResumeLayout(False)
        Me.GroupPanel3.ResumeLayout(False)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Grupo_Configuracion_Ftp As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Directorio_Seleccionado As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Public WithEvents Txt_Ftp_Host As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Ftp_Usuario As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Btn_Ver_Contrasena As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Ftp_Contrasena As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Ftp_Puerto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Grupo_Fichero As DevComponents.DotNetBar.Controls.GroupPanel
    Private WithEvents List_Carpeta_FTP As DevComponents.DotNetBar.Controls.ListViewEx
    Private WithEvents Archivo As System.Windows.Forms.ColumnHeader
    Private WithEvents Size As System.Windows.Forms.ColumnHeader
    Private WithEvents Fecha As System.Windows.Forms.ColumnHeader
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Grupo_Estatus As DevComponents.DotNetBar.Controls.GroupPanel
    Private WithEvents TxtLog As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Btn_Descargar_Archivos As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Subir_Archivos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Public WithEvents Btn_Eliminar_documento As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Renombrar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents CirProgres_FTP As DevComponents.DotNetBar.CircularProgressItem
    Public WithEvents Btn_Refresh As DevComponents.DotNetBar.ButtonItem
End Class
