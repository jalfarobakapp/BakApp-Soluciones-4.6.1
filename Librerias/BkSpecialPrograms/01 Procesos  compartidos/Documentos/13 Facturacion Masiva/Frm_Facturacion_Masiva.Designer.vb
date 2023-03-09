<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Facturacion_Masiva
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Facturacion_Masiva))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Chk_Marcar_todo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Facturar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Traer_Pago_CtaCte = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Exportar_Excel = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Opciones_Especiales = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Cancelar = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_01_Opciones_Documento = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Ver_documento = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Ver_Anotaciones_Documento = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_Opciones_Especiales = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Config_Tipo_Estacion = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Config_Impresora = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Config_Impresora_Local = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Config_Impresora_Diablito = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Impresion_PDF = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Circular_Progres_Porcentaje = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.Circular_Progres_Contador = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.Circular_Progres_Run = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.MetroStatusBar1 = New DevComponents.DotNetBar.Metro.MetroStatusBar()
        Me.Lbl_Status = New DevComponents.DotNetBar.LabelItem()
        Me.Chk_Pagar_Saldos_CRV = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Input_Monto_Max_CRV_FacMasiva = New DevComponents.Editors.IntegerInput()
        Me.Chk_Pagar_Documentos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Imprimir = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Dtp_Fecha_Emision = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Observaciones = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.GroupPanel4 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ComboBoxEx1 = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_BuscaXFechaVencimiento = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_BuscaXFechaEmision = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Buscar = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_BuscaXEntidad = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_BuscaXNudoNVV = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Lbl_Total_Facturar = New DevComponents.DotNetBar.LabelX()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Input_Monto_Max_CRV_FacMasiva, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_Fecha_Emision, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel4.SuspendLayout()
        CType(Me.Dtp_BuscaXFechaVencimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_BuscaXFechaEmision, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Chk_Marcar_todo
        '
        Me.Chk_Marcar_todo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Marcar_todo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Marcar_todo.ForeColor = System.Drawing.Color.Black
        Me.Chk_Marcar_todo.Location = New System.Drawing.Point(9, 525)
        Me.Chk_Marcar_todo.Name = "Chk_Marcar_todo"
        Me.Chk_Marcar_todo.Size = New System.Drawing.Size(85, 23)
        Me.Chk_Marcar_todo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Marcar_todo.TabIndex = 47
        Me.Chk_Marcar_todo.Text = "Marcar todo"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Facturar, Me.Btn_Traer_Pago_CtaCte, Me.Btn_Exportar_Excel, Me.Btn_Opciones_Especiales, Me.Btn_Cancelar})
        Me.Bar1.Location = New System.Drawing.Point(0, 589)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(1180, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 44
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Facturar
        '
        Me.Btn_Facturar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Facturar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Facturar.Image = CType(resources.GetObject("Btn_Facturar.Image"), System.Drawing.Image)
        Me.Btn_Facturar.ImageAlt = CType(resources.GetObject("Btn_Facturar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Facturar.Name = "Btn_Facturar"
        Me.Btn_Facturar.Tooltip = "Facturar documentos seleccionados"
        '
        'Btn_Traer_Pago_CtaCte
        '
        Me.Btn_Traer_Pago_CtaCte.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Traer_Pago_CtaCte.ForeColor = System.Drawing.Color.Black
        Me.Btn_Traer_Pago_CtaCte.Image = CType(resources.GetObject("Btn_Traer_Pago_CtaCte.Image"), System.Drawing.Image)
        Me.Btn_Traer_Pago_CtaCte.ImageAlt = CType(resources.GetObject("Btn_Traer_Pago_CtaCte.ImageAlt"), System.Drawing.Image)
        Me.Btn_Traer_Pago_CtaCte.Name = "Btn_Traer_Pago_CtaCte"
        Me.Btn_Traer_Pago_CtaCte.Tooltip = "Pagar documentos con pagos asociados a la NVV desde Cta.Cte."
        Me.Btn_Traer_Pago_CtaCte.Visible = False
        '
        'Btn_Exportar_Excel
        '
        Me.Btn_Exportar_Excel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Exportar_Excel.ForeColor = System.Drawing.Color.Black
        Me.Btn_Exportar_Excel.Image = CType(resources.GetObject("Btn_Exportar_Excel.Image"), System.Drawing.Image)
        Me.Btn_Exportar_Excel.ImageAlt = CType(resources.GetObject("Btn_Exportar_Excel.ImageAlt"), System.Drawing.Image)
        Me.Btn_Exportar_Excel.Name = "Btn_Exportar_Excel"
        Me.Btn_Exportar_Excel.Tooltip = "Exportar a Excel"
        Me.Btn_Exportar_Excel.Visible = False
        '
        'Btn_Opciones_Especiales
        '
        Me.Btn_Opciones_Especiales.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Opciones_Especiales.ForeColor = System.Drawing.Color.Black
        Me.Btn_Opciones_Especiales.Image = CType(resources.GetObject("Btn_Opciones_Especiales.Image"), System.Drawing.Image)
        Me.Btn_Opciones_Especiales.ImageAlt = CType(resources.GetObject("Btn_Opciones_Especiales.ImageAlt"), System.Drawing.Image)
        Me.Btn_Opciones_Especiales.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center
        Me.Btn_Opciones_Especiales.Name = "Btn_Opciones_Especiales"
        Me.Btn_Opciones_Especiales.Tooltip = "Opciones especiales"
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Cancelar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Cancelar.Image = CType(resources.GetObject("Btn_Cancelar.Image"), System.Drawing.Image)
        Me.Btn_Cancelar.ImageAlt = CType(resources.GetObject("Btn_Cancelar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Text = "Cancelar"
        Me.Btn_Cancelar.Tooltip = "Eliminar Servidor de correo de salida SMTP"
        Me.Btn_Cancelar.Visible = False
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.ContextMenuBar1)
        Me.GroupPanel1.Controls.Add(Me.Grilla)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(9, 108)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(1163, 382)
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
        Me.GroupPanel1.TabIndex = 43
        Me.GroupPanel1.Text = "Detalle"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_01_Opciones_Documento, Me.Menu_Contextual_Opciones_Especiales})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(211, 120)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(325, 25)
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
        Me.Btn_Ver_documento.ImageAlt = CType(resources.GetObject("Btn_Ver_documento.ImageAlt"), System.Drawing.Image)
        Me.Btn_Ver_documento.Name = "Btn_Ver_documento"
        Me.Btn_Ver_documento.Text = "Ver documento"
        '
        'Btn_Ver_Anotaciones_Documento
        '
        Me.Btn_Ver_Anotaciones_Documento.Image = CType(resources.GetObject("Btn_Ver_Anotaciones_Documento.Image"), System.Drawing.Image)
        Me.Btn_Ver_Anotaciones_Documento.Name = "Btn_Ver_Anotaciones_Documento"
        Me.Btn_Ver_Anotaciones_Documento.Text = "Ver anotaciones del documento"
        '
        'Menu_Contextual_Opciones_Especiales
        '
        Me.Menu_Contextual_Opciones_Especiales.AutoExpandOnClick = True
        Me.Menu_Contextual_Opciones_Especiales.Name = "Menu_Contextual_Opciones_Especiales"
        Me.Menu_Contextual_Opciones_Especiales.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Config_Tipo_Estacion, Me.Btn_Config_Impresora})
        Me.Menu_Contextual_Opciones_Especiales.Text = "Opciones especiales"
        '
        'Btn_Config_Tipo_Estacion
        '
        Me.Btn_Config_Tipo_Estacion.Image = CType(resources.GetObject("Btn_Config_Tipo_Estacion.Image"), System.Drawing.Image)
        Me.Btn_Config_Tipo_Estacion.ImageAlt = CType(resources.GetObject("Btn_Config_Tipo_Estacion.ImageAlt"), System.Drawing.Image)
        Me.Btn_Config_Tipo_Estacion.Name = "Btn_Config_Tipo_Estacion"
        Me.Btn_Config_Tipo_Estacion.Text = "Configuración tipo de estación"
        '
        'Btn_Config_Impresora
        '
        Me.Btn_Config_Impresora.Image = CType(resources.GetObject("Btn_Config_Impresora.Image"), System.Drawing.Image)
        Me.Btn_Config_Impresora.ImageAlt = CType(resources.GetObject("Btn_Config_Impresora.ImageAlt"), System.Drawing.Image)
        Me.Btn_Config_Impresora.Name = "Btn_Config_Impresora"
        Me.Btn_Config_Impresora.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Config_Impresora_Local, Me.Btn_Config_Impresora_Diablito, Me.Btn_Impresion_PDF})
        Me.Btn_Config_Impresora.Text = "Configuración impresora de salida"
        '
        'Btn_Config_Impresora_Local
        '
        Me.Btn_Config_Impresora_Local.Image = CType(resources.GetObject("Btn_Config_Impresora_Local.Image"), System.Drawing.Image)
        Me.Btn_Config_Impresora_Local.ImageAlt = CType(resources.GetObject("Btn_Config_Impresora_Local.ImageAlt"), System.Drawing.Image)
        Me.Btn_Config_Impresora_Local.Name = "Btn_Config_Impresora_Local"
        Me.Btn_Config_Impresora_Local.Text = "Impresora local o conectada a la red"
        '
        'Btn_Config_Impresora_Diablito
        '
        Me.Btn_Config_Impresora_Diablito.Image = CType(resources.GetObject("Btn_Config_Impresora_Diablito.Image"), System.Drawing.Image)
        Me.Btn_Config_Impresora_Diablito.ImageAlt = CType(resources.GetObject("Btn_Config_Impresora_Diablito.ImageAlt"), System.Drawing.Image)
        Me.Btn_Config_Impresora_Diablito.Name = "Btn_Config_Impresora_Diablito"
        Me.Btn_Config_Impresora_Diablito.Text = "Impresión hacia diablito (servidor de impresiones)"
        Me.Btn_Config_Impresora_Diablito.Tooltip = "Configurar mis salidas de impresión al diablito"
        '
        'Btn_Impresion_PDF
        '
        Me.Btn_Impresion_PDF.Image = CType(resources.GetObject("Btn_Impresion_PDF.Image"), System.Drawing.Image)
        Me.Btn_Impresion_PDF.ImageAlt = CType(resources.GetObject("Btn_Impresion_PDF.ImageAlt"), System.Drawing.Image)
        Me.Btn_Impresion_PDF.Name = "Btn_Impresion_PDF"
        Me.Btn_Impresion_PDF.Text = "Directorio de salida para PDF automático"
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
        Me.Grilla.Size = New System.Drawing.Size(1157, 359)
        Me.Grilla.TabIndex = 3
        '
        'Circular_Progres_Porcentaje
        '
        Me.Circular_Progres_Porcentaje.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Circular_Progres_Porcentaje.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Circular_Progres_Porcentaje.Location = New System.Drawing.Point(430, 531)
        Me.Circular_Progres_Porcentaje.Name = "Circular_Progres_Porcentaje"
        Me.Circular_Progres_Porcentaje.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.Circular_Progres_Porcentaje.ProgressColor = System.Drawing.Color.SteelBlue
        Me.Circular_Progres_Porcentaje.ProgressTextVisible = True
        Me.Circular_Progres_Porcentaje.Size = New System.Drawing.Size(56, 46)
        Me.Circular_Progres_Porcentaje.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.Circular_Progres_Porcentaje.TabIndex = 49
        Me.Circular_Progres_Porcentaje.Visible = False
        '
        'Circular_Progres_Contador
        '
        Me.Circular_Progres_Contador.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Circular_Progres_Contador.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Circular_Progres_Contador.Location = New System.Drawing.Point(492, 531)
        Me.Circular_Progres_Contador.Name = "Circular_Progres_Contador"
        Me.Circular_Progres_Contador.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.Circular_Progres_Contador.ProgressColor = System.Drawing.Color.SteelBlue
        Me.Circular_Progres_Contador.ProgressTextFormat = "{0}"
        Me.Circular_Progres_Contador.ProgressTextVisible = True
        Me.Circular_Progres_Contador.Size = New System.Drawing.Size(56, 46)
        Me.Circular_Progres_Contador.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.Circular_Progres_Contador.TabIndex = 48
        Me.Circular_Progres_Contador.Visible = False
        '
        'Circular_Progres_Run
        '
        Me.Circular_Progres_Run.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Circular_Progres_Run.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Circular_Progres_Run.Location = New System.Drawing.Point(554, 531)
        Me.Circular_Progres_Run.Name = "Circular_Progres_Run"
        Me.Circular_Progres_Run.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Dot
        Me.Circular_Progres_Run.ProgressColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.Circular_Progres_Run.ProgressTextFormat = ""
        Me.Circular_Progres_Run.ProgressTextVisible = True
        Me.Circular_Progres_Run.Size = New System.Drawing.Size(56, 46)
        Me.Circular_Progres_Run.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.Circular_Progres_Run.TabIndex = 50
        Me.Circular_Progres_Run.Visible = False
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
        Me.MetroStatusBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Lbl_Status})
        Me.MetroStatusBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MetroStatusBar1.Location = New System.Drawing.Point(0, 630)
        Me.MetroStatusBar1.Name = "MetroStatusBar1"
        Me.MetroStatusBar1.Size = New System.Drawing.Size(1180, 22)
        Me.MetroStatusBar1.TabIndex = 52
        Me.MetroStatusBar1.Text = "MetroStatusBar1"
        '
        'Lbl_Status
        '
        Me.Lbl_Status.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Status.Name = "Lbl_Status"
        Me.Lbl_Status.Text = "Status"
        '
        'Chk_Pagar_Saldos_CRV
        '
        Me.Chk_Pagar_Saldos_CRV.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Pagar_Saldos_CRV.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Pagar_Saldos_CRV.ForeColor = System.Drawing.Color.Black
        Me.Chk_Pagar_Saldos_CRV.Location = New System.Drawing.Point(843, 524)
        Me.Chk_Pagar_Saldos_CRV.Name = "Chk_Pagar_Saldos_CRV"
        Me.Chk_Pagar_Saldos_CRV.Size = New System.Drawing.Size(254, 23)
        Me.Chk_Pagar_Saldos_CRV.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Pagar_Saldos_CRV.TabIndex = 53
        Me.Chk_Pagar_Saldos_CRV.Text = "Pagar saldos con CRV. monto máximo CRV $ ->"
        '
        'Input_Monto_Max_CRV_FacMasiva
        '
        Me.Input_Monto_Max_CRV_FacMasiva.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_Monto_Max_CRV_FacMasiva.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_Monto_Max_CRV_FacMasiva.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_Monto_Max_CRV_FacMasiva.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.Input_Monto_Max_CRV_FacMasiva.ForeColor = System.Drawing.Color.Black
        Me.Input_Monto_Max_CRV_FacMasiva.Location = New System.Drawing.Point(1103, 525)
        Me.Input_Monto_Max_CRV_FacMasiva.MaxValue = 10000
        Me.Input_Monto_Max_CRV_FacMasiva.MinValue = 1
        Me.Input_Monto_Max_CRV_FacMasiva.Name = "Input_Monto_Max_CRV_FacMasiva"
        Me.Input_Monto_Max_CRV_FacMasiva.ShowUpDown = True
        Me.Input_Monto_Max_CRV_FacMasiva.Size = New System.Drawing.Size(64, 22)
        Me.Input_Monto_Max_CRV_FacMasiva.TabIndex = 54
        Me.Input_Monto_Max_CRV_FacMasiva.Value = 1
        '
        'Chk_Pagar_Documentos
        '
        Me.Chk_Pagar_Documentos.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Pagar_Documentos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Pagar_Documentos.ForeColor = System.Drawing.Color.Black
        Me.Chk_Pagar_Documentos.Location = New System.Drawing.Point(9, 543)
        Me.Chk_Pagar_Documentos.Name = "Chk_Pagar_Documentos"
        Me.Chk_Pagar_Documentos.Size = New System.Drawing.Size(415, 23)
        Me.Chk_Pagar_Documentos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Pagar_Documentos.TabIndex = 55
        Me.Chk_Pagar_Documentos.Text = "Pagar documentos con pago asociado a la nota de venta en Cta. Cte. del cliente"
        '
        'Chk_Imprimir
        '
        Me.Chk_Imprimir.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Imprimir.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Imprimir.ForeColor = System.Drawing.Color.Black
        Me.Chk_Imprimir.Location = New System.Drawing.Point(9, 563)
        Me.Chk_Imprimir.Name = "Chk_Imprimir"
        Me.Chk_Imprimir.Size = New System.Drawing.Size(254, 23)
        Me.Chk_Imprimir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Imprimir.TabIndex = 56
        Me.Chk_Imprimir.Text = "Imprimir facturas"
        '
        'Dtp_Fecha_Emision
        '
        Me.Dtp_Fecha_Emision.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_Fecha_Emision.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Emision.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Emision.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Emision.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Emision.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Emision.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Emision.Location = New System.Drawing.Point(132, 5)
        '
        '
        '
        Me.Dtp_Fecha_Emision.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Emision.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Emision.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Emision.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Emision.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Emision.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Emision.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Emision.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Emision.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Emision.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Emision.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Emision.MonthCalendar.DisplayMonth = New Date(2021, 1, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Emision.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_Fecha_Emision.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Emision.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Emision.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Emision.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Emision.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Emision.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Emision.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Emision.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Emision.Name = "Dtp_Fecha_Emision"
        Me.Dtp_Fecha_Emision.Size = New System.Drawing.Size(83, 22)
        Me.Dtp_Fecha_Emision.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Emision.TabIndex = 57
        Me.Dtp_Fecha_Emision.Value = New Date(2021, 1, 25, 10, 52, 32, 0)
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(12, 4)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(114, 23)
        Me.LabelX1.TabIndex = 58
        Me.LabelX1.Text = "Fecha de facturación:"
        '
        'Txt_Observaciones
        '
        Me.Txt_Observaciones.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Observaciones.Border.Class = "TextBoxBorder"
        Me.Txt_Observaciones.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Observaciones.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Observaciones.ForeColor = System.Drawing.Color.Black
        Me.Txt_Observaciones.Location = New System.Drawing.Point(9, 496)
        Me.Txt_Observaciones.Name = "Txt_Observaciones"
        Me.Txt_Observaciones.PreventEnterBeep = True
        Me.Txt_Observaciones.ReadOnly = True
        Me.Txt_Observaciones.Size = New System.Drawing.Size(1160, 22)
        Me.Txt_Observaciones.TabIndex = 59
        '
        'GroupPanel4
        '
        Me.GroupPanel4.BackColor = System.Drawing.Color.White
        Me.GroupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel4.Controls.Add(Me.ComboBoxEx1)
        Me.GroupPanel4.Controls.Add(Me.LabelX6)
        Me.GroupPanel4.Controls.Add(Me.Dtp_BuscaXFechaVencimiento)
        Me.GroupPanel4.Controls.Add(Me.LabelX4)
        Me.GroupPanel4.Controls.Add(Me.Dtp_BuscaXFechaEmision)
        Me.GroupPanel4.Controls.Add(Me.LabelX3)
        Me.GroupPanel4.Controls.Add(Me.Btn_Buscar)
        Me.GroupPanel4.Controls.Add(Me.Txt_BuscaXEntidad)
        Me.GroupPanel4.Controls.Add(Me.LabelX2)
        Me.GroupPanel4.Controls.Add(Me.Txt_BuscaXNudoNVV)
        Me.GroupPanel4.Controls.Add(Me.LabelX5)
        Me.GroupPanel4.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel4.Location = New System.Drawing.Point(9, 24)
        Me.GroupPanel4.Name = "GroupPanel4"
        Me.GroupPanel4.Size = New System.Drawing.Size(1163, 78)
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
        Me.GroupPanel4.TabIndex = 109
        Me.GroupPanel4.Text = "Filtrar notas de venta"
        '
        'ComboBoxEx1
        '
        Me.ComboBoxEx1.DisplayMember = "Text"
        Me.ComboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxEx1.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxEx1.FormattingEnabled = True
        Me.ComboBoxEx1.ItemHeight = 16
        Me.ComboBoxEx1.Location = New System.Drawing.Point(775, 29)
        Me.ComboBoxEx1.Name = "ComboBoxEx1"
        Me.ComboBoxEx1.Size = New System.Drawing.Size(85, 22)
        Me.ComboBoxEx1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBoxEx1.TabIndex = 17
        Me.ComboBoxEx1.Text = "Todas..."
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(775, 10)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(93, 23)
        Me.LabelX6.TabIndex = 18
        Me.LabelX6.Text = "Tipo de venta"
        '
        'Dtp_BuscaXFechaVencimiento
        '
        Me.Dtp_BuscaXFechaVencimiento.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_BuscaXFechaVencimiento.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_BuscaXFechaVencimiento.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_BuscaXFechaVencimiento.ButtonClear.Visible = True
        Me.Dtp_BuscaXFechaVencimiento.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_BuscaXFechaVencimiento.ButtonDropDown.Visible = True
        Me.Dtp_BuscaXFechaVencimiento.ForeColor = System.Drawing.Color.Black
        Me.Dtp_BuscaXFechaVencimiento.IsPopupCalendarOpen = False
        Me.Dtp_BuscaXFechaVencimiento.Location = New System.Drawing.Point(666, 30)
        '
        '
        '
        Me.Dtp_BuscaXFechaVencimiento.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_BuscaXFechaVencimiento.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_BuscaXFechaVencimiento.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_BuscaXFechaVencimiento.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_BuscaXFechaVencimiento.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_BuscaXFechaVencimiento.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_BuscaXFechaVencimiento.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_BuscaXFechaVencimiento.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_BuscaXFechaVencimiento.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_BuscaXFechaVencimiento.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_BuscaXFechaVencimiento.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_BuscaXFechaVencimiento.MonthCalendar.DisplayMonth = New Date(2023, 3, 1, 0, 0, 0, 0)
        Me.Dtp_BuscaXFechaVencimiento.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_BuscaXFechaVencimiento.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_BuscaXFechaVencimiento.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_BuscaXFechaVencimiento.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_BuscaXFechaVencimiento.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_BuscaXFechaVencimiento.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_BuscaXFechaVencimiento.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_BuscaXFechaVencimiento.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_BuscaXFechaVencimiento.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_BuscaXFechaVencimiento.Name = "Dtp_BuscaXFechaVencimiento"
        Me.Dtp_BuscaXFechaVencimiento.Size = New System.Drawing.Size(101, 22)
        Me.Dtp_BuscaXFechaVencimiento.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_BuscaXFechaVencimiento.TabIndex = 16
        Me.Dtp_BuscaXFechaVencimiento.Value = New Date(2023, 3, 6, 13, 17, 7, 0)
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(666, 10)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(93, 23)
        Me.LabelX4.TabIndex = 15
        Me.LabelX4.Text = "Fecha Vencimiento"
        '
        'Dtp_BuscaXFechaEmision
        '
        Me.Dtp_BuscaXFechaEmision.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_BuscaXFechaEmision.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_BuscaXFechaEmision.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_BuscaXFechaEmision.ButtonClear.Visible = True
        Me.Dtp_BuscaXFechaEmision.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_BuscaXFechaEmision.ButtonDropDown.Visible = True
        Me.Dtp_BuscaXFechaEmision.ForeColor = System.Drawing.Color.Black
        Me.Dtp_BuscaXFechaEmision.IsPopupCalendarOpen = False
        Me.Dtp_BuscaXFechaEmision.Location = New System.Drawing.Point(559, 30)
        '
        '
        '
        Me.Dtp_BuscaXFechaEmision.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_BuscaXFechaEmision.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_BuscaXFechaEmision.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_BuscaXFechaEmision.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_BuscaXFechaEmision.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_BuscaXFechaEmision.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_BuscaXFechaEmision.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_BuscaXFechaEmision.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_BuscaXFechaEmision.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_BuscaXFechaEmision.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_BuscaXFechaEmision.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_BuscaXFechaEmision.MonthCalendar.DisplayMonth = New Date(2023, 3, 1, 0, 0, 0, 0)
        Me.Dtp_BuscaXFechaEmision.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_BuscaXFechaEmision.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_BuscaXFechaEmision.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_BuscaXFechaEmision.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_BuscaXFechaEmision.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_BuscaXFechaEmision.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_BuscaXFechaEmision.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_BuscaXFechaEmision.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_BuscaXFechaEmision.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_BuscaXFechaEmision.Name = "Dtp_BuscaXFechaEmision"
        Me.Dtp_BuscaXFechaEmision.Size = New System.Drawing.Size(101, 22)
        Me.Dtp_BuscaXFechaEmision.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_BuscaXFechaEmision.TabIndex = 14
        Me.Dtp_BuscaXFechaEmision.Value = New Date(2023, 3, 6, 13, 17, 7, 0)
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(559, 10)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(93, 23)
        Me.LabelX3.TabIndex = 13
        Me.LabelX3.Text = "Fecha Emisión"
        '
        'Btn_Buscar
        '
        Me.Btn_Buscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Buscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Buscar.Location = New System.Drawing.Point(1080, 29)
        Me.Btn_Buscar.Name = "Btn_Buscar"
        Me.Btn_Buscar.Size = New System.Drawing.Size(71, 23)
        Me.Btn_Buscar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Buscar.TabIndex = 12
        Me.Btn_Buscar.Text = "Filtrar..."
        Me.Btn_Buscar.Tooltip = "Aplicar filtro"
        '
        'Txt_BuscaXEntidad
        '
        Me.Txt_BuscaXEntidad.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_BuscaXEntidad.Border.Class = "TextBoxBorder"
        Me.Txt_BuscaXEntidad.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_BuscaXEntidad.ButtonCustom.Image = CType(resources.GetObject("Txt_BuscaXEntidad.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_BuscaXEntidad.ButtonCustom.Visible = True
        Me.Txt_BuscaXEntidad.ButtonCustom2.Image = CType(resources.GetObject("Txt_BuscaXEntidad.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_BuscaXEntidad.ButtonCustom2.Visible = True
        Me.Txt_BuscaXEntidad.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_BuscaXEntidad.ForeColor = System.Drawing.Color.Black
        Me.Txt_BuscaXEntidad.Location = New System.Drawing.Point(150, 30)
        Me.Txt_BuscaXEntidad.Name = "Txt_BuscaXEntidad"
        Me.Txt_BuscaXEntidad.PreventEnterBeep = True
        Me.Txt_BuscaXEntidad.ReadOnly = True
        Me.Txt_BuscaXEntidad.Size = New System.Drawing.Size(403, 22)
        Me.Txt_BuscaXEntidad.TabIndex = 6
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(150, 10)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 23)
        Me.LabelX2.TabIndex = 7
        Me.LabelX2.Text = "Entidad"
        '
        'Txt_BuscaXNudoNVV
        '
        Me.Txt_BuscaXNudoNVV.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_BuscaXNudoNVV.Border.Class = "TextBoxBorder"
        Me.Txt_BuscaXNudoNVV.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_BuscaXNudoNVV.ButtonCustom.Image = CType(resources.GetObject("Txt_BuscaXNudoNVV.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_BuscaXNudoNVV.ButtonCustom.Visible = True
        Me.Txt_BuscaXNudoNVV.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_BuscaXNudoNVV.ForeColor = System.Drawing.Color.Black
        Me.Txt_BuscaXNudoNVV.Location = New System.Drawing.Point(3, 30)
        Me.Txt_BuscaXNudoNVV.Name = "Txt_BuscaXNudoNVV"
        Me.Txt_BuscaXNudoNVV.PreventEnterBeep = True
        Me.Txt_BuscaXNudoNVV.Size = New System.Drawing.Size(141, 22)
        Me.Txt_BuscaXNudoNVV.TabIndex = 3
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(3, 10)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(141, 23)
        Me.LabelX5.TabIndex = 5
        Me.LabelX5.Text = "Número de NVV"
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Lbl_Total_Facturar)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.GroupPanel2.Location = New System.Drawing.Point(1016, 553)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(153, 58)
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
        Me.GroupPanel2.TabIndex = 120
        Me.GroupPanel2.Text = "Total a facturar"
        '
        'Lbl_Total_Facturar
        '
        Me.Lbl_Total_Facturar.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Total_Facturar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Total_Facturar.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Total_Facturar.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Total_Facturar.Location = New System.Drawing.Point(3, 3)
        Me.Lbl_Total_Facturar.Name = "Lbl_Total_Facturar"
        Me.Lbl_Total_Facturar.Size = New System.Drawing.Size(141, 23)
        Me.Lbl_Total_Facturar.TabIndex = 34
        Me.Lbl_Total_Facturar.Text = "0"
        Me.Lbl_Total_Facturar.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Frm_Facturacion_Masiva
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1180, 652)
        Me.Controls.Add(Me.Dtp_Fecha_Emision)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.GroupPanel4)
        Me.Controls.Add(Me.Txt_Observaciones)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Chk_Imprimir)
        Me.Controls.Add(Me.Input_Monto_Max_CRV_FacMasiva)
        Me.Controls.Add(Me.Chk_Pagar_Documentos)
        Me.Controls.Add(Me.Chk_Pagar_Saldos_CRV)
        Me.Controls.Add(Me.Circular_Progres_Run)
        Me.Controls.Add(Me.Circular_Progres_Porcentaje)
        Me.Controls.Add(Me.Circular_Progres_Contador)
        Me.Controls.Add(Me.Chk_Marcar_todo)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.MetroStatusBar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Facturacion_Masiva"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FACTURACION MASIVA DE NOTAS DE VENTA"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Input_Monto_Max_CRV_FacMasiva, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_Fecha_Emision, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel4.ResumeLayout(False)
        CType(Me.Dtp_BuscaXFechaVencimiento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_BuscaXFechaEmision, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Chk_Marcar_todo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Facturar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Exportar_Excel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_01_Opciones_Documento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Ver_documento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Ver_Anotaciones_Documento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Btn_Traer_Pago_CtaCte As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Circular_Progres_Porcentaje As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Circular_Progres_Contador As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Circular_Progres_Run As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents MetroStatusBar1 As DevComponents.DotNetBar.Metro.MetroStatusBar
    Friend WithEvents Lbl_Status As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Chk_Pagar_Saldos_CRV As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Input_Monto_Max_CRV_FacMasiva As DevComponents.Editors.IntegerInput
    Friend WithEvents Chk_Pagar_Documentos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Imprimir As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Btn_Cancelar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Dtp_Fecha_Emision As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Observaciones As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Btn_Opciones_Especiales As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Menu_Contextual_Opciones_Especiales As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Config_Tipo_Estacion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Config_Impresora As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Config_Impresora_Local As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Config_Impresora_Diablito As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Impresion_PDF As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel4 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents ComboBoxEx1 As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dtp_BuscaXFechaVencimiento As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dtp_BuscaXFechaEmision As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Buscar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Txt_BuscaXEntidad As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_BuscaXNudoNVV As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Lbl_Total_Facturar As DevComponents.DotNetBar.LabelX
End Class
