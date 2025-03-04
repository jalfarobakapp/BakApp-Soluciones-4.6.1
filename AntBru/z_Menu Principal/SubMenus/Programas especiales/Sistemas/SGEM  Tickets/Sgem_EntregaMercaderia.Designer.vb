<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Sgem_EntregaMercaderia
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Sgem_EntregaMercaderia))
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem()
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel()
        Me.ConsultaPreciosContenedor = New DevComponents.DotNetBar.ItemContainer()
        Me.Btn_MisTicket = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_TicketListaEspera = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Sgem_EntregarMercaderia = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Sgem_Rutas = New DevComponents.DotNetBar.Metro.MetroTileItem()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.LabelX1.Location = New System.Drawing.Point(3, 0)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(692, 49)
        Me.LabelX1.TabIndex = 66
        Me.LabelX1.Text = "<font color=""#349FCE""><b>Sistema de Gestión de Entrega de Mercadería (SGEM)</b></" &
    "font>"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSalir})
        Me.Bar2.Location = New System.Drawing.Point(0, 286)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(707, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 65
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'BtnSalir
        '
        Me.BtnSalir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnSalir.ForeColor = System.Drawing.Color.Black
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Tooltip = "Volver..."
        '
        'MetroTilePanel1
        '
        Me.MetroTilePanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.MetroTilePanel1.BackgroundStyle.Class = "MetroTilePanel"
        Me.MetroTilePanel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MetroTilePanel1.ContainerControlProcessDialogKey = True
        Me.MetroTilePanel1.DragDropSupport = True
        Me.MetroTilePanel1.ForeColor = System.Drawing.Color.Black
        Me.MetroTilePanel1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ConsultaPreciosContenedor})
        Me.MetroTilePanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MetroTilePanel1.Location = New System.Drawing.Point(3, 54)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(828, 445)
        Me.MetroTilePanel1.TabIndex = 64
        Me.MetroTilePanel1.Text = "MetroTilePanel1"
        '
        'ConsultaPreciosContenedor
        '
        '
        '
        '
        Me.ConsultaPreciosContenedor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ConsultaPreciosContenedor.FixedSize = New System.Drawing.Size(700, 400)
        Me.ConsultaPreciosContenedor.MultiLine = True
        Me.ConsultaPreciosContenedor.Name = "ConsultaPreciosContenedor"
        Me.ConsultaPreciosContenedor.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_MisTicket, Me.Btn_TicketListaEspera, Me.Btn_Sgem_EntregarMercaderia, Me.Btn_Sgem_Rutas})
        '
        '
        '
        Me.ConsultaPreciosContenedor.TitleStyle.Class = "MetroTileGroupTitle"
        Me.ConsultaPreciosContenedor.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ConsultaPreciosContenedor.TitleStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'Btn_MisTicket
        '
        Me.Btn_MisTicket.Image = CType(resources.GetObject("Btn_MisTicket.Image"), System.Drawing.Image)
        Me.Btn_MisTicket.ImageIndent = New System.Drawing.Point(8, -6)
        Me.Btn_MisTicket.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_MisTicket.Name = "Btn_MisTicket"
        Me.Btn_MisTicket.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_MisTicket.Text = "<font size=""+4""><b>TICKETS</b></font><br/><font size=""-1"">Lista de estado de los " &
    "documentos en gestión</font>"
        Me.Btn_MisTicket.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Yellow
        Me.Btn_MisTicket.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_MisTicket.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Btn_MisTicket.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Btn_MisTicket.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Btn_MisTicket.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Btn_MisTicket.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_MisTicket.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_MisTicket.TitleText = "BakApp"
        '
        'Btn_TicketListaEspera
        '
        Me.Btn_TicketListaEspera.Image = CType(resources.GetObject("Btn_TicketListaEspera.Image"), System.Drawing.Image)
        Me.Btn_TicketListaEspera.ImageIndent = New System.Drawing.Point(8, -6)
        Me.Btn_TicketListaEspera.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_TicketListaEspera.Name = "Btn_TicketListaEspera"
        Me.Btn_TicketListaEspera.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_TicketListaEspera.Text = "<font size=""+4""><b>VER LISTA DE ESPERA</b></font><br/><font size=""-1"">Tickes en l" &
    "ista de espera para mostrar a clientes</font>"
        Me.Btn_TicketListaEspera.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Yellow
        Me.Btn_TicketListaEspera.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_TicketListaEspera.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(137, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(163, Byte), Integer))
        Me.Btn_TicketListaEspera.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(137, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(163, Byte), Integer))
        Me.Btn_TicketListaEspera.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(137, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(163, Byte), Integer))
        Me.Btn_TicketListaEspera.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(137, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(163, Byte), Integer))
        Me.Btn_TicketListaEspera.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_TicketListaEspera.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_TicketListaEspera.TitleText = "BakApp"
        '
        'Btn_Sgem_EntregarMercaderia
        '
        Me.Btn_Sgem_EntregarMercaderia.Image = CType(resources.GetObject("Btn_Sgem_EntregarMercaderia.Image"), System.Drawing.Image)
        Me.Btn_Sgem_EntregarMercaderia.ImageIndent = New System.Drawing.Point(8, -6)
        Me.Btn_Sgem_EntregarMercaderia.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Sgem_EntregarMercaderia.Name = "Btn_Sgem_EntregarMercaderia"
        Me.Btn_Sgem_EntregarMercaderia.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Sgem_EntregarMercaderia.Text = "<font size=""+4""><b>ENTREGAR MERCADERIA</b></font><br/><font size=""-1"">Dar factura" &
    ", boleta o guía por entregada.</font>"
        Me.Btn_Sgem_EntregarMercaderia.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Teal
        Me.Btn_Sgem_EntregarMercaderia.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Sgem_EntregarMercaderia.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.Btn_Sgem_EntregarMercaderia.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.Btn_Sgem_EntregarMercaderia.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Sgem_EntregarMercaderia.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.Btn_Sgem_EntregarMercaderia.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.Btn_Sgem_EntregarMercaderia.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Sgem_EntregarMercaderia.TileStyle.PaddingBottom = 4
        Me.Btn_Sgem_EntregarMercaderia.TileStyle.PaddingLeft = 4
        Me.Btn_Sgem_EntregarMercaderia.TileStyle.PaddingRight = 4
        Me.Btn_Sgem_EntregarMercaderia.TileStyle.PaddingTop = 4
        Me.Btn_Sgem_EntregarMercaderia.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Sgem_EntregarMercaderia.TitleText = "BakApp"
        '
        'Btn_Sgem_Rutas
        '
        Me.Btn_Sgem_Rutas.Image = CType(resources.GetObject("Btn_Sgem_Rutas.Image"), System.Drawing.Image)
        Me.Btn_Sgem_Rutas.ImageIndent = New System.Drawing.Point(8, -6)
        Me.Btn_Sgem_Rutas.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Sgem_Rutas.Name = "Btn_Sgem_Rutas"
        Me.Btn_Sgem_Rutas.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Sgem_Rutas.Text = "<font size=""+4""><b>RUTAS</b></font><br/><font size=""-1"">Tickes en lista de espera" &
    " para mostrar a clientes</font>"
        Me.Btn_Sgem_Rutas.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Yellow
        Me.Btn_Sgem_Rutas.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Sgem_Rutas.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_Sgem_Rutas.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_Sgem_Rutas.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_Sgem_Rutas.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_Sgem_Rutas.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Sgem_Rutas.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Sgem_Rutas.TitleText = "BakApp"
        '
        'Sgem_EntregaMercaderia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.Name = "Sgem_EntregaMercaderia"
        Me.Size = New System.Drawing.Size(707, 327)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents ConsultaPreciosContenedor As DevComponents.DotNetBar.ItemContainer
    Private WithEvents Btn_MisTicket As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_TicketListaEspera As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Sgem_EntregarMercaderia As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Sgem_Rutas As DevComponents.DotNetBar.Metro.MetroTileItem
End Class
