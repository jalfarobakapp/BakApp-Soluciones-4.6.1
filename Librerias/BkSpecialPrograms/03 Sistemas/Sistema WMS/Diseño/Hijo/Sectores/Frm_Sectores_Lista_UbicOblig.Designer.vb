<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Sectores_Lista_UbicOblig
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Sectores_Lista_UbicOblig))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Menu_Contextual = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_01 = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_VerInventario = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_EditarInventario = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_EliminarInventario = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem3 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Copiar = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_FechaRevision = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.LblBodega = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.LblSucursal = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LblEmpresa = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Imagenes_16x16 = New System.Windows.Forms.ImageList(Me.components)
        Me.Imagenes_16x16_Dark = New System.Windows.Forms.ImageList(Me.components)
        Me.Btn_ConfProdUbic = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Menu_Contextual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.Dtp_FechaRevision, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Menu_Contextual)
        Me.GroupPanel1.Controls.Add(Me.Grilla)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 133)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(716, 444)
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
        Me.GroupPanel1.TabIndex = 34
        Me.GroupPanel1.Text = "Sectores"
        '
        'Menu_Contextual
        '
        Me.Menu_Contextual.AntiAlias = True
        Me.Menu_Contextual.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Menu_Contextual.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_01})
        Me.Menu_Contextual.Location = New System.Drawing.Point(44, 94)
        Me.Menu_Contextual.Name = "Menu_Contextual"
        Me.Menu_Contextual.Size = New System.Drawing.Size(412, 25)
        Me.Menu_Contextual.Stretch = True
        Me.Menu_Contextual.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Menu_Contextual.TabIndex = 49
        Me.Menu_Contextual.TabStop = False
        Me.Menu_Contextual.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_01
        '
        Me.Menu_Contextual_01.AutoExpandOnClick = True
        Me.Menu_Contextual_01.Name = "Menu_Contextual_01"
        Me.Menu_Contextual_01.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_VerInventario, Me.LabelItem1, Me.Btn_EditarInventario, Me.Btn_EliminarInventario, Me.LabelItem3, Me.Btn_Copiar})
        Me.Menu_Contextual_01.Text = "Opciones documento"
        '
        'Btn_VerInventario
        '
        Me.Btn_VerInventario.Image = CType(resources.GetObject("Btn_VerInventario.Image"), System.Drawing.Image)
        Me.Btn_VerInventario.ImageAlt = CType(resources.GetObject("Btn_VerInventario.ImageAlt"), System.Drawing.Image)
        Me.Btn_VerInventario.Name = "Btn_VerInventario"
        Me.Btn_VerInventario.Text = "Ingresar al inventario"
        '
        'LabelItem1
        '
        Me.LabelItem1.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem1.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem1.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem1.Name = "LabelItem1"
        Me.LabelItem1.PaddingBottom = 1
        Me.LabelItem1.PaddingLeft = 10
        Me.LabelItem1.PaddingTop = 1
        Me.LabelItem1.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem1.Text = "Opciones"
        '
        'Btn_EditarInventario
        '
        Me.Btn_EditarInventario.Image = CType(resources.GetObject("Btn_EditarInventario.Image"), System.Drawing.Image)
        Me.Btn_EditarInventario.ImageAlt = CType(resources.GetObject("Btn_EditarInventario.ImageAlt"), System.Drawing.Image)
        Me.Btn_EditarInventario.Name = "Btn_EditarInventario"
        Me.Btn_EditarInventario.Text = "Editar"
        '
        'Btn_EliminarInventario
        '
        Me.Btn_EliminarInventario.Image = CType(resources.GetObject("Btn_EliminarInventario.Image"), System.Drawing.Image)
        Me.Btn_EliminarInventario.ImageAlt = CType(resources.GetObject("Btn_EliminarInventario.ImageAlt"), System.Drawing.Image)
        Me.Btn_EliminarInventario.Name = "Btn_EliminarInventario"
        Me.Btn_EliminarInventario.Text = "Eliminar"
        '
        'LabelItem3
        '
        Me.LabelItem3.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem3.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem3.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem3.Name = "LabelItem3"
        Me.LabelItem3.PaddingBottom = 1
        Me.LabelItem3.PaddingLeft = 10
        Me.LabelItem3.PaddingTop = 1
        Me.LabelItem3.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem3.Text = "-----------------------------------------"
        '
        'Btn_Copiar
        '
        Me.Btn_Copiar.Image = CType(resources.GetObject("Btn_Copiar.Image"), System.Drawing.Image)
        Me.Btn_Copiar.ImageAlt = CType(resources.GetObject("Btn_Copiar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Copiar.Name = "Btn_Copiar"
        Me.Btn_Copiar.Text = "Copiar (portapapeles)"
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla.DefaultCellStyle = DataGridViewCellStyle5
        Me.Grilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla.EnableHeadersVisualStyles = False
        Me.Grilla.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla.Location = New System.Drawing.Point(0, 0)
        Me.Grilla.Name = "Grilla"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Grilla.Size = New System.Drawing.Size(710, 421)
        Me.Grilla.StandardTab = True
        Me.Grilla.TabIndex = 30
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_ConfProdUbic})
        Me.Bar1.Location = New System.Drawing.Point(0, 583)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(740, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 33
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.LabelX1)
        Me.GroupPanel2.Controls.Add(Me.Dtp_FechaRevision)
        Me.GroupPanel2.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(12, 2)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(716, 125)
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
        Me.GroupPanel2.TabIndex = 93
        Me.GroupPanel2.Text = "Datos del mapa"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(8, 74)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 22)
        Me.LabelX1.TabIndex = 93
        Me.LabelX1.Text = "Fecha revisión"
        '
        'Dtp_FechaRevision
        '
        Me.Dtp_FechaRevision.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_FechaRevision.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_FechaRevision.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaRevision.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_FechaRevision.ButtonDropDown.Visible = True
        Me.Dtp_FechaRevision.ForeColor = System.Drawing.Color.Black
        Me.Dtp_FechaRevision.Format = DevComponents.Editors.eDateTimePickerFormat.[Long]
        Me.Dtp_FechaRevision.IsPopupCalendarOpen = False
        Me.Dtp_FechaRevision.Location = New System.Drawing.Point(91, 74)
        '
        '
        '
        Me.Dtp_FechaRevision.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FechaRevision.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaRevision.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_FechaRevision.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_FechaRevision.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_FechaRevision.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FechaRevision.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_FechaRevision.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_FechaRevision.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_FechaRevision.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_FechaRevision.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaRevision.MonthCalendar.DisplayMonth = New Date(2024, 10, 1, 0, 0, 0, 0)
        Me.Dtp_FechaRevision.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_FechaRevision.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_FechaRevision.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FechaRevision.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_FechaRevision.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FechaRevision.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_FechaRevision.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaRevision.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_FechaRevision.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_FechaRevision.Name = "Dtp_FechaRevision"
        Me.Dtp_FechaRevision.Size = New System.Drawing.Size(200, 22)
        Me.Dtp_FechaRevision.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_FechaRevision.TabIndex = 92
        Me.Dtp_FechaRevision.Value = New Date(2024, 10, 18, 12, 10, 54, 0)
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.LblBodega, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX6, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.LblSucursal, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX4, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LblEmpresa, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX2, 0, 0)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(704, 65)
        Me.TableLayoutPanel1.TabIndex = 91
        '
        'LblBodega
        '
        Me.LblBodega.AutoSize = True
        '
        '
        '
        Me.LblBodega.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblBodega.ForeColor = System.Drawing.Color.Black
        Me.LblBodega.Location = New System.Drawing.Point(88, 46)
        Me.LblBodega.Name = "LblBodega"
        Me.LblBodega.Size = New System.Drawing.Size(41, 17)
        Me.LblBodega.TabIndex = 5
        Me.LblBodega.Text = "LabelX7"
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(5, 46)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(75, 14)
        Me.LabelX6.TabIndex = 4
        Me.LabelX6.Text = "Bodega"
        '
        'LblSucursal
        '
        Me.LblSucursal.AutoSize = True
        '
        '
        '
        Me.LblSucursal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblSucursal.ForeColor = System.Drawing.Color.Black
        Me.LblSucursal.Location = New System.Drawing.Point(88, 24)
        Me.LblSucursal.Name = "LblSucursal"
        Me.LblSucursal.Size = New System.Drawing.Size(41, 17)
        Me.LblSucursal.TabIndex = 3
        Me.LblSucursal.Text = "LabelX5"
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(5, 24)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(75, 14)
        Me.LabelX4.TabIndex = 2
        Me.LabelX4.Text = "Sucursal"
        '
        'LblEmpresa
        '
        Me.LblEmpresa.AutoSize = True
        '
        '
        '
        Me.LblEmpresa.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblEmpresa.ForeColor = System.Drawing.Color.Black
        Me.LblEmpresa.Location = New System.Drawing.Point(88, 5)
        Me.LblEmpresa.Name = "LblEmpresa"
        Me.LblEmpresa.Size = New System.Drawing.Size(41, 17)
        Me.LblEmpresa.TabIndex = 1
        Me.LblEmpresa.Text = "LabelX3"
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(5, 5)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 11)
        Me.LabelX2.TabIndex = 0
        Me.LabelX2.Text = "Empresa"
        '
        'Imagenes_16x16
        '
        Me.Imagenes_16x16.ImageStream = CType(resources.GetObject("Imagenes_16x16.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagenes_16x16.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagenes_16x16.Images.SetKeyName(0, "warning.png")
        Me.Imagenes_16x16.Images.SetKeyName(1, "ok.png")
        Me.Imagenes_16x16.Images.SetKeyName(2, "cancel.png")
        Me.Imagenes_16x16.Images.SetKeyName(3, "delete_button_error.png")
        Me.Imagenes_16x16.Images.SetKeyName(4, "clock.png")
        Me.Imagenes_16x16.Images.SetKeyName(5, "clock-import.png")
        Me.Imagenes_16x16.Images.SetKeyName(6, "clock-info.png")
        Me.Imagenes_16x16.Images.SetKeyName(7, "tag_green.png")
        Me.Imagenes_16x16.Images.SetKeyName(8, "note_text.png")
        Me.Imagenes_16x16.Images.SetKeyName(9, "note.png")
        Me.Imagenes_16x16.Images.SetKeyName(10, "comment-number-1.png")
        Me.Imagenes_16x16.Images.SetKeyName(11, "comment-number-2.png")
        Me.Imagenes_16x16.Images.SetKeyName(12, "comment-number-3.png")
        Me.Imagenes_16x16.Images.SetKeyName(13, "comment-number-4.png")
        Me.Imagenes_16x16.Images.SetKeyName(14, "comment-number-5.png")
        Me.Imagenes_16x16.Images.SetKeyName(15, "comment-number-6.png")
        Me.Imagenes_16x16.Images.SetKeyName(16, "comment-number-7.png")
        Me.Imagenes_16x16.Images.SetKeyName(17, "comment-number-8.png")
        Me.Imagenes_16x16.Images.SetKeyName(18, "comment-number-9.png")
        Me.Imagenes_16x16.Images.SetKeyName(19, "comment-number-9-plus.png")
        Me.Imagenes_16x16.Images.SetKeyName(20, "menu-more.png")
        Me.Imagenes_16x16.Images.SetKeyName(21, "symbol-delete.png")
        Me.Imagenes_16x16.Images.SetKeyName(22, "symbol-ok-warning.png")
        Me.Imagenes_16x16.Images.SetKeyName(23, "symbol-remove.png")
        '
        'Imagenes_16x16_Dark
        '
        Me.Imagenes_16x16_Dark.ImageStream = CType(resources.GetObject("Imagenes_16x16_Dark.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagenes_16x16_Dark.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagenes_16x16_Dark.Images.SetKeyName(0, "warning.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(1, "ok.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(2, "cancel.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(3, "delete_button_error.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(4, "clock.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(5, "clock-import.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(6, "clock-info.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(7, "tag_green.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(8, "note_text.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(9, "note.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(10, "menu-more.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(11, "comment-number-9.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(12, "comment-number-9-plus.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(13, "comment-number-8.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(14, "comment-number-7.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(15, "comment-number-6.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(16, "comment-number-5.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(17, "comment-number-4.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(18, "comment-number-3.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(19, "comment-number-2.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(20, "comment-number-1.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(21, "symbol-delete.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(22, "symbol-ok-warning.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(23, "symbol-remove.png")
        '
        'Btn_ConfProdUbic
        '
        Me.Btn_ConfProdUbic.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_ConfProdUbic.ForeColor = System.Drawing.Color.Black
        Me.Btn_ConfProdUbic.Image = CType(resources.GetObject("Btn_ConfProdUbic.Image"), System.Drawing.Image)
        Me.Btn_ConfProdUbic.ImageAlt = CType(resources.GetObject("Btn_ConfProdUbic.ImageAlt"), System.Drawing.Image)
        Me.Btn_ConfProdUbic.Name = "Btn_ConfProdUbic"
        Me.Btn_ConfProdUbic.Tooltip = "Confirmar productos en todos las ubicaciones de estos sectores"
        '
        'Frm_Sectores_Lista_UbicOblig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(740, 624)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Sectores_Lista_UbicOblig"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SECTORES DEL MAPA:"
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.Menu_Contextual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.Dtp_FechaRevision, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Menu_Contextual As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_01 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_VerInventario As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_EditarInventario As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_EliminarInventario As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem3 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Copiar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Public WithEvents LblBodega As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Public WithEvents LblSucursal As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Public WithEvents LblEmpresa As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dtp_FechaRevision As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Imagenes_16x16 As ImageList
    Friend WithEvents Imagenes_16x16_Dark As ImageList
    Friend WithEvents Btn_ConfProdUbic As DevComponents.DotNetBar.ButtonItem
End Class
