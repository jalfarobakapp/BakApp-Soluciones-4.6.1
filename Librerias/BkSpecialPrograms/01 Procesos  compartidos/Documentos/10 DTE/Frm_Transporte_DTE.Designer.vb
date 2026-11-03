<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Transporte_DTE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Transporte_DTE))
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_UltTransporte = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_RUTChofer = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Chofer = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_CiudadDest = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_DirDest = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Patente = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Lbl_CodRef = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_CmnaDest = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_RUTTrans = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Line1 = New DevComponents.DotNetBar.Controls.Line()
        Me.Txt_PatenteCarro = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.Line2 = New DevComponents.DotNetBar.Controls.Line()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_FchSalida = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Dtp_FchLlegada = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Dtp_HraSalida = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.Dtp_FchSalida, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_FchLlegada, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_HraSalida, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar, Me.Btn_UltTransporte})
        Me.Bar1.Location = New System.Drawing.Point(0, 371)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(539, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 45
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
        Me.Btn_Grabar.Tooltip = "Grabar"
        '
        'Btn_UltTransporte
        '
        Me.Btn_UltTransporte.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_UltTransporte.ForeColor = System.Drawing.Color.Black
        Me.Btn_UltTransporte.Image = CType(resources.GetObject("Btn_UltTransporte.Image"), System.Drawing.Image)
        Me.Btn_UltTransporte.ImageAlt = CType(resources.GetObject("Btn_UltTransporte.ImageAlt"), System.Drawing.Image)
        Me.Btn_UltTransporte.Name = "Btn_UltTransporte"
        Me.Btn_UltTransporte.Tooltip = "Usar los datos del ultimo transporte"
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Dtp_HraSalida)
        Me.GroupPanel2.Controls.Add(Me.Dtp_FchLlegada)
        Me.GroupPanel2.Controls.Add(Me.Dtp_FchSalida)
        Me.GroupPanel2.Controls.Add(Me.LabelX13)
        Me.GroupPanel2.Controls.Add(Me.LabelX12)
        Me.GroupPanel2.Controls.Add(Me.LabelX11)
        Me.GroupPanel2.Controls.Add(Me.Txt_PatenteCarro)
        Me.GroupPanel2.Controls.Add(Me.LabelX10)
        Me.GroupPanel2.Controls.Add(Me.LabelX9)
        Me.GroupPanel2.Controls.Add(Me.LabelX8)
        Me.GroupPanel2.Controls.Add(Me.LabelX7)
        Me.GroupPanel2.Controls.Add(Me.Txt_RUTChofer)
        Me.GroupPanel2.Controls.Add(Me.Txt_Chofer)
        Me.GroupPanel2.Controls.Add(Me.LabelX6)
        Me.GroupPanel2.Controls.Add(Me.Txt_CiudadDest)
        Me.GroupPanel2.Controls.Add(Me.LabelX5)
        Me.GroupPanel2.Controls.Add(Me.Txt_DirDest)
        Me.GroupPanel2.Controls.Add(Me.Txt_Patente)
        Me.GroupPanel2.Controls.Add(Me.Lbl_CodRef)
        Me.GroupPanel2.Controls.Add(Me.LabelX4)
        Me.GroupPanel2.Controls.Add(Me.LabelX1)
        Me.GroupPanel2.Controls.Add(Me.Txt_CmnaDest)
        Me.GroupPanel2.Controls.Add(Me.LabelX2)
        Me.GroupPanel2.Controls.Add(Me.LabelX3)
        Me.GroupPanel2.Controls.Add(Me.Txt_RUTTrans)
        Me.GroupPanel2.Controls.Add(Me.Line2)
        Me.GroupPanel2.Controls.Add(Me.Line1)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(12, 6)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(516, 352)
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
        Me.GroupPanel2.TabIndex = 46
        '
        'LabelX9
        '
        Me.LabelX9.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.ForeColor = System.Drawing.Color.Black
        Me.LabelX9.Location = New System.Drawing.Point(189, 56)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(219, 23)
        Me.LabelX9.TabIndex = 51
        Me.LabelX9.Text = "(Sin puntos y con guión)"
        '
        'LabelX8
        '
        Me.LabelX8.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.ForeColor = System.Drawing.Color.Black
        Me.LabelX8.Location = New System.Drawing.Point(189, 31)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(219, 23)
        Me.LabelX8.TabIndex = 50
        Me.LabelX8.Text = "(Sin puntos y con guión)"
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.ForeColor = System.Drawing.Color.Black
        Me.LabelX7.Location = New System.Drawing.Point(6, 59)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(89, 23)
        Me.LabelX7.TabIndex = 49
        Me.LabelX7.Text = "Rut Chofer"
        '
        'Txt_RUTChofer
        '
        Me.Txt_RUTChofer.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_RUTChofer.Border.Class = "TextBoxBorder"
        Me.Txt_RUTChofer.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_RUTChofer.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_RUTChofer.ForeColor = System.Drawing.Color.Black
        Me.Txt_RUTChofer.Location = New System.Drawing.Point(98, 59)
        Me.Txt_RUTChofer.MaxLength = 10
        Me.Txt_RUTChofer.Name = "Txt_RUTChofer"
        Me.Txt_RUTChofer.PreventEnterBeep = True
        Me.Txt_RUTChofer.Size = New System.Drawing.Size(85, 22)
        Me.Txt_RUTChofer.TabIndex = 3
        '
        'Txt_Chofer
        '
        Me.Txt_Chofer.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Chofer.Border.Class = "TextBoxBorder"
        Me.Txt_Chofer.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Chofer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Chofer.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Chofer.ForeColor = System.Drawing.Color.Black
        Me.Txt_Chofer.Location = New System.Drawing.Point(98, 87)
        Me.Txt_Chofer.MaxLength = 30
        Me.Txt_Chofer.Name = "Txt_Chofer"
        Me.Txt_Chofer.PreventEnterBeep = True
        Me.Txt_Chofer.Size = New System.Drawing.Size(399, 22)
        Me.Txt_Chofer.TabIndex = 4
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(6, 127)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(62, 23)
        Me.LabelX6.TabIndex = 45
        Me.LabelX6.Text = "Destino"
        '
        'Txt_CiudadDest
        '
        Me.Txt_CiudadDest.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_CiudadDest.Border.Class = "TextBoxBorder"
        Me.Txt_CiudadDest.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_CiudadDest.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_CiudadDest.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_CiudadDest.ForeColor = System.Drawing.Color.Black
        Me.Txt_CiudadDest.Location = New System.Drawing.Point(98, 210)
        Me.Txt_CiudadDest.MaxLength = 20
        Me.Txt_CiudadDest.Name = "Txt_CiudadDest"
        Me.Txt_CiudadDest.PreventEnterBeep = True
        Me.Txt_CiudadDest.Size = New System.Drawing.Size(194, 22)
        Me.Txt_CiudadDest.TabIndex = 7
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(6, 209)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(89, 23)
        Me.LabelX5.TabIndex = 43
        Me.LabelX5.Text = "Ciudad"
        '
        'Txt_DirDest
        '
        Me.Txt_DirDest.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_DirDest.Border.Class = "TextBoxBorder"
        Me.Txt_DirDest.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_DirDest.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_DirDest.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_DirDest.ForeColor = System.Drawing.Color.Black
        Me.Txt_DirDest.Location = New System.Drawing.Point(98, 153)
        Me.Txt_DirDest.MaxLength = 70
        Me.Txt_DirDest.Name = "Txt_DirDest"
        Me.Txt_DirDest.PreventEnterBeep = True
        Me.Txt_DirDest.Size = New System.Drawing.Size(399, 22)
        Me.Txt_DirDest.TabIndex = 5
        '
        'Txt_Patente
        '
        Me.Txt_Patente.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Patente.Border.Class = "TextBoxBorder"
        Me.Txt_Patente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Patente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Patente.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Patente.ForeColor = System.Drawing.Color.Black
        Me.Txt_Patente.Location = New System.Drawing.Point(98, 5)
        Me.Txt_Patente.MaxLength = 8
        Me.Txt_Patente.Name = "Txt_Patente"
        Me.Txt_Patente.PreventEnterBeep = True
        Me.Txt_Patente.Size = New System.Drawing.Size(85, 22)
        Me.Txt_Patente.TabIndex = 0
        '
        'Lbl_CodRef
        '
        Me.Lbl_CodRef.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_CodRef.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_CodRef.ForeColor = System.Drawing.Color.Black
        Me.Lbl_CodRef.Location = New System.Drawing.Point(6, 153)
        Me.Lbl_CodRef.Name = "Lbl_CodRef"
        Me.Lbl_CodRef.Size = New System.Drawing.Size(89, 23)
        Me.Lbl_CodRef.TabIndex = 40
        Me.Lbl_CodRef.Text = "Dirección"
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(6, 84)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(89, 23)
        Me.LabelX4.TabIndex = 38
        Me.LabelX4.Text = "Chofer"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(6, 5)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(89, 23)
        Me.LabelX1.TabIndex = 5
        Me.LabelX1.Text = "Patente"
        '
        'Txt_CmnaDest
        '
        Me.Txt_CmnaDest.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_CmnaDest.Border.Class = "TextBoxBorder"
        Me.Txt_CmnaDest.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_CmnaDest.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_CmnaDest.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_CmnaDest.ForeColor = System.Drawing.Color.Black
        Me.Txt_CmnaDest.Location = New System.Drawing.Point(98, 182)
        Me.Txt_CmnaDest.MaxLength = 20
        Me.Txt_CmnaDest.Name = "Txt_CmnaDest"
        Me.Txt_CmnaDest.PreventEnterBeep = True
        Me.Txt_CmnaDest.Size = New System.Drawing.Size(194, 22)
        Me.Txt_CmnaDest.TabIndex = 6
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(6, 31)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(89, 23)
        Me.LabelX2.TabIndex = 0
        Me.LabelX2.Text = "Rut transportista"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(6, 182)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(89, 23)
        Me.LabelX3.TabIndex = 2
        Me.LabelX3.Text = "Comuna"
        '
        'Txt_RUTTrans
        '
        Me.Txt_RUTTrans.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_RUTTrans.Border.Class = "TextBoxBorder"
        Me.Txt_RUTTrans.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_RUTTrans.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_RUTTrans.ForeColor = System.Drawing.Color.Black
        Me.Txt_RUTTrans.Location = New System.Drawing.Point(98, 31)
        Me.Txt_RUTTrans.MaxLength = 10
        Me.Txt_RUTTrans.Name = "Txt_RUTTrans"
        Me.Txt_RUTTrans.PreventEnterBeep = True
        Me.Txt_RUTTrans.Size = New System.Drawing.Size(85, 22)
        Me.Txt_RUTTrans.TabIndex = 2
        '
        'Line1
        '
        Me.Line1.BackColor = System.Drawing.Color.Transparent
        Me.Line1.ForeColor = System.Drawing.Color.Black
        Me.Line1.Location = New System.Drawing.Point(6, 113)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(491, 23)
        Me.Line1.TabIndex = 47
        Me.Line1.Text = "Line1"
        '
        'Txt_PatenteCarro
        '
        Me.Txt_PatenteCarro.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_PatenteCarro.Border.Class = "TextBoxBorder"
        Me.Txt_PatenteCarro.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_PatenteCarro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_PatenteCarro.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_PatenteCarro.ForeColor = System.Drawing.Color.Black
        Me.Txt_PatenteCarro.Location = New System.Drawing.Point(281, 5)
        Me.Txt_PatenteCarro.MaxLength = 8
        Me.Txt_PatenteCarro.Name = "Txt_PatenteCarro"
        Me.Txt_PatenteCarro.PreventEnterBeep = True
        Me.Txt_PatenteCarro.Size = New System.Drawing.Size(85, 22)
        Me.Txt_PatenteCarro.TabIndex = 1
        '
        'LabelX10
        '
        Me.LabelX10.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.ForeColor = System.Drawing.Color.Black
        Me.LabelX10.Location = New System.Drawing.Point(189, 5)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(89, 23)
        Me.LabelX10.TabIndex = 53
        Me.LabelX10.Text = "Patente carro"
        '
        'Line2
        '
        Me.Line2.BackColor = System.Drawing.Color.Transparent
        Me.Line2.ForeColor = System.Drawing.Color.Black
        Me.Line2.Location = New System.Drawing.Point(6, 230)
        Me.Line2.Name = "Line2"
        Me.Line2.Size = New System.Drawing.Size(491, 23)
        Me.Line2.TabIndex = 54
        Me.Line2.Text = "Line2"
        '
        'LabelX11
        '
        Me.LabelX11.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX11.ForeColor = System.Drawing.Color.Black
        Me.LabelX11.Location = New System.Drawing.Point(6, 259)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(89, 23)
        Me.LabelX11.TabIndex = 55
        Me.LabelX11.Text = "Fecha salida"
        '
        'LabelX12
        '
        Me.LabelX12.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX12.ForeColor = System.Drawing.Color.Black
        Me.LabelX12.Location = New System.Drawing.Point(6, 288)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(89, 23)
        Me.LabelX12.TabIndex = 56
        Me.LabelX12.Text = "Hora salida"
        '
        'LabelX13
        '
        Me.LabelX13.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX13.ForeColor = System.Drawing.Color.Black
        Me.LabelX13.Location = New System.Drawing.Point(6, 317)
        Me.LabelX13.Name = "LabelX13"
        Me.LabelX13.Size = New System.Drawing.Size(89, 23)
        Me.LabelX13.TabIndex = 57
        Me.LabelX13.Text = "Fecha llegada"
        '
        'Dtp_FchSalida
        '
        '
        '
        '
        Me.Dtp_FchSalida.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_FchSalida.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FchSalida.ButtonClear.Visible = True
        Me.Dtp_FchSalida.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_FchSalida.ButtonDropDown.Visible = True
        Me.Dtp_FchSalida.IsPopupCalendarOpen = False
        Me.Dtp_FchSalida.Location = New System.Drawing.Point(98, 260)
        '
        '
        '
        Me.Dtp_FchSalida.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FchSalida.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FchSalida.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_FchSalida.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_FchSalida.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_FchSalida.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FchSalida.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_FchSalida.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_FchSalida.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_FchSalida.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_FchSalida.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FchSalida.MonthCalendar.DisplayMonth = New Date(2026, 11, 1, 0, 0, 0, 0)
        Me.Dtp_FchSalida.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_FchSalida.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_FchSalida.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FchSalida.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_FchSalida.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FchSalida.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_FchSalida.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FchSalida.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_FchSalida.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_FchSalida.Name = "Dtp_FchSalida"
        Me.Dtp_FchSalida.Size = New System.Drawing.Size(75, 22)
        Me.Dtp_FchSalida.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_FchSalida.TabIndex = 58
        '
        'Dtp_FchLlegada
        '
        '
        '
        '
        Me.Dtp_FchLlegada.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_FchLlegada.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FchLlegada.ButtonClear.Visible = True
        Me.Dtp_FchLlegada.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_FchLlegada.ButtonDropDown.Visible = True
        Me.Dtp_FchLlegada.IsPopupCalendarOpen = False
        Me.Dtp_FchLlegada.Location = New System.Drawing.Point(98, 317)
        '
        '
        '
        Me.Dtp_FchLlegada.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FchLlegada.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FchLlegada.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_FchLlegada.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_FchLlegada.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_FchLlegada.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FchLlegada.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_FchLlegada.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_FchLlegada.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_FchLlegada.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_FchLlegada.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FchLlegada.MonthCalendar.DisplayMonth = New Date(2026, 11, 1, 0, 0, 0, 0)
        Me.Dtp_FchLlegada.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_FchLlegada.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_FchLlegada.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FchLlegada.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_FchLlegada.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FchLlegada.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_FchLlegada.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FchLlegada.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_FchLlegada.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_FchLlegada.Name = "Dtp_FchLlegada"
        Me.Dtp_FchLlegada.Size = New System.Drawing.Size(75, 22)
        Me.Dtp_FchLlegada.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_FchLlegada.TabIndex = 59
        '
        'Dtp_HraSalida
        '
        '
        '
        '
        Me.Dtp_HraSalida.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_HraSalida.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_HraSalida.ButtonClear.Visible = True
        Me.Dtp_HraSalida.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_HraSalida.ButtonDropDown.Visible = True
        Me.Dtp_HraSalida.Format = DevComponents.Editors.eDateTimePickerFormat.LongTime
        Me.Dtp_HraSalida.IsPopupCalendarOpen = False
        Me.Dtp_HraSalida.Location = New System.Drawing.Point(98, 289)
        '
        '
        '
        Me.Dtp_HraSalida.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_HraSalida.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_HraSalida.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_HraSalida.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_HraSalida.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_HraSalida.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_HraSalida.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_HraSalida.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_HraSalida.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_HraSalida.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_HraSalida.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_HraSalida.MonthCalendar.DisplayMonth = New Date(2026, 11, 1, 0, 0, 0, 0)
        Me.Dtp_HraSalida.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_HraSalida.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_HraSalida.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_HraSalida.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_HraSalida.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_HraSalida.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_HraSalida.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_HraSalida.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_HraSalida.MonthCalendar.Visible = False
        Me.Dtp_HraSalida.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_HraSalida.Name = "Dtp_HraSalida"
        Me.Dtp_HraSalida.Size = New System.Drawing.Size(75, 22)
        Me.Dtp_HraSalida.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_HraSalida.TabIndex = 60
        '
        'Frm_Transporte_DTE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(539, 412)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.GroupPanel2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Transporte_DTE"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Transporte"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.Dtp_FchSalida, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_FchLlegada, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_HraSalida, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Lbl_CodRef As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_CmnaDest As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_RUTTrans As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Patente As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_CiudadDest As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_DirDest As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Chofer As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Line1 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_RUTChofer As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Btn_UltTransporte As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_PatenteCarro As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dtp_HraSalida As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Dtp_FchLlegada As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Dtp_FchSalida As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Line2 As DevComponents.DotNetBar.Controls.Line
End Class
