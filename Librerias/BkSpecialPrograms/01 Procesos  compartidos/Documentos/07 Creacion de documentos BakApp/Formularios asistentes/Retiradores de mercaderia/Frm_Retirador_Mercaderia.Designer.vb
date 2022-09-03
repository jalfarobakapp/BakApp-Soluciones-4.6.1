<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Retirador_Mercaderia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Retirador_Mercaderia))
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Lbl_TipoEnvio = New DevComponents.DotNetBar.LabelX()
        Me.Cmb_Tipo_Envio = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Chk_Mostrar = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.Input_Cant_Minima = New DevComponents.Editors.IntegerInput()
        Me.Line1 = New DevComponents.DotNetBar.Controls.Line()
        Me.Txt_Comuna = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX24 = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Buscar_Comuna = New DevComponents.DotNetBar.ButtonX()
        Me.Lbl_Nom_EntResponsable = New DevComponents.DotNetBar.LabelX()
        Me.Chk_Retcli = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Txt_Licencondu = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Buscar_Koenresp = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_Koenresp = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Koreti = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Noreti = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Direti = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX14 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Rureti = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar_e_Imprimir = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Eliminar = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Input_Cant_Minima, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Lbl_TipoEnvio)
        Me.GroupPanel1.Controls.Add(Me.Cmb_Tipo_Envio)
        Me.GroupPanel1.Controls.Add(Me.Chk_Mostrar)
        Me.GroupPanel1.Controls.Add(Me.LabelX5)
        Me.GroupPanel1.Controls.Add(Me.Input_Cant_Minima)
        Me.GroupPanel1.Controls.Add(Me.Line1)
        Me.GroupPanel1.Controls.Add(Me.Txt_Comuna)
        Me.GroupPanel1.Controls.Add(Me.LabelX24)
        Me.GroupPanel1.Controls.Add(Me.Btn_Buscar_Comuna)
        Me.GroupPanel1.Controls.Add(Me.Lbl_Nom_EntResponsable)
        Me.GroupPanel1.Controls.Add(Me.Chk_Retcli)
        Me.GroupPanel1.Controls.Add(Me.Txt_Licencondu)
        Me.GroupPanel1.Controls.Add(Me.LabelX3)
        Me.GroupPanel1.Controls.Add(Me.Btn_Buscar_Koenresp)
        Me.GroupPanel1.Controls.Add(Me.Txt_Koenresp)
        Me.GroupPanel1.Controls.Add(Me.LabelX1)
        Me.GroupPanel1.Controls.Add(Me.Txt_Koreti)
        Me.GroupPanel1.Controls.Add(Me.LabelX2)
        Me.GroupPanel1.Controls.Add(Me.Txt_Noreti)
        Me.GroupPanel1.Controls.Add(Me.Txt_Direti)
        Me.GroupPanel1.Controls.Add(Me.LabelX14)
        Me.GroupPanel1.Controls.Add(Me.Txt_Rureti)
        Me.GroupPanel1.Controls.Add(Me.LabelX6)
        Me.GroupPanel1.Controls.Add(Me.LabelX4)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(524, 358)
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
        Me.GroupPanel1.TabIndex = 62
        Me.GroupPanel1.Text = "Retirador de mercadería / transportistas"
        '
        'Lbl_TipoEnvio
        '
        Me.Lbl_TipoEnvio.AutoSize = True
        Me.Lbl_TipoEnvio.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_TipoEnvio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_TipoEnvio.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_TipoEnvio.ForeColor = System.Drawing.Color.Black
        Me.Lbl_TipoEnvio.Location = New System.Drawing.Point(3, 309)
        Me.Lbl_TipoEnvio.Name = "Lbl_TipoEnvio"
        Me.Lbl_TipoEnvio.Size = New System.Drawing.Size(62, 20)
        Me.Lbl_TipoEnvio.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Lbl_TipoEnvio.TabIndex = 154
        Me.Lbl_TipoEnvio.Text = "Tipo Envío"
        '
        'Cmb_Tipo_Envio
        '
        Me.Cmb_Tipo_Envio.DisplayMember = "Text"
        Me.Cmb_Tipo_Envio.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Tipo_Envio.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Tipo_Envio.FormattingEnabled = True
        Me.Cmb_Tipo_Envio.ItemHeight = 16
        Me.Cmb_Tipo_Envio.Location = New System.Drawing.Point(74, 307)
        Me.Cmb_Tipo_Envio.Name = "Cmb_Tipo_Envio"
        Me.Cmb_Tipo_Envio.Size = New System.Drawing.Size(250, 22)
        Me.Cmb_Tipo_Envio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Tipo_Envio.TabIndex = 155
        '
        'Chk_Mostrar
        '
        Me.Chk_Mostrar.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Mostrar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Mostrar.ForeColor = System.Drawing.Color.Black
        Me.Chk_Mostrar.Location = New System.Drawing.Point(3, 249)
        Me.Chk_Mostrar.Name = "Chk_Mostrar"
        Me.Chk_Mostrar.Size = New System.Drawing.Size(360, 23)
        Me.Chk_Mostrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Mostrar.TabIndex = 153
        Me.Chk_Mostrar.Text = "Mostrar en sistema de despachos"
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(3, 278)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(204, 23)
        Me.LabelX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX5.TabIndex = 151
        Me.LabelX5.Text = "Cantidad mínima de despacho Kg"
        '
        'Input_Cant_Minima
        '
        Me.Input_Cant_Minima.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_Cant_Minima.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_Cant_Minima.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_Cant_Minima.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.Input_Cant_Minima.ForeColor = System.Drawing.Color.Black
        Me.Input_Cant_Minima.Location = New System.Drawing.Point(232, 279)
        Me.Input_Cant_Minima.Name = "Input_Cant_Minima"
        Me.Input_Cant_Minima.ShowUpDown = True
        Me.Input_Cant_Minima.Size = New System.Drawing.Size(92, 22)
        Me.Input_Cant_Minima.TabIndex = 150
        '
        'Line1
        '
        Me.Line1.BackColor = System.Drawing.Color.Transparent
        Me.Line1.ForeColor = System.Drawing.Color.Black
        Me.Line1.Location = New System.Drawing.Point(3, 230)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(510, 23)
        Me.Line1.TabIndex = 152
        Me.Line1.Text = "Line1"
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
        Me.Txt_Comuna.Location = New System.Drawing.Point(67, 92)
        Me.Txt_Comuna.MaxLength = 200
        Me.Txt_Comuna.Name = "Txt_Comuna"
        Me.Txt_Comuna.PreventEnterBeep = True
        Me.Txt_Comuna.ReadOnly = True
        Me.Txt_Comuna.Size = New System.Drawing.Size(344, 22)
        Me.Txt_Comuna.TabIndex = 149
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
        Me.LabelX24.Location = New System.Drawing.Point(3, 95)
        Me.LabelX24.Name = "LabelX24"
        Me.LabelX24.Size = New System.Drawing.Size(60, 19)
        Me.LabelX24.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX24.TabIndex = 148
        Me.LabelX24.Text = "Comuna"
        '
        'Btn_Buscar_Comuna
        '
        Me.Btn_Buscar_Comuna.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Buscar_Comuna.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Buscar_Comuna.Location = New System.Drawing.Point(417, 92)
        Me.Btn_Buscar_Comuna.Name = "Btn_Buscar_Comuna"
        Me.Btn_Buscar_Comuna.Size = New System.Drawing.Size(96, 22)
        Me.Btn_Buscar_Comuna.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Buscar_Comuna.TabIndex = 4
        Me.Btn_Buscar_Comuna.Text = "Buscar comunas"
        '
        'Lbl_Nom_EntResponsable
        '
        Me.Lbl_Nom_EntResponsable.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Nom_EntResponsable.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Nom_EntResponsable.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Nom_EntResponsable.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Nom_EntResponsable.Location = New System.Drawing.Point(186, 140)
        Me.Lbl_Nom_EntResponsable.Name = "Lbl_Nom_EntResponsable"
        Me.Lbl_Nom_EntResponsable.Size = New System.Drawing.Size(294, 23)
        Me.Lbl_Nom_EntResponsable.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Lbl_Nom_EntResponsable.TabIndex = 78
        Me.Lbl_Nom_EntResponsable.Text = "."
        '
        'Chk_Retcli
        '
        Me.Chk_Retcli.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Retcli.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Retcli.ForeColor = System.Drawing.Color.Black
        Me.Chk_Retcli.Location = New System.Drawing.Point(3, 201)
        Me.Chk_Retcli.Name = "Chk_Retcli"
        Me.Chk_Retcli.Size = New System.Drawing.Size(331, 23)
        Me.Chk_Retcli.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Retcli.TabIndex = 7
        Me.Chk_Retcli.Text = "Retirador actua por cuenta del cliente"
        '
        'Txt_Licencondu
        '
        Me.Txt_Licencondu.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Licencondu.Border.Class = "TextBoxBorder"
        Me.Txt_Licencondu.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Licencondu.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Licencondu.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Licencondu.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Licencondu.ForeColor = System.Drawing.Color.Black
        Me.Txt_Licencondu.Location = New System.Drawing.Point(109, 173)
        Me.Txt_Licencondu.MaxLength = 20
        Me.Txt_Licencondu.Name = "Txt_Licencondu"
        Me.Txt_Licencondu.Size = New System.Drawing.Size(140, 22)
        Me.Txt_Licencondu.TabIndex = 6
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(3, 172)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(193, 23)
        Me.LabelX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX3.TabIndex = 76
        Me.LabelX3.Text = "Licencia conducir"
        '
        'Btn_Buscar_Koenresp
        '
        Me.Btn_Buscar_Koenresp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Buscar_Koenresp.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Buscar_Koenresp.Location = New System.Drawing.Point(135, 140)
        Me.Btn_Buscar_Koenresp.Name = "Btn_Buscar_Koenresp"
        Me.Btn_Buscar_Koenresp.Size = New System.Drawing.Size(45, 22)
        Me.Btn_Buscar_Koenresp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Buscar_Koenresp.TabIndex = 5
        Me.Btn_Buscar_Koenresp.Text = "Buscar"
        '
        'Txt_Koenresp
        '
        Me.Txt_Koenresp.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Koenresp.Border.Class = "TextBoxBorder"
        Me.Txt_Koenresp.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Koenresp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Koenresp.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Koenresp.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Koenresp.ForeColor = System.Drawing.Color.Black
        Me.Txt_Koenresp.Location = New System.Drawing.Point(3, 140)
        Me.Txt_Koenresp.MaxLength = 13
        Me.Txt_Koenresp.Name = "Txt_Koenresp"
        Me.Txt_Koenresp.ReadOnly = True
        Me.Txt_Koenresp.Size = New System.Drawing.Size(126, 22)
        Me.Txt_Koenresp.TabIndex = 72
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 120)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(152, 23)
        Me.LabelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX1.TabIndex = 73
        Me.LabelX1.Text = "Entidad responsable "
        '
        'Txt_Koreti
        '
        Me.Txt_Koreti.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Koreti.Border.Class = "TextBoxBorder"
        Me.Txt_Koreti.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Koreti.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Koreti.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Koreti.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Koreti.ForeColor = System.Drawing.Color.Black
        Me.Txt_Koreti.Location = New System.Drawing.Point(67, 7)
        Me.Txt_Koreti.MaxLength = 13
        Me.Txt_Koreti.Name = "Txt_Koreti"
        Me.Txt_Koreti.Size = New System.Drawing.Size(140, 22)
        Me.Txt_Koreti.TabIndex = 0
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 10)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(89, 20)
        Me.LabelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX2.TabIndex = 67
        Me.LabelX2.Text = "Código"
        '
        'Txt_Noreti
        '
        Me.Txt_Noreti.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Noreti.Border.Class = "TextBoxBorder"
        Me.Txt_Noreti.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Noreti.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Noreti.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Noreti.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Noreti.ForeColor = System.Drawing.Color.Black
        Me.Txt_Noreti.Location = New System.Drawing.Point(67, 36)
        Me.Txt_Noreti.MaxLength = 50
        Me.Txt_Noreti.Name = "Txt_Noreti"
        Me.Txt_Noreti.Size = New System.Drawing.Size(448, 22)
        Me.Txt_Noreti.TabIndex = 2
        '
        'Txt_Direti
        '
        Me.Txt_Direti.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Direti.Border.Class = "TextBoxBorder"
        Me.Txt_Direti.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Direti.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Direti.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Direti.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Direti.ForeColor = System.Drawing.Color.Black
        Me.Txt_Direti.Location = New System.Drawing.Point(67, 64)
        Me.Txt_Direti.MaxLength = 50
        Me.Txt_Direti.Name = "Txt_Direti"
        Me.Txt_Direti.Size = New System.Drawing.Size(448, 22)
        Me.Txt_Direti.TabIndex = 3
        '
        'LabelX14
        '
        Me.LabelX14.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX14.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX14.ForeColor = System.Drawing.Color.Black
        Me.LabelX14.Location = New System.Drawing.Point(3, 64)
        Me.LabelX14.Name = "LabelX14"
        Me.LabelX14.Size = New System.Drawing.Size(60, 22)
        Me.LabelX14.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX14.TabIndex = 71
        Me.LabelX14.Text = "Dirección"
        '
        'Txt_Rureti
        '
        Me.Txt_Rureti.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Rureti.Border.Class = "TextBoxBorder"
        Me.Txt_Rureti.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Rureti.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Rureti.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Rureti.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Rureti.ForeColor = System.Drawing.Color.Black
        Me.Txt_Rureti.Location = New System.Drawing.Point(289, 8)
        Me.Txt_Rureti.MaxLength = 13
        Me.Txt_Rureti.Name = "Txt_Rureti"
        Me.Txt_Rureti.Size = New System.Drawing.Size(140, 22)
        Me.Txt_Rureti.TabIndex = 1
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(3, 37)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(60, 21)
        Me.LabelX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX6.TabIndex = 70
        Me.LabelX6.Text = "Nombre"
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(245, 6)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(89, 23)
        Me.LabelX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX4.TabIndex = 69
        Me.LabelX4.Text = "Rut"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar_e_Imprimir, Me.Btn_Eliminar})
        Me.Bar2.Location = New System.Drawing.Point(0, 389)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(546, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 63
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Grabar_e_Imprimir
        '
        Me.Btn_Grabar_e_Imprimir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar_e_Imprimir.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar_e_Imprimir.Image = CType(resources.GetObject("Btn_Grabar_e_Imprimir.Image"), System.Drawing.Image)
        Me.Btn_Grabar_e_Imprimir.ImageAlt = CType(resources.GetObject("Btn_Grabar_e_Imprimir.ImageAlt"), System.Drawing.Image)
        Me.Btn_Grabar_e_Imprimir.Name = "Btn_Grabar_e_Imprimir"
        Me.Btn_Grabar_e_Imprimir.Tooltip = "Grabar"
        '
        'Btn_Eliminar
        '
        Me.Btn_Eliminar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Eliminar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Btn_Eliminar.Image = CType(resources.GetObject("Btn_Eliminar.Image"), System.Drawing.Image)
        Me.Btn_Eliminar.ImageAlt = CType(resources.GetObject("Btn_Eliminar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Eliminar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Eliminar.Name = "Btn_Eliminar"
        Me.Btn_Eliminar.Tooltip = "Eliminar"
        '
        'Frm_Retirador_Mercaderia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(546, 430)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.GroupPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Retirador_Mercaderia"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantención de retiradores"
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        CType(Me.Input_Cant_Minima, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Chk_Retcli As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Txt_Licencondu As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Buscar_Koenresp As DevComponents.DotNetBar.ButtonX
    Public WithEvents Txt_Koenresp As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Koreti As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Noreti As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Direti As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX14 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Rureti As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Public WithEvents Btn_Grabar_e_Imprimir As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Eliminar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Lbl_Nom_EntResponsable As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Comuna As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX24 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Buscar_Comuna As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Input_Cant_Minima As DevComponents.Editors.IntegerInput
    Friend WithEvents Line1 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents Chk_Mostrar As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Lbl_TipoEnvio As DevComponents.DotNetBar.LabelX
    Friend WithEvents Cmb_Tipo_Envio As DevComponents.DotNetBar.Controls.ComboBoxEx
End Class
