<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Sistema_Despachos
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Sistema_Despachos))
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Configuración = New DevComponents.DotNetBar.ButtonItem()
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel()
        Me.ContenedorTablas = New DevComponents.DotNetBar.ItemContainer()
        Me.Btn_Ordenes_De_Despacho = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_En_Proceso = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSalir, Me.Btn_Configuración})
        Me.Bar2.Location = New System.Drawing.Point(0, 204)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(449, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 42
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
        'Btn_Configuración
        '
        Me.Btn_Configuración.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Configuración.Image = CType(resources.GetObject("Btn_Configuración.Image"), System.Drawing.Image)
        Me.Btn_Configuración.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.Btn_Configuración.Name = "Btn_Configuración"
        Me.Btn_Configuración.Tooltip = "Configuración"
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
        Me.MetroTilePanel1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ContenedorTablas})
        Me.MetroTilePanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MetroTilePanel1.Location = New System.Drawing.Point(6, 56)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(672, 419)
        Me.MetroTilePanel1.TabIndex = 41
        Me.MetroTilePanel1.Text = "MetroTilePanel1"
        '
        'ContenedorTablas
        '
        '
        '
        '
        Me.ContenedorTablas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ContenedorTablas.FixedSize = New System.Drawing.Size(630, 300)
        Me.ContenedorTablas.MultiLine = True
        Me.ContenedorTablas.Name = "ContenedorTablas"
        Me.ContenedorTablas.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Ordenes_De_Despacho, Me.Btn_En_Proceso})
        '
        '
        '
        Me.ContenedorTablas.TitleStyle.Class = "MetroTileGroupTitle"
        Me.ContenedorTablas.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'Btn_Ordenes_De_Despacho
        '
        Me.Btn_Ordenes_De_Despacho.Image = CType(resources.GetObject("Btn_Ordenes_De_Despacho.Image"), System.Drawing.Image)
        Me.Btn_Ordenes_De_Despacho.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Ordenes_De_Despacho.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Ordenes_De_Despacho.Name = "Btn_Ordenes_De_Despacho"
        Me.Btn_Ordenes_De_Despacho.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Ordenes_De_Despacho.Text = "<font size=""+4""><b>ORDENES DE DESPACHO</b></font><br/><font size=""-1"">Crear y rev" &
    "isar reclamos</font>"
        Me.Btn_Ordenes_De_Despacho.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Yellow
        Me.Btn_Ordenes_De_Despacho.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Ordenes_De_Despacho.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(18, Byte), Integer))
        Me.Btn_Ordenes_De_Despacho.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(18, Byte), Integer))
        Me.Btn_Ordenes_De_Despacho.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Ordenes_De_Despacho.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(18, Byte), Integer))
        Me.Btn_Ordenes_De_Despacho.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(18, Byte), Integer))
        Me.Btn_Ordenes_De_Despacho.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Ordenes_De_Despacho.TileStyle.PaddingBottom = 4
        Me.Btn_Ordenes_De_Despacho.TileStyle.PaddingLeft = 4
        Me.Btn_Ordenes_De_Despacho.TileStyle.PaddingRight = 4
        Me.Btn_Ordenes_De_Despacho.TileStyle.PaddingTop = 4
        Me.Btn_Ordenes_De_Despacho.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Ordenes_De_Despacho.TitleText = "BakApp"
        '
        'Btn_En_Proceso
        '
        Me.Btn_En_Proceso.Image = CType(resources.GetObject("Btn_En_Proceso.Image"), System.Drawing.Image)
        Me.Btn_En_Proceso.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_En_Proceso.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_En_Proceso.Name = "Btn_En_Proceso"
        Me.Btn_En_Proceso.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_En_Proceso.Text = "<font size=""+4""><b>DESPACHOS EN PROCESO</b></font><br/><font size=""-1"">Ordens de " &
    "la Sucursal/Bodega</font>"
        Me.Btn_En_Proceso.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Yellow
        Me.Btn_En_Proceso.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_En_Proceso.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.Btn_En_Proceso.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.Btn_En_Proceso.TileStyle.BackColorGradientAngle = 45
        Me.Btn_En_Proceso.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.Btn_En_Proceso.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.Btn_En_Proceso.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_En_Proceso.TileStyle.PaddingBottom = 4
        Me.Btn_En_Proceso.TileStyle.PaddingLeft = 4
        Me.Btn_En_Proceso.TileStyle.PaddingRight = 4
        Me.Btn_En_Proceso.TileStyle.PaddingTop = 4
        Me.Btn_En_Proceso.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_En_Proceso.TitleText = "BakApp"
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
        Me.LabelX1.Size = New System.Drawing.Size(383, 49)
        Me.LabelX1.TabIndex = 43
        Me.LabelX1.Text = "<font color=""#349FCE""><b>SISTEMA DE DESPACHOS</b></font>"
        '
        'Sistema_Despachos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.Name = "Sistema_Despachos"
        Me.Size = New System.Drawing.Size(449, 245)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Configuración As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents ContenedorTablas As DevComponents.DotNetBar.ItemContainer
    Private WithEvents Btn_Ordenes_De_Despacho As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_En_Proceso As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
End Class
