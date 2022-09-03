<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Ranking_Menu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Ranking_Menu))
        Me.Fecha_Estudio_desde = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Fecha_Estudio_hasta = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.RdPmTrans = New System.Windows.Forms.RadioButton()
        Me.CmbListaDeCostos = New System.Windows.Forms.ComboBox()
        Me.RdLP = New System.Windows.Forms.RadioButton()
        Me.RdUC = New System.Windows.Forms.RadioButton()
        Me.RdPM = New System.Windows.Forms.RadioButton()
        Me.Fecha_Desde_Desc = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Fecha_Hasta_Desc = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.BtnProcesarInf = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnEntExcluidas = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Ver_Ranking_Actual = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnRevInfAnterior = New DevComponents.DotNetBar.ButtonItem()
        Me.Grupo_Fechas_Estudio = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Grupo_Fecha_Descontinuados = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Grupo_Opciones = New DevComponents.DotNetBar.Controls.GroupPanel()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_Fechas_Estudio.SuspendLayout()
        Me.Grupo_Fecha_Descontinuados.SuspendLayout()
        Me.Grupo_Opciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Fecha_Estudio_desde
        '
        Me.Fecha_Estudio_desde.BackColor = System.Drawing.Color.White
        Me.Fecha_Estudio_desde.ForeColor = System.Drawing.Color.Black
        Me.Fecha_Estudio_desde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Fecha_Estudio_desde.Location = New System.Drawing.Point(6, 30)
        Me.Fecha_Estudio_desde.Name = "Fecha_Estudio_desde"
        Me.Fecha_Estudio_desde.Size = New System.Drawing.Size(82, 22)
        Me.Fecha_Estudio_desde.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(99, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Hasta"
        '
        'Fecha_Estudio_hasta
        '
        Me.Fecha_Estudio_hasta.BackColor = System.Drawing.Color.White
        Me.Fecha_Estudio_hasta.ForeColor = System.Drawing.Color.Black
        Me.Fecha_Estudio_hasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Fecha_Estudio_hasta.Location = New System.Drawing.Point(102, 30)
        Me.Fecha_Estudio_hasta.Name = "Fecha_Estudio_hasta"
        Me.Fecha_Estudio_hasta.Size = New System.Drawing.Size(82, 22)
        Me.Fecha_Estudio_hasta.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(3, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Desde"
        '
        'RdPmTrans
        '
        Me.RdPmTrans.AutoSize = True
        Me.RdPmTrans.BackColor = System.Drawing.Color.Transparent
        Me.RdPmTrans.Checked = True
        Me.RdPmTrans.ForeColor = System.Drawing.Color.Black
        Me.RdPmTrans.Location = New System.Drawing.Point(3, 20)
        Me.RdPmTrans.Name = "RdPmTrans"
        Me.RdPmTrans.Size = New System.Drawing.Size(349, 17)
        Me.RdPmTrans.TabIndex = 9
        Me.RdPmTrans.TabStop = True
        Me.RdPmTrans.Text = "Precio promedio ponderado al momento de la transacción (PM)"
        Me.RdPmTrans.UseVisualStyleBackColor = False
        '
        'CmbListaDeCostos
        '
        Me.CmbListaDeCostos.BackColor = System.Drawing.Color.White
        Me.CmbListaDeCostos.ForeColor = System.Drawing.Color.Black
        Me.CmbListaDeCostos.FormattingEnabled = True
        Me.CmbListaDeCostos.Location = New System.Drawing.Point(3, 112)
        Me.CmbListaDeCostos.Name = "CmbListaDeCostos"
        Me.CmbListaDeCostos.Size = New System.Drawing.Size(220, 21)
        Me.CmbListaDeCostos.TabIndex = 8
        '
        'RdLP
        '
        Me.RdLP.AutoSize = True
        Me.RdLP.BackColor = System.Drawing.Color.Transparent
        Me.RdLP.ForeColor = System.Drawing.Color.Black
        Me.RdLP.Location = New System.Drawing.Point(3, 89)
        Me.RdLP.Name = "RdLP"
        Me.RdLP.Size = New System.Drawing.Size(234, 17)
        Me.RdLP.TabIndex = 7
        Me.RdLP.Text = "Según lista de costo/precio a seleccionar"
        Me.RdLP.UseVisualStyleBackColor = False
        '
        'RdUC
        '
        Me.RdUC.AutoSize = True
        Me.RdUC.BackColor = System.Drawing.Color.Transparent
        Me.RdUC.ForeColor = System.Drawing.Color.Black
        Me.RdUC.Location = New System.Drawing.Point(3, 66)
        Me.RdUC.Name = "RdUC"
        Me.RdUC.Size = New System.Drawing.Size(132, 17)
        Me.RdUC.TabIndex = 4
        Me.RdUC.Text = "Precio ultima compra"
        Me.RdUC.UseVisualStyleBackColor = False
        '
        'RdPM
        '
        Me.RdPM.AutoSize = True
        Me.RdPM.BackColor = System.Drawing.Color.Transparent
        Me.RdPM.ForeColor = System.Drawing.Color.Black
        Me.RdPM.Location = New System.Drawing.Point(3, 43)
        Me.RdPM.Name = "RdPM"
        Me.RdPM.Size = New System.Drawing.Size(195, 17)
        Me.RdPM.TabIndex = 1
        Me.RdPM.Text = "Precio promedio ponderado (PM)"
        Me.RdPM.UseVisualStyleBackColor = False
        '
        'Fecha_Desde_Desc
        '
        Me.Fecha_Desde_Desc.BackColor = System.Drawing.Color.White
        Me.Fecha_Desde_Desc.ForeColor = System.Drawing.Color.Black
        Me.Fecha_Desde_Desc.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Fecha_Desde_Desc.Location = New System.Drawing.Point(6, 32)
        Me.Fecha_Desde_Desc.Name = "Fecha_Desde_Desc"
        Me.Fecha_Desde_Desc.Size = New System.Drawing.Size(82, 22)
        Me.Fecha_Desde_Desc.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(99, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Hasta"
        '
        'Fecha_Hasta_Desc
        '
        Me.Fecha_Hasta_Desc.BackColor = System.Drawing.Color.White
        Me.Fecha_Hasta_Desc.ForeColor = System.Drawing.Color.Black
        Me.Fecha_Hasta_Desc.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Fecha_Hasta_Desc.Location = New System.Drawing.Point(102, 32)
        Me.Fecha_Hasta_Desc.Name = "Fecha_Hasta_Desc"
        Me.Fecha_Hasta_Desc.Size = New System.Drawing.Size(82, 22)
        Me.Fecha_Hasta_Desc.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(3, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Desde"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnProcesarInf, Me.BtnEntExcluidas, Me.Btn_Ver_Ranking_Actual, Me.BtnRevInfAnterior})
        Me.Bar1.Location = New System.Drawing.Point(0, 285)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(446, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 27
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnProcesarInf
        '
        Me.BtnProcesarInf.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnProcesarInf.ForeColor = System.Drawing.Color.Black
        Me.BtnProcesarInf.Image = CType(resources.GetObject("BtnProcesarInf.Image"), System.Drawing.Image)
        Me.BtnProcesarInf.Name = "BtnProcesarInf"
        Me.BtnProcesarInf.Text = "Procesar informe"
        '
        'BtnEntExcluidas
        '
        Me.BtnEntExcluidas.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnEntExcluidas.ForeColor = System.Drawing.Color.Black
        Me.BtnEntExcluidas.Image = CType(resources.GetObject("BtnEntExcluidas.Image"), System.Drawing.Image)
        Me.BtnEntExcluidas.Name = "BtnEntExcluidas"
        Me.BtnEntExcluidas.Tooltip = "Exportar Excel Ranking actual"
        '
        'Btn_Ver_Ranking_Actual
        '
        Me.Btn_Ver_Ranking_Actual.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Ver_Ranking_Actual.ForeColor = System.Drawing.Color.Black
        Me.Btn_Ver_Ranking_Actual.Image = CType(resources.GetObject("Btn_Ver_Ranking_Actual.Image"), System.Drawing.Image)
        Me.Btn_Ver_Ranking_Actual.Name = "Btn_Ver_Ranking_Actual"
        Me.Btn_Ver_Ranking_Actual.Text = "Ver Ranking Actual"
        '
        'BtnRevInfAnterior
        '
        Me.BtnRevInfAnterior.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnRevInfAnterior.ForeColor = System.Drawing.Color.Black
        Me.BtnRevInfAnterior.Name = "BtnRevInfAnterior"
        Me.BtnRevInfAnterior.Tooltip = "Ver ultimo informe"
        '
        'Grupo_Fechas_Estudio
        '
        Me.Grupo_Fechas_Estudio.BackColor = System.Drawing.Color.White
        Me.Grupo_Fechas_Estudio.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Fechas_Estudio.Controls.Add(Me.Fecha_Estudio_desde)
        Me.Grupo_Fechas_Estudio.Controls.Add(Me.Label5)
        Me.Grupo_Fechas_Estudio.Controls.Add(Me.Label4)
        Me.Grupo_Fechas_Estudio.Controls.Add(Me.Fecha_Estudio_hasta)
        Me.Grupo_Fechas_Estudio.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Fechas_Estudio.Location = New System.Drawing.Point(12, 12)
        Me.Grupo_Fechas_Estudio.Name = "Grupo_Fechas_Estudio"
        Me.Grupo_Fechas_Estudio.Size = New System.Drawing.Size(201, 81)
        '
        '
        '
        Me.Grupo_Fechas_Estudio.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Fechas_Estudio.Style.BackColorGradientAngle = 90
        Me.Grupo_Fechas_Estudio.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Fechas_Estudio.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Fechas_Estudio.Style.BorderBottomWidth = 1
        Me.Grupo_Fechas_Estudio.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Fechas_Estudio.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Fechas_Estudio.Style.BorderLeftWidth = 1
        Me.Grupo_Fechas_Estudio.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Fechas_Estudio.Style.BorderRightWidth = 1
        Me.Grupo_Fechas_Estudio.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Fechas_Estudio.Style.BorderTopWidth = 1
        Me.Grupo_Fechas_Estudio.Style.CornerDiameter = 4
        Me.Grupo_Fechas_Estudio.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Fechas_Estudio.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Fechas_Estudio.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Fechas_Estudio.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Fechas_Estudio.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Fechas_Estudio.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Fechas_Estudio.TabIndex = 28
        Me.Grupo_Fechas_Estudio.Text = "Rango de fechas a estudiar"
        '
        'Grupo_Fecha_Descontinuados
        '
        Me.Grupo_Fecha_Descontinuados.BackColor = System.Drawing.Color.White
        Me.Grupo_Fecha_Descontinuados.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Fecha_Descontinuados.Controls.Add(Me.Fecha_Desde_Desc)
        Me.Grupo_Fecha_Descontinuados.Controls.Add(Me.Label2)
        Me.Grupo_Fecha_Descontinuados.Controls.Add(Me.Label1)
        Me.Grupo_Fecha_Descontinuados.Controls.Add(Me.Fecha_Hasta_Desc)
        Me.Grupo_Fecha_Descontinuados.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Fecha_Descontinuados.Location = New System.Drawing.Point(230, 12)
        Me.Grupo_Fecha_Descontinuados.Name = "Grupo_Fecha_Descontinuados"
        Me.Grupo_Fecha_Descontinuados.Size = New System.Drawing.Size(201, 81)
        '
        '
        '
        Me.Grupo_Fecha_Descontinuados.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Fecha_Descontinuados.Style.BackColorGradientAngle = 90
        Me.Grupo_Fecha_Descontinuados.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Fecha_Descontinuados.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Fecha_Descontinuados.Style.BorderBottomWidth = 1
        Me.Grupo_Fecha_Descontinuados.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Fecha_Descontinuados.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Fecha_Descontinuados.Style.BorderLeftWidth = 1
        Me.Grupo_Fecha_Descontinuados.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Fecha_Descontinuados.Style.BorderRightWidth = 1
        Me.Grupo_Fecha_Descontinuados.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Fecha_Descontinuados.Style.BorderTopWidth = 1
        Me.Grupo_Fecha_Descontinuados.Style.CornerDiameter = 4
        Me.Grupo_Fecha_Descontinuados.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Fecha_Descontinuados.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Fecha_Descontinuados.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Fecha_Descontinuados.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Fecha_Descontinuados.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Fecha_Descontinuados.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Fecha_Descontinuados.TabIndex = 29
        Me.Grupo_Fecha_Descontinuados.Text = "Rango de fechas, descontinuados"
        '
        'Grupo_Opciones
        '
        Me.Grupo_Opciones.BackColor = System.Drawing.Color.White
        Me.Grupo_Opciones.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Opciones.Controls.Add(Me.RdPmTrans)
        Me.Grupo_Opciones.Controls.Add(Me.CmbListaDeCostos)
        Me.Grupo_Opciones.Controls.Add(Me.RdPM)
        Me.Grupo_Opciones.Controls.Add(Me.RdLP)
        Me.Grupo_Opciones.Controls.Add(Me.RdUC)
        Me.Grupo_Opciones.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Opciones.Location = New System.Drawing.Point(12, 108)
        Me.Grupo_Opciones.Name = "Grupo_Opciones"
        Me.Grupo_Opciones.Size = New System.Drawing.Size(419, 167)
        '
        '
        '
        Me.Grupo_Opciones.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Opciones.Style.BackColorGradientAngle = 90
        Me.Grupo_Opciones.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Opciones.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Opciones.Style.BorderBottomWidth = 1
        Me.Grupo_Opciones.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Opciones.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Opciones.Style.BorderLeftWidth = 1
        Me.Grupo_Opciones.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Opciones.Style.BorderRightWidth = 1
        Me.Grupo_Opciones.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Opciones.Style.BorderTopWidth = 1
        Me.Grupo_Opciones.Style.CornerDiameter = 4
        Me.Grupo_Opciones.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Opciones.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Opciones.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Opciones.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Opciones.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Opciones.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Opciones.TabIndex = 30
        Me.Grupo_Opciones.Text = "Datos para considerar costo (Indispensable para calcular margen)"
        '
        'Frm_Ranking_Menu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(446, 326)
        Me.Controls.Add(Me.Grupo_Opciones)
        Me.Controls.Add(Me.Grupo_Fecha_Descontinuados)
        Me.Controls.Add(Me.Grupo_Fechas_Estudio)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Ranking_Menu"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ranking de productos"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo_Fechas_Estudio.ResumeLayout(False)
        Me.Grupo_Fechas_Estudio.PerformLayout()
        Me.Grupo_Fecha_Descontinuados.ResumeLayout(False)
        Me.Grupo_Fecha_Descontinuados.PerformLayout()
        Me.Grupo_Opciones.ResumeLayout(False)
        Me.Grupo_Opciones.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Fecha_Estudio_desde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Fecha_Estudio_hasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents RdPmTrans As System.Windows.Forms.RadioButton
    Friend WithEvents CmbListaDeCostos As System.Windows.Forms.ComboBox
    Friend WithEvents RdLP As System.Windows.Forms.RadioButton
    Friend WithEvents RdUC As System.Windows.Forms.RadioButton
    Friend WithEvents RdPM As System.Windows.Forms.RadioButton
    Friend WithEvents Fecha_Desde_Desc As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Fecha_Hasta_Desc As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnProcesarInf As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnRevInfAnterior As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnEntExcluidas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Ver_Ranking_Actual As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grupo_Fechas_Estudio As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grupo_Opciones As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grupo_Fecha_Descontinuados As DevComponents.DotNetBar.Controls.GroupPanel
End Class
