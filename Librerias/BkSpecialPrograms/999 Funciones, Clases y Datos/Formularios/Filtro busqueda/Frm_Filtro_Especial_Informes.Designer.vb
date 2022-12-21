<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Filtro_Especial_Informes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Filtro_Especial_Informes))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.BtnAceptar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Exportar_Excel = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Crear = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Editar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Eliminar = New DevComponents.DotNetBar.ButtonItem()
        Me.Txt_Descripcion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Btn_Ayuda_Asistente_Busqueda = New DevComponents.DotNetBar.ButtonX()
        Me.Cmb_Filtro_Codigo = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Codigo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_01 = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Ver_documento_origen = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Rdb_Mostrar_Todos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Mostrar_Solo_Tickeados = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Seleccionar_Todos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnAceptar, Me.Btn_Exportar_Excel, Me.Btn_Crear, Me.Btn_Editar, Me.Btn_Eliminar})
        Me.Bar1.Location = New System.Drawing.Point(0, 520)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(611, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 6
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnAceptar
        '
        Me.BtnAceptar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnAceptar.ForeColor = System.Drawing.Color.Black
        Me.BtnAceptar.Image = CType(resources.GetObject("BtnAceptar.Image"), System.Drawing.Image)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Text = "Aceptar"
        '
        'Btn_Exportar_Excel
        '
        Me.Btn_Exportar_Excel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Exportar_Excel.ForeColor = System.Drawing.Color.Black
        Me.Btn_Exportar_Excel.Image = CType(resources.GetObject("Btn_Exportar_Excel.Image"), System.Drawing.Image)
        Me.Btn_Exportar_Excel.Name = "Btn_Exportar_Excel"
        Me.Btn_Exportar_Excel.Tooltip = "Exportar a Excel"
        '
        'Btn_Crear
        '
        Me.Btn_Crear.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Crear.ForeColor = System.Drawing.Color.Black
        Me.Btn_Crear.Image = CType(resources.GetObject("Btn_Crear.Image"), System.Drawing.Image)
        Me.Btn_Crear.Name = "Btn_Crear"
        Me.Btn_Crear.Text = "Crear"
        Me.Btn_Crear.Visible = False
        '
        'Btn_Editar
        '
        Me.Btn_Editar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Editar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Editar.Image = CType(resources.GetObject("Btn_Editar.Image"), System.Drawing.Image)
        Me.Btn_Editar.Name = "Btn_Editar"
        Me.Btn_Editar.Text = "Editar"
        Me.Btn_Editar.Visible = False
        '
        'Btn_Eliminar
        '
        Me.Btn_Eliminar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Eliminar.Enabled = False
        Me.Btn_Eliminar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Eliminar.Image = CType(resources.GetObject("Btn_Eliminar.Image"), System.Drawing.Image)
        Me.Btn_Eliminar.Name = "Btn_Eliminar"
        Me.Btn_Eliminar.Text = "Eliminar"
        Me.Btn_Eliminar.Visible = False
        '
        'Txt_Descripcion
        '
        Me.Txt_Descripcion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Descripcion.Border.Class = "TextBoxBorder"
        Me.Txt_Descripcion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Descripcion.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Descripcion.FocusHighlightEnabled = True
        Me.Txt_Descripcion.ForeColor = System.Drawing.Color.Black
        Me.Txt_Descripcion.Location = New System.Drawing.Point(78, 40)
        Me.Txt_Descripcion.Name = "Txt_Descripcion"
        Me.Txt_Descripcion.PreventEnterBeep = True
        Me.Txt_Descripcion.Size = New System.Drawing.Size(508, 22)
        Me.Txt_Descripcion.TabIndex = 2
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Btn_Ayuda_Asistente_Busqueda)
        Me.GroupPanel1.Controls.Add(Me.Cmb_Filtro_Codigo)
        Me.GroupPanel1.Controls.Add(Me.LabelX2)
        Me.GroupPanel1.Controls.Add(Me.LabelX1)
        Me.GroupPanel1.Controls.Add(Me.Txt_Codigo)
        Me.GroupPanel1.Controls.Add(Me.Txt_Descripcion)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(8, 4)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(595, 91)
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
        Me.GroupPanel1.TabIndex = 9
        Me.GroupPanel1.Text = "Buscar categoria por descripción"
        '
        'Btn_Ayuda_Asistente_Busqueda
        '
        Me.Btn_Ayuda_Asistente_Busqueda.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Ayuda_Asistente_Busqueda.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Ayuda_Asistente_Busqueda.Location = New System.Drawing.Point(290, 14)
        Me.Btn_Ayuda_Asistente_Busqueda.Name = "Btn_Ayuda_Asistente_Busqueda"
        Me.Btn_Ayuda_Asistente_Busqueda.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Ayuda_Asistente_Busqueda.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Ayuda_Asistente_Busqueda.TabIndex = 17
        Me.Btn_Ayuda_Asistente_Busqueda.Text = "Ayuda..."
        '
        'Cmb_Filtro_Codigo
        '
        Me.Cmb_Filtro_Codigo.DisplayMember = "Text"
        Me.Cmb_Filtro_Codigo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Filtro_Codigo.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Filtro_Codigo.FormattingEnabled = True
        Me.Cmb_Filtro_Codigo.ItemHeight = 16
        Me.Cmb_Filtro_Codigo.Location = New System.Drawing.Point(78, 14)
        Me.Cmb_Filtro_Codigo.Name = "Cmb_Filtro_Codigo"
        Me.Cmb_Filtro_Codigo.Size = New System.Drawing.Size(91, 22)
        Me.Cmb_Filtro_Codigo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Filtro_Codigo.TabIndex = 14
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 37)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(68, 23)
        Me.LabelX2.TabIndex = 13
        Me.LabelX2.Text = "Descripción"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 14)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(41, 23)
        Me.LabelX1.TabIndex = 12
        Me.LabelX1.Text = "Código"
        '
        'Txt_Codigo
        '
        Me.Txt_Codigo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Codigo.Border.Class = "TextBoxBorder"
        Me.Txt_Codigo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Codigo.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Codigo.FocusHighlightEnabled = True
        Me.Txt_Codigo.ForeColor = System.Drawing.Color.Black
        Me.Txt_Codigo.Location = New System.Drawing.Point(175, 14)
        Me.Txt_Codigo.Name = "Txt_Codigo"
        Me.Txt_Codigo.PreventEnterBeep = True
        Me.Txt_Codigo.Size = New System.Drawing.Size(109, 22)
        Me.Txt_Codigo.TabIndex = 11
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.ContextMenuBar1)
        Me.GroupPanel2.Controls.Add(Me.Grilla)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(8, 101)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(595, 384)
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
        Me.GroupPanel2.TabIndex = 10
        Me.GroupPanel2.Text = "Detalle"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_01})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(110, 58)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(334, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 48
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_01
        '
        Me.Menu_Contextual_01.AutoExpandOnClick = True
        Me.Menu_Contextual_01.Name = "Menu_Contextual_01"
        Me.Menu_Contextual_01.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Ver_documento_origen})
        Me.Menu_Contextual_01.Text = "Opciones"
        '
        'Btn_Ver_documento_origen
        '
        Me.Btn_Ver_documento_origen.Image = CType(resources.GetObject("Btn_Ver_documento_origen.Image"), System.Drawing.Image)
        Me.Btn_Ver_documento_origen.Name = "Btn_Ver_documento_origen"
        Me.Btn_Ver_documento_origen.Text = "Copiar"
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
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla.Size = New System.Drawing.Size(589, 361)
        Me.Grilla.StandardTab = True
        Me.Grilla.TabIndex = 29
        '
        'Rdb_Mostrar_Todos
        '
        Me.Rdb_Mostrar_Todos.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Rdb_Mostrar_Todos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Mostrar_Todos.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Mostrar_Todos.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Mostrar_Todos.CheckBoxImageUnChecked = CType(resources.GetObject("Rdb_Mostrar_Todos.CheckBoxImageUnChecked"), System.Drawing.Image)
        Me.Rdb_Mostrar_Todos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Mostrar_Todos.Checked = True
        Me.Rdb_Mostrar_Todos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Mostrar_Todos.CheckValue = "Y"
        Me.Rdb_Mostrar_Todos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Mostrar_Todos.Location = New System.Drawing.Point(8, 491)
        Me.Rdb_Mostrar_Todos.Name = "Rdb_Mostrar_Todos"
        Me.Rdb_Mostrar_Todos.Size = New System.Drawing.Size(100, 23)
        Me.Rdb_Mostrar_Todos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Mostrar_Todos.TabIndex = 11
        Me.Rdb_Mostrar_Todos.Text = "Mostrar todos"
        '
        'Rdb_Mostrar_Solo_Tickeados
        '
        Me.Rdb_Mostrar_Solo_Tickeados.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Rdb_Mostrar_Solo_Tickeados.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Mostrar_Solo_Tickeados.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Mostrar_Solo_Tickeados.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Mostrar_Solo_Tickeados.CheckBoxImageUnChecked = CType(resources.GetObject("Rdb_Mostrar_Solo_Tickeados.CheckBoxImageUnChecked"), System.Drawing.Image)
        Me.Rdb_Mostrar_Solo_Tickeados.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Mostrar_Solo_Tickeados.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Mostrar_Solo_Tickeados.Location = New System.Drawing.Point(104, 491)
        Me.Rdb_Mostrar_Solo_Tickeados.Name = "Rdb_Mostrar_Solo_Tickeados"
        Me.Rdb_Mostrar_Solo_Tickeados.Size = New System.Drawing.Size(142, 23)
        Me.Rdb_Mostrar_Solo_Tickeados.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Mostrar_Solo_Tickeados.TabIndex = 12
        Me.Rdb_Mostrar_Solo_Tickeados.Text = "Mostrar solo tickeados"
        '
        'Chk_Seleccionar_Todos
        '
        Me.Chk_Seleccionar_Todos.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Seleccionar_Todos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Seleccionar_Todos.CheckBoxImageChecked = CType(resources.GetObject("Chk_Seleccionar_Todos.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Seleccionar_Todos.CheckBoxImageUnChecked = CType(resources.GetObject("Chk_Seleccionar_Todos.CheckBoxImageUnChecked"), System.Drawing.Image)
        Me.Chk_Seleccionar_Todos.ForeColor = System.Drawing.Color.Black
        Me.Chk_Seleccionar_Todos.Location = New System.Drawing.Point(430, 491)
        Me.Chk_Seleccionar_Todos.Name = "Chk_Seleccionar_Todos"
        Me.Chk_Seleccionar_Todos.Size = New System.Drawing.Size(170, 23)
        Me.Chk_Seleccionar_Todos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Seleccionar_Todos.TabIndex = 13
        Me.Chk_Seleccionar_Todos.Text = "Seleccionar todos los registros"
        '
        'Frm_Filtro_Especial_Informes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(611, 561)
        Me.Controls.Add(Me.Chk_Seleccionar_Todos)
        Me.Controls.Add(Me.Rdb_Mostrar_Solo_Tickeados)
        Me.Controls.Add(Me.Rdb_Mostrar_Todos)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Filtro_Especial_Informes"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FILTROS DE INFORME"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnAceptar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Txt_Descripcion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Codigo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Rdb_Mostrar_Todos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Mostrar_Solo_Tickeados As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Seleccionar_Todos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Cmb_Filtro_Codigo As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_01 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Ver_documento_origen As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Ayuda_Asistente_Busqueda As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Exportar_Excel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Btn_Crear As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Editar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Eliminar As DevComponents.DotNetBar.ButtonItem
End Class
