<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Stk_Ticktes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Stk_Ticktes))
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnCambiarDeUsuario = New DevComponents.DotNetBar.ButtonItem()
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel()
        Me.ConsultaPreciosContenedor = New DevComponents.DotNetBar.ItemContainer()
        Me.Btn_MisTicket = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_TicketAsignados = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Configuracion = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_VerTodosTickets = New DevComponents.DotNetBar.Metro.MetroTileItem()
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
        Me.LabelX1.Size = New System.Drawing.Size(454, 49)
        Me.LabelX1.TabIndex = 63
        Me.LabelX1.Text = "<font color=""#349FCE""><b>SISTEMA DE TICKETS</b></font>"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSalir, Me.BtnCambiarDeUsuario})
        Me.Bar2.Location = New System.Drawing.Point(0, 289)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(639, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 62
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
        Me.MetroTilePanel1.TabIndex = 61
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
        Me.ConsultaPreciosContenedor.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_MisTicket, Me.Btn_TicketAsignados, Me.Btn_Configuracion, Me.Btn_VerTodosTickets})
        '
        '
        '
        Me.ConsultaPreciosContenedor.TitleStyle.Class = "MetroTileGroupTitle"
        Me.ConsultaPreciosContenedor.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ConsultaPreciosContenedor.TitleStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'Btn_MisTicket
        '
        Me.Btn_MisTicket.Image = CType(resources.GetObject("Btn_MisTicket.Image"), System.Drawing.Image)
        Me.Btn_MisTicket.ImageIndent = New System.Drawing.Point(8, -6)
        Me.Btn_MisTicket.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_MisTicket.Name = "Btn_MisTicket"
        Me.Btn_MisTicket.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_MisTicket.Text = "<font size=""+4""><b>MIS TICKETS</b></font><br/><font size=""-1"">Tickets que yo envi" &
    "ó</font>"
        Me.Btn_MisTicket.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Yellow
        Me.Btn_MisTicket.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_MisTicket.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Btn_MisTicket.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Btn_MisTicket.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Btn_MisTicket.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Btn_MisTicket.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_MisTicket.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_MisTicket.TitleText = "BakApp"
        '
        'Btn_TicketAsignados
        '
        Me.Btn_TicketAsignados.Image = CType(resources.GetObject("Btn_TicketAsignados.Image"), System.Drawing.Image)
        Me.Btn_TicketAsignados.ImageIndent = New System.Drawing.Point(8, -6)
        Me.Btn_TicketAsignados.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_TicketAsignados.Name = "Btn_TicketAsignados"
        Me.Btn_TicketAsignados.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_TicketAsignados.Text = "<font size=""+4""><b>TICKETS ASIGNADOS</b></font><br/><font size=""-1"">Tickets que e" &
    "stan asignados a mi nombre</font>"
        Me.Btn_TicketAsignados.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Yellow
        Me.Btn_TicketAsignados.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_TicketAsignados.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(137, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(163, Byte), Integer))
        Me.Btn_TicketAsignados.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(137, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(163, Byte), Integer))
        Me.Btn_TicketAsignados.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(137, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(163, Byte), Integer))
        Me.Btn_TicketAsignados.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(137, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(163, Byte), Integer))
        Me.Btn_TicketAsignados.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_TicketAsignados.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_TicketAsignados.TitleText = "BakApp"
        '
        'Btn_Configuracion
        '
        Me.Btn_Configuracion.Image = CType(resources.GetObject("Btn_Configuracion.Image"), System.Drawing.Image)
        Me.Btn_Configuracion.ImageIndent = New System.Drawing.Point(8, -6)
        Me.Btn_Configuracion.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Configuracion.Name = "Btn_Configuracion"
        Me.Btn_Configuracion.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Configuracion.Text = "<font size=""+4""><b>CONFIGURACION</b></font><br/><font size=""-1"">Configuración de " &
    "parametros del sistema de tickets</font>"
        Me.Btn_Configuracion.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Teal
        Me.Btn_Configuracion.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Configuracion.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Btn_Configuracion.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Btn_Configuracion.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Configuracion.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Btn_Configuracion.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Btn_Configuracion.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Configuracion.TileStyle.PaddingBottom = 4
        Me.Btn_Configuracion.TileStyle.PaddingLeft = 4
        Me.Btn_Configuracion.TileStyle.PaddingRight = 4
        Me.Btn_Configuracion.TileStyle.PaddingTop = 4
        Me.Btn_Configuracion.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Configuracion.TitleText = "BakApp"
        '
        'Btn_VerTodosTickets
        '
        Me.Btn_VerTodosTickets.Image = CType(resources.GetObject("Btn_VerTodosTickets.Image"), System.Drawing.Image)
        Me.Btn_VerTodosTickets.ImageIndent = New System.Drawing.Point(8, -6)
        Me.Btn_VerTodosTickets.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_VerTodosTickets.Name = "Btn_VerTodosTickets"
        Me.Btn_VerTodosTickets.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_VerTodosTickets.Text = "<font size=""+4""><b>VER TODOS LOS TICKETS</b></font><br/><font size=""-1"">Mostrar t" &
    "odos los tickets que hay en el sistema.</font>"
        Me.Btn_VerTodosTickets.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Teal
        Me.Btn_VerTodosTickets.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_VerTodosTickets.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.Btn_VerTodosTickets.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.Btn_VerTodosTickets.TileStyle.BackColorGradientAngle = 45
        Me.Btn_VerTodosTickets.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.Btn_VerTodosTickets.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.Btn_VerTodosTickets.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_VerTodosTickets.TileStyle.PaddingBottom = 4
        Me.Btn_VerTodosTickets.TileStyle.PaddingLeft = 4
        Me.Btn_VerTodosTickets.TileStyle.PaddingRight = 4
        Me.Btn_VerTodosTickets.TileStyle.PaddingTop = 4
        Me.Btn_VerTodosTickets.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_VerTodosTickets.TitleText = "BakApp"
        '
        'Stk_Ticktes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.Name = "Stk_Ticktes"
        Me.Size = New System.Drawing.Size(639, 330)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents ConsultaPreciosContenedor As DevComponents.DotNetBar.ItemContainer
    Private WithEvents Btn_MisTicket As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Configuracion As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_TicketAsignados As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents BtnCambiarDeUsuario As DevComponents.DotNetBar.ButtonItem
    Private WithEvents Btn_VerTodosTickets As DevComponents.DotNetBar.Metro.MetroTileItem
End Class
