<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Modulo_Documentos_Stock
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Modulo_Documentos_Stock))
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem()
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel()
        Me.MnuEspecialOtros = New DevComponents.DotNetBar.ItemContainer()
        Me.Btn_NVI = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_GTI = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_GDP_GDD = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_GDD = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_GRI = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Guia_Recepcion_Devoluciones = New DevComponents.DotNetBar.Metro.MetroTileItem()
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
        Me.LabelX1.Location = New System.Drawing.Point(3, 2)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(378, 49)
        Me.LabelX1.TabIndex = 47
        Me.LabelX1.Text = "<font color=""#349FCE""><b>DOCUMENTOS DE STOCK</b></font>"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSalir})
        Me.Bar2.Location = New System.Drawing.Point(0, 289)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(640, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 45
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
        Me.MetroTilePanel1.Location = New System.Drawing.Point(3, 55)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(642, 310)
        Me.MetroTilePanel1.TabIndex = 46
        Me.MetroTilePanel1.Text = "MetroTilePanel1"
        '
        'MnuEspecialOtros
        '
        '
        '
        '
        Me.MnuEspecialOtros.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MnuEspecialOtros.FixedSize = New System.Drawing.Size(700, 250)
        Me.MnuEspecialOtros.MultiLine = True
        Me.MnuEspecialOtros.Name = "MnuEspecialOtros"
        Me.MnuEspecialOtros.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_NVI, Me.Btn_GTI, Me.Btn_GDP_GDD, Me.Btn_GDD, Me.Btn_GRI, Me.Btn_Guia_Recepcion_Devoluciones})
        '
        '
        '
        Me.MnuEspecialOtros.TitleStyle.Class = "MetroTileGroupTitle"
        Me.MnuEspecialOtros.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'Btn_NVI
        '
        Me.Btn_NVI.Image = CType(resources.GetObject("Btn_NVI.Image"), System.Drawing.Image)
        Me.Btn_NVI.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_NVI.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_NVI.Name = "Btn_NVI"
        Me.Btn_NVI.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_NVI.Tag = "COV"
        Me.Btn_NVI.Text = "<font size=""+4""><b>NVI</b><br/></font>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Nota de entrega interna"
        Me.Btn_NVI.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.RedOrange
        Me.Btn_NVI.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_NVI.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Btn_NVI.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Btn_NVI.TileStyle.BackColorGradientAngle = 45
        Me.Btn_NVI.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Btn_NVI.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Btn_NVI.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_NVI.TileStyle.PaddingBottom = 4
        Me.Btn_NVI.TileStyle.PaddingLeft = 4
        Me.Btn_NVI.TileStyle.PaddingRight = 4
        Me.Btn_NVI.TileStyle.PaddingTop = 4
        Me.Btn_NVI.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_NVI.TitleText = "Documento"
        '
        'Btn_GTI
        '
        Me.Btn_GTI.Image = CType(resources.GetObject("Btn_GTI.Image"), System.Drawing.Image)
        Me.Btn_GTI.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_GTI.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_GTI.Name = "Btn_GTI"
        Me.Btn_GTI.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_GTI.Tag = "GDV"
        Me.Btn_GTI.Text = "<font size=""+4""><b>GTI - GUIA</b><br/></font>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Guía de traslado entre sucursales"
        Me.Btn_GTI.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Blueish
        Me.Btn_GTI.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_GTI.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(137, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(163, Byte), Integer))
        Me.Btn_GTI.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(137, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(163, Byte), Integer))
        Me.Btn_GTI.TileStyle.BackColorGradientAngle = 45
        Me.Btn_GTI.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(137, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(163, Byte), Integer))
        Me.Btn_GTI.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(137, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(163, Byte), Integer))
        Me.Btn_GTI.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_GTI.TileStyle.PaddingBottom = 4
        Me.Btn_GTI.TileStyle.PaddingLeft = 4
        Me.Btn_GTI.TileStyle.PaddingRight = 4
        Me.Btn_GTI.TileStyle.PaddingTop = 4
        Me.Btn_GTI.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_GTI.TitleText = "Documento"
        '
        'Btn_GDP_GDD
        '
        Me.Btn_GDP_GDD.Image = CType(resources.GetObject("Btn_GDP_GDD.Image"), System.Drawing.Image)
        Me.Btn_GDP_GDD.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_GDP_GDD.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_GDP_GDD.Name = "Btn_GDP_GDD"
        Me.Btn_GDP_GDD.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_GDP_GDD.Tag = "GDV"
        Me.Btn_GDP_GDD.Text = "<font size=""+4""><b>GDP - GDD</b><br/></font>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Guía de despacho por devolución<br/" &
    ">" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "prestamos y consignaciones" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Btn_GDP_GDD.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Blueish
        Me.Btn_GDP_GDD.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_GDP_GDD.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Btn_GDP_GDD.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Btn_GDP_GDD.TileStyle.BackColorGradientAngle = 45
        Me.Btn_GDP_GDD.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Btn_GDP_GDD.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Btn_GDP_GDD.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_GDP_GDD.TileStyle.PaddingBottom = 4
        Me.Btn_GDP_GDD.TileStyle.PaddingLeft = 4
        Me.Btn_GDP_GDD.TileStyle.PaddingRight = 4
        Me.Btn_GDP_GDD.TileStyle.PaddingTop = 4
        Me.Btn_GDP_GDD.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_GDP_GDD.TitleText = "Documento"
        '
        'Btn_GDD
        '
        Me.Btn_GDD.Image = CType(resources.GetObject("Btn_GDD.Image"), System.Drawing.Image)
        Me.Btn_GDD.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_GDD.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_GDD.Name = "Btn_GDD"
        Me.Btn_GDD.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_GDD.Tag = "GDV"
        Me.Btn_GDD.Text = "<font size=""+4""><b>GDD - GUIA</b><br/></font>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Guía de despacho por devolución"
        Me.Btn_GDD.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Blueish
        Me.Btn_GDD.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_GDD.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(118, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Btn_GDD.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(118, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Btn_GDD.TileStyle.BackColorGradientAngle = 45
        Me.Btn_GDD.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(118, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Btn_GDD.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(118, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Btn_GDD.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_GDD.TileStyle.PaddingBottom = 4
        Me.Btn_GDD.TileStyle.PaddingLeft = 4
        Me.Btn_GDD.TileStyle.PaddingRight = 4
        Me.Btn_GDD.TileStyle.PaddingTop = 4
        Me.Btn_GDD.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_GDD.TitleText = "Documento"
        '
        'Btn_GRI
        '
        Me.Btn_GRI.Image = CType(resources.GetObject("Btn_GRI.Image"), System.Drawing.Image)
        Me.Btn_GRI.ImageIndent = New System.Drawing.Point(8, -6)
        Me.Btn_GRI.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_GRI.Name = "Btn_GRI"
        Me.Btn_GRI.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_GRI.Text = "<font size=""+4""><b>GDI - GRI</b><br/></font>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Guía de movimientos internos"
        Me.Btn_GRI.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.Btn_GRI.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_GRI.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_GRI.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_GRI.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_GRI.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_GRI.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_GRI.TitleText = "BakApp"
        '
        'Btn_Guia_Recepcion_Devoluciones
        '
        Me.Btn_Guia_Recepcion_Devoluciones.Image = CType(resources.GetObject("Btn_Guia_Recepcion_Devoluciones.Image"), System.Drawing.Image)
        Me.Btn_Guia_Recepcion_Devoluciones.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Guia_Recepcion_Devoluciones.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Guia_Recepcion_Devoluciones.Name = "Btn_Guia_Recepcion_Devoluciones"
        Me.Btn_Guia_Recepcion_Devoluciones.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Guia_Recepcion_Devoluciones.Tag = "BLV"
        Me.Btn_Guia_Recepcion_Devoluciones.Text = "<font size=""+4""><b>GRD - GUIA RECEPCION DEVOLUCIONES</b></font>"
        Me.Btn_Guia_Recepcion_Devoluciones.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.Btn_Guia_Recepcion_Devoluciones.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Guia_Recepcion_Devoluciones.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(111, Byte), Integer), CType(CType(86, Byte), Integer), CType(CType(67, Byte), Integer))
        Me.Btn_Guia_Recepcion_Devoluciones.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(111, Byte), Integer), CType(CType(86, Byte), Integer), CType(CType(67, Byte), Integer))
        Me.Btn_Guia_Recepcion_Devoluciones.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Guia_Recepcion_Devoluciones.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(111, Byte), Integer), CType(CType(86, Byte), Integer), CType(CType(67, Byte), Integer))
        Me.Btn_Guia_Recepcion_Devoluciones.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(111, Byte), Integer), CType(CType(86, Byte), Integer), CType(CType(67, Byte), Integer))
        Me.Btn_Guia_Recepcion_Devoluciones.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Guia_Recepcion_Devoluciones.TileStyle.PaddingBottom = 4
        Me.Btn_Guia_Recepcion_Devoluciones.TileStyle.PaddingLeft = 4
        Me.Btn_Guia_Recepcion_Devoluciones.TileStyle.PaddingRight = 4
        Me.Btn_Guia_Recepcion_Devoluciones.TileStyle.PaddingTop = 4
        Me.Btn_Guia_Recepcion_Devoluciones.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Guia_Recepcion_Devoluciones.TitleText = "Documento"
        '
        'Modulo_Documentos_Stock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.Name = "Modulo_Documentos_Stock"
        Me.Size = New System.Drawing.Size(640, 330)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents MnuEspecialOtros As DevComponents.DotNetBar.ItemContainer
    Public WithEvents Btn_NVI As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_GDD As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_GTI As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_GRI As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_GDP_GDD As DevComponents.DotNetBar.Metro.MetroTileItem
    Public WithEvents Btn_Guia_Recepcion_Devoluciones As DevComponents.DotNetBar.Metro.MetroTileItem
End Class
