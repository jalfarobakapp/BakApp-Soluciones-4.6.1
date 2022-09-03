<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Mant_Productos
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
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel
        Me.Bar2 = New DevComponents.DotNetBar.Bar
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel
        Me.ConsultaPreciosContenedor = New DevComponents.DotNetBar.ItemContainer
        Me.BtnCP_Clasico = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.BtnCP_Matriz = New DevComponents.DotNetBar.Metro.MetroTileItem
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Location = New System.Drawing.Point(3, 0)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(318, 54)
        Me.ReflectionLabel1.TabIndex = 47
        Me.ReflectionLabel1.Text = "<b><font size=""+10""><i>C</i><font color=""#B02B2C"">rear productos </font></font></" & _
            "b>"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSalir})
        Me.Bar2.Location = New System.Drawing.Point(0, 177)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(382, 57)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 46
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'BtnSalir
        '
        Me.BtnSalir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnSalir.ForeColor = System.Drawing.Color.Black
        Me.BtnSalir.Image = Global.BakApp.My.Resources.Resources.button_circle_left
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
        Me.MetroTilePanel1.Location = New System.Drawing.Point(-4, 60)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(589, 132)
        Me.MetroTilePanel1.TabIndex = 45
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
        Me.ConsultaPreciosContenedor.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnCP_Clasico, Me.BtnCP_Matriz})
        '
        '
        '
        Me.ConsultaPreciosContenedor.TitleStyle.Class = "MetroTileGroupTitle"
        Me.ConsultaPreciosContenedor.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ConsultaPreciosContenedor.TitleStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'BtnCP_Clasico
        '
        Me.BtnCP_Clasico.Image = Global.BakApp.My.Resources.Resources.sheet_shipment
        Me.BtnCP_Clasico.ImageIndent = New System.Drawing.Point(8, -6)
        Me.BtnCP_Clasico.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnCP_Clasico.Name = "BtnCP_Clasico"
        Me.BtnCP_Clasico.SymbolColor = System.Drawing.Color.Empty
        Me.BtnCP_Clasico.Text = "<font size=""+4"">Crear productos Clasico</font><br/><font size=""-1"">Mantención del" & _
            " maestro de productos</font>"
        Me.BtnCP_Clasico.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green
        '
        '
        '
        Me.BtnCP_Clasico.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnCP_Clasico.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(172, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnCP_Clasico.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BtnCP_Clasico.TileStyle.TextColor = System.Drawing.Color.White
        Me.BtnCP_Clasico.TitleText = "BakApp"
        '
        'BtnCP_Matriz
        '
        Me.BtnCP_Matriz.Image = Global.BakApp.My.Resources.Resources.table
        Me.BtnCP_Matriz.ImageIndent = New System.Drawing.Point(8, -6)
        Me.BtnCP_Matriz.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnCP_Matriz.Name = "BtnCP_Matriz"
        Me.BtnCP_Matriz.SymbolColor = System.Drawing.Color.Empty
        Me.BtnCP_Matriz.Text = "<font size=""+4"">Crear productos Matriz</font><br/><font size=""-1"">Mantención del " & _
            "maestro de productos</font>"
        Me.BtnCP_Matriz.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        '
        '
        '
        Me.BtnCP_Matriz.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnCP_Matriz.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(121, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnCP_Matriz.TileStyle.BackColorGradientAngle = 45
        Me.BtnCP_Matriz.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BtnCP_Matriz.TileStyle.PaddingBottom = 4
        Me.BtnCP_Matriz.TileStyle.PaddingLeft = 4
        Me.BtnCP_Matriz.TileStyle.PaddingRight = 4
        Me.BtnCP_Matriz.TileStyle.PaddingTop = 4
        Me.BtnCP_Matriz.TileStyle.TextColor = System.Drawing.Color.White
        Me.BtnCP_Matriz.TitleText = "BakApp"
        '
        'Mant_Productos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.Name = "Mant_Productos"
        Me.Size = New System.Drawing.Size(382, 234)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents ConsultaPreciosContenedor As DevComponents.DotNetBar.ItemContainer
    Private WithEvents BtnCP_Clasico As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents BtnCP_Matriz As DevComponents.DotNetBar.Metro.MetroTileItem

End Class
