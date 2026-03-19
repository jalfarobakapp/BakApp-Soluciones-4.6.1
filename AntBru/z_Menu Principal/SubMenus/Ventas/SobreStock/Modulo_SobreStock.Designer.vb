<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Modulo_SobreStock
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Modulo_SobreStock))
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem()
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel()
        Me.ConsultaPreciosContenedor = New DevComponents.DotNetBar.ItemContainer()
        Me.Btn_COV_SobreStock = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_ProductoSobreStock = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_CreaNVVdesdeCOVSobreStock = New DevComponents.DotNetBar.Metro.MetroTileItem()
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
        Me.Bar2.Location = New System.Drawing.Point(0, 194)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(636, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 44
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
        Me.MetroTilePanel1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ConsultaPreciosContenedor})
        Me.MetroTilePanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MetroTilePanel1.Location = New System.Drawing.Point(0, 56)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(703, 411)
        Me.MetroTilePanel1.TabIndex = 43
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
        Me.ConsultaPreciosContenedor.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_COV_SobreStock, Me.Btn_ProductoSobreStock, Me.Btn_CreaNVVdesdeCOVSobreStock})
        '
        '
        '
        Me.ConsultaPreciosContenedor.TitleStyle.Class = "MetroTileGroupTitle"
        Me.ConsultaPreciosContenedor.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ConsultaPreciosContenedor.TitleStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'Btn_COV_SobreStock
        '
        Me.Btn_COV_SobreStock.Image = CType(resources.GetObject("Btn_COV_SobreStock.Image"), System.Drawing.Image)
        Me.Btn_COV_SobreStock.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_COV_SobreStock.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_COV_SobreStock.Name = "Btn_COV_SobreStock"
        Me.Btn_COV_SobreStock.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_COV_SobreStock.Text = "<font size=""+4""><b>COTIZACION</b></font><br/>Crear cotización Sobre Stock<font si" &
    "ze=""-1""></font>"
        Me.Btn_COV_SobreStock.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.Btn_COV_SobreStock.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_COV_SobreStock.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.Btn_COV_SobreStock.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.Btn_COV_SobreStock.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.Btn_COV_SobreStock.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.Btn_COV_SobreStock.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_COV_SobreStock.TitleText = "BakApp"
        '
        'Btn_ProductoSobreStock
        '
        Me.Btn_ProductoSobreStock.Image = CType(resources.GetObject("Btn_ProductoSobreStock.Image"), System.Drawing.Image)
        Me.Btn_ProductoSobreStock.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_ProductoSobreStock.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_ProductoSobreStock.Name = "Btn_ProductoSobreStock"
        Me.Btn_ProductoSobreStock.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_ProductoSobreStock.Text = "<font size=""+4""><b>PRODUCTOS</b></font><br/><font size=""-1"">Mantención de product" &
    "os con Sobre Stock</font>"
        Me.Btn_ProductoSobreStock.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green
        Me.Btn_ProductoSobreStock.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_ProductoSobreStock.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(164, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(93, Byte), Integer))
        Me.Btn_ProductoSobreStock.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(164, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(93, Byte), Integer))
        Me.Btn_ProductoSobreStock.TileStyle.BackColorGradientAngle = 45
        Me.Btn_ProductoSobreStock.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(164, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(93, Byte), Integer))
        Me.Btn_ProductoSobreStock.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(164, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(93, Byte), Integer))
        Me.Btn_ProductoSobreStock.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_ProductoSobreStock.TileStyle.PaddingBottom = 4
        Me.Btn_ProductoSobreStock.TileStyle.PaddingLeft = 4
        Me.Btn_ProductoSobreStock.TileStyle.PaddingRight = 4
        Me.Btn_ProductoSobreStock.TileStyle.PaddingTop = 4
        Me.Btn_ProductoSobreStock.TileStyle.TextColor = System.Drawing.Color.White
        '
        'Btn_CreaNVVdesdeCOVSobreStock
        '
        Me.Btn_CreaNVVdesdeCOVSobreStock.Image = CType(resources.GetObject("Btn_CreaNVVdesdeCOVSobreStock.Image"), System.Drawing.Image)
        Me.Btn_CreaNVVdesdeCOVSobreStock.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_CreaNVVdesdeCOVSobreStock.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_CreaNVVdesdeCOVSobreStock.Name = "Btn_CreaNVVdesdeCOVSobreStock"
        Me.Btn_CreaNVVdesdeCOVSobreStock.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_CreaNVVdesdeCOVSobreStock.Text = "<font size=""+4""><b>CREAR NOTAS DE VENTA</b></font><br/><font size=""-1"">Crear Nota" &
    "s de venta desde cotizaciones con Sobre Stock<br/> </font>"
        Me.Btn_CreaNVVdesdeCOVSobreStock.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.PlumWashed
        Me.Btn_CreaNVVdesdeCOVSobreStock.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_CreaNVVdesdeCOVSobreStock.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(123, Byte), Integer))
        Me.Btn_CreaNVVdesdeCOVSobreStock.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(123, Byte), Integer))
        Me.Btn_CreaNVVdesdeCOVSobreStock.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(123, Byte), Integer))
        Me.Btn_CreaNVVdesdeCOVSobreStock.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(123, Byte), Integer))
        Me.Btn_CreaNVVdesdeCOVSobreStock.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_CreaNVVdesdeCOVSobreStock.TitleText = "BakApp"
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.LabelX1.Location = New System.Drawing.Point(3, 1)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(321, 49)
        Me.LabelX1.TabIndex = 45
        Me.LabelX1.Text = "<font color=""#349FCE""><b>VENTAS SOBRE STOCK</b></font>"
        '
        'Modulo_SobreStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.Controls.Add(Me.LabelX1)
        Me.Name = "Modulo_SobreStock"
        Me.Size = New System.Drawing.Size(636, 235)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents ConsultaPreciosContenedor As DevComponents.DotNetBar.ItemContainer
    Private WithEvents Btn_COV_SobreStock As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_ProductoSobreStock As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_CreaNVVdesdeCOVSobreStock As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
End Class
