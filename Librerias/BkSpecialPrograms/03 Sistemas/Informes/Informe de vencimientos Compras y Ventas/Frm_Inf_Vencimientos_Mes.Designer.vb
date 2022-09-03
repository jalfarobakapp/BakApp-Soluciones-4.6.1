<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Inf_Vencimientos_Mes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Inf_Vencimientos_Mes))
        Me.Navegador_Fechas = New DevComponents.DotNetBar.Schedule.DateNavigator()
        Me.Calendario_Mes = New DevComponents.DotNetBar.Schedule.CalendarView()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Informe_Seleccion = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Ver_Ano = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Informe_Por_Entidad = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Informe_Consolidado = New DevComponents.DotNetBar.ButtonItem()
        Me.Progreso_Cont = New DevComponents.DotNetBar.CircularProgressItem()
        Me.Progreso_Porc = New DevComponents.DotNetBar.CircularProgressItem()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Navegador_Fechas.Size = New System.Drawing.Size(964, 30)
        Me.Navegador_Fechas.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Navegador_Fechas.TabIndex = 19
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
        Me.Calendario_Mes.Dock = System.Windows.Forms.DockStyle.Fill
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
        Me.Calendario_Mes.Size = New System.Drawing.Size(964, 600)
        Me.Calendario_Mes.TabIndex = 21
        Me.Calendario_Mes.Text = "CalendarView1"
        Me.Calendario_Mes.TimeIndicator.BorderColor = System.Drawing.Color.Empty
        Me.Calendario_Mes.TimeIndicator.IndicatorArea = DevComponents.DotNetBar.Schedule.eTimeIndicatorArea.All
        Me.Calendario_Mes.TimeIndicator.Tag = Nothing
        Me.Calendario_Mes.TimeIndicator.Visibility = DevComponents.DotNetBar.Schedule.eTimeIndicatorVisibility.AllResources
        Me.Calendario_Mes.TimeSlotDuration = 30
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Informe_Seleccion, Me.Btn_Ver_Ano, Me.Btn_Informe_Por_Entidad, Me.Btn_Informe_Consolidado, Me.Progreso_Cont, Me.Progreso_Porc})
        Me.Bar1.Location = New System.Drawing.Point(0, 630)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(964, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 20
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Informe_Seleccion
        '
        Me.Btn_Informe_Seleccion.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Informe_Seleccion.ForeColor = System.Drawing.Color.Black
        Me.Btn_Informe_Seleccion.Image = CType(resources.GetObject("Btn_Informe_Seleccion.Image"), System.Drawing.Image)
        Me.Btn_Informe_Seleccion.Name = "Btn_Informe_Seleccion"
        Me.Btn_Informe_Seleccion.Tooltip = "Ver informe detalle de selección"
        '
        'Btn_Ver_Ano
        '
        Me.Btn_Ver_Ano.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Ver_Ano.ForeColor = System.Drawing.Color.Black
        Me.Btn_Ver_Ano.Image = CType(resources.GetObject("Btn_Ver_Ano.Image"), System.Drawing.Image)
        Me.Btn_Ver_Ano.Name = "Btn_Ver_Ano"
        Me.Btn_Ver_Ano.Tooltip = "Ver calendario anual"
        '
        'Btn_Informe_Por_Entidad
        '
        Me.Btn_Informe_Por_Entidad.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Informe_Por_Entidad.ForeColor = System.Drawing.Color.Black
        Me.Btn_Informe_Por_Entidad.Image = CType(resources.GetObject("Btn_Informe_Por_Entidad.Image"), System.Drawing.Image)
        Me.Btn_Informe_Por_Entidad.Name = "Btn_Informe_Por_Entidad"
        Me.Btn_Informe_Por_Entidad.Tooltip = "Ver informe por entidad"
        '
        'Btn_Informe_Consolidado
        '
        Me.Btn_Informe_Consolidado.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Informe_Consolidado.ForeColor = System.Drawing.Color.Black
        Me.Btn_Informe_Consolidado.Image = CType(resources.GetObject("Btn_Informe_Consolidado.Image"), System.Drawing.Image)
        Me.Btn_Informe_Consolidado.Name = "Btn_Informe_Consolidado"
        Me.Btn_Informe_Consolidado.Tooltip = "Ver informe consolidado"
        '
        'Progreso_Cont
        '
        Me.Progreso_Cont.Name = "Progreso_Cont"
        Me.Progreso_Cont.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.Progreso_Cont.ProgressColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.Progreso_Cont.ProgressTextFormat = "{0}"
        Me.Progreso_Cont.ProgressTextVisible = True
        '
        'Progreso_Porc
        '
        Me.Progreso_Porc.Name = "Progreso_Porc"
        Me.Progreso_Porc.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.Progreso_Porc.ProgressColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.Progreso_Porc.ProgressTextVisible = True
        '
        'Frm_Inf_Vencimientos_Mes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 671)
        Me.Controls.Add(Me.Calendario_Mes)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.Navegador_Fechas)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Inf_Vencimientos_Mes"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Vencimientos de compras"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Navegador_Fechas As DevComponents.DotNetBar.Schedule.DateNavigator
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Informe_Seleccion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Ver_Ano As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Calendario_Mes As DevComponents.DotNetBar.Schedule.CalendarView
    Friend WithEvents Progreso_Cont As DevComponents.DotNetBar.CircularProgressItem
    Friend WithEvents Progreso_Porc As DevComponents.DotNetBar.CircularProgressItem
    Friend WithEvents Btn_Informe_Por_Entidad As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Informe_Consolidado As DevComponents.DotNetBar.ButtonItem
End Class
