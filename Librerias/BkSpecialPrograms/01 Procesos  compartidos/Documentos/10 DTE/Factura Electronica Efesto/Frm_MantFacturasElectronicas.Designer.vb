<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_MantFacturasElectronicas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_MantFacturasElectronicas))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual = New DevComponents.DotNetBar.ButtonItem()
        Me.Lbl_LeyendaDoc = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Ver_Documento = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Firmar_Documento = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Reenviar_SII = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_ReConsultar_Trackid = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Reenviar_Correo = New DevComponents.DotNetBar.ButtonItem()
        Me.Lbl_AEC = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_CesionarDTE = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Actualizar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Actualizar_Datos = New DevComponents.DotNetBar.ButtonItem()
        Me.CircularProgressItem1 = New DevComponents.DotNetBar.CircularProgressItem()
        Me.Chk_SoloFirmadosXBakapp = New DevComponents.DotNetBar.CheckBoxItem()
        Me.MStb_Barra = New DevComponents.DotNetBar.Metro.MetroStatusBar()
        Me.Lbl_Etiqueta = New DevComponents.DotNetBar.LabelItem()
        Me.Img_Imagenes = New System.Windows.Forms.ImageList(Me.components)
        Me.Img_Imagenes_Dark = New System.Windows.Forms.ImageList(Me.components)
        Me.Txt_Leyenda = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ComboBoxEx1 = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Cmb_Estado = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Descripcion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Chk_RechazadoSII = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_AceptadoReparos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_AceptadoSII = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_EnviadoSII = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_DocFirmado = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Btn_Mnu_Exportar_XML_Hefesto = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.ContextMenuBar1)
        Me.GroupPanel1.Controls.Add(Me.Grilla)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 66)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(984, 393)
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
        Me.GroupPanel1.TabIndex = 44
        Me.GroupPanel1.Text = "Detalle"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(31, 37)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(360, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 48
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual
        '
        Me.Menu_Contextual.AutoExpandOnClick = True
        Me.Menu_Contextual.Name = "Menu_Contextual"
        Me.Menu_Contextual.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Lbl_LeyendaDoc, Me.Btn_Ver_Documento, Me.Btn_Firmar_Documento, Me.Btn_Reenviar_SII, Me.Btn_ReConsultar_Trackid, Me.Btn_Reenviar_Correo, Me.Btn_Mnu_Exportar_XML_Hefesto, Me.Lbl_AEC, Me.Btn_CesionarDTE})
        Me.Menu_Contextual.Text = "Opciones"
        '
        'Lbl_LeyendaDoc
        '
        Me.Lbl_LeyendaDoc.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Lbl_LeyendaDoc.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.Lbl_LeyendaDoc.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.Lbl_LeyendaDoc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.Lbl_LeyendaDoc.Name = "Lbl_LeyendaDoc"
        Me.Lbl_LeyendaDoc.PaddingBottom = 1
        Me.Lbl_LeyendaDoc.PaddingLeft = 10
        Me.Lbl_LeyendaDoc.PaddingTop = 1
        Me.Lbl_LeyendaDoc.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.Lbl_LeyendaDoc.Text = "Id_Dte: 1235495, Id_Trackid: 98548545"
        '
        'Btn_Ver_Documento
        '
        Me.Btn_Ver_Documento.Image = CType(resources.GetObject("Btn_Ver_Documento.Image"), System.Drawing.Image)
        Me.Btn_Ver_Documento.ImageAlt = CType(resources.GetObject("Btn_Ver_Documento.ImageAlt"), System.Drawing.Image)
        Me.Btn_Ver_Documento.Name = "Btn_Ver_Documento"
        Me.Btn_Ver_Documento.Text = "Ver documento"
        '
        'Btn_Firmar_Documento
        '
        Me.Btn_Firmar_Documento.Image = CType(resources.GetObject("Btn_Firmar_Documento.Image"), System.Drawing.Image)
        Me.Btn_Firmar_Documento.Name = "Btn_Firmar_Documento"
        Me.Btn_Firmar_Documento.Text = "Firmar documento DTE"
        '
        'Btn_Reenviar_SII
        '
        Me.Btn_Reenviar_SII.Image = CType(resources.GetObject("Btn_Reenviar_SII.Image"), System.Drawing.Image)
        Me.Btn_Reenviar_SII.Name = "Btn_Reenviar_SII"
        Me.Btn_Reenviar_SII.Text = "Re-enviar documento al SII"
        '
        'Btn_ReConsultar_Trackid
        '
        Me.Btn_ReConsultar_Trackid.Image = CType(resources.GetObject("Btn_ReConsultar_Trackid.Image"), System.Drawing.Image)
        Me.Btn_ReConsultar_Trackid.Name = "Btn_ReConsultar_Trackid"
        Me.Btn_ReConsultar_Trackid.Text = "Volver a consultar Trackid"
        '
        'Btn_Reenviar_Correo
        '
        Me.Btn_Reenviar_Correo.Image = CType(resources.GetObject("Btn_Reenviar_Correo.Image"), System.Drawing.Image)
        Me.Btn_Reenviar_Correo.Name = "Btn_Reenviar_Correo"
        Me.Btn_Reenviar_Correo.Text = "Reenviar correo de notificación al cliente"
        '
        'Lbl_AEC
        '
        Me.Lbl_AEC.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Lbl_AEC.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.Lbl_AEC.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.Lbl_AEC.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.Lbl_AEC.Name = "Lbl_AEC"
        Me.Lbl_AEC.PaddingBottom = 1
        Me.Lbl_AEC.PaddingLeft = 10
        Me.Lbl_AEC.PaddingTop = 1
        Me.Lbl_AEC.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.Lbl_AEC.Text = "Archivo Electrónico de Cesión (AEC)"
        '
        'Btn_CesionarDTE
        '
        Me.Btn_CesionarDTE.Image = CType(resources.GetObject("Btn_CesionarDTE.Image"), System.Drawing.Image)
        Me.Btn_CesionarDTE.ImageAlt = CType(resources.GetObject("Btn_CesionarDTE.ImageAlt"), System.Drawing.Image)
        Me.Btn_CesionarDTE.Name = "Btn_CesionarDTE"
        Me.Btn_CesionarDTE.Text = "Cesionar documento"
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
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
        Me.Grilla.Size = New System.Drawing.Size(978, 370)
        Me.Grilla.StandardTab = True
        Me.Grilla.TabIndex = 30
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Actualizar, Me.Btn_Actualizar_Datos, Me.CircularProgressItem1, Me.Chk_SoloFirmadosXBakapp})
        Me.Bar1.Location = New System.Drawing.Point(0, 522)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(1008, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 43
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Actualizar
        '
        Me.Actualizar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Actualizar.ForeColor = System.Drawing.Color.Black
        Me.Actualizar.Image = CType(resources.GetObject("Actualizar.Image"), System.Drawing.Image)
        Me.Actualizar.ImageAlt = CType(resources.GetObject("Actualizar.ImageAlt"), System.Drawing.Image)
        Me.Actualizar.Name = "Actualizar"
        Me.Actualizar.Tooltip = "Actualizar datos, consultar estados de los documentos con el SII"
        '
        'Btn_Actualizar_Datos
        '
        Me.Btn_Actualizar_Datos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Actualizar_Datos.ForeColor = System.Drawing.Color.Black
        Me.Btn_Actualizar_Datos.Image = CType(resources.GetObject("Btn_Actualizar_Datos.Image"), System.Drawing.Image)
        Me.Btn_Actualizar_Datos.ImageAlt = CType(resources.GetObject("Btn_Actualizar_Datos.ImageAlt"), System.Drawing.Image)
        Me.Btn_Actualizar_Datos.Name = "Btn_Actualizar_Datos"
        Me.Btn_Actualizar_Datos.Tooltip = "Actualizar datos, consultar estados de los documentos con el SII"
        Me.Btn_Actualizar_Datos.Visible = False
        '
        'CircularProgressItem1
        '
        Me.CircularProgressItem1.Name = "CircularProgressItem1"
        Me.CircularProgressItem1.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Dot
        Me.CircularProgressItem1.Visible = False
        '
        'Chk_SoloFirmadosXBakapp
        '
        Me.Chk_SoloFirmadosXBakapp.Checked = True
        Me.Chk_SoloFirmadosXBakapp.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_SoloFirmadosXBakapp.Name = "Chk_SoloFirmadosXBakapp"
        Me.Chk_SoloFirmadosXBakapp.Text = "Mostrar solo fimados por Bakapp"
        '
        'MStb_Barra
        '
        Me.MStb_Barra.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.MStb_Barra.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MStb_Barra.ContainerControlProcessDialogKey = True
        Me.MStb_Barra.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.MStb_Barra.DragDropSupport = True
        Me.MStb_Barra.Font = New System.Drawing.Font("Segoe UI", 10.25!, System.Drawing.FontStyle.Bold)
        Me.MStb_Barra.ForeColor = System.Drawing.Color.Black
        Me.MStb_Barra.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Lbl_Etiqueta})
        Me.MStb_Barra.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MStb_Barra.Location = New System.Drawing.Point(0, 563)
        Me.MStb_Barra.Name = "MStb_Barra"
        Me.MStb_Barra.Size = New System.Drawing.Size(1008, 22)
        Me.MStb_Barra.TabIndex = 46
        Me.MStb_Barra.Text = "MetroStatusBar1"
        '
        'Lbl_Etiqueta
        '
        Me.Lbl_Etiqueta.Name = "Lbl_Etiqueta"
        Me.Lbl_Etiqueta.Text = "Ambiente de producción"
        '
        'Img_Imagenes
        '
        Me.Img_Imagenes.ImageStream = CType(resources.GetObject("Img_Imagenes.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Img_Imagenes.TransparentColor = System.Drawing.Color.Transparent
        Me.Img_Imagenes.Images.SetKeyName(0, "symbol-ok.png")
        Me.Img_Imagenes.Images.SetKeyName(1, "symbol-cancel.png")
        Me.Img_Imagenes.Images.SetKeyName(2, "option-check-box-unselected.png")
        Me.Img_Imagenes.Images.SetKeyName(3, "option-radio-unselected.png")
        Me.Img_Imagenes.Images.SetKeyName(4, "button-ok.png")
        Me.Img_Imagenes.Images.SetKeyName(5, "symbol-ok-warning.png")
        Me.Img_Imagenes.Images.SetKeyName(6, "mailbox-in-emoticon.png")
        Me.Img_Imagenes.Images.SetKeyName(7, "mailbox-junk.png")
        Me.Img_Imagenes.Images.SetKeyName(8, "send-mail-front-ok-2.png")
        Me.Img_Imagenes.Images.SetKeyName(9, "mailbox-in.png")
        Me.Img_Imagenes.Images.SetKeyName(10, "btn-blue-play-pause.png")
        Me.Img_Imagenes.Images.SetKeyName(11, "emoticon-wink.png")
        '
        'Img_Imagenes_Dark
        '
        Me.Img_Imagenes_Dark.ImageStream = CType(resources.GetObject("Img_Imagenes_Dark.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Img_Imagenes_Dark.TransparentColor = System.Drawing.Color.Transparent
        Me.Img_Imagenes_Dark.Images.SetKeyName(0, "symbol-ok.png")
        Me.Img_Imagenes_Dark.Images.SetKeyName(1, "button-ok.png")
        Me.Img_Imagenes_Dark.Images.SetKeyName(2, "symbol-cancel.png")
        Me.Img_Imagenes_Dark.Images.SetKeyName(3, "mailbox-junk.png")
        Me.Img_Imagenes_Dark.Images.SetKeyName(4, "mailbox-in.png")
        Me.Img_Imagenes_Dark.Images.SetKeyName(5, "btn-blue-play-pause.png")
        Me.Img_Imagenes_Dark.Images.SetKeyName(6, "emoticon-wink.png")
        Me.Img_Imagenes_Dark.Images.SetKeyName(7, "symbol-ok-warning.png")
        '
        'Txt_Leyenda
        '
        Me.Txt_Leyenda.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Leyenda.Border.Class = "TextBoxBorder"
        Me.Txt_Leyenda.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Leyenda.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Leyenda.ForeColor = System.Drawing.Color.Black
        Me.Txt_Leyenda.Location = New System.Drawing.Point(12, 493)
        Me.Txt_Leyenda.Name = "Txt_Leyenda"
        Me.Txt_Leyenda.PreventEnterBeep = True
        Me.Txt_Leyenda.ReadOnly = True
        Me.Txt_Leyenda.Size = New System.Drawing.Size(984, 22)
        Me.Txt_Leyenda.TabIndex = 47
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.ComboBoxEx1)
        Me.GroupPanel2.Controls.Add(Me.LabelX3)
        Me.GroupPanel2.Controls.Add(Me.Cmb_Estado)
        Me.GroupPanel2.Controls.Add(Me.LabelX1)
        Me.GroupPanel2.Controls.Add(Me.Txt_Descripcion)
        Me.GroupPanel2.Controls.Add(Me.LabelX2)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(12, 3)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(984, 57)
        '
        '
        '
        Me.GroupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel2.Style.BackColorGradientAngle = 90
        Me.GroupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderBottomWidth = 1
        Me.GroupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderLeftWidth = 1
        Me.GroupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderRightWidth = 1
        Me.GroupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderTopWidth = 1
        Me.GroupPanel2.Style.CornerDiameter = 4
        Me.GroupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel2.TabIndex = 53
        Me.GroupPanel2.Text = "Filtro, busqueda"
        '
        'ComboBoxEx1
        '
        Me.ComboBoxEx1.DisplayMember = "Text"
        Me.ComboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxEx1.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxEx1.FormattingEnabled = True
        Me.ComboBoxEx1.ItemHeight = 16
        Me.ComboBoxEx1.Location = New System.Drawing.Point(697, 10)
        Me.ComboBoxEx1.Name = "ComboBoxEx1"
        Me.ComboBoxEx1.Size = New System.Drawing.Size(131, 22)
        Me.ComboBoxEx1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBoxEx1.TabIndex = 18
        Me.ComboBoxEx1.Visible = False
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(635, 9)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(56, 23)
        Me.LabelX3.TabIndex = 19
        Me.LabelX3.Text = "Tipo Doc:"
        Me.LabelX3.Visible = False
        '
        'Cmb_Estado
        '
        Me.Cmb_Estado.DisplayMember = "Text"
        Me.Cmb_Estado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Estado.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Estado.FormattingEnabled = True
        Me.Cmb_Estado.ItemHeight = 16
        Me.Cmb_Estado.Location = New System.Drawing.Point(476, 9)
        Me.Cmb_Estado.Name = "Cmb_Estado"
        Me.Cmb_Estado.Size = New System.Drawing.Size(131, 22)
        Me.Cmb_Estado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Estado.TabIndex = 16
        Me.Cmb_Estado.Visible = False
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(436, 9)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(44, 23)
        Me.LabelX1.TabIndex = 17
        Me.LabelX1.Text = "Estado"
        Me.LabelX1.Visible = False
        '
        'Txt_Descripcion
        '
        Me.Txt_Descripcion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Descripcion.Border.Class = "TextBoxBorder"
        Me.Txt_Descripcion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Descripcion.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Descripcion.ForeColor = System.Drawing.Color.Black
        Me.Txt_Descripcion.Location = New System.Drawing.Point(52, 9)
        Me.Txt_Descripcion.Name = "Txt_Descripcion"
        Me.Txt_Descripcion.PreventEnterBeep = True
        Me.Txt_Descripcion.Size = New System.Drawing.Size(368, 22)
        Me.Txt_Descripcion.TabIndex = 14
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(5, 6)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(68, 23)
        Me.LabelX2.TabIndex = 15
        Me.LabelX2.Text = "Buscar..."
        '
        'Chk_RechazadoSII
        '
        Me.Chk_RechazadoSII.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_RechazadoSII.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_RechazadoSII.CheckBoxImageChecked = CType(resources.GetObject("Chk_RechazadoSII.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_RechazadoSII.CheckBoxImageUnChecked = CType(resources.GetObject("Chk_RechazadoSII.CheckBoxImageUnChecked"), System.Drawing.Image)
        Me.Chk_RechazadoSII.Enabled = False
        Me.Chk_RechazadoSII.ForeColor = System.Drawing.Color.Black
        Me.Chk_RechazadoSII.Location = New System.Drawing.Point(325, 465)
        Me.Chk_RechazadoSII.Name = "Chk_RechazadoSII"
        Me.Chk_RechazadoSII.Size = New System.Drawing.Size(70, 22)
        Me.Chk_RechazadoSII.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_RechazadoSII.TabIndex = 52
        Me.Chk_RechazadoSII.Text = "Rechazado"
        '
        'Chk_AceptadoReparos
        '
        Me.Chk_AceptadoReparos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_AceptadoReparos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_AceptadoReparos.CheckBoxImageChecked = CType(resources.GetObject("Chk_AceptadoReparos.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_AceptadoReparos.CheckBoxImageUnChecked = CType(resources.GetObject("Chk_AceptadoReparos.CheckBoxImageUnChecked"), System.Drawing.Image)
        Me.Chk_AceptadoReparos.Enabled = False
        Me.Chk_AceptadoReparos.ForeColor = System.Drawing.Color.Black
        Me.Chk_AceptadoReparos.Location = New System.Drawing.Point(209, 465)
        Me.Chk_AceptadoReparos.Name = "Chk_AceptadoReparos"
        Me.Chk_AceptadoReparos.Size = New System.Drawing.Size(113, 22)
        Me.Chk_AceptadoReparos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_AceptadoReparos.TabIndex = 51
        Me.Chk_AceptadoReparos.Text = "Aceptado/Reparos"
        '
        'Chk_AceptadoSII
        '
        Me.Chk_AceptadoSII.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_AceptadoSII.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_AceptadoSII.CheckBoxImageChecked = CType(resources.GetObject("Chk_AceptadoSII.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_AceptadoSII.CheckBoxImageUnChecked = CType(resources.GetObject("Chk_AceptadoSII.CheckBoxImageUnChecked"), System.Drawing.Image)
        Me.Chk_AceptadoSII.Enabled = False
        Me.Chk_AceptadoSII.ForeColor = System.Drawing.Color.Black
        Me.Chk_AceptadoSII.Location = New System.Drawing.Point(137, 465)
        Me.Chk_AceptadoSII.Name = "Chk_AceptadoSII"
        Me.Chk_AceptadoSII.Size = New System.Drawing.Size(70, 22)
        Me.Chk_AceptadoSII.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_AceptadoSII.TabIndex = 50
        Me.Chk_AceptadoSII.Text = "Aceptado"
        '
        'Chk_EnviadoSII
        '
        Me.Chk_EnviadoSII.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_EnviadoSII.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_EnviadoSII.CheckBoxImageChecked = CType(resources.GetObject("Chk_EnviadoSII.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_EnviadoSII.CheckBoxImageUnChecked = CType(resources.GetObject("Chk_EnviadoSII.CheckBoxImageUnChecked"), System.Drawing.Image)
        Me.Chk_EnviadoSII.Enabled = False
        Me.Chk_EnviadoSII.ForeColor = System.Drawing.Color.Black
        Me.Chk_EnviadoSII.Location = New System.Drawing.Point(75, 465)
        Me.Chk_EnviadoSII.Name = "Chk_EnviadoSII"
        Me.Chk_EnviadoSII.Size = New System.Drawing.Size(68, 22)
        Me.Chk_EnviadoSII.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_EnviadoSII.TabIndex = 49
        Me.Chk_EnviadoSII.Text = "Enviado"
        '
        'Chk_DocFirmado
        '
        Me.Chk_DocFirmado.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_DocFirmado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_DocFirmado.CheckBoxImageChecked = CType(resources.GetObject("Chk_DocFirmado.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_DocFirmado.CheckBoxImageUnChecked = CType(resources.GetObject("Chk_DocFirmado.CheckBoxImageUnChecked"), System.Drawing.Image)
        Me.Chk_DocFirmado.Enabled = False
        Me.Chk_DocFirmado.ForeColor = System.Drawing.Color.Black
        Me.Chk_DocFirmado.Location = New System.Drawing.Point(12, 465)
        Me.Chk_DocFirmado.Name = "Chk_DocFirmado"
        Me.Chk_DocFirmado.Size = New System.Drawing.Size(61, 22)
        Me.Chk_DocFirmado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_DocFirmado.TabIndex = 48
        Me.Chk_DocFirmado.Text = "Firmado"
        '
        'Btn_Mnu_Exportar_XML_Hefesto
        '
        Me.Btn_Mnu_Exportar_XML_Hefesto.Image = CType(resources.GetObject("Btn_Mnu_Exportar_XML_Hefesto.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Exportar_XML_Hefesto.ImageAlt = CType(resources.GetObject("Btn_Mnu_Exportar_XML_Hefesto.ImageAlt"), System.Drawing.Image)
        Me.Btn_Mnu_Exportar_XML_Hefesto.Name = "Btn_Mnu_Exportar_XML_Hefesto"
        Me.Btn_Mnu_Exportar_XML_Hefesto.Text = "Exportar XML"
        '
        'Frm_MantFacturasElectronicas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 585)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.Chk_RechazadoSII)
        Me.Controls.Add(Me.Chk_AceptadoReparos)
        Me.Controls.Add(Me.Chk_AceptadoSII)
        Me.Controls.Add(Me.Chk_EnviadoSII)
        Me.Controls.Add(Me.Chk_DocFirmado)
        Me.Controls.Add(Me.Txt_Leyenda)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.MStb_Barra)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_MantFacturasElectronicas"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REPORTE DEL ESTADO DE LOS ENVIO DTE AL SII"
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Actualizar_Datos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Ver_Documento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Firmar_Documento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Reenviar_Correo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents CircularProgressItem1 As DevComponents.DotNetBar.CircularProgressItem
    Friend WithEvents Btn_Reenviar_SII As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MStb_Barra As DevComponents.DotNetBar.Metro.MetroStatusBar
    Friend WithEvents Lbl_Etiqueta As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Actualizar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_ReConsultar_Trackid As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Img_Imagenes As ImageList
    Friend WithEvents Img_Imagenes_Dark As ImageList
    Friend WithEvents Txt_Leyenda As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Chk_SoloFirmadosXBakapp As DevComponents.DotNetBar.CheckBoxItem
    Friend WithEvents Lbl_LeyendaDoc As DevComponents.DotNetBar.LabelItem
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Txt_Descripcion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ComboBoxEx1 As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Cmb_Estado As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Chk_RechazadoSII As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_AceptadoReparos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_AceptadoSII As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_EnviadoSII As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_DocFirmado As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Lbl_AEC As DevComponents.DotNetBar.LabelItem
    Public WithEvents Btn_CesionarDTE As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_Exportar_XML_Hefesto As DevComponents.DotNetBar.ButtonItem
End Class
