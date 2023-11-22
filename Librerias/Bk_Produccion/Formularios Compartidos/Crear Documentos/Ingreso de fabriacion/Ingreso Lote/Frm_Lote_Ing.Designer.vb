<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Lote_Ing
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Lote_Ing))
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Grupo_Producto = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_FechaVenci = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Txt_NroLote = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Producto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_CodAlternativo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_Producto.SuspendLayout()
        CType(Me.Dtp_FechaVenci, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar})
        Me.Bar1.Location = New System.Drawing.Point(0, 151)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(827, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 100
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Tooltip = "Seleccionar registro marcado"
        '
        'Grupo_Producto
        '
        Me.Grupo_Producto.BackColor = System.Drawing.Color.White
        Me.Grupo_Producto.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Producto.Controls.Add(Me.Txt_CodAlternativo)
        Me.Grupo_Producto.Controls.Add(Me.LabelX13)
        Me.Grupo_Producto.Controls.Add(Me.LabelX4)
        Me.Grupo_Producto.Controls.Add(Me.Dtp_FechaVenci)
        Me.Grupo_Producto.Controls.Add(Me.Txt_NroLote)
        Me.Grupo_Producto.Controls.Add(Me.LabelX2)
        Me.Grupo_Producto.Controls.Add(Me.Txt_Producto)
        Me.Grupo_Producto.Controls.Add(Me.LabelX1)
        Me.Grupo_Producto.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Producto.Location = New System.Drawing.Point(12, 12)
        Me.Grupo_Producto.Name = "Grupo_Producto"
        Me.Grupo_Producto.Size = New System.Drawing.Size(802, 130)
        '
        '
        '
        Me.Grupo_Producto.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Producto.Style.BackColorGradientAngle = 90
        Me.Grupo_Producto.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Producto.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Producto.Style.BorderBottomWidth = 1
        Me.Grupo_Producto.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Producto.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Producto.Style.BorderLeftWidth = 1
        Me.Grupo_Producto.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Producto.Style.BorderRightWidth = 1
        Me.Grupo_Producto.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Producto.Style.BorderTopWidth = 1
        Me.Grupo_Producto.Style.CornerDiameter = 4
        Me.Grupo_Producto.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Producto.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Producto.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Producto.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Producto.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Producto.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Producto.TabIndex = 101
        Me.Grupo_Producto.Text = "Detalle"
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(457, 13)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(89, 23)
        Me.LabelX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX4.TabIndex = 97
        Me.LabelX4.Text = "FECHA VENC."
        '
        'Dtp_FechaVenci
        '
        Me.Dtp_FechaVenci.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_FechaVenci.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_FechaVenci.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaVenci.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_FechaVenci.ButtonDropDown.Visible = True
        Me.Dtp_FechaVenci.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dtp_FechaVenci.ForeColor = System.Drawing.Color.Black
        Me.Dtp_FechaVenci.Format = DevComponents.Editors.eDateTimePickerFormat.[Long]
        Me.Dtp_FechaVenci.IsPopupCalendarOpen = False
        Me.Dtp_FechaVenci.Location = New System.Drawing.Point(552, 11)
        '
        '
        '
        Me.Dtp_FechaVenci.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FechaVenci.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaVenci.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_FechaVenci.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_FechaVenci.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_FechaVenci.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FechaVenci.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_FechaVenci.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_FechaVenci.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_FechaVenci.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_FechaVenci.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaVenci.MonthCalendar.DisplayMonth = New Date(2018, 1, 1, 0, 0, 0, 0)
        Me.Dtp_FechaVenci.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_FechaVenci.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_FechaVenci.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FechaVenci.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_FechaVenci.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FechaVenci.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_FechaVenci.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaVenci.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_FechaVenci.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_FechaVenci.Name = "Dtp_FechaVenci"
        Me.Dtp_FechaVenci.Size = New System.Drawing.Size(238, 25)
        Me.Dtp_FechaVenci.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_FechaVenci.TabIndex = 96
        Me.Dtp_FechaVenci.TabStop = False
        Me.Dtp_FechaVenci.Value = New Date(2018, 1, 30, 12, 16, 22, 0)
        '
        'Txt_NroLote
        '
        Me.Txt_NroLote.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_NroLote.Border.Class = "TextBoxBorder"
        Me.Txt_NroLote.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_NroLote.ButtonCustom.Image = CType(resources.GetObject("Txt_NroLote.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_NroLote.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_NroLote.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_NroLote.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_NroLote.ForeColor = System.Drawing.Color.Black
        Me.Txt_NroLote.Location = New System.Drawing.Point(98, 13)
        Me.Txt_NroLote.MaxLength = 13
        Me.Txt_NroLote.Name = "Txt_NroLote"
        Me.Txt_NroLote.ReadOnly = True
        Me.Txt_NroLote.Size = New System.Drawing.Size(182, 26)
        Me.Txt_NroLote.TabIndex = 76
        Me.Txt_NroLote.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 13)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(71, 23)
        Me.LabelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX2.TabIndex = 77
        Me.LabelX2.Text = "NRO. LOTE"
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
        Me.Txt_Producto.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Producto.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Producto.ForeColor = System.Drawing.Color.Black
        Me.Txt_Producto.Location = New System.Drawing.Point(98, 45)
        Me.Txt_Producto.MaxLength = 50
        Me.Txt_Producto.Name = "Txt_Producto"
        Me.Txt_Producto.ReadOnly = True
        Me.Txt_Producto.Size = New System.Drawing.Size(692, 26)
        Me.Txt_Producto.TabIndex = 3
        Me.Txt_Producto.TabStop = False
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 45)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(71, 23)
        Me.LabelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX1.TabIndex = 75
        Me.LabelX1.Text = "PRODUCTO"
        '
        'Txt_CodAlternativo
        '
        Me.Txt_CodAlternativo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_CodAlternativo.Border.Class = "TextBoxBorder"
        Me.Txt_CodAlternativo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_CodAlternativo.ButtonCustom.Image = CType(resources.GetObject("Txt_CodAlternativo_Pallet.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_CodAlternativo.ButtonCustom.Visible = True
        Me.Txt_CodAlternativo.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_CodAlternativo.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_CodAlternativo.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_CodAlternativo.ForeColor = System.Drawing.Color.Black
        Me.Txt_CodAlternativo.Location = New System.Drawing.Point(98, 77)
        Me.Txt_CodAlternativo.MaxLength = 13
        Me.Txt_CodAlternativo.Name = "Txt_CodAlternativo"
        Me.Txt_CodAlternativo.ReadOnly = True
        Me.Txt_CodAlternativo.Size = New System.Drawing.Size(692, 26)
        Me.Txt_CodAlternativo.TabIndex = 98
        '
        'LabelX13
        '
        Me.LabelX13.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX13.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX13.ForeColor = System.Drawing.Color.Black
        Me.LabelX13.Location = New System.Drawing.Point(3, 77)
        Me.LabelX13.Name = "LabelX13"
        Me.LabelX13.Size = New System.Drawing.Size(89, 23)
        Me.LabelX13.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX13.TabIndex = 99
        Me.LabelX13.Text = "ALTERNATIVO"
        '
        'Frm_Lote_Ing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(827, 192)
        Me.Controls.Add(Me.Grupo_Producto)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Lote_Ing"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "INGRESO DE NUMERO DE LOTE"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo_Producto.ResumeLayout(False)
        CType(Me.Dtp_FechaVenci, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Public WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grupo_Producto As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Txt_Producto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_NroLote As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dtp_FechaVenci As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Public WithEvents Txt_CodAlternativo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
End Class
