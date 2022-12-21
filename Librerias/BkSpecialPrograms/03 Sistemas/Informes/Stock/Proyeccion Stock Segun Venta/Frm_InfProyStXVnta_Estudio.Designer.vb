<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_InfProyStXVnta_Estudio
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_InfProyStXVnta_Estudio))
        Me.Btn_Bodega_Vta_Estudio = New DevComponents.DotNetBar.ButtonX()
        Me.Input_MesesProyeccion = New DevComponents.Editors.IntegerInput()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Input_MesesEstudio = New DevComponents.Editors.IntegerInput()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Procesar_Informe = New DevComponents.DotNetBar.ButtonItem()
        CType(Me.Input_MesesProyeccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Input_MesesEstudio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Btn_Bodega_Vta_Estudio
        '
        Me.Btn_Bodega_Vta_Estudio.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Bodega_Vta_Estudio.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Bodega_Vta_Estudio.Image = CType(resources.GetObject("Btn_Bodega_Vta_Estudio.Image"), System.Drawing.Image)
        Me.Btn_Bodega_Vta_Estudio.ImageAlt = CType(resources.GetObject("Btn_Bodega_Vta_Estudio.ImageAlt"), System.Drawing.Image)
        Me.Btn_Bodega_Vta_Estudio.Location = New System.Drawing.Point(344, 23)
        Me.Btn_Bodega_Vta_Estudio.Name = "Btn_Bodega_Vta_Estudio"
        Me.Btn_Bodega_Vta_Estudio.Size = New System.Drawing.Size(132, 22)
        Me.Btn_Bodega_Vta_Estudio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Bodega_Vta_Estudio.TabIndex = 129
        Me.Btn_Bodega_Vta_Estudio.Text = "Bodegas de estudio"
        '
        'Input_MesesProyeccion
        '
        Me.Input_MesesProyeccion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_MesesProyeccion.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_MesesProyeccion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_MesesProyeccion.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.Input_MesesProyeccion.ForeColor = System.Drawing.Color.Black
        Me.Input_MesesProyeccion.Location = New System.Drawing.Point(283, 22)
        Me.Input_MesesProyeccion.MaxValue = 12
        Me.Input_MesesProyeccion.MinValue = 3
        Me.Input_MesesProyeccion.Name = "Input_MesesProyeccion"
        Me.Input_MesesProyeccion.ShowUpDown = True
        Me.Input_MesesProyeccion.Size = New System.Drawing.Size(42, 22)
        Me.Input_MesesProyeccion.TabIndex = 127
        Me.Input_MesesProyeccion.Value = 6
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(190, 22)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(98, 23)
        Me.LabelX3.TabIndex = 128
        Me.LabelX3.Text = "Meses proyección"
        '
        'Input_MesesEstudio
        '
        Me.Input_MesesEstudio.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_MesesEstudio.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_MesesEstudio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_MesesEstudio.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.Input_MesesEstudio.ForeColor = System.Drawing.Color.Black
        Me.Input_MesesEstudio.Location = New System.Drawing.Point(140, 22)
        Me.Input_MesesEstudio.MaxValue = 24
        Me.Input_MesesEstudio.MinValue = 1
        Me.Input_MesesEstudio.Name = "Input_MesesEstudio"
        Me.Input_MesesEstudio.ShowUpDown = True
        Me.Input_MesesEstudio.Size = New System.Drawing.Size(44, 22)
        Me.Input_MesesEstudio.TabIndex = 125
        Me.Input_MesesEstudio.Value = 3
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 22)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(151, 23)
        Me.LabelX2.TabIndex = 126
        Me.LabelX2.Text = "Meses estudio prom. venta"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Btn_Bodega_Vta_Estudio)
        Me.GroupPanel1.Controls.Add(Me.Input_MesesEstudio)
        Me.GroupPanel1.Controls.Add(Me.Input_MesesProyeccion)
        Me.GroupPanel1.Controls.Add(Me.LabelX3)
        Me.GroupPanel1.Controls.Add(Me.LabelX2)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(492, 100)
        '
        '
        '
        Me.GroupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel1.Style.BackColorGradientAngle = 90
        Me.GroupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderBottomWidth = 1
        Me.GroupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderLeftWidth = 1
        Me.GroupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderRightWidth = 1
        Me.GroupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderTopWidth = 1
        Me.GroupPanel1.Style.CornerDiameter = 4
        Me.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel1.TabIndex = 130
        Me.GroupPanel1.Text = "Datos para el estudio"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Procesar_Informe})
        Me.Bar1.Location = New System.Drawing.Point(0, 133)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(513, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 131
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Procesar_Informe
        '
        Me.Btn_Procesar_Informe.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Procesar_Informe.ForeColor = System.Drawing.Color.Black
        Me.Btn_Procesar_Informe.Image = CType(resources.GetObject("Btn_Procesar_Informe.Image"), System.Drawing.Image)
        Me.Btn_Procesar_Informe.ImageAlt = CType(resources.GetObject("Btn_Procesar_Informe.ImageAlt"), System.Drawing.Image)
        Me.Btn_Procesar_Informe.Name = "Btn_Procesar_Informe"
        Me.Btn_Procesar_Informe.Text = "Procesar"
        '
        'Frm_InfProyStXVnta_Estudio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(513, 174)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.GroupPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_InfProyStXVnta_Estudio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "INFORME DE PROYECCION DE STOCK SEGUN VENTAS"
        CType(Me.Input_MesesProyeccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Input_MesesEstudio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Btn_Bodega_Vta_Estudio As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Input_MesesProyeccion As DevComponents.Editors.IntegerInput
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Input_MesesEstudio As DevComponents.Editors.IntegerInput
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Procesar_Informe As DevComponents.DotNetBar.ButtonItem
End Class
