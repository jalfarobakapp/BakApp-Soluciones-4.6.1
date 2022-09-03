<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Productos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Productos))
        Me.Bar2 = New DevComponents.DotNetBar.Bar
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel
        Me.MnuEspecialProductos = New DevComponents.DotNetBar.ItemContainer
        Me.Btn_CambiarCodProducto = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.Btn_CrearProducto = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.Btn_CodAlternativo = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.Btn_OcultarPr = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.BtnEstProducto = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.Btn_CrearProductoMatriz = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.BtnUbicProductos = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.BtnUnificarProductos = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.BtnCodBusquedAvanzada = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.BtnCondultaIntegradaStock = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.BtnEtiquetasDeBarra = New DevComponents.DotNetBar.Metro.MetroTileItem
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSalir})
        Me.Bar2.Location = New System.Drawing.Point(0, 0)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(665, 57)
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
        Me.BtnSalir.Image = Global.AntBru.My.Resources.Resources.button_circle_left
        Me.BtnSalir.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Text = "Volver..."
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
        Me.MetroTilePanel1.ForeColor = System.Drawing.Color.Black
        Me.MetroTilePanel1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.MnuEspecialProductos})
        Me.MetroTilePanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MetroTilePanel1.Location = New System.Drawing.Point(3, 63)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(650, 500)
        Me.MetroTilePanel1.TabIndex = 29
        Me.MetroTilePanel1.Text = "MetroTilePanel1"
        '
        'MnuEspecialProductos
        '
        '
        '
        '
        Me.MnuEspecialProductos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MnuEspecialProductos.FixedSize = New System.Drawing.Size(600, 400)
        Me.MnuEspecialProductos.MultiLine = True
        Me.MnuEspecialProductos.Name = "MnuEspecialProductos"
        Me.MnuEspecialProductos.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_CambiarCodProducto, Me.Btn_CrearProducto, Me.Btn_CodAlternativo, Me.Btn_OcultarPr, Me.BtnEstProducto, Me.Btn_CrearProductoMatriz, Me.BtnUbicProductos, Me.BtnUnificarProductos, Me.BtnCodBusquedAvanzada, Me.BtnCondultaIntegradaStock, Me.BtnEtiquetasDeBarra})
        '
        '
        '
        Me.MnuEspecialProductos.TitleStyle.Class = "MetroTileGroupTitle"
        Me.MnuEspecialProductos.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MnuEspecialProductos.TitleText = "Productos"
        '
        'Btn_CambiarCodProducto
        '
        Me.Btn_CambiarCodProducto.Image = Global.AntBru.My.Resources.Resources.registry_editor_32
        Me.Btn_CambiarCodProducto.ImageIndent = New System.Drawing.Point(8, -6)
        Me.Btn_CambiarCodProducto.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_CambiarCodProducto.Name = "Btn_CambiarCodProducto"
        Me.Btn_CambiarCodProducto.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_CambiarCodProducto.Text = "<font size=""+4"">Cambiar código</font><br/><font size=""-1"">Cambiar código de produ" & _
            "ctos en forma masiva o invividual</font>"
        Me.Btn_CambiarCodProducto.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        '
        '
        '
        Me.Btn_CambiarCodProducto.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.Btn_CambiarCodProducto.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.Btn_CambiarCodProducto.TileStyle.BackColorGradientAngle = 45
        Me.Btn_CambiarCodProducto.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Btn_CambiarCodProducto.TileStyle.PaddingBottom = 4
        Me.Btn_CambiarCodProducto.TileStyle.PaddingLeft = 4
        Me.Btn_CambiarCodProducto.TileStyle.PaddingRight = 4
        Me.Btn_CambiarCodProducto.TileStyle.PaddingTop = 4
        Me.Btn_CambiarCodProducto.TileStyle.TextColor = System.Drawing.Color.White
        '
        'Btn_CrearProducto
        '
        Me.Btn_CrearProducto.Image = CType(resources.GetObject("Btn_CrearProducto.Image"), System.Drawing.Image)
        Me.Btn_CrearProducto.ImageIndent = New System.Drawing.Point(8, -3)
        Me.Btn_CrearProducto.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_CrearProducto.Name = "Btn_CrearProducto"
        Me.Btn_CrearProducto.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_CrearProducto.Text = "<font size=""+4"">Crear producto</font><br/><font size=""-1"">Formulario para la crea" & _
            "ción de productos en el sistema</font>"
        Me.Btn_CrearProducto.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        '
        '
        '
        Me.Btn_CrearProducto.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.Btn_CrearProducto.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.Btn_CrearProducto.TileStyle.BackColorGradientAngle = 45
        Me.Btn_CrearProducto.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Btn_CrearProducto.TileStyle.PaddingBottom = 4
        Me.Btn_CrearProducto.TileStyle.PaddingLeft = 4
        Me.Btn_CrearProducto.TileStyle.PaddingRight = 4
        Me.Btn_CrearProducto.TileStyle.PaddingTop = 4
        Me.Btn_CrearProducto.TileStyle.TextColor = System.Drawing.Color.White
        '
        'Btn_CodAlternativo
        '
        Me.Btn_CodAlternativo.Image = Global.AntBru.My.Resources.Resources.barcode_32
        Me.Btn_CodAlternativo.ImageIndent = New System.Drawing.Point(8, -6)
        Me.Btn_CodAlternativo.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_CodAlternativo.Name = "Btn_CodAlternativo"
        Me.Btn_CodAlternativo.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_CodAlternativo.Text = "<font size=""+4"">Código alternativo</font><br/><font size=""-1"">Mantención de códig" & _
            "os alternativos por productos</font>"
        Me.Btn_CodAlternativo.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green
        '
        '
        '
        Me.Btn_CodAlternativo.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.Btn_CodAlternativo.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Btn_CodAlternativo.TileStyle.BackColorGradientAngle = 45
        Me.Btn_CodAlternativo.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Btn_CodAlternativo.TileStyle.PaddingBottom = 4
        Me.Btn_CodAlternativo.TileStyle.PaddingLeft = 4
        Me.Btn_CodAlternativo.TileStyle.PaddingRight = 4
        Me.Btn_CodAlternativo.TileStyle.PaddingTop = 4
        Me.Btn_CodAlternativo.TileStyle.TextColor = System.Drawing.Color.White
        '
        'Btn_OcultarPr
        '
        Me.Btn_OcultarPr.Image = Global.AntBru.My.Resources.Resources.triller_32
        Me.Btn_OcultarPr.ImageIndent = New System.Drawing.Point(8, -6)
        Me.Btn_OcultarPr.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_OcultarPr.Name = "Btn_OcultarPr"
        Me.Btn_OcultarPr.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_OcultarPr.Text = "<font size=""+4"">Ocultar productos</font><br/><font size=""-1"">Ocultar o desocultar" & _
            " productos del sistema</font>"
        Me.Btn_OcultarPr.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Magenta
        '
        '
        '
        Me.Btn_OcultarPr.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(118, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Btn_OcultarPr.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Btn_OcultarPr.TileStyle.BackColorGradientAngle = 45
        Me.Btn_OcultarPr.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Btn_OcultarPr.TileStyle.PaddingBottom = 4
        Me.Btn_OcultarPr.TileStyle.PaddingLeft = 4
        Me.Btn_OcultarPr.TileStyle.PaddingRight = 4
        Me.Btn_OcultarPr.TileStyle.PaddingTop = 4
        Me.Btn_OcultarPr.TileStyle.TextColor = System.Drawing.Color.White
        '
        'BtnEstProducto
        '
        Me.BtnEstProducto.Image = Global.AntBru.My.Resources.Resources.statistics_32
        Me.BtnEstProducto.ImageIndent = New System.Drawing.Point(8, -6)
        Me.BtnEstProducto.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnEstProducto.Name = "BtnEstProducto"
        Me.BtnEstProducto.SymbolColor = System.Drawing.Color.Empty
        Me.BtnEstProducto.Text = "<font size=""+4"">Estadisticas producto</font><br/><font size=""-1"">Se utiliza para " & _
            "revisar estadisticas del producto, se puede asociar a dispositivos moviles.</fon" & _
            "t>"
        Me.BtnEstProducto.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Teal
        '
        '
        '
        Me.BtnEstProducto.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'Btn_CrearProductoMatriz
        '
        Me.Btn_CrearProductoMatriz.Image = Global.AntBru.My.Resources.Resources.planning_shipment
        Me.Btn_CrearProductoMatriz.ImageIndent = New System.Drawing.Point(8, -6)
        Me.Btn_CrearProductoMatriz.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_CrearProductoMatriz.Name = "Btn_CrearProductoMatriz"
        Me.Btn_CrearProductoMatriz.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_CrearProductoMatriz.Text = "<font size=""+4"">Crear producto Matriz</font><br/><font size=""-1"">Formulario para " & _
            "creación de productos desde una matriz</font>"
        Me.Btn_CrearProductoMatriz.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Magenta
        '
        '
        '
        Me.Btn_CrearProductoMatriz.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Btn_CrearProductoMatriz.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Btn_CrearProductoMatriz.TileStyle.BackColorGradientAngle = 45
        Me.Btn_CrearProductoMatriz.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Btn_CrearProductoMatriz.TileStyle.PaddingBottom = 4
        Me.Btn_CrearProductoMatriz.TileStyle.PaddingLeft = 4
        Me.Btn_CrearProductoMatriz.TileStyle.PaddingRight = 4
        Me.Btn_CrearProductoMatriz.TileStyle.PaddingTop = 4
        Me.Btn_CrearProductoMatriz.TileStyle.TextColor = System.Drawing.Color.White
        '
        'BtnUbicProductos
        '
        Me.BtnUbicProductos.Image = Global.AntBru.My.Resources.Resources.product_48
        Me.BtnUbicProductos.ImageIndent = New System.Drawing.Point(8, -6)
        Me.BtnUbicProductos.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnUbicProductos.Name = "BtnUbicProductos"
        Me.BtnUbicProductos.SymbolColor = System.Drawing.Color.Empty
        Me.BtnUbicProductos.Text = "<font size=""+4"">Ubicación productos</font><br/><font size=""-1"">Organización de ub" & _
            "icaciones por productos</font>"
        Me.BtnUbicProductos.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Teal
        '
        '
        '
        Me.BtnUbicProductos.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'BtnUnificarProductos
        '
        Me.BtnUnificarProductos.Image = Global.AntBru.My.Resources.Resources.shipment_shipment1
        Me.BtnUnificarProductos.ImageIndent = New System.Drawing.Point(8, -6)
        Me.BtnUnificarProductos.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnUnificarProductos.Name = "BtnUnificarProductos"
        Me.BtnUnificarProductos.SymbolColor = System.Drawing.Color.Empty
        Me.BtnUnificarProductos.Text = "<font size=""+4"">Unificar productos</font><br/><font size=""-1"">Unificar uno o vari" & _
            "os productos en uno solo</font>"
        Me.BtnUnificarProductos.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Magenta
        '
        '
        '
        Me.BtnUnificarProductos.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(118, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.BtnUnificarProductos.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.BtnUnificarProductos.TileStyle.BackColorGradientAngle = 45
        Me.BtnUnificarProductos.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BtnUnificarProductos.TileStyle.PaddingBottom = 4
        Me.BtnUnificarProductos.TileStyle.PaddingLeft = 4
        Me.BtnUnificarProductos.TileStyle.PaddingRight = 4
        Me.BtnUnificarProductos.TileStyle.PaddingTop = 4
        Me.BtnUnificarProductos.TileStyle.TextColor = System.Drawing.Color.White
        '
        'BtnCodBusquedAvanzada
        '
        Me.BtnCodBusquedAvanzada.Image = Global.AntBru.My.Resources.Resources.repeat_32
        Me.BtnCodBusquedAvanzada.ImageIndent = New System.Drawing.Point(8, -6)
        Me.BtnCodBusquedAvanzada.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnCodBusquedAvanzada.Name = "BtnCodBusquedAvanzada"
        Me.BtnCodBusquedAvanzada.SymbolColor = System.Drawing.Color.Empty
        Me.BtnCodBusquedAvanzada.Text = "<font size=""+4"">Busqueda Avanzada</font><br/><font size=""-1"">Matención de product" & _
            "os para busqueda avanzada</font>"
        Me.BtnCodBusquedAvanzada.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Magenta
        '
        '
        '
        Me.BtnCodBusquedAvanzada.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnCodBusquedAvanzada.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnCodBusquedAvanzada.TileStyle.BackColorGradientAngle = 45
        Me.BtnCodBusquedAvanzada.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BtnCodBusquedAvanzada.TileStyle.PaddingBottom = 4
        Me.BtnCodBusquedAvanzada.TileStyle.PaddingLeft = 4
        Me.BtnCodBusquedAvanzada.TileStyle.PaddingRight = 4
        Me.BtnCodBusquedAvanzada.TileStyle.PaddingTop = 4
        Me.BtnCodBusquedAvanzada.TileStyle.TextColor = System.Drawing.Color.White
        '
        'BtnCondultaIntegradaStock
        '
        Me.BtnCondultaIntegradaStock.Image = Global.AntBru.My.Resources.Resources.sheet_shipment
        Me.BtnCondultaIntegradaStock.ImageIndent = New System.Drawing.Point(8, -12)
        Me.BtnCondultaIntegradaStock.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnCondultaIntegradaStock.Name = "BtnCondultaIntegradaStock"
        Me.BtnCondultaIntegradaStock.SymbolColor = System.Drawing.Color.Empty
        Me.BtnCondultaIntegradaStock.Text = "<font size=""+4"">Consulta Stock</font><br/><font size=""-1"">Consulta integrada se s" & _
            "tock por productos</font>"
        Me.BtnCondultaIntegradaStock.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        '
        '
        '
        Me.BtnCondultaIntegradaStock.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.BtnCondultaIntegradaStock.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.BtnCondultaIntegradaStock.TileStyle.BackColorGradientAngle = 45
        Me.BtnCondultaIntegradaStock.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BtnCondultaIntegradaStock.TileStyle.PaddingBottom = 4
        Me.BtnCondultaIntegradaStock.TileStyle.PaddingLeft = 4
        Me.BtnCondultaIntegradaStock.TileStyle.PaddingRight = 4
        Me.BtnCondultaIntegradaStock.TileStyle.PaddingTop = 4
        Me.BtnCondultaIntegradaStock.TileStyle.TextColor = System.Drawing.Color.White
        '
        'BtnEtiquetasDeBarra
        '
        Me.BtnEtiquetasDeBarra.Image = Global.AntBru.My.Resources.Resources.barcode_shipment
        Me.BtnEtiquetasDeBarra.ImageIndent = New System.Drawing.Point(10, -12)
        Me.BtnEtiquetasDeBarra.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnEtiquetasDeBarra.Name = "BtnEtiquetasDeBarra"
        Me.BtnEtiquetasDeBarra.SymbolColor = System.Drawing.Color.Empty
        Me.BtnEtiquetasDeBarra.Text = "<font size=""+4"">Códigos de Barra</font><br/><font size=""-1"">Imprimir etiquetas de" & _
            " barra</font>"
        Me.BtnEtiquetasDeBarra.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        '
        '
        '
        Me.BtnEtiquetasDeBarra.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.BtnEtiquetasDeBarra.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.BtnEtiquetasDeBarra.TileStyle.BackColorGradientAngle = 45
        Me.BtnEtiquetasDeBarra.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BtnEtiquetasDeBarra.TileStyle.PaddingBottom = 4
        Me.BtnEtiquetasDeBarra.TileStyle.PaddingLeft = 4
        Me.BtnEtiquetasDeBarra.TileStyle.PaddingRight = 4
        Me.BtnEtiquetasDeBarra.TileStyle.PaddingTop = 4
        Me.BtnEtiquetasDeBarra.TileStyle.TextColor = System.Drawing.Color.White
        '
        'Productos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.Name = "Productos"
        Me.Size = New System.Drawing.Size(665, 532)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents MnuEspecialProductos As DevComponents.DotNetBar.ItemContainer
    Private WithEvents Btn_CambiarCodProducto As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_CrearProducto As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_CodAlternativo As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_OcultarPr As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents BtnEstProducto As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_CrearProductoMatriz As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents BtnUbicProductos As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents BtnUnificarProductos As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents BtnCodBusquedAvanzada As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents BtnCondultaIntegradaStock As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents BtnEtiquetasDeBarra As DevComponents.DotNetBar.Metro.MetroTileItem

End Class
