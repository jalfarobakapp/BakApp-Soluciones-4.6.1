<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Pagos_Masivos_Transferencia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Pagos_Masivos_Transferencia))
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Pagar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Generar_Archivo = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_Fecha_Emision = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Cmb_Emdp = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Txt_NroTransferencia = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Cmb_Medio_Pago_Proveedor = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Total_a_pagar = New DevComponents.DotNetBar.Controls.TextBoxX()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.Dtp_Fecha_Emision, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Pagar, Me.Btn_Generar_Archivo})
        Me.Bar1.Location = New System.Drawing.Point(0, 192)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(511, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 36
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Pagar
        '
        Me.Btn_Pagar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Pagar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Pagar.Image = CType(resources.GetObject("Btn_Pagar.Image"), System.Drawing.Image)
        Me.Btn_Pagar.Name = "Btn_Pagar"
        Me.Btn_Pagar.Text = "Realizar pago"
        '
        'Btn_Generar_Archivo
        '
        Me.Btn_Generar_Archivo.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Generar_Archivo.ForeColor = System.Drawing.Color.Black
        Me.Btn_Generar_Archivo.Image = CType(resources.GetObject("Btn_Generar_Archivo.Image"), System.Drawing.Image)
        Me.Btn_Generar_Archivo.Name = "Btn_Generar_Archivo"
        Me.Btn_Generar_Archivo.Text = "Generar archivo de exportación"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(11, 12)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(488, 162)
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
        Me.GroupPanel1.TabIndex = 37
        Me.GroupPanel1.Text = "Identificación de documento de pago"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.48826!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.51174!))
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX4, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX5, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Dtp_Fecha_Emision, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Cmb_Emdp, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_NroTransferencia, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cmb_Medio_Pago_Proveedor, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Total_a_pagar, 1, 4)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(474, 133)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(3, 81)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(195, 20)
        Me.LabelX4.TabIndex = 5
        Me.LabelX4.Text = "Medio de pago al proveedor"
        Me.LabelX4.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(3, 107)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(195, 22)
        Me.LabelX5.TabIndex = 6
        Me.LabelX5.Text = "Monto total a pagar "
        Me.LabelX5.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Dtp_Fecha_Emision
        '
        '
        '
        '
        Me.Dtp_Fecha_Emision.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Emision.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Emision.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Emision.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Emision.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Emision.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Emision.Location = New System.Drawing.Point(204, 29)
        '
        '
        '
        Me.Dtp_Fecha_Emision.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Emision.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Emision.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Emision.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Emision.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Emision.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Emision.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Emision.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Emision.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Emision.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Emision.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Emision.MonthCalendar.DisplayMonth = New Date(2016, 3, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Emision.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_Fecha_Emision.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Emision.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Emision.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Emision.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Emision.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Emision.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Emision.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Emision.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Emision.Name = "Dtp_Fecha_Emision"
        Me.Dtp_Fecha_Emision.Size = New System.Drawing.Size(90, 22)
        Me.Dtp_Fecha_Emision.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Emision.TabIndex = 2
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(3, 55)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(195, 20)
        Me.LabelX3.TabIndex = 4
        Me.LabelX3.Text = "Número de la transferencia"
        Me.LabelX3.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Cmb_Emdp
        '
        Me.Cmb_Emdp.DisplayMember = "Text"
        Me.Cmb_Emdp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Emdp.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Emdp.FormattingEnabled = True
        Me.Cmb_Emdp.ItemHeight = 16
        Me.Cmb_Emdp.Location = New System.Drawing.Point(204, 3)
        Me.Cmb_Emdp.Name = "Cmb_Emdp"
        Me.Cmb_Emdp.Size = New System.Drawing.Size(267, 22)
        Me.Cmb_Emdp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Emdp.TabIndex = 0
        '
        'Txt_NroTransferencia
        '
        Me.Txt_NroTransferencia.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_NroTransferencia.Border.Class = "TextBoxBorder"
        Me.Txt_NroTransferencia.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_NroTransferencia.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_NroTransferencia.ForeColor = System.Drawing.Color.Black
        Me.Txt_NroTransferencia.Location = New System.Drawing.Point(204, 55)
        Me.Txt_NroTransferencia.MaxLength = 8
        Me.Txt_NroTransferencia.Name = "Txt_NroTransferencia"
        Me.Txt_NroTransferencia.PreventEnterBeep = True
        Me.Txt_NroTransferencia.Size = New System.Drawing.Size(121, 22)
        Me.Txt_NroTransferencia.TabIndex = 1
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
        Me.LabelX1.Size = New System.Drawing.Size(195, 20)
        Me.LabelX1.TabIndex = 2
        Me.LabelX1.Text = "Emisor de documento"
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Cmb_Medio_Pago_Proveedor
        '
        Me.Cmb_Medio_Pago_Proveedor.DisplayMember = "Text"
        Me.Cmb_Medio_Pago_Proveedor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Medio_Pago_Proveedor.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Medio_Pago_Proveedor.FormattingEnabled = True
        Me.Cmb_Medio_Pago_Proveedor.ItemHeight = 16
        Me.Cmb_Medio_Pago_Proveedor.Location = New System.Drawing.Point(204, 81)
        Me.Cmb_Medio_Pago_Proveedor.Name = "Cmb_Medio_Pago_Proveedor"
        Me.Cmb_Medio_Pago_Proveedor.Size = New System.Drawing.Size(267, 22)
        Me.Cmb_Medio_Pago_Proveedor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Medio_Pago_Proveedor.TabIndex = 3
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 29)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(195, 20)
        Me.LabelX2.TabIndex = 3
        Me.LabelX2.Text = "Fecha de la transferencia"
        Me.LabelX2.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Txt_Total_a_pagar
        '
        Me.Txt_Total_a_pagar.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Total_a_pagar.Border.Class = "TextBoxBorder"
        Me.Txt_Total_a_pagar.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Total_a_pagar.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Total_a_pagar.ForeColor = System.Drawing.Color.Black
        Me.Txt_Total_a_pagar.Location = New System.Drawing.Point(204, 107)
        Me.Txt_Total_a_pagar.Name = "Txt_Total_a_pagar"
        Me.Txt_Total_a_pagar.PreventEnterBeep = True
        Me.Txt_Total_a_pagar.ReadOnly = True
        Me.Txt_Total_a_pagar.Size = New System.Drawing.Size(121, 22)
        Me.Txt_Total_a_pagar.TabIndex = 7
        Me.Txt_Total_a_pagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Frm_Pagos_Masivos_Transferencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(511, 233)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Pagos_Masivos_Transferencia"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pago masivo con transferecia bancaria"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.Dtp_Fecha_Emision, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Public WithEvents Btn_Pagar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Cmb_Emdp As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dtp_Fecha_Emision As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_NroTransferencia As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Cmb_Medio_Pago_Proveedor As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Total_a_pagar As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Btn_Generar_Archivo As DevComponents.DotNetBar.ButtonItem
End Class
