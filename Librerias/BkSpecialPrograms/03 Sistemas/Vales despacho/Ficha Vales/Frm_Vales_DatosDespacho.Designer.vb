<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Vales_DatosDespacho
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Vales_DatosDespacho))
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.BtnGrabar = New DevComponents.DotNetBar.ButtonItem
        Me.BtnImprimir = New DevComponents.DotNetBar.ButtonItem
        Me.BtnEditar = New DevComponents.DotNetBar.ButtonItem
        Me.BtnCancelar = New DevComponents.DotNetBar.ButtonItem
        Me.TxtObservaciones = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.Grupo_Informacion = New System.Windows.Forms.GroupBox
        Me.TxtFono_Contacto = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX
        Me.Link_PersonaContacto = New System.Windows.Forms.LinkLabel
        Me.Link_Direccion = New System.Windows.Forms.LinkLabel
        Me.TxtHora_Recibe = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
        Me.Dtp_Fecha_Recibe = New DevComponents.Editors.DateTimeAdv.DateTimeInput
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX
        Me.TxtFono_Entidad = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX
        Me.TxtPersona_Contacto = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.TxtComuna_Recibe = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.TxtCiudad_Retiro = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX23 = New DevComponents.DotNetBar.LabelX
        Me.LabelX24 = New DevComponents.DotNetBar.LabelX
        Me.TxtDireccion_Recibe = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_Informacion.SuspendLayout()
        CType(Me.Dtp_Fecha_Recibe, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnGrabar, Me.BtnImprimir, Me.BtnEditar, Me.BtnCancelar})
        Me.Bar1.Location = New System.Drawing.Point(0, 363)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(639, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 88
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnGrabar
        '
        Me.BtnGrabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnGrabar.ForeColor = System.Drawing.Color.Black
        Me.BtnGrabar.Image = CType(resources.GetObject("BtnGrabar.Image"), System.Drawing.Image)
        Me.BtnGrabar.Name = "BtnGrabar"
        Me.BtnGrabar.Tooltip = "Grabar"
        '
        'BtnImprimir
        '
        Me.BtnImprimir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnImprimir.ForeColor = System.Drawing.Color.Black
        Me.BtnImprimir.Image = CType(resources.GetObject("BtnImprimir.Image"), System.Drawing.Image)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Tooltip = "imprimir"
        '
        'BtnEditar
        '
        Me.BtnEditar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnEditar.ForeColor = System.Drawing.Color.Black
        Me.BtnEditar.Image = CType(resources.GetObject("BtnEditar.Image"), System.Drawing.Image)
        Me.BtnEditar.Name = "BtnEditar"
        Me.BtnEditar.Tooltip = "Editar dirección de despacho"
        Me.BtnEditar.Visible = False
        '
        'BtnCancelar
        '
        Me.BtnCancelar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnCancelar.ForeColor = System.Drawing.Color.Black
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Tooltip = "Cancelar"
        '
        'TxtObservaciones
        '
        Me.TxtObservaciones.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtObservaciones.Border.Class = "TextBoxBorder"
        Me.TxtObservaciones.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtObservaciones.DisabledBackColor = System.Drawing.Color.White
        Me.TxtObservaciones.FocusHighlightEnabled = True
        Me.TxtObservaciones.ForeColor = System.Drawing.Color.Black
        Me.TxtObservaciones.Location = New System.Drawing.Point(6, 242)
        Me.TxtObservaciones.Multiline = True
        Me.TxtObservaciones.Name = "TxtObservaciones"
        Me.TxtObservaciones.PreventEnterBeep = True
        Me.TxtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtObservaciones.Size = New System.Drawing.Size(609, 77)
        Me.TxtObservaciones.TabIndex = 7
        '
        'Grupo_Informacion
        '
        Me.Grupo_Informacion.BackColor = System.Drawing.Color.White
        Me.Grupo_Informacion.Controls.Add(Me.TxtObservaciones)
        Me.Grupo_Informacion.Controls.Add(Me.TxtFono_Contacto)
        Me.Grupo_Informacion.Controls.Add(Me.LabelX2)
        Me.Grupo_Informacion.Controls.Add(Me.Link_PersonaContacto)
        Me.Grupo_Informacion.Controls.Add(Me.Link_Direccion)
        Me.Grupo_Informacion.Controls.Add(Me.TxtHora_Recibe)
        Me.Grupo_Informacion.Controls.Add(Me.LabelX1)
        Me.Grupo_Informacion.Controls.Add(Me.Dtp_Fecha_Recibe)
        Me.Grupo_Informacion.Controls.Add(Me.LabelX4)
        Me.Grupo_Informacion.Controls.Add(Me.TxtFono_Entidad)
        Me.Grupo_Informacion.Controls.Add(Me.LabelX3)
        Me.Grupo_Informacion.Controls.Add(Me.TxtPersona_Contacto)
        Me.Grupo_Informacion.Controls.Add(Me.TxtComuna_Recibe)
        Me.Grupo_Informacion.Controls.Add(Me.TxtCiudad_Retiro)
        Me.Grupo_Informacion.Controls.Add(Me.LabelX23)
        Me.Grupo_Informacion.Controls.Add(Me.LabelX24)
        Me.Grupo_Informacion.Controls.Add(Me.TxtDireccion_Recibe)
        Me.Grupo_Informacion.Controls.Add(Me.LabelX5)
        Me.Grupo_Informacion.ForeColor = System.Drawing.Color.Black
        Me.Grupo_Informacion.Location = New System.Drawing.Point(6, 12)
        Me.Grupo_Informacion.Name = "Grupo_Informacion"
        Me.Grupo_Informacion.Size = New System.Drawing.Size(627, 335)
        Me.Grupo_Informacion.TabIndex = 93
        Me.Grupo_Informacion.TabStop = False
        Me.Grupo_Informacion.Text = "Dirección de despacho"
        '
        'TxtFono_Contacto
        '
        Me.TxtFono_Contacto.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtFono_Contacto.Border.Class = "TextBoxBorder"
        Me.TxtFono_Contacto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtFono_Contacto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFono_Contacto.DisabledBackColor = System.Drawing.Color.White
        Me.TxtFono_Contacto.FocusHighlightEnabled = True
        Me.TxtFono_Contacto.ForeColor = System.Drawing.Color.Black
        Me.TxtFono_Contacto.Location = New System.Drawing.Point(304, 137)
        Me.TxtFono_Contacto.Name = "TxtFono_Contacto"
        Me.TxtFono_Contacto.PreventEnterBeep = True
        Me.TxtFono_Contacto.Size = New System.Drawing.Size(311, 22)
        Me.TxtFono_Contacto.TabIndex = 5
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(304, 117)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(153, 23)
        Me.LabelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX2.TabIndex = 79
        Me.LabelX2.Text = "Teléfono (Contacto)"
        '
        'Link_PersonaContacto
        '
        Me.Link_PersonaContacto.AutoSize = True
        Me.Link_PersonaContacto.BackColor = System.Drawing.Color.White
        Me.Link_PersonaContacto.ForeColor = System.Drawing.Color.Black
        Me.Link_PersonaContacto.Location = New System.Drawing.Point(6, 121)
        Me.Link_PersonaContacto.Name = "Link_PersonaContacto"
        Me.Link_PersonaContacto.Size = New System.Drawing.Size(226, 13)
        Me.Link_PersonaContacto.TabIndex = 77
        Me.Link_PersonaContacto.TabStop = True
        Me.Link_PersonaContacto.Text = "Persona contacto (Receptor de mercadería)"
        '
        'Link_Direccion
        '
        Me.Link_Direccion.AutoSize = True
        Me.Link_Direccion.BackColor = System.Drawing.Color.White
        Me.Link_Direccion.ForeColor = System.Drawing.Color.Black
        Me.Link_Direccion.Location = New System.Drawing.Point(6, 25)
        Me.Link_Direccion.Name = "Link_Direccion"
        Me.Link_Direccion.Size = New System.Drawing.Size(55, 13)
        Me.Link_Direccion.TabIndex = 76
        Me.Link_Direccion.TabStop = True
        Me.Link_Direccion.Text = "Dirección"
        '
        'TxtHora_Recibe
        '
        Me.TxtHora_Recibe.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtHora_Recibe.Border.Class = "TextBoxBorder"
        Me.TxtHora_Recibe.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtHora_Recibe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtHora_Recibe.DisabledBackColor = System.Drawing.Color.White
        Me.TxtHora_Recibe.FocusHighlightEnabled = True
        Me.TxtHora_Recibe.ForeColor = System.Drawing.Color.Black
        Me.TxtHora_Recibe.Location = New System.Drawing.Point(214, 185)
        Me.TxtHora_Recibe.Name = "TxtHora_Recibe"
        Me.TxtHora_Recibe.PreventEnterBeep = True
        Me.TxtHora_Recibe.Size = New System.Drawing.Size(401, 22)
        Me.TxtHora_Recibe.TabIndex = 6
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(214, 165)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(153, 23)
        Me.LabelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX1.TabIndex = 71
        Me.LabelX1.Text = "Horario"
        '
        'Dtp_Fecha_Recibe
        '
        Me.Dtp_Fecha_Recibe.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_Fecha_Recibe.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Recibe.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Recibe.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Recibe.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Recibe.FocusHighlightEnabled = True
        Me.Dtp_Fecha_Recibe.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Recibe.Format = DevComponents.Editors.eDateTimePickerFormat.[Long]
        Me.Dtp_Fecha_Recibe.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Recibe.Location = New System.Drawing.Point(6, 185)
        '
        '
        '
        Me.Dtp_Fecha_Recibe.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Recibe.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Recibe.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Recibe.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Recibe.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Recibe.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Recibe.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Recibe.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Recibe.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Recibe.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Recibe.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Recibe.MonthCalendar.DisplayMonth = New Date(2014, 11, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Recibe.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Recibe.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Recibe.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Recibe.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Recibe.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Recibe.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Recibe.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Recibe.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Recibe.Name = "Dtp_Fecha_Recibe"
        Me.Dtp_Fecha_Recibe.Size = New System.Drawing.Size(200, 22)
        Me.Dtp_Fecha_Recibe.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Recibe.TabIndex = 5
        Me.Dtp_Fecha_Recibe.TabStop = False
        Me.Dtp_Fecha_Recibe.Value = New Date(2014, 9, 30, 0, 0, 0, 0)
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(6, 165)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(153, 23)
        Me.LabelX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX4.TabIndex = 69
        Me.LabelX4.Text = "Fecha"
        '
        'TxtFono_Entidad
        '
        Me.TxtFono_Entidad.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtFono_Entidad.Border.Class = "TextBoxBorder"
        Me.TxtFono_Entidad.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtFono_Entidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFono_Entidad.DisabledBackColor = System.Drawing.Color.White
        Me.TxtFono_Entidad.FocusHighlightEnabled = True
        Me.TxtFono_Entidad.ForeColor = System.Drawing.Color.Black
        Me.TxtFono_Entidad.Location = New System.Drawing.Point(439, 89)
        Me.TxtFono_Entidad.Name = "TxtFono_Entidad"
        Me.TxtFono_Entidad.PreventEnterBeep = True
        Me.TxtFono_Entidad.Size = New System.Drawing.Size(176, 22)
        Me.TxtFono_Entidad.TabIndex = 3
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(439, 69)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(153, 23)
        Me.LabelX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX3.TabIndex = 66
        Me.LabelX3.Text = "Teléfono (Entidad)"
        '
        'TxtPersona_Contacto
        '
        Me.TxtPersona_Contacto.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtPersona_Contacto.Border.Class = "TextBoxBorder"
        Me.TxtPersona_Contacto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtPersona_Contacto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPersona_Contacto.DisabledBackColor = System.Drawing.Color.White
        Me.TxtPersona_Contacto.FocusHighlightEnabled = True
        Me.TxtPersona_Contacto.ForeColor = System.Drawing.Color.Black
        Me.TxtPersona_Contacto.Location = New System.Drawing.Point(6, 137)
        Me.TxtPersona_Contacto.Name = "TxtPersona_Contacto"
        Me.TxtPersona_Contacto.PreventEnterBeep = True
        Me.TxtPersona_Contacto.Size = New System.Drawing.Size(292, 22)
        Me.TxtPersona_Contacto.TabIndex = 4
        '
        'TxtComuna_Recibe
        '
        Me.TxtComuna_Recibe.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtComuna_Recibe.Border.Class = "TextBoxBorder"
        Me.TxtComuna_Recibe.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtComuna_Recibe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtComuna_Recibe.DisabledBackColor = System.Drawing.Color.White
        Me.TxtComuna_Recibe.ForeColor = System.Drawing.Color.Black
        Me.TxtComuna_Recibe.Location = New System.Drawing.Point(238, 89)
        Me.TxtComuna_Recibe.Name = "TxtComuna_Recibe"
        Me.TxtComuna_Recibe.PreventEnterBeep = True
        Me.TxtComuna_Recibe.Size = New System.Drawing.Size(195, 22)
        Me.TxtComuna_Recibe.TabIndex = 2
        '
        'TxtCiudad_Retiro
        '
        Me.TxtCiudad_Retiro.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtCiudad_Retiro.Border.Class = "TextBoxBorder"
        Me.TxtCiudad_Retiro.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtCiudad_Retiro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCiudad_Retiro.DisabledBackColor = System.Drawing.Color.White
        Me.TxtCiudad_Retiro.FocusHighlightEnabled = True
        Me.TxtCiudad_Retiro.ForeColor = System.Drawing.Color.Black
        Me.TxtCiudad_Retiro.Location = New System.Drawing.Point(6, 89)
        Me.TxtCiudad_Retiro.Name = "TxtCiudad_Retiro"
        Me.TxtCiudad_Retiro.PreventEnterBeep = True
        Me.TxtCiudad_Retiro.Size = New System.Drawing.Size(226, 22)
        Me.TxtCiudad_Retiro.TabIndex = 1
        '
        'LabelX23
        '
        Me.LabelX23.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX23.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX23.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX23.ForeColor = System.Drawing.Color.Black
        Me.LabelX23.Location = New System.Drawing.Point(6, 69)
        Me.LabelX23.Name = "LabelX23"
        Me.LabelX23.Size = New System.Drawing.Size(89, 23)
        Me.LabelX23.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX23.TabIndex = 60
        Me.LabelX23.Text = "Ciudad"
        '
        'LabelX24
        '
        Me.LabelX24.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX24.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX24.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX24.ForeColor = System.Drawing.Color.Black
        Me.LabelX24.Location = New System.Drawing.Point(238, 69)
        Me.LabelX24.Name = "LabelX24"
        Me.LabelX24.Size = New System.Drawing.Size(89, 23)
        Me.LabelX24.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX24.TabIndex = 61
        Me.LabelX24.Text = "Comuna"
        '
        'TxtDireccion_Recibe
        '
        Me.TxtDireccion_Recibe.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtDireccion_Recibe.Border.Class = "TextBoxBorder"
        Me.TxtDireccion_Recibe.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtDireccion_Recibe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDireccion_Recibe.DisabledBackColor = System.Drawing.Color.White
        Me.TxtDireccion_Recibe.FocusHighlightEnabled = True
        Me.TxtDireccion_Recibe.ForeColor = System.Drawing.Color.Black
        Me.TxtDireccion_Recibe.Location = New System.Drawing.Point(6, 41)
        Me.TxtDireccion_Recibe.MaxLength = 100
        Me.TxtDireccion_Recibe.Name = "TxtDireccion_Recibe"
        Me.TxtDireccion_Recibe.PreventEnterBeep = True
        Me.TxtDireccion_Recibe.Size = New System.Drawing.Size(609, 22)
        Me.TxtDireccion_Recibe.TabIndex = 0
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(6, 220)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(361, 23)
        Me.LabelX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX5.TabIndex = 80
        Me.LabelX5.Text = "Observaciones generales/calles de referencia"
        '
        'Frm_Vales_DatosDespacho
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(639, 404)
        Me.ControlBox = False
        Me.Controls.Add(Me.Grupo_Informacion)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_Vales_DatosDespacho"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Datos de despacho"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo_Informacion.ResumeLayout(False)
        Me.Grupo_Informacion.PerformLayout()
        CType(Me.Dtp_Fecha_Recibe, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnGrabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnCancelar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Public WithEvents TxtObservaciones As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents TxtHora_Recibe As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Dtp_Fecha_Recibe As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Public WithEvents TxtFono_Entidad As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Public WithEvents TxtPersona_Contacto As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents TxtComuna_Recibe As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents TxtCiudad_Retiro As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX23 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX24 As DevComponents.DotNetBar.LabelX
    Public WithEvents TxtDireccion_Recibe As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Link_Direccion As System.Windows.Forms.LinkLabel
    Friend WithEvents Link_PersonaContacto As System.Windows.Forms.LinkLabel
    Public WithEvents TxtFono_Contacto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Public WithEvents BtnEditar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Public WithEvents BtnImprimir As DevComponents.DotNetBar.ButtonItem
    Private WithEvents Grupo_Informacion As System.Windows.Forms.GroupBox
End Class
