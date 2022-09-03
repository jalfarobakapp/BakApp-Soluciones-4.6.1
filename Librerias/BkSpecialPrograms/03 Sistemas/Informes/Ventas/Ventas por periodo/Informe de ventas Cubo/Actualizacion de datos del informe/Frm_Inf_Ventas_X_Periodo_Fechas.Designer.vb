<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Inf_Ventas_X_Periodo_Fechas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Inf_Ventas_X_Periodo_Fechas))
        Me.Grupo_Fechas = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Lbl_FS_desde = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_Fecha_Desde = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Lbl_FS_hasta = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_Fecha_Hasta = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Filtrar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Cancelar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Actualizar_Indices = New DevComponents.DotNetBar.ButtonItem()
        Me.Progreso_Porc = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.Lbl_Estado = New DevComponents.DotNetBar.LabelX()
        Me.Progreso_Cont_Productos = New DevComponents.DotNetBar.Controls.ProgressBarX()
        Me.Lbl_Doc_Insert = New DevComponents.DotNetBar.LabelX()
        Me.MetroStatusBar1 = New DevComponents.DotNetBar.Metro.MetroStatusBar()
        Me.Lbl_Tiempo = New DevComponents.DotNetBar.LabelItem()
        Me.Tiempo = New System.Windows.Forms.Timer(Me.components)
        Me.Grupo_Fechas.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.Dtp_Fecha_Desde, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_Fecha_Hasta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Grupo_Fechas
        '
        Me.Grupo_Fechas.BackColor = System.Drawing.Color.White
        Me.Grupo_Fechas.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Fechas.Controls.Add(Me.TableLayoutPanel1)
        Me.Grupo_Fechas.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Fechas.Location = New System.Drawing.Point(6, 2)
        Me.Grupo_Fechas.Name = "Grupo_Fechas"
        Me.Grupo_Fechas.Size = New System.Drawing.Size(311, 66)
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
        Me.Grupo_Fechas.TabIndex = 89
        Me.Grupo_Fechas.Text = "Rango de fecha informe"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.72581!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.87097!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.51613!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.69355!))
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_FS_desde, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Dtp_Fecha_Desde, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_FS_hasta, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Dtp_Fecha_Hasta, 3, 0)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 15)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(299, 25)
        Me.TableLayoutPanel1.TabIndex = 6
        '
        'Lbl_FS_desde
        '
        '
        '
        '
        Me.Lbl_FS_desde.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_FS_desde.ForeColor = System.Drawing.Color.Black
        Me.Lbl_FS_desde.Location = New System.Drawing.Point(3, 3)
        Me.Lbl_FS_desde.Name = "Lbl_FS_desde"
        Me.Lbl_FS_desde.Size = New System.Drawing.Size(32, 19)
        Me.Lbl_FS_desde.TabIndex = 7
        Me.Lbl_FS_desde.Text = "Desde"
        '
        'Dtp_Fecha_Desde
        '
        '
        '
        '
        Me.Dtp_Fecha_Desde.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Desde.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Desde.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Desde.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Desde.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Desde.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Desde.Location = New System.Drawing.Point(49, 3)
        '
        '
        '
        Me.Dtp_Fecha_Desde.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Desde.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Desde.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Desde.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Desde.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Desde.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Desde.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Desde.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Desde.MonthCalendar.DisplayMonth = New Date(2016, 7, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Desde.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_Fecha_Desde.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Desde.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Desde.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Desde.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Desde.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Desde.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Desde.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Desde.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Desde.Name = "Dtp_Fecha_Desde"
        Me.Dtp_Fecha_Desde.Size = New System.Drawing.Size(77, 22)
        Me.Dtp_Fecha_Desde.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Desde.TabIndex = 7
        Me.Dtp_Fecha_Desde.Value = New Date(2016, 7, 8, 16, 32, 31, 0)
        '
        'Lbl_FS_hasta
        '
        '
        '
        '
        Me.Lbl_FS_hasta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_FS_hasta.ForeColor = System.Drawing.Color.Black
        Me.Lbl_FS_hasta.Location = New System.Drawing.Point(149, 3)
        Me.Lbl_FS_hasta.Name = "Lbl_FS_hasta"
        Me.Lbl_FS_hasta.Size = New System.Drawing.Size(29, 19)
        Me.Lbl_FS_hasta.TabIndex = 9
        Me.Lbl_FS_hasta.Text = "Hasta"
        '
        'Dtp_Fecha_Hasta
        '
        '
        '
        '
        Me.Dtp_Fecha_Hasta.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Hasta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Hasta.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Hasta.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Hasta.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Hasta.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Hasta.Location = New System.Drawing.Point(192, 3)
        '
        '
        '
        Me.Dtp_Fecha_Hasta.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Hasta.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Hasta.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Hasta.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Hasta.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Hasta.MonthCalendar.DisplayMonth = New Date(2016, 7, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Hasta.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_Fecha_Hasta.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Hasta.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Hasta.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Hasta.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Hasta.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Hasta.Name = "Dtp_Fecha_Hasta"
        Me.Dtp_Fecha_Hasta.Size = New System.Drawing.Size(81, 22)
        Me.Dtp_Fecha_Hasta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Hasta.TabIndex = 8
        Me.Dtp_Fecha_Hasta.Value = New Date(2016, 7, 8, 16, 33, 0, 0)
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Filtrar, Me.Btn_Cancelar, Me.Btn_Actualizar_Indices})
        Me.Bar2.Location = New System.Drawing.Point(0, 206)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(324, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 90
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Filtrar
        '
        Me.Btn_Filtrar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Filtrar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Filtrar.Image = CType(resources.GetObject("Btn_Filtrar.Image"), System.Drawing.Image)
        Me.Btn_Filtrar.ImageAlt = CType(resources.GetObject("Btn_Filtrar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Filtrar.Name = "Btn_Filtrar"
        Me.Btn_Filtrar.Text = "Aceptar"
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Cancelar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Cancelar.Image = CType(resources.GetObject("Btn_Cancelar.Image"), System.Drawing.Image)
        Me.Btn_Cancelar.ImageAlt = CType(resources.GetObject("Btn_Cancelar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Text = "Detener"
        '
        'Btn_Actualizar_Indices
        '
        Me.Btn_Actualizar_Indices.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Actualizar_Indices.ForeColor = System.Drawing.Color.Black
        Me.Btn_Actualizar_Indices.Image = CType(resources.GetObject("Btn_Actualizar_Indices.Image"), System.Drawing.Image)
        Me.Btn_Actualizar_Indices.ImageAlt = CType(resources.GetObject("Btn_Actualizar_Indices.ImageAlt"), System.Drawing.Image)
        Me.Btn_Actualizar_Indices.Name = "Btn_Actualizar_Indices"
        Me.Btn_Actualizar_Indices.Text = "Actualizar índices"
        '
        'Progreso_Porc
        '
        Me.Progreso_Porc.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Progreso_Porc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Progreso_Porc.Location = New System.Drawing.Point(6, 74)
        Me.Progreso_Porc.Name = "Progreso_Porc"
        Me.Progreso_Porc.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.Progreso_Porc.ProgressColor = System.Drawing.Color.SteelBlue
        Me.Progreso_Porc.ProgressTextVisible = True
        Me.Progreso_Porc.Size = New System.Drawing.Size(47, 45)
        Me.Progreso_Porc.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.Progreso_Porc.TabIndex = 94
        '
        'Lbl_Estado
        '
        Me.Lbl_Estado.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Estado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Estado.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Estado.Location = New System.Drawing.Point(61, 74)
        Me.Lbl_Estado.Name = "Lbl_Estado"
        Me.Lbl_Estado.Size = New System.Drawing.Size(256, 49)
        Me.Lbl_Estado.TabIndex = 95
        Me.Lbl_Estado.Text = "LabelX1" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "LabelX2" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "LabelX3"
        '
        'Progreso_Cont_Productos
        '
        Me.Progreso_Cont_Productos.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Progreso_Cont_Productos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Progreso_Cont_Productos.ForeColor = System.Drawing.Color.Black
        Me.Progreso_Cont_Productos.Location = New System.Drawing.Point(6, 151)
        Me.Progreso_Cont_Productos.Name = "Progreso_Cont_Productos"
        Me.Progreso_Cont_Productos.Size = New System.Drawing.Size(311, 23)
        Me.Progreso_Cont_Productos.TabIndex = 98
        Me.Progreso_Cont_Productos.Text = "ProgressBarX1"
        '
        'Lbl_Doc_Insert
        '
        Me.Lbl_Doc_Insert.AutoSize = True
        Me.Lbl_Doc_Insert.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Doc_Insert.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Doc_Insert.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Doc_Insert.Location = New System.Drawing.Point(6, 129)
        Me.Lbl_Doc_Insert.Name = "Lbl_Doc_Insert"
        Me.Lbl_Doc_Insert.Size = New System.Drawing.Size(163, 17)
        Me.Lbl_Doc_Insert.TabIndex = 99
        Me.Lbl_Doc_Insert.Text = "Insertando documentos 1 de 356"
        '
        'MetroStatusBar1
        '
        Me.MetroStatusBar1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.MetroStatusBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MetroStatusBar1.ContainerControlProcessDialogKey = True
        Me.MetroStatusBar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.MetroStatusBar1.DragDropSupport = True
        Me.MetroStatusBar1.Font = New System.Drawing.Font("Segoe UI", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MetroStatusBar1.ForeColor = System.Drawing.Color.Black
        Me.MetroStatusBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Lbl_Tiempo})
        Me.MetroStatusBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MetroStatusBar1.Location = New System.Drawing.Point(0, 247)
        Me.MetroStatusBar1.Name = "MetroStatusBar1"
        Me.MetroStatusBar1.Size = New System.Drawing.Size(324, 22)
        Me.MetroStatusBar1.TabIndex = 100
        Me.MetroStatusBar1.Text = "MetroStatusBar1"
        '
        'Lbl_Tiempo
        '
        Me.Lbl_Tiempo.Name = "Lbl_Tiempo"
        Me.Lbl_Tiempo.Text = "Tiempo transcurrido:"
        '
        'Tiempo
        '
        '
        'Frm_Inf_Ventas_X_Periodo_Fechas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(324, 269)
        Me.Controls.Add(Me.Lbl_Doc_Insert)
        Me.Controls.Add(Me.Progreso_Cont_Productos)
        Me.Controls.Add(Me.Lbl_Estado)
        Me.Controls.Add(Me.Progreso_Porc)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.Grupo_Fechas)
        Me.Controls.Add(Me.MetroStatusBar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Inf_Ventas_X_Periodo_Fechas"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " "
        Me.Grupo_Fechas.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.Dtp_Fecha_Desde, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_Fecha_Hasta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Grupo_Fechas As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Lbl_FS_desde As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dtp_Fecha_Desde As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Lbl_FS_hasta As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dtp_Fecha_Hasta As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Filtrar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Progreso_Porc As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Lbl_Estado As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Cancelar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Progreso_Cont_Productos As DevComponents.DotNetBar.Controls.ProgressBarX
    Friend WithEvents Lbl_Doc_Insert As DevComponents.DotNetBar.LabelX
    Friend WithEvents MetroStatusBar1 As DevComponents.DotNetBar.Metro.MetroStatusBar
    Friend WithEvents Lbl_Tiempo As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Tiempo As Timer
    Friend WithEvents Btn_Actualizar_Indices As DevComponents.DotNetBar.ButtonItem
End Class
