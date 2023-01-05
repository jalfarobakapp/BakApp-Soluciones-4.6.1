<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Modulo_Compras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Modulo_Compras))
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel()
        Me.MnuEspecialOtros = New DevComponents.DotNetBar.ItemContainer()
        Me.Btn_Asistente_Compras = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Documentos_Compra = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Recomendacion_Compra = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnCambiarDeUsuario = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Prb_Automatizaciones = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_NVI = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_OCCStar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_OCCProveedores = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_EjecutarTodas = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Asociar_Prod_Funcionarios = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.MetroTilePanel1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.MnuEspecialOtros})
        Me.MetroTilePanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MetroTilePanel1.Location = New System.Drawing.Point(3, 58)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(704, 280)
        Me.MetroTilePanel1.TabIndex = 1
        Me.MetroTilePanel1.Text = "MetroTilePanel1"
        '
        'MnuEspecialOtros
        '
        '
        '
        '
        Me.MnuEspecialOtros.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MnuEspecialOtros.FixedSize = New System.Drawing.Size(630, 210)
        Me.MnuEspecialOtros.MultiLine = True
        Me.MnuEspecialOtros.Name = "MnuEspecialOtros"
        Me.MnuEspecialOtros.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Asistente_Compras, Me.Btn_Documentos_Compra, Me.Btn_Recomendacion_Compra})
        '
        '
        '
        Me.MnuEspecialOtros.TitleStyle.Class = "MetroTileGroupTitle"
        Me.MnuEspecialOtros.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'Btn_Asistente_Compras
        '
        Me.Btn_Asistente_Compras.Image = CType(resources.GetObject("Btn_Asistente_Compras.Image"), System.Drawing.Image)
        Me.Btn_Asistente_Compras.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Asistente_Compras.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Asistente_Compras.Name = "Btn_Asistente_Compras"
        Me.Btn_Asistente_Compras.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Asistente_Compras.Text = "<font size=""+4""><b>ASISTENTE DE COMPRAS</b></font>"
        Me.Btn_Asistente_Compras.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.DarkBlue
        Me.Btn_Asistente_Compras.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Asistente_Compras.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.Btn_Asistente_Compras.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.Btn_Asistente_Compras.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Asistente_Compras.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.Btn_Asistente_Compras.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.Btn_Asistente_Compras.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Asistente_Compras.TileStyle.PaddingBottom = 4
        Me.Btn_Asistente_Compras.TileStyle.PaddingLeft = 4
        Me.Btn_Asistente_Compras.TileStyle.PaddingRight = 4
        Me.Btn_Asistente_Compras.TileStyle.PaddingTop = 4
        Me.Btn_Asistente_Compras.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Asistente_Compras.TitleText = "Bakapp"
        Me.Btn_Asistente_Compras.TitleTextColor = System.Drawing.Color.White
        '
        'Btn_Documentos_Compra
        '
        Me.Btn_Documentos_Compra.Image = CType(resources.GetObject("Btn_Documentos_Compra.Image"), System.Drawing.Image)
        Me.Btn_Documentos_Compra.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Documentos_Compra.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Documentos_Compra.Name = "Btn_Documentos_Compra"
        Me.Btn_Documentos_Compra.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Documentos_Compra.Text = "<font Size=""+4""><b>DOCUMENTOS DE COMPRA</b></font>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Btn_Documentos_Compra.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Olive
        Me.Btn_Documentos_Compra.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Documentos_Compra.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Btn_Documentos_Compra.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Btn_Documentos_Compra.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Btn_Documentos_Compra.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Btn_Documentos_Compra.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Documentos_Compra.TileStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Btn_Documentos_Compra.TitleText = "Bakapp"
        '
        'Btn_Recomendacion_Compra
        '
        Me.Btn_Recomendacion_Compra.Image = CType(resources.GetObject("Btn_Recomendacion_Compra.Image"), System.Drawing.Image)
        Me.Btn_Recomendacion_Compra.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Recomendacion_Compra.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Recomendacion_Compra.Name = "Btn_Recomendacion_Compra"
        Me.Btn_Recomendacion_Compra.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Recomendacion_Compra.Text = "<font size=""+4""><b>RECOMENDACION DE COMPRA Y VENTAS CALZADAS</b></font><br/>"
        Me.Btn_Recomendacion_Compra.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Blueish
        Me.Btn_Recomendacion_Compra.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Recomendacion_Compra.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_Recomendacion_Compra.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_Recomendacion_Compra.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Recomendacion_Compra.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_Recomendacion_Compra.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_Recomendacion_Compra.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Recomendacion_Compra.TileStyle.PaddingBottom = 4
        Me.Btn_Recomendacion_Compra.TileStyle.PaddingLeft = 4
        Me.Btn_Recomendacion_Compra.TileStyle.PaddingRight = 4
        Me.Btn_Recomendacion_Compra.TileStyle.PaddingTop = 4
        Me.Btn_Recomendacion_Compra.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Recomendacion_Compra.TitleText = "Bakapp"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSalir, Me.BtnCambiarDeUsuario, Me.Btn_Prb_Automatizaciones, Me.Btn_Asociar_Prod_Funcionarios})
        Me.Bar2.Location = New System.Drawing.Point(0, 198)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(632, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 28
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
        'BtnCambiarDeUsuario
        '
        Me.BtnCambiarDeUsuario.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnCambiarDeUsuario.ForeColor = System.Drawing.Color.Black
        Me.BtnCambiarDeUsuario.Image = CType(resources.GetObject("BtnCambiarDeUsuario.Image"), System.Drawing.Image)
        Me.BtnCambiarDeUsuario.ImageAlt = CType(resources.GetObject("BtnCambiarDeUsuario.ImageAlt"), System.Drawing.Image)
        Me.BtnCambiarDeUsuario.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnCambiarDeUsuario.Name = "BtnCambiarDeUsuario"
        Me.BtnCambiarDeUsuario.Tooltip = "Cambiar de usuario"
        '
        'Btn_Prb_Automatizaciones
        '
        Me.Btn_Prb_Automatizaciones.ForeColor = System.Drawing.Color.Black
        Me.Btn_Prb_Automatizaciones.Name = "Btn_Prb_Automatizaciones"
        Me.Btn_Prb_Automatizaciones.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem2, Me.Btn_NVI, Me.Btn_OCCStar, Me.Btn_OCCProveedores, Me.LabelItem1, Me.Btn_EjecutarTodas})
        Me.Btn_Prb_Automatizaciones.Text = "PRB Procedimientos"
        Me.Btn_Prb_Automatizaciones.Visible = False
        '
        'LabelItem2
        '
        Me.LabelItem2.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem2.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem2.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem2.Name = "LabelItem2"
        Me.LabelItem2.PaddingBottom = 1
        Me.LabelItem2.PaddingLeft = 10
        Me.LabelItem2.PaddingTop = 1
        Me.LabelItem2.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem2.Text = "Prueba de uno en uno"
        '
        'Btn_NVI
        '
        Me.Btn_NVI.ForeColor = System.Drawing.Color.Black
        Me.Btn_NVI.Name = "Btn_NVI"
        Me.Btn_NVI.Text = "NVI Automatica"
        '
        'Btn_OCCStar
        '
        Me.Btn_OCCStar.ForeColor = System.Drawing.Color.Black
        Me.Btn_OCCStar.Name = "Btn_OCCStar"
        Me.Btn_OCCStar.Text = "PRB Proveedor Star"
        '
        'Btn_OCCProveedores
        '
        Me.Btn_OCCProveedores.ForeColor = System.Drawing.Color.Black
        Me.Btn_OCCProveedores.Name = "Btn_OCCProveedores"
        Me.Btn_OCCProveedores.Text = "PRB Proveedores"
        '
        'LabelItem1
        '
        Me.LabelItem1.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem1.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem1.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem1.Name = "LabelItem1"
        Me.LabelItem1.PaddingBottom = 1
        Me.LabelItem1.PaddingLeft = 10
        Me.LabelItem1.PaddingTop = 1
        Me.LabelItem1.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem1.Text = "Prueba completa"
        '
        'Btn_EjecutarTodas
        '
        Me.Btn_EjecutarTodas.ForeColor = System.Drawing.Color.Black
        Me.Btn_EjecutarTodas.Name = "Btn_EjecutarTodas"
        Me.Btn_EjecutarTodas.Text = "Ejecutar todos..."
        '
        'Btn_Asociar_Prod_Funcionarios
        '
        Me.Btn_Asociar_Prod_Funcionarios.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Asociar_Prod_Funcionarios.ForeColor = System.Drawing.Color.Black
        Me.Btn_Asociar_Prod_Funcionarios.Image = CType(resources.GetObject("Btn_Asociar_Prod_Funcionarios.Image"), System.Drawing.Image)
        Me.Btn_Asociar_Prod_Funcionarios.ImageAlt = CType(resources.GetObject("Btn_Asociar_Prod_Funcionarios.ImageAlt"), System.Drawing.Image)
        Me.Btn_Asociar_Prod_Funcionarios.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Asociar_Prod_Funcionarios.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.Btn_Asociar_Prod_Funcionarios.Name = "Btn_Asociar_Prod_Funcionarios"
        Me.Btn_Asociar_Prod_Funcionarios.Tooltip = "Mantención de funcionarios validadores de códigos al generar OCC"
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.LabelX1.Location = New System.Drawing.Point(18, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(245, 49)
        Me.LabelX1.TabIndex = 29
        Me.LabelX1.Text = "<font color=""#349FCE""><b>COMPRAS</b></font>"
        '
        'Modulo_Compras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.Name = "Modulo_Compras"
        Me.Size = New System.Drawing.Size(632, 239)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents MnuEspecialOtros As DevComponents.DotNetBar.ItemContainer
    Private WithEvents Btn_Asistente_Compras As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnCambiarDeUsuario As DevComponents.DotNetBar.ButtonItem
    Private WithEvents Btn_Documentos_Compra As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Private WithEvents Btn_Recomendacion_Compra As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents Btn_Asociar_Prod_Funcionarios As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_OCCProveedores As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_OCCStar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_NVI As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Prb_Automatizaciones As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_EjecutarTodas As DevComponents.DotNetBar.ButtonItem
End Class
