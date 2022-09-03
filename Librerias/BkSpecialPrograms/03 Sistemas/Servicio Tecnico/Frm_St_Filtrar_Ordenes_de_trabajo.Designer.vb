<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_St_Filtrar_Ordenes_de_trabajo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_St_Filtrar_Ordenes_de_trabajo))
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.BtnFiltrar = New DevComponents.DotNetBar.ButtonItem()
        Me.Txt_Nro_OT = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Grupo_Entidad = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_Estados_Algunos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Estados_Todas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_Tecnico_Repara_Algunos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Tecnico_Repara_Todos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_Tecnico_Asignado_Algunos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Tecnico_Asignado_Todos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_Entidades_Algunas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Entidades_Todas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_Orden_de_trabajo_Todas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Orden_de_trabajo_Una = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.Dtp_Fecha_Cierre_Hasta = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Lbl_FC_hasta = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_Fecha_Cierre_Desde = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_Fecha_Cierre_Rango = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Fecha_Cierre_Todas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Lbl_FC_desde = New DevComponents.DotNetBar.LabelX()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Dtp_Fecha_Emision_Hasta = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Lbl_FE_hasta = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_Fecha_Emision_Desde = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Rdb_Fecha_Emision_Rango = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Fecha_Emision_Todas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Lbl_FE_desde = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Imagenes_32x32 = New System.Windows.Forms.ImageList(Me.components)
        Me.TableLayoutPanel8 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_Manquina_Algunas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Manquina_Todas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TableLayoutPanel9 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_Modelo_Algunos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Modelo_Todos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TableLayoutPanel10 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_Marca_Algunas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Marca_Todas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TableLayoutPanel11 = New System.Windows.Forms.TableLayoutPanel()
        Me.Txt_Nro_Serie = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.Grupo_OT = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Grupo_Fechas = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Grupo_Maquina = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TableLayoutPanel14 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_Productos_Algunos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Productos_Todos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TableLayoutPanel12 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_Categoria_Algunas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Categoria_Todas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Grupo_Chk_Tipo_Reparacion = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TableLayoutPanel13 = New System.Windows.Forms.TableLayoutPanel()
        Me.Chk_Serv_Demostracion_Maquina = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Serv_Garantia = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Serv_Mantenimiento_Preventivo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Serv_Recoleccion = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Serv_Presupuesto_Pre_Aprobado = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Serv_Mantenimiento_Correctivo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Serv_Reparacion_Stock = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Serv_Domicilio = New DevComponents.DotNetBar.Controls.CheckBoxX()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_Entidad.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel7.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        CType(Me.Dtp_Fecha_Cierre_Hasta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_Fecha_Cierre_Desde, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.Dtp_Fecha_Emision_Hasta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_Fecha_Emision_Desde, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel8.SuspendLayout()
        Me.TableLayoutPanel9.SuspendLayout()
        Me.TableLayoutPanel10.SuspendLayout()
        Me.TableLayoutPanel11.SuspendLayout()
        Me.Grupo_OT.SuspendLayout()
        Me.Grupo_Fechas.SuspendLayout()
        Me.Grupo_Maquina.SuspendLayout()
        Me.TableLayoutPanel14.SuspendLayout()
        Me.TableLayoutPanel12.SuspendLayout()
        Me.Grupo_Chk_Tipo_Reparacion.SuspendLayout()
        Me.TableLayoutPanel13.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnFiltrar})
        Me.Bar1.Location = New System.Drawing.Point(0, 498)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(743, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 71
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnFiltrar
        '
        Me.BtnFiltrar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnFiltrar.ForeColor = System.Drawing.Color.Black
        Me.BtnFiltrar.Image = CType(resources.GetObject("BtnFiltrar.Image"), System.Drawing.Image)
        Me.BtnFiltrar.Name = "BtnFiltrar"
        Me.BtnFiltrar.Text = "Aplicar filtro"
        '
        'Txt_Nro_OT
        '
        Me.Txt_Nro_OT.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Nro_OT.Border.Class = "TextBoxBorder"
        Me.Txt_Nro_OT.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Nro_OT.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Nro_OT.FocusHighlightEnabled = True
        Me.Txt_Nro_OT.ForeColor = System.Drawing.Color.Black
        Me.Txt_Nro_OT.Location = New System.Drawing.Point(285, 3)
        Me.Txt_Nro_OT.MaxLength = 10
        Me.Txt_Nro_OT.Name = "Txt_Nro_OT"
        Me.Txt_Nro_OT.PreventEnterBeep = True
        Me.Txt_Nro_OT.Size = New System.Drawing.Size(100, 22)
        Me.Txt_Nro_OT.TabIndex = 22
        Me.Txt_Nro_OT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Grupo_Entidad
        '
        Me.Grupo_Entidad.BackColor = System.Drawing.Color.White
        Me.Grupo_Entidad.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Entidad.Controls.Add(Me.TableLayoutPanel5)
        Me.Grupo_Entidad.Controls.Add(Me.TableLayoutPanel4)
        Me.Grupo_Entidad.Controls.Add(Me.TableLayoutPanel3)
        Me.Grupo_Entidad.Controls.Add(Me.TableLayoutPanel2)
        Me.Grupo_Entidad.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Entidad.Location = New System.Drawing.Point(12, 86)
        Me.Grupo_Entidad.Name = "Grupo_Entidad"
        Me.Grupo_Entidad.Size = New System.Drawing.Size(356, 201)
        '
        '
        '
        Me.Grupo_Entidad.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Entidad.Style.BackColorGradientAngle = 90
        Me.Grupo_Entidad.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Entidad.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Entidad.Style.BorderBottomWidth = 1
        Me.Grupo_Entidad.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Entidad.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Entidad.Style.BorderLeftWidth = 1
        Me.Grupo_Entidad.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Entidad.Style.BorderRightWidth = 1
        Me.Grupo_Entidad.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Entidad.Style.BorderTopWidth = 1
        Me.Grupo_Entidad.Style.CornerDiameter = 4
        Me.Grupo_Entidad.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Entidad.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Entidad.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Entidad.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Entidad.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Entidad.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Entidad.TabIndex = 74
        Me.Grupo_Entidad.Text = "Filtros Entidades, Técnicos y Estados"
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel5.ColumnCount = 3
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.LabelX6, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Rdb_Estados_Algunos, 2, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Rdb_Estados_Todas, 1, 0)
        Me.TableLayoutPanel5.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(3, 96)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 1
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(339, 25)
        Me.TableLayoutPanel5.TabIndex = 5
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(3, 3)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(131, 19)
        Me.LabelX6.TabIndex = 4
        Me.LabelX6.Text = "Estados"
        '
        'Rdb_Estados_Algunos
        '
        Me.Rdb_Estados_Algunos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Estados_Algunos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Estados_Algunos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Estados_Algunos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Estados_Algunos.Location = New System.Drawing.Point(231, 3)
        Me.Rdb_Estados_Algunos.Name = "Rdb_Estados_Algunos"
        Me.Rdb_Estados_Algunos.Size = New System.Drawing.Size(94, 19)
        Me.Rdb_Estados_Algunos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Estados_Algunos.TabIndex = 3
        Me.Rdb_Estados_Algunos.Text = "Algunos"
        '
        'Rdb_Estados_Todas
        '
        Me.Rdb_Estados_Todas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Estados_Todas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Estados_Todas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Estados_Todas.Checked = True
        Me.Rdb_Estados_Todas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Estados_Todas.CheckValue = "Y"
        Me.Rdb_Estados_Todas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Estados_Todas.Location = New System.Drawing.Point(140, 3)
        Me.Rdb_Estados_Todas.Name = "Rdb_Estados_Todas"
        Me.Rdb_Estados_Todas.Size = New System.Drawing.Size(85, 19)
        Me.Rdb_Estados_Todas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Estados_Todas.TabIndex = 1
        Me.Rdb_Estados_Todas.Text = "Todos"
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel4.ColumnCount = 3
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.LabelX3, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Rdb_Tecnico_Repara_Algunos, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Rdb_Tecnico_Repara_Todos, 1, 0)
        Me.TableLayoutPanel4.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(3, 65)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(339, 25)
        Me.TableLayoutPanel4.TabIndex = 4
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(3, 3)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(131, 19)
        Me.LabelX3.TabIndex = 4
        Me.LabelX3.Text = "Técnico/Taller Repara"
        '
        'Rdb_Tecnico_Repara_Algunos
        '
        Me.Rdb_Tecnico_Repara_Algunos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Tecnico_Repara_Algunos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Tecnico_Repara_Algunos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Tecnico_Repara_Algunos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Tecnico_Repara_Algunos.Location = New System.Drawing.Point(231, 3)
        Me.Rdb_Tecnico_Repara_Algunos.Name = "Rdb_Tecnico_Repara_Algunos"
        Me.Rdb_Tecnico_Repara_Algunos.Size = New System.Drawing.Size(94, 19)
        Me.Rdb_Tecnico_Repara_Algunos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Tecnico_Repara_Algunos.TabIndex = 3
        Me.Rdb_Tecnico_Repara_Algunos.Text = "Algunos"
        '
        'Rdb_Tecnico_Repara_Todos
        '
        Me.Rdb_Tecnico_Repara_Todos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Tecnico_Repara_Todos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Tecnico_Repara_Todos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Tecnico_Repara_Todos.Checked = True
        Me.Rdb_Tecnico_Repara_Todos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Tecnico_Repara_Todos.CheckValue = "Y"
        Me.Rdb_Tecnico_Repara_Todos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Tecnico_Repara_Todos.Location = New System.Drawing.Point(140, 3)
        Me.Rdb_Tecnico_Repara_Todos.Name = "Rdb_Tecnico_Repara_Todos"
        Me.Rdb_Tecnico_Repara_Todos.Size = New System.Drawing.Size(85, 19)
        Me.Rdb_Tecnico_Repara_Todos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Tecnico_Repara_Todos.TabIndex = 1
        Me.Rdb_Tecnico_Repara_Todos.Text = "Todos"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel3.ColumnCount = 3
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.LabelX2, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Rdb_Tecnico_Asignado_Algunos, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Rdb_Tecnico_Asignado_Todos, 1, 0)
        Me.TableLayoutPanel3.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 37)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(339, 25)
        Me.TableLayoutPanel3.TabIndex = 3
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 3)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(131, 19)
        Me.LabelX2.TabIndex = 4
        Me.LabelX2.Text = "Técnico/Taller Asignado"
        '
        'Rdb_Tecnico_Asignado_Algunos
        '
        Me.Rdb_Tecnico_Asignado_Algunos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Tecnico_Asignado_Algunos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Tecnico_Asignado_Algunos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Tecnico_Asignado_Algunos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Tecnico_Asignado_Algunos.Location = New System.Drawing.Point(231, 3)
        Me.Rdb_Tecnico_Asignado_Algunos.Name = "Rdb_Tecnico_Asignado_Algunos"
        Me.Rdb_Tecnico_Asignado_Algunos.Size = New System.Drawing.Size(94, 19)
        Me.Rdb_Tecnico_Asignado_Algunos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Tecnico_Asignado_Algunos.TabIndex = 3
        Me.Rdb_Tecnico_Asignado_Algunos.Text = "Algunos"
        '
        'Rdb_Tecnico_Asignado_Todos
        '
        Me.Rdb_Tecnico_Asignado_Todos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Tecnico_Asignado_Todos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Tecnico_Asignado_Todos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Tecnico_Asignado_Todos.Checked = True
        Me.Rdb_Tecnico_Asignado_Todos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Tecnico_Asignado_Todos.CheckValue = "Y"
        Me.Rdb_Tecnico_Asignado_Todos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Tecnico_Asignado_Todos.Location = New System.Drawing.Point(140, 3)
        Me.Rdb_Tecnico_Asignado_Todos.Name = "Rdb_Tecnico_Asignado_Todos"
        Me.Rdb_Tecnico_Asignado_Todos.Size = New System.Drawing.Size(85, 19)
        Me.Rdb_Tecnico_Asignado_Todos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Tecnico_Asignado_Todos.TabIndex = 1
        Me.Rdb_Tecnico_Asignado_Todos.Text = "Todas "
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.LabelX1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Rdb_Entidades_Algunas, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Rdb_Entidades_Todas, 1, 0)
        Me.TableLayoutPanel2.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 9)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(339, 25)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(131, 19)
        Me.LabelX1.TabIndex = 4
        Me.LabelX1.Text = "Clientes / Entidades "
        '
        'Rdb_Entidades_Algunas
        '
        Me.Rdb_Entidades_Algunas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Entidades_Algunas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Entidades_Algunas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Entidades_Algunas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Entidades_Algunas.Location = New System.Drawing.Point(231, 3)
        Me.Rdb_Entidades_Algunas.Name = "Rdb_Entidades_Algunas"
        Me.Rdb_Entidades_Algunas.Size = New System.Drawing.Size(94, 19)
        Me.Rdb_Entidades_Algunas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Entidades_Algunas.TabIndex = 3
        Me.Rdb_Entidades_Algunas.Text = "Algunos"
        '
        'Rdb_Entidades_Todas
        '
        Me.Rdb_Entidades_Todas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Entidades_Todas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Entidades_Todas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Entidades_Todas.Checked = True
        Me.Rdb_Entidades_Todas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Entidades_Todas.CheckValue = "Y"
        Me.Rdb_Entidades_Todas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Entidades_Todas.Location = New System.Drawing.Point(140, 3)
        Me.Rdb_Entidades_Todas.Name = "Rdb_Entidades_Todas"
        Me.Rdb_Entidades_Todas.Size = New System.Drawing.Size(85, 19)
        Me.Rdb_Entidades_Todas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Entidades_Todas.TabIndex = 1
        Me.Rdb_Entidades_Todas.Text = "Todos"
        '
        'TableLayoutPanel7
        '
        Me.TableLayoutPanel7.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel7.ColumnCount = 4
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 162.0!))
        Me.TableLayoutPanel7.Controls.Add(Me.LabelX11, 0, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.Txt_Nro_OT, 3, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.Rdb_Orden_de_trabajo_Todas, 1, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.Rdb_Orden_de_trabajo_Una, 2, 0)
        Me.TableLayoutPanel7.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel7.Location = New System.Drawing.Point(6, 12)
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        Me.TableLayoutPanel7.RowCount = 1
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel7.Size = New System.Drawing.Size(444, 28)
        Me.TableLayoutPanel7.TabIndex = 23
        '
        'LabelX11
        '
        '
        '
        '
        Me.LabelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX11.ForeColor = System.Drawing.Color.Black
        Me.LabelX11.Location = New System.Drawing.Point(3, 3)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(131, 19)
        Me.LabelX11.TabIndex = 4
        Me.LabelX11.Text = "Ordenes de trabajo"
        '
        'Rdb_Orden_de_trabajo_Todas
        '
        Me.Rdb_Orden_de_trabajo_Todas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Orden_de_trabajo_Todas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Orden_de_trabajo_Todas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Orden_de_trabajo_Todas.Checked = True
        Me.Rdb_Orden_de_trabajo_Todas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Orden_de_trabajo_Todas.CheckValue = "Y"
        Me.Rdb_Orden_de_trabajo_Todas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Orden_de_trabajo_Todas.Location = New System.Drawing.Point(140, 3)
        Me.Rdb_Orden_de_trabajo_Todas.Name = "Rdb_Orden_de_trabajo_Todas"
        Me.Rdb_Orden_de_trabajo_Todas.Size = New System.Drawing.Size(85, 19)
        Me.Rdb_Orden_de_trabajo_Todas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Orden_de_trabajo_Todas.TabIndex = 1
        Me.Rdb_Orden_de_trabajo_Todas.Text = "Todos"
        '
        'Rdb_Orden_de_trabajo_Una
        '
        Me.Rdb_Orden_de_trabajo_Una.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Orden_de_trabajo_Una.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Orden_de_trabajo_Una.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Orden_de_trabajo_Una.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Orden_de_trabajo_Una.Location = New System.Drawing.Point(232, 3)
        Me.Rdb_Orden_de_trabajo_Una.Name = "Rdb_Orden_de_trabajo_Una"
        Me.Rdb_Orden_de_trabajo_Una.Size = New System.Drawing.Size(47, 19)
        Me.Rdb_Orden_de_trabajo_Una.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Orden_de_trabajo_Una.TabIndex = 3
        Me.Rdb_Orden_de_trabajo_Una.Text = "Una"
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel6.ColumnCount = 7
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 164.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.Dtp_Fecha_Cierre_Hasta, 6, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.Lbl_FC_hasta, 5, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.Dtp_Fecha_Cierre_Desde, 4, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.LabelX9, 0, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.Rdb_Fecha_Cierre_Rango, 2, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.Rdb_Fecha_Cierre_Todas, 1, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.Lbl_FC_desde, 3, 0)
        Me.TableLayoutPanel6.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(3, 44)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 1
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(566, 25)
        Me.TableLayoutPanel6.TabIndex = 7
        '
        'Dtp_Fecha_Cierre_Hasta
        '
        '
        '
        '
        Me.Dtp_Fecha_Cierre_Hasta.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Cierre_Hasta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Cierre_Hasta.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Cierre_Hasta.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Cierre_Hasta.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Cierre_Hasta.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Cierre_Hasta.Location = New System.Drawing.Point(405, 3)
        '
        '
        '
        Me.Dtp_Fecha_Cierre_Hasta.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Cierre_Hasta.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Cierre_Hasta.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Cierre_Hasta.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Cierre_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Cierre_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Cierre_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Cierre_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Cierre_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Cierre_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Cierre_Hasta.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Cierre_Hasta.MonthCalendar.DisplayMonth = New Date(2016, 7, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Cierre_Hasta.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Cierre_Hasta.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Cierre_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Cierre_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Cierre_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Cierre_Hasta.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Cierre_Hasta.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Cierre_Hasta.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Cierre_Hasta.Name = "Dtp_Fecha_Cierre_Hasta"
        Me.Dtp_Fecha_Cierre_Hasta.Size = New System.Drawing.Size(80, 22)
        Me.Dtp_Fecha_Cierre_Hasta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Cierre_Hasta.TabIndex = 8
        Me.Dtp_Fecha_Cierre_Hasta.Value = New Date(2016, 7, 8, 16, 42, 49, 0)
        '
        'Lbl_FC_hasta
        '
        '
        '
        '
        Me.Lbl_FC_hasta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_FC_hasta.ForeColor = System.Drawing.Color.Black
        Me.Lbl_FC_hasta.Location = New System.Drawing.Point(365, 3)
        Me.Lbl_FC_hasta.Name = "Lbl_FC_hasta"
        Me.Lbl_FC_hasta.Size = New System.Drawing.Size(34, 19)
        Me.Lbl_FC_hasta.TabIndex = 9
        Me.Lbl_FC_hasta.Text = "Desde"
        '
        'Dtp_Fecha_Cierre_Desde
        '
        '
        '
        '
        Me.Dtp_Fecha_Cierre_Desde.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Cierre_Desde.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Cierre_Desde.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Cierre_Desde.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Cierre_Desde.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Cierre_Desde.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Cierre_Desde.Location = New System.Drawing.Point(278, 3)
        '
        '
        '
        Me.Dtp_Fecha_Cierre_Desde.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Cierre_Desde.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Cierre_Desde.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Cierre_Desde.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Cierre_Desde.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Cierre_Desde.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Cierre_Desde.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Cierre_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Cierre_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Cierre_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Cierre_Desde.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Cierre_Desde.MonthCalendar.DisplayMonth = New Date(2016, 7, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Cierre_Desde.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Cierre_Desde.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Cierre_Desde.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Cierre_Desde.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Cierre_Desde.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Cierre_Desde.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Cierre_Desde.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Cierre_Desde.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Cierre_Desde.Name = "Dtp_Fecha_Cierre_Desde"
        Me.Dtp_Fecha_Cierre_Desde.Size = New System.Drawing.Size(80, 22)
        Me.Dtp_Fecha_Cierre_Desde.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Cierre_Desde.TabIndex = 7
        Me.Dtp_Fecha_Cierre_Desde.Value = New Date(2016, 7, 8, 16, 42, 41, 0)
        '
        'LabelX9
        '
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.ForeColor = System.Drawing.Color.Black
        Me.LabelX9.Location = New System.Drawing.Point(3, 3)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(95, 19)
        Me.LabelX9.TabIndex = 4
        Me.LabelX9.Text = "Fecha de cierre"
        '
        'Rdb_Fecha_Cierre_Rango
        '
        Me.Rdb_Fecha_Cierre_Rango.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Fecha_Cierre_Rango.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Fecha_Cierre_Rango.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Fecha_Cierre_Rango.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Fecha_Cierre_Rango.Location = New System.Drawing.Point(166, 3)
        Me.Rdb_Fecha_Cierre_Rango.Name = "Rdb_Fecha_Cierre_Rango"
        Me.Rdb_Fecha_Cierre_Rango.Size = New System.Drawing.Size(56, 19)
        Me.Rdb_Fecha_Cierre_Rango.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Fecha_Cierre_Rango.TabIndex = 3
        Me.Rdb_Fecha_Cierre_Rango.Text = "Rango"
        '
        'Rdb_Fecha_Cierre_Todas
        '
        Me.Rdb_Fecha_Cierre_Todas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Fecha_Cierre_Todas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Fecha_Cierre_Todas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Fecha_Cierre_Todas.Checked = True
        Me.Rdb_Fecha_Cierre_Todas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Fecha_Cierre_Todas.CheckValue = "Y"
        Me.Rdb_Fecha_Cierre_Todas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Fecha_Cierre_Todas.Location = New System.Drawing.Point(104, 3)
        Me.Rdb_Fecha_Cierre_Todas.Name = "Rdb_Fecha_Cierre_Todas"
        Me.Rdb_Fecha_Cierre_Todas.Size = New System.Drawing.Size(56, 19)
        Me.Rdb_Fecha_Cierre_Todas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Fecha_Cierre_Todas.TabIndex = 1
        Me.Rdb_Fecha_Cierre_Todas.Text = "Todas"
        '
        'Lbl_FC_desde
        '
        '
        '
        '
        Me.Lbl_FC_desde.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_FC_desde.ForeColor = System.Drawing.Color.Black
        Me.Lbl_FC_desde.Location = New System.Drawing.Point(228, 3)
        Me.Lbl_FC_desde.Name = "Lbl_FC_desde"
        Me.Lbl_FC_desde.Size = New System.Drawing.Size(37, 19)
        Me.Lbl_FC_desde.TabIndex = 7
        Me.Lbl_FC_desde.Text = "Desde"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 7
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 165.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Dtp_Fecha_Emision_Hasta, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_FE_hasta, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Dtp_Fecha_Emision_Desde, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_Fecha_Emision_Rango, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_Fecha_Emision_Todas, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_FE_desde, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX4, 0, 0)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 13)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(566, 25)
        Me.TableLayoutPanel1.TabIndex = 6
        '
        'Dtp_Fecha_Emision_Hasta
        '
        '
        '
        '
        Me.Dtp_Fecha_Emision_Hasta.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Emision_Hasta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Emision_Hasta.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Emision_Hasta.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Emision_Hasta.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Emision_Hasta.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Emision_Hasta.Location = New System.Drawing.Point(404, 3)
        '
        '
        '
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.DisplayMonth = New Date(2016, 7, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Emision_Hasta.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Emision_Hasta.Name = "Dtp_Fecha_Emision_Hasta"
        Me.Dtp_Fecha_Emision_Hasta.Size = New System.Drawing.Size(81, 22)
        Me.Dtp_Fecha_Emision_Hasta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Emision_Hasta.TabIndex = 8
        Me.Dtp_Fecha_Emision_Hasta.Value = New Date(2016, 7, 8, 16, 33, 0, 0)
        '
        'Lbl_FE_hasta
        '
        '
        '
        '
        Me.Lbl_FE_hasta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_FE_hasta.ForeColor = System.Drawing.Color.Black
        Me.Lbl_FE_hasta.Location = New System.Drawing.Point(364, 3)
        Me.Lbl_FE_hasta.Name = "Lbl_FE_hasta"
        Me.Lbl_FE_hasta.Size = New System.Drawing.Size(34, 19)
        Me.Lbl_FE_hasta.TabIndex = 9
        Me.Lbl_FE_hasta.Text = "Hasta"
        '
        'Dtp_Fecha_Emision_Desde
        '
        '
        '
        '
        Me.Dtp_Fecha_Emision_Desde.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Emision_Desde.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Emision_Desde.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Emision_Desde.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Emision_Desde.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Emision_Desde.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Emision_Desde.Location = New System.Drawing.Point(278, 3)
        '
        '
        '
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.DisplayMonth = New Date(2016, 7, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Emision_Desde.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Emision_Desde.Name = "Dtp_Fecha_Emision_Desde"
        Me.Dtp_Fecha_Emision_Desde.Size = New System.Drawing.Size(79, 22)
        Me.Dtp_Fecha_Emision_Desde.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Emision_Desde.TabIndex = 7
        Me.Dtp_Fecha_Emision_Desde.Value = New Date(2016, 7, 8, 16, 32, 31, 0)
        '
        'Rdb_Fecha_Emision_Rango
        '
        Me.Rdb_Fecha_Emision_Rango.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Fecha_Emision_Rango.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Fecha_Emision_Rango.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Fecha_Emision_Rango.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Fecha_Emision_Rango.Location = New System.Drawing.Point(166, 3)
        Me.Rdb_Fecha_Emision_Rango.Name = "Rdb_Fecha_Emision_Rango"
        Me.Rdb_Fecha_Emision_Rango.Size = New System.Drawing.Size(58, 19)
        Me.Rdb_Fecha_Emision_Rango.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Fecha_Emision_Rango.TabIndex = 3
        Me.Rdb_Fecha_Emision_Rango.Text = "Rango"
        '
        'Rdb_Fecha_Emision_Todas
        '
        Me.Rdb_Fecha_Emision_Todas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Fecha_Emision_Todas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Fecha_Emision_Todas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Fecha_Emision_Todas.Checked = True
        Me.Rdb_Fecha_Emision_Todas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Fecha_Emision_Todas.CheckValue = "Y"
        Me.Rdb_Fecha_Emision_Todas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Fecha_Emision_Todas.Location = New System.Drawing.Point(104, 3)
        Me.Rdb_Fecha_Emision_Todas.Name = "Rdb_Fecha_Emision_Todas"
        Me.Rdb_Fecha_Emision_Todas.Size = New System.Drawing.Size(56, 19)
        Me.Rdb_Fecha_Emision_Todas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Fecha_Emision_Todas.TabIndex = 1
        Me.Rdb_Fecha_Emision_Todas.Text = "Todas"
        '
        'Lbl_FE_desde
        '
        '
        '
        '
        Me.Lbl_FE_desde.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_FE_desde.ForeColor = System.Drawing.Color.Black
        Me.Lbl_FE_desde.Location = New System.Drawing.Point(230, 3)
        Me.Lbl_FE_desde.Name = "Lbl_FE_desde"
        Me.Lbl_FE_desde.Size = New System.Drawing.Size(38, 19)
        Me.Lbl_FE_desde.TabIndex = 7
        Me.Lbl_FE_desde.Text = "Desde"
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(3, 3)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(95, 19)
        Me.LabelX4.TabIndex = 4
        Me.LabelX4.Text = "Fecha de emisión"
        '
        'Imagenes_32x32
        '
        Me.Imagenes_32x32.ImageStream = CType(resources.GetObject("Imagenes_32x32.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagenes_32x32.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagenes_32x32.Images.SetKeyName(0, "Delete")
        Me.Imagenes_32x32.Images.SetKeyName(1, "Warning")
        '
        'TableLayoutPanel8
        '
        Me.TableLayoutPanel8.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel8.ColumnCount = 3
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91.0!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111.0!))
        Me.TableLayoutPanel8.Controls.Add(Me.LabelX5, 0, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.Rdb_Manquina_Algunas, 2, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.Rdb_Manquina_Todas, 1, 0)
        Me.TableLayoutPanel8.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel8.Location = New System.Drawing.Point(5, 34)
        Me.TableLayoutPanel8.Name = "TableLayoutPanel8"
        Me.TableLayoutPanel8.RowCount = 1
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel8.Size = New System.Drawing.Size(339, 25)
        Me.TableLayoutPanel8.TabIndex = 24
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(3, 3)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(131, 19)
        Me.LabelX5.TabIndex = 4
        Me.LabelX5.Text = "Maquina"
        '
        'Rdb_Manquina_Algunas
        '
        Me.Rdb_Manquina_Algunas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Manquina_Algunas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Manquina_Algunas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Manquina_Algunas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Manquina_Algunas.Location = New System.Drawing.Point(231, 3)
        Me.Rdb_Manquina_Algunas.Name = "Rdb_Manquina_Algunas"
        Me.Rdb_Manquina_Algunas.Size = New System.Drawing.Size(94, 19)
        Me.Rdb_Manquina_Algunas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Manquina_Algunas.TabIndex = 3
        Me.Rdb_Manquina_Algunas.Text = "Algunas"
        '
        'Rdb_Manquina_Todas
        '
        Me.Rdb_Manquina_Todas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Manquina_Todas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Manquina_Todas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Manquina_Todas.Checked = True
        Me.Rdb_Manquina_Todas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Manquina_Todas.CheckValue = "Y"
        Me.Rdb_Manquina_Todas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Manquina_Todas.Location = New System.Drawing.Point(140, 3)
        Me.Rdb_Manquina_Todas.Name = "Rdb_Manquina_Todas"
        Me.Rdb_Manquina_Todas.Size = New System.Drawing.Size(85, 19)
        Me.Rdb_Manquina_Todas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Manquina_Todas.TabIndex = 1
        Me.Rdb_Manquina_Todas.Text = "Todas"
        '
        'TableLayoutPanel9
        '
        Me.TableLayoutPanel9.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel9.ColumnCount = 3
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91.0!))
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111.0!))
        Me.TableLayoutPanel9.Controls.Add(Me.LabelX7, 0, 0)
        Me.TableLayoutPanel9.Controls.Add(Me.Rdb_Modelo_Algunos, 2, 0)
        Me.TableLayoutPanel9.Controls.Add(Me.Rdb_Modelo_Todos, 1, 0)
        Me.TableLayoutPanel9.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel9.Location = New System.Drawing.Point(5, 90)
        Me.TableLayoutPanel9.Name = "TableLayoutPanel9"
        Me.TableLayoutPanel9.RowCount = 1
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel9.Size = New System.Drawing.Size(339, 25)
        Me.TableLayoutPanel9.TabIndex = 25
        '
        'LabelX7
        '
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.ForeColor = System.Drawing.Color.Black
        Me.LabelX7.Location = New System.Drawing.Point(3, 3)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(131, 19)
        Me.LabelX7.TabIndex = 4
        Me.LabelX7.Text = "Modelo"
        '
        'Rdb_Modelo_Algunos
        '
        Me.Rdb_Modelo_Algunos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Modelo_Algunos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Modelo_Algunos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Modelo_Algunos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Modelo_Algunos.Location = New System.Drawing.Point(231, 3)
        Me.Rdb_Modelo_Algunos.Name = "Rdb_Modelo_Algunos"
        Me.Rdb_Modelo_Algunos.Size = New System.Drawing.Size(94, 19)
        Me.Rdb_Modelo_Algunos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Modelo_Algunos.TabIndex = 3
        Me.Rdb_Modelo_Algunos.Text = "Algunos"
        '
        'Rdb_Modelo_Todos
        '
        Me.Rdb_Modelo_Todos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Modelo_Todos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Modelo_Todos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Modelo_Todos.Checked = True
        Me.Rdb_Modelo_Todos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Modelo_Todos.CheckValue = "Y"
        Me.Rdb_Modelo_Todos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Modelo_Todos.Location = New System.Drawing.Point(140, 3)
        Me.Rdb_Modelo_Todos.Name = "Rdb_Modelo_Todos"
        Me.Rdb_Modelo_Todos.Size = New System.Drawing.Size(85, 19)
        Me.Rdb_Modelo_Todos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Modelo_Todos.TabIndex = 1
        Me.Rdb_Modelo_Todos.Text = "Todos"
        '
        'TableLayoutPanel10
        '
        Me.TableLayoutPanel10.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel10.ColumnCount = 3
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91.0!))
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111.0!))
        Me.TableLayoutPanel10.Controls.Add(Me.LabelX8, 0, 0)
        Me.TableLayoutPanel10.Controls.Add(Me.Rdb_Marca_Algunas, 2, 0)
        Me.TableLayoutPanel10.Controls.Add(Me.Rdb_Marca_Todas, 1, 0)
        Me.TableLayoutPanel10.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel10.Location = New System.Drawing.Point(5, 62)
        Me.TableLayoutPanel10.Name = "TableLayoutPanel10"
        Me.TableLayoutPanel10.RowCount = 1
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel10.Size = New System.Drawing.Size(339, 25)
        Me.TableLayoutPanel10.TabIndex = 26
        '
        'LabelX8
        '
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.ForeColor = System.Drawing.Color.Black
        Me.LabelX8.Location = New System.Drawing.Point(3, 3)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(131, 19)
        Me.LabelX8.TabIndex = 4
        Me.LabelX8.Text = "Marca"
        '
        'Rdb_Marca_Algunas
        '
        Me.Rdb_Marca_Algunas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Marca_Algunas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Marca_Algunas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Marca_Algunas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Marca_Algunas.Location = New System.Drawing.Point(231, 3)
        Me.Rdb_Marca_Algunas.Name = "Rdb_Marca_Algunas"
        Me.Rdb_Marca_Algunas.Size = New System.Drawing.Size(94, 19)
        Me.Rdb_Marca_Algunas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Marca_Algunas.TabIndex = 3
        Me.Rdb_Marca_Algunas.Text = "Algunos"
        '
        'Rdb_Marca_Todas
        '
        Me.Rdb_Marca_Todas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Marca_Todas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Marca_Todas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Marca_Todas.Checked = True
        Me.Rdb_Marca_Todas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Marca_Todas.CheckValue = "Y"
        Me.Rdb_Marca_Todas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Marca_Todas.Location = New System.Drawing.Point(140, 3)
        Me.Rdb_Marca_Todas.Name = "Rdb_Marca_Todas"
        Me.Rdb_Marca_Todas.Size = New System.Drawing.Size(85, 19)
        Me.Rdb_Marca_Todas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Marca_Todas.TabIndex = 1
        Me.Rdb_Marca_Todas.Text = "Todos"
        '
        'TableLayoutPanel11
        '
        Me.TableLayoutPanel11.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel11.ColumnCount = 2
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 238.0!))
        Me.TableLayoutPanel11.Controls.Add(Me.Txt_Nro_Serie, 1, 0)
        Me.TableLayoutPanel11.Controls.Add(Me.LabelX10, 0, 0)
        Me.TableLayoutPanel11.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel11.Location = New System.Drawing.Point(5, 146)
        Me.TableLayoutPanel11.Name = "TableLayoutPanel11"
        Me.TableLayoutPanel11.RowCount = 1
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel11.Size = New System.Drawing.Size(339, 30)
        Me.TableLayoutPanel11.TabIndex = 27
        '
        'Txt_Nro_Serie
        '
        Me.Txt_Nro_Serie.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Nro_Serie.Border.Class = "TextBoxBorder"
        Me.Txt_Nro_Serie.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Nro_Serie.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Nro_Serie.FocusHighlightEnabled = True
        Me.Txt_Nro_Serie.ForeColor = System.Drawing.Color.Black
        Me.Txt_Nro_Serie.Location = New System.Drawing.Point(104, 3)
        Me.Txt_Nro_Serie.MaxLength = 10
        Me.Txt_Nro_Serie.Name = "Txt_Nro_Serie"
        Me.Txt_Nro_Serie.PreventEnterBeep = True
        Me.Txt_Nro_Serie.Size = New System.Drawing.Size(232, 22)
        Me.Txt_Nro_Serie.TabIndex = 28
        Me.Txt_Nro_Serie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Txt_Nro_Serie.WatermarkText = "Ninguna, no aplica filtro"
        '
        'LabelX10
        '
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.ForeColor = System.Drawing.Color.Black
        Me.LabelX10.Location = New System.Drawing.Point(3, 3)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(87, 19)
        Me.LabelX10.TabIndex = 4
        Me.LabelX10.Text = "Número de serie"
        '
        'Grupo_OT
        '
        Me.Grupo_OT.BackColor = System.Drawing.Color.White
        Me.Grupo_OT.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_OT.Controls.Add(Me.TableLayoutPanel7)
        Me.Grupo_OT.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_OT.Location = New System.Drawing.Point(12, 12)
        Me.Grupo_OT.Name = "Grupo_OT"
        Me.Grupo_OT.Size = New System.Drawing.Size(718, 68)
        '
        '
        '
        Me.Grupo_OT.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_OT.Style.BackColorGradientAngle = 90
        Me.Grupo_OT.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_OT.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_OT.Style.BorderBottomWidth = 1
        Me.Grupo_OT.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_OT.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_OT.Style.BorderLeftWidth = 1
        Me.Grupo_OT.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_OT.Style.BorderRightWidth = 1
        Me.Grupo_OT.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_OT.Style.BorderTopWidth = 1
        Me.Grupo_OT.Style.CornerDiameter = 4
        Me.Grupo_OT.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_OT.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_OT.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_OT.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_OT.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_OT.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_OT.TabIndex = 75
        Me.Grupo_OT.Text = "Filtro por número de OT"
        '
        'Grupo_Fechas
        '
        Me.Grupo_Fechas.BackColor = System.Drawing.Color.White
        Me.Grupo_Fechas.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Fechas.Controls.Add(Me.TableLayoutPanel1)
        Me.Grupo_Fechas.Controls.Add(Me.TableLayoutPanel6)
        Me.Grupo_Fechas.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Fechas.Location = New System.Drawing.Point(12, 294)
        Me.Grupo_Fechas.Name = "Grupo_Fechas"
        Me.Grupo_Fechas.Size = New System.Drawing.Size(503, 100)
        '
        '
        '
        Me.Grupo_Fechas.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Fechas.Style.BackColorGradientAngle = 90
        Me.Grupo_Fechas.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Fechas.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Fechas.Style.BorderBottomWidth = 1
        Me.Grupo_Fechas.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Fechas.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Fechas.Style.BorderLeftWidth = 1
        Me.Grupo_Fechas.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Fechas.Style.BorderRightWidth = 1
        Me.Grupo_Fechas.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Fechas.Style.BorderTopWidth = 1
        Me.Grupo_Fechas.Style.CornerDiameter = 4
        Me.Grupo_Fechas.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Fechas.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Fechas.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Fechas.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Fechas.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Fechas.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Fechas.TabIndex = 76
        Me.Grupo_Fechas.Text = "Fechas"
        '
        'Grupo_Maquina
        '
        Me.Grupo_Maquina.BackColor = System.Drawing.Color.White
        Me.Grupo_Maquina.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Maquina.Controls.Add(Me.TableLayoutPanel14)
        Me.Grupo_Maquina.Controls.Add(Me.TableLayoutPanel12)
        Me.Grupo_Maquina.Controls.Add(Me.TableLayoutPanel8)
        Me.Grupo_Maquina.Controls.Add(Me.TableLayoutPanel9)
        Me.Grupo_Maquina.Controls.Add(Me.TableLayoutPanel10)
        Me.Grupo_Maquina.Controls.Add(Me.TableLayoutPanel11)
        Me.Grupo_Maquina.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Maquina.Location = New System.Drawing.Point(375, 86)
        Me.Grupo_Maquina.Name = "Grupo_Maquina"
        Me.Grupo_Maquina.Size = New System.Drawing.Size(356, 201)
        '
        '
        '
        Me.Grupo_Maquina.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Maquina.Style.BackColorGradientAngle = 90
        Me.Grupo_Maquina.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Maquina.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Maquina.Style.BorderBottomWidth = 1
        Me.Grupo_Maquina.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Maquina.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Maquina.Style.BorderLeftWidth = 1
        Me.Grupo_Maquina.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Maquina.Style.BorderRightWidth = 1
        Me.Grupo_Maquina.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Maquina.Style.BorderTopWidth = 1
        Me.Grupo_Maquina.Style.CornerDiameter = 4
        Me.Grupo_Maquina.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Maquina.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Maquina.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Maquina.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Maquina.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Maquina.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Maquina.TabIndex = 77
        Me.Grupo_Maquina.Text = "Datos de la maquina"
        '
        'TableLayoutPanel14
        '
        Me.TableLayoutPanel14.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel14.ColumnCount = 3
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91.0!))
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111.0!))
        Me.TableLayoutPanel14.Controls.Add(Me.LabelX13, 0, 0)
        Me.TableLayoutPanel14.Controls.Add(Me.Rdb_Productos_Algunos, 2, 0)
        Me.TableLayoutPanel14.Controls.Add(Me.Rdb_Productos_Todos, 1, 0)
        Me.TableLayoutPanel14.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel14.Location = New System.Drawing.Point(5, 6)
        Me.TableLayoutPanel14.Name = "TableLayoutPanel14"
        Me.TableLayoutPanel14.RowCount = 1
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel14.Size = New System.Drawing.Size(339, 25)
        Me.TableLayoutPanel14.TabIndex = 79
        '
        'LabelX13
        '
        '
        '
        '
        Me.LabelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX13.ForeColor = System.Drawing.Color.Black
        Me.LabelX13.Location = New System.Drawing.Point(3, 3)
        Me.LabelX13.Name = "LabelX13"
        Me.LabelX13.Size = New System.Drawing.Size(131, 19)
        Me.LabelX13.TabIndex = 4
        Me.LabelX13.Text = "Productos"
        '
        'Rdb_Productos_Algunos
        '
        Me.Rdb_Productos_Algunos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Productos_Algunos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Productos_Algunos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Productos_Algunos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Productos_Algunos.Location = New System.Drawing.Point(231, 3)
        Me.Rdb_Productos_Algunos.Name = "Rdb_Productos_Algunos"
        Me.Rdb_Productos_Algunos.Size = New System.Drawing.Size(94, 19)
        Me.Rdb_Productos_Algunos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Productos_Algunos.TabIndex = 3
        Me.Rdb_Productos_Algunos.Text = "Algunos"
        '
        'Rdb_Productos_Todos
        '
        Me.Rdb_Productos_Todos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Productos_Todos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Productos_Todos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Productos_Todos.Checked = True
        Me.Rdb_Productos_Todos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Productos_Todos.CheckValue = "Y"
        Me.Rdb_Productos_Todos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Productos_Todos.Location = New System.Drawing.Point(140, 3)
        Me.Rdb_Productos_Todos.Name = "Rdb_Productos_Todos"
        Me.Rdb_Productos_Todos.Size = New System.Drawing.Size(85, 19)
        Me.Rdb_Productos_Todos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Productos_Todos.TabIndex = 1
        Me.Rdb_Productos_Todos.Text = "Todos"
        '
        'TableLayoutPanel12
        '
        Me.TableLayoutPanel12.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel12.ColumnCount = 3
        Me.TableLayoutPanel12.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel12.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91.0!))
        Me.TableLayoutPanel12.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111.0!))
        Me.TableLayoutPanel12.Controls.Add(Me.LabelX12, 0, 0)
        Me.TableLayoutPanel12.Controls.Add(Me.Rdb_Categoria_Algunas, 2, 0)
        Me.TableLayoutPanel12.Controls.Add(Me.Rdb_Categoria_Todas, 1, 0)
        Me.TableLayoutPanel12.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel12.Location = New System.Drawing.Point(5, 118)
        Me.TableLayoutPanel12.Name = "TableLayoutPanel12"
        Me.TableLayoutPanel12.RowCount = 1
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel12.Size = New System.Drawing.Size(339, 25)
        Me.TableLayoutPanel12.TabIndex = 78
        '
        'LabelX12
        '
        '
        '
        '
        Me.LabelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX12.ForeColor = System.Drawing.Color.Black
        Me.LabelX12.Location = New System.Drawing.Point(3, 3)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(131, 19)
        Me.LabelX12.TabIndex = 4
        Me.LabelX12.Text = "Categoría"
        '
        'Rdb_Categoria_Algunas
        '
        Me.Rdb_Categoria_Algunas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Categoria_Algunas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Categoria_Algunas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Categoria_Algunas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Categoria_Algunas.Location = New System.Drawing.Point(231, 3)
        Me.Rdb_Categoria_Algunas.Name = "Rdb_Categoria_Algunas"
        Me.Rdb_Categoria_Algunas.Size = New System.Drawing.Size(94, 19)
        Me.Rdb_Categoria_Algunas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Categoria_Algunas.TabIndex = 3
        Me.Rdb_Categoria_Algunas.Text = "Algunas"
        '
        'Rdb_Categoria_Todas
        '
        Me.Rdb_Categoria_Todas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Categoria_Todas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Categoria_Todas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Categoria_Todas.Checked = True
        Me.Rdb_Categoria_Todas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Categoria_Todas.CheckValue = "Y"
        Me.Rdb_Categoria_Todas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Categoria_Todas.Location = New System.Drawing.Point(140, 3)
        Me.Rdb_Categoria_Todas.Name = "Rdb_Categoria_Todas"
        Me.Rdb_Categoria_Todas.Size = New System.Drawing.Size(85, 19)
        Me.Rdb_Categoria_Todas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Categoria_Todas.TabIndex = 1
        Me.Rdb_Categoria_Todas.Text = "Todos"
        '
        'Grupo_Chk_Tipo_Reparacion
        '
        Me.Grupo_Chk_Tipo_Reparacion.BackColor = System.Drawing.Color.White
        Me.Grupo_Chk_Tipo_Reparacion.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Chk_Tipo_Reparacion.Controls.Add(Me.TableLayoutPanel13)
        Me.Grupo_Chk_Tipo_Reparacion.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Chk_Tipo_Reparacion.Location = New System.Drawing.Point(522, 293)
        Me.Grupo_Chk_Tipo_Reparacion.Name = "Grupo_Chk_Tipo_Reparacion"
        Me.Grupo_Chk_Tipo_Reparacion.Size = New System.Drawing.Size(209, 197)
        '
        '
        '
        Me.Grupo_Chk_Tipo_Reparacion.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Chk_Tipo_Reparacion.Style.BackColorGradientAngle = 90
        Me.Grupo_Chk_Tipo_Reparacion.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Chk_Tipo_Reparacion.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Chk_Tipo_Reparacion.Style.BorderBottomWidth = 1
        Me.Grupo_Chk_Tipo_Reparacion.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Chk_Tipo_Reparacion.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Chk_Tipo_Reparacion.Style.BorderLeftWidth = 1
        Me.Grupo_Chk_Tipo_Reparacion.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Chk_Tipo_Reparacion.Style.BorderRightWidth = 1
        Me.Grupo_Chk_Tipo_Reparacion.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Chk_Tipo_Reparacion.Style.BorderTopWidth = 1
        Me.Grupo_Chk_Tipo_Reparacion.Style.CornerDiameter = 4
        Me.Grupo_Chk_Tipo_Reparacion.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Chk_Tipo_Reparacion.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Chk_Tipo_Reparacion.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Chk_Tipo_Reparacion.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Chk_Tipo_Reparacion.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Chk_Tipo_Reparacion.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Chk_Tipo_Reparacion.TabIndex = 83
        Me.Grupo_Chk_Tipo_Reparacion.Text = "Tipo de reparación"
        '
        'TableLayoutPanel13
        '
        Me.TableLayoutPanel13.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel13.ColumnCount = 2
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44.0!))
        Me.TableLayoutPanel13.Controls.Add(Me.Chk_Serv_Demostracion_Maquina, 0, 7)
        Me.TableLayoutPanel13.Controls.Add(Me.Chk_Serv_Garantia, 0, 6)
        Me.TableLayoutPanel13.Controls.Add(Me.Chk_Serv_Mantenimiento_Preventivo, 0, 5)
        Me.TableLayoutPanel13.Controls.Add(Me.Chk_Serv_Recoleccion, 0, 4)
        Me.TableLayoutPanel13.Controls.Add(Me.Chk_Serv_Presupuesto_Pre_Aprobado, 0, 3)
        Me.TableLayoutPanel13.Controls.Add(Me.Chk_Serv_Mantenimiento_Correctivo, 0, 2)
        Me.TableLayoutPanel13.Controls.Add(Me.Chk_Serv_Reparacion_Stock, 0, 1)
        Me.TableLayoutPanel13.Controls.Add(Me.Chk_Serv_Domicilio, 0, 0)
        Me.TableLayoutPanel13.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel13.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel13.Name = "TableLayoutPanel13"
        Me.TableLayoutPanel13.RowCount = 8
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.15152!))
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.7931!))
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.10345!))
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel13.Size = New System.Drawing.Size(217, 168)
        Me.TableLayoutPanel13.TabIndex = 68
        '
        'Chk_Serv_Demostracion_Maquina
        '
        '
        '
        '
        Me.Chk_Serv_Demostracion_Maquina.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Serv_Demostracion_Maquina.ForeColor = System.Drawing.Color.Black
        Me.Chk_Serv_Demostracion_Maquina.Location = New System.Drawing.Point(3, 148)
        Me.Chk_Serv_Demostracion_Maquina.Name = "Chk_Serv_Demostracion_Maquina"
        Me.Chk_Serv_Demostracion_Maquina.Size = New System.Drawing.Size(167, 14)
        Me.Chk_Serv_Demostracion_Maquina.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Serv_Demostracion_Maquina.TabIndex = 88
        Me.Chk_Serv_Demostracion_Maquina.Text = "Demostración de maquina"
        '
        'Chk_Serv_Garantia
        '
        '
        '
        '
        Me.Chk_Serv_Garantia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Serv_Garantia.ForeColor = System.Drawing.Color.Black
        Me.Chk_Serv_Garantia.Location = New System.Drawing.Point(3, 127)
        Me.Chk_Serv_Garantia.Name = "Chk_Serv_Garantia"
        Me.Chk_Serv_Garantia.Size = New System.Drawing.Size(70, 15)
        Me.Chk_Serv_Garantia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Serv_Garantia.TabIndex = 70
        Me.Chk_Serv_Garantia.Text = "Garantía"
        '
        'Chk_Serv_Mantenimiento_Preventivo
        '
        '
        '
        '
        Me.Chk_Serv_Mantenimiento_Preventivo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Serv_Mantenimiento_Preventivo.ForeColor = System.Drawing.Color.Black
        Me.Chk_Serv_Mantenimiento_Preventivo.Location = New System.Drawing.Point(3, 106)
        Me.Chk_Serv_Mantenimiento_Preventivo.Name = "Chk_Serv_Mantenimiento_Preventivo"
        Me.Chk_Serv_Mantenimiento_Preventivo.Size = New System.Drawing.Size(167, 14)
        Me.Chk_Serv_Mantenimiento_Preventivo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Serv_Mantenimiento_Preventivo.TabIndex = 70
        Me.Chk_Serv_Mantenimiento_Preventivo.Text = "Mantenimiento preventivo"
        '
        'Chk_Serv_Recoleccion
        '
        '
        '
        '
        Me.Chk_Serv_Recoleccion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Serv_Recoleccion.ForeColor = System.Drawing.Color.Black
        Me.Chk_Serv_Recoleccion.Location = New System.Drawing.Point(3, 85)
        Me.Chk_Serv_Recoleccion.Name = "Chk_Serv_Recoleccion"
        Me.Chk_Serv_Recoleccion.Size = New System.Drawing.Size(167, 15)
        Me.Chk_Serv_Recoleccion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Serv_Recoleccion.TabIndex = 70
        Me.Chk_Serv_Recoleccion.Text = "Servicio de recolección"
        '
        'Chk_Serv_Presupuesto_Pre_Aprobado
        '
        '
        '
        '
        Me.Chk_Serv_Presupuesto_Pre_Aprobado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Serv_Presupuesto_Pre_Aprobado.ForeColor = System.Drawing.Color.Black
        Me.Chk_Serv_Presupuesto_Pre_Aprobado.Location = New System.Drawing.Point(3, 64)
        Me.Chk_Serv_Presupuesto_Pre_Aprobado.Name = "Chk_Serv_Presupuesto_Pre_Aprobado"
        Me.Chk_Serv_Presupuesto_Pre_Aprobado.Size = New System.Drawing.Size(167, 14)
        Me.Chk_Serv_Presupuesto_Pre_Aprobado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Serv_Presupuesto_Pre_Aprobado.TabIndex = 70
        Me.Chk_Serv_Presupuesto_Pre_Aprobado.Text = "Presupuesto Pre-Aprobado"
        '
        'Chk_Serv_Mantenimiento_Correctivo
        '
        '
        '
        '
        Me.Chk_Serv_Mantenimiento_Correctivo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Serv_Mantenimiento_Correctivo.ForeColor = System.Drawing.Color.Black
        Me.Chk_Serv_Mantenimiento_Correctivo.Location = New System.Drawing.Point(3, 45)
        Me.Chk_Serv_Mantenimiento_Correctivo.Name = "Chk_Serv_Mantenimiento_Correctivo"
        Me.Chk_Serv_Mantenimiento_Correctivo.Size = New System.Drawing.Size(167, 13)
        Me.Chk_Serv_Mantenimiento_Correctivo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Serv_Mantenimiento_Correctivo.TabIndex = 70
        Me.Chk_Serv_Mantenimiento_Correctivo.Text = "Mantenimiento correctivo"
        '
        'Chk_Serv_Reparacion_Stock
        '
        '
        '
        '
        Me.Chk_Serv_Reparacion_Stock.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Serv_Reparacion_Stock.ForeColor = System.Drawing.Color.Black
        Me.Chk_Serv_Reparacion_Stock.Location = New System.Drawing.Point(3, 25)
        Me.Chk_Serv_Reparacion_Stock.Name = "Chk_Serv_Reparacion_Stock"
        Me.Chk_Serv_Reparacion_Stock.Size = New System.Drawing.Size(167, 14)
        Me.Chk_Serv_Reparacion_Stock.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Serv_Reparacion_Stock.TabIndex = 70
        Me.Chk_Serv_Reparacion_Stock.Text = "Reparación de Stock (Interno)"
        '
        'Chk_Serv_Domicilio
        '
        '
        '
        '
        Me.Chk_Serv_Domicilio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Serv_Domicilio.ForeColor = System.Drawing.Color.Black
        Me.Chk_Serv_Domicilio.Location = New System.Drawing.Point(3, 3)
        Me.Chk_Serv_Domicilio.Name = "Chk_Serv_Domicilio"
        Me.Chk_Serv_Domicilio.Size = New System.Drawing.Size(167, 16)
        Me.Chk_Serv_Domicilio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Serv_Domicilio.TabIndex = 69
        Me.Chk_Serv_Domicilio.Text = "Servicio a domicilio"
        '
        'Frm_St_Filtrar_Ordenes_de_trabajo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(743, 539)
        Me.Controls.Add(Me.Grupo_Chk_Tipo_Reparacion)
        Me.Controls.Add(Me.Grupo_Maquina)
        Me.Controls.Add(Me.Grupo_Fechas)
        Me.Controls.Add(Me.Grupo_OT)
        Me.Controls.Add(Me.Grupo_Entidad)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_St_Filtrar_Ordenes_de_trabajo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Ordenes de Trabajo"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo_Entidad.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel7.ResumeLayout(False)
        Me.TableLayoutPanel6.ResumeLayout(False)
        CType(Me.Dtp_Fecha_Cierre_Hasta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_Fecha_Cierre_Desde, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.Dtp_Fecha_Emision_Hasta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_Fecha_Emision_Desde, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel8.ResumeLayout(False)
        Me.TableLayoutPanel9.ResumeLayout(False)
        Me.TableLayoutPanel10.ResumeLayout(False)
        Me.TableLayoutPanel11.ResumeLayout(False)
        Me.Grupo_OT.ResumeLayout(False)
        Me.Grupo_Fechas.ResumeLayout(False)
        Me.Grupo_Maquina.ResumeLayout(False)
        Me.TableLayoutPanel14.ResumeLayout(False)
        Me.TableLayoutPanel12.ResumeLayout(False)
        Me.Grupo_Chk_Tipo_Reparacion.ResumeLayout(False)
        Me.TableLayoutPanel13.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnFiltrar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Txt_Nro_OT As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Grupo_Entidad As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_Estados_Algunos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Estados_Todas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_Tecnico_Repara_Algunos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Tecnico_Repara_Todos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_Tecnico_Asignado_Algunos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Tecnico_Asignado_Todos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_Entidades_Algunas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Entidades_Todas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Dtp_Fecha_Emision_Desde As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_Fecha_Emision_Rango As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Fecha_Emision_Todas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Lbl_FE_desde As DevComponents.DotNetBar.LabelX
    Friend WithEvents TableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Dtp_Fecha_Cierre_Hasta As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Lbl_FC_hasta As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dtp_Fecha_Cierre_Desde As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_Fecha_Cierre_Rango As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Fecha_Cierre_Todas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Lbl_FC_desde As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dtp_Fecha_Emision_Hasta As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Lbl_FE_hasta As DevComponents.DotNetBar.LabelX
    Friend WithEvents TableLayoutPanel7 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_Orden_de_trabajo_Una As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Orden_de_trabajo_Todas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Imagenes_32x32 As System.Windows.Forms.ImageList
    Friend WithEvents TableLayoutPanel9 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_Modelo_Algunos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Modelo_Todos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents TableLayoutPanel8 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_Manquina_Algunas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Manquina_Todas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents TableLayoutPanel10 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_Marca_Algunas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Marca_Todas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents TableLayoutPanel11 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Txt_Nro_Serie As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Grupo_OT As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grupo_Fechas As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grupo_Maquina As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Rdb_Categoria_Algunas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Categoria_Todas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents TableLayoutPanel12 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Grupo_Chk_Tipo_Reparacion As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel13 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Chk_Serv_Demostracion_Maquina As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Serv_Garantia As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Serv_Mantenimiento_Preventivo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Serv_Recoleccion As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Serv_Presupuesto_Pre_Aprobado As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Serv_Mantenimiento_Correctivo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Serv_Reparacion_Stock As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Serv_Domicilio As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents TableLayoutPanel14 As TableLayoutPanel
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_Productos_Algunos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Productos_Todos As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
