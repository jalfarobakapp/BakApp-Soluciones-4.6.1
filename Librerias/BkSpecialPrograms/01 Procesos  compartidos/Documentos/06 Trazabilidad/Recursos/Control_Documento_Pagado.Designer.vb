<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Control_Documento_Pagado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Control_Documento_Pagado))
        Me.Imagen = New DevComponents.DotNetBar.Controls.ReflectionImage()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Ver_documento = New DevComponents.DotNetBar.ButtonItem()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Lbl_Abonado = New System.Windows.Forms.Label()
        Me.labelName = New System.Windows.Forms.LinkLabel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Lbl_Fecha = New System.Windows.Forms.Label()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
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
        Me.Imagen.Location = New System.Drawing.Point(0, 21)
        Me.Imagen.Name = "Imagen"
        Me.Imagen.Size = New System.Drawing.Size(69, 104)
        Me.Imagen.TabIndex = 44
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.BackColor = System.Drawing.Color.Transparent
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Ver_documento})
        Me.Bar2.Location = New System.Drawing.Point(201, 69)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(38, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 46
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Ver_documento
        '
        Me.Btn_Ver_documento.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Ver_documento.ForeColor = System.Drawing.Color.Black
        Me.Btn_Ver_documento.Image = CType(resources.GetObject("Btn_Ver_documento.Image"), System.Drawing.Image)
        Me.Btn_Ver_documento.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Ver_documento.Name = "Btn_Ver_documento"
        Me.Btn_Ver_documento.Tooltip = "Ver documento asignado"
        Me.Btn_Ver_documento.Visible = False
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(3, 0)
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
        Me.Lbl_Abonado.Location = New System.Drawing.Point(76, 0)
        Me.Lbl_Abonado.Name = "Lbl_Abonado"
        Me.Lbl_Abonado.Size = New System.Drawing.Size(85, 16)
        Me.Lbl_Abonado.TabIndex = 17
        Me.Lbl_Abonado.Text = "Abonado:"
        Me.Lbl_Abonado.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'labelName
        '
        Me.labelName.BackColor = System.Drawing.Color.Transparent
        Me.labelName.Dock = System.Windows.Forms.DockStyle.Top
        Me.labelName.Location = New System.Drawing.Point(0, 0)
        Me.labelName.Name = "labelName"
        Me.labelName.Size = New System.Drawing.Size(244, 18)
        Me.labelName.TabIndex = 43
        Me.labelName.TabStop = True
        Me.labelName.Text = "PAGOS"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 73.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_Abonado, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_Fecha, 1, 1)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(75, 21)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(164, 42)
        Me.TableLayoutPanel1.TabIndex = 45
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(3, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 16)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Fecha:"
        '
        'Lbl_Fecha
        '
        Me.Lbl_Fecha.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_Fecha.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Fecha.Location = New System.Drawing.Point(76, 20)
        Me.Lbl_Fecha.Name = "Lbl_Fecha"
        Me.Lbl_Fecha.Size = New System.Drawing.Size(85, 16)
        Me.Lbl_Fecha.TabIndex = 27
        Me.Lbl_Fecha.Text = "Fecha"
        Me.Lbl_Fecha.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Control_Documento_Pagado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.Imagen)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.labelName)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "Control_Documento_Pagado"
        Me.Size = New System.Drawing.Size(244, 124)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Imagen As DevComponents.DotNetBar.Controls.ReflectionImage
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Lbl_Abonado As System.Windows.Forms.Label
    Friend WithEvents labelName As System.Windows.Forms.LinkLabel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Lbl_Fecha As System.Windows.Forms.Label
    Friend WithEvents Btn_Ver_documento As DevComponents.DotNetBar.ButtonItem

End Class
