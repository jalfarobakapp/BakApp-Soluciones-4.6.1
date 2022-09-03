<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProgramasEspeciales
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
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel
        Me.MnuEspecialSistemas = New DevComponents.DotNetBar.ItemContainer
        Me.SistemaInventarioCont = New DevComponents.DotNetBar.ItemContainer
        Me.BtnSisTomaInventarioGeneral = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.BtnCalCantXpeso = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.ItemContainer7 = New DevComponents.DotNetBar.ItemContainer
        Me.BtnSisInvBodegas = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.BtnSisInvUbicaciones = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.BtnSisInvResponzables = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.BtnSisInvInventarios = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.BtnSisinvenParcializado = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.BtnSisImpBarras = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.ConsultaPreciosContenedor = New DevComponents.DotNetBar.ItemContainer
        Me.BtnAutoconsulta = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.BtnConfAutoconsulta = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.AutoconsultaCotenedor = New DevComponents.DotNetBar.ItemContainer
        Me.BtnAutoconsultaSaldoCli = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.MetroTileItem3 = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.FormatosDeDocumentos = New DevComponents.DotNetBar.ItemContainer
        Me.BtnCrearFormatos = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.MnuEspecialOtros = New DevComponents.DotNetBar.ItemContainer
        Me.BtnSQL2Excel = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.BtnPicking = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.SuspendLayout()
        '
        'MetroTilePanel1
        '
        Me.MetroTilePanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MetroTilePanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.MetroTilePanel1.BackgroundStyle.Class = "MetroTilePanel"
        Me.MetroTilePanel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MetroTilePanel1.ContainerControlProcessDialogKey = True
        Me.MetroTilePanel1.ForeColor = System.Drawing.Color.Black
        Me.MetroTilePanel1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.MnuEspecialSistemas, Me.MnuEspecialOtros})
        Me.MetroTilePanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MetroTilePanel1.Location = New System.Drawing.Point(3, 3)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(814, 575)
        Me.MetroTilePanel1.TabIndex = 5
        Me.MetroTilePanel1.Text = "MetroTilePanel1"
        '
        'MnuEspecialSistemas
        '
        '
        '
        '
        Me.MnuEspecialSistemas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MnuEspecialSistemas.FixedSize = New System.Drawing.Size(400, 800)
        Me.MnuEspecialSistemas.MultiLine = True
        Me.MnuEspecialSistemas.Name = "MnuEspecialSistemas"
        Me.MnuEspecialSistemas.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SistemaInventarioCont, Me.BtnSisinvenParcializado, Me.BtnSisImpBarras, Me.ConsultaPreciosContenedor, Me.AutoconsultaCotenedor, Me.FormatosDeDocumentos})
        '
        '
        '
        Me.MnuEspecialSistemas.TitleStyle.Class = "MetroTileGroupTitle"
        Me.MnuEspecialSistemas.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MnuEspecialSistemas.TitleText = "Sistemas"
        '
        'SistemaInventarioCont
        '
        '
        '
        '
        Me.SistemaInventarioCont.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.SistemaInventarioCont.MultiLine = True
        Me.SistemaInventarioCont.Name = "SistemaInventarioCont"
        Me.SistemaInventarioCont.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSisTomaInventarioGeneral, Me.BtnCalCantXpeso, Me.ItemContainer7})
        '
        '
        '
        Me.SistemaInventarioCont.TitleStyle.Class = "MetroTileGroupTitle"
        Me.SistemaInventarioCont.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.SistemaInventarioCont.TitleStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SistemaInventarioCont.TitleText = "Toma de inventario"
        '
        'BtnSisTomaInventarioGeneral
        '
        Me.BtnSisTomaInventarioGeneral.Image = Global.BakApp.My.Resources.Resources.barcode_scanner_64
        Me.BtnSisTomaInventarioGeneral.ImageIndent = New System.Drawing.Point(8, -6)
        Me.BtnSisTomaInventarioGeneral.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnSisTomaInventarioGeneral.Name = "BtnSisTomaInventarioGeneral"
        Me.BtnSisTomaInventarioGeneral.SymbolColor = System.Drawing.Color.Empty
        Me.BtnSisTomaInventarioGeneral.Text = "<font size=""+4"">Ingresar al Sistema</font><br/><font size=""-1"">Tomar inventario, " & _
            "gestionar en linea</font>"
        Me.BtnSisTomaInventarioGeneral.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green
        Me.BtnSisTomaInventarioGeneral.TileSize = New System.Drawing.Size(250, 110)
        '
        '
        '
        Me.BtnSisTomaInventarioGeneral.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BtnSisTomaInventarioGeneral.TitleText = "BakApp"
        '
        'BtnCalCantXpeso
        '
        Me.BtnCalCantXpeso.Image = Global.BakApp.My.Resources.Resources.calculator_64
        Me.BtnCalCantXpeso.ImageIndent = New System.Drawing.Point(8, -3)
        Me.BtnCalCantXpeso.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnCalCantXpeso.Name = "BtnCalCantXpeso"
        Me.BtnCalCantXpeso.SymbolColor = System.Drawing.Color.Empty
        Me.BtnCalCantXpeso.Text = "<font size=""+4"">Calcular</font><br/><font size=""-1"">Calc. Cant X Peso</font>"
        Me.BtnCalCantXpeso.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.BtnCalCantXpeso.TileSize = New System.Drawing.Size(120, 110)
        '
        '
        '
        Me.BtnCalCantXpeso.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.BtnCalCantXpeso.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.BtnCalCantXpeso.TileStyle.BackColorGradientAngle = 45
        Me.BtnCalCantXpeso.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BtnCalCantXpeso.TileStyle.PaddingBottom = 4
        Me.BtnCalCantXpeso.TileStyle.PaddingLeft = 4
        Me.BtnCalCantXpeso.TileStyle.PaddingRight = 4
        Me.BtnCalCantXpeso.TileStyle.PaddingTop = 4
        Me.BtnCalCantXpeso.TileStyle.TextColor = System.Drawing.Color.White
        Me.BtnCalCantXpeso.TitleText = "BakApp"
        '
        'ItemContainer7
        '
        '
        '
        '
        Me.ItemContainer7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer7.MultiLine = True
        Me.ItemContainer7.Name = "ItemContainer7"
        Me.ItemContainer7.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSisInvBodegas, Me.BtnSisInvUbicaciones, Me.BtnSisInvResponzables, Me.BtnSisInvInventarios})
        '
        '
        '
        Me.ItemContainer7.TitleStyle.Class = "MetroTileGroupTitle"
        Me.ItemContainer7.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer7.TitleStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ItemContainer7.TitleText = "Configuración toma inventario"
        '
        'BtnSisInvBodegas
        '
        Me.BtnSisInvBodegas.Image = Global.BakApp.My.Resources.Resources.data_recovery_64
        Me.BtnSisInvBodegas.ImageIndent = New System.Drawing.Point(4, -3)
        Me.BtnSisInvBodegas.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnSisInvBodegas.Name = "BtnSisInvBodegas"
        Me.BtnSisInvBodegas.SymbolColor = System.Drawing.Color.Empty
        Me.BtnSisInvBodegas.Text = "<font size=""+4"">Bodegas</font>"
        Me.BtnSisInvBodegas.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.RedViolet
        Me.BtnSisInvBodegas.TileSize = New System.Drawing.Size(120, 110)
        '
        '
        '
        Me.BtnSisInvBodegas.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnSisInvBodegas.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnSisInvBodegas.TileStyle.BackColorGradientAngle = 45
        Me.BtnSisInvBodegas.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BtnSisInvBodegas.TileStyle.PaddingBottom = 4
        Me.BtnSisInvBodegas.TileStyle.PaddingLeft = 4
        Me.BtnSisInvBodegas.TileStyle.PaddingRight = 4
        Me.BtnSisInvBodegas.TileStyle.PaddingTop = 4
        Me.BtnSisInvBodegas.TileStyle.TextColor = System.Drawing.Color.White
        Me.BtnSisInvBodegas.TitleText = "BakApp"
        '
        'BtnSisInvUbicaciones
        '
        Me.BtnSisInvUbicaciones.Image = Global.BakApp.My.Resources.Resources.product_64
        Me.BtnSisInvUbicaciones.ImageIndent = New System.Drawing.Point(8, -3)
        Me.BtnSisInvUbicaciones.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnSisInvUbicaciones.Name = "BtnSisInvUbicaciones"
        Me.BtnSisInvUbicaciones.SymbolColor = System.Drawing.Color.Empty
        Me.BtnSisInvUbicaciones.Text = "<font size=""+4"">Ubicaciones</font>"
        Me.BtnSisInvUbicaciones.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.BtnSisInvUbicaciones.TileSize = New System.Drawing.Size(120, 110)
        '
        '
        '
        Me.BtnSisInvUbicaciones.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.BtnSisInvUbicaciones.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.BtnSisInvUbicaciones.TileStyle.BackColorGradientAngle = 45
        Me.BtnSisInvUbicaciones.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BtnSisInvUbicaciones.TileStyle.PaddingBottom = 4
        Me.BtnSisInvUbicaciones.TileStyle.PaddingLeft = 4
        Me.BtnSisInvUbicaciones.TileStyle.PaddingRight = 4
        Me.BtnSisInvUbicaciones.TileStyle.PaddingTop = 4
        Me.BtnSisInvUbicaciones.TileStyle.TextColor = System.Drawing.Color.White
        Me.BtnSisInvUbicaciones.TitleText = "BakApp"
        '
        'BtnSisInvResponzables
        '
        Me.BtnSisInvResponzables.Image = Global.BakApp.My.Resources.Resources.checked_user_64
        Me.BtnSisInvResponzables.ImageIndent = New System.Drawing.Point(4, -3)
        Me.BtnSisInvResponzables.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnSisInvResponzables.Name = "BtnSisInvResponzables"
        Me.BtnSisInvResponzables.SymbolColor = System.Drawing.Color.Empty
        Me.BtnSisInvResponzables.Text = "<font size=""+4"">Usuarios</font>"
        Me.BtnSisInvResponzables.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.BtnSisInvResponzables.TileSize = New System.Drawing.Size(120, 110)
        '
        '
        '
        Me.BtnSisInvResponzables.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.BtnSisInvResponzables.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.BtnSisInvResponzables.TileStyle.BackColorGradientAngle = 45
        Me.BtnSisInvResponzables.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BtnSisInvResponzables.TileStyle.PaddingBottom = 4
        Me.BtnSisInvResponzables.TileStyle.PaddingLeft = 4
        Me.BtnSisInvResponzables.TileStyle.PaddingRight = 4
        Me.BtnSisInvResponzables.TileStyle.PaddingTop = 4
        Me.BtnSisInvResponzables.TileStyle.TextColor = System.Drawing.Color.White
        Me.BtnSisInvResponzables.TitleText = "BakApp"
        '
        'BtnSisInvInventarios
        '
        Me.BtnSisInvInventarios.Image = Global.BakApp.My.Resources.Resources.purchase_order_64
        Me.BtnSisInvInventarios.ImageIndent = New System.Drawing.Point(8, -6)
        Me.BtnSisInvInventarios.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnSisInvInventarios.Name = "BtnSisInvInventarios"
        Me.BtnSisInvInventarios.SymbolColor = System.Drawing.Color.Empty
        Me.BtnSisInvInventarios.Text = "<font size=""+4"">Inventarios</font>"
        Me.BtnSisInvInventarios.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.BtnSisInvInventarios.TileSize = New System.Drawing.Size(120, 110)
        '
        '
        '
        Me.BtnSisInvInventarios.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnSisInvInventarios.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnSisInvInventarios.TileStyle.BackColorGradientAngle = 45
        Me.BtnSisInvInventarios.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BtnSisInvInventarios.TileStyle.PaddingBottom = 4
        Me.BtnSisInvInventarios.TileStyle.PaddingLeft = 4
        Me.BtnSisInvInventarios.TileStyle.PaddingRight = 4
        Me.BtnSisInvInventarios.TileStyle.PaddingTop = 4
        Me.BtnSisInvInventarios.TileStyle.TextColor = System.Drawing.Color.White
        Me.BtnSisInvInventarios.TitleText = "BakApp"
        '
        'BtnSisinvenParcializado
        '
        Me.BtnSisinvenParcializado.Image = Global.BakApp.My.Resources.Resources.inventory_shipment3
        Me.BtnSisinvenParcializado.ImageIndent = New System.Drawing.Point(8, -6)
        Me.BtnSisinvenParcializado.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnSisinvenParcializado.Name = "BtnSisinvenParcializado"
        Me.BtnSisinvenParcializado.SymbolColor = System.Drawing.Color.Empty
        Me.BtnSisinvenParcializado.Text = "<font size=""+4"">Toma inventario</font><br/><font size=""-1"">Sistema de toma de inv" & _
            "entario parcializado, actualizar Stock automaticamente.</font>"
        Me.BtnSisinvenParcializado.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green
        Me.BtnSisinvenParcializado.TileSize = New System.Drawing.Size(200, 110)
        '
        '
        '
        Me.BtnSisinvenParcializado.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BtnSisinvenParcializado.TitleText = "BakApp"
        '
        'BtnSisImpBarras
        '
        Me.BtnSisImpBarras.Image = Global.BakApp.My.Resources.Resources.barcode_32
        Me.BtnSisImpBarras.ImageIndent = New System.Drawing.Point(8, -6)
        Me.BtnSisImpBarras.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnSisImpBarras.Name = "BtnSisImpBarras"
        Me.BtnSisImpBarras.SymbolColor = System.Drawing.Color.Empty
        Me.BtnSisImpBarras.Text = "<font size=""+4"">Impresión Barras</font><br/><font size=""-1"">Impresión de cod. de " & _
            "barras por produto - documento - etc.</font>"
        Me.BtnSisImpBarras.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green
        Me.BtnSisImpBarras.TileSize = New System.Drawing.Size(180, 110)
        '
        '
        '
        Me.BtnSisImpBarras.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BtnSisImpBarras.TitleText = "BakApp"
        '
        'ConsultaPreciosContenedor
        '
        '
        '
        '
        Me.ConsultaPreciosContenedor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ConsultaPreciosContenedor.MultiLine = True
        Me.ConsultaPreciosContenedor.Name = "ConsultaPreciosContenedor"
        Me.ConsultaPreciosContenedor.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnAutoconsulta, Me.BtnConfAutoconsulta})
        '
        '
        '
        Me.ConsultaPreciosContenedor.TitleStyle.Class = "MetroTileGroupTitle"
        Me.ConsultaPreciosContenedor.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ConsultaPreciosContenedor.TitleStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ConsultaPreciosContenedor.TitleText = "Consulta Precios"
        '
        'BtnAutoconsulta
        '
        Me.BtnAutoconsulta.Image = Global.BakApp.My.Resources.Resources.price_tag_64
        Me.BtnAutoconsulta.ImageIndent = New System.Drawing.Point(12, -6)
        Me.BtnAutoconsulta.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnAutoconsulta.Name = "BtnAutoconsulta"
        Me.BtnAutoconsulta.SymbolColor = System.Drawing.Color.Empty
        Me.BtnAutoconsulta.Text = "<font size=""+4"">Consulta precios</font><br/><font size=""-1"">sistema de autoconsul" & _
            "ta para clientes</font>"
        Me.BtnAutoconsulta.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green
        Me.BtnAutoconsulta.TileSize = New System.Drawing.Size(250, 110)
        '
        '
        '
        Me.BtnAutoconsulta.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BtnAutoconsulta.TitleText = "BakApp"
        '
        'BtnConfAutoconsulta
        '
        Me.BtnConfAutoconsulta.Image = Global.BakApp.My.Resources.Resources.settings_32
        Me.BtnConfAutoconsulta.ImageIndent = New System.Drawing.Point(18, -15)
        Me.BtnConfAutoconsulta.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnConfAutoconsulta.Name = "BtnConfAutoconsulta"
        Me.BtnConfAutoconsulta.SymbolColor = System.Drawing.Color.Empty
        Me.BtnConfAutoconsulta.Text = "<font size=""+4"">Configuración</font><br/><font size=""-1"">Autoconsulta</font>"
        Me.BtnConfAutoconsulta.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.BtnConfAutoconsulta.TileSize = New System.Drawing.Size(120, 110)
        '
        '
        '
        Me.BtnConfAutoconsulta.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BtnConfAutoconsulta.TitleText = "BakApp"
        '
        'AutoconsultaCotenedor
        '
        '
        '
        '
        Me.AutoconsultaCotenedor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.AutoconsultaCotenedor.MultiLine = True
        Me.AutoconsultaCotenedor.Name = "AutoconsultaCotenedor"
        Me.AutoconsultaCotenedor.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnAutoconsultaSaldoCli, Me.MetroTileItem3})
        '
        '
        '
        Me.AutoconsultaCotenedor.TitleStyle.Class = "MetroTileGroupTitle"
        Me.AutoconsultaCotenedor.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.AutoconsultaCotenedor.TitleStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AutoconsultaCotenedor.TitleText = "Autoconsulta Saldos clientes"
        '
        'BtnAutoconsultaSaldoCli
        '
        Me.BtnAutoconsultaSaldoCli.Image = Global.BakApp.My.Resources.Resources.user_64
        Me.BtnAutoconsultaSaldoCli.ImageIndent = New System.Drawing.Point(12, -6)
        Me.BtnAutoconsultaSaldoCli.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnAutoconsultaSaldoCli.Name = "BtnAutoconsultaSaldoCli"
        Me.BtnAutoconsultaSaldoCli.SymbolColor = System.Drawing.Color.Empty
        Me.BtnAutoconsultaSaldoCli.Text = "<font size=""+4"">Autoconsulta Cliente</font><br/><font size=""-1"">Consultar saldos " & _
            "de cliente en pantalla e impresión</font>"
        Me.BtnAutoconsultaSaldoCli.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green
        Me.BtnAutoconsultaSaldoCli.TileSize = New System.Drawing.Size(250, 110)
        '
        '
        '
        Me.BtnAutoconsultaSaldoCli.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnAutoconsultaSaldoCli.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnAutoconsultaSaldoCli.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BtnAutoconsultaSaldoCli.TitleText = "BakApp"
        '
        'MetroTileItem3
        '
        Me.MetroTileItem3.Image = Global.BakApp.My.Resources.Resources.printer_48
        Me.MetroTileItem3.ImageIndent = New System.Drawing.Point(8, -3)
        Me.MetroTileItem3.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.MetroTileItem3.Name = "MetroTileItem3"
        Me.MetroTileItem3.SymbolColor = System.Drawing.Color.Empty
        Me.MetroTileItem3.Text = "<font size=""+4"">Impresora</font><br/><font size=""-1"">Configurar<br/>Salida impres" & _
            "ión</font>"
        Me.MetroTileItem3.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.MetroTileItem3.TileSize = New System.Drawing.Size(120, 110)
        '
        '
        '
        Me.MetroTileItem3.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.MetroTileItem3.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.MetroTileItem3.TileStyle.BackColorGradientAngle = 45
        Me.MetroTileItem3.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MetroTileItem3.TileStyle.PaddingBottom = 4
        Me.MetroTileItem3.TileStyle.PaddingLeft = 4
        Me.MetroTileItem3.TileStyle.PaddingRight = 4
        Me.MetroTileItem3.TileStyle.PaddingTop = 4
        Me.MetroTileItem3.TileStyle.TextColor = System.Drawing.Color.White
        Me.MetroTileItem3.TitleText = "BakApp"
        '
        'FormatosDeDocumentos
        '
        '
        '
        '
        Me.FormatosDeDocumentos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.FormatosDeDocumentos.MultiLine = True
        Me.FormatosDeDocumentos.Name = "FormatosDeDocumentos"
        Me.FormatosDeDocumentos.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnCrearFormatos})
        '
        '
        '
        Me.FormatosDeDocumentos.TitleStyle.Class = "MetroTileGroupTitle"
        Me.FormatosDeDocumentos.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.FormatosDeDocumentos.TitleStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormatosDeDocumentos.TitleText = "Formatos"
        '
        'BtnCrearFormatos
        '
        Me.BtnCrearFormatos.Image = Global.BakApp.My.Resources.Resources.picture_64
        Me.BtnCrearFormatos.ImageIndent = New System.Drawing.Point(12, -6)
        Me.BtnCrearFormatos.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnCrearFormatos.Name = "BtnCrearFormatos"
        Me.BtnCrearFormatos.SymbolColor = System.Drawing.Color.Empty
        Me.BtnCrearFormatos.Text = "<font size=""+4"">Formatos de documentos</font><br/><font size=""-1"">Sistema de dise" & _
            "ño de formatos de documentos...</font>"
        Me.BtnCrearFormatos.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green
        Me.BtnCrearFormatos.TileSize = New System.Drawing.Size(250, 110)
        '
        '
        '
        Me.BtnCrearFormatos.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnCrearFormatos.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnCrearFormatos.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BtnCrearFormatos.TitleText = "BakApp"
        '
        'MnuEspecialOtros
        '
        '
        '
        '
        Me.MnuEspecialOtros.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MnuEspecialOtros.FixedSize = New System.Drawing.Size(400, 800)
        Me.MnuEspecialOtros.MultiLine = True
        Me.MnuEspecialOtros.Name = "MnuEspecialOtros"
        Me.MnuEspecialOtros.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSQL2Excel, Me.BtnPicking})
        '
        '
        '
        Me.MnuEspecialOtros.TitleStyle.Class = "MetroTileGroupTitle"
        Me.MnuEspecialOtros.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MnuEspecialOtros.TitleText = "Otros"
        '
        'BtnSQL2Excel
        '
        Me.BtnSQL2Excel.Image = Global.BakApp.My.Resources.Resources.registry_editor_32
        Me.BtnSQL2Excel.ImageIndent = New System.Drawing.Point(8, -6)
        Me.BtnSQL2Excel.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnSQL2Excel.Name = "BtnSQL2Excel"
        Me.BtnSQL2Excel.SymbolColor = System.Drawing.Color.Empty
        Me.BtnSQL2Excel.Text = "<font size=""+4"">SQL2Excel</font><br/><font size=""-1"">Generar Query y Exportar a E" & _
            "xcel</font>"
        Me.BtnSQL2Excel.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.BtnSQL2Excel.TileSize = New System.Drawing.Size(180, 110)
        '
        '
        '
        Me.BtnSQL2Excel.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.BtnSQL2Excel.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.BtnSQL2Excel.TileStyle.BackColorGradientAngle = 45
        Me.BtnSQL2Excel.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BtnSQL2Excel.TileStyle.PaddingBottom = 4
        Me.BtnSQL2Excel.TileStyle.PaddingLeft = 4
        Me.BtnSQL2Excel.TileStyle.PaddingRight = 4
        Me.BtnSQL2Excel.TileStyle.PaddingTop = 4
        Me.BtnSQL2Excel.TileStyle.TextColor = System.Drawing.Color.White
        Me.BtnSQL2Excel.TitleText = "BakApp"
        '
        'BtnPicking
        '
        Me.BtnPicking.Image = Global.BakApp.My.Resources.Resources.printer_32
        Me.BtnPicking.ImageIndent = New System.Drawing.Point(8, -6)
        Me.BtnPicking.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnPicking.Name = "BtnPicking"
        Me.BtnPicking.SymbolColor = System.Drawing.Color.Empty
        Me.BtnPicking.Text = "<font size=""+4"">Imprimir Picking</font><br/><font size=""-1"">Ingresar al asistente" & _
            " de impresión de picking automatico...</font>"
        Me.BtnPicking.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green
        Me.BtnPicking.TileSize = New System.Drawing.Size(180, 110)
        '
        '
        '
        Me.BtnPicking.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.BtnPicking.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.BtnPicking.TileStyle.BackColorGradientAngle = 45
        Me.BtnPicking.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BtnPicking.TileStyle.PaddingBottom = 4
        Me.BtnPicking.TileStyle.PaddingLeft = 4
        Me.BtnPicking.TileStyle.PaddingRight = 4
        Me.BtnPicking.TileStyle.PaddingTop = 4
        Me.BtnPicking.TileStyle.TextColor = System.Drawing.Color.White
        Me.BtnPicking.TitleText = "BakApp"
        '
        'ProgramasEspeciales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.Name = "ProgramasEspeciales"
        Me.Size = New System.Drawing.Size(894, 615)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents MnuEspecialSistemas As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents SistemaInventarioCont As DevComponents.DotNetBar.ItemContainer
    Private WithEvents BtnSisTomaInventarioGeneral As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents BtnCalCantXpeso As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents ItemContainer7 As DevComponents.DotNetBar.ItemContainer
    Private WithEvents BtnSisInvBodegas As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents BtnSisInvUbicaciones As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents BtnSisInvResponzables As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents BtnSisInvInventarios As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents BtnSisinvenParcializado As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents BtnSisImpBarras As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents ConsultaPreciosContenedor As DevComponents.DotNetBar.ItemContainer
    Private WithEvents BtnAutoconsulta As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents BtnConfAutoconsulta As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents AutoconsultaCotenedor As DevComponents.DotNetBar.ItemContainer
    Private WithEvents BtnAutoconsultaSaldoCli As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents MetroTileItem3 As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents FormatosDeDocumentos As DevComponents.DotNetBar.ItemContainer
    Private WithEvents BtnCrearFormatos As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents MnuEspecialOtros As DevComponents.DotNetBar.ItemContainer
    Private WithEvents BtnSQL2Excel As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents BtnPicking As DevComponents.DotNetBar.Metro.MetroTileItem

End Class
