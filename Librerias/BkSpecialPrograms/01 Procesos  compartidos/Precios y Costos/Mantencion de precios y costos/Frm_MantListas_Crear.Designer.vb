<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_MantListas_Crear
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_MantListas_Crear))
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.BtnGrabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Txt_Nombre_Lista = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Codigo_Lista = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Grupo_Tipo_Lista = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Rdb_Lista_Costos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Lista_Precios = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Btn_Fx2 = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Fx1 = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_Ecudef02ud = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Ecudef01ud = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.GroupPanel4 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Rdb_Bruto = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Neto = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.GroupPanel5 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Cmb_Moneda = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Wb_ListaMinorista = New DevComponents.DotNetBar.Controls.WarningBox()
        Me.Chk_EsListaSuperior = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Panel_Mayorista = New System.Windows.Forms.Panel()
        Me.Txt_ListaInferior = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Input_VentaMinVencLP = New DevComponents.Editors.DoubleInput()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.Input_Flete = New DevComponents.Editors.DoubleInput()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.Grupo_Tipo_Lista.SuspendLayout()
        Me.GroupPanel3.SuspendLayout()
        Me.GroupPanel4.SuspendLayout()
        Me.GroupPanel5.SuspendLayout()
        Me.GroupPanel2.SuspendLayout()
        Me.Panel_Mayorista.SuspendLayout()
        CType(Me.Input_VentaMinVencLP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Input_Flete, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnGrabar})
        Me.Bar2.Location = New System.Drawing.Point(0, 366)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(623, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 31
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'BtnGrabar
        '
        Me.BtnGrabar.ForeColor = System.Drawing.Color.Black
        Me.BtnGrabar.Image = CType(resources.GetObject("BtnGrabar.Image"), System.Drawing.Image)
        Me.BtnGrabar.ImageAlt = CType(resources.GetObject("BtnGrabar.ImageAlt"), System.Drawing.Image)
        Me.BtnGrabar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnGrabar.Name = "BtnGrabar"
        Me.BtnGrabar.Tooltip = "Mantención de formula global"
        '
        'Txt_Nombre_Lista
        '
        Me.Txt_Nombre_Lista.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Nombre_Lista.Border.Class = "TextBoxBorder"
        Me.Txt_Nombre_Lista.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Nombre_Lista.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Nombre_Lista.ForeColor = System.Drawing.Color.Black
        Me.Txt_Nombre_Lista.Location = New System.Drawing.Point(68, 23)
        Me.Txt_Nombre_Lista.Name = "Txt_Nombre_Lista"
        Me.Txt_Nombre_Lista.PreventEnterBeep = True
        Me.Txt_Nombre_Lista.Size = New System.Drawing.Size(335, 22)
        Me.Txt_Nombre_Lista.TabIndex = 3
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(68, 4)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(64, 23)
        Me.LabelX2.TabIndex = 2
        Me.LabelX2.Text = "Nobre lista"
        '
        'Txt_Codigo_Lista
        '
        Me.Txt_Codigo_Lista.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Codigo_Lista.Border.Class = "TextBoxBorder"
        Me.Txt_Codigo_Lista.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Codigo_Lista.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Codigo_Lista.ForeColor = System.Drawing.Color.Black
        Me.Txt_Codigo_Lista.Location = New System.Drawing.Point(3, 23)
        Me.Txt_Codigo_Lista.Name = "Txt_Codigo_Lista"
        Me.Txt_Codigo_Lista.PreventEnterBeep = True
        Me.Txt_Codigo_Lista.Size = New System.Drawing.Size(59, 22)
        Me.Txt_Codigo_Lista.TabIndex = 1
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 4)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(44, 23)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "Código"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Txt_Codigo_Lista)
        Me.GroupPanel1.Controls.Add(Me.Txt_Nombre_Lista)
        Me.GroupPanel1.Controls.Add(Me.LabelX2)
        Me.GroupPanel1.Controls.Add(Me.LabelX1)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(6, 12)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(412, 71)
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
        Me.GroupPanel1.TabIndex = 34
        Me.GroupPanel1.Text = "Lista"
        '
        'Grupo_Tipo_Lista
        '
        Me.Grupo_Tipo_Lista.BackColor = System.Drawing.Color.White
        Me.Grupo_Tipo_Lista.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Tipo_Lista.Controls.Add(Me.Rdb_Lista_Costos)
        Me.Grupo_Tipo_Lista.Controls.Add(Me.Rdb_Lista_Precios)
        Me.Grupo_Tipo_Lista.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Tipo_Lista.Location = New System.Drawing.Point(87, 89)
        Me.Grupo_Tipo_Lista.Name = "Grupo_Tipo_Lista"
        Me.Grupo_Tipo_Lista.Size = New System.Drawing.Size(122, 95)
        '
        '
        '
        Me.Grupo_Tipo_Lista.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Tipo_Lista.Style.BackColorGradientAngle = 90
        Me.Grupo_Tipo_Lista.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Tipo_Lista.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Tipo_Lista.Style.BorderBottomWidth = 1
        Me.Grupo_Tipo_Lista.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Tipo_Lista.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Tipo_Lista.Style.BorderLeftWidth = 1
        Me.Grupo_Tipo_Lista.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Tipo_Lista.Style.BorderRightWidth = 1
        Me.Grupo_Tipo_Lista.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Tipo_Lista.Style.BorderTopWidth = 1
        Me.Grupo_Tipo_Lista.Style.CornerDiameter = 4
        Me.Grupo_Tipo_Lista.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Tipo_Lista.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Tipo_Lista.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Tipo_Lista.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Tipo_Lista.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Tipo_Lista.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Tipo_Lista.TabIndex = 35
        Me.Grupo_Tipo_Lista.Text = "Tipo lista"
        '
        'Rdb_Lista_Costos
        '
        Me.Rdb_Lista_Costos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Lista_Costos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Lista_Costos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Lista_Costos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Lista_Costos.Location = New System.Drawing.Point(3, 33)
        Me.Rdb_Lista_Costos.Name = "Rdb_Lista_Costos"
        Me.Rdb_Lista_Costos.Size = New System.Drawing.Size(100, 23)
        Me.Rdb_Lista_Costos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Lista_Costos.TabIndex = 38
        Me.Rdb_Lista_Costos.Text = "Lista Costos"
        '
        'Rdb_Lista_Precios
        '
        Me.Rdb_Lista_Precios.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Lista_Precios.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Lista_Precios.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Lista_Precios.Checked = True
        Me.Rdb_Lista_Precios.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Lista_Precios.CheckValue = "Y"
        Me.Rdb_Lista_Precios.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Lista_Precios.Location = New System.Drawing.Point(3, 12)
        Me.Rdb_Lista_Precios.Name = "Rdb_Lista_Precios"
        Me.Rdb_Lista_Precios.Size = New System.Drawing.Size(100, 23)
        Me.Rdb_Lista_Precios.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Lista_Precios.TabIndex = 37
        Me.Rdb_Lista_Precios.Text = "Lista Precios"
        '
        'GroupPanel3
        '
        Me.GroupPanel3.BackColor = System.Drawing.Color.White
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.Btn_Fx2)
        Me.GroupPanel3.Controls.Add(Me.Btn_Fx1)
        Me.GroupPanel3.Controls.Add(Me.Txt_Ecudef02ud)
        Me.GroupPanel3.Controls.Add(Me.Txt_Ecudef01ud)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Location = New System.Drawing.Point(215, 89)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(399, 95)
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
        Me.GroupPanel3.TabIndex = 37
        Me.GroupPanel3.Text = "Formula por defecto para los precios de cada unidad (Opcional)"
        '
        'Btn_Fx2
        '
        Me.Btn_Fx2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Fx2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Fx2.Image = CType(resources.GetObject("Btn_Fx2.Image"), System.Drawing.Image)
        Me.Btn_Fx2.Location = New System.Drawing.Point(3, 40)
        Me.Btn_Fx2.Name = "Btn_Fx2"
        Me.Btn_Fx2.Size = New System.Drawing.Size(59, 23)
        Me.Btn_Fx2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Fx2.TabIndex = 5
        Me.Btn_Fx2.Text = "Ud2"
        '
        'Btn_Fx1
        '
        Me.Btn_Fx1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Fx1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Fx1.Image = CType(resources.GetObject("Btn_Fx1.Image"), System.Drawing.Image)
        Me.Btn_Fx1.Location = New System.Drawing.Point(3, 13)
        Me.Btn_Fx1.Name = "Btn_Fx1"
        Me.Btn_Fx1.Size = New System.Drawing.Size(59, 23)
        Me.Btn_Fx1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Fx1.TabIndex = 0
        Me.Btn_Fx1.Text = "Ud1"
        '
        'Txt_Ecudef02ud
        '
        Me.Txt_Ecudef02ud.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Ecudef02ud.Border.Class = "TextBoxBorder"
        Me.Txt_Ecudef02ud.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Ecudef02ud.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Ecudef02ud.ForeColor = System.Drawing.Color.Black
        Me.Txt_Ecudef02ud.Location = New System.Drawing.Point(68, 41)
        Me.Txt_Ecudef02ud.Name = "Txt_Ecudef02ud"
        Me.Txt_Ecudef02ud.PreventEnterBeep = True
        Me.Txt_Ecudef02ud.ReadOnly = True
        Me.Txt_Ecudef02ud.Size = New System.Drawing.Size(322, 22)
        Me.Txt_Ecudef02ud.TabIndex = 4
        '
        'Txt_Ecudef01ud
        '
        Me.Txt_Ecudef01ud.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Ecudef01ud.Border.Class = "TextBoxBorder"
        Me.Txt_Ecudef01ud.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Ecudef01ud.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Ecudef01ud.ForeColor = System.Drawing.Color.Black
        Me.Txt_Ecudef01ud.Location = New System.Drawing.Point(68, 14)
        Me.Txt_Ecudef01ud.Name = "Txt_Ecudef01ud"
        Me.Txt_Ecudef01ud.PreventEnterBeep = True
        Me.Txt_Ecudef01ud.ReadOnly = True
        Me.Txt_Ecudef01ud.Size = New System.Drawing.Size(322, 22)
        Me.Txt_Ecudef01ud.TabIndex = 3
        '
        'GroupPanel4
        '
        Me.GroupPanel4.BackColor = System.Drawing.Color.White
        Me.GroupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel4.Controls.Add(Me.Rdb_Bruto)
        Me.GroupPanel4.Controls.Add(Me.Rdb_Neto)
        Me.GroupPanel4.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel4.Location = New System.Drawing.Point(6, 89)
        Me.GroupPanel4.Name = "GroupPanel4"
        Me.GroupPanel4.Size = New System.Drawing.Size(75, 95)
        '
        '
        '
        Me.GroupPanel4.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel4.Style.BackColorGradientAngle = 90
        Me.GroupPanel4.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel4.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderBottomWidth = 1
        Me.GroupPanel4.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel4.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderLeftWidth = 1
        Me.GroupPanel4.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderRightWidth = 1
        Me.GroupPanel4.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderTopWidth = 1
        Me.GroupPanel4.Style.CornerDiameter = 4
        Me.GroupPanel4.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel4.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel4.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel4.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel4.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel4.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel4.TabIndex = 38
        Me.GroupPanel4.Text = "Metodo"
        '
        'Rdb_Bruto
        '
        Me.Rdb_Bruto.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Bruto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Bruto.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Bruto.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Bruto.Location = New System.Drawing.Point(3, 35)
        Me.Rdb_Bruto.Name = "Rdb_Bruto"
        Me.Rdb_Bruto.Size = New System.Drawing.Size(63, 23)
        Me.Rdb_Bruto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Bruto.TabIndex = 38
        Me.Rdb_Bruto.Text = "Bruto"
        '
        'Rdb_Neto
        '
        Me.Rdb_Neto.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Neto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Neto.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Neto.Checked = True
        Me.Rdb_Neto.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Neto.CheckValue = "Y"
        Me.Rdb_Neto.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Neto.Location = New System.Drawing.Point(3, 12)
        Me.Rdb_Neto.Name = "Rdb_Neto"
        Me.Rdb_Neto.Size = New System.Drawing.Size(63, 23)
        Me.Rdb_Neto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Neto.TabIndex = 37
        Me.Rdb_Neto.Text = "Neto"
        '
        'GroupPanel5
        '
        Me.GroupPanel5.BackColor = System.Drawing.Color.White
        Me.GroupPanel5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel5.Controls.Add(Me.Cmb_Moneda)
        Me.GroupPanel5.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel5.Location = New System.Drawing.Point(424, 12)
        Me.GroupPanel5.Name = "GroupPanel5"
        Me.GroupPanel5.Size = New System.Drawing.Size(190, 71)
        '
        '
        '
        Me.GroupPanel5.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel5.Style.BackColorGradientAngle = 90
        Me.GroupPanel5.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel5.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel5.Style.BorderBottomWidth = 1
        Me.GroupPanel5.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel5.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel5.Style.BorderLeftWidth = 1
        Me.GroupPanel5.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel5.Style.BorderRightWidth = 1
        Me.GroupPanel5.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel5.Style.BorderTopWidth = 1
        Me.GroupPanel5.Style.CornerDiameter = 4
        Me.GroupPanel5.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel5.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel5.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel5.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel5.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel5.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel5.TabIndex = 39
        Me.GroupPanel5.Text = "Moneda"
        '
        'Cmb_Moneda
        '
        Me.Cmb_Moneda.DisplayMember = "Text"
        Me.Cmb_Moneda.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Moneda.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Moneda.FormattingEnabled = True
        Me.Cmb_Moneda.ItemHeight = 16
        Me.Cmb_Moneda.Location = New System.Drawing.Point(3, 23)
        Me.Cmb_Moneda.Name = "Cmb_Moneda"
        Me.Cmb_Moneda.Size = New System.Drawing.Size(178, 22)
        Me.Cmb_Moneda.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Moneda.TabIndex = 0
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Wb_ListaMinorista)
        Me.GroupPanel2.Controls.Add(Me.Chk_EsListaSuperior)
        Me.GroupPanel2.Controls.Add(Me.Panel_Mayorista)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(6, 226)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(608, 132)
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
        Me.GroupPanel2.TabIndex = 40
        Me.GroupPanel2.Text = "Configuración de lista mayorista/minorista"
        '
        'Wb_ListaMinorista
        '
        Me.Wb_ListaMinorista.BackColor = System.Drawing.Color.White
        Me.Wb_ListaMinorista.CloseButtonVisible = False
        Me.Wb_ListaMinorista.ForeColor = System.Drawing.Color.Black
        Me.Wb_ListaMinorista.Image = CType(resources.GetObject("Wb_ListaMinorista.Image"), System.Drawing.Image)
        Me.Wb_ListaMinorista.Location = New System.Drawing.Point(117, 3)
        Me.Wb_ListaMinorista.Name = "Wb_ListaMinorista"
        Me.Wb_ListaMinorista.OptionsText = "¿Que es esto?"
        Me.Wb_ListaMinorista.Size = New System.Drawing.Size(482, 33)
        Me.Wb_ListaMinorista.TabIndex = 47
        Me.Wb_ListaMinorista.Text = "<b>Es lista minorista</b> La lista mayorista es: <i>01P - PRECIOS GENERAL</i>"
        Me.Wb_ListaMinorista.Visible = False
        '
        'Chk_EsListaSuperior
        '
        Me.Chk_EsListaSuperior.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_EsListaSuperior.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_EsListaSuperior.CheckBoxImageChecked = CType(resources.GetObject("Chk_EsListaSuperior.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_EsListaSuperior.Checked = True
        Me.Chk_EsListaSuperior.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_EsListaSuperior.CheckValue = "Y"
        Me.Chk_EsListaSuperior.ForeColor = System.Drawing.Color.Black
        Me.Chk_EsListaSuperior.Location = New System.Drawing.Point(3, 3)
        Me.Chk_EsListaSuperior.Name = "Chk_EsListaSuperior"
        Me.Chk_EsListaSuperior.Size = New System.Drawing.Size(114, 20)
        Me.Chk_EsListaSuperior.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_EsListaSuperior.TabIndex = 41
        Me.Chk_EsListaSuperior.Text = "Es lista mayorista"
        '
        'Panel_Mayorista
        '
        Me.Panel_Mayorista.BackColor = System.Drawing.Color.Transparent
        Me.Panel_Mayorista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_Mayorista.Controls.Add(Me.Txt_ListaInferior)
        Me.Panel_Mayorista.Controls.Add(Me.LabelX4)
        Me.Panel_Mayorista.Controls.Add(Me.Input_VentaMinVencLP)
        Me.Panel_Mayorista.Controls.Add(Me.LabelX5)
        Me.Panel_Mayorista.ForeColor = System.Drawing.Color.Black
        Me.Panel_Mayorista.Location = New System.Drawing.Point(3, 42)
        Me.Panel_Mayorista.Name = "Panel_Mayorista"
        Me.Panel_Mayorista.Size = New System.Drawing.Size(596, 61)
        Me.Panel_Mayorista.TabIndex = 46
        '
        'Txt_ListaInferior
        '
        Me.Txt_ListaInferior.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_ListaInferior.Border.Class = "TextBoxBorder"
        Me.Txt_ListaInferior.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_ListaInferior.ButtonCustom.Image = CType(resources.GetObject("Txt_ListaInferior.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_ListaInferior.ButtonCustom.Visible = True
        Me.Txt_ListaInferior.ButtonCustom2.Image = CType(resources.GetObject("Txt_ListaInferior.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_ListaInferior.ButtonCustom2.Visible = True
        Me.Txt_ListaInferior.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_ListaInferior.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_ListaInferior.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_ListaInferior.ForeColor = System.Drawing.Color.Black
        Me.Txt_ListaInferior.Location = New System.Drawing.Point(81, 32)
        Me.Txt_ListaInferior.Name = "Txt_ListaInferior"
        Me.Txt_ListaInferior.Size = New System.Drawing.Size(504, 22)
        Me.Txt_ListaInferior.TabIndex = 47
        Me.Txt_ListaInferior.WatermarkText = "Lista minorista a la cual se cambiara si no cumple con la venta mínima"
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(3, 32)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(77, 23)
        Me.LabelX4.TabIndex = 44
        Me.LabelX4.Text = "Lista minorista"
        '
        'Input_VentaMinVencLP
        '
        '
        '
        '
        Me.Input_VentaMinVencLP.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_VentaMinVencLP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_VentaMinVencLP.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.Input_VentaMinVencLP.DisplayFormat = "N0"
        Me.Input_VentaMinVencLP.ForeColor = System.Drawing.Color.Black
        Me.Input_VentaMinVencLP.Increment = 1.0R
        Me.Input_VentaMinVencLP.Location = New System.Drawing.Point(201, 4)
        Me.Input_VentaMinVencLP.MinValue = 0R
        Me.Input_VentaMinVencLP.Name = "Input_VentaMinVencLP"
        Me.Input_VentaMinVencLP.ShowUpDown = True
        Me.Input_VentaMinVencLP.Size = New System.Drawing.Size(67, 22)
        Me.Input_VentaMinVencLP.TabIndex = 43
        Me.Input_VentaMinVencLP.Value = 400000.0R
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(3, 3)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(200, 23)
        Me.LabelX5.TabIndex = 42
        Me.LabelX5.Text = "Venta mínima para pertener a esta lista"
        '
        'Input_Flete
        '
        Me.Input_Flete.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_Flete.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_Flete.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_Flete.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.Input_Flete.DisplayFormat = "N0"
        Me.Input_Flete.ForeColor = System.Drawing.Color.Black
        Me.Input_Flete.Increment = 1.0R
        Me.Input_Flete.Location = New System.Drawing.Point(87, 191)
        Me.Input_Flete.MinValue = 0R
        Me.Input_Flete.Name = "Input_Flete"
        Me.Input_Flete.ShowUpDown = True
        Me.Input_Flete.Size = New System.Drawing.Size(48, 22)
        Me.Input_Flete.TabIndex = 45
        Me.Input_Flete.Value = 150.0R
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(6, 190)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(80, 23)
        Me.LabelX6.TabIndex = 44
        Me.LabelX6.Text = "Flete de la lista"
        '
        'Frm_MantListas_Crear
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(623, 407)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.GroupPanel5)
        Me.Controls.Add(Me.GroupPanel4)
        Me.Controls.Add(Me.Input_Flete)
        Me.Controls.Add(Me.GroupPanel3)
        Me.Controls.Add(Me.LabelX6)
        Me.Controls.Add(Me.Grupo_Tipo_Lista)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_MantListas_Crear"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Crear lista de precio/costo"
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.Grupo_Tipo_Lista.ResumeLayout(False)
        Me.GroupPanel3.ResumeLayout(False)
        Me.GroupPanel4.ResumeLayout(False)
        Me.GroupPanel5.ResumeLayout(False)
        Me.GroupPanel2.ResumeLayout(False)
        Me.Panel_Mayorista.ResumeLayout(False)
        CType(Me.Input_VentaMinVencLP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Input_Flete, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Public WithEvents BtnGrabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Txt_Nombre_Lista As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Codigo_Lista As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grupo_Tipo_Lista As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Rdb_Lista_Costos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Lista_Precios As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Btn_Fx2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Fx1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Txt_Ecudef02ud As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Ecudef01ud As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents GroupPanel4 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Rdb_Bruto As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Neto As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents GroupPanel5 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Cmb_Moneda As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Input_VentaMinVencLP As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Chk_EsListaSuperior As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Input_Flete As DevComponents.Editors.DoubleInput
    Friend WithEvents Panel_Mayorista As Panel
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Wb_ListaMinorista As DevComponents.DotNetBar.Controls.WarningBox
    Friend WithEvents Txt_ListaInferior As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
End Class
