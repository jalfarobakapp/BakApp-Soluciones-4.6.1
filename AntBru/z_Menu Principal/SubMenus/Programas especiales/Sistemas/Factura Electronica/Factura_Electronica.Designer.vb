<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Factura_Electronica
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Factura_Electronica))
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Pruebas = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Configuración = New DevComponents.DotNetBar.ButtonItem()
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel()
        Me.ConsultaPreciosContenedor = New DevComponents.DotNetBar.ItemContainer()
        Me.Btn_Envios_DTE = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Revision_Compras_SII = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_CAF = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_DiablitoDTEMonitor = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.MStb_Barra = New DevComponents.DotNetBar.Metro.MetroStatusBar()
        Me.Lbl_Etiqueta = New DevComponents.DotNetBar.LabelItem()
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
        Me.LabelX1.Location = New System.Drawing.Point(0, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(302, 34)
        Me.LabelX1.TabIndex = 62
        Me.LabelX1.Text = "<font color=""#349FCE""><b>FACTURA ELECTRONICA</b></font>"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSalir, Me.Btn_Pruebas, Me.Btn_Configuración})
        Me.Bar2.Location = New System.Drawing.Point(0, 275)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(442, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 61
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
        'Btn_Pruebas
        '
        Me.Btn_Pruebas.ForeColor = System.Drawing.Color.Black
        Me.Btn_Pruebas.Name = "Btn_Pruebas"
        Me.Btn_Pruebas.Text = "PRUEBAS"
        Me.Btn_Pruebas.Visible = False
        '
        'Btn_Configuración
        '
        Me.Btn_Configuración.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Configuración.Image = CType(resources.GetObject("Btn_Configuración.Image"), System.Drawing.Image)
        Me.Btn_Configuración.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.Btn_Configuración.Name = "Btn_Configuración"
        Me.Btn_Configuración.Tooltip = "Configuración"
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
        Me.MetroTilePanel1.Location = New System.Drawing.Point(3, 43)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(604, 303)
        Me.MetroTilePanel1.TabIndex = 60
        Me.MetroTilePanel1.Text = "MetroTilePanel1"
        '
        'ConsultaPreciosContenedor
        '
        '
        '
        '
        Me.ConsultaPreciosContenedor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ConsultaPreciosContenedor.FixedSize = New System.Drawing.Size(600, 300)
        Me.ConsultaPreciosContenedor.MultiLine = True
        Me.ConsultaPreciosContenedor.Name = "ConsultaPreciosContenedor"
        Me.ConsultaPreciosContenedor.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Envios_DTE, Me.Btn_Revision_Compras_SII, Me.Btn_CAF, Me.Btn_DiablitoDTEMonitor})
        '
        '
        '
        Me.ConsultaPreciosContenedor.TitleStyle.Class = "MetroTileGroupTitle"
        Me.ConsultaPreciosContenedor.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ConsultaPreciosContenedor.TitleStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'Btn_Envios_DTE
        '
        Me.Btn_Envios_DTE.Image = CType(resources.GetObject("Btn_Envios_DTE.Image"), System.Drawing.Image)
        Me.Btn_Envios_DTE.ImageIndent = New System.Drawing.Point(10, -10)
        Me.Btn_Envios_DTE.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Envios_DTE.Name = "Btn_Envios_DTE"
        Me.Btn_Envios_DTE.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Envios_DTE.Text = "<font Size=""+4""><b>DOCUMENTOS...</b></font><br/><font size=""-1"">Informe del estad" &
    "o de envio al SII</font>"
        Me.Btn_Envios_DTE.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.Btn_Envios_DTE.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Envios_DTE.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Btn_Envios_DTE.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Btn_Envios_DTE.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Envios_DTE.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Btn_Envios_DTE.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Btn_Envios_DTE.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Envios_DTE.TileStyle.PaddingBottom = 4
        Me.Btn_Envios_DTE.TileStyle.PaddingLeft = 4
        Me.Btn_Envios_DTE.TileStyle.PaddingRight = 4
        Me.Btn_Envios_DTE.TileStyle.PaddingTop = 4
        Me.Btn_Envios_DTE.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Envios_DTE.TitleText = "BakApp"
        '
        'Btn_Revision_Compras_SII
        '
        Me.Btn_Revision_Compras_SII.Image = CType(resources.GetObject("Btn_Revision_Compras_SII.Image"), System.Drawing.Image)
        Me.Btn_Revision_Compras_SII.ImageIndent = New System.Drawing.Point(8, -6)
        Me.Btn_Revision_Compras_SII.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Revision_Compras_SII.Name = "Btn_Revision_Compras_SII"
        Me.Btn_Revision_Compras_SII.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Revision_Compras_SII.Text = "<font size=""+4""><b>REVISION SII</b></font><br/><font size=""-1"">comparativo de com" &
    "pras vs SII</font>"
        Me.Btn_Revision_Compras_SII.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Yellow
        Me.Btn_Revision_Compras_SII.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Revision_Compras_SII.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(57, Byte), Integer))
        Me.Btn_Revision_Compras_SII.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(57, Byte), Integer))
        Me.Btn_Revision_Compras_SII.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Revision_Compras_SII.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(57, Byte), Integer))
        Me.Btn_Revision_Compras_SII.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(57, Byte), Integer))
        Me.Btn_Revision_Compras_SII.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Revision_Compras_SII.TileStyle.PaddingBottom = 4
        Me.Btn_Revision_Compras_SII.TileStyle.PaddingLeft = 4
        Me.Btn_Revision_Compras_SII.TileStyle.PaddingRight = 4
        Me.Btn_Revision_Compras_SII.TileStyle.PaddingTop = 4
        Me.Btn_Revision_Compras_SII.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Revision_Compras_SII.TitleText = "BakApp"
        '
        'Btn_CAF
        '
        Me.Btn_CAF.Image = CType(resources.GetObject("Btn_CAF.Image"), System.Drawing.Image)
        Me.Btn_CAF.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_CAF.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_CAF.Name = "Btn_CAF"
        Me.Btn_CAF.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_CAF.Text = "<font size=""+4""><b>CAF FOLIOS</b></font><br/><font size=""-1"">Mantención de folios" &
    "</font>"
        Me.Btn_CAF.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.Btn_CAF.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_CAF.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.Btn_CAF.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.Btn_CAF.TileStyle.BackColorGradientAngle = 45
        Me.Btn_CAF.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.Btn_CAF.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.Btn_CAF.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_CAF.TileStyle.PaddingBottom = 4
        Me.Btn_CAF.TileStyle.PaddingLeft = 4
        Me.Btn_CAF.TileStyle.PaddingRight = 4
        Me.Btn_CAF.TileStyle.PaddingTop = 4
        Me.Btn_CAF.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_CAF.TitleText = "BakApp"
        '
        'Btn_DiablitoDTEMonitor
        '
        Me.Btn_DiablitoDTEMonitor.Image = CType(resources.GetObject("Btn_DiablitoDTEMonitor.Image"), System.Drawing.Image)
        Me.Btn_DiablitoDTEMonitor.ImageIndent = New System.Drawing.Point(10, -10)
        Me.Btn_DiablitoDTEMonitor.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_DiablitoDTEMonitor.Name = "Btn_DiablitoDTEMonitor"
        Me.Btn_DiablitoDTEMonitor.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_DiablitoDTEMonitor.Text = "<font Size=""+4""><b>DTEMonitor</b></font><br/><font size=""-1"">Sistema que envia lo" &
    "s DTE al SII y correos</font>"
        Me.Btn_DiablitoDTEMonitor.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.Btn_DiablitoDTEMonitor.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_DiablitoDTEMonitor.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_DiablitoDTEMonitor.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_DiablitoDTEMonitor.TileStyle.BackColorGradientAngle = 45
        Me.Btn_DiablitoDTEMonitor.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_DiablitoDTEMonitor.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_DiablitoDTEMonitor.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_DiablitoDTEMonitor.TileStyle.PaddingBottom = 4
        Me.Btn_DiablitoDTEMonitor.TileStyle.PaddingLeft = 4
        Me.Btn_DiablitoDTEMonitor.TileStyle.PaddingRight = 4
        Me.Btn_DiablitoDTEMonitor.TileStyle.PaddingTop = 4
        Me.Btn_DiablitoDTEMonitor.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_DiablitoDTEMonitor.TitleText = "BakApp"
        '
        'MStb_Barra
        '
        '
        '
        '
        Me.MStb_Barra.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MStb_Barra.ContainerControlProcessDialogKey = True
        Me.MStb_Barra.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.MStb_Barra.DragDropSupport = True
        Me.MStb_Barra.Font = New System.Drawing.Font("Segoe UI", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MStb_Barra.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Lbl_Etiqueta})
        Me.MStb_Barra.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MStb_Barra.Location = New System.Drawing.Point(0, 316)
        Me.MStb_Barra.Name = "MStb_Barra"
        Me.MStb_Barra.Size = New System.Drawing.Size(442, 22)
        Me.MStb_Barra.TabIndex = 64
        Me.MStb_Barra.Text = "MetroStatusBar1"
        '
        'Lbl_Etiqueta
        '
        Me.Lbl_Etiqueta.Name = "Lbl_Etiqueta"
        Me.Lbl_Etiqueta.Text = "Ambiente de producción"
        '
        'Factura_Electronica
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MStb_Barra)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.Name = "Factura_Electronica"
        Me.Size = New System.Drawing.Size(442, 338)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents ConsultaPreciosContenedor As DevComponents.DotNetBar.ItemContainer
    Private WithEvents Btn_Envios_DTE As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Revision_Compras_SII As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_CAF As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents Btn_Configuración As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MStb_Barra As DevComponents.DotNetBar.Metro.MetroStatusBar
    Friend WithEvents Lbl_Etiqueta As DevComponents.DotNetBar.LabelItem
    Private WithEvents Btn_DiablitoDTEMonitor As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents Btn_Pruebas As DevComponents.DotNetBar.ButtonItem
End Class
