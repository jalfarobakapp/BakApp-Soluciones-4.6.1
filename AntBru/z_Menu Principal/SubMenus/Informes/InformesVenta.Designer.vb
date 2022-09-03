<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InformesVenta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InformesVenta))
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem()
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel()
        Me.ItemContainer3 = New DevComponents.DotNetBar.ItemContainer()
        Me.BtnInfMargenes = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.BtnRankingProductos = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Informe_Vencimiento_Ventas = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Informe_Ventas_On_Line = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Ventas = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Creditos_Vigentes = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Compromisos_No_Despachados = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Margenes_y_Proyeccion = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Context_Menu_Solicitud_Compra = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_01 = New DevComponents.DotNetBar.ButtonItem()
        Me.Lbl_Mnu_1 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Mnu_Informe_Vencimientos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Informe_Ventas_On_Line = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Context_Menu_Solicitud_Compra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSalir})
        Me.Bar2.Location = New System.Drawing.Point(0, 380)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(646, 41)
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
        Me.MetroTilePanel1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer3})
        Me.MetroTilePanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MetroTilePanel1.Location = New System.Drawing.Point(8, 48)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(687, 458)
        Me.MetroTilePanel1.TabIndex = 39
        Me.MetroTilePanel1.Text = "MetroTilePanel1"
        '
        'ItemContainer3
        '
        '
        '
        '
        Me.ItemContainer3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer3.FixedSize = New System.Drawing.Size(630, 300)
        Me.ItemContainer3.MultiLine = True
        Me.ItemContainer3.Name = "ItemContainer3"
        Me.ItemContainer3.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnInfMargenes, Me.BtnRankingProductos, Me.Btn_Informe_Vencimiento_Ventas, Me.Btn_Informe_Ventas_On_Line, Me.Btn_Ventas, Me.Btn_Creditos_Vigentes, Me.Btn_Compromisos_No_Despachados, Me.Btn_Margenes_y_Proyeccion})
        '
        '
        '
        Me.ItemContainer3.TitleStyle.Class = "MetroTileGroupTitle"
        Me.ItemContainer3.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'BtnInfMargenes
        '
        Me.BtnInfMargenes.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnInfMargenes.Image = CType(resources.GetObject("BtnInfMargenes.Image"), System.Drawing.Image)
        Me.BtnInfMargenes.ImageIndent = New System.Drawing.Point(8, -10)
        Me.BtnInfMargenes.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnInfMargenes.Name = "BtnInfMargenes"
        Me.BtnInfMargenes.SymbolColor = System.Drawing.Color.Empty
        Me.BtnInfMargenes.Text = "<font size=""+4""><b>MARGENES</b></font><br/><font size=""-1"">Margenes de un periodo" &
    "</font>"
        Me.BtnInfMargenes.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.BtnInfMargenes.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.BtnInfMargenes.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.BtnInfMargenes.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.BtnInfMargenes.TileStyle.BackColorGradientAngle = 45
        Me.BtnInfMargenes.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.BtnInfMargenes.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.BtnInfMargenes.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.BtnInfMargenes.TileStyle.PaddingBottom = 4
        Me.BtnInfMargenes.TileStyle.PaddingLeft = 4
        Me.BtnInfMargenes.TileStyle.PaddingRight = 4
        Me.BtnInfMargenes.TileStyle.PaddingTop = 4
        Me.BtnInfMargenes.TileStyle.TextColor = System.Drawing.Color.White
        Me.BtnInfMargenes.TitleText = "Bakapp"
        '
        'BtnRankingProductos
        '
        Me.BtnRankingProductos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnRankingProductos.Image = CType(resources.GetObject("BtnRankingProductos.Image"), System.Drawing.Image)
        Me.BtnRankingProductos.ImageIndent = New System.Drawing.Point(8, -10)
        Me.BtnRankingProductos.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnRankingProductos.Name = "BtnRankingProductos"
        Me.BtnRankingProductos.SymbolColor = System.Drawing.Color.Empty
        Me.BtnRankingProductos.Text = "<font size=""+4""><b>RANKING DE PRODUCTOS</b></font><br/><font size=""-1"">Ranking 80" &
    "/20</font>"
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
        Me.BtnRankingProductos.TitleText = "Bakapp"
        '
        'Btn_Informe_Vencimiento_Ventas
        '
        Me.Btn_Informe_Vencimiento_Ventas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_Informe_Vencimiento_Ventas.Image = CType(resources.GetObject("Btn_Informe_Vencimiento_Ventas.Image"), System.Drawing.Image)
        Me.Btn_Informe_Vencimiento_Ventas.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Informe_Vencimiento_Ventas.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Informe_Vencimiento_Ventas.Name = "Btn_Informe_Vencimiento_Ventas"
        Me.Btn_Informe_Vencimiento_Ventas.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Informe_Vencimiento_Ventas.Text = "<font size=""+4""><b>VENCIMIENTOS</b></font><br/><font size=""-1"">Informe vencimient" &
    "os</font>"
        Me.Btn_Informe_Vencimiento_Ventas.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Teal
        Me.Btn_Informe_Vencimiento_Ventas.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Informe_Vencimiento_Ventas.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Informe_Vencimiento_Ventas.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Informe_Vencimiento_Ventas.TileStyle.PaddingBottom = 4
        Me.Btn_Informe_Vencimiento_Ventas.TileStyle.PaddingLeft = 4
        Me.Btn_Informe_Vencimiento_Ventas.TileStyle.PaddingRight = 4
        Me.Btn_Informe_Vencimiento_Ventas.TileStyle.PaddingTop = 4
        Me.Btn_Informe_Vencimiento_Ventas.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Informe_Vencimiento_Ventas.TitleText = "Bakapp"
        '
        'Btn_Informe_Ventas_On_Line
        '
        Me.Btn_Informe_Ventas_On_Line.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_Informe_Ventas_On_Line.Image = CType(resources.GetObject("Btn_Informe_Ventas_On_Line.Image"), System.Drawing.Image)
        Me.Btn_Informe_Ventas_On_Line.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Informe_Ventas_On_Line.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Informe_Ventas_On_Line.Name = "Btn_Informe_Ventas_On_Line"
        Me.Btn_Informe_Ventas_On_Line.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Informe_Ventas_On_Line.Text = "<font size=""+4""><b>VENTAS ON-LINE</b></font><br/><font size=""-1"">Ventas Diarias, " &
    "Mensualesy Anuales<br/>Guías diarias<br/></font>"
        Me.Btn_Informe_Ventas_On_Line.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.RedOrange
        Me.Btn_Informe_Ventas_On_Line.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Informe_Ventas_On_Line.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_Informe_Ventas_On_Line.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_Informe_Ventas_On_Line.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Informe_Ventas_On_Line.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_Informe_Ventas_On_Line.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_Informe_Ventas_On_Line.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Informe_Ventas_On_Line.TileStyle.PaddingBottom = 4
        Me.Btn_Informe_Ventas_On_Line.TileStyle.PaddingLeft = 4
        Me.Btn_Informe_Ventas_On_Line.TileStyle.PaddingRight = 4
        Me.Btn_Informe_Ventas_On_Line.TileStyle.PaddingTop = 4
        Me.Btn_Informe_Ventas_On_Line.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Informe_Ventas_On_Line.TitleText = "Bakapp"
        '
        'Btn_Ventas
        '
        Me.Btn_Ventas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_Ventas.Image = CType(resources.GetObject("Btn_Ventas.Image"), System.Drawing.Image)
        Me.Btn_Ventas.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Ventas.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Ventas.Name = "Btn_Ventas"
        Me.Btn_Ventas.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Ventas.Text = "<font size=""+4""><b>VENTAS DEL PERIODO</b></font><br/><font size=""-1"">Nivel docume" &
    "nto,Nivel detalle<br/>X Cliente y X Productos.</font>"
        Me.Btn_Ventas.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.Btn_Ventas.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Ventas.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.Btn_Ventas.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.Btn_Ventas.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Ventas.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.Btn_Ventas.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.Btn_Ventas.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Ventas.TileStyle.PaddingBottom = 4
        Me.Btn_Ventas.TileStyle.PaddingLeft = 4
        Me.Btn_Ventas.TileStyle.PaddingRight = 4
        Me.Btn_Ventas.TileStyle.PaddingTop = 4
        Me.Btn_Ventas.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Ventas.TitleText = "Bakapp"
        '
        'Btn_Creditos_Vigentes
        '
        Me.Btn_Creditos_Vigentes.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_Creditos_Vigentes.Image = CType(resources.GetObject("Btn_Creditos_Vigentes.Image"), System.Drawing.Image)
        Me.Btn_Creditos_Vigentes.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Creditos_Vigentes.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Creditos_Vigentes.Name = "Btn_Creditos_Vigentes"
        Me.Btn_Creditos_Vigentes.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Creditos_Vigentes.Text = "<font size=""+4""><b>CREDITOS VIGENTES</b></font><br/><font size=""-1"">Comportamient" &
    "o de pago<br/>Cheques en cartera</font>"
        Me.Btn_Creditos_Vigentes.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.Btn_Creditos_Vigentes.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Creditos_Vigentes.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.Btn_Creditos_Vigentes.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.Btn_Creditos_Vigentes.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Creditos_Vigentes.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.Btn_Creditos_Vigentes.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.Btn_Creditos_Vigentes.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Creditos_Vigentes.TileStyle.PaddingBottom = 4
        Me.Btn_Creditos_Vigentes.TileStyle.PaddingLeft = 4
        Me.Btn_Creditos_Vigentes.TileStyle.PaddingRight = 4
        Me.Btn_Creditos_Vigentes.TileStyle.PaddingTop = 4
        Me.Btn_Creditos_Vigentes.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Creditos_Vigentes.TitleText = "Bakapp"
        '
        'Btn_Compromisos_No_Despachados
        '
        Me.Btn_Compromisos_No_Despachados.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_Compromisos_No_Despachados.Image = CType(resources.GetObject("Btn_Compromisos_No_Despachados.Image"), System.Drawing.Image)
        Me.Btn_Compromisos_No_Despachados.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Compromisos_No_Despachados.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Compromisos_No_Despachados.Name = "Btn_Compromisos_No_Despachados"
        Me.Btn_Compromisos_No_Despachados.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Compromisos_No_Despachados.Text = "<font size=""+4""><b>COMPROMISOS NO DESPACHADOS</b></font><br/><font size=""-1""></fo" &
    "nt>"
        Me.Btn_Compromisos_No_Despachados.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Olive
        Me.Btn_Compromisos_No_Despachados.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Compromisos_No_Despachados.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Compromisos_No_Despachados.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Compromisos_No_Despachados.TileStyle.PaddingBottom = 4
        Me.Btn_Compromisos_No_Despachados.TileStyle.PaddingLeft = 4
        Me.Btn_Compromisos_No_Despachados.TileStyle.PaddingRight = 4
        Me.Btn_Compromisos_No_Despachados.TileStyle.PaddingTop = 4
        Me.Btn_Compromisos_No_Despachados.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Compromisos_No_Despachados.TitleText = "Bakapp"
        '
        'Btn_Margenes_y_Proyeccion
        '
        Me.Btn_Margenes_y_Proyeccion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_Margenes_y_Proyeccion.Image = CType(resources.GetObject("Btn_Margenes_y_Proyeccion.Image"), System.Drawing.Image)
        Me.Btn_Margenes_y_Proyeccion.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Margenes_y_Proyeccion.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Margenes_y_Proyeccion.Name = "Btn_Margenes_y_Proyeccion"
        Me.Btn_Margenes_y_Proyeccion.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Margenes_y_Proyeccion.Text = "<font size=""+4""><b>MARGENES Y PROYECION</b></font><br/><font size=""-1"">Margenes d" &
    "e un periodo</font>"
        Me.Btn_Margenes_y_Proyeccion.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.Btn_Margenes_y_Proyeccion.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Margenes_y_Proyeccion.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.Btn_Margenes_y_Proyeccion.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.Btn_Margenes_y_Proyeccion.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Margenes_y_Proyeccion.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.Btn_Margenes_y_Proyeccion.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.Btn_Margenes_y_Proyeccion.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Margenes_y_Proyeccion.TileStyle.PaddingBottom = 4
        Me.Btn_Margenes_y_Proyeccion.TileStyle.PaddingLeft = 4
        Me.Btn_Margenes_y_Proyeccion.TileStyle.PaddingRight = 4
        Me.Btn_Margenes_y_Proyeccion.TileStyle.PaddingTop = 4
        Me.Btn_Margenes_y_Proyeccion.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Margenes_y_Proyeccion.TitleText = "Bakapp"
        '
        'Context_Menu_Solicitud_Compra
        '
        Me.Context_Menu_Solicitud_Compra.AntiAlias = True
        Me.Context_Menu_Solicitud_Compra.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Context_Menu_Solicitud_Compra.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_01})
        Me.Context_Menu_Solicitud_Compra.Location = New System.Drawing.Point(459, 17)
        Me.Context_Menu_Solicitud_Compra.Name = "Context_Menu_Solicitud_Compra"
        Me.Context_Menu_Solicitud_Compra.Size = New System.Drawing.Size(118, 25)
        Me.Context_Menu_Solicitud_Compra.Stretch = True
        Me.Context_Menu_Solicitud_Compra.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Context_Menu_Solicitud_Compra.TabIndex = 50
        Me.Context_Menu_Solicitud_Compra.TabStop = False
        Me.Context_Menu_Solicitud_Compra.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_01
        '
        Me.Menu_Contextual_01.AutoExpandOnClick = True
        Me.Menu_Contextual_01.Name = "Menu_Contextual_01"
        Me.Menu_Contextual_01.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Lbl_Mnu_1, Me.Btn_Mnu_Informe_Vencimientos, Me.Btn_Mnu_Informe_Ventas_On_Line})
        Me.Menu_Contextual_01.Text = "Opciones"
        '
        'Lbl_Mnu_1
        '
        Me.Lbl_Mnu_1.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Lbl_Mnu_1.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.Lbl_Mnu_1.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.Lbl_Mnu_1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.Lbl_Mnu_1.Name = "Lbl_Mnu_1"
        Me.Lbl_Mnu_1.PaddingBottom = 1
        Me.Lbl_Mnu_1.PaddingLeft = 10
        Me.Lbl_Mnu_1.PaddingTop = 1
        Me.Lbl_Mnu_1.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.Lbl_Mnu_1.Text = "Informes de venta"
        '
        'Btn_Mnu_Informe_Vencimientos
        '
        Me.Btn_Mnu_Informe_Vencimientos.Image = CType(resources.GetObject("Btn_Mnu_Informe_Vencimientos.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Informe_Vencimientos.Name = "Btn_Mnu_Informe_Vencimientos"
        Me.Btn_Mnu_Informe_Vencimientos.Text = "Informe Vencimientos"
        Me.Btn_Mnu_Informe_Vencimientos.Visible = False
        '
        'Btn_Mnu_Informe_Ventas_On_Line
        '
        Me.Btn_Mnu_Informe_Ventas_On_Line.Image = CType(resources.GetObject("Btn_Mnu_Informe_Ventas_On_Line.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Informe_Ventas_On_Line.Name = "Btn_Mnu_Informe_Ventas_On_Line"
        Me.Btn_Mnu_Informe_Ventas_On_Line.Text = "Informe Ventas On-Line"
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.LabelX1.Location = New System.Drawing.Point(11, 0)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(387, 49)
        Me.LabelX1.TabIndex = 51
        Me.LabelX1.Text = "<font color=""#349FCE""><b>INFORMES DE VENTA</b></font>"
        '
        'InformesVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Context_Menu_Solicitud_Compra)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.Name = "InformesVenta"
        Me.Size = New System.Drawing.Size(646, 421)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Context_Menu_Solicitud_Compra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents ItemContainer3 As DevComponents.DotNetBar.ItemContainer
    Private WithEvents BtnInfMargenes As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents BtnRankingProductos As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Informe_Vencimiento_Ventas As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Informe_Ventas_On_Line As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents Context_Menu_Solicitud_Compra As DevComponents.DotNetBar.ContextMenuBar
    Public WithEvents Menu_Contextual_01 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Lbl_Mnu_1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Mnu_Informe_Vencimientos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_Informe_Ventas_On_Line As DevComponents.DotNetBar.ButtonItem
    Private WithEvents Btn_Ventas As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Creditos_Vigentes As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Compromisos_No_Despachados As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Private WithEvents Btn_Margenes_y_Proyeccion As DevComponents.DotNetBar.Metro.MetroTileItem
End Class
