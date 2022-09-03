<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Licencia_Empresa
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Licencia_Empresa))
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.BtnAceptar = New DevComponents.DotNetBar.ButtonItem
        Me.BtnxSalir = New DevComponents.DotNetBar.ButtonItem
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX
        Me.Txt_Llave4 = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX
        Me.Txt_Llave3 = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
        Me.Txt_Llave2 = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.TxtTelefonos = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX
        Me.TxtCiudad = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX
        Me.TxtCant_licencias = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX
        Me.TxtPais = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX
        Me.DtpFechaExpiracion = New DevComponents.Editors.DateTimeAdv.DateTimeInput
        Me.LblFechaExpiracion = New DevComponents.DotNetBar.LabelX
        Me.TxtGiro = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.TxtRut = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.TxtNombreCorto = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX
        Me.TxtRazonSocial = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX
        Me.TxtDireccion = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX
        Me.LabelX15 = New DevComponents.DotNetBar.LabelX
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX
        Me.Txt_Llave1 = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.Imagen_LLave_1 = New DevComponents.DotNetBar.Controls.ReflectionImage
        Me.Imagen_LLave_2 = New DevComponents.DotNetBar.Controls.ReflectionImage
        Me.Imagen_LLave_3 = New DevComponents.DotNetBar.Controls.ReflectionImage
        Me.Imagen_LLave_4 = New DevComponents.DotNetBar.Controls.ReflectionImage
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.DtpFechaExpiracion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnAceptar, Me.BtnxSalir})
        Me.Bar1.Location = New System.Drawing.Point(0, 471)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(530, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 8
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnAceptar
        '
        Me.BtnAceptar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnAceptar.ForeColor = System.Drawing.Color.Black
        Me.BtnAceptar.Image = CType(resources.GetObject("BtnAceptar.Image"), System.Drawing.Image)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Text = "Grabar licencia"
        '
        'BtnxSalir
        '
        Me.BtnxSalir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnxSalir.ForeColor = System.Drawing.Color.Black
        Me.BtnxSalir.Image = Global.Funciones_BakApp.My.Resources.Resources.button_rounded_red_delete
        Me.BtnxSalir.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnxSalir.Name = "BtnxSalir"
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(12, 431)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(116, 23)
        Me.LabelX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX4.TabIndex = 92
        Me.LabelX4.Text = "Llave 4"
        '
        'Txt_Llave4
        '
        Me.Txt_Llave4.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Llave4.Border.Class = "TextBoxBorder"
        Me.Txt_Llave4.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Llave4.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Llave4.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Llave4.FocusHighlightEnabled = True
        Me.Txt_Llave4.ForeColor = System.Drawing.Color.Black
        Me.Txt_Llave4.Location = New System.Drawing.Point(138, 432)
        Me.Txt_Llave4.MaxLength = 50
        Me.Txt_Llave4.Name = "Txt_Llave4"
        Me.Txt_Llave4.Size = New System.Drawing.Size(352, 22)
        Me.Txt_Llave4.TabIndex = 4
        Me.Txt_Llave4.TabStop = False
        Me.Txt_Llave4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(12, 403)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(116, 23)
        Me.LabelX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX5.TabIndex = 90
        Me.LabelX5.Text = "Llave 3"
        '
        'Txt_Llave3
        '
        Me.Txt_Llave3.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Llave3.Border.Class = "TextBoxBorder"
        Me.Txt_Llave3.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Llave3.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Llave3.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Llave3.FocusHighlightEnabled = True
        Me.Txt_Llave3.ForeColor = System.Drawing.Color.Black
        Me.Txt_Llave3.Location = New System.Drawing.Point(138, 404)
        Me.Txt_Llave3.MaxLength = 50
        Me.Txt_Llave3.Name = "Txt_Llave3"
        Me.Txt_Llave3.Size = New System.Drawing.Size(352, 22)
        Me.Txt_Llave3.TabIndex = 3
        Me.Txt_Llave3.TabStop = False
        Me.Txt_Llave3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(12, 374)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(116, 23)
        Me.LabelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX1.TabIndex = 88
        Me.LabelX1.Text = "Llave 2"
        '
        'Txt_Llave2
        '
        Me.Txt_Llave2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Llave2.Border.Class = "TextBoxBorder"
        Me.Txt_Llave2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Llave2.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Llave2.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Llave2.FocusHighlightEnabled = True
        Me.Txt_Llave2.ForeColor = System.Drawing.Color.Black
        Me.Txt_Llave2.Location = New System.Drawing.Point(138, 375)
        Me.Txt_Llave2.MaxLength = 50
        Me.Txt_Llave2.Name = "Txt_Llave2"
        Me.Txt_Llave2.Size = New System.Drawing.Size(352, 22)
        Me.Txt_Llave2.TabIndex = 2
        Me.Txt_Llave2.TabStop = False
        Me.Txt_Llave2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupPanel2.CanvasColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.TxtTelefonos)
        Me.GroupPanel2.Controls.Add(Me.LabelX7)
        Me.GroupPanel2.Controls.Add(Me.TxtCiudad)
        Me.GroupPanel2.Controls.Add(Me.LabelX8)
        Me.GroupPanel2.Controls.Add(Me.TxtCant_licencias)
        Me.GroupPanel2.Controls.Add(Me.LabelX3)
        Me.GroupPanel2.Controls.Add(Me.TxtPais)
        Me.GroupPanel2.Controls.Add(Me.LabelX9)
        Me.GroupPanel2.Controls.Add(Me.DtpFechaExpiracion)
        Me.GroupPanel2.Controls.Add(Me.LblFechaExpiracion)
        Me.GroupPanel2.Controls.Add(Me.TxtGiro)
        Me.GroupPanel2.Controls.Add(Me.TxtRut)
        Me.GroupPanel2.Controls.Add(Me.TxtNombreCorto)
        Me.GroupPanel2.Controls.Add(Me.LabelX10)
        Me.GroupPanel2.Controls.Add(Me.LabelX11)
        Me.GroupPanel2.Controls.Add(Me.TxtRazonSocial)
        Me.GroupPanel2.Controls.Add(Me.LabelX12)
        Me.GroupPanel2.Controls.Add(Me.TxtDireccion)
        Me.GroupPanel2.Controls.Add(Me.LabelX13)
        Me.GroupPanel2.Controls.Add(Me.LabelX15)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(12, 3)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(508, 328)
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
        Me.GroupPanel2.TabIndex = 86
        Me.GroupPanel2.Text = "Datos de la empresa"
        '
        'TxtTelefonos
        '
        Me.TxtTelefonos.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtTelefonos.Border.Class = "TextBoxBorder"
        Me.TxtTelefonos.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtTelefonos.DisabledBackColor = System.Drawing.Color.White
        Me.TxtTelefonos.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtTelefonos.FocusHighlightEnabled = True
        Me.TxtTelefonos.ForeColor = System.Drawing.Color.Black
        Me.TxtTelefonos.Location = New System.Drawing.Point(307, 229)
        Me.TxtTelefonos.Name = "TxtTelefonos"
        Me.TxtTelefonos.ReadOnly = True
        Me.TxtTelefonos.Size = New System.Drawing.Size(181, 22)
        Me.TxtTelefonos.TabIndex = 66
        Me.TxtTelefonos.TabStop = False
        Me.TxtTelefonos.WatermarkText = "Largo max. 13"
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
        Me.LabelX7.Location = New System.Drawing.Point(307, 209)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(134, 23)
        Me.LabelX7.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX7.TabIndex = 67
        Me.LabelX7.Text = "Teléfonos"
        '
        'TxtCiudad
        '
        Me.TxtCiudad.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtCiudad.Border.Class = "TextBoxBorder"
        Me.TxtCiudad.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtCiudad.DisabledBackColor = System.Drawing.Color.White
        Me.TxtCiudad.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtCiudad.FocusHighlightEnabled = True
        Me.TxtCiudad.ForeColor = System.Drawing.Color.Black
        Me.TxtCiudad.Location = New System.Drawing.Point(101, 229)
        Me.TxtCiudad.Name = "TxtCiudad"
        Me.TxtCiudad.ReadOnly = True
        Me.TxtCiudad.Size = New System.Drawing.Size(200, 22)
        Me.TxtCiudad.TabIndex = 64
        Me.TxtCiudad.TabStop = False
        Me.TxtCiudad.WatermarkText = "Largo max. 13"
        '
        'LabelX8
        '
        Me.LabelX8.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX8.ForeColor = System.Drawing.Color.Black
        Me.LabelX8.Location = New System.Drawing.Point(101, 209)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(89, 23)
        Me.LabelX8.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX8.TabIndex = 65
        Me.LabelX8.Text = "Ciudad"
        '
        'TxtCant_licencias
        '
        Me.TxtCant_licencias.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtCant_licencias.Border.Class = "TextBoxBorder"
        Me.TxtCant_licencias.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtCant_licencias.DisabledBackColor = System.Drawing.Color.White
        Me.TxtCant_licencias.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TxtCant_licencias.FocusHighlightEnabled = True
        Me.TxtCant_licencias.ForeColor = System.Drawing.Color.Black
        Me.TxtCant_licencias.Location = New System.Drawing.Point(388, 272)
        Me.TxtCant_licencias.Name = "TxtCant_licencias"
        Me.TxtCant_licencias.Size = New System.Drawing.Size(100, 22)
        Me.TxtCant_licencias.TabIndex = 0
        Me.TxtCant_licencias.WatermarkText = "Largo max. 13"
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
        Me.LabelX3.Location = New System.Drawing.Point(320, 272)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(62, 23)
        Me.LabelX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX3.TabIndex = 74
        Me.LabelX3.Text = "Licencias"
        '
        'TxtPais
        '
        Me.TxtPais.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtPais.Border.Class = "TextBoxBorder"
        Me.TxtPais.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtPais.DisabledBackColor = System.Drawing.Color.White
        Me.TxtPais.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtPais.FocusHighlightEnabled = True
        Me.TxtPais.ForeColor = System.Drawing.Color.Black
        Me.TxtPais.Location = New System.Drawing.Point(6, 229)
        Me.TxtPais.Name = "TxtPais"
        Me.TxtPais.ReadOnly = True
        Me.TxtPais.Size = New System.Drawing.Size(89, 22)
        Me.TxtPais.TabIndex = 62
        Me.TxtPais.TabStop = False
        Me.TxtPais.WatermarkText = "Largo max. 13"
        '
        'LabelX9
        '
        Me.LabelX9.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX9.ForeColor = System.Drawing.Color.Black
        Me.LabelX9.Location = New System.Drawing.Point(6, 209)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(89, 23)
        Me.LabelX9.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX9.TabIndex = 63
        Me.LabelX9.Text = "Pais"
        '
        'DtpFechaExpiracion
        '
        Me.DtpFechaExpiracion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.DtpFechaExpiracion.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.DtpFechaExpiracion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DtpFechaExpiracion.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.DtpFechaExpiracion.ButtonDropDown.Visible = True
        Me.DtpFechaExpiracion.ForeColor = System.Drawing.Color.Black
        Me.DtpFechaExpiracion.IsPopupCalendarOpen = False
        Me.DtpFechaExpiracion.Location = New System.Drawing.Point(101, 272)
        '
        '
        '
        Me.DtpFechaExpiracion.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.DtpFechaExpiracion.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DtpFechaExpiracion.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.DtpFechaExpiracion.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.DtpFechaExpiracion.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.DtpFechaExpiracion.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.DtpFechaExpiracion.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.DtpFechaExpiracion.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.DtpFechaExpiracion.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.DtpFechaExpiracion.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.DtpFechaExpiracion.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DtpFechaExpiracion.MonthCalendar.DisplayMonth = New Date(2014, 10, 1, 0, 0, 0, 0)
        Me.DtpFechaExpiracion.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.DtpFechaExpiracion.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.DtpFechaExpiracion.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.DtpFechaExpiracion.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.DtpFechaExpiracion.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.DtpFechaExpiracion.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DtpFechaExpiracion.MonthCalendar.TodayButtonVisible = True
        Me.DtpFechaExpiracion.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.DtpFechaExpiracion.Name = "DtpFechaExpiracion"
        Me.DtpFechaExpiracion.Size = New System.Drawing.Size(85, 22)
        Me.DtpFechaExpiracion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.DtpFechaExpiracion.TabIndex = 62
        Me.DtpFechaExpiracion.TabStop = False
        Me.DtpFechaExpiracion.Value = New Date(2014, 10, 14, 12, 21, 1, 0)
        '
        'LblFechaExpiracion
        '
        Me.LblFechaExpiracion.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LblFechaExpiracion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblFechaExpiracion.ForeColor = System.Drawing.Color.Black
        Me.LblFechaExpiracion.Location = New System.Drawing.Point(3, 272)
        Me.LblFechaExpiracion.Name = "LblFechaExpiracion"
        Me.LblFechaExpiracion.Size = New System.Drawing.Size(92, 23)
        Me.LblFechaExpiracion.TabIndex = 61
        Me.LblFechaExpiracion.Text = "Fecha expiración:"
        '
        'TxtGiro
        '
        Me.TxtGiro.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtGiro.Border.Class = "TextBoxBorder"
        Me.TxtGiro.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtGiro.DisabledBackColor = System.Drawing.Color.White
        Me.TxtGiro.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtGiro.FocusHighlightEnabled = True
        Me.TxtGiro.ForeColor = System.Drawing.Color.Black
        Me.TxtGiro.Location = New System.Drawing.Point(6, 181)
        Me.TxtGiro.Name = "TxtGiro"
        Me.TxtGiro.ReadOnly = True
        Me.TxtGiro.Size = New System.Drawing.Size(482, 22)
        Me.TxtGiro.TabIndex = 53
        Me.TxtGiro.TabStop = False
        Me.TxtGiro.WatermarkText = "Griro (Largo Max. 100 caracteres)"
        '
        'TxtRut
        '
        Me.TxtRut.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtRut.Border.Class = "TextBoxBorder"
        Me.TxtRut.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtRut.DisabledBackColor = System.Drawing.Color.White
        Me.TxtRut.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtRut.FocusHighlightEnabled = True
        Me.TxtRut.ForeColor = System.Drawing.Color.Black
        Me.TxtRut.Location = New System.Drawing.Point(6, 23)
        Me.TxtRut.Name = "TxtRut"
        Me.TxtRut.ReadOnly = True
        Me.TxtRut.Size = New System.Drawing.Size(140, 22)
        Me.TxtRut.TabIndex = 50
        Me.TxtRut.TabStop = False
        Me.TxtRut.WatermarkText = "Largo max. 13"
        '
        'TxtNombreCorto
        '
        Me.TxtNombreCorto.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtNombreCorto.Border.Class = "TextBoxBorder"
        Me.TxtNombreCorto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtNombreCorto.DisabledBackColor = System.Drawing.Color.White
        Me.TxtNombreCorto.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtNombreCorto.FocusHighlightEnabled = True
        Me.TxtNombreCorto.ForeColor = System.Drawing.Color.Black
        Me.TxtNombreCorto.Location = New System.Drawing.Point(212, 23)
        Me.TxtNombreCorto.Name = "TxtNombreCorto"
        Me.TxtNombreCorto.ReadOnly = True
        Me.TxtNombreCorto.Size = New System.Drawing.Size(276, 22)
        Me.TxtNombreCorto.TabIndex = 60
        Me.TxtNombreCorto.TabStop = False
        Me.TxtNombreCorto.WatermarkText = "Largo max. 13"
        '
        'LabelX10
        '
        Me.LabelX10.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX10.ForeColor = System.Drawing.Color.Black
        Me.LabelX10.Location = New System.Drawing.Point(212, 3)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(89, 23)
        Me.LabelX10.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX10.TabIndex = 61
        Me.LabelX10.Text = "Nombre corto"
        '
        'LabelX11
        '
        Me.LabelX11.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX11.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX11.ForeColor = System.Drawing.Color.Black
        Me.LabelX11.Location = New System.Drawing.Point(6, 3)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(89, 23)
        Me.LabelX11.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX11.TabIndex = 56
        Me.LabelX11.Text = "Rut"
        '
        'TxtRazonSocial
        '
        Me.TxtRazonSocial.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtRazonSocial.Border.Class = "TextBoxBorder"
        Me.TxtRazonSocial.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtRazonSocial.DisabledBackColor = System.Drawing.Color.White
        Me.TxtRazonSocial.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtRazonSocial.FocusHighlightEnabled = True
        Me.TxtRazonSocial.ForeColor = System.Drawing.Color.Black
        Me.TxtRazonSocial.Location = New System.Drawing.Point(6, 74)
        Me.TxtRazonSocial.Name = "TxtRazonSocial"
        Me.TxtRazonSocial.ReadOnly = True
        Me.TxtRazonSocial.Size = New System.Drawing.Size(482, 22)
        Me.TxtRazonSocial.TabIndex = 51
        Me.TxtRazonSocial.TabStop = False
        Me.TxtRazonSocial.WatermarkText = "Razón Social (Largo max. 50 caracteres)"
        '
        'LabelX12
        '
        Me.LabelX12.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX12.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX12.ForeColor = System.Drawing.Color.Black
        Me.LabelX12.Location = New System.Drawing.Point(6, 162)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(89, 23)
        Me.LabelX12.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX12.TabIndex = 59
        Me.LabelX12.Text = "Giro"
        '
        'TxtDireccion
        '
        Me.TxtDireccion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtDireccion.Border.Class = "TextBoxBorder"
        Me.TxtDireccion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtDireccion.DisabledBackColor = System.Drawing.Color.White
        Me.TxtDireccion.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtDireccion.FocusHighlightEnabled = True
        Me.TxtDireccion.ForeColor = System.Drawing.Color.Black
        Me.TxtDireccion.Location = New System.Drawing.Point(6, 129)
        Me.TxtDireccion.Name = "TxtDireccion"
        Me.TxtDireccion.ReadOnly = True
        Me.TxtDireccion.Size = New System.Drawing.Size(482, 22)
        Me.TxtDireccion.TabIndex = 52
        Me.TxtDireccion.TabStop = False
        Me.TxtDireccion.WatermarkText = "Razón Social (Largo max. 50 caracteres)"
        '
        'LabelX13
        '
        Me.LabelX13.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX13.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX13.ForeColor = System.Drawing.Color.Black
        Me.LabelX13.Location = New System.Drawing.Point(6, 109)
        Me.LabelX13.Name = "LabelX13"
        Me.LabelX13.Size = New System.Drawing.Size(89, 23)
        Me.LabelX13.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX13.TabIndex = 58
        Me.LabelX13.Text = "Dirección"
        '
        'LabelX15
        '
        Me.LabelX15.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX15.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX15.ForeColor = System.Drawing.Color.Black
        Me.LabelX15.Location = New System.Drawing.Point(6, 55)
        Me.LabelX15.Name = "LabelX15"
        Me.LabelX15.Size = New System.Drawing.Size(89, 23)
        Me.LabelX15.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX15.TabIndex = 57
        Me.LabelX15.Text = "Razón social"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(12, 346)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(116, 23)
        Me.LabelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX2.TabIndex = 85
        Me.LabelX2.Text = "Llave 1"
        '
        'Txt_Llave1
        '
        Me.Txt_Llave1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Llave1.Border.Class = "TextBoxBorder"
        Me.Txt_Llave1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Llave1.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Llave1.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Txt_Llave1.FocusHighlightEnabled = True
        Me.Txt_Llave1.ForeColor = System.Drawing.Color.Black
        Me.Txt_Llave1.Location = New System.Drawing.Point(138, 347)
        Me.Txt_Llave1.MaxLength = 50
        Me.Txt_Llave1.Name = "Txt_Llave1"
        Me.Txt_Llave1.Size = New System.Drawing.Size(352, 22)
        Me.Txt_Llave1.TabIndex = 1
        Me.Txt_Llave1.TabStop = False
        Me.Txt_Llave1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Imagen_LLave_1
        '
        '
        '
        '
        Me.Imagen_LLave_1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Imagen_LLave_1.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Imagen_LLave_1.Image = CType(resources.GetObject("Imagen_LLave_1.Image"), System.Drawing.Image)
        Me.Imagen_LLave_1.Location = New System.Drawing.Point(496, 346)
        Me.Imagen_LLave_1.Name = "Imagen_LLave_1"
        Me.Imagen_LLave_1.Size = New System.Drawing.Size(24, 23)
        Me.Imagen_LLave_1.TabIndex = 93
        '
        'Imagen_LLave_2
        '
        '
        '
        '
        Me.Imagen_LLave_2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Imagen_LLave_2.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Imagen_LLave_2.Image = CType(resources.GetObject("Imagen_LLave_2.Image"), System.Drawing.Image)
        Me.Imagen_LLave_2.Location = New System.Drawing.Point(496, 374)
        Me.Imagen_LLave_2.Name = "Imagen_LLave_2"
        Me.Imagen_LLave_2.Size = New System.Drawing.Size(24, 23)
        Me.Imagen_LLave_2.TabIndex = 94
        '
        'Imagen_LLave_3
        '
        '
        '
        '
        Me.Imagen_LLave_3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Imagen_LLave_3.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Imagen_LLave_3.Image = CType(resources.GetObject("Imagen_LLave_3.Image"), System.Drawing.Image)
        Me.Imagen_LLave_3.Location = New System.Drawing.Point(496, 403)
        Me.Imagen_LLave_3.Name = "Imagen_LLave_3"
        Me.Imagen_LLave_3.Size = New System.Drawing.Size(24, 23)
        Me.Imagen_LLave_3.TabIndex = 95
        '
        'Imagen_LLave_4
        '
        '
        '
        '
        Me.Imagen_LLave_4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Imagen_LLave_4.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Imagen_LLave_4.Image = CType(resources.GetObject("Imagen_LLave_4.Image"), System.Drawing.Image)
        Me.Imagen_LLave_4.Location = New System.Drawing.Point(496, 431)
        Me.Imagen_LLave_4.Name = "Imagen_LLave_4"
        Me.Imagen_LLave_4.Size = New System.Drawing.Size(24, 23)
        Me.Imagen_LLave_4.TabIndex = 96
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "ok_button.png")
        Me.ImageList1.Images.SetKeyName(1, "delete.png")
        Me.ImageList1.Images.SetKeyName(2, "warning.png")
        '
        'Frm_Licencia_Empresa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(530, 512)
        Me.ControlBox = False
        Me.Controls.Add(Me.Imagen_LLave_4)
        Me.Controls.Add(Me.Imagen_LLave_3)
        Me.Controls.Add(Me.Imagen_LLave_2)
        Me.Controls.Add(Me.Imagen_LLave_1)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.Txt_Llave4)
        Me.Controls.Add(Me.LabelX5)
        Me.Controls.Add(Me.Txt_Llave3)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Txt_Llave2)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.Txt_Llave1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "Frm_Licencia_Empresa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ingresar licencia"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.DtpFechaExpiracion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnxSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnAceptar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Llave4 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Llave3 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Llave2 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TxtTelefonos As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtCiudad As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtCant_licencias As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtPais As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents DtpFechaExpiracion As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LblFechaExpiracion As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtGiro As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtRut As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtNombreCorto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtRazonSocial As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtDireccion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX15 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Llave1 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Imagen_LLave_1 As DevComponents.DotNetBar.Controls.ReflectionImage
    Friend WithEvents Imagen_LLave_2 As DevComponents.DotNetBar.Controls.ReflectionImage
    Friend WithEvents Imagen_LLave_3 As DevComponents.DotNetBar.Controls.ReflectionImage
    Friend WithEvents Imagen_LLave_4 As DevComponents.DotNetBar.Controls.ReflectionImage
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
End Class
