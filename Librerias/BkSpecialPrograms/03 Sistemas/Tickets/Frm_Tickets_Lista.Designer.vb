<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Tickets_Lista
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Tickets_Lista))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Crear_Ticket = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_RevisarTicket = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Actualizar = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Menu_Contextual = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_01 = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_EditarFuncionario = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_QuitarVendedor = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Imagenes_16x16 = New System.Windows.Forms.ImageList(Me.components)
        Me.Chk_TickesAsigMi = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_TickesMiGrupo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Imagenes_16x16_Dark = New System.Windows.Forms.ImageList(Me.components)
        Me.Lbl_OpcProducto = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Estadisticas_Producto = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Consolidar_Stock_X_Producto = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Copiar = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Mnu_CerrarTicket = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_CerrarTicketCrearNuevo = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_SolicitarCierre = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Anular = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Mnu_EnviarMensajeRespuesta = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_RechazarTicket = New DevComponents.DotNetBar.ButtonItem()
        Me.Super_TabS = New DevComponents.DotNetBar.SuperTabStrip()
        Me.Tab_TodasActivas = New DevComponents.DotNetBar.SuperTabItem()
        Me.Tab_ActivasRechazadas = New DevComponents.DotNetBar.SuperTabItem()
        Me.Tab_Cerradas = New DevComponents.DotNetBar.SuperTabItem()
        Me.Tab_CerradasAceptadas = New DevComponents.DotNetBar.SuperTabItem()
        Me.Tab_CerradasRechazadas = New DevComponents.DotNetBar.SuperTabItem()
        Me.Tab_Nulas = New DevComponents.DotNetBar.SuperTabItem()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Menu_Contextual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Super_TabS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Crear_Ticket, Me.Btn_RevisarTicket, Me.Btn_Actualizar})
        Me.Bar2.Location = New System.Drawing.Point(0, 613)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(1206, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 161
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Crear_Ticket
        '
        Me.Btn_Crear_Ticket.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Crear_Ticket.ForeColor = System.Drawing.Color.Black
        Me.Btn_Crear_Ticket.Image = CType(resources.GetObject("Btn_Crear_Ticket.Image"), System.Drawing.Image)
        Me.Btn_Crear_Ticket.ImageAlt = CType(resources.GetObject("Btn_Crear_Ticket.ImageAlt"), System.Drawing.Image)
        Me.Btn_Crear_Ticket.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Crear_Ticket.Name = "Btn_Crear_Ticket"
        Me.Btn_Crear_Ticket.Tooltip = "Crear nuevo Ticket"
        '
        'Btn_RevisarTicket
        '
        Me.Btn_RevisarTicket.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_RevisarTicket.ForeColor = System.Drawing.Color.Black
        Me.Btn_RevisarTicket.Image = CType(resources.GetObject("Btn_RevisarTicket.Image"), System.Drawing.Image)
        Me.Btn_RevisarTicket.ImageAlt = CType(resources.GetObject("Btn_RevisarTicket.ImageAlt"), System.Drawing.Image)
        Me.Btn_RevisarTicket.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_RevisarTicket.Name = "Btn_RevisarTicket"
        Me.Btn_RevisarTicket.Tooltip = "Revisar Ticket"
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
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Menu_Contextual)
        Me.GroupPanel1.Controls.Add(Me.Grilla)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 99)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(1182, 485)
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
        Me.GroupPanel1.TabIndex = 160
        Me.GroupPanel1.Text = "Tickets"
        '
        'Menu_Contextual
        '
        Me.Menu_Contextual.AntiAlias = True
        Me.Menu_Contextual.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Menu_Contextual.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_01})
        Me.Menu_Contextual.Location = New System.Drawing.Point(33, 108)
        Me.Menu_Contextual.Name = "Menu_Contextual"
        Me.Menu_Contextual.Size = New System.Drawing.Size(412, 25)
        Me.Menu_Contextual.Stretch = True
        Me.Menu_Contextual.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Menu_Contextual.TabIndex = 48
        Me.Menu_Contextual.TabStop = False
        Me.Menu_Contextual.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_01
        '
        Me.Menu_Contextual_01.AutoExpandOnClick = True
        Me.Menu_Contextual_01.Name = "Menu_Contextual_01"
        Me.Menu_Contextual_01.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_EditarFuncionario, Me.Btn_QuitarVendedor})
        Me.Menu_Contextual_01.Text = "Opciones"
        '
        'Btn_EditarFuncionario
        '
        Me.Btn_EditarFuncionario.Image = CType(resources.GetObject("Btn_EditarFuncionario.Image"), System.Drawing.Image)
        Me.Btn_EditarFuncionario.ImageAlt = CType(resources.GetObject("Btn_EditarFuncionario.ImageAlt"), System.Drawing.Image)
        Me.Btn_EditarFuncionario.Name = "Btn_EditarFuncionario"
        Me.Btn_EditarFuncionario.Text = "Editar funcionario"
        '
        'Btn_QuitarVendedor
        '
        Me.Btn_QuitarVendedor.Image = CType(resources.GetObject("Btn_QuitarVendedor.Image"), System.Drawing.Image)
        Me.Btn_QuitarVendedor.ImageAlt = CType(resources.GetObject("Btn_QuitarVendedor.ImageAlt"), System.Drawing.Image)
        Me.Btn_QuitarVendedor.Name = "Btn_QuitarVendedor"
        Me.Btn_QuitarVendedor.Text = "Quitar vendedor"
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.AllowUserToDeleteRows = False
        Me.Grilla.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla.DefaultCellStyle = DataGridViewCellStyle5
        Me.Grilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla.EnableHeadersVisualStyles = False
        Me.Grilla.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla.Location = New System.Drawing.Point(0, 0)
        Me.Grilla.Name = "Grilla"
        Me.Grilla.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Grilla.Size = New System.Drawing.Size(1176, 462)
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
        Me.Imagenes_16x16.Images.SetKeyName(21, "ticket-number-9-plus.png")
        Me.Imagenes_16x16.Images.SetKeyName(22, "ticket-number-9.png")
        Me.Imagenes_16x16.Images.SetKeyName(23, "ticket-number-8.png")
        Me.Imagenes_16x16.Images.SetKeyName(24, "ticket-number-7.png")
        Me.Imagenes_16x16.Images.SetKeyName(25, "ticket-number-6.png")
        Me.Imagenes_16x16.Images.SetKeyName(26, "ticket-number-5.png")
        Me.Imagenes_16x16.Images.SetKeyName(27, "ticket-number-4.png")
        Me.Imagenes_16x16.Images.SetKeyName(28, "ticket-number-3.png")
        Me.Imagenes_16x16.Images.SetKeyName(29, "ticket-number-2.png")
        Me.Imagenes_16x16.Images.SetKeyName(30, "ticket-number-1.png")
        '
        'Chk_TickesAsigMi
        '
        Me.Chk_TickesAsigMi.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_TickesAsigMi.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_TickesAsigMi.CheckBoxImageChecked = CType(resources.GetObject("Chk_TickesAsigMi.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_TickesAsigMi.Checked = True
        Me.Chk_TickesAsigMi.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_TickesAsigMi.CheckValue = "Y"
        Me.Chk_TickesAsigMi.Enabled = False
        Me.Chk_TickesAsigMi.FocusCuesEnabled = False
        Me.Chk_TickesAsigMi.ForeColor = System.Drawing.Color.Black
        Me.Chk_TickesAsigMi.Location = New System.Drawing.Point(12, 590)
        Me.Chk_TickesAsigMi.Name = "Chk_TickesAsigMi"
        Me.Chk_TickesAsigMi.Size = New System.Drawing.Size(169, 17)
        Me.Chk_TickesAsigMi.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_TickesAsigMi.TabIndex = 162
        Me.Chk_TickesAsigMi.Text = "Ver solo ticket asignados a mi"
        '
        'Chk_TickesMiGrupo
        '
        Me.Chk_TickesMiGrupo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_TickesMiGrupo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_TickesMiGrupo.CheckBoxImageChecked = CType(resources.GetObject("Chk_TickesMiGrupo.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_TickesMiGrupo.Checked = True
        Me.Chk_TickesMiGrupo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_TickesMiGrupo.CheckValue = "Y"
        Me.Chk_TickesMiGrupo.FocusCuesEnabled = False
        Me.Chk_TickesMiGrupo.ForeColor = System.Drawing.Color.Black
        Me.Chk_TickesMiGrupo.Location = New System.Drawing.Point(187, 590)
        Me.Chk_TickesMiGrupo.Name = "Chk_TickesMiGrupo"
        Me.Chk_TickesMiGrupo.Size = New System.Drawing.Size(251, 17)
        Me.Chk_TickesMiGrupo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_TickesMiGrupo.TabIndex = 163
        Me.Chk_TickesMiGrupo.Text = "Ver ticket asignados a mi(s) grupo(s) de trabajo"
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
        Me.Imagenes_16x16_Dark.Images.SetKeyName(21, "ticket-number-9-plus.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(22, "ticket-number-9.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(23, "ticket-number-8.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(24, "ticket-number-7.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(25, "ticket-number-6.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(26, "ticket-number-5.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(27, "ticket-number-4.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(28, "ticket-number-3.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(29, "ticket-number-2.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(30, "ticket-number-1.png")
        '
        'Lbl_OpcProducto
        '
        Me.Lbl_OpcProducto.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Lbl_OpcProducto.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.Lbl_OpcProducto.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.Lbl_OpcProducto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.Lbl_OpcProducto.Name = "Lbl_OpcProducto"
        Me.Lbl_OpcProducto.PaddingBottom = 1
        Me.Lbl_OpcProducto.PaddingLeft = 10
        Me.Lbl_OpcProducto.PaddingTop = 1
        Me.Lbl_OpcProducto.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.Lbl_OpcProducto.Text = "Opciones del producto"
        '
        'Btn_Estadisticas_Producto
        '
        Me.Btn_Estadisticas_Producto.Image = CType(resources.GetObject("Btn_Estadisticas_Producto.Image"), System.Drawing.Image)
        Me.Btn_Estadisticas_Producto.ImageAlt = CType(resources.GetObject("Btn_Estadisticas_Producto.ImageAlt"), System.Drawing.Image)
        Me.Btn_Estadisticas_Producto.Name = "Btn_Estadisticas_Producto"
        Me.Btn_Estadisticas_Producto.Text = "Ver estadísticas del producto/información adicional"
        '
        'Btn_Consolidar_Stock_X_Producto
        '
        Me.Btn_Consolidar_Stock_X_Producto.Image = CType(resources.GetObject("Btn_Consolidar_Stock_X_Producto.Image"), System.Drawing.Image)
        Me.Btn_Consolidar_Stock_X_Producto.ImageAlt = CType(resources.GetObject("Btn_Consolidar_Stock_X_Producto.ImageAlt"), System.Drawing.Image)
        Me.Btn_Consolidar_Stock_X_Producto.Name = "Btn_Consolidar_Stock_X_Producto"
        Me.Btn_Consolidar_Stock_X_Producto.Text = "Consolidar stock del producto"
        Me.Btn_Consolidar_Stock_X_Producto.Visible = False
        '
        'Btn_Copiar
        '
        Me.Btn_Copiar.Image = CType(resources.GetObject("Btn_Copiar.Image"), System.Drawing.Image)
        Me.Btn_Copiar.ImageAlt = CType(resources.GetObject("Btn_Copiar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Copiar.Name = "Btn_Copiar"
        Me.Btn_Copiar.Text = "Copiar (portapapeles)"
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
        Me.LabelItem1.Text = "Opciones de cierre"
        '
        'Btn_Mnu_CerrarTicket
        '
        Me.Btn_Mnu_CerrarTicket.Image = CType(resources.GetObject("Btn_Mnu_CerrarTicket.Image"), System.Drawing.Image)
        Me.Btn_Mnu_CerrarTicket.Name = "Btn_Mnu_CerrarTicket"
        Me.Btn_Mnu_CerrarTicket.Text = "Cerrar Ticket"
        '
        'Btn_Mnu_CerrarTicketCrearNuevo
        '
        Me.Btn_Mnu_CerrarTicketCrearNuevo.Image = CType(resources.GetObject("Btn_Mnu_CerrarTicketCrearNuevo.Image"), System.Drawing.Image)
        Me.Btn_Mnu_CerrarTicketCrearNuevo.Name = "Btn_Mnu_CerrarTicketCrearNuevo"
        Me.Btn_Mnu_CerrarTicketCrearNuevo.Text = "Cerrar Ticket y crear nuevo Ticket a partir de este para seguir el hilo."
        '
        'Btn_Mnu_SolicitarCierre
        '
        Me.Btn_Mnu_SolicitarCierre.Image = CType(resources.GetObject("Btn_Mnu_SolicitarCierre.Image"), System.Drawing.Image)
        Me.Btn_Mnu_SolicitarCierre.Name = "Btn_Mnu_SolicitarCierre"
        Me.Btn_Mnu_SolicitarCierre.Text = "Solicitar cierre de Ticket al remitente."
        Me.Btn_Mnu_SolicitarCierre.Visible = False
        '
        'Btn_Anular
        '
        Me.Btn_Anular.Image = CType(resources.GetObject("Btn_Anular.Image"), System.Drawing.Image)
        Me.Btn_Anular.ImageAlt = CType(resources.GetObject("Btn_Anular.ImageAlt"), System.Drawing.Image)
        Me.Btn_Anular.Name = "Btn_Anular"
        Me.Btn_Anular.Text = "Anular Ticket"
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
        Me.LabelItem2.Text = "Opciones de mensajes"
        '
        'Btn_Mnu_EnviarMensajeRespuesta
        '
        Me.Btn_Mnu_EnviarMensajeRespuesta.Image = CType(resources.GetObject("Btn_Mnu_EnviarMensajeRespuesta.Image"), System.Drawing.Image)
        Me.Btn_Mnu_EnviarMensajeRespuesta.ImageAlt = CType(resources.GetObject("Btn_Mnu_EnviarMensajeRespuesta.ImageAlt"), System.Drawing.Image)
        Me.Btn_Mnu_EnviarMensajeRespuesta.Name = "Btn_Mnu_EnviarMensajeRespuesta"
        Me.Btn_Mnu_EnviarMensajeRespuesta.Text = "Enviar mensaje"
        '
        'Btn_Mnu_RechazarTicket
        '
        Me.Btn_Mnu_RechazarTicket.Image = CType(resources.GetObject("Btn_Mnu_RechazarTicket.Image"), System.Drawing.Image)
        Me.Btn_Mnu_RechazarTicket.ImageAlt = CType(resources.GetObject("Btn_Mnu_RechazarTicket.ImageAlt"), System.Drawing.Image)
        Me.Btn_Mnu_RechazarTicket.Name = "Btn_Mnu_RechazarTicket"
        Me.Btn_Mnu_RechazarTicket.Text = "Rechazar Ticket"
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
        Me.Super_TabS.Location = New System.Drawing.Point(12, 66)
        Me.Super_TabS.Name = "Super_TabS"
        Me.Super_TabS.ReorderTabsEnabled = True
        Me.Super_TabS.SelectedTabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Super_TabS.SelectedTabIndex = 3
        Me.Super_TabS.Size = New System.Drawing.Size(1182, 30)
        Me.Super_TabS.TabCloseButtonHot = Nothing
        Me.Super_TabS.TabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Super_TabS.TabIndex = 164
        Me.Super_TabS.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Tab_TodasActivas, Me.Tab_ActivasRechazadas, Me.Tab_Cerradas, Me.Tab_CerradasAceptadas, Me.Tab_CerradasRechazadas, Me.Tab_Nulas})
        Me.Super_TabS.Text = "Nulas"
        '
        'Tab_TodasActivas
        '
        Me.Tab_TodasActivas.GlobalItem = False
        Me.Tab_TodasActivas.Name = "Tab_TodasActivas"
        Me.Tab_TodasActivas.Text = "Todas las activas"
        '
        'Tab_ActivasRechazadas
        '
        Me.Tab_ActivasRechazadas.GlobalItem = False
        Me.Tab_ActivasRechazadas.Name = "Tab_ActivasRechazadas"
        Me.Tab_ActivasRechazadas.Text = "Activas (rechazadas)"
        '
        'Tab_Cerradas
        '
        Me.Tab_Cerradas.GlobalItem = False
        Me.Tab_Cerradas.Name = "Tab_Cerradas"
        Me.Tab_Cerradas.Text = "Cerradas"
        '
        'Tab_CerradasAceptadas
        '
        Me.Tab_CerradasAceptadas.GlobalItem = False
        Me.Tab_CerradasAceptadas.Image = CType(resources.GetObject("Tab_CerradasAceptadas.Image"), System.Drawing.Image)
        Me.Tab_CerradasAceptadas.Name = "Tab_CerradasAceptadas"
        Me.Tab_CerradasAceptadas.Text = "Cerradas (Aceptadas)"
        '
        'Tab_CerradasRechazadas
        '
        Me.Tab_CerradasRechazadas.GlobalItem = False
        Me.Tab_CerradasRechazadas.Name = "Tab_CerradasRechazadas"
        Me.Tab_CerradasRechazadas.Text = "Cerradas (Rechazadas)"
        '
        'Tab_Nulas
        '
        Me.Tab_Nulas.GlobalItem = False
        Me.Tab_Nulas.Name = "Tab_Nulas"
        Me.Tab_Nulas.Text = "Nulas"
        '
        'Frm_Tickets_Lista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1206, 654)
        Me.Controls.Add(Me.Super_TabS)
        Me.Controls.Add(Me.Chk_TickesMiGrupo)
        Me.Controls.Add(Me.Chk_TickesAsigMi)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.GroupPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Tickets_Lista"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.Menu_Contextual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Super_TabS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Public WithEvents Btn_Crear_Ticket As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Menu_Contextual As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_01 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_EditarFuncionario As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_QuitarVendedor As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Public WithEvents Btn_RevisarTicket As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Imagenes_16x16 As ImageList
    Public WithEvents Btn_Actualizar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Chk_TickesAsigMi As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Chk_TickesMiGrupo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Imagenes_16x16_Dark As ImageList
    Friend WithEvents Lbl_OpcProducto As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Estadisticas_Producto As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Consolidar_Stock_X_Producto As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Copiar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Mnu_CerrarTicket As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_CerrarTicketCrearNuevo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_SolicitarCierre As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Anular As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Mnu_EnviarMensajeRespuesta As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_RechazarTicket As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Super_TabS As DevComponents.DotNetBar.SuperTabStrip
    Friend WithEvents Tab_TodasActivas As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents Tab_ActivasRechazadas As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents Tab_CerradasAceptadas As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents Tab_CerradasRechazadas As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents Tab_Cerradas As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents Tab_Nulas As DevComponents.DotNetBar.SuperTabItem
End Class
