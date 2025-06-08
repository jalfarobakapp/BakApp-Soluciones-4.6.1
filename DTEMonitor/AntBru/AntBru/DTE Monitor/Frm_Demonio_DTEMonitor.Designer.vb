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
        Me.Btn_Pruebas = New DevComponents.DotNetBar.ButtonItem()
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
        Me.Chk_FirmarDocumentos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Chk_EnviarCorreos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_ConsultarTrackid = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_EnviarDTE = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_RevisarReclamoDTE = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Timer_RevisarReclamoDTE = New System.Windows.Forms.Timer(Me.components)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
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
        Me.CircularPgrs.FocusCuesEnabled = False
        Me.CircularPgrs.Location = New System.Drawing.Point(714, 15)
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
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Limpiar, Me.Btn_Pruebas})
        Me.Bar1.Location = New System.Drawing.Point(0, 478)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(759, 41)
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
        'Btn_Pruebas
        '
        Me.Btn_Pruebas.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Pruebas.ForeColor = System.Drawing.Color.Black
        Me.Btn_Pruebas.Image = CType(resources.GetObject("Btn_Pruebas.Image"), System.Drawing.Image)
        Me.Btn_Pruebas.ImageAlt = CType(resources.GetObject("Btn_Pruebas.ImageAlt"), System.Drawing.Image)
        Me.Btn_Pruebas.Name = "Btn_Pruebas"
        Me.Btn_Pruebas.Text = "PRUEBAS"
        Me.Btn_Pruebas.Tooltip = "Limpiar log..."
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
        Me.Metro_Bar_Color.Location = New System.Drawing.Point(0, 519)
        Me.Metro_Bar_Color.Name = "Metro_Bar_Color"
        Me.Metro_Bar_Color.Size = New System.Drawing.Size(759, 22)
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
        Me.Chk_AmbienteCertificacion.CheckBoxImageChecked = CType(resources.GetObject("Chk_AmbienteCertificacion.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_AmbienteCertificacion.Enabled = False
        Me.Chk_AmbienteCertificacion.FocusCuesEnabled = False
        Me.Chk_AmbienteCertificacion.Location = New System.Drawing.Point(4, 4)
        Me.Chk_AmbienteCertificacion.Name = "Chk_AmbienteCertificacion"
        Me.Chk_AmbienteCertificacion.Size = New System.Drawing.Size(255, 13)
        Me.Chk_AmbienteCertificacion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_AmbienteCertificacion.TabIndex = 72
        Me.Chk_AmbienteCertificacion.TabStop = False
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
        Me.Txt_Log.Size = New System.Drawing.Size(737, 321)
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
        Me.Chk_MostrarBoletaBkHfDOS.Location = New System.Drawing.Point(807, 330)
        Me.Chk_MostrarBoletaBkHfDOS.Name = "Chk_MostrarBoletaBkHfDOS"
        Me.Chk_MostrarBoletaBkHfDOS.Size = New System.Drawing.Size(224, 23)
        Me.Chk_MostrarBoletaBkHfDOS.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_MostrarBoletaBkHfDOS.TabIndex = 74
        Me.Chk_MostrarBoletaBkHfDOS.Text = "Mostrar ejecución BoletaBkHf (MS-DOS)"
        '
        'Chk_FirmarDocumentos
        '
        Me.Chk_FirmarDocumentos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.Chk_FirmarDocumentos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_FirmarDocumentos.CheckBoxImageChecked = CType(resources.GetObject("Chk_FirmarDocumentos.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_FirmarDocumentos.Checked = True
        Me.Chk_FirmarDocumentos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_FirmarDocumentos.CheckValue = "Y"
        Me.Chk_FirmarDocumentos.FocusCuesEnabled = False
        Me.Chk_FirmarDocumentos.Location = New System.Drawing.Point(4, 24)
        Me.Chk_FirmarDocumentos.Name = "Chk_FirmarDocumentos"
        Me.Chk_FirmarDocumentos.Size = New System.Drawing.Size(255, 13)
        Me.Chk_FirmarDocumentos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_FirmarDocumentos.TabIndex = 75
        Me.Chk_FirmarDocumentos.TabStop = False
        Me.Chk_FirmarDocumentos.Text = "Firmar documentos"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Chk_EnviarCorreos, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Chk_ConsultarTrackid, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Chk_EnviarDTE, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Chk_AmbienteCertificacion, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Chk_FirmarDocumentos, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Chk_RevisarReclamoDTE, 1, 3)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 371)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(564, 104)
        Me.TableLayoutPanel1.TabIndex = 77
        '
        'Chk_EnviarCorreos
        '
        Me.Chk_EnviarCorreos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.Chk_EnviarCorreos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_EnviarCorreos.CheckBoxImageChecked = CType(resources.GetObject("Chk_EnviarCorreos.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_EnviarCorreos.Checked = True
        Me.Chk_EnviarCorreos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_EnviarCorreos.CheckValue = "Y"
        Me.Chk_EnviarCorreos.FocusCuesEnabled = False
        Me.Chk_EnviarCorreos.Location = New System.Drawing.Point(4, 84)
        Me.Chk_EnviarCorreos.Name = "Chk_EnviarCorreos"
        Me.Chk_EnviarCorreos.Size = New System.Drawing.Size(255, 16)
        Me.Chk_EnviarCorreos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_EnviarCorreos.TabIndex = 80
        Me.Chk_EnviarCorreos.TabStop = False
        Me.Chk_EnviarCorreos.Text = "Enviar correos"
        '
        'Chk_ConsultarTrackid
        '
        Me.Chk_ConsultarTrackid.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.Chk_ConsultarTrackid.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_ConsultarTrackid.CheckBoxImageChecked = CType(resources.GetObject("Chk_ConsultarTrackid.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_ConsultarTrackid.Checked = True
        Me.Chk_ConsultarTrackid.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_ConsultarTrackid.CheckValue = "Y"
        Me.Chk_ConsultarTrackid.FocusCuesEnabled = False
        Me.Chk_ConsultarTrackid.Location = New System.Drawing.Point(4, 64)
        Me.Chk_ConsultarTrackid.Name = "Chk_ConsultarTrackid"
        Me.Chk_ConsultarTrackid.Size = New System.Drawing.Size(255, 13)
        Me.Chk_ConsultarTrackid.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_ConsultarTrackid.TabIndex = 79
        Me.Chk_ConsultarTrackid.TabStop = False
        Me.Chk_ConsultarTrackid.Text = "Consultar TrackId"
        '
        'Chk_EnviarDTE
        '
        Me.Chk_EnviarDTE.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.Chk_EnviarDTE.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_EnviarDTE.CheckBoxImageChecked = CType(resources.GetObject("Chk_EnviarDTE.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_EnviarDTE.Checked = True
        Me.Chk_EnviarDTE.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_EnviarDTE.CheckValue = "Y"
        Me.Chk_EnviarDTE.FocusCuesEnabled = False
        Me.Chk_EnviarDTE.Location = New System.Drawing.Point(4, 44)
        Me.Chk_EnviarDTE.Name = "Chk_EnviarDTE"
        Me.Chk_EnviarDTE.Size = New System.Drawing.Size(255, 13)
        Me.Chk_EnviarDTE.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_EnviarDTE.TabIndex = 78
        Me.Chk_EnviarDTE.TabStop = False
        Me.Chk_EnviarDTE.Text = "Enviar DTE"
        '
        'Chk_RevisarReclamoDTE
        '
        Me.Chk_RevisarReclamoDTE.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.Chk_RevisarReclamoDTE.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_RevisarReclamoDTE.CheckBoxImageChecked = CType(resources.GetObject("Chk_RevisarReclamoDTE.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_RevisarReclamoDTE.Checked = True
        Me.Chk_RevisarReclamoDTE.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_RevisarReclamoDTE.CheckValue = "Y"
        Me.Chk_RevisarReclamoDTE.Enabled = False
        Me.Chk_RevisarReclamoDTE.FocusCuesEnabled = False
        Me.Chk_RevisarReclamoDTE.Location = New System.Drawing.Point(266, 64)
        Me.Chk_RevisarReclamoDTE.Name = "Chk_RevisarReclamoDTE"
        Me.Chk_RevisarReclamoDTE.Size = New System.Drawing.Size(251, 13)
        Me.Chk_RevisarReclamoDTE.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_RevisarReclamoDTE.TabIndex = 81
        Me.Chk_RevisarReclamoDTE.TabStop = False
        Me.Chk_RevisarReclamoDTE.Text = "Revisar reclamo de documentos"
        '
        'Timer_RevisarReclamoDTE
        '
        Me.Timer_RevisarReclamoDTE.Interval = 5000
        '
        'Frm_Demonio_DTEMonitor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(759, 541)
        Me.Controls.Add(Me.Chk_MostrarBoletaBkHfDOS)
        Me.Controls.Add(Me.Txt_Log)
        Me.Controls.Add(Me.CircularPgrs)
        Me.Controls.Add(Me.Lbl_Nombre_Equipo)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.Metro_Bar_Color)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(775, 580)
        Me.MinimumSize = New System.Drawing.Size(501, 402)
        Me.Name = "Frm_Demonio_DTEMonitor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
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
    Friend WithEvents Chk_FirmarDocumentos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Chk_EnviarCorreos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_ConsultarTrackid As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_EnviarDTE As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Btn_Pruebas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Chk_RevisarReclamoDTE As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Timer_RevisarReclamoDTE As Timer
End Class
