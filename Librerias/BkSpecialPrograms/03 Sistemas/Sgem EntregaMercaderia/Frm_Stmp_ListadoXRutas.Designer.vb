<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Stmp_ListadoXRutas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Stmp_ListadoXRutas))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Btn_Mnu_Preparacion = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_CerrarTicket = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_ReenviaFacturar = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem3 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Copiar = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_01_Opciones_AgregarTicket = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_AgregarConNumero = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_AgregarBuscando = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Imagenes_16x16 = New System.Windows.Forms.ImageList(Me.components)
        Me.Imagenes_16x16_Dark = New System.Windows.Forms.ImageList(Me.components)
        Me.Metro_Bar_Color = New DevComponents.DotNetBar.Metro.MetroStatusBar()
        Me.Lbl_Estatus = New DevComponents.DotNetBar.LabelItem()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Filtrar = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Btn_Mnu_EntregarMercaderia = New DevComponents.DotNetBar.ButtonItem()
        Me.Lbl_Informacion = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Imprimir = New DevComponents.DotNetBar.ButtonItem()
        Me.Tab_Todas = New DevComponents.DotNetBar.SuperTabItem()
        Me.Super_TabS = New DevComponents.DotNetBar.SuperTabStrip()
        Me.Tab_Ingresadas = New DevComponents.DotNetBar.SuperTabItem()
        Me.Tab_Preparacion = New DevComponents.DotNetBar.SuperTabItem()
        Me.Tab_Completadas = New DevComponents.DotNetBar.SuperTabItem()
        Me.Tab_Facturadas = New DevComponents.DotNetBar.SuperTabItem()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_ImpFacMasiva = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Exportar_Excel = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Actualizar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_ConfLocal = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Menu_Contextual = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_01_Opciones_Documento = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_VerDocumento = New DevComponents.DotNetBar.ButtonItem()
        Me.Dtp_FechaDesde = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Cmb_FiltroFecha = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Dtp_FechaHasta = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Super_TabS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Menu_Contextual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_FechaDesde, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_FechaHasta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Btn_Mnu_Preparacion
        '
        Me.Btn_Mnu_Preparacion.Image = CType(resources.GetObject("Btn_Mnu_Preparacion.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Preparacion.ImageAlt = CType(resources.GetObject("Btn_Mnu_Preparacion.ImageAlt"), System.Drawing.Image)
        Me.Btn_Mnu_Preparacion.Name = "Btn_Mnu_Preparacion"
        Me.Btn_Mnu_Preparacion.Text = "Enviar a preparación "
        '
        'Btn_CerrarTicket
        '
        Me.Btn_CerrarTicket.Image = CType(resources.GetObject("Btn_CerrarTicket.Image"), System.Drawing.Image)
        Me.Btn_CerrarTicket.ImageAlt = CType(resources.GetObject("Btn_CerrarTicket.ImageAlt"), System.Drawing.Image)
        Me.Btn_CerrarTicket.Name = "Btn_CerrarTicket"
        Me.Btn_CerrarTicket.Text = "Cerrar Ticket"
        '
        'Btn_ReenviaFacturar
        '
        Me.Btn_ReenviaFacturar.Image = CType(resources.GetObject("Btn_ReenviaFacturar.Image"), System.Drawing.Image)
        Me.Btn_ReenviaFacturar.ImageAlt = CType(resources.GetObject("Btn_ReenviaFacturar.ImageAlt"), System.Drawing.Image)
        Me.Btn_ReenviaFacturar.Name = "Btn_ReenviaFacturar"
        Me.Btn_ReenviaFacturar.Text = "Volver a enviar a facturar automáticamente"
        Me.Btn_ReenviaFacturar.Visible = False
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
        'Menu_Contextual_01_Opciones_AgregarTicket
        '
        Me.Menu_Contextual_01_Opciones_AgregarTicket.AutoExpandOnClick = True
        Me.Menu_Contextual_01_Opciones_AgregarTicket.Name = "Menu_Contextual_01_Opciones_AgregarTicket"
        Me.Menu_Contextual_01_Opciones_AgregarTicket.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem2, Me.Btn_AgregarConNumero, Me.Btn_AgregarBuscando})
        Me.Menu_Contextual_01_Opciones_AgregarTicket.Text = "Opciones documento"
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
        Me.LabelItem2.Text = "Opciones"
        '
        'Btn_AgregarConNumero
        '
        Me.Btn_AgregarConNumero.Image = CType(resources.GetObject("Btn_AgregarConNumero.Image"), System.Drawing.Image)
        Me.Btn_AgregarConNumero.ImageAlt = CType(resources.GetObject("Btn_AgregarConNumero.ImageAlt"), System.Drawing.Image)
        Me.Btn_AgregarConNumero.Name = "Btn_AgregarConNumero"
        Me.Btn_AgregarConNumero.Text = "Agregar Ticket buscando por numero de nota de venta"
        '
        'Btn_AgregarBuscando
        '
        Me.Btn_AgregarBuscando.Image = CType(resources.GetObject("Btn_AgregarBuscando.Image"), System.Drawing.Image)
        Me.Btn_AgregarBuscando.ImageAlt = CType(resources.GetObject("Btn_AgregarBuscando.ImageAlt"), System.Drawing.Image)
        Me.Btn_AgregarBuscando.Name = "Btn_AgregarBuscando"
        Me.Btn_AgregarBuscando.Text = "Crear nuevo Ticket buscando nota de venta"
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
        Me.Grilla.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla.Size = New System.Drawing.Size(1176, 433)
        Me.Grilla.StandardTab = True
        Me.Grilla.TabIndex = 27
        '
        'Imagenes_16x16
        '
        Me.Imagenes_16x16.ImageStream = CType(resources.GetObject("Imagenes_16x16.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagenes_16x16.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagenes_16x16.Images.SetKeyName(0, "warning.png")
        Me.Imagenes_16x16.Images.SetKeyName(1, "ok.png")
        Me.Imagenes_16x16.Images.SetKeyName(2, "cancel.png")
        Me.Imagenes_16x16.Images.SetKeyName(3, "delete_button_error.png")
        Me.Imagenes_16x16.Images.SetKeyName(4, "clock.png")
        Me.Imagenes_16x16.Images.SetKeyName(5, "clock-import.png")
        Me.Imagenes_16x16.Images.SetKeyName(6, "clock-info.png")
        Me.Imagenes_16x16.Images.SetKeyName(7, "tag_green.png")
        Me.Imagenes_16x16.Images.SetKeyName(8, "note_text.png")
        Me.Imagenes_16x16.Images.SetKeyName(9, "note.png")
        Me.Imagenes_16x16.Images.SetKeyName(10, "comment-number-1.png")
        Me.Imagenes_16x16.Images.SetKeyName(11, "comment-number-2.png")
        Me.Imagenes_16x16.Images.SetKeyName(12, "comment-number-3.png")
        Me.Imagenes_16x16.Images.SetKeyName(13, "comment-number-4.png")
        Me.Imagenes_16x16.Images.SetKeyName(14, "comment-number-5.png")
        Me.Imagenes_16x16.Images.SetKeyName(15, "comment-number-6.png")
        Me.Imagenes_16x16.Images.SetKeyName(16, "comment-number-7.png")
        Me.Imagenes_16x16.Images.SetKeyName(17, "comment-number-8.png")
        Me.Imagenes_16x16.Images.SetKeyName(18, "comment-number-9.png")
        Me.Imagenes_16x16.Images.SetKeyName(19, "comment-number-9-plus.png")
        Me.Imagenes_16x16.Images.SetKeyName(20, "menu-more.png")
        Me.Imagenes_16x16.Images.SetKeyName(21, "symbol-delete.png")
        Me.Imagenes_16x16.Images.SetKeyName(22, "symbol-ok-warning.png")
        Me.Imagenes_16x16.Images.SetKeyName(23, "symbol-remove.png")
        '
        'Imagenes_16x16_Dark
        '
        Me.Imagenes_16x16_Dark.ImageStream = CType(resources.GetObject("Imagenes_16x16_Dark.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagenes_16x16_Dark.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagenes_16x16_Dark.Images.SetKeyName(0, "warning.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(1, "ok.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(2, "cancel.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(3, "delete_button_error.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(4, "clock.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(5, "clock-import.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(6, "clock-info.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(7, "tag_green.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(8, "note_text.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(9, "note.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(10, "menu-more.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(11, "comment-number-9.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(12, "comment-number-9-plus.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(13, "comment-number-8.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(14, "comment-number-7.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(15, "comment-number-6.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(16, "comment-number-5.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(17, "comment-number-4.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(18, "comment-number-3.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(19, "comment-number-2.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(20, "comment-number-1.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(21, "symbol-delete.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(22, "symbol-ok-warning.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(23, "symbol-remove.png")
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
        Me.Metro_Bar_Color.Location = New System.Drawing.Point(0, 574)
        Me.Metro_Bar_Color.Name = "Metro_Bar_Color"
        Me.Metro_Bar_Color.Size = New System.Drawing.Size(1201, 22)
        Me.Metro_Bar_Color.TabIndex = 183
        Me.Metro_Bar_Color.Text = "MetroStatusBar1"
        '
        'Lbl_Estatus
        '
        Me.Lbl_Estatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Estatus.Name = "Lbl_Estatus"
        Me.Lbl_Estatus.Text = "LabelItem2"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Image = CType(resources.GetObject("LabelX1.Image"), System.Drawing.Image)
        Me.LabelX1.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right
        Me.LabelX1.ImageTextSpacing = 3
        Me.LabelX1.Location = New System.Drawing.Point(887, 11)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(57, 23)
        Me.LabelX1.TabIndex = 185
        Me.LabelX1.Text = "Buscar"
        '
        'Txt_Filtrar
        '
        Me.Txt_Filtrar.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Filtrar.Border.Class = "TextBoxBorder"
        Me.Txt_Filtrar.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Filtrar.ButtonCustom.Image = CType(resources.GetObject("Txt_Filtrar.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Filtrar.ButtonCustom.Visible = True
        Me.Txt_Filtrar.ButtonCustom2.Image = CType(resources.GetObject("Txt_Filtrar.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Filtrar.ButtonCustom2.Visible = True
        Me.Txt_Filtrar.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Filtrar.ForeColor = System.Drawing.Color.Black
        Me.Txt_Filtrar.Location = New System.Drawing.Point(950, 11)
        Me.Txt_Filtrar.Name = "Txt_Filtrar"
        Me.Txt_Filtrar.PreventEnterBeep = True
        Me.Txt_Filtrar.Size = New System.Drawing.Size(244, 22)
        Me.Txt_Filtrar.TabIndex = 184
        '
        'Btn_Mnu_EntregarMercaderia
        '
        Me.Btn_Mnu_EntregarMercaderia.Image = CType(resources.GetObject("Btn_Mnu_EntregarMercaderia.Image"), System.Drawing.Image)
        Me.Btn_Mnu_EntregarMercaderia.ImageAlt = CType(resources.GetObject("Btn_Mnu_EntregarMercaderia.ImageAlt"), System.Drawing.Image)
        Me.Btn_Mnu_EntregarMercaderia.Name = "Btn_Mnu_EntregarMercaderia"
        Me.Btn_Mnu_EntregarMercaderia.Text = "Entregar mercadería"
        '
        'Lbl_Informacion
        '
        Me.Lbl_Informacion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Informacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Informacion.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Informacion.Location = New System.Drawing.Point(79, 501)
        Me.Lbl_Informacion.Name = "Lbl_Informacion"
        Me.Lbl_Informacion.Size = New System.Drawing.Size(1115, 23)
        Me.Lbl_Informacion.TabIndex = 188
        Me.Lbl_Informacion.Text = "..."
        '
        'Btn_Imprimir
        '
        Me.Btn_Imprimir.Image = CType(resources.GetObject("Btn_Imprimir.Image"), System.Drawing.Image)
        Me.Btn_Imprimir.ImageAlt = CType(resources.GetObject("Btn_Imprimir.ImageAlt"), System.Drawing.Image)
        Me.Btn_Imprimir.Name = "Btn_Imprimir"
        Me.Btn_Imprimir.Text = "Imprimir"
        '
        'Tab_Todas
        '
        Me.Tab_Todas.GlobalItem = False
        Me.Tab_Todas.Name = "Tab_Todas"
        Me.Tab_Todas.Text = "Todas"
        '
        'Super_TabS
        '
        Me.Super_TabS.AutoSelectAttachedControl = False
        Me.Super_TabS.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Super_TabS.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Super_TabS.ContainerControlProcessDialogKey = True
        '
        '
        '
        '
        '
        '
        Me.Super_TabS.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.Super_TabS.ControlBox.MenuBox.Name = ""
        Me.Super_TabS.ControlBox.Name = ""
        Me.Super_TabS.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Super_TabS.ControlBox.MenuBox, Me.Super_TabS.ControlBox.CloseBox})
        Me.Super_TabS.ForeColor = System.Drawing.Color.Black
        Me.Super_TabS.Location = New System.Drawing.Point(12, 6)
        Me.Super_TabS.Name = "Super_TabS"
        Me.Super_TabS.ReorderTabsEnabled = True
        Me.Super_TabS.SelectedTabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Super_TabS.SelectedTabIndex = 0
        Me.Super_TabS.Size = New System.Drawing.Size(395, 27)
        Me.Super_TabS.TabCloseButtonHot = Nothing
        Me.Super_TabS.TabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Super_TabS.TabIndex = 180
        Me.Super_TabS.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Tab_Todas, Me.Tab_Ingresadas, Me.Tab_Preparacion, Me.Tab_Completadas, Me.Tab_Facturadas})
        Me.Super_TabS.Text = "Nulas"
        '
        'Tab_Ingresadas
        '
        Me.Tab_Ingresadas.GlobalItem = False
        Me.Tab_Ingresadas.Name = "Tab_Ingresadas"
        Me.Tab_Ingresadas.Text = "Ingresadas"
        '
        'Tab_Preparacion
        '
        Me.Tab_Preparacion.GlobalItem = False
        Me.Tab_Preparacion.Name = "Tab_Preparacion"
        Me.Tab_Preparacion.Text = "En preparación"
        '
        'Tab_Completadas
        '
        Me.Tab_Completadas.GlobalItem = False
        Me.Tab_Completadas.Name = "Tab_Completadas"
        Me.Tab_Completadas.Text = "Completadas"
        '
        'Tab_Facturadas
        '
        Me.Tab_Facturadas.GlobalItem = False
        Me.Tab_Facturadas.Name = "Tab_Facturadas"
        Me.Tab_Facturadas.Text = "Facturadas"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_ImpFacMasiva, Me.Btn_Exportar_Excel, Me.Btn_Actualizar, Me.Btn_ConfLocal})
        Me.Bar2.Location = New System.Drawing.Point(0, 533)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(1201, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 179
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_ImpFacMasiva
        '
        Me.Btn_ImpFacMasiva.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_ImpFacMasiva.ForeColor = System.Drawing.Color.Black
        Me.Btn_ImpFacMasiva.Image = CType(resources.GetObject("Btn_ImpFacMasiva.Image"), System.Drawing.Image)
        Me.Btn_ImpFacMasiva.ImageAlt = CType(resources.GetObject("Btn_ImpFacMasiva.ImageAlt"), System.Drawing.Image)
        Me.Btn_ImpFacMasiva.Name = "Btn_ImpFacMasiva"
        Me.Btn_ImpFacMasiva.Text = "Imprimir facturas masivamente"
        '
        'Btn_Exportar_Excel
        '
        Me.Btn_Exportar_Excel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Exportar_Excel.ForeColor = System.Drawing.Color.Black
        Me.Btn_Exportar_Excel.Image = CType(resources.GetObject("Btn_Exportar_Excel.Image"), System.Drawing.Image)
        Me.Btn_Exportar_Excel.ImageAlt = CType(resources.GetObject("Btn_Exportar_Excel.ImageAlt"), System.Drawing.Image)
        Me.Btn_Exportar_Excel.Name = "Btn_Exportar_Excel"
        Me.Btn_Exportar_Excel.Tooltip = "Exportar a Excel"
        '
        'Btn_Actualizar
        '
        Me.Btn_Actualizar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Actualizar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Actualizar.Image = CType(resources.GetObject("Btn_Actualizar.Image"), System.Drawing.Image)
        Me.Btn_Actualizar.ImageAlt = CType(resources.GetObject("Btn_Actualizar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Actualizar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Actualizar.Name = "Btn_Actualizar"
        Me.Btn_Actualizar.Tooltip = "Refrescar datos"
        '
        'Btn_ConfLocal
        '
        Me.Btn_ConfLocal.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_ConfLocal.ForeColor = System.Drawing.Color.Black
        Me.Btn_ConfLocal.Image = CType(resources.GetObject("Btn_ConfLocal.Image"), System.Drawing.Image)
        Me.Btn_ConfLocal.ImageAlt = CType(resources.GetObject("Btn_ConfLocal.ImageAlt"), System.Drawing.Image)
        Me.Btn_ConfLocal.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_ConfLocal.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.Btn_ConfLocal.Name = "Btn_ConfLocal"
        Me.Btn_ConfLocal.Tooltip = "Agregar Ticket buscando por numero de nota de venta"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(12, 501)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 23)
        Me.LabelX2.TabIndex = 187
        Me.LabelX2.Text = "Información:"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Menu_Contextual)
        Me.GroupPanel1.Controls.Add(Me.Grilla)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 39)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(1182, 456)
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
        Me.GroupPanel1.TabIndex = 178
        Me.GroupPanel1.Text = "Detalle de Tickets por entrega de mercadería"
        '
        'Menu_Contextual
        '
        Me.Menu_Contextual.AntiAlias = True
        Me.Menu_Contextual.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Menu_Contextual.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_01_Opciones_Documento, Me.Menu_Contextual_01_Opciones_AgregarTicket})
        Me.Menu_Contextual.Location = New System.Drawing.Point(26, 27)
        Me.Menu_Contextual.Name = "Menu_Contextual"
        Me.Menu_Contextual.Size = New System.Drawing.Size(412, 25)
        Me.Menu_Contextual.Stretch = True
        Me.Menu_Contextual.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Menu_Contextual.TabIndex = 48
        Me.Menu_Contextual.TabStop = False
        Me.Menu_Contextual.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_01_Opciones_Documento
        '
        Me.Menu_Contextual_01_Opciones_Documento.AutoExpandOnClick = True
        Me.Menu_Contextual_01_Opciones_Documento.Name = "Menu_Contextual_01_Opciones_Documento"
        Me.Menu_Contextual_01_Opciones_Documento.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1, Me.Btn_VerDocumento, Me.Btn_Imprimir, Me.Btn_Mnu_Preparacion, Me.Btn_Mnu_EntregarMercaderia, Me.Btn_CerrarTicket, Me.Btn_ReenviaFacturar, Me.LabelItem3, Me.Btn_Copiar})
        Me.Menu_Contextual_01_Opciones_Documento.Text = "Opciones documento"
        '
        'LabelItem1
        '
        Me.LabelItem1.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem1.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem1.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem1.Name = "LabelItem1"
        Me.LabelItem1.PaddingBottom = 1
        Me.LabelItem1.PaddingLeft = 10
        Me.LabelItem1.PaddingTop = 1
        Me.LabelItem1.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem1.Text = "Opciones"
        '
        'Btn_VerDocumento
        '
        Me.Btn_VerDocumento.Image = CType(resources.GetObject("Btn_VerDocumento.Image"), System.Drawing.Image)
        Me.Btn_VerDocumento.ImageAlt = CType(resources.GetObject("Btn_VerDocumento.ImageAlt"), System.Drawing.Image)
        Me.Btn_VerDocumento.Name = "Btn_VerDocumento"
        Me.Btn_VerDocumento.Text = "Ver documento"
        '
        'Dtp_FechaDesde
        '
        Me.Dtp_FechaDesde.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_FechaDesde.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_FechaDesde.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaDesde.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_FechaDesde.ButtonDropDown.Visible = True
        Me.Dtp_FechaDesde.ForeColor = System.Drawing.Color.Black
        Me.Dtp_FechaDesde.IsPopupCalendarOpen = False
        Me.Dtp_FechaDesde.Location = New System.Drawing.Point(679, 10)
        '
        '
        '
        Me.Dtp_FechaDesde.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FechaDesde.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaDesde.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_FechaDesde.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_FechaDesde.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_FechaDesde.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FechaDesde.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_FechaDesde.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_FechaDesde.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_FechaDesde.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_FechaDesde.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaDesde.MonthCalendar.DisplayMonth = New Date(2025, 1, 1, 0, 0, 0, 0)
        Me.Dtp_FechaDesde.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_FechaDesde.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_FechaDesde.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FechaDesde.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_FechaDesde.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FechaDesde.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_FechaDesde.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaDesde.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_FechaDesde.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_FechaDesde.Name = "Dtp_FechaDesde"
        Me.Dtp_FechaDesde.Size = New System.Drawing.Size(79, 22)
        Me.Dtp_FechaDesde.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_FechaDesde.TabIndex = 190
        Me.Dtp_FechaDesde.Value = New Date(2025, 1, 30, 12, 12, 50, 0)
        '
        'Cmb_FiltroFecha
        '
        Me.Cmb_FiltroFecha.DisplayMember = "Text"
        Me.Cmb_FiltroFecha.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_FiltroFecha.ForeColor = System.Drawing.Color.Black
        Me.Cmb_FiltroFecha.FormattingEnabled = True
        Me.Cmb_FiltroFecha.ItemHeight = 16
        Me.Cmb_FiltroFecha.Location = New System.Drawing.Point(493, 10)
        Me.Cmb_FiltroFecha.Name = "Cmb_FiltroFecha"
        Me.Cmb_FiltroFecha.Size = New System.Drawing.Size(140, 22)
        Me.Cmb_FiltroFecha.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_FiltroFecha.TabIndex = 191
        '
        'Dtp_FechaHasta
        '
        Me.Dtp_FechaHasta.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_FechaHasta.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_FechaHasta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaHasta.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_FechaHasta.ButtonDropDown.Visible = True
        Me.Dtp_FechaHasta.ForeColor = System.Drawing.Color.Black
        Me.Dtp_FechaHasta.IsPopupCalendarOpen = False
        Me.Dtp_FechaHasta.Location = New System.Drawing.Point(796, 11)
        '
        '
        '
        Me.Dtp_FechaHasta.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FechaHasta.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaHasta.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_FechaHasta.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_FechaHasta.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_FechaHasta.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FechaHasta.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_FechaHasta.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_FechaHasta.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_FechaHasta.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_FechaHasta.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaHasta.MonthCalendar.DisplayMonth = New Date(2025, 1, 1, 0, 0, 0, 0)
        Me.Dtp_FechaHasta.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_FechaHasta.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_FechaHasta.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FechaHasta.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_FechaHasta.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FechaHasta.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_FechaHasta.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaHasta.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_FechaHasta.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_FechaHasta.Name = "Dtp_FechaHasta"
        Me.Dtp_FechaHasta.Size = New System.Drawing.Size(80, 22)
        Me.Dtp_FechaHasta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_FechaHasta.TabIndex = 192
        Me.Dtp_FechaHasta.Value = New Date(2025, 1, 30, 12, 12, 50, 0)
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(642, 8)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(34, 23)
        Me.LabelX3.TabIndex = 193
        Me.LabelX3.Text = "desde"
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(764, 10)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(34, 23)
        Me.LabelX4.TabIndex = 194
        Me.LabelX4.Text = "hasta"
        '
        'Frm_Stmp_ListadoXRutas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1201, 596)
        Me.Controls.Add(Me.Dtp_FechaHasta)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.Cmb_FiltroFecha)
        Me.Controls.Add(Me.Dtp_FechaDesde)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Txt_Filtrar)
        Me.Controls.Add(Me.Lbl_Informacion)
        Me.Controls.Add(Me.Super_TabS)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Metro_Bar_Color)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Stmp_ListadoXRutas"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SISTEMA DE ENTREGA DE MERCADERIA POR TICKET (RUTAS)"
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Super_TabS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.Menu_Contextual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_FechaDesde, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_FechaHasta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Btn_Mnu_Preparacion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_CerrarTicket As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_ReenviaFacturar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem3 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Copiar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Menu_Contextual_01_Opciones_AgregarTicket As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_AgregarConNumero As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_AgregarBuscando As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Imagenes_16x16 As ImageList
    Friend WithEvents Imagenes_16x16_Dark As ImageList
    Friend WithEvents Metro_Bar_Color As DevComponents.DotNetBar.Metro.MetroStatusBar
    Friend WithEvents Lbl_Estatus As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Filtrar As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Btn_Mnu_EntregarMercaderia As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Lbl_Informacion As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Imprimir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Tab_Todas As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents Super_TabS As DevComponents.DotNetBar.SuperTabStrip
    Friend WithEvents Tab_Ingresadas As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents Tab_Preparacion As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents Tab_Completadas As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents Tab_Facturadas As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Public WithEvents Btn_ImpFacMasiva As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Exportar_Excel As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Actualizar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_ConfLocal As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Menu_Contextual As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_01_Opciones_Documento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_VerDocumento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Dtp_FechaDesde As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Cmb_FiltroFecha As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Dtp_FechaHasta As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
End Class
