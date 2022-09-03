<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Modulo_Prestashop
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Modulo_Prestashop))
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem()
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel()
        Me.ConsultaPreciosContenedor = New DevComponents.DotNetBar.ItemContainer()
        Me.Btn_Prestashop_Configuracion = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Prestashop_Peticion_Manual = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSalir})
        Me.Bar2.Location = New System.Drawing.Point(0, 209)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(436, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 55
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
        Me.MetroTilePanel1.Location = New System.Drawing.Point(3, 59)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(610, 156)
        Me.MetroTilePanel1.TabIndex = 54
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
        Me.ConsultaPreciosContenedor.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Prestashop_Configuracion, Me.Btn_Prestashop_Peticion_Manual})
        '
        '
        '
        Me.ConsultaPreciosContenedor.TitleStyle.Class = "MetroTileGroupTitle"
        Me.ConsultaPreciosContenedor.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ConsultaPreciosContenedor.TitleStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'Btn_Prestashop_Configuracion
        '
        Me.Btn_Prestashop_Configuracion.Image = CType(resources.GetObject("Btn_Prestashop_Configuracion.Image"), System.Drawing.Image)
        Me.Btn_Prestashop_Configuracion.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Prestashop_Configuracion.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Prestashop_Configuracion.Name = "Btn_Prestashop_Configuracion"
        Me.Btn_Prestashop_Configuracion.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Prestashop_Configuracion.Text = "<font size=""+4""><b>MANTENCION</b>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "</font><br/><font size=""-1"">Configuración de a" &
    "cceso a las bases de datos de las paginas</font>"
        Me.Btn_Prestashop_Configuracion.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Teal
        Me.Btn_Prestashop_Configuracion.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Prestashop_Configuracion.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(168, Byte), Integer))
        Me.Btn_Prestashop_Configuracion.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(168, Byte), Integer))
        Me.Btn_Prestashop_Configuracion.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Prestashop_Configuracion.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(168, Byte), Integer))
        Me.Btn_Prestashop_Configuracion.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(168, Byte), Integer))
        Me.Btn_Prestashop_Configuracion.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Prestashop_Configuracion.TileStyle.PaddingBottom = 4
        Me.Btn_Prestashop_Configuracion.TileStyle.PaddingLeft = 4
        Me.Btn_Prestashop_Configuracion.TileStyle.PaddingRight = 4
        Me.Btn_Prestashop_Configuracion.TileStyle.PaddingTop = 4
        Me.Btn_Prestashop_Configuracion.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Prestashop_Configuracion.TitleText = "BakApp"
        '
        'Btn_Prestashop_Peticion_Manual
        '
        Me.Btn_Prestashop_Peticion_Manual.Image = CType(resources.GetObject("Btn_Prestashop_Peticion_Manual.Image"), System.Drawing.Image)
        Me.Btn_Prestashop_Peticion_Manual.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Prestashop_Peticion_Manual.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Prestashop_Peticion_Manual.Name = "Btn_Prestashop_Peticion_Manual"
        Me.Btn_Prestashop_Peticion_Manual.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Prestashop_Peticion_Manual.Text = "<font size=""+4""><b>PETICION MANUAL</b></font><br/><font size=""-1"">Solicitar actua" &
    "lizar productos seleccionados</font>"
        Me.Btn_Prestashop_Peticion_Manual.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Olive
        Me.Btn_Prestashop_Peticion_Manual.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Prestashop_Peticion_Manual.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Btn_Prestashop_Peticion_Manual.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Btn_Prestashop_Peticion_Manual.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Btn_Prestashop_Peticion_Manual.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Btn_Prestashop_Peticion_Manual.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Prestashop_Peticion_Manual.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Prestashop_Peticion_Manual.TitleText = "BakApp"
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.LabelX1.Location = New System.Drawing.Point(16, 4)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(245, 49)
        Me.LabelX1.TabIndex = 56
        Me.LabelX1.Text = "<font color=""#349FCE""><b>PRESTASHOP</b></font>"
        '
        'Modulo_Prestashop
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.Name = "Modulo_Prestashop"
        Me.Size = New System.Drawing.Size(436, 250)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents ConsultaPreciosContenedor As DevComponents.DotNetBar.ItemContainer
    Private WithEvents Btn_Prestashop_Configuracion As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Prestashop_Peticion_Manual As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX

End Class
