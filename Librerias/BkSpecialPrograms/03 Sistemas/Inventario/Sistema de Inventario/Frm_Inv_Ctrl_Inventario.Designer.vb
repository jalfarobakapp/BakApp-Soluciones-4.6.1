<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Inv_Ctrl_Inventario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Inv_Ctrl_Inventario))
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel()
        Me.ConsultaPreciosContenedor = New DevComponents.DotNetBar.ItemContainer()
        Me.Btn_VerInventario = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_CrearHoja = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_InventarioXSector = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Lbl_Nombre_Inventario = New DevComponents.DotNetBar.LabelX()
        Me.Line1 = New DevComponents.DotNetBar.Controls.Line()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_FotoStock = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_TomarFotoStock = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_EliminarFotoStock = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Salir = New DevComponents.DotNetBar.ButtonItem()
        Me.Metro_Bar_Color = New DevComponents.DotNetBar.Metro.MetroStatusBar()
        Me.Lbl_Estatus = New DevComponents.DotNetBar.LabelItem()
        Me.SuperTabControl1 = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.MetroTilePanel2 = New DevComponents.DotNetBar.Metro.MetroTilePanel()
        Me.ItemContainer1 = New DevComponents.DotNetBar.ItemContainer()
        Me.Btn_Sectores = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Contadores = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Parejas = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.SuperTabItem2 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.SuperTabItem1 = New DevComponents.DotNetBar.SuperTabItem()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControl1.SuspendLayout()
        Me.SuperTabControlPanel2.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MetroTilePanel1
        '
        Me.MetroTilePanel1.BackColor = System.Drawing.Color.White
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
        Me.MetroTilePanel1.Location = New System.Drawing.Point(3, 3)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(737, 336)
        Me.MetroTilePanel1.TabIndex = 37
        Me.MetroTilePanel1.Text = "MetroTilePanel1"
        '
        'ConsultaPreciosContenedor
        '
        '
        '
        '
        Me.ConsultaPreciosContenedor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ConsultaPreciosContenedor.FixedSize = New System.Drawing.Size(700, 300)
        Me.ConsultaPreciosContenedor.MultiLine = True
        Me.ConsultaPreciosContenedor.Name = "ConsultaPreciosContenedor"
        Me.ConsultaPreciosContenedor.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_VerInventario, Me.Btn_CrearHoja, Me.Btn_InventarioXSector})
        '
        '
        '
        Me.ConsultaPreciosContenedor.TitleStyle.Class = "MetroTileGroupTitle"
        Me.ConsultaPreciosContenedor.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ConsultaPreciosContenedor.TitleStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'Btn_VerInventario
        '
        Me.Btn_VerInventario.Image = CType(resources.GetObject("Btn_VerInventario.Image"), System.Drawing.Image)
        Me.Btn_VerInventario.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_VerInventario.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_VerInventario.Name = "Btn_VerInventario"
        Me.Btn_VerInventario.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_VerInventario.Text = "<font size=""+4""><b>INVENTARIO</b></font><br/><font size=""-1"">Ver estado de avance" &
    " del inventario.</font>"
        Me.Btn_VerInventario.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.Btn_VerInventario.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_VerInventario.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.Btn_VerInventario.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.Btn_VerInventario.TileStyle.BackColorGradientAngle = 45
        Me.Btn_VerInventario.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.Btn_VerInventario.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.Btn_VerInventario.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_VerInventario.TileStyle.PaddingBottom = 4
        Me.Btn_VerInventario.TileStyle.PaddingLeft = 4
        Me.Btn_VerInventario.TileStyle.PaddingRight = 4
        Me.Btn_VerInventario.TileStyle.PaddingTop = 4
        Me.Btn_VerInventario.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_VerInventario.TitleText = "BakApp"
        '
        'Btn_CrearHoja
        '
        Me.Btn_CrearHoja.Image = CType(resources.GetObject("Btn_CrearHoja.Image"), System.Drawing.Image)
        Me.Btn_CrearHoja.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_CrearHoja.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_CrearHoja.Name = "Btn_CrearHoja"
        Me.Btn_CrearHoja.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_CrearHoja.Text = "<font size=""+4""><b>CREAR HOJA</b></font><br/><font size=""-1"">Ingresar datos de co" &
    "nteo al sistema</font>"
        Me.Btn_CrearHoja.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.Btn_CrearHoja.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_CrearHoja.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_CrearHoja.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_CrearHoja.TileStyle.BackColorGradientAngle = 45
        Me.Btn_CrearHoja.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_CrearHoja.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_CrearHoja.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_CrearHoja.TileStyle.PaddingBottom = 4
        Me.Btn_CrearHoja.TileStyle.PaddingLeft = 4
        Me.Btn_CrearHoja.TileStyle.PaddingRight = 4
        Me.Btn_CrearHoja.TileStyle.PaddingTop = 4
        Me.Btn_CrearHoja.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_CrearHoja.TitleText = "BakApp"
        '
        'Btn_InventarioXSector
        '
        Me.Btn_InventarioXSector.Image = CType(resources.GetObject("Btn_InventarioXSector.Image"), System.Drawing.Image)
        Me.Btn_InventarioXSector.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_InventarioXSector.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_InventarioXSector.Name = "Btn_InventarioXSector"
        Me.Btn_InventarioXSector.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_InventarioXSector.Text = "<font size=""+4""><b>INVENTARIO POR SECTORES</b></font><br/><font size=""-1"">Ver inf" &
    "orme  de avance por sectores</font>"
        Me.Btn_InventarioXSector.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.Btn_InventarioXSector.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_InventarioXSector.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_InventarioXSector.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_InventarioXSector.TileStyle.BackColorGradientAngle = 45
        Me.Btn_InventarioXSector.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_InventarioXSector.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_InventarioXSector.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_InventarioXSector.TileStyle.PaddingBottom = 4
        Me.Btn_InventarioXSector.TileStyle.PaddingLeft = 4
        Me.Btn_InventarioXSector.TileStyle.PaddingRight = 4
        Me.Btn_InventarioXSector.TileStyle.PaddingTop = 4
        Me.Btn_InventarioXSector.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_InventarioXSector.TitleText = "BakApp"
        '
        'Lbl_Nombre_Inventario
        '
        Me.Lbl_Nombre_Inventario.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Nombre_Inventario.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Nombre_Inventario.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Nombre_Inventario.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Nombre_Inventario.Location = New System.Drawing.Point(32, 12)
        Me.Lbl_Nombre_Inventario.Name = "Lbl_Nombre_Inventario"
        Me.Lbl_Nombre_Inventario.Size = New System.Drawing.Size(662, 23)
        Me.Lbl_Nombre_Inventario.TabIndex = 38
        Me.Lbl_Nombre_Inventario.Text = "INVENTARIO: NOMBRE DEL INVENTARIO ACTIVO"
        '
        'Line1
        '
        Me.Line1.BackColor = System.Drawing.Color.White
        Me.Line1.ForeColor = System.Drawing.Color.Black
        Me.Line1.Location = New System.Drawing.Point(32, 34)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(740, 23)
        Me.Line1.TabIndex = 39
        Me.Line1.Text = "Line1"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_FotoStock, Me.Btn_Salir})
        Me.Bar1.Location = New System.Drawing.Point(0, 328)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(704, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 40
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_FotoStock
        '
        Me.Btn_FotoStock.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_FotoStock.ForeColor = System.Drawing.Color.Black
        Me.Btn_FotoStock.Image = CType(resources.GetObject("Btn_FotoStock.Image"), System.Drawing.Image)
        Me.Btn_FotoStock.ImageAlt = CType(resources.GetObject("Btn_FotoStock.ImageAlt"), System.Drawing.Image)
        Me.Btn_FotoStock.Name = "Btn_FotoStock"
        Me.Btn_FotoStock.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_TomarFotoStock, Me.Btn_EliminarFotoStock})
        Me.Btn_FotoStock.Text = "Foto Stock"
        Me.Btn_FotoStock.Tooltip = "Limpiar todo"
        Me.Btn_FotoStock.Visible = False
        '
        'Btn_TomarFotoStock
        '
        Me.Btn_TomarFotoStock.Image = CType(resources.GetObject("Btn_TomarFotoStock.Image"), System.Drawing.Image)
        Me.Btn_TomarFotoStock.ImageAlt = CType(resources.GetObject("Btn_TomarFotoStock.ImageAlt"), System.Drawing.Image)
        Me.Btn_TomarFotoStock.Name = "Btn_TomarFotoStock"
        Me.Btn_TomarFotoStock.Text = "Tomar Foto Stock"
        '
        'Btn_EliminarFotoStock
        '
        Me.Btn_EliminarFotoStock.Image = CType(resources.GetObject("Btn_EliminarFotoStock.Image"), System.Drawing.Image)
        Me.Btn_EliminarFotoStock.ImageAlt = CType(resources.GetObject("Btn_EliminarFotoStock.ImageAlt"), System.Drawing.Image)
        Me.Btn_EliminarFotoStock.Name = "Btn_EliminarFotoStock"
        Me.Btn_EliminarFotoStock.Text = "Eliminar Foto Stock"
        '
        'Btn_Salir
        '
        Me.Btn_Salir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Salir.ForeColor = System.Drawing.Color.Black
        Me.Btn_Salir.Image = CType(resources.GetObject("Btn_Salir.Image"), System.Drawing.Image)
        Me.Btn_Salir.ImageAlt = CType(resources.GetObject("Btn_Salir.ImageAlt"), System.Drawing.Image)
        Me.Btn_Salir.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Tooltip = "Salir"
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
        Me.Metro_Bar_Color.Location = New System.Drawing.Point(0, 369)
        Me.Metro_Bar_Color.Name = "Metro_Bar_Color"
        Me.Metro_Bar_Color.Size = New System.Drawing.Size(704, 22)
        Me.Metro_Bar_Color.TabIndex = 56
        Me.Metro_Bar_Color.Text = "MetroStatusBar1"
        '
        'Lbl_Estatus
        '
        Me.Lbl_Estatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Estatus.Name = "Lbl_Estatus"
        Me.Lbl_Estatus.Text = "LabelItem2"
        '
        'SuperTabControl1
        '
        Me.SuperTabControl1.BackColor = System.Drawing.Color.White
        '
        '
        '
        '
        '
        '
        Me.SuperTabControl1.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.SuperTabControl1.ControlBox.MenuBox.Name = ""
        Me.SuperTabControl1.ControlBox.Name = ""
        Me.SuperTabControl1.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabControl1.ControlBox.MenuBox, Me.SuperTabControl1.ControlBox.CloseBox})
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel1)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel2)
        Me.SuperTabControl1.ForeColor = System.Drawing.Color.Black
        Me.SuperTabControl1.Location = New System.Drawing.Point(32, 63)
        Me.SuperTabControl1.Name = "SuperTabControl1"
        Me.SuperTabControl1.ReorderTabsEnabled = True
        Me.SuperTabControl1.SelectedTabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.SuperTabControl1.SelectedTabIndex = 1
        Me.SuperTabControl1.Size = New System.Drawing.Size(650, 418)
        Me.SuperTabControl1.TabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SuperTabControl1.TabIndex = 57
        Me.SuperTabControl1.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabItem1, Me.SuperTabItem2})
        Me.SuperTabControl1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue
        Me.SuperTabControl1.Text = "SuperTabControl1"
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Controls.Add(Me.MetroTilePanel2)
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 25)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(650, 393)
        Me.SuperTabControlPanel2.TabIndex = 0
        Me.SuperTabControlPanel2.TabItem = Me.SuperTabItem2
        '
        'MetroTilePanel2
        '
        Me.MetroTilePanel2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.MetroTilePanel2.BackgroundStyle.Class = "MetroTilePanel"
        Me.MetroTilePanel2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MetroTilePanel2.ContainerControlProcessDialogKey = True
        Me.MetroTilePanel2.DragDropSupport = True
        Me.MetroTilePanel2.ForeColor = System.Drawing.Color.Black
        Me.MetroTilePanel2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer1})
        Me.MetroTilePanel2.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MetroTilePanel2.Location = New System.Drawing.Point(3, 3)
        Me.MetroTilePanel2.Name = "MetroTilePanel2"
        Me.MetroTilePanel2.Size = New System.Drawing.Size(737, 336)
        Me.MetroTilePanel2.TabIndex = 38
        Me.MetroTilePanel2.Text = "MetroTilePanel2"
        '
        'ItemContainer1
        '
        '
        '
        '
        Me.ItemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer1.FixedSize = New System.Drawing.Size(700, 300)
        Me.ItemContainer1.MultiLine = True
        Me.ItemContainer1.Name = "ItemContainer1"
        Me.ItemContainer1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Sectores, Me.Btn_Contadores, Me.Btn_Parejas})
        '
        '
        '
        Me.ItemContainer1.TitleStyle.Class = "MetroTileGroupTitle"
        Me.ItemContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer1.TitleStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'Btn_Sectores
        '
        Me.Btn_Sectores.Image = CType(resources.GetObject("Btn_Sectores.Image"), System.Drawing.Image)
        Me.Btn_Sectores.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Sectores.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Sectores.Name = "Btn_Sectores"
        Me.Btn_Sectores.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Sectores.Text = "<font size=""+4""><b>SECTORES</b></font><br/><font size=""-1"">Mantención de sectores" &
    "</font>"
        Me.Btn_Sectores.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.Btn_Sectores.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Sectores.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_Sectores.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_Sectores.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Sectores.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_Sectores.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_Sectores.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Sectores.TileStyle.PaddingBottom = 4
        Me.Btn_Sectores.TileStyle.PaddingLeft = 4
        Me.Btn_Sectores.TileStyle.PaddingRight = 4
        Me.Btn_Sectores.TileStyle.PaddingTop = 4
        Me.Btn_Sectores.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Sectores.TitleText = "BakApp"
        '
        'Btn_Contadores
        '
        Me.Btn_Contadores.Image = CType(resources.GetObject("Btn_Contadores.Image"), System.Drawing.Image)
        Me.Btn_Contadores.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Contadores.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Contadores.Name = "Btn_Contadores"
        Me.Btn_Contadores.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Contadores.Text = "<font size=""+4""><b>CONTADORES</b></font><br/><font size=""-1"">Crear, editar, elimi" &
    "nar</font>"
        Me.Btn_Contadores.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.Btn_Contadores.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Contadores.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.Btn_Contadores.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.Btn_Contadores.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Contadores.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.Btn_Contadores.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.Btn_Contadores.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Contadores.TileStyle.PaddingBottom = 4
        Me.Btn_Contadores.TileStyle.PaddingLeft = 4
        Me.Btn_Contadores.TileStyle.PaddingRight = 4
        Me.Btn_Contadores.TileStyle.PaddingTop = 4
        Me.Btn_Contadores.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Contadores.TitleText = "BakApp"
        '
        'Btn_Parejas
        '
        Me.Btn_Parejas.Image = CType(resources.GetObject("Btn_Parejas.Image"), System.Drawing.Image)
        Me.Btn_Parejas.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Parejas.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Parejas.Name = "Btn_Parejas"
        Me.Btn_Parejas.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Parejas.Text = "<font size=""+4""><b>PAREJAS</b></font><br/><font size=""-1"">Crear, editar, eliminar" &
    "</font>"
        Me.Btn_Parejas.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.Btn_Parejas.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Parejas.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.Btn_Parejas.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.Btn_Parejas.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Parejas.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.Btn_Parejas.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.Btn_Parejas.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Parejas.TileStyle.PaddingBottom = 4
        Me.Btn_Parejas.TileStyle.PaddingLeft = 4
        Me.Btn_Parejas.TileStyle.PaddingRight = 4
        Me.Btn_Parejas.TileStyle.PaddingTop = 4
        Me.Btn_Parejas.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Parejas.TitleText = "BakApp"
        Me.Btn_Parejas.Visible = False
        '
        'SuperTabItem2
        '
        Me.SuperTabItem2.AttachedControl = Me.SuperTabControlPanel2
        Me.SuperTabItem2.GlobalItem = False
        Me.SuperTabItem2.Name = "SuperTabItem2"
        Me.SuperTabItem2.Text = "CONFIGURACION"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.MetroTilePanel1)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 25)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(650, 393)
        Me.SuperTabControlPanel1.TabIndex = 1
        Me.SuperTabControlPanel1.TabItem = Me.SuperTabItem1
        '
        'SuperTabItem1
        '
        Me.SuperTabItem1.AttachedControl = Me.SuperTabControlPanel1
        Me.SuperTabItem1.GlobalItem = False
        Me.SuperTabItem1.Name = "SuperTabItem1"
        Me.SuperTabItem1.Text = "MANTENCION DE INVENTARIO"
        '
        'Frm_Inv_Ctrl_Inventario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(704, 391)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.Line1)
        Me.Controls.Add(Me.Lbl_Nombre_Inventario)
        Me.Controls.Add(Me.Metro_Bar_Color)
        Me.Controls.Add(Me.SuperTabControl1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Inv_Ctrl_Inventario"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MANTENCION DE INVENTARIO ACTIVO"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControl1.ResumeLayout(False)
        Me.SuperTabControlPanel2.ResumeLayout(False)
        Me.SuperTabControlPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents ConsultaPreciosContenedor As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents Lbl_Nombre_Inventario As DevComponents.DotNetBar.LabelX
    Friend WithEvents Line1 As DevComponents.DotNetBar.Controls.Line
    Private WithEvents Btn_VerInventario As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Salir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Metro_Bar_Color As DevComponents.DotNetBar.Metro.MetroStatusBar
    Public WithEvents Lbl_Estatus As DevComponents.DotNetBar.LabelItem
    Public WithEvents Btn_FotoStock As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_TomarFotoStock As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_EliminarFotoStock As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents SuperTabControl1 As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents MetroTilePanel2 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents ItemContainer1 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents SuperTabItem2 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem1 As DevComponents.DotNetBar.SuperTabItem
    Private WithEvents Btn_CrearHoja As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_InventarioXSector As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Sectores As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Contadores As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Parejas As DevComponents.DotNetBar.Metro.MetroTileItem
End Class
