<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_InfoEnt_Ficha_Aseguradora
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_InfoEnt_Ficha_Aseguradora))
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Editar = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Num_Monto_Asignado = New System.Windows.Forms.NumericUpDown()
        Me.Num_Porc_Exposicion = New System.Windows.Forms.NumericUpDown()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.Cmb_Clascrediticia = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Razon = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Rut = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Cmb_Moneda = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_Fecha_Vigencia = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Txt_Monto_Asignado = New DevComponents.DotNetBar.Controls.TextBoxX()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.Num_Monto_Asignado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Num_Porc_Exposicion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_Fecha_Vigencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar, Me.Btn_Editar})
        Me.Bar2.Location = New System.Drawing.Point(0, 265)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(621, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 12
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Text = "Grabar"
        '
        'Btn_Editar
        '
        Me.Btn_Editar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Editar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Editar.Image = CType(resources.GetObject("Btn_Editar.Image"), System.Drawing.Image)
        Me.Btn_Editar.Name = "Btn_Editar"
        Me.Btn_Editar.Text = "Editar"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(599, 218)
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
        Me.GroupPanel1.TabIndex = 13
        Me.GroupPanel1.Text = "Información"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.7676!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.2324!))
        Me.TableLayoutPanel1.Controls.Add(Me.Num_Monto_Asignado, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Num_Porc_Exposicion, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX7, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX6, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Cmb_Clascrediticia, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX4, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Razon, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Rut, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cmb_Moneda, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX5, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Dtp_Fecha_Vigencia, 1, 5)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 12)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 7
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(568, 180)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'Num_Monto_Asignado
        '
        Me.Num_Monto_Asignado.BackColor = System.Drawing.Color.White
        Me.Num_Monto_Asignado.DecimalPlaces = 2
        Me.Num_Monto_Asignado.ForeColor = System.Drawing.Color.Black
        Me.Num_Monto_Asignado.Location = New System.Drawing.Point(137, 78)
        Me.Num_Monto_Asignado.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.Num_Monto_Asignado.Name = "Num_Monto_Asignado"
        Me.Num_Monto_Asignado.Size = New System.Drawing.Size(100, 22)
        Me.Num_Monto_Asignado.TabIndex = 14
        Me.Num_Monto_Asignado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Num_Monto_Asignado.ThousandsSeparator = True
        Me.Num_Monto_Asignado.Value = New Decimal(New Integer() {1000000, 0, 0, 0})
        '
        'Num_Porc_Exposicion
        '
        Me.Num_Porc_Exposicion.BackColor = System.Drawing.Color.White
        Me.Num_Porc_Exposicion.DecimalPlaces = 2
        Me.Num_Porc_Exposicion.ForeColor = System.Drawing.Color.Black
        Me.Num_Porc_Exposicion.Location = New System.Drawing.Point(137, 153)
        Me.Num_Porc_Exposicion.Name = "Num_Porc_Exposicion"
        Me.Num_Porc_Exposicion.Size = New System.Drawing.Size(100, 22)
        Me.Num_Porc_Exposicion.TabIndex = 3
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.ForeColor = System.Drawing.Color.Black
        Me.LabelX7.Location = New System.Drawing.Point(3, 153)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(100, 22)
        Me.LabelX7.TabIndex = 7
        Me.LabelX7.Text = "Porc. no cubierto %"
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(3, 103)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(128, 19)
        Me.LabelX6.TabIndex = 6
        Me.LabelX6.Text = "Clasificación crediticia"
        '
        'Cmb_Clascrediticia
        '
        Me.Cmb_Clascrediticia.DisplayMember = "Text"
        Me.Cmb_Clascrediticia.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Clascrediticia.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Clascrediticia.FormattingEnabled = True
        Me.Cmb_Clascrediticia.ItemHeight = 16
        Me.Cmb_Clascrediticia.Location = New System.Drawing.Point(137, 103)
        Me.Cmb_Clascrediticia.Name = "Cmb_Clascrediticia"
        Me.Cmb_Clascrediticia.Size = New System.Drawing.Size(214, 22)
        Me.Cmb_Clascrediticia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Clascrediticia.TabIndex = 14
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(3, 78)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(100, 19)
        Me.LabelX4.TabIndex = 5
        Me.LabelX4.Text = "Monto asignado"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(3, 53)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(100, 19)
        Me.LabelX3.TabIndex = 4
        Me.LabelX3.Text = "Moneda"
        '
        'Txt_Razon
        '
        Me.Txt_Razon.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Razon.Border.Class = "TextBoxBorder"
        Me.Txt_Razon.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Razon.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Razon.ForeColor = System.Drawing.Color.Black
        Me.Txt_Razon.Location = New System.Drawing.Point(137, 28)
        Me.Txt_Razon.Name = "Txt_Razon"
        Me.Txt_Razon.PreventEnterBeep = True
        Me.Txt_Razon.ReadOnly = True
        Me.Txt_Razon.Size = New System.Drawing.Size(428, 22)
        Me.Txt_Razon.TabIndex = 3
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 28)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(100, 19)
        Me.LabelX2.TabIndex = 3
        Me.LabelX2.Text = "Razón Social"
        '
        'Txt_Rut
        '
        Me.Txt_Rut.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Rut.Border.Class = "TextBoxBorder"
        Me.Txt_Rut.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Rut.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Rut.ForeColor = System.Drawing.Color.Black
        Me.Txt_Rut.Location = New System.Drawing.Point(137, 3)
        Me.Txt_Rut.Name = "Txt_Rut"
        Me.Txt_Rut.PreventEnterBeep = True
        Me.Txt_Rut.ReadOnly = True
        Me.Txt_Rut.Size = New System.Drawing.Size(100, 22)
        Me.Txt_Rut.TabIndex = 1
        '
        'Cmb_Moneda
        '
        Me.Cmb_Moneda.DisplayMember = "Text"
        Me.Cmb_Moneda.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Moneda.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Moneda.FormattingEnabled = True
        Me.Cmb_Moneda.ItemHeight = 16
        Me.Cmb_Moneda.Location = New System.Drawing.Point(137, 53)
        Me.Cmb_Moneda.Name = "Cmb_Moneda"
        Me.Cmb_Moneda.Size = New System.Drawing.Size(214, 22)
        Me.Cmb_Moneda.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Moneda.TabIndex = 3
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(100, 19)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "Rut"
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(3, 128)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(100, 19)
        Me.LabelX5.TabIndex = 6
        Me.LabelX5.Text = "Fecha vigencia"
        '
        'Dtp_Fecha_Vigencia
        '
        '
        '
        '
        Me.Dtp_Fecha_Vigencia.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Vigencia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Vigencia.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Vigencia.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Vigencia.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Vigencia.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Vigencia.Location = New System.Drawing.Point(137, 128)
        '
        '
        '
        Me.Dtp_Fecha_Vigencia.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Vigencia.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Vigencia.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Vigencia.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Vigencia.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Vigencia.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Vigencia.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Vigencia.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Vigencia.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Vigencia.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Vigencia.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Vigencia.MonthCalendar.DisplayMonth = New Date(2017, 9, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Vigencia.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Vigencia.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Vigencia.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Vigencia.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Vigencia.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Vigencia.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Vigencia.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Vigencia.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Vigencia.Name = "Dtp_Fecha_Vigencia"
        Me.Dtp_Fecha_Vigencia.Size = New System.Drawing.Size(100, 22)
        Me.Dtp_Fecha_Vigencia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Vigencia.TabIndex = 3
        '
        'Txt_Monto_Asignado
        '
        Me.Txt_Monto_Asignado.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Monto_Asignado.Border.Class = "TextBoxBorder"
        Me.Txt_Monto_Asignado.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Monto_Asignado.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Monto_Asignado.ForeColor = System.Drawing.Color.Black
        Me.Txt_Monto_Asignado.Location = New System.Drawing.Point(106, 236)
        Me.Txt_Monto_Asignado.Name = "Txt_Monto_Asignado"
        Me.Txt_Monto_Asignado.PreventEnterBeep = True
        Me.Txt_Monto_Asignado.Size = New System.Drawing.Size(100, 22)
        Me.Txt_Monto_Asignado.TabIndex = 3
        Me.Txt_Monto_Asignado.Visible = False
        '
        'Frm_InfoEnt_Ficha_Aseguradora
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(621, 306)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.Txt_Monto_Asignado)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_InfoEnt_Ficha_Aseguradora"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ficha de aseguradora de la entidad"
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.Num_Monto_Asignado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Num_Porc_Exposicion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_Fecha_Vigencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Public WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Monto_Asignado As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Razon As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Rut As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Cmb_Moneda As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Dtp_Fecha_Vigencia As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Cmb_Clascrediticia As DevComponents.DotNetBar.Controls.ComboBoxEx
    Public WithEvents Btn_Editar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Num_Porc_Exposicion As System.Windows.Forms.NumericUpDown
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Num_Monto_Asignado As System.Windows.Forms.NumericUpDown
End Class
