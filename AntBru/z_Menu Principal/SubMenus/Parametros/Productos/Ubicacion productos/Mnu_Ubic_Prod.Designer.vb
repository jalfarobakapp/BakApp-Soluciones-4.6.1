<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Mnu_Ubic_Prod
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Mnu_Ubic_Prod))
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem()
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel()
        Me.ConsultaPreciosContenedor = New DevComponents.DotNetBar.ItemContainer()
        Me.BtnUbicxProductos = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.BtnVerUbicaciones = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.BtnMantUbicaciones = New DevComponents.DotNetBar.Metro.MetroTileItem()
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
        Me.Bar2.Location = New System.Drawing.Point(0, 198)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(641, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 43
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
        Me.MetroTilePanel1.Location = New System.Drawing.Point(0, 58)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(695, 188)
        Me.MetroTilePanel1.TabIndex = 42
        Me.MetroTilePanel1.Text = "MetroTilePanel1"
        '
        'ConsultaPreciosContenedor
        '
        '
        '
        '
        Me.ConsultaPreciosContenedor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ConsultaPreciosContenedor.FixedSize = New System.Drawing.Size(620, 120)
        Me.ConsultaPreciosContenedor.MultiLine = True
        Me.ConsultaPreciosContenedor.Name = "ConsultaPreciosContenedor"
        Me.ConsultaPreciosContenedor.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnUbicxProductos, Me.BtnVerUbicaciones, Me.BtnMantUbicaciones})
        '
        '
        '
        Me.ConsultaPreciosContenedor.TitleStyle.Class = "MetroTileGroupTitle"
        Me.ConsultaPreciosContenedor.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ConsultaPreciosContenedor.TitleStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'BtnUbicxProductos
        '
        Me.BtnUbicxProductos.Image = CType(resources.GetObject("BtnUbicxProductos.Image"), System.Drawing.Image)
        Me.BtnUbicxProductos.ImageIndent = New System.Drawing.Point(8, -6)
        Me.BtnUbicxProductos.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnUbicxProductos.Name = "BtnUbicxProductos"
        Me.BtnUbicxProductos.SymbolColor = System.Drawing.Color.Empty
        Me.BtnUbicxProductos.Text = "<font size=""+4"">Ubic. X Producto</font><br/><font size=""-1"">Ver ubicaciones por p" &
    "roducto</font>"
        Me.BtnUbicxProductos.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green
        Me.BtnUbicxProductos.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.BtnUbicxProductos.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnUbicxProductos.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnUbicxProductos.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnUbicxProductos.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnUbicxProductos.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.BtnUbicxProductos.TileStyle.TextColor = System.Drawing.Color.White
        Me.BtnUbicxProductos.TitleText = "BakApp"
        '
        'BtnVerUbicaciones
        '
        Me.BtnVerUbicaciones.Image = CType(resources.GetObject("BtnVerUbicaciones.Image"), System.Drawing.Image)
        Me.BtnVerUbicaciones.ImageIndent = New System.Drawing.Point(8, -6)
        Me.BtnVerUbicaciones.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnVerUbicaciones.Name = "BtnVerUbicaciones"
        Me.BtnVerUbicaciones.SymbolColor = System.Drawing.Color.Empty
        Me.BtnVerUbicaciones.Text = "<font size=""+4"">Mapa de bodega</font><br/><font size=""-1"">Asignar ubicaciones con" &
    " mapa</font>"
        Me.BtnVerUbicaciones.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Blueish
        Me.BtnVerUbicaciones.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.BtnVerUbicaciones.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.BtnVerUbicaciones.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.BtnVerUbicaciones.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.BtnVerUbicaciones.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.BtnVerUbicaciones.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.BtnVerUbicaciones.TileStyle.TextColor = System.Drawing.Color.White
        Me.BtnVerUbicaciones.TitleText = "BakApp"
        '
        'BtnMantUbicaciones
        '
        Me.BtnMantUbicaciones.Image = CType(resources.GetObject("BtnMantUbicaciones.Image"), System.Drawing.Image)
        Me.BtnMantUbicaciones.ImageIndent = New System.Drawing.Point(8, -6)
        Me.BtnMantUbicaciones.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnMantUbicaciones.Name = "BtnMantUbicaciones"
        Me.BtnMantUbicaciones.SymbolColor = System.Drawing.Color.Empty
        Me.BtnMantUbicaciones.Text = "<font size=""+4"">Configuracion de Ubicaciones</font><br/><font size=""-1"">Mantenció" &
    "n de sectores y ubicaciones</font>"
        Me.BtnMantUbicaciones.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Yellowish
        Me.BtnMantUbicaciones.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.BtnMantUbicaciones.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.BtnMantUbicaciones.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.BtnMantUbicaciones.TileStyle.BackColorGradientAngle = 45
        Me.BtnMantUbicaciones.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.BtnMantUbicaciones.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.BtnMantUbicaciones.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.BtnMantUbicaciones.TileStyle.PaddingBottom = 4
        Me.BtnMantUbicaciones.TileStyle.PaddingLeft = 4
        Me.BtnMantUbicaciones.TileStyle.PaddingRight = 4
        Me.BtnMantUbicaciones.TileStyle.PaddingTop = 4
        Me.BtnMantUbicaciones.TileStyle.TextColor = System.Drawing.Color.White
        Me.BtnMantUbicaciones.TitleText = "BakApp"
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
        Me.LabelX1.Size = New System.Drawing.Size(549, 49)
        Me.LabelX1.TabIndex = 45
        Me.LabelX1.Text = "<font color=""#349FCE""><b>MAPA Y UBICACIONES EN BODEGA</b></font>"
        '
        'Mnu_Ubic_Prod
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.Name = "Mnu_Ubic_Prod"
        Me.Size = New System.Drawing.Size(641, 239)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents ConsultaPreciosContenedor As DevComponents.DotNetBar.ItemContainer
    Private WithEvents BtnUbicxProductos As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents BtnVerUbicaciones As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents BtnMantUbicaciones As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
End Class
