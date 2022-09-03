<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Sol_Recom_Compra_Pr
    Inherits DevComponents.DotNetBar.Metro.MetroForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Sol_Recom_Compra_Pr))
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Enviar = New DevComponents.DotNetBar.ButtonItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Txt_Nokopr = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Txt_Observaciones = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Rdb_Para_Stock = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Venta_Calzada = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Btn_Buscar_Cliente = New DevComponents.DotNetBar.ButtonX()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Txt_Razon_Cliente = New System.Windows.Forms.TextBox()
        Me.Txt_CodCliente = New System.Windows.Forms.TextBox()
        Me.Grupo_Cliente = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Input_Valor_Anticipo = New DevComponents.Editors.IntegerInput()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Chk_Deja_Anticipo_SI = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Deja_Anticipo_NO = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Input_Cantidad = New DevComponents.Editors.IntegerInput()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_Cliente.SuspendLayout()
        CType(Me.Input_Valor_Anticipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.Input_Cantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Enviar})
        Me.Bar1.Location = New System.Drawing.Point(0, 368)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(489, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 21
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Enviar
        '
        Me.Btn_Enviar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Enviar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Enviar.Image = CType(resources.GetObject("Btn_Enviar.Image"), System.Drawing.Image)
        Me.Btn_Enviar.Name = "Btn_Enviar"
        Me.Btn_Enviar.Text = "Enviar solicitud"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Descripción"
        '
        'Txt_Nokopr
        '
        Me.Txt_Nokopr.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Nokopr.Border.Class = "TextBoxBorder"
        Me.Txt_Nokopr.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Nokopr.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Nokopr.FocusHighlightEnabled = True
        Me.Txt_Nokopr.ForeColor = System.Drawing.Color.Black
        Me.Txt_Nokopr.Location = New System.Drawing.Point(6, 16)
        Me.Txt_Nokopr.Name = "Txt_Nokopr"
        Me.Txt_Nokopr.PreventEnterBeep = True
        Me.Txt_Nokopr.Size = New System.Drawing.Size(448, 22)
        Me.Txt_Nokopr.TabIndex = 0
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(6, 41)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(82, 13)
        Me.Label10.TabIndex = 126
        Me.Label10.Text = "Observaciones"
        '
        'Txt_Observaciones
        '
        Me.Txt_Observaciones.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Observaciones.Border.Class = "TextBoxBorder"
        Me.Txt_Observaciones.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Observaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Observaciones.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Observaciones.FocusHighlightEnabled = True
        Me.Txt_Observaciones.ForeColor = System.Drawing.Color.Black
        Me.Txt_Observaciones.Location = New System.Drawing.Point(6, 57)
        Me.Txt_Observaciones.Multiline = True
        Me.Txt_Observaciones.Name = "Txt_Observaciones"
        Me.Txt_Observaciones.PreventEnterBeep = True
        Me.Txt_Observaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Observaciones.Size = New System.Drawing.Size(448, 59)
        Me.Txt_Observaciones.TabIndex = 1
        '
        'Rdb_Para_Stock
        '
        Me.Rdb_Para_Stock.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Para_Stock.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Para_Stock.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Para_Stock.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Para_Stock.Location = New System.Drawing.Point(6, 140)
        Me.Rdb_Para_Stock.Name = "Rdb_Para_Stock"
        Me.Rdb_Para_Stock.Size = New System.Drawing.Size(73, 23)
        Me.Rdb_Para_Stock.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Para_Stock.TabIndex = 2
        Me.Rdb_Para_Stock.Text = "Para stock"
        '
        'Rdb_Venta_Calzada
        '
        Me.Rdb_Venta_Calzada.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Venta_Calzada.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Venta_Calzada.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Venta_Calzada.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Venta_Calzada.Location = New System.Drawing.Point(85, 140)
        Me.Rdb_Venta_Calzada.Name = "Rdb_Venta_Calzada"
        Me.Rdb_Venta_Calzada.Size = New System.Drawing.Size(100, 23)
        Me.Rdb_Venta_Calzada.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Venta_Calzada.TabIndex = 3
        Me.Rdb_Venta_Calzada.Text = "Venta calzada"
        '
        'Btn_Buscar_Cliente
        '
        Me.Btn_Buscar_Cliente.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Buscar_Cliente.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Buscar_Cliente.Image = CType(resources.GetObject("Btn_Buscar_Cliente.Image"), System.Drawing.Image)
        Me.Btn_Buscar_Cliente.Location = New System.Drawing.Point(183, 10)
        Me.Btn_Buscar_Cliente.Name = "Btn_Buscar_Cliente"
        Me.Btn_Buscar_Cliente.Size = New System.Drawing.Size(29, 22)
        Me.Btn_Buscar_Cliente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Buscar_Cliente.TabIndex = 134
        Me.Btn_Buscar_Cliente.TabStop = False
        Me.Btn_Buscar_Cliente.Tooltip = "Buscar Cliente"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(6, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 130
        Me.Label4.Text = "Entidad"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(6, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 131
        Me.Label3.Text = "Razón social"
        '
        'Txt_Razon_Cliente
        '
        Me.Txt_Razon_Cliente.BackColor = System.Drawing.Color.White
        Me.Txt_Razon_Cliente.ForeColor = System.Drawing.Color.Black
        Me.Txt_Razon_Cliente.Location = New System.Drawing.Point(85, 34)
        Me.Txt_Razon_Cliente.Name = "Txt_Razon_Cliente"
        Me.Txt_Razon_Cliente.ReadOnly = True
        Me.Txt_Razon_Cliente.Size = New System.Drawing.Size(369, 22)
        Me.Txt_Razon_Cliente.TabIndex = 133
        Me.Txt_Razon_Cliente.TabStop = False
        '
        'Txt_CodCliente
        '
        Me.Txt_CodCliente.BackColor = System.Drawing.Color.White
        Me.Txt_CodCliente.ForeColor = System.Drawing.Color.Black
        Me.Txt_CodCliente.Location = New System.Drawing.Point(85, 10)
        Me.Txt_CodCliente.Name = "Txt_CodCliente"
        Me.Txt_CodCliente.ReadOnly = True
        Me.Txt_CodCliente.Size = New System.Drawing.Size(92, 22)
        Me.Txt_CodCliente.TabIndex = 132
        Me.Txt_CodCliente.TabStop = False
        '
        'Grupo_Cliente
        '
        Me.Grupo_Cliente.BackColor = System.Drawing.Color.White
        Me.Grupo_Cliente.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Cliente.Controls.Add(Me.Input_Valor_Anticipo)
        Me.Grupo_Cliente.Controls.Add(Me.Label5)
        Me.Grupo_Cliente.Controls.Add(Me.Label2)
        Me.Grupo_Cliente.Controls.Add(Me.Label4)
        Me.Grupo_Cliente.Controls.Add(Me.Chk_Deja_Anticipo_SI)
        Me.Grupo_Cliente.Controls.Add(Me.Txt_CodCliente)
        Me.Grupo_Cliente.Controls.Add(Me.Chk_Deja_Anticipo_NO)
        Me.Grupo_Cliente.Controls.Add(Me.Btn_Buscar_Cliente)
        Me.Grupo_Cliente.Controls.Add(Me.Txt_Razon_Cliente)
        Me.Grupo_Cliente.Controls.Add(Me.Label3)
        Me.Grupo_Cliente.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Cliente.Location = New System.Drawing.Point(12, 208)
        Me.Grupo_Cliente.Name = "Grupo_Cliente"
        Me.Grupo_Cliente.Size = New System.Drawing.Size(468, 148)
        '
        '
        '
        Me.Grupo_Cliente.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Cliente.Style.BackColorGradientAngle = 90
        Me.Grupo_Cliente.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Cliente.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Cliente.Style.BorderBottomWidth = 1
        Me.Grupo_Cliente.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Cliente.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Cliente.Style.BorderLeftWidth = 1
        Me.Grupo_Cliente.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Cliente.Style.BorderRightWidth = 1
        Me.Grupo_Cliente.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Cliente.Style.BorderTopWidth = 1
        Me.Grupo_Cliente.Style.CornerDiameter = 4
        Me.Grupo_Cliente.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Cliente.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Cliente.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Cliente.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Cliente.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Cliente.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Cliente.TabIndex = 136
        Me.Grupo_Cliente.Text = "Cliente para venta calzada"
        '
        'Input_Valor_Anticipo
        '
        Me.Input_Valor_Anticipo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_Valor_Anticipo.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_Valor_Anticipo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_Valor_Anticipo.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.Input_Valor_Anticipo.DisplayFormat = "C"
        Me.Input_Valor_Anticipo.Enabled = False
        Me.Input_Valor_Anticipo.ForeColor = System.Drawing.Color.Black
        Me.Input_Valor_Anticipo.Location = New System.Drawing.Point(85, 88)
        Me.Input_Valor_Anticipo.MaxValue = 99999999
        Me.Input_Valor_Anticipo.MinValue = 0
        Me.Input_Valor_Anticipo.Name = "Input_Valor_Anticipo"
        Me.Input_Valor_Anticipo.ShowUpDown = True
        Me.Input_Valor_Anticipo.Size = New System.Drawing.Size(92, 22)
        Me.Input_Valor_Anticipo.TabIndex = 140
        Me.Input_Valor_Anticipo.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(6, 97)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 13)
        Me.Label5.TabIndex = 138
        Me.Label5.Text = "Valor anticipo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(6, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 13)
        Me.Label2.TabIndex = 137
        Me.Label2.Text = "Deja anticipo"
        '
        'Chk_Deja_Anticipo_SI
        '
        Me.Chk_Deja_Anticipo_SI.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Deja_Anticipo_SI.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Deja_Anticipo_SI.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Chk_Deja_Anticipo_SI.ForeColor = System.Drawing.Color.Black
        Me.Chk_Deja_Anticipo_SI.Location = New System.Drawing.Point(85, 65)
        Me.Chk_Deja_Anticipo_SI.Name = "Chk_Deja_Anticipo_SI"
        Me.Chk_Deja_Anticipo_SI.Size = New System.Drawing.Size(28, 23)
        Me.Chk_Deja_Anticipo_SI.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Deja_Anticipo_SI.TabIndex = 135
        Me.Chk_Deja_Anticipo_SI.Text = "SI"
        '
        'Chk_Deja_Anticipo_NO
        '
        Me.Chk_Deja_Anticipo_NO.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Deja_Anticipo_NO.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Deja_Anticipo_NO.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Chk_Deja_Anticipo_NO.ForeColor = System.Drawing.Color.Black
        Me.Chk_Deja_Anticipo_NO.Location = New System.Drawing.Point(119, 65)
        Me.Chk_Deja_Anticipo_NO.Name = "Chk_Deja_Anticipo_NO"
        Me.Chk_Deja_Anticipo_NO.Size = New System.Drawing.Size(58, 23)
        Me.Chk_Deja_Anticipo_NO.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Deja_Anticipo_NO.TabIndex = 136
        Me.Chk_Deja_Anticipo_NO.Text = "NO"
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Input_Cantidad)
        Me.GroupPanel2.Controls.Add(Me.Label7)
        Me.GroupPanel2.Controls.Add(Me.Rdb_Para_Stock)
        Me.GroupPanel2.Controls.Add(Me.Rdb_Venta_Calzada)
        Me.GroupPanel2.Controls.Add(Me.Label6)
        Me.GroupPanel2.Controls.Add(Me.Label1)
        Me.GroupPanel2.Controls.Add(Me.Txt_Nokopr)
        Me.GroupPanel2.Controls.Add(Me.Txt_Observaciones)
        Me.GroupPanel2.Controls.Add(Me.Label10)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(468, 190)
        '
        '
        '
        Me.GroupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel2.Style.BackColorGradientAngle = 90
        Me.GroupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderBottomWidth = 1
        Me.GroupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderLeftWidth = 1
        Me.GroupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderRightWidth = 1
        Me.GroupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderTopWidth = 1
        Me.GroupPanel2.Style.CornerDiameter = 4
        Me.GroupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel2.TabIndex = 137
        Me.GroupPanel2.Text = "Producto"
        '
        'Input_Cantidad
        '
        Me.Input_Cantidad.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_Cantidad.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_Cantidad.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_Cantidad.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.Input_Cantidad.DisplayFormat = "N0"
        Me.Input_Cantidad.Enabled = False
        Me.Input_Cantidad.ForeColor = System.Drawing.Color.Black
        Me.Input_Cantidad.Location = New System.Drawing.Point(194, 142)
        Me.Input_Cantidad.MaxValue = 99999999
        Me.Input_Cantidad.MinValue = 1
        Me.Input_Cantidad.Name = "Input_Cantidad"
        Me.Input_Cantidad.ShowUpDown = True
        Me.Input_Cantidad.Size = New System.Drawing.Size(72, 22)
        Me.Input_Cantidad.TabIndex = 4
        Me.Input_Cantidad.Value = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(6, 124)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 13)
        Me.Label7.TabIndex = 129
        Me.Label7.Text = "Tipo de compra"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(191, 124)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 13)
        Me.Label6.TabIndex = 128
        Me.Label6.Text = "Cantidad"
        '
        'Frm_Sol_Recom_Compra_Pr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(489, 409)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.Grupo_Cliente)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Sol_Recom_Compra_Pr"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Solicitud de recomandación de compra de producto"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo_Cliente.ResumeLayout(False)
        Me.Grupo_Cliente.PerformLayout()
        CType(Me.Input_Valor_Anticipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        Me.GroupPanel2.PerformLayout()
        CType(Me.Input_Cantidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Enviar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Label1 As Label
    Public WithEvents Txt_Nokopr As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label10 As Label
    Public WithEvents Txt_Observaciones As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Rdb_Para_Stock As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Venta_Calzada As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Btn_Buscar_Cliente As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Public WithEvents Txt_Razon_Cliente As TextBox
    Public WithEvents Txt_CodCliente As TextBox
    Friend WithEvents Grupo_Cliente As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Chk_Deja_Anticipo_SI As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Deja_Anticipo_NO As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Input_Cantidad As DevComponents.Editors.IntegerInput
    Friend WithEvents Input_Valor_Anticipo As DevComponents.Editors.IntegerInput
End Class
