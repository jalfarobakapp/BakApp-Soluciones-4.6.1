<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Rc_Lista_Reclamos
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Rc_Lista_Reclamos))
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Crear_OT = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Buscar_Reclamo = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnActualizar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Exportar_Excel = New DevComponents.DotNetBar.ButtonItem()
        Me.MetroStatusBar1 = New DevComponents.DotNetBar.Metro.MetroStatusBar()
        Me.Cmb_Filtro_Codigo = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Progeso_Gestion = New DevComponents.DotNetBar.ProgressSteps()
        Me.Estado_01_Ingreso = New DevComponents.DotNetBar.StepItem()
        Me.Estado_02_Revision = New DevComponents.DotNetBar.StepItem()
        Me.Estado_03_Recopilar_Informacion = New DevComponents.DotNetBar.StepItem()
        Me.Estado_04_Resolucion = New DevComponents.DotNetBar.StepItem()
        Me.Estado_05_Validacion = New DevComponents.DotNetBar.StepItem()
        Me.Estado_06_Aviso_Cliente = New DevComponents.DotNetBar.StepItem()
        Me.Estado_07_Gestionar_Reclamo = New DevComponents.DotNetBar.StepItem()
        Me.StepItem1 = New DevComponents.DotNetBar.StepItem()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelX4
        '
        Me.LabelX4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelX4.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(12, 523)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(163, 23)
        Me.LabelX4.TabIndex = 94
        Me.LabelX4.Text = "<font color=""#4E5D30""><b><font color=""#22B14C""><font color=""#0072BC"">WORKFLOW</fo" &
    "nt></font></b></font> (Flujo de trabajo)"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Grilla)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 41)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(1246, 476)
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
        Me.GroupPanel1.TabIndex = 93
        Me.GroupPanel1.Text = "Ordenes de trabajo vigente"
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
        Me.Grilla.Size = New System.Drawing.Size(1240, 453)
        Me.Grilla.TabIndex = 1
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Crear_OT, Me.Btn_Buscar_Reclamo, Me.BtnActualizar, Me.Btn_Exportar_Excel})
        Me.Bar2.Location = New System.Drawing.Point(0, 609)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(1270, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 92
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
        Me.Btn_Crear_OT.Text = "Crear nuevo reclamo"
        '
        'Btn_Buscar_Reclamo
        '
        Me.Btn_Buscar_Reclamo.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Buscar_Reclamo.FontBold = True
        Me.Btn_Buscar_Reclamo.ForeColor = System.Drawing.Color.Black
        Me.Btn_Buscar_Reclamo.Image = CType(resources.GetObject("Btn_Buscar_Reclamo.Image"), System.Drawing.Image)
        Me.Btn_Buscar_Reclamo.Name = "Btn_Buscar_Reclamo"
        Me.Btn_Buscar_Reclamo.Tooltip = "Buscar reclamos"
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
        Me.Btn_Exportar_Excel.Visible = False
        '
        'MetroStatusBar1
        '
        Me.MetroStatusBar1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.MetroStatusBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MetroStatusBar1.ContainerControlProcessDialogKey = True
        Me.MetroStatusBar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.MetroStatusBar1.DragDropSupport = True
        Me.MetroStatusBar1.Font = New System.Drawing.Font("Segoe UI", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MetroStatusBar1.ForeColor = System.Drawing.Color.Black
        Me.MetroStatusBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MetroStatusBar1.Location = New System.Drawing.Point(0, 650)
        Me.MetroStatusBar1.Name = "MetroStatusBar1"
        Me.MetroStatusBar1.Size = New System.Drawing.Size(1270, 22)
        Me.MetroStatusBar1.TabIndex = 96
        Me.MetroStatusBar1.Text = "MetroStatusBar1"
        '
        'Cmb_Filtro_Codigo
        '
        Me.Cmb_Filtro_Codigo.DisplayMember = "Text"
        Me.Cmb_Filtro_Codigo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Filtro_Codigo.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Filtro_Codigo.FormattingEnabled = True
        Me.Cmb_Filtro_Codigo.ItemHeight = 16
        Me.Cmb_Filtro_Codigo.Location = New System.Drawing.Point(114, 13)
        Me.Cmb_Filtro_Codigo.Name = "Cmb_Filtro_Codigo"
        Me.Cmb_Filtro_Codigo.Size = New System.Drawing.Size(167, 22)
        Me.Cmb_Filtro_Codigo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Filtro_Codigo.TabIndex = 14
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(15, 12)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(93, 23)
        Me.LabelX2.TabIndex = 13
        Me.LabelX2.Text = "Tipo de reclamo"
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
        Me.Progeso_Gestion.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Estado_01_Ingreso, Me.Estado_02_Revision, Me.Estado_03_Recopilar_Informacion, Me.Estado_04_Resolucion, Me.Estado_05_Validacion, Me.Estado_06_Aviso_Cliente, Me.Estado_07_Gestionar_Reclamo, Me.StepItem1})
        Me.Progeso_Gestion.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.Progeso_Gestion.Location = New System.Drawing.Point(12, 552)
        Me.Progeso_Gestion.Name = "Progeso_Gestion"
        Me.Progeso_Gestion.Size = New System.Drawing.Size(1246, 43)
        Me.Progeso_Gestion.TabIndex = 100
        '
        'Estado_01_Ingreso
        '
        Me.Estado_01_Ingreso.HotTracking = False
        Me.Estado_01_Ingreso.MinimumSize = New System.Drawing.Size(100, 0)
        Me.Estado_01_Ingreso.Name = "Estado_01_Ingreso"
        Me.Estado_01_Ingreso.SymbolSize = 10.0!
        Me.Estado_01_Ingreso.Text = "<font size=""+1""><b>Ingresado</b></font><br/><font size=""-1"">Espera<br/>1ra etapa<" &
    "/font>"
        Me.Estado_01_Ingreso.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Center
        Me.Estado_01_Ingreso.Tooltip = "Creación de Orden de trabajo"
        '
        'Estado_02_Revision
        '
        Me.Estado_02_Revision.HotTracking = False
        Me.Estado_02_Revision.MinimumSize = New System.Drawing.Size(100, 0)
        Me.Estado_02_Revision.Name = "Estado_02_Revision"
        Me.Estado_02_Revision.SymbolSize = 13.0!
        Me.Estado_02_Revision.Text = "<font size=""+1""><b>Revisión (Apertura)</b></font><br/><font size=""-1"">...<br/>2da" &
    " etapa</font>"
        Me.Estado_02_Revision.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Center
        Me.Estado_02_Revision.Tooltip = "Apertura de reclamo por parte del personal autorizado, enviar a revisión"
        '
        'Estado_03_Recopilar_Informacion
        '
        Me.Estado_03_Recopilar_Informacion.HotTracking = False
        Me.Estado_03_Recopilar_Informacion.Name = "Estado_03_Recopilar_Informacion"
        Me.Estado_03_Recopilar_Informacion.SymbolSize = 13.0!
        Me.Estado_03_Recopilar_Informacion.Text = "<font size=""+1""><b>Recopilación de información</b></font><br/><font size=""-1"">..." &
    "<br/>3ra etapa</font>"
        '
        'Estado_04_Resolucion
        '
        Me.Estado_04_Resolucion.HotTracking = False
        Me.Estado_04_Resolucion.MinimumSize = New System.Drawing.Size(100, 0)
        Me.Estado_04_Resolucion.Name = "Estado_04_Resolucion"
        Me.Estado_04_Resolucion.SymbolSize = 13.0!
        Me.Estado_04_Resolucion.Text = "<font size=""+1""><b>Resolución</b></font><br/><font size=""-1"">...<br/>4ta etapa</f" &
    "ont>"
        Me.Estado_04_Resolucion.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Center
        Me.Estado_04_Resolucion.Tooltip = "Generación de cotizacion"
        '
        'Estado_05_Validacion
        '
        Me.Estado_05_Validacion.HotTracking = False
        Me.Estado_05_Validacion.Name = "Estado_05_Validacion"
        Me.Estado_05_Validacion.SymbolSize = 13.0!
        Me.Estado_05_Validacion.Text = "<font size=""+1""><b>Validación</b></font><br/><font size=""-1"">...<br/>5ta etapa</f" &
    "ont>"
        '
        'Estado_06_Aviso_Cliente
        '
        Me.Estado_06_Aviso_Cliente.HotTracking = False
        Me.Estado_06_Aviso_Cliente.Name = "Estado_06_Aviso_Cliente"
        Me.Estado_06_Aviso_Cliente.SymbolSize = 13.0!
        Me.Estado_06_Aviso_Cliente.Text = "<font size=""+1""><b>Aviso cliente</b></font><br/><font size=""-1"">...<br/> 6ta Etap" &
    "a</font>"
        '
        'Estado_07_Gestionar_Reclamo
        '
        Me.Estado_07_Gestionar_Reclamo.HotTracking = False
        Me.Estado_07_Gestionar_Reclamo.Name = "Estado_07_Gestionar_Reclamo"
        Me.Estado_07_Gestionar_Reclamo.SymbolSize = 13.0!
        Me.Estado_07_Gestionar_Reclamo.Text = "<font size=""+1""><b>Gestionar reclamo</b></font><br/><font size=""-1"">...<br/>7ma E" &
    "tapa</font>"
        '
        'StepItem1
        '
        Me.StepItem1.HotTracking = False
        Me.StepItem1.Name = "StepItem1"
        Me.StepItem1.SymbolSize = 13.0!
        Me.StepItem1.Text = "<font size=""+1""><b>Cierre</b></font><br/><font size=""-1"">...<br/>7ma Etapa</font>" &
    ""
        '
        'Frm_Rc_Lista_Reclamos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1270, 672)
        Me.Controls.Add(Me.Progeso_Gestion)
        Me.Controls.Add(Me.Cmb_Filtro_Codigo)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.MetroStatusBar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Rc_Lista_Reclamos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SISTEMA DE RECLAMOS (EMPRESA)"
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Public WithEvents Btn_Crear_OT As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnActualizar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Exportar_Excel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroStatusBar1 As DevComponents.DotNetBar.Metro.MetroStatusBar
    Friend WithEvents Cmb_Filtro_Codigo As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Public WithEvents Btn_Buscar_Reclamo As DevComponents.DotNetBar.ButtonItem
    Private WithEvents Progeso_Gestion As DevComponents.DotNetBar.ProgressSteps
    Private WithEvents Estado_01_Ingreso As DevComponents.DotNetBar.StepItem
    Private WithEvents Estado_02_Revision As DevComponents.DotNetBar.StepItem
    Private WithEvents Estado_03_Recopilar_Informacion As DevComponents.DotNetBar.StepItem
    Private WithEvents Estado_04_Resolucion As DevComponents.DotNetBar.StepItem
    Private WithEvents Estado_05_Validacion As DevComponents.DotNetBar.StepItem
    Friend WithEvents Estado_06_Aviso_Cliente As DevComponents.DotNetBar.StepItem
    Friend WithEvents Estado_07_Gestionar_Reclamo As DevComponents.DotNetBar.StepItem
    Friend WithEvents StepItem1 As DevComponents.DotNetBar.StepItem
End Class
