<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Modulo_Huellas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Modulo_Huellas))
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem()
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel()
        Me.ConsultaPreciosContenedor = New DevComponents.DotNetBar.ItemContainer()
        Me.Btn_UareU4500 = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_ZK4500 = New DevComponents.DotNetBar.Metro.MetroTileItem()
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
        Me.LabelX1.Location = New System.Drawing.Point(3, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(245, 49)
        Me.LabelX1.TabIndex = 59
        Me.LabelX1.Text = "<font color=""#349FCE""><b>PRESTASHOP</b></font>"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSalir})
        Me.Bar2.Location = New System.Drawing.Point(0, 198)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(437, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 58
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
        Me.MetroTilePanel1.Location = New System.Drawing.Point(3, 58)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(610, 156)
        Me.MetroTilePanel1.TabIndex = 57
        Me.MetroTilePanel1.Text = "MetroTilePanel1"
        '
        'ConsultaPreciosContenedor
        '
        '
        '
        '
        Me.ConsultaPreciosContenedor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ConsultaPreciosContenedor.FixedSize = New System.Drawing.Size(500, 120)
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
        'Modulo_Huellas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.Name = "Modulo_Huellas"
        Me.Size = New System.Drawing.Size(437, 239)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents ConsultaPreciosContenedor As DevComponents.DotNetBar.ItemContainer
    Private WithEvents Btn_UareU4500 As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_ZK4500 As DevComponents.DotNetBar.Metro.MetroTileItem
End Class
