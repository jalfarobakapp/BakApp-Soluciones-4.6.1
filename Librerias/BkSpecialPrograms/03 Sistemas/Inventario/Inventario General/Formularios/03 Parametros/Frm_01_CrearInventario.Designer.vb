<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_01_CrearInventario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_01_CrearInventario))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Bodega = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Sucursal = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Empresa = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.BtnGrabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_FotoStock = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_TomarFotoStock = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_EliminarFotoStock = New DevComponents.DotNetBar.ButtonItem()
        Me.Txt_NombreInventario = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Chk_Estado = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Dtp_Fecha_Inventario = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Txt_FuncCargo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_Fecha_Inventario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.00533!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.99467!))
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX5, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_Bodega, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_Sucursal, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX4, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_Empresa, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX2, 0, 0)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 6)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(565, 70)
        Me.TableLayoutPanel1.TabIndex = 26
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(4, 50)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(75, 14)
        Me.LabelX5.TabIndex = 5
        Me.LabelX5.Text = "Bodega"
        '
        'Lbl_Bodega
        '
        '
        '
        '
        Me.Lbl_Bodega.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Bodega.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Bodega.Location = New System.Drawing.Point(111, 50)
        Me.Lbl_Bodega.Name = "Lbl_Bodega"
        Me.Lbl_Bodega.Size = New System.Drawing.Size(75, 14)
        Me.Lbl_Bodega.TabIndex = 4
        Me.Lbl_Bodega.Text = "Sucursal"
        '
        'Lbl_Sucursal
        '
        Me.Lbl_Sucursal.AutoSize = True
        '
        '
        '
        Me.Lbl_Sucursal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Sucursal.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Sucursal.Location = New System.Drawing.Point(111, 27)
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
        Me.LabelX4.Location = New System.Drawing.Point(4, 27)
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
        Me.Lbl_Empresa.Location = New System.Drawing.Point(111, 4)
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
        Me.LabelX2.Size = New System.Drawing.Size(75, 11)
        Me.LabelX2.TabIndex = 0
        Me.LabelX2.Text = "Empresa"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnGrabar, Me.Btn_FotoStock})
        Me.Bar1.Location = New System.Drawing.Point(0, 221)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(588, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 25
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnGrabar
        '
        Me.BtnGrabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnGrabar.ForeColor = System.Drawing.Color.Black
        Me.BtnGrabar.Image = CType(resources.GetObject("BtnGrabar.Image"), System.Drawing.Image)
        Me.BtnGrabar.ImageAlt = CType(resources.GetObject("BtnGrabar.ImageAlt"), System.Drawing.Image)
        Me.BtnGrabar.Name = "BtnGrabar"
        Me.BtnGrabar.Tooltip = "Grabar"
        '
        'Btn_FotoStock
        '
        Me.Btn_FotoStock.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_FotoStock.ForeColor = System.Drawing.Color.Black
        Me.Btn_FotoStock.Image = CType(resources.GetObject("Btn_FotoStock.Image"), System.Drawing.Image)
        Me.Btn_FotoStock.ImageAlt = CType(resources.GetObject("Btn_FotoStock.ImageAlt"), System.Drawing.Image)
        Me.Btn_FotoStock.Name = "Btn_FotoStock"
        Me.Btn_FotoStock.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_TomarFotoStock, Me.Btn_EliminarFotoStock})
        Me.Btn_FotoStock.Text = "Foto Stock"
        Me.Btn_FotoStock.Tooltip = "Limpiar todo"
        '
        'Btn_TomarFotoStock
        '
        Me.Btn_TomarFotoStock.Image = CType(resources.GetObject("Btn_TomarFotoStock.Image"), System.Drawing.Image)
        Me.Btn_TomarFotoStock.ImageAlt = CType(resources.GetObject("Btn_TomarFotoStock.ImageAlt"), System.Drawing.Image)
        Me.Btn_TomarFotoStock.Name = "Btn_TomarFotoStock"
        Me.Btn_TomarFotoStock.Text = "Tomar Foto Stock"
        '
        'Btn_EliminarFotoStock
        '
        Me.Btn_EliminarFotoStock.Image = CType(resources.GetObject("Btn_EliminarFotoStock.Image"), System.Drawing.Image)
        Me.Btn_EliminarFotoStock.ImageAlt = CType(resources.GetObject("Btn_EliminarFotoStock.ImageAlt"), System.Drawing.Image)
        Me.Btn_EliminarFotoStock.Name = "Btn_EliminarFotoStock"
        Me.Btn_EliminarFotoStock.Text = "Eliminar Foto Stock"
        '
        'Txt_NombreInventario
        '
        Me.Txt_NombreInventario.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_NombreInventario.Border.Class = "TextBoxBorder"
        Me.Txt_NombreInventario.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_NombreInventario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_NombreInventario.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_NombreInventario.ForeColor = System.Drawing.Color.Black
        Me.Txt_NombreInventario.Location = New System.Drawing.Point(125, 123)
        Me.Txt_NombreInventario.Name = "Txt_NombreInventario"
        Me.Txt_NombreInventario.PreventEnterBeep = True
        Me.Txt_NombreInventario.Size = New System.Drawing.Size(450, 22)
        Me.Txt_NombreInventario.TabIndex = 1
        '
        'Chk_Estado
        '
        Me.Chk_Estado.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Estado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Estado.CheckBoxImageChecked = CType(resources.GetObject("Chk_Estado.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Estado.Enabled = False
        Me.Chk_Estado.FocusCuesEnabled = False
        Me.Chk_Estado.ForeColor = System.Drawing.Color.Black
        Me.Chk_Estado.Location = New System.Drawing.Point(12, 189)
        Me.Chk_Estado.Name = "Chk_Estado"
        Me.Chk_Estado.Size = New System.Drawing.Size(115, 17)
        Me.Chk_Estado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Estado.TabIndex = 30
        Me.Chk_Estado.TabStop = False
        Me.Chk_Estado.Text = "Inventario Activo"
        '
        'Dtp_Fecha_Inventario
        '
        '
        '
        '
        Me.Dtp_Fecha_Inventario.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Inventario.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Inventario.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Inventario.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Inventario.Format = DevComponents.Editors.eDateTimePickerFormat.[Long]
        Me.Dtp_Fecha_Inventario.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Inventario.Location = New System.Drawing.Point(125, 95)
        '
        '
        '
        Me.Dtp_Fecha_Inventario.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Inventario.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Inventario.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Inventario.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Inventario.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Inventario.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Inventario.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Inventario.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Inventario.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Inventario.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Inventario.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Inventario.MonthCalendar.DisplayMonth = New Date(2024, 5, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Inventario.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_Fecha_Inventario.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Inventario.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Inventario.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Inventario.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Inventario.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Inventario.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Inventario.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Inventario.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Inventario.Name = "Dtp_Fecha_Inventario"
        Me.Dtp_Fecha_Inventario.Size = New System.Drawing.Size(200, 22)
        Me.Dtp_Fecha_Inventario.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Inventario.TabIndex = 0
        Me.Dtp_Fecha_Inventario.Value = New Date(2024, 5, 29, 10, 41, 25, 0)
        '
        'Txt_FuncCargo
        '
        Me.Txt_FuncCargo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_FuncCargo.Border.Class = "TextBoxBorder"
        Me.Txt_FuncCargo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_FuncCargo.ButtonCustom.Image = CType(resources.GetObject("Txt_FuncCargo.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_FuncCargo.ButtonCustom.Visible = True
        Me.Txt_FuncCargo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_FuncCargo.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_FuncCargo.ForeColor = System.Drawing.Color.Black
        Me.Txt_FuncCargo.Location = New System.Drawing.Point(125, 153)
        Me.Txt_FuncCargo.Name = "Txt_FuncCargo"
        Me.Txt_FuncCargo.PreventEnterBeep = True
        Me.Txt_FuncCargo.ReadOnly = True
        Me.Txt_FuncCargo.Size = New System.Drawing.Size(450, 22)
        Me.Txt_FuncCargo.TabIndex = 2
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(12, 94)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(91, 23)
        Me.LabelX3.TabIndex = 33
        Me.LabelX3.Text = "Fecha inventario"
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(12, 123)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(115, 23)
        Me.LabelX6.TabIndex = 34
        Me.LabelX6.Text = "Nombre de inventario"
        '
        'LabelX7
        '
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.ForeColor = System.Drawing.Color.Black
        Me.LabelX7.Location = New System.Drawing.Point(12, 153)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(115, 23)
        Me.LabelX7.TabIndex = 35
        Me.LabelX7.Text = "Funcionario a cargo"
        '
        'Frm_01_CrearInventario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(588, 262)
        Me.Controls.Add(Me.Txt_NombreInventario)
        Me.Controls.Add(Me.Txt_FuncCargo)
        Me.Controls.Add(Me.LabelX7)
        Me.Controls.Add(Me.LabelX6)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.Dtp_Fecha_Inventario)
        Me.Controls.Add(Me.Chk_Estado)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_01_CrearInventario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_Fecha_Inventario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Public WithEvents Lbl_Sucursal As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Public WithEvents Lbl_Empresa As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnGrabar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Txt_NombreInventario As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Bodega As DevComponents.DotNetBar.LabelX
    Public WithEvents Btn_FotoStock As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_TomarFotoStock As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_EliminarFotoStock As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Chk_Estado As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Dtp_Fecha_Inventario As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Public WithEvents Txt_FuncCargo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
End Class
