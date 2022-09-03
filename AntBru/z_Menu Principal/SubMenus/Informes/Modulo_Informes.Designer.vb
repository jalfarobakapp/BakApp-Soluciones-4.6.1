<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Modulo_Informes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Modulo_Informes))
        Me.Bar2 = New DevComponents.DotNetBar.Bar
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel
        Me.ConsultaPreciosContenedor = New DevComponents.DotNetBar.ItemContainer
        Me.BtnInformesVenta = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.BtnInfMargenes = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.Btn_Informes_Espciales_Clientes = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.Btn_Inf_Stock = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSalir})
        Me.Bar2.Location = New System.Drawing.Point(0, 278)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(436, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 37
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
        Me.MetroTilePanel1.Size = New System.Drawing.Size(489, 407)
        Me.MetroTilePanel1.TabIndex = 36
        Me.MetroTilePanel1.Text = "MetroTilePanel1"
        '
        'ConsultaPreciosContenedor
        '
        '
        '
        '
        Me.ConsultaPreciosContenedor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ConsultaPreciosContenedor.FixedSize = New System.Drawing.Size(500, 200)
        Me.ConsultaPreciosContenedor.MultiLine = True
        Me.ConsultaPreciosContenedor.Name = "ConsultaPreciosContenedor"
        Me.ConsultaPreciosContenedor.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnInformesVenta, Me.BtnInfMargenes, Me.Btn_Informes_Espciales_Clientes, Me.Btn_Inf_Stock})
        '
        '
        '
        Me.ConsultaPreciosContenedor.TitleStyle.Class = "MetroTileGroupTitle"
        Me.ConsultaPreciosContenedor.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ConsultaPreciosContenedor.TitleStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'BtnInformesVenta
        '
        Me.BtnInformesVenta.Image = CType(resources.GetObject("BtnInformesVenta.Image"), System.Drawing.Image)
        Me.BtnInformesVenta.ImageIndent = New System.Drawing.Point(8, -10)
        Me.BtnInformesVenta.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnInformesVenta.Name = "BtnInformesVenta"
        Me.BtnInformesVenta.SymbolColor = System.Drawing.Color.Empty
        Me.BtnInformesVenta.Text = "<font size=""+4""><b>INFORMES DE VENTA</b></font><br/><font size=""-1""></font>"
        Me.BtnInformesVenta.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green
        Me.BtnInformesVenta.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.BtnInformesVenta.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnInformesVenta.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnInformesVenta.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnInformesVenta.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnInformesVenta.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.BtnInformesVenta.TileStyle.TextColor = System.Drawing.Color.White
        Me.BtnInformesVenta.TitleText = "BakApp"
        '
        'BtnInfMargenes
        '
        Me.BtnInfMargenes.Image = CType(resources.GetObject("BtnInfMargenes.Image"), System.Drawing.Image)
        Me.BtnInfMargenes.ImageIndent = New System.Drawing.Point(8, -10)
        Me.BtnInfMargenes.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnInfMargenes.Name = "BtnInfMargenes"
        Me.BtnInfMargenes.SymbolColor = System.Drawing.Color.Empty
        Me.BtnInfMargenes.Text = "<font size=""+4""><b>INFORMES DE COMPRA</b></font>"
        Me.BtnInfMargenes.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.BtnInfMargenes.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.BtnInfMargenes.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.BtnInfMargenes.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.BtnInfMargenes.TileStyle.BackColorGradientAngle = 45
        Me.BtnInfMargenes.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.BtnInfMargenes.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.BtnInfMargenes.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.BtnInfMargenes.TileStyle.PaddingBottom = 4
        Me.BtnInfMargenes.TileStyle.PaddingLeft = 4
        Me.BtnInfMargenes.TileStyle.PaddingRight = 4
        Me.BtnInfMargenes.TileStyle.PaddingTop = 4
        Me.BtnInfMargenes.TileStyle.TextColor = System.Drawing.Color.White
        Me.BtnInfMargenes.TitleText = "BakApp"
        '
        'Btn_Informes_Espciales_Clientes
        '
        Me.Btn_Informes_Espciales_Clientes.Image = CType(resources.GetObject("Btn_Informes_Espciales_Clientes.Image"), System.Drawing.Image)
        Me.Btn_Informes_Espciales_Clientes.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Informes_Espciales_Clientes.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Informes_Espciales_Clientes.Name = "Btn_Informes_Espciales_Clientes"
        Me.Btn_Informes_Espciales_Clientes.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Informes_Espciales_Clientes.Text = "<font size=""+4""><b>ESPECIAL CLIENTES</b></font>"
        Me.Btn_Informes_Espciales_Clientes.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.Btn_Informes_Espciales_Clientes.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Informes_Espciales_Clientes.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.Btn_Informes_Espciales_Clientes.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.Btn_Informes_Espciales_Clientes.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Informes_Espciales_Clientes.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.Btn_Informes_Espciales_Clientes.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.Btn_Informes_Espciales_Clientes.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Informes_Espciales_Clientes.TileStyle.PaddingBottom = 4
        Me.Btn_Informes_Espciales_Clientes.TileStyle.PaddingLeft = 4
        Me.Btn_Informes_Espciales_Clientes.TileStyle.PaddingRight = 4
        Me.Btn_Informes_Espciales_Clientes.TileStyle.PaddingTop = 4
        Me.Btn_Informes_Espciales_Clientes.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Informes_Espciales_Clientes.TitleText = "BakApp"
        Me.Btn_Informes_Espciales_Clientes.Visible = False
        '
        'Btn_Inf_Stock
        '
        Me.Btn_Inf_Stock.Image = CType(resources.GetObject("Btn_Inf_Stock.Image"), System.Drawing.Image)
        Me.Btn_Inf_Stock.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Inf_Stock.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Inf_Stock.Name = "Btn_Inf_Stock"
        Me.Btn_Inf_Stock.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Inf_Stock.Text = "<font size=""+4""><b>INFORMES DE STOCK</b></font><br/><font size=""-1"">Stock Valoriz" & _
            "ado</font>"
        Me.Btn_Inf_Stock.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.RedOrange
        Me.Btn_Inf_Stock.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Inf_Stock.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.Btn_Inf_Stock.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.Btn_Inf_Stock.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.Btn_Inf_Stock.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.Btn_Inf_Stock.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Inf_Stock.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Inf_Stock.TitleText = "BakApp"
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
        Me.LabelX1.Text = "<font color=""#349FCE""><b>INFORMES</b></font>"
        '
        'Modulo_Informes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.Name = "Modulo_Informes"
        Me.Size = New System.Drawing.Size(436, 319)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents ConsultaPreciosContenedor As DevComponents.DotNetBar.ItemContainer
    Private WithEvents BtnInformesVenta As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents BtnInfMargenes As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Informes_Espciales_Clientes As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Inf_Stock As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX

End Class
