<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class _02_SolCompras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(_02_SolCompras))
        Me.Bar2 = New DevComponents.DotNetBar.Bar
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem
        Me.BtnCambiarDeUsuario = New DevComponents.DotNetBar.ButtonItem
        Me.BtnConfiguracion = New DevComponents.DotNetBar.ButtonItem
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel
        Me.ItemContainer1 = New DevComponents.DotNetBar.ItemContainer
        Me.MtBtnVerMisSolicitudes = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.MtBtnAutorizarSolicitudes = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel
        Me.Context_Menu_Solicitud_Compra = New DevComponents.DotNetBar.ContextMenuBar
        Me.Menu_Contextual_01 = New DevComponents.DotNetBar.ButtonItem
        Me.Lbl_Mnu_1 = New DevComponents.DotNetBar.LabelItem
        Me.Btn_Mnu_Mis_Solicitudes = New DevComponents.DotNetBar.ButtonItem
        Me.Btn_Mnu_Autorizar_Solicitudes = New DevComponents.DotNetBar.ButtonItem
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Context_Menu_Solicitud_Compra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSalir, Me.BtnCambiarDeUsuario, Me.BtnConfiguracion})
        Me.Bar2.Location = New System.Drawing.Point(0, 197)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(413, 57)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 30
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'BtnSalir
        '
        Me.BtnSalir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnSalir.ForeColor = System.Drawing.Color.Black
        Me.BtnSalir.Image = Global.BakApp.My.Resources.Resources.button_circle_left
        Me.BtnSalir.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Text = "Volver..."
        '
        'BtnCambiarDeUsuario
        '
        Me.BtnCambiarDeUsuario.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnCambiarDeUsuario.ForeColor = System.Drawing.Color.Black
        Me.BtnCambiarDeUsuario.Image = Global.BakApp.My.Resources.Resources.user_group
        Me.BtnCambiarDeUsuario.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnCambiarDeUsuario.Name = "BtnCambiarDeUsuario"
        Me.BtnCambiarDeUsuario.Text = "Cambiar de usuario"
        '
        'BtnConfiguracion
        '
        Me.BtnConfiguracion.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnConfiguracion.ForeColor = System.Drawing.Color.Black
        Me.BtnConfiguracion.Image = Global.BakApp.My.Resources.Resources.tools1
        Me.BtnConfiguracion.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnConfiguracion.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnConfiguracion.Name = "BtnConfiguracion"
        Me.BtnConfiguracion.Text = "Configuración local"
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
        Me.MetroTilePanel1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer1})
        Me.MetroTilePanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MetroTilePanel1.Location = New System.Drawing.Point(3, 59)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(585, 128)
        Me.MetroTilePanel1.TabIndex = 29
        Me.MetroTilePanel1.Text = "MetroTilePanel1"
        '
        'ItemContainer1
        '
        '
        '
        '
        Me.ItemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer1.MultiLine = True
        Me.ItemContainer1.Name = "ItemContainer1"
        Me.ItemContainer1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.MtBtnVerMisSolicitudes, Me.MtBtnAutorizarSolicitudes})
        '
        '
        '
        Me.ItemContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer1.TitleStyle.Font = New System.Drawing.Font("Comic Sans MS", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ItemContainer1.TitleStyle.TextColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(66, Byte), Integer))
        '
        'MtBtnVerMisSolicitudes
        '
        Me.MtBtnVerMisSolicitudes.Image = CType(resources.GetObject("MtBtnVerMisSolicitudes.Image"), System.Drawing.Image)
        Me.MtBtnVerMisSolicitudes.ImageIndent = New System.Drawing.Point(9, -10)
        Me.MtBtnVerMisSolicitudes.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.MtBtnVerMisSolicitudes.Name = "MtBtnVerMisSolicitudes"
        Me.MtBtnVerMisSolicitudes.SymbolColor = System.Drawing.Color.Empty
        Me.MtBtnVerMisSolicitudes.Text = "<font size=""+4"">Mis solicitudes</font><br/>Listado de solicitudes generadas por" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & _
            "usuario activo."
        Me.MtBtnVerMisSolicitudes.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Orange
        '
        '
        '
        Me.MtBtnVerMisSolicitudes.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MtBtnVerMisSolicitudes.TileStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        '
        'MtBtnAutorizarSolicitudes
        '
        Me.MtBtnAutorizarSolicitudes.Image = CType(resources.GetObject("MtBtnAutorizarSolicitudes.Image"), System.Drawing.Image)
        Me.MtBtnAutorizarSolicitudes.ImageIndent = New System.Drawing.Point(9, -10)
        Me.MtBtnAutorizarSolicitudes.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.MtBtnAutorizarSolicitudes.Name = "MtBtnAutorizarSolicitudes"
        Me.MtBtnAutorizarSolicitudes.SymbolColor = System.Drawing.Color.Empty
        Me.MtBtnAutorizarSolicitudes.Text = "<font size=""+4"">Autorizar solicitudes</font><br/>Ver lista..."
        Me.MtBtnAutorizarSolicitudes.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Olive
        '
        '
        '
        Me.MtBtnAutorizarSolicitudes.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MtBtnAutorizarSolicitudes.TileStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Location = New System.Drawing.Point(0, 3)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(325, 50)
        Me.ReflectionLabel1.TabIndex = 31
        Me.ReflectionLabel1.Text = "<b><font size=""+10""><i>S</i><font color=""#B02B2C"">olicitudes de compra</font></fo" & _
            "nt></b>"
        '
        'Context_Menu_Solicitud_Compra
        '
        Me.Context_Menu_Solicitud_Compra.AntiAlias = True
        Me.Context_Menu_Solicitud_Compra.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Context_Menu_Solicitud_Compra.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_01})
        Me.Context_Menu_Solicitud_Compra.Location = New System.Drawing.Point(266, 19)
        Me.Context_Menu_Solicitud_Compra.Name = "Context_Menu_Solicitud_Compra"
        Me.Context_Menu_Solicitud_Compra.Size = New System.Drawing.Size(118, 25)
        Me.Context_Menu_Solicitud_Compra.Stretch = True
        Me.Context_Menu_Solicitud_Compra.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Context_Menu_Solicitud_Compra.TabIndex = 48
        Me.Context_Menu_Solicitud_Compra.TabStop = False
        Me.Context_Menu_Solicitud_Compra.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_01
        '
        Me.Menu_Contextual_01.AutoExpandOnClick = True
        Me.Menu_Contextual_01.Name = "Menu_Contextual_01"
        Me.Menu_Contextual_01.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Lbl_Mnu_1, Me.Btn_Mnu_Mis_Solicitudes, Me.Btn_Mnu_Autorizar_Solicitudes})
        Me.Menu_Contextual_01.Text = "Opciones"
        '
        'Lbl_Mnu_1
        '
        Me.Lbl_Mnu_1.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Lbl_Mnu_1.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.Lbl_Mnu_1.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.Lbl_Mnu_1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.Lbl_Mnu_1.Name = "Lbl_Mnu_1"
        Me.Lbl_Mnu_1.PaddingBottom = 1
        Me.Lbl_Mnu_1.PaddingLeft = 10
        Me.Lbl_Mnu_1.PaddingTop = 1
        Me.Lbl_Mnu_1.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.Lbl_Mnu_1.Text = "Solicitudes de compra"
        '
        'Btn_Mnu_Mis_Solicitudes
        '
        Me.Btn_Mnu_Mis_Solicitudes.Image = CType(resources.GetObject("Btn_Mnu_Mis_Solicitudes.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Mis_Solicitudes.Name = "Btn_Mnu_Mis_Solicitudes"
        Me.Btn_Mnu_Mis_Solicitudes.Text = "Mis solicitudes de compra"
        '
        'Btn_Mnu_Autorizar_Solicitudes
        '
        Me.Btn_Mnu_Autorizar_Solicitudes.Image = CType(resources.GetObject("Btn_Mnu_Autorizar_Solicitudes.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Autorizar_Solicitudes.Name = "Btn_Mnu_Autorizar_Solicitudes"
        Me.Btn_Mnu_Autorizar_Solicitudes.Text = "Autorizar solicitudes"
        '
        '_02_SolCompras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Context_Menu_Solicitud_Compra)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.Name = "_02_SolCompras"
        Me.Size = New System.Drawing.Size(413, 254)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Context_Menu_Solicitud_Compra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents ItemContainer1 As DevComponents.DotNetBar.ItemContainer
    Private WithEvents MtBtnVerMisSolicitudes As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents MtBtnAutorizarSolicitudes As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents BtnConfiguracion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnCambiarDeUsuario As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Context_Menu_Solicitud_Compra As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_01 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Lbl_Mnu_1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Mnu_Mis_Solicitudes As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_Autorizar_Solicitudes As DevComponents.DotNetBar.ButtonItem

End Class
