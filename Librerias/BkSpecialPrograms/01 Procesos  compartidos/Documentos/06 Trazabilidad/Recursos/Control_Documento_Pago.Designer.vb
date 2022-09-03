<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Control_Documento_Pago
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Control_Documento_Pago))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Lbl_Banco = New System.Windows.Forms.Label()
        Me.Lbl_Fecha_Vencimiento = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Lbl_Codigo = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Lbl_Vuelto = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Lbl_Abonado = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Lbl_Monto = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Lbl_Fecha_Emision = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Lbl_Numero = New System.Windows.Forms.Label()
        Me.Lista_Imagnes_Pago_64 = New System.Windows.Forms.ImageList(Me.components)
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Info_doc_pagados = New DevComponents.DotNetBar.ButtonItem()
        Me.labelName = New System.Windows.Forms.LinkLabel()
        Me.Imagen = New DevComponents.DotNetBar.Controls.ReflectionImage()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 218.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_Banco, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_Fecha_Vencimiento, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_Codigo, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_Vuelto, 1, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_Abonado, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_Monto, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_Fecha_Emision, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_Numero, 1, 2)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(75, 21)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 8
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(327, 159)
        Me.TableLayoutPanel1.TabIndex = 45
        '
        'Lbl_Banco
        '
        Me.Lbl_Banco.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_Banco.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Banco.Location = New System.Drawing.Point(112, 19)
        Me.Lbl_Banco.Name = "Lbl_Banco"
        Me.Lbl_Banco.Size = New System.Drawing.Size(212, 16)
        Me.Lbl_Banco.TabIndex = 47
        Me.Lbl_Banco.Text = "Banco:"
        '
        'Lbl_Fecha_Vencimiento
        '
        Me.Lbl_Fecha_Vencimiento.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_Fecha_Vencimiento.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Fecha_Vencimiento.Location = New System.Drawing.Point(112, 76)
        Me.Lbl_Fecha_Vencimiento.Name = "Lbl_Fecha_Vencimiento"
        Me.Lbl_Fecha_Vencimiento.Size = New System.Drawing.Size(212, 16)
        Me.Lbl_Fecha_Vencimiento.TabIndex = 47
        Me.Lbl_Fecha_Vencimiento.Text = "Fecha vencimiento:"
        '
        'Label7
        '
        Me.Label7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(3, 76)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(103, 16)
        Me.Label7.TabIndex = 47
        Me.Label7.Text = "Fecha vencimiento:"
        '
        'Lbl_Codigo
        '
        Me.Lbl_Codigo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_Codigo.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Codigo.Location = New System.Drawing.Point(112, 0)
        Me.Lbl_Codigo.Name = "Lbl_Codigo"
        Me.Lbl_Codigo.Size = New System.Drawing.Size(212, 17)
        Me.Lbl_Codigo.TabIndex = 12
        Me.Lbl_Codigo.Text = "Documento:"
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 17)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Documento:"
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(3, 135)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 16)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Vuelto"
        '
        'Lbl_Vuelto
        '
        Me.Lbl_Vuelto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_Vuelto.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Vuelto.Location = New System.Drawing.Point(112, 135)
        Me.Lbl_Vuelto.Name = "Lbl_Vuelto"
        Me.Lbl_Vuelto.Size = New System.Drawing.Size(212, 16)
        Me.Lbl_Vuelto.TabIndex = 29
        Me.Lbl_Vuelto.Text = "Vuelto"
        Me.Lbl_Vuelto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(3, 115)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(103, 16)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Abonado:"
        '
        'Lbl_Abonado
        '
        Me.Lbl_Abonado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_Abonado.ForeColor = System.Drawing.Color.Green
        Me.Lbl_Abonado.Location = New System.Drawing.Point(112, 115)
        Me.Lbl_Abonado.Name = "Lbl_Abonado"
        Me.Lbl_Abonado.Size = New System.Drawing.Size(212, 16)
        Me.Lbl_Abonado.TabIndex = 17
        Me.Lbl_Abonado.Text = "Abonado:"
        Me.Lbl_Abonado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(3, 95)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(103, 16)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Monto:"
        '
        'Lbl_Monto
        '
        Me.Lbl_Monto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_Monto.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Monto.Location = New System.Drawing.Point(112, 95)
        Me.Lbl_Monto.Name = "Lbl_Monto"
        Me.Lbl_Monto.Size = New System.Drawing.Size(212, 16)
        Me.Lbl_Monto.TabIndex = 16
        Me.Lbl_Monto.Text = "Monto:"
        Me.Lbl_Monto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(3, 57)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 16)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Fecha emisión:"
        '
        'Lbl_Fecha_Emision
        '
        Me.Lbl_Fecha_Emision.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_Fecha_Emision.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Fecha_Emision.Location = New System.Drawing.Point(112, 57)
        Me.Lbl_Fecha_Emision.Name = "Lbl_Fecha_Emision"
        Me.Lbl_Fecha_Emision.Size = New System.Drawing.Size(212, 16)
        Me.Lbl_Fecha_Emision.TabIndex = 13
        Me.Lbl_Fecha_Emision.Text = "Fecha emisión:"
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(3, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 16)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Número:"
        '
        'Lbl_Numero
        '
        Me.Lbl_Numero.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_Numero.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Numero.Location = New System.Drawing.Point(112, 38)
        Me.Lbl_Numero.Name = "Lbl_Numero"
        Me.Lbl_Numero.Size = New System.Drawing.Size(212, 16)
        Me.Lbl_Numero.TabIndex = 19
        Me.Lbl_Numero.Text = "Número:"
        '
        'Lista_Imagnes_Pago_64
        '
        Me.Lista_Imagnes_Pago_64.ImageStream = CType(resources.GetObject("Lista_Imagnes_Pago_64.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Lista_Imagnes_Pago_64.TransparentColor = System.Drawing.Color.Transparent
        Me.Lista_Imagnes_Pago_64.Images.SetKeyName(0, "money.png")
        Me.Lista_Imagnes_Pago_64.Images.SetKeyName(1, "check.png")
        Me.Lista_Imagnes_Pago_64.Images.SetKeyName(2, "credit_card.png")
        Me.Lista_Imagnes_Pago_64.Images.SetKeyName(3, "stock_exchange.png")
        Me.Lista_Imagnes_Pago_64.Images.SetKeyName(4, "quote.png")
        Me.Lista_Imagnes_Pago_64.Images.SetKeyName(5, "document_text.png")
        Me.Lista_Imagnes_Pago_64.Images.SetKeyName(6, "invoice-to_check.png")
        Me.Lista_Imagnes_Pago_64.Images.SetKeyName(7, "money_banknote-info.png")
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.BackColor = System.Drawing.Color.Transparent
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Info_doc_pagados})
        Me.Bar2.Location = New System.Drawing.Point(3, 186)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(89, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 46
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Info_doc_pagados
        '
        Me.Btn_Info_doc_pagados.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Info_doc_pagados.ForeColor = System.Drawing.Color.Black
        Me.Btn_Info_doc_pagados.Image = CType(resources.GetObject("Btn_Info_doc_pagados.Image"), System.Drawing.Image)
        Me.Btn_Info_doc_pagados.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Info_doc_pagados.Name = "Btn_Info_doc_pagados"
        Me.Btn_Info_doc_pagados.Tooltip = "Ver documentos pagados"
        '
        'labelName
        '
        Me.labelName.BackColor = System.Drawing.Color.Transparent
        Me.labelName.Dock = System.Windows.Forms.DockStyle.Top
        Me.labelName.Location = New System.Drawing.Point(0, 0)
        Me.labelName.Name = "labelName"
        Me.labelName.Size = New System.Drawing.Size(405, 18)
        Me.labelName.TabIndex = 43
        Me.labelName.TabStop = True
        Me.labelName.Text = "linkLabel1"
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
        'Control_Documento_Pago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.labelName)
        Me.Controls.Add(Me.Imagen)
        Me.Name = "Control_Documento_Pago"
        Me.Size = New System.Drawing.Size(405, 229)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Lbl_Codigo As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Lbl_Numero As System.Windows.Forms.Label
    Friend WithEvents Lbl_Fecha_Emision As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Lbl_Monto As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Lbl_Abonado As System.Windows.Forms.Label
    Friend WithEvents Lista_Imagnes_Pago_64 As System.Windows.Forms.ImageList
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents labelName As System.Windows.Forms.LinkLabel
    Friend WithEvents Imagen As DevComponents.DotNetBar.Controls.ReflectionImage
    Friend WithEvents Lbl_Vuelto As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Lbl_Banco As System.Windows.Forms.Label
    Friend WithEvents Lbl_Fecha_Vencimiento As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Btn_Info_doc_pagados As DevComponents.DotNetBar.ButtonItem

End Class
