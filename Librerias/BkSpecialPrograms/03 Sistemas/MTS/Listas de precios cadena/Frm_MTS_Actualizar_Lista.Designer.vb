<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_MTS_Actualizar_Lista
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_MTS_Actualizar_Lista))
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.BtnActualizarInformacion = New DevComponents.DotNetBar.ButtonItem
        Me.Switch_Activar = New DevComponents.DotNetBar.SwitchButtonItem
        Me.BtnEjecutarManualmente = New DevComponents.DotNetBar.ButtonItem
        Me.BtnCancelar = New DevComponents.DotNetBar.ButtonItem
        Me.Circlar_Prog_Monitoreo = New DevComponents.DotNetBar.CircularProgressItem
        Me.BtnMinimizar = New DevComponents.DotNetBar.ButtonItem
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem
        Me.Tiempo_Accion = New System.Windows.Forms.Timer(Me.components)
        Me.Tiempo_Hora_Actual = New System.Windows.Forms.Timer(Me.components)
        Me.Barra_Progreso = New DevComponents.DotNetBar.Controls.ProgressBarX
        Me.TxtLog_ = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LblEtiqueta = New DevComponents.DotNetBar.LabelX
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.Chk_GuardarConDsctos = New DevComponents.DotNetBar.Controls.CheckBoxX
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnActualizarInformacion, Me.Switch_Activar, Me.BtnEjecutarManualmente, Me.BtnCancelar, Me.Circlar_Prog_Monitoreo, Me.BtnMinimizar, Me.BtnSalir})
        Me.Bar1.Location = New System.Drawing.Point(0, 226)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(630, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 7
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnActualizarInformacion
        '
        Me.BtnActualizarInformacion.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnActualizarInformacion.ForeColor = System.Drawing.Color.Black
        Me.BtnActualizarInformacion.Image = CType(resources.GetObject("BtnActualizarInformacion.Image"), System.Drawing.Image)
        Me.BtnActualizarInformacion.Name = "BtnActualizarInformacion"
        Me.BtnActualizarInformacion.Tooltip = "Configuración automatica"
        '
        'Switch_Activar
        '
        Me.Switch_Activar.Name = "Switch_Activar"
        '
        'BtnEjecutarManualmente
        '
        Me.BtnEjecutarManualmente.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnEjecutarManualmente.ForeColor = System.Drawing.Color.Black
        Me.BtnEjecutarManualmente.Image = Global.BkSpecialPrograms.My.Resources.Resources.ok_button
        Me.BtnEjecutarManualmente.Name = "BtnEjecutarManualmente"
        Me.BtnEjecutarManualmente.Text = "Ejecutar manualmente"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnCancelar.Enabled = False
        Me.BtnCancelar.ForeColor = System.Drawing.Color.Black
        Me.BtnCancelar.Image = Global.BkSpecialPrograms.My.Resources.Resources.cancel1
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Text = "Cancelar proceso"
        '
        'Circlar_Prog_Monitoreo
        '
        Me.Circlar_Prog_Monitoreo.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.Circlar_Prog_Monitoreo.Name = "Circlar_Prog_Monitoreo"
        Me.Circlar_Prog_Monitoreo.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Dot
        Me.Circlar_Prog_Monitoreo.ProgressColor = System.Drawing.Color.SeaGreen
        Me.Circlar_Prog_Monitoreo.TextColor = System.Drawing.Color.Navy
        '
        'BtnMinimizar
        '
        Me.BtnMinimizar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnMinimizar.ForeColor = System.Drawing.Color.Black
        Me.BtnMinimizar.Image = CType(resources.GetObject("BtnMinimizar.Image"), System.Drawing.Image)
        Me.BtnMinimizar.Name = "BtnMinimizar"
        Me.BtnMinimizar.Text = "Minimizar"
        '
        'BtnSalir
        '
        Me.BtnSalir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnSalir.ForeColor = System.Drawing.Color.Black
        Me.BtnSalir.Image = Global.BkSpecialPrograms.My.Resources.Resources.button_rounded_red_delete
        Me.BtnSalir.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnSalir.Name = "BtnSalir"
        '
        'Tiempo_Accion
        '
        '
        'Tiempo_Hora_Actual
        '
        Me.Tiempo_Hora_Actual.Enabled = True
        '
        'Barra_Progreso
        '
        Me.Barra_Progreso.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.Barra_Progreso.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Barra_Progreso.ForeColor = System.Drawing.Color.Black
        Me.Barra_Progreso.Location = New System.Drawing.Point(6, 159)
        Me.Barra_Progreso.Name = "Barra_Progreso"
        Me.Barra_Progreso.Size = New System.Drawing.Size(615, 23)
        Me.Barra_Progreso.TabIndex = 44
        Me.Barra_Progreso.Text = "ProgressBarX1"
        '
        'TxtLog_
        '
        Me.TxtLog_.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtLog_.Border.Class = "TextBoxBorder"
        Me.TxtLog_.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtLog_.DisabledBackColor = System.Drawing.Color.White
        Me.TxtLog_.ForeColor = System.Drawing.Color.Black
        Me.TxtLog_.Location = New System.Drawing.Point(6, 41)
        Me.TxtLog_.Multiline = True
        Me.TxtLog_.Name = "TxtLog_"
        Me.TxtLog_.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtLog_.Size = New System.Drawing.Size(615, 112)
        Me.TxtLog_.TabIndex = 45
        '
        'LblEtiqueta
        '
        Me.LblEtiqueta.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.LblEtiqueta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblEtiqueta.ForeColor = System.Drawing.Color.Black
        Me.LblEtiqueta.Location = New System.Drawing.Point(6, 12)
        Me.LblEtiqueta.Name = "LblEtiqueta"
        Me.LblEtiqueta.Size = New System.Drawing.Size(615, 23)
        Me.LblEtiqueta.TabIndex = 46
        Me.LblEtiqueta.Text = "LabelX1"
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "Actualización costos MTS"
        '
        'Chk_GuardarConDsctos
        '
        '
        '
        '
        Me.Chk_GuardarConDsctos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_GuardarConDsctos.Location = New System.Drawing.Point(6, 188)
        Me.Chk_GuardarConDsctos.Name = "Chk_GuardarConDsctos"
        Me.Chk_GuardarConDsctos.Size = New System.Drawing.Size(275, 23)
        Me.Chk_GuardarConDsctos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_GuardarConDsctos.TabIndex = 73
        Me.Chk_GuardarConDsctos.Text = "Guardar con descuento calculado"
        '
        'Frm_MTS_Actualizar_Lista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(630, 267)
        Me.ControlBox = False
        Me.Controls.Add(Me.Chk_GuardarConDsctos)
        Me.Controls.Add(Me.LblEtiqueta)
        Me.Controls.Add(Me.TxtLog_)
        Me.Controls.Add(Me.Barra_Progreso)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_MTS_Actualizar_Lista"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ACTUALIZACION DE PRECIOS MAESTRA MTS"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnActualizarInformacion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Tiempo_Accion As System.Windows.Forms.Timer
    Friend WithEvents Switch_Activar As DevComponents.DotNetBar.SwitchButtonItem
    Friend WithEvents Tiempo_Hora_Actual As System.Windows.Forms.Timer
    Friend WithEvents Circlar_Prog_Monitoreo As DevComponents.DotNetBar.CircularProgressItem
    Friend WithEvents Barra_Progreso As DevComponents.DotNetBar.Controls.ProgressBarX
    Private WithEvents TxtLog_ As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LblEtiqueta As DevComponents.DotNetBar.LabelX
    Friend WithEvents BtnEjecutarManualmente As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnCancelar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnMinimizar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents Chk_GuardarConDsctos As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
