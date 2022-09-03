<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Meson_Operario
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Meson_Operario))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Actualizar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Impirmir_ProdMeson = New DevComponents.DotNetBar.ButtonItem()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_Meson = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Agregar_Producto_Maquina = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Ingresar_DFA_Manualmente = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Ingresar_DFA_Manualmente_Porcentaje = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Enviar_Meson_Siguiente = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Agregar_Observaciones = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Info_Comercial = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_Maquina = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Poducto_Fabricado = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Avence_Porcentaje = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Problemas_Maquina = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Solo_Quitar_Prod_Maquina = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Cambiar_Hora_Ingreso = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Grilla_Productos_En_Meson = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Grilla_Maquinas_Meson = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Imagenes_16x16 = New System.Windows.Forms.ImageList(Me.components)
        Me.Tiempo_Actualizacion = New System.Windows.Forms.Timer(Me.components)
        Me.Txt_Stx_Etx = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Lbl_Fin_Trabajos = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Enviar_Sel_Maquina = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Finalizar_Trabajo = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Tiempo_Cierre_Automatico = New System.Windows.Forms.Timer(Me.components)
        Me.Imagen_Barra = New DevComponents.DotNetBar.Controls.ReflectionImage()
        Me.Chk_Preguntar_Cuantos_Fabricar = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Cmb_Mesones = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Lbl_Productos_En_Meson = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Info_Linea = New DevComponents.DotNetBar.LabelX()
        Me.Imagenes2_16x16 = New System.Windows.Forms.ImageList(Me.components)
        Me.Imagenes_32_32 = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.Grilla_Productos_En_Meson, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel3.SuspendLayout()
        CType(Me.Grilla_Maquinas_Meson, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Actualizar, Me.Btn_Impirmir_ProdMeson})
        Me.Bar1.Location = New System.Drawing.Point(0, 588)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(1236, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 29
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Actualizar
        '
        Me.Btn_Actualizar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Actualizar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Actualizar.Image = CType(resources.GetObject("Btn_Actualizar.Image"), System.Drawing.Image)
        Me.Btn_Actualizar.ImageAlt = CType(resources.GetObject("Btn_Actualizar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Actualizar.Name = "Btn_Actualizar"
        Me.Btn_Actualizar.Tooltip = "Grabar"
        '
        'Btn_Impirmir_ProdMeson
        '
        Me.Btn_Impirmir_ProdMeson.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Impirmir_ProdMeson.ForeColor = System.Drawing.Color.Black
        Me.Btn_Impirmir_ProdMeson.Image = CType(resources.GetObject("Btn_Impirmir_ProdMeson.Image"), System.Drawing.Image)
        Me.Btn_Impirmir_ProdMeson.ImageAlt = CType(resources.GetObject("Btn_Impirmir_ProdMeson.ImageAlt"), System.Drawing.Image)
        Me.Btn_Impirmir_ProdMeson.Name = "Btn_Impirmir_ProdMeson"
        Me.Btn_Impirmir_ProdMeson.Tooltip = "Imprimir productos en el mesón"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_Meson, Me.Menu_Contextual_Maquina})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(126, 37)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(380, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 49
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_Meson
        '
        Me.Menu_Contextual_Meson.AutoExpandOnClick = True
        Me.Menu_Contextual_Meson.Name = "Menu_Contextual_Meson"
        Me.Menu_Contextual_Meson.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Mnu_Agregar_Producto_Maquina, Me.Btn_Ingresar_DFA_Manualmente, Me.Btn_Ingresar_DFA_Manualmente_Porcentaje, Me.Btn_Enviar_Meson_Siguiente, Me.Btn_Agregar_Observaciones, Me.Btn_Info_Comercial})
        Me.Menu_Contextual_Meson.Text = "Meson"
        '
        'Btn_Mnu_Agregar_Producto_Maquina
        '
        Me.Btn_Mnu_Agregar_Producto_Maquina.Image = CType(resources.GetObject("Btn_Mnu_Agregar_Producto_Maquina.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Agregar_Producto_Maquina.ImageAlt = CType(resources.GetObject("Btn_Mnu_Agregar_Producto_Maquina.ImageAlt"), System.Drawing.Image)
        Me.Btn_Mnu_Agregar_Producto_Maquina.Name = "Btn_Mnu_Agregar_Producto_Maquina"
        Me.Btn_Mnu_Agregar_Producto_Maquina.Text = "Enviar producto a la maquina"
        Me.Btn_Mnu_Agregar_Producto_Maquina.Visible = False
        '
        'Btn_Ingresar_DFA_Manualmente
        '
        Me.Btn_Ingresar_DFA_Manualmente.Image = CType(resources.GetObject("Btn_Ingresar_DFA_Manualmente.Image"), System.Drawing.Image)
        Me.Btn_Ingresar_DFA_Manualmente.ImageAlt = CType(resources.GetObject("Btn_Ingresar_DFA_Manualmente.ImageAlt"), System.Drawing.Image)
        Me.Btn_Ingresar_DFA_Manualmente.Name = "Btn_Ingresar_DFA_Manualmente"
        Me.Btn_Ingresar_DFA_Manualmente.Text = "Ingresar datos de fabricación en forma manual para líneas tickeadas (productos te" &
    "rminados completamente)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Btn_Ingresar_DFA_Manualmente_Porcentaje
        '
        Me.Btn_Ingresar_DFA_Manualmente_Porcentaje.Image = CType(resources.GetObject("Btn_Ingresar_DFA_Manualmente_Porcentaje.Image"), System.Drawing.Image)
        Me.Btn_Ingresar_DFA_Manualmente_Porcentaje.ImageAlt = CType(resources.GetObject("Btn_Ingresar_DFA_Manualmente_Porcentaje.ImageAlt"), System.Drawing.Image)
        Me.Btn_Ingresar_DFA_Manualmente_Porcentaje.Name = "Btn_Ingresar_DFA_Manualmente_Porcentaje"
        Me.Btn_Ingresar_DFA_Manualmente_Porcentaje.Text = "Ingresar datos de fabricación en forma manual para la líneas tickeadas (solo avan" &
    "ce en %)"
        '
        'Btn_Enviar_Meson_Siguiente
        '
        Me.Btn_Enviar_Meson_Siguiente.Image = CType(resources.GetObject("Btn_Enviar_Meson_Siguiente.Image"), System.Drawing.Image)
        Me.Btn_Enviar_Meson_Siguiente.ImageAlt = CType(resources.GetObject("Btn_Enviar_Meson_Siguiente.ImageAlt"), System.Drawing.Image)
        Me.Btn_Enviar_Meson_Siguiente.Name = "Btn_Enviar_Meson_Siguiente"
        Me.Btn_Enviar_Meson_Siguiente.Text = "Enviar producto al mesón siguiente"
        Me.Btn_Enviar_Meson_Siguiente.Visible = False
        '
        'Btn_Agregar_Observaciones
        '
        Me.Btn_Agregar_Observaciones.Image = CType(resources.GetObject("Btn_Agregar_Observaciones.Image"), System.Drawing.Image)
        Me.Btn_Agregar_Observaciones.ImageAlt = CType(resources.GetObject("Btn_Agregar_Observaciones.ImageAlt"), System.Drawing.Image)
        Me.Btn_Agregar_Observaciones.Name = "Btn_Agregar_Observaciones"
        Me.Btn_Agregar_Observaciones.Text = "Agregar observaciones"
        '
        'Btn_Info_Comercial
        '
        Me.Btn_Info_Comercial.Image = CType(resources.GetObject("Btn_Info_Comercial.Image"), System.Drawing.Image)
        Me.Btn_Info_Comercial.ImageAlt = CType(resources.GetObject("Btn_Info_Comercial.ImageAlt"), System.Drawing.Image)
        Me.Btn_Info_Comercial.Name = "Btn_Info_Comercial"
        Me.Btn_Info_Comercial.Text = "Informacion comercial"
        '
        'Menu_Contextual_Maquina
        '
        Me.Menu_Contextual_Maquina.AutoExpandOnClick = True
        Me.Menu_Contextual_Maquina.Name = "Menu_Contextual_Maquina"
        Me.Menu_Contextual_Maquina.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Poducto_Fabricado, Me.Btn_Avence_Porcentaje, Me.Btn_Problemas_Maquina, Me.Btn_Solo_Quitar_Prod_Maquina, Me.ButtonItem1, Me.Btn_Cambiar_Hora_Ingreso})
        Me.Menu_Contextual_Maquina.Text = "Maquinas"
        '
        'Btn_Poducto_Fabricado
        '
        Me.Btn_Poducto_Fabricado.Image = CType(resources.GetObject("Btn_Poducto_Fabricado.Image"), System.Drawing.Image)
        Me.Btn_Poducto_Fabricado.ImageAlt = CType(resources.GetObject("Btn_Poducto_Fabricado.ImageAlt"), System.Drawing.Image)
        Me.Btn_Poducto_Fabricado.Name = "Btn_Poducto_Fabricado"
        Me.Btn_Poducto_Fabricado.Text = "Producto(s) fabricado(s) completamente"
        '
        'Btn_Avence_Porcentaje
        '
        Me.Btn_Avence_Porcentaje.Image = CType(resources.GetObject("Btn_Avence_Porcentaje.Image"), System.Drawing.Image)
        Me.Btn_Avence_Porcentaje.ImageAlt = CType(resources.GetObject("Btn_Avence_Porcentaje.ImageAlt"), System.Drawing.Image)
        Me.Btn_Avence_Porcentaje.Name = "Btn_Avence_Porcentaje"
        Me.Btn_Avence_Porcentaje.Text = "Ingresar solo % de avance de fabricación"
        '
        'Btn_Problemas_Maquina
        '
        Me.Btn_Problemas_Maquina.Image = CType(resources.GetObject("Btn_Problemas_Maquina.Image"), System.Drawing.Image)
        Me.Btn_Problemas_Maquina.ImageAlt = CType(resources.GetObject("Btn_Problemas_Maquina.ImageAlt"), System.Drawing.Image)
        Me.Btn_Problemas_Maquina.Name = "Btn_Problemas_Maquina"
        Me.Btn_Problemas_Maquina.Text = "Quitar producto de la maquina (problemas en la fabricación)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Btn_Solo_Quitar_Prod_Maquina
        '
        Me.Btn_Solo_Quitar_Prod_Maquina.Image = CType(resources.GetObject("Btn_Solo_Quitar_Prod_Maquina.Image"), System.Drawing.Image)
        Me.Btn_Solo_Quitar_Prod_Maquina.ImageAlt = CType(resources.GetObject("Btn_Solo_Quitar_Prod_Maquina.ImageAlt"), System.Drawing.Image)
        Me.Btn_Solo_Quitar_Prod_Maquina.Name = "Btn_Solo_Quitar_Prod_Maquina"
        Me.Btn_Solo_Quitar_Prod_Maquina.Text = "Quitar producto de la maquina (asignado por error)"
        '
        'ButtonItem1
        '
        Me.ButtonItem1.Image = CType(resources.GetObject("ButtonItem1.Image"), System.Drawing.Image)
        Me.ButtonItem1.ImageAlt = CType(resources.GetObject("ButtonItem1.ImageAlt"), System.Drawing.Image)
        Me.ButtonItem1.Name = "ButtonItem1"
        Me.ButtonItem1.Text = "Agregar observaciones"
        Me.ButtonItem1.Visible = False
        '
        'Btn_Cambiar_Hora_Ingreso
        '
        Me.Btn_Cambiar_Hora_Ingreso.Image = CType(resources.GetObject("Btn_Cambiar_Hora_Ingreso.Image"), System.Drawing.Image)
        Me.Btn_Cambiar_Hora_Ingreso.ImageAlt = CType(resources.GetObject("Btn_Cambiar_Hora_Ingreso.ImageAlt"), System.Drawing.Image)
        Me.Btn_Cambiar_Hora_Ingreso.Name = "Btn_Cambiar_Hora_Ingreso"
        Me.Btn_Cambiar_Hora_Ingreso.Text = "Cambiar hora de ingreso"
        '
        'GroupPanel2
        '
        Me.GroupPanel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.ContextMenuBar1)
        Me.GroupPanel2.Controls.Add(Me.Grilla_Productos_En_Meson)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(12, 45)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(1212, 247)
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
        Me.GroupPanel2.TabIndex = 98
        Me.GroupPanel2.Text = "PRODUCTOS EN ESPERA EN EL MESON"
        '
        'Grilla_Productos_En_Meson
        '
        Me.Grilla_Productos_En_Meson.AllowUserToAddRows = False
        Me.Grilla_Productos_En_Meson.AllowUserToDeleteRows = False
        Me.Grilla_Productos_En_Meson.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Productos_En_Meson.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grilla_Productos_En_Meson.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Productos_En_Meson.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grilla_Productos_En_Meson.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Productos_En_Meson.EnableHeadersVisualStyles = False
        Me.Grilla_Productos_En_Meson.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Productos_En_Meson.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Productos_En_Meson.MultiSelect = False
        Me.Grilla_Productos_En_Meson.Name = "Grilla_Productos_En_Meson"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Productos_En_Meson.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla_Productos_En_Meson.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grilla_Productos_En_Meson.Size = New System.Drawing.Size(1206, 224)
        Me.Grilla_Productos_En_Meson.TabIndex = 1
        '
        'GroupPanel3
        '
        Me.GroupPanel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupPanel3.BackColor = System.Drawing.Color.White
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.Grilla_Maquinas_Meson)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Location = New System.Drawing.Point(12, 370)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(1212, 159)
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
        Me.GroupPanel3.TabIndex = 100
        Me.GroupPanel3.Text = "TRABAJOS EN LAS MAQUINAS DEL MESON"
        '
        'Grilla_Maquinas_Meson
        '
        Me.Grilla_Maquinas_Meson.AllowUserToAddRows = False
        Me.Grilla_Maquinas_Meson.AllowUserToDeleteRows = False
        Me.Grilla_Maquinas_Meson.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Maquinas_Meson.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Grilla_Maquinas_Meson.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Maquinas_Meson.DefaultCellStyle = DataGridViewCellStyle5
        Me.Grilla_Maquinas_Meson.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Maquinas_Meson.EnableHeadersVisualStyles = False
        Me.Grilla_Maquinas_Meson.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Maquinas_Meson.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Maquinas_Meson.MultiSelect = False
        Me.Grilla_Maquinas_Meson.Name = "Grilla_Maquinas_Meson"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Maquinas_Meson.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Grilla_Maquinas_Meson.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grilla_Maquinas_Meson.Size = New System.Drawing.Size(1206, 136)
        Me.Grilla_Maquinas_Meson.TabIndex = 1
        '
        'Imagenes_16x16
        '
        Me.Imagenes_16x16.ImageStream = CType(resources.GetObject("Imagenes_16x16.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagenes_16x16.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagenes_16x16.Images.SetKeyName(0, "delete.png")
        Me.Imagenes_16x16.Images.SetKeyName(1, "application-option.png")
        '
        'Tiempo_Actualizacion
        '
        Me.Tiempo_Actualizacion.Enabled = True
        Me.Tiempo_Actualizacion.Interval = 1000
        '
        'Txt_Stx_Etx
        '
        Me.Txt_Stx_Etx.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Stx_Etx.Border.Class = "TextBoxBorder"
        Me.Txt_Stx_Etx.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Stx_Etx.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Stx_Etx.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Stx_Etx.FocusHighlightEnabled = True
        Me.Txt_Stx_Etx.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Stx_Etx.ForeColor = System.Drawing.Color.Black
        Me.Txt_Stx_Etx.Location = New System.Drawing.Point(510, 556)
        Me.Txt_Stx_Etx.MaxLength = 50
        Me.Txt_Stx_Etx.Name = "Txt_Stx_Etx"
        Me.Txt_Stx_Etx.Size = New System.Drawing.Size(115, 26)
        Me.Txt_Stx_Etx.TabIndex = 111
        Me.Txt_Stx_Etx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Lbl_Fin_Trabajos
        '
        Me.Lbl_Fin_Trabajos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Fin_Trabajos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Fin_Trabajos.Font = New System.Drawing.Font("Courier New", 9.75!)
        Me.Lbl_Fin_Trabajos.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Fin_Trabajos.Location = New System.Drawing.Point(345, 559)
        Me.Lbl_Fin_Trabajos.Name = "Lbl_Fin_Trabajos"
        Me.Lbl_Fin_Trabajos.Size = New System.Drawing.Size(159, 23)
        Me.Lbl_Fin_Trabajos.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Lbl_Fin_Trabajos.TabIndex = 110
        Me.Lbl_Fin_Trabajos.Text = "INICIO / FIN Trabajo"
        '
        'Btn_Enviar_Sel_Maquina
        '
        Me.Btn_Enviar_Sel_Maquina.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Enviar_Sel_Maquina.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Enviar_Sel_Maquina.Image = CType(resources.GetObject("Btn_Enviar_Sel_Maquina.Image"), System.Drawing.Image)
        Me.Btn_Enviar_Sel_Maquina.ImageAlt = CType(resources.GetObject("Btn_Enviar_Sel_Maquina.ImageAlt"), System.Drawing.Image)
        Me.Btn_Enviar_Sel_Maquina.Location = New System.Drawing.Point(12, 327)
        Me.Btn_Enviar_Sel_Maquina.Name = "Btn_Enviar_Sel_Maquina"
        Me.Btn_Enviar_Sel_Maquina.Size = New System.Drawing.Size(51, 37)
        Me.Btn_Enviar_Sel_Maquina.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Enviar_Sel_Maquina.TabIndex = 112
        Me.Btn_Enviar_Sel_Maquina.Tooltip = "Enviar productos seleccionados a la maquina"
        '
        'Btn_Finalizar_Trabajo
        '
        Me.Btn_Finalizar_Trabajo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Finalizar_Trabajo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Finalizar_Trabajo.Image = CType(resources.GetObject("Btn_Finalizar_Trabajo.Image"), System.Drawing.Image)
        Me.Btn_Finalizar_Trabajo.ImageAlt = CType(resources.GetObject("Btn_Finalizar_Trabajo.ImageAlt"), System.Drawing.Image)
        Me.Btn_Finalizar_Trabajo.Location = New System.Drawing.Point(12, 544)
        Me.Btn_Finalizar_Trabajo.Name = "Btn_Finalizar_Trabajo"
        Me.Btn_Finalizar_Trabajo.Size = New System.Drawing.Size(48, 38)
        Me.Btn_Finalizar_Trabajo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Finalizar_Trabajo.TabIndex = 113
        Me.Btn_Finalizar_Trabajo.Tooltip = "Enviar productos seleccionados a la maquina"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(69, 341)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(319, 23)
        Me.LabelX1.TabIndex = 114
        Me.LabelX1.Text = "Enviar producto(s) a la maquina, solo productos seleccionados"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(69, 559)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(238, 23)
        Me.LabelX2.TabIndex = 115
        Me.LabelX2.Text = "Finalizar trabajo, solo productos seleccionados"
        '
        'Tiempo_Cierre_Automatico
        '
        Me.Tiempo_Cierre_Automatico.Interval = 1000
        '
        'Imagen_Barra
        '
        Me.Imagen_Barra.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Imagen_Barra.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Imagen_Barra.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Imagen_Barra.ForeColor = System.Drawing.Color.Black
        Me.Imagen_Barra.Image = CType(resources.GetObject("Imagen_Barra.Image"), System.Drawing.Image)
        Me.Imagen_Barra.Location = New System.Drawing.Point(626, 554)
        Me.Imagen_Barra.Name = "Imagen_Barra"
        Me.Imagen_Barra.ReflectionEnabled = False
        Me.Imagen_Barra.Size = New System.Drawing.Size(43, 29)
        Me.Imagen_Barra.TabIndex = 116
        '
        'Chk_Preguntar_Cuantos_Fabricar
        '
        Me.Chk_Preguntar_Cuantos_Fabricar.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Preguntar_Cuantos_Fabricar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Preguntar_Cuantos_Fabricar.Checked = True
        Me.Chk_Preguntar_Cuantos_Fabricar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_Preguntar_Cuantos_Fabricar.CheckValue = "Y"
        Me.Chk_Preguntar_Cuantos_Fabricar.ForeColor = System.Drawing.Color.Black
        Me.Chk_Preguntar_Cuantos_Fabricar.Location = New System.Drawing.Point(394, 341)
        Me.Chk_Preguntar_Cuantos_Fabricar.Name = "Chk_Preguntar_Cuantos_Fabricar"
        Me.Chk_Preguntar_Cuantos_Fabricar.Size = New System.Drawing.Size(284, 23)
        Me.Chk_Preguntar_Cuantos_Fabricar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Preguntar_Cuantos_Fabricar.TabIndex = 117
        Me.Chk_Preguntar_Cuantos_Fabricar.Text = "Preguntar cuantos productos se van a fabricar"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(12, 12)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(40, 23)
        Me.LabelX3.TabIndex = 118
        Me.LabelX3.Text = "MESON"
        '
        'Cmb_Mesones
        '
        Me.Cmb_Mesones.DisplayMember = "Text"
        Me.Cmb_Mesones.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Mesones.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Mesones.FormattingEnabled = True
        Me.Cmb_Mesones.ItemHeight = 16
        Me.Cmb_Mesones.Location = New System.Drawing.Point(69, 12)
        Me.Cmb_Mesones.Name = "Cmb_Mesones"
        Me.Cmb_Mesones.Size = New System.Drawing.Size(352, 22)
        Me.Cmb_Mesones.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Mesones.TabIndex = 119
        '
        'Lbl_Productos_En_Meson
        '
        Me.Lbl_Productos_En_Meson.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Productos_En_Meson.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Productos_En_Meson.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Productos_En_Meson.Location = New System.Drawing.Point(427, 11)
        Me.Lbl_Productos_En_Meson.Name = "Lbl_Productos_En_Meson"
        Me.Lbl_Productos_En_Meson.Size = New System.Drawing.Size(409, 23)
        Me.Lbl_Productos_En_Meson.TabIndex = 120
        Me.Lbl_Productos_En_Meson.Text = "MESON"
        '
        'Lbl_Info_Linea
        '
        Me.Lbl_Info_Linea.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Info_Linea.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Info_Linea.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Info_Linea.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Info_Linea.Location = New System.Drawing.Point(12, 295)
        Me.Lbl_Info_Linea.Name = "Lbl_Info_Linea"
        Me.Lbl_Info_Linea.Size = New System.Drawing.Size(1120, 23)
        Me.Lbl_Info_Linea.TabIndex = 121
        Me.Lbl_Info_Linea.Text = "Lbl_Info_Linea"
        '
        'Imagenes2_16x16
        '
        Me.Imagenes2_16x16.ImageStream = CType(resources.GetObject("Imagenes2_16x16.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagenes2_16x16.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagenes2_16x16.Images.SetKeyName(0, "alert.png")
        Me.Imagenes2_16x16.Images.SetKeyName(1, "alert.png")
        Me.Imagenes2_16x16.Images.SetKeyName(2, "alert-info.png")
        '
        'Imagenes_32_32
        '
        Me.Imagenes_32_32.ImageStream = CType(resources.GetObject("Imagenes_32_32.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagenes_32_32.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagenes_32_32.Images.SetKeyName(0, "button-ok.png")
        '
        'Frm_Meson_Operario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1236, 629)
        Me.Controls.Add(Me.Lbl_Info_Linea)
        Me.Controls.Add(Me.Lbl_Productos_En_Meson)
        Me.Controls.Add(Me.Cmb_Mesones)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.Chk_Preguntar_Cuantos_Fabricar)
        Me.Controls.Add(Me.Imagen_Barra)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Btn_Finalizar_Trabajo)
        Me.Controls.Add(Me.Btn_Enviar_Sel_Maquina)
        Me.Controls.Add(Me.Txt_Stx_Etx)
        Me.Controls.Add(Me.Lbl_Fin_Trabajos)
        Me.Controls.Add(Me.GroupPanel3)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Meson_Operario"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Operación de Mesones"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.Grilla_Productos_En_Meson, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel3.ResumeLayout(False)
        CType(Me.Grilla_Maquinas_Meson, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Public WithEvents Btn_Actualizar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_Meson As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_Agregar_Producto_Maquina As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Agregar_Observaciones As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Menu_Contextual_Maquina As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grilla_Productos_En_Meson As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grilla_Maquinas_Meson As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Imagenes_16x16 As ImageList
    Friend WithEvents Btn_Enviar_Meson_Siguiente As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Tiempo_Actualizacion As Timer
    Friend WithEvents Btn_Poducto_Fabricado As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Avence_Porcentaje As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Problemas_Maquina As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Txt_Stx_Etx As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Lbl_Fin_Trabajos As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Solo_Quitar_Prod_Maquina As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Enviar_Sel_Maquina As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Finalizar_Trabajo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Tiempo_Cierre_Automatico As Timer
    Friend WithEvents Btn_Ingresar_DFA_Manualmente As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Imagen_Barra As DevComponents.DotNetBar.Controls.ReflectionImage
    Friend WithEvents Chk_Preguntar_Cuantos_Fabricar As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Btn_Ingresar_DFA_Manualmente_Porcentaje As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Productos_En_Meson As DevComponents.DotNetBar.LabelX
    Public WithEvents Btn_Impirmir_ProdMeson As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Cmb_Mesones As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Btn_Info_Comercial As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Cambiar_Hora_Ingreso As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Lbl_Info_Linea As DevComponents.DotNetBar.LabelX
    Friend WithEvents Imagenes2_16x16 As ImageList
    Friend WithEvents Imagenes_32_32 As ImageList
End Class
