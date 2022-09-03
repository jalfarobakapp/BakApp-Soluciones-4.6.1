<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Modulo_Documentos_Venta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Modulo_Documentos_Venta))
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem()
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel()
        Me.MnuEspecialOtros = New DevComponents.DotNetBar.ItemContainer()
        Me.Btn_Cotizacion = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Nota_De_Venta = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Boleta = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Factura = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Nota_De_Credito = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Guias = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Guia_Recepcion_Devoluciones = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Nota_De_Debito = New DevComponents.DotNetBar.Metro.MetroTileItem()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSalir})
        Me.Bar2.Location = New System.Drawing.Point(0, 389)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(641, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 34
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
        Me.MetroTilePanel1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.MnuEspecialOtros})
        Me.MetroTilePanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MetroTilePanel1.Location = New System.Drawing.Point(3, 56)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(698, 432)
        Me.MetroTilePanel1.TabIndex = 35
        Me.MetroTilePanel1.Text = "MetroTilePanel1"
        '
        'MnuEspecialOtros
        '
        '
        '
        '
        Me.MnuEspecialOtros.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MnuEspecialOtros.FixedSize = New System.Drawing.Size(650, 350)
        Me.MnuEspecialOtros.MultiLine = True
        Me.MnuEspecialOtros.Name = "MnuEspecialOtros"
        Me.MnuEspecialOtros.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Cotizacion, Me.Btn_Nota_De_Venta, Me.Btn_Boleta, Me.Btn_Factura, Me.Btn_Nota_De_Credito, Me.Btn_Guias, Me.Btn_Guia_Recepcion_Devoluciones, Me.Btn_Nota_De_Debito})
        '
        '
        '
        Me.MnuEspecialOtros.TitleStyle.Class = "MetroTileGroupTitle"
        Me.MnuEspecialOtros.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'Btn_Cotizacion
        '
        Me.Btn_Cotizacion.Image = CType(resources.GetObject("Btn_Cotizacion.Image"), System.Drawing.Image)
        Me.Btn_Cotizacion.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Cotizacion.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Cotizacion.Name = "Btn_Cotizacion"
        Me.Btn_Cotizacion.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Cotizacion.Tag = "COV"
        Me.Btn_Cotizacion.Text = "<font size=""+4""><b>COV - COTIZACION</b></font>"
        Me.Btn_Cotizacion.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.RedOrange
        Me.Btn_Cotizacion.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Cotizacion.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Btn_Cotizacion.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Btn_Cotizacion.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Cotizacion.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Btn_Cotizacion.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Btn_Cotizacion.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Cotizacion.TileStyle.PaddingBottom = 4
        Me.Btn_Cotizacion.TileStyle.PaddingLeft = 4
        Me.Btn_Cotizacion.TileStyle.PaddingRight = 4
        Me.Btn_Cotizacion.TileStyle.PaddingTop = 4
        Me.Btn_Cotizacion.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Cotizacion.TitleText = "Documento"
        '
        'Btn_Nota_De_Venta
        '
        Me.Btn_Nota_De_Venta.Image = CType(resources.GetObject("Btn_Nota_De_Venta.Image"), System.Drawing.Image)
        Me.Btn_Nota_De_Venta.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Nota_De_Venta.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Nota_De_Venta.Name = "Btn_Nota_De_Venta"
        Me.Btn_Nota_De_Venta.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Nota_De_Venta.Tag = "NVV"
        Me.Btn_Nota_De_Venta.Text = "<font size=""+4""><b>NVV - NOTA DE VENTA</b></font>"
        Me.Btn_Nota_De_Venta.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.Btn_Nota_De_Venta.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Nota_De_Venta.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.Btn_Nota_De_Venta.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.Btn_Nota_De_Venta.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Nota_De_Venta.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.Btn_Nota_De_Venta.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.Btn_Nota_De_Venta.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Nota_De_Venta.TileStyle.PaddingBottom = 4
        Me.Btn_Nota_De_Venta.TileStyle.PaddingLeft = 4
        Me.Btn_Nota_De_Venta.TileStyle.PaddingRight = 4
        Me.Btn_Nota_De_Venta.TileStyle.PaddingTop = 4
        Me.Btn_Nota_De_Venta.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Nota_De_Venta.TitleText = "Documento"
        '
        'Btn_Boleta
        '
        Me.Btn_Boleta.Image = CType(resources.GetObject("Btn_Boleta.Image"), System.Drawing.Image)
        Me.Btn_Boleta.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Boleta.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Boleta.Name = "Btn_Boleta"
        Me.Btn_Boleta.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Boleta.Tag = "BLV"
        Me.Btn_Boleta.Text = "<font size=""+4""><b>BLV - BOLETA NOMINATIVA</b></font>"
        Me.Btn_Boleta.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.Btn_Boleta.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Boleta.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_Boleta.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_Boleta.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Boleta.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_Boleta.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_Boleta.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Boleta.TileStyle.PaddingBottom = 4
        Me.Btn_Boleta.TileStyle.PaddingLeft = 4
        Me.Btn_Boleta.TileStyle.PaddingRight = 4
        Me.Btn_Boleta.TileStyle.PaddingTop = 4
        Me.Btn_Boleta.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Boleta.TitleText = "Documento"
        '
        'Btn_Factura
        '
        Me.Btn_Factura.Image = CType(resources.GetObject("Btn_Factura.Image"), System.Drawing.Image)
        Me.Btn_Factura.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Factura.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Factura.Name = "Btn_Factura"
        Me.Btn_Factura.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Factura.Tag = "FCV"
        Me.Btn_Factura.Text = "<font size=""+4""><b>FCV - FACTURA</b></font>"
        Me.Btn_Factura.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.DarkBlue
        Me.Btn_Factura.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Factura.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.Btn_Factura.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.Btn_Factura.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Factura.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.Btn_Factura.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.Btn_Factura.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Factura.TileStyle.PaddingBottom = 4
        Me.Btn_Factura.TileStyle.PaddingLeft = 4
        Me.Btn_Factura.TileStyle.PaddingRight = 4
        Me.Btn_Factura.TileStyle.PaddingTop = 4
        Me.Btn_Factura.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Factura.TitleText = "Documento"
        '
        'Btn_Nota_De_Credito
        '
        Me.Btn_Nota_De_Credito.Image = CType(resources.GetObject("Btn_Nota_De_Credito.Image"), System.Drawing.Image)
        Me.Btn_Nota_De_Credito.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Nota_De_Credito.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Nota_De_Credito.Name = "Btn_Nota_De_Credito"
        Me.Btn_Nota_De_Credito.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Nota_De_Credito.Tag = "NCV"
        Me.Btn_Nota_De_Credito.Text = "<font size=""+4""><b>NCV - NOTA DE CREDITO</b></font>"
        Me.Btn_Nota_De_Credito.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Yellow
        Me.Btn_Nota_De_Credito.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Nota_De_Credito.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(123, Byte), Integer))
        Me.Btn_Nota_De_Credito.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(123, Byte), Integer))
        Me.Btn_Nota_De_Credito.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Nota_De_Credito.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(123, Byte), Integer))
        Me.Btn_Nota_De_Credito.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(123, Byte), Integer))
        Me.Btn_Nota_De_Credito.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Nota_De_Credito.TileStyle.PaddingBottom = 4
        Me.Btn_Nota_De_Credito.TileStyle.PaddingLeft = 4
        Me.Btn_Nota_De_Credito.TileStyle.PaddingRight = 4
        Me.Btn_Nota_De_Credito.TileStyle.PaddingTop = 4
        Me.Btn_Nota_De_Credito.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Nota_De_Credito.TitleText = "Documento"
        Me.Btn_Nota_De_Credito.TitleTextColor = System.Drawing.Color.White
        '
        'Btn_Guias
        '
        Me.Btn_Guias.Image = CType(resources.GetObject("Btn_Guias.Image"), System.Drawing.Image)
        Me.Btn_Guias.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Guias.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Guias.Name = "Btn_Guias"
        Me.Btn_Guias.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Guias.Tag = "GDV"
        Me.Btn_Guias.Text = "<font size=""+4""><b>GDV - GUIA DE DESPACHO DE VENTA</b></font>"
        Me.Btn_Guias.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Blueish
        Me.Btn_Guias.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Guias.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(118, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Btn_Guias.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(118, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Btn_Guias.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Guias.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(118, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Btn_Guias.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(118, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Btn_Guias.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Guias.TileStyle.PaddingBottom = 4
        Me.Btn_Guias.TileStyle.PaddingLeft = 4
        Me.Btn_Guias.TileStyle.PaddingRight = 4
        Me.Btn_Guias.TileStyle.PaddingTop = 4
        Me.Btn_Guias.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Guias.TitleText = "Documento"
        '
        'Btn_Guia_Recepcion_Devoluciones
        '
        Me.Btn_Guia_Recepcion_Devoluciones.Image = CType(resources.GetObject("Btn_Guia_Recepcion_Devoluciones.Image"), System.Drawing.Image)
        Me.Btn_Guia_Recepcion_Devoluciones.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Guia_Recepcion_Devoluciones.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Guia_Recepcion_Devoluciones.Name = "Btn_Guia_Recepcion_Devoluciones"
        Me.Btn_Guia_Recepcion_Devoluciones.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Guia_Recepcion_Devoluciones.Tag = "BLV"
        Me.Btn_Guia_Recepcion_Devoluciones.Text = "<font size=""+4""><b>GRD - GUIA RECEPCION DEVOLUCIONES</b></font>"
        Me.Btn_Guia_Recepcion_Devoluciones.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.Btn_Guia_Recepcion_Devoluciones.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Guia_Recepcion_Devoluciones.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(111, Byte), Integer), CType(CType(86, Byte), Integer), CType(CType(67, Byte), Integer))
        Me.Btn_Guia_Recepcion_Devoluciones.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(111, Byte), Integer), CType(CType(86, Byte), Integer), CType(CType(67, Byte), Integer))
        Me.Btn_Guia_Recepcion_Devoluciones.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Guia_Recepcion_Devoluciones.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(111, Byte), Integer), CType(CType(86, Byte), Integer), CType(CType(67, Byte), Integer))
        Me.Btn_Guia_Recepcion_Devoluciones.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(111, Byte), Integer), CType(CType(86, Byte), Integer), CType(CType(67, Byte), Integer))
        Me.Btn_Guia_Recepcion_Devoluciones.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Guia_Recepcion_Devoluciones.TileStyle.PaddingBottom = 4
        Me.Btn_Guia_Recepcion_Devoluciones.TileStyle.PaddingLeft = 4
        Me.Btn_Guia_Recepcion_Devoluciones.TileStyle.PaddingRight = 4
        Me.Btn_Guia_Recepcion_Devoluciones.TileStyle.PaddingTop = 4
        Me.Btn_Guia_Recepcion_Devoluciones.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Guia_Recepcion_Devoluciones.TitleText = "Documento"
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
        Me.LabelX1.Size = New System.Drawing.Size(378, 49)
        Me.LabelX1.TabIndex = 44
        Me.LabelX1.Text = "<font color=""#349FCE""><b>DOCUMENTOS DE VENTA</b></font>"
        '
        'Btn_Nota_De_Debito
        '
        Me.Btn_Nota_De_Debito.Image = CType(resources.GetObject("Btn_Nota_De_Debito.Image"), System.Drawing.Image)
        Me.Btn_Nota_De_Debito.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Nota_De_Debito.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Nota_De_Debito.Name = "Btn_Nota_De_Debito"
        Me.Btn_Nota_De_Debito.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Nota_De_Debito.Tag = "FCV"
        Me.Btn_Nota_De_Debito.Text = "<font size=""+4""><b>FDV - NOTA DE DEBITO</b></font>"
        Me.Btn_Nota_De_Debito.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.DarkBlue
        Me.Btn_Nota_De_Debito.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Nota_De_Debito.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(179, Byte), Integer))
        Me.Btn_Nota_De_Debito.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(179, Byte), Integer))
        Me.Btn_Nota_De_Debito.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Nota_De_Debito.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.Btn_Nota_De_Debito.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.Btn_Nota_De_Debito.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Nota_De_Debito.TileStyle.PaddingBottom = 4
        Me.Btn_Nota_De_Debito.TileStyle.PaddingLeft = 4
        Me.Btn_Nota_De_Debito.TileStyle.PaddingRight = 4
        Me.Btn_Nota_De_Debito.TileStyle.PaddingTop = 4
        Me.Btn_Nota_De_Debito.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Nota_De_Debito.TitleText = "Documento"
        '
        'Modulo_Documentos_Venta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.Name = "Modulo_Documentos_Venta"
        Me.Size = New System.Drawing.Size(641, 430)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents MnuEspecialOtros As DevComponents.DotNetBar.ItemContainer
    Public WithEvents Btn_Cotizacion As DevComponents.DotNetBar.Metro.MetroTileItem
    Public WithEvents Btn_Nota_De_Venta As DevComponents.DotNetBar.Metro.MetroTileItem
    Public WithEvents Btn_Boleta As DevComponents.DotNetBar.Metro.MetroTileItem
    Public WithEvents Btn_Factura As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Nota_De_Credito As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Guias As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Public WithEvents Btn_Guia_Recepcion_Devoluciones As DevComponents.DotNetBar.Metro.MetroTileItem
    Public WithEvents Btn_Nota_De_Debito As DevComponents.DotNetBar.Metro.MetroTileItem
End Class
