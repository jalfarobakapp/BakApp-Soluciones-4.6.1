<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Stmp_Listado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Stmp_Listado))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Super_TabS = New DevComponents.DotNetBar.SuperTabStrip()
        Me.Tab_Preparacion = New DevComponents.DotNetBar.SuperTabItem()
        Me.Tab_Completadas = New DevComponents.DotNetBar.SuperTabItem()
        Me.Tab_Facturadas = New DevComponents.DotNetBar.SuperTabItem()
        Me.Tab_Cerradas = New DevComponents.DotNetBar.SuperTabItem()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_CargarNVVFechaDespHoy = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Crear_Ticket = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_RevisarTicket = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Actualizar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_FacturarMasivamente = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Menu_Contextual = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_01 = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_EditarFuncionario = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_QuitarVendedor = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Imagenes_16x16 = New System.Windows.Forms.ImageList(Me.components)
        Me.Imagenes_16x16_Dark = New System.Windows.Forms.ImageList(Me.components)
        Me.Chk_TickesAsigMi = New DevComponents.DotNetBar.Controls.CheckBoxX()
        CType(Me.Super_TabS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Menu_Contextual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.Super_TabS.Location = New System.Drawing.Point(12, 12)
        Me.Super_TabS.Name = "Super_TabS"
        Me.Super_TabS.ReorderTabsEnabled = True
        Me.Super_TabS.SelectedTabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Super_TabS.SelectedTabIndex = 0
        Me.Super_TabS.Size = New System.Drawing.Size(1182, 27)
        Me.Super_TabS.TabCloseButtonHot = Nothing
        Me.Super_TabS.TabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Super_TabS.TabIndex = 169
        Me.Super_TabS.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Tab_Preparacion, Me.Tab_Completadas, Me.Tab_Facturadas, Me.Tab_Cerradas})
        Me.Super_TabS.Text = "Nulas"
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
        'Tab_Cerradas
        '
        Me.Tab_Cerradas.GlobalItem = False
        Me.Tab_Cerradas.Name = "Tab_Cerradas"
        Me.Tab_Cerradas.Text = "Cerradas hoy"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_CargarNVVFechaDespHoy, Me.Btn_Crear_Ticket, Me.Btn_RevisarTicket, Me.Btn_Actualizar, Me.Btn_FacturarMasivamente})
        Me.Bar2.Location = New System.Drawing.Point(0, 569)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(1210, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 166
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_CargarNVVFechaDespHoy
        '
        Me.Btn_CargarNVVFechaDespHoy.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_CargarNVVFechaDespHoy.ForeColor = System.Drawing.Color.Black
        Me.Btn_CargarNVVFechaDespHoy.Image = CType(resources.GetObject("Btn_CargarNVVFechaDespHoy.Image"), System.Drawing.Image)
        Me.Btn_CargarNVVFechaDespHoy.ImageAlt = CType(resources.GetObject("Btn_CargarNVVFechaDespHoy.ImageAlt"), System.Drawing.Image)
        Me.Btn_CargarNVVFechaDespHoy.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_CargarNVVFechaDespHoy.Name = "Btn_CargarNVVFechaDespHoy"
        Me.Btn_CargarNVVFechaDespHoy.Tooltip = "Traer todos las NVV con fecha de despacho de hoy"
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
        'Btn_FacturarMasivamente
        '
        Me.Btn_FacturarMasivamente.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_FacturarMasivamente.ForeColor = System.Drawing.Color.Black
        Me.Btn_FacturarMasivamente.Image = CType(resources.GetObject("Btn_FacturarMasivamente.Image"), System.Drawing.Image)
        Me.Btn_FacturarMasivamente.ImageAlt = CType(resources.GetObject("Btn_FacturarMasivamente.ImageAlt"), System.Drawing.Image)
        Me.Btn_FacturarMasivamente.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_FacturarMasivamente.Name = "Btn_FacturarMasivamente"
        Me.Btn_FacturarMasivamente.Tooltip = "Facturar completadas"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Menu_Contextual)
        Me.GroupPanel1.Controls.Add(Me.Grilla)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 45)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(1182, 489)
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
        Me.GroupPanel1.TabIndex = 165
        Me.GroupPanel1.Text = "Detalle de Tickets por entrega de mercadería"
        '
        'Menu_Contextual
        '
        Me.Menu_Contextual.AntiAlias = True
        Me.Menu_Contextual.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Menu_Contextual.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_01})
        Me.Menu_Contextual.Location = New System.Drawing.Point(26, 27)
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
        Me.Grilla.Size = New System.Drawing.Size(1176, 466)
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
        Me.Chk_TickesAsigMi.Location = New System.Drawing.Point(12, 540)
        Me.Chk_TickesAsigMi.Name = "Chk_TickesAsigMi"
        Me.Chk_TickesAsigMi.Size = New System.Drawing.Size(169, 17)
        Me.Chk_TickesAsigMi.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_TickesAsigMi.TabIndex = 170
        Me.Chk_TickesAsigMi.Text = "Ver solo ticket asignados a mi"
        '
        'Frm_Stmp_Listado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1210, 610)
        Me.Controls.Add(Me.Chk_TickesAsigMi)
        Me.Controls.Add(Me.Super_TabS)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.GroupPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Stmp_Listado"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        CType(Me.Super_TabS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.Menu_Contextual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Super_TabS As DevComponents.DotNetBar.SuperTabStrip
    Friend WithEvents Tab_Preparacion As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents Tab_Completadas As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents Tab_Facturadas As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents Tab_Cerradas As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Public WithEvents Btn_Crear_Ticket As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_RevisarTicket As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Actualizar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Menu_Contextual As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_01 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_EditarFuncionario As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_QuitarVendedor As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Imagenes_16x16 As ImageList
    Friend WithEvents Imagenes_16x16_Dark As ImageList
    Public WithEvents Btn_CargarNVVFechaDespHoy As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_FacturarMasivamente As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Chk_TickesAsigMi As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
