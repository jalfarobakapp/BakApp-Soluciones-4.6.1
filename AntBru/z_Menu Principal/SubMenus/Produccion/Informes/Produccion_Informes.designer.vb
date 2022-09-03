<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Produccion_Informes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Produccion_Informes))
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem()
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel()
        Me.ContenedorTablas = New DevComponents.DotNetBar.ItemContainer()
        Me.Btn_Informe_Avance_OT = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Informe_Ocupacion_Maquinas = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Informe_Trabajos_En_Ejecucion = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Informe_Operarios_Estado = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.Btn_Informe_Meson = New DevComponents.DotNetBar.Metro.MetroTileItem()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSalir})
        Me.Bar2.Location = New System.Drawing.Point(0, 295)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(650, 41)
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
        Me.BtnSalir.Tooltip = "Volver"
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
        Me.MetroTilePanel1.Location = New System.Drawing.Point(3, 59)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(727, 315)
        Me.MetroTilePanel1.TabIndex = 38
        Me.MetroTilePanel1.Text = "MetroTilePanel1"
        '
        'ContenedorTablas
        '
        '
        '
        '
        Me.ContenedorTablas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ContenedorTablas.FixedSize = New System.Drawing.Size(650, 260)
        Me.ContenedorTablas.MultiLine = True
        Me.ContenedorTablas.Name = "ContenedorTablas"
        Me.ContenedorTablas.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Informe_Avance_OT, Me.Btn_Informe_Ocupacion_Maquinas, Me.Btn_Informe_Trabajos_En_Ejecucion, Me.Btn_Informe_Operarios_Estado, Me.Btn_Informe_Meson})
        '
        '
        '
        Me.ContenedorTablas.TitleStyle.Class = "MetroTileGroupTitle"
        Me.ContenedorTablas.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'Btn_Informe_Avance_OT
        '
        Me.Btn_Informe_Avance_OT.Image = CType(resources.GetObject("Btn_Informe_Avance_OT.Image"), System.Drawing.Image)
        Me.Btn_Informe_Avance_OT.ImageIndent = New System.Drawing.Point(8, -6)
        Me.Btn_Informe_Avance_OT.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Informe_Avance_OT.Name = "Btn_Informe_Avance_OT"
        Me.Btn_Informe_Avance_OT.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Informe_Avance_OT.Text = "<font size=""+4"">AVANCES OT</font><br/><font size=""-1"">Informe sobre el estado de " &
    "avance por ordenes de trabajo</font>"
        Me.Btn_Informe_Avance_OT.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Maroon
        Me.Btn_Informe_Avance_OT.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Informe_Avance_OT.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(123, Byte), Integer))
        Me.Btn_Informe_Avance_OT.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(123, Byte), Integer))
        Me.Btn_Informe_Avance_OT.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Informe_Avance_OT.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(123, Byte), Integer))
        Me.Btn_Informe_Avance_OT.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(123, Byte), Integer))
        Me.Btn_Informe_Avance_OT.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Informe_Avance_OT.TileStyle.PaddingBottom = 4
        Me.Btn_Informe_Avance_OT.TileStyle.PaddingLeft = 4
        Me.Btn_Informe_Avance_OT.TileStyle.PaddingRight = 4
        Me.Btn_Informe_Avance_OT.TileStyle.PaddingTop = 4
        Me.Btn_Informe_Avance_OT.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Informe_Avance_OT.TitleText = "Bakapp"
        '
        'Btn_Informe_Ocupacion_Maquinas
        '
        Me.Btn_Informe_Ocupacion_Maquinas.Image = CType(resources.GetObject("Btn_Informe_Ocupacion_Maquinas.Image"), System.Drawing.Image)
        Me.Btn_Informe_Ocupacion_Maquinas.ImageIndent = New System.Drawing.Point(8, -6)
        Me.Btn_Informe_Ocupacion_Maquinas.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Informe_Ocupacion_Maquinas.Name = "Btn_Informe_Ocupacion_Maquinas"
        Me.Btn_Informe_Ocupacion_Maquinas.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Informe_Ocupacion_Maquinas.Text = "<font size=""+4"">CARGA DE MAQUINAS</font><br/><font size=""-1"">Informe de la carga " &
    "de trabajo por maquina.</font>"
        Me.Btn_Informe_Ocupacion_Maquinas.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Yellowish
        Me.Btn_Informe_Ocupacion_Maquinas.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Informe_Ocupacion_Maquinas.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Btn_Informe_Ocupacion_Maquinas.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Btn_Informe_Ocupacion_Maquinas.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Informe_Ocupacion_Maquinas.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Btn_Informe_Ocupacion_Maquinas.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Btn_Informe_Ocupacion_Maquinas.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Informe_Ocupacion_Maquinas.TileStyle.PaddingBottom = 4
        Me.Btn_Informe_Ocupacion_Maquinas.TileStyle.PaddingLeft = 4
        Me.Btn_Informe_Ocupacion_Maquinas.TileStyle.PaddingRight = 4
        Me.Btn_Informe_Ocupacion_Maquinas.TileStyle.PaddingTop = 4
        Me.Btn_Informe_Ocupacion_Maquinas.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Informe_Ocupacion_Maquinas.TitleText = "Bakapp"
        '
        'Btn_Informe_Trabajos_En_Ejecucion
        '
        Me.Btn_Informe_Trabajos_En_Ejecucion.Image = CType(resources.GetObject("Btn_Informe_Trabajos_En_Ejecucion.Image"), System.Drawing.Image)
        Me.Btn_Informe_Trabajos_En_Ejecucion.ImageIndent = New System.Drawing.Point(8, -6)
        Me.Btn_Informe_Trabajos_En_Ejecucion.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Informe_Trabajos_En_Ejecucion.Name = "Btn_Informe_Trabajos_En_Ejecucion"
        Me.Btn_Informe_Trabajos_En_Ejecucion.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Informe_Trabajos_En_Ejecucion.Text = "<font size=""+4"">DFA EJECUCION</font><br/><font size=""-1"">Trabajos en ejecución.</" &
    "font>"
        Me.Btn_Informe_Trabajos_En_Ejecucion.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.DarkGreen
        Me.Btn_Informe_Trabajos_En_Ejecucion.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Informe_Trabajos_En_Ejecucion.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Btn_Informe_Trabajos_En_Ejecucion.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Btn_Informe_Trabajos_En_Ejecucion.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Informe_Trabajos_En_Ejecucion.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Btn_Informe_Trabajos_En_Ejecucion.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Btn_Informe_Trabajos_En_Ejecucion.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Informe_Trabajos_En_Ejecucion.TileStyle.PaddingBottom = 4
        Me.Btn_Informe_Trabajos_En_Ejecucion.TileStyle.PaddingLeft = 4
        Me.Btn_Informe_Trabajos_En_Ejecucion.TileStyle.PaddingRight = 4
        Me.Btn_Informe_Trabajos_En_Ejecucion.TileStyle.PaddingTop = 4
        Me.Btn_Informe_Trabajos_En_Ejecucion.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Informe_Trabajos_En_Ejecucion.TitleText = "Bakapp"
        '
        'Btn_Informe_Operarios_Estado
        '
        Me.Btn_Informe_Operarios_Estado.Image = CType(resources.GetObject("Btn_Informe_Operarios_Estado.Image"), System.Drawing.Image)
        Me.Btn_Informe_Operarios_Estado.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Informe_Operarios_Estado.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Informe_Operarios_Estado.Name = "Btn_Informe_Operarios_Estado"
        Me.Btn_Informe_Operarios_Estado.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Informe_Operarios_Estado.Text = "<font size=""+4""><b>ESTADO DE OPERARIOS</b></font><br/><font size=""-1"">Muestra tra" &
    "bajos de los operarios...</font>"
        Me.Btn_Informe_Operarios_Estado.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Blue
        Me.Btn_Informe_Operarios_Estado.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Informe_Operarios_Estado.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.Btn_Informe_Operarios_Estado.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.Btn_Informe_Operarios_Estado.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Informe_Operarios_Estado.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.Btn_Informe_Operarios_Estado.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.Btn_Informe_Operarios_Estado.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Informe_Operarios_Estado.TileStyle.PaddingBottom = 4
        Me.Btn_Informe_Operarios_Estado.TileStyle.PaddingLeft = 4
        Me.Btn_Informe_Operarios_Estado.TileStyle.PaddingRight = 4
        Me.Btn_Informe_Operarios_Estado.TileStyle.PaddingTop = 4
        Me.Btn_Informe_Operarios_Estado.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Informe_Operarios_Estado.TitleText = "Bakapp"
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Location = New System.Drawing.Point(6, 3)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(581, 50)
        Me.ReflectionLabel1.TabIndex = 40
        Me.ReflectionLabel1.Text = "<b><font size=""+8"" color=""#349FCE"">INFORMES DE PRODUCCION</font></b>"
        '
        'Btn_Informe_Meson
        '
        Me.Btn_Informe_Meson.Image = CType(resources.GetObject("Btn_Informe_Meson.Image"), System.Drawing.Image)
        Me.Btn_Informe_Meson.ImageIndent = New System.Drawing.Point(8, -6)
        Me.Btn_Informe_Meson.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Informe_Meson.Name = "Btn_Informe_Meson"
        Me.Btn_Informe_Meson.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Informe_Meson.Text = "<font size=""+4"">MESON</font><br/><font size=""-1"">Informe de tiempos de productos " &
    "por meson</font>"
        Me.Btn_Informe_Meson.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Maroon
        Me.Btn_Informe_Meson.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Informe_Meson.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(123, Byte), Integer))
        Me.Btn_Informe_Meson.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(123, Byte), Integer))
        Me.Btn_Informe_Meson.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Informe_Meson.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(123, Byte), Integer))
        Me.Btn_Informe_Meson.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(123, Byte), Integer))
        Me.Btn_Informe_Meson.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Informe_Meson.TileStyle.PaddingBottom = 4
        Me.Btn_Informe_Meson.TileStyle.PaddingLeft = 4
        Me.Btn_Informe_Meson.TileStyle.PaddingRight = 4
        Me.Btn_Informe_Meson.TileStyle.PaddingTop = 4
        Me.Btn_Informe_Meson.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Informe_Meson.TitleText = "Bakapp"
        '
        'Produccion_Informes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.Name = "Produccion_Informes"
        Me.Size = New System.Drawing.Size(650, 336)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents ContenedorTablas As DevComponents.DotNetBar.ItemContainer
    Private WithEvents Btn_Informe_Avance_OT As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Informe_Ocupacion_Maquinas As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Informe_Trabajos_En_Ejecucion As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Informe_Operarios_Estado As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Private WithEvents Btn_Informe_Meson As DevComponents.DotNetBar.Metro.MetroTileItem
End Class
