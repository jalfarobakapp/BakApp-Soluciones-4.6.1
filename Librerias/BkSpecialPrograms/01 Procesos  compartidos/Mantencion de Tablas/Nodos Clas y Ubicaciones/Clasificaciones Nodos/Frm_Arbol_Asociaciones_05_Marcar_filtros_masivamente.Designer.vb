<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Arbol_Asociaciones_05_Marcar_filtros_masivamente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Arbol_Asociaciones_05_Marcar_filtros_masivamente))
        Me.LblEstado_1 = New DevComponents.DotNetBar.LabelX()
        Me.Progreso_Porc = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.Progreso_Cont = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.BtnGenerar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_ImportarListado = New DevComponents.DotNetBar.ButtonItem()
        Me.TxtLog = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LblEstado_2 = New DevComponents.DotNetBar.LabelX()
        Me.Barra_Progreso_ = New DevComponents.DotNetBar.Controls.ProgressBarX()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblEstado_1
        '
        Me.LblEstado_1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LblEstado_1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblEstado_1.ForeColor = System.Drawing.Color.Black
        Me.LblEstado_1.Location = New System.Drawing.Point(12, 141)
        Me.LblEstado_1.Name = "LblEstado_1"
        Me.LblEstado_1.Size = New System.Drawing.Size(677, 23)
        Me.LblEstado_1.TabIndex = 36
        Me.LblEstado_1.Text = "Presione Porocesar...."
        '
        'Progreso_Porc
        '
        Me.Progreso_Porc.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Progreso_Porc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Progreso_Porc.Location = New System.Drawing.Point(12, 89)
        Me.Progreso_Porc.Name = "Progreso_Porc"
        Me.Progreso_Porc.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.Progreso_Porc.ProgressColor = System.Drawing.Color.SteelBlue
        Me.Progreso_Porc.ProgressTextVisible = True
        Me.Progreso_Porc.Size = New System.Drawing.Size(56, 46)
        Me.Progreso_Porc.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.Progreso_Porc.TabIndex = 35
        '
        'Progreso_Cont
        '
        Me.Progreso_Cont.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Progreso_Cont.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Progreso_Cont.Location = New System.Drawing.Point(12, 23)
        Me.Progreso_Cont.Name = "Progreso_Cont"
        Me.Progreso_Cont.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.Progreso_Cont.ProgressColor = System.Drawing.Color.SteelBlue
        Me.Progreso_Cont.ProgressTextFormat = "{0}"
        Me.Progreso_Cont.ProgressTextVisible = True
        Me.Progreso_Cont.Size = New System.Drawing.Size(56, 46)
        Me.Progreso_Cont.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.Progreso_Cont.TabIndex = 34
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnGenerar, Me.Btn_ImportarListado})
        Me.Bar2.Location = New System.Drawing.Point(0, 223)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(698, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 33
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'BtnGenerar
        '
        Me.BtnGenerar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnGenerar.ForeColor = System.Drawing.Color.Black
        Me.BtnGenerar.Image = CType(resources.GetObject("BtnGenerar.Image"), System.Drawing.Image)
        Me.BtnGenerar.Name = "BtnGenerar"
        Me.BtnGenerar.Text = "Re-clasificar todos los productos, volver a generar arbol"
        '
        'Btn_ImportarListado
        '
        Me.Btn_ImportarListado.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_ImportarListado.ForeColor = System.Drawing.Color.Black
        Me.Btn_ImportarListado.Image = CType(resources.GetObject("Btn_ImportarListado.Image"), System.Drawing.Image)
        Me.Btn_ImportarListado.Name = "Btn_ImportarListado"
        Me.Btn_ImportarListado.Tooltip = "Importar listado de cambio de códigos masivamente"
        Me.Btn_ImportarListado.Visible = False
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
        Me.TxtLog.Location = New System.Drawing.Point(74, 23)
        Me.TxtLog.Multiline = True
        Me.TxtLog.Name = "TxtLog"
        Me.TxtLog.ReadOnly = True
        Me.TxtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtLog.Size = New System.Drawing.Size(615, 112)
        Me.TxtLog.TabIndex = 32
        '
        'LblEstado_2
        '
        Me.LblEstado_2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LblEstado_2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblEstado_2.ForeColor = System.Drawing.Color.Black
        Me.LblEstado_2.Location = New System.Drawing.Point(12, 161)
        Me.LblEstado_2.Name = "LblEstado_2"
        Me.LblEstado_2.Size = New System.Drawing.Size(677, 23)
        Me.LblEstado_2.TabIndex = 37
        Me.LblEstado_2.Text = "Presione Porocesar...."
        '
        'Barra_Progreso_
        '
        Me.Barra_Progreso_.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Barra_Progreso_.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Barra_Progreso_.ForeColor = System.Drawing.Color.Black
        Me.Barra_Progreso_.Location = New System.Drawing.Point(12, 190)
        Me.Barra_Progreso_.Name = "Barra_Progreso_"
        Me.Barra_Progreso_.Size = New System.Drawing.Size(674, 26)
        Me.Barra_Progreso_.TabIndex = 38
        Me.Barra_Progreso_.Text = "Barra estado..."
        Me.Barra_Progreso_.TextVisible = True
        '
        'Frm_Arbol_Asociaciones_05_Marcar_filtros_masivamente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(698, 264)
        Me.Controls.Add(Me.Barra_Progreso_)
        Me.Controls.Add(Me.LblEstado_2)
        Me.Controls.Add(Me.LblEstado_1)
        Me.Controls.Add(Me.Progreso_Porc)
        Me.Controls.Add(Me.Progreso_Cont)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.TxtLog)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Arbol_Asociaciones_05_Marcar_filtros_masivamente"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LblEstado_1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Progreso_Porc As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Progreso_Cont As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Private WithEvents TxtLog As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents BtnGenerar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_ImportarListado As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LblEstado_2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Barra_Progreso_ As DevComponents.DotNetBar.Controls.ProgressBarX
End Class
