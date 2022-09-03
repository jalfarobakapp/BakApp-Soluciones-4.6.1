<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Inf_Vencimientos_Detalle_Documentos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Inf_Vencimientos_Detalle_Documentos))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_01_Opciones_Documento = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Ver_documento = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Ver_Anotaciones_Documento = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_02_Anotaciones = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Anotacion_Telefono = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Anotacion_Mail = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Anotacion_Visita_Cliente = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_03_Exportar_Excel = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem3 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Exportar_Informe_01_Vista_Actual = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Exportar_Informe_02_Mostrar_todas_las_Anotaciones = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Exportar_Informe_03_Entidades = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_04_Pago_Proveedores = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem4 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Pagar_A_Proveedores_Autorizados = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_04_Opciones_Cobranza = New DevComponents.DotNetBar.ButtonItem()
        Me.Lbl_Mnu_1 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Mnu_Ficha_Entidad = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem5 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Mnu_Mostrar_deuda_actual = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Mostrar_deuda_completa = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Enviar_Correo_Cobranza = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Enviar_Correo_Cobranza_Deuda_Completa = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Actualizar_Informacion = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Buscar_Documento = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Exportar_Excel = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mover = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Enviar_correo = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Anotaciones_al_documento = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Marcar_Masivamente_Anotaciones_De_Documentos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Imprimir = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Autorizar_Pago_Proveedor = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Autorizar_Pago_De_Documentos_Proveedores = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Lbl_Nombre_Entidad = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Lbl_Total_Saldos = New DevComponents.DotNetBar.LabelX()
        Me.Chk_Marcar_todo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Mostrar_Pagos_Pendientes = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        Me.GroupPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.ContextMenuBar1)
        Me.GroupPanel1.Controls.Add(Me.Grilla)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(999, 423)
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
        Me.GroupPanel1.TabIndex = 37
        Me.GroupPanel1.Text = "Detalle"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_01_Opciones_Documento, Me.Menu_Contextual_02_Anotaciones, Me.Menu_Contextual_03_Exportar_Excel, Me.Menu_Contextual_04_Pago_Proveedores, Me.Menu_Contextual_04_Opciones_Cobranza})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(211, 120)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(685, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 46
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_01_Opciones_Documento
        '
        Me.Menu_Contextual_01_Opciones_Documento.AutoExpandOnClick = True
        Me.Menu_Contextual_01_Opciones_Documento.Name = "Menu_Contextual_01_Opciones_Documento"
        Me.Menu_Contextual_01_Opciones_Documento.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1, Me.Btn_Ver_documento, Me.Btn_Ver_Anotaciones_Documento})
        Me.Menu_Contextual_01_Opciones_Documento.Text = "Opciones documento"
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
        'Btn_Ver_documento
        '
        Me.Btn_Ver_documento.Image = CType(resources.GetObject("Btn_Ver_documento.Image"), System.Drawing.Image)
        Me.Btn_Ver_documento.Name = "Btn_Ver_documento"
        Me.Btn_Ver_documento.Text = "Ver documento"
        '
        'Btn_Ver_Anotaciones_Documento
        '
        Me.Btn_Ver_Anotaciones_Documento.Image = CType(resources.GetObject("Btn_Ver_Anotaciones_Documento.Image"), System.Drawing.Image)
        Me.Btn_Ver_Anotaciones_Documento.Name = "Btn_Ver_Anotaciones_Documento"
        Me.Btn_Ver_Anotaciones_Documento.Text = "Ver anotaciones del documento"
        '
        'Menu_Contextual_02_Anotaciones
        '
        Me.Menu_Contextual_02_Anotaciones.AutoExpandOnClick = True
        Me.Menu_Contextual_02_Anotaciones.Name = "Menu_Contextual_02_Anotaciones"
        Me.Menu_Contextual_02_Anotaciones.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem2, Me.Btn_Anotacion_Telefono, Me.Btn_Anotacion_Mail, Me.Btn_Anotacion_Visita_Cliente})
        Me.Menu_Contextual_02_Anotaciones.Text = "Opciones marcar"
        '
        'LabelItem2
        '
        Me.LabelItem2.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem2.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem2.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem2.Name = "LabelItem2"
        Me.LabelItem2.PaddingBottom = 1
        Me.LabelItem2.PaddingLeft = 10
        Me.LabelItem2.PaddingTop = 1
        Me.LabelItem2.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem2.Text = "Opciones"
        '
        'Btn_Anotacion_Telefono
        '
        Me.Btn_Anotacion_Telefono.Image = CType(resources.GetObject("Btn_Anotacion_Telefono.Image"), System.Drawing.Image)
        Me.Btn_Anotacion_Telefono.Name = "Btn_Anotacion_Telefono"
        Me.Btn_Anotacion_Telefono.Text = "Llamado telefónico"
        '
        'Btn_Anotacion_Mail
        '
        Me.Btn_Anotacion_Mail.Image = CType(resources.GetObject("Btn_Anotacion_Mail.Image"), System.Drawing.Image)
        Me.Btn_Anotacion_Mail.Name = "Btn_Anotacion_Mail"
        Me.Btn_Anotacion_Mail.Text = "Envío de correo"
        '
        'Btn_Anotacion_Visita_Cliente
        '
        Me.Btn_Anotacion_Visita_Cliente.Image = CType(resources.GetObject("Btn_Anotacion_Visita_Cliente.Image"), System.Drawing.Image)
        Me.Btn_Anotacion_Visita_Cliente.Name = "Btn_Anotacion_Visita_Cliente"
        Me.Btn_Anotacion_Visita_Cliente.Text = "Visita al cliente"
        '
        'Menu_Contextual_03_Exportar_Excel
        '
        Me.Menu_Contextual_03_Exportar_Excel.AutoExpandOnClick = True
        Me.Menu_Contextual_03_Exportar_Excel.Name = "Menu_Contextual_03_Exportar_Excel"
        Me.Menu_Contextual_03_Exportar_Excel.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem3, Me.Btn_Exportar_Informe_01_Vista_Actual, Me.Btn_Exportar_Informe_02_Mostrar_todas_las_Anotaciones, Me.Btn_Exportar_Informe_03_Entidades})
        Me.Menu_Contextual_03_Exportar_Excel.Text = "Opciones Excel"
        '
        'LabelItem3
        '
        Me.LabelItem3.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem3.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem3.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem3.Name = "LabelItem3"
        Me.LabelItem3.PaddingBottom = 1
        Me.LabelItem3.PaddingLeft = 10
        Me.LabelItem3.PaddingTop = 1
        Me.LabelItem3.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem3.Text = "Exportar a Excel"
        '
        'Btn_Exportar_Informe_01_Vista_Actual
        '
        Me.Btn_Exportar_Informe_01_Vista_Actual.Image = CType(resources.GetObject("Btn_Exportar_Informe_01_Vista_Actual.Image"), System.Drawing.Image)
        Me.Btn_Exportar_Informe_01_Vista_Actual.Name = "Btn_Exportar_Informe_01_Vista_Actual"
        Me.Btn_Exportar_Informe_01_Vista_Actual.Text = "Exportar vista actual"
        '
        'Btn_Exportar_Informe_02_Mostrar_todas_las_Anotaciones
        '
        Me.Btn_Exportar_Informe_02_Mostrar_todas_las_Anotaciones.Image = CType(resources.GetObject("Btn_Exportar_Informe_02_Mostrar_todas_las_Anotaciones.Image"), System.Drawing.Image)
        Me.Btn_Exportar_Informe_02_Mostrar_todas_las_Anotaciones.Name = "Btn_Exportar_Informe_02_Mostrar_todas_las_Anotaciones"
        Me.Btn_Exportar_Informe_02_Mostrar_todas_las_Anotaciones.Text = "Exportar todas las anotaciones de los documentos (Vista actual)"
        '
        'Btn_Exportar_Informe_03_Entidades
        '
        Me.Btn_Exportar_Informe_03_Entidades.Image = CType(resources.GetObject("Btn_Exportar_Informe_03_Entidades.Image"), System.Drawing.Image)
        Me.Btn_Exportar_Informe_03_Entidades.Name = "Btn_Exportar_Informe_03_Entidades"
        Me.Btn_Exportar_Informe_03_Entidades.Text = "Exportar entidades de los documentos"
        '
        'Menu_Contextual_04_Pago_Proveedores
        '
        Me.Menu_Contextual_04_Pago_Proveedores.AutoExpandOnClick = True
        Me.Menu_Contextual_04_Pago_Proveedores.Name = "Menu_Contextual_04_Pago_Proveedores"
        Me.Menu_Contextual_04_Pago_Proveedores.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem4, Me.Btn_Pagar_A_Proveedores_Autorizados})
        Me.Menu_Contextual_04_Pago_Proveedores.Text = "Opciones pago a proveedores"
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
        Me.LabelItem4.Text = "Opciones"
        '
        'Btn_Pagar_A_Proveedores_Autorizados
        '
        Me.Btn_Pagar_A_Proveedores_Autorizados.Image = CType(resources.GetObject("Btn_Pagar_A_Proveedores_Autorizados.Image"), System.Drawing.Image)
        Me.Btn_Pagar_A_Proveedores_Autorizados.Name = "Btn_Pagar_A_Proveedores_Autorizados"
        Me.Btn_Pagar_A_Proveedores_Autorizados.Text = "Pagar a proveedores autorizados"
        '
        'Menu_Contextual_04_Opciones_Cobranza
        '
        Me.Menu_Contextual_04_Opciones_Cobranza.AutoExpandOnClick = True
        Me.Menu_Contextual_04_Opciones_Cobranza.Name = "Menu_Contextual_04_Opciones_Cobranza"
        Me.Menu_Contextual_04_Opciones_Cobranza.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Lbl_Mnu_1, Me.Btn_Mnu_Ficha_Entidad, Me.LabelItem5, Me.Btn_Mnu_Mostrar_deuda_actual, Me.Btn_Mnu_Mostrar_deuda_completa, Me.Btn_Mnu_Enviar_Correo_Cobranza, Me.Btn_Mnu_Enviar_Correo_Cobranza_Deuda_Completa})
        Me.Menu_Contextual_04_Opciones_Cobranza.Text = "Opciones"
        '
        'Lbl_Mnu_1
        '
        Me.Lbl_Mnu_1.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Lbl_Mnu_1.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.Lbl_Mnu_1.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.Lbl_Mnu_1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.Lbl_Mnu_1.Name = "Lbl_Mnu_1"
        Me.Lbl_Mnu_1.PaddingBottom = 1
        Me.Lbl_Mnu_1.PaddingLeft = 10
        Me.Lbl_Mnu_1.PaddingTop = 1
        Me.Lbl_Mnu_1.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.Lbl_Mnu_1.Text = "Información del cliente"
        '
        'Btn_Mnu_Ficha_Entidad
        '
        Me.Btn_Mnu_Ficha_Entidad.Image = CType(resources.GetObject("Btn_Mnu_Ficha_Entidad.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Ficha_Entidad.Name = "Btn_Mnu_Ficha_Entidad"
        Me.Btn_Mnu_Ficha_Entidad.Text = "Ver ficha de entidad"
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
        Me.LabelItem5.Text = "Opciones del repote"
        '
        'Btn_Mnu_Mostrar_deuda_actual
        '
        Me.Btn_Mnu_Mostrar_deuda_actual.Image = CType(resources.GetObject("Btn_Mnu_Mostrar_deuda_actual.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Mostrar_deuda_actual.Name = "Btn_Mnu_Mostrar_deuda_actual"
        Me.Btn_Mnu_Mostrar_deuda_actual.Text = "Mostrar detalle actual"
        '
        'Btn_Mnu_Mostrar_deuda_completa
        '
        Me.Btn_Mnu_Mostrar_deuda_completa.Image = CType(resources.GetObject("Btn_Mnu_Mostrar_deuda_completa.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Mostrar_deuda_completa.Name = "Btn_Mnu_Mostrar_deuda_completa"
        Me.Btn_Mnu_Mostrar_deuda_completa.Text = "Mostrar detalle deuda completa"
        '
        'Btn_Mnu_Enviar_Correo_Cobranza
        '
        Me.Btn_Mnu_Enviar_Correo_Cobranza.Image = CType(resources.GetObject("Btn_Mnu_Enviar_Correo_Cobranza.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Enviar_Correo_Cobranza.Name = "Btn_Mnu_Enviar_Correo_Cobranza"
        Me.Btn_Mnu_Enviar_Correo_Cobranza.Text = "Enviar correo de cobranza (detalle actual)"
        '
        'Btn_Mnu_Enviar_Correo_Cobranza_Deuda_Completa
        '
        Me.Btn_Mnu_Enviar_Correo_Cobranza_Deuda_Completa.Image = CType(resources.GetObject("Btn_Mnu_Enviar_Correo_Cobranza_Deuda_Completa.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Enviar_Correo_Cobranza_Deuda_Completa.Name = "Btn_Mnu_Enviar_Correo_Cobranza_Deuda_Completa"
        Me.Btn_Mnu_Enviar_Correo_Cobranza_Deuda_Completa.Text = "Enviar correo de cobranza (deuda completa)"
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
        Me.Grilla.Name = "Grilla"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla.RowHeadersVisible = False
        Me.Grilla.Size = New System.Drawing.Size(993, 400)
        Me.Grilla.TabIndex = 3
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Actualizar_Informacion, Me.Btn_Buscar_Documento, Me.Btn_Exportar_Excel, Me.Btn_Mover, Me.Btn_Enviar_correo, Me.Btn_Anotaciones_al_documento, Me.Btn_Marcar_Masivamente_Anotaciones_De_Documentos, Me.Btn_Imprimir, Me.Btn_Autorizar_Pago_Proveedor, Me.Btn_Autorizar_Pago_De_Documentos_Proveedores})
        Me.Bar1.Location = New System.Drawing.Point(0, 530)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(1020, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 38
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Actualizar_Informacion
        '
        Me.Btn_Actualizar_Informacion.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Actualizar_Informacion.ForeColor = System.Drawing.Color.Black
        Me.Btn_Actualizar_Informacion.Image = CType(resources.GetObject("Btn_Actualizar_Informacion.Image"), System.Drawing.Image)
        Me.Btn_Actualizar_Informacion.Name = "Btn_Actualizar_Informacion"
        Me.Btn_Actualizar_Informacion.Tooltip = "Actualizar vista"
        '
        'Btn_Buscar_Documento
        '
        Me.Btn_Buscar_Documento.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Buscar_Documento.ForeColor = System.Drawing.Color.Black
        Me.Btn_Buscar_Documento.Image = CType(resources.GetObject("Btn_Buscar_Documento.Image"), System.Drawing.Image)
        Me.Btn_Buscar_Documento.Name = "Btn_Buscar_Documento"
        Me.Btn_Buscar_Documento.Tooltip = "Buscar documento en el listado actual (F3)"
        '
        'Btn_Exportar_Excel
        '
        Me.Btn_Exportar_Excel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Exportar_Excel.ForeColor = System.Drawing.Color.Black
        Me.Btn_Exportar_Excel.Image = CType(resources.GetObject("Btn_Exportar_Excel.Image"), System.Drawing.Image)
        Me.Btn_Exportar_Excel.Name = "Btn_Exportar_Excel"
        Me.Btn_Exportar_Excel.Tooltip = "Exportar a Excel"
        '
        'Btn_Mover
        '
        Me.Btn_Mover.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Mover.ForeColor = System.Drawing.Color.Black
        Me.Btn_Mover.Image = CType(resources.GetObject("Btn_Mover.Image"), System.Drawing.Image)
        Me.Btn_Mover.Name = "Btn_Mover"
        Me.Btn_Mover.Tooltip = "Cambiar fecha del vencimiento"
        '
        'Btn_Enviar_correo
        '
        Me.Btn_Enviar_correo.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Enviar_correo.ForeColor = System.Drawing.Color.Black
        Me.Btn_Enviar_correo.Image = CType(resources.GetObject("Btn_Enviar_correo.Image"), System.Drawing.Image)
        Me.Btn_Enviar_correo.Name = "Btn_Enviar_correo"
        Me.Btn_Enviar_correo.Tooltip = "Enviar correo"
        '
        'Btn_Anotaciones_al_documento
        '
        Me.Btn_Anotaciones_al_documento.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Anotaciones_al_documento.ForeColor = System.Drawing.Color.Black
        Me.Btn_Anotaciones_al_documento.Image = CType(resources.GetObject("Btn_Anotaciones_al_documento.Image"), System.Drawing.Image)
        Me.Btn_Anotaciones_al_documento.Name = "Btn_Anotaciones_al_documento"
        Me.Btn_Anotaciones_al_documento.Tooltip = "Agregar anotación a documentos"
        Me.Btn_Anotaciones_al_documento.Visible = False
        '
        'Btn_Marcar_Masivamente_Anotaciones_De_Documentos
        '
        Me.Btn_Marcar_Masivamente_Anotaciones_De_Documentos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Marcar_Masivamente_Anotaciones_De_Documentos.ForeColor = System.Drawing.Color.Black
        Me.Btn_Marcar_Masivamente_Anotaciones_De_Documentos.Image = CType(resources.GetObject("Btn_Marcar_Masivamente_Anotaciones_De_Documentos.Image"), System.Drawing.Image)
        Me.Btn_Marcar_Masivamente_Anotaciones_De_Documentos.Name = "Btn_Marcar_Masivamente_Anotaciones_De_Documentos"
        Me.Btn_Marcar_Masivamente_Anotaciones_De_Documentos.Tooltip = "Marcar masivamente los documentos (Anotación tabulada)"
        '
        'Btn_Imprimir
        '
        Me.Btn_Imprimir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Imprimir.ForeColor = System.Drawing.Color.Black
        Me.Btn_Imprimir.Image = CType(resources.GetObject("Btn_Imprimir.Image"), System.Drawing.Image)
        Me.Btn_Imprimir.Name = "Btn_Imprimir"
        Me.Btn_Imprimir.Tooltip = "Imprimir documento"
        Me.Btn_Imprimir.Visible = False
        '
        'Btn_Autorizar_Pago_Proveedor
        '
        Me.Btn_Autorizar_Pago_Proveedor.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Autorizar_Pago_Proveedor.ForeColor = System.Drawing.Color.Black
        Me.Btn_Autorizar_Pago_Proveedor.Image = CType(resources.GetObject("Btn_Autorizar_Pago_Proveedor.Image"), System.Drawing.Image)
        Me.Btn_Autorizar_Pago_Proveedor.Name = "Btn_Autorizar_Pago_Proveedor"
        Me.Btn_Autorizar_Pago_Proveedor.Tooltip = "Autorizar documentos a pagar (crear código de autorización)"
        Me.Btn_Autorizar_Pago_Proveedor.Visible = False
        '
        'Btn_Autorizar_Pago_De_Documentos_Proveedores
        '
        Me.Btn_Autorizar_Pago_De_Documentos_Proveedores.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Autorizar_Pago_De_Documentos_Proveedores.ForeColor = System.Drawing.Color.Black
        Me.Btn_Autorizar_Pago_De_Documentos_Proveedores.Image = CType(resources.GetObject("Btn_Autorizar_Pago_De_Documentos_Proveedores.Image"), System.Drawing.Image)
        Me.Btn_Autorizar_Pago_De_Documentos_Proveedores.Name = "Btn_Autorizar_Pago_De_Documentos_Proveedores"
        Me.Btn_Autorizar_Pago_De_Documentos_Proveedores.Tooltip = "Autorizar documentos para pagar"
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Lbl_Nombre_Entidad)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(12, 441)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(830, 54)
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
        Me.GroupPanel2.TabIndex = 39
        Me.GroupPanel2.Text = "Nombre de entidad"
        '
        'Lbl_Nombre_Entidad
        '
        Me.Lbl_Nombre_Entidad.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Nombre_Entidad.BackgroundStyle.Class = "RibbonGalleryContainer"
        Me.Lbl_Nombre_Entidad.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Nombre_Entidad.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Nombre_Entidad.Location = New System.Drawing.Point(3, 4)
        Me.Lbl_Nombre_Entidad.Name = "Lbl_Nombre_Entidad"
        Me.Lbl_Nombre_Entidad.Size = New System.Drawing.Size(818, 22)
        Me.Lbl_Nombre_Entidad.TabIndex = 91
        '
        'GroupPanel3
        '
        Me.GroupPanel3.BackColor = System.Drawing.Color.White
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.Lbl_Total_Saldos)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Location = New System.Drawing.Point(848, 441)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(164, 54)
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
        Me.GroupPanel3.TabIndex = 40
        Me.GroupPanel3.Text = "Total saldos"
        '
        'Lbl_Total_Saldos
        '
        Me.Lbl_Total_Saldos.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Total_Saldos.BackgroundStyle.Class = "RibbonGalleryContainer"
        Me.Lbl_Total_Saldos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Total_Saldos.Font = New System.Drawing.Font("Segoe UI", 14.25!)
        Me.Lbl_Total_Saldos.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Total_Saldos.Location = New System.Drawing.Point(3, 4)
        Me.Lbl_Total_Saldos.Name = "Lbl_Total_Saldos"
        Me.Lbl_Total_Saldos.Size = New System.Drawing.Size(152, 22)
        Me.Lbl_Total_Saldos.TabIndex = 92
        Me.Lbl_Total_Saldos.Text = "0"
        Me.Lbl_Total_Saldos.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Chk_Marcar_todo
        '
        Me.Chk_Marcar_todo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Marcar_todo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Marcar_todo.ForeColor = System.Drawing.Color.Black
        Me.Chk_Marcar_todo.Location = New System.Drawing.Point(12, 501)
        Me.Chk_Marcar_todo.Name = "Chk_Marcar_todo"
        Me.Chk_Marcar_todo.Size = New System.Drawing.Size(85, 23)
        Me.Chk_Marcar_todo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Marcar_todo.TabIndex = 41
        Me.Chk_Marcar_todo.Text = "Marcar todo"
        '
        'Chk_Mostrar_Pagos_Pendientes
        '
        Me.Chk_Mostrar_Pagos_Pendientes.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Mostrar_Pagos_Pendientes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Mostrar_Pagos_Pendientes.ForeColor = System.Drawing.Color.Black
        Me.Chk_Mostrar_Pagos_Pendientes.Location = New System.Drawing.Point(103, 501)
        Me.Chk_Mostrar_Pagos_Pendientes.Name = "Chk_Mostrar_Pagos_Pendientes"
        Me.Chk_Mostrar_Pagos_Pendientes.Size = New System.Drawing.Size(196, 23)
        Me.Chk_Mostrar_Pagos_Pendientes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Mostrar_Pagos_Pendientes.TabIndex = 42
        Me.Chk_Mostrar_Pagos_Pendientes.Text = "Mostrar deuda efectiva (Doc. Pago)"
        '
        'Frm_Inf_Vencimientos_Detalle_Documentos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1020, 571)
        Me.Controls.Add(Me.Chk_Mostrar_Pagos_Pendientes)
        Me.Controls.Add(Me.Chk_Marcar_todo)
        Me.Controls.Add(Me.GroupPanel3)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.GroupPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Inf_Vencimientos_Detalle_Documentos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informe de documentos"
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        Me.GroupPanel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Actualizar_Informacion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Btn_Exportar_Excel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mover As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_01_Opciones_Documento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Ver_documento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Enviar_correo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Buscar_Documento As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Anotaciones_al_documento As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Marcar_Masivamente_Anotaciones_De_Documentos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Ver_Anotaciones_Documento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Menu_Contextual_02_Anotaciones As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Anotacion_Telefono As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Anotacion_Mail As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Anotacion_Visita_Cliente As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Imprimir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Menu_Contextual_03_Exportar_Excel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem3 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Exportar_Informe_01_Vista_Actual As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Exportar_Informe_02_Mostrar_todas_las_Anotaciones As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Exportar_Informe_03_Entidades As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Menu_Contextual_04_Pago_Proveedores As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem4 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Pagar_A_Proveedores_Autorizados As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Autorizar_Pago_Proveedor As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Chk_Marcar_todo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Mostrar_Pagos_Pendientes As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Btn_Autorizar_Pago_De_Documentos_Proveedores As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Menu_Contextual_04_Opciones_Cobranza As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Lbl_Mnu_1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Mnu_Ficha_Entidad As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem5 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Mnu_Mostrar_deuda_actual As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_Mostrar_deuda_completa As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_Enviar_Correo_Cobranza As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_Enviar_Correo_Cobranza_Deuda_Completa As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Lbl_Nombre_Entidad As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Total_Saldos As DevComponents.DotNetBar.LabelX
End Class
