<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Servicio_Tecnico_Mesones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Servicio_Tecnico_Mesones))
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem()
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel()
        Me.ContenedorTablas = New DevComponents.DotNetBar.ItemContainer()
        Me.Btn_Mesones = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Asignacion_OT_Al_Meson_ST = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Mesones_Gestion_ST = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Operarios_vs_Mesones_ST = New DevComponents.DotNetBar.Metro.MetroTileItem()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Location = New System.Drawing.Point(3, 1)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(244, 50)
        Me.ReflectionLabel1.TabIndex = 40
        Me.ReflectionLabel1.Text = "<b><font size=""+8"" color=""#349FCE"">SERVICIO TECNICO</font></b>"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSalir})
        Me.Bar2.Location = New System.Drawing.Point(0, 294)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(663, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 39
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
        Me.MetroTilePanel1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ContenedorTablas})
        Me.MetroTilePanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MetroTilePanel1.Location = New System.Drawing.Point(6, 57)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(968, 395)
        Me.MetroTilePanel1.TabIndex = 38
        Me.MetroTilePanel1.Text = "MetroTilePanel1"
        '
        'ContenedorTablas
        '
        '
        '
        '
        Me.ContenedorTablas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ContenedorTablas.FixedSize = New System.Drawing.Size(750, 300)
        Me.ContenedorTablas.MultiLine = True
        Me.ContenedorTablas.Name = "ContenedorTablas"
        Me.ContenedorTablas.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Mesones, Me.Btn_Asignacion_OT_Al_Meson_ST, Me.Btn_Mesones_Gestion_ST, Me.Btn_Operarios_vs_Mesones_ST})
        '
        '
        '
        Me.ContenedorTablas.TitleStyle.Class = "MetroTileGroupTitle"
        Me.ContenedorTablas.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'Btn_Mesones
        '
        Me.Btn_Mesones.Image = CType(resources.GetObject("Btn_Mesones.Image"), System.Drawing.Image)
        Me.Btn_Mesones.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Mesones.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Mesones.Name = "Btn_Mesones"
        Me.Btn_Mesones.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Mesones.Text = "<font size=""+4""><b>MESONES DE TRABAJO</b></font><br/><font size=""-1"">Creación y M" &
    "odificación de Mesones de Trabajo</font>"
        Me.Btn_Mesones.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Yellow
        Me.Btn_Mesones.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Mesones.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(18, Byte), Integer))
        Me.Btn_Mesones.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(18, Byte), Integer))
        Me.Btn_Mesones.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Mesones.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(18, Byte), Integer))
        Me.Btn_Mesones.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(18, Byte), Integer))
        Me.Btn_Mesones.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Mesones.TileStyle.PaddingBottom = 4
        Me.Btn_Mesones.TileStyle.PaddingLeft = 4
        Me.Btn_Mesones.TileStyle.PaddingRight = 4
        Me.Btn_Mesones.TileStyle.PaddingTop = 4
        Me.Btn_Mesones.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Mesones.TitleText = "BakApp"
        '
        'Btn_Asignacion_OT_Al_Meson_ST
        '
        Me.Btn_Asignacion_OT_Al_Meson_ST.Image = CType(resources.GetObject("Btn_Asignacion_OT_Al_Meson_ST.Image"), System.Drawing.Image)
        Me.Btn_Asignacion_OT_Al_Meson_ST.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Asignacion_OT_Al_Meson_ST.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Asignacion_OT_Al_Meson_ST.Name = "Btn_Asignacion_OT_Al_Meson_ST"
        Me.Btn_Asignacion_OT_Al_Meson_ST.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Asignacion_OT_Al_Meson_ST.Text = "<font size=""+4""><b>ASIGNAR OT AL MESON.  SERV. TEC</b></font><br/><font size=""-1""" &
    ">Buscar OT y asignar al mesón</font>"
        Me.Btn_Asignacion_OT_Al_Meson_ST.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.RedViolet
        Me.Btn_Asignacion_OT_Al_Meson_ST.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Asignacion_OT_Al_Meson_ST.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Btn_Asignacion_OT_Al_Meson_ST.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Btn_Asignacion_OT_Al_Meson_ST.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Asignacion_OT_Al_Meson_ST.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Btn_Asignacion_OT_Al_Meson_ST.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Btn_Asignacion_OT_Al_Meson_ST.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Asignacion_OT_Al_Meson_ST.TileStyle.PaddingBottom = 4
        Me.Btn_Asignacion_OT_Al_Meson_ST.TileStyle.PaddingLeft = 4
        Me.Btn_Asignacion_OT_Al_Meson_ST.TileStyle.PaddingRight = 4
        Me.Btn_Asignacion_OT_Al_Meson_ST.TileStyle.PaddingTop = 4
        Me.Btn_Asignacion_OT_Al_Meson_ST.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Asignacion_OT_Al_Meson_ST.TitleText = "BakApp"
        '
        'Btn_Mesones_Gestion_ST
        '
        Me.Btn_Mesones_Gestion_ST.Image = CType(resources.GetObject("Btn_Mesones_Gestion_ST.Image"), System.Drawing.Image)
        Me.Btn_Mesones_Gestion_ST.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Mesones_Gestion_ST.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Mesones_Gestion_ST.Name = "Btn_Mesones_Gestion_ST"
        Me.Btn_Mesones_Gestion_ST.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Mesones_Gestion_ST.Text = "<font size=""+4""><b>MESONES</b></font><br/><font size=""-1"">Ver trabajos en los mes" &
    "ones</font>"
        Me.Btn_Mesones_Gestion_ST.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Yellow
        Me.Btn_Mesones_Gestion_ST.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Mesones_Gestion_ST.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.Btn_Mesones_Gestion_ST.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.Btn_Mesones_Gestion_ST.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Mesones_Gestion_ST.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.Btn_Mesones_Gestion_ST.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.Btn_Mesones_Gestion_ST.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Mesones_Gestion_ST.TileStyle.PaddingBottom = 4
        Me.Btn_Mesones_Gestion_ST.TileStyle.PaddingLeft = 4
        Me.Btn_Mesones_Gestion_ST.TileStyle.PaddingRight = 4
        Me.Btn_Mesones_Gestion_ST.TileStyle.PaddingTop = 4
        Me.Btn_Mesones_Gestion_ST.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Mesones_Gestion_ST.TitleText = "BakApp"
        '
        'Btn_Operarios_vs_Mesones_ST
        '
        Me.Btn_Operarios_vs_Mesones_ST.Image = CType(resources.GetObject("Btn_Operarios_vs_Mesones_ST.Image"), System.Drawing.Image)
        Me.Btn_Operarios_vs_Mesones_ST.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Operarios_vs_Mesones_ST.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Operarios_vs_Mesones_ST.Name = "Btn_Operarios_vs_Mesones_ST"
        Me.Btn_Operarios_vs_Mesones_ST.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Operarios_vs_Mesones_ST.Text = "<font size=""+4""><b>OPERARIO VS MESON</b></font><br/><font size=""-1"">Operación de " &
    "Mesones de Trabajo</font>"
        Me.Btn_Operarios_vs_Mesones_ST.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.RedViolet
        Me.Btn_Operarios_vs_Mesones_ST.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Operarios_vs_Mesones_ST.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Btn_Operarios_vs_Mesones_ST.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Btn_Operarios_vs_Mesones_ST.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Operarios_vs_Mesones_ST.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Btn_Operarios_vs_Mesones_ST.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Btn_Operarios_vs_Mesones_ST.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Operarios_vs_Mesones_ST.TileStyle.PaddingBottom = 4
        Me.Btn_Operarios_vs_Mesones_ST.TileStyle.PaddingLeft = 4
        Me.Btn_Operarios_vs_Mesones_ST.TileStyle.PaddingRight = 4
        Me.Btn_Operarios_vs_Mesones_ST.TileStyle.PaddingTop = 4
        Me.Btn_Operarios_vs_Mesones_ST.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Operarios_vs_Mesones_ST.TitleText = "BakApp"
        '
        'Servicio_Tecnico_Mesones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.Name = "Servicio_Tecnico_Mesones"
        Me.Size = New System.Drawing.Size(663, 335)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents ContenedorTablas As DevComponents.DotNetBar.ItemContainer
    Private WithEvents Btn_Mesones As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Asignacion_OT_Al_Meson_ST As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Mesones_Gestion_ST As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Operarios_vs_Mesones_ST As DevComponents.DotNetBar.Metro.MetroTileItem
End Class
