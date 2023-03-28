<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Modulo_Servicio_Tecnico
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Modulo_Servicio_Tecnico))
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem()
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel()
        Me.ConsultaPreciosContenedor = New DevComponents.DotNetBar.ItemContainer()
        Me.Btn_Sis_Serv_Tecnico = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Configuraciones = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Sis_Serv_GestTaller = New DevComponents.DotNetBar.Metro.MetroTileItem()
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
        Me.Bar2.Location = New System.Drawing.Point(0, 286)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(437, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 43
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
        Me.MetroTilePanel1.Location = New System.Drawing.Point(3, 57)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(586, 445)
        Me.MetroTilePanel1.TabIndex = 42
        Me.MetroTilePanel1.Text = "MetroTilePanel1"
        '
        'ConsultaPreciosContenedor
        '
        '
        '
        '
        Me.ConsultaPreciosContenedor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ConsultaPreciosContenedor.FixedSize = New System.Drawing.Size(500, 400)
        Me.ConsultaPreciosContenedor.MultiLine = True
        Me.ConsultaPreciosContenedor.Name = "ConsultaPreciosContenedor"
        Me.ConsultaPreciosContenedor.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Sis_Serv_Tecnico, Me.Btn_Configuraciones, Me.Btn_Sis_Serv_GestTaller})
        '
        '
        '
        Me.ConsultaPreciosContenedor.TitleStyle.Class = "MetroTileGroupTitle"
        Me.ConsultaPreciosContenedor.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ConsultaPreciosContenedor.TitleStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'Btn_Sis_Serv_Tecnico
        '
        Me.Btn_Sis_Serv_Tecnico.Image = CType(resources.GetObject("Btn_Sis_Serv_Tecnico.Image"), System.Drawing.Image)
        Me.Btn_Sis_Serv_Tecnico.ImageIndent = New System.Drawing.Point(8, -6)
        Me.Btn_Sis_Serv_Tecnico.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Sis_Serv_Tecnico.Name = "Btn_Sis_Serv_Tecnico"
        Me.Btn_Sis_Serv_Tecnico.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Sis_Serv_Tecnico.Text = "<font size=""+4""><b>SERVICIOS, O.T.</b></font>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Btn_Sis_Serv_Tecnico.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Yellow
        Me.Btn_Sis_Serv_Tecnico.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Sis_Serv_Tecnico.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Btn_Sis_Serv_Tecnico.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Btn_Sis_Serv_Tecnico.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Btn_Sis_Serv_Tecnico.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Btn_Sis_Serv_Tecnico.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Sis_Serv_Tecnico.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Sis_Serv_Tecnico.TitleText = "BakApp"
        '
        'Btn_Configuraciones
        '
        Me.Btn_Configuraciones.Image = CType(resources.GetObject("Btn_Configuraciones.Image"), System.Drawing.Image)
        Me.Btn_Configuraciones.ImageIndent = New System.Drawing.Point(8, -6)
        Me.Btn_Configuraciones.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Configuraciones.Name = "Btn_Configuraciones"
        Me.Btn_Configuraciones.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Configuraciones.Text = "<font size=""+4""><b>CONFIGURACION</b></font><br/><font size=""-1"">Mantención de tab" &
    "las</font>"
        Me.Btn_Configuraciones.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Teal
        Me.Btn_Configuraciones.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Configuraciones.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Btn_Configuraciones.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Btn_Configuraciones.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Configuraciones.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Btn_Configuraciones.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Btn_Configuraciones.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Configuraciones.TileStyle.PaddingBottom = 4
        Me.Btn_Configuraciones.TileStyle.PaddingLeft = 4
        Me.Btn_Configuraciones.TileStyle.PaddingRight = 4
        Me.Btn_Configuraciones.TileStyle.PaddingTop = 4
        Me.Btn_Configuraciones.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Configuraciones.TitleText = "BakApp"
        '
        'Btn_Sis_Serv_GestTaller
        '
        Me.Btn_Sis_Serv_GestTaller.Image = CType(resources.GetObject("Btn_Sis_Serv_GestTaller.Image"), System.Drawing.Image)
        Me.Btn_Sis_Serv_GestTaller.ImageIndent = New System.Drawing.Point(8, -6)
        Me.Btn_Sis_Serv_GestTaller.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Sis_Serv_GestTaller.Name = "Btn_Sis_Serv_GestTaller"
        Me.Btn_Sis_Serv_GestTaller.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Sis_Serv_GestTaller.Text = "<font size=""+4""><b>SERV. TEC.</b></font><br/><font size=""-1"">Gestión Mesón</font>" &
    ""
        Me.Btn_Sis_Serv_GestTaller.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Teal
        Me.Btn_Sis_Serv_GestTaller.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Sis_Serv_GestTaller.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(73, Byte), Integer))
        Me.Btn_Sis_Serv_GestTaller.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(73, Byte), Integer))
        Me.Btn_Sis_Serv_GestTaller.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Sis_Serv_GestTaller.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(73, Byte), Integer))
        Me.Btn_Sis_Serv_GestTaller.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(73, Byte), Integer))
        Me.Btn_Sis_Serv_GestTaller.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Sis_Serv_GestTaller.TileStyle.PaddingBottom = 4
        Me.Btn_Sis_Serv_GestTaller.TileStyle.PaddingLeft = 4
        Me.Btn_Sis_Serv_GestTaller.TileStyle.PaddingRight = 4
        Me.Btn_Sis_Serv_GestTaller.TileStyle.PaddingTop = 4
        Me.Btn_Sis_Serv_GestTaller.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Sis_Serv_GestTaller.TitleText = "BakApp"
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
        Me.LabelX1.Size = New System.Drawing.Size(245, 49)
        Me.LabelX1.TabIndex = 54
        Me.LabelX1.Text = "<font color=""#349FCE""><b>SERVICIO TECNICO</b></font>"
        '
        'Modulo_Servicio_Tecnico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.Name = "Modulo_Servicio_Tecnico"
        Me.Size = New System.Drawing.Size(437, 327)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents ConsultaPreciosContenedor As DevComponents.DotNetBar.ItemContainer
    Private WithEvents Btn_Sis_Serv_Tecnico As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Configuraciones As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Private WithEvents Btn_Sis_Serv_GestTaller As DevComponents.DotNetBar.Metro.MetroTileItem
End Class
