<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ImpBarrasPorDocumento
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ImpBarrasPorDocumento))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.CmbBuscarProducto = New System.Windows.Forms.ComboBox
        Me.TxtDescripcionAbuscar = New System.Windows.Forms.TextBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Dtpfechaemision = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Txtnrodocumento = New System.Windows.Forms.TextBox
        Me.txtrazonsocial = New System.Windows.Forms.TextBox
        Me.Txtipodocumento = New System.Windows.Forms.TextBox
        Me.txtcodigoentidad = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.CmbpuertoLPT = New System.Windows.Forms.ComboBox
        Me.BtnImprimirCero = New System.Windows.Forms.Button
        Me.Btnimprimiretiquetas = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Grilla = New System.Windows.Forms.DataGridView
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Cmbetiquetas = New System.Windows.Forms.ComboBox
        Me.Txtveces = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.GroupBox6)
        Me.GroupBox1.Controls.Add(Me.GroupBox5)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(815, 597)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Documento..."
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.Controls.Add(Me.Label6)
        Me.GroupBox6.Controls.Add(Me.CmbBuscarProducto)
        Me.GroupBox6.Controls.Add(Me.TxtDescripcionAbuscar)
        Me.GroupBox6.Location = New System.Drawing.Point(10, 109)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(795, 57)
        Me.GroupBox6.TabIndex = 5
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Buscar producto en la selección"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(229, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(107, 13)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "Descripción a buscar"
        '
        'CmbBuscarProducto
        '
        Me.CmbBuscarProducto.FormattingEnabled = True
        Me.CmbBuscarProducto.Items.AddRange(New Object() {"CODIGO ENTIDAD (ALTERNATIVO)", "CODIGO PRINCIPAL", "DESCRIPCION"})
        Me.CmbBuscarProducto.Location = New System.Drawing.Point(9, 19)
        Me.CmbBuscarProducto.Name = "CmbBuscarProducto"
        Me.CmbBuscarProducto.Size = New System.Drawing.Size(202, 21)
        Me.CmbBuscarProducto.TabIndex = 0
        Me.CmbBuscarProducto.Text = "CODIGO ENTIDAD (ALTERNATIVO)"
        '
        'TxtDescripcionAbuscar
        '
        Me.TxtDescripcionAbuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtDescripcionAbuscar.Location = New System.Drawing.Point(342, 19)
        Me.TxtDescripcionAbuscar.MaxLength = 50
        Me.TxtDescripcionAbuscar.Name = "TxtDescripcionAbuscar"
        Me.TxtDescripcionAbuscar.Size = New System.Drawing.Size(443, 20)
        Me.TxtDescripcionAbuscar.TabIndex = 26
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.Label5)
        Me.GroupBox5.Controls.Add(Me.Dtpfechaemision)
        Me.GroupBox5.Controls.Add(Me.Label3)
        Me.GroupBox5.Controls.Add(Me.Label1)
        Me.GroupBox5.Controls.Add(Me.Txtnrodocumento)
        Me.GroupBox5.Controls.Add(Me.txtrazonsocial)
        Me.GroupBox5.Controls.Add(Me.Txtipodocumento)
        Me.GroupBox5.Controls.Add(Me.txtcodigoentidad)
        Me.GroupBox5.Controls.Add(Me.Label2)
        Me.GroupBox5.Controls.Add(Me.Label4)
        Me.GroupBox5.Location = New System.Drawing.Point(10, 19)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(793, 84)
        Me.GroupBox5.TabIndex = 4
        Me.GroupBox5.TabStop = False
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(707, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 13)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Fecha emisión"
        '
        'Dtpfechaemision
        '
        Me.Dtpfechaemision.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Dtpfechaemision.Enabled = False
        Me.Dtpfechaemision.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtpfechaemision.Location = New System.Drawing.Point(710, 32)
        Me.Dtpfechaemision.Name = "Dtpfechaemision"
        Me.Dtpfechaemision.Size = New System.Drawing.Size(77, 20)
        Me.Dtpfechaemision.TabIndex = 20
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Tipo Doc."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(76, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Número"
        '
        'Txtnrodocumento
        '
        Me.Txtnrodocumento.Location = New System.Drawing.Point(79, 32)
        Me.Txtnrodocumento.Name = "Txtnrodocumento"
        Me.Txtnrodocumento.ReadOnly = True
        Me.Txtnrodocumento.Size = New System.Drawing.Size(101, 20)
        Me.Txtnrodocumento.TabIndex = 17
        Me.Txtnrodocumento.TabStop = False
        '
        'txtrazonsocial
        '
        Me.txtrazonsocial.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtrazonsocial.Location = New System.Drawing.Point(79, 59)
        Me.txtrazonsocial.Name = "txtrazonsocial"
        Me.txtrazonsocial.ReadOnly = True
        Me.txtrazonsocial.Size = New System.Drawing.Size(708, 20)
        Me.txtrazonsocial.TabIndex = 15
        Me.txtrazonsocial.TabStop = False
        '
        'Txtipodocumento
        '
        Me.Txtipodocumento.Location = New System.Drawing.Point(9, 32)
        Me.Txtipodocumento.Name = "Txtipodocumento"
        Me.Txtipodocumento.ReadOnly = True
        Me.Txtipodocumento.Size = New System.Drawing.Size(59, 20)
        Me.Txtipodocumento.TabIndex = 16
        Me.Txtipodocumento.TabStop = False
        '
        'txtcodigoentidad
        '
        Me.txtcodigoentidad.Location = New System.Drawing.Point(186, 32)
        Me.txtcodigoentidad.Name = "txtcodigoentidad"
        Me.txtcodigoentidad.ReadOnly = True
        Me.txtcodigoentidad.Size = New System.Drawing.Size(140, 20)
        Me.txtcodigoentidad.TabIndex = 14
        Me.txtcodigoentidad.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Razón social"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(183, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Proveedor"
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.CmbpuertoLPT)
        Me.GroupBox4.Controls.Add(Me.BtnImprimirCero)
        Me.GroupBox4.Controls.Add(Me.Btnimprimiretiquetas)
        Me.GroupBox4.Location = New System.Drawing.Point(10, 522)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(795, 69)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(541, 33)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(178, 13)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Puerto de Impresora Matriz de punto"
        '
        'CmbpuertoLPT
        '
        Me.CmbpuertoLPT.FormattingEnabled = True
        Me.CmbpuertoLPT.Items.AddRange(New Object() {"LPT1", "LPT2", "LPT3", "LPT4"})
        Me.CmbpuertoLPT.Location = New System.Drawing.Point(725, 30)
        Me.CmbpuertoLPT.Name = "CmbpuertoLPT"
        Me.CmbpuertoLPT.Size = New System.Drawing.Size(60, 21)
        Me.CmbpuertoLPT.TabIndex = 29
        Me.CmbpuertoLPT.Text = "LPT1"
        '
        'BtnImprimirCero
        '
        Me.BtnImprimirCero.Image = Global.AntBru.My.Resources.Resources.printer
        Me.BtnImprimirCero.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnImprimirCero.Location = New System.Drawing.Point(155, 16)
        Me.BtnImprimirCero.Name = "BtnImprimirCero"
        Me.BtnImprimirCero.Size = New System.Drawing.Size(181, 47)
        Me.BtnImprimirCero.TabIndex = 28
        Me.BtnImprimirCero.Text = "Imprimir cantidades en cero"
        Me.BtnImprimirCero.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnImprimirCero.UseVisualStyleBackColor = True
        '
        'Btnimprimiretiquetas
        '
        Me.Btnimprimiretiquetas.Image = Global.AntBru.My.Resources.Resources.barcode1
        Me.Btnimprimiretiquetas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btnimprimiretiquetas.Location = New System.Drawing.Point(9, 16)
        Me.Btnimprimiretiquetas.Name = "Btnimprimiretiquetas"
        Me.Btnimprimiretiquetas.Size = New System.Drawing.Size(140, 47)
        Me.Btnimprimiretiquetas.TabIndex = 27
        Me.Btnimprimiretiquetas.Text = "Imprimir etíquetas"
        Me.Btnimprimiretiquetas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btnimprimiretiquetas.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.Grilla)
        Me.GroupBox3.Location = New System.Drawing.Point(10, 172)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(795, 281)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Detalle del documento"
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.AllowUserToDeleteRows = False
        Me.Grilla.BackgroundColor = System.Drawing.Color.White
        Me.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla.Location = New System.Drawing.Point(3, 16)
        Me.Grilla.Name = "Grilla"
        Me.Grilla.Size = New System.Drawing.Size(789, 262)
        Me.Grilla.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Cmbetiquetas)
        Me.GroupBox2.Controls.Add(Me.Txtveces)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Location = New System.Drawing.Point(10, 459)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(795, 57)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Selección de etíqueta"
        '
        'Cmbetiquetas
        '
        Me.Cmbetiquetas.FormattingEnabled = True
        Me.Cmbetiquetas.Location = New System.Drawing.Point(9, 19)
        Me.Cmbetiquetas.Name = "Cmbetiquetas"
        Me.Cmbetiquetas.Size = New System.Drawing.Size(317, 21)
        Me.Cmbetiquetas.TabIndex = 0
        '
        'Txtveces
        '
        Me.Txtveces.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txtveces.Location = New System.Drawing.Point(751, 19)
        Me.Txtveces.MaxLength = 2
        Me.Txtveces.Name = "Txtveces"
        Me.Txtveces.ReadOnly = True
        Me.Txtveces.Size = New System.Drawing.Size(34, 20)
        Me.Txtveces.TabIndex = 26
        Me.Txtveces.Text = "1"
        Me.Txtveces.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(601, 22)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(144, 13)
        Me.Label11.TabIndex = 25
        Me.Label11.Text = "Cantidad de etiquetas por fila"
        '
        'Frm_ImpBarrasPorDocumento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(835, 621)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(851, 659)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(851, 659)
        Me.Name = "Frm_ImpBarrasPorDocumento"
        Me.ShowInTaskbar = False
        Me.Text = "Impresión de códigos de barra por documentos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Txtveces As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Grilla As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Dtpfechaemision As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Txtnrodocumento As System.Windows.Forms.TextBox
    Friend WithEvents txtrazonsocial As System.Windows.Forms.TextBox
    Friend WithEvents Txtipodocumento As System.Windows.Forms.TextBox
    Friend WithEvents txtcodigoentidad As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Btnimprimiretiquetas As System.Windows.Forms.Button
    Friend WithEvents Cmbetiquetas As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CmbBuscarProducto As System.Windows.Forms.ComboBox
    Friend WithEvents TxtDescripcionAbuscar As System.Windows.Forms.TextBox
    Friend WithEvents BtnImprimirCero As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CmbpuertoLPT As System.Windows.Forms.ComboBox
End Class
