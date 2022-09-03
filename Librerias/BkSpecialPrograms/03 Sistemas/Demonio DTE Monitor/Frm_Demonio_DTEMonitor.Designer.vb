<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Demonio_DTEMonitor
    Inherits DevComponents.DotNetBar.Metro.MetroForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Demonio_DTEMonitor))
        Me.CircularPgrs = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.Lbl_Nombre_Equipo = New DevComponents.DotNetBar.LabelX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Limpiar = New DevComponents.DotNetBar.ButtonItem()
        Me.Metro_Bar_Color = New DevComponents.DotNetBar.Metro.MetroStatusBar()
        Me.Lbl_Estatus = New DevComponents.DotNetBar.LabelItem()
        Me.Timer_Hora_Actual = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_Segundos = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_Enviar_SII = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_Consultar_TrackId = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_Enviar_Correos = New System.Windows.Forms.Timer(Me.components)
        Me.Chk_AmbienteCertificacion = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Txt_Log = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Timer_Minimizar = New System.Windows.Forms.Timer(Me.components)
        Me.Chk_MostrarBoletaBkHfDOS = New DevComponents.DotNetBar.Controls.CheckBoxX()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.CircularPgrs.Location = New System.Drawing.Point(617, 15)
        Me.CircularPgrs.Name = "CircularPgrs"
        Me.CircularPgrs.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Dot
        Me.CircularPgrs.ProgressColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CircularPgrs.Size = New System.Drawing.Size(35, 20)
        Me.CircularPgrs.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.CircularPgrs.TabIndex = 3
        '
        'Lbl_Nombre_Equipo
        '
        Me.Lbl_Nombre_Equipo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Nombre_Equipo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Nombre_Equipo.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Nombre_Equipo.Location = New System.Drawing.Point(12, 12)
        Me.Lbl_Nombre_Equipo.Name = "Lbl_Nombre_Equipo"
        Me.Lbl_Nombre_Equipo.Size = New System.Drawing.Size(605, 23)
        Me.Lbl_Nombre_Equipo.TabIndex = 69
        Me.Lbl_Nombre_Equipo.Text = "Nombre Equipo..."
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Limpiar})
        Me.Bar1.Location = New System.Drawing.Point(0, 396)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(662, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 64
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Limpiar
        '
        Me.Btn_Limpiar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Limpiar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Limpiar.Image = CType(resources.GetObject("Btn_Limpiar.Image"), System.Drawing.Image)
        Me.Btn_Limpiar.ImageAlt = CType(resources.GetObject("Btn_Limpiar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Limpiar.Name = "Btn_Limpiar"
        Me.Btn_Limpiar.Tooltip = "Limpiar log..."
        '
        'Metro_Bar_Color
        '
        Me.Metro_Bar_Color.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Metro_Bar_Color.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Metro_Bar_Color.ContainerControlProcessDialogKey = True
        Me.Metro_Bar_Color.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Metro_Bar_Color.DragDropSupport = True
        Me.Metro_Bar_Color.Font = New System.Drawing.Font("Segoe UI", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Metro_Bar_Color.ForeColor = System.Drawing.Color.Black
        Me.Metro_Bar_Color.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Lbl_Estatus})
        Me.Metro_Bar_Color.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.Metro_Bar_Color.Location = New System.Drawing.Point(0, 437)
        Me.Metro_Bar_Color.Name = "Metro_Bar_Color"
        Me.Metro_Bar_Color.Size = New System.Drawing.Size(662, 22)
        Me.Metro_Bar_Color.TabIndex = 71
        Me.Metro_Bar_Color.Text = "MetroStatusBar1"
        '
        'Lbl_Estatus
        '
        Me.Lbl_Estatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Estatus.Name = "Lbl_Estatus"
        Me.Lbl_Estatus.Text = "LabelItem2"
        '
        'Timer_Hora_Actual
        '
        Me.Timer_Hora_Actual.Interval = 1000
        '
        'Timer_Segundos
        '
        Me.Timer_Segundos.Interval = 1000
        '
        'Timer_Enviar_SII
        '
        Me.Timer_Enviar_SII.Interval = 1000
        '
        'Timer_Consultar_TrackId
        '
        Me.Timer_Consultar_TrackId.Interval = 1000
        '
        'Timer_Enviar_Correos
        '
        Me.Timer_Enviar_Correos.Interval = 1000
        '
        'Chk_AmbienteCertificacion
        '
        Me.Chk_AmbienteCertificacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.Chk_AmbienteCertificacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_AmbienteCertificacion.Enabled = False
        Me.Chk_AmbienteCertificacion.Location = New System.Drawing.Point(12, 370)
        Me.Chk_AmbienteCertificacion.Name = "Chk_AmbienteCertificacion"
        Me.Chk_AmbienteCertificacion.Size = New System.Drawing.Size(264, 23)
        Me.Chk_AmbienteCertificacion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_AmbienteCertificacion.TabIndex = 72
        Me.Chk_AmbienteCertificacion.Text = "Trabajar en Ambiente de Certificación (pruebas)"
        '
        'Txt_Log
        '
        Me.Txt_Log.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt_Log.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Log.Border.Class = "TextBoxBorder"
        Me.Txt_Log.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Log.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Log.ForeColor = System.Drawing.Color.Black
        Me.Txt_Log.Location = New System.Drawing.Point(12, 41)
        Me.Txt_Log.Multiline = True
        Me.Txt_Log.Name = "Txt_Log"
        Me.Txt_Log.PreventEnterBeep = True
        Me.Txt_Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Log.Size = New System.Drawing.Size(640, 320)
        Me.Txt_Log.TabIndex = 73
        '
        'Timer_Minimizar
        '
        Me.Timer_Minimizar.Enabled = True
        Me.Timer_Minimizar.Interval = 1000
        '
        'Chk_MostrarBoletaBkHfDOS
        '
        Me.Chk_MostrarBoletaBkHfDOS.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.Chk_MostrarBoletaBkHfDOS.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_MostrarBoletaBkHfDOS.Location = New System.Drawing.Point(269, 370)
        Me.Chk_MostrarBoletaBkHfDOS.Name = "Chk_MostrarBoletaBkHfDOS"
        Me.Chk_MostrarBoletaBkHfDOS.Size = New System.Drawing.Size(224, 23)
        Me.Chk_MostrarBoletaBkHfDOS.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_MostrarBoletaBkHfDOS.TabIndex = 74
        Me.Chk_MostrarBoletaBkHfDOS.Text = "Mostrar ejecución BoletaBkHf (MS-DOS)"
        '
        'Frm_Demonio_DTEMonitor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(662, 459)
        Me.Controls.Add(Me.Chk_MostrarBoletaBkHfDOS)
        Me.Controls.Add(Me.Txt_Log)
        Me.Controls.Add(Me.Chk_AmbienteCertificacion)
        Me.Controls.Add(Me.CircularPgrs)
        Me.Controls.Add(Me.Lbl_Nombre_Equipo)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.Metro_Bar_Color)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(678, 498)
        Me.MinimumSize = New System.Drawing.Size(501, 299)
        Me.Name = "Frm_Demonio_DTEMonitor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CircularPgrs As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Lbl_Nombre_Equipo As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Limpiar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Metro_Bar_Color As DevComponents.DotNetBar.Metro.MetroStatusBar
    Friend WithEvents Lbl_Estatus As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Timer_Hora_Actual As Timer
    Friend WithEvents Timer_Segundos As Timer
    Friend WithEvents Timer_Enviar_SII As Timer
    Friend WithEvents Timer_Consultar_TrackId As Timer
    Friend WithEvents Timer_Enviar_Correos As Timer
    Friend WithEvents Chk_AmbienteCertificacion As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Txt_Log As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Timer_Minimizar As Timer
    Friend WithEvents Chk_MostrarBoletaBkHfDOS As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
