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
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.Grupo_Tipo_Lista.SuspendLayout()
        Me.GroupPanel3.SuspendLayout()
        Me.GroupPanel4.SuspendLayout()
        Me.GroupPanel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnGrabar})
        Me.Bar2.Location = New System.Drawing.Point(0, 290)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(417, 41)
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
        Me.Txt_Nombre_Lista.Size = New System.Drawing.Size(322, 22)
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
        Me.GroupPanel1.Size = New System.Drawing.Size(399, 71)
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
        Me.Grupo_Tipo_Lista.Location = New System.Drawing.Point(6, 89)
        Me.Grupo_Tipo_Lista.Name = "Grupo_Tipo_Lista"
        Me.Grupo_Tipo_Lista.Size = New System.Drawing.Size(122, 84)
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
        Me.GroupPanel3.Location = New System.Drawing.Point(6, 179)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(399, 99)
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
        Me.GroupPanel4.Location = New System.Drawing.Point(134, 89)
        Me.GroupPanel4.Name = "GroupPanel4"
        Me.GroupPanel4.Size = New System.Drawing.Size(75, 84)
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
        Me.GroupPanel5.Location = New System.Drawing.Point(215, 89)
        Me.GroupPanel5.Name = "GroupPanel5"
        Me.GroupPanel5.Size = New System.Drawing.Size(190, 84)
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
        Me.Cmb_Moneda.Location = New System.Drawing.Point(3, 33)
        Me.Cmb_Moneda.Name = "Cmb_Moneda"
        Me.Cmb_Moneda.Size = New System.Drawing.Size(178, 22)
        Me.Cmb_Moneda.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Moneda.TabIndex = 0
        '
        'Frm_MantListas_Crear
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(417, 331)
        Me.Controls.Add(Me.GroupPanel5)
        Me.Controls.Add(Me.GroupPanel4)
        Me.Controls.Add(Me.GroupPanel3)
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
End Class
