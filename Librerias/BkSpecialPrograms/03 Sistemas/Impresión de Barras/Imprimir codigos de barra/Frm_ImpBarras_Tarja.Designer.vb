<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ImpBarras_Tarja
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ImpBarras_Tarja))
        Me.Grupo_Puerto = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.CmbPuerto = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Btn_ConfPuertoXEtiquetaXEquipo = New DevComponents.DotNetBar.ButtonX()
        Me.Cmbetiquetas = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.BtnImprimirEtiqueta = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnLimpiar = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnConfiguracion = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Conf_PuertoEtiqueta = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Conf_ConfEstacion = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Txt_Nro_CPT = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Observaciones = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX14 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Planta = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Turno = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Analista = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX17 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_CodAlternativo_Pallet = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_NroLote = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Tipo = New DevComponents.DotNetBar.LabelX()
        Me.Grupo_Puerto.SuspendLayout()
        Me.GroupPanel3.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Grupo_Puerto
        '
        Me.Grupo_Puerto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Grupo_Puerto.BackColor = System.Drawing.Color.White
        Me.Grupo_Puerto.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Puerto.Controls.Add(Me.CmbPuerto)
        Me.Grupo_Puerto.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Puerto.Location = New System.Drawing.Point(657, 261)
        Me.Grupo_Puerto.Name = "Grupo_Puerto"
        Me.Grupo_Puerto.Size = New System.Drawing.Size(157, 59)
        '
        '
        '
        Me.Grupo_Puerto.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Puerto.Style.BackColorGradientAngle = 90
        Me.Grupo_Puerto.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Puerto.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Puerto.Style.BorderBottomWidth = 1
        Me.Grupo_Puerto.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Puerto.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Puerto.Style.BorderLeftWidth = 1
        Me.Grupo_Puerto.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Puerto.Style.BorderRightWidth = 1
        Me.Grupo_Puerto.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Puerto.Style.BorderTopWidth = 1
        Me.Grupo_Puerto.Style.CornerDiameter = 4
        Me.Grupo_Puerto.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Puerto.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Puerto.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Puerto.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Puerto.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Puerto.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Puerto.TabIndex = 81
        Me.Grupo_Puerto.Text = "Puerto salida"
        '
        'CmbPuerto
        '
        Me.CmbPuerto.DisplayMember = "Text"
        Me.CmbPuerto.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbPuerto.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.CmbPuerto.ForeColor = System.Drawing.Color.Black
        Me.CmbPuerto.FormattingEnabled = True
        Me.CmbPuerto.ItemHeight = 16
        Me.CmbPuerto.Location = New System.Drawing.Point(1, 5)
        Me.CmbPuerto.Name = "CmbPuerto"
        Me.CmbPuerto.Size = New System.Drawing.Size(147, 22)
        Me.CmbPuerto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CmbPuerto.TabIndex = 0
        '
        'GroupPanel3
        '
        Me.GroupPanel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupPanel3.BackColor = System.Drawing.Color.White
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.Btn_ConfPuertoXEtiquetaXEquipo)
        Me.GroupPanel3.Controls.Add(Me.Cmbetiquetas)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Location = New System.Drawing.Point(12, 261)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(630, 59)
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
        Me.GroupPanel3.TabIndex = 80
        Me.GroupPanel3.Text = "Etiqueta"
        '
        'Btn_ConfPuertoXEtiquetaXEquipo
        '
        Me.Btn_ConfPuertoXEtiquetaXEquipo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_ConfPuertoXEtiquetaXEquipo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_ConfPuertoXEtiquetaXEquipo.Image = CType(resources.GetObject("Btn_ConfPuertoXEtiquetaXEquipo.Image"), System.Drawing.Image)
        Me.Btn_ConfPuertoXEtiquetaXEquipo.ImageAlt = CType(resources.GetObject("Btn_ConfPuertoXEtiquetaXEquipo.ImageAlt"), System.Drawing.Image)
        Me.Btn_ConfPuertoXEtiquetaXEquipo.Location = New System.Drawing.Point(595, 5)
        Me.Btn_ConfPuertoXEtiquetaXEquipo.Name = "Btn_ConfPuertoXEtiquetaXEquipo"
        Me.Btn_ConfPuertoXEtiquetaXEquipo.Size = New System.Drawing.Size(26, 22)
        Me.Btn_ConfPuertoXEtiquetaXEquipo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_ConfPuertoXEtiquetaXEquipo.TabIndex = 80
        Me.Btn_ConfPuertoXEtiquetaXEquipo.Tooltip = "Seleccionar puerto de salida según etiqueta por equipo"
        '
        'Cmbetiquetas
        '
        Me.Cmbetiquetas.DisplayMember = "Text"
        Me.Cmbetiquetas.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmbetiquetas.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmbetiquetas.ForeColor = System.Drawing.Color.Black
        Me.Cmbetiquetas.FormattingEnabled = True
        Me.Cmbetiquetas.ItemHeight = 16
        Me.Cmbetiquetas.Location = New System.Drawing.Point(3, 5)
        Me.Cmbetiquetas.Name = "Cmbetiquetas"
        Me.Cmbetiquetas.Size = New System.Drawing.Size(586, 22)
        Me.Cmbetiquetas.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Cmbetiquetas.TabIndex = 74
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnImprimirEtiqueta, Me.BtnLimpiar, Me.BtnSalir, Me.BtnConfiguracion})
        Me.Bar1.Location = New System.Drawing.Point(0, 326)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(823, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010
        Me.Bar1.TabIndex = 79
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnImprimirEtiqueta
        '
        Me.BtnImprimirEtiqueta.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnImprimirEtiqueta.ForeColor = System.Drawing.Color.Black
        Me.BtnImprimirEtiqueta.Image = CType(resources.GetObject("BtnImprimirEtiqueta.Image"), System.Drawing.Image)
        Me.BtnImprimirEtiqueta.ImageAlt = CType(resources.GetObject("BtnImprimirEtiqueta.ImageAlt"), System.Drawing.Image)
        Me.BtnImprimirEtiqueta.Name = "BtnImprimirEtiqueta"
        Me.BtnImprimirEtiqueta.Text = "Imprimir etiquetas"
        '
        'BtnLimpiar
        '
        Me.BtnLimpiar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnLimpiar.ForeColor = System.Drawing.Color.Black
        Me.BtnLimpiar.Image = CType(resources.GetObject("BtnLimpiar.Image"), System.Drawing.Image)
        Me.BtnLimpiar.ImageAlt = CType(resources.GetObject("BtnLimpiar.ImageAlt"), System.Drawing.Image)
        Me.BtnLimpiar.Name = "BtnLimpiar"
        Me.BtnLimpiar.Tooltip = "Limpiar listado"
        '
        'BtnSalir
        '
        Me.BtnSalir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnSalir.ForeColor = System.Drawing.Color.Black
        Me.BtnSalir.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Tooltip = "Salir"
        '
        'BtnConfiguracion
        '
        Me.BtnConfiguracion.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnConfiguracion.ForeColor = System.Drawing.Color.Black
        Me.BtnConfiguracion.Image = CType(resources.GetObject("BtnConfiguracion.Image"), System.Drawing.Image)
        Me.BtnConfiguracion.ImageAlt = CType(resources.GetObject("BtnConfiguracion.ImageAlt"), System.Drawing.Image)
        Me.BtnConfiguracion.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnConfiguracion.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnConfiguracion.Name = "BtnConfiguracion"
        Me.BtnConfiguracion.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Conf_PuertoEtiqueta, Me.Btn_Conf_ConfEstacion})
        Me.BtnConfiguracion.Tooltip = "Configuración de sistema"
        '
        'Btn_Conf_PuertoEtiqueta
        '
        Me.Btn_Conf_PuertoEtiqueta.Image = CType(resources.GetObject("Btn_Conf_PuertoEtiqueta.Image"), System.Drawing.Image)
        Me.Btn_Conf_PuertoEtiqueta.ImageAlt = CType(resources.GetObject("Btn_Conf_PuertoEtiqueta.ImageAlt"), System.Drawing.Image)
        Me.Btn_Conf_PuertoEtiqueta.Name = "Btn_Conf_PuertoEtiqueta"
        Me.Btn_Conf_PuertoEtiqueta.Text = "Configuración puerto y etiqueta por defecto"
        '
        'Btn_Conf_ConfEstacion
        '
        Me.Btn_Conf_ConfEstacion.Image = CType(resources.GetObject("Btn_Conf_ConfEstacion.Image"), System.Drawing.Image)
        Me.Btn_Conf_ConfEstacion.ImageAlt = CType(resources.GetObject("Btn_Conf_ConfEstacion.ImageAlt"), System.Drawing.Image)
        Me.Btn_Conf_ConfEstacion.Name = "Btn_Conf_ConfEstacion"
        Me.Btn_Conf_ConfEstacion.Text = "Configuración de estación local"
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Txt_Nro_CPT)
        Me.GroupPanel2.Controls.Add(Me.LabelX1)
        Me.GroupPanel2.Controls.Add(Me.Txt_Observaciones)
        Me.GroupPanel2.Controls.Add(Me.LabelX14)
        Me.GroupPanel2.Controls.Add(Me.Txt_Planta)
        Me.GroupPanel2.Controls.Add(Me.Txt_Turno)
        Me.GroupPanel2.Controls.Add(Me.Txt_Analista)
        Me.GroupPanel2.Controls.Add(Me.LabelX17)
        Me.GroupPanel2.Controls.Add(Me.LabelX5)
        Me.GroupPanel2.Controls.Add(Me.Txt_CodAlternativo_Pallet)
        Me.GroupPanel2.Controls.Add(Me.Txt_NroLote)
        Me.GroupPanel2.Controls.Add(Me.LabelX7)
        Me.GroupPanel2.Controls.Add(Me.LabelX10)
        Me.GroupPanel2.Controls.Add(Me.Lbl_Tipo)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(802, 243)
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
        Me.GroupPanel2.TabIndex = 102
        Me.GroupPanel2.Text = "DATOS DE LA TARJA"
        '
        'Txt_Nro_CPT
        '
        Me.Txt_Nro_CPT.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Nro_CPT.Border.Class = "TextBoxBorder"
        Me.Txt_Nro_CPT.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Nro_CPT.ButtonCustom.Image = CType(resources.GetObject("Txt_Nro_CPT.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Nro_CPT.ButtonCustom.Visible = True
        Me.Txt_Nro_CPT.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Nro_CPT.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Nro_CPT.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Txt_Nro_CPT.ForeColor = System.Drawing.Color.Black
        Me.Txt_Nro_CPT.Location = New System.Drawing.Point(87, 3)
        Me.Txt_Nro_CPT.MaxLength = 13
        Me.Txt_Nro_CPT.Name = "Txt_Nro_CPT"
        Me.Txt_Nro_CPT.Size = New System.Drawing.Size(213, 22)
        Me.Txt_Nro_CPT.TabIndex = 106
        Me.Txt_Nro_CPT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(87, 23)
        Me.LabelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX1.TabIndex = 107
        Me.LabelX1.Text = "NRO. TARJA"
        '
        'Txt_Observaciones
        '
        Me.Txt_Observaciones.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Observaciones.Border.Class = "TextBoxBorder"
        Me.Txt_Observaciones.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Observaciones.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Observaciones.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Observaciones.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Txt_Observaciones.ForeColor = System.Drawing.Color.Black
        Me.Txt_Observaciones.Location = New System.Drawing.Point(116, 163)
        Me.Txt_Observaciones.MaxLength = 200
        Me.Txt_Observaciones.Multiline = True
        Me.Txt_Observaciones.Name = "Txt_Observaciones"
        Me.Txt_Observaciones.ReadOnly = True
        Me.Txt_Observaciones.Size = New System.Drawing.Size(674, 52)
        Me.Txt_Observaciones.TabIndex = 105
        Me.Txt_Observaciones.TabStop = False
        '
        'LabelX14
        '
        Me.LabelX14.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX14.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX14.ForeColor = System.Drawing.Color.Black
        Me.LabelX14.Location = New System.Drawing.Point(3, 160)
        Me.LabelX14.Name = "LabelX14"
        Me.LabelX14.Size = New System.Drawing.Size(117, 23)
        Me.LabelX14.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX14.TabIndex = 104
        Me.LabelX14.Text = "OBSERVACIONES"
        '
        'Txt_Planta
        '
        Me.Txt_Planta.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Planta.Border.Class = "TextBoxBorder"
        Me.Txt_Planta.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Planta.ButtonCustom.Image = CType(resources.GetObject("Txt_Planta.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Planta.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Planta.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Planta.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Txt_Planta.ForeColor = System.Drawing.Color.Black
        Me.Txt_Planta.Location = New System.Drawing.Point(316, 67)
        Me.Txt_Planta.MaxLength = 13
        Me.Txt_Planta.Name = "Txt_Planta"
        Me.Txt_Planta.ReadOnly = True
        Me.Txt_Planta.Size = New System.Drawing.Size(165, 22)
        Me.Txt_Planta.TabIndex = 103
        Me.Txt_Planta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Txt_Turno
        '
        Me.Txt_Turno.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Turno.Border.Class = "TextBoxBorder"
        Me.Txt_Turno.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Turno.ButtonCustom.Image = CType(resources.GetObject("Txt_Turno.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Turno.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Turno.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Turno.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Txt_Turno.ForeColor = System.Drawing.Color.Black
        Me.Txt_Turno.Location = New System.Drawing.Point(87, 67)
        Me.Txt_Turno.MaxLength = 13
        Me.Txt_Turno.Name = "Txt_Turno"
        Me.Txt_Turno.ReadOnly = True
        Me.Txt_Turno.Size = New System.Drawing.Size(165, 22)
        Me.Txt_Turno.TabIndex = 102
        Me.Txt_Turno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Txt_Analista
        '
        Me.Txt_Analista.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Analista.Border.Class = "TextBoxBorder"
        Me.Txt_Analista.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Analista.ButtonCustom.Image = CType(resources.GetObject("Txt_Analista.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Analista.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Analista.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Analista.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Txt_Analista.ForeColor = System.Drawing.Color.Black
        Me.Txt_Analista.Location = New System.Drawing.Point(87, 131)
        Me.Txt_Analista.MaxLength = 13
        Me.Txt_Analista.Name = "Txt_Analista"
        Me.Txt_Analista.ReadOnly = True
        Me.Txt_Analista.Size = New System.Drawing.Size(394, 22)
        Me.Txt_Analista.TabIndex = 10
        Me.Txt_Analista.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelX17
        '
        Me.LabelX17.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX17.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX17.ForeColor = System.Drawing.Color.Black
        Me.LabelX17.Location = New System.Drawing.Point(3, 131)
        Me.LabelX17.Name = "LabelX17"
        Me.LabelX17.Size = New System.Drawing.Size(71, 23)
        Me.LabelX17.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX17.TabIndex = 101
        Me.LabelX17.Text = "ANALISTA"
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(3, 35)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(71, 23)
        Me.LabelX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX5.TabIndex = 84
        Me.LabelX5.Text = "NRO. LOTE"
        '
        'Txt_CodAlternativo_Pallet
        '
        Me.Txt_CodAlternativo_Pallet.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_CodAlternativo_Pallet.Border.Class = "TextBoxBorder"
        Me.Txt_CodAlternativo_Pallet.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_CodAlternativo_Pallet.ButtonCustom.Image = CType(resources.GetObject("Txt_CodAlternativo_Pallet.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_CodAlternativo_Pallet.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_CodAlternativo_Pallet.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_CodAlternativo_Pallet.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Txt_CodAlternativo_Pallet.ForeColor = System.Drawing.Color.Black
        Me.Txt_CodAlternativo_Pallet.Location = New System.Drawing.Point(87, 99)
        Me.Txt_CodAlternativo_Pallet.MaxLength = 13
        Me.Txt_CodAlternativo_Pallet.Name = "Txt_CodAlternativo_Pallet"
        Me.Txt_CodAlternativo_Pallet.ReadOnly = True
        Me.Txt_CodAlternativo_Pallet.Size = New System.Drawing.Size(703, 22)
        Me.Txt_CodAlternativo_Pallet.TabIndex = 9
        '
        'Txt_NroLote
        '
        Me.Txt_NroLote.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_NroLote.Border.Class = "TextBoxBorder"
        Me.Txt_NroLote.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_NroLote.ButtonCustom.Image = CType(resources.GetObject("Txt_NroLote.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_NroLote.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_NroLote.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_NroLote.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Txt_NroLote.ForeColor = System.Drawing.Color.Black
        Me.Txt_NroLote.Location = New System.Drawing.Point(87, 35)
        Me.Txt_NroLote.MaxLength = 13
        Me.Txt_NroLote.Name = "Txt_NroLote"
        Me.Txt_NroLote.ReadOnly = True
        Me.Txt_NroLote.Size = New System.Drawing.Size(213, 22)
        Me.Txt_NroLote.TabIndex = 6
        Me.Txt_NroLote.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX7.ForeColor = System.Drawing.Color.Black
        Me.LabelX7.Location = New System.Drawing.Point(3, 70)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(71, 23)
        Me.LabelX7.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX7.TabIndex = 88
        Me.LabelX7.Text = "TURNO"
        '
        'LabelX10
        '
        Me.LabelX10.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX10.ForeColor = System.Drawing.Color.Black
        Me.LabelX10.Location = New System.Drawing.Point(261, 70)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(71, 23)
        Me.LabelX10.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX10.TabIndex = 90
        Me.LabelX10.Text = "PLANTA"
        '
        'Lbl_Tipo
        '
        Me.Lbl_Tipo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Tipo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Tipo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Tipo.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Tipo.Location = New System.Drawing.Point(3, 99)
        Me.Lbl_Tipo.Name = "Lbl_Tipo"
        Me.Lbl_Tipo.Size = New System.Drawing.Size(71, 23)
        Me.Lbl_Tipo.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Lbl_Tipo.TabIndex = 91
        Me.Lbl_Tipo.Text = "TIPO..."
        '
        'Frm_ImpBarras_Tarja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(823, 367)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.Grupo_Puerto)
        Me.Controls.Add(Me.GroupPanel3)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_ImpBarras_Tarja"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CONTROL PRODUCTO TERMINADO"
        Me.Grupo_Puerto.ResumeLayout(False)
        Me.GroupPanel3.ResumeLayout(False)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Public WithEvents Grupo_Puerto As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents CmbPuerto As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Btn_ConfPuertoXEtiquetaXEquipo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Cmbetiquetas As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnImprimirEtiqueta As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnLimpiar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Public WithEvents BtnConfiguracion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Conf_PuertoEtiqueta As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Conf_ConfEstacion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Txt_Observaciones As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX14 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Planta As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Txt_Turno As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Txt_Analista As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX17 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_CodAlternativo_Pallet As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Txt_NroLote As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Tipo As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Nro_CPT As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
End Class
