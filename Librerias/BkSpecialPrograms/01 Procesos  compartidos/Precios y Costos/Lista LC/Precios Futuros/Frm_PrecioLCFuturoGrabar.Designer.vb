<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_PrecioLCFuturoGrabar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_PrecioLCFuturoGrabar))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_EditarFechaProgramacion = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Eliminar_Programa = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_ImprimirFlejes = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_EliminarMarcados = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_EliminarTodo = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla_Precios = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Txtcodigo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Dtp_FechaProgramada = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Chk_Seleccionar_Todo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla_Precios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_FechaProgramada, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar, Me.Btn_EditarFechaProgramacion, Me.Btn_Eliminar_Programa, Me.Btn_ImprimirFlejes})
        Me.Bar1.Location = New System.Drawing.Point(0, 302)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(683, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 68
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = Global.BkSpecialPrograms.My.Resources.Resources.save
        Me.Btn_Grabar.ImageAlt = CType(resources.GetObject("Btn_Grabar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Tooltip = "Grabar"
        '
        'Btn_EditarFechaProgramacion
        '
        Me.Btn_EditarFechaProgramacion.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_EditarFechaProgramacion.ForeColor = System.Drawing.Color.Black
        Me.Btn_EditarFechaProgramacion.Image = CType(resources.GetObject("Btn_EditarFechaProgramacion.Image"), System.Drawing.Image)
        Me.Btn_EditarFechaProgramacion.ImageAlt = CType(resources.GetObject("Btn_EditarFechaProgramacion.ImageAlt"), System.Drawing.Image)
        Me.Btn_EditarFechaProgramacion.Name = "Btn_EditarFechaProgramacion"
        Me.Btn_EditarFechaProgramacion.Tooltip = "Editar fecha de programación"
        '
        'Btn_Eliminar_Programa
        '
        Me.Btn_Eliminar_Programa.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Eliminar_Programa.ForeColor = System.Drawing.Color.Black
        Me.Btn_Eliminar_Programa.Image = CType(resources.GetObject("Btn_Eliminar_Programa.Image"), System.Drawing.Image)
        Me.Btn_Eliminar_Programa.ImageAlt = CType(resources.GetObject("Btn_Eliminar_Programa.ImageAlt"), System.Drawing.Image)
        Me.Btn_Eliminar_Programa.Name = "Btn_Eliminar_Programa"
        Me.Btn_Eliminar_Programa.Tooltip = "Eliminar programación"
        '
        'Btn_ImprimirFlejes
        '
        Me.Btn_ImprimirFlejes.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_ImprimirFlejes.ForeColor = System.Drawing.Color.Black
        Me.Btn_ImprimirFlejes.Image = CType(resources.GetObject("Btn_ImprimirFlejes.Image"), System.Drawing.Image)
        Me.Btn_ImprimirFlejes.ImageAlt = CType(resources.GetObject("Btn_ImprimirFlejes.ImageAlt"), System.Drawing.Image)
        Me.Btn_ImprimirFlejes.Name = "Btn_ImprimirFlejes"
        Me.Btn_ImprimirFlejes.Text = "Imprimir flejes"
        Me.Btn_ImprimirFlejes.Visible = False
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.ContextMenuBar1)
        Me.GroupPanel1.Controls.Add(Me.Grilla_Precios)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(2, 33)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(678, 233)
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
        Me.GroupPanel1.TabIndex = 67
        Me.GroupPanel1.Text = "Detalles Lista"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(69, 51)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(319, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 29
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual
        '
        Me.Menu_Contextual.AutoExpandOnClick = True
        Me.Menu_Contextual.Name = "Menu_Contextual"
        Me.Menu_Contextual.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_EliminarMarcados, Me.Btn_EliminarTodo})
        Me.Menu_Contextual.Text = "Menu Grabar"
        '
        'Btn_EliminarMarcados
        '
        Me.Btn_EliminarMarcados.Image = CType(resources.GetObject("Btn_EliminarMarcados.Image"), System.Drawing.Image)
        Me.Btn_EliminarMarcados.ImageAlt = CType(resources.GetObject("Btn_EliminarMarcados.ImageAlt"), System.Drawing.Image)
        Me.Btn_EliminarMarcados.Name = "Btn_EliminarMarcados"
        Me.Btn_EliminarMarcados.Text = "Eliminar solo marcados"
        '
        'Btn_EliminarTodo
        '
        Me.Btn_EliminarTodo.Image = CType(resources.GetObject("Btn_EliminarTodo.Image"), System.Drawing.Image)
        Me.Btn_EliminarTodo.ImageAlt = CType(resources.GetObject("Btn_EliminarTodo.ImageAlt"), System.Drawing.Image)
        Me.Btn_EliminarTodo.Name = "Btn_EliminarTodo"
        Me.Btn_EliminarTodo.Text = "Eliminar toda la programación"
        '
        'Grilla_Precios
        '
        Me.Grilla_Precios.AllowUserToAddRows = False
        Me.Grilla_Precios.AllowUserToDeleteRows = False
        Me.Grilla_Precios.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Precios.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Grilla_Precios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Precios.DefaultCellStyle = DataGridViewCellStyle5
        Me.Grilla_Precios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Precios.EnableHeadersVisualStyles = False
        Me.Grilla_Precios.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Precios.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Precios.Name = "Grilla_Precios"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Precios.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Grilla_Precios.Size = New System.Drawing.Size(672, 210)
        Me.Grilla_Precios.StandardTab = True
        Me.Grilla_Precios.TabIndex = 28
        '
        'Txtcodigo
        '
        Me.Txtcodigo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txtcodigo.Border.Class = "TextBoxBorder"
        Me.Txtcodigo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txtcodigo.DisabledBackColor = System.Drawing.Color.White
        Me.Txtcodigo.ForeColor = System.Drawing.Color.Black
        Me.Txtcodigo.Location = New System.Drawing.Point(53, 4)
        Me.Txtcodigo.Name = "Txtcodigo"
        Me.Txtcodigo.PreventEnterBeep = True
        Me.Txtcodigo.ReadOnly = True
        Me.Txtcodigo.Size = New System.Drawing.Size(440, 22)
        Me.Txtcodigo.TabIndex = 72
        '
        'Dtp_FechaProgramada
        '
        Me.Dtp_FechaProgramada.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_FechaProgramada.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_FechaProgramada.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaProgramada.ButtonCustom.Image = CType(resources.GetObject("Dtp_FechaProgramada.ButtonCustom.Image"), System.Drawing.Image)
        Me.Dtp_FechaProgramada.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_FechaProgramada.ButtonDropDown.Visible = True
        Me.Dtp_FechaProgramada.ForeColor = System.Drawing.Color.Black
        Me.Dtp_FechaProgramada.IsPopupCalendarOpen = False
        Me.Dtp_FechaProgramada.Location = New System.Drawing.Point(598, 4)
        '
        '
        '
        Me.Dtp_FechaProgramada.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FechaProgramada.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaProgramada.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_FechaProgramada.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_FechaProgramada.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_FechaProgramada.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FechaProgramada.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_FechaProgramada.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_FechaProgramada.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_FechaProgramada.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_FechaProgramada.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaProgramada.MonthCalendar.DisplayMonth = New Date(2022, 10, 1, 0, 0, 0, 0)
        Me.Dtp_FechaProgramada.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_FechaProgramada.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_FechaProgramada.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FechaProgramada.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_FechaProgramada.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FechaProgramada.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_FechaProgramada.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaProgramada.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_FechaProgramada.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_FechaProgramada.Name = "Dtp_FechaProgramada"
        Me.Dtp_FechaProgramada.Size = New System.Drawing.Size(82, 22)
        Me.Dtp_FechaProgramada.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_FechaProgramada.TabIndex = 73
        Me.Dtp_FechaProgramada.Value = New Date(2022, 10, 26, 13, 58, 51, 0)
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(2, 4)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(45, 23)
        Me.LabelX1.TabIndex = 74
        Me.LabelX1.Text = "Producto"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(499, 3)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(93, 23)
        Me.LabelX2.TabIndex = 75
        Me.LabelX2.Text = "Fecha programada"
        '
        'Chk_Seleccionar_Todo
        '
        Me.Chk_Seleccionar_Todo.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.Chk_Seleccionar_Todo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Seleccionar_Todo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Seleccionar_Todo.CheckBoxImageChecked = CType(resources.GetObject("Chk_Seleccionar_Todo.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Seleccionar_Todo.CheckBoxImageUnChecked = CType(resources.GetObject("Chk_Seleccionar_Todo.CheckBoxImageUnChecked"), System.Drawing.Image)
        Me.Chk_Seleccionar_Todo.FocusCuesEnabled = False
        Me.Chk_Seleccionar_Todo.ForeColor = System.Drawing.Color.Black
        Me.Chk_Seleccionar_Todo.Location = New System.Drawing.Point(2, 272)
        Me.Chk_Seleccionar_Todo.Name = "Chk_Seleccionar_Todo"
        Me.Chk_Seleccionar_Todo.Size = New System.Drawing.Size(117, 19)
        Me.Chk_Seleccionar_Todo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Seleccionar_Todo.TabIndex = 76
        Me.Chk_Seleccionar_Todo.TabStop = False
        Me.Chk_Seleccionar_Todo.Text = "Seleccionar todo"
        '
        'Frm_PrecioLCFuturoGrabar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(683, 343)
        Me.Controls.Add(Me.Chk_Seleccionar_Todo)
        Me.Controls.Add(Me.Dtp_FechaProgramada)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Txtcodigo)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.GroupPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_PrecioLCFuturoGrabar"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Grabar precios al futuro"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla_Precios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_FechaProgramada, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_ImprimirFlejes As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grilla_Precios As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Txtcodigo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Dtp_FechaProgramada As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Eliminar_Programa As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_EditarFechaProgramacion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Chk_Seleccionar_Todo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_EliminarMarcados As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_EliminarTodo As DevComponents.DotNetBar.ButtonItem
End Class
