<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_FTP_Conexion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_FTP_Conexion))
        Me.Grupo_Configuracion_Ftp = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Host = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Usuario = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Clave = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Puerto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Eliminar = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Txt_Url_public = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Carpeta_Archivos = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Carpeta_Imagenes = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Fichero = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.Chk_UsePassive = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Input_Timeout = New DevComponents.Editors.IntegerInput()
        Me.Grupo_Configuracion_Ftp.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Input_Timeout, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Grupo_Configuracion_Ftp
        '
        Me.Grupo_Configuracion_Ftp.BackColor = System.Drawing.Color.White
        Me.Grupo_Configuracion_Ftp.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Configuracion_Ftp.Controls.Add(Me.Input_Timeout)
        Me.Grupo_Configuracion_Ftp.Controls.Add(Me.Chk_UsePassive)
        Me.Grupo_Configuracion_Ftp.Controls.Add(Me.LabelX5)
        Me.Grupo_Configuracion_Ftp.Controls.Add(Me.TableLayoutPanel1)
        Me.Grupo_Configuracion_Ftp.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Configuracion_Ftp.Location = New System.Drawing.Point(12, 3)
        Me.Grupo_Configuracion_Ftp.Name = "Grupo_Configuracion_Ftp"
        Me.Grupo_Configuracion_Ftp.Size = New System.Drawing.Size(617, 126)
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
        Me.Grupo_Configuracion_Ftp.TabIndex = 116
        Me.Grupo_Configuracion_Ftp.Text = "<b>Ruta archivos adjunto para el negocio FTP</b>"
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
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Host, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX1, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Usuario, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX3, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Clave, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX4, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Puerto, 4, 1)
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
        'Txt_Host
        '
        Me.Txt_Host.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Host.Border.Class = "TextBoxBorder"
        Me.Txt_Host.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Host.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Host.ForeColor = System.Drawing.Color.Black
        Me.Txt_Host.Location = New System.Drawing.Point(337, 3)
        Me.Txt_Host.Name = "Txt_Host"
        Me.Txt_Host.PreventEnterBeep = True
        Me.Txt_Host.Size = New System.Drawing.Size(243, 22)
        Me.Txt_Host.TabIndex = 2
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(292, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(39, 21)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "Host"
        '
        'Txt_Usuario
        '
        Me.Txt_Usuario.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Usuario.Border.Class = "TextBoxBorder"
        Me.Txt_Usuario.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Usuario.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Usuario.ForeColor = System.Drawing.Color.Black
        Me.Txt_Usuario.Location = New System.Drawing.Point(64, 3)
        Me.Txt_Usuario.Name = "Txt_Usuario"
        Me.Txt_Usuario.PreventEnterBeep = True
        Me.Txt_Usuario.Size = New System.Drawing.Size(222, 22)
        Me.Txt_Usuario.TabIndex = 0
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
        'Txt_Clave
        '
        Me.Txt_Clave.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Clave.Border.Class = "TextBoxBorder"
        Me.Txt_Clave.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Clave.ButtonCustom.Image = CType(resources.GetObject("Txt_Clave.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Clave.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Clave.ForeColor = System.Drawing.Color.Black
        Me.Txt_Clave.Location = New System.Drawing.Point(64, 30)
        Me.Txt_Clave.Name = "Txt_Clave"
        Me.Txt_Clave.PreventEnterBeep = True
        Me.Txt_Clave.Size = New System.Drawing.Size(222, 22)
        Me.Txt_Clave.TabIndex = 1
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(292, 30)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(39, 21)
        Me.LabelX4.TabIndex = 6
        Me.LabelX4.Text = "Puerto"
        '
        'Txt_Puerto
        '
        Me.Txt_Puerto.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Puerto.Border.Class = "TextBoxBorder"
        Me.Txt_Puerto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Puerto.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Puerto.ForeColor = System.Drawing.Color.Black
        Me.Txt_Puerto.Location = New System.Drawing.Point(337, 30)
        Me.Txt_Puerto.Name = "Txt_Puerto"
        Me.Txt_Puerto.PreventEnterBeep = True
        Me.Txt_Puerto.Size = New System.Drawing.Size(50, 22)
        Me.Txt_Puerto.TabIndex = 3
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar, Me.Btn_Eliminar})
        Me.Bar1.Location = New System.Drawing.Point(0, 295)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(642, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 118
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.FontBold = True
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Navy
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.ImageAlt = CType(resources.GetObject("Btn_Grabar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Grabar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Grabar.Name = "Btn_Grabar"
        '
        'Btn_Eliminar
        '
        Me.Btn_Eliminar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Eliminar.FontBold = True
        Me.Btn_Eliminar.ForeColor = System.Drawing.Color.Navy
        Me.Btn_Eliminar.Image = CType(resources.GetObject("Btn_Eliminar.Image"), System.Drawing.Image)
        Me.Btn_Eliminar.ImageAlt = CType(resources.GetObject("Btn_Eliminar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Eliminar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Eliminar.Name = "Btn_Eliminar"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Txt_Url_public)
        Me.GroupPanel1.Controls.Add(Me.LabelX9)
        Me.GroupPanel1.Controls.Add(Me.Txt_Carpeta_Archivos)
        Me.GroupPanel1.Controls.Add(Me.LabelX8)
        Me.GroupPanel1.Controls.Add(Me.Txt_Carpeta_Imagenes)
        Me.GroupPanel1.Controls.Add(Me.LabelX7)
        Me.GroupPanel1.Controls.Add(Me.Txt_Fichero)
        Me.GroupPanel1.Controls.Add(Me.LabelX6)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 135)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(617, 149)
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
        Me.GroupPanel1.TabIndex = 119
        Me.GroupPanel1.Text = "Carpetas de conexión adicionales"
        '
        'Txt_Url_public
        '
        Me.Txt_Url_public.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Url_public.Border.Class = "TextBoxBorder"
        Me.Txt_Url_public.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Url_public.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Url_public.ForeColor = System.Drawing.Color.Black
        Me.Txt_Url_public.Location = New System.Drawing.Point(67, 95)
        Me.Txt_Url_public.Name = "Txt_Url_public"
        Me.Txt_Url_public.PreventEnterBeep = True
        Me.Txt_Url_public.Size = New System.Drawing.Size(539, 22)
        Me.Txt_Url_public.TabIndex = 7
        '
        'LabelX9
        '
        Me.LabelX9.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.ForeColor = System.Drawing.Color.Black
        Me.LabelX9.Location = New System.Drawing.Point(6, 96)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(55, 21)
        Me.LabelX9.TabIndex = 11
        Me.LabelX9.Text = "Url publico"
        '
        'Txt_Carpeta_Archivos
        '
        Me.Txt_Carpeta_Archivos.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Carpeta_Archivos.Border.Class = "TextBoxBorder"
        Me.Txt_Carpeta_Archivos.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Carpeta_Archivos.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Carpeta_Archivos.ForeColor = System.Drawing.Color.Black
        Me.Txt_Carpeta_Archivos.Location = New System.Drawing.Point(67, 67)
        Me.Txt_Carpeta_Archivos.Name = "Txt_Carpeta_Archivos"
        Me.Txt_Carpeta_Archivos.PreventEnterBeep = True
        Me.Txt_Carpeta_Archivos.ReadOnly = True
        Me.Txt_Carpeta_Archivos.Size = New System.Drawing.Size(539, 22)
        Me.Txt_Carpeta_Archivos.TabIndex = 6
        '
        'LabelX8
        '
        Me.LabelX8.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.ForeColor = System.Drawing.Color.Black
        Me.LabelX8.Location = New System.Drawing.Point(6, 68)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(55, 21)
        Me.LabelX8.TabIndex = 9
        Me.LabelX8.Text = "Archivos"
        '
        'Txt_Carpeta_Imagenes
        '
        Me.Txt_Carpeta_Imagenes.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Carpeta_Imagenes.Border.Class = "TextBoxBorder"
        Me.Txt_Carpeta_Imagenes.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Carpeta_Imagenes.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Carpeta_Imagenes.ForeColor = System.Drawing.Color.Black
        Me.Txt_Carpeta_Imagenes.Location = New System.Drawing.Point(67, 39)
        Me.Txt_Carpeta_Imagenes.Name = "Txt_Carpeta_Imagenes"
        Me.Txt_Carpeta_Imagenes.PreventEnterBeep = True
        Me.Txt_Carpeta_Imagenes.ReadOnly = True
        Me.Txt_Carpeta_Imagenes.Size = New System.Drawing.Size(539, 22)
        Me.Txt_Carpeta_Imagenes.TabIndex = 5
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.ForeColor = System.Drawing.Color.Black
        Me.LabelX7.Location = New System.Drawing.Point(6, 40)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(55, 21)
        Me.LabelX7.TabIndex = 7
        Me.LabelX7.Text = "Imagenes"
        '
        'Txt_Fichero
        '
        Me.Txt_Fichero.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Fichero.Border.Class = "TextBoxBorder"
        Me.Txt_Fichero.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Fichero.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Fichero.ForeColor = System.Drawing.Color.Black
        Me.Txt_Fichero.Location = New System.Drawing.Point(67, 11)
        Me.Txt_Fichero.Name = "Txt_Fichero"
        Me.Txt_Fichero.PreventEnterBeep = True
        Me.Txt_Fichero.Size = New System.Drawing.Size(539, 22)
        Me.Txt_Fichero.TabIndex = 4
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(6, 12)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(55, 21)
        Me.LabelX6.TabIndex = 5
        Me.LabelX6.Text = "Fichero"
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(6, 74)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(55, 21)
        Me.LabelX5.TabIndex = 53
        Me.LabelX5.Text = "Time out"
        '
        'Chk_UsePassive
        '
        Me.Chk_UsePassive.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_UsePassive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_UsePassive.Location = New System.Drawing.Point(295, 74)
        Me.Chk_UsePassive.Name = "Chk_UsePassive"
        Me.Chk_UsePassive.Size = New System.Drawing.Size(100, 23)
        Me.Chk_UsePassive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_UsePassive.TabIndex = 54
        Me.Chk_UsePassive.Text = "PASV"
        '
        'Input_Timeout
        '
        '
        '
        '
        Me.Input_Timeout.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_Timeout.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_Timeout.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.Input_Timeout.Location = New System.Drawing.Point(67, 75)
        Me.Input_Timeout.MaxValue = 120
        Me.Input_Timeout.MinValue = 60
        Me.Input_Timeout.Name = "Input_Timeout"
        Me.Input_Timeout.ShowUpDown = True
        Me.Input_Timeout.Size = New System.Drawing.Size(51, 22)
        Me.Input_Timeout.TabIndex = 55
        Me.Input_Timeout.Value = 60
        '
        'Frm_FTP_Conexion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(642, 336)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.Grupo_Configuracion_Ftp)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_FTP_Conexion"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        Me.Grupo_Configuracion_Ftp.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.Input_Timeout, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Grupo_Configuracion_Ftp As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Host As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Usuario As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Clave As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Puerto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Txt_Url_public As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Carpeta_Archivos As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Carpeta_Imagenes As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Fichero As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Eliminar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Chk_UsePassive As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Input_Timeout As DevComponents.Editors.IntegerInput
End Class
