<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Dte_Configuracion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Dte_Configuracion))
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Importar_Datos_Random = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Txt_FchResol = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Btn_Buscar_Cn = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_Cn = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Empresa = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_NroResol = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_RutReceptor = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_RutEnvia = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_RutEmisor = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Buscar_Formato_BLV = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Buscar_Formato_FCV = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Buscar_Formato_NCV = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Buscar_Correo = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_NombreFormato_PDF_BLV = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_NombreFormato_PDF_NCV = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_NombreFormato_PDF_FCV = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Id_Correo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Btn_Quitar_Formato_BLV = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Quitar_Formato_NCV = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Quitar_Formato_FCV = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.MStb_Barra = New DevComponents.DotNetBar.Metro.MetroStatusBar()
        Me.Lbl_Etiqueta = New DevComponents.DotNetBar.LabelItem()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.GroupPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar, Me.Btn_Importar_Datos_Random})
        Me.Bar1.Location = New System.Drawing.Point(0, 439)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(510, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 42
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
        'Btn_Importar_Datos_Random
        '
        Me.Btn_Importar_Datos_Random.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Importar_Datos_Random.ForeColor = System.Drawing.Color.Black
        Me.Btn_Importar_Datos_Random.Image = CType(resources.GetObject("Btn_Importar_Datos_Random.Image"), System.Drawing.Image)
        Me.Btn_Importar_Datos_Random.ImageAlt = CType(resources.GetObject("Btn_Importar_Datos_Random.ImageAlt"), System.Drawing.Image)
        Me.Btn_Importar_Datos_Random.Name = "Btn_Importar_Datos_Random"
        Me.Btn_Importar_Datos_Random.Tooltip = "Importar datos desde Random..."
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Txt_FchResol)
        Me.GroupPanel1.Controls.Add(Me.Btn_Buscar_Cn)
        Me.GroupPanel1.Controls.Add(Me.Txt_Cn)
        Me.GroupPanel1.Controls.Add(Me.LabelX1)
        Me.GroupPanel1.Controls.Add(Me.Txt_Empresa)
        Me.GroupPanel1.Controls.Add(Me.LabelX12)
        Me.GroupPanel1.Controls.Add(Me.Txt_NroResol)
        Me.GroupPanel1.Controls.Add(Me.LabelX7)
        Me.GroupPanel1.Controls.Add(Me.LabelX6)
        Me.GroupPanel1.Controls.Add(Me.Txt_RutReceptor)
        Me.GroupPanel1.Controls.Add(Me.LabelX5)
        Me.GroupPanel1.Controls.Add(Me.Txt_RutEnvia)
        Me.GroupPanel1.Controls.Add(Me.LabelX4)
        Me.GroupPanel1.Controls.Add(Me.Txt_RutEmisor)
        Me.GroupPanel1.Controls.Add(Me.LabelX3)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(486, 236)
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
        Me.GroupPanel1.TabIndex = 43
        Me.GroupPanel1.Text = "Configuración de empresa"
        '
        'Txt_FchResol
        '
        Me.Txt_FchResol.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_FchResol.Border.Class = "TextBoxBorder"
        Me.Txt_FchResol.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_FchResol.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_FchResol.ForeColor = System.Drawing.Color.Black
        Me.Txt_FchResol.Location = New System.Drawing.Point(95, 120)
        Me.Txt_FchResol.Name = "Txt_FchResol"
        Me.Txt_FchResol.PreventEnterBeep = True
        Me.Txt_FchResol.Size = New System.Drawing.Size(128, 22)
        Me.Txt_FchResol.TabIndex = 68
        Me.Txt_FchResol.Tag = "FchResol"
        Me.Txt_FchResol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Btn_Buscar_Cn
        '
        Me.Btn_Buscar_Cn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Buscar_Cn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Buscar_Cn.Image = CType(resources.GetObject("Btn_Buscar_Cn.Image"), System.Drawing.Image)
        Me.Btn_Buscar_Cn.ImageAlt = CType(resources.GetObject("Btn_Buscar_Cn.ImageAlt"), System.Drawing.Image)
        Me.Btn_Buscar_Cn.Location = New System.Drawing.Point(448, 179)
        Me.Btn_Buscar_Cn.Name = "Btn_Buscar_Cn"
        Me.Btn_Buscar_Cn.Size = New System.Drawing.Size(29, 22)
        Me.Btn_Buscar_Cn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Buscar_Cn.TabIndex = 61
        Me.Btn_Buscar_Cn.Tooltip = "Buscar certificado"
        Me.Btn_Buscar_Cn.Visible = False
        '
        'Txt_Cn
        '
        Me.Txt_Cn.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Cn.Border.Class = "TextBoxBorder"
        Me.Txt_Cn.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Cn.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Cn.ForeColor = System.Drawing.Color.Black
        Me.Txt_Cn.Location = New System.Drawing.Point(95, 179)
        Me.Txt_Cn.Name = "Txt_Cn"
        Me.Txt_Cn.PreventEnterBeep = True
        Me.Txt_Cn.Size = New System.Drawing.Size(347, 22)
        Me.Txt_Cn.TabIndex = 52
        Me.Txt_Cn.Tag = "Cn"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 179)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(86, 23)
        Me.LabelX1.TabIndex = 51
        Me.LabelX1.Text = "Certificado"
        '
        'Txt_Empresa
        '
        Me.Txt_Empresa.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Empresa.Border.Class = "TextBoxBorder"
        Me.Txt_Empresa.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Empresa.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Empresa.ForeColor = System.Drawing.Color.Black
        Me.Txt_Empresa.Location = New System.Drawing.Point(95, 3)
        Me.Txt_Empresa.Name = "Txt_Empresa"
        Me.Txt_Empresa.PreventEnterBeep = True
        Me.Txt_Empresa.Size = New System.Drawing.Size(37, 22)
        Me.Txt_Empresa.TabIndex = 37
        Me.Txt_Empresa.Tag = "Empresa"
        Me.Txt_Empresa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelX12
        '
        Me.LabelX12.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX12.ForeColor = System.Drawing.Color.Black
        Me.LabelX12.Location = New System.Drawing.Point(3, 3)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(75, 23)
        Me.LabelX12.TabIndex = 36
        Me.LabelX12.Text = "Empresa"
        '
        'Txt_NroResol
        '
        Me.Txt_NroResol.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_NroResol.Border.Class = "TextBoxBorder"
        Me.Txt_NroResol.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_NroResol.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_NroResol.ForeColor = System.Drawing.Color.Black
        Me.Txt_NroResol.Location = New System.Drawing.Point(95, 149)
        Me.Txt_NroResol.Name = "Txt_NroResol"
        Me.Txt_NroResol.PreventEnterBeep = True
        Me.Txt_NroResol.Size = New System.Drawing.Size(128, 22)
        Me.Txt_NroResol.TabIndex = 42
        Me.Txt_NroResol.Tag = "NroResol"
        Me.Txt_NroResol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.ForeColor = System.Drawing.Color.Black
        Me.LabelX7.Location = New System.Drawing.Point(3, 150)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(99, 23)
        Me.LabelX7.TabIndex = 32
        Me.LabelX7.Text = "Nro. Resol"
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(3, 120)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(99, 23)
        Me.LabelX6.TabIndex = 31
        Me.LabelX6.Text = "Fecha resolusión"
        '
        'Txt_RutReceptor
        '
        Me.Txt_RutReceptor.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_RutReceptor.Border.Class = "TextBoxBorder"
        Me.Txt_RutReceptor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_RutReceptor.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_RutReceptor.ForeColor = System.Drawing.Color.Black
        Me.Txt_RutReceptor.Location = New System.Drawing.Point(95, 89)
        Me.Txt_RutReceptor.Name = "Txt_RutReceptor"
        Me.Txt_RutReceptor.PreventEnterBeep = True
        Me.Txt_RutReceptor.Size = New System.Drawing.Size(128, 22)
        Me.Txt_RutReceptor.TabIndex = 40
        Me.Txt_RutReceptor.Tag = "RutReceptor"
        Me.Txt_RutReceptor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(3, 90)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(75, 23)
        Me.LabelX5.TabIndex = 30
        Me.LabelX5.Text = "rut receptor"
        '
        'Txt_RutEnvia
        '
        Me.Txt_RutEnvia.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_RutEnvia.Border.Class = "TextBoxBorder"
        Me.Txt_RutEnvia.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_RutEnvia.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_RutEnvia.ForeColor = System.Drawing.Color.Black
        Me.Txt_RutEnvia.Location = New System.Drawing.Point(95, 60)
        Me.Txt_RutEnvia.Name = "Txt_RutEnvia"
        Me.Txt_RutEnvia.PreventEnterBeep = True
        Me.Txt_RutEnvia.Size = New System.Drawing.Size(128, 22)
        Me.Txt_RutEnvia.TabIndex = 39
        Me.Txt_RutEnvia.Tag = "RutEnvia"
        Me.Txt_RutEnvia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(3, 60)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(99, 23)
        Me.LabelX4.TabIndex = 29
        Me.LabelX4.Text = "Rut envia"
        '
        'Txt_RutEmisor
        '
        Me.Txt_RutEmisor.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_RutEmisor.Border.Class = "TextBoxBorder"
        Me.Txt_RutEmisor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_RutEmisor.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_RutEmisor.ForeColor = System.Drawing.Color.Black
        Me.Txt_RutEmisor.Location = New System.Drawing.Point(95, 31)
        Me.Txt_RutEmisor.Name = "Txt_RutEmisor"
        Me.Txt_RutEmisor.PreventEnterBeep = True
        Me.Txt_RutEmisor.Size = New System.Drawing.Size(128, 22)
        Me.Txt_RutEmisor.TabIndex = 38
        Me.Txt_RutEmisor.Tag = "RutEmisor"
        Me.Txt_RutEmisor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(3, 31)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(75, 23)
        Me.LabelX3.TabIndex = 28
        Me.LabelX3.Text = "Rut emisor"
        '
        'Btn_Buscar_Formato_BLV
        '
        Me.Btn_Buscar_Formato_BLV.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Buscar_Formato_BLV.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Buscar_Formato_BLV.Image = CType(resources.GetObject("Btn_Buscar_Formato_BLV.Image"), System.Drawing.Image)
        Me.Btn_Buscar_Formato_BLV.ImageAlt = CType(resources.GetObject("Btn_Buscar_Formato_BLV.ImageAlt"), System.Drawing.Image)
        Me.Btn_Buscar_Formato_BLV.Location = New System.Drawing.Point(413, 87)
        Me.Btn_Buscar_Formato_BLV.Name = "Btn_Buscar_Formato_BLV"
        Me.Btn_Buscar_Formato_BLV.Size = New System.Drawing.Size(29, 22)
        Me.Btn_Buscar_Formato_BLV.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Buscar_Formato_BLV.TabIndex = 65
        Me.Btn_Buscar_Formato_BLV.Tooltip = "Buscar certificado"
        '
        'Btn_Buscar_Formato_FCV
        '
        Me.Btn_Buscar_Formato_FCV.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Buscar_Formato_FCV.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Buscar_Formato_FCV.Image = CType(resources.GetObject("Btn_Buscar_Formato_FCV.Image"), System.Drawing.Image)
        Me.Btn_Buscar_Formato_FCV.ImageAlt = CType(resources.GetObject("Btn_Buscar_Formato_FCV.ImageAlt"), System.Drawing.Image)
        Me.Btn_Buscar_Formato_FCV.Location = New System.Drawing.Point(414, 31)
        Me.Btn_Buscar_Formato_FCV.Name = "Btn_Buscar_Formato_FCV"
        Me.Btn_Buscar_Formato_FCV.Size = New System.Drawing.Size(29, 22)
        Me.Btn_Buscar_Formato_FCV.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Buscar_Formato_FCV.TabIndex = 64
        Me.Btn_Buscar_Formato_FCV.Tooltip = "Buscar certificado"
        '
        'Btn_Buscar_Formato_NCV
        '
        Me.Btn_Buscar_Formato_NCV.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Buscar_Formato_NCV.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Buscar_Formato_NCV.Image = CType(resources.GetObject("Btn_Buscar_Formato_NCV.Image"), System.Drawing.Image)
        Me.Btn_Buscar_Formato_NCV.ImageAlt = CType(resources.GetObject("Btn_Buscar_Formato_NCV.ImageAlt"), System.Drawing.Image)
        Me.Btn_Buscar_Formato_NCV.Location = New System.Drawing.Point(413, 59)
        Me.Btn_Buscar_Formato_NCV.Name = "Btn_Buscar_Formato_NCV"
        Me.Btn_Buscar_Formato_NCV.Size = New System.Drawing.Size(29, 22)
        Me.Btn_Buscar_Formato_NCV.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Buscar_Formato_NCV.TabIndex = 63
        Me.Btn_Buscar_Formato_NCV.Tooltip = "Buscar certificado"
        '
        'Btn_Buscar_Correo
        '
        Me.Btn_Buscar_Correo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Buscar_Correo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Buscar_Correo.Image = CType(resources.GetObject("Btn_Buscar_Correo.Image"), System.Drawing.Image)
        Me.Btn_Buscar_Correo.ImageAlt = CType(resources.GetObject("Btn_Buscar_Correo.ImageAlt"), System.Drawing.Image)
        Me.Btn_Buscar_Correo.Location = New System.Drawing.Point(448, 3)
        Me.Btn_Buscar_Correo.Name = "Btn_Buscar_Correo"
        Me.Btn_Buscar_Correo.Size = New System.Drawing.Size(29, 22)
        Me.Btn_Buscar_Correo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Buscar_Correo.TabIndex = 62
        Me.Btn_Buscar_Correo.Tooltip = "Buscar certificado"
        '
        'Txt_NombreFormato_PDF_BLV
        '
        Me.Txt_NombreFormato_PDF_BLV.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_NombreFormato_PDF_BLV.Border.Class = "TextBoxBorder"
        Me.Txt_NombreFormato_PDF_BLV.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_NombreFormato_PDF_BLV.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_NombreFormato_PDF_BLV.Enabled = False
        Me.Txt_NombreFormato_PDF_BLV.ForeColor = System.Drawing.Color.Black
        Me.Txt_NombreFormato_PDF_BLV.Location = New System.Drawing.Point(95, 88)
        Me.Txt_NombreFormato_PDF_BLV.Name = "Txt_NombreFormato_PDF_BLV"
        Me.Txt_NombreFormato_PDF_BLV.PreventEnterBeep = True
        Me.Txt_NombreFormato_PDF_BLV.Size = New System.Drawing.Size(313, 22)
        Me.Txt_NombreFormato_PDF_BLV.TabIndex = 60
        Me.Txt_NombreFormato_PDF_BLV.Tag = "NombreFormato_PDF_BLV"
        '
        'LabelX10
        '
        Me.LabelX10.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.ForeColor = System.Drawing.Color.Black
        Me.LabelX10.Location = New System.Drawing.Point(3, 89)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(99, 23)
        Me.LabelX10.TabIndex = 59
        Me.LabelX10.Text = "Boleta"
        '
        'Txt_NombreFormato_PDF_NCV
        '
        Me.Txt_NombreFormato_PDF_NCV.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_NombreFormato_PDF_NCV.Border.Class = "TextBoxBorder"
        Me.Txt_NombreFormato_PDF_NCV.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_NombreFormato_PDF_NCV.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_NombreFormato_PDF_NCV.Enabled = False
        Me.Txt_NombreFormato_PDF_NCV.ForeColor = System.Drawing.Color.Black
        Me.Txt_NombreFormato_PDF_NCV.Location = New System.Drawing.Point(95, 60)
        Me.Txt_NombreFormato_PDF_NCV.Name = "Txt_NombreFormato_PDF_NCV"
        Me.Txt_NombreFormato_PDF_NCV.PreventEnterBeep = True
        Me.Txt_NombreFormato_PDF_NCV.Size = New System.Drawing.Size(313, 22)
        Me.Txt_NombreFormato_PDF_NCV.TabIndex = 58
        Me.Txt_NombreFormato_PDF_NCV.Tag = "NombreFormato_PDF_NCV"
        '
        'LabelX9
        '
        Me.LabelX9.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.ForeColor = System.Drawing.Color.Black
        Me.LabelX9.Location = New System.Drawing.Point(3, 61)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(86, 23)
        Me.LabelX9.TabIndex = 57
        Me.LabelX9.Text = "Nota de credito"
        '
        'Txt_NombreFormato_PDF_FCV
        '
        Me.Txt_NombreFormato_PDF_FCV.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_NombreFormato_PDF_FCV.Border.Class = "TextBoxBorder"
        Me.Txt_NombreFormato_PDF_FCV.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_NombreFormato_PDF_FCV.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_NombreFormato_PDF_FCV.Enabled = False
        Me.Txt_NombreFormato_PDF_FCV.ForeColor = System.Drawing.Color.Black
        Me.Txt_NombreFormato_PDF_FCV.Location = New System.Drawing.Point(95, 31)
        Me.Txt_NombreFormato_PDF_FCV.Name = "Txt_NombreFormato_PDF_FCV"
        Me.Txt_NombreFormato_PDF_FCV.PreventEnterBeep = True
        Me.Txt_NombreFormato_PDF_FCV.Size = New System.Drawing.Size(313, 22)
        Me.Txt_NombreFormato_PDF_FCV.TabIndex = 56
        Me.Txt_NombreFormato_PDF_FCV.Tag = "NombreFormato_PDF_FCV"
        '
        'LabelX8
        '
        Me.LabelX8.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.ForeColor = System.Drawing.Color.Black
        Me.LabelX8.Location = New System.Drawing.Point(3, 32)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(75, 23)
        Me.LabelX8.TabIndex = 55
        Me.LabelX8.Text = "Factura"
        '
        'Txt_Id_Correo
        '
        Me.Txt_Id_Correo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Id_Correo.Border.Class = "TextBoxBorder"
        Me.Txt_Id_Correo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Id_Correo.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Id_Correo.Enabled = False
        Me.Txt_Id_Correo.ForeColor = System.Drawing.Color.Black
        Me.Txt_Id_Correo.Location = New System.Drawing.Point(95, 3)
        Me.Txt_Id_Correo.Name = "Txt_Id_Correo"
        Me.Txt_Id_Correo.PreventEnterBeep = True
        Me.Txt_Id_Correo.Size = New System.Drawing.Size(313, 22)
        Me.Txt_Id_Correo.TabIndex = 54
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 3)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(86, 23)
        Me.LabelX2.TabIndex = 53
        Me.LabelX2.Text = "Correo"
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Btn_Quitar_Formato_BLV)
        Me.GroupPanel2.Controls.Add(Me.Btn_Quitar_Formato_NCV)
        Me.GroupPanel2.Controls.Add(Me.Btn_Quitar_Formato_FCV)
        Me.GroupPanel2.Controls.Add(Me.LabelX11)
        Me.GroupPanel2.Controls.Add(Me.LabelX2)
        Me.GroupPanel2.Controls.Add(Me.Btn_Buscar_Formato_BLV)
        Me.GroupPanel2.Controls.Add(Me.Txt_Id_Correo)
        Me.GroupPanel2.Controls.Add(Me.Btn_Buscar_Formato_FCV)
        Me.GroupPanel2.Controls.Add(Me.LabelX8)
        Me.GroupPanel2.Controls.Add(Me.Btn_Buscar_Formato_NCV)
        Me.GroupPanel2.Controls.Add(Me.Txt_NombreFormato_PDF_FCV)
        Me.GroupPanel2.Controls.Add(Me.Btn_Buscar_Correo)
        Me.GroupPanel2.Controls.Add(Me.LabelX9)
        Me.GroupPanel2.Controls.Add(Me.Txt_NombreFormato_PDF_NCV)
        Me.GroupPanel2.Controls.Add(Me.Txt_NombreFormato_PDF_BLV)
        Me.GroupPanel2.Controls.Add(Me.LabelX10)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(12, 254)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(486, 182)
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
        Me.GroupPanel2.TabIndex = 44
        Me.GroupPanel2.Text = "Configuración de salida para envio de correos y documentos adjuntos"
        '
        'Btn_Quitar_Formato_BLV
        '
        Me.Btn_Quitar_Formato_BLV.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Quitar_Formato_BLV.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Quitar_Formato_BLV.Image = CType(resources.GetObject("Btn_Quitar_Formato_BLV.Image"), System.Drawing.Image)
        Me.Btn_Quitar_Formato_BLV.ImageAlt = CType(resources.GetObject("Btn_Quitar_Formato_BLV.ImageAlt"), System.Drawing.Image)
        Me.Btn_Quitar_Formato_BLV.Location = New System.Drawing.Point(448, 87)
        Me.Btn_Quitar_Formato_BLV.Name = "Btn_Quitar_Formato_BLV"
        Me.Btn_Quitar_Formato_BLV.Size = New System.Drawing.Size(29, 22)
        Me.Btn_Quitar_Formato_BLV.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Quitar_Formato_BLV.TabIndex = 69
        Me.Btn_Quitar_Formato_BLV.Tooltip = "Buscar certificado"
        '
        'Btn_Quitar_Formato_NCV
        '
        Me.Btn_Quitar_Formato_NCV.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Quitar_Formato_NCV.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Quitar_Formato_NCV.Image = CType(resources.GetObject("Btn_Quitar_Formato_NCV.Image"), System.Drawing.Image)
        Me.Btn_Quitar_Formato_NCV.ImageAlt = CType(resources.GetObject("Btn_Quitar_Formato_NCV.ImageAlt"), System.Drawing.Image)
        Me.Btn_Quitar_Formato_NCV.Location = New System.Drawing.Point(448, 59)
        Me.Btn_Quitar_Formato_NCV.Name = "Btn_Quitar_Formato_NCV"
        Me.Btn_Quitar_Formato_NCV.Size = New System.Drawing.Size(29, 22)
        Me.Btn_Quitar_Formato_NCV.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Quitar_Formato_NCV.TabIndex = 68
        Me.Btn_Quitar_Formato_NCV.Tooltip = "Buscar certificado"
        '
        'Btn_Quitar_Formato_FCV
        '
        Me.Btn_Quitar_Formato_FCV.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Quitar_Formato_FCV.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Quitar_Formato_FCV.Image = CType(resources.GetObject("Btn_Quitar_Formato_FCV.Image"), System.Drawing.Image)
        Me.Btn_Quitar_Formato_FCV.ImageAlt = CType(resources.GetObject("Btn_Quitar_Formato_FCV.ImageAlt"), System.Drawing.Image)
        Me.Btn_Quitar_Formato_FCV.Location = New System.Drawing.Point(448, 31)
        Me.Btn_Quitar_Formato_FCV.Name = "Btn_Quitar_Formato_FCV"
        Me.Btn_Quitar_Formato_FCV.Size = New System.Drawing.Size(29, 22)
        Me.Btn_Quitar_Formato_FCV.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Quitar_Formato_FCV.TabIndex = 67
        Me.Btn_Quitar_Formato_FCV.Tooltip = "Buscar certificado"
        '
        'LabelX11
        '
        Me.LabelX11.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX11.ForeColor = System.Drawing.Color.Black
        Me.LabelX11.Location = New System.Drawing.Point(3, 118)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(474, 38)
        Me.LabelX11.TabIndex = 66
        Me.LabelX11.Text = "Si no se selecciona ningun formato el sistema igualmente enviara el correo, pero " &
    "no adjuntara<br/> un archivo PDF, solamente se ira el archivo XML."
        '
        'MStb_Barra
        '
        Me.MStb_Barra.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.MStb_Barra.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MStb_Barra.ContainerControlProcessDialogKey = True
        Me.MStb_Barra.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.MStb_Barra.DragDropSupport = True
        Me.MStb_Barra.Font = New System.Drawing.Font("Segoe UI", 10.25!, System.Drawing.FontStyle.Bold)
        Me.MStb_Barra.ForeColor = System.Drawing.Color.Black
        Me.MStb_Barra.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Lbl_Etiqueta})
        Me.MStb_Barra.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MStb_Barra.Location = New System.Drawing.Point(0, 480)
        Me.MStb_Barra.Name = "MStb_Barra"
        Me.MStb_Barra.Size = New System.Drawing.Size(510, 22)
        Me.MStb_Barra.TabIndex = 46
        Me.MStb_Barra.Text = "MetroStatusBar1"
        '
        'Lbl_Etiqueta
        '
        Me.Lbl_Etiqueta.Name = "Lbl_Etiqueta"
        Me.Lbl_Etiqueta.Text = "Ambiente de producción"
        '
        'Frm_Dte_Configuracion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(510, 502)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.MStb_Barra)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Dte_Configuracion"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuración Sis. Factura electronica"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Txt_Empresa As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_NroResol As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_RutReceptor As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_RutEnvia As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_RutEmisor As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Cn As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Id_Correo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Buscar_Formato_BLV As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Buscar_Formato_FCV As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Buscar_Formato_NCV As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Buscar_Correo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Buscar_Cn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Txt_NombreFormato_PDF_BLV As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_NombreFormato_PDF_NCV As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_NombreFormato_PDF_FCV As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_FchResol As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Btn_Quitar_Formato_FCV As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Quitar_Formato_BLV As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Quitar_Formato_NCV As DevComponents.DotNetBar.ButtonX
    Friend WithEvents MStb_Barra As DevComponents.DotNetBar.Metro.MetroStatusBar
    Friend WithEvents Lbl_Etiqueta As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Importar_Datos_Random As DevComponents.DotNetBar.ButtonItem
End Class
