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
        Me.Tab_Pendientes = New DevComponents.DotNetBar.SuperTabItem()
        Me.Tab_Ingresadas = New DevComponents.DotNetBar.SuperTabItem()
        Me.Tab_Preparacion = New DevComponents.DotNetBar.SuperTabItem()
        Me.Tab_Completadas = New DevComponents.DotNetBar.SuperTabItem()
        Me.Tab_Facturadas = New DevComponents.DotNetBar.SuperTabItem()
        Me.Tab_Entregadas = New DevComponents.DotNetBar.SuperTabItem()
        Me.Tab_Cerradas = New DevComponents.DotNetBar.SuperTabItem()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_AgregarTicket = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_SalaEsperaFacturar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_EntregarMercaderia = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Exportar_Excel = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Actualizar = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnIrAptincipio = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnIrAlFin = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_ConfLocal = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Menu_Contextual = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_01_Opciones_Documento = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_VerDocumento = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Imprimir = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Preparacion = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_EntregarMercaderia = New DevComponents.DotNetBar.ButtonItem()
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
        Me.Chk_Monitorear = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Timer_Monitoreo = New System.Windows.Forms.Timer(Me.components)
        Me.CircularPgrs = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.Metro_Bar_Color = New DevComponents.DotNetBar.Metro.MetroStatusBar()
        Me.Lbl_Estatus = New DevComponents.DotNetBar.LabelItem()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Filtrar = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Chk_VerIngresadas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Informacion = New DevComponents.DotNetBar.LabelX()
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
        Me.Super_TabS.Size = New System.Drawing.Size(592, 27)
        Me.Super_TabS.TabCloseButtonHot = Nothing
        Me.Super_TabS.TabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Super_TabS.TabIndex = 169
        Me.Super_TabS.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Tab_Pendientes, Me.Tab_Ingresadas, Me.Tab_Preparacion, Me.Tab_Completadas, Me.Tab_Facturadas, Me.Tab_Entregadas, Me.Tab_Cerradas})
        Me.Super_TabS.Text = "Nulas"
        '
        'Tab_Pendientes
        '
        Me.Tab_Pendientes.GlobalItem = False
        Me.Tab_Pendientes.Name = "Tab_Pendientes"
        Me.Tab_Pendientes.Text = "Pendientes"
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
        'Tab_Entregadas
        '
        Me.Tab_Entregadas.GlobalItem = False
        Me.Tab_Entregadas.Name = "Tab_Entregadas"
        Me.Tab_Entregadas.Text = "Entregadas"
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
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_AgregarTicket, Me.Btn_SalaEsperaFacturar, Me.Btn_EntregarMercaderia, Me.Btn_Exportar_Excel, Me.Btn_Actualizar, Me.BtnIrAptincipio, Me.BtnIrAlFin, Me.Btn_ConfLocal})
        Me.Bar2.Location = New System.Drawing.Point(0, 567)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(1204, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 166
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_AgregarTicket
        '
        Me.Btn_AgregarTicket.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_AgregarTicket.ForeColor = System.Drawing.Color.Black
        Me.Btn_AgregarTicket.Image = CType(resources.GetObject("Btn_AgregarTicket.Image"), System.Drawing.Image)
        Me.Btn_AgregarTicket.ImageAlt = CType(resources.GetObject("Btn_AgregarTicket.ImageAlt"), System.Drawing.Image)
        Me.Btn_AgregarTicket.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_AgregarTicket.Name = "Btn_AgregarTicket"
        Me.Btn_AgregarTicket.Tooltip = "Agregar Ticket buscando por numero de nota de venta"
        '
        'Btn_SalaEsperaFacturar
        '
        Me.Btn_SalaEsperaFacturar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_SalaEsperaFacturar.ForeColor = System.Drawing.Color.Black
        Me.Btn_SalaEsperaFacturar.Image = CType(resources.GetObject("Btn_SalaEsperaFacturar.Image"), System.Drawing.Image)
        Me.Btn_SalaEsperaFacturar.ImageAlt = CType(resources.GetObject("Btn_SalaEsperaFacturar.ImageAlt"), System.Drawing.Image)
        Me.Btn_SalaEsperaFacturar.Name = "Btn_SalaEsperaFacturar"
        Me.Btn_SalaEsperaFacturar.Text = "Facturar al completar"
        '
        'Btn_EntregarMercaderia
        '
        Me.Btn_EntregarMercaderia.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_EntregarMercaderia.ForeColor = System.Drawing.Color.Black
        Me.Btn_EntregarMercaderia.Image = CType(resources.GetObject("Btn_EntregarMercaderia.Image"), System.Drawing.Image)
        Me.Btn_EntregarMercaderia.ImageAlt = CType(resources.GetObject("Btn_EntregarMercaderia.ImageAlt"), System.Drawing.Image)
        Me.Btn_EntregarMercaderia.Name = "Btn_EntregarMercaderia"
        Me.Btn_EntregarMercaderia.Text = "Entregar mercadería"
        Me.Btn_EntregarMercaderia.Tooltip = "Entregar mercadería"
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
        'BtnIrAptincipio
        '
        Me.BtnIrAptincipio.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnIrAptincipio.ForeColor = System.Drawing.Color.Black
        Me.BtnIrAptincipio.Image = CType(resources.GetObject("BtnIrAptincipio.Image"), System.Drawing.Image)
        Me.BtnIrAptincipio.ImageAlt = CType(resources.GetObject("BtnIrAptincipio.ImageAlt"), System.Drawing.Image)
        Me.BtnIrAptincipio.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnIrAptincipio.Name = "BtnIrAptincipio"
        Me.BtnIrAptincipio.Tooltip = "Ir al primer registro"
        '
        'BtnIrAlFin
        '
        Me.BtnIrAlFin.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnIrAlFin.ForeColor = System.Drawing.Color.Black
        Me.BtnIrAlFin.Image = CType(resources.GetObject("BtnIrAlFin.Image"), System.Drawing.Image)
        Me.BtnIrAlFin.ImageAlt = CType(resources.GetObject("BtnIrAlFin.ImageAlt"), System.Drawing.Image)
        Me.BtnIrAlFin.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnIrAlFin.Name = "BtnIrAlFin"
        Me.BtnIrAlFin.Tooltip = "Ir al último registro"
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
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Menu_Contextual)
        Me.GroupPanel1.Controls.Add(Me.Grilla)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 45)
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
        Me.GroupPanel1.TabIndex = 165
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
        'Btn_Imprimir
        '
        Me.Btn_Imprimir.Image = CType(resources.GetObject("Btn_Imprimir.Image"), System.Drawing.Image)
        Me.Btn_Imprimir.ImageAlt = CType(resources.GetObject("Btn_Imprimir.ImageAlt"), System.Drawing.Image)
        Me.Btn_Imprimir.Name = "Btn_Imprimir"
        Me.Btn_Imprimir.Text = "Imprimir"
        '
        'Btn_Mnu_Preparacion
        '
        Me.Btn_Mnu_Preparacion.Image = CType(resources.GetObject("Btn_Mnu_Preparacion.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Preparacion.ImageAlt = CType(resources.GetObject("Btn_Mnu_Preparacion.ImageAlt"), System.Drawing.Image)
        Me.Btn_Mnu_Preparacion.Name = "Btn_Mnu_Preparacion"
        Me.Btn_Mnu_Preparacion.Text = "Enviar a preparación "
        '
        'Btn_Mnu_EntregarMercaderia
        '
        Me.Btn_Mnu_EntregarMercaderia.Image = CType(resources.GetObject("Btn_Mnu_EntregarMercaderia.Image"), System.Drawing.Image)
        Me.Btn_Mnu_EntregarMercaderia.ImageAlt = CType(resources.GetObject("Btn_Mnu_EntregarMercaderia.ImageAlt"), System.Drawing.Image)
        Me.Btn_Mnu_EntregarMercaderia.Name = "Btn_Mnu_EntregarMercaderia"
        Me.Btn_Mnu_EntregarMercaderia.Text = "Entregar mercadería"
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
        'Chk_Monitorear
        '
        Me.Chk_Monitorear.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Monitorear.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Monitorear.CheckBoxImageChecked = CType(resources.GetObject("Chk_Monitorear.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Monitorear.FocusCuesEnabled = False
        Me.Chk_Monitorear.ForeColor = System.Drawing.Color.Black
        Me.Chk_Monitorear.Location = New System.Drawing.Point(12, 540)
        Me.Chk_Monitorear.Name = "Chk_Monitorear"
        Me.Chk_Monitorear.Size = New System.Drawing.Size(169, 23)
        Me.Chk_Monitorear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Monitorear.TabIndex = 170
        Me.Chk_Monitorear.Text = "Monitorear automáticamente"
        '
        'Timer_Monitoreo
        '
        '
        'CircularPgrs
        '
        Me.CircularPgrs.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CircularPgrs.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.CircularPgrs.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CircularPgrs.Enabled = False
        Me.CircularPgrs.FocusCuesEnabled = False
        Me.CircularPgrs.Location = New System.Drawing.Point(1153, 19)
        Me.CircularPgrs.Name = "CircularPgrs"
        Me.CircularPgrs.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Dot
        Me.CircularPgrs.ProgressColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CircularPgrs.Size = New System.Drawing.Size(35, 20)
        Me.CircularPgrs.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.CircularPgrs.TabIndex = 171
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
        Me.Metro_Bar_Color.Location = New System.Drawing.Point(0, 608)
        Me.Metro_Bar_Color.Name = "Metro_Bar_Color"
        Me.Metro_Bar_Color.Size = New System.Drawing.Size(1204, 22)
        Me.Metro_Bar_Color.TabIndex = 172
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
        Me.LabelX1.Location = New System.Drawing.Point(626, 17)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(57, 23)
        Me.LabelX1.TabIndex = 174
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
        Me.Txt_Filtrar.ButtonCustom2.Image = CType(resources.GetObject("Txt_Filtrar.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Filtrar.ButtonCustom2.Visible = True
        Me.Txt_Filtrar.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Filtrar.ForeColor = System.Drawing.Color.Black
        Me.Txt_Filtrar.Location = New System.Drawing.Point(689, 17)
        Me.Txt_Filtrar.Name = "Txt_Filtrar"
        Me.Txt_Filtrar.PreventEnterBeep = True
        Me.Txt_Filtrar.Size = New System.Drawing.Size(458, 22)
        Me.Txt_Filtrar.TabIndex = 173
        '
        'Chk_VerIngresadas
        '
        Me.Chk_VerIngresadas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_VerIngresadas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_VerIngresadas.CheckBoxImageChecked = CType(resources.GetObject("Chk_VerIngresadas.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_VerIngresadas.FocusCuesEnabled = False
        Me.Chk_VerIngresadas.ForeColor = System.Drawing.Color.Black
        Me.Chk_VerIngresadas.Location = New System.Drawing.Point(187, 540)
        Me.Chk_VerIngresadas.Name = "Chk_VerIngresadas"
        Me.Chk_VerIngresadas.Size = New System.Drawing.Size(184, 23)
        Me.Chk_VerIngresadas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_VerIngresadas.TabIndex = 175
        Me.Chk_VerIngresadas.Text = "Ver ingresadas y no planificadas"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(12, 507)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 23)
        Me.LabelX2.TabIndex = 176
        Me.LabelX2.Text = "Información:"
        '
        'Lbl_Informacion
        '
        Me.Lbl_Informacion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Informacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Informacion.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Informacion.Location = New System.Drawing.Point(79, 507)
        Me.Lbl_Informacion.Name = "Lbl_Informacion"
        Me.Lbl_Informacion.Size = New System.Drawing.Size(1115, 23)
        Me.Lbl_Informacion.TabIndex = 177
        Me.Lbl_Informacion.Text = "..."
        '
        'Frm_Stmp_Listado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1204, 630)
        Me.Controls.Add(Me.Lbl_Informacion)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.Chk_VerIngresadas)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Txt_Filtrar)
        Me.Controls.Add(Me.CircularPgrs)
        Me.Controls.Add(Me.Chk_Monitorear)
        Me.Controls.Add(Me.Super_TabS)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Metro_Bar_Color)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Stmp_Listado"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SISTEMA DE ENTREGA DE MERCADERIA POR TICKET"
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
    Public WithEvents Btn_Actualizar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Menu_Contextual As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Imagenes_16x16 As ImageList
    Friend WithEvents Imagenes_16x16_Dark As ImageList
    Public WithEvents Chk_Monitorear As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Tab_Entregadas As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents Timer_Monitoreo As Timer
    Friend WithEvents CircularPgrs As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Menu_Contextual_01_Opciones_Documento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_VerDocumento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Imprimir As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_EntregarMercaderia As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_SalaEsperaFacturar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_AgregarTicket As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Menu_Contextual_01_Opciones_AgregarTicket As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_AgregarConNumero As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_AgregarBuscando As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem3 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Copiar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnIrAptincipio As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnIrAlFin As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Tab_Pendientes As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents Metro_Bar_Color As DevComponents.DotNetBar.Metro.MetroStatusBar
    Friend WithEvents Lbl_Estatus As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Mnu_EntregarMercaderia As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Filtrar As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Btn_Exportar_Excel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_CerrarTicket As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Tab_Ingresadas As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents Btn_Mnu_Preparacion As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Chk_VerIngresadas As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Btn_ConfLocal As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Informacion As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_ReenviaFacturar As DevComponents.DotNetBar.ButtonItem
End Class
