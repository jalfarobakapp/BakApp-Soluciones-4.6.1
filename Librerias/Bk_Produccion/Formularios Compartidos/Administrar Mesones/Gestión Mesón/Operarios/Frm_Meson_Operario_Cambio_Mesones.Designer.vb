<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Meson_Operario_Cambio_Mesones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Meson_Operario_Cambio_Mesones))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Grupo_Izquierda = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_Meson = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Agregar_Producto_Maquina = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Enviar_Meson_Siguiente = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Agregar_Observaciones = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_Maquina = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Poducto_Fabricado = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Avence_Porcentaje = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Problemas_Maquina = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Solo_Quitar_Prod_Maquina = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla_Izquierda = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Grupo_Derecha = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Grilla_Derecha = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Actualizar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Cambiar_de_Izquierda_a_derecha = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Cambiar_de_Derecha_a_izquierda = New DevComponents.DotNetBar.ButtonX()
        Me.Lbl_Producto_Izquierda = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Producto_Derecha = New DevComponents.DotNetBar.LabelX()
        Me.Grupo_Izquierda.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla_Izquierda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_Derecha.SuspendLayout()
        CType(Me.Grilla_Derecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Grupo_Izquierda
        '
        Me.Grupo_Izquierda.BackColor = System.Drawing.Color.White
        Me.Grupo_Izquierda.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Izquierda.Controls.Add(Me.ContextMenuBar1)
        Me.Grupo_Izquierda.Controls.Add(Me.Grilla_Izquierda)
        Me.Grupo_Izquierda.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Izquierda.Location = New System.Drawing.Point(12, 12)
        Me.Grupo_Izquierda.Name = "Grupo_Izquierda"
        Me.Grupo_Izquierda.Size = New System.Drawing.Size(460, 390)
        '
        '
        '
        Me.Grupo_Izquierda.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Izquierda.Style.BackColorGradientAngle = 90
        Me.Grupo_Izquierda.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Izquierda.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Izquierda.Style.BorderBottomWidth = 1
        Me.Grupo_Izquierda.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Izquierda.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Izquierda.Style.BorderLeftWidth = 1
        Me.Grupo_Izquierda.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Izquierda.Style.BorderRightWidth = 1
        Me.Grupo_Izquierda.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Izquierda.Style.BorderTopWidth = 1
        Me.Grupo_Izquierda.Style.CornerDiameter = 4
        Me.Grupo_Izquierda.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Izquierda.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Izquierda.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Izquierda.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Izquierda.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Izquierda.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Izquierda.TabIndex = 99
        Me.Grupo_Izquierda.Text = "PRODUCTOS EN ESPERA EN EL MESON"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_Meson, Me.Menu_Contextual_Maquina})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(53, 58)
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
        Me.Menu_Contextual_Meson.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Mnu_Agregar_Producto_Maquina, Me.Btn_Enviar_Meson_Siguiente, Me.Btn_Agregar_Observaciones})
        Me.Menu_Contextual_Meson.Text = "Meson"
        '
        'Btn_Mnu_Agregar_Producto_Maquina
        '
        Me.Btn_Mnu_Agregar_Producto_Maquina.Image = CType(resources.GetObject("Btn_Mnu_Agregar_Producto_Maquina.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Agregar_Producto_Maquina.Name = "Btn_Mnu_Agregar_Producto_Maquina"
        Me.Btn_Mnu_Agregar_Producto_Maquina.Text = "Enviar producto a la maquina"
        '
        'Btn_Enviar_Meson_Siguiente
        '
        Me.Btn_Enviar_Meson_Siguiente.Image = CType(resources.GetObject("Btn_Enviar_Meson_Siguiente.Image"), System.Drawing.Image)
        Me.Btn_Enviar_Meson_Siguiente.Name = "Btn_Enviar_Meson_Siguiente"
        Me.Btn_Enviar_Meson_Siguiente.Text = "Enviar producto al mesón siguiente"
        '
        'Btn_Agregar_Observaciones
        '
        Me.Btn_Agregar_Observaciones.Image = CType(resources.GetObject("Btn_Agregar_Observaciones.Image"), System.Drawing.Image)
        Me.Btn_Agregar_Observaciones.Name = "Btn_Agregar_Observaciones"
        Me.Btn_Agregar_Observaciones.Text = "Agregar observaciones"
        '
        'Menu_Contextual_Maquina
        '
        Me.Menu_Contextual_Maquina.AutoExpandOnClick = True
        Me.Menu_Contextual_Maquina.Name = "Menu_Contextual_Maquina"
        Me.Menu_Contextual_Maquina.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Poducto_Fabricado, Me.Btn_Avence_Porcentaje, Me.Btn_Problemas_Maquina, Me.Btn_Solo_Quitar_Prod_Maquina, Me.ButtonItem1})
        Me.Menu_Contextual_Maquina.Text = "Maquinas"
        '
        'Btn_Poducto_Fabricado
        '
        Me.Btn_Poducto_Fabricado.Image = CType(resources.GetObject("Btn_Poducto_Fabricado.Image"), System.Drawing.Image)
        Me.Btn_Poducto_Fabricado.Name = "Btn_Poducto_Fabricado"
        Me.Btn_Poducto_Fabricado.Text = "Productos fabricados completamente"
        '
        'Btn_Avence_Porcentaje
        '
        Me.Btn_Avence_Porcentaje.Image = CType(resources.GetObject("Btn_Avence_Porcentaje.Image"), System.Drawing.Image)
        Me.Btn_Avence_Porcentaje.Name = "Btn_Avence_Porcentaje"
        Me.Btn_Avence_Porcentaje.Text = "Ingresar solo % de avance de fabricación"
        '
        'Btn_Problemas_Maquina
        '
        Me.Btn_Problemas_Maquina.Image = CType(resources.GetObject("Btn_Problemas_Maquina.Image"), System.Drawing.Image)
        Me.Btn_Problemas_Maquina.Name = "Btn_Problemas_Maquina"
        Me.Btn_Problemas_Maquina.Text = "Quitar producto de la maquina (problemas en la fabricación)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Btn_Solo_Quitar_Prod_Maquina
        '
        Me.Btn_Solo_Quitar_Prod_Maquina.Image = CType(resources.GetObject("Btn_Solo_Quitar_Prod_Maquina.Image"), System.Drawing.Image)
        Me.Btn_Solo_Quitar_Prod_Maquina.Name = "Btn_Solo_Quitar_Prod_Maquina"
        Me.Btn_Solo_Quitar_Prod_Maquina.Text = "Quitar producto de la maquina (asignado por error)"
        '
        'ButtonItem1
        '
        Me.ButtonItem1.Image = CType(resources.GetObject("ButtonItem1.Image"), System.Drawing.Image)
        Me.ButtonItem1.Name = "ButtonItem1"
        Me.ButtonItem1.Text = "Agregar observaciones"
        '
        'Grilla_Izquierda
        '
        Me.Grilla_Izquierda.AllowUserToAddRows = False
        Me.Grilla_Izquierda.AllowUserToDeleteRows = False
        Me.Grilla_Izquierda.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Izquierda.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grilla_Izquierda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Izquierda.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grilla_Izquierda.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Izquierda.EnableHeadersVisualStyles = False
        Me.Grilla_Izquierda.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Izquierda.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Izquierda.MultiSelect = False
        Me.Grilla_Izquierda.Name = "Grilla_Izquierda"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Izquierda.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla_Izquierda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grilla_Izquierda.Size = New System.Drawing.Size(454, 367)
        Me.Grilla_Izquierda.TabIndex = 1
        '
        'Grupo_Derecha
        '
        Me.Grupo_Derecha.BackColor = System.Drawing.Color.White
        Me.Grupo_Derecha.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Derecha.Controls.Add(Me.Grilla_Derecha)
        Me.Grupo_Derecha.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Derecha.Location = New System.Drawing.Point(544, 12)
        Me.Grupo_Derecha.Name = "Grupo_Derecha"
        Me.Grupo_Derecha.Size = New System.Drawing.Size(460, 390)
        '
        '
        '
        Me.Grupo_Derecha.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Derecha.Style.BackColorGradientAngle = 90
        Me.Grupo_Derecha.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Derecha.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Derecha.Style.BorderBottomWidth = 1
        Me.Grupo_Derecha.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Derecha.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Derecha.Style.BorderLeftWidth = 1
        Me.Grupo_Derecha.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Derecha.Style.BorderRightWidth = 1
        Me.Grupo_Derecha.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Derecha.Style.BorderTopWidth = 1
        Me.Grupo_Derecha.Style.CornerDiameter = 4
        Me.Grupo_Derecha.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Derecha.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Derecha.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Derecha.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Derecha.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Derecha.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Derecha.TabIndex = 100
        Me.Grupo_Derecha.Text = "PRODUCTOS EN ESPERA EN EL MESON"
        '
        'Grilla_Derecha
        '
        Me.Grilla_Derecha.AllowUserToAddRows = False
        Me.Grilla_Derecha.AllowUserToDeleteRows = False
        Me.Grilla_Derecha.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Derecha.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Grilla_Derecha.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Derecha.DefaultCellStyle = DataGridViewCellStyle5
        Me.Grilla_Derecha.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Derecha.EnableHeadersVisualStyles = False
        Me.Grilla_Derecha.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Derecha.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Derecha.MultiSelect = False
        Me.Grilla_Derecha.Name = "Grilla_Derecha"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Derecha.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Grilla_Derecha.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grilla_Derecha.Size = New System.Drawing.Size(454, 367)
        Me.Grilla_Derecha.TabIndex = 1
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Actualizar})
        Me.Bar1.Location = New System.Drawing.Point(0, 452)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(1014, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 101
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
        Me.Btn_Actualizar.Tooltip = "Actualizar"
        '
        'Btn_Cambiar_de_Izquierda_a_derecha
        '
        Me.Btn_Cambiar_de_Izquierda_a_derecha.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Cambiar_de_Izquierda_a_derecha.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Cambiar_de_Izquierda_a_derecha.Image = CType(resources.GetObject("Btn_Cambiar_de_Izquierda_a_derecha.Image"), System.Drawing.Image)
        Me.Btn_Cambiar_de_Izquierda_a_derecha.Location = New System.Drawing.Point(478, 90)
        Me.Btn_Cambiar_de_Izquierda_a_derecha.Name = "Btn_Cambiar_de_Izquierda_a_derecha"
        Me.Btn_Cambiar_de_Izquierda_a_derecha.Size = New System.Drawing.Size(60, 37)
        Me.Btn_Cambiar_de_Izquierda_a_derecha.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Cambiar_de_Izquierda_a_derecha.TabIndex = 102
        '
        'Btn_Cambiar_de_Derecha_a_izquierda
        '
        Me.Btn_Cambiar_de_Derecha_a_izquierda.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Cambiar_de_Derecha_a_izquierda.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Cambiar_de_Derecha_a_izquierda.Image = CType(resources.GetObject("Btn_Cambiar_de_Derecha_a_izquierda.Image"), System.Drawing.Image)
        Me.Btn_Cambiar_de_Derecha_a_izquierda.Location = New System.Drawing.Point(477, 200)
        Me.Btn_Cambiar_de_Derecha_a_izquierda.Name = "Btn_Cambiar_de_Derecha_a_izquierda"
        Me.Btn_Cambiar_de_Derecha_a_izquierda.Size = New System.Drawing.Size(60, 37)
        Me.Btn_Cambiar_de_Derecha_a_izquierda.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Cambiar_de_Derecha_a_izquierda.TabIndex = 103
        '
        'Lbl_Producto_Izquierda
        '
        Me.Lbl_Producto_Izquierda.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Producto_Izquierda.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Producto_Izquierda.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Producto_Izquierda.Location = New System.Drawing.Point(12, 408)
        Me.Lbl_Producto_Izquierda.Name = "Lbl_Producto_Izquierda"
        Me.Lbl_Producto_Izquierda.Size = New System.Drawing.Size(460, 23)
        Me.Lbl_Producto_Izquierda.TabIndex = 104
        Me.Lbl_Producto_Izquierda.Text = "."
        '
        'Lbl_Producto_Derecha
        '
        Me.Lbl_Producto_Derecha.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Producto_Derecha.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Producto_Derecha.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Producto_Derecha.Location = New System.Drawing.Point(544, 408)
        Me.Lbl_Producto_Derecha.Name = "Lbl_Producto_Derecha"
        Me.Lbl_Producto_Derecha.Size = New System.Drawing.Size(460, 23)
        Me.Lbl_Producto_Derecha.TabIndex = 105
        Me.Lbl_Producto_Derecha.Text = "."
        '
        'Frm_Meson_Operario_Cambio_Mesones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1014, 493)
        Me.Controls.Add(Me.Lbl_Producto_Derecha)
        Me.Controls.Add(Me.Lbl_Producto_Izquierda)
        Me.Controls.Add(Me.Btn_Cambiar_de_Derecha_a_izquierda)
        Me.Controls.Add(Me.Btn_Cambiar_de_Izquierda_a_derecha)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.Grupo_Derecha)
        Me.Controls.Add(Me.Grupo_Izquierda)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Meson_Operario_Cambio_Mesones"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "INTERCAMBIO DE PRODUCTO ENTRE MESONES"
        Me.Grupo_Izquierda.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla_Izquierda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo_Derecha.ResumeLayout(False)
        CType(Me.Grilla_Derecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Grupo_Izquierda As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_Meson As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_Agregar_Producto_Maquina As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Enviar_Meson_Siguiente As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Agregar_Observaciones As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Menu_Contextual_Maquina As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Poducto_Fabricado As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Avence_Porcentaje As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Problemas_Maquina As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Solo_Quitar_Prod_Maquina As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grilla_Izquierda As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Grupo_Derecha As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grilla_Derecha As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Public WithEvents Btn_Actualizar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Cambiar_de_Izquierda_a_derecha As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Cambiar_de_Derecha_a_izquierda As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Lbl_Producto_Izquierda As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Producto_Derecha As DevComponents.DotNetBar.LabelX
End Class
