<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Ver_Documento_Observaciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Ver_Documento_Observaciones))
        Me.GroupPanel13 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Btn_Buscar_Placa_Patente = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Buscar_Retirador = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Editar_Fecha = New DevComponents.DotNetBar.ButtonX()
        Me.Dtp_Fecha_Valuta = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Motivo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Placa_Patente = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Retirador_Mercaderia = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Orden_de_compra = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Observaciones = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_Fecha_Entrega_Recepcion = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Txt_Forma_de_pago = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Editar_Observaciones = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Observaciones_adicionales = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Referencias_DTE = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel13.SuspendLayout()
        CType(Me.Dtp_Fecha_Valuta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_Fecha_Entrega_Recepcion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel13
        '
        Me.GroupPanel13.BackColor = System.Drawing.Color.White
        Me.GroupPanel13.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel13.Controls.Add(Me.Btn_Buscar_Placa_Patente)
        Me.GroupPanel13.Controls.Add(Me.Btn_Buscar_Retirador)
        Me.GroupPanel13.Controls.Add(Me.Btn_Editar_Fecha)
        Me.GroupPanel13.Controls.Add(Me.Dtp_Fecha_Valuta)
        Me.GroupPanel13.Controls.Add(Me.LabelX7)
        Me.GroupPanel13.Controls.Add(Me.Txt_Motivo)
        Me.GroupPanel13.Controls.Add(Me.LabelX6)
        Me.GroupPanel13.Controls.Add(Me.Txt_Placa_Patente)
        Me.GroupPanel13.Controls.Add(Me.LabelX3)
        Me.GroupPanel13.Controls.Add(Me.Txt_Retirador_Mercaderia)
        Me.GroupPanel13.Controls.Add(Me.LabelX2)
        Me.GroupPanel13.Controls.Add(Me.Txt_Orden_de_compra)
        Me.GroupPanel13.Controls.Add(Me.Txt_Observaciones)
        Me.GroupPanel13.Controls.Add(Me.LabelX1)
        Me.GroupPanel13.Controls.Add(Me.Dtp_Fecha_Entrega_Recepcion)
        Me.GroupPanel13.Controls.Add(Me.Txt_Forma_de_pago)
        Me.GroupPanel13.Controls.Add(Me.LabelX5)
        Me.GroupPanel13.Controls.Add(Me.LabelX4)
        Me.GroupPanel13.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel13.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.GroupPanel13.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel13.Name = "GroupPanel13"
        Me.GroupPanel13.Size = New System.Drawing.Size(544, 228)
        '
        '
        '
        Me.GroupPanel13.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel13.Style.BackColorGradientAngle = 90
        Me.GroupPanel13.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel13.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel13.Style.BorderBottomWidth = 1
        Me.GroupPanel13.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel13.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel13.Style.BorderLeftWidth = 1
        Me.GroupPanel13.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel13.Style.BorderRightWidth = 1
        Me.GroupPanel13.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel13.Style.BorderTopWidth = 1
        Me.GroupPanel13.Style.CornerDiameter = 4
        Me.GroupPanel13.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel13.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel13.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel13.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel13.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel13.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel13.TabIndex = 80
        '
        'Btn_Buscar_Placa_Patente
        '
        Me.Btn_Buscar_Placa_Patente.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Buscar_Placa_Patente.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Buscar_Placa_Patente.Enabled = False
        Me.Btn_Buscar_Placa_Patente.Image = CType(resources.GetObject("Btn_Buscar_Placa_Patente.Image"), System.Drawing.Image)
        Me.Btn_Buscar_Placa_Patente.ImageAlt = CType(resources.GetObject("Btn_Buscar_Placa_Patente.ImageAlt"), System.Drawing.Image)
        Me.Btn_Buscar_Placa_Patente.Location = New System.Drawing.Point(131, 166)
        Me.Btn_Buscar_Placa_Patente.Name = "Btn_Buscar_Placa_Patente"
        Me.Btn_Buscar_Placa_Patente.Size = New System.Drawing.Size(25, 23)
        Me.Btn_Buscar_Placa_Patente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Buscar_Placa_Patente.TabIndex = 97
        Me.Btn_Buscar_Placa_Patente.Visible = False
        '
        'Btn_Buscar_Retirador
        '
        Me.Btn_Buscar_Retirador.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Buscar_Retirador.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Buscar_Retirador.Enabled = False
        Me.Btn_Buscar_Retirador.Image = CType(resources.GetObject("Btn_Buscar_Retirador.Image"), System.Drawing.Image)
        Me.Btn_Buscar_Retirador.ImageAlt = CType(resources.GetObject("Btn_Buscar_Retirador.ImageAlt"), System.Drawing.Image)
        Me.Btn_Buscar_Retirador.Location = New System.Drawing.Point(131, 138)
        Me.Btn_Buscar_Retirador.Name = "Btn_Buscar_Retirador"
        Me.Btn_Buscar_Retirador.Size = New System.Drawing.Size(25, 23)
        Me.Btn_Buscar_Retirador.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Buscar_Retirador.TabIndex = 96
        Me.Btn_Buscar_Retirador.Visible = False
        '
        'Btn_Editar_Fecha
        '
        Me.Btn_Editar_Fecha.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Editar_Fecha.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Editar_Fecha.Location = New System.Drawing.Point(242, 5)
        Me.Btn_Editar_Fecha.Name = "Btn_Editar_Fecha"
        Me.Btn_Editar_Fecha.Size = New System.Drawing.Size(75, 22)
        Me.Btn_Editar_Fecha.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Editar_Fecha.TabIndex = 95
        Me.Btn_Editar_Fecha.Text = "Editar fecha"
        '
        'Dtp_Fecha_Valuta
        '
        Me.Dtp_Fecha_Valuta.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_Fecha_Valuta.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Valuta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Valuta.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Valuta.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Valuta.Enabled = False
        Me.Dtp_Fecha_Valuta.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Valuta.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Valuta.Location = New System.Drawing.Point(141, 239)
        '
        '
        '
        Me.Dtp_Fecha_Valuta.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Valuta.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Valuta.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Valuta.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Valuta.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Valuta.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Valuta.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Valuta.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Valuta.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Valuta.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Valuta.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Valuta.MonthCalendar.DisplayMonth = New Date(2014, 10, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Valuta.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Valuta.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Valuta.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Valuta.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Valuta.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Valuta.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Valuta.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Valuta.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Valuta.Name = "Dtp_Fecha_Valuta"
        Me.Dtp_Fecha_Valuta.Size = New System.Drawing.Size(84, 22)
        Me.Dtp_Fecha_Valuta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Valuta.TabIndex = 92
        Me.Dtp_Fecha_Valuta.Value = New Date(2014, 10, 1, 18, 45, 8, 0)
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.ForeColor = System.Drawing.Color.Black
        Me.LabelX7.Location = New System.Drawing.Point(3, 239)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(76, 23)
        Me.LabelX7.TabIndex = 93
        Me.LabelX7.Text = "Fecha valuta"
        '
        'Txt_Motivo
        '
        Me.Txt_Motivo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Motivo.Border.Class = "TextBoxBorder"
        Me.Txt_Motivo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Motivo.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Motivo.Enabled = False
        Me.Txt_Motivo.ForeColor = System.Drawing.Color.Black
        Me.Txt_Motivo.Location = New System.Drawing.Point(159, 195)
        Me.Txt_Motivo.Name = "Txt_Motivo"
        Me.Txt_Motivo.PreventEnterBeep = True
        Me.Txt_Motivo.ReadOnly = True
        Me.Txt_Motivo.Size = New System.Drawing.Size(371, 22)
        Me.Txt_Motivo.TabIndex = 91
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(3, 195)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(99, 23)
        Me.LabelX6.TabIndex = 90
        Me.LabelX6.Text = "Motivo (si existe)"
        '
        'Txt_Placa_Patente
        '
        Me.Txt_Placa_Patente.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Placa_Patente.Border.Class = "TextBoxBorder"
        Me.Txt_Placa_Patente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Placa_Patente.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Placa_Patente.Enabled = False
        Me.Txt_Placa_Patente.ForeColor = System.Drawing.Color.Black
        Me.Txt_Placa_Patente.Location = New System.Drawing.Point(159, 167)
        Me.Txt_Placa_Patente.Name = "Txt_Placa_Patente"
        Me.Txt_Placa_Patente.PreventEnterBeep = True
        Me.Txt_Placa_Patente.ReadOnly = True
        Me.Txt_Placa_Patente.Size = New System.Drawing.Size(148, 22)
        Me.Txt_Placa_Patente.TabIndex = 89
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(3, 167)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(76, 23)
        Me.LabelX3.TabIndex = 88
        Me.LabelX3.Text = "Placa patente"
        '
        'Txt_Retirador_Mercaderia
        '
        Me.Txt_Retirador_Mercaderia.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Retirador_Mercaderia.Border.Class = "TextBoxBorder"
        Me.Txt_Retirador_Mercaderia.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Retirador_Mercaderia.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Retirador_Mercaderia.Enabled = False
        Me.Txt_Retirador_Mercaderia.ForeColor = System.Drawing.Color.Black
        Me.Txt_Retirador_Mercaderia.Location = New System.Drawing.Point(159, 139)
        Me.Txt_Retirador_Mercaderia.Name = "Txt_Retirador_Mercaderia"
        Me.Txt_Retirador_Mercaderia.PreventEnterBeep = True
        Me.Txt_Retirador_Mercaderia.ReadOnly = True
        Me.Txt_Retirador_Mercaderia.Size = New System.Drawing.Size(371, 22)
        Me.Txt_Retirador_Mercaderia.TabIndex = 87
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 139)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(132, 23)
        Me.LabelX2.TabIndex = 86
        Me.LabelX2.Text = "Retirador de mercadería"
        '
        'Txt_Orden_de_compra
        '
        Me.Txt_Orden_de_compra.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Orden_de_compra.Border.Class = "TextBoxBorder"
        Me.Txt_Orden_de_compra.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Orden_de_compra.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Orden_de_compra.Enabled = False
        Me.Txt_Orden_de_compra.ForeColor = System.Drawing.Color.Black
        Me.Txt_Orden_de_compra.Location = New System.Drawing.Point(411, 111)
        Me.Txt_Orden_de_compra.MaxLength = 20
        Me.Txt_Orden_de_compra.Name = "Txt_Orden_de_compra"
        Me.Txt_Orden_de_compra.PreventEnterBeep = True
        Me.Txt_Orden_de_compra.ReadOnly = True
        Me.Txt_Orden_de_compra.Size = New System.Drawing.Size(119, 22)
        Me.Txt_Orden_de_compra.TabIndex = 3
        '
        'Txt_Observaciones
        '
        Me.Txt_Observaciones.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Observaciones.Border.Class = "TextBoxBorder"
        Me.Txt_Observaciones.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Observaciones.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Observaciones.Enabled = False
        Me.Txt_Observaciones.ForeColor = System.Drawing.Color.Black
        Me.Txt_Observaciones.Location = New System.Drawing.Point(3, 32)
        Me.Txt_Observaciones.MaxLength = 250
        Me.Txt_Observaciones.Multiline = True
        Me.Txt_Observaciones.Name = "Txt_Observaciones"
        Me.Txt_Observaciones.PreventEnterBeep = True
        Me.Txt_Observaciones.ReadOnly = True
        Me.Txt_Observaciones.Size = New System.Drawing.Size(527, 73)
        Me.Txt_Observaciones.TabIndex = 0
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(316, 110)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(89, 23)
        Me.LabelX1.TabIndex = 2
        Me.LabelX1.Text = "Orden de compra"
        '
        'Dtp_Fecha_Entrega_Recepcion
        '
        Me.Dtp_Fecha_Entrega_Recepcion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_Fecha_Entrega_Recepcion.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Entrega_Recepcion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Entrega_Recepcion.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Entrega_Recepcion.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Entrega_Recepcion.Enabled = False
        Me.Dtp_Fecha_Entrega_Recepcion.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Entrega_Recepcion.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Entrega_Recepcion.Location = New System.Drawing.Point(152, 4)
        '
        '
        '
        Me.Dtp_Fecha_Entrega_Recepcion.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Entrega_Recepcion.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Entrega_Recepcion.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Entrega_Recepcion.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Entrega_Recepcion.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Entrega_Recepcion.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Entrega_Recepcion.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Entrega_Recepcion.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Entrega_Recepcion.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Entrega_Recepcion.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Entrega_Recepcion.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Entrega_Recepcion.MonthCalendar.DisplayMonth = New Date(2014, 10, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Entrega_Recepcion.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Entrega_Recepcion.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Entrega_Recepcion.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Entrega_Recepcion.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Entrega_Recepcion.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Entrega_Recepcion.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Entrega_Recepcion.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Entrega_Recepcion.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Entrega_Recepcion.Name = "Dtp_Fecha_Entrega_Recepcion"
        Me.Dtp_Fecha_Entrega_Recepcion.Size = New System.Drawing.Size(84, 22)
        Me.Dtp_Fecha_Entrega_Recepcion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Entrega_Recepcion.TabIndex = 84
        Me.Dtp_Fecha_Entrega_Recepcion.Value = New Date(2014, 10, 1, 18, 45, 8, 0)
        '
        'Txt_Forma_de_pago
        '
        Me.Txt_Forma_de_pago.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Forma_de_pago.Border.Class = "TextBoxBorder"
        Me.Txt_Forma_de_pago.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Forma_de_pago.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Forma_de_pago.Enabled = False
        Me.Txt_Forma_de_pago.ForeColor = System.Drawing.Color.Black
        Me.Txt_Forma_de_pago.Location = New System.Drawing.Point(85, 111)
        Me.Txt_Forma_de_pago.MaxLength = 40
        Me.Txt_Forma_de_pago.Name = "Txt_Forma_de_pago"
        Me.Txt_Forma_de_pago.PreventEnterBeep = True
        Me.Txt_Forma_de_pago.ReadOnly = True
        Me.Txt_Forma_de_pago.Size = New System.Drawing.Size(225, 22)
        Me.Txt_Forma_de_pago.TabIndex = 1
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(3, 4)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(166, 23)
        Me.LabelX5.TabIndex = 85
        Me.LabelX5.Text = "Fecha de entrega / recepción"
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(3, 111)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(76, 23)
        Me.LabelX4.TabIndex = 0
        Me.LabelX4.Text = "Forma de pago"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar, Me.Btn_Editar_Observaciones, Me.Btn_Observaciones_adicionales, Me.Btn_Referencias_DTE})
        Me.Bar2.Location = New System.Drawing.Point(0, 255)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(568, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 81
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.ImageAlt = CType(resources.GetObject("Btn_Grabar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Tooltip = "Grabar observaciones"
        Me.Btn_Grabar.Visible = False
        '
        'Btn_Editar_Observaciones
        '
        Me.Btn_Editar_Observaciones.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Editar_Observaciones.ForeColor = System.Drawing.Color.Black
        Me.Btn_Editar_Observaciones.Image = CType(resources.GetObject("Btn_Editar_Observaciones.Image"), System.Drawing.Image)
        Me.Btn_Editar_Observaciones.ImageAlt = CType(resources.GetObject("Btn_Editar_Observaciones.ImageAlt"), System.Drawing.Image)
        Me.Btn_Editar_Observaciones.Name = "Btn_Editar_Observaciones"
        Me.Btn_Editar_Observaciones.Tooltip = "Editar observaciones"
        '
        'Btn_Observaciones_adicionales
        '
        Me.Btn_Observaciones_adicionales.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Observaciones_adicionales.ForeColor = System.Drawing.Color.Black
        Me.Btn_Observaciones_adicionales.Image = CType(resources.GetObject("Btn_Observaciones_adicionales.Image"), System.Drawing.Image)
        Me.Btn_Observaciones_adicionales.ImageAlt = CType(resources.GetObject("Btn_Observaciones_adicionales.ImageAlt"), System.Drawing.Image)
        Me.Btn_Observaciones_adicionales.Name = "Btn_Observaciones_adicionales"
        Me.Btn_Observaciones_adicionales.Tooltip = "Observaciones adicionales"
        '
        'Btn_Referencias_DTE
        '
        Me.Btn_Referencias_DTE.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Referencias_DTE.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Btn_Referencias_DTE.Image = CType(resources.GetObject("Btn_Referencias_DTE.Image"), System.Drawing.Image)
        Me.Btn_Referencias_DTE.ImageAlt = CType(resources.GetObject("Btn_Referencias_DTE.ImageAlt"), System.Drawing.Image)
        Me.Btn_Referencias_DTE.Name = "Btn_Referencias_DTE"
        Me.Btn_Referencias_DTE.Text = "Referencias DTE"
        Me.Btn_Referencias_DTE.Tooltip = "Solo trasladar observaciones"
        '
        'Frm_Ver_Documento_Observaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(568, 296)
        Me.Controls.Add(Me.GroupPanel13)
        Me.Controls.Add(Me.Bar2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Ver_Documento_Observaciones"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        Me.GroupPanel13.ResumeLayout(False)
        CType(Me.Dtp_Fecha_Valuta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_Fecha_Entrega_Recepcion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel13 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Txt_Orden_de_compra As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Observaciones As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Public WithEvents Dtp_Fecha_Entrega_Recepcion As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Txt_Forma_de_pago As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Public WithEvents Dtp_Fecha_Valuta As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Motivo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Placa_Patente As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Retirador_Mercaderia As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Public WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Editar_Observaciones As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Observaciones_adicionales As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Editar_Fecha As DevComponents.DotNetBar.ButtonX
    Public WithEvents Btn_Referencias_DTE As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Buscar_Retirador As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Buscar_Placa_Patente As DevComponents.DotNetBar.ButtonX
End Class
