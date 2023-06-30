<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Demonios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Demonios))
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem()
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel()
        Me.MnuEspecialOtros = New DevComponents.DotNetBar.ItemContainer()
        Me.Btn_Demonio_Impresion = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Demonio_Old = New DevComponents.DotNetBar.Metro.MetroTileItem()
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
        Me.LabelX1.Size = New System.Drawing.Size(519, 49)
        Me.LabelX1.TabIndex = 43
        Me.LabelX1.Text = "<font color=""#349FCE""><b>DEMONIOS DE ACCIONES AUTOMATICAS</b></font>"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSalir})
        Me.Bar2.Location = New System.Drawing.Point(0, 201)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(524, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 42
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
        Me.MetroTilePanel1.TabIndex = 41
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
        Me.MnuEspecialOtros.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Demonio_Impresion, Me.Demonio_Old})
        '
        '
        '
        Me.MnuEspecialOtros.TitleStyle.Class = "MetroTileGroupTitle"
        Me.MnuEspecialOtros.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'Btn_Demonio_Impresion
        '
        Me.Btn_Demonio_Impresion.Image = CType(resources.GetObject("Btn_Demonio_Impresion.Image"), System.Drawing.Image)
        Me.Btn_Demonio_Impresion.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Demonio_Impresion.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Demonio_Impresion.Name = "Btn_Demonio_Impresion"
        Me.Btn_Demonio_Impresion.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Demonio_Impresion.Text = "<font size=""+4""><b>DEMONIO</b></font><br/><font size=""-1"">Ingresar al asistente d" &
    "e impresión de picking automatico...</font>"
        Me.Btn_Demonio_Impresion.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green
        Me.Btn_Demonio_Impresion.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Demonio_Impresion.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_Demonio_Impresion.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_Demonio_Impresion.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Demonio_Impresion.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_Demonio_Impresion.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_Demonio_Impresion.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Demonio_Impresion.TileStyle.PaddingBottom = 4
        Me.Btn_Demonio_Impresion.TileStyle.PaddingLeft = 4
        Me.Btn_Demonio_Impresion.TileStyle.PaddingRight = 4
        Me.Btn_Demonio_Impresion.TileStyle.PaddingTop = 4
        Me.Btn_Demonio_Impresion.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Demonio_Impresion.TitleText = "BakApp"
        '
        'Demonio_Old
        '
        Me.Demonio_Old.Image = CType(resources.GetObject("Demonio_Old.Image"), System.Drawing.Image)
        Me.Demonio_Old.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Demonio_Old.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Demonio_Old.Name = "Demonio_Old"
        Me.Demonio_Old.SymbolColor = System.Drawing.Color.Empty
        Me.Demonio_Old.Text = "<font size=""+4""><b>DEMONIO OLD</b></font><br/><font size=""-1"">Diablito antiguo</f" &
    "ont>"
        Me.Demonio_Old.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.Demonio_Old.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Demonio_Old.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.Demonio_Old.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.Demonio_Old.TileStyle.BackColorGradientAngle = 45
        Me.Demonio_Old.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.Demonio_Old.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.Demonio_Old.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Demonio_Old.TileStyle.PaddingBottom = 4
        Me.Demonio_Old.TileStyle.PaddingLeft = 4
        Me.Demonio_Old.TileStyle.PaddingRight = 4
        Me.Demonio_Old.TileStyle.PaddingTop = 4
        Me.Demonio_Old.TileStyle.TextColor = System.Drawing.Color.White
        Me.Demonio_Old.TitleText = "BakApp"
        '
        'Demonios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.Name = "Demonios"
        Me.Size = New System.Drawing.Size(524, 242)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents MnuEspecialOtros As DevComponents.DotNetBar.ItemContainer
    Private WithEvents Btn_Demonio_Impresion As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Demonio_Old As DevComponents.DotNetBar.Metro.MetroTileItem
End Class
