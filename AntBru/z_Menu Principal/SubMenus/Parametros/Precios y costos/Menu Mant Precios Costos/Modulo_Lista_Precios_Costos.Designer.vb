<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Modulo_Lista_Precios_Costos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Modulo_Lista_Precios_Costos))
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem()
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel()
        Me.MnuEspecialPrecios = New DevComponents.DotNetBar.ItemContainer()
        Me.Btn_Listas_de_precios = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Listas_Proveedores = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.BtnConfListas = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Listas_de_costos = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.MetroTileItem1 = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.MetroTileItem2 = New DevComponents.DotNetBar.Metro.MetroTileItem()
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
        Me.Bar2.Location = New System.Drawing.Point(0, 297)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(646, 41)
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
        Me.MetroTilePanel1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.MnuEspecialPrecios})
        Me.MetroTilePanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MetroTilePanel1.Location = New System.Drawing.Point(3, 58)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(885, 405)
        Me.MetroTilePanel1.TabIndex = 33
        Me.MetroTilePanel1.Text = "MetroTilePanel1"
        '
        'MnuEspecialPrecios
        '
        '
        '
        '
        Me.MnuEspecialPrecios.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MnuEspecialPrecios.FixedSize = New System.Drawing.Size(650, 220)
        Me.MnuEspecialPrecios.MultiLine = True
        Me.MnuEspecialPrecios.Name = "MnuEspecialPrecios"
        Me.MnuEspecialPrecios.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Listas_de_precios, Me.Btn_Listas_Proveedores, Me.BtnConfListas, Me.Btn_Listas_de_costos, Me.MetroTileItem1, Me.MetroTileItem2})
        '
        '
        '
        Me.MnuEspecialPrecios.TitleStyle.Class = "MetroTileGroupTitle"
        Me.MnuEspecialPrecios.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'Btn_Listas_de_precios
        '
        Me.Btn_Listas_de_precios.Image = CType(resources.GetObject("Btn_Listas_de_precios.Image"), System.Drawing.Image)
        Me.Btn_Listas_de_precios.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Listas_de_precios.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Listas_de_precios.Name = "Btn_Listas_de_precios"
        Me.Btn_Listas_de_precios.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Listas_de_precios.Text = "<font size=""+4""><b>LISTAS DE PRECIOS</b></font><br/><font size=""-1"">Mantención de" &
    " lista de precios especial del sistema</font>"
        Me.Btn_Listas_de_precios.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Blue
        Me.Btn_Listas_de_precios.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Listas_de_precios.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Listas_de_precios.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Listas_de_precios.TileStyle.PaddingBottom = 4
        Me.Btn_Listas_de_precios.TileStyle.PaddingLeft = 4
        Me.Btn_Listas_de_precios.TileStyle.PaddingRight = 4
        Me.Btn_Listas_de_precios.TileStyle.PaddingTop = 4
        Me.Btn_Listas_de_precios.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Listas_de_precios.TitleText = "Bakapp"
        '
        'Btn_Listas_Proveedores
        '
        Me.Btn_Listas_Proveedores.Image = CType(resources.GetObject("Btn_Listas_Proveedores.Image"), System.Drawing.Image)
        Me.Btn_Listas_Proveedores.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Listas_Proveedores.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Listas_Proveedores.Name = "Btn_Listas_Proveedores"
        Me.Btn_Listas_Proveedores.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Listas_Proveedores.Text = "<font size=""+4""><b>LISTAS DE PROVEEDORES</b></font><br/><font size=""-1"">Mantenció" &
    "n de lista de precios por proveedor del sistema</font>"
        Me.Btn_Listas_Proveedores.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Yellowish
        Me.Btn_Listas_Proveedores.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Listas_Proveedores.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Listas_Proveedores.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Listas_Proveedores.TileStyle.PaddingBottom = 4
        Me.Btn_Listas_Proveedores.TileStyle.PaddingLeft = 4
        Me.Btn_Listas_Proveedores.TileStyle.PaddingRight = 4
        Me.Btn_Listas_Proveedores.TileStyle.PaddingTop = 4
        Me.Btn_Listas_Proveedores.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Listas_Proveedores.TitleText = "Bakapp"
        '
        'BtnConfListas
        '
        Me.BtnConfListas.Image = CType(resources.GetObject("BtnConfListas.Image"), System.Drawing.Image)
        Me.BtnConfListas.ImageIndent = New System.Drawing.Point(8, -10)
        Me.BtnConfListas.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnConfListas.Name = "BtnConfListas"
        Me.BtnConfListas.SymbolColor = System.Drawing.Color.Empty
        Me.BtnConfListas.Text = "<font size=""+4""><b>CONFIGURACION DE LISTAS</b></font><br/><font size=""-1"">Crear, " &
    "Editar listas de precios y sus funciones</font>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.BtnConfListas.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.MaroonWashed
        Me.BtnConfListas.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.BtnConfListas.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(123, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(144, Byte), Integer))
        Me.BtnConfListas.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(123, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(144, Byte), Integer))
        Me.BtnConfListas.TileStyle.BackColorGradientAngle = 45
        Me.BtnConfListas.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(123, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(144, Byte), Integer))
        Me.BtnConfListas.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(123, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(144, Byte), Integer))
        Me.BtnConfListas.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.BtnConfListas.TileStyle.PaddingBottom = 4
        Me.BtnConfListas.TileStyle.PaddingLeft = 4
        Me.BtnConfListas.TileStyle.PaddingRight = 4
        Me.BtnConfListas.TileStyle.PaddingTop = 4
        Me.BtnConfListas.TileStyle.TextColor = System.Drawing.Color.White
        Me.BtnConfListas.TitleText = "Bakapp"
        '
        'Btn_Listas_de_costos
        '
        Me.Btn_Listas_de_costos.Image = CType(resources.GetObject("Btn_Listas_de_costos.Image"), System.Drawing.Image)
        Me.Btn_Listas_de_costos.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Listas_de_costos.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Listas_de_costos.Name = "Btn_Listas_de_costos"
        Me.Btn_Listas_de_costos.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Listas_de_costos.Text = "<font size=""+4""><b>LISTAS DE COSTOS</b></font><br/><font size=""-1"">Mantención de " &
    "lista de precios especial del sistema</font>"
        Me.Btn_Listas_de_costos.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Blue
        Me.Btn_Listas_de_costos.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Listas_de_costos.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_Listas_de_costos.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_Listas_de_costos.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Listas_de_costos.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_Listas_de_costos.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_Listas_de_costos.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Listas_de_costos.TileStyle.PaddingBottom = 4
        Me.Btn_Listas_de_costos.TileStyle.PaddingLeft = 4
        Me.Btn_Listas_de_costos.TileStyle.PaddingRight = 4
        Me.Btn_Listas_de_costos.TileStyle.PaddingTop = 4
        Me.Btn_Listas_de_costos.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Listas_de_costos.TitleText = "Bakapp"
        '
        'MetroTileItem1
        '
        Me.MetroTileItem1.Image = CType(resources.GetObject("MetroTileItem1.Image"), System.Drawing.Image)
        Me.MetroTileItem1.ImageIndent = New System.Drawing.Point(8, -10)
        Me.MetroTileItem1.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.MetroTileItem1.Name = "MetroTileItem1"
        Me.MetroTileItem1.SymbolColor = System.Drawing.Color.Empty
        Me.MetroTileItem1.Text = "<font size=""+4""><b>LISTA LC</b></font><br/><font size=""-1"">Crear, Editar listas d" &
    "e precios y sus funciones</font>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.MetroTileItem1.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.MaroonWashed
        Me.MetroTileItem1.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.MetroTileItem1.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(123, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(144, Byte), Integer))
        Me.MetroTileItem1.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(123, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(144, Byte), Integer))
        Me.MetroTileItem1.TileStyle.BackColorGradientAngle = 45
        Me.MetroTileItem1.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(123, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(144, Byte), Integer))
        Me.MetroTileItem1.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(123, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(144, Byte), Integer))
        Me.MetroTileItem1.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.MetroTileItem1.TileStyle.PaddingBottom = 4
        Me.MetroTileItem1.TileStyle.PaddingLeft = 4
        Me.MetroTileItem1.TileStyle.PaddingRight = 4
        Me.MetroTileItem1.TileStyle.PaddingTop = 4
        Me.MetroTileItem1.TileStyle.TextColor = System.Drawing.Color.White
        Me.MetroTileItem1.TitleText = "Bakapp"
        '
        'MetroTileItem2
        '
        Me.MetroTileItem2.Image = CType(resources.GetObject("MetroTileItem2.Image"), System.Drawing.Image)
        Me.MetroTileItem2.ImageIndent = New System.Drawing.Point(8, -10)
        Me.MetroTileItem2.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.MetroTileItem2.Name = "MetroTileItem2"
        Me.MetroTileItem2.SymbolColor = System.Drawing.Color.Empty
        Me.MetroTileItem2.Text = "<font size=""+4"">Ult. recepciones</font><br/><font size=""-1"">Revisar recepciones y" &
    " actualizar costos de forma directa<br/> (Lista LC)</font>"
        Me.MetroTileItem2.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.MaroonWashed
        Me.MetroTileItem2.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.MetroTileItem2.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(123, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(144, Byte), Integer))
        Me.MetroTileItem2.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(123, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(144, Byte), Integer))
        Me.MetroTileItem2.TileStyle.BackColorGradientAngle = 45
        Me.MetroTileItem2.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(123, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(144, Byte), Integer))
        Me.MetroTileItem2.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(123, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(144, Byte), Integer))
        Me.MetroTileItem2.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.MetroTileItem2.TileStyle.PaddingBottom = 4
        Me.MetroTileItem2.TileStyle.PaddingLeft = 4
        Me.MetroTileItem2.TileStyle.PaddingRight = 4
        Me.MetroTileItem2.TileStyle.PaddingTop = 4
        Me.MetroTileItem2.TileStyle.TextColor = System.Drawing.Color.White
        Me.MetroTileItem2.TitleText = "Bakapp"
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
        Me.LabelX1.Size = New System.Drawing.Size(596, 49)
        Me.LabelX1.TabIndex = 54
        Me.LabelX1.Text = "<font color=""#349FCE""><b>MANTENCION DE LISTAS DE PRECIOS Y COSTOS</b></font>"
        '
        'Modulo_Lista_Precios_Costos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.Name = "Modulo_Lista_Precios_Costos"
        Me.Size = New System.Drawing.Size(646, 338)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents MnuEspecialPrecios As DevComponents.DotNetBar.ItemContainer
    Private WithEvents BtnConfListas As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Listas_de_precios As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Listas_Proveedores As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Private WithEvents Btn_Listas_de_costos As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents MetroTileItem1 As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents MetroTileItem2 As DevComponents.DotNetBar.Metro.MetroTileItem
End Class
