<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SolAsisCompraModos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SolAsisCompraModos))
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem()
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel()
        Me.ItemContainer1 = New DevComponents.DotNetBar.ItemContainer()
        Me.Btn_Modo_OCC = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Modo_NVI = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.ButtonItem2 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem3 = New DevComponents.DotNetBar.ButtonItem()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.LabelX1.Location = New System.Drawing.Point(3, 2)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(383, 49)
        Me.LabelX1.TabIndex = 37
        Me.LabelX1.Text = "<font color=""#349FCE""><b>DOCUMENTOS DE COMPRAS</b></font>"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSalir, Me.ButtonItem2, Me.ButtonItem3})
        Me.Bar2.Location = New System.Drawing.Point(0, 190)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(437, 41)
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
        Me.MetroTilePanel1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer1})
        Me.MetroTilePanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MetroTilePanel1.Location = New System.Drawing.Point(3, 56)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(552, 376)
        Me.MetroTilePanel1.TabIndex = 35
        Me.MetroTilePanel1.Text = "MetroTilePanel1"
        '
        'ItemContainer1
        '
        '
        '
        '
        Me.ItemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer1.FixedSize = New System.Drawing.Size(500, 250)
        Me.ItemContainer1.MultiLine = True
        Me.ItemContainer1.Name = "ItemContainer1"
        Me.ItemContainer1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Modo_OCC, Me.Btn_Modo_NVI})
        '
        '
        '
        Me.ItemContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer1.TitleStyle.Font = New System.Drawing.Font("Comic Sans MS", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ItemContainer1.TitleStyle.TextColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(66, Byte), Integer))
        '
        'Btn_Modo_OCC
        '
        Me.Btn_Modo_OCC.Image = CType(resources.GetObject("Btn_Modo_OCC.Image"), System.Drawing.Image)
        Me.Btn_Modo_OCC.ImageIndent = New System.Drawing.Point(9, -10)
        Me.Btn_Modo_OCC.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Modo_OCC.Name = "Btn_Modo_OCC"
        Me.Btn_Modo_OCC.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Modo_OCC.Text = "<font size=""+4""><b>ORDEN DE COMPRA. OCC</b></font><br/>Estudio para generar orden" &
    "es de compra"
        Me.Btn_Modo_OCC.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Azure
        Me.Btn_Modo_OCC.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Modo_OCC.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_Modo_OCC.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_Modo_OCC.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_Modo_OCC.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_Modo_OCC.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Modo_OCC.TileStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        '
        'Btn_Modo_NVI
        '
        Me.Btn_Modo_NVI.Image = CType(resources.GetObject("Btn_Modo_NVI.Image"), System.Drawing.Image)
        Me.Btn_Modo_NVI.ImageIndent = New System.Drawing.Point(9, -10)
        Me.Btn_Modo_NVI.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Modo_NVI.Name = "Btn_Modo_NVI"
        Me.Btn_Modo_NVI.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Modo_NVI.Text = "<font size=""+4""><b>PEDIDO INTERNO. NVI</b></font><br/>Estudio para generar solici" &
    "tud entre sucursales y bodegas"
        Me.Btn_Modo_NVI.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green
        Me.Btn_Modo_NVI.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Modo_NVI.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(118, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Btn_Modo_NVI.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(118, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Btn_Modo_NVI.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(118, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Btn_Modo_NVI.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(118, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Btn_Modo_NVI.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Modo_NVI.TileStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        '
        'ButtonItem2
        '
        Me.ButtonItem2.ForeColor = System.Drawing.Color.Black
        Me.ButtonItem2.Name = "ButtonItem2"
        Me.ButtonItem2.Text = "Conf. OCC"
        Me.ButtonItem2.Visible = False
        '
        'ButtonItem3
        '
        Me.ButtonItem3.ForeColor = System.Drawing.Color.Black
        Me.ButtonItem3.Name = "ButtonItem3"
        Me.ButtonItem3.Text = "Conf. NVI"
        Me.ButtonItem3.Visible = False
        '
        'SolAsisCompraModos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.Name = "SolAsisCompraModos"
        Me.Size = New System.Drawing.Size(437, 231)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents ItemContainer1 As DevComponents.DotNetBar.ItemContainer
    Private WithEvents Btn_Modo_OCC As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Modo_NVI As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents ButtonItem2 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem3 As DevComponents.DotNetBar.ButtonItem
End Class
