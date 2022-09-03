<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Mt_InvParc_NuevoAjuste
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Mt_InvParc_NuevoAjuste))
        Me.DtFechaInv = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.TxtNombreAjuste = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.BtnLimpiarCodigo = New DevComponents.DotNetBar.ButtonItem()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.LblBodega = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.LblSucursal = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LblEmpresa = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Cambiar_Fecha_Ajuste = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Cambiar_Nombre_Ajuste = New DevComponents.DotNetBar.ButtonX()
        CType(Me.DtFechaInv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
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
        Me.DtFechaInv.Enabled = False
        Me.DtFechaInv.ForeColor = System.Drawing.Color.Black
        Me.DtFechaInv.Format = DevComponents.Editors.eDateTimePickerFormat.[Long]
        Me.DtFechaInv.IsPopupCalendarOpen = False
        Me.DtFechaInv.Location = New System.Drawing.Point(124, 89)
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
        Me.DtFechaInv.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
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
        Me.DtFechaInv.TabIndex = 16
        Me.DtFechaInv.Value = New Date(2014, 10, 2, 11, 14, 2, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(9, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Fecha inventario"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(12, 115)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(106, 23)
        Me.LabelX1.TabIndex = 17
        Me.LabelX1.Text = "Nombre de ajuste"
        '
        'TxtNombreAjuste
        '
        Me.TxtNombreAjuste.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtNombreAjuste.Border.Class = "TextBoxBorder"
        Me.TxtNombreAjuste.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtNombreAjuste.DisabledBackColor = System.Drawing.Color.White
        Me.TxtNombreAjuste.Enabled = False
        Me.TxtNombreAjuste.ForeColor = System.Drawing.Color.Black
        Me.TxtNombreAjuste.Location = New System.Drawing.Point(124, 118)
        Me.TxtNombreAjuste.Name = "TxtNombreAjuste"
        Me.TxtNombreAjuste.PreventEnterBeep = True
        Me.TxtNombreAjuste.Size = New System.Drawing.Size(414, 22)
        Me.TxtNombreAjuste.TabIndex = 18
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnLimpiarCodigo})
        Me.Bar1.Location = New System.Drawing.Point(0, 154)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(589, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 19
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnLimpiarCodigo
        '
        Me.BtnLimpiarCodigo.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnLimpiarCodigo.ForeColor = System.Drawing.Color.Black
        Me.BtnLimpiarCodigo.Image = CType(resources.GetObject("BtnLimpiarCodigo.Image"), System.Drawing.Image)
        Me.BtnLimpiarCodigo.Name = "BtnLimpiarCodigo"
        Me.BtnLimpiarCodigo.Text = "Grabar nueva fecha de ajuste"
        Me.BtnLimpiarCodigo.Tooltip = "Limpiar todo"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.LblBodega, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX6, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.LblSucursal, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX4, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LblEmpresa, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX2, 0, 0)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 12)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(565, 65)
        Me.TableLayoutPanel1.TabIndex = 20
        '
        'LblBodega
        '
        Me.LblBodega.AutoSize = True
        '
        '
        '
        Me.LblBodega.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblBodega.ForeColor = System.Drawing.Color.Black
        Me.LblBodega.Location = New System.Drawing.Point(88, 46)
        Me.LblBodega.Name = "LblBodega"
        Me.LblBodega.Size = New System.Drawing.Size(41, 17)
        Me.LblBodega.TabIndex = 5
        Me.LblBodega.Text = "LabelX7"
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(5, 46)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(75, 14)
        Me.LabelX6.TabIndex = 4
        Me.LabelX6.Text = "Bodega"
        '
        'LblSucursal
        '
        Me.LblSucursal.AutoSize = True
        '
        '
        '
        Me.LblSucursal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblSucursal.ForeColor = System.Drawing.Color.Black
        Me.LblSucursal.Location = New System.Drawing.Point(88, 24)
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
        Me.LabelX4.Location = New System.Drawing.Point(5, 24)
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
        Me.LblEmpresa.Location = New System.Drawing.Point(88, 5)
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
        'Btn_Cambiar_Fecha_Ajuste
        '
        Me.Btn_Cambiar_Fecha_Ajuste.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Cambiar_Fecha_Ajuste.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Cambiar_Fecha_Ajuste.Image = CType(resources.GetObject("Btn_Cambiar_Fecha_Ajuste.Image"), System.Drawing.Image)
        Me.Btn_Cambiar_Fecha_Ajuste.Location = New System.Drawing.Point(330, 89)
        Me.Btn_Cambiar_Fecha_Ajuste.Name = "Btn_Cambiar_Fecha_Ajuste"
        Me.Btn_Cambiar_Fecha_Ajuste.Size = New System.Drawing.Size(29, 23)
        Me.Btn_Cambiar_Fecha_Ajuste.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Cambiar_Fecha_Ajuste.TabIndex = 21
        Me.Btn_Cambiar_Fecha_Ajuste.Tooltip = "Cambiar fecha de ajuste"
        '
        'Btn_Cambiar_Nombre_Ajuste
        '
        Me.Btn_Cambiar_Nombre_Ajuste.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Cambiar_Nombre_Ajuste.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Cambiar_Nombre_Ajuste.Image = CType(resources.GetObject("Btn_Cambiar_Nombre_Ajuste.Image"), System.Drawing.Image)
        Me.Btn_Cambiar_Nombre_Ajuste.Location = New System.Drawing.Point(544, 118)
        Me.Btn_Cambiar_Nombre_Ajuste.Name = "Btn_Cambiar_Nombre_Ajuste"
        Me.Btn_Cambiar_Nombre_Ajuste.Size = New System.Drawing.Size(33, 22)
        Me.Btn_Cambiar_Nombre_Ajuste.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Cambiar_Nombre_Ajuste.TabIndex = 22
        Me.Btn_Cambiar_Nombre_Ajuste.Tooltip = "Editar nombre de ajuste"
        '
        'Frm_Mt_InvParc_NuevoAjuste
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(589, 195)
        Me.Controls.Add(Me.Btn_Cambiar_Nombre_Ajuste)
        Me.Controls.Add(Me.Btn_Cambiar_Fecha_Ajuste)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.TxtNombreAjuste)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.DtFechaInv)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Mt_InvParc_NuevoAjuste"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Crear ajuste"
        CType(Me.DtFechaInv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents DtFechaInv As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtNombreAjuste As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnLimpiarCodigo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Public WithEvents LblBodega As DevComponents.DotNetBar.LabelX
    Public WithEvents LblSucursal As DevComponents.DotNetBar.LabelX
    Public WithEvents LblEmpresa As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Cambiar_Fecha_Ajuste As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Cambiar_Nombre_Ajuste As DevComponents.DotNetBar.ButtonX
End Class
