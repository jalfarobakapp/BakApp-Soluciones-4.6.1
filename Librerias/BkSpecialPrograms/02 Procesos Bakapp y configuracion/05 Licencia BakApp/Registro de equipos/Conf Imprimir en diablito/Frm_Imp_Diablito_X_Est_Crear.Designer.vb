<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Imp_Diablito_X_Est_Crear
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Imp_Diablito_X_Est_Crear))
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Line1 = New DevComponents.DotNetBar.Controls.Line()
        Me.Btn_Buscar_Bodega = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_Bodega_Picking = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Lbl_Bodega_Picking = New DevComponents.DotNetBar.LabelX()
        Me.Sw_Imp_Todas_Modalidades = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Layaut_Voucher = New System.Windows.Forms.TableLayoutPanel()
        Me.Rdb_Imprimir_Voucher_TJV_No_Imprimir = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Imprimir_Voucher_TJV_Original_Transbak = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Imprimir_Voucher_TJV = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Btn_Buscar_Impresora = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_Impresora = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.Sw_Activo = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.Input_Nro_Copias = New DevComponents.Editors.IntegerInput()
        Me.Btn_Buscar_Formato = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_NombreFormato = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.Btn_NombreEquipo_Imprime = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_NombreEquipo_Imprime = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Cmb_Tipo = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Txt_SubTido = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Buscar_Tido = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_Tido = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Buscar_Modalidad = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_Modalidad = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Eliminar = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1.SuspendLayout()
        Me.Layaut_Voucher.SuspendLayout()
        CType(Me.Input_Nro_Copias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Line1)
        Me.GroupPanel1.Controls.Add(Me.Btn_Buscar_Bodega)
        Me.GroupPanel1.Controls.Add(Me.Txt_Bodega_Picking)
        Me.GroupPanel1.Controls.Add(Me.Lbl_Bodega_Picking)
        Me.GroupPanel1.Controls.Add(Me.Sw_Imp_Todas_Modalidades)
        Me.GroupPanel1.Controls.Add(Me.Layaut_Voucher)
        Me.GroupPanel1.Controls.Add(Me.Btn_Buscar_Impresora)
        Me.GroupPanel1.Controls.Add(Me.Txt_Impresora)
        Me.GroupPanel1.Controls.Add(Me.LabelX9)
        Me.GroupPanel1.Controls.Add(Me.LabelX8)
        Me.GroupPanel1.Controls.Add(Me.Sw_Activo)
        Me.GroupPanel1.Controls.Add(Me.LabelX7)
        Me.GroupPanel1.Controls.Add(Me.Input_Nro_Copias)
        Me.GroupPanel1.Controls.Add(Me.Btn_Buscar_Formato)
        Me.GroupPanel1.Controls.Add(Me.Txt_NombreFormato)
        Me.GroupPanel1.Controls.Add(Me.LabelX6)
        Me.GroupPanel1.Controls.Add(Me.Btn_NombreEquipo_Imprime)
        Me.GroupPanel1.Controls.Add(Me.Txt_NombreEquipo_Imprime)
        Me.GroupPanel1.Controls.Add(Me.LabelX5)
        Me.GroupPanel1.Controls.Add(Me.LabelX4)
        Me.GroupPanel1.Controls.Add(Me.Cmb_Tipo)
        Me.GroupPanel1.Controls.Add(Me.Txt_SubTido)
        Me.GroupPanel1.Controls.Add(Me.LabelX3)
        Me.GroupPanel1.Controls.Add(Me.Btn_Buscar_Tido)
        Me.GroupPanel1.Controls.Add(Me.Txt_Tido)
        Me.GroupPanel1.Controls.Add(Me.LabelX2)
        Me.GroupPanel1.Controls.Add(Me.Btn_Buscar_Modalidad)
        Me.GroupPanel1.Controls.Add(Me.Txt_Modalidad)
        Me.GroupPanel1.Controls.Add(Me.LabelX1)
        Me.GroupPanel1.Controls.Add(Me.LabelX10)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(404, 444)
        '
        '
        '
        Me.GroupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel1.Style.BackColorGradientAngle = 90
        Me.GroupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderBottomWidth = 1
        Me.GroupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderLeftWidth = 1
        Me.GroupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderRightWidth = 1
        Me.GroupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderTopWidth = 1
        Me.GroupPanel1.Style.CornerDiameter = 4
        Me.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel1.TabIndex = 0
        Me.GroupPanel1.Text = "Configuración"
        '
        'Line1
        '
        Me.Line1.BackColor = System.Drawing.Color.Transparent
        Me.Line1.ForeColor = System.Drawing.Color.Black
        Me.Line1.Location = New System.Drawing.Point(14, 242)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(371, 23)
        Me.Line1.TabIndex = 33
        Me.Line1.Text = "Line1"
        '
        'Btn_Buscar_Bodega
        '
        Me.Btn_Buscar_Bodega.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Buscar_Bodega.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Buscar_Bodega.Image = CType(resources.GetObject("Btn_Buscar_Bodega.Image"), System.Drawing.Image)
        Me.Btn_Buscar_Bodega.Location = New System.Drawing.Point(350, 156)
        Me.Btn_Buscar_Bodega.Name = "Btn_Buscar_Bodega"
        Me.Btn_Buscar_Bodega.Size = New System.Drawing.Size(35, 23)
        Me.Btn_Buscar_Bodega.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Buscar_Bodega.TabIndex = 30
        Me.Btn_Buscar_Bodega.Tooltip = "Buscar equipo en el cual se imprime"
        '
        'Txt_Bodega_Picking
        '
        Me.Txt_Bodega_Picking.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Bodega_Picking.Border.Class = "TextBoxBorder"
        Me.Txt_Bodega_Picking.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Bodega_Picking.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Bodega_Picking.ForeColor = System.Drawing.Color.Black
        Me.Txt_Bodega_Picking.Location = New System.Drawing.Point(125, 156)
        Me.Txt_Bodega_Picking.Name = "Txt_Bodega_Picking"
        Me.Txt_Bodega_Picking.PreventEnterBeep = True
        Me.Txt_Bodega_Picking.ReadOnly = True
        Me.Txt_Bodega_Picking.Size = New System.Drawing.Size(219, 22)
        Me.Txt_Bodega_Picking.TabIndex = 32
        Me.Txt_Bodega_Picking.TabStop = False
        '
        'Lbl_Bodega_Picking
        '
        Me.Lbl_Bodega_Picking.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Bodega_Picking.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Bodega_Picking.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Bodega_Picking.Location = New System.Drawing.Point(14, 156)
        Me.Lbl_Bodega_Picking.Name = "Lbl_Bodega_Picking"
        Me.Lbl_Bodega_Picking.Size = New System.Drawing.Size(105, 23)
        Me.Lbl_Bodega_Picking.TabIndex = 31
        Me.Lbl_Bodega_Picking.Text = "Bodega picking"
        '
        'Sw_Imp_Todas_Modalidades
        '
        Me.Sw_Imp_Todas_Modalidades.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Sw_Imp_Todas_Modalidades.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Sw_Imp_Todas_Modalidades.ForeColor = System.Drawing.Color.Black
        Me.Sw_Imp_Todas_Modalidades.Location = New System.Drawing.Point(125, 13)
        Me.Sw_Imp_Todas_Modalidades.Name = "Sw_Imp_Todas_Modalidades"
        Me.Sw_Imp_Todas_Modalidades.OffText = "Solo una"
        Me.Sw_Imp_Todas_Modalidades.OnText = "Todas"
        Me.Sw_Imp_Todas_Modalidades.Size = New System.Drawing.Size(147, 22)
        Me.Sw_Imp_Todas_Modalidades.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Sw_Imp_Todas_Modalidades.TabIndex = 29
        Me.Sw_Imp_Todas_Modalidades.Value = True
        Me.Sw_Imp_Todas_Modalidades.ValueObject = "Y"
        '
        'Layaut_Voucher
        '
        Me.Layaut_Voucher.BackColor = System.Drawing.Color.Transparent
        Me.Layaut_Voucher.ColumnCount = 1
        Me.Layaut_Voucher.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Layaut_Voucher.Controls.Add(Me.Rdb_Imprimir_Voucher_TJV_No_Imprimir, 0, 0)
        Me.Layaut_Voucher.Controls.Add(Me.Rdb_Imprimir_Voucher_TJV_Original_Transbak, 0, 2)
        Me.Layaut_Voucher.Controls.Add(Me.Rdb_Imprimir_Voucher_TJV, 0, 1)
        Me.Layaut_Voucher.ForeColor = System.Drawing.Color.Black
        Me.Layaut_Voucher.Location = New System.Drawing.Point(14, 279)
        Me.Layaut_Voucher.Name = "Layaut_Voucher"
        Me.Layaut_Voucher.RowCount = 3
        Me.Layaut_Voucher.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Layaut_Voucher.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Layaut_Voucher.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.Layaut_Voucher.Size = New System.Drawing.Size(371, 67)
        Me.Layaut_Voucher.TabIndex = 27
        '
        'Rdb_Imprimir_Voucher_TJV_No_Imprimir
        '
        Me.Rdb_Imprimir_Voucher_TJV_No_Imprimir.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Imprimir_Voucher_TJV_No_Imprimir.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Imprimir_Voucher_TJV_No_Imprimir.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Imprimir_Voucher_TJV_No_Imprimir.Checked = True
        Me.Rdb_Imprimir_Voucher_TJV_No_Imprimir.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Imprimir_Voucher_TJV_No_Imprimir.CheckValue = "Y"
        Me.Rdb_Imprimir_Voucher_TJV_No_Imprimir.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Imprimir_Voucher_TJV_No_Imprimir.Location = New System.Drawing.Point(3, 3)
        Me.Rdb_Imprimir_Voucher_TJV_No_Imprimir.Name = "Rdb_Imprimir_Voucher_TJV_No_Imprimir"
        Me.Rdb_Imprimir_Voucher_TJV_No_Imprimir.Size = New System.Drawing.Size(146, 17)
        Me.Rdb_Imprimir_Voucher_TJV_No_Imprimir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Imprimir_Voucher_TJV_No_Imprimir.TabIndex = 24
        Me.Rdb_Imprimir_Voucher_TJV_No_Imprimir.Text = "No Imprimir Voucher TJV"
        '
        'Rdb_Imprimir_Voucher_TJV_Original_Transbak
        '
        Me.Rdb_Imprimir_Voucher_TJV_Original_Transbak.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Imprimir_Voucher_TJV_Original_Transbak.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Imprimir_Voucher_TJV_Original_Transbak.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Imprimir_Voucher_TJV_Original_Transbak.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Imprimir_Voucher_TJV_Original_Transbak.Location = New System.Drawing.Point(3, 49)
        Me.Rdb_Imprimir_Voucher_TJV_Original_Transbak.Name = "Rdb_Imprimir_Voucher_TJV_Original_Transbak"
        Me.Rdb_Imprimir_Voucher_TJV_Original_Transbak.Size = New System.Drawing.Size(301, 15)
        Me.Rdb_Imprimir_Voucher_TJV_Original_Transbak.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Imprimir_Voucher_TJV_Original_Transbak.TabIndex = 26
        Me.Rdb_Imprimir_Voucher_TJV_Original_Transbak.Text = "Imprimir Voucher TJV (Original Transbank)"
        '
        'Rdb_Imprimir_Voucher_TJV
        '
        Me.Rdb_Imprimir_Voucher_TJV.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Imprimir_Voucher_TJV.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Imprimir_Voucher_TJV.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Imprimir_Voucher_TJV.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Imprimir_Voucher_TJV.Location = New System.Drawing.Point(3, 26)
        Me.Rdb_Imprimir_Voucher_TJV.Name = "Rdb_Imprimir_Voucher_TJV"
        Me.Rdb_Imprimir_Voucher_TJV.Size = New System.Drawing.Size(146, 17)
        Me.Rdb_Imprimir_Voucher_TJV.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Imprimir_Voucher_TJV.TabIndex = 25
        Me.Rdb_Imprimir_Voucher_TJV.Text = "Imprimir Voucher TJV"
        '
        'Btn_Buscar_Impresora
        '
        Me.Btn_Buscar_Impresora.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Buscar_Impresora.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Buscar_Impresora.Image = CType(resources.GetObject("Btn_Buscar_Impresora.Image"), System.Drawing.Image)
        Me.Btn_Buscar_Impresora.Location = New System.Drawing.Point(350, 213)
        Me.Btn_Buscar_Impresora.Name = "Btn_Buscar_Impresora"
        Me.Btn_Buscar_Impresora.Size = New System.Drawing.Size(35, 23)
        Me.Btn_Buscar_Impresora.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Buscar_Impresora.TabIndex = 21
        Me.Btn_Buscar_Impresora.Tooltip = "Buscar equipo en el cual se imprime"
        '
        'Txt_Impresora
        '
        Me.Txt_Impresora.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Impresora.Border.Class = "TextBoxBorder"
        Me.Txt_Impresora.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Impresora.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Impresora.ForeColor = System.Drawing.Color.Black
        Me.Txt_Impresora.Location = New System.Drawing.Point(125, 213)
        Me.Txt_Impresora.Name = "Txt_Impresora"
        Me.Txt_Impresora.PreventEnterBeep = True
        Me.Txt_Impresora.ReadOnly = True
        Me.Txt_Impresora.Size = New System.Drawing.Size(219, 22)
        Me.Txt_Impresora.TabIndex = 23
        Me.Txt_Impresora.TabStop = False
        '
        'LabelX9
        '
        Me.LabelX9.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.ForeColor = System.Drawing.Color.Black
        Me.LabelX9.Location = New System.Drawing.Point(14, 213)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(105, 23)
        Me.LabelX9.TabIndex = 22
        Me.LabelX9.Text = "Impresora"
        '
        'LabelX8
        '
        Me.LabelX8.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.ForeColor = System.Drawing.Color.Black
        Me.LabelX8.Location = New System.Drawing.Point(14, 379)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(105, 23)
        Me.LabelX8.TabIndex = 20
        Me.LabelX8.Text = "Activo"
        '
        'Sw_Activo
        '
        Me.Sw_Activo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Sw_Activo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Sw_Activo.ForeColor = System.Drawing.Color.Black
        Me.Sw_Activo.Location = New System.Drawing.Point(125, 380)
        Me.Sw_Activo.Name = "Sw_Activo"
        Me.Sw_Activo.OffText = "NO"
        Me.Sw_Activo.OnText = "SI"
        Me.Sw_Activo.Size = New System.Drawing.Size(66, 22)
        Me.Sw_Activo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Sw_Activo.TabIndex = 9
        Me.Sw_Activo.Value = True
        Me.Sw_Activo.ValueObject = "Y"
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.ForeColor = System.Drawing.Color.Black
        Me.LabelX7.Location = New System.Drawing.Point(14, 353)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(105, 23)
        Me.LabelX7.TabIndex = 18
        Me.LabelX7.Text = "Nro. de copias"
        '
        'Input_Nro_Copias
        '
        Me.Input_Nro_Copias.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_Nro_Copias.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_Nro_Copias.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_Nro_Copias.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.Input_Nro_Copias.ForeColor = System.Drawing.Color.Black
        Me.Input_Nro_Copias.Location = New System.Drawing.Point(125, 352)
        Me.Input_Nro_Copias.MaxValue = 5
        Me.Input_Nro_Copias.MinValue = 1
        Me.Input_Nro_Copias.Name = "Input_Nro_Copias"
        Me.Input_Nro_Copias.ShowUpDown = True
        Me.Input_Nro_Copias.Size = New System.Drawing.Size(66, 22)
        Me.Input_Nro_Copias.TabIndex = 8
        Me.Input_Nro_Copias.Value = 1
        '
        'Btn_Buscar_Formato
        '
        Me.Btn_Buscar_Formato.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Buscar_Formato.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Buscar_Formato.Image = CType(resources.GetObject("Btn_Buscar_Formato.Image"), System.Drawing.Image)
        Me.Btn_Buscar_Formato.Location = New System.Drawing.Point(350, 100)
        Me.Btn_Buscar_Formato.Name = "Btn_Buscar_Formato"
        Me.Btn_Buscar_Formato.Size = New System.Drawing.Size(35, 23)
        Me.Btn_Buscar_Formato.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Buscar_Formato.TabIndex = 5
        Me.Btn_Buscar_Formato.Tooltip = "Buscar Formato"
        '
        'Txt_NombreFormato
        '
        Me.Txt_NombreFormato.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_NombreFormato.Border.Class = "TextBoxBorder"
        Me.Txt_NombreFormato.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_NombreFormato.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_NombreFormato.ForeColor = System.Drawing.Color.Black
        Me.Txt_NombreFormato.Location = New System.Drawing.Point(125, 100)
        Me.Txt_NombreFormato.Name = "Txt_NombreFormato"
        Me.Txt_NombreFormato.PreventEnterBeep = True
        Me.Txt_NombreFormato.ReadOnly = True
        Me.Txt_NombreFormato.Size = New System.Drawing.Size(219, 22)
        Me.Txt_NombreFormato.TabIndex = 15
        Me.Txt_NombreFormato.TabStop = False
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(14, 100)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(105, 23)
        Me.LabelX6.TabIndex = 14
        Me.LabelX6.Text = "Nombre formato"
        '
        'Btn_NombreEquipo_Imprime
        '
        Me.Btn_NombreEquipo_Imprime.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_NombreEquipo_Imprime.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_NombreEquipo_Imprime.Image = CType(resources.GetObject("Btn_NombreEquipo_Imprime.Image"), System.Drawing.Image)
        Me.Btn_NombreEquipo_Imprime.Location = New System.Drawing.Point(350, 184)
        Me.Btn_NombreEquipo_Imprime.Name = "Btn_NombreEquipo_Imprime"
        Me.Btn_NombreEquipo_Imprime.Size = New System.Drawing.Size(35, 23)
        Me.Btn_NombreEquipo_Imprime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_NombreEquipo_Imprime.TabIndex = 7
        Me.Btn_NombreEquipo_Imprime.Tooltip = "Buscar equipo en el cual se imprime"
        '
        'Txt_NombreEquipo_Imprime
        '
        Me.Txt_NombreEquipo_Imprime.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_NombreEquipo_Imprime.Border.Class = "TextBoxBorder"
        Me.Txt_NombreEquipo_Imprime.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_NombreEquipo_Imprime.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_NombreEquipo_Imprime.ForeColor = System.Drawing.Color.Black
        Me.Txt_NombreEquipo_Imprime.Location = New System.Drawing.Point(125, 184)
        Me.Txt_NombreEquipo_Imprime.Name = "Txt_NombreEquipo_Imprime"
        Me.Txt_NombreEquipo_Imprime.PreventEnterBeep = True
        Me.Txt_NombreEquipo_Imprime.ReadOnly = True
        Me.Txt_NombreEquipo_Imprime.Size = New System.Drawing.Size(219, 22)
        Me.Txt_NombreEquipo_Imprime.TabIndex = 12
        Me.Txt_NombreEquipo_Imprime.TabStop = False
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(14, 184)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(105, 23)
        Me.LabelX5.TabIndex = 11
        Me.LabelX5.Text = "Equipo que imprime"
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(14, 128)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(105, 23)
        Me.LabelX4.TabIndex = 10
        Me.LabelX4.Text = "Tipo impresión"
        '
        'Cmb_Tipo
        '
        Me.Cmb_Tipo.DisplayMember = "Text"
        Me.Cmb_Tipo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Tipo.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Tipo.FormattingEnabled = True
        Me.Cmb_Tipo.ItemHeight = 16
        Me.Cmb_Tipo.Location = New System.Drawing.Point(125, 128)
        Me.Cmb_Tipo.Name = "Cmb_Tipo"
        Me.Cmb_Tipo.Size = New System.Drawing.Size(167, 22)
        Me.Cmb_Tipo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Tipo.TabIndex = 6
        '
        'Txt_SubTido
        '
        Me.Txt_SubTido.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_SubTido.Border.Class = "TextBoxBorder"
        Me.Txt_SubTido.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_SubTido.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_SubTido.ForeColor = System.Drawing.Color.Black
        Me.Txt_SubTido.Location = New System.Drawing.Point(125, 71)
        Me.Txt_SubTido.MaxLength = 3
        Me.Txt_SubTido.Name = "Txt_SubTido"
        Me.Txt_SubTido.PreventEnterBeep = True
        Me.Txt_SubTido.Size = New System.Drawing.Size(66, 22)
        Me.Txt_SubTido.TabIndex = 4
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(14, 71)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(105, 23)
        Me.LabelX3.TabIndex = 6
        Me.LabelX3.Text = "Sub-Tido"
        '
        'Btn_Buscar_Tido
        '
        Me.Btn_Buscar_Tido.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Buscar_Tido.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Buscar_Tido.Image = CType(resources.GetObject("Btn_Buscar_Tido.Image"), System.Drawing.Image)
        Me.Btn_Buscar_Tido.Location = New System.Drawing.Point(350, 41)
        Me.Btn_Buscar_Tido.Name = "Btn_Buscar_Tido"
        Me.Btn_Buscar_Tido.Size = New System.Drawing.Size(35, 23)
        Me.Btn_Buscar_Tido.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Buscar_Tido.TabIndex = 3
        Me.Btn_Buscar_Tido.Tooltip = "Buscar Tido"
        '
        'Txt_Tido
        '
        Me.Txt_Tido.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Tido.Border.Class = "TextBoxBorder"
        Me.Txt_Tido.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Tido.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Tido.ForeColor = System.Drawing.Color.Black
        Me.Txt_Tido.Location = New System.Drawing.Point(125, 41)
        Me.Txt_Tido.Name = "Txt_Tido"
        Me.Txt_Tido.PreventEnterBeep = True
        Me.Txt_Tido.ReadOnly = True
        Me.Txt_Tido.Size = New System.Drawing.Size(219, 22)
        Me.Txt_Tido.TabIndex = 2
        Me.Txt_Tido.TabStop = False
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(14, 42)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(105, 23)
        Me.LabelX2.TabIndex = 3
        Me.LabelX2.Text = "Documento (Tido)"
        '
        'Btn_Buscar_Modalidad
        '
        Me.Btn_Buscar_Modalidad.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Buscar_Modalidad.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Buscar_Modalidad.Image = CType(resources.GetObject("Btn_Buscar_Modalidad.Image"), System.Drawing.Image)
        Me.Btn_Buscar_Modalidad.Location = New System.Drawing.Point(350, 13)
        Me.Btn_Buscar_Modalidad.Name = "Btn_Buscar_Modalidad"
        Me.Btn_Buscar_Modalidad.Size = New System.Drawing.Size(35, 22)
        Me.Btn_Buscar_Modalidad.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Buscar_Modalidad.TabIndex = 1
        Me.Btn_Buscar_Modalidad.Tooltip = "Buscar Modalidad"
        '
        'Txt_Modalidad
        '
        Me.Txt_Modalidad.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Modalidad.Border.Class = "TextBoxBorder"
        Me.Txt_Modalidad.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Modalidad.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Modalidad.ForeColor = System.Drawing.Color.Black
        Me.Txt_Modalidad.Location = New System.Drawing.Point(278, 13)
        Me.Txt_Modalidad.Name = "Txt_Modalidad"
        Me.Txt_Modalidad.PreventEnterBeep = True
        Me.Txt_Modalidad.ReadOnly = True
        Me.Txt_Modalidad.Size = New System.Drawing.Size(66, 22)
        Me.Txt_Modalidad.TabIndex = 0
        Me.Txt_Modalidad.TabStop = False
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(14, 13)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(105, 23)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "Modalidad"
        '
        'LabelX10
        '
        Me.LabelX10.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX10.ForeColor = System.Drawing.Color.Black
        Me.LabelX10.Location = New System.Drawing.Point(14, 257)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(278, 23)
        Me.LabelX10.TabIndex = 28
        Me.LabelX10.Text = "Impresión de Voucher TJV solo para BLV y FCV"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar, Me.Btn_Eliminar})
        Me.Bar1.Location = New System.Drawing.Point(0, 462)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(431, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 15
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Tooltip = "Grabar"
        '
        'Btn_Eliminar
        '
        Me.Btn_Eliminar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Eliminar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Eliminar.Image = CType(resources.GetObject("Btn_Eliminar.Image"), System.Drawing.Image)
        Me.Btn_Eliminar.Name = "Btn_Eliminar"
        Me.Btn_Eliminar.Tooltip = "Eliminar"
        Me.Btn_Eliminar.Visible = False
        '
        'Frm_Imp_Diablito_X_Est_Crear
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(431, 503)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.GroupPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Imp_Diablito_X_Est_Crear"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EQUIPO: NOMBRE DE EQUIPO, EMPRESA 01"
        Me.GroupPanel1.ResumeLayout(False)
        Me.Layaut_Voucher.ResumeLayout(False)
        CType(Me.Input_Nro_Copias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Eliminar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Sw_Activo As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Input_Nro_Copias As DevComponents.Editors.IntegerInput
    Friend WithEvents Btn_Buscar_Formato As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Txt_NombreFormato As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_NombreEquipo_Imprime As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Txt_NombreEquipo_Imprime As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Cmb_Tipo As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Txt_SubTido As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Buscar_Tido As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Txt_Tido As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Buscar_Modalidad As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Txt_Modalidad As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Buscar_Impresora As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Txt_Impresora As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Layaut_Voucher As TableLayoutPanel
    Friend WithEvents Rdb_Imprimir_Voucher_TJV_No_Imprimir As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Imprimir_Voucher_TJV_Original_Transbak As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Imprimir_Voucher_TJV As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Sw_Imp_Todas_Modalidades As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents Line1 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents Btn_Buscar_Bodega As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Txt_Bodega_Picking As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Lbl_Bodega_Picking As DevComponents.DotNetBar.LabelX
End Class
