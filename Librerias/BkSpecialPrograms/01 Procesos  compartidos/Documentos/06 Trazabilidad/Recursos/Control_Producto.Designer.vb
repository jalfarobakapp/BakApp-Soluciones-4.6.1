<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Control_Producto
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Control_Producto))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Lbl_Descripcion = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Lbl_Rtu = New System.Windows.Forms.Label()
        Me.Lbl_Unidad = New System.Windows.Forms.Label()
        Me.Lbl_Cantidad = New System.Windows.Forms.Label()
        Me.Lbl_Estado = New System.Windows.Forms.Label()
        Me.Imagen = New DevComponents.DotNetBar.Controls.ReflectionImage()
        Me.labelName = New System.Windows.Forms.LinkLabel()
        Me.Lista_Imagnes_Producto_64 = New System.Windows.Forms.ImageList(Me.components)
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Estadisticas = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Anotacion_a_la_linea = New DevComponents.DotNetBar.ButtonItem()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 17)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Descripción"
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(3, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 16)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "R.T.U."
        '
        'Lbl_Descripcion
        '
        Me.Lbl_Descripcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_Descripcion.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Descripcion.Location = New System.Drawing.Point(76, 0)
        Me.Lbl_Descripcion.Name = "Lbl_Descripcion"
        Me.Lbl_Descripcion.Size = New System.Drawing.Size(223, 17)
        Me.Lbl_Descripcion.TabIndex = 12
        Me.Lbl_Descripcion.Text = "Documento:"
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(3, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 16)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Unidad"
        '
        'Label6
        '
        Me.Label6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(3, 57)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 16)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Cantidad"
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(3, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 16)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Estado"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.17219!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.82781!))
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_Descripcion, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_Rtu, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_Unidad, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_Cantidad, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_Estado, 1, 4)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(75, 22)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(302, 97)
        Me.TableLayoutPanel1.TabIndex = 24
        '
        'Lbl_Rtu
        '
        Me.Lbl_Rtu.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_Rtu.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Rtu.Location = New System.Drawing.Point(76, 19)
        Me.Lbl_Rtu.Name = "Lbl_Rtu"
        Me.Lbl_Rtu.Size = New System.Drawing.Size(223, 16)
        Me.Lbl_Rtu.TabIndex = 19
        Me.Lbl_Rtu.Text = "Número:"
        '
        'Lbl_Unidad
        '
        Me.Lbl_Unidad.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_Unidad.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Unidad.Location = New System.Drawing.Point(76, 38)
        Me.Lbl_Unidad.Name = "Lbl_Unidad"
        Me.Lbl_Unidad.Size = New System.Drawing.Size(223, 16)
        Me.Lbl_Unidad.TabIndex = 13
        Me.Lbl_Unidad.Text = "Fecha emisión:"
        '
        'Lbl_Cantidad
        '
        Me.Lbl_Cantidad.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_Cantidad.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Cantidad.Location = New System.Drawing.Point(76, 57)
        Me.Lbl_Cantidad.Name = "Lbl_Cantidad"
        Me.Lbl_Cantidad.Size = New System.Drawing.Size(223, 16)
        Me.Lbl_Cantidad.TabIndex = 16
        Me.Lbl_Cantidad.Text = "Monto:"
        '
        'Lbl_Estado
        '
        Me.Lbl_Estado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_Estado.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Estado.Location = New System.Drawing.Point(76, 76)
        Me.Lbl_Estado.Name = "Lbl_Estado"
        Me.Lbl_Estado.Size = New System.Drawing.Size(223, 16)
        Me.Lbl_Estado.TabIndex = 17
        Me.Lbl_Estado.Text = "Abonado:"
        '
        'Imagen
        '
        Me.Imagen.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Imagen.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Imagen.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Imagen.Image = CType(resources.GetObject("Imagen.Image"), System.Drawing.Image)
        Me.Imagen.Location = New System.Drawing.Point(0, 22)
        Me.Imagen.Name = "Imagen"
        Me.Imagen.Size = New System.Drawing.Size(69, 104)
        Me.Imagen.TabIndex = 23
        '
        'labelName
        '
        Me.labelName.BackColor = System.Drawing.Color.Transparent
        Me.labelName.Location = New System.Drawing.Point(3, 0)
        Me.labelName.Name = "labelName"
        Me.labelName.Size = New System.Drawing.Size(260, 19)
        Me.labelName.TabIndex = 22
        Me.labelName.TabStop = True
        Me.labelName.Text = "linkLabel1"
        '
        'Lista_Imagnes_Producto_64
        '
        Me.Lista_Imagnes_Producto_64.ImageStream = CType(resources.GetObject("Lista_Imagnes_Producto_64.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Lista_Imagnes_Producto_64.TransparentColor = System.Drawing.Color.Transparent
        Me.Lista_Imagnes_Producto_64.Images.SetKeyName(0, "shipment.png")
        Me.Lista_Imagnes_Producto_64.Images.SetKeyName(1, "package-lock.png")
        Me.Lista_Imagnes_Producto_64.Images.SetKeyName(2, "package-unlock.png")
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.BackColor = System.Drawing.Color.Transparent
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Estadisticas, Me.Btn_Anotacion_a_la_linea})
        Me.Bar2.Location = New System.Drawing.Point(6, 125)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(89, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 41
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Estadisticas
        '
        Me.Btn_Estadisticas.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Estadisticas.ForeColor = System.Drawing.Color.Black
        Me.Btn_Estadisticas.Image = CType(resources.GetObject("Btn_Estadisticas.Image"), System.Drawing.Image)
        Me.Btn_Estadisticas.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Estadisticas.Name = "Btn_Estadisticas"
        Me.Btn_Estadisticas.Tooltip = "Ver estadísticas del producto/información adicional"
        '
        'Btn_Anotacion_a_la_linea
        '
        Me.Btn_Anotacion_a_la_linea.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Anotacion_a_la_linea.ForeColor = System.Drawing.Color.Black
        Me.Btn_Anotacion_a_la_linea.Image = CType(resources.GetObject("Btn_Anotacion_a_la_linea.Image"), System.Drawing.Image)
        Me.Btn_Anotacion_a_la_linea.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Anotacion_a_la_linea.Name = "Btn_Anotacion_a_la_linea"
        Me.Btn_Anotacion_a_la_linea.Tooltip = "Anotaciones, eventos o links asociados a la línea del documento"
        '
        'Control_Producto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Imagen)
        Me.Controls.Add(Me.labelName)
        Me.Name = "Control_Producto"
        Me.Size = New System.Drawing.Size(380, 164)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Lbl_Descripcion As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Lbl_Rtu As System.Windows.Forms.Label
    Friend WithEvents Lbl_Unidad As System.Windows.Forms.Label
    Friend WithEvents Lbl_Cantidad As System.Windows.Forms.Label
    Friend WithEvents Lbl_Estado As System.Windows.Forms.Label
    Friend WithEvents Imagen As DevComponents.DotNetBar.Controls.ReflectionImage
    Friend WithEvents labelName As System.Windows.Forms.LinkLabel
    Friend WithEvents Lista_Imagnes_Producto_64 As System.Windows.Forms.ImageList
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Estadisticas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Anotacion_a_la_linea As DevComponents.DotNetBar.ButtonItem

End Class
