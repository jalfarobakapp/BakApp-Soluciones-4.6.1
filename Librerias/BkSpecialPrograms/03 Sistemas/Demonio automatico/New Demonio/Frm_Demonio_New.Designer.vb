<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Demonio_New
    Inherits DevComponents.DotNetBar.Metro.MetroForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Demonio_New))
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Modalidad = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Nombre_Equipo = New DevComponents.DotNetBar.LabelX()
        Me.DtpFecharevision = New System.Windows.Forms.DateTimePicker()
        Me.BtnCambFecha = New DevComponents.DotNetBar.ButtonX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Configurar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_On_Off = New DevComponents.DotNetBar.ButtonItem()
        Me.Metro_Bar_Color = New DevComponents.DotNetBar.Metro.MetroStatusBar()
        Me.Lbl_Estatus = New DevComponents.DotNetBar.LabelItem()
        Me.Txt_Log = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Listv_Programaciones = New DevComponents.DotNetBar.Controls.ListViewEx()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Imagenes_16X16 = New System.Windows.Forms.ImageList(Me.components)
        Me.Circular_Monitoreo = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.Lbl_Monitoreo = New DevComponents.DotNetBar.LabelX()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(628, 60)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(51, 19)
        Me.LabelX5.TabIndex = 71
        Me.LabelX5.Text = "20:00"
        Me.LabelX5.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Lbl_Modalidad
        '
        Me.Lbl_Modalidad.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Modalidad.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Modalidad.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Modalidad.Location = New System.Drawing.Point(12, 49)
        Me.Lbl_Modalidad.Name = "Lbl_Modalidad"
        Me.Lbl_Modalidad.Size = New System.Drawing.Size(605, 23)
        Me.Lbl_Modalidad.TabIndex = 70
        Me.Lbl_Modalidad.Text = "Nombre Equipo..."
        '
        'Lbl_Nombre_Equipo
        '
        Me.Lbl_Nombre_Equipo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Nombre_Equipo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Nombre_Equipo.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Nombre_Equipo.Location = New System.Drawing.Point(12, 29)
        Me.Lbl_Nombre_Equipo.Name = "Lbl_Nombre_Equipo"
        Me.Lbl_Nombre_Equipo.Size = New System.Drawing.Size(605, 23)
        Me.Lbl_Nombre_Equipo.TabIndex = 69
        Me.Lbl_Nombre_Equipo.Text = "Nombre Equipo..."
        '
        'DtpFecharevision
        '
        Me.DtpFecharevision.BackColor = System.Drawing.Color.White
        Me.DtpFecharevision.ForeColor = System.Drawing.Color.Black
        Me.DtpFecharevision.Location = New System.Drawing.Point(12, 3)
        Me.DtpFecharevision.Name = "DtpFecharevision"
        Me.DtpFecharevision.Size = New System.Drawing.Size(216, 22)
        Me.DtpFecharevision.TabIndex = 65
        '
        'BtnCambFecha
        '
        Me.BtnCambFecha.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnCambFecha.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnCambFecha.Image = CType(resources.GetObject("BtnCambFecha.Image"), System.Drawing.Image)
        Me.BtnCambFecha.Location = New System.Drawing.Point(234, 2)
        Me.BtnCambFecha.Name = "BtnCambFecha"
        Me.BtnCambFecha.Size = New System.Drawing.Size(112, 23)
        Me.BtnCambFecha.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnCambFecha.TabIndex = 66
        Me.BtnCambFecha.Text = "Cambiar fecha"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Configurar, Me.Btn_On_Off})
        Me.Bar1.Location = New System.Drawing.Point(0, 607)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(755, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 64
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Configurar
        '
        Me.Btn_Configurar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Configurar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Configurar.Image = CType(resources.GetObject("Btn_Configurar.Image"), System.Drawing.Image)
        Me.Btn_Configurar.ImageAlt = CType(resources.GetObject("Btn_Configurar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Configurar.Name = "Btn_Configurar"
        Me.Btn_Configurar.Text = "Configuración"
        '
        'Btn_On_Off
        '
        Me.Btn_On_Off.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_On_Off.ForeColor = System.Drawing.Color.Black
        Me.Btn_On_Off.Image = CType(resources.GetObject("Btn_On_Off.Image"), System.Drawing.Image)
        Me.Btn_On_Off.ImageAlt = CType(resources.GetObject("Btn_On_Off.ImageAlt"), System.Drawing.Image)
        Me.Btn_On_Off.Name = "Btn_On_Off"
        Me.Btn_On_Off.Text = "Activar-Desactivar"
        Me.Btn_On_Off.Visible = False
        '
        'Metro_Bar_Color
        '
        Me.Metro_Bar_Color.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Metro_Bar_Color.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Metro_Bar_Color.ContainerControlProcessDialogKey = True
        Me.Metro_Bar_Color.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Metro_Bar_Color.DragDropSupport = True
        Me.Metro_Bar_Color.Font = New System.Drawing.Font("Segoe UI", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Metro_Bar_Color.ForeColor = System.Drawing.Color.Black
        Me.Metro_Bar_Color.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Lbl_Estatus})
        Me.Metro_Bar_Color.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.Metro_Bar_Color.Location = New System.Drawing.Point(0, 648)
        Me.Metro_Bar_Color.Name = "Metro_Bar_Color"
        Me.Metro_Bar_Color.Size = New System.Drawing.Size(755, 22)
        Me.Metro_Bar_Color.TabIndex = 72
        Me.Metro_Bar_Color.Text = "MetroStatusBar1"
        '
        'Lbl_Estatus
        '
        Me.Lbl_Estatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Estatus.Name = "Lbl_Estatus"
        Me.Lbl_Estatus.Text = "LabelItem2"
        '
        'Txt_Log
        '
        Me.Txt_Log.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt_Log.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Log.Border.Class = "TextBoxBorder"
        Me.Txt_Log.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Log.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Log.ForeColor = System.Drawing.Color.Black
        Me.Txt_Log.Location = New System.Drawing.Point(12, 418)
        Me.Txt_Log.Multiline = True
        Me.Txt_Log.Name = "Txt_Log"
        Me.Txt_Log.PreventEnterBeep = True
        Me.Txt_Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Log.Size = New System.Drawing.Size(731, 167)
        Me.Txt_Log.TabIndex = 74
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Listv_Programaciones)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 78)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(731, 305)
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
        Me.GroupPanel1.TabIndex = 135
        Me.GroupPanel1.Text = "Programación"
        '
        'Listv_Programaciones
        '
        Me.Listv_Programaciones.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.Listv_Programaciones.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Listv_Programaciones.Border.Class = "ListViewBorder"
        Me.Listv_Programaciones.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Listv_Programaciones.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4, Me.ColumnHeader5})
        Me.Listv_Programaciones.DisabledBackColor = System.Drawing.Color.Empty
        Me.Listv_Programaciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Listv_Programaciones.ForeColor = System.Drawing.Color.Black
        Me.Listv_Programaciones.GridLines = True
        Me.Listv_Programaciones.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.Listv_Programaciones.HideSelection = False
        Me.Listv_Programaciones.HotTracking = True
        Me.Listv_Programaciones.HoverSelection = True
        Me.Listv_Programaciones.Location = New System.Drawing.Point(0, 0)
        Me.Listv_Programaciones.Name = "Listv_Programaciones"
        Me.Listv_Programaciones.Size = New System.Drawing.Size(725, 282)
        Me.Listv_Programaciones.SmallImageList = Me.Imagenes_16X16
        Me.Listv_Programaciones.TabIndex = 138
        Me.Listv_Programaciones.UseCompatibleStateImageBehavior = False
        Me.Listv_Programaciones.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Descripción"
        Me.ColumnHeader4.Width = 223
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Programación"
        Me.ColumnHeader5.Width = 500
        '
        'Imagenes_16X16
        '
        Me.Imagenes_16X16.ImageStream = CType(resources.GetObject("Imagenes_16X16.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagenes_16X16.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagenes_16X16.Images.SetKeyName(0, "mail.png")
        Me.Imagenes_16X16.Images.SetKeyName(1, "document-printer.png")
        Me.Imagenes_16X16.Images.SetKeyName(2, "bill-credit-card-printer.png")
        Me.Imagenes_16X16.Images.SetKeyName(3, "button-ok.png")
        '
        'Circular_Monitoreo
        '
        Me.Circular_Monitoreo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Circular_Monitoreo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Circular_Monitoreo.FocusCuesEnabled = False
        Me.Circular_Monitoreo.Location = New System.Drawing.Point(13, 386)
        Me.Circular_Monitoreo.Name = "Circular_Monitoreo"
        Me.Circular_Monitoreo.ProgressColor = System.Drawing.Color.Green
        Me.Circular_Monitoreo.Size = New System.Drawing.Size(28, 26)
        Me.Circular_Monitoreo.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.Circular_Monitoreo.TabIndex = 136
        '
        'Lbl_Monitoreo
        '
        Me.Lbl_Monitoreo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Monitoreo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Monitoreo.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Monitoreo.Location = New System.Drawing.Point(47, 389)
        Me.Lbl_Monitoreo.Name = "Lbl_Monitoreo"
        Me.Lbl_Monitoreo.Size = New System.Drawing.Size(605, 23)
        Me.Lbl_Monitoreo.TabIndex = 137
        Me.Lbl_Monitoreo.Text = "MONITOREO ACTIVO..."
        '
        'Frm_Demonio_New
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(755, 670)
        Me.Controls.Add(Me.Lbl_Monitoreo)
        Me.Controls.Add(Me.Circular_Monitoreo)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Txt_Log)
        Me.Controls.Add(Me.LabelX5)
        Me.Controls.Add(Me.Lbl_Modalidad)
        Me.Controls.Add(Me.Lbl_Nombre_Equipo)
        Me.Controls.Add(Me.DtpFecharevision)
        Me.Controls.Add(Me.BtnCambFecha)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.Metro_Bar_Color)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.Name = "Frm_Demonio_New"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Modalidad As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Nombre_Equipo As DevComponents.DotNetBar.LabelX
    Friend WithEvents DtpFecharevision As DateTimePicker
    Friend WithEvents BtnCambFecha As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Configurar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_On_Off As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Metro_Bar_Color As DevComponents.DotNetBar.Metro.MetroStatusBar
    Friend WithEvents Lbl_Estatus As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Txt_Log As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Listv_Programaciones As DevComponents.DotNetBar.Controls.ListViewEx
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents Imagenes_16X16 As ImageList
    Friend WithEvents Circular_Monitoreo As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Lbl_Monitoreo As DevComponents.DotNetBar.LabelX
End Class
