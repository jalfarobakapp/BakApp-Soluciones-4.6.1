<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tesoreria_Clientes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Tesoreria_Clientes))
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem()
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel()
        Me.MnuEspecialOtros = New DevComponents.DotNetBar.ItemContainer()
        Me.Btn_Subir_Pagos = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Buscar_Documento = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Pago_Documentos = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Liquidacion_TJV_Credito = New DevComponents.DotNetBar.Metro.MetroTileItem()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.LabelX1.Location = New System.Drawing.Point(3, -12)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(394, 49)
        Me.LabelX1.TabIndex = 43
        Me.LabelX1.Text = "<font color=""#349FCE""><b>PAGO DE CLIENTES</b></font>"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSalir})
        Me.Bar2.Location = New System.Drawing.Point(0, 281)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(637, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 42
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
        Me.MetroTilePanel1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.MnuEspecialOtros})
        Me.MetroTilePanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MetroTilePanel1.Location = New System.Drawing.Point(3, 43)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(755, 353)
        Me.MetroTilePanel1.TabIndex = 41
        Me.MetroTilePanel1.Text = "MetroTilePanel1"
        '
        'MnuEspecialOtros
        '
        '
        '
        '
        Me.MnuEspecialOtros.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MnuEspecialOtros.FixedSize = New System.Drawing.Size(700, 300)
        Me.MnuEspecialOtros.MultiLine = True
        Me.MnuEspecialOtros.Name = "MnuEspecialOtros"
        Me.MnuEspecialOtros.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Subir_Pagos, Me.Btn_Buscar_Documento, Me.Btn_Pago_Documentos, Me.Btn_Liquidacion_TJV_Credito})
        '
        '
        '
        Me.MnuEspecialOtros.TitleStyle.Class = "MetroTileGroupTitle"
        Me.MnuEspecialOtros.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'Btn_Subir_Pagos
        '
        Me.Btn_Subir_Pagos.Image = CType(resources.GetObject("Btn_Subir_Pagos.Image"), System.Drawing.Image)
        Me.Btn_Subir_Pagos.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Subir_Pagos.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Subir_Pagos.Name = "Btn_Subir_Pagos"
        Me.Btn_Subir_Pagos.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Subir_Pagos.Text = "<font size=""+4""><b>SUBIR PAGOS</b></font><br/><font size=""-1"">Pago de clientes<br" &
    "/>Levantar pagos en forma masiva</font>"
        Me.Btn_Subir_Pagos.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.DarkBlue
        Me.Btn_Subir_Pagos.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Subir_Pagos.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.Btn_Subir_Pagos.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.Btn_Subir_Pagos.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Subir_Pagos.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.Btn_Subir_Pagos.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.Btn_Subir_Pagos.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Subir_Pagos.TileStyle.PaddingBottom = 4
        Me.Btn_Subir_Pagos.TileStyle.PaddingLeft = 4
        Me.Btn_Subir_Pagos.TileStyle.PaddingRight = 4
        Me.Btn_Subir_Pagos.TileStyle.PaddingTop = 4
        Me.Btn_Subir_Pagos.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Subir_Pagos.TitleTextColor = System.Drawing.Color.White
        '
        'Btn_Buscar_Documento
        '
        Me.Btn_Buscar_Documento.Image = CType(resources.GetObject("Btn_Buscar_Documento.Image"), System.Drawing.Image)
        Me.Btn_Buscar_Documento.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Buscar_Documento.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Buscar_Documento.Name = "Btn_Buscar_Documento"
        Me.Btn_Buscar_Documento.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Buscar_Documento.Text = "<font size=""+4""><b>BUSCAR DOCUMENTOS (PAGO)</b></font><br/><font size=""-1"">Busque" &
    "da avanzada. TENEDURIA</font>"
        Me.Btn_Buscar_Documento.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.DarkGreen
        Me.Btn_Buscar_Documento.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Buscar_Documento.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Btn_Buscar_Documento.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Btn_Buscar_Documento.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Buscar_Documento.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Btn_Buscar_Documento.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Btn_Buscar_Documento.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Buscar_Documento.TileStyle.PaddingBottom = 4
        Me.Btn_Buscar_Documento.TileStyle.PaddingLeft = 4
        Me.Btn_Buscar_Documento.TileStyle.PaddingRight = 4
        Me.Btn_Buscar_Documento.TileStyle.PaddingTop = 4
        Me.Btn_Buscar_Documento.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Buscar_Documento.TitleTextColor = System.Drawing.Color.White
        '
        'Btn_Pago_Documentos
        '
        Me.Btn_Pago_Documentos.Image = CType(resources.GetObject("Btn_Pago_Documentos.Image"), System.Drawing.Image)
        Me.Btn_Pago_Documentos.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Pago_Documentos.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Pago_Documentos.Name = "Btn_Pago_Documentos"
        Me.Btn_Pago_Documentos.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Pago_Documentos.Text = "<font size=""+4""><b>PAGOS GENERALES</b></font><br/><font size=""-1"">Sistema Caja<br" &
    "/> </font>"
        Me.Btn_Pago_Documentos.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.Btn_Pago_Documentos.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Pago_Documentos.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(81, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Btn_Pago_Documentos.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(81, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Btn_Pago_Documentos.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Pago_Documentos.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(81, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Btn_Pago_Documentos.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(81, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Btn_Pago_Documentos.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Pago_Documentos.TileStyle.PaddingBottom = 4
        Me.Btn_Pago_Documentos.TileStyle.PaddingLeft = 4
        Me.Btn_Pago_Documentos.TileStyle.PaddingRight = 4
        Me.Btn_Pago_Documentos.TileStyle.PaddingTop = 4
        Me.Btn_Pago_Documentos.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Pago_Documentos.TitleText = "BakApp"
        '
        'Btn_Liquidacion_TJV_Credito
        '
        Me.Btn_Liquidacion_TJV_Credito.Image = CType(resources.GetObject("Btn_Liquidacion_TJV_Credito.Image"), System.Drawing.Image)
        Me.Btn_Liquidacion_TJV_Credito.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Liquidacion_TJV_Credito.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Liquidacion_TJV_Credito.Name = "Btn_Liquidacion_TJV_Credito"
        Me.Btn_Liquidacion_TJV_Credito.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Liquidacion_TJV_Credito.Text = "<font size=""+4""><b>LIQUIDACION TARJETAS</b></font><br/><font size=""-1"">Liquidació" &
    "n de tarjetas de crédito<br/></font>"
        Me.Btn_Liquidacion_TJV_Credito.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Yellow
        Me.Btn_Liquidacion_TJV_Credito.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Liquidacion_TJV_Credito.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Btn_Liquidacion_TJV_Credito.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Btn_Liquidacion_TJV_Credito.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Liquidacion_TJV_Credito.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Btn_Liquidacion_TJV_Credito.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Btn_Liquidacion_TJV_Credito.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Liquidacion_TJV_Credito.TileStyle.PaddingBottom = 4
        Me.Btn_Liquidacion_TJV_Credito.TileStyle.PaddingLeft = 4
        Me.Btn_Liquidacion_TJV_Credito.TileStyle.PaddingRight = 4
        Me.Btn_Liquidacion_TJV_Credito.TileStyle.PaddingTop = 4
        Me.Btn_Liquidacion_TJV_Credito.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Liquidacion_TJV_Credito.TitleTextColor = System.Drawing.Color.White
        '
        'Tesoreria_Clientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.Name = "Tesoreria_Clientes"
        Me.Size = New System.Drawing.Size(637, 322)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents MnuEspecialOtros As DevComponents.DotNetBar.ItemContainer
    Private WithEvents Btn_Subir_Pagos As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Buscar_Documento As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Pago_Documentos As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Liquidacion_TJV_Credito As DevComponents.DotNetBar.Metro.MetroTileItem
End Class
