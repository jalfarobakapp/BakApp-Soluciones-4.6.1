<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_GDI2GRI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_GDI2GRI))
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Limpiar = New DevComponents.DotNetBar.ButtonItem()
        Me.Txt_Producto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Txt_BodegaGRI = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.DInput_Cantidad = New DevComponents.Editors.DoubleInput()
        Me.Lbl_StfiEnBodega = New DevComponents.DotNetBar.LabelX()
        Me.Cmb_UdMedida = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Lbl_UdMedida = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_BodegaGDI = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_FechaEmision = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.DInput_Cantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_FechaEmision, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar, Me.Btn_Limpiar})
        Me.Bar1.Location = New System.Drawing.Point(0, 219)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(653, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 65
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.ImageAlt = CType(resources.GetObject("Btn_Grabar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Grabar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Tooltip = "Grabar"
        '
        'Btn_Limpiar
        '
        Me.Btn_Limpiar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Limpiar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Limpiar.Image = CType(resources.GetObject("Btn_Limpiar.Image"), System.Drawing.Image)
        Me.Btn_Limpiar.ImageAlt = CType(resources.GetObject("Btn_Limpiar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Limpiar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Limpiar.Name = "Btn_Limpiar"
        Me.Btn_Limpiar.Tooltip = "Nuevo, limpiar documento [F5]"
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
        Me.Txt_Producto.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Producto.ForeColor = System.Drawing.Color.Black
        Me.Txt_Producto.Location = New System.Drawing.Point(84, 23)
        Me.Txt_Producto.Name = "Txt_Producto"
        Me.Txt_Producto.PreventEnterBeep = True
        Me.Txt_Producto.ReadOnly = True
        Me.Txt_Producto.Size = New System.Drawing.Size(536, 22)
        Me.Txt_Producto.TabIndex = 66
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 23)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(52, 23)
        Me.LabelX2.TabIndex = 67
        Me.LabelX2.Text = "Producto"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Dtp_FechaEmision)
        Me.GroupPanel1.Controls.Add(Me.LabelX4)
        Me.GroupPanel1.Controls.Add(Me.Txt_BodegaGRI)
        Me.GroupPanel1.Controls.Add(Me.DInput_Cantidad)
        Me.GroupPanel1.Controls.Add(Me.Lbl_StfiEnBodega)
        Me.GroupPanel1.Controls.Add(Me.Cmb_UdMedida)
        Me.GroupPanel1.Controls.Add(Me.Lbl_UdMedida)
        Me.GroupPanel1.Controls.Add(Me.LabelX3)
        Me.GroupPanel1.Controls.Add(Me.LabelX1)
        Me.GroupPanel1.Controls.Add(Me.Txt_BodegaGDI)
        Me.GroupPanel1.Controls.Add(Me.LabelX2)
        Me.GroupPanel1.Controls.Add(Me.Txt_Producto)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(629, 197)
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
        Me.GroupPanel1.TabIndex = 68
        Me.GroupPanel1.Text = "Datos del producto"
        '
        'Txt_BodegaGRI
        '
        Me.Txt_BodegaGRI.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_BodegaGRI.Border.Class = "TextBoxBorder"
        Me.Txt_BodegaGRI.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_BodegaGRI.ButtonCustom.Image = CType(resources.GetObject("Txt_BodegaGRI.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_BodegaGRI.ButtonCustom.Visible = True
        Me.Txt_BodegaGRI.ButtonCustom2.Image = CType(resources.GetObject("Txt_BodegaGRI.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_BodegaGRI.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_BodegaGRI.ForeColor = System.Drawing.Color.Black
        Me.Txt_BodegaGRI.Location = New System.Drawing.Point(84, 79)
        Me.Txt_BodegaGRI.Name = "Txt_BodegaGRI"
        Me.Txt_BodegaGRI.PreventEnterBeep = True
        Me.Txt_BodegaGRI.ReadOnly = True
        Me.Txt_BodegaGRI.Size = New System.Drawing.Size(536, 22)
        Me.Txt_BodegaGRI.TabIndex = 70
        '
        'DInput_Cantidad
        '
        Me.DInput_Cantidad.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.DInput_Cantidad.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.DInput_Cantidad.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DInput_Cantidad.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.DInput_Cantidad.ForeColor = System.Drawing.Color.Black
        Me.DInput_Cantidad.Increment = 1.0R
        Me.DInput_Cantidad.Location = New System.Drawing.Point(84, 135)
        Me.DInput_Cantidad.MinValue = 0R
        Me.DInput_Cantidad.Name = "DInput_Cantidad"
        Me.DInput_Cantidad.ShowUpDown = True
        Me.DInput_Cantidad.Size = New System.Drawing.Size(111, 22)
        Me.DInput_Cantidad.TabIndex = 188
        '
        'Lbl_StfiEnBodega
        '
        Me.Lbl_StfiEnBodega.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_StfiEnBodega.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_StfiEnBodega.ForeColor = System.Drawing.Color.Black
        Me.Lbl_StfiEnBodega.Location = New System.Drawing.Point(3, 135)
        Me.Lbl_StfiEnBodega.Name = "Lbl_StfiEnBodega"
        Me.Lbl_StfiEnBodega.Size = New System.Drawing.Size(75, 23)
        Me.Lbl_StfiEnBodega.TabIndex = 186
        Me.Lbl_StfiEnBodega.Text = "Cantidad"
        '
        'Cmb_UdMedida
        '
        Me.Cmb_UdMedida.DisplayMember = "Text"
        Me.Cmb_UdMedida.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_UdMedida.ForeColor = System.Drawing.Color.Black
        Me.Cmb_UdMedida.FormattingEnabled = True
        Me.Cmb_UdMedida.ItemHeight = 16
        Me.Cmb_UdMedida.Location = New System.Drawing.Point(84, 107)
        Me.Cmb_UdMedida.Name = "Cmb_UdMedida"
        Me.Cmb_UdMedida.Size = New System.Drawing.Size(52, 22)
        Me.Cmb_UdMedida.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_UdMedida.TabIndex = 185
        '
        'Lbl_UdMedida
        '
        Me.Lbl_UdMedida.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_UdMedida.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_UdMedida.ForeColor = System.Drawing.Color.Black
        Me.Lbl_UdMedida.Location = New System.Drawing.Point(3, 106)
        Me.Lbl_UdMedida.Name = "Lbl_UdMedida"
        Me.Lbl_UdMedida.Size = New System.Drawing.Size(40, 23)
        Me.Lbl_UdMedida.TabIndex = 187
        Me.Lbl_UdMedida.Text = "Unidad"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(3, 79)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(87, 23)
        Me.LabelX3.TabIndex = 71
        Me.LabelX3.Text = "Bodega destino"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 51)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 23)
        Me.LabelX1.TabIndex = 69
        Me.LabelX1.Text = "Bodega origen"
        '
        'Txt_BodegaGDI
        '
        Me.Txt_BodegaGDI.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_BodegaGDI.Border.Class = "TextBoxBorder"
        Me.Txt_BodegaGDI.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_BodegaGDI.ButtonCustom.Image = CType(resources.GetObject("Txt_BodegaGDI.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_BodegaGDI.ButtonCustom.Visible = True
        Me.Txt_BodegaGDI.ButtonCustom2.Image = CType(resources.GetObject("Txt_BodegaGDI.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_BodegaGDI.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_BodegaGDI.ForeColor = System.Drawing.Color.Black
        Me.Txt_BodegaGDI.Location = New System.Drawing.Point(84, 51)
        Me.Txt_BodegaGDI.Name = "Txt_BodegaGDI"
        Me.Txt_BodegaGDI.PreventEnterBeep = True
        Me.Txt_BodegaGDI.ReadOnly = True
        Me.Txt_BodegaGDI.Size = New System.Drawing.Size(536, 22)
        Me.Txt_BodegaGDI.TabIndex = 68
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(455, 108)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(71, 23)
        Me.LabelX4.TabIndex = 189
        Me.LabelX4.Text = "Fecha emisón"
        '
        'Dtp_FechaEmision
        '
        '
        '
        '
        Me.Dtp_FechaEmision.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_FechaEmision.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaEmision.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_FechaEmision.ButtonDropDown.Visible = True
        Me.Dtp_FechaEmision.IsPopupCalendarOpen = False
        Me.Dtp_FechaEmision.Location = New System.Drawing.Point(532, 108)
        '
        '
        '
        Me.Dtp_FechaEmision.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FechaEmision.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaEmision.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_FechaEmision.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_FechaEmision.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_FechaEmision.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FechaEmision.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_FechaEmision.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_FechaEmision.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_FechaEmision.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_FechaEmision.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaEmision.MonthCalendar.DisplayMonth = New Date(2025, 2, 1, 0, 0, 0, 0)
        Me.Dtp_FechaEmision.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_FechaEmision.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_FechaEmision.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FechaEmision.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_FechaEmision.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FechaEmision.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_FechaEmision.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaEmision.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_FechaEmision.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_FechaEmision.Name = "Dtp_FechaEmision"
        Me.Dtp_FechaEmision.Size = New System.Drawing.Size(88, 22)
        Me.Dtp_FechaEmision.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_FechaEmision.TabIndex = 190
        Me.Dtp_FechaEmision.Value = New Date(2025, 2, 6, 16, 38, 38, 0)
        '
        'Frm_GDI2GRI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(653, 260)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_GDI2GRI"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "INGRESO DE GDI Y GRI INMEDIATAMENTE LIGADAS"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.DInput_Cantidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_FechaEmision, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Txt_Producto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_BodegaGRI As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_BodegaGDI As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents DInput_Cantidad As DevComponents.Editors.DoubleInput
    Friend WithEvents Lbl_StfiEnBodega As DevComponents.DotNetBar.LabelX
    Public WithEvents Cmb_UdMedida As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Lbl_UdMedida As DevComponents.DotNetBar.LabelX
    Public WithEvents Btn_Limpiar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Dtp_FechaEmision As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
End Class
