<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Crear_Entidad_Mt_Crear_Contactos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Crear_Entidad_Mt_Crear_Contactos))
        Me.CmbCargo = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.CmbActividad = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.TxtEmail = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.TxtFax = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.TxtTelefono = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.TxtRazonSocial = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.TxtRut = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.BtnxGrabar = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnEliminarContacto = New DevComponents.DotNetBar.ButtonItem()
        Me.Highlighter1 = New DevComponents.DotNetBar.Validator.Highlighter()
        Me.Btn_Area = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Cargo = New DevComponents.DotNetBar.ButtonX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CmbCargo
        '
        Me.CmbCargo.DisplayMember = "Text"
        Me.CmbCargo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbCargo.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CmbCargo.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightOnFocus(Me.CmbCargo, True)
        Me.CmbCargo.ItemHeight = 16
        Me.CmbCargo.Location = New System.Drawing.Point(248, 126)
        Me.CmbCargo.Name = "CmbCargo"
        Me.CmbCargo.Size = New System.Drawing.Size(240, 22)
        Me.CmbCargo.TabIndex = 6
        Me.CmbCargo.WatermarkText = "Cargo"
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX7.ForeColor = System.Drawing.Color.Black
        Me.LabelX7.Location = New System.Drawing.Point(248, 106)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(278, 23)
        Me.LabelX7.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX7.TabIndex = 59
        Me.LabelX7.Text = "Cargo"
        '
        'CmbActividad
        '
        Me.CmbActividad.DisplayMember = "Text"
        Me.CmbActividad.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbActividad.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CmbActividad.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightOnFocus(Me.CmbActividad, True)
        Me.CmbActividad.ItemHeight = 16
        Me.CmbActividad.Location = New System.Drawing.Point(3, 126)
        Me.CmbActividad.Name = "CmbActividad"
        Me.CmbActividad.Size = New System.Drawing.Size(198, 22)
        Me.CmbActividad.TabIndex = 5
        Me.CmbActividad.WatermarkText = "Area actividad"
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
        Me.LabelX5.Location = New System.Drawing.Point(3, 106)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(89, 23)
        Me.LabelX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX5.TabIndex = 57
        Me.LabelX5.Text = "Area Actividad"
        '
        'TxtEmail
        '
        '
        '
        '
        Me.TxtEmail.Border.Class = "TextBoxBorder"
        Me.TxtEmail.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtEmail.DisabledBackColor = System.Drawing.Color.White
        Me.TxtEmail.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtEmail.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightOnFocus(Me.TxtEmail, True)
        Me.TxtEmail.Location = New System.Drawing.Point(217, 80)
        Me.TxtEmail.Name = "TxtEmail"
        Me.TxtEmail.Size = New System.Drawing.Size(309, 22)
        Me.TxtEmail.TabIndex = 4
        Me.TxtEmail.WatermarkText = "E-mail"
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
        Me.LabelX4.Location = New System.Drawing.Point(217, 59)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(89, 23)
        Me.LabelX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX4.TabIndex = 55
        Me.LabelX4.Text = "E-Mail"
        '
        'TxtFax
        '
        '
        '
        '
        Me.TxtFax.Border.Class = "TextBoxBorder"
        Me.TxtFax.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtFax.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFax.DisabledBackColor = System.Drawing.Color.White
        Me.TxtFax.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtFax.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightOnFocus(Me.TxtFax, True)
        Me.TxtFax.Location = New System.Drawing.Point(112, 80)
        Me.TxtFax.Name = "TxtFax"
        Me.TxtFax.Size = New System.Drawing.Size(103, 22)
        Me.TxtFax.TabIndex = 3
        Me.TxtFax.WatermarkText = "Fax"
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
        Me.LabelX3.Location = New System.Drawing.Point(112, 59)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(89, 23)
        Me.LabelX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX3.TabIndex = 53
        Me.LabelX3.Text = "Fax"
        '
        'TxtTelefono
        '
        '
        '
        '
        Me.TxtTelefono.Border.Class = "TextBoxBorder"
        Me.TxtTelefono.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtTelefono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTelefono.DisabledBackColor = System.Drawing.Color.White
        Me.TxtTelefono.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtTelefono.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightOnFocus(Me.TxtTelefono, True)
        Me.TxtTelefono.Location = New System.Drawing.Point(3, 80)
        Me.TxtTelefono.Name = "TxtTelefono"
        Me.TxtTelefono.Size = New System.Drawing.Size(103, 22)
        Me.TxtTelefono.TabIndex = 2
        Me.TxtTelefono.WatermarkText = "Teléfono"
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
        Me.LabelX2.Location = New System.Drawing.Point(3, 59)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(89, 23)
        Me.LabelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX2.TabIndex = 51
        Me.LabelX2.Text = "Teléfono"
        '
        'TxtRazonSocial
        '
        '
        '
        '
        Me.TxtRazonSocial.Border.Class = "TextBoxBorder"
        Me.TxtRazonSocial.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtRazonSocial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtRazonSocial.DisabledBackColor = System.Drawing.Color.White
        Me.TxtRazonSocial.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtRazonSocial.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightOnFocus(Me.TxtRazonSocial, True)
        Me.TxtRazonSocial.Location = New System.Drawing.Point(112, 34)
        Me.TxtRazonSocial.Name = "TxtRazonSocial"
        Me.TxtRazonSocial.Size = New System.Drawing.Size(414, 22)
        Me.TxtRazonSocial.TabIndex = 1
        Me.TxtRazonSocial.WatermarkText = "Razón Social (Largo max. 50 caracteres)"
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
        Me.LabelX1.Location = New System.Drawing.Point(112, 12)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(376, 23)
        Me.LabelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX1.TabIndex = 49
        Me.LabelX1.Text = "Nombre contacto"
        '
        'TxtRut
        '
        '
        '
        '
        Me.TxtRut.Border.Class = "TextBoxBorder"
        Me.TxtRut.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtRut.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtRut.DisabledBackColor = System.Drawing.Color.White
        Me.TxtRut.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtRut.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightOnFocus(Me.TxtRut, True)
        Me.TxtRut.Location = New System.Drawing.Point(3, 34)
        Me.TxtRut.Name = "TxtRut"
        Me.TxtRut.Size = New System.Drawing.Size(103, 22)
        Me.TxtRut.TabIndex = 0
        Me.TxtRut.WatermarkText = "Rut"
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
        Me.LabelX6.Location = New System.Drawing.Point(3, 12)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(89, 23)
        Me.LabelX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX6.TabIndex = 47
        Me.LabelX6.Text = "R.U.T. (código)"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnxGrabar, Me.BtnEliminarContacto})
        Me.Bar1.Location = New System.Drawing.Point(0, 215)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(562, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 48
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnxGrabar
        '
        Me.BtnxGrabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnxGrabar.FontBold = True
        Me.BtnxGrabar.ForeColor = System.Drawing.Color.Navy
        Me.BtnxGrabar.Image = CType(resources.GetObject("BtnxGrabar.Image"), System.Drawing.Image)
        Me.BtnxGrabar.ImageAlt = CType(resources.GetObject("BtnxGrabar.ImageAlt"), System.Drawing.Image)
        Me.BtnxGrabar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnxGrabar.Name = "BtnxGrabar"
        Me.BtnxGrabar.Tooltip = "Grabar"
        '
        'BtnEliminarContacto
        '
        Me.BtnEliminarContacto.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnEliminarContacto.Enabled = False
        Me.BtnEliminarContacto.FontBold = True
        Me.BtnEliminarContacto.ForeColor = System.Drawing.Color.Navy
        Me.BtnEliminarContacto.Image = CType(resources.GetObject("BtnEliminarContacto.Image"), System.Drawing.Image)
        Me.BtnEliminarContacto.ImageAlt = CType(resources.GetObject("BtnEliminarContacto.ImageAlt"), System.Drawing.Image)
        Me.BtnEliminarContacto.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnEliminarContacto.Name = "BtnEliminarContacto"
        Me.BtnEliminarContacto.Tooltip = "Eliminar contacto"
        '
        'Highlighter1
        '
        Me.Highlighter1.ContainerControl = Me
        Me.Highlighter1.FocusHighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
        Me.Highlighter1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        '
        'Btn_Area
        '
        Me.Btn_Area.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Area.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Area.Image = CType(resources.GetObject("Btn_Area.Image"), System.Drawing.Image)
        Me.Btn_Area.ImageAlt = CType(resources.GetObject("Btn_Area.ImageAlt"), System.Drawing.Image)
        Me.Btn_Area.Location = New System.Drawing.Point(207, 126)
        Me.Btn_Area.Name = "Btn_Area"
        Me.Btn_Area.Size = New System.Drawing.Size(32, 23)
        Me.Btn_Area.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Area.TabIndex = 60
        Me.Btn_Area.Tooltip = "Mantención de area actividad"
        '
        'Btn_Cargo
        '
        Me.Btn_Cargo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Cargo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Cargo.Image = CType(resources.GetObject("Btn_Cargo.Image"), System.Drawing.Image)
        Me.Btn_Cargo.ImageAlt = CType(resources.GetObject("Btn_Cargo.ImageAlt"), System.Drawing.Image)
        Me.Btn_Cargo.Location = New System.Drawing.Point(494, 125)
        Me.Btn_Cargo.Name = "Btn_Cargo"
        Me.Btn_Cargo.Size = New System.Drawing.Size(32, 23)
        Me.Btn_Cargo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Cargo.TabIndex = 61
        Me.Btn_Cargo.Tooltip = "Mantención de cargos"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.TxtEmail)
        Me.GroupPanel1.Controls.Add(Me.TxtFax)
        Me.GroupPanel1.Controls.Add(Me.LabelX4)
        Me.GroupPanel1.Controls.Add(Me.TxtTelefono)
        Me.GroupPanel1.Controls.Add(Me.LabelX3)
        Me.GroupPanel1.Controls.Add(Me.TxtRazonSocial)
        Me.GroupPanel1.Controls.Add(Me.TxtRut)
        Me.GroupPanel1.Controls.Add(Me.LabelX2)
        Me.GroupPanel1.Controls.Add(Me.Btn_Cargo)
        Me.GroupPanel1.Controls.Add(Me.CmbActividad)
        Me.GroupPanel1.Controls.Add(Me.Btn_Area)
        Me.GroupPanel1.Controls.Add(Me.LabelX1)
        Me.GroupPanel1.Controls.Add(Me.CmbCargo)
        Me.GroupPanel1.Controls.Add(Me.LabelX6)
        Me.GroupPanel1.Controls.Add(Me.LabelX5)
        Me.GroupPanel1.Controls.Add(Me.LabelX7)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(538, 189)
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
        Me.GroupPanel1.TabIndex = 50
        Me.GroupPanel1.Text = "Ficha contacto"
        '
        'Frm_Crear_Entidad_Mt_Crear_Contactos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(562, 256)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Crear_Entidad_Mt_Crear_Contactos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registro de contacto"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TxtEmail As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtFax As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtTelefono As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtRazonSocial As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents CmbCargo As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents CmbActividad As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnxGrabar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents TxtRut As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Highlighter1 As DevComponents.DotNetBar.Validator.Highlighter
    Friend WithEvents BtnEliminarContacto As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Cargo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Area As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
End Class
