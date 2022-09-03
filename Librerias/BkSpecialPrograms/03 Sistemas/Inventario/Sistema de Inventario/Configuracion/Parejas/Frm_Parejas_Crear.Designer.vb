<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Parejas_Crear
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Parejas_Crear))
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Eliminar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Crear_Operador = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Ubicaciones_Plan = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Btn_Quitar_Capturador = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Agregar_Capturador = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_Capturador = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.Sw_Habilitado = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Btn_Agregar_Operador2 = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Quitar_Operador2 = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Agregar_Operador1 = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Quitar_Operador1 = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_Operario2 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Operario1 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Nombre_Pareja = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar, Me.Btn_Eliminar, Me.Btn_Crear_Operador, Me.Btn_Ubicaciones_Plan})
        Me.Bar1.Location = New System.Drawing.Point(0, 228)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(597, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 39
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.ImageAlt = CType(resources.GetObject("Btn_Grabar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Tooltip = "Crear Inventario"
        '
        'Btn_Eliminar
        '
        Me.Btn_Eliminar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Eliminar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Eliminar.Image = CType(resources.GetObject("Btn_Eliminar.Image"), System.Drawing.Image)
        Me.Btn_Eliminar.ImageAlt = CType(resources.GetObject("Btn_Eliminar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Eliminar.Name = "Btn_Eliminar"
        Me.Btn_Eliminar.Tooltip = "Eliminar"
        '
        'Btn_Crear_Operador
        '
        Me.Btn_Crear_Operador.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Crear_Operador.ForeColor = System.Drawing.Color.Black
        Me.Btn_Crear_Operador.Image = CType(resources.GetObject("Btn_Crear_Operador.Image"), System.Drawing.Image)
        Me.Btn_Crear_Operador.Name = "Btn_Crear_Operador"
        Me.Btn_Crear_Operador.Tooltip = "Operadores"
        Me.Btn_Crear_Operador.Visible = False
        '
        'Btn_Ubicaciones_Plan
        '
        Me.Btn_Ubicaciones_Plan.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Ubicaciones_Plan.ForeColor = System.Drawing.Color.Black
        Me.Btn_Ubicaciones_Plan.Image = CType(resources.GetObject("Btn_Ubicaciones_Plan.Image"), System.Drawing.Image)
        Me.Btn_Ubicaciones_Plan.Name = "Btn_Ubicaciones_Plan"
        Me.Btn_Ubicaciones_Plan.Text = "Plan..."
        Me.Btn_Ubicaciones_Plan.Tooltip = "Ubicaciones para esta pareja"
        Me.Btn_Ubicaciones_Plan.Visible = False
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Btn_Quitar_Capturador)
        Me.GroupPanel1.Controls.Add(Me.Btn_Agregar_Capturador)
        Me.GroupPanel1.Controls.Add(Me.Txt_Capturador)
        Me.GroupPanel1.Controls.Add(Me.LabelX4)
        Me.GroupPanel1.Controls.Add(Me.LabelX7)
        Me.GroupPanel1.Controls.Add(Me.Sw_Habilitado)
        Me.GroupPanel1.Controls.Add(Me.Btn_Agregar_Operador2)
        Me.GroupPanel1.Controls.Add(Me.Btn_Quitar_Operador2)
        Me.GroupPanel1.Controls.Add(Me.Btn_Agregar_Operador1)
        Me.GroupPanel1.Controls.Add(Me.Btn_Quitar_Operador1)
        Me.GroupPanel1.Controls.Add(Me.Txt_Operario2)
        Me.GroupPanel1.Controls.Add(Me.LabelX2)
        Me.GroupPanel1.Controls.Add(Me.Txt_Operario1)
        Me.GroupPanel1.Controls.Add(Me.LabelX1)
        Me.GroupPanel1.Controls.Add(Me.Txt_Nombre_Pareja)
        Me.GroupPanel1.Controls.Add(Me.LabelX3)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 6)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(579, 197)
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
        Me.GroupPanel1.TabIndex = 38
        Me.GroupPanel1.Text = "Pareja"
        '
        'Btn_Quitar_Capturador
        '
        Me.Btn_Quitar_Capturador.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Quitar_Capturador.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Quitar_Capturador.Image = CType(resources.GetObject("Btn_Quitar_Capturador.Image"), System.Drawing.Image)
        Me.Btn_Quitar_Capturador.Location = New System.Drawing.Point(443, 99)
        Me.Btn_Quitar_Capturador.Name = "Btn_Quitar_Capturador"
        Me.Btn_Quitar_Capturador.Size = New System.Drawing.Size(36, 23)
        Me.Btn_Quitar_Capturador.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Quitar_Capturador.TabIndex = 20
        Me.Btn_Quitar_Capturador.Tooltip = "Quitar operador 1"
        '
        'Btn_Agregar_Capturador
        '
        Me.Btn_Agregar_Capturador.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Agregar_Capturador.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Agregar_Capturador.Image = CType(resources.GetObject("Btn_Agregar_Capturador.Image"), System.Drawing.Image)
        Me.Btn_Agregar_Capturador.Location = New System.Drawing.Point(401, 99)
        Me.Btn_Agregar_Capturador.Name = "Btn_Agregar_Capturador"
        Me.Btn_Agregar_Capturador.Size = New System.Drawing.Size(36, 23)
        Me.Btn_Agregar_Capturador.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Agregar_Capturador.TabIndex = 19
        Me.Btn_Agregar_Capturador.Tooltip = "Agregar operador 1"
        '
        'Txt_Capturador
        '
        Me.Txt_Capturador.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Capturador.Border.Class = "TextBoxBorder"
        Me.Txt_Capturador.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Capturador.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Capturador.ForeColor = System.Drawing.Color.Black
        Me.Txt_Capturador.Location = New System.Drawing.Point(84, 99)
        Me.Txt_Capturador.MaxLength = 50
        Me.Txt_Capturador.Name = "Txt_Capturador"
        Me.Txt_Capturador.PreventEnterBeep = True
        Me.Txt_Capturador.ReadOnly = True
        Me.Txt_Capturador.Size = New System.Drawing.Size(311, 22)
        Me.Txt_Capturador.TabIndex = 18
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(3, 99)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(75, 23)
        Me.LabelX4.TabIndex = 17
        Me.LabelX4.Text = "Capturador"
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.ForeColor = System.Drawing.Color.Black
        Me.LabelX7.Location = New System.Drawing.Point(3, 148)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(75, 23)
        Me.LabelX7.TabIndex = 16
        Me.LabelX7.Text = "Estado"
        '
        'Sw_Habilitado
        '
        Me.Sw_Habilitado.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Sw_Habilitado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Sw_Habilitado.ForeColor = System.Drawing.Color.Black
        Me.Sw_Habilitado.Location = New System.Drawing.Point(84, 148)
        Me.Sw_Habilitado.Name = "Sw_Habilitado"
        Me.Sw_Habilitado.OffText = "Deshabilitado"
        Me.Sw_Habilitado.OnText = "Habilitado"
        Me.Sw_Habilitado.Size = New System.Drawing.Size(108, 22)
        Me.Sw_Habilitado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Sw_Habilitado.TabIndex = 15
        '
        'Btn_Agregar_Operador2
        '
        Me.Btn_Agregar_Operador2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Agregar_Operador2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Agregar_Operador2.Image = CType(resources.GetObject("Btn_Agregar_Operador2.Image"), System.Drawing.Image)
        Me.Btn_Agregar_Operador2.Location = New System.Drawing.Point(488, 70)
        Me.Btn_Agregar_Operador2.Name = "Btn_Agregar_Operador2"
        Me.Btn_Agregar_Operador2.Size = New System.Drawing.Size(36, 23)
        Me.Btn_Agregar_Operador2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Agregar_Operador2.TabIndex = 14
        Me.Btn_Agregar_Operador2.Tooltip = "Agregar operador 1"
        '
        'Btn_Quitar_Operador2
        '
        Me.Btn_Quitar_Operador2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Quitar_Operador2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Quitar_Operador2.Image = CType(resources.GetObject("Btn_Quitar_Operador2.Image"), System.Drawing.Image)
        Me.Btn_Quitar_Operador2.Location = New System.Drawing.Point(530, 71)
        Me.Btn_Quitar_Operador2.Name = "Btn_Quitar_Operador2"
        Me.Btn_Quitar_Operador2.Size = New System.Drawing.Size(36, 23)
        Me.Btn_Quitar_Operador2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Quitar_Operador2.TabIndex = 13
        Me.Btn_Quitar_Operador2.Tooltip = "Quitar operador 1"
        '
        'Btn_Agregar_Operador1
        '
        Me.Btn_Agregar_Operador1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Agregar_Operador1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Agregar_Operador1.Image = CType(resources.GetObject("Btn_Agregar_Operador1.Image"), System.Drawing.Image)
        Me.Btn_Agregar_Operador1.Location = New System.Drawing.Point(488, 43)
        Me.Btn_Agregar_Operador1.Name = "Btn_Agregar_Operador1"
        Me.Btn_Agregar_Operador1.Size = New System.Drawing.Size(36, 23)
        Me.Btn_Agregar_Operador1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Agregar_Operador1.TabIndex = 12
        Me.Btn_Agregar_Operador1.Tooltip = "Agregar operador 1"
        '
        'Btn_Quitar_Operador1
        '
        Me.Btn_Quitar_Operador1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Quitar_Operador1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Quitar_Operador1.Image = CType(resources.GetObject("Btn_Quitar_Operador1.Image"), System.Drawing.Image)
        Me.Btn_Quitar_Operador1.Location = New System.Drawing.Point(530, 43)
        Me.Btn_Quitar_Operador1.Name = "Btn_Quitar_Operador1"
        Me.Btn_Quitar_Operador1.Size = New System.Drawing.Size(36, 23)
        Me.Btn_Quitar_Operador1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Quitar_Operador1.TabIndex = 10
        Me.Btn_Quitar_Operador1.Tooltip = "Quitar operador 1"
        '
        'Txt_Operario2
        '
        Me.Txt_Operario2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Operario2.Border.Class = "TextBoxBorder"
        Me.Txt_Operario2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Operario2.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Operario2.ForeColor = System.Drawing.Color.Black
        Me.Txt_Operario2.Location = New System.Drawing.Point(84, 71)
        Me.Txt_Operario2.MaxLength = 50
        Me.Txt_Operario2.Name = "Txt_Operario2"
        Me.Txt_Operario2.PreventEnterBeep = True
        Me.Txt_Operario2.ReadOnly = True
        Me.Txt_Operario2.Size = New System.Drawing.Size(395, 22)
        Me.Txt_Operario2.TabIndex = 9
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 71)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 23)
        Me.LabelX2.TabIndex = 8
        Me.LabelX2.Text = "Operario 2"
        '
        'Txt_Operario1
        '
        Me.Txt_Operario1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Operario1.Border.Class = "TextBoxBorder"
        Me.Txt_Operario1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Operario1.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Operario1.ForeColor = System.Drawing.Color.Black
        Me.Txt_Operario1.Location = New System.Drawing.Point(84, 43)
        Me.Txt_Operario1.MaxLength = 50
        Me.Txt_Operario1.Name = "Txt_Operario1"
        Me.Txt_Operario1.PreventEnterBeep = True
        Me.Txt_Operario1.ReadOnly = True
        Me.Txt_Operario1.Size = New System.Drawing.Size(395, 22)
        Me.Txt_Operario1.TabIndex = 7
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 43)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 23)
        Me.LabelX1.TabIndex = 6
        Me.LabelX1.Text = "Operario 1"
        '
        'Txt_Nombre_Pareja
        '
        Me.Txt_Nombre_Pareja.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Nombre_Pareja.Border.Class = "TextBoxBorder"
        Me.Txt_Nombre_Pareja.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Nombre_Pareja.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Nombre_Pareja.ForeColor = System.Drawing.Color.Black
        Me.Txt_Nombre_Pareja.Location = New System.Drawing.Point(84, 15)
        Me.Txt_Nombre_Pareja.MaxLength = 30
        Me.Txt_Nombre_Pareja.Name = "Txt_Nombre_Pareja"
        Me.Txt_Nombre_Pareja.PreventEnterBeep = True
        Me.Txt_Nombre_Pareja.Size = New System.Drawing.Size(395, 22)
        Me.Txt_Nombre_Pareja.TabIndex = 5
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(3, 15)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(75, 23)
        Me.LabelX3.TabIndex = 4
        Me.LabelX3.Text = "Nombre pareja"
        '
        'Frm_Parejas_Crear
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(597, 269)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.GroupPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Parejas_Crear"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MANTENCION DE PAREJA"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Eliminar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Btn_Quitar_Operador1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Txt_Operario2 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Operario1 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Nombre_Pareja As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Agregar_Operador1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Agregar_Operador2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Quitar_Operador2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Crear_Operador As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Sw_Habilitado As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents Btn_Ubicaciones_Plan As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Quitar_Capturador As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Agregar_Capturador As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Txt_Capturador As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
End Class
