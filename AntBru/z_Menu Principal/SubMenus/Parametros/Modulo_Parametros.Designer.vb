<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Modulo_Parametros
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Modulo_Parametros))
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem()
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel()
        Me.ContenedorTablas = New DevComponents.DotNetBar.ItemContainer()
        Me.BtnCreacionEntidad = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.BtnProductos = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Tablas_Conf_Entidad = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Tablas_Conf_Productos = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Tablas_BakApp = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSalir})
        Me.Bar2.Location = New System.Drawing.Point(0, 277)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(633, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 33
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
        Me.MetroTilePanel1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ContenedorTablas})
        Me.MetroTilePanel1.ItemSpacing = 2
        Me.MetroTilePanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MetroTilePanel1.Location = New System.Drawing.Point(3, 48)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(763, 304)
        Me.MetroTilePanel1.TabIndex = 32
        Me.MetroTilePanel1.Text = "MetroTilePanel1"
        '
        'ContenedorTablas
        '
        '
        '
        '
        Me.ContenedorTablas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ContenedorTablas.FixedSize = New System.Drawing.Size(610, 240)
        Me.ContenedorTablas.MultiLine = True
        Me.ContenedorTablas.Name = "ContenedorTablas"
        Me.ContenedorTablas.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnCreacionEntidad, Me.BtnProductos, Me.Btn_Tablas_Conf_Entidad, Me.Btn_Tablas_Conf_Productos, Me.Btn_Tablas_BakApp})
        '
        '
        '
        Me.ContenedorTablas.TitleStyle.Class = "MetroTileGroupTitle"
        Me.ContenedorTablas.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'BtnCreacionEntidad
        '
        Me.BtnCreacionEntidad.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCreacionEntidad.Image = CType(resources.GetObject("BtnCreacionEntidad.Image"), System.Drawing.Image)
        Me.BtnCreacionEntidad.ImageIndent = New System.Drawing.Point(18, -10)
        Me.BtnCreacionEntidad.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnCreacionEntidad.Name = "BtnCreacionEntidad"
        Me.BtnCreacionEntidad.SymbolColor = System.Drawing.Color.Empty
        Me.BtnCreacionEntidad.Text = "<font size=""+4""><b>ENTIDADES</b></font><br/>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Maestra, configuración, tablas."
        Me.BtnCreacionEntidad.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Olive
        Me.BtnCreacionEntidad.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.BtnCreacionEntidad.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BtnCreacionEntidad.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BtnCreacionEntidad.TileStyle.BackColorGradientAngle = 45
        Me.BtnCreacionEntidad.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BtnCreacionEntidad.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BtnCreacionEntidad.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.BtnCreacionEntidad.TileStyle.PaddingBottom = 4
        Me.BtnCreacionEntidad.TileStyle.PaddingLeft = 4
        Me.BtnCreacionEntidad.TileStyle.PaddingRight = 4
        Me.BtnCreacionEntidad.TileStyle.PaddingTop = 4
        Me.BtnCreacionEntidad.TileStyle.TextColor = System.Drawing.Color.White
        Me.BtnCreacionEntidad.TitleText = "MENU GESTION"
        '
        'BtnProductos
        '
        Me.BtnProductos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnProductos.Image = CType(resources.GetObject("BtnProductos.Image"), System.Drawing.Image)
        Me.BtnProductos.ImageIndent = New System.Drawing.Point(18, -10)
        Me.BtnProductos.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnProductos.Name = "BtnProductos"
        Me.BtnProductos.SymbolColor = System.Drawing.Color.Empty
        Me.BtnProductos.Text = "<font size=""+4""><b>PRODUCTOS</b></font><br/>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Maestra, configuracion, tablas"
        Me.BtnProductos.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.DarkBlue
        Me.BtnProductos.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.BtnProductos.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.BtnProductos.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.BtnProductos.TileStyle.BackColorGradientAngle = 45
        Me.BtnProductos.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.BtnProductos.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.BtnProductos.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.BtnProductos.TileStyle.PaddingBottom = 4
        Me.BtnProductos.TileStyle.PaddingLeft = 4
        Me.BtnProductos.TileStyle.PaddingRight = 4
        Me.BtnProductos.TileStyle.PaddingTop = 4
        Me.BtnProductos.TileStyle.TextColor = System.Drawing.Color.White
        Me.BtnProductos.TitleText = "BakApp"
        '
        'Btn_Tablas_Conf_Entidad
        '
        Me.Btn_Tablas_Conf_Entidad.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_Tablas_Conf_Entidad.Image = CType(resources.GetObject("Btn_Tablas_Conf_Entidad.Image"), System.Drawing.Image)
        Me.Btn_Tablas_Conf_Entidad.ImageIndent = New System.Drawing.Point(18, -10)
        Me.Btn_Tablas_Conf_Entidad.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Tablas_Conf_Entidad.Name = "Btn_Tablas_Conf_Entidad"
        Me.Btn_Tablas_Conf_Entidad.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Tablas_Conf_Entidad.Text = "<font size=""+4""><b>TABLAS DE ENTIDADES</b></font><br/>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<font size=""+1""></font>"
        Me.Btn_Tablas_Conf_Entidad.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Azure
        Me.Btn_Tablas_Conf_Entidad.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Tablas_Conf_Entidad.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.Btn_Tablas_Conf_Entidad.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.Btn_Tablas_Conf_Entidad.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Tablas_Conf_Entidad.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.Btn_Tablas_Conf_Entidad.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.Btn_Tablas_Conf_Entidad.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Tablas_Conf_Entidad.TileStyle.PaddingBottom = 4
        Me.Btn_Tablas_Conf_Entidad.TileStyle.PaddingLeft = 4
        Me.Btn_Tablas_Conf_Entidad.TileStyle.PaddingRight = 4
        Me.Btn_Tablas_Conf_Entidad.TileStyle.PaddingTop = 4
        Me.Btn_Tablas_Conf_Entidad.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Tablas_Conf_Entidad.TitleText = "BakApp"
        '
        'Btn_Tablas_Conf_Productos
        '
        Me.Btn_Tablas_Conf_Productos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_Tablas_Conf_Productos.Image = CType(resources.GetObject("Btn_Tablas_Conf_Productos.Image"), System.Drawing.Image)
        Me.Btn_Tablas_Conf_Productos.ImageIndent = New System.Drawing.Point(18, -10)
        Me.Btn_Tablas_Conf_Productos.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Tablas_Conf_Productos.Name = "Btn_Tablas_Conf_Productos"
        Me.Btn_Tablas_Conf_Productos.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Tablas_Conf_Productos.Text = "<font size=""+4""><b>TABLAS DE PRODUCTOS</b></font><br/>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<font size=""+1""></font>"
        Me.Btn_Tablas_Conf_Productos.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.RedOrange
        Me.Btn_Tablas_Conf_Productos.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Tablas_Conf_Productos.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_Tablas_Conf_Productos.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_Tablas_Conf_Productos.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Tablas_Conf_Productos.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_Tablas_Conf_Productos.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_Tablas_Conf_Productos.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Tablas_Conf_Productos.TileStyle.PaddingBottom = 4
        Me.Btn_Tablas_Conf_Productos.TileStyle.PaddingLeft = 4
        Me.Btn_Tablas_Conf_Productos.TileStyle.PaddingRight = 4
        Me.Btn_Tablas_Conf_Productos.TileStyle.PaddingTop = 4
        Me.Btn_Tablas_Conf_Productos.TileStyle.TextColor = System.Drawing.Color.WhiteSmoke
        Me.Btn_Tablas_Conf_Productos.TitleText = "BakApp"
        '
        'Btn_Tablas_BakApp
        '
        Me.Btn_Tablas_BakApp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_Tablas_BakApp.Image = CType(resources.GetObject("Btn_Tablas_BakApp.Image"), System.Drawing.Image)
        Me.Btn_Tablas_BakApp.ImageIndent = New System.Drawing.Point(18, -10)
        Me.Btn_Tablas_BakApp.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Tablas_BakApp.Name = "Btn_Tablas_BakApp"
        Me.Btn_Tablas_BakApp.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Tablas_BakApp.Text = "<font size=""+4""><b>TABLAS DE CONFIGURACION BAKAPP</b></font><br/>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<font size=""+1" &
    """></font>"
        Me.Btn_Tablas_BakApp.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Olive
        Me.Btn_Tablas_BakApp.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Tablas_BakApp.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(144, Byte), Integer), CType(CType(9, Byte), Integer))
        Me.Btn_Tablas_BakApp.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(144, Byte), Integer), CType(CType(9, Byte), Integer))
        Me.Btn_Tablas_BakApp.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Tablas_BakApp.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Btn_Tablas_BakApp.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Btn_Tablas_BakApp.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Tablas_BakApp.TileStyle.PaddingBottom = 4
        Me.Btn_Tablas_BakApp.TileStyle.PaddingLeft = 4
        Me.Btn_Tablas_BakApp.TileStyle.PaddingRight = 4
        Me.Btn_Tablas_BakApp.TileStyle.PaddingTop = 4
        Me.Btn_Tablas_BakApp.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Tablas_BakApp.TitleText = "BakApp"
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.LabelX1.Location = New System.Drawing.Point(6, 0)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(245, 49)
        Me.LabelX1.TabIndex = 39
        Me.LabelX1.Text = "<font color=""#349FCE""><b>PARAMETROS</b></font>"
        '
        'Modulo_Parametros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.Name = "Modulo_Parametros"
        Me.Size = New System.Drawing.Size(633, 318)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents ContenedorTablas As DevComponents.DotNetBar.ItemContainer
    Private WithEvents BtnCreacionEntidad As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents BtnProductos As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Tablas_Conf_Productos As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Tablas_Conf_Entidad As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Tablas_BakApp As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
End Class
