<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Documentos_GDD_GDP
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Documentos_GDD_GDP))
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem()
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel()
        Me.MnuEspecialOtros = New DevComponents.DotNetBar.ItemContainer()
        Me.Btn_GDD_PRE = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_GDD_CON = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_GDP_PRE = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_GDP_CON = New DevComponents.DotNetBar.Metro.MetroTileItem()
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
        Me.LabelX1.Location = New System.Drawing.Point(3, 1)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(433, 49)
        Me.LabelX1.TabIndex = 50
        Me.LabelX1.Text = "<font color=""#349FCE""><b>PRESTAMOS Y CONSIGNACIONES</b></font>"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSalir})
        Me.Bar2.Location = New System.Drawing.Point(0, 293)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(439, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 48
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
        Me.MetroTilePanel1.Location = New System.Drawing.Point(3, 54)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(743, 320)
        Me.MetroTilePanel1.TabIndex = 49
        Me.MetroTilePanel1.Text = "MetroTilePanel1"
        '
        'MnuEspecialOtros
        '
        '
        '
        '
        Me.MnuEspecialOtros.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MnuEspecialOtros.FixedSize = New System.Drawing.Size(600, 250)
        Me.MnuEspecialOtros.MultiLine = True
        Me.MnuEspecialOtros.Name = "MnuEspecialOtros"
        Me.MnuEspecialOtros.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_GDD_PRE, Me.Btn_GDD_CON, Me.Btn_GDP_PRE, Me.Btn_GDP_CON})
        '
        '
        '
        Me.MnuEspecialOtros.TitleStyle.Class = "MetroTileGroupTitle"
        Me.MnuEspecialOtros.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'Btn_GDD_PRE
        '
        Me.Btn_GDD_PRE.Image = CType(resources.GetObject("Btn_GDD_PRE.Image"), System.Drawing.Image)
        Me.Btn_GDD_PRE.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_GDD_PRE.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_GDD_PRE.Name = "Btn_GDD_PRE"
        Me.Btn_GDD_PRE.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_GDD_PRE.Tag = "COV"
        Me.Btn_GDD_PRE.Text = "<font size=""+4""><b>GDD - PRE</b><br/></font>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Guía de devolución de prestamos al " &
    "proveedor" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Btn_GDD_PRE.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.RedOrange
        Me.Btn_GDD_PRE.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_GDD_PRE.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Btn_GDD_PRE.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Btn_GDD_PRE.TileStyle.BackColorGradientAngle = 45
        Me.Btn_GDD_PRE.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Btn_GDD_PRE.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Btn_GDD_PRE.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_GDD_PRE.TileStyle.PaddingBottom = 4
        Me.Btn_GDD_PRE.TileStyle.PaddingLeft = 4
        Me.Btn_GDD_PRE.TileStyle.PaddingRight = 4
        Me.Btn_GDD_PRE.TileStyle.PaddingTop = 4
        Me.Btn_GDD_PRE.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_GDD_PRE.TitleText = "Documento"
        '
        'Btn_GDD_CON
        '
        Me.Btn_GDD_CON.Image = CType(resources.GetObject("Btn_GDD_CON.Image"), System.Drawing.Image)
        Me.Btn_GDD_CON.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_GDD_CON.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_GDD_CON.Name = "Btn_GDD_CON"
        Me.Btn_GDD_CON.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_GDD_CON.Tag = "GDV"
        Me.Btn_GDD_CON.Text = "<font size=""+4""><b>GDD - CON</b><br/></font>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Guía de devolución de consignacione" &
    "s al proveedor" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Btn_GDD_CON.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Blueish
        Me.Btn_GDD_CON.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_GDD_CON.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(118, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Btn_GDD_CON.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(118, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Btn_GDD_CON.TileStyle.BackColorGradientAngle = 45
        Me.Btn_GDD_CON.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(118, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Btn_GDD_CON.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(118, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Btn_GDD_CON.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_GDD_CON.TileStyle.PaddingBottom = 4
        Me.Btn_GDD_CON.TileStyle.PaddingLeft = 4
        Me.Btn_GDD_CON.TileStyle.PaddingRight = 4
        Me.Btn_GDD_CON.TileStyle.PaddingTop = 4
        Me.Btn_GDD_CON.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_GDD_CON.TitleText = "Documento"
        '
        'Btn_GDP_PRE
        '
        Me.Btn_GDP_PRE.Image = CType(resources.GetObject("Btn_GDP_PRE.Image"), System.Drawing.Image)
        Me.Btn_GDP_PRE.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_GDP_PRE.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_GDP_PRE.Name = "Btn_GDP_PRE"
        Me.Btn_GDP_PRE.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_GDP_PRE.Tag = "GDV"
        Me.Btn_GDP_PRE.Text = "<font size=""+4""><b>GDP - PRE</b><br/></font>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Guía de despacho de prestamos al cl" &
    "iente" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Btn_GDP_PRE.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Blueish
        Me.Btn_GDP_PRE.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_GDP_PRE.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Btn_GDP_PRE.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Btn_GDP_PRE.TileStyle.BackColorGradientAngle = 45
        Me.Btn_GDP_PRE.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Btn_GDP_PRE.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Btn_GDP_PRE.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_GDP_PRE.TileStyle.PaddingBottom = 4
        Me.Btn_GDP_PRE.TileStyle.PaddingLeft = 4
        Me.Btn_GDP_PRE.TileStyle.PaddingRight = 4
        Me.Btn_GDP_PRE.TileStyle.PaddingTop = 4
        Me.Btn_GDP_PRE.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_GDP_PRE.TitleText = "Documento"
        '
        'Btn_GDP_CON
        '
        Me.Btn_GDP_CON.Image = CType(resources.GetObject("Btn_GDP_CON.Image"), System.Drawing.Image)
        Me.Btn_GDP_CON.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_GDP_CON.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_GDP_CON.Name = "Btn_GDP_CON"
        Me.Btn_GDP_CON.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_GDP_CON.Tag = "GDV"
        Me.Btn_GDP_CON.Text = "<font size=""+4""><b>GDP - CON</b><br/></font>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Guía de despacho de consignaciones" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Btn_GDP_CON.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Blueish
        Me.Btn_GDP_CON.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_GDP_CON.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(118, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Btn_GDP_CON.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(118, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Btn_GDP_CON.TileStyle.BackColorGradientAngle = 45
        Me.Btn_GDP_CON.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(118, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Btn_GDP_CON.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(118, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Btn_GDP_CON.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_GDP_CON.TileStyle.PaddingBottom = 4
        Me.Btn_GDP_CON.TileStyle.PaddingLeft = 4
        Me.Btn_GDP_CON.TileStyle.PaddingRight = 4
        Me.Btn_GDP_CON.TileStyle.PaddingTop = 4
        Me.Btn_GDP_CON.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_GDP_CON.TitleText = "Documento"
        '
        'Documentos_GDD_GDP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.Name = "Documentos_GDD_GDP"
        Me.Size = New System.Drawing.Size(439, 334)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents MnuEspecialOtros As DevComponents.DotNetBar.ItemContainer
    Public WithEvents Btn_GDD_PRE As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_GDD_CON As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_GDP_PRE As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_GDP_CON As DevComponents.DotNetBar.Metro.MetroTileItem
End Class
