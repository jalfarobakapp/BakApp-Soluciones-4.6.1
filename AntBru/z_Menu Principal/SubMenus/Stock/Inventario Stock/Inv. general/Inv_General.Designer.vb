<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Inv_General
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Inv_General))
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnConfiguracion = New DevComponents.DotNetBar.ButtonItem()
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel()
        Me.ConsultaPreciosContenedor = New DevComponents.DotNetBar.ItemContainer()
        Me.Btn_Ingresar_Inventario_Activo = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Mant_Inventarios = New DevComponents.DotNetBar.Metro.MetroTileItem()
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
        Me.ReflectionLabel1.Size = New System.Drawing.Size(265, 39)
        Me.ReflectionLabel1.TabIndex = 38
        Me.ReflectionLabel1.Text = "<b><font size=""+10""><i>I</i><font color=""#B02B2C"">nventario general </font></font" &
    "></b>"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSalir, Me.BtnConfiguracion})
        Me.Bar2.Location = New System.Drawing.Point(0, 206)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(441, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 37
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
        Me.MetroTilePanel1.Location = New System.Drawing.Point(3, 47)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(599, 262)
        Me.MetroTilePanel1.TabIndex = 36
        Me.MetroTilePanel1.Text = "MetroTilePanel1"
        '
        'ConsultaPreciosContenedor
        '
        '
        '
        '
        Me.ConsultaPreciosContenedor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ConsultaPreciosContenedor.FixedSize = New System.Drawing.Size(550, 100)
        Me.ConsultaPreciosContenedor.MultiLine = True
        Me.ConsultaPreciosContenedor.Name = "ConsultaPreciosContenedor"
        Me.ConsultaPreciosContenedor.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Ingresar_Inventario_Activo, Me.Btn_Mant_Inventarios})
        '
        '
        '
        Me.ConsultaPreciosContenedor.TitleStyle.Class = "MetroTileGroupTitle"
        Me.ConsultaPreciosContenedor.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ConsultaPreciosContenedor.TitleStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'Btn_Ingresar_Inventario_Activo
        '
        Me.Btn_Ingresar_Inventario_Activo.Image = CType(resources.GetObject("Btn_Ingresar_Inventario_Activo.Image"), System.Drawing.Image)
        Me.Btn_Ingresar_Inventario_Activo.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Ingresar_Inventario_Activo.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Ingresar_Inventario_Activo.Name = "Btn_Ingresar_Inventario_Activo"
        Me.Btn_Ingresar_Inventario_Activo.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Ingresar_Inventario_Activo.Text = "<font size=""+4""><b>INV. GENERAL</b></font><br/><font size=""-1"">Ingresar al sistem" &
    "a de inventario actual</font>"
        Me.Btn_Ingresar_Inventario_Activo.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.Btn_Ingresar_Inventario_Activo.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Ingresar_Inventario_Activo.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_Ingresar_Inventario_Activo.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_Ingresar_Inventario_Activo.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Ingresar_Inventario_Activo.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_Ingresar_Inventario_Activo.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_Ingresar_Inventario_Activo.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Ingresar_Inventario_Activo.TileStyle.PaddingBottom = 4
        Me.Btn_Ingresar_Inventario_Activo.TileStyle.PaddingLeft = 4
        Me.Btn_Ingresar_Inventario_Activo.TileStyle.PaddingRight = 4
        Me.Btn_Ingresar_Inventario_Activo.TileStyle.PaddingTop = 4
        Me.Btn_Ingresar_Inventario_Activo.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Ingresar_Inventario_Activo.TitleText = "BakApp"
        '
        'Btn_Mant_Inventarios
        '
        Me.Btn_Mant_Inventarios.Image = CType(resources.GetObject("Btn_Mant_Inventarios.Image"), System.Drawing.Image)
        Me.Btn_Mant_Inventarios.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Mant_Inventarios.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Mant_Inventarios.Name = "Btn_Mant_Inventarios"
        Me.Btn_Mant_Inventarios.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Mant_Inventarios.Text = "<font size=""+4""><b>MANT. INVENTARIOS</b></font><br/><font size=""-1"">Crear, editar" &
    ", eliminar</font>"
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
        'Inv_General
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.Name = "Inv_General"
        Me.Size = New System.Drawing.Size(441, 247)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents ConsultaPreciosContenedor As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents BtnConfiguracion As DevComponents.DotNetBar.ButtonItem
    Private WithEvents Btn_Ingresar_Inventario_Activo As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Mant_Inventarios As DevComponents.DotNetBar.Metro.MetroTileItem
End Class
