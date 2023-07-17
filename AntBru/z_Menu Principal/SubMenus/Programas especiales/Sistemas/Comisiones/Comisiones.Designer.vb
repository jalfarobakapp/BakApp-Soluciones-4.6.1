<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Comisiones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Comisiones))
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem()
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel()
        Me.MnuEspecialOtros = New DevComponents.DotNetBar.ItemContainer()
        Me.Btn_Periodos = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Configuracion = New DevComponents.DotNetBar.Metro.MetroTileItem()
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
        Me.LabelX1.Size = New System.Drawing.Size(331, 49)
        Me.LabelX1.TabIndex = 46
        Me.LabelX1.Text = "<font color=""#349FCE""><b>SISTEMA DE COMISIONES</b></font>"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSalir})
        Me.Bar2.Location = New System.Drawing.Point(0, 206)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(448, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 45
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
        Me.MetroTilePanel1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.MnuEspecialOtros})
        Me.MetroTilePanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MetroTilePanel1.Location = New System.Drawing.Point(3, 55)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(844, 619)
        Me.MetroTilePanel1.TabIndex = 44
        Me.MetroTilePanel1.Text = "MetroTilePanel1"
        '
        'MnuEspecialOtros
        '
        '
        '
        '
        Me.MnuEspecialOtros.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MnuEspecialOtros.FixedSize = New System.Drawing.Size(1000, 550)
        Me.MnuEspecialOtros.MultiLine = True
        Me.MnuEspecialOtros.Name = "MnuEspecialOtros"
        Me.MnuEspecialOtros.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Periodos, Me.Btn_Configuracion})
        '
        '
        '
        Me.MnuEspecialOtros.TitleStyle.Class = "MetroTileGroupTitle"
        Me.MnuEspecialOtros.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'Btn_Periodos
        '
        Me.Btn_Periodos.Image = CType(resources.GetObject("Btn_Periodos.Image"), System.Drawing.Image)
        Me.Btn_Periodos.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Periodos.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Periodos.Name = "Btn_Periodos"
        Me.Btn_Periodos.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Periodos.Text = "<font size=""+4""><b>PERIODOS</b></font><br/><font size=""-1"">Mantención de comision" &
    "es por periodos</font>"
        Me.Btn_Periodos.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green
        Me.Btn_Periodos.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Periodos.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_Periodos.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_Periodos.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Periodos.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_Periodos.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_Periodos.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Periodos.TileStyle.PaddingBottom = 4
        Me.Btn_Periodos.TileStyle.PaddingLeft = 4
        Me.Btn_Periodos.TileStyle.PaddingRight = 4
        Me.Btn_Periodos.TileStyle.PaddingTop = 4
        Me.Btn_Periodos.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Periodos.TitleText = "BakApp"
        '
        'Btn_Configuracion
        '
        Me.Btn_Configuracion.Image = CType(resources.GetObject("Btn_Configuracion.Image"), System.Drawing.Image)
        Me.Btn_Configuracion.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Configuracion.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Configuracion.Name = "Btn_Configuracion"
        Me.Btn_Configuracion.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Configuracion.Text = "<font size=""+4""><b>CONFIGURACION</b></font><br/><font size=""-1"">configuración de " &
    "parametros, funcionarios, etc.</font>"
        Me.Btn_Configuracion.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.Btn_Configuracion.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Configuracion.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.Btn_Configuracion.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.Btn_Configuracion.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Configuracion.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.Btn_Configuracion.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.Btn_Configuracion.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Configuracion.TileStyle.PaddingBottom = 4
        Me.Btn_Configuracion.TileStyle.PaddingLeft = 4
        Me.Btn_Configuracion.TileStyle.PaddingRight = 4
        Me.Btn_Configuracion.TileStyle.PaddingTop = 4
        Me.Btn_Configuracion.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Configuracion.TitleText = "BakApp"
        '
        'Comisiones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.Name = "Comisiones"
        Me.Size = New System.Drawing.Size(448, 247)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents MnuEspecialOtros As DevComponents.DotNetBar.ItemContainer
    Private WithEvents Btn_Periodos As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Configuracion As DevComponents.DotNetBar.Metro.MetroTileItem
End Class
