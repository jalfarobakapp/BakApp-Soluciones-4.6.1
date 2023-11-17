<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Tickets_CambEstado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Tickets_CambEstado))
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel()
        Me.ContenedorTablas = New DevComponents.DotNetBar.ItemContainer()
        Me.Btn_Fabricado_Completamente = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Avance_Porcentaje = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Quitar_Por_Problemas = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Solo_Quitar = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Observaciones = New DevComponents.DotNetBar.Metro.MetroTileItem()
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
        Me.MetroTilePanel1.Location = New System.Drawing.Point(12, 12)
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
        Me.ContenedorTablas.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Fabricado_Completamente, Me.Btn_Avance_Porcentaje, Me.Btn_Quitar_Por_Problemas, Me.Btn_Solo_Quitar, Me.Btn_Observaciones})
        '
        '
        '
        Me.ContenedorTablas.TitleStyle.Class = "MetroTileGroupTitle"
        Me.ContenedorTablas.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'Btn_Fabricado_Completamente
        '
        Me.Btn_Fabricado_Completamente.Image = CType(resources.GetObject("Btn_Fabricado_Completamente.Image"), System.Drawing.Image)
        Me.Btn_Fabricado_Completamente.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Fabricado_Completamente.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Fabricado_Completamente.Name = "Btn_Fabricado_Completamente"
        Me.Btn_Fabricado_Completamente.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Fabricado_Completamente.Text = "<font size=""+6""><b>PRODUCTOS FABRICADOS COMPLETAMENTE</b></font>"
        Me.Btn_Fabricado_Completamente.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.RedViolet
        Me.Btn_Fabricado_Completamente.TileSize = New System.Drawing.Size(300, 100)
        '
        '
        '
        Me.Btn_Fabricado_Completamente.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_Fabricado_Completamente.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_Fabricado_Completamente.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Fabricado_Completamente.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_Fabricado_Completamente.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_Fabricado_Completamente.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Fabricado_Completamente.TileStyle.PaddingBottom = 4
        Me.Btn_Fabricado_Completamente.TileStyle.PaddingLeft = 4
        Me.Btn_Fabricado_Completamente.TileStyle.PaddingRight = 4
        Me.Btn_Fabricado_Completamente.TileStyle.PaddingTop = 4
        Me.Btn_Fabricado_Completamente.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Fabricado_Completamente.TitleText = "OPCION 1"
        '
        'Btn_Avance_Porcentaje
        '
        Me.Btn_Avance_Porcentaje.Image = CType(resources.GetObject("Btn_Avance_Porcentaje.Image"), System.Drawing.Image)
        Me.Btn_Avance_Porcentaje.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Avance_Porcentaje.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Avance_Porcentaje.Name = "Btn_Avance_Porcentaje"
        Me.Btn_Avance_Porcentaje.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Avance_Porcentaje.Text = "<font size=""+6""><b>INGRESAR SOLO UN % DE AVANCE DE LA FABRICACION</b></font>"
        Me.Btn_Avance_Porcentaje.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Yellow
        Me.Btn_Avance_Porcentaje.TileSize = New System.Drawing.Size(300, 100)
        '
        '
        '
        Me.Btn_Avance_Porcentaje.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Btn_Avance_Porcentaje.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Btn_Avance_Porcentaje.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Avance_Porcentaje.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Btn_Avance_Porcentaje.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Btn_Avance_Porcentaje.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Avance_Porcentaje.TileStyle.PaddingBottom = 4
        Me.Btn_Avance_Porcentaje.TileStyle.PaddingLeft = 4
        Me.Btn_Avance_Porcentaje.TileStyle.PaddingRight = 4
        Me.Btn_Avance_Porcentaje.TileStyle.PaddingTop = 4
        Me.Btn_Avance_Porcentaje.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Avance_Porcentaje.TitleText = "OPCION 2"
        '
        'Btn_Quitar_Por_Problemas
        '
        Me.Btn_Quitar_Por_Problemas.Image = CType(resources.GetObject("Btn_Quitar_Por_Problemas.Image"), System.Drawing.Image)
        Me.Btn_Quitar_Por_Problemas.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Quitar_Por_Problemas.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Quitar_Por_Problemas.Name = "Btn_Quitar_Por_Problemas"
        Me.Btn_Quitar_Por_Problemas.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Quitar_Por_Problemas.Text = "<font size=""+4""><b>QUITAR PRODUCTOS DE LA MAQUINA (PROBLEMAS EN LA FABRICACION)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) &
    "</b></font>"
        Me.Btn_Quitar_Por_Problemas.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.DarkBlue
        Me.Btn_Quitar_Por_Problemas.TileSize = New System.Drawing.Size(300, 100)
        '
        '
        '
        Me.Btn_Quitar_Por_Problemas.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_Quitar_Por_Problemas.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_Quitar_Por_Problemas.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Quitar_Por_Problemas.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_Quitar_Por_Problemas.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_Quitar_Por_Problemas.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Quitar_Por_Problemas.TileStyle.PaddingBottom = 4
        Me.Btn_Quitar_Por_Problemas.TileStyle.PaddingLeft = 4
        Me.Btn_Quitar_Por_Problemas.TileStyle.PaddingRight = 4
        Me.Btn_Quitar_Por_Problemas.TileStyle.PaddingTop = 4
        Me.Btn_Quitar_Por_Problemas.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Quitar_Por_Problemas.TitleText = "OPCION 3"
        '
        'Btn_Solo_Quitar
        '
        Me.Btn_Solo_Quitar.Image = CType(resources.GetObject("Btn_Solo_Quitar.Image"), System.Drawing.Image)
        Me.Btn_Solo_Quitar.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Solo_Quitar.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Solo_Quitar.Name = "Btn_Solo_Quitar"
        Me.Btn_Solo_Quitar.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Solo_Quitar.Text = "<font size=""+4""><b>QUITAR PRODUCTOS DE LA MAQUINA (ASIGNADO POR ERROR)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "</b></fon" &
    "t>"
        Me.Btn_Solo_Quitar.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Yellow
        Me.Btn_Solo_Quitar.TileSize = New System.Drawing.Size(300, 100)
        '
        '
        '
        Me.Btn_Solo_Quitar.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(18, Byte), Integer))
        Me.Btn_Solo_Quitar.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(18, Byte), Integer))
        Me.Btn_Solo_Quitar.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Solo_Quitar.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(18, Byte), Integer))
        Me.Btn_Solo_Quitar.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(18, Byte), Integer))
        Me.Btn_Solo_Quitar.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Solo_Quitar.TileStyle.PaddingBottom = 4
        Me.Btn_Solo_Quitar.TileStyle.PaddingLeft = 4
        Me.Btn_Solo_Quitar.TileStyle.PaddingRight = 4
        Me.Btn_Solo_Quitar.TileStyle.PaddingTop = 4
        Me.Btn_Solo_Quitar.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Solo_Quitar.TitleText = "OPCION 4"
        '
        'Btn_Observaciones
        '
        Me.Btn_Observaciones.Image = CType(resources.GetObject("Btn_Observaciones.Image"), System.Drawing.Image)
        Me.Btn_Observaciones.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Observaciones.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Observaciones.Name = "Btn_Observaciones"
        Me.Btn_Observaciones.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Observaciones.Text = "<font size=""+4""><b>AGREGAR OBSERVACIONES" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "</b></font>"
        Me.Btn_Observaciones.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.DarkBlue
        Me.Btn_Observaciones.TileSize = New System.Drawing.Size(300, 100)
        '
        '
        '
        Me.Btn_Observaciones.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Observaciones.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Observaciones.TileStyle.PaddingBottom = 4
        Me.Btn_Observaciones.TileStyle.PaddingLeft = 4
        Me.Btn_Observaciones.TileStyle.PaddingRight = 4
        Me.Btn_Observaciones.TileStyle.PaddingTop = 4
        Me.Btn_Observaciones.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Observaciones.TitleText = "BakApp"
        Me.Btn_Observaciones.Visible = False
        '
        'Frm_Tickets_CambEstado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(349, 649)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Tickets_CambEstado"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents ContenedorTablas As DevComponents.DotNetBar.ItemContainer
    Private WithEvents Btn_Fabricado_Completamente As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Avance_Porcentaje As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Quitar_Por_Problemas As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Solo_Quitar As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Observaciones As DevComponents.DotNetBar.Metro.MetroTileItem
End Class
