<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_CRV
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_CRV))
        Me.Grupo_Vehiculo = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.Layaut_Cierre = New System.Windows.Forms.TableLayoutPanel
        Me.Btn_Hora_Actual = New DevComponents.DotNetBar.ButtonX
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX
        Me.Dtp_Hora_Llegada = New DevComponents.Editors.DateTimeAdv.DateTimeInput
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
        Me.Btn_Fecha_Actual = New DevComponents.DotNetBar.ButtonX
        Me.Input_Kilometro_Llegada = New DevComponents.Editors.IntegerInput
        Me.Btn_Editar_Km_Llegada = New DevComponents.DotNetBar.ButtonX
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX
        Me.Dtp_Fecha_Llegada = New DevComponents.Editors.DateTimeAdv.DateTimeInput
        Me.Layaut_CRV_1 = New System.Windows.Forms.TableLayoutPanel
        Me.Btn_Vehiculos = New DevComponents.DotNetBar.ButtonX
        Me.Cmb_Nuevo_Vehiculo = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.Txt_Patente = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.Lbl_Nombre_Vehiculo = New DevComponents.DotNetBar.LabelX
        Me.Lbl_Patente = New DevComponents.DotNetBar.LabelX
        Me.Layaut_CRV_2 = New System.Windows.Forms.TableLayoutPanel
        Me.Btn_Editar_Km_Salida = New DevComponents.DotNetBar.ButtonX
        Me.Dtp_Hora_Salida = New DevComponents.Editors.DateTimeAdv.DateTimeInput
        Me.Input_Kilometro_Salida = New DevComponents.Editors.IntegerInput
        Me.Lbl_Chofer = New DevComponents.DotNetBar.LabelX
        Me.Cmb_Chofer = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.Btn_Chofer = New DevComponents.DotNetBar.ButtonX
        Me.Lbl_Fecha = New DevComponents.DotNetBar.LabelX
        Me.Lbl_Nro_Motor = New DevComponents.DotNetBar.LabelX
        Me.Dtp_Fecha_Salida = New DevComponents.Editors.DateTimeAdv.DateTimeInput
        Me.Lbl_Chasis = New DevComponents.DotNetBar.LabelX
        Me.Txt_Razon_Entidad = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX22 = New DevComponents.DotNetBar.LabelX
        Me.LabelX23 = New DevComponents.DotNetBar.LabelX
        Me.LabelX24 = New DevComponents.DotNetBar.LabelX
        Me.Lbl_Color = New DevComponents.DotNetBar.LabelX
        Me.Cmb_Pais = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.Cmb_Ciudad = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.Cmb_Comuna = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.Txt_Direccion = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.Btn_Entidad = New DevComponents.DotNetBar.ButtonX
        Me.Btn_Limpiar_Entidad = New DevComponents.DotNetBar.ButtonX
        Me.Lbl_Kilometraje = New DevComponents.DotNetBar.LabelX
        Me.Bar2 = New DevComponents.DotNetBar.Bar
        Me.Btn_Cerrar_CRV = New DevComponents.DotNetBar.ButtonItem
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem
        Me.Btn_Editar = New DevComponents.DotNetBar.ButtonItem
        Me.Btn_Anular = New DevComponents.DotNetBar.ButtonItem
        Me.Btn_Cancelar = New DevComponents.DotNetBar.ButtonItem
        Me.Btn_Imprimir_CRV = New DevComponents.DotNetBar.ButtonItem
        Me.Btn_Salir = New DevComponents.DotNetBar.ButtonItem
        Me.Imagenes_32x32 = New System.Windows.Forms.ImageList(Me.components)
        Me.Grupo_Vehiculo.SuspendLayout()
        Me.Layaut_Cierre.SuspendLayout()
        CType(Me.Dtp_Hora_Llegada, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Input_Kilometro_Llegada, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_Fecha_Llegada, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Layaut_CRV_1.SuspendLayout()
        Me.Layaut_CRV_2.SuspendLayout()
        CType(Me.Dtp_Hora_Salida, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Input_Kilometro_Salida, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_Fecha_Salida, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Grupo_Vehiculo
        '
        Me.Grupo_Vehiculo.BackColor = System.Drawing.Color.White
        Me.Grupo_Vehiculo.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Vehiculo.Controls.Add(Me.Layaut_Cierre)
        Me.Grupo_Vehiculo.Controls.Add(Me.Layaut_CRV_1)
        Me.Grupo_Vehiculo.Controls.Add(Me.Layaut_CRV_2)
        Me.Grupo_Vehiculo.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Vehiculo.Location = New System.Drawing.Point(12, 2)
        Me.Grupo_Vehiculo.Name = "Grupo_Vehiculo"
        Me.Grupo_Vehiculo.Size = New System.Drawing.Size(506, 472)
        '
        '
        '
        Me.Grupo_Vehiculo.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Vehiculo.Style.BackColorGradientAngle = 90
        Me.Grupo_Vehiculo.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Vehiculo.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Vehiculo.Style.BorderBottomWidth = 1
        Me.Grupo_Vehiculo.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Vehiculo.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Vehiculo.Style.BorderLeftWidth = 1
        Me.Grupo_Vehiculo.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Vehiculo.Style.BorderRightWidth = 1
        Me.Grupo_Vehiculo.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Vehiculo.Style.BorderTopWidth = 1
        Me.Grupo_Vehiculo.Style.CornerDiameter = 4
        Me.Grupo_Vehiculo.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Vehiculo.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Vehiculo.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Vehiculo.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Vehiculo.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Vehiculo.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Vehiculo.TabIndex = 101
        Me.Grupo_Vehiculo.Text = "Información del Vehículo"
        '
        'Layaut_Cierre
        '
        Me.Layaut_Cierre.BackColor = System.Drawing.Color.Transparent
        Me.Layaut_Cierre.ColumnCount = 4
        Me.Layaut_Cierre.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.2915!))
        Me.Layaut_Cierre.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.53846!))
        Me.Layaut_Cierre.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.680162!))
        Me.Layaut_Cierre.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.287449!))
        Me.Layaut_Cierre.Controls.Add(Me.Btn_Hora_Actual, 2, 3)
        Me.Layaut_Cierre.Controls.Add(Me.LabelX3, 0, 3)
        Me.Layaut_Cierre.Controls.Add(Me.Dtp_Hora_Llegada, 1, 3)
        Me.Layaut_Cierre.Controls.Add(Me.LabelX1, 0, 0)
        Me.Layaut_Cierre.Controls.Add(Me.Btn_Fecha_Actual, 2, 2)
        Me.Layaut_Cierre.Controls.Add(Me.Input_Kilometro_Llegada, 1, 0)
        Me.Layaut_Cierre.Controls.Add(Me.Btn_Editar_Km_Llegada, 2, 0)
        Me.Layaut_Cierre.Controls.Add(Me.LabelX2, 0, 2)
        Me.Layaut_Cierre.Controls.Add(Me.Dtp_Fecha_Llegada, 1, 2)
        Me.Layaut_Cierre.ForeColor = System.Drawing.Color.Black
        Me.Layaut_Cierre.Location = New System.Drawing.Point(3, 341)
        Me.Layaut_Cierre.Name = "Layaut_Cierre"
        Me.Layaut_Cierre.RowCount = 4
        Me.Layaut_Cierre.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.Layaut_Cierre.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.Layaut_Cierre.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.Layaut_Cierre.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.Layaut_Cierre.Size = New System.Drawing.Size(494, 101)
        Me.Layaut_Cierre.TabIndex = 102
        '
        'Btn_Hora_Actual
        '
        Me.Btn_Hora_Actual.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Hora_Actual.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Hora_Actual.Image = CType(resources.GetObject("Btn_Hora_Actual.Image"), System.Drawing.Image)
        Me.Btn_Hora_Actual.Location = New System.Drawing.Point(427, 78)
        Me.Btn_Hora_Actual.Name = "Btn_Hora_Actual"
        Me.Btn_Hora_Actual.Size = New System.Drawing.Size(27, 20)
        Me.Btn_Hora_Actual.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Hora_Actual.TabIndex = 104
        Me.Btn_Hora_Actual.Tooltip = "Poner hora actual"
        '
        'LabelX3
        '
        Me.LabelX3.AutoSize = True
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(3, 78)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(94, 20)
        Me.LabelX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX3.TabIndex = 102
        Me.LabelX3.Text = "Hora de llegada"
        '
        'Dtp_Hora_Llegada
        '
        '
        '
        '
        Me.Dtp_Hora_Llegada.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Hora_Llegada.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Hora_Llegada.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Hora_Llegada.ButtonDropDown.Visible = True
        Me.Dtp_Hora_Llegada.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Hora_Llegada.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime
        Me.Dtp_Hora_Llegada.IsPopupCalendarOpen = False
        Me.Dtp_Hora_Llegada.Location = New System.Drawing.Point(123, 78)
        '
        '
        '
        Me.Dtp_Hora_Llegada.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Hora_Llegada.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Hora_Llegada.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Hora_Llegada.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Hora_Llegada.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Hora_Llegada.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Hora_Llegada.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Hora_Llegada.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Hora_Llegada.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Hora_Llegada.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Hora_Llegada.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Hora_Llegada.MonthCalendar.DisplayMonth = New Date(2016, 11, 1, 0, 0, 0, 0)
        Me.Dtp_Hora_Llegada.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Hora_Llegada.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Hora_Llegada.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Hora_Llegada.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Hora_Llegada.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Hora_Llegada.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Hora_Llegada.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Hora_Llegada.MonthCalendar.Visible = False
        Me.Dtp_Hora_Llegada.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Hora_Llegada.Name = "Dtp_Hora_Llegada"
        Me.Dtp_Hora_Llegada.Size = New System.Drawing.Size(55, 22)
        Me.Dtp_Hora_Llegada.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Hora_Llegada.TabIndex = 114
        Me.Dtp_Hora_Llegada.Value = New Date(2016, 11, 7, 17, 33, 13, 0)
        '
        'LabelX1
        '
        Me.LabelX1.AutoSize = True
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(113, 20)
        Me.LabelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX1.TabIndex = 114
        Me.LabelX1.Text = "Kilometraje llegada"
        '
        'Btn_Fecha_Actual
        '
        Me.Btn_Fecha_Actual.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Fecha_Actual.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Fecha_Actual.Image = CType(resources.GetObject("Btn_Fecha_Actual.Image"), System.Drawing.Image)
        Me.Btn_Fecha_Actual.Location = New System.Drawing.Point(427, 53)
        Me.Btn_Fecha_Actual.Name = "Btn_Fecha_Actual"
        Me.Btn_Fecha_Actual.Size = New System.Drawing.Size(27, 19)
        Me.Btn_Fecha_Actual.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Fecha_Actual.TabIndex = 104
        Me.Btn_Fecha_Actual.Tooltip = "Poner fecha actual"
        '
        'Input_Kilometro_Llegada
        '
        Me.Input_Kilometro_Llegada.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_Kilometro_Llegada.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_Kilometro_Llegada.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_Kilometro_Llegada.ButtonClear.Visible = True
        Me.Input_Kilometro_Llegada.FocusHighlightEnabled = True
        Me.Input_Kilometro_Llegada.ForeColor = System.Drawing.Color.Black
        Me.Input_Kilometro_Llegada.Location = New System.Drawing.Point(123, 3)
        Me.Input_Kilometro_Llegada.MaxValue = 999999
        Me.Input_Kilometro_Llegada.MinValue = 0
        Me.Input_Kilometro_Llegada.Name = "Input_Kilometro_Llegada"
        Me.Input_Kilometro_Llegada.ShowUpDown = True
        Me.Input_Kilometro_Llegada.Size = New System.Drawing.Size(90, 22)
        Me.Input_Kilometro_Llegada.TabIndex = 107
        '
        'Btn_Editar_Km_Llegada
        '
        Me.Btn_Editar_Km_Llegada.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Editar_Km_Llegada.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Editar_Km_Llegada.Image = CType(resources.GetObject("Btn_Editar_Km_Llegada.Image"), System.Drawing.Image)
        Me.Btn_Editar_Km_Llegada.Location = New System.Drawing.Point(427, 3)
        Me.Btn_Editar_Km_Llegada.Name = "Btn_Editar_Km_Llegada"
        Me.Btn_Editar_Km_Llegada.Size = New System.Drawing.Size(27, 19)
        Me.Btn_Editar_Km_Llegada.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Editar_Km_Llegada.TabIndex = 103
        Me.Btn_Editar_Km_Llegada.Tooltip = "Buscar Cliente o Proveedor"
        '
        'LabelX2
        '
        Me.LabelX2.AutoSize = True
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 53)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(99, 20)
        Me.LabelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX2.TabIndex = 70
        Me.LabelX2.Text = "Fecha de llegada"
        '
        'Dtp_Fecha_Llegada
        '
        '
        '
        '
        Me.Dtp_Fecha_Llegada.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Llegada.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Llegada.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Llegada.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Llegada.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Llegada.Format = DevComponents.Editors.eDateTimePickerFormat.[Long]
        Me.Dtp_Fecha_Llegada.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Llegada.Location = New System.Drawing.Point(123, 53)
        '
        '
        '
        Me.Dtp_Fecha_Llegada.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Llegada.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Llegada.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Llegada.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Llegada.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Llegada.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Llegada.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Llegada.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Llegada.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Llegada.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Llegada.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Llegada.MonthCalendar.DisplayMonth = New Date(2016, 11, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Llegada.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Llegada.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Llegada.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Llegada.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Llegada.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Llegada.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Llegada.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Llegada.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Llegada.Name = "Dtp_Fecha_Llegada"
        Me.Dtp_Fecha_Llegada.Size = New System.Drawing.Size(206, 22)
        Me.Dtp_Fecha_Llegada.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Llegada.TabIndex = 113
        Me.Dtp_Fecha_Llegada.Value = New Date(2016, 11, 7, 17, 33, 4, 0)
        '
        'Layaut_CRV_1
        '
        Me.Layaut_CRV_1.BackColor = System.Drawing.Color.Transparent
        Me.Layaut_CRV_1.ColumnCount = 3
        Me.Layaut_CRV_1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.28947!))
        Me.Layaut_CRV_1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.71053!))
        Me.Layaut_CRV_1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67.0!))
        Me.Layaut_CRV_1.Controls.Add(Me.Btn_Vehiculos, 2, 0)
        Me.Layaut_CRV_1.Controls.Add(Me.Cmb_Nuevo_Vehiculo, 1, 0)
        Me.Layaut_CRV_1.Controls.Add(Me.Txt_Patente, 1, 1)
        Me.Layaut_CRV_1.Controls.Add(Me.Lbl_Nombre_Vehiculo, 0, 0)
        Me.Layaut_CRV_1.Controls.Add(Me.Lbl_Patente, 0, 1)
        Me.Layaut_CRV_1.ForeColor = System.Drawing.Color.Black
        Me.Layaut_CRV_1.Location = New System.Drawing.Point(3, 3)
        Me.Layaut_CRV_1.Name = "Layaut_CRV_1"
        Me.Layaut_CRV_1.RowCount = 2
        Me.Layaut_CRV_1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.1875!))
        Me.Layaut_CRV_1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.8125!))
        Me.Layaut_CRV_1.Size = New System.Drawing.Size(472, 64)
        Me.Layaut_CRV_1.TabIndex = 69
        '
        'Btn_Vehiculos
        '
        Me.Btn_Vehiculos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Vehiculos.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Vehiculos.Image = CType(resources.GetObject("Btn_Vehiculos.Image"), System.Drawing.Image)
        Me.Btn_Vehiculos.Location = New System.Drawing.Point(407, 3)
        Me.Btn_Vehiculos.Name = "Btn_Vehiculos"
        Me.Btn_Vehiculos.Size = New System.Drawing.Size(27, 20)
        Me.Btn_Vehiculos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Vehiculos.TabIndex = 102
        Me.Btn_Vehiculos.Tooltip = "Mantención de tabla de vehículos de la empresa" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Cmb_Nuevo_Vehiculo
        '
        Me.Cmb_Nuevo_Vehiculo.DisplayMember = "Text"
        Me.Cmb_Nuevo_Vehiculo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Nuevo_Vehiculo.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Nuevo_Vehiculo.FormattingEnabled = True
        Me.Cmb_Nuevo_Vehiculo.ItemHeight = 16
        Me.Cmb_Nuevo_Vehiculo.Location = New System.Drawing.Point(117, 3)
        Me.Cmb_Nuevo_Vehiculo.Name = "Cmb_Nuevo_Vehiculo"
        Me.Cmb_Nuevo_Vehiculo.Size = New System.Drawing.Size(284, 22)
        Me.Cmb_Nuevo_Vehiculo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Nuevo_Vehiculo.TabIndex = 102
        '
        'Txt_Patente
        '
        Me.Txt_Patente.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Patente.Border.Class = "TextBoxBorder"
        Me.Txt_Patente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Patente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Patente.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Patente.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Patente.FocusHighlightEnabled = True
        Me.Txt_Patente.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Patente.ForeColor = System.Drawing.Color.Black
        Me.Txt_Patente.Location = New System.Drawing.Point(117, 30)
        Me.Txt_Patente.MaxLength = 10
        Me.Txt_Patente.Name = "Txt_Patente"
        Me.Txt_Patente.ReadOnly = True
        Me.Txt_Patente.Size = New System.Drawing.Size(116, 33)
        Me.Txt_Patente.TabIndex = 89
        Me.Txt_Patente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Lbl_Nombre_Vehiculo
        '
        Me.Lbl_Nombre_Vehiculo.AutoSize = True
        Me.Lbl_Nombre_Vehiculo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Nombre_Vehiculo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Nombre_Vehiculo.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Nombre_Vehiculo.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Nombre_Vehiculo.Location = New System.Drawing.Point(3, 3)
        Me.Lbl_Nombre_Vehiculo.Name = "Lbl_Nombre_Vehiculo"
        Me.Lbl_Nombre_Vehiculo.Size = New System.Drawing.Size(101, 20)
        Me.Lbl_Nombre_Vehiculo.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Lbl_Nombre_Vehiculo.TabIndex = 100
        Me.Lbl_Nombre_Vehiculo.Text = "Nombre vehículo"
        '
        'Lbl_Patente
        '
        Me.Lbl_Patente.AutoSize = True
        Me.Lbl_Patente.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Patente.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Patente.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Patente.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Patente.Location = New System.Drawing.Point(3, 30)
        Me.Lbl_Patente.Name = "Lbl_Patente"
        Me.Lbl_Patente.Size = New System.Drawing.Size(46, 20)
        Me.Lbl_Patente.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Lbl_Patente.TabIndex = 70
        Me.Lbl_Patente.Text = "Patente"
        '
        'Layaut_CRV_2
        '
        Me.Layaut_CRV_2.BackColor = System.Drawing.Color.Transparent
        Me.Layaut_CRV_2.ColumnCount = 4
        Me.Layaut_CRV_2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.2915!))
        Me.Layaut_CRV_2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.53846!))
        Me.Layaut_CRV_2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.680162!))
        Me.Layaut_CRV_2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.287449!))
        Me.Layaut_CRV_2.Controls.Add(Me.Btn_Editar_Km_Salida, 2, 9)
        Me.Layaut_CRV_2.Controls.Add(Me.Dtp_Hora_Salida, 1, 2)
        Me.Layaut_CRV_2.Controls.Add(Me.Input_Kilometro_Salida, 1, 9)
        Me.Layaut_CRV_2.Controls.Add(Me.Lbl_Chofer, 0, 0)
        Me.Layaut_CRV_2.Controls.Add(Me.Cmb_Chofer, 1, 0)
        Me.Layaut_CRV_2.Controls.Add(Me.Btn_Chofer, 2, 0)
        Me.Layaut_CRV_2.Controls.Add(Me.Lbl_Fecha, 0, 1)
        Me.Layaut_CRV_2.Controls.Add(Me.Lbl_Nro_Motor, 0, 2)
        Me.Layaut_CRV_2.Controls.Add(Me.Dtp_Fecha_Salida, 1, 1)
        Me.Layaut_CRV_2.Controls.Add(Me.Lbl_Chasis, 0, 3)
        Me.Layaut_CRV_2.Controls.Add(Me.Txt_Razon_Entidad, 1, 3)
        Me.Layaut_CRV_2.Controls.Add(Me.LabelX22, 0, 4)
        Me.Layaut_CRV_2.Controls.Add(Me.LabelX23, 0, 5)
        Me.Layaut_CRV_2.Controls.Add(Me.LabelX24, 0, 6)
        Me.Layaut_CRV_2.Controls.Add(Me.Lbl_Color, 0, 7)
        Me.Layaut_CRV_2.Controls.Add(Me.Cmb_Pais, 1, 4)
        Me.Layaut_CRV_2.Controls.Add(Me.Cmb_Ciudad, 1, 5)
        Me.Layaut_CRV_2.Controls.Add(Me.Cmb_Comuna, 1, 6)
        Me.Layaut_CRV_2.Controls.Add(Me.Txt_Direccion, 1, 7)
        Me.Layaut_CRV_2.Controls.Add(Me.Btn_Entidad, 3, 3)
        Me.Layaut_CRV_2.Controls.Add(Me.Btn_Limpiar_Entidad, 2, 3)
        Me.Layaut_CRV_2.Controls.Add(Me.Lbl_Kilometraje, 0, 9)
        Me.Layaut_CRV_2.ForeColor = System.Drawing.Color.Black
        Me.Layaut_CRV_2.Location = New System.Drawing.Point(3, 73)
        Me.Layaut_CRV_2.Name = "Layaut_CRV_2"
        Me.Layaut_CRV_2.RowCount = 10
        Me.Layaut_CRV_2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.Layaut_CRV_2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.Layaut_CRV_2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.Layaut_CRV_2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.Layaut_CRV_2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.Layaut_CRV_2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.Layaut_CRV_2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.Layaut_CRV_2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.Layaut_CRV_2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.Layaut_CRV_2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.Layaut_CRV_2.Size = New System.Drawing.Size(494, 262)
        Me.Layaut_CRV_2.TabIndex = 68
        '
        'Btn_Editar_Km_Salida
        '
        Me.Btn_Editar_Km_Salida.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Editar_Km_Salida.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Editar_Km_Salida.Image = CType(resources.GetObject("Btn_Editar_Km_Salida.Image"), System.Drawing.Image)
        Me.Btn_Editar_Km_Salida.Location = New System.Drawing.Point(427, 237)
        Me.Btn_Editar_Km_Salida.Name = "Btn_Editar_Km_Salida"
        Me.Btn_Editar_Km_Salida.Size = New System.Drawing.Size(27, 20)
        Me.Btn_Editar_Km_Salida.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Editar_Km_Salida.TabIndex = 103
        Me.Btn_Editar_Km_Salida.Tooltip = "Editar kilometraje de salida manualmente"
        '
        'Dtp_Hora_Salida
        '
        '
        '
        '
        Me.Dtp_Hora_Salida.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Hora_Salida.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Hora_Salida.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Hora_Salida.ButtonDropDown.Visible = True
        Me.Dtp_Hora_Salida.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Hora_Salida.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime
        Me.Dtp_Hora_Salida.IsPopupCalendarOpen = False
        Me.Dtp_Hora_Salida.Location = New System.Drawing.Point(123, 55)
        '
        '
        '
        Me.Dtp_Hora_Salida.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Hora_Salida.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Hora_Salida.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Hora_Salida.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Hora_Salida.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Hora_Salida.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Hora_Salida.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Hora_Salida.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Hora_Salida.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Hora_Salida.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Hora_Salida.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Hora_Salida.MonthCalendar.DisplayMonth = New Date(2016, 11, 1, 0, 0, 0, 0)
        Me.Dtp_Hora_Salida.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Hora_Salida.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Hora_Salida.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Hora_Salida.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Hora_Salida.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Hora_Salida.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Hora_Salida.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Hora_Salida.MonthCalendar.Visible = False
        Me.Dtp_Hora_Salida.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Hora_Salida.Name = "Dtp_Hora_Salida"
        Me.Dtp_Hora_Salida.Size = New System.Drawing.Size(55, 22)
        Me.Dtp_Hora_Salida.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Hora_Salida.TabIndex = 113
        Me.Dtp_Hora_Salida.Value = New Date(2016, 11, 7, 17, 33, 13, 0)
        '
        'Input_Kilometro_Salida
        '
        Me.Input_Kilometro_Salida.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_Kilometro_Salida.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_Kilometro_Salida.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_Kilometro_Salida.ButtonClear.Visible = True
        Me.Input_Kilometro_Salida.Enabled = False
        Me.Input_Kilometro_Salida.FocusHighlightEnabled = True
        Me.Input_Kilometro_Salida.ForeColor = System.Drawing.Color.Black
        Me.Input_Kilometro_Salida.Location = New System.Drawing.Point(123, 237)
        Me.Input_Kilometro_Salida.MaxValue = 999999
        Me.Input_Kilometro_Salida.MinValue = 0
        Me.Input_Kilometro_Salida.Name = "Input_Kilometro_Salida"
        Me.Input_Kilometro_Salida.ShowUpDown = True
        Me.Input_Kilometro_Salida.Size = New System.Drawing.Size(90, 22)
        Me.Input_Kilometro_Salida.TabIndex = 106
        '
        'Lbl_Chofer
        '
        Me.Lbl_Chofer.AutoSize = True
        Me.Lbl_Chofer.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Chofer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Chofer.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Chofer.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Chofer.Location = New System.Drawing.Point(3, 3)
        Me.Lbl_Chofer.Name = "Lbl_Chofer"
        Me.Lbl_Chofer.Size = New System.Drawing.Size(97, 20)
        Me.Lbl_Chofer.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Lbl_Chofer.TabIndex = 110
        Me.Lbl_Chofer.Text = "Chofer asignado"
        '
        'Cmb_Chofer
        '
        Me.Cmb_Chofer.DisplayMember = "Text"
        Me.Cmb_Chofer.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Chofer.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Chofer.FormattingEnabled = True
        Me.Cmb_Chofer.ItemHeight = 16
        Me.Cmb_Chofer.Location = New System.Drawing.Point(123, 3)
        Me.Cmb_Chofer.Name = "Cmb_Chofer"
        Me.Cmb_Chofer.Size = New System.Drawing.Size(298, 22)
        Me.Cmb_Chofer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Chofer.TabIndex = 103
        '
        'Btn_Chofer
        '
        Me.Btn_Chofer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Chofer.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Chofer.Image = CType(resources.GetObject("Btn_Chofer.Image"), System.Drawing.Image)
        Me.Btn_Chofer.Location = New System.Drawing.Point(427, 3)
        Me.Btn_Chofer.Name = "Btn_Chofer"
        Me.Btn_Chofer.Size = New System.Drawing.Size(27, 20)
        Me.Btn_Chofer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Chofer.TabIndex = 69
        Me.Btn_Chofer.Tooltip = "Mantención de tabla de choferes de la empresa"
        '
        'Lbl_Fecha
        '
        Me.Lbl_Fecha.AutoSize = True
        Me.Lbl_Fecha.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Fecha.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Fecha.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Fecha.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Fecha.Location = New System.Drawing.Point(3, 29)
        Me.Lbl_Fecha.Name = "Lbl_Fecha"
        Me.Lbl_Fecha.Size = New System.Drawing.Size(72, 20)
        Me.Lbl_Fecha.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Lbl_Fecha.TabIndex = 66
        Me.Lbl_Fecha.Text = "Fecha salida"
        '
        'Lbl_Nro_Motor
        '
        Me.Lbl_Nro_Motor.AutoSize = True
        Me.Lbl_Nro_Motor.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Nro_Motor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Nro_Motor.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Nro_Motor.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Nro_Motor.Location = New System.Drawing.Point(3, 55)
        Me.Lbl_Nro_Motor.Name = "Lbl_Nro_Motor"
        Me.Lbl_Nro_Motor.Size = New System.Drawing.Size(85, 20)
        Me.Lbl_Nro_Motor.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Lbl_Nro_Motor.TabIndex = 69
        Me.Lbl_Nro_Motor.Text = "Hora de salida"
        '
        'Dtp_Fecha_Salida
        '
        '
        '
        '
        Me.Dtp_Fecha_Salida.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Salida.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Salida.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Salida.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Salida.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Salida.Format = DevComponents.Editors.eDateTimePickerFormat.[Long]
        Me.Dtp_Fecha_Salida.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Salida.Location = New System.Drawing.Point(123, 29)
        '
        '
        '
        Me.Dtp_Fecha_Salida.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Salida.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Salida.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Salida.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Salida.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Salida.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Salida.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Salida.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Salida.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Salida.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Salida.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Salida.MonthCalendar.DisplayMonth = New Date(2016, 11, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Salida.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Salida.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Salida.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Salida.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Salida.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Salida.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Salida.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Salida.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Salida.Name = "Dtp_Fecha_Salida"
        Me.Dtp_Fecha_Salida.Size = New System.Drawing.Size(206, 22)
        Me.Dtp_Fecha_Salida.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Salida.TabIndex = 112
        Me.Dtp_Fecha_Salida.Value = New Date(2016, 11, 7, 17, 33, 4, 0)
        '
        'Lbl_Chasis
        '
        Me.Lbl_Chasis.AutoSize = True
        Me.Lbl_Chasis.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Chasis.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Chasis.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Chasis.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Chasis.Location = New System.Drawing.Point(3, 81)
        Me.Lbl_Chasis.Name = "Lbl_Chasis"
        Me.Lbl_Chasis.Size = New System.Drawing.Size(46, 20)
        Me.Lbl_Chasis.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Lbl_Chasis.TabIndex = 48
        Me.Lbl_Chasis.Text = "Entidad"
        '
        'Txt_Razon_Entidad
        '
        Me.Txt_Razon_Entidad.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Razon_Entidad.Border.Class = "TextBoxBorder"
        Me.Txt_Razon_Entidad.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Razon_Entidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Razon_Entidad.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Razon_Entidad.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Razon_Entidad.FocusHighlightEnabled = True
        Me.Txt_Razon_Entidad.ForeColor = System.Drawing.Color.Black
        Me.Txt_Razon_Entidad.Location = New System.Drawing.Point(123, 81)
        Me.Txt_Razon_Entidad.MaxLength = 50
        Me.Txt_Razon_Entidad.Name = "Txt_Razon_Entidad"
        Me.Txt_Razon_Entidad.ReadOnly = True
        Me.Txt_Razon_Entidad.Size = New System.Drawing.Size(298, 22)
        Me.Txt_Razon_Entidad.TabIndex = 102
        '
        'LabelX22
        '
        Me.LabelX22.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX22.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX22.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX22.ForeColor = System.Drawing.Color.Black
        Me.LabelX22.Location = New System.Drawing.Point(3, 107)
        Me.LabelX22.Name = "LabelX22"
        Me.LabelX22.Size = New System.Drawing.Size(89, 20)
        Me.LabelX22.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX22.TabIndex = 107
        Me.LabelX22.Text = "País"
        '
        'LabelX23
        '
        Me.LabelX23.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX23.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX23.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX23.ForeColor = System.Drawing.Color.Black
        Me.LabelX23.Location = New System.Drawing.Point(3, 133)
        Me.LabelX23.Name = "LabelX23"
        Me.LabelX23.Size = New System.Drawing.Size(89, 20)
        Me.LabelX23.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX23.TabIndex = 108
        Me.LabelX23.Text = "Ciudad"
        '
        'LabelX24
        '
        Me.LabelX24.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX24.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX24.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX24.ForeColor = System.Drawing.Color.Black
        Me.LabelX24.Location = New System.Drawing.Point(3, 159)
        Me.LabelX24.Name = "LabelX24"
        Me.LabelX24.Size = New System.Drawing.Size(89, 20)
        Me.LabelX24.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX24.TabIndex = 109
        Me.LabelX24.Text = "Comuna"
        '
        'Lbl_Color
        '
        Me.Lbl_Color.AutoSize = True
        Me.Lbl_Color.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Color.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Color.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Color.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Color.Location = New System.Drawing.Point(3, 185)
        Me.Lbl_Color.Name = "Lbl_Color"
        Me.Lbl_Color.Size = New System.Drawing.Size(56, 20)
        Me.Lbl_Color.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Lbl_Color.TabIndex = 108
        Me.Lbl_Color.Text = "Dirección"
        '
        'Cmb_Pais
        '
        Me.Cmb_Pais.DisplayMember = "Text"
        Me.Cmb_Pais.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Pais.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Cmb_Pais.FocusHighlightEnabled = True
        Me.Cmb_Pais.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Pais.ItemHeight = 16
        Me.Cmb_Pais.Location = New System.Drawing.Point(123, 107)
        Me.Cmb_Pais.Name = "Cmb_Pais"
        Me.Cmb_Pais.Size = New System.Drawing.Size(140, 22)
        Me.Cmb_Pais.TabIndex = 104
        Me.Cmb_Pais.WatermarkText = "País"
        '
        'Cmb_Ciudad
        '
        Me.Cmb_Ciudad.DisplayMember = "Text"
        Me.Cmb_Ciudad.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Ciudad.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Cmb_Ciudad.FocusHighlightEnabled = True
        Me.Cmb_Ciudad.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Ciudad.ItemHeight = 16
        Me.Cmb_Ciudad.Location = New System.Drawing.Point(123, 133)
        Me.Cmb_Ciudad.Name = "Cmb_Ciudad"
        Me.Cmb_Ciudad.Size = New System.Drawing.Size(183, 22)
        Me.Cmb_Ciudad.TabIndex = 105
        Me.Cmb_Ciudad.WatermarkText = "Ciudad - Región"
        '
        'Cmb_Comuna
        '
        Me.Cmb_Comuna.DisplayMember = "Text"
        Me.Cmb_Comuna.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Comuna.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Cmb_Comuna.FocusHighlightEnabled = True
        Me.Cmb_Comuna.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Comuna.ItemHeight = 16
        Me.Cmb_Comuna.Location = New System.Drawing.Point(123, 159)
        Me.Cmb_Comuna.Name = "Cmb_Comuna"
        Me.Cmb_Comuna.Size = New System.Drawing.Size(183, 22)
        Me.Cmb_Comuna.TabIndex = 106
        Me.Cmb_Comuna.WatermarkText = "Comuna"
        '
        'Txt_Direccion
        '
        Me.Txt_Direccion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Direccion.Border.Class = "TextBoxBorder"
        Me.Txt_Direccion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Direccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Direccion.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Direccion.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Direccion.FocusHighlightEnabled = True
        Me.Txt_Direccion.ForeColor = System.Drawing.Color.Black
        Me.Txt_Direccion.Location = New System.Drawing.Point(123, 185)
        Me.Txt_Direccion.MaxLength = 50
        Me.Txt_Direccion.Name = "Txt_Direccion"
        Me.Txt_Direccion.Size = New System.Drawing.Size(298, 22)
        Me.Txt_Direccion.TabIndex = 108
        '
        'Btn_Entidad
        '
        Me.Btn_Entidad.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Entidad.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Entidad.Image = CType(resources.GetObject("Btn_Entidad.Image"), System.Drawing.Image)
        Me.Btn_Entidad.Location = New System.Drawing.Point(460, 81)
        Me.Btn_Entidad.Name = "Btn_Entidad"
        Me.Btn_Entidad.Size = New System.Drawing.Size(28, 20)
        Me.Btn_Entidad.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Entidad.TabIndex = 102
        Me.Btn_Entidad.Tooltip = "Buscar Cliente o Proveedor"
        '
        'Btn_Limpiar_Entidad
        '
        Me.Btn_Limpiar_Entidad.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Limpiar_Entidad.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Limpiar_Entidad.Enabled = False
        Me.Btn_Limpiar_Entidad.Image = CType(resources.GetObject("Btn_Limpiar_Entidad.Image"), System.Drawing.Image)
        Me.Btn_Limpiar_Entidad.Location = New System.Drawing.Point(427, 81)
        Me.Btn_Limpiar_Entidad.Name = "Btn_Limpiar_Entidad"
        Me.Btn_Limpiar_Entidad.Size = New System.Drawing.Size(27, 20)
        Me.Btn_Limpiar_Entidad.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Limpiar_Entidad.TabIndex = 103
        Me.Btn_Limpiar_Entidad.Tooltip = "Limpiar Cliente / Proveedor"
        '
        'Lbl_Kilometraje
        '
        Me.Lbl_Kilometraje.AutoSize = True
        Me.Lbl_Kilometraje.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Kilometraje.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Kilometraje.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Kilometraje.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Kilometraje.Location = New System.Drawing.Point(3, 237)
        Me.Lbl_Kilometraje.Name = "Lbl_Kilometraje"
        Me.Lbl_Kilometraje.Size = New System.Drawing.Size(104, 20)
        Me.Lbl_Kilometraje.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Lbl_Kilometraje.TabIndex = 109
        Me.Lbl_Kilometraje.Text = "Kilometraje salida"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Cerrar_CRV, Me.Btn_Grabar, Me.Btn_Editar, Me.Btn_Anular, Me.Btn_Cancelar, Me.Btn_Imprimir_CRV, Me.Btn_Salir})
        Me.Bar2.Location = New System.Drawing.Point(0, 483)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(527, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 100
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Cerrar_CRV
        '
        Me.Btn_Cerrar_CRV.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Cerrar_CRV.FontBold = True
        Me.Btn_Cerrar_CRV.ForeColor = System.Drawing.Color.Black
        Me.Btn_Cerrar_CRV.Image = CType(resources.GetObject("Btn_Cerrar_CRV.Image"), System.Drawing.Image)
        Me.Btn_Cerrar_CRV.Name = "Btn_Cerrar_CRV"
        Me.Btn_Cerrar_CRV.Text = "Cerrar C.R.V."
        Me.Btn_Cerrar_CRV.Tooltip = "Imprimir C.R.V."
        Me.Btn_Cerrar_CRV.Visible = False
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Tooltip = "Grabar "
        '
        'Btn_Editar
        '
        Me.Btn_Editar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Editar.FontBold = True
        Me.Btn_Editar.ForeColor = System.Drawing.Color.Red
        Me.Btn_Editar.Image = CType(resources.GetObject("Btn_Editar.Image"), System.Drawing.Image)
        Me.Btn_Editar.Name = "Btn_Editar"
        Me.Btn_Editar.Tooltip = "Editar "
        Me.Btn_Editar.Visible = False
        '
        'Btn_Anular
        '
        Me.Btn_Anular.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Anular.ForeColor = System.Drawing.Color.Black
        Me.Btn_Anular.Image = CType(resources.GetObject("Btn_Anular.Image"), System.Drawing.Image)
        Me.Btn_Anular.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Anular.Name = "Btn_Anular"
        Me.Btn_Anular.Tooltip = "Anular C.R.V."
        Me.Btn_Anular.Visible = False
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Cancelar.FontBold = True
        Me.Btn_Cancelar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Cancelar.Image = CType(resources.GetObject("Btn_Cancelar.Image"), System.Drawing.Image)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Text = "Cancelar edición"
        Me.Btn_Cancelar.Visible = False
        '
        'Btn_Imprimir_CRV
        '
        Me.Btn_Imprimir_CRV.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Imprimir_CRV.FontBold = True
        Me.Btn_Imprimir_CRV.ForeColor = System.Drawing.Color.Black
        Me.Btn_Imprimir_CRV.Image = CType(resources.GetObject("Btn_Imprimir_CRV.Image"), System.Drawing.Image)
        Me.Btn_Imprimir_CRV.Name = "Btn_Imprimir_CRV"
        Me.Btn_Imprimir_CRV.Tooltip = "Imprimir C.R.V."
        Me.Btn_Imprimir_CRV.Visible = False
        '
        'Btn_Salir
        '
        Me.Btn_Salir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Salir.ForeColor = System.Drawing.Color.Black
        Me.Btn_Salir.Image = CType(resources.GetObject("Btn_Salir.Image"), System.Drawing.Image)
        Me.Btn_Salir.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Salir.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Tooltip = "Salir"
        '
        'Imagenes_32x32
        '
        Me.Imagenes_32x32.ImageStream = CType(resources.GetObject("Imagenes_32x32.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagenes_32x32.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagenes_32x32.Images.SetKeyName(0, "warning.png")
        '
        'Frm_CRV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(527, 524)
        Me.ControlBox = False
        Me.Controls.Add(Me.Grupo_Vehiculo)
        Me.Controls.Add(Me.Bar2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "Frm_CRV"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "C.R.V. CONTROL RUTA DE VEHICULOS"
        Me.Grupo_Vehiculo.ResumeLayout(False)
        Me.Layaut_Cierre.ResumeLayout(False)
        Me.Layaut_Cierre.PerformLayout()
        CType(Me.Dtp_Hora_Llegada, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Input_Kilometro_Llegada, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_Fecha_Llegada, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Layaut_CRV_1.ResumeLayout(False)
        Me.Layaut_CRV_1.PerformLayout()
        Me.Layaut_CRV_2.ResumeLayout(False)
        Me.Layaut_CRV_2.PerformLayout()
        CType(Me.Dtp_Hora_Salida, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Input_Kilometro_Salida, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_Fecha_Salida, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Grupo_Vehiculo As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Layaut_CRV_1 As System.Windows.Forms.TableLayoutPanel
    Public WithEvents Txt_Patente As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Lbl_Nombre_Vehiculo As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Patente As DevComponents.DotNetBar.LabelX
    Friend WithEvents Layaut_CRV_2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Cmb_Chofer As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Lbl_Chofer As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Chofer As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Lbl_Kilometraje As DevComponents.DotNetBar.LabelX
    Private WithEvents Input_Kilometro_Salida As DevComponents.Editors.IntegerInput
    Friend WithEvents Lbl_Fecha As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Nro_Motor As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Chasis As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Color As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Editar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Anular As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Cancelar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Salir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Cmb_Nuevo_Vehiculo As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Dtp_Hora_Salida As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Dtp_Fecha_Salida As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Btn_Entidad As DevComponents.DotNetBar.ButtonX
    Public WithEvents Txt_Razon_Entidad As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX22 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX23 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX24 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Cmb_Pais As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Cmb_Ciudad As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Cmb_Comuna As DevComponents.DotNetBar.Controls.ComboBoxEx
    Public WithEvents Txt_Direccion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Dtp_Hora_Llegada As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dtp_Fecha_Llegada As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Private WithEvents Input_Kilometro_Llegada As DevComponents.Editors.IntegerInput
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Public WithEvents Btn_Imprimir_CRV As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Vehiculos As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Limpiar_Entidad As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Editar_Km_Llegada As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Editar_Km_Salida As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Imagenes_32x32 As System.Windows.Forms.ImageList
    Friend WithEvents Btn_Fecha_Actual As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Hora_Actual As DevComponents.DotNetBar.ButtonX
    Public WithEvents Btn_Cerrar_CRV As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Layaut_Cierre As System.Windows.Forms.TableLayoutPanel
End Class
