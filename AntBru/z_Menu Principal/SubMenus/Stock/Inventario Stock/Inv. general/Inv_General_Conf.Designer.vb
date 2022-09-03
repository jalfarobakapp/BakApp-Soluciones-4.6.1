<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Inv_General_Conf
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Inv_General_Conf))
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel
        Me.Bar2 = New DevComponents.DotNetBar.Bar
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel
        Me.ConsultaPreciosContenedor = New DevComponents.DotNetBar.ItemContainer
        Me.BtnPreciosCostos = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.BtnInformes = New DevComponents.DotNetBar.Metro.MetroTileItem
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Location = New System.Drawing.Point(0, 1)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(394, 39)
        Me.ReflectionLabel1.TabIndex = 41
        Me.ReflectionLabel1.Text = "<b><font size=""+10""><i>C</i><font color=""#B02B2C"">onfiguración inventario general" & _
            " </font></font></b>"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSalir})
        Me.Bar2.Location = New System.Drawing.Point(0, 189)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(399, 57)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 40
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
        Me.BtnSalir.Text = "Volver..."
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
        Me.MetroTilePanel1.Location = New System.Drawing.Point(3, 46)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(589, 132)
        Me.MetroTilePanel1.TabIndex = 39
        Me.MetroTilePanel1.Text = "MetroTilePanel1"
        '
        'ConsultaPreciosContenedor
        '
        '
        '
        '
        Me.ConsultaPreciosContenedor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ConsultaPreciosContenedor.FixedSize = New System.Drawing.Size(550, 100)
        Me.ConsultaPreciosContenedor.MultiLine = True
        Me.ConsultaPreciosContenedor.Name = "ConsultaPreciosContenedor"
        Me.ConsultaPreciosContenedor.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnPreciosCostos, Me.BtnInformes})
        '
        '
        '
        Me.ConsultaPreciosContenedor.TitleStyle.Class = "MetroTileGroupTitle"
        Me.ConsultaPreciosContenedor.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ConsultaPreciosContenedor.TitleStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'BtnPreciosCostos
        '
        Me.BtnPreciosCostos.Image = CType(resources.GetObject("BtnPreciosCostos.Image"), System.Drawing.Image)
        Me.BtnPreciosCostos.ImageIndent = New System.Drawing.Point(8, -6)
        Me.BtnPreciosCostos.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnPreciosCostos.Name = "BtnPreciosCostos"
        Me.BtnPreciosCostos.SymbolColor = System.Drawing.Color.Empty
        Me.BtnPreciosCostos.Text = "<font size=""+4"">Ubicaciones</font><br/><font size=""-1"">Ubicación, Sector, Pasillo" & _
            "</font>"
        Me.BtnPreciosCostos.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        '
        '
        '
        Me.BtnPreciosCostos.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.BtnPreciosCostos.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.BtnPreciosCostos.TileStyle.BackColorGradientAngle = 45
        Me.BtnPreciosCostos.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BtnPreciosCostos.TileStyle.PaddingBottom = 4
        Me.BtnPreciosCostos.TileStyle.PaddingLeft = 4
        Me.BtnPreciosCostos.TileStyle.PaddingRight = 4
        Me.BtnPreciosCostos.TileStyle.PaddingTop = 4
        Me.BtnPreciosCostos.TileStyle.TextColor = System.Drawing.Color.White
        Me.BtnPreciosCostos.TitleText = "BakApp"
        '
        'BtnInformes
        '
        Me.BtnInformes.Image = CType(resources.GetObject("BtnInformes.Image"), System.Drawing.Image)
        Me.BtnInformes.ImageIndent = New System.Drawing.Point(8, -6)
        Me.BtnInformes.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnInformes.Name = "BtnInformes"
        Me.BtnInformes.SymbolColor = System.Drawing.Color.Empty
        Me.BtnInformes.Text = "<font size=""+4"">Usuarios</font><br/><font size=""-1"">Configuración usuarios lidere" & _
            "s</font>"
        Me.BtnInformes.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        '
        '
        '
        Me.BtnInformes.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnInformes.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnInformes.TileStyle.BackColorGradientAngle = 45
        Me.BtnInformes.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BtnInformes.TileStyle.PaddingBottom = 4
        Me.BtnInformes.TileStyle.PaddingLeft = 4
        Me.BtnInformes.TileStyle.PaddingRight = 4
        Me.BtnInformes.TileStyle.PaddingTop = 4
        Me.BtnInformes.TileStyle.TextColor = System.Drawing.Color.White
        Me.BtnInformes.TitleText = "BakApp"
        '
        'Inv_General_Conf
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.Name = "Inv_General_Conf"
        Me.Size = New System.Drawing.Size(399, 246)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents ConsultaPreciosContenedor As DevComponents.DotNetBar.ItemContainer
    Private WithEvents BtnPreciosCostos As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents BtnInformes As DevComponents.DotNetBar.Metro.MetroTileItem

End Class
