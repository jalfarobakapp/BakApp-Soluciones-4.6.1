<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Tickets_Mant
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Tickets_Mant))
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Txt_TidoNudoCierra = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Chk_ExigeDocCerrar = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Txt_AreaTipo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.Btn_VerProducto = New DevComponents.DotNetBar.ButtonX()
        Me.Menu_Contextual = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_01 = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_EditarFuncionario = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_QuitarVendedor = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_Productos = New DevComponents.DotNetBar.ButtonItem()
        Me.Lbl_OpcProducto = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Estadisticas_Producto = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Consolidar_Stock_X_Producto = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Copiar = New DevComponents.DotNetBar.ButtonItem()
        Me.Chk_ExigeProducto = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Txt_Agente = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Grupo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Rdb_AsignadoGrupo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Txt_Descripcion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Rdb_AsignadoAgente = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Asignado = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Txt_Asunto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Cmb_Prioridad = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Lbl_Descripcion = New DevComponents.DotNetBar.LabelX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Archivos_Adjuntos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Eliminar = New DevComponents.DotNetBar.ButtonItem()
        Me.Timer_CreaDesdeTicket = New System.Windows.Forms.Timer(Me.components)
        Me.GroupPanel2.SuspendLayout()
        CType(Me.Menu_Contextual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Txt_TidoNudoCierra)
        Me.GroupPanel2.Controls.Add(Me.Chk_ExigeDocCerrar)
        Me.GroupPanel2.Controls.Add(Me.Txt_AreaTipo)
        Me.GroupPanel2.Controls.Add(Me.LabelX10)
        Me.GroupPanel2.Controls.Add(Me.Btn_VerProducto)
        Me.GroupPanel2.Controls.Add(Me.Menu_Contextual)
        Me.GroupPanel2.Controls.Add(Me.Chk_ExigeProducto)
        Me.GroupPanel2.Controls.Add(Me.Txt_Agente)
        Me.GroupPanel2.Controls.Add(Me.Txt_Grupo)
        Me.GroupPanel2.Controls.Add(Me.Rdb_AsignadoGrupo)
        Me.GroupPanel2.Controls.Add(Me.Txt_Descripcion)
        Me.GroupPanel2.Controls.Add(Me.Rdb_AsignadoAgente)
        Me.GroupPanel2.Controls.Add(Me.Chk_Asignado)
        Me.GroupPanel2.Controls.Add(Me.Txt_Asunto)
        Me.GroupPanel2.Controls.Add(Me.LabelX3)
        Me.GroupPanel2.Controls.Add(Me.LabelX2)
        Me.GroupPanel2.Controls.Add(Me.Cmb_Prioridad)
        Me.GroupPanel2.Controls.Add(Me.Lbl_Descripcion)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(12, 3)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(631, 414)
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
        Me.GroupPanel2.TabIndex = 165
        Me.GroupPanel2.Text = "Datos del ticket"
        '
        'Txt_TidoNudoCierra
        '
        Me.Txt_TidoNudoCierra.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_TidoNudoCierra.Border.Class = "TextBoxBorder"
        Me.Txt_TidoNudoCierra.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_TidoNudoCierra.ButtonCustom.Image = CType(resources.GetObject("Txt_TidoNudoCierra.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_TidoNudoCierra.ButtonCustom.Visible = True
        Me.Txt_TidoNudoCierra.ButtonCustom2.Image = CType(resources.GetObject("Txt_TidoNudoCierra.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_TidoNudoCierra.ButtonCustom2.Visible = True
        Me.Txt_TidoNudoCierra.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_TidoNudoCierra.ForeColor = System.Drawing.Color.Black
        Me.Txt_TidoNudoCierra.Location = New System.Drawing.Point(422, 33)
        Me.Txt_TidoNudoCierra.Name = "Txt_TidoNudoCierra"
        Me.Txt_TidoNudoCierra.PreventEnterBeep = True
        Me.Txt_TidoNudoCierra.ReadOnly = True
        Me.Txt_TidoNudoCierra.Size = New System.Drawing.Size(200, 22)
        Me.Txt_TidoNudoCierra.TabIndex = 169
        Me.Txt_TidoNudoCierra.TabStop = False
        Me.Txt_TidoNudoCierra.Visible = False
        '
        'Chk_ExigeDocCerrar
        '
        Me.Chk_ExigeDocCerrar.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_ExigeDocCerrar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_ExigeDocCerrar.CheckBoxImageChecked = CType(resources.GetObject("Chk_ExigeDocCerrar.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_ExigeDocCerrar.FocusCuesEnabled = False
        Me.Chk_ExigeDocCerrar.ForeColor = System.Drawing.Color.Black
        Me.Chk_ExigeDocCerrar.Location = New System.Drawing.Point(305, 33)
        Me.Chk_ExigeDocCerrar.Name = "Chk_ExigeDocCerrar"
        Me.Chk_ExigeDocCerrar.Size = New System.Drawing.Size(111, 22)
        Me.Chk_ExigeDocCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_ExigeDocCerrar.TabIndex = 168
        Me.Chk_ExigeDocCerrar.TabStop = False
        Me.Chk_ExigeDocCerrar.Text = "Exige documento"
        Me.Chk_ExigeDocCerrar.Visible = False
        '
        'Txt_AreaTipo
        '
        Me.Txt_AreaTipo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_AreaTipo.Border.Class = "TextBoxBorder"
        Me.Txt_AreaTipo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_AreaTipo.ButtonCustom.Image = CType(resources.GetObject("Txt_AreaTipo.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_AreaTipo.ButtonCustom.Visible = True
        Me.Txt_AreaTipo.ButtonCustom2.Image = CType(resources.GetObject("Txt_AreaTipo.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_AreaTipo.ButtonCustom2.Visible = True
        Me.Txt_AreaTipo.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_AreaTipo.ForeColor = System.Drawing.Color.Black
        Me.Txt_AreaTipo.Location = New System.Drawing.Point(89, 5)
        Me.Txt_AreaTipo.Name = "Txt_AreaTipo"
        Me.Txt_AreaTipo.PreventEnterBeep = True
        Me.Txt_AreaTipo.ReadOnly = True
        Me.Txt_AreaTipo.Size = New System.Drawing.Size(533, 22)
        Me.Txt_AreaTipo.TabIndex = 166
        '
        'LabelX10
        '
        Me.LabelX10.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.ForeColor = System.Drawing.Color.Black
        Me.LabelX10.Location = New System.Drawing.Point(3, 2)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(80, 23)
        Me.LabelX10.TabIndex = 167
        Me.LabelX10.Text = "Area/Tipo"
        '
        'Btn_VerProducto
        '
        Me.Btn_VerProducto.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_VerProducto.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_VerProducto.Image = CType(resources.GetObject("Btn_VerProducto.Image"), System.Drawing.Image)
        Me.Btn_VerProducto.ImageAlt = CType(resources.GetObject("Btn_VerProducto.ImageAlt"), System.Drawing.Image)
        Me.Btn_VerProducto.Location = New System.Drawing.Point(188, 33)
        Me.Btn_VerProducto.Name = "Btn_VerProducto"
        Me.Btn_VerProducto.Size = New System.Drawing.Size(99, 22)
        Me.Btn_VerProducto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_VerProducto.TabIndex = 71
        Me.Btn_VerProducto.Text = "Ver producto"
        Me.Btn_VerProducto.Tooltip = "Ver datos del producto"
        '
        'Menu_Contextual
        '
        Me.Menu_Contextual.AntiAlias = True
        Me.Menu_Contextual.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Menu_Contextual.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_01, Me.Menu_Contextual_Productos})
        Me.Menu_Contextual.Location = New System.Drawing.Point(72, 199)
        Me.Menu_Contextual.Name = "Menu_Contextual"
        Me.Menu_Contextual.Size = New System.Drawing.Size(227, 25)
        Me.Menu_Contextual.Stretch = True
        Me.Menu_Contextual.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Menu_Contextual.TabIndex = 59
        Me.Menu_Contextual.TabStop = False
        Me.Menu_Contextual.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_01
        '
        Me.Menu_Contextual_01.AutoExpandOnClick = True
        Me.Menu_Contextual_01.Name = "Menu_Contextual_01"
        Me.Menu_Contextual_01.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_EditarFuncionario, Me.Btn_QuitarVendedor})
        Me.Menu_Contextual_01.Text = "Opciones"
        '
        'Btn_EditarFuncionario
        '
        Me.Btn_EditarFuncionario.Image = CType(resources.GetObject("Btn_EditarFuncionario.Image"), System.Drawing.Image)
        Me.Btn_EditarFuncionario.ImageAlt = CType(resources.GetObject("Btn_EditarFuncionario.ImageAlt"), System.Drawing.Image)
        Me.Btn_EditarFuncionario.Name = "Btn_EditarFuncionario"
        Me.Btn_EditarFuncionario.Text = "Editar funcionario"
        '
        'Btn_QuitarVendedor
        '
        Me.Btn_QuitarVendedor.Image = CType(resources.GetObject("Btn_QuitarVendedor.Image"), System.Drawing.Image)
        Me.Btn_QuitarVendedor.ImageAlt = CType(resources.GetObject("Btn_QuitarVendedor.ImageAlt"), System.Drawing.Image)
        Me.Btn_QuitarVendedor.Name = "Btn_QuitarVendedor"
        Me.Btn_QuitarVendedor.Text = "Quitar vendedor"
        '
        'Menu_Contextual_Productos
        '
        Me.Menu_Contextual_Productos.AutoExpandOnClick = True
        Me.Menu_Contextual_Productos.Name = "Menu_Contextual_Productos"
        Me.Menu_Contextual_Productos.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Lbl_OpcProducto, Me.Btn_Estadisticas_Producto, Me.Btn_Consolidar_Stock_X_Producto, Me.Btn_Copiar})
        Me.Menu_Contextual_Productos.Text = "Opciones productos"
        '
        'Lbl_OpcProducto
        '
        Me.Lbl_OpcProducto.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Lbl_OpcProducto.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.Lbl_OpcProducto.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.Lbl_OpcProducto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.Lbl_OpcProducto.Name = "Lbl_OpcProducto"
        Me.Lbl_OpcProducto.PaddingBottom = 1
        Me.Lbl_OpcProducto.PaddingLeft = 10
        Me.Lbl_OpcProducto.PaddingTop = 1
        Me.Lbl_OpcProducto.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.Lbl_OpcProducto.Text = "Opciones del producto"
        '
        'Btn_Estadisticas_Producto
        '
        Me.Btn_Estadisticas_Producto.Image = CType(resources.GetObject("Btn_Estadisticas_Producto.Image"), System.Drawing.Image)
        Me.Btn_Estadisticas_Producto.ImageAlt = CType(resources.GetObject("Btn_Estadisticas_Producto.ImageAlt"), System.Drawing.Image)
        Me.Btn_Estadisticas_Producto.Name = "Btn_Estadisticas_Producto"
        Me.Btn_Estadisticas_Producto.Text = "Ver estadísticas del producto/información adicional"
        '
        'Btn_Consolidar_Stock_X_Producto
        '
        Me.Btn_Consolidar_Stock_X_Producto.Image = CType(resources.GetObject("Btn_Consolidar_Stock_X_Producto.Image"), System.Drawing.Image)
        Me.Btn_Consolidar_Stock_X_Producto.ImageAlt = CType(resources.GetObject("Btn_Consolidar_Stock_X_Producto.ImageAlt"), System.Drawing.Image)
        Me.Btn_Consolidar_Stock_X_Producto.Name = "Btn_Consolidar_Stock_X_Producto"
        Me.Btn_Consolidar_Stock_X_Producto.Text = "Consolidar stock del producto"
        Me.Btn_Consolidar_Stock_X_Producto.Visible = False
        '
        'Btn_Copiar
        '
        Me.Btn_Copiar.Image = CType(resources.GetObject("Btn_Copiar.Image"), System.Drawing.Image)
        Me.Btn_Copiar.ImageAlt = CType(resources.GetObject("Btn_Copiar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Copiar.Name = "Btn_Copiar"
        Me.Btn_Copiar.Text = "Copiar (portapapeles)"
        '
        'Chk_ExigeProducto
        '
        Me.Chk_ExigeProducto.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_ExigeProducto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_ExigeProducto.CheckBoxImageChecked = CType(resources.GetObject("Chk_ExigeProducto.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_ExigeProducto.FocusCuesEnabled = False
        Me.Chk_ExigeProducto.ForeColor = System.Drawing.Color.Black
        Me.Chk_ExigeProducto.Location = New System.Drawing.Point(89, 33)
        Me.Chk_ExigeProducto.Name = "Chk_ExigeProducto"
        Me.Chk_ExigeProducto.Size = New System.Drawing.Size(93, 22)
        Me.Chk_ExigeProducto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_ExigeProducto.TabIndex = 57
        Me.Chk_ExigeProducto.TabStop = False
        Me.Chk_ExigeProducto.Text = "Exige producto"
        '
        'Txt_Agente
        '
        Me.Txt_Agente.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Agente.Border.Class = "TextBoxBorder"
        Me.Txt_Agente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Agente.ButtonCustom.Image = CType(resources.GetObject("Txt_Agente.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Agente.ButtonCustom.Visible = True
        Me.Txt_Agente.ButtonCustom2.Image = CType(resources.GetObject("Txt_Agente.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Agente.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Agente.ForeColor = System.Drawing.Color.Black
        Me.Txt_Agente.Location = New System.Drawing.Point(146, 361)
        Me.Txt_Agente.Name = "Txt_Agente"
        Me.Txt_Agente.PreventEnterBeep = True
        Me.Txt_Agente.ReadOnly = True
        Me.Txt_Agente.Size = New System.Drawing.Size(291, 22)
        Me.Txt_Agente.TabIndex = 11
        Me.Txt_Agente.TabStop = False
        '
        'Txt_Grupo
        '
        Me.Txt_Grupo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Grupo.Border.Class = "TextBoxBorder"
        Me.Txt_Grupo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Grupo.ButtonCustom.Image = CType(resources.GetObject("Txt_Grupo.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Grupo.ButtonCustom.Visible = True
        Me.Txt_Grupo.ButtonCustom2.Image = CType(resources.GetObject("Txt_Grupo.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Grupo.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Grupo.ForeColor = System.Drawing.Color.Black
        Me.Txt_Grupo.Location = New System.Drawing.Point(146, 332)
        Me.Txt_Grupo.Name = "Txt_Grupo"
        Me.Txt_Grupo.PreventEnterBeep = True
        Me.Txt_Grupo.ReadOnly = True
        Me.Txt_Grupo.Size = New System.Drawing.Size(291, 22)
        Me.Txt_Grupo.TabIndex = 9
        Me.Txt_Grupo.TabStop = False
        '
        'Rdb_AsignadoGrupo
        '
        Me.Rdb_AsignadoGrupo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_AsignadoGrupo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_AsignadoGrupo.CheckBoxImageChecked = CType(resources.GetObject("Rdb_AsignadoGrupo.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_AsignadoGrupo.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_AsignadoGrupo.FocusCuesEnabled = False
        Me.Rdb_AsignadoGrupo.ForeColor = System.Drawing.Color.Black
        Me.Rdb_AsignadoGrupo.Location = New System.Drawing.Point(3, 332)
        Me.Rdb_AsignadoGrupo.Name = "Rdb_AsignadoGrupo"
        Me.Rdb_AsignadoGrupo.Size = New System.Drawing.Size(137, 22)
        Me.Rdb_AsignadoGrupo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_AsignadoGrupo.TabIndex = 8
        Me.Rdb_AsignadoGrupo.TabStop = False
        Me.Rdb_AsignadoGrupo.Text = "Asignar a un grupo"
        '
        'Txt_Descripcion
        '
        Me.Txt_Descripcion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Descripcion.Border.Class = "TextBoxBorder"
        Me.Txt_Descripcion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Descripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Descripcion.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Descripcion.ForeColor = System.Drawing.Color.Black
        Me.Txt_Descripcion.Location = New System.Drawing.Point(3, 145)
        Me.Txt_Descripcion.MaxLength = 5000
        Me.Txt_Descripcion.Multiline = True
        Me.Txt_Descripcion.Name = "Txt_Descripcion"
        Me.Txt_Descripcion.PreventEnterBeep = True
        Me.Txt_Descripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Descripcion.Size = New System.Drawing.Size(619, 153)
        Me.Txt_Descripcion.TabIndex = 6
        '
        'Rdb_AsignadoAgente
        '
        Me.Rdb_AsignadoAgente.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_AsignadoAgente.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_AsignadoAgente.CheckBoxImageChecked = CType(resources.GetObject("Rdb_AsignadoAgente.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_AsignadoAgente.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_AsignadoAgente.FocusCuesEnabled = False
        Me.Rdb_AsignadoAgente.ForeColor = System.Drawing.Color.Black
        Me.Rdb_AsignadoAgente.Location = New System.Drawing.Point(3, 360)
        Me.Rdb_AsignadoAgente.Name = "Rdb_AsignadoAgente"
        Me.Rdb_AsignadoAgente.Size = New System.Drawing.Size(137, 22)
        Me.Rdb_AsignadoAgente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_AsignadoAgente.TabIndex = 10
        Me.Rdb_AsignadoAgente.TabStop = False
        Me.Rdb_AsignadoAgente.Text = "Asignar a un agente"
        '
        'Chk_Asignado
        '
        Me.Chk_Asignado.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Asignado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Asignado.CheckBoxImageChecked = CType(resources.GetObject("Chk_Asignado.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Asignado.FocusCuesEnabled = False
        Me.Chk_Asignado.ForeColor = System.Drawing.Color.Black
        Me.Chk_Asignado.Location = New System.Drawing.Point(3, 304)
        Me.Chk_Asignado.Name = "Chk_Asignado"
        Me.Chk_Asignado.Size = New System.Drawing.Size(187, 22)
        Me.Chk_Asignado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Asignado.TabIndex = 7
        Me.Chk_Asignado.TabStop = False
        Me.Chk_Asignado.Text = "ASIGNAR EL REQUERIMIENTO A:"
        '
        'Txt_Asunto
        '
        Me.Txt_Asunto.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Asunto.Border.Class = "TextBoxBorder"
        Me.Txt_Asunto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Asunto.ButtonCustom.Image = CType(resources.GetObject("Txt_Asunto.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Asunto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Asunto.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Asunto.ForeColor = System.Drawing.Color.Black
        Me.Txt_Asunto.Location = New System.Drawing.Point(89, 65)
        Me.Txt_Asunto.MaxLength = 50
        Me.Txt_Asunto.Name = "Txt_Asunto"
        Me.Txt_Asunto.PreventEnterBeep = True
        Me.Txt_Asunto.Size = New System.Drawing.Size(533, 22)
        Me.Txt_Asunto.TabIndex = 1
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(3, 64)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(80, 23)
        Me.LabelX3.TabIndex = 45
        Me.LabelX3.Text = "Asunto"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 93)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(80, 23)
        Me.LabelX2.TabIndex = 44
        Me.LabelX2.Text = "Prioridad"
        '
        'Cmb_Prioridad
        '
        Me.Cmb_Prioridad.DisplayMember = "Text"
        Me.Cmb_Prioridad.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Prioridad.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Cmb_Prioridad.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Prioridad.ItemHeight = 16
        Me.Cmb_Prioridad.Location = New System.Drawing.Point(89, 94)
        Me.Cmb_Prioridad.Name = "Cmb_Prioridad"
        Me.Cmb_Prioridad.Size = New System.Drawing.Size(137, 22)
        Me.Cmb_Prioridad.TabIndex = 2
        '
        'Lbl_Descripcion
        '
        Me.Lbl_Descripcion.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Descripcion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Descripcion.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Descripcion.Location = New System.Drawing.Point(3, 122)
        Me.Lbl_Descripcion.Name = "Lbl_Descripcion"
        Me.Lbl_Descripcion.Size = New System.Drawing.Size(80, 23)
        Me.Lbl_Descripcion.TabIndex = 51
        Me.Lbl_Descripcion.Text = "Descripción"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar, Me.Btn_Archivos_Adjuntos, Me.Btn_Eliminar})
        Me.Bar2.Location = New System.Drawing.Point(0, 435)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(655, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 164
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.ImageAlt = CType(resources.GetObject("Btn_Grabar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Tooltip = "Grabar"
        '
        'Btn_Archivos_Adjuntos
        '
        Me.Btn_Archivos_Adjuntos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Archivos_Adjuntos.ForeColor = System.Drawing.Color.Black
        Me.Btn_Archivos_Adjuntos.Image = CType(resources.GetObject("Btn_Archivos_Adjuntos.Image"), System.Drawing.Image)
        Me.Btn_Archivos_Adjuntos.ImageAlt = CType(resources.GetObject("Btn_Archivos_Adjuntos.ImageAlt"), System.Drawing.Image)
        Me.Btn_Archivos_Adjuntos.Name = "Btn_Archivos_Adjuntos"
        Me.Btn_Archivos_Adjuntos.Tooltip = "Adjuntar archivos"
        '
        'Btn_Eliminar
        '
        Me.Btn_Eliminar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Eliminar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Eliminar.Image = CType(resources.GetObject("Btn_Eliminar.Image"), System.Drawing.Image)
        Me.Btn_Eliminar.ImageAlt = CType(resources.GetObject("Btn_Eliminar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Eliminar.Name = "Btn_Eliminar"
        Me.Btn_Eliminar.Tooltip = "Anular Ticket"
        Me.Btn_Eliminar.Visible = False
        '
        'Timer_CreaDesdeTicket
        '
        Me.Timer_CreaDesdeTicket.Interval = 1000
        '
        'Frm_Tickets_Mant
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(655, 476)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.Bar2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Tickets_Mant"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MANTENCION DE TICKET"
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.Menu_Contextual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Rdb_AsignadoGrupo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Eliminar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Txt_Asunto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Public WithEvents Cmb_Prioridad As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Lbl_Descripcion As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Descripcion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Rdb_AsignadoAgente As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Asignado As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Txt_Agente As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Grupo As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Btn_Archivos_Adjuntos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Chk_ExigeProducto As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Menu_Contextual As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_01 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_EditarFuncionario As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_QuitarVendedor As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Menu_Contextual_Productos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Lbl_OpcProducto As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Estadisticas_Producto As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Consolidar_Stock_X_Producto As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Copiar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_VerProducto As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Txt_AreaTipo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Timer_CreaDesdeTicket As Timer
    Friend WithEvents Txt_TidoNudoCierra As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Chk_ExigeDocCerrar As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
