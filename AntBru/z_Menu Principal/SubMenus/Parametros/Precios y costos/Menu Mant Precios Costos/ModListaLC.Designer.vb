<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ModListaLC
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ModListaLC))
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem()
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel()
        Me.MnuEspecialPrecios = New DevComponents.DotNetBar.ItemContainer()
        Me.Btn_PreciosFuturo = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_LictaLC = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_UltRecepciones = New DevComponents.DotNetBar.Metro.MetroTileItem()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.LabelX1.Location = New System.Drawing.Point(3, 0)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(627, 49)
        Me.LabelX1.TabIndex = 57
        Me.LabelX1.Text = "<font color=""#349FCE""><b>MANTENCION DE LISTAS DE PRECIOS Y COSTOS LC</b></font>"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSalir})
        Me.Bar2.Location = New System.Drawing.Point(0, 200)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(658, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 56
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
        Me.MetroTilePanel1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.MnuEspecialPrecios})
        Me.MetroTilePanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MetroTilePanel1.Location = New System.Drawing.Point(3, 55)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(778, 405)
        Me.MetroTilePanel1.TabIndex = 55
        Me.MetroTilePanel1.Text = "MetroTilePanel1"
        '
        'MnuEspecialPrecios
        '
        '
        '
        '
        Me.MnuEspecialPrecios.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MnuEspecialPrecios.FixedSize = New System.Drawing.Size(650, 220)
        Me.MnuEspecialPrecios.MultiLine = True
        Me.MnuEspecialPrecios.Name = "MnuEspecialPrecios"
        Me.MnuEspecialPrecios.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_LictaLC, Me.Btn_UltRecepciones, Me.Btn_PreciosFuturo})
        '
        '
        '
        Me.MnuEspecialPrecios.TitleStyle.Class = "MetroTileGroupTitle"
        Me.MnuEspecialPrecios.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'Btn_PreciosFuturo
        '
        Me.Btn_PreciosFuturo.Image = CType(resources.GetObject("Btn_PreciosFuturo.Image"), System.Drawing.Image)
        Me.Btn_PreciosFuturo.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_PreciosFuturo.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_PreciosFuturo.Name = "Btn_PreciosFuturo"
        Me.Btn_PreciosFuturo.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_PreciosFuturo.Text = "<font size=""+4""><b>PRECIOS FUTURO</b></font><br/><font size=""-1"">Lista de product" &
    "os con precios programados a futuro</font>"
        Me.Btn_PreciosFuturo.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Blue
        Me.Btn_PreciosFuturo.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_PreciosFuturo.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_PreciosFuturo.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_PreciosFuturo.TileStyle.BackColorGradientAngle = 45
        Me.Btn_PreciosFuturo.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_PreciosFuturo.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_PreciosFuturo.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_PreciosFuturo.TileStyle.PaddingBottom = 4
        Me.Btn_PreciosFuturo.TileStyle.PaddingLeft = 4
        Me.Btn_PreciosFuturo.TileStyle.PaddingRight = 4
        Me.Btn_PreciosFuturo.TileStyle.PaddingTop = 4
        Me.Btn_PreciosFuturo.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_PreciosFuturo.TitleText = "Bakapp"
        '
        'Btn_LictaLC
        '
        Me.Btn_LictaLC.Image = CType(resources.GetObject("Btn_LictaLC.Image"), System.Drawing.Image)
        Me.Btn_LictaLC.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_LictaLC.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_LictaLC.Name = "Btn_LictaLC"
        Me.Btn_LictaLC.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_LictaLC.Text = "<font size=""+4""><b>LISTA LC</b></font><br/><font size=""-1"">Crear, Editar listas d" &
    "e precios y sus funciones</font>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Btn_LictaLC.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.MaroonWashed
        Me.Btn_LictaLC.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_LictaLC.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(123, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(144, Byte), Integer))
        Me.Btn_LictaLC.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(123, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(144, Byte), Integer))
        Me.Btn_LictaLC.TileStyle.BackColorGradientAngle = 45
        Me.Btn_LictaLC.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(123, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(144, Byte), Integer))
        Me.Btn_LictaLC.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(123, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(144, Byte), Integer))
        Me.Btn_LictaLC.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_LictaLC.TileStyle.PaddingBottom = 4
        Me.Btn_LictaLC.TileStyle.PaddingLeft = 4
        Me.Btn_LictaLC.TileStyle.PaddingRight = 4
        Me.Btn_LictaLC.TileStyle.PaddingTop = 4
        Me.Btn_LictaLC.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_LictaLC.TitleText = "Bakapp"
        '
        'Btn_UltRecepciones
        '
        Me.Btn_UltRecepciones.Image = CType(resources.GetObject("Btn_UltRecepciones.Image"), System.Drawing.Image)
        Me.Btn_UltRecepciones.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_UltRecepciones.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_UltRecepciones.Name = "Btn_UltRecepciones"
        Me.Btn_UltRecepciones.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_UltRecepciones.Text = "<font size=""+4"">Ult. recepciones</font><br/><font size=""-1"">Revisar recepciones y" &
    " actualizar costos de forma directa<br/> (Lista LC)</font>"
        Me.Btn_UltRecepciones.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.MaroonWashed
        Me.Btn_UltRecepciones.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_UltRecepciones.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(123, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(144, Byte), Integer))
        Me.Btn_UltRecepciones.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(123, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(144, Byte), Integer))
        Me.Btn_UltRecepciones.TileStyle.BackColorGradientAngle = 45
        Me.Btn_UltRecepciones.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(123, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(144, Byte), Integer))
        Me.Btn_UltRecepciones.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(123, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(144, Byte), Integer))
        Me.Btn_UltRecepciones.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_UltRecepciones.TileStyle.PaddingBottom = 4
        Me.Btn_UltRecepciones.TileStyle.PaddingLeft = 4
        Me.Btn_UltRecepciones.TileStyle.PaddingRight = 4
        Me.Btn_UltRecepciones.TileStyle.PaddingTop = 4
        Me.Btn_UltRecepciones.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_UltRecepciones.TitleText = "Bakapp"
        '
        'ModListaLC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.Name = "ModListaLC"
        Me.Size = New System.Drawing.Size(658, 241)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents MnuEspecialPrecios As DevComponents.DotNetBar.ItemContainer
    Private WithEvents Btn_LictaLC As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_UltRecepciones As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_PreciosFuturo As DevComponents.DotNetBar.Metro.MetroTileItem
End Class
