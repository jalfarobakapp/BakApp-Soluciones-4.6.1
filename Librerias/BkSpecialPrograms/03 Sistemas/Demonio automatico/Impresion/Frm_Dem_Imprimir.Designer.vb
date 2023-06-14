<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Dem_Imprimir
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Dem_Imprimir))
        Me.Lbl_Modalidad = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Nombre_Equipo = New DevComponents.DotNetBar.LabelX()
        Me.DtpFecharevision = New System.Windows.Forms.DateTimePicker()
        Me.BtnCambFecha = New DevComponents.DotNetBar.ButtonX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Configurar = New DevComponents.DotNetBar.ButtonItem()
        Me.Metro_Bar_Color = New DevComponents.DotNetBar.Metro.MetroStatusBar()
        Me.Lbl_Estatus = New DevComponents.DotNetBar.LabelItem()
        Me.Txt_Log = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.CircularPgrs = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.Timer_Segundos = New System.Windows.Forms.Timer(Me.components)
        Me.ReflectionImage1 = New DevComponents.DotNetBar.Controls.ReflectionImage()
        Me.Chk_ImprimirDocumentos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_ImprimirPicking = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Chk_MarcarImprimirDocumentos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Timer_Clear = New System.Windows.Forms.Timer(Me.components)
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Input_SegundosImpresion = New DevComponents.Editors.IntegerInput()
        Me.Timer_Minimizar = New System.Windows.Forms.Timer(Me.components)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Input_SegundosImpresion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Lbl_Modalidad
        '
        Me.Lbl_Modalidad.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Modalidad.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Modalidad.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Modalidad.Location = New System.Drawing.Point(12, 49)
        Me.Lbl_Modalidad.Name = "Lbl_Modalidad"
        Me.Lbl_Modalidad.Size = New System.Drawing.Size(605, 23)
        Me.Lbl_Modalidad.TabIndex = 70
        Me.Lbl_Modalidad.Text = "Nombre Equipo..."
        '
        'Lbl_Nombre_Equipo
        '
        Me.Lbl_Nombre_Equipo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Nombre_Equipo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Nombre_Equipo.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Nombre_Equipo.Location = New System.Drawing.Point(12, 29)
        Me.Lbl_Nombre_Equipo.Name = "Lbl_Nombre_Equipo"
        Me.Lbl_Nombre_Equipo.Size = New System.Drawing.Size(605, 23)
        Me.Lbl_Nombre_Equipo.TabIndex = 69
        Me.Lbl_Nombre_Equipo.Text = "Nombre Equipo..."
        '
        'DtpFecharevision
        '
        Me.DtpFecharevision.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DtpFecharevision.ForeColor = System.Drawing.Color.Black
        Me.DtpFecharevision.Location = New System.Drawing.Point(12, 3)
        Me.DtpFecharevision.Name = "DtpFecharevision"
        Me.DtpFecharevision.Size = New System.Drawing.Size(216, 22)
        Me.DtpFecharevision.TabIndex = 65
        '
        'BtnCambFecha
        '
        Me.BtnCambFecha.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnCambFecha.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnCambFecha.Image = CType(resources.GetObject("BtnCambFecha.Image"), System.Drawing.Image)
        Me.BtnCambFecha.Location = New System.Drawing.Point(234, 2)
        Me.BtnCambFecha.Name = "BtnCambFecha"
        Me.BtnCambFecha.Size = New System.Drawing.Size(112, 23)
        Me.BtnCambFecha.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnCambFecha.TabIndex = 66
        Me.BtnCambFecha.Text = "Cambiar fecha"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Configurar})
        Me.Bar1.Location = New System.Drawing.Point(0, 376)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(732, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 64
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Configurar
        '
        Me.Btn_Configurar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Configurar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Configurar.Image = CType(resources.GetObject("Btn_Configurar.Image"), System.Drawing.Image)
        Me.Btn_Configurar.ImageAlt = CType(resources.GetObject("Btn_Configurar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Configurar.Name = "Btn_Configurar"
        Me.Btn_Configurar.Text = "Configuración"
        '
        'Metro_Bar_Color
        '
        '
        '
        '
        Me.Metro_Bar_Color.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Metro_Bar_Color.ContainerControlProcessDialogKey = True
        Me.Metro_Bar_Color.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Metro_Bar_Color.DragDropSupport = True
        Me.Metro_Bar_Color.Font = New System.Drawing.Font("Segoe UI", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Metro_Bar_Color.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Lbl_Estatus})
        Me.Metro_Bar_Color.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.Metro_Bar_Color.Location = New System.Drawing.Point(0, 417)
        Me.Metro_Bar_Color.Name = "Metro_Bar_Color"
        Me.Metro_Bar_Color.Size = New System.Drawing.Size(732, 22)
        Me.Metro_Bar_Color.TabIndex = 71
        Me.Metro_Bar_Color.Text = "MetroStatusBar1"
        '
        'Lbl_Estatus
        '
        Me.Lbl_Estatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Estatus.Name = "Lbl_Estatus"
        Me.Lbl_Estatus.Text = "LabelItem2"
        '
        'Txt_Log
        '
        Me.Txt_Log.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Log.Border.Class = "TextBoxBorder"
        Me.Txt_Log.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Log.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Log.ForeColor = System.Drawing.Color.Black
        Me.Txt_Log.Location = New System.Drawing.Point(12, 90)
        Me.Txt_Log.Multiline = True
        Me.Txt_Log.Name = "Txt_Log"
        Me.Txt_Log.PreventEnterBeep = True
        Me.Txt_Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Log.Size = New System.Drawing.Size(708, 229)
        Me.Txt_Log.TabIndex = 75
        '
        'CircularPgrs
        '
        Me.CircularPgrs.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CircularPgrs.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.CircularPgrs.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CircularPgrs.Enabled = False
        Me.CircularPgrs.Location = New System.Drawing.Point(685, 52)
        Me.CircularPgrs.Name = "CircularPgrs"
        Me.CircularPgrs.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Dot
        Me.CircularPgrs.ProgressColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CircularPgrs.Size = New System.Drawing.Size(35, 20)
        Me.CircularPgrs.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.CircularPgrs.TabIndex = 74
        '
        'Timer_Segundos
        '
        Me.Timer_Segundos.Interval = 1000
        '
        'ReflectionImage1
        '
        '
        '
        '
        Me.ReflectionImage1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionImage1.Image = CType(resources.GetObject("ReflectionImage1.Image"), System.Drawing.Image)
        Me.ReflectionImage1.Location = New System.Drawing.Point(623, 2)
        Me.ReflectionImage1.Name = "ReflectionImage1"
        Me.ReflectionImage1.Size = New System.Drawing.Size(56, 70)
        Me.ReflectionImage1.TabIndex = 76
        '
        'Chk_ImprimirDocumentos
        '
        '
        '
        '
        Me.Chk_ImprimirDocumentos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_ImprimirDocumentos.CheckBoxImageChecked = CType(resources.GetObject("Chk_ImprimirDocumentos.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_ImprimirDocumentos.Checked = True
        Me.Chk_ImprimirDocumentos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_ImprimirDocumentos.CheckValue = "Y"
        Me.Chk_ImprimirDocumentos.Enabled = False
        Me.Chk_ImprimirDocumentos.FocusCuesEnabled = False
        Me.Chk_ImprimirDocumentos.Location = New System.Drawing.Point(12, 325)
        Me.Chk_ImprimirDocumentos.Name = "Chk_ImprimirDocumentos"
        Me.Chk_ImprimirDocumentos.Size = New System.Drawing.Size(133, 18)
        Me.Chk_ImprimirDocumentos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_ImprimirDocumentos.TabIndex = 77
        Me.Chk_ImprimirDocumentos.TabStop = False
        Me.Chk_ImprimirDocumentos.Text = "Imprimir documentos"
        '
        'Chk_ImprimirPicking
        '
        '
        '
        '
        Me.Chk_ImprimirPicking.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_ImprimirPicking.CheckBoxImageChecked = CType(resources.GetObject("Chk_ImprimirPicking.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_ImprimirPicking.Checked = True
        Me.Chk_ImprimirPicking.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_ImprimirPicking.CheckValue = "Y"
        Me.Chk_ImprimirPicking.Enabled = False
        Me.Chk_ImprimirPicking.FocusCuesEnabled = False
        Me.Chk_ImprimirPicking.Location = New System.Drawing.Point(151, 325)
        Me.Chk_ImprimirPicking.Name = "Chk_ImprimirPicking"
        Me.Chk_ImprimirPicking.Size = New System.Drawing.Size(139, 18)
        Me.Chk_ImprimirPicking.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_ImprimirPicking.TabIndex = 79
        Me.Chk_ImprimirPicking.TabStop = False
        Me.Chk_ImprimirPicking.Text = "Imprimir Picking"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(515, 324)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(91, 19)
        Me.LabelX3.TabIndex = 135
        Me.LabelX3.Text = "Se imprime cada"
        '
        'Chk_MarcarImprimirDocumentos
        '
        Me.Chk_MarcarImprimirDocumentos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_MarcarImprimirDocumentos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_MarcarImprimirDocumentos.CheckBoxImageChecked = CType(resources.GetObject("Chk_MarcarImprimirDocumentos.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_MarcarImprimirDocumentos.Enabled = False
        Me.Chk_MarcarImprimirDocumentos.FocusCuesEnabled = False
        Me.Chk_MarcarImprimirDocumentos.ForeColor = System.Drawing.Color.Black
        Me.Chk_MarcarImprimirDocumentos.Location = New System.Drawing.Point(12, 349)
        Me.Chk_MarcarImprimirDocumentos.Name = "Chk_MarcarImprimirDocumentos"
        Me.Chk_MarcarImprimirDocumentos.Size = New System.Drawing.Size(593, 18)
        Me.Chk_MarcarImprimirDocumentos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_MarcarImprimirDocumentos.TabIndex = 137
        Me.Chk_MarcarImprimirDocumentos.Text = "<b>Solo marcar, no imprimir</b> (Si activa esta casilla los documentos quedaran c" &
    "omo impresos, pero no se imprimirán)"
        '
        'Timer_Clear
        '
        Me.Timer_Clear.Enabled = True
        Me.Timer_Clear.Interval = 30000
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(661, 324)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(58, 19)
        Me.LabelX1.TabIndex = 136
        Me.LabelX1.Text = "Segundos"
        '
        'Input_SegundosImpresion
        '
        Me.Input_SegundosImpresion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_SegundosImpresion.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_SegundosImpresion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_SegundosImpresion.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.Input_SegundosImpresion.Enabled = False
        Me.Input_SegundosImpresion.ForeColor = System.Drawing.Color.Black
        Me.Input_SegundosImpresion.Location = New System.Drawing.Point(612, 324)
        Me.Input_SegundosImpresion.MaxValue = 15
        Me.Input_SegundosImpresion.MinValue = 1
        Me.Input_SegundosImpresion.Name = "Input_SegundosImpresion"
        Me.Input_SegundosImpresion.ShowUpDown = True
        Me.Input_SegundosImpresion.Size = New System.Drawing.Size(43, 22)
        Me.Input_SegundosImpresion.TabIndex = 134
        Me.Input_SegundosImpresion.Value = 1
        '
        'Timer_Minimizar
        '
        Me.Timer_Minimizar.Enabled = True
        Me.Timer_Minimizar.Interval = 1000
        '
        'Frm_Dem_Imprimir
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(732, 439)
        Me.Controls.Add(Me.Chk_MarcarImprimirDocumentos)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.Input_SegundosImpresion)
        Me.Controls.Add(Me.Chk_ImprimirPicking)
        Me.Controls.Add(Me.Chk_ImprimirDocumentos)
        Me.Controls.Add(Me.ReflectionImage1)
        Me.Controls.Add(Me.Txt_Log)
        Me.Controls.Add(Me.CircularPgrs)
        Me.Controls.Add(Me.Lbl_Modalidad)
        Me.Controls.Add(Me.Lbl_Nombre_Equipo)
        Me.Controls.Add(Me.DtpFecharevision)
        Me.Controls.Add(Me.BtnCambFecha)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.Metro_Bar_Color)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Frm_Dem_Imprimir"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DIABLITO DE IMPRESIONES AUTOMATICAS"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Input_SegundosImpresion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Lbl_Modalidad As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Nombre_Equipo As DevComponents.DotNetBar.LabelX
    Friend WithEvents DtpFecharevision As DateTimePicker
    Friend WithEvents BtnCambFecha As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Configurar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Metro_Bar_Color As DevComponents.DotNetBar.Metro.MetroStatusBar
    Friend WithEvents Lbl_Estatus As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Txt_Log As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents CircularPgrs As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Timer_Segundos As Timer
    Friend WithEvents ReflectionImage1 As DevComponents.DotNetBar.Controls.ReflectionImage
    Friend WithEvents Chk_ImprimirDocumentos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_ImprimirPicking As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Chk_MarcarImprimirDocumentos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Timer_Clear As Timer
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Input_SegundosImpresion As DevComponents.Editors.IntegerInput
    Friend WithEvents Timer_Minimizar As Timer
End Class
