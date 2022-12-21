<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Productos
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Productos))
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem()
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel()
        Me.MnuEspecialProductos = New DevComponents.DotNetBar.ItemContainer()
        Me.Btn_Maestra_Productos = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_CodAlternativo = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_CambiarCodProducto = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.BtnUbicProductos = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.BtnUnificarProductos = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.BtnConsolidarStock = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Tablas = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.BtnCP_Matriz = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Arbol_Clasificaciones = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_AjustePM = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.BtnRankingProductos = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Kardex_Inventario = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_ImagenesXProductos = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_ImpAdicionalXProd = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Radio1 = New DevComponents.DotNetBar.Command(Me.components)
        Me.Radio2 = New DevComponents.DotNetBar.Command(Me.components)
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Radio3 = New DevComponents.DotNetBar.Command(Me.components)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSalir, Me.ButtonItem1})
        Me.Bar2.Location = New System.Drawing.Point(0, 495)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(839, 57)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 30
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
        'ButtonItem1
        '
        Me.ButtonItem1.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem1.ForeColor = System.Drawing.Color.Black
        Me.ButtonItem1.Image = CType(resources.GetObject("ButtonItem1.Image"), System.Drawing.Image)
        Me.ButtonItem1.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem1.Name = "ButtonItem1"
        Me.ButtonItem1.Text = "BOTON DE PRUEBAS DE ACCESO RAPIDO"
        Me.ButtonItem1.Visible = False
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
        Me.MetroTilePanel1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.MnuEspecialProductos})
        Me.MetroTilePanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MetroTilePanel1.Location = New System.Drawing.Point(3, 63)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(834, 659)
        Me.MetroTilePanel1.TabIndex = 29
        Me.MetroTilePanel1.Text = "MetroTilePanel1"
        '
        'MnuEspecialProductos
        '
        '
        '
        '
        Me.MnuEspecialProductos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MnuEspecialProductos.FixedSize = New System.Drawing.Size(850, 500)
        Me.MnuEspecialProductos.MultiLine = True
        Me.MnuEspecialProductos.Name = "MnuEspecialProductos"
        Me.MnuEspecialProductos.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Maestra_Productos, Me.Btn_CodAlternativo, Me.Btn_CambiarCodProducto, Me.BtnUbicProductos, Me.BtnUnificarProductos, Me.BtnConsolidarStock, Me.Btn_Tablas, Me.BtnCP_Matriz, Me.Btn_Arbol_Clasificaciones, Me.Btn_AjustePM, Me.BtnRankingProductos, Me.Btn_Kardex_Inventario, Me.Btn_ImagenesXProductos, Me.Btn_ImpAdicionalXProd})
        '
        '
        '
        Me.MnuEspecialProductos.TitleStyle.Class = "MetroTileGroupTitle"
        Me.MnuEspecialProductos.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'Btn_Maestra_Productos
        '
        Me.Btn_Maestra_Productos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_Maestra_Productos.Image = CType(resources.GetObject("Btn_Maestra_Productos.Image"), System.Drawing.Image)
        Me.Btn_Maestra_Productos.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Maestra_Productos.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Maestra_Productos.Name = "Btn_Maestra_Productos"
        Me.Btn_Maestra_Productos.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Maestra_Productos.Text = "<font size=""+4""><b>MAESTRA PRODUCTOS</b></font><br/><font size=""-1"">Mantención de" &
    "l maestro de productos</font>"
        Me.Btn_Maestra_Productos.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.Btn_Maestra_Productos.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Maestra_Productos.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.Btn_Maestra_Productos.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.Btn_Maestra_Productos.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Maestra_Productos.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.Btn_Maestra_Productos.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.Btn_Maestra_Productos.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Maestra_Productos.TileStyle.PaddingBottom = 4
        Me.Btn_Maestra_Productos.TileStyle.PaddingLeft = 4
        Me.Btn_Maestra_Productos.TileStyle.PaddingRight = 4
        Me.Btn_Maestra_Productos.TileStyle.PaddingTop = 4
        Me.Btn_Maestra_Productos.TileStyle.TextColor = System.Drawing.Color.White
        '
        'Btn_CodAlternativo
        '
        Me.Btn_CodAlternativo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_CodAlternativo.Image = CType(resources.GetObject("Btn_CodAlternativo.Image"), System.Drawing.Image)
        Me.Btn_CodAlternativo.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_CodAlternativo.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_CodAlternativo.Name = "Btn_CodAlternativo"
        Me.Btn_CodAlternativo.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_CodAlternativo.Text = "<font size=""+4""><b>CODIGOS ALTERNATIVOS</b></font><br/><font size=""-1"">Mantención" &
    " de códigos alternativos por productos</font>"
        Me.Btn_CodAlternativo.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green
        Me.Btn_CodAlternativo.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_CodAlternativo.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(164, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(93, Byte), Integer))
        Me.Btn_CodAlternativo.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(164, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(93, Byte), Integer))
        Me.Btn_CodAlternativo.TileStyle.BackColorGradientAngle = 45
        Me.Btn_CodAlternativo.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(164, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(93, Byte), Integer))
        Me.Btn_CodAlternativo.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(164, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(93, Byte), Integer))
        Me.Btn_CodAlternativo.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_CodAlternativo.TileStyle.PaddingBottom = 4
        Me.Btn_CodAlternativo.TileStyle.PaddingLeft = 4
        Me.Btn_CodAlternativo.TileStyle.PaddingRight = 4
        Me.Btn_CodAlternativo.TileStyle.PaddingTop = 4
        Me.Btn_CodAlternativo.TileStyle.TextColor = System.Drawing.Color.White
        '
        'Btn_CambiarCodProducto
        '
        Me.Btn_CambiarCodProducto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_CambiarCodProducto.Image = CType(resources.GetObject("Btn_CambiarCodProducto.Image"), System.Drawing.Image)
        Me.Btn_CambiarCodProducto.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_CambiarCodProducto.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_CambiarCodProducto.Name = "Btn_CambiarCodProducto"
        Me.Btn_CambiarCodProducto.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_CambiarCodProducto.Text = "<font size=""+4""><b>CAMBIAR CODIGO</b></font><br/><font size=""-1"">Cambiar código d" &
    "e productos en forma masiva o invividual</font>"
        Me.Btn_CambiarCodProducto.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.Btn_CambiarCodProducto.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_CambiarCodProducto.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Btn_CambiarCodProducto.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Btn_CambiarCodProducto.TileStyle.BackColorGradientAngle = 45
        Me.Btn_CambiarCodProducto.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Btn_CambiarCodProducto.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Btn_CambiarCodProducto.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_CambiarCodProducto.TileStyle.PaddingBottom = 4
        Me.Btn_CambiarCodProducto.TileStyle.PaddingLeft = 4
        Me.Btn_CambiarCodProducto.TileStyle.PaddingRight = 4
        Me.Btn_CambiarCodProducto.TileStyle.PaddingTop = 4
        Me.Btn_CambiarCodProducto.TileStyle.TextColor = System.Drawing.Color.White
        '
        'BtnUbicProductos
        '
        Me.BtnUbicProductos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnUbicProductos.Image = CType(resources.GetObject("BtnUbicProductos.Image"), System.Drawing.Image)
        Me.BtnUbicProductos.ImageIndent = New System.Drawing.Point(8, -10)
        Me.BtnUbicProductos.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnUbicProductos.Name = "BtnUbicProductos"
        Me.BtnUbicProductos.SymbolColor = System.Drawing.Color.Empty
        Me.BtnUbicProductos.Text = "<font size=""+4""><b>UBICACION PRODUCTOS</b></font><br/><font size=""-1"">Organizació" &
    "n de ubicaciones por productos</font>"
        Me.BtnUbicProductos.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Teal
        Me.BtnUbicProductos.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.BtnUbicProductos.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(91, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.BtnUbicProductos.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(91, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.BtnUbicProductos.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(91, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.BtnUbicProductos.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(91, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.BtnUbicProductos.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        '
        'BtnUnificarProductos
        '
        Me.BtnUnificarProductos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnUnificarProductos.Image = CType(resources.GetObject("BtnUnificarProductos.Image"), System.Drawing.Image)
        Me.BtnUnificarProductos.ImageIndent = New System.Drawing.Point(8, -10)
        Me.BtnUnificarProductos.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnUnificarProductos.Name = "BtnUnificarProductos"
        Me.BtnUnificarProductos.SymbolColor = System.Drawing.Color.Empty
        Me.BtnUnificarProductos.Text = "<font size=""+4""><b>UNIFICAR PRODUCTOS</b></font><br/><font size=""-1"">Unificar uno" &
    " o varios productos en uno solo</font>"
        Me.BtnUnificarProductos.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Magenta
        Me.BtnUnificarProductos.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.BtnUnificarProductos.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.BtnUnificarProductos.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.BtnUnificarProductos.TileStyle.BackColorGradientAngle = 45
        Me.BtnUnificarProductos.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.BtnUnificarProductos.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.BtnUnificarProductos.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.BtnUnificarProductos.TileStyle.PaddingBottom = 4
        Me.BtnUnificarProductos.TileStyle.PaddingLeft = 4
        Me.BtnUnificarProductos.TileStyle.PaddingRight = 4
        Me.BtnUnificarProductos.TileStyle.PaddingTop = 4
        Me.BtnUnificarProductos.TileStyle.TextColor = System.Drawing.Color.White
        '
        'BtnConsolidarStock
        '
        Me.BtnConsolidarStock.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnConsolidarStock.Image = CType(resources.GetObject("BtnConsolidarStock.Image"), System.Drawing.Image)
        Me.BtnConsolidarStock.ImageIndent = New System.Drawing.Point(8, -10)
        Me.BtnConsolidarStock.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnConsolidarStock.Name = "BtnConsolidarStock"
        Me.BtnConsolidarStock.SymbolColor = System.Drawing.Color.Empty
        Me.BtnConsolidarStock.Text = "<font size=""+4""><b>CONSOLIDAR STOCK</b></font><br/><font size=""-1"">Consolida Stoc" &
    "k físico por productos</font>"
        Me.BtnConsolidarStock.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.RedOrange
        Me.BtnConsolidarStock.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.BtnConsolidarStock.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.BtnConsolidarStock.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.BtnConsolidarStock.TileStyle.BackColorGradientAngle = 45
        Me.BtnConsolidarStock.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.BtnConsolidarStock.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.BtnConsolidarStock.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.BtnConsolidarStock.TileStyle.PaddingBottom = 4
        Me.BtnConsolidarStock.TileStyle.PaddingLeft = 4
        Me.BtnConsolidarStock.TileStyle.PaddingRight = 4
        Me.BtnConsolidarStock.TileStyle.PaddingTop = 4
        Me.BtnConsolidarStock.TileStyle.TextColor = System.Drawing.Color.White
        '
        'Btn_Tablas
        '
        Me.Btn_Tablas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_Tablas.Image = CType(resources.GetObject("Btn_Tablas.Image"), System.Drawing.Image)
        Me.Btn_Tablas.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Tablas.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Tablas.Name = "Btn_Tablas"
        Me.Btn_Tablas.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Tablas.Text = "<font size=""+4""><b>TABLAS</b></font><br/><font size=""-1"">Familias, Rubros, Marcas" &
    ", clasificaciones varias...</font>"
        Me.Btn_Tablas.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Olive
        Me.Btn_Tablas.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Tablas.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Btn_Tablas.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Btn_Tablas.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Tablas.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Tablas.TileStyle.PaddingBottom = 4
        Me.Btn_Tablas.TileStyle.PaddingLeft = 4
        Me.Btn_Tablas.TileStyle.PaddingRight = 4
        Me.Btn_Tablas.TileStyle.PaddingTop = 4
        Me.Btn_Tablas.TileStyle.TextColor = System.Drawing.Color.White
        '
        'BtnCP_Matriz
        '
        Me.BtnCP_Matriz.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCP_Matriz.Image = CType(resources.GetObject("BtnCP_Matriz.Image"), System.Drawing.Image)
        Me.BtnCP_Matriz.ImageIndent = New System.Drawing.Point(8, -10)
        Me.BtnCP_Matriz.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnCP_Matriz.Name = "BtnCP_Matriz"
        Me.BtnCP_Matriz.SymbolColor = System.Drawing.Color.Empty
        Me.BtnCP_Matriz.Text = "<font size=""+4""><b>CREAR PRODUCTOS MATRIZ</b></font><br/><font size=""-1"">Mantenci" &
    "ón del maestro de productos</font>"
        Me.BtnCP_Matriz.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.RedOrange
        Me.BtnCP_Matriz.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.BtnCP_Matriz.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.BtnCP_Matriz.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.BtnCP_Matriz.TileStyle.BackColorGradientAngle = 45
        Me.BtnCP_Matriz.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.BtnCP_Matriz.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.BtnCP_Matriz.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.BtnCP_Matriz.TileStyle.PaddingBottom = 4
        Me.BtnCP_Matriz.TileStyle.PaddingLeft = 4
        Me.BtnCP_Matriz.TileStyle.PaddingRight = 4
        Me.BtnCP_Matriz.TileStyle.PaddingTop = 4
        Me.BtnCP_Matriz.TileStyle.TextColor = System.Drawing.Color.White
        '
        'Btn_Arbol_Clasificaciones
        '
        Me.Btn_Arbol_Clasificaciones.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_Arbol_Clasificaciones.Image = CType(resources.GetObject("Btn_Arbol_Clasificaciones.Image"), System.Drawing.Image)
        Me.Btn_Arbol_Clasificaciones.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Arbol_Clasificaciones.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Arbol_Clasificaciones.Name = "Btn_Arbol_Clasificaciones"
        Me.Btn_Arbol_Clasificaciones.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Arbol_Clasificaciones.Text = "<font size=""+4""><b>CLASIFICACIONES, ASOCIACIONES</b></font><br/><font size=""-1"">M" &
    "antención de clasificaciones.</font>"
        Me.Btn_Arbol_Clasificaciones.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Yellowish
        Me.Btn_Arbol_Clasificaciones.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Arbol_Clasificaciones.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Arbol_Clasificaciones.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Arbol_Clasificaciones.TileStyle.PaddingBottom = 4
        Me.Btn_Arbol_Clasificaciones.TileStyle.PaddingLeft = 4
        Me.Btn_Arbol_Clasificaciones.TileStyle.PaddingRight = 4
        Me.Btn_Arbol_Clasificaciones.TileStyle.PaddingTop = 4
        Me.Btn_Arbol_Clasificaciones.TileStyle.TextColor = System.Drawing.Color.White
        '
        'Btn_AjustePM
        '
        Me.Btn_AjustePM.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_AjustePM.Image = CType(resources.GetObject("Btn_AjustePM.Image"), System.Drawing.Image)
        Me.Btn_AjustePM.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_AjustePM.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_AjustePM.Name = "Btn_AjustePM"
        Me.Btn_AjustePM.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_AjustePM.Text = "<font size=""+4""><b>REAJUSTE PPP</b></font><br/><font size=""-1"">Empezar con un nue" &
    "vo PM por producto</font>"
        Me.Btn_AjustePM.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green
        Me.Btn_AjustePM.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_AjustePM.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_AjustePM.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_AjustePM.TileStyle.BackColorGradientAngle = 45
        Me.Btn_AjustePM.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_AjustePM.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_AjustePM.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_AjustePM.TileStyle.PaddingBottom = 4
        Me.Btn_AjustePM.TileStyle.PaddingLeft = 4
        Me.Btn_AjustePM.TileStyle.PaddingRight = 4
        Me.Btn_AjustePM.TileStyle.PaddingTop = 4
        Me.Btn_AjustePM.TileStyle.TextColor = System.Drawing.Color.White
        '
        'BtnRankingProductos
        '
        Me.BtnRankingProductos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnRankingProductos.Image = CType(resources.GetObject("BtnRankingProductos.Image"), System.Drawing.Image)
        Me.BtnRankingProductos.ImageIndent = New System.Drawing.Point(8, -10)
        Me.BtnRankingProductos.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnRankingProductos.Name = "BtnRankingProductos"
        Me.BtnRankingProductos.SymbolColor = System.Drawing.Color.Empty
        Me.BtnRankingProductos.Text = "<font size=""+4""><b>RANKIG DE PRODUCTOS</b></font><br/><font size=""-1"">Ranking 80/" &
    "20</font>"
        Me.BtnRankingProductos.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.RedOrange
        Me.BtnRankingProductos.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.BtnRankingProductos.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.BtnRankingProductos.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.BtnRankingProductos.TileStyle.BackColorGradientAngle = 45
        Me.BtnRankingProductos.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.BtnRankingProductos.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.BtnRankingProductos.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.BtnRankingProductos.TileStyle.PaddingBottom = 4
        Me.BtnRankingProductos.TileStyle.PaddingLeft = 4
        Me.BtnRankingProductos.TileStyle.PaddingRight = 4
        Me.BtnRankingProductos.TileStyle.PaddingTop = 4
        Me.BtnRankingProductos.TileStyle.TextColor = System.Drawing.Color.White
        '
        'Btn_Kardex_Inventario
        '
        Me.Btn_Kardex_Inventario.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_Kardex_Inventario.Image = CType(resources.GetObject("Btn_Kardex_Inventario.Image"), System.Drawing.Image)
        Me.Btn_Kardex_Inventario.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Kardex_Inventario.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Kardex_Inventario.Name = "Btn_Kardex_Inventario"
        Me.Btn_Kardex_Inventario.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Kardex_Inventario.Text = "<font size=""+4""><b>CONSULTA INTEGRADA STOCK</b></font><br/><font size=""-1"">Kardex" &
    " de inventario por producto</font>"
        Me.Btn_Kardex_Inventario.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Teal
        Me.Btn_Kardex_Inventario.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Kardex_Inventario.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.Btn_Kardex_Inventario.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.Btn_Kardex_Inventario.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.Btn_Kardex_Inventario.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.Btn_Kardex_Inventario.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        '
        'Btn_ImagenesXProductos
        '
        Me.Btn_ImagenesXProductos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_ImagenesXProductos.Image = CType(resources.GetObject("Btn_ImagenesXProductos.Image"), System.Drawing.Image)
        Me.Btn_ImagenesXProductos.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_ImagenesXProductos.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_ImagenesXProductos.Name = "Btn_ImagenesXProductos"
        Me.Btn_ImagenesXProductos.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_ImagenesXProductos.Text = "<font size=""+4""><b>IMAGENES POR PRODUCTOS URL.</b></font><br/><font size=""-1"">Lis" &
    "tado de tabla donde se guardan las imagenes de los productos URL</font>"
        Me.Btn_ImagenesXProductos.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.Btn_ImagenesXProductos.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_ImagenesXProductos.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Btn_ImagenesXProductos.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Btn_ImagenesXProductos.TileStyle.BackColorGradientAngle = 45
        Me.Btn_ImagenesXProductos.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Btn_ImagenesXProductos.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Btn_ImagenesXProductos.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_ImagenesXProductos.TileStyle.PaddingBottom = 4
        Me.Btn_ImagenesXProductos.TileStyle.PaddingLeft = 4
        Me.Btn_ImagenesXProductos.TileStyle.PaddingRight = 4
        Me.Btn_ImagenesXProductos.TileStyle.PaddingTop = 4
        Me.Btn_ImagenesXProductos.TileStyle.TextColor = System.Drawing.Color.White
        '
        'Btn_ImpAdicionalXProd
        '
        Me.Btn_ImpAdicionalXProd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_ImpAdicionalXProd.Image = CType(resources.GetObject("Btn_ImpAdicionalXProd.Image"), System.Drawing.Image)
        Me.Btn_ImpAdicionalXProd.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_ImpAdicionalXProd.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_ImpAdicionalXProd.Name = "Btn_ImpAdicionalXProd"
        Me.Btn_ImpAdicionalXProd.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_ImpAdicionalXProd.Text = "<font size=""+4""><b>IMPRESION ADICIONAL</b></font><br/><font size=""-1"">Productos q" &
    "ue gatillan una impresión adicional</font>"
        Me.Btn_ImpAdicionalXProd.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Magenta
        Me.Btn_ImpAdicionalXProd.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_ImpAdicionalXProd.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.Btn_ImpAdicionalXProd.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.Btn_ImpAdicionalXProd.TileStyle.BackColorGradientAngle = 45
        Me.Btn_ImpAdicionalXProd.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.Btn_ImpAdicionalXProd.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.Btn_ImpAdicionalXProd.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_ImpAdicionalXProd.TileStyle.PaddingBottom = 4
        Me.Btn_ImpAdicionalXProd.TileStyle.PaddingLeft = 4
        Me.Btn_ImpAdicionalXProd.TileStyle.PaddingRight = 4
        Me.Btn_ImpAdicionalXProd.TileStyle.PaddingTop = 4
        Me.Btn_ImpAdicionalXProd.TileStyle.TextColor = System.Drawing.Color.White
        '
        'Radio1
        '
        Me.Radio1.Checked = True
        Me.Radio1.Name = "Radio1"
        Me.Radio1.Text = "Todos los productos"
        '
        'Radio2
        '
        Me.Radio2.Name = "Radio2"
        Me.Radio2.Text = "Algunos"
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.LabelX1.Location = New System.Drawing.Point(3, 8)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(245, 49)
        Me.LabelX1.TabIndex = 38
        Me.LabelX1.Text = "<font color=""#349FCE""><b>PRODUCTOS</b></font>"
        '
        'Radio3
        '
        Me.Radio3.Name = "Radio3"
        Me.Radio3.Text = "Con movimientos hoy"
        '
        'Productos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.Name = "Productos"
        Me.Size = New System.Drawing.Size(839, 552)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents MnuEspecialProductos As DevComponents.DotNetBar.ItemContainer
    Private WithEvents Btn_CambiarCodProducto As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Maestra_Productos As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_CodAlternativo As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents BtnUbicProductos As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents BtnUnificarProductos As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents BtnConsolidarStock As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents Radio1 As DevComponents.DotNetBar.Command
    Friend WithEvents Radio2 As DevComponents.DotNetBar.Command
    Private WithEvents BtnCP_Matriz As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Tablas As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Arbol_Clasificaciones As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_AjustePM As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents BtnRankingProductos As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Radio3 As DevComponents.DotNetBar.Command
    Private WithEvents Btn_Kardex_Inventario As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_ImagenesXProductos As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_ImpAdicionalXProd As DevComponents.DotNetBar.Metro.MetroTileItem
End Class
