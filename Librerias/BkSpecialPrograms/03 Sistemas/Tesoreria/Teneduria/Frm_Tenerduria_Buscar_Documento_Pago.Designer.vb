<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Tenerduria_Buscar_Documento_Pago
    Inherits DevComponents.DotNetBar.Metro.MetroForm

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Tenerduria_Buscar_Documento_Pago))
        Me.Grupo_documento = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Num_Top = New System.Windows.Forms.NumericUpDown()
        Me.Num_Monto = New System.Windows.Forms.NumericUpDown()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.Cmb_Estado = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Nro_Cheque = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_Tipo_Doc_Uno = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Cmb_Tipo_de_documentos = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LblNroDocumento = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Buscar_Documentos = New DevComponents.DotNetBar.ButtonX()
        Me.Rdb_Tipo_Doc_Algunos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Txt_Numero_Interno = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Buscar = New DevComponents.DotNetBar.ButtonItem()
        Me.Grupo_Fechas = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Cmb_Fecha_Vencimineto = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Lbl_FV_hasta = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_Fecha_Vencimiento_Hasta = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Cmb_Fecha_Emision = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_Fecha_Vencimiento_Desde = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Dtp_Fecha_Emision_Desde = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_FE_hasta = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_Fecha_Emision_Hasta = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Grupo_Entidad = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Btn_Entidad_Una = New DevComponents.DotNetBar.ButtonX()
        Me.Rdb_Entidad_Todas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Entidad_Una = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Txt_Entidad = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Grupo_documento.SuspendLayout()
        CType(Me.Num_Top, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Num_Monto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_Fechas.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.Dtp_Fecha_Vencimiento_Hasta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_Fecha_Vencimiento_Desde, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_Fecha_Emision_Desde, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_Fecha_Emision_Hasta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_Entidad.SuspendLayout()
        Me.SuspendLayout()
        '
        'Grupo_documento
        '
        Me.Grupo_documento.BackColor = System.Drawing.Color.White
        Me.Grupo_documento.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_documento.Controls.Add(Me.LabelX2)
        Me.Grupo_documento.Controls.Add(Me.Num_Top)
        Me.Grupo_documento.Controls.Add(Me.Num_Monto)
        Me.Grupo_documento.Controls.Add(Me.LabelX7)
        Me.Grupo_documento.Controls.Add(Me.Cmb_Estado)
        Me.Grupo_documento.Controls.Add(Me.LabelX6)
        Me.Grupo_documento.Controls.Add(Me.LabelX5)
        Me.Grupo_documento.Controls.Add(Me.Txt_Nro_Cheque)
        Me.Grupo_documento.Controls.Add(Me.LabelX1)
        Me.Grupo_documento.Controls.Add(Me.Rdb_Tipo_Doc_Uno)
        Me.Grupo_documento.Controls.Add(Me.Cmb_Tipo_de_documentos)
        Me.Grupo_documento.Controls.Add(Me.LblNroDocumento)
        Me.Grupo_documento.Controls.Add(Me.Btn_Buscar_Documentos)
        Me.Grupo_documento.Controls.Add(Me.Rdb_Tipo_Doc_Algunos)
        Me.Grupo_documento.Controls.Add(Me.Txt_Numero_Interno)
        Me.Grupo_documento.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_documento.Location = New System.Drawing.Point(6, 0)
        Me.Grupo_documento.Name = "Grupo_documento"
        Me.Grupo_documento.Size = New System.Drawing.Size(684, 153)
        '
        '
        '
        Me.Grupo_documento.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_documento.Style.BackColorGradientAngle = 90
        Me.Grupo_documento.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_documento.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_documento.Style.BorderBottomWidth = 1
        Me.Grupo_documento.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_documento.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_documento.Style.BorderLeftWidth = 1
        Me.Grupo_documento.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_documento.Style.BorderRightWidth = 1
        Me.Grupo_documento.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_documento.Style.BorderTopWidth = 1
        Me.Grupo_documento.Style.CornerDiameter = 4
        Me.Grupo_documento.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_documento.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_documento.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_documento.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_documento.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_documento.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_documento.TabIndex = 35
        Me.Grupo_documento.Text = "Filtro de documentos"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(233, 94)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(160, 23)
        Me.LabelX2.TabIndex = 37
        Me.LabelX2.Text = "(0 = Sin límite de registros)"
        '
        'Num_Top
        '
        Me.Num_Top.BackColor = System.Drawing.Color.White
        Me.Num_Top.ForeColor = System.Drawing.Color.Black
        Me.Num_Top.Location = New System.Drawing.Point(123, 94)
        Me.Num_Top.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.Num_Top.Name = "Num_Top"
        Me.Num_Top.Size = New System.Drawing.Size(102, 22)
        Me.Num_Top.TabIndex = 36
        Me.Num_Top.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Num_Top.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'Num_Monto
        '
        Me.Num_Monto.BackColor = System.Drawing.Color.White
        Me.Num_Monto.ForeColor = System.Drawing.Color.Black
        Me.Num_Monto.Location = New System.Drawing.Point(420, 66)
        Me.Num_Monto.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.Num_Monto.Name = "Num_Monto"
        Me.Num_Monto.Size = New System.Drawing.Size(94, 22)
        Me.Num_Monto.TabIndex = 34
        Me.Num_Monto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.ForeColor = System.Drawing.Color.Black
        Me.LabelX7.Location = New System.Drawing.Point(520, 37)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(110, 23)
        Me.LabelX7.TabIndex = 33
        Me.LabelX7.Text = "Estado"
        '
        'Cmb_Estado
        '
        Me.Cmb_Estado.DisplayMember = "Text"
        Me.Cmb_Estado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Estado.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Estado.FormattingEnabled = True
        Me.Cmb_Estado.ItemHeight = 16
        Me.Cmb_Estado.Location = New System.Drawing.Point(520, 66)
        Me.Cmb_Estado.Name = "Cmb_Estado"
        Me.Cmb_Estado.Size = New System.Drawing.Size(151, 22)
        Me.Cmb_Estado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Estado.TabIndex = 32
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(420, 37)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(84, 23)
        Me.LabelX6.TabIndex = 31
        Me.LabelX6.Text = "Monto $"
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(330, 37)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(84, 23)
        Me.LabelX5.TabIndex = 29
        Me.LabelX5.Text = "N° Cheque"
        '
        'Txt_Nro_Cheque
        '
        Me.Txt_Nro_Cheque.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Nro_Cheque.Border.Class = "TextBoxBorder"
        Me.Txt_Nro_Cheque.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Nro_Cheque.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Nro_Cheque.FocusHighlightEnabled = True
        Me.Txt_Nro_Cheque.ForeColor = System.Drawing.Color.Black
        Me.Txt_Nro_Cheque.Location = New System.Drawing.Point(330, 66)
        Me.Txt_Nro_Cheque.Name = "Txt_Nro_Cheque"
        Me.Txt_Nro_Cheque.PreventEnterBeep = True
        Me.Txt_Nro_Cheque.Size = New System.Drawing.Size(84, 22)
        Me.Txt_Nro_Cheque.TabIndex = 28
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 94)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(84, 23)
        Me.LabelX1.TabIndex = 27
        Me.LabelX1.Text = "Ver los primeros"
        '
        'Rdb_Tipo_Doc_Uno
        '
        Me.Rdb_Tipo_Doc_Uno.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Tipo_Doc_Uno.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Tipo_Doc_Uno.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Tipo_Doc_Uno.Checked = True
        Me.Rdb_Tipo_Doc_Uno.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Tipo_Doc_Uno.CheckValue = "Y"
        Me.Rdb_Tipo_Doc_Uno.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Tipo_Doc_Uno.Location = New System.Drawing.Point(3, 37)
        Me.Rdb_Tipo_Doc_Uno.Name = "Rdb_Tipo_Doc_Uno"
        Me.Rdb_Tipo_Doc_Uno.Size = New System.Drawing.Size(157, 23)
        Me.Rdb_Tipo_Doc_Uno.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Tipo_Doc_Uno.TabIndex = 24
        Me.Rdb_Tipo_Doc_Uno.Text = "Uno en especifico"
        '
        'Cmb_Tipo_de_documentos
        '
        Me.Cmb_Tipo_de_documentos.DisplayMember = "Text"
        Me.Cmb_Tipo_de_documentos.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Tipo_de_documentos.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Tipo_de_documentos.FormattingEnabled = True
        Me.Cmb_Tipo_de_documentos.ItemHeight = 16
        Me.Cmb_Tipo_de_documentos.Location = New System.Drawing.Point(3, 66)
        Me.Cmb_Tipo_de_documentos.Name = "Cmb_Tipo_de_documentos"
        Me.Cmb_Tipo_de_documentos.Size = New System.Drawing.Size(222, 22)
        Me.Cmb_Tipo_de_documentos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Tipo_de_documentos.TabIndex = 23
        '
        'LblNroDocumento
        '
        Me.LblNroDocumento.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LblNroDocumento.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblNroDocumento.ForeColor = System.Drawing.Color.Black
        Me.LblNroDocumento.Location = New System.Drawing.Point(233, 37)
        Me.LblNroDocumento.Name = "LblNroDocumento"
        Me.LblNroDocumento.Size = New System.Drawing.Size(110, 23)
        Me.LblNroDocumento.TabIndex = 21
        Me.LblNroDocumento.Text = "N° Doc. Interno"
        '
        'Btn_Buscar_Documentos
        '
        Me.Btn_Buscar_Documentos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Buscar_Documentos.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Buscar_Documentos.Enabled = False
        Me.Btn_Buscar_Documentos.Image = CType(resources.GetObject("Btn_Buscar_Documentos.Image"), System.Drawing.Image)
        Me.Btn_Buscar_Documentos.ImageAlt = CType(resources.GetObject("Btn_Buscar_Documentos.ImageAlt"), System.Drawing.Image)
        Me.Btn_Buscar_Documentos.Location = New System.Drawing.Point(74, 8)
        Me.Btn_Buscar_Documentos.Name = "Btn_Buscar_Documentos"
        Me.Btn_Buscar_Documentos.Size = New System.Drawing.Size(31, 23)
        Me.Btn_Buscar_Documentos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Buscar_Documentos.TabIndex = 22
        Me.Btn_Buscar_Documentos.Tooltip = "Ver selección"
        '
        'Rdb_Tipo_Doc_Algunos
        '
        Me.Rdb_Tipo_Doc_Algunos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Tipo_Doc_Algunos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Tipo_Doc_Algunos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Tipo_Doc_Algunos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Tipo_Doc_Algunos.Location = New System.Drawing.Point(3, 8)
        Me.Rdb_Tipo_Doc_Algunos.Name = "Rdb_Tipo_Doc_Algunos"
        Me.Rdb_Tipo_Doc_Algunos.Size = New System.Drawing.Size(65, 23)
        Me.Rdb_Tipo_Doc_Algunos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Tipo_Doc_Algunos.TabIndex = 19
        Me.Rdb_Tipo_Doc_Algunos.Text = "Algunos"
        '
        'Txt_Numero_Interno
        '
        Me.Txt_Numero_Interno.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Numero_Interno.Border.Class = "TextBoxBorder"
        Me.Txt_Numero_Interno.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Numero_Interno.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Numero_Interno.FocusHighlightEnabled = True
        Me.Txt_Numero_Interno.ForeColor = System.Drawing.Color.Black
        Me.Txt_Numero_Interno.Location = New System.Drawing.Point(233, 66)
        Me.Txt_Numero_Interno.Name = "Txt_Numero_Interno"
        Me.Txt_Numero_Interno.PreventEnterBeep = True
        Me.Txt_Numero_Interno.Size = New System.Drawing.Size(91, 22)
        Me.Txt_Numero_Interno.TabIndex = 3
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Buscar})
        Me.Bar1.Location = New System.Drawing.Point(0, 362)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(697, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 34
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Buscar
        '
        Me.Btn_Buscar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Buscar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Buscar.Image = CType(resources.GetObject("Btn_Buscar.Image"), System.Drawing.Image)
        Me.Btn_Buscar.ImageAlt = CType(resources.GetObject("Btn_Buscar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Buscar.Name = "Btn_Buscar"
        Me.Btn_Buscar.Text = "Buscar documentos"
        Me.Btn_Buscar.Tooltip = "Seleccionar documento"
        '
        'Grupo_Fechas
        '
        Me.Grupo_Fechas.BackColor = System.Drawing.Color.White
        Me.Grupo_Fechas.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Fechas.Controls.Add(Me.TableLayoutPanel1)
        Me.Grupo_Fechas.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Fechas.Location = New System.Drawing.Point(6, 159)
        Me.Grupo_Fechas.Name = "Grupo_Fechas"
        Me.Grupo_Fechas.Size = New System.Drawing.Size(684, 98)
        '
        '
        '
        Me.Grupo_Fechas.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Fechas.Style.BackColorGradientAngle = 90
        Me.Grupo_Fechas.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Fechas.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Fechas.Style.BorderBottomWidth = 1
        Me.Grupo_Fechas.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Fechas.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Fechas.Style.BorderLeftWidth = 1
        Me.Grupo_Fechas.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Fechas.Style.BorderRightWidth = 1
        Me.Grupo_Fechas.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Fechas.Style.BorderTopWidth = 1
        Me.Grupo_Fechas.Style.CornerDiameter = 4
        Me.Grupo_Fechas.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Fechas.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Fechas.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Fechas.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Fechas.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Fechas.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Fechas.TabIndex = 77
        Me.Grupo_Fechas.Text = "Fechas"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Cmb_Fecha_Vencimineto, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_FV_hasta, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Dtp_Fecha_Vencimiento_Hasta, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Cmb_Fecha_Emision, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX4, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Dtp_Fecha_Vencimiento_Desde, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Dtp_Fecha_Emision_Desde, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX9, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_FE_hasta, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Dtp_Fecha_Emision_Hasta, 4, 0)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 13)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(568, 59)
        Me.TableLayoutPanel1.TabIndex = 6
        '
        'Cmb_Fecha_Vencimineto
        '
        Me.Cmb_Fecha_Vencimineto.DisplayMember = "Text"
        Me.Cmb_Fecha_Vencimineto.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Fecha_Vencimineto.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Fecha_Vencimineto.FormattingEnabled = True
        Me.Cmb_Fecha_Vencimineto.ItemHeight = 16
        Me.Cmb_Fecha_Vencimineto.Location = New System.Drawing.Point(173, 32)
        Me.Cmb_Fecha_Vencimineto.Name = "Cmb_Fecha_Vencimineto"
        Me.Cmb_Fecha_Vencimineto.Size = New System.Drawing.Size(164, 22)
        Me.Cmb_Fecha_Vencimineto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Fecha_Vencimineto.TabIndex = 34
        '
        'Lbl_FV_hasta
        '
        '
        '
        '
        Me.Lbl_FV_hasta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_FV_hasta.ForeColor = System.Drawing.Color.Black
        Me.Lbl_FV_hasta.Location = New System.Drawing.Point(441, 32)
        Me.Lbl_FV_hasta.Name = "Lbl_FV_hasta"
        Me.Lbl_FV_hasta.Size = New System.Drawing.Size(31, 22)
        Me.Lbl_FV_hasta.TabIndex = 10
        Me.Lbl_FV_hasta.Text = "Hasta"
        '
        'Dtp_Fecha_Vencimiento_Hasta
        '
        '
        '
        '
        Me.Dtp_Fecha_Vencimiento_Hasta.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Vencimiento_Hasta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Vencimiento_Hasta.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Vencimiento_Hasta.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Vencimiento_Hasta.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Vencimiento_Hasta.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Vencimiento_Hasta.Location = New System.Drawing.Point(478, 32)
        '
        '
        '
        Me.Dtp_Fecha_Vencimiento_Hasta.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Vencimiento_Hasta.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Vencimiento_Hasta.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Vencimiento_Hasta.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Vencimiento_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Vencimiento_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Vencimiento_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Vencimiento_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Vencimiento_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Vencimiento_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Vencimiento_Hasta.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Vencimiento_Hasta.MonthCalendar.DisplayMonth = New Date(2016, 7, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Vencimiento_Hasta.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Vencimiento_Hasta.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Vencimiento_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Vencimiento_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Vencimiento_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Vencimiento_Hasta.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Vencimiento_Hasta.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Vencimiento_Hasta.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Vencimiento_Hasta.Name = "Dtp_Fecha_Vencimiento_Hasta"
        Me.Dtp_Fecha_Vencimiento_Hasta.Size = New System.Drawing.Size(80, 22)
        Me.Dtp_Fecha_Vencimiento_Hasta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Vencimiento_Hasta.TabIndex = 8
        Me.Dtp_Fecha_Vencimiento_Hasta.Value = New Date(2016, 7, 8, 16, 42, 49, 0)
        '
        'Cmb_Fecha_Emision
        '
        Me.Cmb_Fecha_Emision.DisplayMember = "Text"
        Me.Cmb_Fecha_Emision.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Fecha_Emision.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Fecha_Emision.FormattingEnabled = True
        Me.Cmb_Fecha_Emision.ItemHeight = 16
        Me.Cmb_Fecha_Emision.Location = New System.Drawing.Point(173, 3)
        Me.Cmb_Fecha_Emision.Name = "Cmb_Fecha_Emision"
        Me.Cmb_Fecha_Emision.Size = New System.Drawing.Size(164, 22)
        Me.Cmb_Fecha_Emision.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Fecha_Emision.TabIndex = 33
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(3, 3)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(95, 19)
        Me.LabelX4.TabIndex = 4
        Me.LabelX4.Text = "Fecha de emisión"
        '
        'Dtp_Fecha_Vencimiento_Desde
        '
        '
        '
        '
        Me.Dtp_Fecha_Vencimiento_Desde.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Vencimiento_Desde.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Vencimiento_Desde.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Vencimiento_Desde.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Vencimiento_Desde.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Vencimiento_Desde.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Vencimiento_Desde.Location = New System.Drawing.Point(343, 32)
        '
        '
        '
        Me.Dtp_Fecha_Vencimiento_Desde.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Vencimiento_Desde.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Vencimiento_Desde.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Vencimiento_Desde.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Vencimiento_Desde.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Vencimiento_Desde.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Vencimiento_Desde.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Vencimiento_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Vencimiento_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Vencimiento_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Vencimiento_Desde.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Vencimiento_Desde.MonthCalendar.DisplayMonth = New Date(2016, 7, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Vencimiento_Desde.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Vencimiento_Desde.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Vencimiento_Desde.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Vencimiento_Desde.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Vencimiento_Desde.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Vencimiento_Desde.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Vencimiento_Desde.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Vencimiento_Desde.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Vencimiento_Desde.Name = "Dtp_Fecha_Vencimiento_Desde"
        Me.Dtp_Fecha_Vencimiento_Desde.Size = New System.Drawing.Size(80, 22)
        Me.Dtp_Fecha_Vencimiento_Desde.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Vencimiento_Desde.TabIndex = 7
        Me.Dtp_Fecha_Vencimiento_Desde.Value = New Date(2016, 7, 8, 16, 42, 41, 0)
        '
        'Dtp_Fecha_Emision_Desde
        '
        '
        '
        '
        Me.Dtp_Fecha_Emision_Desde.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Emision_Desde.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Emision_Desde.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Emision_Desde.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Emision_Desde.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Emision_Desde.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Emision_Desde.Location = New System.Drawing.Point(343, 3)
        '
        '
        '
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.DisplayMonth = New Date(2016, 7, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Emision_Desde.Name = "Dtp_Fecha_Emision_Desde"
        Me.Dtp_Fecha_Emision_Desde.Size = New System.Drawing.Size(79, 22)
        Me.Dtp_Fecha_Emision_Desde.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Emision_Desde.TabIndex = 7
        Me.Dtp_Fecha_Emision_Desde.Value = New Date(2016, 7, 8, 16, 32, 31, 0)
        '
        'LabelX9
        '
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.ForeColor = System.Drawing.Color.Black
        Me.LabelX9.Location = New System.Drawing.Point(3, 32)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(120, 14)
        Me.LabelX9.TabIndex = 4
        Me.LabelX9.Text = "Fecha de vencimiento"
        '
        'Lbl_FE_hasta
        '
        '
        '
        '
        Me.Lbl_FE_hasta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_FE_hasta.ForeColor = System.Drawing.Color.Black
        Me.Lbl_FE_hasta.Location = New System.Drawing.Point(441, 3)
        Me.Lbl_FE_hasta.Name = "Lbl_FE_hasta"
        Me.Lbl_FE_hasta.Size = New System.Drawing.Size(31, 23)
        Me.Lbl_FE_hasta.TabIndex = 9
        Me.Lbl_FE_hasta.Text = "Hasta"
        '
        'Dtp_Fecha_Emision_Hasta
        '
        '
        '
        '
        Me.Dtp_Fecha_Emision_Hasta.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Emision_Hasta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Emision_Hasta.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Emision_Hasta.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Emision_Hasta.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Emision_Hasta.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Emision_Hasta.Location = New System.Drawing.Point(478, 3)
        '
        '
        '
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.DisplayMonth = New Date(2016, 7, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Emision_Hasta.Name = "Dtp_Fecha_Emision_Hasta"
        Me.Dtp_Fecha_Emision_Hasta.Size = New System.Drawing.Size(81, 22)
        Me.Dtp_Fecha_Emision_Hasta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Emision_Hasta.TabIndex = 8
        Me.Dtp_Fecha_Emision_Hasta.Value = New Date(2016, 7, 8, 16, 33, 0, 0)
        '
        'Grupo_Entidad
        '
        Me.Grupo_Entidad.BackColor = System.Drawing.Color.White
        Me.Grupo_Entidad.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Entidad.Controls.Add(Me.Btn_Entidad_Una)
        Me.Grupo_Entidad.Controls.Add(Me.Rdb_Entidad_Todas)
        Me.Grupo_Entidad.Controls.Add(Me.Rdb_Entidad_Una)
        Me.Grupo_Entidad.Controls.Add(Me.Txt_Entidad)
        Me.Grupo_Entidad.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Entidad.Location = New System.Drawing.Point(6, 263)
        Me.Grupo_Entidad.Name = "Grupo_Entidad"
        Me.Grupo_Entidad.Size = New System.Drawing.Size(684, 86)
        '
        '
        '
        Me.Grupo_Entidad.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Entidad.Style.BackColorGradientAngle = 90
        Me.Grupo_Entidad.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Entidad.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Entidad.Style.BorderBottomWidth = 1
        Me.Grupo_Entidad.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Entidad.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Entidad.Style.BorderLeftWidth = 1
        Me.Grupo_Entidad.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Entidad.Style.BorderRightWidth = 1
        Me.Grupo_Entidad.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Entidad.Style.BorderTopWidth = 1
        Me.Grupo_Entidad.Style.CornerDiameter = 4
        Me.Grupo_Entidad.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Entidad.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Entidad.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Entidad.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Entidad.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Entidad.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Entidad.TabIndex = 78
        Me.Grupo_Entidad.Text = "Entidad del documento"
        '
        'Btn_Entidad_Una
        '
        Me.Btn_Entidad_Una.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Entidad_Una.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Entidad_Una.Image = CType(resources.GetObject("Btn_Entidad_Una.Image"), System.Drawing.Image)
        Me.Btn_Entidad_Una.ImageAlt = CType(resources.GetObject("Btn_Entidad_Una.ImageAlt"), System.Drawing.Image)
        Me.Btn_Entidad_Una.Location = New System.Drawing.Point(135, 32)
        Me.Btn_Entidad_Una.Name = "Btn_Entidad_Una"
        Me.Btn_Entidad_Una.Size = New System.Drawing.Size(31, 23)
        Me.Btn_Entidad_Una.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Entidad_Una.TabIndex = 28
        Me.Btn_Entidad_Una.Tooltip = "Ver selección"
        '
        'Rdb_Entidad_Todas
        '
        Me.Rdb_Entidad_Todas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Entidad_Todas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Entidad_Todas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Entidad_Todas.Checked = True
        Me.Rdb_Entidad_Todas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Entidad_Todas.CheckValue = "Y"
        Me.Rdb_Entidad_Todas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Entidad_Todas.Location = New System.Drawing.Point(3, 3)
        Me.Rdb_Entidad_Todas.Name = "Rdb_Entidad_Todas"
        Me.Rdb_Entidad_Todas.Size = New System.Drawing.Size(56, 23)
        Me.Rdb_Entidad_Todas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Entidad_Todas.TabIndex = 22
        Me.Rdb_Entidad_Todas.Text = "Todas"
        '
        'Rdb_Entidad_Una
        '
        Me.Rdb_Entidad_Una.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Entidad_Una.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Entidad_Una.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Entidad_Una.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Entidad_Una.Location = New System.Drawing.Point(3, 32)
        Me.Rdb_Entidad_Una.Name = "Rdb_Entidad_Una"
        Me.Rdb_Entidad_Una.Size = New System.Drawing.Size(106, 23)
        Me.Rdb_Entidad_Una.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Entidad_Una.TabIndex = 27
        Me.Rdb_Entidad_Una.Text = "Uno en especifico"
        '
        'Txt_Entidad
        '
        Me.Txt_Entidad.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Entidad.Border.Class = "TextBoxBorder"
        Me.Txt_Entidad.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Entidad.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Entidad.Enabled = False
        Me.Txt_Entidad.ForeColor = System.Drawing.Color.Black
        Me.Txt_Entidad.Location = New System.Drawing.Point(172, 33)
        Me.Txt_Entidad.Name = "Txt_Entidad"
        Me.Txt_Entidad.PreventEnterBeep = True
        Me.Txt_Entidad.ReadOnly = True
        Me.Txt_Entidad.Size = New System.Drawing.Size(499, 22)
        Me.Txt_Entidad.TabIndex = 9
        '
        'Frm_Tenerduria_Buscar_Documento_Pago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(697, 403)
        Me.Controls.Add(Me.Grupo_Entidad)
        Me.Controls.Add(Me.Grupo_Fechas)
        Me.Controls.Add(Me.Grupo_documento)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Tenerduria_Buscar_Documento_Pago"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        Me.Grupo_documento.ResumeLayout(False)
        CType(Me.Num_Top, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Num_Monto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo_Fechas.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.Dtp_Fecha_Vencimiento_Hasta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_Fecha_Vencimiento_Desde, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_Fecha_Emision_Desde, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_Fecha_Emision_Hasta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo_Entidad.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents Grupo_documento As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Public WithEvents Rdb_Tipo_Doc_Uno As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Cmb_Tipo_de_documentos As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LblNroDocumento As DevComponents.DotNetBar.LabelX
    Public WithEvents Btn_Buscar_Documentos As DevComponents.DotNetBar.ButtonX
    Public WithEvents Rdb_Tipo_Doc_Algunos As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Txt_Numero_Interno As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Buscar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grupo_Fechas As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Dtp_Fecha_Emision_Hasta As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Lbl_FE_hasta As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dtp_Fecha_Emision_Desde As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dtp_Fecha_Vencimiento_Hasta As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Dtp_Fecha_Vencimiento_Desde As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Public WithEvents Cmb_Estado As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Nro_Cheque As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Grupo_Entidad As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Btn_Entidad_Una As DevComponents.DotNetBar.ButtonX
    Public WithEvents Rdb_Entidad_Todas As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Rdb_Entidad_Una As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Txt_Entidad As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Num_Monto As System.Windows.Forms.NumericUpDown
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Num_Top As System.Windows.Forms.NumericUpDown
    Public WithEvents Cmb_Fecha_Vencimineto As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Lbl_FV_hasta As DevComponents.DotNetBar.LabelX
    Public WithEvents Cmb_Fecha_Emision As DevComponents.DotNetBar.Controls.ComboBoxEx
End Class
