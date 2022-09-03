<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Demonio_01_Conf_Local_FH
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Demonio_01_Conf_Local_FH))
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.Chk_Cons_Stock_Domingo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Cons_Stock_Lunes = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Cons_Stock_Martes = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Cons_Stock_Miercoles = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Cons_Stock_Sabado = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Cons_Stock_Jueves = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Cons_Stock_Viernes = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Dtp_Cons_Stock_Hora_Ejecucion = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.BtnGrabar = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.Dtp_Cons_Stock_Hora_Ejecucion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.LabelX8)
        Me.GroupPanel1.Controls.Add(Me.TableLayoutPanel2)
        Me.GroupPanel1.Controls.Add(Me.Dtp_Cons_Stock_Hora_Ejecucion)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(7, 12)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(451, 91)
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
        Me.GroupPanel1.TabIndex = 0
        Me.GroupPanel1.Text = "GroupPanel1"
        '
        'LabelX8
        '
        Me.LabelX8.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.ForeColor = System.Drawing.Color.Black
        Me.LabelX8.Location = New System.Drawing.Point(3, 40)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(92, 21)
        Me.LabelX8.TabIndex = 39
        Me.LabelX8.Text = "Hora ejecución"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel2.ColumnCount = 8
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.77778!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.41667!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.64815!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.87963!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.953704!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.490741!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.490741!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111!))
        Me.TableLayoutPanel2.Controls.Add(Me.LabelX6, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Chk_Cons_Stock_Domingo, 7, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Chk_Cons_Stock_Lunes, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Chk_Cons_Stock_Martes, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Chk_Cons_Stock_Miercoles, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Chk_Cons_Stock_Sabado, 6, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Chk_Cons_Stock_Jueves, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Chk_Cons_Stock_Viernes, 5, 0)
        Me.TableLayoutPanel2.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(432, 31)
        Me.TableLayoutPanel2.TabIndex = 38
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(3, 3)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(114, 23)
        Me.LabelX6.TabIndex = 34
        Me.LabelX6.Text = "Repetir los días:"
        '
        'Chk_Cons_Stock_Domingo
        '
        Me.Chk_Cons_Stock_Domingo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Cons_Stock_Domingo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Cons_Stock_Domingo.ForeColor = System.Drawing.Color.Black
        Me.Chk_Cons_Stock_Domingo.Location = New System.Drawing.Point(386, 3)
        Me.Chk_Cons_Stock_Domingo.Name = "Chk_Cons_Stock_Domingo"
        Me.Chk_Cons_Stock_Domingo.Size = New System.Drawing.Size(43, 23)
        Me.Chk_Cons_Stock_Domingo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Cons_Stock_Domingo.TabIndex = 32
        Me.Chk_Cons_Stock_Domingo.Text = "Dom"
        '
        'Chk_Cons_Stock_Lunes
        '
        Me.Chk_Cons_Stock_Lunes.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Cons_Stock_Lunes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Cons_Stock_Lunes.ForeColor = System.Drawing.Color.Black
        Me.Chk_Cons_Stock_Lunes.Location = New System.Drawing.Point(123, 3)
        Me.Chk_Cons_Stock_Lunes.Name = "Chk_Cons_Stock_Lunes"
        Me.Chk_Cons_Stock_Lunes.Size = New System.Drawing.Size(37, 23)
        Me.Chk_Cons_Stock_Lunes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Cons_Stock_Lunes.TabIndex = 26
        Me.Chk_Cons_Stock_Lunes.Text = "Lun"
        '
        'Chk_Cons_Stock_Martes
        '
        Me.Chk_Cons_Stock_Martes.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Cons_Stock_Martes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Cons_Stock_Martes.ForeColor = System.Drawing.Color.Black
        Me.Chk_Cons_Stock_Martes.Location = New System.Drawing.Point(168, 3)
        Me.Chk_Cons_Stock_Martes.Name = "Chk_Cons_Stock_Martes"
        Me.Chk_Cons_Stock_Martes.Size = New System.Drawing.Size(37, 23)
        Me.Chk_Cons_Stock_Martes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Cons_Stock_Martes.TabIndex = 27
        Me.Chk_Cons_Stock_Martes.Text = "Mar"
        '
        'Chk_Cons_Stock_Miercoles
        '
        Me.Chk_Cons_Stock_Miercoles.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Cons_Stock_Miercoles.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Cons_Stock_Miercoles.ForeColor = System.Drawing.Color.Black
        Me.Chk_Cons_Stock_Miercoles.Location = New System.Drawing.Point(214, 3)
        Me.Chk_Cons_Stock_Miercoles.Name = "Chk_Cons_Stock_Miercoles"
        Me.Chk_Cons_Stock_Miercoles.Size = New System.Drawing.Size(37, 23)
        Me.Chk_Cons_Stock_Miercoles.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Cons_Stock_Miercoles.TabIndex = 28
        Me.Chk_Cons_Stock_Miercoles.Text = "Mie"
        '
        'Chk_Cons_Stock_Sabado
        '
        Me.Chk_Cons_Stock_Sabado.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Cons_Stock_Sabado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Cons_Stock_Sabado.ForeColor = System.Drawing.Color.Black
        Me.Chk_Cons_Stock_Sabado.Location = New System.Drawing.Point(345, 3)
        Me.Chk_Cons_Stock_Sabado.Name = "Chk_Cons_Stock_Sabado"
        Me.Chk_Cons_Stock_Sabado.Size = New System.Drawing.Size(35, 23)
        Me.Chk_Cons_Stock_Sabado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Cons_Stock_Sabado.TabIndex = 31
        Me.Chk_Cons_Stock_Sabado.Text = "Sab"
        '
        'Chk_Cons_Stock_Jueves
        '
        Me.Chk_Cons_Stock_Jueves.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Cons_Stock_Jueves.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Cons_Stock_Jueves.ForeColor = System.Drawing.Color.Black
        Me.Chk_Cons_Stock_Jueves.Location = New System.Drawing.Point(261, 3)
        Me.Chk_Cons_Stock_Jueves.Name = "Chk_Cons_Stock_Jueves"
        Me.Chk_Cons_Stock_Jueves.Size = New System.Drawing.Size(37, 23)
        Me.Chk_Cons_Stock_Jueves.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Cons_Stock_Jueves.TabIndex = 29
        Me.Chk_Cons_Stock_Jueves.Text = "Jue"
        '
        'Chk_Cons_Stock_Viernes
        '
        Me.Chk_Cons_Stock_Viernes.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Cons_Stock_Viernes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Cons_Stock_Viernes.ForeColor = System.Drawing.Color.Black
        Me.Chk_Cons_Stock_Viernes.Location = New System.Drawing.Point(304, 3)
        Me.Chk_Cons_Stock_Viernes.Name = "Chk_Cons_Stock_Viernes"
        Me.Chk_Cons_Stock_Viernes.Size = New System.Drawing.Size(35, 23)
        Me.Chk_Cons_Stock_Viernes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Cons_Stock_Viernes.TabIndex = 30
        Me.Chk_Cons_Stock_Viernes.Text = "Vie"
        '
        'Dtp_Cons_Stock_Hora_Ejecucion
        '
        Me.Dtp_Cons_Stock_Hora_Ejecucion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_Cons_Stock_Hora_Ejecucion.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Cons_Stock_Hora_Ejecucion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Cons_Stock_Hora_Ejecucion.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Cons_Stock_Hora_Ejecucion.ButtonDropDown.Visible = True
        Me.Dtp_Cons_Stock_Hora_Ejecucion.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Cons_Stock_Hora_Ejecucion.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime
        Me.Dtp_Cons_Stock_Hora_Ejecucion.IsPopupCalendarOpen = False
        Me.Dtp_Cons_Stock_Hora_Ejecucion.Location = New System.Drawing.Point(98, 40)
        '
        '
        '
        Me.Dtp_Cons_Stock_Hora_Ejecucion.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Cons_Stock_Hora_Ejecucion.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Cons_Stock_Hora_Ejecucion.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Cons_Stock_Hora_Ejecucion.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Cons_Stock_Hora_Ejecucion.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Cons_Stock_Hora_Ejecucion.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Cons_Stock_Hora_Ejecucion.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Cons_Stock_Hora_Ejecucion.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Cons_Stock_Hora_Ejecucion.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Cons_Stock_Hora_Ejecucion.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Cons_Stock_Hora_Ejecucion.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Cons_Stock_Hora_Ejecucion.MonthCalendar.DisplayMonth = New Date(2018, 11, 1, 0, 0, 0, 0)
        Me.Dtp_Cons_Stock_Hora_Ejecucion.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_Cons_Stock_Hora_Ejecucion.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Cons_Stock_Hora_Ejecucion.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Cons_Stock_Hora_Ejecucion.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Cons_Stock_Hora_Ejecucion.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Cons_Stock_Hora_Ejecucion.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Cons_Stock_Hora_Ejecucion.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Cons_Stock_Hora_Ejecucion.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Cons_Stock_Hora_Ejecucion.MonthCalendar.Visible = False
        Me.Dtp_Cons_Stock_Hora_Ejecucion.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Cons_Stock_Hora_Ejecucion.Name = "Dtp_Cons_Stock_Hora_Ejecucion"
        Me.Dtp_Cons_Stock_Hora_Ejecucion.Size = New System.Drawing.Size(62, 22)
        Me.Dtp_Cons_Stock_Hora_Ejecucion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Cons_Stock_Hora_Ejecucion.TabIndex = 37
        Me.Dtp_Cons_Stock_Hora_Ejecucion.TabStop = False
        Me.Dtp_Cons_Stock_Hora_Ejecucion.Value = New Date(2018, 11, 5, 16, 26, 11, 0)
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnGrabar})
        Me.Bar1.Location = New System.Drawing.Point(0, 115)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(465, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 117
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnGrabar
        '
        Me.BtnGrabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnGrabar.ForeColor = System.Drawing.Color.Black
        Me.BtnGrabar.Image = CType(resources.GetObject("BtnGrabar.Image"), System.Drawing.Image)
        Me.BtnGrabar.Name = "BtnGrabar"
        Me.BtnGrabar.Tooltip = "Grabar"
        '
        'Frm_Demonio_01_Conf_Local_FH
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(465, 156)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.GroupPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Demonio_01_Conf_Local_FH"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        Me.GroupPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.Dtp_Cons_Stock_Hora_Ejecucion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Chk_Cons_Stock_Domingo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Cons_Stock_Lunes As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Cons_Stock_Martes As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Cons_Stock_Miercoles As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Cons_Stock_Sabado As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Cons_Stock_Jueves As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Cons_Stock_Viernes As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Dtp_Cons_Stock_Hora_Ejecucion As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnGrabar As DevComponents.DotNetBar.ButtonItem
End Class
