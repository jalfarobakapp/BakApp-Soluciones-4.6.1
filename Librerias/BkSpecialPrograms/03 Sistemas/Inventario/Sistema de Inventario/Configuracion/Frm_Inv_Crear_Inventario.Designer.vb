<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Inv_Crear_Inventario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Inv_Crear_Inventario))
        Me.Btn_Cambiar_Fecha_Ajuste = New DevComponents.DotNetBar.ButtonX()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Lbl_Sucursal = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Empresa = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Cerrar = New DevComponents.DotNetBar.ButtonItem()
        Me.Txt_Nombre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_FechaInicio = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Sw_Activo = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Lbl_Estado = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_FechaCierre = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Lbl_FechaCierre = New DevComponents.DotNetBar.LabelX()
        Me.Line1 = New DevComponents.DotNetBar.Controls.Line()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_FechaInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_FechaCierre, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Btn_Cambiar_Fecha_Ajuste
        '
        Me.Btn_Cambiar_Fecha_Ajuste.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Cambiar_Fecha_Ajuste.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Cambiar_Fecha_Ajuste.Image = CType(resources.GetObject("Btn_Cambiar_Fecha_Ajuste.Image"), System.Drawing.Image)
        Me.Btn_Cambiar_Fecha_Ajuste.Location = New System.Drawing.Point(310, 59)
        Me.Btn_Cambiar_Fecha_Ajuste.Name = "Btn_Cambiar_Fecha_Ajuste"
        Me.Btn_Cambiar_Fecha_Ajuste.Size = New System.Drawing.Size(29, 23)
        Me.Btn_Cambiar_Fecha_Ajuste.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Cambiar_Fecha_Ajuste.TabIndex = 37
        Me.Btn_Cambiar_Fecha_Ajuste.Tooltip = "Cambiar fecha de ajuste"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_Sucursal, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX4, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_Empresa, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX2, 0, 0)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(565, 46)
        Me.TableLayoutPanel1.TabIndex = 36
        '
        'Lbl_Sucursal
        '
        Me.Lbl_Sucursal.AutoSize = True
        '
        '
        '
        Me.Lbl_Sucursal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Sucursal.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Sucursal.Location = New System.Drawing.Point(86, 28)
        Me.Lbl_Sucursal.Name = "Lbl_Sucursal"
        Me.Lbl_Sucursal.Size = New System.Drawing.Size(41, 17)
        Me.Lbl_Sucursal.TabIndex = 3
        Me.Lbl_Sucursal.Text = "LabelX5"
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(4, 28)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(75, 14)
        Me.LabelX4.TabIndex = 2
        Me.LabelX4.Text = "Sucursal"
        '
        'Lbl_Empresa
        '
        Me.Lbl_Empresa.AutoSize = True
        '
        '
        '
        Me.Lbl_Empresa.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Empresa.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Empresa.Location = New System.Drawing.Point(86, 4)
        Me.Lbl_Empresa.Name = "Lbl_Empresa"
        Me.Lbl_Empresa.Size = New System.Drawing.Size(41, 17)
        Me.Lbl_Empresa.TabIndex = 1
        Me.Lbl_Empresa.Text = "LabelX3"
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(4, 4)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 17)
        Me.LabelX2.TabIndex = 0
        Me.LabelX2.Text = "Empresa"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar, Me.Btn_Cerrar})
        Me.Bar1.Location = New System.Drawing.Point(0, 206)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(590, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 35
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
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
        'Btn_Cerrar
        '
        Me.Btn_Cerrar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Cerrar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Cerrar.Image = CType(resources.GetObject("Btn_Cerrar.Image"), System.Drawing.Image)
        Me.Btn_Cerrar.ImageAlt = CType(resources.GetObject("Btn_Cerrar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Cerrar.Name = "Btn_Cerrar"
        Me.Btn_Cerrar.Tooltip = "Cerrar inventario"
        '
        'Txt_Nombre
        '
        Me.Txt_Nombre.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Nombre.Border.Class = "TextBoxBorder"
        Me.Txt_Nombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Nombre.ButtonCustom.Image = CType(resources.GetObject("Txt_Nombre.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Nombre.ButtonCustom.Visible = True
        Me.Txt_Nombre.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Nombre.Enabled = False
        Me.Txt_Nombre.ForeColor = System.Drawing.Color.Black
        Me.Txt_Nombre.Location = New System.Drawing.Point(133, 88)
        Me.Txt_Nombre.Name = "Txt_Nombre"
        Me.Txt_Nombre.PreventEnterBeep = True
        Me.Txt_Nombre.ReadOnly = True
        Me.Txt_Nombre.Size = New System.Drawing.Size(444, 22)
        Me.Txt_Nombre.TabIndex = 34
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(12, 85)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(129, 23)
        Me.LabelX1.TabIndex = 33
        Me.LabelX1.Text = "Nombre del Inventario"
        '
        'Dtp_FechaInicio
        '
        Me.Dtp_FechaInicio.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_FechaInicio.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_FechaInicio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaInicio.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_FechaInicio.ButtonDropDown.Visible = True
        Me.Dtp_FechaInicio.Enabled = False
        Me.Dtp_FechaInicio.ForeColor = System.Drawing.Color.Black
        Me.Dtp_FechaInicio.Format = DevComponents.Editors.eDateTimePickerFormat.[Long]
        Me.Dtp_FechaInicio.IsPopupCalendarOpen = False
        Me.Dtp_FechaInicio.Location = New System.Drawing.Point(133, 60)
        '
        '
        '
        Me.Dtp_FechaInicio.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FechaInicio.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaInicio.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_FechaInicio.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_FechaInicio.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_FechaInicio.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FechaInicio.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_FechaInicio.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_FechaInicio.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_FechaInicio.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_FechaInicio.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaInicio.MonthCalendar.DisplayMonth = New Date(2014, 10, 1, 0, 0, 0, 0)
        Me.Dtp_FechaInicio.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_FechaInicio.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_FechaInicio.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FechaInicio.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_FechaInicio.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FechaInicio.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_FechaInicio.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaInicio.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_FechaInicio.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_FechaInicio.Name = "Dtp_FechaInicio"
        Me.Dtp_FechaInicio.Size = New System.Drawing.Size(171, 22)
        Me.Dtp_FechaInicio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_FechaInicio.TabIndex = 32
        Me.Dtp_FechaInicio.Value = New Date(2014, 10, 2, 11, 14, 2, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(9, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 13)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Fecha inventario"
        '
        'Sw_Activo
        '
        Me.Sw_Activo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Sw_Activo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Sw_Activo.ForeColor = System.Drawing.Color.Black
        Me.Sw_Activo.Location = New System.Drawing.Point(133, 145)
        Me.Sw_Activo.Name = "Sw_Activo"
        Me.Sw_Activo.OffText = "Cerrado"
        Me.Sw_Activo.OnText = "Activo"
        Me.Sw_Activo.Size = New System.Drawing.Size(95, 22)
        Me.Sw_Activo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Sw_Activo.TabIndex = 40
        Me.Sw_Activo.Value = True
        Me.Sw_Activo.ValueObject = "Y"
        '
        'Lbl_Estado
        '
        Me.Lbl_Estado.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Estado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Estado.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Estado.Location = New System.Drawing.Point(12, 143)
        Me.Lbl_Estado.Name = "Lbl_Estado"
        Me.Lbl_Estado.Size = New System.Drawing.Size(75, 23)
        Me.Lbl_Estado.TabIndex = 41
        Me.Lbl_Estado.Text = "Estado"
        '
        'Dtp_FechaCierre
        '
        Me.Dtp_FechaCierre.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_FechaCierre.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_FechaCierre.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaCierre.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_FechaCierre.ButtonDropDown.Visible = True
        Me.Dtp_FechaCierre.Enabled = False
        Me.Dtp_FechaCierre.ForeColor = System.Drawing.Color.Black
        Me.Dtp_FechaCierre.Format = DevComponents.Editors.eDateTimePickerFormat.[Long]
        Me.Dtp_FechaCierre.IsPopupCalendarOpen = False
        Me.Dtp_FechaCierre.Location = New System.Drawing.Point(133, 173)
        '
        '
        '
        Me.Dtp_FechaCierre.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FechaCierre.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaCierre.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_FechaCierre.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_FechaCierre.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_FechaCierre.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FechaCierre.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_FechaCierre.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_FechaCierre.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_FechaCierre.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_FechaCierre.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaCierre.MonthCalendar.DisplayMonth = New Date(2014, 10, 1, 0, 0, 0, 0)
        Me.Dtp_FechaCierre.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_FechaCierre.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_FechaCierre.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FechaCierre.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_FechaCierre.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FechaCierre.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_FechaCierre.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaCierre.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_FechaCierre.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_FechaCierre.Name = "Dtp_FechaCierre"
        Me.Dtp_FechaCierre.Size = New System.Drawing.Size(180, 22)
        Me.Dtp_FechaCierre.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_FechaCierre.TabIndex = 42
        Me.Dtp_FechaCierre.Value = New Date(2014, 10, 2, 11, 14, 2, 0)
        '
        'Lbl_FechaCierre
        '
        Me.Lbl_FechaCierre.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_FechaCierre.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_FechaCierre.ForeColor = System.Drawing.Color.Black
        Me.Lbl_FechaCierre.Location = New System.Drawing.Point(12, 172)
        Me.Lbl_FechaCierre.Name = "Lbl_FechaCierre"
        Me.Lbl_FechaCierre.Size = New System.Drawing.Size(75, 23)
        Me.Lbl_FechaCierre.TabIndex = 43
        Me.Lbl_FechaCierre.Text = "Fecha cierre"
        '
        'Line1
        '
        Me.Line1.BackColor = System.Drawing.Color.White
        Me.Line1.ForeColor = System.Drawing.Color.Black
        Me.Line1.Location = New System.Drawing.Point(12, 114)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(565, 23)
        Me.Line1.TabIndex = 44
        Me.Line1.Text = "Line1"
        '
        'Frm_Inv_Crear_Inventario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(590, 247)
        Me.Controls.Add(Me.Line1)
        Me.Controls.Add(Me.Dtp_FechaCierre)
        Me.Controls.Add(Me.Lbl_FechaCierre)
        Me.Controls.Add(Me.Lbl_Estado)
        Me.Controls.Add(Me.Sw_Activo)
        Me.Controls.Add(Me.Btn_Cambiar_Fecha_Ajuste)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.Txt_Nombre)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Dtp_FechaInicio)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Inv_Crear_Inventario"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "INVENTARIO"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_FechaInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_FechaCierre, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Btn_Cambiar_Fecha_Ajuste As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Public WithEvents Lbl_Sucursal As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Public WithEvents Lbl_Empresa As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Txt_Nombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Public WithEvents Dtp_FechaInicio As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Label1 As Label
    Friend WithEvents Sw_Activo As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents Lbl_Estado As DevComponents.DotNetBar.LabelX
    Public WithEvents Dtp_FechaCierre As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Lbl_FechaCierre As DevComponents.DotNetBar.LabelX
    Friend WithEvents Line1 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents Btn_Cerrar As DevComponents.DotNetBar.ButtonItem
End Class
