<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Filtro_Especial_Productos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Filtro_Especial_Productos))
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Aceptar = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Panel_Otros_Filtros = New System.Windows.Forms.Panel()
        Me.Tabla_01 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_Clasificacion_Libre_Algunas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Clasificacion_Masisa_Todas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_Zonas_Algunas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Zonas_Todas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_Super_Familias_Algunas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Super_Familias_Todas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_Rubros_Algunos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Rubros_Todos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_Marcas_Algunas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Marcas_Todas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TableLayoutPanel8 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_Productos_Algunos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Productos_Todos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.Panel_Otros_Filtros.SuspendLayout()
        Me.Tabla_01.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel8.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Aceptar})
        Me.Bar1.Location = New System.Drawing.Point(0, 259)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(330, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 14
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Aceptar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Aceptar.Image = CType(resources.GetObject("Btn_Aceptar.Image"), System.Drawing.Image)
        Me.Btn_Aceptar.ImageAlt = CType(resources.GetObject("Btn_Aceptar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Text = "Aceptar"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Panel_Otros_Filtros)
        Me.GroupPanel1.Controls.Add(Me.TableLayoutPanel8)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(311, 232)
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
        Me.GroupPanel1.TabIndex = 15
        Me.GroupPanel1.Text = "Filtros"
        '
        'Panel_Otros_Filtros
        '
        Me.Panel_Otros_Filtros.BackColor = System.Drawing.Color.Transparent
        Me.Panel_Otros_Filtros.Controls.Add(Me.Tabla_01)
        Me.Panel_Otros_Filtros.Controls.Add(Me.TableLayoutPanel4)
        Me.Panel_Otros_Filtros.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel_Otros_Filtros.Controls.Add(Me.TableLayoutPanel3)
        Me.Panel_Otros_Filtros.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel_Otros_Filtros.Location = New System.Drawing.Point(3, 47)
        Me.Panel_Otros_Filtros.Name = "Panel_Otros_Filtros"
        Me.Panel_Otros_Filtros.Size = New System.Drawing.Size(302, 159)
        Me.Panel_Otros_Filtros.TabIndex = 16
        '
        'Tabla_01
        '
        Me.Tabla_01.BackColor = System.Drawing.Color.Transparent
        Me.Tabla_01.ColumnCount = 3
        Me.Tabla_01.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Tabla_01.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84.0!))
        Me.Tabla_01.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
        Me.Tabla_01.Controls.Add(Me.LabelX1, 0, 0)
        Me.Tabla_01.Controls.Add(Me.Rdb_Clasificacion_Libre_Algunas, 2, 0)
        Me.Tabla_01.Controls.Add(Me.Rdb_Clasificacion_Masisa_Todas, 1, 0)
        Me.Tabla_01.ForeColor = System.Drawing.Color.Black
        Me.Tabla_01.Location = New System.Drawing.Point(3, 3)
        Me.Tabla_01.Name = "Tabla_01"
        Me.Tabla_01.RowCount = 1
        Me.Tabla_01.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Tabla_01.Size = New System.Drawing.Size(296, 25)
        Me.Tabla_01.TabIndex = 47
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(100, 19)
        Me.LabelX1.TabIndex = 4
        Me.LabelX1.Text = "Clasificación Libre"
        '
        'Rdb_Clasificacion_Libre_Algunas
        '
        Me.Rdb_Clasificacion_Libre_Algunas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Clasificacion_Libre_Algunas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Clasificacion_Libre_Algunas.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Clasificacion_Libre_Algunas.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Clasificacion_Libre_Algunas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Clasificacion_Libre_Algunas.FocusCuesEnabled = False
        Me.Rdb_Clasificacion_Libre_Algunas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Clasificacion_Libre_Algunas.Location = New System.Drawing.Point(193, 3)
        Me.Rdb_Clasificacion_Libre_Algunas.Name = "Rdb_Clasificacion_Libre_Algunas"
        Me.Rdb_Clasificacion_Libre_Algunas.Size = New System.Drawing.Size(94, 19)
        Me.Rdb_Clasificacion_Libre_Algunas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Clasificacion_Libre_Algunas.TabIndex = 3
        Me.Rdb_Clasificacion_Libre_Algunas.Text = "Algunas"
        '
        'Rdb_Clasificacion_Masisa_Todas
        '
        Me.Rdb_Clasificacion_Masisa_Todas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Clasificacion_Masisa_Todas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Clasificacion_Masisa_Todas.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Clasificacion_Masisa_Todas.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Clasificacion_Masisa_Todas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Clasificacion_Masisa_Todas.Checked = True
        Me.Rdb_Clasificacion_Masisa_Todas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Clasificacion_Masisa_Todas.CheckValue = "Y"
        Me.Rdb_Clasificacion_Masisa_Todas.FocusCuesEnabled = False
        Me.Rdb_Clasificacion_Masisa_Todas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Clasificacion_Masisa_Todas.Location = New System.Drawing.Point(109, 3)
        Me.Rdb_Clasificacion_Masisa_Todas.Name = "Rdb_Clasificacion_Masisa_Todas"
        Me.Rdb_Clasificacion_Masisa_Todas.Size = New System.Drawing.Size(78, 19)
        Me.Rdb_Clasificacion_Masisa_Todas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Clasificacion_Masisa_Todas.TabIndex = 1
        Me.Rdb_Clasificacion_Masisa_Todas.Text = "Todas "
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel4.ColumnCount = 3
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.LabelX5, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Rdb_Zonas_Algunas, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Rdb_Zonas_Todas, 1, 0)
        Me.TableLayoutPanel4.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(3, 126)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(296, 25)
        Me.TableLayoutPanel4.TabIndex = 51
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(3, 3)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(100, 19)
        Me.LabelX5.TabIndex = 4
        Me.LabelX5.Text = "Zonas"
        '
        'Rdb_Zonas_Algunas
        '
        Me.Rdb_Zonas_Algunas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Zonas_Algunas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Zonas_Algunas.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Zonas_Algunas.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Zonas_Algunas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Zonas_Algunas.FocusCuesEnabled = False
        Me.Rdb_Zonas_Algunas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Zonas_Algunas.Location = New System.Drawing.Point(193, 3)
        Me.Rdb_Zonas_Algunas.Name = "Rdb_Zonas_Algunas"
        Me.Rdb_Zonas_Algunas.Size = New System.Drawing.Size(94, 19)
        Me.Rdb_Zonas_Algunas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Zonas_Algunas.TabIndex = 3
        Me.Rdb_Zonas_Algunas.Text = "Algunas"
        '
        'Rdb_Zonas_Todas
        '
        Me.Rdb_Zonas_Todas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Zonas_Todas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Zonas_Todas.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Zonas_Todas.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Zonas_Todas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Zonas_Todas.Checked = True
        Me.Rdb_Zonas_Todas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Zonas_Todas.CheckValue = "Y"
        Me.Rdb_Zonas_Todas.FocusCuesEnabled = False
        Me.Rdb_Zonas_Todas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Zonas_Todas.Location = New System.Drawing.Point(109, 3)
        Me.Rdb_Zonas_Todas.Name = "Rdb_Zonas_Todas"
        Me.Rdb_Zonas_Todas.Size = New System.Drawing.Size(78, 19)
        Me.Rdb_Zonas_Todas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Zonas_Todas.TabIndex = 1
        Me.Rdb_Zonas_Todas.Text = "Todas "
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.LabelX3, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Rdb_Super_Familias_Algunas, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Rdb_Super_Familias_Todas, 1, 0)
        Me.TableLayoutPanel2.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 64)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(296, 25)
        Me.TableLayoutPanel2.TabIndex = 49
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(3, 3)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(100, 19)
        Me.LabelX3.TabIndex = 4
        Me.LabelX3.Text = "Super Familias"
        '
        'Rdb_Super_Familias_Algunas
        '
        Me.Rdb_Super_Familias_Algunas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Super_Familias_Algunas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Super_Familias_Algunas.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Super_Familias_Algunas.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Super_Familias_Algunas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Super_Familias_Algunas.FocusCuesEnabled = False
        Me.Rdb_Super_Familias_Algunas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Super_Familias_Algunas.Location = New System.Drawing.Point(193, 3)
        Me.Rdb_Super_Familias_Algunas.Name = "Rdb_Super_Familias_Algunas"
        Me.Rdb_Super_Familias_Algunas.Size = New System.Drawing.Size(94, 19)
        Me.Rdb_Super_Familias_Algunas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Super_Familias_Algunas.TabIndex = 3
        Me.Rdb_Super_Familias_Algunas.Text = "Algunas"
        '
        'Rdb_Super_Familias_Todas
        '
        Me.Rdb_Super_Familias_Todas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Super_Familias_Todas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Super_Familias_Todas.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Super_Familias_Todas.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Super_Familias_Todas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Super_Familias_Todas.Checked = True
        Me.Rdb_Super_Familias_Todas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Super_Familias_Todas.CheckValue = "Y"
        Me.Rdb_Super_Familias_Todas.FocusCuesEnabled = False
        Me.Rdb_Super_Familias_Todas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Super_Familias_Todas.Location = New System.Drawing.Point(109, 3)
        Me.Rdb_Super_Familias_Todas.Name = "Rdb_Super_Familias_Todas"
        Me.Rdb_Super_Familias_Todas.Size = New System.Drawing.Size(78, 19)
        Me.Rdb_Super_Familias_Todas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Super_Familias_Todas.TabIndex = 1
        Me.Rdb_Super_Familias_Todas.Text = "Todas "
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel3.ColumnCount = 3
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.LabelX4, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Rdb_Rubros_Algunos, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Rdb_Rubros_Todos, 1, 0)
        Me.TableLayoutPanel3.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 95)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(296, 25)
        Me.TableLayoutPanel3.TabIndex = 50
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(3, 3)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(100, 19)
        Me.LabelX4.TabIndex = 4
        Me.LabelX4.Text = "Rubro"
        '
        'Rdb_Rubros_Algunos
        '
        Me.Rdb_Rubros_Algunos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Rubros_Algunos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Rubros_Algunos.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Rubros_Algunos.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Rubros_Algunos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Rubros_Algunos.FocusCuesEnabled = False
        Me.Rdb_Rubros_Algunos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Rubros_Algunos.Location = New System.Drawing.Point(193, 3)
        Me.Rdb_Rubros_Algunos.Name = "Rdb_Rubros_Algunos"
        Me.Rdb_Rubros_Algunos.Size = New System.Drawing.Size(94, 19)
        Me.Rdb_Rubros_Algunos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Rubros_Algunos.TabIndex = 3
        Me.Rdb_Rubros_Algunos.Text = "Algunas"
        '
        'Rdb_Rubros_Todos
        '
        Me.Rdb_Rubros_Todos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Rubros_Todos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Rubros_Todos.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Rubros_Todos.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Rubros_Todos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Rubros_Todos.Checked = True
        Me.Rdb_Rubros_Todos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Rubros_Todos.CheckValue = "Y"
        Me.Rdb_Rubros_Todos.FocusCuesEnabled = False
        Me.Rdb_Rubros_Todos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Rubros_Todos.Location = New System.Drawing.Point(109, 3)
        Me.Rdb_Rubros_Todos.Name = "Rdb_Rubros_Todos"
        Me.Rdb_Rubros_Todos.Size = New System.Drawing.Size(78, 19)
        Me.Rdb_Rubros_Todos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Rubros_Todos.TabIndex = 1
        Me.Rdb_Rubros_Todos.Text = "Todas "
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_Marcas_Algunas, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_Marcas_Todas, 1, 0)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 33)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(296, 25)
        Me.TableLayoutPanel1.TabIndex = 48
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 3)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(100, 19)
        Me.LabelX2.TabIndex = 4
        Me.LabelX2.Text = "Marcas"
        '
        'Rdb_Marcas_Algunas
        '
        Me.Rdb_Marcas_Algunas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Marcas_Algunas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Marcas_Algunas.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Marcas_Algunas.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Marcas_Algunas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Marcas_Algunas.FocusCuesEnabled = False
        Me.Rdb_Marcas_Algunas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Marcas_Algunas.Location = New System.Drawing.Point(193, 3)
        Me.Rdb_Marcas_Algunas.Name = "Rdb_Marcas_Algunas"
        Me.Rdb_Marcas_Algunas.Size = New System.Drawing.Size(94, 19)
        Me.Rdb_Marcas_Algunas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Marcas_Algunas.TabIndex = 3
        Me.Rdb_Marcas_Algunas.Text = "Algunas"
        '
        'Rdb_Marcas_Todas
        '
        Me.Rdb_Marcas_Todas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Marcas_Todas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Marcas_Todas.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Marcas_Todas.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Marcas_Todas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Marcas_Todas.Checked = True
        Me.Rdb_Marcas_Todas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Marcas_Todas.CheckValue = "Y"
        Me.Rdb_Marcas_Todas.FocusCuesEnabled = False
        Me.Rdb_Marcas_Todas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Marcas_Todas.Location = New System.Drawing.Point(109, 3)
        Me.Rdb_Marcas_Todas.Name = "Rdb_Marcas_Todas"
        Me.Rdb_Marcas_Todas.Size = New System.Drawing.Size(78, 19)
        Me.Rdb_Marcas_Todas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Marcas_Todas.TabIndex = 1
        Me.Rdb_Marcas_Todas.Text = "Todas "
        '
        'TableLayoutPanel8
        '
        Me.TableLayoutPanel8.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel8.ColumnCount = 3
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84.0!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
        Me.TableLayoutPanel8.Controls.Add(Me.LabelX9, 0, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.Rdb_Productos_Algunos, 2, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.Rdb_Productos_Todos, 1, 0)
        Me.TableLayoutPanel8.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel8.Location = New System.Drawing.Point(6, 16)
        Me.TableLayoutPanel8.Name = "TableLayoutPanel8"
        Me.TableLayoutPanel8.RowCount = 1
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel8.Size = New System.Drawing.Size(296, 25)
        Me.TableLayoutPanel8.TabIndex = 53
        '
        'LabelX9
        '
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.ForeColor = System.Drawing.Color.Black
        Me.LabelX9.Location = New System.Drawing.Point(3, 3)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(100, 19)
        Me.LabelX9.TabIndex = 4
        Me.LabelX9.Text = "Productos"
        '
        'Rdb_Productos_Algunos
        '
        Me.Rdb_Productos_Algunos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Productos_Algunos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Productos_Algunos.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Productos_Algunos.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Productos_Algunos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Productos_Algunos.FocusCuesEnabled = False
        Me.Rdb_Productos_Algunos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Productos_Algunos.Location = New System.Drawing.Point(193, 3)
        Me.Rdb_Productos_Algunos.Name = "Rdb_Productos_Algunos"
        Me.Rdb_Productos_Algunos.Size = New System.Drawing.Size(94, 19)
        Me.Rdb_Productos_Algunos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Productos_Algunos.TabIndex = 3
        Me.Rdb_Productos_Algunos.Text = "Algunos"
        '
        'Rdb_Productos_Todos
        '
        Me.Rdb_Productos_Todos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Productos_Todos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Productos_Todos.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Productos_Todos.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Productos_Todos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Productos_Todos.Checked = True
        Me.Rdb_Productos_Todos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Productos_Todos.CheckValue = "Y"
        Me.Rdb_Productos_Todos.FocusCuesEnabled = False
        Me.Rdb_Productos_Todos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Productos_Todos.Location = New System.Drawing.Point(109, 3)
        Me.Rdb_Productos_Todos.Name = "Rdb_Productos_Todos"
        Me.Rdb_Productos_Todos.Size = New System.Drawing.Size(78, 19)
        Me.Rdb_Productos_Todos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Productos_Todos.TabIndex = 1
        Me.Rdb_Productos_Todos.Text = "Todos "
        '
        'Frm_Filtro_Especial_Productos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(330, 300)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Filtro_Especial_Productos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Filtro para productos"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.Panel_Otros_Filtros.ResumeLayout(False)
        Me.Tabla_01.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel8.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_Zonas_Algunas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Zonas_Todas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Tabla_01 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_Clasificacion_Libre_Algunas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Clasificacion_Masisa_Todas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_Marcas_Algunas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Marcas_Todas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_Rubros_Algunos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Rubros_Todos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_Super_Familias_Algunas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Super_Familias_Todas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Btn_Aceptar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents TableLayoutPanel8 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_Productos_Algunos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Productos_Todos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Panel_Otros_Filtros As Panel
End Class
