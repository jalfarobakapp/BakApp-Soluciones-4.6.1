<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Direc_Cli
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Direc_Cli))
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Btn_Traer_Datos_Transportista = New DevComponents.DotNetBar.ButtonX()
        Me.Chk_Usar_HA = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Txt_Nombre_Contacto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Chk_Por_Defecto = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Txt_Comuna = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX24 = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Direccion_Servicio = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Buscar_Comuna = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Buscar_Transportista = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_Transportista = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Btn_Buscar_Tipo_Venta = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_Tipo_Venta = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Email = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Direccion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Telefono = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Btn_Modificar_Horario = New DevComponents.DotNetBar.ButtonX()
        Me.Layauot_HA = New System.Windows.Forms.TableLayoutPanel()
        Me.Dtp_HA_Tarde_Desde = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Dtp_HA_Tarde_Hasta = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Lbl_Hora_Termino = New DevComponents.DotNetBar.LabelX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_HA_Manana_Hasta = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Dtp_HA_Manana_Desde = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.Layauot_HA.SuspendLayout()
        CType(Me.Dtp_HA_Tarde_Desde, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_HA_Tarde_Hasta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_HA_Manana_Hasta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_HA_Manana_Desde, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar})
        Me.Bar2.Location = New System.Drawing.Point(0, 395)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(619, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 92
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.ImageAlt = CType(resources.GetObject("Btn_Grabar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Grabar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Tooltip = "Grabar [F4]"
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Btn_Traer_Datos_Transportista)
        Me.GroupPanel2.Controls.Add(Me.Chk_Usar_HA)
        Me.GroupPanel2.Controls.Add(Me.Txt_Nombre_Contacto)
        Me.GroupPanel2.Controls.Add(Me.LabelX2)
        Me.GroupPanel2.Controls.Add(Me.Chk_Por_Defecto)
        Me.GroupPanel2.Controls.Add(Me.Txt_Comuna)
        Me.GroupPanel2.Controls.Add(Me.LabelX24)
        Me.GroupPanel2.Controls.Add(Me.Btn_Direccion_Servicio)
        Me.GroupPanel2.Controls.Add(Me.Btn_Buscar_Comuna)
        Me.GroupPanel2.Controls.Add(Me.Btn_Buscar_Transportista)
        Me.GroupPanel2.Controls.Add(Me.Txt_Transportista)
        Me.GroupPanel2.Controls.Add(Me.Btn_Buscar_Tipo_Venta)
        Me.GroupPanel2.Controls.Add(Me.Txt_Tipo_Venta)
        Me.GroupPanel2.Controls.Add(Me.Txt_Email)
        Me.GroupPanel2.Controls.Add(Me.Txt_Direccion)
        Me.GroupPanel2.Controls.Add(Me.Txt_Telefono)
        Me.GroupPanel2.Controls.Add(Me.LabelX3)
        Me.GroupPanel2.Controls.Add(Me.LabelX6)
        Me.GroupPanel2.Controls.Add(Me.LabelX4)
        Me.GroupPanel2.Controls.Add(Me.LabelX5)
        Me.GroupPanel2.Controls.Add(Me.LabelX1)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(12, 3)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(596, 290)
        '
        '
        '
        Me.GroupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel2.Style.BackColorGradientAngle = 90
        Me.GroupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderBottomWidth = 1
        Me.GroupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderLeftWidth = 1
        Me.GroupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderRightWidth = 1
        Me.GroupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderTopWidth = 1
        Me.GroupPanel2.Style.CornerDiameter = 4
        Me.GroupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel2.TabIndex = 91
        Me.GroupPanel2.Text = "Dirección de despacho"
        '
        'Btn_Traer_Datos_Transportista
        '
        Me.Btn_Traer_Datos_Transportista.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Traer_Datos_Transportista.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Traer_Datos_Transportista.Image = CType(resources.GetObject("Btn_Traer_Datos_Transportista.Image"), System.Drawing.Image)
        Me.Btn_Traer_Datos_Transportista.ImageAlt = CType(resources.GetObject("Btn_Traer_Datos_Transportista.ImageAlt"), System.Drawing.Image)
        Me.Btn_Traer_Datos_Transportista.Location = New System.Drawing.Point(413, 205)
        Me.Btn_Traer_Datos_Transportista.Name = "Btn_Traer_Datos_Transportista"
        Me.Btn_Traer_Datos_Transportista.Size = New System.Drawing.Size(174, 22)
        Me.Btn_Traer_Datos_Transportista.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Traer_Datos_Transportista.TabIndex = 150
        Me.Btn_Traer_Datos_Transportista.Text = "Utilizar dirección transportista"
        Me.Btn_Traer_Datos_Transportista.Tooltip = "Utilizar datos de la dirección del transportista"
        '
        'Chk_Usar_HA
        '
        Me.Chk_Usar_HA.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Usar_HA.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Usar_HA.ForeColor = System.Drawing.Color.Black
        Me.Chk_Usar_HA.Location = New System.Drawing.Point(9, 240)
        Me.Chk_Usar_HA.Name = "Chk_Usar_HA"
        Me.Chk_Usar_HA.Size = New System.Drawing.Size(379, 23)
        Me.Chk_Usar_HA.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Usar_HA.TabIndex = 149
        Me.Chk_Usar_HA.Text = "Usar horario de atención"
        '
        'Txt_Nombre_Contacto
        '
        Me.Txt_Nombre_Contacto.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Nombre_Contacto.Border.Class = "TextBoxBorder"
        Me.Txt_Nombre_Contacto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Nombre_Contacto.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Nombre_Contacto.ForeColor = System.Drawing.Color.Black
        Me.Txt_Nombre_Contacto.Location = New System.Drawing.Point(92, 59)
        Me.Txt_Nombre_Contacto.MaxLength = 50
        Me.Txt_Nombre_Contacto.Name = "Txt_Nombre_Contacto"
        Me.Txt_Nombre_Contacto.PreventEnterBeep = True
        Me.Txt_Nombre_Contacto.Size = New System.Drawing.Size(393, 22)
        Me.Txt_Nombre_Contacto.TabIndex = 6
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(9, 61)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(85, 20)
        Me.LabelX2.TabIndex = 148
        Me.LabelX2.Text = "Contacto"
        '
        'Chk_Por_Defecto
        '
        Me.Chk_Por_Defecto.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Por_Defecto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Por_Defecto.ForeColor = System.Drawing.Color.Black
        Me.Chk_Por_Defecto.Location = New System.Drawing.Point(9, 211)
        Me.Chk_Por_Defecto.Name = "Chk_Por_Defecto"
        Me.Chk_Por_Defecto.Size = New System.Drawing.Size(360, 23)
        Me.Chk_Por_Defecto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Por_Defecto.TabIndex = 94
        Me.Chk_Por_Defecto.Text = "Dirección de despacho por defecto"
        '
        'Txt_Comuna
        '
        Me.Txt_Comuna.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Comuna.Border.Class = "TextBoxBorder"
        Me.Txt_Comuna.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Comuna.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Comuna.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Comuna.ForeColor = System.Drawing.Color.Black
        Me.Txt_Comuna.Location = New System.Drawing.Point(92, 5)
        Me.Txt_Comuna.MaxLength = 200
        Me.Txt_Comuna.Name = "Txt_Comuna"
        Me.Txt_Comuna.PreventEnterBeep = True
        Me.Txt_Comuna.ReadOnly = True
        Me.Txt_Comuna.Size = New System.Drawing.Size(393, 22)
        Me.Txt_Comuna.TabIndex = 146
        '
        'LabelX24
        '
        Me.LabelX24.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX24.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX24.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX24.ForeColor = System.Drawing.Color.Black
        Me.LabelX24.Location = New System.Drawing.Point(9, 8)
        Me.LabelX24.Name = "LabelX24"
        Me.LabelX24.Size = New System.Drawing.Size(60, 19)
        Me.LabelX24.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX24.TabIndex = 145
        Me.LabelX24.Text = "Comuna"
        '
        'Btn_Direccion_Servicio
        '
        Me.Btn_Direccion_Servicio.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Direccion_Servicio.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Direccion_Servicio.Image = CType(resources.GetObject("Btn_Direccion_Servicio.Image"), System.Drawing.Image)
        Me.Btn_Direccion_Servicio.ImageAlt = CType(resources.GetObject("Btn_Direccion_Servicio.ImageAlt"), System.Drawing.Image)
        Me.Btn_Direccion_Servicio.Location = New System.Drawing.Point(491, 30)
        Me.Btn_Direccion_Servicio.Name = "Btn_Direccion_Servicio"
        Me.Btn_Direccion_Servicio.Size = New System.Drawing.Size(96, 22)
        Me.Btn_Direccion_Servicio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Direccion_Servicio.TabIndex = 142
        Me.Btn_Direccion_Servicio.TabStop = False
        Me.Btn_Direccion_Servicio.Text = "Ver mapa"
        '
        'Btn_Buscar_Comuna
        '
        Me.Btn_Buscar_Comuna.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Buscar_Comuna.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Buscar_Comuna.Location = New System.Drawing.Point(491, 5)
        Me.Btn_Buscar_Comuna.Name = "Btn_Buscar_Comuna"
        Me.Btn_Buscar_Comuna.Size = New System.Drawing.Size(96, 22)
        Me.Btn_Buscar_Comuna.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Buscar_Comuna.TabIndex = 4
        Me.Btn_Buscar_Comuna.Text = "Buscar comunas"
        '
        'Btn_Buscar_Transportista
        '
        Me.Btn_Buscar_Transportista.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Buscar_Transportista.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Buscar_Transportista.Image = CType(resources.GetObject("Btn_Buscar_Transportista.Image"), System.Drawing.Image)
        Me.Btn_Buscar_Transportista.ImageAlt = CType(resources.GetObject("Btn_Buscar_Transportista.ImageAlt"), System.Drawing.Image)
        Me.Btn_Buscar_Transportista.Location = New System.Drawing.Point(491, 177)
        Me.Btn_Buscar_Transportista.Name = "Btn_Buscar_Transportista"
        Me.Btn_Buscar_Transportista.Size = New System.Drawing.Size(96, 22)
        Me.Btn_Buscar_Transportista.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Buscar_Transportista.TabIndex = 10
        Me.Btn_Buscar_Transportista.Text = "buscar..."
        Me.Btn_Buscar_Transportista.Tooltip = "Buscar transportista"
        '
        'Txt_Transportista
        '
        Me.Txt_Transportista.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Transportista.Border.Class = "TextBoxBorder"
        Me.Txt_Transportista.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Transportista.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Transportista.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Transportista.ForeColor = System.Drawing.Color.Black
        Me.Txt_Transportista.Location = New System.Drawing.Point(92, 177)
        Me.Txt_Transportista.MaxLength = 20
        Me.Txt_Transportista.Name = "Txt_Transportista"
        Me.Txt_Transportista.PreventEnterBeep = True
        Me.Txt_Transportista.ReadOnly = True
        Me.Txt_Transportista.Size = New System.Drawing.Size(393, 22)
        Me.Txt_Transportista.TabIndex = 141
        Me.Txt_Transportista.TabStop = False
        '
        'Btn_Buscar_Tipo_Venta
        '
        Me.Btn_Buscar_Tipo_Venta.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Buscar_Tipo_Venta.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Buscar_Tipo_Venta.Image = CType(resources.GetObject("Btn_Buscar_Tipo_Venta.Image"), System.Drawing.Image)
        Me.Btn_Buscar_Tipo_Venta.ImageAlt = CType(resources.GetObject("Btn_Buscar_Tipo_Venta.ImageAlt"), System.Drawing.Image)
        Me.Btn_Buscar_Tipo_Venta.Location = New System.Drawing.Point(491, 152)
        Me.Btn_Buscar_Tipo_Venta.Name = "Btn_Buscar_Tipo_Venta"
        Me.Btn_Buscar_Tipo_Venta.Size = New System.Drawing.Size(96, 21)
        Me.Btn_Buscar_Tipo_Venta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Buscar_Tipo_Venta.TabIndex = 9
        Me.Btn_Buscar_Tipo_Venta.Text = "buscar..."
        Me.Btn_Buscar_Tipo_Venta.Tooltip = "Buscar tipo de venta"
        '
        'Txt_Tipo_Venta
        '
        Me.Txt_Tipo_Venta.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Tipo_Venta.Border.Class = "TextBoxBorder"
        Me.Txt_Tipo_Venta.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Tipo_Venta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Tipo_Venta.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Tipo_Venta.ForeColor = System.Drawing.Color.Black
        Me.Txt_Tipo_Venta.Location = New System.Drawing.Point(92, 151)
        Me.Txt_Tipo_Venta.MaxLength = 20
        Me.Txt_Tipo_Venta.Name = "Txt_Tipo_Venta"
        Me.Txt_Tipo_Venta.PreventEnterBeep = True
        Me.Txt_Tipo_Venta.ReadOnly = True
        Me.Txt_Tipo_Venta.Size = New System.Drawing.Size(393, 22)
        Me.Txt_Tipo_Venta.TabIndex = 139
        Me.Txt_Tipo_Venta.TabStop = False
        '
        'Txt_Email
        '
        Me.Txt_Email.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Email.Border.Class = "TextBoxBorder"
        Me.Txt_Email.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Email.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Email.ForeColor = System.Drawing.Color.Black
        Me.Txt_Email.Location = New System.Drawing.Point(92, 115)
        Me.Txt_Email.MaxLength = 100
        Me.Txt_Email.Name = "Txt_Email"
        Me.Txt_Email.PreventEnterBeep = True
        Me.Txt_Email.Size = New System.Drawing.Size(393, 22)
        Me.Txt_Email.TabIndex = 8
        '
        'Txt_Direccion
        '
        Me.Txt_Direccion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Direccion.Border.Class = "TextBoxBorder"
        Me.Txt_Direccion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Direccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Direccion.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Direccion.ForeColor = System.Drawing.Color.Black
        Me.Txt_Direccion.Location = New System.Drawing.Point(92, 30)
        Me.Txt_Direccion.MaxLength = 100
        Me.Txt_Direccion.Name = "Txt_Direccion"
        Me.Txt_Direccion.PreventEnterBeep = True
        Me.Txt_Direccion.Size = New System.Drawing.Size(393, 22)
        Me.Txt_Direccion.TabIndex = 5
        '
        'Txt_Telefono
        '
        Me.Txt_Telefono.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Telefono.Border.Class = "TextBoxBorder"
        Me.Txt_Telefono.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Telefono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Telefono.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Telefono.ForeColor = System.Drawing.Color.Black
        Me.Txt_Telefono.Location = New System.Drawing.Point(92, 87)
        Me.Txt_Telefono.MaxLength = 30
        Me.Txt_Telefono.Name = "Txt_Telefono"
        Me.Txt_Telefono.PreventEnterBeep = True
        Me.Txt_Telefono.Size = New System.Drawing.Size(190, 22)
        Me.Txt_Telefono.TabIndex = 7
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(9, 117)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(85, 20)
        Me.LabelX3.TabIndex = 94
        Me.LabelX3.Text = "Email"
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(9, 176)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(77, 20)
        Me.LabelX6.TabIndex = 135
        Me.LabelX6.Text = "Transportista"
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(9, 150)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(77, 20)
        Me.LabelX4.TabIndex = 137
        Me.LabelX4.Text = "Tipo venta"
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(9, 33)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(85, 19)
        Me.LabelX5.TabIndex = 30
        Me.LabelX5.Text = "Dirección"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(9, 90)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(85, 19)
        Me.LabelX1.TabIndex = 91
        Me.LabelX1.Text = "Teléfono"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Btn_Modificar_Horario)
        Me.GroupPanel1.Controls.Add(Me.Layauot_HA)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 299)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(596, 86)
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
        Me.GroupPanel1.TabIndex = 93
        Me.GroupPanel1.Text = "Horarios de atención"
        '
        'Btn_Modificar_Horario
        '
        Me.Btn_Modificar_Horario.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Modificar_Horario.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Modificar_Horario.Image = CType(resources.GetObject("Btn_Modificar_Horario.Image"), System.Drawing.Image)
        Me.Btn_Modificar_Horario.ImageAlt = CType(resources.GetObject("Btn_Modificar_Horario.ImageAlt"), System.Drawing.Image)
        Me.Btn_Modificar_Horario.Location = New System.Drawing.Point(314, 3)
        Me.Btn_Modificar_Horario.Name = "Btn_Modificar_Horario"
        Me.Btn_Modificar_Horario.Size = New System.Drawing.Size(74, 26)
        Me.Btn_Modificar_Horario.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Modificar_Horario.TabIndex = 10
        Me.Btn_Modificar_Horario.Text = "Editar"
        Me.Btn_Modificar_Horario.Tooltip = "Modificar horario de atención"
        '
        'Layauot_HA
        '
        Me.Layauot_HA.BackColor = System.Drawing.Color.Transparent
        Me.Layauot_HA.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.Layauot_HA.ColumnCount = 4
        Me.Layauot_HA.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.80268!))
        Me.Layauot_HA.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.3991!))
        Me.Layauot_HA.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.05824!))
        Me.Layauot_HA.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.73997!))
        Me.Layauot_HA.Controls.Add(Me.Dtp_HA_Tarde_Desde, 1, 1)
        Me.Layauot_HA.Controls.Add(Me.Dtp_HA_Tarde_Hasta, 3, 1)
        Me.Layauot_HA.Controls.Add(Me.Lbl_Hora_Termino, 2, 1)
        Me.Layauot_HA.Controls.Add(Me.LabelX8, 0, 1)
        Me.Layauot_HA.Controls.Add(Me.LabelX9, 2, 0)
        Me.Layauot_HA.Controls.Add(Me.LabelX10, 0, 0)
        Me.Layauot_HA.Controls.Add(Me.Dtp_HA_Manana_Hasta, 3, 0)
        Me.Layauot_HA.Controls.Add(Me.Dtp_HA_Manana_Desde, 1, 0)
        Me.Layauot_HA.Enabled = False
        Me.Layauot_HA.ForeColor = System.Drawing.Color.Black
        Me.Layauot_HA.Location = New System.Drawing.Point(3, 3)
        Me.Layauot_HA.Name = "Layauot_HA"
        Me.Layauot_HA.RowCount = 2
        Me.Layauot_HA.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Layauot_HA.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Layauot_HA.Size = New System.Drawing.Size(305, 57)
        Me.Layauot_HA.TabIndex = 1
        '
        'Dtp_HA_Tarde_Desde
        '
        '
        '
        '
        Me.Dtp_HA_Tarde_Desde.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_HA_Tarde_Desde.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_HA_Tarde_Desde.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_HA_Tarde_Desde.ButtonDropDown.Visible = True
        Me.Dtp_HA_Tarde_Desde.ForeColor = System.Drawing.Color.Black
        Me.Dtp_HA_Tarde_Desde.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime
        Me.Dtp_HA_Tarde_Desde.IsPopupCalendarOpen = False
        Me.Dtp_HA_Tarde_Desde.Location = New System.Drawing.Point(94, 32)
        '
        '
        '
        Me.Dtp_HA_Tarde_Desde.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_HA_Tarde_Desde.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_HA_Tarde_Desde.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_HA_Tarde_Desde.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_HA_Tarde_Desde.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_HA_Tarde_Desde.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_HA_Tarde_Desde.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_HA_Tarde_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_HA_Tarde_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_HA_Tarde_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_HA_Tarde_Desde.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_HA_Tarde_Desde.MonthCalendar.DisplayMonth = New Date(2018, 8, 1, 0, 0, 0, 0)
        Me.Dtp_HA_Tarde_Desde.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_HA_Tarde_Desde.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_HA_Tarde_Desde.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_HA_Tarde_Desde.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_HA_Tarde_Desde.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_HA_Tarde_Desde.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_HA_Tarde_Desde.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_HA_Tarde_Desde.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_HA_Tarde_Desde.MonthCalendar.Visible = False
        Me.Dtp_HA_Tarde_Desde.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_HA_Tarde_Desde.Name = "Dtp_HA_Tarde_Desde"
        Me.Dtp_HA_Tarde_Desde.Size = New System.Drawing.Size(60, 22)
        Me.Dtp_HA_Tarde_Desde.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_HA_Tarde_Desde.TabIndex = 5
        Me.Dtp_HA_Tarde_Desde.Value = New Date(2018, 8, 7, 11, 47, 57, 0)
        '
        'Dtp_HA_Tarde_Hasta
        '
        '
        '
        '
        Me.Dtp_HA_Tarde_Hasta.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_HA_Tarde_Hasta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_HA_Tarde_Hasta.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_HA_Tarde_Hasta.ButtonDropDown.Visible = True
        Me.Dtp_HA_Tarde_Hasta.ForeColor = System.Drawing.Color.Black
        Me.Dtp_HA_Tarde_Hasta.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime
        Me.Dtp_HA_Tarde_Hasta.IsPopupCalendarOpen = False
        Me.Dtp_HA_Tarde_Hasta.Location = New System.Drawing.Point(238, 32)
        '
        '
        '
        Me.Dtp_HA_Tarde_Hasta.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_HA_Tarde_Hasta.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_HA_Tarde_Hasta.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_HA_Tarde_Hasta.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_HA_Tarde_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_HA_Tarde_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_HA_Tarde_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_HA_Tarde_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_HA_Tarde_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_HA_Tarde_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_HA_Tarde_Hasta.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_HA_Tarde_Hasta.MonthCalendar.DisplayMonth = New Date(2018, 8, 1, 0, 0, 0, 0)
        Me.Dtp_HA_Tarde_Hasta.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_HA_Tarde_Hasta.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_HA_Tarde_Hasta.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_HA_Tarde_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_HA_Tarde_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_HA_Tarde_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_HA_Tarde_Hasta.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_HA_Tarde_Hasta.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_HA_Tarde_Hasta.MonthCalendar.Visible = False
        Me.Dtp_HA_Tarde_Hasta.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_HA_Tarde_Hasta.Name = "Dtp_HA_Tarde_Hasta"
        Me.Dtp_HA_Tarde_Hasta.Size = New System.Drawing.Size(60, 22)
        Me.Dtp_HA_Tarde_Hasta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_HA_Tarde_Hasta.TabIndex = 5
        Me.Dtp_HA_Tarde_Hasta.Value = New Date(2018, 8, 7, 11, 47, 57, 0)
        '
        'Lbl_Hora_Termino
        '
        '
        '
        '
        Me.Lbl_Hora_Termino.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Hora_Termino.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Hora_Termino.Location = New System.Drawing.Point(165, 32)
        Me.Lbl_Hora_Termino.Name = "Lbl_Hora_Termino"
        Me.Lbl_Hora_Termino.Size = New System.Drawing.Size(66, 18)
        Me.Lbl_Hora_Termino.TabIndex = 4
        Me.Lbl_Hora_Termino.Text = "hasta"
        '
        'LabelX8
        '
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.ForeColor = System.Drawing.Color.Black
        Me.LabelX8.Location = New System.Drawing.Point(4, 32)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(72, 18)
        Me.LabelX8.TabIndex = 3
        Me.LabelX8.Text = "Tarde desde"
        '
        'LabelX9
        '
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.ForeColor = System.Drawing.Color.Black
        Me.LabelX9.Location = New System.Drawing.Point(165, 4)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(66, 18)
        Me.LabelX9.TabIndex = 3
        Me.LabelX9.Text = "hasta"
        '
        'LabelX10
        '
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.ForeColor = System.Drawing.Color.Black
        Me.LabelX10.Location = New System.Drawing.Point(4, 4)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(72, 18)
        Me.LabelX10.TabIndex = 2
        Me.LabelX10.Text = "Mañana desde"
        '
        'Dtp_HA_Manana_Hasta
        '
        '
        '
        '
        Me.Dtp_HA_Manana_Hasta.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_HA_Manana_Hasta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_HA_Manana_Hasta.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_HA_Manana_Hasta.ButtonDropDown.Visible = True
        Me.Dtp_HA_Manana_Hasta.ForeColor = System.Drawing.Color.Black
        Me.Dtp_HA_Manana_Hasta.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime
        Me.Dtp_HA_Manana_Hasta.IsPopupCalendarOpen = False
        Me.Dtp_HA_Manana_Hasta.Location = New System.Drawing.Point(238, 4)
        '
        '
        '
        Me.Dtp_HA_Manana_Hasta.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_HA_Manana_Hasta.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_HA_Manana_Hasta.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_HA_Manana_Hasta.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_HA_Manana_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_HA_Manana_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_HA_Manana_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_HA_Manana_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_HA_Manana_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_HA_Manana_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_HA_Manana_Hasta.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_HA_Manana_Hasta.MonthCalendar.DisplayMonth = New Date(2018, 8, 1, 0, 0, 0, 0)
        Me.Dtp_HA_Manana_Hasta.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_HA_Manana_Hasta.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_HA_Manana_Hasta.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_HA_Manana_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_HA_Manana_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_HA_Manana_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_HA_Manana_Hasta.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_HA_Manana_Hasta.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_HA_Manana_Hasta.MonthCalendar.Visible = False
        Me.Dtp_HA_Manana_Hasta.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_HA_Manana_Hasta.Name = "Dtp_HA_Manana_Hasta"
        Me.Dtp_HA_Manana_Hasta.Size = New System.Drawing.Size(60, 22)
        Me.Dtp_HA_Manana_Hasta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_HA_Manana_Hasta.TabIndex = 4
        Me.Dtp_HA_Manana_Hasta.Value = New Date(2018, 8, 7, 11, 47, 57, 0)
        '
        'Dtp_HA_Manana_Desde
        '
        '
        '
        '
        Me.Dtp_HA_Manana_Desde.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_HA_Manana_Desde.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_HA_Manana_Desde.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_HA_Manana_Desde.ButtonDropDown.Visible = True
        Me.Dtp_HA_Manana_Desde.ForeColor = System.Drawing.Color.Black
        Me.Dtp_HA_Manana_Desde.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime
        Me.Dtp_HA_Manana_Desde.IsPopupCalendarOpen = False
        Me.Dtp_HA_Manana_Desde.Location = New System.Drawing.Point(94, 4)
        '
        '
        '
        Me.Dtp_HA_Manana_Desde.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_HA_Manana_Desde.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_HA_Manana_Desde.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_HA_Manana_Desde.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_HA_Manana_Desde.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_HA_Manana_Desde.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_HA_Manana_Desde.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_HA_Manana_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_HA_Manana_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_HA_Manana_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_HA_Manana_Desde.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_HA_Manana_Desde.MonthCalendar.DisplayMonth = New Date(2018, 8, 1, 0, 0, 0, 0)
        Me.Dtp_HA_Manana_Desde.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_HA_Manana_Desde.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_HA_Manana_Desde.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_HA_Manana_Desde.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_HA_Manana_Desde.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_HA_Manana_Desde.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_HA_Manana_Desde.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_HA_Manana_Desde.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_HA_Manana_Desde.MonthCalendar.Visible = False
        Me.Dtp_HA_Manana_Desde.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_HA_Manana_Desde.Name = "Dtp_HA_Manana_Desde"
        Me.Dtp_HA_Manana_Desde.Size = New System.Drawing.Size(60, 22)
        Me.Dtp_HA_Manana_Desde.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_HA_Manana_Desde.TabIndex = 5
        Me.Dtp_HA_Manana_Desde.Value = New Date(2018, 8, 7, 11, 47, 57, 0)
        '
        'Frm_Direc_Cli
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(619, 436)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.GroupPanel2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Direc_Cli"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        Me.GroupPanel1.ResumeLayout(False)
        Me.Layauot_HA.ResumeLayout(False)
        CType(Me.Dtp_HA_Tarde_Desde, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_HA_Tarde_Hasta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_HA_Manana_Hasta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_HA_Manana_Desde, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Email As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Direccion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Telefono As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Btn_Buscar_Transportista As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Txt_Transportista As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Btn_Buscar_Tipo_Venta As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Txt_Tipo_Venta As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Chk_Por_Defecto As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Btn_Buscar_Comuna As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Direccion_Servicio As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Txt_Comuna As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX24 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Nombre_Contacto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Chk_Usar_HA As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Layauot_HA As TableLayoutPanel
    Public WithEvents Dtp_HA_Tarde_Hasta As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Public WithEvents Lbl_Hora_Termino As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Public WithEvents Dtp_HA_Manana_Hasta As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Btn_Modificar_Horario As DevComponents.DotNetBar.ButtonX
    Public WithEvents Dtp_HA_Tarde_Desde As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Public WithEvents Dtp_HA_Manana_Desde As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Public WithEvents Btn_Traer_Datos_Transportista As DevComponents.DotNetBar.ButtonX
End Class
