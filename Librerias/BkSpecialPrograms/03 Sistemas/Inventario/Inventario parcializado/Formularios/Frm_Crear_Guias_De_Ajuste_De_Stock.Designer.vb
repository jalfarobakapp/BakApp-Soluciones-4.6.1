<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Crear_Guias_De_Ajuste_De_Stock
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Crear_Guias_De_Ajuste_De_Stock))
        Me.Chk_Dejar_Doc_Final_Del_Dia = New System.Windows.Forms.CheckBox()
        Me.Chk_CambiarCostoEnLCProducto = New System.Windows.Forms.CheckBox()
        Me.ChkDejaStockCero = New System.Windows.Forms.CheckBox()
        Me.DtFechaInv = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblEstado = New DevComponents.DotNetBar.LabelX()
        Me.Progreso_Porc = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.Progreso_Cont = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Procesar = New DevComponents.DotNetBar.ButtonItem()
        Me.TxtLog = New DevComponents.DotNetBar.Controls.TextBoxX()
        CType(Me.DtFechaInv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Chk_Dejar_Doc_Final_Del_Dia
        '
        Me.Chk_Dejar_Doc_Final_Del_Dia.AutoSize = True
        Me.Chk_Dejar_Doc_Final_Del_Dia.BackColor = System.Drawing.Color.White
        Me.Chk_Dejar_Doc_Final_Del_Dia.Enabled = False
        Me.Chk_Dejar_Doc_Final_Del_Dia.ForeColor = System.Drawing.Color.Black
        Me.Chk_Dejar_Doc_Final_Del_Dia.Location = New System.Drawing.Point(489, 157)
        Me.Chk_Dejar_Doc_Final_Del_Dia.Name = "Chk_Dejar_Doc_Final_Del_Dia"
        Me.Chk_Dejar_Doc_Final_Del_Dia.Size = New System.Drawing.Size(198, 17)
        Me.Chk_Dejar_Doc_Final_Del_Dia.TabIndex = 46
        Me.Chk_Dejar_Doc_Final_Del_Dia.Text = "Hora de grabación al final del día"
        Me.Chk_Dejar_Doc_Final_Del_Dia.UseVisualStyleBackColor = False
        '
        'Chk_CambiarCostoEnLCProducto
        '
        Me.Chk_CambiarCostoEnLCProducto.AutoSize = True
        Me.Chk_CambiarCostoEnLCProducto.BackColor = System.Drawing.Color.White
        Me.Chk_CambiarCostoEnLCProducto.Checked = True
        Me.Chk_CambiarCostoEnLCProducto.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_CambiarCostoEnLCProducto.Enabled = False
        Me.Chk_CambiarCostoEnLCProducto.ForeColor = System.Drawing.Color.Black
        Me.Chk_CambiarCostoEnLCProducto.Location = New System.Drawing.Point(12, 180)
        Me.Chk_CambiarCostoEnLCProducto.Name = "Chk_CambiarCostoEnLCProducto"
        Me.Chk_CambiarCostoEnLCProducto.Size = New System.Drawing.Size(233, 17)
        Me.Chk_CambiarCostoEnLCProducto.TabIndex = 45
        Me.Chk_CambiarCostoEnLCProducto.Text = "Cambiar el costo de la lista del producto"
        Me.Chk_CambiarCostoEnLCProducto.UseVisualStyleBackColor = False
        '
        'ChkDejaStockCero
        '
        Me.ChkDejaStockCero.AutoSize = True
        Me.ChkDejaStockCero.BackColor = System.Drawing.Color.White
        Me.ChkDejaStockCero.ForeColor = System.Drawing.Color.Black
        Me.ChkDejaStockCero.Location = New System.Drawing.Point(12, 203)
        Me.ChkDejaStockCero.Name = "ChkDejaStockCero"
        Me.ChkDejaStockCero.Size = New System.Drawing.Size(120, 17)
        Me.ChkDejaStockCero.TabIndex = 44
        Me.ChkDejaStockCero.Text = "Deja stock en cero"
        Me.ChkDejaStockCero.UseVisualStyleBackColor = False
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
        Me.DtFechaInv.Location = New System.Drawing.Point(489, 12)
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
        Me.DtFechaInv.TabIndex = 43
        Me.DtFechaInv.Value = New Date(2014, 10, 2, 11, 14, 2, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(391, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 13)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "Fecha de ajuste"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblEstado
        '
        Me.LblEstado.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LblEstado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblEstado.ForeColor = System.Drawing.Color.Black
        Me.LblEstado.Location = New System.Drawing.Point(12, 151)
        Me.LblEstado.Name = "LblEstado"
        Me.LblEstado.Size = New System.Drawing.Size(677, 23)
        Me.LblEstado.TabIndex = 41
        Me.LblEstado.Text = "Presione Porocesar...."
        '
        'Progreso_Porc
        '
        Me.Progreso_Porc.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Progreso_Porc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Progreso_Porc.Location = New System.Drawing.Point(12, 95)
        Me.Progreso_Porc.Name = "Progreso_Porc"
        Me.Progreso_Porc.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.Progreso_Porc.ProgressColor = System.Drawing.Color.SteelBlue
        Me.Progreso_Porc.ProgressTextVisible = True
        Me.Progreso_Porc.Size = New System.Drawing.Size(56, 46)
        Me.Progreso_Porc.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.Progreso_Porc.TabIndex = 40
        '
        'Progreso_Cont
        '
        Me.Progreso_Cont.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Progreso_Cont.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Progreso_Cont.Location = New System.Drawing.Point(12, 43)
        Me.Progreso_Cont.Name = "Progreso_Cont"
        Me.Progreso_Cont.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.Progreso_Cont.ProgressColor = System.Drawing.Color.SteelBlue
        Me.Progreso_Cont.ProgressTextFormat = "{0}"
        Me.Progreso_Cont.ProgressTextVisible = True
        Me.Progreso_Cont.Size = New System.Drawing.Size(56, 46)
        Me.Progreso_Cont.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.Progreso_Cont.TabIndex = 39
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Procesar})
        Me.Bar2.Location = New System.Drawing.Point(0, 229)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(705, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 38
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Procesar
        '
        Me.Btn_Procesar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Procesar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Procesar.Image = CType(resources.GetObject("Btn_Procesar.Image"), System.Drawing.Image)
        Me.Btn_Procesar.Name = "Btn_Procesar"
        Me.Btn_Procesar.Text = "Procesar"
        Me.Btn_Procesar.Tooltip = "Grabar"
        '
        'TxtLog
        '
        Me.TxtLog.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtLog.Border.Class = "TextBoxBorder"
        Me.TxtLog.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtLog.DisabledBackColor = System.Drawing.Color.White
        Me.TxtLog.ForeColor = System.Drawing.Color.Black
        Me.TxtLog.Location = New System.Drawing.Point(74, 43)
        Me.TxtLog.Multiline = True
        Me.TxtLog.Name = "TxtLog"
        Me.TxtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtLog.Size = New System.Drawing.Size(615, 98)
        Me.TxtLog.TabIndex = 37
        '
        'Frm_Crear_Guias_De_Ajuste_De_Stock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(705, 270)
        Me.Controls.Add(Me.Chk_Dejar_Doc_Final_Del_Dia)
        Me.Controls.Add(Me.Chk_CambiarCostoEnLCProducto)
        Me.Controls.Add(Me.ChkDejaStockCero)
        Me.Controls.Add(Me.DtFechaInv)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LblEstado)
        Me.Controls.Add(Me.Progreso_Porc)
        Me.Controls.Add(Me.Progreso_Cont)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.TxtLog)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Crear_Guias_De_Ajuste_De_Stock"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AJUSTE DE INVENTARIO GDI - GRI"
        CType(Me.DtFechaInv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public WithEvents Chk_Dejar_Doc_Final_Del_Dia As CheckBox
    Public WithEvents Chk_CambiarCostoEnLCProducto As CheckBox
    Public WithEvents ChkDejaStockCero As CheckBox
    Public WithEvents DtFechaInv As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Label1 As Label
    Friend WithEvents LblEstado As DevComponents.DotNetBar.LabelX
    Friend WithEvents Progreso_Porc As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Progreso_Cont As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Procesar As DevComponents.DotNetBar.ButtonItem
    Private WithEvents TxtLog As DevComponents.DotNetBar.Controls.TextBoxX
End Class
