<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Informes_Especial_Cliente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Informes_Especial_Cliente))
        Me.MetroTilePanel2 = New DevComponents.DotNetBar.Metro.MetroTilePanel
        Me.MnuEspecialPrecios = New DevComponents.DotNetBar.ItemContainer
        Me.Btn_Creditos_Vigentes = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.Btn_Comportamiento_De_Pago = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.Btn_Informe_Cheques_En_Cartera = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.Bar2 = New DevComponents.DotNetBar.Bar
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
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
        Me.MetroTilePanel2.Location = New System.Drawing.Point(3, 48)
        Me.MetroTilePanel2.Name = "MetroTilePanel2"
        Me.MetroTilePanel2.Size = New System.Drawing.Size(609, 232)
        Me.MetroTilePanel2.TabIndex = 48
        Me.MetroTilePanel2.Text = "MetroTilePanel2"
        '
        'MnuEspecialPrecios
        '
        '
        '
        '
        Me.MnuEspecialPrecios.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MnuEspecialPrecios.FixedSize = New System.Drawing.Size(450, 200)
        Me.MnuEspecialPrecios.MultiLine = True
        Me.MnuEspecialPrecios.Name = "MnuEspecialPrecios"
        Me.MnuEspecialPrecios.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Creditos_Vigentes, Me.Btn_Comportamiento_De_Pago, Me.Btn_Informe_Cheques_En_Cartera})
        '
        '
        '
        Me.MnuEspecialPrecios.TitleStyle.Class = "MetroTileGroupTitle"
        Me.MnuEspecialPrecios.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'Btn_Creditos_Vigentes
        '
        Me.Btn_Creditos_Vigentes.Image = CType(resources.GetObject("Btn_Creditos_Vigentes.Image"), System.Drawing.Image)
        Me.Btn_Creditos_Vigentes.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Creditos_Vigentes.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Creditos_Vigentes.Name = "Btn_Creditos_Vigentes"
        Me.Btn_Creditos_Vigentes.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Creditos_Vigentes.Text = "<font size=""+4""><b>CREDITOS VIGENTES</b></font><br/><font size=""-1"">..</font>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Btn_Creditos_Vigentes.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.Btn_Creditos_Vigentes.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Creditos_Vigentes.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.Btn_Creditos_Vigentes.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.Btn_Creditos_Vigentes.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Creditos_Vigentes.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.Btn_Creditos_Vigentes.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.Btn_Creditos_Vigentes.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Creditos_Vigentes.TileStyle.PaddingBottom = 4
        Me.Btn_Creditos_Vigentes.TileStyle.PaddingLeft = 4
        Me.Btn_Creditos_Vigentes.TileStyle.PaddingRight = 4
        Me.Btn_Creditos_Vigentes.TileStyle.PaddingTop = 4
        Me.Btn_Creditos_Vigentes.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Creditos_Vigentes.TitleText = "Bakapp"
        '
        'Btn_Comportamiento_De_Pago
        '
        Me.Btn_Comportamiento_De_Pago.Image = CType(resources.GetObject("Btn_Comportamiento_De_Pago.Image"), System.Drawing.Image)
        Me.Btn_Comportamiento_De_Pago.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Comportamiento_De_Pago.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Comportamiento_De_Pago.Name = "Btn_Comportamiento_De_Pago"
        Me.Btn_Comportamiento_De_Pago.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Comportamiento_De_Pago.Text = "<font size=""+4""><b>COMPORTAMIENTOS DE PAGO</b></font><br/><font size=""-1"">..</fon" & _
            "t>"
        Me.Btn_Comportamiento_De_Pago.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Teal
        Me.Btn_Comportamiento_De_Pago.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Comportamiento_De_Pago.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Btn_Comportamiento_De_Pago.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Btn_Comportamiento_De_Pago.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Comportamiento_De_Pago.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Btn_Comportamiento_De_Pago.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Btn_Comportamiento_De_Pago.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Comportamiento_De_Pago.TileStyle.PaddingBottom = 4
        Me.Btn_Comportamiento_De_Pago.TileStyle.PaddingLeft = 4
        Me.Btn_Comportamiento_De_Pago.TileStyle.PaddingRight = 4
        Me.Btn_Comportamiento_De_Pago.TileStyle.PaddingTop = 4
        Me.Btn_Comportamiento_De_Pago.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Comportamiento_De_Pago.TitleText = "Bakapp"
        '
        'Btn_Informe_Cheques_En_Cartera
        '
        Me.Btn_Informe_Cheques_En_Cartera.Image = CType(resources.GetObject("Btn_Informe_Cheques_En_Cartera.Image"), System.Drawing.Image)
        Me.Btn_Informe_Cheques_En_Cartera.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Informe_Cheques_En_Cartera.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Informe_Cheques_En_Cartera.Name = "Btn_Informe_Cheques_En_Cartera"
        Me.Btn_Informe_Cheques_En_Cartera.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Informe_Cheques_En_Cartera.Text = "<font size=""+4""><b>CHEQUES EN CARTERA</b></font><br/><font size=""-1""></font>"
        Me.Btn_Informe_Cheques_En_Cartera.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green
        Me.Btn_Informe_Cheques_En_Cartera.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Informe_Cheques_En_Cartera.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_Informe_Cheques_En_Cartera.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_Informe_Cheques_En_Cartera.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_Informe_Cheques_En_Cartera.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_Informe_Cheques_En_Cartera.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Informe_Cheques_En_Cartera.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Informe_Cheques_En_Cartera.TitleText = "Bakapp"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSalir})
        Me.Bar2.Location = New System.Drawing.Point(0, 276)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(439, 41)
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
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnSalir.Name = "BtnSalir"
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.LabelX1.Location = New System.Drawing.Point(6, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(323, 49)
        Me.LabelX1.TabIndex = 51
        Me.LabelX1.Text = "<font color=""#349FCE""><b>ESPECIALES CLIENTES</b></font>"
        '
        'Informes_Especial_Cliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.MetroTilePanel2)
        Me.Controls.Add(Me.Bar2)
        Me.Name = "Informes_Especial_Cliente"
        Me.Size = New System.Drawing.Size(439, 317)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MetroTilePanel2 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents MnuEspecialPrecios As DevComponents.DotNetBar.ItemContainer
    Private WithEvents Btn_Creditos_Vigentes As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Comportamiento_De_Pago As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Private WithEvents Btn_Informe_Cheques_En_Cartera As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX

End Class
