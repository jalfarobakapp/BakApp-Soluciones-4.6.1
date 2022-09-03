<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Vales_Marcar
    Inherits DevComponents.DotNetBar.Metro.MetroForm

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Vales_Marcar))
        Me.Bar2 = New DevComponents.DotNetBar.Bar
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel
        Me.MnuEspecialOtros = New DevComponents.DotNetBar.ItemContainer
        Me.BtnRetiraCliente = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.BtnDespacho = New DevComponents.DotNetBar.Metro.MetroTileItem
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSalir})
        Me.Bar2.Location = New System.Drawing.Point(0, 251)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(270, 41)
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
        Me.BtnSalir.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnSalir.Name = "BtnSalir"
        '
        'MetroTilePanel1
        '
        Me.MetroTilePanel1.BackColor = System.Drawing.Color.White
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
        Me.MetroTilePanel1.Location = New System.Drawing.Point(3, 0)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(363, 581)
        Me.MetroTilePanel1.TabIndex = 32
        Me.MetroTilePanel1.Text = "MetroTilePanel1"
        '
        'MnuEspecialOtros
        '
        '
        '
        '
        Me.MnuEspecialOtros.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MnuEspecialOtros.FixedSize = New System.Drawing.Size(300, 500)
        Me.MnuEspecialOtros.MultiLine = True
        Me.MnuEspecialOtros.Name = "MnuEspecialOtros"
        Me.MnuEspecialOtros.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnRetiraCliente, Me.BtnDespacho})
        '
        '
        '
        Me.MnuEspecialOtros.TitleStyle.Class = "MetroTileGroupTitle"
        Me.MnuEspecialOtros.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'BtnRetiraCliente
        '
        Me.BtnRetiraCliente.Image = CType(resources.GetObject("BtnRetiraCliente.Image"), System.Drawing.Image)
        Me.BtnRetiraCliente.ImageIndent = New System.Drawing.Point(8, -6)
        Me.BtnRetiraCliente.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnRetiraCliente.Name = "BtnRetiraCliente"
        Me.BtnRetiraCliente.SymbolColor = System.Drawing.Color.Empty
        Me.BtnRetiraCliente.Text = "<font size=""+9"">RETIRA CLIENTE</font><br/>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Cliente retitra en bodega" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.BtnRetiraCliente.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.BtnRetiraCliente.TileSize = New System.Drawing.Size(230, 100)
        '
        '
        '
        Me.BtnRetiraCliente.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BtnRetiraCliente.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BtnRetiraCliente.TileStyle.BackColorGradientAngle = 45
        Me.BtnRetiraCliente.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BtnRetiraCliente.TileStyle.PaddingBottom = 4
        Me.BtnRetiraCliente.TileStyle.PaddingLeft = 4
        Me.BtnRetiraCliente.TileStyle.PaddingRight = 4
        Me.BtnRetiraCliente.TileStyle.PaddingTop = 4
        Me.BtnRetiraCliente.TileStyle.TextColor = System.Drawing.Color.Black
        Me.BtnRetiraCliente.TitleText = "Aceptar compra"
        '
        'BtnDespacho
        '
        Me.BtnDespacho.Image = CType(resources.GetObject("BtnDespacho.Image"), System.Drawing.Image)
        Me.BtnDespacho.ImageIndent = New System.Drawing.Point(8, -6)
        Me.BtnDespacho.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnDespacho.Name = "BtnDespacho"
        Me.BtnDespacho.SymbolColor = System.Drawing.Color.Empty
        Me.BtnDespacho.Text = "<font size=""+10"">DESPACHO</font><br/>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Despacho a domicilio" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.BtnDespacho.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.BtnDespacho.TileSize = New System.Drawing.Size(230, 100)
        '
        '
        '
        Me.BtnDespacho.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.BtnDespacho.TileStyle.BackColor2 = System.Drawing.Color.MediumSeaGreen
        Me.BtnDespacho.TileStyle.BackColorGradientAngle = 45
        Me.BtnDespacho.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BtnDespacho.TileStyle.PaddingBottom = 4
        Me.BtnDespacho.TileStyle.PaddingLeft = 4
        Me.BtnDespacho.TileStyle.PaddingRight = 4
        Me.BtnDespacho.TileStyle.PaddingTop = 4
        Me.BtnDespacho.TileStyle.TextColor = System.Drawing.Color.Black
        Me.BtnDespacho.TitleText = "Aceptar compra"
        '
        'Frm_Vales_Marcar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(270, 292)
        Me.ControlBox = False
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_Vales_Marcar"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Marcar documento"
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents MnuEspecialOtros As DevComponents.DotNetBar.ItemContainer
    Private WithEvents BtnRetiraCliente As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents BtnDespacho As DevComponents.DotNetBar.Metro.MetroTileItem
End Class
