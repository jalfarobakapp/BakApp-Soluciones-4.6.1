<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Sistema_CodBarras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Sistema_CodBarras))
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnConfiguracion = New DevComponents.DotNetBar.ButtonItem()
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel()
        Me.ConsultaPreciosContenedor = New DevComponents.DotNetBar.ItemContainer()
        Me.BtnImpBarras_Producto = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.BtnImpBarras_Documento = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.BtnImpBarras_Ubicaciones = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.BtnCrearCodigosBarra = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSalir, Me.BtnConfiguracion})
        Me.Bar2.Location = New System.Drawing.Point(0, 303)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(633, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 46
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
        'BtnConfiguracion
        '
        Me.BtnConfiguracion.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnConfiguracion.ForeColor = System.Drawing.Color.Black
        Me.BtnConfiguracion.Image = CType(resources.GetObject("BtnConfiguracion.Image"), System.Drawing.Image)
        Me.BtnConfiguracion.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnConfiguracion.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnConfiguracion.Name = "BtnConfiguracion"
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
        Me.MetroTilePanel1.Location = New System.Drawing.Point(3, 61)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(811, 251)
        Me.MetroTilePanel1.TabIndex = 45
        Me.MetroTilePanel1.Text = "MetroTilePanel1"
        '
        'ConsultaPreciosContenedor
        '
        '
        '
        '
        Me.ConsultaPreciosContenedor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ConsultaPreciosContenedor.FixedSize = New System.Drawing.Size(670, 300)
        Me.ConsultaPreciosContenedor.MultiLine = True
        Me.ConsultaPreciosContenedor.Name = "ConsultaPreciosContenedor"
        Me.ConsultaPreciosContenedor.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnImpBarras_Producto, Me.BtnImpBarras_Documento, Me.BtnImpBarras_Ubicaciones, Me.BtnCrearCodigosBarra})
        '
        '
        '
        Me.ConsultaPreciosContenedor.TitleStyle.Class = "MetroTileGroupTitle"
        Me.ConsultaPreciosContenedor.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ConsultaPreciosContenedor.TitleStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'BtnImpBarras_Producto
        '
        Me.BtnImpBarras_Producto.Image = CType(resources.GetObject("BtnImpBarras_Producto.Image"), System.Drawing.Image)
        Me.BtnImpBarras_Producto.ImageIndent = New System.Drawing.Point(8, -10)
        Me.BtnImpBarras_Producto.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnImpBarras_Producto.Name = "BtnImpBarras_Producto"
        Me.BtnImpBarras_Producto.SymbolColor = System.Drawing.Color.Empty
        Me.BtnImpBarras_Producto.Text = "<font size=""+4""><b>X PRODUCTO</b></font><br/><font size=""-1"">imprimir códigos de " &
    "barras según listado</font>"
        Me.BtnImpBarras_Producto.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.BtnImpBarras_Producto.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.BtnImpBarras_Producto.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.BtnImpBarras_Producto.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.BtnImpBarras_Producto.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.BtnImpBarras_Producto.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.BtnImpBarras_Producto.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.BtnImpBarras_Producto.TileStyle.TextColor = System.Drawing.Color.White
        Me.BtnImpBarras_Producto.TitleText = "BakApp"
        '
        'BtnImpBarras_Documento
        '
        Me.BtnImpBarras_Documento.Image = CType(resources.GetObject("BtnImpBarras_Documento.Image"), System.Drawing.Image)
        Me.BtnImpBarras_Documento.ImageIndent = New System.Drawing.Point(8, -10)
        Me.BtnImpBarras_Documento.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnImpBarras_Documento.Name = "BtnImpBarras_Documento"
        Me.BtnImpBarras_Documento.SymbolColor = System.Drawing.Color.Empty
        Me.BtnImpBarras_Documento.Text = "<font size=""+4""><b>X DOCUMENTO</b></font><br/><font size=""-1"">Seleccionar un docu" &
    "mento</font>"
        Me.BtnImpBarras_Documento.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Teal
        Me.BtnImpBarras_Documento.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.BtnImpBarras_Documento.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.BtnImpBarras_Documento.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.BtnImpBarras_Documento.TileStyle.BackColorGradientAngle = 45
        Me.BtnImpBarras_Documento.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.BtnImpBarras_Documento.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.BtnImpBarras_Documento.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.BtnImpBarras_Documento.TileStyle.PaddingBottom = 4
        Me.BtnImpBarras_Documento.TileStyle.PaddingLeft = 4
        Me.BtnImpBarras_Documento.TileStyle.PaddingRight = 4
        Me.BtnImpBarras_Documento.TileStyle.PaddingTop = 4
        Me.BtnImpBarras_Documento.TileStyle.TextColor = System.Drawing.Color.White
        Me.BtnImpBarras_Documento.TitleText = "BakApp"
        '
        'BtnImpBarras_Ubicaciones
        '
        Me.BtnImpBarras_Ubicaciones.Image = CType(resources.GetObject("BtnImpBarras_Ubicaciones.Image"), System.Drawing.Image)
        Me.BtnImpBarras_Ubicaciones.ImageIndent = New System.Drawing.Point(8, -10)
        Me.BtnImpBarras_Ubicaciones.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnImpBarras_Ubicaciones.Name = "BtnImpBarras_Ubicaciones"
        Me.BtnImpBarras_Ubicaciones.SymbolColor = System.Drawing.Color.Empty
        Me.BtnImpBarras_Ubicaciones.Text = "<font size=""+4""><b>X UBICACIONES</b></font><br/><font size=""-1"">Imprimir etiqueta" &
    "s para las ubicaciones</font>"
        Me.BtnImpBarras_Ubicaciones.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Orange
        Me.BtnImpBarras_Ubicaciones.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.BtnImpBarras_Ubicaciones.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.BtnImpBarras_Ubicaciones.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.BtnImpBarras_Ubicaciones.TileStyle.BackColorGradientAngle = 45
        Me.BtnImpBarras_Ubicaciones.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.BtnImpBarras_Ubicaciones.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.BtnImpBarras_Ubicaciones.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.BtnImpBarras_Ubicaciones.TileStyle.PaddingBottom = 4
        Me.BtnImpBarras_Ubicaciones.TileStyle.PaddingLeft = 4
        Me.BtnImpBarras_Ubicaciones.TileStyle.PaddingRight = 4
        Me.BtnImpBarras_Ubicaciones.TileStyle.PaddingTop = 4
        Me.BtnImpBarras_Ubicaciones.TileStyle.TextColor = System.Drawing.Color.White
        Me.BtnImpBarras_Ubicaciones.TitleText = "BakApp"
        '
        'BtnCrearCodigosBarra
        '
        Me.BtnCrearCodigosBarra.Image = CType(resources.GetObject("BtnCrearCodigosBarra.Image"), System.Drawing.Image)
        Me.BtnCrearCodigosBarra.ImageIndent = New System.Drawing.Point(8, -10)
        Me.BtnCrearCodigosBarra.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnCrearCodigosBarra.Name = "BtnCrearCodigosBarra"
        Me.BtnCrearCodigosBarra.SymbolColor = System.Drawing.Color.Empty
        Me.BtnCrearCodigosBarra.Text = "<font size=""+4""><b>DISEÑO DE BARRAS</b></font><br/><font size=""-1"">Mantencion de " &
    "códigos de barra</font>"
        Me.BtnCrearCodigosBarra.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Yellow
        Me.BtnCrearCodigosBarra.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.BtnCrearCodigosBarra.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.BtnCrearCodigosBarra.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.BtnCrearCodigosBarra.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.BtnCrearCodigosBarra.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.BtnCrearCodigosBarra.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.BtnCrearCodigosBarra.TileStyle.TextColor = System.Drawing.Color.White
        Me.BtnCrearCodigosBarra.TitleText = "BakApp"
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.LabelX1.Location = New System.Drawing.Point(3, 6)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(563, 49)
        Me.LabelX1.TabIndex = 47
        Me.LabelX1.Text = "<font color=""#349FCE""><b>SISTEMA IMPRESION DE CODIGOS DE BARRA</b></font>"
        '
        'Sistema_CodBarras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.Name = "Sistema_CodBarras"
        Me.Size = New System.Drawing.Size(633, 344)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents ConsultaPreciosContenedor As DevComponents.DotNetBar.ItemContainer
    Private WithEvents BtnImpBarras_Producto As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents BtnImpBarras_Documento As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents BtnConfiguracion As DevComponents.DotNetBar.ButtonItem
    Private WithEvents BtnCrearCodigosBarra As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents BtnImpBarras_Ubicaciones As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX

End Class
