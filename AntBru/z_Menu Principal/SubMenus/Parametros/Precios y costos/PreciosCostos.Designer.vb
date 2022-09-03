<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PreciosCostos
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
        Me.Bar2 = New DevComponents.DotNetBar.Bar
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel
        Me.MnuEspecialPrecios = New DevComponents.DotNetBar.ItemContainer
        Me.BtnUltRecpciones = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.BtnListaLC = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.BtnCambioCostoLC = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.BtnActuCostosVILLAR = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.BtnActuCostosMTS = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.BtnCambioCostosFN = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.MetroTileItem1 = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSalir})
        Me.Bar2.Location = New System.Drawing.Point(0, 382)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(600, 57)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 32
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
        Me.MetroTilePanel1.Location = New System.Drawing.Point(3, 63)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(583, 319)
        Me.MetroTilePanel1.TabIndex = 31
        Me.MetroTilePanel1.Text = "MetroTilePanel1"
        '
        'MnuEspecialPrecios
        '
        '
        '
        '
        Me.MnuEspecialPrecios.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MnuEspecialPrecios.FixedSize = New System.Drawing.Size(550, 280)
        Me.MnuEspecialPrecios.MultiLine = True
        Me.MnuEspecialPrecios.Name = "MnuEspecialPrecios"
        Me.MnuEspecialPrecios.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnUltRecpciones, Me.BtnListaLC, Me.BtnCambioCostoLC, Me.BtnActuCostosVILLAR, Me.BtnActuCostosMTS, Me.BtnCambioCostosFN, Me.MetroTileItem1})
        '
        '
        '
        Me.MnuEspecialPrecios.TitleStyle.Class = "MetroTileGroupTitle"
        Me.MnuEspecialPrecios.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'BtnUltRecpciones
        '
        Me.BtnUltRecpciones.Image = Global.BakApp.My.Resources.Resources.list_32
        Me.BtnUltRecpciones.ImageIndent = New System.Drawing.Point(8, -3)
        Me.BtnUltRecpciones.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnUltRecpciones.Name = "BtnUltRecpciones"
        Me.BtnUltRecpciones.SymbolColor = System.Drawing.Color.Empty
        Me.BtnUltRecpciones.Text = "<font size=""+4"">Ult. recepciones</font><br/><font size=""-1"">Revisar recepciones y" & _
            " actualizar costos de forma directa<br/> (Lista LC)</font>"
        Me.BtnUltRecpciones.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        '
        '
        '
        Me.BtnUltRecpciones.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.BtnUltRecpciones.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.BtnUltRecpciones.TileStyle.BackColorGradientAngle = 45
        Me.BtnUltRecpciones.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BtnUltRecpciones.TileStyle.PaddingBottom = 4
        Me.BtnUltRecpciones.TileStyle.PaddingLeft = 4
        Me.BtnUltRecpciones.TileStyle.PaddingRight = 4
        Me.BtnUltRecpciones.TileStyle.PaddingTop = 4
        Me.BtnUltRecpciones.TileStyle.TextColor = System.Drawing.Color.White
        Me.BtnUltRecpciones.TitleText = "BakApp"
        '
        'BtnListaLC
        '
        Me.BtnListaLC.Image = Global.BakApp.My.Resources.Resources.USD_32
        Me.BtnListaLC.ImageIndent = New System.Drawing.Point(8, -6)
        Me.BtnListaLC.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnListaLC.Name = "BtnListaLC"
        Me.BtnListaLC.SymbolColor = System.Drawing.Color.Empty
        Me.BtnListaLC.Text = "<font size=""+4"">Lista LC</font><br/><font size=""-1"">Cambio de costo por productos" & _
            "...</font>"
        Me.BtnListaLC.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        '
        '
        '
        Me.BtnListaLC.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(178, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.BtnListaLC.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.BtnListaLC.TileStyle.BackColorGradientAngle = 45
        Me.BtnListaLC.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BtnListaLC.TileStyle.PaddingBottom = 4
        Me.BtnListaLC.TileStyle.PaddingLeft = 4
        Me.BtnListaLC.TileStyle.PaddingRight = 4
        Me.BtnListaLC.TileStyle.PaddingTop = 4
        Me.BtnListaLC.TileStyle.TextColor = System.Drawing.Color.White
        Me.BtnListaLC.TitleText = "BakApp"
        '
        'BtnCambioCostoLC
        '
        Me.BtnCambioCostoLC.Image = Global.BakApp.My.Resources.Resources.USD_32
        Me.BtnCambioCostoLC.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnCambioCostoLC.Name = "BtnCambioCostoLC"
        Me.BtnCambioCostoLC.SymbolColor = System.Drawing.Color.Empty
        Me.BtnCambioCostoLC.Text = "<font size=""+4"">Cambiar costo</font><br/><font size=""-1"">Actualiza el precio auto" & _
            "maticamente según el costo....</font><br/>"
        Me.BtnCambioCostoLC.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        '
        '
        '
        Me.BtnCambioCostoLC.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(78, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.BtnCambioCostoLC.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(158, Byte), Integer))
        Me.BtnCambioCostoLC.TileStyle.BackColorGradientAngle = 45
        Me.BtnCambioCostoLC.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BtnCambioCostoLC.TileStyle.PaddingBottom = 4
        Me.BtnCambioCostoLC.TileStyle.PaddingLeft = 4
        Me.BtnCambioCostoLC.TileStyle.PaddingRight = 4
        Me.BtnCambioCostoLC.TileStyle.PaddingTop = 4
        Me.BtnCambioCostoLC.TileStyle.TextColor = System.Drawing.Color.Black
        Me.BtnCambioCostoLC.TitleText = "BakApp"
        '
        'BtnActuCostosVILLAR
        '
        Me.BtnActuCostosVILLAR.Image = Global.BakApp.My.Resources.Resources.USD_32
        Me.BtnActuCostosVILLAR.ImageIndent = New System.Drawing.Point(8, -6)
        Me.BtnActuCostosVILLAR.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnActuCostosVILLAR.Name = "BtnActuCostosVILLAR"
        Me.BtnActuCostosVILLAR.SymbolColor = System.Drawing.Color.Empty
        Me.BtnActuCostosVILLAR.Text = "<font size=""+4"">Actualizar costos</font><br/><font size=""-1"">Programa especial pa" & _
            "ra actualizar costos Ferretería O'higgins</font>"
        Me.BtnActuCostosVILLAR.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Magenta
        '
        '
        '
        Me.BtnActuCostosVILLAR.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(121, Byte), Integer), CType(CType(118, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.BtnActuCostosVILLAR.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.BtnActuCostosVILLAR.TileStyle.BackColorGradientAngle = 45
        Me.BtnActuCostosVILLAR.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BtnActuCostosVILLAR.TileStyle.PaddingBottom = 4
        Me.BtnActuCostosVILLAR.TileStyle.PaddingLeft = 4
        Me.BtnActuCostosVILLAR.TileStyle.PaddingRight = 4
        Me.BtnActuCostosVILLAR.TileStyle.PaddingTop = 4
        Me.BtnActuCostosVILLAR.TileStyle.TextColor = System.Drawing.Color.Black
        Me.BtnActuCostosVILLAR.TitleText = "BakApp"
        '
        'BtnActuCostosMTS
        '
        Me.BtnActuCostosMTS.Image = Global.BakApp.My.Resources.Resources.mts
        Me.BtnActuCostosMTS.ImageIndent = New System.Drawing.Point(8, -6)
        Me.BtnActuCostosMTS.ImageTextAlignment = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnActuCostosMTS.Name = "BtnActuCostosMTS"
        Me.BtnActuCostosMTS.SymbolColor = System.Drawing.Color.Empty
        Me.BtnActuCostosMTS.Text = "<font size=""+4"">Actualizar costos</font><br/><font size=""-1"">Programa especial pa" & _
            "ra actualizar costos desde Win MTS</font>"
        Me.BtnActuCostosMTS.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.RedViolet
        '
        '
        '
        Me.BtnActuCostosMTS.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnActuCostosMTS.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnActuCostosMTS.TileStyle.BackColorGradientAngle = 45
        Me.BtnActuCostosMTS.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BtnActuCostosMTS.TileStyle.PaddingBottom = 4
        Me.BtnActuCostosMTS.TileStyle.PaddingLeft = 4
        Me.BtnActuCostosMTS.TileStyle.PaddingRight = 4
        Me.BtnActuCostosMTS.TileStyle.PaddingTop = 4
        Me.BtnActuCostosMTS.TileStyle.TextColor = System.Drawing.Color.White
        Me.BtnActuCostosMTS.TitleText = "BakApp"
        '
        'BtnCambioCostosFN
        '
        Me.BtnCambioCostosFN.Image = Global.BakApp.My.Resources.Resources.USD_32
        Me.BtnCambioCostosFN.ImageIndent = New System.Drawing.Point(8, -6)
        Me.BtnCambioCostosFN.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnCambioCostosFN.Name = "BtnCambioCostosFN"
        Me.BtnCambioCostosFN.SymbolColor = System.Drawing.Color.Empty
        Me.BtnCambioCostosFN.Text = "<font size=""+4"">Cambiar costo</font><br/><font size=""-1"">Actualiza el precio auto" & _
            "maticamente según el costo asignado por producto...</font>"
        Me.BtnCambioCostosFN.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green
        '
        '
        '
        Me.BtnCambioCostosFN.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(147, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.BtnCambioCostosFN.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.BtnCambioCostosFN.TileStyle.BackColorGradientAngle = 45
        Me.BtnCambioCostosFN.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BtnCambioCostosFN.TileStyle.PaddingBottom = 4
        Me.BtnCambioCostosFN.TileStyle.PaddingLeft = 4
        Me.BtnCambioCostosFN.TileStyle.PaddingRight = 4
        Me.BtnCambioCostosFN.TileStyle.PaddingTop = 4
        Me.BtnCambioCostosFN.TileStyle.TextColor = System.Drawing.Color.Black
        Me.BtnCambioCostosFN.TitleText = "BakApp"
        '
        'MetroTileItem1
        '
        Me.MetroTileItem1.Image = Global.BakApp.My.Resources.Resources.money_query
        Me.MetroTileItem1.ImageIndent = New System.Drawing.Point(8, -5)
        Me.MetroTileItem1.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.MetroTileItem1.Name = "MetroTileItem1"
        Me.MetroTileItem1.SymbolColor = System.Drawing.Color.Empty
        Me.MetroTileItem1.Text = "<font size=""+4"">Mantencion Precios/Costos</font><br/><font size=""-1"">Mantención d" & _
            "e lista de precios y costos especial del sistema</font>"
        Me.MetroTileItem1.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        '
        '
        '
        Me.MetroTileItem1.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.MetroTileItem1.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.MetroTileItem1.TileStyle.BackColorGradientAngle = 45
        Me.MetroTileItem1.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MetroTileItem1.TileStyle.PaddingBottom = 4
        Me.MetroTileItem1.TileStyle.PaddingLeft = 4
        Me.MetroTileItem1.TileStyle.PaddingRight = 4
        Me.MetroTileItem1.TileStyle.PaddingTop = 4
        Me.MetroTileItem1.TileStyle.TextColor = System.Drawing.Color.White
        Me.MetroTileItem1.TitleText = "BakApp"
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Location = New System.Drawing.Point(3, 7)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(363, 50)
        Me.ReflectionLabel1.TabIndex = 39
        Me.ReflectionLabel1.Text = "<b><font size=""+10""><i>P</i><font color=""#B02B2C"">recios y costos</font></font></" & _
            "b>"
        '
        'PreciosCostos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.Name = "PreciosCostos"
        Me.Size = New System.Drawing.Size(600, 439)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents MnuEspecialPrecios As DevComponents.DotNetBar.ItemContainer
    Private WithEvents BtnUltRecpciones As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents BtnListaLC As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents BtnCambioCostoLC As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents BtnActuCostosVILLAR As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents BtnActuCostosMTS As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents BtnCambioCostosFN As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents MetroTileItem1 As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel

End Class
