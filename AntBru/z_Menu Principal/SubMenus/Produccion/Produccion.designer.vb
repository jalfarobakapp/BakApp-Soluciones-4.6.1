<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Produccion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Produccion))
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem()
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel()
        Me.ContenedorTablas = New DevComponents.DotNetBar.ItemContainer()
        Me.Btn_DFA = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Imprimir_Hoja_Ruta = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Informes = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Mesones = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.MetroTileItem1 = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.MetroTileItem2 = New DevComponents.DotNetBar.Metro.MetroTileItem()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Location = New System.Drawing.Point(3, 3)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(244, 50)
        Me.ReflectionLabel1.TabIndex = 37
        Me.ReflectionLabel1.Text = "<b><font size=""+8"" color=""#349FCE"">PRODUCCION</font></b>"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSalir})
        Me.Bar2.Location = New System.Drawing.Point(0, 296)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(645, 41)
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
        Me.MetroTilePanel1.Location = New System.Drawing.Point(6, 59)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(859, 395)
        Me.MetroTilePanel1.TabIndex = 35
        Me.MetroTilePanel1.Text = "MetroTilePanel1"
        '
        'ContenedorTablas
        '
        '
        '
        '
        Me.ContenedorTablas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ContenedorTablas.FixedSize = New System.Drawing.Size(750, 300)
        Me.ContenedorTablas.MultiLine = True
        Me.ContenedorTablas.Name = "ContenedorTablas"
        Me.ContenedorTablas.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_DFA, Me.Btn_Imprimir_Hoja_Ruta, Me.Btn_Informes, Me.Btn_Mesones, Me.MetroTileItem1})
        '
        '
        '
        Me.ContenedorTablas.TitleStyle.Class = "MetroTileGroupTitle"
        Me.ContenedorTablas.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'Btn_DFA
        '
        Me.Btn_DFA.Image = CType(resources.GetObject("Btn_DFA.Image"), System.Drawing.Image)
        Me.Btn_DFA.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_DFA.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_DFA.Name = "Btn_DFA"
        Me.Btn_DFA.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_DFA.Text = "<font size=""+4""><b>DFA</b></font><br/><font size=""-1"">Datos de fabricación</font>" &
    ""
        Me.Btn_DFA.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.RedViolet
        Me.Btn_DFA.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_DFA.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Btn_DFA.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Btn_DFA.TileStyle.BackColorGradientAngle = 45
        Me.Btn_DFA.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Btn_DFA.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Btn_DFA.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_DFA.TileStyle.PaddingBottom = 4
        Me.Btn_DFA.TileStyle.PaddingLeft = 4
        Me.Btn_DFA.TileStyle.PaddingRight = 4
        Me.Btn_DFA.TileStyle.PaddingTop = 4
        Me.Btn_DFA.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_DFA.TitleText = "BakApp"
        '
        'Btn_Imprimir_Hoja_Ruta
        '
        Me.Btn_Imprimir_Hoja_Ruta.Image = CType(resources.GetObject("Btn_Imprimir_Hoja_Ruta.Image"), System.Drawing.Image)
        Me.Btn_Imprimir_Hoja_Ruta.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Imprimir_Hoja_Ruta.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Imprimir_Hoja_Ruta.Name = "Btn_Imprimir_Hoja_Ruta"
        Me.Btn_Imprimir_Hoja_Ruta.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Imprimir_Hoja_Ruta.Text = "<font size=""+4""><b>HOJA RUTA</b></font><br/><font size=""-1"">Imprimir hoja de ruta" &
    " por Sub-OT</font>"
        Me.Btn_Imprimir_Hoja_Ruta.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Yellow
        Me.Btn_Imprimir_Hoja_Ruta.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Imprimir_Hoja_Ruta.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Btn_Imprimir_Hoja_Ruta.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Btn_Imprimir_Hoja_Ruta.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Imprimir_Hoja_Ruta.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Btn_Imprimir_Hoja_Ruta.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Btn_Imprimir_Hoja_Ruta.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Imprimir_Hoja_Ruta.TileStyle.PaddingBottom = 4
        Me.Btn_Imprimir_Hoja_Ruta.TileStyle.PaddingLeft = 4
        Me.Btn_Imprimir_Hoja_Ruta.TileStyle.PaddingRight = 4
        Me.Btn_Imprimir_Hoja_Ruta.TileStyle.PaddingTop = 4
        Me.Btn_Imprimir_Hoja_Ruta.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Imprimir_Hoja_Ruta.TitleText = "BakApp"
        '
        'Btn_Informes
        '
        Me.Btn_Informes.Image = CType(resources.GetObject("Btn_Informes.Image"), System.Drawing.Image)
        Me.Btn_Informes.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Informes.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Informes.Name = "Btn_Informes"
        Me.Btn_Informes.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Informes.Text = "<font size=""+4""><b>INFORMES</b></font><br/><font size=""-1"">Informes especiales de" &
    "l sistema.</font>"
        Me.Btn_Informes.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.DarkBlue
        Me.Btn_Informes.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Informes.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Informes.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Informes.TileStyle.PaddingBottom = 4
        Me.Btn_Informes.TileStyle.PaddingLeft = 4
        Me.Btn_Informes.TileStyle.PaddingRight = 4
        Me.Btn_Informes.TileStyle.PaddingTop = 4
        Me.Btn_Informes.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Informes.TitleText = "BakApp"
        '
        'Btn_Mesones
        '
        Me.Btn_Mesones.Image = CType(resources.GetObject("Btn_Mesones.Image"), System.Drawing.Image)
        Me.Btn_Mesones.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Mesones.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Mesones.Name = "Btn_Mesones"
        Me.Btn_Mesones.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Mesones.Text = "<font size=""+4""><b>SIST. DE MESONES FABRICACION</b></font><br/><font size=""-1"">Cr" &
    "eación y Modificación de Mesones de Trabajo</font>"
        Me.Btn_Mesones.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Yellow
        Me.Btn_Mesones.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Mesones.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(18, Byte), Integer))
        Me.Btn_Mesones.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(18, Byte), Integer))
        Me.Btn_Mesones.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Mesones.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(18, Byte), Integer))
        Me.Btn_Mesones.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(18, Byte), Integer))
        Me.Btn_Mesones.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Mesones.TileStyle.PaddingBottom = 4
        Me.Btn_Mesones.TileStyle.PaddingLeft = 4
        Me.Btn_Mesones.TileStyle.PaddingRight = 4
        Me.Btn_Mesones.TileStyle.PaddingTop = 4
        Me.Btn_Mesones.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Mesones.TitleText = "BakApp"
        '
        'MetroTileItem1
        '
        Me.MetroTileItem1.Image = CType(resources.GetObject("MetroTileItem1.Image"), System.Drawing.Image)
        Me.MetroTileItem1.ImageIndent = New System.Drawing.Point(8, -10)
        Me.MetroTileItem1.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.MetroTileItem1.Name = "MetroTileItem1"
        Me.MetroTileItem1.SymbolColor = System.Drawing.Color.Empty
        Me.MetroTileItem1.Text = "<font size=""+4""><b>SIS. MESONES SERV. TEC." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "</b></font><br/><font size=""-1"">Creac" &
    "ión y Modificación de Mesones de Trabajo</font>"
        Me.MetroTileItem1.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Yellow
        Me.MetroTileItem1.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.MetroTileItem1.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.MetroTileItem1.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.MetroTileItem1.TileStyle.BackColorGradientAngle = 45
        Me.MetroTileItem1.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.MetroTileItem1.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.MetroTileItem1.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.MetroTileItem1.TileStyle.PaddingBottom = 4
        Me.MetroTileItem1.TileStyle.PaddingLeft = 4
        Me.MetroTileItem1.TileStyle.PaddingRight = 4
        Me.MetroTileItem1.TileStyle.PaddingTop = 4
        Me.MetroTileItem1.TileStyle.TextColor = System.Drawing.Color.White
        Me.MetroTileItem1.TitleText = "BakApp"
        '
        'MetroTileItem2
        '
        Me.MetroTileItem2.Image = CType(resources.GetObject("MetroTileItem2.Image"), System.Drawing.Image)
        Me.MetroTileItem2.ImageIndent = New System.Drawing.Point(8, -10)
        Me.MetroTileItem2.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.MetroTileItem2.Name = "MetroTileItem2"
        Me.MetroTileItem2.SymbolColor = System.Drawing.Color.Empty
        Me.MetroTileItem2.Text = "<font size=""+4""><b>MESONES DE TRABAJO</b></font><br/><font size=""-1"">Asignación d" &
    "e OT y Productos a Mesones de Trabajo</font>"
        Me.MetroTileItem2.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.RedViolet
        Me.MetroTileItem2.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.MetroTileItem2.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.MetroTileItem2.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.MetroTileItem2.TileStyle.BackColorGradientAngle = 45
        Me.MetroTileItem2.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.MetroTileItem2.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.MetroTileItem2.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.MetroTileItem2.TileStyle.PaddingBottom = 4
        Me.MetroTileItem2.TileStyle.PaddingLeft = 4
        Me.MetroTileItem2.TileStyle.PaddingRight = 4
        Me.MetroTileItem2.TileStyle.PaddingTop = 4
        Me.MetroTileItem2.TileStyle.TextColor = System.Drawing.Color.White
        Me.MetroTileItem2.TitleText = "BakApp"
        '
        'Produccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.Name = "Produccion"
        Me.Size = New System.Drawing.Size(645, 337)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents ContenedorTablas As DevComponents.DotNetBar.ItemContainer
    Private WithEvents Btn_DFA As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Informes As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Imprimir_Hoja_Ruta As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Mesones As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents MetroTileItem2 As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents MetroTileItem1 As DevComponents.DotNetBar.Metro.MetroTileItem
End Class
