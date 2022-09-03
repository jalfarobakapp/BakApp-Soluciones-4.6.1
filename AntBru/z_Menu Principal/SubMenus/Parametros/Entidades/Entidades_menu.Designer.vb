<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Entidades_menu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Entidades_menu))
        Me.Btn_MantEntidades = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.MnuEspecialPrecios = New DevComponents.DotNetBar.ItemContainer()
        Me.Btn_EntExcuidas = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem()
        Me.MetroTilePanel2 = New DevComponents.DotNetBar.Metro.MetroTilePanel()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Tablas_Conf_Entidad = New DevComponents.DotNetBar.Metro.MetroTileItem()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Btn_MantEntidades
        '
        Me.Btn_MantEntidades.Image = CType(resources.GetObject("Btn_MantEntidades.Image"), System.Drawing.Image)
        Me.Btn_MantEntidades.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_MantEntidades.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_MantEntidades.Name = "Btn_MantEntidades"
        Me.Btn_MantEntidades.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_MantEntidades.Text = "<font size=""+4""><b>MAESTRO ENTIDADES</b></font><br/><font size=""-1"">Mantención de" &
    " entidades:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Buscar, Crear, Editar, Eliminar</font>"
        Me.Btn_MantEntidades.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green
        Me.Btn_MantEntidades.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_MantEntidades.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Btn_MantEntidades.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Btn_MantEntidades.TileStyle.BackColorGradientAngle = 45
        Me.Btn_MantEntidades.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Btn_MantEntidades.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Btn_MantEntidades.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_MantEntidades.TileStyle.PaddingBottom = 4
        Me.Btn_MantEntidades.TileStyle.PaddingLeft = 4
        Me.Btn_MantEntidades.TileStyle.PaddingRight = 4
        Me.Btn_MantEntidades.TileStyle.PaddingTop = 4
        Me.Btn_MantEntidades.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_MantEntidades.TitleText = "Bakapp"
        '
        'MnuEspecialPrecios
        '
        '
        '
        '
        Me.MnuEspecialPrecios.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MnuEspecialPrecios.FixedSize = New System.Drawing.Size(700, 130)
        Me.MnuEspecialPrecios.MultiLine = True
        Me.MnuEspecialPrecios.Name = "MnuEspecialPrecios"
        Me.MnuEspecialPrecios.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_MantEntidades, Me.Btn_EntExcuidas, Me.Btn_Tablas_Conf_Entidad})
        '
        '
        '
        Me.MnuEspecialPrecios.TitleStyle.Class = "MetroTileGroupTitle"
        Me.MnuEspecialPrecios.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'Btn_EntExcuidas
        '
        Me.Btn_EntExcuidas.Image = CType(resources.GetObject("Btn_EntExcuidas.Image"), System.Drawing.Image)
        Me.Btn_EntExcuidas.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_EntExcuidas.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_EntExcuidas.Name = "Btn_EntExcuidas"
        Me.Btn_EntExcuidas.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_EntExcuidas.Text = "<font size=""+4""><b>ENTIDADES EXLUIDAS</b></font><br/><font size=""-1"">Entidades ex" &
    "cluidas en informes y otras acciones del sistema.</font>"
        Me.Btn_EntExcuidas.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Yellow
        Me.Btn_EntExcuidas.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_EntExcuidas.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(77, Byte), Integer))
        Me.Btn_EntExcuidas.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(77, Byte), Integer))
        Me.Btn_EntExcuidas.TileStyle.BackColorGradientAngle = 45
        Me.Btn_EntExcuidas.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(77, Byte), Integer))
        Me.Btn_EntExcuidas.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(77, Byte), Integer))
        Me.Btn_EntExcuidas.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_EntExcuidas.TileStyle.PaddingBottom = 4
        Me.Btn_EntExcuidas.TileStyle.PaddingLeft = 4
        Me.Btn_EntExcuidas.TileStyle.PaddingRight = 4
        Me.Btn_EntExcuidas.TileStyle.PaddingTop = 4
        Me.Btn_EntExcuidas.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_EntExcuidas.TitleText = "Bakapp"
        '
        'BtnSalir
        '
        Me.BtnSalir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnSalir.ForeColor = System.Drawing.Color.Black
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnSalir.Name = "BtnSalir"
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
        Me.MetroTilePanel2.Location = New System.Drawing.Point(3, 58)
        Me.MetroTilePanel2.Name = "MetroTilePanel2"
        Me.MetroTilePanel2.Size = New System.Drawing.Size(766, 179)
        Me.MetroTilePanel2.TabIndex = 38
        Me.MetroTilePanel2.Text = "MetroTilePanel2"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSalir})
        Me.Bar2.Location = New System.Drawing.Point(0, 210)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(641, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 37
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.LabelX1.Location = New System.Drawing.Point(3, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(323, 49)
        Me.LabelX1.TabIndex = 52
        Me.LabelX1.Text = "<font color=""#349FCE""><b>ESPECIALES CLIENTES</b></font>"
        '
        'Btn_Tablas_Conf_Entidad
        '
        Me.Btn_Tablas_Conf_Entidad.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_Tablas_Conf_Entidad.Image = CType(resources.GetObject("Btn_Tablas_Conf_Entidad.Image"), System.Drawing.Image)
        Me.Btn_Tablas_Conf_Entidad.ImageIndent = New System.Drawing.Point(18, -10)
        Me.Btn_Tablas_Conf_Entidad.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Tablas_Conf_Entidad.Name = "Btn_Tablas_Conf_Entidad"
        Me.Btn_Tablas_Conf_Entidad.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Tablas_Conf_Entidad.Text = "<font size=""+4""><b>TABLAS DE ENTIDADES</b></font><br/>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<font size=""+1""></font>"
        Me.Btn_Tablas_Conf_Entidad.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Azure
        Me.Btn_Tablas_Conf_Entidad.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Tablas_Conf_Entidad.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.Btn_Tablas_Conf_Entidad.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.Btn_Tablas_Conf_Entidad.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Tablas_Conf_Entidad.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.Btn_Tablas_Conf_Entidad.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.Btn_Tablas_Conf_Entidad.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Tablas_Conf_Entidad.TileStyle.PaddingBottom = 4
        Me.Btn_Tablas_Conf_Entidad.TileStyle.PaddingLeft = 4
        Me.Btn_Tablas_Conf_Entidad.TileStyle.PaddingRight = 4
        Me.Btn_Tablas_Conf_Entidad.TileStyle.PaddingTop = 4
        Me.Btn_Tablas_Conf_Entidad.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Tablas_Conf_Entidad.TitleText = "BakApp"
        '
        'Entidades_menu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroTilePanel2)
        Me.Name = "Entidades_menu"
        Me.Size = New System.Drawing.Size(641, 251)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents Btn_MantEntidades As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents MnuEspecialPrecios As DevComponents.DotNetBar.ItemContainer
    Private WithEvents Btn_EntExcuidas As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroTilePanel2 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Private WithEvents Btn_Tablas_Conf_Entidad As DevComponents.DotNetBar.Metro.MetroTileItem
End Class
