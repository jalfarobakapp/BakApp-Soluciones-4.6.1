<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Cambio_Codigos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Cambio_Codigos))
        Me.Barra_Progreso_ = New DevComponents.DotNetBar.Controls.ProgressBarX()
        Me.LblEstado_2 = New DevComponents.DotNetBar.LabelX()
        Me.LblEstado_1 = New DevComponents.DotNetBar.LabelX()
        Me.Progreso_Porc = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.Progreso_Cont = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_ImportarListado = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnBuscarArchivoLevantar = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnListadoEjemplo = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnCancelar = New DevComponents.DotNetBar.ButtonItem()
        Me.TxtLog = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.ChkCambiarCodigoTecnico = New DevComponents.DotNetBar.Controls.CheckBoxX()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Barra_Progreso_
        '
        Me.Barra_Progreso_.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Barra_Progreso_.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Barra_Progreso_.ForeColor = System.Drawing.Color.Black
        Me.Barra_Progreso_.Location = New System.Drawing.Point(3, 179)
        Me.Barra_Progreso_.Name = "Barra_Progreso_"
        Me.Barra_Progreso_.Size = New System.Drawing.Size(677, 26)
        Me.Barra_Progreso_.TabIndex = 45
        Me.Barra_Progreso_.Text = "Barra estado..."
        Me.Barra_Progreso_.TextVisible = True
        '
        'LblEstado_2
        '
        Me.LblEstado_2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LblEstado_2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblEstado_2.ForeColor = System.Drawing.Color.Black
        Me.LblEstado_2.Location = New System.Drawing.Point(3, 150)
        Me.LblEstado_2.Name = "LblEstado_2"
        Me.LblEstado_2.Size = New System.Drawing.Size(677, 23)
        Me.LblEstado_2.TabIndex = 44
        Me.LblEstado_2.Text = "Presione Porocesar...."
        '
        'LblEstado_1
        '
        Me.LblEstado_1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LblEstado_1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblEstado_1.ForeColor = System.Drawing.Color.Black
        Me.LblEstado_1.Location = New System.Drawing.Point(3, 130)
        Me.LblEstado_1.Name = "LblEstado_1"
        Me.LblEstado_1.Size = New System.Drawing.Size(534, 23)
        Me.LblEstado_1.TabIndex = 43
        Me.LblEstado_1.Text = "Presione Porocesar...."
        '
        'Progreso_Porc
        '
        Me.Progreso_Porc.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Progreso_Porc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Progreso_Porc.Location = New System.Drawing.Point(3, 78)
        Me.Progreso_Porc.Name = "Progreso_Porc"
        Me.Progreso_Porc.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.Progreso_Porc.ProgressColor = System.Drawing.Color.Green
        Me.Progreso_Porc.ProgressTextVisible = True
        Me.Progreso_Porc.Size = New System.Drawing.Size(56, 46)
        Me.Progreso_Porc.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.Progreso_Porc.TabIndex = 42
        '
        'Progreso_Cont
        '
        Me.Progreso_Cont.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Progreso_Cont.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Progreso_Cont.Location = New System.Drawing.Point(3, 12)
        Me.Progreso_Cont.Name = "Progreso_Cont"
        Me.Progreso_Cont.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.Progreso_Cont.ProgressColor = System.Drawing.Color.Green
        Me.Progreso_Cont.ProgressTextFormat = "{0}"
        Me.Progreso_Cont.ProgressTextVisible = True
        Me.Progreso_Cont.Size = New System.Drawing.Size(56, 46)
        Me.Progreso_Cont.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.Progreso_Cont.TabIndex = 41
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_ImportarListado, Me.BtnCancelar})
        Me.Bar2.Location = New System.Drawing.Point(0, 225)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(688, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 40
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_ImportarListado
        '
        Me.Btn_ImportarListado.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_ImportarListado.ForeColor = System.Drawing.Color.Black
        Me.Btn_ImportarListado.Image = CType(resources.GetObject("Btn_ImportarListado.Image"), System.Drawing.Image)
        Me.Btn_ImportarListado.Name = "Btn_ImportarListado"
        Me.Btn_ImportarListado.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnBuscarArchivoLevantar, Me.BtnListadoEjemplo})
        Me.Btn_ImportarListado.Tooltip = "Importar listado de cambio de códigos masivamente"
        '
        'BtnBuscarArchivoLevantar
        '
        Me.BtnBuscarArchivoLevantar.Image = CType(resources.GetObject("BtnBuscarArchivoLevantar.Image"), System.Drawing.Image)
        Me.BtnBuscarArchivoLevantar.Name = "BtnBuscarArchivoLevantar"
        Me.BtnBuscarArchivoLevantar.Text = "Buscar archivo para levantar (Procesar)"
        '
        'BtnListadoEjemplo
        '
        Me.BtnListadoEjemplo.Image = CType(resources.GetObject("BtnListadoEjemplo.Image"), System.Drawing.Image)
        Me.BtnListadoEjemplo.Name = "BtnListadoEjemplo"
        Me.BtnListadoEjemplo.Text = "Listado de ejemplo para levantar"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnCancelar.Enabled = False
        Me.BtnCancelar.ForeColor = System.Drawing.Color.Black
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Text = "Cancelar"
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
        Me.TxtLog.Location = New System.Drawing.Point(65, 12)
        Me.TxtLog.Multiline = True
        Me.TxtLog.Name = "TxtLog"
        Me.TxtLog.ReadOnly = True
        Me.TxtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtLog.Size = New System.Drawing.Size(615, 112)
        Me.TxtLog.TabIndex = 39
        '
        'ChkCambiarCodigoTecnico
        '
        Me.ChkCambiarCodigoTecnico.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.ChkCambiarCodigoTecnico.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ChkCambiarCodigoTecnico.ForeColor = System.Drawing.Color.Black
        Me.ChkCambiarCodigoTecnico.Location = New System.Drawing.Point(543, 130)
        Me.ChkCambiarCodigoTecnico.Name = "ChkCambiarCodigoTecnico"
        Me.ChkCambiarCodigoTecnico.Size = New System.Drawing.Size(137, 23)
        Me.ChkCambiarCodigoTecnico.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ChkCambiarCodigoTecnico.TabIndex = 46
        Me.ChkCambiarCodigoTecnico.Text = "Cambiar código técnico"
        '
        'Frm_Cambio_Codigos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(688, 266)
        Me.Controls.Add(Me.ChkCambiarCodigoTecnico)
        Me.Controls.Add(Me.Barra_Progreso_)
        Me.Controls.Add(Me.LblEstado_2)
        Me.Controls.Add(Me.LblEstado_1)
        Me.Controls.Add(Me.Progreso_Porc)
        Me.Controls.Add(Me.Progreso_Cont)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.TxtLog)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Cambio_Codigos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cambio de productos masivamente"
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Barra_Progreso_ As DevComponents.DotNetBar.Controls.ProgressBarX
    Friend WithEvents LblEstado_2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LblEstado_1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Progreso_Porc As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Progreso_Cont As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Public WithEvents BtnCancelar As DevComponents.DotNetBar.ButtonItem
    Private WithEvents TxtLog As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Btn_ImportarListado As DevComponents.DotNetBar.ButtonItem
    Public WithEvents ChkCambiarCodigoTecnico As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents BtnBuscarArchivoLevantar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnListadoEjemplo As DevComponents.DotNetBar.ButtonItem
End Class
