<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Despacho_Configuracion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Despacho_Configuracion))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Cmb_Estados = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Correo = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Quitar_Correo = New DevComponents.DotNetBar.ButtonItem()
        Me.Chk_Adjuntar_Archivo = New DevComponents.DotNetBar.CheckBoxItem()
        Me.Btn_Formato_BLV = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Formato_FCV = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Formato_GDV = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Formato_GTI = New DevComponents.DotNetBar.ButtonItem()
        Me.Chk_Enviar_al_otro_dia = New DevComponents.DotNetBar.CheckBoxItem()
        Me.Lbl_Modelo = New DevComponents.DotNetBar.LabelX()
        Me.Grilla_Correos = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX()
        Me.Cmb_Tipo_Venta = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Btn_Mant_Tipo_Venta = New DevComponents.DotNetBar.ButtonX()
        Me.Grupo_Tipo = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Btn_Transportistas_Sin_Asociar = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Transportistas_Asociados = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Mant_Transportistas = New DevComponents.DotNetBar.ButtonX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar_Configuracion = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Txt_Tipo_Venta = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Chk_ConfirmarLecturaDespacho = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Mostrar_Agencia = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Mostrar_RetiraTransportista = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Valor_Min_Despacho = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Chk_Transpor_Por_Pagar = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Buscar_Transportista_x_Defecto = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_Transportista = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Btn_Buscar_Tipo_Venta_x_Defecto = New DevComponents.DotNetBar.ButtonX()
        Me.Chk_Pedir_Sucursal_Retiro = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Tabs = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.Btn_Conf_Chilexpress = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Conf_Imp_Letrero = New DevComponents.DotNetBar.ButtonX()
        Me.SuperTabItem1 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.Btn_Correos = New DevComponents.DotNetBar.ButtonX()
        Me.SuperTabItem2 = New DevComponents.DotNetBar.SuperTabItem()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla_Correos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_Tipo.SuspendLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Tabs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tabs.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        Me.SuperTabControlPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.LabelX2)
        Me.GroupPanel2.Controls.Add(Me.Cmb_Estados)
        Me.GroupPanel2.Controls.Add(Me.ContextMenuBar1)
        Me.GroupPanel2.Controls.Add(Me.Lbl_Modelo)
        Me.GroupPanel2.Controls.Add(Me.Grilla_Correos)
        Me.GroupPanel2.Controls.Add(Me.LabelX12)
        Me.GroupPanel2.Controls.Add(Me.Cmb_Tipo_Venta)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(3, 14)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(500, 257)
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
        Me.GroupPanel2.TabIndex = 129
        Me.GroupPanel2.Text = "Combinación de envio de correos automaticos, despues de cada acción"
        '
        'LabelX2
        '
        Me.LabelX2.AutoSize = True
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 36)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(46, 20)
        Me.LabelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX2.TabIndex = 132
        Me.LabelX2.Text = "Estados"
        '
        'Cmb_Estados
        '
        Me.Cmb_Estados.DisplayMember = "Text"
        Me.Cmb_Estados.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Estados.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Estados.FormattingEnabled = True
        Me.Cmb_Estados.ItemHeight = 16
        Me.Cmb_Estados.Location = New System.Drawing.Point(127, 34)
        Me.Cmb_Estados.Name = "Cmb_Estados"
        Me.Cmb_Estados.Size = New System.Drawing.Size(290, 22)
        Me.Cmb_Estados.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Estados.TabIndex = 133
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(246, 116)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(130, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 124
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual
        '
        Me.Menu_Contextual.AutoExpandOnClick = True
        Me.Menu_Contextual.Name = "Menu_Contextual"
        Me.Menu_Contextual.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Mnu_Correo, Me.Btn_Mnu_Quitar_Correo, Me.Chk_Adjuntar_Archivo, Me.Btn_Formato_BLV, Me.Btn_Formato_FCV, Me.Btn_Formato_GDV, Me.Btn_Formato_GTI, Me.Chk_Enviar_al_otro_dia})
        Me.Menu_Contextual.Text = "Opciones"
        '
        'Btn_Mnu_Correo
        '
        Me.Btn_Mnu_Correo.Image = CType(resources.GetObject("Btn_Mnu_Correo.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Correo.Name = "Btn_Mnu_Correo"
        Me.Btn_Mnu_Correo.Text = "Ingresar/editar correo"
        '
        'Btn_Mnu_Quitar_Correo
        '
        Me.Btn_Mnu_Quitar_Correo.Image = CType(resources.GetObject("Btn_Mnu_Quitar_Correo.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Quitar_Correo.Name = "Btn_Mnu_Quitar_Correo"
        Me.Btn_Mnu_Quitar_Correo.Text = "Quitar correo"
        '
        'Chk_Adjuntar_Archivo
        '
        Me.Chk_Adjuntar_Archivo.Name = "Chk_Adjuntar_Archivo"
        Me.Chk_Adjuntar_Archivo.Text = "Adjuntar archivos"
        '
        'Btn_Formato_BLV
        '
        Me.Btn_Formato_BLV.Name = "Btn_Formato_BLV"
        Me.Btn_Formato_BLV.Tag = "BLV"
        Me.Btn_Formato_BLV.Text = "Formato BLV:"
        '
        'Btn_Formato_FCV
        '
        Me.Btn_Formato_FCV.Name = "Btn_Formato_FCV"
        Me.Btn_Formato_FCV.Tag = "FCV"
        Me.Btn_Formato_FCV.Text = "Formato FCV:"
        '
        'Btn_Formato_GDV
        '
        Me.Btn_Formato_GDV.Name = "Btn_Formato_GDV"
        Me.Btn_Formato_GDV.Tag = "GDV"
        Me.Btn_Formato_GDV.Text = "Formato GDV:"
        '
        'Btn_Formato_GTI
        '
        Me.Btn_Formato_GTI.Name = "Btn_Formato_GTI"
        Me.Btn_Formato_GTI.Tag = "GTI"
        Me.Btn_Formato_GTI.Text = "Formato GTI:"
        '
        'Chk_Enviar_al_otro_dia
        '
        Me.Chk_Enviar_al_otro_dia.Name = "Chk_Enviar_al_otro_dia"
        Me.Chk_Enviar_al_otro_dia.Text = "Enviar correo al otro día"
        '
        'Lbl_Modelo
        '
        Me.Lbl_Modelo.AutoSize = True
        Me.Lbl_Modelo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Modelo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Modelo.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Modelo.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Modelo.Location = New System.Drawing.Point(3, 10)
        Me.Lbl_Modelo.Name = "Lbl_Modelo"
        Me.Lbl_Modelo.Size = New System.Drawing.Size(65, 20)
        Me.Lbl_Modelo.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Lbl_Modelo.TabIndex = 107
        Me.Lbl_Modelo.Text = "Tipo Venta"
        '
        'Grilla_Correos
        '
        Me.Grilla_Correos.AllowUserToAddRows = False
        Me.Grilla_Correos.AllowUserToDeleteRows = False
        Me.Grilla_Correos.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Correos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grilla_Correos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Correos.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grilla_Correos.EnableHeadersVisualStyles = False
        Me.Grilla_Correos.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Correos.Location = New System.Drawing.Point(3, 88)
        Me.Grilla_Correos.Name = "Grilla_Correos"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Correos.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla_Correos.RowHeadersVisible = False
        Me.Grilla_Correos.RowTemplate.Height = 25
        Me.Grilla_Correos.Size = New System.Drawing.Size(488, 143)
        Me.Grilla_Correos.TabIndex = 122
        '
        'LabelX12
        '
        Me.LabelX12.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX12.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX12.ForeColor = System.Drawing.Color.Black
        Me.LabelX12.Location = New System.Drawing.Point(3, 62)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(427, 23)
        Me.LabelX12.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX12.TabIndex = 123
        Me.LabelX12.Text = "Correos" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Cmb_Tipo_Venta
        '
        Me.Cmb_Tipo_Venta.DisplayMember = "Text"
        Me.Cmb_Tipo_Venta.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Tipo_Venta.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Tipo_Venta.FormattingEnabled = True
        Me.Cmb_Tipo_Venta.ItemHeight = 16
        Me.Cmb_Tipo_Venta.Location = New System.Drawing.Point(127, 8)
        Me.Cmb_Tipo_Venta.Name = "Cmb_Tipo_Venta"
        Me.Cmb_Tipo_Venta.Size = New System.Drawing.Size(290, 22)
        Me.Cmb_Tipo_Venta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Tipo_Venta.TabIndex = 109
        '
        'Btn_Mant_Tipo_Venta
        '
        Me.Btn_Mant_Tipo_Venta.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Mant_Tipo_Venta.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Mant_Tipo_Venta.Image = CType(resources.GetObject("Btn_Mant_Tipo_Venta.Image"), System.Drawing.Image)
        Me.Btn_Mant_Tipo_Venta.Location = New System.Drawing.Point(3, 13)
        Me.Btn_Mant_Tipo_Venta.Name = "Btn_Mant_Tipo_Venta"
        Me.Btn_Mant_Tipo_Venta.Size = New System.Drawing.Size(184, 22)
        Me.Btn_Mant_Tipo_Venta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Mant_Tipo_Venta.TabIndex = 130
        Me.Btn_Mant_Tipo_Venta.Text = "Tipos de venta"
        Me.Btn_Mant_Tipo_Venta.Tooltip = "Mantención de tabla de tipo de venta"
        '
        'Grupo_Tipo
        '
        Me.Grupo_Tipo.BackColor = System.Drawing.Color.White
        Me.Grupo_Tipo.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Tipo.Controls.Add(Me.Btn_Transportistas_Sin_Asociar)
        Me.Grupo_Tipo.Controls.Add(Me.Btn_Transportistas_Asociados)
        Me.Grupo_Tipo.Controls.Add(Me.Btn_Mant_Transportistas)
        Me.Grupo_Tipo.Controls.Add(Me.Btn_Mant_Tipo_Venta)
        Me.Grupo_Tipo.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Tipo.Location = New System.Drawing.Point(14, 244)
        Me.Grupo_Tipo.Name = "Grupo_Tipo"
        Me.Grupo_Tipo.Size = New System.Drawing.Size(460, 94)
        '
        '
        '
        Me.Grupo_Tipo.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Tipo.Style.BackColorGradientAngle = 90
        Me.Grupo_Tipo.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Tipo.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Tipo.Style.BorderBottomWidth = 1
        Me.Grupo_Tipo.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Tipo.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Tipo.Style.BorderLeftWidth = 1
        Me.Grupo_Tipo.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Tipo.Style.BorderRightWidth = 1
        Me.Grupo_Tipo.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Tipo.Style.BorderTopWidth = 1
        Me.Grupo_Tipo.Style.CornerDiameter = 4
        Me.Grupo_Tipo.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Tipo.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Tipo.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Tipo.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Tipo.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Tipo.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Tipo.TabIndex = 128
        Me.Grupo_Tipo.Text = "Tablas de configuración"
        '
        'Btn_Transportistas_Sin_Asociar
        '
        Me.Btn_Transportistas_Sin_Asociar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Transportistas_Sin_Asociar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Transportistas_Sin_Asociar.Image = CType(resources.GetObject("Btn_Transportistas_Sin_Asociar.Image"), System.Drawing.Image)
        Me.Btn_Transportistas_Sin_Asociar.Location = New System.Drawing.Point(325, 41)
        Me.Btn_Transportistas_Sin_Asociar.Name = "Btn_Transportistas_Sin_Asociar"
        Me.Btn_Transportistas_Sin_Asociar.Size = New System.Drawing.Size(126, 22)
        Me.Btn_Transportistas_Sin_Asociar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Transportistas_Sin_Asociar.TabIndex = 134
        Me.Btn_Transportistas_Sin_Asociar.Text = "Sin asociar"
        Me.Btn_Transportistas_Sin_Asociar.Tooltip = "Ver transportistas sin asociar al sistema de despachos"
        '
        'Btn_Transportistas_Asociados
        '
        Me.Btn_Transportistas_Asociados.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Transportistas_Asociados.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Transportistas_Asociados.Image = CType(resources.GetObject("Btn_Transportistas_Asociados.Image"), System.Drawing.Image)
        Me.Btn_Transportistas_Asociados.Location = New System.Drawing.Point(193, 41)
        Me.Btn_Transportistas_Asociados.Name = "Btn_Transportistas_Asociados"
        Me.Btn_Transportistas_Asociados.Size = New System.Drawing.Size(126, 22)
        Me.Btn_Transportistas_Asociados.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Transportistas_Asociados.TabIndex = 133
        Me.Btn_Transportistas_Asociados.Text = "Asociados"
        Me.Btn_Transportistas_Asociados.Tooltip = "Ver transportistas asociados al sistema de despachos"
        '
        'Btn_Mant_Transportistas
        '
        Me.Btn_Mant_Transportistas.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Mant_Transportistas.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Mant_Transportistas.Image = CType(resources.GetObject("Btn_Mant_Transportistas.Image"), System.Drawing.Image)
        Me.Btn_Mant_Transportistas.Location = New System.Drawing.Point(3, 41)
        Me.Btn_Mant_Transportistas.Name = "Btn_Mant_Transportistas"
        Me.Btn_Mant_Transportistas.Size = New System.Drawing.Size(184, 22)
        Me.Btn_Mant_Transportistas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Mant_Transportistas.TabIndex = 132
        Me.Btn_Mant_Transportistas.Text = "Transportistas"
        Me.Btn_Mant_Transportistas.Tooltip = "Mantención de tabla de modelos de marcas de vehículos"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar_Configuracion})
        Me.Bar2.Location = New System.Drawing.Point(0, 457)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(528, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 127
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Grabar_Configuracion
        '
        Me.Btn_Grabar_Configuracion.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar_Configuracion.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar_Configuracion.Image = CType(resources.GetObject("Btn_Grabar_Configuracion.Image"), System.Drawing.Image)
        Me.Btn_Grabar_Configuracion.ImageAlt = CType(resources.GetObject("Btn_Grabar_Configuracion.ImageAlt"), System.Drawing.Image)
        Me.Btn_Grabar_Configuracion.Name = "Btn_Grabar_Configuracion"
        Me.Btn_Grabar_Configuracion.Tooltip = "Configuración Impresora/salidas de impresión letrero"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Txt_Tipo_Venta)
        Me.GroupPanel1.Controls.Add(Me.Chk_ConfirmarLecturaDespacho)
        Me.GroupPanel1.Controls.Add(Me.Chk_Mostrar_Agencia)
        Me.GroupPanel1.Controls.Add(Me.Chk_Mostrar_RetiraTransportista)
        Me.GroupPanel1.Controls.Add(Me.LabelX6)
        Me.GroupPanel1.Controls.Add(Me.Txt_Valor_Min_Despacho)
        Me.GroupPanel1.Controls.Add(Me.Chk_Transpor_Por_Pagar)
        Me.GroupPanel1.Controls.Add(Me.LabelX5)
        Me.GroupPanel1.Controls.Add(Me.LabelX4)
        Me.GroupPanel1.Controls.Add(Me.Btn_Buscar_Transportista_x_Defecto)
        Me.GroupPanel1.Controls.Add(Me.Txt_Transportista)
        Me.GroupPanel1.Controls.Add(Me.Btn_Buscar_Tipo_Venta_x_Defecto)
        Me.GroupPanel1.Controls.Add(Me.Chk_Pedir_Sucursal_Retiro)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(14, 14)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(460, 224)
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
        Me.GroupPanel1.TabIndex = 130
        Me.GroupPanel1.Text = "Configuración despacho por empresa"
        '
        'Txt_Tipo_Venta
        '
        Me.Txt_Tipo_Venta.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Tipo_Venta.Border.Class = "TextBoxBorder"
        Me.Txt_Tipo_Venta.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Tipo_Venta.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Tipo_Venta.ForeColor = System.Drawing.Color.Black
        Me.Txt_Tipo_Venta.Location = New System.Drawing.Point(160, 46)
        Me.Txt_Tipo_Venta.MaxLength = 20
        Me.Txt_Tipo_Venta.Name = "Txt_Tipo_Venta"
        Me.Txt_Tipo_Venta.PreventEnterBeep = True
        Me.Txt_Tipo_Venta.ReadOnly = True
        Me.Txt_Tipo_Venta.Size = New System.Drawing.Size(257, 22)
        Me.Txt_Tipo_Venta.TabIndex = 135
        '
        'Chk_ConfirmarLecturaDespacho
        '
        Me.Chk_ConfirmarLecturaDespacho.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_ConfirmarLecturaDespacho.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_ConfirmarLecturaDespacho.CheckBoxImageChecked = CType(resources.GetObject("Chk_ConfirmarLecturaDespacho.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_ConfirmarLecturaDespacho.ForeColor = System.Drawing.Color.Black
        Me.Chk_ConfirmarLecturaDespacho.Location = New System.Drawing.Point(3, 174)
        Me.Chk_ConfirmarLecturaDespacho.Name = "Chk_ConfirmarLecturaDespacho"
        Me.Chk_ConfirmarLecturaDespacho.Size = New System.Drawing.Size(414, 15)
        Me.Chk_ConfirmarLecturaDespacho.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_ConfirmarLecturaDespacho.TabIndex = 147
        Me.Chk_ConfirmarLecturaDespacho.Text = "Confirmar lectura del despacho al grabar"
        '
        'Chk_Mostrar_Agencia
        '
        Me.Chk_Mostrar_Agencia.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Mostrar_Agencia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Mostrar_Agencia.CheckBoxImageChecked = CType(resources.GetObject("Chk_Mostrar_Agencia.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Mostrar_Agencia.ForeColor = System.Drawing.Color.Black
        Me.Chk_Mostrar_Agencia.Location = New System.Drawing.Point(3, 149)
        Me.Chk_Mostrar_Agencia.Name = "Chk_Mostrar_Agencia"
        Me.Chk_Mostrar_Agencia.Size = New System.Drawing.Size(414, 19)
        Me.Chk_Mostrar_Agencia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Mostrar_Agencia.TabIndex = 146
        Me.Chk_Mostrar_Agencia.Text = "Mostrar agencia"
        '
        'Chk_Mostrar_RetiraTransportista
        '
        Me.Chk_Mostrar_RetiraTransportista.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Mostrar_RetiraTransportista.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Mostrar_RetiraTransportista.CheckBoxImageChecked = CType(resources.GetObject("Chk_Mostrar_RetiraTransportista.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Mostrar_RetiraTransportista.ForeColor = System.Drawing.Color.Black
        Me.Chk_Mostrar_RetiraTransportista.Location = New System.Drawing.Point(3, 128)
        Me.Chk_Mostrar_RetiraTransportista.Name = "Chk_Mostrar_RetiraTransportista"
        Me.Chk_Mostrar_RetiraTransportista.Size = New System.Drawing.Size(414, 19)
        Me.Chk_Mostrar_RetiraTransportista.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Mostrar_RetiraTransportista.TabIndex = 145
        Me.Chk_Mostrar_RetiraTransportista.Text = "Mostrar retira transportista"
        '
        'LabelX6
        '
        Me.LabelX6.AutoSize = True
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(3, 102)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(178, 20)
        Me.LabelX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX6.TabIndex = 144
        Me.LabelX6.Text = "Valor mínimo para despacho $"
        '
        'Txt_Valor_Min_Despacho
        '
        Me.Txt_Valor_Min_Despacho.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Valor_Min_Despacho.Border.Class = "TextBoxBorder"
        Me.Txt_Valor_Min_Despacho.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Valor_Min_Despacho.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Valor_Min_Despacho.ForeColor = System.Drawing.Color.Black
        Me.Txt_Valor_Min_Despacho.Location = New System.Drawing.Point(187, 100)
        Me.Txt_Valor_Min_Despacho.MaxLength = 20
        Me.Txt_Valor_Min_Despacho.Name = "Txt_Valor_Min_Despacho"
        Me.Txt_Valor_Min_Despacho.PreventEnterBeep = True
        Me.Txt_Valor_Min_Despacho.Size = New System.Drawing.Size(92, 22)
        Me.Txt_Valor_Min_Despacho.TabIndex = 143
        Me.Txt_Valor_Min_Despacho.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Chk_Transpor_Por_Pagar
        '
        Me.Chk_Transpor_Por_Pagar.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Transpor_Por_Pagar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Transpor_Por_Pagar.CheckBoxImageChecked = CType(resources.GetObject("Chk_Transpor_Por_Pagar.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Transpor_Por_Pagar.ForeColor = System.Drawing.Color.Black
        Me.Chk_Transpor_Por_Pagar.Location = New System.Drawing.Point(3, 21)
        Me.Chk_Transpor_Por_Pagar.Name = "Chk_Transpor_Por_Pagar"
        Me.Chk_Transpor_Por_Pagar.Size = New System.Drawing.Size(414, 28)
        Me.Chk_Transpor_Por_Pagar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Transpor_Por_Pagar.TabIndex = 142
        Me.Chk_Transpor_Por_Pagar.Text = "Transporte por pagar"
        '
        'LabelX5
        '
        Me.LabelX5.AutoSize = True
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(3, 74)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(147, 20)
        Me.LabelX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX5.TabIndex = 141
        Me.LabelX5.Text = "Transportista por defecto"
        '
        'LabelX4
        '
        Me.LabelX4.AutoSize = True
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(3, 48)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(151, 20)
        Me.LabelX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX4.TabIndex = 140
        Me.LabelX4.Text = "Tipo de venta por defecto"
        '
        'Btn_Buscar_Transportista_x_Defecto
        '
        Me.Btn_Buscar_Transportista_x_Defecto.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Buscar_Transportista_x_Defecto.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Buscar_Transportista_x_Defecto.Image = CType(resources.GetObject("Btn_Buscar_Transportista_x_Defecto.Image"), System.Drawing.Image)
        Me.Btn_Buscar_Transportista_x_Defecto.Location = New System.Drawing.Point(423, 72)
        Me.Btn_Buscar_Transportista_x_Defecto.Name = "Btn_Buscar_Transportista_x_Defecto"
        Me.Btn_Buscar_Transportista_x_Defecto.Size = New System.Drawing.Size(28, 22)
        Me.Btn_Buscar_Transportista_x_Defecto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Buscar_Transportista_x_Defecto.TabIndex = 132
        Me.Btn_Buscar_Transportista_x_Defecto.Tooltip = "Ver selección"
        '
        'Txt_Transportista
        '
        Me.Txt_Transportista.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Transportista.Border.Class = "TextBoxBorder"
        Me.Txt_Transportista.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Transportista.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Transportista.ForeColor = System.Drawing.Color.Black
        Me.Txt_Transportista.Location = New System.Drawing.Point(160, 72)
        Me.Txt_Transportista.MaxLength = 20
        Me.Txt_Transportista.Name = "Txt_Transportista"
        Me.Txt_Transportista.PreventEnterBeep = True
        Me.Txt_Transportista.ReadOnly = True
        Me.Txt_Transportista.Size = New System.Drawing.Size(257, 22)
        Me.Txt_Transportista.TabIndex = 137
        '
        'Btn_Buscar_Tipo_Venta_x_Defecto
        '
        Me.Btn_Buscar_Tipo_Venta_x_Defecto.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Buscar_Tipo_Venta_x_Defecto.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Buscar_Tipo_Venta_x_Defecto.Image = CType(resources.GetObject("Btn_Buscar_Tipo_Venta_x_Defecto.Image"), System.Drawing.Image)
        Me.Btn_Buscar_Tipo_Venta_x_Defecto.Location = New System.Drawing.Point(423, 46)
        Me.Btn_Buscar_Tipo_Venta_x_Defecto.Name = "Btn_Buscar_Tipo_Venta_x_Defecto"
        Me.Btn_Buscar_Tipo_Venta_x_Defecto.Size = New System.Drawing.Size(28, 22)
        Me.Btn_Buscar_Tipo_Venta_x_Defecto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Buscar_Tipo_Venta_x_Defecto.TabIndex = 134
        Me.Btn_Buscar_Tipo_Venta_x_Defecto.TabStop = False
        Me.Btn_Buscar_Tipo_Venta_x_Defecto.Tooltip = "Buscar Cliente"
        '
        'Chk_Pedir_Sucursal_Retiro
        '
        Me.Chk_Pedir_Sucursal_Retiro.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Pedir_Sucursal_Retiro.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Pedir_Sucursal_Retiro.CheckBoxImageChecked = CType(resources.GetObject("Chk_Pedir_Sucursal_Retiro.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Pedir_Sucursal_Retiro.ForeColor = System.Drawing.Color.Black
        Me.Chk_Pedir_Sucursal_Retiro.Location = New System.Drawing.Point(3, 1)
        Me.Chk_Pedir_Sucursal_Retiro.Name = "Chk_Pedir_Sucursal_Retiro"
        Me.Chk_Pedir_Sucursal_Retiro.Size = New System.Drawing.Size(414, 28)
        Me.Chk_Pedir_Sucursal_Retiro.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Pedir_Sucursal_Retiro.TabIndex = 0
        Me.Chk_Pedir_Sucursal_Retiro.Text = "Pedir sucursal de retiro"
        '
        'Tabs
        '
        Me.Tabs.BackColor = System.Drawing.Color.White
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
        Me.Tabs.Controls.Add(Me.SuperTabControlPanel1)
        Me.Tabs.Controls.Add(Me.SuperTabControlPanel2)
        Me.Tabs.ForeColor = System.Drawing.Color.Black
        Me.Tabs.Location = New System.Drawing.Point(12, 12)
        Me.Tabs.Name = "Tabs"
        Me.Tabs.ReorderTabsEnabled = True
        Me.Tabs.SelectedTabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Tabs.SelectedTabIndex = 0
        Me.Tabs.Size = New System.Drawing.Size(506, 434)
        Me.Tabs.TabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tabs.TabIndex = 131
        Me.Tabs.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabItem1, Me.SuperTabItem2})
        Me.Tabs.Text = "Configuración general"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.Btn_Conf_Chilexpress)
        Me.SuperTabControlPanel1.Controls.Add(Me.Btn_Conf_Imp_Letrero)
        Me.SuperTabControlPanel1.Controls.Add(Me.GroupPanel1)
        Me.SuperTabControlPanel1.Controls.Add(Me.Grupo_Tipo)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 27)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(506, 407)
        Me.SuperTabControlPanel1.TabIndex = 1
        Me.SuperTabControlPanel1.TabItem = Me.SuperTabItem1
        '
        'Btn_Conf_Chilexpress
        '
        Me.Btn_Conf_Chilexpress.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Conf_Chilexpress.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Conf_Chilexpress.Location = New System.Drawing.Point(14, 373)
        Me.Btn_Conf_Chilexpress.Name = "Btn_Conf_Chilexpress"
        Me.Btn_Conf_Chilexpress.Size = New System.Drawing.Size(157, 23)
        Me.Btn_Conf_Chilexpress.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Conf_Chilexpress.TabIndex = 141
        Me.Btn_Conf_Chilexpress.Text = "Conf. CHILEXPRESS"
        Me.Btn_Conf_Chilexpress.Tooltip = "Configuración de llaves para sis. Chilexpress"
        '
        'Btn_Conf_Imp_Letrero
        '
        Me.Btn_Conf_Imp_Letrero.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Conf_Imp_Letrero.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Conf_Imp_Letrero.Location = New System.Drawing.Point(14, 344)
        Me.Btn_Conf_Imp_Letrero.Name = "Btn_Conf_Imp_Letrero"
        Me.Btn_Conf_Imp_Letrero.Size = New System.Drawing.Size(157, 23)
        Me.Btn_Conf_Imp_Letrero.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Conf_Imp_Letrero.TabIndex = 140
        Me.Btn_Conf_Imp_Letrero.Text = "Conf. Impresora para letrero"
        Me.Btn_Conf_Imp_Letrero.Tooltip = "Configuración Impresora/salidas de impresión letrero"
        '
        'SuperTabItem1
        '
        Me.SuperTabItem1.AttachedControl = Me.SuperTabControlPanel1
        Me.SuperTabItem1.GlobalItem = False
        Me.SuperTabItem1.Name = "SuperTabItem1"
        Me.SuperTabItem1.Text = "Configuración general"
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Controls.Add(Me.Btn_Correos)
        Me.SuperTabControlPanel2.Controls.Add(Me.GroupPanel2)
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 27)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(506, 407)
        Me.SuperTabControlPanel2.TabIndex = 0
        Me.SuperTabControlPanel2.TabItem = Me.SuperTabItem2
        '
        'Btn_Correos
        '
        Me.Btn_Correos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Correos.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Correos.Location = New System.Drawing.Point(12, 286)
        Me.Btn_Correos.Name = "Btn_Correos"
        Me.Btn_Correos.Size = New System.Drawing.Size(108, 23)
        Me.Btn_Correos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Correos.TabIndex = 141
        Me.Btn_Correos.Text = "Conf. Correos"
        Me.Btn_Correos.Tooltip = "Mantención de correos de salida SMTP del sistema"
        '
        'SuperTabItem2
        '
        Me.SuperTabItem2.AttachedControl = Me.SuperTabControlPanel2
        Me.SuperTabItem2.GlobalItem = False
        Me.SuperTabItem2.Name = "SuperTabItem2"
        Me.SuperTabItem2.Text = "Configuración correo automático"
        '
        'Frm_Despacho_Configuracion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(528, 498)
        Me.Controls.Add(Me.Tabs)
        Me.Controls.Add(Me.Bar2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Despacho_Configuracion"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuración Sis. Despachos"
        Me.GroupPanel2.ResumeLayout(False)
        Me.GroupPanel2.PerformLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla_Correos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo_Tipo.ResumeLayout(False)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        CType(Me.Tabs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tabs.ResumeLayout(False)
        Me.SuperTabControlPanel1.ResumeLayout(False)
        Me.SuperTabControlPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Mnu_Correo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_Quitar_Correo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Lbl_Modelo As DevComponents.DotNetBar.LabelX
    Friend WithEvents Grilla_Correos As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Cmb_Tipo_Venta As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Grupo_Tipo As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Mant_Tipo_Venta As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Cmb_Estados As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Btn_Mant_Transportistas As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Chk_Adjuntar_Archivo As DevComponents.DotNetBar.CheckBoxItem
    Friend WithEvents Chk_Enviar_al_otro_dia As DevComponents.DotNetBar.CheckBoxItem
    Friend WithEvents Btn_Formato_BLV As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Formato_FCV As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Formato_GDV As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Formato_GTI As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Chk_Pedir_Sucursal_Retiro As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Btn_Buscar_Transportista_x_Defecto As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Txt_Transportista As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Btn_Buscar_Tipo_Venta_x_Defecto As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Txt_Tipo_Venta As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Chk_Transpor_Por_Pagar As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Tabs As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem2 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem1 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents Btn_Grabar_Configuracion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Conf_Imp_Letrero As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Correos As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Valor_Min_Despacho As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Btn_Transportistas_Asociados As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Transportistas_Sin_Asociar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Conf_Chilexpress As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Chk_Mostrar_RetiraTransportista As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Mostrar_Agencia As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_ConfirmarLecturaDespacho As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
