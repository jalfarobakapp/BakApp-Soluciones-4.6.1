<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tablas_Clasificaciones_Pro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Tablas_Clasificaciones_Pro))
        Me.Bar2 = New DevComponents.DotNetBar.Bar
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem
        Me.Btn_Actualizar_Tablas_BakApp = New DevComponents.DotNetBar.ButtonItem
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel
        Me.ContenedorTablas = New DevComponents.DotNetBar.ItemContainer
        Me.Btn_Arbol_Clasificaciones = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.Btn_Clasificacion_Libre = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.Btn_Marcas = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.Btn_Rubros = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.BtnTablasFamilias = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.Btn_Zonas = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSalir, Me.Btn_Actualizar_Tablas_BakApp})
        Me.Bar2.Location = New System.Drawing.Point(0, 290)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(636, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 36
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
        'Btn_Actualizar_Tablas_BakApp
        '
        Me.Btn_Actualizar_Tablas_BakApp.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Actualizar_Tablas_BakApp.ForeColor = System.Drawing.Color.Black
        Me.Btn_Actualizar_Tablas_BakApp.Image = CType(resources.GetObject("Btn_Actualizar_Tablas_BakApp.Image"), System.Drawing.Image)
        Me.Btn_Actualizar_Tablas_BakApp.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Actualizar_Tablas_BakApp.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.Btn_Actualizar_Tablas_BakApp.Name = "Btn_Actualizar_Tablas_BakApp"
        Me.Btn_Actualizar_Tablas_BakApp.Tooltip = "Exportar tablas desde Random a BakApp"
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
        Me.MetroTilePanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MetroTilePanel1.Location = New System.Drawing.Point(3, 58)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(697, 366)
        Me.MetroTilePanel1.TabIndex = 35
        Me.MetroTilePanel1.Text = "MetroTilePanel1"
        '
        'ContenedorTablas
        '
        '
        '
        '
        Me.ContenedorTablas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ContenedorTablas.FixedSize = New System.Drawing.Size(650, 400)
        Me.ContenedorTablas.MultiLine = True
        Me.ContenedorTablas.Name = "ContenedorTablas"
        Me.ContenedorTablas.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Arbol_Clasificaciones, Me.Btn_Clasificacion_Libre, Me.Btn_Marcas, Me.Btn_Rubros, Me.BtnTablasFamilias, Me.Btn_Zonas})
        '
        '
        '
        Me.ContenedorTablas.TitleStyle.Class = "MetroTileGroupTitle"
        Me.ContenedorTablas.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'Btn_Arbol_Clasificaciones
        '
        Me.Btn_Arbol_Clasificaciones.Image = CType(resources.GetObject("Btn_Arbol_Clasificaciones.Image"), System.Drawing.Image)
        Me.Btn_Arbol_Clasificaciones.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Arbol_Clasificaciones.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Arbol_Clasificaciones.Name = "Btn_Arbol_Clasificaciones"
        Me.Btn_Arbol_Clasificaciones.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Arbol_Clasificaciones.Text = "<font size=""+4""><b>ARBOL CLASIFICACIONES</b></font><br/><font size=""-1"">Mantenció" & _
            "n de clasificaciones.</font>"
        Me.Btn_Arbol_Clasificaciones.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Yellowish
        Me.Btn_Arbol_Clasificaciones.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Arbol_Clasificaciones.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Btn_Arbol_Clasificaciones.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Btn_Arbol_Clasificaciones.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Arbol_Clasificaciones.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Btn_Arbol_Clasificaciones.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Btn_Arbol_Clasificaciones.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Arbol_Clasificaciones.TileStyle.PaddingBottom = 4
        Me.Btn_Arbol_Clasificaciones.TileStyle.PaddingLeft = 4
        Me.Btn_Arbol_Clasificaciones.TileStyle.PaddingRight = 4
        Me.Btn_Arbol_Clasificaciones.TileStyle.PaddingTop = 4
        Me.Btn_Arbol_Clasificaciones.TileStyle.TextColor = System.Drawing.Color.White
        '
        'Btn_Clasificacion_Libre
        '
        Me.Btn_Clasificacion_Libre.Image = CType(resources.GetObject("Btn_Clasificacion_Libre.Image"), System.Drawing.Image)
        Me.Btn_Clasificacion_Libre.ImageIndent = New System.Drawing.Point(8, -6)
        Me.Btn_Clasificacion_Libre.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Clasificacion_Libre.Name = "Btn_Clasificacion_Libre"
        Me.Btn_Clasificacion_Libre.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Clasificacion_Libre.Text = "<font size=""+4""><b>CLASIFICACION LIBRE</b></font><br/><font size=""-1"">Mantención " & _
            "clasificaciones libre.</font>"
        Me.Btn_Clasificacion_Libre.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Orange
        Me.Btn_Clasificacion_Libre.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Clasificacion_Libre.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Btn_Clasificacion_Libre.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Btn_Clasificacion_Libre.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Clasificacion_Libre.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Btn_Clasificacion_Libre.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Btn_Clasificacion_Libre.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Clasificacion_Libre.TileStyle.PaddingBottom = 4
        Me.Btn_Clasificacion_Libre.TileStyle.PaddingLeft = 4
        Me.Btn_Clasificacion_Libre.TileStyle.PaddingRight = 4
        Me.Btn_Clasificacion_Libre.TileStyle.PaddingTop = 4
        Me.Btn_Clasificacion_Libre.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Clasificacion_Libre.TitleText = "BakApp"
        '
        'Btn_Marcas
        '
        Me.Btn_Marcas.Image = CType(resources.GetObject("Btn_Marcas.Image"), System.Drawing.Image)
        Me.Btn_Marcas.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Marcas.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Marcas.Name = "Btn_Marcas"
        Me.Btn_Marcas.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Marcas.Text = "<font size=""+4""><b>MARCAS</b></font><br/><font size=""-1"">Mantención de marcas.</f" & _
            "ont>"
        Me.Btn_Marcas.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.DarkBlue
        Me.Btn_Marcas.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Marcas.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.Btn_Marcas.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.Btn_Marcas.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Marcas.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.Btn_Marcas.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.Btn_Marcas.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Marcas.TileStyle.PaddingBottom = 4
        Me.Btn_Marcas.TileStyle.PaddingLeft = 4
        Me.Btn_Marcas.TileStyle.PaddingRight = 4
        Me.Btn_Marcas.TileStyle.PaddingTop = 4
        Me.Btn_Marcas.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Marcas.TitleText = "BakApp"
        '
        'Btn_Rubros
        '
        Me.Btn_Rubros.Image = CType(resources.GetObject("Btn_Rubros.Image"), System.Drawing.Image)
        Me.Btn_Rubros.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Rubros.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Rubros.Name = "Btn_Rubros"
        Me.Btn_Rubros.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Rubros.Text = "<font size=""+4""><b>RUBROS</b></font><br/><font size=""-1"">Mantención de rubros.</f" & _
            "ont>"
        Me.Btn_Rubros.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Teal
        Me.Btn_Rubros.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Rubros.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Btn_Rubros.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Btn_Rubros.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Rubros.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Btn_Rubros.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Btn_Rubros.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Rubros.TileStyle.PaddingBottom = 4
        Me.Btn_Rubros.TileStyle.PaddingLeft = 4
        Me.Btn_Rubros.TileStyle.PaddingRight = 4
        Me.Btn_Rubros.TileStyle.PaddingTop = 4
        Me.Btn_Rubros.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Rubros.TitleText = "BakApp"
        '
        'BtnTablasFamilias
        '
        Me.BtnTablasFamilias.Image = CType(resources.GetObject("BtnTablasFamilias.Image"), System.Drawing.Image)
        Me.BtnTablasFamilias.ImageIndent = New System.Drawing.Point(8, -10)
        Me.BtnTablasFamilias.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnTablasFamilias.Name = "BtnTablasFamilias"
        Me.BtnTablasFamilias.SymbolColor = System.Drawing.Color.Empty
        Me.BtnTablasFamilias.Text = "<font size=""+4""><b>FAMILIAS</b></font><br/><font size=""-1"">Mantención de tablas d" & _
            "e Super familia, familias y sub familias</font>"
        Me.BtnTablasFamilias.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.MaroonWashed
        Me.BtnTablasFamilias.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.BtnTablasFamilias.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(124, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(144, Byte), Integer))
        Me.BtnTablasFamilias.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(124, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(144, Byte), Integer))
        Me.BtnTablasFamilias.TileStyle.BackColorGradientAngle = 45
        Me.BtnTablasFamilias.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(124, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(144, Byte), Integer))
        Me.BtnTablasFamilias.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(124, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(144, Byte), Integer))
        Me.BtnTablasFamilias.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.BtnTablasFamilias.TileStyle.PaddingBottom = 4
        Me.BtnTablasFamilias.TileStyle.PaddingLeft = 4
        Me.BtnTablasFamilias.TileStyle.PaddingRight = 4
        Me.BtnTablasFamilias.TileStyle.PaddingTop = 4
        Me.BtnTablasFamilias.TileStyle.TextColor = System.Drawing.Color.White
        Me.BtnTablasFamilias.TitleText = "BakApp"
        '
        'Btn_Zonas
        '
        Me.Btn_Zonas.Image = CType(resources.GetObject("Btn_Zonas.Image"), System.Drawing.Image)
        Me.Btn_Zonas.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Zonas.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Zonas.Name = "Btn_Zonas"
        Me.Btn_Zonas.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Zonas.Text = "<font size=""+4""><b>ZONAS</b></font><br/><font size=""-1"">Mantención de zonas.</fon" & _
            "t>"
        Me.Btn_Zonas.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.RedOrange
        Me.Btn_Zonas.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Zonas.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_Zonas.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_Zonas.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Zonas.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_Zonas.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_Zonas.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Zonas.TileStyle.PaddingBottom = 4
        Me.Btn_Zonas.TileStyle.PaddingLeft = 4
        Me.Btn_Zonas.TileStyle.PaddingRight = 4
        Me.Btn_Zonas.TileStyle.PaddingTop = 4
        Me.Btn_Zonas.TileStyle.TextColor = System.Drawing.Color.WhiteSmoke
        Me.Btn_Zonas.TitleText = "BakApp"
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.LabelX1.Location = New System.Drawing.Point(3, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(392, 49)
        Me.LabelX1.TabIndex = 49
        Me.LabelX1.Text = "<font color=""#349FCE""><b>PARAMETROS PRODUCTOS</b></font>"
        '
        'Tablas_Clasificaciones_Pro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.Name = "Tablas_Clasificaciones_Pro"
        Me.Size = New System.Drawing.Size(636, 331)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents ContenedorTablas As DevComponents.DotNetBar.ItemContainer
    Private WithEvents Btn_Clasificacion_Libre As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Marcas As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents BtnTablasFamilias As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Arbol_Clasificaciones As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Rubros As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Zonas As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents Btn_Actualizar_Tablas_BakApp As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX

End Class
