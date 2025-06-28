<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ImpMasiva
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ImpMasiva))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Chk_Marcar_Todas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_01 = New DevComponents.DotNetBar.ButtonItem()
        Me.Lbl_Mnu_Idmaeedo = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Ver_Documento = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Enviar_Correo_Adjunto = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Cambiar_Entidad_Documento = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Imprimir_Documento = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Firmar_Documento = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Facturar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_CopiarDocOtrEmpresa = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem3 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Copiar = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Imprimir = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Cancelar = New DevComponents.DotNetBar.ButtonItem()
        Me.MetroStatusBar1 = New DevComponents.DotNetBar.Metro.MetroStatusBar()
        Me.Barra_Progreso = New DevComponents.DotNetBar.ProgressBarItem()
        Me.Lbl_Status = New DevComponents.DotNetBar.LabelItem()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_NombreFormato = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Impresora = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Chk_ImprimirCedible = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Chk_Marcar_Todas
        '
        Me.Chk_Marcar_Todas.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Marcar_Todas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Marcar_Todas.CheckBoxImageChecked = CType(resources.GetObject("Chk_Marcar_Todas.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Marcar_Todas.FocusCuesEnabled = False
        Me.Chk_Marcar_Todas.ForeColor = System.Drawing.Color.Black
        Me.Chk_Marcar_Todas.Location = New System.Drawing.Point(12, 515)
        Me.Chk_Marcar_Todas.Name = "Chk_Marcar_Todas"
        Me.Chk_Marcar_Todas.Size = New System.Drawing.Size(100, 20)
        Me.Chk_Marcar_Todas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Marcar_Todas.TabIndex = 54
        Me.Chk_Marcar_Todas.Text = "Marcar todas"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.ContextMenuBar1)
        Me.GroupPanel1.Controls.Add(Me.Grilla)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 4)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(715, 505)
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
        Me.GroupPanel1.TabIndex = 52
        Me.GroupPanel1.Text = "Documentos"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_01})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(310, 23)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(153, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 45
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_01
        '
        Me.Menu_Contextual_01.AutoExpandOnClick = True
        Me.Menu_Contextual_01.Name = "Menu_Contextual_01"
        Me.Menu_Contextual_01.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Lbl_Mnu_Idmaeedo, Me.Btn_Ver_Documento, Me.Btn_Enviar_Correo_Adjunto, Me.LabelItem2, Me.Btn_Cambiar_Entidad_Documento, Me.Btn_Imprimir_Documento, Me.Btn_Firmar_Documento, Me.Btn_Facturar, Me.Btn_CopiarDocOtrEmpresa, Me.LabelItem3, Me.Btn_Copiar})
        Me.Menu_Contextual_01.Text = "Opciones"
        '
        'Lbl_Mnu_Idmaeedo
        '
        Me.Lbl_Mnu_Idmaeedo.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Lbl_Mnu_Idmaeedo.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.Lbl_Mnu_Idmaeedo.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.Lbl_Mnu_Idmaeedo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.Lbl_Mnu_Idmaeedo.Name = "Lbl_Mnu_Idmaeedo"
        Me.Lbl_Mnu_Idmaeedo.PaddingBottom = 1
        Me.Lbl_Mnu_Idmaeedo.PaddingLeft = 10
        Me.Lbl_Mnu_Idmaeedo.PaddingTop = 1
        Me.Lbl_Mnu_Idmaeedo.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.Lbl_Mnu_Idmaeedo.Text = "Opciones"
        '
        'Btn_Ver_Documento
        '
        Me.Btn_Ver_Documento.Image = CType(resources.GetObject("Btn_Ver_Documento.Image"), System.Drawing.Image)
        Me.Btn_Ver_Documento.ImageAlt = CType(resources.GetObject("Btn_Ver_Documento.ImageAlt"), System.Drawing.Image)
        Me.Btn_Ver_Documento.Name = "Btn_Ver_Documento"
        Me.Btn_Ver_Documento.Text = "Ver documento"
        '
        'Btn_Enviar_Correo_Adjunto
        '
        Me.Btn_Enviar_Correo_Adjunto.Image = CType(resources.GetObject("Btn_Enviar_Correo_Adjunto.Image"), System.Drawing.Image)
        Me.Btn_Enviar_Correo_Adjunto.ImageAlt = CType(resources.GetObject("Btn_Enviar_Correo_Adjunto.ImageAlt"), System.Drawing.Image)
        Me.Btn_Enviar_Correo_Adjunto.Name = "Btn_Enviar_Correo_Adjunto"
        Me.Btn_Enviar_Correo_Adjunto.Text = "Enviar documento por correo"
        '
        'LabelItem2
        '
        Me.LabelItem2.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem2.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem2.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem2.Name = "LabelItem2"
        Me.LabelItem2.PaddingBottom = 1
        Me.LabelItem2.PaddingLeft = 10
        Me.LabelItem2.PaddingTop = 1
        Me.LabelItem2.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem2.Text = "Opciones especiales"
        '
        'Btn_Cambiar_Entidad_Documento
        '
        Me.Btn_Cambiar_Entidad_Documento.Image = CType(resources.GetObject("Btn_Cambiar_Entidad_Documento.Image"), System.Drawing.Image)
        Me.Btn_Cambiar_Entidad_Documento.ImageAlt = CType(resources.GetObject("Btn_Cambiar_Entidad_Documento.ImageAlt"), System.Drawing.Image)
        Me.Btn_Cambiar_Entidad_Documento.Name = "Btn_Cambiar_Entidad_Documento"
        Me.Btn_Cambiar_Entidad_Documento.Text = "Cambiar entidad del documento"
        '
        'Btn_Imprimir_Documento
        '
        Me.Btn_Imprimir_Documento.Image = CType(resources.GetObject("Btn_Imprimir_Documento.Image"), System.Drawing.Image)
        Me.Btn_Imprimir_Documento.ImageAlt = CType(resources.GetObject("Btn_Imprimir_Documento.ImageAlt"), System.Drawing.Image)
        Me.Btn_Imprimir_Documento.Name = "Btn_Imprimir_Documento"
        Me.Btn_Imprimir_Documento.Text = "Imprimir documento"
        '
        'Btn_Firmar_Documento
        '
        Me.Btn_Firmar_Documento.Image = CType(resources.GetObject("Btn_Firmar_Documento.Image"), System.Drawing.Image)
        Me.Btn_Firmar_Documento.ImageAlt = CType(resources.GetObject("Btn_Firmar_Documento.ImageAlt"), System.Drawing.Image)
        Me.Btn_Firmar_Documento.Name = "Btn_Firmar_Documento"
        Me.Btn_Firmar_Documento.Text = "Firmar documento Electrónicamente"
        '
        'Btn_Facturar
        '
        Me.Btn_Facturar.Image = CType(resources.GetObject("Btn_Facturar.Image"), System.Drawing.Image)
        Me.Btn_Facturar.ImageAlt = CType(resources.GetObject("Btn_Facturar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Facturar.Name = "Btn_Facturar"
        Me.Btn_Facturar.Text = "Facturar"
        '
        'Btn_CopiarDocOtrEmpresa
        '
        Me.Btn_CopiarDocOtrEmpresa.Image = CType(resources.GetObject("Btn_CopiarDocOtrEmpresa.Image"), System.Drawing.Image)
        Me.Btn_CopiarDocOtrEmpresa.ImageAlt = CType(resources.GetObject("Btn_CopiarDocOtrEmpresa.ImageAlt"), System.Drawing.Image)
        Me.Btn_CopiarDocOtrEmpresa.Name = "Btn_CopiarDocOtrEmpresa"
        Me.Btn_CopiarDocOtrEmpresa.Text = "Copiar documento en otra empresa"
        '
        'LabelItem3
        '
        Me.LabelItem3.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem3.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem3.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem3.Name = "LabelItem3"
        Me.LabelItem3.PaddingBottom = 1
        Me.LabelItem3.PaddingLeft = 10
        Me.LabelItem3.PaddingTop = 1
        Me.LabelItem3.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem3.Text = "-----------------------------------------"
        '
        'Btn_Copiar
        '
        Me.Btn_Copiar.Image = CType(resources.GetObject("Btn_Copiar.Image"), System.Drawing.Image)
        Me.Btn_Copiar.ImageAlt = CType(resources.GetObject("Btn_Copiar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Copiar.Name = "Btn_Copiar"
        Me.Btn_Copiar.Text = "Copiar (portapapeles)"
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.AllowUserToDeleteRows = False
        Me.Grilla.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla.EnableHeadersVisualStyles = False
        Me.Grilla.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla.Location = New System.Drawing.Point(0, 0)
        Me.Grilla.Name = "Grilla"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla.Size = New System.Drawing.Size(709, 482)
        Me.Grilla.StandardTab = True
        Me.Grilla.TabIndex = 28
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Imprimir, Me.Btn_Cancelar})
        Me.Bar1.Location = New System.Drawing.Point(0, 576)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(735, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 49
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Imprimir
        '
        Me.Btn_Imprimir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Imprimir.ForeColor = System.Drawing.Color.Black
        Me.Btn_Imprimir.Image = CType(resources.GetObject("Btn_Imprimir.Image"), System.Drawing.Image)
        Me.Btn_Imprimir.ImageAlt = CType(resources.GetObject("Btn_Imprimir.ImageAlt"), System.Drawing.Image)
        Me.Btn_Imprimir.Name = "Btn_Imprimir"
        Me.Btn_Imprimir.Text = "Imprimir"
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Cancelar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Cancelar.Image = CType(resources.GetObject("Btn_Cancelar.Image"), System.Drawing.Image)
        Me.Btn_Cancelar.ImageAlt = CType(resources.GetObject("Btn_Cancelar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Text = "Detener impresión"
        Me.Btn_Cancelar.Visible = False
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
        Me.MetroStatusBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Barra_Progreso, Me.Lbl_Status})
        Me.MetroStatusBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MetroStatusBar1.Location = New System.Drawing.Point(0, 617)
        Me.MetroStatusBar1.Name = "MetroStatusBar1"
        Me.MetroStatusBar1.Size = New System.Drawing.Size(735, 22)
        Me.MetroStatusBar1.TabIndex = 55
        Me.MetroStatusBar1.Text = "MetroStatusBar1"
        '
        'Barra_Progreso
        '
        '
        '
        '
        Me.Barra_Progreso.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Barra_Progreso.ChunkGradientAngle = 0!
        Me.Barra_Progreso.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.Barra_Progreso.Name = "Barra_Progreso"
        Me.Barra_Progreso.RecentlyUsed = False
        Me.Barra_Progreso.Visible = False
        '
        'Lbl_Status
        '
        Me.Lbl_Status.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Lbl_Status.Name = "Lbl_Status"
        Me.Lbl_Status.Text = "Status..."
        '
        'LabelX9
        '
        Me.LabelX9.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.ForeColor = System.Drawing.Color.Black
        Me.LabelX9.Location = New System.Drawing.Point(328, 544)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(91, 19)
        Me.LabelX9.TabIndex = 112
        Me.LabelX9.Text = "Nombre formato"
        '
        'LabelX11
        '
        Me.LabelX11.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX11.ForeColor = System.Drawing.Color.Black
        Me.LabelX11.Location = New System.Drawing.Point(12, 541)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(63, 19)
        Me.LabelX11.TabIndex = 111
        Me.LabelX11.Text = "Impresora"
        '
        'Txt_NombreFormato
        '
        Me.Txt_NombreFormato.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_NombreFormato.Border.Class = "TextBoxBorder"
        Me.Txt_NombreFormato.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_NombreFormato.ButtonCustom.Image = CType(resources.GetObject("Txt_NombreFormato.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_NombreFormato.ButtonCustom.Visible = True
        Me.Txt_NombreFormato.ButtonCustom2.Image = CType(resources.GetObject("Txt_NombreFormato.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_NombreFormato.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_NombreFormato.ForeColor = System.Drawing.Color.Black
        Me.Txt_NombreFormato.Location = New System.Drawing.Point(425, 541)
        Me.Txt_NombreFormato.Name = "Txt_NombreFormato"
        Me.Txt_NombreFormato.PreventEnterBeep = True
        Me.Txt_NombreFormato.Size = New System.Drawing.Size(302, 22)
        Me.Txt_NombreFormato.TabIndex = 110
        Me.Txt_NombreFormato.WatermarkText = "Nombre de formato"
        '
        'Txt_Impresora
        '
        Me.Txt_Impresora.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Impresora.Border.Class = "TextBoxBorder"
        Me.Txt_Impresora.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Impresora.ButtonCustom.Image = CType(resources.GetObject("Txt_Impresora.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Impresora.ButtonCustom.Visible = True
        Me.Txt_Impresora.ButtonCustom2.Image = CType(resources.GetObject("Txt_Impresora.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Impresora.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Impresora.ForeColor = System.Drawing.Color.Black
        Me.Txt_Impresora.Location = New System.Drawing.Point(71, 541)
        Me.Txt_Impresora.Name = "Txt_Impresora"
        Me.Txt_Impresora.PreventEnterBeep = True
        Me.Txt_Impresora.Size = New System.Drawing.Size(229, 22)
        Me.Txt_Impresora.TabIndex = 109
        Me.Txt_Impresora.WatermarkText = "Nombre de impresora"
        '
        'Chk_ImprimirCedible
        '
        Me.Chk_ImprimirCedible.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_ImprimirCedible.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_ImprimirCedible.CheckBoxImageChecked = CType(resources.GetObject("Chk_ImprimirCedible.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_ImprimirCedible.FocusCuesEnabled = False
        Me.Chk_ImprimirCedible.ForeColor = System.Drawing.Color.Black
        Me.Chk_ImprimirCedible.Location = New System.Drawing.Point(627, 512)
        Me.Chk_ImprimirCedible.Name = "Chk_ImprimirCedible"
        Me.Chk_ImprimirCedible.Size = New System.Drawing.Size(100, 20)
        Me.Chk_ImprimirCedible.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_ImprimirCedible.TabIndex = 113
        Me.Chk_ImprimirCedible.Text = "Imprimir Cedible"
        '
        'Frm_ImpMasiva
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(735, 639)
        Me.Controls.Add(Me.Chk_ImprimirCedible)
        Me.Controls.Add(Me.Txt_Impresora)
        Me.Controls.Add(Me.Txt_NombreFormato)
        Me.Controls.Add(Me.LabelX9)
        Me.Controls.Add(Me.LabelX11)
        Me.Controls.Add(Me.Chk_Marcar_Todas)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.MetroStatusBar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_ImpMasiva"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "IMPRESION MASIVA DE DOCUMENTOS"
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Chk_Marcar_Todas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_01 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Lbl_Mnu_Idmaeedo As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Ver_Documento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Enviar_Correo_Adjunto As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Cambiar_Entidad_Documento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Imprimir_Documento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Firmar_Documento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Facturar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_CopiarDocOtrEmpresa As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem3 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Copiar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Public WithEvents Btn_Imprimir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Cancelar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroStatusBar1 As DevComponents.DotNetBar.Metro.MetroStatusBar
    Friend WithEvents Barra_Progreso As DevComponents.DotNetBar.ProgressBarItem
    Friend WithEvents Lbl_Status As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_NombreFormato As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Impresora As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Chk_ImprimirCedible As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
