<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Control_Detalle_Pagos_X_Documento
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Control_Detalle_Pagos_X_Documento))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Lbl_Monto = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Lbl_Abonado = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Lbl_Saldo = New System.Windows.Forms.Label()
        Me.Imagen = New DevComponents.DotNetBar.Controls.ReflectionImage()
        Me.labelName = New System.Windows.Forms.LinkLabel()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Ver_Vencimientos = New DevComponents.DotNetBar.ButtonItem()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 73.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_Monto, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_Abonado, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_Saldo, 1, 2)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(75, 22)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(164, 60)
        Me.TableLayoutPanel1.TabIndex = 23
        '
        'Label6
        '
        Me.Label6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(3, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 16)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Monto:"
        '
        'Lbl_Monto
        '
        Me.Lbl_Monto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_Monto.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Monto.Location = New System.Drawing.Point(76, 0)
        Me.Lbl_Monto.Name = "Lbl_Monto"
        Me.Lbl_Monto.Size = New System.Drawing.Size(85, 16)
        Me.Lbl_Monto.TabIndex = 16
        Me.Lbl_Monto.Text = "Monto:"
        Me.Lbl_Monto.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(3, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 16)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Abonado:"
        '
        'Lbl_Abonado
        '
        Me.Lbl_Abonado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_Abonado.ForeColor = System.Drawing.Color.Green
        Me.Lbl_Abonado.Location = New System.Drawing.Point(76, 20)
        Me.Lbl_Abonado.Name = "Lbl_Abonado"
        Me.Lbl_Abonado.Size = New System.Drawing.Size(85, 16)
        Me.Lbl_Abonado.TabIndex = 17
        Me.Lbl_Abonado.Text = "Abonado:"
        Me.Lbl_Abonado.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(3, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 16)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Saldo:"
        '
        'Lbl_Saldo
        '
        Me.Lbl_Saldo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_Saldo.ForeColor = System.Drawing.Color.DarkRed
        Me.Lbl_Saldo.Location = New System.Drawing.Point(76, 40)
        Me.Lbl_Saldo.Name = "Lbl_Saldo"
        Me.Lbl_Saldo.Size = New System.Drawing.Size(85, 16)
        Me.Lbl_Saldo.TabIndex = 27
        Me.Lbl_Saldo.Text = "Saldo:"
        Me.Lbl_Saldo.TextAlign = System.Drawing.ContentAlignment.TopRight
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
        Me.Imagen.TabIndex = 22
        '
        'labelName
        '
        Me.labelName.BackColor = System.Drawing.Color.Transparent
        Me.labelName.Dock = System.Windows.Forms.DockStyle.Top
        Me.labelName.Location = New System.Drawing.Point(0, 0)
        Me.labelName.Name = "labelName"
        Me.labelName.Size = New System.Drawing.Size(246, 18)
        Me.labelName.TabIndex = 21
        Me.labelName.TabStop = True
        Me.labelName.Text = "PAGOS"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.BackColor = System.Drawing.Color.Transparent
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Ver_Vencimientos})
        Me.Bar2.Location = New System.Drawing.Point(195, 85)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(41, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 42
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Ver_Vencimientos
        '
        Me.Btn_Ver_Vencimientos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Ver_Vencimientos.ForeColor = System.Drawing.Color.Black
        Me.Btn_Ver_Vencimientos.Image = CType(resources.GetObject("Btn_Ver_Vencimientos.Image"), System.Drawing.Image)
        Me.Btn_Ver_Vencimientos.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Ver_Vencimientos.Name = "Btn_Ver_Vencimientos"
        Me.Btn_Ver_Vencimientos.Tooltip = "Ver vencimientos"
        '
        'Control_Detalle_Pagos_X_Documento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Imagen)
        Me.Controls.Add(Me.labelName)
        Me.Name = "Control_Detalle_Pagos_X_Documento"
        Me.Size = New System.Drawing.Size(246, 129)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Lbl_Monto As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Lbl_Abonado As System.Windows.Forms.Label
    Friend WithEvents Imagen As DevComponents.DotNetBar.Controls.ReflectionImage
    Friend WithEvents labelName As System.Windows.Forms.LinkLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Lbl_Saldo As System.Windows.Forms.Label
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Ver_Vencimientos As DevComponents.DotNetBar.ButtonItem

End Class
