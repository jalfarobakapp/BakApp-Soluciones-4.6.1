<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Tickets_IngProducto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Tickets_IngProducto))
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Archivos_Adjuntos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Eliminar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_GestProductos = New DevComponents.DotNetBar.ButtonItem()
        Me.Lbl_Cantidad = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_StfiEnBodega = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Bodega = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Producto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Lbl_Producto = New DevComponents.DotNetBar.LabelX()
        Me.Cmb_UdMedida = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Lbl_UdMedida = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_FechaRev = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_FechaRev = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Txt_Diferencia = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_HoraRev = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_HoraRev = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Txt_Ubicacion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Input_StfiEnBodega = New DevComponents.Editors.IntegerInput()
        Me.Input_Cantidad = New DevComponents.Editors.IntegerInput()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_FechaRev, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_HoraRev, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Input_StfiEnBodega, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Input_Cantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar, Me.Btn_Archivos_Adjuntos, Me.Btn_Eliminar, Me.Btn_GestProductos})
        Me.Bar2.Location = New System.Drawing.Point(0, 244)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(536, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 165
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
        Me.Btn_Grabar.Tooltip = "Grabar"
        '
        'Btn_Archivos_Adjuntos
        '
        Me.Btn_Archivos_Adjuntos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Archivos_Adjuntos.ForeColor = System.Drawing.Color.Black
        Me.Btn_Archivos_Adjuntos.Image = CType(resources.GetObject("Btn_Archivos_Adjuntos.Image"), System.Drawing.Image)
        Me.Btn_Archivos_Adjuntos.ImageAlt = CType(resources.GetObject("Btn_Archivos_Adjuntos.ImageAlt"), System.Drawing.Image)
        Me.Btn_Archivos_Adjuntos.Name = "Btn_Archivos_Adjuntos"
        Me.Btn_Archivos_Adjuntos.Tooltip = "Adjuntar archivos"
        Me.Btn_Archivos_Adjuntos.Visible = False
        '
        'Btn_Eliminar
        '
        Me.Btn_Eliminar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Eliminar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Eliminar.Image = CType(resources.GetObject("Btn_Eliminar.Image"), System.Drawing.Image)
        Me.Btn_Eliminar.ImageAlt = CType(resources.GetObject("Btn_Eliminar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Eliminar.Name = "Btn_Eliminar"
        Me.Btn_Eliminar.Tooltip = "Anular Ticket"
        Me.Btn_Eliminar.Visible = False
        '
        'Btn_GestProductos
        '
        Me.Btn_GestProductos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_GestProductos.ForeColor = System.Drawing.Color.Black
        Me.Btn_GestProductos.Image = CType(resources.GetObject("Btn_GestProductos.Image"), System.Drawing.Image)
        Me.Btn_GestProductos.ImageAlt = CType(resources.GetObject("Btn_GestProductos.ImageAlt"), System.Drawing.Image)
        Me.Btn_GestProductos.Name = "Btn_GestProductos"
        Me.Btn_GestProductos.Tooltip = "Adjuntar archivos"
        Me.Btn_GestProductos.Visible = False
        '
        'Lbl_Cantidad
        '
        Me.Lbl_Cantidad.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Cantidad.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Cantidad.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Cantidad.Location = New System.Drawing.Point(11, 152)
        Me.Lbl_Cantidad.Name = "Lbl_Cantidad"
        Me.Lbl_Cantidad.Size = New System.Drawing.Size(89, 23)
        Me.Lbl_Cantidad.TabIndex = 173
        Me.Lbl_Cantidad.Text = "Stock f�sico"
        '
        'Lbl_StfiEnBodega
        '
        Me.Lbl_StfiEnBodega.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_StfiEnBodega.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_StfiEnBodega.ForeColor = System.Drawing.Color.Black
        Me.Lbl_StfiEnBodega.Location = New System.Drawing.Point(11, 124)
        Me.Lbl_StfiEnBodega.Name = "Lbl_StfiEnBodega"
        Me.Lbl_StfiEnBodega.Size = New System.Drawing.Size(89, 23)
        Me.Lbl_StfiEnBodega.TabIndex = 171
        Me.Lbl_StfiEnBodega.Text = "Stock sistema"
        '
        'Txt_Bodega
        '
        Me.Txt_Bodega.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Bodega.Border.Class = "TextBoxBorder"
        Me.Txt_Bodega.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Bodega.ButtonCustom.Image = CType(resources.GetObject("Txt_Bodega.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Bodega.ButtonCustom.Visible = True
        Me.Txt_Bodega.ButtonCustom2.Image = CType(resources.GetObject("Txt_Bodega.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Bodega.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Bodega.ForeColor = System.Drawing.Color.Black
        Me.Txt_Bodega.Location = New System.Drawing.Point(107, 41)
        Me.Txt_Bodega.Name = "Txt_Bodega"
        Me.Txt_Bodega.PreventEnterBeep = True
        Me.Txt_Bodega.ReadOnly = True
        Me.Txt_Bodega.Size = New System.Drawing.Size(419, 22)
        Me.Txt_Bodega.TabIndex = 1
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.ForeColor = System.Drawing.Color.Black
        Me.LabelX7.Location = New System.Drawing.Point(12, 41)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(80, 23)
        Me.LabelX7.TabIndex = 169
        Me.LabelX7.Text = "Bodega"
        '
        'Txt_Producto
        '
        Me.Txt_Producto.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Producto.Border.Class = "TextBoxBorder"
        Me.Txt_Producto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Producto.ButtonCustom.Image = CType(resources.GetObject("Txt_Producto.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Producto.ButtonCustom.Visible = True
        Me.Txt_Producto.ButtonCustom2.Image = CType(resources.GetObject("Txt_Producto.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Producto.ButtonCustom2.Visible = True
        Me.Txt_Producto.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Producto.Enabled = False
        Me.Txt_Producto.ForeColor = System.Drawing.Color.Black
        Me.Txt_Producto.Location = New System.Drawing.Point(107, 13)
        Me.Txt_Producto.Name = "Txt_Producto"
        Me.Txt_Producto.PreventEnterBeep = True
        Me.Txt_Producto.ReadOnly = True
        Me.Txt_Producto.Size = New System.Drawing.Size(419, 22)
        Me.Txt_Producto.TabIndex = 0
        '
        'Lbl_Producto
        '
        Me.Lbl_Producto.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Producto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Producto.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Producto.Location = New System.Drawing.Point(12, 12)
        Me.Lbl_Producto.Name = "Lbl_Producto"
        Me.Lbl_Producto.Size = New System.Drawing.Size(80, 23)
        Me.Lbl_Producto.TabIndex = 167
        Me.Lbl_Producto.Text = "Producto"
        '
        'Cmb_UdMedida
        '
        Me.Cmb_UdMedida.DisplayMember = "Text"
        Me.Cmb_UdMedida.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_UdMedida.ForeColor = System.Drawing.Color.Black
        Me.Cmb_UdMedida.FormattingEnabled = True
        Me.Cmb_UdMedida.ItemHeight = 16
        Me.Cmb_UdMedida.Location = New System.Drawing.Point(106, 96)
        Me.Cmb_UdMedida.Name = "Cmb_UdMedida"
        Me.Cmb_UdMedida.Size = New System.Drawing.Size(52, 22)
        Me.Cmb_UdMedida.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_UdMedida.TabIndex = 3
        '
        'Lbl_UdMedida
        '
        Me.Lbl_UdMedida.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_UdMedida.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_UdMedida.ForeColor = System.Drawing.Color.Black
        Me.Lbl_UdMedida.Location = New System.Drawing.Point(12, 95)
        Me.Lbl_UdMedida.Name = "Lbl_UdMedida"
        Me.Lbl_UdMedida.Size = New System.Drawing.Size(40, 23)
        Me.Lbl_UdMedida.TabIndex = 177
        Me.Lbl_UdMedida.Text = "Unidad"
        '
        'Lbl_FechaRev
        '
        Me.Lbl_FechaRev.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_FechaRev.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_FechaRev.ForeColor = System.Drawing.Color.Black
        Me.Lbl_FechaRev.Location = New System.Drawing.Point(11, 180)
        Me.Lbl_FechaRev.Name = "Lbl_FechaRev"
        Me.Lbl_FechaRev.Size = New System.Drawing.Size(89, 23)
        Me.Lbl_FechaRev.TabIndex = 176
        Me.Lbl_FechaRev.Text = "Fecha de revisi�n"
        '
        'Dtp_FechaRev
        '
        Me.Dtp_FechaRev.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_FechaRev.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_FechaRev.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaRev.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_FechaRev.ButtonDropDown.Visible = True
        Me.Dtp_FechaRev.Enabled = False
        Me.Dtp_FechaRev.ForeColor = System.Drawing.Color.Black
        Me.Dtp_FechaRev.IsPopupCalendarOpen = False
        Me.Dtp_FechaRev.Location = New System.Drawing.Point(106, 180)
        '
        '
        '
        Me.Dtp_FechaRev.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FechaRev.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaRev.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_FechaRev.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_FechaRev.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_FechaRev.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FechaRev.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_FechaRev.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_FechaRev.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_FechaRev.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_FechaRev.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaRev.MonthCalendar.DisplayMonth = New Date(2023, 12, 1, 0, 0, 0, 0)
        Me.Dtp_FechaRev.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_FechaRev.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_FechaRev.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FechaRev.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_FechaRev.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FechaRev.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_FechaRev.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaRev.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_FechaRev.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_FechaRev.Name = "Dtp_FechaRev"
        Me.Dtp_FechaRev.Size = New System.Drawing.Size(86, 22)
        Me.Dtp_FechaRev.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_FechaRev.TabIndex = 6
        Me.Dtp_FechaRev.Value = New Date(2024, 1, 2, 0, 0, 0, 0)
        '
        'Txt_Diferencia
        '
        Me.Txt_Diferencia.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Diferencia.Border.Class = "TextBoxBorder"
        Me.Txt_Diferencia.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Diferencia.ButtonCustom.Image = CType(resources.GetObject("Txt_Diferencia.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Diferencia.ButtonCustom2.Image = CType(resources.GetObject("Txt_Diferencia.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Diferencia.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Diferencia.ForeColor = System.Drawing.Color.Black
        Me.Txt_Diferencia.Location = New System.Drawing.Point(293, 152)
        Me.Txt_Diferencia.Name = "Txt_Diferencia"
        Me.Txt_Diferencia.PreventEnterBeep = True
        Me.Txt_Diferencia.ReadOnly = True
        Me.Txt_Diferencia.Size = New System.Drawing.Size(86, 22)
        Me.Txt_Diferencia.TabIndex = 180
        Me.Txt_Diferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Txt_Diferencia.Visible = False
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(231, 152)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(56, 23)
        Me.LabelX1.TabIndex = 179
        Me.LabelX1.Text = "Diferencia"
        Me.LabelX1.Visible = False
        '
        'Lbl_HoraRev
        '
        Me.Lbl_HoraRev.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_HoraRev.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_HoraRev.ForeColor = System.Drawing.Color.Black
        Me.Lbl_HoraRev.Location = New System.Drawing.Point(11, 209)
        Me.Lbl_HoraRev.Name = "Lbl_HoraRev"
        Me.Lbl_HoraRev.Size = New System.Drawing.Size(89, 23)
        Me.Lbl_HoraRev.TabIndex = 182
        Me.Lbl_HoraRev.Text = "Hora de revisi�n"
        '
        'Dtp_HoraRev
        '
        Me.Dtp_HoraRev.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_HoraRev.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_HoraRev.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_HoraRev.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_HoraRev.ButtonDropDown.Visible = True
        Me.Dtp_HoraRev.Enabled = False
        Me.Dtp_HoraRev.ForeColor = System.Drawing.Color.Black
        Me.Dtp_HoraRev.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime
        Me.Dtp_HoraRev.IsPopupCalendarOpen = False
        Me.Dtp_HoraRev.Location = New System.Drawing.Point(138, 209)
        '
        '
        '
        Me.Dtp_HoraRev.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_HoraRev.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_HoraRev.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_HoraRev.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_HoraRev.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_HoraRev.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_HoraRev.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_HoraRev.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_HoraRev.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_HoraRev.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_HoraRev.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_HoraRev.MonthCalendar.DisplayMonth = New Date(2023, 12, 1, 0, 0, 0, 0)
        Me.Dtp_HoraRev.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_HoraRev.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_HoraRev.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_HoraRev.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_HoraRev.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_HoraRev.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_HoraRev.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_HoraRev.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_HoraRev.MonthCalendar.Visible = False
        Me.Dtp_HoraRev.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_HoraRev.Name = "Dtp_HoraRev"
        Me.Dtp_HoraRev.Size = New System.Drawing.Size(54, 22)
        Me.Dtp_HoraRev.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_HoraRev.TabIndex = 7
        Me.Dtp_HoraRev.Value = New Date(2024, 1, 2, 0, 0, 0, 0)
        '
        'Txt_Ubicacion
        '
        Me.Txt_Ubicacion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Ubicacion.Border.Class = "TextBoxBorder"
        Me.Txt_Ubicacion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Ubicacion.ButtonCustom.Image = CType(resources.GetObject("Txt_Ubicacion.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Ubicacion.ButtonCustom2.Image = CType(resources.GetObject("Txt_Ubicacion.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Ubicacion.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Ubicacion.ForeColor = System.Drawing.Color.Black
        Me.Txt_Ubicacion.Location = New System.Drawing.Point(107, 69)
        Me.Txt_Ubicacion.MaxLength = 30
        Me.Txt_Ubicacion.Name = "Txt_Ubicacion"
        Me.Txt_Ubicacion.PreventEnterBeep = True
        Me.Txt_Ubicacion.Size = New System.Drawing.Size(272, 22)
        Me.Txt_Ubicacion.TabIndex = 2
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(12, 66)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(59, 23)
        Me.LabelX2.TabIndex = 183
        Me.LabelX2.Text = "Ubicaci�n"
        '
        'Input_StfiEnBodega
        '
        Me.Input_StfiEnBodega.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_StfiEnBodega.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_StfiEnBodega.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_StfiEnBodega.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.Input_StfiEnBodega.ForeColor = System.Drawing.Color.Black
        Me.Input_StfiEnBodega.Location = New System.Drawing.Point(106, 124)
        Me.Input_StfiEnBodega.Name = "Input_StfiEnBodega"
        Me.Input_StfiEnBodega.ShowUpDown = True
        Me.Input_StfiEnBodega.Size = New System.Drawing.Size(80, 22)
        Me.Input_StfiEnBodega.TabIndex = 184
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
        Me.Input_Cantidad.ForeColor = System.Drawing.Color.Black
        Me.Input_Cantidad.Location = New System.Drawing.Point(106, 152)
        Me.Input_Cantidad.Name = "Input_Cantidad"
        Me.Input_Cantidad.ShowUpDown = True
        Me.Input_Cantidad.Size = New System.Drawing.Size(80, 22)
        Me.Input_Cantidad.TabIndex = 185
        '
        'Frm_Tickets_IngProducto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(536, 285)
        Me.Controls.Add(Me.Input_Cantidad)
        Me.Controls.Add(Me.Input_StfiEnBodega)
        Me.Controls.Add(Me.Txt_Ubicacion)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.Lbl_HoraRev)
        Me.Controls.Add(Me.Dtp_HoraRev)
        Me.Controls.Add(Me.Txt_Diferencia)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Lbl_Cantidad)
        Me.Controls.Add(Me.Lbl_StfiEnBodega)
        Me.Controls.Add(Me.Txt_Bodega)
        Me.Controls.Add(Me.LabelX7)
        Me.Controls.Add(Me.Txt_Producto)
        Me.Controls.Add(Me.Lbl_Producto)
        Me.Controls.Add(Me.Cmb_UdMedida)
        Me.Controls.Add(Me.Lbl_UdMedida)
        Me.Controls.Add(Me.Lbl_FechaRev)
        Me.Controls.Add(Me.Dtp_FechaRev)
        Me.Controls.Add(Me.Bar2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Tickets_IngProducto"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "INGRESO DE PRODUCTO"
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_FechaRev, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_HoraRev, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Input_StfiEnBodega, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Input_Cantidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Archivos_Adjuntos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Eliminar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Lbl_Cantidad As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_StfiEnBodega As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Bodega As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Producto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Lbl_Producto As DevComponents.DotNetBar.LabelX
    Public WithEvents Cmb_UdMedida As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Lbl_UdMedida As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_FechaRev As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dtp_FechaRev As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Txt_Diferencia As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_HoraRev As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dtp_HoraRev As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Txt_Ubicacion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Input_StfiEnBodega As DevComponents.Editors.IntegerInput
    Friend WithEvents Input_Cantidad As DevComponents.Editors.IntegerInput
    Public WithEvents Btn_GestProductos As DevComponents.DotNetBar.ButtonItem
End Class
