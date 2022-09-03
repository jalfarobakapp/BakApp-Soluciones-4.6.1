<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Modulo_CashDro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Modulo_CashDro))
        Me.Bar2 = New DevComponents.DotNetBar.Bar
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel
        Me.MnuEspecialOtros = New DevComponents.DotNetBar.ItemContainer
        Me.Btn_Pago_Proveedores = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.Btn_Pago_Clientes = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSalir})
        Me.Bar2.Location = New System.Drawing.Point(0, 191)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(426, 41)
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
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnSalir.Name = "BtnSalir"
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
        Me.MetroTilePanel1.Location = New System.Drawing.Point(-3, 59)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(641, 132)
        Me.MetroTilePanel1.TabIndex = 36
        Me.MetroTilePanel1.Text = "MetroTilePanel1"
        '
        'MnuEspecialOtros
        '
        '
        '
        '
        Me.MnuEspecialOtros.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MnuEspecialOtros.FixedSize = New System.Drawing.Size(600, 100)
        Me.MnuEspecialOtros.MultiLine = True
        Me.MnuEspecialOtros.Name = "MnuEspecialOtros"
        Me.MnuEspecialOtros.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Pago_Proveedores, Me.Btn_Pago_Clientes})
        '
        '
        '
        Me.MnuEspecialOtros.TitleStyle.Class = "MetroTileGroupTitle"
        Me.MnuEspecialOtros.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'Btn_Pago_Proveedores
        '
        Me.Btn_Pago_Proveedores.Image = CType(resources.GetObject("Btn_Pago_Proveedores.Image"), System.Drawing.Image)
        Me.Btn_Pago_Proveedores.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Pago_Proveedores.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Pago_Proveedores.Name = "Btn_Pago_Proveedores"
        Me.Btn_Pago_Proveedores.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Pago_Proveedores.Text = "<font size=""+4""><b>EJECUTAR</b></font><br/><font size=""-1"">CashDro<br/></font>"
        Me.Btn_Pago_Proveedores.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Yellow
        Me.Btn_Pago_Proveedores.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Pago_Proveedores.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Btn_Pago_Proveedores.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Btn_Pago_Proveedores.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Pago_Proveedores.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Btn_Pago_Proveedores.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Btn_Pago_Proveedores.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Pago_Proveedores.TileStyle.PaddingBottom = 4
        Me.Btn_Pago_Proveedores.TileStyle.PaddingLeft = 4
        Me.Btn_Pago_Proveedores.TileStyle.PaddingRight = 4
        Me.Btn_Pago_Proveedores.TileStyle.PaddingTop = 4
        Me.Btn_Pago_Proveedores.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Pago_Proveedores.TitleTextColor = System.Drawing.Color.White
        '
        'Btn_Pago_Clientes
        '
        Me.Btn_Pago_Clientes.Image = CType(resources.GetObject("Btn_Pago_Clientes.Image"), System.Drawing.Image)
        Me.Btn_Pago_Clientes.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Pago_Clientes.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Pago_Clientes.Name = "Btn_Pago_Clientes"
        Me.Btn_Pago_Clientes.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Pago_Clientes.Text = "<font size=""+4""><b>CONFIGURACION</b></font><br/><font size=""-1"">Configurar CashDr" & _
            "o</font>"
        Me.Btn_Pago_Clientes.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Blueish
        Me.Btn_Pago_Clientes.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Pago_Clientes.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Pago_Clientes.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Pago_Clientes.TileStyle.PaddingBottom = 4
        Me.Btn_Pago_Clientes.TileStyle.PaddingLeft = 4
        Me.Btn_Pago_Clientes.TileStyle.PaddingRight = 4
        Me.Btn_Pago_Clientes.TileStyle.PaddingTop = 4
        Me.Btn_Pago_Clientes.TileStyle.TextColor = System.Drawing.Color.White
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.LabelX1.Location = New System.Drawing.Point(3, 4)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(245, 49)
        Me.LabelX1.TabIndex = 38
        Me.LabelX1.Text = "<font color=""#349FCE""><b>CASHDRO</b></font>"
        '
        'Modulo_CashDro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.Name = "Modulo_CashDro"
        Me.Size = New System.Drawing.Size(426, 232)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents MnuEspecialOtros As DevComponents.DotNetBar.ItemContainer
    Private WithEvents Btn_Pago_Proveedores As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Pago_Clientes As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX

End Class
