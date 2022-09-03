<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Crear_Meson
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Crear_Meson))
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Eliminar = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Line1 = New DevComponents.DotNetBar.Controls.Line()
        Me.Chk_SolicitaConfOperaciones = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.Chk_Maestro = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Solicita_Alerta = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Buscar_Operacion_Reproceso = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_Operacion_Reproceso = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Bucasr_Operacion_Equiv = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_Operacion_Equivalente = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Btn_Buscar_Operacion = New DevComponents.DotNetBar.ButtonX()
        Me.Chk_Meson_Virtual = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Txt_Operacion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Nommeson = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Codmeson = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.Chk_ActivaAlPrincipio = New DevComponents.DotNetBar.Controls.CheckBoxX()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar, Me.Btn_Eliminar})
        Me.Bar1.Location = New System.Drawing.Point(0, 398)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(772, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 27
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Tooltip = "Grabar"
        '
        'Btn_Eliminar
        '
        Me.Btn_Eliminar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Eliminar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Eliminar.Image = CType(resources.GetObject("Btn_Eliminar.Image"), System.Drawing.Image)
        Me.Btn_Eliminar.Name = "Btn_Eliminar"
        Me.Btn_Eliminar.Tooltip = "Eiminar"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Chk_ActivaAlPrincipio)
        Me.GroupPanel1.Controls.Add(Me.Line1)
        Me.GroupPanel1.Controls.Add(Me.Chk_SolicitaConfOperaciones)
        Me.GroupPanel1.Controls.Add(Me.LabelX7)
        Me.GroupPanel1.Controls.Add(Me.Chk_Maestro)
        Me.GroupPanel1.Controls.Add(Me.Chk_Solicita_Alerta)
        Me.GroupPanel1.Controls.Add(Me.LabelX5)
        Me.GroupPanel1.Controls.Add(Me.LabelX4)
        Me.GroupPanel1.Controls.Add(Me.Buscar_Operacion_Reproceso)
        Me.GroupPanel1.Controls.Add(Me.Txt_Operacion_Reproceso)
        Me.GroupPanel1.Controls.Add(Me.LabelX3)
        Me.GroupPanel1.Controls.Add(Me.Btn_Bucasr_Operacion_Equiv)
        Me.GroupPanel1.Controls.Add(Me.Txt_Operacion_Equivalente)
        Me.GroupPanel1.Controls.Add(Me.Btn_Buscar_Operacion)
        Me.GroupPanel1.Controls.Add(Me.Chk_Meson_Virtual)
        Me.GroupPanel1.Controls.Add(Me.Txt_Operacion)
        Me.GroupPanel1.Controls.Add(Me.LabelX2)
        Me.GroupPanel1.Controls.Add(Me.Txt_Nommeson)
        Me.GroupPanel1.Controls.Add(Me.Txt_Codmeson)
        Me.GroupPanel1.Controls.Add(Me.LabelX9)
        Me.GroupPanel1.Controls.Add(Me.LabelX6)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(750, 368)
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
        Me.GroupPanel1.TabIndex = 89
        '
        'Line1
        '
        Me.Line1.BackColor = System.Drawing.Color.Transparent
        Me.Line1.ForeColor = System.Drawing.Color.Black
        Me.Line1.Location = New System.Drawing.Point(3, 281)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(727, 23)
        Me.Line1.TabIndex = 95
        Me.Line1.Text = "Line1"
        '
        'Chk_SolicitaConfOperaciones
        '
        Me.Chk_SolicitaConfOperaciones.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_SolicitaConfOperaciones.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_SolicitaConfOperaciones.ForeColor = System.Drawing.Color.Black
        Me.Chk_SolicitaConfOperaciones.Location = New System.Drawing.Point(3, 304)
        Me.Chk_SolicitaConfOperaciones.Name = "Chk_SolicitaConfOperaciones"
        Me.Chk_SolicitaConfOperaciones.Size = New System.Drawing.Size(496, 23)
        Me.Chk_SolicitaConfOperaciones.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_SolicitaConfOperaciones.TabIndex = 94
        Me.Chk_SolicitaConfOperaciones.Text = "SOLICITAR CONFIRMAR OPERACIONES/MESONES AL GRABAR (Recomendable Servicio Técnico)" &
    ""
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.ForeColor = System.Drawing.Color.Black
        Me.LabelX7.Location = New System.Drawing.Point(3, 199)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(653, 57)
        Me.LabelX7.TabIndex = 93
        Me.LabelX7.Text = "<b>MESON MAESTRO</b> <br/>El mesón maestro es aquel mesón que activa todos los tr" &
    "abajos que estan en pausa.<br/> Trabajos que por cierto son mesones que no son v" &
    "irtuales."
        '
        'Chk_Maestro
        '
        Me.Chk_Maestro.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Maestro.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Maestro.ForeColor = System.Drawing.Color.Black
        Me.Chk_Maestro.Location = New System.Drawing.Point(3, 262)
        Me.Chk_Maestro.Name = "Chk_Maestro"
        Me.Chk_Maestro.Size = New System.Drawing.Size(138, 23)
        Me.Chk_Maestro.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Maestro.TabIndex = 91
        Me.Chk_Maestro.Text = "MESON MAESTRO"
        '
        'Chk_Solicita_Alerta
        '
        Me.Chk_Solicita_Alerta.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Solicita_Alerta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Solicita_Alerta.ForeColor = System.Drawing.Color.Black
        Me.Chk_Solicita_Alerta.Location = New System.Drawing.Point(289, 69)
        Me.Chk_Solicita_Alerta.Name = "Chk_Solicita_Alerta"
        Me.Chk_Solicita_Alerta.Size = New System.Drawing.Size(138, 23)
        Me.Chk_Solicita_Alerta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Solicita_Alerta.TabIndex = 90
        Me.Chk_Solicita_Alerta.Text = "SOLICITA ALERTA"
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(6, 143)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(68, 23)
        Me.LabelX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX5.TabIndex = 89
        Me.LabelX5.Text = "Equivalente"
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(6, 170)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(51, 23)
        Me.LabelX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX4.TabIndex = 86
        Me.LabelX4.Text = "Reproceso"
        '
        'Buscar_Operacion_Reproceso
        '
        Me.Buscar_Operacion_Reproceso.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Buscar_Operacion_Reproceso.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Buscar_Operacion_Reproceso.Location = New System.Drawing.Point(643, 169)
        Me.Buscar_Operacion_Reproceso.Name = "Buscar_Operacion_Reproceso"
        Me.Buscar_Operacion_Reproceso.Size = New System.Drawing.Size(90, 23)
        Me.Buscar_Operacion_Reproceso.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Buscar_Operacion_Reproceso.TabIndex = 85
        Me.Buscar_Operacion_Reproceso.Text = "Buscar operación"
        '
        'Txt_Operacion_Reproceso
        '
        Me.Txt_Operacion_Reproceso.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Operacion_Reproceso.Border.Class = "TextBoxBorder"
        Me.Txt_Operacion_Reproceso.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Operacion_Reproceso.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Operacion_Reproceso.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Operacion_Reproceso.FocusHighlightEnabled = True
        Me.Txt_Operacion_Reproceso.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Txt_Operacion_Reproceso.ForeColor = System.Drawing.Color.Black
        Me.Txt_Operacion_Reproceso.Location = New System.Drawing.Point(80, 170)
        Me.Txt_Operacion_Reproceso.MaxLength = 13
        Me.Txt_Operacion_Reproceso.Name = "Txt_Operacion_Reproceso"
        Me.Txt_Operacion_Reproceso.ReadOnly = True
        Me.Txt_Operacion_Reproceso.Size = New System.Drawing.Size(557, 22)
        Me.Txt_Operacion_Reproceso.TabIndex = 84
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(6, 117)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(51, 23)
        Me.LabelX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX3.TabIndex = 83
        Me.LabelX3.Text = "Regular"
        '
        'Btn_Bucasr_Operacion_Equiv
        '
        Me.Btn_Bucasr_Operacion_Equiv.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Bucasr_Operacion_Equiv.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Bucasr_Operacion_Equiv.Location = New System.Drawing.Point(643, 143)
        Me.Btn_Bucasr_Operacion_Equiv.Name = "Btn_Bucasr_Operacion_Equiv"
        Me.Btn_Bucasr_Operacion_Equiv.Size = New System.Drawing.Size(90, 23)
        Me.Btn_Bucasr_Operacion_Equiv.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Bucasr_Operacion_Equiv.TabIndex = 82
        Me.Btn_Bucasr_Operacion_Equiv.Text = "Buscar operación"
        '
        'Txt_Operacion_Equivalente
        '
        Me.Txt_Operacion_Equivalente.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Operacion_Equivalente.Border.Class = "TextBoxBorder"
        Me.Txt_Operacion_Equivalente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Operacion_Equivalente.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Operacion_Equivalente.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Operacion_Equivalente.FocusHighlightEnabled = True
        Me.Txt_Operacion_Equivalente.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Txt_Operacion_Equivalente.ForeColor = System.Drawing.Color.Black
        Me.Txt_Operacion_Equivalente.Location = New System.Drawing.Point(80, 144)
        Me.Txt_Operacion_Equivalente.MaxLength = 13
        Me.Txt_Operacion_Equivalente.Name = "Txt_Operacion_Equivalente"
        Me.Txt_Operacion_Equivalente.ReadOnly = True
        Me.Txt_Operacion_Equivalente.Size = New System.Drawing.Size(557, 22)
        Me.Txt_Operacion_Equivalente.TabIndex = 81
        '
        'Btn_Buscar_Operacion
        '
        Me.Btn_Buscar_Operacion.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Buscar_Operacion.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Buscar_Operacion.Location = New System.Drawing.Point(643, 118)
        Me.Btn_Buscar_Operacion.Name = "Btn_Buscar_Operacion"
        Me.Btn_Buscar_Operacion.Size = New System.Drawing.Size(90, 22)
        Me.Btn_Buscar_Operacion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Buscar_Operacion.TabIndex = 79
        Me.Btn_Buscar_Operacion.Text = "Buscar operación"
        '
        'Chk_Meson_Virtual
        '
        Me.Chk_Meson_Virtual.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Meson_Virtual.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Meson_Virtual.ForeColor = System.Drawing.Color.Black
        Me.Chk_Meson_Virtual.Location = New System.Drawing.Point(145, 69)
        Me.Chk_Meson_Virtual.Name = "Chk_Meson_Virtual"
        Me.Chk_Meson_Virtual.Size = New System.Drawing.Size(138, 23)
        Me.Chk_Meson_Virtual.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Meson_Virtual.TabIndex = 78
        Me.Chk_Meson_Virtual.Text = "MESON VIRTUAL"
        '
        'Txt_Operacion
        '
        Me.Txt_Operacion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Operacion.Border.Class = "TextBoxBorder"
        Me.Txt_Operacion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Operacion.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Operacion.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Operacion.FocusHighlightEnabled = True
        Me.Txt_Operacion.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Txt_Operacion.ForeColor = System.Drawing.Color.Black
        Me.Txt_Operacion.Location = New System.Drawing.Point(80, 118)
        Me.Txt_Operacion.MaxLength = 13
        Me.Txt_Operacion.Name = "Txt_Operacion"
        Me.Txt_Operacion.ReadOnly = True
        Me.Txt_Operacion.Size = New System.Drawing.Size(557, 22)
        Me.Txt_Operacion.TabIndex = 77
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(6, 90)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(133, 23)
        Me.LabelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX2.TabIndex = 76
        Me.LabelX2.Text = "OPERACION ASOCIADA"
        '
        'Txt_Nommeson
        '
        Me.Txt_Nommeson.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Nommeson.Border.Class = "TextBoxBorder"
        Me.Txt_Nommeson.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Nommeson.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Nommeson.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Nommeson.FocusHighlightEnabled = True
        Me.Txt_Nommeson.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Txt_Nommeson.ForeColor = System.Drawing.Color.Black
        Me.Txt_Nommeson.Location = New System.Drawing.Point(145, 33)
        Me.Txt_Nommeson.MaxLength = 100
        Me.Txt_Nommeson.Name = "Txt_Nommeson"
        Me.Txt_Nommeson.Size = New System.Drawing.Size(588, 22)
        Me.Txt_Nommeson.TabIndex = 74
        '
        'Txt_Codmeson
        '
        Me.Txt_Codmeson.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Codmeson.Border.Class = "TextBoxBorder"
        Me.Txt_Codmeson.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Codmeson.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Codmeson.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Codmeson.FocusHighlightEnabled = True
        Me.Txt_Codmeson.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Txt_Codmeson.ForeColor = System.Drawing.Color.Black
        Me.Txt_Codmeson.Location = New System.Drawing.Point(145, 5)
        Me.Txt_Codmeson.MaxLength = 13
        Me.Txt_Codmeson.Name = "Txt_Codmeson"
        Me.Txt_Codmeson.Size = New System.Drawing.Size(115, 22)
        Me.Txt_Codmeson.TabIndex = 73
        Me.Txt_Codmeson.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelX9
        '
        Me.LabelX9.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.LabelX9.ForeColor = System.Drawing.Color.Black
        Me.LabelX9.Location = New System.Drawing.Point(6, 5)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(133, 23)
        Me.LabelX9.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX9.TabIndex = 72
        Me.LabelX9.Text = "CODIGO MESON"
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(6, 32)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(133, 23)
        Me.LabelX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX6.TabIndex = 65
        Me.LabelX6.Text = "DESCRIPCION MESON"
        '
        'Chk_ActivaAlPrincipio
        '
        Me.Chk_ActivaAlPrincipio.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_ActivaAlPrincipio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_ActivaAlPrincipio.ForeColor = System.Drawing.Color.Black
        Me.Chk_ActivaAlPrincipio.Location = New System.Drawing.Point(3, 333)
        Me.Chk_ActivaAlPrincipio.Name = "Chk_ActivaAlPrincipio"
        Me.Chk_ActivaAlPrincipio.Size = New System.Drawing.Size(730, 23)
        Me.Chk_ActivaAlPrincipio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_ActivaAlPrincipio.TabIndex = 96
        Me.Chk_ActivaAlPrincipio.Text = "ACTIVAR OPERACION AL PRINCIPIO, CUANDO SE HAYA EJECUTADO EL MESON MAESTRO. (Eje. " &
    "Corte por hilo en fresas)"
        '
        'Frm_Crear_Meson
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(772, 439)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Crear_Meson"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MANTENCION DE MESON"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Public WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Txt_Codmeson As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Nommeson As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Btn_Eliminar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Buscar_Operacion As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Chk_Meson_Virtual As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Txt_Operacion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Bucasr_Operacion_Equiv As DevComponents.DotNetBar.ButtonX
    Public WithEvents Txt_Operacion_Equivalente As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Buscar_Operacion_Reproceso As DevComponents.DotNetBar.ButtonX
    Public WithEvents Txt_Operacion_Reproceso As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Chk_Solicita_Alerta As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Chk_Maestro As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_SolicitaConfOperaciones As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Line1 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents Chk_ActivaAlPrincipio As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
