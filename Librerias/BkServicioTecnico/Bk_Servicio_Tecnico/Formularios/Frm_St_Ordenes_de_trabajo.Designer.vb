<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_St_Ordenes_de_trabajo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_St_Ordenes_de_trabajo))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Bar2 = New DevComponents.DotNetBar.Bar
        Me.Btn_Buscar_OT = New DevComponents.DotNetBar.ButtonItem
        Me.Btn_Crear_OT = New DevComponents.DotNetBar.ButtonItem
        Me.BtnActualizar = New DevComponents.DotNetBar.ButtonItem
        Me.Btn_Exportar_Excel = New DevComponents.DotNetBar.ButtonItem
        Me.Btn_Mantencion_Tecnicos = New DevComponents.DotNetBar.ButtonItem
        Me.Btn_Conf_Info_Reportes = New DevComponents.DotNetBar.ButtonItem
        Me.Btn_Salir = New DevComponents.DotNetBar.ButtonItem
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX
        Me.Progeso_Gestion = New DevComponents.DotNetBar.ProgressSteps
        Me.Estado_01_Ingreso = New DevComponents.DotNetBar.StepItem
        Me.Estado_02_Asignar_Tecnico = New DevComponents.DotNetBar.StepItem
        Me.Estado_03_Presupuesto = New DevComponents.DotNetBar.StepItem
        Me.Estado_04_Cotizacion = New DevComponents.DotNetBar.StepItem
        Me.Estado_05_Reparacion_Cierre = New DevComponents.DotNetBar.StepItem
        Me.Estado_06_Aviso = New DevComponents.DotNetBar.StepItem
        Me.Estado_07_Entrega = New DevComponents.DotNetBar.StepItem
        Me.Estado_08_Cierre = New DevComponents.DotNetBar.StepItem
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Buscar_OT, Me.Btn_Crear_OT, Me.BtnActualizar, Me.Btn_Exportar_Excel, Me.Btn_Mantencion_Tecnicos, Me.Btn_Conf_Info_Reportes, Me.Btn_Salir})
        Me.Bar2.Location = New System.Drawing.Point(0, 0)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(1135, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 87
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
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
        'Btn_Crear_OT
        '
        Me.Btn_Crear_OT.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Crear_OT.FontBold = True
        Me.Btn_Crear_OT.ForeColor = System.Drawing.Color.Black
        Me.Btn_Crear_OT.Image = CType(resources.GetObject("Btn_Crear_OT.Image"), System.Drawing.Image)
        Me.Btn_Crear_OT.Name = "Btn_Crear_OT"
        Me.Btn_Crear_OT.Text = "Crear O.T."
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
        '
        'Btn_Conf_Info_Reportes
        '
        Me.Btn_Conf_Info_Reportes.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Conf_Info_Reportes.Image = CType(resources.GetObject("Btn_Conf_Info_Reportes.Image"), System.Drawing.Image)
        Me.Btn_Conf_Info_Reportes.Name = "Btn_Conf_Info_Reportes"
        Me.Btn_Conf_Info_Reportes.Tooltip = "Configuración información fija en reportes"
        '
        'Btn_Salir
        '
        Me.Btn_Salir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Salir.ForeColor = System.Drawing.Color.Black
        Me.Btn_Salir.Image = CType(resources.GetObject("Btn_Salir.Image"), System.Drawing.Image)
        Me.Btn_Salir.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Salir.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Tooltip = "Salir"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Grilla)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 47)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(1111, 448)
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
        Me.GroupPanel1.Text = "Ordenes de trabajo vigente"
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.AllowUserToDeleteRows = False
        Me.Grilla.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
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
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
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
        Me.Grilla.Size = New System.Drawing.Size(1105, 425)
        Me.Grilla.TabIndex = 1
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
        Me.LabelX4.Location = New System.Drawing.Point(12, 501)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(163, 23)
        Me.LabelX4.TabIndex = 90
        Me.LabelX4.Text = "<font color=""#4E5D30""><b><font color=""#22B14C""><font color=""#0072BC"">WORKFLOW</fo" & _
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
        Me.Progeso_Gestion.Location = New System.Drawing.Point(12, 530)
        Me.Progeso_Gestion.Name = "Progeso_Gestion"
        Me.Progeso_Gestion.Size = New System.Drawing.Size(955, 53)
        Me.Progeso_Gestion.TabIndex = 91
        '
        'Estado_01_Ingreso
        '
        Me.Estado_01_Ingreso.HotTracking = False
        Me.Estado_01_Ingreso.MinimumSize = New System.Drawing.Size(100, 0)
        Me.Estado_01_Ingreso.Name = "Estado_01_Ingreso"
        Me.Estado_01_Ingreso.SymbolSize = 10.0!
        Me.Estado_01_Ingreso.Text = "<font size=""+2""><b>Ingreso</b></font><br/><font size=""-1"">Espera<br/>1ra etapa</f" & _
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
        Me.Estado_02_Asignar_Tecnico.Text = "<font size=""+2""><b>Asignar</b></font><br/><font size=""-1"">Espera<br/>2da etapa</f" & _
            "ont>"
        Me.Estado_02_Asignar_Tecnico.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Center
        Me.Estado_02_Asignar_Tecnico.Tooltip = "Asignación de técnico"
        '
        'Estado_03_Presupuesto
        '
        Me.Estado_03_Presupuesto.HotTracking = False
        Me.Estado_03_Presupuesto.Name = "Estado_03_Presupuesto"
        Me.Estado_03_Presupuesto.SymbolSize = 13.0!
        Me.Estado_03_Presupuesto.Text = "<font size=""+2""><b>Presupuesto</b></font><br/><font size=""-1"">Espera<br/>3ra etap" & _
            "a</font>"
        '
        'Estado_04_Cotizacion
        '
        Me.Estado_04_Cotizacion.HotTracking = False
        Me.Estado_04_Cotizacion.MinimumSize = New System.Drawing.Size(100, 0)
        Me.Estado_04_Cotizacion.Name = "Estado_04_Cotizacion"
        Me.Estado_04_Cotizacion.SymbolSize = 13.0!
        Me.Estado_04_Cotizacion.Text = "<font size=""+2""><b>Cotización</b></font><br/><font size=""-1"">Espera<br/>4ta etapa" & _
            "</font>"
        Me.Estado_04_Cotizacion.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Center
        Me.Estado_04_Cotizacion.Tooltip = "Generación de cotizacion"
        '
        'Estado_05_Reparacion_Cierre
        '
        Me.Estado_05_Reparacion_Cierre.HotTracking = False
        Me.Estado_05_Reparacion_Cierre.Name = "Estado_05_Reparacion_Cierre"
        Me.Estado_05_Reparacion_Cierre.SymbolSize = 13.0!
        Me.Estado_05_Reparacion_Cierre.Text = "<font size=""+2""><b>Reparación</b></font><br/><font size=""-1"">Espera<br/>5ta etapa" & _
            "</font>"
        '
        'Estado_06_Aviso
        '
        Me.Estado_06_Aviso.HotTracking = False
        Me.Estado_06_Aviso.Name = "Estado_06_Aviso"
        Me.Estado_06_Aviso.SymbolSize = 13.0!
        Me.Estado_06_Aviso.Text = "<font size=""+2""><b>Aviso</b></font><br/><font size=""-1"">Espera<br/> 6ta Etapa</fo" & _
            "nt>"
        '
        'Estado_07_Entrega
        '
        Me.Estado_07_Entrega.HotTracking = False
        Me.Estado_07_Entrega.Name = "Estado_07_Entrega"
        Me.Estado_07_Entrega.SymbolSize = 13.0!
        Me.Estado_07_Entrega.Text = "<font size=""+2""><b>Entrega/Facturación</b></font><br/><font size=""-1"">Espera<br/>" & _
            "7ma Etapa</font>"
        '
        'Estado_08_Cierre
        '
        Me.Estado_08_Cierre.HotTracking = False
        Me.Estado_08_Cierre.Name = "Estado_08_Cierre"
        Me.Estado_08_Cierre.SymbolSize = 13.0!
        Me.Estado_08_Cierre.Text = "<font size=""+2""><b>Cerrar</b></font><br/><font size=""-1"">Espera<br/>8va Etapa</fo" & _
            "nt>"
        '
        'Frm_St_Ordenes_de_trabajo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1135, 605)
        Me.ControlBox = False
        Me.Controls.Add(Me.Progeso_Gestion)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "Frm_St_Ordenes_de_trabajo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ORDENES DE TRABAJO.  SISTEMA SERVICIO TECNICO"
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Buscar_OT As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Crear_OT As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Salir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
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
End Class
