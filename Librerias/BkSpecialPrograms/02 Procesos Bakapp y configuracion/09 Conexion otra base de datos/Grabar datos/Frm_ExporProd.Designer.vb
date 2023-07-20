<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ExporProd
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ExporProd))
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Chk_SincroEmpresa = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Lbl_Listas = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Bodegas = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Listas = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Bodegas = New DevComponents.DotNetBar.ButtonX()
        Me.Chk_GrbProd_Nuevos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Chk_GrbEnti_Nuevas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_GrbOCC_Nuevas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_SincroProductos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_SincroMarcas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_SincroRubros = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_SincroFamilias = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_SincroClaslib = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_SincroZonasProd = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_SincroZonas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Line1 = New DevComponents.DotNetBar.Controls.Line()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Line2 = New DevComponents.DotNetBar.Controls.Line()
        Me.Chk_SincroTratalote = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Chk_SincroDimensiones = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Chk_SincroEmpresa)
        Me.GroupPanel2.Controls.Add(Me.Lbl_Listas)
        Me.GroupPanel2.Controls.Add(Me.Lbl_Bodegas)
        Me.GroupPanel2.Controls.Add(Me.Btn_Listas)
        Me.GroupPanel2.Controls.Add(Me.Btn_Bodegas)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(24, 81)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(281, 116)
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
        Me.GroupPanel2.TabIndex = 124
        Me.GroupPanel2.Text = "Grabar producto en"
        '
        'Chk_SincroEmpresa
        '
        Me.Chk_SincroEmpresa.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_SincroEmpresa.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_SincroEmpresa.CheckBoxImageChecked = CType(resources.GetObject("Chk_SincroEmpresa.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_SincroEmpresa.ForeColor = System.Drawing.Color.Black
        Me.Chk_SincroEmpresa.Location = New System.Drawing.Point(3, 3)
        Me.Chk_SincroEmpresa.Name = "Chk_SincroEmpresa"
        Me.Chk_SincroEmpresa.Size = New System.Drawing.Size(269, 23)
        Me.Chk_SincroEmpresa.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_SincroEmpresa.TabIndex = 141
        Me.Chk_SincroEmpresa.Text = "Grabar en empresa por defecto"
        '
        'Lbl_Listas
        '
        Me.Lbl_Listas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Listas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Listas.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Listas.Location = New System.Drawing.Point(132, 61)
        Me.Lbl_Listas.Name = "Lbl_Listas"
        Me.Lbl_Listas.Size = New System.Drawing.Size(146, 23)
        Me.Lbl_Listas.TabIndex = 3
        Me.Lbl_Listas.Text = "Listas seleccionadas: 0"
        '
        'Lbl_Bodegas
        '
        Me.Lbl_Bodegas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Bodegas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Bodegas.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Bodegas.Location = New System.Drawing.Point(132, 32)
        Me.Lbl_Bodegas.Name = "Lbl_Bodegas"
        Me.Lbl_Bodegas.Size = New System.Drawing.Size(146, 23)
        Me.Lbl_Bodegas.TabIndex = 2
        Me.Lbl_Bodegas.Text = "Bodegas seleccionadas: 0"
        '
        'Btn_Listas
        '
        Me.Btn_Listas.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Listas.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Listas.Location = New System.Drawing.Point(3, 61)
        Me.Btn_Listas.Name = "Btn_Listas"
        Me.Btn_Listas.Size = New System.Drawing.Size(123, 23)
        Me.Btn_Listas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Listas.TabIndex = 1
        Me.Btn_Listas.Text = "Listas de precio/costo"
        '
        'Btn_Bodegas
        '
        Me.Btn_Bodegas.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Bodegas.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Bodegas.Location = New System.Drawing.Point(3, 32)
        Me.Btn_Bodegas.Name = "Btn_Bodegas"
        Me.Btn_Bodegas.Size = New System.Drawing.Size(123, 23)
        Me.Btn_Bodegas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Bodegas.TabIndex = 0
        Me.Btn_Bodegas.Text = "Bodegas"
        '
        'Chk_GrbProd_Nuevos
        '
        Me.Chk_GrbProd_Nuevos.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_GrbProd_Nuevos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_GrbProd_Nuevos.CheckBoxImageChecked = CType(resources.GetObject("Chk_GrbProd_Nuevos.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_GrbProd_Nuevos.ForeColor = System.Drawing.Color.Black
        Me.Chk_GrbProd_Nuevos.Location = New System.Drawing.Point(12, 52)
        Me.Chk_GrbProd_Nuevos.Name = "Chk_GrbProd_Nuevos"
        Me.Chk_GrbProd_Nuevos.Size = New System.Drawing.Size(293, 23)
        Me.Chk_GrbProd_Nuevos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_GrbProd_Nuevos.TabIndex = 125
        Me.Chk_GrbProd_Nuevos.Text = "Grabar nuevos productos"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar})
        Me.Bar1.Location = New System.Drawing.Point(0, 503)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(339, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 126
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
        Me.Btn_Grabar.Tooltip = "Procesar"
        '
        'Chk_GrbEnti_Nuevas
        '
        Me.Chk_GrbEnti_Nuevas.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_GrbEnti_Nuevas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_GrbEnti_Nuevas.CheckBoxImageChecked = CType(resources.GetObject("Chk_GrbEnti_Nuevas.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_GrbEnti_Nuevas.ForeColor = System.Drawing.Color.Black
        Me.Chk_GrbEnti_Nuevas.Location = New System.Drawing.Point(12, 428)
        Me.Chk_GrbEnti_Nuevas.Name = "Chk_GrbEnti_Nuevas"
        Me.Chk_GrbEnti_Nuevas.Size = New System.Drawing.Size(311, 23)
        Me.Chk_GrbEnti_Nuevas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_GrbEnti_Nuevas.TabIndex = 127
        Me.Chk_GrbEnti_Nuevas.Text = "Grabar Entidades"
        '
        'Chk_GrbOCC_Nuevas
        '
        Me.Chk_GrbOCC_Nuevas.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_GrbOCC_Nuevas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_GrbOCC_Nuevas.CheckBoxImageChecked = CType(resources.GetObject("Chk_GrbOCC_Nuevas.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_GrbOCC_Nuevas.ForeColor = System.Drawing.Color.Black
        Me.Chk_GrbOCC_Nuevas.Location = New System.Drawing.Point(24, 474)
        Me.Chk_GrbOCC_Nuevas.Name = "Chk_GrbOCC_Nuevas"
        Me.Chk_GrbOCC_Nuevas.Size = New System.Drawing.Size(311, 23)
        Me.Chk_GrbOCC_Nuevas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_GrbOCC_Nuevas.TabIndex = 128
        Me.Chk_GrbOCC_Nuevas.Text = "Grabar OCC en la otra empresa"
        '
        'Chk_SincroProductos
        '
        Me.Chk_SincroProductos.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_SincroProductos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_SincroProductos.CheckBoxImageChecked = CType(resources.GetObject("Chk_SincroProductos.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_SincroProductos.ForeColor = System.Drawing.Color.Black
        Me.Chk_SincroProductos.Location = New System.Drawing.Point(3, 3)
        Me.Chk_SincroProductos.Name = "Chk_SincroProductos"
        Me.Chk_SincroProductos.Size = New System.Drawing.Size(275, 18)
        Me.Chk_SincroProductos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_SincroProductos.TabIndex = 129
        Me.Chk_SincroProductos.Text = "Sincronizar productos entre ambas empresas"
        '
        'Chk_SincroMarcas
        '
        Me.Chk_SincroMarcas.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_SincroMarcas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_SincroMarcas.CheckBoxImageChecked = CType(resources.GetObject("Chk_SincroMarcas.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_SincroMarcas.ForeColor = System.Drawing.Color.Black
        Me.Chk_SincroMarcas.Location = New System.Drawing.Point(3, 51)
        Me.Chk_SincroMarcas.Name = "Chk_SincroMarcas"
        Me.Chk_SincroMarcas.Size = New System.Drawing.Size(275, 18)
        Me.Chk_SincroMarcas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_SincroMarcas.TabIndex = 130
        Me.Chk_SincroMarcas.Text = "Sincronizar Marcas"
        '
        'Chk_SincroRubros
        '
        Me.Chk_SincroRubros.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_SincroRubros.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_SincroRubros.CheckBoxImageChecked = CType(resources.GetObject("Chk_SincroRubros.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_SincroRubros.ForeColor = System.Drawing.Color.Black
        Me.Chk_SincroRubros.Location = New System.Drawing.Point(3, 75)
        Me.Chk_SincroRubros.Name = "Chk_SincroRubros"
        Me.Chk_SincroRubros.Size = New System.Drawing.Size(275, 18)
        Me.Chk_SincroRubros.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_SincroRubros.TabIndex = 131
        Me.Chk_SincroRubros.Text = "Sincronizar Rubros"
        '
        'Chk_SincroFamilias
        '
        Me.Chk_SincroFamilias.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_SincroFamilias.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_SincroFamilias.CheckBoxImageChecked = CType(resources.GetObject("Chk_SincroFamilias.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_SincroFamilias.ForeColor = System.Drawing.Color.Black
        Me.Chk_SincroFamilias.Location = New System.Drawing.Point(3, 99)
        Me.Chk_SincroFamilias.Name = "Chk_SincroFamilias"
        Me.Chk_SincroFamilias.Size = New System.Drawing.Size(275, 18)
        Me.Chk_SincroFamilias.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_SincroFamilias.TabIndex = 132
        Me.Chk_SincroFamilias.Text = "Sincronizar Super familias/familias/subfamilias"
        '
        'Chk_SincroClaslib
        '
        Me.Chk_SincroClaslib.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_SincroClaslib.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_SincroClaslib.CheckBoxImageChecked = CType(resources.GetObject("Chk_SincroClaslib.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_SincroClaslib.ForeColor = System.Drawing.Color.Black
        Me.Chk_SincroClaslib.Location = New System.Drawing.Point(3, 123)
        Me.Chk_SincroClaslib.Name = "Chk_SincroClaslib"
        Me.Chk_SincroClaslib.Size = New System.Drawing.Size(275, 18)
        Me.Chk_SincroClaslib.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_SincroClaslib.TabIndex = 133
        Me.Chk_SincroClaslib.Text = "Sincronizar Clasificación libre"
        '
        'Chk_SincroZonasProd
        '
        Me.Chk_SincroZonasProd.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_SincroZonasProd.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_SincroZonasProd.CheckBoxImageChecked = CType(resources.GetObject("Chk_SincroZonasProd.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_SincroZonasProd.ForeColor = System.Drawing.Color.Black
        Me.Chk_SincroZonasProd.Location = New System.Drawing.Point(3, 147)
        Me.Chk_SincroZonasProd.Name = "Chk_SincroZonasProd"
        Me.Chk_SincroZonasProd.Size = New System.Drawing.Size(275, 18)
        Me.Chk_SincroZonasProd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_SincroZonasProd.TabIndex = 134
        Me.Chk_SincroZonasProd.Text = "Sincronizar Zonas (producto)"
        '
        'Chk_SincroZonas
        '
        Me.Chk_SincroZonas.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_SincroZonas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_SincroZonas.CheckBoxImageChecked = CType(resources.GetObject("Chk_SincroZonas.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_SincroZonas.ForeColor = System.Drawing.Color.Black
        Me.Chk_SincroZonas.Location = New System.Drawing.Point(24, 453)
        Me.Chk_SincroZonas.Name = "Chk_SincroZonas"
        Me.Chk_SincroZonas.Size = New System.Drawing.Size(293, 23)
        Me.Chk_SincroZonas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_SincroZonas.TabIndex = 135
        Me.Chk_SincroZonas.Text = "Sincronizar Zonas"
        '
        'Line1
        '
        Me.Line1.BackColor = System.Drawing.Color.White
        Me.Line1.ForeColor = System.Drawing.Color.Black
        Me.Line1.Location = New System.Drawing.Point(66, 399)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(257, 23)
        Me.Line1.TabIndex = 136
        Me.Line1.Text = "Line1"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(10, 399)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(57, 23)
        Me.LabelX1.TabIndex = 137
        Me.LabelX1.Text = "Entidades"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(10, 23)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(57, 23)
        Me.LabelX2.TabIndex = 139
        Me.LabelX2.Text = "Productos"
        '
        'Line2
        '
        Me.Line2.BackColor = System.Drawing.Color.White
        Me.Line2.ForeColor = System.Drawing.Color.Black
        Me.Line2.Location = New System.Drawing.Point(66, 23)
        Me.Line2.Name = "Line2"
        Me.Line2.Size = New System.Drawing.Size(257, 23)
        Me.Line2.TabIndex = 138
        Me.Line2.Text = "Line2"
        '
        'Chk_SincroTratalote
        '
        Me.Chk_SincroTratalote.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_SincroTratalote.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_SincroTratalote.CheckBoxImageChecked = CType(resources.GetObject("Chk_SincroTratalote.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_SincroTratalote.ForeColor = System.Drawing.Color.Black
        Me.Chk_SincroTratalote.Location = New System.Drawing.Point(3, 27)
        Me.Chk_SincroTratalote.Name = "Chk_SincroTratalote"
        Me.Chk_SincroTratalote.Size = New System.Drawing.Size(275, 18)
        Me.Chk_SincroTratalote.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_SincroTratalote.TabIndex = 140
        Me.Chk_SincroTratalote.Text = "Sincronizar tratamiento por lotes"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Chk_SincroDimensiones, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.Chk_SincroMarcas, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Chk_SincroRubros, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Chk_SincroFamilias, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Chk_SincroClaslib, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Chk_SincroZonasProd, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Chk_SincroTratalote, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Chk_SincroProductos, 0, 0)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(24, 203)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 8
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(281, 190)
        Me.TableLayoutPanel1.TabIndex = 141
        '
        'Chk_SincroDimensiones
        '
        Me.Chk_SincroDimensiones.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_SincroDimensiones.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_SincroDimensiones.CheckBoxImageChecked = CType(resources.GetObject("Chk_SincroDimensiones.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_SincroDimensiones.ForeColor = System.Drawing.Color.Black
        Me.Chk_SincroDimensiones.Location = New System.Drawing.Point(3, 171)
        Me.Chk_SincroDimensiones.Name = "Chk_SincroDimensiones"
        Me.Chk_SincroDimensiones.Size = New System.Drawing.Size(275, 16)
        Me.Chk_SincroDimensiones.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_SincroDimensiones.TabIndex = 142
        Me.Chk_SincroDimensiones.Text = "Sincronizar Dimensiones"
        '
        'Frm_ExporProd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(339, 544)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.Line2)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Line1)
        Me.Controls.Add(Me.Chk_SincroZonas)
        Me.Controls.Add(Me.Chk_GrbOCC_Nuevas)
        Me.Controls.Add(Me.Chk_GrbEnti_Nuevas)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.Chk_GrbProd_Nuevos)
        Me.Controls.Add(Me.GroupPanel2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_ExporProd"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Grabaciones automáticas"
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Chk_GrbProd_Nuevos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Chk_GrbEnti_Nuevas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Lbl_Listas As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Bodegas As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Listas As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Bodegas As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Chk_GrbOCC_Nuevas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_SincroProductos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_SincroMarcas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_SincroRubros As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_SincroFamilias As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_SincroClaslib As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_SincroZonasProd As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_SincroZonas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Line1 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Line2 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents Chk_SincroTratalote As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_SincroEmpresa As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Chk_SincroDimensiones As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
