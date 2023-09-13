<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Sistema_Inventarios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Sistema_Inventarios))
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem()
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel()
        Me.ConsultaPreciosContenedor = New DevComponents.DotNetBar.ItemContainer()
        Me.BtnSisinvenParcializado = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Inventario_General = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.BtnUbicProductos = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Documentos_Stock = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Maquila = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.BtnCambiarDeUsuario = New DevComponents.DotNetBar.ButtonItem()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSalir, Me.BtnCambiarDeUsuario})
        Me.Bar2.Location = New System.Drawing.Point(0, 291)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(642, 41)
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
        Me.MetroTilePanel1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ConsultaPreciosContenedor})
        Me.MetroTilePanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MetroTilePanel1.Location = New System.Drawing.Point(3, 48)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(700, 397)
        Me.MetroTilePanel1.TabIndex = 33
        Me.MetroTilePanel1.Text = "MetroTilePanel1"
        '
        'ConsultaPreciosContenedor
        '
        '
        '
        '
        Me.ConsultaPreciosContenedor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ConsultaPreciosContenedor.FixedSize = New System.Drawing.Size(650, 300)
        Me.ConsultaPreciosContenedor.MultiLine = True
        Me.ConsultaPreciosContenedor.Name = "ConsultaPreciosContenedor"
        Me.ConsultaPreciosContenedor.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSisinvenParcializado, Me.Btn_Inventario_General, Me.BtnUbicProductos, Me.Btn_Documentos_Stock, Me.Btn_Maquila})
        '
        '
        '
        Me.ConsultaPreciosContenedor.TitleStyle.Class = "MetroTileGroupTitle"
        Me.ConsultaPreciosContenedor.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ConsultaPreciosContenedor.TitleStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'BtnSisinvenParcializado
        '
        Me.BtnSisinvenParcializado.Image = CType(resources.GetObject("BtnSisinvenParcializado.Image"), System.Drawing.Image)
        Me.BtnSisinvenParcializado.ImageIndent = New System.Drawing.Point(8, -6)
        Me.BtnSisinvenParcializado.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnSisinvenParcializado.Name = "BtnSisinvenParcializado"
        Me.BtnSisinvenParcializado.SymbolColor = System.Drawing.Color.Empty
        Me.BtnSisinvenParcializado.Text = "<font size=""+4""><b>AJUSTE INVENTARIO</b></font><br/><font size=""-1"">Sistema de aj" &
    "ustes, (GRI-GDI)</font>"
        Me.BtnSisinvenParcializado.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Yellow
        Me.BtnSisinvenParcializado.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.BtnSisinvenParcializado.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.BtnSisinvenParcializado.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.BtnSisinvenParcializado.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.BtnSisinvenParcializado.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.BtnSisinvenParcializado.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.BtnSisinvenParcializado.TileStyle.TextColor = System.Drawing.Color.White
        Me.BtnSisinvenParcializado.TitleText = "BakApp"
        '
        'Btn_Inventario_General
        '
        Me.Btn_Inventario_General.Image = CType(resources.GetObject("Btn_Inventario_General.Image"), System.Drawing.Image)
        Me.Btn_Inventario_General.ImageIndent = New System.Drawing.Point(8, -6)
        Me.Btn_Inventario_General.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Inventario_General.Name = "Btn_Inventario_General"
        Me.Btn_Inventario_General.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Inventario_General.Text = "<font size=""+4""><b>INV. GENERAL</b></font><br/><font size=""-1"">Sis. de toma de in" &
    "v. general</font>"
        Me.Btn_Inventario_General.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.Btn_Inventario_General.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Inventario_General.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.Btn_Inventario_General.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.Btn_Inventario_General.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Inventario_General.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.Btn_Inventario_General.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.Btn_Inventario_General.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Inventario_General.TileStyle.PaddingBottom = 4
        Me.Btn_Inventario_General.TileStyle.PaddingLeft = 4
        Me.Btn_Inventario_General.TileStyle.PaddingRight = 4
        Me.Btn_Inventario_General.TileStyle.PaddingTop = 4
        Me.Btn_Inventario_General.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Inventario_General.TitleText = "BakApp"
        '
        'BtnUbicProductos
        '
        Me.BtnUbicProductos.Image = CType(resources.GetObject("BtnUbicProductos.Image"), System.Drawing.Image)
        Me.BtnUbicProductos.ImageIndent = New System.Drawing.Point(8, -6)
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
        'Btn_Documentos_Stock
        '
        Me.Btn_Documentos_Stock.Image = CType(resources.GetObject("Btn_Documentos_Stock.Image"), System.Drawing.Image)
        Me.Btn_Documentos_Stock.ImageIndent = New System.Drawing.Point(8, -6)
        Me.Btn_Documentos_Stock.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Documentos_Stock.Name = "Btn_Documentos_Stock"
        Me.Btn_Documentos_Stock.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Documentos_Stock.Text = "<font size=""+4""><b>DOCUMENTOS</b></font><br/>Generar documentos de stock"
        Me.Btn_Documentos_Stock.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.Btn_Documentos_Stock.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Documentos_Stock.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_Documentos_Stock.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_Documentos_Stock.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_Documentos_Stock.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_Documentos_Stock.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Documentos_Stock.TitleText = "BakApp"
        '
        'Btn_Maquila
        '
        Me.Btn_Maquila.Image = CType(resources.GetObject("Btn_Maquila.Image"), System.Drawing.Image)
        Me.Btn_Maquila.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Maquila.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Maquila.Name = "Btn_Maquila"
        Me.Btn_Maquila.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Maquila.Text = "<font size=""+4""><b>MAQUILAR</b></font><br/><font size=""-1"">Ingreso de guias de re" &
    "cepción por maquilación<br/> </font>"
        Me.Btn_Maquila.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.PlumWashed
        Me.Btn_Maquila.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Maquila.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(123, Byte), Integer))
        Me.Btn_Maquila.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(123, Byte), Integer))
        Me.Btn_Maquila.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(123, Byte), Integer))
        Me.Btn_Maquila.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(123, Byte), Integer))
        Me.Btn_Maquila.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Maquila.TitleText = "BakApp"
        Me.Btn_Maquila.Visible = False
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.LabelX1.Location = New System.Drawing.Point(6, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(245, 49)
        Me.LabelX1.TabIndex = 36
        Me.LabelX1.Text = "<font color=""#349FCE""><b>INVENTARIOS</b></font>"
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
        'Sistema_Inventarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.Controls.Add(Me.LabelX1)
        Me.Name = "Sistema_Inventarios"
        Me.Size = New System.Drawing.Size(642, 332)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents ConsultaPreciosContenedor As DevComponents.DotNetBar.ItemContainer
    Private WithEvents BtnSisinvenParcializado As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Inventario_General As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents BtnUbicProductos As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Private WithEvents Btn_Documentos_Stock As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Maquila As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents BtnCambiarDeUsuario As DevComponents.DotNetBar.ButtonItem
End Class
