<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Sistema_Reclamos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Sistema_Reclamos))
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Configuración = New DevComponents.DotNetBar.ButtonItem()
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel()
        Me.ContenedorTablas = New DevComponents.DotNetBar.ItemContainer()
        Me.Btn_Ingresar_Reclamos = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Resolucion = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Validacion = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Gestionar_Reclamo = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Buscar_Reclamos = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Revision_Espera = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.MetroTileItem2 = New DevComponents.DotNetBar.Metro.MetroTileItem()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Location = New System.Drawing.Point(3, 0)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(244, 50)
        Me.ReflectionLabel1.TabIndex = 40
        Me.ReflectionLabel1.Text = "<b><font size=""+8"" color=""#349FCE"">SISTEMA RECLAMOS</font></b>"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSalir, Me.Btn_Configuración})
        Me.Bar2.Location = New System.Drawing.Point(0, 315)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(643, 41)
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
        Me.MetroTilePanel1.Size = New System.Drawing.Size(672, 395)
        Me.MetroTilePanel1.TabIndex = 38
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
        Me.ContenedorTablas.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Ingresar_Reclamos, Me.Btn_Resolucion, Me.Btn_Validacion, Me.Btn_Gestionar_Reclamo, Me.Btn_Buscar_Reclamos})
        '
        '
        '
        Me.ContenedorTablas.TitleStyle.Class = "MetroTileGroupTitle"
        Me.ContenedorTablas.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'Btn_Ingresar_Reclamos
        '
        Me.Btn_Ingresar_Reclamos.Image = CType(resources.GetObject("Btn_Ingresar_Reclamos.Image"), System.Drawing.Image)
        Me.Btn_Ingresar_Reclamos.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Ingresar_Reclamos.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Ingresar_Reclamos.Name = "Btn_Ingresar_Reclamos"
        Me.Btn_Ingresar_Reclamos.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Ingresar_Reclamos.Text = "<font size=""+4""><b>VER RECLAMOS ACTIVOS</b></font><br/><font size=""-1"">Crear y re" &
    "visar reclamos</font>"
        Me.Btn_Ingresar_Reclamos.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Yellow
        Me.Btn_Ingresar_Reclamos.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Ingresar_Reclamos.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(18, Byte), Integer))
        Me.Btn_Ingresar_Reclamos.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(18, Byte), Integer))
        Me.Btn_Ingresar_Reclamos.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Ingresar_Reclamos.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(18, Byte), Integer))
        Me.Btn_Ingresar_Reclamos.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(18, Byte), Integer))
        Me.Btn_Ingresar_Reclamos.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Ingresar_Reclamos.TileStyle.PaddingBottom = 4
        Me.Btn_Ingresar_Reclamos.TileStyle.PaddingLeft = 4
        Me.Btn_Ingresar_Reclamos.TileStyle.PaddingRight = 4
        Me.Btn_Ingresar_Reclamos.TileStyle.PaddingTop = 4
        Me.Btn_Ingresar_Reclamos.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Ingresar_Reclamos.TitleText = "BakApp"
        '
        'Btn_Resolucion
        '
        Me.Btn_Resolucion.Image = CType(resources.GetObject("Btn_Resolucion.Image"), System.Drawing.Image)
        Me.Btn_Resolucion.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Resolucion.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Resolucion.Name = "Btn_Resolucion"
        Me.Btn_Resolucion.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Resolucion.Text = "<font size=""+4""><b>RESOLUCION</b></font><br/><font size=""-1"">Ingresar investigaci" &
    "ón y resolución de reclamos</font>"
        Me.Btn_Resolucion.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Yellow
        Me.Btn_Resolucion.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Resolucion.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.Btn_Resolucion.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.Btn_Resolucion.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Resolucion.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.Btn_Resolucion.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.Btn_Resolucion.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Resolucion.TileStyle.PaddingBottom = 4
        Me.Btn_Resolucion.TileStyle.PaddingLeft = 4
        Me.Btn_Resolucion.TileStyle.PaddingRight = 4
        Me.Btn_Resolucion.TileStyle.PaddingTop = 4
        Me.Btn_Resolucion.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Resolucion.TitleText = "BakApp"
        '
        'Btn_Validacion
        '
        Me.Btn_Validacion.Image = CType(resources.GetObject("Btn_Validacion.Image"), System.Drawing.Image)
        Me.Btn_Validacion.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Validacion.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Validacion.Name = "Btn_Validacion"
        Me.Btn_Validacion.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Validacion.Text = "<font size=""+4""><b>VALIDACION</b></font><br/><font size=""-1"">Aprobar o rechazar r" &
    "esolución de reclamos</font>"
        Me.Btn_Validacion.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.RedViolet
        Me.Btn_Validacion.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Validacion.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Btn_Validacion.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Btn_Validacion.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Validacion.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Btn_Validacion.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Btn_Validacion.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Validacion.TileStyle.PaddingBottom = 4
        Me.Btn_Validacion.TileStyle.PaddingLeft = 4
        Me.Btn_Validacion.TileStyle.PaddingRight = 4
        Me.Btn_Validacion.TileStyle.PaddingTop = 4
        Me.Btn_Validacion.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Validacion.TitleText = "BakApp"
        '
        'Btn_Gestionar_Reclamo
        '
        Me.Btn_Gestionar_Reclamo.Image = CType(resources.GetObject("Btn_Gestionar_Reclamo.Image"), System.Drawing.Image)
        Me.Btn_Gestionar_Reclamo.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Gestionar_Reclamo.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Gestionar_Reclamo.Name = "Btn_Gestionar_Reclamo"
        Me.Btn_Gestionar_Reclamo.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Gestionar_Reclamo.Text = "<font size=""+4""><b>GESTIONAR RECLAMO</b></font><br/><font size=""-1"">Control admin" &
    "istrativo interno derivado por reclamos</font>"
        Me.Btn_Gestionar_Reclamo.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Yellow
        Me.Btn_Gestionar_Reclamo.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Gestionar_Reclamo.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.Btn_Gestionar_Reclamo.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.Btn_Gestionar_Reclamo.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Gestionar_Reclamo.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.Btn_Gestionar_Reclamo.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.Btn_Gestionar_Reclamo.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Gestionar_Reclamo.TileStyle.PaddingBottom = 4
        Me.Btn_Gestionar_Reclamo.TileStyle.PaddingLeft = 4
        Me.Btn_Gestionar_Reclamo.TileStyle.PaddingRight = 4
        Me.Btn_Gestionar_Reclamo.TileStyle.PaddingTop = 4
        Me.Btn_Gestionar_Reclamo.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Gestionar_Reclamo.TitleText = "BakApp"
        '
        'Btn_Buscar_Reclamos
        '
        Me.Btn_Buscar_Reclamos.Image = CType(resources.GetObject("Btn_Buscar_Reclamos.Image"), System.Drawing.Image)
        Me.Btn_Buscar_Reclamos.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Buscar_Reclamos.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Buscar_Reclamos.Name = "Btn_Buscar_Reclamos"
        Me.Btn_Buscar_Reclamos.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Buscar_Reclamos.Text = "<font size=""+4""><b>BUSCAR RECLAMOS</b></font><br/><font size=""-1"">Buscador..</fon" &
    "t>"
        Me.Btn_Buscar_Reclamos.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Yellow
        Me.Btn_Buscar_Reclamos.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Buscar_Reclamos.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.Btn_Buscar_Reclamos.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.Btn_Buscar_Reclamos.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Buscar_Reclamos.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.Btn_Buscar_Reclamos.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.Btn_Buscar_Reclamos.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Buscar_Reclamos.TileStyle.PaddingBottom = 4
        Me.Btn_Buscar_Reclamos.TileStyle.PaddingLeft = 4
        Me.Btn_Buscar_Reclamos.TileStyle.PaddingRight = 4
        Me.Btn_Buscar_Reclamos.TileStyle.PaddingTop = 4
        Me.Btn_Buscar_Reclamos.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Buscar_Reclamos.TitleText = "BakApp"
        '
        'Btn_Revision_Espera
        '
        Me.Btn_Revision_Espera.Image = CType(resources.GetObject("Btn_Revision_Espera.Image"), System.Drawing.Image)
        Me.Btn_Revision_Espera.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Revision_Espera.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Revision_Espera.Name = "Btn_Revision_Espera"
        Me.Btn_Revision_Espera.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Revision_Espera.Text = "<font size=""+4""><b>EN REVISION Y ESPERA</b></font><br/><font size=""-1"">Lista que " &
    "están en espera de ser enviadoa a RESOLUCION</font>"
        Me.Btn_Revision_Espera.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.RedViolet
        Me.Btn_Revision_Espera.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Revision_Espera.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(57, Byte), Integer))
        Me.Btn_Revision_Espera.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(57, Byte), Integer))
        Me.Btn_Revision_Espera.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Revision_Espera.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(57, Byte), Integer))
        Me.Btn_Revision_Espera.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(57, Byte), Integer))
        Me.Btn_Revision_Espera.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Revision_Espera.TileStyle.PaddingBottom = 4
        Me.Btn_Revision_Espera.TileStyle.PaddingLeft = 4
        Me.Btn_Revision_Espera.TileStyle.PaddingRight = 4
        Me.Btn_Revision_Espera.TileStyle.PaddingTop = 4
        Me.Btn_Revision_Espera.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Revision_Espera.TitleText = "BakApp"
        '
        'MetroTileItem2
        '
        Me.MetroTileItem2.Image = CType(resources.GetObject("MetroTileItem2.Image"), System.Drawing.Image)
        Me.MetroTileItem2.ImageIndent = New System.Drawing.Point(8, -10)
        Me.MetroTileItem2.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.MetroTileItem2.Name = "MetroTileItem2"
        Me.MetroTileItem2.SymbolColor = System.Drawing.Color.Empty
        Me.MetroTileItem2.Text = "<font size=""+4""><b>MESONES DE TRABAJO</b></font><br/><font size=""-1"">Asignación d" &
    "e OT y Productos a Mesones de Trabajo</font>"
        Me.MetroTileItem2.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.RedViolet
        Me.MetroTileItem2.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.MetroTileItem2.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.MetroTileItem2.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.MetroTileItem2.TileStyle.BackColorGradientAngle = 45
        Me.MetroTileItem2.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.MetroTileItem2.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.MetroTileItem2.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.MetroTileItem2.TileStyle.PaddingBottom = 4
        Me.MetroTileItem2.TileStyle.PaddingLeft = 4
        Me.MetroTileItem2.TileStyle.PaddingRight = 4
        Me.MetroTileItem2.TileStyle.PaddingTop = 4
        Me.MetroTileItem2.TileStyle.TextColor = System.Drawing.Color.White
        Me.MetroTileItem2.TitleText = "BakApp"
        '
        'Sistema_Reclamos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.Name = "Sistema_Reclamos"
        Me.Size = New System.Drawing.Size(643, 356)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents ContenedorTablas As DevComponents.DotNetBar.ItemContainer
    Private WithEvents Btn_Ingresar_Reclamos As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Revision_Espera As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Resolucion As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Validacion As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Gestionar_Reclamo As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents MetroTileItem2 As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents Btn_Configuración As DevComponents.DotNetBar.ButtonItem
    Private WithEvents Btn_Buscar_Reclamos As DevComponents.DotNetBar.Metro.MetroTileItem
End Class
