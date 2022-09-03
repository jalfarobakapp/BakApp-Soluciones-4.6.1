<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreditosNegociosMnu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CreditosNegociosMnu))
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel
        Me.Bar2 = New DevComponents.DotNetBar.Bar
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem
        Me.BtnConfiguracion = New DevComponents.DotNetBar.ButtonItem
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel
        Me.ConsultaPreciosContenedor = New DevComponents.DotNetBar.ItemContainer
        Me.Btn_Mis_SCN = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.Btn_Resolucion = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.Context_Menu_Solicitud_Compra = New DevComponents.DotNetBar.ContextMenuBar
        Me.Menu_Contextual_01 = New DevComponents.DotNetBar.ButtonItem
        Me.Lbl_Mnu_1 = New DevComponents.DotNetBar.LabelItem
        Me.Btn_Mnu_Departamento_Credito = New DevComponents.DotNetBar.ButtonItem
        Me.Btn_Mnu_Autorizar_Solicitudes = New DevComponents.DotNetBar.ButtonItem
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Context_Menu_Solicitud_Compra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Location = New System.Drawing.Point(3, 3)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(265, 39)
        Me.ReflectionLabel1.TabIndex = 38
        Me.ReflectionLabel1.Text = "<b><font size=""+10""><i>C</i><font color=""#B02B2C"">réditos por negocios</font></fo" & _
            "nt></b>"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSalir, Me.BtnConfiguracion})
        Me.Bar2.Location = New System.Drawing.Point(0, 184)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(390, 57)
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
        Me.BtnSalir.Image = Global.BakApp.My.Resources.Resources.button_circle_left
        Me.BtnSalir.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Text = "Volver..."
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
        Me.MetroTilePanel1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ConsultaPreciosContenedor})
        Me.MetroTilePanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MetroTilePanel1.Location = New System.Drawing.Point(0, 46)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(589, 132)
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
        Me.ConsultaPreciosContenedor.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Mis_SCN, Me.Btn_Resolucion})
        '
        '
        '
        Me.ConsultaPreciosContenedor.TitleStyle.Class = "MetroTileGroupTitle"
        Me.ConsultaPreciosContenedor.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ConsultaPreciosContenedor.TitleStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'Btn_Mis_SCN
        '
        Me.Btn_Mis_SCN.Image = CType(resources.GetObject("Btn_Mis_SCN.Image"), System.Drawing.Image)
        Me.Btn_Mis_SCN.ImageIndent = New System.Drawing.Point(8, -6)
        Me.Btn_Mis_SCN.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Mis_SCN.Name = "Btn_Mis_SCN"
        Me.Btn_Mis_SCN.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Mis_SCN.Text = "<font size=""+4"">DEPARTAMENTE DE CREDITO</font><br/><font size=""-1"">Gestión negoci" & _
            "os vegentes</font>"
        Me.Btn_Mis_SCN.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Olive
        '
        '
        '
        Me.Btn_Mis_SCN.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Btn_Mis_SCN.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Mis_SCN.TitleText = "BakApp"
        '
        'Btn_Resolucion
        '
        Me.Btn_Resolucion.Image = CType(resources.GetObject("Btn_Resolucion.Image"), System.Drawing.Image)
        Me.Btn_Resolucion.ImageIndent = New System.Drawing.Point(8, -6)
        Me.Btn_Resolucion.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Resolucion.Name = "Btn_Resolucion"
        Me.Btn_Resolucion.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Resolucion.Text = "<font size=""+4"">RESOLUCION COMITE</font><br/><font size=""-1"">Negocios a analizar<" & _
            "/font>"
        Me.Btn_Resolucion.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Teal
        '
        '
        '
        Me.Btn_Resolucion.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Resolucion.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Btn_Resolucion.TileStyle.PaddingBottom = 4
        Me.Btn_Resolucion.TileStyle.PaddingLeft = 4
        Me.Btn_Resolucion.TileStyle.PaddingRight = 4
        Me.Btn_Resolucion.TileStyle.PaddingTop = 4
        Me.Btn_Resolucion.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Resolucion.TitleText = "BakApp"
        '
        'Context_Menu_Solicitud_Compra
        '
        Me.Context_Menu_Solicitud_Compra.AntiAlias = True
        Me.Context_Menu_Solicitud_Compra.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Context_Menu_Solicitud_Compra.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_01})
        Me.Context_Menu_Solicitud_Compra.Location = New System.Drawing.Point(269, 15)
        Me.Context_Menu_Solicitud_Compra.Name = "Context_Menu_Solicitud_Compra"
        Me.Context_Menu_Solicitud_Compra.Size = New System.Drawing.Size(118, 25)
        Me.Context_Menu_Solicitud_Compra.Stretch = True
        Me.Context_Menu_Solicitud_Compra.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Context_Menu_Solicitud_Compra.TabIndex = 49
        Me.Context_Menu_Solicitud_Compra.TabStop = False
        Me.Context_Menu_Solicitud_Compra.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_01
        '
        Me.Menu_Contextual_01.AutoExpandOnClick = True
        Me.Menu_Contextual_01.Name = "Menu_Contextual_01"
        Me.Menu_Contextual_01.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Lbl_Mnu_1, Me.Btn_Mnu_Departamento_Credito, Me.Btn_Mnu_Autorizar_Solicitudes})
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
        Me.Lbl_Mnu_1.Text = "Crédito por negocios"
        '
        'Btn_Mnu_Departamento_Credito
        '
        Me.Btn_Mnu_Departamento_Credito.Image = CType(resources.GetObject("Btn_Mnu_Departamento_Credito.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Departamento_Credito.Name = "Btn_Mnu_Departamento_Credito"
        Me.Btn_Mnu_Departamento_Credito.Text = "Departamento de crédito"
        '
        'Btn_Mnu_Autorizar_Solicitudes
        '
        Me.Btn_Mnu_Autorizar_Solicitudes.Image = CType(resources.GetObject("Btn_Mnu_Autorizar_Solicitudes.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Autorizar_Solicitudes.Name = "Btn_Mnu_Autorizar_Solicitudes"
        Me.Btn_Mnu_Autorizar_Solicitudes.Text = "Resolución comité"
        '
        'CreditosNegociosMnu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Context_Menu_Solicitud_Compra)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.Name = "CreditosNegociosMnu"
        Me.Size = New System.Drawing.Size(390, 241)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Context_Menu_Solicitud_Compra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents ConsultaPreciosContenedor As DevComponents.DotNetBar.ItemContainer
    Private WithEvents Btn_Mis_SCN As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Resolucion As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents BtnConfiguracion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Context_Menu_Solicitud_Compra As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Lbl_Mnu_1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Mnu_Departamento_Credito As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_Autorizar_Solicitudes As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Menu_Contextual_01 As DevComponents.DotNetBar.ButtonItem

End Class
