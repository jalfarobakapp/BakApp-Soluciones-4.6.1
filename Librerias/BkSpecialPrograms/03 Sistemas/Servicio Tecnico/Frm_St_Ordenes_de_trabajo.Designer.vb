<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_St_Ordenes_de_trabajo
    Inherits DevComponents.DotNetBar.Metro.MetroForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_St_Ordenes_de_trabajo))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Crear_OT = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Buscar_OT = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnActualizar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Exportar_Excel = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mantencion_Tecnicos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Conf_Info_Reportes = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Recetas = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Operaciones = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_Garantia = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Crear_OT1Producto = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Crear_OTVariosProductos = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Lbl_FlujoTrabajo = New DevComponents.DotNetBar.LabelX()
        Me.Progeso_Gestion = New DevComponents.DotNetBar.ProgressSteps()
        Me.Estado_01_Ingreso = New DevComponents.DotNetBar.StepItem()
        Me.Estado_02_Asignar_Tecnico = New DevComponents.DotNetBar.StepItem()
        Me.Estado_03_Presupuesto = New DevComponents.DotNetBar.StepItem()
        Me.Estado_04_Cotizacion = New DevComponents.DotNetBar.StepItem()
        Me.Estado_05_Reparacion_Cierre = New DevComponents.DotNetBar.StepItem()
        Me.Estado_06_Aviso = New DevComponents.DotNetBar.StepItem()
        Me.Estado_07_Entrega = New DevComponents.DotNetBar.StepItem()
        Me.Estado_08_Cierre = New DevComponents.DotNetBar.StepItem()
        Me.Super_TabS = New DevComponents.DotNetBar.SuperTabStrip()
        Me.Tab_01_Todas = New DevComponents.DotNetBar.SuperTabItem()
        Me.Tab_02_Ingresadas = New DevComponents.DotNetBar.SuperTabItem()
        Me.Tab_03_Asignadas = New DevComponents.DotNetBar.SuperTabItem()
        Me.Tab_04_Presupuesto = New DevComponents.DotNetBar.SuperTabItem()
        Me.Tab_05_Preparacion = New DevComponents.DotNetBar.SuperTabItem()
        Me.Tab_06_Aviso = New DevComponents.DotNetBar.SuperTabItem()
        Me.Tab_07_Entregadas = New DevComponents.DotNetBar.SuperTabItem()
        Me.Tab_08_Cerradas_Hoy = New DevComponents.DotNetBar.SuperTabItem()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Grilla_SubOt = New DevComponents.DotNetBar.Controls.DataGridViewX()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Super_TabS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.Grilla_SubOt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Crear_OT, Me.Btn_Buscar_OT, Me.BtnActualizar, Me.Btn_Exportar_Excel, Me.Btn_Mantencion_Tecnicos, Me.Btn_Conf_Info_Reportes, Me.Btn_Recetas, Me.Btn_Operaciones})
        Me.Bar2.Location = New System.Drawing.Point(0, 0)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(962, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 87
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Crear_OT
        '
        Me.Btn_Crear_OT.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Crear_OT.FontBold = True
        Me.Btn_Crear_OT.ForeColor = System.Drawing.Color.Black
        Me.Btn_Crear_OT.Image = CType(resources.GetObject("Btn_Crear_OT.Image"), System.Drawing.Image)
        Me.Btn_Crear_OT.Name = "Btn_Crear_OT"
        Me.Btn_Crear_OT.Text = "Crear O.T."
        '
        'Btn_Buscar_OT
        '
        Me.Btn_Buscar_OT.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Buscar_OT.ForeColor = System.Drawing.Color.Black
        Me.Btn_Buscar_OT.Image = CType(resources.GetObject("Btn_Buscar_OT.Image"), System.Drawing.Image)
        Me.Btn_Buscar_OT.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Buscar_OT.Name = "Btn_Buscar_OT"
        Me.Btn_Buscar_OT.Tooltip = "Buscar OT"
        '
        'BtnActualizar
        '
        Me.BtnActualizar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnActualizar.Image = CType(resources.GetObject("BtnActualizar.Image"), System.Drawing.Image)
        Me.BtnActualizar.Name = "BtnActualizar"
        Me.BtnActualizar.Tooltip = "Actualizar información"
        '
        'Btn_Exportar_Excel
        '
        Me.Btn_Exportar_Excel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Exportar_Excel.Image = CType(resources.GetObject("Btn_Exportar_Excel.Image"), System.Drawing.Image)
        Me.Btn_Exportar_Excel.Name = "Btn_Exportar_Excel"
        Me.Btn_Exportar_Excel.Tooltip = "Exportar a Excel"
        '
        'Btn_Mantencion_Tecnicos
        '
        Me.Btn_Mantencion_Tecnicos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Mantencion_Tecnicos.Image = CType(resources.GetObject("Btn_Mantencion_Tecnicos.Image"), System.Drawing.Image)
        Me.Btn_Mantencion_Tecnicos.Name = "Btn_Mantencion_Tecnicos"
        Me.Btn_Mantencion_Tecnicos.Tooltip = "Mantención de Técnicos / Talleres"
        Me.Btn_Mantencion_Tecnicos.Visible = False
        '
        'Btn_Conf_Info_Reportes
        '
        Me.Btn_Conf_Info_Reportes.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Conf_Info_Reportes.Image = CType(resources.GetObject("Btn_Conf_Info_Reportes.Image"), System.Drawing.Image)
        Me.Btn_Conf_Info_Reportes.Name = "Btn_Conf_Info_Reportes"
        Me.Btn_Conf_Info_Reportes.Tooltip = "Configuración información fija en reportes"
        Me.Btn_Conf_Info_Reportes.Visible = False
        '
        'Btn_Recetas
        '
        Me.Btn_Recetas.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Recetas.Image = CType(resources.GetObject("Btn_Recetas.Image"), System.Drawing.Image)
        Me.Btn_Recetas.Name = "Btn_Recetas"
        Me.Btn_Recetas.Tooltip = "Mantención de Recetas"
        Me.Btn_Recetas.Visible = False
        '
        'Btn_Operaciones
        '
        Me.Btn_Operaciones.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Operaciones.Image = CType(resources.GetObject("Btn_Operaciones.Image"), System.Drawing.Image)
        Me.Btn_Operaciones.Name = "Btn_Operaciones"
        Me.Btn_Operaciones.Tooltip = "Mantención de Operaciones"
        Me.Btn_Operaciones.Visible = False
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.ContextMenuBar1)
        Me.GroupPanel1.Controls.Add(Me.Grilla)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 80)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(938, 298)
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
        Me.GroupPanel1.TabIndex = 88
        Me.GroupPanel1.Text = "Ordenes de trabajo"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_Garantia})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(232, 56)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(586, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 66
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_Garantia
        '
        Me.Menu_Contextual_Garantia.AutoExpandOnClick = True
        Me.Menu_Contextual_Garantia.Name = "Menu_Contextual_Garantia"
        Me.Menu_Contextual_Garantia.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Crear_OT1Producto, Me.Btn_Crear_OTVariosProductos})
        Me.Menu_Contextual_Garantia.Text = "Opciones encabezado"
        '
        'Btn_Crear_OT1Producto
        '
        Me.Btn_Crear_OT1Producto.Image = CType(resources.GetObject("Btn_Crear_OT1Producto.Image"), System.Drawing.Image)
        Me.Btn_Crear_OT1Producto.Name = "Btn_Crear_OT1Producto"
        Me.Btn_Crear_OT1Producto.Text = "Crear Orden con un solo producto"
        '
        'Btn_Crear_OTVariosProductos
        '
        Me.Btn_Crear_OTVariosProductos.Image = CType(resources.GetObject("Btn_Crear_OTVariosProductos.Image"), System.Drawing.Image)
        Me.Btn_Crear_OTVariosProductos.Name = "Btn_Crear_OTVariosProductos"
        Me.Btn_Crear_OTVariosProductos.Text = "Crear Orden con varios productos"
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.AllowUserToDeleteRows = False
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
        Me.Grilla.MultiSelect = False
        Me.Grilla.Name = "Grilla"
        Me.Grilla.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grilla.Size = New System.Drawing.Size(932, 275)
        Me.Grilla.TabIndex = 1
        '
        'Lbl_FlujoTrabajo
        '
        Me.Lbl_FlujoTrabajo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Lbl_FlujoTrabajo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_FlujoTrabajo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_FlujoTrabajo.ForeColor = System.Drawing.Color.Black
        Me.Lbl_FlujoTrabajo.Location = New System.Drawing.Point(12, 588)
        Me.Lbl_FlujoTrabajo.Name = "Lbl_FlujoTrabajo"
        Me.Lbl_FlujoTrabajo.Size = New System.Drawing.Size(163, 23)
        Me.Lbl_FlujoTrabajo.TabIndex = 90
        Me.Lbl_FlujoTrabajo.Text = "<font color=""#4E5D30""><b><font color=""#22B14C""><font color=""#0072BC"">WORKFLOW</fo" &
    "nt></font></b></font> (Flujo de trabajo)"
        '
        'Progeso_Gestion
        '
        Me.Progeso_Gestion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Progeso_Gestion.AutoSize = True
        Me.Progeso_Gestion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Progeso_Gestion.BackgroundStyle.Class = "ProgressSteps"
        Me.Progeso_Gestion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Progeso_Gestion.ContainerControlProcessDialogKey = True
        Me.Progeso_Gestion.ForeColor = System.Drawing.Color.Black
        Me.Progeso_Gestion.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Estado_01_Ingreso, Me.Estado_02_Asignar_Tecnico, Me.Estado_03_Presupuesto, Me.Estado_04_Cotizacion, Me.Estado_05_Reparacion_Cierre, Me.Estado_06_Aviso, Me.Estado_07_Entrega, Me.Estado_08_Cierre})
        Me.Progeso_Gestion.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.Progeso_Gestion.Location = New System.Drawing.Point(12, 617)
        Me.Progeso_Gestion.Name = "Progeso_Gestion"
        Me.Progeso_Gestion.Size = New System.Drawing.Size(955, 45)
        Me.Progeso_Gestion.TabIndex = 91
        '
        'Estado_01_Ingreso
        '
        Me.Estado_01_Ingreso.HotTracking = False
        Me.Estado_01_Ingreso.MinimumSize = New System.Drawing.Size(100, 0)
        Me.Estado_01_Ingreso.Name = "Estado_01_Ingreso"
        Me.Estado_01_Ingreso.SymbolSize = 10.0!
        Me.Estado_01_Ingreso.Text = "<font size=""+2""><b>Ingreso</b></font><br/><font size=""-1"">Espera<br/>1ra etapa</f" &
    "ont>"
        Me.Estado_01_Ingreso.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Center
        Me.Estado_01_Ingreso.Tooltip = "Creación de Orden de trabajo"
        '
        'Estado_02_Asignar_Tecnico
        '
        Me.Estado_02_Asignar_Tecnico.HotTracking = False
        Me.Estado_02_Asignar_Tecnico.MinimumSize = New System.Drawing.Size(100, 0)
        Me.Estado_02_Asignar_Tecnico.Name = "Estado_02_Asignar_Tecnico"
        Me.Estado_02_Asignar_Tecnico.SymbolSize = 13.0!
        Me.Estado_02_Asignar_Tecnico.Text = "<font size=""+2""><b>Asignar</b></font><br/><font size=""-1"">Espera<br/>2da etapa</f" &
    "ont>"
        Me.Estado_02_Asignar_Tecnico.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Center
        Me.Estado_02_Asignar_Tecnico.Tooltip = "Asignación de técnico"
        '
        'Estado_03_Presupuesto
        '
        Me.Estado_03_Presupuesto.HotTracking = False
        Me.Estado_03_Presupuesto.Name = "Estado_03_Presupuesto"
        Me.Estado_03_Presupuesto.SymbolSize = 13.0!
        Me.Estado_03_Presupuesto.Text = "<font size=""+2""><b>Presupuesto</b></font><br/><font size=""-1"">Espera<br/>3ra etap" &
    "a</font>"
        '
        'Estado_04_Cotizacion
        '
        Me.Estado_04_Cotizacion.HotTracking = False
        Me.Estado_04_Cotizacion.MinimumSize = New System.Drawing.Size(100, 0)
        Me.Estado_04_Cotizacion.Name = "Estado_04_Cotizacion"
        Me.Estado_04_Cotizacion.SymbolSize = 13.0!
        Me.Estado_04_Cotizacion.Text = "<font size=""+2""><b>Cotización</b></font><br/><font size=""-1"">Espera<br/>4ta etapa" &
    "</font>"
        Me.Estado_04_Cotizacion.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Center
        Me.Estado_04_Cotizacion.Tooltip = "Generación de cotizacion"
        '
        'Estado_05_Reparacion_Cierre
        '
        Me.Estado_05_Reparacion_Cierre.HotTracking = False
        Me.Estado_05_Reparacion_Cierre.Name = "Estado_05_Reparacion_Cierre"
        Me.Estado_05_Reparacion_Cierre.SymbolSize = 13.0!
        Me.Estado_05_Reparacion_Cierre.Text = "<font size=""+2""><b>Reparación</b></font><br/><font size=""-1"">Espera<br/>5ta etapa" &
    "</font>"
        '
        'Estado_06_Aviso
        '
        Me.Estado_06_Aviso.HotTracking = False
        Me.Estado_06_Aviso.Name = "Estado_06_Aviso"
        Me.Estado_06_Aviso.SymbolSize = 13.0!
        Me.Estado_06_Aviso.Text = "<font size=""+2""><b>Aviso</b></font><br/><font size=""-1"">Espera<br/> 6ta Etapa</fo" &
    "nt>"
        '
        'Estado_07_Entrega
        '
        Me.Estado_07_Entrega.HotTracking = False
        Me.Estado_07_Entrega.Name = "Estado_07_Entrega"
        Me.Estado_07_Entrega.SymbolSize = 13.0!
        Me.Estado_07_Entrega.Text = "<font size=""+2""><b>Entrega/Facturación</b></font><br/><font size=""-1"">Espera<br/>" &
    "7ma Etapa</font>"
        '
        'Estado_08_Cierre
        '
        Me.Estado_08_Cierre.HotTracking = False
        Me.Estado_08_Cierre.Name = "Estado_08_Cierre"
        Me.Estado_08_Cierre.SymbolSize = 13.0!
        Me.Estado_08_Cierre.Text = "<font size=""+2""><b>Cerrar</b></font><br/><font size=""-1"">Espera<br/>8va Etapa</fo" &
    "nt>"
        '
        'Super_TabS
        '
        Me.Super_TabS.AutoSelectAttachedControl = False
        Me.Super_TabS.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Super_TabS.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Super_TabS.ContainerControlProcessDialogKey = True
        '
        '
        '
        '
        '
        '
        Me.Super_TabS.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.Super_TabS.ControlBox.MenuBox.Name = ""
        Me.Super_TabS.ControlBox.Name = ""
        Me.Super_TabS.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Super_TabS.ControlBox.MenuBox, Me.Super_TabS.ControlBox.CloseBox})
        Me.Super_TabS.ForeColor = System.Drawing.Color.Black
        Me.Super_TabS.Location = New System.Drawing.Point(12, 47)
        Me.Super_TabS.Name = "Super_TabS"
        Me.Super_TabS.ReorderTabsEnabled = True
        Me.Super_TabS.SelectedTabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Super_TabS.SelectedTabIndex = 0
        Me.Super_TabS.Size = New System.Drawing.Size(938, 27)
        Me.Super_TabS.TabCloseButtonHot = Nothing
        Me.Super_TabS.TabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Super_TabS.TabIndex = 120
        Me.Super_TabS.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Tab_01_Todas, Me.Tab_02_Ingresadas, Me.Tab_03_Asignadas, Me.Tab_04_Presupuesto, Me.Tab_05_Preparacion, Me.Tab_06_Aviso, Me.Tab_07_Entregadas, Me.Tab_08_Cerradas_Hoy})
        Me.Super_TabS.Text = "SuperTabStrip1"
        '
        'Tab_01_Todas
        '
        Me.Tab_01_Todas.GlobalItem = False
        Me.Tab_01_Todas.Name = "Tab_01_Todas"
        Me.Tab_01_Todas.Text = "Todas las activas"
        '
        'Tab_02_Ingresadas
        '
        Me.Tab_02_Ingresadas.GlobalItem = False
        Me.Tab_02_Ingresadas.Name = "Tab_02_Ingresadas"
        Me.Tab_02_Ingresadas.Text = "Ingresadas."
        '
        'Tab_03_Asignadas
        '
        Me.Tab_03_Asignadas.GlobalItem = False
        Me.Tab_03_Asignadas.Name = "Tab_03_Asignadas"
        Me.Tab_03_Asignadas.Text = "Asignadas a un técnico."
        '
        'Tab_04_Presupuesto
        '
        Me.Tab_04_Presupuesto.GlobalItem = False
        Me.Tab_04_Presupuesto.Name = "Tab_04_Presupuesto"
        Me.Tab_04_Presupuesto.Text = "Presupuesto"
        '
        'Tab_05_Preparacion
        '
        Me.Tab_05_Preparacion.GlobalItem = False
        Me.Tab_05_Preparacion.Name = "Tab_05_Preparacion"
        Me.Tab_05_Preparacion.Text = "En reparación"
        '
        'Tab_06_Aviso
        '
        Me.Tab_06_Aviso.GlobalItem = False
        Me.Tab_06_Aviso.Name = "Tab_06_Aviso"
        Me.Tab_06_Aviso.Text = "Aviso"
        '
        'Tab_07_Entregadas
        '
        Me.Tab_07_Entregadas.GlobalItem = False
        Me.Tab_07_Entregadas.Name = "Tab_07_Entregadas"
        Me.Tab_07_Entregadas.Text = "Entregadas. Fact. o Guía."
        '
        'Tab_08_Cerradas_Hoy
        '
        Me.Tab_08_Cerradas_Hoy.GlobalItem = False
        Me.Tab_08_Cerradas_Hoy.Name = "Tab_08_Cerradas_Hoy"
        Me.Tab_08_Cerradas_Hoy.Text = "Cerradas hoy"
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Grilla_SubOt)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(12, 384)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(938, 199)
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
        Me.GroupPanel2.TabIndex = 121
        Me.GroupPanel2.Text = "Sub-Ot de la orden de servicio"
        '
        'Grilla_SubOt
        '
        Me.Grilla_SubOt.AllowUserToAddRows = False
        Me.Grilla_SubOt.AllowUserToDeleteRows = False
        Me.Grilla_SubOt.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_SubOt.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Grilla_SubOt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_SubOt.DefaultCellStyle = DataGridViewCellStyle5
        Me.Grilla_SubOt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_SubOt.EnableHeadersVisualStyles = False
        Me.Grilla_SubOt.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_SubOt.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_SubOt.MultiSelect = False
        Me.Grilla_SubOt.Name = "Grilla_SubOt"
        Me.Grilla_SubOt.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_SubOt.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Grilla_SubOt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grilla_SubOt.Size = New System.Drawing.Size(932, 176)
        Me.Grilla_SubOt.TabIndex = 1
        '
        'Frm_St_Ordenes_de_trabajo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(962, 692)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.Super_TabS)
        Me.Controls.Add(Me.Progeso_Gestion)
        Me.Controls.Add(Me.Lbl_FlujoTrabajo)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_St_Ordenes_de_trabajo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ORDENES DE TRABAJO.  SISTEMA SERVICIO TECNICO"
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Super_TabS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.Grilla_SubOt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Buscar_OT As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Crear_OT As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Lbl_FlujoTrabajo As DevComponents.DotNetBar.LabelX
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents BtnActualizar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Exportar_Excel As DevComponents.DotNetBar.ButtonItem
    Private WithEvents Progeso_Gestion As DevComponents.DotNetBar.ProgressSteps
    Private WithEvents Estado_01_Ingreso As DevComponents.DotNetBar.StepItem
    Private WithEvents Estado_02_Asignar_Tecnico As DevComponents.DotNetBar.StepItem
    Private WithEvents Estado_03_Presupuesto As DevComponents.DotNetBar.StepItem
    Private WithEvents Estado_04_Cotizacion As DevComponents.DotNetBar.StepItem
    Private WithEvents Estado_05_Reparacion_Cierre As DevComponents.DotNetBar.StepItem
    Friend WithEvents Estado_06_Aviso As DevComponents.DotNetBar.StepItem
    Friend WithEvents Estado_07_Entrega As DevComponents.DotNetBar.StepItem
    Friend WithEvents Btn_Mantencion_Tecnicos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Estado_08_Cierre As DevComponents.DotNetBar.StepItem
    Friend WithEvents Btn_Conf_Info_Reportes As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Super_TabS As DevComponents.DotNetBar.SuperTabStrip
    Friend WithEvents Tab_01_Todas As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents Tab_02_Ingresadas As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents Tab_03_Asignadas As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents Tab_04_Presupuesto As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents Tab_06_Aviso As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents Tab_07_Entregadas As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents Tab_08_Cerradas_Hoy As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents Tab_05_Preparacion As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_Garantia As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Crear_OT1Producto As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Crear_OTVariosProductos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Recetas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Operaciones As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grilla_SubOt As DevComponents.DotNetBar.Controls.DataGridViewX
End Class
