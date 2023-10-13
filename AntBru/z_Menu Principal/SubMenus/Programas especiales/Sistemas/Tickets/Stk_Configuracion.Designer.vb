<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Stk_Configuracion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Stk_Configuracion))
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem()
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel()
        Me.ConsultaPreciosContenedor = New DevComponents.DotNetBar.ItemContainer()
        Me.Btn_Agentes = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Conf_Info_Reportes = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Recetas = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Operaciones = New DevComponents.DotNetBar.Metro.MetroTileItem()
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
        Me.LabelX1.Location = New System.Drawing.Point(3, 0)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(462, 49)
        Me.LabelX1.TabIndex = 60
        Me.LabelX1.Text = "<font color=""#349FCE""><b>CONFIGURACIONSISTEMA DE TICKETS</b></font>"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSalir})
        Me.Bar2.Location = New System.Drawing.Point(0, 293)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(641, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 59
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
        Me.MetroTilePanel1.Location = New System.Drawing.Point(3, 54)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(828, 445)
        Me.MetroTilePanel1.TabIndex = 58
        Me.MetroTilePanel1.Text = "MetroTilePanel1"
        '
        'ConsultaPreciosContenedor
        '
        '
        '
        '
        Me.ConsultaPreciosContenedor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ConsultaPreciosContenedor.FixedSize = New System.Drawing.Size(700, 400)
        Me.ConsultaPreciosContenedor.MultiLine = True
        Me.ConsultaPreciosContenedor.Name = "ConsultaPreciosContenedor"
        Me.ConsultaPreciosContenedor.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Agentes, Me.Btn_Conf_Info_Reportes, Me.Btn_Operaciones, Me.Btn_Recetas})
        '
        '
        '
        Me.ConsultaPreciosContenedor.TitleStyle.Class = "MetroTileGroupTitle"
        Me.ConsultaPreciosContenedor.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ConsultaPreciosContenedor.TitleStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'Btn_Agentes
        '
        Me.Btn_Agentes.Image = CType(resources.GetObject("Btn_Agentes.Image"), System.Drawing.Image)
        Me.Btn_Agentes.ImageIndent = New System.Drawing.Point(8, -6)
        Me.Btn_Agentes.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Agentes.Name = "Btn_Agentes"
        Me.Btn_Agentes.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Agentes.Text = "<font size=""+4""><b>AGENTES</b></font>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Btn_Agentes.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Yellow
        Me.Btn_Agentes.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Agentes.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Btn_Agentes.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Btn_Agentes.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Btn_Agentes.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Btn_Agentes.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Agentes.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Agentes.TitleText = "BakApp"
        '
        'Btn_Conf_Info_Reportes
        '
        Me.Btn_Conf_Info_Reportes.Image = CType(resources.GetObject("Btn_Conf_Info_Reportes.Image"), System.Drawing.Image)
        Me.Btn_Conf_Info_Reportes.ImageIndent = New System.Drawing.Point(8, -6)
        Me.Btn_Conf_Info_Reportes.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Conf_Info_Reportes.Name = "Btn_Conf_Info_Reportes"
        Me.Btn_Conf_Info_Reportes.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Conf_Info_Reportes.Text = "<font size=""+4""><b>GRUPOS</b></font><br/><font size=""-1"">Mantención de grupos de " &
    "agentes</font>"
        Me.Btn_Conf_Info_Reportes.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Teal
        Me.Btn_Conf_Info_Reportes.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Conf_Info_Reportes.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Btn_Conf_Info_Reportes.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Btn_Conf_Info_Reportes.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Conf_Info_Reportes.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Btn_Conf_Info_Reportes.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Btn_Conf_Info_Reportes.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Conf_Info_Reportes.TileStyle.PaddingBottom = 4
        Me.Btn_Conf_Info_Reportes.TileStyle.PaddingLeft = 4
        Me.Btn_Conf_Info_Reportes.TileStyle.PaddingRight = 4
        Me.Btn_Conf_Info_Reportes.TileStyle.PaddingTop = 4
        Me.Btn_Conf_Info_Reportes.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Conf_Info_Reportes.TitleText = "BakApp"
        Me.Btn_Conf_Info_Reportes.Visible = False
        '
        'Btn_Recetas
        '
        Me.Btn_Recetas.Image = CType(resources.GetObject("Btn_Recetas.Image"), System.Drawing.Image)
        Me.Btn_Recetas.ImageIndent = New System.Drawing.Point(8, -6)
        Me.Btn_Recetas.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Recetas.Name = "Btn_Recetas"
        Me.Btn_Recetas.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Recetas.Text = "<font size=""+4""><b>TIPOS</b></font><br/><font size=""-1"">Mantención de tipos de at" &
    "ención</font>"
        Me.Btn_Recetas.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Teal
        Me.Btn_Recetas.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Recetas.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(73, Byte), Integer))
        Me.Btn_Recetas.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(73, Byte), Integer))
        Me.Btn_Recetas.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Recetas.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(73, Byte), Integer))
        Me.Btn_Recetas.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(73, Byte), Integer))
        Me.Btn_Recetas.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Recetas.TileStyle.PaddingBottom = 4
        Me.Btn_Recetas.TileStyle.PaddingLeft = 4
        Me.Btn_Recetas.TileStyle.PaddingRight = 4
        Me.Btn_Recetas.TileStyle.PaddingTop = 4
        Me.Btn_Recetas.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Recetas.TitleText = "BakApp"
        '
        'Btn_Operaciones
        '
        Me.Btn_Operaciones.Image = CType(resources.GetObject("Btn_Operaciones.Image"), System.Drawing.Image)
        Me.Btn_Operaciones.ImageIndent = New System.Drawing.Point(8, -6)
        Me.Btn_Operaciones.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Operaciones.Name = "Btn_Operaciones"
        Me.Btn_Operaciones.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Operaciones.Text = "<font size=""+4""><b>AREAS DEPARTAMENTOS</b></font><br/><font size=""-1"">Mantención " &
    "de areas o departamentos encargados</font>"
        Me.Btn_Operaciones.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Yellow
        Me.Btn_Operaciones.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Operaciones.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(137, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(163, Byte), Integer))
        Me.Btn_Operaciones.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(137, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(163, Byte), Integer))
        Me.Btn_Operaciones.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(137, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(163, Byte), Integer))
        Me.Btn_Operaciones.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(137, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(163, Byte), Integer))
        Me.Btn_Operaciones.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Operaciones.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Operaciones.TitleText = "BakApp"
        '
        'Stk_Configuracion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.Name = "Stk_Configuracion"
        Me.Size = New System.Drawing.Size(641, 334)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents ConsultaPreciosContenedor As DevComponents.DotNetBar.ItemContainer
    Private WithEvents Btn_Agentes As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Conf_Info_Reportes As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Recetas As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Operaciones As DevComponents.DotNetBar.Metro.MetroTileItem
End Class
