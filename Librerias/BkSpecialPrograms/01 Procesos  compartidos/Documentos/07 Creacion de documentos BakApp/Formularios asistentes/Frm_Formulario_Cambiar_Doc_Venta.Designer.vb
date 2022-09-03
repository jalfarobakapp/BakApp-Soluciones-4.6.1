<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Formulario_Cambiar_Doc_Venta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Formulario_Cambiar_Doc_Venta))
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel()
        Me.MnuEspecialOtros = New DevComponents.DotNetBar.ItemContainer()
        Me.BtnBoleta = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.BtnFactura = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.BtnCotizacion = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.BtnNotaDeVenta = New DevComponents.DotNetBar.Metro.MetroTileItem()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Location = New System.Drawing.Point(0, 258)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(263, 25)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 29
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
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
        Me.MetroTilePanel1.Location = New System.Drawing.Point(0, 6)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(580, 417)
        Me.MetroTilePanel1.TabIndex = 28
        Me.MetroTilePanel1.Text = "MetroTilePanel1"
        '
        'MnuEspecialOtros
        '
        '
        '
        '
        Me.MnuEspecialOtros.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MnuEspecialOtros.FixedSize = New System.Drawing.Size(340, 300)
        Me.MnuEspecialOtros.MultiLine = True
        Me.MnuEspecialOtros.Name = "MnuEspecialOtros"
        Me.MnuEspecialOtros.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnBoleta, Me.BtnFactura, Me.BtnCotizacion, Me.BtnNotaDeVenta})
        '
        '
        '
        Me.MnuEspecialOtros.TitleStyle.Class = "MetroTileGroupTitle"
        Me.MnuEspecialOtros.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'BtnBoleta
        '
        Me.BtnBoleta.Image = CType(resources.GetObject("BtnBoleta.Image"), System.Drawing.Image)
        Me.BtnBoleta.ImageIndent = New System.Drawing.Point(8, -6)
        Me.BtnBoleta.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnBoleta.Name = "BtnBoleta"
        Me.BtnBoleta.SymbolColor = System.Drawing.Color.Empty
        Me.BtnBoleta.Text = "<font size=""+10""><b>BOLETA</b></font><br/>"
        Me.BtnBoleta.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.BtnBoleta.TileSize = New System.Drawing.Size(230, 70)
        '
        '
        '
        Me.BtnBoleta.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.BtnBoleta.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.BtnBoleta.TileStyle.BackColorGradientAngle = 45
        Me.BtnBoleta.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.BtnBoleta.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.BtnBoleta.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.BtnBoleta.TileStyle.PaddingBottom = 4
        Me.BtnBoleta.TileStyle.PaddingLeft = 4
        Me.BtnBoleta.TileStyle.PaddingRight = 4
        Me.BtnBoleta.TileStyle.PaddingTop = 4
        Me.BtnBoleta.TileStyle.TextColor = System.Drawing.Color.White
        Me.BtnBoleta.TitleText = "Vale transitorio"
        '
        'BtnFactura
        '
        Me.BtnFactura.Image = CType(resources.GetObject("BtnFactura.Image"), System.Drawing.Image)
        Me.BtnFactura.ImageIndent = New System.Drawing.Point(8, -6)
        Me.BtnFactura.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnFactura.Name = "BtnFactura"
        Me.BtnFactura.SymbolColor = System.Drawing.Color.Empty
        Me.BtnFactura.Text = "<font size=""+10""><b><font color=""#FFFFFF"">FACTURA</font></b></font><br/>"
        Me.BtnFactura.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.BtnFactura.TileSize = New System.Drawing.Size(230, 70)
        '
        '
        '
        Me.BtnFactura.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.BtnFactura.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.BtnFactura.TileStyle.BackColorGradientAngle = 45
        Me.BtnFactura.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.BtnFactura.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.BtnFactura.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.BtnFactura.TileStyle.PaddingBottom = 4
        Me.BtnFactura.TileStyle.PaddingLeft = 4
        Me.BtnFactura.TileStyle.PaddingRight = 4
        Me.BtnFactura.TileStyle.PaddingTop = 4
        Me.BtnFactura.TileStyle.TextColor = System.Drawing.Color.White
        Me.BtnFactura.TitleText = "Vale transitorio"
        '
        'BtnCotizacion
        '
        Me.BtnCotizacion.Image = CType(resources.GetObject("BtnCotizacion.Image"), System.Drawing.Image)
        Me.BtnCotizacion.ImageIndent = New System.Drawing.Point(8, -6)
        Me.BtnCotizacion.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnCotizacion.Name = "BtnCotizacion"
        Me.BtnCotizacion.SymbolColor = System.Drawing.Color.Empty
        Me.BtnCotizacion.Text = "<font size=""+10""><b>COTIZACION</b></font><br/>"
        Me.BtnCotizacion.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.BtnCotizacion.TileSize = New System.Drawing.Size(230, 70)
        '
        '
        '
        Me.BtnCotizacion.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(8, Byte), Integer))
        Me.BtnCotizacion.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(8, Byte), Integer))
        Me.BtnCotizacion.TileStyle.BackColorGradientAngle = 45
        Me.BtnCotizacion.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(8, Byte), Integer))
        Me.BtnCotizacion.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(8, Byte), Integer))
        Me.BtnCotizacion.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.BtnCotizacion.TileStyle.PaddingBottom = 4
        Me.BtnCotizacion.TileStyle.PaddingLeft = 4
        Me.BtnCotizacion.TileStyle.PaddingRight = 4
        Me.BtnCotizacion.TileStyle.PaddingTop = 4
        Me.BtnCotizacion.TileStyle.TextColor = System.Drawing.Color.White
        Me.BtnCotizacion.TitleText = "Documento"
        '
        'BtnNotaDeVenta
        '
        Me.BtnNotaDeVenta.Image = CType(resources.GetObject("BtnNotaDeVenta.Image"), System.Drawing.Image)
        Me.BtnNotaDeVenta.ImageIndent = New System.Drawing.Point(8, -6)
        Me.BtnNotaDeVenta.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnNotaDeVenta.Name = "BtnNotaDeVenta"
        Me.BtnNotaDeVenta.SymbolColor = System.Drawing.Color.Empty
        Me.BtnNotaDeVenta.Text = "<font size=""+10""><b>NOTA VENTA</b></font><br/>"
        Me.BtnNotaDeVenta.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.BtnNotaDeVenta.TileSize = New System.Drawing.Size(230, 70)
        '
        '
        '
        Me.BtnNotaDeVenta.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.BtnNotaDeVenta.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.BtnNotaDeVenta.TileStyle.BackColorGradientAngle = 45
        Me.BtnNotaDeVenta.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.BtnNotaDeVenta.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.BtnNotaDeVenta.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.BtnNotaDeVenta.TileStyle.PaddingBottom = 4
        Me.BtnNotaDeVenta.TileStyle.PaddingLeft = 4
        Me.BtnNotaDeVenta.TileStyle.PaddingRight = 4
        Me.BtnNotaDeVenta.TileStyle.PaddingTop = 4
        Me.BtnNotaDeVenta.TileStyle.TextColor = System.Drawing.Color.White
        Me.BtnNotaDeVenta.TitleText = "Documento"
        Me.BtnNotaDeVenta.Visible = False
        '
        'Frm_Formulario_Cambiar_Doc_Venta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(263, 283)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Formulario_Cambiar_Doc_Venta"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SELECCIONAR DOCUMENTO DE VENTA"
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents MnuEspecialOtros As DevComponents.DotNetBar.ItemContainer
    Public WithEvents BtnBoleta As DevComponents.DotNetBar.Metro.MetroTileItem
    Public WithEvents BtnFactura As DevComponents.DotNetBar.Metro.MetroTileItem
    Public WithEvents BtnCotizacion As DevComponents.DotNetBar.Metro.MetroTileItem
    Public WithEvents BtnNotaDeVenta As DevComponents.DotNetBar.Metro.MetroTileItem
End Class
