<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Rc_Reclamo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Rc_Reclamo))
        Me.Btn_Garantia_Ver_Documento = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Garantia_Agregar_Documento = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Garantia_Cambiar_Documento = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Imprimir_Acta_ingreso = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Imprimir_Evaluacion_Tecnico = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Imprimir_Reporte_Final = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Documento_Sistema = New DevComponents.DotNetBar.ButtonItem()
        Me.Documento_Externo = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Doc_Externo_Boleta = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Doc_Externo_Factura = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Cerrar_Reclamo = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Anular = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Imprimir = New DevComponents.DotNetBar.ButtonItem()
        Me.Progeso_Gestion = New DevComponents.DotNetBar.ProgressSteps()
        Me.Estado_01_Ingreso = New DevComponents.DotNetBar.StepItem()
        Me.Estado_02_Revision = New DevComponents.DotNetBar.StepItem()
        Me.Estado_03_Recopilar_Informacion = New DevComponents.DotNetBar.StepItem()
        Me.Estado_04_Resolucion = New DevComponents.DotNetBar.StepItem()
        Me.Estado_05_Validacion = New DevComponents.DotNetBar.StepItem()
        Me.Estado_06_Aviso_Cliente = New DevComponents.DotNetBar.StepItem()
        Me.Estado_07_Gestionar_Reclamo = New DevComponents.DotNetBar.StepItem()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Progreso_Sub_Estados = New DevComponents.DotNetBar.ProgressSteps()
        Me.Sub_Estado_REM = New DevComponents.DotNetBar.StepItem()
        Me.Sub_Estado_RVD = New DevComponents.DotNetBar.StepItem()
        Me.Sub_Estado_DME_REP_EBV = New DevComponents.DotNetBar.StepItem()
        Me.Sub_Estado_RAC = New DevComponents.DotNetBar.StepItem()
        Me.Sub_Estado_CIE = New DevComponents.DotNetBar.StepItem()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Sub_Tipo_Reclamo = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Descripcion_Reclamo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX18 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Tipo_De_Reclamo = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Lbl_Sucursal_Ingreso = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Fecha_Emision = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Vendedor = New DevComponents.DotNetBar.LabelX()
        Me.LabelX24 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Direccion = New DevComponents.DotNetBar.LabelX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Cliente = New DevComponents.DotNetBar.LabelX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Numero = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Sucursal_Elaboracion = New DevComponents.DotNetBar.LabelX()
        Me.LabelX21 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Nombre_Contacto = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Telefono_Contacto = New DevComponents.DotNetBar.LabelX()
        Me.LabelX14 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Email_Contacto = New DevComponents.DotNetBar.LabelX()
        Me.LabelX16 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Lbl_Fecha_Elaboracion = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Cantidad = New DevComponents.DotNetBar.LabelX()
        Me.LabelX20 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Producto = New DevComponents.DotNetBar.LabelX()
        Me.LabelX33 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX31 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel4 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Sub_Estado_RZC = New DevComponents.DotNetBar.StepItem()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel3.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.GroupPanel2.SuspendLayout()
        Me.GroupPanel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Btn_Garantia_Ver_Documento
        '
        Me.Btn_Garantia_Ver_Documento.Image = CType(resources.GetObject("Btn_Garantia_Ver_Documento.Image"), System.Drawing.Image)
        Me.Btn_Garantia_Ver_Documento.Name = "Btn_Garantia_Ver_Documento"
        Me.Btn_Garantia_Ver_Documento.Text = "Ver documento"
        '
        'Btn_Garantia_Agregar_Documento
        '
        Me.Btn_Garantia_Agregar_Documento.Image = CType(resources.GetObject("Btn_Garantia_Agregar_Documento.Image"), System.Drawing.Image)
        Me.Btn_Garantia_Agregar_Documento.Name = "Btn_Garantia_Agregar_Documento"
        Me.Btn_Garantia_Agregar_Documento.Text = "Agregar documento"
        '
        'Btn_Garantia_Cambiar_Documento
        '
        Me.Btn_Garantia_Cambiar_Documento.Image = CType(resources.GetObject("Btn_Garantia_Cambiar_Documento.Image"), System.Drawing.Image)
        Me.Btn_Garantia_Cambiar_Documento.Name = "Btn_Garantia_Cambiar_Documento"
        Me.Btn_Garantia_Cambiar_Documento.Text = "Cambiar documento"
        '
        'Btn_Imprimir_Acta_ingreso
        '
        Me.Btn_Imprimir_Acta_ingreso.Image = CType(resources.GetObject("Btn_Imprimir_Acta_ingreso.Image"), System.Drawing.Image)
        Me.Btn_Imprimir_Acta_ingreso.Name = "Btn_Imprimir_Acta_ingreso"
        Me.Btn_Imprimir_Acta_ingreso.Text = "Imprimir Acta De Ingreso"
        Me.Btn_Imprimir_Acta_ingreso.Visible = False
        '
        'Btn_Imprimir_Evaluacion_Tecnico
        '
        Me.Btn_Imprimir_Evaluacion_Tecnico.Image = CType(resources.GetObject("Btn_Imprimir_Evaluacion_Tecnico.Image"), System.Drawing.Image)
        Me.Btn_Imprimir_Evaluacion_Tecnico.Name = "Btn_Imprimir_Evaluacion_Tecnico"
        Me.Btn_Imprimir_Evaluacion_Tecnico.Text = "Imprimir Evaluación Técnico"
        Me.Btn_Imprimir_Evaluacion_Tecnico.Visible = False
        '
        'Btn_Imprimir_Reporte_Final
        '
        Me.Btn_Imprimir_Reporte_Final.Image = CType(resources.GetObject("Btn_Imprimir_Reporte_Final.Image"), System.Drawing.Image)
        Me.Btn_Imprimir_Reporte_Final.Name = "Btn_Imprimir_Reporte_Final"
        Me.Btn_Imprimir_Reporte_Final.Text = "Imprimir Reporte Final"
        Me.Btn_Imprimir_Reporte_Final.Visible = False
        '
        'Btn_Documento_Sistema
        '
        Me.Btn_Documento_Sistema.Image = CType(resources.GetObject("Btn_Documento_Sistema.Image"), System.Drawing.Image)
        Me.Btn_Documento_Sistema.Name = "Btn_Documento_Sistema"
        Me.Btn_Documento_Sistema.Text = "Documento del sistema"
        Me.Btn_Documento_Sistema.Tooltip = "Buscar documento en base de datos del sistema y linkear"
        '
        'Documento_Externo
        '
        Me.Documento_Externo.Image = CType(resources.GetObject("Documento_Externo.Image"), System.Drawing.Image)
        Me.Documento_Externo.Name = "Documento_Externo"
        Me.Documento_Externo.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Doc_Externo_Boleta, Me.Btn_Doc_Externo_Factura})
        Me.Documento_Externo.Text = "Documento Externo"
        Me.Documento_Externo.Tooltip = "Poner numero de la boleta o factura del cliente"
        '
        'Btn_Doc_Externo_Boleta
        '
        Me.Btn_Doc_Externo_Boleta.Image = CType(resources.GetObject("Btn_Doc_Externo_Boleta.Image"), System.Drawing.Image)
        Me.Btn_Doc_Externo_Boleta.Name = "Btn_Doc_Externo_Boleta"
        Me.Btn_Doc_Externo_Boleta.Text = "BOLETA"
        '
        'Btn_Doc_Externo_Factura
        '
        Me.Btn_Doc_Externo_Factura.Image = CType(resources.GetObject("Btn_Doc_Externo_Factura.Image"), System.Drawing.Image)
        Me.Btn_Doc_Externo_Factura.Name = "Btn_Doc_Externo_Factura"
        Me.Btn_Doc_Externo_Factura.Text = "FACTURA"
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
        Me.LabelX4.Location = New System.Drawing.Point(6, 347)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(291, 23)
        Me.LabelX4.TabIndex = 100
        Me.LabelX4.Text = "<font color=""#4E5D30""><b><font color=""#22B14C""><font color=""#0072BC"">ESTADOS</fon" &
    "t></font></b></font> (Flujo de trabajo)"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Cerrar_Reclamo, Me.Btn_Anular, Me.Btn_Imprimir})
        Me.Bar2.Location = New System.Drawing.Point(0, 520)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(788, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 101
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Cerrar_Reclamo
        '
        Me.Btn_Cerrar_Reclamo.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Cerrar_Reclamo.ForeColor = System.Drawing.Color.Black
        Me.Btn_Cerrar_Reclamo.Image = CType(resources.GetObject("Btn_Cerrar_Reclamo.Image"), System.Drawing.Image)
        Me.Btn_Cerrar_Reclamo.Name = "Btn_Cerrar_Reclamo"
        Me.Btn_Cerrar_Reclamo.Text = "Cerrar reclamo"
        Me.Btn_Cerrar_Reclamo.Tooltip = "Cierra definitivamente la orden de trabajo, no se pueden hacer mas modificaciones" &
    ""
        Me.Btn_Cerrar_Reclamo.Visible = False
        '
        'Btn_Anular
        '
        Me.Btn_Anular.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Anular.ForeColor = System.Drawing.Color.Black
        Me.Btn_Anular.Image = CType(resources.GetObject("Btn_Anular.Image"), System.Drawing.Image)
        Me.Btn_Anular.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Anular.Name = "Btn_Anular"
        Me.Btn_Anular.Tooltip = "Eliminar"
        Me.Btn_Anular.Visible = False
        '
        'Btn_Imprimir
        '
        Me.Btn_Imprimir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Imprimir.ForeColor = System.Drawing.Color.Black
        Me.Btn_Imprimir.Image = CType(resources.GetObject("Btn_Imprimir.Image"), System.Drawing.Image)
        Me.Btn_Imprimir.Name = "Btn_Imprimir"
        Me.Btn_Imprimir.Tooltip = "Imprimir"
        Me.Btn_Imprimir.Visible = False
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
        Me.Progeso_Gestion.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Estado_01_Ingreso, Me.Estado_02_Revision, Me.Estado_03_Recopilar_Informacion, Me.Estado_04_Resolucion, Me.Estado_05_Validacion, Me.Estado_06_Aviso_Cliente, Me.Estado_07_Gestionar_Reclamo})
        Me.Progeso_Gestion.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.Progeso_Gestion.Location = New System.Drawing.Point(6, 376)
        Me.Progeso_Gestion.Name = "Progeso_Gestion"
        Me.Progeso_Gestion.Size = New System.Drawing.Size(774, 43)
        Me.Progeso_Gestion.TabIndex = 99
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
        'LabelX2
        '
        Me.LabelX2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelX2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(6, 438)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(291, 23)
        Me.LabelX2.TabIndex = 105
        Me.LabelX2.Text = "Gestionar Reclamo"
        '
        'Progreso_Sub_Estados
        '
        Me.Progreso_Sub_Estados.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Progreso_Sub_Estados.AutoSize = True
        Me.Progreso_Sub_Estados.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Progreso_Sub_Estados.BackgroundStyle.Class = "ProgressSteps"
        Me.Progreso_Sub_Estados.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Progreso_Sub_Estados.ContainerControlProcessDialogKey = True
        Me.Progreso_Sub_Estados.ForeColor = System.Drawing.Color.Black
        Me.Progreso_Sub_Estados.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Sub_Estado_REM, Me.Sub_Estado_RVD, Me.Sub_Estado_DME_REP_EBV, Me.Sub_Estado_RAC, Me.Sub_Estado_RZC, Me.Sub_Estado_CIE})
        Me.Progreso_Sub_Estados.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.Progreso_Sub_Estados.Location = New System.Drawing.Point(6, 467)
        Me.Progreso_Sub_Estados.Name = "Progreso_Sub_Estados"
        Me.Progreso_Sub_Estados.Size = New System.Drawing.Size(746, 45)
        Me.Progreso_Sub_Estados.TabIndex = 104
        '
        'Sub_Estado_REM
        '
        Me.Sub_Estado_REM.HotTracking = False
        Me.Sub_Estado_REM.MinimumSize = New System.Drawing.Size(100, 0)
        Me.Sub_Estado_REM.Name = "Sub_Estado_REM"
        Me.Sub_Estado_REM.SymbolSize = 10.0!
        Me.Sub_Estado_REM.Text = "<font size=""+2""><b>Recepción</b></font><br/><font size=""-1"">Espera<br/>1ra etapa<" &
    "/font>"
        Me.Sub_Estado_REM.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Center
        Me.Sub_Estado_REM.Tooltip = "Creación de Orden de trabajo"
        '
        'Sub_Estado_RVD
        '
        Me.Sub_Estado_RVD.HotTracking = False
        Me.Sub_Estado_RVD.MinimumSize = New System.Drawing.Size(100, 0)
        Me.Sub_Estado_RVD.Name = "Sub_Estado_RVD"
        Me.Sub_Estado_RVD.SymbolSize = 13.0!
        Me.Sub_Estado_RVD.Text = "<font size=""+2""><b>Revisión devolución</b></font><br/><font size=""-1"">...<br/>2da" &
    " etapa</font>"
        Me.Sub_Estado_RVD.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Center
        Me.Sub_Estado_RVD.Tooltip = "Asignación de técnico"
        '
        'Sub_Estado_DME_REP_EBV
        '
        Me.Sub_Estado_DME_REP_EBV.HotTracking = False
        Me.Sub_Estado_DME_REP_EBV.Name = "Sub_Estado_DME_REP_EBV"
        Me.Sub_Estado_DME_REP_EBV.SymbolSize = 13.0!
        Me.Sub_Estado_DME_REP_EBV.Text = "<font size=""+2""><b>Destrucción Merc.</b></font><br/><font size=""-1"">...<br/>3ra e" &
    "tapa</font>"
        '
        'Sub_Estado_RAC
        '
        Me.Sub_Estado_RAC.HotTracking = False
        Me.Sub_Estado_RAC.Name = "Sub_Estado_RAC"
        Me.Sub_Estado_RAC.SymbolSize = 13.0!
        Me.Sub_Estado_RAC.Text = "<font size=""+2""><b>Recepción de acta</b></font><br/><font size=""-1"">...<br/>3ra e" &
    "tapa</font>"
        '
        'Sub_Estado_CIE
        '
        Me.Sub_Estado_CIE.HotTracking = False
        Me.Sub_Estado_CIE.MinimumSize = New System.Drawing.Size(100, 0)
        Me.Sub_Estado_CIE.Name = "Sub_Estado_CIE"
        Me.Sub_Estado_CIE.SymbolSize = 13.0!
        Me.Sub_Estado_CIE.Text = "<font size=""+2""><b>Cierre</b></font><br/><font size=""-1"">...<br/>4ta etapa</font>" &
    ""
        Me.Sub_Estado_CIE.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Center
        Me.Sub_Estado_CIE.Tooltip = "Generación de cotizacion"
        '
        'GroupPanel3
        '
        Me.GroupPanel3.BackColor = System.Drawing.Color.White
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.LabelX3)
        Me.GroupPanel3.Controls.Add(Me.Lbl_Sub_Tipo_Reclamo)
        Me.GroupPanel3.Controls.Add(Me.Txt_Descripcion_Reclamo)
        Me.GroupPanel3.Controls.Add(Me.LabelX10)
        Me.GroupPanel3.Controls.Add(Me.LabelX18)
        Me.GroupPanel3.Controls.Add(Me.Lbl_Tipo_De_Reclamo)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Location = New System.Drawing.Point(6, 208)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(774, 133)
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
        Me.GroupPanel3.TabIndex = 109
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(309, 3)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(52, 23)
        Me.LabelX3.TabIndex = 73
        Me.LabelX3.Text = "Sub tipo"
        '
        'Lbl_Sub_Tipo_Reclamo
        '
        Me.Lbl_Sub_Tipo_Reclamo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Sub_Tipo_Reclamo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Sub_Tipo_Reclamo.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Sub_Tipo_Reclamo.Location = New System.Drawing.Point(367, 3)
        Me.Lbl_Sub_Tipo_Reclamo.Name = "Lbl_Sub_Tipo_Reclamo"
        Me.Lbl_Sub_Tipo_Reclamo.Size = New System.Drawing.Size(195, 23)
        Me.Lbl_Sub_Tipo_Reclamo.TabIndex = 74
        Me.Lbl_Sub_Tipo_Reclamo.Text = "Número reclamo"
        '
        'Txt_Descripcion_Reclamo
        '
        Me.Txt_Descripcion_Reclamo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Descripcion_Reclamo.Border.Class = "TextBoxBorder"
        Me.Txt_Descripcion_Reclamo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Descripcion_Reclamo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Descripcion_Reclamo.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Descripcion_Reclamo.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Descripcion_Reclamo.FocusHighlightEnabled = True
        Me.Txt_Descripcion_Reclamo.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Txt_Descripcion_Reclamo.ForeColor = System.Drawing.Color.Black
        Me.Txt_Descripcion_Reclamo.Location = New System.Drawing.Point(93, 28)
        Me.Txt_Descripcion_Reclamo.MaxLength = 1000
        Me.Txt_Descripcion_Reclamo.Multiline = True
        Me.Txt_Descripcion_Reclamo.Name = "Txt_Descripcion_Reclamo"
        Me.Txt_Descripcion_Reclamo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Descripcion_Reclamo.Size = New System.Drawing.Size(670, 96)
        Me.Txt_Descripcion_Reclamo.TabIndex = 11
        '
        'LabelX10
        '
        Me.LabelX10.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelX10.ForeColor = System.Drawing.Color.Black
        Me.LabelX10.Location = New System.Drawing.Point(0, 28)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(76, 32)
        Me.LabelX10.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX10.TabIndex = 72
        Me.LabelX10.Text = "Descripción<br/> Reclamo"
        '
        'LabelX18
        '
        Me.LabelX18.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX18.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX18.ForeColor = System.Drawing.Color.Black
        Me.LabelX18.Location = New System.Drawing.Point(0, 3)
        Me.LabelX18.Name = "LabelX18"
        Me.LabelX18.Size = New System.Drawing.Size(94, 23)
        Me.LabelX18.TabIndex = 14
        Me.LabelX18.Text = "Tipo de reclamo"
        '
        'Lbl_Tipo_De_Reclamo
        '
        Me.Lbl_Tipo_De_Reclamo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Tipo_De_Reclamo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Tipo_De_Reclamo.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Tipo_De_Reclamo.Location = New System.Drawing.Point(93, 3)
        Me.Lbl_Tipo_De_Reclamo.Name = "Lbl_Tipo_De_Reclamo"
        Me.Lbl_Tipo_De_Reclamo.Size = New System.Drawing.Size(195, 23)
        Me.Lbl_Tipo_De_Reclamo.TabIndex = 15
        Me.Lbl_Tipo_De_Reclamo.Text = "Número reclamo"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Lbl_Sucursal_Ingreso)
        Me.GroupPanel1.Controls.Add(Me.LabelX6)
        Me.GroupPanel1.Controls.Add(Me.Lbl_Fecha_Emision)
        Me.GroupPanel1.Controls.Add(Me.Lbl_Vendedor)
        Me.GroupPanel1.Controls.Add(Me.LabelX24)
        Me.GroupPanel1.Controls.Add(Me.Lbl_Direccion)
        Me.GroupPanel1.Controls.Add(Me.LabelX9)
        Me.GroupPanel1.Controls.Add(Me.Lbl_Cliente)
        Me.GroupPanel1.Controls.Add(Me.LabelX7)
        Me.GroupPanel1.Controls.Add(Me.LabelX5)
        Me.GroupPanel1.Controls.Add(Me.Lbl_Numero)
        Me.GroupPanel1.Controls.Add(Me.LabelX1)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(6, 2)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(774, 86)
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
        Me.GroupPanel1.TabIndex = 110
        '
        'Lbl_Sucursal_Ingreso
        '
        Me.Lbl_Sucursal_Ingreso.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Sucursal_Ingreso.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Sucursal_Ingreso.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Sucursal_Ingreso.Location = New System.Drawing.Point(523, 32)
        Me.Lbl_Sucursal_Ingreso.Name = "Lbl_Sucursal_Ingreso"
        Me.Lbl_Sucursal_Ingreso.Size = New System.Drawing.Size(195, 23)
        Me.Lbl_Sucursal_Ingreso.TabIndex = 22
        Me.Lbl_Sucursal_Ingreso.Text = "USC. INGRESO RECLAMO"
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(398, 32)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(107, 23)
        Me.LabelX6.TabIndex = 21
        Me.LabelX6.Text = "Sucursal ingreso"
        '
        'Lbl_Fecha_Emision
        '
        Me.Lbl_Fecha_Emision.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Fecha_Emision.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Fecha_Emision.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Fecha_Emision.Location = New System.Drawing.Point(684, 3)
        Me.Lbl_Fecha_Emision.Name = "Lbl_Fecha_Emision"
        Me.Lbl_Fecha_Emision.Size = New System.Drawing.Size(70, 23)
        Me.Lbl_Fecha_Emision.TabIndex = 20
        Me.Lbl_Fecha_Emision.Text = "01/01/2000"
        '
        'Lbl_Vendedor
        '
        Me.Lbl_Vendedor.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Vendedor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Vendedor.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Vendedor.Location = New System.Drawing.Point(523, 54)
        Me.Lbl_Vendedor.Name = "Lbl_Vendedor"
        Me.Lbl_Vendedor.Size = New System.Drawing.Size(195, 23)
        Me.Lbl_Vendedor.TabIndex = 19
        Me.Lbl_Vendedor.Text = "VENDEDOR XXXXXXXXX"
        '
        'LabelX24
        '
        Me.LabelX24.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX24.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX24.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX24.ForeColor = System.Drawing.Color.Black
        Me.LabelX24.Location = New System.Drawing.Point(398, 55)
        Me.LabelX24.Name = "LabelX24"
        Me.LabelX24.Size = New System.Drawing.Size(107, 23)
        Me.LabelX24.TabIndex = 18
        Me.LabelX24.Text = "Vendedor"
        '
        'Lbl_Direccion
        '
        Me.Lbl_Direccion.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Direccion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Direccion.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Direccion.Location = New System.Drawing.Point(65, 55)
        Me.Lbl_Direccion.Name = "Lbl_Direccion"
        Me.Lbl_Direccion.Size = New System.Drawing.Size(368, 23)
        Me.Lbl_Direccion.TabIndex = 7
        Me.Lbl_Direccion.Text = "DIRECCION XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"
        '
        'LabelX9
        '
        Me.LabelX9.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX9.ForeColor = System.Drawing.Color.Black
        Me.LabelX9.Location = New System.Drawing.Point(3, 55)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(94, 23)
        Me.LabelX9.TabIndex = 6
        Me.LabelX9.Text = "Dirección"
        '
        'Lbl_Cliente
        '
        Me.Lbl_Cliente.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Cliente.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Cliente.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Cliente.Location = New System.Drawing.Point(65, 32)
        Me.Lbl_Cliente.Name = "Lbl_Cliente"
        Me.Lbl_Cliente.Size = New System.Drawing.Size(368, 23)
        Me.Lbl_Cliente.TabIndex = 5
        Me.Lbl_Cliente.Text = "RAZON SOCIAL DEL CLIENTE XXXXXXXXXXXXXXXXXXXXXXXXX"
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX7.ForeColor = System.Drawing.Color.Black
        Me.LabelX7.Location = New System.Drawing.Point(3, 32)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(94, 23)
        Me.LabelX7.TabIndex = 4
        Me.LabelX7.Text = "Cliente "
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(593, 3)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(85, 23)
        Me.LabelX5.TabIndex = 3
        Me.LabelX5.Text = "Fecha emisión"
        '
        'Lbl_Numero
        '
        Me.Lbl_Numero.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Numero.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Numero.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Numero.Location = New System.Drawing.Point(103, 3)
        Me.Lbl_Numero.Name = "Lbl_Numero"
        Me.Lbl_Numero.Size = New System.Drawing.Size(94, 23)
        Me.Lbl_Numero.TabIndex = 1
        Me.Lbl_Numero.Text = "9999999999"
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
        Me.LabelX1.Location = New System.Drawing.Point(3, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(94, 23)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "Número reclamo"
        '
        'Lbl_Sucursal_Elaboracion
        '
        Me.Lbl_Sucursal_Elaboracion.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Sucursal_Elaboracion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Sucursal_Elaboracion.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Sucursal_Elaboracion.Location = New System.Drawing.Point(116, 21)
        Me.Lbl_Sucursal_Elaboracion.Name = "Lbl_Sucursal_Elaboracion"
        Me.Lbl_Sucursal_Elaboracion.Size = New System.Drawing.Size(351, 23)
        Me.Lbl_Sucursal_Elaboracion.TabIndex = 17
        Me.Lbl_Sucursal_Elaboracion.Text = "SUCURSAL ELABORACION"
        '
        'LabelX21
        '
        Me.LabelX21.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX21.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX21.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX21.ForeColor = System.Drawing.Color.Black
        Me.LabelX21.Location = New System.Drawing.Point(3, 21)
        Me.LabelX21.Name = "LabelX21"
        Me.LabelX21.Size = New System.Drawing.Size(107, 23)
        Me.LabelX21.TabIndex = 16
        Me.LabelX21.Text = "Sucursal Elaboración"
        '
        'LabelX11
        '
        Me.LabelX11.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX11.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX11.ForeColor = System.Drawing.Color.Black
        Me.LabelX11.Location = New System.Drawing.Point(6, 3)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(94, 23)
        Me.LabelX11.TabIndex = 8
        Me.LabelX11.Text = "Contacto"
        '
        'Lbl_Nombre_Contacto
        '
        Me.Lbl_Nombre_Contacto.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Nombre_Contacto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Nombre_Contacto.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Nombre_Contacto.Location = New System.Drawing.Point(65, 3)
        Me.Lbl_Nombre_Contacto.Name = "Lbl_Nombre_Contacto"
        Me.Lbl_Nombre_Contacto.Size = New System.Drawing.Size(265, 23)
        Me.Lbl_Nombre_Contacto.TabIndex = 9
        Me.Lbl_Nombre_Contacto.Text = "NOMBRE DE CONTACTO XXXXXXXXX"
        '
        'Lbl_Telefono_Contacto
        '
        Me.Lbl_Telefono_Contacto.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Telefono_Contacto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Telefono_Contacto.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Telefono_Contacto.Location = New System.Drawing.Point(398, 3)
        Me.Lbl_Telefono_Contacto.Name = "Lbl_Telefono_Contacto"
        Me.Lbl_Telefono_Contacto.Size = New System.Drawing.Size(119, 23)
        Me.Lbl_Telefono_Contacto.TabIndex = 11
        Me.Lbl_Telefono_Contacto.Text = "9999999999999999"
        '
        'LabelX14
        '
        Me.LabelX14.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX14.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX14.ForeColor = System.Drawing.Color.Black
        Me.LabelX14.Location = New System.Drawing.Point(336, 3)
        Me.LabelX14.Name = "LabelX14"
        Me.LabelX14.Size = New System.Drawing.Size(57, 23)
        Me.LabelX14.TabIndex = 10
        Me.LabelX14.Text = "Telefono"
        '
        'Lbl_Email_Contacto
        '
        Me.Lbl_Email_Contacto.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Email_Contacto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Email_Contacto.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Email_Contacto.Location = New System.Drawing.Point(573, 3)
        Me.Lbl_Email_Contacto.Name = "Lbl_Email_Contacto"
        Me.Lbl_Email_Contacto.Size = New System.Drawing.Size(190, 23)
        Me.Lbl_Email_Contacto.TabIndex = 13
        Me.Lbl_Email_Contacto.Text = "EMAIL@CONTACTO.COM"
        '
        'LabelX16
        '
        Me.LabelX16.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX16.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX16.ForeColor = System.Drawing.Color.Black
        Me.LabelX16.Location = New System.Drawing.Point(523, 3)
        Me.LabelX16.Name = "LabelX16"
        Me.LabelX16.Size = New System.Drawing.Size(57, 23)
        Me.LabelX16.TabIndex = 12
        Me.LabelX16.Text = "Email"
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Lbl_Fecha_Elaboracion)
        Me.GroupPanel2.Controls.Add(Me.Lbl_Cantidad)
        Me.GroupPanel2.Controls.Add(Me.LabelX20)
        Me.GroupPanel2.Controls.Add(Me.Lbl_Producto)
        Me.GroupPanel2.Controls.Add(Me.LabelX33)
        Me.GroupPanel2.Controls.Add(Me.Lbl_Sucursal_Elaboracion)
        Me.GroupPanel2.Controls.Add(Me.LabelX31)
        Me.GroupPanel2.Controls.Add(Me.LabelX21)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(6, 136)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(774, 53)
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
        Me.GroupPanel2.TabIndex = 111
        '
        'Lbl_Fecha_Elaboracion
        '
        Me.Lbl_Fecha_Elaboracion.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Fecha_Elaboracion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Fecha_Elaboracion.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Fecha_Elaboracion.Location = New System.Drawing.Point(657, 21)
        Me.Lbl_Fecha_Elaboracion.Name = "Lbl_Fecha_Elaboracion"
        Me.Lbl_Fecha_Elaboracion.Size = New System.Drawing.Size(70, 23)
        Me.Lbl_Fecha_Elaboracion.TabIndex = 16
        Me.Lbl_Fecha_Elaboracion.Text = "01/01/2000"
        Me.Lbl_Fecha_Elaboracion.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Lbl_Cantidad
        '
        Me.Lbl_Cantidad.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Cantidad.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Cantidad.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Cantidad.Location = New System.Drawing.Point(651, 3)
        Me.Lbl_Cantidad.Name = "Lbl_Cantidad"
        Me.Lbl_Cantidad.Size = New System.Drawing.Size(76, 23)
        Me.Lbl_Cantidad.TabIndex = 15
        Me.Lbl_Cantidad.Text = "KG. 99.500"
        Me.Lbl_Cantidad.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX20
        '
        Me.LabelX20.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX20.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX20.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX20.ForeColor = System.Drawing.Color.Black
        Me.LabelX20.Location = New System.Drawing.Point(573, 3)
        Me.LabelX20.Name = "LabelX20"
        Me.LabelX20.Size = New System.Drawing.Size(56, 23)
        Me.LabelX20.TabIndex = 14
        Me.LabelX20.Text = "Cantidad"
        Me.LabelX20.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'Lbl_Producto
        '
        Me.Lbl_Producto.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Producto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Producto.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Producto.Location = New System.Drawing.Point(65, 3)
        Me.Lbl_Producto.Name = "Lbl_Producto"
        Me.Lbl_Producto.Size = New System.Drawing.Size(402, 23)
        Me.Lbl_Producto.TabIndex = 1
        Me.Lbl_Producto.Text = "XXXXXXXXXXXXX - XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"
        '
        'LabelX33
        '
        Me.LabelX33.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX33.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX33.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX33.ForeColor = System.Drawing.Color.Black
        Me.LabelX33.Location = New System.Drawing.Point(3, 3)
        Me.LabelX33.Name = "LabelX33"
        Me.LabelX33.Size = New System.Drawing.Size(94, 23)
        Me.LabelX33.TabIndex = 0
        Me.LabelX33.Text = "Producto"
        '
        'LabelX31
        '
        Me.LabelX31.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX31.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX31.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX31.ForeColor = System.Drawing.Color.Black
        Me.LabelX31.Location = New System.Drawing.Point(534, 21)
        Me.LabelX31.Name = "LabelX31"
        Me.LabelX31.Size = New System.Drawing.Size(95, 23)
        Me.LabelX31.TabIndex = 3
        Me.LabelX31.Text = "Fecha Elaboración"
        '
        'GroupPanel4
        '
        Me.GroupPanel4.BackColor = System.Drawing.Color.White
        Me.GroupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel4.Controls.Add(Me.Lbl_Email_Contacto)
        Me.GroupPanel4.Controls.Add(Me.Lbl_Nombre_Contacto)
        Me.GroupPanel4.Controls.Add(Me.LabelX14)
        Me.GroupPanel4.Controls.Add(Me.Lbl_Telefono_Contacto)
        Me.GroupPanel4.Controls.Add(Me.LabelX16)
        Me.GroupPanel4.Controls.Add(Me.LabelX11)
        Me.GroupPanel4.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel4.Location = New System.Drawing.Point(6, 94)
        Me.GroupPanel4.Name = "GroupPanel4"
        Me.GroupPanel4.Size = New System.Drawing.Size(774, 36)
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
        Me.GroupPanel4.TabIndex = 112
        '
        'Sub_Estado_RZC
        '
        Me.Sub_Estado_RZC.HotTracking = False
        Me.Sub_Estado_RZC.Name = "Sub_Estado_RZC"
        Me.Sub_Estado_RZC.SymbolSize = 13.0!
        Me.Sub_Estado_RZC.Text = "<font size=""+2""><b>Rechazado...</b></font><br/><font size=""-1"">...<br/>3ra etapa<" &
    "/font>"
        '
        'Frm_Rc_Reclamo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(788, 561)
        Me.Controls.Add(Me.GroupPanel4)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.GroupPanel3)
        Me.Controls.Add(Me.Progreso_Sub_Estados)
        Me.Controls.Add(Me.Progeso_Gestion)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.Bar2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Rc_Reclamo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FICHA RECLAMO (EMPRESA)"
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel3.ResumeLayout(False)
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel2.ResumeLayout(False)
        Me.GroupPanel4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Btn_Garantia_Ver_Documento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Garantia_Agregar_Documento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Garantia_Cambiar_Documento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Imprimir_Acta_ingreso As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Imprimir_Evaluacion_Tecnico As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Imprimir_Reporte_Final As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Documento_Sistema As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Documento_Externo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Doc_Externo_Boleta As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Doc_Externo_Factura As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Anular As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Cerrar_Reclamo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Imprimir As DevComponents.DotNetBar.ButtonItem
    Private WithEvents Progeso_Gestion As DevComponents.DotNetBar.ProgressSteps
    Private WithEvents Estado_01_Ingreso As DevComponents.DotNetBar.StepItem
    Private WithEvents Estado_02_Revision As DevComponents.DotNetBar.StepItem
    Private WithEvents Estado_03_Recopilar_Informacion As DevComponents.DotNetBar.StepItem
    Private WithEvents Estado_04_Resolucion As DevComponents.DotNetBar.StepItem
    Private WithEvents Estado_05_Validacion As DevComponents.DotNetBar.StepItem
    Friend WithEvents Estado_06_Aviso_Cliente As DevComponents.DotNetBar.StepItem
    Friend WithEvents Estado_07_Gestionar_Reclamo As DevComponents.DotNetBar.StepItem
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Private WithEvents Progreso_Sub_Estados As DevComponents.DotNetBar.ProgressSteps
    Private WithEvents Sub_Estado_REM As DevComponents.DotNetBar.StepItem
    Private WithEvents Sub_Estado_RVD As DevComponents.DotNetBar.StepItem
    Private WithEvents Sub_Estado_CIE As DevComponents.DotNetBar.StepItem
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Txt_Descripcion_Reclamo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Lbl_Vendedor As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX24 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Sucursal_Elaboracion As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX21 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Tipo_De_Reclamo As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX18 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Direccion As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Cliente As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Numero As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Nombre_Contacto As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Telefono_Contacto As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX14 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Email_Contacto As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX16 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Lbl_Cantidad As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX20 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX31 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Producto As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX33 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupPanel4 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Lbl_Fecha_Emision As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Fecha_Elaboracion As DevComponents.DotNetBar.LabelX
    Private WithEvents Sub_Estado_DME_REP_EBV As DevComponents.DotNetBar.StepItem
    Private WithEvents Sub_Estado_RAC As DevComponents.DotNetBar.StepItem
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Sub_Tipo_Reclamo As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Sucursal_Ingreso As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Private WithEvents Sub_Estado_RZC As DevComponents.DotNetBar.StepItem
End Class
