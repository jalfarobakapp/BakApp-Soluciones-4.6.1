<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Imprimir_Cierres_Transbank
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Imprimir_Cierres_Transbank))
        Me.Navegador_Fechas = New DevComponents.DotNetBar.Schedule.DateNavigator()
        Me.Calendario_Mes = New DevComponents.DotNetBar.Schedule.CalendarView()
        Me.Btn_Exportar_Excel = New DevComponents.DotNetBar.ButtonItem()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Imprimir_Cierre = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_01 = New DevComponents.DotNetBar.ButtonItem()
        Me.Lbl_Dia = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Mnu_Imprimir_Cierre = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Imprimir_Vouchers = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Exportar_Excel = New DevComponents.DotNetBar.ButtonItem()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Navegador_Fechas
        '
        Me.Navegador_Fechas.CalendarView = Me.Calendario_Mes
        Me.Navegador_Fechas.CanvasColor = System.Drawing.SystemColors.Control
        Me.Navegador_Fechas.DisabledBackColor = System.Drawing.Color.Empty
        Me.Navegador_Fechas.Dock = System.Windows.Forms.DockStyle.Top
        Me.Navegador_Fechas.Location = New System.Drawing.Point(0, 0)
        Me.Navegador_Fechas.Name = "Navegador_Fechas"
        Me.Navegador_Fechas.Size = New System.Drawing.Size(954, 30)
        Me.Navegador_Fechas.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Navegador_Fechas.TabIndex = 22
        Me.Navegador_Fechas.Text = "DateNavigator1"
        '
        'Calendario_Mes
        '
        Me.Calendario_Mes.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Calendario_Mes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Calendario_Mes.ContainerControlProcessDialogKey = True
        Me.Calendario_Mes.FixedAllDayPanelHeight = 0
        Me.Calendario_Mes.ForeColor = System.Drawing.Color.Black
        Me.Calendario_Mes.HighlightCurrentDay = True
        Me.Calendario_Mes.Is24HourFormat = True
        Me.Calendario_Mes.LabelTimeSlots = True
        Me.Calendario_Mes.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.Calendario_Mes.Location = New System.Drawing.Point(0, 30)
        Me.Calendario_Mes.MultiUserTabHeight = 19
        Me.Calendario_Mes.Name = "Calendario_Mes"
        Me.Calendario_Mes.SelectedView = DevComponents.DotNetBar.Schedule.eCalendarView.Month
        Me.Calendario_Mes.Size = New System.Drawing.Size(954, 584)
        Me.Calendario_Mes.TabIndex = 24
        Me.Calendario_Mes.Text = "CalendarView1"
        Me.Calendario_Mes.TimeIndicator.BorderColor = System.Drawing.Color.Empty
        Me.Calendario_Mes.TimeIndicator.IndicatorArea = DevComponents.DotNetBar.Schedule.eTimeIndicatorArea.All
        Me.Calendario_Mes.TimeIndicator.Tag = Nothing
        Me.Calendario_Mes.TimeIndicator.Visibility = DevComponents.DotNetBar.Schedule.eTimeIndicatorVisibility.AllResources
        Me.Calendario_Mes.TimeSlotDuration = 30
        '
        'Btn_Exportar_Excel
        '
        Me.Btn_Exportar_Excel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Exportar_Excel.ForeColor = System.Drawing.Color.Black
        Me.Btn_Exportar_Excel.Image = CType(resources.GetObject("Btn_Exportar_Excel.Image"), System.Drawing.Image)
        Me.Btn_Exportar_Excel.Name = "Btn_Exportar_Excel"
        Me.Btn_Exportar_Excel.Tooltip = "Exportar a excel"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Imprimir_Cierre, Me.Btn_Exportar_Excel, Me.BtnSalir})
        Me.Bar1.Location = New System.Drawing.Point(0, 620)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(954, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 23
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Imprimir_Cierre
        '
        Me.Btn_Imprimir_Cierre.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Imprimir_Cierre.ForeColor = System.Drawing.Color.Black
        Me.Btn_Imprimir_Cierre.Image = CType(resources.GetObject("Btn_Imprimir_Cierre.Image"), System.Drawing.Image)
        Me.Btn_Imprimir_Cierre.Name = "Btn_Imprimir_Cierre"
        Me.Btn_Imprimir_Cierre.Text = "Imprimir Cierre"
        '
        'BtnSalir
        '
        Me.BtnSalir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnSalir.ForeColor = System.Drawing.Color.Black
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnSalir.Name = "BtnSalir"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_01})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(401, 318)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(153, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 47
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_01
        '
        Me.Menu_Contextual_01.AutoExpandOnClick = True
        Me.Menu_Contextual_01.Name = "Menu_Contextual_01"
        Me.Menu_Contextual_01.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Lbl_Dia, Me.Btn_Mnu_Imprimir_Cierre, Me.Btn_Imprimir_Vouchers, Me.Btn_Mnu_Exportar_Excel})
        Me.Menu_Contextual_01.Text = "Opciones"
        '
        'Lbl_Dia
        '
        Me.Lbl_Dia.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Lbl_Dia.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.Lbl_Dia.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.Lbl_Dia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.Lbl_Dia.Name = "Lbl_Dia"
        Me.Lbl_Dia.PaddingBottom = 1
        Me.Lbl_Dia.PaddingLeft = 10
        Me.Lbl_Dia.PaddingTop = 1
        Me.Lbl_Dia.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.Lbl_Dia.Text = "Opciones"
        '
        'Btn_Mnu_Imprimir_Cierre
        '
        Me.Btn_Mnu_Imprimir_Cierre.Image = CType(resources.GetObject("Btn_Mnu_Imprimir_Cierre.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Imprimir_Cierre.Name = "Btn_Mnu_Imprimir_Cierre"
        Me.Btn_Mnu_Imprimir_Cierre.Text = "IMPRIMIR CIERRE"
        '
        'Btn_Imprimir_Vouchers
        '
        Me.Btn_Imprimir_Vouchers.Image = CType(resources.GetObject("Btn_Imprimir_Vouchers.Image"), System.Drawing.Image)
        Me.Btn_Imprimir_Vouchers.Name = "Btn_Imprimir_Vouchers"
        Me.Btn_Imprimir_Vouchers.Text = "IMPRIMIR COMPROBANTES (VOUCHER)"
        '
        'Btn_Mnu_Exportar_Excel
        '
        Me.Btn_Mnu_Exportar_Excel.Image = CType(resources.GetObject("Btn_Mnu_Exportar_Excel.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Exportar_Excel.Name = "Btn_Mnu_Exportar_Excel"
        Me.Btn_Mnu_Exportar_Excel.Text = "EXPORTAR A EXCEL"
        '
        'Frm_Imprimir_Cierres_Transbank
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(954, 661)
        Me.ControlBox = False
        Me.Controls.Add(Me.ContextMenuBar1)
        Me.Controls.Add(Me.Navegador_Fechas)
        Me.Controls.Add(Me.Calendario_Mes)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Imprimir_Cierres_Transbank"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Navegador_Fechas As DevComponents.DotNetBar.Schedule.DateNavigator
    Friend WithEvents Calendario_Mes As DevComponents.DotNetBar.Schedule.CalendarView
    Friend WithEvents Btn_Exportar_Excel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Imprimir_Cierre As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_01 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Lbl_Dia As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Mnu_Imprimir_Cierre As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_Exportar_Excel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Imprimir_Vouchers As DevComponents.DotNetBar.ButtonItem
End Class
