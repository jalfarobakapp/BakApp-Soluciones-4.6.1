<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Modulo_Ventas
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Modulo_Ventas))
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnCambiarDeUsuario = New DevComponents.DotNetBar.ButtonItem()
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel()
        Me.ConsultaPreciosContenedor = New DevComponents.DotNetBar.ItemContainer()
        Me.BtnPostVenta = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_ProductoSolicitadosBodega = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Conf_CashDro = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.BtnBuscarDocumento = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Pago_Documentos = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Documentos_Venta = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Pagos_Generales_Cliente = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSalir, Me.BtnCambiarDeUsuario})
        Me.Bar2.Location = New System.Drawing.Point(0, 402)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(642, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 40
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
        '
        'BtnCambiarDeUsuario
        '
        Me.BtnCambiarDeUsuario.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnCambiarDeUsuario.ForeColor = System.Drawing.Color.Black
        Me.BtnCambiarDeUsuario.Image = CType(resources.GetObject("BtnCambiarDeUsuario.Image"), System.Drawing.Image)
        Me.BtnCambiarDeUsuario.ImageAlt = CType(resources.GetObject("BtnCambiarDeUsuario.ImageAlt"), System.Drawing.Image)
        Me.BtnCambiarDeUsuario.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnCambiarDeUsuario.Name = "BtnCambiarDeUsuario"
        Me.BtnCambiarDeUsuario.Tooltip = "Cambiar de usuario"
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
        Me.MetroTilePanel1.Location = New System.Drawing.Point(0, 58)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(703, 411)
        Me.MetroTilePanel1.TabIndex = 39
        Me.MetroTilePanel1.Text = "MetroTilePanel1"
        '
        'ConsultaPreciosContenedor
        '
        '
        '
        '
        Me.ConsultaPreciosContenedor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ConsultaPreciosContenedor.FixedSize = New System.Drawing.Size(650, 350)
        Me.ConsultaPreciosContenedor.MultiLine = True
        Me.ConsultaPreciosContenedor.Name = "ConsultaPreciosContenedor"
        Me.ConsultaPreciosContenedor.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnPostVenta, Me.Btn_ProductoSolicitadosBodega, Me.Btn_Conf_CashDro, Me.BtnBuscarDocumento, Me.Btn_Pago_Documentos, Me.Btn_Documentos_Venta, Me.Btn_Pagos_Generales_Cliente})
        '
        '
        '
        Me.ConsultaPreciosContenedor.TitleStyle.Class = "MetroTileGroupTitle"
        Me.ConsultaPreciosContenedor.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ConsultaPreciosContenedor.TitleStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'BtnPostVenta
        '
        Me.BtnPostVenta.Image = CType(resources.GetObject("BtnPostVenta.Image"), System.Drawing.Image)
        Me.BtnPostVenta.ImageIndent = New System.Drawing.Point(8, -10)
        Me.BtnPostVenta.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnPostVenta.Name = "BtnPostVenta"
        Me.BtnPostVenta.SymbolColor = System.Drawing.Color.Empty
        Me.BtnPostVenta.Text = "<font size=""+4""><b>POST-VENTA</b></font><br/>Ingreso a sistema de ventas<font siz" &
    "e=""-1""></font>"
        Me.BtnPostVenta.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.BtnPostVenta.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.BtnPostVenta.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.BtnPostVenta.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.BtnPostVenta.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.BtnPostVenta.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.BtnPostVenta.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.BtnPostVenta.TitleText = "BakApp"
        '
        'Btn_ProductoSolicitadosBodega
        '
        Me.Btn_ProductoSolicitadosBodega.Image = CType(resources.GetObject("Btn_ProductoSolicitadosBodega.Image"), System.Drawing.Image)
        Me.Btn_ProductoSolicitadosBodega.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_ProductoSolicitadosBodega.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_ProductoSolicitadosBodega.Name = "Btn_ProductoSolicitadosBodega"
        Me.Btn_ProductoSolicitadosBodega.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_ProductoSolicitadosBodega.Text = "<font size=""+4""><b>SOLICITUD PRODUCTO</b></font><br/><font size=""-1"">Administraci" &
    "ó de entrega y recepcion de productos prestados</font>"
        Me.Btn_ProductoSolicitadosBodega.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green
        Me.Btn_ProductoSolicitadosBodega.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_ProductoSolicitadosBodega.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(164, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(93, Byte), Integer))
        Me.Btn_ProductoSolicitadosBodega.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(164, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(93, Byte), Integer))
        Me.Btn_ProductoSolicitadosBodega.TileStyle.BackColorGradientAngle = 45
        Me.Btn_ProductoSolicitadosBodega.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(164, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(93, Byte), Integer))
        Me.Btn_ProductoSolicitadosBodega.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(164, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(93, Byte), Integer))
        Me.Btn_ProductoSolicitadosBodega.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_ProductoSolicitadosBodega.TileStyle.PaddingBottom = 4
        Me.Btn_ProductoSolicitadosBodega.TileStyle.PaddingLeft = 4
        Me.Btn_ProductoSolicitadosBodega.TileStyle.PaddingRight = 4
        Me.Btn_ProductoSolicitadosBodega.TileStyle.PaddingTop = 4
        Me.Btn_ProductoSolicitadosBodega.TileStyle.TextColor = System.Drawing.Color.White
        '
        'Btn_Conf_CashDro
        '
        Me.Btn_Conf_CashDro.Image = CType(resources.GetObject("Btn_Conf_CashDro.Image"), System.Drawing.Image)
        Me.Btn_Conf_CashDro.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Conf_CashDro.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Conf_CashDro.Name = "Btn_Conf_CashDro"
        Me.Btn_Conf_CashDro.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Conf_CashDro.Text = "<font size=""+4""><b>CASHDROP</b></font><br/><font size=""-1"">Configuración CashDro<" &
    "br/> </font>"
        Me.Btn_Conf_CashDro.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.PlumWashed
        Me.Btn_Conf_CashDro.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Conf_CashDro.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(123, Byte), Integer))
        Me.Btn_Conf_CashDro.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(123, Byte), Integer))
        Me.Btn_Conf_CashDro.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(123, Byte), Integer))
        Me.Btn_Conf_CashDro.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(123, Byte), Integer))
        Me.Btn_Conf_CashDro.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Conf_CashDro.TitleText = "BakApp"
        '
        'BtnBuscarDocumento
        '
        Me.BtnBuscarDocumento.Image = CType(resources.GetObject("BtnBuscarDocumento.Image"), System.Drawing.Image)
        Me.BtnBuscarDocumento.ImageIndent = New System.Drawing.Point(8, -10)
        Me.BtnBuscarDocumento.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnBuscarDocumento.Name = "BtnBuscarDocumento"
        Me.BtnBuscarDocumento.SymbolColor = System.Drawing.Color.Empty
        Me.BtnBuscarDocumento.Text = "<font size=""+4""><b>BUSCAR DOCUMENTOS</b></font><br/><font size=""-1""></font>"
        Me.BtnBuscarDocumento.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Teal
        Me.BtnBuscarDocumento.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.BtnBuscarDocumento.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.BtnBuscarDocumento.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.BtnBuscarDocumento.TileStyle.BackColorGradientAngle = 45
        Me.BtnBuscarDocumento.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.BtnBuscarDocumento.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.BtnBuscarDocumento.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.BtnBuscarDocumento.TileStyle.PaddingBottom = 4
        Me.BtnBuscarDocumento.TileStyle.PaddingLeft = 4
        Me.BtnBuscarDocumento.TileStyle.PaddingRight = 4
        Me.BtnBuscarDocumento.TileStyle.PaddingTop = 4
        Me.BtnBuscarDocumento.TileStyle.TextColor = System.Drawing.Color.White
        Me.BtnBuscarDocumento.TitleText = "BakApp"
        '
        'Btn_Pago_Documentos
        '
        Me.Btn_Pago_Documentos.Image = CType(resources.GetObject("Btn_Pago_Documentos.Image"), System.Drawing.Image)
        Me.Btn_Pago_Documentos.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Pago_Documentos.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Pago_Documentos.Name = "Btn_Pago_Documentos"
        Me.Btn_Pago_Documentos.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Pago_Documentos.Text = "<font size=""+4""><b>PAGO A DOCUMENTOS</b></font><br/><font size=""-1"">Sistema Caja<" &
    "br/> </font>"
        Me.Btn_Pago_Documentos.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.Btn_Pago_Documentos.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Pago_Documentos.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(81, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Btn_Pago_Documentos.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(81, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Btn_Pago_Documentos.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Pago_Documentos.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(81, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Btn_Pago_Documentos.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(81, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Btn_Pago_Documentos.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Pago_Documentos.TileStyle.PaddingBottom = 4
        Me.Btn_Pago_Documentos.TileStyle.PaddingLeft = 4
        Me.Btn_Pago_Documentos.TileStyle.PaddingRight = 4
        Me.Btn_Pago_Documentos.TileStyle.PaddingTop = 4
        Me.Btn_Pago_Documentos.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Pago_Documentos.TitleText = "BakApp"
        '
        'Btn_Documentos_Venta
        '
        Me.Btn_Documentos_Venta.Image = CType(resources.GetObject("Btn_Documentos_Venta.Image"), System.Drawing.Image)
        Me.Btn_Documentos_Venta.ImageIndent = New System.Drawing.Point(8, -6)
        Me.Btn_Documentos_Venta.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Documentos_Venta.Name = "Btn_Documentos_Venta"
        Me.Btn_Documentos_Venta.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Documentos_Venta.Text = "<font size=""+4""><b>DOCUMENTOS</b></font><br/>Generar documentos<font size=""-1""></" &
    "font>"
        Me.Btn_Documentos_Venta.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.Btn_Documentos_Venta.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Documentos_Venta.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(91, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.Btn_Documentos_Venta.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(91, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.Btn_Documentos_Venta.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(91, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.Btn_Documentos_Venta.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(91, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.Btn_Documentos_Venta.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Documentos_Venta.TitleText = "BakApp"
        '
        'Btn_Pagos_Generales_Cliente
        '
        Me.Btn_Pagos_Generales_Cliente.Image = CType(resources.GetObject("Btn_Pagos_Generales_Cliente.Image"), System.Drawing.Image)
        Me.Btn_Pagos_Generales_Cliente.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Pagos_Generales_Cliente.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Pagos_Generales_Cliente.Name = "Btn_Pagos_Generales_Cliente"
        Me.Btn_Pagos_Generales_Cliente.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Pagos_Generales_Cliente.Text = "<font size=""+4""><b>PAGOS GENERALES</b></font><br/><font size=""-1"">Pgo de clientes" &
    "<br/> </font>"
        Me.Btn_Pagos_Generales_Cliente.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.Btn_Pagos_Generales_Cliente.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Pagos_Generales_Cliente.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(81, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Btn_Pagos_Generales_Cliente.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(81, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Btn_Pagos_Generales_Cliente.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Pagos_Generales_Cliente.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(81, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Btn_Pagos_Generales_Cliente.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(81, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Btn_Pagos_Generales_Cliente.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Pagos_Generales_Cliente.TileStyle.PaddingBottom = 4
        Me.Btn_Pagos_Generales_Cliente.TileStyle.PaddingLeft = 4
        Me.Btn_Pagos_Generales_Cliente.TileStyle.PaddingRight = 4
        Me.Btn_Pagos_Generales_Cliente.TileStyle.PaddingTop = 4
        Me.Btn_Pagos_Generales_Cliente.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Pagos_Generales_Cliente.TitleText = "BakApp"
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.LabelX1.Location = New System.Drawing.Point(3, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(245, 49)
        Me.LabelX1.TabIndex = 42
        Me.LabelX1.Text = "<font color=""#349FCE""><b>VENTAS</b></font>"
        '
        'Modulo_Ventas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.Name = "Modulo_Ventas"
        Me.Size = New System.Drawing.Size(642, 443)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents ConsultaPreciosContenedor As DevComponents.DotNetBar.ItemContainer
    Private WithEvents BtnPostVenta As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_ProductoSolicitadosBodega As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Conf_CashDro As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents BtnBuscarDocumento As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents BtnCambiarDeUsuario As DevComponents.DotNetBar.ButtonItem
    Private WithEvents Btn_Pago_Documentos As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Documentos_Venta As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Private WithEvents Btn_Pagos_Generales_Cliente As DevComponents.DotNetBar.Metro.MetroTileItem
End Class
