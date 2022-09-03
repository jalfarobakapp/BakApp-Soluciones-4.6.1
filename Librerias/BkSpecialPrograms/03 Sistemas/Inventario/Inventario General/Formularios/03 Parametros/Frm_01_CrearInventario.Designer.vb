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
        Me.LblBodega = New DevComponents.DotNetBar.LabelX()
        Me.LblSucursal = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LblEmpresa = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.BtnGrabar = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnEstado = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem2 = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnEliminarFotoStock = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnxSalir = New DevComponents.DotNetBar.ButtonItem()
        Me.TxtNombreInventario = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.DtFechaInv = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CmbFuncionarios = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ChkInvGenerado = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtFechaInv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.00533!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.99467!))
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX5, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.LblBodega, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.LblSucursal, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX4, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LblEmpresa, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX2, 0, 0)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 6)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(565, 69)
        Me.TableLayoutPanel1.TabIndex = 26
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(5, 50)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(75, 14)
        Me.LabelX5.TabIndex = 5
        Me.LabelX5.Text = "Bodega"
        '
        'LblBodega
        '
        '
        '
        '
        Me.LblBodega.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblBodega.ForeColor = System.Drawing.Color.Black
        Me.LblBodega.Location = New System.Drawing.Point(113, 50)
        Me.LblBodega.Name = "LblBodega"
        Me.LblBodega.Size = New System.Drawing.Size(75, 14)
        Me.LblBodega.TabIndex = 4
        Me.LblBodega.Text = "Sucursal"
        '
        'LblSucursal
        '
        Me.LblSucursal.AutoSize = True
        '
        '
        '
        Me.LblSucursal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblSucursal.ForeColor = System.Drawing.Color.Black
        Me.LblSucursal.Location = New System.Drawing.Point(113, 28)
        Me.LblSucursal.Name = "LblSucursal"
        Me.LblSucursal.Size = New System.Drawing.Size(41, 17)
        Me.LblSucursal.TabIndex = 3
        Me.LblSucursal.Text = "LabelX5"
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(5, 28)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(75, 14)
        Me.LabelX4.TabIndex = 2
        Me.LabelX4.Text = "Sucursal"
        '
        'LblEmpresa
        '
        Me.LblEmpresa.AutoSize = True
        '
        '
        '
        Me.LblEmpresa.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblEmpresa.ForeColor = System.Drawing.Color.Black
        Me.LblEmpresa.Location = New System.Drawing.Point(113, 5)
        Me.LblEmpresa.Name = "LblEmpresa"
        Me.LblEmpresa.Size = New System.Drawing.Size(41, 17)
        Me.LblEmpresa.TabIndex = 1
        Me.LblEmpresa.Text = "LabelX3"
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(5, 5)
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
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnGrabar, Me.BtnEstado, Me.ButtonItem1, Me.BtnxSalir})
        Me.Bar1.Location = New System.Drawing.Point(0, 228)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(581, 41)
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
        Me.BtnGrabar.Name = "BtnGrabar"
        Me.BtnGrabar.Text = "Grabar"
        Me.BtnGrabar.Tooltip = "Limpiar todo"
        '
        'BtnEstado
        '
        Me.BtnEstado.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnEstado.ForeColor = System.Drawing.Color.Black
        Me.BtnEstado.Name = "BtnEstado"
        Me.BtnEstado.Text = "Grabar"
        Me.BtnEstado.Tooltip = "Limpiar todo"
        '
        'ButtonItem1
        '
        Me.ButtonItem1.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem1.ForeColor = System.Drawing.Color.Black
        Me.ButtonItem1.Image = CType(resources.GetObject("ButtonItem1.Image"), System.Drawing.Image)
        Me.ButtonItem1.Name = "ButtonItem1"
        Me.ButtonItem1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem2, Me.BtnEliminarFotoStock})
        Me.ButtonItem1.Text = "Foto Stock"
        Me.ButtonItem1.Tooltip = "Limpiar todo"
        '
        'ButtonItem2
        '
        Me.ButtonItem2.Image = CType(resources.GetObject("ButtonItem2.Image"), System.Drawing.Image)
        Me.ButtonItem2.Name = "ButtonItem2"
        Me.ButtonItem2.Text = "Tomar Foto Stock"
        '
        'BtnEliminarFotoStock
        '
        Me.BtnEliminarFotoStock.Image = CType(resources.GetObject("BtnEliminarFotoStock.Image"), System.Drawing.Image)
        Me.BtnEliminarFotoStock.Name = "BtnEliminarFotoStock"
        Me.BtnEliminarFotoStock.Text = "Eliminar Foto Stock"
        '
        'BtnxSalir
        '
        Me.BtnxSalir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnxSalir.ForeColor = System.Drawing.Color.Black
        Me.BtnxSalir.Image = CType(resources.GetObject("BtnxSalir.Image"), System.Drawing.Image)
        Me.BtnxSalir.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnxSalir.Name = "BtnxSalir"
        '
        'TxtNombreInventario
        '
        Me.TxtNombreInventario.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtNombreInventario.Border.Class = "TextBoxBorder"
        Me.TxtNombreInventario.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtNombreInventario.DisabledBackColor = System.Drawing.Color.White
        Me.TxtNombreInventario.ForeColor = System.Drawing.Color.Black
        Me.TxtNombreInventario.Location = New System.Drawing.Point(125, 123)
        Me.TxtNombreInventario.Name = "TxtNombreInventario"
        Me.TxtNombreInventario.PreventEnterBeep = True
        Me.TxtNombreInventario.Size = New System.Drawing.Size(450, 22)
        Me.TxtNombreInventario.TabIndex = 24
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(12, 120)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(106, 23)
        Me.LabelX1.TabIndex = 23
        Me.LabelX1.Text = "Nombre de ajuste"
        '
        'DtFechaInv
        '
        Me.DtFechaInv.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.DtFechaInv.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.DtFechaInv.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DtFechaInv.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.DtFechaInv.ButtonDropDown.Visible = True
        Me.DtFechaInv.ForeColor = System.Drawing.Color.Black
        Me.DtFechaInv.Format = DevComponents.Editors.eDateTimePickerFormat.[Long]
        Me.DtFechaInv.IsPopupCalendarOpen = False
        Me.DtFechaInv.Location = New System.Drawing.Point(125, 94)
        '
        '
        '
        Me.DtFechaInv.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.DtFechaInv.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DtFechaInv.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.DtFechaInv.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.DtFechaInv.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.DtFechaInv.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.DtFechaInv.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.DtFechaInv.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.DtFechaInv.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.DtFechaInv.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.DtFechaInv.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DtFechaInv.MonthCalendar.DisplayMonth = New Date(2014, 10, 1, 0, 0, 0, 0)
        Me.DtFechaInv.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.DtFechaInv.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.DtFechaInv.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.DtFechaInv.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.DtFechaInv.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.DtFechaInv.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DtFechaInv.MonthCalendar.TodayButtonVisible = True
        Me.DtFechaInv.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.DtFechaInv.Name = "DtFechaInv"
        Me.DtFechaInv.Size = New System.Drawing.Size(200, 22)
        Me.DtFechaInv.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.DtFechaInv.TabIndex = 22
        Me.DtFechaInv.Value = New Date(2014, 10, 2, 11, 14, 2, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(9, 103)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 13)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Fecha inventario"
        '
        'CmbFuncionarios
        '
        Me.CmbFuncionarios.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CmbFuncionarios.ForeColor = System.Drawing.Color.Black
        Me.CmbFuncionarios.FormattingEnabled = True
        Me.CmbFuncionarios.Location = New System.Drawing.Point(125, 152)
        Me.CmbFuncionarios.Name = "CmbFuncionarios"
        Me.CmbFuncionarios.Size = New System.Drawing.Size(333, 21)
        Me.CmbFuncionarios.TabIndex = 28
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(9, 155)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 13)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Funcionario a cargo"
        '
        'ChkInvGenerado
        '
        Me.ChkInvGenerado.AutoSize = True
        Me.ChkInvGenerado.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ChkInvGenerado.ForeColor = System.Drawing.Color.Black
        Me.ChkInvGenerado.Location = New System.Drawing.Point(12, 187)
        Me.ChkInvGenerado.Name = "ChkInvGenerado"
        Me.ChkInvGenerado.Size = New System.Drawing.Size(131, 17)
        Me.ChkInvGenerado.TabIndex = 29
        Me.ChkInvGenerado.Text = "Inventario generado"
        Me.ChkInvGenerado.UseVisualStyleBackColor = False
        '
        'Frm_01_CrearInventario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(581, 269)
        Me.ControlBox = False
        Me.Controls.Add(Me.ChkInvGenerado)
        Me.Controls.Add(Me.CmbFuncionarios)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.TxtNombreInventario)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.DtFechaInv)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_01_CrearInventario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtFechaInv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Public WithEvents LblSucursal As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Public WithEvents LblEmpresa As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnGrabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnxSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Public WithEvents DtFechaInv As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents TxtNombreInventario As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents CmbFuncionarios As System.Windows.Forms.ComboBox
    Public WithEvents ChkInvGenerado As System.Windows.Forms.CheckBox
    Public WithEvents BtnEstado As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LblBodega As DevComponents.DotNetBar.LabelX
    Public WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem2 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnEliminarFotoStock As DevComponents.DotNetBar.ButtonItem
End Class
