<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Documentos_GDI_GRI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Documentos_GDI_GRI))
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem()
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel()
        Me.MnuEspecialOtros = New DevComponents.DotNetBar.ItemContainer()
        Me.Btn_GRI = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_GDI = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_GDI_GRI = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_GRI_Ajuste = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_GDI_Ajuste = New DevComponents.DotNetBar.Metro.MetroTileItem()
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
        Me.LabelX1.Location = New System.Drawing.Point(0, 0)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(303, 49)
        Me.LabelX1.TabIndex = 53
        Me.LabelX1.Text = "<font color=""#349FCE""><b>MOVIMIENTOS INTERNOS</b></font>"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSalir})
        Me.Bar2.Location = New System.Drawing.Point(0, 288)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(634, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 51
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
        Me.MetroTilePanel1.Location = New System.Drawing.Point(0, 53)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(743, 320)
        Me.MetroTilePanel1.TabIndex = 52
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
        Me.MnuEspecialOtros.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_GDI_GRI, Me.Btn_GRI, Me.Btn_GDI, Me.Btn_GRI_Ajuste, Me.Btn_GDI_Ajuste})
        '
        '
        '
        Me.MnuEspecialOtros.TitleStyle.Class = "MetroTileGroupTitle"
        Me.MnuEspecialOtros.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'Btn_GRI
        '
        Me.Btn_GRI.Image = CType(resources.GetObject("Btn_GRI.Image"), System.Drawing.Image)
        Me.Btn_GRI.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_GRI.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_GRI.Name = "Btn_GRI"
        Me.Btn_GRI.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_GRI.Tag = "COV"
        Me.Btn_GRI.Text = "<font size=""+4""><b>GRI</b><br/></font>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Guía de recepción interna, común." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Btn_GRI.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.RedOrange
        Me.Btn_GRI.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_GRI.TileStyle.BackColor = System.Drawing.Color.Green
        Me.Btn_GRI.TileStyle.BackColor2 = System.Drawing.Color.Green
        Me.Btn_GRI.TileStyle.BackColorGradientAngle = 45
        Me.Btn_GRI.TileStyle.BorderColor = System.Drawing.Color.Green
        Me.Btn_GRI.TileStyle.BorderColor2 = System.Drawing.Color.Green
        Me.Btn_GRI.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_GRI.TileStyle.PaddingBottom = 4
        Me.Btn_GRI.TileStyle.PaddingLeft = 4
        Me.Btn_GRI.TileStyle.PaddingRight = 4
        Me.Btn_GRI.TileStyle.PaddingTop = 4
        Me.Btn_GRI.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_GRI.TitleText = "Documento"
        '
        'Btn_GDI
        '
        Me.Btn_GDI.Image = CType(resources.GetObject("Btn_GDI.Image"), System.Drawing.Image)
        Me.Btn_GDI.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_GDI.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_GDI.Name = "Btn_GDI"
        Me.Btn_GDI.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_GDI.Tag = "GDV"
        Me.Btn_GDI.Text = "<font size=""+4""><b>GDI</b><br/></font>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Guía de despacho interna, común." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Btn_GDI.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Blueish
        Me.Btn_GDI.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_GDI.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(126, Byte), Integer))
        Me.Btn_GDI.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(126, Byte), Integer))
        Me.Btn_GDI.TileStyle.BackColorGradientAngle = 45
        Me.Btn_GDI.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(126, Byte), Integer))
        Me.Btn_GDI.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(126, Byte), Integer))
        Me.Btn_GDI.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_GDI.TileStyle.PaddingBottom = 4
        Me.Btn_GDI.TileStyle.PaddingLeft = 4
        Me.Btn_GDI.TileStyle.PaddingRight = 4
        Me.Btn_GDI.TileStyle.PaddingTop = 4
        Me.Btn_GDI.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_GDI.TitleText = "Documento"
        '
        'Btn_GDI_GRI
        '
        Me.Btn_GDI_GRI.Image = CType(resources.GetObject("Btn_GDI_GRI.Image"), System.Drawing.Image)
        Me.Btn_GDI_GRI.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_GDI_GRI.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_GDI_GRI.Name = "Btn_GDI_GRI"
        Me.Btn_GDI_GRI.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_GDI_GRI.Tag = "GDV"
        Me.Btn_GDI_GRI.Text = "<font size=""+4""><b>Especial GDI-GRI</b><br/></font>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Btn_GDI_GRI.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Blueish
        Me.Btn_GDI_GRI.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_GDI_GRI.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(118, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Btn_GDI_GRI.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(118, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Btn_GDI_GRI.TileStyle.BackColorGradientAngle = 45
        Me.Btn_GDI_GRI.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(118, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Btn_GDI_GRI.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(118, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Btn_GDI_GRI.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_GDI_GRI.TileStyle.PaddingBottom = 4
        Me.Btn_GDI_GRI.TileStyle.PaddingLeft = 4
        Me.Btn_GDI_GRI.TileStyle.PaddingRight = 4
        Me.Btn_GDI_GRI.TileStyle.PaddingTop = 4
        Me.Btn_GDI_GRI.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_GDI_GRI.TitleText = "Documento"
        Me.Btn_GDI_GRI.Visible = False
        '
        'Btn_GRI_Ajuste
        '
        Me.Btn_GRI_Ajuste.Image = CType(resources.GetObject("Btn_GRI_Ajuste.Image"), System.Drawing.Image)
        Me.Btn_GRI_Ajuste.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_GRI_Ajuste.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_GRI_Ajuste.Name = "Btn_GRI_Ajuste"
        Me.Btn_GRI_Ajuste.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_GRI_Ajuste.Tag = "GDV"
        Me.Btn_GRI_Ajuste.Text = "<font size=""+4""><b><font color=""#FFC20E"">GRI - Ajuste</font></b><br/></font>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Guí" &
    "a de recepción interna, especial para ajustes." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Btn_GRI_Ajuste.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Blueish
        Me.Btn_GRI_Ajuste.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_GRI_Ajuste.TileStyle.BackColor = System.Drawing.Color.Green
        Me.Btn_GRI_Ajuste.TileStyle.BackColor2 = System.Drawing.Color.Green
        Me.Btn_GRI_Ajuste.TileStyle.BackColorGradientAngle = 45
        Me.Btn_GRI_Ajuste.TileStyle.BorderColor = System.Drawing.Color.Green
        Me.Btn_GRI_Ajuste.TileStyle.BorderColor2 = System.Drawing.Color.Green
        Me.Btn_GRI_Ajuste.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_GRI_Ajuste.TileStyle.PaddingBottom = 4
        Me.Btn_GRI_Ajuste.TileStyle.PaddingLeft = 4
        Me.Btn_GRI_Ajuste.TileStyle.PaddingRight = 4
        Me.Btn_GRI_Ajuste.TileStyle.PaddingTop = 4
        Me.Btn_GRI_Ajuste.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_GRI_Ajuste.TitleText = "Documento"
        '
        'Btn_GDI_Ajuste
        '
        Me.Btn_GDI_Ajuste.Image = CType(resources.GetObject("Btn_GDI_Ajuste.Image"), System.Drawing.Image)
        Me.Btn_GDI_Ajuste.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_GDI_Ajuste.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_GDI_Ajuste.Name = "Btn_GDI_Ajuste"
        Me.Btn_GDI_Ajuste.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_GDI_Ajuste.Tag = "GDV"
        Me.Btn_GDI_Ajuste.Text = "<font size=""+4""><b><font color=""#FFC20E"">GDI - Ajuste</font></b><br/></font>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Guí" &
    "a de despacho interna, especial para ajustes." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Btn_GDI_Ajuste.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Blueish
        Me.Btn_GDI_Ajuste.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_GDI_Ajuste.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(126, Byte), Integer))
        Me.Btn_GDI_Ajuste.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(126, Byte), Integer))
        Me.Btn_GDI_Ajuste.TileStyle.BackColorGradientAngle = 45
        Me.Btn_GDI_Ajuste.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(126, Byte), Integer))
        Me.Btn_GDI_Ajuste.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(126, Byte), Integer))
        Me.Btn_GDI_Ajuste.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_GDI_Ajuste.TileStyle.PaddingBottom = 4
        Me.Btn_GDI_Ajuste.TileStyle.PaddingLeft = 4
        Me.Btn_GDI_Ajuste.TileStyle.PaddingRight = 4
        Me.Btn_GDI_Ajuste.TileStyle.PaddingTop = 4
        Me.Btn_GDI_Ajuste.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_GDI_Ajuste.TitleText = "Documento"
        '
        'Documentos_GDI_GRI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.Name = "Documentos_GDI_GRI"
        Me.Size = New System.Drawing.Size(634, 329)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents MnuEspecialOtros As DevComponents.DotNetBar.ItemContainer
    Public WithEvents Btn_GRI As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_GDI As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_GDI_Ajuste As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_GDI_GRI As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_GRI_Ajuste As DevComponents.DotNetBar.Metro.MetroTileItem
End Class
