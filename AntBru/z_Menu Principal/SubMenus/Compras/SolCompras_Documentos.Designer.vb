﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SolCompras_Documentos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SolCompras_Documentos))
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem()
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel()
        Me.ItemContainer1 = New DevComponents.DotNetBar.ItemContainer()
        Me.Btn_OCC = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_GRC = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Recomendacion_Compra = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSalir})
        Me.Bar2.Location = New System.Drawing.Point(0, 283)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(440, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 33
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
        Me.MetroTilePanel1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer1})
        Me.MetroTilePanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MetroTilePanel1.Location = New System.Drawing.Point(3, 57)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(552, 376)
        Me.MetroTilePanel1.TabIndex = 32
        Me.MetroTilePanel1.Text = "MetroTilePanel1"
        '
        'ItemContainer1
        '
        '
        '
        '
        Me.ItemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer1.FixedSize = New System.Drawing.Size(500, 250)
        Me.ItemContainer1.MultiLine = True
        Me.ItemContainer1.Name = "ItemContainer1"
        Me.ItemContainer1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_OCC, Me.Btn_GRC, Me.Btn_Recomendacion_Compra})
        '
        '
        '
        Me.ItemContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer1.TitleStyle.Font = New System.Drawing.Font("Comic Sans MS", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ItemContainer1.TitleStyle.TextColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(66, Byte), Integer))
        '
        'Btn_OCC
        '
        Me.Btn_OCC.Image = CType(resources.GetObject("Btn_OCC.Image"), System.Drawing.Image)
        Me.Btn_OCC.ImageIndent = New System.Drawing.Point(9, -10)
        Me.Btn_OCC.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_OCC.Name = "Btn_OCC"
        Me.Btn_OCC.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_OCC.Text = "<font size=""+4""><b>OCC - ORDEN DE COMPRA</b></font>"
        Me.Btn_OCC.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Azure
        Me.Btn_OCC.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_OCC.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_OCC.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_OCC.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_OCC.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_OCC.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_OCC.TileStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        '
        'Btn_GRC
        '
        Me.Btn_GRC.Image = CType(resources.GetObject("Btn_GRC.Image"), System.Drawing.Image)
        Me.Btn_GRC.ImageIndent = New System.Drawing.Point(9, -10)
        Me.Btn_GRC.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_GRC.Name = "Btn_GRC"
        Me.Btn_GRC.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_GRC.Text = "<font size=""+4""><b>GRC - GUIA DE RECEPCION DE COMPRA</b></font><br/>"
        Me.Btn_GRC.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green
        Me.Btn_GRC.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_GRC.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(118, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Btn_GRC.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(118, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Btn_GRC.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(118, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Btn_GRC.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(118, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Btn_GRC.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_GRC.TileStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        '
        'Btn_Recomendacion_Compra
        '
        Me.Btn_Recomendacion_Compra.Image = CType(resources.GetObject("Btn_Recomendacion_Compra.Image"), System.Drawing.Image)
        Me.Btn_Recomendacion_Compra.ImageIndent = New System.Drawing.Point(8, -10)
        Me.Btn_Recomendacion_Compra.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Recomendacion_Compra.Name = "Btn_Recomendacion_Compra"
        Me.Btn_Recomendacion_Compra.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Recomendacion_Compra.Text = "<font size=""+4""><b>FCC - FACTURA DE COMPRA</b></font><br/>"
        Me.Btn_Recomendacion_Compra.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Blueish
        Me.Btn_Recomendacion_Compra.TileSize = New System.Drawing.Size(200, 100)
        '
        '
        '
        Me.Btn_Recomendacion_Compra.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.Btn_Recomendacion_Compra.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.Btn_Recomendacion_Compra.TileStyle.BackColorGradientAngle = 45
        Me.Btn_Recomendacion_Compra.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.Btn_Recomendacion_Compra.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.Btn_Recomendacion_Compra.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Recomendacion_Compra.TileStyle.PaddingBottom = 4
        Me.Btn_Recomendacion_Compra.TileStyle.PaddingLeft = 4
        Me.Btn_Recomendacion_Compra.TileStyle.PaddingRight = 4
        Me.Btn_Recomendacion_Compra.TileStyle.PaddingTop = 4
        Me.Btn_Recomendacion_Compra.TileStyle.TextColor = System.Drawing.Color.White
        Me.Btn_Recomendacion_Compra.TitleText = "Bakapp"
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.LabelX1.Location = New System.Drawing.Point(3, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(383, 49)
        Me.LabelX1.TabIndex = 34
        Me.LabelX1.Text = "<font color=""#349FCE""><b>DOCUMENTOS DE COMPRAS</b></font>"
        '
        'SolCompras_Documentos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.Name = "SolCompras_Documentos"
        Me.Size = New System.Drawing.Size(440, 324)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents ItemContainer1 As DevComponents.DotNetBar.ItemContainer
    Private WithEvents Btn_OCC As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_GRC As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Private WithEvents Btn_Recomendacion_Compra As DevComponents.DotNetBar.Metro.MetroTileItem
End Class
