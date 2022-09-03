<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Huellas_Menu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Huellas_Menu))
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel()
        Me.ConsultaPreciosContenedor = New DevComponents.DotNetBar.ItemContainer()
        Me.Btn_UareU4500 = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_ZK4500 = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.SuspendLayout()
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
        Me.MetroTilePanel1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ConsultaPreciosContenedor})
        Me.MetroTilePanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MetroTilePanel1.Location = New System.Drawing.Point(54, 23)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(232, 389)
        Me.MetroTilePanel1.TabIndex = 136
        Me.MetroTilePanel1.Text = "MetroTilePanel1"
        '
        'ConsultaPreciosContenedor
        '
        '
        '
        '
        Me.ConsultaPreciosContenedor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ConsultaPreciosContenedor.FixedSize = New System.Drawing.Size(200, 300)
        Me.ConsultaPreciosContenedor.MultiLine = True
        Me.ConsultaPreciosContenedor.Name = "ConsultaPreciosContenedor"
        Me.ConsultaPreciosContenedor.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_UareU4500, Me.Btn_ZK4500})
        '
        '
        '
        Me.ConsultaPreciosContenedor.TitleStyle.Class = "MetroTileGroupTitle"
        Me.ConsultaPreciosContenedor.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ConsultaPreciosContenedor.TitleStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'Btn_UareU4500
        '
        Me.Btn_UareU4500.Image = CType(resources.GetObject("Btn_UareU4500.Image"), System.Drawing.Image)
        Me.Btn_UareU4500.ImageIndent = New System.Drawing.Point(10, -10)
        Me.Btn_UareU4500.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_UareU4500.Name = "Btn_UareU4500"
        Me.Btn_UareU4500.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_UareU4500.Text = "<font size=""+4""><b>LECTOR<br/>U.are.U 4500</b></font><br/><font size=""-1"">Registr" &
    "o de Huellas</font>"
        Me.Btn_UareU4500.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.Btn_UareU4500.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_UareU4500.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Btn_UareU4500.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Btn_UareU4500.TileStyle.BackColorGradientAngle = 45
        Me.Btn_UareU4500.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Btn_UareU4500.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Btn_UareU4500.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_UareU4500.TileStyle.PaddingBottom = 4
        Me.Btn_UareU4500.TileStyle.PaddingLeft = 4
        Me.Btn_UareU4500.TileStyle.PaddingRight = 4
        Me.Btn_UareU4500.TileStyle.PaddingTop = 4
        Me.Btn_UareU4500.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_UareU4500.TitleText = "BakApp"
        '
        'Btn_ZK4500
        '
        Me.Btn_ZK4500.Image = CType(resources.GetObject("Btn_ZK4500.Image"), System.Drawing.Image)
        Me.Btn_ZK4500.ImageIndent = New System.Drawing.Point(10, -10)
        Me.Btn_ZK4500.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_ZK4500.Name = "Btn_ZK4500"
        Me.Btn_ZK4500.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_ZK4500.Text = "<font size=""+4""><b>LECTOR<br/>ZKTeco ZK4500</b></font><br/><font size=""-1"">Regist" &
    "ro de Huellas</font>"
        Me.Btn_ZK4500.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.Btn_ZK4500.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_ZK4500.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.Btn_ZK4500.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.Btn_ZK4500.TileStyle.BackColorGradientAngle = 45
        Me.Btn_ZK4500.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.Btn_ZK4500.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.Btn_ZK4500.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_ZK4500.TileStyle.PaddingBottom = 4
        Me.Btn_ZK4500.TileStyle.PaddingLeft = 4
        Me.Btn_ZK4500.TileStyle.PaddingRight = 4
        Me.Btn_ZK4500.TileStyle.PaddingTop = 4
        Me.Btn_ZK4500.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_ZK4500.TitleText = "BakApp"
        '
        'Frm_Huellas_Menu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(340, 296)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Huellas_Menu"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LECTORES AUTORIZADOS"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents ConsultaPreciosContenedor As DevComponents.DotNetBar.ItemContainer
    Private WithEvents Btn_UareU4500 As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_ZK4500 As DevComponents.DotNetBar.Metro.MetroTileItem
End Class
