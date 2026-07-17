<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Aec_CesionExt
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Aec_CesionExt))
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar_Cesion = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Dtp_FechaCesion = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Lbl_FEmision_Desde = New DevComponents.DotNetBar.LabelX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Cesionario_Entidad = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Lbl_Documento = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_RutCedente = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_DireccionCedente = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_RazonSocialCedente = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_FUltimoVencimiento = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel3.SuspendLayout()
        CType(Me.Dtp_FechaCesion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.Dtp_FUltimoVencimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar_Cesion})
        Me.Bar1.Location = New System.Drawing.Point(0, 211)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(652, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 112
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Grabar_Cesion
        '
        Me.Btn_Grabar_Cesion.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar_Cesion.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar_Cesion.Image = CType(resources.GetObject("Btn_Grabar_Cesion.Image"), System.Drawing.Image)
        Me.Btn_Grabar_Cesion.ImageAlt = CType(resources.GetObject("Btn_Grabar_Cesion.ImageAlt"), System.Drawing.Image)
        Me.Btn_Grabar_Cesion.Name = "Btn_Grabar_Cesion"
        Me.Btn_Grabar_Cesion.Tooltip = "Grabar"
        '
        'GroupPanel3
        '
        Me.GroupPanel3.BackColor = System.Drawing.Color.White
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.Dtp_FUltimoVencimiento)
        Me.GroupPanel3.Controls.Add(Me.LabelX3)
        Me.GroupPanel3.Controls.Add(Me.Dtp_FechaCesion)
        Me.GroupPanel3.Controls.Add(Me.Lbl_FEmision_Desde)
        Me.GroupPanel3.Controls.Add(Me.LabelX7)
        Me.GroupPanel3.Controls.Add(Me.Txt_Cesionario_Entidad)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Location = New System.Drawing.Point(12, 124)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(629, 82)
        '
        '
        '
        Me.GroupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel3.Style.BackColorGradientAngle = 90
        Me.GroupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderBottomWidth = 1
        Me.GroupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderLeftWidth = 1
        Me.GroupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderRightWidth = 1
        Me.GroupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderTopWidth = 1
        Me.GroupPanel3.Style.CornerDiameter = 4
        Me.GroupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel3.TabIndex = 111
        Me.GroupPanel3.Text = "Datos del Cesionario"
        '
        'Dtp_FechaCesion
        '
        Me.Dtp_FechaCesion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_FechaCesion.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_FechaCesion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaCesion.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_FechaCesion.ButtonDropDown.Visible = True
        Me.Dtp_FechaCesion.ForeColor = System.Drawing.Color.Black
        Me.Dtp_FechaCesion.IsPopupCalendarOpen = False
        Me.Dtp_FechaCesion.Location = New System.Drawing.Point(88, 31)
        '
        '
        '
        Me.Dtp_FechaCesion.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FechaCesion.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaCesion.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_FechaCesion.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_FechaCesion.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_FechaCesion.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FechaCesion.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_FechaCesion.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_FechaCesion.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_FechaCesion.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_FechaCesion.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaCesion.MonthCalendar.DisplayMonth = New Date(2016, 7, 1, 0, 0, 0, 0)
        Me.Dtp_FechaCesion.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_FechaCesion.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_FechaCesion.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FechaCesion.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_FechaCesion.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FechaCesion.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_FechaCesion.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaCesion.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_FechaCesion.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_FechaCesion.Name = "Dtp_FechaCesion"
        Me.Dtp_FechaCesion.Size = New System.Drawing.Size(83, 22)
        Me.Dtp_FechaCesion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_FechaCesion.TabIndex = 37
        Me.Dtp_FechaCesion.Value = New Date(2016, 7, 8, 16, 33, 0, 0)
        '
        'Lbl_FEmision_Desde
        '
        Me.Lbl_FEmision_Desde.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_FEmision_Desde.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_FEmision_Desde.ForeColor = System.Drawing.Color.Black
        Me.Lbl_FEmision_Desde.Location = New System.Drawing.Point(3, 30)
        Me.Lbl_FEmision_Desde.Name = "Lbl_FEmision_Desde"
        Me.Lbl_FEmision_Desde.Size = New System.Drawing.Size(75, 23)
        Me.Lbl_FEmision_Desde.TabIndex = 36
        Me.Lbl_FEmision_Desde.Text = "Fecha cesión"
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.ForeColor = System.Drawing.Color.Black
        Me.LabelX7.Location = New System.Drawing.Point(3, 2)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(64, 23)
        Me.LabelX7.TabIndex = 11
        Me.LabelX7.Text = "Entidad"
        '
        'Txt_Cesionario_Entidad
        '
        Me.Txt_Cesionario_Entidad.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Cesionario_Entidad.Border.Class = "TextBoxBorder"
        Me.Txt_Cesionario_Entidad.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Cesionario_Entidad.ButtonCustom.Image = CType(resources.GetObject("Txt_Cesionario_Entidad.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Cesionario_Entidad.ButtonCustom.Visible = True
        Me.Txt_Cesionario_Entidad.ButtonCustom2.Image = CType(resources.GetObject("Txt_Cesionario_Entidad.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Cesionario_Entidad.ButtonCustom2.Visible = True
        Me.Txt_Cesionario_Entidad.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Cesionario_Entidad.ForeColor = System.Drawing.Color.Black
        Me.Txt_Cesionario_Entidad.Location = New System.Drawing.Point(88, 3)
        Me.Txt_Cesionario_Entidad.Name = "Txt_Cesionario_Entidad"
        Me.Txt_Cesionario_Entidad.PreventEnterBeep = True
        Me.Txt_Cesionario_Entidad.ReadOnly = True
        Me.Txt_Cesionario_Entidad.Size = New System.Drawing.Size(532, 22)
        Me.Txt_Cesionario_Entidad.TabIndex = 4
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Lbl_Documento)
        Me.GroupPanel2.Controls.Add(Me.Lbl_RutCedente)
        Me.GroupPanel2.Controls.Add(Me.Lbl_DireccionCedente)
        Me.GroupPanel2.Controls.Add(Me.Lbl_RazonSocialCedente)
        Me.GroupPanel2.Controls.Add(Me.LabelX6)
        Me.GroupPanel2.Controls.Add(Me.LabelX5)
        Me.GroupPanel2.Controls.Add(Me.LabelX2)
        Me.GroupPanel2.Controls.Add(Me.LabelX1)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(12, 6)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(629, 112)
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
        Me.GroupPanel2.TabIndex = 110
        Me.GroupPanel2.Text = "Datos del cedente y DTE"
        '
        'Lbl_Documento
        '
        Me.Lbl_Documento.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Documento.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Documento.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Lbl_Documento.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Documento.Location = New System.Drawing.Point(88, 3)
        Me.Lbl_Documento.Name = "Lbl_Documento"
        Me.Lbl_Documento.Size = New System.Drawing.Size(532, 23)
        Me.Lbl_Documento.TabIndex = 7
        Me.Lbl_Documento.Text = "0000058999"
        '
        'Lbl_RutCedente
        '
        Me.Lbl_RutCedente.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_RutCedente.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_RutCedente.ForeColor = System.Drawing.Color.Black
        Me.Lbl_RutCedente.Location = New System.Drawing.Point(88, 24)
        Me.Lbl_RutCedente.Name = "Lbl_RutCedente"
        Me.Lbl_RutCedente.Size = New System.Drawing.Size(532, 23)
        Me.Lbl_RutCedente.TabIndex = 6
        Me.Lbl_RutCedente.Text = "Rut Cedente"
        '
        'Lbl_DireccionCedente
        '
        Me.Lbl_DireccionCedente.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_DireccionCedente.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_DireccionCedente.ForeColor = System.Drawing.Color.Black
        Me.Lbl_DireccionCedente.Location = New System.Drawing.Point(88, 63)
        Me.Lbl_DireccionCedente.Name = "Lbl_DireccionCedente"
        Me.Lbl_DireccionCedente.Size = New System.Drawing.Size(532, 23)
        Me.Lbl_DireccionCedente.TabIndex = 5
        Me.Lbl_DireccionCedente.Text = "Dirección cedente"
        '
        'Lbl_RazonSocialCedente
        '
        Me.Lbl_RazonSocialCedente.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_RazonSocialCedente.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_RazonSocialCedente.ForeColor = System.Drawing.Color.Black
        Me.Lbl_RazonSocialCedente.Location = New System.Drawing.Point(88, 43)
        Me.Lbl_RazonSocialCedente.Name = "Lbl_RazonSocialCedente"
        Me.Lbl_RazonSocialCedente.Size = New System.Drawing.Size(532, 23)
        Me.Lbl_RazonSocialCedente.TabIndex = 4
        Me.Lbl_RazonSocialCedente.Text = "Razón social cedente"
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(3, 3)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(75, 23)
        Me.LabelX6.TabIndex = 3
        Me.LabelX6.Text = "Factura"
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(3, 63)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(75, 23)
        Me.LabelX5.TabIndex = 2
        Me.LabelX5.Text = "Dirección"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 43)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 23)
        Me.LabelX2.TabIndex = 1
        Me.LabelX2.Text = "Razón social"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 24)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 23)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "Rut"
        '
        'Dtp_FUltimoVencimiento
        '
        Me.Dtp_FUltimoVencimiento.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_FUltimoVencimiento.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_FUltimoVencimiento.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FUltimoVencimiento.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_FUltimoVencimiento.ButtonDropDown.Visible = True
        Me.Dtp_FUltimoVencimiento.ForeColor = System.Drawing.Color.Black
        Me.Dtp_FUltimoVencimiento.IsPopupCalendarOpen = False
        Me.Dtp_FUltimoVencimiento.Location = New System.Drawing.Point(289, 30)
        '
        '
        '
        Me.Dtp_FUltimoVencimiento.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FUltimoVencimiento.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FUltimoVencimiento.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_FUltimoVencimiento.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_FUltimoVencimiento.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_FUltimoVencimiento.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FUltimoVencimiento.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_FUltimoVencimiento.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_FUltimoVencimiento.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_FUltimoVencimiento.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_FUltimoVencimiento.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FUltimoVencimiento.MonthCalendar.DisplayMonth = New Date(2016, 7, 1, 0, 0, 0, 0)
        Me.Dtp_FUltimoVencimiento.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_FUltimoVencimiento.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_FUltimoVencimiento.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FUltimoVencimiento.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_FUltimoVencimiento.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FUltimoVencimiento.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_FUltimoVencimiento.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FUltimoVencimiento.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_FUltimoVencimiento.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_FUltimoVencimiento.Name = "Dtp_FUltimoVencimiento"
        Me.Dtp_FUltimoVencimiento.Size = New System.Drawing.Size(83, 22)
        Me.Dtp_FUltimoVencimiento.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_FUltimoVencimiento.TabIndex = 39
        Me.Dtp_FUltimoVencimiento.Value = New Date(2016, 7, 8, 16, 33, 0, 0)
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(190, 30)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(93, 23)
        Me.LabelX3.TabIndex = 38
        Me.LabelX3.Text = "Fecha vencimiento"
        '
        'Frm_Aec_CesionExt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(652, 252)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.GroupPanel3)
        Me.Controls.Add(Me.GroupPanel2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Aec_CesionExt"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REGISTRO DE DOCUMENTO CESIONADO DESDE FACTORING"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel3.ResumeLayout(False)
        CType(Me.Dtp_FechaCesion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.Dtp_FUltimoVencimiento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Public WithEvents Btn_Grabar_Cesion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Cesionario_Entidad As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Lbl_Documento As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_RutCedente As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_DireccionCedente As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_RazonSocialCedente As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dtp_FechaCesion As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Lbl_FEmision_Desde As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dtp_FUltimoVencimiento As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
End Class
