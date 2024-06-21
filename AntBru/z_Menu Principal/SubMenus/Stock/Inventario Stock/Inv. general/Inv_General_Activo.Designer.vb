<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Inv_General_Activo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Inv_General_Activo))
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnConfiguracion = New DevComponents.DotNetBar.ButtonItem()
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel()
        Me.ConsultaPreciosContenedor = New DevComponents.DotNetBar.ItemContainer()
        Me.Btn_VerInventarioActivo = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Mant_Inventarios = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.MetroTileItem1 = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.MStb_Barra = New DevComponents.DotNetBar.Metro.MetroStatusBar()
        Me.Lbl_InventarioActivo = New DevComponents.DotNetBar.LabelItem()
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
        Me.LabelX1.Size = New System.Drawing.Size(318, 35)
        Me.LabelX1.TabIndex = 41
        Me.LabelX1.Text = "<font color=""#349FCE""><b>INVENTARIO GENERAL</b></font>"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSalir, Me.BtnConfiguracion})
        Me.Bar2.Location = New System.Drawing.Point(0, 169)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(636, 41)
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
        Me.BtnSalir.Tooltip = "Salir"
        '
        'BtnConfiguracion
        '
        Me.BtnConfiguracion.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnConfiguracion.ForeColor = System.Drawing.Color.Black
        Me.BtnConfiguracion.Image = CType(resources.GetObject("BtnConfiguracion.Image"), System.Drawing.Image)
        Me.BtnConfiguracion.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnConfiguracion.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnConfiguracion.Name = "BtnConfiguracion"
        Me.BtnConfiguracion.Tooltip = "Configuración"
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
        Me.MetroTilePanel1.Location = New System.Drawing.Point(3, 44)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(688, 144)
        Me.MetroTilePanel1.TabIndex = 39
        Me.MetroTilePanel1.Text = "MetroTilePanel1"
        '
        'ConsultaPreciosContenedor
        '
        '
        '
        '
        Me.ConsultaPreciosContenedor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ConsultaPreciosContenedor.FixedSize = New System.Drawing.Size(650, 100)
        Me.ConsultaPreciosContenedor.MultiLine = True
        Me.ConsultaPreciosContenedor.Name = "ConsultaPreciosContenedor"
        Me.ConsultaPreciosContenedor.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_VerInventarioActivo, Me.Btn_Mant_Inventarios, Me.MetroTileItem1})
        '
        '
        '
        Me.ConsultaPreciosContenedor.TitleStyle.Class = "MetroTileGroupTitle"
        Me.ConsultaPreciosContenedor.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ConsultaPreciosContenedor.TitleStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'Btn_VerInventarioActivo
        '
        Me.Btn_VerInventarioActivo.Image = CType(resources.GetObject("Btn_VerInventarioActivo.Image"), System.Drawing.Image)
        Me.Btn_VerInventarioActivo.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_VerInventarioActivo.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_VerInventarioActivo.Name = "Btn_VerInventarioActivo"
        Me.Btn_VerInventarioActivo.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_VerInventarioActivo.Text = "<font size=""+4""><b>VER INVENTARIO ACTIVO</b></font><br/><font size=""-1"">Revisar G" &
    "estión de inventario actual</font>"
        Me.Btn_VerInventarioActivo.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.Btn_VerInventarioActivo.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_VerInventarioActivo.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_VerInventarioActivo.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_VerInventarioActivo.TileStyle.BackColorGradientAngle = 45
        Me.Btn_VerInventarioActivo.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_VerInventarioActivo.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_VerInventarioActivo.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_VerInventarioActivo.TileStyle.PaddingBottom = 4
        Me.Btn_VerInventarioActivo.TileStyle.PaddingLeft = 4
        Me.Btn_VerInventarioActivo.TileStyle.PaddingRight = 4
        Me.Btn_VerInventarioActivo.TileStyle.PaddingTop = 4
        Me.Btn_VerInventarioActivo.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_VerInventarioActivo.TitleText = "BakApp"
        '
        'Btn_Mant_Inventarios
        '
        Me.Btn_Mant_Inventarios.Image = CType(resources.GetObject("Btn_Mant_Inventarios.Image"), System.Drawing.Image)
        Me.Btn_Mant_Inventarios.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Mant_Inventarios.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Mant_Inventarios.Name = "Btn_Mant_Inventarios"
        Me.Btn_Mant_Inventarios.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Mant_Inventarios.Text = "<font size=""+4""><b>VER SECTORES</b></font><br/><font size=""-1"">Ver estado de avan" &
    "ce por sector</font>"
        Me.Btn_Mant_Inventarios.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.Btn_Mant_Inventarios.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Mant_Inventarios.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.Btn_Mant_Inventarios.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.Btn_Mant_Inventarios.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Mant_Inventarios.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.Btn_Mant_Inventarios.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.Btn_Mant_Inventarios.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Mant_Inventarios.TileStyle.PaddingBottom = 4
        Me.Btn_Mant_Inventarios.TileStyle.PaddingLeft = 4
        Me.Btn_Mant_Inventarios.TileStyle.PaddingRight = 4
        Me.Btn_Mant_Inventarios.TileStyle.PaddingTop = 4
        Me.Btn_Mant_Inventarios.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Mant_Inventarios.TitleText = "BakApp"
        '
        'MetroTileItem1
        '
        Me.MetroTileItem1.Image = CType(resources.GetObject("MetroTileItem1.Image"), System.Drawing.Image)
        Me.MetroTileItem1.ImageIndent = New System.Drawing.Point(8, -10)
        Me.MetroTileItem1.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.MetroTileItem1.Name = "MetroTileItem1"
        Me.MetroTileItem1.SymbolColor = System.Drawing.Color.Empty
        Me.MetroTileItem1.Text = "<font size=""+4""><b>INGRESAR HOJA</b></font><br/><font size=""-1"">Ingresar conteo d" &
    "e productos</font>"
        Me.MetroTileItem1.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.MetroTileItem1.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.MetroTileItem1.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.MetroTileItem1.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.MetroTileItem1.TileStyle.BackColorGradientAngle = 45
        Me.MetroTileItem1.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.MetroTileItem1.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.MetroTileItem1.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.MetroTileItem1.TileStyle.PaddingBottom = 4
        Me.MetroTileItem1.TileStyle.PaddingLeft = 4
        Me.MetroTileItem1.TileStyle.PaddingRight = 4
        Me.MetroTileItem1.TileStyle.PaddingTop = 4
        Me.MetroTileItem1.TileStyle.TextColor = System.Drawing.Color.White
        Me.MetroTileItem1.TitleText = "BakApp"
        '
        'MStb_Barra
        '
        '
        '
        '
        Me.MStb_Barra.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MStb_Barra.ContainerControlProcessDialogKey = True
        Me.MStb_Barra.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.MStb_Barra.DragDropSupport = True
        Me.MStb_Barra.Font = New System.Drawing.Font("Segoe UI", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MStb_Barra.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Lbl_InventarioActivo})
        Me.MStb_Barra.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MStb_Barra.Location = New System.Drawing.Point(0, 210)
        Me.MStb_Barra.Name = "MStb_Barra"
        Me.MStb_Barra.Size = New System.Drawing.Size(636, 22)
        Me.MStb_Barra.TabIndex = 66
        Me.MStb_Barra.Text = "MetroStatusBar1"
        '
        'Lbl_InventarioActivo
        '
        Me.Lbl_InventarioActivo.Name = "Lbl_InventarioActivo"
        Me.Lbl_InventarioActivo.Text = "Ambiente de producción"
        '
        'Inv_General_Activo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.Controls.Add(Me.MStb_Barra)
        Me.Name = "Inv_General_Activo"
        Me.Size = New System.Drawing.Size(636, 232)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnConfiguracion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents ConsultaPreciosContenedor As DevComponents.DotNetBar.ItemContainer
    Private WithEvents Btn_VerInventarioActivo As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Mant_Inventarios As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents MetroTileItem1 As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents MStb_Barra As DevComponents.DotNetBar.Metro.MetroStatusBar
    Friend WithEvents Lbl_InventarioActivo As DevComponents.DotNetBar.LabelItem
End Class
