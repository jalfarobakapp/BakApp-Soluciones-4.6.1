<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Sis_ValesDespacho
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
        Me.Bar2 = New DevComponents.DotNetBar.Bar
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem
        Me.BtnConfiguracion = New DevComponents.DotNetBar.ButtonItem
        Me.MetroTilePanel2 = New DevComponents.DotNetBar.Metro.MetroTilePanel
        Me.MnuEspecialPrecios = New DevComponents.DotNetBar.ItemContainer
        Me.BtnModCaja = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.Btn_Retiro_Despacho = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSalir, Me.BtnConfiguracion})
        Me.Bar2.Location = New System.Drawing.Point(0, 230)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(440, 57)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 32
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
        'BtnConfiguracion
        '
        Me.BtnConfiguracion.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnConfiguracion.ForeColor = System.Drawing.Color.Black
        Me.BtnConfiguracion.Image = Global.BakApp.My.Resources.Resources.tools1
        Me.BtnConfiguracion.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnConfiguracion.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnConfiguracion.Name = "BtnConfiguracion"
        Me.BtnConfiguracion.Text = "Configuración local"
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
        Me.MetroTilePanel2.Location = New System.Drawing.Point(17, 75)
        Me.MetroTilePanel2.Name = "MetroTilePanel2"
        Me.MetroTilePanel2.Size = New System.Drawing.Size(440, 149)
        Me.MetroTilePanel2.TabIndex = 35
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
        Me.MnuEspecialPrecios.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnModCaja, Me.Btn_Retiro_Despacho})
        '
        '
        '
        Me.MnuEspecialPrecios.TitleStyle.Class = "MetroTileGroupTitle"
        Me.MnuEspecialPrecios.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'BtnModCaja
        '
        Me.BtnModCaja.Image = Global.BakApp.My.Resources.Resources.shipment_edit
        Me.BtnModCaja.ImageIndent = New System.Drawing.Point(8, -5)
        Me.BtnModCaja.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnModCaja.Name = "BtnModCaja"
        Me.BtnModCaja.SymbolColor = System.Drawing.Color.Empty
        Me.BtnModCaja.Text = "<font size=""+4"">Modulo Caja</font><br/><font size=""-1"">Marcar documentos, nominar" & _
            " boletas, mantención de entidades</font>"
        Me.BtnModCaja.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.RedOrange
        '
        '
        '
        Me.BtnModCaja.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.BtnModCaja.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(158, Byte), Integer))
        Me.BtnModCaja.TileStyle.BackColorGradientAngle = 45
        Me.BtnModCaja.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BtnModCaja.TileStyle.PaddingBottom = 4
        Me.BtnModCaja.TileStyle.PaddingLeft = 4
        Me.BtnModCaja.TileStyle.PaddingRight = 4
        Me.BtnModCaja.TileStyle.PaddingTop = 4
        Me.BtnModCaja.TileStyle.TextColor = System.Drawing.Color.Black
        Me.BtnModCaja.TitleText = "BakApp"
        '
        'Btn_Retiro_Despacho
        '
        Me.Btn_Retiro_Despacho.Image = Global.BakApp.My.Resources.Resources.transport_shipment
        Me.Btn_Retiro_Despacho.ImageIndent = New System.Drawing.Point(8, -5)
        Me.Btn_Retiro_Despacho.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Retiro_Despacho.Name = "Btn_Retiro_Despacho"
        Me.Btn_Retiro_Despacho.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Retiro_Despacho.Text = "<font size=""+4"">Retiro/Despacho</font><br/><font size=""-1"">Despacho a domicilo, i" & _
            "mpresión de vales</font>"
        Me.Btn_Retiro_Despacho.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green
        '
        '
        '
        Me.Btn_Retiro_Despacho.TileStyle.BackColor = System.Drawing.Color.Yellow
        Me.Btn_Retiro_Despacho.TileStyle.BackColor2 = System.Drawing.Color.Yellow
        Me.Btn_Retiro_Despacho.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Retiro_Despacho.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Btn_Retiro_Despacho.TileStyle.PaddingBottom = 4
        Me.Btn_Retiro_Despacho.TileStyle.PaddingLeft = 4
        Me.Btn_Retiro_Despacho.TileStyle.PaddingRight = 4
        Me.Btn_Retiro_Despacho.TileStyle.PaddingTop = 4
        Me.Btn_Retiro_Despacho.TileStyle.TextColor = System.Drawing.Color.Black
        Me.Btn_Retiro_Despacho.TitleText = "BakApp"
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Location = New System.Drawing.Point(3, 7)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(484, 62)
        Me.ReflectionLabel1.TabIndex = 36
        Me.ReflectionLabel1.Text = "<b><font size=""+10""><i>Sistema V</i><font color=""#B02B2C"">ales mercaderia pendien" & _
            "te</font></font></b>"
        '
        'Sis_ValesDespacho
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.MetroTilePanel2)
        Me.Controls.Add(Me.Bar2)
        Me.Name = "Sis_ValesDespacho"
        Me.Size = New System.Drawing.Size(440, 287)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroTilePanel2 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents MnuEspecialPrecios As DevComponents.DotNetBar.ItemContainer
    Private WithEvents BtnModCaja As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Private WithEvents Btn_Retiro_Despacho As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents BtnConfiguracion As DevComponents.DotNetBar.ButtonItem

End Class
