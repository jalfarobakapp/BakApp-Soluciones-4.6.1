<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Recalculo_PPPxProd
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Recalculo_PPPxProd))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Progreso_XDetalle = New DevComponents.DotNetBar.Controls.ProgressBarX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Procesar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_TraerProductos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Limpiar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Cancelar = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_FechaTope = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.GroupPanel4 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Progreso_XProducto = New DevComponents.DotNetBar.Controls.ProgressBarX()
        Me.MetroStatusBar1 = New DevComponents.DotNetBar.Metro.MetroStatusBar()
        Me.Lbl_StatusBar = New DevComponents.DotNetBar.LabelItem()
        Me.Chk_ModoPruebas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_FechaTope, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel4.SuspendLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Progreso_XDetalle
        '
        Me.Progreso_XDetalle.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Progreso_XDetalle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Progreso_XDetalle.ForeColor = System.Drawing.Color.Black
        Me.Progreso_XDetalle.Location = New System.Drawing.Point(12, 469)
        Me.Progreso_XDetalle.Name = "Progreso_XDetalle"
        Me.Progreso_XDetalle.Size = New System.Drawing.Size(953, 23)
        Me.Progreso_XDetalle.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Progreso_XDetalle.TabIndex = 114
        Me.Progreso_XDetalle.Text = "0%"
        Me.Progreso_XDetalle.TextVisible = True
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Procesar, Me.Btn_TraerProductos, Me.Btn_Limpiar, Me.Btn_Cancelar})
        Me.Bar1.Location = New System.Drawing.Point(0, 533)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(977, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 113
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Procesar
        '
        Me.Btn_Procesar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Procesar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Procesar.Image = CType(resources.GetObject("Btn_Procesar.Image"), System.Drawing.Image)
        Me.Btn_Procesar.ImageAlt = CType(resources.GetObject("Btn_Procesar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Procesar.Name = "Btn_Procesar"
        Me.Btn_Procesar.Text = "Procesar"
        '
        'Btn_TraerProductos
        '
        Me.Btn_TraerProductos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_TraerProductos.ForeColor = System.Drawing.Color.Black
        Me.Btn_TraerProductos.Image = CType(resources.GetObject("Btn_TraerProductos.Image"), System.Drawing.Image)
        Me.Btn_TraerProductos.ImageAlt = CType(resources.GetObject("Btn_TraerProductos.ImageAlt"), System.Drawing.Image)
        Me.Btn_TraerProductos.Name = "Btn_TraerProductos"
        Me.Btn_TraerProductos.Tooltip = "Traer productos"
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
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Cancelar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Cancelar.Image = CType(resources.GetObject("Btn_Cancelar.Image"), System.Drawing.Image)
        Me.Btn_Cancelar.ImageAlt = CType(resources.GetObject("Btn_Cancelar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Tooltip = "Cancelar"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(11, 12)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(166, 23)
        Me.LabelX1.TabIndex = 116
        Me.LabelX1.Text = "Fecha de comienzo del recalculo"
        '
        'Dtp_FechaTope
        '
        Me.Dtp_FechaTope.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_FechaTope.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_FechaTope.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaTope.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_FechaTope.ForeColor = System.Drawing.Color.Black
        Me.Dtp_FechaTope.IsPopupCalendarOpen = False
        Me.Dtp_FechaTope.Location = New System.Drawing.Point(183, 12)
        '
        '
        '
        Me.Dtp_FechaTope.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FechaTope.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaTope.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_FechaTope.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_FechaTope.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_FechaTope.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FechaTope.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_FechaTope.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_FechaTope.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_FechaTope.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_FechaTope.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaTope.MonthCalendar.DisplayMonth = New Date(2022, 3, 1, 0, 0, 0, 0)
        Me.Dtp_FechaTope.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_FechaTope.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_FechaTope.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FechaTope.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_FechaTope.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FechaTope.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_FechaTope.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaTope.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_FechaTope.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_FechaTope.Name = "Dtp_FechaTope"
        Me.Dtp_FechaTope.Size = New System.Drawing.Size(77, 22)
        Me.Dtp_FechaTope.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_FechaTope.TabIndex = 119
        Me.Dtp_FechaTope.Value = New Date(2022, 3, 18, 10, 52, 43, 0)
        '
        'GroupPanel4
        '
        Me.GroupPanel4.BackColor = System.Drawing.Color.White
        Me.GroupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel4.Controls.Add(Me.Grilla)
        Me.GroupPanel4.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel4.Location = New System.Drawing.Point(11, 41)
        Me.GroupPanel4.Name = "GroupPanel4"
        Me.GroupPanel4.Size = New System.Drawing.Size(954, 422)
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
        Me.GroupPanel4.TabIndex = 167
        Me.GroupPanel4.Text = "Productos"
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.AllowUserToDeleteRows = False
        Me.Grilla.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
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
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
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
        Me.Grilla.Size = New System.Drawing.Size(948, 399)
        Me.Grilla.StandardTab = True
        Me.Grilla.TabIndex = 166
        '
        'Progreso_XProducto
        '
        Me.Progreso_XProducto.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Progreso_XProducto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Progreso_XProducto.ForeColor = System.Drawing.Color.Black
        Me.Progreso_XProducto.Location = New System.Drawing.Point(12, 498)
        Me.Progreso_XProducto.Name = "Progreso_XProducto"
        Me.Progreso_XProducto.Size = New System.Drawing.Size(953, 23)
        Me.Progreso_XProducto.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Progreso_XProducto.TabIndex = 168
        Me.Progreso_XProducto.Text = "0%"
        Me.Progreso_XProducto.TextVisible = True
        Me.Progreso_XProducto.Visible = False
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
        Me.MetroStatusBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Lbl_StatusBar})
        Me.MetroStatusBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MetroStatusBar1.Location = New System.Drawing.Point(0, 574)
        Me.MetroStatusBar1.Name = "MetroStatusBar1"
        Me.MetroStatusBar1.Size = New System.Drawing.Size(977, 22)
        Me.MetroStatusBar1.TabIndex = 170
        '
        'Lbl_StatusBar
        '
        Me.Lbl_StatusBar.Name = "Lbl_StatusBar"
        Me.Lbl_StatusBar.Text = "Bakapp Soluciones"
        '
        'Chk_ModoPruebas
        '
        Me.Chk_ModoPruebas.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_ModoPruebas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_ModoPruebas.CheckBoxImageChecked = CType(resources.GetObject("Chk_ModoPruebas.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_ModoPruebas.FocusCuesEnabled = False
        Me.Chk_ModoPruebas.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Chk_ModoPruebas.ForeColor = System.Drawing.Color.Black
        Me.Chk_ModoPruebas.Location = New System.Drawing.Point(734, 16)
        Me.Chk_ModoPruebas.Name = "Chk_ModoPruebas"
        Me.Chk_ModoPruebas.Size = New System.Drawing.Size(231, 19)
        Me.Chk_ModoPruebas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_ModoPruebas.TabIndex = 171
        Me.Chk_ModoPruebas.Text = "Modo pruebas"
        '
        'Frm_Recalculo_PPPxProd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(977, 596)
        Me.Controls.Add(Me.Chk_ModoPruebas)
        Me.Controls.Add(Me.Progreso_XProducto)
        Me.Controls.Add(Me.GroupPanel4)
        Me.Controls.Add(Me.Dtp_FechaTope)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Progreso_XDetalle)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.MetroStatusBar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Recalculo_PPPxProd"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RECALCULO DEL PRECIO PROMEDIO PONDERADO POR PRODUCTO"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_FechaTope, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel4.ResumeLayout(False)
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Progreso_XDetalle As DevComponents.DotNetBar.Controls.ProgressBarX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Cancelar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dtp_FechaTope As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents GroupPanel4 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Btn_Procesar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_TraerProductos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Progreso_XProducto As DevComponents.DotNetBar.Controls.ProgressBarX
    Friend WithEvents MetroStatusBar1 As DevComponents.DotNetBar.Metro.MetroStatusBar
    Friend WithEvents Lbl_StatusBar As DevComponents.DotNetBar.LabelItem
    Public WithEvents Btn_Limpiar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Chk_ModoPruebas As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
