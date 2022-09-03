<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Inv_Parcializado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Inv_Parcializado))
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel
        Me.Bar2 = New DevComponents.DotNetBar.Bar
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem
        Me.BtnCalculadoraPeso = New DevComponents.DotNetBar.ButtonItem
        Me.BtnConfiguracion = New DevComponents.DotNetBar.ButtonItem
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel
        Me.ContenedorTablas = New DevComponents.DotNetBar.ItemContainer
        Me.BtnNuevoInventario = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.BtnAbrirInventarios = New DevComponents.DotNetBar.Metro.MetroTileItem
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Location = New System.Drawing.Point(0, 2)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(363, 50)
        Me.ReflectionLabel1.TabIndex = 37
        Me.ReflectionLabel1.Text = "<b><font size=""+10""><i>A</i><font color=""#B02B2C"">juste de Inventario</font></fon" & _
            "t></b>"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSalir, Me.BtnCalculadoraPeso, Me.BtnConfiguracion})
        Me.Bar2.Location = New System.Drawing.Point(0, 193)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(400, 57)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 36
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
        Me.BtnSalir.Text = "Volver..."
        '
        'BtnCalculadoraPeso
        '
        Me.BtnCalculadoraPeso.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnCalculadoraPeso.ForeColor = System.Drawing.Color.Black
        Me.BtnCalculadoraPeso.Image = CType(resources.GetObject("BtnCalculadoraPeso.Image"), System.Drawing.Image)
        Me.BtnCalculadoraPeso.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnCalculadoraPeso.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnCalculadoraPeso.Name = "BtnCalculadoraPeso"
        Me.BtnCalculadoraPeso.Text = "Calc. peso"
        '
        'BtnConfiguracion
        '
        Me.BtnConfiguracion.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnConfiguracion.Enabled = False
        Me.BtnConfiguracion.ForeColor = System.Drawing.Color.Black
        Me.BtnConfiguracion.Image = CType(resources.GetObject("BtnConfiguracion.Image"), System.Drawing.Image)
        Me.BtnConfiguracion.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnConfiguracion.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnConfiguracion.Name = "BtnConfiguracion"
        Me.BtnConfiguracion.Text = "Configuración"
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
        Me.MetroTilePanel1.Location = New System.Drawing.Point(3, 58)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(642, 166)
        Me.MetroTilePanel1.TabIndex = 35
        Me.MetroTilePanel1.Text = "MetroTilePanel1"
        '
        'ContenedorTablas
        '
        '
        '
        '
        Me.ContenedorTablas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ContenedorTablas.FixedSize = New System.Drawing.Size(600, 130)
        Me.ContenedorTablas.MultiLine = True
        Me.ContenedorTablas.Name = "ContenedorTablas"
        Me.ContenedorTablas.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnNuevoInventario, Me.BtnAbrirInventarios})
        '
        '
        '
        Me.ContenedorTablas.TitleStyle.Class = "MetroTileGroupTitle"
        Me.ContenedorTablas.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'BtnNuevoInventario
        '
        Me.BtnNuevoInventario.ImageIndent = New System.Drawing.Point(8, -6)
        Me.BtnNuevoInventario.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnNuevoInventario.Name = "BtnNuevoInventario"
        Me.BtnNuevoInventario.SymbolColor = System.Drawing.Color.Empty
        Me.BtnNuevoInventario.Text = "<font size=""+4"">NUEVO</font><br/><font size=""-1"">Generar nuevo inventario con la " & _
            "fecha de hoy</font>"
        Me.BtnNuevoInventario.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Magenta
        '
        '
        '
        Me.BtnNuevoInventario.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnNuevoInventario.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(158, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnNuevoInventario.TileStyle.BackColorGradientAngle = 45
        Me.BtnNuevoInventario.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BtnNuevoInventario.TileStyle.PaddingBottom = 4
        Me.BtnNuevoInventario.TileStyle.PaddingLeft = 4
        Me.BtnNuevoInventario.TileStyle.PaddingRight = 4
        Me.BtnNuevoInventario.TileStyle.PaddingTop = 4
        Me.BtnNuevoInventario.TileStyle.TextColor = System.Drawing.Color.White
        Me.BtnNuevoInventario.TitleText = "BakApp"
        '
        'BtnAbrirInventarios
        '
        Me.BtnAbrirInventarios.ImageIndent = New System.Drawing.Point(8, -6)
        Me.BtnAbrirInventarios.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnAbrirInventarios.Name = "BtnAbrirInventarios"
        Me.BtnAbrirInventarios.SymbolColor = System.Drawing.Color.Empty
        Me.BtnAbrirInventarios.Text = "<font size=""+4"">ABRIR</font><br/><font size=""-1"">Abrir inventarios realizados ant" & _
            "eriormente</font>"
        Me.BtnAbrirInventarios.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        '
        '
        '
        Me.BtnAbrirInventarios.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BtnAbrirInventarios.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BtnAbrirInventarios.TileStyle.BackColorGradientAngle = 45
        Me.BtnAbrirInventarios.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BtnAbrirInventarios.TileStyle.PaddingBottom = 4
        Me.BtnAbrirInventarios.TileStyle.PaddingLeft = 4
        Me.BtnAbrirInventarios.TileStyle.PaddingRight = 4
        Me.BtnAbrirInventarios.TileStyle.PaddingTop = 4
        Me.BtnAbrirInventarios.TileStyle.TextColor = System.Drawing.Color.Black
        Me.BtnAbrirInventarios.TitleText = "BakApp"
        '
        'Inv_Parcializado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.Name = "Inv_Parcializado"
        Me.Size = New System.Drawing.Size(400, 250)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents ContenedorTablas As DevComponents.DotNetBar.ItemContainer
    Private WithEvents BtnNuevoInventario As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents BtnAbrirInventarios As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents BtnConfiguracion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnCalculadoraPeso As DevComponents.DotNetBar.ButtonItem

End Class
