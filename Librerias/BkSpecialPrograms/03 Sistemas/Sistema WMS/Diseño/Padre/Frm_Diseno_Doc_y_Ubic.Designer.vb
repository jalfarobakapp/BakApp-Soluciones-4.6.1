<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Diseno_Doc_y_Ubic
    Inherits DevComponents.DotNetBar.RibbonForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Diseno_Doc_y_Ubic))
        Me.RibbonControl1 = New DevComponents.DotNetBar.RibbonControl()
        Me.RibbonPanel1 = New DevComponents.DotNetBar.RibbonPanel()
        Me.RibbonBar3 = New DevComponents.DotNetBar.RibbonBar()
        Me.Btn_Sectores = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonBar1 = New DevComponents.DotNetBar.RibbonBar()
        Me.Btn_NuevoMapa = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonBar8 = New DevComponents.DotNetBar.RibbonBar()
        Me.ItemContainer9 = New DevComponents.DotNetBar.ItemContainer()
        Me.Sld_Ubicacion_Y = New DevComponents.DotNetBar.SliderItem()
        Me.Sld_Ubicacion_X = New DevComponents.DotNetBar.SliderItem()
        Me.RibbonBar7 = New DevComponents.DotNetBar.RibbonBar()
        Me.ItemContainer8 = New DevComponents.DotNetBar.ItemContainer()
        Me.Sld_Tam_Alto = New DevComponents.DotNetBar.SliderItem()
        Me.Sld_Tam_Ancho = New DevComponents.DotNetBar.SliderItem()
        Me.RibbonBar2 = New DevComponents.DotNetBar.RibbonBar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonTabItem1 = New DevComponents.DotNetBar.RibbonTabItem()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.ButtonItem17 = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem5 = New DevComponents.DotNetBar.LabelItem()
        Me.SliderItem7 = New DevComponents.DotNetBar.SliderItem()
        Me.SliderItem8 = New DevComponents.DotNetBar.SliderItem()
        Me.LabelItem6 = New DevComponents.DotNetBar.LabelItem()
        Me.SliderItem9 = New DevComponents.DotNetBar.SliderItem()
        Me.SliderItem10 = New DevComponents.DotNetBar.SliderItem()
        Me.SliderItem4 = New DevComponents.DotNetBar.SliderItem()
        Me.tabStrip1 = New DevComponents.DotNetBar.TabStrip()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_Opciones_Mapa = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem4 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Mnu_Editar_Mapa = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Eliminar_Mapa = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Exportar_Excel = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Exportar_Excel_Sectores = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Exportar_Excel_Ubicaciones = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Exportar_Excel_Productos = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonControl1.SuspendLayout()
        Me.RibbonPanel1.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControl1
        '
        Me.RibbonControl1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.RibbonControl1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonControl1.CanCustomize = False
        Me.RibbonControl1.CaptionVisible = True
        Me.RibbonControl1.Controls.Add(Me.RibbonPanel1)
        Me.RibbonControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.RibbonControl1.Expanded = False
        Me.RibbonControl1.ForeColor = System.Drawing.Color.Black
        Me.RibbonControl1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.RibbonTabItem1})
        Me.RibbonControl1.KeyTipsFont = New System.Drawing.Font("Tahoma", 7.0!)
        Me.RibbonControl1.Location = New System.Drawing.Point(5, 1)
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Size = New System.Drawing.Size(921, 154)
        Me.RibbonControl1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonControl1.SystemText.MaximizeRibbonText = "&Maximize the Ribbon"
        Me.RibbonControl1.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon"
        Me.RibbonControl1.SystemText.QatAddItemText = "&Add to Quick Access Toolbar"
        Me.RibbonControl1.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>"
        Me.RibbonControl1.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar..."
        Me.RibbonControl1.SystemText.QatDialogAddButton = "&Add >>"
        Me.RibbonControl1.SystemText.QatDialogCancelButton = "Cancel"
        Me.RibbonControl1.SystemText.QatDialogCaption = "Customize Quick Access Toolbar"
        Me.RibbonControl1.SystemText.QatDialogCategoriesLabel = "&Choose commands from:"
        Me.RibbonControl1.SystemText.QatDialogOkButton = "OK"
        Me.RibbonControl1.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon"
        Me.RibbonControl1.SystemText.QatDialogRemoveButton = "&Remove"
        Me.RibbonControl1.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon"
        Me.RibbonControl1.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon"
        Me.RibbonControl1.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar"
        Me.RibbonControl1.TabGroupHeight = 14
        Me.RibbonControl1.TabIndex = 0
        Me.RibbonControl1.Text = "RibbonControl1"
        '
        'RibbonPanel1
        '
        Me.RibbonPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonPanel1.Controls.Add(Me.RibbonBar3)
        Me.RibbonPanel1.Controls.Add(Me.RibbonBar1)
        Me.RibbonPanel1.Controls.Add(Me.RibbonBar8)
        Me.RibbonPanel1.Controls.Add(Me.RibbonBar7)
        Me.RibbonPanel1.Controls.Add(Me.RibbonBar2)
        Me.RibbonPanel1.Location = New System.Drawing.Point(0, 54)
        Me.RibbonPanel1.Name = "RibbonPanel1"
        Me.RibbonPanel1.Padding = New System.Windows.Forms.Padding(3, 0, 3, 2)
        Me.RibbonPanel1.Size = New System.Drawing.Size(921, 100)
        '
        '
        '
        Me.RibbonPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonPanel1.TabIndex = 1
        '
        'RibbonBar3
        '
        Me.RibbonBar3.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar3.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar3.ContainerControlProcessDialogKey = True
        Me.RibbonBar3.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar3.DragDropSupport = True
        Me.RibbonBar3.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Sectores})
        Me.RibbonBar3.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.RibbonBar3.Location = New System.Drawing.Point(571, 0)
        Me.RibbonBar3.Name = "RibbonBar3"
        Me.RibbonBar3.Size = New System.Drawing.Size(101, 98)
        Me.RibbonBar3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar3.TabIndex = 9
        '
        '
        '
        Me.RibbonBar3.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar3.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'Btn_Sectores
        '
        Me.Btn_Sectores.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Sectores.Image = CType(resources.GetObject("Btn_Sectores.Image"), System.Drawing.Image)
        Me.Btn_Sectores.Name = "Btn_Sectores"
        Me.Btn_Sectores.SubItemsExpandWidth = 14
        Me.Btn_Sectores.Text = "Manejo de " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Cabeceras"
        '
        'RibbonBar1
        '
        Me.RibbonBar1.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar1.ContainerControlProcessDialogKey = True
        Me.RibbonBar1.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar1.DragDropSupport = True
        Me.RibbonBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_NuevoMapa})
        Me.RibbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.RibbonBar1.Location = New System.Drawing.Point(417, 0)
        Me.RibbonBar1.Name = "RibbonBar1"
        Me.RibbonBar1.Size = New System.Drawing.Size(154, 98)
        Me.RibbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar1.TabIndex = 8
        '
        '
        '
        Me.RibbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'Btn_NuevoMapa
        '
        Me.Btn_NuevoMapa.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_NuevoMapa.Image = CType(resources.GetObject("Btn_NuevoMapa.Image"), System.Drawing.Image)
        Me.Btn_NuevoMapa.Name = "Btn_NuevoMapa"
        Me.Btn_NuevoMapa.SubItemsExpandWidth = 14
        Me.Btn_NuevoMapa.Text = "Crear nuevo mapa"
        '
        'RibbonBar8
        '
        Me.RibbonBar8.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar8.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar8.ContainerControlProcessDialogKey = True
        Me.RibbonBar8.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar8.DragDropSupport = True
        Me.RibbonBar8.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer9})
        Me.RibbonBar8.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.RibbonBar8.Location = New System.Drawing.Point(237, 0)
        Me.RibbonBar8.Name = "RibbonBar8"
        Me.RibbonBar8.Size = New System.Drawing.Size(180, 98)
        Me.RibbonBar8.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar8.TabIndex = 7
        Me.RibbonBar8.Text = "Ubicación Objeto"
        '
        '
        '
        Me.RibbonBar8.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar8.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'ItemContainer9
        '
        '
        '
        '
        Me.ItemContainer9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer9.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemContainer9.Name = "ItemContainer9"
        Me.ItemContainer9.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Sld_Ubicacion_Y, Me.Sld_Ubicacion_X})
        '
        '
        '
        Me.ItemContainer9.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer9.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
        '
        'Sld_Ubicacion_Y
        '
        Me.Sld_Ubicacion_Y.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar
        Me.Sld_Ubicacion_Y.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center
        Me.Sld_Ubicacion_Y.Name = "Sld_Ubicacion_Y"
        Me.Sld_Ubicacion_Y.Text = "Fila"
        Me.Sld_Ubicacion_Y.Value = 0
        '
        'Sld_Ubicacion_X
        '
        Me.Sld_Ubicacion_X.Name = "Sld_Ubicacion_X"
        Me.Sld_Ubicacion_X.Text = "Columna"
        Me.Sld_Ubicacion_X.Value = 0
        '
        'RibbonBar7
        '
        Me.RibbonBar7.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar7.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar7.ContainerControlProcessDialogKey = True
        Me.RibbonBar7.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar7.DragDropSupport = True
        Me.RibbonBar7.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer8})
        Me.RibbonBar7.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.RibbonBar7.Location = New System.Drawing.Point(57, 0)
        Me.RibbonBar7.Name = "RibbonBar7"
        Me.RibbonBar7.Size = New System.Drawing.Size(180, 98)
        Me.RibbonBar7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar7.TabIndex = 6
        Me.RibbonBar7.Text = "Tamaño objeto"
        '
        '
        '
        Me.RibbonBar7.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar7.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'ItemContainer8
        '
        '
        '
        '
        Me.ItemContainer8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer8.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemContainer8.Name = "ItemContainer8"
        Me.ItemContainer8.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Sld_Tam_Alto, Me.Sld_Tam_Ancho})
        '
        '
        '
        Me.ItemContainer8.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer8.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
        '
        'Sld_Tam_Alto
        '
        Me.Sld_Tam_Alto.Name = "Sld_Tam_Alto"
        Me.Sld_Tam_Alto.Step = 10
        Me.Sld_Tam_Alto.Text = "Alto"
        Me.Sld_Tam_Alto.Value = 0
        '
        'Sld_Tam_Ancho
        '
        Me.Sld_Tam_Ancho.Name = "Sld_Tam_Ancho"
        Me.Sld_Tam_Ancho.Step = 10
        Me.Sld_Tam_Ancho.Text = "Ancho"
        Me.Sld_Tam_Ancho.Value = 0
        '
        'RibbonBar2
        '
        Me.RibbonBar2.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar2.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar2.ContainerControlProcessDialogKey = True
        Me.RibbonBar2.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar2.DragDropSupport = True
        Me.RibbonBar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar})
        Me.RibbonBar2.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.RibbonBar2.Location = New System.Drawing.Point(3, 0)
        Me.RibbonBar2.Name = "RibbonBar2"
        Me.RibbonBar2.Size = New System.Drawing.Size(54, 98)
        Me.RibbonBar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar2.TabIndex = 1
        '
        '
        '
        Me.RibbonBar2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar2.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.SubItemsExpandWidth = 14
        Me.Btn_Grabar.Text = "Grabar"
        '
        'RibbonTabItem1
        '
        Me.RibbonTabItem1.Checked = True
        Me.RibbonTabItem1.Name = "RibbonTabItem1"
        Me.RibbonTabItem1.Panel = Me.RibbonPanel1
        Me.RibbonTabItem1.Text = "Inicio"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Location = New System.Drawing.Point(24, 33)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(796, 385)
        Me.Panel2.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Location = New System.Drawing.Point(24, 33)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(796, 385)
        Me.Panel3.TabIndex = 0
        '
        'ButtonItem17
        '
        Me.ButtonItem17.AutoExpandOnClick = True
        Me.ButtonItem17.Name = "ButtonItem17"
        Me.ButtonItem17.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem5, Me.SliderItem7, Me.SliderItem8, Me.LabelItem6, Me.SliderItem9, Me.SliderItem10})
        Me.ButtonItem17.Text = "ButtonItem16"
        '
        'LabelItem5
        '
        Me.LabelItem5.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem5.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem5.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem5.Name = "LabelItem5"
        Me.LabelItem5.PaddingBottom = 1
        Me.LabelItem5.PaddingLeft = 10
        Me.LabelItem5.PaddingTop = 1
        Me.LabelItem5.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem5.Text = "LabelItem3"
        '
        'SliderItem7
        '
        Me.SliderItem7.Name = "SliderItem7"
        Me.SliderItem7.Text = "SliderItem3"
        Me.SliderItem7.Value = 0
        '
        'SliderItem8
        '
        Me.SliderItem8.Name = "SliderItem8"
        Me.SliderItem8.Text = "SliderItem4"
        Me.SliderItem8.Value = 0
        '
        'LabelItem6
        '
        Me.LabelItem6.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem6.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem6.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem6.Name = "LabelItem6"
        Me.LabelItem6.PaddingBottom = 1
        Me.LabelItem6.PaddingLeft = 10
        Me.LabelItem6.PaddingTop = 1
        Me.LabelItem6.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem6.Text = "LabelItem4"
        '
        'SliderItem9
        '
        Me.SliderItem9.Name = "SliderItem9"
        Me.SliderItem9.Text = "SliderItem5"
        Me.SliderItem9.Value = 0
        '
        'SliderItem10
        '
        Me.SliderItem10.Name = "SliderItem10"
        Me.SliderItem10.Text = "SliderItem6"
        Me.SliderItem10.Value = 0
        '
        'SliderItem4
        '
        Me.SliderItem4.Name = "SliderItem4"
        Me.SliderItem4.Text = "SliderItem2"
        Me.SliderItem4.Value = 0
        '
        'tabStrip1
        '
        Me.tabStrip1.AutoSelectAttachedControl = True
        Me.tabStrip1.CanReorderTabs = True
        Me.tabStrip1.CloseButtonOnTabsVisible = True
        Me.tabStrip1.CloseButtonVisible = False
        Me.tabStrip1.Dock = System.Windows.Forms.DockStyle.Top
        Me.tabStrip1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabStrip1.ForeColor = System.Drawing.Color.Black
        Me.tabStrip1.Location = New System.Drawing.Point(5, 155)
        Me.tabStrip1.MdiForm = Me
        Me.tabStrip1.MdiTabbedDocuments = True
        Me.tabStrip1.Name = "tabStrip1"
        Me.tabStrip1.SelectedTab = Nothing
        Me.tabStrip1.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabStrip1.Size = New System.Drawing.Size(921, 26)
        Me.tabStrip1.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
        Me.tabStrip1.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Top
        Me.tabStrip1.TabIndex = 10
        Me.tabStrip1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.tabStrip1.Text = "tabStrip1"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_Opciones_Mapa})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(306, 230)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(319, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 48
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_Opciones_Mapa
        '
        Me.Menu_Contextual_Opciones_Mapa.AutoExpandOnClick = True
        Me.Menu_Contextual_Opciones_Mapa.Name = "Menu_Contextual_Opciones_Mapa"
        Me.Menu_Contextual_Opciones_Mapa.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem4, Me.Btn_Mnu_Editar_Mapa, Me.Btn_Mnu_Eliminar_Mapa, Me.LabelItem1, Me.Btn_Exportar_Excel})
        Me.Menu_Contextual_Opciones_Mapa.Text = "Opciones diseño de mapa"
        '
        'LabelItem4
        '
        Me.LabelItem4.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem4.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem4.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem4.Name = "LabelItem4"
        Me.LabelItem4.PaddingBottom = 1
        Me.LabelItem4.PaddingLeft = 10
        Me.LabelItem4.PaddingTop = 1
        Me.LabelItem4.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem4.Text = "Opciones del mapa"
        '
        'Btn_Mnu_Editar_Mapa
        '
        Me.Btn_Mnu_Editar_Mapa.Image = CType(resources.GetObject("Btn_Mnu_Editar_Mapa.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Editar_Mapa.Name = "Btn_Mnu_Editar_Mapa"
        Me.Btn_Mnu_Editar_Mapa.Text = "Cambiar el nombre al mapa"
        '
        'Btn_Mnu_Eliminar_Mapa
        '
        Me.Btn_Mnu_Eliminar_Mapa.Image = CType(resources.GetObject("Btn_Mnu_Eliminar_Mapa.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Eliminar_Mapa.Name = "Btn_Mnu_Eliminar_Mapa"
        Me.Btn_Mnu_Eliminar_Mapa.Text = "Eliminar Mapa"
        '
        'LabelItem1
        '
        Me.LabelItem1.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem1.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem1.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem1.Name = "LabelItem1"
        Me.LabelItem1.PaddingBottom = 1
        Me.LabelItem1.PaddingLeft = 10
        Me.LabelItem1.PaddingTop = 1
        Me.LabelItem1.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem1.Text = "Exportar datos"
        '
        'Btn_Exportar_Excel
        '
        Me.Btn_Exportar_Excel.Image = CType(resources.GetObject("Btn_Exportar_Excel.Image"), System.Drawing.Image)
        Me.Btn_Exportar_Excel.Name = "Btn_Exportar_Excel"
        Me.Btn_Exportar_Excel.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Exportar_Excel_Sectores, Me.Btn_Exportar_Excel_Ubicaciones, Me.Btn_Exportar_Excel_Productos})
        Me.Btn_Exportar_Excel.Text = "Exportar a Excel"
        '
        'Btn_Exportar_Excel_Sectores
        '
        Me.Btn_Exportar_Excel_Sectores.Image = CType(resources.GetObject("Btn_Exportar_Excel_Sectores.Image"), System.Drawing.Image)
        Me.Btn_Exportar_Excel_Sectores.Name = "Btn_Exportar_Excel_Sectores"
        Me.Btn_Exportar_Excel_Sectores.Text = "Exportar Sectores dentro del mapa"
        '
        'Btn_Exportar_Excel_Ubicaciones
        '
        Me.Btn_Exportar_Excel_Ubicaciones.Image = CType(resources.GetObject("Btn_Exportar_Excel_Ubicaciones.Image"), System.Drawing.Image)
        Me.Btn_Exportar_Excel_Ubicaciones.Name = "Btn_Exportar_Excel_Ubicaciones"
        Me.Btn_Exportar_Excel_Ubicaciones.Text = "Exportar Ubicaciones dentro del mapa"
        '
        'Btn_Exportar_Excel_Productos
        '
        Me.Btn_Exportar_Excel_Productos.Image = CType(resources.GetObject("Btn_Exportar_Excel_Productos.Image"), System.Drawing.Image)
        Me.Btn_Exportar_Excel_Productos.Name = "Btn_Exportar_Excel_Productos"
        Me.Btn_Exportar_Excel_Productos.Text = "Exportar Productos dentro del mapa"
        '
        'Frm_Diseno_Doc_y_Ubic
        '
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(931, 477)
        Me.Controls.Add(Me.ContextMenuBar1)
        Me.Controls.Add(Me.tabStrip1)
        Me.Controls.Add(Me.RibbonControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "Frm_Diseno_Doc_y_Ubic"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Frm_ImpresionDoc_Configuracion"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.RibbonControl1.ResumeLayout(False)
        Me.RibbonControl1.PerformLayout()
        Me.RibbonPanel1.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RibbonControl1 As DevComponents.DotNetBar.RibbonControl
    Friend WithEvents RibbonPanel1 As DevComponents.DotNetBar.RibbonPanel
    Friend WithEvents RibbonTabItem1 As DevComponents.DotNetBar.RibbonTabItem
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents RibbonBar2 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem17 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem5 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents SliderItem7 As DevComponents.DotNetBar.SliderItem
    Friend WithEvents SliderItem8 As DevComponents.DotNetBar.SliderItem
    Friend WithEvents LabelItem6 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents SliderItem9 As DevComponents.DotNetBar.SliderItem
    Friend WithEvents SliderItem10 As DevComponents.DotNetBar.SliderItem
    Friend WithEvents RibbonBar7 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents ItemContainer8 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents SliderItem4 As DevComponents.DotNetBar.SliderItem
    Friend WithEvents RibbonBar8 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents ItemContainer9 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Public WithEvents Sld_Tam_Alto As DevComponents.DotNetBar.SliderItem
    Public WithEvents Sld_Tam_Ancho As DevComponents.DotNetBar.SliderItem
    Public WithEvents Sld_Ubicacion_X As DevComponents.DotNetBar.SliderItem
    Public WithEvents Sld_Ubicacion_Y As DevComponents.DotNetBar.SliderItem
    Private WithEvents tabStrip1 As DevComponents.DotNetBar.TabStrip
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_Opciones_Mapa As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem4 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Mnu_Editar_Mapa As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_Eliminar_Mapa As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Exportar_Excel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Exportar_Excel_Sectores As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Exportar_Excel_Ubicaciones As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Exportar_Excel_Productos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents RibbonBar1 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents Btn_NuevoMapa As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents RibbonBar3 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents Btn_Sectores As DevComponents.DotNetBar.ButtonItem
End Class
