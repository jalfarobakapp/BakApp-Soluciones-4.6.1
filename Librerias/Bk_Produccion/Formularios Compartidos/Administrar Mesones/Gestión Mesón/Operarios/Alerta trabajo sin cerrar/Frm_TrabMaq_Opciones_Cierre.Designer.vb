<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_TrabMaq_Opciones_Cierre
    Inherits DevComponents.DotNetBar.Metro.MetroForm

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_TrabMaq_Opciones_Cierre))
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel()
        Me.ContenedorTablas = New DevComponents.DotNetBar.ItemContainer()
        Me.Btn_Trabajo_Terminado = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Dejar_Pendiente = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Continuar = New DevComponents.DotNetBar.Metro.MetroTileItem()
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
        Me.MetroTilePanel1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ContenedorTablas})
        Me.MetroTilePanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MetroTilePanel1.Location = New System.Drawing.Point(12, 1)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(718, 676)
        Me.MetroTilePanel1.TabIndex = 37
        Me.MetroTilePanel1.Text = "MetroTilePanel1"
        '
        'ContenedorTablas
        '
        '
        '
        '
        Me.ContenedorTablas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ContenedorTablas.FixedSize = New System.Drawing.Size(500, 600)
        Me.ContenedorTablas.MultiLine = True
        Me.ContenedorTablas.Name = "ContenedorTablas"
        Me.ContenedorTablas.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Trabajo_Terminado, Me.Btn_Dejar_Pendiente, Me.Btn_Continuar})
        '
        '
        '
        Me.ContenedorTablas.TitleStyle.Class = "MetroTileGroupTitle"
        Me.ContenedorTablas.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'Btn_Trabajo_Terminado
        '
        Me.Btn_Trabajo_Terminado.Image = CType(resources.GetObject("Btn_Trabajo_Terminado.Image"), System.Drawing.Image)
        Me.Btn_Trabajo_Terminado.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Trabajo_Terminado.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Trabajo_Terminado.Name = "Btn_Trabajo_Terminado"
        Me.Btn_Trabajo_Terminado.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Trabajo_Terminado.Text = "<font size=""+6""><b>TRABAJO TERMINADO</b></font>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<br/><font size=""+6"">Enviar al s" &
    "iguiente mesón</font>"
        Me.Btn_Trabajo_Terminado.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.RedViolet
        Me.Btn_Trabajo_Terminado.TileSize = New System.Drawing.Size(350, 100)
        '
        '
        '
        Me.Btn_Trabajo_Terminado.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_Trabajo_Terminado.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_Trabajo_Terminado.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Trabajo_Terminado.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_Trabajo_Terminado.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_Trabajo_Terminado.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Trabajo_Terminado.TileStyle.PaddingBottom = 4
        Me.Btn_Trabajo_Terminado.TileStyle.PaddingLeft = 4
        Me.Btn_Trabajo_Terminado.TileStyle.PaddingRight = 4
        Me.Btn_Trabajo_Terminado.TileStyle.PaddingTop = 4
        Me.Btn_Trabajo_Terminado.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Trabajo_Terminado.TitleText = "OPCION 1"
        '
        'Btn_Dejar_Pendiente
        '
        Me.Btn_Dejar_Pendiente.Image = CType(resources.GetObject("Btn_Dejar_Pendiente.Image"), System.Drawing.Image)
        Me.Btn_Dejar_Pendiente.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Dejar_Pendiente.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Dejar_Pendiente.Name = "Btn_Dejar_Pendiente"
        Me.Btn_Dejar_Pendiente.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Dejar_Pendiente.Text = "<font size=""+6""><b>DEJAR PENDIENTE EN MI MESON</b></font>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<br/><font size=""+6"">A" &
    "vance en %</font>"
        Me.Btn_Dejar_Pendiente.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Yellow
        Me.Btn_Dejar_Pendiente.TileSize = New System.Drawing.Size(350, 100)
        '
        '
        '
        Me.Btn_Dejar_Pendiente.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Btn_Dejar_Pendiente.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Btn_Dejar_Pendiente.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Dejar_Pendiente.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Btn_Dejar_Pendiente.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Btn_Dejar_Pendiente.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Dejar_Pendiente.TileStyle.PaddingBottom = 4
        Me.Btn_Dejar_Pendiente.TileStyle.PaddingLeft = 4
        Me.Btn_Dejar_Pendiente.TileStyle.PaddingRight = 4
        Me.Btn_Dejar_Pendiente.TileStyle.PaddingTop = 4
        Me.Btn_Dejar_Pendiente.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Dejar_Pendiente.TitleText = "OPCION 2"
        '
        'Btn_Continuar
        '
        Me.Btn_Continuar.Image = CType(resources.GetObject("Btn_Continuar.Image"), System.Drawing.Image)
        Me.Btn_Continuar.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Continuar.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Continuar.Name = "Btn_Continuar"
        Me.Btn_Continuar.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Continuar.Text = "<font size=""+6""><b>CONTINUAR CON EL TRABAJO</b></font>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<br/><font size=""+6"">El p" &
    "roducto sigue en la máquina</font>"
        Me.Btn_Continuar.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.DarkBlue
        Me.Btn_Continuar.TileSize = New System.Drawing.Size(350, 100)
        '
        '
        '
        Me.Btn_Continuar.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.Btn_Continuar.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.Btn_Continuar.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Continuar.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.Btn_Continuar.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.Btn_Continuar.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Continuar.TileStyle.PaddingBottom = 4
        Me.Btn_Continuar.TileStyle.PaddingLeft = 4
        Me.Btn_Continuar.TileStyle.PaddingRight = 4
        Me.Btn_Continuar.TileStyle.PaddingTop = 4
        Me.Btn_Continuar.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Continuar.TitleText = "OPCION 3"
        '
        'Frm_TrabMaq_Opciones_Cierre
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(404, 340)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_TrabMaq_Opciones_Cierre"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gestión pendiente"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents ContenedorTablas As DevComponents.DotNetBar.ItemContainer
    Private WithEvents Btn_Trabajo_Terminado As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Dejar_Pendiente As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Continuar As DevComponents.DotNetBar.Metro.MetroTileItem
End Class
