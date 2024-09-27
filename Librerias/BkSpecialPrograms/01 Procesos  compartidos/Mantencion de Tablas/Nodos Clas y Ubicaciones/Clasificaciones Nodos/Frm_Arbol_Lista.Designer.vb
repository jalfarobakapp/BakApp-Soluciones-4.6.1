<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Arbol_Lista
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Arbol_Lista))
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Tree_Bandeja = New System.Windows.Forms.TreeView()
        Me.Imagenes_16x16 = New System.Windows.Forms.ImageList(Me.components)
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Actualizar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Exportar_Excel = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem3 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_VerTicket = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_TicketProducto = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem4 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Mnu_Copiar = New DevComponents.DotNetBar.ButtonItem()
        Me.Metro_Bar_Color = New DevComponents.DotNetBar.Metro.MetroStatusBar()
        Me.Lbl_Estatus = New DevComponents.DotNetBar.LabelItem()
        Me.Imagenes_24x24 = New System.Windows.Forms.ImageList(Me.components)
        Me.Txt_Filtrar = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Imagenes_16x16_Dark = New System.Windows.Forms.ImageList(Me.components)
        Me.Menu_Contextual = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_01 = New DevComponents.DotNetBar.ButtonItem()
        Me.Lbl_TotalProductos = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_VerProductos = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_CrearClasificacion = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_CambiarNombreCarpeta = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_EliminarClasificacion = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Copiar = New DevComponents.DotNetBar.ButtonItem()
        Me.Tree_Bandeja_Adv = New DevComponents.AdvTree.AdvTree()
        Me.nodeConnector2 = New DevComponents.AdvTree.NodeConnector()
        Me.elementStyle7 = New DevComponents.DotNetBar.ElementStyle()
        Me.Btn_Aceptar = New DevComponents.DotNetBar.ButtonItem()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Menu_Contextual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tree_Bandeja_Adv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.LabelX1.Location = New System.Drawing.Point(12, 12)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(57, 23)
        Me.LabelX1.TabIndex = 180
        Me.LabelX1.Text = "Buscar"
        '
        'Tree_Bandeja
        '
        Me.Tree_Bandeja.AllowDrop = True
        Me.Tree_Bandeja.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Tree_Bandeja.BackColor = System.Drawing.Color.White
        Me.Tree_Bandeja.CheckBoxes = True
        Me.Tree_Bandeja.ForeColor = System.Drawing.Color.Black
        Me.Tree_Bandeja.ImageIndex = 0
        Me.Tree_Bandeja.ImageList = Me.Imagenes_16x16
        Me.Tree_Bandeja.Location = New System.Drawing.Point(734, 268)
        Me.Tree_Bandeja.Name = "Tree_Bandeja"
        Me.Tree_Bandeja.SelectedImageIndex = 0
        Me.Tree_Bandeja.Size = New System.Drawing.Size(549, 79)
        Me.Tree_Bandeja.TabIndex = 179
        '
        'Imagenes_16x16
        '
        Me.Imagenes_16x16.ImageStream = CType(resources.GetObject("Imagenes_16x16.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagenes_16x16.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagenes_16x16.Images.SetKeyName(0, "folder.png")
        Me.Imagenes_16x16.Images.SetKeyName(1, "folder-open.png")
        Me.Imagenes_16x16.Images.SetKeyName(2, "folder-ok.png")
        Me.Imagenes_16x16.Images.SetKeyName(3, "folder-open-ok.png")
        Me.Imagenes_16x16.Images.SetKeyName(4, "house-1.png")
        Me.Imagenes_16x16.Images.SetKeyName(5, "option-check-box-selected.png")
        Me.Imagenes_16x16.Images.SetKeyName(6, "option-check-box-unselected.png")
        Me.Imagenes_16x16.Images.SetKeyName(7, "folder-list.png")
        Me.Imagenes_16x16.Images.SetKeyName(8, "folder-open-list.png")
        Me.Imagenes_16x16.Images.SetKeyName(9, "house-1-ok.png")
        Me.Imagenes_16x16.Images.SetKeyName(10, "house-1-media-record.png")
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Aceptar, Me.Btn_Grabar, Me.Btn_Actualizar, Me.Btn_Exportar_Excel})
        Me.Bar2.Location = New System.Drawing.Point(0, 493)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(705, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 176
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.ImageAlt = CType(resources.GetObject("Btn_Grabar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Grabar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Tooltip = "Refrescar datos"
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
        'Btn_Exportar_Excel
        '
        Me.Btn_Exportar_Excel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Exportar_Excel.ForeColor = System.Drawing.Color.Black
        Me.Btn_Exportar_Excel.Image = CType(resources.GetObject("Btn_Exportar_Excel.Image"), System.Drawing.Image)
        Me.Btn_Exportar_Excel.ImageAlt = CType(resources.GetObject("Btn_Exportar_Excel.ImageAlt"), System.Drawing.Image)
        Me.Btn_Exportar_Excel.Name = "Btn_Exportar_Excel"
        Me.Btn_Exportar_Excel.Tooltip = "Exportar a Excel"
        Me.Btn_Exportar_Excel.Visible = False
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
        Me.LabelItem3.Text = "Opciones del producto"
        '
        'Btn_VerTicket
        '
        Me.Btn_VerTicket.Image = CType(resources.GetObject("Btn_VerTicket.Image"), System.Drawing.Image)
        Me.Btn_VerTicket.ImageAlt = CType(resources.GetObject("Btn_VerTicket.ImageAlt"), System.Drawing.Image)
        Me.Btn_VerTicket.Name = "Btn_VerTicket"
        Me.Btn_VerTicket.Text = "Ver Ticket"
        '
        'Btn_TicketProducto
        '
        Me.Btn_TicketProducto.Image = CType(resources.GetObject("Btn_TicketProducto.Image"), System.Drawing.Image)
        Me.Btn_TicketProducto.ImageAlt = CType(resources.GetObject("Btn_TicketProducto.ImageAlt"), System.Drawing.Image)
        Me.Btn_TicketProducto.Name = "Btn_TicketProducto"
        Me.Btn_TicketProducto.Text = "Ver información del ticket del producto"
        '
        'LabelItem4
        '
        Me.LabelItem4.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem4.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem4.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem4.ImageTextSpacing = 1
        Me.LabelItem4.Name = "LabelItem4"
        Me.LabelItem4.PaddingBottom = 1
        Me.LabelItem4.PaddingLeft = 10
        Me.LabelItem4.PaddingTop = 1
        Me.LabelItem4.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem4.Text = "-------------------------------------------"
        '
        'Btn_Mnu_Copiar
        '
        Me.Btn_Mnu_Copiar.Image = CType(resources.GetObject("Btn_Mnu_Copiar.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Copiar.ImageAlt = CType(resources.GetObject("Btn_Mnu_Copiar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Mnu_Copiar.Name = "Btn_Mnu_Copiar"
        Me.Btn_Mnu_Copiar.Text = "Copiar (portapapeles)"
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
        Me.Metro_Bar_Color.Location = New System.Drawing.Point(0, 534)
        Me.Metro_Bar_Color.Name = "Metro_Bar_Color"
        Me.Metro_Bar_Color.Size = New System.Drawing.Size(705, 22)
        Me.Metro_Bar_Color.TabIndex = 181
        Me.Metro_Bar_Color.Text = "MetroStatusBar1"
        '
        'Lbl_Estatus
        '
        Me.Lbl_Estatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Estatus.Name = "Lbl_Estatus"
        Me.Lbl_Estatus.Text = "LabelItem2"
        '
        'Imagenes_24x24
        '
        Me.Imagenes_24x24.ImageStream = CType(resources.GetObject("Imagenes_24x24.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagenes_24x24.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagenes_24x24.Images.SetKeyName(0, "folder.png")
        Me.Imagenes_24x24.Images.SetKeyName(1, "folder-open.png")
        Me.Imagenes_24x24.Images.SetKeyName(2, "folder-ok.png")
        Me.Imagenes_24x24.Images.SetKeyName(3, "folder-open-ok.png")
        Me.Imagenes_24x24.Images.SetKeyName(4, "folder-cancel-2.png")
        Me.Imagenes_24x24.Images.SetKeyName(5, "folder-open-cancel-2.png")
        Me.Imagenes_24x24.Images.SetKeyName(6, "folder-cancel.png")
        Me.Imagenes_24x24.Images.SetKeyName(7, "folder-open-cancel.png")
        Me.Imagenes_24x24.Images.SetKeyName(8, "folder-time.png")
        Me.Imagenes_24x24.Images.SetKeyName(9, "folder-open-time.png")
        Me.Imagenes_24x24.Images.SetKeyName(10, "folder-open-padlock.png")
        Me.Imagenes_24x24.Images.SetKeyName(11, "folder-padlock.png")
        Me.Imagenes_24x24.Images.SetKeyName(12, "ticket-vendor.png")
        Me.Imagenes_24x24.Images.SetKeyName(13, "ticket-customer.png")
        Me.Imagenes_24x24.Images.SetKeyName(14, "ticket-arrow-up.png")
        Me.Imagenes_24x24.Images.SetKeyName(15, "ticket-arrow-right.png")
        Me.Imagenes_24x24.Images.SetKeyName(16, "ticket-arrow-left.png")
        Me.Imagenes_24x24.Images.SetKeyName(17, "ticket-arrow-down.png")
        Me.Imagenes_24x24.Images.SetKeyName(18, "ticket-ok.png")
        Me.Imagenes_24x24.Images.SetKeyName(19, "ticket-cancel-2.png")
        Me.Imagenes_24x24.Images.SetKeyName(20, "ticket-cancel.png")
        Me.Imagenes_24x24.Images.SetKeyName(21, "ticket-time.png")
        Me.Imagenes_24x24.Images.SetKeyName(22, "house-1.png")
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
        Me.Txt_Filtrar.ButtonCustom.Text = "Buscar siguiente"
        Me.Txt_Filtrar.ButtonCustom.Visible = True
        Me.Txt_Filtrar.ButtonCustom2.Image = CType(resources.GetObject("Txt_Filtrar.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Filtrar.ButtonCustom2.Visible = True
        Me.Txt_Filtrar.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Filtrar.ForeColor = System.Drawing.Color.Black
        Me.Txt_Filtrar.Location = New System.Drawing.Point(75, 12)
        Me.Txt_Filtrar.Name = "Txt_Filtrar"
        Me.Txt_Filtrar.PreventEnterBeep = True
        Me.Txt_Filtrar.Size = New System.Drawing.Size(620, 22)
        Me.Txt_Filtrar.TabIndex = 174
        '
        'Imagenes_16x16_Dark
        '
        Me.Imagenes_16x16_Dark.ImageStream = CType(resources.GetObject("Imagenes_16x16_Dark.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagenes_16x16_Dark.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagenes_16x16_Dark.Images.SetKeyName(0, "folder.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(1, "folder-open.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(2, "folder-ok.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(3, "folder-open-ok.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(4, "house-1.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(5, "option-check-box-selected.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(6, "option-check-box-unselected.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(7, "folder-list.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(8, "folder-open-list.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(9, "house-1-ok.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(10, "house-1-media-record.png")
        '
        'Menu_Contextual
        '
        Me.Menu_Contextual.AntiAlias = True
        Me.Menu_Contextual.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Menu_Contextual.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_01})
        Me.Menu_Contextual.Location = New System.Drawing.Point(15, 40)
        Me.Menu_Contextual.Name = "Menu_Contextual"
        Me.Menu_Contextual.Size = New System.Drawing.Size(412, 25)
        Me.Menu_Contextual.Stretch = True
        Me.Menu_Contextual.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Menu_Contextual.TabIndex = 182
        Me.Menu_Contextual.TabStop = False
        Me.Menu_Contextual.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_01
        '
        Me.Menu_Contextual_01.AutoExpandOnClick = True
        Me.Menu_Contextual_01.Name = "Menu_Contextual_01"
        Me.Menu_Contextual_01.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Lbl_TotalProductos, Me.Btn_VerProductos, Me.LabelItem1, Me.Btn_CrearClasificacion, Me.Btn_CambiarNombreCarpeta, Me.Btn_EliminarClasificacion, Me.LabelItem2, Me.Btn_Copiar})
        Me.Menu_Contextual_01.Text = "Opciones"
        '
        'Lbl_TotalProductos
        '
        Me.Lbl_TotalProductos.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Lbl_TotalProductos.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.Lbl_TotalProductos.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.Lbl_TotalProductos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.Lbl_TotalProductos.Name = "Lbl_TotalProductos"
        Me.Lbl_TotalProductos.PaddingBottom = 1
        Me.Lbl_TotalProductos.PaddingLeft = 10
        Me.Lbl_TotalProductos.PaddingTop = 1
        Me.Lbl_TotalProductos.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.Lbl_TotalProductos.Text = "Total productos asociados: 9999"
        '
        'Btn_VerProductos
        '
        Me.Btn_VerProductos.Image = CType(resources.GetObject("Btn_VerProductos.Image"), System.Drawing.Image)
        Me.Btn_VerProductos.ImageAlt = CType(resources.GetObject("Btn_VerProductos.ImageAlt"), System.Drawing.Image)
        Me.Btn_VerProductos.Name = "Btn_VerProductos"
        Me.Btn_VerProductos.Text = "Ver productos asociados"
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
        Me.LabelItem1.Text = "-------------------------------------------"
        '
        'Btn_CrearClasificacion
        '
        Me.Btn_CrearClasificacion.Image = CType(resources.GetObject("Btn_CrearClasificacion.Image"), System.Drawing.Image)
        Me.Btn_CrearClasificacion.ImageAlt = CType(resources.GetObject("Btn_CrearClasificacion.ImageAlt"), System.Drawing.Image)
        Me.Btn_CrearClasificacion.Name = "Btn_CrearClasificacion"
        Me.Btn_CrearClasificacion.Text = "Crear"
        Me.Btn_CrearClasificacion.Tooltip = "Crear nueva clasificación"
        '
        'Btn_CambiarNombreCarpeta
        '
        Me.Btn_CambiarNombreCarpeta.Image = CType(resources.GetObject("Btn_CambiarNombreCarpeta.Image"), System.Drawing.Image)
        Me.Btn_CambiarNombreCarpeta.ImageAlt = CType(resources.GetObject("Btn_CambiarNombreCarpeta.ImageAlt"), System.Drawing.Image)
        Me.Btn_CambiarNombreCarpeta.Name = "Btn_CambiarNombreCarpeta"
        Me.Btn_CambiarNombreCarpeta.Text = "Editar"
        Me.Btn_CambiarNombreCarpeta.Tooltip = "Editar descripción de la clasificación"
        '
        'Btn_EliminarClasificacion
        '
        Me.Btn_EliminarClasificacion.Image = CType(resources.GetObject("Btn_EliminarClasificacion.Image"), System.Drawing.Image)
        Me.Btn_EliminarClasificacion.ImageAlt = CType(resources.GetObject("Btn_EliminarClasificacion.ImageAlt"), System.Drawing.Image)
        Me.Btn_EliminarClasificacion.Name = "Btn_EliminarClasificacion"
        Me.Btn_EliminarClasificacion.Text = "Eliminar"
        Me.Btn_EliminarClasificacion.Tooltip = "Eliminar clasificación"
        '
        'LabelItem2
        '
        Me.LabelItem2.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem2.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem2.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem2.ImageTextSpacing = 1
        Me.LabelItem2.Name = "LabelItem2"
        Me.LabelItem2.PaddingBottom = 1
        Me.LabelItem2.PaddingLeft = 10
        Me.LabelItem2.PaddingTop = 1
        Me.LabelItem2.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem2.Text = "-------------------------------------------"
        '
        'Btn_Copiar
        '
        Me.Btn_Copiar.Image = CType(resources.GetObject("Btn_Copiar.Image"), System.Drawing.Image)
        Me.Btn_Copiar.ImageAlt = CType(resources.GetObject("Btn_Copiar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Copiar.Name = "Btn_Copiar"
        Me.Btn_Copiar.Text = "Copiar (portapapeles)"
        '
        'Tree_Bandeja_Adv
        '
        Me.Tree_Bandeja_Adv.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline
        Me.Tree_Bandeja_Adv.AllowDrop = True
        Me.Tree_Bandeja_Adv.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Tree_Bandeja_Adv.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Tree_Bandeja_Adv.BackgroundStyle.Class = "TreeBorderKey"
        Me.Tree_Bandeja_Adv.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Tree_Bandeja_Adv.CellEdit = True
        Me.Tree_Bandeja_Adv.DragDropEnabled = False
        Me.Tree_Bandeja_Adv.DragDropNodeCopyEnabled = False
        Me.Tree_Bandeja_Adv.ExpandButtonType = DevComponents.AdvTree.eExpandButtonType.Triangle
        Me.Tree_Bandeja_Adv.ForeColor = System.Drawing.Color.Black
        Me.Tree_Bandeja_Adv.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.Tree_Bandeja_Adv.Location = New System.Drawing.Point(12, 54)
        Me.Tree_Bandeja_Adv.Name = "Tree_Bandeja_Adv"
        Me.Tree_Bandeja_Adv.NodesConnector = Me.nodeConnector2
        Me.Tree_Bandeja_Adv.NodeStyle = Me.elementStyle7
        Me.Tree_Bandeja_Adv.PathSeparator = ";"
        Me.Tree_Bandeja_Adv.Size = New System.Drawing.Size(683, 433)
        Me.Tree_Bandeja_Adv.Styles.Add(Me.elementStyle7)
        Me.Tree_Bandeja_Adv.TabIndex = 183
        Me.Tree_Bandeja_Adv.Text = "advTree6"
        '
        'nodeConnector2
        '
        Me.nodeConnector2.LineColor = System.Drawing.Color.FromArgb(CType(CType(135, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(135, Byte), Integer))
        '
        'elementStyle7
        '
        Me.elementStyle7.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.elementStyle7.Name = "elementStyle7"
        Me.elementStyle7.TextColor = System.Drawing.Color.Black
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Aceptar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Aceptar.Image = CType(resources.GetObject("Btn_Aceptar.Image"), System.Drawing.Image)
        Me.Btn_Aceptar.ImageAlt = CType(resources.GetObject("Btn_Aceptar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Text = "Aceptar"
        '
        'Frm_Arbol_Lista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(705, 556)
        Me.Controls.Add(Me.Menu_Contextual)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Tree_Bandeja_Adv)
        Me.Controls.Add(Me.Txt_Filtrar)
        Me.Controls.Add(Me.Tree_Bandeja)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.Metro_Bar_Color)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(721, 685)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(721, 595)
        Me.Name = "Frm_Arbol_Lista"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Menu_Contextual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tree_Bandeja_Adv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Tree_Bandeja As TreeView
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Exportar_Excel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem3 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_VerTicket As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_TicketProducto As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem4 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Mnu_Copiar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Metro_Bar_Color As DevComponents.DotNetBar.Metro.MetroStatusBar
    Friend WithEvents Lbl_Estatus As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Imagenes_24x24 As ImageList
    Friend WithEvents Imagenes_16x16 As ImageList
    Friend WithEvents Txt_Filtrar As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Imagenes_16x16_Dark As ImageList
    Friend WithEvents Menu_Contextual As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_01 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Lbl_TotalProductos As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_VerProductos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_CambiarNombreCarpeta As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Copiar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_CrearClasificacion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_EliminarClasificacion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Public WithEvents Btn_Actualizar As DevComponents.DotNetBar.ButtonItem
    Private WithEvents Tree_Bandeja_Adv As DevComponents.AdvTree.AdvTree
    Private WithEvents nodeConnector2 As DevComponents.AdvTree.NodeConnector
    Private WithEvents elementStyle7 As DevComponents.DotNetBar.ElementStyle
    Public WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Aceptar As DevComponents.DotNetBar.ButtonItem
End Class
