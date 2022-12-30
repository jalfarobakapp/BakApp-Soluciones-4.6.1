<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Consolidacion_Stock_PP
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Consolidacion_Stock_PP))
        Me.Progreso_Porc = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.Progreso_Cont = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.BtnProcesar = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnCancelar = New DevComponents.DotNetBar.ButtonItem()
        Me.Barra_Progreso = New DevComponents.DotNetBar.Controls.ProgressBarX()
        Me.LblEstado = New DevComponents.DotNetBar.LabelX()
        Me.TxtLog = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Tiempo_Accion_Automatico = New System.Windows.Forms.Timer(Me.components)
        Me.Chk_Reservar_Ventas_Pendientes_Bakapp = New DevComponents.DotNetBar.Controls.CheckBoxX()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Progreso_Porc
        '
        Me.Progreso_Porc.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Progreso_Porc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Progreso_Porc.FocusCuesEnabled = False
        Me.Progreso_Porc.Location = New System.Drawing.Point(65, 12)
        Me.Progreso_Porc.Name = "Progreso_Porc"
        Me.Progreso_Porc.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.Progreso_Porc.ProgressColor = System.Drawing.Color.SteelBlue
        Me.Progreso_Porc.ProgressTextVisible = True
        Me.Progreso_Porc.Size = New System.Drawing.Size(47, 46)
        Me.Progreso_Porc.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.Progreso_Porc.TabIndex = 33
        '
        'Progreso_Cont
        '
        Me.Progreso_Cont.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Progreso_Cont.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Progreso_Cont.FocusCuesEnabled = False
        Me.Progreso_Cont.Location = New System.Drawing.Point(12, 12)
        Me.Progreso_Cont.Name = "Progreso_Cont"
        Me.Progreso_Cont.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.Progreso_Cont.ProgressColor = System.Drawing.Color.SteelBlue
        Me.Progreso_Cont.ProgressTextFormat = "{0}"
        Me.Progreso_Cont.ProgressTextVisible = True
        Me.Progreso_Cont.Size = New System.Drawing.Size(47, 46)
        Me.Progreso_Cont.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.Progreso_Cont.TabIndex = 32
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnProcesar, Me.BtnCancelar})
        Me.Bar2.Location = New System.Drawing.Point(0, 191)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(794, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 35
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'BtnProcesar
        '
        Me.BtnProcesar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnProcesar.ForeColor = System.Drawing.Color.Black
        Me.BtnProcesar.Image = CType(resources.GetObject("BtnProcesar.Image"), System.Drawing.Image)
        Me.BtnProcesar.ImageAlt = CType(resources.GetObject("BtnProcesar.ImageAlt"), System.Drawing.Image)
        Me.BtnProcesar.Name = "BtnProcesar"
        Me.BtnProcesar.Text = "CONSOLIDAR"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnCancelar.Enabled = False
        Me.BtnCancelar.ForeColor = System.Drawing.Color.Black
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Text = "CANCELAR"
        '
        'Barra_Progreso
        '
        Me.Barra_Progreso.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Barra_Progreso.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Barra_Progreso.ForeColor = System.Drawing.Color.Black
        Me.Barra_Progreso.Location = New System.Drawing.Point(12, 131)
        Me.Barra_Progreso.Name = "Barra_Progreso"
        Me.Barra_Progreso.Size = New System.Drawing.Size(770, 23)
        Me.Barra_Progreso.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Barra_Progreso.TabIndex = 36
        Me.Barra_Progreso.TextVisible = True
        '
        'LblEstado
        '
        Me.LblEstado.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LblEstado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblEstado.ForeColor = System.Drawing.Color.Black
        Me.LblEstado.Location = New System.Drawing.Point(12, 105)
        Me.LblEstado.Name = "LblEstado"
        Me.LblEstado.Size = New System.Drawing.Size(444, 20)
        Me.LblEstado.TabIndex = 37
        Me.LblEstado.Text = "..."
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
        Me.TxtLog.Location = New System.Drawing.Point(118, 1)
        Me.TxtLog.Multiline = True
        Me.TxtLog.Name = "TxtLog"
        Me.TxtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtLog.Size = New System.Drawing.Size(664, 98)
        Me.TxtLog.TabIndex = 38
        '
        'Tiempo_Accion_Automatico
        '
        Me.Tiempo_Accion_Automatico.Interval = 1000
        '
        'Chk_Reservar_Ventas_Pendientes_Bakapp
        '
        Me.Chk_Reservar_Ventas_Pendientes_Bakapp.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Reservar_Ventas_Pendientes_Bakapp.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Reservar_Ventas_Pendientes_Bakapp.Checked = True
        Me.Chk_Reservar_Ventas_Pendientes_Bakapp.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_Reservar_Ventas_Pendientes_Bakapp.CheckValue = "Y"
        Me.Chk_Reservar_Ventas_Pendientes_Bakapp.FocusCuesEnabled = False
        Me.Chk_Reservar_Ventas_Pendientes_Bakapp.ForeColor = System.Drawing.Color.Black
        Me.Chk_Reservar_Ventas_Pendientes_Bakapp.Location = New System.Drawing.Point(12, 160)
        Me.Chk_Reservar_Ventas_Pendientes_Bakapp.Name = "Chk_Reservar_Ventas_Pendientes_Bakapp"
        Me.Chk_Reservar_Ventas_Pendientes_Bakapp.Size = New System.Drawing.Size(687, 23)
        Me.Chk_Reservar_Ventas_Pendientes_Bakapp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Reservar_Ventas_Pendientes_Bakapp.TabIndex = 40
        Me.Chk_Reservar_Ventas_Pendientes_Bakapp.Text = "Reservar el Stock PEDIDO con ventas en transito en Bakapp (pendientes de permisos" &
    " remotos)"
        '
        'Frm_Consolidacion_Stock_PP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(794, 232)
        Me.Controls.Add(Me.Chk_Reservar_Ventas_Pendientes_Bakapp)
        Me.Controls.Add(Me.TxtLog)
        Me.Controls.Add(Me.LblEstado)
        Me.Controls.Add(Me.Barra_Progreso)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.Progreso_Porc)
        Me.Controls.Add(Me.Progreso_Cont)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Consolidacion_Stock_PP"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CONSOLIDACION DE STOCK FISICO"
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Progreso_Porc As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Progreso_Cont As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnProcesar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Barra_Progreso As DevComponents.DotNetBar.Controls.ProgressBarX
    Friend WithEvents LblEstado As DevComponents.DotNetBar.LabelX
    Private WithEvents TxtLog As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Tiempo_Accion_Automatico As System.Windows.Forms.Timer
    Public WithEvents BtnCancelar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Chk_Reservar_Ventas_Pendientes_Bakapp As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
