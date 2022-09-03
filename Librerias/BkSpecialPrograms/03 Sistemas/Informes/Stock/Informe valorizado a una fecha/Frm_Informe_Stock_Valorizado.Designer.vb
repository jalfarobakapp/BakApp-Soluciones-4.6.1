<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Informe_Stock_Valorizado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Informe_Stock_Valorizado))
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Ejecutar_Informe = New DevComponents.DotNetBar.ButtonItem()
        Me.Dtp_Fecha_Anterior = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Chk_Excluye_SSN = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Excluye_FLN = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_No_Bloqueados = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Rdb_Stock_Pedido = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Stock_Compras_No_Recibidas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Stock_Comprometido = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Stock_Devengado = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Stock_Fisico = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Rdb_Saldo_Distinto_de_cero = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Saldo_Con_saldo_Positivo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Saldo_Con_y_sin_saldo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.GroupPanel4 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.CheckBoxX5 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.CheckBoxX11 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.CheckBoxX1 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtros_Bodega = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Clasificacion_Productos = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Dtp_Fecha_Actual = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Rdb_Valorizado_Fecha_Anterior = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Valorizado_Fecha_Actual = New DevComponents.DotNetBar.Controls.CheckBoxX()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_Fecha_Anterior, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.GroupPanel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupPanel4.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel3.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.Dtp_Fecha_Actual, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Ejecutar_Informe})
        Me.Bar1.Location = New System.Drawing.Point(0, 492)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(363, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 92
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Ejecutar_Informe
        '
        Me.Btn_Ejecutar_Informe.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Ejecutar_Informe.ForeColor = System.Drawing.Color.Black
        Me.Btn_Ejecutar_Informe.Image = CType(resources.GetObject("Btn_Ejecutar_Informe.Image"), System.Drawing.Image)
        Me.Btn_Ejecutar_Informe.Name = "Btn_Ejecutar_Informe"
        Me.Btn_Ejecutar_Informe.Text = "Procesar informe"
        '
        'Dtp_Fecha_Anterior
        '
        Me.Dtp_Fecha_Anterior.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_Fecha_Anterior.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Anterior.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Anterior.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Anterior.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Anterior.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Anterior.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Anterior.Location = New System.Drawing.Point(209, 32)
        '
        '
        '
        Me.Dtp_Fecha_Anterior.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Anterior.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Anterior.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Anterior.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Anterior.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Anterior.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Anterior.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Anterior.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Anterior.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Anterior.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Anterior.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Anterior.MonthCalendar.DisplayMonth = New Date(2017, 5, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Anterior.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Anterior.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Anterior.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Anterior.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Anterior.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Anterior.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Anterior.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Anterior.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Anterior.Name = "Dtp_Fecha_Anterior"
        Me.Dtp_Fecha_Anterior.Size = New System.Drawing.Size(93, 22)
        Me.Dtp_Fecha_Anterior.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Anterior.TabIndex = 93
        Me.Dtp_Fecha_Anterior.Value = New Date(2017, 5, 9, 17, 44, 34, 0)
        '
        'Chk_Excluye_SSN
        '
        Me.Chk_Excluye_SSN.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Excluye_SSN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Excluye_SSN.Checked = True
        Me.Chk_Excluye_SSN.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_Excluye_SSN.CheckValue = "Y"
        Me.Chk_Excluye_SSN.ForeColor = System.Drawing.Color.Black
        Me.Chk_Excluye_SSN.Location = New System.Drawing.Point(3, 3)
        Me.Chk_Excluye_SSN.Name = "Chk_Excluye_SSN"
        Me.Chk_Excluye_SSN.Size = New System.Drawing.Size(222, 16)
        Me.Chk_Excluye_SSN.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Excluye_SSN.TabIndex = 94
        Me.Chk_Excluye_SSN.Text = "Excluir productos tipo servicios (SSN)"
        '
        'Chk_Excluye_FLN
        '
        Me.Chk_Excluye_FLN.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Excluye_FLN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Excluye_FLN.Checked = True
        Me.Chk_Excluye_FLN.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_Excluye_FLN.CheckValue = "Y"
        Me.Chk_Excluye_FLN.ForeColor = System.Drawing.Color.Black
        Me.Chk_Excluye_FLN.Location = New System.Drawing.Point(3, 26)
        Me.Chk_Excluye_FLN.Name = "Chk_Excluye_FLN"
        Me.Chk_Excluye_FLN.Size = New System.Drawing.Size(222, 16)
        Me.Chk_Excluye_FLN.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Excluye_FLN.TabIndex = 95
        Me.Chk_Excluye_FLN.Text = "Excluir productos tipo libre (FLN)"
        '
        'Chk_No_Bloqueados
        '
        Me.Chk_No_Bloqueados.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_No_Bloqueados.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_No_Bloqueados.ForeColor = System.Drawing.Color.Black
        Me.Chk_No_Bloqueados.Location = New System.Drawing.Point(3, 49)
        Me.Chk_No_Bloqueados.Name = "Chk_No_Bloqueados"
        Me.Chk_No_Bloqueados.Size = New System.Drawing.Size(222, 16)
        Me.Chk_No_Bloqueados.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_No_Bloqueados.TabIndex = 96
        Me.Chk_No_Bloqueados.Text = "No incluir productos bloqueados"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.TableLayoutPanel3)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Enabled = False
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 143)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(154, 142)
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
        Me.GroupPanel1.TabIndex = 98
        Me.GroupPanel1.Text = "Stock a valorizar"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.Rdb_Stock_Pedido, 0, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.Rdb_Stock_Compras_No_Recibidas, 0, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.Rdb_Stock_Comprometido, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.Rdb_Stock_Devengado, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Rdb_Stock_Fisico, 0, 0)
        Me.TableLayoutPanel3.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 13)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 5
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(138, 100)
        Me.TableLayoutPanel3.TabIndex = 5
        '
        'Rdb_Stock_Pedido
        '
        Me.Rdb_Stock_Pedido.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Stock_Pedido.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Stock_Pedido.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Stock_Pedido.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Stock_Pedido.Location = New System.Drawing.Point(3, 83)
        Me.Rdb_Stock_Pedido.Name = "Rdb_Stock_Pedido"
        Me.Rdb_Stock_Pedido.Size = New System.Drawing.Size(94, 14)
        Me.Rdb_Stock_Pedido.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Stock_Pedido.TabIndex = 6
        Me.Rdb_Stock_Pedido.Text = "Pedido"
        '
        'Rdb_Stock_Compras_No_Recibidas
        '
        Me.Rdb_Stock_Compras_No_Recibidas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Stock_Compras_No_Recibidas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Stock_Compras_No_Recibidas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Stock_Compras_No_Recibidas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Stock_Compras_No_Recibidas.Location = New System.Drawing.Point(3, 63)
        Me.Rdb_Stock_Compras_No_Recibidas.Name = "Rdb_Stock_Compras_No_Recibidas"
        Me.Rdb_Stock_Compras_No_Recibidas.Size = New System.Drawing.Size(132, 14)
        Me.Rdb_Stock_Compras_No_Recibidas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Stock_Compras_No_Recibidas.TabIndex = 6
        Me.Rdb_Stock_Compras_No_Recibidas.Text = "Compras no recibidas"
        '
        'Rdb_Stock_Comprometido
        '
        Me.Rdb_Stock_Comprometido.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Stock_Comprometido.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Stock_Comprometido.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Stock_Comprometido.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Stock_Comprometido.Location = New System.Drawing.Point(3, 43)
        Me.Rdb_Stock_Comprometido.Name = "Rdb_Stock_Comprometido"
        Me.Rdb_Stock_Comprometido.Size = New System.Drawing.Size(94, 14)
        Me.Rdb_Stock_Comprometido.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Stock_Comprometido.TabIndex = 6
        Me.Rdb_Stock_Comprometido.Text = "Comprometido"
        '
        'Rdb_Stock_Devengado
        '
        Me.Rdb_Stock_Devengado.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Stock_Devengado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Stock_Devengado.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Stock_Devengado.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Stock_Devengado.Location = New System.Drawing.Point(3, 23)
        Me.Rdb_Stock_Devengado.Name = "Rdb_Stock_Devengado"
        Me.Rdb_Stock_Devengado.Size = New System.Drawing.Size(94, 14)
        Me.Rdb_Stock_Devengado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Stock_Devengado.TabIndex = 6
        Me.Rdb_Stock_Devengado.Text = "Devengado"
        '
        'Rdb_Stock_Fisico
        '
        Me.Rdb_Stock_Fisico.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Stock_Fisico.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Stock_Fisico.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Stock_Fisico.Checked = True
        Me.Rdb_Stock_Fisico.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Stock_Fisico.CheckValue = "Y"
        Me.Rdb_Stock_Fisico.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Stock_Fisico.Location = New System.Drawing.Point(3, 3)
        Me.Rdb_Stock_Fisico.Name = "Rdb_Stock_Fisico"
        Me.Rdb_Stock_Fisico.Size = New System.Drawing.Size(94, 14)
        Me.Rdb_Stock_Fisico.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Stock_Fisico.TabIndex = 3
        Me.Rdb_Stock_Fisico.Text = "Físico"
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(172, 143)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(180, 142)
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
        Me.GroupPanel2.TabIndex = 99
        Me.GroupPanel2.Text = "Saldos"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_Saldo_Distinto_de_cero, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_Saldo_Con_saldo_Positivo, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_Saldo_Con_y_sin_saldo, 0, 0)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 13)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(168, 67)
        Me.TableLayoutPanel1.TabIndex = 5
        '
        'Rdb_Saldo_Distinto_de_cero
        '
        Me.Rdb_Saldo_Distinto_de_cero.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Saldo_Distinto_de_cero.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Saldo_Distinto_de_cero.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Saldo_Distinto_de_cero.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Saldo_Distinto_de_cero.Location = New System.Drawing.Point(3, 47)
        Me.Rdb_Saldo_Distinto_de_cero.Name = "Rdb_Saldo_Distinto_de_cero"
        Me.Rdb_Saldo_Distinto_de_cero.Size = New System.Drawing.Size(162, 14)
        Me.Rdb_Saldo_Distinto_de_cero.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Saldo_Distinto_de_cero.TabIndex = 6
        Me.Rdb_Saldo_Distinto_de_cero.Text = "Con saldo distinto de cero"
        '
        'Rdb_Saldo_Con_saldo_Positivo
        '
        Me.Rdb_Saldo_Con_saldo_Positivo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Saldo_Con_saldo_Positivo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Saldo_Con_saldo_Positivo.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Saldo_Con_saldo_Positivo.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Saldo_Con_saldo_Positivo.Location = New System.Drawing.Point(3, 25)
        Me.Rdb_Saldo_Con_saldo_Positivo.Name = "Rdb_Saldo_Con_saldo_Positivo"
        Me.Rdb_Saldo_Con_saldo_Positivo.Size = New System.Drawing.Size(126, 14)
        Me.Rdb_Saldo_Con_saldo_Positivo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Saldo_Con_saldo_Positivo.TabIndex = 6
        Me.Rdb_Saldo_Con_saldo_Positivo.Text = "Con saldo positivo"
        '
        'Rdb_Saldo_Con_y_sin_saldo
        '
        Me.Rdb_Saldo_Con_y_sin_saldo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Saldo_Con_y_sin_saldo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Saldo_Con_y_sin_saldo.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Saldo_Con_y_sin_saldo.Checked = True
        Me.Rdb_Saldo_Con_y_sin_saldo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Saldo_Con_y_sin_saldo.CheckValue = "Y"
        Me.Rdb_Saldo_Con_y_sin_saldo.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Saldo_Con_y_sin_saldo.Location = New System.Drawing.Point(3, 3)
        Me.Rdb_Saldo_Con_y_sin_saldo.Name = "Rdb_Saldo_Con_y_sin_saldo"
        Me.Rdb_Saldo_Con_y_sin_saldo.Size = New System.Drawing.Size(94, 14)
        Me.Rdb_Saldo_Con_y_sin_saldo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Saldo_Con_y_sin_saldo.TabIndex = 3
        Me.Rdb_Saldo_Con_y_sin_saldo.Text = "Con y sin saldo"
        '
        'GroupPanel4
        '
        Me.GroupPanel4.BackColor = System.Drawing.Color.White
        Me.GroupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel4.Controls.Add(Me.TableLayoutPanel4)
        Me.GroupPanel4.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel4.Enabled = False
        Me.GroupPanel4.Location = New System.Drawing.Point(12, 291)
        Me.GroupPanel4.Name = "GroupPanel4"
        Me.GroupPanel4.Size = New System.Drawing.Size(154, 90)
        '
        '
        '
        Me.GroupPanel4.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel4.Style.BackColorGradientAngle = 90
        Me.GroupPanel4.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel4.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderBottomWidth = 1
        Me.GroupPanel4.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel4.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderLeftWidth = 1
        Me.GroupPanel4.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderRightWidth = 1
        Me.GroupPanel4.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderTopWidth = 1
        Me.GroupPanel4.Style.CornerDiameter = 4
        Me.GroupPanel4.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel4.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel4.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel4.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel4.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel4.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel4.TabIndex = 101
        Me.GroupPanel4.Text = "Unidad"
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel4.ColumnCount = 1
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.CheckBoxX5, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.CheckBoxX11, 0, 0)
        Me.TableLayoutPanel4.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(3, 13)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 2
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(135, 45)
        Me.TableLayoutPanel4.TabIndex = 5
        '
        'CheckBoxX5
        '
        Me.CheckBoxX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.CheckBoxX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxX5.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.CheckBoxX5.ForeColor = System.Drawing.Color.Black
        Me.CheckBoxX5.Location = New System.Drawing.Point(3, 25)
        Me.CheckBoxX5.Name = "CheckBoxX5"
        Me.CheckBoxX5.Size = New System.Drawing.Size(126, 14)
        Me.CheckBoxX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxX5.TabIndex = 6
        Me.CheckBoxX5.Text = "Secundaria"
        '
        'CheckBoxX11
        '
        Me.CheckBoxX11.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.CheckBoxX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxX11.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.CheckBoxX11.Checked = True
        Me.CheckBoxX11.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxX11.CheckValue = "Y"
        Me.CheckBoxX11.ForeColor = System.Drawing.Color.Black
        Me.CheckBoxX11.Location = New System.Drawing.Point(3, 3)
        Me.CheckBoxX11.Name = "CheckBoxX11"
        Me.CheckBoxX11.Size = New System.Drawing.Size(94, 14)
        Me.CheckBoxX11.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxX11.TabIndex = 3
        Me.CheckBoxX11.Text = "Principal"
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel5.ColumnCount = 1
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.CheckBoxX1, 0, 3)
        Me.TableLayoutPanel5.Controls.Add(Me.Chk_Excluye_SSN, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Chk_Excluye_FLN, 0, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.Chk_No_Bloqueados, 0, 2)
        Me.TableLayoutPanel5.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(12, 387)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 4
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(276, 89)
        Me.TableLayoutPanel5.TabIndex = 102
        '
        'CheckBoxX1
        '
        Me.CheckBoxX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.CheckBoxX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxX1.Checked = True
        Me.CheckBoxX1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxX1.CheckValue = "Y"
        Me.CheckBoxX1.Enabled = False
        Me.CheckBoxX1.ForeColor = System.Drawing.Color.Black
        Me.CheckBoxX1.Location = New System.Drawing.Point(3, 72)
        Me.CheckBoxX1.Name = "CheckBoxX1"
        Me.CheckBoxX1.Size = New System.Drawing.Size(270, 14)
        Me.CheckBoxX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxX1.TabIndex = 103
        Me.CheckBoxX1.Text = "Valorización al precio promedio ponderado (PM)"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem1})
        Me.Bar2.Location = New System.Drawing.Point(0, 0)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(363, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar2.TabIndex = 103
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'ButtonItem1
        '
        Me.ButtonItem1.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem1.Image = CType(resources.GetObject("ButtonItem1.Image"), System.Drawing.Image)
        Me.ButtonItem1.Name = "ButtonItem1"
        Me.ButtonItem1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Filtros_Bodega, Me.Btn_Clasificacion_Productos})
        Me.ButtonItem1.Text = "Filtros"
        '
        'Btn_Filtros_Bodega
        '
        Me.Btn_Filtros_Bodega.Image = CType(resources.GetObject("Btn_Filtros_Bodega.Image"), System.Drawing.Image)
        Me.Btn_Filtros_Bodega.Name = "Btn_Filtros_Bodega"
        Me.Btn_Filtros_Bodega.Text = "Bodegas"
        '
        'Btn_Clasificacion_Productos
        '
        Me.Btn_Clasificacion_Productos.Image = CType(resources.GetObject("Btn_Clasificacion_Productos.Image"), System.Drawing.Image)
        Me.Btn_Clasificacion_Productos.Name = "Btn_Clasificacion_Productos"
        Me.Btn_Clasificacion_Productos.Text = "Filtros (Super familia, Marcas, Clasificación, Rubro, Zonas)"
        '
        'GroupPanel3
        '
        Me.GroupPanel3.BackColor = System.Drawing.Color.White
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.TableLayoutPanel2)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Location = New System.Drawing.Point(12, 49)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(340, 88)
        '
        '
        '
        Me.GroupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel3.Style.BackColorGradientAngle = 90
        Me.GroupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderBottomWidth = 1
        Me.GroupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderLeftWidth = 1
        Me.GroupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderRightWidth = 1
        Me.GroupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderTopWidth = 1
        Me.GroupPanel3.Style.CornerDiameter = 4
        Me.GroupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel3.TabIndex = 104
        Me.GroupPanel3.Text = "Fecha de valorización del stock"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 104.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Dtp_Fecha_Actual, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Rdb_Valorizado_Fecha_Anterior, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Rdb_Valorizado_Fecha_Actual, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Dtp_Fecha_Anterior, 1, 1)
        Me.TableLayoutPanel2.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(6, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(310, 59)
        Me.TableLayoutPanel2.TabIndex = 5
        '
        'Dtp_Fecha_Actual
        '
        Me.Dtp_Fecha_Actual.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_Fecha_Actual.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Actual.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Actual.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Actual.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Actual.Enabled = False
        Me.Dtp_Fecha_Actual.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Actual.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Actual.Location = New System.Drawing.Point(209, 3)
        '
        '
        '
        Me.Dtp_Fecha_Actual.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Actual.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Actual.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Actual.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Actual.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Actual.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Actual.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Actual.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Actual.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Actual.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Actual.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Actual.MonthCalendar.DisplayMonth = New Date(2017, 5, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Actual.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Actual.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Actual.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Actual.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Actual.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Actual.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Actual.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Actual.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Actual.Name = "Dtp_Fecha_Actual"
        Me.Dtp_Fecha_Actual.Size = New System.Drawing.Size(93, 22)
        Me.Dtp_Fecha_Actual.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Actual.TabIndex = 105
        Me.Dtp_Fecha_Actual.Value = New Date(2017, 5, 9, 17, 44, 34, 0)
        '
        'Rdb_Valorizado_Fecha_Anterior
        '
        Me.Rdb_Valorizado_Fecha_Anterior.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Valorizado_Fecha_Anterior.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Valorizado_Fecha_Anterior.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Valorizado_Fecha_Anterior.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Valorizado_Fecha_Anterior.Location = New System.Drawing.Point(3, 32)
        Me.Rdb_Valorizado_Fecha_Anterior.Name = "Rdb_Valorizado_Fecha_Anterior"
        Me.Rdb_Valorizado_Fecha_Anterior.Size = New System.Drawing.Size(163, 20)
        Me.Rdb_Valorizado_Fecha_Anterior.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Valorizado_Fecha_Anterior.TabIndex = 6
        Me.Rdb_Valorizado_Fecha_Anterior.Text = "Valorizado a fecha anterior"
        '
        'Rdb_Valorizado_Fecha_Actual
        '
        Me.Rdb_Valorizado_Fecha_Actual.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Valorizado_Fecha_Actual.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Valorizado_Fecha_Actual.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Valorizado_Fecha_Actual.Checked = True
        Me.Rdb_Valorizado_Fecha_Actual.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Valorizado_Fecha_Actual.CheckValue = "Y"
        Me.Rdb_Valorizado_Fecha_Actual.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Valorizado_Fecha_Actual.Location = New System.Drawing.Point(3, 3)
        Me.Rdb_Valorizado_Fecha_Actual.Name = "Rdb_Valorizado_Fecha_Actual"
        Me.Rdb_Valorizado_Fecha_Actual.Size = New System.Drawing.Size(94, 22)
        Me.Rdb_Valorizado_Fecha_Actual.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Valorizado_Fecha_Actual.TabIndex = 3
        Me.Rdb_Valorizado_Fecha_Actual.Text = "Fecha actual"
        '
        'Frm_Informe_Stock_Valorizado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(363, 533)
        Me.Controls.Add(Me.GroupPanel3)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.TableLayoutPanel5)
        Me.Controls.Add(Me.GroupPanel4)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Informe_Stock_Valorizado"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informe de Stock Valorizado"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_Fecha_Anterior, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.GroupPanel2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel3.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.Dtp_Fecha_Actual, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Ejecutar_Informe As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Dtp_Fecha_Anterior As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Chk_Excluye_SSN As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Excluye_FLN As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_No_Bloqueados As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Rdb_Stock_Devengado As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Stock_Comprometido As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Rdb_Stock_Pedido As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Stock_Compras_No_Recibidas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Stock_Fisico As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Rdb_Saldo_Distinto_de_cero As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Saldo_Con_saldo_Positivo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Saldo_Con_y_sin_saldo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents GroupPanel4 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents CheckBoxX5 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents CheckBoxX11 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents CheckBoxX1 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Filtros_Bodega As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Clasificacion_Productos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Rdb_Valorizado_Fecha_Anterior As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Valorizado_Fecha_Actual As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Dtp_Fecha_Actual As DevComponents.Editors.DateTimeAdv.DateTimeInput
End Class
