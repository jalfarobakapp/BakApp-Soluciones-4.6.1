<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ModCaja_01
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
        Me.MetroTilePanel2 = New DevComponents.DotNetBar.Metro.MetroTilePanel
        Me.MnuEspecialPrecios = New DevComponents.DotNetBar.ItemContainer
        Me.BtnMarcar_Documentos = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.BtnNominarBoleta = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.Bar2 = New DevComponents.DotNetBar.Bar
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem
        Me.ReflectionLabel2 = New DevComponents.DotNetBar.Controls.ReflectionLabel
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MetroTilePanel2
        '
        Me.MetroTilePanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.MetroTilePanel2.BackgroundStyle.Class = "MetroTilePanel"
        Me.MetroTilePanel2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MetroTilePanel2.ContainerControlProcessDialogKey = True
        Me.MetroTilePanel2.DragDropSupport = True
        Me.MetroTilePanel2.ForeColor = System.Drawing.Color.Black
        Me.MetroTilePanel2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.MnuEspecialPrecios})
        Me.MetroTilePanel2.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MetroTilePanel2.Location = New System.Drawing.Point(3, 61)
        Me.MetroTilePanel2.Name = "MetroTilePanel2"
        Me.MetroTilePanel2.Size = New System.Drawing.Size(609, 136)
        Me.MetroTilePanel2.TabIndex = 38
        Me.MetroTilePanel2.Text = "MetroTilePanel2"
        '
        'MnuEspecialPrecios
        '
        '
        '
        '
        Me.MnuEspecialPrecios.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MnuEspecialPrecios.FixedSize = New System.Drawing.Size(400, 100)
        Me.MnuEspecialPrecios.MultiLine = True
        Me.MnuEspecialPrecios.Name = "MnuEspecialPrecios"
        Me.MnuEspecialPrecios.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnMarcar_Documentos, Me.BtnNominarBoleta})
        '
        '
        '
        Me.MnuEspecialPrecios.TitleStyle.Class = "MetroTileGroupTitle"
        Me.MnuEspecialPrecios.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'BtnMarcar_Documentos
        '
        Me.BtnMarcar_Documentos.Image = Global.BakApp.My.Resources.Resources.account_book_info
        Me.BtnMarcar_Documentos.ImageIndent = New System.Drawing.Point(8, -8)
        Me.BtnMarcar_Documentos.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnMarcar_Documentos.Name = "BtnMarcar_Documentos"
        Me.BtnMarcar_Documentos.SymbolColor = System.Drawing.Color.Empty
        Me.BtnMarcar_Documentos.Text = "<font size=""+8"">Marcar</font><br/><font size=""-1"">Marcar Boleta o Factura para re" & _
            "tiro o despacho</font>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.BtnMarcar_Documentos.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        '
        '
        '
        Me.BtnMarcar_Documentos.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.BtnMarcar_Documentos.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.BtnMarcar_Documentos.TileStyle.BackColorGradientAngle = 45
        Me.BtnMarcar_Documentos.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BtnMarcar_Documentos.TileStyle.PaddingBottom = 4
        Me.BtnMarcar_Documentos.TileStyle.PaddingLeft = 4
        Me.BtnMarcar_Documentos.TileStyle.PaddingRight = 4
        Me.BtnMarcar_Documentos.TileStyle.PaddingTop = 4
        Me.BtnMarcar_Documentos.TileStyle.TextColor = System.Drawing.Color.White
        Me.BtnMarcar_Documentos.TitleText = "BakApp"
        '
        'BtnNominarBoleta
        '
        Me.BtnNominarBoleta.Image = Global.BakApp.My.Resources.Resources.record_user
        Me.BtnNominarBoleta.ImageIndent = New System.Drawing.Point(8, -5)
        Me.BtnNominarBoleta.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnNominarBoleta.Name = "BtnNominarBoleta"
        Me.BtnNominarBoleta.SymbolColor = System.Drawing.Color.Empty
        Me.BtnNominarBoleta.Text = "<font size=""+4"">Nominar Boleta</font><br/><font size=""-1"">Cambiar entidad del doc" & _
            "umento, creación de entiades</font>"
        Me.BtnNominarBoleta.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        '
        '
        '
        Me.BtnNominarBoleta.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.BtnNominarBoleta.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(158, Byte), Integer))
        Me.BtnNominarBoleta.TileStyle.BackColorGradientAngle = 45
        Me.BtnNominarBoleta.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BtnNominarBoleta.TileStyle.PaddingBottom = 4
        Me.BtnNominarBoleta.TileStyle.PaddingLeft = 4
        Me.BtnNominarBoleta.TileStyle.PaddingRight = 4
        Me.BtnNominarBoleta.TileStyle.PaddingTop = 4
        Me.BtnNominarBoleta.TileStyle.TextColor = System.Drawing.Color.White
        Me.BtnNominarBoleta.TitleText = "BakApp"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSalir})
        Me.Bar2.Location = New System.Drawing.Point(0, 201)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(414, 57)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 37
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
        'ReflectionLabel2
        '
        '
        '
        '
        Me.ReflectionLabel2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel2.Location = New System.Drawing.Point(3, 3)
        Me.ReflectionLabel2.Name = "ReflectionLabel2"
        Me.ReflectionLabel2.Size = New System.Drawing.Size(215, 62)
        Me.ReflectionLabel2.TabIndex = 40
        Me.ReflectionLabel2.Text = "<b><font size=""+10""><i>M</i><font color=""#B02B2C"">odulo cajas.</font></font></b>"
        '
        'ModCaja_01
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ReflectionLabel2)
        Me.Controls.Add(Me.MetroTilePanel2)
        Me.Controls.Add(Me.Bar2)
        Me.Name = "ModCaja_01"
        Me.Size = New System.Drawing.Size(414, 258)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MetroTilePanel2 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents MnuEspecialPrecios As DevComponents.DotNetBar.ItemContainer
    Private WithEvents BtnMarcar_Documentos As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents BtnNominarBoleta As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ReflectionLabel2 As DevComponents.DotNetBar.Controls.ReflectionLabel

End Class
