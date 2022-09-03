<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cambiar_Codigos_Mnu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cambiar_Codigos_Mnu))
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel
        Me.Bar2 = New DevComponents.DotNetBar.Bar
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel
        Me.ItemContainer1 = New DevComponents.DotNetBar.ItemContainer
        Me.BtnCambiarCodigoUnoxUno = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.BtnCompra_Stock = New DevComponents.DotNetBar.Metro.MetroTileItem
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
        Me.ReflectionLabel1.Size = New System.Drawing.Size(383, 50)
        Me.ReflectionLabel1.TabIndex = 34
        Me.ReflectionLabel1.Text = "<b><font size=""+10""><i>C</i><font color=""#B02B2C"">ambiar códigos de productos</fo" & _
            "nt></font></b>"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSalir})
        Me.Bar2.Location = New System.Drawing.Point(0, 186)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(412, 57)
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
        Me.MetroTilePanel1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer1})
        Me.MetroTilePanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MetroTilePanel1.Location = New System.Drawing.Point(3, 57)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(395, 128)
        Me.MetroTilePanel1.TabIndex = 32
        Me.MetroTilePanel1.Text = "MetroTilePanel1"
        '
        'ItemContainer1
        '
        '
        '
        '
        Me.ItemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer1.MultiLine = True
        Me.ItemContainer1.Name = "ItemContainer1"
        Me.ItemContainer1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnCambiarCodigoUnoxUno, Me.BtnCompra_Stock})
        '
        '
        '
        Me.ItemContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer1.TitleStyle.Font = New System.Drawing.Font("Comic Sans MS", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ItemContainer1.TitleStyle.TextColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(66, Byte), Integer))
        '
        'BtnCambiarCodigoUnoxUno
        '
        Me.BtnCambiarCodigoUnoxUno.Image = CType(resources.GetObject("BtnCambiarCodigoUnoxUno.Image"), System.Drawing.Image)
        Me.BtnCambiarCodigoUnoxUno.ImageIndent = New System.Drawing.Point(9, -10)
        Me.BtnCambiarCodigoUnoxUno.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnCambiarCodigoUnoxUno.Name = "BtnCambiarCodigoUnoxUno"
        Me.BtnCambiarCodigoUnoxUno.SymbolColor = System.Drawing.Color.Empty
        Me.BtnCambiarCodigoUnoxUno.Text = "<font size=""+4"">Uno x Uno</font><br/>Compra Cambiar el código de un producto a la" & _
            " vez" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.BtnCambiarCodigoUnoxUno.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Azure
        '
        '
        '
        Me.BtnCambiarCodigoUnoxUno.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BtnCambiarCodigoUnoxUno.TileStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        '
        'BtnCompra_Stock
        '
        Me.BtnCompra_Stock.Image = CType(resources.GetObject("BtnCompra_Stock.Image"), System.Drawing.Image)
        Me.BtnCompra_Stock.ImageIndent = New System.Drawing.Point(9, -10)
        Me.BtnCompra_Stock.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnCompra_Stock.Name = "BtnCompra_Stock"
        Me.BtnCompra_Stock.SymbolColor = System.Drawing.Color.Empty
        Me.BtnCompra_Stock.Text = "<font size=""+4"">Masivamente</font><br/>Cambio de código de productos en forma mas" & _
            "iva."
        Me.BtnCompra_Stock.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.RedOrange
        '
        '
        '
        Me.BtnCompra_Stock.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BtnCompra_Stock.TileStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        '
        'Cambiar_Codigos_Mnu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.Name = "Cambiar_Codigos_Mnu"
        Me.Size = New System.Drawing.Size(412, 243)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents ItemContainer1 As DevComponents.DotNetBar.ItemContainer
    Private WithEvents BtnCambiarCodigoUnoxUno As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents BtnCompra_Stock As DevComponents.DotNetBar.Metro.MetroTileItem

End Class
