<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tablas_BakApp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Tablas_BakApp))
        Me.ConsultaPreciosContenedor = New DevComponents.DotNetBar.ItemContainer()
        Me.Btn_Arbol_Clasificaciones = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Marca_Vehiculo = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem()
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ConsultaPreciosContenedor
        '
        '
        '
        '
        Me.ConsultaPreciosContenedor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ConsultaPreciosContenedor.FixedSize = New System.Drawing.Size(550, 100)
        Me.ConsultaPreciosContenedor.MultiLine = True
        Me.ConsultaPreciosContenedor.Name = "ConsultaPreciosContenedor"
        Me.ConsultaPreciosContenedor.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Arbol_Clasificaciones, Me.Btn_Marca_Vehiculo})
        '
        '
        '
        Me.ConsultaPreciosContenedor.TitleStyle.Class = "MetroTileGroupTitle"
        Me.ConsultaPreciosContenedor.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ConsultaPreciosContenedor.TitleStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'Btn_Arbol_Clasificaciones
        '
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
        Me.Btn_Arbol_Clasificaciones.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(144, Byte), Integer), CType(CType(9, Byte), Integer))
        Me.Btn_Arbol_Clasificaciones.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(144, Byte), Integer), CType(CType(9, Byte), Integer))
        Me.Btn_Arbol_Clasificaciones.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Arbol_Clasificaciones.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(144, Byte), Integer), CType(CType(9, Byte), Integer))
        Me.Btn_Arbol_Clasificaciones.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(144, Byte), Integer), CType(CType(9, Byte), Integer))
        Me.Btn_Arbol_Clasificaciones.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Arbol_Clasificaciones.TileStyle.PaddingBottom = 4
        Me.Btn_Arbol_Clasificaciones.TileStyle.PaddingLeft = 4
        Me.Btn_Arbol_Clasificaciones.TileStyle.PaddingRight = 4
        Me.Btn_Arbol_Clasificaciones.TileStyle.PaddingTop = 4
        Me.Btn_Arbol_Clasificaciones.TileStyle.TextColor = System.Drawing.Color.White
        '
        'Btn_Marca_Vehiculo
        '
        Me.Btn_Marca_Vehiculo.Image = CType(resources.GetObject("Btn_Marca_Vehiculo.Image"), System.Drawing.Image)
        Me.Btn_Marca_Vehiculo.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Marca_Vehiculo.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Marca_Vehiculo.Name = "Btn_Marca_Vehiculo"
        Me.Btn_Marca_Vehiculo.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Marca_Vehiculo.Text = "<font size=""+4""><b>TABLAS VEHICULOS</b></font><br/><font size=""-1"">Mantención de " &
    "Tipos, Marcas y Modelos de vehículos</font>"
        Me.Btn_Marca_Vehiculo.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Teal
        Me.Btn_Marca_Vehiculo.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Marca_Vehiculo.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Marca_Vehiculo.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Marca_Vehiculo.TitleText = "BakApp"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSalir})
        Me.Bar2.Location = New System.Drawing.Point(0, 193)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(439, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 49
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
        Me.MetroTilePanel1.Location = New System.Drawing.Point(3, 60)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(589, 132)
        Me.MetroTilePanel1.TabIndex = 48
        Me.MetroTilePanel1.Text = "MetroTilePanel1"
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.LabelX1.Location = New System.Drawing.Point(0, 5)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(299, 49)
        Me.LabelX1.TabIndex = 55
        Me.LabelX1.Text = "<font color=""#349FCE""><b>TABLAS DE BAKAPP</b></font>"
        '
        'Tablas_BakApp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.Name = "Tablas_BakApp"
        Me.Size = New System.Drawing.Size(439, 234)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ConsultaPreciosContenedor As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Private WithEvents Btn_Arbol_Clasificaciones As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Marca_Vehiculo As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX

End Class
