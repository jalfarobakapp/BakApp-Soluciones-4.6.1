<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Parejas_Plan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Parejas_Plan))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_Operadores = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Editar_Operador = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Eliminar_Operador = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Agregar_Ubicaciones = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Quitar_Ubicaciones = New DevComponents.DotNetBar.ButtonItem()
        Me.Tabs = New DevComponents.DotNetBar.SuperTabStrip()
        Me.TabToma = New DevComponents.DotNetBar.SuperTabItem()
        Me.TabLevante = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabItem1 = New DevComponents.DotNetBar.SuperTabItem()
        Me.Cmb_Bodegas = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.GroupPanel4 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Txt_UbicAsignadas = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_UbicContadas = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_PorcAvance = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tabs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        Me.GroupPanel3.SuspendLayout()
        Me.GroupPanel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.ContextMenuBar1)
        Me.GroupPanel1.Controls.Add(Me.Grilla)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 76)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(868, 378)
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
        Me.GroupPanel1.TabIndex = 42
        Me.GroupPanel1.Text = "Parejas"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_Operadores})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(31, 37)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(360, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 48
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_Operadores
        '
        Me.Menu_Contextual_Operadores.AutoExpandOnClick = True
        Me.Menu_Contextual_Operadores.Name = "Menu_Contextual_Operadores"
        Me.Menu_Contextual_Operadores.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Editar_Operador, Me.Btn_Eliminar_Operador})
        Me.Menu_Contextual_Operadores.Text = "Opciones"
        '
        'Btn_Editar_Operador
        '
        Me.Btn_Editar_Operador.Image = CType(resources.GetObject("Btn_Editar_Operador.Image"), System.Drawing.Image)
        Me.Btn_Editar_Operador.Name = "Btn_Editar_Operador"
        Me.Btn_Editar_Operador.Text = "Asociar ubcaciones"
        Me.Btn_Editar_Operador.Tooltip = "Dar "
        '
        'Btn_Eliminar_Operador
        '
        Me.Btn_Eliminar_Operador.Image = CType(resources.GetObject("Btn_Eliminar_Operador.Image"), System.Drawing.Image)
        Me.Btn_Eliminar_Operador.Name = "Btn_Eliminar_Operador"
        Me.Btn_Eliminar_Operador.Text = "CONFIRMAR "
        Me.Btn_Eliminar_Operador.Tooltip = "Dar "
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla.EnableHeadersVisualStyles = False
        Me.Grilla.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla.Location = New System.Drawing.Point(0, 0)
        Me.Grilla.Name = "Grilla"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla.Size = New System.Drawing.Size(862, 355)
        Me.Grilla.StandardTab = True
        Me.Grilla.TabIndex = 30
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Agregar_Ubicaciones, Me.Btn_Quitar_Ubicaciones})
        Me.Bar1.Location = New System.Drawing.Point(0, 520)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(889, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 41
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Agregar_Ubicaciones
        '
        Me.Btn_Agregar_Ubicaciones.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Agregar_Ubicaciones.ForeColor = System.Drawing.Color.Black
        Me.Btn_Agregar_Ubicaciones.Image = CType(resources.GetObject("Btn_Agregar_Ubicaciones.Image"), System.Drawing.Image)
        Me.Btn_Agregar_Ubicaciones.Name = "Btn_Agregar_Ubicaciones"
        Me.Btn_Agregar_Ubicaciones.Tooltip = "Agregar ubicacione para la Toma"
        '
        'Btn_Quitar_Ubicaciones
        '
        Me.Btn_Quitar_Ubicaciones.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Quitar_Ubicaciones.ForeColor = System.Drawing.Color.Black
        Me.Btn_Quitar_Ubicaciones.Image = CType(resources.GetObject("Btn_Quitar_Ubicaciones.Image"), System.Drawing.Image)
        Me.Btn_Quitar_Ubicaciones.Name = "Btn_Quitar_Ubicaciones"
        Me.Btn_Quitar_Ubicaciones.Tooltip = "Quitar ubicaciones"
        '
        'Tabs
        '
        Me.Tabs.AutoSelectAttachedControl = False
        Me.Tabs.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Tabs.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Tabs.ContainerControlProcessDialogKey = True
        '
        '
        '
        '
        '
        '
        Me.Tabs.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.Tabs.ControlBox.MenuBox.Name = ""
        Me.Tabs.ControlBox.Name = ""
        Me.Tabs.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Tabs.ControlBox.MenuBox, Me.Tabs.ControlBox.CloseBox})
        Me.Tabs.ForeColor = System.Drawing.Color.Black
        Me.Tabs.Location = New System.Drawing.Point(12, 43)
        Me.Tabs.Name = "Tabs"
        Me.Tabs.ReorderTabsEnabled = True
        Me.Tabs.SelectedTabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Tabs.SelectedTabIndex = 0
        Me.Tabs.Size = New System.Drawing.Size(868, 27)
        Me.Tabs.TabCloseButtonHot = Nothing
        Me.Tabs.TabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tabs.TabIndex = 43
        Me.Tabs.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.TabToma, Me.TabLevante, Me.SuperTabItem1})
        Me.Tabs.Text = "SuperTabStrip1"
        '
        'TabToma
        '
        Me.TabToma.GlobalItem = False
        Me.TabToma.Name = "TabToma"
        Me.TabToma.Tag = "TOMA"
        Me.TabToma.Text = "Toma"
        '
        'TabLevante
        '
        Me.TabLevante.GlobalItem = False
        Me.TabLevante.Name = "TabLevante"
        Me.TabLevante.Tag = "LEVANTE"
        Me.TabLevante.Text = "Levante"
        '
        'SuperTabItem1
        '
        Me.SuperTabItem1.GlobalItem = False
        Me.SuperTabItem1.Name = "SuperTabItem1"
        Me.SuperTabItem1.Tag = "RECONTEO"
        Me.SuperTabItem1.Text = "Reconteo"
        Me.SuperTabItem1.Visible = False
        '
        'Cmb_Bodegas
        '
        Me.Cmb_Bodegas.DisplayMember = "Text"
        Me.Cmb_Bodegas.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Bodegas.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Bodegas.FormattingEnabled = True
        Me.Cmb_Bodegas.ItemHeight = 16
        Me.Cmb_Bodegas.Location = New System.Drawing.Point(66, 13)
        Me.Cmb_Bodegas.Name = "Cmb_Bodegas"
        Me.Cmb_Bodegas.Size = New System.Drawing.Size(442, 22)
        Me.Cmb_Bodegas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Bodegas.TabIndex = 45
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(12, 12)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(45, 23)
        Me.LabelX1.TabIndex = 44
        Me.LabelX1.Text = "Bodega"
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Txt_UbicAsignadas)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(529, 460)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(113, 54)
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
        Me.GroupPanel2.Text = "Ubic. Asignadas"
        '
        'GroupPanel3
        '
        Me.GroupPanel3.BackColor = System.Drawing.Color.White
        Me.GroupPanel3.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.Txt_UbicContadas)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Location = New System.Drawing.Point(648, 460)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(113, 54)
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
        Me.GroupPanel3.TabIndex = 47
        Me.GroupPanel3.Text = "Ubic. Contadas"
        '
        'GroupPanel4
        '
        Me.GroupPanel4.BackColor = System.Drawing.Color.White
        Me.GroupPanel4.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel4.Controls.Add(Me.Txt_PorcAvance)
        Me.GroupPanel4.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel4.Location = New System.Drawing.Point(767, 460)
        Me.GroupPanel4.Name = "GroupPanel4"
        Me.GroupPanel4.Size = New System.Drawing.Size(113, 54)
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
        Me.GroupPanel4.TabIndex = 48
        Me.GroupPanel4.Text = "Est. Avance"
        '
        'Txt_UbicAsignadas
        '
        Me.Txt_UbicAsignadas.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_UbicAsignadas.Border.Class = "TextBoxBorder"
        Me.Txt_UbicAsignadas.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_UbicAsignadas.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_UbicAsignadas.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_UbicAsignadas.ForeColor = System.Drawing.Color.Black
        Me.Txt_UbicAsignadas.Location = New System.Drawing.Point(4, 3)
        Me.Txt_UbicAsignadas.Name = "Txt_UbicAsignadas"
        Me.Txt_UbicAsignadas.PreventEnterBeep = True
        Me.Txt_UbicAsignadas.ReadOnly = True
        Me.Txt_UbicAsignadas.Size = New System.Drawing.Size(100, 27)
        Me.Txt_UbicAsignadas.TabIndex = 49
        Me.Txt_UbicAsignadas.Text = "125"
        Me.Txt_UbicAsignadas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Txt_UbicContadas
        '
        Me.Txt_UbicContadas.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_UbicContadas.Border.Class = "TextBoxBorder"
        Me.Txt_UbicContadas.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_UbicContadas.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_UbicContadas.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_UbicContadas.ForeColor = System.Drawing.Color.Black
        Me.Txt_UbicContadas.Location = New System.Drawing.Point(3, 3)
        Me.Txt_UbicContadas.Name = "Txt_UbicContadas"
        Me.Txt_UbicContadas.PreventEnterBeep = True
        Me.Txt_UbicContadas.ReadOnly = True
        Me.Txt_UbicContadas.Size = New System.Drawing.Size(100, 27)
        Me.Txt_UbicContadas.TabIndex = 50
        Me.Txt_UbicContadas.Text = "52"
        Me.Txt_UbicContadas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Txt_PorcAvance
        '
        Me.Txt_PorcAvance.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_PorcAvance.Border.Class = "TextBoxBorder"
        Me.Txt_PorcAvance.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_PorcAvance.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_PorcAvance.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_PorcAvance.ForeColor = System.Drawing.Color.Black
        Me.Txt_PorcAvance.Location = New System.Drawing.Point(3, 3)
        Me.Txt_PorcAvance.Name = "Txt_PorcAvance"
        Me.Txt_PorcAvance.PreventEnterBeep = True
        Me.Txt_PorcAvance.ReadOnly = True
        Me.Txt_PorcAvance.Size = New System.Drawing.Size(100, 27)
        Me.Txt_PorcAvance.TabIndex = 50
        Me.Txt_PorcAvance.Text = "58.5 %"
        Me.Txt_PorcAvance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Frm_Parejas_Plan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(889, 561)
        Me.Controls.Add(Me.GroupPanel4)
        Me.Controls.Add(Me.GroupPanel3)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.Cmb_Bodegas)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Tabs)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Parejas_Plan"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tabs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        Me.GroupPanel3.ResumeLayout(False)
        Me.GroupPanel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_Operadores As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Editar_Operador As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Eliminar_Operador As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Agregar_Ubicaciones As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Tabs As DevComponents.DotNetBar.SuperTabStrip
    Friend WithEvents TabToma As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents TabLevante As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents Cmb_Bodegas As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents SuperTabItem1 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents Btn_Quitar_Ubicaciones As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Txt_UbicAsignadas As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Txt_UbicContadas As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents GroupPanel4 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Txt_PorcAvance As DevComponents.DotNetBar.Controls.TextBoxX
End Class
