<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InformesCompra
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InformesCompra))
        Me.Bar2 = New DevComponents.DotNetBar.Bar
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem
        Me.BtnCambiarDeUsuario = New DevComponents.DotNetBar.ButtonItem
        Me.BtnInfPagoProveedores = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.ItemContainer3 = New DevComponents.DotNetBar.ItemContainer
        Me.BtnRankingProductos = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.MetroTilePanel2 = New DevComponents.DotNetBar.Metro.MetroTilePanel
        Me.MnuEspecialPrecios = New DevComponents.DotNetBar.ItemContainer
        Me.Btn_Proximas_Recepciones = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.Btn_Informe_Vencimiento_Compras = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSalir, Me.BtnCambiarDeUsuario})
        Me.Bar2.Location = New System.Drawing.Point(0, 182)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(434, 41)
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
        '
        'BtnCambiarDeUsuario
        '
        Me.BtnCambiarDeUsuario.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnCambiarDeUsuario.ForeColor = System.Drawing.Color.Black
        Me.BtnCambiarDeUsuario.Image = Global.BakApp.My.Resources.Resources.user_group
        Me.BtnCambiarDeUsuario.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnCambiarDeUsuario.Name = "BtnCambiarDeUsuario"
        Me.BtnCambiarDeUsuario.Tooltip = "Cambiar de usuario"
        '
        'BtnInfPagoProveedores
        '
        Me.BtnInfPagoProveedores.Image = Global.BakApp.My.Resources.Resources.barcode_32
        Me.BtnInfPagoProveedores.ImageIndent = New System.Drawing.Point(8, -6)
        Me.BtnInfPagoProveedores.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnInfPagoProveedores.Name = "BtnInfPagoProveedores"
        Me.BtnInfPagoProveedores.SymbolColor = System.Drawing.Color.Empty
        Me.BtnInfPagoProveedores.Text = "<font size=""+4"">Pago proveedores</font><br/><font size=""-1"">Teneduría de pagos a " & _
            "proveedores<br/> - Informes<br/> - Procesos</font>"
        Me.BtnInfPagoProveedores.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green
        '
        '
        '
        Me.BtnInfPagoProveedores.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.BtnInfPagoProveedores.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.BtnInfPagoProveedores.TileStyle.BackColorGradientAngle = 45
        Me.BtnInfPagoProveedores.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BtnInfPagoProveedores.TileStyle.PaddingBottom = 4
        Me.BtnInfPagoProveedores.TileStyle.PaddingLeft = 4
        Me.BtnInfPagoProveedores.TileStyle.PaddingRight = 4
        Me.BtnInfPagoProveedores.TileStyle.PaddingTop = 4
        Me.BtnInfPagoProveedores.TileStyle.TextColor = System.Drawing.Color.White
        Me.BtnInfPagoProveedores.TitleText = "BakApp"
        '
        'ItemContainer3
        '
        '
        '
        '
        Me.ItemContainer3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer3.FixedSize = New System.Drawing.Size(300, 300)
        Me.ItemContainer3.MultiLine = True
        Me.ItemContainer3.Name = "ItemContainer3"
        Me.ItemContainer3.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnInfPagoProveedores})
        '
        '
        '
        Me.ItemContainer3.TitleStyle.Class = "MetroTileGroupTitle"
        Me.ItemContainer3.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'BtnRankingProductos
        '
        Me.BtnRankingProductos.Image = Global.BakApp.My.Resources.Resources.statistics_32
        Me.BtnRankingProductos.ImageIndent = New System.Drawing.Point(8, -6)
        Me.BtnRankingProductos.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnRankingProductos.Name = "BtnRankingProductos"
        Me.BtnRankingProductos.SymbolColor = System.Drawing.Color.Empty
        Me.BtnRankingProductos.Text = "<font size=""+4"">Ranking de productos</font><br/><font size=""-1"">Ranking de produc" & _
            "tos: " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "- Presencia" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "- Cantidad" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "- Precio</font>"
        Me.BtnRankingProductos.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        '
        '
        '
        Me.BtnRankingProductos.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.BtnRankingProductos.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.BtnRankingProductos.TileStyle.BackColorGradientAngle = 45
        Me.BtnRankingProductos.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BtnRankingProductos.TileStyle.PaddingBottom = 4
        Me.BtnRankingProductos.TileStyle.PaddingLeft = 4
        Me.BtnRankingProductos.TileStyle.PaddingRight = 4
        Me.BtnRankingProductos.TileStyle.PaddingTop = 4
        Me.BtnRankingProductos.TileStyle.TextColor = System.Drawing.Color.White
        Me.BtnRankingProductos.TitleText = "BakApp"
        '
        'MetroTilePanel2
        '
        Me.MetroTilePanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.MetroTilePanel2.BackgroundStyle.Class = "MetroTilePanel"
        Me.MetroTilePanel2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MetroTilePanel2.ContainerControlProcessDialogKey = True
        Me.MetroTilePanel2.DragDropSupport = True
        Me.MetroTilePanel2.ForeColor = System.Drawing.Color.Black
        Me.MetroTilePanel2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.MnuEspecialPrecios})
        Me.MetroTilePanel2.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MetroTilePanel2.Location = New System.Drawing.Point(3, 49)
        Me.MetroTilePanel2.Name = "MetroTilePanel2"
        Me.MetroTilePanel2.Size = New System.Drawing.Size(609, 134)
        Me.MetroTilePanel2.TabIndex = 45
        Me.MetroTilePanel2.Text = "MetroTilePanel2"
        '
        'MnuEspecialPrecios
        '
        '
        '
        '
        Me.MnuEspecialPrecios.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MnuEspecialPrecios.FixedSize = New System.Drawing.Size(430, 210)
        Me.MnuEspecialPrecios.MultiLine = True
        Me.MnuEspecialPrecios.Name = "MnuEspecialPrecios"
        Me.MnuEspecialPrecios.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Proximas_Recepciones, Me.Btn_Informe_Vencimiento_Compras})
        '
        '
        '
        Me.MnuEspecialPrecios.TitleStyle.Class = "MetroTileGroupTitle"
        Me.MnuEspecialPrecios.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'Btn_Proximas_Recepciones
        '
        Me.Btn_Proximas_Recepciones.Image = CType(resources.GetObject("Btn_Proximas_Recepciones.Image"), System.Drawing.Image)
        Me.Btn_Proximas_Recepciones.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Proximas_Recepciones.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Proximas_Recepciones.Name = "Btn_Proximas_Recepciones"
        Me.Btn_Proximas_Recepciones.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Proximas_Recepciones.Text = "<font size=""+4""><b>PROXIMAS RECEPCIONES</b></font><br/><font size=""-1"">Productos " & _
            "pendientes...</font>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Btn_Proximas_Recepciones.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.Btn_Proximas_Recepciones.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Proximas_Recepciones.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(124, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(119, Byte), Integer))
        Me.Btn_Proximas_Recepciones.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(124, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(119, Byte), Integer))
        Me.Btn_Proximas_Recepciones.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Proximas_Recepciones.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(124, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(119, Byte), Integer))
        Me.Btn_Proximas_Recepciones.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(124, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(119, Byte), Integer))
        Me.Btn_Proximas_Recepciones.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Proximas_Recepciones.TileStyle.PaddingBottom = 4
        Me.Btn_Proximas_Recepciones.TileStyle.PaddingLeft = 4
        Me.Btn_Proximas_Recepciones.TileStyle.PaddingRight = 4
        Me.Btn_Proximas_Recepciones.TileStyle.PaddingTop = 4
        Me.Btn_Proximas_Recepciones.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Proximas_Recepciones.TitleText = "Bakapp"
        '
        'Btn_Informe_Vencimiento_Compras
        '
        Me.Btn_Informe_Vencimiento_Compras.Image = CType(resources.GetObject("Btn_Informe_Vencimiento_Compras.Image"), System.Drawing.Image)
        Me.Btn_Informe_Vencimiento_Compras.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Informe_Vencimiento_Compras.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Informe_Vencimiento_Compras.Name = "Btn_Informe_Vencimiento_Compras"
        Me.Btn_Informe_Vencimiento_Compras.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Informe_Vencimiento_Compras.Text = "<font size=""+4""><b>VENCIMIENTOS</b></font><br/><font size=""-1"">Informe vencimient" & _
            "os</font>"
        Me.Btn_Informe_Vencimiento_Compras.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Teal
        Me.Btn_Informe_Vencimiento_Compras.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Informe_Vencimiento_Compras.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Btn_Informe_Vencimiento_Compras.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Btn_Informe_Vencimiento_Compras.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Informe_Vencimiento_Compras.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Btn_Informe_Vencimiento_Compras.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Btn_Informe_Vencimiento_Compras.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Informe_Vencimiento_Compras.TileStyle.PaddingBottom = 4
        Me.Btn_Informe_Vencimiento_Compras.TileStyle.PaddingLeft = 4
        Me.Btn_Informe_Vencimiento_Compras.TileStyle.PaddingRight = 4
        Me.Btn_Informe_Vencimiento_Compras.TileStyle.PaddingTop = 4
        Me.Btn_Informe_Vencimiento_Compras.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Informe_Vencimiento_Compras.TitleText = "Bakapp"
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.LabelX1.Location = New System.Drawing.Point(6, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(323, 49)
        Me.LabelX1.TabIndex = 50
        Me.LabelX1.Text = "<font color=""#349FCE""><b>INFORMES DE COMPRA</b></font>"
        '
        'InformesCompra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.MetroTilePanel2)
        Me.Controls.Add(Me.Bar2)
        Me.Name = "InformesCompra"
        Me.Size = New System.Drawing.Size(434, 223)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Private WithEvents BtnInfPagoProveedores As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents ItemContainer3 As DevComponents.DotNetBar.ItemContainer
    Private WithEvents BtnRankingProductos As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents MetroTilePanel2 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents MnuEspecialPrecios As DevComponents.DotNetBar.ItemContainer
    Private WithEvents Btn_Informe_Vencimiento_Compras As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Proximas_Recepciones As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents BtnCambiarDeUsuario As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX

End Class
