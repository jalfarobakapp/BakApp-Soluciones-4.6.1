<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Despacho
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Despacho))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupPanel4 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Lbl_Tipo_Venta = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Cambiar_Transporte = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Cambiar_Tipo_Envio = New DevComponents.DotNetBar.ButtonX()
        Me.Lbl_Transporte = New DevComponents.DotNetBar.LabelX()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Tipo_Envio = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Tipo_Despacho = New DevComponents.DotNetBar.LabelX()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Fecha_Despacho = New DevComponents.DotNetBar.LabelX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Datos_Entidad_Direccion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Progeso_Despacho = New DevComponents.DotNetBar.ProgressSteps()
        Me.Estado_01_Ingreso = New DevComponents.DotNetBar.StepItem()
        Me.Estado_02_Confirmacion = New DevComponents.DotNetBar.StepItem()
        Me.Estado_03_Preparacion = New DevComponents.DotNetBar.StepItem()
        Me.Estado_04_Despachar_Despachado = New DevComponents.DotNetBar.StepItem()
        Me.Estado_05_Cerrar_Despacho = New DevComponents.DotNetBar.StepItem()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Imprimir = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Anular = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Reenviar_Correos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Exportar_Excel = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Reenviar_Chilexpress = New DevComponents.DotNetBar.ButtonItem()
        Me.SuperTabControl1 = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.Btn_Modificar_Direccion = New DevComponents.DotNetBar.ButtonX()
        Me.SuperTabItem1 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel3 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.Grilla_Productos = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.SuperTabItem3 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_01 = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Ver_Documento = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Quitar_Documento = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla_Documentos = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.SuperTabItem2 = New DevComponents.DotNetBar.SuperTabItem()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Nro_Despacho = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Nombre_Entidad = New DevComponents.DotNetBar.LabelX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Referencia = New DevComponents.DotNetBar.LabelX()
        Me.LabelX24 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Responsable = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Fecha_Emision = New DevComponents.DotNetBar.LabelX()
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Nro_Sub = New DevComponents.DotNetBar.LabelX()
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Lbl_Nro_Encomienda = New DevComponents.DotNetBar.LabelX()
        Me.LabelX14 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Estado = New DevComponents.DotNetBar.LabelX()
        Me.Rimg_Estado = New DevComponents.DotNetBar.Controls.ReflectionImage()
        Me.Imagenes_48x48 = New System.Windows.Forms.ImageList(Me.components)
        Me.Imagenes_20x20 = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupPanel4.SuspendLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControl1.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        Me.SuperTabControlPanel3.SuspendLayout()
        CType(Me.Grilla_Productos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel2.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla_Documentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupPanel4
        '
        Me.GroupPanel4.BackColor = System.Drawing.Color.White
        Me.GroupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel4.Controls.Add(Me.Lbl_Tipo_Venta)
        Me.GroupPanel4.Controls.Add(Me.LabelX6)
        Me.GroupPanel4.Controls.Add(Me.Btn_Cambiar_Transporte)
        Me.GroupPanel4.Controls.Add(Me.Btn_Cambiar_Tipo_Envio)
        Me.GroupPanel4.Controls.Add(Me.Lbl_Transporte)
        Me.GroupPanel4.Controls.Add(Me.LabelX10)
        Me.GroupPanel4.Controls.Add(Me.Lbl_Tipo_Envio)
        Me.GroupPanel4.Controls.Add(Me.LabelX3)
        Me.GroupPanel4.Controls.Add(Me.Lbl_Tipo_Despacho)
        Me.GroupPanel4.Controls.Add(Me.LabelX11)
        Me.GroupPanel4.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel4.Location = New System.Drawing.Point(9, 106)
        Me.GroupPanel4.Name = "GroupPanel4"
        Me.GroupPanel4.Size = New System.Drawing.Size(774, 65)
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
        Me.GroupPanel4.TabIndex = 121
        '
        'Lbl_Tipo_Venta
        '
        Me.Lbl_Tipo_Venta.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Tipo_Venta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Tipo_Venta.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Tipo_Venta.Location = New System.Drawing.Point(400, 4)
        Me.Lbl_Tipo_Venta.Name = "Lbl_Tipo_Venta"
        Me.Lbl_Tipo_Venta.Size = New System.Drawing.Size(285, 23)
        Me.Lbl_Tipo_Venta.TabIndex = 17
        Me.Lbl_Tipo_Venta.Text = "TIPO DE VENTA XXXXXXXXXXXXX"
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
        Me.LabelX6.Location = New System.Drawing.Point(320, 4)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(94, 23)
        Me.LabelX6.TabIndex = 16
        Me.LabelX6.Text = "Tipo de venta"
        '
        'Btn_Cambiar_Transporte
        '
        Me.Btn_Cambiar_Transporte.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Cambiar_Transporte.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Cambiar_Transporte.Location = New System.Drawing.Point(538, 33)
        Me.Btn_Cambiar_Transporte.Name = "Btn_Cambiar_Transporte"
        Me.Btn_Cambiar_Transporte.Size = New System.Drawing.Size(50, 22)
        Me.Btn_Cambiar_Transporte.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Cambiar_Transporte.TabIndex = 15
        Me.Btn_Cambiar_Transporte.Text = "Cambiar"
        '
        'Btn_Cambiar_Tipo_Envio
        '
        Me.Btn_Cambiar_Tipo_Envio.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Cambiar_Tipo_Envio.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Cambiar_Tipo_Envio.Location = New System.Drawing.Point(264, 33)
        Me.Btn_Cambiar_Tipo_Envio.Name = "Btn_Cambiar_Tipo_Envio"
        Me.Btn_Cambiar_Tipo_Envio.Size = New System.Drawing.Size(50, 22)
        Me.Btn_Cambiar_Tipo_Envio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Cambiar_Tipo_Envio.TabIndex = 14
        Me.Btn_Cambiar_Tipo_Envio.Text = "Cambiar"
        '
        'Lbl_Transporte
        '
        Me.Lbl_Transporte.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Transporte.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Transporte.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Transporte.Location = New System.Drawing.Point(400, 33)
        Me.Lbl_Transporte.Name = "Lbl_Transporte"
        Me.Lbl_Transporte.Size = New System.Drawing.Size(132, 23)
        Me.Lbl_Transporte.TabIndex = 13
        Me.Lbl_Transporte.Text = "TRANSPORTE XXXXXXXXXXXXX"
        '
        'LabelX10
        '
        Me.LabelX10.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX10.ForeColor = System.Drawing.Color.Black
        Me.LabelX10.Location = New System.Drawing.Point(320, 33)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(62, 23)
        Me.LabelX10.TabIndex = 12
        Me.LabelX10.Text = "Transporte"
        '
        'Lbl_Tipo_Envio
        '
        Me.Lbl_Tipo_Envio.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Tipo_Envio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Tipo_Envio.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Tipo_Envio.Location = New System.Drawing.Point(103, 33)
        Me.Lbl_Tipo_Envio.Name = "Lbl_Tipo_Envio"
        Me.Lbl_Tipo_Envio.Size = New System.Drawing.Size(155, 23)
        Me.Lbl_Tipo_Envio.TabIndex = 11
        Me.Lbl_Tipo_Envio.Text = "TIPO DE ENVIO XXXXXXXXXXXXX"
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
        Me.LabelX3.Location = New System.Drawing.Point(3, 32)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(77, 23)
        Me.LabelX3.TabIndex = 10
        Me.LabelX3.Text = "Tipo de envío"
        '
        'Lbl_Tipo_Despacho
        '
        Me.Lbl_Tipo_Despacho.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Tipo_Despacho.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Tipo_Despacho.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Tipo_Despacho.Location = New System.Drawing.Point(103, 4)
        Me.Lbl_Tipo_Despacho.Name = "Lbl_Tipo_Despacho"
        Me.Lbl_Tipo_Despacho.Size = New System.Drawing.Size(211, 23)
        Me.Lbl_Tipo_Despacho.TabIndex = 9
        Me.Lbl_Tipo_Despacho.Text = "TIPO DE DESPACHO XXXXXXXXXXXXX"
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
        Me.LabelX11.Location = New System.Drawing.Point(3, 3)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(94, 23)
        Me.LabelX11.TabIndex = 8
        Me.LabelX11.Text = "Tipo de despacho"
        '
        'Lbl_Fecha_Despacho
        '
        Me.Lbl_Fecha_Despacho.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Fecha_Despacho.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Fecha_Despacho.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Fecha_Despacho.Location = New System.Drawing.Point(917, 99)
        Me.Lbl_Fecha_Despacho.Name = "Lbl_Fecha_Despacho"
        Me.Lbl_Fecha_Despacho.Size = New System.Drawing.Size(70, 23)
        Me.Lbl_Fecha_Despacho.TabIndex = 24
        Me.Lbl_Fecha_Despacho.Text = "01/01/2000"
        '
        'LabelX8
        '
        Me.LabelX8.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX8.ForeColor = System.Drawing.Color.Black
        Me.LabelX8.Location = New System.Drawing.Point(826, 99)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(85, 23)
        Me.LabelX8.TabIndex = 23
        Me.LabelX8.Text = "Fecha despacho"
        '
        'Txt_Datos_Entidad_Direccion
        '
        Me.Txt_Datos_Entidad_Direccion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Datos_Entidad_Direccion.Border.Class = "TextBoxBorder"
        Me.Txt_Datos_Entidad_Direccion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Datos_Entidad_Direccion.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Datos_Entidad_Direccion.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Datos_Entidad_Direccion.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Txt_Datos_Entidad_Direccion.ForeColor = System.Drawing.Color.Black
        Me.Txt_Datos_Entidad_Direccion.Location = New System.Drawing.Point(3, 3)
        Me.Txt_Datos_Entidad_Direccion.MaxLength = 1000
        Me.Txt_Datos_Entidad_Direccion.Multiline = True
        Me.Txt_Datos_Entidad_Direccion.Name = "Txt_Datos_Entidad_Direccion"
        Me.Txt_Datos_Entidad_Direccion.ReadOnly = True
        Me.Txt_Datos_Entidad_Direccion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Datos_Entidad_Direccion.Size = New System.Drawing.Size(768, 194)
        Me.Txt_Datos_Entidad_Direccion.TabIndex = 11
        '
        'Progeso_Despacho
        '
        Me.Progeso_Despacho.AutoSize = True
        Me.Progeso_Despacho.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Progeso_Despacho.BackgroundStyle.Class = "ProgressSteps"
        Me.Progeso_Despacho.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Progeso_Despacho.ContainerControlProcessDialogKey = True
        Me.Progeso_Despacho.ForeColor = System.Drawing.Color.Black
        Me.Progeso_Despacho.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Estado_01_Ingreso, Me.Estado_02_Confirmacion, Me.Estado_03_Preparacion, Me.Estado_04_Despachar_Despachado, Me.Estado_05_Cerrar_Despacho})
        Me.Progeso_Despacho.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.Progeso_Despacho.Location = New System.Drawing.Point(12, 459)
        Me.Progeso_Despacho.Name = "Progeso_Despacho"
        Me.Progeso_Despacho.Size = New System.Drawing.Size(771, 43)
        Me.Progeso_Despacho.TabIndex = 113
        '
        'Estado_01_Ingreso
        '
        Me.Estado_01_Ingreso.HotTracking = False
        Me.Estado_01_Ingreso.Image = CType(resources.GetObject("Estado_01_Ingreso.Image"), System.Drawing.Image)
        Me.Estado_01_Ingreso.ImageTextSpacing = 10
        Me.Estado_01_Ingreso.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center
        Me.Estado_01_Ingreso.MinimumSize = New System.Drawing.Size(100, 0)
        Me.Estado_01_Ingreso.Name = "Estado_01_Ingreso"
        Me.Estado_01_Ingreso.SymbolSize = 10.0!
        Me.Estado_01_Ingreso.Text = "<font size=""+1""><b>Ingresado</b></font><br/><font size=""-1"">Espera<br/>1ra etapa<" &
    "/font>"
        Me.Estado_01_Ingreso.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Center
        Me.Estado_01_Ingreso.Tooltip = "Creación de Orden de trabajo"
        '
        'Estado_02_Confirmacion
        '
        Me.Estado_02_Confirmacion.HotTracking = False
        Me.Estado_02_Confirmacion.Image = CType(resources.GetObject("Estado_02_Confirmacion.Image"), System.Drawing.Image)
        Me.Estado_02_Confirmacion.MinimumSize = New System.Drawing.Size(100, 0)
        Me.Estado_02_Confirmacion.Name = "Estado_02_Confirmacion"
        Me.Estado_02_Confirmacion.SymbolSize = 13.0!
        Me.Estado_02_Confirmacion.Text = "<font size=""+1""><b>Confirmación</b></font><br/><font size=""-1"">...<br/>2da etapa<" &
    "/font>"
        Me.Estado_02_Confirmacion.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Center
        Me.Estado_02_Confirmacion.Tooltip = "Apertura de reclamo por parte del personal autorizado, enviar a revisión"
        '
        'Estado_03_Preparacion
        '
        Me.Estado_03_Preparacion.HotTracking = False
        Me.Estado_03_Preparacion.Image = CType(resources.GetObject("Estado_03_Preparacion.Image"), System.Drawing.Image)
        Me.Estado_03_Preparacion.Name = "Estado_03_Preparacion"
        Me.Estado_03_Preparacion.SymbolSize = 13.0!
        Me.Estado_03_Preparacion.Text = "<font size=""+1""><b>Preparación</b></font><br/><font size=""-1"">Armar bulto...<br/>" &
    "3ra etapa</font>"
        '
        'Estado_04_Despachar_Despachado
        '
        Me.Estado_04_Despachar_Despachado.HotTracking = False
        Me.Estado_04_Despachar_Despachado.Image = CType(resources.GetObject("Estado_04_Despachar_Despachado.Image"), System.Drawing.Image)
        Me.Estado_04_Despachar_Despachado.Name = "Estado_04_Despachar_Despachado"
        Me.Estado_04_Despachar_Despachado.SymbolSize = 13.0!
        Me.Estado_04_Despachar_Despachado.Text = "<font size=""+1""><b>Despachar</b></font><br/><font size=""-1"">...<br/>4ta Etapa</fo" &
    "nt>"
        '
        'Estado_05_Cerrar_Despacho
        '
        Me.Estado_05_Cerrar_Despacho.HotTracking = False
        Me.Estado_05_Cerrar_Despacho.Image = CType(resources.GetObject("Estado_05_Cerrar_Despacho.Image"), System.Drawing.Image)
        Me.Estado_05_Cerrar_Despacho.Name = "Estado_05_Cerrar_Despacho"
        Me.Estado_05_Cerrar_Despacho.SymbolSize = 13.0!
        Me.Estado_05_Cerrar_Despacho.Text = "<font size=""+1""><b>Cerrar despacho</b></font><br/><font size=""-1"">...<br/>5ta Eta" &
    "pa</font>"
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(12, 430)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(291, 23)
        Me.LabelX4.TabIndex = 114
        Me.LabelX4.Text = "<font color=""#4E5D30""><b><font color=""#22B14C""><font color=""#0072BC"">ESTADOS</fon" &
    "t></font></b></font> (Flujo de trabajo)"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Imprimir, Me.Btn_Anular, Me.Btn_Reenviar_Correos, Me.Btn_Exportar_Excel, Me.Btn_Reenviar_Chilexpress})
        Me.Bar2.Location = New System.Drawing.Point(0, 521)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(794, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 115
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Imprimir
        '
        Me.Btn_Imprimir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Imprimir.ForeColor = System.Drawing.Color.Black
        Me.Btn_Imprimir.Image = CType(resources.GetObject("Btn_Imprimir.Image"), System.Drawing.Image)
        Me.Btn_Imprimir.ImageAlt = CType(resources.GetObject("Btn_Imprimir.ImageAlt"), System.Drawing.Image)
        Me.Btn_Imprimir.Name = "Btn_Imprimir"
        Me.Btn_Imprimir.Tooltip = "Imprimir"
        '
        'Btn_Anular
        '
        Me.Btn_Anular.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Anular.ForeColor = System.Drawing.Color.Black
        Me.Btn_Anular.Image = CType(resources.GetObject("Btn_Anular.Image"), System.Drawing.Image)
        Me.Btn_Anular.ImageAlt = CType(resources.GetObject("Btn_Anular.ImageAlt"), System.Drawing.Image)
        Me.Btn_Anular.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Anular.Name = "Btn_Anular"
        Me.Btn_Anular.Tooltip = "Eliminar"
        '
        'Btn_Reenviar_Correos
        '
        Me.Btn_Reenviar_Correos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Reenviar_Correos.ForeColor = System.Drawing.Color.Black
        Me.Btn_Reenviar_Correos.Image = CType(resources.GetObject("Btn_Reenviar_Correos.Image"), System.Drawing.Image)
        Me.Btn_Reenviar_Correos.ImageAlt = CType(resources.GetObject("Btn_Reenviar_Correos.ImageAlt"), System.Drawing.Image)
        Me.Btn_Reenviar_Correos.Name = "Btn_Reenviar_Correos"
        Me.Btn_Reenviar_Correos.Tooltip = "Reenviar correos"
        '
        'Btn_Exportar_Excel
        '
        Me.Btn_Exportar_Excel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Exportar_Excel.ForeColor = System.Drawing.Color.Black
        Me.Btn_Exportar_Excel.Image = CType(resources.GetObject("Btn_Exportar_Excel.Image"), System.Drawing.Image)
        Me.Btn_Exportar_Excel.ImageAlt = CType(resources.GetObject("Btn_Exportar_Excel.ImageAlt"), System.Drawing.Image)
        Me.Btn_Exportar_Excel.Name = "Btn_Exportar_Excel"
        Me.Btn_Exportar_Excel.Tooltip = "Exportar Excel"
        '
        'Btn_Reenviar_Chilexpress
        '
        Me.Btn_Reenviar_Chilexpress.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Reenviar_Chilexpress.ForeColor = System.Drawing.Color.Black
        Me.Btn_Reenviar_Chilexpress.Image = CType(resources.GetObject("Btn_Reenviar_Chilexpress.Image"), System.Drawing.Image)
        Me.Btn_Reenviar_Chilexpress.ImageAlt = CType(resources.GetObject("Btn_Reenviar_Chilexpress.ImageAlt"), System.Drawing.Image)
        Me.Btn_Reenviar_Chilexpress.Name = "Btn_Reenviar_Chilexpress"
        Me.Btn_Reenviar_Chilexpress.Text = "CHILEXPRESS"
        '
        'SuperTabControl1
        '
        Me.SuperTabControl1.BackColor = System.Drawing.Color.White
        '
        '
        '
        '
        '
        '
        Me.SuperTabControl1.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.SuperTabControl1.ControlBox.MenuBox.Name = ""
        Me.SuperTabControl1.ControlBox.Name = ""
        Me.SuperTabControl1.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabControl1.ControlBox.MenuBox, Me.SuperTabControl1.ControlBox.CloseBox})
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel1)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel3)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel2)
        Me.SuperTabControl1.ForeColor = System.Drawing.Color.Black
        Me.SuperTabControl1.Location = New System.Drawing.Point(12, 186)
        Me.SuperTabControl1.Name = "SuperTabControl1"
        Me.SuperTabControl1.ReorderTabsEnabled = True
        Me.SuperTabControl1.SelectedTabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.SuperTabControl1.SelectedTabIndex = 0
        Me.SuperTabControl1.Size = New System.Drawing.Size(774, 238)
        Me.SuperTabControl1.TabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SuperTabControl1.TabIndex = 122
        Me.SuperTabControl1.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabItem1, Me.SuperTabItem3, Me.SuperTabItem2})
        Me.SuperTabControl1.Text = "SuperTabControl1"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.Btn_Modificar_Direccion)
        Me.SuperTabControlPanel1.Controls.Add(Me.Txt_Datos_Entidad_Direccion)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 38)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(774, 200)
        Me.SuperTabControlPanel1.TabIndex = 1
        Me.SuperTabControlPanel1.TabItem = Me.SuperTabItem1
        '
        'Btn_Modificar_Direccion
        '
        Me.Btn_Modificar_Direccion.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Modificar_Direccion.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Modificar_Direccion.Location = New System.Drawing.Point(651, 14)
        Me.Btn_Modificar_Direccion.Name = "Btn_Modificar_Direccion"
        Me.Btn_Modificar_Direccion.Size = New System.Drawing.Size(90, 23)
        Me.Btn_Modificar_Direccion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Modificar_Direccion.TabIndex = 13
        Me.Btn_Modificar_Direccion.Text = "Modificar"
        Me.Btn_Modificar_Direccion.Tooltip = "Modificar datos de envío y observaciones"
        '
        'SuperTabItem1
        '
        Me.SuperTabItem1.AttachedControl = Me.SuperTabControlPanel1
        Me.SuperTabItem1.GlobalItem = False
        Me.SuperTabItem1.Image = CType(resources.GetObject("SuperTabItem1.Image"), System.Drawing.Image)
        Me.SuperTabItem1.Name = "SuperTabItem1"
        Me.SuperTabItem1.Text = "Dirección de envío"
        '
        'SuperTabControlPanel3
        '
        Me.SuperTabControlPanel3.Controls.Add(Me.Grilla_Productos)
        Me.SuperTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel3.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel3.Name = "SuperTabControlPanel3"
        Me.SuperTabControlPanel3.Size = New System.Drawing.Size(774, 238)
        Me.SuperTabControlPanel3.TabIndex = 0
        Me.SuperTabControlPanel3.TabItem = Me.SuperTabItem3
        '
        'Grilla_Productos
        '
        Me.Grilla_Productos.AllowUserToAddRows = False
        Me.Grilla_Productos.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Productos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grilla_Productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Productos.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grilla_Productos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Productos.EnableHeadersVisualStyles = False
        Me.Grilla_Productos.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Productos.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Productos.Name = "Grilla_Productos"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Productos.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla_Productos.Size = New System.Drawing.Size(774, 238)
        Me.Grilla_Productos.StandardTab = True
        Me.Grilla_Productos.TabIndex = 29
        '
        'SuperTabItem3
        '
        Me.SuperTabItem3.AttachedControl = Me.SuperTabControlPanel3
        Me.SuperTabItem3.GlobalItem = False
        Me.SuperTabItem3.Image = CType(resources.GetObject("SuperTabItem3.Image"), System.Drawing.Image)
        Me.SuperTabItem3.Name = "SuperTabItem3"
        Me.SuperTabItem3.Text = "Productos"
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Controls.Add(Me.ContextMenuBar1)
        Me.SuperTabControlPanel2.Controls.Add(Me.Grilla_Documentos)
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(774, 238)
        Me.SuperTabControlPanel2.TabIndex = 0
        Me.SuperTabControlPanel2.TabItem = Me.SuperTabItem2
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_01})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(179, 28)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(153, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 47
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_01
        '
        Me.Menu_Contextual_01.AutoExpandOnClick = True
        Me.Menu_Contextual_01.Name = "Menu_Contextual_01"
        Me.Menu_Contextual_01.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1, Me.Btn_Ver_Documento, Me.Btn_Quitar_Documento})
        Me.Menu_Contextual_01.Text = "Opciones"
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
        Me.LabelItem1.Text = "Opciones"
        '
        'Btn_Ver_Documento
        '
        Me.Btn_Ver_Documento.Image = CType(resources.GetObject("Btn_Ver_Documento.Image"), System.Drawing.Image)
        Me.Btn_Ver_Documento.Name = "Btn_Ver_Documento"
        Me.Btn_Ver_Documento.Text = "Ver documento"
        '
        'Btn_Quitar_Documento
        '
        Me.Btn_Quitar_Documento.Image = CType(resources.GetObject("Btn_Quitar_Documento.Image"), System.Drawing.Image)
        Me.Btn_Quitar_Documento.Name = "Btn_Quitar_Documento"
        Me.Btn_Quitar_Documento.Text = "Quitar documento de la orden"
        '
        'Grilla_Documentos
        '
        Me.Grilla_Documentos.AllowUserToAddRows = False
        Me.Grilla_Documentos.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Documentos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Grilla_Documentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Documentos.DefaultCellStyle = DataGridViewCellStyle5
        Me.Grilla_Documentos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Documentos.EnableHeadersVisualStyles = False
        Me.Grilla_Documentos.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Documentos.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Documentos.Name = "Grilla_Documentos"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Documentos.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Grilla_Documentos.Size = New System.Drawing.Size(774, 238)
        Me.Grilla_Documentos.StandardTab = True
        Me.Grilla_Documentos.TabIndex = 28
        '
        'SuperTabItem2
        '
        Me.SuperTabItem2.AttachedControl = Me.SuperTabControlPanel2
        Me.SuperTabItem2.GlobalItem = False
        Me.SuperTabItem2.Image = CType(resources.GetObject("SuperTabItem2.Image"), System.Drawing.Image)
        Me.SuperTabItem2.Name = "SuperTabItem2"
        Me.SuperTabItem2.Text = "Documentos"
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
        Me.LabelX1.Text = "Número orden"
        '
        'Lbl_Nro_Despacho
        '
        Me.Lbl_Nro_Despacho.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Nro_Despacho.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Nro_Despacho.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Nro_Despacho.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Nro_Despacho.Location = New System.Drawing.Point(88, 3)
        Me.Lbl_Nro_Despacho.Name = "Lbl_Nro_Despacho"
        Me.Lbl_Nro_Despacho.Size = New System.Drawing.Size(119, 23)
        Me.Lbl_Nro_Despacho.TabIndex = 1
        Me.Lbl_Nro_Despacho.Text = "9999999999"
        Me.Lbl_Nro_Despacho.TextAlignment = System.Drawing.StringAlignment.Center
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
        Me.LabelX5.Location = New System.Drawing.Point(524, 3)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(85, 23)
        Me.LabelX5.TabIndex = 3
        Me.LabelX5.Text = "Fecha emisión"
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
        Me.LabelX7.Location = New System.Drawing.Point(3, 48)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(56, 23)
        Me.LabelX7.TabIndex = 4
        Me.LabelX7.Text = "Cliente "
        '
        'Lbl_Nombre_Entidad
        '
        Me.Lbl_Nombre_Entidad.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Nombre_Entidad.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Nombre_Entidad.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Nombre_Entidad.Location = New System.Drawing.Point(88, 48)
        Me.Lbl_Nombre_Entidad.Name = "Lbl_Nombre_Entidad"
        Me.Lbl_Nombre_Entidad.Size = New System.Drawing.Size(327, 23)
        Me.Lbl_Nombre_Entidad.TabIndex = 5
        Me.Lbl_Nombre_Entidad.Text = "RAZON SOCIAL DEL CLIENTE XXXXXXXXXXXXXXXXXXXXXXXXX"
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
        Me.LabelX9.Location = New System.Drawing.Point(3, 70)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(56, 23)
        Me.LabelX9.TabIndex = 6
        Me.LabelX9.Text = "Referencia"
        '
        'Lbl_Referencia
        '
        Me.Lbl_Referencia.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Referencia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Referencia.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Referencia.Location = New System.Drawing.Point(88, 70)
        Me.Lbl_Referencia.Name = "Lbl_Referencia"
        Me.Lbl_Referencia.Size = New System.Drawing.Size(314, 23)
        Me.Lbl_Referencia.TabIndex = 7
        Me.Lbl_Referencia.Text = "REFERENCIA XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"
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
        Me.LabelX24.Location = New System.Drawing.Point(433, 48)
        Me.LabelX24.Name = "LabelX24"
        Me.LabelX24.Size = New System.Drawing.Size(107, 23)
        Me.LabelX24.TabIndex = 18
        Me.LabelX24.Text = "Responsable"
        '
        'Lbl_Responsable
        '
        Me.Lbl_Responsable.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Responsable.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Responsable.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Responsable.Location = New System.Drawing.Point(541, 48)
        Me.Lbl_Responsable.Name = "Lbl_Responsable"
        Me.Lbl_Responsable.Size = New System.Drawing.Size(132, 23)
        Me.Lbl_Responsable.TabIndex = 19
        Me.Lbl_Responsable.Text = "VENDEDOR XXXXXXXXX"
        '
        'Lbl_Fecha_Emision
        '
        Me.Lbl_Fecha_Emision.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Fecha_Emision.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Fecha_Emision.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Fecha_Emision.Location = New System.Drawing.Point(603, 3)
        Me.Lbl_Fecha_Emision.Name = "Lbl_Fecha_Emision"
        Me.Lbl_Fecha_Emision.Size = New System.Drawing.Size(70, 23)
        Me.Lbl_Fecha_Emision.TabIndex = 20
        Me.Lbl_Fecha_Emision.Text = "01/01/2000"
        '
        'LabelX12
        '
        Me.LabelX12.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX12.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX12.ForeColor = System.Drawing.Color.Black
        Me.LabelX12.Location = New System.Drawing.Point(216, 3)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(59, 23)
        Me.LabelX12.TabIndex = 23
        Me.LabelX12.Text = "Sub-Orden"
        '
        'Lbl_Nro_Sub
        '
        Me.Lbl_Nro_Sub.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Nro_Sub.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Nro_Sub.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Nro_Sub.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Nro_Sub.Location = New System.Drawing.Point(281, 3)
        Me.Lbl_Nro_Sub.Name = "Lbl_Nro_Sub"
        Me.Lbl_Nro_Sub.Size = New System.Drawing.Size(48, 23)
        Me.Lbl_Nro_Sub.TabIndex = 24
        Me.Lbl_Nro_Sub.Text = "999"
        Me.Lbl_Nro_Sub.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX13
        '
        Me.LabelX13.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX13.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX13.ForeColor = System.Drawing.Color.Black
        Me.LabelX13.Location = New System.Drawing.Point(3, 26)
        Me.LabelX13.Name = "LabelX13"
        Me.LabelX13.Size = New System.Drawing.Size(44, 23)
        Me.LabelX13.TabIndex = 25
        Me.LabelX13.Text = "Estado"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Lbl_Nro_Encomienda)
        Me.GroupPanel1.Controls.Add(Me.LabelX14)
        Me.GroupPanel1.Controls.Add(Me.Lbl_Estado)
        Me.GroupPanel1.Controls.Add(Me.LabelX13)
        Me.GroupPanel1.Controls.Add(Me.Lbl_Nro_Sub)
        Me.GroupPanel1.Controls.Add(Me.LabelX12)
        Me.GroupPanel1.Controls.Add(Me.Lbl_Fecha_Emision)
        Me.GroupPanel1.Controls.Add(Me.Lbl_Responsable)
        Me.GroupPanel1.Controls.Add(Me.LabelX24)
        Me.GroupPanel1.Controls.Add(Me.Lbl_Referencia)
        Me.GroupPanel1.Controls.Add(Me.LabelX9)
        Me.GroupPanel1.Controls.Add(Me.Lbl_Nombre_Entidad)
        Me.GroupPanel1.Controls.Add(Me.LabelX7)
        Me.GroupPanel1.Controls.Add(Me.LabelX5)
        Me.GroupPanel1.Controls.Add(Me.Lbl_Nro_Despacho)
        Me.GroupPanel1.Controls.Add(Me.LabelX1)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(9, 1)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(680, 99)
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
        Me.GroupPanel1.TabIndex = 119
        '
        'Lbl_Nro_Encomienda
        '
        Me.Lbl_Nro_Encomienda.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Nro_Encomienda.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Nro_Encomienda.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Nro_Encomienda.Location = New System.Drawing.Point(541, 70)
        Me.Lbl_Nro_Encomienda.Name = "Lbl_Nro_Encomienda"
        Me.Lbl_Nro_Encomienda.Size = New System.Drawing.Size(132, 23)
        Me.Lbl_Nro_Encomienda.TabIndex = 28
        Me.Lbl_Nro_Encomienda.Text = "VENDEDOR XXXXXXXXX"
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
        Me.LabelX14.Location = New System.Drawing.Point(433, 70)
        Me.LabelX14.Name = "LabelX14"
        Me.LabelX14.Size = New System.Drawing.Size(107, 23)
        Me.LabelX14.TabIndex = 27
        Me.LabelX14.Text = "Nro. Encomienda"
        '
        'Lbl_Estado
        '
        Me.Lbl_Estado.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Estado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Estado.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Estado.Location = New System.Drawing.Point(88, 26)
        Me.Lbl_Estado.Name = "Lbl_Estado"
        Me.Lbl_Estado.Size = New System.Drawing.Size(327, 23)
        Me.Lbl_Estado.TabIndex = 26
        Me.Lbl_Estado.Text = "RAZON SOCIAL DEL CLIENTE XXXXXXXXXXXXXXXXXXXXXXXXX"
        '
        'Rimg_Estado
        '
        Me.Rimg_Estado.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Rimg_Estado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rimg_Estado.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Rimg_Estado.ForeColor = System.Drawing.Color.Black
        Me.Rimg_Estado.Image = CType(resources.GetObject("Rimg_Estado.Image"), System.Drawing.Image)
        Me.Rimg_Estado.Location = New System.Drawing.Point(692, 1)
        Me.Rimg_Estado.Name = "Rimg_Estado"
        Me.Rimg_Estado.Size = New System.Drawing.Size(96, 99)
        Me.Rimg_Estado.TabIndex = 123
        '
        'Imagenes_48x48
        '
        Me.Imagenes_48x48.ImageStream = CType(resources.GetObject("Imagenes_48x48.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagenes_48x48.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagenes_48x48.Images.SetKeyName(0, "delivery_list-delay.png")
        Me.Imagenes_48x48.Images.SetKeyName(1, "package_open-delay.png")
        Me.Imagenes_48x48.Images.SetKeyName(2, "package-ok.png")
        Me.Imagenes_48x48.Images.SetKeyName(3, "trolley-team.png")
        Me.Imagenes_48x48.Images.SetKeyName(4, "truck_load_full.png")
        Me.Imagenes_48x48.Images.SetKeyName(5, "hand_delivery-team.png")
        '
        'Imagenes_20x20
        '
        Me.Imagenes_20x20.ImageStream = CType(resources.GetObject("Imagenes_20x20.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagenes_20x20.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagenes_20x20.Images.SetKeyName(0, "delivery_list-delay.png")
        Me.Imagenes_20x20.Images.SetKeyName(1, "delivery_list-ok.png")
        Me.Imagenes_20x20.Images.SetKeyName(2, "package_open-delay.png")
        Me.Imagenes_20x20.Images.SetKeyName(3, "truck_load_full.png")
        Me.Imagenes_20x20.Images.SetKeyName(4, "hand_delivery-user.png")
        Me.Imagenes_20x20.Images.SetKeyName(5, "package_open-delay.png")
        Me.Imagenes_20x20.Images.SetKeyName(6, "trolley-delay.png")
        Me.Imagenes_20x20.Images.SetKeyName(7, "hand_delivery-delay.png")
        '
        'Frm_Despacho
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(794, 562)
        Me.Controls.Add(Me.Rimg_Estado)
        Me.Controls.Add(Me.Lbl_Fecha_Despacho)
        Me.Controls.Add(Me.SuperTabControl1)
        Me.Controls.Add(Me.LabelX8)
        Me.Controls.Add(Me.GroupPanel4)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Progeso_Despacho)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.Bar2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Despacho"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        Me.GroupPanel4.ResumeLayout(False)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControl1.ResumeLayout(False)
        Me.SuperTabControlPanel1.ResumeLayout(False)
        Me.SuperTabControlPanel3.ResumeLayout(False)
        CType(Me.Grilla_Productos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel2.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla_Documentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupPanel4 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Lbl_Tipo_Despacho As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Datos_Entidad_Direccion As DevComponents.DotNetBar.Controls.TextBoxX
    Private WithEvents Progeso_Despacho As DevComponents.DotNetBar.ProgressSteps
    Private WithEvents Estado_01_Ingreso As DevComponents.DotNetBar.StepItem
    Private WithEvents Estado_02_Confirmacion As DevComponents.DotNetBar.StepItem
    'Private WithEvents Estado_05_Despachado As DevComponents.DotNetBar.StepItem
    Friend WithEvents Estado_05_Cerrar_Despacho As DevComponents.DotNetBar.StepItem
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Anular As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Imprimir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Lbl_Fecha_Despacho As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents SuperTabControl1 As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem1 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem2 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel3 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem3 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents Grilla_Documentos As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Grilla_Productos As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_01 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Ver_Documento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Quitar_Documento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Lbl_Tipo_Envio As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Transporte As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Private WithEvents Estado_03_Preparacion As DevComponents.DotNetBar.StepItem
    Friend WithEvents Estado_04_Despachar_Despachado As DevComponents.DotNetBar.StepItem
    Friend WithEvents Btn_Cambiar_Transporte As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Cambiar_Tipo_Envio As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Modificar_Direccion As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Nro_Despacho As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Nombre_Entidad As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Referencia As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX24 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Responsable As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Fecha_Emision As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Nro_Sub As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Lbl_Estado As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rimg_Estado As DevComponents.DotNetBar.Controls.ReflectionImage
    Friend WithEvents Imagenes_48x48 As ImageList
    Friend WithEvents Imagenes_20x20 As ImageList
    Friend WithEvents Lbl_Nro_Encomienda As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX14 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Reenviar_Correos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Lbl_Tipo_Venta As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Exportar_Excel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Reenviar_Chilexpress As DevComponents.DotNetBar.ButtonItem
End Class
