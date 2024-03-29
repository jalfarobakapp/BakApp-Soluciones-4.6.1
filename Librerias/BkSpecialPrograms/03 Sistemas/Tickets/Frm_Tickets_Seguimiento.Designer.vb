<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Tickets_Seguimiento
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Tickets_Seguimiento))
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Menu_Contextual = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_Productos = New DevComponents.DotNetBar.ButtonItem()
        Me.Lbl_OpcProducto = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Estadisticas_Producto = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Consolidar_Stock_X_Producto = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Copiar = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_Cambio_Estado = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Mnu_EnviarMensajeRespuesta = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_RechazarTicket = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_CerrarTicket = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_CerrarTicketCrearNuevo = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_SolicitarCierre = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Anular = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_Ticker_Traza = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Mnu_TkAntecesor = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_TkSucesor = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.GrupoTicket = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Txt_Producto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_FUlt_Respuesta = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_FUlt_Mensaje = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Tipo = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_FechaCreacion = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Area = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Estado = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_GestionarAcciones = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_VerTicketOrigen = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_AgentesAsignados = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Cerrar = New DevComponents.DotNetBar.ButtonItem()
        Me.Txt_Descripcion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Imagenes_16x16 = New System.Windows.Forms.ImageList(Me.components)
        Me.Imagenes_16x16_Dark = New System.Windows.Forms.ImageList(Me.components)
        Me.Btn_MensajeRespuesta = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_TkHistoria = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Menu_Contextual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrupoTicket.SuspendLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Menu_Contextual)
        Me.GroupPanel1.Controls.Add(Me.Grilla)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 151)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(667, 196)
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
        Me.GroupPanel1.TabIndex = 161
        Me.GroupPanel1.Text = "Historia"
        '
        'Menu_Contextual
        '
        Me.Menu_Contextual.AntiAlias = True
        Me.Menu_Contextual.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Menu_Contextual.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_Productos, Me.Menu_Contextual_Cambio_Estado, Me.Menu_Contextual_Ticker_Traza})
        Me.Menu_Contextual.Location = New System.Drawing.Point(18, 21)
        Me.Menu_Contextual.Name = "Menu_Contextual"
        Me.Menu_Contextual.Size = New System.Drawing.Size(602, 25)
        Me.Menu_Contextual.Stretch = True
        Me.Menu_Contextual.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Menu_Contextual.TabIndex = 48
        Me.Menu_Contextual.TabStop = False
        Me.Menu_Contextual.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_Productos
        '
        Me.Menu_Contextual_Productos.AutoExpandOnClick = True
        Me.Menu_Contextual_Productos.Name = "Menu_Contextual_Productos"
        Me.Menu_Contextual_Productos.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Lbl_OpcProducto, Me.Btn_Estadisticas_Producto, Me.Btn_Consolidar_Stock_X_Producto, Me.Btn_Copiar})
        Me.Menu_Contextual_Productos.Text = "Opciones productos"
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
        'Menu_Contextual_Cambio_Estado
        '
        Me.Menu_Contextual_Cambio_Estado.AutoExpandOnClick = True
        Me.Menu_Contextual_Cambio_Estado.Name = "Menu_Contextual_Cambio_Estado"
        Me.Menu_Contextual_Cambio_Estado.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1, Me.Btn_Mnu_EnviarMensajeRespuesta, Me.Btn_Mnu_RechazarTicket, Me.Btn_Mnu_CerrarTicket, Me.Btn_Mnu_CerrarTicketCrearNuevo, Me.Btn_Mnu_SolicitarCierre, Me.Btn_Anular})
        Me.Menu_Contextual_Cambio_Estado.Text = "Opciones cambio de estado"
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
        Me.Btn_Mnu_CerrarTicketCrearNuevo.Text = "Cerrar/Aceptar Ticket y crear nuevo Ticket a partir de este para seguir el hilo."
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
        'Menu_Contextual_Ticker_Traza
        '
        Me.Menu_Contextual_Ticker_Traza.AutoExpandOnClick = True
        Me.Menu_Contextual_Ticker_Traza.Name = "Menu_Contextual_Ticker_Traza"
        Me.Menu_Contextual_Ticker_Traza.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem2, Me.Btn_Mnu_TkHistoria, Me.Btn_Mnu_TkAntecesor, Me.Btn_Mnu_TkSucesor})
        Me.Menu_Contextual_Ticker_Traza.Text = "Opciones traza ticket"
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
        Me.LabelItem2.Text = "Trazabilidad del Ticket"
        '
        'Btn_Mnu_TkAntecesor
        '
        Me.Btn_Mnu_TkAntecesor.Image = CType(resources.GetObject("Btn_Mnu_TkAntecesor.Image"), System.Drawing.Image)
        Me.Btn_Mnu_TkAntecesor.ImageAlt = CType(resources.GetObject("Btn_Mnu_TkAntecesor.ImageAlt"), System.Drawing.Image)
        Me.Btn_Mnu_TkAntecesor.Name = "Btn_Mnu_TkAntecesor"
        Me.Btn_Mnu_TkAntecesor.Text = "Ticket de origen (Antecesor)"
        Me.Btn_Mnu_TkAntecesor.Tooltip = "Ticket que se crea como resultado de una acción o una demanda."
        '
        'Btn_Mnu_TkSucesor
        '
        Me.Btn_Mnu_TkSucesor.Image = CType(resources.GetObject("Btn_Mnu_TkSucesor.Image"), System.Drawing.Image)
        Me.Btn_Mnu_TkSucesor.ImageAlt = CType(resources.GetObject("Btn_Mnu_TkSucesor.ImageAlt"), System.Drawing.Image)
        Me.Btn_Mnu_TkSucesor.Name = "Btn_Mnu_TkSucesor"
        Me.Btn_Mnu_TkSucesor.Text = "Ticket de cierre (Sucesor)"
        Me.Btn_Mnu_TkSucesor.Tooltip = "Ticket que se crea como confirmación de que se ha solucionado el problema o se ha" &
    " cumplido la demanda."
        Me.Btn_Mnu_TkSucesor.Visible = False
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
        Me.Grilla.Size = New System.Drawing.Size(661, 173)
        Me.Grilla.StandardTab = True
        Me.Grilla.TabIndex = 27
        '
        'GrupoTicket
        '
        Me.GrupoTicket.BackColor = System.Drawing.Color.White
        Me.GrupoTicket.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GrupoTicket.Controls.Add(Me.Txt_Producto)
        Me.GrupoTicket.Controls.Add(Me.LabelX7)
        Me.GrupoTicket.Controls.Add(Me.Lbl_FUlt_Respuesta)
        Me.GrupoTicket.Controls.Add(Me.Lbl_FUlt_Mensaje)
        Me.GrupoTicket.Controls.Add(Me.Lbl_Tipo)
        Me.GrupoTicket.Controls.Add(Me.Lbl_FechaCreacion)
        Me.GrupoTicket.Controls.Add(Me.Lbl_Area)
        Me.GrupoTicket.Controls.Add(Me.Lbl_Estado)
        Me.GrupoTicket.Controls.Add(Me.LabelX6)
        Me.GrupoTicket.Controls.Add(Me.LabelX5)
        Me.GrupoTicket.Controls.Add(Me.LabelX4)
        Me.GrupoTicket.Controls.Add(Me.LabelX3)
        Me.GrupoTicket.Controls.Add(Me.LabelX2)
        Me.GrupoTicket.Controls.Add(Me.LabelX1)
        Me.GrupoTicket.DisabledBackColor = System.Drawing.Color.Empty
        Me.GrupoTicket.Location = New System.Drawing.Point(12, 5)
        Me.GrupoTicket.Name = "GrupoTicket"
        Me.GrupoTicket.Size = New System.Drawing.Size(667, 140)
        '
        '
        '
        Me.GrupoTicket.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GrupoTicket.Style.BackColorGradientAngle = 90
        Me.GrupoTicket.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GrupoTicket.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GrupoTicket.Style.BorderBottomWidth = 1
        Me.GrupoTicket.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GrupoTicket.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GrupoTicket.Style.BorderLeftWidth = 1
        Me.GrupoTicket.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GrupoTicket.Style.BorderRightWidth = 1
        Me.GrupoTicket.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GrupoTicket.Style.BorderTopWidth = 1
        Me.GrupoTicket.Style.CornerDiameter = 4
        Me.GrupoTicket.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GrupoTicket.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GrupoTicket.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GrupoTicket.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GrupoTicket.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GrupoTicket.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GrupoTicket.TabIndex = 162
        Me.GrupoTicket.Text = "Ticket"
        '
        'Txt_Producto
        '
        Me.Txt_Producto.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Producto.Border.Class = "TextBoxBorder"
        Me.Txt_Producto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Producto.ButtonCustom.Image = CType(resources.GetObject("Txt_Producto.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Producto.ButtonCustom.Visible = True
        Me.Txt_Producto.ButtonCustom2.Image = CType(resources.GetObject("Txt_Producto.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Producto.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Producto.Enabled = False
        Me.Txt_Producto.ForeColor = System.Drawing.Color.Black
        Me.Txt_Producto.Location = New System.Drawing.Point(117, 90)
        Me.Txt_Producto.Name = "Txt_Producto"
        Me.Txt_Producto.PreventEnterBeep = True
        Me.Txt_Producto.ReadOnly = True
        Me.Txt_Producto.Size = New System.Drawing.Size(541, 22)
        Me.Txt_Producto.TabIndex = 14
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX7.ForeColor = System.Drawing.Color.Black
        Me.LabelX7.Location = New System.Drawing.Point(3, 90)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(114, 23)
        Me.LabelX7.TabIndex = 13
        Me.LabelX7.Text = "Producto"
        '
        'Lbl_FUlt_Respuesta
        '
        Me.Lbl_FUlt_Respuesta.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_FUlt_Respuesta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_FUlt_Respuesta.ForeColor = System.Drawing.Color.Black
        Me.Lbl_FUlt_Respuesta.Location = New System.Drawing.Point(396, 61)
        Me.Lbl_FUlt_Respuesta.Name = "Lbl_FUlt_Respuesta"
        Me.Lbl_FUlt_Respuesta.Size = New System.Drawing.Size(153, 23)
        Me.Lbl_FUlt_Respuesta.TabIndex = 12
        Me.Lbl_FUlt_Respuesta.Text = "Tipo"
        '
        'Lbl_FUlt_Mensaje
        '
        Me.Lbl_FUlt_Mensaje.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_FUlt_Mensaje.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_FUlt_Mensaje.ForeColor = System.Drawing.Color.Black
        Me.Lbl_FUlt_Mensaje.Location = New System.Drawing.Point(396, 32)
        Me.Lbl_FUlt_Mensaje.Name = "Lbl_FUlt_Mensaje"
        Me.Lbl_FUlt_Mensaje.Size = New System.Drawing.Size(153, 23)
        Me.Lbl_FUlt_Mensaje.TabIndex = 11
        Me.Lbl_FUlt_Mensaje.Text = "Tipo"
        '
        'Lbl_Tipo
        '
        Me.Lbl_Tipo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Tipo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Tipo.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Tipo.Location = New System.Drawing.Point(396, 3)
        Me.Lbl_Tipo.Name = "Lbl_Tipo"
        Me.Lbl_Tipo.Size = New System.Drawing.Size(153, 23)
        Me.Lbl_Tipo.TabIndex = 10
        Me.Lbl_Tipo.Text = "Tipo"
        '
        'Lbl_FechaCreacion
        '
        Me.Lbl_FechaCreacion.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_FechaCreacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_FechaCreacion.ForeColor = System.Drawing.Color.Black
        Me.Lbl_FechaCreacion.Location = New System.Drawing.Point(117, 61)
        Me.Lbl_FechaCreacion.Name = "Lbl_FechaCreacion"
        Me.Lbl_FechaCreacion.Size = New System.Drawing.Size(177, 23)
        Me.Lbl_FechaCreacion.TabIndex = 9
        Me.Lbl_FechaCreacion.Text = "Tipo"
        '
        'Lbl_Area
        '
        Me.Lbl_Area.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Area.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Area.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Area.Location = New System.Drawing.Point(117, 32)
        Me.Lbl_Area.Name = "Lbl_Area"
        Me.Lbl_Area.Size = New System.Drawing.Size(177, 23)
        Me.Lbl_Area.TabIndex = 8
        Me.Lbl_Area.Text = "Tipo"
        '
        'Lbl_Estado
        '
        Me.Lbl_Estado.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Estado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Estado.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Estado.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Estado.Location = New System.Drawing.Point(117, 3)
        Me.Lbl_Estado.Name = "Lbl_Estado"
        Me.Lbl_Estado.Size = New System.Drawing.Size(162, 23)
        Me.Lbl_Estado.TabIndex = 7
        Me.Lbl_Estado.Text = "Tipo"
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(301, 61)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(89, 23)
        Me.LabelX6.TabIndex = 5
        Me.LabelX6.Text = "Ultima respuesta"
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(301, 32)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(89, 23)
        Me.LabelX5.TabIndex = 4
        Me.LabelX5.Text = "Ultimo mensaje"
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(301, 3)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(114, 23)
        Me.LabelX4.TabIndex = 3
        Me.LabelX4.Text = "Tema de ayuda"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(3, 61)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(114, 23)
        Me.LabelX3.TabIndex = 2
        Me.LabelX3.Text = "Fecha de creación"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 32)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(114, 23)
        Me.LabelX2.TabIndex = 1
        Me.LabelX2.Text = "Area/Departamento"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 23)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "Estado"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_GestionarAcciones, Me.Btn_VerTicketOrigen, Me.Btn_AgentesAsignados, Me.Btn_Cerrar})
        Me.Bar2.Location = New System.Drawing.Point(0, 536)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(689, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 165
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_GestionarAcciones
        '
        Me.Btn_GestionarAcciones.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_GestionarAcciones.ForeColor = System.Drawing.Color.Black
        Me.Btn_GestionarAcciones.Image = CType(resources.GetObject("Btn_GestionarAcciones.Image"), System.Drawing.Image)
        Me.Btn_GestionarAcciones.ImageAlt = CType(resources.GetObject("Btn_GestionarAcciones.ImageAlt"), System.Drawing.Image)
        Me.Btn_GestionarAcciones.Name = "Btn_GestionarAcciones"
        Me.Btn_GestionarAcciones.Text = "Gestionar acciones"
        '
        'Btn_VerTicketOrigen
        '
        Me.Btn_VerTicketOrigen.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_VerTicketOrigen.ForeColor = System.Drawing.Color.Black
        Me.Btn_VerTicketOrigen.Image = CType(resources.GetObject("Btn_VerTicketOrigen.Image"), System.Drawing.Image)
        Me.Btn_VerTicketOrigen.ImageAlt = CType(resources.GetObject("Btn_VerTicketOrigen.ImageAlt"), System.Drawing.Image)
        Me.Btn_VerTicketOrigen.Name = "Btn_VerTicketOrigen"
        Me.Btn_VerTicketOrigen.Text = "Traza de Ticket"
        '
        'Btn_AgentesAsignados
        '
        Me.Btn_AgentesAsignados.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_AgentesAsignados.ForeColor = System.Drawing.Color.Black
        Me.Btn_AgentesAsignados.Image = CType(resources.GetObject("Btn_AgentesAsignados.Image"), System.Drawing.Image)
        Me.Btn_AgentesAsignados.ImageAlt = CType(resources.GetObject("Btn_AgentesAsignados.ImageAlt"), System.Drawing.Image)
        Me.Btn_AgentesAsignados.Name = "Btn_AgentesAsignados"
        Me.Btn_AgentesAsignados.Tooltip = "Agentes asignados"
        '
        'Btn_Cerrar
        '
        Me.Btn_Cerrar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Cerrar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Btn_Cerrar.Image = CType(resources.GetObject("Btn_Cerrar.Image"), System.Drawing.Image)
        Me.Btn_Cerrar.ImageAlt = CType(resources.GetObject("Btn_Cerrar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Cerrar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Cerrar.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.Btn_Cerrar.Name = "Btn_Cerrar"
        Me.Btn_Cerrar.Tooltip = "Cerrar formulario"
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
        Me.Txt_Descripcion.Location = New System.Drawing.Point(3, 3)
        Me.Txt_Descripcion.MaxLength = 30
        Me.Txt_Descripcion.Multiline = True
        Me.Txt_Descripcion.Name = "Txt_Descripcion"
        Me.Txt_Descripcion.PreventEnterBeep = True
        Me.Txt_Descripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Descripcion.Size = New System.Drawing.Size(655, 133)
        Me.Txt_Descripcion.TabIndex = 166
        '
        'GroupPanel3
        '
        Me.GroupPanel3.BackColor = System.Drawing.Color.White
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.Txt_Descripcion)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Location = New System.Drawing.Point(12, 353)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(667, 162)
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
        Me.GroupPanel3.TabIndex = 168
        Me.GroupPanel3.Text = "Descripción..."
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
        Me.Imagenes_16x16.Images.SetKeyName(21, "attach-number-1.png")
        Me.Imagenes_16x16.Images.SetKeyName(22, "attach-number-2.png")
        Me.Imagenes_16x16.Images.SetKeyName(23, "attach-number-3.png")
        Me.Imagenes_16x16.Images.SetKeyName(24, "attach-number-4.png")
        Me.Imagenes_16x16.Images.SetKeyName(25, "attach-number-5.png")
        Me.Imagenes_16x16.Images.SetKeyName(26, "attach-number-6.png")
        Me.Imagenes_16x16.Images.SetKeyName(27, "attach-number-7.png")
        Me.Imagenes_16x16.Images.SetKeyName(28, "attach-number-8.png")
        Me.Imagenes_16x16.Images.SetKeyName(29, "attach-number-9.png")
        Me.Imagenes_16x16.Images.SetKeyName(30, "attach-number-9-plus.png")
        Me.Imagenes_16x16.Images.SetKeyName(31, "user.png")
        Me.Imagenes_16x16.Images.SetKeyName(32, "people-employee.png")
        Me.Imagenes_16x16.Images.SetKeyName(33, "people-vendor.png")
        Me.Imagenes_16x16.Images.SetKeyName(34, "people-customer-man.png")
        Me.Imagenes_16x16.Images.SetKeyName(35, "people-vendor-error.png")
        Me.Imagenes_16x16.Images.SetKeyName(36, "ticket-new.png")
        Me.Imagenes_16x16.Images.SetKeyName(37, "ticket-cancel.png")
        Me.Imagenes_16x16.Images.SetKeyName(38, "ticket-link.png")
        Me.Imagenes_16x16.Images.SetKeyName(39, "ticket-refresh.png")
        Me.Imagenes_16x16.Images.SetKeyName(40, "ticket-padlock.png")
        Me.Imagenes_16x16.Images.SetKeyName(41, "ticket-select.png")
        Me.Imagenes_16x16.Images.SetKeyName(42, "ticket-ok.png")
        Me.Imagenes_16x16.Images.SetKeyName(43, "ticket.png")
        Me.Imagenes_16x16.Images.SetKeyName(44, "ticket-add.png")
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
        Me.Imagenes_16x16_Dark.Images.SetKeyName(10, "comment-number-1.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(11, "comment-number-2.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(12, "comment-number-3.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(13, "comment-number-4.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(14, "comment-number-5.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(15, "comment-number-6.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(16, "comment-number-7.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(17, "comment-number-8.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(18, "comment-number-9.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(19, "comment-number-9-plus.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(20, "menu-more.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(21, "attach-number-1.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(22, "attach-number-2.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(23, "attach-number-3.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(24, "attach-number-4.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(25, "attach-number-5.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(26, "attach-number-6.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(27, "attach-number-7.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(28, "attach-number-8.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(29, "attach-number-9.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(30, "attach-number-9-plus.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(31, "people-vendor.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(32, "people-vendor-error.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(33, "people-employee.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(34, "people-customer-man.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(35, "user.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(36, "ticket-new.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(37, "ticket-cancel.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(38, "ticket-link.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(39, "ticket-refresh.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(40, "ticket-padlock.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(41, "ticket-select.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(42, "ticket-ok.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(43, "ticket-add.png")
        '
        'Btn_MensajeRespuesta
        '
        Me.Btn_MensajeRespuesta.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_MensajeRespuesta.ForeColor = System.Drawing.Color.Black
        Me.Btn_MensajeRespuesta.Image = CType(resources.GetObject("Btn_MensajeRespuesta.Image"), System.Drawing.Image)
        Me.Btn_MensajeRespuesta.ImageAlt = CType(resources.GetObject("Btn_MensajeRespuesta.ImageAlt"), System.Drawing.Image)
        Me.Btn_MensajeRespuesta.Name = "Btn_MensajeRespuesta"
        Me.Btn_MensajeRespuesta.Text = "Agregar mensaje"
        '
        'Btn_Mnu_TkHistoria
        '
        Me.Btn_Mnu_TkHistoria.Image = CType(resources.GetObject("Btn_Mnu_TkHistoria.Image"), System.Drawing.Image)
        Me.Btn_Mnu_TkHistoria.ImageAlt = CType(resources.GetObject("Btn_Mnu_TkHistoria.ImageAlt"), System.Drawing.Image)
        Me.Btn_Mnu_TkHistoria.Name = "Btn_Mnu_TkHistoria"
        Me.Btn_Mnu_TkHistoria.Text = "Ver toda la historia del Ticket"
        Me.Btn_Mnu_TkHistoria.Tooltip = "Muestra un detalle de la historia del Ticket desde el inicio al fin"
        '
        'Frm_Tickets_Seguimiento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(689, 577)
        Me.Controls.Add(Me.GroupPanel3)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.GrupoTicket)
        Me.Controls.Add(Me.GroupPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Tickets_Seguimiento"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.Menu_Contextual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrupoTicket.ResumeLayout(False)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Menu_Contextual As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents GrupoTicket As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_FUlt_Respuesta As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_FUlt_Mensaje As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Tipo As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_FechaCreacion As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Area As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Estado As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Txt_Descripcion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Imagenes_16x16 As ImageList
    Friend WithEvents Txt_Producto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Menu_Contextual_Productos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Lbl_OpcProducto As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Estadisticas_Producto As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Consolidar_Stock_X_Producto As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Copiar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Menu_Contextual_Cambio_Estado As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Anular As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_CerrarTicket As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_SolicitarCierre As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_CerrarTicketCrearNuevo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Cerrar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_VerTicketOrigen As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_AgentesAsignados As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_EnviarMensajeRespuesta As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_RechazarTicket As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Imagenes_16x16_Dark As ImageList
    Friend WithEvents Btn_GestionarAcciones As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_MensajeRespuesta As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Menu_Contextual_Ticker_Traza As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Mnu_TkAntecesor As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_TkSucesor As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_TkHistoria As DevComponents.DotNetBar.ButtonItem
End Class
