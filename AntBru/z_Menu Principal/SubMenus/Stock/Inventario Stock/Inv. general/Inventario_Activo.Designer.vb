<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Inventario_Activo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Inventario_Activo))
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel
        Me.Bar2 = New DevComponents.DotNetBar.Bar
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel
        Me.ConsultaPreciosContenedor = New DevComponents.DotNetBar.ItemContainer
        Me.BtnIngresoHojaConteo = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.BtnVerSectores = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.BtnVerInventario = New DevComponents.DotNetBar.Metro.MetroTileItem
        Me.LblInventarioActual = New DevComponents.DotNetBar.LabelX
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Location = New System.Drawing.Point(0, 1)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(265, 61)
        Me.ReflectionLabel1.TabIndex = 41
        Me.ReflectionLabel1.Text = "<b><font size=""+10""><i>I</i><font color=""#B02B2C"">nventario general </font></font" & _
            "></b>"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSalir})
        Me.Bar2.Location = New System.Drawing.Point(0, 240)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(637, 57)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 40
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
        Me.MetroTilePanel1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ConsultaPreciosContenedor})
        Me.MetroTilePanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MetroTilePanel1.Location = New System.Drawing.Point(3, 89)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(599, 278)
        Me.MetroTilePanel1.TabIndex = 39
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
        Me.ConsultaPreciosContenedor.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnIngresoHojaConteo, Me.BtnVerSectores, Me.BtnVerInventario})
        '
        '
        '
        Me.ConsultaPreciosContenedor.TitleStyle.Class = "MetroTileGroupTitle"
        Me.ConsultaPreciosContenedor.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ConsultaPreciosContenedor.TitleStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'BtnIngresoHojaConteo
        '
        Me.BtnIngresoHojaConteo.Image = CType(resources.GetObject("BtnIngresoHojaConteo.Image"), System.Drawing.Image)
        Me.BtnIngresoHojaConteo.ImageIndent = New System.Drawing.Point(8, -6)
        Me.BtnIngresoHojaConteo.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnIngresoHojaConteo.Name = "BtnIngresoHojaConteo"
        Me.BtnIngresoHojaConteo.SymbolColor = System.Drawing.Color.Empty
        Me.BtnIngresoHojaConteo.Text = "<font size=""+4"">INGRESAR HOJA</font><br/><font size=""-1"">Ingresar conteo de produ" & _
            "ctos</font>"
        Me.BtnIngresoHojaConteo.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        '
        '
        '
        Me.BtnIngresoHojaConteo.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnIngresoHojaConteo.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(103, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnIngresoHojaConteo.TileStyle.BackColorGradientAngle = 45
        Me.BtnIngresoHojaConteo.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BtnIngresoHojaConteo.TileStyle.PaddingBottom = 4
        Me.BtnIngresoHojaConteo.TileStyle.PaddingLeft = 4
        Me.BtnIngresoHojaConteo.TileStyle.PaddingRight = 4
        Me.BtnIngresoHojaConteo.TileStyle.PaddingTop = 4
        Me.BtnIngresoHojaConteo.TileStyle.TextColor = System.Drawing.Color.White
        Me.BtnIngresoHojaConteo.TitleText = "BakApp"
        '
        'BtnVerSectores
        '
        Me.BtnVerSectores.Image = CType(resources.GetObject("BtnVerSectores.Image"), System.Drawing.Image)
        Me.BtnVerSectores.ImageIndent = New System.Drawing.Point(8, -6)
        Me.BtnVerSectores.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnVerSectores.Name = "BtnVerSectores"
        Me.BtnVerSectores.SymbolColor = System.Drawing.Color.Empty
        Me.BtnVerSectores.Text = "<font size=""+4"">VER SECTORES</font><br/><font size=""-1"">Ver estado de avance por " & _
            "sector...</font>"
        Me.BtnVerSectores.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        '
        '
        '
        Me.BtnVerSectores.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.BtnVerSectores.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.BtnVerSectores.TileStyle.BackColorGradientAngle = 45
        Me.BtnVerSectores.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BtnVerSectores.TileStyle.PaddingBottom = 4
        Me.BtnVerSectores.TileStyle.PaddingLeft = 4
        Me.BtnVerSectores.TileStyle.PaddingRight = 4
        Me.BtnVerSectores.TileStyle.PaddingTop = 4
        Me.BtnVerSectores.TileStyle.TextColor = System.Drawing.Color.White
        Me.BtnVerSectores.TitleText = "BakApp"
        '
        'BtnVerInventario
        '
        Me.BtnVerInventario.Image = CType(resources.GetObject("BtnVerInventario.Image"), System.Drawing.Image)
        Me.BtnVerInventario.ImageIndent = New System.Drawing.Point(8, -6)
        Me.BtnVerInventario.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.BtnVerInventario.Name = "BtnVerInventario"
        Me.BtnVerInventario.SymbolColor = System.Drawing.Color.Empty
        Me.BtnVerInventario.Text = "<font size=""+4"">VER INVENTARIO</font><br/><font size=""-1"">Revisar gestión de inve" & _
            "ntario actual</font>"
        Me.BtnVerInventario.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green
        '
        '
        '
        Me.BtnVerInventario.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnVerInventario.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(97, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnVerInventario.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BtnVerInventario.TileStyle.TextColor = System.Drawing.Color.Black
        Me.BtnVerInventario.TitleText = "BakApp"
        '
        'LblInventarioActual
        '
        Me.LblInventarioActual.AutoSize = True
        '
        '
        '
        Me.LblInventarioActual.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblInventarioActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblInventarioActual.Location = New System.Drawing.Point(3, 68)
        Me.LblInventarioActual.Name = "LblInventarioActual"
        Me.LblInventarioActual.Size = New System.Drawing.Size(44, 15)
        Me.LblInventarioActual.TabIndex = 0
        Me.LblInventarioActual.Text = "LabelX1"
        '
        'Inventario_Activo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LblInventarioActual)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.Name = "Inventario_Activo"
        Me.Size = New System.Drawing.Size(637, 297)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents ConsultaPreciosContenedor As DevComponents.DotNetBar.ItemContainer
    Private WithEvents BtnIngresoHojaConteo As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents BtnVerInventario As DevComponents.DotNetBar.Metro.MetroTileItem
    Public WithEvents LblInventarioActual As DevComponents.DotNetBar.LabelX
    Private WithEvents BtnVerSectores As DevComponents.DotNetBar.Metro.MetroTileItem

End Class
