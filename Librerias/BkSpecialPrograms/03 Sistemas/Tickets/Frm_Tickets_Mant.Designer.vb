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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Tickets_Mant))
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
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
        Me.Lbl_Descripcion = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_AsignadoGrupo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Txt_Descripcion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Rdb_AsignadoAgente = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Txt_Tipo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Chk_Asignado = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Txt_Area = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Asunto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Cmb_Prioridad = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Txt_CodFuncionario_Crea = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Cantidad = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Stf = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Bodega = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.Btn_OpcProducto = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_Producto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Lbl_Producto = New DevComponents.DotNetBar.LabelX()
        Me.Cmb_UdMedida = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Lbl_LUnimulti = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_FechaRev = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Archivos_Adjuntos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Eliminar = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.Menu_Contextual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_FechaRev, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Menu_Contextual)
        Me.GroupPanel2.Controls.Add(Me.Chk_ExigeProducto)
        Me.GroupPanel2.Controls.Add(Me.Txt_Agente)
        Me.GroupPanel2.Controls.Add(Me.Txt_Grupo)
        Me.GroupPanel2.Controls.Add(Me.Lbl_Descripcion)
        Me.GroupPanel2.Controls.Add(Me.Rdb_AsignadoGrupo)
        Me.GroupPanel2.Controls.Add(Me.Txt_Descripcion)
        Me.GroupPanel2.Controls.Add(Me.Rdb_AsignadoAgente)
        Me.GroupPanel2.Controls.Add(Me.Txt_Tipo)
        Me.GroupPanel2.Controls.Add(Me.Chk_Asignado)
        Me.GroupPanel2.Controls.Add(Me.Txt_Area)
        Me.GroupPanel2.Controls.Add(Me.LabelX5)
        Me.GroupPanel2.Controls.Add(Me.LabelX4)
        Me.GroupPanel2.Controls.Add(Me.Txt_Asunto)
        Me.GroupPanel2.Controls.Add(Me.LabelX3)
        Me.GroupPanel2.Controls.Add(Me.LabelX2)
        Me.GroupPanel2.Controls.Add(Me.Cmb_Prioridad)
        Me.GroupPanel2.Controls.Add(Me.Txt_CodFuncionario_Crea)
        Me.GroupPanel2.Controls.Add(Me.LabelX1)
        Me.GroupPanel2.Controls.Add(Me.Txt_Cantidad)
        Me.GroupPanel2.Controls.Add(Me.LabelX9)
        Me.GroupPanel2.Controls.Add(Me.Txt_Stf)
        Me.GroupPanel2.Controls.Add(Me.LabelX8)
        Me.GroupPanel2.Controls.Add(Me.Txt_Bodega)
        Me.GroupPanel2.Controls.Add(Me.LabelX7)
        Me.GroupPanel2.Controls.Add(Me.Btn_OpcProducto)
        Me.GroupPanel2.Controls.Add(Me.Txt_Producto)
        Me.GroupPanel2.Controls.Add(Me.Lbl_Producto)
        Me.GroupPanel2.Controls.Add(Me.Cmb_UdMedida)
        Me.GroupPanel2.Controls.Add(Me.Lbl_LUnimulti)
        Me.GroupPanel2.Controls.Add(Me.LabelX6)
        Me.GroupPanel2.Controls.Add(Me.Dtp_FechaRev)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(12, 3)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(560, 516)
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
        'Menu_Contextual
        '
        Me.Menu_Contextual.AntiAlias = True
        Me.Menu_Contextual.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Menu_Contextual.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_01, Me.Menu_Contextual_Productos})
        Me.Menu_Contextual.Location = New System.Drawing.Point(72, 298)
        Me.Menu_Contextual.Name = "Menu_Contextual"
        Me.Menu_Contextual.Size = New System.Drawing.Size(411, 25)
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
        Me.Chk_ExigeProducto.Location = New System.Drawing.Point(386, 122)
        Me.Chk_ExigeProducto.Name = "Chk_ExigeProducto"
        Me.Chk_ExigeProducto.Size = New System.Drawing.Size(165, 22)
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
        Me.Txt_Agente.ButtonCustom2.Visible = True
        Me.Txt_Agente.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Agente.ForeColor = System.Drawing.Color.Black
        Me.Txt_Agente.Location = New System.Drawing.Point(146, 460)
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
        Me.Txt_Grupo.ButtonCustom2.Visible = True
        Me.Txt_Grupo.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Grupo.ForeColor = System.Drawing.Color.Black
        Me.Txt_Grupo.Location = New System.Drawing.Point(146, 431)
        Me.Txt_Grupo.Name = "Txt_Grupo"
        Me.Txt_Grupo.PreventEnterBeep = True
        Me.Txt_Grupo.ReadOnly = True
        Me.Txt_Grupo.Size = New System.Drawing.Size(291, 22)
        Me.Txt_Grupo.TabIndex = 9
        Me.Txt_Grupo.TabStop = False
        '
        'Lbl_Descripcion
        '
        Me.Lbl_Descripcion.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Descripcion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Descripcion.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Descripcion.Location = New System.Drawing.Point(3, 248)
        Me.Lbl_Descripcion.Name = "Lbl_Descripcion"
        Me.Lbl_Descripcion.Size = New System.Drawing.Size(80, 23)
        Me.Lbl_Descripcion.TabIndex = 51
        Me.Lbl_Descripcion.Text = "Descripción"
        '
        'Rdb_AsignadoGrupo
        '
        Me.Rdb_AsignadoGrupo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_AsignadoGrupo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_AsignadoGrupo.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_AsignadoGrupo.FocusCuesEnabled = False
        Me.Rdb_AsignadoGrupo.ForeColor = System.Drawing.Color.Black
        Me.Rdb_AsignadoGrupo.Location = New System.Drawing.Point(3, 431)
        Me.Rdb_AsignadoGrupo.Name = "Rdb_AsignadoGrupo"
        Me.Rdb_AsignadoGrupo.Size = New System.Drawing.Size(125, 23)
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
        Me.Txt_Descripcion.Location = New System.Drawing.Point(3, 275)
        Me.Txt_Descripcion.MaxLength = 200
        Me.Txt_Descripcion.Multiline = True
        Me.Txt_Descripcion.Name = "Txt_Descripcion"
        Me.Txt_Descripcion.PreventEnterBeep = True
        Me.Txt_Descripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Descripcion.Size = New System.Drawing.Size(548, 122)
        Me.Txt_Descripcion.TabIndex = 6
        '
        'Rdb_AsignadoAgente
        '
        Me.Rdb_AsignadoAgente.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_AsignadoAgente.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_AsignadoAgente.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_AsignadoAgente.FocusCuesEnabled = False
        Me.Rdb_AsignadoAgente.ForeColor = System.Drawing.Color.Black
        Me.Rdb_AsignadoAgente.Location = New System.Drawing.Point(3, 459)
        Me.Rdb_AsignadoAgente.Name = "Rdb_AsignadoAgente"
        Me.Rdb_AsignadoAgente.Size = New System.Drawing.Size(137, 23)
        Me.Rdb_AsignadoAgente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_AsignadoAgente.TabIndex = 10
        Me.Rdb_AsignadoAgente.TabStop = False
        Me.Rdb_AsignadoAgente.Text = "Asignar a un agente"
        '
        'Txt_Tipo
        '
        Me.Txt_Tipo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Tipo.Border.Class = "TextBoxBorder"
        Me.Txt_Tipo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Tipo.ButtonCustom.Image = CType(resources.GetObject("Txt_Tipo.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Tipo.ButtonCustom.Visible = True
        Me.Txt_Tipo.ButtonCustom2.Image = CType(resources.GetObject("Txt_Tipo.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Tipo.ButtonCustom2.Visible = True
        Me.Txt_Tipo.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Tipo.ForeColor = System.Drawing.Color.Black
        Me.Txt_Tipo.Location = New System.Drawing.Point(89, 121)
        Me.Txt_Tipo.Name = "Txt_Tipo"
        Me.Txt_Tipo.PreventEnterBeep = True
        Me.Txt_Tipo.ReadOnly = True
        Me.Txt_Tipo.Size = New System.Drawing.Size(291, 22)
        Me.Txt_Tipo.TabIndex = 4
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
        Me.Chk_Asignado.Location = New System.Drawing.Point(3, 403)
        Me.Chk_Asignado.Name = "Chk_Asignado"
        Me.Chk_Asignado.Size = New System.Drawing.Size(187, 22)
        Me.Chk_Asignado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Asignado.TabIndex = 7
        Me.Chk_Asignado.TabStop = False
        Me.Chk_Asignado.Text = "ASIGNAR EL REQUERIMINETO A:"
        '
        'Txt_Area
        '
        Me.Txt_Area.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Area.Border.Class = "TextBoxBorder"
        Me.Txt_Area.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Area.ButtonCustom.Image = CType(resources.GetObject("Txt_Area.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Area.ButtonCustom.Visible = True
        Me.Txt_Area.ButtonCustom2.Image = CType(resources.GetObject("Txt_Area.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Area.ButtonCustom2.Visible = True
        Me.Txt_Area.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Area.ForeColor = System.Drawing.Color.Black
        Me.Txt_Area.Location = New System.Drawing.Point(89, 92)
        Me.Txt_Area.Name = "Txt_Area"
        Me.Txt_Area.PreventEnterBeep = True
        Me.Txt_Area.ReadOnly = True
        Me.Txt_Area.Size = New System.Drawing.Size(291, 22)
        Me.Txt_Area.TabIndex = 3
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(3, 118)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(80, 23)
        Me.LabelX5.TabIndex = 49
        Me.LabelX5.Text = "Tipo"
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(3, 89)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(80, 23)
        Me.LabelX4.TabIndex = 47
        Me.LabelX4.Text = "Area"
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
        Me.Txt_Asunto.ButtonCustom.Visible = True
        Me.Txt_Asunto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Asunto.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Asunto.ForeColor = System.Drawing.Color.Black
        Me.Txt_Asunto.Location = New System.Drawing.Point(89, 32)
        Me.Txt_Asunto.MaxLength = 50
        Me.Txt_Asunto.Name = "Txt_Asunto"
        Me.Txt_Asunto.PreventEnterBeep = True
        Me.Txt_Asunto.Size = New System.Drawing.Size(462, 22)
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
        Me.LabelX3.Location = New System.Drawing.Point(3, 31)
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
        Me.LabelX2.Location = New System.Drawing.Point(3, 60)
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
        Me.Cmb_Prioridad.Location = New System.Drawing.Point(89, 61)
        Me.Cmb_Prioridad.Name = "Cmb_Prioridad"
        Me.Cmb_Prioridad.Size = New System.Drawing.Size(137, 22)
        Me.Cmb_Prioridad.TabIndex = 2
        '
        'Txt_CodFuncionario_Crea
        '
        Me.Txt_CodFuncionario_Crea.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_CodFuncionario_Crea.Border.Class = "TextBoxBorder"
        Me.Txt_CodFuncionario_Crea.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_CodFuncionario_Crea.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_CodFuncionario_Crea.ForeColor = System.Drawing.Color.Black
        Me.Txt_CodFuncionario_Crea.Location = New System.Drawing.Point(89, 4)
        Me.Txt_CodFuncionario_Crea.MaxLength = 30
        Me.Txt_CodFuncionario_Crea.Name = "Txt_CodFuncionario_Crea"
        Me.Txt_CodFuncionario_Crea.PreventEnterBeep = True
        Me.Txt_CodFuncionario_Crea.ReadOnly = True
        Me.Txt_CodFuncionario_Crea.Size = New System.Drawing.Size(462, 22)
        Me.Txt_CodFuncionario_Crea.TabIndex = 0
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(80, 23)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "Solicitado por:"
        '
        'Txt_Cantidad
        '
        Me.Txt_Cantidad.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Cantidad.Border.Class = "TextBoxBorder"
        Me.Txt_Cantidad.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Cantidad.ButtonCustom.Image = CType(resources.GetObject("Txt_Cantidad.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Cantidad.ButtonCustom2.Image = CType(resources.GetObject("Txt_Cantidad.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Cantidad.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Cantidad.ForeColor = System.Drawing.Color.Black
        Me.Txt_Cantidad.Location = New System.Drawing.Point(241, 215)
        Me.Txt_Cantidad.Name = "Txt_Cantidad"
        Me.Txt_Cantidad.PreventEnterBeep = True
        Me.Txt_Cantidad.Size = New System.Drawing.Size(51, 22)
        Me.Txt_Cantidad.TabIndex = 65
        Me.Txt_Cantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelX9
        '
        Me.LabelX9.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.ForeColor = System.Drawing.Color.Black
        Me.LabelX9.Location = New System.Drawing.Point(146, 214)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(89, 23)
        Me.LabelX9.TabIndex = 64
        Me.LabelX9.Text = "Cant. inventariada"
        '
        'Txt_Stf
        '
        Me.Txt_Stf.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Stf.Border.Class = "TextBoxBorder"
        Me.Txt_Stf.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Stf.ButtonCustom.Image = CType(resources.GetObject("Txt_Stf.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Stf.ButtonCustom2.Image = CType(resources.GetObject("Txt_Stf.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Stf.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Stf.ForeColor = System.Drawing.Color.Black
        Me.Txt_Stf.Location = New System.Drawing.Point(89, 214)
        Me.Txt_Stf.Name = "Txt_Stf"
        Me.Txt_Stf.PreventEnterBeep = True
        Me.Txt_Stf.Size = New System.Drawing.Size(51, 22)
        Me.Txt_Stf.TabIndex = 63
        Me.Txt_Stf.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelX8
        '
        Me.LabelX8.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.ForeColor = System.Drawing.Color.Black
        Me.LabelX8.Location = New System.Drawing.Point(3, 214)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(89, 23)
        Me.LabelX8.TabIndex = 62
        Me.LabelX8.Text = "Cant. en bodega"
        '
        'Txt_Bodega
        '
        Me.Txt_Bodega.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Bodega.Border.Class = "TextBoxBorder"
        Me.Txt_Bodega.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Bodega.ButtonCustom.Image = CType(resources.GetObject("Txt_Bodega.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Bodega.ButtonCustom.Visible = True
        Me.Txt_Bodega.ButtonCustom2.Image = CType(resources.GetObject("Txt_Bodega.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Bodega.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Bodega.ForeColor = System.Drawing.Color.Black
        Me.Txt_Bodega.Location = New System.Drawing.Point(89, 186)
        Me.Txt_Bodega.Name = "Txt_Bodega"
        Me.Txt_Bodega.PreventEnterBeep = True
        Me.Txt_Bodega.ReadOnly = True
        Me.Txt_Bodega.Size = New System.Drawing.Size(303, 22)
        Me.Txt_Bodega.TabIndex = 61
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.ForeColor = System.Drawing.Color.Black
        Me.LabelX7.Location = New System.Drawing.Point(3, 186)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(80, 23)
        Me.LabelX7.TabIndex = 60
        Me.LabelX7.Text = "Bodega"
        '
        'Btn_OpcProducto
        '
        Me.Btn_OpcProducto.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_OpcProducto.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_OpcProducto.Image = CType(resources.GetObject("Btn_OpcProducto.Image"), System.Drawing.Image)
        Me.Btn_OpcProducto.ImageAlt = CType(resources.GetObject("Btn_OpcProducto.ImageAlt"), System.Drawing.Image)
        Me.Btn_OpcProducto.Location = New System.Drawing.Point(523, 158)
        Me.Btn_OpcProducto.Name = "Btn_OpcProducto"
        Me.Btn_OpcProducto.Size = New System.Drawing.Size(28, 22)
        Me.Btn_OpcProducto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_OpcProducto.TabIndex = 58
        '
        'Txt_Producto
        '
        Me.Txt_Producto.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Producto.Border.Class = "TextBoxBorder"
        Me.Txt_Producto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Producto.ButtonCustom.Image = CType(resources.GetObject("Txt_Producto.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Producto.ButtonCustom.Visible = True
        Me.Txt_Producto.ButtonCustom2.Image = CType(resources.GetObject("Txt_Producto.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Producto.ButtonCustom2.Visible = True
        Me.Txt_Producto.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Producto.Enabled = False
        Me.Txt_Producto.ForeColor = System.Drawing.Color.Black
        Me.Txt_Producto.Location = New System.Drawing.Point(89, 158)
        Me.Txt_Producto.Name = "Txt_Producto"
        Me.Txt_Producto.PreventEnterBeep = True
        Me.Txt_Producto.ReadOnly = True
        Me.Txt_Producto.Size = New System.Drawing.Size(428, 22)
        Me.Txt_Producto.TabIndex = 5
        '
        'Lbl_Producto
        '
        Me.Lbl_Producto.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Producto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Producto.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Producto.Location = New System.Drawing.Point(3, 157)
        Me.Lbl_Producto.Name = "Lbl_Producto"
        Me.Lbl_Producto.Size = New System.Drawing.Size(80, 23)
        Me.Lbl_Producto.TabIndex = 53
        Me.Lbl_Producto.Text = "Producto"
        '
        'Cmb_UdMedida
        '
        Me.Cmb_UdMedida.DisplayMember = "Text"
        Me.Cmb_UdMedida.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_UdMedida.ForeColor = System.Drawing.Color.Black
        Me.Cmb_UdMedida.FormattingEnabled = True
        Me.Cmb_UdMedida.ItemHeight = 16
        Me.Cmb_UdMedida.Location = New System.Drawing.Point(446, 187)
        Me.Cmb_UdMedida.Name = "Cmb_UdMedida"
        Me.Cmb_UdMedida.Size = New System.Drawing.Size(52, 22)
        Me.Cmb_UdMedida.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_UdMedida.TabIndex = 70
        '
        'Lbl_LUnimulti
        '
        Me.Lbl_LUnimulti.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_LUnimulti.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_LUnimulti.ForeColor = System.Drawing.Color.Black
        Me.Lbl_LUnimulti.Location = New System.Drawing.Point(400, 186)
        Me.Lbl_LUnimulti.Name = "Lbl_LUnimulti"
        Me.Lbl_LUnimulti.Size = New System.Drawing.Size(40, 23)
        Me.Lbl_LUnimulti.TabIndex = 69
        Me.Lbl_LUnimulti.Text = "Unidad"
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(314, 214)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(89, 23)
        Me.LabelX6.TabIndex = 67
        Me.LabelX6.Text = "Fecha de revisión"
        '
        'Dtp_FechaRev
        '
        Me.Dtp_FechaRev.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_FechaRev.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_FechaRev.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaRev.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_FechaRev.ButtonDropDown.Visible = True
        Me.Dtp_FechaRev.ForeColor = System.Drawing.Color.Black
        Me.Dtp_FechaRev.IsPopupCalendarOpen = False
        Me.Dtp_FechaRev.Location = New System.Drawing.Point(409, 214)
        '
        '
        '
        Me.Dtp_FechaRev.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FechaRev.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaRev.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_FechaRev.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_FechaRev.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_FechaRev.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FechaRev.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_FechaRev.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_FechaRev.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_FechaRev.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_FechaRev.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaRev.MonthCalendar.DisplayMonth = New Date(2023, 12, 1, 0, 0, 0, 0)
        Me.Dtp_FechaRev.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_FechaRev.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_FechaRev.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FechaRev.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_FechaRev.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FechaRev.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_FechaRev.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaRev.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_FechaRev.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_FechaRev.Name = "Dtp_FechaRev"
        Me.Dtp_FechaRev.Size = New System.Drawing.Size(89, 22)
        Me.Dtp_FechaRev.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_FechaRev.TabIndex = 66
        Me.Dtp_FechaRev.Value = New Date(2023, 12, 15, 16, 11, 43, 0)
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar, Me.Btn_Archivos_Adjuntos, Me.Btn_Eliminar})
        Me.Bar2.Location = New System.Drawing.Point(0, 525)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(584, 41)
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
        'Frm_Tickets_Mant
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 566)
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
        CType(Me.Dtp_FechaRev, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Rdb_AsignadoGrupo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Txt_CodFuncionario_Crea As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Eliminar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Txt_Asunto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Public WithEvents Cmb_Prioridad As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Lbl_Descripcion As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Descripcion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_AsignadoAgente As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Asignado As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Txt_Tipo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Area As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Agente As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Grupo As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Btn_Archivos_Adjuntos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Txt_Producto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Lbl_Producto As DevComponents.DotNetBar.LabelX
    Friend WithEvents Chk_ExigeProducto As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Btn_OpcProducto As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Menu_Contextual As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_01 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_EditarFuncionario As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_QuitarVendedor As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Menu_Contextual_Productos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Lbl_OpcProducto As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Estadisticas_Producto As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Consolidar_Stock_X_Producto As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Copiar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Txt_Stf As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Bodega As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Cantidad As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dtp_FechaRev As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Public WithEvents Cmb_UdMedida As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Lbl_LUnimulti As DevComponents.DotNetBar.LabelX
End Class
