<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_InvParc_06_ProcesarDatos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_InvParc_06_ProcesarDatos))
        Me.TxtLog = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.BtnProcesar = New DevComponents.DotNetBar.ButtonItem()
        Me.Progreso_Cont = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.Progreso_Porc = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.LblEstado = New DevComponents.DotNetBar.LabelX()
        Me.DtFechaInv = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ChkDejaStockCero = New System.Windows.Forms.CheckBox()
        Me.Chk_CambiarCostoEnLCProducto = New System.Windows.Forms.CheckBox()
        Me.Chk_Dejar_Doc_Final_Del_Dia = New System.Windows.Forms.CheckBox()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtFechaInv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.TxtLog.Location = New System.Drawing.Point(74, 47)
        Me.TxtLog.Multiline = True
        Me.TxtLog.Name = "TxtLog"
        Me.TxtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtLog.Size = New System.Drawing.Size(615, 98)
        Me.TxtLog.TabIndex = 11
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnProcesar})
        Me.Bar2.Location = New System.Drawing.Point(0, 207)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(701, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 27
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'BtnProcesar
        '
        Me.BtnProcesar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnProcesar.ForeColor = System.Drawing.Color.Black
        Me.BtnProcesar.Image = CType(resources.GetObject("BtnProcesar.Image"), System.Drawing.Image)
        Me.BtnProcesar.Name = "BtnProcesar"
        Me.BtnProcesar.Text = "Procesar"
        Me.BtnProcesar.Tooltip = "Grabar"
        '
        'Progreso_Cont
        '
        Me.Progreso_Cont.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Progreso_Cont.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Progreso_Cont.Location = New System.Drawing.Point(12, 47)
        Me.Progreso_Cont.Name = "Progreso_Cont"
        Me.Progreso_Cont.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.Progreso_Cont.ProgressColor = System.Drawing.Color.SteelBlue
        Me.Progreso_Cont.ProgressTextFormat = "{0}"
        Me.Progreso_Cont.ProgressTextVisible = True
        Me.Progreso_Cont.Size = New System.Drawing.Size(56, 46)
        Me.Progreso_Cont.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.Progreso_Cont.TabIndex = 28
        '
        'Progreso_Porc
        '
        Me.Progreso_Porc.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Progreso_Porc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Progreso_Porc.Location = New System.Drawing.Point(12, 99)
        Me.Progreso_Porc.Name = "Progreso_Porc"
        Me.Progreso_Porc.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.Progreso_Porc.ProgressColor = System.Drawing.Color.SteelBlue
        Me.Progreso_Porc.ProgressTextVisible = True
        Me.Progreso_Porc.Size = New System.Drawing.Size(56, 46)
        Me.Progreso_Porc.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.Progreso_Porc.TabIndex = 30
        '
        'LblEstado
        '
        Me.LblEstado.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LblEstado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblEstado.ForeColor = System.Drawing.Color.Black
        Me.LblEstado.Location = New System.Drawing.Point(12, 155)
        Me.LblEstado.Name = "LblEstado"
        Me.LblEstado.Size = New System.Drawing.Size(677, 23)
        Me.LblEstado.TabIndex = 31
        Me.LblEstado.Text = "Presione Porocesar...."
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
        Me.DtFechaInv.Location = New System.Drawing.Point(489, 9)
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
        Me.DtFechaInv.TabIndex = 33
        Me.DtFechaInv.Value = New Date(2014, 10, 2, 11, 14, 2, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(391, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 13)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Fecha inventario"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ChkDejaStockCero
        '
        Me.ChkDejaStockCero.AutoSize = True
        Me.ChkDejaStockCero.BackColor = System.Drawing.Color.White
        Me.ChkDejaStockCero.Enabled = False
        Me.ChkDejaStockCero.ForeColor = System.Drawing.Color.Black
        Me.ChkDejaStockCero.Location = New System.Drawing.Point(12, 9)
        Me.ChkDejaStockCero.Name = "ChkDejaStockCero"
        Me.ChkDejaStockCero.Size = New System.Drawing.Size(120, 17)
        Me.ChkDejaStockCero.TabIndex = 34
        Me.ChkDejaStockCero.Text = "Deja stock en cero"
        Me.ChkDejaStockCero.UseVisualStyleBackColor = False
        '
        'Chk_CambiarCostoEnLCProducto
        '
        Me.Chk_CambiarCostoEnLCProducto.AutoSize = True
        Me.Chk_CambiarCostoEnLCProducto.BackColor = System.Drawing.Color.White
        Me.Chk_CambiarCostoEnLCProducto.Checked = True
        Me.Chk_CambiarCostoEnLCProducto.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_CambiarCostoEnLCProducto.Enabled = False
        Me.Chk_CambiarCostoEnLCProducto.ForeColor = System.Drawing.Color.Black
        Me.Chk_CambiarCostoEnLCProducto.Location = New System.Drawing.Point(12, 184)
        Me.Chk_CambiarCostoEnLCProducto.Name = "Chk_CambiarCostoEnLCProducto"
        Me.Chk_CambiarCostoEnLCProducto.Size = New System.Drawing.Size(233, 17)
        Me.Chk_CambiarCostoEnLCProducto.TabIndex = 35
        Me.Chk_CambiarCostoEnLCProducto.Text = "Cambiar el costo de la lista del producto"
        Me.Chk_CambiarCostoEnLCProducto.UseVisualStyleBackColor = False
        '
        'Chk_Dejar_Doc_Final_Del_Dia
        '
        Me.Chk_Dejar_Doc_Final_Del_Dia.AutoSize = True
        Me.Chk_Dejar_Doc_Final_Del_Dia.BackColor = System.Drawing.Color.White
        Me.Chk_Dejar_Doc_Final_Del_Dia.Enabled = False
        Me.Chk_Dejar_Doc_Final_Del_Dia.ForeColor = System.Drawing.Color.Black
        Me.Chk_Dejar_Doc_Final_Del_Dia.Location = New System.Drawing.Point(489, 161)
        Me.Chk_Dejar_Doc_Final_Del_Dia.Name = "Chk_Dejar_Doc_Final_Del_Dia"
        Me.Chk_Dejar_Doc_Final_Del_Dia.Size = New System.Drawing.Size(198, 17)
        Me.Chk_Dejar_Doc_Final_Del_Dia.TabIndex = 36
        Me.Chk_Dejar_Doc_Final_Del_Dia.Text = "Hora de grabación al final del día"
        Me.Chk_Dejar_Doc_Final_Del_Dia.UseVisualStyleBackColor = False
        '
        'Frm_InvParc_06_ProcesarDatos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(701, 248)
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
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_InvParc_06_ProcesarDatos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Generar ajsute de Stock"
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtFechaInv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents TxtLog As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnProcesar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Progreso_Cont As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Progreso_Porc As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents LblEstado As DevComponents.DotNetBar.LabelX
    Public WithEvents DtFechaInv As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents ChkDejaStockCero As System.Windows.Forms.CheckBox
    Public WithEvents Chk_CambiarCostoEnLCProducto As System.Windows.Forms.CheckBox
    Public WithEvents Chk_Dejar_Doc_Final_Del_Dia As System.Windows.Forms.CheckBox
End Class
