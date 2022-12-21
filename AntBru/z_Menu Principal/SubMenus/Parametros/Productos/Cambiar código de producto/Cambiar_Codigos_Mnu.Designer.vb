<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cambiar_Codigos_Mnu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cambiar_Codigos_Mnu))
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem()
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel()
        Me.ItemContainer1 = New DevComponents.DotNetBar.ItemContainer()
        Me.Btn_Cambio_UnoxUno = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Cambio_Masivo = New DevComponents.DotNetBar.Metro.MetroTileItem()
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
        Me.Bar2.Location = New System.Drawing.Point(0, 200)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(441, 41)
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
        Me.MetroTilePanel1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer1})
        Me.MetroTilePanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MetroTilePanel1.Location = New System.Drawing.Point(3, 57)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(636, 393)
        Me.MetroTilePanel1.TabIndex = 32
        Me.MetroTilePanel1.Text = "MetroTilePanel1"
        '
        'ItemContainer1
        '
        '
        '
        '
        Me.ItemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer1.FixedSize = New System.Drawing.Size(600, 300)
        Me.ItemContainer1.MultiLine = True
        Me.ItemContainer1.Name = "ItemContainer1"
        Me.ItemContainer1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Cambio_UnoxUno, Me.Btn_Cambio_Masivo})
        '
        '
        '
        Me.ItemContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer1.TitleStyle.Font = New System.Drawing.Font("Comic Sans MS", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ItemContainer1.TitleStyle.TextColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(66, Byte), Integer))
        '
        'Btn_Cambio_UnoxUno
        '
        Me.Btn_Cambio_UnoxUno.Image = CType(resources.GetObject("Btn_Cambio_UnoxUno.Image"), System.Drawing.Image)
        Me.Btn_Cambio_UnoxUno.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Cambio_UnoxUno.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Cambio_UnoxUno.Name = "Btn_Cambio_UnoxUno"
        Me.Btn_Cambio_UnoxUno.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Cambio_UnoxUno.Text = "<font size=""+4""><b>UNO x UNO</b></font><br/>Compra Cambiar el código de un produc" &
    "to a la vez" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Btn_Cambio_UnoxUno.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Blue
        Me.Btn_Cambio_UnoxUno.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Cambio_UnoxUno.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Cambio_UnoxUno.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Cambio_UnoxUno.TileStyle.PaddingBottom = 4
        Me.Btn_Cambio_UnoxUno.TileStyle.PaddingLeft = 4
        Me.Btn_Cambio_UnoxUno.TileStyle.PaddingRight = 4
        Me.Btn_Cambio_UnoxUno.TileStyle.PaddingTop = 4
        Me.Btn_Cambio_UnoxUno.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Cambio_UnoxUno.TitleText = "Bakapp"
        '
        'Btn_Cambio_Masivo
        '
        Me.Btn_Cambio_Masivo.Image = CType(resources.GetObject("Btn_Cambio_Masivo.Image"), System.Drawing.Image)
        Me.Btn_Cambio_Masivo.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Cambio_Masivo.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Cambio_Masivo.Name = "Btn_Cambio_Masivo"
        Me.Btn_Cambio_Masivo.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Cambio_Masivo.Text = "<font size=""+4""><b>MASIVAMENTE</b></font><br/>Cambio de código de productos en fo" &
    "rma masiva."
        Me.Btn_Cambio_Masivo.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Blue
        Me.Btn_Cambio_Masivo.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Cambio_Masivo.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_Cambio_Masivo.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_Cambio_Masivo.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Cambio_Masivo.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_Cambio_Masivo.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_Cambio_Masivo.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Cambio_Masivo.TileStyle.PaddingBottom = 4
        Me.Btn_Cambio_Masivo.TileStyle.PaddingLeft = 4
        Me.Btn_Cambio_Masivo.TileStyle.PaddingRight = 4
        Me.Btn_Cambio_Masivo.TileStyle.PaddingTop = 4
        Me.Btn_Cambio_Masivo.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Cambio_Masivo.TitleText = "Bakapp"
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.LabelX1.Location = New System.Drawing.Point(3, 0)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(438, 49)
        Me.LabelX1.TabIndex = 55
        Me.LabelX1.Text = "<font color=""#349FCE""><b>CAMBIAR CODIGOS DE PRODUCTOS</b></font>"
        '
        'Cambiar_Codigos_Mnu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.Name = "Cambiar_Codigos_Mnu"
        Me.Size = New System.Drawing.Size(441, 241)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents ItemContainer1 As DevComponents.DotNetBar.ItemContainer
    Private WithEvents Btn_Cambio_UnoxUno As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Cambio_Masivo As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
End Class
