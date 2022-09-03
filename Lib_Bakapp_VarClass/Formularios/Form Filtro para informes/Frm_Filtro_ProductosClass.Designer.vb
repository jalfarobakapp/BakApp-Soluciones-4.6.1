<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Filtro_ProductosClass
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Filtro_ProductosClass))
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel
        Me.MnuEspecialOtros = New DevComponents.DotNetBar.ItemContainer
        Me.BtnRubros = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.BtnClasLibre = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.BtnMarca = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.BtnZona = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.BtnFamilias = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.BtnxSalir = New DevComponents.DotNetBar.ButtonItem
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.MetroTilePanel1.Location = New System.Drawing.Point(6, 39)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(281, 301)
        Me.MetroTilePanel1.TabIndex = 21
        Me.MetroTilePanel1.Text = "MetroTilePanel1"
        '
        'MnuEspecialOtros
        '
        '
        '
        '
        Me.MnuEspecialOtros.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MnuEspecialOtros.FixedSize = New System.Drawing.Size(240, 260)
        Me.MnuEspecialOtros.MultiLine = True
        Me.MnuEspecialOtros.Name = "MnuEspecialOtros"
        Me.MnuEspecialOtros.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnRubros, Me.BtnClasLibre, Me.BtnMarca, Me.BtnZona, Me.BtnFamilias})
        '
        '
        '
        Me.MnuEspecialOtros.TitleStyle.Class = "MetroTileGroupTitle"
        Me.MnuEspecialOtros.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MnuEspecialOtros.TitleStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'BtnRubros
        '
        Me.BtnRubros.ImageIndent = New System.Drawing.Point(8, -6)
        Me.BtnRubros.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnRubros.Name = "BtnRubros"
        Me.BtnRubros.SymbolColor = System.Drawing.Color.Empty
        Me.BtnRubros.Text = "<font size=""+6"">Rubros</font><br/>"
        Me.BtnRubros.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.BtnRubros.TileSize = New System.Drawing.Size(230, 50)
        '
        '
        '
        Me.BtnRubros.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BtnRubros.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BtnRubros.TileStyle.BackColorGradientAngle = 45
        Me.BtnRubros.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BtnRubros.TileStyle.PaddingBottom = 4
        Me.BtnRubros.TileStyle.PaddingLeft = 4
        Me.BtnRubros.TileStyle.PaddingRight = 4
        Me.BtnRubros.TileStyle.PaddingTop = 4
        Me.BtnRubros.TileStyle.TextColor = System.Drawing.Color.Black
        Me.BtnRubros.TitleText = "Vale transitorio"
        Me.BtnRubros.TitleTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnRubros.TitleTextColor = System.Drawing.Color.Black
        Me.BtnRubros.TitleTextFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'BtnClasLibre
        '
        Me.BtnClasLibre.ImageIndent = New System.Drawing.Point(8, -6)
        Me.BtnClasLibre.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnClasLibre.Name = "BtnClasLibre"
        Me.BtnClasLibre.SymbolColor = System.Drawing.Color.Empty
        Me.BtnClasLibre.Text = "<font size=""+6"">Clasif. Libre</font><br/>"
        Me.BtnClasLibre.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.BtnClasLibre.TileSize = New System.Drawing.Size(230, 50)
        '
        '
        '
        Me.BtnClasLibre.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.BtnClasLibre.TileStyle.BackColor2 = System.Drawing.Color.MediumSeaGreen
        Me.BtnClasLibre.TileStyle.BackColorGradientAngle = 45
        Me.BtnClasLibre.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BtnClasLibre.TileStyle.PaddingBottom = 4
        Me.BtnClasLibre.TileStyle.PaddingLeft = 4
        Me.BtnClasLibre.TileStyle.PaddingRight = 4
        Me.BtnClasLibre.TileStyle.PaddingTop = 4
        Me.BtnClasLibre.TileStyle.TextColor = System.Drawing.Color.Black
        Me.BtnClasLibre.TitleText = "Vale transitorio"
        Me.BtnClasLibre.TitleTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnClasLibre.TitleTextFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        '
        'BtnMarca
        '
        Me.BtnMarca.ImageIndent = New System.Drawing.Point(8, -6)
        Me.BtnMarca.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnMarca.Name = "BtnMarca"
        Me.BtnMarca.SymbolColor = System.Drawing.Color.Empty
        Me.BtnMarca.Text = "<font size=""+6"">Marcas</font><br/>"
        Me.BtnMarca.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.BtnMarca.TileSize = New System.Drawing.Size(230, 50)
        '
        '
        '
        Me.BtnMarca.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(140, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnMarca.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnMarca.TileStyle.BackColorGradientAngle = 45
        Me.BtnMarca.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BtnMarca.TileStyle.PaddingBottom = 4
        Me.BtnMarca.TileStyle.PaddingLeft = 4
        Me.BtnMarca.TileStyle.PaddingRight = 4
        Me.BtnMarca.TileStyle.PaddingTop = 4
        Me.BtnMarca.TileStyle.TextColor = System.Drawing.Color.Black
        Me.BtnMarca.TitleText = "Vale transitorio"
        Me.BtnMarca.TitleTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnMarca.TitleTextFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        '
        'BtnZona
        '
        Me.BtnZona.ImageIndent = New System.Drawing.Point(8, -6)
        Me.BtnZona.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnZona.Name = "BtnZona"
        Me.BtnZona.SymbolColor = System.Drawing.Color.Empty
        Me.BtnZona.Text = "<font size=""+6"">Zonas</font><br/>"
        Me.BtnZona.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.BtnZona.TileSize = New System.Drawing.Size(230, 50)
        '
        '
        '
        Me.BtnZona.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.BtnZona.TileStyle.BackColor2 = System.Drawing.Color.MediumSeaGreen
        Me.BtnZona.TileStyle.BackColorGradientAngle = 45
        Me.BtnZona.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BtnZona.TileStyle.PaddingBottom = 4
        Me.BtnZona.TileStyle.PaddingLeft = 4
        Me.BtnZona.TileStyle.PaddingRight = 4
        Me.BtnZona.TileStyle.PaddingTop = 4
        Me.BtnZona.TileStyle.TextColor = System.Drawing.Color.Black
        Me.BtnZona.TitleText = "Vale transitorio"
        Me.BtnZona.TitleTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnZona.TitleTextFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        '
        'BtnFamilias
        '
        Me.BtnFamilias.ImageIndent = New System.Drawing.Point(8, -6)
        Me.BtnFamilias.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnFamilias.Name = "BtnFamilias"
        Me.BtnFamilias.SymbolColor = System.Drawing.Color.Empty
        Me.BtnFamilias.Text = "<font size=""+6"">Super Familias</font><br/>"
        Me.BtnFamilias.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.BtnFamilias.TileSize = New System.Drawing.Size(230, 50)
        '
        '
        '
        Me.BtnFamilias.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BtnFamilias.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BtnFamilias.TileStyle.BackColorGradientAngle = 45
        Me.BtnFamilias.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BtnFamilias.TileStyle.PaddingBottom = 4
        Me.BtnFamilias.TileStyle.PaddingLeft = 4
        Me.BtnFamilias.TileStyle.PaddingRight = 4
        Me.BtnFamilias.TileStyle.PaddingTop = 4
        Me.BtnFamilias.TileStyle.TextColor = System.Drawing.Color.Black
        Me.BtnFamilias.TitleText = "Vale transitorio"
        Me.BtnFamilias.TitleTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnFamilias.TitleTextFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        '
        'ReflectionLabel1
        '
        Me.ReflectionLabel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.ForeColor = System.Drawing.Color.Black
        Me.ReflectionLabel1.Location = New System.Drawing.Point(22, -4)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(233, 56)
        Me.ReflectionLabel1.TabIndex = 39
        Me.ReflectionLabel1.Text = "<b><font size=""+8"">F<font color=""#B02B2C"">iltro de productos</font></font></b>"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnxSalir})
        Me.Bar1.Location = New System.Drawing.Point(0, 371)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(275, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 40
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnxSalir
        '
        Me.BtnxSalir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnxSalir.ForeColor = System.Drawing.Color.Black
        Me.BtnxSalir.Image = Nothing 'Global.Funciones_BakApp.My.Resources.Resources.ok_button
        Me.BtnxSalir.Name = "BtnxSalir"
        Me.BtnxSalir.Text = "Aceptar"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(9, 331)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(246, 37)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "Clic con el boton derecho sobre el boton selecciona todo"
        '
        'Frm_Filtro_ProductosClass
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(275, 412)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Filtro_ProductosClass"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Filtros"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents MnuEspecialOtros As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents BtnxSalir As DevComponents.DotNetBar.ButtonItem
    Public WithEvents BtnRubros As DevComponents.DotNetBar.Metro.MetroTileItem
    Public WithEvents BtnClasLibre As DevComponents.DotNetBar.Metro.MetroTileItem
    Public WithEvents BtnMarca As DevComponents.DotNetBar.Metro.MetroTileItem
    Public WithEvents BtnZona As DevComponents.DotNetBar.Metro.MetroTileItem
    Public WithEvents BtnFamilias As DevComponents.DotNetBar.Metro.MetroTileItem
End Class
