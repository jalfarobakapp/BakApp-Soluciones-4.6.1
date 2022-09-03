<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Inv_Ctrl_Inventario
    Inherits DevComponents.DotNetBar.Metro.MetroForm

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Inv_Ctrl_Inventario))
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel()
        Me.ConsultaPreciosContenedor = New DevComponents.DotNetBar.ItemContainer()
        Me.Btn_Sectores = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Operadores = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Parejas = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Lbl_Nombre_Inventario = New DevComponents.DotNetBar.LabelX()
        Me.Line1 = New DevComponents.DotNetBar.Controls.Line()
        Me.Btn_Plan = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.SuspendLayout()
        '
        'MetroTilePanel1
        '
        Me.MetroTilePanel1.BackColor = System.Drawing.Color.White
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
        Me.MetroTilePanel1.Location = New System.Drawing.Point(12, 63)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(738, 339)
        Me.MetroTilePanel1.TabIndex = 37
        Me.MetroTilePanel1.Text = "MetroTilePanel1"
        '
        'ConsultaPreciosContenedor
        '
        '
        '
        '
        Me.ConsultaPreciosContenedor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ConsultaPreciosContenedor.FixedSize = New System.Drawing.Size(700, 300)
        Me.ConsultaPreciosContenedor.MultiLine = True
        Me.ConsultaPreciosContenedor.Name = "ConsultaPreciosContenedor"
        Me.ConsultaPreciosContenedor.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Sectores, Me.Btn_Operadores, Me.Btn_Parejas, Me.Btn_Plan})
        '
        '
        '
        Me.ConsultaPreciosContenedor.TitleStyle.Class = "MetroTileGroupTitle"
        Me.ConsultaPreciosContenedor.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ConsultaPreciosContenedor.TitleStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'Btn_Sectores
        '
        Me.Btn_Sectores.Image = CType(resources.GetObject("Btn_Sectores.Image"), System.Drawing.Image)
        Me.Btn_Sectores.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Sectores.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Sectores.Name = "Btn_Sectores"
        Me.Btn_Sectores.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Sectores.Text = "<font size=""+4""><b>SECTORES</b></font><br/><font size=""-1"">Mantención de zonas</f" &
    "ont>"
        Me.Btn_Sectores.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.Btn_Sectores.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Sectores.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_Sectores.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_Sectores.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Sectores.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_Sectores.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_Sectores.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Sectores.TileStyle.PaddingBottom = 4
        Me.Btn_Sectores.TileStyle.PaddingLeft = 4
        Me.Btn_Sectores.TileStyle.PaddingRight = 4
        Me.Btn_Sectores.TileStyle.PaddingTop = 4
        Me.Btn_Sectores.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Sectores.TitleText = "BakApp"
        '
        'Btn_Operadores
        '
        Me.Btn_Operadores.Image = CType(resources.GetObject("Btn_Operadores.Image"), System.Drawing.Image)
        Me.Btn_Operadores.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Operadores.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Operadores.Name = "Btn_Operadores"
        Me.Btn_Operadores.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Operadores.Text = "<font size=""+4""><b>OPERADORES</b></font><br/><font size=""-1"">Crear, editar, elimi" &
    "nar</font>"
        Me.Btn_Operadores.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.Btn_Operadores.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Operadores.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.Btn_Operadores.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.Btn_Operadores.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Operadores.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.Btn_Operadores.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.Btn_Operadores.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Operadores.TileStyle.PaddingBottom = 4
        Me.Btn_Operadores.TileStyle.PaddingLeft = 4
        Me.Btn_Operadores.TileStyle.PaddingRight = 4
        Me.Btn_Operadores.TileStyle.PaddingTop = 4
        Me.Btn_Operadores.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Operadores.TitleText = "BakApp"
        '
        'Btn_Parejas
        '
        Me.Btn_Parejas.Image = CType(resources.GetObject("Btn_Parejas.Image"), System.Drawing.Image)
        Me.Btn_Parejas.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Parejas.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Parejas.Name = "Btn_Parejas"
        Me.Btn_Parejas.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Parejas.Text = "<font size=""+4""><b>PAREJAS</b></font><br/><font size=""-1"">Crear, editar, eliminar" &
    "</font>"
        Me.Btn_Parejas.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.Btn_Parejas.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Parejas.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.Btn_Parejas.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.Btn_Parejas.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Parejas.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.Btn_Parejas.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.Btn_Parejas.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Parejas.TileStyle.PaddingBottom = 4
        Me.Btn_Parejas.TileStyle.PaddingLeft = 4
        Me.Btn_Parejas.TileStyle.PaddingRight = 4
        Me.Btn_Parejas.TileStyle.PaddingTop = 4
        Me.Btn_Parejas.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Parejas.TitleText = "BakApp"
        '
        'Lbl_Nombre_Inventario
        '
        Me.Lbl_Nombre_Inventario.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Nombre_Inventario.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Nombre_Inventario.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Nombre_Inventario.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Nombre_Inventario.Location = New System.Drawing.Point(32, 12)
        Me.Lbl_Nombre_Inventario.Name = "Lbl_Nombre_Inventario"
        Me.Lbl_Nombre_Inventario.Size = New System.Drawing.Size(525, 23)
        Me.Lbl_Nombre_Inventario.TabIndex = 38
        Me.Lbl_Nombre_Inventario.Text = "INVENTARIO: NOMBRE DEL INVENTARIO ACTIVO"
        '
        'Line1
        '
        Me.Line1.BackColor = System.Drawing.Color.White
        Me.Line1.ForeColor = System.Drawing.Color.Black
        Me.Line1.Location = New System.Drawing.Point(32, 34)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(740, 23)
        Me.Line1.TabIndex = 39
        Me.Line1.Text = "Line1"
        '
        'Btn_Plan
        '
        Me.Btn_Plan.Image = CType(resources.GetObject("Btn_Plan.Image"), System.Drawing.Image)
        Me.Btn_Plan.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Plan.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Plan.Name = "Btn_Plan"
        Me.Btn_Plan.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Plan.Text = "<font size=""+4""><b>PLAN DE TRABAJO</b></font><br/><font size=""-1"">Detalle del pla" &
    "n de trabajo</font>"
        Me.Btn_Plan.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.Btn_Plan.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Plan.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_Plan.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_Plan.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Plan.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_Plan.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_Plan.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Plan.TileStyle.PaddingBottom = 4
        Me.Btn_Plan.TileStyle.PaddingLeft = 4
        Me.Btn_Plan.TileStyle.PaddingRight = 4
        Me.Btn_Plan.TileStyle.PaddingTop = 4
        Me.Btn_Plan.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Plan.TitleText = "BakApp"
        '
        'Frm_Inv_Ctrl_Inventario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.Line1)
        Me.Controls.Add(Me.Lbl_Nombre_Inventario)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Inv_Ctrl_Inventario"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MANTENCION DE INVENTARIO ACTIVO"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents ConsultaPreciosContenedor As DevComponents.DotNetBar.ItemContainer
    Private WithEvents Btn_Sectores As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Operadores As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Parejas As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents Lbl_Nombre_Inventario As DevComponents.DotNetBar.LabelX
    Friend WithEvents Line1 As DevComponents.DotNetBar.Controls.Line
    Private WithEvents Btn_Plan As DevComponents.DotNetBar.Metro.MetroTileItem
End Class
